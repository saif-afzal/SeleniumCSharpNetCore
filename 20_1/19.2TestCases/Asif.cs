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
using TestAutomation.Meridian;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class Asif : TestBase
    {
        string scormtitle = "Survey" + Meridian_Common.globalnum;
        string Evaltittle = "Eval" + Meridian_Common.globalnum;
        string EvaluationTitle = "Evaluation" + Meridian_Common.globalnum;
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        private bool TC35341;
        private bool TC35342;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;

        public string SurveyTittle { get; private set; }

        public Asif(string browser)
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
     
        bool _TC_57918 = false;
        [Test, Order(1)]
        public void As_an_Admin_add_Short_Answer_Type_question_to_the_Evaluation_57771()
        {
            CommonSection.CreateLink.Evaluation();
            _test.Log(Status.Info, "Naviagte to Create Evaluation page");
            EvaluationPage.CreateNewEvaluation(EvaluationTitle + "TC563374");
            ManageEvaluationPage.Structure1.Click_AddQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageEvaluationPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Verify the Add A Question modal");
            ManageEvaluationPage.AddaQuestionModal.Select_QuestionType("Short Answer");
            _test.Log(Status.Info, "Select Short Answer type Question");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifySelected_QuestionType("Short Answer"));
            _test.Log(Status.Pass, "Verify selected Question type Short Answer");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.Verify_ShortAnswerExample());
            _test.Log(Status.Pass, "Verify selected Question type");

            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyQuestionTitleIs_Displayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyingRequiredOptionSliderIs_Displayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyQuestionReusedSliderIs_Displayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            string QuestionType = ManageEvaluationPage.AddaQuestionModal.Question_Type();
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.QuestionOrTitleInputbox_Displayed("How are you asif ali ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionTitle = "How are you asif ali ?";
            ManageEvaluationPage.AddaQuestionModal.Click_Create();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageEvaluationPage.Structure1.Verify_QuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageEvaluationPage.Structure1.Verify_OptionalDisplayed(QuestionTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            //string QuestQuestionTypei = ManageEvaluationPage.Structure.Structure_Question(QuestionType);
            string Question = ManageEvaluationPage.Structure1.Structure_Question(QuestionType);
            ManageEvaluationPage.DropDownToggle.Click_AtPreview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageEvaluationPage.VerifyQuestion_DisplayedInPreview(Question, EvaluationTitle + "TC563374"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
        }

        [Test, Order(2)]
        public void As_an_Admin_add_Paragraph_type_Question_to_the_Evaluation_57760()
        {
            CommonSection.CreateLink.Evaluation();
            _test.Log(Status.Info, "Naviagte to Cretae Evalution page");

            EvaluationPage.CreateNewEvaluation(EvaluationTitle + "TC563394");
            _test.Log(Status.Info, "A new Evaluation is Created");
            ManageEvaluationPage.Structure1.Click_AddQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageEvaluationPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Verify on Add A Question");
            ManageEvaluationPage.AddaQuestionModal.Select_QuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrap type Question");
            string QuestionType = ManageEvaluationPage.AddaQuestionModal.Question_Type();
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.QuestionOrTitleInputbox_Displayed("How are you asif ali ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionTitle = "How are you asif ali ?";
            //string QuestionTitle = ManageEvaluationPage.AddaQuestionModal.Question_Title();
            ManageEvaluationPage.AddaQuestionModal.Question_Required("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageEvaluationPage.AddaQuestionModal.AllowQuestion_ToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageEvaluationPage.AddaQuestionModal.Click_Create();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageEvaluationPage.Structure1.Verify_QuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageEvaluationPage.Structure1.Verify_OptionalDisplayed(QuestionTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageEvaluationPage.Structure1.Structure_Question(QuestionType);
            ManageEvaluationPage.DropDownToggle.Click_AtPreview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageEvaluationPage.VerifyQuestion_DisplayedInPreview(Question, EvaluationTitle + "TC563394"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");


        }
        [Test, Order(3)]
        public void an_Admin_add_a_date_type_questionto_the_Evaluation_57712()

        {
            CommonSection.CreateLink.Evaluation();
            _test.Log(Status.Info, "Naviagte to Cretae Evalution page");

            EvaluationPage.CreateNewEvaluation(EvaluationTitle + "TC563394");
            _test.Log(Status.Info, "A new Evaluation is Created");
            ManageEvaluationPage.Structure1.Click_AddQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageEvaluationPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Verify on Add A Question");
            ManageEvaluationPage.AddaQuestionModal.Select_QuestionType("Date Field");
            _test.Log(Status.Info, "Select Date Field List type Question");
            string QuestionType = ManageEvaluationPage.AddaQuestionModal.Question_Type();
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.QuestionOrTitleInputbox_Displayed("How are you asif ali " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify selected type is in Question type List");

            ManageEvaluationPage.AddaQuestionModal.Select_QuestionType("Date Field");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifySelected_QuestionType("Date Field"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType1 = ManageEvaluationPage.AddaQuestionModal.Question_Type();

            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyQuestion_TitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyingRequiredOptionSliderIs_Displayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyQuestionReusedSliderIs_Displayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIs_Displayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.QuestionOrTitleInputbox_Displayed("what will be the date tomorrow " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = ManageEvaluationPage.AddaQuestionModal.Question_Title();
            ManageEvaluationPage.AddaQuestionModal.Click_Create();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageEvaluationPage.Structure1.Verify_QuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageEvaluationPage.Structure1.Verify_OptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageEvaluationPage.Structure1.Structure_Question(QuestionType);
            ManageEvaluationPage.DropDownToggle.Click_AtPreview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
            Assert.IsTrue(ManageEvaluationPage.VerifyQuestion_DisplayedInPreview(Question, EvaluationTitle + "TC563394"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
        }

        [Test, Order(4)]
        public void As_an_admin_add_radio_button_type_question_to_the_Evaluation_57714()
        {
            CommonSection.CreateLink.Evaluation();
            _test.Log(Status.Info, "Navigate to Create Evalution page");
            EvaluationPage.CreateNewEvaluation(EvaluationTitle + "TC563994");
            _test.Log(Status.Info, "A new Evaluation is Created");
            ManageEvaluationPage.Structure1.Click_AddQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageEvaluationPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Verify on Add A Question");
            ManageEvaluationPage.AddaQuestionModal.Select_QuestionType("Radio Button");
            _test.Log(Status.Info, "Select Date Field List type Question");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifySelected_QuestionType("Radio Button"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageEvaluationPage.AddaQuestionModal.Question_Type();

            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyQuestion_TitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyingRequiredOptionSliderIs_Displayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.VerifyQuestionReusedSliderIs_Displayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.QuestionOrTitleInputbox_Displayed("How are you asif ali ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionTitle = "How are you asif ali ?";


            Assert.IsTrue(ManageEvaluationPage.AddaQuestionModal.Verify_AnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageEvaluationPage.AddaQuestionModal.Enter_Response(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageEvaluationPage.AddaQuestionModal.Click_Create();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageEvaluationPage.Structure1.Verify_QuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageEvaluationPage.Structure1.Verify_OptionalDisplayed(QuestionTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            string Question = ManageEvaluationPage.Structure1.Structure_Question(QuestionType);
            ManageEvaluationPage.DropDownToggle.Click_AtPreview();
            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");

            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, EvaluationTitle + "TC563994"));
            _test.Log(Status.Pass, "Verify Question is Displayed in preview");


        }
        //[Test, Order(4)]

        //public void As_an_Admin_I_want_to_see_branching_is_not_available_to_Date_Field_Question_57441
        //()
        //{

        //}
        [Test, Order(1)]
        public void As_an_Admin_I_want_to_see_branching_is_not_available_to_Date_Field_Question_57441()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(SurveyTittle + "TC56300");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            Assert.IsTrue(ManageSurveyPage.IsAddaQuestionModalDisplayed());
            _test.Log(Status.Pass, "Verify is Edit Question Modal is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeDropdownIsDisplayed());
            _test.Log(Status.Pass, "Verif Question Type is Displayed on left side of Modal");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionTypeIsInList("Date Field"));
            _test.Log(Status.Pass, "Verify selected type is in Question type List");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Date Field");
            _test.Log(Status.Info, "Select mentioned Question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Date Field"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("what will be the date tomorrow ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = "what will be the date tomorrow ?";
            //string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageSurveyPage.Structure.verifyingbranching());
            _test.Log(Status.Pass, "Verify branching is disable");







        }
        [Test, Order(5)]
        public void As_an_Admin_I_want_to_see_branching_is_not_available_to_Short_Answer_Question_57442()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(SurveyTittle + "TC56599");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Short Answer");
            _test.Log(Status.Info, "Select short type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Short Answer"));
            _test.Log(Status.Pass, "Verify selected Question type");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyShortAnswerExample());
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
            //Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
            //_test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("what is ur short ans tomorrow ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = "what is ur short ans tomorrow ?";
            //string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageSurveyPage.Structure.verifyingbranching());
            _test.Log(Status.Pass, "Verify branching is disable");







        }

        [Test, Order(6)]
        public void As_an_Admin_I_want_to_see_branching_is_not_available_to_Paragraph_type_Question_57443()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(SurveyTittle + "TC56883");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Paragraph");
            _test.Log(Status.Info, "Select Paragrapg type Question");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = "How are you ?";
            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
            _test.Log(Status.Info, "Select Question Required");
            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
            _test.Log(Status.Info, "Select Question to be Reused");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");

            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageSurveyPage.Structure.verifyingbranching());
            _test.Log(Status.Pass, "Verify branching is disable");
        }

        [Test, Order(6)]
        public void As_an_Admin_I_want_to_see_branching_is_not_available_to_Multiple_Choice_Checkbox_Question_57440()
        {

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Create Survey page");
            SurveysPage.CreateNewSurvey(SurveyTittle + "TC56566");
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
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you Asif for checkboxes ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            string QuestionOrTitle = "How are you Asif for checkboxes ?";

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
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
            Assert.IsFalse(ManageSurveyPage.Structure.verifyingbranching());
            _test.Log(Status.Pass, "Verify branching is disable");
        }

        //[Test, Order(7)]

        //public void SCORM_History_tab_View_Certificate_button_57918()
        //{


        //    CommonSection.Logout();
        //    LoginPage.LoginAs("").WithPassword("").Login();

        //    CommonSection.CreteNewScorm(scormtitle + "TC262557");
        //    _test.Log(Status.Info, "Creating New Scorm");
        //    Assert.IsTrue(ContentDetailsPage.IsContentCreated());
        //    _test.Log(Status.Pass, "Verify New Scorm Course is Created");
        //    // ContentDetailsPage.Click_Check_in();
        //    //_test.Log(Status.Pass, "Verify New Scorm Course is check in  ");
        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    Assert.False(ContentDetailsPage.verifyHistotytab());
        //    _test.Log(Status.Pass, " scrom course not having history tab");
        //    ContentDetailsPage.Click_Enroll();
        //    _test.Log(Status.Pass, " clicking enroll ");
        //    Assert.IsTrue(ContentDetailsPage.VerifyCancelEnrollmentButton_Curriculum());
        //    // verify the test case for 57924
        //    Assert.IsTrue(ContentDetailsPage.verifyHistotytab());
        //    _test.Log(Status.Pass, " verify the history tab");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.verifydate());
        //    _test.Log(Status.Pass, "validate the date ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.VerifyEnrollstatus());

        //    ContentDetailsPage.ContentBanner.Click_Startbutton();
        //    _test.Log(Status.Pass, "click at start button ");
        //    Driver.Instance.selectWindow("Meridian Global - Core Domain");

        //    Driver.Instance.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
        //    Driver.Instance.SwitchTo().DefaultContent();


        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "click at History tab again ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.verifydate());
        //    _test.Log(Status.Pass, "Verify the Date and status as statrted ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.Verifystatrtedstatus());

        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
        //    _test.Log(Status.Pass, "Verify to Display at contiunue button ");
        //    ContentDetailsPage.ContentBanner.click_continuebutton();
        //    _test.Log(Status.Pass, "Verify to click at contiunue button");
        //    Driver.Instance.selectWindow("Meridian Global");
        //    ContentDetailsPage.SCROM.CompleteSCROMCourse();
        //    _test.Log(Status.Pass, "Complete the Scrom page");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "click at History tab again ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.isViewCertificateButtonDisplay());//BV_(for testcase_57918)
        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());// For verify the test case for 57924

        //    _TC_57918 = true;


        //}
        //[Test, Order(8)]

        //public void SCORM_Learner_views_Details_in_History_from_multiple_attempts_57919()
        //{

            


        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(9),Description("Need to write the vaidation for local picker")]

        //public void SCORM_Banner_Actions_Navigation_57921()
        //{


        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    //ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    //_test.Log(Status.Pass, "Click at History ");
        //    ContentDetailsPage.ClickSaveButton();
        //    _test.Log(Status.Pass, "Click at saved button ");
        //    Assert.IsTrue(ContentDetailsPage.isSaveButtonIconGreen());
        //    _test.Log(Status.Pass, "Click at Green saved button ");
        //    Assert.IsTrue(ContentDetailsPage.SocialSharingDropDown("Facebook"));
        //    _test.Log(Status.Pass, "verify the facebook ");
        //    Assert.IsTrue(ContentDetailsPage.editclickbuttonexist());
          
        //    _test.Log(Status.Pass, "verify the edit contentdetailpage ");


        //}
        //[Test, Order(10)]

        //public void SCORM_Banner_Actions_Edit_Save_Share_57922()
        //{




        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(11)]

        //public void SCORM_Banner_Actions_Request_Access_57923()
        //{




        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(12)]

        //public void SCORM_Banner_Actions_Enroll_57924()
        //{




        //    Assert.IsTrue(_TC_57918);
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(13)]

        //public void SCORM_Banner_Pass_Fail_For_Never_New_57925()
        //{



        //    CommonSection.CreteNewScorm(scormtitle + "TC262557");
        //    _test.Log(Status.Info, "Creating New Scorm");
        //    Assert.IsTrue(ContentDetailsPage.IsContentCreated());
        //    _test.Log(Status.Pass, "Verify New Scorm Course is Created");
        //    ContentDetailsPage.Click_Check_in();
        //    _test.Log(Status.Pass, "Verify New Scorm Course is check in  ");
        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    Assert.False(ContentDetailsPage.verifyHistotytab());
        //    _test.Log(Status.Pass, " scrom course not having history tab");
        //    ContentDetailsPage.Click_Enroll();
        //    _test.Log(Status.Pass, " clicking enroll ");
        //    Assert.IsTrue(ContentDetailsPage.VerifyCancelEnrollmentButton_Curriculum());
        //    // verify the test case for 57924
        //    Assert.IsTrue(ContentDetailsPage.verifyHistotytab());
        //    _test.Log(Status.Pass, " verify the history tab");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.verifydate());
        //    _test.Log(Status.Pass, "validate the date ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.VerifyEnrollstatus());

        //    ContentDetailsPage.ContentBanner.Click_Startbutton();
        //    _test.Log(Status.Pass, "click at start button ");
        //    Driver.Instance.selectWindow("Meridian Global - Core Domain");
            
        //    Driver.Instance.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
        //    Driver.Instance.SwitchTo().DefaultContent();

        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "click at History tab again ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.verifydate());
        //    _test.Log(Status.Pass, "Verify the Date and status as statrted ");
        //    Assert.IsTrue(ContentDetailsPage.Historytab.Verifystatrtedstatus());

        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
        //    _test.Log(Status.Pass, "Verify to Display at contiunue button ");
        //    ContentDetailsPage.ContentBanner.click_continuebutton();
        //    _test.Log(Status.Pass, "Verify to click at contiunue button");
        //    Driver.Instance.selectWindow("Meridian Global - Core Domain"); 
        //    ContentDetailsPage.SCROM.Fail_SCROMCourse();
        //    _test.Log(Status.Pass, "Fail the Scrom course");
           
        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());
        //    _test.Log(Status.Pass, "verify the retake button");
        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
        //    _test.Log(Status.Pass, "verify the Review button");
        //    //DateTime date = DateTime.Now;


        //  string str1=DateTime.Now.ToString("M'/'d'/'yyyy");
        //    //string Systemtime = date.ToString("MM/dd/yyyy");
        //    //string dateofcontent= Systemtime.Replace('-', '/');
        //    // string contentdate = dateofcontent.Remove('0', ' ').TrimStart('/');
        //    _test.Log(Status.Pass, "date picker");

        //    Assert.IsTrue(ContentDetailsPage.ContentBanner.verifymessage("You completed this item on "+ str1 + " but received a failing result."));



        //}
        //[Test, Order(14)]

        //public void SCORM_Banner_Actions_Survey_57926()
        //{




        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(8)]

        //public void SCORM_Banner_Pass_Fail_For_Always_New_57927()
        //{




        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(15)]

        //public void SCORM_Banner_Pass_Fail_For_Ask_User_57928()
        //{




        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(16)]

        //public void SCORM_Banner_Pass_Fail_for_One_Time_Content_Usage_57929()
        //{




        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
        //[Test, Order(17)]

        //public void SCORM__Banner_Notifications_57930()
        //{




        //    CommonSection.SearchCatalog(scormtitle + "TC262557");
        //    _test.Log(Status.Pass, "Search the scrom course  ");
        //    SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
        //    ContentDetailsPage.Click_HistoryTab_Curriculum();
        //    _test.Log(Status.Pass, "Click at History ");
        //    Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
        //    _test.Log(Status.Pass, "Verify the View Detail Link ");

        //}
    

        
    }
    
}