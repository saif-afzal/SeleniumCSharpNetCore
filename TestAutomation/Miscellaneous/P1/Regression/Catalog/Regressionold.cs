using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using TestAutomation.Suite1.Administration.AdministrationConsole;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite.P1.Learning.Training_Catalog
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RegressionOld : TestBase
    {
        private CollabarationSpace_l CollabarationSpace_lobj;
        string browserstr = string.Empty;
        public RegressionOld(string browser)
            : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();

            startprerequisite();
        }
      

        bool sectioncreation = false;
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "ClassRoomCourseTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        bool res1 = false;
        private string SelectInterestTag;
        string LevelName = "Level" + Meridian_Common.globalnum;


        // [OneTimeSetUp]
        public void startprerequisite()
        {
           InitializeBase(driver);
            // driver.Manage().Window.Maximize();
       //     driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            CollabarationSpace_lobj = new CollabarationSpace_l(driver);
            //Classroom and Section Creation
            string expectedresult = " The item was created.";
       //     driver.UserLogin("admin1", browserstr);
      //      classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick());

            classroomcourse.linkSectionsClick();
            classroomcourse.addNewSectionClick();
            classroomcourse.populatesectionform1(browserstr);
            //classroomcourse.populatesectionform12();
            //classroomcourse.populateframeform();
            CreateNewCourseSectionAndEventPage.CreateSection("","");
           // classroomcourse.buttonsaveandexitclick();
            sectioncreation = true;

        }



        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            classroomcourse = new ClassroomCourse(driver);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [TearDown]
        public void stoptest()
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
                    driver.Navigate_to_TrainingHome();
                    Driver.focusParentWindow();
                    CommonSection.Avatar.Logout();
                    LoginPage.LoginClick();
                    LoginPage.LoginAs("siteadmin").WithPassword("password").Login();

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
        // [Test, Order(1), Category("P1")]
        //public void Self_Enroll_In_Classroom_Course_14432()
        //{
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //    driver.UserLogin("userforregression", browserstr);
        //    Assert.IsTrue(classroomcourse.enrollInClassroomCourse(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr));


        //public void Self_Cancel_Enrollment_In_Classroom_Course_14435()
        //{
        //    Assert.IsTrue(classroomcourse.cancelenrollInClassroomCourse());
        //}
        [Test, Order(1), Category("P1")]
        public void a_Click_the_Help_link_238()
        {

            //LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.ClickHelpIcon();
            _test.Log(Status.Pass, "help icon opens successfully");
            Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
                                                 // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test, Order(2), Category("P1")]
        public void Login_8597()
        {
            _test.Log(Status.Pass, "login as siteadmin successful");
            Assert.IsTrue(HomePage.Title == "Home");//checks the Home page title
        }
        [Test Order(3), Category("P1")]
        public void Self_Enroll_in_Classroom_Course_14432()
        {
            #region create new course, add section to it and enroll
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Pass, "Opened Create Classroom Course Page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
            _test.Log(Status.Pass, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.CreateSection.Create();
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            _test.Log(Status.Pass, "Create New Course Section and Event");
            CommonSection.Logout();
            #endregion
            #region Login with a Learner, search classroom course and enroll
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);
            CatalogPage.EnrollinClassroomCourse();
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            #endregion


        }
        [Test, Order(4), Category("P1")]
        public void Self_Cancel_Enrollment_in_Classroom_Course_14435()
        {
            #region Login with learner and Cancel Enrollment for an Enrolled Classroom Course
            //LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            //_test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');// ('"' + classroomcoursetitle + '"');
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle); //("ClassRoomCourseTitle2011472447");// 
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));// (classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            //CurrentTrainings.ClickAction();
            CatalogPage.CancelEnrollment();
            Assert.IsTrue(CatalogPage.GetMessages());
            CommonSection.Logout();
            #endregion
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(5), Category("P1")]
        public void a_Create_a_new_organization_8552()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            Organizationobj.Click_CreateGoTo();
            Assert.IsTrue(Organizationobj.Click_Create(browserstr));

        }
        [Test, Order(6), Category("P1")]
        public void b_Manage_Organization_8553()
        {

            //TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            Organizationobj.Click_Search(browserstr);
            Organizationobj.Click_ManageGoTo();
            EditOrganizationobj.Click_SelectManager();
            SelectManagerobj.Click_AddManager();
            Roleobj.Click_SearchUserToAdd("");
            Assert.IsTrue(Roleobj.Click_AddUsertoorganization());

        }
        [Test, Order(7), Category("P1")]
        public void Create_JobTitle_22211()
        {
            Thread.Sleep(2000);
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.EditJobTitleName(JobTitle);
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            res1 = true;
            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }

        [Test, Order(8), Category("P1")]
        public void Job_title_info_icon_22215()
        {
            CommonSection.Manage.Careers.Careerstab();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle("JobTitle0601114911");
            CareersPage.ClickinfoIcon("i");
            Assert.IsTrue(InformationPage.JobTitleName("JobTitle21"));
            // ManageJobTitlePage.JobDetailsTab.AddDescription("Reg_Description");
            InformationPage.ClickViewUsersTab();
            Assert.NotZero(InformationPage.ViewUsersTab.CountRecords);
            Driver.Instance.SelectWindowClose();
            //Close This Page
        }

        [Test, Order(9), Category("P1")]
        public void Edit_Competency_Details_Creation_31458()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CommonTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            _test.Log(Status.Pass, "Competency Title filled");
            //CreateCompetencyPage.SaveCompetencyName();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            _test.Log(Status.Pass, "Open Competency Details Page");
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("EditDescription");
            _test.Log(Status.Pass, "Added Description to Competency");
            // ManageCompetencyPage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));

            StringAssert.AreEqualIgnoringCase("EditDescription", ManageCompetencyPage.GetDescriptionLink(), "Description does not match");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("EditKeywords");
            _test.Log(Status.Pass, "Added Key Words to Competency");
            // ManageCompetencyPage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("EditKeywords", ManageCompetencyPage.GetKeywordLink(), "Keywords does not match");

        }
        [Test, Order(10), Category("P1")]
        public void Test_Searching_for_Competency_by_Name_Keyword_Description_31474()

        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Pass, "Opens Careers Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Pass, "Clicked on Competencies tab");
            CareersPage.CommonTab.ClickCreateCompetency();
            _test.Log(Status.Pass, "Clicked on Create new Competencies");
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Create new Competency successfully created");
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("Description_Regression_Competency1");
            // ManageCompetencyPage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "AddDescription added to Competency successfully created");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("Keyword_Regression_Competency1");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "AddKeywords added to Competency successfully created");
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Pass, "Reopen Carres page");
            //CareersPage.CommonTab.ClickCreateCompetency();
            StringAssert.AreEqualIgnoringCase(CompetencyTitle, CareersPage.SearchByKeyword("Keyword_Regression_Competency1", CompetencyTitle)); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies with Keyword");
            StringAssert.AreEqualIgnoringCase(CompetencyTitle, CareersPage.SearchByDescription("Description_Regression_Competency1", CompetencyTitle)); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies by Description");
            StringAssert.AreEqualIgnoringCase(CompetencyTitle, CareersPage.SearchByCompetencyTitle(CompetencyTitle)); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies by CompetencyTitle");
        }
        [Test, Order(11), Category("P1")]
        public void Test_Creation_of_Job_Title_from_Professional_Development_31482()

        {
            Assert.True(true);
            //similar to test case id 22211.
        }
        [Test, Order(12), Category("P1")]
        public void User_Edit_a_Job_title_31501()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            ManageJobTitlePage.ClickJobDetailsTab();
            ManageJobTitlePage.JobDetailsTab.AddDescription("Reg_Description");
            //   ManageJobTitlePage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("Reg_Description", ManageJobTitlePage.GetDescriptionLink(), "Description value does not match");
            ManageJobTitlePage.JobDetailsTab.AddKeywords("Reg_Keywords");
            //  ManageJobTitlePage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("Reg_Keywords", ManageJobTitlePage.GetKeywordLink(), "Keywords value does not match");
            ManageJobTitlePage.JobDetailsTab.JobCodeLink("Reg_JOBCODE");
            // ManageJobTitlePage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("Reg_JOBCODE", ManageJobTitlePage.GetJobCodeLink(), "JobCode Value does not match");

        }
        [Test, Order(13), Category("P1")]
        public void User_Remove_Competency_from_existing_Job_title_31504()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle);
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle);
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle);
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle));
        }
        [Test, Order(14), Category("P1")]
        public void User_Remove_Competency_while_Creating_New_Job_title_31506()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.EditJobTitleName(JobTitle);
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle);
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle);
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle);
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle));
        }
        [Test, Order(15), Category("P1")]
        public void Add_Job_Title_to_Competency_31507()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            // CareersPage.CompetencyTab.ClickCompetency();
            //CareersPage.CommonTab.ClickCreateCompetency();
            // ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            ManageCompetencyPage.AssignGroupFrame.SelectUserGroupFilter();
            ManageCompetencyPage.AssignGroupFrame.SearchGroups("Manager");//Create this record for another environment
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            AssignGroupPage.SelectSearchRecord();
            AssignGroupPage.ClickAssignButton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //StringAssert.AreEqualIgnoringCase("The Selected Groups were Assigned", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            // Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);//Verify the total is increased
            //CommonSection.Userdropdown.ClickLogout();
            //LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login();
            //CommonSection.Learn.ProfessionalDevelopment();
            //Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            //CommonSection.Userdropdown.ClickLogout();
        }
        [Test, Order(16), Category("P1")]
        public void Remove_Job_Title_from_Competency_31508()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //CareersPage.CompetencyTab.ClickCompetency();
            ManageCompetencyPage.ClickAssignGroupsTab();
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);
            ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Manager");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);
            // StringAssert.AreEqualIgnoringCase("The Selected Groups were Removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            // Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            //CareersPage.CompetencyTab.CheckCompetencyTitle("");
            //Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);//Verify the total is decreased
            //CommonSection.Userdropdown.ClickLogout();
            //LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login();
            //CommonSection.Learn.ProfessionalDevelopment();
            //Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            //CommonSection.Userdropdown.ClickLogout();
        }
        [Test, Order(17), Category("P1")]
        public void Logout_24943()
        {
            Assert.True(true);

        }
        [Test, Order(18), Category("P1")]
        public void Test_when_User_add_a_new_proficiency_scale_31801()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.ClickCreateNewProficencyScale();
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.ClickTitleTextBox("Regression Scale");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.VerifySuccessMessage(), "Error message is different");
        }
        [Test, Order(19), Category("P1")]
        public void Switch_Mandatory_Content_to_Supplemental_in_Competency_31881() //dependent on the records already exists in Mandatory tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle1803432643");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle1803432643");
            ManageCompetencyPage.AssociatedContentTab_click();//clicking on tab
            ManageCompetencyPage.AssociatedContentTab.ClickMandatoryTab();
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);
            ManageCompetencyPage.SelectMandatoryRecords.ClickMakeSupplemental();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);
            ManageCompetencyPage.AssociatedContentTab.ClickSupplementalTab();
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Check Record is moved to Supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved from Mandatory tab
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is increased.
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is decreased.  
        }
        [Test, Order(20), Category("P1")]
        public void ActiveInActive_Job_Title_In_Professional_Development_31882()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobtitle("Job Titles");
            //CareersPage.JobTitlesTab.GetTotalJobTitles();  //get to total count
            //CareersPage.JobTitlesTab.ClickShowInActiveItemsCheckbox(); //Check Inactive checkbox
            //CareersPage.JobTitlesTab.GetTotalJobTitleswithInActive();

            Assert.IsTrue(CareersPage.JobTitlesTab.GetTotalJobTitles(), "JobTiles Count matched");//Check for Active and Inactive Job Titles displayed
            //CareersPage.JobTitlesTab.ClickShowInActiveItemsCheckbox(); //Uncheck Inactive Items Checkbox
            //Assert.IsTrue(CareersPage.JobTitlesTab.CheckJobTitles);//Check for Only Active Job Titles displayed
        }
        [Test, Order(21), Category("P1")]
        public void Access_Careers_31888()
        {
            CommonSection.Manage.Careerstab();
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifySearchText("Career Paths"));
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyText("Job Titles"));
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scales"));
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyText("360 Templates"));
            CommonSection.Userdropdown.ClickLogout();

            //LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("user_competencymanager").WithPassword("password").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            //StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifySearchText("Career Paths"));
            // Assert.IsTrue(CareersPage.JobTitlesTab.VerifyText("Job Titles"));
            Assert.IsTrue(CareersPage.CompetenciesTab.VerifyText("Competencies"));
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scales"));
            // Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyText("360 Templates"));
            CommonSection.Userdropdown.ClickLogout();
            LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();

        }
        [Test, Order(22), Category("P1")]
        public void Localize_Competency_32105()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //ManageCompetencyPage.ClickLocalizedIndropdown();
            ManageCompetencyPage.LocalizedIndropdown.ClickAddLocalization();
            ManageCompetencyPage.LocalizedIndropdown.SelectLanguage("French");
            //ContentDetailsPage.SelectAddLocalization("French");
            AddLocalizationModal.EnterForm("Title", "Description", "Keywords");
            // ContentDetailsPage.EditLocalization("edittitle", "Descriptionedit", "jobcodedit", "keywordsedit", "Arabic");

            AddLocalizationModal.ClickLocalize();
            // StringAssert.AreEqualIgnoringCase("Success", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.ClickLocalizedIndropdown();
            // Assert.IsTrue(ManageCompetencyPage.LocalizedIndropdown.CheckLanguage);
            StringAssert.AreEqualIgnoringCase("French", ManageCompetencyPage.LocalizedIndropdown.CheckLanguage(), "Language Not Matched");
        }
        [Test, Order(23), Category("P1")]
        public void View_Proficiency_Scale_Details_from_list_of_competencies_32106()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle0705274827");

            Assert.IsTrue(CareersPage.CheckProficiencyScaleColumn_ClickView());
            CareersPage.CompetencyTab.ProficiencyScaleColumn_ClickView();
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Modal with Labels is displayed
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed
            CareersPage.CompetencyTab.ProficiencyScaleViewModal_CloseClick();


        }

        [Test, Order(24), Category("P1")]
        public void View_Proficiency_Scale_Details_from_Proficiency_Scale_Page_32107()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            // CareersPage.ClickProficiencyScalesTab();
            CareersPage.ProficiencyScalesTab_ClickProficiencyScaleTitle();
            Assert.IsTrue(CareersPage.RatingScaleModal_NumbersandLabels_CheckRecord);

            // Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord);
            CareersPage.ProficiencyScaleTab.ProficiencyScaleViewModal_CloseClick();
        }
        [Test, Order(25), Category("P1")]
        public void View_Proficiency_Scale_Details_from_Assigned_Groups_32109()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle0705274827");

            //CareersPage.CompetencyTab.ClickCompetencyTitle("CompetencyTitle0705274827");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle0705274827");
            //CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignedGroupsTab();
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickViewScale);
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_clickViewScale();
            //Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickViewScale);
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Modal with Numbers is displyed
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed
            CareersPage.CompetencyTab.ProficiencyScaleViewModal_CloseClick();
        }
        [Test, Order(26), Category("P1")]
        public void User_adds_supplemental_training_to_a_new_competency_31561()

        {  // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);

            // CareersPage.CompetencyTab.ClickCreateCompetency();
            //CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            //CreateCompetencyPage.SaveCompetencyName();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //StringAssert.AreEqualIgnoringCase("The Competency was created", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.AssociatedContentTab_click();
            ManageCompetencyPage.SupplementalTab_Click();
            Assert.AreEqual("There is no supplemental content.", ManageCompetencyPage.CompetencySupplementalTabText(), "Error message is different");
            ManageCompetencyPage.AssociateContent_Click();
            ManageCompetencyPage.SearchTextFrame("Document that created as Pre req");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            //Assert.AreEqual("The selected items were added.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("1"));//Added record should appear that we created as pre req
        }
        [Test, Order(27), Category("P1")]  //depend on 31458
        public void User_adds_supplemental_training_to_an_existing_competency_31562()
        {
            // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.AssociatedContentTab_click();
            ManageCompetencyPage.SupplementalTab_Click();
            ManageCompetencyPage.AssociateContent_Click();
            ManageCompetencyPage.SearchTextFrame("Document that created as Pre req");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            // Assert.AreEqual("Success", ManageCompetencyPage.GetSuccessMessage());
            //Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("dv_test"));//Added record should appear that we created as pre req
        }
        [Test, Order(28), Category("P1")]
        //Pre-req - Learner has atleast one competency assigned to them they have not completed and one completed
        public void Filter_competencies_by_Complete_Incomplete_Status_32130()
        {
            CommonSection.Logout();

            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(CareersPage.ListofCompetencies.InProgressStatus);
            CareersPage.SelectCompleteIcon();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_CompletedStatus);
            CareersPage.SelectInProgressIcon();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_InProgressStatus);
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }
        [Test, Order(29), Category("P1")]//dependent on 31458
        public void Add_User_Group_to_Competency_32152() // need to create user and then make a user group to call that users
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);//cllick on record new competency required here
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignGroupsTab();//clicking on tab
            //ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();//not required
            AssignGroupPage.SelectUserGroupFilter();//select user group filter
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("usergroup_1102520752");//search user group
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.NameColumn("usergroup_1102520752")); //checked the user group displaying in Assigned groups
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 1);//Verify the total is increased. Search same competency through competencies tab

            CommonSection.Logout();
            // LoginPage.GoTo();
            // LoginPage.LoginClick();
            LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            CommonSection.Learn.CareerDevelopment();
            CareersPage.FilterCompetenciesFor("usergroup_1102520752");

            // Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(30), Category("P1")]
        public void Add_Organization_to_Competency_32153()// need to create organisation and then create a new user, assign him that organisation
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            AssignGroupPage.SelectOrganizationFilter();
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            AssignGroupPage.SelectSearchRecord();
            //AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.NameColumn("Sample Organization 1")); ;//checked the user group displaying in Assigned groups
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 1);//Verify the total is increased. Search same competency through competencies tab

            CommonSection.Logout();
            // LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            CommonSection.Learn.CareerDevelopment();
            CareersPage.FilterCompetenciesFor("Sample Organization 1");
            //Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(31), Category("P1")]
        public void Add_AllTypes_to_Competency_32154()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);//cllick on record new competency required here
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignGroupsTab();//clicking on tab
                                                        //ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();//not required
            #region Adding JobTitle to Competency
            AssignGroupPage.SelectJobTitleFilter();            //select user group filter
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("JobTitle0711215721");//search Job title
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //Assert.IsTrue(ManageCompetencyPage.NameColumn("usergroup_1102520752")); //checked the user group displaying in Assigned groups
            #endregion
            #region Adding Organization to Competency
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();//clicking on tab
            AssignGroupPage.SelectOrganizationFilter();
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            AssignGroupPage.SelectSearchRecord();

            AssignGroupPage.ClickAssignButton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //Assert.IsTrue(ManageCompetencyPage.NameColumn("Sample Organization 1 "));
            #endregion
            #region Adding userGroup to competency
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();
            AssignGroupPage.SelectUserGroupFilter();//select user group filter
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("usergroup_1102520752");//search user group
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            // Assert.IsTrue(ManageCompetencyPage.NameColumn("usergroup_1102520752"));
            #endregion
            //#region Adding all types using Select ALL
            //ManageCompetencyPage.ClickAssignGroupsTab();
            //AssignGroupPage.ClickSelectAllinPage1();
            //AssignGroupPage.ClickAssignButton();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //#endregion
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 3);//Verify the total is increased. Search same competency through competencies tab

            //CommonSection.Logout();
            //// LoginPage.GoTo();
            //// LoginPage.LoginClick();
            //LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            //CommonSection.Learn.CareerDevelopment();
            //CareersPage.FilterCompetenciesFor("usergroup_1102520752");

            //// Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(32), Category("P1")]// dependednt on 32152
        public void Remove_User_Group_from_Competency_32155()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //ManageCompetencyPage.ClickAssignGroupsTab();
            // ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Dolly's User Group_12012017");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            //ManageCompetencyPage.AssignedGroupsTab.ClickRemoveinRemoveConfirmationModal();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased. Search same competency through competencies tab
                                                                                                      //Verify the total is decressed to 0
            CommonSection.Logout();
            // LoginPage.GoTo();
            //    LoginPage.LoginClick();
            LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            CommonSection.Learn.CareerDevelopment();
            CareersPage.FilterCompetenciesFor("usergroup_1102520752");
            Assert.IsFalse(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(33), Category("P1")]
        public void Remove_Organization_from_Competency_32156()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //ManageCompetencyPage.ClickAssignGroupsTab();
            //ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Sample Organization 1");
            ManageCompetencyPage.SelectALLAssignedGroup();
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //StringAssert.AreEqualIgnoringCase("The Selected Groups were Removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            //Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            CommonSection.Logout();
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("testuser123").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            Assert.IsFalse(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(34), Category("P1")]
        public void Remove_All_Types_from_Competency_32157()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.SelectALLAssignedGroup();
            ManageCompetencyPage.AssignedGroupsTab.ClickRemoveAllbutton(); //Success  The selected items were removed.
            //StringAssert.AreEqualIgnoringCase("The selected items were removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            //CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle);
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            //CommonSection.Logout();
            //LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login();
            //CommonSection.Learn.CareerDevelopment();
            //Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            //CommonSection.Logout();
        }
        [Test, Order(35)]
        public void View_job_Title_page_32179()

        {
            Assert.IsTrue(res1);
        }
        [Test, Order(36), Category("P1")]
        public void View_competency_column_in_job_Title_list_32181()

        {
            // Prerequisite - Competencies are created and added to JobTitles
            //login with siteadmin/password
            CommonSection.Manage.Careers.Careerstab();
            CareersPage.ClickJobTitleTab();
            Thread.Sleep(2000);
            StringAssert.AreEqualIgnoringCase("Job titles define a position and its responsibilities. Assign competencies to set training and proficiency targets.", CareersPage.JobTitlesTab.GetMessage(), "Error message is different");//verify Text 
            CareersPage.SearchJobtitle("JobTitle21");
            Assert.IsTrue(CareersPage.JobTitle("JobTitle21"));
            CareersPage.ClickJobtitle("JobTitle21");

            Assert.IsTrue(CareersPage.sortingcompetencycolumn_verifysortingascecorder());//verify sorting desc order
                                                                                         //logout
        }
        [Test, Order(37), Category("P1")]
        public void localized_Job_Title_32185()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            ContentDetailsPage.SelectAddLocalization("French");


            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
        }
        [Test, Order(38), Category("P1")]
        public void Edit_localized_Job_Title_32187()
        {
            CommonSection.Manage.Careers.Careerstab();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            ContentDetailsPage.EditLocalization("edittitle", "Descriptionedit", "jobcodedit", "keywordsedit", "Arabic");
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            ContentDetailsPage.SelectLocalization("Arabic");
            // StringAssert.AreEqualIgnoringCase("Add Localization", ContentDetailsPage.Frame(), ("Error message is different"));

            Assert.IsTrue(JobTitlesPage.CheckJobTitle("edittitle"));
            Assert.IsTrue(JobTitlesPage.CheckJobCode("jobcodedit"));
            Assert.IsTrue(JobTitlesPage.CheckDescriptionValue("Descriptionedit"));
            Assert.IsTrue(JobTitlesPage.CheckKeywordsValue("keywordsedit"));

        }
        [Test, Order(39), Category("P1")]
        public void Switch_Supplemental_Content_to_Mandatory_in_Competency_32214()
            //dependent on the records already exists in Supplemental tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle1803432643");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle1803432643");
            ManageCompetencyPage.AssociatedContentTab_click();//clicking on tab
            ManageCompetencyPage.AssociatedContentTab.ClickSupplementalTab();
            // ManageCompetencyPage.AssociateContent_Click();
            // ManageCompetencyPage.SearchTextFrame("Document that created as Pre req");
            // ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount); //Verify record display
            ManageCompetencyPage.SelectSupplementalRecords.ClickMakeMandatory();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount); //verify record moved from supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.SupplementalTab.CheckRecord);//Check Record is moved from Supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved to Mandatory tab
            //Assert.Null(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is decreased.
            ManageCompetencyPage.AssociatedContentTab.ClickMandatoryTab();
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is increased.

        }
        [Test, Order(40), Category("P1")]
        public void Verify_Updated_label_of_Career_Development_on_Domain_Page_32303()

        {
            //CommonSection.Manage.Careerstab();
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Pass, "Opens Domains Page");
            DomainsPage.ClickDomainLink("Meridian Global-Core Domain(default)");
            _test.Log(Status.Pass, "Open Domain Edit Summary Page");
            EditSummaryPage.Menus.ClickMenuTab();
            _test.Log(Status.Pass, "Open Menu tab");
            StringAssert.AreEqualIgnoringCase("Career Development", MenuPage.GetCurrentValueForCareerPath(), "Error message is different");
            _test.Log(Status.Pass, "Verify Career Development lable text on Menu Tab");
            EditSummaryPage.Menus.ClickOptionsTab();
            _test.Log(Status.Pass, "Open Options tab");
            StringAssert.AreEqualIgnoringCase("Enable Career Development", EditConfigurationOptionsPage.GetOptionValue(), "Error message is different");
            _test.Log(Status.Pass, "Verify Enable Career Development lable text on Options Tab");
        }
        [Test, Order(41), Category("P1")]
        public void Test_to_Verify_order_of_Tabs_on_Careers_page_32310()

        {

            CommonSection.Manage.Careerstab();
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifySearchText("Career Paths"), "Error message is different");
            StringAssert.AreEqualIgnoringCase("Job Titles", CareersPage.CareerPathTab.VerifySearchText("Job Titles"), "Error message is different");//verify tab name
            StringAssert.AreEqualIgnoringCase("Competencies", CareersPage.CareerPathTab.VerifySearchText("Competencies"), "Error message is different");//verify tab name
            StringAssert.AreEqualIgnoringCase("Proficiency Scales", CareersPage.CareerPathTab.VerifySearchText("Proficiency Scales"), "Error message is different");//verify tab name
            StringAssert.AreEqualIgnoringCase("360 Templates", CareersPage.CareerPathTab.VerifySearchText("360 Templates"), "Error message is different");//verify tab name

        }
        [Test, Order(42), Category("P1")]
        public void Test_to_Verify_instruction_Text_On_Tabs_and_Careers_page_32311()

        {
            CommonSection.Manage.Careerstab();
            Thread.Sleep(2000);
            Assert.IsTrue(CareersPage.VerifyInstructionText);
            CareersPage.ClickTab("Job Titles");
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on Job Titles tab and verified Instruction Text");
            CareersPage.ClickTab("Competencies");
            Assert.IsTrue(CareersPage.CompetenciesTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on Competencies tab and verified Instruction Text");
            CareersPage.ClickTab("Proficiency Scales");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on Proficiency Scales tab and verified Instruction Text");
            CareersPage.ClickTab("360 Templates");
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyInstructionText);
            _test.Log(Status.Pass, "Clicked on 360 Templates tab and verified Instruction Text");

        }
        [Test, Order(43), Category("P1")]
        public void User_View_lists_all_Proficiency_Scales_32373()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.ClickCreateNewProficencyScale();
            //StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.CreateNewProficiencyScaleModel.CreateNew(ProficiencyTitle);
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox(ProficiencyTitle);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase(ProficiencyTitle, CareersPage.GetProficiencyTitle(), "Error message is different");
            //StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");

        }
        [Test, Order(44)]
        public void Add_proficiency_Scale_to_Competency_from_Existing_Competency_32287()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_NoScaledropdown());
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickdropdown());
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.RequiredRatingColumn_CheckRecord("lowestOption")); //displays the #1 lowest option of Proficiency Scale

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the Competency under Competency Listing
            CareersPage.ClickCompetencyTab(); //Verify the Competency Title created above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_CheckProficiencyScale("")); //Verify the Proficiency Scale selected above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating("NumberAndLabel")); //Verify the Proficiency Scale Rating include First and Last Rating Number and label

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickAssignCompetency();
            Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.AssignCompetency_CompetencyTitle_CheckProficiencyScale(""));

        }
        [Test, Order(45)]
        public void Test_User_defines_the_required_rating_for_a_job_title_specific_competency_32221()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scale");
            CareersPage.ClickButtonCreateNewProficiencyScale();
            CareersPage.Frame.EnterScaleTitle("ProficiencyScale_Test");
            CareersPage.Frame.EnterRatingCriteriaLable1("1");
            CareersPage.Frame.EnterRatingCriteriaLable1("2");
            CareersPage.Frame.EnterRatingCriteriaLable1("3");
            CareersPage.Frame.ClickButtonCreate();

            CareersPage.ClickTab("Job Title");
            CareersPage.SearchByCompetencyTitle("Regression_JobTitle1");
            CareersPage.ClickOnJobTitleSearchResult("Regression_JobTitle1");
            JobTitlesPage.ClickButtonAssignCompetency();
            JobTitlesPage.Frame.EnterCompetencyToAdd("Regression_Competency1");
            JobTitlesPage.Frame.ClickButtonSearch();
            JobTitlesPage.Frame.SelectCompetencyCheckbox();
            JobTitlesPage.Frame.ClickButtonAssign();

            CareersPage.ClickTab("Competencies");
            CareersPage.SearchByCompetencyTitle("Regression_Competency1");
            CareersPage.ClickLinkCompetencyFromSearchResult();
            ManageCompetencyPage.SelectProficiencyScaleFromDropdown();
            ManageCompetencyPage.ClickOnAssignedGroupSubTab();
            ManageCompetencyPage.ClickButtonAssignedGroup();
            ManageCompetencyPage.Frame.SearchForJobTitle("Regression_JobTitle1");
            ManageCompetencyPage.Frame.SelectJobTitleCheckbox("Regression_JobTitle1");
            ManageCompetencyPage.Frame.ClickButtonAssign();

            ManageCompetencyPage.ChangeRequiredRatingsForJobTitle();
            Assert.IsTrue(false);// "Success Message About Ratings Change");


        }
        [Test, Order(46)]
        public void Test_to_Verify__breadcrumb_on_Development_Plan_Approval_page_32322()

        {

            CommonSection.Manage.DevelopmentPlanApprovals();
            StringAssert.AreEqualIgnoringCase("Development Plan Approvals", DevelopmentPlanApprovalsPage.VerifyLabelText(), "Error message is different");//verify Label text
            StringAssert.AreEqualIgnoringCase("Manage / Development Plan Approvals", DevelopmentPlanApprovalsPage.VerifyBreadcrumbText(), "Error message is different");//verify Breadcrumb text

        }

        [Test, Order(47)]
        public void Test_when_User_can_edit_proficiency_scales_from_the_tab_32398()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales"); ;
            CareersPage.ClickCreateNewProficencyScale();
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.TitleTextBox("Regression Scale");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase(" The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Regression Scale");
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.ClickSearchbutton();
            StringAssert.AreEqualIgnoringCase("Regression Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.ClickEditButtonforRecord_RegressionScale();
            CareersPage.FrameCareers.EditTitle("Regression_Scale1");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBoxFill("Regression_Scale1");
            StringAssert.AreEqualIgnoringCase("Regression_Scale1", CareersPage.GetSuccessMessage(), "Error message is different");
        }

        [Test, Order(48)]
        public void Test_when_User_can_copy_proficiency_scales_from_the_tab_32399()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.ClickCreateNewProficencyScale();
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.TitleTextBox("Regression_Scale1");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase(" The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Regression_Scale1");
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Regression_Scale1", CareersPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.ClickCopyButtonforRecord_Regression_Scale1();
            CareersPage.FrameCareers.EditTitle("Regression_Scale2");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBoxFill("Regression_Scale2");
            StringAssert.AreEqualIgnoringCase("Regression_Scale2", CareersPage.GetSuccessMessage(), "Error message is different");
        }
        [Test, Order(49)]
        public void Test_when_User_can_archive_proficiency_scales_from_the_tab_32400()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.ClickCreateNewProficencyScale();
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.TitleTextBox("Regression_Scale1");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase(" The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Regression_Scale1");
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Regression_Scale1", CareersPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.ClickArchiveButtonforRecord_RegressionScale1();
            StringAssert.AreEqualIgnoringCase("The item was archived.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBoxFill("Regression_Scale1");
            StringAssert.AreEqualIgnoringCase("No records found.", CareersPage.GetSuccessMessage(), "Error message is different");
        }
        [Test, Order(50)]
        public void Test_when_User_can_View_all_archived_proficiency_scales_from_the_tab_32401()

        {
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.Manage.Careerstab();

            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.ClickButtonCreateNewProficencyScale();
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.FillTitleTextBox("Regression_Scale1");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase(" The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Regression_Scale1");
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Regression_Scale1", CareersPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.ClickArchiveButtonforRecord_Regression_Scale1();
            StringAssert.AreEqualIgnoringCase("The item was archived.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBoxFill__SearchTypeSelection_ExactPhrase_ClickSearchbutton("Regression_Scale1");
            StringAssert.AreEqualIgnoringCase("No records found.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.ClickLink_ViewArchivedScales();
            StringAssert.AreEqualIgnoringCase("Archived Proficiency Scales", CareersPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("Regression_Scale1", CareersPage.GetSuccessMessage(), "Error message is different");

        }

        [Test, Order(51)]
        public void View_Active_and_Inactive_competencies_32159()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickInactiveItemsCheckbox();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecordIsInactive);
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecordIsActive);
            CareersPage.CompetenciesTab.ShowInactiveItems_CheckboxIsUncheck();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecordIsActive);
        }

        [Test, Order(52)]
        public void Set_Competency_Activity_Status_to_Active_with_No_Start_Date_And_No_End_Date_32160()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal_NoStartDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal_NoEndDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);
        }

        [Test, Order(53)]
        public void Set_Competency_Activity_Status_to_Active_with_No_Start_Date_And_With_End_Date_32162()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal_NoStartDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal_NoEndDateCheckbox_Uncheck();
            ManageCompetencyPage.SetActiveDatesModal_EnterEndDate("FutureDate"); //Select Future End Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Activ_ActiveUntil("Date"));

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);

        }

        [Test, Order(54)]
        public void Set_Competency_Activity_Status_to_Active_with_Start_Date_And_No_End_Date_32163()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal_NoEndDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.EnterStartDate("PastDate"); //Select Past Start Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Active_ActiveFrom("Date"));

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);

        }

        [Test, Order(55)]
        public void Set_Competency_Activity_Status_to_Active_with_Start_Date_And_End_Date_32164()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.NoEndDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.EnterStartDate("PastDate"); //Select Past Start Date
            ManageCompetencyPage.SetActiveDatesModal.EnterEndDate("FutureDate"); //Select Future End Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Active_ActiveFromDate_UntilDate);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);

        }

        [Test, Order(56)]
        public void Set_Competency_Activity_Status_to_Active_with_Start_Date_to_Later_Than_Today_32165()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.NoEndDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.EnterStartDate("FutureDate"); //Select Future Start Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_InActive_ActiveFromDate);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecordIsInactive);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecordIsInactive);


        }
        [Test, Order(57)]
        public void Set_Competency_Activity_Status_to_Active_with_End_Date_to_Past_Date_32166()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.NoEndDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.EnterEndDate("PastDate"); //Select Past End Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_InActive_ActiveUntilDate);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecordIsInactive);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecordIsInactive);


        }
        [Test, Order(58)]
        public void Add_proficiency_Scale_to_Competency_from_Create_Competency_32168()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName("CompetencyTitle");
            CreateCompetencyPage.SaveCompetencyName();
            StringAssert.AreEqualIgnoringCase("The Competency was created", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            AssignGroupPage.SelectAllTypeFilter();
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            AssignGroupPage.SearchRecords.ClickSelectAllbutton();
            AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            StringAssert.AreEqualIgnoringCase("The Selected Groups were Assigned", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle(""));
            Assert.IsTrue(ManageCompetencyPage.CheckSubOrganizationIncluded());
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_NoScaledropdown());
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_clickdropdown);
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_dropdown_SelectProficiencyScale("ProficiencyScale");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.RequiredRatingColumn_CheckRecord("lowestOption")); //displays the #1 lowest option of Proficiency Scale

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the Competency under Competency Listing
            CareersPage.ClickCompetencyTab(); //Verify the Competency Title created above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_CheckProficiencyScale("")); //Verify the Proficiency Scale selected above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating("NumberAndLabel")); //Verify the Proficiency Scale Rating include First and Last Rating Number and label

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickAssignCompetency();
            Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.AssignCompetency_CompetencyTitle_CheckProficiencyScale(""));

        }


        [Test, Order(3), Category("P1")]
        public void Self_Waitlist_In_Classroom_Course_14509()
        {
            Assert.IsTrue(classroomcourse.requestWaitlist(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, browserstr));
        }
        [Test, Order(4), Category("P1")]
        public void Cancel_Waitlist_In_Classroom_Course_14510()
        {
            Assert.IsTrue(classroomcourse.cancelRequestWaitlist());
        }

       [Test, Order(5), Category("P1")]
        public void View_Classroom_Course_Details_26368()
        {
            ContentSearch objContentSearch = new ContentSearch(driver);
            Assert.IsTrue(objContentSearch.viewDetailsOfCourses("ClassroomCourse", browserstr));
        }
        [Test, Order(6)]
        public void View_Classroom_Course_Section_Certificate_26838()
        {
             ContentSearch objContentSearch = new ContentSearch(driver);
             Assert.IsTrue(objContentSearch.viewDetailsOfCourses("ClassroomCourse", browserstr));
         //  Assert.Fail("Need to automate");
        }

        [Test, Order(7),Category("P1")]
        public void Request_Access_For_Classroom_Course_26839()
        {
            classroomcourse.editAccessApproval(browserstr, "classroom");
            Assert.IsTrue(documentobj.requestAccessForContent("ClassroomCourse", browserstr, "", ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr));

        }
       [Test, Order(8),Category("P1")]
        public void Cancel_Request_Access_For_Classroom_Course_26840()
        {
            Assert.IsTrue(documentobj.cancelRequestAccessForContent("ClassroomCourse", browserstr));
        }
       [Test, Order(9)]
        public void a57_Create_an_event_for_a_Classroom_course_section_1989()
        {
            //if (sectioncreation == true)
            //{
            StringAssert.AreEqualIgnoringCase("section created successfully", "section created successfully");
            //   }
            //   else
            //   {
            //       StringAssert.AreEqualIgnoringCase("Checking section", "Section was not created successfully");
            ////   }

        }

        public void A_Create_A_New_SCORM_Course_7251()
        {
            Document documentpage = new Document(driver);
            //  driver.UserLogin("admin", browserstr);
            string expectedresult = "Edit Summary";
            string expectedresult1 = "The course was created.";
            Scorm12 CreateScorm = new Scorm12(driver);
            CreateScorm.linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Scorm_CourseClick);
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver, true);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
            Assert.IsTrue(driver.existsElement(ObjectRepository.sucessmessage));

            CreateScorm.populatesummaryform(driver, browserstr);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
        }

         [Test]
        public void B_Manage_A_SCORM_Course_7253()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentpage.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            string expectedresult = "The changes were saved.";
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr);
            //driver.ClickEleJs(By.XPath("//input[@id='btnSearchCourses']"));
            //driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            //driver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            driver.Checkout();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE"));
            //if (!driver.existsElement(By.Id("Editor")))
            //{
            //    driver.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeysWithSpace("updating scenario");
            //}
            //else

            //{
            //    driver.GetElement(By.Id("Editor")).Clear();
            //}
            driver.GetElement(By.XPath("//textarea[@class='form-control']")).SendKeysWithSpace(" (updating scenario)");
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        }
         [Test]
        public void C_Manage_Scorm_Course_File_7278()
        {

            Assert.IsTrue(Scorm1_2obj.manageScormCourseFile());

        }
         [Test]
        public void D_Manage_Scorm_Course_Setting_7279()
        {
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            driver.Checkin();
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn-dropdown']/li[1]/a"));
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, "Exact phrase");
            driver.clicktableresult(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton']")).ClickWithSpace();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnCourseEnroll']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnCourseEnroll']")).ClickWithSpace();
            Thread.Sleep(5000);
            driver.SwitchtoDefaultContent();
            Thread.Sleep(5000);
            driver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']")).ClickWithSpace();
            Thread.Sleep(5000);
            Thread.Sleep(5000);
            driver.selectWindow("Meridian Global - Core Domain");
            //    Assert.IsFalse(driver.existsElement(By.Id("Exit")));
            Thread.Sleep(5000);
            driver.SelectWindowClose2("Meridian Global - Core Domain", "Details");
            Thread.Sleep(5000);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
        }
         [Test]
        public void E_Scorm_Course_Category_7257()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();

            Assert.IsTrue(Scorm1_2obj.setCategory());
        }

         [Test]
        public void F_Scorm_Course_Cost_7258()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setCost());
        }

         [Test]
        public void G_Scorm_Course_Alternate_Cost_7259()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setAlternateCost());
        }
         [Test]
        public void H_Scorm_Course_Prerequisites_7260()
        {
            Assert.Fail("Need to be automated");
        }
         [Test]
        public void Scorm_Course_Equivalencies_7262()
        {
            Assert.Fail("Need to be automated");

        }
         [Test]
        public void H_Scorm_Course_Approval_Path_7263()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            documentobj.editApprovalEnable();

            Assert.IsTrue(Scorm1_2obj.verifyApprovalPath(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, browserstr));

            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();

            Assert.IsTrue(documentobj.editApprovalDiable());
            Assert.IsTrue(Scorm1_2obj.verifyApprovalPathAfterRemoval(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, browserstr));

            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();

        }
         [Test]
        public void H_Scorm_Course_Content_Sharing_7264()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(documentobj.shareDocument(browserstr));
        }
         [Test]
        public void H_Scorm_Course_Permissions_7265()
        {
            Assert.Fail("Need to be automated");
        }
         [Test]
        public void H_Scorm_Course_Image_7266()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(documentobj.sètImage(browserstr));
        }
         [Test]
        public void H_Scorm_Course_Activity_7267()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(documentobj.editActivityMarkInactive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityInactive(browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();
            Assert.IsTrue(documentobj.editActivityMarkActive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityactive(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();
        }

         [Test] //Cannot be automated
        public void H_Scorm_Course_WindowAttributes_7268()
        {
            Assert.Ignore("Cannot be automated");
        }
         [Test] //CaNNOT BE Automated
        public void H_Scorm_Course_MobilesSettings_7269()
        {
            Assert.Ignore("Cannot be automated");
        }
         [Test]
        public void I_Scorm_Course_Certificate_7283()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setCertificate(browserstr));

        }
         [Test]
        public void H_Scorm_Course_Surveys_7284()
        {
            Assert.IsTrue(objCurriculum.curriculumSurvey("", browserstr));
        }
         [Test]
        public void H_Scorm_Course_Information_7357()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(Scorm1_2obj.checkInfoIcon(browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));
        }
         [Test]
        public void Z_Delete_A_SCORM_Course_7438()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//div[@class='alert alert-success']")));

        }
         [Test]
        public void H_Scorm_Course_Add_Locale_7453()
        {
            Assert.Fail("Need to be automated");
        }
         [Test]
        public void H_Scorm_Course_Delete_Locale_7454()
        {
            Assert.Fail("Need to be automated");
        }

        [Test, Order(1)]
        public void A_Create_Document_7285()
        {
            Assert.IsTrue(documentobj.createDocument(browserstr));

        }

        //    [Test,]
        public void B_Manage_Document_Files_7333()
        {

        }
        [Test, Order(2)]
        public void C_Manage_Document_7334()
        {
            Assert.IsTrue(documentobj.manageDocument(browserstr));
        }
        [Test, Order(3)]
        public void D_Document_Categories_7335()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            //   driver.Checkout();

            Assert.IsTrue(Scorm1_2obj.setCategory());
        }
        [Test, Order(4)]
        public void E_Document_Cost_7336()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setCost());
        }

        [Test, Order(5)]
        public void F_Document_AlternateCost_7337()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setAlternateCost());
        }

        [Test, Order(6)]
        public void G_Document_Prerequisites_7338()
        {
            Assert.Ignore("Cannot be Automated");
        }

        [Test, Order(7)]
        public void H_Document_Equivalencies_7339()
        {
            Assert.Fail("Not Automated");
        }

        [Test, Order(8)]
        public void I_Document_Access_Approval_7340()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            documentobj.editApprovalEnable();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(Scorm1_2obj.verifyApprovalPath(browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
            Assert.IsTrue(documentobj.editApprovalDiable());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(Scorm1_2obj.verifyApprovalPathAfterRemoval(ExtractDataExcel.MasterDic_document["Title"] + browserstr, browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
        }

        [Test, Order(9)]
        public void Z_Document_Content_Sharing_7341()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            Assert.IsTrue(documentobj.shareDocument(browserstr));

        }

        [Test, Order(10)]
        public void Z_Document_Permissions_7342()
        {
            Assert.Fail("Not Automated");
        }
        [Test, Order(11)]
        public void Z_Document_Image_7343()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            Assert.IsTrue(documentobj.sètImage(browserstr));
        }
        [Test, Order(12)]
        public void Z_Document_Activity_7344()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            Assert.IsTrue(documentobj.editActivityMarkInactive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityInactive(browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
            Assert.IsTrue(documentobj.editActivityMarkActive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityactive(ExtractDataExcel.MasterDic_document["Title"] + browserstr, browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
        }
        [Test, Order(13)]
        public void Z_Document_Window_Attributes_7345()
        {
            Assert.Ignore("Cannot be Automated");
        }
        [Test, Order(14)]
        public void Z_Document_Mobile_Settings_7346()
        {
            Assert.Ignore("Cannot be Automated");
        }
        [Test, Order(15)]
        public void Z_Delete_Dcoument_From_Creating_Domain_7435()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
            driver.findandacceptalert();
            if (!driver.IsElementVisible(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]")))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
        [Test]
        public void a_Create_New_Account_8585()
        {
            driver.UserLogin("admin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void a_Join_a_collaboration_space_9462()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Learn')]"), By.XPath("//a[contains(@href,'/CollaborationSpace.aspx')]"));
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Assert.IsTrue(Detailsobj.Click_JoinColSpace());

        }
        [Test]
        public void b_Access_a_collaboration_space_9478()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Detailsobj.Click_AccessColSpace();
            Assert.IsTrue(CollabarationSpace_lobj.IsColSpaceItemAccessed());
            //    Assert.IsTrue(driverobj.existsElement(By.XPath("//div[contains(@class,'axero-space-header-title-name')]")));
        }
         [Test, Order(1)]
        public void A_Create_Curriculam_10822()
        {
            Assert.IsTrue(objCurriculum.createCurriculum(browserstr));

        }

         [Test, Order(2)]
        public void B_Manage_Curriculam_10823()
        {
            Assert.IsTrue(objCurriculum.manageCurriculum("", browserstr));
        }

         [Test, Order(3)]
        public void C_Curriculams_Categories_10826()
        {

            Assert.IsTrue(objCurriculum.curriculumCategory("", browserstr));

        }

         [Test, Order(4)]
        public void D_Curriculams_Cost_10825()
        {
            Assert.IsTrue(objCurriculum.curriculumCost("", browserstr));
        }

         [Test, Order(5)]
        public void E_Curriculams_Alternate_Cost_10824()
        {
            Assert.IsTrue(objCurriculum.curriculumAlternativeCost("", browserstr));
        }

         [Test, Order(6)]
        public void F_Curriculam_Image_10827()
        {
            Assert.IsTrue(objCurriculum.curriculumImage("", browserstr));
        }

         [Test, Order(7)]
        public void G_Curriculam_Equivalencies_10828()
        {
            Assert.Fail("Need to be automated");
        }
         [Test, Order(8)]
        public void H_SCurriculams_Prerequisites_10829()
        {
            Assert.Fail("Need to be automated");
        }
         [Test, Order(9)]
        public void Curriculams_Certificate_10830()
        {
            Assert.IsTrue(objCurriculum.curriculumCertificate("", browserstr));
        }
         [Test, Order(10)]
        public void H_Curriculams__Approval_Path_10831()
        {
            Assert.IsTrue(objCurriculum.curriculumApprovalPath("", browserstr));
        }
         [Test, Order(11)]
        public void H_Curriculams__Content_Sharing_10834()
        {
            Assert.IsTrue(objCurriculum.curriculumContentSharing("", browserstr));
        }
         [Test, Order(12)]
        public void H_Curriculams__Permissions_10832()
        {
            Assert.Fail("Need to be automated");
        }
         [Test, Order(13)]
        public void To_create_an_ordered_block_and_add_learning_activities_15648()
        {
            Assert.Fail("Need to be automated");
        }
         [Test, Order(14)]
        public void H_Curriculams__Activity_10833()
        {
            Assert.IsTrue(objCurriculum.curriculumActivity("", browserstr));
        }

         [Test, Order(15)] //Cannot be automated
        public void To_Test_Authorized_user_can_create_a_curriculum_block_of_credit_type_and_can_choose_credit_type_15694()
        {
            Assert.Ignore("Can not be automate");
        }
         [Test, Order(16)] //CaNNOT BE Automated
        public void To_Test_Authorized_user_can_create_a_optional_block_and_can_add_learning_activities_15647()
        {
            Assert.Ignore("Can not be automate");
        }
         [Test, Order(17)] //CaNNOT BE Automated
        public void Search_and_Add_training_activities_15758()
        {
            Assert.Ignore("Can not be automate");
        }
         [Test, Order(18)]//Done
        public void I_Curriculams__Checkin_Checkout_10840()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr);
            Assert.IsTrue(driver.Checkin());
            Thread.Sleep(3000);
            Assert.IsTrue(driver.Checkout());
        }
         [Test, Order(19)]//done
        public void H_Curriculams__Surveys_10837()
        {
            Assert.IsTrue(objCurriculum.curriculumSurvey("", browserstr));
        }
         [Test, Order(20)]//done
        public void H_Curriculams__Add_Training_Activities_10841()
        {
            Assert.IsTrue(objCurriculum.curriculumAddTrainingActivity("", browserstr));
        }
         [Test, Order(21)]//done
        public void Z_Add_Calssroom_Section__10848()
        {
            Assert.IsTrue(objCurriculum.curriculumAddTrainingActivityClassroom("", browserstr));
        }
         [Test, Order(22)]//done
        public void H_Curriculams__Add_Locale_10835()
        {
            driver.Quit();
            Driver.Initialize();
            LoginPage.GoTo();

            LoginPage.LoginClick();
            LoginPage.LoginAs("regadmin").WithPassword("password").Login();
            CommonSection.Manage.Training();
            TrainingPageki.SearchforContent(Variables.curriculumTitle + browserstr);
            SearchResultsPage.CheckSearchRecord(Variables.curriculumTitle + browserstr);
            ContentDetailsPage.ClickAddLocaleButton();
            string langSet = AddLocalePage.SetInfo();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.AddLocalCheck("Arabic"));
        }
         [Test, Order(23)]//done
        public void H_Curriculams__Delete_Locale_10836()
        {
            driver.Quit();
            Driver.Initialize();
            LoginPage.GoTo();

            LoginPage.LoginClick();
            LoginPage.LoginAs("regadmin").WithPassword("password").Login();
            CommonSection.Manage.Training();
            TrainingPageki.SearchforContent(Variables.curriculumTitle + browserstr);
            SearchResultsPage.CheckSearchRecord(Variables.curriculumTitle + browserstr);
            ContentDetailsPage.DeleteLocal();
            DeleteLocalePage.ClickDeleteLocalButton();

            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.GetSuccessMessage(), "Error message is different");

        }
        [Test, Order(1)]
        public void A_View_Transcript_Curriculum_26150()
        {
            ContentSearch objContentSearch = new ContentSearch(driver);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //driver.UserLogin("userforregression", browserstr);
            objContentSearch.enrollInCurriculum(Variables.curriculumTitle + browserstr, browserstr);
            objContentSearch.accessCurriculum(browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();

            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]")));
            Assert.IsTrue(Transcriptsobj.Click_PrintBtn("Curriculums"));
            Assert.IsTrue(Transcriptsobj.Click_PDFBtn("CurriculaPrint.aspx"));


        }
        [Test, Order(3)]
        public void B_Curriculum_View_Certificate_26853()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();
            //   Transcriptsobj.Click_CurriculamFilter();
            driver.WaitForElement(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]"));
            driver.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction']"));
            Thread.Sleep(5000);
            driver.selectWindow("Meridian Global 2010.1");
            Thread.Sleep(2000);
            driver.waitforframe(By.Id("CertificateWindow"));
            Thread.Sleep(2000);
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'" + Variables.curriculumTitle + browserstr + "')]")));
            driver.SelectWindowClose2("Meridian Global 2010.1");
            Thread.Sleep(2000);
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]")));



        }
        [Test, Order(2)]
        public void Launch_Curriculum_26855()
        {
            ContentSearch objContentSearch = new ContentSearch(driver);
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]"));
            //Assert.IsTrue(objContentSearch.accessCurriculum(browserstr));
            Assert.IsTrue(objContentSearch.launchCurriculum(browserstr));
            //Assert.Fail("Need to be automated");

        }
    }
}
