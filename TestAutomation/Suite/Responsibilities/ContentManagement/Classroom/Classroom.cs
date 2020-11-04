using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
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
  public  class b_ClassroomCourse : TestBase
    {
        string browserstr = string.Empty;
        public b_ClassroomCourse(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        bool sectioncreation = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }

        [SetUp]
        public void starttest()
        {
            classroomcourse = new ClassroomCourse(driver);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin",browserstr);
            }
            Meridian_Common.islog = false;
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
            //    driver.Navigate_to_TrainingHome();
            }
        }
        [Test, Order(1)]
        public void Create_Classroom_Course_14061()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion

            //Login with admin account and move to Manage > Training > Click search & Create Content
            driver.FindElement(By.XPath("//a[contains(.,'Search & Create Content')]"));
            driver.FindElement(By.XPath("//select[@id='MainContent_ucSearchTop_ddlCreateNew']"));
            driver.FindElement(By.XPath("//option[contains(.,'Classroom Course')]"));
            driver.FindElement(By.XPath("//input[@id='MainContent_ucSearchTop_btnCreateNew']"));

            #region Create Classroom Course
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")); //enter title
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")); //click save/create button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); //verify success message
            driver.FindElement(By.XPath("//h1[contains(.,'SS Classroom 04 / 20 / 17 More Information')]")); //verify course title
            //search for above created course in catalog
            driver.FindElement(By.XPath("//input[@id='MainContent_ucSearchLanding_txtSearchFor']")); //enter title
            driver.FindElement(By.XPath("//span[@class='fa fa-lg fa-search']")); //click search button
            driver.FindElement(By.XPath("//a[contains(.,'SS Classroom 04/20/17')]")); //verify content display in search detail.
            //goto my responsibility 
            driver.FindElement(By.XPath("//a[contains(.,'SS Classroom 04/20/17')]")); //verify content display in content created by me portlet
            #endregion

            #region logout
            driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));//click logout
            #endregion

            Assert.Fail();

        }
        [Test, Order(2)]
        public void Manage_Classroom_Course_26747()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            //Login with admin account and move to Manage > Training > Click search & Create Content
            driver.FindElement(By.XPath("//a[contains(.,'Search & Create Content')]"));
            driver.FindElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']")); //enter title of course
            driver.FindElement(By.XPath("//input[@id='btnSearchCourses']")); // click on search button  
            driver.FindElement(By.XPath("//a[contains(.,'SS Classroom 04/20/17')]")); //click on content title from search result
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']")); //click on edit button for summary
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE']")); // update the title
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); //click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); //verify success message
            #region logout
            driver.FindElement(By.XPath("//a[contains(.,'Logout')]"));//click logout
            #endregion

            Assert.Fail();
        }
        [Test, Order(3)]
        public void Classroom_Course_Course_Information_26749()
        {


            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseInfo_lnkEdit']")); //click edit button for classroom course information
            driver.FindElement(By.XPath("//h2[contains(.,'Course Information')]")); //verify correct page open
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSW_NUMBER']")); // enter data
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            Assert.Fail();

        }
        [Test, Order(4)]
        public void Classroom_Course_Cost_26750()
        {
            //default cost
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']")); // click edit for cost
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")); //enter default cost
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); //click save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify feedback message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click return button

            //alternate cost
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']")); // click edit for cost
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkCostAdd']")); // click add more user / group button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // select type user and perform blank search
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST']")); // enter cost for first search result
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']")); // click add button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); //verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // return button click
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST']")); // enter cost for alternate cost
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); //verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click return button

            // remove alternate cost
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']")); // click edit for cost
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_chkSelect']")); // select checkbox for alternate cost
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")); // click remove button // click on OK for JS popup
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); //verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click return button

            Assert.Fail();

        }

        [Test, Order(5)]
        public void Classroom_Course_Categories_26751()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCategories_lnkEdit']")); // click edit for categories
            driver.FindElement(By.XPath("//input[@class='rtChk']")); // selecr the checkbox of any category
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucCategories_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            Assert.Fail();
        }

        [Test, Order(6)]
        public void Classroom_Course_Prerequisites_26752()
        {
            //add prerequisite
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']")); // click edit for prerrquisites
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']")); // click on add button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // perform blank search
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect']")); // select first checkbox item of search result
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']")); // click on add button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click return button

            // mamage user for content.

            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']")); // click edit for prerrquisites
            driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_btnEditUsers']")); // click on yes manage user button
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkGroupsAdd']")); // click on add user/group
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button perform blank search
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgUsers_ctl00_ctl04_chkSelect']")); // select checkbox of first user under search result
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']")); // click on add/save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on return button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgUsers_ctl00_ctl04_chkSelect']")); // select checkbox of added user/group
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")); // click on remove button. click on ok for JS popup
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on return button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_CNTPRE_MIN_SCORE']")); // enter score of content.
            driver.FindElement(By.XPath("//input[@class='btn btn-primary pull-right']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            // remove prerequisite
           
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect']")); // select checkbox of added item
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")); // click remove button. also click on ok for JS popup
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on return button

            Assert.Fail();
        }

        [Test, Order(7)]
        public void Create_Classroom_Equivalencies_26753()
        {
            // add equivalencies
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucEquivalencies_lnkEdit']")); // Click on edit button for equivalencies
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']")); // click on add equiva;encies button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect']")); // select first content checkbox
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']")); // click on add button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            // Manage User for content
            driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_btnEditUsers']")); // click on Yes- manage User
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkGroupsAdd']")); // click on add user/group
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgUsers_ctl00_ctl04_chkSelect']")); // select checkbox for first user / group
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']")); // click on add button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on return button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgUsers_ctl00_ctl04_chkSelect']")); // select checkbox for added user/group
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")); // click on remove button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            
            // remove content
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on back button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on filter
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect']")); // select checkbox for first content.
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")); // click on remove button // click on OK for JS popup
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on return button

            Assert.Fail();
            
        }
       
        [Test, Order(8)]
        public void Classroom_Course_Competencies_24916()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucAllignedComptency_lnkEdit']")); // click on edit for compitencies
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnMapContent']")); // click on map compitencies
            driver.FindElement(By.XPath("//input[@id='btnSearch']")); // click on search button
            // if there is data select one and continue, if there is no data click on back button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnReturn']")); // click on return / back
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnReturn']")); // again click on return / back

            Assert.Fail();
        }
        [Test, Order(9)]
        public void Classroom_Course_Certificate_16298()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucCertificate_lnkEdit']")); // click on edit button for certificate
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_btnChangeCertificate']")); // click on change certificate
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']")); // select radio button first
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button // select OK for JS popup
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click return / back button
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_btnRemove']")); // click on remove button // click ok for JS popup
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success messgae
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click return / back button

            Assert.Fail();

        }

        [Test, Order(10)]
        public void Classroom_Course_Access_Approval_26755()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']")); // click on edit button for access approval
            driver.FindElement(By.XPath("//input[@value='Y']")); // select radio button option YES
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']")); // click on radio button for first approval path
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            Assert.Fail();
        }

        [Test, Order(11)]
        public void Classroom_Course_Learner_Interest_14257()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucLearnerInterest_lnkEdit']")); // click on edit button for learner interest
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtThresh']")); // enter a value from 1 to 5
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_MButton1']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click return / back button

            Assert.Fail();
        }
        [Test, Order(12)]
        public void Classroom_Course_Content_Sharing_26756()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']")); // click on edit button for content sharing
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkAllDomains']")); // click on all domai toggle
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToPublicCatalog']")); // select public catalog checkbox 
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToAllDomains']")); // select checkbox share content with all domain
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC2_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            Assert.Fail();

        }
        [Test, Order(13)]
        public void Classroom_Course_Permission_26757()
        {
            driver.FindElement(By.XPath("//a[contains(@id,'MHyperLink1')]")); // click on edit button for permission.
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkCostAdd']")); // click on assign permission button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl04_chkView']")); // select 'View' chdckbox for first search result item
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on return / back button

            Assert.Fail();
        }
        [Test, Order(14)]
        public void Classroom_Course_Image_26758()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucImage_lnkEdit']")); // click on edit button for image
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_AsyncUpload1file0']")); // click on browse button and add the image path.
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save once image path has been set
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            Assert.Fail();
        }
   
        [Test, Order(15)]
        public void Classroom_Course_Activity_26759()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucActivity_lnkEdit']")); // click on edit button for image
            driver.FindElement(By.XPath("//input[@value='F']")); // select false / inactive radio button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucActivity_lnkEdit']")); // click on edit button for image
            driver.FindElement(By.XPath("//input[@value='T']")); // select true radio button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            Assert.Fail();
        }
        [Test, Order(16)]
        public void Classroom_Course_Mobile_Settings_26760()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucMobile_lnkEdit']")); // click on edit button for mobile setting
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message

            Assert.Fail();
        }
        [Test, Order(17)] // Can not be automate
        public void Classroom_Course_Edit_System_Events_14063()
        {
            

        }
        [Test, Order(18)]
        public void Classroom_Course_Multiple_Credits_15836()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC5_hlManage']")); // click on manage button for multiple credit
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnAddNew']")); // click on add credit button4
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue']")); // enter a value e.g. 5 into first line item
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on return / back button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_chkRemove']")); // select checkbox for first item
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")); // click on remove button // click on OK for JS popup
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on back button

            Assert.Fail();

        }
        [Test, Order(19)]
        public void Classroom_Course_Info_Icon_16328()
        {
            driver.FindElement(By.XPath("//span[@class='fa fa-info-circle text-info']")); // click on info icon // frame will open
            driver.FindElement(By.XPath("//h2[contains(.,'SS Classroom 04/20/17')]")); // verify content name should display. Content will be dynamic which will be fetch from excel
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_MLinkButton11']"));// click on tab category
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_lnkPermissions']")); // click on tab permission
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_lnkContentDomain']")); // click on domain sharing
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_MLinkButton46']")); // click on prereuisite
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_MLinkButton56']")); // click on equivalenices
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_lnkContentAssociation']")); // click on content associated

            Assert.Fail();

        }
        [Test, Order(20)]
        public void Classroom_Course_Survey_16745()
        {
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']")); // click on manage button for survey
            driver.FindElement(By.XPath("//h2[contains(.,'Surveys')]")); // Verify survey page open
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAssignSurveys']")); // Click on add survey button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("xpath=(//a[contains(@href, '#')])[31]")); // Click on link of survey which display in search result
            driver.FindElement(By.XPath("//span[@id='MainHeading']")); // Verify a Popup window should open of survey 
            // Close the popup window and switch to default content
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect']")); // select first checkbox of search result
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // Verify success message            
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect']")); // select the first checkbox of search result
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")); // click on remove button // click on ok button for popup window
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on back button

            Assert.Fail();

        }
        [Test, Order(21)]
        public void Create_Classroom_Section_1823()
        {
            #region Create New Section
            driver.FindElement(By.XPath("//a[@id='MainContent_hlScheduling']")); // Click on manage section tab
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//h2[contains(.,'Create New Course Section and Event')]")); // verify create new section page open
            driver.FindElement(By.XPath("//p[contains(.,'Create a new course section and the first event for the classroom course by completing the form below.')]")); // verify instrcution text should display.
            driver.FindElement(By.XPath("//h1[contains(.,'SS Classroom 04/20/17 More Information')]")); // verify classroom title should display.
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_FORMAT_0']")); // verify radio button exist and selected
            driver.FindElement(By.XPath("//input[@value='F']")); // verify radio button exist and selected as NO
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_TITLE']")); // enter section title "Section 1"
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']")); // click on next button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput']")); // enter start date
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput']")); // enter end datae
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput']")); // enter start time
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput']")); // enter end date
            driver.FindElement(By.XPath("//p[contains(.,'No location selected.')]")); // verify no location selected message appear
            driver.FindElement(By.XPath("//p[contains(.,'No instructor selected.')]")); // verify instructor message should display
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY']")); // enter capacity min
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY']")); // enter capacity max
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkEnrollInfo']")); // click on change button for enrollment 
            //switch to frame
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput']")); // enter enrollment start date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput']")); // enter enrollment end date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput']")); // enter enorllment start time
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput']")); // enter enrollment end time
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")); // click on save button
            // switch to default content
            driver.FindElement(By.XPath("//input[contains(@id,'MainContent_MainContent_UC1_FormView1_CRSSECT_COLLABORATION_SPACE_0')]")); // verify radio button should exist and disable for collaboration space
            driver.FindElement(By.XPath("//input[@name='ctl00$ctl00$MainContent$MainContent$UC1$btnAddEvent']")); // verifu add antoher event button should display
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")); // verify success message

            #endregion

            #region Add Another Event
            driver.FindElement(By.XPath("//a[@id='MainContent_hlScheduling']")); // Click on manage section tab
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//h2[contains(.,'Create New Course Section and Event')]")); // verify create new section page open
            driver.FindElement(By.XPath("//p[contains(.,'Create a new course section and the first event for the classroom course by completing the form below.')]")); // verify instrcution text should display.
            driver.FindElement(By.XPath("//h1[contains(.,'SS Classroom 04/20/17 More Information')]")); // verify classroom title should display.
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_FORMAT_0']")); // verify radio button exist and selected
            driver.FindElement(By.XPath("//input[@value='F']")); // verify radio button exist and selected as NO
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_TITLE']")); // enter section title "Section 1"
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']")); // click on next button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput']")); // enter start date
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput']")); // enter end datae
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput']")); // enter start time
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput']")); // enter end date
            driver.FindElement(By.XPath("//p[contains(.,'No location selected.')]")); // verify no location selected message appear
            driver.FindElement(By.XPath("//p[contains(.,'No instructor selected.')]")); // verify instructor message should display
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY']")); // enter capacity min
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY']")); // enter capacity max
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkEnrollInfo']")); // click on change button for enrollment 
            //switch to frame
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput']")); // enter enrollment start date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput']")); // enter enrollment end date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput']")); // enter enorllment start time
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput']")); // enter enrollment end time
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")); // click on save button
            // switch to default content
            driver.FindElement(By.XPath("//input[contains(@id,'MainContent_MainContent_UC1_FormView1_CRSSECT_COLLABORATION_SPACE_0')]")); // verify radio button should exist and disable for collaboration space
            driver.FindElement(By.XPath("//input[@name='ctl00$ctl00$MainContent$MainContent$UC1$btnAddEvent']")); // click on add another event button
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")); // verify success message
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_EVT_TITLE']")); // enter event title
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']")); // click on next button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_EVT_START_DATE_dateInput']"));
            // Note : Give dates and time below under section start & end date time
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput']")); // enter start date
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput']")); // enter end datae
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput']")); // enter start time
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput']")); // enter end date
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")); // verify success message
            #endregion

            #region Create Section with Recurrence,Location,Instructor,Notes

            driver.FindElement(By.XPath("//a[@id='MainContent_hlScheduling']")); // Click on manage section tab
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//h2[contains(.,'Create New Course Section and Event')]")); // verify create new section page open
            driver.FindElement(By.XPath("//p[contains(.,'Create a new course section and the first event for the classroom course by completing the form below.')]")); // verify instrcution text should display.
            driver.FindElement(By.XPath("//h1[contains(.,'SS Classroom 04/20/17 More Information')]")); // verify classroom title should display.
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_FORMAT_0']")); // verify radio button exist and selected
            driver.FindElement(By.XPath("//input[@value='F']")); // verify radio button exist and selected as NO
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_TITLE']")); // enter section title "Section 1"
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']")); // click on next button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput']")); // enter start date
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput']")); // enter end datae
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput']")); // enter start time
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput']")); // enter end date
            driver.FindElement(By.XPath("//p[contains(.,'No location selected.')]")); // verify no location selected message appear
            driver.FindElement(By.XPath("//p[contains(.,'No instructor selected.')]")); // verify instructor message should display
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY']")); // enter capacity min
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY']")); // enter capacity max
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkEnrollInfo']")); // click on change button for enrollment 
            //switch to frame
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput']")); // enter enrollment start date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput']")); // enter enrollment end date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput']")); // enter enorllment start time
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput']")); // enter enrollment end time
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")); // click on save button
            // switch to default content
            driver.FindElement(By.XPath("//input[contains(@id,'MainContent_MainContent_UC1_FormView1_CRSSECT_COLLABORATION_SPACE_0')]")); // verify radio button should exist and disable for collaboration space
            driver.FindElement(By.XPath("//input[@name='ctl00$ctl00$MainContent$MainContent$UC1$btnAddEvent']")); // verifu add antoher event button should display
            #region Set Location
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkSelectLoc']")); // click on select location
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect']")); // select radio button for first item
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            #endregion
            #region Set Instructor
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkSelectInst']")); // click on add instructor
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']")); // click on search button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_SectionInstructorSearch_ctl00_ctl04_chkSelect']")); // select checkbox for first instructor of search result
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify succes message

            #endregion
            #region Set Recurrence
            driver.FindElement(By.XPath("//a[contains(@id,'MainContent_MainContent_UC1_FormView1_lnkEChangeRecur')]")); // click on change button for recurrence
            driver.FindElement(By.XPath("//p[contains(.,'Make selections that allow the course section or event to occur repeatedly (recurrence).')]")); // Verify recurrence page open or not
            driver.FindElement(By.XPath("//option[contains(.,'Annually')]")); // select annually option
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_EVT_RECURRENCE_END_DATE_dateInput']")); // enter next year date
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")); // click on save button
            #endregion
            #region Set Notes
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkComments']")); // click on change button for notes
            driver.FindElement(By.XPath("//textarea[@id='MainContent_UC1_FormView1_EVT_PRE_ENRL_COMMENT']")); // enter notes
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")); // click on save button
            #endregion
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")); // verify success message

            #endregion


        }
        [Test, Order(22)]
        public void Classroom_Section_Edit_26761()
        {
            #region Manage Section
            driver.FindElement(By.XPath("//a[contains(.,'Section 1')]")); // click on first section title
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_FormView1_lnkEdit']")); // click on edit button for section
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));
            #endregion
        }
        [Test, Order(23)]
        public void Create_Classroom_Event_1989()
        {
            #region Create Event for existing section
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucSectionEvents_lbEdit']")); // click on edit button for event
            driver.FindElement(By.XPath("//a[contains(@id,'MainContent_MainContent_UC1_lnkAddEvent')]")); // click on add event button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_EVT_TITLE']")); // enter title
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']")); // click on Next button
            // dates should be within section start date and end date which we created in above test case
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput']")); // enter start date
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput']")); // enter end datae
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput']")); // enter start time
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput']")); // enter end date
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")); // verify success message
            #endregion

        
        }

        [Test, Order(24)]
        public void Classroom_Calendar_View_24916()
        {
            #region Calendar view
            driver.FindElement(By.XPath("//a[contains(.,'Schedule & Manage Sections')]")); // click on breadcrum link
            driver.FindElement(By.XPath("//a[contains(.,'Schedule & Manage Sections')]")); // Click on calender view button
            driver.FindElement(By.XPath("//a[@aria-describedby='tooltip925249']")); // click on link from calender
            //OR // User any one locator
            driver.FindElement(By.XPath("//a[contains(.,'12:30am Section 1')]")); // click on link from calender, Parameterization for section title.
            // Switch to frame
            driver.FindElement(By.XPath("//a[@id='MainContent_UC1_btnMoreInformation']")); // click on More Information button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); // verify success message
            #endregion
        }

        [Test, Order(25)]
        public void To_Test_System_Should_Update_The_Time_And_Date_When_A_Section_Is_Updated_16073()
        {
            #region Update Section
            //Move to Manage > Training > Click search & Create Content
            driver.FindElement(By.XPath("//a[contains(.,'Search & Create Content')]"));
            driver.FindElement(By.XPath("//select[@id='MainContent_ucSearchTop_ddlCreateNew']"));
            driver.FindElement(By.XPath("//option[contains(.,'Classroom Course')]"));
            driver.FindElement(By.XPath("//input[@id='MainContent_ucSearchTop_btnCreateNew']"));
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")); //enter title
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")); //click save/create button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']")); //verify success message
            #region Create New Section
            driver.FindElement(By.XPath("//a[@id='MainContent_hlScheduling']")); // Click on manage section tab
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//h2[contains(.,'Create New Course Section and Event')]")); // verify create new section page open
            driver.FindElement(By.XPath("//p[contains(.,'Create a new course section and the first event for the classroom course by completing the form below.')]")); // verify instrcution text should display.
            driver.FindElement(By.XPath("//h1[contains(.,'SS Classroom 04/20/17 More Information')]")); // verify classroom title should display.
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_FORMAT_0']")); // verify radio button exist and selected
            driver.FindElement(By.XPath("//input[@value='F']")); // verify radio button exist and selected as NO
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']")); // click on cancel button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_ucTopBar_btnAddNewSection']")); // click on add new section button
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_TITLE']")); // enter section title "Section 1"
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']")); // click on next button
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput']")); // enter start date
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput']")); // enter end datae
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput']")); // enter start time
            driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput']")); // enter end date
            driver.FindElement(By.XPath("//p[contains(.,'No location selected.')]")); // verify no location selected message appear
            driver.FindElement(By.XPath("//p[contains(.,'No instructor selected.')]")); // verify instructor message should display
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY']")); // enter capacity min
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY']")); // enter capacity max
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_UC1_FormView1_lnkEnrollInfo']")); // click on change button for enrollment 
            //switch to frame
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput']")); // enter enrollment start date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput']")); // enter enrollment end date
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput']")); // enter enorllment start time
            driver.FindElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput']")); // enter enrollment end time
            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_Save']")); // click on save button
            // switch to default content
            driver.FindElement(By.XPath("//input[contains(@id,'MainContent_MainContent_UC1_FormView1_CRSSECT_COLLABORATION_SPACE_0')]")); // verify radio button should exist and disable for collaboration space
            driver.FindElement(By.XPath("//input[@name='ctl00$ctl00$MainContent$MainContent$UC1$btnAddEvent']")); // verifu add antoher event button should display
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]")); // verify success message

            #endregion
            
            driver.FindElement(By.XPath("//a[contains(.,'Section 1')]")); // click on first section title which we created in above steps
            driver.FindElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_FormView1_lnkEdit']")); // click on edit button for section
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_EVT_TITLE']")); // Clear the text
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_EVT_TITLE']")); // enter new title edited
            driver.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']")); // click on save button
            driver.FindElement(By.XPath("//div[@class='alert alert-success']"));
            #endregion

        }

        [Test, Order(26)] // Can not be automate as its related to email
        public void As_a_user_who_can_manage_a_course_section_I_want_the_option_of_sending_an_update_email_when_I_am_updating_an_event_23516()
        {



        }

        [Test, Order(27)]
        public void Connectors_Create_and_Launch_New_Virtual_Classroom_Course_using_Connectors_17206()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//logging in
            driver.FindElement(By.XPath("//input[@id='username']"));//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']"));
            driver.FindElement(By.XPath("//input[@type='submit']"));
            #endregion
            // navigate to administration > training > content configuration > Virtual meeting connector
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]")); // Mouse Hover
            driver.FindElement(By.XPath("//a[@href='#admin-console-training']")); // Click on Training
            driver.FindElement(By.XPath("//a[@aria-controls='admin-console-contentPanel']")); // Click on content configuration
            driver.FindElement(By.XPath("//a[contains(.,'Virtual Meeting Connectors')]")); // click on Virtual Meeting connectors

            #region Setup Goto meeting
            driver.FindElement(By.XPath("//a[@class='button primary']")); // click on add connection button // if this button exist only then click on it
            driver.FindElement(By.XPath("//a[contains(.,'GoToMeeting')]")); // click on goto meeting link
            driver.FindElement(By.XPath("//input[@id='ctl09_gtm_username']")); // enter username as 'dkutty@meridianks.com'
            driver.FindElement(By.XPath("//input[@id='ctl09_gtm_password']")); // enter password as 'Password@1'
            driver.FindElement(By.XPath("//input[@id='ctl09_gtm_clientid']")); // enter client id as 'bFCCJMFhIUtSCZFZE2pJyW4OgBEGPpk6'
            driver.FindElement(By.XPath("//input[@id='2737D4C075C741A0B9A95994294AFF40']")); // select checkbox for goto meeting audio
            driver.FindElement(By.XPath("//input[@id='5B542F3B4B6E4EE3A6EFBB8D9CE2E761']")); // select checkbox for other tele option
            driver.FindElement(By.XPath("//input[@id='ctl09_btnValidate']")); // click on validate button


            #endregion


        }

        //[Test, Order(28)]
        //public void Classroom_Calender_View_249161()
        //{



        //}

        //[Test, Order(29)]
        //public void Classroom_Calender_View_24916()
        //{



        //}

        [Test, Order(30)]
        public void View_As_Learner_Classroom_27989()
        {



        }

        [Test, Order(31)]
        public void Classroom_Section_Expand_28080()
        {



        }

       

        


    }
}
