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
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1RegressionTests1 : TestBase
    {
        string browserstr = string.Empty;
        public P1RegressionTests1(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string Section = "Section" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        bool res1 = false;

        string LevelName = "Level" + Meridian_Common.globalnum;
        string OrganizationTitle = "Organization" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        bool ArchivedScale = false;
        string documenttitle = "Doc" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string title = "Google";
        static string today = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
        string markAsComplete = $"This item was marked as complete on "+today+".";
        string completed = "The item was marked complete.";
        string curriculamblocktitle = "curriculam1";
       


        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }
        public bool chktest = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

        }
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        bool TC_34132 = false;
        bool TC_26224 = false;
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
        string assignment = "Assignment" + Meridian_Common.globalnum;
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
       // [TearDown]
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

        [Test, Order(1), Category("AutomatedP1")]
        public void A01_Delete_Document_from_Creating_Domain_7435()
        {
            //Assert.Fail();
            CommonSection.CreateLink.Document();
            DocumentPage.Populate_DocumentData(documenttitle+"TC7435", "");
            DocumentPage.ClickButton_Create();
            _test.Log(Status.Info, "Dcoument Created");
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "Deleting Document");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass as Document has been deleted from creating domain");

        }

        [Test, Order(2), Category("AutomatedP1")]
        public void A02_Delete_Scorm_from_Creating_Domain_7438()
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

        [Test, Order(3), Category("P1"), Category("AutomatedP1")]
        public void A03_Manage_Content_Page_Redesign_34133()
        {
            #region Creating a Classroom Course Section With Tag
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle+"TC34133");
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
        [Test, Order(4), Category("P1")]
        public void A04_Manage_Content_Page_Redesign_34132()
        {
            Assert.IsTrue(TC_34132);
            _test.Log(Status.Pass, "Assertion Pass as Manage Content Elements have been verified");
        }

        [Test, Order(5), Category("AutomatedP1")]
        public void A05_Launch_General_Course_26250()
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
            LoginPage.LoginAs("ssuser1").WithPassword("password").Login();
            _test.Log(Status.Info, "Login with Learner");
            CommonSection.SearchCatalog(generalcourse+ "TC26250");
            _test.Log(Status.Info, "Searching for general course from catalog");
            CatalogPage.ClickonSearchedCatalog(generalcourse + "TC26250");
            GeneralCoursePage.completeGeneralCourse();
            TC_26224 = true;
            _test.Log(Status.Pass, "Assertion Pass as Learner Launched & Completed the General Course");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        [Test, Order(6), Category("AutomatedP1")]
        public void A06_Enroll_in_General_Course_26224()
        {
            Assert.IsTrue(TC_26224); // This test case already covered in above test case 26250
            _test.Log(Status.Pass, "Assertion Pass as Learner abale to enroll into general course.");
        }

        [Test, Order(7), Category("P1")]
        public void A07_User_Sets_Weekly_Recurrence_On_Section_34145()
        {
            #region Creating a Classroom Course Section With Weekday Recurrence
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34145");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section+"TC34145");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Weekly");
            _test.Log(Status.Info, "Setting Recurrence Type as Weekly");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34145"));
            _test.Log(Status.Pass, "Verify Section is Created with Weekly Recurrence Type");
            #endregion
        }

        [Test, Order(8), Category("P1")]
        public void A08_User_Sets_Every_Weekday_Recurrence_On_Section_34144()
        {
            #region Creating a Classroom Course Section With Every_Weekday Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34144");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34144");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Every Weekday");
            _test.Log(Status.Info, "Setting Recurrence Type as Every Weekday");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34144"));
            _test.Log(Status.Pass, "Verify Section is Created with Every Weekday Recurrence Type");

            #endregion
        }

        [Test, Order(9), Category("P1")]
        public void A09_User_Sets_Every_two_weeks_Recurrence_On_Section_34146()
        {
            #region Creating a Classroom Course Section With Every_two_weeks Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34146");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34146");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Every two weeks");
            _test.Log(Status.Info, "Setting Recurrence Type as Every two weeks");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34146"));
            _test.Log(Status.Pass, "Verify Section is Created with Every two weeks Recurrence Type");

            #endregion
        }

        [Test, Order(10), Category("P1")]
        public void A10_User_Sets_Monthly_Recurrence_On_Section_34148()
        {
            #region Creating a Classroom Course Section With Monthly Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34148");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34148");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Monthly");
            _test.Log(Status.Info, "Setting Recurrence Type as Monthly");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34148"));
            _test.Log(Status.Pass, "Verify Section is Created with Monthly Recurrence Type");

            #endregion
        }

        [Test, Order(11), Category("P1")]
        public void A11_User_Sets_Annually_Recurrence_On_Section_34147()
        {
            #region Creating a Classroom Course Section With Annually Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34147");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34147");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Annually");
            _test.Log(Status.Info, "Setting Recurrence Type as Annually");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34147"));
            _test.Log(Status.Pass, "Verify Section is Created with Annually Recurrence Type");

            #endregion
        }

        [Test, Order(12), Category("P1")]
        public void A12_User_Sets_Daily_Recurrence_On_Section_34143()
        {
            #region Creating a Classroom Course Section With Daily Recurrence

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34143");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34143");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.setRecurence("Daily");
            _test.Log(Status.Info, "Setting Recurrence Type as Annually");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34143"));
            _test.Log(Status.Pass, "Verify Section is Created with Daily Recurrence Type");

            #endregion
        }

        [Test, Order(13), Category("P1")]
        public void A13_Manage_Students_Manage_Notes_Instructor_9008()
        {
            #region Create Instructor
            Driver.CreateNewAccount("Instructor");
            _test.Log(Status.Info, "Created Instructor" + Meridian_Common.NewUserId);
            //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Logged in with admin");
            CommonSection.Administer.People.Instructor();
            _test.Log(Status.Info, "Navigated to Instructor Page");
            InstructorsPage.AddInstructor(Meridian_Common.NewUserId);
            _test.Log(Status.Info, "Created Instructor" + Meridian_Common.NewUserId);
            #endregion
            #region Creating a Classroom Course Section with Max 5 User and Instructor
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC9008");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC9008");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.Select_Specific_Instructor(Meridian_Common.NewUserId);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC9008"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            #region Enroll User into Section
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            ManageClassroomCoursePage.Enrollment();
            _test.Log(Status.Info, "Clicking Enrollment Tab");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");
            _test.Log(Status.Info, "Searching and Enrolling User");

            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage Training");
            CommonSection.Manage.TrainingPage.InstructorTool();
            _test.Log(Status.Info, "Navigate to Instructor Tool Page");
            InstructorsPage.Click_ManageStudent();
            _test.Log(Status.Info, "Click on Manage Student");
            InstructorsPage.Search_ForSection_InManageStudentPage(classroomcoursetitle + "TC9008");
            _test.Log(Status.Info, "Sarching for Classroom Course from Manage Student");
            Assert.IsTrue(InstructorsPage.Click_SectionTitle_FrommanageStudentPage(Section + "TC9008"));
            _test.Log(Status.Info, "Click on Section Title");
            SectionDetailsPage.clickEnrollmentTab();
            Assert.IsTrue(SectionDetailsPage.Add_Notes());
            _test.Log(Status.Pass, "Assertion Pass as Instructor successfully added Notes for enrolled user");
            Assert.IsTrue(SectionDetailsPage.Delete_Notes());
            _test.Log(Status.Pass, "Assertion Pass as Instructor successfully removed Notes for enrolled user");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        [Test, Order(14), Category("P1")]
        public void A14_Authorized_User_Should_Able_To_Access_Manage_Gradebook_11794()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage Training");
            CommonSection.Manage.TrainingPage.InstructorTool();
            _test.Log(Status.Info, "Navigate to Instructor Tool Page");
            InstructorsPage.Click_TeachingScheduleTab();
            InstructorsPage.Click_Expand_SectionDetail();
            _test.Log(Status.Info, "Click on Teaching Scheule and Expand the Detail.");
            Assert.IsTrue(InstructorsPage.Click_ManageGradeBookButton()); 
            
        }

        [Test, Order(15), Category("P1")] // Working on it
        public void A15_Instructor_Entering_Grades_for_an_Assignment_Should_not_Have_to_Search_for_Students_20376()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Creating a Classroom Course Section with Max 5 User and Instructor
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC20376");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC20376");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.Select_Specific_Instructor(Meridian_Common.NewUserId);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC20376"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            #region Enroll User into Section
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            ManageClassroomCoursePage.Enrollment();
            _test.Log(Status.Info, "Clicking Enrollment Tab");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            string expected_username = Driver.Instance.GetElement(By.XPath("//div[5]/div[1]/div[1]/form[1]/div[5]/div[1]/div[1]/div[2]/div[2]/table[1]/tbody[1]/tr[1]/td[2]")).Text;
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("");
            _test.Log(Status.Info, "Searching and Enrolling User");
            #endregion
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage Training");
            CommonSection.Manage.TrainingPage.InstructorTool();
            _test.Log(Status.Info, "Navigate to Instructor Tool Page");
            InstructorsPage.Click_ManageStudent();
            _test.Log(Status.Info, "Click on Manage Student");
            InstructorsPage.Search_ForSection_InManageStudentPage(classroomcoursetitle + "TC20376");
            _test.Log(Status.Info, "Sarching for Classroom Course from Manage Student");
            Assert.IsTrue(InstructorsPage.Click_SectionTitle_FrommanageStudentPage(Section + "TC20376"));
            _test.Log(Status.Info, "Click on Section Title");
            SectionDetailsPage.clickEnrollmentTab();
            string actual_username = Driver.Instance.GetElement(By.XPath("//div[1]/div[2]/div[1]/div[2]/div[2]/div[2]/table[1]/tbody[1]/tr[1]/td[2]")).Text;
            StringAssert.AreEqualIgnoringCase(expected_username, actual_username);
            _test.Log(Status.Pass, "Assertion Pass as users re displaying without performing search by instructor");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        [Test, Order(16), Category("P1"), Category("AutomatedP1")]
        public void A16_Batch_Enroll_and_MarkComplete_User_into_Online_Course_with_Cost_34154()
        {
            #region Create General Course with Cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34154", "Test General Course");
            GeneralCoursePage.setCost("5");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Goto Training Page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Click on Batch enroll online course link");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34154");
            _test.Log(Status.Info, "Search for online course");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//div[@aria-disabled='true']")));
            _test.Log(Status.Pass, "Batch Enroll and MarkComplete User into Online Course with Cost");
            //  CommonSection.Manage.TrainingPage.searchFor_UsersToEnroll("");
            //  CommonSection.Manage.TrainingPage.BatchEnroll_OnlineCourse(); // In Progress
            // xpath = //label[@id='lblMarkComplete']

        }

        [Test, Order(17), Category("P1"), Category("AutomatedP1")]
        public void A17_BatchEnroll_And_MarkComplete_User_into_NoCost_OnlineCourse_where_Toggle_SetTo_Yes_34149()
        {
            #region Create General Course without cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34149", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Goto Training Page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Click on Batch enroll online course link");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34149");
            _test.Log(Status.Info, "Search for online course");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//div[@aria-disabled='true']")));
            _test.Log(Status.Pass, "Mark Enrollee complete toggle is disabled");
            CommonSection.Manage.TrainingPage.searchFor_UsersToBatchEnroll("");
            _test.Log(Status.Info, "Search for user to batch enroll");
            CommonSection.Manage.TrainingPage.select_UsersToBatchEnroll();
            _test.Log(Status.Info, "Select users to batch enroll");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.switchToggle_toYes_MarkEnrolleesComplete());
            _test.Log(Status.Pass, "Toggle set to Yes");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.Click_BatchEnroll_Button_OnlineCourse_WhenToogle_Yes());
            _test.Log(Status.Pass, "BatchEnroll And MarkComplete User into NoCost Online Course where Toggle Set To Yes");

        }

        [Test, Order(18), Category("P1"), Category("AutomatedP1")]
        public void A18_BatchEnroll_And_MarkComplete_User_into_NoCost_OnlineCourse_where_Toggle_SetTo_No_34163()
        {
            #region Create General Course without cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34163", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Goto Training Page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Click on Batch enroll online course link");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34163");
            _test.Log(Status.Info, "Search for online course");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//label[contains(text(),'Mark Enrollees Complete')]")));
            _test.Log(Status.Pass, "Mark Enrollee complete lable is disabled");
            CommonSection.Manage.TrainingPage.searchFor_UsersToBatchEnroll("");
            _test.Log(Status.Info, "Search for user to batch enroll");
            CommonSection.Manage.TrainingPage.select_UsersToBatchEnroll();
            _test.Log(Status.Info, "Select users to batch enroll");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.Click_BatchEnroll_Button_OnlineCourse_WhenToogle_No());
            _test.Log(Status.Pass, "BatchEnroll And MarkComplete User into NoCost Online Course where Toggle Set To No");

        }

        [Test, Order(19), Category("P1"), Category("AutomatedP1")]
        public void A19_UserManager_BatchEnroll_and_MarkComplete_User_into_NoCost_Online_Course_34164()
        {
            #region Create Learner
            Driver.CreateNewAccount("Learner");
            _test.Log(Status.Info, "Created Learner" + Meridian_Common.NewUserId);
             LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Logged in with admin");
            #endregion

            #region Create General Course without cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34164", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Goto batch enrollment online course page");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34164");
            _test.Log(Status.Info, "search for online content");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//label[contains(text(),'Mark Enrollees Complete')]")));
            _test.Log(Status.Pass, "Mark Enrollees Complete Lable Displaying");
            CommonSection.Manage.TrainingPage.searchFor_UsersToBatchEnroll(Meridian_Common.NewUserId);
            _test.Log(Status.Info, "Search for user");
            CommonSection.Manage.TrainingPage.select_UsersToBatchEnroll();
            _test.Log(Status.Info, "Select user's to batch enroll");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.switchToggle_toYes_MarkEnrolleesComplete());
            _test.Log(Status.Pass, "Switch Toggle to Yes");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.Click_BatchEnroll_Button_OnlineCourse_WhenToogle_Yes());
            _test.Log(Status.Pass, "Click Batch Enroll Button When Toggle is Set to Yes");
            CommonSection.Manage.People();
            _test.Log(Status.Info, "Goto People Page");
            PeoplePage.Search_User(Meridian_Common.NewUserId);
            _test.Log(Status.Info, "Search user");
            PeoplePage.viewTranscript();
            _test.Log(Status.Info, "Open User's Transcript");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//td[contains(.,'"+ generalcourse + "TC34164" + "')]")));
            _test.Log(Status.Pass, "Correct Course displayin in user's transcript");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//td[contains(.,'Completed')]")));
            _test.Log(Status.Pass, "Status displayin as Completed in user's transcript");
        }

        [Test, Order(20), Category("P1")]
        public void A20_Learner_Want_To_Know_The_Timezone_Associated_With_A_Scheduled_Event_34112()
        {
            //  CommonSection.Administer.System.SystemAdministration.SystemBehaviorAndStorage();
            //  SystemBehaviorAndStoragePage.enableTimeZoneVisibility();
            // -> Above codes are commented as there is a defect in saving the information.
            #region Creating a Classroom Course and Section Event
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34112");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC34112");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.SelectTimeZone();
            _test.Log(Status.Info, "Select Timezone as EST");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC34112"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("password").Login();
            _test.Log(Status.Info, "Logged in with learner");
            CommonSection.Avatar.Account();
            _test.Log(Status.Info, "Navigat to Profile Page");
            AccountPage.ClickPreferencesTab();
            _test.Log(Status.Info, "Click on Preferences Tab");
            AccountPage.Click_EditPreferencesButton();
            _test.Log(Status.Info, "Click Edit Preference");
            AccountPage.Change_Timezone();
            _test.Log(Status.Info, "Change time zone to CST");
            AccountPage.Click_SavePreferencesButton();
            _test.Log(Status.Info, "Save The Detail");
            CatalogPage.SearchContent_InCatalogPage(classroomcoursetitle + "TC34112");
            string timezonecatalog = ClassroomCoursePage.verifyTimeZone_CatalogPage();
            Assert.IsTrue(timezonecatalog.Contains("CST"));
            _test.Log(Status.Pass, "Assertion Pass as Timezone displaying to user in catalog Search detail");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34112");
            string timezonedetailpage = ClassroomCoursePage.verifyTimeZone_ClassroomDetailPage();
            Assert.IsTrue(timezonedetailpage.EndsWith("CST"));
            _test.Log(Status.Pass, "Assertion Pass as Timezone displaying to user in section detail");
            string eventdetail = ClassroomCoursePage.verifyTimeZone_EventDetail();
            Assert.IsTrue(eventdetail.EndsWith("CST"));
            _test.Log(Status.Pass, "Assertion Pass as Timezone displaying to user in Event detail");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logg Out from learner");
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Log in with admin");

        }

        [Test, Order(21), Category("P1")]
        public void A21_User_Adds_Additional_Event_While_Creating_Classroom_Section_33709()
        {
            #region Creating a Classroom Course and Section with additional Event
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33709");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC33709");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            string s = ManageClassroomCoursePage.add_AnotherEvent(Section + "TC33709"); //add Tab mechanism
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC33709"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            string s2 = ClassroomCoursePage.click_DetailButton(s);
            _test.Log(Status.Info, "Expand the event detail");
            Assert.IsTrue(s2.Contains("_2ndEvent"));
            _test.Log(Status.Pass, "Assertion Pass as Events details are displaying correct");
            StringAssert.AreEqualIgnoringCase(s, s2);
            _test.Log(Status.Pass, "Assertion Pass as Multiple events has been created for classroom course section");

        }

        [Test, Order(22), Category("P1")]
        public void A22_View_All_Assignments_For_Section_And_Edit_Their_Weights_In_Bulk_14678()
        {
            #region Creating a Classroom Course and Section
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC14678");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs(Section + "TC14678");
            _test.Log(Status.Info, "Enter Title of Section");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("5");
            _test.Log(Status.Info, "Enter Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink(Section + "TC14678"));
            _test.Log(Status.Pass, "Verify Section is Created");
            #endregion
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            ManageClassroomCoursePage.Enrollment();
            _test.Log(Status.Info, "Clicking Enrollment Tab");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            string expected_username = Driver.Instance.GetElement(By.XPath("//div[5]/div[1]/div[1]/form[1]/div[5]/div[1]/div[1]/div[2]/div[2]/table[1]/tbody[1]/tr[1]/td[2]")).Text;
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser_MultipleUsers("");
            _test.Log(Status.Info, "Searching and Enrolling User");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs(assignment + "1");
            _test.Log(Status.Info, "Added First Assignment");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs(assignment + "2");
            _test.Log(Status.Info, "Added Second Assignment");
            SectionDetailsPage.ClickGradebookTab();
            _test.Log(Status.Info, "Click on Gradebook Tab");
            SectionDetailsPage.Click_GradesOnlyButton();
            _test.Log(Status.Info, "Click on Grade Only Tab");
            Assert.IsTrue(SectionDetailsPage.enterGradeForUser_PASS_OR_FAIL());
            _test.Log(Status.Pass, "Assertion Pass as user able to edit weights in bulk successfully.");

        }
        [Test, Order(23), Category("AutomatedP1")]
        public void z34_View_SCORM_Course_Details_26366()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26366");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");
            CommonSection.SearchCatalog('"' + scormtitle + "TC26366" + '"');
            _test.Log(Status.Info, "Search created document from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26366");
            _test.Log(Status.Info, "Click searched document title");

            ContentDetailsPage.ClickEnrollButton();
            //ContentDetailsPage.ClickOpenItem();

            //Assert.IsTrue(ContentDetailsPage.)

        }
        //[Test, Order(35)]
        //public void View_Classroom_Course_Details_26368()
        //{
        //    #region Manage Classroom Course
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC26368");
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.SelectAddDayEventCheckbox();
        //    ManageClassroomCoursePage.SetEnrollmentStartDate("Currentdate-1");
        //    _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
        //    ManageClassroomCoursePage.SelectWaitListasYes();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");

        //    SectionsPage.SelectViewAsLearner();
        //    _test.Log(Status.Info, "Click view as learner");
        //    Assert.IsTrue(ContentDetailsPage.isEnrollButtonDisplay());
        //    _test.Log(Status.Pass, "Verify Enroll button is display");
        //    ContentDetailsPage.ClickEnrollButton();
        //    _test.Log(Status.Info, "Click Enroll Button");


        //    #endregion

        //}
        [Test, Order(24),Category("AutomatedP1")]
        public void z35_Create_Classroom_Section_1823()
        {
            Assert.IsTrue(true);  // as this test cases coved in section management.
        }
        [Test, Order(25),Category("AutomatedP1")]
        public void z36_Create_Classroom_Event_1989()
        {
            Assert.IsTrue(true);  // as this test cases coved in section management.
        }
        [Test, Order(26), Category("AutomatedP1")]
        public void z37_Request_Access_to_Classroom_Course_26839()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC26839");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
           // ManageClassroomCoursePage.SetEnrollmentStartDate("Currentdate-1");
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            SectionsPage.SelectViewAsLearner();
            _test.Log(Status.Pass, "Click view as learner");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");

        }
        [Test, Order(27), Category("AutomatedP1")] // Depend on Z38
        public void z38_Cancel_Access_Request_to_Classroom_Course_26840()
        {
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC26839" + '"');
            _test.Log(Status.Info, "Search created Classroom Course from Catalog");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC26839");
            _test.Log(Status.Info, "Click searched Classroom course title");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.AccessApprovalModal.CancelRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
        }
        [Test, Order(28), Category("AutomatedP1")]
        public void z39_Add_Classroom_Sections_to_Classroom_Training_Activities_10848()
        {

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC10848");
            _test.Log(Status.Info, "Creating New Curriculum");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            ContentDetailsPage.Accordians.ClickEdit_CurriculumContent();
            _test.Log(Status.Info, "Click Curricumn Content Edit button");
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("Test");
            _test.Log(Status.Info, "Add a new block using Add Curriculum Block");
            CurriculumContentPage.ClickAddTrainingActivities();
            AddTrainingActivitiesPage.Search(classroomcoursetitle + "TC26839");  //depend on 26839
            AddTrainingActivitiesPage.AddTraing();
            Assert.IsTrue(AddTrainingActivitiesPage.verifyfeedbackmessage("The selected items were added."));
            AddTrainingActivitiesPage.Click_backbutton();
            CurriculumContentPage.RemoveTrainingActivities();
            _test.Log(Status.Info, "Remove added training activities from content");
            Assert.IsTrue(CurriculumContentPage.GetSuccessMessage("The item was removed."));
            _test.Log(Status.Pass, "Verify Feedback message");
            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(29), Category("AutomatedP1")]
        public void Z40_Self_Waitlist_in_Classroom_Course_14509()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC14509");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
          //  ManageClassroomCoursePage.SetEnrollmentStartDate("Currentdate-1");
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

            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Waitlist button Display for section");
            ContentDetailsPage.ScheduledCourse.ClickWaitlistButton();
            _test.Log(Status.Info, "Click Waitlist button");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsCancelWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Cancel Waitlist button Display for section");

        }
        [Test, Order(30), Category("AutomatedP1")]
        public void Z41_Self_Cancle_Waitlist_in_Classroom_Course_14510()  //Depend on 14509
        {

            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC14509" + '"');
            _test.Log(Status.Info, "Search created Classroom Course from Catalog");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC14509");
            _test.Log(Status.Info, "Click searched Classroom course title");

            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsCancelWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Cancel Waitlist button Display for section");
            ContentDetailsPage.ScheduledCourse.ClickCancelkWaitlistButton();
            _test.Log(Status.Info, "Click Cancel Waitlist button");
            Assert.IsTrue(ContentDetailsPage.ScheduledCourse.IsWaitlistbuttonDisplay());
            _test.Log(Status.Pass, "Verify Waitlist button Display for section");

        }

    }

}
