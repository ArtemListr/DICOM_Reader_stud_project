
namespace Dicom_project_listr
{
    partial class Form_dicom
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_dicom));
            this.ms_main = new System.Windows.Forms.MenuStrip();
            this.tsmi_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveToXML = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_View = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd_dicom = new System.Windows.Forms.OpenFileDialog();
            this.sfd_dicom = new System.Windows.Forms.SaveFileDialog();
            this.ms_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_main
            // 
            this.ms_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File,
            this.tsmi_View});
            this.ms_main.Location = new System.Drawing.Point(0, 0);
            this.ms_main.Name = "ms_main";
            this.ms_main.Size = new System.Drawing.Size(1262, 28);
            this.ms_main.TabIndex = 0;
            this.ms_main.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            this.tsmi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_OpenFile,
            this.tsmi_SaveToXML,
            this.tsmi_Exit});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(59, 24);
            this.tsmi_File.Text = "Файл";
            // 
            // tsmi_OpenFile
            // 
            this.tsmi_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_OpenFile.Image")));
            this.tsmi_OpenFile.Name = "tsmi_OpenFile";
            this.tsmi_OpenFile.Size = new System.Drawing.Size(264, 26);
            this.tsmi_OpenFile.Text = "Открыть файл";
            this.tsmi_OpenFile.Click += new System.EventHandler(this.tsmi_OpenFile_Click);
            // 
            // tsmi_SaveToXML
            // 
            this.tsmi_SaveToXML.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_SaveToXML.Image")));
            this.tsmi_SaveToXML.Name = "tsmi_SaveToXML";
            this.tsmi_SaveToXML.Size = new System.Drawing.Size(264, 26);
            this.tsmi_SaveToXML.Text = "Сохранить файл как XML";
            this.tsmi_SaveToXML.Click += new System.EventHandler(this.tsmi_SaveToXML_Click);
            // 
            // tsmi_Exit
            // 
            this.tsmi_Exit.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Exit.Image")));
            this.tsmi_Exit.Name = "tsmi_Exit";
            this.tsmi_Exit.Size = new System.Drawing.Size(264, 26);
            this.tsmi_Exit.Text = "Выход";
            this.tsmi_Exit.Click += new System.EventHandler(this.tsmi_Exit_Click);
            // 
            // tsmi_View
            // 
            this.tsmi_View.Name = "tsmi_View";
            this.tsmi_View.Size = new System.Drawing.Size(49, 24);
            this.tsmi_View.Text = "Вид";
            // 
            // sfd_dicom
            // 
            this.sfd_dicom.FileName = "Newfile";
            this.sfd_dicom.Filter = "XML файл|*.xml|Все файлы |*.*";
            // 
            // Form_dicom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.ms_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms_main;
            this.Name = "Form_dicom";
            this.Text = "DICOM-reader (Листратов 4811)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_dicom_FormClosing);
            this.Load += new System.EventHandler(this.Form_dicom_Load);
            this.ms_main.ResumeLayout(false);
            this.ms_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_File;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveToXML;
        private System.Windows.Forms.ToolStripMenuItem tsmi_View;
        private System.Windows.Forms.OpenFileDialog ofd_dicom;
        private System.Windows.Forms.SaveFileDialog sfd_dicom;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
    }
}

