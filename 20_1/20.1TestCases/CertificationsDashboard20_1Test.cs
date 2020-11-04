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
    public class P1_CertificationsDashboard20_1Test : TestBase
    {
        string browserstr = string.Empty;
        public P1_CertificationsDashboard20_1Test(string browser)
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
        bool TC60336;
        bool TC60308;
        bool TC59262;
        bool TC59262_1;
        bool TC59262_2;
        bool TC60513;
        bool TC60518;
        bool TC60608, TC60610;


        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }

        [Test, Order(1)]
        public void tc_60317_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Not_Certified_Started()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60317");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60317");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            //CertificationPage.SelectautomaticallygrantedcertificationDefaultValue("No");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60317" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60317" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60317" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60317");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60317");

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60317");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60317");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Certify", "Suspend"));
            Assert.IsFalse(CertificationConsolePage.Resulttable.isRevokedstatusdisplayActionMenu());
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
            TC60308 = true;


        }
        [Test, Order(2)]
        public void tc_60308_As_an_admin_I_want_to_see_certification_status_and_progress_status_when_the_learner_has_never_certified()
        {
            Assert.IsTrue(TC60308);
        }
        [Test, Order(3)]
        public void tc_60319_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Certified()
        {

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60317" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60317" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60317");

            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC60317");
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC60317");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60317");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60317");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus(""));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Update Expiration Date","Recertify", "Revoke", "Suspend"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
        }
        [Test, Order(4)]
        public void tc_60320_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Certified_Started()
        {

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60317" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60317" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60317");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStart_recertificationLinkdisplay());
            ContentDetailsPage.ContentBanner.Click_recertificationLink();
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60317");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60317");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            _test.Log(Status.Pass, "Verify progression status display as Started");
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Update Expiration Date","Revoke", "Suspend"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
        }


        [Test, Order(5)]
        public void tc_60330_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Revoked_Recertification()
        {
            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60317");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60317");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified"));
            CertificationConsolePage.Resulttable.SelectActionItem("Revoke");
            _test.Log(Status.Pass, "Admin Revocked the certification");

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60317");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60317");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Revoked"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Recertify"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");

        }
        [Test, Order(6)]
        public void tc_60331_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Revoked_Started_recertification()
        {
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60317" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60317" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60317");
            _test.Log(Status.Info, "Clicked searched course title");
            //need to verify how to start a revocked certification

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60317");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60317");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");

            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Revoked"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Recertify"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");

        }
        [Test, Order(7)]
        public void tc_60334_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Suspended_Recertification()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60334");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60334");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            //CertificationPage.SelectautomaticallygrantedcertificationDefaultValue("No");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60334" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            // CommonSection.Logout();
            //  LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60334" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60334" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60334");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60334");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60334");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");

            CertificationConsolePage.Resulttable.SelectActionItem("Suspend");
            _test.Log(Status.Info, "Mark certification as Suspended");

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60334");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60334");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Suspended"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus(""));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Certify"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
            Assert.IsFalse(CertificationConsolePage.Resulttable.isRevokedstatusdisplayActionMenu());
            TC59262_1 = true;
        }
        [Test, Order(8)]
        public void tc_60335_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Suspended_Started_recertification()
        {
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60334" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60334" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60334");
            _test.Log(Status.Info, "Clicked searched course title");
            //need to verify how to start a suspended certification

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60334");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60334");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Suspended"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus(""));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Certify"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
            TC60336 = true;

        }
        [Test, Order(9)]
        public void tc_60336_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Suspended_Pending_Recertification()
        {
            Assert.IsTrue(TC60336);
        }
        [Test, Order(10)]
        public void tc_60318_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Not_Certified_Pending()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60318");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60318_1");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60318");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.SelectautomaticallygrantedcertificationDefaultValue("No");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60318" + '"');
            CertificatePage.Click_backbutton();
            CertificatePage.addContenttoRecertification('"' + GeneralCourseTitle + "_TC60318_1" + '"');
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60318" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60318" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60318");
            _test.Log(Status.Info, "Clicked searched course title");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60318");
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC60318");
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC60318");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60318");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60318");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Pending"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Certify", "Suspend"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
        }

        [Test, Order(11)]
        public void tc_60321_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Certified_Pending()
        {
            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60318");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60318");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
            CertificationConsolePage.Resulttable.SelectActionItem("Certify");
            _test.Log(Status.Info, "certify user");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60318" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60318" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60318");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStart_recertificationLinkdisplay());
            _test.Log(Status.Info, "Verify is start recitification link display");
            ContentDetailsPage.ContentBanner.Click_recertificationLink();
            Assert.IsTrue(ContentDetailsPage.ContentTab.isRecertificationCriteriaportletdisplay());
            _test.Log(Status.Pass, "Verify recertification content display");

            ContentDetailsPage.ContentTab.RecertificationCriteria.ClickEnroll(GeneralCourseTitle + "_TC60318_1");
            ContentDetailsPage.ContentTab.RecertificationCriteria.StarContentandClose(GeneralCourseTitle + "_TC60318_1");
            ContentDetailsPage.ContentTab.RecertificationCriteria.SelectMarkComplete(GeneralCourseTitle + "_TC60318_1");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());


            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60318");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60318");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Pending"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Update Expiration Date","Revoke", "Suspend"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");


        }
        [Test, Order(12)]
        public void tc_60332_As_an_admin_I_want_to_see_applicable_action_available_when_learners_current_status_progress_status_is_Revoked_Pending_Recertification()
        {
            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60318");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60318");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified"));
            CertificationConsolePage.Resulttable.SelectActionItem("Revoke");
            _test.Log(Status.Info, "Revocked recertifications");

            CommonSection.SearchCatalog(CertificatrTitle + "_TC60318");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60318");
            //Need to check how to start a revocked certification
            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60318");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60318");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Revoked"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Pending"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Recertify"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
            Assert.IsFalse(CertificationConsolePage.Resulttable.isRevokedstatusdisplayActionMenu());
            TC59262_2 = true;
        }
        [Test, Order(13)]
        public void tc_59250_As_an_Admin_I_want_to_Revoke_already_certified_User()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC59250");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC59250");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC59250" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC59250" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC59250" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC59250");
            _test.Log(Status.Info, "Clicked searched course title");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC59250");
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC59250");
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC59250");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC59250");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC59250");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus(""));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Revoked", "Suspend"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
            CertificationConsolePage.Resulttable.SelectActionItem("Revoke");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Revoked"));

            CommonSection.Logout();
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.Learner.Transcript();
            TranscriptPage.ClickCertificationsTab();
            Assert.IsTrue(TranscriptPage.CertificationTab.isStatusdisplay(CertificatrTitle + "_TC59250", "Revoked"));


        }
        [Test, Order(14)]
        public void tc_59262_As_an_Admin_I_want_see_revoked_status_for_Not_Certified_Suspended_and_already_Revoked()
        {
            Assert.IsTrue(TC59262);
            Assert.IsTrue(TC59262_1);
            Assert.IsTrue(TC59262_2);
        }
        [Test, Order(15)]
        public void tc_60468_As_an_Admin_Individually_certify_existing_users_based_on_default_date_from_Certification_Management_Certification_does_not_expire()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60468");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60468");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60468" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60468" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60468" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60468");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC60468");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC60468");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            CertificationConsolePage.Resulttable.ClickCertifyAction();
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Obtaineddate("Today"));
            Assert.IsFalse(CertificationConsolePage.Resulttable.CertifiyUserModal.ObtaineddateCalender.isbackdatesaredisabled());
            CertificationConsolePage.Resulttable.CertifiyUserModal.CancelwithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            _test.Log(Status.Pass, "Verify Current Status still shows Not Certified");
            CertificationConsolePage.Resulttable.SelectActionItem("Certify");
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            CertificationConsolePage.Resulttable.CertifiyUserModal.CertifywithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified (Alternate)"));
            _test.Log(Status.Pass, "Verify Current Status shows Certified (Alternate)");
            TC60513 = true;
        }
        [Test, Order(16)]
        public void tc_60513_As_an_Admin_Individually_certify_existing_users_based_on_date_selected_from_Certification_Management_Certification_does_not_expire()

        {
            Assert.IsTrue(TC60513);
        }
        [Test, Order(17)]
        public void tc_60516_As_an_Admin_Individually_certify_existing_users_based_on_default_date_from_Certification_Management_Certification_expires_and_no_recertification()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC60516");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60516");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "TC60516" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60516" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60516" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60516");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "TC60516");
            string CertifiedUserCount = CertificationConsolePage.CertifiedUserCount();
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "TC60516");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            CertificationConsolePage.Resulttable.ClickCertifyAction();
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Obtaineddate("Today"));
            Assert.IsFalse(CertificationConsolePage.Resulttable.CertifiyUserModal.ObtaineddateCalender.isbackdatesaredisabled());
            _test.Log(Status.Pass, "Verify obtained date can't be less than today");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Expirationdate("Today+1"));
            _test.Log(Status.Pass, "Verify Expiration date is display with date (obtained date+certification period");
            CertificationConsolePage.Resulttable.CertifiyUserModal.CancelwithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            _test.Log(Status.Pass, "Verify Current Status still shows Not Certified");
            CertificationConsolePage.Resulttable.SelectActionItem("Certify");
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            CertificationConsolePage.Resulttable.CertifiyUserModal.CertifywithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified (Alternate)"));
            _test.Log(Status.Pass, "Verify Current Status shows Certified (Alternate)");
            CertificationConsolePage.ClickCertificationBreadcromp();
            Assert.IsFalse(CertificationConsolePage.CertifiedUserCount().Equals(CertifiedUserCount));
            TC60518 = true;
        }
        [Test, Order(18)]
        public void tc_60518_As_an_Admin_individually_certify_existing_users_based_on_date_selected_from_Certification_Management_Certification_expires_and_no_recertification()
        {
            Assert.IsTrue(TC60518);
        }
        [Test, Order(19)]
        public void tc_60519_Admin_Individually_certify_users_from_Certification_Management_CertificationExpiresWithRecertificationStartDateAImmediateAndNoLimitOnLastDate()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC60519");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60519");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "TC60519" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60519" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60519" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60519");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "TC60519");
            string CertifiedUserCount = CertificationConsolePage.CertifiedUserCount();
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "TC60519");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            CertificationConsolePage.Resulttable.ClickCertifyAction();
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Obtaineddate("Today"));
            Assert.IsFalse(CertificationConsolePage.Resulttable.CertifiyUserModal.ObtaineddateCalender.isbackdatesaredisabled());
            _test.Log(Status.Pass, "Verify obtained date can't be less than today");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Expirationdate("Today+1"));
            _test.Log(Status.Pass, "Verify Expiration date is display with date (obtained date+certification period");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.isRecertificationPerioddisplay());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.isRecertificationbegindisplay("Today", 0, "Immediately after certifying"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.isRecertificationPeriodenddisplay("No Limit"));
            _test.Log(Status.Pass, "Verify Recertification start and end display");
            CertificationConsolePage.Resulttable.CertifiyUserModal.CancelwithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            _test.Log(Status.Pass, "Verify Current Status still shows Not Certified");
            CertificationConsolePage.Resulttable.SelectActionItem("Certify");
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            CertificationConsolePage.Resulttable.CertifiyUserModal.CertifywithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified (Alternate)"));
            _test.Log(Status.Pass, "Verify Current Status shows Certified (Alternate)");
            CertificationConsolePage.ClickCertificationBreadcromp();
            Assert.IsFalse(CertificationConsolePage.CertifiedUserCount().Equals(CertifiedUserCount));

        }
        [Test, Order(20)]
        public void tc_60520_Admin_Individually_certify_users_from_Certification_Management_CertiExpiresWithRecertiStartDateAsXperiodVeforeExpirationAndLimitOnLastDate()
        {
            //  CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC60520");
            //  DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60520");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.Whenistherecertificationperiod.Setbeforeexpiration();

            CertificationPage.Whenistherecertificationperiod.Start("15");
            CertificationPage.Whenistherecertificationperiod.SetEndsAs("Set period");
            CertificationPage.Whenistherecertificationperiod.After("15");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            // CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "TC60519" + '"');
            // CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60520" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60520" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60520");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "TC60520");
            string CertifiedUserCount = CertificationConsolePage.CertifiedUserCount();
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "TC60520");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            CertificationConsolePage.Resulttable.SelectActionItem("Certify");
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Obtaineddate("Today"));
            Assert.IsFalse(CertificationConsolePage.Resulttable.CertifiyUserModal.ObtaineddateCalender.isbackdatesaredisabled());
            _test.Log(Status.Pass, "Verify obtained date can't be less than today");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Expirationdate("Today+1"));
            _test.Log(Status.Pass, "Verify Expiration date is display with date (obtained date+certification period");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.isRecertificationPerioddisplay());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.isRecertificationbegindisplay("Today", 15, "15 Day(s) before expiration date"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.isRecertificationPeriodenddisplay("15 Day(s) after expiration date"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.isRecertificationenddatedisplay("Today", 15));
            _test.Log(Status.Pass, "Verify Recertification start and end display");
            CertificationConsolePage.Resulttable.CertifiyUserModal.CancelwithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            _test.Log(Status.Pass, "Verify Current Status still shows Not Certified");
            CertificationConsolePage.Resulttable.SelectActionItem("Certify");
            _test.Log(Status.Info, "Select Certify from Action menu");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            CertificationConsolePage.Resulttable.CertifiyUserModal.CertifywithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified (Alternate)"));
            _test.Log(Status.Pass, "Verify Current Status shows Certified (Alternate)");
            CertificationConsolePage.ClickCertificationBreadcromp();
            Assert.IsFalse(CertificationConsolePage.CertifiedUserCount().Equals(CertifiedUserCount));

        }
        [Test, Order(21)]
        public void tc_60607_As_an_Admin_Bulk_certify_existing_users_based_on_default_date_from_Certification_Management_Certification_does_not_expire()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC60607");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60607");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "TC60607" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60607" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60607" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60607");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "TC60607");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "TC60607");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            CertificationConsolePage.Resulttable.selectstatus("Not Certified");
            CertificationConsolePage.Resulttable.Selectuser("admin");
            CertificationConsolePage.Resulttable.SelectCertifyfrombulkaction();
            _test.Log(Status.Info, "Select user and click Certify button");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Obtaineddate("Today"));
            Assert.IsFalse(CertificationConsolePage.Resulttable.CertifiyUserModal.ObtaineddateCalender.isbackdatesaredisabled());
            _test.Log(Status.Pass, "Verify obtained date can't be less than today");
            CertificationConsolePage.Resulttable.CertifiyUserModal.CancelwithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            _test.Log(Status.Pass, "Verify Current Status still shows Not Certified");
            CertificationConsolePage.Resulttable.SelectCertifyfrombulkaction();
            _test.Log(Status.Info, "Select user and click Certify button");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            CertificationConsolePage.Resulttable.CertifiyUserModal.CertifywithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified (Alternate)"));
            _test.Log(Status.Pass, "Verify Current Status shows Certified (Alternate)");
            TC60608 = true;
        }
        [Test, Order(22)]
        public void tc_60608_As_an_Admin_bulk_certify_existing_users_based_on_date_selected_from_Certification_Management_Certification_does_not_expire()
        {
            Assert.IsTrue(TC60608);
        }
        [Test, Order(23)]
        public void tc_60609_Admin_bulk_certify_users_from_Certification_Management_Certification_expires_and_no_recertification()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC60609");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC60609");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "TC60609" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC60609" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC60609" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC60609");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "TC60609");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "TC60609");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Started"));
            CertificationConsolePage.Resulttable.selectstatus("Not Certified");
            CertificationConsolePage.Resulttable.Selectuser("admin");
            CertificationConsolePage.Resulttable.SelectCertifyfrombulkaction();
            _test.Log(Status.Info, "Select user and click Certify button");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Obtaineddate("Today"));
            Assert.IsFalse(CertificationConsolePage.Resulttable.CertifiyUserModal.ObtaineddateCalender.isbackdatesaredisabled());
            _test.Log(Status.Pass, "Verify obtained date can't be less than today");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CertifiyUserModal.Expirationdate("Today+1"));
            _test.Log(Status.Pass, "Verify Expiration date is display with date (obtained date+certification period");
            CertificationConsolePage.Resulttable.CertifiyUserModal.CancelwithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            _test.Log(Status.Pass, "Verify Current Status still shows Not Certified");
            CertificationConsolePage.Resulttable.SelectCertifyfrombulkaction();
            _test.Log(Status.Info, "Select user and click Certify button");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isCertifiyUserModalOpen());

            //two line will copy from afreen

            CertificationConsolePage.Resulttable.CertifiyUserModal.CertifywithReason("Test");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Certified (Alternate)"));
            _test.Log(Status.Pass, "Verify Current Status shows Certified (Alternate)");
            TC60610 = true;
        }
        [Test, Order(24)]
        public void tc_60610_Admin_bulk_certify_users_from_Certification_Management_Certification_expires_and_no_recertification()
        {
            Assert.IsTrue(TC60610);
        }
        [Test, Order(25)]
        public void tc_60611_Admin_bulk_certify_users_from_Certification_Management_Certification_expires_with_recertification_start_date_as_immediate_and_no_limit_on_Last_date()
        {

        }
        [Test, Order(26)]
        public void tc_60612_Admin_bulk_certify_users_from_Certification_Management_CertificationExpiresWithRecertificationStartDateAsXperiodBeforeExpirationAndLimitOnLastDate()
        {

        }
        [Test, Order(27)]
        public void tc_59994_As_an_admin_I_want_to_certify_users_with_no_certification_history_for_Recurring_certification_Re_Certification_Unlimited_Expiration()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC59994");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC59994");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC59994" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC59994" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC59994" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC59994");
            _test.Log(Status.Info, "Clicked searched course title");

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Info, "Click on start button of the Content banner");
            CommonSection.Manage.Certifications();
            _test.Log(Status.Info, "Click Certifications under Manage to open Certification dashboard");
            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_TC59994");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_TC59994");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
            CertificationDashboardDetailsPage.Click_CertifyUsers();
            _test.Log(Status.Info, "Click Certify Users on the certification dashboard details page");
            Assert.IsTrue(CertificationDashboardDetailsPage.VerifyCertifyUsersModalIsDisplayed());
            _test.Log(Status.Pass, "Click Certify Users on the certification dashboard details page");
            CertificationDashboardDetailsPage.CertifyUsersModal.SearchUsers("ak");
            _test.Log(Status.Info, "Search users in the certify Users Modal");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyNameAndEmailIdIsDisplayed());
            _test.Log(Status.Pass, "Verify Name and email Id is Displayed");
            //
            //
            CertificationDashboardDetailsPage.CertifyUsersModal.SelectMultipleUsers();
            _test.Log(Status.Info, "Select multiple users");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickNextButton();
            _test.Log(Status.Info, "Click on Next Button");
            //
            //

            CertificationDashboardDetailsPage.CertifyUsersModal.ClickPreviousButton();
            _test.Log(Status.Info, "Click on Previous Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyOnClickOfPreviousButtonPagelandsOnPreviousPage());
            _test.Log(Status.Pass, "verify page lands on Previous page");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickNextButton();
            _test.Log(Status.Info, "Click on Next Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyObtainedDateCanBeSelectedPast(2));
            _test.Log(Status.Pass, "Verify date obtained can be selected in past");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyExpirationDateCanbeOverridden(2));
            _test.Log(Status.Pass, "Verify expiration date can be overridden");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertificationPeriodLearnerMayStart());
            _test.Log(Status.Pass, "Verify Certification period Learner may start");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertificationPeriodLearnerMustCompleteBy("No Limit"));
            _test.Log(Status.Pass, "Verify Certification period Learner may start");



            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyReasonTextboxIsDisplayed());
            _test.Log(Status.Pass, "Verify reason textbox is Displayed");
            Assert.IsFalse(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertifyButtonIsEnabled());
            _test.Log(Status.Pass, "Verify certify button is displayed");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Click on Next Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertifyButtonIsEnabled());
            _test.Log(Status.Pass, "Verify certify button is displayed");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");
            Assert.IsFalse(CertificationDashboardDetailsPage.VerifyCertifyUsersModalIsDisplayed());
            _test.Log(Status.Pass, "Click Certify Users on the certification dashboard details page");
        }
        [Test, Order(28)]
        public void tc_59992_As_an_admin_I_want_to_certify_users_with_no_certification_history_for_Recurring_certification_Re_Certification_limited_Expiration()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC59992");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC59992");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.Whenistherecertificationperiod.ReCertificationWindowWithLimitAfterExpiration("4");

            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC59992" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC59992" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC59992" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC59992");
            _test.Log(Status.Info, "Clicked searched course title");

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Info, "Click on start button of the Content banner");
            CommonSection.Manage.Certifications();
            _test.Log(Status.Info, "Click Certifications under Manage to open Certification dashboard");
            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_TC59992");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_TC59992");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
            CertificationDashboardDetailsPage.Click_CertifyUsers();
            _test.Log(Status.Info, "Click Certify Users on the certification dashboard details page");
            Assert.IsTrue(CertificationDashboardDetailsPage.VerifyCertifyUsersModalIsDisplayed());
            _test.Log(Status.Pass, "Click Certify Users on the certification dashboard details page");
            CertificationDashboardDetailsPage.CertifyUsersModal.SearchUsers("ak");
            _test.Log(Status.Info, "Search users in the certify Users Modal");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyNameAndEmailIdIsDisplayed());
            _test.Log(Status.Pass, "Verify Name and email Id is Displayed");
            //
            //
            CertificationDashboardDetailsPage.CertifyUsersModal.SelectMultipleUsers();
            _test.Log(Status.Info, "Select multiple users");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickNextButton();
            _test.Log(Status.Info, "Click on Next Button");
            //
            //

            CertificationDashboardDetailsPage.CertifyUsersModal.ClickPreviousButton();
            _test.Log(Status.Info, "Click on Previous Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyOnClickOfPreviousButtonPagelandsOnPreviousPage());
            _test.Log(Status.Pass, "verify page lands on Previous page");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickNextButton();
            _test.Log(Status.Info, "Click on Next Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyObtainedDateCanBeSelectedPast(2));
            _test.Log(Status.Pass, "Verify date obtained can be selected in past");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyExpirationDateCanbeOverridden(2));
            _test.Log(Status.Pass, "Verify expiration date can be overridden");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertificationPeriodLearnerMayStart());
            _test.Log(Status.Pass, "Verify Certification period Learner may start");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertificationPeriodLearnerMustCompleteBy(""));
            _test.Log(Status.Pass, "Verify Certification period Learner must complete by");



            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyReasonTextboxIsDisplayed());
            _test.Log(Status.Pass, "Verify reason textbox is Displayed");
            Assert.IsFalse(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertifyButtonIsEnabled());
            _test.Log(Status.Pass, "Verify certify button is displayed");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Click on Next Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertifyButtonIsEnabled());
            _test.Log(Status.Pass, "Verify certify button is displayed");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");
            Assert.IsFalse(CertificationDashboardDetailsPage.VerifyCertifyUsersModalIsDisplayed());
            _test.Log(Status.Pass, "Click Certify Users on the certification dashboard details page");
        }
        [Test, Order(29)]
        public void tc_59965_As_an_admin_I_want_to_certify_users_from_certification_dashboard_with_no_certification_history_for_Non_Recurring_certification()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC59965");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC59965");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC59965" + '"');
            _test.Log(Status.Info, "Add content to  certification");
            ContentDetailsPage.Click_Check_in();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC59965" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC59965" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC59965");
            _test.Log(Status.Info, "Clicked searched course title");

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Info, "Click on start button of the Content banner");
            CommonSection.Manage.Certifications();
            _test.Log(Status.Info, "Click Certifications under Manage to open Certification dashboard");
            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_TC59965");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_TC59965");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
            CertificationDashboardDetailsPage.Click_CertifyUsers();
            _test.Log(Status.Info, "Click Certify Users on the certification dashboard details page");
            Assert.IsTrue(CertificationDashboardDetailsPage.VerifyCertifyUsersModalIsDisplayed());
            _test.Log(Status.Pass, "Click Certify Users on the certification dashboard details page");
            CertificationDashboardDetailsPage.CertifyUsersModal.SearchUsers("ak");
            _test.Log(Status.Info, "Search users in the certify Users Modal");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyNameAndEmailIdIsDisplayed());
            _test.Log(Status.Pass, "Verify Name and email Id is Displayed");
            //Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyUserInformationFromInfoIcon());
            //_test.Log(Status.Pass, "Verify users information is Displayed in Info Icon");
            //CertificationDashboardDetailsPage.CertifyUsersModal.CloseInformationModal();
            //_test.Log(Status.Pass, "Close Information modal");
            CertificationDashboardDetailsPage.CertifyUsersModal.SelectMultipleUsers();
            _test.Log(Status.Info, "Select multiple users");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickNextButton();
            _test.Log(Status.Info, "Click on Next Button");
            //Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyObtainedDateIsTodaysdate());
            //_test.Log(Status.Pass, "Verify obtained date is today's date");

            CertificationDashboardDetailsPage.CertifyUsersModal.ClickPreviousButton();
            _test.Log(Status.Info, "Click on Previous Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyOnClickOfPreviousButtonPagelandsOnPreviousPage());
            _test.Log(Status.Pass, "verify page lands on Previous page");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickNextButton();
            _test.Log(Status.Info, "Click on Next Button");
            Assert.IsFalse(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyObtainedDateCanBeSelectedPast(2));
            _test.Log(Status.Pass, "Verify date obtained can be selected in past");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyReasonTextboxIsDisplayed());
            _test.Log(Status.Pass, "Verify reason textbox is Displayed");
            Assert.IsFalse(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertifyButtonIsEnabled());
            _test.Log(Status.Pass, "Verify certify button is displayed");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Click on Next Button");
            Assert.IsTrue(CertificationDashboardDetailsPage.CertifyUsersModal.VerifyCertifyButtonIsEnabled());
            _test.Log(Status.Pass, "Verify certify button is displayed");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");
            Assert.IsFalse(CertificationDashboardDetailsPage.VerifyCertifyUsersModalIsDisplayed());
            _test.Log(Status.Pass, "Click Certify Users on the certification dashboard details page");



        }

        [Test, Order(30)]
        public void tc_60326_As_an_admin_I_want_to_re_certify_an_individual_from_Certification_Management_having_setting_Certification_expires_with_recertification_start_date_as_immediate_and_No_Limit_on_last_date()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60326");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60326");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC60326" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60326" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60326" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60326");
            _test.Log(Status.Info, "Clicked searched course title");

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Info, "Click on start button of the Content banner");
            CommonSection.Manage.Certifications();
            _test.Log(Status.Info, "Click Certifications under Manage to open Certification dashboard");
            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_TC60326");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_TC60326");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
            CertificationDashboardDetailsPage.Click_CertifyUsers();
            _test.Log(Status.Info, "Click Certify Users on the certification dashboard details page");
            Assert.IsTrue(CertificationDashboardDetailsPage.VerifyCertifyUsersModalIsDisplayed());
            _test.Log(Status.Pass, "Click Certify Users on the certification dashboard details page");
            CertificationDashboardDetailsPage.CertifyUsersModal.SearchUsers("ak");
            _test.Log(Status.Info, "Search users in the certify Users Modal");
            CertificationDashboardDetailsPage.CertifyUsersModal.SelectMultipleUsers();
            _test.Log(Status.Info, "Select multiple users");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickNextButton();
            _test.Log(Status.Info, "Click on Next Button");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Enter Reason");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");
            CertificationPage.SearchCertification_Dashboard_DetailsPage("");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.Click_OptionFromActionMenu("Recertify");
            _test.Log(Status.Info, "Click on recertify from action menu to recertify an Individual");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Enter Reason");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");
            
        }
        [Test, Order(31)]
        public void tc_61179_As_an_admin_I_want_to_update_expiration_date_of_a_certified_individual_learner_for_a_non_expiring_certifications()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC61179");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61179");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");  
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC61179" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61179" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61179" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61179");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Info, "Click on start button of the Content banner");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC61179");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC61179");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC61179");

            CommonSection.Manage.Certifications();
            _test.Log(Status.Info, "Click Certifications under Manage to open Certification dashboard");
            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_TC61179");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_TC61179");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
          






        }

        [Test, Order(32)]
        public void tc_60327_As_an_admin_I_want_to_re_certify_an_individual_from_Certification_Management_having_setting_Certification_expires_with_recertification_Period_as_Set_period_Before_Expiration_and_No_Limit_on_last_date()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60327");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60327");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.Whenistherecertificationperiod.Setbeforeexpiration();

            CertificationPage.Whenistherecertificationperiod.Start("15");
            
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC60327" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60327" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60327" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60327");
            _test.Log(Status.Info, "Clicked searched course title");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60327");
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC60327");
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC60327");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.Certification();

            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_TC60327");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_TC60327");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
            Assert.IsTrue(CertificationDashboardDetailsPage.VerifyStatus("Certify"));
            _test.Log(Status.Info, "Verify user's status");

            CertificationPage.Click_OptionFromActionMenu("Recertify");
            _test.Log(Status.Info, "Click on recertify from action menu to recertify an Individual");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Enter Reason");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");





        }
        [Test, Order(33)]
        public void tc_60328_As_an_admin_I_want_to_re_certify_an_individual_from_Certification_Management_having_setting_Certification_expires_with_recertification_start_date_as_immediate_and_With_Limit_after_Expiration_as_last_date()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60328");
            DocumentPage.ClickButton_CheckIn();


            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60328");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.Whenistherecertificationperiod.ReCertificationWindowWithLimitAfterExpiration("4");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_TC60328" + '"');
            CertificatePage.Click_backbutton();
                       
            ContentDetailsPage.ClickCheckInbutton();


            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60328" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60328" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60328");
            _test.Log(Status.Info, "Clicked searched course title");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60328");
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC60328");
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC60328");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.Certification();

            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_TC60328");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_TC60328");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
            Assert.IsTrue(CertificationDashboardDetailsPage.VerifyStatus("Certify"));
            _test.Log(Status.Info, "Verify user's status");

            CertificationPage.Click_OptionFromActionMenu("Recertify");
            _test.Log(Status.Info, "Click on recertify from action menu to recertify an Individual");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Enter Reason");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");


        }
        [Test, Order(34)]
        public void tc_60562_As_an_admin_I_want_to_re_certify_an_individual_from_Certification_Management_having_setting_Certification_expires_with_recertification_Period_as_Set_period_Before_Expiration_and_With_Limit_after_Expiration_as_last_date()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_60562");
            DocumentPage.ClickButton_CheckIn();


            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_60562");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");

            
            CertificationPage.Whenistherecertificationperiod.Setbeforeexpiration();

            CertificationPage.Whenistherecertificationperiod.Start("15");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.EditAndAddCertificationContent('"' + GeneralCourseTitle + "_60562" + '"');
            CertificatePage.Click_backbutton();

            ContentDetailsPage.ClickCheckInbutton();


            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_60562" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_60562" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_60562");
            _test.Log(Status.Info, "Clicked searched course title");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_60562");
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_60562");
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_60562");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.Certification();

            CertificationPage.SearchCertification_Dashboard(CertificatrTitle + "_60562");
            _test.Log(Status.Info, "Search certification on the certification dashboard");
            CertificationPage.ClickSearchedCertification_Dashboard(CertificatrTitle + "_60562");
            _test.Log(Status.Info, "Click searched certification on the certification dashboard");
            Assert.IsTrue(CertificationDashboardDetailsPage.VerifyStatus("Certify"));
            _test.Log(Status.Info, "Verify user's status");

            CertificationPage.Click_OptionFromActionMenu("Recertify");
            _test.Log(Status.Info, "Click on recertify from action menu to recertify an Individual");
            CertificationDashboardDetailsPage.CertifyUsersModal.EnterReason();
            _test.Log(Status.Info, "Enter Reason");
            CertificationDashboardDetailsPage.CertifyUsersModal.ClickCertifyButton();
            _test.Log(Status.Info, "Click on Certify Button");

        }
        [Test, Order(35)]
        public void tc_62351_Redirect_old_certification_Console_to_new_Certification_page()
        {
            CommonSection.Administer.TrainingManagement.Certifications();
            _test.Log(Status.Info, "Navigate to Administer >> training >> Training Management >> Certifications");
            Assert.IsTrue(Driver.checkTitle("Certifications"));
            _test.Log(Status.Pass, "Verify page redirect to Certification console page"); 
        }
        [Test]
        public void tc_61178_As_an_admin_I_want_to_update_expiration_date_of_a_certified_individual_learner_for_a_recurring_certifications()
        {

        }
        
    }
}

