using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.Meridian;


namespace Selenium2.Meridian.Suite.MyResponsibilities.e_InstructorTools
{
    [TestFixture("firefoxbrowserstack")]
    [TestFixture("Chromebrowserstack")]
    [TestFixture("IE11browserstack")]
    [Parallelizable(ParallelScope.Fixtures)]
   class TC_InstructorToolsold : TestBase
    {
        public TC_InstructorToolsold(string browser)
            : base(browser)
        {

}
        public Training objTraining;
        public Login objLogin;
        public TrainingHomes objTrainingHome;
        public AdministrationConsoles objAdminConsole;
        public Instructorspof objInstructors;
        public ContentSearch objContentSearch;
        public Create objCreate;
        public Content objContent;
        public ScheduleAndManageSection objSection;
        public CreateNewCourseSectionAndEvent objCourseSection;
        public BrowseTrainingCatalog objBrowseTrainingCatalog;
        public SearchResults objSearchResults;
        public Details objDetails;
        public MyTeachingSchedule objMyTeachingSch;
        public TeachingSchedule objTeachingSch;
        public ManageStudents objManageStudents;
        public DomainConsole objDomainConsole;
        public EditSummary objEditSummary;
        public ManageMembership objMemdership;
        public AddMembers objAddMembers;
        public TrainingNotes objTrainingNotes;
        public AdminConsole_Surveys objAdminSurveys;
        public Surveys objSurveys;

        [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
          //  objLogin = new Login();
            objTrainingHome = new TrainingHomes(driver);
            objTraining = new Training(driver);
            objAdminConsole = new AdministrationConsoles(driver);
            objInstructors = new Instructorspof();
            objContentSearch = new ContentSearch(driver);
            objCreate = new Create(driver);
            objContent = new Content(driver);
            objSection = new ScheduleAndManageSection(driver);
            objCourseSection = new CreateNewCourseSectionAndEvent(driver);
            objBrowseTrainingCatalog = new BrowseTrainingCatalog(driver);
            objSearchResults = new SearchResults(driver);
            objDetails = new Details(driver);
            objMyTeachingSch = new MyTeachingSchedule();
            objTeachingSch = new TeachingSchedule();
            objManageStudents = new ManageStudents();
           // objDomainConsole = new DomainConsole();
            objEditSummary = new EditSummary(driver);
            objMemdership = new ManageMembership();
            objAddMembers = new AddMembers();
            objTrainingNotes = new TrainingNotes();
            objAdminSurveys = new AdminConsole_Surveys();
            objSurveys = new Surveys(driver);
        }

        [SetUp]
        public void SetUp()
        {

            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);

            driver.UserLogin("admin1");
        }

        [Test]
        public void A_ClickOnTabsToSortByDate()
        {
            //// PreRequisite - Create Instructor
            //objTrainingHome.click_systemOptions();
            //objTrainingHome.click_systemOptionsTab("People");
            //objTrainingHome.click_systemOptionsAccordian("Users");
            //objTrainingHome.click_systemOptionsLink("Instructors");
            ////objAdminConsole.Instructors_Click(driver);
            //objInstructors.CreateInstructor_Click(driver);
            
            //objTrainingHome.click_systemOptions();
            objTrainingHome.click_systemOptions();
            objTrainingHome.click_systemOptionsTab("System");
            objTrainingHome.click_systemOptionsAccordian("Domains and URLS");
            objTrainingHome.click_systemOptionsLink("Domains");
            //objAdminConsole.DomainManagement_Click(driver);
        //    objDomainConsole.CoreDomainClick(driver);
            objEditSummary.Membership_Click();
            objMemdership.AddMembers_Click(driver);
         //   objAddMembers.SearchInstructor(driver);
            
            objTrainingHome.QuitSystemOptionsConsole(driver);
            objTrainingHome.close_systemOptions();

            // PreRequisite - Create Classroom Course with Section
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "Classroom Course");
            objCreate.FillClassroomCoursePage("");
            objContent.ManageSectionTab();
            objSection.AddNewSection_Click();
            objCourseSection.CreateNewSectionInPerson(driver, ExtractDataExcel.MasterDic_instructor["Lastname"]);

            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //driver.UserLogin("admin1");
            //objLogin.Login_click(driver);
            objTrainingHome.Click_MyOwnLearning();
            objTrainingHome.Click_TrainingCatalogLink();
            objBrowseTrainingCatalog.Populate_SearchText(Variables.classroomCourseTitle);
            objBrowseTrainingCatalog.Set_SearchType("All words");
            objBrowseTrainingCatalog.Click_Search();
            objSearchResults.Content_Click();
            objDetails.EnrollClassroomCourse();

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("Instructor");
            //objLogin.Login_click(driver);
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            string ccSectionName = objMyTeachingSch.Days7ScheduleTab_Click(driver);
            StringAssert.Contains(Variables.sectionTitle, ccSectionName);
        }

        [Test]
        public void B_ClickMyTeachingCalendar()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.MyTeachingCalendar_Click();
            Assert.IsTrue(objTraining.ViewMyTeachingSchedule_Click());
        }

        [Test]
        public void C_ClickClassroomCalendarView()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.ClassroomCalendarView_Click(driver);
            Assert.IsTrue(objTeachingSch.ViewCoursesOnCalendar(driver));    
        }

        [Test]
        public void D_ConductSearchForSections()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.SearchForSectionInMangeStudentsTab(driver);
            Assert.IsTrue(objManageStudents.DisplaySections(driver));
        }

        [Test]
        public void E_ClickSectionTitleToViewRosterForClassroomSection()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.SearchForSectionInMangeStudentsTab(driver); 
            objManageStudents.SectionTitle_Click(driver);
            Assert.IsTrue(objManageStudents.RosterPage(driver));
        }

      /*  [Test]
        public void F_ExportRosterToExcel()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.SearchForSectionInMangeStudentsTab(driver);
            objManageStudents.SectionTitle_Click(driver);
            objManageStudents.ExportToExcel(driver);
        }
*/
        [Test]
        public void F_SendEmailToUsersFromRoster()
        {
            Variables.isRoster = true;
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.SearchForSectionInMangeStudentsTab(driver);
            objManageStudents.SectionTitle_Click(driver);
            objManageStudents.EmailToUsers(driver);
            String successMsg = objManageStudents.SuccessMsgDisplayed(driver);
            StringAssert.Contains("The email was sent.", successMsg);
        }

        [Test]
        public void G_SendEmailToUsersFromInstructorTools()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.SearchForSectionInMangeStudentsTab(driver);
            objManageStudents.SectionTitle_Click(driver);
            objManageStudents.EmailToUsers(driver);
            String successMsg = objManageStudents.SuccessMsgDisplayed(driver);
            StringAssert.Contains("The email was sent.", successMsg);
        }

        [Test]
        public void H_AddNoteToTheUserTranscriptViaManageNotes()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.SearchForSectionInMangeStudentsTab(driver);
            objManageStudents.SectionTitle_Click(driver);
            objManageStudents.ManageNotes_Click(driver);
            objTrainingNotes.AddNotes(driver);
            String successMsg = objTrainingNotes.SuccessMsgDisplayed(driver);
            StringAssert.Contains("The note was added.", successMsg);
            Assert.IsTrue(objTrainingNotes.NoteAddedToTranscript(driver));
        }

        [Test]
        public void I_AssignAsurveyToTheClassroomSection()
        {
            //Steps to create survey to available on certification - PreRequisite
            objTrainingHome.AdminConsole_Click(driver);
            objAdminConsole.Surveys_Click(driver);
            objAdminSurveys.CreateSurveys(driver);
            objTrainingHome.QuitAdminConsole(driver);

            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.classroomCourseTitle);
            objContentSearch.Content_Click();
            objContent.ManageSurveyInClassroom_Click();
            objSurveys.AssigningSurveys(driver);
            //String assertion on assigning survey
            String successMsg = objSurveys.SuccessMsg_Survey(driver);
            StringAssert.Contains("The surveys were assigned.", successMsg);

            objTrainingHome.MyResponsiblities_click();
            objTraining.ViewMyTeachingSchedule_Click();
            objMyTeachingSch.ManageStudentsTab_Click(driver);
            objManageStudents.SearchForSectionInMangeStudentsTab(driver);
            objManageStudents.SectionTitle_Click(driver);
            Assert.IsTrue(objManageStudents.SurveyDisplayed(driver));
        }

        [TearDown]
        public void TearDown()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            Console.WriteLine("TearDown");
            driver.Quit();
        }
    }
}
