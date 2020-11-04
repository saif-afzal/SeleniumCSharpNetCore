using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class JobTitleSuite : TestBase
    {
        string browserstr = string.Empty;
        public JobTitleSuite(string browser)
            : base(browser)
        {
            browserstr = browser;
            // InitializeBase(driver);
            Driver.Instance = driver;
            LoginPage.GoTo();
            //    LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
        }


        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        bool res1 = false;

        //  [OneTimeSetUp]
        public void Login()
        {
            // Driver.Initialize();

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
        //  [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }

        [Test, Order(1), Category("cannot be automated")]
        public void Add_Job_title_model_22219()
        {
            Assert.Ignore("cannot be automated as it's belong to old KView funtionality and on 18.1 it's no more in use.");
        }
        [Test, Order(2), Category("cannot be automated")]
        public void Remove_Job_title_model_22218()
        {
            Assert.Ignore("cannot be automated as it's belong to old KView funtionality and on 18.1 it's no more in use.");
        }

        [Test, Order(3), Category("cannot be automated")]
        public void Edit_Job_title_Organizations_22220()
        {
            Assert.Ignore("cannot be automated as it's belong to old KView funtionality and on 18.1 it's no more in use.");
        }

        [Test, Order(4), Category("cannot be automated")]
        public void Select_Job_Title_Evaulation_Templates_22221()
        {
            Assert.Ignore("cannot be automated as it's belong to old KView funtionality and on 18.1 it's no more in use.");
        }
        [Test, Order(5), Category("cannot be automated")]
        public void Edit_Job_title_activity_22217()
        {
            Assert.Ignore("cannot be automated as it's belong to old KView funtionality and on 18.1 it's no more in use.");

        }
        [Test, Order(6)]
        public void Edit_JobTitle_Sharing_25275()
        {
            Assert.Ignore("cannot be aotomated as it's related to turn on/off setting from backend");

        }
        [Test, Order(7)]
        public void Disable_localized_Job_Title_32189()
        {
            Assert.Ignore("cannot be aotomated as it's related to turn on/off setting from backend");

        }
        [Test, Order(8), Category("P1")]
        public void Delete_Job_Title_22213()
        {
            Assert.Ignore("cannot be aotomated as it's related to domain sharing and for multiple domains.");


        }
        [Test, Order(9)]
        public void Create_JobTitle_22211()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.EditJobTitleName(JobTitle);
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            res1 = true;
            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }
        [Test, Order(10)]
        public void Manage_JobTitle_22212()
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

            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }

        [Test, Order(11), Category("P1")]
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



        [Test, Order(12)]
        public void View_job_Title_page_32179()

        {
            Assert.IsTrue(res1);
        }

        [Test, Order(13), Category("P1")]
        public void localized_Job_Title_32185()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            AdminContentDetailsPage.SelectAddLocalization("French");


            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
        }


        [Test, Order(14), Category("P1")]
        public void Edit_localized_Job_Title_32187()
        {
            CommonSection.Manage.Careers.Careerstab();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            AdminContentDetailsPage.EditLocalization("edittitle", "Descriptionedit", "jobcodedit", "keywordsedit", "Arabic");
           // Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            AdminContentDetailsPage.SelectLocalization("Arabic");
            // StringAssert.AreEqualIgnoringCase("Add Localization", ContentDetailsPage.Frame(), ("Error message is different"));

            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckJobTitle("edittitle"));
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckJobCode("jobcodedit"));
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckDescriptionValue("Descriptionedit"));
            Assert.IsTrue(TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.CheckKeywordsValue("keywordsedit"));

        }

        [Test, Order(15), Category("P1")]
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


    }
}

    
