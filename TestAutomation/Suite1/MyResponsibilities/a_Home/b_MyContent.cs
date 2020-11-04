using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

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
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   public  class b_MyContentold : TestBase
    {
        string browserstr = string.Empty;
        public b_MyContentold(string browser)
            : base(browser)
        {
            browserstr = browser;
            //Variables.setvalues(browserstr);
            //ExtractDataExcel.fillalldic(browserstr);
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //Common.closeie();
            //driver = StartBrowser(browser);
        }
      
       
     
        

     

        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1", "", "", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //  _extent.Flush();
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }
        /// On clicking the content title it must open the details page.
        /// </summary>
        [Test]
        public void b6_Click_on_a_content_title()
        {
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "contenttitle" + browserstr;
            string actualresult = string.Empty;
            //creates the prerequisites
            driver.UserLogin("admin1",browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            //classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "contenttitle"+browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            //Test Starts
            classroomcourse.linkmyresponsibilitiesclick(driver);
            actualresult = classroomcourse.linkcontenttitleclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "contenttitle" + browserstr);
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

            

            //classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
          //  classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "viewallcourses"+browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            //Test Starts
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonviewallcoursesclick();
            //classroomcourse.populatecontentsearchsimple("Contains", ExtractDataExcel.MasterDic_classrommcourse["Title"]+"viewallcourses"+browserstr, "");
            //classroomcourse.buttoncontentsearchclick();
            int j = 0;// defined the integer for the iteration in the table of elements
            j = driver.countelements(By.XPath(".//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div"));

            string expectedresult1 = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "viewallcourses" + browserstr;
            Assert.Greater(j, 1);
        }
     
    }
  
}





