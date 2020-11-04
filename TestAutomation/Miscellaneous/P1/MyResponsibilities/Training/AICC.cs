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
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class AICC : TestBase
    {
        string browserstr = string.Empty;
        bool courseCreated = false;
        public AICC(string browser)
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
        //[Test]
        public void A_Create_A_New_SCORM_Course_7251()
        {
            Document documentpage = new Document(driver);
          //  driver.UserLogin("admin", browserstr);
            string expectedresult = "Edit Summary";
            string expectedresult1 = "The course was created.";
            Scorm12 CreateScorm = new Scorm12(driver);
            CreateScorm.linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Scorm_CourseClick);
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver, true);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
          Assert.IsTrue(driver.existsElement(ObjectRepository.sucessmessage));
           
            CreateScorm.populatesummaryform(driver, browserstr);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
        }
     
        //[Test]
        public void B_Manage_A_SCORM_Course_7253()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentpage.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            string expectedresult = "The changes were saved.";
            //driver.GetElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr);
            //driver.ClickEleJs(By.XPath("//input[@id='btnSearchCourses']"));
            //driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            //driver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            driver.Checkout();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE"));
            //if (!driver.existsElement(By.Id("Editor")))
            //{
            //    driver.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeysWithSpace("updating scenario");
            //}
            //else

            //{
            //    driver.GetElement(By.Id("Editor")).Clear();
            //}
            driver.GetElement(By.XPath("//textarea[@class='form-control']")).SendKeysWithSpace(" (updating scenario)");
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        }
       //[Test]
        public void C_Manage_Scorm_Course_File_7278()
        {

            Assert.IsTrue(Scorm1_2obj.manageScormCourseFile());
               
        }
        //[Test]
        public void D_Manage_Scorm_Course_Setting_7279()
        {
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            driver.Checkin();
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn-dropdown']/li[1]/a"));
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, "Exact phrase");
            driver.clicktableresult(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton']")).ClickWithSpace();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnCourseEnroll']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnCourseEnroll']")).ClickWithSpace();
            Thread.Sleep(5000);
            driver.SwitchtoDefaultContent();
            Thread.Sleep(5000);
            driver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']")).ClickWithSpace();
            Thread.Sleep(5000);
            Thread.Sleep(5000);
            driver.selectWindow("Meridian Global - Core Domain");
        //    Assert.IsFalse(driver.existsElement(By.Id("Exit")));
            Thread.Sleep(5000);
            driver.SelectWindowClose2("Meridian Global - Core Domain", "Details");
            Thread.Sleep(5000);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
        }
        //[Test]
        public void E_Scorm_Course_Category_7257()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();

            Assert.IsTrue(Scorm1_2obj.setCategory());
        }

        //[Test]
        public void F_Scorm_Course_Cost_7258()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
           
            Assert.IsTrue(Scorm1_2obj.setCost());
        }

        //[Test]
        public void G_Scorm_Course_Alternate_Cost_7259()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setAlternateCost());
        }
        //[Test]
        public void H_Scorm_Course_Prerequisites_7260()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test]
        public void Scorm_Course_Equivalencies_7262()
        {
            Assert.Fail("Need to be automated");

        }
        //[Test]
        public void H_Scorm_Course_Approval_Path_7263()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            documentobj.editApprovalEnable();

            Assert.IsTrue(Scorm1_2obj.verifyApprovalPath(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, browserstr));

            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();

            Assert.IsTrue(documentobj.editApprovalDiable());
            Assert.IsTrue(Scorm1_2obj.verifyApprovalPathAfterRemoval(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, browserstr));

            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();

        }
        //[Test]
        public void H_Scorm_Course_Content_Sharing_7264()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(documentobj.shareDocument(browserstr));
        }
        //[Test]
        public void H_Scorm_Course_Permissions_7265()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test]
        public void H_Scorm_Course_Image_7266()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(documentobj.sètImage(browserstr));
        }
        //[Test]
        public void H_Scorm_Course_Activity_7267()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(documentobj.editActivityMarkInactive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityInactive(browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();
            Assert.IsTrue(documentobj.editActivityMarkActive());
            Assert.IsTrue(Scorm1_2obj.verifyActivityactive(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, browserstr));
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.Checkout();
        }
     
        //[Test] //Cannot be automated
        public void H_Scorm_Course_WindowAttributes_7268()
        {
            Assert.Ignore("Cannot be automated");
        }
        //[Test] //CaNNOT BE Automated
        public void H_Scorm_Course_MobilesSettings_7269()
        {
            Assert.Ignore("Cannot be automated");
        }
        //[Test]
        public void I_Scorm_Course_Certificate_7283()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);

            Assert.IsTrue(Scorm1_2obj.setCertificate(browserstr));

        }
        //[Test]
        public void H_Scorm_Course_Surveys_7284()
        {
            Assert.IsTrue(objCurriculum.curriculumSurvey("", browserstr));
        }
        //[Test]
        public void H_Scorm_Course_Information_7357()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(Scorm1_2obj.checkInfoIcon(browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));
        }
        //[Test]
        public void Z_Delete_A_SCORM_Course_7438()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//div[@class='alert alert-success']")));

        }
        //[Test]
        public void H_Scorm_Course_Add_Locale_7453()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test]
        public void H_Scorm_Course_Delete_Locale_7454()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test,Category("P2")]
        public void ScormInfo_Icon_16332()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test,Category("P2")]
        public void H_Scorm_Multiple_Credits_15835()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test,Category("P2")]
        public void SCORM_Course_Content_Sharing_Un_push_26903()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test,Category("P2")]
        public void View_as_Learner_SCORM_27996()
        {
            Assert.Fail("Need to be automated");
        }
    }
}
