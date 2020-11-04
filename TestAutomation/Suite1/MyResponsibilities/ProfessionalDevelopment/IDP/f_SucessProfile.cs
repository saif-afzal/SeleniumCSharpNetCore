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

namespace Selenium2.Meridian.Suite.MyResponsibilities.ProfessionalDevelopment.IDP
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class f_SucessProfileold : TestBase
    {
        string browserstr = string.Empty;
        public f_SucessProfileold(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        private bool s17635 = false;
        private bool s17636 = false;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
           
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
       
        [Test]
        public void a_create_a_Success_Profile_17634()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_CreateNewSuccessProfile();
            Assert.IsTrue(CreateNewSucessProfileobj.Click_Create(Variables.SuccessProfileTitle,"",browserstr));
            SucessProfileobj.Click_AddCompetency();
            Searchobj.Click_SearchCompetency(Variables.PerformanceCompetencyTitle);
            Assert.IsTrue(Searchobj.Click_addcompetency());
            //MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            //ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
            //SearchResultsobj.MyResponsbilities_ContentSP_Click();
            SucessProfileobj.Click_AddOrganization();
            Searchobj.Click_Searchorganization("Sample Organization 1");//Variables.organizationTitle + "sp");
            Assert.IsTrue(Searchobj.Click_addorganization());
            SucessProfileobj.Click_Save(browserstr);
            SucessProfileobj.Click_Back();
            SucessProfileobj.Click_Cancel();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            s17635 = true;
            s17636 = true;
        }
        //[Test]
        //public void a_create_a_Success_Profile_17635()
        //{
        //    Assert.IsTrue(s17635, "a_create_a_Success_Profile_17634 got fail");
        //}
        //[Test]
        //public void a_create_a_Success_Profile_17636()
        //{
        //    Assert.IsTrue(s17636, "a_create_a_Success_Profile_17634 got fail");
        //    }
        [Test]
        public void b_Edit_a_Success_Profile_17634()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
            SearchResultsobj.MyResponsbilities_ContentSP_Click();
            SucessProfileobj.Click_EditSP();
            Assert.IsTrue(SucessProfileobj.Edit_Save(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        //[Test]
        //public void c_Associate_Competency_to_a_success_profile()
        //{
        //    driver.UserLogin("idpadmin");
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.MyResponsiblities_click();
        //    MyResponsibilitiesobj.Click_ProfessionalDevelopment();
        //    ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
        //    SearchResultsobj.MyResponsbilities_ContentSP_Click();
        //    SucessProfileobj.Click_AddCompetency();
        //    Searchobj.Click_SearchCompetency(Variables.PerformanceCompetencyTitle);
        //    Assert.IsTrue(Searchobj.Click_addcompetency());
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //}

        //[Test]
        //public void d_Associate_Organization_to_a_success_profile()
        //{
        
        //    driver.UserLogin("idpadmin");
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.MyResponsiblities_click();
        //    MyResponsibilitiesobj.Click_ProfessionalDevelopment();
        //    ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
        //    SearchResultsobj.MyResponsbilities_ContentSP_Click();
        //    SucessProfileobj.Click_AddOrganization();
        //    Searchobj.Click_Searchorganization("Bug Bash Org");//Variables.organizationTitle + "sp");
        //    Assert.IsTrue(Searchobj.Click_addorganization());
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //}

        [Test]
        public void e_View_existing_success_profiles_via_a_Manage_Success_Profiles_page_17637()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageSuccessProfile();
            ManageSuccessProfileobj.Click_SearchProfile(Variables.SuccessProfileTitle);
            Assert.IsTrue(ManageSuccessProfileobj.Check_Items());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void f_Delete_a_success_profile_that_is_not_in_use_17674()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_CreateNewSuccessProfile();
            Assert.IsTrue(CreateNewSucessProfileobj.Click_Create(Variables.SuccessProfileTitle,"delete",browserstr));
            SucessProfileobj.Click_AddCompetency();
            Searchobj.Click_SearchCompetency(Variables.PerformanceCompetencyTitle);
            Assert.IsTrue(Searchobj.Click_addcompetency());
            //MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            //ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
            //SearchResultsobj.MyResponsbilities_ContentSP_Click();
            SucessProfileobj.Click_AddOrganization();
            Searchobj.Click_Searchorganization("Sample Organization 2");//Variables.organizationTitle + "sp");
            Assert.IsTrue(Searchobj.Click_addorganization());
            SucessProfileobj.Click_Save(browserstr);
            SucessProfileobj.Click_Back();
            SucessProfileobj.Click_Cancel();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageSuccessProfile();
            ManageSuccessProfileobj.Click_SearchProfile(Variables.SuccessProfileTitle + "delete");
            Assert.IsTrue(ManageSuccessProfileobj.Click_Delete());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void g_Save_target_data_associated_with_a_success_profile_17692()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
            SearchResultsobj.MyResponsbilities_ContentSP_Click();
            SucessProfileobj.Click_EditSP();
            Assert.IsTrue(SucessProfileobj.Edit_Save(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void h_Edit_target_data_associated_with_a_success_profile_17692()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
            SearchResultsobj.MyResponsbilities_ContentSP_Click();
            SucessProfileobj.Click_EditSP();
            Assert.IsTrue(SucessProfileobj.Edit_Save(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        

        [Test]
        public void j_View_success_profiles_assigned_to_the_employee()
      {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_ProfessionalDevelopment();
            Assert.IsTrue(ProfessionalDevelopments_learnerobj.Check_SucessProfile(Variables.SuccessProfileTitle,Variables.PerformanceCompetencyTitle));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void k_Search_for_and_add_new_Success_Profiles_to_My_Success_Profiles_dashboard()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_AddSucessProfile();
            ProfessionalDevelopments_learnerobj.Click_SearchSucessProfile("");
            Assert.IsTrue(ProfessionalDevelopments_learnerobj.Click_AddSPAction());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void l_Indication_should_be_displayed_when_a_competency_overlaps_multiple_success_profiles()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_CreateNewSuccessProfile();
            Assert.IsTrue(CreateNewSucessProfileobj.Click_Create(Variables.SuccessProfileTitle,"overlap",browserstr));
            SucessProfileobj.Click_AddCompetency();
            Searchobj.Click_SearchCompetency(Variables.PerformanceCompetencyTitle);
            Assert.IsTrue(Searchobj.Click_addcompetency());
            //MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            //ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
            //SearchResultsobj.MyResponsbilities_ContentSP_Click();
            SucessProfileobj.Click_AddOrganization();
            Searchobj.Click_Searchorganization("Sample Organization 1");//Variables.organizationTitle + "sp");
            Assert.IsTrue(Searchobj.Click_addorganization());
            SucessProfileobj.Click_Save(browserstr);
            SucessProfileobj.Click_Back();
            SucessProfileobj.Click_Cancel();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_CreateDevPlan();
            Assert.IsTrue(DevelopmentPlansobj.Check_OverlapofCompetency(Variables.PerformanceCompetencyTitle));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }


      
        [TearDown]
        public void stoptest()
        {

            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }

    }
}
