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
namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class g_ScormCourse : TestBase
    {
        string browserstr = string.Empty;
        bool courseCreated = false;
        public g_ScormCourse(string browser)
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
        [Test]
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
        [Test]
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
        [Test]
        public void C_As_a_content_administrator_able_to_preview_my_uploaded_Scorm_ManageCourse_7278()
        {
            scormobj.ManageScormCourse(browserstr);
       Assert.IsTrue(scormobj.ValidatePreviewButton());
        }
        #endregion
        [Test]
        public void f119_Create_a_new_SCORM_course()
        {
            Document documentpage = new Document(driver);
          //  driver.UserLogin("admin", browserstr);
            string expectedresult = "Edit Summary";
            string expectedresult1 = "The course was created.";
            Scorm12 CreateScorm = new Scorm12(driver);
            CreateScorm.linkmyresponsibilitiesclick();
            documentpage.tabcontentmanagementclick();
            documentpage.buttoncoursecreationgoclick("SCORM");
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver, true);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
          Assert.IsTrue(driver.WaitForElement(ObjectRepository.sucessmessage));
           
            CreateScorm.populatesummaryform(driver, browserstr);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
        }
      // [Test]
        public void f120_Conduct_a_simple_and_advanced_search_for_a_SCORM_course()
        {
            Document documentpage = new Document(driver);
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "");
            Assert.IsTrue(classroomcourse.buttoncontentsearchclick(),"Simple search worked");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.populatecontentsearchadvance("SCORM", ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "");
            Assert.IsTrue(classroomcourse.buttoncontentsearchclick(),"Advance search worked");
        }
        [Test]
        public void f121_Manage_a_SCORM_course()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentpage.tabcontentmanagementclick();
            string expectedresult = "The changes were saved.";
            driver.GetElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr);
            driver.GetElement(By.XPath("//input[@id='btnSearchCourses']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']")).ClickWithSpace();
            driver.Checkout();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']")).ClickWithSpace();
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE"));
            if (!driver.existsElement(By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")))
            {
                driver.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeysWithSpace("updating scenario");
            }
            else
            {
                driver.GetElement(By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            }
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        }
     //  [Test]
        public void f122_Edit_the_Course_Files_for_a_SCORM_course()
        {
            
        }
        [Test]
        public void f123_Edit_the_Course_Settings_for_a_SCORM_1_2_course()
        {
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
            driver.Checkin();
            driver.GetElement(By.Id("lbUserView")).ClickWithSpace();
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
            Assert.IsFalse(driver.existsElement(By.Id("Exit")));
            Thread.Sleep(5000);
            driver.SelectWindowClose2("Meridian Global - Core Domain", "Details");
            Thread.Sleep(5000);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
        }
        [Test]
        public void f124_Assign_required_training_to_a_SCORM_course()
        {
            Scorm12 AssignScorm = new Scorm12(driver);
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsAccordian("Required Training");
            TrainingHomeobj.click_systemOptionsLink("Training Assignments");
            Assert.IsTrue(requiredtrainingobj.AssigntrainingCourse(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, ExtractDataExcel.MasterDic_admin["Firstname"]));
            driver.Navigate_to_TrainingHome();
        }
        [Test]
        public void f125_Assign_a_survey_to_a_SCORM_course()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Document documentpage = new Document(driver);
            string expectedresult = "Remove";
            classroomcourse.linkmyresponsibilitiesclick(driver);
            documentpage.tabcontentmanagementclick();
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "Exact phrase");
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            driver.Checkin();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.GetElement(By.XPath("//a[@id='lbUserView']")).ClickWithSpace();
           driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "Exact phrase");
           driver.clicktableresult(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr); 
            
            driver.WaitForElement(By.Id("lnkDetails"));
        }
        [Test]
        public void f129_Delete_a_SCORM_course()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Document documentpage = new Document(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            documentpage.tabcontentmanagementclick();
            string expectedresult = "The selected items were deleted.";
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "Exact phrase");
            driver.WaitForElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']")).ClickWithSpace();
            driver.SwitchTo().Alert().Accept();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
    }
}
