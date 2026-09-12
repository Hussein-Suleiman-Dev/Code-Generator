namespace Code_Genrator
{
    partial class frmCodeGenrator
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
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGenrate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDAL = new System.Windows.Forms.CheckBox();
            this.chkDTO = new System.Windows.Forms.CheckBox();
            this.chkBLL = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCutomFunction = new System.Windows.Forms.RadioButton();
            this.rbAllClasses = new System.Windows.Forms.RadioButton();
            this.gbCustomFunctionDal = new System.Windows.Forms.GroupBox();
            this.chkGetAllDAL = new System.Windows.Forms.CheckBox();
            this.chkFindDAL = new System.Windows.Forms.CheckBox();
            this.chkUpdateDAL = new System.Windows.Forms.CheckBox();
            this.chkDeleteDAL = new System.Windows.Forms.CheckBox();
            this.chkAddDAL = new System.Windows.Forms.CheckBox();
            this.gbCustomFunction = new System.Windows.Forms.GroupBox();
            this.chkGetAll = new System.Windows.Forms.CheckBox();
            this.chkFind = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkl = new System.Windows.Forms.CheckedListBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbCustomFunctionDal.SuspendLayout();
            this.gbCustomFunction.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(12, 726);
            this.txtOutputPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputPath.Multiline = true;
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(900, 26);
            this.txtOutputPath.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(946, 723);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Browse";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGenrate
            // 
            this.btnGenrate.Enabled = false;
            this.btnGenrate.Location = new System.Drawing.Point(547, 770);
            this.btnGenrate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenrate.Name = "btnGenrate";
            this.btnGenrate.Size = new System.Drawing.Size(388, 39);
            this.btnGenrate.TabIndex = 7;
            this.btnGenrate.Text = "Genrate";
            this.btnGenrate.UseVisualStyleBackColor = true;
            this.btnGenrate.Click += new System.EventHandler(this.btnGenrate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(364, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Server";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDatabaseName.Location = new System.Drawing.Point(45, 56);
            this.lblDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(51, 28);
            this.lblDatabaseName.TabIndex = 15;
            this.lblDatabaseName.Text = "[???]";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblServerName.Location = new System.Drawing.Point(365, 56);
            this.lblServerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(51, 28);
            this.lblServerName.TabIndex = 17;
            this.lblServerName.Text = "[???]";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.gbCustomFunctionDal);
            this.groupBox3.Controls.Add(this.gbCustomFunction);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(547, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(952, 617);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "genration Option";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDAL);
            this.groupBox2.Controls.Add(this.chkDTO);
            this.groupBox2.Controls.Add(this.chkBLL);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(33, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 78);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Layers";
            // 
            // chkDAL
            // 
            this.chkDAL.AutoSize = true;
            this.chkDAL.Checked = true;
            this.chkDAL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDAL.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDAL.Location = new System.Drawing.Point(258, 36);
            this.chkDAL.Margin = new System.Windows.Forms.Padding(4);
            this.chkDAL.Name = "chkDAL";
            this.chkDAL.Size = new System.Drawing.Size(59, 26);
            this.chkDAL.TabIndex = 9;
            this.chkDAL.Text = "DAL";
            this.chkDAL.UseVisualStyleBackColor = true;
            this.chkDAL.CheckedChanged += new System.EventHandler(this.chkDAL_CheckedChanged);
            // 
            // chkDTO
            // 
            this.chkDTO.AutoSize = true;
            this.chkDTO.Checked = true;
            this.chkDTO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDTO.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDTO.Location = new System.Drawing.Point(19, 36);
            this.chkDTO.Margin = new System.Windows.Forms.Padding(4);
            this.chkDTO.Name = "chkDTO";
            this.chkDTO.Size = new System.Drawing.Size(62, 26);
            this.chkDTO.TabIndex = 8;
            this.chkDTO.Text = "DTO";
            this.chkDTO.UseVisualStyleBackColor = true;
            this.chkDTO.CheckedChanged += new System.EventHandler(this.chkDTO_CheckedChanged);
            // 
            // chkBLL
            // 
            this.chkBLL.AutoSize = true;
            this.chkBLL.Checked = true;
            this.chkBLL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBLL.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBLL.Location = new System.Drawing.Point(460, 36);
            this.chkBLL.Margin = new System.Windows.Forms.Padding(4);
            this.chkBLL.Name = "chkBLL";
            this.chkBLL.Size = new System.Drawing.Size(57, 26);
            this.chkBLL.TabIndex = 7;
            this.chkBLL.Text = "BLL";
            this.chkBLL.UseVisualStyleBackColor = true;
            this.chkBLL.CheckedChanged += new System.EventHandler(this.chkBLL_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCutomFunction);
            this.groupBox1.Controls.Add(this.rbAllClasses);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(33, 164);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(505, 140);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genration Mode";
            // 
            // rbCutomFunction
            // 
            this.rbCutomFunction.AutoSize = true;
            this.rbCutomFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCutomFunction.Location = new System.Drawing.Point(8, 93);
            this.rbCutomFunction.Margin = new System.Windows.Forms.Padding(4);
            this.rbCutomFunction.Name = "rbCutomFunction";
            this.rbCutomFunction.Size = new System.Drawing.Size(162, 24);
            this.rbCutomFunction.TabIndex = 20;
            this.rbCutomFunction.Text = "Custom Function ";
            this.rbCutomFunction.UseVisualStyleBackColor = true;
            this.rbCutomFunction.CheckedChanged += new System.EventHandler(this.rbCutomFunction_CheckedChanged_1);
            // 
            // rbAllClasses
            // 
            this.rbAllClasses.AutoSize = true;
            this.rbAllClasses.Checked = true;
            this.rbAllClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAllClasses.Location = new System.Drawing.Point(8, 40);
            this.rbAllClasses.Margin = new System.Windows.Forms.Padding(4);
            this.rbAllClasses.Name = "rbAllClasses";
            this.rbAllClasses.Size = new System.Drawing.Size(115, 24);
            this.rbAllClasses.TabIndex = 19;
            this.rbAllClasses.TabStop = true;
            this.rbAllClasses.Text = "All Classes";
            this.rbAllClasses.UseVisualStyleBackColor = true;
            // 
            // gbCustomFunctionDal
            // 
            this.gbCustomFunctionDal.Controls.Add(this.chkGetAllDAL);
            this.gbCustomFunctionDal.Controls.Add(this.chkFindDAL);
            this.gbCustomFunctionDal.Controls.Add(this.chkUpdateDAL);
            this.gbCustomFunctionDal.Controls.Add(this.chkDeleteDAL);
            this.gbCustomFunctionDal.Controls.Add(this.chkAddDAL);
            this.gbCustomFunctionDal.Location = new System.Drawing.Point(33, 347);
            this.gbCustomFunctionDal.Margin = new System.Windows.Forms.Padding(4);
            this.gbCustomFunctionDal.Name = "gbCustomFunctionDal";
            this.gbCustomFunctionDal.Padding = new System.Windows.Forms.Padding(4);
            this.gbCustomFunctionDal.Size = new System.Drawing.Size(410, 246);
            this.gbCustomFunctionDal.TabIndex = 21;
            this.gbCustomFunctionDal.TabStop = false;
            this.gbCustomFunctionDal.Text = "Custom Function DAL";
            this.gbCustomFunctionDal.Visible = false;
            // 
            // chkGetAllDAL
            // 
            this.chkGetAllDAL.AutoSize = true;
            this.chkGetAllDAL.Location = new System.Drawing.Point(150, 109);
            this.chkGetAllDAL.Margin = new System.Windows.Forms.Padding(4);
            this.chkGetAllDAL.Name = "chkGetAllDAL";
            this.chkGetAllDAL.Size = new System.Drawing.Size(82, 24);
            this.chkGetAllDAL.TabIndex = 4;
            this.chkGetAllDAL.Text = "Get All";
            this.chkGetAllDAL.UseVisualStyleBackColor = true;
            // 
            // chkFindDAL
            // 
            this.chkFindDAL.AutoSize = true;
            this.chkFindDAL.Location = new System.Drawing.Point(150, 59);
            this.chkFindDAL.Margin = new System.Windows.Forms.Padding(4);
            this.chkFindDAL.Name = "chkFindDAL";
            this.chkFindDAL.Size = new System.Drawing.Size(68, 24);
            this.chkFindDAL.TabIndex = 3;
            this.chkFindDAL.Text = "Find ";
            this.chkFindDAL.UseVisualStyleBackColor = true;
            // 
            // chkUpdateDAL
            // 
            this.chkUpdateDAL.AutoSize = true;
            this.chkUpdateDAL.Location = new System.Drawing.Point(19, 169);
            this.chkUpdateDAL.Margin = new System.Windows.Forms.Padding(4);
            this.chkUpdateDAL.Name = "chkUpdateDAL";
            this.chkUpdateDAL.Size = new System.Drawing.Size(84, 24);
            this.chkUpdateDAL.TabIndex = 2;
            this.chkUpdateDAL.Text = "Update";
            this.chkUpdateDAL.UseVisualStyleBackColor = true;
            // 
            // chkDeleteDAL
            // 
            this.chkDeleteDAL.AutoSize = true;
            this.chkDeleteDAL.Location = new System.Drawing.Point(19, 109);
            this.chkDeleteDAL.Margin = new System.Windows.Forms.Padding(4);
            this.chkDeleteDAL.Name = "chkDeleteDAL";
            this.chkDeleteDAL.Size = new System.Drawing.Size(80, 24);
            this.chkDeleteDAL.TabIndex = 1;
            this.chkDeleteDAL.Text = "Delete";
            this.chkDeleteDAL.UseVisualStyleBackColor = true;
            // 
            // chkAddDAL
            // 
            this.chkAddDAL.AutoSize = true;
            this.chkAddDAL.Location = new System.Drawing.Point(19, 59);
            this.chkAddDAL.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddDAL.Name = "chkAddDAL";
            this.chkAddDAL.Size = new System.Drawing.Size(60, 24);
            this.chkAddDAL.TabIndex = 0;
            this.chkAddDAL.Text = "Add";
            this.chkAddDAL.UseVisualStyleBackColor = true;
            // 
            // gbCustomFunction
            // 
            this.gbCustomFunction.Controls.Add(this.chkGetAll);
            this.gbCustomFunction.Controls.Add(this.chkFind);
            this.gbCustomFunction.Controls.Add(this.chkUpdate);
            this.gbCustomFunction.Controls.Add(this.chkDelete);
            this.gbCustomFunction.Controls.Add(this.chkAdd);
            this.gbCustomFunction.Location = new System.Drawing.Point(509, 347);
            this.gbCustomFunction.Margin = new System.Windows.Forms.Padding(4);
            this.gbCustomFunction.Name = "gbCustomFunction";
            this.gbCustomFunction.Padding = new System.Windows.Forms.Padding(4);
            this.gbCustomFunction.Size = new System.Drawing.Size(410, 246);
            this.gbCustomFunction.TabIndex = 20;
            this.gbCustomFunction.TabStop = false;
            this.gbCustomFunction.Text = "Custom Function BLL";
            this.gbCustomFunction.Visible = false;
            // 
            // chkGetAll
            // 
            this.chkGetAll.AutoSize = true;
            this.chkGetAll.Location = new System.Drawing.Point(165, 92);
            this.chkGetAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkGetAll.Name = "chkGetAll";
            this.chkGetAll.Size = new System.Drawing.Size(82, 24);
            this.chkGetAll.TabIndex = 4;
            this.chkGetAll.Text = "Get All";
            this.chkGetAll.UseVisualStyleBackColor = true;
            // 
            // chkFind
            // 
            this.chkFind.AutoSize = true;
            this.chkFind.Location = new System.Drawing.Point(165, 42);
            this.chkFind.Margin = new System.Windows.Forms.Padding(4);
            this.chkFind.Name = "chkFind";
            this.chkFind.Size = new System.Drawing.Size(68, 24);
            this.chkFind.TabIndex = 3;
            this.chkFind.Text = "Find ";
            this.chkFind.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(19, 152);
            this.chkUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(84, 24);
            this.chkUpdate.TabIndex = 2;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(19, 92);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(4);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(80, 24);
            this.chkDelete.TabIndex = 1;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(19, 42);
            this.chkAdd.Margin = new System.Windows.Forms.Padding(4);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(60, 24);
            this.chkAdd.TabIndex = 0;
            this.chkAdd.Text = "Add";
            this.chkAdd.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkSelectAll);
            this.groupBox4.Controls.Add(this.chkl);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox4.Location = new System.Drawing.Point(12, 102);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(512, 617);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tables";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(7, 34);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(107, 26);
            this.chkSelectAll.TabIndex = 3;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // chkl
            // 
            this.chkl.BackColor = System.Drawing.Color.White;
            this.chkl.Font = new System.Drawing.Font("Segoe UI Historic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkl.FormattingEnabled = true;
            this.chkl.Location = new System.Drawing.Point(5, 66);
            this.chkl.Margin = new System.Windows.Forms.Padding(4);
            this.chkl.Name = "chkl";
            this.chkl.Size = new System.Drawing.Size(500, 554);
            this.chkl.TabIndex = 2;
            // 
            // frmCodeGenrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 810);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenrate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtOutputPath);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCodeGenrator";
            this.Text = "frmCodeGenrator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCodeGenrator_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbCustomFunctionDal.ResumeLayout(false);
            this.gbCustomFunctionDal.PerformLayout();
            this.gbCustomFunction.ResumeLayout(false);
            this.gbCustomFunction.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnGenrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDAL;
        private System.Windows.Forms.CheckBox chkDTO;
        private System.Windows.Forms.CheckBox chkBLL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCutomFunction;
        private System.Windows.Forms.RadioButton rbAllClasses;
        private System.Windows.Forms.GroupBox gbCustomFunctionDal;
        private System.Windows.Forms.CheckBox chkGetAllDAL;
        private System.Windows.Forms.CheckBox chkFindDAL;
        private System.Windows.Forms.CheckBox chkUpdateDAL;
        private System.Windows.Forms.CheckBox chkDeleteDAL;
        private System.Windows.Forms.CheckBox chkAddDAL;
        private System.Windows.Forms.GroupBox gbCustomFunction;
        private System.Windows.Forms.CheckBox chkGetAll;
        private System.Windows.Forms.CheckBox chkFind;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckedListBox chkl;
    }
}