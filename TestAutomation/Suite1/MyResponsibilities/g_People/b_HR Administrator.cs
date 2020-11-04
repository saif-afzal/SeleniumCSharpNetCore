using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;

namespace Selenium2.Meridian.Suite.MyResponsibilities.g_People
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   class b_HRAdministratorold : TestBase
    {
        string browserstr = string.Empty;
        public b_HRAdministratorold(string browser)
            : base(browser)
        {
            browserstr = browser;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            AdminstrationConsoleobj = new AdministrationConsoles(driver);
            TrainingHomeobj = new TrainingHomes(driver);
            ManageUsersobj = new ManageUsers(driver);
            CreateNewAccountobj = new CreateNewAccount(driver);
            MyResponsibilitiesobj = new My_Responsibilities(driver);
        }
        public string chktest = string.Empty;
          public TrainingHomes TrainingHomeobj;
        public My_Responsibilities MyResponsibilitiesobj;
        public AdministrationConsoles AdminstrationConsoleobj;
        public ManageUsers ManageUsersobj;
        public CreateNewAccount CreateNewAccountobj;
     

      
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        }
        [Test]
        public void b199_Conduct_a_search_for_a_user()
        {
           AccountCreation CreateAccount = new AccountCreation(driver);
           ClassroomCourse classroom = new ClassroomCourse(driver);
         //   string expectedresult = "The account was created and the user profile was updated.";
         //   driver.UserLogin("admin");
         //   classroom.linkmyresponsibilitiesclick(driver);

         //   CreateAccount.linkcreateaccntclick();
         //   CreateAccount.populatecreateaccountformforregressioncustomized(ExtractDataExcel.MasterDic_userforhr["Id"],ExtractDataExcel.MasterDic_userforhr["Firstname"],ExtractDataExcel.MasterDic_userforhr["Lastname"],ExtractDataExcel.MasterDic_userforhr["Email"]);
         //   CreateAccount.populateselectorganizationformforregression();
         //   string actualresult = CreateAccount.buttoncreateclick();
         //   CreateAccount.populateaccountsearchformforregressioncustomized(ExtractDataExcel.MasterDic_userforhr["Firstname"], ExtractDataExcel.MasterDic_userforhr["Lastname"]);
         //   chktest = CreateAccount.buttonsearchclick();
         //   CreateAccount.passwordcreationforregressioncustomize("userforhr");
         //   StringAssert.AreEqualIgnoringCase(actualresult, expectedresult);
         //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         //   // Assert.IsTrue(driver.existsElement("SiteNavigationBar2_SiteWide_txtSearch"));


           driver.UserLogin("admin1", browserstr);
          //  TrainingHomeobj.isTrainingHome();
         //   TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_userforhr["Id"] + browserstr, ExtractDataExcel.MasterDic_userforhr["Firstname"] + browserstr, ExtractDataExcel.MasterDic_userforhr["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforhr["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforhr["Firstname"], ExtractDataExcel.MasterDic_userforhr["Lastname"]);
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_userforhr["Id"] + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr);
            driver.ClickEleJs(By.XPath("//a[@id='ph_avatar']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Logout')]"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));

            driver.UserLogin("admin1", browserstr);
          //  TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_personnel']"));

            TrainingHomeobj.click_systemOptionsLink("Roles");
          //  driver.openadminconsolepage();
          //  driver.GetElement(By.XPath("//a[@pageid='ML.BASE.HEAD.ManageRoles']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));

            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeysWithSpace("hr administrator");
            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));

            //driver.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));
            //driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']")).ClickWithSpace();
            //   driver.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_GoPageActionsMenu']"));
            //driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_GoPageActionsMenu']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_GoPageActionsMenu']"));
            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_GoPageActionsMenu']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_LAST_NAME']"));
            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_LAST_NAME']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforhr["Lastname"]);
            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforhr["Firstname"]);
            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnSearch']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME']"));
            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnAdd']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
            string result = driver.GetElement(By.XPath("//span[@id='ReturnFeedback']")).Text;
            StringAssert.AreEqualIgnoringCase(result, "The user(s) was added.");
            driver.Navigate_to_TrainingHome();
            driver.ClickEleJs(By.XPath("//a[@id='ph_avatar']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Logout')]"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));
            driver.UserLogin("userforhr", browserstr);

            MyResponsibilitiesobj.Click_People();
            //     driver.WaitForElement(By.XPath("//input[@id='USR_FIRST_NAME']"));
            //   Assert.IsFalse(driver.existsElement("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser"));
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforhr["Firstname"], ExtractDataExcel.MasterDic_userforhr["Lastname"]);
            chktest = CreateAccount.buttonsearchclick1();
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Firstname"] + "' )]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Lastname"] + "' )]")));
          //  Assert.IsTrue(driver.existsElement(By.XPath("//th[contains(.,'Locked')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'No job title')]")));
         //   Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Location')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Active')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@class,'fa fa-info-circle fa-lg')]")));
            driver.select(By.XPath("//select[@id='ddlUsrAction_0']"), "Send Email");
            driver.GetElement(By.XPath("//a[@class='btn btn-default go']")).ClickWithSpace();
            driver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
           bool res= driver.existsElement(By.Id("MainContent_UC1_Subject"));
           driver.SwitchtoDefaultContent();
           driver.GetElement(By.XPath("//a[contains(.,'Close')]")).ClickWithSpace();
            Thread.Sleep(4000);
            //select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']
          //  StringAssert.IsMatch("Send Email", test[1].Text);
            Assert.IsTrue(res);
        }
        [Test]
        public void b200_Click_on_the_information_icon_for_a_user()
        {
            AccountCreation CreateAccount = new AccountCreation(driver);
            CreateAccount.buttonsearchclick1();
            driver.GetElement(By.XPath("//span[contains(@class,'fa fa-info-circle fa-lg')]")).ClickWithSpace();
            driver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));               

            //Assert.IsTrue(driverobj.existsElement(By.XPath("//span[@id='MainContent_UC1_PopUpUserInfo_lblComma']")));
            // driver.SelectFrame(By.XPath("//span[@id='MainContent_UC1_PopUpUserInfo_lblComma']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Id"] + browserstr + "@tpg.com" + "')]")));
           // Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Lastname"] + browserstr + ", " + ExtractDataExcel.MasterDic_userforhr["Firstname"] + browserstr + "')]")));

            
            //Assert.IsTrue(driver.existsElement(By.Id("MainContent_UC1_PopUpUserInfo_lblLastName")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'City:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Non-U.S. State/Province:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'U.S. State:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Country:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Postal Code:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'lblEXT')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Job Titles:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Organizations:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Managers:')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'lblJobTitles')]")));
            //Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='MainContent_UC1_PopUpUserInfo_lblUnqId']")));
            driver.SwitchtoDefaultContent();
            driver.GetElement(By.XPath("//a[contains(.,'Close')]")).ClickWithSpace();
  
        }
        [Test]
        public void b201_Send_an_email_to_a_user()
        {
            driver.select(By.XPath("//select[@id='ddlUsrAction_0']"), "Send Email");
            driver.GetElement(By.XPath("//a[@class='btn btn-default go']")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC1_Send']")));
            Assert.IsTrue(driver.existsElement(By.Id("MainContent_UC1_lblMessage")));
           // driver.GetElement(By.Id("MainContent_UC1_lblMessage")).SendKeysWithSpace("test");
            driver.GetElement(By.Id("MainContent_UC1_Subject")).SendKeysWithSpace("test");
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC1_Send']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC1_Cancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Send']"));

            driver.SwitchtoDefaultContent();
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            string result = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            driver.ClickEleJs(By.XPath("//a[@id='ph_avatar']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Logout')]"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));
            Assert.IsTrue(driver.Compareregexstring("The email was sent.", result));
            
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
