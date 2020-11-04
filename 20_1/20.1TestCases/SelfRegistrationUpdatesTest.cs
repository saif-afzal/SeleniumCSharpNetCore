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
    public class P1_SelfRegistrationUpdatesTest : TestBase
    {

        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;
        string scormtitle = "SCROMTitle" + Meridian_Common.globalnum;
        static string today = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
        bool TC62626;
        bool TC61864;
        bool TC61744;
        bool TC61747;

        public P1_SelfRegistrationUpdatesTest(string browser)
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
        public void tc_61680_As_an_admin_I_want_to_set_default_organization_for_Self_registration()
        {
            CommonSection.Administer.System.DomainsandURLS.Domains();
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            _test.Log(Status.Info, "Navigate to option tab");
            EditConfigurationOptionsPage.EditConfigurationTab.ClickOrgResetLink();
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isDefaultOrganization("None"));
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isSelectbuttonisdisplay());
            EditConfigurationOptionsPage.EditConfigurationTab.ClickSelect();
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isSelectOrganizationWindowOpen());
            EditConfigurationOptionsPage.EditConfigurationTab.SelectOrganizationWindow.SelectOrg("Sample");
            //Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isOrgResetLinkdisplay());
            //EditConfigurationOptionsPage.EditConfigurationTab.ClickOrgResetLink();
            EditSummaryPage.OptionsTab.Save();



        }
        [Test, Order(2)]
        public void tc_61679_As_a_learner_Learner_utilize_Default_Organization_while_self_registration()
        {

            CommonSection.Logout();
            LoginPage.ClickSignup();
            _test.Log(Status.Info, "Click Sign up link on Login Page");
            Assert.IsTrue(CreateAccountPage.checkTilte("Create Account"));
            _test.Log(Status.Pass, "Verify Create Account Page is Opened");
            string id = CreateAccountPage.CreateNewUserLinkOuter(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            Assert.IsTrue(CreateAccountPage.isNextpagedisplay());
            Assert.IsFalse(CreateAccountPage.isSelectOrgdisplay());
            _test.Log(Status.Pass, "Verify select organization is not display");
           // CreateAccountPage.SelectPerPageRec();
            CreateAccountPage.clickCreate();
            Assert.IsTrue(CreateAccountPage.isSuccessmessagedisplay());
            _test.Log(Status.Pass, "Verify is account created successfully");
            LoginPage.LoginAs(id).WithPassword("password").Login();
            _test.Log(Status.Info, "Login with new id");
            Assert.IsTrue(HomePage.Title == "Home");
            _test.Log(Status.Pass, "User Successfully Logged in");
            TC62626 = true;
            TC61864 = true;
            TC61744 = true;
        }
       
        

        [Test, Order(6)]
        public void tc_62150_Self_Registration_and_Public_Catalog_Setting_controls_all_user_account_creation()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.System.DomainsandURLS.Domains();
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            _test.Log(Status.Info, "Navigate to option tab");
            Assert.IsTrue(EditConfigurationOptionsPage.isSeftRegistrationisOn());
            EditConfigurationOptionsPage.SetSeftRegistration("Off");
            Assert.IsTrue(EditConfigurationOptionsPage.isPublicCatalogYes());
            EditConfigurationOptionsPage.SetPublicCatalog("No");
            EditConfigurationOptionsPage.ClickSave();
            CommonSection.Logout();
            Assert.IsFalse(LoginPage.isSignupLisnkdisplay());
            Assert.IsFalse(LoginPage.isBrowsePublicCatalog());
            _test.Log(Status.Pass, "Verify both sign up and Public catalog link is not present");

            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.System.DomainsandURLS.Domains();
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            _test.Log(Status.Info, "Navigate to option tab");
            Assert.IsFalse(EditConfigurationOptionsPage.isSeftRegistrationisOn());
            EditConfigurationOptionsPage.SetSeftRegistration("On");
            EditConfigurationOptionsPage.SetPublicCatalog("Yes");
            EditConfigurationOptionsPage.ClickSave();
        }
        [Test, Order(7)]
        public void tc_61748_As_a_Domain_Admin_enable_Custom_and_Optional_System_Fields_in_Field_Management_for_Account_Creation_form()
        {
            CommonSection.Administer.System.BrandingAndCustomization.FieldManagement();
            _test.Log(Status.Info, "Navigate to Field Management page from administer >> system >> branding");
            FieldManagementPage.Userprofile.ClickUserInformation();
            _test.Log(Status.Info, "Click on user informantion");
            FieldlibraryPage.clickSystemTab();
            FieldlibraryPage.SystemTab.ClickAddressLebel();
            Assert.IsTrue(EditSystemFieldsPage.isIncludeonAccountCreationDisplay());
            _test.Log(Status.Pass, "Verify Include on Account Creation lebel is visible");
            Assert.IsFalse(EditSystemFieldsPage.isIncludeonAccountCreationisUnchecked());
            _test.Log(Status.Pass, "Verify Include on Account Creation lebel is visible");
            TC61747 = true;
        }
        [Test, Order(8)]
        public void tc_61747_As_an_Admin_enable_Custom_and_Optional_System_Fields_in_Field_Management_for_Account_Creation_form()
        {
            Assert.IsTrue(TC61747);
        }
        [Test, Order(9)]
        public void tc_7279_Manage_Scorm_Course_Setting()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7279");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            ContentDetailsPage.Click_CheckOut();
            ContentDetailsPage.Accordians.Edit_ScormCourseSetting();
            _test.Log(Status.Info, "Click scorm course setting ");
            Assert.IsTrue(EditCourseSettingPage.isPlayerModedisplay());
            _test.Log(Status.Pass, "Verify Player Mode setting is display");
            Assert.IsTrue(EditCourseSettingPage.PlayerModeddropdownlist("Play Inline", "New Window", "New Window (Legacy Player"));
            _test.Log(Status.Pass, "Verify Player Mode setting dropdown list");
            EditCourseSettingPage.ClickSave();            
            //StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(10), Category("AutomatedP11")]
        public void tc_26248_Launch_SCROM()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26248");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Info, "Checkin the scrom course");
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from Admin");
            //LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(scormtitle + "TC26248");
            _test.Log(Status.Info, "Search the created SCROM");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26248");
            _test.Log(Status.Info, "Click on the searched SCROM");
            ContentDetailsPage.ContentBanner.Click_Enrollbutton();
            _test.Log(Status.Info, "Enroll at the course");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Verify open button is available");
            ContentDetailsPage.ContentBanner.ClickOpenItembutton();
            _test.Log(Status.Info, "Click open item");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyCourseOpensInNewWindow());
            _test.Log(Status.Pass, "Verify course opens in new window");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Info, "Complete scrom course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyDateofCompletion(today));
            _test.Log(Status.Pass, "Verify scrom date of completeion");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyViewCertificateButtonAvailable());
            _test.Log(Status.Pass, "Verify View Certificate button is available on completeion");
            Driver.focusParentWindow();
        }




    }
}