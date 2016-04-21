# SSIS_RSExecutionTask2014
A custom control flow task in SSIS 2014 to generate reporting service report by calling report execution web service.

## Prerequisities
To compile the project in a dev environment, you need to have:
* SQL Server Integration Service 2014
* SQL Server Reporting Service support ReportService2010 and ReportExecution2005 web services
* Visual Studio 2012 or later versions (haven't tested on 2010)

## Install
1. Open the solution in Visual Studio and there should be two projects available: ReportingServiceExecutionTask and ReportingServiceExecutionTask_UI
2. For project ReportingServiceExecutionTask:
  * verify if Microsoft.SQLServer.ManagedDTS in References folder is referenced correctly, remove it and add correct version if necessary
  * verify if RS2010 and RSExec in Web References folder are with correct reporting service URL, update the url if necessary
  * Open project property window and go to Build tab, ensure the output path is correct. By default it is at "Program Files (x86)\Microsoft SQL Server\120\DTS\Tasks\"
  * Go to Build Events and in Post-Build event command line textbox, verify the path for the gacutil tool is correct, by default it is at "C:\Program Files (x86)\Microsoft SQL Server\120\DTS\Tasks\ReportingServiceExecutionTask.dll" 
3. For project ReportingServiceExecutionTask_UI:
  * verify if Microsoft.SQLServer.ManagedDTS and Microsoft.SQLServer.Dts.Design are referenced correctly, remove them and add correct versions if necessary
  * verify if RS2010 in Web References folder is with correct reporting service URL, update the url if necessary
  * Open project property window and go to Build tab, ensure the output path is correct. By default it is at "Program Files (x86)\Microsoft SQL Server\120\DTS\Tasks\"
  * Go to Build Events and in Post-Build event command line textbox, verify the path for the gacutil tool is correct, by default it is at "C:\Program Files (x86)\Microsoft SQL Server\120\DTS\Tasks\ReportingServiceExecutionTask_UI.dll" 
4. Build the solution
5. Create a SSIS 2014 project via SSDT or Visual Studio, the Reporting Service Execution Task should be available in Control Flow tasks

## Uninstall
To Remove the task from SSDT or Visual Studio, open Visual Studio Developer Command Prompt tool and input below commands:
```
"C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\gacutil.exe" -u ReportingServiceExecutionTask
"C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\gacutil.exe" -u ReportingServiceExecutionTask_UI
```
## Basic Usage
To use the Reporting Service Execution Task in SSDT or Visual Studio
1. drag and drop the Reporting Service Execution task onto the panel 
2. open the setting window by double click the task
3. input the Reporting Service server name, e.g. localhost, and then press Search button
4. in the popup report setting window, input a report name and then press the Search button (support "Like" condition)
5. select a report from dropdown box, the data grid view should list all parameters needed to execute the report
6. for required parameters select variables from corresponding dropdown box, and then press OK button to go back to task setting window
7. the data grid view on task setting window lists all parameter/variable mappings in READ-ONLY manner. To change the setting, repeat step 3 to step 6
8. to set export file format of the report, select a variable from File Format dropdown box
9. to set export file name of the report, select a variable from File Name dropdown box
10. After done all of them, press OK button to close the task setting window.
11. the task is ready to be executed

## Advanced Topic
#### Execute the task dynamically
You can assign variable value to the task dynamically. To do so:
1. select the Reporting Service Execution task and then in Properties window, open Expressions node
2. in the Property Expressions Editor, FileFormat (export file format), FileName (export file name), and SelectedReport(RS report you want to execute) can be set by inputting expression
3. the report parameters are fixed list and will be allocated at design time. It cannot be modified during runtime unfortunately


#### variable data type
When assigning the package variable to report parameters, the variable data type must follow certain rules:
* In most cases, the package variable will be translated to string and then be passed into the report. So for report parameter numeric values, strings, and even date (as long as the format is correct), it is saft to set package variable type as string
* However for the report parameter type Boolean, the package variable must be boolean as well
* If the report parameter has available value setting (a dropdown box in the report), then the variable passed into the report must be in the available value set as well


## Future Plan
Relase SSIS 2016 version when SQL Server 2016 is RTM.

