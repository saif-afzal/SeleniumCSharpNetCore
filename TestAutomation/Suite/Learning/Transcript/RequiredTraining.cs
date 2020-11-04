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

namespace Selenium2.Meridian.Suite.MyOwnLearning.Transcript
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class RequiredTraining : TestBase
    {
        string browserstr = string.Empty;
        public RequiredTraining(string browser)
            : base(browser)
        {
            browserstr = browser;
}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
        }
        [SetUp]
        public void starttest()
        {
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
        public void a_Click_the_Required_Training_quicklink()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_RequiredTrainingLink();
            Transcriptsobj.Check_RequiredTrainingFirstItem();
        }

        // [Test]
        public void b_Expand_information_for_the_required_training_assignments()
        {
            string _expectedresult = "Details";
            driver.UserLogin("userforregression",browserstr);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void c_Click_on_a_content_item()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_RequiredTrainingLink();
            Transcriptsobj.Check_RequiredTrainingFirstItem();
            string firstitem = Transcriptsobj.Click_RequiredTrainingFirstItem();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(firstitem));
        }
        [Test]
        public void d_Click_the_Print_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_RequiredTrainingLink();
            Assert.IsTrue(Transcriptsobj.Click_PrintBtn("Required Training"));
        }

        [Test]
        public void e_Click_the_Save_as_PDF_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_RequiredTrainingLink();
            Assert.IsTrue(Transcriptsobj.Click_PDFBtn("RequiredTrainingPrint.aspx"));
        }

        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }
    }
}
