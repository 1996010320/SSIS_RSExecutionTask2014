using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using ReportingServiceExecutionTask_UI.RS2010;
using System.Reflection;
using System.Collections;
using System.Xml;

namespace ReportingServiceExecutionTask_UI
{
    public partial class ReportingServiceExecutionTaskForm : Form
    {

        #region properties

        public TaskHost TaskHostValue { get; set; }

        //txtserver
        public string Server
        {
            get
            {
                if (TaskHostValue.Properties["Server"].GetValue(TaskHostValue) != null)
                {
                    return TaskHostValue.Properties["Server"].GetValue(TaskHostValue).ToString();
                }
                return null;
            }
            set
            {
                TaskHostValue.Properties["Server"].SetValue(TaskHostValue, value);
            }

        }

        //cbxreportname - selected report
        public string SelectedReport
        {
            get
            {
                if (TaskHostValue.Properties["SelectedReport"].GetValue(TaskHostValue) != null)
                {
                    return TaskHostValue.Properties["SelectedReport"].GetValue(TaskHostValue).ToString();
                }
                return null;
            }
            set
            {
                TaskHostValue.Properties["SelectedReport"].SetValue(TaskHostValue, value);
            }
        }

        //cbxFileFormat
        public string FileFormat
        {
            get
            {
                if (TaskHostValue.Properties["FileFormat"].GetValue(TaskHostValue) != null)
                {
                    return TaskHostValue.Properties["FileFormat"].GetValue(TaskHostValue).ToString();
                }
                return null;
            }
            set
            {
                TaskHostValue.Properties["FileFormat"].SetValue(TaskHostValue, value);
            }
        }

        //cbxFileName
        public string FileName
        {
            get
            {
                if (TaskHostValue.Properties["FileName"].GetValue(TaskHostValue)!=null)
                {
                    return TaskHostValue.Properties["FileName"].GetValue(TaskHostValue).ToString();
                }
                return null;
            }
            set
            {
                TaskHostValue.Properties["FileName"].SetValue(TaskHostValue, value);
            }
        }

        public DataTable DtParameters
        {
            get
            {
                if (TaskHostValue.Properties["DtParameters"].GetValue(TaskHostValue) != null)
                {
                    return TaskHostValue.Properties["DtParameters"].GetValue(TaskHostValue) as DataTable;
                }
                return null;
            }
            set
            {
                TaskHostValue.Properties["DtParameters"].SetValue(TaskHostValue, value);
            }
        }

        #endregion

        #region constructor
        public ReportingServiceExecutionTaskForm()
        {
            InitializeComponent();
        }

        public ReportingServiceExecutionTaskForm(TaskHost taskHost)
        {
            this.TaskHostValue = taskHost;
            InitializeComponent();
        }
        #endregion

        #region event

        private void btnOK_Click(object sender, EventArgs e)
        {
            Server = string.IsNullOrEmpty(txtServer.Text) ? string.Empty : txtServer.Text;
            SelectedReport = string.IsNullOrEmpty(txtReportName.Text) ? string.Empty : txtReportName.Text;

            FileFormat = string.IsNullOrEmpty(cbxFileFormat.Text) ? string.Empty : cbxFileFormat.Text.Trim();
            FileName = string.IsNullOrEmpty(cbxFileName.Text) ? string.Empty : cbxFileName.Text.Trim();

            DtParameters = new DataTable();
            DtParameters.Columns.Add("ParameterName", typeof(string));
            DtParameters.Columns.Add("Required", typeof(bool));
            DtParameters.Columns.Add("ParameterValue", typeof(string));

            foreach (DataGridViewRow row in dgvParameters.Rows)
            {
                DtParameters.Rows.Add(row.Cells["ParameterName"].Value.ToString(), Convert.ToBoolean(row.Cells["Required"].Value.ToString()), row.Cells["ParameterValue"].Value.ToString());                
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void ReportingServiceExecutionTaskForm_Load(object sender, EventArgs e)
        {
               
            txtServer.Text = string.IsNullOrEmpty(Server) ? string.Empty : Server;
            txtReportName.Text = string.IsNullOrEmpty(SelectedReport) ? string.Empty : SelectedReport;
                        
            if (SelectedReport != null)
            {
                SetGroupControls(true, groupBox2);
            }
            else
            {
                SetGroupControls(false, groupBox2);
            }

            if (DtParameters != null)
            {
                if (DtParameters.Rows.Count > 0)
                {
                    foreach (DataRow row in DtParameters.Rows)
                    {
                        int idx = dgvParameters.Rows.Add();
                        dgvParameters.Rows[idx].Cells["ParameterName"].Value = row["ParameterName"].ToString();
                        dgvParameters.Rows[idx].Cells["Required"].Value = Convert.ToBoolean(row["Required"].ToString());
                        dgvParameters.Rows[idx].Cells["ParameterValue"].Value = row["ParameterValue"].ToString();
                    }
                }
            }


            PopulateCombobox(cbxFileFormat);
            PopulateCombobox(cbxFileName);

            cbxFileFormat.SelectedItem = string.IsNullOrEmpty(FileFormat) ? string.Empty : FileFormat;
            cbxFileName.SelectedItem = string.IsNullOrEmpty(FileName) ? string.Empty : FileName;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                MessageBox.Show("Server needs to have value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReportingServiceExecutionTaskSetParameterForm ParameterForm = new ReportingServiceExecutionTaskSetParameterForm(txtServer.Text, TaskHostValue);

            if (ParameterForm.ShowDialog() == DialogResult.OK)
            {
                txtReportName.Text = ParameterForm.SelectedReport;

                DataTable dtTemp = new DataTable();

                dtTemp = ParameterForm.DtParameters;

                dgvParameters.Rows.Clear();

                foreach (DataRow row in dtTemp.Rows)
                {
                    int idx = dgvParameters.Rows.Add();
                    dgvParameters.Rows[idx].Cells["ParameterName"].Value = row["ParameterName"].ToString();
                    dgvParameters.Rows[idx].Cells["Required"].Value = Convert.ToBoolean(row["Required"].ToString());
                    dgvParameters.Rows[idx].Cells["ParameterValue"].Value = row["ParameterValue"].ToString();
                }

                SetGroupControls(true, groupBox2);
            }
                      
            
            
        }
        
        #endregion

        #region helper

        //set interface
        private void SetGroupControls(bool enable, GroupBox g)
        {
            foreach (Control c in g.Controls)
            {
                c.Enabled = enable;
            }
        }

        //populate variables for combobox
        private void PopulateCombobox(ComboBox cbx)
        {
            foreach (Variable var in TaskHostValue.Variables)
            {
                if (!var.SystemVariable)
                {
                    cbx.Items.Add(var.QualifiedName);
                }
            }
        }

        #endregion
    }
}
