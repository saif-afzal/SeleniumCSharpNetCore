using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;

//using TestAutomation.Meridian.Regression_Objects;

/// <summary>
/// On clicking the content title it must open the details page.
/// Clicking on View All courses from Content Portlet to test whether all the courses created are displayed.
/// </summary>

namespace Selenium2.Meridian.Suite.MyResponsibilities.a_Home
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   public  class b_MyContent : TestBase
    {
        string browserstr = string.Empty;
        public b_MyContent(string browser)
            : base(browser)
        {
            browserstr = browser;
            //Common.closeie();
            //driver = StartBrowser(browser);
        }
      
       
     
        

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            //Variables.setvalues(browserstr);
            //ExtractDataExcel.fillalldic(browserstr);
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            

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
                driver.UserLogin("admin", "", "", browserstr);
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
                //driver.Navigate_to_TrainingHome();
            }
        }
        /// On clicking the content title it must open the details page.
        /// </summary>
        [Test]
        public void b6_Click_on_a_content_title()
        {
            string expectedresult = "Content";
            string actualresult = string.Empty;
            //creates the prerequisites
            driver.UserLogin("admin",browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "contenttitle"+browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            //Test Starts
            classroomcourse.linkmyresponsibilitiesclick(driver);
            actualresult = classroomcourse.linkcontenttitleclick();
            // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            StringAssert.Contains(expectedresult, actualresult);
        }
     
        /// <summary>
        /// Clicking on View All courses from Content Portlet to test whether all the courses created are displayed.
        /// </summary>
        [Test]
        public void b7_Click_View_All_Courses()
        {
            string expectedresult = "The item was created.";
            //Create the prerequisite. Creates the classroom course with different name

            

            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "viewallcourses"+browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            //Test Starts
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonviewallcoursesclick();
            classroomcourse.populatecontentsearchsimple("Contains", ExtractDataExcel.MasterDic_classrommcourse["Title"]+"viewallcourses"+browserstr, "");
            classroomcourse.buttoncontentsearchclick();
            int j = 0;// defined the integer for the iteration in the table of elements
            j = driver.countelements(By.XPath("//a[contains(@id,'ctl00_MainContent_ucSearchResults_rlvSearchResults')]"));

            string expectedresult1 = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "viewallcourses" + browserstr;
            Assert.IsTrue(driver.Compareregexstring(expectedresult1, driver.gettextofelement(By.XPath("//a[contains(@id,'ctl00_MainContent_ucSearchResults_rlvSearchResults')]"))));

        }
     
    }
  
}





