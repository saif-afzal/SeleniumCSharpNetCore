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

namespace Selenium2.Meridian.Suite.MyOwnLearning.Transcript
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ExternalLearningold : TestBase
    {
        string browserstr = string.Empty;
        public ExternalLearningold(string browser)
            : base(browser)
        {
            browserstr = browser+"EL";
            // driver.Manage().Window.Maximize();
            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }
    
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);

            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Click_the_External_Learning_quicklink()
        {
            driver.UserLogin("userforregression",browserstr);
            //TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_ExternalLearningLink();
            Transcriptsobj.Click_ELSubmitRequest();
            ExternalLearningSearchobj.Click_SearchEl("");
            string firstel = ExternalLearningSearchobj.Click_Elfirstitem();
            Detailsobj.Click_SubmitRequest();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_ExternalLearningLink();
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(firstel));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void b_Click_on_an_external_learning_title()
        {
            driver.UserLogin("userforregression",browserstr);
          //  TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_ExternalLearningLink();
            string firstitem = Transcriptsobj.Click_ELFirstItem();
            Detailsobj.Check_ContentHeading(firstitem);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void c_Click_the_Print_link()
        {
            driver.UserLogin("userforregression",browserstr);
         //   TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Assert.IsTrue(Transcriptsobj.Click_PrintBtn("External Learning"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void d_Click_the_Save_as_PDF_link()
        {
            driver.UserLogin("userforregression",browserstr);
      //      TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Assert.IsTrue(Transcriptsobj.Click_PDFBtn("MyExternalLearningsPrint.aspx"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void e_Click_the_Submit_Request_button()
        {
            driver.UserLogin("userforregression",browserstr);
         //   TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_ExternalLearningLink();
            Assert.IsTrue(Transcriptsobj.Click_ELSubmitRequest());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void f_Conduct_a_search_for_an_external_learning_item()
        {

            driver.UserLogin("userforregression",browserstr);
       //     TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_ExternalLearningLink();
            Transcriptsobj.Click_ELSubmitRequest();
            Assert.IsTrue(ExternalLearningSearchobj.Click_SearchEl(""));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void g_Click_on_an_external_learning_item_and_submit_a_request()
        {
            driver.UserLogin("userforregression",browserstr);
        //    TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_ExternalLearningLink();
            Transcriptsobj.Click_ELSubmitRequest();
            ExternalLearningSearchobj.Click_SearchEl("");
            string secondel = ExternalLearningSearchobj.Click_Elseconditem();
            Detailsobj.Click_SubmitRequest();
            TrainingHomeobj.Click_TranscriptLink();
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(secondel));
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
