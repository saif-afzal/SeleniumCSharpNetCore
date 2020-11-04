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
   class TC_InstructorTools : TestBase
    {
        public TC_InstructorTools(string browser)
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
           // objLogin = new Login();
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

          //  driver.UserLogin("admin1");
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
