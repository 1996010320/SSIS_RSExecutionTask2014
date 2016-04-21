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
5. Create a SSIS 2014 project via SSDT or Visual Studio, the Report Execution Task should be available in Control Flow tasks

## Uninstall
To Remove the task from SSDT or Visual Studio, open Visual Studio Developer Command Prompt tool and input below commands:
```
"C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\gacutil.exe" -u ReportingServiceExecutionTask
"C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\gacutil.exe" -u ReportingServiceExecutionTask_UI
```

