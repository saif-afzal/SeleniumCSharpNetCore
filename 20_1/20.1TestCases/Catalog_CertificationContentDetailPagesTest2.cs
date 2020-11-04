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
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1_Catalog_CertificationContentDetailPagesTest2 : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_CertificationContentDetailPagesTest2(string browser)
             : base(browser)
        {
            browserstr = browser;


            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string documenttitle = "Document" + Meridian_Common.globalnum;
        string AICCCourseTitle= "AICC" + Meridian_Common.globalnum;
        string scormtitle = "SCROM" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle = "TA" + Meridian_Common.globalnum;
        string CertificatrTitle = "Certification" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        string TestTitle = "Test" + Meridian_Common.globalnum;
        bool addtocontainer;
        bool TC61487;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }        
        [Test, Order(1)]
        public void tc_60999_AS_Learner_Verify_override_Behavior_Access_Periods_for_Online_Courses_in_a_Certification_For_Scrom()
        {
            CommonSection.CreteNewScorm(scormtitle + "_TC60999");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");
            DocumentPage.ClickButton_CheckOut();
            _test.Log(Status.Info, "Click Check-out");
            ContentDetailsPage.Edit_AddAccessPeriod("15");            
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60999");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + scormtitle + "_TC60999" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + scormtitle + "_TC60999" + '"');
            _test.Log(Status.Pass, "Search the SCROM Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60999");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflagMessage("Access ends 15 day(s) after enrollment"));
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60999" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60999" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60999");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(scormtitle + "_TC60999");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(scormtitle + "_TC60999"));
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");            
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60999");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60999"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(scormtitle + "_TC60999");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + scormtitle + "_TC60999" + '"');
            _test.Log(Status.Pass, "Search the SCROM Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60999");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Virefy start button should display on banner");
        }
        [Test, Order(2)]
        public void tc_61000_AS_Learner_Verify_override_Behavior_Access_Periods_for_Online_Courses_in_a_Certification_For_AICC()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            CreateAICCPage.Title(AICCCourseTitle + "_TC61000");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New AICC is Created");
            ContentDetailsPage.Edit_AddAccessPeriod("15");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61000");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + AICCCourseTitle + "_TC61000" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + AICCCourseTitle + "_TC61000" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "_TC61000");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflagMessage("Access ends 15 day(s) after enrollment"));
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61000" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61000" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61000");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(AICCCourseTitle + "_TC61000");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "_TC61000"));
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61000");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61000"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(AICCCourseTitle + "_TC61000");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + AICCCourseTitle + "_TC61000" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "_TC61000");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Virefy start button should display on banner");
        }
        [Test, Order(3)]
        public void tc_61002_AS_Learner_Verify_override_Behavior_Access_Periods_for_Online_Courses_in_a_Certification_For_General()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC61002");
            _test.Log(Status.Info, "Create a new General Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New AICC is Created");
            ContentDetailsPage.Edit_AddAccessPeriod("15");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61002");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "TC61002" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "TC61002" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "TC61002");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflagMessage("Access ends 15 day(s) after enrollment"));
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61002" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61002" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61002");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(GeneralCourseTitle + "TC61002");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "TC61002"));
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61002");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61002"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "TC61002");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "TC61002" + '"');
            _test.Log(Status.Pass, "Search the General Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "TC61002");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Virefy start button should display on banner");
        }
        [Test, Order(4)]
        public void tc_61003_AS_Learner_Verify_override_Behavior_Access_Periods_for_Online_Courses_in_a_Certification_For_Document()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC61003");
            _test.Log(Status.Info, "Create a new Document");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_AddAccessPeriod("15");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61003");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + documenttitle + "TC61003" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + documenttitle + "TC61003" + '"');
            _test.Log(Status.Pass, "Search the Document Course");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC61003");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflagMessage("Access ends 15 day(s) after enrollment"));
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61003" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61003" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61003");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(documenttitle + "TC61003");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(documenttitle + "TC61003"));
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61003");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61003"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(documenttitle + "TC61003");
            _test.Log(Status.Pass, "Start Content in certification content");

            CommonSection.SearchCatalog('"' + documenttitle + "TC61003" + '"');
            _test.Log(Status.Pass, "Search the Document Course");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC61003");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Virefy Access period flag display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            _test.Log(Status.Pass, "Virefy start button should display on banner");
        }
       
        [Test, Order(5)]
        public void tc_60976_As_Learner_verify_the_Override_Behavior_Cost_Access_Keys_for_Online_Courses_in_a_Certification_Tests()
        {
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "TC60976");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.addCosttoTest("10");            
            TestwizardPage.checkin();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60976");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + TestTitle + "TC60976" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + TestTitle + "TC60976" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(TestTitle + "TC60976");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should display");           
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60976" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60976" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60976");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(TestTitle + "TC60976");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");           
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeTestButtonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays as it override");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "TC60976");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "TC60976"));
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(TestTitle + "TC60976");
            _test.Log(Status.Pass, "Enroll in certification content");
            ContentDetailsPage.ContentBanner.CloseOpenedTestwindow();

            CommonSection.SearchCatalog('"' + TestTitle + "TC60976" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(TestTitle + "TC60976");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");           
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            _test.Log(Status.Pass, "iVerify Countinue Button Should displays");
        }
        [Test, Order(6)]
        public void tc_60977_AS_Learner_Verify_the_override_Behavior_Cost_Access_Keys_for_Online_Courses_in_a_Certification_Document()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC60977");
            _test.Log(Status.Info, "Creating New Document");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60977");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + documenttitle + "TC60977" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + documenttitle + "TC60977" + '"');
            _test.Log(Status.Pass, "Search the Document");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC60977");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should display");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60977" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60977" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60977");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(documenttitle + "TC60977");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60977");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60977"));
            ContentDetailsPage.Click_ContentTab();      
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(documenttitle + "TC60977");
            _test.Log(Status.Pass, "Start in certification content");

            CommonSection.SearchCatalog('"' + documenttitle + "TC60977" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC60977");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            _test.Log(Status.Pass, "Start Button Should displays");
        }
        [Test, Order(7)]
        public void tc_60937_As_a_Learner_verify_Override_Behavior_Cost_Access_Key_for_Classrooms_in_a_Certification()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC60937");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            _test.Log(Status.Info, "Enable Accees key");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
           
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60937");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addClassroomsectionIntoCertificate('"' + classroomcoursetitle + "_TC60937" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC60937" + '"');
            _test.Log(Status.Pass, "Search the Classroom");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC60937");
            ContentDetailsPage.ContentBanner.clickViewScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsAddtoCartbuttonDisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should display in schedule tab");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should display in schecule tab");
            Assert.IsFalse(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60937" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60937" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60937");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(classroomcoursetitle + "_TC60937");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(classroomcoursetitle + "_TC60937"));
            ContentDetailsPage.ContentBanner.clickViewScheduleButton();
            Assert.IsFalse(ContentDetailsPage.ScheduleTab.SectionPortlet.IsAddtoCartbuttonDisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display in schedule tab");
            Assert.IsFalse(ContentDetailsPage.ScheduleTab.SectionPortlet.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display in schecule tab");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isSectionCostdisplay());
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();
            _test.Log(Status.Info, "Enroll into classroom");
                       
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC60937" + '"');
            _test.Log(Status.Info, "Search the classroom Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC60937");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.ContentBanner.clickViewScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsAddtoCartbuttonDisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should display in schedule tab");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should display in schecule tab");
            Assert.IsFalse(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());
            TC61487 = true;
        }
        [Test, Order(8)]
        public void tc_61487_As_a_Learner_verify_Override_Behavior_Cost_for_Classrooms_in_a_Certification()
        {
            Assert.IsTrue(TC61487);
        }
        [Test, Order(9)]
        public void tc_61068_Permission_Override_Behavior_Documents()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC61068");
            _test.Log(Status.Info, "Creating New Document");
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.SetPermissionforonlyAdmin();
            _test.Log(Status.Info, "Permission set only for admin");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC61068");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + documenttitle + "TC61068" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + documenttitle + "TC61068" + '"');
            _test.Log(Status.Info, "Search the Document Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(documenttitle + "TC61068"));            
            _test.Log(Status.Pass, "Verify content cant be search");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC61068" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC61068" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC61068");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(documenttitle + "TC61068");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(documenttitle + "TC61068"));
            _test.Log(Status.Pass, "Verify docuemnt can ve access through certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Open Item Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "TC61068");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "TC61068"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(documenttitle + "TC61068");

            CommonSection.SearchCatalog('"' + documenttitle + "TC61068" + '"');
            _test.Log(Status.Pass, "Search the Document Course");            
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(documenttitle + "TC61068"));
            _test.Log(Status.Pass, "Verify content should be searched after started same content from certification");
        }
        [Test, Order(10)]
        public void tc_61063_Permission_Override_Behavior_SCROM()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewScorm(scormtitle + "_TC61063");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");
            DocumentPage.ClickButton_CheckOut();
            _test.Log(Status.Info, "Click Check-out");
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.SetPermissionforonlyAdmin();
            _test.Log(Status.Info, "Permission set only for admin");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61063");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + scormtitle + "_TC61063" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + scormtitle + "_TC61063" + '"');
            _test.Log(Status.Info, "Search the SCROm Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(scormtitle + "_TC61063"));
            _test.Log(Status.Pass, "Verify content cant be search");
           
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61063" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61063" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61063");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(scormtitle + "_TC61063");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(scormtitle + "_TC61063"));
            _test.Log(Status.Pass, "Virefy scrom course is display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61063");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61063"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(scormtitle + "_TC61063");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + scormtitle + "_TC61063" + '"');
            _test.Log(Status.Pass, "Search the SCROM Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(scormtitle + "_TC61063"));
            _test.Log(Status.Pass, "Verify content should be searched after started same content from certification");

        }
        [Test, Order(11)]
        public void tc_61064_Permission_Override_Behavior_AICC()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();           
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            CreateAICCPage.Title(AICCCourseTitle + "_TC61064");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");            
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.SetPermissionforonlyAdmin();
            _test.Log(Status.Info, "Permission set only for admin");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61064");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + AICCCourseTitle + "_TC61064" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + AICCCourseTitle + "_TC61064" + '"');
            _test.Log(Status.Info, "Search the AICC Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(AICCCourseTitle + "_TC61064"));
            _test.Log(Status.Pass, "Verify content cant be search");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61064" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61064" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61064");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(AICCCourseTitle + "_TC61064");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "_TC61064"));
            _test.Log(Status.Pass, "Virefy scrom course is display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61064");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61064"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(AICCCourseTitle + "_TC61064");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + AICCCourseTitle + "_TC61064" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(AICCCourseTitle + "_TC61064"));
            _test.Log(Status.Pass, "Verify content should be searched after started same content from certification");

        }
        [Test, Order(12)]
        public void tc_61065_Permission_Override_Behavior_General()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC61065");
            _test.Log(Status.Info, "Creating a new general course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify Course is Created");            
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.SetPermissionforonlyAdmin();
            _test.Log(Status.Info, "Permission set only for admin");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61065");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC61065" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "_TC61065" + '"');
            _test.Log(Status.Info, "Search the general Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(GeneralCourseTitle + "_TC61065"));
            _test.Log(Status.Pass, "Verify content cant be search");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61065" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61065" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61065");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(GeneralCourseTitle + "_TC61065");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "_TC61065"));
            _test.Log(Status.Pass, "Virefy general course is display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61065");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61065"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC61065");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "_TC61065" + '"');
            _test.Log(Status.Pass, "Search the general Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(GeneralCourseTitle + "_TC61065"));
            _test.Log(Status.Pass, "Verify content should be searched after started same content from certification");

        }
        [Test, Order(13)]
        public void tc_61066_Permission_Override_Behavior_Survey()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Survey();
            SurveysPage.CreateNewSurvey(surveyTitle + "_TC61066", "addtocontainer");
            _test.Log(Status.Info, "A new Survey Created");
            SurveysPage.clickSurveyTab(); 
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.SetPermissionforonlyAdmin();
            _test.Log(Status.Info, "Permission set only for admin");
            SurveyPage.Click_Publish();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61066");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + surveyTitle + "_TC61066" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + surveyTitle + "_TC61066" + '"');
            _test.Log(Status.Info, "Search the survey");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(surveyTitle + "_TC61066"));
            _test.Log(Status.Pass, "Verify content cant be search");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61066" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61066" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61066");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(surveyTitle + "_TC61066");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(surveyTitle + "_TC61066"));
            _test.Log(Status.Pass, "Virefy survey is display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeSurveyButtonDisplay());
            _test.Log(Status.Pass, "Take Survey Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61066");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61066"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(surveyTitle + "_TC61066");
            _test.Log(Status.Pass, "Enroll in certification content");
            ContentDetailsPage.closeSurveywindow(surveyTitle + "_TC61066");

            CommonSection.SearchCatalog('"' + surveyTitle + "_TC61066" + '"');
            _test.Log(Status.Pass, "Search the survey");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(surveyTitle + "_TC61066"));
            _test.Log(Status.Pass, "Verify content should be searched after started same content from certification");

        }
        [Test, Order(14)]
        public void tc_61067_Permission_Override_Behavior_Test()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_tc61067");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.setPermissionforonlyAdmin();          
            _test.Log(Status.Info, "Permission set only for admin");
            TestwizardPage.checkin();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61067");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + TestTitle + "_tc61067" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + TestTitle + "_tc61067" + '"');
            _test.Log(Status.Info, "Search the test");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(TestTitle + "_tc61067"));
            _test.Log(Status.Pass, "Verify content cant be search");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61067" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61067" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61067");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(TestTitle + "_tc61067");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(TestTitle + "_tc61067"));
            _test.Log(Status.Pass, "Virefy survey is display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeTestButtonDisplay());
            _test.Log(Status.Pass, "Take Test Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61067");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61067"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(TestTitle + "_tc61067");
            _test.Log(Status.Pass, "Enroll in certification content");
            ContentDetailsPage.closeTestModalwithoutComplete(TestTitle + "_tc61067");

            CommonSection.SearchCatalog('"' + TestTitle + "_tc61067" + '"');
            _test.Log(Status.Pass, "Search the test");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(TestTitle + "_tc61067"));
            _test.Log(Status.Pass, "Verify content should be searched after started same content from certification");

        }
        [Test, Order(15)]
        public void tc_61037_Verify_the_override_Behavior_Permissions_in_a_Classroom_course_as_part_of_Certification()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC61037");
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.SetPermissionforonlyAdmin();
            _test.Log(Status.Info, "Permission set only for admin");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");           

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61037");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + classroomcoursetitle + "_TC61037" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC61037" + '"');
            _test.Log(Status.Info, "Search the Classroom Course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(classroomcoursetitle + "_TC61037"));
            _test.Log(Status.Pass, "Verify content cant be search");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61037" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61037" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61037");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(classroomcoursetitle + "_TC61037");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(classroomcoursetitle + "_TC61037"));
            _test.Log(Status.Pass, "Virefy survey is display");
            ContentDetailsPage.ContentBanner.CLickScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC61037");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC61037"));
            
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC61037" + '"');
            _test.Log(Status.Pass, "Search the classroom course");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(classroomcoursetitle + "_TC61037"));
            _test.Log(Status.Pass, "Verify content should be searched after started same content from certification");

        }
        [Test, Order(16)]
        public void tc_61753_Content_Details_Page_Allignment_when_No_right_Sidebar()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC61753");
            _test.Log(Status.Info, "Creating a new general course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify Course is Created");            
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61753");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC61753" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "_TC61753" + '"');
            _test.Log(Status.Info, "Search the general Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC61753");
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isDescriptiondisplayExpandedtillRight());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61753" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61753" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61753");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptiondisplayExpandedtillRight());
        }

    }
}



