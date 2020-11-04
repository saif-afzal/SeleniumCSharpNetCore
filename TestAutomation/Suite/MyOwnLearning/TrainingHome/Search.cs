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
    class Search : TestBase
    {
        string browserstr = string.Empty;
        public Search(string browser)
            : base(browser)
        {
            browserstr = browser + "Search";
}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
         
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test]
        public  void a_Conduct_a_simple_search_for_a_course_content_item()
        {
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("simple_search", browserstr);
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"] + "simple_search"));
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(ExtractDataExcel.MasterDic_genralcourse["Title"] + "simple_search"));
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
