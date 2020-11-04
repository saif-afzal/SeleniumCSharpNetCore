using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.Administration.Training
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class TrainingProfileold : TestBase
    {
        string browserstr = string.Empty;
        public TrainingProfileold(string browser)
            : base(browser)
        {
            browserstr = browser+"tpo";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
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
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        #region Titans_Team_1RTProfile
        [Test]
        public void A_interval_for_calculating_recurrences_CreateDynamic_Profile_when_no_recurrence_set()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
            EditTrainingProfileobj.ValidatePreviewEmailLink();
            EditTrainingProfileobj.Click_CreateTrainingProfileDynamic(browserstr, "No");
            EditTrainingProfileobj.VerifyTraningProfilePastCompletionOptions("Yes", "Include all completions");
        }
        [Test]
        public void B_interval_for_calculating_recurrences_CreateDynamic_Profile_when_recurrence_set()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
            EditTrainingProfileobj.Click_CreateTrainingProfileDynamic(browserstr + "new", "No");
            EditTrainingProfileobj.VerifyTraningProfilePastCompletionOptions("Yes", "Include all completions");
        }
        [Test]
        public void C_interval_for_calculating_recurrences_Validate_that_Correct_duedates_appear_in_RTreporting_for_all_scenarios()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
            EditTrainingProfileobj.Click_CreateTrainingProfileDynamic(browserstr + "new", "yes");
        }
        #endregion
        [Test]
        public void a_Create_a_new_dynamic_training_profile()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
            Assert.IsTrue(EditTrainingProfileobj.Click_CreateTrainingProfileDynamic(browserstr,"yes"));

        }

        [Test]
        public void b_Create_a_new_fixed_date_training_profile()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_FixedTrainingProfileCreateGoTo();
            Assert.IsTrue(EditTrainingProfileobj.Click_CreateTrainingProfileFixed(browserstr));

        }
        [Test]
        public void c_Conduct_a_simple_and_advanced_search_for_a_training_profile()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            Assert.IsTrue(TrainingProfilesobj.Click_searchTrainingProfile(browserstr));
            driver.Navigate_to_TrainingHome();
            // TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            Assert.IsTrue(TrainingProfilesobj.Click_AdvsearchTrainingProfile(browserstr));

        }


        [Test]
        public void d_Manage_a_training_profile()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_searchTrainingProfile(browserstr);
            TrainingProfilesobj.Click_ManageTrainingProfile();
            EditTrainingProfileobj.Click_UpdateTrainingProfileFixed();

        }


        [Test]
        public void e_Delete_a_Training_Profile()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_searchTrainingProfile(browserstr);
            TrainingProfilesobj.Check_ProfileToDelete();
            TrainingProfilesobj.Click_ProfileToDelete();

        }
        //excluded as scenarios are to be updated by saif
        //[Test]
        //public void f_share_training_profiles_to_other_domains()
        //{
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_requiredTrainingManagement_click();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
        //    TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
        //    EditTrainingProfileobj.Click_CreateTrainingProfileDynamic();
        //    EditTrainingProfileobj.Click_SharingTab();
        //    Assert.IsTrue(EditTrainingProfileobj.shareTrainingProfileToChildDomain());

        //}

        //[Test]
        //public void g_domain_sharing_tab_present_in_training_profiles_information_window_in_KView()
        //{
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_requiredTrainingManagement_click();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
        //    TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
        //    EditTrainingProfileobj.Click_CreateTrainingProfileDynamic();
        //    EditTrainingProfileobj.Click_SharingTab();
        //    EditTrainingProfileobj.shareTrainingProfileToChildDomain();
        //    TrainingProfilesobj.Click_searchTrainingProfile(browserstr);
        //    TrainingProfilesobj.Click_infoIcon();
        //    TrainingProfilesobj.verify_DomainSharingTabPresent();

        //}


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
