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
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]

    [TestFixture("anybrowser", Category = "local")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class NF_Everest_20_2_EventLevelAttendanceTests : TestBase
    {
        string browserstr = string.Empty;
        bool TC35342;
        public NF_Everest_20_2_EventLevelAttendanceTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string classroomcoursetitle = "CRT" + Meridian_Common.globalnum;
        string SectionTitle = "Section" + Meridian_Common.globalnum;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }

        [Test, Order(1)]
        public void tc_63342_As_admin_verify_the_Subtab_Grades()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63342");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            Assert.IsFalse(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab is not visible in Gradebook and Attendance tab");

            //for Recurring recurring
            ManageClassroomCoursePage.ClickSectionBreadcrumb();
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section with Recurring");
            ManageClassroomCoursePage.setRecurence("Daily");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Graded Assignment");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("somnath");
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            SectionDetailsPage.ClickGradebookTab();
            Assert.IsTrue(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab display in Gradebook and Attendance tab");
            SectionDetailsPage.GradebookTab.GradesSubTab.ClickGrades();
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.isGradeSubmissionsButtonDisplay());
            _test.Log(Status.Pass, "Verify Grade Submissions Button display inside Grades Sub Tab ");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.isGradesOnlyButtonDisplay());
            _test.Log(Status.Pass, "Verify Grades Only Button is display in Grades Sub Tab");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.GradeSubmissions.isusertabledisplay());
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.GradeSubmissions.UserTablecolumnHeaders("Name", "Score", "Attendance", "Graded Assignment"));

        }
        [Test, Order(2)]
        public void tc_63344_As_a_instructor_verify_the_Subtab_Grades()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("Somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as instructor");
            CommonSection.Manage.Training();
            TrainingPage.QuickLinks.ClickInstructorTools();
            _test.Log(Status.Info, "Click Instructor tools link from Quick link portlet ");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "_TC63342");
            _test.Log(Status.Info, "Expand the classroom course ");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "_TC63342");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            Assert.IsFalse(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab is not visible in Gradebook and Attendance tab");

            CommonSection.Logout();
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login as instructor");
            CommonSection.Manage.Training();
            TrainingPage.QuickLinks.ClickInstructorTools();
            _test.Log(Status.Info, "Click Instructor tools link from Quick link portlet ");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "_TC63342");
            _test.Log(Status.Info, "Expand the classroom course ");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "_TC63342");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab display in Gradebook and Attendance tab");
            SectionDetailsPage.GradebookTab.GradesSubTab.ClickGrades();
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.isGradeSubmissionsButtonDisplay());
            _test.Log(Status.Pass, "Verify Grade Submissions Button display inside Grades Sub Tab ");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.isGradesOnlyButtonDisplay());
            _test.Log(Status.Pass, "Verify Grades Only Button is display in Grades Sub Tab");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.GradeSubmissions.isusertabledisplay());
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.GradeSubmissions.UserTablecolumnHeaders("Name", "Score", "Attendance", "Graded Assignment"));
        }
        [Test, Order(3)]
        public void tc_63296_As_admin_verify_the_Timeline_Schedule_and_Content_tab_Recurring_Events()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login as siteadmin");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63296");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Daily");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isScheduleandContentTabDisplay());
            _test.Log(Status.Pass, "Verify Schedule and Content tab display");
            SectionDetailsPage.ClickScheduleandContentTab();
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.EventCount() >= 1);
            _test.Log(Status.Pass, "Verify Event count should be 1 or more than that");
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.CommitmentDisplay());
            _test.Log(Status.Pass, "Verify Commitment Display in Schedule and Content tab");
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.Commitment.StartandEndDateDisplay());
            _test.Log(Status.Pass, "Verify Commitment Display in Schedule and Content tab");
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Graded Assignment");
            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            SectionDetailsPage.ClickScheduleandContentTab();
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.isPossiblePointdisplay());
            _test.Log(Status.Pass, "Verify Possible Point Display in Schedule and Content tab");
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.isGradedItemsDisplay());
            _test.Log(Status.Pass, "Verify Graded Items Display in Schedule and Content tab");
        }
        [Test, Order(4)]
        public void tc_63319_As_admin_verify_the_Timeline_Schedule_and_Content_tab_Non_Recurring_Events()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63319");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isScheduleandContentTabDisplay());
            _test.Log(Status.Pass, "Verify Schedule and Content tab display");
            SectionDetailsPage.ClickScheduleandContentTab();
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.EventCount() >= 1);
            _test.Log(Status.Pass, "Verify Event count should be 1 or more than that");
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.CommitmentDisplay());
            _test.Log(Status.Pass, "Verify Commitment Display in Schedule and Content tab");
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.Commitment.StartandEndDateDisplay());
            _test.Log(Status.Pass, "Verify Commitment Display in Schedule and Content tab");
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Graded Assignment");
            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            SectionDetailsPage.ClickScheduleandContentTab();
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.isPossiblePointdisplay());
            _test.Log(Status.Pass, "Verify Possible Point Display in Schedule and Content tab");
            Assert.IsTrue(SectionDetailsPage.ScheduleandContentTab.isGradedItemsDisplay());
            _test.Log(Status.Pass, "Verify Graded Items Display in Schedule and Content tab");
        }
        [Test, Order(4)]

        public void tc_33782_User_Views_Gradebook_via_Teaching_Schedule_Tab_33782()
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

            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            Assert.IsFalse(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab display in Gradebook and Attendance tab");
            //Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            //_test.Log(Status.Pass, "Assertion Pass Gradebook accessible Available from Instructor Tool Training Schedule");
        }
        [Test, Order(1)]
        public void tc_63420_Classroom_Attendance_and_progress_Single_Event_Admin()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63420");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("somnath");
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            SectionDetailsPage.ClickGradebookTab();
            Assert.IsFalse(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab is not display in Gradebook and Attendance tab");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.UserListGrid.Verify_ColumnHeader());
            Assert.IsTrue(SectionDetailsPage.GradebookTab.UserListGrid.Verify_AttendanceSubTab("All Attended", " All Absent"));
            _test.Log(Status.Pass, "Verify All Attended and all Absent link display in Attendace culumn header");
            SectionDetailsPage.GradebookTab.UserListGrid.ClickAllAttended();
            Assert.IsTrue(Driver.comparePartialString("Success The information was updated.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            SectionDetailsPage.GradebookTab.UserListGrid.ClickAllAbsent();
            Assert.IsTrue(Driver.comparePartialString("Success The information was updated.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
        }
        [Test,Order(7)]
        public void tc_63421_Classroom_Attendance_and_progress_Multi_Event_with_no_Items_in_gradebook()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63421");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section with Recurring");
            ManageClassroomCoursePage.setRecurence("Daily");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("somnath");
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            SectionDetailsPage.ClickGradebookTab();
            Assert.IsFalse(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab is not display in Gradebook and Attendance tab");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.UserListGrid.Verify_ColumnHeaderforRecevent());
                       
            Assert.IsTrue(SectionDetailsPage.GradebookTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is Pagination display");
           
        }
        [Test, Order(7)]
        public void tc_63422_Classroom_Attendance_and_progress_Multi_Event_with_Items_in_gradebook()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63422");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section with Recurring");
            ManageClassroomCoursePage.setRecurence("Daily");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isGradebookAndAttendanceTabDisplay());
            _test.Log(Status.Pass, "Verify Gradebook and Attendance tab display");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("somnath");
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Graded Assignment");
            SectionDetailsPage.ClickGradebookTab();
            Assert.IsTrue(SectionDetailsPage.GradebookTab.isGradesSubTabDisplay());
            _test.Log(Status.Pass, "Verify Grades Sub Tab is not display in Gradebook and Attendance tab");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.UserListGrid.Verify_ColumnHeaderforRecevent());

            Assert.IsTrue(SectionDetailsPage.GradebookTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is Pagination display");
            SectionDetailsPage.GradebookTab.GradesSubTab.ClickGrades();
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.isGradeSubmissionsButtonDisplay());
            _test.Log(Status.Pass, "Verify Grade Submissions Button display inside Grades Sub Tab ");
            Assert.IsTrue(SectionDetailsPage.GradebookTab.GradesSubTab.isGradesOnlyButtonDisplay());
            _test.Log(Status.Pass, "Verify Grades Only Button is display in Grades Sub Tab");

        }
    }
}



