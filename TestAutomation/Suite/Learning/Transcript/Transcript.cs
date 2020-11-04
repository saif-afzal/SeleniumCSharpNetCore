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
    class Transcript : TestBase
    {
        string browserstr = string.Empty;
        public Transcript(string browser)
            : base(browser)
        {
            browserstr = browser;
}
      
        public TrainingHomes TrainingHomesobj;
        public Transcripts Transcriptsobj;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            Transcriptsobj = new Transcripts(driver);
            TrainingHomesobj = new TrainingHomes(driver);
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        }
        [Test]
        public  void a_Click_the_Transcript_from_the_menu()
        {
            driver.UserLogin("admin1",browserstr);
            TrainingHomesobj.isTrainingHome();
            TrainingHomesobj.Click_TranscriptLink();
            Assert.IsTrue(Transcriptsobj.Check_TranscriptDefaults());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
