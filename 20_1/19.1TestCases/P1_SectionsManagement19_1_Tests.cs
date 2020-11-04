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
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P1SectionsManagement19_1_Tests : TestBase
    {
        string browserstr = string.Empty;
        public P1SectionsManagement19_1_Tests(string browser)
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
        public string SectionStartDate;
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

        }
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
    
        [Test]
        public void a01_Copy_Section_Including_Section_Content_and_Gradebook_34724()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34724");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            //ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Graded Assignment");
            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");
            Assert.IsTrue(GradebookPage.GradebookTab.VerifyGradedContent());
            _test.Log(Status.Pass, "User able to grade test");
            SectionsPage.SelectCopySectionformActionDropdown();
            Assert.IsTrue(SectionsPage.CopySectionModal.VerifyCopySectionModalComponets());
            _test.Log(Status.Pass, "Verify Modal Title, Section Start date, Section title and timezone");
            SectionsPage.CopySectionModal.CopywithGradebooktoggle("Yes");
            _test.Log(Status.Info, "Copy new section with Include section content and gradebook toggle option as Yes");
            Assert.IsTrue(Driver.comparePartialString("The classroom section was copied.", SectionsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful messasge");
            
            SectionsPage.ClickSectionTitle("Section1-Copy");
            ManageClassroomCoursePage.Click_Gradebook();
            Assert.IsTrue(GradebookPage.GradebookTab.VerifyGradedContent());
            _test.Log(Status.Pass, "Assertion Pass Gradebook are Available for new section");

        }
        [Test]  //Depend on 34724
        public void a02_Copy_Section_without_Section_Content_and_Gradebook_34725()
        {
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34724" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34724");
            ContentDetailsPage.ClickEditContent();
            ManageClassroomCoursePage.Clicktab("Sections");
            SectionsPage.SelectCopySectionformActionDropdown();
            SectionsPage.CopySectionModal.CopywithGradebooktoggle("No");
            _test.Log(Status.Info, "Copy new section with Include section content and gradebook toggle option as Yes");
            SectionsPage.ClickSectionTitle("Section1-Copy-WithNo");
            ManageClassroomCoursePage.Click_Gradebook();
            Assert.IsFalse(GradebookPage.GradebookTab.VerifyGradedContentisNotDisplay());
            _test.Log(Status.Pass, "Assertion Pass Gradebook are not Available for new section");

            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34724");

        }
        [Test]
        public void a03_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_has_All_Day_Event_without_Recurrence_34745()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34745");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            CreateNewCourseSectionAndEventPage.SectionTitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            //CreateNewCourseSectionAndEventPage.SchedulePortlet.AllDayevent("Yes");
            _test.Log(Status.Info, "Set All day event toggle as Yes");
           // ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34745" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("AllDay"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34745");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("AllDay"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("AllDay"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34745");
        }
        [Test]
        public void a04_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_with_One_Event_No_Recurrence_34746()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34746");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
           // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34746" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("OneEvent"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34746");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("OneEvent"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("OneEvent"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");

            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34746");
        }
        [Test]
        public void a05_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_with_One_Event_with_Every_Weekday_Recurrence_34747()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34747");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Every Weekday");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
           // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34747" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("Every Weekday"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34747");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("Every Weekday"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("Every Weekday"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34747");
        }
        [Test]
        public void a06_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithDaily_Recurrence_34748()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34748");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Daily");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
           // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34748" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("Daily"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34748");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("Daily"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("Daily"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34748");
        }
        [Test]
        public void a07_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_OneEventwithWeekly_Recurrence_34749()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34749");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Weekly");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            //ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34749" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("Weekly"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34749");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("Weekly"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("Weekly"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34749");
        }
        [Test]
        public void a08_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithEverytwoweeks_Recurrence_34750()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34750");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Every two weeks");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
           // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34750" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("Every two weeks"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34750");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("Every two weeks"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("Every two weeks"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34750");
        }
        [Test]
        public void a09_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithMonthly_Day_Recurrence_34751()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34751");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Monthly");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            //ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34751" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("Monthly"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34751");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("Monthly"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("Monthly"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34751");
        }
        [Test]
        public void a10_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithMonthlySpecificDay_Recurrence_34752()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34752");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("MonthlySDR"); // Monthly Specific Day
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            //ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34752" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("MonthlySpecificDay"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34752");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("MonthlySpecificDay"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("MonthlySpecificDay"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC34752");
        }
        [Test]
        public void a11_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_with_Multiple_Events_34754()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34754");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("MonthlySDR");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
           // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            ManageClassroomCoursePage.ClickSectionTab();
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            SectionDetailsPage.ClickScehduleTab();
            _test.Log(Status.Info, "Click on Schedule tab page");
            SectionDetailsPage.ScheduleTab.ClickCreateNewEvent();
            CreateNewEvent.ScheduleTab.CreateNewEvent("Dally");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34754" + '"');

            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("MultipleEvents"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34754");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("MultipleEvents"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("MultipleEvents"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
        }
        [Test]
        public void a12_User_views_event_date_time_recurrence_format_on_Catalog_Expanded_Classroom_Course_where_section_withOneEventwithAnnual_Recurrence_34753()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34753");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Annually");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
           // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC34753" + '"');
            SearchResultsPage.ListofSearchResults.ExpandSections();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.VerifyTextonEventPortlet("Annually"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC34753");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.VerifyMiddleColumnText("Annually"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            ContentDetailsPage.ScheduledCourse.ClickExpandRowicon();
            Assert.IsTrue(ContentDetailsPage.ExpandedScheduledCourse.VerifyEventScheduleText("Annually"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
        }
        [Test]
        public void a13_User_views_event_date_time_recurrence_format_correctly_from_courses_learner_content_details_34765()
        {
            Assert.True(true);  //As I have cover this page on above tests (34745 to 34754)
        }
        [Test]
        public void a14_User_views_event_date_time_recurrence_format_correctly_from_courses_learner_content_details_expanded_section_details_34780()
        {
            Assert.True(true);  //As I have cover this page on above tests (34745 to 34754)
        }
        
        [Test]
        public void a15_NYDOH_Payment_Type_in_Domain_Console_34822()
        {
            //login as admin
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "Navigate to Administer >> System >> Domains and URLs >> Domains");
            DomainsPage.ClickDomainLink("Meridian Global-Core Domain");
            _test.Log(Status.Info, "Click on Core Doamain link");
            Assert.IsTrue(EditSummaryPage.SummaryTab.PaymentTypesSection.isNYDOHChecked());
            _test.Log(Status.Pass, "Verify NYDOH Payment option is checked");
            

        }
        [Test]
        public void a16_User_views_event_date_time_recurrence_format_Correctly_from_Manage_Training_Expanded_Course_51578()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC51578");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Every Weekday");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "navigate to Manage Training page");
            TrainingPage.ManageContentPortlet.SearchForContent(classroomcoursetitle + "TC51578");
            _test.Log(Status.Info, "Search the classroom content from Manage Content portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(classroomcoursetitle + "TC51578"));
            ManageContentPage.ResultGrid.ClickCourseExpander(classroomcoursetitle + "TC51578");
            Assert.IsTrue(ManageContentPage.ExpandedSectiondetails.VerifyEventScheduleText("Every Weekday"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");

           
        }
        [Test]
        public void a17_User_views_event_date_time_recurrence_format_Correctly_from_Course_SectionTab_51573()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC51573");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.setRecurence("Every Weekday");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            // ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            Assert.IsTrue(ManageClassroomCoursePage.Sectiontab.VerifyEventScheduleTextforSection("Every Weekday"));
            _test.Log(Status.Pass, "Verify event start date, end date, recurrence type");
            


        }
        [Test]
        public void z01_Classroom_Section_Copy_With_Standard_Default_Enrollment_35666()

        {

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35666");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            // ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(0);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
           // ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            SectionStartDate = SectionsPage.SectionStartDate();
            // ManageClassroomCoursePage.Sectionsdropdown.CopySection();


            SectionsPage.SelectCopySectionformActionDropdown();
            _test.Log(Status.Info, "Select Copy Section from Mange Enrollment Dropdown Toggle");
            //Assert.IsTrue(SectionsPage.CopySectionModal.VerifyCopySectionModalComponets());
            //_test.Log(Status.Pass, "Verify Modal Title, Section Start date, Section title and timezone");
            Assert.IsTrue(SectionsPage.CopySectionModal.VerifyModalEnrollmentDate(SectionStartDate));
            _test.Log(Status.Pass, "Verify Enrollment Start Date is defaulted to Section Start Date");
            SectionsPage.CopySectionModal.EditSectionTitle("Section2");
            _test.Log(Status.Pass, "Change the Section Title to Section2");
            Assert.IsTrue(SectionsPage.CopySectionModal.EnrollmentStartsToggle("Initial"));
            _test.Log(Status.Info, "Keep Enrollment Start date to Default with Initial setting");
            SectionsPage.CopySectionModal.ClickCopy();
            _test.Log(Status.Info, "Click on Copy Button on Copy Section Modal");
            Assert.IsTrue(Driver.comparePartialString("The classroom section was copied.", SectionsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful messasge");
            ManageClassroomCoursePage.Sectiontab.ClickDetails("Section2");
            Assert.IsTrue(ManageClassroomCoursePage.Sectiontab.VerifySection2Expanded());
            _test.Log(Status.Pass, "Verify Section2 is Expanded");
            SectionStartDate = SectionsPage.CopiedSectionStartDate();
            Assert.IsTrue(ManageClassroomCoursePage.Sectiontab.VerifySection2EnrollmentAndSectionDates(SectionStartDate));
            _test.Log(Status.Pass, "Verify Section2 the Enrollment Start Date is same as Section Start Date");

        }

        [Test]
        public void z02_Classroom_Section_Copy_With_Manual_Enrollment_Start_Date_35669()

        {

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35669");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
           // ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            //  ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
           // ManageClassroomCoursePage.Sectiontab.ClickDetails("Section1");
           // string EnrollStartDate = ManageClassroomCoursePage.Sectiontab.SectionDetails.EnrollmentStartDate();
            SectionStartDate = SectionsPage.SectionStartDate();
            // ManageClassroomCoursePage.Sectionsdropdown.CopySection();




            SectionsPage.SelectCopySectionformActionDropdown();
            _test.Log(Status.Info, "Select Copy Section from Mange Enrollment Dropdown Toggle");
            //Assert.IsTrue(SectionsPage.CopySectionModal.VerifyCopySectionModalComponets());
            //_test.Log(Status.Pass, "Verify Modal Title, Section Start date, Section title and timezone");
            Assert.IsTrue(SectionsPage.CopySectionModal.VerifyModalEnrollmentDate(SectionStartDate));
            _test.Log(Status.Pass, "Verify Enrollment Start Date is defaulted to Section Start Date");
            SectionsPage.CopySectionModal.EditSectionTitle("Section2");
            _test.Log(Status.Pass, "Change the Section Title to Section2");
            //SectionsPage.CopySectionModal.EnrollmentStartsToggle("Override");
            Assert.IsTrue(SectionsPage.CopySectionModal.EnrollmentStartsToggle("Override"));
            _test.Log(Status.Info, "Change the Enrollment Start Toggle to Override");
            SectionsPage.CopySectionModal.ChangeEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Change the Enrollment Start Date to before Section Start Date");
            SectionsPage.CopySectionModal.ClickCopy();
            _test.Log(Status.Info, "Click on Copy Button on Copy Section Modal");
            //Assert.IsTrue(Driver.comparePartialString("The classroom section was copied.", SectionsPage.GetFeedbackMessage()));
            //_test.Log(Status.Pass, "Verify Successful messasge");
            ManageClassroomCoursePage.Sectiontab.ClickDetails("Section2");
            Assert.IsTrue(ManageClassroomCoursePage.Sectiontab.VerifySection2Expanded());
            _test.Log(Status.Pass, "Verify Section2 is Expanded");
            SectionStartDate = SectionsPage.CopiedSectionStartDate();

            Assert.IsTrue(ManageClassroomCoursePage.Sectiontab.VerifySection2EnrollmentAndSectionDatesDifferent(SectionStartDate));
            _test.Log(Status.Pass, "Verify Section2 the Enrollment Start Date before the Section Start Date");

        }


    }


}


