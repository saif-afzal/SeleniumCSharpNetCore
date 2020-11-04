using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;


namespace Selenium2.Meridian.Suite.MyResponsibilities.e_InstructorTools
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   public class c_GradeBook : TestBase
    {
        string browserstr = string.Empty;
        public c_GradeBook(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {
           
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            

            // PreRequisite - Create a new instructor
  /*          driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            manageuserobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_instructor["Id"]+browserstr, ExtractDataExcel.MasterDic_instructor["Firstname"]+browserstr, ExtractDataExcel.MasterDic_instructor["Lastname"]+browserstr, ExtractDataExcel.MasterDic_instructor["Email"]);
            CreateNewAccountobj.Click_SelectOrganization("");
            CreateNewAccountobj.Click_CreateAccount();
            manageuserobj.populateaccountsearchform(ExtractDataExcel.MasterDic_instructor["Firstname"]+browserstr, ExtractDataExcel.MasterDic_instructor["Lastname"]+browserstr);
            manageuserobj.Click_SearchUser();
            driver.tempUserLogin("instructor", ExtractDataExcel.MasterDic_instructor["Id"]+browserstr, manageuserobj.passwordcreationnewuser(),browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsTab("People");
            TrainingHomeobj.click_systemOptionsAccordian("Users");
            TrainingHomeobj.click_systemOptionsLink("Instructors");
         //   TrainingHomeobj.AdminConsole_Click(driver);
         //   AdminstrationConsoleobj.Click_OpenItemLink("Instructors");
            Instructorsobj.CreateInstructor_Click(driver,browserstr);
            TrainingHomeobj.QuitSystemOptionsConsole(driver);
            TrainingHomeobj.close_systemOptions();

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);*/
        }

        [SetUp]
        public void SetUp()
        {
          
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);


        }

        
        [Test]
        public void a_Gradebook_Creation_11762()
        {
            
            // PreRequisite - Create Classroom Course with Section
            

            driver.UserLogin("admin1",browserstr);

            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent( "Classroom Course");
            Createobj.FillClassroomCoursePage("",browserstr);
            Contentobj.ManageSectionTab();
            ScheduleAndManageSectionobj.AddNewSection_Click();

            

            CourseSectionobj.CreateNewSectionInPerson(driver, ExtractDataExcel.MasterDic_instructor["Lastname"],browserstr);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(Variables.classroomCourseTitle+browserstr);
            BrowseTrainingCatalogobj.Set_SearchType("All words");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.EnrollClassroomCourse();

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.linkinstructortoolsclick();
            ManageGradebookobj.GradebookConsoleTab_Click(driver);
            ManageGradebookobj.Populate_SearchText(driver, Variables.classroomCourseTitle+browserstr);
            ManageGradebookobj.Click_Search(driver);
            Assert.IsTrue(ManageGradebookobj.Create_Gradebook(driver,browserstr));
        }

        [Test]
        public void b_access_gradebook_console_to_create_manage_gradebook_classroom_sections_11789()
        {

            // PreRequisite - Create Classroom Course with Section


            

            TrainingHomeobj.MyResponsiblities_click();
            
            classroomcourse.linkinstructortoolsclick();
            ManageGradebookobj.GradebookConsoleTab_Click(driver);
            ManageGradebookobj.Populate_SearchText(driver, Variables.classroomCourseTitle+browserstr);
            ManageGradebookobj.Click_Search(driver);
            Assert.IsTrue(ManageGradebookobj.Manage_Gradebook(driver,browserstr));
        }


        [Test]
        public void c_Add_Edit_Remove_Assignments_In_Gradebook_11795()
        {
            ManageGradebookobj.Add_Assigment(driver, ExtractDataExcel.MasterDic_Assignment["Title"] + "1", ExtractDataExcel.MasterDic_Assignment["Desc"], ExtractDataExcel.MasterDic_Assignment["ItemWeight"]);
            ManageGradebookobj.Add_Assigment(driver, ExtractDataExcel.MasterDic_Assignment["Title"] + "2", ExtractDataExcel.MasterDic_Assignment["Desc"], ExtractDataExcel.MasterDic_Assignment["ItemWeight"]);
            ManageGradebookobj.Edit_Assigment(driver);
            ManageGradebookobj.Remove_Assigment(driver);
        }

        [Test]
        public void d_Assignments_should_only_display_to_enrolled_learner_when_gradebook_is_shown_11798()
        {
            ManageGradebookobj.Show_Gradebook(driver);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(Variables.classroomCourseTitle+browserstr);
            BrowseTrainingCatalogobj.Set_SearchType("All words");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Assert.IsTrue(driver.WaitForElement(By.Id("ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00__0")));

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.linkinstructortoolsclick();
            ManageGradebookobj.GradebookConsoleTab_Click(driver);
            ManageGradebookobj.Populate_SearchText(driver, Variables.classroomCourseTitle+browserstr);
            ManageGradebookobj.Click_Search(driver);
            ManageGradebookobj.Manage_Gradebook(driver,browserstr);
            ManageGradebookobj.Hide_Gradebook(driver);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(Variables.classroomCourseTitle+browserstr);
            BrowseTrainingCatalogobj.Set_SearchType("All words");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Assert.IsTrue(driver.ElementNotPresent(By.Id("ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00__0")));

        }

        [Test]
        public void e_Access_Edit_Student_Score_page_from_Manage_Gradebook_11799()
        {
            string expectedresult = ExtractDataExcel.MasterDic_userforreg["Firstname"];
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.linkinstructortoolsclick();
            ManageGradebookobj.GradebookConsoleTab_Click(driver);
            ManageGradebookobj.Populate_SearchText(driver, Variables.classroomCourseTitle+browserstr);
            ManageGradebookobj.Click_Search(driver);
            ManageGradebookobj.Manage_Gradebook(driver,browserstr);
            ManageGradebookobj.click_EnterGrades(driver);
            string actualresult = ManageGradebookobj.verify_enrolleduser(driver);
            StringAssert.Contains(expectedresult, actualresult);
        }

        [Test]
        public void f_Allow_online_submissions_for_assignment_14703()
        {
            ManageGradebookobj.click_returnOnEnterGradesPage(driver);
            ManageGradebookobj.Show_Gradebook(driver);
            ManageGradebookobj.click_assignmentTitle(driver);
            ManageGradebookobj.click_allowOnlineSubmission(driver);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(Variables.classroomCourseTitle+browserstr);
            BrowseTrainingCatalogobj.Set_SearchType("All words");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.verify_submitAssignmentButtonNotPresent(driver));

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.linkinstructortoolsclick();
            ManageGradebookobj.GradebookConsoleTab_Click(driver);
            ManageGradebookobj.Populate_SearchText(driver, Variables.classroomCourseTitle+browserstr);
            ManageGradebookobj.Click_Search(driver);
            ManageGradebookobj.Manage_Gradebook(driver,browserstr);
            ManageGradebookobj.click_assignmentTitle(driver);
            ManageGradebookobj.click_allowOnlineSubmission(driver);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(Variables.classroomCourseTitle+browserstr);
            BrowseTrainingCatalogobj.Set_SearchType("All words");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.verify_submitAssignmentButtonPresent(driver));

        }

        [Test]
        public void g_Learner_view_details_for_an_assignment_14714()
        {
            Detailsobj.click_infoIconForAssignment(driver);

            string format = "M/d/yyyy";
            List<string> expectedresult = new List<string>(6);
            expectedresult.Add(ExtractDataExcel.MasterDic_Assignment["Title"] + "1");
            expectedresult.Add(ExtractDataExcel.MasterDic_Assignment["Desc"]);
            expectedresult.Add("100.00");
            expectedresult.Add("Pass/Fail");
            expectedresult.Add("Yes");
            expectedresult.Add(DateTime.Now.AddMonths(1).ToString(format));

            List<string> result = new List<string>(6);
            result = Detailsobj.return_assignmentDetailsInfoWindow(driver);
            for (int i = 0; i < 6; i++)
            {
                StringAssert.Contains(expectedresult[i], result[i]);
            }
            
        }

        [Test]
        public void h_Learner_view_all_assignments_and_due_dates_14712()
        {
            string format = "M/d/yyyy";
            List<string> expectedresult = new List<string>(4);
            expectedresult.Add(ExtractDataExcel.MasterDic_Assignment["Title"] + "1");
            expectedresult.Add("of 100.00");
            expectedresult.Add(DateTime.Now.AddMonths(1).ToString(format));
            expectedresult.Add("Not Submitted");
            List<string> result = new List<string>(4);
            result = Detailsobj.return_assignmentDetails(driver);
            for (int i = 0; i < 4; i++)
            {
                StringAssert.Contains(expectedresult[i], result[i]);
            }
        }

        [Test]
        public void i_Learner_can_enter_an_assignment_response_14716()
        {
            Detailsobj.click_submitAssignmentDetailsPage(driver);
            Detailsobj.click_submitAssignmentWithoutResponse(driver);
            Detailsobj.populateAssignmentForm(driver, "Test Response", "Test Comments");
            Detailsobj.click_SaveResumeLaterAssignment(driver);
            Detailsobj.click_submitAssignmentDetailsPage(driver);
            Detailsobj.click_submitAssignmentWithResponse(driver);

        }

        [Test]
        public void j_Instructor_can_see_assignment_responses_that_are_pending_grades_14733()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("Instructor",browserstr);

            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.linkinstructortoolsclick();
            ManageGradebookobj.GradebookConsoleTab_Click(driver);
            ManageGradebookobj.Populate_SearchText(driver, Variables.classroomCourseTitle+browserstr);
            ManageGradebookobj.Click_Search(driver);
            ManageGradebookobj.Manage_Gradebook(driver,browserstr);

            string format = "M/d/yyyy";
            List<string> expectedresult = new List<string>(4);
            expectedresult.Add(ExtractDataExcel.MasterDic_Assignment["Title"] + "1");
            expectedresult.Add("100.00");
            expectedresult.Add("Pass/Fail");
            expectedresult.Add(DateTime.Now.AddMonths(1).ToString(format));
            List<string> result = new List<string>(4);
            result = ManageGradebookobj.verify_assignmentDetailsOnManageGradebookPage(driver);
            for (int i = 0; i < 4; i++)
            {
                StringAssert.Contains(expectedresult[i], result[i]);
            }

            string expectedresult1 = ExtractDataExcel.MasterDic_userforreg["Firstname"];
            ManageGradebookobj.click_EnterGrades(driver);
            string actualresult1 = ManageGradebookobj.verify_enrolleduser(driver);
            StringAssert.Contains(expectedresult1, actualresult1);


        }

        [Test]
        public void k_Instructor_can_view_assignment_response_for_evaluation_14738()
        {
            ManageGradebookobj.click_viewSubmissions(driver);
            string format = "M/d/yyyy";
            List<string> expectedresult = new List<string>(3);
            expectedresult.Add("Test Response");
            expectedresult.Add("Test Comments");
            expectedresult.Add(DateTime.Now.ToString(format));
            List<string> result = new List<string>(3);
            result = ManageGradebookobj.verify_assignmentResponse(driver);
            for (int i = 0; i < 3; i++)
            {
                StringAssert.Contains(expectedresult[i], result[i]);
            }
        }

        [Test]
        public void l_Instructor_can_enter_grade_for_assignment_14740()
        {
            ManageGradebookobj.click_returnViewSubmissionPage(driver);
            Assert.IsTrue(ManageGradebookobj.enterGradesPassFail(driver, "Pass"));
        }

        [Test]
        public void m_Instructor_can_change_the_grade_for_assignment_14774()
        {
            ManageGradebookobj.click_returnEnterGradesPage(driver);
            ManageGradebookobj.click_EnterGrades(driver);
            Assert.IsTrue(ManageGradebookobj.enterGradesPassFail(driver, "Fail"));
        }

        [Test]
        public void n_View_all_assignment_scores_for_the_section_14776_14777()
        {
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.linkinstructortoolsclick();
            ManageGradebookobj.GradebookConsoleTab_Click(driver);
            ManageGradebookobj.Populate_SearchText(driver, Variables.classroomCourseTitle+browserstr);
            ManageGradebookobj.Click_Search(driver);
            ManageGradebookobj.Manage_Gradebook(driver,browserstr);

            List<string> expectedresult = new List<string>(2);
            List<string> result = new List<string>(2);
            expectedresult.Add("100.00");
            expectedresult.Add(ExtractDataExcel.MasterDic_userforreg["Firstname"]);
            ManageGradebookobj.click_viewFinalScores(driver);
            result = ManageGradebookobj.verify_recordAttendancePageElements(driver);
            for (int i = 0; i < 2; i++)
            {
                StringAssert.Contains(expectedresult[i], result[i]);
            }

        }

        [Test]
        public void o_Instructor_provide_attendance_status_final_score_for_section_11644()
        {
            ManageGradebookobj.click_recordAttendance(driver);
            ManageGradebookobj.provide_attendance_status(driver);

        }

        [Test]
        public void p_Instructor_view_attendance_status_final_score_for_section_14778()
        {
            ManageGradebookobj.click_returnRecordAttendancePage(driver);

            List<string> expectedresult = new List<string>(2);
            List<string> result = new List<string>(2);
            expectedresult.Add("Attended");
            expectedresult.Add("Completed");
            result = ManageGradebookobj.verify_attendanceStatusScores(driver);
            for (int i = 0; i < 2; i++)
            {
                StringAssert.Contains(expectedresult[i], result[i]);
            }
        }


        [TearDown]
        public void TearDown()
        {

            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            Console.WriteLine("TearDown");
            driver.Quit();
        }
    }
}
