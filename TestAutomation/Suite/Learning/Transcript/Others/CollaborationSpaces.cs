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
    class CollaborationSpaces : TestBase
    {
        string browserstr = string.Empty;
        public CollaborationSpaces(string browser)
            : base(browser)
        {
            browserstr = browser+"waipre";
}
       
        static MoreInformationUtil MoreInformationUtilobj;
        static TrainingHomes TrainingHomeobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MoreInformationUtilobj = new MoreInformationUtil(driver);
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
        public void a_View_the_Waived_Prerequisities_quicklink()
        {
            Assert.IsTrue(MoreInformationUtilobj.checkwiever(browserstr));
        }
        [Test]
        public void b_Click_the_Print_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(MoreInformationUtilobj.printwiever(browserstr));
        }
        [Test]
        public void c_Click_the_Save_as_PDF_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(MoreInformationUtilobj.savepdfwiever(browserstr));
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
