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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            CreatebundlePage.FillTitle(bundleTitle + "TC35504");
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("Yes"));
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
            Assert.IsTrue(SurveysPage.resultgrid.RequiredforFirstSurvey("No"));
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
            CommonSection.Administer.ContentConfiguration.DisplayFarmats();
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
            DisplayFormatsPage.SelectotherdisplayformatforAICC(defaultdisplayformatforAICC);
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
            TrainingPage.ManageContent.SearchContent("AICC").ClickSearchButton();
            _test.Log(Status.Info, "Search Content with AICC and click on Search Button");
            Assert.ISTrue(SearchResultsPage.AICCList.ContentTypeIsFile);
            _test.Log(Status.Info, "Verify all AICC content in the list displays Content Type as File");
        }


        [Test]
        public void Classroom_Section_Copy_With_Standard_Default_Enrollment_35666()

        {
            CommonSection.Create.ClassroomCourse();
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
            SectionsPage.CopySectionModal.ClickCopy();
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
            CommonSection.Create.ClassroomCourse();
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
            SectionsPage.CopySectionModal.ClickCopy();
            _test.Log(Status.Info, "Click on Copy Button on Copy Section Modal");
            Assert.IsTrue(Driver.comparePartialString("The classroom section was copied.", SectionsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful messasge");
            ManageClassroomCoursePage.SectionTab.Section2.ClickDetails();
            Assert.IsTrue(ManageClassroomCoursePage.SectionTab.VerifySection2Expanded);
            _test.Log(Status.Pass, "Verify Section2 is Expanded");
            Assert.IsTrue(ManageClassroomCoursePage.SectionTab.Section2.EnrollmentStartDate.VerifyAsSectionStartDate);
            _test.Log(Status.Pass, "Verify Section2 the Enrollment Start Date before the Section Start Date");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_All_Portlets_In_HomePage_35552()

        {
            CommonSection.Learn.Home();
            Homepage.CurrentTrainingPortlet.Content.ContentType();
            Assert.IsTrue(Homepage.CurrentTrainingPortlet.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Current Training Portlet");
            Homepage.CompletedTrainingPortlet.TypeColumn.ContentType();
            Assert.IsTrue(Homepage.CompletedTrainingPortlet.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Completed Training Portlet");
            Homepage.BasedOnYourInterestPortlet.Content.ContentType();
            Assert.IsTrue(Homepage.BasedOnYourInterestPortlet.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Based On Your Interest Portlet");
            Assert.IsTrue(Homepage.BasedOnYourInterestPortlet.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format (if there is no picture) for all Content in Based On Your Interest Portlet");
            Homepage.RecentlyAddedPortlet.Content.ContentType();
            Assert.IsTrue(Homepage.RecentlyAddedPortlet.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Recently Added Portlet");
            Assert.IsTrue(Homepage.RecentlyAddedPortlet.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format (if there is no picture) for all Content in Recently Added Portlet");
            Homepage.RecommendedForYouPortlet.Content.ContentType();
            Assert.IsTrue(Homepage.RecommendedForYouPortlet.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Recommended for You Portlet");
            Assert.IsTrue(Homepage.RecommendedForYouPortlet.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format (if there is no picture) for all Content in Recommended For You Portlet");
            Homepage.CertificationPortlet.Content.ContentType();
            Assert.IsTrue(Homepage.CertificationPortlet.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Certification Portlet");

        }
        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Saved_Content_35553()

        {
            CommonSection.Learn.SavedContent();
            SavedContentPage.ContentList.Content.ContentType();
            Assert.IsTrue(SavedContentPage.ContentList.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Saved Content Page");
            Assert.IsTrue(SavedContentPage.ContentList.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format (if there is no picture) for all Content in Saved Content Page");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Current_Training_35554()

        {
            CommonSection.Learn.CurrentTraining();
            CurrentTrainingPage.ContentList.Content.ContentType();
            Assert.IsTrue(CurrentTrainingPage.ContentList.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Current Training Page");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Transcript_35561()

        {
            CommonSection.Learn.Transcript();
            AllMyTrainingPage.AllTrainingTab.ContentList.TypeColumn();
            Assert.IsTrue(AllMyTrainingPage.AllTrainingTab.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in All My Training Page");
            AllMyTrainingPage.AllTrainingTab.ClickPrintButton();
            Assert.IsTrue(AllMyTrainingPrintPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in All My Training Print Page");
            AllMyTrainingPage.AllTrainingTab.ClickSaveasPDFButton();
            Assert.IsTrue(AllMyTrainingPDFPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in All My Training PDF Page");

            AllMyTrainingPage.Moredropdown.SelectWaivedPrerequisitesOption();
            WaivedPrerequisitesPage.ContentList.TypeColumn();
            Assert.IsTrue(WaivedPrerequisitesPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Waived Prerequisites Page");
            WaivedPrerequisitesPage.ClickPrintButton();
            Assert.IsTrue(WaivedPrerequisitesPrintPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Waived Prerequisites Print Page");
            WaivedPrerequisitesPage.ClickSaveasPDFButton();
            Assert.IsTrue(WaivedPrerequisitesPDFPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Waived Prerequisites PDF Page");

            AllMyTrainingPage.Moredropdown.SelectTrainingAssignmentExemptionsOption();
            RequiredTrainingExemptionsPage.ContentList.TypeColumn();
            Assert.IsTrue(RequiredTrainingExemptionsPage.CurrentExemptionsSection.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Page Current Exemption Section");
            RequiredTrainingExemptionsPage.CurrentExemptionsSection.ClickPrintButton();
            Assert.IsTrue(RequiredTrainingExemptionsCurrentPrintPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Current Print Page");
            RequiredTrainingExemptionsPage.CurrentExemptionsSection.ClickSaveasPDFButton();
            Assert.IsTrue(RequiredTrainingExemptionsCurrentPDFPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Current PDF Page");

            Assert.IsTrue(RequiredTrainingExemptionsPage.PastExemptionsSection.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Page Past Exemption Section");
            RequiredTrainingExemptionsPage.PastExemptionsSection.ClickPrintButton();
            Assert.IsTrue(RequiredTrainingExemptionsPastPrintPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Past Print Page");
            RequiredTrainingExemptionsPage.PastExemptionsSection.ClickSaveasPDFButton();
            Assert.IsTrue(RequiredTrainingExemptionsPastPDFPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Past PDF Page");

            AllMyTrainingPage.Moredropdown.SelectExpiredIncompleteContentOption();
            ExpiredLearningPage.ContentList.TypeColumn();
            Assert.IsTrue(ExpiredLearningPage.CurrentExemptionsSection.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Expired Learning Page");
            ExpiredLearningPage.ClickPrintButton();
            Assert.IsTrue(ExpiredLearningPrintPage.ContentList.TypeColumn.ContentType(DisplayFormat));
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Expired Learning Print Page");
            ExpiredLearningPage.ClickSaveasPDFButton();
            Assert.IsTrue(WaivedPrerequisitesPDFPage.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Expired Learning PDF Page");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Checkout_ShoppingCart_35562()
        //Pre-req - Item is added to Cart
        {
            CommonSection.ShoppingCart();
            _test.Log(Status.Info, "Verify Shopping Cart Page is displayed");
            Assert.IsTrue(ShoppingCartPage.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Shopping Cart Page");
            ShoppingCartPage.ClickCheckout();
            _test.Log(Status.Info, "Verify Checkout Page is displayed ");
            CheckOutPage.SelectPaymentMethod.PurchaseOrder.ClickUsethispaymentmethodButton();
            _test.Log(Status.Info, "On the Checkout page, click Use this payment method button");
            Assert.IsTrue(CheckOutPage.OrderSummarySection.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Checkout Page");
            CheckOutPage.AcceptTermsandConditions.ClickCheckbox.SelectPlaceOrder();
            Assert.IsTrue(OrderReceiptPage.OrderSummarySection.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Order Receipt Page");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Catalog_Search_Results_35564()

        {
            CommonSection.SearchCatalog("dolly");
            _test.Log(Status.Info, "Search dolly from Catalog search ");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("dolly") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search result is display");
            Assert.IsTrue(SearchResultsPage.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Catalog Search Results page");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Public_Catalog_35565()

        {
            CommonSection.Avatar.Logout();
            _test.Log(Status.Pass, "Verify User is logged Out");
            LoginPage.ClickBrowsePublicCatalogLink();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search result is display");
            Assert.IsTrue(SearchResultsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format in Public Catalog");
            Assert.IsTrue(SearchResultsPage.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in Public Catalog");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Career_Development_35566()
        //Pre-Req: Development Plan with Competency is created
        {
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Verify Professional Development Page is displayed ");
            ProfessionalDevelopmentPage.DevelopmentPlansSection.ClickExistingPlan();
            _test.Log(Status.Info, "Verify Development Plan Page is displayed ");
            Assert.IsTrue(DevelopmentPlanPage.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Development Plan page");
            DevelopmentPlanPage.ProfessionalFocusSection.ClickAddContent();
            Assert.IsTrue(AddDevelopmentActivityPage.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Add Development Activity page");
            DevelopmentPlanPage.ProfessionalFocusSection.ContentList.ClickTrashIcon();
            _test.Log(Status.Pass, "Click on the Trash icon for the Content");
            Assert.IsTrue(ConfirmationModal.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Confirmation modal");
            DevelopmentPlanPage.ProfessionalFocusSection.ClickonCompetencyTitle();
            _test.Log(Status.Info, "On the Development Plan Page, Professional Focus Section, click on the Competency Title");
            Assert.IsTrue(CompetencyModal.MandatoryTab.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Mandatory Tab");
            CompetencyModal.ClickSupplementalTab();
            _test.Log(Status.Info, "On the Competency Modal, select the Supplemental tab");
            Assert.IsTrue(CompetencyModal.SupplementalTab.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Supplemental Tab");

            ProfessionalDevelopmentPage.ClickExploreCareers();
            Assert.IsTrue(CareerNavigatorLandingPage.JobCard);
            _test.Log(Status.Info, "Verify Career Navigator Landing Page is displayed with Job Cards");
            CareerNavigatorLangingPage.ClickJobCard();
            _test.Log(Status.Info, "On the Career Navigator page, Click on the Job Card");
            Assert.IsTrue(JobCardModal.InProgressTab);
            _test.Log(Status.Info, "Verify JobCard Modal with InProgress Tab is displayed");
            CareerNavigationLandingPage.JobCardModal.InProgressTab.ClickCompetencyLink();
            _test.Log(Status.Info, "On the Job Card Modal, Click on the Competency Link");
            Assert.IsTrue(CompetencyModal.MandatoryTab.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Mandatory Tab");
            CompetencyModal.ClickSupplementalTab();
            _test.Log(Status.Info, "On the Competency Modal, select the Supplemental tab");
            Assert.IsTrue(CompetencyModal.SupplementalTab.ContentList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Supplemental Tab");
        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Orders_35568()
        //Pre-req - Items are purchased
        {
            CommonSection.Avatar.Orders();
            _test.Log(Status.Info, "Click Orders from Avatar");
            OrderHistoryPage.OrderList.Order.ClickViewDetails();
            _test.Log(Status.Info, "Verify Orders History Page is displayed with existing Orders, Click View Details for one Order");
            Assert.IsTrue(OrderDetailsPage.ItemDetailsSection.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Order Details page");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Requests_35569()
        //Pre-req - Access Request is made
        {
            CommonSection.Avatar.Requests();
            _test.Log(Status.Info, "Click Requests from Avatar");
            Assert.IsTrue(MyRequestsPage.RequestList.TypeColumn.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content Request in My Request Page");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Manage_Access_Keys_35570()
        //Pre-req - Purchased Access Keys

        {

            CommonSection.Manage.AccessKeys();
            _test.Log(Status.Info, "Select Access Keys from manage");
            Assert.IsTrue(ManageAccessPage.SearchResults.Content.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Manage Access page");
            ManageAccessPage.SearchResults.Action.ClickViewDetails();
            _test.Log(Status.Pass, "Click on View Details Action button from Manage Access page");
            Assert.IsTrue(ItemHistoryPage.ContentTitle.ContentType = DisplayFormat);
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Item History page");


        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Document_35572()

        {
            CommonSection.SearchCatalog("Document");
            _test.Log(Status.Info, "Search a document from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Document") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickDocumentTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Document");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Document");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");
            ContentDetailsPage.ClickOpenItembutton.CompleteContent();
            _test.Log(Status.Pass, "Click Open Item button, Launch the Course and complete the content");
            Assert.IsTrue(ContentDetailsPage.MarkCompletebutton);
            _test.Log(Status.Pass, "Verify Mark Complete button is displayed Content Details Page");
            ContentDetailsPage.MarkCompletebutton.Click();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");
            Assert.IsTrue(MarkCompleteModal.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Document in Mark Complete Modal");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_General_Course_35573()

        {
            CommonSection.SearchCatalog("General Course");
            _test.Log(Status.Info, "Search a General Course from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("General Course") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickGeneralCourseTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for General Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for General Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");
            ContentDetailsPage.ClickOpenItembutton.CompleteContent();
            _test.Log(Status.Pass, "Click Open Item button, Launch the Course and complete the content");
            Assert.IsTrue(ContentDetailsPage.MarkCompletebutton);
            _test.Log(Status.Pass, "Verify Mark Complete button is displayed Content Details Page");
            ContentDetailsPage.MarkCompletebutton.Click();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");
            Assert.IsTrue(MarkCompleteModal.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for General Course in Mark Complete Modal");



        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_AICC_35574()

        {
            CommonSection.SearchCatalog("AICC Course");
            _test.Log(Status.Info, "Search a AICC Course from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("AICC Course") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickAICCCourseTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");
            ContentDetailsPage.ClickOpenItembutton.CompleteContent();
            _test.Log(Status.Pass, "Click Open Item button, Launch the Course and complete the content");
            Assert.IsTrue(ContentDetailsPage.MarkCompletebutton);
            _test.Log(Status.Pass, "Verify Mark Complete button is displayed Content Details Page");
            ContentDetailsPage.MarkCompletebutton.Click();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");
            Assert.IsTrue(MarkCompleteModal.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course in Mark Complete Modal");


        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Scorm_35575()

        {
            CommonSection.SearchCatalog("Scorm Course");
            _test.Log(Status.Info, "Search a Scorm Course from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Scorm Course") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickScormCourseTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Scorm Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Scorm Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");
            ContentDetailsPage.ClickOpenItembutton.CompleteContent();
            _test.Log(Status.Pass, "Click Open Item button, Launch the Course and complete the content");
            Assert.IsTrue(ContentDetailsPage.MarkCompletebutton);
            _test.Log(Status.Pass, "Verify Mark Complete button is displayed Content Details Page");
            ContentDetailsPage.MarkCompletebutton.Click();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");
            Assert.IsTrue(MarkCompleteModal.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Scorm Course in Mark Complete Modal");



        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Survey_35576()

        {
            CommonSection.SearchCatalog("Survey");
            _test.Log(Status.Info, "Search a Survey from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Survey") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickSurveyTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Surveys");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Surveys");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Curriculum_35577()

        {
            CommonSection.SearchCatalog("Curriculum");
            _test.Log(Status.Info, "Search a Curriculum from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Curriculum") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickCurriculumTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Curriculum");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Curriculum");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Certification_35578()

        {
            CommonSection.SearchCatalog("Certification");
            _test.Log(Status.Info, "Search a Certification from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Certification") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickCertificationTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Certification");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Certification");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Bundle_35579()

        {
            CommonSection.SearchCatalog("Bundle");
            _test.Log(Status.Info, "Search a Bundle from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Bundle") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickBundleTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Bundle");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Bundle");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Subscription_35580()

        {
            CommonSection.SearchCatalog("Subscription");
            _test.Log(Status.Info, "Search a Subscription from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Subscription") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickSubscriptionTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Subscription");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Subscription");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");

        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_OJT_35581()

        {
            CommonSection.SearchCatalog("OJT");
            _test.Log(Status.Info, "Search a OJT from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("OJT") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickOJTTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for OJT");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for OJT");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");


        }

        [Test]
        public void I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Classroom_Course_35582()

        {
            CommonSection.SearchCatalog("Classroom");
            _test.Log(Status.Info, "Search a Classroom from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Classroom") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ListofSearchResults.ClickClassroomCourseTitle();
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Classroom Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTitle.ContentType = DisplayFormat());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Classroom Course");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.Content.ContentTypeIcon = DisplayFormatIcon);
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in More Like This Section");
        }

        [Test]
        public void Add_Custom_Content_Block_Panel_35706()

        {
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            CustomBlockPage.Panels.CreatePanelButton;
            _test.Log(Status.Info, "Select Create Panel Button");
            Assert.IsTrue(CreatePanelPage.isDisplayed());
            _test.Log(Status.Pass, "Verify the Create Custom Page is Displayed");
            Assert.IsTrue(CreatePanelPage.isTitleDisplayed);
            _test.Log(Status.Pass, "Verify the Title is Displayed");
            CreatePanelPage.EditTitle("Custom Panel");
            _test.Log(Status.Info, "Edit title of Custom Panel and click on Save");
            Assert.IsTrue(CreatePanelPage.isStatus("Visible"));
            _test.Log(Status.Pass, "Verify the Status is Visible by default");
            CreatePanelPage.EditStatus("Hidden");
            _test.Log(Status.Info, "Edit Status of Custom Panel to Hidden");
            Assert.IsTrue(CreatePanelPage.VerifyLocalization());
            _test.Log(Status.Pass, "Verify Localization is defaulted to English (US)");
            Assert.IsTrue(CreatePanelPage.Template.VerifyTemplate1());
            _test.Log(Status.Pass, "Verify Template1 is defaulted to Full Width");
            Assert.IsTrue(CreatePanelPage.Template.VerifyTemplate2);
            _test.Log(Status.Pass, "Verify Template2 is displayed");
            Assert.IsTrue(CreatePanelPage.Template.VerifyTemplate3);
            _test.Log(Status.Pass, "Verify Template3 is displayed");
            Assert.IsTrue(CreatePanelPage.Template.VerifyTemplate4);
            _test.Log(Status.Pass, "Verify Template4 is displayed");
            CreatePanelPage.Template.ClickToolTip();
            Assert.IsTrue(CreatePanelPage.Template.VerifyToolTipMessage("Some templates look similar at smaller resolutions. Use the preview function to review your selections"));
            _test.Log(Status.Info, "Verify ToolTip Message is displayed");
            CreatePanelPage.Template.SelectTemplateView2();
            _test.Log(Status.Info, "Click on template view 2");
            CreatePanelPage.Template.SelectTemplateView3();
            _test.Log(Status.Info, "Click on template view 3");
            CreatePanelPage.Template.SelectTemplateView4();
            _test.Log(Status.Info, "Click on template view 4");
            CreatePanelPage.Template.SelectTemplateView1();
            _test.Log(Status.Info, "Click on template view 1");
            Assert.IsTrue(CreatePanelPage.Color.isColor("Black"));
            _test.Log(Status.Pass, "verify Color Theme is defaulted to Black");
            CreatePanelPage.Color.SelectColor;
            _test.Log(Status.Info, "Select Blue color from the Color theme and Save");
            CreatePanelPage.Color.ClickToolTip();
            Assert.IsTrue(CreatePanelPage.Color.VerifyToolTipMessage("Changing the color of the background and overlay automatically updates the panel's text to improve readability"));
            Assert.IsTrue(CreatePanelPage.Overlay.isOverlay("ON"));
            _test.Log(Status.Pass, "verify Overlay is defaulted to ON");
            CreatePanelPage.Overlay.SelectOverlay("OFF");
            _test.Log(Status.Info, "Select the overlay to OFF and Save");
            Assert.IsTrue(CreatePanelPage.Heading.isHeadingDisplayed);
            _test.Log(Status.Pass, "verify Heading is displayed");
            CreatePanelPage.Heading.EditHeading("Enter Heading For Test");
            _test.Log(Status.Info, "Edit Heading and click on Save");
            Assert.IsTrue(CreatePanelPage.Caption.isCaptionDisplayed);
            _test.Log(Status.Pass, "verify Caption is displayed");
            CreatePanelPage.Caption.EditCaption("Change Caption For Test");
            _test.Log(Status.Info, "Edit Caption and click on Save");
            Assert.IsTrue(CreatePanelPage.Buttonlabel.isButtonlabelDisplayed);
            _test.Log(Status.Pass, "verify Button Label is displayed");
            CreatePanelPage.Buttonlabel.EditButtonLabel("Change New Button Label");
            _test.Log(Status.Info, "Edit Button label and click on Save");
            Assert.IsTrue(CreatePanelPage.Hyperlink.isHyperlinkDisplayed);
            _test.Log(Status.Pass, "verify Hyperlink field is displayed");
            CreatePanelPage.Hyperlink.EditHyperlink("Enter Hyperlink https://cnn.com");
            _test.Log(Status.Info, "Edit Hyperlink and click on Save");
            Assert.IsTrue(CreatePanelPage.Backgroundimage);
            CreatePanelPage.Backgroundimage.ClickBrowse("Image Upload");
            _test.Log(Status.Pass, "Click Browse on Background Image and click on Upload. Verify the background Image is uploaded");
            CreatePanelPage.BackgroundImage.ClickToolTip();
            Assert.IsTrue(CreatePanelPage.Backgroundimage.VerifyToolTipMessage("Images are automatically cropped and zoomed to fit the panel. For best results, use images with centered focal points that do not contain text"));
            Assert.IsTrue(CreatePanelPage.Backgroundvideo);
            CreatePanelPage.Backgroundvideo.EditBackgroundvideo("Enter Video https://www.youtube.com/watch?v=tTakVo8Q3FE");
            _test.Log(Status.Pass, "verify Background Video link is Added");
            CreatePanelPage.BackgroundVideo.ClickToolTip();
            Assert.IsTrue(CreatePanelPage.BackgroundVideo.VerifyToolTipMessage("Videos are automatically muted and cropped to fit the panel. For best results, include a background image for devices that do not support inline video"));
            Assert.IsTrue(Driver.comparePartialString("The changes are saved.", CustomBlockDetailsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful message is displayed");
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            Assert.IsTrue(CustomBlockPage.Panels.isCreatedPanelDisplayed);
            _test.Log(Status.Pass, "Verify the created panel is displayed in Custom Block page, Panels tab");
        }

        [Test]
        public void As_An_Administrator_Edit_Custom_Content_Panel_35707()
        //Custom Block is created and the Panels are created
        {

            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            CustomBlockPage.Panels.SelectCustomPanelToEdit("Dolly's Custom Panel_2");
            _test.Log(Status.Info, "Select a Custom block to Edit");
            CustomBlockDetailsPage.EditCustomContentTitle("Edited Dolly's Custom Panel_2");
            _test.Log(Status.Info, "Edit title of Custom block");
            CustomBlockDetailsPage.TemplateView2();
            _test.Log(Status.Info, "Click on template view 2");
            CustomBlockDetailsPage.TemplateView3();
            _test.Log(Status.Info, "Click on template view 3");
            CustomBlockDetailsPage.TemplateView4();
            _test.Log(Status.Info, "Click on template view 4");
            CustomBlockDetailsPage.TemplateView1();
            _test.Log(Status.Info, "Click on template view 1");
            CustomBlockDetailsPage.EditHeading("Enter Heading For Test");
            _test.Log(Status.Info, "Edit Heading in the details Tab");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyHeading());
            _test.Log(Status.Pass, "verify Heading");
            CustomBlockDetailsPage.EditCaption("Change Caption For Test");
            _test.Log(Status.Info, "Edit Caption in the details Tab");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyCaption());
            _test.Log(Status.Pass, "verify Caption");
            CustomBlockDetailsPage.EditButtonLabel("Change New Button Label");
            _test.Log(Status.Info, "Edit Button label in the details Tab");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyButtonLabel());
            _test.Log(Status.Pass, "verify Button Label");
            CustomBlockDetailsPage.Cancel();
            _test.Log(Status.Pass, "Click on cancel Button");
            CustomBlockDetailsPage.EditCustomContentTitle("Edited Dolly's Custom Panel_2");
            _test.Log(Status.Info, "Edit title of Custom block");
            CustomBlockDetailsPage.TemplateView2();
            _test.Log(Status.Info, "Click on template view 2");
            CustomBlockDetailsPage.TemplateView3();
            _test.Log(Status.Info, "Click on template view 3");
            CustomBlockDetailsPage.TemplateView4();
            _test.Log(Status.Info, "Click on template view 4");
            CustomBlockDetailsPage.TemplateView1();
            _test.Log(Status.Info, "Click on template view 1");
            CustomBlockDetailsPage.EditHeading("Enter Heading For Test");
            _test.Log(Status.Info, "Edit Heading");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyHeading());
            _test.Log(Status.Pass, "verify Heading");
            CustomBlockDetailsPage.EditCaption("Change Caption For Test");
            _test.Log(Status.Info, "Edit Caption");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyCaption());
            _test.Log(Status.Pass, "verify Caption");
            CustomBlockDetailsPage.EditButtonLabel("Change New Button Label");
            _test.Log(Status.Info, "Edit Button label");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyButtonLabel());
            _test.Log(Status.Pass, "verify Button Label");
            CustomBlockDetailsPage.EditHyperlink("Enter Hyperlink https://cnn.com");
            _test.Log(Status.Info, "Edit Hyperlink");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyHyperlink());
            _test.Log(Status.Pass, "verify Hyperlink");
            CustomBlockDetailsPage.Save();
            Assert.IsTrue(Driver.comparePartialString("The changes are saved.", CustomBlockDetailsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful message");

        }

        [Test]
        public void As_An_Administrator_Delete_Custom_Content_Panel_35726()

        {
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            CustomBlockPage.Panels.SelectCustomBlock("Custom Block");
            _test.Log(Status.Info, "Select Custom Block");
            CustomBlockPage.Panels.Delete();
            _test.Log(Status.Info, "Click Delete Button");
            Assert.IsTrue(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box Appears");
            CustomBlockPage.AlertBoxCancel();
            _test.Log(Status.Pass, "Click Cancel Button in Alert Box");
            Assert.IsFalse(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box is Closed");
            CustomBlockPage.Panels.SelectCustomBlock("Custom Block");
            _test.Log(Status.Info, "Select Custom Block");
            CustomBlockPage.Panels.Delete();
            _test.Log(Status.Info, "Click Delete Button");
            Assert.IsTrue(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box Appears");
            CustomBlockPage.AlertBoxDelete();
            _test.Log(Status.Info, "Click Delete Button in Alert Box");
            Assert.IsTrue(Driver.comparePartialString("Success", CustomBlockPage.Successmessage()));
            _test.Log(Status.Pass, "Verify success message is Displayed");
            Assert.IsFalse(CustomBlockPage.Panels.VerifyCustomBlockDeleted("Custom Block"));
            _test.Log(Status.Pass, "Verify Selected Custom Block is Deleted");

        }

        [Test]
        public void Add_End_Date_to_Training_Assignments_related_Scheduling_of_Reports_51787()

        {
            CommonSection.Administer.System.Reporting.ReportsConsole();
            ReportsConsolePage.SearchReport("Domain Report-Training Assignments");
            _test.Log(Status.Info, "Search a Report from Reports Console");
            Assert.IsTrue(ReportsConsolePage.CheckSearchRecord("Domain Report - Training Assignments") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(ReportsConsolePage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            ReportsConsolePage.ListofSearchResults.ClickReportTitle();
            Assert.IsTrue(ReportPage.ScheduleReportbutton);
            _test.Log(Status.Pass, "Verify Reports page is displayed with Schedule Report button");
             ​ReportPage.ClickScheduleReportbutton();
            Assert.IsTrue(RunReportPage.DateRange.VerifyEndDatewithCalendar);
            _test.Log(Status.Pass, "Verify Run Report Page is displayed with End Date field with Calendar");
            Assert.IsFalse(RunReportPage.DateRange.VerifyEndDateIsRequired);
            _test.Log(Status.Pass, "Verify End Date field is not a required field");
            RunReportPage.DateRange.FixedDate.SelectRadiobutton();
            _test.Log(Status.Info, "Select Radio Button");
            RunReportPage.DateRange.FixedDate.EnterFixedStartDate();
            _test.Log(Status.Info, "Enter Future Fixed Start Date");
            RunReportPage.DateRange.EndDate.EnterEndDate();
            _test.Log(Status.Info, "Enter Current End Date");
            RunReportPage.ClickContinuebutton();
            _test.Log(Status.Info, "Click on Continue button");
            Assert.IsTrue(RunReportPage.VerifyValidationMessage);
            _test.Log(Status.Pass, "Verify Validation Check message is displayed");
            RunReportPage.DateRange.FixedDate.EnterFixedStartDate();
            _test.Log(Status.Info, "Enter Past Fixed Start Date");
            RunReportPage.DateRange.EndDate.EnterEndDate();
            _test.Log(Status.Info, "Enter Current End Date");
            RunReportPage.ClickContinuebutton();
            _test.Log(Status.Info, "Click on Continue button");
            Assert.IsTrue(NewReportPage.VerifySummaryTab);
            _test.Log(Status.Pass, "Verify New Report Page, Summary tab is displayed");
            RunReportPage.DateRange.FixedDate.EnterFixedStartDate();
            _test.Log(Status.Info, "Enter Past Fixed Start Date");
            RunReportPage.ClickContinuebutton();
            _test.Log(Status.Info, "Click on Continue button");
            Assert.IsTrue(NewReportPage.VerifySummaryTab);
            _test.Log(Status.Pass, "Verify New Report Page, Summary tab is displayed");
            RunReportPage.DateRange.FloatingDateRange.EnterFloatingDateRange();
            _test.Log(Status.Info, "Enter Floating Date Range as 5 Days");
            RunReportPage.DateRange.EndDate.EnterEndDate();
            _test.Log(Status.Info, "Enter Current End Date");
            RunReportPage.ClickContinuebutton();
            _test.Log(Status.Info, "Click on Continue button");
            Assert.IsTrue(NewReportPage.VerifySummaryTab);
            _test.Log(Status.Pass, "Verify New Report Page, Summary tab is displayed");

        }

        [Test]
        public void User_Adds_Instructor_While_Creating_a_Classroom_Course_34064()
        // Pre-req:  Create a personal Item manually in Instructor Calendar from Avatar >> Calendar

        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Instructor");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Verify Select Instructor modal is displayed");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Instructor with Personal Item"); //Instructor Name
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModal.InstructorAvailability.OccupiedDisplayed);
            _test.Log(Status.Info, "Select Instructor Modal is displayed with availability as Occupied for personal days");
            ManageClassroomCoursePage.SelectInstructorModal.SelectViewScheduleButton();
            _test.Log(Status.Info, "Select View Schedule button for the User with personal days");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorCalendarModal.PersonalDaysDisplayed);
            _test.Log(Status.Pass, "Verify Instructor Calendar Modal is displayed with the personal days description");

        }

        public void a01_As_an_admin_manage_equivalencies_for_content_General_Course_52292()
        // Pre-req: General Course created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("General Course with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search General Course with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.GeneralList);
            _test.Log(Status.Pass, "Verify all General courses with existing equivalencies in the list displays");
            SearchResultspage.GeneralList.ClickGeneralCourseLink();
            _test.Log(Status.Info, "Click on General Course link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.isExistingEquivalencyContentdisplay("Yes"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }

        public void a02_As_an_admin_manage_equivalencies_for_content_SCORM_52293()
        // Pre-req: Scorm Course created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Scorm Course with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Scorm Course with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Scorm courses with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickScormCourseLink();
            _test.Log(Status.Info, "Click on Scorm Course link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.isExistingEquivalencyContentdisplay("Yes"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }

        public void a03_As_an_admin_manage_equivalencies_for_content_Document_52291()
        // Pre-req: Document created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Document with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Document with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Documents with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickDocumentLink();
            _test.Log(Status.Info, "Click on Document link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.isExistingEquivalencyContentdisplay("Yes"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }

        public void a04_As_an_admin_manage_equivalencies_for_content_Classroom_52289()
        // Pre-req: Classroom Course created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Classroom Course with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Classroom Course with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Classroom Courses with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickClassroomCourseLink();
            _test.Log(Status.Info, "Click on Classroom Course link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.isExistingEquivalencyContentdisplay("Yes"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }

        public void a05_As_an_admin_manage_equivalencies_for_content_AICC_52287()
        // Pre-req: AICC Course created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("AICC Course with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search AICC Course with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all AICC Courses with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickAICCCourseLink();
            _test.Log(Status.Info, "Click on AICC Course link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.isExistingEquivalencyContentdisplay("Yes"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }

        public void a06_As_an_admin_manage_equivalencies_for_content_Curriculum_52290()
        // Pre-req: Curriculum created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Curriculum with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Curriculum with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Curriculums with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickCurriculumLink();
            _test.Log(Status.Info, "Click on Curriculum link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.isExistingEquivalencyContentdisplay("Yes"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }

        public void a06_As_an_admin_manage_equivalencies_for_content_Bundles_52288()
        // Pre-req: Bundles created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Bundle with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Bundle with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Bundles with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickBundleLink();
            _test.Log(Status.Info, "Click on Bundle link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.isExistingEquivalencyContentdisplay("Yes"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }

        public void a06_As_an_admin_manage_equivalencies_for_content_Survey_52305()
        // Pre-req: Surveys created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Surveys with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Surveys with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Surveys with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickSurveyLink();
            _test.Log(Status.Info, "Click on Survey link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.IsExistingEquivalencyContentdisplay);
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDateAdded("Date")); //Verify the Date the equivalency was added is displayed
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isDefaultRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("->1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is->1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");

            EquivalenciesPage.ResultGrid.Content.Relationship.Click2 - way();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is2 - wayDropdowndisplayed);
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.ResultGrid.Content.Relationship.2 - wayDropdown.Select("<-1-WayOnly").ClickSaveIcon();
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.Is < -1 - WayOnlydisplayed);
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.Content.Relationship.IsDescriptionTextdisplayed); //Description as "Is Satisfied by XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
        }


        public void a01_As_an_admin_remove_equivalencies_from_a_content_General_Course_52323()
        // Pre-req: General Course created with equivaliencies content added
        {

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(generalcoursetitle + "TC52323");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(generalcoursetitle + "TC52323"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(generalcoursetitle + "TC52323");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");


        }

        public void a02_As_an_admin_remove_equivalencies_from_a_content_SCORM_52325()
        // Pre-req: Scorm Course created with equivaliencies
        {

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(scormcoursetitle + "TC52325");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(scormcoursetitle + "TC52325"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(scormcoursetitle + "TC52325");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(scormcoursetitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");

        }

        public void a03_As_an_admin_remove_equivalencies_from_a_content_Document_52322()
        // Pre-req: Document created with equivaliencies
        {

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(documenttitle + "TC52322");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(documenttitle + "TC52322"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(documenttitle + "TC52322");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(documenttitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");

        }
        public void a04_As_an_admin_remove_equivalencies_from_a_content_Classroom_52320()
        // Pre-req: Classroom Course created with equivaliencies
        {

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(classroomcoursetitle + "TC52320");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(classroomcoursetitle + "TC52320"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(classroomcoursetitle + "TC52320");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(classroomcoursetitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");
        }

        public void a05_As_an_admin_remove_equivalencies_from_a_content_AICC_52318()
        // Pre-req: AICC Course created with equivaliencies
        {

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(AICCcoursetitle + "TC52318");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(AICCcoursetitle + "TC52318"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(AICCcoursetitle + "TC52318");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(AICCcoursetitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");
           
 }
        public void a06_As_an_admin_remove_equivalencies_from_a_content_Curriculum_52321()
        // Pre-req: Curriculum created with equivaliencies
        {

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(curriculumtitle + "TC52321");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(curriculumtitle + "TC52321"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(curriculumtitle + "TC52321");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(curriculumtitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");

        }
        public void a06_As_an_admin_remove_equivalencies_from_a_content_Bundle_52319()
        // Pre-req: Bundles created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Bundle with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Bundle with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Bundles with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickBundleLink();
            _test.Log(Status.Info, "Click on Bundle link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.IsExistingEquivalencyContentdisplay);
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");

        }

        public void a06_As_an_admin_remove_equivalencies_from_a_content_Survey_52327()
        // Pre-req: Surveys created with equivaliencies
        {

            CommonSection.Manage.Training.ManageContent();
            _test.Log(Status.Info, "Navigate to Manage >> Training >> ManageContent");
            TrainingPage.ManageContent.SearchContent("Surveys with existing equivalencies").ClickSearchButton();
            _test.Log(Status.Info, "Search Surveys with existing equivalencies and click on Search Button");
            Assert.IsTrue(SearchResultsPage.ResultsList);
            _test.Log(Status.Pass, "Verify all Surveys with existing equivalencies in the list displays");
            SearchResultspage.ResultsList.ClickSurveyLink();
            _test.Log(Status.Info, "Click on Survey link");
            Assert.IsTrue(ContentDetailsPage.Equivalencies);
            _test.Log(Status.Pass, "Verify Content Details Page with equivalencies workflow displays");
            ContentDetailsPage.Equivalencies.ClickEditButton();
            _test.Log(Status.Info, "Click Edit button for Equivalencies workflow");
            Assert.IsTrue(EquivalenciesPage.IsExistingEquivalencyContentdisplay);
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            EquivalenciesPage.ResultGrid.Content.SelectCheckbox();
            _test.Log(Status.Info, "Select the checkbox for one of the Content");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.ContentRemoved);
            _test.Log(Status.Pass, "Verify The content Item from the Data Grid is removed");

            EquivalenciesPage.ResultGrid.Content.SelectRemoveAllCheckbox();
            _test.Log(Status.Info, "Select the checkbox for all of the Content (Checkbox next to Title)");
            Assert.IsTrue(EquivalenciesPage.IsRemoveButtonEnabled);
            _test.Log(Status.Pass, "Verify Remove button gets enabled after selecting the Remove All checkbox");
            EquivalenciesPage.ClickRemoveButton();
            _test.Log(Status.Info, "Click on the Remove button");
            Assert.IsTrue(EquivalenciesPage.IsRemoveEquivalencyModaldisplayed);
            _test.Log(Status.Pass, "Verify Remove Equivalency Modal is displayed");
            RemoveEquivalencyModal.ClickOK();
            _test.Log(Status.Info, "On Remove Equivalency modal, click on OK button");
            Assert.IsTrue(Driver.comparePartialString("The items were removed.", EquivalenciesPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsTrue(EquivalenciesPage.ResultGrid.AllContentRemoved);
            _test.Log(Status.Pass, "Verify all content items from the Data Grid is removed");

        }



    }

}


