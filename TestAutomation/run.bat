@ECHO OFF
nunit3-console.exe bin\Debug\TestAutomation.dll --result=TestResult.xml;format=nunit2 --seed=2 --workers=3
rem nunit3-console.exe bin\Debug\TestAutomation.dll --test=Selenium2.Meridian.Suite.MyResponsibilities.a_Home.a_Home --result=TestResult.xml;format=nunit2 --workers=1
rem pause