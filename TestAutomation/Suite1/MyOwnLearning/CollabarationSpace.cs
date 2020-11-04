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

namespace Selenium2.Meridian.Suite.MyOwnLearning
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CollabarationSpaceold : TestBase
    {
        string browserstr = string.Empty;
        public CollabarationSpaceold(string browser)
            : base(browser)
        {
            browserstr = browser+"CS";
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            TrainingHomeobj = new TrainingHomes(driver);
            CollabarationSpace_lobj = new CollabarationSpace_l(driver);
            Detailsobj = new Details(driver);
            driver.UserLogin("admin1", browserstr);
        }
      
        public TrainingHomes TrainingHomeobj;
        public CollabarationSpace_l CollabarationSpace_lobj;
        public Details Detailsobj;
     
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("userforregression", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Join_a_collaboration_space()
        {
            TrainingHomeobj.isTrainingHome();
            //  TrainingHomeobj.Click_CollabartionSpace();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Learn')]"), By.XPath("//a[contains(@href,'/CollaborationSpace.aspx')]"));

       //     AdminstrationConsoleobj.Click_OpenItemLink("Virtual Meeting Connectors");
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
           Assert.IsTrue( Detailsobj.Click_JoinColSpace());
            
        }


        [Test]
        public  void b_Click_on_a_collaboration_space_link()
        {

            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
          Assert.IsTrue(  Detailsobj.IsColSpaceDetailPage());
        }

      //  [Test] Need to add manager so that we can leave the collaboration space
        public  void d_Leave_a_collaboration_space()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Assert.IsTrue(Detailsobj.Click_LeaveColSpace());
        }

        [Test]
        public  void c_Access_a_collaboration_space()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Detailsobj.Click_AccessColSpace();
            Assert.IsTrue(CollabarationSpace_lobj.IsColSpaceItemAccessed());
            Assert.IsTrue(driver.existsElement(By.XPath("//div[contains(@class,'axero-space-header-title-name')]")));
        }
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
            //  _extent.Flush();
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
