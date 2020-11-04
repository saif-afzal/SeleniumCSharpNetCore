using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class d_Document : TestBase
    {
        string browserstr = string.Empty;
        bool courseDocCreated = false;
        public d_Document(string browser)
            : base(browser)
        {
            browserstr = browser+"docs";
        }      
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
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
    
        [Test]
        public void Manage_Document_Files_7333()
        {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Manage>Training
            driver.FindElement(By.XPath("//a[@id='ManagerView']"));//mouse hover on manage
            driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            driver.FindElement(By.XPath("//h2[contains(.,'Manage Content')]"));//verify manage content section label
            driver.FindElement(By.XPath("//a[@href='../ContentSearch.aspx']"));//verify search&create content
            driver.FindElement(By.XPath("//a[@href='../Courseware/Classroom/ManageClassroomEnrollment.aspx']"));//verify manage enrollment for classroom coruse link
            driver.FindElement(By.XPath("//a[@href='../Courseware/Online/ManageOnlineEnrollment.aspx']"));//verify manage enrollment for online course
            driver.FindElement(By.XPath("//a[@href='../SkillSoftSearch.aspx']"));//verify import skilset coruse link
            driver.FindElement(By.XPath("//h2[contains(.,'Quick Links')]"));//veirfy quick link label
            driver.FindElement(By.XPath("//a[@href='../../AccessApprovals/AwaitingApprovalRequestsByDate.aspx']"));//verify approval requests link
            driver.FindElement(By.XPath("//a[contains(.,'Instructor Tools')]"));//verify instructor tool link
            driver.FindElement(By.XPath("//a[contains(.,'On-the-Job Training Tasks')]"));//verify OJT tasks link
            driver.FindElement(By.XPath("//h2[contains(.,'Content Created by Me')]"));//verify content created by me section label
            driver.FindElement(By.XPath("//h2[contains(.,'Most Recent Requests')]"));//verify most recent request section label
            driver.FindElement(By.XPath("//h2[contains(.,'Instructor Tools')]"));//verify instructor tools section label
            driver.FindElement(By.XPath("//h3[contains(.,'Teaching Schedule')]"));//verify teaching schedule section label
            driver.FindElement(By.XPath("//h2[contains(.,'On-the-Job Training Tasks')]"));//verify OJT training task section label
            driver.FindElement(By.XPath("//h2[contains(.,'Learner Interest')]"));//verify learner interest label
            driver.FindElement(By.XPath("//a[@href='../LearnerInterestList.aspx']"));//verify interest list for catalog link
            driver.FindElement(By.XPath("//a[@href='../ClassRoomInterestList.aspx']"));//verify interest list for classroom course link
            #endregion
            #region create new document with File

            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top
                                                                                                                                   //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            driver.FindElement(By.XPath("//input[@id='AsyncUpload1file0']"));//click on browse button to upload file
            //select and upload any file like pdf/doc file
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.FindElement(By.XPath("//p[contains(.,'  Current Document:     Certificate(3).pdf    ')]"));//verify file that we uploaded are saved and showing
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region search content
            driver.FindElement(By.XPath("//a[contains(.,'Search & Create Content')]"));//click on search and create content link
            driver.FindElement(By.XPath("//input[@id='CreatedBy']")); //verify create by me button
            driver.FindElement(By.XPath("//input[@id='ScheduledTo']"));//verify course im teaching button
            driver.FindElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']"));//enter text as dv
            driver.FindElement(By.XPath("//input[@id='btnSearchCourses']"));//click on search button
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl3_lnkDetails']")); //verify dv_doc1 coming in result
            driver.FindElement(By.XPath("//strong[contains(.,'Document')]"));//verify content type should be document
            driver.FindElement(By.XPath("//h3[contains(.,'Categories')]"));//verify catagories in left panel
            driver.FindElement(By.XPath("//h3[contains(.,'Content Type')]"));//verify content type label in left panel
            driver.FindElement(By.XPath("//h3[contains(.,'Cost')]"));//veriy cost in left pane
            driver.FindElement(By.XPath("//h3[contains(.,'Duration (Hours)')]"));//verify duration in left pane
            driver.FindElement(By.XPath(".//*[@id='CostFacet']/h3"));//verify ratings in left pane
            driver.FindElement(By.XPath("//h3[contains(.,'Course Provider')]"));//verify cost provider in left pane.
            #endregion
            #region document detail page-admin
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl3_lnkDetails']"));//click on dv_doc1 
            driver.FindElement(By.XPath("//h1[contains(.,'     DV_Doc1  More Information   ')]"));//verify user lands on detail page by checking dv_doc1 label name
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify checkin/checkout button
            driver.FindElement(By.XPath("//span[contains(.,'        More Information       ')]"));//click on information icon
            driver.FindElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));//verify window tittle is information
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));//verify delete link 
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnViewCatalog']"));//verify view as learner link
            driver.FindElement(By.XPath("//li[contains(.,'Title: DV_Doc1')]"));//verify tittle name 
            driver.FindElement(By.XPath("//li[contains(.,'Keywords: ')]"));//verify keywords
            driver.FindElement(By.XPath("//li[contains(.,'Description: ')]"));//veriy description
            driver.FindElement(By.XPath("//li[contains(.,'Search Priority: ')]"));//veridy search priority
            driver.FindElement(By.XPath("//h3[contains(.,'Document')]"));//verify document accorodian for file or ulr
            driver.FindElement(By.XPath("//h3[contains(.,'Cost & Sales Tax')]"));//verify cost and sales tax accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Categories')]"));//veridy catagories accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Prerequisites')]"));//verify prerequisites accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Equivalencies')]"));//verify equivalencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Competencies')]"));//verify competencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Content Sharing')]"));//verify content sharing accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Permissions')]"));//verify permissions accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Image')]"));//verify image accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Manage Activity')]"));//verify manage activity accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Window')]"));//verify window accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Mobile Settings')]"));//verify mobile settings accordian
            #endregion
            #region Manage Document file
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//click on checkout buttn to edit this doc
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify button status become checkin
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucDocument_lnkEdit']"));//click on edit button for docuemnt file change
            driver.FindElement(By.XPath("//input[@id='AsyncUpload1file0']"));//verify file upload option
            driver.FindElement(By.XPath("//input[@id='AsyncUpload1file0']"));//click on browse button to upload file
            //select and upload any file like pdf/doc file
            driver.FindElement(By.XPath("//span[@class='ruUploadProgress ruUploadSuccess']"));//verify that file is uploaded
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));//verify back button
            driver.FindElement(By.XPath("//input[@value='Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//p[contains(.,'  Current Document:     Certificate(3).pdf    ')]"));//verify file that we uploaded are saved and showing
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify it changes to checkout
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test]
        public void Select_Categories_workflow_7335()
        {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Manage>Training
            driver.FindElement(By.XPath("//a[@id='ManagerView']"));//mouse hover on manage
            driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            driver.FindElement(By.XPath("//h2[contains(.,'Manage Content')]"));//verify manage content section label
            driver.FindElement(By.XPath("//a[@href='../ContentSearch.aspx']"));//verify search&create content
            driver.FindElement(By.XPath("//a[@href='../Courseware/Classroom/ManageClassroomEnrollment.aspx']"));//verify manage enrollment for classroom coruse link
            driver.FindElement(By.XPath("//a[@href='../Courseware/Online/ManageOnlineEnrollment.aspx']"));//verify manage enrollment for online course
            driver.FindElement(By.XPath("//a[@href='../SkillSoftSearch.aspx']"));//verify import skilset coruse link
            driver.FindElement(By.XPath("//h2[contains(.,'Quick Links')]"));//veirfy quick link label
            driver.FindElement(By.XPath("//a[@href='../../AccessApprovals/AwaitingApprovalRequestsByDate.aspx']"));//verify approval requests link
            driver.FindElement(By.XPath("//a[contains(.,'Instructor Tools')]"));//verify instructor tool link
            driver.FindElement(By.XPath("//a[contains(.,'On-the-Job Training Tasks')]"));//verify OJT tasks link
            driver.FindElement(By.XPath("//h2[contains(.,'Content Created by Me')]"));//verify content created by me section label
            driver.FindElement(By.XPath("//h2[contains(.,'Most Recent Requests')]"));//verify most recent request section label
            driver.FindElement(By.XPath("//h2[contains(.,'Instructor Tools')]"));//verify instructor tools section label
            driver.FindElement(By.XPath("//h3[contains(.,'Teaching Schedule')]"));//verify teaching schedule section label
            driver.FindElement(By.XPath("//h2[contains(.,'On-the-Job Training Tasks')]"));//verify OJT training task section label
            driver.FindElement(By.XPath("//h2[contains(.,'Learner Interest')]"));//verify learner interest label
            driver.FindElement(By.XPath("//a[@href='../LearnerInterestList.aspx']"));//verify interest list for catalog link
            driver.FindElement(By.XPath("//a[@href='../ClassRoomInterestList.aspx']"));//verify interest list for classroom course link
            #endregion
            #region create new document with File

            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top
                                                                                                                                   //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            driver.FindElement(By.XPath("//input[@id='AsyncUpload1file0']"));//click on browse button to upload file
            //select and upload any file like pdf/doc file
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.FindElement(By.XPath("//p[contains(.,'  Current Document:     Certificate(3).pdf    ')]"));//verify file that we uploaded are saved and showing
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region document detail page-admin
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl3_lnkDetails']"));//click on dv_doc1 
            driver.FindElement(By.XPath("//h1[contains(.,'     DV_Doc1  More Information   ')]"));//verify user lands on detail page by checking dv_doc1 label name
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify checkin/checkout button
            driver.FindElement(By.XPath("//span[contains(.,'        More Information       ')]"));//click on information icon
            driver.FindElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));//verify window tittle is information
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));//verify delete link 
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnViewCatalog']"));//verify view as learner link
            driver.FindElement(By.XPath("//li[contains(.,'Title: DV_Doc1')]"));//verify tittle name 
            driver.FindElement(By.XPath("//li[contains(.,'Keywords: ')]"));//verify keywords
            driver.FindElement(By.XPath("//li[contains(.,'Description: ')]"));//veriy description
            driver.FindElement(By.XPath("//li[contains(.,'Search Priority: ')]"));//veridy search priority
            driver.FindElement(By.XPath("//h3[contains(.,'Document')]"));//verify document accorodian for file or ulr
            driver.FindElement(By.XPath("//h3[contains(.,'Cost & Sales Tax')]"));//verify cost and sales tax accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Categories')]"));//veridy catagories accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Prerequisites')]"));//verify prerequisites accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Equivalencies')]"));//verify equivalencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Competencies')]"));//verify competencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Content Sharing')]"));//verify content sharing accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Permissions')]"));//verify permissions accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Image')]"));//verify image accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Manage Activity')]"));//verify manage activity accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Window')]"));//verify window accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Mobile Settings')]"));//verify mobile settings accordian
            #endregion
            #region select catagories
            //Create catagory is prerequisite to select any catagories for content
            driver.FindElement(By.XPath("//h3[contains(.,'Categories')]"));//verify catagories accordian
            driver.FindElement(By.XPath("//p[contains(.,'1 Assigned Categories')]"));//verify if any catagoreis is already assing to this file
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//click on checkout buttn to edit this doc
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify button status become checkin
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCategories_lnkEdit']"));//click on edit button for catagories
            driver.FindElement(By.XPath("//span[contains(.,'cat0401304830anybrowser')]"));//verify catagory name in list
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_ucCategories_tvCategories']/ul/li/ul/li[1]/div/input"));//click on checkbox to select this cat.
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucCategories_btnCancel']"));//verify back button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucCategories_btnSave']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify sucess message
            driver.FindElement(By.XPath("//span[contains(.,'cat0401304830anybrowser')]"));//verify selected catagories is displayed in catagoreis section
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify it changes to checkout
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test]
        public void Document_Cost_7336()
        {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Manage>Training
            driver.FindElement(By.XPath("//a[@id='ManagerView']"));//mouse hover on manage
            driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            driver.FindElement(By.XPath("//h2[contains(.,'Manage Content')]"));//verify manage content section label
            driver.FindElement(By.XPath("//a[@href='../ContentSearch.aspx']"));//verify search&create content
            driver.FindElement(By.XPath("//a[@href='../Courseware/Classroom/ManageClassroomEnrollment.aspx']"));//verify manage enrollment for classroom coruse link
            driver.FindElement(By.XPath("//a[@href='../Courseware/Online/ManageOnlineEnrollment.aspx']"));//verify manage enrollment for online course
            driver.FindElement(By.XPath("//a[@href='../SkillSoftSearch.aspx']"));//verify import skilset coruse link
            driver.FindElement(By.XPath("//h2[contains(.,'Quick Links')]"));//veirfy quick link label
            driver.FindElement(By.XPath("//a[@href='../../AccessApprovals/AwaitingApprovalRequestsByDate.aspx']"));//verify approval requests link
            driver.FindElement(By.XPath("//a[contains(.,'Instructor Tools')]"));//verify instructor tool link
            driver.FindElement(By.XPath("//a[contains(.,'On-the-Job Training Tasks')]"));//verify OJT tasks link
            driver.FindElement(By.XPath("//h2[contains(.,'Content Created by Me')]"));//verify content created by me section label
            driver.FindElement(By.XPath("//h2[contains(.,'Most Recent Requests')]"));//verify most recent request section label
            driver.FindElement(By.XPath("//h2[contains(.,'Instructor Tools')]"));//verify instructor tools section label
            driver.FindElement(By.XPath("//h3[contains(.,'Teaching Schedule')]"));//verify teaching schedule section label
            driver.FindElement(By.XPath("//h2[contains(.,'On-the-Job Training Tasks')]"));//verify OJT training task section label
            driver.FindElement(By.XPath("//h2[contains(.,'Learner Interest')]"));//verify learner interest label
            driver.FindElement(By.XPath("//a[@href='../LearnerInterestList.aspx']"));//verify interest list for catalog link
            driver.FindElement(By.XPath("//a[@href='../ClassRoomInterestList.aspx']"));//verify interest list for classroom course link
            #endregion
            #region create new document with File

            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top
                                                                                                                                   //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            driver.FindElement(By.XPath("//input[@id='AsyncUpload1file0']"));//click on browse button to upload file
            //select and upload any file like pdf/doc file
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.FindElement(By.XPath("//p[contains(.,'  Current Document:     Certificate(3).pdf    ')]"));//verify file that we uploaded are saved and showing
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region document detail page-admin
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl3_lnkDetails']"));//click on dv_doc1 
            driver.FindElement(By.XPath("//h1[contains(.,'     DV_Doc1  More Information   ')]"));//verify user lands on detail page by checking dv_doc1 label name
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify checkin/checkout button
            driver.FindElement(By.XPath("//span[contains(.,'        More Information       ')]"));//click on information icon
            driver.FindElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));//verify window tittle is information
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));//verify delete link 
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnViewCatalog']"));//verify view as learner link
            driver.FindElement(By.XPath("//li[contains(.,'Title: DV_Doc1')]"));//verify tittle name 
            driver.FindElement(By.XPath("//li[contains(.,'Keywords: ')]"));//verify keywords
            driver.FindElement(By.XPath("//li[contains(.,'Description: ')]"));//veriy description
            driver.FindElement(By.XPath("//li[contains(.,'Search Priority: ')]"));//veridy search priority
            driver.FindElement(By.XPath("//h3[contains(.,'Document')]"));//verify document accorodian for file or ulr
            driver.FindElement(By.XPath("//h3[contains(.,'Cost & Sales Tax')]"));//verify cost and sales tax accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Categories')]"));//veridy catagories accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Prerequisites')]"));//verify prerequisites accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Equivalencies')]"));//verify equivalencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Competencies')]"));//verify competencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Content Sharing')]"));//verify content sharing accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Permissions')]"));//verify permissions accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Image')]"));//verify image accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Manage Activity')]"));//verify manage activity accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Window')]"));//verify window accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Mobile Settings')]"));//verify mobile settings accordian
            #endregion
            #region edit cost
            driver.FindElement(By.XPath("//h3[contains(.,'Cost & Sales Tax')]"));//verify cost accordian
            driver.FindElement(By.XPath("//p[contains(.,'Default Cost: $0.00 with 0 Alternate Cost(s) and 0 Pricing Schedule(s)')]"));//verify cost value including other costs
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//click on checkout buttn to edit this doc
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify button status become checkin
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));//click on edit button for cost accordian
            driver.FindElement(By.XPath("//h2[contains(.,'Costs')]"));//verify cost page displayed, verify cost label
            driver.FindElement(By.XPath("//h1[contains(.,'    DV_Doc1       More Information  ')]"));//verify document tittle name
            driver.FindElement(By.XPath("//h3[contains(.,'Manage Sales Tax')]"));//verify sales tax section if it's enabled
            driver.FindElement(By.XPath("//h3[contains(.,'Default Cost')]"));//verify default cost section label
            driver.FindElement(By.XPath("//h3[contains(.,'Alternate Costs')]"));//verify alternate costs label
            driver.FindElement(By.XPath("//h3[contains(.,'Pricing Schedules')]"));//verify pricing schedule label [if Pricing Schedules is on]
            driver.FindElement(By.XPath("//label[@id='MainContent_MainContent_UC1_lblTaxCat']"));//verify tax item cat.[only if Tax Item = Yes]
            driver.FindElement(By.XPath("//label[@for='ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']"));//verify default cost label
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']"));//verify search for text box
            driver.FindElement(By.XPath("//select[contains(@id,'ddlSearchType')]"));//verify search type dropdown
            driver.FindElement(By.XPath("//select[contains(@id,'MainContent_MainContent_UC1_ddlEntityType')]"));//verify type drop down
            driver.FindElement(By.XPath("//select[@id='MainContent_MainContent_UC1_DM_USER_SEARCH_ID']"));//verify user search dropdown
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));//verify search button 
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkClear']"));//verify clear search button
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkCostAdd']"));//verify add more user/group button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtPricingSearchFor']"));//verify search for text box of pricing schedule
            driver.FindElement(By.XPath("//select[@id='MainContent_MainContent_UC1_ddlPricingSearchType']"));//verify search type drop down
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnPricingSearch']"));//verify filter button
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkPricingClear']"));//verify clear filter button
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnAddNew']"));//verify add pricing schedule button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']"));//enter default cost as 10
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//input[@value='10.00']"));//verify cost is added and showing as 10.00
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));//click on back button
            driver.FindElement(By.XPath("//h1[contains(.,'        DV_Doc1       More Information      ')]"));//verify user bring back on admin-content detail page
            driver.FindElement(By.XPath("//p[contains(.,'Default Cost: $10.00 with 0 Alternate Cost(s) and 0 Pricing Schedule(s)')]"));//verify cost is coming in cost acordian as 10.00
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify it changes to checkout
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test]
        public void Document_Alternate_Cost_7337()
        {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Manage>Training
            driver.FindElement(By.XPath("//a[@id='ManagerView']"));//mouse hover on manage
            driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            driver.FindElement(By.XPath("//h2[contains(.,'Manage Content')]"));//verify manage content section label
            driver.FindElement(By.XPath("//a[@href='../ContentSearch.aspx']"));//verify search&create content
            driver.FindElement(By.XPath("//a[@href='../Courseware/Classroom/ManageClassroomEnrollment.aspx']"));//verify manage enrollment for classroom coruse link
            driver.FindElement(By.XPath("//a[@href='../Courseware/Online/ManageOnlineEnrollment.aspx']"));//verify manage enrollment for online course
            driver.FindElement(By.XPath("//a[@href='../SkillSoftSearch.aspx']"));//verify import skilset coruse link
            driver.FindElement(By.XPath("//h2[contains(.,'Quick Links')]"));//veirfy quick link label
            driver.FindElement(By.XPath("//a[@href='../../AccessApprovals/AwaitingApprovalRequestsByDate.aspx']"));//verify approval requests link
            driver.FindElement(By.XPath("//a[contains(.,'Instructor Tools')]"));//verify instructor tool link
            driver.FindElement(By.XPath("//a[contains(.,'On-the-Job Training Tasks')]"));//verify OJT tasks link
            driver.FindElement(By.XPath("//h2[contains(.,'Content Created by Me')]"));//verify content created by me section label
            driver.FindElement(By.XPath("//h2[contains(.,'Most Recent Requests')]"));//verify most recent request section label
            driver.FindElement(By.XPath("//h2[contains(.,'Instructor Tools')]"));//verify instructor tools section label
            driver.FindElement(By.XPath("//h3[contains(.,'Teaching Schedule')]"));//verify teaching schedule section label
            driver.FindElement(By.XPath("//h2[contains(.,'On-the-Job Training Tasks')]"));//verify OJT training task section label
            driver.FindElement(By.XPath("//h2[contains(.,'Learner Interest')]"));//verify learner interest label
            driver.FindElement(By.XPath("//a[@href='../LearnerInterestList.aspx']"));//verify interest list for catalog link
            driver.FindElement(By.XPath("//a[@href='../ClassRoomInterestList.aspx']"));//verify interest list for classroom course link
            #endregion
            #region create new document with File

            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top
                                                                                                                                   //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            driver.FindElement(By.XPath("//input[@id='AsyncUpload1file0']"));//click on browse button to upload file
            //select and upload any file like pdf/doc file
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.FindElement(By.XPath("//p[contains(.,'  Current Document:     Certificate(3).pdf    ')]"));//verify file that we uploaded are saved and showing
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region document detail page-admin
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl3_lnkDetails']"));//click on dv_doc1 
            driver.FindElement(By.XPath("//h1[contains(.,'     DV_Doc1  More Information   ')]"));//verify user lands on detail page by checking dv_doc1 label name
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify checkin/checkout button
            driver.FindElement(By.XPath("//span[contains(.,'        More Information       ')]"));//click on information icon
            driver.FindElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));//verify window tittle is information
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));//verify delete link 
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnViewCatalog']"));//verify view as learner link
            driver.FindElement(By.XPath("//li[contains(.,'Title: DV_Doc1')]"));//verify tittle name 
            driver.FindElement(By.XPath("//li[contains(.,'Keywords: ')]"));//verify keywords
            driver.FindElement(By.XPath("//li[contains(.,'Description: ')]"));//veriy description
            driver.FindElement(By.XPath("//li[contains(.,'Search Priority: ')]"));//veridy search priority
            driver.FindElement(By.XPath("//h3[contains(.,'Document')]"));//verify document accorodian for file or ulr
            driver.FindElement(By.XPath("//h3[contains(.,'Cost & Sales Tax')]"));//verify cost and sales tax accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Categories')]"));//veridy catagories accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Prerequisites')]"));//verify prerequisites accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Equivalencies')]"));//verify equivalencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Competencies')]"));//verify competencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Content Sharing')]"));//verify content sharing accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Permissions')]"));//verify permissions accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Image')]"));//verify image accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Manage Activity')]"));//verify manage activity accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Window')]"));//verify window accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Mobile Settings')]"));//verify mobile settings accordian
            #endregion
            #region add alternate cost
            driver.FindElement(By.XPath("//h3[contains(.,'Cost & Sales Tax')]"));//verify cost accordian
            driver.FindElement(By.XPath("//p[contains(.,'Default Cost: $0.00 with 0 Alternate Cost(s) and 0 Pricing Schedule(s)')]"));//verify cost value including other costs
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//click on checkout buttn to edit this doc
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify button status become checkin
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));//click on edit button for cost accordian
            driver.FindElement(By.XPath("//h2[contains(.,'Costs')]"));//verify cost page displayed, verify cost label
            driver.FindElement(By.XPath("//h1[contains(.,'    DV_Doc1       More Information  ')]"));//verify document tittle name
            driver.FindElement(By.XPath("//h3[contains(.,'Alternate Costs')]"));//verify alternate costs label
            driver.FindElement(By.XPath("//label[@for='ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']"));//verify default cost label
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']"));//verify search for text box
            driver.FindElement(By.XPath("//select[contains(@id,'ddlSearchType')]"));//verify search type dropdown
            driver.FindElement(By.XPath("//select[contains(@id,'MainContent_MainContent_UC1_ddlEntityType')]"));//verify type drop down
            driver.FindElement(By.XPath("//select[@id='MainContent_MainContent_UC1_DM_USER_SEARCH_ID']"));//verify user search dropdown
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));//verify search button 
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkClear']"));//verify clear search button
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkCostAdd']"));//click on add more user/group button
            driver.FindElement(By.XPath("//h2[contains(.,'Add Alternate Costs')]"));//verify Add alternate cost label
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']"));//verify search for text box, enter dv
            driver.FindElement(By.XPath("//option[@value='ML.BASE.DV.SearchExactPhrase']"));//select search type as exact phrase
            driver.FindElement(By.XPath("//option[@value='User']"));//select type as user
            driver.FindElement(By.XPath("//option[@value='ML.BASE.DV.UserSearch.ThisDomainOnly']"));//seelct user serch as this domain only
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));//click on search button
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00__0']/td[1]"));// verify tittle column value ase singh.dv
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00__0']/td[2]"));//verify user value in type column
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST']"));//enter cost as 10 for this record
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_MImageButton2']/span"));//verify info icon for this record
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']"));//click on add button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success msg
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST']"));//verify cost should be 10$
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_chkSelect']"));//select checkbox for record
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']"));//click on remove button
            //confrimation msg, click on ok
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify that The entities and alternate costs were removed. should appear
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00']/tbody/tr/td/span"));//verify that record deleted 
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkCostAdd']"));//click on add more user/group button
            driver.FindElement(By.XPath("//h2[contains(.,'Add Alternate Costs')]"));//verify Add alternate cost label
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']"));//verify search for text box, enter dv
            driver.FindElement(By.XPath("//option[@value='ML.BASE.DV.SearchExactPhrase']"));//select search type as exact phrase
            driver.FindElement(By.XPath("//option[@value='User']"));//select type as user
            driver.FindElement(By.XPath("//option[@value='ML.BASE.DV.UserSearch.ThisDomainOnly']"));//seelct user serch as this domain only
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));//click on search button
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00__0']/td[1]"));// verify tittle column value ase singh.dv
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00__0']/td[2]"));//verify user value in type column
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST']"));//enter cost as 10 for this record
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_MImageButton2']/span"));//verify info icon for this record
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']"));//click on add button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success msg
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST']"));//verify cost should be 10$
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success message
            driver.FindElement(By.XPath("//input[@value='10.00']"));//verify cost is added and showing as 10.00
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));//click on back button
            driver.FindElement(By.XPath("//h1[contains(.,'        DV_Doc1       More Information      ')]"));//verify user bring back on admin-content detail page
            driver.FindElement(By.XPath("//p[contains(.,'Default Cost: $0.00 with 1 Alternate Cost(s) and 0 Pricing Schedule(s)')]"));//verify cost is coming in cost acordian with 1 alternative cost
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]"));//click on checkin button
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify it changes to checkout
            #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion
        }
        [Test]
        public void Document_Document_Prerequisites_7338()
        {
            #region login admin
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Manage>Training
            driver.FindElement(By.XPath("//a[@id='ManagerView']"));//mouse hover on manage
            driver.FindElement(By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));//click on training
            driver.FindElement(By.XPath("//h2[contains(.,'Manage Content')]"));//verify manage content section label
            driver.FindElement(By.XPath("//a[@href='../ContentSearch.aspx']"));//verify search&create content
            driver.FindElement(By.XPath("//a[@href='../Courseware/Classroom/ManageClassroomEnrollment.aspx']"));//verify manage enrollment for classroom coruse link
            driver.FindElement(By.XPath("//a[@href='../Courseware/Online/ManageOnlineEnrollment.aspx']"));//verify manage enrollment for online course
            driver.FindElement(By.XPath("//a[@href='../SkillSoftSearch.aspx']"));//verify import skilset coruse link
            driver.FindElement(By.XPath("//h2[contains(.,'Quick Links')]"));//veirfy quick link label
            driver.FindElement(By.XPath("//a[@href='../../AccessApprovals/AwaitingApprovalRequestsByDate.aspx']"));//verify approval requests link
            driver.FindElement(By.XPath("//a[contains(.,'Instructor Tools')]"));//verify instructor tool link
            driver.FindElement(By.XPath("//a[contains(.,'On-the-Job Training Tasks')]"));//verify OJT tasks link
            driver.FindElement(By.XPath("//h2[contains(.,'Content Created by Me')]"));//verify content created by me section label
            driver.FindElement(By.XPath("//h2[contains(.,'Most Recent Requests')]"));//verify most recent request section label
            driver.FindElement(By.XPath("//h2[contains(.,'Instructor Tools')]"));//verify instructor tools section label
            driver.FindElement(By.XPath("//h3[contains(.,'Teaching Schedule')]"));//verify teaching schedule section label
            driver.FindElement(By.XPath("//h2[contains(.,'On-the-Job Training Tasks')]"));//verify OJT training task section label
            driver.FindElement(By.XPath("//h2[contains(.,'Learner Interest')]"));//verify learner interest label
            driver.FindElement(By.XPath("//a[@href='../LearnerInterestList.aspx']"));//verify interest list for catalog link
            driver.FindElement(By.XPath("//a[@href='../ClassRoomInterestList.aspx']"));//verify interest list for classroom course link
            #endregion
            #region create new document with File

            driver.HoverLinkClick(By.XPath("//button[contains(.,'Create')]"), By.XPath("//a[@href='/Admin/CreateDocument.aspx']"));// mouse hover on create link on top
                                                                                                                                   //driver.FindElement(By.XPath("//a[@href='/Admin/CreateDocument.aspx']")); // click on document
            Assert.IsTrue(driver.existsElement(By.XPath("//h1[contains(., 'Create New Document')]"))); // verify document page
            driver.FindElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("dv_doc" + Meridian_Common.globalnum); // enter title = dv_doc20-04
            driver.FindElement(By.XPath("//input[@id='AsyncUpload1file0']"));//click on browse button to upload file
            //select and upload any file like pdf/doc file
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace(); //click on create
            StringAssert.AreEqualIgnoringCase("The item was created.", driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text);// successful message on document creation
            driver.FindElement(By.XPath("//p[contains(.,'  Current Document:     Certificate(3).pdf    ')]"));//verify file that we uploaded are saved and showing
            driver.FindElement(By.XPath("//a[contains(.,'Check-in')]")).ClickWithSpace();//click on checkin button.
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'Checkout')]")));//verify button change to checkout after checkin
            #endregion
            #region document detail page-admin
            driver.FindElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl3_lnkDetails']"));//click on dv_doc1 
            driver.FindElement(By.XPath("//h1[contains(.,'     DV_Doc1  More Information   ')]"));//verify user lands on detail page by checking dv_doc1 label name
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify checkin/checkout button
            driver.FindElement(By.XPath("//span[contains(.,'        More Information       ')]"));//click on information icon
            driver.FindElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));//verify window tittle is information
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));//verify delete link 
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnViewCatalog']"));//verify view as learner link
            driver.FindElement(By.XPath("//li[contains(.,'Title: DV_Doc1')]"));//verify tittle name 
            driver.FindElement(By.XPath("//li[contains(.,'Keywords: ')]"));//verify keywords
            driver.FindElement(By.XPath("//li[contains(.,'Description: ')]"));//veriy description
            driver.FindElement(By.XPath("//li[contains(.,'Search Priority: ')]"));//veridy search priority
            driver.FindElement(By.XPath("//h3[contains(.,'Document')]"));//verify document accorodian for file or ulr
            driver.FindElement(By.XPath("//h3[contains(.,'Cost & Sales Tax')]"));//verify cost and sales tax accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Categories')]"));//veridy catagories accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Prerequisites')]"));//verify prerequisites accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Equivalencies')]"));//verify equivalencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Competencies')]"));//verify competencies accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Content Sharing')]"));//verify content sharing accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Permissions')]"));//verify permissions accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Image')]"));//verify image accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Manage Activity')]"));//verify manage activity accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Window')]"));//verify window accordian
            driver.FindElement(By.XPath("//h3[contains(.,'Mobile Settings')]"));//verify mobile settings accordian
            #endregion
            #region Add Prerequisites
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']")); //click on checkout button
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify it changes to checkin
            driver.FindElement(By.XPath("//h3[contains(.,'Prerequisites')]"));//verify prerequiste label
            driver.FindElement(By.XPath("//p[contains(.,'No prerequisites are currently assigned.')]"));//verify no item is set as prereq.
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));//click on edit button
            driver.FindElement(By.XPath("//h2[contains(.,'Prerequisites')]"));//verify prerequisite label on new page
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkClear']"));//verify clear filter button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));//verify filter button
            driver.FindElement(By.XPath("//p[contains(.,'No prerequisites are currently assigned.')]"));//verify no prereq. is being assinged text
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));//verofy back button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));//verify save button
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']"));//click on add prereq. button
            driver.FindElement(By.XPath("//h2[contains(.,'Add Prerequisites')]"));//verify labell
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']"));//enter text as dv
            driver.FindElement(By.XPath("//option[@value='ML.BASE.DV.SearchStartsWith']"));//select value as starts with
            driver.FindElement(By.XPath("//option[@value='ML.BASE.COURSEWARE.ONLINE']"));//select content type as online
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));//click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect']"));//check mark first record
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl06_chkSelect']"));//check marck second record
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00']/thead/tr/th[2]/a"));//verify column name title
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00']/thead/tr/th[3]/a"));//verify type column
            driver.FindElement(By.XPath("//th[contains(.,'Valid Period')]"));//verify valid period column
            driver.FindElement(By.XPath("//th[contains(.,'Target Score')]"));//verify target score colu,mn
            driver.FindElement(By.XPath("//th[@class='rgHeader rgHeaderOver']"));//verify info column
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));//verify back button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']"));//click on add button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify success msg
            driver.FindElement(By.XPath("//td[contains(.,'                 DV_2404         ')]"));//verify records after saving
            driver.FindElement(By.XPath("//td[contains(.,'           dv_gc20 / 04       ')]"));//verify records
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl07_chkSelect']"));//select check box for dv_gc20/04 
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']"));//click on remove button
            //popup confirmation message and click on ok
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));//verify message
            driver.FindElement(By.XPath("//td[contains(.,'                 DV_2404         ')]"));//verify records after saving is only 1 as we have removed another
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));//click on save button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));//click on back button
            driver.FindElement(By.XPath("//h1[contains(.,'            DV_Doc1       More Information     ')]"));//user bring back on admin detail page
            driver.FindElement(By.XPath("//p[contains(.,'1 Assigned Prerequisites')]"));//verify that 1 prereq. has been added 
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']")); //click on checkin button
            driver.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));//verify it changes to checkout
                        #endregion
            #region logout
            driver.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/Logout.aspx']"));//mouse hover
            #endregion


        }
        [Test]
        public void Document_Mobile_Settings_7346()
        {

        }
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
        //[Test]
        //public void Document_Mobile_Settings_7346()
        //{

        //}
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
