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
using TestAutomation.Miscellaneous;
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
    public class P1SectionsManagementTests : TestBase
    {
        string browserstr = string.Empty;
        public P1SectionsManagementTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            InitializeBase(driver);
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
        string LevelName = "Level" + Meridian_Common.globalnum;
        string SectionTitle = "Section_" + Meridian_Common.globalnum;
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

   
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
      

        [Test, Order(1), Category("AutomatedP11")]
        public void a01_Create_a_new_Classroom_course_14061()
        {
            string expectedresult = " The item was created.";
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");
            //Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            //_test.Log(Status.Pass, "Verify Tag lavel on Content Creation page");
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            _test.Log(Status.Info, "Filled all required information and submit the classroom creation page");
            Assert.IsTrue(driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick()));
            _test.Log(Status.Pass, "Verify Classroom Course saved");
            // Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
        }

        [Test, Order(2), Category("AutomatedP11")]
        public void a02_Manage_a_Classroom_course_26747()
        {
            string expectedresult = " The changes were saved.";
            string actualresult = string.Empty;
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "editcontent", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            _test.Log(Status.Info, "Filled all required information and submit the classroom creation page");
            classroomcourse.buttonsaveclick();
            _test.Log(Status.Info, "Click Save button");
            //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage>>Training Page");
            TrainingPage.SearchRecord(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "editcontent");
            _test.Log(Status.Info, "Searchched created Classroom course using manage Content portlet");
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "editcontent");
            _test.Log(Status.Info, "Click on Classroom Course title from Manage Content page");
            classroomcourse.buttoncourseeditclick();
            _test.Log(Status.Info, "Click on edit button in summary accordian");
            //SummaryPage.AddnewTag(TAGTitle + "TC26747");
            Assert.IsTrue(SummaryPage.AddnewTag(TAGTitle + "TC26747"));
            _test.Log(Status.Pass, "Verify new tab can added in summary page");

            SummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(SummaryPage.checkContentTagsOnDetailsPage());
            // Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            _test.Log(Status.Pass, "Verify added tag is displayed");


        }
       

        [Test, Order(4), Category("AutomatedP11")]

        public void P20_1_a04_Create_New_Section_with_New_Hybrid_Event_Future_Date_33494()
        {

            #region Create New Course, Add Section with Future Date

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33494");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys("10/15/2019 5:30 PM");
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).SendKeys("10/15/2019 6:30 PM");
            IWebElement webElement = Driver.Instance.GetElement(By.XPath("//button[@id='location_0']"));//You can use xpath, ID or name whatever you like
            webElement.SendKeys(Keys.Tab);
            ManageClassroomCoursePage.CreateSection.Create();
           
            _test.Log(Status.Pass, "Click on Create Button");
            Assert.IsTrue(Driver.existsElement(By.XPath("//a[contains(.,'Section1')]")));
            _test.Log(Status.Pass, "Assertion Pass as Section Has been created and visible with future date");
            #endregion


        }

             [Test, Order(32), Category("AutomatedP11")]
        public void a32_Inactive_Content_from_Training_Assignments_automatically_filtered_from_Add_Content_34061()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click on Training Assignment link");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content in Training Assignment Page");
            Assert.IsTrue(CreateTrainingAssignmentPage.ContentTab.AddContentModal.VerifyInactiveSearch());
            _test.Log(Status.Pass, "Verify Search Inactive check box is working");
        }
        [Test, Order(33), Category("AutomatedP11")]
        public void a33_Inactive_Assignees_from_Training_Assignments_automatically_filtered_from_Add_Assignees_34060()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click on Training Assignment link");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Content in Training Assignment Page");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.Search("learner");
            Assert.IsTrue(CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.VerifyInactiveSearch());
            _test.Log(Status.Pass, "Verify Search Inactive check box is working");
        }
       
        [Test, Order(19), Category("AutomatedP11")]

        public void P20_1_Z19_Admin_User_Delete_Events_From_Section_Detail_Page_34041()
        {
            #region create new course and Access The Section Detail From Gradebook Page
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34041");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs(SectionTitle + "TC34041");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(SectionTitle + "TC34041"));

            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            ManageClassroomCoursePage.ScheduleTab();
            Assert.IsTrue(ManageClassroomCoursePage.Remove_Event(SectionTitle + "TC34041"));
            _test.Log(Status.Pass, "Assertion Pass as Event has been removed");
            #endregion
        }



        //[Test]
        //public void Copy_Section_Including_Section_Content_and_Gradebook_34724()
        //{
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34724");
        //    _test.Log(Status.Info, "New Classroom Course Created");
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate();
        //    ManageClassroomCoursePage.SelectWaitListasYes();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Info, "Click on Create Button on Create Section Page");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    SectionDetailsPage.ClickContentTab();
        //    SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
        //    _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
        //    SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
        //    Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");
        //    Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");
        //    Assert.IsTrue(GradebookPage.GradebookTab.GradeTest());
        //    _test.Log(Status.Pass, "User able to grade test");
        //    SectionsPage.SelectCopySectionformActionDropdown();
        //    Assert.IsTrue(SectionsPage.CopySectionModal.VerifyComponets());
        //    _test.Log(Status.Pass, "Verify Modal Title, Section Start date, Section title and timezone");
        //    SectionsPage.CopySectionModal.CopywithGradebooktoggle("Yes");
        //    _test.Log(Status.Info, "Copy new section with Include section content and gradebook toggle option as Yes");
        //    SectionsPage.ClickonSectionTitle("2nd Section");
        //    Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook are Available for new section");

        //}
        //[Test]  //Depend on 34724
        //public void Copy_Section_without_Section_Content_and_Gradebook_34725()
        //{
        //    CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34724" + '"');
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34724");
        //    ContentDetailsPage.ClickEditContent();
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    SectionsPage.SelectCopySectionformActionDropdown();
        //    SectionsPage.CopySectionModal.CopywithGradebooktoggle("No");
        //    _test.Log(Status.Info, "Copy new section with Include section content and gradebook toggle option as Yes");
        //    SectionsPage.ClickonSectionTitle("3rd Section");
        //    Assert.IsFalse(ManageClassroomCoursePage.Verify_GradebookGrid());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook are not Available for new section");


        //}
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_has_All_Day_Event_without_Recurrence_34745()
        //{
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34745");
        //    _test.Log(Status.Info, "New Classroom Course Created");
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    CreateNewCourseSectionAndEventPage.SchedulePortlet.AllDayevent("Yes");
        //    _test.Log(Status.Info, "Set All day event toggle as Yes");
        //    ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate();
        //    ManageClassroomCoursePage.SelectWaitListasYes();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Info, "Click on Create Button on Create Section Page");
        //    CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34745" + '"');
        //    SearchResultsPage.ListofSearchResults.ExpandSections();
        //    Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("AllDay"));
        //    _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
        //    SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34724");
        //    Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("AllDay"));
        //    _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
        //    ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
        //    Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("AllDay"));
        //    _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");

        //}
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_with_One_Event_No_Recurrence_34746()
        //{
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34746");
        //    _test.Log(Status.Info, "New Classroom Course Created");
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    _test.Log(Status.Info, "Set All day event toggle as Yes");
        //    ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate();
        //    ManageClassroomCoursePage.SelectWaitListasYes();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Info, "Click on Create Button on Create Section Page");
        //    CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34746" + '"');
        //    SearchResultsPage.ListofSearchResults.ExpandSections();
        //    Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("OneEvent"));
        //    _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
        //    SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34724");
        //    Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("OneEvent"));
        //    _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
        //    ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
        //    Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("OneEvent"));
        //    _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
        //}
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_with_One_Event_with_Every_Weekday_Recurrence_34747()
        //{ }
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithDaily_Recurrence_34748()
        //{ }
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_OneEventwithWeekly_Recurrence_34749()
        //{ }
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithEverytwoweeks_Recurrence_34750()
        //{ }
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithMonthly_Day_Recurrence_34751()
        //{ }
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithMonthlySpecificDay_Recurrence_34752()
        //{ }
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_with_Multiple_Events_34754()
        //{ }
        //[Test]
        //public void User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithAnnual_Recurrence_34753()
        //{ }

    }


}


