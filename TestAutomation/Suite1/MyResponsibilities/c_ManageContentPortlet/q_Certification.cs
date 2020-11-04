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
 class q_TC_Certificationold : TestBase  
   {
        string browserstr = string.Empty;
        public q_TC_Certificationold(string browser)
            : base(browser)
        {
            browserstr = browser;
            // driver.Manage().Window.Maximize();
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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
            objCertification = new Certification();
            objObjective = new Objective();
            objAddContent = new AddContent(driver);
            objRecertification = new ReCertification();
        }
        public static int addingOptions;
       
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
        public Certification objCertification;
        public AddContent objAddContent;
        public ReCertification objRecertification;
        public static string _baseUrl;
        public Objective objObjective;

        
        
      
        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);

                driver.UserLogin("admin", browserstr);
        }
            
        [Test]
        //Creating new certification
        public void A_CreateANewCertification()
        {
            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Certificate_CourseClick);
            // objCreate.FillCertificationPageByExcel(driver);
            objCreate.FillCertificationPage(browserstr);

            //String Assertion on new certification creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            objTrainingHome.MyResponsiblities_click();
          //  objContent.ContentSearch_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);

            //Assertion for certification displayed on search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.certTitle + browserstr));
        }

       // [Test]
        //Simple and advance search of created certification
        public void B_SimpleAndAdvanceSearchForCertification()
        {
            objTrainingHome.MyResponsiblities_click();
          //  objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            // Certification displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.certTitle + browserstr));
            objTrainingHome.MyResponsiblities_click();
            objContentSearch.AdvanceSearch(Variables.certTitle + browserstr, "ML.BASE.CERTIFICATION");
            // Certification displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.certTitle + browserstr));
        }
     /*
        [Test]
        //Editing existing certification
        public void C_ManageACertification()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.certTitle);
            objContentSearch.Content_Click();
            objContent.Edit_Click(driver);
            //String assertion on updating certification
            String successMsg = objContent.SuccessMsgDisplayed(driver);
            StringAssert.Contains("The changes were saved.", successMsg);
        }
     */
      //  [Test]
        //Assigning Required Training to a certification
        public void D_AssignRequiredTrainingToACertification()
        {
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-requiredTrainingManagement']"));
            driver.ClickEleJs(By.XPath(".//*[@id='admin-console-requiredTrainingManagement']/div/ul/li[1]/a"));
            driver.SwitchWindow("Required Training Console");
            //objTrainingHome.AdminConsole_Click(driver);
          //  objAdminConsole.RequiredTraining_Click(driver);
            objReqTrainingConsole.Click_RequiredTrainingContentSearch(Variables.certTitle + browserstr);
            objReqTrainingConsole.Click_GoToRequiredTraining();
           Assert.IsTrue( objReqTraining.Assigntraining());
           
          //  objTrainingHome.QuitAdminConsole(driver);
        }

        [Test]
        //Add Objectives to a certification
        public void E_AddObjectivesToTheCertification()
        {
          //  driver.Navigate_to_TrainingHome();
            objTrainingHome.MyResponsiblities_click();
            //objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.Add_Objective();
            objObjective.AddObjective(driver);
            //String assertion on adding Objective to a certification
            String successMsg = objObjective.SuccessMsg_Objective(driver);
            StringAssert.Contains("The item was added.", successMsg);
        }

        [Test]
        //Add Certification content to the certification
        public void F_AddCertificationActivitiesToTheCertification()
        {
            //Add Bundle - PreRequite
            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Bundle_CourseClick);
            objCreate.FillBundlePage(browserstr);

            objTrainingHome.MyResponsiblities_click();
            //    objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.Add_CertificationContent();
            objCertification.AddContent(driver);
            objAddContent.AddingBundle(browserstr);

            //String Assertion on adding Certification activities to the certification
            String successMsg = objAddContent.SuccessMsg();
            StringAssert.Contains("The selected content items were added. If inactive content items were added to the certification, users will be unable to complete these items. If external learning content has been added, an administrator must approve the external learning content before it will be applied to the user's learning record.", successMsg);

        }

     //   [Test]
        //Add Re-Certication content to the certification 
            //Test is on hold
        public void G_AddReCertificationActivitiesToTheCertification()
        {
            addingOptions = 1;
            objTrainingHome.MyResponsiblities_click();
       //     objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.Add_ReCertification();
            objRecertification.AddContent(driver);
            objAddContent.AddingBundle(browserstr);

            //String Assertion on adding ReCertification activities to the certification
            String successMsg = objAddContent.SuccessMsg();
            StringAssert.Contains("The selected content items were added. If inactive content items were added to the certification, users will be unable to complete these items. If external learning content has been added, an administrator must approve the external learning content before it will be applied to the user's learning record.", successMsg);
        }


        [Test]
        public void H_AddAlternateOptionstoTheCertification()
        {
            addingOptions = 2;
            objTrainingHome.MyResponsiblities_click();
        //    objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.Add_AlternateOption();
            objCertification.AddContent(driver);
            objAddContent.AddingBundle(browserstr);

            //String Assertion on adding Alternate activities to the certification
            String successMsg = objAddContent.SuccessMsg();
            StringAssert.Contains("The selected content items were added. If inactive content items were added to the certification, users will be unable to complete these items. If external learning content has been added, an administrator must approve the external learning content before it will be applied to the user's learning record.", successMsg);
        }

        [Test]
        //Assigning survey to a certification
        public void I_AssignASurveyToTheCertification()
        {
            //Steps to create survey to available on certification - PreRequisite
            //objTrainingHome.AdminConsole_Click(driver);
            //objAdminConsole.Surveys_Click(driver);
            //TrainingHomeobj.click_systemOptions();
           // TrainingHomeobj.click_systemOptionsTab("Training");
            //TrainingHomeobj.click_systemOptionsAccordian("Content Management");
            //TrainingHomeobj.click_systemOptionsLink("Surveys");
            //objAdminSurveys.CreateSurveys(driver,browserstr);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //driver.UserLogin("admin",browserstr);
          //  objTrainingHome.QuitAdminConsole(driver);
           

            objTrainingHome.MyResponsiblities_click();
       //     objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.Manage_Click();
            objSurveys.AssigningSurveys(driver,browserstr);
            //String assertion on assigning survey
            String successMsg = objSurveys.SuccessMsg_Survey(driver);
            StringAssert.Contains("The surveys were assigned.", successMsg);

            objContent.CheckIn();
            objContent.MyOwnLearning_Click();
            objTrainingHome.Click_TrainingCatalogLink();
            objBrowseTraining.Populate_SearchText(Variables.certTitle + browserstr);
        //    objBrowseTraining.Set_SearchType("All words");
            objBrowseTraining.Click_Search();
            objSearchResults.Content_Click();
            objDetails.CompleteContent();
            //Asserting Survey displayed on completion of certification
            Assert.IsTrue(objDetails.SurveyDisplays());
        }

        [Test]
        public void J_CopyTheCertification()
        {
            objTrainingHome.MyResponsiblities_click();
       //     objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.Copy_Click();

            //String assertion on Copy of the certification
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was copied. Use the workflow steps to make changes to the new item.", successMsg);
        }

        [Test]
        //Deleting a certification
        public void K_DeleteACertification()
        {
            Document documentpage = new Document(driver);
            objTrainingHome.MyResponsiblities_click();
         //   objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
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

