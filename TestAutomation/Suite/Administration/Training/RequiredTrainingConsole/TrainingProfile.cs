using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;


namespace Selenium2.Meridian.Suite.Administration.Training
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class TrainingProfile : TestBase
    {
        string browserstr = string.Empty;
        public TrainingProfile(string browser)
            : base(browser)
        {
            browserstr = browser;
}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1",browserstr);
        }

        [SetUp]
        public void starttest()
        {

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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_DynamicTrainingProfileCreateGoTo();
            Assert.IsTrue(EditTrainingProfileobj.Click_CreateTrainingProfileDynamic(browserstr,"yes"));

        }

        [Test]
        public void b_Create_a_new_fixed_date_training_profile()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_FixedTrainingProfileCreateGoTo();
            Assert.IsTrue(EditTrainingProfileobj.Click_CreateTrainingProfileFixed(browserstr));

        }
        [Test]
        public void c_Conduct_a_simple_and_advanced_search_for_a_training_profile()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            Assert.IsTrue(TrainingProfilesobj.Click_searchTrainingProfile(browserstr));
            driver.Navigate_to_TrainingHome();
           // TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            Assert.IsTrue(TrainingProfilesobj.Click_AdvsearchTrainingProfile(browserstr));

        }


        [Test]
        public void d_Manage_a_training_profile()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Profiles");
            TrainingProfilesobj.Click_searchTrainingProfile(browserstr);
            TrainingProfilesobj.Click_ManageTrainingProfile();
            EditTrainingProfileobj.Click_UpdateTrainingProfileFixed();

        }


        [Test]
        public void e_Delete_a_Training_Profile()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
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
            if (Meridian_Common.islog == true)
            {
                 driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                TrainingHomeobj.lnk_requiredTrainingManagement_click();
                TrainingHomeobj.lnk_SystemOptions_click();
                
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }
    }
}
