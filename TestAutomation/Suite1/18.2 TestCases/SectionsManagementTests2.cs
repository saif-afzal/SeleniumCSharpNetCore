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
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1SectionsManagementTests2 : TestBase
    {
        string browserstr = string.Empty;
        public P1SectionsManagementTests2(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
            InitializeBase(driver);

        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string SectionTitle = "Section_" + Meridian_Common.globalnum;

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

       // [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

        }
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
        //s[TearDown]
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
                    //if (!Meridian_Common.isadminlogin)
                    //{
                    //    CommonSection.Logout();
                    //    LoginPage.LoginAs("").WithPassword("").Login();
                    //}


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
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }

       
        
        [Test, Order(1)]

        public void Z01_User_Views_Section_Gradebook_via_section_Tab_33774()
        {
            #region create new course and Access The Gradebook From Section Detail Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle+"TC33774");
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

        [Test, Order(2)]

        public void Z02_User_Views_Section_Gradebook_via_Instructor_Tool_33776()
        {
            #region create new course and Access The Gradebook From Instructor Tool Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle+"TC33776");
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

        [Test, Order(19), Category("AutomatedP1")]

        public void Z19_Admin_User_Delete_Events_From_Section_Detail_Page_34041()
        {
            #region create new course and Access The Section Detail From Gradebook Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34041");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC34041");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC34041"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            ManageClassroomCoursePage.ScheduleTab();
            Assert.IsTrue(ManageClassroomCoursePage.Remove_Event(SectionTitle + "TC34041"));
            _test.Log(Status.Pass, "Assertion Pass as Event has been removed");
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

        [Test,Order(21)]

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
       
        //[Test, Order(23)]
        //public void Manage_Waitlist_from_Sections_listing_for_Not_Completed_Section_and_Enrollment_is_Full_33259()

        //{
        //    #region Manage Classroom Course
        //    CommonSection.Manage.Training();
        //    TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
        //    TrainingPage.ClickSearchRecord("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
        //    ClassroomCoursePage.ClickSectionsTab();
        //    Assert.IsTrue(SectionsPage.ListofSections);
        //    #endregion

        //    #region Create Sections
        //    ClassroomCourseDetailsPage.ClickSectionstab();
        //    SectionsPage.Sectionstab.ClickAddaNewSectionbutton();
        //    AddSectionPage.EnterSectionTitle("Section 1").ClickNext();
        //    AddSectionPage.SelectAddDayEventCheckbox();
        //    AddSectionPage.StartDateField.EnterStartDate("FutureStartDate");
        //    AddSectionPage.EndDateField.EnterEndDate("FutureEndDate");
        //    AddSectionPage.Capacity.MinimumField.EnterMinimum("0");
        //    AddSectionPage.Capacity.MaximumField.EnterMaximum("3");
        //    AddSectionPage.Waitlist.SelectUseWaitlist();
        //    AddSectionPage.EnrollmentPeriodfield.ClickChangebutton();
        //    EnrollmentPeriodModal.EnrollmentStartDateField.EnterStartDate("CurrentStartDate");
        //    EnrollmentPeriodModal.EnrollmentEndDateField.EnterEndDate("FutureEndDate"); //Date before Section End Date
        //    EnrollmentPeriodModal.EnrollmentStartTimeField.EnterStartTime("12:30AM");
        //    EnrollmentPeriodModal.EnrollmentEndTimeField.EnterEndTime("11:30PM");
        //    EnrollmentPeriodModal.ClickSaveButton();
        //    Assert.IsTrue(AddSectionPage.EnrollmentDateAndTimeDisplayed);
        //    AddSectionPage.ClickSave();
        //    StringAssert.AreEqualIgnoringCase("The course section was created with the first event", SectionsPage.GetSuccessMessage(), "Error message is different");
        //    #endregion

        //    #region Enroll Users to make Section Full
        //    SectionsPage.SectionTab.ClickSectionTitle;
        //    SectionPage.EnrollmentTab.ClickEnrollButton();
        //    BatchEnrollUsersModal.ListOfUsers.SelectCheckBox();//Select 3 checkboxes for Users to make Section Full
        //    BatchEnrollUsersModal.ClickEnrollButton();
        //    StringAssert.AreEqualIgnoringCase("Selected Users were enrolled in the section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    Assert.IsTrue(EnrollmentPage.ListofUsersEnrolled);
        //    #endregion

        //    SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is Not Completed Section and the Enrollment is Full 
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.ManageWaitlist); //Verify the Manage Waitlist dropdown is displayed
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.WaitlistUsers); //Verify the Waitlist Users dropdown is NOT displayed
        //    SectionsPage.Sectiondropdown.SelectManageWaitlistoption();
        //    Assert.IsTrue(EnrollmentPage.EnrollmentTab.WaitlistedSubTab);

        //}
        

        //public void As_Course_Manager_View_Files_And_Notes_For_Classroom_Section_33931()

        //{
        //    LoginPage.LoginAs("saifcoursemanager").WithPassword("").Login(); //Login as Course Manager 
        //    #region Manage Classroom Course
        //    CommonSection.Manage.Training();
        //    TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
        //    TrainingPage.ClickSearchRecord("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
        //    AdminContentDetailsPage.ClickSectionsTab();
        //    //  Assert.IsTrue(SectionsPage.ListofSections);
        //    #endregion
        //    SectionsPage.ListofSections.ClickSectionTitle();
        //    // Assert.IsTrue(SectionDetailsPage);
        //    SectionDetailsPage.ClickContentTab();
        //    // Assert.IsTrue(SectionContentPage);
        //    Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
        //    Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
        //    ContentPage.ContentTab.ClickNotesTitle();//Click on the Note Name in the Section Content page 
        //    Assert.IsTrue(ContentPage.ContentTab.isNoteModalOpened);// Verify the Note opens and can be viewed
        //    ContentPage.ContentTab.ClickFile(); ;//Click on the File Link in the Section Content page 
        //    Assert.IsTrue(ContentPage.ContentTab.isFileOpened());// Verify the File opens and can be viewed
        //}

        //[Test]

        //public void As_Instructor_View_Files_And_Notes_For_Classroom_Sections_33932()

        //{
        //    LoginPage.LoginAs("saifinstructor").WithPassword("").Login(); //Login as Instructor
        //    CommonSection.Manage.Training();
        //    TrainingPage.InstructorTools.TeachingSchedule(); //Select Instructor Tools then Teaching Schedule
        //    Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules);//Verify Teaching Schedule page is displyed with list of Sections
        //    InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules.ClickExpandRow(); //Click on Expand Row (+) for one of the section (where there are already Files and Notes)
        //    Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.SectionScheduleExpanded);
        //    InstructorToolsPage.TeachingScheduleTab.ExpandedSectionSchedule.ClickDropdown();
        //    Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.DropdownExpanded.SelectFilesAndNotes);
        //    Assert.IsTrue(FilesAndNotesPage.ListOfFilesandNotes); //Verify Files and Notes page for the sections is displayed with associated Notes and Files
        //    FilesAndNotesPage.Files.Title.ClickFileName();//Click on the File Link in the Files and Notes page 
        //    Assert.IsTrue(FileOpened);// Verify the File opens and can be viewed

        //}

        

    }

 
}


