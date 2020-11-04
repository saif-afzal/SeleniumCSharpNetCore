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
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1RegressionTests8 : TestBase
    {
        string browserstr = string.Empty;
        public P1RegressionTests8(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        bool res1 = false;

        string LevelName = "Level" + Meridian_Common.globalnum;
        string OrganizationTitle = "Organization" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        bool ArchivedScale = false;
        string documenttitle = "Doc" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string testtitle = "Test" + Meridian_Common.globalnum;       
        static string today = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
        string markAsComplete = $"This item was marked as complete on " + today + ".";
        string DocumentTitle = "Document" + Meridian_Common.globalnum;
        public string version="1.0";




        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }
        public bool chktest = false;

      
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
     

        [Test, Order(08), Category("AutomatedP11")]
        public void z01_Create_New_Account_Self_Registration_8585()
        {
            CommonSection.Logout();
            AccountCreation CreateAccount = new AccountCreation(driver);
            CommonSection.Logout();
            LoginPage.ClickSignup();
            _test.Log(Status.Info, "Click Sign up link on Login Page");

            CreateNewAccountobj.PopulateCreateNewUserLinkOuter(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            _test.Log(Status.Info, "Click Create button after fill all mandetory fields");
            HomePage.clickGetStarted();
            _test.Log(Status.Info, "Click On lets get Started button");
            Assert.IsTrue(HomePage.Title == "Home");
            _test.Log(Status.Pass, "User Successfully Logged in");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");

        }
       
        [Test, Order(01), Category("AutomatedP11")]
        public void P20_1_z02_View_Transcript_20487()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            StringAssert.AreEqualIgnoringCase("Transcript", TranscriptPage.pagetitle());
            _test.Log(Status.Pass, "Verify page title is Transcript");
            Assert.IsTrue(TranscriptPage.AllComponetsdisplay());
            _test.Log(Status.Pass, "Verify all componets of Transcript page is display");
            //TranscriptPage.AllMyTrainingPage.ClickSaveasPDF();
            //_test.Log(Status.Info, "Click on Save as PDF button");
            //Driver.Instance.SwitchWindow("Untitled - Google Chrome");
            //Assert.IsTrue(TranscriptAllMyTrainingPrintPage.Title.EndsWith("AllMyTrainingPrint.aspx"));
            //TranscriptAllMyTrainingPrintPage
           // Driver.focusParentWindow();
           // _test.Log(Status.Info, "CLose window meridian global reporting page");
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from learner");
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Admin");


        }
        
        [Test, Order(02)]//Document
        public void P20_1_z03_Document_Enable_Versioning_7480()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC7480");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.EditVersioning_Enabled("1.0");
            _test.Log(Status.Info, "Enable versioning by adding values");
            Assert.IsTrue(Driver.comparePartialString("Versioning is now enabled for this item; however," +
                " information cannot be edited for this version because either users had progress against it before versioning was enabled, " +
                "or the effective date has been reached.", VersionsPage.VerifyVersionEnableMessage()));
            _test.Log(Status.Pass, "Verify version enabling message");

            Assert.IsTrue(Driver.comparePartialString(" This information cannot be edited for this version because either users" +
                " had progress against it before versioning was enabled, or the effective date has been reached.", VersionsPage.VerifyVersionAlertMessage()));
            _test.Log(Status.Pass, "Verify version Locking message");

            //string version = VersionsPage.VersionNo();
            VersionsPage.Click_Back();

            Assert.IsTrue(AdminContentDetailsPage.VerifyVersion(version));
            _test.Log(Status.Pass, "Verify version");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");

        }
        [Test, Order(03)]
        public void P20_1_z04_Document_Add_Version_7481()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            TrainingPage.ManageContentPortlet.SearchForContent(DocumentTitle + "TC7480");
            _test.Log(Status.Info, "Search for Content");
            ManageContentPage.filtersearch.Searchfortext(DocumentTitle + "TC7480");
            ManageContentPage.Clickflitersearch();
            ManageContentPage.ClickContentTitle(DocumentTitle + "TC7480");
            _test.Log(Status.Info, "Click on Coure title ");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            AdminContentDetailsPage.AddVersion();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            Assert.IsTrue(Driver.comparePartialString(" The new version was added for the content item.", AdminContentDetailsPage.VerifyNewVersionSuccessMessage()));
            _test.Log(Status.Pass, "Verify New Version Success Message");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddedVersionsInDropDownlist());
            _test.Log(Status.Pass, "Verify New Version Success Message");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyDeleteVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyManageVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");




        }
        [Test, Order(04)]
        public void P20_1_z05_General_Course_Enable_Versioning_7476()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC7476");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.EditVersioning_Enabled("1.0");
            _test.Log(Status.Info, "Enable versioning by adding values");
            Assert.IsTrue(Driver.comparePartialString("Versioning is now enabled for this item; however," +
                " information cannot be edited for this version because either users had progress against it before versioning was enabled, " +
                "or the effective date has been reached.", VersionsPage.VerifyVersionEnableMessage()));
            _test.Log(Status.Pass, "Verify version enabling message");

            Assert.IsTrue(Driver.comparePartialString(" This information cannot be edited for this version because either users" +
                " had progress against it before versioning was enabled, or the effective date has been reached.", VersionsPage.VerifyVersionAlertMessage()));
            _test.Log(Status.Pass, "Verify version Locking message");

            // string version = VersionsPage.VersionNo();
            VersionsPage.Click_Back();

            Assert.IsTrue(AdminContentDetailsPage.VerifyVersion(version));
            _test.Log(Status.Pass, "Verify version");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");


        }
        [Test, Order(05)]
        public void P20_1_z06_General_Course_Add_Version_7477()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            TrainingPage.ManageContentPortlet.SearchForContent(generalcoursetitle + "TC7476");
            _test.Log(Status.Info, "Search for Content");
            ManageContentPage.ClickContentTitle(generalcoursetitle + "TC7476");
            _test.Log(Status.Info, "Click on Coure title ");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            AdminContentDetailsPage.AddVersion();
            _test.Log(Status.Info, "Verify Add version Button is Displayed");
            Assert.IsTrue(Driver.comparePartialString(" The new version was added for the content item.", AdminContentDetailsPage.VerifyNewVersionSuccessMessage()));
            _test.Log(Status.Pass, "Verify New Version Success Message");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddedVersionsInDropDownlist());
            _test.Log(Status.Pass, "Verify New Version Success Message");
            Assert.IsTrue(AdminContentDetailsPage.VerifyAddVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyDeleteVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");
            Assert.IsTrue(AdminContentDetailsPage.VerifyManageVersionButton());
            _test.Log(Status.Pass, "Verify Add version Button is Displayed");

        }
        [Test, Order(06), Category("AutomatedP11")]
        public void P20_1_z07_My_Training_Progress_Report_24843()
        {
            //Assert.IsTrue(true);  //as it is running as part of smoke test.
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            ReportsConsolePage.SearchText("My");
            _test.Log(Status.Info, "Searched My");
            Assert.IsTrue(ReportsConsolePage.DisplayResult > 1);//checks results display more than 1
            ReportsConsolePage.ClickMyTrainingProgress();
            _test.Log(Status.Info, "Clicked My Training Progress");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            // Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "Clicked go button having details selected and opens details page");
            //Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));//retrieves the text from details tab
            DetailsPage.ClickCloseWindowlink();
            _test.Log(Status.Info, "Details page closes");
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));
            //   MyTrainingProgressPDFPage.ClickBrowsertabX();
            //   Assert.IsTrue(DetailsPage.Displays>1);
            //MeridianGlobalReportingPage.CloseWindow();
            Assert.IsTrue(Driver.focusParentWindow());
            _test.Log(Status.Info, "Closes pdf window");
            Assert.IsTrue(RunReportPage.Title == "Run Report");
            // Assert.IsTrue(Driver.focusParentWindow());
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "open reports from KI");
            ReportsPage.MyTrainingProgress.ClickRunReport();
            _test.Log(Status.Info, "opens run report page from KI");
            ReportsPage.ReportCriteriaModal.ClickRunReport();
            _test.Log(Status.Info, "click run report from KI");
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "click the go button having details option displayed");
            string restext = DetailsPage.CheckDetailsTabText;
            StringAssert.EndsWith("Details", restext);
            DetailsPage.ClickCloseWindowlink();
            _test.Log(Status.Info, "closed the details page ");
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Reports");
        }
        //[Test, Order(07), Category("AutomatedP11")]
        public void z08_Add_Items_to_Public_Catalog_Cart_and_Checkout_23474()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from User");
            LoginPage.ClickBrowsePublicCatalogLink();
           // Driver.Instance.Navigate().GoToUrl("https://prdct-mg-19-1.mksi-lms.net/Public/TrainingCatalog.aspx");
            _test.Log(Status.Info, "Navigate to public catalog URL");
            SearchResultsPage.ClickCourseTitle("CRCTitle1910293729TC27023_NewEnroll");
            _test.Log(Status.Info, "Click on first course display on Search result Pagr");
            ContentDetailsPage.ClickAddtoCart();
            _test.Log(Status.Info, "Click on Add to Cart button");
            Assert.IsTrue(ContentDetailsPage.getFeedbackMessage("The item was added to the cart."));
            CommonSection.ClickShoppingCart();
            _test.Log(Status.Info, "Click on Shopping Cart");
            //ShoppingCarts.completePurchaseProcess();
            ShoppingCartPage.ClickCheckout_public();
            ShoppingCartPage.CheckOutModal.Login();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            Assert.IsTrue(ShoppingCartPage.Title("Shopping Cart"));
            ShoppingCartPage.CompletePurchaseProcess();
            OrderPage.Click_PurchasedContentTitle();
            Assert.IsTrue(ContentDetailsPage.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Verify Purchased item Accessed to User");

        }

    }

}
