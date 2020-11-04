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
    public class P1_Catalog_CertificationContentDetailPagesTest1 : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_CertificationContentDetailPagesTest1(string browser)
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
        public void tc_60995_As_a_Learner_verify_override_Behavior_Prerequisites_for_Online_Courses_in_a_Certification_Document()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60995");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreteNewDocuemnt(documenttitle + "_TC60995");
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "_TC60995" + '"');
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60995");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + documenttitle + "_TC60995" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(documenttitle + "_TC60995");
            SearchResultsPage.ClickCourseTitle(documenttitle + "_TC60995");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");
            Assert.False(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60995" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60995" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60995");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());            
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(documenttitle + "_TC60995");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(documenttitle + "_TC60995"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60995");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60995"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(documenttitle + "_TC60995");

            CommonSection.SearchCatalog(documenttitle + "_TC60995");
            SearchResultsPage.ClickCourseTitle(documenttitle + "_TC60995");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");            
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
        }
        [Test, Order(2)]
        public void tc_60989_As_a_Learner_verify_override_Behavior_Prerequisites_for_Online_Courses_in_a_Certification_Scrum()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60989");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreteNewScorm(scormtitle + "_TC60989");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");            
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "_TC60989" + '"');
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60989");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + scormtitle + "_TC60989" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(scormtitle + "_TC60989");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60989");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");
            Assert.False(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60989" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60989" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60989");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(scormtitle + "_TC60989");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(scormtitle + "_TC60989"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60989");
            _test.Log(Status.Info, "Clicked Bread crumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60989"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(scormtitle + "_TC60989");            
           
            CommonSection.SearchCatalog(scormtitle + "_TC60989");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60989");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");           
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Verify Start button is display as pre requisite is overridden");
        }
        [Test, Order(3)]
        public void tc_60992_As_a_Learner_verify_override_Behavior_Prerequisites_for_Online_Courses_in_a_Certification_General()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60992_Pre");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60992");
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "_TC60992_Pre" + '"');
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60992");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60992" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC60992");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC60992");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");
            Assert.False(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60992" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60992" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60992");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(GeneralCourseTitle + "_TC60992");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "_TC60992"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60992");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60992"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60992");

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC60992");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC60992");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");           
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Verify Start button is display as pre requisite is overridden");
        }
        [Test, Order(4)]
        public void tc_60988_As_a_Learner_verify_override_Behavior_Prerequisites_for_Classroom_Course_in_a_Certification()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60988");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.ClassroomCourse();//(documenttitle + "_TC60995");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC60988");
            _test.Log(Status.Info, "A new Classroom Course Created");
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "_TC60988" + '"');
            PrerequisitesPage.Click_BreadCrumb(classroomcoursetitle + "_TC60988");
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
            CertificationPage.FillTitle(CertificatrTitle + "_TC60988");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + classroomcoursetitle + "_TC60988" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(classroomcoursetitle + "_TC60988");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC60988");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");
            //Assert.IsFalse(ContentDetailsPage.ContentBanner.IsViewScheduleButtonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60988" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60988" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60988");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(classroomcoursetitle + "_TC60988");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(classroomcoursetitle + "_TC60988"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.IsViewScheduleButtonDisplay());
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60988");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60988"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(classroomcoursetitle + "_TC60988");

            CommonSection.SearchCatalog(classroomcoursetitle + "_TC60988");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC60988");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");
            //Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            //_test.Log(Status.Pass, "Verify Start button is display as pre requisite is overridden");
        }
        [Test, Order(5)]
        public void tc_60991_As_a_Learner_verify_override_Behavior_Prerequisites_for_Online_Courses_in_a_Certification_AICC()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60991");
            DocumentPage.ClickButton_CheckIn();
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "_TC60991");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "_TC60991" + '"');
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60991");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + AICCCourseTitle + "_TC60991" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(AICCCourseTitle + "_TC60991");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "_TC60991");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");
            //Assert.False(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60991" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60991" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60991");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(AICCCourseTitle + "_TC60991");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "_TC60991"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60991");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60991"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(AICCCourseTitle + "_TC60991");

            CommonSection.SearchCatalog(AICCCourseTitle + "_TC60991");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "_TC60991");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Verify Start button is display as pre requisite is overridden");
        }
        [Test, Order(6)]
        public void tc_60993_As_a_Learner_verify_override_Behavior_Prerequisites_for_Online_Courses_in_a_Certification_Survey()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60993");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.Survey();
            SurveysPage.CreateNewSurvey(surveyTitle + "_TC60993","addtocontainer");
            _test.Log(Status.Info, "A new Survey Created");
            SurveysPage.clickSurveyTab();
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "_TC60993" + '"');
            PrerequisitesPage.Click_BreadCrumb();
            SurveyPage.Click_Publish();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60993");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + surveyTitle + "_TC60993" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(surveyTitle + "_TC60993");
            SearchResultsPage.ClickCourseTitle(surveyTitle + "_TC60993");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
          
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60993" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60993" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60993");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(surveyTitle + "_TC60993");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(surveyTitle + "_TC60993"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeSurveyButtonDisplay());
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60993");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60993"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(surveyTitle + "_TC60993");
            ContentDetailsPage.closeSurveywindow(surveyTitle + "_TC60993");

            CommonSection.SearchCatalog(surveyTitle + "_TC60993");
            SearchResultsPage.ClickCourseTitle(surveyTitle + "_TC60993");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");           
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
        }
        [Test, Order(7)]
        public void tc_60994_As_a_Learner_verify_override_Behavior_Prerequisites_for_Online_Courses_in_a_Certification_Tests()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60994");
            DocumentPage.ClickButton_CheckIn();            
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_tc60994");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.addPrerequisitetotest(GeneralCourseTitle + "_TC60994");
            TestwizardPage.checkin();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60994");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + TestTitle + "_tc60994" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(TestTitle + "_tc60994");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_tc60994");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");           
            //Assert.False(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60994" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60994" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60994");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(TestTitle + "_tc60994");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(TestTitle + "_tc60994"));
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60994");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60994"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(TestTitle + "_tc60994");
            ContentDetailsPage.ContentBanner.CloseOpenedTestwindow();

            CommonSection.SearchCatalog(TestTitle + "_tc60994");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_tc60994");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");           
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
        }

        [Test, Order(8)]
        public void tc_60967_As_Learner_verify_the_override_behavior_Access_approval_for_Online_courses_in_a_Certification_AICC()
        {            
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            CreateAICCPage.Title(AICCTitle + "TC60967");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60967");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + AICCTitle + "TC60967" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + AICCTitle + "TC60967" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC60967");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button should Display");
           
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60967" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60967" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60967");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(AICCTitle + "TC60967");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button Should not displays");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
             ContentDetailsPage.ClickBreadCrumb(CertificatrTitle+"_TC60967");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60967"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(AICCTitle + "TC60967");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + AICCTitle + "TC60967" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC60967");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());

        }

        [Test, Order(9)]
        public void tc_60968_As_Learner_verify_the_override_behavior_Access_approval_for_Online_courses_in_a_Certification_General_Course()
        {            
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC60968");            
            _test.Log(Status.Info, "Create a new General Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60968");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "TC60968" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "TC60968" + '"');
            _test.Log(Status.Pass, "Search the General Course Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "TC60968");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button should Display");
            
            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60968" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60968" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60968");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(GeneralCourseTitle + "TC60968");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button Should not displays");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle+"TC60968");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "TC60968");
            _test.Log(Status.Pass, "Enroll in certification");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "TC60968" + '"');
            _test.Log(Status.Pass, "Search the General Course Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "TC60968");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
        }
        [Test, Order(10)]
        public void tc_60971_As_Learner_verify_the_override_behavior_Access_approval_for_Online_courses_in_a_Certification_Document()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC60971");
            _test.Log(Status.Info, "Creating New Document");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60971");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + documenttitle + "TC60971" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + documenttitle + "TC60971" + '"');
            _test.Log(Status.Pass, "Search the Document Course");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC60971");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button should Display");
            
            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60971" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60971" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60971");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(documenttitle + "TC60971");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button Should not displays");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Open Item Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle+ "TC60971");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "TC60971"));
            ContentDetailsPage.Click_ContentTab();         
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(documenttitle + "TC60971");
            _test.Log(Status.Pass, "Start certification content");

            CommonSection.SearchCatalog('"' + documenttitle + "TC60971" + '"');
            _test.Log(Status.Pass, "Search the Document Course");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC60971");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
        }
        [Test, Order(11)]
        public void tc_60966_As_Learner_verify_the_override_behavior_Access_approval_for_Online_courses_in_a_Certification_SCROM()
        {
            CommonSection.CreteNewScorm(scormtitle + "_TC60966");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");
            DocumentPage.ClickButton_CheckOut();
            _test.Log(Status.Info, "Click Check-out");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60966");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + scormtitle + "_TC60966" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + scormtitle + "_TC60966" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60966");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button should Display");
            
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60966" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60966" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60966");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(scormtitle + "_TC60966");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button Should not displays");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60966");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60966"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(scormtitle + "_TC60966");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + scormtitle + "_TC60966" + '"');
            _test.Log(Status.Pass, "Search the SCROM Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60966");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());

        }
        [Test, Order(12)]
        public void tc_60970_As_Learner_verify_the_override_behavior_Access_approval_for_Online_courses_in_a_Certification_Tests()

        {
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "TC60970");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.setApprovalPath();
            TestwizardPage.checkin();    

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60970");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + TestTitle + "TC60970" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + TestTitle + "TC60970" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(TestTitle + "TC60970");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button should Display");
            
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60970" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60970" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60970");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(TestTitle + "TC60970");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Request access Button Should not displays");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeTestButtonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle+"_TC60970");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60970"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(TestTitle + "TC60970");
            _test.Log(Status.Pass, "Enroll in certification content");
            ContentDetailsPage.ContentBanner.CloseOpenedTestwindow();

            CommonSection.SearchCatalog('"' + TestTitle + "TC60970" + '"');
            _test.Log(Status.Pass, "Search the Test Course");
            SearchResultsPage.ClickCourseTitle(TestTitle + "TC60970");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());

        }
        [Test, Order(13)]
        public void tc_60460_As_a_Learner_verify_the_override_behavior_Access_Approval_for_classrooms()

        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC60460");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            AccessApprovalPage.AssignApproverPath();           
            _test.Log(Status.Info, "Assign approval path");
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
            CertificationPage.FillTitle(CertificatrTitle + "_TC60460");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addClassroomsectionIntoCertificate('"' + classroomcoursetitle + "_TC60460" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"'+ classroomcoursetitle + "_TC60460" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC60460");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.IsViewScheduleButtonDisplay());
            ContentDetailsPage.ContentBanner.clickViewScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsRequestAccessbuttondisplay("Section1"));
            _test.Log(Status.Pass, "Request access Button should Display");            

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60460" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60460" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60460");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(classroomcoursetitle + "_TC60460");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            ContentDetailsPage.ContentBanner.clickViewScheduleButton();
            Assert.IsFalse(ContentDetailsPage.ScheduleTab.SectionPortlet.IsRequestAccessbuttondisplay("Section1"));
            _test.Log(Status.Pass, "Request access Button should Display");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");           
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60460");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60460"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickStart(classroomcoursetitle + "_TC60460");
            _test.Log(Status.Pass, "Enroll in certification content");
           

            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC60460" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC60460");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.ContentBanner.clickViewScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsRequestAccessbuttondisplay("Section1"));
            _test.Log(Status.Pass, "Request access Button should not Display");
            Assert.IsFalse(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());
            _test.Log(Status.Pass, "Verify enroll Button Should displays");

        }
        [Test, Order(14)]
        public void tc_60972_AS_Learner_Verify_the_override_Behavior_Cost_Access_Keys_for_Online_Courses_in_a_Certification_Scrom()
        {
            CommonSection.CreteNewScorm(scormtitle + "_TC60972");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");
            DocumentPage.ClickButton_CheckOut();
            _test.Log(Status.Info, "Click Check-out");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60972");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + scormtitle + "_TC60972" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + scormtitle + "_TC60972" + '"');
            _test.Log(Status.Pass, "Search the SCROM Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60972");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should display");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60972" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60972" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60972");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(scormtitle + "TC60972");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60972");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60972"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(scormtitle + "_TC60972");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + scormtitle + "_TC60972" + '"');
            _test.Log(Status.Pass, "Search the SCROM Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "_TC60972");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Start Button Should displays");
        }
        [Test, Order(15)]
        public void tc_60974_AS_Learner_Verify_the_override_Behavior_Cost_Access_Keys_for_Online_Courses_in_a_Certification_General_Course()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60974");
            _test.Log(Status.Info, "Creating a new General course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New General Course is Created");           
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60974");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60974" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "_TC60974" + '"');
            _test.Log(Status.Pass, "Search the General Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC60974");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should display");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60974" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60974" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60974");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(GeneralCourseTitle + "_TC60974");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60974");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60974"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60974");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + GeneralCourseTitle + "_TC60974" + '"');
            _test.Log(Status.Pass, "Search the SCROM Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC60974");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Start Button Should displays");
        }
        [Test, Order(16)]
        public void tc_60973_AS_Learner_Verify_the_override_Behavior_Cost_Access_Keys_for_Online_Courses_in_a_Certification_AICC()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            CreateAICCPage.Title(AICCCourseTitle + "_TC60973");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60973");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + AICCCourseTitle + "_TC60973" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click at Check IN");

            CommonSection.SearchCatalog('"' + AICCCourseTitle + "_TC60973" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "_TC60973");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should display");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should display");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60973" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60973" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60973");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "Start the certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickContentTitle(AICCCourseTitle + "_TC60973");
            _test.Log(Status.Pass, "Click at Certification Content Tittle");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Enroll Button Should displays");
            ContentDetailsPage.ClickBreadCrumb(CertificatrTitle + "_TC60973");
            _test.Log(Status.Pass, "Bcck to Certification by clicking at breadcrumb");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC60973"));
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(AICCCourseTitle + "_TC60973");
            _test.Log(Status.Pass, "Enroll in certification content");

            CommonSection.SearchCatalog('"' + AICCCourseTitle + "_TC60973" + '"');
            _test.Log(Status.Pass, "Search the AICC Course");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "_TC60973");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Virefy Add to Cart button should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAccessKeyfielddisplay());
            _test.Log(Status.Pass, "Virefy Accesskey field should not display as it overrride");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Start Button Should displays");
        }
        

    }
}



