﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using System.Text.RegularExpressions;
using Selenium2.Meridian.Suite.P1.MyResponsibilities.Training;
using TestAutomation.Suite1.Administration.AdministrationConsole;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using TestAutomation.Miscellaneous;

namespace Selenium2.Meridian.Suite
{
    //[TestFixture("ffbs", Category = "firefox")]
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    //[TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]

   // [Parallelizable(ParallelScope.Fixtures)]
    class P1RecommendationContentTagTest : TestBase
    {
        string browserstr = string.Empty;

        public P1RecommendationContentTagTest(string browser)
            : base(browser)
        {
            //   browserstr = browser + "apo";
             
            // driver.Manage().Window.Maximize();
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            //    LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();

        }

        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string classroomcoursetitle= "ClassRoomCourseTitle" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;

        [SetUp]
        public void starttest()
        {
            string tagname = "Tag_Reg" + Meridian_Common.globalnum;
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);


           
        }
      
        public bool chktest = false;

        [Test, Order(20), Category("AutomatedP11")]
        public void T_Create_a_new_SCORM_course_7251()
        {
            string expectedresult = "Summary";

            CommonSection.CreteNewScorm(scormtitle + "TC7284");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.Accordians.ClickEdit_Summery();
            _test.Log(Status.Info, "Click on Edit Summery");
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            Driver.clickEleJs(By.XPath("//input[@value='Save']"));
            driver.WaitForElement(By.XPath("//h3[contains(.,'Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h3[contains(.,'Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
            Assert.IsTrue(driver.existsElement(By.XPath("//*[contains(@class,'alert alert-success')]")));
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");


            
           
            
            
        }
        [Test, Order(21),Category("AutomatedP11")]
        public void U_Manage_a_SCORM_course_7253()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            Document documentpage = new Document(driver);
            CommonSection.CreateLink.SCORM();
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));

            CreateScorm.buttoncreateclick(driver, true);
        //    Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
           
            CreateScorm.populatesummaryform(driver, "editscorm");
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
            driver.WaitForElement(By.XPath("//h3[contains(.,'Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h3[contains(.,'Summary')]"));

            string expectedresult = "The changes were saved.";
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(ExtractDataExcel.MasterDic_scrom["Title"] + "editscorm");
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_scrom["Title"] + "editscorm");
            
           driver.Checkout();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            //   Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            driver.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            //  Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]")));
        }
        [Test, Order(22), Category("AutomatedP11")]
        public void V_Create_a_new_document_using_a_URL_7285()
        {
            //   driver.UserLogin("admin",browserstr);
            CommonSection.CreateLink.Document();
            documentobj.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
            documentobj.populateCourseFilesform(driver, true);
            driver.ScrollToCoordinated("500", "500");
            //   Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            Assert.IsTrue(documentobj.buttoncreateclick(driver));
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
        }
        [Test, Order(23), Category("AutomatedP11")]
        public void P20_1_W__Manage_a_document_7333()
        {
            string expectedresult = " The changes were saved.";
            string actualresult = string.Empty;
            CommonSection.CreateLink.Document();
            documentobj.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_document["Title"] + "editcontent", ExtractDataExcel.MasterDic_document["Desc"]);
            documentobj.populateCourseFilesform(driver, true);
            driver.ScrollToCoordinated("500", "500");
           // Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            Assert.IsTrue(documentobj.buttoncreateclick(driver));
            // Assert.IsTrue(Driver.checkContentTagsOnDetailsPage()); 
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(ExtractDataExcel.MasterDic_document["Title"] + "editcontent");
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_document["Title"] + "editcontent");
            //driver.Checkout();
            documentobj.buttoncourseeditclick();
            documentobj.populateeditclassroomsummaryform("testchange");
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            actualresult = documentobj.buttonsaveeditclassroomsaveclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
        }
        [Test, Order(24), Category("AutomatedP11")]
        public void X_Create_a_new_General_course_7373()
        {
           
            //   driver.UserLogin("admin", browserstr);
            CommonSection.CreateLink.GeneralCourse();
            //   Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            GeneralCoursePage.CreateGeneralCourse(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
        }

       
        [Test, Order(25), Category("AutomatedP11")]
        public void Y_Manage_a_General_course_7375()
        {
            CommonSection.CreateLink.GeneralCourse();
            
            GeneralCoursePage.CreateGeneralCourse(ExtractDataExcel.MasterDic_genralcourse["Title"] + "editcontent", ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            CommonSection.Manage.Training();
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_genralcourse["Title"] + "editcontent");

            //driver.Checkout();
            generalcourseobj.buttoncourseeditclick();
            generalcourseobj.populateeditclassroomsummaryform("testchange");
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            generalcourseobj.buttonsaveeditclassroomsaveclick();
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");




        }
        [Test, Order(26), Category("AutomatedP11")]
        public void Z00_Create_a_new_AICC_course_7401()
        {
            Document documentpage = new Document(driver);
           // driver.UserLogin("admin", browserstr);
            string expectedresult = "Summary";
            string expectedresult1 = "The course was created.";
            //driver.openadminconsolepage();
            AICC aicccourse = new AICC(driver);
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            //    Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult1, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]"))));

            aicccourse.populatesummaryform(driver, browserstr);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            //  driver.Checkin();

        }
        [Test, Order(27), Category("AutomatedP11")]
        public void Z01_Manage_an_AICC_course_7402()
        {

            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            //documentpage.tabcontentmanagementclick();
            string expectedresult = "The changes were saved.";
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            aicccourse.populatesummaryform(driver, "editcontent");
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
            string actualresult = driver.gettextofelement(By.XPath("//h3[contains(.,'Summary')]"));
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(ExtractDataExcel.MasterDic_aicc["Title"] + "editcontent");
           
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_aicc["Title"] + "editcontent");

            driver.Checkout();
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));

            //  driver.SelectFrame();
            driver.WaitForElement(By.Id("CNTLCL_TITLE"));
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
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
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            // driver.SwitchTo().DefaultContent();
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
           

            driver.Checkin();
            // Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");

        }
        [Test, Order(28), Category("AutomatedP11")]
        //Creating a Bundle
        public void Z02_CreateANewBundle_10455()
        {
            /* objTrainingHome.AdminConsole_Click(driver);
             objAdminConsole.ConfigConsole_Click(driver);
             objConfigConsole.ContentSettings_Click(driver);
             objContentSettings.IsAccessPeriod(driver);
             objTrainingHome.QuitAdminConsole(driver);*/


            CommonSection.CreateLink.Bundle();
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            objCreate.FillBundlePage(browserstr);

            //String Assertion on new Bundle creation 

            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");

        }
        [Test, Order(29), Category("AutomatedP11")]
        public void Z03_ManageABundle_10574()
               {

            CommonSection.CreateLink.Bundle();
           
            objCreate.FillBundlePage("editcontent");
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(Variables.bundleTitle + "editcontent");

            SearchResultsPage.ClickCourseTitle(Variables.bundleTitle + "editcontent");
            BundlesPage.ClickEdit();
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            SummaryPage.ClickSavebutton();

            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());

            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            //  String assertion on updating Bundle

        }
       
        [Test, Order(32), Category("AutomatedP11")]
        //Creating a curriculum
        public void Z06_CreateANewCurriculum_10822()
        {
            CommonSection.CreateLink.Curriculam();
            //    Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            objCreate.FillCurriculumPage("", browserstr);
            //    Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            //String Assertion on new curriculum creation 
            //  String successMsg = Driver.getSuccessMessage();
            // StringAssert.Contains("The item was created.", successMsg);

            //objContent.ContentSearch_Click();
            //  CommonSection.SearchCatalog(Variables.curriculumTitle + browserstr);

            //Assertion for curriculum displayed on search
            //   StringAssert.AreNotEqualIgnoringCase(Variables.curriculumTitle + browserstr,SearchResultsPage.MatchRecord(Variables.curriculumTitle + browserstr));
        }

      

         [Test, Order(33), Category("AutomatedP11")]
          public void Z07_ManageACurriculum_10823()
          {

            CommonSection.CreateLink.Curriculam();
          //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            objCreate.FillCurriculumPage("", "editcontent");
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(Variables.curriculumTitle + "editcontent");

            SearchResultsPage.ClickCourseTitle(Variables.curriculumTitle + "editcontent");
            CurriculumsPage.Edit_Click(driver);
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            SummaryPage.ClickSavebutton();
            //   Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
        }

       


        //[Test]
        //public void a48_Create_a_new_Classroom_course_14061()
        //{
        //    string expectedresult = " The item was created.";
        //    CommonSection.CreateLink.ClassroomCourse();
        //    Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
        //    classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
        //    Assert.IsTrue(driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick()));
        //    Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
        //}
    
        //[Test]
        //public void a51_Manage_a_Classroom_course_26747()
        //{
        //    string expectedresult = " The changes were saved.";
        //    string actualresult = string.Empty;
        //    CommonSection.CreateLink.ClassroomCourse();
           
        //    classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "editcontent", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
        //   classroomcourse.buttonsaveclick();
        //    //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
        //    CommonSection.Manage.Training();
        //    TrainingPage.SearchRecord(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "editcontent");
        //    SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "editcontent");

        //    classroomcourse.buttoncourseeditclick();
        //    Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
        //    SummaryPage.ClickSavebutton();
        //    Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());

         
        //}
        //[Test]
        //public void N_ENrolluserfromClassroomSection_33230()
        //{
        //    #region create new course, add section to it and enroll
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
        //    // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
        //    Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "User Enrolled into select course successfully ");
        //    CommonSection.Logout();
        //    _test.Log(Status.Pass, "Admin user logged out successfully");
        //    #endregion

        //    #region Login with a Learner search created classroom course and enroll
        //    LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
        //    _test.Log(Status.Pass, "Login as a Learner");
        //    CommonSection.Learner.CurrentTraining();
        //    CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);

        //    Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));
        //    _test.Log(Status.Pass, "Enrolled classroom course is displaying");
        //    CommonSection.Logout();

        //    #endregion
        //    #region Re login with admin user after validate test.
        //    LoginPage.LoginAs("").WithPassword("").Login();
        //    #endregion

        //}
        //[Test]
        //public void O_Enrollment_Set_Individual_Cancellation_33232()
        //{
        //    #region verify Attendance Required Status For EnrolledUser
        //    CommonSection.CatalogSearchText('"' + classroomcoursetitle + '"');// (classroomcoursetitle);
        //    _test.Log(Status.Pass, "Searched classroom course from Catalog");
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle); //("ClassRoomCourseTitle2011472447");
        //    _test.Log(Status.Pass, "Click Course title to view Detail Content");
        //    CatalogPage.ClickEditContent();
        //    _test.Log(Status.Pass, "Click Edit Content");
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    //ManageClassroomCoursePage.Enrollmenttab.SearchEnrolledUser("userreg_0403012001people1");
        //    Assert.AreEqual("No", ManageClassroomCoursePage.Enrollmenttab.AttendanceRequiredStatusForEnrolledUser());
        //    CommonSection.Logout();
        //    #endregion

        //    #region Login with learner and verify Cancel Enrollment under action
        //    LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
        //    _test.Log(Status.Pass, "Login as a Learner");
        //    CommonSection.Learner.CurrentTraining();
        //    CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');// ('"' + classroomcoursetitle + '"');
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle); //("ClassRoomCourseTitle2011472447");// 
        //    Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));// (classroomcoursetitle));
        //    _test.Log(Status.Pass, "Enrolled classroom course is displaying");
        //    //CurrentTrainings.ClickAction();

        //    Assert.AreEqual("Cancel Enrollment", CurrentTrainings.GetActionStatus());
        //    _test.Log(Status.Pass, "Cancel Enrollment is display in Action section");
        //    CommonSection.Logout();
        //    #endregion

        //    #region Login as admin and update Attendance Required Status For EnrolledUser from No to Yes
        //    LoginPage.LoginAs("").WithPassword("").Login();
        //    _test.Log(Status.Pass, "Login as a Admin");
        //    CommonSection.CatalogSearchText('"' + classroomcoursetitle + '"');//('"' + classroomcoursetitle + '"');
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);// (classroomcoursetitle);
        //    _test.Log(Status.Pass, "Search Catalog");
        //    CatalogPage.ClickEditContent();
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    _test.Log(Status.Pass, "Click Section Tab");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    //ManageClassroomCoursePage.Enrollmenttab.SearchEnrolledUser("userreg_0403012001people1");
        //    ManageClassroomCoursePage.Enrollmenttab.UpdateAttendanceRequiredfromNotoYes();
        //    _test.Log(Status.Pass, "Update Attendance Required from No to Yes");
        //    Assert.AreEqual("Yes", ManageClassroomCoursePage.Enrollmenttab.AttendanceRequiredStatusForEnrolledUser());
        //    //Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    CommonSection.Logout();
        //    #endregion

        //    #region Re Login with learner and verify Cancel Enrollment under action
        //    LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
        //    _test.Log(Status.Pass, "Login as a Learner");
        //    CommonSection.Learner.CurrentTraining();
        //    CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');// ('"' + classroomcoursetitle + '"');
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);// (classroomcoursetitle);
        //    Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));
        //    _test.Log(Status.Pass, "Enrolled classroom course is displaying");
        //    Assert.AreNotEqual("Cancel Enrollment", CurrentTrainings.GetActionStatusForCancelEnrollment());
        //    CommonSection.Logout();
        //    #endregion

        //    #region Re login with admin user after validate test.
        //    LoginPage.LoginAs("").WithPassword("").Login();
        //    #endregion

        //}

        //[Test]

        //public void R_User_Views_Notes_from_Section_Details_33601()
        //{
        //    #region Create New Course And Section And Read Notes
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.EnterNotes("Testing Notes");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.ScheduleTab());
        //    ManageClassroomCoursePage.ClickReadNotesButton();
        //    _test.Log(Status.Pass, "Read Notes Popup Open.");
        //    ManageClassroomCoursePage.ClickCloseReadNotePopup();

        //    _test.Log(Status.Pass, "Read Notes Popup Closed.");
        //    #endregion
        //}

        //[Test]

        //public void S_Admin_User_Search_For_Learner_From_Section_Enrollment_Tab_33599()
        //{
        //    #region Create A Classroom Course Section And Enroll Multiple Users Into It
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("30");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
        //    Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "User Enrolled into select course successfully ");
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.SelectMultipleUsers();
        //    #endregion
        //    Assert.IsTrue(ManageClassroomCoursePage.SearchForEnrolledUser("Regression0403012001people"));
        //    _test.Log(Status.Pass, "Search Result Displayed");
            
        //}

        //[Test]

        //public void T_Enroll_User_In_A_Paid_Section_33597()
        //{
        //    #region Create A Paid Classroom Course Section
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("30");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    ManageClassroomCoursePage.SectionDetailTab();
        //    ManageClassroomCoursePage.setCostForSection();
        //    #endregion

        //    ManageClassroomCoursePage.SearchForContent(classroomcoursetitle);
        //    _test.Log(Status.Pass, "Search For Classroom Course");
        //    ClassroomCourseDetailsPage.addToCart();
        //    _test.Log(Status.Pass, "User Purchasing The Classroom Course");
        //    ManageClassroomCoursePage.SearchForContent(classroomcoursetitle);
        //    Assert.IsTrue(ClassroomCourseDetailsPage.verifyEnrollment());
        //    _test.Log(Status.Pass, "Assertion Pass : User Successfully Purchased Classroom Course and Enrolled");
        //}

        //[Test]

        //public void S_Add_Enrollment_Cancelation_Deadline_While_Creating_Section_33513()
        //{
        //    #region Create New Course And Section With Enrollment Cancellation Date

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SetEnrollmentCancellationDate();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Create New Course Section and Event with Enrollment Cancellation Date");
           
        //    #endregion
        //}

        //[Test, Order(26)]

        //public void Test_When_User_Adds_Learner_toWaitList_33509()
        //{
        //    #region create new course, add section to it and enroll
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle+"Waitlist");
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    //ManageClassroomCoursePage.CreateSection.SectionStartTime("");
        //    // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

        //    // ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SelectWaitListasYes();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");
        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");
        //    Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "User Enrolled into select course successfully ");
        //    CommonSection.Logout();
        //    _test.Log(Status.Pass, "Admin user logged out successfully");
        //    #endregion
        //    LoginPage.GoTo();
        //    LoginPage.LoginClick();
        //    LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
        //    CommonSection.Manage.Training();
        //    _test.Log(Status.Info, "Navigating to Manage Training Page");
        //    TrainingPage.ClickSearchRecord("New Classroom Course ABCD");//Search for Course ABCD 
        //    SectionsPage.ClickSection("section 3");
        //    _test.Log(Status.Info, "must select a section with no seats avialable and start date is in the future");
        //    _test.Log(Status.Info, "User lands on Enrollment Tab--Waitlisted tab. ");
        //    _test.Log(Status.Info, "Wait List Users button is active");
        //    _test.Log(Status.Info, "Enroll button is InActive");
        //    SectionsPage.ClickManageEnrollmentButton();
        //    EnrollmentPage.CickWaitListUsersButton();
        //    _test.Log(Status.Info, "Validate a new Modal opens with a search box and search results are displayed ");
        //    EnrollmentPage.SelectUser("AnyUser");
        //    EnrollmentPage.CickWaitListUsersModalButton();
        //    _test.Log(Status.Info, "Validate User has been Waitlisted ");

        //}

        //[Test]
        // public void P_Create_Setion_With_Past_Date_33497()
        //{
        //    #region Create New Course, Add Section with Past Date
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
        //    Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys("07/15/2018 5:30 PM");
        //    Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).Clear();
        //    Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).SendKeys("07/15/2018 6:30 PM");
        //    IWebElement webElement = Driver.Instance.GetElement(By.XPath("//button[@id='location_0']"));//You can use xpath, ID or name whatever you like
        //    webElement.SendKeys(Keys.Tab);
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Pass, "Click on Create Button");
        //    Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//label[contains(.,'Complete(1)')]")));
        //    _test.Log(Status.Pass, "Assertion Pass as Past Date Section not displaying in Grid.");
        //    #endregion
        //}

        //[Test]
        //public void Q_Create_Setion_With_Different_TimeZone_33501()
        //{
        //    #region Create New Course, Add Section with different timezone
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.SelectTimeZone();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Pass, "Click on Create Button");
        //    #endregion
        //    CommonSection.Logout();
        //    #region Create User and Enroll into above created classroom section
        //    LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
        //    _test.Log(Status.Pass, "Login as a Learner");
        //    CommonSection.Learner.CurrentTraining();
        //    CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');
        //    CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);

        //    Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));
        //    _test.Log(Status.Pass, "Enrolled classroom course is displaying");
        //    CatalogPage.EnrollinClassroomCourse();
        //    Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']")));
        //    _test.Log(Status.Pass, "Assertion Pass, User Enrolled in Timezone Specific Section");
        //    CommonSection.Logout();
        //    #endregion
        //}

        //[Test]
        //public void R_Set_Enrollment_Cancellation_Setting_From_Section_Waitlist_33255()
        //{
        //    #region Create New Course, Add Section with different timezone
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.EnterMaximum("1");
        //    ManageClassroomCoursePage.SelectUseWaitlist("Yes");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Pass, "Click on Create Button");
        //    #endregion

        //    #region Enroll Users
        //    ManageClassroomCoursePage.ClickSectionTitle("Section1");
        //    ManageClassroomCoursePage.ClickEnrollmentTab();
        //    ManageClassroomCoursePage.ClickEnrollButton();
        //    ManageClassroomCoursePage.SelectCheckBox();
        //    ManageClassroomCoursePage.ClickEnroll();
        //    _test.Log(Status.Pass, "User Enrolled into Section");
        //    #endregion

        //    #region Waitlist User
        //    EnrollmentPage.EnrollmentTab.ClickWaitlistedSubTab();
        //    EnrollmentPage.ClickWaitlistUsersButton();
        //    EnrollmentPage.SelectCheckBox();//Select few Users
        //    EnrollmentPage.ClickWaitlistButton();
        //    _test.Log(Status.Pass, "User Waitlisted into Section");
        //    #endregion

        //    Assert.IsTrue(EnrollmentPage.EnrollmentTab.SelectYes()); //Select the 1st User in the List and make Attendance Required to Yes.  Remember User Name
        //    _test.Log(Status.Pass, "Assertion Pass : User's Cancel Enrollment Setting has been set");
        //    CommonSection.Logout();
     
        //}

        //[Test]

        //public void L_Create_New_Section_with_New_Hybrid_Event_Future_Date_33494()
        //{

        //    #region Create New Course, Add Section with Future Date
        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");
        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");
        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
        //    Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys("07/15/2019 5:30 PM");
        //    Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).Clear();
        //    Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).SendKeys("07/15/2019 6:30 PM");
        //    IWebElement webElement = Driver.Instance.GetElement(By.XPath("//button[@id='location_0']"));//You can use xpath, ID or name whatever you like
        //    webElement.SendKeys(Keys.Tab);
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Pass, "Click on Create Button");
        //    Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Section1')]")));
        //    _test.Log(Status.Pass, "Assertion Pass as Section Has been created and visible with future date");
        //    #endregion


        //}


        //[Test]

        //public void S_Admin_User_Add_Remove_Notes_in_Classroom_Course_Section_33705()
        //{
        //    #region Create Classroom Course With Adding Notes

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");

        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    _test.Log(Status.Pass, "Success Message Verified");

        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    _test.Log(Status.Pass, "Enter Section Title and Capacity");

        //    Assert.IsTrue(ManageClassroomCoursePage.EnterNotes("Testing Notes"));
        //    _test.Log(Status.Pass, "Assertion Pass - Added Notes into Section");

        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Pass, "New Section Created");

        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");

        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.ScheduleTab());

        //    ManageClassroomCoursePage.ClickReadNotesButton();
        //    _test.Log(Status.Pass, "Read Notes Popup Open.");

        //    ManageClassroomCoursePage.ClickCloseReadNotePopup();
        //    _test.Log(Status.Pass, "Read Notes Popup Closed.");

           

        //    #endregion
        //}

        //[Test]

        //public void S_User_View_Section_Date_Time_in_Read_Only_Format_Only_33668()
        //{
        //    #region Create Classroom Course With Adding Notes

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");

        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    _test.Log(Status.Pass, "Success Message Verified");

        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    _test.Log(Status.Pass, "Enter Section Title and Capacity");

        //    ManageClassroomCoursePage.CreateSection.Create();
        //    _test.Log(Status.Pass, "New Section Created");

        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    ManageClassroomCoursePage.SectionDetailTab();
        //    Assert.IsTrue(ManageClassroomCoursePage.ClickButton_EditSection());

        //    #endregion
        //}

        

        //  [Test]
        public void Add_Remove_Tags_33228() //Shared step created to test in all contents 
        {
            //   //Assert.IsTrue(Driver.GetElement(By.XPath("xpath=(//button[@type='button'])[33]")).Text=="Select tags");//verifies tag button
            #region verifies that list selected is represented in textbox
            Driver.GetElement(By.XPath("//div[@id='container-tags']/div/div/button/span[2]/span")).ClickWithSpace();//clicks tags button
            var arr = new List<string>();
            IList<IWebElement> lst = Driver.Instance.FindElements(By.XPath("//div[@id='container-tags']/div/div/div/ul/li"));
            int i = 0;
            foreach (var ele in lst)
            {
               ele.ClickWithSpace();//select tags
                arr.Add(ele.Text);
                i = i + 1;
                if(i==3)
                {
                    Driver.GetElement(By.XPath("//div[@id='container-tags']/div/div/button/span[2]/span")).ClickWithSpace();
                    break;
                }
            }
         var str=string.Join(",", arr);
            var stractual = Driver.GetElement(By.XPath("//div[@id='container-tags']/div/div/button/span")).Text;
            stractual= Regex.Replace(stractual, @"\s+", "");
            StringAssert.AreEqualIgnoringCase(str, stractual);

            #endregion
            #region verifies the tag at content details page
            StringAssert.AreEqualIgnoringCase(str, Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[3]/strong")).Text);
            #endregion
            //  StringAssert.Contains("", Driver.GetElement(By.XPath("//div[@id='container-tags']/div/div/button/span")).Text);
            //   // 
        }
        #region verifies that tag gets displayedin content page
        //   // CommonSection.CreateLink.GeneralCourse();
        //   // Assert.IsTrue(GeneralCoursePage.VerifyTagsdropdown()); //Verify Tags dropdown is displayed
        //   // GeneralCoursePage.SelectTags();
        //   // Assert.IsTrue(GeneralCoursePage.Tagsdropdown.SelectTags.ListOfTags()); //Click on Select Tags and verify the list of Tags are available
        //   // GeneralCoursePage.Tagsdropdown.SelectTags.ListofTags.ClickonTags.Enter(); //Select couple of tags from the list
        //   // Assert.IsTrue(GeneralCoursePage.Tagsdropdown.SelectedTagsdisplayed()); //Verify the selected tags are displayed in the field
        #endregion
        //   // // The above steps are to be added to all course Type (except Announcement) to add the Tags while creation
        //   // //Example is for General Course
        #region verifies tag at content details page
        //   // CommonSection.Manage.Training();
        //   // TrainingPage.ManageContentPortlet.SearchForContent("General Course_1");
        //   // StringAssert.AreEqualIgnoringCase("General Course_1", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
        //   // TrainingPage.ClickSearchRecord("General Course_1");
        //   // StringAssert.AreEqualIgnoringCase("General Course_1", GeneralCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
        //   // GeneralCoursePage.ClickCheckout();
        //   // Assert.IsTrue(GeneralCoursePage.VerifyTagsdropdown());
        #endregion//Verify Tags dropdown is displayed
        //   // GeneralCoursePage.EditSummary();
        //   // SummaryPage.Tagsdropdown.clickSelectTags();
        //   // Assert.IsTrue(SummaryPage.Tagsdropdown.SelectTags.ListOfTags()); //Click on Select Tags and verify the list of Tags are available
        //   // SummaryPage.Tagsdropdown.SelectTags.ListofTags.ClickonTags.Enter(); //Select couple of tags from the list
        //   // Assert.IsTrue(SummaryPage.Tagsdropdown.SelectedTagsdisplayed()); //Verify the selected tags are displayed in the field

        //   // // The above steps are to be added to all course Type (except Announcement) to Add/Edit Tags in Manage Training     
        //   // //Example is for General Course
        #region removing the tags
        //   // CommonSection.Manage.Training();
        //   // TrainingPage.ManageContentPortlet.SearchForContent("General Course_1");
        //   // StringAssert.AreEqualIgnoringCase("General Course_1", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
        //   // TrainingPage.ClickSearchRecord("General Course_1");
        //   // StringAssert.AreEqualIgnoringCase("General Course_1", GeneralCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
        //   // GeneralCoursePage.ClickCheckout();
        //   // Assert.IsTrue(GeneralCoursePage.VerifyTagsdropdown()); //Verify Tags dropdown is displayed
        //   // GeneralCoursePage.EditSummary();
        //   // SummaryPage.Tagsdropdown.clickSelectTags();
        //   // Assert.IsTrue(SummaryPage.Tagsdropdown.SelectTags.ListOfTags()); //Click on Select Tags and verify the list of Tags are available
        //   // SummaryPage.Tagsdropdown.SelectTags.ListofTags.UncheckTags.Enter(); //Uncheck the selected Tags from the list
        //   // Assert.IsTrue(SummaryPage.Tagsdropdown.UncheckedTagsNotdisplayed()); //Verify the Unchecked tags are not displayed in the field
        #endregion
        //   // SummaryPage.Tagsdropdown.SelectTags.ListofTags.UncheckAllTags.Enter(); //Uncheck all the selected Tags from the list
        //   // Assert.IsTrue(SummaryPage.Tagsdropdown.SelectTagsdisplayed()); //Verify the none of the Tags are displayed in the dropdown field

        //   // // The above steps are to be added to all course Type (except Announcement) to Remove Tags in Create/Manage Training      
        //   // //Example is for General Course
        //}

        //[Test, Order(22)]
        //public void Set_individual_learners_enrollment_cancellation_setting_Attendance_Required_to_Yes_from_Section_Waitlist_33255()

        //{
        //    CommonSection.CreateLink.ClassroomCourse();
        //    ClassroomCoursePage.Create("Classroom Course_1");
        //    StringAssert.AreEqualIgnoringCase("The item was created.", ClassroomCourseDetailsPage.GetSuccessMessage(), "Error message is different");

        //    #region Create Classroom Section
        //    ClassroomCourseDetailsPage.ClickSectionstab();
        //    SectionsPage.Sectionstab.ClickAddaNewSectionbutton();
        //    AddSectionPage.EnterSectionTitle("Section 1").ClickNext();
        //    AddSectionPage.SelectAddDayEventCheckbox();
        //    AddSectionPage.StartDateField.EnterStartDate("FutureStartDate");
        //    AddSectionPage.EndDateField.EnterEndDate("FutureEndDate");
        //    AddSectionPage.Capacity.MinimumField.EnterMinimum("0");
        //    AddSectionPage.Capacity.MaximumField.EnterMaximum("3");
        //    AddSectionPage.Waitlist.SelectUseWaitlist();
        //    AddSectionPage.EnrollmentPeriodfield.ClickChangebutton();
        //    EnrollmentPeriodModal.EnrollmentStartDateField.EnterStartDate("CurrentStartDate");
        //    EnrollmentPeriodModal.EnrollmentEndDateField.EnterEndDate("FutureEndDate"); //Date before Section End Date
        //    EnrollmentPeriodModal.EnrollmentStartTimeField.EnterStartTime("12:30AM");
        //    EnrollmentPeriodModal.EnrollmentEndTimeField.EnterEndTime("11:30PM");
        //    EnrollmentPeriodModal.ClickSaveButton();
        //    Assert.IsTrue(AddSectionPage.EnrollmentDateAndTimeDisplayed);
        //    AddSectionPage.ClickSave();
        //    StringAssert.AreEqualIgnoringCase("The course section was created with the first event", SectionsPage.GetSuccessMessage(), "Error message is different");
        //    #endregion
        //    #region Enroll Users
        //    SectionsPage.SectionTab.ClickSectionTitle;
        //    SectionPage.EnrollmentTab.ClickEnrollButton();
        //    BatchEnrollUsersModal.ListOfUsers.SelectCheckBox();//Select 3 checkboxes for Users to make Section Full
        //    BatchEnrollUsersModal.ClickEnrollButton();
        //    StringAssert.AreEqualIgnoringCase("Selected Users were enrolled in the section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    Assert.IsTrue(EnrollmentPage.ListofUsersEnrolled);
        //    #endregion

        //    EnrollmentPage.EnrollmentTab.ClickWaitlistedSubTab();
        //    EnrollmentPage.WaitlistedSubTab.ClickWaitlistUsersButton();
        //    WaitlistUsersModal.ListOfUsers.SelectCheckBox();//Select few Users
        //    WaitlistUsersModal.ClickWaitlistUsersButton();
        //    StringAssert.AreEqualIgnoringCase("The Users were waitlisted in selected section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    EnrollmentPage.EnrollmentTab.WaitlistedSubTab.AttendanceRequiredColumn.UserOneintheList.Clickdropdown.SelectYes(); //Select the 1st User in the List and make Attendance Required to Yes.  Remember User Name
        //    StringAssert.AreEqualIgnoringCase("The Changes were saved", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    EnrollmentPage.EnrollmentTab.WaitlistedSubTab.AttendanceRequiredColumn.UserTwointheList.Clickdropdown.SelectNo(); //Select the 2nd User in the List and make Attendance Required to No.  Remember User Name
        //    StringAssert.AreEqualIgnoringCase("The Changes were saved", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    CommonSection.Logout();

        //    LoginPage.LoginAs("UserOne").WithPassword("").Login();//login with the user that has Yes in Attendance Required for the WaitList
        //    CommonSection.Learn.Home();
        //    HomePage.CurrentTrainingSection.ClickClassroomCourseTitle("Classroom Course 1");
        //    Assert.IsTrue(ClassroomCoursePage.NoCancelWaitlistbutton);
        //    StringAssert.AreEqualIgnoringCase("You cannot cancel enrollment/waitlisting for the course. Contact an administrator for the information", ClassroomCoursePage.Message());
        //    CommonSection.Logout();
        //    LoginPage.LoginAs("UserTwo").WithPassword("").Login();//login with the user that has No in Attendance Required for the WaitList
        //    CommonSection.Learn.Home();
        //    HomePage.CurrentTrainingSection.ClickClassroomCourseTitle("Classroom Course 1");
        //    Assert.IsTrue(ClassroomCoursePage.CancelWaitlistbutton.ClickCancelWaitlistbutton);
        //    Assert.IsTrue(ClassroomCoursePage.Waitlistbutton);
        //    CommonSection.Logout();
        //}


        //[Test, Order(23)]
        //public void Manage_Waitlist_from_Sections_listing_for_Not_Completed_Section_and_Enrollment_is_Full_33259()

        //{
        //    #region Manage Classroom Course
        //    CommonSection.Manage.Training();
        //    TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
        //    TrainingPage.ClickSearchRecord("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
        //    ClassroomCoursePage.ClickSectionsTab();
        //    Assert.IsTrue(SectionsPage.ListofSections);
        //    #endregion

        //    #region Create Sections
        //    ClassroomCourseDetailsPage.ClickSectionstab();
        //    SectionsPage.Sectionstab.ClickAddaNewSectionbutton();
        //    AddSectionPage.EnterSectionTitle("Section 1").ClickNext();
        //    AddSectionPage.SelectAddDayEventCheckbox();
        //    AddSectionPage.StartDateField.EnterStartDate("FutureStartDate");
        //    AddSectionPage.EndDateField.EnterEndDate("FutureEndDate");
        //    AddSectionPage.Capacity.MinimumField.EnterMinimum("0");
        //    AddSectionPage.Capacity.MaximumField.EnterMaximum("3");
        //    AddSectionPage.Waitlist.SelectUseWaitlist();
        //    AddSectionPage.EnrollmentPeriodfield.ClickChangebutton();
        //    EnrollmentPeriodModal.EnrollmentStartDateField.EnterStartDate("CurrentStartDate");
        //    EnrollmentPeriodModal.EnrollmentEndDateField.EnterEndDate("FutureEndDate"); //Date before Section End Date
        //    EnrollmentPeriodModal.EnrollmentStartTimeField.EnterStartTime("12:30AM");
        //    EnrollmentPeriodModal.EnrollmentEndTimeField.EnterEndTime("11:30PM");
        //    EnrollmentPeriodModal.ClickSaveButton();
        //    Assert.IsTrue(AddSectionPage.EnrollmentDateAndTimeDisplayed);
        //    AddSectionPage.ClickSave();
        //    StringAssert.AreEqualIgnoringCase("The course section was created with the first event", SectionsPage.GetSuccessMessage(), "Error message is different");
        //    #endregion

        //    #region Enroll Users to make Section Full
        //    SectionsPage.SectionTab.ClickSectionTitle;
        //    SectionPage.EnrollmentTab.ClickEnrollButton();
        //    BatchEnrollUsersModal.ListOfUsers.SelectCheckBox();//Select 3 checkboxes for Users to make Section Full
        //    BatchEnrollUsersModal.ClickEnrollButton();
        //    StringAssert.AreEqualIgnoringCase("Selected Users were enrolled in the section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    Assert.IsTrue(EnrollmentPage.ListofUsersEnrolled);
        //    #endregion

        //    SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is Not Completed Section and the Enrollment is Full 
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.ManageWaitlist); //Verify the Manage Waitlist dropdown is displayed
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.WaitlistUsers); //Verify the Waitlist Users dropdown is NOT displayed
        //    SectionsPage.Sectiondropdown.SelectManageWaitlistoption();
        //    Assert.IsTrue(EnrollmentPage.EnrollmentTab.WaitlistedSubTab);

        //}

        //[Test, Order(24)]

        //public void Manage_Waitlist_from_Sections_listing_for_Completed_Section_and_Enrollment_is_Full_33273()

        //{
        //    #region Manage Classroom Course
        //    CommonSection.Manage.Training();
        //    TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", Driver.getSuccessMessage(), "Error message is different");//verify  text
        //    TrainingPage.ClickSearchRecord("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", Driver.getSuccessMessage(), "Error message is different");//verify  text
        //    ClassroomCoursePage.ClickSectionsTab();
        //    Assert.IsTrue(SectionsPage.ListofSections);
        //    #endregion

        //    #region Create Sections
        //    ClassroomCourseDetailsPage.ClickSectionstab();
        //    SectionsPage.Sectionstab.ClickAddaNewSectionbutton();
        //    AddSectionPage.EnterSectionTitle("Section 1").ClickNext();
        //    AddSectionPage.SelectAddDayEventCheckbox();
        //    AddSectionPage.StartDateField.EnterStartDate("CurrentStartDate");
        //    AddSectionPage.EndDateField.EnterEndDate("CurrentEndDate");
        //    AddSectionPage.Capacity.MinimumField.EnterMinimum("0");
        //    AddSectionPage.Capacity.MaximumField.EnterMaximum("3");
        //    AddSectionPage.Waitlist.SelectUseWaitlist();
        //    AddSectionPage.EnrollmentPeriodfield.ClickChangebutton();
        //    EnrollmentPeriodModal.EnrollmentStartDateField.EnterStartDate("PastStartDate");
        //    EnrollmentPeriodModal.EnrollmentEndDateField.EnterEndDate("CurrentEndDate"); //Date of Section End Date
        //    EnrollmentPeriodModal.EnrollmentStartTimeField.EnterStartTime("12:30AM"); //Time before Section Start Time
        //    EnrollmentPeriodModal.EnrollmentEndTimeField.EnterEndTime("11:30PM"); //Time before Section End Time
        //    EnrollmentPeriodModal.ClickSaveButton();
        //    Assert.IsTrue(AddSectionPage.EnrollmentDateAndTimeDisplayed);
        //    AddSectionPage.ClickSave();
        //    StringAssert.AreEqualIgnoringCase("The course section was created with the first event", SectionsPage.GetSuccessMessage(), "Error message is different");
        //    #endregion


        //    #region Enroll Users to make Section Full
        //    SectionsPage.SectionTab.ClickSectionTitle;
        //    SectionPage.EnrollmentTab.ClickEnrollButton();
        //    BatchEnrollUsersModal.ListOfUsers.SelectCheckBox();//Select 3 checkboxes for Users to make Section Full
        //    BatchEnrollUsersModal.ClickEnrollButton();
        //    StringAssert.AreEqualIgnoringCase("Selected Users were enrolled in the section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    Assert.IsTrue(EnrollmentPage.ListofUsersEnrolled);
        //    #endregion

        //    SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is Completed Section and the Enrollment is Full 
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.ManageWaitlist()); //Verify the Manage Waitlist dropdown is NOT displayed
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.WaitlistUsers()); //Verify the Waitlist Users dropdown is NOT displayed


        //}
        //[Test, Order(25)]
        //public void Manage_Waitlist_from_Sections_listing_for_Not_Completed_Section_and_Enrollment_is_Not_Full_33279()

        //{
        //    #region Manage Classroom Course
        //    CommonSection.Manage.Training();
        //    TrainingPage.ManageContentPortlet.SearchForContent("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
        //    TrainingPage.ClickSearchRecord("Classroom Course");
        //    StringAssert.AreEqualIgnoringCase("Classroom Course", ClassroomCoursePage.GetSuccessMessage(), "Error message is different");//verify  text
        //    ClassroomCoursePage.ClickSectionsTab();
        //    Assert.IsTrue(SectionsPage.ListofSections);
        //    #endregion

        //    #region Create Sections
        //    ClassroomCourseDetailsPage.ClickSectionstab();
        //    SectionsPage.Sectionstab.ClickAddaNewSectionbutton();
        //    AddSectionPage.EnterSectionTitle("Section 1").ClickNext();
        //    AddSectionPage.SelectAddDayEventCheckbox();
        //    AddSectionPage.StartDateField.EnterStartDate("FutureStartDate");
        //    AddSectionPage.EndDateField.EnterEndDate("FutureEndDate");
        //    AddSectionPage.Capacity.MinimumField.EnterMinimum("0");
        //    AddSectionPage.Capacity.MaximumField.EnterMaximum("3");
        //    AddSectionPage.Waitlist.SelectUseWaitlist();
        //    AddSectionPage.EnrollmentPeriodfield.ClickChangebutton();
        //    EnrollmentPeriodModal.EnrollmentStartDateField.EnterStartDate("CurrentStartDate");
        //    EnrollmentPeriodModal.EnrollmentEndDateField.EnterEndDate("FutureEndDate"); //Date before Section End Date
        //    EnrollmentPeriodModal.EnrollmentStartTimeField.EnterStartTime("12:30AM");
        //    EnrollmentPeriodModal.EnrollmentEndTimeField.EnterEndTime("11:30PM");
        //    EnrollmentPeriodModal.ClickSaveButton();
        //    Assert.IsTrue(AddSectionPage.EnrollmentDateAndTimeDisplayed);
        //    AddSectionPage.ClickSave();
        //    StringAssert.AreEqualIgnoringCase("The course section was created with the first event", SectionsPage.GetSuccessMessage(), "Error message is different");
        //    #endregion

        //    #region Enroll Users to make Section Not Full
        //    SectionsPage.SectionTab.ClickSectionTitle;
        //    SectionPage.EnrollmentTab.ClickEnrollButton();
        //    BatchEnrollUsersModal.ListOfUsers.SelectCheckBox();//Select 1-2 checkboxes for Users to make Section NOT Full
        //    BatchEnrollUsersModal.ClickEnrollButton();
        //    StringAssert.AreEqualIgnoringCase("Selected Users were enrolled in the section", EnrollmentPage.GetSuccessMessage(), "Error message is different");
        //    Assert.IsTrue(EnrollmentPage.ListofUsersEnrolled);
        //    #endregion

        //    SectionsPage.ListofSections.ClickSectiondropdown(); //Click the dropdown for Section that is NOT Completed Section and the Enrollment is NOT Full 
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.ManageWaitlist()); //Verify the Manage Waitlist dropdown is NOT displayed
        //    Assert.IsTrue(SectionsPage.Sectionsdropdown.WaitlistUsers()); //Verify the Waitlist Users dropdown is NOT displayed   

        //}
        //[Test, Order(17)]
        //public void View_Events_in_Section_Schedule_33511()
        //{

        //    string format = "M/dd/yyyy";

        //    string startdate = DateTime.Now.ToString(format);
        //    startdate = startdate.Replace("-", "/");
        //    string enddate = DateTime.Now.ToString(format);
        //    enddate = enddate.Replace("-", "/");
        //    //This Test is to test the format of Events >> Schedule page. 
        //    //Pre-requisite For this test - Classroom Course, Sections, and Events with and without Location, Tnstructor, Notes are already created
        //    CommonSection.CreateLink.ClassroomCourse();
        //    ClassroomCoursePage.CreateClassroomCourse("ClassroomCourse" + Meridian_Common.globalnum);
        //    ClassroomCourseDetailsPage.ClickSectionsTab();
        //    SectionsPage.AddNewSectionButton();
        //    CreateNewCourseSectionAndEventPage.CreateSection("testsection", startdate, enddate, startdate, enddate);
        //    CommonSection.Manage.Training();

        //    TrainingPage.SearchRecord("ClassroomCourse" + Meridian_Common.globalnum);



        //    Assert.IsTrue(SearchResultsPage.SearchedRecord.SectionsButton.ClickSectionTitle(), "Sections details button is missing");
        //    // ClassroomCourseDetailsPage.ClickSectionsTab();
        //    // SearchResultsPage.SearchedRecord.SectionsButton.ClickSectionTitle(); //Click on the Section link that contains Events
        //    SectionsPage.ClickScheduleTab();
        //    //   EventsPage.ScheduleTab.VerifyListofEvents();
        //    #region Verifies table with out data
        //    StringAssert.AreEqualIgnoringCase("ClassroomCourse" + Meridian_Common.globalnum, SchedulePage.ScheduleTab.EventTitlecolumn.Value); //Verify Event Title is displayed as link
        //    string expectedres = startdate + " - " + enddate + "\r\n8:00 AM - 12:00 PM";
        //    StringAssert.AreEqualIgnoringCase(expectedres, SchedulePage.ScheduleTab.Schedulecolumn.EventStartEndDateTime); //Verify right Event Start Date and time is displayed
        //    StringAssert.AreEqualIgnoringCase("", SchedulePage.ScheduleTab.Instructorscolumn.Instructors); //Verify right Event Instructor is displayed if entered
        //    StringAssert.AreEqualIgnoringCase("", SchedulePage.ScheduleTab.Locationcolumn.Locations); //Verify right Event Location is displayed if entered
        //    Assert.IsFalse(SchedulePage.ScheduleTab.Notescolumn.ReadNotesButton); //Verify Read Notes button is displayed when there are notes for the section
        //    Assert.IsTrue(SchedulePage.ScheduleTab.CreateNewEventButton, "Create New Event button is missing from Schedule page");
        //    Assert.IsTrue(SchedulePage.ScheduleTab.BacktoSectionsButton, "Back to sections button is missing from Schedule page");
        //    #endregion
        //    #region Updating Classroom course with Instructor,Locators and notes
        //    SchedulePage.ScheduleTab.EventTitlecolumn.ClickEventTitle("ClassroomCourse" + Meridian_Common.globalnum);
        //    //ClassroomCourseDetailsPage.ClickSectionsTab();
        //    //SectionsPage.ClickSectionTitle("testsection");
        //    //SectionDetailsPage.ClickScehduleTab();
        //    //SchedulePage.ScheduleTab.EventTitlecolumn.ClickEventTitle("ClassroomCourse" + Meridian_Common.globalnum);
        //    SectionsPage.ClickLocation();
        //    LocationPage.AddLocation();
        //    SectionsPage.ClickInstructor();
        //    InstructorsPage.AddInstructor();

        //    SectionsPage.AddEventNotes("testing");
        //    SectionsPage.ClickSaveButton();
        //    #endregion
        //    #region verifies  table with data 
        //    StringAssert.AreEqualIgnoringCase("Site Administrator", SchedulePage.ScheduleTab.Instructorscolumn.Instructors); //Verify right Event Instructor is displayed if entered
        //    StringAssert.AreEqualIgnoringCase("1, testroom", SchedulePage.ScheduleTab.Locationcolumn.Locations); //Verify right Event Location is displayed if entered
        //    Assert.IsTrue(SchedulePage.ScheduleTab.Notescolumn.ReadNotesButton); //Verify Read Notes button is displayed when there are notes for the section
        //    Assert.IsTrue(SchedulePage.ScheduleTab.CreateNewEventButton, "Create New Event button is missing from Schedule page");
        //    Assert.IsTrue(SchedulePage.ScheduleTab.BacktoSectionsButton, "Back to sections button is missing from Schedule page");
        //    #endregion
        //    //#region removes Instructor,notes,Location from Section
        //    //SchedulePage.ScheduleTab.EventTitlecolumn.ClickEventTitle("ClassroomCourse" + Meridian_Common.globalnum);
        //    //SectionsPage.ClickLocation();
        //    //LocationPage.RemoveLocation();
        //    //SectionsPage.ClickInstructor();
        //    //InstructorsPage.RemoveInstructor();

        //    //SectionsPage.DeleteEventNotes();
        //    //SectionsPage.ClickSaveButton();
        //    //#endregion


        //    //#region verifies data from table when all is erased in above region
        //    //StringAssert.AreNotEqualIgnoringCase("Site Administrator", SchedulePage.ScheduleTab.Instructorscolumn.Instructors); //Verify right Event Instructor is displayed if entered
        //    //StringAssert.AreNotEqualIgnoringCase("1, testroom", SchedulePage.ScheduleTab.Locationcolumn.Locations); //Verify right Event Location is displayed if entered
        //    //Assert.IsFalse(SchedulePage.ScheduleTab.Notescolumn.ReadNotesButton); //Verify Read Notes button is displayed when there are notes for the section
        //    //Assert.IsTrue(SchedulePage.ScheduleTab.CreateNewEventButton, "Create New Event button is missing from Schedule page");
        //    //Assert.IsTrue(SchedulePage.ScheduleTab.BacktoSectionsButton, "Back to sections button is missing from Schedule page");
        //    //#endregion

        //}

    
        //[Test]

        //public void Z_User_Views_Section_Gradebook_via_section_Tab_33774()
        //{
        //    #region create new course and Access The Gradebook From Section Detail Page

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");

        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SelectUseWaitlist("");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));

        //    //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");

        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");

        //    Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "User Enrolled into select course successfully ");

        //    Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");

        //    Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook Grid Columns are Available and Sortable");

        //   #endregion
            
        //}

        //[Test]

        //public void Z2_User_Views_Section_Gradebook_via_Instructor_Tool_33776()
        //{
        //    #region create new course and Access The Gradebook From Instructor Tool Page

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");

        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SelectUseWaitlist("");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));

        //    //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");

        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");

        // //   Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "User Enrolled into select course successfully ");

        //    #endregion
        //    CommonSection.Manage.Training();
        //    CommonSection.Manage.TrainingPage.InstructorTool();
        //    Assert.IsTrue(InstructorsPage.Click_GradebookConsole());
        //    InstructorsPage.Search_ForSection(classroomcoursetitle);
        //   // InstructorsPage.Open_SectionDetail();

        //    Assert.IsTrue(InstructorsPage.Click_GradebookButton());
        //    _test.Log(Status.Pass, "Assertion Pass Manage Gradebook Button is Visible");

        //    Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook accessible Available from Instructor Tool Page");

        //}

        //[Test]

        //public void Z3_User_Views_Gradebook_via_Manage_Students_Tab_33780()
        //{
        //    #region create new course and Access The Gradebook From Manage Student

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");

        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SelectUseWaitlist("");
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));

        //    //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");

        //    ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
        //    Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
        //    ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
        //    ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg_0403012001people1");

        //    //   Assert.IsTrue(Driver.comparePartialString("Success", ManageClassroomCoursePage.GetUpdatedSuccessMessage()));
        //    _test.Log(Status.Pass, "User Enrolled into select course successfully ");

        //    #endregion
        //    CommonSection.Manage.Training();
        //    CommonSection.Manage.TrainingPage.InstructorTool();
        //    InstructorsPage.Click_ManageStudent();
        //    InstructorsPage.Search_ForSection_InManageStudentPage(classroomcoursetitle);
           
        //    Assert.IsTrue(InstructorsPage.Click_SectionTitle_FrommanageStudentPage());
        //    _test.Log(Status.Pass, "Assertion Pass Manage Gradebook Button is Visible");

        //    Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook accessible Available from Instructor Tool Page");
        //}

        //[Test]

        //public void Z4_User_Views_Gradebook_via_Teaching_Schedule_Tab_33782()
        //{
        //    #region create new course and Access The Gradebook From Teaching Schedule

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");

        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SelectUseWaitlist("");
        //    ManageClassroomCoursePage.SelectInstructor();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Create New Course Section and Event");

        //    #endregion
        //    CommonSection.Manage.Training();
        //    CommonSection.Manage.TrainingPage.InstructorTool();
        //    Assert.IsTrue(InstructorsPage.Expand_SectionDetail());
        //    _test.Log(Status.Pass, "Assertion Pass Manage Gradebook Button is Visible");

        //    Assert.IsTrue(ManageClassroomCoursePage.Verify_GradebookGrid());
        //    _test.Log(Status.Pass, "Assertion Pass Gradebook accessible Available from Instructor Tool Training Schedule");
        //}

        //[Test]

        //public void Z5_User_Adds_Location_when_creating_classroom_course_33786()
        //{
        //    #region create new course with Location

        //    CommonSection.CreateLink.ClassroomCourse();
        //    _test.Log(Status.Pass, "Opened Create Classroom Course Page");

        //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
        //    _test.Log(Status.Pass, "New Classroom Course Created");

        //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
        //    ManageClassroomCoursePage.Clicktab("Sections");
        //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
        //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
        //    ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
        //    ManageClassroomCoursePage.SelectUseWaitlist("");
        //    ManageClassroomCoursePage.SelectLocation();
        //    ManageClassroomCoursePage.CreateSection.Create();
        //    Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
        //    _test.Log(Status.Pass, "Assertion Pass : As Section Created With Location");

        //    #endregion
        //}



        //[TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, "Assertion has been Failed, Please Take a Look to Below Screenshot and StackTrace");
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath = screenShotPath.Replace(@"C:\Users\admin\Desktop\Automation\Regression Scripts\18.2\", @"Z:\");
                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

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
                CommonSection.Learn.Home();
             //   Driver.Instance.Navigate_to_TrainingHome();
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
