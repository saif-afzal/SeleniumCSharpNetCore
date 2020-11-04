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


namespace TestAutomation.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ApprovalPaths : TestBase
    {
        string browserstr = string.Empty;
        public ApprovalPaths(string browser)
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
        //[Test, Order(1)] not automable
        public void As_an_adminstrator_share_approval_paths_to_other_domains_19252()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")); //Clicked on Log In
            #endregion
            #region navigate to  approval path page
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Access Approval Paths')]"));
            driver.FindElement(By.XPath("//span[contains(.,'Approval Paths')]")); // Verify the page contains Approval Path heading
            #endregion
            #region Create new Approval Path 
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_TITLE']")); //Entered Title - Dollys Linear Approval Path_04192017
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_DESCRIPTION']"));  //Entered Description - Dollys Linear Approval Path_04192017
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_PATH_TYPE_ID']")); //Selected Type - Linear
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']")); //Clicked on Create
            driver.FindElement(By.XPath("//span[contains(.,'The approval path was created. You may now add users as approvers.')]")); // Verified Confirmation message received
            #endregion
            #region Navigate to Approver Stages tab
            driver.FindElement(By.XPath("//span[contains(.,'Approvers/Stages')]"));
            #endregion
            #region Select Approvers from the list and add them
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl06_DataGridItem_Id']")); //Selected Approvers (Administrator and User Manager) from the list
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ML.BASE.BTN.AddSelected']")); // Selected Add
            driver.FindElement(By.XPath("//span[contains(.,'The selected approver(s) was added to the path.')]")); //Verified confirmation message is received
            #endregion
            #region Navigate to Sharing tab
            driver.FindElement(By.XPath("//span[contains(.,'Sharing')]"));
            #endregion
            #region Select the Domains to share
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_DomainContentSharing_CONTENT_SHARED']")); // Click on Radio button - Object is shared with Child Domain
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_DomainContentSharing_ContentShared_3_ContentSharing_1_2_A9DE4C094A4046ACA6FEAFA7AB5BA862_P_']")); //Since there was no child domain, I picked this ID from baseqa-m-c1
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")); // Click on Save
            driver.FindElement(By.XPath("//span[contains(.,'The content sharing selections were saved.')]")); // Verified the confirmation message is received
            #endregion
            Assert.Fail();

        }
      //  [Test, Order(2)]not automable
        public void Add_domain_sharing_tab_to_approval_paths_information_window_19258()
        {
          
            Assert.Fail();
        }
      //  [Test, Order(3)] not automable
        public void As_an_adminstrator_see_approval_paths_in_the_shared_content_or_object_area_of_admin_console_19259()
        {
          

            Assert.Fail();
        }
        [Test, Order(4)]
        public void Create_Approval_Path_25155()
        { 
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin"); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password"); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace(); //Clicked on Log In
            #endregion
            #region navigate to  approval path page
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
          //  driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
           // driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Access Approval Paths')]")).ClickWithSpace();
            driver.selectWindow("");
            Assert.AreEqual("Approval Paths", driver.Title);
          Assert.AreEqual("Approval Paths",driver.FindElement(By.XPath("//span[contains(.,'Approval Paths')]")).Text); // Verify the page contains Approval Path heading
            #endregion
            #region Create new Approval Path for Linear Type
          Assert.IsTrue(driver.existsElement(By.XPath("//option[contains(.,'Create New')]"))); // Verify the page contains Create New Option
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")).ClickWithSpace();
           Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Access Approval Path']"))); // Verify the Edit Access Approval Path page is displayed
          Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Approvers/Stages')]"))); //Verify the Approver/Stages tab is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Sharing')]"))); //Verify Sharing tab is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_TITLE']")).SendKeysWithSpace("Dollys Linear Approval Path_04192017"); //Entered Title - Dollys Linear Approval Path_04192017
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_DESCRIPTION']")).SendKeysWithSpace("Dollys Linear Approval Path_04192017");  //Entered Description - Dollys Linear Approval Path_04192017
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_PATH_TYPE_ID']"));
            driver.FindElement(By.XPath("//option[@value='ML.BASE.APPROVALTYPE.Linear']")); //Selected Type - Linear
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']")).ClickWithSpace(); //Clicked on Create
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The approval path was created. You may now add users as approvers.')]"))); // Verified Confirmation message received
            driver.FindElement(By.Id("Return")).ClickWithSpace();
            #endregion
            #region Create new Approval Path for Non Linear Type
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")).ClickWithSpace();
            //driver.FindElement(By.XPath("//span[@title='Edit Access Approval Path']")).ClickWithSpace(); // Verify the Edit Access Approval Path page is displayed
            //driver.FindElement(By.XPath("//span[contains(.,'Approvers/Stages')]")); //Verify the Approver/Stages tab is displayed
            //driver.FindElement(By.XPath("//span[contains(.,'Sharing')]")); //Verify Sharing tab is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_TITLE']")).SendKeysWithSpace("Dollys Non-Linear Approval Path_04202017"); //Entered Title - Dollys Non-Linear Approval Path_04202017
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_DESCRIPTION']")).SendKeysWithSpace("Dollys Non-Linear Approval Path_04202017");  //Entered Description - Dollys Non-Linear Approval Path_04202017
            driver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_PATH_TYPE_ID']"),"Non-Linear"); 
           // driver.FindElement(By.XPath("//option[@value='ML.BASE.APPROVALTYPE.NonLinear']")); //Selected Type - NonLinear
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']")).ClickWithSpace(); //Clicked on Create
           Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The approval path was created. You may now add users as approvers.')]"))); // Verified Confirmation message received
            #endregion
           driver.FindElement(By.Id("Return")).ClickWithSpace();
           driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")).ClickWithSpace();
            #region Cancel
            driver.FindElement(By.XPath("//input[@id='Cancel']")).ClickWithSpace(); //Clicked on Cancel
            #endregion
           Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")));
           driver.Navigate_to_TrainingHome();
           driver.LogoutUser(ObjectRepository.HoverMainLink, ObjectRepository.LogoutHoverLink);
            //Assert.Fail();
        }
        [Test, Order(5)]
        public void Manage_Approval_Path_25157()    
        {
          
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin"); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password"); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace(); //Clicked on Log In
            #endregion
            #region navigate to  approval path page
            string ParentWIndow = driver.CurrentWindowHandle;//getting the parent window id
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            //driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            //driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Access Approval Paths')]")).ClickWithSpace();
            driver.selectWindow("");
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Approval Paths')]"))); // Verify the page contains Approval Path heading
            #endregion
            #region Information Icon for Approval Paths
            driver.ClickEleJs(By.XPath("//img[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_ML.BASE.DG.Info']")); //Clicked on the Information Icon for Approval path
            driver.selectWindow("Approval Paths");
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Summary')]"))); //Verified the Information page contains Summary tab
           Assert.IsTrue( driver.existsElement(By.XPath("//nobr[contains(.,'Stages')]")));  // Verified the Information page contains Stages tab
           Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Domain Sharing')]"))); // Verified the Information page contains Domain Sharing tab
           driver.SelectWindowClose();
           driver.SwitchTo().Window(ParentWIndow);
            driver.selectWindow("Approval Paths");
            #endregion
            #region Manage Approval Path
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_ActionsMenu']")).ClickWithSpace(); //Manage Dollys Linear Approval path_04192017//change this to xpath to avoid id changes
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_GoButton']")).ClickWithSpace(); //Selected Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Access Approval Path']"))); //Verified Edit Access Approval Path page is displayed
           Assert.IsTrue( driver.existsElement(By.XPath("//span[@id='ML.BASE.WF.ConfigureAccessApproval']"))); //Verified Access Approval Path tab is displayed
           Assert.IsTrue( driver.existsElement(By.XPath("//span[contains(.,'Approvers/Stages')]"))); // Verified the Approvers/Stage tab is displayed
            #endregion
            #region Edit Approval Path
            driver.FindElement(By.XPath("//span[@id='ML.BASE.WF.ConfigureAccessApproval']")).ClickWithSpace(); //Access Approval tab is selected
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_TITLE']")).SendKeysWithSpace("test"); //Edit Title 
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")).ClickWithSpace(); // Clicked on Save button
           Assert.IsTrue( driver.existsElement(By.XPath("//span[contains(.,'The summary information changes were saved.')]"))); // Success message is displayed
        Assert.IsTrue( driver.existsElement(By.XPath("//span[contains(.,'test')]")));
            #endregion
            //Assert.Fail();
        }
        [Test, Order(6)]
        public void Add_Approver_25159()
        {
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin"); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password"); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace(); //Clicked on Log In
            #endregion
            #region navigate to  approval path page
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
          
            driver.FindElement(By.XPath("//a[contains(.,'Access Approval Paths')]")).ClickWithSpace();
            driver.selectWindow("");
           Assert.IsTrue( driver.existsElement(By.XPath("//span[contains(.,'Approval Paths')]"))); // Verify the page contains Approval Path heading
            #endregion
            #region Manage Approval Path
            driver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_ActionsMenu']"),"Manage"); //Manage Dollys Linear Approval path_04192017
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_GoButton']")).ClickWithSpace(); //Selected Go button
           Assert.IsTrue( driver.existsElement(By.XPath("//span[@title='Edit Access Approval Path']"))); //Verified Edit Access Approval Path page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ML.BASE.WF.ConfigureAccessApproval']"))); //Verified Access Approval Path tab is displayed
         Assert.IsTrue(   driver.existsElement(By.XPath("//span[contains(.,'Approvers/Stages')]"))); // Verified the Approvers/Stage tab is displayed
            #endregion
            #region Navigate to Approver Stages tab
            driver.FindElement(By.XPath("//span[contains(.,'Approvers/Stages')]")).ClickWithSpace(); //Approvers/Stages tab is selected
            #endregion
            #region Add Approvers
          Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Approvers/Stages']"))); //Verified the Title Edit Approvers/Stages is displayed
           Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Available Approvers')]"))); //Verified the list of Available Approvers are displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl07_DataGridItem_Id']")).ClickWithSpace(); //Selected the checkbox from the list of Approvers hr administrators
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ML.BASE.BTN.AddSelected']")).ClickWithSpace(); //Clicked on Add Selected
          Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The selected approver(s) was added to the path.')]"))); //Verified the Success message is displayed
            #endregion
          driver.Navigate_to_TrainingHome();
          driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
           // Assert.Fail();
        }
        [Test, Order(7)]
        public void Add_User_25160()
        {
            Assert.Fail();
        }
        [Test, Order(8)]
        public void Reorder_Approvers_25161()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin"); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password"); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace(); //Clicked on Log In
            #endregion
            #region navigate to  approval path page
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));

            driver.FindElement(By.XPath("//a[contains(.,'Access Approval Paths')]")).ClickWithSpace();
            driver.selectWindow("");
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Approval Paths')]"))); // Verify the page contains Approval Path heading
            #endregion
            #region Manage Approval Path
            driver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_ActionsMenu']"), "Manage"); //Manage Dollys Linear Approval path_04192017
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_GoButton']")).ClickWithSpace(); //Selected Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Access Approval Path']"))); //Verified Edit Access Approval Path page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ML.BASE.WF.ConfigureAccessApproval']"))); //Verified Access Approval Path tab is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Approvers/Stages')]"))); // Verified the Approvers/Stage tab is displayed
            #endregion
            #region Navigate to Approver Stages tab
            driver.FindElement(By.XPath("//span[contains(.,'Approvers/Stages')]")).ClickWithSpace(); //Approvers/Stages tab is selected
            #endregion
            #region Add Approvers
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Approvers/Stages']"))); //Verified the Title Edit Approvers/Stages is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Available Approvers')]"))); //Verified the list of Available Approvers are displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl07_DataGridItem_Id']")).ClickWithSpace(); //Selected the checkbox from the list of Approvers hr administrators
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ML.BASE.BTN.AddSelected']")).ClickWithSpace(); //Clicked on Add Selected
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The selected approver(s) was added to the path.')]"))); //Verified the Success message is displayed
            #endregion
            #region Reorder Approvers
           Assert.IsTrue( driver.existsElement(By.XPath("//span[contains(.,'Current Approvers')]"))); //Verified the Section contains Current Approvers
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ExistingApproversList_ctl02_ReOrderMenu']")); //Changed the Order of the Existing Approver list
            driver.select(By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_ExistingApproversList_ctl02_ReOrderMenu"), "2"); //Changed the Value 1 to 2 change the xpath
            driver.select(By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_ExistingApproversList_ctl03_ReOrderMenu"), "1"); //Changed the Value 2 to 1
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ML.BASE.BTN.Reorder']")).ClickWithSpace(); //Clicked on Reorder
          Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The order of the approvers for this path was updated.')]"))); // Veified the Success message is displayed
         //add more assert to check that the reorder had happened.
            #endregion
          string ParentWIndow = driver.CurrentWindowHandle;
            #region Information Icon for Existing Approvers
            driver.FindElement(By.XPath("//img[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ExistingApproversList_ctl02_ML.BASE.DG.Info']")).ClickWithSpace(); //Clicked on the Information Icon for Existing Approvers
            driver.selectWindow("");
            Assert.IsTrue( driver.existsElement(By.XPath("//nobr[contains(.,'Summary')]"))); // Verified the Information Summary page is displayed
         Assert.IsTrue(   driver.existsElement(By.XPath("//span[contains(.,'Title')]")));  //Verified the page contains Title
          Assert.IsTrue(  driver.existsElement(By.XPath("//span[contains(.,'Description')]")));  // Verified the page contains Description
          Assert.IsTrue(  driver.existsElement(By.XPath("//span[contains(.,'Approval Type')]"))); //Verified the page Contains Approval Type
            #endregion
          #region Navigate to Approval Path WIndow
          driver.SelectWindowClose();
          driver.SwitchTo().Window(ParentWIndow);
          driver.selectWindow("Approval Paths");
          driver.selectWindow("Approval Paths");
          #endregion
          #region Information icon for Available Approvers
          driver.FindElement(By.XPath("//img[@id='TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl02_ML.BASE.DG.Info']")).ClickWithSpace(); //Clicked on the Information icon for Available Approvers
            driver.selectWindow("");
            Assert.IsTrue(driver.existsElement(By.XPath("//nobr[contains(.,'Summary')]"))); // Verified the Information Summary page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Title')]")));  //Verified the page contains Title
          Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Description')]")));  // Verified the page contains Description
           Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Approval Type')]"))); //Verified the page Contains Approval Type
          #endregion
           #region Navigate to KI
           driver.Navigate_to_TrainingHome();
           driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
           #endregion
            //Assert.Fail();
        }
        [Test, Order(9)]
        public void Remove_Approver_25162()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin"); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password"); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace(); //Clicked on Log In
            #endregion
            #region navigate to  approval path page
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));

            driver.FindElement(By.XPath("//a[contains(.,'Access Approval Paths')]")).ClickWithSpace();
            driver.selectWindow("");
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Approval Paths')]"))); // Verify the page contains Approval Path heading
            #endregion
            #region Manage Approval Path
            driver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_ActionsMenu']"), "Manage"); //Manage Dollys Linear Approval path_04192017
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl03_GoButton']")).ClickWithSpace(); //Selected Go button
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@title='Edit Access Approval Path']"))); //Verified Edit Access Approval Path page is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[@id='ML.BASE.WF.ConfigureAccessApproval']"))); //Verified Access Approval Path tab is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Approvers/Stages')]"))); // Verified the Approvers/Stage tab is displayed
            #endregion
            #region Navigate to Approver Stages tab
            driver.FindElement(By.XPath("//span[contains(.,'Approvers/Stages')]")).ClickWithSpace(); //Approvers/Stages tab is selected
            #endregion
          
            #region Remove Approver
           Assert.IsTrue( driver.existsElement(By.XPath("//span[contains(.,'Current Approvers')]"))); //Verified the Section contains Current Approvers
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ExistingApproversList_ctl02_DataGridItem_ACCESS_APPR_STAGE_LOCALE/StageId']")); //Selected the checkbox for one of the Approver
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditApproversStages_ML.BASE.BTN.Remove']")); //Clicked on Remove button.  Modal box is dispayed where I had to click on OK or Cancel, but I cannot grab any string from there
            driver.findandacceptalert();
         Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'The selected approver(s) was removed from the path.')]"))); //Verified the Success message is displayed
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
