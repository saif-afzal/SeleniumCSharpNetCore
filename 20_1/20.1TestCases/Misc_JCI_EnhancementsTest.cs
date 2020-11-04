using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_Misc_JCI_EnhancementsTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Misc_JCI_EnhancementsTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle = "TA" + Meridian_Common.globalnum;
        string email = "test"+ Meridian_Common.globalnum+"@test.com";
       
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        bool tc_7334;
        bool tc_7375;
        bool tc_10574;
        string curriculumtitle = "CurruculumTitle" + Meridian_Common.globalnum;
        string AICCCourseTitle = "AICCTitle" + Meridian_Common.globalnum;
        string scormtitle = "SCROMTitle" + Meridian_Common.globalnum;
        string subscriptionTitle = "SubTitle" + Meridian_Common.globalnum;
        string CertificatrTitle = "CertificationTitle" + Meridian_Common.globalnum;
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
        [Test, Order(01)]
        public void tc_7373_Create_a_new_General_course()
        {


            CommonSection.CreateLink.GeneralCourse();

            GeneralCoursePage.SearchTagForNewContent(tagname + "TC7373");
            _test.Log(Status.Info, "Searching Tag.");
            Assert.IsTrue(GeneralCoursePage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(GeneralCoursePage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            GeneralCoursePage.CreateGeneralCourse(GeneralCourseTitle + "TC7373", generalcoursedec);
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string savedTagName = ContentDetailsPage.Summary.tagName(tagname + "TC7373");
            StringAssert.AreEqualIgnoringCase(tagname + "TC7373", savedTagName);
            _test.Log(Status.Pass, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(GeneralCourseTitle + "TC7373");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(GeneralCourseTitle + "TC7373"));
            _test.Log(Status.Pass, "Verify Created content is Searched");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "TC7373");
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Summary.ClickEdit();
            GeneralCoursePage.AvailableinCatalog.ClicktoUncheck();

            GeneralCoursePage.ClickSaveButton();
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is No in summary portlet");
            CommonSection.SearchCatalog(GeneralCourseTitle + "TC7373");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(GeneralCourseTitle + "TC7373"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent(GeneralCourseTitle + "TC7373");

            ManageContentPage.ResultGrid.isSeaarchedContentDisplay(GeneralCourseTitle + "TC7373");
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");
            tc_7375 = true;
            ManageContentPage.ClickContentTitle(GeneralCourseTitle + "TC7373");
            ContentDetailsPage.DeleteContent();
        }
        [Test, Order(02)]
        public void tc_7375_Manage_a_General_course()
        {
            Assert.IsTrue(tc_7375);
            //CommonSection.CreateLink.GeneralCourse();

            //GeneralCoursePage.CreateGeneralCourse(ExtractDataExcel.MasterDic_genralcourse["Title"] + "editcontent", ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            //CommonSection.Manage.Training();
            //SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_genralcourse["Title"] + "editcontent");

            ////driver.Checkout();
            //generalcourseobj.buttoncourseeditclick();
            //generalcourseobj.populateeditclassroomsummaryform("testchange");
            ////  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            //GeneralCoursePage.SearchTagForNewContent(tagname);
            //_test.Log(Status.Info, "Searching Tag.");
            //generalcourseobj.buttonsaveeditclassroomsaveclick();
            ////  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            //string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            //StringAssert.AreEqualIgnoringCase(tagname, s);
            //_test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
        }
        [Test, Order(3)]
        public void tc_7285_Create_Document()
        {
            CommonSection.CreateLink.Document();

            DocumentPage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            Assert.IsTrue(DocumentPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(DocumentPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            DocumentPage.CreateDocument(DocumentTitle + "TC7285");
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string savedTagName = ContentDetailsPage.Summary.tagName(tagname);
            StringAssert.AreEqualIgnoringCase(tagname, savedTagName);
            _test.Log(Status.Pass, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(DocumentTitle + "TC7285");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(DocumentTitle + "TC7285"));
            _test.Log(Status.Pass, "Verify Created content is Searched");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC7285");
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Summary.ClickEdit();
            DocumentPage.AvailableinCatalog.ClicktoUncheck();
            GeneralCoursePage.ClickSaveButton();
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is No in summary portlet");
            CommonSection.SearchCatalog(DocumentTitle + "TC7285");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(DocumentTitle + "TC7285"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent(DocumentTitle + "TC7285");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(DocumentTitle + "TC7285"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");
            tc_7334 = true;
        }
        [Test, Order(4)]
        public void tc_7334_Manage_Document()
        {
            Assert.IsTrue(tc_7334);
        }
        [Test, Order(5)]
        //Creating a Bundle
        public void tc_10455_CreateANewBundle()
        {

            CommonSection.CreateLink.Bundle();

            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");

            Assert.IsTrue(BundlesPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(BundlesPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            CreatebundlePage.CreateBundle("Content Bundle", bunbdleTitle + "TC10445", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            string savedTagName = ContentDetailsPage.Summary.tagName(tagname);
            StringAssert.AreEqualIgnoringCase(tagname, savedTagName);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(bunbdleTitle + "TC10445");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(bunbdleTitle + "TC10445"));
            _test.Log(Status.Pass, "Verify Created content is Searched");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC10445");
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Summary.ClickEdit();
            BundlesPage.AvailableinCatalog.ClicktoUncheck();
            GeneralCoursePage.ClickSaveButton();
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is No in summary portlet");
            CommonSection.SearchCatalog(bunbdleTitle + "TC10445");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(bunbdleTitle + "TC10445"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent(bunbdleTitle + "TC10445");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(bunbdleTitle + "TC10445"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");
            tc_10574 = true;

        }
        [Test, Order(06)]
        public void tc_10574_ManageABundle()
        {
            Assert.IsTrue(tc_10574);
            #region old code
            //CommonSection.CreateLink.Bundle();

            //objCreate.FillBundlePage("editcontent");
            //CommonSection.Manage.Training();
            //TrainingPage.SearchRecord(Variables.bundleTitle + "editcontent");

            //SearchResultsPage.ClickCourseTitle(Variables.bundleTitle + "editcontent");
            //BundlesPage.ClickEdit();
            ////  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            //GeneralCoursePage.SearchTagForNewContent(tagname);
            //_test.Log(Status.Info, "Searching Tag.");
            //SummaryPage.ClickSavebutton();

            ////  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());

            //string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            //StringAssert.AreEqualIgnoringCase(tagname, s);
            //_test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            ////  String assertion on updating Bundle
            #endregion

        }
        [Test, Order(7)]
        public void tc_14061_Create_a_new_Classroom_course()
        {
            string expectedresult = " The item was created.";
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");
            Assert.IsTrue(ClassroomCoursePage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(ClassroomCoursePage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            classroomcourse.populateClassroomform(classroomcoursetitle + "TC14061", "DescTC14061");
            _test.Log(Status.Info, "Filled all required information and submit the classroom creation page");
            Assert.IsTrue(driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick()));
            _test.Log(Status.Pass, "Verify Classroom Course saved");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC14061");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(classroomcoursetitle + "TC14061"));
            _test.Log(Status.Pass, "Verify Created content is Searched");
        }
        [Test, Order(8)]
        public void tc_26747_Manage_a_Classroom_course()
        {

            string actualresult = string.Empty;
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");

            classroomcourse.populateClassroomform(classroomcoursetitle + "TC26747", "DescTC26747");
            _test.Log(Status.Info, "Filled all required information and submit the classroom creation page");
            ClassroomCoursePage.AvailableinCatalog.ClicktoUncheck();
            classroomcourse.buttonsaveclick();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            CommonSection.SearchCatalog(classroomcoursetitle + "TC26747");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(classroomcoursetitle + "TC26747"));
            _test.Log(Status.Pass, "Verify Created content is Searched");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage>>Training Page");
            TrainingPage.SearchRecord(classroomcoursetitle + "TC26747");
            _test.Log(Status.Info, "Searchched created Classroom course using manage Content portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(classroomcoursetitle + "TC26747"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC26747");
            _test.Log(Status.Info, "Click on Classroom Course title from Manage Content page");
            classroomcourse.buttoncourseeditclick();
            _test.Log(Status.Info, "Click on edit button in summary accordian");
            //SummaryPage.AddnewTag(TAGTitle + "TC26747");
            Assert.IsTrue(SummaryPage.AddnewTag(TAGTitle + "TC26747"));
            _test.Log(Status.Pass, "Verify new tab can added in summary page");

            SummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(SummaryPage.checkContentTagsOnDetailsPage());
            // Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            _test.Log(Status.Pass, "Verify added tag is displayed");


        }
        [Test, Order(9)]
        public void tc_10822_Create_Curriculum()
        {
            CommonSection.CreateLink.Curriculam();
            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            CreateCurriculumnPage.fillTtile(curriculumtitle + "TC10822");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            string savedTagName = ContentDetailsPage.Summary.tagName(tagname);
            StringAssert.AreEqualIgnoringCase(tagname, savedTagName);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(curriculumtitle + "TC10822");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(curriculumtitle + "TC10822"));
            _test.Log(Status.Pass, "Verify Created content is Searched");
        }
        [Test, Order(10)]
        public void tc_10823_Manager_Curriculum()
        {
            CommonSection.CreateLink.Curriculam();
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            CreateCurriculumnPage.fillTtile(curriculumtitle + "TC10823");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(curriculumtitle + "TC10823");
            SearchResultsPage.ClickCourseTitle(curriculumtitle + "TC10823");
            ContentDetailsPage.Summary.ClickEdit();
            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            CreateCurriculumnPage.AvailableinCatalog.ClicktoUncheck();
            SummaryPage.ClickSavebutton();
            string savedTagName = ContentDetailsPage.Summary.tagName(tagname);
            StringAssert.AreEqualIgnoringCase(tagname, savedTagName);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            CommonSection.SearchCatalog(curriculumtitle + "TC10823");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(curriculumtitle + "TC10823"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage>>Training Page");
            TrainingPage.SearchRecord(curriculumtitle + "TC10823");
            _test.Log(Status.Info, "Searchched created Classroom course using manage Content portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(curriculumtitle + "TC10823"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");

        }
        [Test, Order(11)]
        public void tc_7401_Create_a_new_AICC_course()
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
            GeneralCoursePage.SearchTagForNewContent(tagname + "TC7401");
            _test.Log(Status.Info, "Searching Tag.");
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            Assert.IsTrue(CreateAICCPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(CreateAICCPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            CreateAICCPage.Title(AICCCourseTitle + "TC7401");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC7401')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC7401", s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(AICCCourseTitle + "TC7401");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(AICCCourseTitle + "TC7401"));
            _test.Log(Status.Pass, "Verify Created content is Searched");

        }
        [Test, Order(12)]
        public void tc_7402_Manage_an_AICC_course()
        {

            Document documentpage = new Document(driver);

            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            CreateAICCPage.Title(AICCCourseTitle + "TC7402");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(AICCCourseTitle + "TC7402");

            SearchResultsPage.ClickCourseTitle(AICCCourseTitle + "TC7402");
            ContentDetailsPage.Summary.ClickEdit();
            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");

            GeneralCoursePage.SearchTagForNewContent(tagname + "TC7402");
            CreateAICCPage.AvailableinCatalog.ClicktoUncheck();
            SummaryPage.ClickSavebutton();
            //_test.Log(Status.Info, "Searching Tag.");
            //if (!driver.existsElement(By.XPath("//*[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")))
            //{
            //    //driver.SelectFrame();
            //    driver.GetElement(By.CssSelector("body")).ClickWithSpace();
            //    driver.GetElement(By.CssSelector("body")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            //    //  driver.SwitchTo().DefaultContent();
            //}
            //else
            //{
            //    driver.GetElement(By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            //}
            //driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            //// driver.SwitchTo().DefaultContent();
            //driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));


            //driver.Checkin();
            // Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC7402')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC7402", s);

            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            CommonSection.SearchCatalog(AICCCourseTitle + "TC7402");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(AICCCourseTitle + "TC7402"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage>>Training Page");
            TrainingPage.SearchRecord(AICCCourseTitle + "TC7402");
            _test.Log(Status.Info, "Searchched created Classroom course using manage Content portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(AICCCourseTitle + "TC7402"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");

        }
        [Test, Order(13)]
        public void tc_7251_Create_a_new_SCORM_course()
        {
            
            string expectedresult = "Summary";

            CommonSection.CreteNewScorm(scormtitle + "TC7251");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.Accordians.ClickEdit_Summery();
            _test.Log(Status.Info, "Click on Edit Summery");
            GeneralCoursePage.SearchTagForNewContent(tagname + "TC7251");
            _test.Log(Status.Info, "Searching Tag.");
            Assert.IsTrue(CreateAICCPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(CreateAICCPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Driver.clickEleJs(By.XPath("//input[@value='Save']"));
            driver.WaitForElement(By.XPath("//h3[contains(.,'Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h3[contains(.,'Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
            Assert.IsTrue(driver.existsElement(By.XPath("//*[contains(@class,'alert alert-success')]")));
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC7251')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC7251", s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(scormtitle + "TC7251");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(scormtitle + "TC7251"));
            _test.Log(Status.Pass, "Verify Created content is Searched");

        }
        [Test, Order(14)]
        public void tc_7253_Manage_a_SCORM_course()
        {
            string expectedresult = "Summary";

            CommonSection.CreteNewScorm(scormtitle + "TC7251");
            _test.Log(Status.Info, "Creating New Scorm");
            DocumentPage.ClickButton_CheckOut();
            ContentDetailsPage.Accordians.ClickEdit_Summery();
            _test.Log(Status.Info, "Click on Edit Summery");
            GeneralCoursePage.SearchTagForNewContent(tagname + "TC7251");
            _test.Log(Status.Info, "Searching Tag.");
            Assert.IsTrue(CreateAICCPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(CreateAICCPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Driver.clickEleJs(By.XPath("//input[@value='Save']"));
            driver.WaitForElement(By.XPath("//h3[contains(.,'Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h3[contains(.,'Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
            Assert.IsTrue(driver.existsElement(By.XPath("//*[contains(@class,'alert alert-success')]")));


            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(scormtitle + "TC7251");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(scormtitle + "TC7251"));
            _test.Log(Status.Pass, "Verify Created content is Searched");

            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(scormtitle + "TC7251");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC7251");
            DocumentPage.ClickButton_CheckOut();
            ContentDetailsPage.Summary.ClickEdit();

            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");

            //GeneralCoursePage.SearchTagForNewContent(tagname + "TC7402");
            CreateAICCPage.AvailableinCatalog.ClicktoUncheck();
            SummaryPage.ClickSavebutton();
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC7251')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC7251", s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");

            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            CommonSection.SearchCatalog(scormtitle + "TC7251");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(scormtitle + "TC7251"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage>>Training Page");
            TrainingPage.SearchRecord(scormtitle + "TC7251");
            _test.Log(Status.Info, "Searchched created Classroom course using manage Content portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(scormtitle + "TC7251"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");
        }
        [Test, Order(15)]
        //Creating a Subscription
        public void tc_10853_CreateANew_Subscription()
        {
            CommonSection.CreateLink.Subscription();

            GeneralCoursePage.SearchTagForNewContent(tagname + "TC10853");
            _test.Log(Status.Info, "Searching Tag.");
            Assert.IsTrue(SubscriptionPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(SubscriptionPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            objCreate.FillSubscriptionPage(subscriptionTitle + "TC10853");
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());

            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC10853')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC10853", s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(subscriptionTitle + "TC10853");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(subscriptionTitle + "TC10853"));
            _test.Log(Status.Pass, "Verify Created content is Searched");
        }


        [Test, Order(16)]
        public void tc_10854_ManageA_Subscription()
        {

            CommonSection.CreateLink.Subscription();

            objCreate.FillSubscriptionPage(subscriptionTitle + "TC10854");
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(subscriptionTitle + "TC10854");

            SearchResultsPage.ClickCourseTitle(subscriptionTitle + "TC10854");
            SubscriptionPage.ClickEdit();
            Assert.IsTrue(CreateCurriculumnPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            GeneralCoursePage.SearchTagForNewContent(tagname + "TC10854");
            _test.Log(Status.Info, "Searching Tag.");
            CreateAICCPage.AvailableinCatalog.ClicktoUncheck();
            SummaryPage.ClickSavebutton();

            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC10854')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC10854", s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("No"));
            CommonSection.SearchCatalog(subscriptionTitle + "TC10854");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(subscriptionTitle + "TC10854"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage>>Training Page");
            TrainingPage.SearchRecord(subscriptionTitle + "TC10854");
            _test.Log(Status.Info, "Searchched created Classroom course using manage Content portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(subscriptionTitle + "TC10854"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");
        }
        [Test, Order(17)]
        //Creating new certification
        public void tc_10878_CreateANew_Certification()
        {
            CommonSection.CreateLink.Certifications();
            Assert.IsTrue(CertificationPage.AvailableinCatalog.isAvailableinCatalogOptionisDisplay());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            Assert.IsTrue(CertificationPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            GeneralCoursePage.SearchTagForNewContent(tagname + "TC10878");
            _test.Log(Status.Info, "Searching Tag.");
            CertificationPage.FillTitle(CertificatrTitle + "TC10878");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreate();
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC10878')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC10878", s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog("Yes"));
            _test.Log(Status.Pass, "Verify Available in Catalog values is Yes in summary portlet");
            CommonSection.SearchCatalog(CertificatrTitle + "TC10878");
            Assert.IsTrue(SearchResultsPage.isSearchResultDisplayed(CertificatrTitle + "TC10878"));
            _test.Log(Status.Pass, "Verify Created content is Searched");
        }



        [Test, Order(18)]
        //Editing existing certification
        public void tc_10879_ManageA_Certification()
        {
            CommonSection.CreateLink.Certifications();
            CertificationPage.FillTitle(CertificatrTitle + "TC10879");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreate();
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(CertificatrTitle + "TC10879");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC10879");

            ContentDetailsPage.Summary.ClickEdit();
            Assert.IsTrue(CertificationPage.AvailableinCatalog.isChecked());
            _test.Log(Status.Pass, "Verifed Available in Catalog Option is Display");
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname + "TC10879");
            _test.Log(Status.Info, "Searching Tag.");
            CertificationPage.AvailableinCatalog.ClicktoUncheck();
            SummaryPage.ClickSavebutton();
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "TC10879')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname + "TC10879", s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            Assert.IsTrue(ContentDetailsPage.Summary.isAvailableinCatalog_certification("No"));
            CommonSection.SearchCatalog(CertificatrTitle + "TC10879");
            Assert.IsFalse(SearchResultsPage.isSearchResultDisplayed(CertificatrTitle + "TC10879"));
            _test.Log(Status.Pass, "Verify Created content is not Searched");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage>>Training Page");
            TrainingPage.SearchRecord(CertificatrTitle + "TC10879");
            _test.Log(Status.Info, "Searchched created Classroom course using manage Content portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(CertificatrTitle + "TC10879"));
            _test.Log(Status.Pass, "Verify Created content is Searched through Manage content");

        }

       // [Test, Order(19)]
        public void tc_8585_Create_New_Account_Self_Registration_8585()
        {
            AccountCreation CreateAccount = new AccountCreation(driver);
            CommonSection.Logout();
            LoginPage.ClickSignup();
            _test.Log(Status.Info, "Click Sign up link on Login Page");

            CreateNewAccountobj.PopulateCreateNewUserLinkOuter(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
           // CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccount.SelectOrganization("Sample Organization");
            CreateNewAccount.EnteredPassword("password");
            CreateNewAccount.EnteredConfirmPassword("password");
            Assert.IsTrue(CreateNewAccount.isConfirmEmailfielddisplaywithNonEditMode()=="true");
            _test.Log(Status.Pass, "Verify Confirm Email field display with non edit mode");
            CreateNewAccount.FilEmailAddress(email);
            Assert.IsTrue(CreateNewAccount.isConfirmEmailfielddisplaywithEditMode());
            _test.Log(Status.Pass, "Verify Confirm Email field display with edit mode");
            Assert.IsFalse(CreateNewAccount.CreateButtonisEnabled());
            CreateNewAccount.FilConfirmEmail("a");
            Assert.IsTrue(CreateNewAccount.ConfirmEmailAddressValidationmessagedisplay("Enter a valid email address that contains"));
            CreateNewAccount.ClearEmailAddress();
            //Assert.IsTrue(CreateNewAccount.isConfirmEmailfielddisplaywithNonEditMode() == "true");
            _test.Log(Status.Pass, "Verify Confirm Email field display with non edit mode");
            CreateNewAccount.FilEmailAddress(email);
            CreateNewAccount.FilConfirmEmail(email);
            Assert.IsTrue(CreateNewAccount.CreateButtonisEnabled());
            CreateNewAccountobj.Click_CreateAccount();
            _test.Log(Status.Info, "Click Create button after fill all mandetory fields");

            HomePage.clickGetStarted();
            _test.Log(Status.Info, "Click On lets get Started button");
            Assert.IsTrue(HomePage.Title == "Home");
            _test.Log(Status.Pass, "User Successfully Logged in");
            

        }
        [Test, Order(20)]
        public void tc_24708_Add_Content_Section_to_Item_Discount_Code()
        {
            //CommonSection.Administer.System.DomainsandURLS.Domains();
            CommonSection.Administer.ECommerce.PricingAndCodes.DiscountCodes();
            _test.Log(Status.Info, "Click Discount codes From administer");
            DiscountCodesPage.SearchCodeAndEditContent("Ak003");
            _test.Log(Status.Info, "Seach the discount code and from Manage go to Edit content");
            EditContentPage.AddContent("NewClassroomTest_DIscountCode002");
            _test.Log(Status.Info, "Click Add content");
            Assert.IsTrue(AddContentPage.SearchResultDisplayed("NewClassroomTest_DIscountCode002"));
            _test.Log(Status.Pass, "Verify Search result is Displayed");
            Assert.IsTrue(AddContentPage.VerifyClassroomCourseSelected("NewClassroomTest_DIscountCode002"));
            _test.Log(Status.Pass, "Verify classroom course is selected");
            Assert.IsTrue(AddContentPage.VerifyByDefaultAllSectionsAreSelected("All Sections (#)"));
            _test.Log(Status.Pass, "Verify by default all section is selected");
            //Assert.IsTrue(AddContentPage.VerifyOnlyFutureSectionsAreDisplayed());
            //_test.Log(Status.Pass, "VerifyI only future sections are displayed");
            Assert.IsTrue(AddContentPage.VerifyIndividualSectionsAreDisplayed());
            _test.Log(Status.Pass, "Verify individual sections are displayed");
            Assert.IsFalse(AddContentPage.VerifySingleSectionCanNotBeSelectedWithAllSections("All Sections(#)"));
            _test.Log(Status.Pass, "Verify Course and the single Sections can not be selected at a time");
            Assert.IsTrue(AddContentPage.VerifyIndividualSectionsIsSelected("All Sections(#)"));
            _test.Log(Status.Pass, "Verify individual sections are displayed");
            Assert.IsTrue(AddContentPage.GetSuccessDiscountCodeAddedMessage("The item was added."));
            _test.Log(Status.Pass, "Verify discount code added success message");

            CommonSection.Administer.ECommerce.PricingAndCodes.DiscountCodes();
            _test.Log(Status.Info, "Click Discount codes From administer");
            DiscountCodesPage.SearchCodeAndEditContent("Ak004");
            _test.Log(Status.Info, "Seach the discount code and from Manage go to Edit content");
            EditContentPage.AddContent("NewClassroomTest_DIscountCode002");
            _test.Log(Status.Info, "Click Add content");
            Assert.IsTrue(AddContentPage.SearchResultDisplayed("NewClassroomTest_DIscountCode002"));
            _test.Log(Status.Pass, "Verify Search result is Displayed");
            Assert.IsTrue(AddContentPage.VerifyIndividualSectionsIsSelected("All Sections(#)"));
            _test.Log(Status.Pass, "Verify individual sections are displayed");
            Assert.IsTrue(AddContentPage.GetSuccessDiscountCodeAddedMessage("The item was added."));
            _test.Log(Status.Pass, "Verify discount code added success message");
        }
        [Test, Order(21)]
        public void tc_59265_As_a_learner_I_want_to_redeem_discount_codes_at_the_classroom_section_Level()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();

            CommonSection.SearchCatalog("NewClassroomTest_DIscountCode002");
            _test.Log(Status.Info, "Search for the content");
            SearchResultsPage.ClickCourseTitle("NewClassroomTest_DIscountCode002");
            _test.Log(Status.Info, "Click on searched title");
            ContentDetailsPage.ClickOnAddtoCartButtonOfSection();
            _test.Log(Status.Info, "Click on Add to Cart Button");
            Assert.IsTrue(CommonSection.isCountincrease_ShopingCart());
            _test.Log(Status.Pass, "Verify the cart count has Increased");
            CommonSection.ClickShoppingCart();
            _test.Log(Status.Info, "Click on Shopping Cart");
            ShoppingCartPage.ApplyDiscountCode("Ak005");
            _test.Log(Status.Info, "Apply wrong Discount code");
            StringAssert.AreEqualIgnoringCase("The discount code you entered is not a valid discount code. Confirm that you have entered the code correctly. If you did, then perhaps you no longer have permission to use the code.", ShoppingCartPage.VerifyWrongDiscountCodeMessage());
            _test.Log(Status.Pass, "Verify Alert message for wrong discount Code");
            ShoppingCartPage.ApplyDiscountCode("Ak003");
            _test.Log(Status.Info, "Apply valid discount code");
            StringAssert.AreEqualIgnoringCase("The discount code was applied to your order.", ShoppingCartPage.VerifyValidDiscountCodeMessage());
            _test.Log(Status.Pass, "Verify Alert message for valid discount Code");
            Assert.IsTrue(ShoppingCartPage.DiscountedAmountIsDisplayed());
            _test.Log(Status.Pass, "Verify discounted amount is displayed");
            ShoppingCartPage.RemoveDiscountCode();
            _test.Log(Status.Info, "Remove discount code");
            StringAssert.AreEqualIgnoringCase("The discount code was removed from your order.", ShoppingCartPage.VerifyDiscountCodeRemoveMessage());
            _test.Log(Status.Pass, "Verify Alert message for remove discount Code");
            ShoppingCartPage.ApplyDiscountCode("Ak004");
            _test.Log(Status.Info, "Apply valid percentage discount code");
            StringAssert.AreEqualIgnoringCase("The discount code was applied to your order.", ShoppingCartPage.VerifyValidDiscountCodeMessage());
            _test.Log(Status.Pass, "Verify Alert message for valid discount Code");
            Assert.IsTrue(ShoppingCartPage.DiscountedAmountInPercentageDisplayed());
            _test.Log(Status.Pass, "Verify discounted amount is displayed");
            ShoppingCartPage.RemoveContent("NewClassroomTest_DIscountCode002 - Section 1");
            _test.Log(Status.Info, "Remove content from cart");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner's account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.Administer.ECommerce.PricingAndCodes.DiscountCodes();
            _test.Log(Status.Info, "Click Discount codes From administer");
            DiscountCodesPage.SearchCodeAndEditContent("Ak003");
            _test.Log(Status.Info, "Seach the discount code and from Manage go to Edit content");
            DiscountCodesPage.RemoveDiscountCode();
            _test.Log(Status.Info, "Remove Discount code");
            DiscountCodesPage.SearchCodeAndEditContent("Ak004");
            _test.Log(Status.Info, "Seach the discount code and from Manage go to Edit content");
            DiscountCodesPage.RemoveDiscountCode();
            _test.Log(Status.Info, "Remove Discount code");

        }
        

    }
}



