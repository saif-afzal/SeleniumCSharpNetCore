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
    class MyCurriculams : TestBase
    {

        string browserstr = string.Empty;
        public MyCurriculams(string browser)
            : base(browser)
        {
            browserstr = browser;
}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
    }
}
