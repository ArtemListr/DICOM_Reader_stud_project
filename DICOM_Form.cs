using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dicom_project_listr
{
    public partial class Form_dicom : Form
    {
        public DicomElements dicomelements;
        
        public Form_dicom()
        {
            InitializeComponent();
            dicomelements = new DicomElements("dicom-elements.xml");
        }

        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_dicom_Load(object sender, EventArgs e)
        {
            dicomelements = new DicomElements("dicom-elements.XML");

        }

        private void Form_dicom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void tsmi_OpenFile_Click(object sender, EventArgs e)
        {
            if (ofd_dicom.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DicomFileForm dff = new DicomFileForm(ofd_dicom.FileName, dicomelements); 
                    dff.MdiParent = this;
                    dff.Show();
                }
                catch(FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmi_SaveToXML_Click(object sender, EventArgs e)
        {
            if (sfd_dicom.ShowDialog() == DialogResult.OK)
                (ActiveMdiChild as DicomFileForm).dicom_file.SaveasXML(sfd_dicom.FileName);
        }

        /* private void tsmi_SaveToXML_Click(object sender, EventArgs e)
         {
             if(sfd_dicom.ShowDialog()==DialogResult.OK)
                 dicomelements.
         }*/
    }
}
