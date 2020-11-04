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
    public class P2_Afreen : TestBase
    {
        string DocumentTitle = "Document" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string curriculumTitle = "Curriculum" + Meridian_Common.globalnum;
        string bundleTitle = "Bundle" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscription" + Meridian_Common.globalnum;

        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string block = "Block_" + Meridian_Common.globalnum;
        bool TC26963 = false;
        bool TC27167 = false;

        public P2_Afreen(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string CertificatrTitle = "Certi" + Meridian_Common.globalnum;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
        }
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath = screenShotPath.Replace(@"C:\Users\admin\Desktop\Automation\Regression Scripts\18.2\", @"Z:\");
                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    if (driver.Title == "Object reference not set to an instance of an object.")
                    {
                        driver.Navigate_to_TrainingHome();
                        Driver.focusParentWindow();
                        CommonSection.Avatar.Logout();
                        LoginPage.LoginClick();
                        LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
                    }

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
                driver.Navigate().Refresh();
            }
        }
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }
        [Test, Order(1)]
        public void b01_Document_Add_Locale_7458()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC7458");
            _test.Log(Status.Info, "Create a Document");

            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");

            Assert.IsTrue(ContentDetailsPage.isDefultLocaledisplay());
            _test.Log(Status.Pass, "Verify Defult Locale display");

            ContentDetailsPage.AddLocale();
            _test.Log(Status.Info, "Added new locale to curriculumn");

            Assert.IsTrue(ContentDetailsPage.Localedropdownlistdisplay());
            _test.Log(Status.Pass, "Verify Locale dropdown display");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(2)]
        public void b02_Document_Delete_Locale_7459()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC7459");
            _test.Log(Status.Info, "Create a Document");

            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");

            Assert.IsTrue(ContentDetailsPage.isDefultLocaledisplay());
            _test.Log(Status.Pass, "Verify Defult Locale display");

            ContentDetailsPage.AddLocale();
            _test.Log(Status.Info, "Added new locale to curriculumn");

            Assert.IsTrue(ContentDetailsPage.Localedropdownlistdisplay());
            _test.Log(Status.Pass, "Verify Locale dropdown display");

            ContentDetailsPage.DeleteLocale();
            _test.Log(Status.Info, "Delete locale from curriculumn");
            Assert.IsTrue(ContentDetailsPage.isDefultLocaledisplay());
            _test.Log(Status.Pass, "Verify Defult Locale display");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(3)]
        public void b03_Document_Delete_Version_button_7482()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC7482");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.EditVersioning_Enabled("1.0");
            _test.Log(Status.Info, "Enable versioning by adding values");
            VersionsPage.Click_Back();
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            AdminContentDetailsPage.AddVersion();
            _test.Log(Status.Info, "`Click Add Version");
            StringAssert.AreEqualIgnoringCase("The new version was added for the content item.", AdminContentDetailsPage.VerifyNewVersionSuccessMessage());
            _test.Log(Status.Pass, "Verify New Version Success Message");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyDeleteVersionButton());
            _test.Log(Status.Pass, "Verify Delete version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyManageVersionButton());
            _test.Log(Status.Pass, "Verify Manage version Button is Displayed");
            AdminContentDetailsPage.DeleteVesion("Version 1.1 English (United States)");
            _test.Log(Status.Info, "Delete Version from Dropdown list using Delete Button");
            StringAssert.AreEqualIgnoringCase("The version was deleted.", AdminContentDetailsPage.VerifyDeleteVersionSuccessMessage());
            _test.Log(Status.Pass, "Verify Delete Version Success Message");
            //Assert.IsFalse(AdminContentDetailsPage.VerifyAddVersionButton());
            //_test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsFalse(AdminContentDetailsPage.VerifyDeleteVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsFalse(AdminContentDetailsPage.VerifyManageVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");



        }
        [Test, Order(4)]
        public void b04_Document_Delete_Version_Manage_Versions_7483()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            TrainingPage.ManageContentPortlet.SearchForContent(DocumentTitle + "TC7482");
            _test.Log(Status.Info, "Search for Content");
            ManageContentPage.ClickContentTitle(DocumentTitle + "TC7482");
            _test.Log(Status.Info, "Click on Coure title ");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            AdminContentDetailsPage.AddVersion();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            Assert.IsTrue(Driver.comparePartialString(" The new version was added for the content item.", AdminContentDetailsPage.VerifyNewVersionSuccessMessage()));
            _test.Log(Status.Pass, "Verify New Version Success Message");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddedVersionsInDropDownlist());
            _test.Log(Status.Pass, "Verify added version in Dropdown List");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyDeleteVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyManageVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            AdminContentDetailsPage.ManageVersion_Delete("Version 1.1 English (United States)");
            _test.Log(Status.Info, "Delete Version from Manage Version Button");
            Assert.IsTrue(Driver.comparePartialString(" The version was deleted.", ManageVersionsPage.VerifyDeleteVersionSuccessMessage()));
            _test.Log(Status.Pass, "Verify Delete Version Message");
            ManageVersionsPage.Click_Back();
            _test.Log(Status.Pass, "Click Back Button");
            Assert.IsFalse(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsFalse(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsFalse(AdminContentDetailsPage.VerifyDeleteVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsFalse(AdminContentDetailsPage.VerifyManageVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");



        }

        [Test, Order(5)]
        public void b05_Document_info_icon_16325()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            TrainingPage.ManageContentPortlet.SearchForContent("Document");
            _test.Log(Status.Info, "Search for Content");
            ManageContentPage.ClickFirstContentTitle();
            _test.Log(Status.Info, "Click on Coure title ");
            ContentDetailsPage.Click_InfoIcon();
            _test.Log(Status.Info, "Click on info icon");
            Assert.IsTrue(ContentDetailsPage.VerifyInformationModal());
            _test.Log(Status.Info, "Verify Information modal is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.SummaryTab_verifyUniqueID());
            _test.Log(Status.Info, "Verify Unique ID is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.SummaryTab_verifyContentType());
            _test.Log(Status.Info, "Verify Content Type is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.SummaryTab_verifyCreatedDate());
            _test.Log(Status.Info, "Verify Created Date is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.SummaryTab_verifyCreatedBy());
            _test.Log(Status.Info, "Verify Created By is Displayed");
            ContentDetailsPage.Information.Click_CategoriesTab();
            _test.Log(Status.Info, "Click on Categories Tab");

            Assert.IsTrue(ContentDetailsPage.Information.CategoriesTab_verifyInstruction());
            _test.Log(Status.Info, "Verify Instruction is Displayed");
            ContentDetailsPage.Information.CategoriesTab_verifyRecordsCount();
            _test.Log(Status.Info, "Verify records Count");

            ContentDetailsPage.Information.Click_StatusTab();
            _test.Log(Status.Info, "Click status Tab");

            ContentDetailsPage.Information.StatusTab_VerifyEditingHistory();
            _test.Log(Status.Info, "Verify Editing History is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.StatusTab_verifyCheckoutDate());
            _test.Log(Status.Info, "Verify Created By is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.StatusTab_verifyCheckinDate());
            _test.Log(Status.Info, "Verify Created By is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.StatusTab_verifyCheckinUser());
            _test.Log(Status.Info, "Verify Created By is Displayed");
            Assert.IsTrue(ContentDetailsPage.Information.StatusTab_verifyCheckoutUser());
            _test.Log(Status.Info, "Verify Created By is Displayed");
            ContentDetailsPage.Information.Click_PermissionsTab();
            _test.Log(Status.Info, "Click Permissions Tab");
            ContentDetailsPage.Information.PermissionsTab_VerifyPermissions();
            _test.Log(Status.Info, "Verify Permissions");
            ContentDetailsPage.Information.Click_DomainSharing();
            _test.Log(Status.Info, "Click on Domain sharing");
            Assert.IsTrue(ContentDetailsPage.Information.DomainSharingTab_verifyDomainOwner());
            _test.Log(Status.Info, "Click on Domain sharing");
            ContentDetailsPage.Information.Click_Prerequisites();
            _test.Log(Status.Info, "Click on Domain sharing");
            ContentDetailsPage.Information.PrerequisitesTab_verifyPrerequisites();
            _test.Log(Status.Info, "Click on Domain sharing");
            ContentDetailsPage.Information.Click_Equivalencies();
            _test.Log(Status.Info, "Click on Domain sharing");
            ContentDetailsPage.Information.Click_ContentAssociations();
            _test.Log(Status.Info, "Click on Domain sharing");
            ContentDetailsPage.Information.ContentAssociationsTab_verifyAssociatedContents();
            _test.Log(Status.Info, "Click on Domain sharing");
        }
        [Test, Order(6)]
        public void b06_View_as_Learner_Document_27993()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            TrainingPage.ManageContentPortlet.SearchForContent("Document");
            _test.Log(Status.Info, "Search for Content");
            ManageContentPage.ClickFirstContentTitle();
            _test.Log(Status.Info, "Click on Coure title ");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner ");
            Assert.IsTrue(ContentDetailsPage.isContentPageDisplayed());
            _test.Log(Status.Pass, "verify Content Page is Displayed");

        }
        [Test, Order(7)]
        public void b07_Create_Document_Add_Access_Period_updated_13361()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC13361");
            _test.Log(Status.Info, "Create a Document");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_AddAccessPeriod("1");
            _test.Log(Status.Info, "Edit Access Period");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.VerifySuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            string AccessPeriod = ContentDetailsPage.AccessPeriod();
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner");
            Assert.IsTrue(ContentDetailsPage.verifyAccessPeriod(AccessPeriod));
            _test.Log(Status.Info, "Verify Access Period");




        }
        [Test, Order(8)]
        public void b08_Manage_Document_Add_Access_Period_updated__13362()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            TrainingPage.ManageContentPortlet.SearchForContent(DocumentTitle + "TC13361");
            _test.Log(Status.Info, "Search for Content");
            ManageContentPage.ClickContentTitle(DocumentTitle + "TC13361");
            _test.Log(Status.Info, "Click on Course title ");
            ContentDetailsPage.Click_CheckOut();
            _test.Log(Status.Info, "Click on Coure title ");
            string AccessPeriod = ContentDetailsPage.AccessPeriod();
            ContentDetailsPage.Edit_AddAccessPeriod("6");
            _test.Log(Status.Info, "Edit Access Period");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.VerifySuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            string UpdatedAccessPeriod = ContentDetailsPage.AccessPeriod();
            Assert.IsTrue(ContentDetailsPage.VerifyUpdatedAccessPeriod(AccessPeriod, UpdatedAccessPeriod));
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner");
            Assert.IsTrue(ContentDetailsPage.verifyUpdatedAccessPeriod(UpdatedAccessPeriod));
            _test.Log(Status.Info, "Verify Access Period");




        }
        [Test, Order(9)]
        public void b09_Manage_Document_Remove_Access_Period_updated__13363()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            TrainingPage.ManageContentPortlet.SearchForContent(DocumentTitle + "TC13361");
            _test.Log(Status.Info, "Search for Content");
            ManageContentPage.ClickContentTitle(DocumentTitle + "TC13361");
            _test.Log(Status.Info, "Click on Course title ");
            ContentDetailsPage.Click_CheckOut();
            _test.Log(Status.Info, "Click on Coure title ");
            string AccessPeriod = ContentDetailsPage.AccessPeriod();

            ContentDetailsPage.Edit_DisableAccessPeriod();
            _test.Log(Status.Info, "Click on Edit Access Period Disable it");

            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.VerifySuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");

        }
        [Test, Order(10)]
        public void P20_1_b10_View_All_Document_Attempts_26209()
        {
            CommonSection.SearchCatalog("Document");
            _test.Log(Status.Info, "Search text in Catalog Search");

            SearchResultsPage.ClickFirstTitle();
            _test.Log(Status.Info, "Click on First Title");

            ContentDetailsPage.ViewAllAttempts();
            _test.Log(Status.Info, "Click on view all attempts");

            Assert.IsTrue(ContentDetailsPage.VerifyViewAllAttenpts());
            _test.Log(Status.Info, "Verify View all attempts");

        }
        [Test, Order(11)]
        public void b11_View_Prerequisities_to_Document_26974()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC26974");
            _test.Log(Status.Info, "Create a general Course for Prerequisite");

            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC26974");
            _test.Log(Status.Info, "Create a Document");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_Prerequisites(GeneralCourseTitle + "TC26974");
            _test.Log(Status.Pass, "Click edit Prerequisite and add Prerequisite");
            Assert.IsTrue(Driver.comparePartialString(" The selected items were added as prerequisites." +
                " If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify  Success message");
            PrerequisitesPage.Click_BreadCrumb();
            _test.Log(Status.Pass, "Click breadcrumbs");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner");
            Assert.IsTrue(Driver.comparePartialString("You have one or more prerequisites to complete before you can take or access this item." +
                " If you have previously completed the item, then you may not have completed it in the allotted time or did not achieve the required score.", ContentDetailsPage.VerifyPrerequisiteInformation()));
            _test.Log(Status.Pass, "Verify  information");
            Assert.IsTrue(ContentDetailsPage.isPrerequisitesAccordiandisplayed());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteStatusDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite status is Displayed");
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteCostDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite Cost is Displayed");
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteTitleDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite Cost is Displayed");
            ContentDetailsPage.click_PrerequisiteTitle(GeneralCourseTitle + "TC26974");
            _test.Log(Status.Info, "Click Prerequisite Title");

        }
        [Test, Order(12)]
        public void b12_Equivalent_Items_to_a_Document_27168()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC26974");
            _test.Log(Status.Info, "Create a Document");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click on Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencies();
            _test.Log(Status.Info, "Click on Edit Equivalencies");
            AddEquivalenciesPage.Search("general");
            _test.Log(Status.Info, "Search for a genaral course");
            AddEquivalenciesPage.SelectRecord();
            _test.Log(Status.Info, "Select a record");
            AddEquivalenciesPage.ClickAddButton();
            _test.Log(Status.Info, "Click on Add Button");
            EquivalenciesPage.ClickViewAsLearner();
            _test.Log(Status.Info, "Click on View as Learner");
            Assert.IsTrue(ContentDetailsPage.isEquivalenciesDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies table is Displayed");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.isTitleDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies Title is Displayed");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.isProgressStatusDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies Progress status is Displayed");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.isCostDisplayed());
            _test.Log(Status.Pass, "Verify Equivalencies Cost is Displayed");



        }

        [Test, Order(13)]
        public void P20_1_b13_View_Post_Access_Items_to_Document_27108()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "Child");
            _test.Log(Status.Info, "Create a Document");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "Parent");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.AddPrequisites(DocumentTitle + "Child");
            _test.Log(Status.Info, "Click Edit Prerequisite and add Prequisite");
            Assert.IsTrue(Driver.comparePartialString(" The selected items were added as prerequisites. " +
                "If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.VerifyPrerequisiteMessage()));
            _test.Log(Status.Pass, "Verify prerequisite message");
            CommonSection.CatalogSearchText(DocumentTitle + "Parent");
            _test.Log(Status.Info, "Search for content through Catalog search");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "Parent");
            _test.Log(Status.Info, "Click the content Title");
            Assert.IsTrue(ContentDetailsPage.isprerequisitetableDisplayed());
            _test.Log(Status.Pass, "Verify is the prerquisite table Dispayed");
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteTitleDisplayed());
            _test.Log(Status.Pass, "Verify is the prerquisite title Dispayed");
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteCostDisplayed());
            _test.Log(Status.Pass, "Verify is the prerquisite Cost Dispayed");
            Assert.IsTrue(ContentDetailsPage.isPrerequisiteStatusDisplayed());
            _test.Log(Status.Pass, "Verify is the prerquisite Status Dispayed");
            ContentDetailsPage.ClickPrerequisiteTitle();
            _test.Log(Status.Info, "Click the prerequisite Title");
            Assert.IsTrue(ContentDetailsPage.isOtherAvailableTraining());
            _test.Log(Status.Pass, "verify is the other Available training table is Displayed");


        }
        [Test, Order(14)]
        public void P20_1_b14_Curriculums_Containing_a_Document_27154()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27154");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In Button");

            CommonSection.CreteNewCurriculumn(curriculumTitle + "TC27154");
            _test.Log(Status.Info, "Create a Curriculum");

            AdminContentDetailsPage.ClickEditandAddCurriculumContent("TC27154", DocumentTitle + "TC27154");
            _test.Log(Status.Info, "Click edit Curriculum content and Add Content");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In Button");

            CommonSection.SearchCatalog(curriculumTitle + "TC27154");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculumTitle + "TC27154");
            _test.Log(Status.Info, "Click on search result from catalog");
            ContentDetailsPage.Click_Enroll();
            _test.Log(Status.Info, "Click Enroll to enroll in Curriculum");
            Assert.IsTrue(ContentDetailsPage.IsCurriculumContentBlockDisplayed());
            _test.Log(Status.Pass, "Verify Curriculum Block is Dispalyed");
            ContentDetailsPage.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Curriculum Content Block");
            Assert.IsTrue(ContentDetailsPage.IsCurriculumContentDisplayed());
            _test.Log(Status.Pass, "Verify Curriculum Content is Displayed");
            Assert.IsTrue(ContentDetailsPage.IsCurriculumContentStatusDisplayed());
            _test.Log(Status.Pass, "Verify Curriculum Status is Displayed");


        }

        [Test, Order(15)]
        public void P20_1_b15_Bundles_Containing_a_Document_27196()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27196");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In Button");



            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Create Bundle");
            BundlesPage.EnterTitle(bundleTitle + "TC27196");
            _test.Log(Status.Info, "Create bundle course");
            BundlesPage.BundleType("Content Bundle");
            _test.Log(Status.Info, "Select Bundle Type");
            BundlesPage.BundleCostType();
            _test.Log(Status.Info, "Select Bundle Type");
            BundlesPage.ClickCreate();
            _test.Log(Status.Info, "Click on Create Bundle");
            BundlesPage.addContentIntoBundle(DocumentTitle + "TC27196");
            _test.Log(Status.Info, "Add Content in Bundle");
            BundlesPage.checkIn();
            _test.Log(Status.Info, "Click on CheckIn Button");
            CommonSection.SearchCatalog(bundleTitle + "TC27196");
            _test.Log(Status.Info, "Make a Search of Bundle course");
            SearchResultsPage.ClickCourseTitle(bundleTitle + "TC27196");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isBundlesCostTypeDisplayed());
            _test.Log(Status.Pass, "Verify Bundle Cost Type is Displayed");
            ContentDetailsPage.ClickOnContent();
            _test.Log(Status.Info, "Click on Content");
            Assert.IsTrue(ContentDetailsPage.isSuggestedBundlesDisplayed());
            _test.Log(Status.Pass, "Verify Suggested Bundle is Displayed");
            Assert.IsTrue(ContentDetailsPage.isBundlesTitleDisplayed());
            _test.Log(Status.Pass, "Verify Bundle Title is Displayed");
            Assert.IsTrue(ContentDetailsPage.isBundlesCostDisplayed());
            _test.Log(Status.Pass, "Verify bundle Cost is Displayed");

        }

        [Test, Order(16)]
        public void P20_1_b16_Certifications_Containing_a_Document_27200()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27200");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In Button");

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click on Certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC27200");
            _test.Log(Status.Info, "Create a Certification course");
            CertificationPage.SelectDropDown.CompletionCriteriaAs("Content is completed in ANY order (Non-Linear) (Non-Linear)");
            _test.Log(Status.Info, "Select Completion Criteria ");
            CertificationPage.Radiobutton.SelectCertificationexpireAs("No");
            _test.Log(Status.Info, "Select Certification expiry");
            CertificationPage.Radiobutton.IncludePastContentCompletionAs("No");
            _test.Log(Status.Info, "Select option Includes Past Content Completion");
            CertificationPage.Radiobutton.SelectAllowReCertificationAs("Yes");
            _test.Log(Status.Info, "Select Allow Re-Certification");
            CertificationPage.Radiobutton.CertificationCostTypeAs("");
            _test.Log(Status.Info, "Select Certification Cost Type");
            CertificationPage.CreateCertification();
            _test.Log(Status.Info, "Click on Create Button");
            //CertificationPage.VerifySuccessMessageText("The item was created.");
            CertificationPage.AddContentInCertification("AddingWaitlistMembers_Bug");
            _test.Log(Status.Info, "Add Content in Certification");
            CertificationPage.CheckIn();
            _test.Log(Status.Info, "Click on CheckIn");
            CommonSection.SearchCatalog(CertificatrTitle + "TC27200");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickCourseTitle(bundleTitle + "TC27200");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue((Driver.comparePartialString("You do not have a certification status for this certification.", ContentDetailsPage.getInformativeMessage())));
            _test.Log(Status.Pass, "Verify information is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationTypeDisplayed());
            _test.Log(Status.Pass, "Verify Certification Type is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationCostTypeDisplayed());
            _test.Log(Status.Pass, "Verify Certification Cost Type is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationPeriodDisplayed());
            _test.Log(Status.Pass, "Verify Certification Period is Displayed");
            Assert.IsTrue(ContentDetailsPage.isAccessItemButtonDisplayed());
            _test.Log(Status.Pass, "Verify Access Button is Displayed");
            Assert.IsTrue(ContentDetailsPage.isObjectivesBlockDisplayed());
            _test.Log(Status.Pass, "Verify Objective Block is Displayed");
            Assert.IsTrue(ContentDetailsPage.isAlternateOptionsBlockDisplayed());
            _test.Log(Status.Pass, "Verify Alternate Option Block is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCertificationContentBlockDisplayed());
            _test.Log(Status.Pass, "Verify Certification Content Block is Displayed");
            ContentDetailsPage.ClickAccessItem();
            _test.Log(Status.Info, "Click on Access Item");
            Assert.IsTrue((Driver.comparePartialString(" You first accessed this item on 1/25/2019. ", ContentDetailsPage.getAccessDateMessage())));
            _test.Log(Status.Pass, "Verify Certification Content Block is Displayed");
            ContentDetailsPage.ClickCertificationClassroom();
            _test.Log(Status.Pass, "click on Certification Classroom");
            Assert.IsTrue((Driver.comparePartialString("You are enrolled in a current section for this classroom course.", ContentDetailsPage.getCertificationEnrolledMessage())));
            _test.Log(Status.Pass, "Verify Information is Displayed");
            Assert.IsTrue(Driver.isSuggestedCertificationDisplayed());
            _test.Log(Status.Pass, "Verify Suggested Certification is displayed");
            Assert.IsTrue(Driver.SuggestedCertifications.isCertificationTitleDisplayed());
            _test.Log(Status.Pass, "Verify Certification Title is Displayed");
            Assert.IsTrue(Driver.SuggestedCertifications.isCertificationCostDisplayed());
            _test.Log(Status.Pass, "Verify Certification Cost is Displayed");

        }

        [Test, Order(17)]
        public void b17_Add_Document_to_Cart_26205()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC26205");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Click edit Cost and Add Cost to document");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Check In Button");
            AdminContentDetailsPage.ClickCheckInbutton();

            _test.Log(Status.Info, "Click Check-In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on view as learner");

            ContentDetailsPage.ClickAddtoCart();
            _test.Log(Status.Info, "Click on Add to cart");

            Assert.IsTrue(Driver.comparePartialString("The item was added to the cart.", ContentDetailsPage.AddToCartSuccessMessage()));
            _test.Log(Status.Pass, "Verify the Content added to cart message");


        }


        [Test, Order(18)]//dependent on TC26025
        public void b18_View_Document_Purchase_Details_26379()
        {
            ContentDetailsPage.ClickShoppingCart();
            _test.Log(Status.Info, "Click on Shopping Cart");
            ShoppingCartPage.Checkout();
            _test.Log(Status.Info, "Click Checkout");
            CheckoutPage.UseThisPaymentMethod();
            _test.Log(Status.Info, "Click Use This Payment Method");
            CheckoutPage.AcceptTermsandCondition();
            _test.Log(Status.Info, "Click Accept Terms and Condition");
            CheckoutPage.PlaceOrder();
            _test.Log(Status.Info, "Click Place Order");
            Assert.IsTrue(Driver.comparePartialString("Thank you for your order! Your order has been successfully processed. You will receive an email confirmation shortly.", ContentDetailsPage.OrderReciptSuccessMessage()));
            _test.Log(Status.Pass, "Verify Order Processed Success Message");
            OrderReceiptPage.ViewOrder();
            _test.Log(Status.Pass, "Click View Order");
            OrderPage.ClickOrderedItemViewDetails(DocumentTitle + "TC26205");
            _test.Log(Status.Pass, "Click View Details for Purchased Content");
            Assert.IsTrue(OrderDetailsPage.VerifyPurchasedContent(DocumentTitle + "TC26205"));
            _test.Log(Status.Pass, "verify Puschased Content");





        }
        [Test, Order(19)]
        public void P20_1_b19_Subscriptions_Containing_a_Document_27179()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27179");

            _test.Log(Status.Info, "Create a Document");
            string SubscriptionContent = AdminContentDetailsPage.CreatedContent();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In Button");
            CommonSection.CreateLink.Subscription();
            _test.Log(Status.Info, "Click Subscription");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC27179").SubscriptionType("DynamicDate").Create();
            _test.Log(Status.Info, "Create subscription");
            AdminContentDetailsPage.ClickEditandAddSubscriptionContent(DocumentTitle + "TC27179");
            _test.Log(Status.Info, "Click Edit and Add Subscription Content");
            AdminContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog(SubscriptionsTitle + "TC27179");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickCourseTitle(SubscriptionsTitle + "TC27179");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.IsSubscriptionBlockDispalyed(SubscriptionContent));
            _test.Log(Status.Pass, "Verify Added Document is Displayed in Subscription Block ");
            Assert.IsTrue(ContentDetailsPage.IsTitleDisplayed());
            _test.Log(Status.Pass, "Verify Added Document is Displayed in Subscription Block ");
            Assert.IsTrue(ContentDetailsPage.IsTypeDisplayed());
            _test.Log(Status.Pass, "Verify Added Document is Displayed in Subscription Block ");
            Assert.IsTrue(ContentDetailsPage.IsCostDisplayed());
            _test.Log(Status.Pass, "Verify Added Document is Displayed in Subscription Block ");

        }

        [Test, Order(20)]
        public void b20_Edit_Content_Document_27999()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27999");
            _test.Log(Status.Info, "Create a Document");
            CommonSection.SearchCatalog(DocumentTitle + "TC27999");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC27999");
            _test.Log(Status.Info, "Click on Course Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content");
            Assert.IsTrue(AdminContentDetailsPage.VerifyCheckout());
            _test.Log(Status.Pass, "verify Checkout Button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of siteadmin account");

            LoginPage.LoginAs("ak_contentmanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Content manager Account");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27999");
            _test.Log(Status.Info, "Create a Document");
            CommonSection.SearchCatalog(DocumentTitle + "TC27999");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC27999");
            _test.Log(Status.Info, "Click on Course Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content");
            Assert.IsTrue(AdminContentDetailsPage.VerifyCheckout());
            _test.Log(Status.Pass, "verify Checkout Button");




        }
        [Test, Order(21)]
        public void b21_Rate_Document_26208()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "26208");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on view as learner");
            Assert.IsFalse(ContentDetailsPage.IsRateAccordianDisplayed());
            _test.Log(Status.Pass, "Verify Rate Accordian is not Dispayed");
            ContentDetailsPage.OpenItem.CompleteContentDocument();
            _test.Log(Status.Pass, "Launch the content");

            ContentDetailsPage.CompleteLunchedCourse();
            _test.Log(Status.Info, "Complete content Document");
            Assert.IsTrue(ContentDetailsPage.IsRateAccordianDisplayed());
            _test.Log(Status.Pass, "Verify Rate Accordian is Dispayed");
            ContentDetailsPage.Rate("4 Stars", "Good", "Good Rating");
            _test.Log(Status.Info, "Verify Rate Accordian is Dispayed");
            Assert.IsTrue(ContentDetailsPage.IsDeleteRatingDisplayed());
            _test.Log(Status.Pass, "Verify Rate Accordian is Dispayed");



        }
        [Test, Order(22)]
        public void b22_Request_Access_to_Document_with_cost_27018()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC26018");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Document");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as Learner");

            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner Account");
            CommonSection.SearchCatalog(DocumentTitle + "TC26018");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC26018");
            _test.Log(Status.Info, "Click on Course Title");
            ContentDetailsPage.ClickRequestAccess();
            _test.Log(Status.Info, "Click Access Request");
            Assert.IsFalse(ContentDetailsPage.isAddToCartButtonDisplayed());
            _test.Log(Status.Pass, "Add to Cart Button is Displayed");

            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");
            CommonSection.Manage.ApprovalRequests();
            _test.Log(Status.Info, "Click on Approval Request ");
            ApprovalRequestsPage.PendingMyApproval.Approve(DocumentTitle + "TC26018","Request Accepted");
            _test.Log(Status.Info, "Approve request");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner Account");
            CommonSection.SearchCatalog(DocumentTitle + "TC26018");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC26018");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());
            _test.Log(Status.Pass, "Add to Cart Button is Displayed");

        }
    }
}