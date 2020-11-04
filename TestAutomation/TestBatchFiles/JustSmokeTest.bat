@ECHO OFF
taskkill /f /im "IEDriverServer.exe"
taskkill /f /im "iexplore.exe"
taskkill /f /im "chromedriver.exe"
taskkill /f /im "nunit*"
rem ping 192.0.2.2 -n 1 -w 10000 > nul
cd /d %~dp0
rem %windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe ..\TestAutomation.sln /t:Clean,Build /p:Configuration=Release

DEL /F /S /Q /A %~dp0bin\TestResult.xml
DEL /F /S /Q /A %~dp0bin\Release\TestResult.xml
nunit3-console.exe -x86 bin\Debug\TestAutomation.dll --where "cat=chrome" --test=Selenium2.Meridian.Suite.SmokeTest_19_1
set DeployToQA=%ERRORLEVEL%
ping 192.0.2.2 -n 1 -w 10000 > nul
move TestResult.xml bin\Debug
ping 192.0.2.2 -n 1 -w 10000 > nul
move bin\Debug\*.html TestResult.html

rem nant -buildfile:bin\Release\TestAutomation.build
Set XMLPath=%~dp0bin

SET SCRIPTDIR=%~dp0
:: Remove trailing backslash, if it exists...
:: http://stackoverflow.com/questions/2952401/remove-trailing-slash-from-batch-file-input
IF %SCRIPTDIR:~-1%==\ SET SCRIPTDIR=%SCRIPTDIR:~0,-1%

:: Check for the latest available drive...
:: http://wiki.uniformserver.com/index.php/Batch_files:_First_Free_Drive
FOR %%a in (C D E F G H I J K L M N O P Q R S T U V W X Y Z) do CD %%a: 1>> nul 2>&1 & if errorlevel 1 SET FREEDRIVE=%%a:

subst %FREEDRIVE% %SCRIPTDIR%
cd /d "%FREEDRIVE%"
powershell.exe Set-ExecutionPolicy bypass
powershell.exe -command ". .\SmokeFunctions.ps1;
rem set DeployToQA=%ERRORLEVEL%
echo %ERRORLEVEL%

:: Send smoke test results to just Saif and me...
powershell.exe -command ". .\SmokeFunctions.ps1; EmailTestGroup -envVar_LMSversion '18.2' -envVar_success %DeployToQA% -ReportsDir %FREEDRIVE%\reports"

cd /d "C:"
subst %FREEDRIVE% /D

