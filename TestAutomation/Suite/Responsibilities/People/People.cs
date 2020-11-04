using System;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using NUnit.Framework;


namespace TestAutomation.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   class People :TestBase
    {
        string browserstr = string.Empty;
        public People(string browser)
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
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        }
         [Test,Order(1)]
        public void Waive_Item_6829()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create new document with URL
            
             driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top
            //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
        Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
        driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc"+Meridian_Common.globalnum); // enter title = dv_doc20-04
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']")).ClickWithSpace();// click on url radio
           Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Enter URL')]")));// verify label
           driver.FindElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.google.com"); // enter url www.google.com
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checkin button.
        Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region create general course with URL
        driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[contains(.,'General Course')]"));// mouse hover on create link on top
            //driver.FindElement(By.XPath("//a[contains(.,'General Course')]"));//click on General course
         Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Create New General Course')]")));//verify course page
           Assert.IsTrue( driver.existsElement(By.XPath("//label[contains(.,'*Title')]")));//verify label title
           driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_gc"+Meridian_Common.globalnum); //enter title as dv_gc20/04
            driver.FindElement(By.XPath("//label[@for='MainContent_UC1_EXTERNALFILE_URL']")).ClickWithSpace();//click on url radio button
           Assert.IsTrue( driver.existsElement(By.XPath("//label[contains(.,'*Enter URL')]")));//verify label
           driver.FindElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeysWithSpace("www.yahoo.com");//enter url as www.yahoo.com
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();//click on create button
           StringAssert.AreEqualIgnoringCase("The item was created.",driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// verify successful saved message
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checin butotn
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region set document as a prerequiste for general course
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//mosue hover on manage
            //driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
          Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Manage Content')]")));//manage and search content section
            driver.FindElement(By.XPath("//a[contains(.,'Search & Create Content')]")).ClickWithSpace();// click on search and create link
           Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Search')]")));// verify label
           driver.FindElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']")).SendKeysWithSpace("dv_gc"+Meridian_Common.globalnum);//enter text as dv_gc20/04
            driver.FindElement(By.XPath("//input[@id='btnSearchCourses']")).ClickWithSpace();//click on search button
           Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Search Results')]")));//search result page
           StringAssert.AreEqualIgnoringCase("You searched for 'dv_gc" + Meridian_Common.globalnum + "'", driver.FindElement(By.XPath(".//*[@id='MainContent_ucSearchResults_divMsg']/p")).Text);//verify search result message as You searched for 'dv_gc20/04' 
            driver.FindElement(By.XPath("//a[contains(.,'dv_gc"+Meridian_Common.globalnum+"')]")).ClickWithSpace();//search result document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'dv_gc"+Meridian_Common.globalnum+"')]"))); //verify general course detail page
            Thread.Sleep(2000);
             driver.FindElement(By.XPath("//a[contains(.,'Checkout')]")).ClickWithSpace();//click on checuout button to make it checkin
               Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Check-in')]")));//verify it become as checkin
           Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,' Under Revision')]")));//verify status of content
           Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'Prerequisites')]")));//check prerequiestes
           Assert.IsTrue( driver.existsElement(By.XPath("//p[contains(.,'No prerequisites are currently assigned.')]")));//verify current status 
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']")).ClickWithSpace();//click on edit to add prerequisite
            Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Prerequisites')]")));//verify prerequisite page
            driver.FindElement(By.XPath("//a[contains(.,'Add Prerequisites')]")).ClickWithSpace();//click on add button
           Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,'Add Prerequisites')]")));//verify add prereq. page open
           Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Search for')]")));// label
           driver.FindElement(By.XPath("//input[contains(@id,'txtSearchFor')]")).SendKeysWithSpace("dv_doc"+Meridian_Common.globalnum);//enter text - dv_doc20-04
          Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Search Type')]")));//label
            driver.FindSelectElement(By.XPath("//option[contains(.,'Exact phrase')]"),"Exact phrase");//select exact phrase 
           Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'Content Type')]")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DOCUMENT']"),"Document");//select docuemnt
            driver.FindElement(By.XPath("//input[contains(@id,'btnSearch')]")).ClickWithSpace();//click search button
           Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'dv_doc"+Meridian_Common.globalnum+"')]")));// verify document that we searched
            driver.FindElement(By.XPath("//input[contains(@id,'chkSelect')]")).ClickWithSpace();//click on checkbox
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']")).ClickWithSpace();//click on add button
            StringAssert.AreEqualIgnoringCase("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message
            driver.FindElement(By.XPath("//a[contains(.,'dv_gc"+Meridian_Common.globalnum+"')]")).ClickWithSpace();//click on content link from breadcrumb to see detail page
            Assert.IsTrue(driver.existsElement(By.XPath("//h3[contains(.,'Prerequisites')]")));//vweify go to prerequieste accordian
            Assert.IsTrue(driver.existsElement(By.XPath("//p[contains(.,'1 Assigned Prerequisites')]")));// now showing 1 assiged prerequieste info
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checin butotn
          Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout
            #endregion
            #region create new learner 
         
          driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[contains(.,'Logout')]"));//mouse hover on user logout menu
            //driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));//click on logout
           Assert.IsTrue(driver.existsElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")));//verify login button
           Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,' or')]")));//label
          Assert.IsTrue(  driver.existsElement(By.XPath("//a[@id='MainContent_UC5_lnkCreateAccount']")));// verify new account butotn and click on it
             driver.FindElement(By.XPath("//a[@id='MainContent_UC5_lnkCreateAccount']")).ClickWithSpace();
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' Create New Account')]")));//create new account page
           Assert.IsTrue( driver.existsElement(By.XPath("//label[contains(.,'*Login ID')]")));
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeysWithSpace("learner"+Meridian_Common.globalnum);//enter text as learnerdv1
           Assert.IsTrue( driver.existsElement(By.XPath("//label[contains(.,'*Password')]")));//label
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_PASSWORD']")).SendKeysWithSpace("password");// enter password as password
         Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*Confirm Password')]")));//label
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_ConfirmPassword']")).SendKeysWithSpace("password");//re-enter pwd
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'*First Name')]")));//label first name
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']")).SendKeysWithSpace("learner");//enter name as dv1
       Assert.IsTrue(     driver.existsElement(By.XPath("//label[contains(.,'*Last Name')]")));//label
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']")).SendKeysWithSpace(""+Meridian_Common.globalnum);//enter lastname as singh
          Assert.IsTrue(  driver.existsElement(By.XPath("//label[@for='MainContent_UC1_lnkSelectOrg']")));//select org label
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_lnkSelectOrg']")).ClickWithSpace();//click on button
           Assert.IsTrue( driver.existsElement(By.XPath("//span[@class='k-window-title']")));//new popup window
          Assert.IsTrue(  driver.existsElement(By.XPath("//span[contains(.,'Select Organizations')]")));//verify label
         driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
             Assert.IsTrue(    driver.existsElement(By.XPath("//p[contains(.,'Select an item from search results, then select Save.')]")));//verify text
           Assert.IsTrue( driver.existsElement(By.XPath("//label[contains(.,'Find Organization')]")));//check label
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeysWithSpace("sample");//enter text as sample
           Assert.IsTrue( driver.existsElement(By.XPath("//label[@for='SearchType']")));//label
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.DV.SearchStartsWith']"),"Starts with");// select type as start with
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();//click on search
           Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Organizations')]")));// verify column organization
           Assert.IsTrue( driver.existsElement(By.XPath("//th[contains(.,'Path')]")));//verify column path
          Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Sample Organization 1')]")));//check org1
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']")).ClickWithSpace();//click checkbox for sample org1
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']")).ClickWithSpace();//click on save
            driver.SwitchTo().DefaultContent();
             Assert.IsTrue( driver.existsElement(By.XPath("//li[contains(.,'Sample Organization 1')]")));//verify org added and option to delete it is there
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Create']")).ClickWithSpace();//click on create
           Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,'Welcome')]")));//verify user loggedin and see welcome text
            #endregion
            #region learner access general course and request for waive item
           driver.FindElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace("dv_gc"+Meridian_Common.globalnum);// global search text box, enter text dv_gc20/04
           driver.ClickEleJs(By.XPath("//button[@class='btn btn-default']"));//click on search icon on this navigation
           Assert.IsTrue( driver.existsElement(By.XPath("//strong[@data-bind='formatText: [total]']"))); //searched data on left navigation page
           //Assert.IsTrue( driver.existsElement(By.XPath("//strong[contains(.,'Catalog ')]")));//searched data on left navigation page
          Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(.,' results for dv_gc"+Meridian_Common.globalnum+" in Catalog')]"))); //display info on searched data on left side menu
            driver.FindElement(By.XPath("//a[contains(.,'dv_gc"+Meridian_Common.globalnum+"')]")).ClickWithSpace();// select record and click on it to open this content
            driver.FindElement(By.XPath("//h1[contains(.,'dv_gc20/04')]"));//verify page
            driver.FindElement(By.XPath("//p[contains(.,'Warning You have one or more prerequisites to complete before you can take or access this item. If you have previously completed the item, then you may not have completed it in the allotted time or did not achieve the required score.')]"));//verify wanring message
            driver.FindElement(By.XPath("//h3[contains(.,'Prerequisites (1)')]"));//verify label 
            driver.FindElement(By.XPath("//input[@id='btnManagePrequisites']"));//button
            driver.FindElement(By.XPath("//a[contains(.,'dv_doc20-04')]"));//verify document that is prerequisite of this content
            driver.FindElement(By.XPath("//li[contains(.,' Status: Not Started          ')]"));//verify status
            driver.FindElement(By.XPath("//a[contains(.,'dv_doc"+Meridian_Common.globalnum+"')]")).ClickWithSpace();//click on this document
            driver.FindElement(By.XPath("//h1[contains(.,'dv_doc20-04')]"));//verify content detail page
            driver.FindElement(By.XPath("//strong[contains(.,'            English(United States)     ')]"));// content type and locale
            driver.FindElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']")).ClickWithSpace();//click on open button
            //new window for the url open and close it
            driver.SelectWindowClose2("Google", "dv_doc" + Meridian_Common.globalnum);
           Assert.IsTrue( driver.existsElement(By.XPath("//p[contains(.,'Information You first accessed this item on "+DateTime.Now.Date+". ')]")));//verify status
           driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            //driver.FindElement(By.XPath("//a[@href='/Logout.aspx']"));//click on logout
            #endregion
           #region login
           driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
           driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
           driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
           driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
           #endregion
            #region view transcript using learner account
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("learner"+Meridian_Common.globalnum);//search new user id
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
            driver.select(By.XPath("//select[@id='ddlUsrAction_0']"),"View Transcript");//select view transcript
            driver.FindElement(By.XPath("//a[@id='btnGo']")).ClickWithSpace();//click go
            #endregion
            #region check waive item flow
            //created Dv_GC with a prerequised item dv_doc by admin, then create a new learner account and access the dv_gc content
            // learner now send request waiver request for this item dv_doc
            //login with siteadmin and do people search for dv, lands on transcript and click on view transcript
          string text=  driver.FindElement(By.XPath("//option[contains(.,'Delete Progress')]")).Text;//verify delete progress control
          Assert.AreEqual("Delete Progress", text);//verify delete progress control
            string text1= driver.FindElement(By.XPath("//option[contains(.,'Mark Complete')]")).Text;//verify mark complete control
            Assert.AreEqual("Mark Complete", text1);
            driver.FindSelectElement(By.XPath("//option[contains(.,'Waive Item')]"),"Waive Item"); //click on waive item
          //  driver.FindElement(By.XPath("//option[contains(.,'Delete Progress')]"));//verify delete progress control
          //  driver.FindElement(By.XPath("//option[contains(.,'Mark Complete')]"));//verify mark complete control
         //   driver.FindElement(By.XPath("//option[contains(.,'Waive Item')]")); //click on waive item
                driver.FindElement(By.XPath("//a[contains(@id,'btnGo')]")).ClickWithSpace(); //click on  go
                driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
              
             driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_Reason']")).SendKeysWithSpace("TEsting"); // enter reason for action text box
             driver.FindElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
             driver.SwitchTo().DefaultContent();
             StringAssert.AreEqualIgnoringCase("The requirement for completing this item was waived.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);//successful message
            #endregion
             #region logout
             driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

            
           
        }
         [Test, Order(2)]
         public void Proxy_Login_2302()
         {
             #region login
             driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
             driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
             driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
             driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
             #endregion
            #region people search - proxy login with homephone changes on user account
             driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("learner");//search learner
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
            driver.FindSelectElement(By.XPath("//option[contains(.,'Proxy Login')]"),"Proxy Login"); //SelectCertificate proxy login
            driver.FindElement(By.XPath("//a[@id='btnGo']")).ClickWithSpace();//click go
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_txtAdminPassword']")).SendKeysWithSpace("password");//enter admin password
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_Save']")).ClickWithSpace();//click on login button
            //You are about to log into the site as dv singh. While logged in as this user, any action you perform will be credited to the user. Click OK to continue, or Cancel to remain logged in as yourself.
            //pop up appears and click on ok 
            driver.findandacceptalert();
            driver.SwitchTo().DefaultContent();
            driver.WaitForElement(By.XPath("//div[@id='proxyNotification']"));
            StringAssert.AreEqualIgnoringCase("You're logged in as a proxy.", driver.FindElement(By.XPath("//div[@id='proxyNotification']")).Text);//verify proxy login confirmation message
           Assert.IsTrue( driver.existsElement(By.XPath("//div[@role='alert']")));// red alert
            driver.ClickEleJs(By.XPath("//a[contains(.,'Account')]")); //click on my account
            driver.FindElement(By.XPath("//a[contains(@aria-controls,'acct-profile')]")).ClickWithSpace();//click profile tab
            driver.FindElement(By.XPath("//a[contains(.,'Edit User Information')]")).ClickWithSpace();//click edit user information
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
             driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_HOME_PHONE']")).SendKeysWithSpace("123456789");//enter home phone
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();//click save
            driver.SwitchTo().DefaultContent();
              driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            StringAssert.AreEqualIgnoringCase("The changes were saved.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// confirmation message on save
            driver.FindElement(By.XPath("//a[contains(@aria-controls,'acct-profile')]")).ClickWithSpace();//click profile tab
           Assert.IsTrue(driver.existsElement(By.XPath("//strong[contains(.,'123456789')]")));//verify home phone
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

         //   Assert.Fail();
         }
         [Test, Order(3)]
         public void Edit_Activity_6817()
         {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region people search - Edit Activity
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//search text
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click go
            driver.FindElement(By.XPath("//option[contains(.,'Edit Activity')]")); // select edit activity
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click go
            driver.FindElement(By.XPath("//h2[contains(.,'Edit Activity for dv singh')]"));// edit activity for choosen user
            driver.FindElement(By.XPath("//label[contains(.,'Inactive')]")); //verify radio buttons - inactive
            driver.FindElement(By.XPath("//label[contains(.,'Active')]"));//verify radio buttons - active
            driver.FindElement(By.XPath("//input[@id='chkNoStartDate']"));//verify no startdate checkbox
            driver.FindElement(By.XPath("//label[@for='chkNoStartDate']"));//no startdate label
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_OBJ_ACTIVE_START_DATE_dateInput']"));//choose start date
            driver.FindElement(By.XPath("//input[@id='chkNoEndDate']"));// no enddate checkbox
            driver.FindElement(By.XPath("//label[@for='chkNoEndDate']"));//no enddate label
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_OBJ_ACTIVE_END_DATE_dateInput']"));// choose end date
            driver.FindElement(By.XPath("//input[@name='ctl00$MainContent$UC1$Cancel']")); // verify cancel button 
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));// verify and click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));// confirmation message
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            //login with learner and check his message for activity change
            #region Learner check his messages from site to see activity changes
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            driver.FindElement(By.XPath("//a[@id='lnkMyMessages']"));//click my messages from account
            driver.FindElement(By.XPath("//h2[contains(.,'Messages')]"));//verify messages page
            driver.FindElement(By.XPath("//a[contains(.,'Activity Status in Meridian Global - Core Domain')]"));// verify email subject
                                                                                                                // not able to check inactive because after inactive user not able to login and email sent to his email id, so validation on email text needed.
#endregion


            Assert.Fail();
         }
         [Test,Order(4)]
         public void Edit_Login_ID_6818()
         {
             #region login
             driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
             driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
             driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
             driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
             #endregion
            #region people search  Edit login id
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("learner");//search learner
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
           Assert.IsTrue( driver.existsElement(By.XPath("//a[contains(.,'First Name')]"))); //first name column
           Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'learner')]")));//verify name in first name column
            driver.FindSelectElement(By.XPath("//option[@value='ML.BASE.ACT.EditLoginId']"),"Login ID");//select edit login id from drop down
            driver.FindElement(By.XPath("//a[@id='btnGo']")).ClickWithSpace();// click go
            driver.existsElement(By.XPath("//span[@class='k-window-title']"));//verify new pop-up window
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.existsElement(By.XPath("//span[contains(.,'Edit Login ID')]"));//pup-up window title
            driver.existsElement(By.XPath("//h2[contains(.,'Edit Login ID')]"));//label verification
            driver.existsElement(By.XPath("//p[contains(.,'Enter a new login ID for the user. Changes will apply immediately.')]"));//lable text
           Assert.IsTrue( driver.existsElement(By.XPath("//li[contains(.,' User: learner ')]")));//verify user name
            driver.existsElement(By.XPath("//strong[contains(.,'learnerdv')]"));//verify current user id
            driver.existsElement(By.XPath("//label[contains(.,'*New Login ID')]"));//label for new user id
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeysWithSpace("learnerdv");// enter new user id as learnerdv0
            driver.existsElement(By.XPath("//input[@id='MainContent_UC1_Cancel']"));//cancel button should be here
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();//click on save button
            driver.SwitchTo().DefaultContent();
            StringAssert.AreEqualIgnoringCase("The user's Login ID was updated.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);//confirmation message
         //   driver.FindElement(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"));//mouse hover
       
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login with learner's old account and he should not able to access it and successfully logged in with updated id
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//click login button
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeysWithSpace("learnerdv");//enter old user id i.e learnerdv
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");//enter password as -password
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();//click on login button
            driver.existsElement(By.XPath("//div[@class='alert alert-danger ng-binding ng-scope']"));//verify user should not logged in with old user id and got alert message
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learnerdv0");//enter updated user id as learnerdv0
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");//enter password as -password
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();//click on login button
          Assert.IsTrue(driver.existsElement(By.XPath("//h2[contains(.,' Current Training')]")));//verify user login to homepage
            #endregion
            //Assert.Fail();
          #region logout
          driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
          #endregion
         }
         [Test,Order(5)]
         public void Send_Email_People_6819()
         {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using siteadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region people search - send email to people
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//search text as dv
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click go
            driver.FindElement(By.XPath("//a[contains(.,'First Name')]")); //first name column
            driver.FindElement(By.XPath("//td[contains(.,'dv')]"));//verify name in first name column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.SendEmail']"));//select send email from drop down
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click on go
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//verify popup window tittle
            driver.FindElement(By.XPath("//p[contains(.,'Complete the required fields, enter your message and then select Send.')]"));//label text
            driver.FindElement(By.XPath("//a[contains(.,'Close')]"));//close button control
            driver.FindElement(By.XPath("//label[contains(.,'From')]"));//from label
            driver.FindElement(By.XPath("//input[@value='siteadmin@meridianksi.com']"));//site admin email id
            driver.FindElement(By.XPath("//label[contains(.,'*To')]"));//label to
            driver.FindElement(By.XPath("//input[@value='dv singh']"));//should display last name and first name of selected user
            driver.FindElement(By.XPath("//select[contains(@id,'ImportanceId')]"));// select importacne as medium
            driver.FindElement(By.XPath("//input[contains(@id,'Subject')]"));// enter subject id as send test mail
            driver.FindElement(By.XPath("//p[contains(.,'this is text in the message body')]"));//enter text in message box 
            driver.FindElement(By.XPath("//label[contains(@for,'EmailSendCopy')]"));//check label
            driver.FindElement(By.XPath("//input[contains(@id,'EmailSendCopy')]")); // select checkbox
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Send']"));//click on send button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));// successfful message
            driver.FindElement(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"));//mouser hover
            driver.FindElement(By.XPath("//a[@id='lnkMyMessages']"));//click on message to see copy of email
            driver.FindElement(By.XPath("//a[contains(.,'Subject')]"));//column subject
            driver.FindElement(By.XPath("//a[contains(.,'send test mail')]"));//verify the subject that we entered. should be send test mail
            driver.FindElement(By.XPath("//a[contains(.,'From')]"));//from column
            driver.FindElement(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"));//mouse hover
            driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));//logout click
            #endregion
            #region login with learner to see email message
            driver.FindElement(By.XPath("//input[@id='username']"));//enter updated user id as learnerdv0
            driver.FindElement(By.XPath("//input[@id='password']"));//enter password as -password
            driver.FindElement(By.XPath("//input[@type='submit']"));//click on login button
            driver.FindElement(By.XPath("//h2[contains(.,' Current Training')]"));//verify user login to homepage
            driver.FindElement(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"));//mouser hover
            driver.FindElement(By.XPath("//a[@id='lnkMyMessages']"));//click on message to see copy of email
            driver.FindElement(By.XPath("//a[contains(.,'send test mail')]"));//click on message which have this subject
             //new window open and display email details
            driver.FindElement(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"));//mouse hover
            driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));//logout click
            #endregion
            
            Assert.Fail();
         }
         [Test,Order(6)]//cannot be automated
         public void Select_Primary_Domain_6820()
         {
           
            Assert.Fail();
         }
         [Test,Order(7)]
         public void Edit_Profile_6821()
         {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using siteadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region people search - Edit Profile
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//search text as dv
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click go
            driver.FindElement(By.XPath("//a[contains(.,'First Name')]")); //first name column
            driver.FindElement(By.XPath("//td[contains(.,'dv')]"));//verify name in first name column
            driver.FindElement(By.XPath("//option[contains(.,'Edit Profile')]"));//select edit profile from drop down
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click on go
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]")); // Verify there is a breadcrumb to return to the Manage Users page
            driver.FindElement(By.XPath("//h1[contains(.,'dv1 singh')]"));// verify header indicator of user profile
            driver.FindElement(By.XPath("//a[contains(.,' Account')]"));//verify account tab
            driver.FindElement(By.XPath("//h2[contains(.,'  Domains and Roles')]"));//verify domain and role label on account tab
            driver.FindElement(By.XPath("//a[@title='Roles and Permissions']"));// verify roles button and click on it
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));// window title
            driver.FindElement(By.XPath("//span[contains(.,'Roles and Permissions')]"));// verify title name
            driver.FindElement(By.XPath("//input[@value='Close']"));//click on close button
            driver.FindElement(By.XPath("//a[contains(.,'  Profile')]"));//click on profile tab
            driver.FindElement(By.XPath("//h2[contains(.,'  User Information')]"));//verify user info label
            driver.FindElement(By.XPath("//a[contains(.,'Edit User Information')]"));//click on user info
            driver.FindElement(By.XPath("//span[contains(.,'User Information')]"));//verify user info page title
            driver.FindElement(By.XPath("//input[contains(@id,'MainContent_UC1_FormView1_USR_HOME_PHONE')]"));//enter home phone as 123456789
            driver.FindElement(By.XPath("//input[contains(@id,'Save')]"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//a[contains(.,'  Profile')]"));//click on profile tab
            driver.FindElement(By.XPath("//li[contains(.,'Home Phone: 123456789')]"));//verify value of phone no. should same
            driver.FindElement(By.XPath("//h2[contains(.,'    Qualifications')]"));//qualification label
            driver.FindElement(By.XPath("//a[contains(.,'Edit Qualifications')]"));//click on edit qualificaiton
            driver.FindElement(By.XPath("//textarea[contains(@id,'MainContent_UC1_FormView1_USR_EDUCATION_DESCRIPTION')]"));//enter text as test Desc
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//success msg.
            driver.FindElement(By.XPath("//a[contains(.,'  Profile')]"));//click on profile tab
            driver.FindElement(By.XPath("//strong[contains(.,'test desc')]"));//verify description data test desc
            driver.FindElement(By.XPath("//h2[contains(.,'   Work Information')]"));//work info. label
            driver.FindElement(By.XPath("//a[contains(.,'Edit Work Information')]"));//click on edit work info
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//page title
            driver.FindElement(By.XPath("//span[contains(.,'Work Information')]"));//title should be work information
            driver.FindElement(By.XPath("//input[contains(@id,'COMPANY')]"));// enter value as - test company
            driver.FindElement(By.XPath("//input[contains(@id,'Save')]"));//click on save
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//success msg
            driver.FindElement(By.XPath("//a[contains(.,'  Profile')]"));//click on profile tab
            driver.FindElement(By.XPath("//strong[contains(.,'test company')]"));//verify compnay name under work info
            driver.FindElement(By.XPath("//a[contains(.,'               Preferences')]"));//click on preferences tab
            driver.FindElement(By.XPath("//a[contains(.,'               Edit Preferences          ')]"));//click on edit preferences
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//popup window
            driver.FindElement(By.XPath("//span[contains(.,'Preferences')]"));//title name
            driver.FindElement(By.XPath("//label[contains(.,' Dutch')]"));//check dutch language
            driver.FindElement(By.XPath("//input[contains(@value,'nl-NL')]"));//click on dutch check box
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click save
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//success msg
            driver.FindElement(By.XPath("//a[contains(.,'               Preferences')]"));//click on preferences tab
            driver.FindElement(By.XPath("//li[contains(.,'Secondary Language: Dutch')]"));//verify secondary language should be dutch
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            Assert.Fail();
         }
         [Test,Order(8)]//cannot be automated
         public void UnlockAccount_6822()
         {
            //cannot automated as no test to lock user account is there to unlock it
             Assert.Fail();
         }
         [Test,Order(9)]
         public void ViewTranscript_6823()
         {
            
            
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create test
            driver.FindElement(By.XPath("//a[contains(.,'  Administer     ')]"));//mouse hover on admin
            driver.FindElement(By.XPath("//a[@href='#admin-console-training']"));//click on training tab
            driver.FindElement(By.XPath("//a[contains(.,'Content Management')]"));//click on content mgt link
            driver.FindElement(By.XPath("//a[contains(.,'Tests')]"));//click on tests link
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify admin lands on tests page in new tab
            driver.FindElement(By.XPath("//option[contains(.,'Create New')]"));//select create new from drop down 
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify create new test page open
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_TITLE']"));//enter title as dv_test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_DESCRIPTION']"));//enter desc. as test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_KEYWORDS']"));//enter keywords as test
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//nobr[contains(.,'Edit Structure')]"));//verify user lands on edit structure tab
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewGroup']"));//select 'create new group' from drop down
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_TITLE']"));//enter tittle as 'test'
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_DESCRIPTION']"));//enter desc as test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_KEYWORDS']"));//enter keywords as test
            driver.FindElement(By.XPath("//input[contains(@id,'QUESTIONS')]"));//enter no. of question as 2
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.EditStructure']"));//click on edit structure link
            driver.FindElement(By.XPath("//td[@class=' firepath-matching-node']"));//verify that test should appear under title column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewTrueFalseQuestion']"));//click new true/false option from actiion
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));//click on go button
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']"));//enter question as 'sun rises from east?'
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TYPE_TRUEFALSE_VALUE_0']"));//click choice as yes
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify our question appear on top as sun rises from east?
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The question was created.
            driver.FindElement(By.XPath("//a[@navigatingurl='TEST/MANAGEMENT/TESTEDITSTRUCTURE.ASPX']"));//click on edit structure link
            driver.FindElement(By.XPath("//td[@class=' firepath-matching-node']"));//verify that test should appear under title column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewMultipleChoiceQuestion']"));//click on new multiple choice from drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));//click go button
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']")); // enter quesiton as - Are you human?
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_QSTNCHC_TITLE']"));//enter choice as yes
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.AddChoice']"));//click on add choice button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_QSTNCHC_TITLE']"));//enter choice as no
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.AddChoice']"));//click on add choice button
            driver.FindElement(By.XPath("//span[@id='TabMenu_ML_BASE_TAB_EditChoices_FeedbackTestQuestionChoices']"));//verify records found should be 2
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_TestQuestionChoices_ctl02_DataGridItem_Correct']"));//click on select checkbox
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.Save']"));//click on save button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message that The choice(s) was updated. displayed
            driver.FindElement(By.XPath("//a[@navigatingurl='CONTENT/ADMINCONTENTSIMPLESEARCH.ASPX?strContentTypeId=ML.BASE.TEST']"));//click on test link on top
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text- dv_test 
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_Search_ID1_CONTENT1_1_0_F8A8C7D1FE404A0187F059E3031A06CA']"));//verify dv_test should appear in test search and click on it
            driver.FindElement(By.XPath("//a[contains(.,'Lock Test')]"));//click on lock test
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The test was locked. You may now use this test to publish one or more instances of the test (users may take the tests you publish).
            driver.FindElement(By.XPath("//a[contains(.,'Publish SCORM 2004')]"));//click on publish scorm 2004
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COURSE_TITLE']"));//edit tittle from dv_test to dv_test1
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MASTERY_SCORE']"));//enter mastery score as 100
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_SHOW_ALL_QUESTIONS']"));//select checkbox to show all question
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The published test was created.
            driver.FindElement(By.XPath("//span[contains(.,'Check In')]"));//click on checkin
            driver.FindElement(By.XPath("//span[contains(.,'Check Out')]"));//verify it become checkout
                                                                            //close the tab
            #endregion
            #region login-learner account
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learnerdv0");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region  Search Test and open test
            driver.FindElement(By.XPath("//input[contains(@id,'txtGlobalSearch')]"));// search text dv_test
            driver.FindElement(By.XPath("//button[@class='btn btn-default']"));//click on go
            driver.FindElement(By.XPath("//a[contains(.,'dv_test1')]"));//click on content item - dv_test
            driver.FindElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));//click on open button
                                                                                                                     //new window open
            driver.FindElement(By.XPath(".//*[@id='SCORMMenu_1']/span[3]/i//"));//click on title link of test
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[1]/table/tbody/tr/td[1]/font"));// verify question 1
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[1]/table/tbody/tr/td[1]/table/tbody/tr[1]/td[4]/label")); // verify question 1
            driver.FindElement(By.XPath(".//*[@id='q1c1']"));// select checkbox for option 
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[2]/table/tbody/tr/td[1]/font"));// verify Question 2
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[2]/table/tbody/tr/td[1]/table/tbody/tr[1]/td[3]/label"));// verify answer as true
            driver.FindElement(By.XPath(".//*[@id='q2true']"));// select checkbox for option 2
            driver.FindElement(By.XPath(".//*[@id='Submit']"));// click on submit button
            driver.FindElement(By.XPath(".//*[@id='ResultsContainer']/font[1]"));// verify success message as - )// Your score is 100%. You passed the exam.
            driver.FindElement(By.XPath(".//*[@id='Submit']"));// click on close button to close window
            driver.FindElement(By.XPath("//p[contains(.,'Success You completed this item on 4/26/2017.  View Details ')]"));//verify success message as  You completed this item on 4/26/2017.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region view transcript using learner account
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//search new user id
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
            driver.select(By.XPath("//select[@id='ddlUsrAction_0']"), "View Transcript");//select view transcript
            driver.FindElement(By.XPath("//a[@id='btnGo']")).ClickWithSpace();//click go
            #endregion
            #region Admin update Score for learner transcript
            driver.FindElement(By.XPath("//select[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl08_ddlUsrAction']"));// select update score value from dropdown
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl08_btnGo']"));//click on go 
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//verify popup window open
            driver.FindElement(By.XPath("//strong[contains(.,'dv_test1')]"));//verify title as dvtest1
            driver.FindElement(By.XPath("//span[contains(.,'Update Score')]"));//verify title for popup window
            driver.FindElement(By.XPath("//strong[contains(.,'dv singh')]"));//verify user dv singh i.e user first and last name
            driver.FindElement(By.XPath("//strong[contains(.,'Test')]"));//verify content type as test
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Score']"));//edit score from 100.00 to make it 90
            driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_Reason']"));//fill text as test in reason text box
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Cancel']"));//verify cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on update score
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify aler message as  The score was updated.
            driver.FindElement(By.XPath("//a[contains(.,'Score')]"));//verify column name score
            driver.FindElement(By.XPath("//td[contains(.,'90.00')]"));//verify score should 90.00 under score column
            #endregion
            #region Admin come back to people from Learner Transcript
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user come back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region people search - View Transcript
            driver.HoverLinkClick(By.Id("ManagerView"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("dv1");//search text as dv1
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
            driver.FindElement(By.XPath("//a[contains(.,'First Name')]")); //first name column
            driver.FindElement(By.XPath("//td[contains(.,'dv1')]"));//verify name in first name column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.ViewTranscript']"));//select edit profile from drop down
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click on go
            driver.FindElement(By.XPath("//h1[contains(.,'User Transcript for dv1 singh')]"));//verify it display transcript of logged user dv1 sing
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]")); // Verify there is a breadcrumb to return to the Manage Users page
            driver.FindElement(By.XPath("//h1[contains(.,'dv1 singh')]"));// verify header indicator of user profile
            driver.FindElement(By.XPath("//th[contains(.,'             Action             ')]"));//action label
            driver.FindElement(By.XPath("//td[contains(.,'      dv_doc20 - 04     ')]"));//verify content item
            driver.FindElement(By.XPath("//option[@value='ML.BASE.HEAD.MarkComplete']"));//verify mark complete option 
            driver.FindElement(By.XPath("//option[@value='ML.BASE.GENERIC.DeleteProgress']"));//verify delete progress option
            driver.FindElement(By.XPath("//option[@value='ML.BASE.LBL.MO.Admin.ProgressHistory']"));//verify preogress history option
            driver.FindElement(By.XPath("//option[@value='ML.BASE.HEAD.Dialog.WaiveContent']"));//verify waive item option
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create instructor
            driver.FindElement(By.XPath("//a[contains(.,'  Administer     ')]"));//mouse hover on admin
            driver.FindElement(By.XPath("//a[contains(@href,'#admin-console-personnel')]"));//click on people tab
            driver.FindElement(By.XPath("//a[contains(.,'Instructors')]"));//click on instructor link
            //new tab open
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify label should be Instructors on page
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.DesignateInstructor']"));//select value as Add Users
            driver.FindElement(By.XPath("//input[@value='Go']"));//click go button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME']"));//enter first name as DV
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//span[contains(.,'Records found: 2')]"));//verify search result message 
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers']/tbody/tr[3]/td[3]"));//verify user dv singh
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl03_DataGridItem_PRM_ENTITY_NAME']"));//select checkbox for user dv singh
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnAdd']"));//click on add selected button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message The user(s) was added.
            driver.FindElement(By.XPath("//input[@id='Return']"));//click on return button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_USR_FIRST_NAME']"));//enter text as first name
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ManageInstructorList']/tbody/tr[2]/td[4]"));//verify first name is DV
             //close Add new instructor tab
            #endregion
            #region create classroom
            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateClassroom.aspx']"));// mouse hover on create link on top and click on classroom course
            driver.FindElement(By.XPath("//h1[contains(.,' Create New Classroom Course')]"));//verify label
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']"));// enter text as DV_Class
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on create button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message 
            #endregion
            #region create section
            driver.FindElement(By.XPath("//a[contains(.,'Schedule & Manage Sections')]"));//click on Schedule & manage section tab
            driver.FindElement(By.XPath("//input[@value='Add a New Section']"));//click on add a new section button
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]"));//enter text as test section
            driver.FindElement(By.XPath("//input[@value='ML.BASE.INPERSON']"));// select radio button as in person.
            driver.FindElement(By.XPath("//input[@value='F']"));//select value as no radio button.
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']"));//click on next button
            #endregion
            #region Create section
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput']"));//enter start date as today date 4/28/2017
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput']"));//enter end date as tomorow i.e 4/29/2017
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput']"));//enter start time as 1:00 PM
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput']"));//enter end time as 10:00 PM
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkSelectInst']"));//clikc on select instructor
            driver.FindElement(By.XPath("//h2[contains(.,'Select Instructor')]"));//verify label in new page
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_USR_FIRST_NAME']"));//enter text as dv in first name text box
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//td[contains(.,'  dv singh ')]"));//verify user name in result
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_SectionInstructorSearch_ctl00_ctl04_chkSelect']"));//click on checkbox
            driver.FindElement(By.XPath(".//*[@id='MainContent_MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//p[contains(.,'     dv singh,                ')]"));//verify instructor name in instrutor section within section page
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY']"));//eter value as 1
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY']"));//enter value as 20
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_WAITLIST_OPTION_0']"));//select radio button use waitlist
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkEnrollInfo']"));//click on change button for enrollmetn
            driver.FindElement(By.XPath("//span[contains(.,'Enrollment Period')]"));//verify popup window label
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput']"));//enter start date as 4/28/2017
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput']"));//enter end date as 4/29/2017
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput']"));//enter start time as 12:00 AM
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput']"));//enter end time as 6:00AM
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//p[contains(.,  Course section enrollment begins on 4 / 28 / 2017 12:00 AM and ends on 4 / 29 / 2017 6:00 AM.')]"));//verify enrollment date and time schedule on section page
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//veriy success message as The course section was created with the first event.
#endregion
            #region enroll user
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//click on manage enrolment button
            driver.FindElement(By.XPath("//td[contains(.,'test section')]"));//verify section name
            driver.FindElement(By.XPath("//a[@id='btnEnrollUser_671264306D65407BA0996CCCB4D01686']"));//click on enroll users button
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//enter text as dv
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click on search link next to text box
            driver.FindElement(By.XPath(".//*[@id='tableEnrollmentUsers']/tbody/tr/td[2]"));//verify last name
            driver.FindElement(By.XPath(".//*[@id='tableEnrollmentUsers']/tbody/tr/td[3]"));//verify first name
            driver.FindElement(By.XPath("//input[@id='btSelectItem_ED8C528FC87E4A31A1965511F7AB2CB3']"));//click on checkbox
            driver.FindElement(By.XPath("//input[@id='btnEnrollUsers']"));//click on batch enroll users button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message as The selected users were enrolled in the section.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learnerdv0");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region  verify learner get notification on enrollment
            driver.FindElement(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"));//mouse hover on my account
            driver.FindElement(By.XPath("//a[@id='lnkMyMessages']"));//click on messages
            driver.FindElement(By.XPath("//a[contains(.,'Course Enrollment: DV_Class - Section #1')]"));//verify subject of mail
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region view transcript using learner account
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//search new user id
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
            driver.select(By.XPath("//select[@id='ddlUsrAction_0']"), "View Transcript");//select view transcript
            driver.FindElement(By.XPath("//a[@id='btnGo']")).ClickWithSpace();//click go
            #endregion
            #region mark complete
            driver.FindElement(By.XPath("//td[contains(.,'         DV_Class(1)    ')]"));//verify class tittle name on user transcript
            driver.FindElement(By.XPath("//option[contains(.,'Mark Complete')]"));//select mark complete value from drop down 
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl08_btnGo']"));//click on go 
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//verify popup window open
            driver.FindElement(By.XPath("//span[contains(.,'Mark Complete')]"));//verify page tittle
            driver.FindElement(By.XPath("//li[contains(.,'          Title:       test section ')]"));//verify section title name on this page
            driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_Reason']"));//fill text as test in reason text box
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Cancel']"));//verify cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on update score
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify aler message as  The score was updated.
            driver.FindElement(By.XPath("//td[contains(.,'         DV_Class(1)    ')]"));//verify class tittle name on user transcript
            driver.FindElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__1']/td[3]"));//verify status for this should be completed 
            #endregion
            #region Admin come back to people from Learner Transcript
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user come back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create external learning type
            driver.FindElement(By.XPath("//a[contains(.,'              Administer          ')]"));//mouse hover on adminster
            driver.FindElement(By.XPath("//a[@href='#admin-console-contentManagement']"));//click on content mgt.
            driver.FindElement(By.XPath("//a[contains(.,'External Learning Types')]"));//clikc on ext. learning type
            //new tab open
            driver.FindElement(By.XPath("//span[contains(.,'External Learning Types')]"));//verify label text on this page
            driver.FindElement(By.XPath("//option[contains(.,'Create New')]"));//select create new
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));//click on go
            driver.FindElement(By.XPath("//span[contains(.,'New External Learning Type')]"));//veriy label 
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditExternalLearningType_ELTL_TYPE_TITLE']"));//enter title text as test external type
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditExternalLearningType_ELTL_TYPE_DESC']"));//enter desc. as test
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//very alert message
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.ExternalLearningType']"));//clikc on breadcrumb link
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text as test external type
            driver.FindElement(By.XPath("//option[contains(.,'Exact phrase')]"));//select type as exact phrase
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Search_ExternalLearningType_ELTL_TYPE_ID_0_01_1||A55ABCF746BA46ACA36EAB16DAD70324']/td[4] "));//verify title text should be test external type
                                                                                                                                                                     //close this tab
            #endregion
            #region create external learning
            driver.FindElement(By.XPath("//a[contains(.,'              Administer          ')]"));//mouse hover on adminster
            driver.FindElement(By.XPath("//a[@href='#admin-console-contentManagement']"));//click on content mgt.
            driver.FindElement(By.XPath(".//*[@id='admin-console-contentManagement']/div/ul/li[7]/a']"));//click on external learning
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//veriy label on new page should be External Learning
            driver.FindElement(By.XPath("//option[contains(.,'Create New')]"));//select create new
            driver.FindElement(By.XPath("//input[@value='Go']"));//clikc go
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//veriy new page label should be New External Learning
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_EXT_TITLE']"));//enter text as dv_External learning
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_EXT_DESCRIPTION']"));//enter desc as test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_EXT_KEYWORDS']"));//enter keyword as test
            driver.FindElement(By.XPath("//option[@value='A55ABCF746BA46ACA36EAB16DAD70324']"));//select content type value as test external type
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']"));//click on save button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//veriy success message
            driver.FindElement(By.XPath("//span[contains(.,'Check In')]"));//click on checkin button
            driver.FindElement(By.XPath("//span[contains(.,'Check Out')]"));//veriy it changed to checkout
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.ExternalLearning']"));//click on breadcrumb to go back to page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text dv_External learning
            driver.FindElement(By.XPath("//option[@value='ML.BASE.DV.SearchExactPhrase']"));//select valuye as exact phrase
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_Search_ID1_CONTENT1_1_0_1535F9ABBB5B4C2AAB48F382BC10C35A']"));//veriy tittle id in results
                                                                                                                                    //close tab
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learnerdv0");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region learner submit external learning request
            driver.FindElement(By.XPath("//a[contains(.,'                      Learn                ')]"));//mouse hover on learn tab
            driver.FindElement(By.XPath("//a[contains(.,'Transcript')]"));//click on transcript
            driver.FindElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkEL']"));//click in external learning tab
            driver.FindElement(By.XPath("//a[@id='MainContent_UC2_MLinkButton1']"));//click on submit request button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_txtSearchFor']"));//enter text as dv external learning
            driver.FindElement(By.XPath("//option[@value='ML.BASE.DV.SearchExactPhrase']"));//select search type as exact phrase
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));//click on search
            driver.FindElement(By.XPath("//h2[contains(.,'           1 Items')]"));//veriy search result label
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_UC1_rlvSearchResults_ctrl0_lnkDetails']"));//veriy and click on content dv external learning in search result
            driver.FindElement(By.XPath("//h1[contains(.,'dv_External learning')]"));//verify detail page label
            driver.FindElement(By.XPath("//strong[contains(.,'test external type')]"));//veriy type should be test external type
            driver.FindElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_SubmitRequestBlock']"));//click on submit button
            driver.FindElement(By.XPath("//span[contains(.,'Submit External Learning Request')]"));//verify poputp page tittle 
            driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_fvSubmitRequest_ELR_REASON']"));//enter text as test
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_fvSubmitRequest_ELR_OBTAINED_DATE_dateInput']"));//enter date obtained date as 6/23/2017 tomorrow
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_fvSubmitRequest_ELR_TUITION_REIMBURSEMENT_1']"));//seect tution reimb as no.
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_SubmitRequest']"));//click on submit
            driver.FindElement(By.XPath("//p[contains(.,'Success You submitted an external learning request for approval on 5/5/2017.')]"));//veriy message and date should be today's date
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region admin approve external learning request
            driver.FindElement(By.XPath("//a[contains(.,'         Administer               ')]"));//mouser hover on admin tab
            driver.FindElement(By.XPath("//a[@href='#admin-console-training']"));//click on training
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));//click on training mgt.
            driver.FindElement(By.XPath("//a[contains(.,'External Learning Requests')]"));//click on external learning req.
            //new tab open
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify heading should be External Learning Console
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_LBL_SearchUsers_USR_LAST_NAME']"));//enter last name as singh
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_LBL_SearchUsers_USR_FIRST_NAME']"));//enter first name as dv
            driver.FindElement(By.XPath("//option[@value='ML.BASE.EXTLLRNGSTATUS.Pending']"));//select option as pending
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_LBL_SearchUsers_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//span[@id='TabMenu_ML_BASE_LBL_SearchUsers_Feedback_b4d62adfe6694c21a9e69a940adf7513']"));//verify search result message
            driver.FindElement(By.XPath("//td[contains(.,'.//*[@id='TabMenu_ML_BASE_LBL_SearchUsers_LMS_USER_USR_LMS_USER_ID_0_01_1||ED8C528FC87E4A31A1965511F7AB2CB3']/td[3]')]"));//verify dv singh in result
            driver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_LBL_SearchUsers_CONTENT_ITEM_CNT_CONTENT_ID_0_02_2||1535F9ABBB5B4C2AAB48F382BC10C35A']/td[5]')]"));//verify title name
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.TakeAction']"));//select take action
            driver.FindElement(By.XPath("//input[@class='Button']"));//click on go
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify label Take Action
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_ACT_TakeAction_ELH_STATUS_ID_0']"));//selct readio button of approve 
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_ACT_TakeAction_ELR_EXP_DATE||DATEPICKER_dateInput']"));//enter date as future more than date obtained like 25/6/2017
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_ACT_TakeAction_ELH_REASON']"));//enter reason as test
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_ACT_TakeAction_ML.BASE.BTN.TakeAction']"));//click on action button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//veriy success message as The external learning request was approved.
            #endregion
            //close the tab
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            Assert.Fail();
         }
         [Test,Order(10)]
         public void Update_Score_6825()
         {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create test
            driver.FindElement(By.XPath("//a[contains(.,'  Administer     ')]"));//mouse hover on admin
            driver.FindElement(By.XPath("//a[@href='#admin-console-training']"));//click on training tab
            driver.FindElement(By.XPath("//a[contains(.,'Content Management')]"));//click on content mgt link
            driver.FindElement(By.XPath("//a[contains(.,'Tests')]"));//click on tests link
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify admin lands on tests page in new tab
            driver.FindElement(By.XPath("//option[contains(.,'Create New')]"));//select create new from drop down 
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify create new test page open
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_TITLE']"));//enter title as dv_test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_DESCRIPTION']"));//enter desc. as test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_KEYWORDS']"));//enter keywords as test
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//nobr[contains(.,'Edit Structure')]"));//verify user lands on edit structure tab
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewGroup']"));//select 'create new group' from drop down
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_TITLE']"));//enter tittle as 'test'
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_DESCRIPTION']"));//enter desc as test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_KEYWORDS']"));//enter keywords as test
            driver.FindElement(By.XPath("//input[contains(@id,'QUESTIONS')]"));//enter no. of question as 2
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.EditStructure']"));//click on edit structure link
            driver.FindElement(By.XPath("//td[@class=' firepath-matching-node']"));//verify that test should appear under title column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewTrueFalseQuestion']"));//click new true/false option from actiion
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));//click on go button
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']"));//enter question as 'sun rises from east?'
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TYPE_TRUEFALSE_VALUE_0']"));//click choice as yes
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify our question appear on top as sun rises from east?
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The question was created.
            driver.FindElement(By.XPath("//a[@navigatingurl='TEST/MANAGEMENT/TESTEDITSTRUCTURE.ASPX']"));//click on edit structure link
            driver.FindElement(By.XPath("//td[@class=' firepath-matching-node']"));//verify that test should appear under title column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewMultipleChoiceQuestion']"));//click on new multiple choice from drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));//click go button
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']")); // enter quesiton as - Are you human?
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_QSTNCHC_TITLE']"));//enter choice as yes
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.AddChoice']"));//click on add choice button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_QSTNCHC_TITLE']"));//enter choice as no
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.AddChoice']"));//click on add choice button
            driver.FindElement(By.XPath("//span[@id='TabMenu_ML_BASE_TAB_EditChoices_FeedbackTestQuestionChoices']"));//verify records found should be 2
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_TestQuestionChoices_ctl02_DataGridItem_Correct']"));//click on select checkbox
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.Save']"));//click on save button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message that The choice(s) was updated. displayed
            driver.FindElement(By.XPath("//a[@navigatingurl='CONTENT/ADMINCONTENTSIMPLESEARCH.ASPX?strContentTypeId=ML.BASE.TEST']"));//click on test link on top
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text- dv_test 
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_Search_ID1_CONTENT1_1_0_F8A8C7D1FE404A0187F059E3031A06CA']"));//verify dv_test should appear in test search and click on it
            driver.FindElement(By.XPath("//a[contains(.,'Lock Test')]"));//click on lock test
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The test was locked. You may now use this test to publish one or more instances of the test (users may take the tests you publish).
            driver.FindElement(By.XPath("//a[contains(.,'Publish SCORM 2004')]"));//click on publish scorm 2004
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COURSE_TITLE']"));//edit tittle from dv_test to dv_test1
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MASTERY_SCORE']"));//enter mastery score as 100
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_SHOW_ALL_QUESTIONS']"));//select checkbox to show all question
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The published test was created.
            driver.FindElement(By.XPath("//span[contains(.,'Check In')]"));//click on checkin
            driver.FindElement(By.XPath("//span[contains(.,'Check Out')]"));//verify it become checkout
                                                                            //close the tab
            #endregion
            #region login-learner account
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learnerdv0");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region  Search Test and open test
            driver.FindElement(By.XPath("//input[contains(@id,'txtGlobalSearch')]"));// search text dv_test
            driver.FindElement(By.XPath("//button[@class='btn btn-default']"));//click on go
            driver.FindElement(By.XPath("//a[contains(.,'dv_test1')]"));//click on content item - dv_test
            driver.FindElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));//click on open button
                                                                                                                     //new window open
            driver.FindElement(By.XPath(".//*[@id='SCORMMenu_1']/span[3]/i//"));//click on title link of test
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[1]/table/tbody/tr/td[1]/font"));// verify question 1
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[1]/table/tbody/tr/td[1]/table/tbody/tr[1]/td[4]/label"));// verify question 1
            driver.FindElement(By.XPath(".//*[@id='q1c1']"));// select checkbox for option 
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[2]/table/tbody/tr/td[1]/font"));// verify Question 2
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[2]/table/tbody/tr/td[1]/table/tbody/tr[1]/td[3]/label"));// verify answer as true
            driver.FindElement(By.XPath(".//*[@id='q2true']"));// select checkbox for option 2
            driver.FindElement(By.XPath(".//*[@id='Submit']"));// click on submit button
            driver.FindElement(By.XPath(".//*[@id='ResultsContainer']/font[1]"));// verify success message as - )// Your score is 100%. You passed the exam.
            driver.FindElement(By.XPath(".//*[@id='Submit']"));// click on close button to close window
            driver.FindElement(By.XPath("//p[contains(.,'Success You completed this item on 4/26/2017.  View Details ')]"));//verify success message as  You completed this item on 4/26/2017.
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
            #region view transcript of learner account
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//search new user id
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
            driver.select(By.XPath("//select[@id='ddlUsrAction_0']"), "View Transcript");//select view transcript
            driver.FindElement(By.XPath("//a[@id='btnGo']")).ClickWithSpace();//click go
            #endregion
            #region Admin update Score for learner transcript
            driver.FindElement(By.XPath("//select[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl08_ddlUsrAction']"));// select update score value from dropdown
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl08_btnGo']"));//click on go 
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//verify popup window open
            driver.FindElement(By.XPath("//strong[contains(.,'dv_test1')]"));//verify title as dvtest1
            driver.FindElement(By.XPath("//span[contains(.,'Update Score')]"));//verify title for popup window
            driver.FindElement(By.XPath("//strong[contains(.,'dv singh')]"));//verify user dv singh i.e user first and last name
            driver.FindElement(By.XPath("//strong[contains(.,'Test')]"));//verify content type as test
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Score']"));//edit score from 100.00 to make it 90
            driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_Reason']"));//fill text as test in reason text box
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Cancel']"));//verify cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on update score
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify aler message as  The score was updated.
            driver.FindElement(By.XPath("//a[contains(.,'Score')]"));//verify column name score
            driver.FindElement(By.XPath("//td[contains(.,'90.00')]"));//verify score should 90.00 under score column
            #endregion
            #region Admin come back to people from Learner Transcript
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user come back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

            Assert.Fail();
         }
         [Test,Order(11)]
         public void Mark_Complete_6826()
         {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using siteadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region people search - Mark complete
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//search text as dv
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click go
            driver.FindElement(By.XPath("//a[contains(.,'First Name')]")); //first name column
            driver.FindElement(By.XPath("//td[contains(.,'dv')]"));//verify name in first name column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.ViewTranscript']"));//select edit profile from drop down
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click on go
            driver.FindElement(By.XPath("//h1[contains(.,'User Transcript for dv singh')]"));//verify it display transcript of logged user dv1 sing
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]")); // Verify there is a breadcrumb to return to the Manage Users page
            driver.FindElement(By.XPath("//h1[contains(.,'dv singh')]"));// verify header indicator of user profile
            driver.FindElement(By.XPath("//th[contains(.,'             Action             ')]"));//action label
            driver.FindElement(By.XPath("//td[contains(.,'      DV_Doc1      ')]"));//verify content item
            driver.FindElement(By.XPath("//option[@value='ML.BASE.HEAD.MarkComplete']"));//verify mark complete option and click on it
            driver.FindElement(By.XPath("//a[contains(@id,'btnGo')]"));//click on go
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//popup window title
            driver.FindElement(By.XPath("//span[contains(.,'Mark Complete')]"));//verify page title
            driver.FindElement(By.XPath("//li[contains(.,'           User:       dv singh     ')]"));//verify user
            driver.FindElement(By.XPath("//strong[contains(.,'DV_Doc1')]"));//verify tittle
            driver.FindElement(By.XPath("//strong[contains(.,'Document')]"));//verify content type
            driver.FindElement(By.XPath("//label[contains(.,'*Reason for Action')]"));//verify label- reason for action
            driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_Reason']"));//enter text as testing
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Cancel']"));//verify cancel button presence
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//verify mark complete button presence and click on it
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]"));//success messaage
            driver.FindElement(By.XPath("//td[contains(.,'Completed')]"));// verify status now become completed
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
             Assert.Fail();

         }
         [Test,Order(12)]
         public void Delete_Progress_6828()
         {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using siteadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region people search - Delete Progress
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//search text as dv
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click go
            driver.FindElement(By.XPath("//a[contains(.,'First Name')]")); //first name column
            driver.FindElement(By.XPath("//td[contains(.,'dv')]"));//verify name in first name column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.ViewTranscript']"));//select edit profile from drop down
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click on go
            driver.FindElement(By.XPath("//h1[contains(.,'User Transcript for dv singh')]"));//verify it display transcript of logged user dv1 sing
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]")); // Verify there is a breadcrumb to return to the Manage Users page
            driver.FindElement(By.XPath("//h1[contains(.,'dv singh')]"));// verify header indicator of user profile
            driver.FindElement(By.XPath("//th[contains(.,'             Action             ')]"));//action label
            driver.FindElement(By.XPath("//td[contains(.,'      DV_Doc1      ')]"));//verify content item
            driver.FindElement(By.XPath("//option[@value='ML.BASE.HEAD.MarkComplete']"));//verify mark complete option and click on it
            driver.FindElement(By.XPath("//a[contains(@id,'btnGo')]"));//click on go
            driver.FindElement(By.XPath("//span[@class='k-window-title']"));//popup window title
            driver.FindElement(By.XPath("//span[contains(.,'Mark Complete')]"));//verify page title
            driver.FindElement(By.XPath("//li[contains(.,'           User:       dv singh     ')]"));//verify user
            driver.FindElement(By.XPath("//strong[contains(.,'DV_Doc1')]"));//verify tittle
            driver.FindElement(By.XPath("//strong[contains(.,'Document')]"));//verify content type
            driver.FindElement(By.XPath("//label[contains(.,'*Reason for Action')]"));//verify label- reason for action
            driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_Reason']"));//enter text as testing
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Cancel']"));//verify cancel button presence
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//verify mark complete button presence and click on it
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]"));//success messaage
            driver.FindElement(By.XPath("//td[contains(.,'Completed')]"));// verify status now become completed
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region Admin come back to people from Learner Transcript
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user come back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            Assert.Fail();
         }
         [Test,Order(13)]
         public void Create_Password_6816()
         {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region create password for learner account
            driver.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace("learner" + Meridian_Common.globalnum);//search new user id
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();//click go
            driver.FindElement(By.XPath("//td[contains(.,'singh')]"));//verify last name
            driver.FindElement(By.XPath("//td[contains(.,'dv')]"));//verify first name
            driver.FindElement(By.XPath("//option[contains(.,'Create Password')]"));//..select create password option
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click on go
            //popup window
            driver.FindElement(By.XPath("//span[contains(.,'Create Password')]"));//verify tittle name
            driver.FindElement(By.XPath("//li[contains(.,'          User:        dv singh   ')]"));//verify user name
            driver.FindElement(By.XPath("//input[@value='Create']"));//click on create button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify message
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

            Assert.Fail();
         }
         [Test,Order(14)]
         public void View_Certificate_6830()
         {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using siteadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region create test
            driver.FindElement(By.XPath("//a[contains(.,'  Administer     ')]"));//mouse hover on admin
            driver.FindElement(By.XPath("//a[@href='#admin-console-training']"));//click on training tab
            driver.FindElement(By.XPath("//a[contains(.,'Content Management')]"));//click on content mgt link
            driver.FindElement(By.XPath("//a[contains(.,'Tests')]"));//click on tests link
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify admin lands on tests page in new tab
            driver.FindElement(By.XPath("//option[contains(.,'Create New')]"));//select create new from drop down 
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify create new test page open
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_TITLE']"));//enter title as dv_test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_DESCRIPTION']"));//enter desc. as test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_KEYWORDS']"));//enter keywords as test
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//nobr[contains(.,'Edit Structure')]"));//verify user lands on edit structure tab
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewGroup']"));//select 'create new group' from drop down
            driver.FindElement(By.XPath("//input[@value='Go']"));//click on go
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_TITLE']"));//enter tittle as 'test'
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_DESCRIPTION']"));//enter desc as test
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_KEYWORDS']"));//enter keywords as test
            driver.FindElement(By.XPath("//input[contains(@id,'QUESTIONS')]"));//enter no. of question as 2
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.EditStructure']"));//click on edit structure link
            driver.FindElement(By.XPath("//td[@class=' firepath-matching-node']"));//verify that test should appear under title column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewTrueFalseQuestion']"));//click new true/false option from actiion
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));//click on go button
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']"));//enter question as 'sun rises from east?'
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TYPE_TRUEFALSE_VALUE_0']"));//click choice as yes
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create
            driver.FindElement(By.XPath("//span[@id='MainHeading']"));//verify our question appear on top as sun rises from east?
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The question was created.
            driver.FindElement(By.XPath("//a[@navigatingurl='TEST/MANAGEMENT/TESTEDITSTRUCTURE.ASPX']"));//click on edit structure link
            driver.FindElement(By.XPath("//td[@class=' firepath-matching-node']"));//verify that test should appear under title column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.NewMultipleChoiceQuestion']"));//click on new multiple choice from drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));//click go button
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']")); // enter quesiton as - Are you human?
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_QSTNCHC_TITLE']"));//enter choice as yes
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.AddChoice']"));//click on add choice button
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_QSTNCHC_TITLE']"));//enter choice as no
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.AddChoice']"));//click on add choice button
            driver.FindElement(By.XPath("//span[@id='TabMenu_ML_BASE_TAB_EditChoices_FeedbackTestQuestionChoices']"));//verify records found should be 2
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_TestQuestionChoices_ctl02_DataGridItem_Correct']"));//click on select checkbox
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditChoices_ML.BASE.BTN.Save']"));//click on save button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message that The choice(s) was updated. displayed
            driver.FindElement(By.XPath("//a[@navigatingurl='CONTENT/ADMINCONTENTSIMPLESEARCH.ASPX?strContentTypeId=ML.BASE.TEST']"));//click on test link on top
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));//enter text- dv_test 
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));//click on search button
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_Search_ID1_CONTENT1_1_0_F8A8C7D1FE404A0187F059E3031A06CA']"));//verify dv_test should appear in test search and click on it
            driver.FindElement(By.XPath("//a[contains(.,'Lock Test')]"));//click on lock test
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The test was locked. You may now use this test to publish one or more instances of the test (users may take the tests you publish).
            driver.FindElement(By.XPath("//a[contains(.,'Publish SCORM 2004')]"));//click on publish scorm 2004
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COURSE_TITLE']"));//edit tittle from dv_test to dv_test1
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MASTERY_SCORE']"));//enter mastery score as 100
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_SHOW_ALL_QUESTIONS']"));//select checkbox to show all question
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']"));//click on create button
            driver.FindElement(By.XPath("//span[@id='ReturnFeedback']"));//verify message - The published test was created.
            driver.FindElement(By.XPath("//span[contains(.,'Check In')]"));//click on checkin
            driver.FindElement(By.XPath("//span[contains(.,'Check Out')]"));//verify it become checkout
                                                                            //close the tab
            #endregion
            #region login-learner account
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learnerdv0");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region  Search Test and open test
            driver.FindElement(By.XPath("//input[contains(@id,'txtGlobalSearch')]"));// search text dv_test
            driver.FindElement(By.XPath("//button[@class='btn btn-default']"));//click on go
            driver.FindElement(By.XPath("//a[contains(.,'dv_test1')]"));//click on content item - dv_test
            driver.FindElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));//click on open button
                                                                                                                     //new window open
            driver.FindElement(By.XPath(".//*[@id='SCORMMenu_1']/span[3]/i//"));//click on title link of test
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[1]/table/tbody/tr/td[1]/font"));// verify question 1
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[1]/table/tbody/tr/td[1]/table/tbody/tr[1]/td[4]/label")); // verify question 1
            driver.FindElement(By.XPath(".//*[@id='q1c1']"));// select checkbox for option 
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[2]/table/tbody/tr/td[1]/font"));// verify Question 2
            driver.FindElement(By.XPath(".//*[@id='TestQuestionsContainer']/div[2]/table/tbody/tr/td[1]/table/tbody/tr[1]/td[3]/label"));// verify answer as true
            driver.FindElement(By.XPath(".//*[@id='q2true']"));// select checkbox for option 2
            driver.FindElement(By.XPath(".//*[@id='Submit']"));// click on submit button
            driver.FindElement(By.XPath(".//*[@id='ResultsContainer']/font[1]"));// verify success message as - )// Your score is 100%. You passed the exam.
            driver.FindElement(By.XPath(".//*[@id='Submit']"));// click on close button to close window
            driver.FindElement(By.XPath("//p[contains(.,'Success You completed this item on 4/26/2017.  View Details ')]"));//verify success message as  You completed this item on 4/26/2017.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region people search - View Certificate
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//search text as dv
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click go
            driver.FindElement(By.XPath("//a[contains(.,'First Name')]")); //first name column
            driver.FindElement(By.XPath("//td[contains(.,'dv')]"));//verify name in first name column
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.ViewTranscript']"));//select edit profile from drop down
            driver.FindElement(By.XPath("//a[@id='btnGo']"));//click on go
            driver.FindElement(By.XPath("//h1[contains(.,'User Transcript for dv singh')]"));//verify it display transcript of logged user dv1 sing
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]")); // Verify there is a breadcrumb to return to the Manage Users page
            driver.FindElement(By.XPath("//h1[contains(.,'dv singh')]"));// verify header indicator of user profile
            driver.FindElement(By.XPath("//th[contains(.,'             Action             ')]"));//action label
            driver.FindElement(By.XPath("//td[contains(.,'          dv_test1        ')]"));//verify content item
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.ViewCertificate']"));//verify mark complete option in dropdown and click on it
            driver.FindElement(By.XPath("//a[contains(@id,'btnGo')]"));//click on go
            //new window
            driver.FindElement(By.XPath("//span[@id='UserFullName']"));//verify user name in certificate
            driver.FindElement(By.XPath("//span[@id='ContentTitle']"));//verify content name should be dv_test1
            //close this window
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region Admin come back to people from Learner Transcript
            driver.FindElement(By.XPath("//a[contains(.,'Manage Users')]"));//click on manage user breadcrumb
            driver.FindElement(By.XPath("//h1[contains(.,'Manage Users')]"));//verify user come back on manage user page on people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));// verify create new account button on manage people page.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            Assert.Fail();
         }
         [Test,Order(15)]
         public void Create_New_Account_ManageUsers_6831()
         {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using siteadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region people search - Create new account
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//a[@id='MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser']"));//click on create an account for a new user
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']"));//enter user id as dvtestuser
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']"));//enter first name as dvtest
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']"));//enter last name as user
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_lnkSelectOrg']"));//click on select ogr. button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_txtSearch']"));//enter org as sample
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//td[contains(.,'Sample Organization 1')]"));//verify sample org 1
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));//click on radio button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']"));//click on save button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Create']"));//click on create button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//option[contains(.,'(GMT-05:00) Eastern Time (US and Canada)')]"));//set timezone as EST us and canada
            driver.FindElement(By.XPath("//option[contains(.,'English (United States)')]"));//select region as english united states
            driver.FindElement(By.XPath("//option[contains(.,'English (US)')]"));//select primary language as english
            driver.FindElement(By.XPath("//a[contains(@id,'lnkAddManager')]"));//click on select  manager button 
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_txtSearch']"));//enter text as dv 
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));//click search button
            driver.FindElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__1']/td[2])]"));//verify user dv singh
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl06_rbSelect']"));//click on radio button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']"));//click on save button
            driver.FindElement(By.XPath("//li[contains(.,'        dv singh          Remove    ')]"));//verify manager set as dv singh with remove link
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Cancel']"));//verify cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Create']"));//click on create button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            #endregion
            #region set password by login assistance
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//enter text as dvtest
            driver.FindElement(By.XPath("//td[contains(.,'dvtest')]"));//verify first name
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.LoginAssistance']"));//click on login assistance
            driver.FindElement(By.XPath("//strong[contains(.,'dvtestuser')]"));//verify login id
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on create button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify The user's temporary password is: 10AD16C0AD. Note: No email will be sent to the user.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login-learner account
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("dvtestuser");//using dvtestuser account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("10AD16C0AD");//enter password that created by login assistance i.e. 10AD16C0AD
                        driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_CurrentPassword']")); //enter current password 10AD16C0AD
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_USR_PASSWORD']"));//enter new pwd as password
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_ConfirmPassword']"));//enter confirm pwd as password
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify text message Your password was changed. Remember to use your new password the next time you log in.
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

            Assert.Fail();
         }
         [Test,Order(16)]
         public void User_Information_7996()
         {
            #region login-learner account
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("learnerdv");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region learner edit profile info
            driver.FindElement(By.XPath("//a[@id='lnkMyAccount']"));//click on account from right menu on top
            driver.FindElement(By.XPath("//a[contains(.,'     Profile')]"));//click on profile tab
            driver.FindElement(By.XPath("//a[contains(.,'Edit User Information')]"));//click on edit info button
            driver.FindElement(By.XPath("//span[contains(.,'User Information')]"));//verify popuo window title name
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_FIRST_NAME']"));//enter first name as dv
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_LAST_NAME']"));//enter last name as singh
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_EMAIL_ADDRESS']"));//enter email id as test @test.com
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_WORK_PHONE']"));//enter work pho. no. as 9865326562
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_WORK_PHONE_EXT']"));//enter ext as 123
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_HOME_PHONE']"));//enter home phone as 123456789
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_STREET_ADDRESS']"));// enter address as 123, park avenue street
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_CITY']"));//enter city as california
            driver.FindElement(By.XPath("//option[contains(.,'Washington')]"));//select state as washington
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_USR_POSTAL_CODE']"));//enter postal code as 16022
            driver.FindElement(By.XPath("//option[@value='US']"));//select country as united states
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify alert message
            driver.FindElement(By.XPath("//a[contains(.,'     Profile')]"));//click on profile tab
            driver.FindElement(By.XPath("//a[@id='MainContent_UCProfile_ucWorkInfo_lnkEdit']"));//click on edit work info button
            driver.FindElement(By.XPath("//span[contains(.,'Work Information')]"));//verify title name of popup window
            driver.FindElement(By.XPath("//a[contains(.,'Select Organization')]"));//click on seelct org. button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_txtSearch']"));//enter text as sample
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//td[contains(.,'Sample Organization 2')]"));//verify title name of organization
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect']"));//click on checkbox
            driver.FindElement(By.XPath("//input[@value='Done']"));//click on done button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify message
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_UC1_FormView1_rlvOrg_ctrl1_lnkMakeOrgPrimary']"));//click on make primary to make sample 2 org as primary
            driver.FindElement(By.XPath(".//*[@id='MainContent_UC1_pnlworkInfoEdit']/ul[1]/li[1]/ul/li[1]"));//verify primary text below sample org 2
            driver.FindElement(By.XPath("//a[contains(.,'Select Job Title')]"));//click on select job title button
            driver.FindElement(By.XPath("//span[contains(.,'Select Job Title')]"));//verify popuo window title
            driver.FindElement(By.XPath("//input[@value='Search']"));//click on search button
            driver.FindElement(By.XPath("//td[contains(.,'Training Seeker')]"));//verify title name 
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect']"));//click on checkbox
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']"));//click save
            //click on ok button of confirmation alert window
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//h3[contains(.,'Training Seeker')]"));//verify job title name 
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_FormView1_hladdMultiManager']"));//click on select manager button
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_txtSearch']"));//enter text as site
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//td[contains(.,'Administrator, Site')]"));//verify administrator,site in title column
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect']"));//click on checkbox
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify alert msg
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using siteadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            #region people search - User Information
            driver.FindElement(By.XPath("//a[contains(@href,'/Admin/ManageUsers/UserSimpleSearch.aspx')]"));//clicking people
            driver.FindElement(By.XPath("//input[@id='SEARCH_FOR']"));//search text as dv
            driver.FindElement(By.XPath("//button[@id='btnSearchClientSide']"));//click go
            driver.FindElement(By.XPath("//a[contains(.,'First Name')]")); //first name column
            driver.FindElement(By.XPath(".//*[@id='tableSearchUser']/tbody/tr[1]/td[3]"));//verify name in first name column as dv
            driver.FindElement(By.XPath(".//*[@id='tableSearchUser']/tbody/tr[1]/td[4]"));//verify job title as training seeker
            driver.FindElement(By.XPath("//span[contains(@class,'fa fa-info-circle fa-lg')]"));//click on info icon
            driver.FindElement(By.XPath("//span[contains(.,'Information')]"));//verify title name should be Information
            driver.FindElement(By.XPath("//h2[contains(.,'singh, dv')]"));//verify user name
            driver.FindElement(By.XPath("//strong[contains(.,'A1033AF6C3FD4A81A187F6ED1A1CA402')]"));//verify unique id, it's self system created i.e.  A1033AF6C3FD4A81A187F6ED1A1CA402
            driver.FindElement(By.XPath("//strong[contains(.,'test@test.com')]"));//veriy email id should be test@test.com
            driver.FindElement(By.XPath("//strong[contains(.,'9865326562')]"));//verify phone should be 9865326562
            driver.FindElement(By.XPath(".//*[@id='pnlContent']/div/ul/li[3]/div/div[2]"));//verify ext 123
            driver.FindElement(By.XPath("//strong[contains(.,'Training Seeker (Primary)')]"));//verify job tittle is training seeker
            driver.FindElement(By.XPath("//strong[contains(.,'Site Administrator (Primary)')]"));//veriy manager is site admin 
            driver.FindElement(By.XPath("//strong[contains(.,'Sample Organization 2 (Primary), Sample Organization 1')]"));//verify ogranizationn
            driver.FindElement(By.XPath("//strong[contains(.,'123, park avenue street')]"));//verify address is 123, park avenue street
            driver.FindElement(By.XPath("//strong[contains(.,'california')]"));//verify city is california
            driver.FindElement(By.XPath("//strong[contains(.,'Washington')]"));//verify us state is Washington
            driver.FindElement(By.XPath("//strong[contains(.,'UNITED STATES')]"));//verify country is United States
            driver.FindElement(By.XPath("//strong[contains(.,'16022')]"));//verify postal code is 16022
            driver.FindElement(By.XPath("//a[contains(.,'Close')]"));//click on X to close this window.

            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion

            Assert.Fail();
         }
         [Test,Order(17)]
         public void View_Pdf_Files_And_Notes_8995()
         {
             Assert.Fail();
         }
         [Test,Order(18)]
         public void View_Transcript_Edit_Access_Period_12057()
         {
             Assert.Fail();
         }
         [Test,Order(19)]
         public void Account_Changes_Domain_Seperation_Specific_13376()
         {
             Assert.Fail();
         }
         [Test,Order(20)]
         public void Cancel_Enrollment_14503()
         {
             Assert.Fail();
         }
         [Test,Order(21)]
         public void Cancel_Waitlist_14508()
         {
             Assert.Fail();
         }
         [Test,Order(22)]
         public void Login_Assistance_27526()
         {
             Assert.Fail();
         }
         [Test,Order(23)]
         public void Test_When_Admin_remove_Scope_of_Control_for_an_individual_user_28051()
         {
             Assert.Fail();
         }
         [Test,Order(24)]
         public void Test_to_see_people_search_result_display_on_the_basis_of_addition_scope_of_a_user_28820()
         {
             Assert.Fail();
         }
         [Test,Order(25)]
         public void Test_to_see_user_search_result_in_manage_enrollment_should_display_as_per_the_additional_scope_added_into_it_28821()
         {
             Assert.Fail();
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
