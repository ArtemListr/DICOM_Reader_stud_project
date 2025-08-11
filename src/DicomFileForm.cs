using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dicom_project_listr
{
    public partial class DicomFileForm : Form
    {
        public Dicom_File dicom_file;

        
        public DicomFileForm(string p_filename, DicomElements dicom_elements)
        {
            InitializeComponent();
            dicom_file = new Dicom_File(p_filename, dicom_elements);
        }

        private void ShowData()
        {
            dataGV.Rows.Clear();
            foreach(Dicom_dataset ds in dicom_file)
            {
                object[] o = { ds.dsheader.GroupID, ds.dsheader.ElementID, ds.dsheader.VR, ds.dsheader.ElementName, ds.length, ds.GetValueStr(dicom_file.charset) };
                dataGV.Rows.Add(o);
            }
        }
        private void DicomFileForm_Load(object sender, EventArgs e)
        {
            ShowData();
            picbox.Height = dicom_file.bmp.Height;
            picbox.Width = dicom_file.bmp.Width;
            picbox.Image = dicom_file.bmp;
        }

      /*  private void dataGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGV.Rows[e.RowIndex].Cells[1].Value.ToString() == "0000")
                e.CellStyle.BackColor = Color.YellowGreen;
        }*/



    }
}
