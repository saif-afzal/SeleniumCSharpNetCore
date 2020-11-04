using System;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestAutomation.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Training_Assignments : TestBase
    {
        string browserstr = string.Empty;
        public Training_Assignments(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            //  driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://prdct-mg-17-3.mksi-lms.net/");
            //driver.Navigate().GoToUrl("https://baseqa-17-3-m-c1.meridianksi.net");


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
        [Test, Order(1)]//done


        public void Test_when_Authorised_User_sees_instructional_text_on_Create_Training_Assignment_page_30318()
        {


            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Create new assignment - see instructional text and draft status
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            // driver.GetElement(By.XPath(".//*[@id='assignment-title-edit-link']/em")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            driver.WaitForElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]"));
            string expected = "Draft";
            string actual = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (string expected="Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            StringAssert.AreEqualIgnoringCase(expected, actual);
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }

        [Test, Order(2)]//done
        public void Test_when_Authorised_User_Add_Content_in_New_Training_Assignment_30319()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Create new assignment - see instructional text and draft status
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("d");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }

        [Test, Order(3)]//done
        public void Test_when_Authorized_User_adds_Assignees_to_New_Training_Assignment_30320()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Create new assignment - see instructional text and draft status
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(4)]//done
        public void Test_when_Authorized_User_removes_Assignees_to_New_Training_Assignment_30321()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Create new assignment - see instructional text and draft status
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region Remove Assignees
            driver.mouseOverClick(By.XPath("//input[@name='btSelectAll']"));
            //driver.ClickEleJs(By.XPath("//input[@id='btSelectItem_3725705C7EFA41379B496F6661DEAE23']"));
            driver.ClickEleJs(By.XPath("//button[@data-target='#remove-assignees-modal']"));
            Thread.Sleep(3000);
            driver.selectWindow("");
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(5)]//done
        public void Add_Content_to_new_Training_Assignment_29559()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            Thread.Sleep(3000);
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("d");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(6)]//Done
        public void Remove_Content_to_new_Training_Assignment_29560()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            Thread.Sleep(3000);
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Remove Content
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-cnt']"));
            driver.selectWindow("");
            driver.ClickEleJs(By.XPath(".//*[@id='remove-content-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-cnt']"));
            //    driver.selectWindow("");
            //  driver.ClickEleJs(By.XPath("//button[@id='btn-remove-assignees']"));
            driver.ClickEleJs(By.XPath("//button[contains(@id,'btn-remove-content')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(7)]//done
        public void Add_No_Due_Date_to_new_Training_Assignment_30102()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Due Date Default
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-date-save']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='due-date-modal']/div[2]/div/div[3]/button[1]"));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(8)]//DONE
        public void Add_Assignee_to_new_Training_Assignment_30186()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region New Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            Thread.Sleep(3000);
           
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(9)]//done
        public void Create_New_Training_Assignments_30098()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(10)]//done
        public void Manage_Training_Assignments_30136()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            #endregion
            #region Manage Training Assignment
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[1]/h1")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Name')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[5]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[6]/a")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv");
            driver.ClickEleJs(By.XPath(".//*[@id='btn-search']/i"));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(11)]// DONE
        public void Add_content_to_the_active_training_assignments_30229()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            #region Manage Training Assignment
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[1]/h1")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Name')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[5]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[6]/a")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath(".//*[@id='btn-search']/i"));
            #endregion
            //   driver.ClickEleJs(By.XPath(".//*[@id='content_376BB313C0B648ABA21AA15EF80AF3B0']"));
            //  driver.ClickEleJs(By.XPath("//a[@id='content_A62548F7B6004844A8AEBDFE5757F03D']"));
            // driver.GetElement(By.XPath("//a[contains(.,'dv_assignment")).ClickWithSpace();
            driver.ClickEleJs(By.XPath("//a[contains(.,'dv_assignment_')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='assignment-title-edit-link']/em")));
            #region Add Content
            driver.ClickEleJs(By.XPath(".//*[@id='content-modal-button']"));
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(12)]//done
        public void Remove_content_from_the_active_training_assignments_30228()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            #region Manage Training Assignment
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[1]/h1")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Name')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[5]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[6]/a")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath(".//*[@id='btn-search']/i"));
            #endregion
            //   driver.ClickEleJs(By.XPath(".//*[@id='content_376BB313C0B648ABA21AA15EF80AF3B0']"));
            //  driver.ClickEleJs(By.XPath("//a[@id='content_A62548F7B6004844A8AEBDFE5757F03D']"));
            // driver.GetElement(By.XPath("//a[contains(.,'dv_assignment")).ClickWithSpace();
            driver.ClickEleJs(By.XPath("//a[contains(.,'dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='assignment-title-edit-link']/em")));
            #region Remove Content
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-cnt']"));
            Thread.Sleep(3000);
            driver.selectWindow("");
            driver.ClickEleJs(By.XPath(".//*[@id='remove-content-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-cnt']"));
            //    driver.selectWindow("");
            //  driver.ClickEleJs(By.XPath("//button[@id='btn-remove-assignees']"));
            driver.ClickEleJs(By.XPath("//button[contains(@id,'btn-remove-content')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(13)]//done
        public void Add_Assignees_in_Active_Training_Assignments_30232()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            Thread.Sleep(10000);
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            #region Manage Training Assignment
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[1]/h1")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Name')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[5]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[6]/a")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath(".//*[@id='btn-search']/i"));
            #endregion
            driver.ClickEleJs(By.XPath("//a[contains(.,'dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='assignment-title-edit-link']/em")));
            #region Add Assignees
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            driver.ClickEleJs(By.XPath("//button[@id='assignees-modal-button']"));
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace("b");
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//input[contains(@id,'ML.BASE.ROLE.BundleManager')]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(14)]// DONE
        public void Remove_Assignees_in_Active_Training_Assignments_30230()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            Thread.Sleep(3000);
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.SelectFrame(By.Id("SearchFor"));
            driver.selectWindow();
            Thread.Sleep(3000);
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            Thread.Sleep(3000);
            //driver.selectWindow();
            driver.ClickEleJs(By.XPath("//input[@data-index='1']"));
     //       driver.ClickEleJs(By.XPath(".//*[@id='btSelectItem_3725705C7EFA41379B496F6661DEAE23']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            #region Manage Training Assignment
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[1]/h1")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Name')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[5]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[6]/a")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath(".//*[@id='btn-search']/i"));
            #endregion
            driver.ClickEleJs(By.XPath("//a[contains(.,'dv_assignment_')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='assignment-title-edit-link']/em")));
            #region Remove Assignees
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            driver.ClickEleJs(By.XPath(".//*[@id='training-assignees']/thead/tr/th[1]/div[1]/input"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-assignees']"));
            driver.selectWindow();
            Assert.IsTrue(driver.existsElement(By.XPath("//div[@id='remove-assignee-warning']")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No assignees have been added.')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(15)]//done
        public void Authorized_user_deletes_Draft_training_assignment_from_Detail_page_30300()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            Thread.Sleep(10000);
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region Delete draft Assignment from detail page
            driver.ClickEleJs(By.XPath("//button[@id='rt-options-delete']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Delete')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='delete-assignment-modal']/div[2]/div/div[4]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='rt-options-delete']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Delete')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-delete-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Manage Training Assignments')]")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'No matching records found')]")));//verify content should not found
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(16)]//done
        public void Authorized_user_deletes_Draft_training_assignment_from_Manage_Assignment_page_30302()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            Thread.Sleep(10000);
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region Delete draft Assignment from manage assignment page
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Manage Training Assignments')]")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-assignment']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(@class,'modal-title')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='remove-assignment-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-assignment']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(@class,'modal-title')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-delete-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Manage Training Assignments')]")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).Clear();
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@name='btSelectAll']"));
            driver.ClickEleJs(By.XPath("//button[contains(.,'Delete')]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-delete-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'No matching records found')]")));//verify assignment not appear in result as its deleted
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(17)]//done
        public void Authorized_user_deletes_Active_training_assignment_from_Detail_page_30307()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            Thread.Sleep(10000);
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region Assign Assignment
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Assigned')]")));
            #endregion
            #region Delete Active Assignment from detail page
            driver.ClickEleJs(By.XPath("//button[@id='rt-options-delete']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Delete')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='delete-assignment-modal']/div[2]/div/div[4]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='rt-options-delete']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Delete')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-delete-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Manage Training Assignments')]")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'No matching records found')]")));//verify content should not found
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(18)]
        public void Authorized_user_deletes_Active_training_assignment_from_Manage_Training_page_30308()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            Thread.Sleep(10000);
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region Assign Assignment
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='confirm-assign-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Assigned')]")));
            #endregion
            #region Delete Active Assignment from manage assignment page
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Manage Training Assignments')]")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-assignment']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(@class,'modal-title')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='remove-assignment-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-assignment']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(@class,'modal-title')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-delete-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Manage Training Assignments')]")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).Clear();
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.mouseOverClick(By.XPath("//input[@name='btSelectAll']"));
            driver.ClickEleJs(By.XPath("//button[contains(.,'Delete')]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-delete-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'No matching records found')]")));//verify assignment not appear in result as its deleted
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(19)]//done
        public void Create_New_Training_Assignment_29517()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(20)]//done
        public void Manage_Training_Assignments_30036()
        {

            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            #endregion
            #region New Training Assignment Portlet
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            Thread.Sleep(3000);
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("a");
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            Thread.Sleep(10000);
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
           // driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            #region Manage Training Assignment
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[1]/h1")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Name')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[5]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[6]/a")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv");
            driver.ClickEleJs(By.XPath(".//*[@id='btn-search']/i"));
            #endregion
            #region Manage Extensions
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li/a"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Manage Training Assignments')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[2]/div/button"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[2]/div/ul/li[1]/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[2]/div/ul/li[2]/a"));
            driver.selectWindow();
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='MainHeading']")));
            driver.SelectWindowClose2("Manage Extensions & Exemptions");
            #endregion
            //could not automate further as it required dated completion/date extended.
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(21)]//not done as it is failing in external site for the bug
        public void Assign_Training_To_Users_30185()
        {
            #region create new learner 
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_UC5_lnkCreateAccount']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' Create New Account')]")));//create new account page
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//enter text as learnerdv1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_PASSWORD']")).SendKeysWithSpace("password");// enter password as password
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_ConfirmPassword']")).SendKeysWithSpace("password");//re-enter pwd
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']")).SendKeysWithSpace("learner");//enter name as dv1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']")).SendKeysWithSpace("" + Meridian_Common.globalnum);//enter lastname as singh
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='MainContent_UC1_lnkSelectOrg']")));//select org label
            driver.GetElement(By.XPath("//a[@id='MainContent_UC1_lnkSelectOrg']")).ClickWithSpace();//click on button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@class='k-window-title']")));//new popup window
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Select Organizations')]")));//verify label
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Select an item from search results, then select Save.')]")));//verify text
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Find Organization')]")));//check label
            driver.GetElement(By.XPath("//input[@type='text']")).SendKeysWithSpace("sample");//enter text as sample
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='SearchType']")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DV.SearchStartsWith']"), "Starts with");// select type as start with
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();//click on search
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Organizations')]")));// verify column organization
            Assert.IsTrue(driver.existsElement(By.XPath("//th[contains(.,'Path')]")));//verify column path
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Sample Organization 1')]")));//check org1
            driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']")).ClickWithSpace();//click checkbox for sample org1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']")).ClickWithSpace();//click on save
            driver.SwitchTo().DefaultContent();
            Assert.IsTrue(driver.existsElement(By.XPath("//li[contains(.,'Sample Organization 1')]")));//verify org added and option to delete it is there
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Create']")).ClickWithSpace();//click on create
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Welcome')]")));//verify user loggedin and see welcome text
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new document with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top                                                                                                       //driver.GetElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
                                                                                                                                    //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.google.com"); // enter url www.google.com
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-content']"));
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);
            Thread.Sleep(5000);
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            //Thread.Sleep(10000);
            //driver.WaitForElement(By.XPath("//input[@data-index='0']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            Thread.Sleep(10000);
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='filter-group']/div/div/div/button"));
            driver.ClickEleJs(By.XPath(".//*[@id='RoleType']/li[5]/a"));
            driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace(Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            driver.WaitForElement(By.XPath("//input[@data-index='0']"));
        
          
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[3]/div[1]/div[2]/div[4]/div[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='spInclude']/div/div/span[3]"));
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[1]/h4"));
            //          driver.GetElement(By.XPath("//input[@name='btSelectItem']")).ClickWithSpace();
           
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.Id("btn-assign")));
            #endregion
            #region Assign Assignment
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='confirm-assign-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Assigned')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='btn-assign']")));
            #endregion           
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Learner view Assignment on Current Training and Transcript
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,' Current Training')]")));
            
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'dv_doc"+ Meridian_Common.globalnum + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Current Training')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Transcript')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Training Assignments')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Training Assignments')]"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_ucQLinks_moreInfoBtn']"));
            //verify on Transciprt under Training Assignment Tab 
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(22)]//need to check in Dharab for last lines as well as Transcript is not avaialable

        public void Remove_content_from_the_active_training_assignments_30209()
        {

            #region create new learner 
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_UC5_lnkCreateAccount']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' Create New Account')]")));//create new account page
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//enter text as learnerdv1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_PASSWORD']")).SendKeysWithSpace("password");// enter password as password
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_ConfirmPassword']")).SendKeysWithSpace("password");//re-enter pwd
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']")).SendKeysWithSpace("learner");//enter name as dv1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']")).SendKeysWithSpace("" + Meridian_Common.globalnum);//enter lastname as singh
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='MainContent_UC1_lnkSelectOrg']")));//select org label
            driver.GetElement(By.XPath("//a[@id='MainContent_UC1_lnkSelectOrg']")).ClickWithSpace();//click on button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@class='k-window-title']")));//new popup window
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Select Organizations')]")));//verify label
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Select an item from search results, then select Save.')]")));//verify text
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Find Organization')]")));//check label
            driver.GetElement(By.XPath("//input[@type='text']")).SendKeysWithSpace("sample");//enter text as sample
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='SearchType']")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DV.SearchStartsWith']"), "Starts with");// select type as start with
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();//click on search
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Organizations')]")));// verify column organization
            Assert.IsTrue(driver.existsElement(By.XPath("//th[contains(.,'Path')]")));//verify column path
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Sample Organization 1')]")));//check org1
            driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']")).ClickWithSpace();//click checkbox for sample org1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']")).ClickWithSpace();//click on save
            driver.SwitchTo().DefaultContent();
            Assert.IsTrue(driver.existsElement(By.XPath("//li[contains(.,'Sample Organization 1')]")));//verify org added and option to delete it is there
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Create']")).ClickWithSpace();//click on create
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Welcome')]")));//verify user loggedin and see welcome text
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new document with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top                                                                                                       //driver.GetElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
                                                                                                                                    //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.google.com"); // enter url www.google.com
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region Add Content
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'No content has been added.')]")));
            driver.GetElement(By.XPath("//button[@id='btn-find-content']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@placeholder='Search for Content']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);
            Thread.Sleep(10000);
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following content item(s):')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='content']")));
            #endregion
            #region Add Assignees
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'assignees-warning')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Assignees')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[5]/button[1]"));   //click cancel
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));  //verify no item added
            driver.ClickEleJs(By.XPath("//button[@id='btn-find-assignees']"));
            driver.selectWindow();
            driver.ClickEleJs(By.XPath(".//*[@id='filter-group']/div/div/div/button"));
            driver.ClickEleJs(By.XPath(".//*[@id='RoleType']/li[5]/a"));
            driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace("learner " + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//a[@id='btn-search']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[3]/div[1]/div[2]/div[4]/div[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='spInclude']/div/div/span[3]"));
            driver.ClickEleJs(By.XPath(".//*[@id='find-assignees-modal']/div[2]/div/div[1]/h4"));
            //          driver.GetElement(By.XPath("//input[@name='btSelectItem']")).ClickWithSpace();
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-add-assignees']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'This training assignment includes the following assignees:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@aria-controls='assignees']")));
            #endregion
            #region Assign Assignment
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='confirm-assign-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Assign Training')]")));
            driver.ClickEleJs(By.XPath("//button[@id='btn-assign-ok']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Assigned')]")));
            #endregion           
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Learner view Assignment on Current Training and Transcript
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,' Current Training')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Current Training')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Transcript')]"));
            //  driver.ClickEleJs(By.XPath("//a[@id='MainContent_ucQLinks_moreInfoBtn']"));
            //verify on Transciprt under Training Assignment Tab 
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Manage Training Assignment
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Training Assignments')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[1]/div[1]/h1")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Name')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[5]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='training-assignment']/thead/tr/th[6]/a")));
            driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath(".//*[@id='btn-search']/i"));
            #endregion
            driver.ClickEleJs(By.XPath("//a[contains(.,'dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='assignment-title-edit-link']/em")));
            #region Remove Content
            Thread.Sleep(5000);
            driver.mouseOverClick(By.XPath("//input[@data-index='0']"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-cnt']"));
            driver.selectWindow("");
            driver.ClickEleJs(By.XPath(".//*[@id='remove-content-modal']/div[2]/div/div[3]/button[1]"));
            driver.ClickEleJs(By.XPath("//button[@id='btn-remove-selected-cnt']"));
            //    driver.selectWindow("");
            //  driver.ClickEleJs(By.XPath("//button[@id='btn-remove-assignees']"));
            driver.ClickEleJs(By.XPath("//button[contains(@id,'btn-remove-content')]"));
            // Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,' No assignees have been added.')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Learner view Assignment on Current Training and Transcript
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,' Current Training')]")));
            Assert.IsFalse(driver.existsElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ctl00_MainContent_ucUpcomingTraining_RadGrid1_ctl00']/tbody/tr/td/span")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Current Training')]"));
            Assert.IsFalse(driver.existsElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div/div/div[1]/div[1]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'No records found.')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Transcript')]"));
            //verify on Transciprt under Training Assignment Tab 
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(23)]//done
        public void Add_One_Time_Fixed_year_Due_Date_to_new_Training_Assignment_30234()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region Fixed-year Due Date
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            //not able to click via automation on toggle switch
            //driver.ClickEleJs(By.Id("Due_Date_Times_Once"));
            //driver.ClickEleJs(By.XPath("//span[@class='bootstrap-switch-handle-off bootstrap-switch-default firepath-matching-node']"));
            //  driver.ClickEleJs(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_More']"));
            driver.ClickEleJs(By.XPath("//select[@id='Due_Date_When_Zone']"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_Once']"));
            string format = "MM/dd/yyyy";
           
            string startenroldate = DateTime.Now.AddDays(2).ToString(format);
            startenroldate = startenroldate.Replace("-", "/");
   
            // driverobj.GetElement(ObjectRepository.EnrolEndDate).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
            driver.GetElement(By.XPath("//input[@id='Due_Date_When_On_Date']")).Click();
            driver.GetElement(By.XPath("//input[@id='Due_Date_When_On_Date']")).Clear();
            driver.GetElement(By.XPath("//input[@id='Due_Date_When_On_Date']")).SendKeysWithSpace(startenroldate);
            #endregion
            #region Reminder Email
            driver.ClickEleJs(By.XPath("//a[@class='due-date-reminder-add']"));
            driver.GetElement(By.XPath("//input[@id='reminder-time-0']")).SendKeysWithSpace("5");
            driver.ClickEleJs(By.XPath("//select[@id='reminder-period-0']"));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-save']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'"+ DateTime.Now.AddDays(2).ToString(format) + "')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='reminderemails']/li")));
            #endregion
            #region logout

            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(24)]//done
        public void Add_One_Time_Floating_year_Due_Date_to_new_Training_Assignment_30238()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region Floating-year Due Date
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            //not able to click via automation on toggle switch
            //  driver.ClickEleJs(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_More']"));
            driver.ClickEleJs(By.XPath("//select[@id='Due_Date_When_Zone']"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_Once']"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_When_By']"));
            //   driver.GetElement(By.XPath("//input[@id='Due_Date_When_By_Date']")).SendKeysWithSpace("0412");
            string format = "MM/dd";

            string startenroldate = DateTime.Now.AddDays(2).ToString(format);
            startenroldate = startenroldate.Replace("-", "/");

            // driverobj.GetElement(ObjectRepository.EnrolEndDate).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
            driver.GetElement(By.XPath("//input[@id='Due_Date_When_By']")).Click();
          //  driver.GetElement(By.XPath("//input[@id='Due_Date_When_By']")).Clear();
            driver.GetElement(By.XPath("//input[@id='Due_Date_When_By_Date']")).SendKeysWithSpace(startenroldate);
            #endregion
            #region Reminder Email
            driver.ClickEleJs(By.XPath("//a[@class='due-date-reminder-add']"));
            driver.GetElement(By.XPath("//input[@id='reminder-time-0']")).SendKeysWithSpace("5");
            driver.ClickEleJs(By.XPath("//select[@id='reminder-period-0']"));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-save']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'" + DateTime.Now.AddDays(2).ToString(format) + "')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='reminderemails']/li")));
            #endregion
            #region logout

            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(25)]//done
        public void Add_One_Time_Dynamic_Date_Range_to_new_Training_Assignment_30239()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region Dynamic Date Range
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            //not able to click via automation on toggle switch
            //  driver.ClickEleJs(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_More']"));
            driver.ClickEleJs(By.XPath("//select[@id='Due_Date_When_Zone']"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_Once']"));
            driver.GetElement(By.XPath("//input[@id='Due_Date_When_Within_Amount']")).SendKeysWithSpace("15");
            driver.ClickEleJs(By.XPath("//select[@id='Due_Date_When_Within_Time']"));
            #endregion
            #region Reminder Email
            driver.ClickEleJs(By.XPath("//a[@class='due-date-reminder-add']"));
            driver.GetElement(By.XPath("//input[@id='reminder-time-0']")).SendKeysWithSpace("5");
            driver.ClickEleJs(By.XPath("//select[@id='reminder-period-0']"));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-save']"));
            #endregion
            #region Date verification on detail page
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'15 Day(s)')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='reminderemails']/li")));
            #endregion
            #region logout

            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(26)]//done
        public void Access_Manage_Extension_and_Exemption_from_Training_Assignment_portlets_30311()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            #endregion
            #region Manage Extenstions and Exemptions
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]"));
            driver.selectWindow();
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='MainHeading']")));
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_SortLink_ReqTrainingContent_CNT_TITLE']/span")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ReqTrainingContent']/tbody/tr[2]/td[5]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ReqTrainingContent']/tbody/tr[2]/td[6]")));
            //select[@contenttype='ReqTraining']
            Assert.IsTrue(driver.existsElement(By.XPath("//select[@contenttype='ReqTraining']")));
          //  Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ActionsMenu_1_ReqTrainingContent_1_0_B1AA9249FF8A46D6A1269456E4959D46']")));
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ReqTrainingContent_GoButton_1']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'View Assignees')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'View Assigned Users')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'Manage Current Extension Training Periods')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'Manage Training Period Exemptions')]")));
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_ViewAssignees_ML.BASE.BTN.Search']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_ViewAssignees_ASSIGNED_ENTITY']/tbody/tr[2]/td[3]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_ViewAssignees_ASSIGNED_ENTITY']/tbody/tr[2]/td[4]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_ViewAssignees_ASSIGNED_ENTITY']/tbody/tr[2]/td[5]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_ViewAssignees_ASSIGNED_ENTITY']/tbody/tr[2]/td[6]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_ViewAssignees_ASSIGNED_ENTITY']/tbody/tr[2]/td[7]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_ViewAssignees_ASSIGNED_ENTITY']/tbody/tr[2]/td[8]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_ViewAssignees_ASSIGNED_ENTITY']/tbody/tr[2]/td[9]")));
            #endregion
            #region logout
            driver.Navigate_to_TrainingHome();
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(27)]//done
        public void Add_Recurring_no_initial_Due_Date_to_new_Training_Assignment_30491()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            Thread.Sleep(3000);
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region Recurring no initial Due Date
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            //not able to click via automation on toggle switch
            //  driver.ClickEleJs(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_More']"));
            driver.GetElement(By.XPath("//input[@id='Due_Date_Recur_Every_Number']")).SendKeysWithSpace("15");
            driver.ClickEleJs(By.XPath(".//*[@id='Due_Date_Recur_Every_Time']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Occur_No']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Training_Current_Always']")));
            #endregion
            #region Reminder Email
            driver.ClickEleJs(By.XPath("//a[@class='due-date-reminder-add']"));
            driver.GetElement(By.XPath("//input[@id='reminder-time-0']")).SendKeysWithSpace("5");
            driver.ClickEleJs(By.XPath("//select[@id='reminder-period-0']"));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-save']"));
            #endregion
            #region Date verification on detail page
            Assert.IsTrue(driver.existsElement(By.XPath("//p[@id='due']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,' 15 Day(s)')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'After the previous training period ends')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Do not count')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Always')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='reminderemails']/li")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(28)]//done
        public void Add_Recurring_Yes_By_Float_Due_Date_to_new_Training_Assignment_30493()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region Recurring YEs By Float Due Date
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            //not able to click via automation on toggle switch
            //  driver.ClickEleJs(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_More']"));
            driver.GetElement(By.XPath("//input[@id='Due_Date_Recur_Every_Number']")).SendKeysWithSpace("15");
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Occur_Yes_By_MMDD']"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Occur_Yes_By_Date']"));
            driver.GetElement(By.XPath("//input[@id='Due_Date_Occur_Yes_By_Date']")).SendKeysWithSpace("1112");
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Occur_No']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Training_Current_Always']")));
            #endregion
            #region Reminder Email
            driver.ClickEleJs(By.XPath("//a[@class='due-date-reminder-add']"));
            driver.GetElement(By.XPath("//input[@id='reminder-time-0']")).SendKeysWithSpace("5");
            driver.ClickEleJs(By.XPath("//select[@id='reminder-period-0']"));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-save']"));
            #endregion
            #region Date verification on detail page
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'11/12')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,' 15 Day(s)')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Do not count')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Always')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='reminderemails']/li")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(29)]//done
        public void Add_Recurring_Yes_By_Fixed_Due_Date_to_new_Training_Assignment_30494()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region Recurring YEs By Fixed Due Date
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            //not able to click via automation on toggle switch
            //  driver.ClickEleJs(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_More']"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Occur_By']"));
            driver.GetElement(By.XPath("//input[@id='Due_Date_Recur_Every_Number']")).SendKeysWithSpace("15");
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Occur_Yes_By_MMDD']"));
            string format = "MM/dd/yyyy";

            string startenroldate = DateTime.Now.AddDays(2).ToString(format);
            startenroldate = startenroldate.Replace("-", "/");

            // driverobj.GetElement(ObjectRepository.EnrolEndDate).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
            driver.GetElement(By.XPath("//input[@id='Due_Date_Occur_By_Date']")).Click();
            driver.GetElement(By.XPath("//input[@id='Due_Date_Occur_By_Date']")).Clear();
            driver.GetElement(By.XPath("//input[@id='Due_Date_Occur_By_Date']")).SendKeysWithSpace(startenroldate);
           
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Occur_No']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Training_Current_Always']")));
            #endregion
            #region Reminder Email
            driver.ClickEleJs(By.XPath("//a[@class='due-date-reminder-add']"));
            driver.GetElement(By.XPath("//input[@id='reminder-time-0']")).SendKeysWithSpace("5");
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-save']"));
            #endregion
            #region Date verification on detail page
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'"+ DateTime.Now.AddDays(2).ToString(format) + "')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,' 15 Day(s)')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Do not count')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Always')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='reminderemails']/li")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[@id='sendextensionemails']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(30)]//done
        public void Add_Recurring_Yes_Within_Due_Date_to_new_Training_Assignment_30495()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            driver.ClickEleJs(By.LinkText("Create Training Assignment"));
            Assert.IsTrue(driver.existsElement(By.XPath("//button[@id='rt-options-delete']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'content-warning')]")));
            //   Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'A training assignment is a collection of learning content assigned to individual users or groups of users.Assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date.As soon as you update a blank training assignment, the assignment is saved as a draft. ')]")));
            driver.GetElement(By.XPath(".//*[@id='instruction-div']/p"));
            // driver.GetElement(By.XPath("//em[contains(.,'Unnamed Assignment')]")).ClickWithSpace();
            driver.ClickEleJs(By.XPath(".//*[@id='assignment-title-edit-link']/em"));
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).Clear();
            driver.GetElement(By.XPath("//input[@id='assignment-title-edit']")).SendKeysWithSpace("dv_assignment_" + ExtractDataExcel.token_for_reg + browserstr);
            driver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            driver.ClickEleJs(By.XPath("//span[@class='fa fa-fw fa-question-circle']")); //click on draft
            string text = driver.GetElement(By.XPath(".//*[@id='content']/div[2]/div/p[1]")).Text;// need to validate text (Training assignments have no due date by default, but you may require users to complete content within a given time frame or by a specified date. An assignment must include at least one content item and one assignee before it can be assigned to users.)
            #endregion
            #region New Training Assignment - Add Desc and Keyword
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/p[2]/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Description:')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'Keywords:')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='edit-description-link']"));
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test desc");
            driver.ClickEleJs(By.XPath(".//*[@id='description-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            driver.GetElement(By.XPath("//a[@id='edit-description-link']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test desc')]")));
            driver.ClickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).Clear();
            driver.GetElement(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace("test keyword");
            driver.ClickEleJs(By.XPath(".//*[@id='keywords-edit']/span/div/form/div/div[1]/div[2]/div/button[1]"));
            //driver.ClickEleJs(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'test keyword')]")));
            #endregion
            #region Lock/Unlock Assignment
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Lock Assignment')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]")));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/div/div/span[1]")));
            #endregion
            #region Recurring YEs By Within Due Date
            driver.ClickEleJs(By.XPath("//a[@aria-controls='dueDate']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'This assignment has no due date.')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC3_btnCancel']")));
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-edit']"));
            driver.selectWindow();
            driver.mouseOverClick(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            //not able to click via automation on toggle switch
            //  driver.ClickEleJs(By.XPath(".//*[@id='due-date-status']/div[1]/div/div/span[2]"));
            driver.ClickEleJs(By.XPath("//input[@id='Due_Date_Times_More']"));
            driver.GetElement(By.XPath("//input[@id='Due_Date_Recur_Every_Number']")).SendKeysWithSpace("15");
            driver.GetElement(By.XPath("//input[@id='Due_Date_Occur_Within_Time']")).SendKeysWithSpace("20");
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Occur_No']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='Due_Date_Training_Current_Always']")));
            #endregion
            #region Reminder Email
            driver.ClickEleJs(By.XPath("//a[@class='due-date-reminder-add']"));
            driver.GetElement(By.XPath("//input[@id='reminder-time-0']")).SendKeysWithSpace("5");
            driver.ClickEleJs(By.XPath("//button[@id='rt-date-save']"));
            #endregion
            #region Date verification on detail page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='due']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='recurrence']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='trainingperiod']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='completionsafterduedate']")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Always')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[@id='sendextensionemails']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }

        [Test, Order(31)]//done
        public void First_due_date_NOT_different_and_Previous_Completions_Settings_Yes_if_completed_within_the_recurrence_interval_30870()


        {
            Assert.Ignore("Cannot be automated, because of recurrance for learner to see past and new date");
        }
        [Test, Order(32)]//done
        public void First_due_date_different_and_Previous_Completions_Settings_Yes_if_completed_within_the_recurrence_interval_30871()
        {
            Assert.Ignore("Cannot be automated, because of recurrance for learner to see past and new date");


        }

        [Test, Order(33)]//DOne
        public void Manage_settings_for_Training_Assignment_29439()
        {
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Content Settings
            driver.HoverLinkClick(By.XPath(".//*[@id='mega-li']/a"), By.XPath(".//*[@id='admin-console-contentPanelHeader']/h3/a"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Training Assignment Settings')]"));
            driver.selectWindow("Training Assignment Settings");
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainHeading']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TrainingAssignmentSettings_TDElementREQUIRED_TRAINING_STATUS_QUESTION']")));

            #endregion
        }
        [Test, Order(34)]//done
        public void Edit_Permissions_for_Custom_Role_create_manage_training_assignments_30756()
        {

            #region create new learner 
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_UC5_lnkCreateAccount']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' Create New Account')]")));//create new account page
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//enter text as learnerdv1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_PASSWORD']")).SendKeysWithSpace("password");// enter password as password
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_ConfirmPassword']")).SendKeysWithSpace("password");//re-enter pwd
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']")).SendKeysWithSpace("learner");//enter name as dv1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']")).SendKeysWithSpace("dv" + Meridian_Common.globalnum);//enter lastname as singh
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='MainContent_UC1_lnkSelectOrg']")));//select org label
            driver.GetElement(By.XPath("//a[@id='MainContent_UC1_lnkSelectOrg']")).ClickWithSpace();//click on button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@class='k-window-title']")));//new popup window
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Select Organizations')]")));//verify label
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'Select an item from search results, then select Save.')]")));//verify text
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Find Organization')]")));//check label
            driver.GetElement(By.XPath("//input[@type='text']")).SendKeysWithSpace("sample");//enter text as sample
            Assert.IsTrue(driver.existsElement(By.XPath("//label[@for='SearchType']")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DV.SearchStartsWith']"), "Starts with");// select type as start with
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();//click on search
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Organizations')]")));// verify column organization
            Assert.IsTrue(driver.existsElement(By.XPath("//th[contains(.,'Path')]")));//verify column path
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Sample Organization 1')]")));//check org1
            driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']")).ClickWithSpace();//click checkbox for sample org1
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']")).ClickWithSpace();//click on save
            driver.SwitchTo().DefaultContent();
            Assert.IsTrue(driver.existsElement(By.XPath("//li[contains(.,'Sample Organization 1')]")));//verify org added and option to delete it is there
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Create']")).ClickWithSpace();//click on create
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Welcome')]")));//verify user loggedin and see welcome text
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region CreateNewRole
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));//mouse hover
            driver.GetElement(By.XPath("//a[contains(.,'Roles')]")).ClickWithSpace();//click role
   //         driver.WaitForElement(By.XPath("//option[contains(.,'Create New')]"));
            //new tab open
            driver.selectWindow("Roles");
            driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.FAQSimpleSearch']")); //select create new
            driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));//click on go button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainHeading']")));//verify label on new page
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_NAME']")).SendKeysWithSpace("Reg_TrainingAssignment_" + ExtractDataExcel.token_for_reg);//enter name as reg_gamification
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_ROLE_DESCRIPTION']")).SendKeysWithSpace("testdesc");//enter descriptin as test
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='Cancel']")));//verify cancel button
            driver.GetElement(By.XPath(".//*[@id='ML.BASE.BTN.Create']")).ClickWithSpace();//click on create button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ReturnFeedback']")));//verify messgage
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='Return']")));//verify return button
            driver.GetElement(By.XPath(".//*[@id='ML.BASE.BTN.Save']")).ClickWithSpace();//click on save button
            driver.ClickEleJs(By.XPath(".//*[@id='BreadCrumbs']/table/tbody/tr/td/a"));//click on reole breadcrumb
            #endregion
            #region search role
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeysWithSpace("Reg_TrainingAssignment_" + ExtractDataExcel.token_for_reg);//enter text as reg_gamification
            driver.GetElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_SearchType']")).Click();
            driver.GetElement(By.XPath("//option[contains(@value,'ML.BASE.DV.SearchExactPhrase')]")).Click();
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")).ClickWithSpace();//click on search button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[2]/td[3]")));//verify title name should be reg_gamificaiton
            #endregion
            #region assign Training Assignment role to user
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']")).ClickWithSpace();//click on go button
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_EditRole_GoPageActionsMenu']")).ClickWithSpace();//click on go button
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_LAST_NAME']")).SendKeysWithSpace("dv" + Meridian_Common.globalnum);//enter last name 
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_btnSearch']")).ClickWithSpace();//click on search button
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers']/tbody/tr[2]/td[3]"));//verify  user's last name
            driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME']"));//click on checkbox for that user
            driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_btnAdd']"));//click on add selected button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ReturnFeedback']")));//verify message
            driver.ClickEleJs(By.XPath("//a[@pageid='ML.BASE.TAB.EditRole']"));
            driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_EditRole_ML.BASE.BTN.Search']"));//click on search button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_EditRole_FeedbackRolePermissionsDataGrid']")));
            driver.ClickEleJs(By.XPath(".//*[@id='BreadCrumbs']/table/tbody/tr/td/a"));//click on roles breadcrumb
            driver.GetElement(By.XPath(".//*[@id='MainHeading']"));//verify user lands on roles page
            #endregion
            #region search role
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).Clear();
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeysWithSpace("Reg_TrainingAssignment_" + ExtractDataExcel.token_for_reg);//enter text as reg_gamification
            driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_SearchType']"));
            driver.ClickEleJs(By.XPath("//option[contains(.,'Exact phrase')]"));
            driver.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")).ClickWithSpace();//click on search button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[2]/td[3]")));//verify title name should be reg_gamificaiton
            #endregion
            #region edit permissions for Training Assignment role
            //   driver.ClickEleJs(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_ActionsMenu']"));
            driver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_ActionsMenu']"), "Edit Permission");
            //     driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_ActionsMenu']/option[5]"));
            driver.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton']"));//click on go button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainHeading']")));//verify label on page
            driver.GetElement(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00']/thead/tr/th[3]"));//verify allow column
            driver.GetElement(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00']/thead/tr/th[4]"));//verify deny column
            driver.GetElement(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00']/thead/tr/th[5]"));//verify default column
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl12_Detail30__1:0_2:0_8']/td[2]")));//verify TA module appearing in this list
            driver.ClickEleJs(By.XPath(".//*[@id='ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl12_Detail30_ctl28_rbAllow']"));//click on allow
     //       driver.GetElement(By.XPath("//input[contains(@id,'ctl11_RadGrid1_ctl00_ctl09_Detail20_ctl34_rbAllow')]"));//select allow radio button for this 
            driver.ClickEleJs(By.XPath(".//*[@id='ctl11_btnSave']"));//click save
            driver.ClickEleJs(By.XPath(".//*[@id='ReturnFeedback']"));//verify success message
            driver.Navigate_to_TrainingHome();
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Learner sees Training Assignment Portlet
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Training Assignments')]")));//verify label
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Training Assignments')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Manage Extensions & Exemptions')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

            //above Testcase can be used in MTM Testcase 9193 - Add/Edit USers :Roles (System Roles)
        }

        [Test, Order(35)]//done
        public void Apply_Remove_Extensions_30312()
        {
            Assert.Ignore("Cannot be automated, because of recurrance for learner to see past and new date");

        }
        // Survey Related Testcases started..
        [Test, Order(36)]
        public void Update_System_emails_for_Required_Training_30207() { Assert.Ignore("Cannot be automated, because of recurrance for learner to see past and new date"); }
        [Test, Order(37)]
        public void Create_Survey_24656()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[3]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[5]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_lblSearchBoost']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_MLabel4']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[8]/div[1]/div/label")));
            //       Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[8]/div[2]/div/label"))); locale drop down not appearing so commented this for now
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[9]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[10]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Page1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Page1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[4]/div[2]/p/button")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_hlSurvey']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_pnlContent']/div[2]/div/div[1]/div/div/div[1]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucCategories_pnlCategories']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucContentSharing_pnlContentSharing']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPermissions_pnlPermission']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucImage_pnlImage']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucActivity_pnlActivity']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucWindow_pnlWindow']/div/div/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='contentDetailsHeader']/div[1]/h1")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(38)]
        public void Create_Survey_Section_24659()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[3]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[5]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_lblSearchBoost']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_MLabel4']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[8]/div[1]/div/label")));
            //       Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[8]/div[2]/div/label"))); locale drop down not appearing so commented this for now
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[9]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[10]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            #endregion
            #region Create Survey Section
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[2]")));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Page1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Page1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[4]/div[2]/p/button")));
            driver.ClickEleJs(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/button"));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnPublishSurvey']"));

            //driver.SelectFrame(By.XPath("//button[@type='button'])[29]")); ok button not working
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/p")));//verify published
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_hlSurveyStructure']"));
            Assert.IsFalse(driver.GetElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button")).Enabled);
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(39)]
        public void Create_Question_24661()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey/Question from Manage>Surveys
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), (By.XPath("//a[contains(@href,'/SurveyConsole')]"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            driver.ClickEleJs(By.XPath(".//*[@id='containerSurveys']/div[1]/div[3]/p/a/span[2]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Page1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Page1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button"));//click add question link
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Edit Question')]")));
            driver.FindElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/button"));//default multiple choice added
            driver.FindElement(By.XPath(".//*[@id='SQSTLCL_TITLE']")).SendKeysWithSpace("Select Options" + Meridian_Common.globalnum);
            driver.FindElement(By.XPath(".//*[@id='question-add-response-1']")).SendKeysWithSpace("Option A");
            driver.FindElement(By.XPath(".//*[@id='question-add-response-2']")).SendKeysWithSpace("Option B");
            driver.ClickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
            driver.FindElement(By.XPath(".//*[@id='question-add-response-3']")).SendKeysWithSpace("Option C");
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[1]/div/div/div/span[1]")));//default seletecd as required
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/label")));//Allow question to be reused?
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/div/div/span[3]")));// default selected no
            driver.ClickEleJs(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[4]/button[1]")));//verify cancel buton
            driver.ClickEleJs(By.XPath("//button[@id='btnCreateQuestion']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[2]/ul/li[2]/div/div[1]/small")));
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), (By.XPath("//a[contains(@href,'/SurveyConsole')]"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            driver.ClickEleJs(By.XPath(".//*[@id='surveyConsoleTabs']/li[2]/a"));//click question tab
            driver.GetElement(By.XPath("//input[@id='QuestionsSearchFor']")).SendKeysWithSpace("Select Options" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='btnSearchQuestions']"));//click search
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Select Options')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestions']/thead/tr/th[2]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestions']/thead/tr/th[3]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestions']/thead/tr/th[4]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestions']/thead/tr/th[5]/div[1]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestions']/tbody/tr[1]/td[2]/a")));
            //       driver.ClickEleJs(By.XPath(".//*[@id='info_3FCCD9FC9777455690DB697AD60A7EB4']/span"));// random no. coming manually clicked
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestionUsage']/tbody/tr/td")));
            driver.ClickEleJs(By.XPath("//span[contains(.,' Create Question')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Edit Question')]")));
            driver.FindElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/button"));//default multiple choice added
            driver.ClickEleJs(By.XPath("//button[@role='button']"));
            driver.ClickEleJs(By.XPath(".//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/div/ul/li[2]/a/span[2]"));
            driver.FindElement(By.XPath(".//*[@id='SQSTLCL_TITLE']")).SendKeysWithSpace("Enter Your Name" + Meridian_Common.globalnum);
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div/div/div/div/span[1]")));//Allow question to be reused?
            driver.ClickEleJs(By.XPath("//button[@id='btnCreateQuestion']"));
            driver.GetElement(By.XPath("//input[@id='QuestionsSearchFor']")).Clear();
            driver.GetElement(By.XPath("//input[@id='QuestionsSearchFor']")).SendKeysWithSpace("Enter Your Name" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='btnSearchQuestions']"));//click search
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestions']/tbody/tr/td[2]/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='tableSurveyQuestions']/tbody/tr/td[2]/a"));
            driver.FindElement(By.XPath(".//*[@id='SQSTLCL_TITLE']")).Clear();
            driver.FindElement(By.XPath(".//*[@id='SQSTLCL_TITLE']")).SendKeysWithSpace("Please Enter Your Name" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//button[@id='btnCreateQuestion']"));
            driver.GetElement(By.XPath("//input[@id='QuestionsSearchFor']")).Clear();
            driver.GetElement(By.XPath("//input[@id='QuestionsSearchFor']")).SendKeysWithSpace("Please Enter Your Name" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='btnSearchQuestions']"));//click search
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyQuestions']/tbody/tr/td[2]/a")));
            //  Assert.IsTrue(driver.existsElement(By.XPath(""))); for testing use
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }

        [Test, Order(40)]
        public void Publish_Survey_24666()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[3]/label")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_UC1_SRVY_SEARCHABLE']"));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_UC1_SRVY_INDEPENDENT_CONTENT']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            #endregion
            #region Create Survey Section
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[2]")));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Page1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Page1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[4]/div[2]/p/button")));
            driver.ClickEleJs(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/button"));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnPublishSurvey']"));
            //driver.SelectFrame(By.XPath("//button[@type='button'])[29]")); ok button not working done manually
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/p")));//verify published
            #endregion
            #region Search Published Survey
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), (By.XPath("//a[contains(@href,'/SurveyConsole')]"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            driver.FindElement(By.XPath("//input[@id='SurveySearchFor']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='btnSearchSurveys']"));
            driver.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='utility-nav']/ul[1]/li[4]/div/span/button"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[1]/h3/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[1]/h3/a"));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(41)]
        public void Preview_Survey_24665()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[3]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[4]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            #endregion
            #region Create Survey Section
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[2]")));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Page1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Page1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            #endregion
            #region add question
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button"));//click add question link
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Edit Question')]")));
            driver.FindElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/button"));//default multiple choice added
            driver.FindElement(By.XPath(".//*[@id='SQSTLCL_TITLE']")).SendKeysWithSpace("Select Options" + Meridian_Common.globalnum);
            driver.FindElement(By.XPath(".//*[@id='question-add-response-1']")).SendKeysWithSpace("Option A");
            driver.FindElement(By.XPath(".//*[@id='question-add-response-2']")).SendKeysWithSpace("Option B");
            driver.ClickEleJs(By.XPath("//a[@id='btnAddAnotherResponse']"));
            driver.FindElement(By.XPath(".//*[@id='question-add-response-3']")).SendKeysWithSpace("Option C");
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[1]/div/div/div/span[1]")));//default seletecd as required
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/label")));//Allow question to be reused?
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/div/div/span[3]")));// default selected no
            driver.ClickEleJs(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[4]/button[1]")));//verify cancel buton
            driver.ClickEleJs(By.XPath("//button[@id='btnCreateQuestion']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[2]/ul/li[2]/div/div[1]/small")));
            #endregion
            #region Preview Survey
            driver.ClickEleJs(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/button"));
            driver.ClickEleJs(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/ul/li[2]/a"));
            driver.selectWindow("Reg_Survey" + Meridian_Common.globalnum);
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='surveyContainer']/div/div[1]/h3/small")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='sq_100']/h5/span")));
            driver.GetElement(By.XPath(".//*[@id='sq_100i']")).Click();
            driver.FindElement(By.XPath(".//*[@id='sq_100i']/option[3]")).ClickWithSpace(); //select option b
            driver.GetElement(By.XPath(".//*[@id='surveyContainer']/div/div[1]/h3/small")).ClickWithSpace();//this drop down value got seleted but giving error based on choose selection default
            driver.ClickEleJs(By.XPath(".//*[@id='surveyContainer']/div/div[3]/input")); //click not working on complete button
            driver.selectWindow("Reg_Survey" + Meridian_Common.globalnum);

            // Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='surveyContainer']/div/div/div[2]/div/h3")));//not working
            driver.ClickEleJs(By.XPath(".//*[@id='surveyContainer']/div/div/p/a"));
            driver.selectWindow("Structure");
            //  Assert.IsTrue(driver.existsElement(By.XPath(""))); for testing use
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(42)]
        public void Delete_Survey_24667()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey/Question from Manage>Surveys
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), (By.XPath("//a[contains(@href,'/SurveyConsole')]"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            driver.ClickEleJs(By.XPath(".//*[@id='containerSurveys']/div[1]/div[3]/p/a/span[2]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Page1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Page1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), (By.XPath("//a[contains(@href,'/SurveyConsole')]"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            driver.ClickEleJs(By.XPath(".//*[@id='surveyConsoleTabs']/li[1]/a"));
            driver.FindElement(By.XPath("//input[@id='SurveySearchFor']")).SendKeysWithSpace(Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='btnSearchSurveys']"));
            driver.ClickEleJs(By.XPath(".//*[@id='btSelectItem_2AC05E0972B74C328A4B7284BF62B6FF']"));
            driver.ClickEleJs(By.XPath("//button[@id='btnDeleteSurvey']"));
            driver.GetElement(By.XPath("//button[@data-bb-handler='cancel']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//div[@class='bootbox-body']")));
            driver.ClickEleJs(By.XPath("html/body/div[8]/div[2]/div/div[2]/button[2]"));// ok button not working so this code of line need to update
            driver.FindElement(By.XPath("//input[@id='SurveySearchFor']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SurveySearchFor']")).SendKeysWithSpace(Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='btnSearchSurveys']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveys']/tbody/tr/td")));
            //  Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveys']/tbody/tr/td"))); for testing use
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }


        [Test, Order(43)]
        public void Add_Locale_in_Survey_30295()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[3]/label")));
            Assert.IsTrue(driver.existsElement(By.XPath("//*[@id='content']/div[2]/div/div[9]/div[2]/div/label")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            #endregion
            #region Add Locale
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_hlSurvey']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_ctl00_btnAddLocale']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_pnlContent']/div/div/h2")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_UC1_chkLocale']/tbody/tr[5]/td/label"));//select locate english UK
            driver.ClickEleJs(By.XPath("//label[contains(.,'German')]"));
            driver.ClickEleJs(By.XPath("//label[contains(.,'Japanese')]"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            driver.ClickEleJs(By.XPath("//select[@id='ddlLocalesAdded']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'Japanese (Japan)')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'English (United Kingdom)')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'German (Germany)')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_ctl00_btnDeleteLocale']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_pnlContent']/div/div/p[4]")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_deleteLocale']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//*[@id='content']/div[2]/div")));

            //  Assert.IsTrue(driver.existsElement(By.XPath("//*[@id='content']/div[2]/div"))); for testing use
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(44)]
        public void Link_Question_24662()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
             Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            #endregion
            #region Create Reusable Question
            driver.ClickEleJs(By.XPath("//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Edit Question')]")));
            driver.FindElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/button"));//default multiple choice added
            driver.FindElement(By.XPath(".//*[@id='SQSTLCL_TITLE']")).SendKeysWithSpace("Select Options" + Meridian_Common.globalnum);
            driver.FindElement(By.XPath(".//*[@id='question-add-response-1']")).SendKeysWithSpace("Option A");
            driver.FindElement(By.XPath(".//*[@id='question-add-response-2']")).SendKeysWithSpace("Option B");
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/div/div/span[3]")));// default selected no
            driver.ClickEleJs(By.XPath(".//*[@id='modal-question']/div[2]/div/div[3]/div/div/div/div[2]/div/div/div/span[3]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[4]/button[1]")));//verify cancel buton
            driver.ClickEleJs(By.XPath("//button[@id='btnCreateQuestion']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[2]/ul/li[2]/div/div[1]/small")));
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
           driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            #endregion
            #region add reusable question
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button"));//click add question link
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Edit Question')]")));
            driver.FindElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/button"));//default multiple choice added
            driver.ClickEleJs(By.XPath("//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/button"));
            driver.ClickEleJs(By.XPath("//*[@id='modal-question']/div[2]/div/div[2]/div[1]/div[1]/div/div/ul/li[5]/a"));
            driver.GetElement(By.XPath("//*[@id='question-add-existing']/div/div[1]/div[1]/div/input")).SendKeysWithSpace("Select Options" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//input[@data-index='0']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-question']/div[2]/div/div[4]/button[1]")));//verify cancel buton
            driver.ClickEleJs(By.XPath("//button[@id='btnCreateQuestion']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[2]/ul/li[2]/div/div[1]/small")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
       }
        [Test, Order(45)]
        public void Delete_Survey_Section_24664()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Page1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Page1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button")));
            #endregion
            #region Add and Delete New Section
            driver.ClickEleJs(By.XPath("//button[contains(.,'Add a New Page')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[2]/div/button[2]"));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[2]/div/ul/li/a/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//div[@class='bootbox-body']")));
            driver.mouseOverClick(By.XPath(".//*[@id='PageBody']/body/div[2]/div[2]/div/div[2]/button[2]"));//click on on confirm page// ok click not working 
            Assert.IsFalse(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")));

            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(46)]
        public void Reorder_Survey_24663()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new Survey
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), (By.XPath("//a[@href='/Admin/CreateSurvey.aspx']"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/h1"))); // verify create Survey page
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("Reg_Survey" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_btnCancel']")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            #endregion
            #region Add and Reorder Multiple Sections
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_hlSurveyStructure']")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a"));
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).Clear();
            driver.FindElement(By.XPath("//input[@style='padding-right: 24px;']")).SendKeysWithSpace("Test_Section1");
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Section1')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/small/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-section-desc']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath(".//*[@id='SSEC_SECTION_DESCRIPTION']")).SendKeysWithSpace("Test_Desc");
            driver.ClickEleJs(By.XPath(".//*[@id='btnUpdateSection']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Desc')]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/p/button")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[2]/div[2]/p/button")));
            driver.ClickEleJs(By.XPath("//button[contains(.,'Add a New Page')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Page 2')]"));
            driver.FindElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[1]/input")).Clear();
            driver.FindElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[1]/input")).SendKeysWithSpace("Test_Section2");
            driver.ClickEleJs(By.XPath("//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/span/div/form/div/div[1]/div[2]/div/button[1]/span"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Test_Section2')]")));
            string tx1 = driver.FindElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")).Text;
            string tx2 = driver.FindElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")).Text;
            driver.ClickEleJs(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[2]/div/button[1]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h4[contains(.,'Reorder Pages')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='modal-section-reorder']/div[2]/div/div[2]/ul/li[1]/div/div[3]/button"));
            driver.ClickEleJs(By.XPath(".//*[@id='modal-section-reorder']/div[2]/div/div[3]/button"));//click close button
          string tx3=  driver.FindElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[1]/div[1]/div/div[1]/h3/a")).Text;
            string tx4= driver.FindElement(By.XPath(".//*[@id='ViewManageSurvey']/div[1]/div[3]/div[1]/div/div[1]/h3/a")).Text;
            Assert.AreEqual(tx1, tx4);
            Assert.AreEqual(tx2, tx3);
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test, Order(47)]
        public void Survey_Answers_creation_edit_and_removal_30224()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Create Answer
            driver.ClickEleJs(By.XPath(".//*[@id='containerScales']/div[1]/div[3]/p/a/span[2]"));
            driver.GetElement(By.XPath("//input[contains(@id,'NAME')]")).SendKeysWithSpace("Name " + Meridian_Common.globalnum);
            driver.FindElement(By.XPath("//*[@id='question-add-response-1']")).SendKeysWithSpace("Answer1");
            driver.FindElement(By.XPath("//*[@id='question-add-response-2']")).SendKeysWithSpace("Answer2");
            driver.ClickEleJs(By.XPath("//a[@id='btnAddAnotherAnswer']"));
            driver.FindElement(By.XPath("//*[@id='question-add-response-3']")).SendKeysWithSpace("Answer3");
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-survey-scale']/div[2]/div/div[3]/button[1]")));
            driver.ClickEleJs(By.XPath(".//*[@id='btnCreateScale']"));
            driver.FindElement(By.XPath("//input[@id='ScalesSearchFor']")).SendKeysWithSpace("Name " + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//button[@id='btnSearchScales']"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr/td[2]/a")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr/td[2]/small")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr/td[3]")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr/td[3]/small")));
            //  Assert.IsTrue(driver.existsElement(By.XPath(""))); for testing use
            #endregion
            #region create new Answers from Manage>Surveys
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), (By.XPath("//a[contains(@href,'/SurveyConsole')]"))); // mouse hover on create link on top                                                                                                       //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div/div/h1")));//verify user lands on survey page
            driver.ClickEleJs(By.XPath(".//*[@id='surveyConsoleTabs']/li[3]/a"));//click answer tab
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyScales']/thead/tr/th[3]/a")));//verify in use column
            string str = string.Empty; 
          str = driver.FindElement(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr[1]/td[3]/parent::*/td[1]/input")).GetAttribute("disabled");
            Assert.AreEqual("true", str);
            //Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr[2]/td[3]")));//verify yes and click on selection box it should be disabled
            // Script need to update to Check Yes Values in table
            driver.ClickEleJs(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr[1]/td[3]/parent::*/td[2]/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-survey-scale']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath("//input[@id='SSCL_SURVEY_SCALE_NAME']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SSCL_SURVEY_SCALE_NAME']")).SendKeysWithSpace("Answer" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath(".//*[@id='btnEditScale']"));
             str = driver.FindElement(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr[2]/td[3]/parent::*/td[1]/input")).GetAttribute("disabled");
            Assert.AreEqual(null, str);
            driver.ClickEleJs(By.XPath(".//*[@id='tableSurveyScales']/tbody/tr[2]/td[3]/parent::*/td[2]/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='modal-survey-scale']/div[2]/div/div[1]/h4")));
            driver.FindElement(By.XPath("//input[@id='SSCL_SURVEY_SCALE_NAME']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SSCL_SURVEY_SCALE_NAME']")).SendKeysWithSpace("Answer" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//a[@id='btnAddAnotherAnswer']"));
            driver.FindElement(By.XPath("//*[@id='question-add-response-1']")).SendKeysWithSpace("Answer1");
            driver.ClickEleJs(By.XPath(".//*[@id='btnEditScale']"));
            #endregion
               #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }

        // Working on document related scenarios i.e. 7338, 7339 and 7342

        [Test, Order(48)]
        public void Genral_Course_Prerequisites()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new document with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top                                                                                                       //driver.GetElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
                                                                                                                                   //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.google.com"); // enter url www.google.com
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region create general course with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[contains(.,'General Course')]"));// mouse hover on create link on top
                                                                                                                             //driver.FindElement(By.XPath("//a[contains(.,'General Course')]"));//click on General course
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Create New General Course')]")));//verify course page
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Title')]")));//verify label title
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum); //enter title as dv_gc20/04
            driver.GetElement(By.XPath("//*[@id='MainContent_UC1_EXTERNALFILE_URL']")).ClickWithSpace();//click on url radio button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_ltEnterUrl']")));//verify label
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.yahoo.com");//enter url as www.yahoo.com
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_Save']")).ClickWithSpace();//click on create button
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// verify successful saved message
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region set document as a prerequiste for general course
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//mosue hover on manage
                                                                                                                                        //driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Manage Content')]")));//manage and search content section
             driver.FindElement(By.XPath(".//*[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);//enter text as dv_gc20/04
            driver.FindElement(By.XPath(".//*[@id='btnSearch']/span")).ClickWithSpace();//click on search button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div")));//search result page
            StringAssert.AreEqualIgnoringCase("dv_gc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 
            driver.FindElement(By.XPath("//a[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();//search result document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]"))); //verify general course detail page
            Thread.Sleep(2000);
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checuout button to make it checkin
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Check-in')]")));//verify it become as checkin
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/p")));//verify status of content
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/div/div[1]/h3")));//check prerequiestes
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/p")));//verify current pre req status 
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));//click on edit to add prerequisite
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[1]/h2")));//verify prerequisite page
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_LnkAdd']")).ClickWithSpace();//click on add button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/h2")));//verify add prereq. page open
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_lblSearchFor']")));// label
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);//enter text - dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[2]/label")));//label
            driver.FindSelectElement(By.XPath("//option[contains(.,'Exact phrase')]"), "Exact phrase");//select exact phrase 
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Content Type')]")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DOCUMENT']"), "Document");//select docuemnt
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnSearch']")).ClickWithSpace();//click search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect']")).ClickWithSpace();//click on checkbox
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_Add']")).ClickWithSpace();//click on add button
            StringAssert.AreEqualIgnoringCase("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message
            driver.FindElement(By.XPath("//a[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();//click on content link from breadcrumb to see detail page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div[1]/div/div[1]/h3")));//vweify go to prerequieste accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'1 Assigned Prerequisites')]")));// now showing 1 assiged prerequieste info
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region Logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[contains(.,'Logout')]"));//mouse hover on user logout menu
            #endregion
            #region create new learner                                          
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
            #region learner access general course and see pre-requiste item associated with this
           // driver.FindElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);// global search text box, enter text dv_gc20/04
          //  driver.mouseOverClick(By.XPath("//li[contains(@class,'search-bar')]"));//click on search icon on this navigation
              driver.FindElement(By.XPath("//*[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//*[@id='utility-nav']/ul[1]/li[5]/div/span[2]/button"));

      //      Assert.IsTrue(driver.existsElement(By.XPath("//strong[@data-bind='formatText: [total]']"))); //searched data on left navigation page

            //Assert.IsTrue( driver.existsElement(By.XPath("//strong[contains(.,'Catalog ')]")));//searched data on left navigation page
          //  Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' results for dv_gc" + Meridian_Common.globalnum + " in Catalog')]"))); //display info on searched data on left side menu
            StringAssert.AreEqualIgnoringCase("dv_gc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 

            driver.FindElement(By.XPath("//a[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();// select record and click on it to open this content
 //           Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));//verify page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[2]/div[1]/div/p")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[2]/div[2]/div[3]/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[2]/div[1]/div/p")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Admin search content and remove prerequisites
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//mosue hover on manage
                                                                                                                                        //driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Manage Content')]")));//manage and search content section
            driver.FindElement(By.XPath(".//*[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);//enter text as dv_gc20/04
            driver.FindElement(By.XPath(".//*[@id='btnSearch']/span")).ClickWithSpace();//click on search button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div")));//search result page
            StringAssert.AreEqualIgnoringCase("dv_gc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 
            driver.FindElement(By.XPath("//a[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();//search result document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]"))); //verify general course detail page
            Thread.Sleep(2000);
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checuout button to make it checkin
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Check-in')]")));//verify it become as checkin
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/p")));//verify status of content
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/div/div[1]/h3")));//check prerequiestes
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/p")));//verify current pre req status 
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));//click on edit to add prerequisite
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[1]/h2")));//verify prerequisite page
            driver.ClickEleJs(By.XPath("//input[contains(@id,'chkSelect')]"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']"));
            driver.findandacceptalert();
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No prerequisites are currently assigned.')]")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li[2]/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div[1]/div/div[1]/h3")));//vweify go to prerequieste accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No prerequisites are currently assigned.')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
             #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region learner access general course and don't see pre-requiste item associated with this
            // driver.FindElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);// global search text box, enter text dv_gc20/04
            //  driver.mouseOverClick(By.XPath("//li[contains(@class,'search-bar')]"));//click on search icon on this navigation
            driver.FindElement(By.XPath("//*[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//*[@id='utility-nav']/ul[1]/li[5]/div/span[2]/button"));

            //      Assert.IsTrue(driver.existsElement(By.XPath("//strong[@data-bind='formatText: [total]']"))); //searched data on left navigation page

            //Assert.IsTrue( driver.existsElement(By.XPath("//strong[contains(.,'Catalog ')]")));//searched data on left navigation page
            //  Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' results for dv_gc" + Meridian_Common.globalnum + " in Catalog')]"))); //display info on searched data on left side menu
            StringAssert.AreEqualIgnoringCase("dv_gc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 

            driver.FindElement(By.XPath("//a[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();// select record and click on it to open this content
                                                                                                                       //           Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));//verify page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton']")));
               #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

         }
        [Test, Order(49)]
        public void Genral_Course_Equivalencies()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new document with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top                                                                                                       //driver.GetElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
                                                                                                                                   //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.google.com"); // enter url www.google.com
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region create general course with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[contains(.,'General Course')]"));// mouse hover on create link on top
                                                                                                                             //driver.FindElement(By.XPath("//a[contains(.,'General Course')]"));//click on General course
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Create New General Course')]")));//verify course page
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Title')]")));//verify label title
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum); //enter title as dv_gc20/04
            driver.GetElement(By.XPath("//*[@id='MainContent_UC1_EXTERNALFILE_URL']")).ClickWithSpace();//click on url radio button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_ltEnterUrl']")));//verify label
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.yahoo.com");//enter url as www.yahoo.com
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_Save']")).ClickWithSpace();//click on create button
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// verify successful saved message
             #endregion
            #region set document as a Equilences for general course
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]"))); //verify general course detail page
            Thread.Sleep(2000);
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/div/div[1]/h3")));//verify equilencies accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No equivalencies are currently assigned.')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_lnkEdit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Equivalencies')]")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']"));
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);//enter text - dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[2]/label")));//label
            driver.FindSelectElement(By.XPath("//option[contains(.,'Exact phrase')]"), "Exact phrase");//select exact phrase 
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DOCUMENT']"), "Document");//select docuemnt
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnSearch']")).ClickWithSpace();//click search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect']")).ClickWithSpace();//click on checkbox
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_Add']")).ClickWithSpace();//click on add button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnCancel']"));//click back button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div[1]/p"))); // 1 item added as equilencies
            driver.ClickEleJs(By.XPath("//a[contains(@id,'MainContent_MainContent_ucEquivalencies_lnkEdit')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[1]/h2")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.ClickEleJs(By.XPath("//input[contains(@id,'chkSelect')]"));
            driver.ClickEleJs(By.XPath("//a[contains(@id,'btnRemove')]"));
            driver.findandacceptalert();
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            driver.ClickEleJs(By.XPath("//*[@id='MainContent_MainContent_UC1_btnCancel']"));//click back button  
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/div/div[1]/h3")));//verify equilencies accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No equivalencies are currently assigned.')]")));
            driver.ClickEleJs(By.XPath("//a[contains(@id,'MainContent_MainContent_ucEquivalencies_lnkEdit')]"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']"));
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);//enter text - dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[2]/label")));//label
            driver.FindSelectElement(By.XPath("//option[contains(.,'Exact phrase')]"), "Exact phrase");//select exact phrase 
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DOCUMENT']"), "Document");//select docuemnt
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnSearch']")).ClickWithSpace();//click search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect']")).ClickWithSpace();//click on checkbox
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_Add']")).ClickWithSpace();//click on add button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            driver.ClickEleJs(By.XPath("//*[@id='MainContent_MainContent_UC1_btnCancel']"));//click back button  
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div[1]/p"))); // 1 item added as equilencies
            driver.ClickEleJs(By.XPath("//*[@id='MainContent_header_FormView1_btnStatus']"));//click checkin button  
            Assert.IsTrue(driver.existsElement(By.XPath("//*[@id='contentDetailsHeader']/div[2]/p")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div[1]/p"))); // 1 item added as equilencies
              #endregion
            #region Logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[contains(.,'Logout')]"));//mouse hover on user logout menu
            #endregion
         
        }
        [Test, Order(50)]
        public void Document_Prerequisites_7338()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            
            #region create general course with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[contains(.,'General Course')]"));// mouse hover on create link on top
                                                                                                                             //driver.FindElement(By.XPath("//a[contains(.,'General Course')]"));//click on General course
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Create New General Course')]")));//verify course page
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Title')]")));//verify label title
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum); //enter title as dv_gc20/04
            driver.GetElement(By.XPath("//*[@id='MainContent_UC1_EXTERNALFILE_URL']")).ClickWithSpace();//click on url radio button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_ltEnterUrl']")));//verify label
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.yahoo.com");//enter url as www.yahoo.com
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_Save']")).ClickWithSpace();//click on create button
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// verify successful saved message
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region create new document with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top                                                                                                       //driver.GetElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
                                                                                                                                   //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.google.com"); // enter url www.google.com
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region set Gen Course as a prerequiste for Document
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//mosue hover on manage
            driver.FindElement(By.XPath(".//*[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);//enter text as dv_gc20/04
            driver.FindElement(By.XPath(".//*[@id='btnSearch']/span")).ClickWithSpace();//click on search button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div")));//search result page
            StringAssert.AreEqualIgnoringCase("dv_doc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 
            driver.FindElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();//search result document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]"))); //verify doc detail page
            Thread.Sleep(2000);
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checuout button to make it checkin
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Check-in')]")));//verify it become as checkin
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/p")));//verify status of content
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/div/div[1]/h3")));//check prerequiestes
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/p")));//verify current pre req status 
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));//click on edit to add prerequisite
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[1]/h2")));//verify prerequisite page
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_LnkAdd']")).ClickWithSpace();//click on add button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/h2")));//verify add prereq. page open
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_lblSearchFor']")));// label
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);//enter text - dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[2]/label")));//label
            driver.FindSelectElement(By.XPath("//option[contains(.,'Exact phrase')]"), "Exact phrase");//select exact phrase 
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Content Type')]")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.COURSEWARE.ONLINE']"), "Online");//select online
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnSearch']")).ClickWithSpace();//click search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect']")).ClickWithSpace();//click on checkbox
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_Add']")).ClickWithSpace();//click on add button
            StringAssert.AreEqualIgnoringCase("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message
            driver.FindElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();//click on content link from breadcrumb to see detail page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div[1]/div/div[1]/h3")));//vweify go to prerequieste accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'1 Assigned Prerequisites')]")));// now showing 1 assiged prerequieste info
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region Logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[contains(.,'Logout')]"));//mouse hover on user logout menu
            #endregion
            #region create new learner                                          
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
            #region learner access general course and see pre-requiste item associated with this
            // driver.FindElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);// global search text box, enter text dv_gc20/04
            //  driver.mouseOverClick(By.XPath("//li[contains(@class,'search-bar')]"));//click on search icon on this navigation
            driver.FindElement(By.XPath("//*[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//*[@id='utility-nav']/ul[1]/li[5]/div/span[2]/button"));

            //      Assert.IsTrue(driver.existsElement(By.XPath("//strong[@data-bind='formatText: [total]']"))); //searched data on left navigation page

            //Assert.IsTrue( driver.existsElement(By.XPath("//strong[contains(.,'Catalog ')]")));//searched data on left navigation page
            //  Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' results for dv_gc" + Meridian_Common.globalnum + " in Catalog')]"))); //display info on searched data on left side menu
            StringAssert.AreEqualIgnoringCase("dv_doc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 

            driver.FindElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();// select record and click on it to open this content
                                                                                                                       //           Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));//verify page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[2]/div[1]/div/p")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[2]/div[2]/div[3]/div[1]/h3")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div/div[2]/div[1]/div/p")));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Admin search content and remove prerequisites
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//mosue hover on manage
                                                                                                                                        //driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Manage Content')]")));//manage and search content section
            driver.FindElement(By.XPath(".//*[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);//enter text as dv_gc20/04
            driver.FindElement(By.XPath(".//*[@id='btnSearch']/span")).ClickWithSpace();//click on search button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div")));//search result page
            StringAssert.AreEqualIgnoringCase("dv_doc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 
            driver.FindElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();//search result document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]"))); //verify general course detail page
            Thread.Sleep(2000);
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checuout button to make it checkin
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Check-in')]")));//verify it become as checkin
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/p")));//verify status of content
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/div/div[1]/h3")));//check prerequiestes
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/p")));//verify current pre req status 
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));//click on edit to add prerequisite
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[1]/h2")));//verify prerequisite page
            driver.ClickEleJs(By.XPath("//input[contains(@id,'chkSelect')]"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']"));
            driver.findandacceptalert();
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No prerequisites are currently assigned.')]")));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            driver.ClickEleJs(By.XPath(".//*[@id='content']/div[1]/ol/li[2]/a"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div[1]/div/div[1]/h3")));//vweify go to prerequieste accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No prerequisites are currently assigned.')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnStatus']"));//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.GetElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.GetElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//using regadmin account
            driver.GetElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region learner access general course and don't see pre-requiste item associated with this
            // driver.FindElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);// global search text box, enter text dv_gc20/04
            //  driver.mouseOverClick(By.XPath("//li[contains(@class,'search-bar')]"));//click on search icon on this navigation
            driver.FindElement(By.XPath("//*[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum);
            driver.ClickEleJs(By.XPath("//*[@id='utility-nav']/ul[1]/li[5]/div/span[2]/button"));

            //      Assert.IsTrue(driver.existsElement(By.XPath("//strong[@data-bind='formatText: [total]']"))); //searched data on left navigation page

            //Assert.IsTrue( driver.existsElement(By.XPath("//strong[contains(.,'Catalog ')]")));//searched data on left navigation page
            //  Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' results for dv_gc" + Meridian_Common.globalnum + " in Catalog')]"))); //display info on searched data on left side menu
            StringAssert.AreEqualIgnoringCase("dv_doc" + Meridian_Common.globalnum + "", driver.FindElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h1/em")).Text);//verify search result message as You searched for 'dv_gc20/04' 

            driver.FindElement(By.XPath("//a[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]")).ClickWithSpace();// select record and click on it to open this content
                                                                                                                       //           Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));//verify page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']")));
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

        }
        [Test, Order(51)]
        public void Document_Equivalencies_7339()
        {
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("regadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create general course with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[contains(.,'General Course')]"));// mouse hover on create link on top
                                                                                                                             //driver.FindElement(By.XPath("//a[contains(.,'General Course')]"));//click on General course
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Create New General Course')]")));//verify course page
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Title')]")));//verify label title
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum); //enter title as dv_gc20/04
            driver.GetElement(By.XPath("//*[@id='MainContent_UC1_EXTERNALFILE_URL']")).ClickWithSpace();//click on url radio button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_UC1_ltEnterUrl']")));//verify label
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.yahoo.com");//enter url as www.yahoo.com
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_Save']")).ClickWithSpace();//click on create button
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// verify successful saved message
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region create new document with URL
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top                                                                                                       //driver.GetElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
                                                                                                                                   //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.google.com"); // enter url www.google.com
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
             #endregion
            #region set gen couse as a Equilences for doc
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'dv_doc" + Meridian_Common.globalnum + "')]"))); //verify general course detail page
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/div/div[1]/h3")));//verify equilencies accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No equivalencies are currently assigned.')]")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_lnkEdit']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Equivalencies')]")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']"));
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);//enter text - dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[2]/label")));//label
            driver.FindSelectElement(By.XPath("//option[contains(.,'Exact phrase')]"), "Exact phrase");//select exact phrase 
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.COURSEWARE.ONLINE']"), "Online");//select online
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnSearch']")).ClickWithSpace();//click search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect']")).ClickWithSpace();//click on checkbox
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_Add']")).ClickWithSpace();//click on add button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            driver.ClickEleJs(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnCancel']"));//click back button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div[1]/p"))); // 1 item added as equilencies
            driver.ClickEleJs(By.XPath("//a[contains(@id,'MainContent_MainContent_ucEquivalencies_lnkEdit')]"));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[1]/h2")));
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.ClickEleJs(By.XPath("//input[contains(@id,'chkSelect')]"));
            driver.ClickEleJs(By.XPath("//a[contains(@id,'btnRemove')]"));
            driver.findandacceptalert();
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            driver.ClickEleJs(By.XPath("//*[@id='MainContent_MainContent_UC1_btnCancel']"));//click back button  
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/div/div[1]/h3")));//verify equilencies accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'No equivalencies are currently assigned.')]")));
            driver.ClickEleJs(By.XPath("//a[contains(@id,'MainContent_MainContent_ucEquivalencies_lnkEdit')]"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']"));
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("dv_gc" + Meridian_Common.globalnum);//enter text - dv_doc20-04
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_pnlSearch']/div[1]/div[2]/label")));//label
            driver.FindSelectElement(By.XPath("//option[contains(.,'Exact phrase')]"), "Exact phrase");//select exact phrase 
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.COURSEWARE.ONLINE']"), "Online");//select online
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_btnSearch']")).ClickWithSpace();//click search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_gc" + Meridian_Common.globalnum + "')]")));// verify document that we searched
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect']")).ClickWithSpace();//click on checkbox
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_Add']")).ClickWithSpace();//click on add button
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='content']/div[2]/div")));
            driver.ClickEleJs(By.XPath("//*[@id='MainContent_MainContent_UC1_btnCancel']"));//click back button  
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div[1]/p"))); // 1 item added as equilencies
            driver.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            Assert.IsTrue(driver.existsElement(By.XPath("//*[@id='contentDetailsHeader']/div[2]/p")));
            Assert.IsTrue(driver.existsElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div[1]/p"))); // 1 item added as equilencies
            #endregion
            #region Logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[contains(.,'Logout')]"));//mouse hover on user logout menu
            #endregion

        }
    }
}