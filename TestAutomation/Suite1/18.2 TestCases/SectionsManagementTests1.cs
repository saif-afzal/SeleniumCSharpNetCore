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
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1SectionsManagementTests1 : TestBase
    {
        string browserstr = string.Empty;
        public P1SectionsManagementTests1(string browser)
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
        string LevelName = "Level" + Meridian_Common.globalnum;
        
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

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
        [TearDown]
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

       
        [Test, Order(1)]
        public void b01_Manage_Enrollment_for_Classroom_from_details_page_3700()
        {
           // CommonSection.Logout();
          //  LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it and enroll
           
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Enrollment");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            //_test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            _test.Log(Status.Pass, "Verify Enrollment is display");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll");
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg");
            Assert.IsTrue(EnrollmentPage.EnrollmentTab.isuserEnrolled());
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Enrollment");

            #endregion
        }
        [Test, Order(2)]

        public void b02_Make_Section_File_Available_To_Learners_33972()
        //Prerequieite - File is added to the Section
        {
            #region create new course, add section to it and enroll
            
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Section");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
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
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.UploadFile();
            //Assert.IsTrue(SectionDetailsPage.ContentTab.UpLoadFileModalIsClosed); //Verify Upload File modal is closed
            //_test.Log(Status.Pass, "Verify Upload Files Modal is closed");

            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFiles); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing file
            _test.Log(Status.Info, "Click on Availavle To Learner dropdown link ");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("No"));
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("Yes, when learner enrolls"));
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("Yes, when section starts"));
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDropDownOption("Yes, when section ends"));
            _test.Log(Status.Pass, "Varify all dowpdown list text");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("Yes, when learner enrolls")); //Verified the "Yes, when learner enrolls" option is displayed
            _test.Log(Status.Pass, "Verify option text has been updated");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Section");

        }
        [Test, Order(3)]

        public void b03_Make_Section_Note_Available_To_Learners_33974()
        //Prerequisite - Note is added to the Section
        {
            #region Manage Classroom Course
           
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Note");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
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
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFirstNotes);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing Note
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify option text has been updated");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Note");
        }
        [Test, Order(4)]

        public void b04_Make_Section_Assignment_Available_To_Learners_34000()
        //Prerequisite - Assignment is added to the section
        {
            #region Manage Classroom Course
           
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
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
            //Assert.IsTrue(SectionContentPage.List.Type.Files); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            //Assert.IsTrue(SectionContentPage.List.Type.Notes);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt);// Verify Assignment associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("No"));
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            StringAssert.StartsWith("Success", Driver.getSuccessMessage(), "Error message is different"); //Verified the "Yes, when learner enrolls" option is displayed
            _test.Log(Status.Pass, "Verify option text has been updated");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment");

        }
        [Test, Order(5)]

        public void b05_Edit_Assignment_Grading_Settings_When_There_Are_No_Submissions_And_Not_Graded_34015()
        //Prerequisite - Learner has enrolled in a Classroom course
        // Assignment has been made available to Learners and there are no assignment submissions
        {
            #region Manage Classroom Course
            
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment1");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            #endregion

            string GradingCompletionColumnvalue = ContentPage.ContentTab.GradingCompletionColumnValue();
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt);// Verify Assignment associated with that section is displayed and can be viewed by clicking on them
            ContentPage.ContentTab.ClickGradingCompletionColumnForAssignment(); // Click on the Grading column cell in for an existing Assignment
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.GradingScaledisplay());// Verify Edit Assignment Modal is displayed with Grading Scale field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field

            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("3"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.GradingScaleEditAs("Pass/Fail"); //Update the Grading Scale
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("28/08/18"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
            _test.Log(Status.Info, "Insert data into all three fields and Click on Save");
            Assert.IsFalse(ContentPage.ContentTab.EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            _test.Log(Status.Pass, "Verify EditAssignmentModal is Closed");
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(GradingCompletionColumnvalue));// Verify Grading Completion for the Assignment is updated
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment1");
        }


        [Test, Order(6)]

        public void b06_Edit_Assignment_Grading_Settings_When_There_Are_Submissions_And_Not_Graded_34013()
        //Prerequisite - Learner has enrolled in a Classroom course
        // Assignment has been made available to Learners and Learner has submitted the assignment, but not graded
        {
            #region Manage Classroom Course
           
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment2");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            #endregion
            string GradingCompletionColumnvalue = ContentPage.ContentTab.GradingCompletionColumnValue();

            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            _test.Log(Status.Pass, "Verify Added assignment is display");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            ContentPage.ContentTab.ClickGradingCompletionColumnForAssignment();  // Click on the Grading column cell in for an existing Assignment
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.GradingScaledisplay());// Verify Edit Assignment Modal is displayed with Grading Scale field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("3"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.GradingScaleEditAs("Pass/Fail"); //Update the Grading Scale
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("28/09/18"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
            _test.Log(Status.Info, "Insert data into all three fields and Click on Save");
            Assert.IsFalse(ContentPage.ContentTab.EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            _test.Log(Status.Pass, "Verify EditAssignmentModal is Closed");
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(GradingCompletionColumnvalue));// Verify Grading Completion for the Assignment is updated
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment2");                                                                                                  // Verify Grading Completion for the Assignment is updated

        }

        [Test, Order(7)]

        public void b07_Edit_Assignment_Grading_Settings_When_There_Are_Submissions_And_Graded_34014()
        //Prerequisite - Learner has enrolled in a Classroom course
        // Assignment has been made available to Learners and Learner has submitted the assignment, and has been graded
        {
            #region Manage Classroom Course
           
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Assignment3");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Test");
            #endregion
            string GradingCompletionColumnvalue = ContentPage.ContentTab.GradingCompletionColumnValue();
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListAssignemnt); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            _test.Log(Status.Pass, "Verify Added assignment is display");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            ContentPage.ContentTab.ClickGradingCompletionColumnForAssignment(); // Click on the Grading column cell in for an existing Assignment
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with editable Due Date field
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
            Assert.IsFalse(ContentPage.ContentTab.EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            _test.Log(Status.Pass, "Verify EditAssignmentModal is Closed");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Assignment3");
        }
        [Test, Order(8)]
        public void b08_User_views_location_schedule_while_adding_location_to_a_classroom_course_section_33911()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            //_test.Log(Status.Info, "Login as an Admin User");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "location");
            _test.Log(Status.Info, "New Classroom Course Created");
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
            ManageClassroomCoursePage.EnterStartDateAndTime("08/15/2019");
            _test.Log(Status.Info, "Enter Start date");
            ManageClassroomCoursePage.EnterEndDateAndTime("08/15/2019");
            _test.Log(Status.Info, "Enter End date");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click on Waitlist as Yes");
            ManageClassroomCoursePage.ClickSelectLocationButton();
            _test.Log(Status.Info, "Click on Select Location Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectLocationModaldisplay());
            _test.Log(Status.Pass, "Select Location Modal is display");
            ManageClassroomCoursePage.SelectLocationModal.ClickViewSchedule();
            _test.Log(Status.Info, "Click on view schedule");
            Assert.IsTrue(ManageClassroomCoursePage.SelectLocationModal.LocationCalenderModal.ModalisDisplay());
            _test.Log(Status.Pass, "Verify Location Calender modal is display");
            ManageClassroomCoursePage.SelectLocationModal.LocationCalenderModal.CloseModal();
            ManageClassroomCoursePage.SelectLocationModal.CloseModal();
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "location");

        }
        [Test, Order(9)]
        public void b09_User_Adds_Instructor_while_creating_a_classroom_course_34064()
        {
                      
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Instructor");
            _test.Log(Status.Info, "New Classroom Course Created");
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
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Verify Select Instructor modal is display");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("site");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            _test.Log(Status.Pass, "Verify Added instructor display bellow Select Instructor button");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button again");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Verify Select Instructor modal is display");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            _test.Log(Status.Pass, "Verify Added instructor display bellow Select Instructor button");
            ManageClassroomCoursePage.removeinstructors();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            _test.Log(Status.Info, "No Instructor display on screen");
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Instructor");

        }

        [Test, Order(10)]
        public void b10_User_edits_note_from_section_content_tab_33958()
        {
            #region Create classroom, then section adding instructor and note
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33958");
            _test.Log(Status.Info, "New Classroom Course Created");
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
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click on Waitlist as Yes");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            String NotesTitle = "For Test";
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith(NotesTitle);// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC33958");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "TC33958");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(GradebookPage.GradebookTabDisplay());
            GradebookPage.clickContentTab();
            //Assert.IsTrue(ContentPage.SectionContentPageopened());
           // _test.Log(Status.Pass, "Verify Content tab is display");
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");
             NotesTitle = ContentPage.ContentTab.NotesTitleText();
            ContentPage.ContentTab.ClickNotesTitle();
            Assert.IsTrue(ContentPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            ContentPage.ContentTab.AddNoteModal.AddNoteswith("For Test Updated3");
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsTrue(ContentPage.ContentTab.NotesTitleUpdated(NotesTitle));
            _test.Log(Status.Pass, "Verify notes title is updated");

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC33958");

        }
        [Test, Order(11)]
        public void b11_User_Edits_assignments_from_section_content_tab_33959()
        {
            #region Create classroom, then section adding instructor and note
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login as an Admin User");
            
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33959");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click on Waitlist as Yes");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            
            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            ContentPage.ContentTab.AddAssignmentAs("Test");
            _test.Log(Status.Info, "Assignment added successfully");

            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC33959");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "TC33959");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(GradebookPage.GradebookTabDisplay());
            GradebookPage.clickContentTab();
          
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");
            String AssignmentTitle = ContentPage.ContentTab.AssignmentTitleText();
            ContentPage.ContentTab.ClickAssignmentTitle();
//            Assert.IsTrue(ContentPage.ContentTab.AddNoteModaldisplay());
      //      _test.Log(Status.Pass, "Add Note Modal is opened");
            ContentPage.ContentTab.UpdateAssignmentAs("Test Updated");
            _test.Log(Status.Info, "Assignment Title updated successfully");
            Assert.IsTrue(ContentPage.ContentTab.NotesTitleUpdated(AssignmentTitle));
            _test.Log(Status.Pass, "Verify Assignment title is updated");

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC33959");
        }
        [Test, Order(12)]
        public void b12_User_makes_section_content_avialable_to_learners_Learner_has_no_access_34066()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it and enroll
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34066");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Admin user logged out successfully");
            #endregion

            #region Login with instructor and add content to created section.

            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34066");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
           
            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            // ContentPage.ContentTab.AddAssignmentAs("Test");
            ContentPage.ContentTab.AddAssignmentAs("Test" + Meridian_Common.globalnum);//Added by Aafreen

            _test.Log(Status.Info, "Assignment added successfully");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("No"));



            #endregion
            #region Login with a Learner search created classroom course and enroll
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34066" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34066");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC34066"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            Assert.IsFalse(ContentDetailsPage.CheckAssignmentPanel());
            _test.Log(Status.Pass, "Assignment Panel is not display");

            #endregion
        }
        [Test, Order(13)]
        public void b13_User_makes_section_content_avialable_to_learners_Learner_has_Access_when_enrolled_34067()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it and enroll
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34067");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Admin user logged out successfully");
            #endregion

            #region Login with instructor and add content to created section.

            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34067");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            
            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            ContentPage.ContentTab.AddAssignmentAs("Test"+ Meridian_Common.globalnum);
            _test.Log(Status.Info, "Assignment added successfully");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("Yes, when learner enrolls"));


            #endregion
            #region Login with a Learner search created classroom course and enroll
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34067" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34067");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC34067"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            Assert.IsTrue(ContentDetailsPage.CheckAssignmentPanel());
            _test.Log(Status.Pass, "Assignment Panel is not display");

            #endregion
        }
        [Test, Order(14)]  //Depend on 34067

        public void b14_As_Instructor_View_Files_And_Notes_For_Classroom_Sections_33932()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login(); //Login as Instructor
            CommonSection.Manage.Training();
            TrainingPage.TeachingSchedule.ClickViewTeachingSchedule();
            _test.Log(Status.Info, "Click ViewTteaching Schedule button");
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.ListOfSectionSchedules);//Verify Teaching Schedule page is displyed with list of Sections
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "TC34067"); //Click on Expand Row (+) for one of the section (where there are already Files and Notes)
            Assert.IsTrue(InstructorToolsPage.TeachingScheduleTab.SectionScheduleExpanded);
            InstructorToolsPage.TeachingScheduleTab.Enrollment.OptionfromManageGradebook("Manage Content");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(ContentPage.ContentTab.ListFirstNotesdisplay());
            _test.Log(Status.Pass, "Verify Note is display");//Verify Files and Notes page for the sections is displayed with associated Notes and Files
            ContentPage.ContentTab.ClickAssignmentTitle();
            Assert.IsTrue(ContentPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");// Verify the File opens and can be viewed

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
        [Test, Order(16)]
        public void b16_Learner_views_and_complets_course_section_assignment_33967()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region create new course, add section to it, add Assignment and enroll once user
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC33967");
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
          
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
           
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
            _test.Log(Status.Pass, "User Enrolled into select course successfully ");
            SectionDetailsPage.ClickContentTab();
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            ContentPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            ContentPage.ContentTab.AddAssignmentAs("Test");
            _test.Log(Status.Info, "Assignment added successfully");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option ce
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); // Click on the sharing option cell in Available to Learners column for an existing Assignment
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            Assert.IsTrue(ContentPage.ContentTab.AvailabletoLearneris("Yes, when learner enrolls"));
            #endregion

            #region Login with a Learner search created classroom course and enroll
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC33967" + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC33967");

            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle + "TC34067"));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            Assert.IsTrue(ContentDetailsPage.CheckAssignmentPanel());
            _test.Log(Status.Pass, "Assignment Panel is not display");
            Assert.IsTrue(ContentDetailsPage.AssignmentWork.SubmitAssignment("Test", "Des"));
            _test.Log(Status.Pass, "Assignment Panel is not display");

            #endregion

        }
        [Test, Order(17)]
        public void b17_Make_Scorm_12_Course_Gradeable_34046()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            //StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            //CommonSection.Manage.Training();//editted: line was not here.
            TrainingPage.ClickSearchRecord("Classroom Course");
  //          StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }

        [Test, Order(18)]

        public void b18_Make_Scorm_2004_Course_Gradeable_34047()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }

        [Test, Order(19)]

        public void b19_Make_General_Course_Gradeable_34048()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }
        [Test, Order(20)]

        public void b20_User_Make_Test_Gradeable_34071()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }

        [Test, Order(21)]

        public void b21_Make_AICC_Course_Gradeable_34049()

        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Classroom Course");
            StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.filesIsDisplayed); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.notesIsDisplayed);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.assignmentIsDisplayed);// Verify Assignment course associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(ContentPage.ContentTab.onlineIsDisplayed("Scorm 1.2 Course"));// Verify Scorm 1.2 course associated with that section is displayed
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.ItemWeightdisplay()); // Verify Edit Assignment Modal is displayed with Item Weight field
            Assert.IsTrue(ContentPage.ContentTab.EditAssignmentModal.DueDatedisplay());// Verify Edit Assignment Modal is displayed with Due Date field
                                                                                       // Assert.IsTrue.(ContentPage.ContentTab.EditAssignmentModal.DueDateIsRequired); // Verify Due Date field is Required in Edit Assignment Modal
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("Value"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          // Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GradingCompletionColumnUpdated(""));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsTrue(GradebookPage.GradebookTab.isScormCourse12Displayed("Scorm 1.2 Course"));//Verify Scorm 1.2 Course column is added in ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScoreUpdatedAsActualScoreXWeightOfGradebookColumn());//Verify SCORM course grade toward final score is actual score multiplied by weight of gradebook column
            GradebookPage.clickContentTab();
            ContentPage.ContentTab.clickGradingCompletionForScormCourse(); // Click on the Grading column cell in for an existing Scorm 1.2 Course
            ContentPage.ContentTab.EditAssignmentModal.ItemWeightEditAs("0"); //Update the Item Weight
            ContentPage.ContentTab.EditAssignmentModal.DueDateEditAs("Date"); //Update the Due Date
            ContentPage.ContentTab.EditAssignmentModal.ClickSaveButton(); //Click Save button
                                                                          //  Assert.IsTrue(EditAssignmentModal.IsClosed); // Verify the Edit Assignment Modal is closed
            Assert.IsTrue(ContentPage.ContentTab.GetGradingCompletionColumnForScormCourse("Scorm 1.2 Course"));// Verify Grading Completion for the Scorm 1.2 Course is updated
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.False(GradebookPage.GradebookTab.isScormCourse12Displayed(""));//Verify Scorm 1.2 Course column is removed from ManageGradeBook page
            Assert.IsTrue(GradebookPage.GradebookTab.isScore(""));//Verify the Score Column is updated by removing the weight of Scorm Course 
        }
        [Test, Order(22)]

        public void b22_Remove_Gradeable_Test_From_A_Section_34054()
        // Prequisite:  As one Learner view and complete the test that is associated with course section
        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.isTestDisplayed(""));
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isTestDisplayed());
            GradebookPage.GradebookTab.ClickContentTab();// Verify Test associated with that section is displayed
            ContentPage.ContentTab.DeleteContent(); //Select a checkbox of an existing Test and click on Delete button
            //Assert.IsTrue(ConfirmBox.String "Are you sure you want to remove the selected items?");
            //ConfirmBox.SelectRemove();
            StringAssert.AreEqualIgnoringCase("The item was removed", Driver.getSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            Assert.False(ContentPage.ContentTab.isTestDisplayed("")); //Verify the Test is removed from the Content Tab
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isTestDisplayed());//Verify the Test column is removed from gradebook
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());//Verify the Test Score is removed from the Final Score in Gradebook
            CommonSection.Logout();
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();//login with the user that has completed taken the test
            CommonSection.Transcript(); ; //Access the Transcript All My Training page
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isTestDisplayed("Test")); // Verify the completed test is NOT removed from User's transcript
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
            TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
            Assert.IsTrue(ContentDetailsPage.isScoreUpdated()); // Verify the test no longer count towards score.
        }
        [Test, Order(23)]

        public void b23_Remove_Gradeable_General_Course_From_A_Section_34056()
        // Prequisite:  As one Learner view and complete the General Course that is associated with course section


        // Prequisite:  As one Learner view and complete the test that is associated with course section
        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
            Assert.IsTrue(ContentPage.ContentTab.isGeneralCourseDisplayed(""));
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isGeneralCoursetDisplayed());
            GradebookPage.GradebookTab.ClickContentTab();// Verify Test associated with that section is displayed
            ContentPage.ContentTab.DeleteContent(); //Select a checkbox of an existing Test and click on Delete button
            StringAssert.AreEqualIgnoringCase("The item was removed", Driver.getSuccessMessage(), "Error message is different");// Verify the message "The item was removed" is displayed
            Assert.False(ContentPage.ContentTab.isGeneralCourseDisplayed("")); //Verify the Test is removed from the Content Tab
            ContentPage.ContentTab.ClickGradeBookTab();
            Assert.IsFalse(GradebookPage.GradebookTab.isGeneralCoursetDisplayed());//Verify the Test column is removed from gradebook
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());//Verify the Test Score is removed from the Final Score in Gradebook
            CommonSection.Logout();
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();//login with the user that has completed taken the test
            CommonSection.Transcript(); ; //Access the Transcript All My Training page
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isGeneralCOurseDisplayed("GC")); // Verify the completed test is NOT removed from User's transcript
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
            TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
            Assert.IsTrue(ContentDetailsPage.isScoreUpdated()); // Verify the test no longer count towards score.
        }

        [Test, Order(24)]

        public void b24_Remove_Gradeable_Scorm_2004_Course_From_A_Section_34075()
        // Prequisite:  As one Learner view and complete the Scorm 2004 course that is associated with course section

        // Prequisite:  As one Learner view and complete the test that is associated with course section
        {
            #region Manage Classroom Course
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Somnath-Classroom");
            StringAssert.AreEqualIgnoringCase("Somnath-Classroom", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
            AdminContentDetailsPage.ClickSectionsTab();
            // Assert.IsTrue(SectionsPage.ListofSections);
            #endregion
            SectionsPage.ListofSections.ClickSectionTitle();
            SectionDetailsPage.ClickContentTab();
            // Assert.IsTrue(SectionContentPage);
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
            Assert.False(GradebookPage.GradebookTab.isScoreDisplayed());//Verify the Test Score is removed from the Final Score in Gradebook
            CommonSection.Logout();
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();//login with the user that has completed taken the test
            CommonSection.Transcript(); ; //Access the Transcript All My Training page
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Test by selecting Test in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isScormCourse2004tDisplayed("Scorm 2004")); // Verify the completed test is NOT removed from User's transcript
            TranscriptPage.AllMyTrainingPage.SearchRecord("Type", "Status", "FromDate", "ToDate"); // Search for Classroom by selecting Classroom in Type field and click on Filter
            Assert.IsTrue(TranscriptPage.AllMyTrainingPage.isClassroomCourseDisplayed("ClassroomCOurse")); // Verify the Classroom Course is displayed
            TranscriptPage.AllMyTrainingPage.ClickClassroomCourseLink("ClassroomCourse");
            Assert.IsTrue(ContentDetailsPage.isScoreUpdated()); // Verify the test no longer count towards score.
        }

        [Test, Order(25)]

        public void b25_Learner_Views_Section_File_34004()   //Depend on 33918
        //Prerequisite - Learner has enrolled in a Classroom course
        // File has been made available to Learners

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC34004");
            _test.Log(Status.Info, "New Classroom Course Created");
            
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.SelectUploadFilesFromAdddContentdropdown("Upload Files");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.UploadFile();
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFiles); // Verify the Files associated with that section is displayed and can be viewed by clicking on them
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing file
            _test.Log(Status.Info, "Click on Availavle To Learner dropdown link ");
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login(); //Login as regular user (Learner)
            _test.Log(Status.Info, "Login with lerner");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC34004" + '"');
            _test.Log(Status.Info, "Search" + classroomcoursetitle + "TC34004" + "from Cataloh Search");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "TC34004");
            _test.Log(Status.Info, "Click on Searched catalog title");
            // HomePage.CurrentTrainingSection.ClickClassroomCourseTitle("Classroom Course");//Click on the Classroom Course Title
            Assert.IsTrue(ContentDetailsPage.MatchCatalogName(classroomcoursetitle + "TC34004")); // Verify the Content Details Page is displayed
            _test.Log(Status.Pass, "Verify searched catalog title in Content details page");
            ContentDetailsPage.ClickEnrollButton();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsFiledisplayed()); //Verify the Files Associated to the Section is displayed
            _test.Log(Status.Pass, "Verify attached file/notes display into Course Material area");
            ContentDetailsPage.CourseMaterials.ClicktoOpenFile(); //Click on Open for a File
            _test.Log(Status.Info, "Click Open button to open Attached file");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.FileOpened()); //Verify the File is opened
            _test.Log(Status.Pass, "Verify file is opend");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.FileStatus("Open"));
            _test.Log(Status.Pass, "Verify attched file/notes status is Open");
        }

        [Test, Order(26)]

        public void b26_Learner_Views_Section_Note_34009()
        ////Prerequisite - Learner has enrolled in a Classroom course
        //// Note has been made available to Learners

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Manage Classroom Course

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Note");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Clcik on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            ManageClassroomCoursePage.CreateSection.SectionEndTime("");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
           
            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            SectionDetailsPage.ContentTab.AddContentdropdownSelect("Add Note");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            Assert.IsTrue(SectionDetailsPage.ContentTab.AddNoteModaldisplay());
            _test.Log(Status.Pass, "Add Note Modal is opened");
            SectionDetailsPage.ContentTab.AddNoteModal.AddNoteswith("For Test");// Add a Note in Note field and click on Add
            _test.Log(Status.Info, "Filled note and click on Add");
            Assert.IsFalse(SectionDetailsPage.ContentTab.AddNoteModalIsClosed);// Verify the Add Note Modal is closed
            _test.Log(Status.Pass, "Verify Add Note Modal is closed");
            Assert.IsTrue(SectionDetailsPage.ContentTab.ListFirstNotes);// Verify Notes associated with that section is displayed and can be viewed by clicking on them
            Assert.IsTrue(SectionDetailsPage.ContentTab.AvailableToLearnersColumn.CellDisplay("No"));
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.ClickFileCell(); // Click on the sharing option cell in Available to Learners column for an existing Note
            SectionDetailsPage.ContentTab.AvailableToLearnersColumn.SelectOption("Yes, when learner enrolls"); //Select Option "Yes, when learner enrolls"
            _test.Log(Status.Info, "Make Yes, when learner enrolls from dropdown");
            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs("somnath1_learner").WithPassword("").Login(); //Login as regular user (Learner)
            _test.Log(Status.Info, "Login with lerner");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "Note" + '"');//Click on the Classroom Course Title
            _test.Log(Status.Info, "Search" + classroomcoursetitle + "Note" + "from Cataloh Search");
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle + "Note"); // Verify the Content Details Page is displayed
            _test.Log(Status.Info, "Click on Searched catalog title");
            Assert.IsTrue(ContentDetailsPage.MatchCatalogName(classroomcoursetitle + "Note")); // Verify the Content Details Page is displayed
            _test.Log(Status.Pass, "Verify searched catalog title in Content details page");
            ContentDetailsPage.ClickEnrollButton();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsNoteDisplayed()); //Verify the Notes Associated to the Section is displayed
            _test.Log(Status.Pass, "Verify attached file/notes display into Course Material area");
            ContentDetailsPage.CourseMaterials.ClickToOpenNote(); //Click on Open for a Note
            _test.Log(Status.Info, "Click Open button to open Attached file");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsNoteModaldisplay()); //Verify the Note modal is opened
            _test.Log(Status.Pass, "Verify Notes Modal is opend");
            ContentDetailsPage.CourseMaterials.NoteModal.ClickClose(); //Close the Note
            _test.Log(Status.Info, "Click close button in note modal");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.IsNoteModalIsClosed()); // Verify the Note modal is Closed
            _test.Log(Status.Pass, "Verify Note modal is closed");
            Assert.IsTrue(ContentDetailsPage.CourseMaterials.FileStatus("Open"));
            _test.Log(Status.Pass, "Verify attched file/notes status is Open");
        }

        
        

    }

 
}


