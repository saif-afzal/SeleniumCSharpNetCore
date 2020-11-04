using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using OpenQA.Selenium.Firefox;
namespace Selenium2.Meridian.Suite.P1.MyResponsibilities.Training
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DocumentsP1 : TestBase
    {
        string browserstr = string.Empty;
        bool courseCreated = false;
        public DocumentsP1(string browser)
            : base(browser)
        {
            browserstr = browser;
}
       
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
           // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
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
        }
        #region Titans_Team_UploadedScormCourse
      //  //[Test]
        public void A_As_a_content_administrator_able_to_preview_my_uploaded_Scorm_CreateCourse_7251()
        {
            MyResponsibilitiesobj.ValidateResponsibilityPageComplete_SharedSteps7623();
            MyResponsibilitiesobj.Click_Traning();
            scormobj.Goto_CreateSCORMPage();
            scormobj.ValidateContentSearch_SCORMCreate_Complete_SharedSteps7276();
            driver.navigateAICCfile("\\Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            scormobj.buttoncreateclick(driver, true);
            scormobj.ValidateContentSearch_SCORMEditSummary_Complete_SharedSteps7276();
            scormobj.populatesummaryform(driver, browserstr);
            courseCreated = true;
            scormobj.buttonsaveclick(driver);
          Assert.IsTrue(scormobj.ValidatePreviewButton());
        }
   //     //[Test]
        public void B_As_a_content_administrator_able_to_preview_my_uploaded_Scorm_SearchCourse_7253()
        {
            if (!courseCreated) { scormobj.CreateSCORMCourse(browserstr); courseCreated = true; }
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, "");
            MyResponsibilitiesobj.ValidateSearch_ScormCourse_SharedSteps_7252();
            classroomcourse.buttoncontentsearchclick();
            driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")).Click();
            MyResponsibilitiesobj.ValidateSearch_CourseDetails_ScormCourse_SharedSteps_7252();
          Assert.IsTrue(scormobj.ValidatePreviewButton());
        }
      //  //[Test]
        public void C_As_a_content_administrator_able_to_preview_my_uploaded_Scorm_ManageCourse_7278()
        {
            scormobj.ManageScormCourse(browserstr);
       Assert.IsTrue(scormobj.ValidatePreviewButton());
        }
        #endregion
        //[Test, Order(1)]
        public void A_Create_Document_7285()
        {
            Assert.IsTrue(documentobj.createDocument(browserstr));
            
        }
     
    //    //[Test]
        public void B_Manage_Document_Files_7333()
        {
            
        }
       //[Test, Order(2)]
        public void C_Manage_Document_7334()
        {
            Assert.IsTrue(documentobj.manageDocument(browserstr));
        }
        //[Test, Order(3)]
        public void D_Document_Categories_7335()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
         //   driver.Checkout();

            Assert.IsTrue(Scorm1_2obj.setCategory());
        }
        //[Test, Order(4)]
        public void E_Document_Cost_7336()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setCost());
        }

        //[Test, Order(5)]
        public void F_Document_AlternateCost_7337()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setAlternateCost());
        }

        //[Test, Order(6)]
        public void G_Document_Prerequisites_7338()
        {
            Assert.Ignore("Cannot be Automated");
        }

        //[Test, Order(7)]
        public void H_Document_Equivalencies_7339()
        {
            Assert.Fail("Not Automated");
        }

        //[Test, Order(8)]
        public void I_Document_Access_Approval_7340()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            documentobj.editApprovalEnable();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(Scorm1_2obj.verifyApprovalPath(browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
            Assert.IsTrue(documentobj.editApprovalDiable());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(Scorm1_2obj.verifyApprovalPathAfterRemoval(ExtractDataExcel.MasterDic_document["Title"] + browserstr, browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
        }

        //[Test, Order(9)]
        public void Z_Document_Content_Sharing_7341()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            Assert.IsTrue(documentobj.shareDocument(browserstr));

        }

        //[Test, Order(10)]
        public void Z_Document_Permissions_7342()
        {
            Assert.Fail("Not Automated");
        }
        //[Test, Order(11)]
        public void Z_Document_Image_7343()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            Assert.IsTrue(documentobj.sètImage(browserstr));
        }
        //[Test, Order(12)]
        public void Z_Document_Activity_7344()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            Assert.IsTrue(documentobj.editActivityMarkInactive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityInactive(browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
            Assert.IsTrue(documentobj.editActivityMarkActive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityactive(ExtractDataExcel.MasterDic_document["Title"] + browserstr, browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.Checkout();
        }
        //[Test, Order(13)]
        public void Z_Document_Window_Attributes_7345()
        {
            Assert.Ignore("Cannot be Automated");
        }
        //[Test, Order(14)]
        public void Z_Document_Mobile_Settings_7346()
        {
            Assert.Ignore("Cannot be Automated");   
        }
        //[Test, Order(15)]
        public void Z_Delete_Dcoument_From_Creating_Domain_7435()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
            driver.findandacceptalert();
            if (!driver.IsElementVisible(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]")))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
            
        }
    }
}
