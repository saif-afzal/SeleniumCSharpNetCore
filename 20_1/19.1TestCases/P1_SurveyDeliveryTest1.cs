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
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P1SurveyDeliveryTest1 : TestBase
    {
        string browserstr = string.Empty;
        public P1SurveyDeliveryTest1(string browser)
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
        private bool TC35545;
        private bool TC35546;
        string bunbdleTitle = "Bndl" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }


     
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
       
   
        [Test]
        public void z01_Require_Survey_for_getting_a_certificate_General_35501()
        {
            #region Survey with Required Status Yes

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto General Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35501", generalcoursetitle + "TC35356");
            _test.Log(Status.Info, "A new Genaral Course Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
         
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
           
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
           
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(generalcoursetitle + "TC35501");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35501");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();

            _test.Log(Status.Info, "Click on Enroll Button");
            Assert.IsTrue(Driver.comparePartialString("You are now enrolled.", ContentDetailsPage.getEnrollmentSuccessMessage()));
            _test.Log(Status.Info, "Verify Succcess Message");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();

            _test.Log(Status.Info, "Click on open item and Close the window");
            Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getAssociatedMessage()));
            _test.Log(Status.Pass, "Verify Displayed Message");
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey("Before Course Start");
            _test.Log(Status.Info, "Complete Survey");
            Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            Driver.focusParentWindow();
            #endregion


            #region Survey with required status NO
            //With Required Status -No-
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From learner Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login From SiteAdmin Account");
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto General Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35501_1", generalcoursetitle + "TC35356");
            _test.Log(Status.Info, "A new Genaral Course Created");
           
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            //Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            //_test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            //Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            //_test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
           
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("No");
            _test.Log(Status.Pass, "Verify Required field is No");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            //-------------------
            CommonSection.SearchCatalog(generalcoursetitle + "TC35501_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35501_1");
            _test.Log(Status.Info, "Click Course Title");
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //_test.Log(Status.Info, "Verify Survey is Displayed");
            ContentDetailsPage.ClickEnroll();

            _test.Log(Status.Info, "Click on Enroll Button");
            Assert.IsTrue(Driver.comparePartialString("You are now enrolled.", ContentDetailsPage.getEnrollmentSuccessMessage()));
            _test.Log(Status.Info, "Verify Succcess Message");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();

            _test.Log(Status.Info, "Click on open item and Close the window");
            //ContentDetailsPage.OpenItem.CompleteGeneralCourse();
            //_test.Log(Status.Info, "complete General Course");


            //Assert.IsTrue(Driver.comparePartialString("Warning This item needs to be marked complete manually. Mark this item as complete when you have finished reviewing the content.", ContentDetailsPage.getMarkCompleteSuccessMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getAssociatedMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
          
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Verify Displayed Message");
            Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.ClickViewCertificate();
            //_test.Log(Status.Pass, "Click View Certificate");
            //Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            //_test.Log(Status.Pass, "Verify certificate Page is displayed");


            #endregion

        }
        [Test]
        public void z02_Require_Survey_for_getting_a_certificate_Scrom_35502()
        {
            #region Survey with Required Status Yes
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewScorm(scormtitle + "TC35502");
            _test.Log(Status.Info, "A new SCROM Course Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
        
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
           
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            #endregion
            #region create scrom with required No
            CommonSection.CreteNewScorm(scormtitle + "TC35502_1");
            _test.Log(Status.Info, "A new SCROM Course Created");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
          
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");

            SurveysPage.resultgrid.RequiredforFirstSurvey("No");
            _test.Log(Status.Pass, "Verify Required field is No");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            #endregion

            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(scormtitle + "TC35502");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35502");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            Assert.IsTrue(Driver.comparePartialString("You are now enrolled.", ContentDetailsPage.getEnrollmentSuccessMessage()));
            _test.Log(Status.Info, "Verify Succcess Message");
            ContentDetailsPage.OpenItemScorm();
            _test.Log(Status.Info, "Click on open item ");
            Driver.focusParentWindow();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isRequiredDisplayFor("Before Course Start"));
            //ContentDetailsPage.SCROM.CompleteSCROMCourse();
            //_test.Log(Status.Info, "Complete Scorm Course ");
            ////Assert.IsTrue(Driver.comparePartialString("Warning This item needs to be marked complete manually. Mark this item as complete when you have finished reviewing the content.", ContentDetailsPage.getMarkCompleteSuccessMessage()));
            ////_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getAssociatedMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //_test.Log(Status.Info, "Verify Survey is Displayed");
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Verify Displayed Message");
            //Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            //_test.Log(Status.Info, "Click Attached Survey");
            //ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            //_test.Log(Status.Info, "Complete Survey");
            //Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.ClickViewCertificate();
            //_test.Log(Status.Pass, "Click View Certificate");
            //Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            //_test.Log(Status.Pass, "Verify certificate Page is displayed");
                   
            CommonSection.SearchCatalog(scormtitle + "TC35502_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35502_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            Assert.IsTrue(Driver.comparePartialString("You are now enrolled.", ContentDetailsPage.getEnrollmentSuccessMessage()));
            _test.Log(Status.Info, "Verify Succcess Message");
            ContentDetailsPage.OpenItemScorm();
            _test.Log(Status.Info, "Click on open item ");
            Driver.focusParentWindow();
            Assert.IsFalse(ContentDetailsPage.SurveyPortlet.isRequiredDisplayFor("Before Course Start"));
            //ContentDetailsPage.SCROM.CompleteSCROMCourse();
            //_test.Log(Status.Info, "Complete Scorm Course ");
            //Assert.IsTrue(Driver.comparePartialString("Warning This item needs to be marked complete manually. Mark this item as complete when you have finished reviewing the content.", ContentDetailsPage.getMarkCompleteSuccessMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getAssociatedMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //_test.Log(Status.Info, "Verify Survey is Displayed");
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Verify Displayed Message");

            //Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.ClickViewCertificate();
            //_test.Log(Status.Pass, "Click View Certificate");
            //Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            //_test.Log(Status.Pass, "Verify certificate Page is displayed");

            //#endregion


        }
        [Test]
        public void z03_Require_Survey_for_getting_a_certificate_AICC_35503()
        {
            //CommonSection.CreateLink.AICC();
            //UploadaiccPage.UploadfileandClickCreate();
            //CreateAICCPage.CreateAICC(AICCTitle + "TC35688");         //Complete AICC Course Creation
            //_test.Log(Status.Info, "Create a new AICC Course");

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Survey with Required Status Yes
            
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
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            #endregion
            #region survey with required No
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC35503_1");
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            
            SurveysPage.resultgrid.RequiredforFirstSurvey("No");
            _test.Log(Status.Pass, "Verify Required field is No");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            #endregion

            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(AICCTitle + "TC35503");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC35503");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            Assert.IsTrue(Driver.comparePartialString("You are now enrolled.", ContentDetailsPage.getEnrollmentSuccessMessage()));
            _test.Log(Status.Info, "Verify Succcess Message");
            ContentDetailsPage.OpenItemAICC();
            _test.Log(Status.Info, "Click on open item ");
            Driver.focusParentWindow();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isRequiredDisplayFor("Before Course Start"));
            //ContentDetailsPage.OpenItem.CompleteAICCCourse();           //write method to Complete AICC course
            //_test.Log(Status.Info, "Complete AICC Course ");
            //Assert.IsTrue(Driver.comparePartialString("Warning This item needs to be marked complete manually. Mark this item as complete when you have finished reviewing the content.", ContentDetailsPage.getMarkCompleteSuccessMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getAssociatedMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //_test.Log(Status.Info, "Verify Survey is Displayed");
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Verify Displayed Message");
            //Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            //_test.Log(Status.Info, "Click Attached Survey");
            //ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            //_test.Log(Status.Info, "Complete Survey");
            //Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.ClickViewCertificate();
            //_test.Log(Status.Pass, "Click View Certificate");
            //Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            //_test.Log(Status.Pass, "Verify certificate Page is displayed");



           
            CommonSection.SearchCatalog(AICCTitle + "TC35503_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC35503_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            Assert.IsTrue(Driver.comparePartialString("You are now enrolled.", ContentDetailsPage.getEnrollmentSuccessMessage()));
            _test.Log(Status.Info, "Verify Succcess Message");
            ContentDetailsPage.OpenItemAICC();
            _test.Log(Status.Info, "Click on open item ");
            Driver.focusParentWindow();
            Assert.IsFalse(ContentDetailsPage.SurveyPortlet.isRequiredDisplayFor("Before Course Start"));
            //ContentDetailsPage.OpenItem.CompleteAICCCourse();           //write method to Complete AICC course
            //_test.Log(Status.Info, "Complete AICC Course ");
            //Assert.IsTrue(Driver.comparePartialString("Warning This item needs to be marked complete manually. Mark this item as complete when you have finished reviewing the content.", ContentDetailsPage.getMarkCompleteSuccessMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getAssociatedMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //_test.Log(Status.Info, "Verify Survey is Displayed");
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Click on Mark Complete");
            //Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.ClickViewCertificate();
            //_test.Log(Status.Pass, "Click View Certificate");
            //Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            //_test.Log(Status.Pass, "Verify certificate Page is displayed");
            //#endregion

        }

        [Test]
        public void z04_Require_Survey_for_getting_a_certificate_Progress_Bundle_35504()
        {
            #region Survey with Required status Yes
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout with Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteadmin Account");

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "TC35504");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            Assert.IsTrue(CreatebundlePage.DisplayFormatDropdown.Defaultvalue("Bundle"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");
            AdminContentDetailsPage.EditBundle();
            _test.Log(Status.Info, "Click edit and Add Content");
            CommonSection.SearchCatalog(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEditContent();
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
         
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
         
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemBundle();
            _test.Log(Status.Info, "Click on Access Item");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Pass, "Verify Survey is Displayed");
            //  ---------------------------------------------------------

            ContentDetailsPage.ClickBundleContent();
            _test.Log(Status.Info, "Click on Bundle Content");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            ContentDetailsPage.OpenItemGeneral();
            _test.Log(Status.Info, "Click on Open Item");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Click on mark Complete");
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey("Before Course Start");
            _test.Log(Status.Info, "Complete Survey");
            Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            #endregion

            #region Survey with Required status Yes
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with site admin Account");

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "TC35504_1");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            Assert.IsTrue(CreatebundlePage.DisplayFormatDropdown.Defaultvalue("Bundle"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");
            AdminContentDetailsPage.EditBundle();
            _test.Log(Status.Info, "Click edit and Add Content");
            CommonSection.SearchCatalog(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEditContent();
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
           // AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("No");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35504");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemBundle();
            _test.Log(Status.Info, "Click on Access Item");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Pass, "Verify Survey is Displayed");
            ContentDetailsPage.ClickBundleContent();
            _test.Log(Status.Info, "Click on Bundle Content");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "Click on Open Item");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Verify Displayed Message");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");

            #endregion

        }

        [Test]
        public void z05_Require_Survey_for_getting_a_certificate_Classroom_35505()
        {
            #region Survey with Required Status Yes

            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout with SiteAdmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteadmin Account");
            CommonSection.CreateLink.ClassroomCourse();
            //_test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            //Assert.IsTrue(ClassroomCourse.DisplayFormatDropdown.Defaultvalue("Classroom"));
            //_test.Log(Status.Pass, "Verify Default value of Display Format is Classroom");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35505");
            _test.Log(Status.Info, "A new Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click Add New Section Tab");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");

            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");

            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            ContentPage.ClickAddContent("GeneralNew");
            _test.Log(Status.Pass, "Add Content To Classroom course");
            ContentPage.ContentTab.AvailabletoLearner("Yes, when learner enrolls");
            _test.Log(Status.Pass, "Select Available to Learner");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC35505");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35505");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click in Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC35505");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35505");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll");
            ContentDetailsPage.CourseMaterials.ClickContent("GeneralNew");
            _test.Log(Status.Info, "Click Content in Course Material");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "Click on Open New Attempt");
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //_test.Log(Status.Info, "Verify Survey is Displayed");
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Click on mark Complete");
            //Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");
            Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            #endregion


            #region Survey with Required Status No

            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout with SiteAdmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteadmin Account");
            CommonSection.CreateLink.ClassroomCourse();
            //_test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            //Assert.IsTrue(ClassroomCourse.DisplayFormatDropdown.Defaultvalue("Classroom"));
            //_test.Log(Status.Pass, "Verify Default value of Display Format is Classroom");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35505_1");
            _test.Log(Status.Info, "A new Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click Add New Section Tab");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");

            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");

            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            ContentPage.ClickAddContent("GeneralNew");
            _test.Log(Status.Pass, "Add Content To Classroom course");
            ContentPage.ContentTab.AvailabletoLearner("Yes, when learner enrolls");
            _test.Log(Status.Pass, "Select Available to Learner");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC35505_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35505_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click in Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC35505_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35505_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll");
            ContentDetailsPage.CourseMaterials.ClickContent("GeneralNew");
            _test.Log(Status.Info, "Click Content in Course Material");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "Click on Open New Attempt");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Click on mark Complete");

            #endregion

        }

        [Test]
        public void z06_Require_Survey_for_getting_a_certificate_Certification_35506()
        {
            #region Survey with Required status Yes 

            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC35506");
            _test.Log(Status.Info, "Fill title");
            Assert.IsTrue(CertificationPage.DisplayFormatDropdown.Defaultvalue("Document"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "A new Certification Created");
            ContentDetailsPage.EditAndAddCertificationContent();
            _test.Log(Status.Info, "Add certification Content");
            CommonSection.SearchCatalog(CertificatrTitle + "TC35506");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35506");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();

            CommonSection.SearchCatalog(CertificatrTitle + "TC35506");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35506");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemCertification();
            _test.Log(Status.Info, "Click Access Item");
            ContentDetailsPage.ClickCertificationContent();
            _test.Log(Status.Info, "click Certification Content");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "click on New Content");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Click on mark Complete");
            //Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            //_test.Log(Status.Pass, "Verify View Certificate Button is displayed");

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");

            #endregion


            #region Survey with Required status No 

            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC35506_1");
            _test.Log(Status.Info, "Fill title");
            Assert.IsTrue(CertificationPage.DisplayFormatDropdown.Defaultvalue("Document"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "A new Certification Created");
            ContentDetailsPage.EditAndAddCertificationContent();
            _test.Log(Status.Info, "Add certification Content");
            CommonSection.SearchCatalog(CertificatrTitle + "TC35506_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35506_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();

            CommonSection.SearchCatalog(CertificatrTitle + "TC35506_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35506_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemCertification();
            _test.Log(Status.Info, "Click Access Item");
            ContentDetailsPage.ClickCertificationContent();
            _test.Log(Status.Info, "click Certification Content");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "click on New Content");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Click on mark Complete");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            #endregion


        }

        [Test]
        public void z07_Require_Survey_for_getting_a_certificate_Curriculum_35507()
        {
            #region Survey with Required Status Yes

            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "TC35507");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            Assert.IsTrue(CreateCurriculumnPage.DisplayFormatDropdown.Defaultvalue("Curriculum"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Curriculum");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            ContentDetailsPage.EditCurriculumsContent();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("AfreenBlock");
            CurriculumContentPage.ClickAddTrainingActivities("General");
            CommonSection.SearchCatalog(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Click Course Title");



            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();

            CommonSection.SearchCatalog(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemCertification();
            _test.Log(Status.Info, "Click Access Item");
            ContentDetailsPage.ClickCertificationContent();
            _test.Log(Status.Info, "click Certification Content");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "click on New Content");
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");

            #endregion


            #region Survey with Required Status No
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "TC35507_1");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            Assert.IsTrue(CreateCurriculumnPage.DisplayFormatDropdown.Defaultvalue("Curriculum"));
            _test.Log(Status.Pass, "Verify Default value of Display Format is Curriculum");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            ContentDetailsPage.EditCurriculumsContent();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("AfreenBlock");
            CurriculumContentPage.ClickAddTrainingActivities("General");
            CommonSection.SearchCatalog(curriculamtitle + "TC35507_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35507_1");
            _test.Log(Status.Info, "Click Course Title");



            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("No");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();

            CommonSection.SearchCatalog(curriculamtitle + "TC35507_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35507_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemCertification();
            _test.Log(Status.Info, "Click Access Item");
            ContentDetailsPage.ClickCertificationContent();
            _test.Log(Status.Info, "click Certification Content");
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "click on New Content");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");





            #endregion


        }


        [Test]
        public void z08_Require_Survey_for_getting_a_certificate_OJT_35508()
        {
            #region Survey with Required Status Yes

            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();


            CommonSection.CreateLink.OJT();
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The item was created.";
            CommonSection.CreateLink.OJT();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            string actres = onlinejobtraining.buttoncreateclick(driver);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            _test.Log(Status.Info, "Create a new On Job Training");
            AdminContentDetailsPage.CreateAndManageChecklists();
            _test.Log(Status.Info, "Click on Create & Manage Checklist Tab");
            ChecklistsPage.CreateAndManageCheckListTab.CreateNewCheckListInAnyOrder();
            _test.Log(Status.Info, "Click Create New Checklist in Any order Section");
            CreateChecklistPage.Create("Checklist" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "Create New Checklist ");
            ContentDetailsPage.AddaNewSection("NewSection");
            ChecklistsPage.EditSection.CreateQuestion("Radio Button");
            CreateChecklistPage.Publish();

            CommonSection.SearchCatalog(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr);
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr);
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();

            CommonSection.SearchCatalog(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemOJT();
            _test.Log(Status.Info, "Click Access Item");
            ContentDetailsPage.OnTheJobTrainingActivities.CompleteContent("Checklist" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "Click on content");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Click on mark Complete");
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");

            #endregion


            #region Survey with Required Status NO


            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();


            CommonSection.CreateLink.OJT();
            //OJT onlinejobtraining = new OJT(driver);
            //string expectedresult = " The item was created.";
            CommonSection.CreateLink.OJT();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            actres = onlinejobtraining.buttoncreateclick(driver);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            _test.Log(Status.Info, "Create a new On Job Training");
            AdminContentDetailsPage.CreateAndManageChecklists();
            _test.Log(Status.Info, "Click on Create & Manage Checklist Tab");
            ChecklistsPage.CreateAndManageCheckListTab.CreateNewCheckListInAnyOrder();
            _test.Log(Status.Info, "Click Create New Checklist in Any order Section");
            CreateChecklistPage.Create("Checklist" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "Create New Checklist ");
            ContentDetailsPage.AddaNewSection("NewSection");
            ChecklistsPage.EditSection.CreateQuestion("Radio Button");
            CreateChecklistPage.Publish();

            CommonSection.SearchCatalog(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr);
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr);
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("No");
            _test.Log(Status.Pass, "Verify Required field is No");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();

            CommonSection.SearchCatalog(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35507");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.AccessItemOJT();
            _test.Log(Status.Info, "Click Access Item");
            ContentDetailsPage.OnTheJobTrainingActivities.CompleteContent("Checklist" + Meridian_Common.globalnum);
            _test.Log(Status.Info, "Click on content");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            _test.Log(Status.Info, "Verify Survey is Displayed");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Click on mark Complete");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");

            #endregion


        }



        [Test]
        public void z09_Require_Survey_for_getting_a_certificate_Subscription_35509()
        {
            #region Survey: Required Field Disabled

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
            Assert.IsFalse(SurveysPage.resultgrid.isRequiredforSurveyDisabled());
            _test.Log(Status.Pass, "Verify Required field is Disabled");

            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(SubscriptionsTitle + "TC35509");
            SearchResultsPage.ClickCourseTitle(SubscriptionsTitle + "TC35509");

            ContentDetailsPage.AccessItemSubscription();
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            _test.Log(Status.Info, "click on New Content");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            //_test.Log(Status.Info, "Verify Survey is Displayed");
            //ContentDetailsPage.MarkComplete();
            //_test.Log(Status.Info, "Click on mark Complete");
            ContentDetailsPage.ClickViewCertificate();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            #endregion


        }

        [Test]
        public void z10_Require_Survey_for_getting_a_certificate_Content_Bundle_35532()
        {
            #region Survey: Required Field Disabled


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
            Assert.False(SurveysPage.resultgrid.isRequiredforSurveyDisabled());
            _test.Log(Status.Pass, "Verify Required field is Disabled");
            CommonSection.Logout();
            LoginPage.LoginAs("learner").WithPassword("").Login();
            CommonSection.SearchCatalog(generalcoursetitle + "TC35532");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35532");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.isSurveyDisplay());
            ContentDetailsPage.OpenNewAttempt.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            #endregion

        }
    }
}


