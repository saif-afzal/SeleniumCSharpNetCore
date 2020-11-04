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
    public class P1_Catalog_AICCContentDetailPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_AICCContentDetailPagesTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string AICCCourseTitle = "AICC" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle= "TA" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        bool TC59990, TC60002;
        bool TC60004;
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        [Test, Order(01)]
        public void P20_1_tc_26953_View_Prerequisities_to_AICC_Course()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC26953");
            _test.Log(Status.Info, "Create a general Course for Prerequisite");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckIn();
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            
            CreateAICCPage.Title(AICCCourseTitle + "TC26953");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_Prerequisites(GeneralCourseTitle + "TC26953");
            _test.Log(Status.Pass, "Click edit Prerequisite and add Prerequisite");
            //Assert.IsTrue(Driver.comparePartialString(" The selected items were added as prerequisites." +
            //    " If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "Verify  Success message");
            PrerequisitesPage.Click_BreadCrumb();
            _test.Log(Status.Pass, "Click breadcrumbs");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");

            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPrerequisiteStatusDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite status is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPrerequisiteCostDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite Cost is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPrerequisiteTitleDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite Cost is Displayed");
            ContentDetailsPage.OverviewTab.Prerequisiteportlet.ClickPrerequisiteContentTitle(GeneralCourseTitle + "TC26953");
            _test.Log(Status.Info, "Click Prerequisite Title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "TC26953"));

        }
        [Test, Order(2)]
        public void tc_59840_AICC_Overview_Tab_Learner_finds_What_is_content_About()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
                      
            CreateAICCPage.Title(AICCCourseTitle + "TC59840");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");

            AdminContentDetailsPage.CourseInformation.ClickEditButton();
            CourseInformationPage.CourseProvider.Select("Meridian");
            CourseInformationPage.EnterDuration("5");
            CourseInformationPage.clickSave();

            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.CreditTypeAccordian.ClickManage();
            NewCreditTypePage.AddDefaultCreditValue("5");

            ContentDetailsPage.PromotionalVideo.Click_Edit();
            PromotionalVideoPage.AddNewURL("//www.youtube.com/embed/Fc1P-AEaEp8");
            PromotionalVideoPage.Click_SaveButton();
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Aicc course checked in");

            CommonSection.SearchCatalog(AICCCourseTitle + "TC59840");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC59840");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "TC59840"));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());   //AC1
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isCourseProviderDisplay()); //AC3
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDurationDisplay());  //AC2
            Assert.IsTrue(ContentDetailsPage.OverviewTab.CreditPortlet.isCreditScoreDisplay() >= 0);
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPromotionalVideodisplay()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page overview tab");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());

        }
        [Test, Order(3)]
        public void tc_59282_As_Learner_AICC_Overview_Tab_What_other_content_can_I_take()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC59282", generalcoursetitle + "TC34839");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddCourseProvider("Meridian");
            string CourseProvider = ContentDetailsPage.CourseProviderAccodian.CourseProvidername();
            GeneralCoursePage.ClickCheckIn();

            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC59282");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            GeneralCoursePage.AddCourseProvider("Meridian");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + AICCCourseTitle + "TC59282" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC59282");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isMorelikethisPortletDisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            Assert.IsTrue(ContentDetailsPage.isSameCourseProviderrelatedContentDisplay(CourseProvider));
        }
        [Test, Order(4)]
        public void P20_1_tc_27144_Curriculums_Containing_an_AICC_Course()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC27144");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC27144");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC27144");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(AICCCourseTitle + "TC27144");

            DocumentPage.ClickButton_CheckIn();

            CommonSection.SearchCatalog(AICCCourseTitle + "TC27144");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC27144");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "TC27144"));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay());
            _test.Log(Status.Pass, "Verify is part of these collestion portlet display");
            ContentDetailsPage.OverviewTab.clicktoexpandPartoftheseCollectionPortlet();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.PartoftheseCollection.isContentdisplay(curriculamtitle + "_TC27144"));
            _test.Log(Status.Pass, "Verify Curriculum title is display in part of these collestion portlet");
        }
        [Test, Order(5)]
        public void tc_59883_AICC_Overview_Tab_Prerequisites_Training_Assignments_Surveys_Evaluation()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC59883");
            _test.Log(Status.Info, "Create a general Course for Prerequisite");
            DocumentPage.ClickButton_CheckIn();
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC59883");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_Prerequisites(GeneralCourseTitle + "TC59883");
            _test.Log(Status.Pass, "Click edit Prerequisite and add Prerequisite");
            //Assert.IsTrue(Driver.comparePartialString(" The selected items were added as prerequisites." +
            //    " If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "Verify  Success message");
            PrerequisitesPage.Click_BreadCrumb();
            _test.Log(Status.Pass, "Click breadcrumbs");
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
            SurveysPage.Click_backbutton();
            DocumentPage.ClickButton_CheckIn();

            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "_TC59883");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(AICCCourseTitle + "TC59883");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("learner 101");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("days");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickDueDateTab();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            _test.Log(Status.Pass, "Verify Copletion count saved properly");
            CreateTrainingAssignmentPage.clickAssignButton();
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();

            CommonSection.SearchCatalog(AICCCourseTitle + "TC59883");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC59883");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.issurveyPortletisDisplay());


        }
        [Test, Order(6)]
        public void tc_59939_Learner_view_AICC_history_tab_on_Content_Details_page()
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

            CreateAICCPage.Title(AICCCourseTitle + "TC59939");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new AICC is Created");
            CommonSection.SearchCatalog(AICCCourseTitle + "TC59939");
            _test.Log(Status.Info, "Searched created AICC");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC59939");
            _test.Log(Status.Info, "Click on Aicc course title");
            Assert.IsFalse(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify History tab is not displayed");
            ContentDetailsPage.ContentBanner.Click_Enrollbutton();
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.isAICCCourseOpened());
            ContentDetailsPage.CloseAICCModal();

            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify History tab is displayed");
            //Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            //Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            //Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());

            ContentDetailsPage.Click_HistoryTab_Curriculum();
            //Assert.IsFalse(ContentDetailsPage.Historytab.isViewCertificateButtonDisplay());
            //_test.Log(Status.Pass, "Verify View Certification button should not display");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isStatusDisplay("Started"));
            _test.Log(Status.Pass, "Verify Completed status displayed");
        }
        [Test, Order(7)]
        public void tc_60042_AICC_Review()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC60042");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("password").Login();
            CommonSection.SearchCatalog(AICCCourseTitle + "TC60042");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC60042");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            _test.Log(Status.Info, "Click Review Tab");
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay()); //AC1
            ContentDetailsPage.EnrollinGeneralCourse_new();
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay()); //AC1
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));
            _test.Log(Status.Pass, "Review submited");
        }
        [Test, Order(8)]
        public void tc_59986_AICC_Banner_Actions_Edit_Save_and_Share()
        {
                        
            CommonSection.SearchCatalog(AICCCourseTitle + "TC60042");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC60042");
            _test.Log(Status.Info, "Click on Genaral Course title");
            Assert.IsTrue(ContentDetailsPage.isOnlySaveandSharebuttndisplay());
            ContentDetailsPage.ClickSaveButton();
            Assert.IsTrue(ContentDetailsPage.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Click at Green saved button ");
            Assert.IsTrue(ContentDetailsPage.SocialSharingDropDown("Facebook"));
            _test.Log(Status.Pass, "verify the facebook ");

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.SearchCatalog(AICCCourseTitle + "TC60042");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC60042");
            Assert.IsTrue(ContentDetailsPage.isSaveShareandEditContentbuttndisplay());
            _test.Log(Status.Pass, "Verify Save, Share and Edit content button is displayed");
            ContentDetailsPage.ClickEditContent_New19_2();
            Assert.IsTrue(AdminContentDetailsPage.isContentopened(AICCCourseTitle + "TC60042"));
            _test.Log(Status.Pass, "Verify edit content opens admin content details page");
            
        }
        [Test, Order(9)]
        public void tc_59985_AICC_Banner_Actions_Course_Info_and_Navigation()
        {

            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC59985");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
           
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            StringAssert.AreEqualIgnoringCase("The file was uploaded.", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            //ContentDetailsPage.AddLocale();   don't have other local in external
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.SearchCatalog(AICCCourseTitle + "TC59985");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC59985");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(AICCCourseTitle + "TC59985"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
        }
        [Test, Order(10)]
        public void tc_59988_AICC_Banner_Actions_Request_Access()
        {
            #region Create a AICC course
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC59988");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());

            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(AICCCourseTitle + "TC59988");
            _test.Log(Status.Info, "Searched created AICC Course");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC59988");
            _test.Log(Status.Info, "Click on AICC Course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display on Banner");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.ContentBanner.ClickViewRequestHistory();
            Assert.IsTrue(ContentDetailsPage.isHistorywindowopened());

            Assert.IsTrue(ContentDetailsPage.Historywin.isfieldsdisplay(AICCCourseTitle + "TC59988", "Content type", "status"));
            Driver.Instance.SelectWindowClose2("History", Meridian_Common.parentwdw);
            
            ContentDetailsPage.AccessApprovalModal.SubmitCancelRequestAccess("ForTest");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Info, "Verify Cancel Request access wotk flow");
            TC59990 = true;
        }
        [Test, Order(13)]
        public void tc_59990_AICC_Banner_Actions_View_History_for_requesting_access()
        {
            Assert.IsTrue(TC59990);
            _test.Log(Status.Info, "History link displayed on banner after made request access");
        }
        [Test, Order(14)]
        public void tc_59996_AICC_Banner_Actions_Add_To_Cart()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Create a AICC course
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC59996");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Document");
            ContentDetailsPage.ClickEditContent_New19_2();
            _test.Log(Status.Info, "Click Edit Content");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();

            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Add to Cart Button is Displayed");
        }
        [Test, Order(15)]
        public void tc_60001_AICC_Banner_Actions_Enroll_in_content()
        {
            #region Create a AICC course
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC560001");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
                       
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            #endregion
            CommonSection.SearchCatalog(AICCCourseTitle + "TC560001");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC560001");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            ContentDetailsPage.EnrollinGeneralCourse_new();
            //StringAssert.AreEqualIgnoringCase("Success\r\nYou are now enrolled.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancelEnrolllinkDisplay_GeneralCourse());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_CancelEnrollmetlink();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "Verify Enroll button display");
            TC60002 = true;

        }
        [Test, Order(16)]
        public void tc_60002_AICC_Banner_Aactions_Cancel_enrollment()
        {
            Assert.IsTrue(TC60002);
        }
        [Test, Order(17)]
        public void tc_60003_AICC_Banner_Actions_Open_Item()
        {
            #region Create a AICC course
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC560003");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());

            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            #endregion
            CommonSection.SearchCatalog(AICCCourseTitle + "TC560003");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC560003");
            ContentDetailsPage.ContentBanner.Click_Enrollbutton();
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Info, "Start Aicc course");
            Assert.IsTrue(ContentDetailsPage.isAICCCourseOpened());
            ContentDetailsPage.CloseAICCModal();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            _test.Log(Status.Pass, "Verify is Continue button display");
            TC60004 = true;
        }
        [Test, Order(18)]
        public void tc_60004_AICC_Banner_Actions_Resume_course_content()
        {
            Assert.IsTrue(TC60004);
        }
        [Test, Order(19)]
        public void tc_60021_AICC_Banner_Actions_Access_Keys()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");

            CreateAICCPage.Title(AICCCourseTitle + "TC60021");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            DocumentPage.ClickButton_CheckIn();
            //Driver.CreateNewAccount();
            // _test.Log(Status.Info, "Create new user account");
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner105").WithPassword("").Login();
            CommonSection.SearchCatalog(AICCCourseTitle + "TC60021");
            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC60021");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            ContentDetailsPage.OverviewTab.click_AddtoCart();

            CommonSection.Completepurchage(AICCCourseTitle + "TC60021");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Enrollbutton();
   
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
           
        }
    }
}



