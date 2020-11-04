using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class P1RegressionTests2 : TestBase
    {
        string browserstr = string.Empty;
        public P1RegressionTests2(string browser)
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
      


        [Test, Order(1), Category("AutomatedP11")]
        public void P20_1_z01_Curriculumn_Cost_10825()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10825");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Curriculumn is Created");

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
        public void P20_1_z02_Curriculum_Alternate_Cost_10824()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10824");
            _test.Log(Status.Info, "Creating New Curriculumn");

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
        public void P20_1_z03_Curriculum_Prerequisites_10829()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10829");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.isPrerequisitesAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");

            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            _test.Log(Status.Info, "Click on Prerequisities Accordian Edit button");
            Assert.IsTrue(PrerequisitesPage.isSearchFiledsdisplay());
            _test.Log(Status.Pass, "Verify Search fields are display in Prerequisites page");

            PrerequisitesPage.ClickAddPrerequisites();
            _test.Log(Status.Info, "Click on ADD Prerequisities Button");
            Assert.IsTrue(AddPrerequisitesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddPrerequisitesPage.SearchFor("");
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");

            Assert.IsTrue(PrerequisitesPage.isPrerequisitesadded());
            _test.Log(Status.Pass, "Verify Prerequisites are added to Curriculumn");
            AddPrerequisitesPage.ClickBackButton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyanyPrerequisitesPresent());
            _test.Log(Status.Info, "Verify any Prerequisities content display in Accordian");
            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            PrerequisitesPage.removeAddedPrerequisites();
            _test.Log(Status.Info, "Remove added prerequisites");
           // StringAssert.AreEqualIgnoringCase("The selected items were removed and are no longer prerequisites.", (Driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();

        }
        [Test, Order(4), Category("AutomatedP11")]
        public void P20_1_z04_Curriculum_Certificate_10830()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10830");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");

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
            Driver.focusParentWindow();
            ContentDetailsPage.DeleteContent();
        }
       // [Test, Order(5), Category("AutomatedP11")]
        public void z05_Curriculumn_Add_Locale_10835()
        {
            Assert.IsTrue(true); // As external and PS support only one Local
            //CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10835");
            //_test.Log(Status.Info, "Creating New Curriculumn");
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
        public void z06_Curriculumn_Delete_Locale_10836()
        {
           // Assert.IsTrue(true); // As external and PS support only one Local
            //CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10824");
            //_test.Log(Status.Info, "Creating New Curriculumn");
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
        public void P20_1_z07_Curriculumn_Access_Aproval_10831()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10831");
            _test.Log(Status.Info, "Creating New Curriculumn");
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
        public void P20_1_z08_Curriculumn_Categories_10826()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10826");
            _test.Log(Status.Info, "Creating New Curriculumn");
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
        public void P20_1_z09_Curriculumn_Image_10827()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10827");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isImageAcordianDisplay());
            _test.Log(Status.Pass, "Verify Image Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            Assert.IsTrue(ImagePage.verifyrequiredatributesdisplay());
            _test.Log(Status.Pass, "Verify File path, Browse Button, Save button are display");
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            StringAssert.AreEqualIgnoringCase("The file was uploaded.", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyImageOnSummarAcordian());
            CommonSection.SearchCatalog('"' + curriculamtitle + "TC10827" + '"');
            _test.Log(Status.Info, "Search created content from Catalog Search");
            Assert.IsTrue(SearchResultsPage.IsContentImageDisplay());
            _test.Log(Status.Pass, "Verify Content Image display");

        }
        [Test, Order(10), Category("AutomatedP11")]
        public void P20_1_z10_Curriculumn_Equivalencies_10828()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10828");
            _test.Log(Status.Info, "Creating New Curriculumn");
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
        public void P20_1_z11_Curriculumn_Activity_10833()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10833");
            _test.Log(Status.Info, "Creating New Curriculumn");
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
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            Assert.IsTrue(ContentDetailsPage.Accordians.ManageActivityStatus("Active"));
            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(12), Category("AutomatedP11")]
        public void P20_1_z12_Curriculumn_Check_In_Out_10840()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10840");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isContentDetailsPageEditable());
            _test.Log(Status.Pass, "Verify Content Detail page is edit mode and Check in button display");

            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click Content Check-in button");

            Assert.IsTrue(ContentDetailsPage.isContentDetailsPageNonEditable());
            _test.Log(Status.Pass, "Verify Content Detail page is in only view mode and Check in button display");
            ContentDetailsPage.DeleteContent();
        }

        [Test, Order(13), Category("AutomatedP11")]
        public void P20_1_z13_Curriculumn_Surveys_10837()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10837");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");

            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click on Survey Accordian Manage button");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            string[] sur = Regex.Split(AddedsurveyTitle, "\r");
            string AddedsurveyTitle1 = sur[0];
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.Click_backbutton();
            StringAssert.AreEqualIgnoringCase(ContentDetailsPage.Accordians.VerifySurveyPresent(), "A_Survey\r\nSurvey");
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

      
        [Test, Order(14), Category("AutomatedP11")]
        public void P20_1_z14_Search_and_Add_training_activities_15758()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC15758");
            _test.Log(Status.Info, "Creating New Curriculum");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            ContentDetailsPage.Accordians.ClickEdit_CurriculumContent();
            _test.Log(Status.Info, "Click Curricumn Content Edit button");
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("_UnOrdered");
            CurriculumContentPage.AddTrainingActivities_UnOrdered("General");
            //CurriculumContentPage.ClickAddCurriculumBlock();
            //CurriculumContentPage.AddCurriculumBlock.AddBlockAs("Test");
            //_test.Log(Status.Info, "Add a new block using Add Curriculum Block");
            //CurriculumContentPage.ClickAddTrainingActivities("General");
            //AddTrainingActivitiesPage.Search("Somnath-General-Course");
            //AddTrainingActivitiesPage.AddTraing();
            //Assert.IsTrue(AddTrainingActivitiesPage.verifyfeedbackmessage("The selected items were added."));
            //AddTrainingActivitiesPage.Click_backbutton();
            CurriculumContentPage.RemoveTrainingActivities();
            _test.Log(Status.Info, "Remove added training activities from content");
            Assert.IsTrue(CurriculumContentPage.GetSuccessMessage("The item was removed."));
            _test.Log(Status.Pass, "Verify Feedback message");
            ContentDetailsPage.DeleteContent();
           // CurriculumContentPage.ClickAddCurriculumBlock();
           // CurriculumContentPage.AddCurriculumBlock.AddBlockAs("AfreenBlock");
           // CurriculumContentPage.ClickAddTrainingActivities("General");
        }


        [Test, Order(15), Category("AutomatedP11")]
        public void P20_1_z15_Document_Cost_7336()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC7336");
            _test.Log(Status.Info, "Creating New Docuemnt");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");

            Assert.IsTrue(ContentDetailsPage.isCostNSalesTaxAccordiandisplayed());
            _test.Log(Status.Pass, "Verify New Curriculumn is Created");

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

        [Test, Order(16), Category("AutomatedP11")]
        public void P20_1_z16_Document_Alternate_Cost_7337()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC10824");
            _test.Log(Status.Info, "Creating New Curriculumn");

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
        [Test, Order(17), Category("AutomatedP11")]
        public void P20_1_z17_Document_Access_Aproval_7340()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC7340");
            _test.Log(Status.Info, "Creating New Document");
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
        [Test, Order(18),Category("AutomatedP11")]
        public void P20_1_z18_Document_Categories_7335()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC7335");
            _test.Log(Status.Info, "Creating New Document");
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
        [Test, Order(19), Category("AutomatedP11")]
        public void P20_1_z19_Document_Prerequisites_7338()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC7338");
            _test.Log(Status.Info, "Creating New Document");
            Assert.IsTrue(ContentDetailsPage.isPrerequisitesAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");

            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            _test.Log(Status.Info, "Click on Prerequisities Accordian Edit button");
            Assert.IsTrue(PrerequisitesPage.isSearchFiledsdisplay());
            _test.Log(Status.Pass, "Verify Search fields are display in Prerequisites page");

            PrerequisitesPage.ClickAddPrerequisites();
            _test.Log(Status.Info, "Click on ADD Prerequisities Button");
            Assert.IsTrue(AddPrerequisitesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddPrerequisitesPage.SearchFor("");
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");

            Assert.IsTrue(PrerequisitesPage.isPrerequisitesadded());
            _test.Log(Status.Pass, "Verify Prerequisites are added to Docuemnt");
            AddPrerequisitesPage.ClickBackButton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyanyPrerequisitesPresent());
            _test.Log(Status.Info, "Verify any Prerequisities content display in Accordian");
            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            PrerequisitesPage.removeAddedPrerequisites();
            _test.Log(Status.Info, "Remove added prerequisites");
            StringAssert.AreEqualIgnoringCase("Success\r\nThe selected items were removed and are no longer prerequisites.\r\n×", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();

        }
        [Test, Order(20), Category("AutomatedP11")]
        public void P20_1_z20_Document_Image_7343()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC7343");
            _test.Log(Status.Info, "Creating New Document");
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
            CommonSection.SearchCatalog('"' + documenttitle + "TC7343" + '"');
            _test.Log(Status.Info, "Search created content from Catalog Search");
            Assert.IsTrue(SearchResultsPage.IsContentImageDisplay());
            _test.Log(Status.Pass, "Verify Content Image display");
            //ContentDetailsPage.DeleteContent();
        }
        [Test, Order(21), Category("AutomatedP11")]
        public void P20_1_z21_Document_Equivalencies_7339()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC7339");
            _test.Log(Status.Info, "Creating New Document");
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
            AddEquivalenciesPage.SearchFor("general").ClickAddbutton();
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify Equivalencies are added to Document");
            AddEquivalenciesPage.ClickBackButton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyanyEquivalenciesPresent());
            _test.Log(Status.Info, "Verify any Equivalencies content display in Accordian");
            ContentDetailsPage.Accordians.ClickEdit_Equivalencies();
            EquivalenciesPage.removeAddedEquivalencies();
            _test.Log(Status.Info, "Remove added Equivalencies");
            StringAssert.AreEqualIgnoringCase("Success\r\nThe items were removed. They are not equivalencies.\r\n×", (Driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(22), Category("AutomatedP11")]
        public void P20_1_z22_Document_Activity_7344()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC7344");
            _test.Log(Status.Info, "Creating New Docuemnt");
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
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            Assert.IsTrue(ContentDetailsPage.Accordians.ManageActivityStatus("Active"));
            ContentDetailsPage.DeleteContent();
        }
        

   
        [Test, Order(24), Category("AutomatedP11")]
        public void P20_1_z24_Create_Classroom_Event_1989()
        {
            Assert.IsTrue(true);  // as this test cases coved in section management.
        }
        [Test, Order(25), Category("AutomatedP11")]
        public void P20_1_z25_Request_Access_to_Classroom_Course_26839()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC26839");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            // ManageClassroomCoursePage.SetEnrollmentStartDate("Currentdate-1");
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            //CommonSection.Logout();
            CommonSection.Avatar.Logout();
            LoginPage.LoginClick();
            LoginPage.LoginAs("3PGLearner").WithPassword("password").Login();
            CommonSection.SearchCatalog(classroomcoursetitle + "TC26839");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC26839");

          //  SectionsPage.SelectViewAsLearner();
           // _test.Log(Status.Pass, "Click view as learner");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");

        }
        [Test, Order(26), Category("AutomatedP11")] // Depend on Z38 first execute the Z
        public void P20_1_z26_Cancel_Access_Request_to_Classroom_Course_26840()
        {
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC26839" + '"');
            _test.Log(Status.Info, "Search created Classroom Course from Catalog");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC26839");
            _test.Log(Status.Info, "Click searched Classroom course title");
           // Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            //_test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.AccessApprovalModal.CancelRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
        }
        [Test, Order(27), Category("AutomatedP11")]
        public void P20_1_z27_Add_Classroom_Sections_to_Classroom_Training_Activities_10848()
        {
           // CommonSection.Logout();
            LoginPage.LoginClick();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC26840");
            _test.Log(Status.Pass, "New Classroom Course Created");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10848");
            _test.Log(Status.Info, "Creating New Curriculum");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            ContentDetailsPage.Accordians.ClickEdit_CurriculumContent();
            _test.Log(Status.Info, "Click Curricumn Content Edit button");
            //CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("_UnOrdered");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(classroomcoursetitle + "TC26840");
            //AddTrainingActivitiesPage.Search(classroomcoursetitle + "TC26839");  //depend on 26839
            //AddTrainingActivitiesPage.AddTraing();
            //Assert.IsTrue(AddTrainingActivitiesPage.verifyfeedbackmessage("The selected items were added."));
            //AddTrainingActivitiesPage.Click_backbutton();
            CurriculumContentPage.RemoveTrainingActivities();
            _test.Log(Status.Info, "Remove added training activities from content");
            Assert.IsTrue(CurriculumContentPage.GetSuccessMessage("The item was removed."));
            _test.Log(Status.Pass, "Verify Feedback message");
            ContentDetailsPage.DeleteContent();
        }

       
        [Test, Order(28), Category("AutomatedP11")]
        public void P20_1_z28_Request_Access_to_SCORM_Course_26230()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26230");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isAccessApprovalAcordianDisplay());
            _test.Log(Status.Pass, "Verify Access Approval Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            Driver.Instance.Checkout();
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click check in button");
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.SearchCatalog('"' + scormtitle + "TC26230" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26230");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
        }
        [Test, Order(29), Category("AutomatedP11")]
        public void P20_1_z29_Cancle_Request_Access_to_SCORM_Course_26233()
        {
            CommonSection.SearchCatalog('"' + scormtitle + "TC26230" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26230");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.AccessApprovalModal.CancelRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
        }
        [Test, Order(30), Category("AutomatedP11")]
        public void P20_1_z30_Request_Access_to_Document_26206()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC26206");
            _test.Log(Status.Info, "Creating New Document");
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
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click check in button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog('"' + documenttitle + "TC26206" + '"');
            _test.Log(Status.Info, "Search created document from Catalog");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC26206");
            _test.Log(Status.Info, "Click searched document title");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
        }
        [Test, Order(31), Category("AutomatedP11")]
        public void P20_1_z31_Cancel_Request_Access_to_Document_26207()
        {
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from Admin");
            //LoginPage.LoginAs("saiflearner").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog('"' + documenttitle + "TC26206" + '"');
            _test.Log(Status.Info, "Search created document from Catalog");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC26206");
            _test.Log(Status.Info, "Click searched document title");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.AccessApprovalModal.CancelRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
        }
       

    }

}
