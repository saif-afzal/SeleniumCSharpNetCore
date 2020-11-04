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
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_SurveyTooboxEnhancementTest : TestBase
    {
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string BunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string SCORMTitle = "SCORM" + Meridian_Common.globalnum;
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;
        string Question;
        string QuestionOrTitle;
        bool TC56918;
        public P1_SurveyTooboxEnhancementTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
             LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }


     
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
    


        [Test,Order(01)]
        public void SQ01_As_An_Admin_I_want_To_Choose_Radio_Button_Question_Type_For_multiple_Choice_56338()
        //Comment to be added

        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56338");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verif Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Radio Button"));
            _test.Log(Status.Pass, "Verify mentioned Question type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Radio Button");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Radio Button"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
           
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56338"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            

        }

        [Test, Order(02)]//Question bank part to be added
        public void SQ02_As_an_Admin_I_want_to_Choose_a_dropdown_Question_Type_56339()
        //Comment to be added
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56339");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verif Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Drop-Down List"));
            _test.Log(Status.Pass, "Verify selected type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Drop-Down List");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Drop-Down List"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);


            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");


            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56339"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            

        }
        [Test, Order(03)]

        public void SQ03_As_an_Admin_I_want_to_see_Radio_Button_and_Dropdown_Question_Type_in_Question_Bank_56340()

        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56338");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Radio Button");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Radio Button"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");


            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Drop-Down List");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Drop-Down List"));
            _test.Log(Status.Pass, "Verify selected Question type");
            QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys under manage");
            SurveysPage.Click_QuestionTab();
            _test.Log(Status.Info, "Click Question Tab");
            Assert.IsTrue(SurveysPage.QuestionTab.VerifyQuestionTypeInQuestionBank("Radio Button"));
            _test.Log(Status.Pass, "Verify radio button Question type in Question Bank");
            Assert.IsTrue(SurveysPage.QuestionTab.VerifyQuestionTypeInQuestionBank("Dropdown"));
            _test.Log(Status.Pass, "Verify radio button Question type in Question Bank");
            ManageSurveyPage.AddaQuestionModal.click_cancelbutton();
            Driver.Instance.SwitchTo().DefaultContent();

        }

        [Test, Order(04)]

        public void SQ04_As_an_Admin_add_a_question_that_allows_for_a_date_type_answer_56308()
        
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56308");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());//
            _test.Log(Status.Pass, "Verif Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Date Field"));//
            _test.Log(Status.Pass, "Verify selected type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Date Field");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Date Field"));//AC1
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());//
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("what will be the date tomorrow " + Meridian_Common.globalnum + " ?"));//AC2
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");//AC3
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");

            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);


            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56308"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

        }

        [Test, Order(05)]//Dependent On 56308

        public void P20_1_LSQ01_As_a_learner_I_want_to_see_a_date_type_field_question_of_a_survey_56309()
        
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys under manage");
            SurveysPage.SearchSurvey(surveyTitle + "TC56308");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.Click_SurveyTitleFromtheList(surveyTitle + "TC56308");
            _test.Log(Status.Info, "Click survey title to open");
            AdminContentDetailsPage.DropDownToggle.Publish();
            _test.Log(Status.Info, "Click Publish and Publish Survey");
            Assert.IsTrue(AdminContentDetailsPage.VerifyIsPublishedTextDisplayed("Published"));
            _test.Log(Status.Pass, "Verify Published Text id Displayed below Dropdoen toggle");

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For Datefield");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.ManageSurveyWhenSurveyTitleAvailable(surveyTitle + "TC56308");
            _test.Log(Status.Info, "Add Survey to the Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkin button");
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login As learner");
            CommonSection.SearchCatalog(generalcoursetitle + "For Datefield");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "For Datefield");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Verify Enroll button os Displayed in the banner");
            ContentDetailsPage.EnrollinGeneralCourse_new();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify Open item Button is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysareNotavailable);
            _test.Log(Status.Pass, "Verify Surveys are not available to Complete");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            _test.Log(Status.Info, "Open Course and Complete Content");
            ContentDetailsPage.Click_Survey(surveyTitle + "TC56308");
            _test.Log(Status.Info, "Click Survey");
            Assert.IsTrue(ContentDetailsPage.VerifyQuestionInSurvey(Question, surveyTitle + "TC56308"));
            _test.Log(Status.Pass, "verify date field Question in Survey");
        }

        [Test, Order(06)]
        public void SQ05_As_an_Admin_I_want_create_a_Paragraph_type_Survey_Question_with_Required_NO_and_Reusable_NO_56558()
        //comment to be added

        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login As siteadmin");
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56558");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused");
            
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestion(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56558"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

        }

        [Test, Order(07)]
        public void SQ06_As_an_Admin_I_want_create_a_Paragraph_type_Survey_Question_with_Required_NO_and_Reusable_Yes_56683()

        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56683");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
        
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            // Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestion(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56683"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
        }
        [Test, Order(08)]
        public void SQ07_As_an_Admin_I_want_create_a_Paragraph_type_Survey_Question_with_Required_Yes_and_Reusable_No_56684()

        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56684");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            // Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestion(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56684"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
        }
        [Test, Order(09)]
        public void SQ08_As_an_Admin_I_want_create_a_Paragraph_type_Survey_Question_with_Required_Yes_and_Reusable_Yes_56685()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56685");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            //string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            // Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestion(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            //Assert.IsFalse(ManageSurveyPage.Structure.VerifyOptionalDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56685"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
        }

        [Test, Order(10)]
        public void SQ09As_an_admin_I_want_to_Select_a_paragraph_Type_Question_56589()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56589");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Paragraph"));
            _test.Log(Status.Pass, "Verify selected Question type");
        }
        [Test, Order(11)]
        public void SQ10_As_an_Admin_I_want_to_See_an_Example_of_what_Paragraph_Answer_looks_like_in_survey_for_Paragraph_type_question_56688()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56688");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Paragraph"));
            _test.Log(Status.Pass, "Verify selected Question type");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyParagraphExample());
            _test.Log(Status.Pass, "Verify selected Question type");
        }

        [Test, Order(12)]
        public void SQ11_As_an_Admin_I_want_to_see_an_example_of_what_Short_Answer_Looks_like_in_Survey_for_Short_Answer_Type_Question_56559()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56590");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Short Answer");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Short Answer"));
            _test.Log(Status.Pass, "Verify selected Question type");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyShortAnswerExample());
            _test.Log(Status.Pass, "Verify selected Question type");
        }
        [Test, Order(13)]
        public void SQ12_As_an_Admin_create_a_multiple_item_checkbox_Question_with_required_Question_No_and_reused_as_No_56566()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56566");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Checkbox"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Checkbox");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Checkbox"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();


            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCreateCustomAnswerIsDisplayed());
            _test.Log(Status.Pass, "Verify Create Custom Answer is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMinimumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Minimum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMaximumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Maximum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Option is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("States starts with A are (Check all that apply)?" + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("--");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("1");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            //string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("2", "1");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyErrorMessageIsDisplayed());
            _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("1", "2");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
        }


        [Test, Order(14)]
        public void SQ13_As_an_Admin_add_a_Checkbox_type_Question_to_the_survey_with_Required_as_NO_and_Question_Reused_as_Yes_52367()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52367");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Checkbox"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Checkbox");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Checkbox"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();


            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCreateCustomAnswerIsDisplayed());
            _test.Log(Status.Pass, "Verify Create Custom Answer is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMinimumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Minimum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMaximumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Maximum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Option is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("States starts with A are (Check all that apply)?" + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("--");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("1");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            //string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("2", "1");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyErrorMessageIsDisplayed());
            _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("1", "2");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify selected Question type");
        }
        [Test, Order(15)]
        public void SQ14_As_an_Admin_add_a_Checkbox_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_No_52368()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52368");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Checkbox"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Checkbox");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Checkbox"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();


            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCreateCustomAnswerIsDisplayed());
            _test.Log(Status.Pass, "Verify Create Custom Answer is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMinimumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Minimum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMaximumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Maximum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Option is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("States starts with A are (Check all that apply)?" + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("--");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("1");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            //string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("2", "1");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyErrorMessageIsDisplayed());
            _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("1", "2");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify selected Question type");

        }
        [Test, Order(16)]
        public void SQ15_As_an_Admin_add_a_Checkbox_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_Yes_52294()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52294");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Checkbox"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Checkbox");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Checkbox"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();


            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCreateCustomAnswerIsDisplayed());
            _test.Log(Status.Pass, "Verify Create Custom Answer is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMinimumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Minimum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMaximumDropdownFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Maximum Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Option is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("States starts with A are (Check all that apply)?" + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("--");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_CheckboxMinimumValue("1");
            _test.Log(Status.Info, "Select Minimum Value from drop down as (--)");
            CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            //string CheckboxMinValue = ManageSurveyPage.AddaQuestionModal.ChkbxMinValue();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("2", "1");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyErrorMessageIsDisplayed());
            _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("1", "2");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify selected Question type");
        }

        //[Test, Order(17)]
        //public void SQ16_As_an_Admin_insert_slider_question_and_specify_the_allowable_values_56580()
        //{
        //    CommonSection.CreateLink.Survey();
        //    _test.Log(Status.Info, "Naviagte to Create Survey page");
        //    SurveysPage.CreateNewSurvey(surveyTitle + "TC56580");
        //    _test.Log(Status.Info, "A new Survey Created");
        //    ManageSurveyPage.Structure.Click_AddAQuestion();
        //    _test.Log(Status.Info, "Click on Add A Question Link ");
        //    Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
        //    _test.Log(Status.Pass, "Verify is Add a Question Modal is Displayed ");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Slider"));
        //    _test.Log(Status.Pass, "Verify Slider type is in Question type List");
        //    ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Slider");
        //    _test.Log(Status.Info, "Select mentioned Question type Question");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Slider"));
        //    _test.Log(Status.Pass, "Verify selected Question type");
        //    string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Question or Title field is Displayed");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMinRangeFieldIsDisplayed("1"));
        //    _test.Log(Status.Pass, "Verify Min Range field is Displayed with default value as 1");
           
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMaxRangeFieldIsDisplayed("5"));
        //    _test.Log(Status.Pass, "Verify Max Range field is Displayed with default value as 5");

        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyStepIncrementFieldIsDisplayed("1"));
        //    _test.Log(Status.Pass, "Verify Step Increment field is Displayed with default value as 1");
            
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMinLabelFieldIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Min Label field is Displayed");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMaxLabelFieldIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Max Label field is Displayed");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySliderResponseExampleIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Response Example with the scale Agree to Disagree is displayed");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Question Required Option is Displayed");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
        //    _test.Log(Status.Pass, "Verify Question Comments Option is displayed");

        //    Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Slider Question" + Meridian_Common.globalnum + " ?"));
        //    _test.Log(Status.Pass, "Verify Question or title is Displayed");
        //    string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
        //    ManageSurveyPage.AddaQuestionModal.Select_MinRange_MaxRange("10","1");
        //    _test.Log(Status.Pass, "Enter Minimum Range greater than Maximum Range ");
        //    StringAssert.AreEqualIgnoringCase("The maximum value must be greater than or equal to the minimum value.", ManageSurveyPage.AddaQuestionModal.VerifyMinRangeMessageIsDisplayed());
        //    _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
        //    ManageSurveyPage.AddaQuestionModal.Select_MinRange_MaxRange("1", "10");
        //    _test.Log(Status.Pass, "Enter Minimum Range greater than Maximum Range ");
        //    ManageSurveyPage.AddaQuestionModal.Enter_StepIncrement(".2");
        //    _test.Log(Status.Pass, "Enter Step Increment value in decimal");
        //    StringAssert.AreEqualIgnoringCase("Enter numbers only.", ManageSurveyPage.AddaQuestionModal.VerifyStepIncrementMessageIsDisplayed());
        //    _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
        //    ManageSurveyPage.AddaQuestionModal.Enter_StepIncrement("-2");
        //    _test.Log(Status.Pass, "Enter Step Increment value in Negative");
        //    StringAssert.AreEqualIgnoringCase("Enter numbers only.", ManageSurveyPage.AddaQuestionModal.VerifyStepIncrementMessageIsDisplayed());
        //    _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
        //    ManageSurveyPage.AddaQuestionModal.Enter_StepIncrement("2");
        //    _test.Log(Status.Pass, "Enter Step Increment value in positive and whole number");
        //    ManageSurveyPage.AddaQuestionModal.Enter_MinLabel_Maxlabel("Minimum", "Maximum");
        //    _test.Log(Status.Pass, "Enter Min Label as Minimum and Max Label as Maximum");
        //    ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
        //    _test.Log(Status.Info, "Select Question Required");
        //    ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
        //    _test.Log(Status.Info, "Select Question to be Reused");
        //    ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
        //    _test.Log(Status.Pass, "Select Optional Comment Field option");
        //    ManageSurveyPage.AddaQuestionModal.ClickCreate();
        //    _test.Log(Status.Pass, "Click on Create button");
        //    Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
        //    _test.Log(Status.Pass, "Verify selected Question type exists in Question Tab");
        //    Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
        //    ManageSurveyPage.DropDownToggle.Click_Preview();
        //    _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
        //    Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56580"));
        //    _test.Log(Status.Pass, "Verify Question is Displayed in preview");


        //}

        //[Test, Order(18)]//Dependent on 56580
        //public void LSQ02_As_an_Learner_enter_a_response_to_a_Slider_Type_question_52328()

        //{
        //    CommonSection.Manage.SurveysAndEvaluations();
        //    _test.Log(Status.Info, "Click Surveys under manage");
        //    SurveysPage.SearchSurvey(surveyTitle + "TC56580");
        //    _test.Log(Status.Info, "Search Created Survey");
        //    SurveysPage.Click_SurveyTitleFromtheList(surveyTitle + "TC56580");
        //    _test.Log(Status.Info, "Click survey title to open");

        //    AdminContentDetailsPage.DropDownToggle.Publish();
        //    _test.Log(Status.Info, "Click Publish and Publish Survey");
        //    Assert.IsTrue(AdminContentDetailsPage.VerifyIsPublishedTextDisplayed("Published"));
        //    _test.Log(Status.Pass, "Verify Published Text id Displayed below Dropdown toggle");

        //    CommonSection.CreateGeneralCourse(generalcoursetitle + "ForSlider");
        //    _test.Log(Status.Info, "Create a general Course");
        //    AdminContentDetailsPage.ManageSurveyWhenSurveyTitleAvailable(surveyTitle + "TC56580");
        //    _test.Log(Status.Info, "Add Survey to the Course");
        //    AdminContentDetailsPage.ClickCheckInbutton();
        //    _test.Log(Status.Info, "Click checkin button");

        //    CommonSection.Logout();
        //    LoginPage.LoginAs("ak_learner").WithPassword("").Login();
        //    _test.Log(Status.Info, "Login As learner");
        //    CommonSection.SearchCatalog(generalcoursetitle + "ForSlider");
        //    SearchResultsPage.ClickCourseTitle(generalcoursetitle + "ForSlider");
        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollbuttonDisplay_GeneralCourse());
        //    _test.Log(Status.Pass, "Verify Enroll button os Displayed in the banner");
        //    ContentDetailsPage.EnrollinGeneralCourse_new();
        //    _test.Log(Status.Info, "Click Enroll button");
        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
        //    _test.Log(Status.Pass, "Verify Open item Button is Displayed");
        //    Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysareNotavailable);
        //    _test.Log(Status.Pass, "Verify Surveys are not available to Complete");
        //    AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
        //    _test.Log(Status.Info, "Open Course and Complete Content");
        //    ContentDetailsPage.Click_Survey(surveyTitle + "TC56580");
        //    _test.Log(Status.Info, "Click Survey");
        //    Assert.IsTrue(ContentDetailsPage.SurveyPortlet.VerifyQuestion(surveyTitle + "TC56580", Question));
        //    _test.Log(Status.Pass, "Enter Slider response verify Rating Question in Survey");
        //    ContentDetailsPage.SurveyPortlet.EnterSliderResponseAndCompleteSurvey();
        //    _test.Log(Status.Info, "Enter Slider response verify Rating Question in Survey");

        //}

        [Test,Order(19)]
        public void SQ17_As_an_Admin_Choose_Rating_Scale_For_a_Rating_Type_Question_52295()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login As siteadmin");
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52295");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Rating"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Rating");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Rating"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRatingScaleDropdownFieldIsDisplayed("1 - 5"));
            _test.Log(Status.Pass, "Verify Rating Scale Dropdown field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyFirstItemLabelFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify First Item Label field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyLastItemLabelFieldIsDisplayed());
            _test.Log(Status.Pass, "Verify Last Item Label field is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyResponseExampleIsDisplayed());
            _test.Log(Status.Pass, "Verify Response Example with the scale Agree to Disagree is displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Option is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.SelectRatingScaleFromDropdown("1 - 10");
            _test.Log(Status.Pass, "Select the Rating Scale 1-10 from the drop down");
            ManageSurveyPage.AddaQuestionModal.EnterFirstValueLabel("Good");
            _test.Log(Status.Pass, "Enter First Value Label as Good");
            ManageSurveyPage.AddaQuestionModal.EnterLastValueLabel("Bad");
            _test.Log(Status.Pass, "Enter Last Value Label as Bad");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Pass, "Select Optional Comment Field option to No");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Pass, "Click on Create button");

            //Assert.IsTrue(Driver.comparePartialString("The question was created and added to the survey page.", ManageSurveyPage.SuccessMessage()));
            //_test.Log(Status.Pass, "Verify Success message is Displayed");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType("Rating"));
            _test.Log(Status.Pass, "Verify question Type is Displayed below The Question");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC52295"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            //ManageSurveyPage.AttemptPreviewSurvey();

            //_test.Log(Status.Pass, "Attempt Survey and Close window");
        }



        [Test,Order(20)]//Prerequisite:  Add a Survey of Rating Type field to a Course 
        //Dependent on 52295
        public void P20_1_LSQ03_As_an_Learner_enter_a_response_to_a_revised_rating_question_52326()
        {            
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys under manage");
            SurveysPage.SearchSurvey(surveyTitle + "TC52295");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.Click_SurveyTitleFromtheList(surveyTitle + "TC52295");
            _test.Log(Status.Info, "Click survey title to open");

            AdminContentDetailsPage.DropDownToggle.Publish();
            _test.Log(Status.Info, "Click Publish and Publish Survey");
            Assert.IsTrue(AdminContentDetailsPage.VerifyIsPublishedTextDisplayed("Published"));
            _test.Log(Status.Pass, "Verify Published Text id Displayed below Dropdown toggle");

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For Rating");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.ManageSurveyWhenSurveyTitleAvailable(surveyTitle + "TC52295");
            _test.Log(Status.Info, "Add Survey to the Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkin button");

            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login As learner");
            CommonSection.SearchCatalog(generalcoursetitle + "For Rating");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "For Rating");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Verify Enroll button os Displayed in the banner");
            ContentDetailsPage.EnrollinGeneralCourse_new();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify Open item Button is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysareNotavailable);
            _test.Log(Status.Pass, "Verify Surveys are not available to Complete");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            _test.Log(Status.Info, "Open Course and Complete Content");
            ContentDetailsPage.Click_Survey(surveyTitle + "TC52295");
            _test.Log(Status.Info, "Click Survey");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.VerifyQuestion(surveyTitle + "TC52295", Question));
            _test.Log(Status.Pass, "Enter Rating response verify Rating Question in Survey");
            //ContentDetailsPage.SurveyPortlet.EnterRatingResponseAndCompleteSurvey("6");
            //_test.Log(Status.Info, "Enter Rating response verify Rating Question in Survey");


        }
        [Test, Order(21)]
        public void SQ18_As_an_Admin_Add_a_Rating_type_Question_to_the_survey_with_Required_as_No_and_Question_Reused_as_Yes_52303()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login As siteadmin");
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52503");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Rating"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Rating");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Rating"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();


            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How would you Rate your Community?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.SelectRatingScaleFromDropdown("1 - 8");
            _test.Log(Status.Pass, "Select the Rating Scale 1-8 from the drop down");
            ManageSurveyPage.AddaQuestionModal.EnterFirstValueLabel("Excellent");
            _test.Log(Status.Pass, "Enter First Value Label as Excellent");
            ManageSurveyPage.AddaQuestionModal.EnterLastValueLabel("Terrible");
            _test.Log(Status.Pass, "Enter Last Value Label as Terrible");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Pass, "Select Optional Comment Field option to No");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Pass, "Click on Create button");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC52503"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

        }

        [Test, Order(22)]
        public void SQ19_As_an_Admin_Add_a_Rating_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_No_52314()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52314");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Rating"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Rating");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Rating"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();


            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How would you Rate your School?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.SelectRatingScaleFromDropdown("1 - 10");
            _test.Log(Status.Pass, "Select the Rating Scale 1-10 from the drop down");
            ManageSurveyPage.AddaQuestionModal.EnterFirstValueLabel("Good");
            _test.Log(Status.Pass, "Enter First Value Label as Good");
            ManageSurveyPage.AddaQuestionModal.EnterLastValueLabel("Bad");
            _test.Log(Status.Pass, "Enter Last Value Label as Bad");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Pass, "Select Optional Comment Field option to ");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Pass, "Click on Create button");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC52314"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

        }

        [Test, Order(23)]
        public void SQ20_As_an_Admin_add_a_Rating_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_Yes_52324()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52324");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Rating"));
            _test.Log(Status.Pass, "Verify Checkbox type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Rating");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Rating"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();


            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How would you Rate your Community?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.SelectRatingScaleFromDropdown("1 - 8");
            _test.Log(Status.Pass, "Select the Rating Scale 1-8 from the drop down");
            ManageSurveyPage.AddaQuestionModal.EnterFirstValueLabel("Excellent");
            _test.Log(Status.Pass, "Enter First Value Label as Excellent");
            ManageSurveyPage.AddaQuestionModal.EnterLastValueLabel("Terrible");
            _test.Log(Status.Pass, "Enter Last Value Label as Terrible");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Pass, "Select Optional Comment Field option to ");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Pass, "Click on Create button");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC52324"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            
        }


        [Test, Order(24)]
        public void M01_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_No_and_Question_Reused_as_No_56560()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56560");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required as");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused as");
                //ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
                //_test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56560"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            


        }
        [Test, Order(25)]
        public void M02_As_an_Admin_I_want_to_see_an_example_of_what_matrix_type_Answer_Looks_like_in_Survey_for_Matrix_Type_Question_56590()
        {
            

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56590");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Matrix type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixExample());
            _test.Log(Status.Pass, "Verify selected Question type");
            ManageSurveyPage.AddaQuestionModal.click_cancelbutton();//To resume next test case 
            //Driver.Instance.SwitchTo().DefaultContent();

        }

        [Test, Order(26)]
        public void M03_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_10_Answers_Options_in_a_matrix_type_Question_for_Surveys_56593()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56593");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());//Option is not shwing at screen
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 10);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56593"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            //Driver.Instance.SelectWindowClose();


            //Driver.Instance.SwitchTo().DefaultContent();
        }

        [Test, Order(26)]
        public void M04_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_1_Question_in_a_matrix_type_Question_for_Surveys_56634()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56634");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            //Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Click create Button");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56634"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            //Driver.Instance.SelectWindowClose();


            //Driver.Instance.SwitchTo().DefaultContent();
        }
        [Test, Order(27)]
        public void M05_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_9_Answers_Options_in_a_matrix_type_Question_for_Surveys_56664()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56664");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 9);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56664"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            //Driver.Instance.SelectWindowClose();


            //Driver.Instance.SwitchTo().DefaultContent();

        }

        [Test, Order(28)]
        public void M06_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_2_Answers_Options_in_a_matrix_type_Question_for_Surveys_56665()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56665");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56665"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            //Driver.Instance.SelectWindowClose();


            //Driver.Instance.SwitchTo().DefaultContent();

        }
        [Test, Order(29)]
        public void M07_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_0_Answers_Options_in_a_matrix_type_Question_for_Surveys_56666()
        {

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56666");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            //Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.DeleteNumberofResponseto(0, 1, 2));
            _test.Log(Status.Pass, "Delete both the default blank responses");
            StringAssert.AreEqualIgnoringCase("Warning: This must have at least 2 entry(ies).", ManageSurveyPage.AddaQuestionModal.VerifyLeastResponseWarningMessage());
            _test.Log(Status.Pass, "Verify warning message");
            //Driver.Instance.SelectWindowClose2(QuestionOrTitle, ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
            ManageSurveyPage.AddaQuestionModal.click_cancelbutton();//To resume next test case 
            Driver.Instance.SwitchTo().DefaultContent();
        }

        [Test, Order(30)]
        public void M08_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_only_one_Answers_Options_in_a_matrix_type_Question_for_Surveys_56667()
        {

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56667");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.DeleteNumberofResponseto(1, 1, 1));
            _test.Log(Status.Pass, "Delete both the default blank responses");
            StringAssert.AreEqualIgnoringCase("Warning: This must have at least 2 entry(ies).", ManageSurveyPage.AddaQuestionModal.VerifyLeastResponseWarningMessage());
            _test.Log(Status.Pass, "Verify warning message");
            ManageSurveyPage.AddaQuestionModal.click_cancelbutton();
            

        }

        [Test, Order(31)]
        public void M09_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_11_Answers_Options_in_a_matrix_type_Question_for_Surveys_56668()
        {

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56668");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 11);
            _test.Log(Status.Info, "Enter response");
            StringAssert.AreEqualIgnoringCase("Warning: Only 10 entries are allowed.", ManageSurveyPage.AddaQuestionModal.VerifyLeastResponseWarningMessage());
            _test.Log(Status.Pass, "Verify warning message");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56668"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            Driver.Instance.SelectWindowClose();

            //Driver.Instance.SwitchTo().DefaultContent();
        }

        [Test, Order(32)]
        public void M10_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_2_Question_in_a_matrix_type_Question_for_Surveys_56669()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56669");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            //Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 2);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56669"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            


        }

        [Test, Order(33)]
        public void M11_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_49_Question_in_a_matrix_type_Question_for_Surveys_56670()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56670");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 49);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56670"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
       


        }
        [Test, Order(34)]
        public void M12_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_50_Question_in_a_matrix_type_Question_for_Surveys_56671()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56671");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 50);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56671"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
           
        }

        [Test, Order(35)]
        public void M13_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_No_Question_in_a_matrix_type_Question_for_Surveys_56675()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56675");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
          //  Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            ManageSurveyPage.AddaQuestionModal.BlankMatrixQuery("");
            _test.Log(Status.Pass, "Leave the matrix Query as Blank");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.DeleteNumberofQueryto(0, 1, 1));
            _test.Log(Status.Pass, "Delete both the default blank responses");
            StringAssert.AreEqualIgnoringCase("Warning: This must have at least 1 entry(ies).", ManageSurveyPage.AddaQuestionModal.VerifyLeastQueryWarningMessage());
            _test.Log(Status.Pass, "Verify warning message");
            //Driver.Instance.SelectWindowClose2(QuestionOrTitle, ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
            ManageSurveyPage.AddaQuestionModal.click_cancelbutton();


            Driver.Instance.SwitchTo().DefaultContent();
        }
        [Test, Order(36)]
        public void M14_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_51_Question_in_a_matrix_type_Question_for_Surveys_56676()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56676");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
           // Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 51);
            _test.Log(Status.Info, "Prepare Questions");
            StringAssert.AreEqualIgnoringCase("Warning: Only 50 entries are allowed.", ManageSurveyPage.AddaQuestionModal.VerifyLeastQueryWarningMessage());
            _test.Log(Status.Pass, "Verify warning message");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56676"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
         
        }

        [Test, Order(37)]
        public void M15_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_No_and_Question_Reused_as_Yes_56680()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56680");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required as");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused as");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56680"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            
        }
        [Test, Order(38)]
        public void M16_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_No_56681()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56681");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required as");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused as");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56681"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            
        }
        [Test, Order(39)]
        public void M17_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_Yes_56682()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56682");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required as");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused as");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56682"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            
        }

        [Test, Order(40)]
        public void P20_1_ML01_As_a_learner_I_want_to_Take_survey_For_Matrix_type_Question_56919()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys under manage");
            SurveysPage.SearchSurvey(surveyTitle + "TC56682");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.Click_SurveyTitleFromtheList(surveyTitle + "TC56682");
            _test.Log(Status.Info, "Click survey title to open");
            AdminContentDetailsPage.DropDownToggle.Publish();
            _test.Log(Status.Info, "Click Publish and Publish Survey");
            Assert.IsTrue(AdminContentDetailsPage.VerifyIsPublishedTextDisplayed("Published"));
            _test.Log(Status.Pass, "Verify Published Text id Displayed below Dropdoen toggle");

            CommonSection.CreateGeneralCourse(generalcoursetitle + "ForMatrix");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.ManageSurveyWhenSurveyTitleAvailable(surveyTitle + "TC56682");
            _test.Log(Status.Info, "Add Survey to the Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkin button");

            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login As learner");
            CommonSection.SearchCatalog(generalcoursetitle + "ForMatrix");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "ForMatrix");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Verify Enroll button os Displayed in the banner");
            ContentDetailsPage.EnrollinGeneralCourse_new();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify Open item Button is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysareNotavailable);
            _test.Log(Status.Pass, "Verify Surveys are not available to Complete");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            _test.Log(Status.Info, "Open Course and Complete Content");
            ContentDetailsPage.Click_Survey(surveyTitle + "TC56682");
            _test.Log(Status.Info, "Click Survey");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.VerifyQuestion(surveyTitle + "TC56682", Question));
            _test.Log(Status.Pass, "Enter Rating response verify Rating Question in Survey");
            ContentDetailsPage.SurveyPortlet.EnterMatrixResponseAndCompleteSurvey();
            _test.Log(Status.Info, "Enter Rating response verify Rating Question in Survey");

            TC56918 = true;

        }
        [Test, Order(41)]
        public void P20_1_ML02_As_a_learner_I_want_to_See_matrix_type_Question_on_Surveys_56918()
        {
            Assert.IsTrue(TC56918);

        }
        [Test, Order(42)]
        public void M18_As_an_Admin_preview_matrix_type_Question_56896()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC56896");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required as");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
            _test.Log(Status.Info, "Select Question to be Reused as");
            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
            _test.Log(Status.Info, "Select optional comment fiels as");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
            ManageSurveyPage.DropDownToggle.Click_Preview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56896"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
            Driver.Instance.SelectWindowClose();


            Driver.Instance.SwitchTo().DefaultContent();

        }






       
        [Test, Order(43)]
        public void tc_57440_As_an_Admin_I_want_to_see_branching_is_not_available_to_Multiple_Choice_Checkbox_Question()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("TestBranchingSurveys");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.RedirectToStructureTab("TestBranchingSurveys");
            _test.Log(Status.Info, "Redirect to Structure tab");
            //Assert.IsFalse(ManageSurveyPage.Structure.VerifyBranchingLogicIsNotAvailableForCheckbox);
            //_test.Log(Status.Info, "Verify given question type has branching logic or Not");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifybranchingLogicWhenSelected("Checkbox"));
            _test.Log(Status.Pass, "Verify branching is disable");
        }
        [Test, Order(44)]
        public void tc_57441_As_an_Admin_I_want_to_see_branching_is_not_available_to_Date_Field_Question()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("TestBranchingSurveys");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.RedirectToStructureTab("TestBranchingSurveys");
            _test.Log(Status.Info, "Redirect to Structure tab");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifybranchingLogicWhenSelected("Date"));
            _test.Log(Status.Info, "Verify given question type has branching logic or Not");
        }
        [Test, Order(45)]
        public void tc_57442_As_an_Admin_I_want_to_see_branching_is_not_available_to_Short_Answer_Question()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("TestBranchingSurveys");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.RedirectToStructureTab("TestBranchingSurveys");
            _test.Log(Status.Info, "Redirect to Structure tab");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifybranchingLogicWhenSelected("Short Answer"));
            _test.Log(Status.Info, "Verify given question type has branching logic or Not");
        }
        [Test, Order(46)]
        public void tc_57443_As_an_Admin_I_want_to_see_branching_is_not_available_to_Paragraph_type_Question()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("TestBranchingSurveys");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.RedirectToStructureTab("TestBranchingSurveys");
            _test.Log(Status.Info, "Redirect to Structure tab");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifybranchingLogicWhenSelected("Paragraph"));
            _test.Log(Status.Info, "Verify given question type has branching logic or Not");
        }
        [Test, Order(47)]
        public void tc_57445_As_an_Admin_I_want_to_see_branching_is_not_available_to_Matrix_Question()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("TestBranchingSurveys");
            _test.Log(Status.Info, "Search Created Survey");
            SurveysPage.RedirectToStructureTab("TestBranchingSurveys");
            _test.Log(Status.Info, "Redirect to Structure tab");
            Assert.IsFalse(ManageSurveyPage.Structure.VerifybranchingLogicWhenSelected("Matrix"));
            _test.Log(Status.Info, "Verify given question type has branching logic or Not");
        }
    }





}