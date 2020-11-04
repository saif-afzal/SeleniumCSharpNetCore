using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P2_Reg_19_1 : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPath" + Meridian_Common.globalnum;

        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        string Section = "Section" + Meridian_Common.globalnum;
        string SectionTitle = "Section_" + Meridian_Common.globalnum;
        bool res1 = false;
        bool ArchivedScale = false;
        string assignment = "Assignment" + Meridian_Common.globalnum;



        public P2_Reg_19_1(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
        }
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        //[TearDown]
        public void teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath = screenShotPath.Replace(@"C:\Users\admin\Desktop\Automation\Regression Scripts\18.2\", @"Z:\");
                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    if (driver.Title == "Object reference not set to an instance of an object.")
                    {
                        driver.Navigate_to_TrainingHome();
                        Driver.focusParentWindow();
                        CommonSection.Avatar.Logout();
                        LoginPage.LoginClick();
                        LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
                    }

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
                driver.Navigate().Refresh();
            }
        }
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }


        [Test, Order(1)]
        public void b1_View_Classroom_Calandar_26170()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "26170");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click Add New Section Tab");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            SectionsPage.ClickManageEnrollmentButton();
            EnrollmentPage.ClickEnrollButton();
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("ak learner");
            // Assert.IsTrue(Driver.comparePartialString("The selected users were enrolled in the section", Driver.getSuccessMessage()));


            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "26170");
            _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCalendarButton();
            _test.Log(Status.Info, "Click Calendar Button");
            Assert.IsTrue(SearchResultsPage.Calendar.isDisplayed());
            _test.Log(Status.Pass, "Verify Calendar is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isDisplayingCurrentMonth());
            _test.Log(Status.Pass, "Verify Current Month is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.VerifyCalendarDisplayClassroomCourse(classroomcoursetitle + "26170"));
            _test.Log(Status.Pass, "Verify Classroom Course are displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.VerifyCalendaronlyDisplayedOpenSectionWithOpenSeats());
            _test.Log(Status.Pass, "Verify Open Section With " +
                "Open Seats are Displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isTodayLinkDisplayed());
            _test.Log(Status.Pass, "Verify Today is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isYearLinkDisplayed());
            _test.Log(Status.Pass, "Verify Year link is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isMonthLinkDisplayed());
            _test.Log(Status.Pass, "Verify Month Link is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isWeekLinkDisplayed());
            _test.Log(Status.Pass, "Verify Week is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isDayLinkDisplayed());
            _test.Log(Status.Pass, "Verify Day Link is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isPrintButtonDisplayed());
            _test.Log(Status.Pass, "Verify Print Button is displayed");
            SearchResultsPage.Calendar.ClickmonthArrow();
            _test.Log(Status.Info, "Click Month Arrow Link");
            Assert.IsTrue(SearchResultsPage.Calendar.isCalendarShowingnextMOnth());
            _test.Log(Status.Pass, "Verify Next Month is displayed");
            SearchResultsPage.Calendar.ClickTodayButton();
            _test.Log(Status.Info, "Click Today Link");
            Assert.IsTrue(SearchResultsPage.Calendar.isDisplayingCurrentMonth());
            _test.Log(Status.Pass, "Verify Current Month is displayed");
            SearchResultsPage.Calendar.ClickYearLink();
            _test.Log(Status.Info, "Click Year Link");
            Assert.IsTrue(SearchResultsPage.Calendar.VerifyITDisplayAllMonths());
            _test.Log(Status.Pass, "Verify Al Months are displayed");
            SearchResultsPage.Calendar.ClickMonthLink();
            _test.Log(Status.Info, "Click Month Link");
            Assert.IsTrue(SearchResultsPage.Calendar.VerifyITDisplayWholeMonth());
            _test.Log(Status.Pass, "Verify displays content as per month in count");
            SearchResultsPage.Calendar.ClickWeekLink();
            _test.Log(Status.Info, "Click week link");
            Assert.IsTrue(SearchResultsPage.Calendar.VerifyITDisplayAWeek());
            _test.Log(Status.Pass, "Click it displays content per week");
            SearchResultsPage.Calendar.ClickDayLink();
            _test.Log(Status.Info, "Click Day Link");
            Assert.IsTrue(SearchResultsPage.Calendar.VerifyITDisplayAWholeDay());
            _test.Log(Status.Pass, "Verify it displays content of that day");
            SearchResultsPage.Calendar.ClickClassroomCourse();
            _test.Log(Status.Info, "Click Classroom Course");
            Assert.IsTrue(SearchResultsPage.Calendar.isNewFrameDisplaying());
            _test.Log(Status.Pass, "Verify New Frame is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isEventTitleDisplaying());
            _test.Log(Status.Pass, "Verify Event Title is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isEventLocationDisplaying());
            _test.Log(Status.Pass, "Verify Event Location is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isInstructorDisplaying());
            _test.Log(Status.Pass, "Verify Instructor is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isStartDateDisplaying());
            _test.Log(Status.Pass, "Verify Start Date is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isEndDateDisplaying());
            _test.Log(Status.Pass, "Verify End Date is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isStartTimeDisplaying());
            _test.Log(Status.Pass, "Verify Start Time is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isEndTimeDisplaying());
            _test.Log(Status.Pass, "Verify End Timeis displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isCancelButtonDisplaying());
            _test.Log(Status.Pass, "Verify Cancel Button is displayed");
            Assert.IsTrue(SearchResultsPage.Calendar.isMoreInformationDisplaying());
            _test.Log(Status.Pass, "Verify More Information  is displayed");
            SearchResultsPage.Calendar.ClickMoreInformationButton();
            _test.Log(Status.Info, "Click More Information BUtton");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "Verify Clsassroom Details is displayed");
            SearchResultsPage.Calendar.ClickCancelButton();
            _test.Log(Status.Info, "Click Cancel Button");
            Assert.IsTrue(SearchResultsPage.Calendar.isNewFrameCloses());
            _test.Log(Status.Pass, "Verify New Frame Closes");
            SearchResultsPage.Calendar.ClickPrintButton();
            _test.Log(Status.Info, "Click Print Button");
            _test.Log(Status.Info, "Login with Learner's Account");
            Assert.IsTrue(SearchResultsPage.verifyPrintWindowOpensDisplayingProperFormat());
            _test.Log(Status.Pass, "Verify Print Format is displayed");
        }

        [Test, Order(2)]
        public void P20_1_b2_Classroom_Calendar_Self_Enroll_in_Classroom_Course_27023()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with site admin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27023_NewEnroll");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click Add New Section Tab");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");

            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC27023_NewEnroll");
            _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27023_NewEnroll");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "Content Details Page is Displayed");
            Assert.IsTrue(ContentDetailsPage.isEnrollButtonDisplayed());
            _test.Log(Status.Pass, "Enroll Button is Displayed");
            ContentDetailsPage.ClickEnrollButton();
            _test.Log(Status.Info, "Click Enroll Button");
            Assert.IsTrue(Driver.comparePartialString(" You are enrolled in the course.", ContentDetailsPage.VerifyEnrollMessage()));//The item was submitted
            _test.Log(Status.Pass, "Verify Enroll Message");
            Assert.IsTrue(ContentDetailsPage.isCancelEnrollmentButtonDisplayed());
            _test.Log(Status.Pass, "Cancel Enrollment Button is Displayed");
            // ContentDetailsPage.CourseMaterials.ClickEnrollButton();

        }
        //Dependent on Testcase TC27023
        [Test, Order(3)]
        public void P20_1_b3_Classroom_Calendar_Self_Cancel_Enrollment_in_Classroom_Course_27024()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC27023_NewEnroll");
            _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27023_NewEnroll");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "Content Details Page is Displayed");
            // ContentDetailsPage.ClickEnrollButton();
            // Assert.IsTrue(Driver.comparePartialString(" You are enrolled in the course.", ContentDetailsPage.VerifyEnrollMessage()));//The item was submitted
            Assert.IsTrue(ContentDetailsPage.isCancelEnrollmentButtonDisplayed());
            _test.Log(Status.Pass, "Verify Cancel enrollment Button");
            ContentDetailsPage.ClickCancelEnrollment();
            _test.Log(Status.Info, "Click Cancel Enrollment");
            //Assert.IsTrue(Driver.comparePartialString(" Your enrollment for the selected course was cancelled.", ContentDetailsPage.VerifyEnrollCancelMessage()));//The item was submitted
            //_test.Log(Status.Pass, "Verify Cancel Enrollment Message");
            Assert.IsTrue(ContentDetailsPage.isEnrollButtonDisplayed());
            _test.Log(Status.Pass, "Verify Enrollment Button is Displayed");
            ContentDetailsPage.ClickEnrollButton();
            _test.Log(Status.Info, "Click Enroll Button");


        }
        [Test, Order(4)]
        public void b4_Classroom_Calendar_Self_Waitlist_in_Classroom_Course_27025()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC27023_NewEnroll");
            _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27023_NewEnroll");
            Assert.IsTrue(ContentDetailsPage.isWaitlistButtonDisplayed());
            _test.Log(Status.Pass, "Verify Waitlist Button is Displayed");
            ContentDetailsPage.ClickWaitlistButton();
            _test.Log(Status.Info, "Click Waitlist Button");
            //Assert.IsTrue(Driver.comparePartialString("You were added to the waitlist.", ContentDetailsPage.VerifyWaitlistMessage()));//The item was submitted
            //_test.Log(Status.Pass, "Verify WaitList Message");
            ContentDetailsPage.ClickCancelkWaitlistButton();
            _test.Log(Status.Info, "Click Cancel Waitlist Button");
        }


        [Test, Order(5)]
        //
        public void b5_Classroom_Calendar_Self_Cancel_Waitlist_in_Classroom_Course_27026()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC27023_NewEnroll");
            _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27023_NewEnroll");
            _test.Log(Status.Info, "Click Course Title");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "Content Details page is Displayed");
            ContentDetailsPage.ClickWaitlistButton();
            _test.Log(Status.Info, "Click Waitlist Button");
            ContentDetailsPage.ClickCancelkWaitlistButton();
            _test.Log(Status.Info, "Click Cancel Waitlist Button");
            Assert.IsTrue(ContentDetailsPage.isSectionDisplayed());
            _test.Log(Status.Pass, "Verify Section is Displayed");
            Assert.IsTrue(ContentDetailsPage.VerifyEnRollmentStatusUpdated());
            _test.Log(Status.Pass, "Verify Enrollment Status is Updated");
            Assert.IsTrue(Driver.comparePartialString("You were removed from the waitlist.", ContentDetailsPage.VerifyCancelWaitlistMessage()));//The item was submitted
            _test.Log(Status.Pass, "Cancel Waitlist Message is Displayed");

        }
        //[Test, Order(6)]
        //public void b6_View_Prerequisities_to_Classroom_26966()
        //{
        //    //CommonSection.Logout();
        //    _test.Log(Status.Info, "Logout of the Site Admin Account");
        //    LoginPage.LoginAs("ak_learner").WithPassword("").Login();
        //    _test.Log(Status.Info, "Login with Learner's Account");
        //    CommonSection.SearchCatalog("TC26966");
        //    _test.Log(Status.Info, "Click Catalog Search Button");
        //    SearchResultsPage.ClickCourseTitle("TC6966");
        //    _test.Log(Status.Info, "Click on Course Title");
        //    Assert.IsTrue(Driver.comparePartialString(" You have one or more prerequisites to complete before you can take or access this item. If you have previously completed the item," +
        //     " then you may not have completed it in the allotted time or did not achieve the required score.", ContentDetailsPage.VerifyPrerequisiteMessage()));
        //    _test.Log(Status.Pass, "Verify Prerequisite Message");
        //    Assert.IsTrue(ContentDetailsPage.isprerequisitetableDisplayed());
        //    _test.Log(Status.Pass, "Verify Prerequisite Table is Displayed");
        //}
      
        [Test, Order(9)]
        public void b9_Classroom_Calendar_View_Classroom_Course_Details_27027()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27027");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            //ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();
            CommonSection.SearchCatalog(classroomcoursetitle + "TC27027");
            _test.Log(Status.Info, "Click Catalog Search Button");
            Assert.IsTrue(SearchResultsPage.isSearchResultListDisplayed(classroomcoursetitle + "TC27027"));
            _test.Log(Status.Pass, "Verify Search list is Displayed");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27027");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isClassroomTitleDisplayed());
            _test.Log(Status.Pass, "Verify Course Title is Displayed");
            Assert.IsTrue(ContentDetailsPage.isSectionDisplayed());
            _test.Log(Status.Pass, "Verify Section is Displayed");
            Assert.IsTrue(ContentDetailsPage.isEventScheduleDisplayed());
            _test.Log(Status.Pass, "Verify Event Schedule is Displayed");
            Assert.IsTrue(ContentDetailsPage.isEnrollmentStartDateDisplayed());
            _test.Log(Status.Pass, "Verify Enrollment Start is Displayed");
            Assert.IsTrue(ContentDetailsPage.isEnrollmentEndDateDisplayed());
            _test.Log(Status.Pass, "Verify Enrollment End is Displayed");

        }
        [Test, Order(10)]
        public void b10_Classroom_Calendar_View_Classroom_Section_Certificates_27028()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.Avatar.Account();
            CommonSection.Transcript();
            CommonSection.SearchCatalog("TC27028");
            _test.Log(Status.Info, "Click Catalog Search Button");
            Assert.IsTrue(SearchResultsPage.isSearchResultListDisplayed(""));
            _test.Log(Status.Pass, "Verify Search list is Displayed");
            SearchResultsPage.ClickCourseTitle("TC27028");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "Verify Content Details Page is Displayed");
            ContentDetailsPage.ClickCourse();
            _test.Log(Status.Info, "Click on Course Title");

            Assert.IsTrue(ContentDetailsPage.isContentPageDisplayed());
            _test.Log(Status.Pass, "Verify content page is displayed");

            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Info, "Click on view certificate");

            Assert.IsTrue(ContentDetailsPage.isCertificatePageDisplayed());
            _test.Log(Status.Pass, "Verify certificate page is Displayed");

            Assert.IsTrue(CertificatePage.VerifyCertificateCourseTitle());
            _test.Log(Status.Pass, "verify certificate course title");


            Assert.IsTrue(CertificatePage.VerifyCertificateDate());
            _test.Log(Status.Pass, "verify certificate course Date");


            Assert.IsTrue(CertificatePage.VerifyCandidateName());
            _test.Log(Status.Pass, "verify candidate name");

            Assert.IsTrue(CertificatePage.isPrintLinkDisplayed());
            _test.Log(Status.Pass, "verify print link is Displayed");

            CertificatePage.ClickCloseWindow();
            _test.Log(Status.Info, "click on Close Window");

        }

        [Test, Order(11)]
        public void b11_Classroom_Calendar_Request_Access_to_Classroom_Course_27030()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27030");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(1);
            ManageClassroomCoursePage.CreateSection.SectionEndDate(-1);

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();
            SectionsPage.CourseTab();
            _test.Log(Status.Info, "Click Course Tab");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Button");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assing Approver Path");
           
            CommonSection.SearchCatalog(classroomcoursetitle + "TC27030");
            _test.Log(Status.Info, "Click Catalog Search Button");
            Assert.IsTrue(SearchResultsPage.isSearchResultListDisplayed(""));
            _test.Log(Status.Pass, "Verify Search list is Displayed");
            SearchResultsPage.ClickCourseTitle("TC27030");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessButtonDisplayed());
            _test.Log(Status.Pass, "Verify Requset Access Button is Displayed");
            ContentDetailsPage.ClickRequestAccess();
            _test.Log(Status.Info, "Click Request Access Button");
            Assert.IsTrue(ContentDetailsPage.isCancelRequestButtonDisplayed());
            _test.Log(Status.Pass, "Verify Cancel Request Button is Displayed");
            Assert.IsTrue(Driver.comparePartialString(" Your request for access approval was submitted." +
                " You will receive an email indicating whether your request is approved or denied. " + " You will automatically have access to the content if your request is approved.", ContentDetailsPage.getRequestAccessMessage()));
            _test.Log(Status.Pass, "Verify Request Access Message is Displayed");
        }


        [Test, Order(12)]//Testcase Dependent on TC27030
        public void b12_Classroom_Calendar_Cancel_Access_Request_to_Classroom_Course_27031()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            CommonSection.SearchCatalog("TC27030");
            _test.Log(Status.Info, "Click Catalog Search Button");
            Assert.IsTrue(SearchResultsPage.isSearchResultListDisplayed(""));
            _test.Log(Status.Pass, "Verify Search list is Displayed");
            SearchResultsPage.ClickCourseTitle("TC27030");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isCancelRequestButtonDisplayed());
            _test.Log(Status.Pass, "Verify Cancel Request Button is Displayed");
            ContentDetailsPage.ClickCancelRequest();
            _test.Log(Status.Info, "Click Cancel Request Button");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessButtonDisplayed());
            _test.Log(Status.Pass, "Verify Requset Access Button is Displayed");
            Assert.IsTrue(Driver.comparePartialString(" Your request for access approval was cancelled.", ContentDetailsPage.getCancelRequestMessage()));
            _test.Log(Status.Pass, "Verify Cancel Request Message is Displayed");

        }

        //[Test, Order(13)]//Testcase Dependent on TC27030
        //public void b13_Classroom1_Calendar_Cancel_Access_Request_to_Classroom_Course_27031()
        //{
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33230");
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
        //    // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SelectWaitListasYes();
        //    _test.Log(Status.Info, "Click Waitlist as Yes");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("ak_learner");
        //    //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "User Enrolled into select course successfully ");
        //    CommonSection.Logout();
        //    _test.Log(Status.Pass, "Admin user logged out successfully");


        //    LoginPage.LoginAs("ak_learner").WithPassword("").Login();
        //    _test.Log(Status.Pass, "Login as a Learner");
        //    CommonSection.Learner.CurrentTraining();
        //    CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33230" + '"');
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33230");

        //    Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC33230"));
        //    _test.Log(Status.Pass, "Enrolled classroom course is displaying");

        //}

        [Test, Order(13)]
        public void b13_View_Surveys_Associated_to_Classroom_Course_27142()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27142");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "verify Success Message");
            ContentDetailsPage.ManageSurveys();//3 lines missing
            _test.Log(Status.Info, "Click on manage Survey");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add new Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on manage enrollment button");
            // EnrollmentPage.ClickEnrollButton();
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("Site Administrator");
            _test.Log(Status.Info, "Enroll site Administrator");
            EnrollmentPage.ClickContentTab();
            _test.Log(Status.Info, "Click on content Tab");
            ContentPage.ClickAddContent("General");
            _test.Log(Status.Info, "Add a general Course");
            ContentPage.ContentTab.AvailabletoLearner("Yes, when learner enrolls");
            _test.Log(Status.Info, "Select Available To Learner as 'Yes, when learner enrolls'");
            ContentPage.ClickViewAslearner();
            _test.Log(Status.Info, "Click on View As Leaner");
            ContentDetailsPage.CourseMaterials.ClickContentButton();
            _test.Log(Status.Info, "Click on Content Button");
            Assert.IsTrue(ContentDetailsPage.isSurveyDisplayed());
            _test.Log(Status.Pass, "Verify Survey is Displayed");
            Assert.IsTrue(ContentDetailsPage.Surveys.isSurveyTitleDisplayed());
            _test.Log(Status.Pass, "Verify Survey Title is Displayed");
            Assert.IsTrue(ContentDetailsPage.Surveys.isSurveyProgressStatusDisplayed());
            _test.Log(Status.Pass, "Verify Survey Progress Status is Displayed");
            Assert.IsTrue((Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getSurveysMessage())));
            _test.Log(Status.Pass, "Verify Succees message is Displayed");

        }

        [Test, Order(14)]
        public void b14_Equivalent_Items_to_an_Classroom_Course_27166()
        {
            // CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27166");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click on Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencies();
            _test.Log(Status.Info, "Click on Edit Equivalencies");
            AddEquivalenciesPage.Search("general");
            _test.Log(Status.Info, "Search for a genaral course");
            AddEquivalenciesPage.SelectRecord();
            _test.Log(Status.Info, "Select a record");
            AddEquivalenciesPage.ClickAddButton();
            _test.Log(Status.Info, "Click on Add Button");
            EquivalenciesPage.ClickViewAsLearner();
            _test.Log(Status.Info, "Click on View as Learner");
            Assert.IsTrue(ContentDetailsPage.isEquivalenciesDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies table is Displayed");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.isTitleDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies Title is Displayed");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.isProgressStatusDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies Progress status is Displayed");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.isCostDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies Cost is Displayed");

        }


        [Test, Order(15)]
        public void b15_View_Surveys_Associated_to_Classroom_Section_27143()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27142");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on manage enrollment button");
            // EnrollmentPage.ClickEnrollButton();
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("Site Administrator");
            _test.Log(Status.Info, "Enroll site Administrator");
            EnrollmentPage.ClickContentTab();
            _test.Log(Status.Info, "Click on content Tab");
            ContentPage.ClickAddContent("General");
            _test.Log(Status.Info, "Add a general Course");
            ContentPage.ContentTab.AvailabletoLearner("Yes, when learner enrolls");
            _test.Log(Status.Info, "Select Available To Learner as 'Yes, when learner enrolls'");
            ContentPage.ClickSectionDetailsTab();
            _test.Log(Status.Info, "Click on section Details Page");
            SectionDetailsPage.ManageSurveys();
            _test.Log(Status.Info, "Manage Survey");
            ContentPage.ClickViewAslearner();
            _test.Log(Status.Info, "Click on View As Learner");
            ContentDetailsPage.CourseMaterials.ClickContentButton();
            _test.Log(Status.Info, "Click on Content ");
            Assert.IsTrue(ContentDetailsPage.isSurveyDisplayed());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            Assert.IsTrue(ContentDetailsPage.Surveys.isSurveyTitleDisplayed());
            _test.Log(Status.Pass, "Verify Survey Title is Displayed");
            Assert.IsTrue(ContentDetailsPage.Surveys.isSurveyProgressStatusDisplayed());
            _test.Log(Status.Pass, "Verify Survey Progress status is Displayed");
            Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getSurveysMessage()));
            _test.Log(Status.Pass, "Verify Success message is Displayed");

        }


        [Test, Order(16)]
        public void b16_Bundles_Containing_a_Classroom_Course_27192()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Verify Survey Progress status is Displayed");
            BundlesPage.EnterTitle("Bundle" + Meridian_Common.globalnum + "TC27192");
            _test.Log(Status.Info, "Create bundle course");
            BundlesPage.BundleType("Content Bundle");
            _test.Log(Status.Info, "Select Bundle Type");
            BundlesPage.BundleCostType();
            _test.Log(Status.Info, "Select Bundle Type");
            BundlesPage.ClickCreate();
            _test.Log(Status.Info, "Click on Create Bundle");
            BundlesPage.addContentIntoBundle("Classroom");
            _test.Log(Status.Info, "Add Content in Bundle");
            //Assert.IsTrue((Driver.comparePartialString(" The item was created.", ContentDetailsPage.getBundleSuccessMessage())));
            BundlesPage.checkIn();
            _test.Log(Status.Info, "Click on CheckIn Button");
            CommonSection.SearchCatalog("Bundle" + Meridian_Common.globalnum + "TC27192");
            _test.Log(Status.Info, "Make a Search of Bundle course");
            SearchResultsPage.ClickFirstCourseTitle("");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isBundlesCostTypeDisplayed());
            _test.Log(Status.Pass, "Verify Bundle Cost Type is Displayed");
            ContentDetailsPage.ClickOnContent();
            _test.Log(Status.Info, "Click on Content");
            Assert.IsTrue(ContentDetailsPage.isSuggestedBundlesDisplayed());
            _test.Log(Status.Pass, "Verify Suggested Bundle is Displayed");
            Assert.IsTrue(ContentDetailsPage.isBundlesTitleDisplayed());
            _test.Log(Status.Pass, "Verify Bundle Title is Displayed");
            Assert.IsTrue(ContentDetailsPage.isBundlesCostDisplayed());
            _test.Log(Status.Pass, "Verify bundle Cost is Displayed");

        }

        [Test, Order(17)]
        public void b17_Certifications_Containing_a_Classroom_Course_27208()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click on Certification");
            CertificationPage.FillTitle("Certification" + Meridian_Common.globalnum + "TC27208");
            _test.Log(Status.Info, "Create a Certification course");
            CertificationPage.SelectDropDown.CompletionCriteriaAs("Content is completed in ANY order (Non-Linear) (Non-Linear)");
            _test.Log(Status.Info, "Select Completion Criteria ");
            CertificationPage.Radiobutton.SelectCertificationexpireAs("No");
            _test.Log(Status.Info, "Select Certification expiry");
            CertificationPage.Radiobutton.IncludePastContentCompletionAs("No");
            _test.Log(Status.Info, "Select option Includes Past Content Completion");
            CertificationPage.Radiobutton.SelectAllowReCertificationAs("Yes");
            _test.Log(Status.Info, "Select Allow Re-Certification");
            CertificationPage.Radiobutton.CertificationCostTypeAs("");
            _test.Log(Status.Info, "Select Certification Cost Type");
            CertificationPage.CreateCertification();
            _test.Log(Status.Info, "Click on Create Button");
            //CertificationPage.VerifySuccessMessageText("The item was created.");
            CertificationPage.AddContentInCertification("AddingWaitlistMembers_Bug");
            _test.Log(Status.Info, "Add Content in Certification");
            CertificationPage.CheckIn();
            _test.Log(Status.Info, "Click on CheckIn");
            CommonSection.SearchCatalog("Certification" + Meridian_Common.globalnum + "TC27208");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickFirstCourseTitle("");
            _test.Log(Status.Info, "Click on Course title");
            Assert.IsTrue((Driver.comparePartialString("You do not have a certification status for this certification.", ContentDetailsPage.getInformativeMessage())));
            _test.Log(Status.Pass, "Verify information is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationTypeDisplayed());
            _test.Log(Status.Pass, "Verify Certification Type is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationCostTypeDisplayed());
            _test.Log(Status.Pass, "Verify Certification Cost Type is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationPeriodDisplayed());
            _test.Log(Status.Pass, "Verify Certification Period is Displayed");
            Assert.IsTrue(ContentDetailsPage.isAccessItemButtonDisplayed());
            _test.Log(Status.Pass, "Verify Access Button is Displayed");
            Assert.IsTrue(ContentDetailsPage.isObjectivesBlockDisplayed());
            _test.Log(Status.Pass, "Verify Objective Block is Displayed");
            Assert.IsTrue(ContentDetailsPage.isAlternateOptionsBlockDisplayed());
            _test.Log(Status.Pass, "Verify Alternate Option Block is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationContentBlockDisplayed());
            _test.Log(Status.Pass, "Verify Certification Content Block is Displayed");
            ContentDetailsPage.ClickAccessItem();
            _test.Log(Status.Info, "Click on Access Item");
            Assert.IsTrue((Driver.comparePartialString(" You first accessed this item on 1/25/2019. ", ContentDetailsPage.getAccessDateMessage())));
            _test.Log(Status.Pass, "Verify Certification Content Block is Displayed");
            ContentDetailsPage.ClickCertificationClassroom();
            _test.Log(Status.Pass, "click on Certification Classroom");
            Assert.IsTrue((Driver.comparePartialString("You are enrolled in a current section for this classroom course.", ContentDetailsPage.getCertificationEnrolledMessage())));
            _test.Log(Status.Pass, "Verify Information is Displayed");
            Assert.IsTrue(Driver.isSuggestedCertificationDisplayed());
            _test.Log(Status.Pass, "Verify Suggested Certification is displayed");
            Assert.IsTrue(Driver.SuggestedCertifications.isCertificationTitleDisplayed());
            _test.Log(Status.Pass, "Verify Certification Title is Displayed");
            Assert.IsTrue(Driver.SuggestedCertifications.isCertificationCostDisplayed());
            _test.Log(Status.Pass, "Verify Certification Cost is Displayed");

        }


        [Test, Order(18)]
        public void b18_Classroom_Calendar_View_Prerequisities_to_Classroom_27035()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");



            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27107CHILD");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");


            SectionsPage.CourseTab();
            AdminContentDetailsPage.AddPrequisites("general");

            // Assert.IsTrue(Driver.comparePartialString(" You have one or more prerequisites to complete before you can take or access this item. If you have previously completed the item," +
            // " then you may not have completed it in the allotted time or did not achieve the required score.", ContentDetailsPage.VerifyPrerequisiteMessage()));
            _test.Log(Status.Pass, "Verify Prerequisite Message");
            Assert.IsTrue(ContentDetailsPage.isprerequisitetableDisplayed());
            _test.Log(Status.Pass, "Verify Prerequisite Table is Displayed");





            //CommonSection.SearchCatalog(classroomcoursetitle + "TC27107PARENT");
            //_test.Log(Status.Info, "Click Catalog Search Button");
            //SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27107PARENT");
            //_test.Log(Status.Info, "Click on Course Title");
            //ContentDetailsPage.ClickEditContent();
            //ContentDetailsPage.CourseTab.ClickEditPrerequisite();
            //PrerequisitesPage.ClickAddPrerequisites();
            //AddPrerequisitesPage.SearchFor("ChildClassroom");

            //PrerequisitesPage.ClickSave();


            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout of the Site Admin Account");


            //LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            //_test.Log(Status.Info, "Login with Learner's Account");
            //CommonSection.SearchCatalog(classroomcoursetitle + "TC27107CHILD");
            //_test.Log(Status.Info, "Click Catalog Search Button");
            //SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27107CHILD");
            //_test.Log(Status.Info, "Click on Course Title");
            //Assert.IsTrue(Driver.comparePartialString(" You have one or more prerequisites to complete before you can take or access this item. If you have previously completed the item," +
            // " then you may not have completed it in the allotted time or did not achieve the required score.", ContentDetailsPage.VerifyPrerequisiteMessage()));
            //_test.Log(Status.Pass, "Verify Prerequisite Message");
            //Assert.IsTrue(ContentDetailsPage.isprerequisitetableDisplayed());
            //_test.Log(Status.Pass, "Verify Prerequisite Table is Displayed");
        }
        [Test, Order(19)]
        public void b19_Classroom_Calendar_Take_Classroom_Course_Related_Surveys_27033()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27142");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");

            SectionsPage.ClickManageEnrollmentButton();
            // EnrollmentPage.ClickEnrollButton();
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("Site Administrator");
            EnrollmentPage.ClickContentTab();
            ContentPage.ClickAddContent("General");
            ContentPage.ContentTab.AvailabletoLearner("Yes, when learner enrolls");
            ContentPage.ClickSectionDetailsTab();
            SectionDetailsPage.ManageSurveys();
            ContentPage.ClickViewAslearner();
            ContentDetailsPage.CourseMaterials.ClickContentButton();
            Assert.IsTrue(ContentDetailsPage.isSurveyDisplayed());
            Assert.IsTrue(ContentDetailsPage.Surveys.isSurveyTitleDisplayed());
            Assert.IsTrue(ContentDetailsPage.Surveys.isSurveyProgressStatusDisplayed());
            Assert.IsTrue((Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getSurveysMessage())));
        }
        [Test, Order(20)]
        public void b20_Curriculums_Containing_a_Classroom_Course_27151()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27151");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");


            CommonSection.CreateLink.ClickCurriculumns();
            CurriculumsPage.FillTitle(Meridian_Common.globalnum + "TC27151");
            CurriculumsPage.SelectCollaborationSpaceOption("No");
            CurriculumsPage.CreateCurriculum();
            ContentDetailsPage.EditCurriculumsContent();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.CurriculumContentFrame_SelectType("Optional");
            CurriculumContentPage.CurriculumContentFrame_Title_Text("TC27151");
            CurriculumContentPage.CurriculumContentFrame_ClickSave();
            CurriculumContentPage.ClickAddTrainingActivities("");
            AddTrainingActivitiesPage.Search(classroomcoursetitle + "TC27151");
            AddTrainingActivitiesPage.ClickAddButton();
            AddTrainingActivitiesPage.ClickCheckInButton();
            AddTrainingActivitiesPage.DropdownToggle.ViewAsLearner();
            ContentDetailsPage.isCurriculumBlockDisplayed();
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue((Driver.comparePartialString(" You are enrolled in the curriculum.", ContentDetailsPage.getCurriculumEnrollmentSuccessMessage())));
            ContentDetailsPage.CurriculumAccessItem();

            ContentDetailsPage.CurriculumBlocks.ClickContent();
            Assert.IsTrue(ContentDetailsPage.isCurriculumDisplayed());
            Assert.IsTrue(ContentDetailsPage.isCurriculumtitleDisplayed());
            Assert.IsTrue(ContentDetailsPage.isCurriculumCostDisplayed());



        }

        [Test, Order(21)]
        public void b21_View_Post_Access_Items_to_Classroom_27107()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27107PARENT");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27107CHILD");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");

            CommonSection.SearchCatalog(classroomcoursetitle + "TC27107PARENT");
            _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27107PARENT");
            _test.Log(Status.Info, "Click on Course Title");
            ContentDetailsPage.ClickEditContent();
            ContentDetailsPage.CourseTab.ClickEditPrerequisite();
            PrerequisitesPage.ClickAddPrerequisites();
            AddPrerequisitesPage.SearchFor("ChildClassroom");
            PrerequisitesPage.ClickSave();
            PrerequisitesPage.ClickViewAsLearner();
            Assert.IsTrue(ContentDetailsPage.isprerequisitetableDisplayed());
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteTitleDisplayed());
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteCostDisplayed());
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteStatusDisplayed());
            ContentDetailsPage.ClickPrerequisiteTitle();
            Assert.IsTrue(ContentDetailsPage.isOtherAvailableTraining());
        }

        [Test, Order(22)]
        public void b22_Add_Classroom_to_Cart_26841()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC26841");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add Cost to classroom");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "click on Edit Content");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");

            ContentPage.ClickViewAslearner();
            ContentDetailsPage.ClickAddtoCart();
            Assert.IsTrue(Driver.comparePartialString("The item was added to the cart.", ContentDetailsPage.AddToCartSuccessMessage()));
        }


        [Test, Order(23)]
        public void b23_Self_Cancel_Enrollment_in_Classroom_Course_with_cost_paid_by_authorized_user_27015()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27015");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add Cost to classroom");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "click on Edit Content");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            SectionsPage.SelectViewAsLearner();
            ContentDetailsPage.ClickAddtoCart();
            CommonSection.ClickShoppingCart();
            ShoppingCartPage.Checkout();
            CheckoutPage.UseThisPaymentMethod();
            CheckoutPage.AcceptTermsandCondition();
            CheckoutPage.PlaceOrder();
            Assert.IsTrue(Driver.comparePartialString("Thank you for your order! Your order has been successfully processed. You will receive an email confirmation shortly.", OrderReceiptPage.SuccessMessage()));
            OrderReceiptPage.ViewOrder();
            Assert.IsTrue(OrderPage.isPurchasedCotentDisplayed());
            OrderPage.Click_Purchased_Content(classroomcoursetitle + "TC27015" + " - " + "Section1");
            ContentDetailsPage.ClickCancelEnrollment();
            Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());
        }



        [Test, Order(24)]
        public void b24_Self_Cancel_Enrollment_in_Classroom_Course_with_cost_paid_by_end_user_27016()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC27016");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add Cost to classroom");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "click on Edit Content");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(5);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");




            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");


            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC27016");
            _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC27016");
            _test.Log(Status.Info, "Click on Course Title");
            ContentDetailsPage.ClickAddtoCart();
            Assert.IsTrue(Driver.comparePartialString("The item was added to the cart.", ContentDetailsPage.AddToCartSuccessMessage()));

            //CommonSection.ClickShoppingCart();
            //ShoppingcartPage.Ckeckout();
            //CheckoutPage.UseThisPaymentMethod();
            //CheckoutPage.AcceptTermsandCondition();
            //CheckoutPage.PlaceOrder();
            //Assert.IsTrue(Driver.comparePartialString("Thank you for your order! Your order has been successfully processed. You will receive an email confirmation shortly.", OrderReceiptPage.SuccessMessage()));
            //OrderReceiptPage.ViewOrder();
            //Assert.IsTrue(OrderPage.isPurchasedCotentDisplayed());
            //OrderPage.Click_Purchased_Content(classroomcoursetitle + "TC27016" + " - " + "Section1");
            //ContentDetailsPage.ClickCancelEnrollment();
            //Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());

        }
        [Test, Order(25)]
        public void b25_Unenrolled_User_enters_Completion_Code_for_Current_Section_and_Future_sections_28074()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28074");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(1);
            //ManageClassroomCoursePage.CreateSection.SectionEndDate(-1);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");
            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code");
            SectionDetailsPage.ClickViewAsLearner();
            _test.Log(Status.Info, "Click on View as learner");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString("You can only enter a completion code for a course section that has ended.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");
        }


        [Test, Order(26)]
        public void b26_Unenrolled_User_enters_Completion_Code_for_Past_Sections_28075()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28074");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));

            _test.Log(Status.Info, "Verify Success message is Displayed");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionEndDate(3);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickSearchSection();
            _test.Log(Status.Info, "Click on Search Button in Sections Tab");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");

            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");

            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code ");

            SectionDetailsPage.ClickViewAsLearner();
            _test.Log(Status.Info, "Click on View as learner");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString("You completed TC28075Afreen : NewSection. This item has been added to your transcript.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");
            CommonSection.Dropdowntoggle.Transcript();
            _test.Log(Status.Info, "Click on Transcript");
            Assert.IsTrue(Driver.comparePartialString("Completed", TranscriptPage.VerifyStatus(classroomcoursetitle + "TC28074")));
            _test.Log(Status.Pass, "Verify Status as 'Çompleted'");
            TranscriptPage.ClickRequiredCourse("");
            _test.Log(Status.Info, "Click on Course title");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString(" You have already completed this course section.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");


        }

        [Test, Order(27)]
        public void b27_Enrolled_User_Enters_Completion_Code_For_Current_Section_And_Future_Sections_28077()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28077");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //           ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            _test.Log(Status.Info, "Select section start Date from calendar");
            //           ManageClassroomCoursePage.CreateSection.SectionEndDate(3);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("Site Administrator");
            _test.Log(Status.Info, "Enroll Site Administratio");
            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");

            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code ");
            SectionDetailsPage.ClickViewAsLearner();
            _test.Log(Status.Info, "Click on View as learner");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString("You can only enter a completion code for a course section that has ended.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");



        }

        [Test, Order(28)]
        public void b28_Select_credit_type_columns_in_Training_Progress_Report_33515()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            // create a credit value with name - dv_credit_type
            //   Create a General coruse with name - dv_gc2205_credit_value
            //Add credit type with value as 1 or 1 both default cretid value and dv_credit_type checkin
            // Learner complete this course then login with admin
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "Navigating to Report page ");
            ReportsConsolePage.SearchText("My Training Progress");
            _test.Log(Status.Info, "Search My Training Progress Report");
            ReportsConsolePage.ClickMyTrainingProgress();
            _test.Log(Status.Info, "Click My Training Progress Title name");
            StringAssert.AreEqualIgnoringCase("My Training Progress", MyTrainingProgressPage.verifylabel("My Training Progress"));
            _test.Log(Status.Info, "Verify Label name = My Training Progress");
            MyTrainingProgressPage.ClickSelectButton();
            _test.Log(Status.Info, "Click Select button");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "Click Run Report");
            StringAssert.AreEqualIgnoringCase("Meridian Global Reporting", MeridianGlobalReportingPage.Title);
            _test.Log(Status.Info, "Verify page label");
            MeridianGlobalReportingPage.CustomizeTableColumns("DV_Credit_Type", "Default Credit Type");//Click on gear icon Below formula button
                                                                                                       //      MeridianGlobalReportingPage.SelectColumns("DV_Credit_Type", "Default Credit Type");
            StringAssert.AreEqualIgnoringCase("dv_dc2205_credit_value", MeridianGlobalReportingPage.ContentTitle);//verify course name
            _test.Log(Status.Info, "Verify Course name");
            _test.Log(Status.Info, "Select DV_Credit_Type and Default Credit Type options");
            Assert.IsTrue(MeridianGlobalReportingPage.verifycolumn("dv_credit_type"), "dv_Credit_Type column not present");//verify colums
            Assert.IsTrue(MeridianGlobalReportingPage.verifycolumn1("Default Credit Type"), "Default Credit Type not present");//verify colums
            StringAssert.AreEqualIgnoringCase("1", MeridianGlobalReportingPage.verifycolumnvalue("1"), "Mismatch for Dv_Credit_Type_value");

            StringAssert.AreEqualIgnoringCase("1", MeridianGlobalReportingPage.verifycolumnvalue1("1"), "Mismatch for Default Credit Type");
        }

        [Test, Order(29)]
        public void b29_enrolled_User_enters_Completion_Code_for_Past_Sections_28078()
        {
            CommonSection.Logout();
            // _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28078");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionEndDate(3);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickSearchSection();
            _test.Log(Status.Info, "Click on Search Button in Sections Tab");

            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("Site Administrator");
            _test.Log(Status.Info, "Enroll Site Administratio");
            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");

            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code ");
            SectionDetailsPage.ClickViewAsLearner();
            _test.Log(Status.Info, "Click on View as learner");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString("You completed TC28075Afreen : NewSection. This item has been added to your transcript.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");
            CommonSection.Dropdowntoggle.Transcript();
            _test.Log(Status.Info, "Click on Transcript");
            Assert.IsTrue(Driver.comparePartialString("Completed", TranscriptPage.VerifyStatus(classroomcoursetitle + "TC28078")));
            _test.Log(Status.Pass, "Verify Status as 'Çompleted'");
            TranscriptPage.ClickRequiredCourse("");
            _test.Log(Status.Info, "Click on Course title");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString(" You have already completed this course section.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");



        }

        [Test, Order(20)]
        public void t_Edit_Career_path_level_from_Job_Title_page_33922()
        {
            //login with a admin
            CareersPage.CreateCareerPath(CareerPathTitle + "TC33922");
            CreateCareerPathPage.LevelsandjobtitlesTab.ClickCreateLevel(); //inside frame
            CareersPage.CreateJobTitle(JobTitle + "TC33922");
            _test.Log(Status.Info, "New Job title Created");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Navigating to Career page");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab on Career page");
            CareersPage.SearchJobtitle(JobTitle + "TC33922");
            _test.Log(Status.Info, "Search Job title as" + JobTitle + "TC33922");    //CareerPathTitle + "TC33920"
            CareersPage.ClickJobtitle(JobTitle + "TC33922");
            _test.Log(Status.Info, "Search Job title and click on it from search result");
            ManageJobTitlePage.CompetenciesTab.ClickCareerPath("None Selected");
            ManageJobTitlePage.CompetenciesTab.SearchandSelect(CareerPathTitle + "TC33922");
            ManageJobTitlePage.CompetenciesTab.clickyescheckmark();
            _test.Log(Status.Info, "Click on none selected career path from competencies tab, search TC33922 and select level 1");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            ////StringAssert.AreEqualIgnoringCase("The selected items were added.", DV_JOB_Title_RegressionPage.VerifyText(""));
            //_test.Log(Status.Pass, "Verify success message");
            StringAssert.AreEqualIgnoringCase(CareerPathTitle + "TC33922", ManageJobTitlePage.VerifyCareerpathText(CareerPathTitle + "TC33922"));
            _test.Log(Status.Info, "Verify Saved career path");
            StringAssert.AreEqualIgnoringCase("Level 1", ManageJobTitlePage.VerifyLevelText("Level 1"));
            _test.Log(Status.Info, "Verify Saved career path Level");
            //ManageJobTitlePage.ClickCareerBreadcrumb();
            CommonSection.Manage.Careerstab();
            _test.Log(Status.Info, "Navigating to Career Path Tab");
            CareersPage.CareerPathTab.SearchCareerPath(CareerPathTitle + "TC33922");
            CareersPage.CareerPathTab.ClickSearchResult(CareerPathTitle + "TC33922");
            _test.Log(Status.Info, "search and open career path");
            CreateCareerPathPage.LevelsandjobtitlesTab.ExpandLevel1();
            _test.Log(Status.Info, "Expand level 1 for this career path");
            StringAssert.AreEqualIgnoringCase(JobTitle + "TC33922", CreateCareerPathPage.LevelsandjobtitlesTab.Level.JobtitletextinsideLevel1(JobTitle + "TC33922"));
            _test.Log(Status.Info, "Verify career path name");

            CareersPage.DeleteCareerPath(CareerPathTitle + "TC33922");
            CareersPage.DeleteJobTitle(JobTitle + "TC33922");

        }
        [Test, Order(21)]
        public void u_Edit_Permissions_for_Custom_Role_create_manage_Career_Path_33579()
        {
            CommonSection.Administer.People.Roles();
            _test.Log(Status.Info, "Navigating to Roles page");
            RolesPage.SelectCreateNew.ClickGo();
            _test.Log(Status.Info, "Select create new and click on go button");
            NewRolePage.FillName(CustomRole);
            _test.Log(Status.Info, "Fill Custom role name");
            NewRolePage.FillDescription("Test");
            NewRolePage.ClickCreateButton();
            _test.Log(Status.Info, "Fill Custom role Description and click create button");
            SelectDomainPage.ClickSaveButton();
            _test.Log(Status.Info, "Click Save");
            StringAssert.AreEqualIgnoringCase("The domain selections were saved.", SelectDomainPage.GetSuccessfullMessage());
            SelectDomainPage.ClickRolesCredcrumb();
            _test.Log(Status.Info, "Click Roles Breadcrumb");
            RolesPage.SearchText(CustomRole).ClickSearchbutton();
            _test.Log(Status.Info, "Select created custom role");
            Assert.IsTrue(Driver.comparePartialString(CustomRole, RolesPage.VerifySearchText()));
            //StringAssert.AreEqualIgnoringCase("Reg_CareerPath_CustomRole", RolesPage.VerifySearchText("Reg_CareerPath_CustomRole"));
            _test.Log(Status.Info, "Verify Searched Result");
            RolesPage.SearchResult.Select("Edit Permissions");
            RolesPage.SearchResult.ClickGo();
            _test.Log(Status.Info, "Select Edit Permission for searhed role and click go button");
            StringAssert.AreEqualIgnoringCase("Career Paths", EditPermissionsPage.VerifySearchText("Career Paths"));
            _test.Log(Status.Info, "Verify Career Paths option in listing");
            StringAssert.AreEqualIgnoringCase("Create Career Path", EditPermissionsPage.VerifySearchText1("Create Career Path"));
            _test.Log(Status.Info, "Verify Create Career Path option in listing");
        }
        [Test, Order(22)]
        public void v_Test_when_user_have_Manage_permission_for_Career_Path_33580()
        {
            //Create a Learner with user name learnerdv/password
            //CommonSection.Administer.People.Roles();
            //_test.Log(Status.Info, "Navigating to Roles page");
            //RolesPage.SelectCreateNew.ClickGo();
            //_test.Log(Status.Info, "Select create new and click on go button");
            //NewRolePage.FillName(CustomRole);
            //_test.Log(Status.Info, "Fill Custom role name");
            //NewRolePage.FillDescription("Test");
            //NewRolePage.ClickCreateButton();

            //_test.Log(Status.Info, "Fill Custom role Description and click create button");
            //SelectDomainPage.ClickSaveButton();
            //_test.Log(Status.Info, "Click Save");
            //SelectDomainPage.ClickRolesCredcrumb();
            //_test.Log(Status.Info, "Click Roles Breadcrumb");

            Assert.True(true);  //this test doesnot need regular execution
                                //CommonSection.Administer.People.Roles();
                                //RolesPage.SearchText(CustomRole).ClickSearchbutton();
                                //_test.Log(Status.Info, "Select created custom role");
                                //Assert.IsTrue(Driver.comparePartialString(CustomRole, RolesPage.VerifySearchText()));
                                ////StringAssert.AreEqualIgnoringCase("Reg_CareerPath_CustomRole", RolesPage.VerifySearchText("Reg_CareerPath_CustomRole"));
                                //_test.Log(Status.Info, "Verify Searched Result");
                                //RolesPage.SearchResult.Select("Edit Users");
                                //RolesPage.SearchResult.ClickGo();
                                //// RolesPage.SearchResult.Select.EditUsers.ClickGo();
                                //_test.Log(Status.Info, "Select Edit Users for searhed role and click go button");
                                //EditUsersPage.SelectOptions.AddUserClickGo();
                                //_test.Log(Status.Info, "Select Add Users to include user in this role");
                                //AddUsersPage.SearchLearneraccountwithFirstname("reg").LastName("learner1").clicksearch();
                                //_test.Log(Status.Info, "Search user with first name and last name search and click search");
                                //StringAssert.AreEqualIgnoringCase("learner1", AddUsersPage.VerifySearchText("learner1"));
                                //_test.Log(Status.Info, "Verify User in search result");
                                //AddUsersPage.SelectSearchedUser.Clickcheckbox();
                                //AddUsersPage.SelectSearchedUser.ClickAddSelected();
                                //_test.Log(Status.Info, "add user from search result");
                                //StringAssert.AreEqualIgnoringCase("The user(s) was added.", AddUsersPage.VerifySuccessfullMessage("The user(s) was added."));
                                //_test.Log(Status.Info, "Verify Successful message of user inclusion in role");
                                //SelectDomainPage.ClickRolesCredcrumb();
                                //RolesPage.SearchText(CustomRole).ClickSearchbutton();
                                //RolesPage.SearchResult.Select("Edit Permissions");
                                //RolesPage.SearchResult.ClickGo();
                                ////RolesPage.SearchResult.Select.EditPermissions.ClickGo();
                                //_test.Log(Status.Info, "Select Edit Permission for searhed role and click go button");
                                //StringAssert.AreEqualIgnoringCase("Career Paths", EditPermissionsPage.VerifySearchText("Career Paths"));
                                //_test.Log(Status.Info, "Verify Career Paths option in listing");
                                //StringAssert.AreEqualIgnoringCase("Create Career Path", EditPermissionsPage.VerifySearchText1("Create Career Path"));
                                //_test.Log(Status.Info, "Verify Create Career Path option in listing");
                                //EditPermissionsPage.PermissionforCareerPaths.SelectAllow();
                                //_test.Log(Status.Info, "Select Allow Permission for Manage Career Path");
                                //EditPermissionsPage.PermissionforCareerPaths.SelectDeny();
                                //EditPermissionsPage.PermissionforCareerPaths.ClickSave();
                                //_test.Log(Status.Info, "Select Deny Permission for Create Career Path and click save");
                                //StringAssert.AreEqualIgnoringCase("The selection(s) was saved.", AddUsersPage.VerifySuccessfullMessage("The selection(s) was saved."));
                                //_test.Log(Status.Info, "Verify Success Message");
                                //CommonSection.Logout();
                                ////logout with addmin
                                ////Login with learner
                                //LoginPage.LoginAs("reglearner1").WithPassword("").Login();
                                //CommonSection.Manage.ProfessionalDevelopment();
                                //_test.Log(Status.Info, "Navigating to Career page");
                                //StringAssert.AreEqualIgnoringCase("Define job responsibilities and create competencies to set training and proficiency targets.", CareersPage.VerifySearchinstructionText("Define job responsibilities and create competencies to set training and proficiency targets."));
                                //_test.Log(Status.Info, "Verify text on career page");
                                //CareersPage.ClickAnyrecordfromCareerPathListing();
                                //_test.Log(Status.Info, "Open any career path from listing");
                                //CreateCareerPathPage.EditCareerPathName(CareerPathTitle + '1');
                                ////CareerPathPage.EditTitlename.clear.edit("reg_updatedCareerPath").Save;
                                //_test.Log(Status.Info, "Rename title name of career path and save it");
                                //CreateCareerPathPage.ClickCareerBreadcrumb();
                                //// CareerPathPage.ClickCareerBreadcrumb();
                                //_test.Log(Status.Info, "click on career breadcrumb ");
                                //CareersPage.SearchCareerPath(CareerPathTitle + '1');
                                ////CareerPathTab.SearchCareerPath("reg_updatedCareerPath");
                                //_test.Log(Status.Info, "search created career path");
                                //StringAssert.AreEqualIgnoringCase(CareerPathTitle + '1', CareersPage.CareerPathTab.VerifySearchText(CareerPathTitle + '1'));
                                //_test.Log(Status.Info, "Verify career path name");

        }

        [Test, Order(23)]
        public void w_Test_when_user_have_Create_permission_for_Career_Path_33581()
        {

            Assert.True(true);  //this test doesnot need regular execution
                                //CommonSection.Logout();
                                //LoginPage.LoginAs("").WithPassword("").Login();
                                ////Create a Learner with user name learnerdv/password
                                //CommonSection.Administer.People.Roles();
                                //_test.Log(Status.Info, "Navigating to Roles page");

            //RolesPage.SearchText(CustomRole).ClickSearchbutton();
            //_test.Log(Status.Info, "Select created custom role");
            //Assert.IsTrue(Driver.comparePartialString(CustomRole, RolesPage.VerifySearchText()));
            ////StringAssert.AreEqualIgnoringCase("Reg_CareerPath_CustomRole", RolesPage.VerifySearchText("Reg_CareerPath_CustomRole"));
            //_test.Log(Status.Info, "Verify Searched Result");

            ////_test.Log(Status.Info, "Verify Successful message of user inclusion in role");
            //RolesPage.SearchResult.Select("Edit Permissions");
            //RolesPage.SearchResult.ClickGo();
            //_test.Log(Status.Info, "Select Edit Permission for searhed role and click go button");
            //StringAssert.AreEqualIgnoringCase("Career Paths", EditPermissionsPage.VerifySearchText("Career Paths"));
            //_test.Log(Status.Info, "Verify Career Paths option in listing");
            //StringAssert.AreEqualIgnoringCase("Create Career Path", EditPermissionsPage.VerifySearchText1("Create Career Path"));
            //_test.Log(Status.Info, "Verify Create Career Path option in listing");
            //EditPermissionsPage.PermissionforCareerPaths.SelectAllow();
            //_test.Log(Status.Info, "Select Allow Permission for Manage Career Path");
            //EditPermissionsPage.PermissionforCareerPaths.SelectDeny();
            //EditPermissionsPage.PermissionforCareerPaths.ClickSave();
            //_test.Log(Status.Info, "Select Allow Permission for Create Career Path and click save");
            //StringAssert.AreEqualIgnoringCase("The selection(s) was saved.", AddUsersPage.VerifySuccessfullMessage("The selection(s) was saved."));
            //_test.Log(Status.Info, "Verify Success Message");
            //CommonSection.Logout();
            ////logout with addmin
            ////Login with learner
            //LoginPage.LoginAs("reglearner1").WithPassword("").Login();
            //CommonSection.Manage.ProfessionalDevelopment();
            //_test.Log(Status.Info, "Navigating to Career page");
            //StringAssert.AreEqualIgnoringCase("Define job responsibilities and create competencies to set training and proficiency targets.", CareersPage.VerifySearchinstructionText("Define job responsibilities and create competencies to set training and proficiency targets."));
            ////StringAssert.AreEqualIgnoringCase("Define job responsibilities and create competencies to set training and proficiency targets.", CareersPage.VerifyInstructionText("Define job responsibilities and create competencies to set training and proficiency targets."));
            //_test.Log(Status.Info, "Verify text on career page");

            //CareersPage.CareerPathTab.CreateCareerPath();
            //_test.Log(Status.Info, "Click Create Career Path");
            //CreateCareerPathPage.EditCareerPathName(CareerPathTitle + '2');
            //_test.Log(Status.Info, "Fill career path name");
            //CreateCareerPathPage.ClickCareerBreadcrumb();
            //_test.Log(Status.Info, "click on career breadcrumb ");
            //CareersPage.CareerPathTab.SearchCareerPath(CareerPathTitle + '2');
            //_test.Log(Status.Info, "search created career path");
            //StringAssert.AreEqualIgnoringCase(CareerPathTitle + '2', CareersPage.CareerPathTab.VerifySearchText(CareerPathTitle + '2'));
            //_test.Log(Status.Info, "Verify career path name");
            //StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            //_test.Log(Status.Info, "Verify career path status");
            //CareersPage.CareerPathTab.ClickSearchResult(CareerPathTitle + '2');
            //_test.Log(Status.Info, "click career path name");
            //CreateCareerPathPage.EditCareerPathName(CareerPathTitle + '3');
            ////CareerPathPage.EditTitlename.clear.edit("reg_updatedCareerPath").Save;
            //_test.Log(Status.Info, "Rename title name of career path and save it");
            //CreateCareerPathPage.ClickCareerBreadcrumb();
            //_test.Log(Status.Info, "click on career breadcrumb ");
            //CareersPage.SearchCareerPath(CareerPathTitle + '3');
            //_test.Log(Status.Info, "search created career path");
            //StringAssert.AreEqualIgnoringCase(CareerPathTitle + '3', CareersPage.CareerPathTab.VerifySearchText(CareerPathTitle + '3'));
            //_test.Log(Status.Info, "Verify career path name");

        }
        [Test, Order(1)]
        public void While_searching_for_Classroom_course_Learner_views_credit_type_and_credit_type_value_33875()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a classroom course i.e. DV_Class_CV_0507, and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            #region  Pre-Requisite
            CreditTypesPage.inactivepreviouscredittype();
            CommonSection.Administer.ContentManagement.CreditType();
            CreditTypesPage.ClickCreatenew();
            NewCreditTypePage.TitleAs(CreditTypeTitle).DescriptionAs("Test for Automation").Create();
            NewCreditTypePage.AssignedUsers("Add Users").SearchText("site").SelectAdminuser("siteadmin").Add();
            CommonSection.CreateLink.ClassroomCourse();
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "credittype");
            ClassroomCourseDetailsPage.CLickManageCredit();
            NewCreditTypePage.ClickAddCredit();
            NewCreditTypePage.AddCreditValuetoCreditType();

            CommonSection.CreateLink.Curriculam();
            CurriculumsPage.TitleAs(curriculamtitle + "CreditType").Create();
            ClassroomCourseDetailsPage.CLickManageCredit();
            NewCreditTypePage.ClickAddCredit();
            NewCreditTypePage.AddCreditValuetoCreditType();

            CommonSection.CreateLink.GeneralCourse();
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "credittype", "Automation Test");
            ClassroomCourseDetailsPage.CLickManageCredit();
            NewCreditTypePage.ClickAddCredit();
            NewCreditTypePage.AddCreditValuetoCreditType();



            // CommonSection.Logout();

            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "credittype" + '"');
            _test.Log(Status.Info, "Search Classroom course DV_Class_CV_0507 from catalog search");
            StringAssert.AreEqualIgnoringCase(classroomcoursetitle + "credittype", SearchResultsPage.VerifyCourseTitleText(classroomcoursetitle + "credittype"));
            _test.Log(Status.Info, "Verify Classroom course name");
            StringAssert.AreEqualIgnoringCase(CreditTypeTitle + " (5)", SearchResultsPage.VerifyTextCredits(CreditTypeTitle + " (5)"));
            _test.Log(Status.Info, "Verify Credit type value and Credit Type");

        }

        [Test, Order(2)]
        public void Learner_views_credit_type_help_text_from_Classroom_Course_Details_33805()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a classroom course i.e. DV_Class_CV_0507, and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner

            CommonSection.SearchCatalog('"' + classroomcoursetitle + "credittype" + '"');
            _test.Log(Status.Info, "Search and open Classroom course DV_Class_CV_0507 from catalog search");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "credittype");
            // CatalogSearch.SearchCourse("DV_Class_CV_0507").clicktitle(); 
            _test.Log(Status.Info, "Click on Classroom course DV_Class_CV_0507 title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Info, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Info, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Info, "Verify Credit type text info that user is not eligible for ");
        }


        [Test, Order(3)]
        public void Learner_views_credit_type_help_text_from_Curriculum_Details_33810()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a Curriculum course i.e. DV_Curri_CV_0507, and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner

            CommonSection.SearchCatalog('"' + curriculamtitle + "CreditType" + '"');
            _test.Log(Status.Info, "Search and open course DV_Curri_CV_0507 from catalog search");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "CreditType");
            _test.Log(Status.Info, "Click on course DV_Curri_CV_0507 title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Info, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Info, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Info, "Verify Credit type text info that user is not eligible for ");
        }

        [Test, Order(4)]
        public void While_searching_for_Curriculum_Learner_views_credit_type_and_credit_type_value_33876()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a Curriculum course i.e. DV_Curri_CV_0507,and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.SearchCatalog('"' + curriculamtitle + "CreditType" + '"');
            _test.Log(Status.Info, "Search Classroom course DV_Curri_CV_0507 from catalog search");
            StringAssert.AreEqualIgnoringCase(curriculamtitle + "CreditType", SearchResultsPage.VerifyCourseTitleText(curriculamtitle + "CreditType"));
            _test.Log(Status.Info, "Verify Curriculum name");
            StringAssert.AreEqualIgnoringCase(CreditTypeTitle + " (5)", SearchResultsPage.VerifyTextCredits(CreditTypeTitle + " (5)"));
            _test.Log(Status.Info, "Verify Credit type value and Credit Type");
        }
        [Test, Order(9)]
        public void Learner_views_credit_type_help_text_from_Scorm_Course_Details_33809()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a sorm course i.e. DV_Scorm_CV_0507 , and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner
            CommonSection.SearchCatalog('"' + "SCORM-TEST-Somnath1" + '"');
            _test.Log(Status.Info, "Search and open Scorm course SCORM-TEST-Somnath1  from catalog search");
            SearchResultsPage.ClickCourseTitle("SCORM-TEST-Somnath1");
            _test.Log(Status.Info, "Click on course SCORM-TEST-Somnath1 title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Pass, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Pass, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Pass, "Verify Credit type text info that user is not eligible for ");
        }



        [Test, Order(10)]
        public void While_searching_for_Scorm_course_Learner_views_credit_type_and_credit_type_value_33879()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a sorm course i.e. DV_Scorm_CV_0507 , and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.SearchCatalog('"' + "SCORM-TEST-Somnath1" + '"');
            _test.Log(Status.Info, "Search Scorm course SCORM-TEST-Somnath1 from catalog search");
            StringAssert.AreEqualIgnoringCase("SCORM-TEST-Somnath1", SearchResultsPage.VerifyCourseTitleText("SCORM-TEST-Somnath1"));
            _test.Log(Status.Pass, "Verify Classroom course name");
            StringAssert.AreEqualIgnoringCase("dv_credit_type (5)", SearchResultsPage.VerifyTextCredits("dv_credit_type (5)"));
            _test.Log(Status.Pass, "Verify Credit type value and Credit Type");

        }
        [Test, Order(9), Category("P1")]
        public void a09_Edit_localized_Job_Title_32187()
        {
            CareersPage.CreateJobTitle(JobTitle + "TC32187");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "TC32187");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC32187"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle(JobTitle + "TC32187");
            _test.Log(Status.Info, "Click on Searched Job Title");
            AdminContentDetailsPage.EditLocalization("edittitle", "Descriptionedit", "jobcodedit", "keywordsedit", "Arabic");
            _test.Log(Status.Info, "Edit Descriptionn Job code, Key Word on edit Job Title page and Save");
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            AdminContentDetailsPage.SelectLocalization("Arabic");
            _test.Log(Status.Info, " Set Localization DropDown as Arabic");
            // StringAssert.AreEqualIgnoringCase("Add Localization", ContentDetailsPage.Frame(), ("Error message is different"));

            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckJobTitle("edittitle"));
            _test.Log(Status.Pass, "Verify Job Tilte After edit");
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckJobCode("jobcodedit"));
            _test.Log(Status.Pass, "Verify job Title Job Code");
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckDescriptionValue("Descriptionedit"));
            _test.Log(Status.Pass, "Verify Job Title Description");
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckKeywordsValue("keywordsedit"));
            _test.Log(Status.Pass, "Verify Job Title Description");

            //Deleted Job title After test complete
            CareersPage.DeleteJobTitle(JobTitle + "TC32187");
            _test.Log(Status.Info, "Job Title Deleted");
            StringAssert.AreEqualIgnoringCase("No matching records found", CareersPage.NoMatchingJobTitleFound("No matching records found"));
            _test.Log(Status.Pass, "Verify No matching records found message display after job title deleted");

        }
        [Test, Order(10), Category("P1")]
        public void a10_localized_Job_Title_32185()
        {
            CareersPage.CreateJobTitle(JobTitle + "TC32185");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "TC32185");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC32185"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle(JobTitle + "TC32185");
            _test.Log(Status.Info, "Click on Searched Job Title");
            AdminContentDetailsPage.SelectAddLocalization("French");
            _test.Log(Status.Info, "Set Localization DropDown as French");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");

            //Deleted Job title After test complete
            CareersPage.DeleteJobTitle(JobTitle + "TC32185");
            _test.Log(Status.Info, "Job Title Deleted");
            StringAssert.AreEqualIgnoringCase("No matching records found", CareersPage.NoMatchingJobTitleFound("No matching records found"));
            _test.Log(Status.Pass, "Verify No matching records found message display after job title deleted");
        }
        [Test, Order(11), Category("P1")]
        public void a11_View_competency_column_in_job_Title_list_32181()

        {
            // Prerequisite - Competencies are created and added to JobTitles
            //login with siteadmin/password

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            StringAssert.AreEqualIgnoringCase("Job titles define a position and its responsibilities. Assign competencies to set training and proficiency targets.", CareersPage.JobTitlesTab.GetMessage(), "Error message is different");//verify Text 
            _test.Log(Status.Pass, "Verify Infor text of Job Title Tab");
            CareersPage.SearchJobtitle("JobTitle21");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle("JobTitle21"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle("JobTitle21");
            _test.Log(Status.Info, "Click on Searched Job Title");
            Assert.IsTrue(CareersPage.sortingcompetencycolumn_verifysortingascecorder());//verify sorting desc order
            _test.Log(Status.Pass, "Verify Sorting order of Competency associated with this Job Title");
            //logout
        }
        [Test, Order(8), Category("P1")]
        public void a08_Job_title_info_icon_22215()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Pass, "Open Career Menu");
            CareersPage.EditJobTitleName(JobTitle + "TC22125");
            _test.Log(Status.Info, "Clik on Create New Job Title, Edit Job Title name, Click Save");
            CommonSection.Avatar.Account();
            AccountPage.ClickProfiletab();
            AccountPage.Click_EditWorkInformation();
            AccountPage.WorkInformationFrame.AddJobTitle(JobTitle + "TC22125");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Pass, "Open Career Menu");

            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Pass, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "TC22125");
            _test.Log(Status.Pass, "Search above Jobtitle");
            CareersPage.ClickinfoIcon("i");
            _test.Log(Status.Pass, "Click on info icon for the searched Job Title");
            Assert.IsTrue(InformationPage.JobTitleName(JobTitle + "TC22125"));
            // ManageJobTitlePage.JobDetailsTab.AddDescription("Reg_Description");
            InformationPage.ClickViewUsersTab();
            _test.Log(Status.Pass, "Click on View users Tab on Info Popup");
            Assert.NotZero(InformationPage.ViewUsersTab.CountRecords);
            _test.Log(Status.Pass, "Verify User Record");
            Driver.Instance.SelectWindowClose();
            _test.Log(Status.Pass, "Close opened Popup");
            //Close This Page
        }




        [Test, Order(12), Category("P1")]
        public void a12_User_Edit_a_Job_title_31501()
        {
            CareersPage.CreateJobTitle(JobTitle + "TC31501");

            //CommonSection.Manage.ProfessionalDevelopment();
            //_test.Log(Status.Info, "Open Career Menu");
            //CareersPage.ClickJobTitleTab();
            //_test.Log(Status.Info, "Open Job Title tab");
            //CareersPage.SearchJobtitle(JobTitle + "TC31501");
            //_test.Log(Status.Info, "Search Job Title");
            //Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC31501"));
            //_test.Log(Status.Pass, "Verify Job Tile is searched");
            //CareersPage.ClickJobtitle(JobTitle + "TC31501");
            //_test.Log(Status.Info, "Clicked on Searched Job title");
            ManageJobTitlePage.ClickJobDetailsTab();
            _test.Log(Status.Info, "Clicked on Job Details tab.");
            ManageJobTitlePage.JobDetailsTab.AddDescription("Reg_Description");
            _test.Log(Status.Info, "Clicked Add Description link, fill Details and click on Submit button.");

            StringAssert.AreEqualIgnoringCase("Reg_Description", ManageJobTitlePage.GetDescriptionLink(), "Description value does not match");
            ManageJobTitlePage.JobDetailsTab.AddKeywords("Reg_Keywords");
            _test.Log(Status.Pass, "Clicked Add Kew Word link, fill Details and click on Submit button.");

            StringAssert.AreEqualIgnoringCase("Reg_Keywords", ManageJobTitlePage.GetKeywordLink(), "Keywords value does not match");
            ManageJobTitlePage.JobDetailsTab.JobCodeLink("Reg_JOBCODE");
            _test.Log(Status.Info, "Clicked Add Job Code link, fill Details and click on Submit button.");
            // ManageJobTitlePage.ClickSavebutton();
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verified Successful Message");
            StringAssert.AreEqualIgnoringCase("Reg_JOBCODE", ManageJobTitlePage.GetJobCodeLink(), "JobCode Value does not match");
            _test.Log(Status.Pass, "Verify Tags after edit");

        }
        [Test, Order(13), Category("P1")]
        public void a13_Edit_Competency_Details_Creation_31458()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CommonTab.ClickCreateCompetency();
            _test.Log(Status.Info, "Click on Create Competency Button");
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            _test.Log(Status.Info, "Competency Title filled");
            //CreateCompetencyPage.SaveCompetencyName();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            _test.Log(Status.Info, "Open Competency Details Page");
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("EditDescription");
            _test.Log(Status.Info, "Added Description to Competency");
            // ManageCompetencyPage.ClickSavebutton();
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "verify Successful Message");
            StringAssert.AreEqualIgnoringCase("EditDescription", ManageCompetencyPage.GetDescriptionLink(), "Description does not match");
            _test.Log(Status.Pass, "Verify Description text");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("EditKeywords");
            _test.Log(Status.Info, "Added Key Words to Competency");
            // ManageCompetencyPage.ClickSavebutton();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            // _test.Log(Status.Pass, "verify Successful Message");
            StringAssert.AreEqualIgnoringCase("EditKeywords", ManageCompetencyPage.GetKeywordLink(), "Keywords does not match");
            _test.Log(Status.Pass, "verify Key Words text");

        }
        [Test, Order(14), Category("P1")]
        public void a14_User_Remove_Competency_from_existing_Job_title_31504()
        {
            CareersPage.CreateJobTitle(JobTitle + "31504");
            CareersPage.CreateCompetency(CompetencyTitle + "31504");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "31504");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "31504"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle(JobTitle + "31504");
            _test.Log(Status.Info, "Clicked on Searched Job title");
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            _test.Log(Status.Info, "Clicked on Assign Competency Button display insite frame");
            //ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle + "31504");
            //_test.Log(Status.Info, "Search Competency in Assign Compentency Modal");
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle + "31504");
            _test.Log(Status.Info, "Select Conpentency from result and Click on Assign button");
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle + "31504");
            _test.Log(Status.Info, "Remove Added Compentency ");
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle + "31504"));
            _test.Log(Status.Info, "Verify Competency Count is 0");

            //Deleted Job title After test complete
            CareersPage.DeleteJobTitle(JobTitle + "31504");
            _test.Log(Status.Info, "Job Title Deleted");
            StringAssert.AreEqualIgnoringCase("No matching records found", CareersPage.NoMatchingJobTitleFound("No matching records found"));
            _test.Log(Status.Pass, "Verify No matching records found message display after job title deleted");
            CareersPage.DeleteCompetency(CompetencyTitle + "31504");

        }

        [Test, Order(15), Category("P1")]
        public void a15_User_Remove_Competency_while_Creating_New_Job_title_31506()
        {
            CareersPage.CreateCompetency(CompetencyTitle + "31506");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.EditJobTitleName(JobTitle + "TC31506");
            _test.Log(Status.Info, "Create new Job Title");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "Verify SuccessFul Message");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC31506"));
            _test.Log(Status.Pass, "Verify Job Title name");
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            _test.Log(Status.Info, "Clicked on Assign Competency Button display insite frame");
            //ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle + "31506");
            //_test.Log(Status.Info, "Search Competency in Assign Compentency Modal");
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle + "31506");
            _test.Log(Status.Info, "Select Conpentency from result and Click on Assign button");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle + "31506");
            _test.Log(Status.Info, "Remove Added Compentency ");
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
            //  Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "Verify Successful message");
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle + "31506"));
            _test.Log(Status.Info, "Verify Competency Count is 0");

            CareersPage.DeleteCompetency(CompetencyTitle + "31506");
            CareersPage.DeleteJobTitle(JobTitle + "TC31506");
        }

        [Test, Order(16), Category("P1")]
        public void a16_Add_Job_Title_to_Competency_31507()
        {
            CareersPage.CreateCompetency(CompetencyTitle + "31507");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Search Compentency");
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Click on Competency Title");
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            _test.Log(Status.Info, "Clicked on AssignGroup Button display inside frame");
            ManageCompetencyPage.AssignGroupFrame.SelectUserGroupFilter();
            _test.Log(Status.Info, "Select Group from Dropdown list on Asign Modal");
            ManageCompetencyPage.AssignGroupFrame.SearchGroups("Manager");//Create this record for another environment
            _test.Log(Status.Info, "Type Manage on Search area in Asign Modal");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click Search Icon in Asign Modal");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select Record in Asign Modal");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button in Asign Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            //StringAssert.AreEqualIgnoringCase("The Selected Groups were Assigned", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            // Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Verify Competency Title");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);//Verify the total is increased
            _test.Log(Status.Pass, "Verify Count is increased");

        }
        [Test, Order(17), Category("P1")]//dependent on 31458
        public void a17_Add_User_Group_to_Competency_32152() // need to create user and then make a user group to call that users
        {
            CareersPage.CreateCompetency(CompetencyTitle + "TC32152");
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupButtonOuter();//Click on Assign Group button present
            _test.Log(Status.Info, "Clicked on AssignGroup Button display OutSide frame");
            AssignGroupPage.SelectUserGroupFilter();//select user group filter
            _test.Log(Status.Pass, "Select Group from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("usergroup_1102520752");//search user group
            _test.Log(Status.Info, "Search Any User Group Name In Assign Group Modal");
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            string selectedusergroup = Driver.GetElement(By.XPath("//table[@id='find-entities-table']/tbody/tr/td[2]")).Text;
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            Assert.IsTrue(ManageCompetencyPage.NameColumn2ndRow(selectedusergroup)); //checked the user group displaying in Assigned groups
            _test.Log(Status.Pass, "Verify value of 2nd Row");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32152");
            _test.Log(Status.Info, "Search Compentency");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn >= 1);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify Assign groups count");

            //CommonSection.Logout();

            //LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            //_test.Log(Status.Info, "Login with test user");
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open Career Development page");
            //CareersPage.FilterCompetenciesFor("usergroup_1102520752");
            //_test.Log(Status.Info, "Select User group in DropDown");
            //Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            //_test.Log(Status.Info, "Verify Competecy id display in User's Career Development page");

        }

        [Test, Order(18), Category("P1")]// dependednt on 32152
        public void a18_Remove_User_Group_from_Competency_32155()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Search Compentency");
            CareersPage.ClickCompetencyTitle(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Click on Searched Competency Title");
            //ManageCompetencyPage.ClickAssignGroupsTab();
            // ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Dolly's User Group_12012017");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            _test.Log(Status.Info, "Select Assigned Group and Remove them");
            //ManageCompetencyPage.AssignedGroupsTab.ClickRemoveinRemoveConfirmationModal();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Search Compentency");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn >= 0);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify Assign group count");                                                                                          //Verify the total is decressed to 0
            CommonSection.Logout();

            LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            _test.Log(Status.Info, "Login with test User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development page");
            CareersPage.FilterCompetenciesFor("usergroup_1102520752");
            // Assert.IsFalse(CareersPage.CheckCompetencyTitle(CompetencyTitle));

        }
        [Test, Order(19), Category("P1")]
        public void a19_Add_Organization_to_Competency_32153()// need to create organisation and then create a new user, assign him that organisation
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            _test.Log(Status.Info, "Search Competency");
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            _test.Log(Status.Info, "Click on Compentency Title");
            //ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            _test.Log(Status.Info, "Click on Assign Group Button present outside frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Info, "Select Organization from All type Dropdown");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            _test.Log(Status.Info, "Type Sample Organization 1 in search text box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click on Search Icon");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select search result");
            //AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign button");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify successful message");
            Assert.IsTrue(ManageCompetencyPage.NameColumn("Sample Organization 1")); ;//checked the user group displaying in Assigned groups
            _test.Log(Status.Pass, "Organization added to Competency successfully ");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            _test.Log(Status.Info, "Click Searched competency title");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 1);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify Assign group count");
            //CommonSection.Logout();
            //// LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            //_test.Log(Status.Info, "Login with test user");
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open Career Development Page");
            //CareersPage.FilterCompetenciesFor("Sample Organization 1");
            ////Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(20), Category("P1")]
        public void a20_Remove_Organization_from_Competency_32156() //depend on 31507
        {
            CareersPage.CreateCompetency(CompetencyTitle + "TC32156");
            ManageCompetencyPage.ClickAssignGroupsTab();
            _test.Log(Status.Info, "Click on Assign Group Button present inside frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Info, "Select Organization from All type Dropdown");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("test");
            _test.Log(Status.Info, "Search Sample Organization 1");
            AssignGroupPage.SelectFirstRecord();
            _test.Log(Status.Info, "Select searched first record");
            //AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");

            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            _test.Log(Status.Info, "Removed selected Competency");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Pass, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32156");
            _test.Log(Status.Info, "Search Competency" + CompetencyTitle + "TC32156");
            CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle + "TC32156");
            _test.Log(Status.Info, "Click on Searched Competency Title");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            _test.Log(Status.Pass, "Verify Assign Group Count");
            CareersPage.DeleteCompetency(CompetencyTitle + "TC32156");
            // CommonSection.Logout();
            // LoginPage.GoTo();
            // LoginPage.LoginClick();
            // LoginPage.LoginAs("testuser123").WithPassword("").Login();
            // CommonSection.Learn.CareerDevelopment();
            //// Assert.IsFalse(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            // CommonSection.Logout();
            // LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(21), Category("P1")]
        public void a21_Remove_Job_Title_from_Competency_31508()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            _test.Log(Status.Info, "Search Competency" + CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            _test.Log(Status.Info, "Click on Searched Competency Title");
            //CareersPage.CompetencyTab.ClickCompetency();
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();
            _test.Log(Status.Info, "Click on Assign Group Button present inside frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Pass, "Select Job Title from All type Dropdown");
            // AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click Search icon");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select searched record");
            //AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successfull Message");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);
            _test.Log(Status.Pass, "Verify Assign Group Column");
            //ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Manager");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            _test.Log(Status.Info, "Select all and remove all Assign Groups");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);
            _test.Log(Status.Pass, "Verify Assign Group Column");
        }

        [Test, Order(22), Category("P1")]
        public void a22_Access_Careers_31888()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifyTabName("Career Paths"));
            _test.Log(Status.Pass, "Verify Career Path tab Name");
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyText("Job Titles"));
            _test.Log(Status.Pass, "Verify Job Titles tab Name");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scales"));
            _test.Log(Status.Pass, "Verify Proficiency Scales tab Name");
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyText("360 Templates"));
            _test.Log(Status.Pass, "Verified Tab Names");
            CommonSection.Logout();

            //LoginPage.GoTo();

            LoginPage.LoginAs("user_competencymanager").WithPassword("password").Login(); //Login as Competency Manager
            _test.Log(Status.Info, "Login with Competency Manager");
            CommonSection.Manage.CareerMenu();
            _test.Log(Status.Info, "Logged in with Learner and open Career Page");
            Assert.IsTrue(CareersPage.CompetenciesTab.VerifyText("Competencies"));
            _test.Log(Status.Pass, "Verified Competencies Tab Names");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scales"));
            _test.Log(Status.Pass, "Verified Proficiency Scales Tab Names");


        }
        [Test, Order(23), Category("P1")]
        public void a23_Test_to_Verify_order_of_Tabs_on_Careers_page_32310()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifySearchText("Career Paths"), "Error message is different");
            _test.Log(Status.Pass, "Verify Career Paths tab Name");
            StringAssert.AreEqualIgnoringCase("Job Titles", CareersPage.CareerPathTab.VerifySearchText("Job Titles"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify Job Titles tab Name");
            StringAssert.AreEqualIgnoringCase("Competencies", CareersPage.CareerPathTab.VerifySearchText("Competencies"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify Competencies tab Name");
            StringAssert.AreEqualIgnoringCase("Proficiency Scales", CareersPage.CareerPathTab.VerifySearchText("Proficiency Scales"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify Proficiency Scales tab Name");
            StringAssert.AreEqualIgnoringCase("360 Templates", CareersPage.CareerPathTab.VerifySearchText("360 Templates"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify 360 Templates tab Name");
        }
        [Test, Order(24), Category("P1")]
        public void a24_Test_to_Verify_instruction_Text_On_Tabs_and_Careers_page_32311()

        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickTab("Job Titles");
            _test.Log(Status.Info, "Open Job Title Tab");
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on Job Titles tab and verified Instruction Text");
            CareersPage.ClickTab("Competencies");
            Assert.IsTrue(CareersPage.CompetenciesTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on Competencies tab and verified Instruction Text");
            CareersPage.ClickTab("Proficiency Scales");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on Proficiency Scales tab and verified Instruction Text");
            CareersPage.ClickTab("360 Templates");
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on 360 Templates tab and verified Instruction Text");

        }
        [Test, Order(25), Category("P1")]
        public void a25_Verify_Updated_label_of_Career_Development_on_Domain_Page_32303()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "Opens Domains Page");
            DomainsPage.ClickDomainLink("Meridian Global-Core Domain(default)");
            _test.Log(Status.Info, "Open Domain Edit Summary Page");
            EditSummaryPage.Menus.ClickMenuTab();
            _test.Log(Status.Info, "Open Menu tab");
            StringAssert.AreEqualIgnoringCase("Career Development", MenuPage.GetCurrentValueForCareerPath(), "Error message is different");
            _test.Log(Status.Pass, "Verify Career Development lable text on Menu Tab");
            EditSummaryPage.Menus.ClickOptionsTab();
            _test.Log(Status.Info, "Open Options tab");
            StringAssert.AreEqualIgnoringCase("Enable Career Development", EditConfigurationOptionsPage.GetOptionValue(), "Error message is different");
            _test.Log(Status.Pass, "Verify Enable Career Development lable text on Options Tab");
        }
        [Test, Order(26), Category("P1")]
        public void a26_User_View_lists_all_Proficiency_Scales_32373()

        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickTab("Proficiency Scales");
            _test.Log(Status.Info, "Open Proficiency Scales tab");
            CareersPage.ClickCreateNewProficencyScale();
            _test.Log(Status.Info, "Click On Create Proficeancy Scale button");
            //StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.CreateNewProficiencyScaleModel.CreateNew(ProficiencyTitle);
            _test.Log(Status.Info, "Click New on Model opened");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            _test.Log(Status.Info, "Enter Label text");
            CareersPage.ClickCreatebutton();
            _test.Log(Status.Info, "Click Create button");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify Successful Message");
            CareersPage.SearchTextBox(ProficiencyTitle);
            _test.Log(Status.Info, "Search Proficiency" + ProficiencyTitle);
            CareersPage.SelectSearchType("Exact Phrase");
            _test.Log(Status.Info, "Choose Exact Phrase");
            CareersPage.Searchbutton();
            _test.Log(Status.Info, "Click Search Button");
            StringAssert.AreEqualIgnoringCase(ProficiencyTitle, CareersPage.GetProficiencyTitle(), "Error message is different");
            _test.Log(Status.Info, "Verify Proficiency Title");
            //StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");

        }
        [Test, Order(27), Category("P1")]
        public void a27_ActiveInActive_Job_Title_In_Professional_Development_31882()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickJobtitle("Job Titles");
            _test.Log(Status.Info, "Open Job Title Tab");
            Assert.IsTrue(CareersPage.JobTitlesTab.GetTotalJobTitles(), "JobTiles Count matched");//Check for Active and Inactive Job Titles displayed
            _test.Log(Status.Info, "Verify results with active and inactive state");

        }
        [Test, Order(28), Category("P1")]
        public void a28_Localize_Competency_32105()
        {
            CareersPage.CreateCompetency(CompetencyTitle + "TC32105");

            //CommonSection.Manage.ProfessionalDevelopment();
            //_test.Log(Status.Info, "Open Career Menu");
            //CareersPage.ClickCompetencyTab();
            //_test.Log(Status.Info, "Open Competency tab");
            //CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32105");
            //_test.Log(Status.Info, "Search Competency as " + CompetencyTitle + "TC32105");
            //CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //_test.Log(Status.Info, "Click on Competency Title");
            ManageCompetencyPage.ClickLocalizedIndropdown();
            ManageCompetencyPage.LocalizedIndropdown.ClickAddLocalization();
            _test.Log(Status.Info, "Click on Add Localization");
            ManageCompetencyPage.LocalizedIndropdown.SelectLanguage("French");
            _test.Log(Status.Info, "Select French from DropDown");
            //ContentDetailsPage.SelectAddLocalization("French");
            AddLocalizationModal.EnterForm("Title", "Description", "Keywords");
            AddLocalizationModal.ClickLocalize();
            _test.Log(Status.Info, "Added Description, Keywords and click Localize");
            // StringAssert.AreEqualIgnoringCase("Success", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.ClickLocalizedIndropdown();
            _test.Log(Status.Info, "Click on Localize Dropdown");
            // Assert.IsTrue(ManageCompetencyPage.LocalizedIndropdown.CheckLanguage);
            StringAssert.AreEqualIgnoringCase("French (Canada)", ManageCompetencyPage.LocalizedIndropdown.CheckLanguage("French"), "Language Not Matched");
            _test.Log(Status.Pass, "Verify French is display as selected into DropDown ");
            Assert.IsTrue(ManageCompetencyPage.CompetencyTitleText(CompetencyTitle + "TC32105"));
            _test.Log(Status.Pass, "Verify Competency Ttile matched");
            CareersPage.DeleteCompetency(CompetencyTitle + "TC32105");
        }
        

        [Test, Order(7), Category("P1")]
        public void A07_User_Sets_Weekly_Recurrence_On_Section_34145()
        {
            #region Creating a Classroom Course Section With Weekday Recurrence
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34145");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34145");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Weekly");
            _test.Log(Status.Info, "Setting Recurrence Type as Weekly");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34145"));
            _test.Log(Status.Pass, "Verify Section is Created with Weekly Recurrence Type");
            #endregion
        }

        [Test, Order(8), Category("P1")]
        public void A08_User_Sets_Every_Weekday_Recurrence_On_Section_34144()
        {
            #region Creating a Classroom Course Section With Every_Weekday Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34144");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34144");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Every Weekday");
            _test.Log(Status.Info, "Setting Recurrence Type as Every Weekday");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34144"));
            _test.Log(Status.Pass, "Verify Section is Created with Every Weekday Recurrence Type");

            #endregion
        }

        [Test, Order(9), Category("P1")]
        public void A09_User_Sets_Every_two_weeks_Recurrence_On_Section_34146()
        {
            #region Creating a Classroom Course Section With Every_two_weeks Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34146");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34146");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Every two weeks");
            _test.Log(Status.Info, "Setting Recurrence Type as Every two weeks");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34146"));
            _test.Log(Status.Pass, "Verify Section is Created with Every two weeks Recurrence Type");

            #endregion
        }

        [Test, Order(10), Category("P1")]
        public void A10_User_Sets_Monthly_Recurrence_On_Section_34148()
        {
            #region Creating a Classroom Course Section With Monthly Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34148");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34148");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Monthly");
            _test.Log(Status.Info, "Setting Recurrence Type as Monthly");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34148"));
            _test.Log(Status.Pass, "Verify Section is Created with Monthly Recurrence Type");

            #endregion
        }

        [Test, Order(11), Category("P1")]
        public void A11_User_Sets_Annually_Recurrence_On_Section_34147()
        {
            #region Creating a Classroom Course Section With Annually Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34147");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34147");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Annually");
            _test.Log(Status.Info, "Setting Recurrence Type as Annually");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34147"));
            _test.Log(Status.Pass, "Verify Section is Created with Annually Recurrence Type");

            #endregion
        }

        [Test, Order(12), Category("P1")]
        public void A12_User_Sets_Daily_Recurrence_On_Section_34143()
        {
            #region Creating a Classroom Course Section With Daily Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34143");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34143");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Daily");
            _test.Log(Status.Info, "Setting Recurrence Type as Annually");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34143"));
            _test.Log(Status.Pass, "Verify Section is Created with Daily Recurrence Type");

            #endregion
        }

        [Test, Order(13), Category("P1")]
        public void A13_Manage_Students_Manage_Notes_Instructor_9008()
        {
            #region Create Instructor
            Driver.CreateNewAccount("Instructor");
            _test.Log(Status.Info, "Created Instructor" + Meridian_Common.NewUserId);
            //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Logged in with admin");
            CommonSection.Administer.People.Instructor();
            _test.Log(Status.Info, "Navigated to Instructor Page");
            InstructorsPage.AddInstructor(Meridian_Common.NewUserId);
            _test.Log(Status.Info, "Created Instructor" + Meridian_Common.NewUserId);
            #endregion
            #region Creating a Classroom Course Section with Max 5 User and Instructor
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC9008");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC9008");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.Select_Specific_Instructor(Meridian_Common.NewUserId);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC9008"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            #region Enroll User into Section
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            ManageClassroomCoursePage.Enrollment();
            _test.Log(Status.Info, "Clicking Enrollment Tab");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");
            _test.Log(Status.Info, "Searching and Enrolling User");

            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage Training");
            CommonSection.Manage.TrainingPage.InstructorTool();
            _test.Log(Status.Info, "Navigate to Instructor Tool Page");
            InstructorsPage.Click_ManageStudent();
            _test.Log(Status.Info, "Click on Manage Student");
            InstructorsPage.Search_ForSection_InManageStudentPage(classroomcoursetitle + "TC9008");
            _test.Log(Status.Info, "Sarching for Classroom Course from Manage Student");
            Assert.IsTrue(InstructorsPage.Click_SectionTitle_FrommanageStudentPage(Section + "TC9008"));
            _test.Log(Status.Info, "Click on Section Title");
            SectionDetailsPage.clickEnrollmentTab();
            Assert.IsTrue(SectionDetailsPage.Add_Notes());
            _test.Log(Status.Pass, "Assertion Pass as Instructor successfully added Notes for enrolled user");
            Assert.IsTrue(SectionDetailsPage.Delete_Notes());
            _test.Log(Status.Pass, "Assertion Pass as Instructor successfully removed Notes for enrolled user");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        [Test, Order(14), Category("P1")]
        public void A14_Authorized_User_Should_Able_To_Access_Manage_Gradebook_11794()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage Training");
            CommonSection.Manage.TrainingPage.InstructorTool();
            _test.Log(Status.Info, "Navigate to Instructor Tool Page");
            InstructorsPage.Click_TeachingScheduleTab();
            InstructorsPage.Click_Expand_SectionDetail();
            _test.Log(Status.Info, "Click on Teaching Scheule and Expand the Detail.");
            Assert.IsTrue(InstructorsPage.Click_ManageGradeBookButton());

        }

        [Test, Order(15), Category("P1")] // Working on it
        public void A15_Instructor_Entering_Grades_for_an_Assignment_Should_not_Have_to_Search_for_Students_20376()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Creating a Classroom Course Section with Max 5 User and Instructor
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC20376");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC20376");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.Select_Specific_Instructor(Meridian_Common.NewUserId);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC20376"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            #region Enroll User into Section
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            ManageClassroomCoursePage.Enrollment();
            _test.Log(Status.Info, "Clicking Enrollment Tab");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            string expected_username = Driver.Instance.GetElement(By.XPath("//div[5]/div[1]/div[1]/form[1]/div[5]/div[1]/div[1]/div[2]/div[2]/table[1]/tbody[1]/tr[1]/td[2]")).Text;
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");
            _test.Log(Status.Info, "Searching and Enrolling User");
            #endregion
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage Training");
            CommonSection.Manage.TrainingPage.InstructorTool();
            _test.Log(Status.Info, "Navigate to Instructor Tool Page");
            InstructorsPage.Click_ManageStudent();
            _test.Log(Status.Info, "Click on Manage Student");
            InstructorsPage.Search_ForSection_InManageStudentPage(classroomcoursetitle + "TC20376");
            _test.Log(Status.Info, "Sarching for Classroom Course from Manage Student");
            Assert.IsTrue(InstructorsPage.Click_SectionTitle_FrommanageStudentPage(Section + "TC20376"));
            _test.Log(Status.Info, "Click on Section Title");
            SectionDetailsPage.clickEnrollmentTab();
            string actual_username = Driver.Instance.GetElement(By.XPath("//div[1]/div[2]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody[1]/tr[1]/td[2]")).Text;
            StringAssert.AreEqualIgnoringCase(expected_username, actual_username);
            _test.Log(Status.Pass, "Assertion Pass as users re displaying without performing search by instructor");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(20), Category("P1")]
        public void A20_Learner_Want_To_Know_The_Timezone_Associated_With_A_Scheduled_Event_34112()
        {
            //  CommonSection.Administer.System.SystemAdministration.SystemBehaviorAndStorage();
            //  SystemBehaviorAndStoragePage.enableTimeZoneVisibility();
            // -> Above codes are commented as there is a defect in saving the information.
            #region Creating a Classroom Course and Section Event
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34112");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34112");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.SelectTimeZone();
            _test.Log(Status.Info, "Select Timezone as EST");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34112"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with learner");
            CommonSection.Avatar.Account();
            _test.Log(Status.Info, "Navigat to Profile Page");
            AccountPage.ClickPreferencesTab();
            _test.Log(Status.Info, "Click on Preferences Tab");
            AccountPage.Click_EditPreferencesButton();
            _test.Log(Status.Info, "Click Edit Preference");
            AccountPage.Change_Timezone();
            _test.Log(Status.Info, "Change time zone to CST");
            AccountPage.Click_SavePreferencesButton();
            _test.Log(Status.Info, "Save The Detail");
            CatalogPage.SearchContent_InCatalogPage(classroomcoursetitle + "TC34112");
            string timezonecatalog = ClassroomCoursePage.verifyTimeZone_CatalogPage();
            Assert.IsTrue(timezonecatalog.Contains("CST"));
            _test.Log(Status.Pass, "Assertion Pass as Timezone displaying to user in catalog Search detail");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34112");
            string timezonedetailpage = ClassroomCoursePage.verifyTimeZone_ClassroomDetailPage();
            Assert.IsTrue(timezonedetailpage.EndsWith("CST"));
            _test.Log(Status.Pass, "Assertion Pass as Timezone displaying to user in section detail");
            string eventdetail = ClassroomCoursePage.verifyTimeZone_EventDetail();
            Assert.IsTrue(eventdetail.EndsWith("CST"));
            _test.Log(Status.Pass, "Assertion Pass as Timezone displaying to user in Event detail");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logg Out from learner");
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Log in with admin");

        }

        [Test, Order(21), Category("P1")]
        public void A21_User_Adds_Additional_Event_While_Creating_Classroom_Section_33709()
        {
            #region Creating a Classroom Course and Section with additional Event
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33709");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC33709");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            string s = ManageClassroomCoursePage.add_AnotherEvent(Section + "TC33709"); //add Tab mechanism
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC33709"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            string s2 = ClassroomCoursePage.click_DetailButton(s);
            _test.Log(Status.Info, "Expand the event detail");
            Assert.IsTrue(s2.Contains("_2ndEvent"));
            _test.Log(Status.Pass, "Assertion Pass as Events details are displaying correct");
            StringAssert.AreEqualIgnoringCase(s, s2);
            _test.Log(Status.Pass, "Assertion Pass as Multiple events has been created for classroom course section");

        }

        [Test, Order(22), Category("P1")]
        public void A22_View_All_Assignments_For_Section_And_Edit_Their_Weights_In_Bulk_14678()
        {
            #region Creating a Classroom Course and Section
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC14678");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC14678");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC14678"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            ManageClassroomCoursePage.Enrollment();
            _test.Log(Status.Info, "Clicking Enrollment Tab");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            string expected_username = Driver.Instance.GetElement(By.XPath("//div[5]/div[1]/div[1]/form[1]/div[5]/div[1]/div[1]/div[2]/div[2]/table[1]/tbody[1]/tr[1]/td[2]")).Text;
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser_MultipleUsers("");
            _test.Log(Status.Info, "Searching and Enrolling User");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs(assignment + "1");
            _test.Log(Status.Info, "Added First Assignment");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs(assignment + "2");
            _test.Log(Status.Info, "Added Second Assignment");
            SectionDetailsPage.ClickGradebookTab();
            _test.Log(Status.Info, "Click on Gradebook Tab");
            SectionDetailsPage.Click_GradesOnlyButton();
            _test.Log(Status.Info, "Click on Grade Only Tab");
            Assert.IsTrue(SectionDetailsPage.enterGradeForUser_PASS_OR_FAIL());
            _test.Log(Status.Pass, "Assertion Pass as user able to edit weights in bulk successfully.");

        }
        [Test, Order(1), Category("P1")]
        public void a01_Test_when_User_add_a_new_proficiency_scale_31801()

        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickTab("Proficiency Scales");
            _test.Log(Status.Info, "Open Proficiency Scales tab");
            CareersPage.ClickCreateNewProficencyScale();
            _test.Log(Status.Info, "Click Create new Preficiency");
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message");
            CareersPage.ClickTitleTextBox("Regression Scale");
            _test.Log(Status.Info, "Click On Scale Title");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            _test.Log(Status.Info, "Enter Label text");
            CareersPage.ClickCreatebutton();
            _test.Log(Status.Info, "Click Create button");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.VerifySuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message");
            Assert.IsTrue(CareersPage.ProficeancyItemCount());
            _test.Log(Status.Pass, "Verify Item Count");
        }

        [Test, Order(2), Category("P1")]
        public void a02_User_adds_supplemental_training_to_a_new_competency_31561()

        {  // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training 
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Create General Course Page ");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC31561", "Automation Test");
            _test.Log(Status.Info, "Fill Course title and Description and Click on Create");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle + "TC31561");
            _test.Log(Status.Info, "Competency Title filled");
            //CreateCompetencyPage.SaveCompetencyName();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));

            // CareersPage.CompetencyTab.ClickCreateCompetency();
            //CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            //CreateCompetencyPage.SaveCompetencyName();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //StringAssert.AreEqualIgnoringCase("The Competency was created", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.AssociatedContentTab_click();
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.SupplementalTab_Click();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            Assert.AreEqual("There is no supplemental content.", ManageCompetencyPage.CompetencySupplementalTabText(), "Error message is different");
            _test.Log(Status.Pass, "Verify supplemental tab doesnot contain any Content");
            ManageCompetencyPage.AssociateContent_Click();
            _test.Log(Status.Info, "Click on Associated Content Button present inside frame");
            ManageCompetencyPage.SearchTextFrame(generalcoursetitle + "TC31561");
            _test.Log(Status.Info, "Search" + generalcoursetitle + "TC31561");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            _test.Log(Status.Info, "Select course and Click Add");
            //Assert.AreEqual("The selected items were added.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("1"));//Added record should appear that we created as pre req
            _test.Log(Status.Pass, "Verify Content added to supplemental tab");
        }
        [Test, Order(3), Category("P1")]  //depend on 31458
        public void a03_User_adds_supplemental_training_to_an_existing_competency_31562()
        {
            // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC31561");
            _test.Log(Status.Info, "Search Conpetency");
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle + "TC31561");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            ManageCompetencyPage.AssociatedContentTab_click();
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.SupplementalTab_Click();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            ManageCompetencyPage.AssociateContent_Click();
            _test.Log(Status.Info, "Click on Associated Content Button present inside frame");
            ManageCompetencyPage.SearchTextFrame(generalcoursetitle + "TC31561");
            _test.Log(Status.Info, "Search" + generalcoursetitle + "TC31561");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            _test.Log(Status.Info, "Select course and Click Add");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("1"));//Added record should appear that we created as pre req
            _test.Log(Status.Pass, "Verify Content added to supplemental tab");
            // Assert.AreEqual("Success", ManageCompetencyPage.GetSuccessMessage());
            //Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("dv_test"));//Added record should appear that we created as pre req
        }
        [Test, Order(4), Category("P1")]
        public void a04_Switch_Supplemental_Content_to_Mandatory_in_Competency_32214() //dependent on the records already exists in Supplemental tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Search CompetencyTitle1803432643");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            ManageCompetencyPage.AssociatedContentTab_click();//clicking on tab
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.AssociatedContentTab.ClickSupplementalTab();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            // ManageCompetencyPage.AssociateContent_Click();
            // ManageCompetencyPage.SearchTextFrame("Document that created as Pre req");
            // ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount); //Verify record display
            _test.Log(Status.Pass, "Verify Content is Present");
            ManageCompetencyPage.SelectSupplementalRecords.ClickMakeMandatory();
            _test.Log(Status.Info, "Mark as Mandatory from one of the record");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            //Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount); //verify record moved from supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.SupplementalTab.CheckRecord);//Check Record is moved from Supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved to Mandatory tab
            //Assert.Null(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is decreased.
            ManageCompetencyPage.AssociatedContentTab.ClickMandatoryTab();
            _test.Log(Status.Info, "Click on Mandatory Tab");
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is increased.
            _test.Log(Status.Pass, "Verify Content is Present");

        }
        [Test, Order(5), Category("P1")]
        public void a05_Switch_Mandatory_Content_to_Supplemental_in_Competency_31881() //dependent on the records already exists in Mandatory tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Search CompetencyTitle1803432643");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            ManageCompetencyPage.AssociatedContentTab_click();//clicking on tab
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.AssociatedContentTab.ClickMandatoryTab();
            _test.Log(Status.Info, "Click on Mandatory Tab");
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);
            _test.Log(Status.Pass, "Verify Content is Present");
            ManageCompetencyPage.SelectMandatoryRecords.ClickMakeSupplemental();
            _test.Log(Status.Info, "Mark as Supplemental from one of the record");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            //Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);
            ManageCompetencyPage.AssociatedContentTab.ClickSupplementalTab();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);
            _test.Log(Status.Pass, "Verify Content is Present");
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Check Record is moved to Supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved from Mandatory tab
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is increased.
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is decreased.  
        }
        [Test, Order(6), Category("P1")]
        public void a06_View_Proficiency_Scale_Details_from_list_of_competencies_32106()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle0705274827");
            _test.Log(Status.Info, "Search CompetencyTitle0705274827");
            Assert.IsTrue(CareersPage.CheckProficiencyScaleColumn_ClickView());
            _test.Log(Status.Pass, "Verify Profeciency Column is display with View link");
            CareersPage.CompetencyTab.ProficiencyScaleColumn_ClickView();
            _test.Log(Status.Info, "Click on View link");
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Modal with Labels is displayed
            _test.Log(Status.Pass, "Verify Profeciency Labels are display on Popup");
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed
            _test.Log(Status.Pass, "Verify Profeciency Labels Numbers are display on Popup");
            CareersPage.CompetencyTab.ProficiencyScaleViewModal_CloseClick();
            _test.Log(Status.Info, "Close the Popup");
            Assert.IsTrue(CareersPage.ProficeancyViewPopupClosed());
            _test.Log(Status.Pass, "Verify Popup is closed");


        }

        [Test, Order(7), Category("P1")]
        public void a07_View_Proficiency_Scale_Details_from_Proficiency_Scale_Page_32107()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickTab("Proficiency Scales");
            _test.Log(Status.Info, "Open Proficiency Scales Tab");
            // CareersPage.ClickProficiencyScalesTab();
            CareersPage.ProficiencyScalesTab_ClickProficiencyScaleTitle();
            _test.Log(Status.Info, "Click on Proficiency Scale title");
            Assert.IsTrue(CareersPage.RatingScaleModal_NumbersandLabels_CheckRecord);
            _test.Log(Status.Pass, "Verify Detail Proficiency display");
            // Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord);
            CareersPage.ProficiencyScaleTab.ProficiencyScaleViewModal_CloseClick();
            _test.Log(Status.Info, "Click the popup");
        }

        [Test, Order(8), Category("P1")]
        public void a08_View_Proficiency_Scale_Details_from_Assigned_Groups_32109()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle0705274827");
            _test.Log(Status.Info, "Search CompetencyTitle0705274827");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle0705274827");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            //CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignedGroupsTab();
            _test.Log(Status.Info, "Clicking on Assign Group Tab");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickViewScale);
            _test.Log(Status.Pass, "Verify Optional Rating drodown is Present");
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_clickViewScale();
            _test.Log(Status.Info, "Clicking Optional Rating view Scale link");
            //Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickViewScale);
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Modal with Numbers is displyed
            _test.Log(Status.Pass, "Verify Scale Numbers are display");
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed
            _test.Log(Status.Pass, "Verify Scale Lables are display");
            CareersPage.CompetencyTab.ProficiencyScaleViewModal_CloseClick();
            _test.Log(Status.Info, "Close Popup");
        }
        [Test, Order(9), Category("P1")]
        public void a09_Test_Searching_for_Competency_by_Name_Keyword_Description_31474()

        {
            CareersPage.CreateCompetency(CompetencyTitle + "TC31474");
            _test.Log(Status.Pass, "Create new Competency successfully created");
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            _test.Log(Status.Info, "Clicked on Competency Details tab");
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("Description_Regression_Competency1");
            // ManageCompetencyPage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "AddDescription added to Competency successfully created");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("Keyword_Regression_Competency1");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "AddKeywords added to Competency successfully created");
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Reopen Carres page");
            //CareersPage.CommonTab.ClickCreateCompetency();
            StringAssert.AreEqualIgnoringCase(CompetencyTitle + "TC31474", CareersPage.SearchByKeyword("Keyword_Regression_Competency1", CompetencyTitle + "TC31474")); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies with Keyword");
            StringAssert.AreEqualIgnoringCase(CompetencyTitle + "TC31474", CareersPage.SearchByDescription("Description_Regression_Competency1", CompetencyTitle + "TC31474")); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies by Description");
            StringAssert.AreEqualIgnoringCase(CompetencyTitle + "TC31474", CareersPage.SearchByCompetencyTitle(CompetencyTitle + "TC31474")); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies by CompetencyTitle");
            CareersPage.DeleteCompetency(CompetencyTitle + "TC31474");
        }

        [Test, Order(10), Category("P1")]
        public void a10_Test_Creation_of_Job_Title_from_Professional_Development_31482()

        {
            Assert.True(true);
            //similar to test case id 22211.
        }
        [Test, Order(11), Category("P1")]
        //Pre-req - Learner has atleast one competency assigned to them they have not completed and one completed
        public void a11_Filter_competencies_by_Complete_Incomplete_Status_32130()
        {
            CommonSection.Logout();

            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            Assert.IsTrue(CareersPage.ListofCompetencies.InProgressStatus);
            _test.Log(Status.Pass, "Progress bar display for competency");
            CareersPage.SelectCompleteIcon();
            _test.Log(Status.Info, "Select Complete Icon");
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_CompletedStatus);
            _test.Log(Status.Pass, "verify records");
            CareersPage.SelectInProgressIcon();
            _test.Log(Status.Info, "Select In Progress Icon");
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_InProgressStatus);
            _test.Log(Status.Pass, "Verify records");

            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }

        [Test, Order(12), Category("P1")]
        public void a12_Add_AllTypes_to_Competency_32154()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CareersPage.CreateJobTitle(JobTitle + "TC32154");
            _test.Log(Status.Info, "Login with Admin suer");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.ClickCreateCompetency(); //cllick on record new competency required here
            _test.Log(Status.Info, "Click on Create Competency Button");
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Competency Title filled");
            //CreateCompetencyPage.SaveCompetencyName();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageCompetencyPage.ClickAssignGroupsTab();//clicking on tab
            _test.Log(Status.Info, "Clicking on Assign Group Tab");
            //ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();//not required
            #region Adding JobTitle to Competency
            AssignGroupPage.SelectJobTitleFilter();            //select user group filter
            _test.Log(Status.Pass, "Select Job Title from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext(JobTitle + "TC32154");//search Job title
            _test.Log(Status.Info, "Enter Job Title name into search text Box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            //Assert.IsTrue(ManageCompetencyPage.NameColumn("usergroup_1102520752")); //checked the user group displaying in Assigned groups
            #endregion
            #region Adding Organization to Competency
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();//clicking on tab
            _test.Log(Status.Info, "Clicking on Assign Group button outside Frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Pass, "Select Organization from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            _test.Log(Status.Info, "Enter Organization name into search text box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            //Assert.IsTrue(ManageCompetencyPage.NameColumn("Sample Organization 1 "));
            #endregion
            #region Adding userGroup to competency
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();
            _test.Log(Status.Info, "Clicking on Assign Group button outside Frame");
            AssignGroupPage.SelectUserGroupFilter();//select user group filter
            _test.Log(Status.Pass, "Select User Group from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("usergroup_1102520752");//search user group
            _test.Log(Status.Info, "Enter User Group name into search text box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            // Assert.IsTrue(ManageCompetencyPage.NameColumn("usergroup_1102520752"));
            #endregion
            //#region Adding all types using Select ALL
            //ManageCompetencyPage.ClickAssignGroupsTab();
            //AssignGroupPage.ClickSelectAllinPage1();
            //AssignGroupPage.ClickAssignButton();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //#endregion
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Search Competency" + CompetencyTitle + "TC32154");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 3);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify competency count");

            //CommonSection.Logout();
            //// LoginPage.GoTo();
            //// LoginPage.LoginClick();
            //LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            //CommonSection.Learn.CareerDevelopment();
            //CareersPage.FilterCompetenciesFor("usergroup_1102520752");

            //// Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(13), Category("P1")]
        public void a13_Remove_All_Types_from_Competency_32157()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Search " + CompetencyTitle + "TC32154");
            CareersPage.ClickCompetencyTitle(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Click on Conoetency Title");
            ManageCompetencyPage.SelectALLAssignedGroup();
            _test.Log(Status.Info, "Click On Select All Check Box");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemoveAllbutton(); //Success  The selected items were removed.
            _test.Log(Status.Info, "Click on Remove All button");
            //StringAssert.AreEqualIgnoringCase("The selected items were removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify successful message");
            //Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            //CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle);
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Search " + CompetencyTitle + "TC32154");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            _test.Log(Status.Pass, "Verify Assign Group Count");

        }
        [Test, Order(16)]
        public void a16_Add_proficiency_Scale_to_Competency_from_Create_Competency_32168()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CareersPage.CreateCompetency(CompetencyTitle + "TC32168");
            _test.Log(Status.Info, "Create a new competency");
            StringAssert.AreEqualIgnoringCase("Success\r\nThe competency was created.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message is display");
            ManageCompetencyPage.ClickAssignGroupsTab();
            AssignGroupPage.SelectUserGroupFilter();
            //AssignGroupPage.SearchGroups.ClickSearchbutton("");
            AssignGroupPage.SearchRecords.SelectFirstRecord();
            AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button");
            StringAssert.AreEqualIgnoringCase("Success\r\nThe selected groups were assigned.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message is display");
            //Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle("dfgdfgdg"));
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_NoScaledropdown());
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.RequiredRatingColumn_CheckRecord("1")); //displays the #1 lowest option of Proficiency Scale

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the Competency under Competency Listing
            CareersPage.ClickCompetencyTab(); //Verify the Competency Title created above
            CareersPage.SearchByCompetencyTitle(CompetencyTitle + "TC32168");
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_CheckProficiencyScale("test")); //Verify the Proficiency Scale selected above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating("1 - 3 3 View")); //Verify the Proficiency Scale Rating include First and Last Rating Number and label

            //CareersPage.CreateJobTitle(JobTitle + "TC32168"); //Verify the Proficiency Rating for the competency record under Job Title

            //Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.VerifyProficiencyScale("test"));
            //ManageJobTitlePage.CompetenciesTab.RemoveAllCompetency();
            //ManageJobTitlePage.CompetenciesTab.ClickAssignCompetency();
            //AssignCompetencyModal.SearchCompetency(CompetencyTitle + "TC32168");
            //Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.AssignCompetency_CompetencyTitle_CheckProficiencyScale("test"));

        }
        [Test, Order(17), Description("Dependent on 44")]
        public void a17_Add_proficiency_Scale_to_Competency_from_Existing_Competency_32287()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.SearchByCompetencyTitle(CompetencyTitle);
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_NoScaledropdown());
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            AssignGroupPage.SelectUserGroupFilter();
            AssignGroupPage.SelectFirstRecord();
            AssignGroupPage.ClickAssignButton();
            // Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickdropdown());
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            //      ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.RequiredRatingColumn_CheckRecord("1")); //displays the #1 lowest option of Proficiency Scale

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the Competency under Competency Listing
            CareersPage.ClickCompetencyTab(); //Verify the Competency Title created above
            CareersPage.SearchByCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_CheckProficiencyScale("test")); //Verify the Proficiency Scale selected above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating("3 View")); //Verify the Proficiency Scale Rating include First and Last Rating Number and label

            //CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the competency record under Job Title
            //CareersPage.ClickJobTitleTab();
            //CareersPage.JobTitlesTab.SearchJobTitle("dfgdfgdg");
            //CareersPage.JobTitlesTab.ClickJobTitleName("dfgdfgdg");
            //ManageJobTitlePage.CompetenciesTab.ClickAssignCompetency();
            //Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.AssignCompetency_CompetencyTitle_CheckProficiencyScale(""));

        }
        [Test, Order(18)]
        public void a18_View_Active_and_Inactive_competencies_32159()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCareerPathTab();
            CareersPage.ClickCompetencyTab();
            int recordsbefore = CareersPage.CompetencyTab.GetNumberOfRecords();
            CareersPage.CompetenciesTab.ClickInactiveItemsCheckbox();
            int recordsafter = CareersPage.CompetencyTab.GetNumberOfRecords();
            Assert.That(recordsafter > recordsbefore, recordsafter + " is not greater than " + recordsbefore);
            CareersPage.CompetenciesTab.ClickInactiveItemsCheckbox();
            recordsafter = CareersPage.CompetencyTab.GetNumberOfRecords();
            Assert.That(recordsafter == recordsbefore, "Records after is not equal to Records Before");
        }
        [Test, Order(19)]
        public void a19_Test_when_User_can_View_all_archived_proficiency_scales_from_the_tab_32401()

        {

            CommonSection.Manage.Careerstab();

            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.CreateNewProficencyScale("Scale_" + Meridian_Common.globalnum, "1", "2", "3");

            StringAssert.AreEqualIgnoringCase("The changes were saved.", Driver.getSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            CareersPage.ClickArchiveButtonforRecord_Regression_Scale1();
            StringAssert.AreEqualIgnoringCase("The item was archived.", Driver.getSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("No records found.", CareersPage.ProficiencyScaleTab.VerifyNoRecordsFoundisDsiplayed(), "Error message is different");
            CareersPage.ClickLink_ViewArchivedScales();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifyArchivedProficiencyScale(), "Error message is different");
            CareersPage.ProficiencyScaleTab.VerifyArchivedScaleisDeleted();
            ArchivedScale = true;
        }
        [Test, Order(20), Description("Dependent on 47")]
        public void a20_Test_when_User_can_archive_proficiency_scales_from_the_tab_32400()

        {
            Assert.IsTrue(ArchivedScale);
        }
        [Test, Order(21)]
        public void a21_Test_when_User_can_copy_proficiency_scales_from_the_tab_32399()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.CreateNewProficencyScale("Scale_" + Meridian_Common.globalnum, "1", "2", "3");

            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            CareersPage.ClickCopyButtonforRecord_Regression_Scale1();
            CareersPage.FrameCareers.EditTitle("Regression_Scale2");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Copy of Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");

            CareersPage.SearchTextBox("Copy of Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Copy of Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.Searchbutton();
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifySearchResultsisMatchedWith("Copy of Scale_" + Meridian_Common.globalnum, "Scale_" + Meridian_Common.globalnum));
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.Searchbutton();
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyScaleisDeleted(2));
        }
        [Test, Order(22)]
        public void a22_Test_when_User_can_edit_proficiency_scales_from_the_tab_32398()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.CreateNewProficencyScale("Scale_" + Meridian_Common.globalnum, "1", "2", "3");

            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            CareersPage.ClickEditButtonforRecord_RegressionScale();
            CareersPage.ProficiencyScaleTab.ProficiencyScaleModal.EditProficiencyScale("EditScale", "4", "5", "6");
            // CareersPage.FrameCareers.EditTitle("Regression_Scale1");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("EditScale");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("EditScale", CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyScaleisDeleted(1));
        }
        [Test, Order(24)]
        public void a24_Delete_Job_Title_22213()
        {
            CareersPage.CreateJobTitle(JobTitle + "Delete");
            _test.Log(Status.Info, "A new job Title Created");
            CareersPage.DeleteJobTitle(JobTitle + "Delete");
            _test.Log(Status.Info, "Created job title searched and deleted");
            Assert.IsTrue(CareersPage.JobTitlesTab.Nomatchingrecordsfound());
            _test.Log(Status.Pass, "Verify job title is deleted");

        }
        [Test, Order(29)]
        public void P20_1_R_User_sees_an_indicator_of_an_extension_being_granted_for_training_in_25202()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_Extendedtraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string extension_being_grantedTraining = driver.gettextofelement(By.Id("ctl00_MainContent_UC3_RadGrid1_ctl00__0"));
            StringAssert.Contains("Extended", extension_being_grantedTraining);
        }
        [Test, Order(27)]
        public void P20_1_S_User_views_Due_Soon_label_for_due_soon_training_23663()
        {
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_DueSoonTraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string DueSoonStatus = driver.gettextofelement(By.CssSelector("div[id*='_pnlDueDate']"));
            StringAssert.Contains("Due Soon", DueSoonStatus);
        }
        [Test]
        public void P20_1_Q_User_can_hide_non_required_training_25498()
        {
            TrainingHomeobj.click_currenttraining();
            driver.GetElement(By.CssSelector("input[id*='_btnReset']")).ClickWithSpace();
            Thread.Sleep(3000);
            CurrentTrainingsobj.Click_blogType(browserstr);
            CurrentTrainingsobj.course_dropdown();

            CurrentTrainingsobj.hidebtn_click();
            Thread.Sleep(3000);
            driver.GetElement(By.CssSelector("button[data-bb-handler='confirm']")).Click();
            //driver.SwitchTo().Alert().Accept();
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("Your content has been hidden. It is still available on your transcript.", successMsg);
        }
        [Test, Order(76)]
        public void Admin_bulk_removes_tags_on_manage_content_page_34044()
        {
            //login with a admin 
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Manage Content Search page");
            TrainingPage.SearchRecord("");
            _test.Log(Status.Info, "Click Search page");
            ManageContentPage.SelectMultipleResult();
            ManageContentPage.RemoveTag();
            _test.Log(Status.Info, "Select Multiple records and click Remove tag and select DV_Test1 Tag");
            StringAssert.AreNotEqualIgnoringCase("DV_Test1", ManageContentPage.VerifyTags("DV_Test1"));
            _test.Log(Status.Info, "Verify that Tag DV_Test1 is removed from all selected items under Tags column");

        }
      
        [Test, Order(1)]

        public void Z01_User_Views_Section_Gradebook_via_section_Tab_33774()
        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33774");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33774");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33774"));
            //  Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");
            //  Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            //   _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");
            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");
            #endregion

        }

      //  [Test, Order(2)] depreceated in 19.1 test plan

        public void Z02_User_Views_Section_Gradebook_via_Instructor_Tool_33776()
        {
            #region create new course and Access The Gradebook From Instructor Tool Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33776");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33776");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33776"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            //   Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            #endregion
            CommonSection.Manage.Training();
            CommonSection.Manage.TrainingPage.InstructorTool();
            InstructorsPage.Click_ManageStudent();
            InstructorsPage.Search_ForSection_InManageStudentPage(classroomcoursetitle + "TC33776");
            InstructorsPage.Click_Expand_SectionDetail();
            Assert.IsTrue(InstructorsPage.Click_GradebookConsole());
            //InstructorsPage.Search_ForSection(classroomcoursetitle + "TC33776");
            // InstructorsPage.Open_SectionDetail();

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Manage Gradebook Button is Visible");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook accessible Available from Instructor Tool Page");

        }

        [Test, Order(3)]

        public void Z03_User_Views_Gradebook_via_Manage_Students_Tab_33780()
        {
            #region create new course and Access The Gradebook From Manage Student
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33780");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33780");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33780"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            //   Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            #endregion
            CommonSection.Manage.Training();
            CommonSection.Manage.TrainingPage.InstructorTool();
            InstructorsPage.Click_ManageStudent();
            InstructorsPage.Search_ForSection_InManageStudentPage(classroomcoursetitle + "TC33780");

            Assert.IsTrue(InstructorsPage.Click_SectionTitle_FrommanageStudentPage(SectionTitle + "TC33780"));
            _test.Log(Status.Pass, "Assertion Pass Manage Gradebook Button is Visible");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook accessible Available from Instructor Tool Page");
        }
        [Test, Order(4)]

        public void Z04_User_Views_Gradebook_via_Teaching_Schedule_Tab_33782()
        {
            #region create new course and Access The Gradebook From Teaching Schedule
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33782");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33782");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.SelectInstructor();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33782"));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            #endregion
            CommonSection.Manage.Training();
            CommonSection.Manage.TrainingPage.InstructorTool();
            Assert.IsTrue(InstructorsPage.Expand_SectionDetail());
            _test.Log(Status.Pass, "Assertion Pass Manage Gradebook Button is Visible");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook accessible Available from Instructor Tool Training Schedule");
        }

        [Test, Order(5)]

        public void Z05_User_Adds_Location_when_creating_classroom_course_33786()
        {
            #region create new course with Location
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33786");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33786");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.SelectLocation();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33786"));
            _test.Log(Status.Pass, "Assertion Pass : As Section Created With Location");

            #endregion
        }


        [Test, Order(6)]

        public void Z06_User_defines_Access_Key_purchase_period_while_creating_classroom_33711()
        {
            #region Create New Classroom Course With Access Keys Enabled and Cost
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33711");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Enable_AccessKeys();
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33711");
            ManageClassroomCoursePage.SetEnrollmentStartDate(string.Format("{0:MM/dd/yyyy}", DateTime.Today));
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            ManageClassroomCoursePage.SelectUseWaitlist("");

            ManageClassroomCoursePage.SetAccessKeys_Custom();
            _test.Log(Status.Pass, "Setting Access Keys with Custom Date Range");

            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "Section has been Created");

            ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33711");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            ManageClassroomCoursePage.SectionDetailTab();

            ManageClassroomCoursePage.Set_Cost();
            _test.Log(Status.Pass, "Setting Cost For Section");
            #endregion
            #region Purchase Keys for Classroom Course Section
            CommonSection.Learn.Home();
            CommonSection.CatalogSearchText(classroomcoursetitle + "TC33711");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33711");

            ClassroomCourseDetailsPage.addToCart();
            _test.Log(Status.Pass, "User Purchasing The Classroom Course");

            OrderPage.Click_Purchased_Content(classroomcoursetitle + "TC33711" + " - " + SectionTitle + "TC33711");
            _test.Log(Status.Pass, "Click on Purchased Classroom Course Section From Order Detail Page");

            Assert.IsTrue(OrderPage.Verify_PurchasedAccessKey(classroomcoursetitle + "TC33711" + " - " + SectionTitle + "TC33711"));
            _test.Log(Status.Pass, "Assertion : Pass as User Successfully Purchased Access Keys for Classroom Course Section");
            #endregion
        }

        [Test, Order(7)]

        public void Z07_User_Sets_learner_Attendance_through_Section_GradeBook_33778()
        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33778");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33778");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33778"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            //  Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion
            ManageClassroomCoursePage.Set_LearnerAttendance_toYES();
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-dismissible alert-fixed alert-success']"));
            ManageClassroomCoursePage.Set_LearnerAttendance_toNo();
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-dismissible alert-fixed alert-success']"));
            ManageClassroomCoursePage.Set_Progress_To_NoShow();
            ManageClassroomCoursePage.Set_LearnerAttendance_toYES();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-dismissible alert-fixed alert-danger']")));
            _test.Log(Status.Pass, "Assertion Pass as content Progress is 'No Show' and user can not mark attendance");


        }

        [Test, Order(8)]
        public void Z08_User_Sets_Learner_progress_from_section_Gradebook_33784()

        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33784");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33784");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33784"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");


        }

        [Test, Order(9)]
        public void Z09_User_Exports_Section_Enrollment_to_Excel_from_gradebook_33790()

        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33790");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33790");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33790"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");

            Assert.IsTrue((ManageClassroomCoursePage.ExportToExcel()));
            _test.Log(Status.Pass, "Assertion Pass as Export to Excel window has been open and verified");



        }

        [Test, Order(10)]
        public void Z10_User_Prints_Signin_Sheet_from_Section_Gradebook_33788()

        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33788");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33788");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33788"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");

            Assert.IsTrue((ManageClassroomCoursePage.PringtSighInSheet(classroomcoursetitle + "TC33788")));
            _test.Log(Status.Pass, "Assertion Pass as Print Screen has been open and verified");


        }

        [Test, Order(11)]
        public void Z11_Admin_User_Enters_Learner_Score_from_Section_Gradebook_33849()

        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33849");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33849");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33849"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");

            Assert.IsTrue((ManageClassroomCoursePage.Set_Score()));
            _test.Log(Status.Pass, "Assertion Pass as Score Has been Entered and Submitted with upto 2 decimal value");


        }

        [Test, Order(12)]
        public void Z12_Admin_User_Filters_Gradebook_by_User_33895()

        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33895");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33895");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33895"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");

            Assert.IsTrue((ManageClassroomCoursePage.Filter_User()));
            _test.Log(Status.Pass, "Assertion Pass as User filtered correctly");


        }

        [Test, Order(13)]
        public void Z13_Admin_User_Create_a_Section_Assignment_33945()

        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33945");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33945");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33945"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");
            ManageClassroomCoursePage.Click_ContentTab();


            Assert.IsTrue((ManageClassroomCoursePage.Create_Assignment("Assignment_1")));
            _test.Log(Status.Pass, "Assertion Pass as Assignment has been created");


        }

        [Test, Order(14)]
        public void Z14_Authorized_User_Grades_Individual_Assignment_from_Section_Gradebook_33946()
        {

            #region create new course and Access The Gradebook From Section Detail Page

            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Pass, "Opened Create Classroom Course Page");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33946");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33946");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33946"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");
            ManageClassroomCoursePage.Click_ContentTab();
            Assert.IsTrue((ManageClassroomCoursePage.Create_Assignment("Assignment_1")));
            _test.Log(Status.Pass, "Assertion Pass as Assignment has been created");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            Assert.IsTrue(ManageClassroomCoursePage.Grade_Individual_Assignment());
            _test.Log(Status.Pass, "Assertion Pass as Assignment Grading has been submitted");

        }

        [Test, Order(15)]

        public void Z15_User_Navigates_to_Empty_Content_Tab_33955()
        {
            #region create new course and Access The Empty Manage Content Tab From Instructor Tool Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33955");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33955");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33955"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            //   Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            #endregion
            CommonSection.Manage.Training();
            CommonSection.Manage.TrainingPage.InstructorTool();
            InstructorsPage.Click_ManageStudent();
            Assert.IsTrue(InstructorsPage.Search_ForSection_ManageStudent(classroomcoursetitle + "TC33955"));

            _test.Log(Status.Pass, "Assertion Pass as Empty Content Page accessed successfully from instructor tool");
        }

        [Test, Order(16)]

        public void Z16_Instructor_Navigates_to_Content_Tab_from_Instructor_tools_33954()
        {
            #region create new course and Access The Empty Manage Content Tab From Instructor Tool Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33954");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33954");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33954"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            //   Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            #endregion
            CommonSection.Manage.Training();
            CommonSection.Manage.TrainingPage.InstructorTool();
            InstructorsPage.Click_ManageStudent();
            Assert.IsTrue(InstructorsPage.Search_ForSection_ManageStudent(classroomcoursetitle + "TC33954"));

            _test.Log(Status.Pass, "Assertion Pass as Content Page accessed successfully from instructor tool");
        }

        [Test, Order(17)]

        public void Z17_User_Removes_Classroom_Course_Section_Content_33957()
        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33957");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33957");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33957"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            #endregion

            ManageClassroomCoursePage.Set_Progress_To_NoShow();

            Assert.IsTrue(ManageClassroomCoursePage.Set_Progress_To_Completed());
            _test.Log(Status.Pass, "Assertion Pass as content Progress is set to Completed");
            ManageClassroomCoursePage.Click_ContentTab();
            Assert.IsTrue((ManageClassroomCoursePage.Create_Assignment("Assignment_1")));
            _test.Log(Status.Pass, "Assertion Pass as Assignment has been created");

            CommonSection.Manage.Training();
            CommonSection.Manage.TrainingPage.InstructorTool();
            InstructorsPage.Click_ManageStudent();
            InstructorsPage.Search_ForSection_ManageStudent(classroomcoursetitle + "TC33957");
            _test.Log(Status.Pass, "Content Page accessed successfully from instructor tool");

            Assert.IsTrue(ManageClassroomCoursePage.Remove_Content());
            _test.Log(Status.Pass, "Assertion Pass as Content has been removed from section");

        }

        [Test, Order(18)]

        public void Z18_Instructor_Navigates_to_Section_Details_via_Gradebook_33913()
        {
            #region create new course and Access The Section Detail From Gradebook Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33913");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33913");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33913"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            ManageClassroomCoursePage.SectionDetailTab();
            _test.Log(Status.Pass, "Navigating to section detail tab");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_SectionDetilPage());
            _test.Log(Status.Pass, "Assertion Pass as Section Detail has been accessed from gradebook page and section date time is read only");

            #endregion
        }
        [Test, Order(20)]
        public void Z20_Admin_User_Adds_a_Piece_of_Content_to_A_Section_Content_Tab_33993()
        {
            #region create new course and Access The Section Detail From Gradebook Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33993");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33993");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33993"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            SectionDetailsPage.ClickContentTab();

            Assert.IsTrue(ManageClassroomCoursePage.Add_Content());
            Assert.IsFalse(Driver.Instance.IsElementVisible(By.XPath("//strong[contains(.,'No content has been added.')]")));
            _test.Log(Status.Pass, "Assertion Pass as Content has been added into section");
            #endregion
        }

        [Test, Order(21)]

        public void Z21_All_Instructor_Should_Have_Access_To_Added_Contents_of_Section_33994()
        {
            #region create new course and Access The Empty Manage Content Tab From any Instructor from Instructor Tool Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33994");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC33994");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC33994"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");

            //   Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            #endregion
            CommonSection.Manage.Training();
            CommonSection.Manage.TrainingPage.InstructorTool();
            InstructorsPage.Click_ManageStudent();
            Assert.IsTrue(InstructorsPage.Search_ForSection_ManageStudent(classroomcoursetitle + "TC33994"));

            _test.Log(Status.Pass, "Assertion Pass as any instructor can access classroom course section from instructor tool");
        }

        [Test, Order(1)]
        public void b01_Manage_Enrollment_for_Classroom_from_details_page_3700()
        {
            // CommonSection.Logout();
            //  LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it and enroll

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Enrollment");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            //_test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            _test.Log(Status.Pass, "Verify Enrollment is display");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll");
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg");
            Assert.IsTrue(EnrollmentPage.EnrollmentTab.isuserEnrolled());
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Enrollment");

            #endregion
        }
        [Test, Order(2)]

        public void b02_Make_Section_File_Available_To_Learners_33972()
        //Prerequieite - File is added to the Section
        {
            #region create new course, add section to it and enroll

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Section");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.UploadFile();
            //Assert.IsTrue(SectionDetailsPage.ContentTab.UpLoadFileModalIsClosed); //Verify Upload File modal is closed
            //_test.Log(Status.Pass, "Verify Upload Files Modal is closed");

            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFiles); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing file
            _test.Log(Status.Info, "Click on Availavle To Learner dropdown link ");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("No"));
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("Yes, when learner enrolls"));
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("Yes, when section starts"));
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("Yes, when section ends"));
            _test.Log(Status.Pass, "Varify all dowpdown list text");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("Yes, when learner enrolls")); //Verified the "Yes, when learner enrolls" option is displayed
            _test.Log(Status.Pass, "Verify option text has been updated");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Section");

        }
        [Test, Order(3)]

        public void b03_Make_Section_Note_Available_To_Learners_33974()
        //Prerequisite - Note is added to the Section
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Note");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFirstNotes);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing Note
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify option text has been updated");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Note");
        }
        [Test, Order(4)]

        public void b04_Make_Section_Assignment_Available_To_Learners_34000()
        //Prerequisite - Assignment is added to the section
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            //Assert.IsTrue(SectionContentPage.List.Type.Files); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            //Assert.IsTrue(SectionContentPage.List.Type.Notes);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt);// Verify Assignment associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("No"));
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different"); //Verified the "Yes, when learner enrolls" option is displayed
            _test.Log(Status.Pass, "Verify option text has been updated");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment");

        }
        [Test, Order(5)]

        public void b05_Edit_Assignment_Grading_Settings_When_There_Are_No_Submissions_And_Not_Graded_34015()
        //Prerequisite - Learner has enrolled in a Classroom course
        // Assignment has been made available to Learners and there are no assignment submissions
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment1");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            #endregion

            string GradingCompletionColumnvalue = ContentPage.ContentTab.GradingCompletionColumnValue();
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt);// Verify Assignment associated with that section is displayed and can be viewed by clicking on them
            ContentPage.ContentTab.ClickGradingCompletionColumnForAssignment(); // Click on the Grading column cell in for an existing Assignment
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.GradingScaledisplay());// Verify Edit Assignment Modal is displayed with Grading Scale field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field

            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("3"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.GradingScaleEditAs("Pass/Fail"); //Update the Grading Scale
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("28/08/18"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
            _test.Log(Status.Info, "Insert data into all three fields and Click on Save");
            Assert.IsFalse(ContentPage.ContentTab.EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            _test.Log(Status.Pass, "Verify EditAssignmentModal is Closed");
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(GradingCompletionColumnvalue));// Verify Grading Completion for the Assignment is updated
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment1");
        }


        [Test, Order(6)]

        public void b06_Edit_Assignment_Grading_Settings_When_There_Are_Submissions_And_Not_Graded_34013()
        //Prerequisite - Learner has enrolled in a Classroom course
        // Assignment has been made available to Learners and Learner has submitted the assignment, but not graded
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment2");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            #endregion
            string GradingCompletionColumnvalue = ContentPage.ContentTab.GradingCompletionColumnValue();

            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            _test.Log(Status.Pass, "Verify Added assignment is display");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            ContentPage.ContentTab.ClickGradingCompletionColumnForAssignment();  // Click on the Grading column cell in for an existing Assignment
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.GradingScaledisplay());// Verify Edit Assignment Modal is displayed with Grading Scale field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("3"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.GradingScaleEditAs("Pass/Fail"); //Update the Grading Scale
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("28/09/18"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
            _test.Log(Status.Info, "Insert data into all three fields and Click on Save");
            Assert.IsFalse(ContentPage.ContentTab.EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            _test.Log(Status.Pass, "Verify EditAssignmentModal is Closed");
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(GradingCompletionColumnvalue));// Verify Grading Completion for the Assignment is updated
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment2");                                                                                                  // Verify Grading Completion for the Assignment is updated

        }

        [Test, Order(7)]

        public void b07_Edit_Assignment_Grading_Settings_When_There_Are_Submissions_And_Graded_34014()
        //Prerequisite - Learner has enrolled in a Classroom course
        // Assignment has been made available to Learners and Learner has submitted the assignment, and has been graded
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment3");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            #endregion
            string GradingCompletionColumnvalue = ContentPage.ContentTab.GradingCompletionColumnValue();
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            _test.Log(Status.Pass, "Verify Added assignment is display");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            ContentPage.ContentTab.ClickGradingCompletionColumnForAssignment(); // Click on the Grading column cell in for an existing Assignment
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with editable Due Date field
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
            Assert.IsFalse(ContentPage.ContentTab.EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            _test.Log(Status.Pass, "Verify EditAssignmentModal is Closed");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment3");
        }
        [Test, Order(8)]
        public void b08_User_views_location_schedule_while_adding_location_to_a_classroom_course_section_33911()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as an Admin User");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "location");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.EnterStartDateAndTime("08/15/2019");
            _test.Log(Status.Info, "Enter Start date");
            ManageClassroomCoursePage.EnterEndDateAndTime("08/15/2019");
            _test.Log(Status.Info, "Enter End date");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click on Waitlist as Yes");
            ManageClassroomCoursePage.ClickSelectLocationButton();
            _test.Log(Status.Info, "Click on Select Location Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectLocationModaldisplay());
            _test.Log(Status.Pass, "Select Location Modal is display");
            ManageClassroomCoursePage.SelectLocationModal.ClickViewSchedule();
            _test.Log(Status.Info, "Click on view schedule");
            Assert.IsTrue(ManageClassroomCoursePage.SelectLocationModal.LocationCalenderModal.ModalisDisplay());
            _test.Log(Status.Pass, "Verify Location Calender modal is display");
            ManageClassroomCoursePage.SelectLocationModal.LocationCalenderModal.CloseModal();
            ManageClassroomCoursePage.SelectLocationModal.CloseModal();
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "location");

        }
        [Test, Order(9)]
        public void b09_User_Adds_Instructor_while_creating_a_classroom_course_34064()
        {

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Instructor");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Verify Select Instructor modal is display");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("site");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            _test.Log(Status.Pass, "Verify Added instructor display bellow Select Instructor button");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button again");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Verify Select Instructor modal is display");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            _test.Log(Status.Pass, "Verify Added instructor display bellow Select Instructor button");
            ManageClassroomCoursePage.removeinstructors();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            _test.Log(Status.Info, "No Instructor display on screen");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Instructor");

        }

        [Test, Order(10)]
        public void b10_User_edits_note_from_section_content_tab_33958()
        {
            #region Create classroom, then section adding instructor and note
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33958");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");

            ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click on Waitlist as Yes");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            String NotesTitle = "For Test";
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith(NotesTitle);// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC33958");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "TC33958");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(GradebookPage.GradebookTabDisplay());
            GradebookPage.clickContentTab();
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            // _test.Log(Status.Pass, "Verify Content tab is display");
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");
            NotesTitle = ContentPage.ContentTab.NotesTitleText();
            ContentPage.ContentTab.ClickNotesTitle();
            Assert.IsTrue(ContentPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            ContentPage.ContentTab.AddNoteModal.AddNoteswith("For Test Updated3");
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsTrue(ContentPage.ContentTab.NotesTitleUpdated(NotesTitle));
            _test.Log(Status.Pass, "Verify notes title is updated");

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC33958");

        }
        [Test, Order(11)]
        public void b11_User_Edits_assignments_from_section_content_tab_33959()
        {
            #region Create classroom, then section adding instructor and note
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login as an Admin User");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33959");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click on Waitlist as Yes");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");

            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            ContentPage.ContentTab.AddAssignmentAs("Test");
            _test.Log(Status.Info, "Assignment added successfully");

            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC33959");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "TC33959");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(GradebookPage.GradebookTabDisplay());
            GradebookPage.clickContentTab();

            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");
            String AssignmentTitle = ContentPage.ContentTab.AssignmentTitleText();
            ContentPage.ContentTab.ClickAssignmentTitle();
            //            Assert.IsTrue(ContentPage.ContentTab.AddNoteModaldisplay());
            //      _test.Log(Status.Pass, "Add Note Modal is opened");
            ContentPage.ContentTab.UpdateAssignmentAs("Test Updated");
            _test.Log(Status.Info, "Assignment Title updated successfully");
            Assert.IsTrue(ContentPage.ContentTab.NotesTitleUpdated(AssignmentTitle));
            _test.Log(Status.Pass, "Verify Assignment title is updated");

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC33959");
        }
        [Test, Order(12)]
        public void b12_User_makes_section_content_avialable_to_learners_Learner_has_no_access_34066()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it and enroll
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34066");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Admin user logged out successfully");
            #endregion

            #region Login with instructor and add content to created section.

            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34066");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");

            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            // ContentPage.ContentTab.AddAssignmentAs("Test");
            ContentPage.ContentTab.AddAssignmentAs("Test" + Meridian_Common.globalnum);//Added by Aafreen

            _test.Log(Status.Info, "Assignment added successfully");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("No"));



            #endregion
            #region Login with a Learner search created classroom course and enroll
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34066" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34066");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC34066"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            Assert.IsFalse(ContentDetailsPage.CheckAssignmentPanel());
            _test.Log(Status.Pass, "Assignment Panel is not display");

            #endregion
        }
        [Test, Order(13)]
        public void b13_User_makes_section_content_avialable_to_learners_Learner_has_Access_when_enrolled_34067()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it and enroll
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34067");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Admin user logged out successfully");
            #endregion

            #region Login with instructor and add content to created section.

            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34067");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");

            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            ContentPage.ContentTab.AddAssignmentAs("Test" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "Assignment added successfully");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("Yes, when learner enrolls"));


            #endregion
            #region Login with a Learner search created classroom course and enroll
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34067" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34067");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC34067"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            Assert.IsTrue(ContentDetailsPage.CheckAssignmentPanel());
            _test.Log(Status.Pass, "Assignment Panel is not display");

            #endregion
        }
        [Test, Order(14)]  //Depend on 34067

        public void b14_As_Instructor_View_Files_And_Notes_For_Classroom_Sections_33932()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login(); //Login as Instructor
            CommonSection.Manage.Training();
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules);//Verify Teaching Schedule page is displyed with list of Sections
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34067"); //Click on Expand Row (+) for one of the section (where there are already Files and Notes)
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.SectionScheduleExpanded);
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");//Verify Files and Notes page for the sections is displayed with associated Notes and Files
            ContentPage.ContentTab.ClickAssignmentTitle();
            Assert.IsTrue(ContentPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");// Verify the File opens and can be viewed

        }
        [Test, Order(16)]
        public void b16_Learner_views_and_complets_course_section_assignment_33967()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it, add Assignment and enroll once user
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33967");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");

            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            SectionDetailsPage.ClickContentTab();
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            ContentPage.ContentTab.AddAssignmentAs("Test");
            _test.Log(Status.Info, "Assignment added successfully");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("Yes, when learner enrolls"));
            #endregion

            #region Login with a Learner search created classroom course and enroll
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33967" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33967");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC34067"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            Assert.IsTrue(ContentDetailsPage.CheckAssignmentPanel());
            _test.Log(Status.Pass, "Assignment Panel is not display");
            Assert.IsTrue(ContentDetailsPage.AssignmentWork.SubmitAssignment("Test", "Des"));
            _test.Log(Status.Pass, "Assignment Panel is not display");

            #endregion

        }
        [Test, Order(17)]
        public void b17_Make_Scorm_12_Course_Gradeable_34046()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            //StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            //CommonSection.Manage.Training();//editted: line was not here.
            TrainingPage.ClickSearchRecord("Classroom Course");
            //          StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }

        [Test, Order(18)]

        public void b18_Make_Scorm_2004_Course_Gradeable_34047()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }

        [Test, Order(19)]

        public void b19_Make_General_Course_Gradeable_34048()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }
        [Test, Order(20)]

        public void b20_User_Make_Test_Gradeable_34071()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }

        [Test, Order(21)]

        public void b21_Make_AICC_Course_Gradeable_34049()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }
        [Test, Order(22)]

        public void b22_Remove_Gradeable_Test_From_A_Section_34054()
        // Prequisite:  As one Learner view and complete the test that is associated with course section
        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.isTestDisplayed(""));
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isTestDisplayed());
            GradebookPage.GradebookTab.ClickContentTab();// Verify Test associated with that section is displayed
            ContentPage.ContentTab.DeleteContent(); //Select a checkbox of an existing Test and click on Delete button
            //Assert.IsTrue(ConfirmBox.String "Are you sure you want to remove the selected items?");
            //ConfirmBox.SelectRemove();
            StringAssert.AreEqualIgnoringCase("The item was removed", Driver.getSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            Assert.False(ContentPage.ContentTab.isTestDisplayed("")); //Verify the Test is removed from the Content Tab
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isTestDisplayed());//Verify the Test column is removed from gradebook
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());//Verify the Test Score is removed from the Final Score in Gradebook
            CommonSection.Logout();
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();//login with the user that has completed taken the test
            CommonSection.Transcript(); ; //Access the Transcript All My Training page
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isTestDisplayed("Test")); // Verify the completed test is NOT removed from User's transcript
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
            TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
            Assert.IsTrue(ContentDetailsPage.isScoreUpdated()); // Verify the test no longer count towards score.
        }
        [Test, Order(23)]

        public void b23_Remove_Gradeable_General_Course_From_A_Section_34056()
        // Prequisite:  As one Learner view and complete the General Course that is associated with course section


        // Prequisite:  As one Learner view and complete the test that is associated with course section
        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.isGeneralCourseDisplayed(""));
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isGeneralCoursetDisplayed());
            GradebookPage.GradebookTab.ClickContentTab();// Verify Test associated with that section is displayed
            ContentPage.ContentTab.DeleteContent(); //Select a checkbox of an existing Test and click on Delete button
            StringAssert.AreEqualIgnoringCase("The item was removed", Driver.getSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            Assert.False(ContentPage.ContentTab.isGeneralCourseDisplayed("")); //Verify the Test is removed from the Content Tab
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isGeneralCoursetDisplayed());//Verify the Test column is removed from gradebook
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());//Verify the Test Score is removed from the Final Score in Gradebook
            CommonSection.Logout();
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();//login with the user that has completed taken the test
            CommonSection.Transcript(); ; //Access the Transcript All My Training page
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isGeneralCOurseDisplayed("GC")); // Verify the completed test is NOT removed from User's transcript
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
            TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
            Assert.IsTrue(ContentDetailsPage.isScoreUpdated()); // Verify the test no longer count towards score.
        }

        [Test, Order(24)]

        public void b24_Remove_Gradeable_Scorm_2004_Course_From_A_Section_34075()
        // Prequisite:  As one Learner view and complete the Scorm 2004 course that is associated with course section

        // Prequisite:  As one Learner view and complete the test that is associated with course section
        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.isScormCourse2004tDisplayed(""));
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isScormCourse2004tDisplayed());
            GradebookPage.GradebookTab.ClickContentTab();// Verify Test associated with that section is displayed
            ContentPage.ContentTab.DeleteContent(); //Select a checkbox of an existing Test and click on Delete button
            //Assert.IsTrue(ConfirmBox.String "Are you sure you want to remove the selected items?");
            //ConfirmBox.SelectRemove();
            StringAssert.AreEqualIgnoringCase("The item was removed", Driver.getSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            Assert.False(ContentPage.ContentTab.isScormCourse2004tDisplayed("")); //Verify the Test is removed from the Content Tab
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isScormCourse2004tDisplayed());//Verify the Test column is removed from gradebook
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());//Verify the Test Score is removed from the Final Score in Gradebook
            CommonSection.Logout();
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();//login with the user that has completed taken the test
            CommonSection.Transcript(); ; //Access the Transcript All My Training page
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isScormCourse2004tDisplayed("Scorm 2004")); // Verify the completed test is NOT removed from User's transcript
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
            TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
            Assert.IsTrue(ContentDetailsPage.isScoreUpdated()); // Verify the test no longer count towards score.
        }

        [Test, Order(25)]

        public void b25_Learner_Views_Section_File_34004()   //Depend on 33918
        //Prerequisite - Learner has enrolled in a Classroom course
        // File has been made available to Learners

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34004");
            _test.Log(Status.Info, "New Classroom Course Created");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.UploadFile();
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFiles); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing file
            _test.Log(Status.Info, "Click on Availavle To Learner dropdown link ");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login(); //Login as regular user (Learner)
            _test.Log(Status.Info, "Login with lerner");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34004" + '"');
            _test.Log(Status.Info, "Search" + classroomcoursetitle + "TC34004" + "from Cataloh Search");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34004");
            _test.Log(Status.Info, "Click on Searched catalog title");
            // HomePage.CurrentTrainingSection.ClickClassroomCourseTitle("Classroom Course");//Click on the Classroom Course Title
            Assert.IsTrue(ContentDetailsPage.MatchCatalogName(classroomcoursetitle + "TC34004")); // Verify the Content Details Page is displayed
            _test.Log(Status.Pass, "Verify searched catalog title in Content details page");
            ContentDetailsPage.ClickEnrollButton();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsFiledisplayed()); //Verify the Files Associated to the Section is displayed
            _test.Log(Status.Pass, "Verify attached file/notes display into Course Material area");
            ContentDetailsPage.CourseMaterials.ClicktoOpenFile(); //Click on Open for a File
            _test.Log(Status.Info, "Click Open button to open Attached file");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.FileOpened()); //Verify the File is opened
            _test.Log(Status.Pass, "Verify file is opend");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.FileStatus("Open"));
            _test.Log(Status.Pass, "Verify attched file/notes status is Open");
        }

        [Test, Order(26)]

        public void b26_Learner_Views_Section_Note_34009()
        ////Prerequisite - Learner has enrolled in a Classroom course
        //// Note has been made available to Learners

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Note");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");

            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFirstNotes);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing Note
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login(); //Login as regular user (Learner)
            _test.Log(Status.Info, "Login with lerner");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "Note" + '"');//Click on the Classroom Course Title
            _test.Log(Status.Info, "Search" + classroomcoursetitle + "Note" + "from Cataloh Search");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "Note"); // Verify the Content Details Page is displayed
            _test.Log(Status.Info, "Click on Searched catalog title");
            Assert.IsTrue(ContentDetailsPage.MatchCatalogName(classroomcoursetitle + "Note")); // Verify the Content Details Page is displayed
            _test.Log(Status.Pass, "Verify searched catalog title in Content details page");
            ContentDetailsPage.ClickEnrollButton();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsNoteDisplayed()); //Verify the Notes Associated to the Section is displayed
            _test.Log(Status.Pass, "Verify attached file/notes display into Course Material area");
            ContentDetailsPage.CourseMaterials.ClickToOpenNote(); //Click on Open for a Note
            _test.Log(Status.Info, "Click Open button to open Attached file");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsNoteModaldisplay()); //Verify the Note modal is opened
            _test.Log(Status.Pass, "Verify Notes Modal is opend");
            ContentDetailsPage.CourseMaterials.NoteModal.ClickClose(); //Close the Note
            _test.Log(Status.Info, "Click close button in note modal");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsNoteModalIsClosed()); // Verify the Note modal is Closed
            _test.Log(Status.Pass, "Verify Note modal is closed");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.FileStatus("Open"));
            _test.Log(Status.Pass, "Verify attched file/notes status is Open");
        }
        [Test, Order(3)]

        public void a03_User_View_Section_Date_Time_in_Read_Only_Format_Only_33668()
        {
            #region Create Classroom Course With Adding Notes
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Success Message Verified");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "New Section Created");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            _test.Log(Status.Info, "Click Manage Enrollment Action");
            ManageClassroomCoursePage.SectionDetailTab();
            _test.Log(Status.Info, "Click on Section Details Tab");
            Assert.IsTrue(ManageClassroomCoursePage.ClickButton_EditSection());
            _test.Log(Status.Pass, "Verify Section Start and End Dates are disabled");

            #endregion
        }
        [Test, Order(5)]
        public void a05_Create_Setion_With_Past_Date_33497()
        {
            #region Create New Course, Add Section with Past Date

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33497");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys("07/15/2018 5:30 PM");
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).SendKeys("07/15/2018 6:30 PM");
            IWebElement webElement = Driver.Instance.GetElement(By.XPath("//button[@id='location_0']"));//You can use xpath, ID or name whatever you like
            webElement.SendKeys(Keys.Tab);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "Click on Create Button");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//label[contains(.,'Complete(1)')]")));
            _test.Log(Status.Pass, "Assertion Pass as Past Date Section not displaying in Grid.");
            #endregion
        }

        [Test, Order(6)]

        public void a06_Admin_User_Add_Remove_Notes_in_Classroom_Course_Section_33705()
        {
            #region Create Classroom Course With Adding Notes


            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33705");
            _test.Log(Status.Pass, "New Classroom Course Created");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Pass, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();

            Assert.IsTrue(ManageClassroomCoursePage.EnterNotes("Testing Notes"));
            _test.Log(Status.Pass, "Assertion Pass - Added Notes into Section");

            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "New Section Created");

            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.ScheduleTab());

            ManageClassroomCoursePage.ClickReadNotesButton();
            _test.Log(Status.Pass, "Read Notes Popup Open.");

            ManageClassroomCoursePage.ClickCloseReadNotePopup();
            _test.Log(Status.Pass, "Read Notes Popup Closed.");

            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC33705");

            #endregion
        }
        [Test, Order(7)]
        public void a07_Create_Setion_With_Different_TimeZone_33501()
        {
            #region Create New Course, Add Section with different timezone

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33501");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectTimeZone();
            ManageClassroomCoursePage.SelectWaitListasYes();

            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            //ManageClassroomCoursePage.CreateSection.Create();

            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            #endregion
            CommonSection.Logout();
            #region Create User and Enroll into above created classroom section
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as a Learner");
            //CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33501" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33501");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC33501"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            CatalogPage.EnrollinClassroomCourse();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass, User Enrolled in Timezone Specific Section");

            #endregion
        }

        [Test, Order(8)]
        public void a08_View_Events_in_Section_Schedule_33511()
        {
            //This Test is to test the format of Events >> Schedule page. 
            //Pre-requisite For this test - Classroom Course, Sections, and Events with and without Location, Tnstructor, Notes are already created
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33511");
            _test.Log(Status.Pass, "New Classroom Course Created");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section 1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Pass, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section page");

            ManageClassroomCoursePage.ClickonSection();
            _test.Log(Status.Info, "Click Section created section title");
            Assert.IsTrue(SchedulePage.ScheduleTabisvisible());
            _test.Log(Status.Pass, "Schedule Tab is displaying");
            SchedulePage.ClickScheduleTab();
            _test.Log(Status.Info, "Click Section Schedule tab");
            //Assert.IsTrue(SectionsDetailsPage.ClickScheduleTab();
            //EventsPage.ScheduleTab.VerifyListofEvents();
            Assert.IsTrue(SchedulePage.ScheduleTab.EventTitlecolumn.EventTitleText()); //Verify Event Title is displayed as link
            _test.Log(Status.Pass, "Verify Event Title on Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Schedulecolumn.EventStartEndDatecolumn()); //Verify right Event Start Date and time is displayed
            _test.Log(Status.Pass, "Verifying Event start date and time in Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Instructorscolumn.Instructorscolumn()); //Verify right Event Instructor is displayed if entered
            _test.Log(Status.Pass, "verifing Instructors column display on Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Locationcolumn.Locationscolumn()); //Verify right Event Location is displayed if entered
            _test.Log(Status.Pass, "Verify Location on Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Notescolumn.IsNotesColumnDisplay());
            _test.Log(Status.Pass, "Verify notes column on Schedule Tab is displaying");
            Assert.IsTrue(SchedulePage.ScheduleTab.CreateNewEventButton);
            _test.Log(Status.Pass, "Verify Create new Event button on Schedule Tab is displaying");
            Assert.IsTrue(SchedulePage.ScheduleTab.BacktoSectionsButton);
            _test.Log(Status.Pass, "Verify Back to Section button on Schedule Tab is displaying");
        }
        [Test, Order(9)]

        public void a09_View_Instructors_Schedule_While_Adding_Instructor_To_A_Classroom_Course_Section_33902()
        //Prerequisite: Event type must be in-person
        {
            // CommonSection.Logout();
            // LoginPage.LoginAs("").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as an Admin User");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33902");
            _test.Log(Status.Info, "New Classroom Course Created");
            // ClassroomCoursePage.EnterDescription("Classroom Course Description");
            // ClassroomCoursePage.EnterKeywords("Classroom Course Keywords").ClickCreateButton();
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.EnterStartDateAndTime("10/15/2019");
            _test.Log(Status.Info, "Enter Start date");
            ManageClassroomCoursePage.EnterEndDateAndTime("10/15/2019");
            _test.Log(Status.Info, "Enter End date");
            ManageClassroomCoursePage.ClickSelectLocationButton();
            _test.Log(Status.Info, "Click on Select Location Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectLocationModaldisplay());
            _test.Log(Status.Pass, "Select Location Modal is display");
            ManageClassroomCoursePage.SelectLocationModal.ClickLocationRadioButton();
            ManageClassroomCoursePage.SelectLocationModal.ClickSet(); //Select the Location by clicking on the Radio button and Select Set
            _test.Log(Status.Info, "Search Location and add it to section");
            Assert.IsTrue(ManageClassroomCoursePage.LocationAdded());// Verify the Location selected in Modal is displayed in the Location field
            _test.Log(Status.Pass, "Location Added to Section");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Select Instructor Modal is display");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search Instructor");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModal.ViewScheduleButton()); //Verify the all the Instructors display View Schedule button
            _test.Log(Status.Pass, "Verify View Schedule Button is display");
            ManageClassroomCoursePage.SelectInstructorModal.ClickViewScheduleButton(); //Select the View Schedule button
            _test.Log(Status.Info, "Click on  View Schedule Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModal.InstructorCalendarModaldisplay());// Verify the Instructor Schedule (Calendar) is displayed
            _test.Log(Status.Pass, "Verify Instructor Calender is display");
            ManageClassroomCoursePage.SelectInstructorModal.CloseInstructorCalendarModal();
            _test.Log(Status.Info, "Verify Instructor Calender is display");
            ManageClassroomCoursePage.SelectInstructorModal.CloseInstructorModal();
            _test.Log(Status.Info, "Close Select Instructoe Modal");
        }
        [Test, Order(10)]

        public void a10_Upload_A_File_To_A_Section_Content_Tab_33918()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33918");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button on Create Section page");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            Assert.IsTrue(SectionsPage.SectionDetailsPageOpened());
            _test.Log(Status.Pass, "Section Details Page is opened");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsFalse(SectionDetailsPage.ContentTab.UploadFilesModaldisplay());
            _test.Log(Status.Pass, "Upload Files Modal is opened");

            SectionDetailsPage.ContentTab.UploadFile();
            Assert.IsFalse(SectionDetailsPage.ContentTab.UpLoadFileModalIsClosed()); //Verify Upload File modal is closed
            _test.Log(Status.Pass, "Verify Upload Files Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFileAdded()); //Verify the File just uploaded is displayed 
            _test.Log(Status.Pass, "Verify Uploaded file is display into Content tab");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
                                                                                                               // StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different"); //Verified the "Yes, when learner enrolls" option is displayed
            _test.Log(Status.Pass, "Verify option text has been updated");

        }
        [Test, Order(11)]

        public void a11_View_Files_And_Notes_In_Section_Content_Tab_33916()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33916");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ManageClassroomCoursePage.SectionsPage.ListofSections);
            _test.Log(Status.Pass, "Verify created section is display");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            //Assert.IsTrue(SectionDetailsPage.FilesAndNotesPanelRemoved); // Verify the Files and Notes Panel from Section Details page is removed
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.UploadFile();
            Assert.IsFalse(SectionDetailsPage.ContentTab.UpLoadFileModalIsClosed()); //Verify Upload File modal is closed
            _test.Log(Status.Pass, "Verify Upload Files Modal is closed");
            SectionDetailsPage.ContentTab.SelectAddNotesFromAddContentdropdown();
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");

            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFiles); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListNotes); // Verify the Note is added and is displayed 
            _test.Log(Status.Pass, "Verify Add Note is display into Content tab");// Verify Notes associated with that section is displayed and can be viewed by clicking on them
                                                                                  // Assert.IsTrue(SectionDetailsPage.ContentTab.NotesTitleXCharactersOfActualNote());//Verify the Note Title is first # of characters of actual note
                                                                                  // Assert.IsTrue(SectionContentPage.List.AddedByColumnRemoved);//Verify "Added By" column is removed from list of Notes and Files
        }
        [Test, Order(12)]

        public void a12_Create_A_Note_On_A_Section_Content_Tab_33926()

        {
            #region Create Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33926");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set Max Entollment Capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Sections Tab ");
            Assert.IsTrue(ManageClassroomCoursePage.SectionsPage.ListofSections);
            _test.Log(Status.Pass, "Verify created section is display");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            Assert.IsTrue(SectionsPage.SectionDetailsPageOpened());
            _test.Log(Status.Pass, "Section Details Page is opened");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Create Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListNoteAdded); // Verify the Note is added and is displayed 
            _test.Log(Status.Pass, "Verify Add Note is display into Content tab");
            SectionDetailsPage.ContentTab.ClickNoteName();//Click on the Note Name in the Section Content page 
            _test.Log(Status.Info, "Click On added note title");
            Assert.IsTrue(SectionDetailsPage.ContentTab.NoteModalOpened);// Verify the Note opens and can be viewed 
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.CloseAddNoteModal();
            _test.Log(Status.Info, "Close Add Note Modal");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
        }
        [Test, Order(13)]
        public void a13_Test_When_User_reserve_Seats_Navigation_9034()
        {
            //LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC9034");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            //ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //_test.Log(Status.Info, "Enter Section Title As Section1");
            CreateNewCourseSectionAndEventPage.CreateSection("Section1", DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"), DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
            // ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("05");
            // _test.Log(Status.Info, "Set Max Entollment Capacity as 05");

            // // ManageClassroomCoursePage.SelectWaitListasYes();
            // //   _test.Log(Status.Info, "Click Waitlist as Yes");
            // ManageClassroomCoursePage.CreateSection.Create();
            // _test.Log(Status.Info, "Click Create Button");
            //// StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different");
            // ManageClassroomCoursePage.Clicktab("Sections");
            // _test.Log(Status.Info, "Click on Sections tab");

            ManageClassroomCoursePage.Sectionsdropdown.SelectManageoption("Reserved Seats");
            ManageClassroomCoursePage.Enrollmenttab.ReservedSeatsbutton();
            _test.Log(Status.Info, "Validate a new Modal opens with a search box and search results are displayed ");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollmenttab.ReserveSeatsModelDisplay());
            //EnrollmentPage.ClickReservedSeatsButton();
            _test.Log(Status.Info, "Validate a new Modal opens with a search box and search results are displayed ");
            ManageClassroomCoursePage.Enrollmenttab.EnrolGrouptoReserveSeats("user");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollmenttab.Groupdisplayintoreservetab());
            _test.Log(Status.Info, "Validate User has been display in Reserved Tab ");

            //delete added group to make this script rerun.

            ManageClassroomCoursePage.Enrollmenttab.SelectAddedUserGroup();
            ManageClassroomCoursePage.Enrollmenttab.ClickRemove();
            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC9034");
        }
        [Test, Order(16)]
        public void a16_Set_Enrollment_Cancellation_Setting_From_Section_Waitlist_33255()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            #region Create New Course, Add Section with different timezone

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "33255");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();


            _test.Log(Status.Pass, "Click on Create Button");
            #endregion

            #region Enroll Users
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.ClickEnrollButton();
            ManageClassroomCoursePage.SelectCheckBox();
            ManageClassroomCoursePage.ClickEnroll();
            _test.Log(Status.Pass, "User Enrolled into Section");
            #endregion

            #region Waitlist User
            EnrollmentPage.EnrollmentTab.ClickWaitlistedSubTab();
            EnrollmentPage.ClickWaitlistUsersButton();
            EnrollmentPage.SelectCheckBox();//Select few Users
            EnrollmentPage.ClickWaitlistButton();
            _test.Log(Status.Pass, "User Waitlisted into Section");
            #endregion
            //EnrollmentPage.EnrollmentTab.ClickEnrolled();
            //ManageClassroomCoursePage.Enrollmenttab.UpdateAttendanceRequiredfromNotoYes();

            Assert.IsTrue(EnrollmentPage.EnrollmentTab.SelectYes()); //Select the 1st User in the List and make Attendance Required to Yes.  Remember User Name
            _test.Log(Status.Pass, "Assertion Pass : User's Cancel Enrollment Setting has been set");


        }


        [Test, Order(17)]
        public void a17_Test_when_user_navigates_to_section_enrollment_From_sections_listing_33267()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin



            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "33267");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("dv_class1105");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();


            _test.Log(Status.Pass, "Click on Create Button");



            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("dv_class1105"));
            _test.Log(Status.Pass, "Section Created successfully");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Open Training Page");
            //CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');
            //CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);
            TrainingPage.ManageContentSearchText(classroomcoursetitle + "33267").Click();
            _test.Log(Status.Info, "Search Classroom course");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section");
            //TrainingPage. ManageContentSearchText("dv_class1105").click;
            //TrainingPage.click.dv_class1105();
            //dv_class1105.ClickSectionsTab();
            SectionsPage.ClickManageEnrollmentButton();//click manage enrollment button for section 1
            _test.Log(Status.Info, "Click on Manage Enrollment");
            Assert.IsTrue(Driver.comparePartialString("Enrollment", EnrollmentPage.VerifyTab()));
            StringAssert.AreEqualIgnoringCase("There are no enrolled students.", EnrollmentPage.GetDescriptionLink(), "Description does not match");
            _test.Log(Status.Pass, "Verified Enrollment tab and its description");
        }




        [Test, Order(18)]
        public void a18_Manage_Waitlist_from_Sections_listing_for_Completed_Section_and_Enrollment_is_Full_33273()

        {
            #region manage Classroom

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "33223");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();


            _test.Log(Status.Pass, "Click on Create Button");
            #endregion

            #region Enroll Users
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.ClickEnrollButton();
            ManageClassroomCoursePage.SelectCheckBox();
            ManageClassroomCoursePage.ClickEnroll();
            _test.Log(Status.Pass, "User Enrolled into Section");
            #endregion

            #region Waitlist User
            EnrollmentPage.EnrollmentTab.ClickWaitlistedSubTab();
            EnrollmentPage.ClickWaitlistUsersButton();
            EnrollmentPage.SelectCheckBox();//Select few Users
            EnrollmentPage.ClickWaitlistButton();
            _test.Log(Status.Pass, "User Waitlisted into Section");

            EnrollmentPage.ClickViewAslearner();
            #endregion







            #region oldcode
            //Searching a ClassRoomCourse and find a section which status is complete with wait and Enrollment is full
            // #region Manage Classroom Course
            //CommonSection.Manage.Training();
            //TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            //StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            //TrainingPage.ClickSearchRecord("Classroom Course");
            //StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            //ClassroomCoursePage.ClickSectionsTab();
            //Assert.IsTrue(SectionsPage.ListofSections);
            //#endregion

            //#region Create Sections
            //ClassroomCourseDetailsPage.ClickSectionstab();
            //SectionsPage.Sectionstab.ClickAddaNewSectionbutton();
            //AddSectionPage.EnterSectionTitle("Section 1").ClickNext();
            //AddSectionPage.SelectAddDayEventCheckbox();
            //AddSectionPage.StartDateField.EnterStartDate("CurrentStartDate");
            //AddSectionPage.EndDateField.EnterEndDate("CurrentEndDate");
            //AddSectionPage.Capacity.MinimumField.EnterMinimum("0");
            //AddSectionPage.Capacity.MaximumField.EnterMaximum("3");
            //AddSectionPage.Waitlist.SelectUseWaitlist();
            //AddSectionPage.EnrollmentPeriodfield.ClickChangebutton();
            //EnrollmentPeriodModal.EnrollmentStartDateField.EnterStartDate("PastStartDate");
            //EnrollmentPeriodModal.EnrollmentEndDateField.EnterEndDate("CurrentEndDate"); //Date of Section End Date
            //EnrollmentPeriodModal.EnrollmentStartTimeField.EnterStartTime("12:30AM"); //Time before Section Start Time
            //EnrollmentPeriodModal.EnrollmentEndTimeField.EnterEndTime("11:30PM"); //Time before Section End Time
            //EnrollmentPeriodModal.ClickSaveButton();
            //Assert.IsTrue(AddSectionPage.EnrollmentDateAndTimeDisplayed);
            //AddSectionPage.ClickSave();
            //StringAssert.AreEqualIgnoringCase("The course section was created with the first event", SectionsPage.GetSuccessMessage(), "Error message is different");
            //#endregion


            //#region Enroll Users to make Section Full
            //SectionsPage.SectionTab.ClickSectionTitle;
            //SectionPage.EnrollmentTab.ClickEnrollButton();
            //BatchEnrollUsersModal.ListOfUsers.SelectCheckBox();//Select 3 checkboxes for Users to make Section Full
            //BatchEnrollUsersModal.ClickEnrollButton();
            //StringAssert.AreEqualIgnoringCase("Selected Users were enrolled in the section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
            //Assert.IsTrue(EnrollmentPage.ListofUsersEnrolled);
            #endregion
            //CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC33255" + '"');
            //SearchResultsPage.CheckSearchRecord(classroomcoursetitle + "TC33255");
            //SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC33255");
            CatalogPage.ClickEditContent();
            ManageClassroomCoursePage.Clicktab("Sections");
            //SectionsPage.ClickCompletedSecton();
            ManageClassroomCoursePage.Sectionsdropdown.OpenDropdown();
            //SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is Completed Section and the Enrollment is Full 
            Assert.IsTrue(ManageClassroomCoursePage.Sectionsdropdown.ManageWaitlist("Manage Waitlist")); //Verify the Manage Waitlist dropdown is NOT displayed
        }

        [Test, Order(19)]
        public void a19_Manage_Waitlist_from_Sections_listing_for_Not_Completed_Section_and_Enrollment_is_Not_Full_33279()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "ManageWaitListNotCompletedNotFull");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            #endregion

            #region Create Sections
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            #endregion


            ManageClassroomCoursePage.Sectionsdropdown.OpenDropdown();
            // SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is NOT Completed Section and the Enrollment is NOT Full 
            Assert.IsFalse(ManageClassroomCoursePage.Sectionsdropdown.ManageWaitlist("Manage Waitlist")); //Verify the Manage Waitlist dropdown is NOT displayed
            Assert.IsFalse(ManageClassroomCoursePage.Sectionsdropdown.ManageWaitlist("Wait list Users")); //Verify the Waitlist Users dropdown is NOT displayed   

        }
        [Test, Order(25)]
        public void a25_Manage_Waitlist_from_Sections_listing_for_Not_Completed_Section_and_Enrollment_is_Full_33259()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "ManageWaitlistNotCompleted");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));

            #endregion

            #region Create Sections

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            //ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            #endregion

            #region Enroll Users to make Section Full
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.SearchUserandEnrollbatch("userreg");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            #endregion
            ManageClassroomCoursePage.ClickSectionBreadcrumb();
            ManageClassroomCoursePage.Sectionsdropdown.SelectManageoption("Manage Waitlist");
            Assert.IsTrue(EnrollmentPage.EnrollmentTab.WaitlistedSubTab);

        }
        [Test, Order(26)]
        public void a26_Remove_a_gradeable_AICC_Course_from_a_section_34104()
        {
            #region Manage Classroom Course
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "34104");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            //ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.AddContent("Somnath-AICC");
            SectionDetailsPage.ContentTab.DeleteContent();
            //    Assert.IsTrue(SectionContentPage);
            //    Assert.IsTrue(SectionContentPage.List.Type.Online("AICC Course"));// Verify AICC Course associated with that section is displayed
            //    SectionContentPage.List.Type.Online("AICC Course").SelectCheckbox.ClickDeleteButton(); //Select a checkbox of an existing AICC Course and click on Delete button
            //    Assert.IsTrue(ConfirmBox.String "Are you sure you want to remove the selected items?");
            //    ConfirmBox.SelectRemove();
            //    StringAssert.AreEqualIgnoringCase("The item was removed", SectionContentPage.GetSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            //    Assert.IsTrue(SectionContentPage.List.Type.Online("AICC Course").Removed); //Verify the AICC Course is removed from the Content Tab
            //    SectionContentPage.ClickGradebookTab();
            //    Assert.IsTrue(GradebookPage.AICCCourseColumnRemoved);//Verify the AICC Course column is removed from gradebook
            //    Assert.IsTrue(GradebookPage.ScoreColumn.AICCCourseScoreRemoved);//Verify the AICC Course Score is removed from the Final Score in Gradebook

            //    LoginPage.LoginAs("Learner").WithPassword("").Login();//login with the user that has completed taken the AICC Course
            //    CommonSection.Transcript.AllMyTraining(); //Access the Transcript All My Training page
            //    AllMyTrainingPage.Type.SelectOnline.ClickFilter(); // Search for AICC Course by selecting Online in Type field and click on Filter
            //    Assert.IsTrue(AllMyTrainingPage.List.AICCCourseDisplayed); // Verify the completed AICC course is NOT removed from User's transcript
            //    AllMyTrainingPage.Type.SelectClassroom.ClickFilter(); // Search for Classroom by selecting Classroom in Type field and click on Filter
            //    Assert.IsTrue(AllMyTrainingPage.List.ClassroomCourseDisplayed); // Verify the Classroom Course is displayed
            //    AllMyTrainingPage.List.ClickClassroomCourseLink();
            //    Assert.IsTrue(ContentDetailsPage.AICCCourseRemoved.ScoreUpdated); // Verify the AICC Course no longer count towards score.
        }

        [Test, Order(27)]
        public void a27_Remove_a_gradeable_Scrom12_Course_from_a_section_34094()
        {
            #region Manage Classroom Course
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Success Message Verified");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "New Section Created");

            //ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            //_test.Log(Status.Info, "Click Manage Enrollment Action");
            // //ContentDetailsPage.ClickEditContent();
            //AdminContentDetailsPage.ClickSectionsTab();
            //// Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            ContentPage.ClickAddContent("");
            Assert.IsTrue(ContentPage.ContentTab.isScormCourse2004tDisplayed(""));
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isScormCourse2004tDisplayed());
            GradebookPage.GradebookTab.ClickContentTab();// Verify Test associated with that section is displayed
            ContentPage.ContentTab.DeleteContent(); //Select a checkbox of an existing Test and click on Delete button
            //Assert.IsTrue(ConfirmBox.String "Are you sure you want to remove the selected items?");
            //ConfirmBox.SelectRemove();
            StringAssert.AreEqualIgnoringCase("The item was removed", Driver.getSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            Assert.False(ContentPage.ContentTab.isScormCourse2004tDisplayed("")); //Verify the Test is removed from the Content Tab
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isScormCourse2004tDisplayed());//Verify the Test column is removed from gradebook
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());
        }
        //Verify the Test Score is removed from the Final Score in Gradebook
        //    CommonSection.Logout();
        //    LoginPage.LoginAs("srlearner").WithPassword("").Login();//login with the user that has completed taken the test
        //    CommonSection.Transcript(); ; //Access the Transcript All My Training page
        //    TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
        //    Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isScormCourse2004tDisplayed("Scorm 2004")); // Verify the completed test is NOT removed from User's transcript
        //    TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
        //    Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
        //    TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
        //    Assert.IsTrue(ContentDetailsPage.isScoreUpdated());
        //}
        [Test, Order(28)]
        public void a28_User_edits_event_in_existing_course_section_34142()
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34142");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("ak instructor");
            _test.Log(Status.Info, "Search Instructor");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt);

            CommonSection.Logout();
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login(); //Login as Instructor
            CommonSection.Manage.Training();
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules);//Verify Teaching Schedule page is displyed with list of Sections
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34142"); //Click on Expand Row (+) for one of the section (where there are already Files and Notes)
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.SectionScheduleExpanded);
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");//Verify Files and Notes page for the sections is displayed with associated Notes and Files
            String AssignmentTitle = ContentPage.ContentTab.AssignmentTitleText();
            ContentPage.ContentTab.ClickAssignmentTitle();
            ContentPage.ContentTab.UpdateAssignmentAs("Test Updated");
            _test.Log(Status.Info, "Assignment Title updated successfully");
            Assert.IsTrue(ContentPage.ContentTab.NotesTitleUpdated(AssignmentTitle));
            _test.Log(Status.Pass, "Verify Assignment title is updated");
        }
        [Test, Order(29)]
        public void a29_User_Grades_Individual_test_from_section_Gradebook_34141()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            #region create new course and Access The Gradebook From Section Detail Page

            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Pass, "Opened Create Classroom Course Page");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34141");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");

            // Assert.IsTrue(Driver.comparePartialString("The selected users were enrolled in the section.", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            Assert.IsTrue(GradebookPage.GradebookTab.GradeTest());
            _test.Log(Status.Pass, "User able to grade test");
            #endregion
        }
        [Test, Order(30)]
        public void a30_User_Manages_learners_transcript_notes_through_section_enrollment_34078()
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34078");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("ak instructor");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login(); //Login as Instructor
            CommonSection.Manage.Training();
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules);//Verify Teaching Schedule page is displyed with list of Sections
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34078"); //Click on Expand Row (+) for one of the section (where there are already Files and Notes)
            //Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.SectionScheduleExpanded);
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            // _test.Log(Status.Pass, "Verify Content tab is display");

            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            //_test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            //Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            //_test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");

            CommonSection.Learner.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            TranscriptPage.MoreInformation.viewPDFFilesandNotes();
            Assert.IsTrue(TranscriptPage.NotesAccorian.NotesDisplay());


        }
        [Test, Order(31)]
        public void a31_User_Bulk_grades_within_gradebook_34073()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34073");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg");

            // Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");
            Assert.IsTrue(GradebookPage.GradebookTab.BulkGrades());
        }


    }



}







