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
    public class h_AICCCourses : TestBase
    {
        string browserstr = string.Empty;
        public h_AICCCourses(string browser)
            : base(browser)
        {
            browserstr = browser;
}
       
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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

        }
        [Test]
        public void g135_Create_a_new_AICC_course()
        {
            Document documentpage = new Document(driver);
            driver.UserLogin("admin",browserstr);
            string expectedresult = "Edit Summary";
            string expectedresult1 = "The course was created.";
            //driver.openadminconsolepage();
            AICC aicccourse = new AICC(driver);
            Scorm12 CreateScorm = new Scorm12(driver);
            CreateScorm.linkmyresponsibilitiesclick();
            documentpage.tabcontentmanagementclick();
            documentpage.buttoncoursecreationgoclick("AICC");
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver,true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            driver.WaitForElement(ObjectRepository.sucessmessage);
            Assert.IsTrue(driver.Compareregexstring(expectedresult1, driver.gettextofelement(ObjectRepository.sucessmessage)));

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
            documentpage.tabcontentmanagementclick();
            string expectedresult = "The changes were saved.";
            driver.GetElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_aicc["Title"]+browserstr);
           // driver.select(By.XPath("//select[@id='MainContent_ucSearchTop_SearchType']"), "Exact phrase");
            driver.GetElement(By.XPath("//input[@id='btnSearchCourses']")).ClickWithSpace();
         
            driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            driver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            driver.Checkout();
            driver.GetElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']")).ClickWithSpace();

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
            driver.WaitForElement(ObjectRepository.sucessmessage);
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));

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
            driver.GetElement(By.XPath("//a[@id='lbUserView']")).ClickWithSpace();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_aicc["Title"]+browserstr, "Exact phrase");
            driver.clicktableresult(ExtractDataExcel.MasterDic_aicc["Title"] + browserstr);
        }
        [Test]
        public void g143_Delete_an_AICC_course()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Document documentpage = new Document(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            documentpage.tabcontentmanagementclick();
            string expectedresult = "The selected items were deleted.";
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_aicc["Title"]+browserstr, "Exact phrase");
            driver.WaitForElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']")).ClickWithSpace();
            driver.SwitchTo().Alert().Accept();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }

  
    
    }
}
