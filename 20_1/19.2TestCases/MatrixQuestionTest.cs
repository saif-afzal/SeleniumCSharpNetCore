//using AventStack.ExtentReports;
//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using OpenQA.Selenium;
//using Selenium2.Meridian.P1.MyResponsibilities.Training;
//using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading;
//using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
//using TestAutomation.Suite1.Administration.AdministrationConsole;

//namespace Selenium2.Meridian.Suite
//{

//    //[TestFixture("ffbs", Category = "firefox")]
//    //// [TestFixture("chbs", Category = "chrome")]
//    //[TestFixture("iebs", Category = "iexplorer")]
//    //[TestFixture("safari", Category = "safari")]
//    [TestFixture("anybrowser", Category = "local")]
//    // [Parallelizable(ParallelScope.Fixtures)]
//    public class NF_MatrixQuestionTests : TestBase
//    {
//        string surveyTitle = "Survey" + Meridian_Common.globalnum;
//        string BunbdleTitle = "Bundle" + Meridian_Common.globalnum;
//        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
//        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
//        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
//        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
//        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
//        string curriculamtitle = "curr" + Meridian_Common.globalnum;
//        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
//        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
//        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
//        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
//        string LevelName = "Level" + Meridian_Common.globalnum;
//        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
//        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
//        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
//        string CategoryTitle = "Category" + Meridian_Common.globalnum;
//        string AICCTitle = "AICC" + Meridian_Common.globalnum;
//        string SCORMTitle = "SCORM" + Meridian_Common.globalnum;
//        string browserstr = string.Empty;
//        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;
//        string Question;
//        bool TC56918;

//        public NF_MatrixQuestionTests(string browser)
//             : base(browser)
//        {
//            browserstr = browser;
//            Driver.Instance = driver;
//            InitializeBase(driver);
//            LoginPage.GoTo();
//            LoginPage.LoginAs("").WithPassword("").Login();
//        }


//      //  [OneTimeSetUp]
//        public void OneTimeSetUp()
//        {
//            InitializeBase(driver);
//        }
//        [SetUp]
//        public void starttest()
//        {
//            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
//        }
//      //  [TearDown]
//        public void teardown()
//        {
//            var status = TestContext.CurrentContext.Result.Outcome.Status;
//            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
//                    ? ""
//                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
//            Status logstatus;
//            var errorMessage = TestContext.CurrentContext.Result.Message;
//            switch (status)
//            {
//                case TestStatus.Failed:
//                    logstatus = Status.Fail;
//                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
//                    _test.Log(Status.Info, stacktrace + errorMessage);
//                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
//                    screenShotPath = screenShotPath.Replace(@"C:\Users\admin\Desktop\Automation\Regression Scripts\18.2\", @"Z:\");
//                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
//                    if (driver.Title == "Object reference not set to an instance of an object.")
//                    {
//                        driver.Navigate_to_TrainingHome();
//                        Driver.focusParentWindow();
//                        CommonSection.Avatar.Logout();
//                        LoginPage.LoginClick();
//                        LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
//                    }

//                    break;
//                case TestStatus.Inconclusive:
//                    logstatus = Status.Warning;
//                    break;
//                case TestStatus.Skipped:
//                    logstatus = Status.Skip;
//                    break;

//                default:

//                    logstatus = Status.Pass;
//                    break;
//            }
//            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
//            //  _extent.Flush();
//            if (Meridian_Common.islog == true)
//            {
//                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//            }
//            else
//            {
//                driver.Navigate_to_TrainingHome();
//                driver.Navigate().Refresh();
//            }
//        }
//        // [OneTimeTearDown]
//        public void exitscript()
//        {
//            Driver.Instance.Close();
//        }

//        [Test, Order(01)]
//        public void M01_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_No_and_Question_Reused_as_No_56560()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56560");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
//            _test.Log(Status.Info, "Select Question Required as");
//            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
//            _test.Log(Status.Info, "Select Question to be Reused as");
//            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
//            _test.Log(Status.Info, "Select optional comment fiels as");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56560"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }
//        [Test, Order(02)]
//        public void M02_As_an_Admin_I_want_to_see_an_example_of_what_matrix_type_Answer_Looks_like_in_Survey_for_Matrix_Type_Question_56590()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56590");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixExample());
//            _test.Log(Status.Pass, "Verify selected Question type");
//        }

//        [Test, Order(03)]
//        public void M03_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_10_Answers_Options_in_a_matrix_type_Question_for_Surveys_56593()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56593");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 10);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56593"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

//        }

//        [Test, Order(04)]
//        public void M04_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_1_Question_in_a_matrix_type_Question_for_Surveys_56634()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56634");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Click create Button");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56634"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }
//        [Test, Order(05)]
//        public void M05_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_9_Answers_Options_in_a_matrix_type_Question_for_Surveys_56664()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56664");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 9);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56664"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

//        }

//        [Test, Order(06)]
//        public void M06_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_2_Answers_Options_in_a_matrix_type_Question_for_Surveys_56665()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56665");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56665"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

//        }
//        [Test, Order(07)]
//        public void M07_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_0_Answers_Options_in_a_matrix_type_Question_for_Surveys_56666()
//        {

//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56666");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.DeleteNumberofResponseto(0, 1, 2));
//            _test.Log(Status.Pass, "Delete both the default blank responses");
//            StringAssert.AreEqualIgnoringCase("Warning: This must have at least 2 entry(ies).", ManageSurveyPage.AddaQuestionModal.VerifyLeastResponseWarningMessage());
//            _test.Log(Status.Pass, "Verify warning message");
//        }

//        [Test, Order(08)]
//        public void M08_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_only_one_Answers_Options_in_a_matrix_type_Question_for_Surveys_56667()
//        {

//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56667");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.DeleteNumberofResponseto(1, 1, 1));
//            _test.Log(Status.Pass, "Delete both the default blank responses");
//            StringAssert.AreEqualIgnoringCase("Warning: This must have at least 2 entry(ies).", ManageSurveyPage.AddaQuestionModal.VerifyLeastResponseWarningMessage());
//            _test.Log(Status.Pass, "Verify warning message");
//        }

//        [Test, Order(09)]
//        public void M09_As_an_Admin_I_want_to_check_for_the_limits_of_Answer_options_Columns_that_is_11_Answers_Options_in_a_matrix_type_Question_for_Surveys_56668()
//        {

//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56668");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 11);
//            _test.Log(Status.Info, "Enter response");
//            StringAssert.AreEqualIgnoringCase("Warning: Only 10 entries are allowed.", ManageSurveyPage.AddaQuestionModal.VerifyLeastResponseWarningMessage());
//            _test.Log(Status.Pass, "Verify warning message");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56668"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }

//        [Test, Order(10)]
//        public void M10_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_2_Question_in_a_matrix_type_Question_for_Surveys_56669()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56669");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 2);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56669"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");



//        }

//        [Test, Order(11)]
//        public void M11_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_49_Question_in_a_matrix_type_Question_for_Surveys_56670()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56670");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 49);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56670"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");



//        }
//        [Test, Order(12)]
//        public void M12_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_50_Question_in_a_matrix_type_Question_for_Surveys_56671()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56671");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 50);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56671"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }

//        [Test, Order(13)]
//        public void M13_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_No_Question_in_a_matrix_type_Question_for_Surveys_56675()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56675");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            ManageSurveyPage.AddaQuestionModal.BlankMatrixQuery("");
//            _test.Log(Status.Pass, "Leave the matrix Query as Blank");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.DeleteNumberofQueryto(0, 1, 1));
//            _test.Log(Status.Pass, "Delete both the default blank responses");
//            StringAssert.AreEqualIgnoringCase("Warning: This must have at least 1 entry(ies).", ManageSurveyPage.AddaQuestionModal.VerifyLeastQueryWarningMessage());
//            _test.Log(Status.Pass, "Verify warning message");
//        }
//        [Test, Order(14)]
//        public void M14_As_an_Admin_I_want_to_check_for_the_limits_of_Question_Rows_with_51_Question_in_a_matrix_type_Question_for_Surveys_56676()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56676");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionOrTitleInputboxIsDisplayed());
//            _test.Log(Status.Pass, "Verify Fill Question Title is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyRequiredOptionSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Required Slider is Displayed is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyQuestionToBeReusedSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify Question Can Be reused Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyOptionalCommentfieldSliderIsDisplayed());
//            _test.Log(Status.Pass, "Verify comment Field Slider is Displayed");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyMatrixRows() == 1);
//            _test.Log(Status.Pass, "Verify custom answer options are = to 1 in count");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 51);
//            _test.Log(Status.Info, "Prepare Questions");
//            StringAssert.AreEqualIgnoringCase("Warning: This must have at least 1 entry(ies).", ManageSurveyPage.AddaQuestionModal.VerifyLeastQueryWarningMessage());
//            _test.Log(Status.Pass, "Verify warning message");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");

//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56676"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }

//        [Test, Order(15)]
//        public void M15_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_No_and_Question_Reused_as_Yes_56680()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56680");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
//            _test.Log(Status.Info, "Select Question Required as");
//            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
//            _test.Log(Status.Info, "Select Question to be Reused as");
//            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
//            _test.Log(Status.Info, "Select optional comment fiels as");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56680"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }
//        [Test, Order(16)]
//        public void M16_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_No_56681()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56681");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
//            _test.Log(Status.Info, "Select Question Required as");
//            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
//            _test.Log(Status.Info, "Select Question to be Reused as");
//            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
//            _test.Log(Status.Info, "Select optional comment fiels as");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
//            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            string Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56681"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }
//        [Test, Order(17)]
//        public void M17_As_an_Admin_I_want_to_Add_a_matrix_type_Question_to_the_survey_with_Required_as_Yes_and_Question_Reused_as_Yes_56682()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56682");
//            _test.Log(Status.Info, "A new Survey Created");
//            ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
//            _test.Log(Status.Pass, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
//            _test.Log(Status.Pass, "Verify selected Question type");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.QuestionRequired("Yes");
//            _test.Log(Status.Info, "Select Question Required as");
//            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("Yes");
//            _test.Log(Status.Info, "Select Question to be Reused as");
//            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
//            _test.Log(Status.Info, "Select optional comment fiels as");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
//            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56682"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");
//        }
       
//        [Test, Order(18)]
//        public void ML01_As_a_learner_I_want_to_Take_survey_For_Matrix_type_Question_56919()
//        {
//            CommonSection.Manage.Surveys();
//            _test.Log(Status.Info, "Click Surveys under manage");
//            SurveysPage.SearchSurvey(surveyTitle + "TC56682");
//            _test.Log(Status.Info, "Search Created Survey");
//            SurveysPage.Click_SurveyTitleFromtheList(surveyTitle + "TC56682");
//            _test.Log(Status.Info, "Click survey title to open");
//            AdminContentDetailsPage.DropDownToggle.Publish();
//            _test.Log(Status.Info, "Click Publish and Publish Survey");
//            Assert.IsTrue(AdminContentDetailsPage.VerifyIsPublishedTextDisplayed("Published"));
//            _test.Log(Status.Pass, "Verify Published Text id Displayed below Dropdoen toggle");

//            CommonSection.CreateGeneralCourse(generalcoursetitle + "ForMatrix");
//            _test.Log(Status.Info, "Create a general Course");
//            AdminContentDetailsPage.ManageSurveyWhenSurveyTitleAvailable(surveyTitle + "TC56682");
//            _test.Log(Status.Info, "Add Survey to the Course");
//            AdminContentDetailsPage.ClickCheckInbutton();
//            _test.Log(Status.Info, "Click checkin button");

//            CommonSection.Logout();
//            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
//            _test.Log(Status.Info, "Login As learner");
//            CommonSection.SearchCatalog(generalcoursetitle + "ForMatrix");
//            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "ForMatrix");
//            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollbuttonDisplay_GeneralCourse());
//            _test.Log(Status.Pass, "Verify Enroll button os Displayed in the banner");
//            ContentDetailsPage.EnrollinGeneralCourse_new();
//            _test.Log(Status.Info, "Click Enroll button");
//            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
//            _test.Log(Status.Pass, "Verify Open item Button is Displayed");
//            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysareNotavailable);
//            _test.Log(Status.Pass, "Verify Surveys are not available to Complete");
//            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
//            _test.Log(Status.Info, "Open Course and Complete Content");
//            ContentDetailsPage.Click_Survey(surveyTitle + "TC56682");
//            _test.Log(Status.Info, "Click Survey");
//            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.VerifyQuestion(surveyTitle + "TC56682", Question));
//            _test.Log(Status.Pass, "Enter Rating response verify Rating Question in Survey");
//            ContentDetailsPage.SurveyPortlet.EnterMatrixResponseAndCompleteSurvey();
//            _test.Log(Status.Info, "Enter Rating response verify Rating Question in Survey");

//            TC56918 = true;

//        }
//        [Test, Order(19)]
//        public void ML02_As_a_learner_I_want_to_See_matrix_type_Question_on_Surveys_56918()
//        {
//            Assert.IsTrue(TC56918);

//        }
//        [Test, Order(20)]
//        public void M18_As_an_Admin_preview_matrix_type_Question_56896()
//        {
//            CommonSection.CreateLink.Survey();
//            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
//            SurveysPage.CreateNewSurvey(surveyTitle + "TC56896");
//            _test.Log(Status.Info, "A new Survey Created");
//          ManageSurveyPage.Structure.Click_AddAQuestion();
//            _test.Log(Status.Info, "Click on Add A Question");
//            ManageSurveyPage.AddaQuestionModal.SelectQuestionType("Matrix");
//            _test.Log(Status.Info, "Select Paragrapg type Question");
//            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();

//            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Matrix Question " + Meridian_Common.globalnum + " ?"));
//            _test.Log(Status.Pass, "Verify Question or title is Displayed");
//            string QuestionOrTitle = ManageSurveyPage.AddaQuestionModal.QuestionOrTitle();
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
//            _test.Log(Status.Info, "Prepare Questions");
//            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
//            _test.Log(Status.Info, "Enter response");
//            ManageSurveyPage.AddaQuestionModal.QuestionRequired("No");
//            _test.Log(Status.Info, "Select Question Required as");
//            ManageSurveyPage.AddaQuestionModal.AllowQuestionToBeReused("No");
//            _test.Log(Status.Info, "Select Question to be Reused as");
//            ManageSurveyPage.AddaQuestionModal.SelectOptionalCommentsFieldOption("Yes");
//            _test.Log(Status.Info, "Select optional comment fiels as");
//            ManageSurveyPage.AddaQuestionModal.ClickCreate();
//            _test.Log(Status.Info, "Click create Button");
//            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
//            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            //Assert.IsTrue(ManageSurveyPage.Structure.VerifyOptionalDisplayed(QuestionOrTitle));
//            //_test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
//            Question = ManageSurveyPage.Structure.StructureQuestion(QuestionType);
//            ManageSurveyPage.DropDownToggle.Click_Preview();
//            _test.Log(Status.Pass, "Click preview From Dropdown Toggle");
//            Assert.IsTrue(ManageSurveyPage.VerifyQuestionDisplayedInPreview(Question, surveyTitle + "TC56896"));
//            _test.Log(Status.Pass, "Verify Question is Displayed in preview");

//        }
//    }
//}