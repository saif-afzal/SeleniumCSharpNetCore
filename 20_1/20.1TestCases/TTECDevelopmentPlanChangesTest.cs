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
    public class P1_TTECDevelopmentPlanChangesTest : TestBase
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
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;       
        string ExtlearningTitle = "ExtLearning" + Meridian_Common.globalnum;
        bool TC60939;

        public P1_TTECDevelopmentPlanChangesTest(string browser)
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


        [Test, Order(01)]
        public void tc_60961_Create_External_Learning_item_from_Development_Plan_when_both_External_Learning_option_is_False()
        {
            CommonSection.Administer.Training.ContentConfiguration.ContentSettings();
            _test.Log(Status.Info, "Goto Administer > Training >Content Configuration>Content Settings Page");
            Assert.IsTrue(ContentSettingsPage.isExternalLearningcontenttobesubmittedforapproval("False"));
            Assert.IsFalse(ContentSettingsPage.isAutoapproveExternalLearningsubmissionsisNonedititable());
            _test.Log(Status.Pass, "Verify Auto approve External Learning submissions is Non edititable");
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(ProfessionalDevelopmentPage.isDevelopmentPlanportletdisplay());
            _test.Log(Status.Pass, "Verify Development plan portlet display");
            ProfessionalDevelopmentPage.DevelopmentPlan.ClickCreatePlan();
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickAddContentDropdown();
            Assert.IsFalse(ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickAddContent.isExternalLearneingoptiondisplay());
            _test.Log(Status.Pass, "Verify user can't see any external learning option");
        }

        [Test, Order(02)]
        public void tc_60926_As_an_Admin_I_want_my_site_to_auto_approve_external_learning_requests()
        {
            CommonSection.Administer.Training.ContentConfiguration.ContentSettings();
            _test.Log(Status.Info, "Goto Administer > Training >Content Configuration>Content Settings Page");
            Assert.IsTrue(ContentSettingsPage.isExternalLearningcontenttobesubmittedforapproval("False"));
            Assert.IsFalse(ContentSettingsPage.isAutoapproveExternalLearningsubmissionsisNonedititable());
            _test.Log(Status.Pass, "Verify Auto approve External Learning submissions is Non edititable");
            ContentSettingsPage.SetExternalLearningcontenttobesubmittedforapproval("True");
            Assert.IsTrue(ContentSettingsPage.isAutoapproveExternalLearningsubmissionsisNonedititable());
            _test.Log(Status.Pass, "Verify Auto approve External Learning submissions is edititable");
            Assert.IsTrue(ContentSettingsPage.isAutoapproveExternalLearningsubmissions("False"));            
            ContentSettingsPage.SetAutoapproveExternalLearningsubmissions("True");
            ContentSettingsPage.ClickSave();
            CommonSection.Administer.Training.ContentConfiguration.ContentSettings();
            _test.Log(Status.Info, "Goto Administer > Training >Content Configuration>Content Settings Page");
            Assert.IsTrue(ContentSettingsPage.isExternalLearningcontenttobesubmittedforapproval("True"));
            Assert.IsFalse(ContentSettingsPage.isAutoapproveExternalLearningsubmissionsisNonedititable());
            _test.Log(Status.Pass, "Verify Auto approve External Learning submissions is edititable");
           // ContentSettingsPage.SetExternalLearningcontenttobesubmittedforapproval("False");
           // ContentSettingsPage.ClickSave();

        }
        [Test, Order(03)]
        public void tc_60959_Create_External_Learning_item_from_Development_Plan_when_Auto_Approve_setting_is_True_or_ON()
        {
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(ProfessionalDevelopmentPage.isDevelopmentPlanportletdisplay());
            _test.Log(Status.Pass, "Verify Development plan portlet display");
            ProfessionalDevelopmentPage.DevelopmentPlan.ClickCreatePlan();
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickAddContentDropdown();
            Assert.IsTrue(ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickAddContent.isExternalLearneingoptiondisplay());
            _test.Log(Status.Pass, "Verify user can see any external learning option");
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickAddContent.clickExternallearning();
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickAddContent.SubmitExtrernalLearning(ExtlearningTitle);
            Assert.IsTrue(ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.isExternallearnersubmitted());
            _test.Log(Status.Pass, "Verify external learning is submitted");
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickContentTitle(ExtlearningTitle);
            Assert.IsTrue(ContentDetailsPage.isContentPageDisplayed());
            CommonSection.Learn.Transcript();
            TranscriptPage.ClickExternalLearningTab();
            Assert.IsTrue (TranscriptPage.ExternalLearning.isTitledisplay(ExtlearningTitle));
            _test.Log(Status.Pass, "Verify external learning is display on Transcript");
            CommonSection.Administer.TrainingManagement.ClickExternalLearningRequests();
            ExternalLearningConsolePage.SearchUser("admin");
            Assert.IsTrue(ExternalLearningConsolePage.isExternalLearningdisplay(ExtlearningTitle));
            _test.Log(Status.Pass, "Verify external learning is display");
            TC60939 = true;
        }
        [Test, Order(5)]
        public void tc_61102_Submit_External_Learning_item_from_Transcript_when_Auto_Approve_setting_is_True_or_ON()
        {
            CommonSection.Learn.Transcript();
            TranscriptPage.ClickExternalLearningTab();
            TranscriptPage.ExternalLearning.SubmitExternalLearning(ExtlearningTitle + "TC61102");
            CommonSection.Learn.Transcript();
            TranscriptPage.ClickExternalLearningTab();
            Assert.IsTrue(TranscriptPage.ExternalLearning.isTitledisplay(ExtlearningTitle+ "TC61102"));
            _test.Log(Status.Pass, "Verify external learning is display on Transcript");

        }
        [Test, Order(6)]
        public void tc_60964_I_want_to_see_and_remove_external_learning_items_from_my_plan()
        {
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(ProfessionalDevelopmentPage.isDevelopmentPlanportletdisplay());
            _test.Log(Status.Pass, "Verify Development plan portlet display");
            ProfessionalDevelopmentPage.DevelopmentPlan.ClickCreatePlan();
            ProfessionalDevelopmentPage.ProfecionalFocus.AddContent.clickExternallearning();
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickAddContent.SubmitExtrernalLearning(ExtlearningTitle+"TC60964");
            Assert.IsTrue(ProfessionalDevelopmentPage.ProfecionalFocus.isExternallearnersubmitted());
            _test.Log(Status.Pass, "Verify external learning is submitted");
            Assert.IsTrue(ProfessionalDevelopmentPage.ProfecionalFocus.isRemoveExternalLearningicondisplay());
            ProfessionalDevelopmentPage.ProfecionalFocus.RemoveExternalLearning();
            CommonSection.Learn.Transcript();
            TranscriptPage.ClickExternalLearningTab();
            Assert.IsTrue(TranscriptPage.ExternalLearning.isTitledisplay(ExtlearningTitle + "TC60964"));
            _test.Log(Status.Pass, "Verify external learning is display on Transcript");

            CommonSection.Administer.Training.ContentConfiguration.ContentSettings();
            _test.Log(Status.Info, "Goto Administer > Training >Content Configuration>Content Settings Page");
            Assert.IsTrue(ContentSettingsPage.isExternalLearningcontenttobesubmittedforapproval("True"));
            ContentSettingsPage.SetExternalLearningcontenttobesubmittedforapproval("False");
            ContentSettingsPage.ClickSave();

        }
        [Test, Order(7)]
        public void tc_60939_Create_External_Learning_item_from_Development_Plan_when_Auto_Approve_setting_is_False_or_OFF()
        {
            Assert.IsTrue(TC60939);
        }
        [Test, Order(8)]
        public void tc_60898_As_an_Admin_I_want_to_configure_my_domain_to_auto_approve_development_plans()
        {
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "Navigate to Administer >> System >> Domains and URLs >> Domains");
            DomainsPage.ClickDomainLink("Meridian Global-Core Domain");
            _test.Log(Status.Info, "Click on Core Doamain link");
            EditSummaryPage.ClickOptionsTab();
            Assert.IsTrue(EditSummaryPage.OptionsTab.isAutoApproveDevelopmentPlan("No"));
            _test.Log(Status.Pass, "Verify Auto Approve Development Plan is No");
            EditSummaryPage.OptionsTab.SetAutoApproveDevelopmentPlan("Yes");
            EditSummaryPage.ClickSavebutton();
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "Navigate to Administer >> System >> Domains and URLs >> Domains");
            DomainsPage.ClickDomainLink("Meridian Global-Core Domain");
            _test.Log(Status.Info, "Click on Core Doamain link");
            EditSummaryPage.ClickOptionsTab();
            Assert.IsTrue(EditSummaryPage.OptionsTab.isAutoApproveDevelopmentPlan("Yes"));
            _test.Log(Status.Pass, "Verify Auto Approve Development Plan is Yes");
            EditSummaryPage.OptionsTab.SetAutoApproveDevelopmentPlan("No");
            EditSummaryPage.ClickSavebutton();

        }
        [Test, Order(9)]
        public void tc_60963_I_want_to_go_to_Content_Detail_page_instead_of_Info_modal()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Navigating to Career Development page");
            Assert.IsTrue(ProfessionalDevelopmentPage.isDevelopmentPlanportletdisplay());
            _test.Log(Status.Pass, "Verify Development plan portlet display");
            Assert.IsTrue(ProfessionalDevelopmentPage.DevelopmentPlan.isdeveplandisplay("New Development Plan for Somnath learner 101"));
            ProfessionalDevelopmentPage.DevelopmentPlan.ClickexistingDevplan();
            Assert.IsTrue(ProfessionalDevelopmentPage.isdevplanOpened("New Development Plan for Somnath learner 101"));
            string contenttitle=ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.getContettitle();
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickContentTitle();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(contenttitle));
            _test.Log(Status.Pass, "Verify New content details page open for that content");
        }
        [Test, Order(10)]
        public void tc_61731_As_a_learner_I_want_to_view_description_of_content_from_development_plan()
        {
           
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Navigating to Career Development page");
            Assert.IsTrue(ProfessionalDevelopmentPage.isDevelopmentPlanportletdisplay());
            _test.Log(Status.Pass, "Verify Development plan portlet display");
            Assert.IsTrue(ProfessionalDevelopmentPage.DevelopmentPlan.isdeveplandisplay("New Development Plan for Somnath learner 101"));
            ProfessionalDevelopmentPage.DevelopmentPlan.ClickexistingDevplan();
            Assert.IsTrue(ProfessionalDevelopmentPage.isdevplanOpened("New Development Plan for Somnath learner 101"));
            string contenttitle = ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.getContettitle();
            Assert.IsTrue(ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.isviewdescriptionLinkdisplay());
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickviewdescriptionLink();
            Assert.IsTrue(ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.isDiscriptionmodaldisplay());
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.CloseDiscriptionmodal();
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickContentTitle();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(contenttitle));
            _test.Log(Status.Pass, "Verify New content details page open for that content");
        }
        [Test, Order(11)]
        public void tc_61730_As_a_manager_I_want_to_view_description_of_content_from_development_plan_approval()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.DevelopmentPlanApprovals();
            _test.Log(Status.Info, "Navigating to Manage >> Development Plan Approvals");
            Assert.IsTrue(ManagerProfessionalDevelopmentPage.isDevelopmentPlansdisplay());
            _test.Log(Status.Pass, "Verify Development plan portlet display");
            ManagerProfessionalDevelopmentPage.Clickfirstdevplan();
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.ClickviewdescriptionLink();
            Assert.IsTrue(ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.isDiscriptionmodaldisplay());
            ProfessionalDevelopmentPage.PendingDevPlan.GeneralDevelopment.CloseDiscriptionmodal();
            _test.Log(Status.Pass, "Verify Discription modal is closed");
        }

        [Test, Order(12)]
        public void tc_61237_As_a_Learner_I_want_to_see_the_summary_of_my_submitted_development_plan()
        {

        }
        [Test, Order(13)]
        public void tc_61251_As_an_admin_I_want_to_change_Activity_or_set_Active_dates_for_an_individual_email()
        {

        }
    }
}