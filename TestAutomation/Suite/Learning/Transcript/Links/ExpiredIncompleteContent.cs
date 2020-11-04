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

namespace Selenium2.Meridian.Suite.MyOwnLearning.MoreInformation
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]

    class ExpiredIncompleteContent : TestBase
    {
        string browserstr = string.Empty;
        public ExpiredIncompleteContent(string browser)
            : base(browser)
        {
            browserstr = browser+"ExpIncCont";
        }
      
        static MoreInformationUtil MoreInformationUtilobj;
       [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MoreInformationUtilobj = new MoreInformationUtil(driver);
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
       public void a_View_the_Expired_Incomplete_Content_quicklink()
       {
           //driver.UserLogin("admin1", browserstr);
           Assert.IsTrue(MoreInformationUtilobj.checkexpired());
       }
        [Test]
        public void b_Click_the_Print_link()
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driver);
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(MoreInformationUtilobj.printexpired());
        }
        [Test]
        public void c_Click_the_Save_as_PDF_link()
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driver);
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(MoreInformationUtilobj.savepdfexpired());
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
