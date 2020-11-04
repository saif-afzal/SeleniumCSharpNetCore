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
    class MyCurriculams : TestBase
    {
        string browserstr = string.Empty;
        public MyCurriculams(string browser)
            : base(browser)
        {
            browserstr = browser+"molmycur";
}
       
        static CurriculamUtil MyCurriculamsobj;
        static MyOwnLearningUtils MyOwnLearningobj;
        static TrainingHomes TrainingHomeobj;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyCurriculamsobj = new CurriculamUtil(driver);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
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
        public void a_Access_the_Training_Home_page_and_view_the_My_Curriculums_portlet()
        {
            Assert.IsTrue(MyCurriculamsobj.CheckCricullamCount());
        }

        [Test]
        public void b_Click_the_View_Details_button()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(MyCurriculamsobj.CricullamViewDetail());
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
