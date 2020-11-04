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
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P1RequiredTrainingTests : TestBase
    {
        string browserstr = string.Empty;
        public P1RequiredTrainingTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string TATitle= "TATitle"+ Meridian_Common.globalnum;
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }
       

     
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
       
        
        
        [Test]
        public void a01_Add_a_non_recurring_training_assignment_with_previous_completions_count_is_Yes_allow_all_previous_completions_35521()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle+"35521");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("Yes");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickDueDateTab();
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            _test.Log(Status.Pass, "Verify Copletion count saved properly");


        }
        [Test]
        public void a02_Add_a_non_recurring_training_assignment_with_previous_completions_count_is_Yes_allow_completions_since_any_day_35522()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "35522");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("date");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickDueDateTab();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            _test.Log(Status.Pass, "Verify Copletion count saved properly");

        }
        [Test]
        public void a03_Add_a_non_recurring_training_assignment_with_previous_completions_count_is_Yes_allow_completions_from_past_days_35523()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "35523");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("days");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickDueDateTab();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            _test.Log(Status.Pass, "Verify Copletion count saved properly");

        }
        [Test]
        public void a04_Add_a_non_recurring_training_assignment_with_previous_completions_count_is_Yes_allow_completions_since_any_days_MM_DD_50963()
        {
            Assert.IsTrue(true); 
            //CommonSection.Manage.Training();
            //_test.Log(Status.Info, "Navigate to Manage >> Training Page");
            //TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            //_test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            //CreateTrainingAssignmentPage.Create(TATitle + "_TC50963");
            //_test.Log(Status.Info, "A new training assignement created as draft");
            //CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            //_test.Log(Status.Info, "Click Add Content");
            //CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            //_test.Log(Status.Info, "Content added to training assignment");
            //CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            //_test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            //CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            //_test.Log(Status.Info, "A user added to training assignment");
            //CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            //_test.Log(Status.Info, "Click Chage button in Due Date tab");
            //string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("days_DDMM");
            //_test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            //CreateTrainingAssignmentPage.ClickDueDateTab();
            //_test.Log(Status.Info, "Click Chage button in Due Date tab");
            //Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            //_test.Log(Status.Pass, "Verify Copletion count saved properly");

        }
        [Test]
        public void a05_I_want_to_be_able_to_filter_by_Pending_status_in_Manage_Training_Assignment_35871()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignment link from training assignment portlet");
            Assert.IsTrue(TrainingAssignmentsPage.StatusFilter.VerifyIsPendingisSelected());
            _test.Log(Status.Pass, "Verify Pending is selected in Status dropdown");
            TrainingAssignmentsPage.ListofContent.ClickonStatusHeader();
            _test.Log(Status.Info, "Click Status culumn Header");
            Assert.IsTrue(TrainingAssignmentsPage.ListofContent.isStatusdisplay("Pending"));
            _test.Log(Status.Info, "Verify Pending status display into result grid");

        }
        [Test]
        public void a06_Add_Effective_and_Expires_date_to_new_Training_assignment_which_has_no_Due_Date_35821()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "35821");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.ClickEffectiveDatesTab();
            string Effectivedate=CreateTrainingAssignmentPage.EffectiveDateTab.SetEffectiveDate(2); // 2 means today+2
            CreateTrainingAssignmentPage.ClickEffectiveDatesTab();
            string Expiresdate=CreateTrainingAssignmentPage.EffectiveDateTab.SetExpiresDate(5);
            CreateTrainingAssignmentPage.clickAssignButton();
            Assert.IsTrue(CreateTrainingAssignmentPage.isEffectiveDateandExpiresDateDisplayonTop(Effectivedate,Expiresdate));
            
            Assert.IsTrue(CreateTrainingAssignmentPage.isAssignmentStatus("Pending"));

        }
        [Test]
        public void a07_Add_Effective_and_Expires_date_to_new_Training_assignment_which_has_Due_Date_and_Non_recurring_35823()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "35823");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("date");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickEffectiveDatesTab();
            string Effectivedate = CreateTrainingAssignmentPage.EffectiveDateTab.SetEffectiveDate(1);
            string Expiresdate=CreateTrainingAssignmentPage.EffectiveDateTab.SetExpiresDate(25);
            CreateTrainingAssignmentPage.clickAssignButton();
            Assert.IsTrue(CreateTrainingAssignmentPage.isEffectiveDateandExpiresDateDisplayonTop(Effectivedate, Expiresdate));
            
            Assert.IsTrue(CreateTrainingAssignmentPage.isAssignmentStatus("Pending"));

        }

    }


}


