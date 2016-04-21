using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using ReportingServiceExecutionTask.RSExec;
using System.Data;
using System.Xml;
using System.Security;
using System.IO;

namespace ReportingServiceExecutionTask
{

    //public key: 62b943b3dd164c27

    [DtsTask
        (
        DisplayName = "Reporting Service Execution Task",
        Description = "Generate Report from SQL Server Reporting Service",
        UITypeName = "ReportingServiceExecutionTask_UI.ReportingServiceExecutionTask_UI,ReportingServiceExecutionTask_UI,Version=1.0.0.0,Culture=Neutral,PublicKeyToken=62b943b3dd164c27",
        IconResource = "ReportingServiceExecutionTask.Task.ico"
        )
    ]
    public class ReportingServiceExecutionTask:Microsoft.SqlServer.Dts.Runtime.Task,IDTSComponentPersist
    {
        #region properties

        private string _server;
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        private string _selectedreport;
        public string SelectedReport
        {
            get { return _selectedreport; }
            set { _selectedreport = value; }
        }

        private DataTable _dtparameters;
        public DataTable DtParameters
        {
            get { return _dtparameters; }
            set { _dtparameters = value; }
        }

        private string _fileformat;
        public string FileFormat
        {
            get { return _fileformat; }
            set { _fileformat = value; }
        }

        private string _filename;
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        }
        #endregion

        #region task
        public override void InitializeTask(Connections connections, VariableDispenser variableDispenser, IDTSInfoEvents events, IDTSLogging log, EventInfos eventInfos, LogEntryInfos logEntryInfos, ObjectReferenceTracker refTracker)
        {
            base.InitializeTask(connections, variableDispenser, events, log, eventInfos, logEntryInfos, refTracker);
        }

        public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log)
        {
            DTSExecResult Result = base.Validate(connections, variableDispenser, componentEvents, log);

            if (Result == DTSExecResult.Success)
            {
                if (string.IsNullOrEmpty(Server))
                {
                    componentEvents.FireError(0, "Reporting Service Execution Task", "Missing configuration value - Report Server", "", 0);
                    return DTSExecResult.Failure;
                }

                if (string.IsNullOrEmpty(SelectedReport))
                {
                    componentEvents.FireError(0, "Reporting Service Execution Task", "Missing configuration value - Selected Report", "", 0);
                    return DTSExecResult.Failure;
                }

                if (string.IsNullOrEmpty(FileFormat))
                {
                    componentEvents.FireError(0, "Reporting Service Execution Task", "Missing configuration value - Output File Format", "", 0);
                    return DTSExecResult.Failure;
                }

                if (string.IsNullOrEmpty(FileName))
                {
                    componentEvents.FireError(0, "Reporting Service Execution Task", "Missing configuration value - Output File Name", "", 0);
                    return DTSExecResult.Failure;
                }
            }
          
            return DTSExecResult.Success;
        }

        public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log, object transaction)
        {
            //initialize report execution service
            string RSExecURL = @"http://" + Server + "/ReportServer/ReportExecution2005.asmx";
            ReportExecutionService RSExec2005 = new ReportExecutionService();
            RSExec2005.Credentials = System.Net.CredentialCache.DefaultCredentials;
            RSExec2005.Url = RSExecURL;

            //prepare variables
            byte[] Results = null;
            Warning[] warnings = null;
            string encoding;
            string mimetype;
            string[] streamids = null;
            string extension;

            try
            {
                ExecutionInfo Info = new ExecutionInfo();
                Info = RSExec2005.LoadReport(SelectedReport, null);

                
                if (DtParameters != null)
                {
                    if (DtParameters.Rows.Count > 0)
                    {
                        List<Tuple<string, string>> lstParameters = new List<Tuple<string, string>>();
                        foreach (DataRow row in DtParameters.Rows)
                        {
                            if (row["ParameterValue"] != null)
                            {
                                if (!string.IsNullOrEmpty(row["ParameterValue"].ToString()))
                                {
                                    //the parameter value has to be a variable
                                    string pName = row["ParameterName"].ToString();

                                    Variables varPValue = null;
                                    variableDispenser.LockOneForRead(row["ParameterValue"].ToString(), ref varPValue);
                                    string pValue = varPValue[0].Value.ToString();

                                    lstParameters.Add(Tuple.Create(pName, pValue));
                                }
                            }
                        }

                        ParameterValue[] Parameters;
                        if (lstParameters.Count > 0)
                        {
                            Parameters = new ParameterValue[lstParameters.Count];

                            for (int i = 0; i < lstParameters.Count; i++)
                            {
                                Parameters[i] = new ParameterValue();
                                Parameters[i].Name = lstParameters[i].Item1;
                                Parameters[i].Value = lstParameters[i].Item2;
                            }

                            RSExec2005.SetExecutionParameters(Parameters, "en-us");
                        }
                    }
                }

                //output format and name
                Variables varFileFormat = null;
                variableDispenser.LockOneForRead(FileFormat, ref varFileFormat);

                Variables varFileName = null;
                variableDispenser.LockOneForRead(FileName, ref varFileName);

                Results = RSExec2005.Render(varFileFormat[0].Value.ToString(), null, out extension, out mimetype, out encoding, out warnings, out streamids);
                Info = RSExec2005.GetExecutionInfo();

                FileStream FS = File.Create(varFileName[0].Value.ToString(), Results.Length);
                FS.Write(Results, 0, Results.Length);
                FS.Close();

                return DTSExecResult.Success;

            }
            catch (Exception ex)
            {
                componentEvents.FireError(0, "Reporting Service Task", "Task Error: " + ex.ToString(), "", -1);
                return DTSExecResult.Failure;
            }

        }
        #endregion
        
        #region IDTSComponentPersist

        //load from package
        public void LoadFromXML(System.Xml.XmlElement node, IDTSInfoEvents infoEvents)
        {
            _dtparameters = new DataTable();
            _dtparameters.Columns.Add("ParameterName", typeof(string));
            _dtparameters.Columns.Add("Required", typeof(bool));
            _dtparameters.Columns.Add("ParameterValue", typeof(string));

            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.Name == "Server")
                {
                    _server = n.InnerText;
                }

                if (n.Name == "SelectedReport")
                {
                    _selectedreport = n.InnerText;
                }

                if (n.Name == "FileName")
                {
                    _filename = n.InnerText;
                }

                if (n.Name == "FileFormat")
                {
                    _fileformat = n.InnerText;
                }

                if (n.Name == "Parameter")
                {
                    string parametername = n.Attributes.GetNamedItem("ParameterName").Value;
                    bool required = Convert.ToBoolean(n.Attributes.GetNamedItem("Required").Value);
                    string parametervalue = n.InnerText;                    
                    
                    _dtparameters.Rows.Add(parametername, required, parametervalue);
                    
                }
            }
        }

        //save into package
        public void SaveToXML(System.Xml.XmlDocument doc, IDTSInfoEvents infoEvents)
        {
            XmlElement elementRoot;
            XmlNode propertyNode;

            elementRoot = doc.CreateElement(string.Empty, "DtParameters", string.Empty);

            if (DtParameters != null)
            {
                if (DtParameters.Rows.Count > 0)
                {
                    //
                    foreach (DataRow row in DtParameters.Rows)
                    {
                        propertyNode = doc.CreateNode(XmlNodeType.Element, "Parameter", string.Empty);
                        propertyNode.InnerText = row["ParameterValue"].ToString();

                        XmlAttribute attrParameterName = doc.CreateAttribute("ParameterName");
                        attrParameterName.Value = row["ParameterName"].ToString();
                        propertyNode.Attributes.Append(attrParameterName);

                        XmlAttribute attrRequired = doc.CreateAttribute("Required");
                        attrRequired.Value = row["Required"].ToString();
                        propertyNode.Attributes.Append(attrRequired);

                        elementRoot.AppendChild(propertyNode);
                    }
                }
            }           
                        

            propertyNode = doc.CreateNode(XmlNodeType.Element, "Server", string.Empty);
            propertyNode.InnerText = Server;
            elementRoot.AppendChild(propertyNode);

            propertyNode = doc.CreateNode(XmlNodeType.Element, "SelectedReport", string.Empty);
            propertyNode.InnerText = SelectedReport;
            elementRoot.AppendChild(propertyNode);

            propertyNode = doc.CreateNode(XmlNodeType.Element, "FileName", string.Empty);
            propertyNode.InnerText = FileName;
            elementRoot.AppendChild(propertyNode);

            propertyNode = doc.CreateNode(XmlNodeType.Element, "FileFormat", string.Empty);
            propertyNode.InnerText = FileFormat;
            elementRoot.AppendChild(propertyNode);

            doc.AppendChild(elementRoot);
        }

        #endregion
    }
}
