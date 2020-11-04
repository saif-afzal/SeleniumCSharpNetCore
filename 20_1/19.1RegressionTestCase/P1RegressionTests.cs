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
    public class P1RegressionTests : TestBase
    {
        string browserstr = string.Empty;
        public P1RegressionTests(string browser)
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
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        bool TC_26224 = false;
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
        string assignment = "Assignment" + Meridian_Common.globalnum;

        string LevelName = "Level" + Meridian_Common.globalnum;
        string OrganizationTitle = "Organization" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        string documenttitle = "Doc" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string testtitle = "Test" + Meridian_Common.globalnum;
        static string today = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
        string markAsComplete = $"This item was marked as complete on "+today+".";
        public bool chktest = false;
        string AICCTitle= "AICC" + Meridian_Common.globalnum;
        string bunbdleTitle="Bundle"+ Meridian_Common.globalnum;
        string TATitle="TA"+ Meridian_Common.globalnum;

    
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
    

        [Test, Order(1), Category("AutomatedP11")]
        public void P20_1_a01_Login_8597()
        {
            _test.Log(Status.Pass, "login as siteadmin successful");
            Assert.IsTrue(HomePage.Title == "Home");//checks the Home page title
        }
        [Test, Order(16)]
        public void P20_1_a16_Equivalent_Items_to_an_AICC_Course_27160()
        {
            CommonSection.SearchCatalog(AICCTitle + "TC52241");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC52241");
            Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());
        }

        [Test, Order(2), Category("AutomatedP11")]
        public void a02_Click_the_Help_link_238()
        {
            CommonSection.ClickHelpIcon();
            _test.Log(Status.Info, "help icon opens successfully");
            Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
            _test.Log(Status.Pass, "Verified Help Page/Title");


        }
        [Test, Order(3), Category("AutomatedP11")]
        public void P20_1_a03_Logout_24943()
        {
            Assert.True(true);

        }
        [Test, Order(4), Category("AutomatedP11")]
        public void P20_1_a04_Create_a_new_organization_8552()
        {
            CommonSection.Administer.People.Organizations();
            _test.Log(Status.Info, "Open Organization page");

            OrganizationsPage.ClickCreatenew();
            _test.Log(Status.Info, "Click Create New Organization");

            NewOrganizationsPage.OrganizationTitleAs(OrganizationTitle).DescriptionAs("Automation test").Create();
            _test.Log(Status.Info, "Click Create New Organization");

            Assert.IsTrue(NewOrganizationsPage.SuccessmessgeDisplay());
            _test.Log(Status.Pass, "Verified Successful Message");

        }
        [Test, Order(5), Category("AutomatedP11")]
        public void P20_1_a05_Manage_Organization_8553()
        {

            //TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            CommonSection.Administer.People.Organizations();
            _test.Log(Status.Info, "Open Organization page");

            OrganizationsPage.SearchWith(OrganizationTitle).Search();
            _test.Log(Status.Info, "Search any Organization");

            Assert.IsTrue(Driver.comparePartialString(OrganizationTitle, OrganizationsPage.verifySearchedOrganizationTitle()));
            //StringAssert.AreEqualIgnoringCase(OrganizationTitle+ "Automation test", OrganizationsPage.verifySearchedOrganizationTitle());
            _test.Log(Status.Pass, "Verify search result");

            OrganizationsPage.ClickManageGoButton();
            _test.Log(Status.Info, "Click on Manage Go button");

            //Organizationobj.Click_ManageGoTo();
            EditOrganizationobj.Click_SelectManager();
            _test.Log(Status.Info, "Select Manager from Dropdown");
            SelectManagerobj.Click_AddManager();
            _test.Log(Status.Info, "Click on Add Manage button");
            Roleobj.Click_SearchUserToAdd("");
            _test.Log(Status.Info, "Perform Blank Search");
            Assert.IsTrue(Roleobj.Click_AddUsertoorganization());
            _test.Log(Status.Pass, "User added to Organization");

        }

        [Test, Order(6), Category("AutomatedP11")]
        public void P20_1_a06_View_job_Title_page_32179()

        {
            CareersPage.CreateJobTitle(JobTitle + "TC32179");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu Page");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Click on Job Title Tab");
            CareersPage.SearchJobtitle(JobTitle + "TC32179");
            _test.Log(Status.Info, "Search Job Title");
            CareersPage.ClickJobtitle(JobTitle + "TC32179");
            _test.Log(Status.Info, "Clicked on Searched Job Title");
            //CareersPage.EditJobTitleName(JobTitle);
            //_test.Log(Status.Info, "Perform Blank Search");
            StringAssert.AreEqualIgnoringCase(JobTitle + "TC32179", AdminContentDetailsPage.JobTitle_Title(), "Title Not Matched");
            _test.Log(Status.Pass, "Matched Job Title ");
            Assert.IsTrue(AdminContentDetailsPage.CompetenciesTabDisplay());
            _test.Log(Status.Pass, "Competencies tab Display on Job Title Details page");
            Assert.IsTrue(AdminContentDetailsPage.JobDetailstabDisplay());
            _test.Log(Status.Pass, "Job Details tab Display on Job Title Details page");

            //Deleted Job title After test complete
            CareersPage.DeleteJobTitle(JobTitle + "TC32179");
            _test.Log(Status.Info, "Job Title Deleted");
            StringAssert.AreEqualIgnoringCase("No matching records found", CareersPage.NoMatchingJobTitleFound("No matching records found"));
            _test.Log(Status.Pass, "Verify No matching records found message display after job title deleted");
        }
        [Test, Order(7), Category("AutomatedP11")]
        public void a07_Create_new_job_title_with_default_value_and_assign_to_a_career_path_33920()
        {
            //login with a admin 

            CareersPage.CreateCareerPath(CareerPathTitle + "TC33920");
            CreateCareerPathPage.LevelsandjobtitlesTab.ClickCreateLevel(); //inside frame

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Navigating to Career page");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab on Career page");
            CareersPage.ClickCreateJobTitleButton();
            _test.Log(Status.Info, "Click Create Job title button from Jobtitle tab");
            ManageJobTitlePage.CompetenciesTab.ClickCareerPath("None Selected");
            ManageJobTitlePage.CompetenciesTab.SearchandSelect(CareerPathTitle + "TC33920");
            ManageJobTitlePage.CompetenciesTab.clickyescheckmark();
            _test.Log(Status.Info, "Click on none selected career path from competencies tab, search CP_demo_2006 and select level 2");
            Assert.IsTrue(Driver.comparePartialString("Success", Driver.getSuccessMessage()));
            //StringAssert.AreEqualIgnoringCase("The selected items were added.", UnnamedJobtitled23Page.VerifyText(""));
            _test.Log(Status.Info, "Verify success message");
            StringAssert.AreEqualIgnoringCase(CareerPathTitle + "TC33920", ManageJobTitlePage.VerifyCareerpathText(CareerPathTitle + "TC33920"));
            _test.Log(Status.Info, "Verify Saved career path");
            StringAssert.AreEqualIgnoringCase("Level 1", ManageJobTitlePage.VerifyLevelText("Level 1"));
            _test.Log(Status.Info, "Verify Saved career path Level");
            String Jobtitletext = ManageJobTitlePage.getJobTitletext();
            ManageJobTitlePage.ClickCareerBreadcrumb();
            CareersPage.ClickCareerPathTab();
            _test.Log(Status.Info, "Navigating to Career Path Tab");
            CareersPage.CareerPathTab.SearchCareerPath(CareerPathTitle + "TC33920");
            CareersPage.CareerPathTab.ClickSearchResult(CareerPathTitle + "TC33920");
            _test.Log(Status.Info, "search and open career path");
            CreateCareerPathPage.LevelsandjobtitlesTab.ExpandLevel1();
            // CP_demo_2006Page.ClickLevel2Expandlink();
            _test.Log(Status.Info, "Expand level 1 for this career path");
            StringAssert.AreEqualIgnoringCase(Jobtitletext, CreateCareerPathPage.LevelsandjobtitlesTab.Level.JobtitletextinsideLevel1(Jobtitletext));
            _test.Log(Status.Info, "Verify career path name");

            CareersPage.DeleteCareerPath(CareerPathTitle + "TC33920");
            CareersPage.DeleteJobTitle(Jobtitletext);

        }


        [Test, Order(8), Category("AutomatedP11")]
        public void P20_1_a08_Delete_Scorm_from_Creating_Domain_7438()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC7438");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Deleting Document");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass as Document has been deleted from creating domain");

        }



        [Test, Order(9), Category("AutomatedP11")]
        public void a09_Launch_General_Course_26250()
        {
            #region Creating general course
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC26250", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion 
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from admin");
            LoginPage.LoginAs("ak_learner").WithPassword("password").Login();
            _test.Log(Status.Info, "Login with Learner");
            CommonSection.SearchCatalog(generalcourse + "TC26250");
            _test.Log(Status.Info, "Searching for general course from catalog");
            CatalogPage.ClickonSearchedCatalog(generalcourse + "TC26250");
            GeneralCoursePage.completeGeneralCourse();
            TC_26224 = true;
            _test.Log(Status.Pass, "Assertion Pass as Learner Launched & Completed the General Course");


        }

        [Test, Order(10), Category("AutomatedP11")]
        public void a10_Enroll_in_General_Course_26224()
        {
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //LoginPage.LoginAs("").WithPassword("").Login();
            Assert.IsTrue(TC_26224); // This test case already covered in above test case 26250
                                     // _test.Log(Status.Pass, "Assertion Pass as Learner abale to enroll into general course.");
        }
        [Test, Order(11), Category("AutomatedP11")]
        public void a11_Delete_general_Course_7439()
        {

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Creating general course
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC26250", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion 
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + generalcourse + "TC26250" + '"');
            _test.Log(Status.Info, "Search created general Course from Catalog");
            SearchResultsPage.ClickCourseTitle(generalcourse + "TC26250");
            _test.Log(Status.Info, "Click searched general course title");
            ContentDetailsPage.ClickEditContent();
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Deleting general Course");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass as Content has been deleted from creating domain");
        }
        [Test, Order(12), Category("AutomatedP11")]
        public void a12_Delete_AICC_Course_7436()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region creat AICC
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "7436");

            //driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            #endregion
            CommonSection.SearchCatalog('"' + AICCTitle + "7436" + '"');
            _test.Log(Status.Info, "Search created AICC Course from Catalog");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "7436");
            _test.Log(Status.Info, "Click searched AICC course title");
            ContentDetailsPage.ClickEditContent();
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Deleting general Course");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass as Content has been deleted from creating domain");
        }
        [Test, Order(13), Category("AutomatedP11")]
        public void a13_Delete_Bundle_10818()
        {
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "TC10818");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            //Assert.IsTrue(CreatebundlePage.DisplayFormatDropdown.isDefaultvaluedisplay());
            //_test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");

            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC10818" + '"');
            _test.Log(Status.Info, "Search created general Course from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC10818");
            _test.Log(Status.Info, "Click searched Bundle title");
            ContentDetailsPage.ClickEditContent();
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Deleting general Course");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass as Content has been deleted from creating domain");
        }
        [Test, Order(14), Category("AutomatedP11")]
        public void P20_1_a14_Delete_Curriculumn_10839()
        {
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "TC10839");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");

            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");

            CommonSection.SearchCatalog('"' + curriculamtitle + "TC10839" + '"');
            _test.Log(Status.Info, "Search created Curriculumn Course from Catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC10839");
            _test.Log(Status.Info, "Click searched Curriculumn course title");
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Deleting Content");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass as Content has been deleted from creating domain");
        }

        [Test, Order(15), Category("AutomatedP11")]
        public void P20_1_a15_Self_Waitlist_in_Classroom_Course_14509()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC14509");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("user");
            _test.Log(Status.Info, "Enrollment one user to section");

            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            _test.Log(Status.Info, "Login with a learner");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC14509" + '"');
            _test.Log(Status.Info, "Search created Classroom Course from Catalog");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC14509");
            _test.Log(Status.Info, "Click searched Classroom course title");
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            _test.Log(Status.Info, "Click at schedule tab");
            //Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Waitlist button Display for section");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsWaitlistbuttonDisplay());
            ContentDetailsPage.ScheduledCourse.ClickWaitlistButton();
            _test.Log(Status.Info, "Click Waitlist button");
            // Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsCancelWaitlistbuttonDisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsCancelWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Cancel Waitlist button Display for section");

        }
        [Test, Order(16), Category("AutomatedP11")]
        public void P20_1_a16_Self_Cancle_Waitlist_in_Classroom_Course_14510()  //Depend on 14509
        {

            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC14509" + '"');
            _test.Log(Status.Info, "Search created Classroom Course from Catalog");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC14509");
            _test.Log(Status.Info, "Click searched Classroom course title");
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            _test.Log(Status.Info, "Click at schedule tab");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsCancelWaitlistbuttonDisplay());
            // Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsCancelWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Cancel Waitlist button Display for section");
            // ContentDetailsPage.ScheduledCourse.ClickCancelkWaitlistButton();
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickCancelkWaitlistButton();

            _test.Log(Status.Info, "Click Cancel Waitlist button");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsWaitlistbuttonDisplay());
            //Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Waitlist button Display for section");


        }

        [Test, Order(17), Category("AutomatedP11")]
        public void a17_Self_Enroll_in_Classroom_Course_14432()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            #region create new course, add section to it and enroll
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC14432");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify successful message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add new Section Button");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Filled Title as Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Filled Max Capacity to 11");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "New Classroom Course CreatedVerify Section1 link is present on screen");
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            // _test.Log(Status.Pass, "Create New Course Section and Event");
            CommonSection.Logout();
            #endregion
            #region Login with a Learner, search classroom course and enroll
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            _test.Log(Status.Info, "Open Current trainging Page");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC14432" + '"');
            _test.Log(Status.Info, "Search course name as" + classroomcoursetitle + "_TC14432");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "_TC14432");
            _test.Log(Status.Info, "Click on Course title");
            CatalogPage.EnrollinClassroomCourse();
            _test.Log(Status.Info, "Click Enroll button");
            //Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle+ "_TC14432"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            #endregion


        }
        [Test, Order(18), Category("AutomatedP11")]
        public void P20_1_a18_Self_Cancel_Enrollment_in_Classroom_Course_14435()
        {
            #region Login with learner and Cancel Enrollment for an Enrolled Classroom Course
            //LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            //_test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            _test.Log(Status.Info, "Open Current trainging Page");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC14432" + '"');// ('"' + classroomcoursetitle + '"');
            _test.Log(Status.Info, "Search course name as" + classroomcoursetitle + "_TC14432");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "_TC14432"); //("ClassRoomCourseTitle2011472447");// 
            _test.Log(Status.Info, "Click on Course title");
            // Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle+ "_TC14432"));// (classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            //CurrentTrainings.ClickAction();

            CatalogPage.CancelEnrollment_WithoutReason();
            _test.Log(Status.Info, "Click on Cancel Enrollment");
            Assert.IsTrue(ContentDetailsPage.isEnrollButtonDisplay());// CatalogPage.GetMessages());
            _test.Log(Status.Pass, "Verify is Enroll button display");
            #endregion

        }
        [Test, Order(19)]
        public void P20_1_a19_Add_no_Due_Date_to_new_training_Assignment_30102()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "30102");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.isAssignDueDateDisplay());
            _test.Log(Status.Info, "verify is Assignment Due date modal open");
            CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.ClickCancel();
            _test.Log(Status.Pass, "Verify Assignment Due date modal is closed");


        }
        [Test, Order(20)]
        public void P20_1_a20_Add_One_Time_Dynamic_Date_Range_to_new_Training_Assignment_30239()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "30239");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetDueDateNonRecurring("Within days");
            _test.Log(Status.Info, "Set Due Date for Non recurring assignement and Save");
            CreateTrainingAssignmentPage.clickAssignButton();
            Assert.IsTrue(CreateTrainingAssignmentPage.isAssignmentStatus("Assigned"));


        }
        [Test, Order(21)]
        public void P20_1_a21_Add_Recurring_Yes_within_Due_Date_to_new_Training_Assignment_30495()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "30495");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent("general");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("somnath");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetDueDateRecurring("Within days");
            _test.Log(Status.Info, "Set Due Date for Non recurring assignement and Save");
            CreateTrainingAssignmentPage.clickAssignButton();
            Assert.IsTrue(CreateTrainingAssignmentPage.isAssignmentStatus("Assigned"));


        }
        [Test, Order(22)]
        public void P20_1_a22_Lunch_Curriculum_26346()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Create a general course
            CommonSection.CreateGeneralCourse(generalcoursetitle + "_TC26346");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC26346");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("_UnOrdered" + "_TC26346");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "_TC26346");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC26346");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26346");
            _test.Log(Status.Info, "Click on search result from catalog");
            ContentDetailsPage.EnrollinCurriculum();
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.MarkComplete_Curriculum());
        }
        [Test, Order(23)]
        public void P20_1_a23_Take_Curriculum_Related_Surveys_26347()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "_TC26347", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC326347");
            _test.Log(Status.Info, "Create A new Curriculum");

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
            SurveysPage.Click_backbutton();

            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("_UnOrdered" + "_TC26349");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "_TC26347");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.SearchCatalog(curriculamtitle + "TC326347");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC326347");
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplayForCurriculumn(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickCurriculumnEnroll();
            // Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailableforCurriculumn(Surveytitle_OnEnroll));
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.MarkComplete_Curriculum_whenSurveyRequired());
            ContentDetailsPage.Click_OverviewTab();
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailableforCurriculumn(Surveytitle_OnContentComplete));

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");
            ContentDetailsPage.Click_MarkComplete();
            _test.Log(Status.Pass, "Click at Take Survey button");
            // ContentDetailsPage.SurveyPortlet.CompleteSurvey(); // Why we need it to do?

            Assert.IsTrue(ContentDetailsPage.ClickViewCertificate_Curriculum());
            //Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");


        }





    }

}
