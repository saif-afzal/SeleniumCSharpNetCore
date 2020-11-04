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
    class b_ProficiencyScale : TestBase
    {
        string browserstr = string.Empty;
        public b_ProficiencyScale(string browser)
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
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_idpadmin["Id"] + browserstr, ExtractDataExcel.MasterDic_idpadmin["Firstname"] + browserstr, ExtractDataExcel.MasterDic_idpadmin["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization 1");//Variables.organizationTitle + "sp");//
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_idpadmin["Firstname"] + browserstr, ExtractDataExcel.MasterDic_idpadmin["Lastname"] + browserstr);
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_idpadmin["Id"], ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsTab("People");
            TrainingHomeobj.click_systemOptionsAccordian("Users");
            TrainingHomeobj.click_systemOptionsLink("Roles");
            Roleobj.Click_Search("Competency Manager");
            Roleobj.Click_EditUserGoTo();
            Roleobj.Click_AddUserGoTo();
            Roleobj.Click_SearchUserToAdd(ExtractDataExcel.MasterDic_idpadmin["Firstname"] + browserstr);
           Roleobj.Click_AddUser();
           driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         
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
        public void a_create_a_proficiency_scale_for_performance_competencies_17385()
        {
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_CreateNewProficencyScale();
           Assert.IsTrue( Createnewproficencyscaleobj.Click_Create(ExtractDataExcel.MasterDic_ProficencyScale["Title"],""));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void b_View_Manage_Proficiency_Scales_page_as_an_admin_US127_17400_17414()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageProficencyScale();
            ManageProficencyScaleobj.Click_SearchScale("");
            Assert.IsTrue(ManageProficencyScaleobj.Check_Items());
            Assert.IsTrue(ManageProficencyScaleobj.sort_title());
            Assert.IsTrue(ManageProficencyScaleobj.Click_title());
            Assert.IsTrue(ManageProficencyScaleobj.Click_infoicon());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void c_archive_a_proficiency_scale_17415()
        {
            driver.UserLogin("idpadmin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_CreateNewProficencyScale();
            Assert.IsTrue(Createnewproficencyscaleobj.Click_Create(ExtractDataExcel.MasterDic_ProficencyScale["Title"],"archive"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("idpadmin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageProficencyScale();
            ManageProficencyScaleobj.Click_SearchScale(ExtractDataExcel.MasterDic_ProficencyScale["Title"] + "archive");
            Assert.IsTrue(ManageProficencyScaleobj.Click_ArchiveItem());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void d_view_archived_proficiency_scales_17416()
        {
            driver.UserLogin("idpadmin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageProficencyScale();
            ManageProficencyScaleobj.Click_ViewArchive();
            Assert.IsTrue(ArchivedProficencyScaleobj.Check_Items());
            Assert.IsTrue(ArchivedProficencyScaleobj.Click_title());
            Assert.IsTrue(ArchivedProficencyScaleobj.Click_infoicon());
            Assert.IsTrue(ArchivedProficencyScaleobj.Click_Copy());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void e_edit_a_proficiency_scale_that_is_not_inuse_17436()
        {
            driver.UserLogin("idpadmin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageProficencyScale();
            ManageProficencyScaleobj.Click_SearchScale(ExtractDataExcel.MasterDic_ProficencyScale["Title"]);
            ManageProficencyScaleobj.Click_Edit();
           Assert.IsTrue( ManageProficencyScaleobj.Click_save(browserstr));
         
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void f_copy_a_proficiency_scale_and_use_as_a_template_for_a_new_one_17495()
        {
            driver.UserLogin("idpadmin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageProficencyScale();
            ManageProficencyScaleobj.Click_SearchScale(ExtractDataExcel.MasterDic_ProficencyScale["Title"]);
           Assert.IsTrue( ManageProficencyScaleobj.Click_Copy(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void g_view_information_about_a_proficiency_scale_17512()
        {
            driver.UserLogin("idpadmin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_ManageProficencyScale();
            ManageProficencyScaleobj.Click_SearchScale("");
            Assert.IsTrue(ManageProficencyScaleobj.Click_infoicon());
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
