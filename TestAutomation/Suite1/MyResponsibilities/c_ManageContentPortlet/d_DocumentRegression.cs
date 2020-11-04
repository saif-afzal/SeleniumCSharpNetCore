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
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class d_Documentold : TestBase
    {
        string browserstr = string.Empty;
        bool courseDocCreated = false;
        public d_Documentold(string browser)
            : base(browser)
        {
            browserstr = browser+"docs";
            // driver.Manage().Window.Maximize();
            InitializeBase(driver);
            Driver.Instance = driver;
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
        }      
   

   
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        #region Titans_Team_UploadedDocument
          [Test]
        public void A_As_a_content_administrator_able_to_preview_my_uploaded_Document_CreateCourse_7251()
        {
            #region Create Document Cource
            documentobj.Create_DocumentForRegression(ExtractDataExcel.MasterDic_document["Title"] + browserstr,browserstr);
            courseDocCreated = true;
            #endregion
       Assert.IsTrue(documentobj.ValidatePreviewButton_Document(ExtractDataExcel.MasterDic_document["Title"] + browserstr));
        }
        [Test]
        public void B_As_a_content_administrator_able_to_preview_my_uploaded_Document_SearchCourse_7253()
        {
         
            if (!courseDocCreated) { documentobj.Create_DocumentForRegression(ExtractDataExcel.MasterDic_document["Title"] + browserstr,browserstr); courseDocCreated = true; }
            GeneralCourse generalcourseobj = new GeneralCourse(driver);
            documentobj.linkmyresponsibilitiesclick();
         //   documentobj.tabcontentmanagementclick();
            generalcourseobj.populatecontentsearchsimple("Contains", ExtractDataExcel.MasterDic_document["Title"] + browserstr, "");
            //driver.ScrollToCoordinated("500", "500");
            //generalcourseobj.buttoncontentsearchclick();
            driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
           Assert.IsTrue(documentobj.ValidatePreviewButton_Document(ExtractDataExcel.MasterDic_document["Title"] + browserstr));
        }
        [Test,Category("P1")]
        public void C_As_a_content_administrator_able_to_preview_my_uploaded_Document_ManageCourse_7278()
        {
            documentobj.ManageDocumentCourse(browserstr);
            Assert.IsTrue(documentobj.ValidatePreviewButton_Document(ExtractDataExcel.MasterDic_document["Title"] + browserstr));
        }

        #endregion
        [Test]
        public void e93_Create_a_new_document_using_a_URL()
        {
         //   driver.UserLogin("admin",browserstr);
            documentobj.linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Document_CourseClick);
            documentobj.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_document["Title"]+browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
            documentobj.populateCourseFilesform(driver,true);
            driver.ScrollToCoordinated("500", "500");
            Assert.IsTrue(documentobj.buttoncreateclick(driver));
        }
        [Test]
        public void e94_Create_a_new_document_using_a_file()
        {
            //driver.UserLogin("admin", browserstr);
            documentobj.linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Document_CourseClick);
            documentobj.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
            driver.ScrollToCoordinated("500", "500");
            documentobj.populateCourseFilesform(driver,false);
            Assert.IsTrue(documentobj.buttoncreateclick(driver));
        }
     //   [Test]
        public void e95_Conduct_a_simple_and_advanced_search_for_a_document()
        {
            GeneralCourse generalcourseobj = new GeneralCourse(driver);
            documentobj.linkmyresponsibilitiesclick();
            documentobj.tabcontentmanagementclick();
            documentobj.buttoncoursecreationgoclick("Document");
            documentobj.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            documentobj.populateCourseFilesform(driver, true);
            documentobj.buttoncreateclick(driver);
            string expectedresult = "3 Items";
            documentobj.linkmyresponsibilitiesclick();
            documentobj.tabcontentmanagementclick();
            generalcourseobj.populatecontentsearchsimple("Contains", ExtractDataExcel.MasterDic_document["Title"] + browserstr, "");
            driver.ScrollToCoordinated("500", "500");
           Assert.IsTrue(generalcourseobj.buttoncontentsearchclick());
            documentobj.linkmyresponsibilitiesclick();
            documentobj.tabcontentmanagementclick();
            documentobj.populatecontentsearchadvance("Contains", ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_genralcourse["Desc"], 9);
            Assert.IsTrue(generalcourseobj.buttoncontentsearchclick());
        }
        [Test]
        public void e96_Manage_a_document()
        {
            string expectedresult = " The changes were saved.";
            string actualresult = string.Empty;
            documentobj.linkmyresponsibilitiesclick();
            //documentobj.tabcontentmanagementclick();
            documentobj.buttonsearchgoclick(ExtractDataExcel.MasterDic_document["Title"] + browserstr, "Exact phrase");
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
            driver.Checkout();
            documentobj.buttoncourseeditclick();
            documentobj.populateeditclassroomsummaryform("testchange");
            actualresult = documentobj.buttonsaveeditclassroomsaveclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
        }
        [Test]
        public void e97_Delete_a_document()
        {
            documentobj.linkmyresponsibilitiesclick();
            //documentobj.tabcontentmanagementclick();
            documentobj.buttonsearchgoclick(ExtractDataExcel.MasterDic_document["Title"] + browserstr, "Exact phrase");
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
            string expectedresult = " The selected items were deleted.";
            string actualresult = documentobj.buttondeletesectionclick();
        
            Assert.IsTrue(driver.comparePartialString("Success", driver.getSuccessMessage()));
            //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
    }
}
