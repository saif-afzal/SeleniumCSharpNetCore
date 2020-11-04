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
   class a_Administrator :TestBase
    {
        string browserstr = string.Empty;
        public a_Administrator(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        public TrainingHomes TrainingHomeobj;
        public My_Responsibilities MyResponsibilitiesobj;
        public AdministrationConsoles AdminstrationConsoleobj;
        public ManageUsers ManageUsersobj;
        public CreateNewAccount CreateNewAccountobj;
        public bool chktest = false;
        public bool chktest1 = false;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
          //  driver.UserLogin("admin",browserstr);

            //InitializeBase(driver);
            //driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
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
       [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod] 
        [Test]
        public void g185_Create_a_new_account()
         {
            AccountCreation CreateAccount = new AccountCreation(driver);
            ClassroomCourse classroom = new ClassroomCourse(driver);
            driver.UserLogin("admin", browserstr);
      //      TrainingHomeobj.isTrainingHome();
           
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_userforreg["Id"] + "people" + browserstr, ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people", ExtractDataExcel.MasterDic_userforreg["Email"]);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
           chktest= ManageUsersobj.Click_SearchUser();
           Assert.IsTrue(driver.tempUserLogin("user", ExtractDataExcel.MasterDic_userforreg["Id"] + "people" + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr));
             chktest1 = true;
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
      //      string expectedresult = "The account was created and the user profile was updated.";
      //      driver.UserLogin("admin");
      //      classroom.linkmyresponsibilitiesclick(driver);

      //      CreateAccount.linkcreateaccntclick();
      //    class  CreateAccount.populatecreateaccountformforregression();
      //      CreateAccount.populateselectorganizationformforregression();
      //      string actualresult = CreateAccount.buttoncreateclick();
      //CreateAccount.populateaccountsearchformforregression();
      //chktest = CreateAccount.buttonsearchclick();
      //      CreateAccount.passwordcreationforregression();
      //      StringAssert.AreEqualIgnoringCase(actualresult, expectedresult);
      //Assert.IsTrue(driver.existsElement(By.Id("SiteNavigationBar2_SiteWide_txtSearch")));
        }
        [Test]
        public void g186_Conduct_a_search_for_a_user()
        {
            if (chktest == true)
            {
                Assert.AreEqual(1,1);
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                Assert.Fail("Search failed");
            }
        }
        [Test]
        public void g187_Click_on_the_information_icon_for_a_user()
        {
            AccountCreation CreateAccount = new AccountCreation(driver);
            ClassroomCourse classroom = new ClassroomCourse(driver);
            driver.UserLogin("admin1", browserstr);
        //    classroom.linkmyresponsibilitiesclick(driver);
            classroom.linkmyresponsibilitiesclick(driver);
            driver.WaitForElement(By.XPath("//a[@data-menuitem='people']"));
            driver.GetElement(By.XPath("//a[@data-menuitem='people']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']"));
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            ManageUsersobj.Click_SearchUser();
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_FIRST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_btnSearch']")).ClickWithSpace();

            driver.WaitForElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00__0"));
            driver.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_MUsrImgIcon")).ClickWithSpace();
           //driver.SelectFrame();
           driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
         //  Assert.IsTrue(driver.WaitForElement(By.XPath("//strong[contains(.,'" +ExtractDataExcel.MasterDic_userforreg["Id"] + "people" + ExtractDataExcel.MasterDic_userforreg["Email"] +browserstr+"')]")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//h2[contains(.,'" + ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people, " + ExtractDataExcel.MasterDic_userforreg["Firstname"]+"people"+"')]")));
          
          
         //  Assert.IsTrue(driver.WaitForElement(By.XPath("//span[@id='MainContent_UC1_PopUpUserInfo_lblJobTitles']")));
         //  Assert.IsTrue(driver.WaitForElement(By.XPath("//strong[contains(.,'" + ExtractDataExcel.MasterDic_userforreg["Org"] + "')]")));
        //  Assert.IsTrue(driver.existsElement(By.Id("MainContent_UC1_PopUpUserInfo_lblUnqId")));
            driver.SwitchtoDefaultContent();
          driver.GetElement(By.XPath("//a[contains(.,'Close')]")).ClickWithSpace();

        }
        [Test]
        public void g188_Create_a_new_password_for_a_user()
        {
         //   ClassroomCourse classroom = new ClassroomCourse(driver);
         //   AccountCreation CreateAccount = new AccountCreation(driver);
         //   //driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Edit Profile");
         //   //driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
         //   //driver.GetElement(By.XPath("//a[@id='MainContent_UCProfile_ucPreferences_lnkEdit']")).ClickWithSpace();
         //   //driver.SelectFrame(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_COMMUNICATION_MESSAGES']"));
         //   //driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_COMMUNICATION_MESSAGES']")).ClickWithSpace();
         //   //driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
         //   //driver.SwitchTo().DefaultContent();
         //   //driver.GetElement(By.XPath("//a[contains(.,'Manage Users')]")).ClickWithSpace();
         //   driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Create Password");
        
         //   driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
         //   driver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));               

         //   driver.WaitForElement(By.Id("MainContent_ucUserSimpleSearch_MbtnCreate"));
         //   driver.GetElement(By.Id("MainContent_ucUserSimpleSearch_MbtnCreate")).ClickWithSpace();
         //   driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
         //   string result = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
         //   StringAssert.AreEqualIgnoringCase(result, "A temporary password was created and emailed to the user.");
         //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         //  driver.UserLogin("admin", browserstr);
         //  classroom.linkmyresponsibilitiesclick(driver);

         //  //CreateAccount.linkcreateaccntclick();
         //  //CreateAccount.populatecreateaccountformforregression();
         //  //CreateAccount.populateselectorganizationformforregression();
         //  //string actualresult = CreateAccount.buttoncreateclick();
         //  driver.GetElement(By.XPath("//a[@data-menuitem='people']")).ClickWithSpace();
         //  driver.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']"));
         //  driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
         //  driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_FIRST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people");
         //  driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_btnSearch']")).ClickWithSpace();
         //  driver.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
         //  driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Login Assistance");
         //  driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
         //  driver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));               
         //  driver.WaitForElement(By.Id("MainContent_UC1_Save"));
         //  driver.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
         //  Thread.Sleep(3000);
         //  driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
         //  string result1 = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
         //  Thread.Sleep(5000);
         //  var elements = result1.Split(' ');
         //  string passwd = elements[5];
         //  passwd = passwd.Replace(".", "");
         //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         //  driver.tempUserLogin("userforregression", "", passwd, browserstr);
  
         //  //CreateAccount.populateaccountsearchformforregression();
         //  //chktest = CreateAccount.buttonsearchclick();
         //  //CreateAccount.passwordcreationforregression();
         ////   driver.UserLogin("user");
         //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            if (chktest1 == true)
            {
                Assert.AreEqual(1, 1);
              //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                Assert.Fail("Search failed");
            }
        }
        [Test]
        public void g189_Edit_the_activity_for_a_user()
        {
            ClassroomCourse classroom = new ClassroomCourse(driver);
            //driver.UserLogin("admin", browserstr);
            AccountCreation CreateAccount = new AccountCreation(driver);
// classroom.linkmyresponsibilitiesclick(driver);
            //driver.GetElement(By.XPath("//a[@data-menuitem='people']")).ClickWithSpace();
            //driver.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']"));
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']")).Clear();
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_FIRST_NAME']")).Clear();
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_FIRST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_btnSearch']")).ClickWithSpace();
         //   ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
           // ManageUsersobj.Click_SearchUser();
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Edit Activity");
            driver.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo")).ClickWithSpace();
            Thread.Sleep(3000);
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.Id("MainContent_UC1_FormView1_OBJ_IS_ACTIVE_0"));
            //driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_OBJ_IS_ACTIVE_0']")).ClickWithSpace();
            
            //driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_btnChangeActivity']")).ClickWithSpace();
            //Thread.Sleep(3000);
            //driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
            //driver.SwitchTo().DefaultContent();
            //driver.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
          //  string result = driver.GetElement(By.XPath("//div[@class='forms-msg-success']")).Text;
            //driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Edit Activity");
            //driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            //driver.SelectFrame(By.XPath("//input[@id='MainContent_UC1_FormView1_OBJ_IS_ACTIVE_1']"));
            driver.GetElement(By.Id("MainContent_UC1_FormView1_OBJ_IS_ACTIVE_1")).ClickWithSpace();

            //driver.GetElement(By.Id("MainContent_UC1_FormView1_btnChangeActivity")).ClickWithSpace();
            Thread.Sleep(3000);
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
            Thread.Sleep(5000);
            driver.SwitchtoDefaultContent();
            //driver.SwitchTo().DefaultContent();
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            string result1 = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
          //  CreateAccount.passwordcreationforregression();
          //  driver.GetElement(By.XPath("//span[contains(.,'People')]")).ClickWithSpace();
          //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
          ////  driver.UserLogin("user");
            Assert.IsTrue(driver.Compareregexstring("The changes were saved.",result1));
            
        }
        [Test]
        public void g190_Edit_the_login_ID_for_a_user()
        {
            ClassroomCourse classroom = new ClassroomCourse(driver);
            //driver.UserLogin("admin",browserstr);
            AccountCreation CreateAccount = new AccountCreation(driver);
            classroom.linkmyresponsibilitiesclick(driver);
            driver.GetElement(By.XPath("//a[@data-menuitem='people']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']"));
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_FIRST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_btnSearch']")).ClickWithSpace();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            ManageUsersobj.Click_SearchUser();
            driver.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Edit Login ID");
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//strong[contains(.,'" + ExtractDataExcel.MasterDic_userforreg["Id"] + "people" + "')]"));
            string text = driver.gettextofelement(By.XPath("//strong[contains(.,'" + ExtractDataExcel.MasterDic_userforreg["Id"] + "people" + "')]"));
            StringAssert.AreEqualIgnoringCase(text,ExtractDataExcel.MasterDic_userforreg["Id"] + "people" + browserstr);
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Id"] + "people" + 1);
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
            driver.SwitchtoDefaultContent();
            //driver.SwitchTo().DefaultContent();
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            string result = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            Assert.IsTrue(driver.Compareregexstring("The user's Login ID was updated.",result));
            
            // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            ////  driver.UserLogin("user");
        }
        [Test]
        public void g191_Edit_Profile_for_a_user()

        {
            // driver.UserLogin("admin",browserstr);
            //    classroom.linkmyresponsibilitiesclick(driver);
            ClassroomCourse classroom = new ClassroomCourse(driver);
            classroom.linkmyresponsibilitiesclick(driver);
            driver.GetElement(By.XPath("//a[@data-menuitem='people']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtLastName']"));
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            ManageUsersobj.Click_SearchUser();
            driver.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Edit Profile");
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            Thread.Sleep(5000);
            driver.ScrollToCoordinated("500", "500");
            MyAccountobj.ClickPreferencesTab();
                    
            driver.GetElement(By.XPath(".//*[@id='preferences-block']/div[2]/div[2]/div[2]/div/div/div[2]/div/div/div/span[2]")).Click();
 
            //if(driver.existsElement(By.XPath("//*[@class='k-icon k-i-close']")))
            //{
            //     driver.GetElement(By.XPath("//*[@class='k-icon k-i-close']")).ClickWithSpace();
            //Thread.Sleep(5000);
            //}
            MyAccountobj.ClickProfileTab();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_UCProfile_ucUserInfo_lnkEdit']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_UCProfile_ucUserInfo_lnkEdit']")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_FIRST_NAME']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_WORK_PHONE']")).SendKeys("1111111");
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_STREET_ADDRESS']")).Clear();

              driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_STREET_ADDRESS']")).SendKeysWithSpace("testaddress");
              driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_CITY']")).Clear();
              driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_CITY']")).SendKeysWithSpace("NewYork");
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
            driver.SwitchtoDefaultContent();
                if (driver.existsElement(By.XPath("//*[@class='k-icon k-i-close']")))
            {
                driver.GetElement(By.XPath("//*[@class='k-icon k-i-close']")).ClickWithSpace();
                Thread.Sleep(5000);
            }
            string format = "MM/dd/yyyy";

            driver.WaitForElement(By.XPath("//a[@id='MainContent_UCProfile_ucQualification_lnkEdit']"));
          //  driver.GetElement(By.XPath("//a[@id='MainContent_UCProfile_ucWorkInfo_lnkEdit']")).ClickWithSpace();
          //  driver.SelectFrame(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_WORK_STREET_ADDRESS']"));
          //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_WORK_STREET_ADDRESS']")).SendKeys("123");
          //  driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_USR_HIRE_DATE_dateInput']")).SendKeys(DateTime.Now.AddDays(0).ToString(format));
          //  driver.getcomboitemselected(By.XPath("//select[@id='MainContent_UC1_FormView1_USR_APPTMT_TYPE_ID']"));
          //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_PAY_PLAN_CODE']")).SendKeys("AA");
          //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_SERIES']")).SendKeys("1234");
          ////  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USRX_825287A6743C4C5982D31629F048CAC4']")).SendKeys("testme");
          //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
          //  driver.SwitchTo().DefaultContent();
          //  driver.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_UCProfile_ucQualification_lnkEdit']")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//select[@id='MainContent_UC1_FormView1_USR_EDUCATION_LEVEL_ID']"));
            driver.getcomboitemselected(By.XPath("//select[@id='MainContent_UC1_FormView1_USR_EDUCATION_LEVEL_ID']"),1);
            driver.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
            driver.SwitchtoDefaultContent();
            if (driver.existsElement(By.XPath("//*[@class='k-icon k-i-close']")))
            {
                driver.GetElement(By.XPath("//*[@class='k-icon k-i-close']")).ClickWithSpace();
                Thread.Sleep(5000);
            }
            driver.WaitForElement(By.XPath("//a[@id='MainContent_UCProfile_ucQualification_lnkEdit']"));
            //driver.GetElement(By.XPath("//a[@id='MainContent_UCProfile_ucEHRI_lnkEdit']")).ClickWithSpace();
            //driver.SelectFrame(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_EHRI_DATE_OF_BIRTH_dateInput']"));
            //driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_EHRI_DATE_OF_BIRTH_dateInput']")).SendKeys(DateTime.Now.AddYears(-20).ToString(format));
            //driver.GetElement(By.Id("MainContent_UC1_FormView1_EHRI_EMPL_NUMBER")).ClickWithSpace();
            //driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
            //Thread.Sleep(2000);
            //driver.SwitchTo().DefaultContent();
            //Thread.Sleep(2000);
            //driver.WaitForElement(By.XPath("//div[@class='forms-msg-success']"));
            string result = driver.GetElement(By.XPath("//a[@id='MainContent_UCProfile_ucQualification_lnkEdit']")).Text;
            StringAssert.AreEqualIgnoringCase(result, "Edit Qualifications");
            driver.GetElement(By.XPath("//a[contains(.,'Manage Users')]")).ClickWithSpace();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
       // [Test] Disabled in PS site
        public void g192_Proxy_log_in_as_another_user()
        {
            ClassroomCourse classroom = new ClassroomCourse(driver);
            AccountCreation CreateAccount = new AccountCreation(driver);
            // CreateAccount.passwordcreationforprxylogin();
            //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //  driver.UserLogin("admin");
            //    classroom.linkmyresponsibilitiesclick(driver);
            //   classroom.linkmyresponsibilitiesclick(driver);
            //   driver.GetElement(By.XPath("//span[contains(.,'People')]")).ClickWithSpace();
            //     driver.WaitForElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtLastName']"));
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtLastName']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Lastname"]);
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtFirstName']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"]);
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_btnSearch']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"));
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Proxy Login");
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            Thread.Sleep(3000);
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            //driver.SelectFrame();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC5_txtAdminPassword']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_txtAdminPassword']")).SendKeys("password");
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_Save']")).ClickWithSpace();
            driver.findandacceptalert();
          //  driver.SwitchTo().Alert().Accept();
            ////driver.WaitForElement(By.XPath("//div[@class='forms-msg-error']"));
            ////string result = driver.GetElement(By.XPath("//div[@class='forms-msg-error']")).Text;
            ////StringAssert.Contains("The login ID and password combination was not found in the system's records.", result);
            //driver.GetElement(By.XPath("//input[@id='MainContent_UC5_txtAdminPassword']")).SendKeys(ExtractDataExcel.MasterDic_admin["Password"]);
            //driver.GetElement(By.XPath("//input[@id='MainContent_UC5_Save']")).ClickWithSpace();
            //Thread.Sleep(3000);
            //driver.SwitchTo().Alert().Accept();
            //Thread.Sleep(3000);
            //   Assert.IsTrue(driver.existsElement("MainContent_ucQuickSearch_txtSearch"));
            //driver.GetElement(By.Id("MainContent_UC1_CurrentPassword")).SendKeys("password");
            //driver.GetElement(By.Id("MainContent_UC1_USR_PASSWORD")).SendKeys("password");
            //driver.GetElement(By.Id("MainContent_UC1_ConfirmPassword")).SendKeys("password");
            //driver.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
            driver.WaitForElement(By.XPath(".//*[@id='proxyNotification']/strong"));
            string msg = driver.GetElement(By.XPath(".//*[@id='proxyNotification']/strong")).Text;
            StringAssert.AreEqualIgnoringCase(msg, "You're logged in as a proxy.");
            //String bgImage = element.GetCssValue("background-image");
            //StringAssert.Contains("nav-proxy-lock.png", bgImage);
            //// StringAssert.Contains("none", bgImage);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public void g193_Send_an_email_to_a_user()
        {
            ClassroomCourse classroom = new ClassroomCourse(driver);
            AccountCreation CreateAccount = new AccountCreation(driver);
            driver.UserLogin("admin1", browserstr);
               classroom.linkmyresponsibilitiesclick(driver);
          //  classroom.linkmyresponsibilitiesclick(driver);
            TrainingHomeobj.lnk_People_click();
            //ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            //chktest = ManageUsersobj.Click_SearchUser(); // driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtLastName']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_txtFirstName']")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people");
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucUserSimpleSearch_btnSearch']")).ClickWithSpace();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            ManageUsersobj.Click_SearchUser();
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Send Email");
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_Subject']"));
           Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_From']")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//select[@id='MainContent_UC1_ImportanceId']")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_EmailSendCopy']")));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Subject']")).SendKeys("test");
            driver.GetElement(By.XPath(".//*[@id='Editor']/div[2]/div")).SendKeys("testme");
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Send']")).ClickWithSpace();
            //driver.SwitchTo().DefaultContent();
            driver.SwitchtoDefaultContent();
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            string result = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            Assert.IsTrue(driver.Compareregexstring("The email was sent.", result));
           
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //driver.tempUserLogin("userforregression1", "", ExtractDataExcel.MasterDic_userforreg["Password"], browserstr);
            //driver.GetElement(By.Id("NavigationStrip1_qucMessages_imgQueueIcon")).ClickWithSpace();
            //string text = driver.gettextofelement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkSubject"));
            //StringAssert.AreEqualIgnoringCase(text, "test");
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
     //   [Test]
        public void g194_Select_the_primary_domain_for_a_user_single_URL_only()
        {
            driver.UserLogin("admin", browserstr);
            ClassroomCourse classroom = new ClassroomCourse(driver);
            AccountCreation CreateAccount = new AccountCreation(driver);
            classroom.linkmyresponsibilitiesclick(driver);
            TrainingHomeobj.lnk_People_click();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            chktest = ManageUsersobj.Click_SearchUser();
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "Select Primary Domain");
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.Id("MainContent_UC1_btnSave"));
            driver.GetElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgUserPrimaryDomain_ctl00__0']/td[1]")).ClickWithSpace();//(By.XPath("//td[contains(.,'Meridian Global - Core Domain')]/preceding-sibling::input[@value='rbPrimaryDomain']")).ClickWithSpace();
            driver.GetElement(By.Id("MainContent_UC1_btnSave")).ClickWithSpace();
            driver.SwitchtoDefaultContent();
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            string result = driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            StringAssert.AreEqualIgnoringCase(result, " The selected domain was set as the primary domain.");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void g195_View_the_transcript_for_a_user()
        {
            ClassroomCourse classroom = new ClassroomCourse(driver);
            AccountCreation CreateAccount = new AccountCreation(driver);
            driver.UserLogin("admin", browserstr);
            classroom.linkmyresponsibilitiesclick(driver);
            driver.GetElement(By.XPath("//a[@data-menuitem='people']")).ClickWithSpace();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_userforreg["Firstname"] + "people", ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people");
            ManageUsersobj.Click_SearchUser(); 
            driver.select(By.XPath("//select[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction']"), "View Transcript");
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo']")).ClickWithSpace();
            string text = driver.gettextofelement(By.XPath("//h2"));
          //  StringAssert.Contains(ExtractDataExcel.MasterDic_userforreg["Firstname"] + " " + ExtractDataExcel.MasterDic_userforreg["Lastname"] + "people", text);
            Assert.IsTrue( driver.WaitForElement(By.XPath("//a[contains(.,'Manage Users')]")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnReturn']")));
            driver.GetElement(By.XPath("//a[contains(.,'Manage Users')]")).ClickWithSpace();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
           
            
            //driver.FindElement(By.XPath("//a[contains(.,'Curriculums')]")).ClickWithSpace();
            //driver.GetElement(By.Id("MainContent_ucQLinks_lnkCurriculum")).ClickWithSpace();
            //Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnReturn']")));
            //driver.FindElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkEL']")).ClickWithSpace();
            //Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnReturn']")));
            //driver.FindElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkRT']")).ClickWithSpace();
            //Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnReturn']")));
            //driver.FindElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkCert']")).ClickWithSpace();
            //Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnReturn']")));
            //driver.FindElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkSF182']")).ClickWithSpace();
            //Assert.IsTrue(driver.WaitForElement(By.XPath("//h2[contains(.,'SF-182 (0)')]")));
            //driver.FindElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkAllTraining']")).ClickWithSpace();
           

        }
     //   [Test]
        public void g196_From_the_transcript_perform_the_following_actions_for_content_Mark_Complete_for_User_Update_Score_Delete_Progress_Waive_Cancel_Enrollment()
        {

        }
    //    [Test]
        public void g196_From_the_transcript_add_a_PDF_File_and_Note_for_a_user()
        {

        }
   //     [Test]
        public void g197_Unlock_account_for_user()
        {

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
