using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
 class r_TC_Curriculum : TestBase
    {
        string browserstr = string.Empty;
     public r_TC_Curriculum(string browser)
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

            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
           // objLogin = new Login();
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
        //Creating a curriculum
        public void A_CreateANewCurriculum()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "Curriculums");
            objCreate.FillCurriculumPage("",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            objContent.ContentSearch_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);

            //Assertion for curriculum displayed on search
            Assert.IsTrue(objContentSearch.ViewInList());
        }

        [Test]
        public void B_SimpleAndAdvanceSearchForCurriculum()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);
            // curriculum displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList());

            objContentSearch.AdvanceSearch( Variables.curriculumTitle+browserstr, "ML.BASE.CURRICULUM");
            // curriculum displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList());
        }

      /*  [Test]
        public void C_ManageACurriculum()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle);
            objContentSearch.Content_Click();
            objContent.Edit_Click(driver);
            //String assertion on updating curriculum
            String successMsg = objContent.SuccessMsgDisplayed(driver);
            StringAssert.Contains("The changes were saved.", successMsg);
        }
     */
        [Test]
        public void D_AssignRequiredTrainingToACurriculum()
        {
            //objTrainingHome.AdminConsole_Click(driver);
            //objAdminConsole.RequiredTraining_Click(driver);
            TrainingHomeobj.click_systemOptions();
         //   TrainingHomeobj.click_systemOptionsTab("Training");
            TrainingHomeobj.click_systemOptionsAccordian("Required Training");
            TrainingHomeobj.click_systemOptionsLink("Training Assignments");
            objReqTrainingConsole.Click_RequiredTrainingContentSearch(Variables.curriculumTitle+browserstr);
            objReqTrainingConsole.Click_GoToRequiredTraining();
           Assert.IsTrue( objReqTraining.Assigntraining());
           
           // objTrainingHome.QuitAdminConsole(driver);
        }

        [Test]
        public void E_AddTrainingActivitiesToTheCurriculum()
        {
            // PreRequisite - Create Classroom Course
            driver.Navigate_to_TrainingHome();
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "Classroom Course");
            objCreate.FillClassroomCoursePage("",browserstr);

            objContent.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("",browserstr);
            objTrainingActivities.AddTrainingActivities_Click();
            objAddContent.SearchAndAddActivity(browserstr);
            //String assertion on adding training activities
            String successMsg = objAddContent.SuccessMsg();
            StringAssert.Contains("The selected items were added.", successMsg);
        }

        [Test]
        //Assigning survey to a curriculum
        public void F_AssignASurveyToTheCurriculum()
        {
            //Steps to create survey to available on curriculum - PreRequisite
            //objTrainingHome.AdminConsole_Click(driver);
            //objAdminConsole.Surveys_Click(driver);
            //objAdminSurveys.CreateSurveys(driver);
            //objTrainingHome.QuitAdminConsole(driver);
            TrainingHomeobj.click_systemOptions();
          //  TrainingHomeobj.click_systemOptionsTab("Training");
            TrainingHomeobj.click_systemOptionsAccordian("Content Management");
            TrainingHomeobj.click_systemOptionsLink("Surveys");
            objAdminSurveys.CreateSurveys(driver,browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1",browserstr);

            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.Manage_Click();
            objSurveys.AssigningSurveys(driver,browserstr);
            //String assertion on assigning survey
            String successMsg = objSurveys.SuccessMsg_Survey(driver);
            StringAssert.Contains("The surveys were assigned.", successMsg);

            objContent.CheckIn();
            isCurriculum = true;
            objContent.MyOwnLearning_Click();
            objTrainingHome.Click_TrainingCatalogLink();
            objBrowseTraining.Populate_SearchText(Variables.curriculumTitle+browserstr);
            objBrowseTraining.Set_SearchType("All words");
            objBrowseTraining.Click_Search();
            objSearchResults.Content_Click();
            objDetails.CompleteContent();
            //Asserting Survey displayed on completion of certification
            Assert.IsTrue(objDetails.SurveyDisplays());
        }

        [Test]
        public void G_CopyACurriculum()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.Copy_Click();

            //String assertion on Copy of the curriculum
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was copied. Use the workflow steps to make changes to the new item.", successMsg);
        }

        [Test]
        public void H_DeleteACurriculum()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.DeleteContent_Click();
            //String assertion on deletion of curriculum
            String successMsg = objTraining.SuccessMsg_DeletingCertification();
            StringAssert.Contains("The selected items were deleted.", successMsg);
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
