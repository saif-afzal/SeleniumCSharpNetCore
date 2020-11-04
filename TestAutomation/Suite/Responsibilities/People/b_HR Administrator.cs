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

namespace Selenium2.Meridian.Suite.MyResponsibilities.g_People
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   class b_HRAdministrator : TestBase
    {
        string browserstr = string.Empty;
        public b_HRAdministrator(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        public string chktest = string.Empty;
          public TrainingHomes TrainingHomeobj;
        public My_Responsibilities MyResponsibilitiesobj;
        public AdministrationConsoles AdminstrationConsoleobj;
        public ManageUsers ManageUsersobj;
        public CreateNewAccount CreateNewAccountobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
             AdminstrationConsoleobj = new AdministrationConsoles(driver);
            TrainingHomeobj = new TrainingHomes(driver);
            ManageUsersobj = new ManageUsers(driver);
            CreateNewAccountobj = new CreateNewAccount(driver);
            MyResponsibilitiesobj = new My_Responsibilities(driver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
        [SetUp]
        public void starttest()
        {
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


           driver.UserLogin("admin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_userforhr["Id"] + browserstr, ExtractDataExcel.MasterDic_userforhr["Firstname"] + browserstr, ExtractDataExcel.MasterDic_userforhr["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforhr["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforhr["Firstname"], ExtractDataExcel.MasterDic_userforhr["Lastname"]);
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_userforhr["Id"] + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


            driver.UserLogin("admin", browserstr);
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsTab("People");
            TrainingHomeobj.click_systemOptionsAccordian("Users");
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
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforhr", browserstr);

            classroom.linkmyresponsibilities1click1(driver);
            driver.WaitForElement(By.XPath("//a[@data-menuitem='people']"));
            driver.GetElement(By.XPath("//a[@data-menuitem='people']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_FIRST_NAME']"));
            //   Assert.IsFalse(driver.existsElement("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser"));
            CreateAccount.populateaccountsearchformforregressioncustomized(ExtractDataExcel.MasterDic_userforhr["Firstname"], ExtractDataExcel.MasterDic_userforhr["Lastname"]);
            chktest = CreateAccount.buttonsearchclick1();
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Firstname"] + "' )]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Lastname"] + "' )]")));
          //  Assert.IsTrue(driver.existsElement(By.XPath("//th[contains(.,'Locked')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'No job title')]")));
         //   Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Location')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Active')]")));
            Assert.IsTrue(driver.existsElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_MUsrImgIcon")));
            driver.select(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction"),"Send Email");
            driver.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo")).ClickWithSpace();
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
            driver.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_MUsrImgIcon")).ClickWithSpace();
            driver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));               

            //Assert.IsTrue(driver.WaitForElement(By.XPath("//span[@id='MainContent_UC1_PopUpUserInfo_lblComma']")));
            // driver.SelectFrame(By.XPath("//span[@id='MainContent_UC1_PopUpUserInfo_lblComma']"));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//strong[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Id"] + browserstr + "@tpg.com" + "')]")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//h2[contains(.,'" + ExtractDataExcel.MasterDic_userforhr["Lastname"] + browserstr + ", " + ExtractDataExcel.MasterDic_userforhr["Firstname"] + browserstr + "')]")));

            
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
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Send Email");
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_Send']")));
            Assert.IsTrue(driver.existsElement(By.Id("MainContent_UC1_lblMessage")));
           // driver.GetElement(By.Id("MainContent_UC1_lblMessage")).SendKeysWithSpace("test");
            driver.GetElement(By.Id("MainContent_UC1_Subject")).SendKeysWithSpace("test");
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC1_Send']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC1_Cancel']")));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Send']")).ClickWithSpace();

            driver.SwitchtoDefaultContent();
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            string result = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Assert.IsTrue(driver.Compareregexstring("The email was sent.", result));
            
        }

        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
    }
}
