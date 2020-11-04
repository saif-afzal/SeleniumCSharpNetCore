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
    class g_DevelopmentPlanold : TestBase
    {
        string browserstr = string.Empty;
        public g_DevelopmentPlanold(string browser)
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
        public void b_View_details_about_competencies_in_my_development_plan_18318()
        {

            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
       //     TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);
            Assert.IsTrue(DevelopmentPlansobj.Click_Competency(Variables.PerformanceCompetencyTitle));
            Assert.IsTrue(DevelopmentPlansobj.Check_CompetencyModal(Variables.PerformanceCompetencyTitle));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void a_Create_a_new_Development_Plan_and_open_it()
        {//For debug use only avoid the commented lines
            //driver.UserLogin("idpadmin", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.MyResponsiblities_click();
            //MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            //ProfessionalDevelopmentsobj.Click_CreateNewCompetency();
            //Assert.IsTrue(Createnewcompetencyobj.Click_Create(Variables.PerformanceCompetencyTitle, "", "Performance Competency"));
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
           
            //driver.UserLogin("idpadmin", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.MyResponsiblities_click();
            //MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            //ProfessionalDevelopmentsobj.Click_CreateNewSuccessProfile();
            //Assert.IsTrue(CreateNewSucessProfileobj.Click_Create(Variables.SuccessProfileTitle, "", browserstr));
            //SucessProfileobj.Click_AddCompetency();
            //Searchobj.Click_SearchCompetency(Variables.PerformanceCompetencyTitle);
            //Assert.IsTrue(Searchobj.Click_addcompetency());
            ////MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ////ProfessionalDevelopmentsobj.Click_search(Variables.SuccessProfileTitle, "Success Profile");
            ////SearchResultsobj.MyResponsbilities_ContentSP_Click();
            //SucessProfileobj.Click_AddOrganization();
            //Searchobj.Click_Searchorganization("Sample Organization 1");//Variables.organizationTitle + "sp");
            //Assert.IsTrue(Searchobj.Click_addorganization());
            //SucessProfileobj.Click_Save(browserstr);
            //SucessProfileobj.Click_Back();
            //SucessProfileobj.Click_Cancel();
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
       
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_CreateDevPlan();
            Assert.IsTrue(DevelopmentPlansobj.Check_DevelopmentPlan(Variables.SuccessProfileTitle, Variables.PerformanceCompetencyTitle));

            Assert.IsTrue(DevelopmentPlansobj.Check_DevelopmentPlanTitle(ExtractDataExcel.MasterDic_idpadmin["Firstname"]+browserstr, ExtractDataExcel.MasterDic_idpadmin["Lastname"]+browserstr));
            DevelopmentPlansobj.Update_DevelopmentPlanTitle("",browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void c_Add_success_profiles_that_populate_my_development_plan()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
         
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);
            DevelopmentPlansobj.Click_AddSucessProfile();
            DevelopmentPlansobj.Click_SearchSucessProfile("");
            Assert.IsTrue(DevelopmentPlansobj.Click_AddSPAction());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void d_Remove_success_profiles_from_development_plan_US164()
        {
            driver.UserLogin("idpadmin", browserstr);
            TrainingHomeobj.isTrainingHome();
        
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);
            Assert.IsTrue(DevelopmentPlansobj.Click_RemoveSucessProfile());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void e_View_Professional_Focus_Professional_Enhancement_and_General_Development_areas_of_development_plan_US170()
        {

            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
       
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);
            Assert.IsTrue(DevelopmentPlansobj.Check_DefaultAreas());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void f_Add_development_activities_to_my_development_plan_17977()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
        
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);
            DevelopmentPlansobj.Click_AddDevelopmentActivity(browserstr);
            AddDevelopmentActivitiesobj.Click_AddDevelopmentActivity();
            Assert.IsTrue(ContentSearchobj.Click_AddDevelopmentActivity());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void g_View_a_read_only_version_of_a_development_plan_after_it_has_been_submitted_for_approval()
        {

            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
        
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);
            Assert.IsTrue(DevelopmentPlansobj.Click_SubmitDevPlan());
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);
            Assert.IsTrue(DevelopmentPlansobj.Check_ReadOnly_DevPlan());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void h_Add_Additional_Career_Objectives_to_a_development_plan()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
       
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_CreateDevPlan();
            DevelopmentPlansobj.Update_DevelopmentPlanTitle(Variables.DevPlanTitle + " CarrerObj",browserstr);
            Assert.IsTrue(DevelopmentPlansobj.Click_Shorttermobj(browserstr));
            Assert.IsTrue(DevelopmentPlansobj.Click_Longtermobj(browserstr));
            
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void i_Submit_a_development_plan_for_approval()
        {

            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
         
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_CreateDevPlan();
            DevelopmentPlansobj.Update_DevelopmentPlanTitle(Variables.DevPlanTitle + "approval",browserstr);
            DevelopmentPlansobj.Click_AddDevelopmentActivity(browserstr);
            AddDevelopmentActivitiesobj.Click_AddDevelopmentActivity();
            Assert.IsTrue(ContentSearchobj.Click_AddDevelopmentActivity());
            Assert.IsTrue(DevelopmentPlansobj.Click_SubmitDevPlan());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void j_Add_development_activities_not_related_to_existing_success_profiles_as_General_Development_activities_18079()
        {

            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
         
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle);

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
