namespace ReportingServiceExecutionTask_UI
{
    partial class ReportingServiceExecutionTaskSetParameterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportingServiceExecutionTaskSetParameterForm));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Required = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ParameterValue = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxReports = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(16, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(329, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(364, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvParameters);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxReports);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 331);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterName,
            this.Required,
            this.ParameterValue});
            this.dgvParameters.Location = new System.Drawing.Point(24, 65);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowHeadersVisible = false;
            this.dgvParameters.Size = new System.Drawing.Size(388, 260);
            this.dgvParameters.TabIndex = 2;
            // 
            // ParameterName
            // 
            this.ParameterName.HeaderText = "Name";
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
            this.ParameterValue.HeaderText = "Value";
            this.ParameterValue.Name = "ParameterValue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report Name";
            // 
            // cbxReports
            // 
            this.cbxReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReports.FormattingEnabled = true;
            this.cbxReports.Location = new System.Drawing.Point(97, 33);
            this.cbxReports.Name = "cbxReports";
            this.cbxReports.Size = new System.Drawing.Size(315, 21);
            this.cbxReports.TabIndex = 2;
            this.cbxReports.SelectedIndexChanged += new System.EventHandler(this.cbxReports_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(270, 397);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(364, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReportingServiceExecutionTaskSetParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 432);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportingServiceExecutionTaskSetParameterForm";
            this.Text = "Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxReports;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Required;
        private System.Windows.Forms.DataGridViewComboBoxColumn ParameterValue;

    }
}