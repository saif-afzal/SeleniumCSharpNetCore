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
namespace Selenium2.Meridian.Suite.P1.Learning.Training_Catalog
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DocumentLearnerP1 : TestBase
    {
        string browserstr = string.Empty;
        bool courseDocCreated = false;
        public DocumentLearnerP1(string browser)
            : base(browser)
        {
            browserstr = browser+"docs";
        }      
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           // driver.Manage().Window.Maximize();
            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
            documentobj.linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Document_CourseClick);
          //  documentobj.tabcontentmanagementclick();
         //   documentobj.buttoncoursecreationgoclick("Document");
            documentobj.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
            documentobj.populateCourseFilesform(driver, true);
            driver.ScrollToCoordinated("500", "500");
            documentobj.buttoncreateclick(driver);
            documentobj.editApprovalEnable();
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
        #region Titans_Team_UploadedDocument
     //     //[Test]
        public void A_As_a_content_administrator_able_to_preview_my_uploaded_Document_CreateCourse_7251()
        {
            #region Create Document Cource
            documentobj.Create_DocumentForRegression(ExtractDataExcel.MasterDic_document["Title"] + browserstr,browserstr);
            courseDocCreated = true;
            #endregion
       Assert.IsTrue(documentobj.ValidatePreviewButton_Document(ExtractDataExcel.MasterDic_document["Title"] + browserstr));
        }
    //    //[Test]
        public void B_As_a_content_administrator_able_to_preview_my_uploaded_Document_SearchCourse_7253()
        {
            if (!courseDocCreated) { documentobj.Create_DocumentForRegression(ExtractDataExcel.MasterDic_document["Title"] + browserstr,browserstr); courseDocCreated = true; }
            GeneralCourse generalcourseobj = new GeneralCourse(driver);
            documentobj.linkmyresponsibilitiesclick();
            documentobj.tabcontentmanagementclick();
            generalcourseobj.populatecontentsearchsimple("Contains", ExtractDataExcel.MasterDic_document["Title"] + browserstr, "");
            //driver.ScrollToCoordinated("500", "500");
            generalcourseobj.buttoncontentsearchclick();
            driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
           Assert.IsTrue(documentobj.ValidatePreviewButton_Document(ExtractDataExcel.MasterDic_document["Title"] + browserstr));
        }
    //    //[Test]
        public void C_As_a_content_administrator_able_to_preview_my_uploaded_Document_ManageCourse_7278()
        {
            documentobj.ManageDocumentCourse(browserstr);
            Assert.IsTrue(documentobj.ValidatePreviewButton_Document(ExtractDataExcel.MasterDic_document["Title"] + browserstr));
        }

        #endregion
        ////[Test]
        //public void e93_Create_a_new_document_using_a_URL()
        //{
         
        //}
        //[Test]
        public void a_Request_Access_To_Document_26206()
        {
            Assert.IsTrue(documentobj.requestAccess(ExtractDataExcel.MasterDic_document["Title"], browserstr));
            
        }
        //[Test]
        public void b_Cancel_Request_Access_To_Document_26207()
        {
            Assert.IsTrue(documentobj.cancelRequestAccess(ExtractDataExcel.MasterDic_document["Title"], browserstr));
        }
        //[Test]
        public void c_Launch_Document_26211()
        {
            documentobj.removeAccessApproval("Document", browserstr, ExtractDataExcel.MasterDic_document["Title"], "");
            Assert.IsTrue(documentobj.launchDocument("Document", browserstr, ExtractDataExcel.MasterDic_document["Title"], ""));
            
        }
        //[Test]
        public void d_Mark_Document_Complete_26210()
        {
            Assert.IsTrue(documentobj.markCompleteDocument(ExtractDataExcel.MasterDic_document["Title"], browserstr));
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
