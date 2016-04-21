using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportingServiceExecutionTask_UI.RS2010;
using Microsoft.SqlServer.Dts.Runtime;

namespace ReportingServiceExecutionTask_UI
{
    public partial class ReportingServiceExecutionTaskSetParameterForm : Form
    {
        #region properties

        ReportingService2010 RS2010;

        public string Server { get; set; }

        TaskHost TaskHostValue { get; set; }


        public string SelectedReport
        {
            get 
            {
                if (cbxReports.SelectedItem == null)
                {
                    return null;
                }
                return ((CatalogItem)cbxReports.SelectedItem).Path;
            }
        }

        public DataTable DtParameters { get; set; }

        #endregion

        #region constructor
        public ReportingServiceExecutionTaskSetParameterForm()
        {
            InitializeComponent();            
        }

        public ReportingServiceExecutionTaskSetParameterForm(string server, TaskHost taskhost)
        {
            InitializeComponent();

            foreach (Control c in groupBox1.Controls)
            {
                c.Enabled = false;
            }

            this.Server = server;
            this.TaskHostValue = taskhost;


        }
        #endregion

        #region event

        private void btnSearch_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Cannot search due to condition(s) missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvParameters.Rows.Clear();
            cbxReports.Items.Clear();
            cbxReports.SelectedItem = null;

            string serverURL = "http://" + Server + "/reportserver/reportservice2010.asmx";

            if (RS2010 == null)
            {
                RS2010 = GetReportingService(serverURL);
            }

            CatalogItem[] items = GetCatalogItems(RS2010, txtSearch.Text);

            if (items != null)
            {
                SetGroupControls(true, groupBox1);

                foreach (CatalogItem item in items)
                {
                    if (item.TypeName == "Report")
                    {
                        cbxReports.Items.Add(item);
                    }
                }

                cbxReports.DisplayMember = "Path";
            }
            
        }

        private void cbxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxReports.SelectedItem == null)
            {
                MessageBox.Show("Please select a report!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RS2010 == null)
            {
                string serverURL = "http://" + Server + "/reportserver/reportservice2010.asmx";
                RS2010 = GetReportingService(serverURL);
            }

            //retrieve report parameters and initialise the datagridview, enable button
            dgvParameters.Rows.Clear();

            if (btnOK.Enabled == false)
            {
                btnOK.Enabled = true;
            }


            ItemParameter[] parameters = RS2010.GetItemParameters(((CatalogItem)cbxReports.SelectedItem).Path, null, false, null, null);

            if (parameters != null && parameters.Count() > 0)
            {
                foreach (ItemParameter parameter in parameters)
                {
                    var index = dgvParameters.Rows.Add();

                    dgvParameters.Rows[index].Cells["ParameterName"].Value = parameter.Name;

                    if (parameter.DefaultValues != null || parameter.DefaultValuesQueryBased == true)
                    {
                        dgvParameters.Rows[index].Cells["Required"].Value = false;
                    }
                    else
                    {
                        dgvParameters.Rows[index].Cells["Required"].Value = true;
                    }


                    DataGridViewComboBoxCell cbxCell = new DataGridViewComboBoxCell();
                    cbxCell = (DataGridViewComboBoxCell)dgvParameters.Rows[index].Cells["ParameterValue"];

                    foreach (Variable var in TaskHostValue.Variables)
                    {
                        if (!var.SystemVariable)
                        {
                            cbxCell.Items.Add(var.QualifiedName);
                        }
                    }
                }

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DtParameters == null)
            {
                DtParameters = new DataTable();
                DtParameters.Columns.Add("ParameterName", typeof(string));
                DtParameters.Columns.Add("Required", typeof(bool));
                DtParameters.Columns.Add("ParameterValue", typeof(string));
            }

            DtParameters.Rows.Clear();
            foreach (DataGridViewRow r in dgvParameters.Rows)
            {
                string pname = r.Cells["ParameterName"].Value == null ? string.Empty : r.Cells["ParameterName"].Value.ToString();
                bool required = bool.Parse(r.Cells["Required"].Value.ToString());
                string pvalue = r.Cells["ParameterValue"].Value == null ? string.Empty : r.Cells["ParameterValue"].Value.ToString();

                DtParameters.Rows.Add(pname, required, pvalue);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

        #region helpers

        //initialise reporting service
        private ReportingService2010 GetReportingService(string url)
        {
            ReportingService2010 RS2010 = new ReportingService2010();
            RS2010.Url = url;
            RS2010.Credentials = System.Net.CredentialCache.DefaultCredentials;

            return RS2010;
        }


        //list reporting service catalog items
        private CatalogItem[] GetCatalogItems(ReportingService2010 rs2010, string value)
        {
            CatalogItem[] items;

            SearchCondition condition = new SearchCondition();
            condition.Condition = ConditionEnum.Contains;
            condition.ConditionSpecified = true;
            condition.Name = "Name";
            condition.Values = new string[] { value };

            try
            {
                items = rs2010.FindItems("/", BooleanOperatorEnum.And, new Property[] { new Property() { Name = "Recursive", Value = "True" } }, new SearchCondition[] { condition });
                return items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        //set interface
        private void SetGroupControls(bool enable, GroupBox g)
        {
            foreach (Control c in g.Controls)
            {
                c.Enabled = enable;
            }
        }

        #endregion
        
        
    }
}
