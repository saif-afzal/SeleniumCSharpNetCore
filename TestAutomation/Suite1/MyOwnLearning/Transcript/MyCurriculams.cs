﻿using System;
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

namespace Selenium2.Meridian.Suite.MyOwnLearning.Transcript
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class MyCurriculamsold : TestBase
    {

        string browserstr = string.Empty;
        public MyCurriculamsold(string browser)
            : base(browser)
        {
            browserstr = browser;
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public  void a_Click_the_Curriculums_quicklink()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();
            Transcriptsobj.Check_CurriculamFirstItem();

        }
        [Test]
        public  void b_Click_on_a_curriculum_title()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();
            Transcriptsobj.Check_CurriculamFirstItem();
            string firstitem = Transcriptsobj.Click_CurriculamFirstItem();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(firstitem));
        }
        [Test]
        public  void c_Click_the_Print_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();
            Assert.IsTrue(Transcriptsobj.Click_PrintBtn("Curriculums"));
        }
        [Test]
        public  void d_Click_the_Save_as_PDF_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();
            Assert.IsTrue(Transcriptsobj.Click_PDFBtn("CurriculaPrint.aspx"));
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
