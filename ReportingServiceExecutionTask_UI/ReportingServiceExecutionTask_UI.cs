using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;

namespace ReportingServiceExecutionTask_UI
{
    public class ReportingServiceExecutionTask_UI:IDtsTaskUI
    {
        public TaskHost TaskHostValue { get; set; }

        public ReportingServiceExecutionTask_UI() { }

        public ContainerControl GetView()
        {
            ReportingServiceExecutionTaskForm theForm = new ReportingServiceExecutionTaskForm(this.TaskHostValue);
            return theForm;
        }

        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            this.TaskHostValue = taskHost;
        }

        public void New(System.Windows.Forms.IWin32Window parentWindow)
        {
        }


        public void Delete(System.Windows.Forms.IWin32Window parentWindow)
        {
        }
    }
}
