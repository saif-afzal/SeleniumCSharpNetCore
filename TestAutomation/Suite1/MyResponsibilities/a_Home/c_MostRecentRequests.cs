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


namespace Selenium2.Meridian.Suite.MyResponsibilities.a_Home
{

    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class c_MostRecentRequestsold : TestBase
    {
        string browserstr = string.Empty;
        public c_MostRecentRequestsold(string browser)
            : base(browser)
        {
            browserstr = browser + "mrr";
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }
        public bool errorhandling = false;





       

        

        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            classroomcourse = new ClassroomCourse(driver);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1", browserstr);
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



        [Test]
        public void e18_Click_on_a_user_name()
        {
          

            string expectedresult = "City:";
            string actualresult = string.Empty;
            driver.UserLogin("admin1", browserstr);
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_training_management']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Access Approval Paths')]"));
            driver.selectWindow("Approval Paths");
            ApprovalPathobj.Click_CreateNewGoTo();
            ApprovalPathobj.Populate_AdministrativeApproval(ExtractDataExcel.MasterDic_approver["Title"] + browserstr);
            ApprovalPathobj.Select_Administrators(0);
            driver.Navigate_to_TrainingHome();
           // TrainingHomeobj.isTrainingHome();
            // classroomcourse.deleteclassroomcourse(driver);

            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            //classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.linkcoursesectionclick();
            approvalrequest.buttonaccessapprovaleditclick();
            approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"] + browserstr, "Exact phrase");
            approvalrequest.buttonaccessapprovalsearchclick();
            approvalrequest.radioaccessapprovalresultclick();
            approvalrequest.buttonaccessapprovalsaveclick();
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a"));
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr, "Exact phrase");
            driver.clicktableresult(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr);
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();
            

            classroomcourse.linkmyresponsibilitiesclick(driver);
            actualresult = classroomcourse.linkmostrecentrequestsusernamelinkclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);

            StringAssert.Contains(expectedresult, actualresult);


        }

        [Test]
        public void e19_Click_on_content_title()
        {

            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr;
            string actualresult = string.Empty;

            classroomcourse.linkmyresponsibilitiesclick(driver);
            actualresult = classroomcourse.linkmostrecentrequestscontenttitlelinkclick(ExtractDataExcel.MasterDic_approver["Title"] + browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // driver.SwitchWindow("Section Information");

            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
        }
        [Test]
        public void e21_Approve_a_request()
        {

            string expectedresult = "The request was approved.";
            if (errorhandling == true)
            {
                approvalrequest.linkmyownlearningclick();
                driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr, "Exact phrase");
                driver.clicktableresult(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr);
                approvalrequest.buttonrequestaccessapprovalclick();
                approvalrequest.buttonrequestaccessapprovalframeclick();
            }
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.buttonrmostrecentrequestsaccessapprovalclick();
           
            Assert.IsTrue(driver.Compareregexstring(expectedresult, approvalrequest.buttonmostrecentrequestaccessapprovalframeclick()));

        }

        [Test]
        public void e20_Deny_a_request()
        {

            string expectedresult = " The request was denied.";

            //  classroomcourse.deleteclassroomcourse(driver);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //driver.UserLogin("admin");
            ////classroomcourse.linkmyresponsibilitiesclick(driver);
            ////classroomcourse.linkclassroomcourseclick();
            ////classroomcourse.buttongoclick();
            ////classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"deny_request", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            ////classroomcourse.buttonsaveclick();
            ////classroomcourse.linkmanagesectionsclick();
            ////classroomcourse.buttonaddnewsectionclick();
            ////classroomcourse.populatesectionform1();
            ////classroomcourse.populatesectionform12();
            ////classroomcourse.populateframeform();
            ////classroomcourse.buttonsaveframeclick();
            ////classroomcourse.buttonsaveandexitclick();
            ////classroomcourse.linkcoursesectionclick();
            ////approvalrequest.buttonaccessapprovaleditclick();
            ////approvalrequest.populatemanageaccessapprovalframe(""/*Administrative Approval*/ , "Exact phrase");
            ////approvalrequest.buttonaccessapprovalsearchclick();
            ////approvalrequest.radioaccessapprovalresultclick();
            ////approvalrequest.buttonaccessapprovalsaveclick();
            //approvalrequest.linkmyownlearningclick();
            //driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "username", "Exact phrase");
            //driver.clicktableresult();
            //approvalrequest.buttonrequestaccessapprovalclick();
            //approvalrequest.buttonrequestaccessapprovalframeclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            approvalrequest.buttonrmostrecentrequestdenyclick();
          Assert.IsTrue(driver.Compareregexstring(expectedresult, approvalrequest.buttonmostrecentrequestdenyframeclick()));
            
            errorhandling = true; //checks the deny request has taken place

        }
        // [Test]
        //  [Test]
        public void e22_Rescind_a_request()
        {

            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            // string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
            Instructor instructor = new Instructor(driver);
            int expectedresult = 1;
            driver.UserLogin("admin1", browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            instructor.drpdownfilterinstructortoolsportletselect("All Instructors");
            instructor.buttongoinstructortoolportletclick();
            int actualresult = driver.countelements(ObjectRepository.myresponsibilitiesinstructortoolsportlettableresultcount);
            Assert.GreaterOrEqual(actualresult, expectedresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }
        [Test]
        public void e23_Click_All_Requests()
        {

            // string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
            string expectedresult = "Approval Requests";

            classroomcourse.linkmyresponsibilitiesclick(driver);
            string actualresult = approvalrequest.buttonrmostrecentrequestsviewallrequestsclick();

            StringAssert.Contains(actualresult, expectedresult);

        }

    }
}








