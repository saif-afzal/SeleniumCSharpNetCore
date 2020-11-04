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
    //[TestFixture("chbs", Category = "chrome")]
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

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

       // [OneTimeSetUp]
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

        [Test, Order(2), Category("AutomatedP1")]
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
        [Test, Order(3)]

        public void a03_User_View_Section_Date_Time_in_Read_Only_Format_Only_33668()
        {
            #region Create Classroom Course With Adding Notes
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Success Message Verified");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "New Section Created");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            _test.Log(Status.Info, "Click Manage Enrollment Action");
            ManageClassroomCoursePage.SectionDetailTab();
            _test.Log(Status.Info, "Click on Section Details Tab");
            Assert.IsTrue(ManageClassroomCoursePage.ClickButton_EditSection());
            _test.Log(Status.Pass, "Verify Section Start and End Dates are disabled");

            #endregion
        }


        [Test, Order(4), Category("AutomatedP1")]

        public void a04_Create_New_Section_with_New_Hybrid_Event_Future_Date_33494()
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

        [Test, Order(5)]
        public void a05_Create_Setion_With_Past_Date_33497()
        {
            #region Create New Course, Add Section with Past Date

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33497");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys("07/15/2018 5:30 PM");
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).SendKeys("07/15/2018 6:30 PM");
            IWebElement webElement = Driver.Instance.GetElement(By.XPath("//button[@id='location_0']"));//You can use xpath, ID or name whatever you like
            webElement.SendKeys(Keys.Tab);
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "Click on Create Button");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//label[contains(.,'Complete(1)')]")));
            _test.Log(Status.Pass, "Assertion Pass as Past Date Section not displaying in Grid.");
            #endregion
        }

        [Test, Order(6)]

        public void a06_Admin_User_Add_Remove_Notes_in_Classroom_Course_Section_33705()
        {
            #region Create Classroom Course With Adding Notes


            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33705");
            _test.Log(Status.Pass, "New Classroom Course Created");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Pass, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();

            Assert.IsTrue(ManageClassroomCoursePage.EnterNotes("Testing Notes"));
            _test.Log(Status.Pass, "Assertion Pass - Added Notes into Section");

            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "New Section Created");

            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.ScheduleTab());

            ManageClassroomCoursePage.ClickReadNotesButton();
            _test.Log(Status.Pass, "Read Notes Popup Open.");

            ManageClassroomCoursePage.ClickCloseReadNotePopup();
            _test.Log(Status.Pass, "Read Notes Popup Closed.");

            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC33705");

            #endregion
        }
        [Test, Order(7)]
        public void a07_Create_Setion_With_Different_TimeZone_33501()
        {
            #region Create New Course, Add Section with different timezone

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33501");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectTimeZone();
            ManageClassroomCoursePage.SelectWaitListasYes();
                      
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            //ManageClassroomCoursePage.CreateSection.Create();
         
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            #endregion
            CommonSection.Logout();
            #region Create User and Enroll into above created classroom section
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as a Learner");
            //CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33501" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33501");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC33501"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            CatalogPage.EnrollinClassroomCourse();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
            _test.Log(Status.Pass, "Assertion Pass, User Enrolled in Timezone Specific Section");

            #endregion
        }

        [Test, Order(8)]
        public void a08_View_Events_in_Section_Schedule_33511()
        {
            //This Test is to test the format of Events >> Schedule page. 
            //Pre-requisite For this test - Classroom Course, Sections, and Events with and without Location, Tnstructor, Notes are already created
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33511");
            _test.Log(Status.Pass, "New Classroom Course Created");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section 1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Pass, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section page");

            ManageClassroomCoursePage.ClickonSection();
            _test.Log(Status.Info, "Click Section created section title");
            Assert.IsTrue(SchedulePage.ScheduleTabisvisible());
            _test.Log(Status.Pass, "Schedule Tab is displaying");
            SchedulePage.ClickScheduleTab();
            _test.Log(Status.Info, "Click Section Schedule tab");
            //Assert.IsTrue(SectionsDetailsPage.ClickScheduleTab();
            //EventsPage.ScheduleTab.VerifyListofEvents();
            Assert.IsTrue(SchedulePage.ScheduleTab.EventTitlecolumn.EventTitleText()); //Verify Event Title is displayed as link
            _test.Log(Status.Pass, "Verify Event Title on Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Schedulecolumn.EventStartEndDatecolumn()); //Verify right Event Start Date and time is displayed
            _test.Log(Status.Pass, "Verifying Event start date and time in Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Instructorscolumn.Instructorscolumn()); //Verify right Event Instructor is displayed if entered
            _test.Log(Status.Pass, "verifing Instructors column display on Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Locationcolumn.Locationscolumn()); //Verify right Event Location is displayed if entered
            _test.Log(Status.Pass, "Verify Location on Schedule Tab");
            Assert.IsTrue(SchedulePage.ScheduleTab.Notescolumn.IsNotesColumnDisplay());
            _test.Log(Status.Pass, "Verify notes column on Schedule Tab is displaying");
            Assert.IsTrue(SchedulePage.ScheduleTab.CreateNewEventButton);
            _test.Log(Status.Pass, "Verify Create new Event button on Schedule Tab is displaying");
            Assert.IsTrue(SchedulePage.ScheduleTab.BacktoSectionsButton);
            _test.Log(Status.Pass, "Verify Back to Section button on Schedule Tab is displaying");
        }
        [Test, Order(9)]

        public void a09_View_Instructors_Schedule_While_Adding_Instructor_To_A_Classroom_Course_Section_33902()
        //Prerequisite: Event type must be in-person
        {
            // CommonSection.Logout();
            // LoginPage.LoginAs("").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as an Admin User");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33902");
            _test.Log(Status.Info, "New Classroom Course Created");
            // ClassroomCoursePage.EnterDescription("Classroom Course Description");
            // ClassroomCoursePage.EnterKeywords("Classroom Course Keywords").ClickCreateButton();
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.EnterStartDateAndTime("10/15/2019");
            _test.Log(Status.Info, "Enter Start date");
            ManageClassroomCoursePage.EnterEndDateAndTime("10/15/2019");
            _test.Log(Status.Info, "Enter End date");
            ManageClassroomCoursePage.ClickSelectLocationButton();
            _test.Log(Status.Info, "Click on Select Location Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectLocationModaldisplay());
            _test.Log(Status.Pass, "Select Location Modal is display");
            ManageClassroomCoursePage.SelectLocationModal.ClickLocationRadioButton();
            ManageClassroomCoursePage.SelectLocationModal.ClickSet(); //Select the Location by clicking on the Radio button and Select Set
            _test.Log(Status.Info, "Search Location and add it to section");
            Assert.IsTrue(ManageClassroomCoursePage.LocationAdded());// Verify the Location selected in Modal is displayed in the Location field
            _test.Log(Status.Pass, "Location Added to Section");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Select Instructor Modal is display");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search Instructor");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModal.ViewScheduleButton()); //Verify the all the Instructors display View Schedule button
            _test.Log(Status.Pass, "Verify View Schedule Button is display");
            ManageClassroomCoursePage.SelectInstructorModal.ClickViewScheduleButton(); //Select the View Schedule button
            _test.Log(Status.Info, "Click on  View Schedule Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModal.InstructorCalendarModaldisplay());// Verify the Instructor Schedule (Calendar) is displayed
            _test.Log(Status.Pass, "Verify Instructor Calender is display");
            ManageClassroomCoursePage.SelectInstructorModal.CloseInstructorCalendarModal();
            _test.Log(Status.Info, "Verify Instructor Calender is display");
            ManageClassroomCoursePage.SelectInstructorModal.CloseInstructorModal();
            _test.Log(Status.Info, "Close Select Instructoe Modal");
        }
        [Test, Order(10)]

        public void a10_Upload_A_File_To_A_Section_Content_Tab_33918()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33918");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button on Create Section page");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            Assert.IsTrue(SectionsPage.SectionDetailsPageOpened());
            _test.Log(Status.Pass, "Section Details Page is opened");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsFalse(SectionDetailsPage.ContentTab.UploadFilesModaldisplay());
            _test.Log(Status.Pass, "Upload Files Modal is opened");

            SectionDetailsPage.ContentTab.UploadFile();
            Assert.IsFalse(SectionDetailsPage.ContentTab.UpLoadFileModalIsClosed()); //Verify Upload File modal is closed
            _test.Log(Status.Pass, "Verify Upload Files Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFileAdded()); //Verify the File just uploaded is displayed 
            _test.Log(Status.Pass, "Verify Uploaded file is display into Content tab");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
           // StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different"); //Verified the "Yes, when learner enrolls" option is displayed
            _test.Log(Status.Pass, "Verify option text has been updated");

        }
        [Test, Order(11)]

        public void a11_View_Files_And_Notes_In_Section_Content_Tab_33916()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33916");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ManageClassroomCoursePage.SectionsPage.ListofSections);
            _test.Log(Status.Pass, "Verify created section is display");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            //Assert.IsTrue(SectionDetailsPage.FilesAndNotesPanelRemoved); // Verify the Files and Notes Panel from Section Details page is removed
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.UploadFile();
            Assert.IsFalse(SectionDetailsPage.ContentTab.UpLoadFileModalIsClosed()); //Verify Upload File modal is closed
            _test.Log(Status.Pass, "Verify Upload Files Modal is closed");
            SectionDetailsPage.ContentTab.SelectAddNotesFromAddContentdropdown();
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");

            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFiles); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListNotes); // Verify the Note is added and is displayed 
            _test.Log(Status.Pass, "Verify Add Note is display into Content tab");// Verify Notes associated with that section is displayed and can be viewed by clicking on them
                                                                                  // Assert.IsTrue(SectionDetailsPage.ContentTab.NotesTitleXCharactersOfActualNote());//Verify the Note Title is first # of characters of actual note
                                                                                  // Assert.IsTrue(SectionContentPage.List.AddedByColumnRemoved);//Verify "Added By" column is removed from list of Notes and Files
        }
        [Test, Order(12)]

        public void a12_Create_A_Note_On_A_Section_Content_Tab_33926()

        {
            #region Create Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33926");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "Set Max Entollment Capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Sections Tab ");
            Assert.IsTrue(ManageClassroomCoursePage.SectionsPage.ListofSections);
            _test.Log(Status.Pass, "Verify created section is display");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            Assert.IsTrue(SectionsPage.SectionDetailsPageOpened());
            _test.Log(Status.Pass, "Section Details Page is opened");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Create Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListNoteAdded); // Verify the Note is added and is displayed 
            _test.Log(Status.Pass, "Verify Add Note is display into Content tab");
            SectionDetailsPage.ContentTab.ClickNoteName();//Click on the Note Name in the Section Content page 
            _test.Log(Status.Info, "Click On added note title");
            Assert.IsTrue(SectionDetailsPage.ContentTab.NoteModalOpened);// Verify the Note opens and can be viewed 
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.CloseAddNoteModal();
            _test.Log(Status.Info, "Close Add Note Modal");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
        }
        [Test, Order(13)]
        public void a13_Test_When_User_reserve_Seats_Navigation_9034()
        {
            //LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC9034");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            //ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //_test.Log(Status.Info, "Enter Section Title As Section1");
            CreateNewCourseSectionAndEventPage.CreateSection("Section1", DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"), DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
           // ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("05");
           // _test.Log(Status.Info, "Set Max Entollment Capacity as 05");

           // // ManageClassroomCoursePage.SelectWaitListasYes();
           // //   _test.Log(Status.Info, "Click Waitlist as Yes");
           // ManageClassroomCoursePage.CreateSection.Create();
           // _test.Log(Status.Info, "Click Create Button");
           //// StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different");
           // ManageClassroomCoursePage.Clicktab("Sections");
           // _test.Log(Status.Info, "Click on Sections tab");

            ManageClassroomCoursePage.Sectionsdropdown.SelectManageoption("Reserved Seats");
            ManageClassroomCoursePage.Enrollmenttab.ReservedSeatsbutton();
            _test.Log(Status.Info, "Validate a new Modal opens with a search box and search results are displayed ");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollmenttab.ReserveSeatsModelDisplay());
            //EnrollmentPage.ClickReservedSeatsButton();
            _test.Log(Status.Info, "Validate a new Modal opens with a search box and search results are displayed ");
            ManageClassroomCoursePage.Enrollmenttab.EnrolGrouptoReserveSeats("user");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollmenttab.Groupdisplayintoreservetab());
            _test.Log(Status.Info, "Validate User has been display in Reserved Tab ");

            //delete added group to make this script rerun.

            ManageClassroomCoursePage.Enrollmenttab.SelectAddedUserGroup();
            ManageClassroomCoursePage.Enrollmenttab.ClickRemove();
            ClassroomCoursePage.DeleteClassroomCourse(classroomcoursetitle + "TC9034");
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

        [Test, Order(16)]
        public void a16_Set_Enrollment_Cancellation_Setting_From_Section_Waitlist_33255()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            #region Create New Course, Add Section with different timezone

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "33255");
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


            _test.Log(Status.Pass, "Click on Create Button");
            #endregion

            #region Enroll Users
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.ClickEnrollButton();
            ManageClassroomCoursePage.SelectCheckBox();
            ManageClassroomCoursePage.ClickEnroll();
            _test.Log(Status.Pass, "User Enrolled into Section");
            #endregion

            #region Waitlist User
            EnrollmentPage.EnrollmentTab.ClickWaitlistedSubTab();
            EnrollmentPage.ClickWaitlistUsersButton();
            EnrollmentPage.SelectCheckBox();//Select few Users
            EnrollmentPage.ClickWaitlistButton();
            _test.Log(Status.Pass, "User Waitlisted into Section");
            #endregion
            //EnrollmentPage.EnrollmentTab.ClickEnrolled();
            //ManageClassroomCoursePage.Enrollmenttab.UpdateAttendanceRequiredfromNotoYes();
            
            Assert.IsTrue(EnrollmentPage.EnrollmentTab.SelectYes()); //Select the 1st User in the List and make Attendance Required to Yes.  Remember User Name
            _test.Log(Status.Pass, "Assertion Pass : User's Cancel Enrollment Setting has been set");


        }


        [Test, Order(17)]
        public void a17_Test_when_user_navigates_to_section_enrollment_From_sections_listing_33267()
        {
            CommonSection.Logout();
           LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin



            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "33267");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("dv_class1105");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();


            _test.Log(Status.Pass, "Click on Create Button");

  

            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("dv_class1105"));
            _test.Log(Status.Pass, "Section Created successfully");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Open Training Page");
            //CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');
            //CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);
            TrainingPage.ManageContentSearchText(classroomcoursetitle + "33267").Click();
            _test.Log(Status.Info, "Search Classroom course");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section");
            //TrainingPage. ManageContentSearchText("dv_class1105").click;
            //TrainingPage.click.dv_class1105();
            //dv_class1105.ClickSectionsTab();
            SectionsPage.ClickManageEnrollmentButton();//click manage enrollment button for section 1
            _test.Log(Status.Info, "Click on Manage Enrollment");
            Assert.IsTrue(Driver.comparePartialString("Enrollment", EnrollmentPage.VerifyTab()));
            StringAssert.AreEqualIgnoringCase("There are no enrolled students.", EnrollmentPage.GetDescriptionLink(), "Description does not match");
            _test.Log(Status.Pass, "Verified Enrollment tab and its description");
        }




        [Test, Order(18)]
        public void a18_Manage_Waitlist_from_Sections_listing_for_Completed_Section_and_Enrollment_is_Full_33273()

        {
            #region manage Classroom

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "33223");
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


            _test.Log(Status.Pass, "Click on Create Button");
            #endregion

            #region Enroll Users
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            ManageClassroomCoursePage.ClickEnrollmentTab();
            ManageClassroomCoursePage.ClickEnrollButton();
            ManageClassroomCoursePage.SelectCheckBox();
            ManageClassroomCoursePage.ClickEnroll();
            _test.Log(Status.Pass, "User Enrolled into Section");
            #endregion

            #region Waitlist User
            EnrollmentPage.EnrollmentTab.ClickWaitlistedSubTab();
            EnrollmentPage.ClickWaitlistUsersButton();
            EnrollmentPage.SelectCheckBox();//Select few Users
            EnrollmentPage.ClickWaitlistButton();
            _test.Log(Status.Pass, "User Waitlisted into Section");

            EnrollmentPage.ClickViewAslearner();
            #endregion





            

            #region oldcode
            //Searching a ClassRoomCourse and find a section which status is complete with wait and Enrollment is full
            // #region Manage Classroom Course
            //CommonSection.Manage.Training();
            //TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            //StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            //TrainingPage.ClickSearchRecord("Classroom Course");
            //StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            //ClassroomCoursePage.ClickSectionsTab();
            //Assert.IsTrue(SectionsPage.ListofSections);
            //#endregion

            //#region Create Sections
            //ClassroomCourseDetailsPage.ClickSectionstab();
            //SectionsPage.Sectionstab.ClickAddaNewSectionbutton();
            //AddSectionPage.EnterSectionTitle("Section 1").ClickNext();
            //AddSectionPage.SelectAddDayEventCheckbox();
            //AddSectionPage.StartDateField.EnterStartDate("CurrentStartDate");
            //AddSectionPage.EndDateField.EnterEndDate("CurrentEndDate");
            //AddSectionPage.Capacity.MinimumField.EnterMinimum("0");
            //AddSectionPage.Capacity.MaximumField.EnterMaximum("3");
            //AddSectionPage.Waitlist.SelectUseWaitlist();
            //AddSectionPage.EnrollmentPeriodfield.ClickChangebutton();
            //EnrollmentPeriodModal.EnrollmentStartDateField.EnterStartDate("PastStartDate");
            //EnrollmentPeriodModal.EnrollmentEndDateField.EnterEndDate("CurrentEndDate"); //Date of Section End Date
            //EnrollmentPeriodModal.EnrollmentStartTimeField.EnterStartTime("12:30AM"); //Time before Section Start Time
            //EnrollmentPeriodModal.EnrollmentEndTimeField.EnterEndTime("11:30PM"); //Time before Section End Time
            //EnrollmentPeriodModal.ClickSaveButton();
            //Assert.IsTrue(AddSectionPage.EnrollmentDateAndTimeDisplayed);
            //AddSectionPage.ClickSave();
            //StringAssert.AreEqualIgnoringCase("The course section was created with the first event", SectionsPage.GetSuccessMessage(), "Error message is different");
            //#endregion


            //#region Enroll Users to make Section Full
            //SectionsPage.SectionTab.ClickSectionTitle;
            //SectionPage.EnrollmentTab.ClickEnrollButton();
            //BatchEnrollUsersModal.ListOfUsers.SelectCheckBox();//Select 3 checkboxes for Users to make Section Full
            //BatchEnrollUsersModal.ClickEnrollButton();
            //StringAssert.AreEqualIgnoringCase("Selected Users were enrolled in the section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
            //Assert.IsTrue(EnrollmentPage.ListofUsersEnrolled);
            #endregion
            //CommonSection.CatalogSearchText('"' + classroomcoursetitle + "TC33255" + '"');
            //SearchResultsPage.CheckSearchRecord(classroomcoursetitle + "TC33255");
            //SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC33255");
            CatalogPage.ClickEditContent();
            ManageClassroomCoursePage.Clicktab("Sections");
            //SectionsPage.ClickCompletedSecton();
            ManageClassroomCoursePage.Sectionsdropdown.OpenDropdown();
            //SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is Completed Section and the Enrollment is Full 
            Assert.IsTrue(ManageClassroomCoursePage.Sectionsdropdown.ManageWaitlist("Manage Waitlist")); //Verify the Manage Waitlist dropdown is NOT displayed
        }

        [Test, Order(19)]
        public void a19_Manage_Waitlist_from_Sections_listing_for_Not_Completed_Section_and_Enrollment_is_Not_Full_33279()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "ManageWaitListNotCompletedNotFull");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            #endregion

            #region Create Sections
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            #endregion


            ManageClassroomCoursePage.Sectionsdropdown.OpenDropdown();
            // SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is NOT Completed Section and the Enrollment is NOT Full 
            Assert.IsFalse(ManageClassroomCoursePage.Sectionsdropdown.ManageWaitlist("Manage Waitlist")); //Verify the Manage Waitlist dropdown is NOT displayed
            Assert.IsFalse(ManageClassroomCoursePage.Sectionsdropdown.ManageWaitlist("Wait list Users")); //Verify the Waitlist Users dropdown is NOT displayed   

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
        [Test, Order(25)]
        public void a25_Manage_Waitlist_from_Sections_listing_for_Not_Completed_Section_and_Enrollment_is_Full_33259()

        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "ManageWaitlistNotCompleted");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));

            #endregion

            #region Create Sections

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            //ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            #endregion

            #region Enroll Users to make Section Full
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.SearchUserandEnrollbatch("userreg");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            #endregion
            ManageClassroomCoursePage.ClickSectionBreadcrumb();
            ManageClassroomCoursePage.Sectionsdropdown.SelectManageoption("Manage Waitlist");
            Assert.IsTrue(EnrollmentPage.EnrollmentTab.WaitlistedSubTab);

        }
        [Test, Order(26)]
        public void a26_Remove_a_gradeable_AICC_Course_from_a_section_34104()
        {
            #region Manage Classroom Course
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "34104");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            //ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.AddContent("Somnath-AICC");
            SectionDetailsPage.ContentTab.DeleteContent();
        //    Assert.IsTrue(SectionContentPage);
        //    Assert.IsTrue(SectionContentPage.List.Type.Online("AICC Course"));// Verify AICC Course associated with that section is displayed
        //    SectionContentPage.List.Type.Online("AICC Course").SelectCheckbox.ClickDeleteButton(); //Select a checkbox of an existing AICC Course and click on Delete button
        //    Assert.IsTrue(ConfirmBox.String "Are you sure you want to remove the selected items?");
        //    ConfirmBox.SelectRemove();
        //    StringAssert.AreEqualIgnoringCase("The item was removed", SectionContentPage.GetSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
        //    Assert.IsTrue(SectionContentPage.List.Type.Online("AICC Course").Removed); //Verify the AICC Course is removed from the Content Tab
        //    SectionContentPage.ClickGradebookTab();
        //    Assert.IsTrue(GradebookPage.AICCCourseColumnRemoved);//Verify the AICC Course column is removed from gradebook
        //    Assert.IsTrue(GradebookPage.ScoreColumn.AICCCourseScoreRemoved);//Verify the AICC Course Score is removed from the Final Score in Gradebook

        //    LoginPage.LoginAs("Learner").WithPassword("").Login();//login with the user that has completed taken the AICC Course
        //    CommonSection.Transcript.AllMyTraining(); //Access the Transcript All My Training page
        //    AllMyTrainingPage.Type.SelectOnline.ClickFilter(); // Search for AICC Course by selecting Online in Type field and click on Filter
        //    Assert.IsTrue(AllMyTrainingPage.List.AICCCourseDisplayed); // Verify the completed AICC course is NOT removed from User's transcript
        //    AllMyTrainingPage.Type.SelectClassroom.ClickFilter(); // Search for Classroom by selecting Classroom in Type field and click on Filter
        //    Assert.IsTrue(AllMyTrainingPage.List.ClassroomCourseDisplayed); // Verify the Classroom Course is displayed
        //    AllMyTrainingPage.List.ClickClassroomCourseLink();
        //    Assert.IsTrue(ContentDetailsPage.AICCCourseRemoved.ScoreUpdated); // Verify the AICC Course no longer count towards score.
        }

        [Test, Order(27)]
        public void a27_Remove_a_gradeable_Scrom12_Course_from_a_section_34094()
        {
            #region Manage Classroom Course
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Success Message Verified");

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "New Section Created");

            //ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            //_test.Log(Status.Info, "Click Manage Enrollment Action");
            // //ContentDetailsPage.ClickEditContent();
            //AdminContentDetailsPage.ClickSectionsTab();
            //// Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            ContentPage.ClickAddContent("");
            Assert.IsTrue(ContentPage.ContentTab.isScormCourse2004tDisplayed(""));
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isScormCourse2004tDisplayed());
            GradebookPage.GradebookTab.ClickContentTab();// Verify Test associated with that section is displayed
            ContentPage.ContentTab.DeleteContent(); //Select a checkbox of an existing Test and click on Delete button
            //Assert.IsTrue(ConfirmBox.String "Are you sure you want to remove the selected items?");
            //ConfirmBox.SelectRemove();
            StringAssert.AreEqualIgnoringCase("The item was removed", Driver.getSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            Assert.False(ContentPage.ContentTab.isScormCourse2004tDisplayed("")); //Verify the Test is removed from the Content Tab
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isScormCourse2004tDisplayed());//Verify the Test column is removed from gradebook
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());
        }
        //Verify the Test Score is removed from the Final Score in Gradebook
        //    CommonSection.Logout();
        //    LoginPage.LoginAs("srlearner").WithPassword("").Login();//login with the user that has completed taken the test
        //    CommonSection.Transcript(); ; //Access the Transcript All My Training page
        //    TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
        //    Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isScormCourse2004tDisplayed("Scorm 2004")); // Verify the completed test is NOT removed from User's transcript
        //    TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
        //    Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
        //    TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
        //    Assert.IsTrue(ContentDetailsPage.isScoreUpdated());
        //}
        [Test, Order(28)]
        public void a28_User_edits_event_in_existing_course_section_34142()
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34142");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("ak instructor");
            _test.Log(Status.Info, "Search Instructor");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
           ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt);

            CommonSection.Logout();
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login(); //Login as Instructor
            CommonSection.Manage.Training();
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules);//Verify Teaching Schedule page is displyed with list of Sections
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34142"); //Click on Expand Row (+) for one of the section (where there are already Files and Notes)
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.SectionScheduleExpanded);
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");//Verify Files and Notes page for the sections is displayed with associated Notes and Files
            String AssignmentTitle = ContentPage.ContentTab.AssignmentTitleText();
            ContentPage.ContentTab.ClickAssignmentTitle();
            ContentPage.ContentTab.UpdateAssignmentAs("Test Updated");
            _test.Log(Status.Info, "Assignment Title updated successfully");
            Assert.IsTrue(ContentPage.ContentTab.NotesTitleUpdated(AssignmentTitle));
            _test.Log(Status.Pass, "Verify Assignment title is updated");
        }
        [Test, Order(29)]
        public void a29_User_Grades_Individual_test_from_section_Gradebook_34141()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            #region create new course and Access The Gradebook From Section Detail Page

            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Pass, "Opened Create Classroom Course Page");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34141");
            _test.Log(Status.Pass, "New Classroom Course Created");

            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectUseWaitlist("");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));

            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");

            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");

           // Assert.IsTrue(Driver.comparePartialString("The selected users were enrolled in the section.", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");

            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");

            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

            Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
            _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

            Assert.IsTrue(GradebookPage.GradebookTab.GradeTest());
            _test.Log(Status.Pass, "User able to grade test");
            #endregion
        }
        [Test, Order(30)]
        public void a30_User_Manages_learners_transcript_notes_through_section_enrollment_34078()
        {
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34078");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("ak instructor");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login(); //Login as Instructor
            CommonSection.Manage.Training();
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules);//Verify Teaching Schedule page is displyed with list of Sections
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34078"); //Click on Expand Row (+) for one of the section (where there are already Files and Notes)
            //Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.SectionScheduleExpanded);
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
           // _test.Log(Status.Pass, "Verify Content tab is display");

            //Assert.IsTrue(ContentPage.SectionContentPageopened());
            //_test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            //Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            //_test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");

            CommonSection.Learner.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            TranscriptPage.MoreInformation.viewPDFFilesandNotes();
            Assert.IsTrue(TranscriptPage.NotesAccorian.NotesDisplay());


        }
        [Test, Order(31)]
        public void a31_User_Bulk_grades_within_gradebook_34073()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34073");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(3);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg");

           // Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");
            Assert.IsTrue(GradebookPage.GradebookTab.BulkGrades());
        }
        [Test, Order(32), Category("AutomatedP1")]
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
        [Test, Order(33), Category("AutomatedP1")]
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


