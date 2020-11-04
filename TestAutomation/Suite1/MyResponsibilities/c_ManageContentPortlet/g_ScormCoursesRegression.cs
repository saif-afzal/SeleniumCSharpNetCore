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
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class g_ScormCourseold : TestBase
    {
        string browserstr = string.Empty;
        
        bool courseCreated = false;
        public g_ScormCourseold(string browser)
            : base(browser)
        {
            browserstr = browser;
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
        }
    


      
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //  _extent.Flush();
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }
        #region Titans_Team_UploadedScormCourse
        //  [Test]
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
   //     [Test]
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
      //  [Test]
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
            string expectedresult = "Summary";
            string expectedresult1 = "The course was created.";
            Scorm12 CreateScorm = new Scorm12(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Scorm_CourseClick);
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver, true);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
            Assert.IsTrue(driver.existsElement(By.XPath("//*[contains(@class,'alert alert-success')]")));
           
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
            //documentpage.tabcontentmanagementclick();
            string expectedresult = "The changes were saved.";
            driver.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//*[@id='btnSearch']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.Checkout();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
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
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]")));
        }
     //  [Test]
        public void f122_Edit_the_Course_Files_for_a_SCORM_course()
        {
            
        }
        [Test]
        public void f123_Edit_the_Course_Settings_for_a_SCORM_1_2_course()
        {
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            driver.Checkin();
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a"));
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, "Exact phrase");
            driver.clicktableresult(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton']")).ClickWithSpace();
            //driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            //driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnCourseEnroll']"));
          //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnCourseEnroll']")).ClickWithSpace();
            Thread.Sleep(5000);
          //  driver.SwitchtoDefaultContent();
            Thread.Sleep(5000);
            driver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']")).ClickWithSpace();
            Thread.Sleep(5000);
            Thread.Sleep(5000);
            Assert.IsFalse(driver.existsElement(By.Id("Exit")));
            Thread.Sleep(5000);
            driver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Thread.Sleep(5000);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
        }
      //  [Test]
        public void f124_Assign_required_training_to_a_SCORM_course()
        {
            Scorm12 AssignScorm = new Scorm12(driver);
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-requiredTrainingManagement']"));
            driver.ClickEleJs(By.XPath(".//*[@id='admin-console-requiredTrainingManagement']/div/ul/li[1]/a"));
            driver.selectWindow("Required Training Console");
            //TrainingHomeobj.click_systemOptionsAccordian("Required Training");
            //TrainingHomeobj.click_systemOptionsLink("Training Assignments");
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
          //  documentpage.tabcontentmanagementclick();
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "Exact phrase");
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            driver.Checkin();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a"));
           driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "Exact phrase");
           driver.clicktableresult(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr); 
            
          Assert.IsTrue(driver.existsElement(By.Id("lnkDetails")));
        }
        [Test]
        public void f129_Delete_a_SCORM_course()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Document documentpage = new Document(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
         //   documentpage.tabcontentmanagementclick();
            string expectedresult = "The selected items were deleted.";
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr, "Exact phrase");
            //driver.ClickEleJs(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/button"));
            //driver.WaitForElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']"));
           // documentpage.buttondeletesectionclick();
            //driver.SwitchTo().Alert().Accept();
            string actualresult = documentpage.buttondeletesectionclick();
            Assert.IsTrue(driver.comparePartialString("Success", driver.getSuccessMessage()));
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
    }
}

