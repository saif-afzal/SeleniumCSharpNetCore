@ECHO OFF
taskkill /f /im "IEDriverServer.exe"
taskkill /f /im "iexplore.exe"
taskkill /f /im "chromedriver.exe"
taskkill /f /im "nunit*"
rem ping 192.0.2.2 -n 1 -w 10000 > nul

cd /d %~dp0/..


rem %windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe ..\TestAutomation.sln /t:Clean,Build /p:Configuration=Release

DEL /F /S /Q /A TestResult.xml
DEL /F /S /Q /A TestResult.html
nunit3-console.exe -x86 bin\Debug\19_1.dll --where "cat=chrome" --test=Selenium2.Meridian.Suite.NF_DashboardComplianceTest
set DeployToQA=%ERRORLEVEL%

ping 192.0.2.2 -n 1 -w 10000 > nul
move TestResult.xml bin\Debug
ping 192.0.2.2 -n 1 -w 10000 > nul
rem move bin\Debug\*.html TestResult.html

rem nant -buildfile:bin\Release\TestAutomation.build
REM Set XMLPath=%~dp0/..

REM SET SCRIPTDIR=%~dp0/..
REM :: Remove trailing backslash, if it exists...
REM :: http://stackoverflow.com/questions/2952401/remove-trailing-slash-from-batch-file-input
REM IF %SCRIPTDIR:~-1%==\ SET SCRIPTDIR=%SCRIPTDIR:~0,-1%

REM :: Check for the latest available drive...
REM :: http://wiki.uniformserver.com/index.php/Batch_files:_First_Free_Drive
REM FOR %%a in (C D E F G H I J K L M N O P Q R S T U V W X Y Z) do CD %%a: 1>> nul 2>&1 & if errorlevel 1 SET FREEDRIVE=%%a:

REM subst %FREEDRIVE% %SCRIPTDIR%
REM cd /d "%FREEDRIVE%"
REM powershell.exe Set-ExecutionPolicy bypass
REM powershell.exe -command ". .\SmokeFunctions.ps1;
REM rem set DeployToQA=%ERRORLEVEL%
REM echo %ERRORLEVEL%

REM :: Send smoke test results to just Saif and me...
REM powershell.exe -command ". .\SmokeFunctions.ps1; EmailTestGroup -envVar_LMSversion '19.1' -envVar_success %DeployToQA% -ReportsDir %FREEDRIVE%\reports"

REM cd /d "C:"
REM subst %FREEDRIVE% /D

