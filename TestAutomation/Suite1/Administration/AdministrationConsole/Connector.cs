using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;

using TestAutomation.Meridian.Regression_Objects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Connectorold : TestBase
    {
        string browserstr = string.Empty;
        bool isadmincases = false;
        public Connectorold(string browser)
            : base(browser)
        {
            browserstr = browser+"cono";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
        }
       
     
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1",browserstr);
            }
            Meridian_Common.islog = false;
            isadmincases = false;
        }
        [Test]
        public void a_Connectors_Setup_Virtual_Meetings_Adoebe_17018()
        {
            isadmincases = true;
            bool foundresult = false;
           // string text = "Adobe1";
            string expectedresult = "You have connected " + Variables.AdobeName+browserstr + " Adobe Connect!";
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentConfiguration_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_content_configuration']"));
            
            AdminstrationConsoleobj.Click_OpenItemLink("Virtual Meeting Connectors");
            VirtualMeetingsobj.Click_Button();
            VirtualMeetingsobj.Click_FrameLink("Adobe Connect");
            VirtualMeetingsobj.PopulateAdobeMeetingsForm(ExtractDataExcel.MasterDic_Adobe["Name"], ExtractDataExcel.MasterDic_Adobe["Password"], ExtractDataExcel.MasterDic_Adobe["URL"]);
            VirtualMeetingsobj.Click_Button_Validate();
            VirtualMeetingsobj.Click_Button_Next();
            VirtualMeetingsobj.PopulateConnectionName(Variables.AdobeName+browserstr);
            string actualres = VirtualMeetingsobj.Click_Button_Done();
           
            if (driver.Compareregexstring(expectedresult,actualres))
            {
                foundresult = true;

            }
            Assert.IsTrue(foundresult);
         
        }
        [Test]
        public void b_Connectors_Setup_Virtual_Meetings_Gotomeeting_17018()
        {
            isadmincases = true;
            bool foundresult = false;
           
            string expectedresult = "You have connected " + Variables.GoToMeetingName+browserstr + " GoToMeeting!";
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentConfiguration_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_content_configuration']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Virtual Meeting Connectors");
 
            VirtualMeetingsobj.Click_Button();
            VirtualMeetingsobj.Click_FrameLink("GoToMeeting");
            VirtualMeetingsobj.PopulateGotomeetingMeetingsForm(ExtractDataExcel.MasterDic_GoToMeeting["Name"], ExtractDataExcel.MasterDic_GoToMeeting["Password"], ExtractDataExcel.MasterDic_GoToMeeting["ClientId"]);
            VirtualMeetingsobj.Click_Button_Validate();
            VirtualMeetingsobj.Click_Button_Next();
            VirtualMeetingsobj.PopulateConnectionName(Variables.GoToMeetingName+browserstr);

            Assert.IsTrue(driver.Compareregexstring(expectedresult, VirtualMeetingsobj.Click_Button_Done()));
 

           
        }

        [Test]
        public void c_Connectors_Setup_Virtual_Meetings_WebEx_17018()
        {
            isadmincases = true;
            bool foundresult = false;
          //  string text = "WebEx1";
            string expectedresult = "You have connected " + Variables.WebexName+browserstr + " WebEx Meeting!";
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentConfiguration_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_content_configuration']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Virtual Meeting Connectors");
            VirtualMeetingsobj.Click_Button();
            VirtualMeetingsobj.Click_FrameLink("WebEx Meeting");
            VirtualMeetingsobj.PopulateWebexMeetingsForm(ExtractDataExcel.MasterDic_Webex["URL"], ExtractDataExcel.MasterDic_Webex["Username"], ExtractDataExcel.MasterDic_Webex["Password"], ExtractDataExcel.MasterDic_Webex["Siteid"], ExtractDataExcel.MasterDic_Webex["Partnerid"]);
            VirtualMeetingsobj.Click_Button_Validate();
            VirtualMeetingsobj.Click_Button_Next();
            VirtualMeetingsobj.PopulateConnectionName(Variables.WebexName+browserstr);
           
            Assert.IsTrue(driver.Compareregexstring(expectedresult, VirtualMeetingsobj.Click_Button_Done()));
           // string actualresult=VirtualMeetingsobj.Click_Button_Done();
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
        }

        [Test]
        public void d_Connectors_Setup_Virtual_Meetings_Gototraining_17018()
        {
            isadmincases = true;
            bool foundresult = false;
           // string text = "Gototraining1";
            string expectedresult = "You have connected " + Variables.GoToTrainingName+browserstr + " GoToTraining!";
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentConfiguration_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_content_configuration']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Virtual Meeting Connectors");
            VirtualMeetingsobj.Click_Button();
            VirtualMeetingsobj.Click_FrameLink("GoToTraining");
            VirtualMeetingsobj.PopulateGototrainingMeetingsForm(ExtractDataExcel.MasterDic_GoToTraining["Name"], ExtractDataExcel.MasterDic_GoToTraining["Password"], ExtractDataExcel.MasterDic_GoToTraining["ClientId"]);
            VirtualMeetingsobj.Click_Button_Validate();
            VirtualMeetingsobj.Click_Button_Next();
            VirtualMeetingsobj.PopulateConnectionName(Variables.GoToTrainingName+browserstr);

            Assert.IsTrue(driver.Compareregexstring(expectedresult, VirtualMeetingsobj.Click_Button_Done()));

        }

        //commented due to new window bug
        ///// <summary>
        ///// this test must be executed after b_Connectors_Setup_Virtual_Meetings_Gotomeeting_17018
        ///// </summary>
        //[Test]
        //public void e_Instructor_SelfRegistration_GoToMeeting_17513()
        //{

        //    string expectedresult = "You’ve successfully set up GoToMeeting.";
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.Click_MyAccount();
        //  StringAssert.AreEqualIgnoringCase(expectedresult,MyAccountobj.Click_GoToMeetingAndSelectConnector(Variables.GoToMeetingName+browserstr));

        //}
        ///// <summary>
        ///// this test must be executed after a_Connectors_Setup_Virtual_Meetings_Adoebe_17018
        ///// </summary>
        //[Test]
        //public void f_Instructor_SelfRegistration_AdobeConnect_18973()
        //{

        //    string expectedresult = "You’ve successfully set up Adobe Connect.";
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.Click_MyAccount();
        //    StringAssert.AreEqualIgnoringCase(expectedresult, MyAccountobj.Click_AdobeConnectAndSelectConnector(Variables.AdobeName+browserstr));

        //}

        ///// <summary>
        ///// this test must be executed after d_Connectors_Setup_Virtual_Meetings_Gototraining_17018
        ///// </summary>
        //[Test]
        //public void g_Instructor_SelfRegistration_GoToTraining_18807()
        //{

        //    string expectedresult = "You’ve successfully set up GoToTraining.";
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.Click_MyAccount();
        //    StringAssert.AreEqualIgnoringCase(expectedresult, MyAccountobj.Click_GoToTrainingAndSelectConnector(Variables.GoToTrainingName+browserstr));

        //}
        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
           // _extent.Flush();
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }

   

    }
}
