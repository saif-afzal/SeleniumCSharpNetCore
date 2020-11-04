using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium2.Meridian.Suite.P1.Learning.Training_Catalog
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
 class CurriculumsP1 : TestBase
    {
        string browserstr = string.Empty;
     public CurriculumsP1(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        public static bool isCurriculum;
       
        public Training objTraining;
        public Login objLogin;
        public TrainingHomes objTrainingHome;
        public ContentSearch objContentSearch;
        public Create objCreate;
        public Content objContent;
        public AdministrationConsoles objAdminConsole;
        public RequiredTrainingConsoles objReqTrainingConsole;
        public RequiredTraining objReqTraining;
        public Surveys objSurveys;
        public BrowseTrainingCatalog objBrowseTraining;
        public SearchResults objSearchResults;
        public Details objDetails;
        public AdminConsole_Surveys objAdminSurveys;
        public AddContent objAddContent;
        public TrainingActivities objTrainingActivities;
        
        
        [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {

            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            objTrainingHome = new TrainingHomes(driver);
            objTraining = new Training(driver);
            objContentSearch = new ContentSearch(driver);
            objCreate = new Create(driver);
            objContent = new Content(driver);
            objAdminConsole = new AdministrationConsoles(driver);
            objReqTrainingConsole = new RequiredTrainingConsoles(driver);
            objReqTraining = new RequiredTraining(driver);
            objSurveys = new Surveys(driver);
            objBrowseTraining = new BrowseTrainingCatalog(driver);
            objSearchResults = new SearchResults(driver);
            objDetails = new Details(driver);
            objAdminSurveys = new AdminConsole_Surveys();
            objAddContent = new AddContent(driver);
            objTrainingActivities = new TrainingActivities(driver);
            driver.UserLogin("admin", browserstr);

            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
            objCreate.FillGeneralCoursePage("", browserstr);
            driver.WaitForElement(ObjectRepository.CheckinNew);
            driver.ClickEleJs(ObjectRepository.CheckinNew);

            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
       
            objCreate.FillCurriculumPage("", browserstr);
            objContent.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("", browserstr);
            objTrainingActivities.AddTrainingActivities_Click();
            objAddContent.SearchAndAddActivityGC(browserstr);
            //String assertion on adding training activities
            String successMsg1 = objAddContent.SuccessMsg();

            String successMsg = objContent.SuccessMsgDisplayed();
        //    StringAssert.Contains("The item was created.", successMsg);
            driver.WaitForElement(ObjectRepository.CheckinNew);
            driver.ClickEleJs(ObjectRepository.CheckinNew);
        }

        [SetUp]
        public void SetUp()
        {
        
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);

          
        }

        //[Test, Order(1)]
        
        public void Enroll_In_Curriculum_24948()
        {
            Assert.IsTrue(objContentSearch.enrollInCurriculum(Variables.curriculumTitle + browserstr, browserstr));
        }

        //[Test, Order(2)]
        public void Cancel_Enrollment_In_Curriculum_26340()
        {
            Assert.IsTrue(objContentSearch.cancelEnrollment());
        }

        //[Test, Order(3)]
        public void Launch_Curriculum_26346()
        {
            driver.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            Assert.IsTrue(objContentSearch.accessCurriculum(browserstr));
          Assert.IsTrue(objContentSearch.launchCurriculum(browserstr));
        }

        //[Test, Order(4)]
        public void View_Curriculum_Certificate_26349()
        {
            Assert.IsTrue(objContentSearch.viewCurriculumCertificate(browserstr));
        }

        //[Test, Order(5)]
        public void View_Curriculum_Details_26367()
        {
            Assert.IsTrue(objContentSearch.viewDetailsOfCourses("Curriculum", browserstr));
        }

        //[Test, Order(6)]
        public void Take_Curriculum_Related_Survey_26347()
        {
            Assert.Fail("Need tobe automated");
        }

        

        [TearDown]
        public void TearDown()
        {
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            Console.WriteLine("TearDown");
            driver.Quit();
        }

       
    } 
}
