using System;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestAutomation.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Surveys : TestBase
    {
        string browserstr = string.Empty;
        public Surveys(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            //  driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://prdct-mg-17-3.mksi-lms.net/");
            //driver.Navigate().GoToUrl("https://baseqa-17-3-m-c1.meridianksi.net");


        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }

        [Test, Order(1)]
        public void Survey_Answer_creation_Edit_Removal_30224()
        {
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("siteadmin").WithPassword("passwrod").Login();
            Pages.Login.GotoLogin_Page();
            CommonSection.Manage.Training.SurveysClick();
            Pages.ManageSurveys.Search_Survey("reg_Survey");
            Pages.ManageSurveys.ClickAnswersTab();
            Pages.ManageSurveys.ClickCreateAnswerButton();
            Pages.ManageSurveys.Frame.EditAnswer();
            Pages.ManageSurveys.Frame.EditAnswer.Textbox.Name_FillTextName("Reg_Answer");
            Pages.ManageSurveys.Frame.EditAnswer.Textbox.FillResponse1("Reg_Response1");
            Pages.ManageSurveys.Frame.EditAnswer.Textbox.FillResponse2("Reg_Response2");
            Pages.ManageSurveys.Frame.EditAnswer.Click_AddAnother_responselink("Reg_Response2");
            Pages.ManageSurveys.Frame.EditAnswer.Textbox.FillResponse2("Reg_Response3");
            Pages.ManageSurveys.ClickCreateButton();
            Pages.ManageSurveys.ClickSurveyssTab();
            Pages.ManageSurveys.Search_ExistingSurvey("reg_Survey");// you have to create Reg_Survey
            Pages.ManageSurveys.ClickSurveyName_FromSurveyResults();
            Pages.Reg_Survey.ClickStructureTab();
            Pages.Structure.Click_Add_A_Question_Link();
            Pages.Structure.Frame.EditQuestion.FillTextin_Add_a_QuestionTextbox("Please enter your choice");
            Pages.Structure.Frame.EditQuestion.Click_Choose_ExistingAnser();
            Pages.Structure.Frame.EditQuestion.Select_Choose_ExistingAnswer.Select("Reg_Answer");
            Pages.Structure.Frame.EditQuestion.Click_Createbutton();
            Pages.Structure.Assert.Validate_RecentlyAddedQuestion("Please Enter your Choice");
            Pages.Structure.ClickMenu.Logout();
            Assert.Pages.Login.Userlogin();
            
        }
        [Test, Order(2)]
        public void Branching_logic_into_survey_scale_30296()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Click_Create.Surveys();
            Pages.Create.FillTextinTitleTextbox("Reg_Survey");
            Pages.Create.ClickCreateButton();
            Pages.Structure.ClickEditPageDescriptionLink();
            Pages.Structure.Frame.EditPageDescription.FillTextin_PageDescriptionTextbox("This is Desc");
            Pages.Structure.Frame.EditPageDescription.ClickOkbutton();
            Pages.Structure.Assert.DescriptionText("This is Desc");
            Pages.Structure.ClickAddANewPagelink();
            Pages.Structure.Assert.Page2("Page 2");
            Pages.Structure.ClickAddaNewQuestionLink();
            Pages.Structure.Frame.EditAnswer.Textbox.Name_FillTextName("Reg_Answer");
            Pages.Structure.Frame.EditAnswer.Textbox.FillResponse1("Reg_Response1");
            Pages.Structure.Frame.EditAnswer.Textbox.FillResponse2("Reg_Response2");
            Pages.Structure.Frame.EditAnswer.Click_AddAnother_responselink("Reg_Response2");
            Pages.Structure.Frame.EditAnswer.Textbox.FillResponse2("Reg_Response3");
            Pages.Structure.Frame.ClickCreateButton();
            Pages.Structure.AssertMultipleQuestions("Multiple");
            Pages.Structure.ClickAddaNewQuestionLink();
            Pages.Structure.Frame.EditAnswer.Dropdown.SelectValue("Short Answer");
            Pages.Structure.Frame.EditAnswer.Textbox.Name_FillTextName("What is your name?");
            Pages.Structure.Frame.ClickCreateButton();
            Pages.Structure.AssertShortAnswer("What is your name?");
            Pages.Structure.ClickAddaNewQuestionLink();
            Pages.Structure.Frame.EditAnswer.Dropdown.SelectValue("Rating");
            Pages.Structure.Frame.EditAnswer.Textbox.Name_FillTextName("Rate it?");
            Pages.Structure.Frame.ClickCreateButton();
            Pages.Structure.AssertRatings("Rate it?");
            Pages.Structure.ClickBranckingIcon_NexttoanyQuestionwithmultipleanswers();
            Pages.Structure.Frame.ManageBranchinLogic.ClickAddARulelink();
            Pages.Structure.Frame.SelectfromDropdownResponse("b");
            Pages.Structure.Frame.SelectfromDropdownAction("Complete Survey");
            Pages.Structure.Frame.ClickSaveButton();
            Pags.Structure.Assert.BranchingTooltip("1 Brancking Rules");
            Pages.Structure.ClickMenu.Logout();
            Assert.Pages.Login.Userlogin();
        }

        [Test, Order(3)]
        public void Manage_Survey_24658()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.Surveys();
            Pages.ManageSurveys.Search_Survey("reg_Survey");
            Pages.ManageSurveys.ClickAnswersTab();
            Pages.ManageSurveys.ClicksSearchbutton();//do a blank search
            Pages.ManageSurveys.ClickQuestionsTab();
            Pages.ManageSurveys.ClicksSearchbutton();//do a blank search
            Pages.ManageSurveys.ClickSurveyssTab();
            Pages.ManageSurveys.ClicksSearchbutton();//do a blank search
            Pages.ManageSurveys.Assert.SearchResultData(); //Verify searched data
            Pages.ManageSurveys.ClickMenu.Logout();
            
        }
        // Testcase for Professional Development Started here below//
        [Test, Order(4)]
        public void User_views_a_list_of_job_titles_US3418()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ClickProfessionalDevelopment();
            Pages.ProfessionalDevelopment.ClickJobTitleTab();
            Pages.ProfessionalDevelopment.Assert.JobtitleRecord();
            Pages.ProfessionalDevelopment.ClickNameColumn();
            Pages.ProfessionalDevelopment.Assert.NameColumnRecords();
            Pages.ProfessionalDevelopment.ClickInfoIcon();
            Pages.ProfessionalDevelopment.NewWindow.info();
            Pages.ProfessionalDevelopment.NewWindow.info.Close();
            Pages.ProfessionalDevelopment.ClickPaginationLink(); //if there are more than 10 record
            Pages.ProfessionalDevelopment.AssertPaginationRecord();
            Pages.ProfessionalDevelopment.ClickMenu.Logout();
           
        }
        [Test, Order(5)]
        public void User_edits_competancy_details_US3411()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ClickProfessionalDevelopment();
            Pages.ProfessionalDevelopment.ClickCompetenciesTab();
            Pages.ProfessionalDevelopment.Clickanyrecordfromlist("A competency");
            Pages.CreateCompetencies.ClickCompetencyDetailsTab();
            Pages.CreateCompetencies.ClickAddDescriptionlink();
            Pages.CreateCompetencies.FillTextinAddDescription("reg_desc");
            Pages.CreateCompetencies.ClickYesCheck();
            Pages.CreateCompetencies.Assert.DescriptionValue("reg_desc");
            Pages.CreateCompetencies.ClickddKeywordslink();
            Pages.CreateCompetencies.FillTextinKeywords("reg_KW");
            Pages.CreateCompetencies.ClickYesCheck();
            Pages.CreateCompetencies.Assert.KeywordsValue("reg_KW");
            Pages.CreateCompetencies.ClickMenu.Logout();

        }
        [Test, Order(6)]
        public void Allow_purchaser_to_pay_with_Credit_Debit_card_via_PayPal_US3557()
        {
            //user story related to Paypal payment gateway
        }

        [Test, Order(7)]
        public void User_views_a_list_of_career_paths_US3441()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ClickProfessionalDevelopment();
            Pages.ProfessionalDevelopment.AssertCareerPathTab();
            Pages.ProfessionalDevelopment.ClickNameColumn();
            Pages.ProfessionalDevelopment.AssertSortingbyName();
            Pages.ProfessionalDevelopment.ClickMenu.Logout();
        }

        [Test, Order(8)]
        public void User_Creates_a_career_path_US3442()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ClickProfessionalDevelopment();
            Pages.ProfessionalDevelopment.AssertCreateCareerPath_Button();
            Pages.CreateCareerPath.ClickTextContains("Unnamed Career Path");
            Pages.CreateCareerPath.FillText("Reg_CareerPath_1");
            Pages.CreateCareerPath.ClickYesCheckmark("");
            Pages.CreateCareerPath.AssertTextContains("Reg_CareerPath_1");
            Pages.CreateCareerPath.ClickMenu.Logout();
        }


        [Test, Order(9)]
                 public void User_edit_a_job_titles_Details_US3467()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ClickProfessionalDevelopment();
            Pages.ProfessionalDevelopment.ClickJobTitleTab();
            Pages.ProfessionalDevelopment.Assert.JobtitleRecord();
            Pages.ProfessionalDevelopment.ClickanyRecord();
            Pages.ManageJobtitle.Assert.CareerTrackTab("Career Track");
            Pages.ManageJobtitle.ClickJobDetailsTab();
            Pages.ManageJobtitle.ClickJobcodelink();
            Pages.ManageJobtitle.FillTextinJobcode("reg1");
            Pages.ManageJobtitle.ClickYesCheck();
            Pages.ManageJobtitle.Assert.JobcodeValue("reg1");
            Pages.ManageJobtitle.ClickAddDescriptionlink();
            Pages.ManageJobtitle.FillTextinAddDescription("reg_desc");
            Pages.ManageJobtitle.ClickYesCheck();
            Pages.ManageJobtitle.Assert.DescriptionValue("reg_desc");
            Pages.ManageJobtitle.ClickddKeywordslink();
            Pages.ManageJobtitle.FillTextinKeywords("reg_KW");
            Pages.ManageJobtitle.ClickYesCheck();
            Pages.ManageJobtitle.Assert.KeywordsValue("reg_KW");
            Pages.ManageJobtitle.ClickMenu.Logout();
            
        }
        [Test, Order(10)]
        public void User_views_competencies_column_in_list_of_job_titles_US3554()
        {
           
                Pages.Login.GotoLogin_Page();
                Pages.Login.Login_User("siteadmin", "passwrod");
                Pages.Homepage.Manage.ClickProfessionalDevelopment();
                Pages.ProfessionalDevelopment.ClickJobTitleTab();
                Pages.ProfessionalDevelopment.Assert.JobtitleRecord();
                Pages.ProfessionalDevelopment.ClickCompetencies.column();
                Pages.ProfessionalDevelopment.Assert.CompetienciesRecords();
                Pages.ProfessionalDevelopment.Click.Jobtitle("Reg_JT");
                Pages.ManageJobTitle.Assert.CompetenciesRecorts();
                Pages.ManageJobTitle.ClickMenu.Logout();

           
        }
        [Test, Order(11)]
        public void User_searches_for_a_job_title_US3427()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            TrainingPageki.CommonSection.Manage.ClickProfessionalDevelopment();
            Pages.ProfessionalDevelopment.ClickJobTitleTab();
            Pages.ProfessionalDevelopment.EnterTextinSearchTextbox("Reg_JT");
            Pages.ProfessionalDevelopment.ClickSearchicon();
            Pages.ProfessionalDevelopment.assert.SearchRecord("Reg_JT");
            Pages.ProfessionalDevelopment.ClickMenu.Logout();
        }

        [Test, Order(12)]
        public void User_Remove_Competency_from_existing_Job_title_31504()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ClickProfessionalDevelopment();
            Pages.ProfessionalDevelopment.ClickCompetenciesTab();
            Pages.ProfessionalDevelopment.Clickanyrecordfromlist("A competency");

        }
        [Test, Order(999999)]
        public void Test_Test()
        {
            //Template script here
        }
    }






}
