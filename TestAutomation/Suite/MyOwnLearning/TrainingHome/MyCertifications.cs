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

namespace Selenium2.Meridian.Suite.MyOwnLearning.TrainingHome
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
            browserstr = browser+"molmycer";
        }
       
        static CertificationUtils MyCertificationsobj;
        static MyOwnLearningUtils MyOwnLearningobj;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyCertificationsobj = new CertificationUtils(driver);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
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
        public void a_Access_the_Training_Home_page_and_view_the_My_Certifications_portlet()
        {
            Assert.IsTrue(MyCertificationsobj.CheckCertificationCount());
        }
        [Test]
        public void b_Click_the_View_Details_button()
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driver);
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(MyCertificationsobj.CertificationViewDetail("Revoke"));
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
