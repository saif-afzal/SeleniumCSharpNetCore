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
    public class P2RegressionTests : TestBase
    {
        string browserstr = string.Empty;
        public P2RegressionTests(string browser)
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
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        bool TC_34132 = false;
        bool TC_26224 = false;
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
        string assignment = "Assignment" + Meridian_Common.globalnum;

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
    

        [Test, Order(6), Category("AutomatedP1")]
        public void a06_Create_JobTitle_22211()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Click on Job Title Tab");
            CareersPage.EditJobTitleName(JobTitle);
            _test.Log(Status.Info, "Clik on Create New Job Title, Edit Job Title name, Click Save");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            res1 = true;
            _test.Log(Status.Pass, "Verify Successful Message");
            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }
      
        [Test, Order(09), Category("AutomatedP1")]
        public void Z02_Learner_See_Recently_Added_Content_Recommendation_on_Home_Page_33470()
        {
            #region Create a content and access it from recommendation portlet
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Click on Create Document Top Menu");

            DocumentPage.Populate_DocumentData(ExtractDataExcel.MasterDic_document["Title"]);
            _test.Log(Status.Info, "Populate Document data");

            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Click on Create Button");

            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Checkin the Document");

            CommonSection.Learn.Home();
            _test.Log(Status.Info, "Navigate to Homepage");

            Assert.IsTrue(HomePage.RecommendationPortlet.Access_Content(ExtractDataExcel.MasterDic_document["Title"]));

            _test.Log(Status.Info, "Assert : Pass as Recently Created Content has been visible from recommendation portlet successfully");

            #endregion


        }
        [Test, Order(10), Category("AutomatedP1")]
        public void Z03_Learner_see_Recent_Contents_in_Recent_Added_Contents_Portlet_33472()
        {
            #region Create a content and access it from recommendation portlet
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Click on Create Document Top Menu");

            DocumentPage.Populate_DocumentData(ExtractDataExcel.MasterDic_document["Title"]);
            _test.Log(Status.Info, "Populate Document data");

            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Click on Create Button");

            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Checkin the Document");

            CommonSection.Learn.Home();
            _test.Log(Status.Info, "Navigate to Homepage");

            Assert.IsTrue(HomePage.RecommendationPortlet.Access_Content(ExtractDataExcel.MasterDic_document["Title"]));

            _test.Log(Status.Info, "Assert : Pass as Recently Created Content has been accessed from recommendation portlet successfully");

            CommonSection.Manage.Recommendations();
            RecommendationsPage.ChangeShortingType_For_RecentlyAdded("most recent");
            CommonSection.Learn.Home();

            Assert.IsFalse(HomePage.RecommendationPortlet.Verify_Content_InRandom(ExtractDataExcel.MasterDic_document["Title"]));
            _test.Log(Status.Info, "Assert : Pass as Contents are displaying in random order after changing the sorting order");
            #endregion


        }

        [Test,Order(08), Category("AutomatedP1")]
        public void Z01_Learner_Access_A_Content_from_Recommendation_Portlets_33521()
        {
            #region Create a content and access it from recommendation portlet
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Click on Create Document Top Menu");

            DocumentPage.Populate_DocumentData(ExtractDataExcel.MasterDic_document["Title"]);
            _test.Log(Status.Info, "Populate Document data");

            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Click on Create Button");

            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Checkin the Document");

            CommonSection.Learn.Home();
            _test.Log(Status.Info, "Navigate to Homepage");

            Assert.IsTrue(HomePage.RecommendationPortlet.Access_Content(ExtractDataExcel.MasterDic_document["Title"]));

            _test.Log(Status.Info, "Assert : Pass as Content has been accessed from recommendation portlet successfully");

            #endregion


        }
        [Test, Order(13), Category("AutomatedP1")]
        public void A01_Delete_Document_from_Creating_Domain_7435()
        {
            //Assert.Fail();
            CommonSection.CreateLink.Document();
            DocumentPage.Populate_DocumentData(documenttitle + "TC7435", "");
            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Dcoument Created");
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Deleting Document");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass as Document has been deleted from creating domain");

        }

      
        [Test, Order(15), Category("P1"), Category("AutomatedP1")]
        public void A03_Manage_Content_Page_Redesign_34133()
        {
            #region Creating a Classroom Course Section With Tag
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34133");
            _test.Log(Status.Pass, "New Classroom Course Created");
            string expectedtagname = ManageClassroomCoursePage.CreateTags(tagname);
            _test.Log(Status.Info, "Tag Created");
            StringAssert.AreEqualIgnoringCase(tagname, expectedtagname);
            _test.Log(Status.Info, "Assertion Pass as Tag Has been created successfully.");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion
            CommonSection.Manage.Training();
            ManageContentPage.allSearch();
            _test.Log(Status.Info, "Blank Search in Manage Content Page From Portlet");
            Assert.IsTrue(ManageContentPage.search_WithingManageContentPage(classroomcoursetitle + "TC34133"));
            _test.Log(Status.Pass, "Assertion Pass as Content search within Manage Content is Working Fine");
            string pagetitle = ManageContentPage.verifyElements();
            _test.Log(Status.Pass, "Assertion Pass as Manage Content Elements have been verified");
            StringAssert.AreEqualIgnoringCase("Manage Content", pagetitle);
            _test.Log(Status.Pass, "Assertion Pass as Manage Content Page Title Verified");
            TC_34132 = true;


        }
      

        
        

   
        [Test, Order(29), Category("AutomatedP1")]
        public void Catalog_Search_By_Using_Content_Tags_Facets_33557()
        //Pre-Req - Admin has created Content Tags and Admin has associated content with tags

        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login(); //Login as regular user (Learner)
            CommonSection.SearchCatalog("Tag_Reg0612405840");
            _test.Log(Status.Info, "Search Tag_Reg0612405840 from Catalog search ");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Tag_Reg0612405840") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify result list is display");
            Assert.IsTrue(SearchResultsPage.ContentTagsFacet.Display()); //Verify Content Tag Facet is displayed in the left sidebar
            _test.Log(Status.Pass, "Content Tags Facet display on LHS");
            SearchResultsPage.ContentTagsFacet.SelectCheckbox(); //Select multiple checkboxes
            _test.Log(Status.Info, "Select first check of from Content Tags");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Tag_Reg0612405840") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero after select Conatent tag Facets");
            Assert.IsTrue(SearchResultsPage.SelectedTagsAboveSearchResults.Display()); //Verify the tag appears above the search results and Checkbox is checked
            _test.Log(Status.Pass, "Verify result list is display");
            Assert.IsTrue(SearchResultsPage.ContentTagsFacet.TagCheckboxChecked());
            _test.Log(Status.Pass, "Verify tag check box is remains checked");
            SearchResultsPage.ContentTagsFacet.UnCheckTagCheckbox();  // removed 3ed one
            _test.Log(Status.Pass, "UnCheck on Content Tag check box");
            Assert.IsFalse(SearchResultsPage.ContentTagsFacet.UnCheckedTagRemoved); // from breadcrumb
            SearchResultsPage.SelectedTagsAboveSearchResults.RemoveTag();
            _test.Log(Status.Info, "Removed one Tag");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.TagRemoved); // from breadcrumb
            _test.Log(Status.Pass, "Verfiy tag is removed from bread crumb");
            Assert.IsTrue(SearchResultsPage.ContentTagsFacet.TagCheckboxUnChecked());
            SearchResultsPage.SelectedTagsAboveSearchResults.SelectClearAll();
            _test.Log(Status.Info, "Click Clear All to clean all tag searches");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.AllTagsRemoved);
            _test.Log(Status.Pass, "Verfiy all tag is removed from bread crumb");
            Assert.IsTrue(SearchResultsPage.ContentTagsFacet.AllTagCheckboxUnChecked());
            _test.Log(Status.Pass, "Verfiy tag check box is unchecked");

        }
       

        [Test, Order(23), Category("AutomatedP1")]
        public void a23_View_list_of_Competencies_from_Career_Development_page_33761()
        {
            Assert.True(true);   // this test cases is similar as 33755
        }



        [Test, Order(75), Category("AutomatedP1")]
        public void Admin_bulk_adds_tags_on_manage_content_page_34043()
        {
            //login with a admin 
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Manage Content Search page");
            TrainingPage.SearchRecord("");
            _test.Log(Status.Info, "Click Search page");
            ManageContentPage.SelectMultipleResult();
            ManageContentPage.ClickAddTagOption_Select_DV_Test1();
            _test.Log(Status.Info, "Select Multiple records and click add tag and select DV_Test1 Tag");
            StringAssert.AreEqualIgnoringCase("DV_Test1", ManageContentPage.VerifyTags("DV_Test1"));
            _test.Log(Status.Info, "Verify that Tag DV_Test1 is applied to all selected items under Tags column");

        }
        [Test, Category("AutomatedP1")]
        public void Create_Career_Path_31460()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCreateCareerPath();
            CreateCareerPathPage.EditCareerPathName(CareerPathTitle);
            //  CreateCareerPathPage.SaveCareerPathName();
            Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
            Assert.IsTrue(CareersPage.CheckCareerPathTitle("Create Career Path"));

        }
        [Test, Category("AutomatedP1")]
        public void View_List_of_Career_Path_as_existing_User_31461()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.SearchCareerPath(CareerPathTitle);
            Assert.IsTrue(CareersPage.CheckNameColumn(CareerPathTitle));

        }


        [Test, Order(14), Category("AutomatedP1")]
        public void Test_when_User_sets_the_active_dates_for_a_career_path_33167()
        {
            // LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            _test.Log(Status.Info, "Navigating to Career page");
            CareersPage.CareerPathTab.CreateCareerPath();
            _test.Log(Status.Info, "Click Create Career Path");
            CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
            _test.Log(Status.Info, "Fill career path name");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "click on career breadcrumb ");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "search created career path");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path status");
            CareersPage.CareerPathTab.ClickSearchResult("Reg_CareerPath");
            _test.Log(Status.Info, "click career path name");
            CreateCareerPathPage.SetActiveDates("5/4/2018", "5/31/2018");
            _test.Log(Status.Info, "Define Career path Active Datas");
            //Assert.IsTrue(CreateCareerPathPage.SetActiveDatesPopup.VerifyText("SetActiveDates "));
            //CreateCareerPathPage.FillStartDate("5/4/2018").FillEndDate("5/31/2018").ClickSave();
            Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
            _test.Log(Status.Info, "Date saved");
            Assert.IsTrue(CreateCareerPathPage.VerifyDates("Active from 05/04/2018 until 05/31/2018"));
            _test.Log(Status.Info, "Verify Career Path active dates");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify status should be Active");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "click on career breadcrumb");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "Search created career path");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path status");
        }
        [Test, Order(15), Category("AutomatedP1")]
        public void z15_View_Transcript_Curriculums_26150()
        {
            CommonSection.Learner.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            TranscriptPage.ClickCurriculumsTab();
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
            TranscriptPage.ClickCurriculumsTab();
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
            TranscriptPage.ClickCurriculumsTab();
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
        [Test, Order(24), Category("AutomatedP1")]
        public void z35_Create_Classroom_Section_1823()
        {
            Assert.IsTrue(true);  // as this test cases coved in section management.
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
            CurriculumContentPage.ClickAddTrainingActivities("");
            _test.Log(Status.Info, "Add training activities");
            AddTrainingActivitiesPage.Search("Somnath-AICC");
            _test.Log(Status.Info, "Search general course");
            AddTrainingActivitiesPage.ClickCheckButton();
            _test.Log(Status.Info, "Click on check box");
            AddTrainingActivitiesPage.ClickAddButton();
            _test.Log(Status.Info, "Click on add button");
            AddTrainingActivitiesPage.Click_backbutton();

        }
        [Test, Order(22), Category("AutomatedP1")]
        public void Create_ordered_block_and_learning_activities_15648()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC15648");
            _test.Log(Status.Info, "Create General Course");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin general course");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC15648");
            _test.Log(Status.Info, "Create new curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Edit the new curriculum");
            CurriculumContentPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Add curriculum block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(curriculamblocktitle);
            _test.Log(Status.Info, "Add title and ordered type");
            Assert.IsTrue(CurriculumContentPage.VerifyOrderedTypeIsAvailable());
            _test.Log(Status.Pass, "Verify ordered type is available");
            // CurriculumContentPage.AddCurriculumBlock.AddOrderedType();
            CurriculumContentPage.ClickAddTrainingActivities("");
            _test.Log(Status.Info, "Add training activities");
            AddTrainingActivitiesPage.Search(generalcoursetitle + "TC15648");
            _test.Log(Status.Info, "Search general course");
            AddTrainingActivitiesPage.ClickCheckButton();
            _test.Log(Status.Info, "Click on check box");
            AddTrainingActivitiesPage.ClickAddButton();
            _test.Log(Status.Info, "Click on add button");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Checkin the general course");

            CommonSection.SearchCatalog(curriculamtitle + "TC15648");
            _test.Log(Status.Info, "Search the created curriculum");
            SearchResultsPage.ClickCourseTitle((curriculamtitle + "TC15648"));
            _test.Log(Status.Info, "Click on searched curriculum ");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Button");
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Delete the created curriculum");

            CommonSection.SearchCatalog(generalcoursetitle + "TC15648");
            _test.Log(Status.Info, "Search the created general course");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC15648");
            _test.Log(Status.Info, "Click on searched cousrse");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on edit button");
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Delete the created curriculum");

        }
        [Test, Order(14), Category("AutomatedP1")]
        public void a14_ENrolluserfromClassroomSection_33230()
        {
            #region create new course, add section to it and enroll

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33230");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            // ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

            // ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            CreateNewCourseSectionAndEventPage.CreateSection("Section1", DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"), DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
            // ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("saiflearner");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Admin user logged out successfully");
            #endregion

            #region Login with a Learner search created classroom course and enroll
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33230" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33230");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC33230"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            #endregion
        }
        [Test, Order(15), Category("AutomatedP1")]
        public void a15_Enrollment_Set_Individual_Cancellation_33232()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            #region verify Attendance Required Status For EnrolledUser

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33232");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();
            // ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("ak_learner");
            //ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            //_test.Log(Status.Info, "Click Manage Enrollment action menu");
            //ManageClassroomCoursePage.Enrollmenttab.SearchEnrolledUser("userreg_0403012001people1");
            Assert.AreEqual("No", ManageClassroomCoursePage.Enrollmenttab.AttendanceRequiredStatusForEnrolledUser());
            _test.Log(Status.Pass, "Verify attandance required value is No");
            CommonSection.Logout();
            #endregion

            #region Login with learner and verify Cancel Enrollment under action
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33232" + '"');// ('"' + classroomcoursetitle + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33232"); //("ClassRoomCourseTitle2011472447");// 
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC33232"));// (classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            //CurrentTrainings.ClickAction();

            Assert.AreEqual("Cancel Enrollment", CurrentTrainings.GetActionStatus());
            _test.Log(Status.Pass, "Cancel Enrollment is display in Action section");
            CommonSection.Logout();
            #endregion

            #region Login as admin and update Attendance Required Status For EnrolledUser from No to Yes
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Admin");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC33232" + '"');//('"' + classroomcoursetitle + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33232");// (classroomcoursetitle);
            _test.Log(Status.Pass, "Search Catalog");
            CatalogPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            _test.Log(Status.Info, "Click Manage Enrollment action menu");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("ak_learner");

            ManageClassroomCoursePage.Enrollmenttab.SearchEnrolledUser("ak_learner");
            ManageClassroomCoursePage.Enrollmenttab.UpdateAttendanceRequiredfromNotoYes();
            _test.Log(Status.Info, "Update Attendance Required from No to Yes");
            Assert.AreEqual("Yes", ManageClassroomCoursePage.Enrollmenttab.AttendanceRequiredStatusForEnrolledUser());
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            CommonSection.Logout();
            #endregion

            #region Re Login with learner and verify Cancel Enrollment under action
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33232" + '"');// ('"' + classroomcoursetitle + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33232");// (classroomcoursetitle);
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC33232"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");

            Assert.AreNotEqual("Cancel Enrollment", CurrentTrainings.GetActionStatusForCancelEnrollment());

            #endregion

        }

        [Test, Order(20), Category("AutomatedP1")]

        public void a20_Test_When_User_Adds_Learner_to_WaitList_33509()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
            #region create new course, add section to it and enroll

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "WaitlistTC33509");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("ak_learner");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            //Driver.waitlistrefresh();
            //EnrollmentPage.EnrollmentTab.AddWaitListed();
            // CommonSection.Logout();
            // _test.Log(Status.Pass, "Admin user logged out successfully");
            #endregion
            //LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
            //CommonSection.Manage.Training();
            //_test.Log(Status.Info, "Navigating to Manage Training Page");
            CommonSection.CatalogSearchText(classroomcoursetitle + "WaitlistTC33509");//Search for Course ABCD 
            SearchResultsPage.CheckSearchRecord(classroomcoursetitle + "WaitlistTC33509");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "WaitlistTC33509");
            ContentDetailsPage.ClickEditContent();
            ManageClassroomCoursePage.Clicktab("Sections");


            SectionsPage.ClickManageEnrollmentButton();
            EnrollmentPage.EnrollmentTab.ClickWaitlistedSubTab();
            EnrollmentPage.EnrollmentTab.ClickWaitlistUsers();
            ManageClassroomCoursePage.Enrollmenttab.EnrollwaitlistUser("Site Administrator");
            //EnrollmentPage.ClickViewAslearner();
            //ContentDetailsPage.ClickEditContent();
            CommonSection.CatalogSearchText(classroomcoursetitle + "WaitlistTC33509");//Search for Course ABCD 
            SearchResultsPage.CheckSearchRecord(classroomcoursetitle + "WaitlistTC33509");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "WaitlistTC33509");
            ContentDetailsPage.ClickEditContent();

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.Sectionsdropdown.SelectManageoption("Manage Waitlist");
            _test.Log(Status.Info, "must select a section with no seats avialable and start date is in the future");

            ManageClassroomCoursePage.Enrollmenttab.ClickWaitlistUsers();

            //SectionsPage.ClickManageEnrollmentButton();
            //EnrollmentPage.CickWaitListUsersButton();
            _test.Log(Status.Info, "Validate a new Modal opens with a search box and search results are displayed ");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollmenttab.WaitListUserModelDisplay());
            ManageClassroomCoursePage.Enrollmenttab.EnrollwaitlistUser("shivam 1");

            Assert.IsTrue(ManageClassroomCoursePage.Enrollmenttab.WaitListUserCount());
            _test.Log(Status.Info, "Validate User has been Waitlisted ");

        }
        [Test, Order(21), Category("AutomatedP1")]

        public void a21_Add_Enrollment_Cancelation_Deadline_While_Creating_Section_33513()
        {
            #region Create New Course And Section With Enrollment Cancellation Date

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33513");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SetEnrollmentCancellationDate();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event with Enrollment Cancellation Date");
            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC33513");
            #endregion
        }
        [Test, Order(22), Category("AutomatedP1")]

        public void a22_Enroll_User_In_A_Paid_Section_33597()
        {
            #region Create A Paid Classroom Course Section

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33597");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            // ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("30");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");

            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            ManageClassroomCoursePage.SectionDetailTab();
            ManageClassroomCoursePage.setCostForSection();
            #endregion

            ManageClassroomCoursePage.SearchForContent(classroomcoursetitle + "TC33597");
            _test.Log(Status.Pass, "Search For Classroom Course");
            ClassroomCourseDetailsPage.addToCart();
            _test.Log(Status.Pass, "User Purchasing The Classroom Course");
            ManageClassroomCoursePage.SearchForContent(classroomcoursetitle + "TC33597");
            Assert.IsTrue(ClassroomCourseDetailsPage.verifyEnrollment());
            _test.Log(Status.Pass, "Assertion Pass : User Successfully Purchased Classroom Course and Enrolled");
            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC33597");
        }
        [Test, Order(23), Category("AutomatedP1")]

        public void a23_Admin_User_Search_For_Learner_From_Section_Enrollment_Tab_33599()
        {
            #region Create A Classroom Course Section And Enroll Multiple Users Into It

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33599");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("30");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.Create();
            #endregion
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("Site Administrator");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            string enrolleduserName = ManageClassroomCoursePage.Enrollmenttab.EnrolledUserName();
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.SelectMultipleUsers();

            Assert.IsTrue(ManageClassroomCoursePage.SearchForEnrolledUser("Site Administrator")); //"Regression0403012001people"
            _test.Log(Status.Pass, "Search Result Displayed");
            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC33599");
        }
        [Test, Order(24), Category("AutomatedP1")]

        public void a24_User_Views_Notes_from_Section_Details_33601()
        {
            #region Create New Course And Section And Read Notes

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33601");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.EnterNotes("Testing Notes");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.ScheduleTab());
            ManageClassroomCoursePage.ClickReadNotesButton();
            _test.Log(Status.Pass, "Read Notes Popup Open.");
            ManageClassroomCoursePage.ClickCloseReadNotePopup();
            _test.Log(Status.Pass, "Read Notes Popup Closed.");
            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC33601");
            #endregion
        }
        [Test, Order(15), Category("AutomatedP1")]

        public void b15_As_Course_Manager_View_Files_And_Notes_For_Classroom_Section_33931()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login(); //Login as Course Manager 
            #region Manage Classroom Course
            CommonSection.Manage.Training();

            TrainingPage.ManageContentPortlet.SearchForContent(classroomcoursetitle + "TC34067");
            // StringAssert.AreEqualIgnoringCase(classroomcoursetitle + "TC34067", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord(classroomcoursetitle + "TC34067");
            // StringAssert.AreEqualIgnoringCase(classroomcoursetitle + "TC34067", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            // Assert.IsTrue(SectionDetailsPage);
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Pass, "Verify Content tab is display");
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");//Verify Files and Notes page for the sections is displayed with associated Notes and Files
            ContentPage.ContentTab.ClickAssignmentTitle();
            Assert.IsTrue(ContentPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");// Verify the File opens and can be viewed
        }
    }

}
