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

    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DollyTest : TestBase
    {
        string browserstr = string.Empty;
        public DollyTest(string browser)
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
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }


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
        [Test]
        public void Require_Survey_for_getting_a_certificate_General_35501()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35501", generalcoursetitle + "TC35356");
            _test.Log(Status.Info, "A new Genaral Course Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(generalcoursetitle + "TC35501");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35501");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());


            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35501", generalcoursetitle + "TC35356");
            _test.Log(Status.Info, "A new Genaral Course Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(generalcoursetitle + "TC35501");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35501");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

        }
        [Test]
        public void Require_Survey_for_getting_a_certificate_Scrom_35502()
        {
            CommonSection.CreateLink.SCORM();
            _test.Log(Status.Info, "Goto SCROM Content Creation Page");
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(scormtitle + "TC35502");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(scormtitle + "TC35502");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35502");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            CommonSection.CreateLink.SCORM();
            _test.Log(Status.Info, "Goto SCROM Content Creation Page");
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(scormtitle + "TC35502");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(scormtitle + "TC35502");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35502");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

        }
        [Test]
        public void Require_Survey_for_getting_a_certificate_AICC_35503()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC35503");
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(AICCTitle + "TC35503");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC35503");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            Scorm12 CreateScorm1 = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult1 = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC35503_1");
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle1 = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(AICCTitle + "TC35503");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC35503");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

        }

        [Test]
        public void Require_Survey_for_getting_a_certificate_Progress_Bundle_35504()
        {

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "TC35504");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            Assert.IsTrue(CreatebundlePage.DisplayFormatDropdown.Defaultvalue("Bundle"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(progressbundletitle + "TC35504");
            SearchResultsPage.ClickCourseTitle(progressbundletitle + "TC35504");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "TC35504");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            Assert.IsTrue(CreatebundlePage.DisplayFormatDropdown.Defaultvalue("Bundle"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(progressbundletitle + "TC35504");
            SearchResultsPage.ClickCourseTitle(progressbundletitle + "TC35504");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());



        }

        [Test]
        public void Require_Survey_for_getting_a_certificate_Classroom_35505()
        {

            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            Assert.IsTrue(ClassroomCourse.DisplayFormatDropdown.Defaultvalue("Classroom"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Classroom");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35505");
            _test.Log(Status.Info, "A new Classroom Course Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(classroomcoursetitle + "TC35505");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35505");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());


            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            Assert.IsTrue(ClassroomCourse.DisplayFormatDropdown.Defaultvalue("Classroom"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Classroom");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35505");
            _test.Log(Status.Info, "A new Classroom Course Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(classroomcoursetitle + "TC35505");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35505");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

        }

        [Test]
        public void Require_Survey_for_getting_a_certificate_Certification_35506()
        {

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificationTitle + "TC35506");
            _test.Log(Status.Info, "Fill title");
            Assert.IsTrue(CertificationPage.DisplayFormatDropdown.Defaultvalue("Document"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "A new Certification Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(certificationtitle + "TC35506");
            SearchResultsPage.ClickCourseTitle(certificationtitle + "TC35506");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificationTitle + "TC35506");
            _test.Log(Status.Info, "Fill title");
            Assert.IsTrue(CertificationPage.DisplayFormatDropdown.Defaultvalue("Document"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "A new Certification Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(certificationtitle + "TC35506");
            SearchResultsPage.ClickCourseTitle(certificationtitle + "TC35506");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

        }

        [Test]
        public void Require_Survey_for_getting_a_certificate_Curriculum_35507()
        {
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "TC35507");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            Assert.IsTrue(CreateCurriculumnPage.DisplayFormatDropdown.Defaultvalue("Curriculum"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Curriculum");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(curriculumtitle + "TC35507");
            SearchResultsPage.ClickCourseTitle(curriculumtitle + "TC35507");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "TC35507");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            Assert.IsTrue(CreateCurriculumnPage.DisplayFormatDropdown.Defaultvalue("Curriculum"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Curriculum");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(curriculumtitle + "TC35507");
            SearchResultsPage.ClickCourseTitle(curriculumtitle + "TC35507");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());


        }


        [Test]
        public void Require_Survey_for_getting_a_certificate_OJT_35508()
        {
            CommonSection.CreateLink.OJT();
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The item was created.";
            CommonSection.CreateLink.OJT();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            string actres = onlinejobtraining.buttoncreateclick(driver);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            _test.Log(Status.Info, "Create a new On Job Training");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("Yes"));
            _test.Log(Status.Pass, "Verify Required field is Yes");


            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(OJTtitle + "TC35508");
            SearchResultsPage.ClickCourseTitle(OJTtitle + "TC35508");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey();
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            CommonSection.CreateLink.OJT();
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The item was created.";
            CommonSection.CreateLink.OJT();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            string actres = onlinejobtraining.buttoncreateclick(driver);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            _test.Log(Status.Info, "Create a new On Job Training");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.SetRequiredforFirstSurvey("No");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforFirstSurvey("No"));
            _test.Log(Status.Pass, "Verify Required field is No");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(OJTtitle + "TC35508");
            SearchResultsPage.ClickCourseTitle(OJTtitle + "TC35508");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

        }


        [Test]
        public void Require_Survey_for_getting_a_certificate_Subscription_35509()
        {
            CommonSection.CreateLink.Subscription();
            _test.Log(Status.Info, "Click create>Subscriptions");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC35509").SubscriptionType("Dynamic Date").Create();
            _test.Log(Status.Info, "Create a new Subscriptions");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforSurvey.Disabled);
            _test.Log(Status.Pass, "Verify Required field is Disabled");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(subscriptiontitle + "TC35509");
            SearchResultsPage.ClickCourseTitle(subscriptiontitle + "TC35509");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());


        }

        [Test]
        public void Require_Survey_for_getting_a_certificate_Content_Bundle_35532()
        {

            #region Create General Course and Bundle With Cost and Access keys Enabled
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35532", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.Learn.Home();
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Creating a Paid Bundle Course with Access Keys");
            objCreate.FillBundlePage(browserstr);

            BundlesPage.addContentIntoBundle(generalcoursetitle + "TC35532");
            _test.Log(Status.Info, "Adding Paid General Course into Bundle");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Create a new On Job Training");
            #endregion

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            Assert.IsTrue(SurveysPage.resultgrid.isRequiredforSurvey.Disabled);
            _test.Log(Status.Pass, "Verify Required field is Disabled");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(generalcoursetitle + "TC35532");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35532");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

        }
        [Test]
        public void I_want_to_see_a_list_of_Display_Format_for_my_Site_35435()
        {
            CommonSection.Administer.ContnetConfiguration.DisplayFarmats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatsPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            string defultdisplayformatforAICC = DisplayFormatsPage.GetAICCdefultDisplayFormat();
            DisplayFormatsPage.ClickAICCDisplayFormatDropdown();
            _test.Log(Status.Info, "Clicked AICC display format dropdown");
            Assert.IsTrue(DisplayFormatsPage.VerifyDisplayformatList());
            _test.Log(Status.Pass, "Verify list of Display Formats are displayed");
            DisplayFormatsPage.SelectotherdisplayformatforAICC("File");
            Assert.IsTrue(DisplayFormatsPage.GetAICCdefultDisplayFormat() != defultdisplayformatforAICC);
            _test.Log(Status.Pass, "Verify selected display format is not equals to defult format");
            Assert.IsTrue(DisplayFormatsPage.isDefultChnagesDatedisplay());
            _test.Log(Status.Pass, "Verify Defult Change Date display");
            DisplayFormatsPage.SelectotherdisplayformatforAICC(defultdisplayformatforAICC);
            _test.Log(Status.Info, "Reset Display format value to defult");
            Assert.IsFalse(DisplayFormatsPage.isDefultChnagesDatedisplay());
            _test.Log(Status.Pass, "Verify Defult Change Date removed for AICC");
        }
        [Test]
        public void Filter_Catalog_Search_result_by_Content_Type_Display_Format_35457()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login(); //Login as regular user (Learner)
            CommonSection.SearchCatalog("dolly");
            _test.Log(Status.Info, "Search dolly from Catalog search ");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("dolly") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search result is display");
            Assert.IsTrue(SearchResultsPage.ContentTypeFacet.Display()); //Verify Display Format Facet  is displayed in the left sidebar
            SearchResultsPage.ContentTypeFacet.SelectCheckbox(); //Select multiple checkboxes
            _test.Log(Status.Info, "Select Content Type Facet check box");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Dolly") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero after select Credit tag Facets");
            Assert.IsTrue(SearchResultsPage.SelectedTagsAboveSearchResults.Display()); //Verify the DisplayFormatFacet appears above the search results and Checkbox is checked
            Assert.IsTrue(SearchResultsPage.ContentTypeFacet.TagCheckboxChecked());
            SearchResultsPage.ContentTypeFacet.UnCheckDisplayFormatFacetFacetCheckbox();  //remove 3rd one
            _test.Log(Status.Pass, "UnCheck on Content Tag check box");
            Assert.IsFalse(SearchResultsPage.ContentTypeFacet.UnCheckedDisplayFormatFacetRemoved);
            SearchResultsPage.SelectedTagsAboveSearchResults.RemoveTag();
            _test.Log(Status.Pass, "Removed one Tag");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.TagRemoved);
            SearchResultsPage.SelectedTagsAboveSearchResults.SelectClearAll();
            _test.Log(Status.Pass, "Click Clear All to clean all tag searches");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.AllTagsRemoved);
            Assert.IsTrue(SearchResultsPage.ContentTypeFacet.AllTagCheckboxUnChecked());
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Dolly") >= 1);
        }


        [Test]
        public void As_Admin_Set_Default_Display_Formats_And_Apply_To_All_Existing_Content_Items_35662()
        {
            CommonSection.Administer.ContnetConfiguration.DisplayFarmats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatsPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            string defaultdisplayformatforAICC = DisplayFormatsPage.GetAICCdefaultDisplayFormat();
            DisplayFormatsPage.ClickAICCDisplayFormatDropdown();
            _test.Log(Status.Info, "Clicked AICC display format dropdown");
            Assert.IsTrue(DisplayFormatsPage.VerifyDisplayformatList());
            _test.Log(Status.Pass, "Verify list of Display Formats are displayed");
            DisplayFormatsPage.SelectotherdisplayformatforAICC("File");
            Assert.IsTrue(DisplayFormatsPage.GetAICCdefaultDisplayFormat() != defaultdisplayformatforAICC);
            _test.Log(Status.Pass, "Verify selected display format is not equals to default format");
            Assert.ISTrue(DisplayFormatsPage.displayformatforAICC.ApplyToAllbutton);
            _test.Log(Status.Pass, "Verify AICC display format now displays Apply To All Button if All content are not the same Type");
            DisplayFormatsPage.displayformatforAICC.ClickApplyToAllbutton();
            _test.Log(Status.Pass, "Click on Apply To All Button");
            Assert.ISTrue(DisplayFormatsPage.isApplyToAllModaldisplay);
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.ISTrue(DisplayFormatsPage.ApplyToAllModal.WarningMessage);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.ISTrue(DisplayFormatsPage.ApplyToAllModal.ContentItemsCount);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatsPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            Assert.ISTrue(DisplayFormatsPage.ApplyToAllModalIsClosed);
            _test.Log(Status.Pass, "Verify Apply to All Modal is Closed");
            Assert.ISTrue(DisplayFormatsPage.SuccessMessageDisplay);
            _test.Log(Status.Pass, "Verify Success Message is displayed on Display Format Page");
            Assert.ISFalse(DisplayFormatsPage.ApplyToAllButton);
            _test.Log(Status.Pass, "Verify Apply to All button is not displayed");

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("AICC").ClickSearchButton;
            _test.Log(Status.Info, "Search Content with AICC and click on Search Button");
            Assert.ISTrue(SearchResultsPage.AICCList.ContentTypeIsFile);
            _test.Log(Status.Info, "Verify all AICC content in the list displays Content Type as File");
        }


        [Test]
        public void Classroom_Section_Copy_With_Standard_Default_Enrollment_35666()

        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35666");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            SectionsPage.SelectCopySectionformActionDropdown();
            Assert.IsTrue(SectionsPage.CopySectionModal.VerifyCopySectionModalComponets());
            _test.Log(Status.Pass, "Verify Modal Title, Section Start date, Section title and timezone");
            Assert.IsTrue(SectionsPage.CopySectionModal.EnrollmentStarts.VerifySetToSectionStartDate());
            _test.Log(Status.Pass, "Verify Enrollment Start Date is defaulted to Section Start Date");
            SectionsPage.CopySectionModal.EditSectionTitle("Section2");
            _test.Log(Status.Pass, "Change the Section Title to Section2");
            SectionsPage.CopySectionModal.EnrollmentStartsToggle("Initial");
            _test.Log(Status.Info, "Keep Enrollment Start date to Default with Initial setting");
            SectionsPage.CopySectionModal.ClickCopy;
            _test.Log(Status.Info, "Click on Copy Button on Copy Section Modal");
            Assert.IsTrue(Driver.comparePartialString("The classroom section was copied.", SectionsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful messasge");
            ManageClassroomCoursePage.SectionTab.Section2.ClickDetails();
            Assert.IsTrue(ManageClassroomCoursePage.SectionTab.VerifySection2Expanded);
            _test.Log(Status.Pass, "Verify Section2 is Expanded");
            Assert.IsTrue(ManageClassroomCoursePage.SectionTab.Section2.EnrollmentStartDate.VerifyAsSectionStartDate);
            _test.Log(Status.Pass, "Verify Section2 the Enrollment Start Date is same as Section Start Date");

        }

        [Test]
        public void Classroom_Section_Copy_With_Manual_Enrollment_Start_Date_35669()
  
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35669");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            SectionsPage.SelectCopySectionformActionDropdown();
            Assert.IsTrue(SectionsPage.CopySectionModal.VerifyCopySectionModalComponets());
            _test.Log(Status.Pass, "Verify Modal Title, Section Start date, Section title and timezone");
            Assert.IsTrue(SectionsPage.CopySectionModal.EnrollmentStarts.VerifySetToSectionStartDate());
            _test.Log(Status.Pass, "Verify Enrollment Start Date is defaulted to Section Start Date");
            SectionsPage.CopySectionModal.EditSectionTitle("Section2");
            _test.Log(Status.Pass, "Change the Section Title to Section2");
            SectionsPage.CopySectionModal.SetEnrollmentStartsToggle("Override");
            _test.Log(Status.Info, "Change the Enrollment Start Toggle to Override");
            SectionsPage.CopySectionModal.ChangeEnrollmentStartsDate("Before Section Start Date");
            _test.Log(Status.Info, "Change the Enrollment Start Date to before Section Start Date");
            SectionsPage.CopySectionModal.ClickCopy;
            _test.Log(Status.Info, "Click on Copy Button on Copy Section Modal");
            Assert.IsTrue(Driver.comparePartialString("The classroom section was copied.", SectionsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful messasge");
            ManageClassroomCoursePage.SectionTab.Section2.ClickDetails();
            Assert.IsTrue(ManageClassroomCoursePage.SectionTab.VerifySection2Expanded);
            _test.Log(Status.Pass, "Verify Section2 is Expanded");
            Assert.IsTrue(ManageClassroomCoursePage.SectionTab.Section2.EnrollmentStartDate.VerifyAsSectionStartDate);
            _test.Log(Status.Pass, "Verify Section2 the Enrollment Start Date before the Section Start Date");

        }

    }   
     
    }


