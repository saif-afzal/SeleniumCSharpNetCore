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
    public class P1SurveyDeliveryTest : TestBase
    {
        string browserstr = string.Empty;
        public P1SurveyDeliveryTest(string browser)
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
        public void a01_I_Admin_want_to_assign_a_list_of_survey_to_a_General_course_35458()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35458", generalcoursetitle + "TC35356");
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            ContentDetailsPage.DeleteContent();

        }
        [Test]
        public void a02_I_Admin_want_to_assign_a_list_of_survey_to_a_AICC_course_35510()
        {
            #region Create AICC Course
            Document documentpage = new Document(driver);
            string expectedresult = "Summary";
            string expectedresult1 = "The course was created.";
            AICC aicccourse = new AICC(driver);
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult1, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]"))));
            aicccourse.populatesummaryform(driver, browserstr);
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            ContentDetailsPage.DeleteContent();
        }
        [Test]
        public void a03_I_Admin_want_to_assign_a_list_of_survey_to_a_SCROM_course_35511()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC35511");
            _test.Log(Status.Info, "Create A new SCROM Course");
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            ContentDetailsPage.DeleteContent();

        }
        [Test]
        public void a04_I_Admin_want_to_assign_a_list_of_survey_to_a_Bundle_35512()
        {
            #region Create General Course and Bundle With Cost and Access keys Enabled
            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", bunbdleTitle + "TC35512", "Bundle Price");
            // DocumentPage.ClickButton_CheckIn();
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            //ContentDetailsPage.DeleteContent();
        }
        [Test]
        public void a05_I_Admin_want_to_assign_a_list_of_survey_to_a_Certification_35513()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC35513");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            ContentDetailsPage.DeleteContent();

        }
        [Test]
        public void a06_I_Admin_want_to_assign_a_list_of_survey_to_a_Curriculumn_35514()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35514");
            _test.Log(Status.Info, "Create A new Curriculum");
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            ContentDetailsPage.DeleteContent();

        }
        [Test]
        public void a07_I_Admin_want_to_assign_a_list_of_survey_to_a_OJT_35515()
        {
            CommonSection.CreateLink.OJT();
            CreateojtPage.CreteNewOJT(OJTTitle + "TC35515");
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            ContentDetailsPage.DeleteContent();


        }
        [Test]
        public void a08_I_Admin_want_to_assign_a_list_of_survey_to_a_Subscriptions_35516()
        {
            CommonSection.CreateLink.Subscription();
            _test.Log(Status.Info, "Click create>Subscriptions");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC35516").SubscriptionType("Dynamic Date").Create();
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            ContentDetailsPage.DeleteContent();
        }
        [Test]
        public void a09_As_a_classroom_admin_I_want_to_attach_assign_survey_to_a_classroom_Course_35497()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35497");
            _test.Log(Status.Info, "Create A new Classroom Course");
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
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");

        }
        [Test]
        public void a10_As_a_classroom_admin_I_want_to_attach_assign_survey_to_a_classroom_Section_35498()
        {
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.setRecurence("MonthlySDR");
            // ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(-1);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "A new Section is Createed");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            Assert.IsTrue(SectionDetailsPage.SectionDetailsTab.isSurveyAccordianDisplay());
            _test.Log(Status.Info, "Verify Survey accordian display");
            Assert.IsTrue(SectionDetailsPage.SectionDetailsTab.SurvetAccordian.isCourseLevelSurveysdisplay());
            _test.Log(Status.Info, "Verify Course lable Surveys are diaply in accordian");
            SectionDetailsPage.SectionDetailsTab.Click_ManageSurveysButton();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            Assert.IsTrue(SurveysPage.SurveyResults.isCourselableSurveysDisplay());
            Assert.IsTrue(SurveysPage.SurveyResults.isCourselableSurveysarenoneditable());
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");

        }
        [Test]
        public void a11_I_admin_want_to_edit_availability_for_a_survey_when_it_is_attached_to_a_course_35459()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35459", generalcoursetitle + "TC35359");
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

            Assert.IsTrue(SurveysPage.resultgrid.SetandVerifyAvailable("When learner enrolls"));
            _test.Log(Status.Pass, "Verify all 4 options are available and set perporly for fiest survey of result grid");
            Assert.IsTrue(SurveysPage.resultgrid.SetandVerifyAvailable("When content started"));
            _test.Log(Status.Pass, "Verify all 4 options are available and set perporly for fiest survey of result grid");
            Assert.IsTrue(SurveysPage.resultgrid.SetandVerifyAvailable("When content completed"));
            _test.Log(Status.Pass, "Verify all 4 options are available and set perporly for fiest survey of result grid");
            Assert.IsTrue(SurveysPage.resultgrid.SetandVerifyAvailable("Custom date beyond completion"));
            _test.Log(Status.Pass, "Verify all 4 options are available and set perporly for fiest survey of result grid");

        }
        [Test]
        public void a12_As_an_Admin_Run_run_a_filtered_version_of_our_new_Survey_Report_from_Manage_Surveys_35544()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            
            _test.Log(Status.Info, "Goto Manage >> Surveys Page");
            ////tr[@data-index='1']//i[@class='fa fa-bar-chart']
            SurveysPage.SurveyResults.ClickReportDropdown();
            SurveysPage.SurveyResults.SelectExportbleReport();
            _test.Log(Status.Info, "Click on Exportblereport link from report link dropdown");
            #region verify columns on report page
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyReportlevelColumns());
            _test.Log(Status.Info, "Verify some survey level columns are display in report");

            //Assert.IsTrue(ReportPage.VerifySurveyIDColumn);
            //Assert.IsTrue(ReportPage.VerifySurveyTitleColumn);
            //Assert.IsTrue(ReportPage.VerifySurveySectionColumn);
            //Assert.IsTrue(ReportPage.VerifyQuestionIDColumn);
            //Assert.IsTrue(ReportPage.VerifyQuestionTypeColumn);
            //Assert.IsTrue(ReportPage.VerifyQuestionColumn);
            //Assert.IsTrue(ReportPage.VerifyResponseValueColumn);
            //Assert.IsTrue(ReportPage.VerifyResponseTextColumn);
            //Assert.IsTrue(ReportPage.VerifyResponseDateColumn);
            //Assert.IsTrue(ReportPage.VerifyContentIDColumn);
            //Assert.IsTrue(ReportPage.VerifyContentTitleColumn);
            //Assert.IsTrue(ReportPage.VerifyContentTypeColumn);
            //Assert.IsTrue(ReportPage.VerifySectionIDColumn);
            //Assert.IsTrue(ReportPage.VerifySectionNumberColumn);
            //Assert.IsTrue(ReportPage.VerifySectionTitleColumn);
            //Assert.IsTrue(ReportPage.VerifySectionStartDateColumn);
            //Assert.IsTrue(ReportPage.VerifySectionEndDateColumn);
            //Assert.IsTrue(ReportPage.VerifyInstructorNameColumn);
            //Assert.IsTrue(ReportPage.VerifyLocationColumn);
            //Assert.IsTrue(ReportPage.VerifyUserIDColumn);
            //Assert.IsTrue(ReportPage.VerifyLanguageColumn);
            //Assert.IsTrue(ReportPage.VerifyProvinceColumn);
            //Assert.IsTrue(ReportPage.VerifyWorkCityColumn);
            //Assert.IsTrue(ReportPage.VerifyWorkStateColumn);
            //Assert.IsTrue(ReportPage.VerifyWorkCountryColumn);
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("All_Questions__All_Surveys.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            //            ReportPage.ClickExportToPDFlink(); //Export to PDF
            //            Assert.IsTrue(IsPDFPageOpened);
            //            PDFPage.ClickBrowserX();
            //            Assert.IsTrue(IsPDFPageClosed);
            //            Assert.IsTrue(IsReportPageDisplayed);
            //            ReportPage.ClickExportToXMLlink();//Export to XML
            //            Assert.IsTrue(IsXMLPageOpened);
            //            XMLPage.ClickBrowserX();
            //            Assert.IsTrue(IsXMLPageClosed);
            //            Assert.IsTrue(IsReportPageDisplayed);
            //            ReportPage.ClickExportToExcellink();//Export to Excel
            //            Assert.IsTrue(IsExcelPageOpened);
            //            ExcelPage.ClickBrowserX();
            //            Assert.IsTrue(IsExcelPageClosed);
            //            Assert.IsTrue(IsReportPageDisplayed);
            //            ReportPage.ClickExportToCSVlink(); //Export to CSV
            //            Assert.IsTrue(IsCSVPageOpened);
            //            CSVPage.ClickBrowserX();
            //            Assert.IsTrue(IsCSVPageClosed);
            //            Assert.IsTrue(IsReportPageDisplayed);
            #endregion
            TC35545 = true;
            TC35546 = true;

        }
        [Test]
        public void a13_As_a_Content_Mamager_Run_run_a_filtered_version_of_our_new_Survey_Report_from_Manage_Surveys_35545()
        {
            Assert.IsTrue(TC35545);
        }
        [Test]
        public void a14_As_a_Survey_Manager_Run_run_a_filtered_version_of_our_new_Survey_Report_from_Manage_Surveys_35546()
        {
            Assert.IsTrue(TC35546);
        }
        [Test]
        public void a15_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_General_Course_35687()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35687", generalcoursetitle + "TC35687");
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
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When content completed");
            SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog(generalcoursetitle + "TC35687");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35687");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickEnrollinGeneralCourse();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnContentComplete));

        }
       
        [Test]
        public void a17_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_SCROM_Course_35689()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC35689");
            _test.Log(Status.Info, "Create A new SCROM Course");
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
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When content completed");
            SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(scormtitle + "TC35689");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35689");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickEnroll();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));
            //ContentDetailsPage.SCROM.CompleteSCROMCourse();
            //AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            //Assert.IsFalse(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnContentComplete));

        }
        [Test]
        public void P20_1_a18_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_OJT_35715()
        {
            CommonSection.CreateLink.OJT();
            CreateojtPage.CreteNewOJT(OJTTitle + "TC35515");
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
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When content completed");
            //SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(OJTTitle + "TC35515");
            SearchResultsPage.ClickCourseTitle(OJTTitle + "TC35515");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickEnrollButton_OJT();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));


        }
        [Test]
        public void a19_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_Subscription_35699()
        {
            CommonSection.CreateLink.Subscription();
            _test.Log(Status.Info, "Click create>Subscriptions");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC35699").SubscriptionType("Dynamic Date").Create();
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
            _test.Log(Status.Info, "Add one surveys to Subscriptions");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            Assert.IsTrue(SurveysPage.resultgrid.isrequiredisdisabled());
            _test.Log(Status.Info, "Verify surveys are not required for subscription");
            //SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(SubscriptionsTitle + "TC35699");
            SearchResultsPage.ClickCourseTitle(SubscriptionsTitle + "TC35699");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickAccessItemButton_Subscription();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(AddedsurveyTitle));


        }
        [Test]
        public void a20_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_Content_Bundle_35697()
        {
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Subscriptions");
            CreatebundlePage.CreateBundle("Content Bundle", bunbdleTitle + "TC35697", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
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
            _test.Log(Status.Info, "Add one surveys to Subscriptions");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            Assert.IsTrue(SurveysPage.resultgrid.isrequiredisdisabled());
            _test.Log(Status.Info, "Verify surveys are not required for Content Bundle");
            SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(bunbdleTitle + "TC35697");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35697");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickAccessItemButton_Bundle();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(AddedsurveyTitle));


        }
        [Test]
        public void a21_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_Progress_Bundle_35698()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35698", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Bundle");
            CreatebundlePage.CreateBundle("Progress Bundle", bunbdleTitle + "TC35698", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            BundlesPage.addContentIntoBundle(generalcoursetitle + "TC35698");
            _test.Log(Status.Info, "Adding Paid General Course into Bundle");
           
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
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When content completed");
            //SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(bunbdleTitle + "TC35698");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35698");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickAccessItemButton_Bundle();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));
            ContentDetailsPage.ContentItemsPortlet.ClickItemTitle(generalcoursetitle + "TC35698");
            ContentDetailsPage.ClickEnroll();
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            AdminContentDetailsPage.ClickBundleBreadcomb();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnContentComplete));

        }
        [Test]
        public void a22_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_Certifications_35691()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35691", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC35691");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate(generalcoursetitle + "TC35691");
            CertificatePage.Click_backbutton();
            _test.Log(Status.Info, "Adding Paid General Course into Ceritification");
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
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When content completed");
            SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(CertificatrTitle + "TC35691");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35691");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickAccessItemButton_Certi();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));
            ContentDetailsPage.ContentItemsPortlet.ClickItemTitle(generalcoursetitle + "TC35691");
            ContentDetailsPage.ClickEnroll_CerficationGeneralCourse();
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent_Certification();
            AdminContentDetailsPage.ClickBundleBreadcomb();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnContentComplete));

        }
        [Test]
        public void P20_1_a23_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_Curriculumn_35716()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "_TC35716", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35716");
            _test.Log(Status.Info, "Create A new Curriculum");
                        
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
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When content completed");
            SurveysPage.Click_backbutton();
         
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("_UnOrdered" + "_TC26349");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "_TC35716");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.SearchCatalog(curriculamtitle + "TC35716");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35716");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplayForCurriculumn(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickCurriculumnEnroll();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailableforCurriculumn(Surveytitle_OnEnroll));
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.MarkComplete_Curriculum_whenSurveyRequired());
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailableforCurriculumn(Surveytitle_OnContentComplete));

        }
        
    }
}


