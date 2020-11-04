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
    //[TestFixture("chbs", Category = "chrome")]
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
        string markAsComplete = $"This item was marked as complete on " + today + ".";
        string completed = "The item was marked complete.";
        string curriculamblocktitle = "curriculam1";




        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }
        public bool chktest = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

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
                    //if (!Meridian_Common.isadminlogin)
                    //{
                    //    CommonSection.Logout();
                    //    LoginPage.LoginAs("").WithPassword("").Login();
                    //}


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
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }


        [Test, Order(1), Category("AutomatedP1")]
        public void z01_Curriculumn_Cost_10825()
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
        [Test, Order(2), Category("AutomatedP1")]
        public void z02_Curriculum_Alternate_Cost_10824()
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
        [Test, Order(3), Category("AutomatedP1")]
        public void z03_Curriculum_Prerequisites_10829()
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
            StringAssert.AreEqualIgnoringCase("The selected items were removed and are no longer prerequisites.", (PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();

        }
        [Test, Order(4), Category("AutomatedP1")]
        public void z04_Curriculum_Certificate_10830()
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
            StringAssert.AreEqualIgnoringCase("The certificate was associated with the content.", ChangeCertificatePage.FeedbackMessage("The certificate was associated with the content."));
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
        [Test, Order(5), Category("AutomatedP1")]
        public void z05_Curriculumn_Add_Locale_10835()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10835");
            _test.Log(Status.Info, "Creating New Curriculumn");
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
        [Test, Order(6), Category("AutomatedP1")]
        public void z06_Curriculumn_Delete_Locale_10836()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10824");
            _test.Log(Status.Info, "Creating New Curriculumn");
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
        [Test, Order(7), Category("AutomatedP1")]
        public void z07_Curriculumn_Access_Aproval_10831()
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
        [Test, Order(8), Category("AutomatedP1")]
        public void z08_Curriculumn_Categories_10826()
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
        [Test, Order(9), Category("AutomatedP1")]
        public void z09_Curriculumn_Image_10827()
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
            StringAssert.AreEqualIgnoringCase("The file was uploaded.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyImageOnSummarAcordian());
            CommonSection.SearchCatalog('"' + curriculamtitle + "TC10827" + '"');
            _test.Log(Status.Info, "Search created content from Catalog Search");
            Assert.IsTrue(SearchResultsPage.IsContentImageDisplay());
            _test.Log(Status.Pass, "Verify Content Image display");

        }
        [Test, Order(10), Category("AutomatedP1")]
        public void z10_Curriculumn_Equivalencies_10828()
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
            StringAssert.AreEqualIgnoringCase("The items were removed. They are not equivalencies.", (EquivalenciesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();
        }

        [Test, Order(11), Category("AutomatedP1")]
        public void z11_Curriculumn_Activity_10833()
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
        [Test, Order(12), Category("AutomatedP1")]
        public void z12_Curriculumn_Check_In_Out_10840()
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

        [Test, Order(13), Category("AutomatedP1")]
        public void z13_Curriculumn_Surveys_10837()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10837");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");

            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click on Survey Accordian Manage button");
            Assert.IsTrue(SurveysPage.isSurveysPresent());
            _test.Log(Status.Pass, "Verify any existing Surveys Present");
            SurveysPage.ClickAssignSurveys();
            _test.Log(Status.Info, "Click on Assign Surveys Button");

            Assert.IsTrue(AddServeysPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search for, Search Type, Save button, Back button display");
            AddServeysPage.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            Assert.IsTrue(SurveysPage.isSurveysAdded());
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click on Survey Accordian Manage button");
            SurveysPage.RemoveSurveys();
            Assert.IsTrue(SurveysPage.GetFeedbackmessage("The surveys were removed."));
            SurveysPage.Click_backbutton();
            Assert.IsFalse(ContentDetailsPage.Accordians.VerifySurveyPresnet());
            _test.Log(Status.Pass, "Verify Prerequisites Accordian Display");
            ContentDetailsPage.DeleteContent();

        }

        [Test, Order(14)]
        public void z14_Enroll_in_Curriculum_24948()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10830");
            _test.Log(Status.Info, "Creating New Curriculum");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            ContentDetailsPage.Accordians.ClickEdit_CurriculumContent();
            _test.Log(Status.Info, "Click Curricumn Content Edit button");
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("Test");
            _test.Log(Status.Info, "Add a new block using Add Curriculum Block");
            CurriculumContentPage.ClickAddTrainingActivities();
            AddTrainingActivitiesPage.Search("Somnath-General-Course");
            AddTrainingActivitiesPage.AddTraing();
            Assert.IsTrue(AddTrainingActivitiesPage.verifyfeedbackmessage("The selected items were added."));
            AddTrainingActivitiesPage.ClickBreadcrumblink(curriculamtitle + "TC10830");
            ContentDetailsPage.Click_Check_in();

            CommonSection.SearchCatalog('"' + curriculamtitle + "TC10830" + '"');
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC10830");
            CatalogPage.Click_Enrollbutton();
            Assert.IsTrue(ContentDetailsPage.getFeedbackMessage("You were successfully enrolled in the curriculum."));
        }
        [Test, Order(15), Category("AutomatedP1")]
        public void z15_View_Transcript_Curriculums_26150()
        {
            CommonSection.Learner.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            TranscriptPage.ClickCurriculums();
            _test.Log(Status.Info, "Click Curriculums tab on Transcript Page");

            Assert.IsTrue(TranscriptPage.CurricumnPortlet.VerifyColumnTitles());
            Assert.IsTrue(TranscriptPage.CurricumnPortlet.Verifyrecorddisplay());
            _test.Log(Status.Pass, "Verify result table and existing record are display on Transcript Page");



        }

        [Test, Order(16), Category("AutomatedP1")]
        public void z16_Lunch_Curriculum_Transcript_26855()
        {
            CommonSection.Learner.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            TranscriptPage.ClickCurriculums();
            _test.Log(Status.Info, "Click Curriculums tab on Transcript Page");

            TranscriptPage.CurricumnPortlet.ClickCurriculumTitle();
            Assert.IsTrue(ContentDetailsPage.ContentDetailsPageOpened());
            _test.Log(Status.Pass, "Verify Content Datails Page is opened");
        }
        [Test, Order(17), Category("AutomatedP1")]
        public void z17_Curriculums_View_Certificate_26853()
        {
            CommonSection.Learner.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            TranscriptPage.ClickCurriculums();
            _test.Log(Status.Info, "Click Curriculums tab on Transcript Page");

            TranscriptPage.CurricumnPortlet.ClickCurriculumTitle();
            Assert.IsTrue(ContentDetailsPage.ContentDetailsPageOpened());
            _test.Log(Status.Pass, "verify Content Details page opened");
            //ContentDetailsPage.Click_OpenNewAttempt();
            //ContentDetailsPage.CurriculumnBlocks.LunchCourse();
            //ContentDetailsPage.CompleteLunchedCourse();
            //_test.Log(Status.Info, "Lunched the course attached and complete it");
            //ContentDetailsPage.ClickBrowserBackButton();
            //ContentDetailsPage.ClickBrowserBackButton();
            //_test.Log(Status.Info, "Click Browse back button");
            ContentDetailsPage.Click_CiewCertificate();
            _test.Log(Status.Info, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.VerifyCertificateisOpened());
            _test.Log(Status.Pass, "Verify Certificate is opened");

        }
        [Test, Order(18), Category("AutomatedP1")]
        public void z18_Search_and_Add_training_activities_15758()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC15758");
            _test.Log(Status.Info, "Creating New Curriculum");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            ContentDetailsPage.Accordians.ClickEdit_CurriculumContent();
            _test.Log(Status.Info, "Click Curricumn Content Edit button");
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("Test");
            _test.Log(Status.Info, "Add a new block using Add Curriculum Block");
            CurriculumContentPage.ClickAddTrainingActivities();
            AddTrainingActivitiesPage.Search("Somnath-General-Course");
            AddTrainingActivitiesPage.AddTraing();
            Assert.IsTrue(AddTrainingActivitiesPage.verifyfeedbackmessage("The selected items were added."));
            AddTrainingActivitiesPage.Click_backbutton();
            CurriculumContentPage.RemoveTrainingActivities();
            _test.Log(Status.Info, "Remove added training activities from content");
            Assert.IsTrue(CurriculumContentPage.GetSuccessMessage("The item was removed."));
            _test.Log(Status.Pass, "Verify Feedback message");
            ContentDetailsPage.DeleteContent();
        }


        [Test, Order(19), Category("AutomatedP1")]
        public void z19_Document_Cost_7336()
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

        [Test, Order(20), Category("AutomatedP1")]
        public void z20_Document_Alternate_Cost_7337()
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
        [Test, Order(21), Category("AutomatedP1")]
        public void z21_Document_Access_Aproval_7340()
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
        [Test, Order(22),Category("AutomatedP1")]
        public void z22_Document_Categories_7335()
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
        [Test, Order(23), Category("AutomatedP1")]
        public void z23_Document_Prerequisites_7338()
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
            StringAssert.AreEqualIgnoringCase("The selected items were removed and are no longer prerequisites.", (PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();

        }
        [Test, Order(24), Category("AutomatedP1")]
        public void z24_Document_Image_7343()
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
        [Test, Order(25), Category("AutomatedP1")]
        public void z25_Document_Equivalencies_7339()
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
            AddEquivalenciesPage.SearchFor("").ClickAddbutton();
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify Equivalencies are added to Document");
            AddEquivalenciesPage.ClickBackButton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyanyEquivalenciesPresent());
            _test.Log(Status.Info, "Verify any Equivalencies content display in Accordian");
            ContentDetailsPage.Accordians.ClickEdit_Equivalencies();
            EquivalenciesPage.removeAddedEquivalencies();
            _test.Log(Status.Info, "Remove added Equivalencies");
            StringAssert.AreEqualIgnoringCase("The items were removed. They are not equivalencies.", (EquivalenciesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify success message");

            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(26), Category("AutomatedP1")]
        public void z26_Document_Activity_7344()
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
        [Test, Category("AutomatedP1")]
        public void z42_Managers_Report_Proficiency_Ratings_32143()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            ReportsConsolePage.SearchText("Manager's Report - Proficiency Ratings");
            _test.Log(Status.Info, "Searched Manager's Report - Proficiency Ratings");
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1);//checks results display more than 1
            ReportsConsolePage.ClickManagersReportProficiencyRatings();
            _test.Log(Status.Info, "ClickedManager's Report - Proficiency Ratings");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            // RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            // Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            // MeridianGlobalReportingPage.ClickDetails();
            //_test.Log(Status.Info, "Clicked go button having details selected and opens details page");
            //Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));//retrieves the text from details tab
            //DetailsPage.ClickCloseWindowlink();
            // _test.Log(Status.Info, "Details page closes");
            //Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            //// RunReportPage.ClickRunReport();
            //Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            //DetailsPage.ClickExporttoPDF();
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));

            //MeridianGlobalReportingPage.CloseWindow();
            //_test.Log(Status.Info, "Closes pdf window");
            //Assert.IsTrue(RunReportPage.Title == "Run Report");
            //Assert.IsTrue(Driver.focusParentWindow());
            //CommonSection.Avatar.Reports();
            //_test.Log(Status.Info, "open reports from KI");
            //ReportsPage.MyTrainingProgress.ClickRunReport();
            //_test.Log(Status.Info, "opens run report page from KI");
            //ReportsPage.ReportCriteriaModal.ClickRunReport();
            //_test.Log(Status.Info, "click run report from KI");
            //MeridianGlobalReportingPage.ClickDetails();
            //_test.Log(Status.Info, "click the go button having details option displayed");
            //string restext = DetailsPage.CheckDetailsTabText;
            //StringAssert.EndsWith("Details", restext);
            //DetailsPage.ClickCloseWindowlink();
            //_test.Log(Status.Info, "closed the details page ");
            //Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            //// RunReportPage.ClickRunReport();
            //Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            //DetailsPage.ClickExporttoPDF();
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));

            // MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            Driver.focusParentWindow();
            // StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Report");
        }
        [Test, Order(28), Category("AutomatedP1")]
        public void z43_To_Test_Authorized_user_can_create_a_curriculum_block_of_credit_type_and_can_choose_credit_type_15694()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC26346");
            _test.Log(Status.Info, "Create new curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Edit the new curriculum");
            CurriculumContentPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Add curriculum block");
            CurriculumContentPage.AddCurriculumBlock.AddCreditBlockAs("Credit");
            _test.Log(Status.Info, "Add block as Credit");
            //Assert.IsTrue(CurriculumContentPage.isCreditCompenetsDisplay());
            _test.Log(Status.Pass, "Required Credit Type and Required Credits are display");
            CurriculumContentPage.ClickAddTrainingActivities();
            _test.Log(Status.Info, "Add training activities");
            AddTrainingActivitiesPage.Search("Somnath-AICC");
            _test.Log(Status.Info, "Search general course");
            AddTrainingActivitiesPage.ClickCheckButton();
            _test.Log(Status.Info, "Click on check box");
            AddTrainingActivitiesPage.ClickAddButton();
            _test.Log(Status.Info, "Click on add button");
            AddTrainingActivitiesPage.Click_backbutton();

        }
        [Test, Order(29) ,Category("AutomatedP1")]
        public void z44_Add_Items_to_Public_Catalog_Cart_and_Checkout_23474()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from User");
            Driver.Instance.Navigate().GoToUrl("https://prdct-mg-18-2.mksi-lms.net/Public/TrainingCatalog.aspx");
            _test.Log(Status.Info, "Navigate to public catalog URL");
            SearchResultsPage.ClickFirstCourseTitle("");
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
        [Test,Order(30), Category("AutomatedP1")]

        public void Z04_Learner_See_Based_on_Your_Interest_Content_Recommendation_on_Home_Page_33519()
        {
            CommonSection.Manage.Recommendations();
            _test.Log(Status.Info, "Open Recommendations Setting Page");

            RecommendationsPage.ClickToggle_ContentTag_Enable();
            _test.Log(Status.Info, "Enabled Content Tag Toggle Switch");

            CommonSection.Learn.Home();
            _test.Log(Status.Info, "Navigate to Home Page");

            Assert.IsTrue(RecommendationsPage.Verify_ContentTagPortlet());
            _test.Log(Status.Info, "Assert Conte nt TagPortlet Visible");


        }

    }

}
