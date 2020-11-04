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
    public class h_AICCCoursesold : TestBase
    {
        string browserstr = string.Empty;
        public h_AICCCoursesold(string browser)
            : base(browser)
        {
            browserstr = browser;
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
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
        [Test]
        public void g135_Create_a_new_AICC_course()
        {
            Document documentpage = new Document(driver);
            driver.UserLogin("admin",browserstr);
            string expectedresult = "Summary";
            string expectedresult1 = "The course was created.";
            //driver.openadminconsolepage();
            AICC aicccourse = new AICC(driver);
            Scorm12 CreateScorm = new Scorm12(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.AICC_CourseClick);
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver,true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult1, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]"))));

            aicccourse.populatesummaryform(driver,browserstr);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
          //  driver.Checkin();

        }
     //   [Test]
        public void g136_Conduct_a_simple_and_advanced_search_for_an_AICC_course()
        {
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_aicc["Title"]+browserstr, "");


            Assert.IsTrue(classroomcourse.buttoncontentsearchclick(), "Simple search worked");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.populatecontentsearchadvance("AICC", ExtractDataExcel.MasterDic_aicc["Title"]+browserstr, "");


            Assert.IsTrue(classroomcourse.buttoncontentsearchclick(), "Advance search worked"); 
        }
        [Test]
        public void g137_Manage_an_AICC_course()
        {
          
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            //documentpage.tabcontentmanagementclick();
            string expectedresult = "The changes were saved.";
        
            driver.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_aicc["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//*[@id='btnSearch']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_aicc["Title"] + browserstr + "')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_aicc["Title"] + browserstr + "')]"));
            driver.Checkout();
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));

             //  driver.SelectFrame();
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE"));
            if (!driver.existsElement(By.XPath("//*[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")))
            {
                //driver.SelectFrame();
                driver.GetElement(By.CssSelector("body")).ClickWithSpace();
                driver.GetElement(By.CssSelector("body")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
              //  driver.SwitchTo().DefaultContent();
            }
            else
            {
                driver.GetElement(By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            }
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
           // driver.SwitchTo().DefaultContent();
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]")));

            driver.Checkin();

        }
       // [Test]
        public void g138_Edit_the_Course_Files_for_an_AICC_course()
        {
            
        }
        [Test]
        public void g139_Assign_a_survey_to_an_AICC_course()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Document documentpage = new Document(driver);
            string expectedresult = "Remove";

            classroomcourse.linkmyresponsibilitiesclick(driver);
            documentpage.tabcontentmanagementclick();
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_aicc["Title"]+browserstr, "Exact phrase");
            // classroomcourse.linkmanagesectionsclick();
            //  classroomcourse.linksearchresulttableclick();
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a"));
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_aicc["Title"]+browserstr, "Exact phrase");
            driver.clicktableresult(ExtractDataExcel.MasterDic_aicc["Title"] + browserstr);
        }
        [Test]
        public void g143_Delete_an_AICC_course()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Document documentpage = new Document(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
          //  documentpage.tabcontentmanagementclick();
            string expectedresult = "The selected items were deleted.";
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_aicc["Title"]+browserstr, "Exact phrase");
       //     driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_aicc["Title"] + browserstr + "')]"));
        //    driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_aicc["Title"] + browserstr + "')]"));
            documentpage.buttondeletesectionclick();

           // string actualresult = documentpage.buttondeletesectionclick();
            Assert.IsTrue(driver.comparePartialString("Success", driver.getSuccessMessage()));
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }

  
    
    }
}
