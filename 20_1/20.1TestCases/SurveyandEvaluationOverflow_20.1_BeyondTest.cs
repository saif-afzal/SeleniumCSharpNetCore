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
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_SurveyandEvaluationOverflow_20_1_BeyondTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_SurveyandEvaluationOverflow_20_1_BeyondTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle = "TA" + Meridian_Common.globalnum;
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        string CertificatrTitle = "Certi" + Meridian_Common.globalnum;
        string EvaluationTitle = "EvalustionTitle" + Meridian_Common.globalnum;
        bool TC60869;
        bool TC58374;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        [Test, Order(1)]
        public void tc_58378_As_an_Admin_Include_evaluation_in_certification_content()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC58378");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            ContentDetailsPage.ClickEditCertificationContent();
            EditCertificateContentsPage.ClickAddContent();
            AddContentToCertificationPage.ClickSeemoresearchcriteriaLink();
            AddContentToCertificationPage.SearchType.ClickType();
            Assert.IsTrue(AddContentToCertificationPage.SearchType.Type.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify is Evaluation display in Type list");
            AddContentToCertificationPage.SearchType.Type.SelectType("Evaluation");
            AddContentToCertificationPage.ClickSearchbutton();
            Assert.IsTrue(AddContentToCertificationPage.ResultGrid.isContentTypeDisplay("Evaluation"));
            _test.Log(Status.Pass, "Verify Evaluation recoreds are searched");
            AddContentToCertificationPage.ResultGrid.Selectfirstrecord();
            AddContentToCertificationPage.clickAddButton();
            Assert.IsTrue(AddContentToCertificationPage.getFeedbackMessage());
            _test.Log(Status.Pass, "Verify Content added feedback message on page");
            AddContentToCertificationPage.clickBackButton();
            Assert.IsTrue(EditCertificateContentsPage.addedContent.isEvaluationAdded());
            _test.Log(Status.Pass, "Verify Evaluation added to certification content");

        }
        [Test, Order(2)]
        public void tc_58380_As_an_Admin_Include_evaluation_in_Curriculum_Content()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC58380");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            //CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC56247");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC58380");
            CurriculumContentPage.ClickAddTrainingActivitiesbutton();

            CurriculumAddActivityPage.ClickSeemoresearchcriteriaLink();
            CurriculumAddActivityPage.SearchType.ClickType();
            Assert.IsTrue(CurriculumAddActivityPage.SearchType.Type.isEvaluationdisplay());
            _test.Log(Status.Pass, "Verify is Evaluation display in Type list");
            CurriculumAddActivityPage.SearchType.Type.SelectType("Evaluation");
            CurriculumAddActivityPage.ClickSearchbutton();
            Assert.IsTrue(CurriculumAddActivityPage.ResultGrid.isContentTypeDisplay("Evaluation"));
            _test.Log(Status.Pass, "Verify Evaluation recoreds are searched");
            CurriculumAddActivityPage.ResultGrid.Selectfirstrecord();
            CurriculumAddActivityPage.clickAddButton();
            Assert.IsTrue(CurriculumAddActivityPage.getFeedbackMessage());
            _test.Log(Status.Pass, "Verify Content added feedback message on page");
            CurriculumAddActivityPage.clickBackButton();
            Assert.IsTrue(CurriculumContentPage.addedContent.isEvaluationAdded());
            _test.Log(Status.Pass, "Verify Evaluation added to certification content");
        }

        [Test, Order(3)]
        public void tc_58492_As_an_admin_Include_evaluation_to_Training_Assignment_content()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            SurveycosolePage.Create.Evaluation();
            EvaluationPage.ClickCanbeaddedtocontainersortrainingassignments();
            EvaluationPage.Title(EvaluationTitle + "TC58492").Keywors("test").Create();
            SurveyPage.Click_Publish();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "TC58492");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");

            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(EvaluationTitle + "TC58492");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("learner 101");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("days");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickDueDateTab();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            _test.Log(Status.Pass, "Verify Copletion count saved properly");
            CreateTrainingAssignmentPage.clickAssignButton();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.Learn.CurrentTraining();
            CurrentTrainingPage.allContenttypefilter.selectEvaluation();
            Assert.IsTrue(CurrentTrainingPage.ContentList.isContentTypeDisplay("Evaluation"));
            TC60869 = true;

        }
        [Test, Order(4)]
        public void tc_60869_As_a_learner_View_Evaluation_as_a_part_of_training_assignment_in_current_training()
        {
            Assert.IsTrue(TC60869);
        }
        [Test, Order(5)]
        public void tc_61736_As_an_Admin_Cant_choose_to_display_in_Catalog_in_Edit_Evaluation()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.SurveysAndEvaluations();
            SurveycosolePage.Create.Evaluation();

            Assert.IsFalse(EvaluationPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is not Display");
            EvaluationPage.Title(EvaluationTitle + "TC61736").Keywors("test").Create();

            CommonSection.Manage.SurveysAndEvaluations(); //New Eval-1903
            SurveycosolePage.ItemTab.search("Evaluation", EvaluationTitle + "TC58492");
            SurveycosolePage.ItemTab.ResultTable.clickEvalustionTitle(EvaluationTitle + "TC58492");
            ContentDetailsPage.Summary.ClickEditButton();
            Assert.IsFalse(EvaluationPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is not Display");
        }
        [Test, Order(6)]
        public void tc_59043_As_an_Admin_I_want_to_view_completed_evaluations()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Navigate to Manage >> Surveys and Ebaluations");
            SurveycosolePage.clickLearnerEvaluations();
            _test.Log(Status.Info, "Click on Learner Evaluations tab");
            Assert.IsTrue(SurveycosolePage.LearnerEvaluationTab.isCompltedTabdisplay());
            _test.Log(Status.Pass, "Verify Completed tab is visible");
            SurveycosolePage.LearnerEvaluationTab.ClickCompletedTab();
            Assert.IsTrue(SurveycosolePage.LearnerEvaluationTab.CompletedTab.isCompletedEvalustiondisplay());
            _test.Log(Status.Pass, "Verify Completed Evalutions are display");
            Assert.IsTrue(SurveycosolePage.LearnerEvaluationTab.CompletedTab.ColumnHeaders("Title","Content","Learner","Completion Date"));
            _test.Log(Status.Pass, "Verify column headers");
            TC58374 = true;
        }
        [Test, Order(7)]
        public void tc_58374_As_an_Evaluator_I_want_to_view_completed_evaluations_for_a_Learner()
        {
            Assert.IsTrue(TC58374);
        }
    }

}



