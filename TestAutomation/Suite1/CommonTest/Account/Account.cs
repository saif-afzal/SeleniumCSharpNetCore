using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Selenium2.Meridian.Suite.CommonTest.Account
{
    /// <summary>
    /// US1772- User views "People" instead of "Items" count on Team page and other misc test cases 
    /// US1773- User jumps to Transcript from account page
    /// US2158- I can more easily select multiple secondary languages in my account profile
    /// US1926- User views loading icon while filtering Current Training
    /// US2102- As a learner, when I complete an MG test with individual question results turned off, I see only my overall score and whether I passed.
    /// US2003- Migration: for existing profiles, if recurring or not, behavior is the same for calculating training periods, last completions, etc.
    /// US2152,US2157- As a learner who has run a search for content, I can refine results based on language/locale 
    /// </summary>
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Accountold : TestBase
    {
        string browserstr = string.Empty;
        public Accountold(string browser)
            : base(browser)
        {
            browserstr = browser+"TPU";
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }
     
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);

            if (Meridian_Common.islog == true)
            {
                //driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void A_User_Views_People_insteadof_Items_count_on_Team_page()
        {
            driver.UserLogin("testuser", browserstr, "siteadmin", "password");
            TrainingHomeobj.TeamPage_MenuBar_click();
            Assert.IsTrue(TrainingHomeobj.VerifyUserNameColumn_Team());
        }
        [Test]
        public void B_User_jumps_to_Transcript_from_UserAccount_page()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.Click_MyAccount();
            Thread.Sleep(3000);
           Assert.IsTrue(TrainingHomeobj.Verify_UserJumpsToTranscript_FromAccountPage());
        }
        [Test]
        public void C_User_can_easily_select_multiple_secondary_languages_in_my_account_profile()
        {
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickPreferencesTab();
            Assert.IsTrue(MyAccountobj.EditPreferences_ForLanguage());
        }
       // [Test]
        public void D_User_views_loading_icon_while_filtering_Current_Training()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_CurrentTraining_click();
         Assert.IsTrue(CurrentTrainingsobj.LoadingIconAfterApplyFilters_CT());
        }
        [Test]
        public void E_LearnerSee_only_overall_score_whether_I_passed_when_complete_MG_test_Individual_Question_Turnedoff()
        {
            //Test for Question Like true/false beacuse essay type is already done and in this case US2087 is also covered with US2102
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Thread.Sleep(3000);
            Testsobj.Click_CreateGoTo();
            Testsobj.Populate_CreateForm("admin", browserstr);
            Testsobj.Click_CreateNewGroupGoTo();
            EditQuestionGroupobj.Populate_NewGroup(1);
            Testsobj.Click_NewQuestionGoTo("New True/False");
            EditQuestionobj.Populate_NewQuestionForTrueFalse();
            Testsobj.Click_testsLinkBreadCrumb();
            Thread.Sleep(2000);
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_LockTestLink();
            Detailsobj.Click_PublishScrom_1_2_Link();
            EditSummaryobj.Populate_TestForPublish_Question_HideTestResult();
            Assert.IsTrue(BrowseTrainingCatalogobj.Verify_LearnerTestResults_test_Individual_Question_Turnedoff(browserstr));
        }
        [Test]
        public void F_Migration_Existing_Profiles_Behavior_is_same_for_calculating_training_periods_last_completions_etc()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
            EditTrainingProfileobj.Click_CreateTrainingProfileDynamic(browserstr, "No");
            EditTrainingProfileobj.VerifyTraningProfilePastCompletionOptions("Yes", "Include completions within Initial Due Date Interval");
            driver.Navigate_to_TrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_searchTrainingProfile(browserstr);
            TrainingProfilesobj.Click_ManageTrainingProfile();
            Assert.IsTrue(EditTrainingProfileobj.VerifyMigratedExistingTraningProfile_Manage());

        }
    //    [Test] Flow changed Advance search option removed.
        public void G_As_learner_I_can_select_multiple_languages_prior_to_running_ContentSearch_can_RefineResultsBased_on_language()
        {
            driver.UserLogin("admin", browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
        //    TrainingHomeobj.Click_BrowseItem();
        //    BrowseTrainingCatalogobj.Click_ShowContent();
           // TrainingHomeobj.Click_TrainingCatalogLink();

            driver.GetElement(By.XPath(".//*[@id='btnSearch']/span")).ClickWithSpace();

         Assert.IsTrue(TrainingCatalogobj.Verification_SearchWthDifferentLanguages());
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
