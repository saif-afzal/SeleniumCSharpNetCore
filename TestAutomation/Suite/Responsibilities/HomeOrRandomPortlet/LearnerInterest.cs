using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


//using TestAutomation.Meridian.Regression_Objects;


namespace Selenium2.Meridian.Suite.MyResponsibilities.a_Home
{
    /// <summary>
    /// Checks the home link and verify the porlets in the page My Content, My Teaching Schedule, Instructor Tools, Most Recent Requests
    /// </summary>
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
  
    [Parallelizable(ParallelScope.Fixtures)]
    public class a_Home : TestBase
    {

      //  public IWebDriver driver;
        string browserstr = string.Empty;
        public a_Home(string browser)
            : base(browser)
        {
            browserstr = browser;
            //OneTimeTearDown();
            //driver = StartBrowser(browser);
        }
          [OneTimeSetUp] 
        public void OneTimeSetUp()
        {

            Common.closeie();
           // ExtractDataExcel.fillalldic();
           // driver = StartBrowser();
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
           // driver.UserLogin("admin", browserstr);
         
           
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            Meridian_Common.checklocal = false;
            driver.Quit();
        }

        [SetUp]
        public void starttest()
        {
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin",browserstr);
            }
            Meridian_Common.islog = false;
        }
        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
              //  driver.Navigate_to_TrainingHome();
            }
        }
        /// <summary>
        /// Checks the home link and verify the porlets in the page My Content, My Teaching Schedule, Instructor Tools, Most Recent Requests
        /// </summary>
        [Test]
        public void a4_Click_the_Training_link()
        {
            classroomcourse = new ClassroomCourse(driver);
            List<string> expectedresult = new List<string>(4);
            expectedresult.Add("Content Created by Me");
            expectedresult.Add("Most Recent Requests");
            expectedresult.Add("Instructor Tools");
            expectedresult.Add("Needs Grading");
            expectedresult.Add("On-the-Job Training Tasks");
            expectedresult.Add("Manage Content");
            expectedresult.Add("Quick Links");
            expectedresult.Add("Learner Interest");
            driver.UserLogin("admin",browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            List<string> result = new List<string>(4);
            result = classroomcourse.NavigateMyResponsibilitiesTab(driver);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(expectedresult[i], result[i]);//in every loop verifies the portlet
            }
            

        }
     


    }
  
}





