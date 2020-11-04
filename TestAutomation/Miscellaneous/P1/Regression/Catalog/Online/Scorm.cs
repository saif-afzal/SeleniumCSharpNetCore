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
namespace Selenium2.Meridian.Suite.P1.Learning.Training_Catalog
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ScormLearnerP1 : TestBase
    {
        string browserstr = string.Empty;
        bool courseCreated = false;
        public ScormLearnerP1(string browser)
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

            #region Create Scorm Course
            Document documentpage = new Document(driver);
        //    string expectedresult = "Edit Summary";
        //    string expectedresult1 = "The course was created.";
            Scorm12 CreateScorm = new Scorm12(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Scorm_CourseClick);
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver, true);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
         //   string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
        //    StringAssert.AreEqualIgnoringCase(expectedresult, text);
            driver.WaitForElement(ObjectRepository.sucessmessage);
            CreateScorm.populatesummaryform(driver, browserstr);
            CreateScorm.buttonsaveclick(driver);
            
            #endregion

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
        public void Enroll_In_Scorm_Course_26225()
        {
         //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         //   driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(classroomcourse.enrollInToCourses("Scorm", browserstr, "", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr, ""));
        }
       //[Test, Order(2)]
        public void Cancel_Enrollment_From_Scorm_Course_14517()
        {
            Assert.IsTrue(classroomcourse.cancelEnrollmentCourses("Scorm"));
        }
        //[Test, Order(3)]
        public void Request_Access_To_Scorm_Course_26230()
        {
            
            classroomcourse.editAccessApproval(browserstr, "scorm");
            Assert.IsTrue(documentobj.requestAccessForContent("scorm", browserstr, "", "", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));


        }
       //[Test, Order(4)]
        public void Cancel_Request_Access_To_Scorm_Course_26233()
        {
            Assert.IsTrue(documentobj.cancelRequestAccessForContent("scorm", browserstr));
        }

        //[Test, Order(5)]
        public void Launch_Scorm_Course_26248()

        {
            documentobj.removeAccessApproval("Scorm", browserstr, "", ExtractDataExcel.MasterDic_scrom["Title"]);
            classroomcourse.enrollInToCourses("Scorm", browserstr, "", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Assert.IsTrue(documentobj.launchDocument("Scorm", browserstr, "", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));
        }

        //[Test, Order(6)]
        public void View_Scorm_Course_Details_26366()
        {
            ContentSearch objContentSearch = new ContentSearch(driver);
            objContentSearch.viewDetailsOfCourses("Scorm", browserstr);
        }

        //[Test, Order(7)]
        public void Mark_Complete_Scorm_Course_16743()
        {

            Assert.IsTrue(Scorm1_2obj.markComplete());

        }

        //[Test, Order(8)]
        public void View_Scorm_Course_Certificate_26236()
        {
            ContentSearch objContentSearch = new ContentSearch(driver);
            Assert.IsTrue(Scorm1_2obj.viewScormCertificate());
            
        }
        //[Test, Order(9)]
        public void Take_Scorm_Course_Related_Surveys_26242()
        {
            Assert.Fail("Need to be automated");
        }

       

        //[Test, Order(10)]
        public void f129_Delete_a_SCORM_course_7438()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin", browserstr);
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']")));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
            driver.findandacceptalert();
            if (!driver.IsElementVisible(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")))
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
