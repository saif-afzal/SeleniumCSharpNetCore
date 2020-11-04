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
    class MyCertifications : TestBase
    {
        string browserstr = string.Empty;
        public MyCertifications(string browser)
            : base(browser)
        {
            browserstr = browser;
}
       
        static MyOwnLearningUtils MyOwnLearningobj;
        public TrainingHomes TrainingHomesobj;
        public Create Createobj;
        public SearchResults SearchResultsobj;
        public Details Detailsobj;
        public Training Trainingobj;
        public ContentSearch ContentSearchobj;
        public Content Contentobj;
        public Transcripts Transcriptsobj;
        public TrainingHomes TrainingHomeobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            TrainingHomesobj = new TrainingHomes(driver);
            Createobj = new Create(driver);
            SearchResultsobj = new SearchResults(driver);
            Detailsobj = new Details(driver);
            Trainingobj = new Training(driver);
            Contentobj = new Content(driver);
            Transcriptsobj = new Transcripts(driver);
            ContentSearchobj = new ContentSearch(driver);
            TrainingHomeobj = new TrainingHomes(driver);
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
        public  void a_Click_the_Certifications_quicklink()
        {
            TrainingHomesobj.isTrainingHome();
            TrainingHomesobj.Click_TranscriptLink();
            Transcriptsobj.Click_CertificationLink();
            Transcriptsobj.Check_CertificationsFirstItem();

        }
        [Test]
        public void b_Click_on_a_certification_title()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomesobj.isTrainingHome();
            TrainingHomesobj.Click_TranscriptLink();
            Transcriptsobj.Click_CertificationLink();
            Transcriptsobj.Check_CertificationsFirstItem();
            string firstitem = Transcriptsobj.Click_CertificationsFirstItem();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(firstitem));
        }
        [Test]
        public  void c_Click_the_Print_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomesobj.isTrainingHome();
            TrainingHomesobj.Click_TranscriptLink();
            Transcriptsobj.Click_CertificationLink();
            Assert.IsTrue(Transcriptsobj.Click_PrintBtn("Certifications"));

        }
        [Test]
        public  void d_Click_the_Save_as_PDF_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomesobj.isTrainingHome();
            TrainingHomesobj.Click_TranscriptLink();
            Transcriptsobj.Click_CertificationLink();
            Assert.IsTrue(Transcriptsobj.Click_PDFBtn("MyCertificationsPrint.aspx"));
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
