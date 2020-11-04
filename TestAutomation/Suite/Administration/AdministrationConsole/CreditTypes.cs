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

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CreditTypes : TestBase
    {
        string browserstr = string.Empty;
        public CreditTypes(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
         driver.UserLogin("admin1",browserstr);

        }
        [SetUp]
        public void starttest()
        {

            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
             driver.UserLogin("admin1",browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void Create_Credit_Type_8555()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']")); 
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Navigate to Create Credit Type page
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.CreditType.SimpleSearch']"));
            driver.ClickEleJs(By.XPath("//option[contains(.,'Create New')]")); //Clicked on Create New
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")); //Selected Go
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'New Credit Type')]"))); //Verified the New Credit Type page heading is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verified the Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Create')]"))); //Verified the Create button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Cancel')]"))); //Verified the Cancel button is displayed
            #endregion
            #region Cancel Credit Type
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE']")).SendKeysWithSpace("Dolly's Credit Type_1"); //Entered Title Dolly's Credit Type_1
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION']")).SendKeysWithSpace("Dolly's Credit Type_1"); //Entered Description Dolly's Credit type_1
            driver.ClickEleJs(By.XPath("//input[@id='Cancel']")); //Clicked on Cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verified the previous page Credit Types is displayed
            #endregion
            #region Navigate to Create Credit Type page
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.CreditType.SimpleSearch']"));
            driver.ClickEleJs(By.XPath("//option[contains(.,'Create New')]")); //Clicked on Create New
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")); //Selected Go
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'New Credit Type')]"))); //Verified the New Credit Type page heading is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verified the Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Create')]"))); //Verified the Create button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Cancel')]"))); //Verified the Cancel button is displayed
            #endregion
            #region Create Credit Type
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE']")).SendKeysWithSpace("Dolly's Credit Type_1"); //Entered Title Dolly's Credit Type_1
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION']")).SendKeysWithSpace("Dolly's Credit Type_1"); //Entered Description Dolly's Credit type_1
            driver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']")); //Clicked on Create
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the return feedback "The Credit Type was created" is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Edit Activity')]"))); //Verified the Activity tab is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_IS_ACTIVE_1']")));//Verified the Activity = Active is defaulted
            #endregion
            #region Return to Credit Type page
            driver.ClickEleJs(By.XPath("//input[@id='Return']")); //Clicked on Return button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verified the Credit Type page is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion
        }


        [Test]
        public void Manage_Credit_Type_8556()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Manage Credit type
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ActionsMenu_3_CreditType_1_2_3EC305A6B1654F2DADC83650F38F8CA2']")); //Selected "Manage" on Credit Type page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_3']")).ClickWithSpace(); //Clicked on Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Credit Type']"))); //Verified the Edit Credit Type page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verified the Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'ML.BASE.BTN.Save')]"))); //Verified the Save button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'Return')]"))); //Verified the Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE']")); //Edited Title to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION']")); //Edited Description to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//input[@name='ML.BASE.BTN.Save']")); //Clicked on Save
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the feedback received
            #endregion
            #region Edit Activity to Inactive
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Activity')]"))); //Verified Activity field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Start Date')]"))); //Verified Start Date field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'End Date')]"))); //Verified the End Date field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='ML.BASE.BTN.Save']"))); //Verified Save button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Return']"))); //Verified Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_IS_ACTIVE_0']")); //Selected Inactive Radio button
            driver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']")); //Clicked on Save
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the feedback "The activity information was saved" is received
            #endregion
            #region Edit Activity to Active
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_IS_ACTIVE_1']")); //Selected the Active Radio button 
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_START_DATE||DATEPICKER_dateInput']")); //Entered the Start Date to 5/18/2017
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_START_DATE||DATEPICKER_popupButton']")); //Selected the Start Date from the popup calendar
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_NO_START_DATE']")); // Unchecked the No Start Date check box
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_END_DATE||DATEPICKER_dateInput']")); //Entered the End Date 6/30/2017
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_END_DATE||DATEPICKER_popupButton']")); //Selected the End Date from the popup calendar
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_NO_END_DATE']")); //Unchecked the No End Date checkbox
            driver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']")); //Clicked on Save
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the feedback "The activity information was saved" is received
            #endregion
            #region Return to Credit Type page
            driver.ClickEleJs(By.XPath("//input[@id='Return']")); //Clicked on Return button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verified the Credit Type page is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion

            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_3']")); //Clicked on Go button
            driver.FindElement(By.XPath("//span[@title='Edit Credit Type']")); //Verified the Edit Credit Type page is displayed
            driver.FindElement(By.XPath("//span[contains(.,'Title')]")); //Verified the Title fied is displayed
            driver.FindElement(By.XPath("//span[contains(.,'Description')]")); //Verified the Description field is displayed
            driver.FindElement(By.XPath("//input[contains(@id,'ML.BASE.BTN.Save')]")); //Verified the Save button is displayed
            driver.FindElement(By.XPath("//input[contains(@id,'Return')]")); //Verified the Return button is displayed
           


        }

        [Test]
        public void Credit_Type_Simple_Search_8558()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Simple Search Credit Types
            driver.ClickEleJs(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Simple']")); //Click on Simple Search tab
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")); //Searched for "Default"
            driver.ClickEleJs(By.XPath("//input[contains(@id,'ML.BASE.BTN.Search')]")); // Clicked on search
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Credit Type')]"))); //Verify the results datagrid displays "Credit Type" column
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Action')]"))); //Verify the results datagrid displays "Action" column
            Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'Manage')]"))); //Verify the Action menu option "Manage" is displayed for each credit types
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Records found: 1')]"))); //Verify the Records found at least '1' is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion

        }



        [Test]
        public void Credit_Type_Advanced_Search_8559()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Advanced Search Credit Types
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced']")).ClickWithSpace(); //Click on Advanced Search tab
            Assert.IsTrue (driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verify  Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verify Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify Search Type field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Activity')]"))); //Verify Activity field is displayed
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")); //Entered Title value "Continuing"
            driver.ClickEleJs(By.XPath("//input[@value='Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//i[contains(.,'Continuing Education Units')]"))); //Verified the Continuing Education Units is displayed
            driver.FindElement(By.XPath("//input[contains(@id,'DESCRIPTION')]")); //Entered Description value "Education"
            driver.ClickEleJs(By.XPath("//input[@value='Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//i[contains(.,'Continuing Education Units')]"))); //Verified the Continuing Education Units is displayed
            driver.FindElement(By.XPath("//select[contains(@id,'SearchActivity')]")); //Select the Activity as "Active"
            driver.ClickEleJs(By.XPath("//input[@value='Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//i[contains(.,'Continuing Education Units')]"))); //Verified the Continuing Education Units is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Default Credit TypeDefault Credit Type')]"))); //Verified the Default Credit Type is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion

        }

        [Test]
        public void Edit_Assigned_Users_15890()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Manage Credit type
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ActionsMenu_3_CreditType_1_2_3EC305A6B1654F2DADC83650F38F8CA2']")); //Selected "Manage" on Credit Type page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_3']")).ClickWithSpace(); //Clicked on Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Credit Type']"))); //Verified the Edit Credit Type page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verified the Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'ML.BASE.BTN.Save')]"))); //Verified the Save button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'Return')]"))); //Verified the Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE']")); //Edited Title to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION']")); //Edited Description to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//input[@name='ML.BASE.BTN.Save']")); //Clicked on Save
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the feedback received
            #endregion
            #region Assigned Users
            driver.FindElement(By.XPath("//span[contains(.,'Assigned Users')]")); //Clicked on Assigned Users tab
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Assigned Users')]"))); //Verified the Assigned Users 
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verified the Search Test is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verified the Search Type Action drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Type')]"))); //Verified the Type Action drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'User Search')]"))); //Verified the User Action Search drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_LBL_AssignedUsers_ML.BASE.TAB.EntitySearch']")));  //Verified the Add User Action Menu is displayed
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_LBL_AssignedUsers_ML.BASE.BTN.Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Records found: 2')]"))); //Verified the search records displayed with count
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@type='checkbox']"))); // Verified the checkbox for the results is displyed
            Assert.IsTrue(driver.existsElement(By.XPath("//img[contains(@title,'Click to open Information window adminedge, reg')]"))); //Verified the Information Icon is displayed for each line item
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Name/Title')]"))); //Verified the Title column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Type')]"))); //Verified the Type column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Include Subs?')]"))); //Verified the Include Subs column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Assignment Date')]"))); //Verified the Assignment Date column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Remove')]"))); //Verified the Remove button is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion

        }

        [Test]
        public void Add_learning_groups_15891() //Duplicate of 15893
        {
        

        }
          [Test]
        public void Assign_Users_to_Credit_Types_15893()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Manage Credit type
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ActionsMenu_3_CreditType_1_2_3EC305A6B1654F2DADC83650F38F8CA2']")); //Selected "Manage" on Credit Type page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_3']")).ClickWithSpace(); //Clicked on Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Credit Type']"))); //Verified the Edit Credit Type page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verified the Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'ML.BASE.BTN.Save')]"))); //Verified the Save button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'Return')]"))); //Verified the Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE']")); //Edited Title to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION']")); //Edited Description to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//input[@name='ML.BASE.BTN.Save']")); //Clicked on Save
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the feedback received
            #endregion
            #region Assigned Users
            driver.FindElement(By.XPath("//span[contains(.,'Assigned Users')]")); //Clicked on Assigned Users tab
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Assigned Users')]"))); //Verified the Assigned Users 
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verified the Search Test is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verified the Search Type Action drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Type')]"))); //Verified the Type Action drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'User Search')]"))); //Verified the User Action Search drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_LBL_AssignedUsers_ML.BASE.TAB.EntitySearch']")));  //Verified the Add User Action Menu is displayed
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_LBL_AssignedUsers_ML.BASE.BTN.Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Records found: 2')]"))); //Verified the search records displayed with count
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@type='checkbox']"))); // Verified the checkbox for the results is displyed
            Assert.IsTrue(driver.existsElement(By.XPath("//img[contains(@title,'Click to open Information window adminedge, reg')]"))); //Verified the Information Icon is displayed for each line item
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Name/Title')]"))); //Verified the Title column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Type')]"))); //Verified the Type column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Include Subs?')]"))); //Verified the Include Subs column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Assignment Date')]"))); //Verified the Assignment Date column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Remove')]"))); //Verified the Remove button is displayed
            #endregion
            #region Assign Users
            driver.ClickEleJs(By.XPath("//option[@value='ML.BASE.ACT.AddUsers']")); //Selected the Add Users option drop down
            driver.ClickEleJs(By.XPath("//input[@value='Go']")); //Clicked on Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Add Users')]"))); //Verified the Add Users page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verified Search Text field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verified the Search Type field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Type')]")));  //Verified the Type field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'User Search')]"))); //Verified the User Search field is displyed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Search')]"))); //Verified the Search button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Return')]"))); //Verified the Return button is displayed
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_AddUsers_ML.BASE.BTN.Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@class='PRE']"))); //Verified # of records are displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Organization')]"))); //Verified the records contains Type Organization
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'User')]"))); //Verified the records contains Type User
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Role')]")));  //Verified the records contains Type Role
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'User Group')]"))); //Verified the records contains Type User Group
            driver.ClickEleJs(By.XPath("//input[@type='checkbox']")); //Selected the checkbox for Demo 1 Org 1
            driver.ClickEleJs(By.XPath("//input[@value='Add']")); // Clicked on Add button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The selected items were added.')]"))); //Verified the feedback is displayed
            driver.ClickEleJs(By.XPath("//input[@id='Return']")); //Selected the Return button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@class,'WorkflowButtonCurrent')]"))); //Verified the Assigned Users page is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion

        }
          [Test]
        public void Remove_Assigned_Users_15894()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Manage Credit type
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ActionsMenu_3_CreditType_1_2_3EC305A6B1654F2DADC83650F38F8CA2']")); //Selected "Manage" on Credit Type page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_3']")).ClickWithSpace(); //Clicked on Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Credit Type']"))); //Verified the Edit Credit Type page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verified the Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'ML.BASE.BTN.Save')]"))); //Verified the Save button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'Return')]"))); //Verified the Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE']")); //Edited Title to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION']")); //Edited Description to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//input[@name='ML.BASE.BTN.Save']")); //Clicked on Save
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the feedback received
            #endregion
            #region Assigned Users
            driver.FindElement(By.XPath("//span[contains(.,'Assigned Users')]")); //Clicked on Assigned Users tab
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Assigned Users')]"))); //Verified the Assigned Users 
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verified the Search Test is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verified the Search Type Action drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Type')]"))); //Verified the Type Action drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'User Search')]"))); //Verified the User Action Search drop down is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_LBL_AssignedUsers_ML.BASE.TAB.EntitySearch']")));  //Verified the Add User Action Menu is displayed
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_LBL_AssignedUsers_ML.BASE.BTN.Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Records found: 2')]"))); //Verified the search records displayed with count
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@type='checkbox']"))); // Verified the checkbox for the results is displyed
            Assert.IsTrue(driver.existsElement(By.XPath("//img[contains(@title,'Click to open Information window adminedge, reg')]"))); //Verified the Information Icon is displayed for each line item
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Name/Title')]"))); //Verified the Title column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Type')]"))); //Verified the Type column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Include Subs?')]"))); //Verified the Include Subs column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Assignment Date')]"))); //Verified the Assignment Date column is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Remove')]"))); //Verified the Remove button is displayed
            #endregion
            #region Remove Assigned Users
            driver.ClickEleJs(By.XPath("//input[@type='checkbox']")); //Clicked on Check box next to the User to be removed "adminedge,reg"
            driver.ClickEleJs(By.XPath("//input[@value='Remove']")); // Clicked on Remove button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The selected users were removed.')]"))); //Verified the User is removed and feedback message is returned
            driver.ClickEleJs(By.XPath("//input[@value='Return']")); //Clicked on Return
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verified the Cretit Types Search page is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion

        }
          [Test]
        public void Edit_Certificate_Credit_type_learning_group_16216()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region navigate to  Credit Types
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Content Management')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Credit Types')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verify the page contains Categories heading
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verify the page contains Search Text field
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verify the page contains Search Type field
            #endregion
            #region Manage Credit type
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ActionsMenu_3_CreditType_1_2_3EC305A6B1654F2DADC83650F38F8CA2']")); //Selected "Manage" on Credit Type page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_3']")).ClickWithSpace(); //Clicked on Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Credit Type']"))); //Verified the Edit Credit Type page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the Title field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]"))); //Verified the Description field is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'ML.BASE.BTN.Save')]"))); //Verified the Save button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@id,'Return')]"))); //Verified the Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE']")); //Edited Title to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION']")); //Edited Description to Dolly's Credit Type_1_edit
            driver.FindElement(By.XPath("//input[@name='ML.BASE.BTN.Save']")); //Clicked on Save
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ReturnFeedback']"))); //Verified the feedback received
            #endregion
            #region Certificate
            driver.ClickEleJs(By.XPath("//span[contains(.,'Certificate')]")); //Clicked on Certificate tab
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Select Certificate')]"))); //Verified the Select Certificate tab is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Current Certificate')]"))); //Verified the Current Certificate is defaulted
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verified the Search Text is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]"))); //Verified the Search Type is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Search')]"))); //Verified the Search button is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Return')]"))); //Verified the Return button is displayed
            driver.ClickEleJs(By.XPath("//input[@value='Search']")); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='TabMenu_ML_BASE_BTN_SelectCertificate_FeedbackCertificateSearch']"))); //Verified the Records found is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]"))); //Verified the list of records with Title is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Action')]"))); //Verified the list of records with Action is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//input[contains(@value,'Select Certificate')]"))); //Verified the Select Certificate button is displayed
            driver.ClickEleJs(By.XPath("//input[@type='radio']")); //Selected Radio button next to Certificate (Base Example Certificate)
            driver.ClickEleJs(By.XPath("//input[@value='Select Certificate']")); //Clicked on Select Certificate button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The certificate was associated with the content.')]"))); //Verified the certificate is attached and feedback is returned
            driver.FindElement(By.XPath("//span[@id='TabMenu_ML_BASE_BTN_SelectCertificate_CERT_TITLE']")); //Verified the new Certificate is displayed
            driver.ClickEleJs(By.XPath("//input[@id='Return']")); //Selected Return button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Credit Types')]"))); //Verified the Cerdit Types Search page is displayed
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion
            
        }  
        [Test]
        public void Credit_Type_Sharing_25266() //Cannot be automated
        {
           

        }
        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                 driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                TrainingHomeobj.lnk_ContentManagement_click();
                if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                {
                    driver.Navigate().Refresh();
                }
                
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }

    }
}
