using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Dicom_project_listr
{
    public class DatasetHeader//стандарт
    {
        public string GroupID;
        public string ElementID;
        public string VR;
        public string ElementName;

        public DatasetHeader()
        {
            SetGroupID("0008");
            SetElementID("0001");
            SetVR("UL");
            SetElementName("Lenght to end");
        }

        public DatasetHeader(string GID, string EID, string pVR, string EN)
        {
            SetGroupID(GID);
            SetElementID(EID);
            SetVR(pVR);
            SetElementName(EN);
        }

        public void SetGroupID(string GID) { GroupID = GID; }
        public void SetElementID(string EID) { ElementID = EID; }
        public void SetVR(string pVR) { VR = pVR; }
        public void SetElementName(string EN) { ElementName = EN; }

        public string GetGroupID() { return GroupID; }
        public string GetElementID() { return ElementID; }
        public string GetVR() { return VR; }
        public string GetElementName() { return ElementName; }



        public DatasetHeader(XmlNode node)
        {
            Set_XMLNode(node);
        }

        public void Set_XMLNode(XmlNode node)
        {
                foreach (XmlAttribute attr in node.Attributes)
                {
                        if (attr.Name == "GroupID")
                            GroupID = attr.InnerText;
                        else if (attr.Name == "ElementID")
                            ElementID = attr.InnerText;
                }
                foreach (XmlNode child in node.ChildNodes)
                {
                        if (child.Name == "VR")
                            VR = child.InnerText;
                        else if (child.Name == "Name")
                            ElementName = child.InnerText;     
                }     
        }

        public override string ToString()
        {
            return (GroupID + " " + ElementID + " " + VR + " " + ElementName);
        }
    }

    public  class DicomElements: List<DatasetHeader>
    {
        public void Load_XML(string filename)
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(filename);
            foreach (XmlNode node in xml_doc.DocumentElement)
            {
                Add(new DatasetHeader(node));
            }
        }

        public DicomElements(string filename)
        {
            Load_XML(filename);
        }

        public string Get_VR(string Group, string Element)
        {
            string res;
            int i = 0;
            while (i < Count && (this[i].GroupID!=Group || this[i].ElementID != Element))
            {
                i++;
            }
            if (i < Count)
                res = this[i].VR;
            else
                res = "UN";
            return res;
        }

        public DatasetHeader Get_dataset(string ng, string ne) // ne -номер элемента, ng - номер группы
        {
            DatasetHeader dsh;
            if (ne == "0000")
            {
                dsh = new DatasetHeader(ng, ne, "UL", "Group Length");
            }
            else
            {
                int i=0;
                while (i < Count && (this[i].GroupID != ng || this[i].ElementID != ne))
                {
                    i++;
                }
                if (i < Count)
                    dsh = this[i];
                else
                     dsh = new DatasetHeader(ng, ne,"UN", "User Data");
            }
            return dsh;
        }
    }

    public class Dicom_dataset
    {
        public DatasetHeader dsheader;
        public uint length;
        public byte[] value;

        public Dicom_dataset(DatasetHeader dsh)
        {
            SetDSHeader(dsh);
        }
        public Dicom_dataset(DatasetHeader dsh, uint l, byte[] val)
        {
            SetDSHeader(dsh);
            SetLength(l);
            SetValue(val);
        }
        public Dicom_dataset(DatasetHeader dsh, uint l):this(dsh)
        {
            SetLength(l);
            SetDSHeader(dsh);
        }

        public void SetLength(uint l) { length = l; }
        public void SetDSHeader(DatasetHeader dsh) { dsheader = dsh; }
        public void SetValue(byte[] val) { value = val; }

        public DatasetHeader GetDSHeader() { return dsheader; }
        public uint GetLenth() { return length; }
        public byte[] GetValue() { return value; }
        
        public string GetValueStr(Encoding enc)
        {
            string res;
            if (length == 0)
                res = "";
            else
            {
                switch(dsheader.VR)
                {
                    case "SS": res = BitConverter.ToInt16(value, 0).ToString(); break;
                    case "US": res = BitConverter.ToUInt16(value, 0).ToString(); break;
                    case "SL": res = BitConverter.ToInt32(value, 0).ToString(); break;
                    case "UL": res = BitConverter.ToUInt32(value, 0).ToString(); break;
                    case "FL": res = BitConverter.ToDouble(value, 0).ToString(); break;
                    case "FD": res = BitConverter.ToDouble(value, 0).ToString(); break;
                    case "SV": res = BitConverter.ToInt64(value, 0).ToString(); break;
                    case "UV": res = BitConverter.ToUInt64(value, 0).ToString(); break;
                    case "OB":
                        {
                            int tmp=0;
                            for (int i = 0; i<value.Length; i++)
                            {
                                tmp += (value[i] << i * 8);
                            }
                            res = tmp.ToString();
                            break;
                        }
                    default: res = enc.GetString(value); break;
                }

            }

            return res.Trim(new char[] {(char)0});
        }
    }

   

    public class Dicom_File : List<Dicom_dataset>
    {
        private readonly FileInfo file_info;
        private readonly BinaryReader br;
        public readonly Encoding charset;
        private readonly bool ImplicitVR;
        private readonly DicomElements dicom_elements;
        public readonly Size Bmp_size;
        public readonly ushort bits_allocated;
        public readonly ushort bits_stored;
        public readonly double WL;
        public readonly double WW;
        public Bitmap bmp;
        public IntPtr ptr;

        public Dicom_File(string filename, DicomElements de)
        {
            br = new BinaryReader(File.Open(filename, FileMode.Open)); //считыватель файла
            if (IsDicom())
            {
                file_info = new FileInfo(filename);
                charset = Encoding.ASCII;
                NumberFormatInfo nfi = new CultureInfo("ru-RU", false).NumberFormat;
                nfi.NumberDecimalSeparator = ".";
                ImplicitVR = false;
                dicom_elements = de;
                Dicom_dataset ds = new Dicom_dataset(dicom_elements.Get_dataset("0002", "0000")); // первый Dataset файла всегда размер группы 0002, можно не читать
                //ds.dsheader.VR = "UL"; // VR размера группы всегда UL, можно не читать
                ds.length = 4; // длина значения 'размер группы' всегда 4 байта, можно не читать
                br.ReadBytes(2 + 2 + 2 + 2); // пропускаем номер группы, номер элемента, VR и длину
                uint group2length = br.ReadUInt32(); // считываем размер группы 0002 (4 байта)
                ds.value = BitConverter.GetBytes(group2length); // преобразовываем его в массив байтов
                Add(ds); // добавляем Dataset размера группы в список
                long group2end = br.BaseStream.Position + group2length; // определяем конец группы 0002
                while (br.BaseStream.Position < group2end)
                {
                    // считываем номер группы и номер элемента очередного датасета, преобразовываем в строку в шестнадцатиричном формате, создаем новый экземпляр DicomDataSet
                    ds = new Dicom_dataset(dicom_elements.Get_dataset(br.ReadInt16().ToString("X4"), br.ReadInt16().ToString("X4")));
                    ds.dsheader.VR = Encoding.ASCII.GetString(br.ReadBytes(2)); // получаем VR - считываем 2 байта, преобразуем их в строку
                    ds.length = ReadLength(ds.dsheader.VR);  // считываем длину значения, основываясь на VR
                    ds.value = br.ReadBytes((int)ds.length);  // считываем значение, то есть читаем столько байтов, ссколько получили длину в предыдущей строке 
                    Add(ds); // добавляем датасет в список

                    if (ds.dsheader.ElementID == "0010")
                    {
                        string str = ds.GetValueStr(Encoding.ASCII);
                        if (str == "1.2.840.10008.1.2")
                            ImplicitVR = true;
                        else
                            ImplicitVR = false;
                    }
                };
                bool isPixelData = false;
                do
                {
                    ds = new Dicom_dataset(dicom_elements.Get_dataset(br.ReadInt16().ToString("X4"), br.ReadInt16().ToString("X4")));
                    if (!ImplicitVR)
                        ds.dsheader.VR = Encoding.ASCII.GetString(br.ReadBytes(2));
                    else
                        br.ReadBytes(2);
                    ds.length = ReadLength(ds.dsheader.VR, ImplicitVR);
                    isPixelData = (ds.dsheader.GroupID == "7FE0" && ds.dsheader.ElementID == "0010");
                    if (isPixelData)
                    {
                        ds.value = Encoding.ASCII.GetBytes(new char[] { 'D', 'i', 'c', 'o', 'm' });
                        CreateImage();
                    }
                    else
                    {
                        ds.value = br.ReadBytes((int)ds.length);
                        if (ds.dsheader.GroupID == "0008" && ds.dsheader.ElementID == "0005")
                        {
                            if (Encoding.ASCII.GetString(ds.value) == "ISO_IR 144")
                                charset = Encoding.GetEncoding(28595);
                            else if (Encoding.ASCII.GetString(ds.value) == "ISO 2022 IR 6\\IS")
                                charset = Encoding.ASCII;
                            //charset = Encoding.GetEncoding(1251);
                        }
                        if (ds.dsheader.GroupID == "0028" && ds.dsheader.ElementID == "0010")
                        {
                            Bmp_size.Height = BitConverter.ToUInt16(ds.value,0);
                        }
                        if (ds.dsheader.GroupID == "0028" && ds.dsheader.ElementID == "0011")
                        {
                            Bmp_size.Width = BitConverter.ToUInt16(ds.value,0);
                        }
                        if (ds.dsheader.GroupID == "0028" && ds.dsheader.ElementID == "0100")
                        {
                            bits_allocated = BitConverter.ToUInt16(ds.value,0);
                        }
                        if (ds.dsheader.GroupID == "0028" && ds.dsheader.ElementID == "0101")
                        {
                            bits_stored = BitConverter.ToUInt16(ds.value,0);
                        }
                        if (ds.dsheader.GroupID == "0028" && ds.dsheader.ElementID == "1050")
                        {
                            WL = Convert.ToDouble(ds.GetValueStr(Encoding.ASCII), nfi);
                        }
                        if (ds.dsheader.GroupID == "0028" && ds.dsheader.ElementID == "1051")
                        {
                            WW = Convert.ToDouble(ds.GetValueStr(Encoding.ASCII), nfi);
                        }
                    }
                    Add(ds);
                } while (!isPixelData);
                br.Close();
            }
           //group ="7fe0" element = "0010"
            else
            {
                br.Close();
                throw new FormatException("Not DICOM file");
            }
        }

        private bool IsDicom() //сравниваем сигнатуру на соответствие DICM
        {
            br.ReadBytes(128); // пропускаем преамбулу
            byte[] h = br.ReadBytes(4); // считываем сигнатуру
            return (Encoding.ASCII.GetString(h) == "DICM"); 
        }

        public void CreateImage()
        {
            byte[] file_pixels = br.ReadBytes(Bmp_size.Height * Bmp_size.Width * (bits_allocated / 8));//исходная инфа о картинке
            byte[] pixels = new byte[Bmp_size.Height * Bmp_size.Width * 3]; //массив для ргб
            int j = 0;
            for(int i=0; i<file_pixels.Length; i+=2)
            {
                int grey = file_pixels[i] + (file_pixels[i+1]<<8);
                int grey_8bit;
                if (grey <= (WL - 0.5 - (WW - 1) / 2))
                    grey_8bit = 0;
                else if (grey > (WL - 0.5 + (WW - 1) / 2))
                    grey_8bit = 255;
                else
                    grey_8bit = (int)(((grey - (WL - 0.5)) / (WW - 1) + 0.5) * 255);
                pixels[j] = (byte)grey_8bit;
                pixels[j + 1] = (byte)grey_8bit;
                pixels[j + 2] = (byte)grey_8bit;
                j += 3;
            }
            int size = Marshal.SizeOf(pixels[0]) * pixels.Length;
            ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(pixels, 0, ptr, size);
            bmp = new Bitmap(Bmp_size.Width, Bmp_size.Height, Bmp_size.Width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, ptr);
        }

        public uint ReadLength(string vr, bool IsImplicitVR = false)
        {
            uint result;
            if (IsImplicitVR)
                result = br.ReadUInt32();
            else
            {
                if (vr == "OB" || vr == "OT" || vr == "OW" || vr == "UN" || vr == "UT" || vr == "SQ")
                {
                    br.ReadBytes(2);
                    result = br.ReadUInt32();
                }
                else
                    result = br.ReadUInt16();

            }
            if (vr == "SQ")
            {
                if (result == 0xffffffff)
                {
                    ushort tmp;
                    bool stop = false;
                    do
                    {
                        tmp = br.ReadUInt16();
                        if (tmp == 0xfffe)
                        {
                            tmp = br.ReadUInt16();
                            stop = (tmp == 0xe0dd);
                        }
                    } while (!stop);
                    br.ReadBytes(4);
                    result = 0;
                }
            }
            return result;
        }

        public void SaveasXML(string filename)
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration declaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(declaration);

            XmlElement root = xml.CreateElement("DicomFile");
            xml.AppendChild(root);

            foreach (Dicom_dataset dataSet in this)
            {
                XmlNode node = xml.CreateElement("Dicom_Dataset");
                XmlAttribute attribute = xml.CreateAttribute("GroupID");
                attribute.Value = dataSet.dsheader.GroupID;
                node.Attributes.Append(attribute);

                attribute = xml.CreateAttribute("ElementID");
                attribute.Value = dataSet.dsheader.ElementID;
                node.Attributes.Append(attribute);

                XmlNode child = xml.CreateElement("VR");
                child.InnerText = dataSet.dsheader.VR;
                node.AppendChild(child);

                child = xml.CreateElement("Description");
                child.InnerText = dataSet.dsheader.ElementName;
                node.AppendChild(child);

                child = xml.CreateElement("Size");
                child.InnerText = dataSet.length.ToString();
                node.AppendChild(child);

                child = xml.CreateElement("Value");
                child.InnerText = dataSet.GetValueStr(charset);
                node.AppendChild(child);

                root.AppendChild(node);

            }
            xml.Save(filename);
        }
        
        ~Dicom_File()
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
}

