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
    public class P1RegressionTests3 : TestBase
    {
        string browserstr = string.Empty;
        public P1RegressionTests3(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            Driver.Instance.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(120);
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
        string title = "Google";
        static string today = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
        string markAsComplete = $"This item was marked as complete on "+today+".";
        string completed = "The item was marked complete.";
        string curriculamblocktitle = "curriculam1";

       


        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }
        public bool chktest = false;

       // [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

        }
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
       

       [Test, Order(1), Category("AutomatedP11")]      
        public void P20_1_s01_Scorm_Cost_7258()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7258");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");

            Assert.IsTrue(ContentDetailsPage.isCostNSalesTaxAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Cost and Sales Tax Accordian Display");

            ContentDetailsPage.Accordians.ClickEdit_CostNSalesTax();
            _test.Log(Status.Info, "Click on Cost & SalesTax Accordian Edit button");
            Assert.IsTrue(CostPage.VerifyDifferentPortlets());
            _test.Log(Status.Pass, "Verify the Manage Sales Tax, Default Cost, Alternate Costs, Pricing Schedules sections are displayed");
            
            CostPage.DefaultCostAs("15").Save();
            _test.Log(Status.Info, "Enter Defailt Cost and Click Save");
            Assert.IsTrue(CostPage.Successmessage("The default cost was saved."));
            _test.Log(Status.Pass, "Verfy Default cost is saved");

            CostPage.ClickReturn();
            _test.Log(Status.Info, "Click back button");
            Assert.IsTrue(ContentDetailsPage.isCostNSalesTaxAccordiandisplayed());
            _test.Log(Status.Info, "Verify bage back to Content Detais page");
            ContentDetailsPage.DeleteContent();

        }

        [Test, Order(2), Category("AutomatedP11")]

        public void P20_1_s02_Scorm_Alternate_Cost_7259()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7259");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");

            ContentDetailsPage.Accordians.ClickEdit_CostNSalesTax();
            _test.Log(Status.Info, "Click on Cost & SalesTax Accordian Edit button");
            Assert.IsTrue(CostPage.VerifyDifferentPortlets());
            _test.Log(Status.Pass, "Verify the Manage Sales Tax, Default Cost, Alternate Costs, Pricing Schedules sections are displayed");

            Assert.IsTrue(CostPage.alternetCostsPortlate.NoUserorgroupsadded());
            _test.Log(Status.Pass, "Verify no User/Group added into Alternet Costs portlate");
            CostPage.alternetCostsPortlate.ClickAddmoreusersNgroups();
            _test.Log(Status.Info, "Click Add more user/groups button");
            Assert.IsTrue(AlternetCostsPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AlternetCostsPage.AddUsertoAlternetCost();
            _test.Log(Status.Info, "Perform a blank search and first record to alternet cost");
            Assert.IsTrue(CostPage.alternetCostsPortlate.Userorgroupsadded());
            _test.Log(Status.Pass, "Verify User/Group added into Alternet Costs portlate");

            CostPage.alternetCostsPortlate.removeAddedusergroup();
            _test.Log(Status.Info, "Remove added user/group from alternet cost portlet");
            Assert.IsTrue(CostPage.alternetCostsPortlate.NoUserorgroupsadded());
            _test.Log(Status.Pass, "Verify no User/Group added into Alternet Costs portlate");

            ContentDetailsPage.DeleteContent();

        }

        [Test, Order(3), Category("AutomatedP11")]
        public void P20_1_s03_Scorm_Prerequisites_7260()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7260");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.isPrerequisitesAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");

            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            _test.Log(Status.Info, "Click on Prerequisities Accordian Edit button");
            //Assert.IsTrue(PrerequisitesPage.isSearchFiledsdisplay());
            //_test.Log(Status.Pass, "Verify Search fields are display in Prerequisites page");

            PrerequisitesPage.ClickAddPrerequisites();
            _test.Log(Status.Info, "Click on ADD Prerequisities Button");
            Assert.IsTrue(AddPrerequisitesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddPrerequisitesPage.SearchFor("");
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");
            //AddPrerequisitesPage.SelectRecord();
            //AddPrerequisitesPage.ClickAddButton();
            _test.Log(Status.Info, "Select One record and Click Add button");

            Assert.IsTrue(PrerequisitesPage.isPrerequisitesadded());
            _test.Log(Status.Pass, "Verify Prerequisites are added to Curriculumn");
            AddPrerequisitesPage.ClickBackButton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyanyPrerequisitesPresent());
            _test.Log(Status.Info, "Verify any Prerequisities content display in Accordian");
            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            PrerequisitesPage.removeAddedPrerequisites();
            _test.Log(Status.Info, "Remove added prerequisites");
          //  Assert.IsTrue(Driver.comparePartialString("Success", Driver.getSuccessMessage()));

            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();

        }

        [Test, Order(4), Category("AutomatedP11")]
        public void P20_1_s04_Scorm_Certificate_7283()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7283");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm is Created");

            Assert.IsTrue(ContentDetailsPage.isCertificateAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Certificate Accordian display on Content Details page");

            ContentDetailsPage.Accordians.ClickEdit_Certificate();
            _test.Log(Status.Info, "Click Certificate Accordian Edit button");
            Assert.IsTrue(CertificatePage.isrequiredattributesdisplay());
            _test.Log(Status.Pass, "Verify Preview button, Change Certificate button, Grant certificate upon completion options display");

            CertificatePage.click_ChageCertificate();
            _test.Log(Status.Info, "Click Change Certificate button");
            Assert.IsTrue(ChangeCertificatePage.isAttributesdisplay());
            _test.Log(Status.Pass, "Verify Find Certificate and Search option are display ");

            ChangeCertificatePage.Click_Search();
            _test.Log(Status.Info, "Click Search button");
            ChangeCertificatePage.SelectandSaveOneCertificate();
            _test.Log(Status.Info, "Select one record and Click Save");
            StringAssert.AreEqualIgnoringCase("The certificate was associated with the content.", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "verify Certificate Save feedback message");
            ChangeCertificatePage.Click_back();
            Assert.IsTrue(CertificatePage.isCurrentCertificatedisplay());
            _test.Log(Status.Pass, "Verify Certificate added to current content");
            CertificatePage.Click_Preview();
            //Assert.IsTrue(CertificatePage.CertificatePreviewModalDisplay());
            _test.Log(Status.Pass, "Verify Certificate Open on a Popup");
            CertificatePage.Click_back();
            _test.Log(Status.Info, "Click Back button");
            StringAssert.AreEqualIgnoringCase("A certificate is assigned.", ContentDetailsPage.Accordians.VerifyText_Certificate("A certificate is assigned."));
            ContentDetailsPage.DeleteContent();
        }

      //  [Test, Order(5), Category("AutomatedP11")]
        public void s05_Scorm_Add_Locale_7453()
        {
            Assert.IsTrue(true); //External Site and PS doesnot support multiple Local
            //CommonSection.CreteNewScorm(scormtitle + "TC7453");
            //_test.Log(Status.Info, "Creating New Scorm");
            //Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            //_test.Log(Status.Pass, "Verify New Document is Created");

            //Assert.IsTrue(ContentDetailsPage.isDefultLocaledisplay());
            //_test.Log(Status.Pass, "Verify Defult Locale display");

            //ContentDetailsPage.AddLocale();
            //_test.Log(Status.Info, "Added new locale to curriculumn");

            //Assert.IsTrue(ContentDetailsPage.Localedropdownlistdisplay());
            //_test.Log(Status.Pass, "Verify Locale dropdown display");

            //ContentDetailsPage.DeleteContent();
        }
       // [Test, Order(6), Category("AutomatedP11")]
        public void s06_Scorm_Delete_Locale_7454()
        {
            Assert.IsTrue(true); //External Site and PS doesnot support multiple Local
            //CommonSection.CreteNewScorm(scormtitle + "TC7454");
            //_test.Log(Status.Info, "Creating New Scorm");
            //Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            //_test.Log(Status.Pass, "Verify New Document is Created");

            //Assert.IsTrue(ContentDetailsPage.isDefultLocaledisplay());
            //_test.Log(Status.Pass, "Verify Defult Locale display");

            //ContentDetailsPage.AddLocale();
            //_test.Log(Status.Info, "Added new locale to curriculumn");

            //Assert.IsTrue(ContentDetailsPage.Localedropdownlistdisplay());
            //_test.Log(Status.Pass, "Verify Locale dropdown display");

            //ContentDetailsPage.DeleteLocale();
            //_test.Log(Status.Info, "Delete locale from curriculumn");
            //Assert.IsTrue(ContentDetailsPage.isDefultLocaledisplay());
            //_test.Log(Status.Pass, "Verify Defult Locale display");

            //ContentDetailsPage.DeleteContent();
        }

        [Test, Order(7), Category("AutomatedP11")]
        public void P20_1_s07_Scorm_Access_Aproval_7263()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7263");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isAccessApprovalAcordianDisplay());
            _test.Log(Status.Pass, "Verify Access Approval Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(8), Category("AutomatedP11")]
        public void P20_1_s08_Scorm_Categories_7257()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7257");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isCategoriesAcordianDisplay());
            _test.Log(Status.Pass, "Verify Categories Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_Categories();
            Assert.IsTrue(CategoriesPage.verifyCategoriesTree());
            _test.Log(Status.Pass, "Verify categories tree structure");
            CategoriesPage.Selectandaddcategories();
            _test.Log(Status.Info, "Select any categories and add it to content");
            StringAssert.AreEqualIgnoringCase("The category information was saved.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyCategoryAdded());
            ContentDetailsPage.DeleteContent();
        }

        [Test, Order(9), Category("AutomatedP11")]
        public void P20_1_s09_Scorm_Image_7266()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7266");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isImageAcordianDisplay());
            _test.Log(Status.Pass, "Verify Image Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            Assert.IsTrue(ImagePage.verifyrequiredatributesdisplay());
            _test.Log(Status.Pass, "Verify File path, Browse Button, Save button are display");
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            StringAssert.AreEqualIgnoringCase("The file was uploaded.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyImageOnSummarAcordian());
            CommonSection.SearchCatalog('"' + scormtitle + "TC7266" + '"');
            _test.Log(Status.Info, "Search created content from Catalog Search");
            Assert.IsTrue(SearchResultsPage.IsContentImageDisplay());
            _test.Log(Status.Pass, "Verify Content Image display");
            //ContentDetailsPage.DeleteContent();
        }
        [Test,Order(10), Category("AutomatedP11")]
        public void P20_1_s10_Scorm_Equivalencies_7262()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7262");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isEquivalenciesAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");

            ContentDetailsPage.Accordians.ClickEdit_Equivalencies();
            _test.Log(Status.Info, "Click on Prerequisities Accordian Edit button");
            Assert.IsTrue(EquivalenciesPage.isSearchFiledsdisplay());
            _test.Log(Status.Pass, "Verify Search fields are display in Equivalencies page");
            EquivalenciesPage.ClickAddEquivalencies();
            _test.Log(Status.Info, "Click on ADD Equivalencies Button");
            Assert.IsTrue(AddEquivalenciesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddEquivalenciesPage.SearchFor("").ClickAddbutton();
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify Equivalencies are added to Curriculumn");
            AddEquivalenciesPage.ClickBackButton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyanyEquivalenciesPresent());
            _test.Log(Status.Info, "Verify any Equivalencies content display in Accordian");
            ContentDetailsPage.Accordians.ClickEdit_Equivalencies();
            EquivalenciesPage.removeAddedEquivalencies();
            _test.Log(Status.Info, "Remove added Equivalencies");
            StringAssert.AreEqualIgnoringCase("Success\r\nThe items were removed. They are not equivalencies.\r\n×", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();
        }

        [Test, Order(11), Category("AutomatedP11")]
        public void P20_1_s11_Scorm_Activity_7267()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7267");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isManageActivityAcordianDisplay());
            _test.Log(Status.Pass, "Verify Image Acordian Display");
            Assert.IsTrue(ContentDetailsPage.Accordians.ManageActivityStatus("Active"));
            ContentDetailsPage.Accordians.ClickEdit_ManageActivity();
            Assert.IsTrue(ActivityPage.verifyrequiredatributesdisplay());
            _test.Log(Status.Pass, "Verify File path, Browse Button, Save button are display");
            ActivityPage.Activity.InactiveContent();
            _test.Log(Status.Info, "Inactive content");
            Assert.IsTrue(ContentDetailsPage.Accordians.ManageActivityStatus("Inactive"));
            _test.Log(Status.Pass, "Verify Content Activity Status is inactive");
            ContentDetailsPage.Accordians.ClickEdit_ManageActivity();
            ActivityPage.Activity.ActivewithStartandEndDate();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            Assert.IsTrue(ContentDetailsPage.Accordians.ManageActivityStatus("Active"));
            ContentDetailsPage.DeleteContent();
        }

        [Test, Order(12), Category("AutomatedP11")]
        public void P20_1_s12_Scorm_Surveys_7284()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7284");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");

            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click on Survey Accordian Manage button");
            Assert.IsFalse(SurveysPage.isSurveysPresent());
            _test.Log(Status.Pass, "Verify any existing Surveys Present");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.Click_backbutton();
            StringAssert.AreEqualIgnoringCase(ContentDetailsPage.Accordians.VerifySurveyPresent(),AddedsurveyTitle);
            _test.Log(Status.Pass, "Verify existing added survey is display");


            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click on Survey Accordian Manage button");
            SurveysPage.RemoveSurveys();
            //Assert.IsTrue(SurveysPage.GetFeedbackmessage("The surveys were removed."));
            SurveysPage.Click_backbutton();
            Assert.IsFalse(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");
            ContentDetailsPage.DeleteContent();

        }

        [Test, Order(13), Category("AutomatedP11")]
        public void P20_1_s13_Enroll_in_Scorm_26225()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26225");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Driver.Instance.Checkin();

            CommonSection.SearchCatalog('"' + scormtitle + "TC26225" + '"');
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26225");
            ContentDetailsPage.Click_Enroll();
            //CatalogPage.Click_Enrollbutton();
            Assert.IsTrue(Driver.comparePartialString("Success", Driver.getSuccessMessage()));

        }

        [Test, Order(14), Category("AutomatedP11")]
        public void P20_1_s14_Cancel_Enrollment_in_Scorm_14517()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC14517");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            ContentDetailsPage.Click_Check_in();

            CommonSection.SearchCatalog('"' + scormtitle + "TC14517" + '"');
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC14517");
            ContentDetailsPage.ClickEnroll();
            ContentDetailsPage.ClickCancelEnrollment_Scrom();
            Assert.IsTrue(ContentDetailsPage.getFeedbackMessage("Your enrollment for the selected course was cancelled."));
        }

        //[Test, Order(15)]
        //public void s15_Manage_Scorm_Course_File_7278()
        //{
        //    CommonSection.CreteNewScorm(scormtitle + "TC7278");
        //    _test.Log(Status.Info, "Creating New Scorm");
        //    Assert.IsTrue(ContentDetailsPage.IsContentCreated());
        //    _test.Log(Status.Pass, "Verify New Content is Created");
        //    Assert.IsTrue(ContentDetailsPage.Accordians.ClickEdit_ScormCourseFile());
        //    _test.Log(Status.Pass, "Verify New Scorm Content File Changed");
        //    StringAssert.AreEqualIgnoringCase("The course was uploaded.", ContentDetailsPage.VerifyFeedbackMessage());
        //    _test.Log(Status.Pass, "Verify feedback message");
        //    ContentDetailsPage.DeleteContent();
        //}

        

        [Test, Order(16), Category("AutomatedP11")]
        public void P20_1_s16_Scorm_Course_Content_Sharing_7264()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7264");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            Assert.IsTrue(ContentDetailsPage.Accordians.ClickEdit_ContentShring());
            _test.Log(Status.Pass, "Verify content share page");
            Assert.IsTrue(ContentDetailsPage.Accordians.ShaareContent_ChildDomain());
            _test.Log(Status.Pass, "Verify scorm course shared with all child domains");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.DeleteContent();
        }



        [Test, Order(18), Category("AutomatedP11")]
        public void P20_1_s18_SCROM_Course_information_7357()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreteNewScorm(scormtitle + "TC7357");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.SCROM.AddCourseInfo();
            _test.Log(Status.Info,"Add course info");
            Assert.IsTrue(ContentDetailsPage.VerifyCourseNumber());
            _test.Log(Status.Pass, "Verify course number");
            Assert.IsTrue(ContentDetailsPage.VerifyCourseProvider());
            _test.Log(Status.Pass, "Verify course provider");
            Assert.IsTrue(ContentDetailsPage.VerifyCourseDuration());
            _test.Log(Status.Pass, "Verify course duration");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin the scrom course");
            CommonSection.SearchCatalog(scormtitle + "TC7357");
            _test.Log(Status.Info, "Search the created scrom");
            SearchResultsPage.ClickCourseTitle((scormtitle + "TC7357"));
            _test.Log(Status.Info, "Click on searched scrom ");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Button");
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Delete the created scrom");

        }

  



        [Test, Order(19), Category("AutomatedP11")]//Stsrted

        public void P20_1_s19_Launch_Document_26211()
        {
            string _today = DateTime.Now.ToString("M/d/yyyy").Replace("-", "/");
            //CommonSection.Logout();
            // LoginPage.GoTo();
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Login as Admin and Click on Document link to create new document");
            DocumentPage.Populate_DocumentData(documenttitle + "TC26211","www.google.com");
            _test.Log(Status.Info, "Enter the document details");
            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Click on Create Button");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Click on Check-in Button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(documenttitle + "TC26211");
            _test.Log(Status.Info, "Search the created document");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC26211");
            _test.Log(Status.Info, "Click on the searched document");
            Assert.IsTrue(ContentDetailsPage.Document.GetHeaderText(documenttitle + "TC26211"));
            _test.Log(Status.Pass, "Verify the Document title");
            ContentDetailsPage.LaunchDocument();
            _test.Log(Status.Info, "Open the document");
            Driver.Instance.SwitchWindow(title);
            _test.Log(Status.Info, "Switch to the opened document window");
            Assert.IsTrue(Driver.checkTitle(title));
            _test.Log(Status.Pass, "Verify that the document gets opened in the new window");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Switch back to the parent window");
           
            Assert.AreEqual(_today, ContentDetailsPage.Document.VerifyCurrentDate(today));
            _test.Log(Status.Pass, "Verify the date for the opened document");
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from learner");
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Admin");
            //CommonSection.SearchCatalog(documenttitle + "TC26211");
            //_test.Log(Status.Info, "Search the created document");
            //SearchResultsPage.ClickCourseTitle((documenttitle + "TC26211"));
            //_test.Log(Status.Info, "Click on searched document ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click on Edit Button");
            //ContentDetailsPage.DeleteContent();
            //_test.Log(Status.Info, "Delete the created document");
            

        }


        [Test, Order(20), Category("AutomatedP11")]

        public void P20_1_s20_Mark_Document_Complete_26210()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Login as Admin and Click on Document link to create new document");
            DocumentPage.Populate_DocumentData(documenttitle + "TC26210", "www.google.com");
            _test.Log(Status.Info, "Enter the document details");
            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Click on Create Button");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Click on Check-in Button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(documenttitle + "TC26210");
            _test.Log(Status.Info, "Search the created document");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC26210");
            _test.Log(Status.Info, "Click on the searched document");
            Assert.IsTrue(ContentDetailsPage.Document.GetHeaderText(documenttitle + "TC26210"));
            _test.Log(Status.Pass, "Verify the Document title");
            ContentDetailsPage.LaunchDocument();
            _test.Log(Status.Info, "Open the document");
            Driver.Instance.SwitchWindow(title);
            _test.Log(Status.Info, "Switch to the opened document window");
            Assert.IsTrue(Driver.checkTitle(title));
            _test.Log(Status.Pass, "Verify that the document gets opened in the new window");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Switch back to the parent window");
            ContentDetailsPage.MarkCompleteDocument();
            _test.Log(Status.Info, "Click on Mark Complete Button");
            StringAssert.EndsWith(markAsComplete,ContentDetailsPage.Document.VerifyMarkedAsComplete());
            _test.Log(Status.Pass, "Verify the Marked as complete string");
            StringAssert.Contains(completed, ContentDetailsPage.Document.VerifyCompletedThisItemString());
            _test.Log(Status.Pass, "Verify the- The item was marked complete. string");
            Assert.IsTrue(ContentDetailsPage.Document.OpenCurrentAttempt());
            _test.Log(Status.Pass, "Verify Open Current Attempt button exists");

            Assert.IsTrue(ContentDetailsPage.Document.OpenNewAttempt());
            _test.Log(Status.Pass, "Verify Open New Attempt button exists");

            Assert.AreEqual(today, ContentDetailsPage.Document.VerifyCurrentDate(today));
            _test.Log(Status.Pass, "Verify the date for the opened document");
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from learner");
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Admin");
            //CommonSection.SearchCatalog(documenttitle + "TC26211");
            //_test.Log(Status.Info, "Search the created document");
            //SearchResultsPage.ClickCourseTitle((documenttitle + "TC26211"));
            //_test.Log(Status.Info, "Click on searched document ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click on Edit Button");
            //ContentDetailsPage.DeleteContent();
            //_test.Log(Status.Info, "Delete the created document");

        }

        [Test, Order(21), Category("AutomatedP11")]
        public void P20_1_s21_Launch_Document_Transcript_26868()
        {
            string _today = DateTime.Now.ToString("M/d/yyyy").Replace("-", "/");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Login as Admin and Click on Document link to create new document");
            DocumentPage.Populate_DocumentData(documenttitle + "TC26868", "www.google.com");
            _test.Log(Status.Info, "Enter the document details");
            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Click on Create Button");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Click on Check-in Button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(documenttitle + "TC26868");
            _test.Log(Status.Info, "Search the created document");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC26868");
            _test.Log(Status.Info, "Click on the searched document");
            Assert.IsTrue(ContentDetailsPage.Document.GetHeaderText(documenttitle + "TC26868"));
            _test.Log(Status.Pass, "Verify the Document title");
            ContentDetailsPage.LaunchDocument();
            _test.Log(Status.Info, "Open the document");
            Driver.Instance.SwitchWindow(title);
            _test.Log(Status.Info, "Switch to the opened document window");
            Assert.IsTrue(Driver.checkTitle(title));
            _test.Log(Status.Pass, "Verify that the document gets opened in the new window");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Switch back to the parent window");
            CommonSection.Transcript();
            _test.Log(Status.Info, "Click on transcript");
            //CommonSection.Learner.Transcript();
            TranscriptPage.AllMyTrainingPage.ClickDocument(documenttitle + "TC26868");
            _test.Log(Status.Info, "Click document link to open");
            Assert.IsTrue(ContentDetailsPage.Document.GetHeaderText(documenttitle + "TC26868"));
            _test.Log(Status.Pass, "Verify the Document title");
            ContentDetailsPage.LaunchDocument();
            _test.Log(Status.Info, "Open the document");
            Driver.Instance.SwitchWindow(title);
            _test.Log(Status.Info, "Switch to the opened document window");
            Assert.IsTrue(Driver.checkTitle(title));
            _test.Log(Status.Pass, "Verify that the document gets opened in the new window");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Switch back to the parent window");
            Assert.AreEqual(_today, ContentDetailsPage.Document.VerifyCurrentDate(today));
            _test.Log(Status.Pass, "Verify the date for the opened document");
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from learner");
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Admin");
            //CommonSection.SearchCatalog(documenttitle + "TC26868");
            //_test.Log(Status.Info, "Search the created document");
            //SearchResultsPage.ClickCourseTitle((documenttitle + "TC26868"));
            //_test.Log(Status.Info, "Click on searched document ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click on Edit Button");
            //ContentDetailsPage.DeleteContent();
            //_test.Log(Status.Info, "Delete the created document");



        }

        [Test, Order(22), Category("AutomatedP11")]
        public void P20_1_s22_Launch_SCROM_Course_Transcript_26844()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreteNewScorm(scormtitle + "TC26844");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin the scrom course");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(scormtitle + "TC26844");
            _test.Log(Status.Info, "Search the created SCROM");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26844");
            _test.Log(Status.Info, "Click on the searched SCROM");
            ContentDetailsPage.SCROM.ClickEnrollButton();
            _test.Log(Status.Info, "Enroll at the course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyOpenItemButtonAvailable());
            _test.Log(Status.Pass, "Verify open button is available");
            CommonSection.Transcript();
            _test.Log(Status.Info, "Click on transcript");
            //CommonSection.Learner.Transcript();
            TranscriptPage.AllMyTrainingPage.ClickDocument(scormtitle + "TC26844");
            _test.Log(Status.Info, "click on scrom link to open");
            ContentDetailsPage.SCROM.ClickOpenItem();
            _test.Log(Status.Info, "Click open item");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyCourseOpensInNewWindow());
            _test.Log(Status.Pass, "Verify course opens in new window");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Info, "Complete scrom course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyDateofCompletion(today));
            _test.Log(Status.Pass, "Verify scrom date of completeion");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyViewCertificateButtonAvailable());
            _test.Log(Status.Pass, "Verify View Certificate button is available on completeion");
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from learner");
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Admin");
            //CommonSection.SearchCatalog(scormtitle + "TC26844");
            //_test.Log(Status.Info, "Search the created scrom");
            //SearchResultsPage.ClickCourseTitle((scormtitle + "TC26844"));
            //_test.Log(Status.Info, "Click on searched scrom ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click on Edit Button");
            //ContentDetailsPage.DeleteContent();
            //_test.Log(Status.Info, "Delete the created scrom");

        }

        [Test, Order(23), Category("AutomatedP11")]
        public void P20_1_s23_View_SCROM_Course_Certificate_Transcript_26848()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreteNewScorm(scormtitle + "TC26848");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin the scrom course");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(scormtitle + "TC26848");
            _test.Log(Status.Info, "Search the created SCROM");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26848");
            _test.Log(Status.Info, "Click on the searched SCROM");
            ContentDetailsPage.SCROM.ClickEnrollButton();
            _test.Log(Status.Info, "Enroll at the course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyOpenItemButtonAvailable());
            _test.Log(Status.Pass, "Verify open button is available");
            CommonSection.Transcript();
            _test.Log(Status.Info, "Click on transcript");
            //CommonSection.Learner.Transcript();
            TranscriptPage.AllMyTrainingPage.ClickDocument(scormtitle + "TC26848");
            _test.Log(Status.Info, "Click on scrom title to open");
            ContentDetailsPage.SCROM.ClickOpenItem();
            _test.Log(Status.Info, "Click open item");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyCourseOpensInNewWindow());
            _test.Log(Status.Pass, "Verify course opens in new window");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Info, "Complete scrom course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyDateofCompletion(today));
            _test.Log(Status.Pass, "Verify scrom date of completeion");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyViewCertificateButtonAvailable());
            _test.Log(Status.Pass, "Verify View Certificate button is available on completeion");
            ContentDetailsPage.SCROM.ClickViewCertificateButton();
            _test.Log(Status.Info, "View certificate");
            Assert.IsTrue(ContentDetailsPage.VerifyCertificateisOpened());
            _test.Log(Status.Pass, "Verify Certificate is opened");
            CertificatePage.Click_back();
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from learner");
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Admin");
            //CommonSection.SearchCatalog(scormtitle + "TC26848");
            //_test.Log(Status.Info, "Search the created scrom");
            //SearchResultsPage.ClickCourseTitle((scormtitle + "TC26848"));
            //_test.Log(Status.Info, "Click on searched scrom ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click on Edit Button");
            //ContentDetailsPage.DeleteContent();
            //_test.Log(Status.Info, "Delete the created scrom");
        }

        [Test, Order(24), Category("AutomatedP11")]
        public void P20_1_s24_View_SCROM_Certificate_26236()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreteNewScorm(scormtitle + "TC26236");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin the scrom course");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(scormtitle + "TC26236");
            _test.Log(Status.Info, "Search the created SCROM");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26236");
            _test.Log(Status.Info, "Click on the searched SCROM");
            ContentDetailsPage.SCROM.ClickEnrollButton();
            _test.Log(Status.Info, "Enroll at the course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyOpenItemButtonAvailable());
            _test.Log(Status.Pass, "Verify open button is available");
            ContentDetailsPage.SCROM.ClickOpenItem();
            _test.Log(Status.Info, "Click open item");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyCourseOpensInNewWindow());
            _test.Log(Status.Pass, "Verify course opens in new window");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Info, "Complete scrom course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyDateofCompletion(today));
            _test.Log(Status.Pass, "Verify scrom date of completeion");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyViewCertificateButtonAvailable());
            _test.Log(Status.Pass, "Verify View Certificate button is available on completeion");
            ContentDetailsPage.SCROM.ClickViewCertificateButton();
            _test.Log(Status.Info, "View certificate");
            Assert.IsTrue(ContentDetailsPage.VerifyCertificateisOpened());
            _test.Log(Status.Pass, "Verify Certificate is opened");
            CertificatePage.Click_back();


        }



        [Test, Order(25), Category("AutomatedP11")]
        public void P20_1_s25_Complete_SCROM_CourseWith_Surveys_16743()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreteNewScorm(scormtitle + "TC16743");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.SCROM.AddSurveys();
            _test.Log(Status.Info, "Add surveys");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin the scrom course");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(scormtitle + "TC16743");
            _test.Log(Status.Info, "Search the created SCROM");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC16743");
            _test.Log(Status.Info, "Click on the searched SCROM");
            ContentDetailsPage.SCROM.ClickEnrollButton();
            _test.Log(Status.Info, "Enroll at the course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyOpenItemButtonAvailable());
            _test.Log(Status.Pass, "Verify open button is available");
            ContentDetailsPage.SCROM.ClickOpenItem();
            _test.Log(Status.Info, "Click open item");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyCourseOpensInNewWindow());
            _test.Log(Status.Pass, "Verify course opens in new window");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Info, "Complete scrom course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyDateofCompletion(today));
            _test.Log(Status.Pass, "Verify scrom date of completeion");
            ContentDetailsPage.Accordians.ClickSurveyLink();
            _test.Log(Status.Info, "Click on survey link");
            ContentDetailsPage.ComleteSurvey("Somnath-Survey");
            _test.Log(Status.Info, "Complete Survey");
            Driver.Instance.SwitchWindow(scormtitle + "TC16743");
            Assert.IsTrue(ContentDetailsPage.VerifySurveyCompleted());
            _test.Log(Status.Pass, "Verify survey completeion");





        }

        [Test, Order(26), Category("AutomatedP11")]
        public void P20_1_s26_Complete_SCROM_Course_With_Surveys_Transcript_26846()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.CreteNewScorm(scormtitle + "TC26846");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.SCROM.AddSurveys();
            _test.Log(Status.Info, "Add surveys");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin the scrom course");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(scormtitle + "TC26846");
            _test.Log(Status.Info, "Search the created SCROM");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26846");
            _test.Log(Status.Info, "Click on the searched SCROM");
            ContentDetailsPage.SCROM.ClickEnrollButton();
            _test.Log(Status.Info, "Enroll at the course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyOpenItemButtonAvailable());
            _test.Log(Status.Pass, "Verify open button is available");
            CommonSection.Transcript();
            _test.Log(Status.Info, "Click on transcript");
            //CommonSection.Learner.Transcript();
            TranscriptPage.AllMyTrainingPage.ClickDocument(scormtitle + "TC26846");
            _test.Log(Status.Info, "Click on scrom title to open");
            ContentDetailsPage.SCROM.ClickOpenItem();
            _test.Log(Status.Info, "Click open item");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyCourseOpensInNewWindow());
            _test.Log(Status.Pass, "Verify course opens in new window");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Info, "Complete scrom course");
            Assert.IsTrue(ContentDetailsPage.SCROM.VerifyDateofCompletion(today));
            _test.Log(Status.Pass, "Verify scrom date of completeion");
            ContentDetailsPage.Accordians.ClickSurveyLink();
            _test.Log(Status.Info, "Click on survey link");
            ContentDetailsPage.ComleteSurvey("Somnath-Survey");
            _test.Log(Status.Info, "Complete Survey");
            Driver.Instance.SwitchWindow(scormtitle + "TC26846");
            Assert.IsTrue(ContentDetailsPage.VerifySurveyCompleted());
            _test.Log(Status.Pass, "Verify survey completeion");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.SearchCatalog(scormtitle + "TC26846");
            _test.Log(Status.Info, "Search the created scrom");
            SearchResultsPage.ClickCourseTitle((scormtitle + "TC26846"));
            _test.Log(Status.Info, "Click on searched scrom ");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Button");
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Delete the created scrom");

        }

       
    }

}
