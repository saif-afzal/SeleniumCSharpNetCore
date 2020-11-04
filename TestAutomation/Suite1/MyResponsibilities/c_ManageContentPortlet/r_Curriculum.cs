using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
 class r_TC_Curriculumold : TestBase
    {
        string browserstr = string.Empty;
     public r_TC_Curriculumold(string browser)
            : base(browser)
        {
            browserstr = browser;
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            InitializeBase(driver);
            Driver.Instance = driver;
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
        
        
     

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
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
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
            objCreate.FillCurriculumPage("",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            objTrainingHome.MyResponsiblities_click();
            //objContent.ContentSearch_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);

            //Assertion for curriculum displayed on search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.curriculumTitle + browserstr));
        }

       // [Test]
        public void B_SimpleAndAdvanceSearchForCurriculum()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);
            // curriculum displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.curriculumTitle + browserstr));

            objContentSearch.AdvanceSearch( Variables.curriculumTitle+browserstr, "ML.BASE.CURRICULUM");
            // curriculum displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.curriculumTitle + browserstr));
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
     //   [Test]
        public void D_AssignRequiredTrainingToACurriculum()
        {
            //objTrainingHome.AdminConsole_Click(driver);
            //objAdminConsole.RequiredTraining_Click(driver);
            driver.WaitForElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-requiredTrainingManagement']"));
            driver.ClickEleJs(By.XPath(".//*[@id='admin-console-requiredTrainingManagement']/div/ul/li[1]/a"));
            driver.SwitchWindow("Required Training Console");
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
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            objCreate.FillClassroomCoursePage("",browserstr);

            objTrainingHome.MyResponsiblities_click();
         //   objTraining.SearchContent_Click();
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
            //driver.Navigate_to_TrainingHome();
            //driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-contentManagement']"));
            //driver.ClickEleJs(By.XPath("//a[contains(.,'Surveys')]"));
            //driver.SwitchWindow("Surveys");
            //objAdminSurveys.CreateSurveys(driver,browserstr);
            ////driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            ////driver.UserLogin("admin1",browserstr);
            //driver.Navigate_to_TrainingHome();
            objTrainingHome.MyResponsiblities_click();
         //   objTraining.SearchContent_Click();
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
         //   objTrainingHome.Click_TrainingCatalogLink();
            objBrowseTraining.Populate_SearchText(Variables.curriculumTitle+browserstr);
            //objBrowseTraining.Set_SearchType("All words");
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
           // objTraining.SearchContent_Click();
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
          //  objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.curriculumTitle+browserstr);
            objContentSearch.Content_Click();
            Document documentpage = new Document(driver);
            string actualresult = documentpage.buttondeletesectionclick();
            Assert.IsTrue(driver.comparePartialString("Success", driver.getSuccessMessage()));
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



    } 
}
