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
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    ////   [Parallelizable(ParallelScope.Fixtures)]
    public class P1_Catalog_PublicversionsofUpdatedCatalogPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_PublicversionsofUpdatedCatalogPagesTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }


        string AICCCourseTitle = "AICC" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        string CertificatrTitle = "Certification" + Meridian_Common.globalnum;
        string TestTitle = "Test" + Meridian_Common.globalnum;
        string GeneralCourseTitle= "GC" + Meridian_Common.globalnum;
        bool tc_60477;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
      
        [Test, Order(1)]
        public void tc_60459_Public_catalog_banner_actions_for_AICC()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC60459");
            _test.Log(Status.Info, "Create a general Course for Prerequisite");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckIn();
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC60459");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_Prerequisites(generalcoursetitle + "TC60459");
            _test.Log(Status.Pass, "Click edit Prerequisite and add Prerequisite");          
            PrerequisitesPage.Click_BreadCrumb();
            _test.Log(Status.Pass, "Click breadcrumbs");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            ContentDetailsPage.Click_editContentSharing();
            ContentSharingPage.PublishtoPublishcatalog();
             ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");

            CommonSection.Logout();
            LoginPage.ClickBrowsePublicCatalogLink();
            CommonSection.SearchCatalog(AICCCourseTitle + "TC60459");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC60459");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "TC60459"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
        }
        [Test, Order(2)]
        public void tc_61893_Create_New_Account_Public_Catalog_Shopping_Cart()
        {
            CommonSection.SearchCatalog(AICCCourseTitle + "TC60459");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC60459");            
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "TC60459"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            ContentDetailsPage.OverviewTab.click_AddtoCart();
            CommonSection.ClickShoppingCart();
            ShoppingCartPage.ClickCheckout_public();
            Assert.IsTrue(Driver.checkTitle("Login"));
            _test.Log(Status.Pass, "Verify page redirect to Login page");
            //account creation handle using 61891
        }
        [Test, Order(3)]
        public void tc_60487_Public_catalog_banner_actions_for_Documents()
        {
            ContentDetailsPage.clickReturningUserLogin();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC60487");
            _test.Log(Status.Info, "Create a Document");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_Prerequisites(generalcoursetitle + "TC60459");
            _test.Log(Status.Pass, "Click edit Prerequisite and add Prerequisite");
            PrerequisitesPage.Click_BreadCrumb();
            _test.Log(Status.Pass, "Click breadcrumbs");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            ContentDetailsPage.Click_editContentSharing();
            ContentSharingPage.PublishtoPublishcatalog();
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");

            CommonSection.Logout();
            LoginPage.ClickBrowsePublicCatalogLink();
            CommonSection.SearchCatalog(DocumentTitle + "TC60487");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60487");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(DocumentTitle + "TC60487"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
        }
        [Test, Order(4)]
        public void tc_60488_Public_catalog_banner_actions_for_Certification()
        {
            ContentDetailsPage.clickReturningUserLogin();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60488");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            CertificationPage.FillTitle(CertificatrTitle + "_TC60488");            
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_Prerequisites(generalcoursetitle + "TC60459");
            _test.Log(Status.Pass, "Click edit Prerequisite and add Prerequisite");
            PrerequisitesPage.Click_BreadCrumb();
            _test.Log(Status.Pass, "Click breadcrumbs");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC60488" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            ContentDetailsPage.Click_editContentSharing();
            ContentSharingPage.PublishtoPublishcatalog();
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");

            CommonSection.Logout();
            LoginPage.ClickBrowsePublicCatalogLink();
            CommonSection.SearchCatalog(CertificatrTitle + "_TC60488");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60488");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60488"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            Assert.IsTrue(ContentDetailsPage.isContentTabdisplay());
            tc_60477 = true;
        }
        [Test, Order(5)]
        public void tc_60477_Verify_the_Content_tab_at_Public_catalog()
        {
            Assert.IsTrue(tc_60477);
        }
        [Test, Order(6)]
        public void tc_60489_Public_catalog_banner_actions_for_Test()
        {
            ContentDetailsPage.clickReturningUserLogin();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC60489");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.addPrerequisitetotest();
            TestwizardPage.UploadImagetoTest();
            TestwizardPage.PublishtoPublishcatalog();
            TestwizardPage.checkin();

            CommonSection.Logout();
            LoginPage.ClickBrowsePublicCatalogLink();
            CommonSection.SearchCatalog(TestTitle + "_TC60489");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60489");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(TestTitle + "_TC60489"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
        }
        [Test, Order(7)]
        public void tc_62138_SEO_Friendly_URLs_for_Public_Catalog()
        {
            CommonSection.SearchCatalog(TestTitle + "_TC60489");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60489");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(TestTitle + "_TC60489"));
            Assert.IsTrue(ContentDetailsPage.isURLisSEOFriendly(TestTitle + "_TC60489"));
            _test.Log(Status.Pass, "Verify URL ends with content tile");
        }
        [Test, Order(8)]
        public void tc_61891_Create_New_Account_Public_Catalog_Workflow()
        {
            Assert.IsTrue(CommonSection.isCreateAccountmenudisplay());
            _test.Log(Status.Pass, "Verify Create Account menu is visible in public cataloh page");
            CommonSection.CLickCreateAccount();
            _test.Log(Status.Info, "Click on create account menu");
            Assert.IsTrue(CreateAccountPage.checkTilte("Create Account"));
            _test.Log(Status.Pass, "Verify Create Account Page is Opened");
            string id = CreateAccountPage.CreateNewUserLinkOuter(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            Assert.IsTrue(CreateAccountPage.isNextpagedisplay());
            Assert.IsFalse(CreateAccountPage.isSelectOrgdisplay());
            _test.Log(Status.Pass, "Verify select organization is not display");
            CreateAccountPage.SelectPerPageRec();
            CreateAccountPage.clickCreate();
            Assert.IsTrue(CreateAccountPage.isSuccessmessagedisplay());
            _test.Log(Status.Pass, "Verify is account created successfully");
            
        }

    }
}
