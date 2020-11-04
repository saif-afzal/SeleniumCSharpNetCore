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
  ////   [Parallelizable(ParallelScope.Fixtures)]
    public class P2CareerDevelopmentTests : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPath" + Meridian_Common.globalnum;
        
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;


        public P2CareerDevelopmentTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
    
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
        }
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        //[TearDown]
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
                driver.Navigate().Refresh();
            }
        }
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }
      
     
        [Test, Order(1), Category("AutomatedP1")]

        public void a_Learner_Searches_for_Job_33736()

        {
            /*  Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner"); */

            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Info, "Login with userreg_0403012001people1 User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Navigating to Career Development page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click on Explorer Career Button");
            Assert.IsTrue(CareerNavigatorPage.Title);
            _test.Log(Status.Pass, "Verify Career Nevigator page is opened");
            CareerNavigatorPage.ClickShowSearchIcon();
            _test.Log(Status.Info, "Click on Search lense Icon");
            Assert.IsTrue(CareerNavigatorPage.SearchField()); //Verify the Search field is displayed
            _test.Log(Status.Pass, "Verify search text box is visible on page");
            CareerNavigatorPage.SearchwithJobTitleAs("JobTitle").ClickSearchIcon(); // Search by entering Job Title
            _test.Log(Status.Info, "Search jobtitle as JobTitle");
            Assert.IsTrue(CareerNavigatorPage.Results.ActiveJobCards()); // Verify the results only display "active" job titles
            _test.Log(Status.Pass, "Verify search result is display");
            //Assert.IsTrue.CareerNavigatorPage.Results.JobCardsAlphabeticallyByJobTitle(); // Verify the results are sorted in alphabetical order by Job Title
            Assert.IsTrue(CareerNavigatorPage.Results.JobCardsCount()); // Verify the count of items are displayed above the grid
            _test.Log(Status.Pass, "verify search result count");
            CareerNavigatorPage.SearchwithJobTitleAs("Reg_Description").ClickSearchIcon(); // Search by entering Job Title Description
            _test.Log(Status.Info, "Re Search with job title description as Reg_Description");
            Assert.IsTrue(CareerNavigatorPage.Results.ActiveJobCards()); // Verify the results only display "active" job titles
            _test.Log(Status.Pass, "Verify search result is display");
            //Assert.IsTrue.CareerNavigatorPage.Results.JobCardsAlphabeticallyByJobTitle(); // Verify the results are sorted in alphabetical order by Job Title
            Assert.IsTrue(CareerNavigatorPage.Results.JobCardsCount()); // Verify the count of items are displayed above the grid
            _test.Log(Status.Pass, "verify search result count");
            CareerNavigatorPage.SearchwithJobTitleAs("Reg_Keyword").ClickSearchIcon(); // Search by entering Job Title Keywords
            _test.Log(Status.Info, "Re Search with job title key word as Reg_Keyword");
            Assert.IsTrue(CareerNavigatorPage.Results.ActiveJobCards()); // Verify the results only display "active" job titles
            _test.Log(Status.Pass, "Verify search result is display");
            Assert.IsTrue(CareerNavigatorPage.Results.JobCardsCount()); // Verify the count of items are displayed above the grid
            _test.Log(Status.Pass, "verify search result count");
            int resultcount = CareerNavigatorPage.Results.GetJobCardsCount();
            CareerNavigatorPage.ClickCancelSearchIcon(); // Click on the Cancel Search (X) icon
            _test.Log(Status.Info, "Clicked on Cancel Search X icon");
            Assert.IsTrue(CareerNavigatorPage.Results.SearchFilterCleared(resultcount)); // Verify the search is cleared and page reloads 
            Assert.IsTrue(CareerNavigatorPage.CareerPathFilter()); //Verify filter by Career Path displays
            Assert.IsTrue(CareerNavigatorPage.LevelFilter()); //Verify filter by Level displays
            _test.Log(Status.Pass, "verify all filters are removed");
        }
        [Test, Order(2), Category("AutomatedP1")]

        public void b_Learner_Views_Career_Navigator_33640()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            _test.Log(Status.Info, "Login with userreg_0210112911anybrowser User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click on Explorer Career button");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Career Explorer Page is opened");
            Assert.IsTrue(CareerNavigatorPage.JobCards.FirstJobTitle()); //Verify JobCard displayed one jobtitle per card
            _test.Log(Status.Pass, "Verify Job title is display");
            Assert.IsTrue(CareerNavigatorPage.MoreThan9JobCards.ShowMoreButton()); //Verify if more than 9 JobCards exists, "Show More" button is displayed centered in the bottom
            _test.Log(Status.Pass, "Verify Show More Button is display");
            CareerNavigatorPage.MoreThan9JobCards.ClickShowMoreButton();
            _test.Log(Status.Info, "Click on Show More button");
            string firstjobtitle_CareerexplorerPage = CareerNavigatorPage.JobCards.FirstJobTitle_Name();

            CommonSection.Logout();
            _test.Log(Status.Info, "User logout");
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with admin user");
            CommonSection.Manage.ProfessionalDevelopment();// Careers();
            _test.Log(Status.Info, "Open Career Page");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Tile Page");
            CareersPage.SearchJobtitle(firstjobtitle_CareerexplorerPage); //Search for the JobTitle in one of the above Job Card
            _test.Log(Status.Info, "Search Job Tile");
            CareersPage.ClickJobtitle(firstjobtitle_CareerexplorerPage);
            _test.Log(Status.Info, "Click on Job title");
            CareersPage.JobTitlesTab.SelectStatusInactive();
            _test.Log(Status.Info, "Select Job title status to Inactive");
            Assert.IsTrue(CareersPage.JobTitlesTab.StatusInActive);
            _test.Log(Status.Pass, "Verify status become inactive");

            CommonSection.Logout();
            _test.Log(Status.Info, "Logout user");
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            _test.Log(Status.Info, "Login with userreg_0210112911anybrowser User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explorer Career Button");
            CareerNavigatorPage.ClickShowSearchIcon();
            _test.Log(Status.Info, "Clcik on search icon");
            CareerNavigatorPage.SearchwithJobTitleAs(firstjobtitle_CareerexplorerPage).ClickSearchIcon();
            _test.Log(Status.Info, "Search Job title "+ firstjobtitle_CareerexplorerPage);
            Assert.IsTrue(CareerNavigatorPage.NOInActiveJobCard);//Verify Only Active Job Title Card are displayed.  In Active is not displayed
            _test.Log(Status.Pass, "No Job title found");
            CommonSection.Logout();
            _test.Log(Status.Info, "User Logout");
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Admin User");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career page");
            CareersPage.ClickJobTitleTab();
            _test.Log(Status.Info, "Open Job Title Page");
            CareersPage.SearchJobtitlewithShowInactiveItems(firstjobtitle_CareerexplorerPage);
            _test.Log(Status.Info, "Search job tile "+ firstjobtitle_CareerexplorerPage);
            CareersPage.ClickJobtitle(firstjobtitle_CareerexplorerPage);
            _test.Log(Status.Info, "Click Job title");
            CareersPage.JobTitlesTab.SelectStatusActive();
            _test.Log(Status.Info, "Change status inactive to active");

        }
        [Test, Order(3), Category("AutomatedP1")]

        public void c_Select_DeSelect_Star_On_Job_Card_33657()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            _test.Log(Status.Info, "Login with user userreg_0210112911anybrowser");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Open Explorer Career Page");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Career Nevigator page is opend");
            //Assert.IsTrue.CareerNavigatorPage.9JobCards();
            CareerNavigatorPage.JobCardwithStarIcon.HoveronStarIcon(); //Look for the Job Card that has Star Icon and Hover over the Star Icon
            _test.Log(Status.Info, "Mouse hover on job card star icon");
            Assert.IsTrue(CareerNavigatorPage.JobCardwithStarIcon.ToolTip("Save job"));//The Star Icon is in Default Deselected State
            _test.Log(Status.Pass, "Verify tool tip text");
            string jobtitletext = CareerNavigatorPage.JobCards.FirstJobTitle_Name();
            CareerNavigatorPage.JobCardwithStarIcon.ClickStarIcon(); //Select the one with more than one job card
            _test.Log(Status.Info, "Click on star icon ");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            Assert.IsTrue(CareerDevelopmentPage.SavedJobsPortlet.JobCardAdded(jobtitletext)); //Verify only the selected Job Card is displayed in Saved Jobs Portlet
            _test.Log(Status.Pass, "Verify saved job has display on Save Jobs Portlet");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explorer Career Button on RHS");
            CareerNavigatorPage.JobCardwithStarIcon.HoveronStarIcon(); //Look for the Job Card that has Star Icon and Hover over the Star Icon
            _test.Log(Status.Info, "Mouse hover on job card star icon");
            Assert.IsTrue(CareerNavigatorPage.JobCardwithStarIcon.ToolTip("Remove from saved jobs")); //The Star Icon is in Selected State
            _test.Log(Status.Pass, "Verify tool tip text");
            CareerNavigatorPage.JobCardwithStarIcon.ClickStarIcon();
            _test.Log(Status.Info, "Click on star icon ");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            Assert.IsTrue(CareerDevelopmentPage.SavedJobsPortlet.JobCardRemoved("jobtitletext")); //Verify the selected Job Card is removed from in Saved Jobs Portlet
            _test.Log(Status.Pass, "Verify No saved job display on Save Jobs Portlet");
        }
        [Test, Order(4), Category("AutomatedP1")]
        public void d_When_Learner_Views_Job_Card_on_Career_Navigator_33693()
        {
            //login with a new learner 
            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            // after that from learner account give this learner the job title which u created earlier
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();//. dropicon.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            CareerNavigatorPage.JobsDropdown.SelectAllJobs();
            _test.Log(Status.Info, "Slect All from Job DropDown");  // to view all job card
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            Assert.IsTrue(CareerNavigatorPage.Verifyimage("Star Icon"));
            _test.Log(Status.Info, "Verify Star icon on any job card");
            CareerNavigatorPage.ClickShowSearchIcon();
            CareerNavigatorPage.SearchwithJobTitleAs("JobTitle").ClickSearchIcon();
            _test.Log(Status.Info, "Search JobTitle using Search text box");
            Assert.IsTrue(CareerNavigatorPage.isJobCarddisplay());
            _test.Log(Status.Info, "Verify Job Title name on job card");
            Assert.IsTrue(CareerNavigatorPage.JobCards.isLevelDisplay());
            _test.Log(Status.Info, "Verify Level in a Job card");
        }

        [Test, Order(5), Category("AutomatedP1")]
        public void e_Learner_View_Primary_Job_Card_on_Career_Navigator_33694()
        {
            //login with a new learner 
            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            // after that from learner account give this learner the job title which u created as primary 
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0302402440anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinJobDropdown("CP_Demo_2006"));
            //StringAssert.AreEqualIgnoringCase("CP_Demo_2006", CareerNavigatorPage.VerifyValueinJobDropdown("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in Job Dropdownmenu as default selected");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinLevelsDropdown("Demo_Stage 1"));
            //StringAssert.AreEqualIgnoringCase("Demo_Stage 1", CareerNavigatorPage.VerifyValueinLevelsDropdown("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level value = Demo_Stage 1 in Levels Dropdownmenu as default selected");
            Assert.IsTrue(CareerNavigatorPage.VerifyisJobTitledisplay("PrimaryJob_Title_Demo_2006"));
           // Assert.IsTrue(Driver.comparePartialString("PrimaryJob_Title_Demo_2006", CareerNavigatorPage.VerifyJobTitletext("PrimaryJob_Title_Demo_2006")));
            //StringAssert.AreEqualIgnoringCase("PrimaryJOB_Title_Demo_2006", CareerNavigatorPage.VerifyJobTitletext("PrimaryJOB_Title_Demo_2006"));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            StringAssert.AreEqualIgnoringCase("Demo_Stage 1", CareerNavigatorPage.VerifyLeveltext("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.AreEqualIgnoringCase("CP_Demo_2006", CareerNavigatorPage.VerifyCareerPathtext("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in a Job Title job card");
        }

        [Test, Order(6), Category("AutomatedP1")]
        public void f_Learner_View_Secondary_Job_Card_on_Career_Navigator_33695()
        {

            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006,SecondaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1(its for primary) and Level 2 for Secondary job title
            //login with a new learner
            // after that from learner account give this learner the job title which u created as primary and secondary as secondary job title

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
           
            CareerNavigatorPage.JobsDropdown.SelectAllJobs();
            _test.Log(Status.Info, "Select All from jobs drop down");
            CareerNavigatorPage.MoreThan9JobCards.ClickShowMoreButton();
            _test.Log(Status.Info, "Click Show More button to view all (more than 9 Job card)");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Demo_2006");
            _test.Log(Status.Info, "Select CP_Demo_2006 from jobs dropdown");
            StringAssert.Contains("PrimaryJob_Title_Demo_2006", CareerNavigatorPage.VerifytextPrimaryJobCard("PrimaryJob_Title_Demo_2006"));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            StringAssert.Contains("Demo_Stage 1", CareerNavigatorPage.VerifytextPrimaryJobLevel("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.Contains("CP_Demo_2006", CareerNavigatorPage.VerifytextPrimaryJobCareerpath("CP_Demo_2006"));
            //StringAssert.Contains("SecondaryJOB_Title_Demo_2006", CareerNavigatorPage.VerifytextSecondaryJobCard("SecondaryJOB_Title_Demo_2006"));
            _test.Log(Status.Info, "Verify Secondary Job Title name on job card");
            StringAssert.Contains("Level 2", CareerNavigatorPage.VerifytextSecondaryJobLevel("Level 2"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.Contains("CP_Demo_2006", CareerNavigatorPage.VerifytextSecondaryJobCareerpath("CP_Demo_2006"));

        }

        [Test, Order(7), Category("AutomatedP1")]
        public void g_Learner_with_no_job_title_Views_Job_Card_on_Career_Navigator_33696()
        {
            //login with a new learner and dont give any job title to it   userreg_0206411841anybrowser 
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            Assert.IsTrue(CareerNavigatorPage.Verifyimage("Star Icon"));
            _test.Log(Status.Info, "Verify Star icon on any particular job card");
            Assert.IsTrue(CareerNavigatorPage.VerifyResultsdisplay());
           // StringAssert.AreEqualIgnoringCase("JobTitle0209214421", CareerNavigatorPage.Verifyjobtitletext("JobTitle0209214421"));
            _test.Log(Status.Info, "Verify Job Title are display");
            //StringAssert.AreEqualIgnoringCase("Level 1", CareerNavigatorPage.VerifyLeveltext("Level 1"));
            //_test.Log(Status.Info, "Verify Level in a Job Title a particular job card");

        }
        [Test, Order(8), Category("AutomatedP1")]
        public void h_Learner_Views_Job_Details_model_on_Career_Navigator_33704()
        {
            //login with a new learner and dont give any job title to it (run this test with 33696)

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            CareerNavigatorPage.ClickJobtitleName(); //click any job title name on any job card like- PrimaryJOB_Title_Demo_2006
            _test.Log(Status.Info, "Click on job title name on any job card");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyModalName("Save job"));
            _test.Log(Status.Info, "Verify Save job link on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.JobTitleNameDisplay());
            _test.Log(Status.Info, "Verify Job title name on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyCareerPathNameDisplay());
            _test.Log(Status.Info, "Verify Career Path name on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyLevelDisplay());
            _test.Log(Status.Info, "Verify Level name on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyCompetenciesDisplay());
            _test.Log(Status.Info, "Verify Competencies name on Job Details model");
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            _test.Log(Status.Info, "Closed Job Details model");

        }
        [Test, Order(9), Category("AutomatedP1")]
        public void i_Select_Deselect_Star_Icon_On_Job_Details_Modal_33700()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            _test.Log(Status.Info, "Verify Level in a Job Title a particular job card");
            CareerNavigatorPage.ClickJobtitleName(); //Select the one with more than one job card
            _test.Log(Status.Info, "Click On Job Title name");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.SaveJobTextdisplay()); //Verify the text is displayed as Save Job
            _test.Log(Status.Pass, "verify job title details modal is opened");
            CareerNavigatorPage.JobDetailModel.ClickStarIcon(); //Click Star Icon in the modal
            _test.Log(Status.Info, "Click on Star Icon");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.SavedJobsToolTipText("Remove from saved jobs"));
            _test.Log(Status.Pass, "verify tooltip text of star icon");
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            _test.Log(Status.Info, "Close Job title detail modal");
            Assert.IsFalse(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
            _test.Log(Status.Pass, "Verify Modal is closed");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            Assert.IsTrue(CareerDevelopmentPage.SavedJobsPortlet.JobCardAdded("")); //Verify only the selected Job Card is displayed in Saved Jobs Portlet
            _test.Log(Status.Pass, "Verify saved job has display on Save Jobs Portlet");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explorer Career Button on RHS");
            CareerNavigatorPage.ClickJobtitleName();
            _test.Log(Status.Info, "Click on Job title");
            CareerNavigatorPage.JobDetailModel.ClickRemoveFromSavedJobsText(); //Click the text in the modal
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.SavedJobsToolTipText("Remove from saved jobs")); //Verify the text is changed to Save Job
            _test.Log(Status.Pass, "verify tooltip text of star icon");
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            _test.Log(Status.Info, "Close Job title detail modal");
            Assert.IsFalse(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
            _test.Log(Status.Pass, "Verify Modal is closed");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            Assert.IsTrue(CareerDevelopmentPage.SavedJobsPortlet.JobCardRemoved("")); //Verify only the selected Job Card is Removed from Saved Jobs Portlet
            _test.Log(Status.Pass, "Verify No saved job display on Save Jobs Portlet");
        }
        [Test, Order(10), Category("AutomatedP1")]

        public void j_Filter_Results_By_Different_Career_Level_33725()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            _test.Log(Status.Info, "Login with userreg_0210112911anybrowser User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click on Explorer Career button");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Demo_2006");
            _test.Log(Status.Info, "Select CP_Demo_2006 from jobs dropdown");
            CareerNavigatorPage.SelectLevels("Demo_Stage 1"); //Select a Level
            _test.Log(Status.Info, "Select Demo_Stage 1 from Levels dropdown");
            Assert.IsTrue(CareerNavigatorPage.Results.JobCards()); //Verify the JobCards are displayed for the Career Path and Level selected
            _test.Log(Status.Pass, "Verify Job Cards Are display");
            Assert.IsTrue(Driver.comparePartialString("PrimaryJob_Title_Demo_2006", CareerNavigatorPage.VerifyJobTitletext("PrimaryJob_Title_Demo_2006")));
            _test.Log(Status.Pass, "verify PrimaryJobTitle_Demo_2006 jobs card is displaying");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Demo_2006");
            _test.Log(Status.Info, "Select CP_Demo_2006 from jobs dropdown");
            CareerNavigatorPage.SelectLevels("All");
            _test.Log(Status.Info, "Select All from Levels dropdown");
            Assert.IsTrue(CareerNavigatorPage.Results.JobCardsAllLevels()); //Verify the JobCards are displayed for the Career Path for All Levels
            _test.Log(Status.Pass, "Verify Job Cards Are display");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Title_WithnoLevel"); //Look for JobCard where Career Path exists, but no level exists
            _test.Log(Status.Info, "Select CP_Title_WithnoLevel from Levels dropdown");
            Assert.IsFalse(CareerNavigatorPage.Levels.LevelisDisabled()); //Verify the Levels dropdown does not show
            _test.Log(Status.Pass, "Verify Level DropDown is disabled");
            Assert.IsTrue(CareerNavigatorPage.Results.JobCards());
           
        }


        [Test, Order(11), Category("AutomatedP1")]
        public void k_Learner_Filter_Results_by_SavedJobs_33730()
        {
            //login with a new learner 
            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1
            // CommonSection.Logout();
            // LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");

            _test.Log(Status.Info, "Select CareerPathTitle04102309239 from jobs dropdown");
            StringAssert.AreEqualIgnoringCase("JobTitle_ForSavetest", CareerNavigatorPage.VerifyJobTitletext("JobTitle_ForSavetest"));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            CareerNavigatorPage.JobCardwithStarIcon.ClickStarIcon();
            _test.Log(Status.Info, "Click on Star icon on job card");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved", CareerNavigatorPage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message");
            CareerNavigatorPage.ClicklinkfromJobs("Saved Jobs");
            _test.Log(Status.Info, "Select Saved Jobs from jobs dropdown");
            StringAssert.AreEqualIgnoringCase("JobTitle_ForSavetest", CareerNavigatorPage.VerifyJobTitletext("JobTitle_ForSavetest"));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            StringAssert.AreEqualIgnoringCase("rgb(51, 62, 71)", CareerNavigatorPage.VerifyStariconColor("rgb(51, 51, 51)")); //Star Icon as petal color
            _test.Log(Status.Info, "Verify Saved Jobs icon");
            StringAssert.AreEqualIgnoringCase("Level 1", CareerNavigatorPage.VerifyLeveltext("Level 1"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.AreEqualIgnoringCase("CP_ForSave_Test", CareerNavigatorPage.VerifyCareerPathtext("CP_ForSave_Test"));
            _test.Log(Status.Info, "Verify Career Path name in a Job Title job card");

        }

        [Test, Order(12), Category("AutomatedP1")]
        public void l_Learner_Views_SavedJobs_from_CareerDevelopment_Page_33731()
        {
            //login with a new learner 
            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.SavedJobsPortlet.DeleteSaveJobCards();
            _test.Log(Status.Info, "Delete Job Cards if added previously");
            CareerDevelopmentPage.SavedJobsPortlet.ClickAddbuttonfrosmSavedJobs();
            _test.Log(Status.Info, "Click Add Button on on Saved jobs to add jobs");
            StringAssert.AreEqualIgnoringCase("Add Jobs", CareerDevelopmentPage.AddJobsmodelwindow.VerifyJobmodelTitleText("Add Jobs"));
            _test.Log(Status.Info, "Verify model window page title");
            CareerDevelopmentPage.AddJobsmodelwindow.SearchTextwith("JobTitle_ForSavetest");
            _test.Log(Status.Info, "Search job title with name -JobTitle_ForSavetest ");
            CareerDevelopmentPage.AddJobsmodelwindow.SelectrecordandAdd("JobTitle_ForSavetest");
            _test.Log(Status.Info, "Select and click on add");
            StringAssert.AreEqualIgnoringCase("JobTitle_ForSavetest", CareerDevelopmentPage.SavedJobsPortlet.VerifyaddedjobtitleText("JobTitle_ForSavetest"));
            _test.Log(Status.Info, "Verify Saved jobs");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            CareerNavigatorPage.ClicklinkfromJobs("Saved Jobs");
            _test.Log(Status.Info, "Select Saved Jobs from jobs dropdown");
            StringAssert.AreEqualIgnoringCase("JobTitle_ForSavetest", CareerNavigatorPage.VerifyJobTitletext("JobTitle_ForSavetest"));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            StringAssert.AreEqualIgnoringCase("rgb(51, 62, 71)", CareerNavigatorPage.VerifyStariconColor("rgb(51, 62, 71)"));
            _test.Log(Status.Info, "Verify Saved Jobs icon");
            StringAssert.AreEqualIgnoringCase("Level 1", CareerNavigatorPage.VerifyLeveltext("Level 1"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.AreEqualIgnoringCase("CP_ForSave_Test", CareerNavigatorPage.VerifyCareerPathtext("CP_ForSave_Test"));
            _test.Log(Status.Info, "Verify Career Path name in a Job Title job card");
            CareerNavigatorPage.JobCards.ClickStartIcon();
        }

        [Test, Order(13), Category("AutomatedP1")]
        public void m_Filter_Results_by_different_Career_Path_33748()
        {
            //login with a new learner 
            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0302402440anybrowser").WithPassword("").Login();

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Demo_2006");
            _test.Log(Status.Info, "Select CP_Demo_2006 from jobs dropdown");
            Assert.IsTrue(Driver.comparePartialString("PrimaryJob_Title_Demo_2006", CareerNavigatorPage.VerifyJobTitletext("PrimaryJob_Title_Demo_2006")));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinJobDropdown("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in Job Dropdownmenu ");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinLevelsDropdown("All"));
            _test.Log(Status.Info, "Verify Value All in Levels drop down menu ");
            StringAssert.AreEqualIgnoringCase("Demo_Stage 1", CareerNavigatorPage.VerifyLeveltext("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.AreEqualIgnoringCase("CP_Demo_2006", CareerNavigatorPage.VerifyCareerPathtext("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in a Job Title job card");
        }
        [Test, Order(14), Category("AutomatedP1")]
        public void n_Filter_by_Career_paths_with_no_competencies_should_not_show_in_the_list_33749()
        {
            //login with a new learner 
            //Prereq- By Admin user create a Job title without any competencies and then create a new career path, add that job title(without competency) in this career path
            //like name career path as CP_witnout_competency
           // CommonSection.Logout();
           // LoginPage.LoginAs("userreg_0302402440anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            CareerNavigatorPage.ClickJobsDropDown();
            _test.Log(Status.Info, "Click on Jobs drop down");
            Assert.IsFalse(CareerNavigatorPage.VerifyValueinJobDropdown("CP_witnout_competency"));
            // Assert.notEqualIgnoringCase("CP_witnout_competency", CareerNavigatorPage.VerifyValueintexixtinDropdown("CP_witnout_competency"));
            _test.Log(Status.Info, "Verify that competency CP_witnout_competency not appear in listing");

        }
        [Test, Order(15), Category("AutomatedP1")]
        public void o_Learner_Selects_AllJobs_in_the_Dropdown_menu_33750()
        {

            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006,SecondaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1(its for primary) and Level 2 for Secondary job title
            //login with a new learner
            // after that from learner account give this learner the job title which u created as primary and secondary as secondary job title
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0302402440anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinJobDropdown("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in Job Dropdownmenu as default selected");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinLevelsDropdown("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level value = Demo_Stage 1 in Levels Dropdownmenu as default selected");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinLevelsDropdown("All"));
            _test.Log(Status.Info, "Verify Value All in Levels drop down menu ");
            CareerNavigatorPage.ClicklinkfromJobs("All");
            _test.Log(Status.Info, "Select All from jobs dropdown");
            CareerNavigatorPage.MoreThan9JobCards.ClickShowMoreButton();
            _test.Log(Status.Info, "Click on Show More button to view all jobs on page");
            // Assert.IsTrue(CareerNavigatorPage.VerifyValueinLevelsDropdown("All"));
            // _test.Log(Status.Info, "Verify Value All in Levels drop down menu ");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Demo_2006");
            StringAssert.AreEqualIgnoringCase("PrimaryJob_Title_Demo_2006", CareerNavigatorPage.VerifytextPrimaryJobCard("Primary_Job_Title_Demo_2006"));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            StringAssert.AreEqualIgnoringCase("Demo_Stage 1", CareerNavigatorPage.VerifytextPrimaryJobLevel("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.AreEqualIgnoringCase("CP_Demo_2006", CareerNavigatorPage.VerifytextPrimaryJobCareerpath("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in a Job Title job card");
           
            //StringAssert.AreEqualIgnoringCase("SecondaryJOB_Title_Demo_2006", CareerNavigatorPage.VerifytextSecondaryJobCard("SecondaryJOB_Title_Demo_2006"));
            //_test.Log(Status.Info, "Verify Secondary Job Title name on job card");
            //StringAssert.AreEqualIgnoringCase("Demo_Stage 2", CareerNavigatorPage.VerifytextSecondaryJobLevel("Demo_Stage 2"));
            //_test.Log(Status.Info, "Verify Level in a Job Title job card");
            //StringAssert.AreEqualIgnoringCase("CP_Demo_2006", CareerNavigatorPage.VerifytextSecondaryJobCareerpath("CP_Demo_2006"));

        }
        [Test, Order(16), Category("AutomatedP1")]
        public void p_Learner_Views_Default_Filtered_Job_REsults_in_Career_Navigator_33757()
        {
            //login with a new learner 
            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            // after that from learner account give this learner the job title which u created 
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1
            //CommonSection.Logout();
           // LoginPage.LoginAs("userreg_0302402440anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinJobDropdown("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in Job Dropdownmenu as default selected");
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinLevelsDropdown("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level value = Demo_Stage 1 in Levels Dropdownmenu as default selected");
            Assert.IsTrue(CareerNavigatorPage.VerifyisJobTitledisplay("PrimaryJOB_Title_Demo_2006"));
            //Assert.IsTrue(Driver.comparePartialString("PrimaryJobTitle_Demo_2006", CareerNavigatorPage.VerifyJobTitletext("PrimaryJOB_Title_Demo_2006")));
            _test.Log(Status.Info, "Verify Job Title name on job card");
            StringAssert.AreEqualIgnoringCase("Demo_Stage 1", CareerNavigatorPage.VerifyLeveltext("Demo_Stage 1"));
            _test.Log(Status.Info, "Verify Level in a Job Title job card");
            StringAssert.AreEqualIgnoringCase("CP_Demo_2006", CareerNavigatorPage.VerifyCareerPathtext("CP_Demo_2006"));
            _test.Log(Status.Info, "Verify Career Path name in a Job Title job card");
        }
        [Test, Order(17), Category("AutomatedP1")]

        public void q_View_List_Of_Competencies_33755()
        //Prerequisite: Job Title must have assigned competencies

        {
             CommonSection.Logout();
           LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            _test.Log(Status.Info, "Verify Level in a Job Title a particular job card");
            CareerNavigatorPage.ClickJobtitleName(); //click any job title name on any job card like- PrimaryJOB_Title_Demo_2006
            _test.Log(Status.Info, "Click on job title name on any job card");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyModalName("Save job"));
            _test.Log(Status.Info, "Verify Save job link on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.JobTitleNameDisplay());
            _test.Log(Status.Info, "Verify Job title name on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyCareerPathNameDisplay());
            _test.Log(Status.Info, "Verify Career Path name on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyLevelDisplay());
            _test.Log(Status.Info, "Verify Level name on Job Details model");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyCompetenciesDisplay());
            _test.Log(Status.Info, "Verify Competencies name on Job Details model");
            //CareerNavigatorPage.JobCard.ClickJobTitle();
            // Assert.IsTrue.(JobTitleModal.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyCompetenciesInProgressTabCount()); //Verify the Competencies list has InProgress Tab with Count
                                                                                                      // Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyCompetenciesCompleteTabCount()); //Verify the Competencies list has Complete Tab with count
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
           // Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetenciesInProgressName("Competency Name"));
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetenciesInProgressRating("Competency Rating"));
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetenciesInProgressProgress("Competency Progress"));
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesCompleteTab();
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            _test.Log(Status.Info, "Closed Job Details model");
        }
       
        [Test, Order(18), Category("AutomatedP1")]

        public void r_Add_Job_On_Landing_Page_Portlet_33764()
        //Prequisite: Job titles exist that have competencies assigned to them. Login with a new Learner

        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(CareerDevelopmentPage.CareerDevelopment());
            _test.Log(Status.Info, "Open Career Development Page and Verify Page Title");
            CareerDevelopmentPage.SavedJobsPortlet.ClickAddbuttonfrosmSavedJobs(); // Click Add on the Saved Jobs portlet
            _test.Log(Status.Info, "Click on Add button in Save Job Portlet");
            StringAssert.AreEqualIgnoringCase("Add Jobs", CareerDevelopmentPage.AddJobsmodelwindow.VerifyJobmodelTitleText("Add Jobs")); // Verify the Add Jobs Modal is displayed
            _test.Log(Status.Info, "Verify Add Job Model is opened");
            Assert.IsTrue(CareerDevelopmentPage.AddJobsmodelwindow.NameColumn("Name", "Path", "Level", "Competencies")); // Verify the Name Column is displayed in the modal
          //  Assert.IsTrue(CareerDevelopmentPage.AddJobsmodelwindow.PathColumn("Path")); // Verify the Path Column is displayed in the modal
          //  Assert.IsTrue(CareerDevelopmentPage.AddJobsmodelwindow.LevelColumn("Level")); // Verify the Level Column is displayed in the modal
          //  Assert.IsTrue(CareerDevelopmentPage.AddJobsmodelwindow.CompetenciesColumn("Competencies")); // Verify the Competencies Column is displayed in the modal
            _test.Log(Status.Info, "Verify Name, Path, Level and Competencies Colomn Display on Add Job Model");
            CareerDevelopmentPage.AddJobsmodelwindow.SearchTextwith("JobTitle");
            _test.Log(Status.Info, "Search for the Job Titles");
            string jobtitletext = CareerDevelopmentPage.AddJobsmodelwindow.Jobtitletext();
            CareerDevelopmentPage.AddJobsmodelwindow.SelectrecordandAdd("JobTitle_ForSavetest");
            _test.Log(Status.Info, "Select Job Title and click on Add Button");

            //Assert.IsTrue(CareerDevelopmentPage.AddJobsmodelwindow.IsClosed); //Verify the Modal is closed
            Assert.IsTrue(CareerDevelopmentPage.SavedJobsPortlet.JobCardAdded(jobtitletext));  //Verify the Jobs are saved in Saved Jobs Portlet
            Assert.IsTrue(CareerDevelopmentPage.SavedJobsPortlet.JobsSaved.NamePathLevelCompetencies()); //Verify for each job added, the Saved Jobs portlet now displays: Name, Path, Level, and number of Competencies
            CareerDevelopmentPage.ClickExploreCareersbutton();
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            CareerNavigatorPage.ClicklinkfromJobs("Saved Jobs");
            _test.Log(Status.Info, "Select Saved Jobs from jobs dropdown");
            StringAssert.AreEqualIgnoringCase(jobtitletext, CareerNavigatorPage.VerifyJobTitletext(jobtitletext));
            _test.Log(Status.Info, "Verify Saved Job Title name on job card");
           
            CareerNavigatorPage.JobCards.ClickStartIcon();
            _test.Log(Status.Info, "Remove Saved Job");  // added by somnath because we need to run this script multiple time.

        }
        [Test, Order(19), Category("AutomatedP1")]
        public void s_Learner_Clears_Filteres__show_totheir_default_Job_REsults_33768()
        {
            //login with a new learner 
            //with admin user create a job title, then create a career path in which include created job title and create level in that.
            // after that from learner account give this learner the job title which u created 
            //Create Jobtitle with name - PrimaryJOB_Title_Demo_2006, Career Path = CP_Demo_2006 and Level = Demo_Stage 1
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            CareerNavigatorPage.ClicklinkfromJobs("All");
            _test.Log(Status.Info, "Select job as All");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Demo_2006");
            _test.Log(Status.Info, "Select any career path");
            Assert.IsTrue(CareerNavigatorPage.Showmyjoblinkdisplay);
            _test.Log(Status.Info, "Verify Show my job link is displaying");
            CareerNavigatorPage.ClickShowmyjob();
            Assert.IsTrue(CareerNavigatorPage.VerifyResultsdisplay());
            _test.Log(Status.Info, "Verify job filter removed and result/jobcards are displayed");
            CareerNavigatorPage.MoreThan9JobCards.ShowMoreButton();
            _test.Log(Status.Info, "Verify Show More button display on result page");
            CareerNavigatorPage.MoreThan9JobCards.ClickShowMoreButton();
            _test.Log(Status.Info, "Click on Show More button");
            Assert.IsTrue(CareerNavigatorPage.verifymorethan9jobsaredisplay());
            
            _test.Log(Status.Info, "Verify More than 9 jobs are display");
           
        }
        [Test, Order(20), Category("AutomatedP1")]

        public void t_View_Progress_Indicator_on_Job_Cards_33825()
        //Prequisite: Job titles exist that have competencies assigned to them.

        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            _test.Log(Status.Info, "Login with userreg_0210112911anybrowser User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Nevigating to Career Development Page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click on Explorer Career Button");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Vareer Nevegator Page is opened");
            Assert.IsTrue(CareerNavigatorPage.MoreThan9JobCards.ShowMoreButton());
            _test.Log(Status.Pass, "Verify Show More button is display");
            Assert.IsTrue(CareerNavigatorPage.JobCards.ProgressBar()); //Verify Progress Bar animate in on page load and indicate how much progress a learner has made
            _test.Log(Status.Pass, "Verify Job card has Progess indicator");
            CareerNavigatorPage.JobCards.HoverOverProgressBar();
            _test.Log(Status.Info, "mouce hover on Progress indevator bar");
            Assert.IsTrue(CareerNavigatorPage.JobCards.ToolTipwithProgress());//Verify the Tool Tip with Progress is displayed when we hover over the Progress Bar
            _test.Log(Status.Pass, "Verify tool tip text");
            //CareerNavigatorPage.JobCards._100PercentComplete();
            Assert.IsTrue(CareerNavigatorPage.JobCards.TextDisplays("100%Complete")); //Verify if 100% of competencies have been completed, "100%" text displays on the progress bar
            _test.Log(Status.Pass, "Verify tooltip text");
            //   CareerNavigatorPage.JobCards.NoCompletionCriteria(); //Select the Job Title that contains no completion criteria (no rating and no required content)
            //  Assert.IsTrue(CareerNavigatorPage.JobCards.InComplete());//Verify the Job Card is never listed as Complete and the User will never satisfy completing a competencies associated to Job Title.


        }
        [Test, Order(21), Category("AutomatedP1")]

        public void u_Navigate_To_Another_Career_Level_Where_There_Are_Multiple_Levels_33827()
        //Prerequisite: Career Path exists, Career Level Exists, and there is another level above and/or below the current level shown in the grid that includes atleast one Job Title

        {
           // CommonSection.Logout();
           // LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
           // _test.Log(Status.Info, "Login with userreg_0210112911anybrowser User");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click on Explorer Career button");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Career Explorer page");
           // Assert.IsTrue(CareerNavigatorPage._9JobCards());
            CareerNavigatorPage.ClicklinkfromJobs("CP_Demo_2006");
            _test.Log(Status.Info, "Select any career path");
            //CareerNavigatorPage.Jobs.ClickCareerPathdropdown.SelectCareerPathWithMultipleLevels("Career Path"); //Select a Career Path which contains multiple levels
            Assert.IsTrue(CareerNavigatorPage.VerifyValueinLevelsDropdown("All"));
            _test.Log(Status.Pass, "Verify Value All in Levels drop down menu ");
            StringAssert.AreEqualIgnoringCase("Demo_Stage 1", CareerNavigatorPage.VerifyLeveltext("Demo_Stage "));
            _test.Log(Status.Info, "Verify Level in a Job Title job card"); //Verify only levels that have jobs, appear in the dropdown 
            CareerNavigatorPage.SelectLevels("Demo_Stage 1"); //Select a Level
            Assert.IsTrue(CareerNavigatorPage.Results.JobCards()); //Verify the JobCards are displayed for the Career Path and Level selected
            _test.Log(Status.Pass, "Verify Job Card");
            //Assert.IsTrue(CareerNavigatorPage.Results.JobCardsAlphabeticallyByJobTitle()); //Verify the jobCards are displayed alphabetically by JobTitle
            CareerNavigatorPage.Levels.ClickNextLevel(); //Click on Forward arrow UI
            Assert.IsTrue(CareerNavigatorPage.Results.JobCards());// Verify clicking on the forward arrow shows job cards in the next level up in the selected career path. 
                                                                  // CareerNavigatorPage.Levels.ClickNextLevel.HighestLevel();
            Assert.IsFalse(CareerNavigatorPage.Levels.NextLevelDisabled());//Verify when viewing jobs in the highest level, the forward arrow is disabled.
            CareerNavigatorPage.Levels.ClickPreviousLevel();//Click on Back arrow UI on either side of the level filter dropdown
            Assert.IsTrue(CareerNavigatorPage.Results.JobCards());//Verify clicking on the back arrow shows job cards in the previous level in the selected career path. 
            CareerNavigatorPage.SelectLevels("All"); // select lowest level
            _test.Log(Status.Info, "Select All from dropdown");
            Assert.IsFalse(CareerNavigatorPage.Levels.PreviousLevelDisabled());// Verify when viewing jobs in the lowest level, the back arrow is disabled
            _test.Log(Status.Pass, "Verify Previous level is disabled");
        }
        [Test, Order(22), Category("AutomatedP1")]

        public void v_Learner_Met_Required_Rating_Completed_Required_Content_Recommended_Content_Does_Not_Matter_33830()
        //Prerequisite: Job Title must have assigned competencies which includes the Proficiency Scales, has Required Content, and has Recommended Content 
        {
           // CommonSection.Logout(); 
           // LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            //_test.Log(Status.Info, "Login with userreg_0210112911anybrowser User.");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Nevigating to Career Development Page");
            CareerDevelopmentPage.ClickCompetenciesWithCompletedRatings();
            Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            _test.Log(Status.Pass, "Verify Competency Modal is display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent();
            Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent(); //Complete all Required Content associated

            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Nevigate to Career Development Page");
            Assert.IsTrue(CareerDevelopmentPage.Competency.StatusIsComplete());//Verify the Competency listed as “Complete” on Career Development page
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Exporer Career Button");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");
            CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            _test.Log(Status.Info, "Click on Job Title");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            _test.Log(Status.Pass, "Verify In progress tab display in Job Details Modal");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay); //Verify the Competencies list has Complete Tab with count
            _test.Log(Status.Pass, "Verify Completed tab display in Job Details Modal");
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesCompleteTab();
            _test.Log(Status.Info, "Click on Complete tab");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.Complete());//Verify the Progress Bar is displayed as Complete
            _test.Log(Status.Pass, "Verify Complete Progress is display");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.ToolTipText("100% Completed"));//Verify the Progress Bar text is displayed as 100% Complete
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            _test.Log(Status.Info, "Close Job Title Modal");
           
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
        }

        [Test, Order(23), Category("AutomatedP1")]

        public void w_Learner_NOT_Met_Required_Rating_Completed_Required_Content_Recommended_Content_Does_Not_Matter_33831()
        //Prerequisite: Job Title must have assigned competencies which includes the Proficiency Scales, has Required Content, and has Recommended Content 
        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Nevigate to Career Development Page");
           

            // CareerDevelopmentPage.ClicktoCompetenciesWithCompletedRatings("CompetencyTitle0703424142");
            CareerDevelopmentPage.ClicktoCompetenciesWithCompletedRatings("Competency Test 1");

            _test.Log(Status.Info, "Click on Competencies with Complete Ratings");
            Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            _test.Log(Status.Pass, "Verify Competency Modal Display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent();
            Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            _test.Log(Status.Pass, "Verify Content Details page opened");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent(); //Complete all Required Content associated
            CommonSection.Learn.CareerDevelopment();
            //Assert.IsTrue(CareerDevelopmentPage.Competency.InComplete());//Verify the Competency listed as “InComplete” on Career Development page
           // _test.Log(Status.Pass, "Verify incomplete Competency");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");
            CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            _test.Log(Status.Pass, "Verify list of Competency Display");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay); //Verify the Competencies list has Complete Tab with count
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as InComplete
            CareerNavigatorPage.JobDetailModel.ModelClosed();
           
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
        }

        [Test, Order(24), Category("AutomatedP1")]

        public void x_Learner_Met_Required_Rating_NOT_Completed_Required_Content_Recommended_Content_Does_Not_Matter_33832()
        //Prerequisite: Job Title must have assigned competencies which includes the Proficiency Scales, has Required Content, and has Recommended Content 
        {
            // CommonSection.Logout();
            // LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();

            CommonSection.Learn.CareerDevelopment();
            CareerDevelopmentPage.ClicktoCompetenciesWithCompletedRatings("CompetencyTitle1310330233");
            Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            _test.Log(Status.Pass, "Verify Competency Modal Display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent();
            Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            _test.Log(Status.Pass, "Verify Content Details page opened");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent();//Do not complete Mandatory Content
            CommonSection.Learn.CareerDevelopment();
            //Assert.IsTrue(CareerDevelopmentPage.Competency.InComplete());//Verify the Competency listed as “InComplete” on Career Development page
            CareerDevelopmentPage.ClickExploreCareersbutton();
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");
            CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            _test.Log(Status.Pass, "Verify List of Competencies display");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay); //Verify the Competencies list has Complete Tab with count
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            _test.Log(Status.Pass, "Verify Competencies display in Progress tab");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as InComplete
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));

        }

        [Test, Order(25), Category("AutomatedP1")]

        public void y_Learner_NOT_Met_Required_Rating_NOT_Completed_Required_Content_Recommended_Content_Does_Not_Matter_33833()
        //Prerequisite: Job Title must have assigned competencies which includes the Proficiency Scales, has Required Content, and has Recommended Content 
        {
            CommonSection.Learn.CareerDevelopment();
            CareerDevelopmentPage.ClicktoCompetenciesWithCompletedRatings("CompetencyTitle1310330233");
            Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            _test.Log(Status.Pass, "Verify Competency Modal Display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent();
            Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            _test.Log(Status.Pass, "Verify Content Details page opened");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent();//Do not complete Mandatory Content
            CommonSection.Learn.CareerDevelopment();
           // Assert.IsTrue(CareerDevelopmentPage.Competency.InComplete()); //Verify the Competency listed as “InComplete” on Career Development page
            CareerDevelopmentPage.ClickExploreCareersbutton();
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");
            CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay);//Verify the Competencies list has Complete Tab with count
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            _test.Log(Status.Pass, "Verify Competencies display in Progress tab");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as InComplete
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));

        }

        [Test, Order(26), Category("AutomatedP1")]

        public void z_Learner_Met_Required_Rating_Recommended_Content_Does_Not_Matter_33834()
        //Prerequisite: Job Title must have assigned competencies which includes the Proficiency Scales, has No Required Content, and has Recommended Content 
        {

            //CommonSection.Logout();
            //LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();

            CommonSection.Learn.CareerDevelopment();
            CareerDevelopmentPage.ClicktoCompetenciesWithCompletedRatings("CompetencyTitle1310330233");
            Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            _test.Log(Status.Pass, "Verify Competency Modal Display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.NoMandatoryContent();//Does not have Mandatory Content
            //Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            //_test.Log(Status.Pass, "Verify Content Details page opened");
            //AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent();
            CommonSection.Learn.CareerDevelopment();
           // Assert.IsTrue(CareerDevelopmentPage.Competency.StatusIsComplete());//Verify the Competency listed as “Complete” on Career Development page as there is no Required Content
            CareerDevelopmentPage.ClickExploreCareersbutton();
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");
            CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies);  //Verify the Job Title modal displays with list of competencies
            _test.Log(Status.Pass, "Verify List of Competencies display");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay); //Verify the Competencies list has InProgress Tab with count
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay); //Verify the Competencies list has Complete Tab with count
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesCompleteTab();
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as Complete
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));

        }

        [Test, Order(27), Category("AutomatedP1")]

        public void za_Learner_NOT_Met_Required_Rating_Recommended_Content_Does_Not_Matter_33835()
        //Prerequisite: Job Title must have assigned competencies which includes the Proficiency Scales, has No Required Content, and has Recommended Content 
        {
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open career Development Page");
            CareerDevelopmentPage.ClicktoCompetenciesWithCompletedRatings("CompetencyTitle1310330233");// ClickCompetenciesWithInCompleteRatings();
            _test.Log(Status.Info, "Click on Competency having In Complete Ratings");
            Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            _test.Log(Status.Pass, "verify Compentency Modal is display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent();//Does not have Mandatory Content
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent();
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open career Development Page");
           // Assert.IsTrue(CareerDevelopmentPage.Competency.InComplete());//Verify the Competency listed as “InComplete” on Career Development page
            _test.Log(Status.Info, "Verify status is incomplete");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click on Career Explorer Button");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
            CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            _test.Log(Status.Info, "Click on Job Title");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            _test.Log(Status.Pass, "Verify Competencies are display on Modal");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            _test.Log(Status.Pass, "Verify ompetency InProgress Tab Display");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay);//Verify the Competencies list has Complete Tab with count
            _test.Log(Status.Pass, "Verify ompetency InProgress Tab Display");
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            _test.Log(Status.Info, "Click on In Progress Tab");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as InComplete
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            _test.Log(Status.Info, "Close the Job Title modal");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
           // _test.Log(Status.Pass, "Verify Job Title Modal is closed");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Career Nevigator Page is opened");

        }

        [Test, Order(28), Category("AutomatedP1")]

        public void zb_Learner_Completed_Required_Content_Recommended_Content_Does_Not_Matter_33836()
        //Prerequisite: Job Title must have assigned competencies which DOES NOT includes the Proficiency Scales, has Required Content, and has Recommended Content 
        {
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout from site");  
            //LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            //_test.Log(Status.Info, "Login with user as userreg_0210112911anybrowser");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open career Development Page");
            CareerDevelopmentPage.ClickCompetenciesWithNoRatings();
            _test.Log(Status.Info, "Click on Competency having In No Ratings");
            Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            _test.Log(Status.Pass, "verify Compentency Modal is display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent();
            _test.Log(Status.Info, "Click on Mandatory Content");
            Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent(); //Complete all Required Content associated
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open career Development Page");
            //Assert.IsTrue(CareerDevelopmentPage.Competency.StatusIsCompleteForCompetencywithoutrating()); //Verify the Competency listed as “Complete” on Career Development page
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explorer Career Button");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
            CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            _test.Log(Status.Info, "Click on Job Title");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            _test.Log(Status.Pass, "Verify Competencies are display on Modal");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            _test.Log(Status.Pass, "Verify ompetency InProgress Tab Display");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay);//Verify the Competencies list has Complete Tab with count
            _test.Log(Status.Pass, "Verify ompetency InProgress Tab Display");
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesCompleteTab();
            _test.Log(Status.Info, "Click on In Complete Tab");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.Complete());//Verify the Progress Bar is displayed as Complete
            CareerNavigatorPage.JobDetailModel.ModelClosed();
            _test.Log(Status.Info, "Close the Job Title modal");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
           // _test.Log(Status.Pass, "Verify Job Title Modal is closed");
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
        }

        [Test, Order(29), Category("AutomatedP1")]

        public void zc_Learner_NOT_Completed_Required_Content_Recommended_Content_Does_Not_Matter_33837()
        //Prerequisite: Job Title must have assigned competencies which DOES NOT includes the Proficiency Scales, has Required Content, and has Recommended Content 
        {
            Assert.IsTrue(true);  // This test cann't be automated due to prerequisite
            //CommonSection.Learn.CareerDevelopment();

            //CareerDevelopmentPage.ClickCompetenciesWithNoRatings();
            //_test.Log(Status.Info, "Click on Competency having No Ratings");
            //Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            //_test.Log(Status.Pass, "verify Compentency Modal is display");
            //CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent();//Do not complete Mandatory Content

            //Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            //AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent();
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open career Development Page");
            //Assert.IsTrue(CareerDevelopmentPage.Competency.InComplete());//Verify the Competency listed as “InComplete” on Career Development page
            //_test.Log(Status.Info, "Verify status is incomplete");
            //CareerDevelopmentPage.ClickExploreCareersbutton();
            //_test.Log(Status.Info, "Click on Career Explorer Button");
            //StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            //_test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
            //CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay);//Verify the Competencies list has Complete Tab with count
            //CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            //Assert.IsFalse(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as InComplete
            //CareerNavigatorPage.JobDetailModel.ModelClosed();
            //_test.Log(Status.Info, "Close the Job Title modal");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
            //_test.Log(Status.Pass, "Verify Job Title Modal is closed");
            //StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            //_test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
        }

        [Test, Order(30), Category("AutomatedP1")]

        public void zd_Learner_Completed_OR_NotCompleted_Recommended_Content_Does_Not_Matter_33838()
        //Prerequisite: Job Title must have assigned competencies which DOES NOT includes the Proficiency Scales, has No Required Content, and has Recommended Content 
        {
            Assert.IsTrue(true);  // This test cann't be automated due to prerequisite
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open career Development Page");
            //CareerDevelopmentPage.ClickCompetenciesWithNoRatings();
            //_test.Log(Status.Info, "Click on Competency having No Ratings");
            //Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            //_test.Log(Status.Pass, "verify Compentency Modal is display");
            //// CompetencyModal.MandatoryTab.NoMandatoryContent();//No Mandatory Content exists
            //CareerDevelopmentPage.CompetencyModal.MandatoryTab.NoMandatoryContent();//Recommended Content exists
            //Assert.IsTrue(AdminContentDetailsPage.ContentDetailsPageOpened());
            //AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent();
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open career Development Page");
            //Assert.IsTrue(CareerDevelopmentPage.Competency.InComplete());//Verify the Competency listed as “InComplete” on Career Development page
            //_test.Log(Status.Info, "Verify status is incomplete");
            //CareerDevelopmentPage.ClickExploreCareersbutton();
            //_test.Log(Status.Info, "Click on Career Explorer Button");
            //StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            //_test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
            //CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            //_test.Log(Status.Info, "Click on Job Title");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            //_test.Log(Status.Pass, "Verify Competencies are display on Modal");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            //_test.Log(Status.Pass, "Verify ompetency InProgress Tab Display");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay);//Verify the Competencies list has Complete Tab with count
            //_test.Log(Status.Pass, "Verify ompetency InProgress Tab Display");
            //CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            //_test.Log(Status.Info, "Click on In Progress Tab");
            //Assert.IsFalse(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as InComplete
            //CareerNavigatorPage.JobDetailModel.ModelClosed();
            //_test.Log(Status.Info, "Close the Job Title modal");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
            //_test.Log(Status.Pass, "Verify Job Title Modal is closed");
            //StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            //_test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
        }
        [Test, Order(31), Category("AutomatedP1")]
        public void ze_Learner_Not_Completed_Any_Content_And_No_Completion_Requirement_33840()
        //Prerequisite: Job Title must have assigned competencies which DOES NOT includes the Proficiency Scales, has No Required Content, and NO Recommended Content 
        {
            Assert.IsTrue(true);  // This test cann't be automated due to prerequisite
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open career Development Page");
            //CareerDevelopmentPage.ClickCompetenciesWithNoRatings();
            //_test.Log(Status.Info, "Click on Competency having No Ratings");
            //Assert.IsTrue(CareerDevelopmentPage.CompetencyModal.Display());
            //_test.Log(Status.Pass, "verify Compentency Modal is display");
            //CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent(); //No Mandatory Content exists
            //// CareerDevelopmentPage.CompetencyModal.SupplementTab.NoMandatoryContent();//No Recommended Content exists
            //AdminContentDetailsPage.ClickOpenNewAttemptbutton.NotCompleteContent();
            //CommonSection.Learn.CareerDevelopment();
            //_test.Log(Status.Info, "Open career Development Page");
            //Assert.IsTrue(CareerDevelopmentPage.Competency.InComplete());//Verify the Competency listed as “InComplete” on Career Development page
            //_test.Log(Status.Info, "Verify status is incomplete");
            //CareerDevelopmentPage.ClickExploreCareersbutton();
            //_test.Log(Status.Info, "Click on Career Explorer Button");
            //StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            //_test.Log(Status.Pass, "Verify Career Nevigator Page is opened");
            //CareerNavigatorPage.JobCards.ClickJobTitle();//Select the JobTitle associated to the Competency
            //_test.Log(Status.Info, "Click on Job Title");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ListofCompetencies); //Verify the Job Title modal displays with list of competencies
            //_test.Log(Status.Pass, "Verify Competencies are display on Modal");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyInProgressTabDisplay);//Verify the Competencies list has InProgress Tab with count
            //_test.Log(Status.Pass, "Verify ompetency InProgress Tab Display");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.CompetencyCompleteTabDisplay);//Verify the Competencies list has Complete Tab with count
            //_test.Log(Status.Pass, "Verify Competency Complete Tab Display");
            //CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            //_test.Log(Status.Info, "Click on In Progress Tab");
            //Assert.IsFalse(CareerNavigatorPage.JobDetailModel.CompleteTab.ProgressBar.InComplete());//Verify the Progress Bar is displayed as InComplete
            //// JobTitleModal.ListofCompetencies.ClickInProgressTab();
            //// Assert.IsTrue(JobTitleModal.ListofCompetencies.InProgressTab.ProgressBar.Incomplete);//Verify the Progress Bar is displayed as InComplete
            //CareerNavigatorPage.JobDetailModel.ModelClosed();
            //_test.Log(Status.Info, "Close the Job Title modal");
            //Assert.IsTrue(CareerNavigatorPage.JobDetailModel.ModalIsClosed());
            //_test.Log(Status.Pass, "Verify Job Title Modal is closed");
            //StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            //_test.Log(Status.Pass, "Verify Career Nevigator Page is opened");

        }
        [Test, Order(32), Category("AutomatedP1")]

        public void zf_Learner_Navigates_Between_Job_Details_Competency_Details_And_Content_Details_33990()
        {

            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
           
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");
            CareerNavigatorPage.ClickJobtitleName(); //Click on the JobCard 
            _test.Log(Status.Info, "Click on job title name on any job card");
            CareerNavigatorPage.JobDetailModel.Competencies.InProgressTab.ClickCompetencyTitle();// From Job Details page Click one of the Competency Title
            _test.Log(Status.Info, "Click on Inprogress conpetency ttle");
            Assert.IsTrue(CareerNavigatorPage.CompetencyDetailsModaldisplay()); //Verify Competency Details Modal is displayed
            _test.Log(Status.Pass, "Verify Competency Details Modal is display");
            CareerDevelopmentPage.CompetencyModal.MandatoryTab.ClickMandatoryContent(); // Click on the Content Title from Competency Details Modal Mandatory Tab
            Assert.IsTrue(ContentDetailsPage.ContentDetailsPageOpened()); //Verify Content Details Page is displayed
            ContentDetailsPage.ClickBrowserBackButton();
            StringAssert.AreEqualIgnoringCase("Career Explorer", CareerNavigatorPage.VerifySearchText("Career Explorer"));
            _test.Log(Status.Info, "Verify Career Explorer page");
            CareerNavigatorPage.ClicklinkfromJobs("CP_ForSave_Test");
            CareerNavigatorPage.ClickJobtitleName(); //Click on the JobCard 
            _test.Log(Status.Info, "Click on job title name on any job card");
            CareerNavigatorPage.JobDetailModel.Competencies.InProgressTab.ClickCompetencyTitle();// From Job Details page Click one of the Competency Title
            _test.Log(Status.Info, "Click on Inprogress conpetency title");
            Assert.IsTrue(CareerNavigatorPage.CompetencyDetailsModaldisplay()); //Verify Competency Details Modal is displayed
            _test.Log(Status.Pass, "Verify Competency Details Modal is display");
            CareerNavigatorPage.CompetencyDetailsModal.ClickBackArrow();//Click Browser back button or back arrow button from Competency Detail Modal
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyModalName("Save job"));
            _test.Log(Status.Info, "Verify Save job link on Job Details model");
            CareerNavigatorPage.JobDetailModel.ModelClosed();
        }
        [Test, Order(33), Category("AutomatedP1")]
        public void zg_Navigation_to_another_Career_Level_where_there_are_no_levels_33829()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            //_test.Log(Status.Info, "Login with learner");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career Development from v arrow next to transcriptt");
            CareerDevelopmentPage.ClickExploreCareersbutton();
            _test.Log(Status.Info, "Click Explore Career Button on RHS");
            CareerNavigatorPage.ClicklinkfromJobs("CP_Title_WithnoLevel"); //Look for JobCard where Career Path exists, but no level exists
            _test.Log(Status.Info, "Select CP_Title_WithnoLevel from Levels dropdown");
            Assert.IsFalse(CareerNavigatorPage.Levels.LevelisDisabled()); //Verify the Levels dropdown does not show
            _test.Log(Status.Pass, "Verify Level DropDown is disabled");
            Assert.IsFalse(CareerNavigatorPage.Levels.NextLevelDisabled());//Verify when viewing jobs in the highest level, the forward arrow is disabled.
            _test.Log(Status.Pass, "Verify Next level Arrow icon is disabled");
            Assert.IsFalse(CareerNavigatorPage.Levels.PreviousLevelDisabled());// Verify when viewing jobs in the lowest level, the back arrow is disabled
            _test.Log(Status.Pass, "Verify Previous level Arrow icon is disabled");

        }

    }

}
