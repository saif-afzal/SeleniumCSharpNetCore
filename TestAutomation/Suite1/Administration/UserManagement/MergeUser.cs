using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.Administration.UserManagement
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class MergeUserold : TestBase
    {
        string browserstr = string.Empty;
        public MergeUserold(string browser)
            : base(browser)
        {
            browserstr = browser+"muo";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
        }
      
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Create_a_new_user_group()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.MyResponsiblities_click();
            //MyResponsibilitiesobj.Click_People();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Manage')]"), By.XPath("//a[@href='/Admin/ManageUsers/UserSimpleSearch.aspx']"));
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "merge1", ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr + "merge1", ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr + "merge1", ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            driver.Navigate().Refresh();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr + "merge1", ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr + "merge1");
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "merge1", ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            driver.UserLogin("admin1", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.MyResponsiblities_click();
            //MyResponsibilitiesobj.Click_People();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Manage')]"), By.XPath("//a[@href='/Admin/ManageUsers/UserSimpleSearch.aspx']"));
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "merge2", ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr + "merge2", ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr + "merge2", ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            driver.Navigate().Refresh();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr + "merge2", ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr + "merge2");
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "merge2", ManageUsersobj.passwordcreationnewuser(), browserstr);
             driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

             driver.UserLogin("admin1", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_People_click();
            //TrainingHomeobj.lnk_peopleManagement_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Merge Users");
            MergeUsersobj.Populate_primaryusers(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr + "merge1", ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr + "merge1", ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "merge1");
            MergeUsersobj.Click_SearchPrimaryUser();
            MergeUsersobj.Click_PrimaryUser();
            MergeUsersobj.Populate_secondryusers(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr + "merge2", ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr + "merge2", ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "merge2");
            MergeUsersobj.Click_Searchsecondryuser();
            MergeUsersobj.Click_secondryUser();
            Assert.IsTrue(MergeUsersobj.Click_MergeUser());


        }

      //  [Test]
        public void b_View_the_Transcript_for_the_user_as_they_are_selected_and_merged()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Merge Users");


        }

        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

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

    }
}
