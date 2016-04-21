namespace ReportingServiceExecutionTask_UI
{
    partial class ReportingServiceExecutionTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportingServiceExecutionTaskForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxFileName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxFileFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Required = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(243, 512);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(348, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReportName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvParameters);
            this.groupBox1.Location = new System.Drawing.Point(13, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 271);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterName,
            this.Required,
            this.ParameterValue});
            this.dgvParameters.Enabled = false;
            this.dgvParameters.Location = new System.Drawing.Point(22, 59);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowHeadersVisible = false;
            this.dgvParameters.Size = new System.Drawing.Size(376, 190);
            this.dgvParameters.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxFileName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxFileFormat);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 131);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // cbxFileName
            // 
            this.cbxFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileName.FormattingEnabled = true;
            this.cbxFileName.Location = new System.Drawing.Point(100, 88);
            this.cbxFileName.Name = "cbxFileName";
            this.cbxFileName.Size = new System.Drawing.Size(297, 21);
            this.cbxFileName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "File Name: ";
            // 
            // cbxFileFormat
            // 
            this.cbxFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileFormat.FormattingEnabled = true;
            this.cbxFileFormat.Location = new System.Drawing.Point(100, 39);
            this.cbxFileFormat.Name = "cbxFileFormat";
            this.cbxFileFormat.Size = new System.Drawing.Size(297, 21);
            this.cbxFileFormat.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "File Format: ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(348, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(92, 27);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(226, 20);
            this.txtServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Report Server:";
            // 
            // txtReportName
            // 
            this.txtReportName.Enabled = false;
            this.txtReportName.Location = new System.Drawing.Point(101, 26);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(297, 20);
            this.txtReportName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Report:";
            // 
            // ParameterName
            // 
            this.ParameterName.HeaderText = "Parameter Name";
            this.ParameterName.Name = "ParameterName";
            this.ParameterName.ReadOnly = true;
            // 
            // Required
            // 
            this.Required.HeaderText = "Required";
            this.Required.Name = "Required";
            this.Required.ReadOnly = true;
            // 
            // ParameterValue
            // 
            this.ParameterValue.HeaderText = "Parameter Value";
            this.ParameterValue.Name = "ParameterValue";
            this.ParameterValue.ReadOnly = true;
            this.ParameterValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParameterValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ReportingServiceExecutionTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 546);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportingServiceExecutionTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Execution Task Setting";
            this.Load += new System.EventHandler(this.ReportingServiceExecutionTaskForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxFileFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Required;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterValue;
    }
}