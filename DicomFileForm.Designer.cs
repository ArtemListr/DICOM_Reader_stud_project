
namespace Dicom_project_listr
{
    partial class DicomFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicomFileForm));
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc_dicomfile = new System.Windows.Forms.TabControl();
            this.tp_picture = new System.Windows.Forms.TabPage();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.pn_pb = new System.Windows.Forms.Panel();
            this.tp_Table = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.tc_dicomfile.SuspendLayout();
            this.tp_picture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.tp_Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGV
            // 
            this.dataGV.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupID,
            this.ElementID,
            this.VR,
            this.Description,
            this.Size,
            this.Value});
            this.dataGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV.Location = new System.Drawing.Point(3, 3);
            this.dataGV.Name = "dataGV";
            this.dataGV.RowHeadersWidth = 51;
            this.dataGV.RowTemplate.Height = 29;
            this.dataGV.Size = new System.Drawing.Size(786, 411);
            this.dataGV.TabIndex = 0;
            // 
            // GroupID
            // 
            this.GroupID.HeaderText = "Group";
            this.GroupID.MinimumWidth = 6;
            this.GroupID.Name = "GroupID";
            this.GroupID.Width = 122;
            // 
            // ElementID
            // 
            this.ElementID.HeaderText = "Element";
            this.ElementID.MinimumWidth = 6;
            this.ElementID.Name = "ElementID";
            this.ElementID.Width = 122;
            // 
            // VR
            // 
            this.VR.HeaderText = "VR";
            this.VR.MinimumWidth = 6;
            this.VR.Name = "VR";
            this.VR.Width = 122;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.Width = 123;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            // 
            // tc_dicomfile
            // 
            this.tc_dicomfile.Controls.Add(this.tp_picture);
            this.tc_dicomfile.Controls.Add(this.tp_Table);
            this.tc_dicomfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_dicomfile.Location = new System.Drawing.Point(0, 0);
            this.tc_dicomfile.Name = "tc_dicomfile";
            this.tc_dicomfile.SelectedIndex = 0;
            this.tc_dicomfile.Size = new System.Drawing.Size(800, 450);
            this.tc_dicomfile.TabIndex = 1;
            // 
            // tp_picture
            // 
            this.tp_picture.AutoScroll = true;
            this.tp_picture.Controls.Add(this.picbox);
            this.tp_picture.Controls.Add(this.pn_pb);
            this.tp_picture.Location = new System.Drawing.Point(4, 29);
            this.tp_picture.Name = "tp_picture";
            this.tp_picture.Padding = new System.Windows.Forms.Padding(3);
            this.tp_picture.Size = new System.Drawing.Size(792, 417);
            this.tp_picture.TabIndex = 1;
            this.tp_picture.Text = "Изображение";
            this.tp_picture.UseVisualStyleBackColor = true;
            // 
            // picbox
            // 
            this.picbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbox.Location = new System.Drawing.Point(3, 3);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(786, 411);
            this.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox.TabIndex = 0;
            this.picbox.TabStop = false;
            // 
            // pn_pb
            // 
            this.pn_pb.AutoScroll = true;
            this.pn_pb.AutoSize = true;
            this.pn_pb.BackColor = System.Drawing.Color.Silver;
            this.pn_pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_pb.Location = new System.Drawing.Point(3, 3);
            this.pn_pb.Name = "pn_pb";
            this.pn_pb.Size = new System.Drawing.Size(786, 411);
            this.pn_pb.TabIndex = 1;
            // 
            // tp_Table
            // 
            this.tp_Table.Controls.Add(this.dataGV);
            this.tp_Table.Location = new System.Drawing.Point(4, 29);
            this.tp_Table.Name = "tp_Table";
            this.tp_Table.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Table.Size = new System.Drawing.Size(792, 417);
            this.tp_Table.TabIndex = 0;
            this.tp_Table.Text = "Таблица";
            this.tp_Table.UseVisualStyleBackColor = true;
            // 
            // DicomFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tc_dicomfile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DicomFileForm";
            this.Text = "File";
            this.Load += new System.EventHandler(this.DicomFileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.tc_dicomfile.ResumeLayout(false);
            this.tp_picture.ResumeLayout(false);
            this.tp_picture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.tp_Table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.TabControl tc_dicomfile;
        private System.Windows.Forms.TabPage tp_picture;
        private System.Windows.Forms.TabPage tp_Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.Panel pn_pb;
    }
}