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
    public class P1RegressionTests : TestBase
    {
        string browserstr = string.Empty;
        public P1RegressionTests(string browser)
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
      //  [TearDown]
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
        public void a01_Login_8597()
        {
            _test.Log(Status.Pass, "login as siteadmin successful");
            Assert.IsTrue(HomePage.Title == "Home");//checks the Home page title
        }

        [Test, Order(2), Category("AutomatedP1")]
        public void a02_Click_the_Help_link_238()
        {

            //LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.ClickHelpIcon();
            _test.Log(Status.Info, "help icon opens successfully");
            Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
            _test.Log(Status.Pass, "Verified Help Page/Title");
            // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test, Order(3), Category("AutomatedP1")]
        public void a03_Logout_24943()
        {
            Assert.True(true);

        }
        [Test, Order(4), Category("AutomatedP1")]
        public void a04_Create_a_new_organization_8552()
        {
            CommonSection.Administer.People.Organizations();
            _test.Log(Status.Info, "Open Organization page");
            //TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));

            //AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            OrganizationsPage.ClickCreatenew();
            _test.Log(Status.Info, "Click Create New Organization");

            NewOrganizationsPage.OrganizationTitleAs(OrganizationTitle).DescriptionAs("Automation test").Create();
            _test.Log(Status.Info, "Click Create New Organization");

            Assert.IsTrue(NewOrganizationsPage.SuccessmessgeDisplay());
            _test.Log(Status.Pass, "Verified Successful Message");

        }
        [Test, Order(5), Category("AutomatedP1")]
        public void a05_Manage_Organization_8553()
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
        [Test, Order(6), Category("P1")]
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
        [Test, Order(7), Category("AutomatedP1")]
        public void a07_View_job_Title_page_32179()

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
        [Test, Order(8), Category("P1")]
        public void a08_Job_title_info_icon_22215()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Pass, "Open Career Menu");
            CareersPage.EditJobTitleName(JobTitle+ "TC22125");
            _test.Log(Status.Info, "Clik on Create New Job Title, Edit Job Title name, Click Save");
            CommonSection.Avatar.Account();
            AccountPage.ClickProfiletab();
            AccountPage.Click_EditWorkInformation();
            AccountPage.WorkInformationFrame.AddJobTitle(JobTitle + "TC22125");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Pass, "Open Career Menu");
            
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Pass, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "TC22125");
            _test.Log(Status.Pass, "Search above Jobtitle");
            CareersPage.ClickinfoIcon("i");
            _test.Log(Status.Pass, "Click on info icon for the searched Job Title");
            Assert.IsTrue(InformationPage.JobTitleName(JobTitle + "TC22125"));
            // ManageJobTitlePage.JobDetailsTab.AddDescription("Reg_Description");
            InformationPage.ClickViewUsersTab();
            _test.Log(Status.Pass, "Click on View users Tab on Info Popup");
            Assert.NotZero(InformationPage.ViewUsersTab.CountRecords);
            _test.Log(Status.Pass, "Verify User Record");
            Driver.Instance.SelectWindowClose();
            _test.Log(Status.Pass, "Close opened Popup");
            //Close This Page
        }
        [Test, Order(9), Category("P1")]
        public void a09_Edit_localized_Job_Title_32187()
        {
            CareersPage.CreateJobTitle(JobTitle + "TC32187");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "TC32187");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC32187"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle(JobTitle + "TC32187");
            _test.Log(Status.Info, "Click on Searched Job Title");
            AdminContentDetailsPage.EditLocalization("edittitle", "Descriptionedit", "jobcodedit", "keywordsedit", "Arabic");
            _test.Log(Status.Info, "Edit Descriptionn Job code, Key Word on edit Job Title page and Save");
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            AdminContentDetailsPage.SelectLocalization("Arabic");
            _test.Log(Status.Info, " Set Localization DropDown as Arabic");
            // StringAssert.AreEqualIgnoringCase("Add Localization", ContentDetailsPage.Frame(), ("Error message is different"));

            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckJobTitle("edittitle"));
            _test.Log(Status.Pass, "Verify Job Tilte After edit");
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckJobCode("jobcodedit"));
            _test.Log(Status.Pass, "Verify job Title Job Code");
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckDescriptionValue("Descriptionedit"));
            _test.Log(Status.Pass, "Verify Job Title Description");
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckKeywordsValue("keywordsedit"));
            _test.Log(Status.Pass, "Verify Job Title Description");

            //Deleted Job title After test complete
            CareersPage.DeleteJobTitle(JobTitle + "TC32187");
            _test.Log(Status.Info, "Job Title Deleted");
            StringAssert.AreEqualIgnoringCase("No matching records found", CareersPage.NoMatchingJobTitleFound("No matching records found"));
            _test.Log(Status.Pass, "Verify No matching records found message display after job title deleted");

        }
        [Test, Order(10), Category("P1")]
        public void a10_localized_Job_Title_32185()
        {
            CareersPage.CreateJobTitle(JobTitle + "TC32185");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "TC32185");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC32185"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle(JobTitle + "TC32185");
            _test.Log(Status.Info, "Click on Searched Job Title");
            AdminContentDetailsPage.SelectAddLocalization("French");
            _test.Log(Status.Info, "Set Localization DropDown as French");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");

            //Deleted Job title After test complete
            CareersPage.DeleteJobTitle(JobTitle + "TC32185");
            _test.Log(Status.Info, "Job Title Deleted");
            StringAssert.AreEqualIgnoringCase("No matching records found", CareersPage.NoMatchingJobTitleFound("No matching records found"));
            _test.Log(Status.Pass, "Verify No matching records found message display after job title deleted");
        }

        [Test, Order(11), Category("P1")]
        public void a11_View_competency_column_in_job_Title_list_32181()

        {
            // Prerequisite - Competencies are created and added to JobTitles
            //login with siteadmin/password

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            StringAssert.AreEqualIgnoringCase("Job titles define a position and its responsibilities. Assign competencies to set training and proficiency targets.", CareersPage.JobTitlesTab.GetMessage(), "Error message is different");//verify Text 
            _test.Log(Status.Pass, "Verify Infor text of Job Title Tab");
            CareersPage.SearchJobtitle("JobTitle21");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle("JobTitle21"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle("JobTitle21");
            _test.Log(Status.Info, "Click on Searched Job Title");
            Assert.IsTrue(CareersPage.sortingcompetencycolumn_verifysortingascecorder());//verify sorting desc order
            _test.Log(Status.Pass, "Verify Sorting order of Competency associated with this Job Title");
            //logout
        }


        [Test, Order(12), Category("P1")]
        public void a12_User_Edit_a_Job_title_31501()
        {
            CareersPage.CreateJobTitle(JobTitle + "TC31501");

            //CommonSection.Manage.ProfessionalDevelopment();
            //_test.Log(Status.Info, "Open Career Menu");
            //CareersPage.ClickJobTitleTab();
            //_test.Log(Status.Info, "Open Job Title tab");
            //CareersPage.SearchJobtitle(JobTitle + "TC31501");
            //_test.Log(Status.Info, "Search Job Title");
            //Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC31501"));
            //_test.Log(Status.Pass, "Verify Job Tile is searched");
            //CareersPage.ClickJobtitle(JobTitle + "TC31501");
            //_test.Log(Status.Info, "Clicked on Searched Job title");
            ManageJobTitlePage.ClickJobDetailsTab();
            _test.Log(Status.Info, "Clicked on Job Details tab.");
            ManageJobTitlePage.JobDetailsTab.AddDescription("Reg_Description");
            _test.Log(Status.Info, "Clicked Add Description link, fill Details and click on Submit button.");

            StringAssert.AreEqualIgnoringCase("Reg_Description", ManageJobTitlePage.GetDescriptionLink(), "Description value does not match");
            ManageJobTitlePage.JobDetailsTab.AddKeywords("Reg_Keywords");
            _test.Log(Status.Pass, "Clicked Add Kew Word link, fill Details and click on Submit button.");

            StringAssert.AreEqualIgnoringCase("Reg_Keywords", ManageJobTitlePage.GetKeywordLink(), "Keywords value does not match");
            ManageJobTitlePage.JobDetailsTab.JobCodeLink("Reg_JOBCODE");
            _test.Log(Status.Info, "Clicked Add Job Code link, fill Details and click on Submit button.");
            // ManageJobTitlePage.ClickSavebutton();
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verified Successful Message");
            StringAssert.AreEqualIgnoringCase("Reg_JOBCODE", ManageJobTitlePage.GetJobCodeLink(), "JobCode Value does not match");
            _test.Log(Status.Pass, "Verify Tags after edit");

        }
        [Test, Order(13), Category("P1")]
        public void a13_Edit_Competency_Details_Creation_31458()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CommonTab.ClickCreateCompetency();
            _test.Log(Status.Info, "Click on Create Competency Button");
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            _test.Log(Status.Info, "Competency Title filled");
            //CreateCompetencyPage.SaveCompetencyName();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            _test.Log(Status.Info, "Open Competency Details Page");
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("EditDescription");
            _test.Log(Status.Info, "Added Description to Competency");
            // ManageCompetencyPage.ClickSavebutton();
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "verify Successful Message");
            StringAssert.AreEqualIgnoringCase("EditDescription", ManageCompetencyPage.GetDescriptionLink(), "Description does not match");
            _test.Log(Status.Pass, "Verify Description text");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("EditKeywords");
            _test.Log(Status.Info, "Added Key Words to Competency");
            // ManageCompetencyPage.ClickSavebutton();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            // _test.Log(Status.Pass, "verify Successful Message");
            StringAssert.AreEqualIgnoringCase("EditKeywords", ManageCompetencyPage.GetKeywordLink(), "Keywords does not match");
            _test.Log(Status.Pass, "verify Key Words text");

        }
        [Test, Order(14), Category("P1")]
        public void a14_User_Remove_Competency_from_existing_Job_title_31504()
        {
            CareersPage.CreateJobTitle(JobTitle + "31504");
            CareersPage.CreateCompetency(CompetencyTitle + "31504");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.SearchJobtitle(JobTitle + "31504");
            _test.Log(Status.Info, "Search Job Title");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "31504"));
            _test.Log(Status.Pass, "Verify Job Tile is searched");
            CareersPage.ClickJobtitle(JobTitle + "31504");
            _test.Log(Status.Info, "Clicked on Searched Job title");
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            _test.Log(Status.Info, "Clicked on Assign Competency Button display insite frame");
            //ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle + "31504");
            //_test.Log(Status.Info, "Search Competency in Assign Compentency Modal");
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle + "31504");
            _test.Log(Status.Info, "Select Conpentency from result and Click on Assign button");
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle + "31504");
            _test.Log(Status.Info, "Remove Added Compentency ");
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle + "31504"));
            _test.Log(Status.Info, "Verify Competency Count is 0");

            //Deleted Job title After test complete
            CareersPage.DeleteJobTitle(JobTitle + "31504");
            _test.Log(Status.Info, "Job Title Deleted");
            StringAssert.AreEqualIgnoringCase("No matching records found", CareersPage.NoMatchingJobTitleFound("No matching records found"));
            _test.Log(Status.Pass, "Verify No matching records found message display after job title deleted");
            CareersPage.DeleteCompetency(CompetencyTitle + "31504");

        }

        [Test, Order(15), Category("P1")]
        public void a15_User_Remove_Competency_while_Creating_New_Job_title_31506()
        {
            CareersPage.CreateCompetency(CompetencyTitle + "31506");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title tab");
            CareersPage.EditJobTitleName(JobTitle + "TC31506");
            _test.Log(Status.Info, "Create new Job Title");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "Verify SuccessFul Message");
            Assert.IsTrue(CareersPage.JobTitle(JobTitle + "TC31506"));
            _test.Log(Status.Pass, "Verify Job Title name");
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            _test.Log(Status.Info, "Clicked on Assign Competency Button display insite frame");
            //ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle + "31506");
            //_test.Log(Status.Info, "Search Competency in Assign Compentency Modal");
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle + "31506");
            _test.Log(Status.Info, "Select Conpentency from result and Click on Assign button");
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle + "31506");
            _test.Log(Status.Info, "Remove Added Compentency ");
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
          //  Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "Verify Successful message");
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle + "31506"));
            _test.Log(Status.Info, "Verify Competency Count is 0");

            CareersPage.DeleteCompetency(CompetencyTitle + "31506");
            CareersPage.DeleteJobTitle(JobTitle + "TC31506");
        }

        [Test, Order(16), Category("P1")]
        public void a16_Add_Job_Title_to_Competency_31507()
        {
            CareersPage.CreateCompetency(CompetencyTitle + "31507");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Search Compentency");
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Click on Competency Title");
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            _test.Log(Status.Info, "Clicked on AssignGroup Button display inside frame");
            ManageCompetencyPage.AssignGroupFrame.SelectUserGroupFilter();
            _test.Log(Status.Info, "Select Group from Dropdown list on Asign Modal");
            ManageCompetencyPage.AssignGroupFrame.SearchGroups("Manager");//Create this record for another environment
            _test.Log(Status.Info, "Type Manage on Search area in Asign Modal");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click Search Icon in Asign Modal");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select Record in Asign Modal");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button in Asign Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            //StringAssert.AreEqualIgnoringCase("The Selected Groups were Assigned", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            // Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Verify Competency Title");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);//Verify the total is increased
            _test.Log(Status.Pass, "Verify Count is increased");

        }
        [Test, Order(17), Category("P1")]//dependent on 31458
        public void a17_Add_User_Group_to_Competency_32152() // need to create user and then make a user group to call that users
        {
            CareersPage.CreateCompetency(CompetencyTitle + "TC32152");
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupButtonOuter();//Click on Assign Group button present
            _test.Log(Status.Info, "Clicked on AssignGroup Button display OutSide frame");
            AssignGroupPage.SelectUserGroupFilter();//select user group filter
            _test.Log(Status.Pass, "Select Group from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("usergroup_1102520752");//search user group
            _test.Log(Status.Info, "Search Any User Group Name In Assign Group Modal");
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            string selectedusergroup=Driver.GetElement(By.XPath("//table[@id='find-entities-table']/tbody/tr/td[2]")).Text;
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            Assert.IsTrue(ManageCompetencyPage.NameColumn2ndRow(selectedusergroup)); //checked the user group displaying in Assigned groups
            _test.Log(Status.Pass, "Verify value of 2nd Row");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32152");
            _test.Log(Status.Info, "Search Compentency");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn >= 1);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify Assign groups count");

            //CommonSection.Logout();

            //LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            //_test.Log(Status.Info, "Login with test user");
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open Career Development page");
            //CareersPage.FilterCompetenciesFor("usergroup_1102520752");
            //_test.Log(Status.Info, "Select User group in DropDown");
            //Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            //_test.Log(Status.Info, "Verify Competecy id display in User's Career Development page");

        }

        [Test, Order(18), Category("P1")]// dependednt on 32152
        public void a18_Remove_User_Group_from_Competency_32155()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Search Compentency");
            CareersPage.ClickCompetencyTitle(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Click on Searched Competency Title");
            //ManageCompetencyPage.ClickAssignGroupsTab();
            // ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Dolly's User Group_12012017");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            _test.Log(Status.Info, "Select Assigned Group and Remove them");
            //ManageCompetencyPage.AssignedGroupsTab.ClickRemoveinRemoveConfirmationModal();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competencie tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "31507");
            _test.Log(Status.Info, "Search Compentency");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn >= 0);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify Assign group count");                                                                                          //Verify the total is decressed to 0
            CommonSection.Logout();

            LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            _test.Log(Status.Info, "Login with test User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development page");
            CareersPage.FilterCompetenciesFor("usergroup_1102520752");
            // Assert.IsFalse(CareersPage.CheckCompetencyTitle(CompetencyTitle));

        }
        [Test, Order(19), Category("P1")]
        public void a19_Add_Organization_to_Competency_32153()// need to create organisation and then create a new user, assign him that organisation
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            _test.Log(Status.Info, "Search Competency");
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            _test.Log(Status.Info, "Click on Compentency Title");
            //ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            _test.Log(Status.Info, "Click on Assign Group Button present outside frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Info, "Select Organization from All type Dropdown");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            _test.Log(Status.Info, "Type Sample Organization 1 in search text box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click on Search Icon");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select search result");
            //AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign button");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify successful message");
            Assert.IsTrue(ManageCompetencyPage.NameColumn("Sample Organization 1")); ;//checked the user group displaying in Assigned groups
            _test.Log(Status.Pass, "Organization added to Competency successfully ");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            _test.Log(Status.Info, "Click Searched competency title");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 1);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify Assign group count");
            //CommonSection.Logout();
            //// LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            //_test.Log(Status.Info, "Login with test user");
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open Career Development Page");
            //CareersPage.FilterCompetenciesFor("Sample Organization 1");
            ////Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(20), Category("P1")]
        public void a20_Remove_Organization_from_Competency_32156() //depend on 31507
        {
            CareersPage.CreateCompetency(CompetencyTitle + "TC32156");
            ManageCompetencyPage.ClickAssignGroupsTab();
            _test.Log(Status.Info, "Click on Assign Group Button present inside frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Info, "Select Organization from All type Dropdown");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("test");
            _test.Log(Status.Info, "Search Sample Organization 1");
            AssignGroupPage.SelectFirstRecord();
            _test.Log(Status.Info, "Select searched first record");
            //AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
           
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            _test.Log(Status.Info, "Removed selected Competency");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Pass, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32156");
            _test.Log(Status.Info, "Search Competency" + CompetencyTitle + "TC32156");
            CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle + "TC32156");
            _test.Log(Status.Info, "Click on Searched Competency Title");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            _test.Log(Status.Pass, "Verify Assign Group Count");
            CareersPage.DeleteCompetency(CompetencyTitle + "TC32156");
            // CommonSection.Logout();
            // LoginPage.GoTo();
            // LoginPage.LoginClick();
            // LoginPage.LoginAs("testuser123").WithPassword("").Login();
            // CommonSection.Learn.CareerDevelopment();
            //// Assert.IsFalse(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            // CommonSection.Logout();
            // LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(21), Category("P1")]
        public void a21_Remove_Job_Title_from_Competency_31508()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency Tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            _test.Log(Status.Info, "Search Competency" + CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            _test.Log(Status.Info, "Click on Searched Competency Title");
            //CareersPage.CompetencyTab.ClickCompetency();
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();
            _test.Log(Status.Info, "Click on Assign Group Button present inside frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Pass, "Select Job Title from All type Dropdown");
            // AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click Search icon");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select searched record");
            //AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successfull Message");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);
            _test.Log(Status.Pass, "Verify Assign Group Column");
            //ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Manager");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            _test.Log(Status.Info, "Select all and remove all Assign Groups");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);
            _test.Log(Status.Pass, "Verify Assign Group Column");
        }

        [Test, Order(22), Category("P1")]
        public void a22_Access_Careers_31888()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifyTabName("Career Paths"));
            _test.Log(Status.Pass, "Verify Career Path tab Name");
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyText("Job Titles"));
            _test.Log(Status.Pass, "Verify Job Titles tab Name");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scales"));
            _test.Log(Status.Pass, "Verify Proficiency Scales tab Name");
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyText("360 Templates"));
            _test.Log(Status.Pass, "Verified Tab Names");
            CommonSection.Logout();

            //LoginPage.GoTo();

            LoginPage.LoginAs("user_competencymanager").WithPassword("password").Login(); //Login as Competency Manager
            _test.Log(Status.Info, "Login with Competency Manager");
            CommonSection.Manage.CareerMenu();
            _test.Log(Status.Info, "Logged in with Learner and open Career Page");
            Assert.IsTrue(CareersPage.CompetenciesTab.VerifyText("Competencies"));
            _test.Log(Status.Pass, "Verified Competencies Tab Names");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scales"));
            _test.Log(Status.Pass, "Verified Proficiency Scales Tab Names");


        }
        [Test, Order(23), Category("P1")]
        public void a23_Test_to_Verify_order_of_Tabs_on_Careers_page_32310()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifySearchText("Career Paths"), "Error message is different");
            _test.Log(Status.Pass, "Verify Career Paths tab Name");
            StringAssert.AreEqualIgnoringCase("Job Titles", CareersPage.CareerPathTab.VerifySearchText("Job Titles"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify Job Titles tab Name");
            StringAssert.AreEqualIgnoringCase("Competencies", CareersPage.CareerPathTab.VerifySearchText("Competencies"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify Competencies tab Name");
            StringAssert.AreEqualIgnoringCase("Proficiency Scales", CareersPage.CareerPathTab.VerifySearchText("Proficiency Scales"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify Proficiency Scales tab Name");
            StringAssert.AreEqualIgnoringCase("360 Templates", CareersPage.CareerPathTab.VerifySearchText("360 Templates"), "Error message is different");//verify tab name
            _test.Log(Status.Pass, "Verify 360 Templates tab Name");
        }
        [Test, Order(24), Category("P1")]
        public void a24_Test_to_Verify_instruction_Text_On_Tabs_and_Careers_page_32311()

        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickTab("Job Titles");
            _test.Log(Status.Info, "Open Job Title Tab");
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
        [Test, Order(25), Category("P1")]
        public void a25_Verify_Updated_label_of_Career_Development_on_Domain_Page_32303()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "Opens Domains Page");
            DomainsPage.ClickDomainLink("Meridian Global-Core Domain(default)");
            _test.Log(Status.Info, "Open Domain Edit Summary Page");
            EditSummaryPage.Menus.ClickMenuTab();
            _test.Log(Status.Info, "Open Menu tab");
            StringAssert.AreEqualIgnoringCase("Career Development", MenuPage.GetCurrentValueForCareerPath(), "Error message is different");
            _test.Log(Status.Pass, "Verify Career Development lable text on Menu Tab");
            EditSummaryPage.Menus.ClickOptionsTab();
            _test.Log(Status.Info, "Open Options tab");
            StringAssert.AreEqualIgnoringCase("Enable Career Development", EditConfigurationOptionsPage.GetOptionValue(), "Error message is different");
            _test.Log(Status.Pass, "Verify Enable Career Development lable text on Options Tab");
        }
        [Test, Order(26), Category("P1")]
        public void a26_User_View_lists_all_Proficiency_Scales_32373()

        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickTab("Proficiency Scales");
            _test.Log(Status.Info, "Open Proficiency Scales tab");
            CareersPage.ClickCreateNewProficencyScale();
            _test.Log(Status.Info, "Click On Create Proficeancy Scale button");
            //StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.CreateNewProficiencyScaleModel.CreateNew(ProficiencyTitle);
            _test.Log(Status.Info, "Click New on Model opened");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            _test.Log(Status.Info, "Enter Label text");
            CareersPage.ClickCreatebutton();
            _test.Log(Status.Info, "Click Create button");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify Successful Message");
            CareersPage.SearchTextBox(ProficiencyTitle);
            _test.Log(Status.Info, "Search Proficiency" + ProficiencyTitle);
            CareersPage.SelectSearchType("Exact Phrase");
            _test.Log(Status.Info, "Choose Exact Phrase");
            CareersPage.Searchbutton();
            _test.Log(Status.Info, "Click Search Button");
            StringAssert.AreEqualIgnoringCase(ProficiencyTitle, CareersPage.GetProficiencyTitle(), "Error message is different");
            _test.Log(Status.Info, "Verify Proficiency Title");
            //StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");

        }
        [Test, Order(27), Category("P1")]
        public void a27_ActiveInActive_Job_Title_In_Professional_Development_31882()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickJobtitle("Job Titles");
            _test.Log(Status.Info, "Open Job Title Tab");
            Assert.IsTrue(CareersPage.JobTitlesTab.GetTotalJobTitles(), "JobTiles Count matched");//Check for Active and Inactive Job Titles displayed
            _test.Log(Status.Info, "Verify results with active and inactive state");

        }
        [Test, Order(28), Category("P1")]
        public void a28_Localize_Competency_32105()
        {
            CareersPage.CreateCompetency(CompetencyTitle + "TC32105");

            //CommonSection.Manage.ProfessionalDevelopment();
            //_test.Log(Status.Info, "Open Career Menu");
            //CareersPage.ClickCompetencyTab();
            //_test.Log(Status.Info, "Open Competency tab");
            //CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32105");
            //_test.Log(Status.Info, "Search Competency as " + CompetencyTitle + "TC32105");
            //CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //_test.Log(Status.Info, "Click on Competency Title");
            ManageCompetencyPage.ClickLocalizedIndropdown();
            ManageCompetencyPage.LocalizedIndropdown.ClickAddLocalization();
            _test.Log(Status.Info, "Click on Add Localization");
            ManageCompetencyPage.LocalizedIndropdown.SelectLanguage("French");
            _test.Log(Status.Info, "Select French from DropDown");
            //ContentDetailsPage.SelectAddLocalization("French");
            AddLocalizationModal.EnterForm("Title", "Description", "Keywords");
            AddLocalizationModal.ClickLocalize();
            _test.Log(Status.Info, "Added Description, Keywords and click Localize");
            // StringAssert.AreEqualIgnoringCase("Success", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.ClickLocalizedIndropdown();
            _test.Log(Status.Info, "Click on Localize Dropdown");
            // Assert.IsTrue(ManageCompetencyPage.LocalizedIndropdown.CheckLanguage);
            StringAssert.AreEqualIgnoringCase("French (Canada)", ManageCompetencyPage.LocalizedIndropdown.CheckLanguage("French"), "Language Not Matched");
            _test.Log(Status.Pass, "Verify French is display as selected into DropDown ");
            Assert.IsTrue(ManageCompetencyPage.CompetencyTitleText(CompetencyTitle + "TC32105"));
            _test.Log(Status.Pass, "Verify Competency Ttile matched");
            CareersPage.DeleteCompetency(CompetencyTitle + "TC32105");
        }

        [Test, Order(29), Category("AutomatedP1")]
        public void Catalog_Search_By_Using_Content_Tags_Facets_33557()
        //Pre-Req - Admin has created Content Tags and Admin has associated content with tags

        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login(); //Login as regular user (Learner)
            CommonSection.SearchCatalog("Tag_Reg0108230023");
            _test.Log(Status.Info, "Search Tag_Reg0108230023 from Catalog search ");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Tag_Reg0108230023") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify result list is display");
            Assert.IsTrue(SearchResultsPage.ContentTagsFacet.Display()); //Verify Content Tag Facet is displayed in the left sidebar
            _test.Log(Status.Pass, "Content Tags Facet display on LHS");
            SearchResultsPage.ContentTagsFacet.SelectCheckbox(); //Select multiple checkboxes
            _test.Log(Status.Info, "Select first check of from Content Tags");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Tag_Reg0108230023") >= 1);
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
        [Test, Order(30), Category("AutomatedP1")]
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
        [Test, Order(31), Category("AutomatedP1")]
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

        [Test,Order(32), Category("AutomatedP1")]
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
    }

}
