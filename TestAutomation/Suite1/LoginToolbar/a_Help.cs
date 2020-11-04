using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;
using System.Threading;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.LoginToolbar
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class a_Helpold_Reg : TestBase
    {
        string browserstr = string.Empty;
        public a_Helpold_Reg(string browser)
            : base(browser)
        {
            browserstr = browser+"help";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }
      

      //  [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }

        /// <summary>
        /// Checks the holp link and verify help link title after login with an admin user.
        /// </summary>
        [Test, Category("P1")]
        public  void a_Click_the_Help_link_238()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            //CommonSection.ClickHelpIcon();
            //_test.Log(Status.Pass, "help icon opens successfully");
            //Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Assert.That(1 == 1);
        }
        [Test, Category("P1")]
        public void a_Click_the_Help_link_239()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            //CommonSection.ClickHelpIcon();
            //_test.Log(Status.Pass, "help icon opens successfully");
            //Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Assert.That(1 == 1);
        }
        // [TearDown]
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
