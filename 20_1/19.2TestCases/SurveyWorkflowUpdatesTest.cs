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
    public class P1_SurveyWorkflowUpdatesTest : TestBase
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
        string Evaluation = "Evaluation" + Meridian_Common.globalnum;
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;
       
        string EvaluationTitle = "Evaluation" + Meridian_Common.globalnum;

        public P1_SurveyWorkflowUpdatesTest(string browser)
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

        [Test, Order(1)]
        public void tc_57017_As_an_admin_add_a_Upload_file_Type_question_to_the_evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("File Upload");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("File Upload"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
        }
        [Test, Order(2)]
        public void tc_57265_As_an_Admin_Create_an_evaluation_with_Pass_Fail_to_No_default_setting()
        {
            CommonSection.CreateLink.Evaluation();
            Assert.IsTrue(Driver.Instance.Title.Equals("Evaluation"));
            Assert.IsTrue(EvaluationPage.Type.isEvaluationSelected());
            Assert.IsTrue(EvaluationPage.Evaluatormustmarkaspassfail.Defectvalue("No"));
            EvaluationPage.Title(EvaluationTitle + "TC57265").Keywors("test").Create();
            Assert.IsTrue(EvaluationPage.EvaluationTileis(EvaluationTitle + "TC57265"));

        }
        [Test, Order(3)]
        public void tc_57271_As_an_Admin_Create_an_evaluation_with_Pass_Fail_to_Yes()
        {
            CommonSection.CreateEvaluationWithPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            Assert.IsTrue(ManageSurveyPage.VerifyEvaluationPassFail());
            _test.Log(Status.Pass, "Verify evaluation is Pass/Fail");

        }
        [Test, Order(4)]
        public void tc_57412_As_Admin_Add_custom_evaluators_for_unpublished_evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.SelectEvaluatorsTab();
            _test.Log(Status.Info, "Select Evaluators tab");
            ManageSurveyPage.EvaluatorsTab.SelectCustomEvaluator();
            _test.Log(Status.Info, "Select Custom Evaluator ");
            Assert.IsTrue(ManageSurveyPage.EvaluatorsTab.VerifyEvaluatorIsAdded() >= 1);
            _test.Log(Status.Pass, "Verify evaluation is Pass/Fail");

        }
        [Test, Order(5)]
        public void tc_57433_As_Admin_make_Learners_Manager_a_special_evaluator_for_unpublished_evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.SelectEvaluatorsTab();
            _test.Log(Status.Info, "Select Evaluators tab");
            ManageSurveyPage.EvaluatorsTab.SelectLearnermanager();
            _test.Log(Status.Info, "Selct learner manager");
            Assert.IsTrue(ManageSurveyPage.EvaluatorsTab.VerifyLearnerManager());
            _test.Log(Status.Pass, "Verify learner manager is selected");


        }
        [Test, Order(6)]
        public void tc_57434_As_Admin_make_Classroom_Section_Instructor_a_special_evaluator_for_unpublished_evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.SelectEvaluatorsTab();
            _test.Log(Status.Info, "Select Evaluators tab");
            ManageSurveyPage.EvaluatorsTab.SelectCourseInstructor();
            _test.Log(Status.Info, "Selct learner manager");
            Assert.IsTrue(ManageSurveyPage.EvaluatorsTab.VerifyCourseInstructor());
            _test.Log(Status.Pass, "Verify learner manager is selected");
        }
        [Test, Order(7)]
        public void tc_57435_As_Admin_Add_custom_evaluators_for_published_evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.PublishEvaluation();
            _test.Log(Status.Info, "Publish Evaluation");
            Assert.IsTrue(ManageSurveyPage.VerifyPublishedEvaluation());
            _test.Log(Status.Info, "Verify Published Evaluation");
            ManageSurveyPage.SelectEvaluatorsTab();
            _test.Log(Status.Info, "Select Evaluators tab");
            ManageSurveyPage.EvaluatorsTab.SelectCourseInstructor();
            _test.Log(Status.Info, "Selct learner manager");
            Assert.IsTrue(ManageSurveyPage.EvaluatorsTab.VerifyCourseInstructor());
            _test.Log(Status.Pass, "Verify learner manager is selected");
        }
        [Test, Order(8)]
        public void tc_57436_As_Admin_make_Classroom_Section_Instructor_a_special_evaluator_for_published_evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.PublishEvaluation();
            _test.Log(Status.Info, "Publish Evaluation");
            Assert.IsTrue(ManageSurveyPage.VerifyPublishedEvaluation());
            _test.Log(Status.Info, "Verify Published Evaluation");
            ManageSurveyPage.SelectEvaluatorsTab();
            _test.Log(Status.Info, "Select Evaluators tab");
            ManageSurveyPage.EvaluatorsTab.SelectCourseInstructor();
            _test.Log(Status.Info, "Selct learner manager");
            Assert.IsTrue(ManageSurveyPage.EvaluatorsTab.VerifyCourseInstructor());
            _test.Log(Status.Pass, "Verify learner manager is selected");
        }
        [Test, Order(9)]
        public void tc_57437_As_Admin_make_Learners_Manager_a_special_evaluator_for_published_evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.PublishEvaluation();
            _test.Log(Status.Info, "Publish Evaluation");
            Assert.IsTrue(ManageSurveyPage.VerifyPublishedEvaluation());
            _test.Log(Status.Info, "Verify Published Evaluation");
            ManageSurveyPage.SelectEvaluatorsTab();
            _test.Log(Status.Info, "Select Evaluators tab");
            ManageSurveyPage.EvaluatorsTab.SelectLearnermanager();
            _test.Log(Status.Info, "Selct learner manager");
            Assert.IsTrue(ManageSurveyPage.EvaluatorsTab.VerifyLearnerManager());
            _test.Log(Status.Pass, "Verify learner manager is selected");
        }
        [Test, Order(10)]
        public void tc_57544_As_an_admin_I_want_to_attach_an_Evaluation_for_General_course()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC57544");
            _test.Log(Status.Info, "Create a general Course");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(11)]
        public void tc_57591_As_an_admin_I_want_to_attach_an_Evaluation_for_AICC_course()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC57591");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(12)]
        public void tc_57592_As_an_admin_I_want_to_attach_an_Evaluation_for_SCORM_course()
        {
            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(SCORMTitle + "TC57592");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(13)]
        public void tc_57593_As_an_admin_I_want_to_attach_an_Evaluation_for_Classroom_course()
        {
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC57593");
            _test.Log(Status.Info, "A new Classroom Course Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(14)]
        public void tc_57595_As_an_admin_I_want_to_attach_an_Evaluation_to_Bundles()
        {
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(BunbdleTitle + "_TC57595");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(15)]
        public void tc_57596_As_an_admin_I_want_to_attach_an_Evaluation_for_Certification()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57596");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(16)]
        public void tc_57597_As_an_admin_I_want_to_attach_an_Evaluation_for_Curriculum()
        {
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "_TC57597");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(17)]
        public void tc_57598_As_an_admin_I_want_to_attach_an_Evaluation_for_Subscription()
        {
            CommonSection.CreateLink.Subscription();
            Assert.IsTrue(CreatesubscriptionPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC57598").SubscriptionType("Dynamic Date").Create();
            _test.Log(Status.Info, "Create a new Subscriptions");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey and Evaluations accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("Add btn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Add Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.isAddSurveyandEvaluationsModalDisplay());
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.ClickAllTypedropdown();
            Assert.IsTrue(SurveysPage.AddSurveyModal.AllTypedropdown.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify Evaluation display in alltype dropdown");
            SurveysPage.AddSurveyModal.AllTypedropdown.ClickEvaluations();
            SurveysPage.AddSurveyModal.clickSearchicon();
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isEvaluationsDisplay());
            _test.Log(Status.Pass, "Verify Evaluations are display in Result grid");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isRequiredChangeble());
            _test.Log(Status.Pass, "Verifyis Require is changeable");
            Assert.IsTrue(SurveysPage.AddSurveyModal.ResultGrid.isAvailableChangeble());
            _test.Log(Status.Pass, "Verify Available is changeable");

            ContentDetailsPage.DeleteContent();
        }
        //[Test, Order(18)]
        //public void tc_57618_As_an_Admin_I_want_to_publish_an_Evaluation_and_want_to_verify_its_feature_after_publishing()
        //{

        //}
        //[Test, Order(19)]
        //public void tc_57661_As_Admin_Remove_custom_evaluators_from_unpublished_evaluation()
        //{

        //}
        //[Test, Order(20)]
        //public void tc_57662_As_Admin_Remove_custom_evaluators_from_published_evaluation()
        //{

        //}
        //[Test, Order(21)]
        //public void tc_57710_As_an_Evaluator_upload_supporting_files_for_evaluation()
        //{

        //}

        [Test, Order(23)]
        public void tc_57712_As_an_Admin_add_a_date_type_question_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Date Field");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Date Field"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("Enter a valid date " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");

        }
        [Test, Order(24)]
        public void tc_57713_As_an_Admin_add_a_dropdown_Question_Type_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Drop-Down List");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Drop-Down List"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyAnswerRadioSelections() == 2);
            _test.Log(Status.Pass, "Verify custom answer options are = to 2 in count");
            ManageSurveyPage.AddaQuestionModal.EnterResponse(1, 4);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType("Dropdown"));
            _test.Log(Status.Pass, "Verify question Type is Displayed below The Question");
        }
        [Test, Order(25)]
        public void tc_57714_As_an_admin_add_a_radio_button_type_question_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Radio Button");
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
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
        }
        //[Test, Order(26)]
        //public void tc_57730_As_an_Admin_copy_the_published_Evaluation()
        //{

        //}
        [Test, Order(27)]
        public void tc_57760_As_an_Admin_add_a_Paragraph_type_Question_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Paragraph");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Paragraph"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
        }
        [Test, Order(28)]
        public void tc_57764_As_an_Admin_add_a_Checkbox_type_Question_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Checkbox");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Checkbox"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
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
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyCheckboxQuestionRequired(CheckboxMinValue));
            _test.Log(Status.Pass, "Verify Question required Changes to No");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("2", "1");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifyErrorMessageIsDisplayed());
            _test.Log(Status.Pass, "Verify the error message is displayed to fix the values");
            ManageSurveyPage.AddaQuestionModal.Select_MinimumValue_MaximumValue("1", "2");
            _test.Log(Status.Pass, "Select Minimum greater than Maximum  ");

            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
        }
        [Test, Order(29)]
        public void tc_57766_As_an_Admin_add_Rating_type_Question_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Rating");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Rating"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");

            ManageSurveyPage.AddaQuestionModal.SelectRatingScaleFromDropdown("1 - 10");
            _test.Log(Status.Pass, "Select the Rating Scale 1-10 from the drop down");
            ManageSurveyPage.AddaQuestionModal.EnterFirstValueLabel("Good");
            _test.Log(Status.Pass, "Enter First Value Label as Good");
            ManageSurveyPage.AddaQuestionModal.EnterLastValueLabel("Bad");
            _test.Log(Status.Pass, "Enter Last Value Label as Bad");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");

        }
        [Test, Order(30)]
        public void tc_57767_As_an_Admin_add_Matrix_Type_Question_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Matrix");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Matrix"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixQueries(1, 1);
            _test.Log(Status.Info, "Prepare Questions");
            ManageSurveyPage.AddaQuestionModal.EnterMatrixResponse(1, 2);
            _test.Log(Status.Info, "Enter response");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");
        }
        //[Test, Order(31)]
        //public void tc_57770_As_an_Admin_add_a_slider_type_question_to_the_evaluation()
        //{

        //}
        [Test, Order(32)]
        public void tc_57771_As_an_Admin_add_Short_Answer_Type_question_to_the_Evaluation()
        {
            CommonSection.CreateEvaluationWithoutPassFail("Evaluation" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "create Evaluations without Pass/fail");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question Link ");
            ManageSurveyPage.AddaQuestionModal.SelectEvaluationQuestionType("Short Answer");
            _test.Log(Status.Info, "Select mentioned question type Question");
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.VerifySelectedQuestionType("Short Answer"));
            _test.Log(Status.Pass, "Verify selected Question type");
            string QuestionType = ManageSurveyPage.AddaQuestionModal.QuestionType();
            Assert.IsTrue(ManageSurveyPage.AddaQuestionModal.QuestionOrTitleInputboxDisplayed("How are you " + Meridian_Common.globalnum + " ?"));
            _test.Log(Status.Pass, "Verify Question or title is Displayed");
            ManageSurveyPage.AddaQuestionModal.ClickCreate();
            _test.Log(Status.Info, "Click create Button");
            Assert.IsTrue(ManageSurveyPage.Structure.VerifyQuestionType(QuestionType));
            _test.Log(Status.Pass, "Verify created Question Type exists in structure Tab ");

        }
        //[Test, Order(33)]
        //public void tc_57773_As_an_Admin_reorder_and_remove_questions_and_create_reorder_and_remove_Page_in_Evaluation()
        //{

        //}
        //[Test, Order(34)]
        //public void tc_57784_As_a_Custom_Evaluator_start_and_Submit_the_adhoc_evaluation_w_o_Pass_Fail_enabled()
        //{

        //}
        //[Test, Order(35)]
        //public void tc_57785_As_a_Primary_Manager_find_pending_evaluations_for_me_to_fill_out()
        //{

        //}
        //[Test, Order(36)]
        //public void tc_57786_As_a_Course_Instructor_find_pending_evaluations_for_me_to_fill_out()
        //{

        //}
        //[Test, Order(37)]
        //public void tc_57795_As_a_Custom_Evaluator_start_and_Save_the_adhoc_evaluation()
        //{

        //}
        //[Test, Order(38)]
        //public void tc_57796_As_a_Custom_Evaluator_find_pending_evaluations_for_me_to_fill_out()
        //{

        //}
        //[Test, Order(39)]
        //public void tc_57815_As_an_Admin_copy_the_unpublished_Evaluation()
        //{

        //}
        //[Test, Order(40)]
        //public void tc_57822_As_a_manager_I_want_to_start_and_save_an_Evaluation_on_a_learner()
        //{

        //}
        //[Test, Order(42)]
        //public void tc_57978_As_an_admin_I_want_to_attach_an_Evaluation_to_a_section_of_Classroom_course()
        //{

        //}
        //[Test, Order(43)]
        //public void tc_57995_Do_not_email_an_evaluator_Manager_when_the_course_is_Completed()
        //{

        //}
        //[Test, Order(44)]
        //public void tc_58007_Do_not_email_an_evaluator_Course_Instructor_when_the_course_is_Completed()
        //{

        //}
        //[Test, Order(45)]
        //public void tc_58008_Email_an_evaluator_Custom_Evaluator_User_when_the_evaluation_is_ready()
        //{

        //}
        //[Test, Order(46)]
        //public void tc_58024_As_an_Instructor_I_want_to_start_and_save_an_Evaluation_on_a_learner()
        //{

        //}
        //[Test, Order(47)]
        //public void tc_58025_As_a_custom_manager_I_want_to_start_and_save_an_Evaluation_on_a_learner()
        //{

        //}
        //[Test, Order(48)]
        //public void tc_58038_Email_an_evaluator_Custom_Evaluator_Job_Title_when_the_evaluation_is_ready()
        //{

        //}
        //[Test, Order(49)]
        //public void tc_58039_Email_an_evaluator_Custom_Evaluator_User_Group_when_the_evaluation_is_ready()
        //{

        //}
        //[Test, Order(50)]
        //public void tc_58040_As_a_Custom_Evaluator_start_and_Submit_the_adhoc_evaluation_w_Pass_Fail_enabled()
        //{

        //}
        //[Test, Order(51)]
        //public void tc_58041_As_a_Evaluator_Submit_the_evaluation_from_Pending_tab_w_Pass_Fail_enabled()
        //{

        //}
        //[Test, Order(52)]
        //public void tc_58042_As_a_Evaluator_Submit_the_evaluation_from_Pending_tab_w_o_Pass_Fail_enabled()
        //{

        //}
        //[Test, Order(53)]
        //public void tc_58043_As_a_Evaluator_I_want_to_see_a_list_of_my_submitted_evaluations_in_Completed_sub_tab()
        //{

        //}
        //[Test, Order(54)]
        //public void tc_58048_As_a_Course_Instructor_I_want_to_see_Evaluation_on_pending_tab_in_manage_Assessments_For_anyone_Enrolled()
        //{

        //}
        //[Test, Order(55)]
        //public void tc_58055_Email_an_evaluator_when_the_evaluation_becomes_ready_after_XX_of_days_of_course_completion()
        //{

        //}
        //[Test, Order(56)]
        //public void tc_58056_As_a_Learner_I_want_to_see_the_Started_status_of_an_attached_manager_evaluation()
        //{

        //}
        //[Test, Order(57)]
        //public void tc_58059_As_a_Learner_I_want_to_see_the_Ready_for_Evaluator_status_of_an_attached_manager_evaluation()
        //{

        //}
        //[Test, Order(58)]
        //public void tc_58061_As_a_Learner_I_want_to_see_the_Completed_status_of_an_attached_manager_evaluation()
        //{

        //}
        //[Test, Order(59)]
        //public void tc_58062_As_a_Learner_I_want_to_see_the_Passed_status_of_an_attached_manager_evaluation()
        //{

        //}
        //[Test, Order(60)]
        //public void tc_58063_As_a_Learner_I_want_to_see_the_Failed_status_of_an_attached_manager_evaluation()
        //{

        //}
        //[Test, Order(61)]
        //public void tc_58071_Do_Not_Email_an_evaluator_when_the_evaluation_is_ready_and_setting_is_When_Learner_Enrolls()
        //{

        //}
        //[Test, Order(62)]
        //public void tc_58072_Do_Not_Email_an_evaluator_when_the_evaluation_is_ready_and_setting_is_When_Content_Starteds()
        //{

        //}
        //[Test, Order(63)]
        //public void tc_58374_As_an_Evaluator_I_want_to_view_completed_evaluations()
        //{

        //}
        //[Test, Order(64)]
        //public void tc_58378_As_an_Admin_Include_evaluation_in_certification_content()
        //{

        //}
        //[Test, Order(65)]
        //public void tc_58379_As_an_Admin_Include_evaluation_in_progress_bundle_content()
        //{

        //}
        //[Test, Order(66)]
        //public void tc_58380_As_an_Admin_Include_evaluation_in_Curriculum_Content()
        //{

        //}
        //[Test, Order(67)]
        //public void tc_58381_Email_an_evaluator_Manager__when_course_is_Completed_and_Evaluation_is_available_on_completion()
        //{

        //}
        //[Test, Order(68)]
        //public void tc_58382_Email_an_evaluator_Course_Instructor__when_course_is_completed_and_Evaluation_is_available_on_completion()
        //{

        //}
        //[Test, Order(69)]
        //public void tc_58383_Email_an_evaluator_Custom_Evaluator__when_course_is_completed_and_Evaluation_is_available_on_completion()
        //{

        //}
        //[Test, Order(70)]
        //public void tc_58450_As_an_Evaluator_I_want_to_re_evaluate_a_learner()
        //{

        //}
        //[Test, Order(71)]
        //public void tc_58492_As_an_admin_Include_evaluation_to_Training_Assignment_content()
        //{

        //}
        //[Test, Order(72)]
        //public void tc_58644_As_an_admin_I_want_to_view_evaluation_on_learners_transcript()
        //{

        //}
        //[Test, Order(73)]
        //public void tc_59043_As_an_Evaluator_I_want_to_view_learners_and_Evaluators_name_on_completed_evaluation_header()
        //{

        //}

    }
}



