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
 class q_TC_Certification : TestBase  
   {
        string browserstr = string.Empty;
        public q_TC_Certification(string browser)
            : base(browser)
        {
            browserstr = browser;
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

        
        
        [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
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

        [SetUp]
        public void SetUp()
        {
          
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
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "Certification");
            // objCreate.FillCertificationPageByExcel(driver);
            objCreate.FillCertificationPage(browserstr);

            //String Assertion on new certification creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            objContent.ContentSearch_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);

            //Assertion for certification displayed on search
            Assert.IsTrue(objContentSearch.ViewInList());
        }

        [Test]
        //Simple and advance search of created certification
        public void B_SimpleAndAdvanceSearchForCertification()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            // Certification displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList());

            objContentSearch.AdvanceSearch(Variables.certTitle + browserstr, "ML.BASE.CERTIFICATION");
            // Certification displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList());
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
        [Test]
        //Assigning Required Training to a certification
        public void D_AssignRequiredTrainingToACertification()
        {
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-requiredTrainingManagement']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Training Assignments')]"));
            driver.selectWindow("Required Training Console");
            //objTrainingHome.AdminConsole_Click(driver);
          //  objAdminConsole.RequiredTraining_Click(driver);
            objReqTrainingConsole.Click_RequiredTrainingContentSearch(Variables.certTitle + browserstr);
            objReqTrainingConsole.Click_GoToRequiredTraining();
           Assert.IsTrue( objReqTraining.Assigntraining());
           driver.Navigate_to_TrainingHome();
           
          //  objTrainingHome.QuitAdminConsole(driver);
        }

        [Test]
        //Add Objectives to a certification
        public void E_AddObjectivesToTheCertification()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
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
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "Bundle");
            objCreate.FillBundlePage(browserstr);

            objContent.MyResponsiblities_click();
            objTraining.SearchContent_Click();
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
            objTraining.SearchContent_Click();
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
            objTraining.SearchContent_Click();
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
           // TrainingHomeobj.click_systemOptions();
           //// TrainingHomeobj.click_systemOptionsTab("Training");
           // TrainingHomeobj.click_systemOptionsAccordian("Content Management");
           // TrainingHomeobj.click_systemOptionsLink("Surveys");
           // objAdminSurveys.CreateSurveys(driver,browserstr);
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
           // driver.UserLogin("admin",browserstr);
          //  objTrainingHome.QuitAdminConsole(driver);
           

            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.Manage_Click();
            objSurveys.AssigningSurveys(driver,browserstr);
            //String assertion on assigning survey
            String successMsg = objSurveys.SuccessMsg_Survey(driver);
            StringAssert.Contains("The surveys were assigned.", successMsg);

            objContent.CheckIn();
            objContent.MyOwnLearning_Click();
         //   objTrainingHome.Click_TrainingCatalogLink();
            objBrowseTraining.Populate_SearchText(Variables.certTitle + browserstr);
            //objBrowseTraining.Set_SearchType("All words");
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
            objTraining.SearchContent_Click();
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
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.certTitle + browserstr);
            objContentSearch.Content_Click();
            objContent.DeleteContent_Click();

            //String assertion on deletion of certification
            String successMsg = objTraining.SuccessMsg_DeletingCertification();
            StringAssert.Contains("The selected items were deleted.", successMsg);
        }

        [TearDown]
        public void TearDown()
        {
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            Console.WriteLine("TearDown");
            driver.Quit();
        }

       
    } 
}
