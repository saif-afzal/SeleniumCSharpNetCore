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
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1DesignAndMiscTest : TestBase
    {
        string browserstr = string.Empty;
        public P1DesignAndMiscTest(string browser)
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
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }


     
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
      
        [Test, Order(1)]
        public void a01_Test_to_see_the_modern_default_icons_for_learning_items_34800()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();  //login as a usermanager

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34800", generalcoursetitle + "TC34800");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC34800" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            Assert.IsTrue(SearchResultsPage.SearchedRecord.isDefaulticondisplay("General"));
            _test.Log(Status.Pass, "Verify General Course Default icon display");

        }

        [Test, Order(2)]
        public void a02_Admin_views_the_assignments_to_which_a_content_item_has_been_added_35316()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignments link from Training Assignmnets portlet");
            TrainingAssignmentsPage.SearchDropdown.Select("Content");
            _test.Log(Status.Info, "Select Content from Search DropDown");
            Assert.IsTrue(TrainingAssignmentsPage.Contents.isAssignmentsLinkPresent());
            _test.Log(Status.Pass, "Verify Assignments link present for Content");
            Assert.IsTrue(TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.VerifyAssignmentsList());
            _test.Log(Status.Pass, "Verify Assignments Count and other conpentes on Assignments Modal");
            string AssignmentTitleText = TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.AssigmentTitleText("first row");
            TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.Click_AssigmentTitle();
            _test.Log(Status.Info, "Click on Assignment Title");
            Assert.IsTrue(CreateTrainingAssignmentPage.isTrainingAssigmentPageOpened(AssignmentTitleText));
            _test.Log(Status.Pass, "Verify Assignments Details Page Opened");

        }
        [Test, Order(3)]
        public void a03_UserManger_OrgManager_views_the_assignments_to_which_a_content_item_has_been_added_35317()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("UserManager").WithPassword("").Login();  //login as a usermanager
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignments link from Training Assignmnets portlet");
            TrainingAssignmentsPage.SearchDropdown.Select("Content");
            _test.Log(Status.Info, "Select Content from Search DropDown");
            Assert.IsTrue(TrainingAssignmentsPage.Contents.isAssignmentsLinkPresent());
            _test.Log(Status.Pass, "Verify Assignments link present for Content");
            Assert.IsTrue(TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.VerifyAssignmentsList());
            _test.Log(Status.Pass, "Verify Assignments Count and other conpentes on Assignments Modal");
            
           // string AssignmentTitleText = TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.AssigmentTitleText("first row");
            //TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.Click_AssigmentTitle();
            //_test.Log(Status.Info, "Click on Assignment Title");
            //Assert.IsTrue(CreateTrainingAssignmentPage.isTrainingAssigmentPageOpened(AssignmentTitleText));
            //_test.Log(Status.Pass, "Verify Assignments Details Page Opened");

            CommonSection.Logout();
            LoginPage.LoginAs("orgmanager").WithPassword("").Login();  //login as a orgmanager
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignments link from Training Assignmnets portlet");
            TrainingAssignmentsPage.SearchDropdown.Select("Content");
            _test.Log(Status.Info, "Select Content from Search DropDown");
            Assert.IsTrue(TrainingAssignmentsPage.Contents.isAssignmentsLinkPresent());
            _test.Log(Status.Pass, "Verify Assignments link present for Content");
            Assert.IsTrue(TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.VerifyAssignmentsList());
            _test.Log(Status.Pass, "Verify Assignments Count and other conpentes on Assignments Modal");
            //string AssignmentTitleText1 = TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.AssigmentTitleText("first row");
            //TrainingAssignmentsPage.AssignmentsLinks.AssigmnentsModal.Click_AssigmentTitle();
            //_test.Log(Status.Info, "Click on Assignment Title");
            //Assert.IsTrue(CreateTrainingAssignmentPage.isTrainingAssigmentPageOpened(AssignmentTitleText1));
            //_test.Log(Status.Pass, "Verify Assignments Details Page Opened");
        }
        [Test, Order(4)]
        public void a04_Admin_views_the_users_entities_who_have_been_assigned_a_content_item_35327()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignments link from Training Assignmnets portlet");
            TrainingAssignmentsPage.SearchDropdown.Select("Content");
            _test.Log(Status.Info, "Select Content from Search DropDown");
            Assert.IsTrue(TrainingAssignmentsPage.Contents.isAssigneesLinkPresent());
            _test.Log(Status.Pass, "Verify Assignments link present for Content");
            TrainingAssignmentsPage.Contents.Click_AssigneesLink();
            _test.Log(Status.Info, "Click Assignees link");
            Assert.IsTrue(TrainingAssignmentsPage.AssigneesLinks.AssigneesModal.VerifyAssigneesList());
            _test.Log(Status.Pass, "Verify Assignments Count and other conpentes on Assignments Modal");
            string AssignmentTitleText = TrainingAssignmentsPage.AssigneesLinks.AssigneesModal.AssigmentTitleText("first row");
            TrainingAssignmentsPage.AssigneesLinks.AssigneesModal.Click_Assignmentlink();
            _test.Log(Status.Info, "Click on Assignment Title");
            Assert.IsTrue(CreateTrainingAssignmentPage.isTrainingAssigmentPageOpened(AssignmentTitleText));
            _test.Log(Status.Pass, "Verify Assignments Details Page Opened");
        }
        [Test, Order(5)]
        public void a05_UserManger_OrgManager_views_the_users_entities_who_have_been_assigned_a_content_item_35328()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("UserManager").WithPassword("").Login();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignments link from Training Assignmnets portlet");
            TrainingAssignmentsPage.SearchDropdown.Select("Content");
            _test.Log(Status.Info, "Select Content from Search DropDown");
            Assert.IsTrue(TrainingAssignmentsPage.Contents.isAssigneesLinkPresent());
            _test.Log(Status.Pass, "Verify Assignees link present for Content");
            TrainingAssignmentsPage.Contents.Click_AssigneesLink();
            _test.Log(Status.Info, "Click Assignees link");
            Assert.IsTrue(TrainingAssignmentsPage.AssigneesLinks.AssigneesModal.VerifyAssigneesList());
            _test.Log(Status.Pass, "Verify Assignments Count and other conpentes on Assignments Modal");

            CommonSection.Logout();
            LoginPage.LoginAs("orgmanager").WithPassword("").Login();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignments link from Training Assignmnets portlet");
            TrainingAssignmentsPage.SearchDropdown.Select("Content");
            _test.Log(Status.Info, "Select Content from Search DropDown");
            //    Assert.IsTrue(TrainingAssignmentsPage.Contents.isAssigneesLinkPresent());
            _test.Log(Status.Pass, "Verify Assignees link present for Content");
            TrainingAssignmentsPage.Contents.Click_AssigneesLink();
            _test.Log(Status.Info, "Click Assignees link");
            Assert.IsTrue(TrainingAssignmentsPage.AssigneesLinks.AssigneesModal.VerifyAssigneesList());
            _test.Log(Status.Pass, "Verify Assignments Count and other conpentes on Assignments Modal");
            //string AssignmentTitleText = TrainingAssignmentsPage.AssigneesLinks.AssigneesModal.AssigmentTitleText("first row");
            //TrainingAssignmentsPage.AssigneesLinks.AssigneesModal.Click_Assignmentlink();
            //_test.Log(Status.Info, "Click on Assignment Title");
            //Assert.IsTrue(CreateTrainingAssignmentPage.isTrainingAssigmentPageOpened(AssignmentTitleText));
            //_test.Log(Status.Pass, "Verify Assignments Details Page Opened");
        }
        [Test, Order(6)]
        public void a06_Create_Category_21003()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.TrainingManagement.ContentCategories();
            _test.Log(Status.Info, "Naviagate to Administer >> Training management >> Content Categories");
            ContentCategoriesPage.SearchTab.Click_CreateButton();
            _test.Log(Status.Info, "Click Create button");
            CategoryPage.CreateNewcategory(CategoryTitle);
            _test.Log(Status.Info, "Create new Category");
            CategoryPage.Click_CategoryBreadComblink();
            ContentCategoriesPage.Click_CategoryHierarchyTab();
            Assert.IsTrue(ContentCategoriesPage.CategoryHierarchyTab.isNewCategoryDisplay(CategoryTitle));
            _test.Log(Status.Pass, "Verify ne created category display in Category Hierarchy tab");
        }
        [Test, Order(7)]
        public void a07_Delete_Category_21005()
        {
            CommonSection.Administer.TrainingManagement.ContentCategories();
            _test.Log(Status.Info, "Naviagate to Administer >> Training management >> Content Categories");
            ContentCategoriesPage.SearchTab.Click_CreateButton();
            _test.Log(Status.Info, "Click Create button");
            CategoryPage.CreateNewcategory(CategoryTitle + "TC21005");
            _test.Log(Status.Info, "Create new Category");
            CategoryPage.Click_CategoryBreadComblink();
            ContentCategoriesPage.SearchTab.SearchCategory(CategoryTitle + "TC21005");
            _test.Log(Status.Info, "Search Category");
            Assert.IsTrue(ContentCategoriesPage.SearchTab.DeleteCategory(CategoryTitle + "TC21005"));
            _test.Log(Status.Pass, "Verify Category Deleted");
        }
        [Test, Order(8)]
        public void a08_Category_Localization_34885()
        {
            CommonSection.Administer.TrainingManagement.ContentCategories();
            _test.Log(Status.Info, "Naviagate to Administer >> Training management >> Content Categories");
            ContentCategoriesPage.SearchTab.Click_CreateButton();
            _test.Log(Status.Info, "Click Create button");
            CategoryPage.CreateNewcategory(CategoryTitle + "TC34558");
            _test.Log(Status.Info, "Create new Category");
            CategoryPage.Click_CategoryBreadComblink();
            ContentCategoriesPage.SearchTab.SearchCategory(CategoryTitle + "TC34558");
            _test.Log(Status.Info, "Search Category");
            ContentCategoriesPage.SearchTab.Click_SearchedCategoryTitle(CategoryTitle + "TC34558");
            _test.Log(Status.Info, "Click Searched Category title");
            Assert.IsTrue(CategoryDetailsPage.SetLocalized("French (Canada)"));
            _test.Log(Status.Pass, "Set Catagory Localization");
        }
        [Test, Order(9)]
        public void a09_Edit_Category_21004()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.TrainingManagement.ContentCategories();
            _test.Log(Status.Info, "Naviagate to Administer >> Training management >> Content Categories");
            ContentCategoriesPage.SearchTab.Click_CreateButton();
            _test.Log(Status.Info, "Click Create button");
            CategoryPage.CreateNewcategory(CategoryTitle + "TC21004");
            _test.Log(Status.Info, "Create new Category");
            CategoryPage.Click_CategoryBreadComblink();
            ContentCategoriesPage.SearchTab.SearchCategory(CategoryTitle + "TC21004");
            _test.Log(Status.Info, "Search Category");
            ContentCategoriesPage.SearchTab.Click_SearchedCategoryTitle(CategoryTitle + "TC21004");
            _test.Log(Status.Info, "Click Searched Category title");
            String CategotyTitleText = CategoryDetailsPage.GetCategoryTitle();
            CategoryDetailsPage.EditCategory(CategoryTitle + "TC21004_1", "Description");
            _test.Log(Status.Info, "Edit Category title, Description and Keyword");
            Assert.IsTrue(CategoryDetailsPage.isCategoryTitleupdated(CategoryTitle + "TC21004", CategoryTitle + "TC21004_1"));
            _test.Log(Status.Pass, "Verify Category title is updated");

        }
        [Test, Order(10)]
        public void a10_View_Category_Content_21006()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.Administer.TrainingManagement.ContentCategories();
            _test.Log(Status.Info, "Naviagate to Administer >> Training management >> Content Categories");
            ContentCategoriesPage.SearchTab.Click_CreateButton();
            _test.Log(Status.Info, "Click Create button");
            CategoryPage.CreateNewcategory(CategoryTitle + "TC21004");
            _test.Log(Status.Info, "Create new Category");
            CategoryPage.Click_CategoryBreadComblink();
            ContentCategoriesPage.SearchTab.SearchCategory(CategoryTitle + "TC21004");
            _test.Log(Status.Info, "Search Category");
            ContentCategoriesPage.SearchTab.Click_SearchedCategoryTitle(CategoryTitle + "TC21004");
            _test.Log(Status.Info, "Click Searched Category title");

        }
        [Test, Order(11)]
        public void a11_Select_all_content_when_adding_to_Gamification_34880()
        {
            CommonSection.Manage.Gamification();
            _test.Log(Status.Info, "Naviagate to Manage >> Gamification");
            GamificationPage.PointsTab.Click_AddContentbutton();
            _test.Log(Status.Info, "Go to Points tab and click on Add Content Button");
            Assert.IsTrue(GamificationPage.PointsTab.AddContentModal.SelectAllandAddContents());
            _test.Log(Status.Pass, "Verify all Contents are added");

        }
        [Test, Order(12)]
        public void a12_Upload_custom_Image_for_Categories_35320()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.Administer.TrainingManagement.ContentCategories();
            _test.Log(Status.Info, "Naviagate to Administer >> Training management >> Content Categories");
            ContentCategoriesPage.SearchTab.Click_CreateButton();
            _test.Log(Status.Info, "Click Create button");
            CategoryPage.CreateNewcategory(CategoryTitle + "TC35320");
            _test.Log(Status.Info, "Create new Category");
            CategoryPage.Click_CategoryBreadComblink();
            ContentCategoriesPage.SearchTab.SearchCategory(CategoryTitle + "TC35320");
            _test.Log(Status.Info, "Search Category");
            ContentCategoriesPage.SearchTab.Click_SearchedCategoryTitle(CategoryTitle + "TC35320");
            _test.Log(Status.Info, "Click Searched Category title");
            _test.Log(Status.Pass, "Verify ne created category display in Category Hierarchy tab");
            CategoryDetailsPage.UploadImage("C://Automation//Somnath//19_1//Data//image.jpg");
            _test.Log(Status.Info, "Upload Image");
            //Assert.IsTrue(Driver.comparePartialString("The changes were saved.", Driver.getSuccessMessage()));
        }
         [Test, Order(13)]
        public void a13_Search_For_Training_Assignment_By_Content_Item_34849()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click Manage Training Assignments link from Training Assignmnets portlet");
            Assert.IsTrue(TrainingAssignmentsPage.VerifyisListofAssignmentsdisplay()); //Verify List of Assignments are displayed
            TrainingAssignmentsPage.SearchDropdown.Select("Content");
            _test.Log(Status.Info, "Select Content from Search DropDown");
            Assert.IsTrue(TrainingAssignmentsPage.isListofContentdisplay()); // Verify list of Content are displayed
            int totalresult = TrainingAssignmentsPage.Totalnumberofresultdisplay();
            //Assert.IsTrue(ManageTrainingAssignmentsPage.ListOfContent.VerifyAlphabeticalOrderByName); // Verify list of Content are displayed in Alphabetical Order by Name

            Assert.IsTrue(TrainingAssignmentsPage.StatusFilter.VerifyIsActiveSelecte);//Verify the Status filter defaults to Active
            Assert.IsTrue(TrainingAssignmentsPage.ListofContent.VerifyColumns("Name", "Type", "Status", "Assignments", "Assignees", "Info"));
            Assert.IsFalse(TrainingAssignmentsPage.ListofContent.VerifyAssignmentColumnisNotSortable()); // Verify the Assignments Column is not sortable
            Assert.IsFalse(TrainingAssignmentsPage.ListofContent.VerifyAssigneesColumnisNotSortable); // Verify the Assignees Column is not sortable
            //TrainingAssignmentsPage.ListofContent.NameColumn.ClickSortIcon();
            //Assert.IsTrue(TrainingAssignmentsPage.ListofContent.NameColumn.VerifySorted);
            //TrainingAssignmentsPage.ListofContent.TypeColumn.ClickSortIcon();
            //Assert.IsTrue(TrainingAssignmentsPage.ListofContent.TypeColumn.VerifySorted);
            //TrainingAssignmentsPage.ListofContent.StatusColumn.ClickSortIcon();
            //Assert.IsTrue(TrainingAssignmentsPage.ListofContent.StatusColumn.VerifySorted);
            TrainingAssignmentsPage.SearchbyContent("General");
            Assert.IsTrue(TrainingAssignmentsPage.ListofContent.VerifyResultisdisplay());
            TrainingAssignmentsPage.SearchbyContent("Reg-Description");
            Assert.IsTrue(TrainingAssignmentsPage.ListofContent.VerifyResultisdisplay());
            TrainingAssignmentsPage.SearchbyContent("keywords");
            Assert.IsTrue(TrainingAssignmentsPage.ListofContent.VerifyResultisdisplay());
            TrainingAssignmentsPage.SearchbyContent("tag");
            Assert.IsTrue(TrainingAssignmentsPage.ListofContent.VerifyResultisdisplay());
            
            //TrainingAssignmentsPage.StatusFilter.SelectInActive();
            //Assert.IsTrue(TrainingAssignmentsPage.ListofContent.VerifyResultsByStatusInActive() >= totalresult);
           
        }
        [Test, Order(14)]
        public void a14_Manage_survey_permissions_for_Admin_and_Content_Manager_35395()
         {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Goto Manage >> Surveys Page");
            Assert.IsTrue(SurveycosolePage.SurveysTabisLearningEvaluationssarePresent());
            SurveycosolePage.SurveysTab.ClickCreateNewSurvey();
            Assert.IsTrue(CreateSurveypage.Title("Survey"));

            CommonSection.Logout();
            LoginPage.LoginAs("srsurveymanager").WithPassword("").Login();
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Goto Manage >> Surveys Page");
            //Assert.IsTrue(SurveycosolePage.SurveysTabisLearningEvaluationssarePresent());
            SurveycosolePage.SurveysTab.ClickCreateNewSurvey();
            Assert.IsTrue(CreateSurveypage.Title("Survey"));

            CommonSection.Logout();
            LoginPage.LoginAs("report_mngr").WithPassword("").Login();
            Assert.IsFalse(CommonSection.Manage.IsSurveysDisplay());

        }
        [Test, Order(15)]
        public void Z4_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_with_Every_two_weeks_Recurrence_35840()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();  

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35840");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartDate(0);
            //_test.Log(Status.Info, "Set Section start date");
            // ManageClassroomCoursePage.CreateSection.SectionEndDate(0);
            //_test.Log(Status.Info, "Set Section End date");
            ManageClassroomCoursePage.setRecurence("Every two weeks");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            //ManageClassroomCoursePage.CreateSection.SetEnrollmentEndDate(63);
            //_test.Log(Status.Info, "Set Enrollment End Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35840", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35840"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35840");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();//Event date block is not removed
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");

        }
        [Test, Order(16)]
        public void Z5_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_No_Recurrence_35841()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();  

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35841");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35841", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35841"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35841");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();//Event date block is not removed
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");


        }
        [Test, Order(17)]
        public void Z6_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_With_Every_Weekday_Recurrence_35842()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();  

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35842");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(1);
            _test.Log(Status.Info, "Set Section start date");
              ManageClassroomCoursePage.setRecurence("Every Weekday");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35842", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35842"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35842");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();//Event date block is not removed
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");
        }

        [Test, Order(18)]
        public void Z7_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_With_Daily_Recurrence_35843()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login(); 

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35843");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Daily");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35843", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35843"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35843");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");
        }

        [Test, Order(19)]
        public void Z8_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_With_Weekly_Recurrence_35844()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login(); 

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35844");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Weekly");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35844", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35844"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35844");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();//Event date block is not removed
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");
        }

        [Test, Order(20)]
        public void Z9_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_With_Monthly_Day_Recurrence_35845()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();  

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35845");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Monthly");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35845", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35845"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35845");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();//Event date block is not removed
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");
        }
        [Test, Order(21)]
        public void Z10_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_With_Monthly_Specific_Day_Recurrence_35846()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();  

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35846");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("MonthlySDR");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35846", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35846"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35846");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");
        }

        [Test, Order(22)]
        public void Z11_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Manage_Students_where_section_with_One_Event_With_Annual_Recurrence_35847()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();  //login as a usermanager

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35847");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Annually");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isInstructorToolDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            TrainingPage.InstructorTools.ViewAllSections();
            _test.Log(Status.Info, "Click on View All Sections");
            InstructorToolsPage.ManageStudentsTab.SearchSection(classroomcoursetitle + "TC35847", "All");
            _test.Log(Status.Info, "Search Section from Manage students Tab");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.isCourseDisplayed(classroomcoursetitle + "TC35847"));
            _test.Log(Status.Pass, "Verify searched Course is Displayed");
            InstructorToolsPage.ManageStudentsTab.ExpandCourse(classroomcoursetitle + "TC35847");
            _test.Log(Status.Info, "Expand the Course");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyCourseInformation());
            _test.Log(Status.Pass, "verify Course information");
            InstructorToolsPage.ManageStudentsTab.ExpandEvent();
            _test.Log(Status.Info, "Click on Event");
            Assert.IsTrue(InstructorToolsPage.ManageStudentsTab.VerifyAdditionalInformation());
            _test.Log(Status.Info, "Verify Additional Information Block is Displayed");
        }

        [Test, Order(23)]
        public void Z12_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Teaching_Schedule_portlet_where_section_with_One_Event_with_Every_Weekday_Recurrence_35848()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();  

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35848");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Every Weekday");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isTeachingScheduleDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            //TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            //_test.Log(Status.Pass, "Click on view Teaching Schedule");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyAllDayDisplayed(classroomcoursetitle + "TC35848"));
            _test.Log(Status.Pass, "Verify All Day status is Displayed");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyCourseDateAndRecurrenceStatus());//verify as per ID
            _test.Log(Status.Pass, "Verify Course date and recurrence status is Displayed");

        }

        [Test, Order(24)]
        public void Z13_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Teaching_Schedule_portlet_where_section_with_One_Event_with_Daily_Recurrence_35849()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35849");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Daily");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isTeachingScheduleDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            //TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            //_test.Log(Status.Pass, "Click on view Teaching Schedule");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyAllDayDisplayed(classroomcoursetitle + "TC35849"));
            _test.Log(Status.Pass, "Verify All Day status is Displayed");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyCourseDateAndRecurrenceStatus());
            _test.Log(Status.Pass, "Verify Course date and recurrence status is Displayed");
        }
        [Test, Order(25)]
        public void Z14_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Teaching_Schedule_portlet_where_section_with_One_Event_with_Weekly_Recurrence_35850()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login(); 

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC358550");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Weekly");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isTeachingScheduleDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            //TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            //_test.Log(Status.Pass, "Click on view Teaching Schedule");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyAllDayDisplayed(classroomcoursetitle + "TC35850"));
            _test.Log(Status.Pass, "Verify All Day status is Displayed");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyCourseDateAndRecurrenceStatus());
            _test.Log(Status.Pass, "Verify Course date and recurrence status is Displayed");
        }

        [Test, Order(26)]
        public void Z15_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Teaching_Schedule_portlet_where_section_with_One_Event_with_Every_two_Weeks_Recurrence_35851()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC358551");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Every two weeks");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isTeachingScheduleDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            //TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            //_test.Log(Status.Pass, "Click on view Teaching Schedule");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyAllDayDisplayed(classroomcoursetitle + "TC35851"));
            _test.Log(Status.Pass, "Verify All Day status is Displayed");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyCourseDateAndRecurrenceStatus());
            _test.Log(Status.Pass, "Verify Course date and recurrence status is Displayed");
        }
        [Test, Order(27)]
        public void Z16_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Teaching_Schedule_portlet_where_section_with_One_Event_with_Monthly_Day_Recurrence_35852()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login(); 

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC358552");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Monthly");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isTeachingScheduleDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            //TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            //_test.Log(Status.Pass, "Click on view Teaching Schedule");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyAllDayDisplayed(classroomcoursetitle + "TC35852"));
            _test.Log(Status.Pass, "Verify All Day status is Displayed");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyCourseDateAndRecurrenceStatus());
            _test.Log(Status.Pass, "Verify Course date and recurrence status is Displayed");
        }
        [Test, Order(28)]
        public void Z17_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Teaching_Schedule_portlet_where_section_with_One_Event_with_Monthly_Specific_Day_Recurrence_35854()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login(); 

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC358554");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("MonthlySDR");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isTeachingScheduleDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            //TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            //_test.Log(Status.Pass, "Click on view Teaching Schedule");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyAllDayDisplayed(classroomcoursetitle + "TC35854"));
            _test.Log(Status.Pass, "Verify All Day status is Displayed");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyCourseDateAndRecurrenceStatus());
            _test.Log(Status.Pass, "Verify Course date and recurrence status is Displayed");
        }


        [Test, Order(29)]
        public void Z18_User_views_event_date_time_recurrence_format_from_Instructor_Tools_Teaching_Schedule_portlet_where_section_with_One_Event_with_Annual_Recurrence_35855()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC358555");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add a New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.setRecurence("Annually");
            _test.Log(Status.Info, "Set Reccurence");
            CreateNewCourseSectionAndEventPage.SelectInstructor("ak instructor");
            _test.Log(Status.Info, "Select Instructor");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set maximum Capacity");
            ManageClassroomCoursePage.CreateSection.UseWaitlistasYes();
            _test.Log(Status.Info, "Select waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set Enrollment start Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout from siteadmin Account");
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training from manage");
            Assert.IsTrue(TrainingPage.isTeachingScheduleDisplayed());
            _test.Log(Status.Pass, "Verify instructor Tool is Displayed");
            //TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            //_test.Log(Status.Pass, "Click on view Teaching Schedule");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyAllDayDisplayed(classroomcoursetitle + "TC35855"));
            _test.Log(Status.Pass, "Verify All Day status is Displayed");
            Assert.IsTrue(TrainingPage.TeachingSchedule.VerifyCourseDateAndRecurrenceStatus());
            _test.Log(Status.Pass, "Verify Course date and recurrence status is Displayed");
        }

       

    }


}


