using System;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;


namespace TestAutomation.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class PermissionConsole : TestBase
    {
        string browserstr = string.Empty;
        public PermissionConsole(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            //  driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://prdct-mg-17-2.mksi-lms.net/");

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
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        
        [Test, Order(1)]
        public void View_Gamification_Permissions_for_Custom_Roles_28070()
        {
            #region create new user

          //  driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[contains(.,'Logout')]"));//mouse hover on user logout menu
            //driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));//click on logout
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")));//verify login button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,' or')]")));//label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@id='MainContent_UC5_lnkCreateAccount']")));// verify new account butotn and click on it
            driver.FindElement(By.XPath("//a[@id='MainContent_UC5_lnkCreateAccount']")).ClickWithSpace();
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' Create New Account')]")));//create new account page
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Login ID')]")));
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//enter text as learnerdv1
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Password')]")));//label
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_PASSWORD']")).SendKeysWithSpace("password");// enter password as password
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Confirm Password')]")));//label
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_ConfirmPassword']")).SendKeysWithSpace("password");//re-enter pwd
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*First Name')]")));//label first name
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']")).SendKeysWithSpace("learner");//enter name as dv1
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Last Name')]")));//label
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']")).SendKeysWithSpace("" + Meridian_Common.globalnum);//enter lastname as singh
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='MainContent_UC1_lnkSelectOrg']")));//select org label
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_lnkSelectOrg']")).ClickWithSpace();//click on button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@class='k-window-title']")));//new popup window
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Select Organizations')]")));//verify label
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Select an item from search results, then select Save.')]")));//verify text
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Find Organization')]")));//check label
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeysWithSpace("sample");//enter text as sample
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='SearchType']")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DV.SearchStartsWith']"), "Starts with");// select type as start with
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();//click on search
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Organizations')]")));// verify column organization
            Assert.IsTrue(driver.existsElement(By.XPath("//th[contains(.,'Path')]")));//verify column path
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Sample Organization 1')]")));//check org1
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']")).ClickWithSpace();//click checkbox for sample org1
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']")).ClickWithSpace();//click on save
            driver.SwitchTo().DefaultContent();
            Assert.IsTrue(driver.existsElement(By.XPath("//li[contains(.,'Sample Organization 1')]")));//verify org added and option to delete it is there
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Create']")).ClickWithSpace();//click on create
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Welcome')]")));//verify user loggedin and see welcome text
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region CreateNewRole
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));//mouse hover
          //  driver.FindElement(By.XPath("//a[contains(.,'    Administer    ')]"));//mouse hover on administer
            //driver.FindElement(By.XPath("//a[@href='#admin-console-personnel']"));//click people
            driver.FindElement(By.XPath("//a[contains(.,'Roles')]")).Click();//click role
            //new tab open
            driver.selectWindow("");
            driver.FindSelectElement(By.XPath("//option[contains(.,'Create New')]"),"Create New");//select create new
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")).Click();//click on go button
           Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'New Role')]")));//verify label on new page
           driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_NAME']")).SendKeysWithSpace("reg_gamification"+DateTime.Now.ToString());//enter name as reg_gamification
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_ROLE_DESCRIPTION']")).SendKeysWithSpace("testdesc");//enter descriptin as test
           Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Cancel']")));//verify cancel button
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']")).ClickWithSpace();//click on create button
          Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']")));//verify messgage
        bool tsetme=    driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_SelectDomain_TDElementCONTENT_NOT_SHARED']")).Selected;//verify default it set to this option
         Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Return']")));//verify return button
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")).ClickWithSpace();//click on save button
            driver.FindElement(By.XPath("//a[@navigatingurl='Role/RoleSimpleSearch.aspx']")).ClickWithSpace();//click on reole breadcrumb
            #endregion
            #region search role
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text as reg_gamification
            driver.FindElement(By.XPath("//option[contains(.,'Exact phrase')]"));//select search type as exact phrase
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//span[contains(.,'Records found: 1')]"));//verify result message
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[2]/td[3]"));//verify title name should be reg_gamificaiton
            #endregion
            #region assign gamification role to user
            driver.FindElement(By.XPath("//option[contains(.,'Edit Users')]"));//select edit user  option
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));//click on go button
            driver.FindElement(By.XPath("//span[contains(.,'reg_gamification (Meridian Global - Core Domain)')]"));//verify label on this page
            driver.FindElement(By.XPath("//option[contains(.,'Add User')]"));//select add user 
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME']"));//enter first name as dv
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//span[contains(.,'Records found: 3')]"));//verify success message
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers']/tbody/tr[2]/td[4]"));//verify  user's last name
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME']"));//click on checkbox for that user
            driver.FindElement(By.XPath("//input[@value='Add Selected']"));//click on add selected button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message
            driver.FindElement(By.XPath("//a[@title='Edit Users']"));//click on edit user breadcrumb
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_USR_FIRST_NAME']"));//enter first anme as dv
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_EditRole_RolePermissionsDataGrid']/tbody/tr[2]/td[4]"));//verify user's first name is dv
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.ManageRoles']"));//click on roles breadcrumb
            driver.FindElement(By.XPath("//span[contains(.,'Roles')]"));//verify user lands on roles page
            #endregion
            #region edit permissions for gamification role
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.EditPermissions']"));//select edit permisison option from drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));//click on go button
            driver.FindElement(By.XPath("//span[contains(.,'reg_gamification (Meridian Global - Core Domain)')]"));//verify label on page
            driver.FindElement(By.XPath("//th[contains(.,'Allow')]"));//verify allow column
            driver.FindElement(By.XPath("//th[contains(.,'Deny')]"));//verify deny column
            driver.FindElement(By.XPath("//th[contains(.,'Default')]"));//verify default column
            driver.FindElement(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00_ctl09_Detail20__1:0_10']/td[2]"));//verify gamification module appearing in this list
            driver.FindElement(By.XPath("//input[contains(@id,'ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl34_rbNoAction')]"));//verify gamification module set to default by default
            driver.FindElement(By.XPath("//input[contains(@id,'ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl34_rbAllow')]"));//select allow radio button for this 
            driver.FindElement(By.XPath("//input[@value='Return']"));//verify return button
            driver.FindElement(By.XPath("//input[@value='Save']"));//click on save button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify success message
            //close this page
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login with created user
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using learnerdv
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region user sees gamification module
            driver.FindElement(By.XPath("//a[contains(.,'  Manage                    ')]"));//mouse hover on manage
            driver.FindElement(By.XPath("//a[contains(.,'Gamification')]"));//verify gamification link appearing and click on it
            driver.FindElement(By.XPath("//label[contains(.,'         Gamification    ')]"));//verify gamifiaction page and user access it
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region admin deny permission for gamification
            driver.FindElement(By.XPath("//a[contains(.,'    Administer    ')]"));//mouse hover on administer
            driver.FindElement(By.XPath("//a[@href='#admin-console-personnel']"));//click people
            driver.FindElement(By.XPath("//a[contains(.,'Roles')]"));//click role
            #region search role
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text as reg_gamification
            driver.FindElement(By.XPath("//option[contains(.,'Exact phrase')]"));//select search type as exact phrase
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//span[contains(.,'Records found: 1')]"));//verify result message
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[2]/td[3]"));//verify title name should be reg_gamificaiton
            #endregion
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.EditPermissions']"));//select edit permisison option from drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));//click on go button
            driver.FindElement(By.XPath("//span[contains(.,'reg_gamification (Meridian Global - Core Domain)')]"));//verify label on page
            driver.FindElement(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00_ctl09_Detail20__1:0_10']/td[2]"));//verify gamification module appearing in this list
            driver.FindElement(By.XPath("//input[@id='ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl34_rbDeny']"));//select deny radio button for this 
            driver.FindElement(By.XPath("//input[@value='Return']"));//verify return button
            driver.FindElement(By.XPath("//input[@value='Save']"));//click on save button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify success message
            //close this page
            #endregion
            //close this tab
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login with created user
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using learnerdv
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region user not sees gamification module
            //manage link should not appear
            #endregion

            //   Assert.Fail();
        }
        [Test, Order(2)]

        public void Edit_Permissions_for_Custom_Roles_27888()
        {

            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region CreateNewRole
            driver.FindElement(By.XPath("//a[contains(.,'    Administer    ')]"));//mouse hover on administer
            driver.FindElement(By.XPath("//a[@href='#admin-console-personnel']"));//click people
            driver.FindElement(By.XPath("//a[contains(.,'Roles')]"));//click role
            //new tab open
            driver.FindElement(By.XPath("//option[contains(.,'Create New')]"));//select create new
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));//click on go button
            driver.FindElement(By.XPath("//span[contains(.,'New Role')]"));//verify label on new page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_NAME']"));//enter name as reg_gamification
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_ROLE_DESCRIPTION']"));//enter descriptin as test
            driver.FindElement(By.XPath("//input[@id='Cancel']"));//verify cancel button
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify messgage
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_SelectDomain_TDElementCONTENT_NOT_SHARED']"));//verify default it set to this option
            driver.FindElement(By.XPath("//input[@id='Return']"));//verify return button
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']"));//click on save button
            driver.FindElement(By.XPath("//a[@navigatingurl='Role/RoleSimpleSearch.aspx']"));//click on reole breadcrumb
            #endregion
            #region search role
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text as reg_gamification
            driver.FindElement(By.XPath("//option[contains(.,'Exact phrase')]"));//select search type as exact phrase
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//span[contains(.,'Records found: 1')]"));//verify result message
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[2]/td[3]"));//verify title name should be reg_gamificaiton
            #endregion
            #region assign gamification role to user
            driver.FindElement(By.XPath("//option[contains(.,'Edit Users')]"));//select edit user  option
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));//click on go button
            driver.FindElement(By.XPath("//span[contains(.,'reg_gamification (Meridian Global - Core Domain)')]"));//verify label on this page
            driver.FindElement(By.XPath("//option[contains(.,'Add User')]"));//select add user 
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME']"));//enter first name as dv
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//span[contains(.,'Records found: 3')]"));//verify success message
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers']/tbody/tr[2]/td[4]"));//verify  user's last name
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME']"));//click on checkbox for that user
            driver.FindElement(By.XPath("//input[@value='Add Selected']"));//click on add selected button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message
            driver.FindElement(By.XPath("//a[@title='Edit Users']"));//click on edit user breadcrumb
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_USR_FIRST_NAME']"));//enter first anme as dv
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditRole_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_EditRole_RolePermissionsDataGrid']/tbody/tr[2]/td[4]"));//verify user's first name is dv
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.ManageRoles']"));//click on roles breadcrumb
            driver.FindElement(By.XPath("//span[contains(.,'Roles')]"));//verify user lands on roles page
            #endregion
            #region edit permissions for gamification role
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.EditPermissions']"));//select edit permisison option from drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));//click on go button
            driver.FindElement(By.XPath("//span[contains(.,'reg_gamification (Meridian Global - Core Domain)')]"));//verify label on page
            driver.FindElement(By.XPath("//th[contains(.,'Allow')]"));//verify allow column
            driver.FindElement(By.XPath("//th[contains(.,'Deny')]"));//verify deny column
            driver.FindElement(By.XPath("//th[contains(.,'Default')]"));//verify default column
            driver.FindElement(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00_ctl09_Detail20__1:0_10']/td[2]"));//verify gamification module appearing in this list
            driver.FindElement(By.XPath("//input[contains(@id,'ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl34_rbNoAction')]"));//verify gamification module set to default by default
            driver.FindElement(By.XPath("//input[contains(@id,'ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl34_rbAllow')]"));//select allow radio button for this 
            driver.FindElement(By.XPath("//input[@value='Return']"));//verify return button
            driver.FindElement(By.XPath("//input[@value='Save']"));//click on save button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify success message
            //close this page
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

            //   Assert.Fail();
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
