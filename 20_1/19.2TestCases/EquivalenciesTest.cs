using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1_EquivalenciesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_EquivalenciesTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string documenttitle="Document" + Meridian_Common.globalnum;
        string scormtitle="SCROM"+ Meridian_Common.globalnum;
        string AICCTitle= "AICC" + Meridian_Common.globalnum;
        string bunbdleTitle= "Bundle" + Meridian_Common.globalnum;
        string curriculamtitle= "Curriculum" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string surveyTitle= "Survey" + Meridian_Common.globalnum;

      
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
   
        [Test, Order(1)]
        public void a01_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_GeneralCourse_52238()
        {

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC52238", generalcoursetitle + "TC52238");
            _test.Log(Status.Info, "Content Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            DocumentPage.ClickButton_CheckIn();
        }
     [Test, Order(2)]
        public void a02_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_Document_52239()
        {

            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(documenttitle + "TC52239");
            _test.Log(Status.Info, "A new Classroom Course Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            DocumentPage.ClickButton_CheckIn();

        }
        
        [Test, Order(3)]
        public void a03_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_SCROM_52240()
        {

            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(scormtitle + "TC52240");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            DocumentPage.ClickButton_CheckIn();
        }
       
        [Test, Order(4)]
        public void a04_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_AICC_52241()
        {

            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC52241");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            DocumentPage.ClickButton_CheckIn();

        }
      
        [Test, Order(5)]
        public void a05_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_Bundle_52242()
        {

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "_TC52242");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            DocumentPage.ClickButton_CheckIn();
        }
   
        [Test, Order(6)]
        public void a06_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_Curriculum_52243()
        {

            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "_TC52243");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            DocumentPage.ClickButton_CheckIn();

        }

        [Test, Order(18)] //depend on 52243
        public void a18_As_a_Learner_view_Equivalent_Items_to_a_Curriculum_27167()
        {
            CommonSection.SearchCatalog(curriculamtitle + "_TC52243");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC52243");
            Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());
        }
        [Test, Order(7)]
        public void a07_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_OJT_52246()
        {

            CommonSection.CreateLink.OJT();
            _test.Log(Status.Info, "Naviagte to Cretae OJT page");
            CreateojtPage.CreteNewOJT(OJTTitle + "TC52246");
            _test.Log(Status.Info, "A new OJT Created");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");

        }

        [Test, Order(8)]
        public void a08_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_Classroom_52247()
        {

            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC52247");
            _test.Log(Status.Info, "A new Classroom Course Created");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
//           DocumentPage.ClickButton_CheckIn();
        }

      [Test, Order(9)]
        public void a09_As_an_admin_managing_equivalencies_I_want_to_find_content_to_add_as_a_new_equivalency_for_Survey_52244()
        {

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Manage >> Survey page");

            SurveysPage.CreateNewSurvey(surveyTitle + "_TC52244");
            _test.Log(Status.Info, "A new Survey Created");

            ContentDetailsPage.click_Surveylink();
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
           // DocumentPage.click_publish();

        }
        //[Test,Order(21)]
        //public void a21_As_a_Learner_view_Equivalent_Items_to_a_Survey_27169()
        //{
        //    CommonSection.SearchCatalog(surveyTitle + "_TC52244");
        //    SearchResultsPage.ClickCourseTitle(surveyTitle + "_TC52244");
        //    Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());

        //}
        [Test, Order(10)]
        public void a10_As_an_admin_setting_an_equivalency_I_want_to_choose_to_whom_Job_Title_the_equivalency_applies_52259()
        {

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC52259", generalcoursetitle + "TC52259");
            _test.Log(Status.Info, "Content Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            EquivalenciesPage.Resultgrid.click_ApplaytoManagelinkof(EquivalencyName);
            Assert.IsTrue(EquivalenciesManageGroupsEditPage.isExistingUseddisplay("No"));
            EquivalenciesManageGroupsEditPage.Click_Changebutton();
            Assert.IsTrue(EquivalenciesManageGroupsEditPage.isAddUsermodalOpened());
            EquivalenciesManageGroupsEditPage.addUserModal.addUser("Job Title", "job");
            Assert.IsTrue(Driver.comparePartialString("The users/groups were added for the equivalency", Driver.getSuccessMessage()));
            
            EquivalenciesManageGroupsEditPage.click_Equivalencies_breadcrumb();
            Assert.IsTrue(EquivalenciesPage.Resultgrid.verifyquivalenciesApplayedto("Job Titles", EquivalencyName));
        }
        [Test, Order(11)]
        public void a11_As_an_admin_setting_an_equivalency_I_want_to_choose_to_whom_Organization_the_equivalency_applies_52260()
        {

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC52260", generalcoursetitle + "TC52260");
            _test.Log(Status.Info, "Content Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            EquivalenciesPage.Resultgrid.click_ApplaytoManagelinkof(EquivalencyName);
            EquivalenciesManageGroupsEditPage.isExistingUseddisplay("No");
            EquivalenciesManageGroupsEditPage.Click_Changebutton();
            Assert.IsTrue(EquivalenciesManageGroupsEditPage.isAddUsermodalOpened());
            EquivalenciesManageGroupsEditPage.addUserModal.addUser("Organization", "org");
            Assert.IsTrue(Driver.comparePartialString("The users/groups were added for the equivalency", Driver.getSuccessMessage()));
            EquivalenciesManageGroupsEditPage.click_Equivalencies_breadcrumb();
            Assert.IsTrue(EquivalenciesPage.Resultgrid.verifyquivalenciesApplayedto("Organization", EquivalencyName));
        }
        [Test, Order(12)]
        public void a12_As_an_admin_setting_an_equivalency_I_want_to_choose_to_whom_User_the_equivalency_applies_52261()
        {

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC52261", generalcoursetitle + "TC52261");
            _test.Log(Status.Info, "Content Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            EquivalenciesPage.Resultgrid.click_ApplaytoManagelinkof(EquivalencyName);
            EquivalenciesManageGroupsEditPage.isExistingUseddisplay("No");
            EquivalenciesManageGroupsEditPage.Click_Changebutton();
            Assert.IsTrue(EquivalenciesManageGroupsEditPage.isAddUsermodalOpened());
            EquivalenciesManageGroupsEditPage.addUserModal.addUser("User", "user");
            Assert.IsTrue(Driver.comparePartialString("The users/groups were added for the equivalency", Driver.getSuccessMessage()));
            EquivalenciesManageGroupsEditPage.click_Equivalencies_breadcrumb();
            Assert.IsTrue(EquivalenciesPage.Resultgrid.verifyquivalenciesApplayedto("User", EquivalencyName));
        }
        [Test, Order(13)]
        public void a13_As_an_Admin_I_can_see_whether_there_are_equivalencies_set_and_how_many_52245()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC52245", generalcoursetitle + "TC52245");
            _test.Log(Status.Info, "Content Created");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.NoEquivalenciesadded("No equivalencies are currently assigned."));
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            EquivalenciesPage.ClickBreadcrumb_ContentTitle(generalcoursetitle + "TC52245");
            Assert.IsTrue(ContentDetailsPage.Equivalencies.AssignedEquivalenciesCount() >= 1);
            _test.Log(Status.Pass, "Verify 1 equivalencies content added");
        }
        [Test, Order(14)]
        public void a14_As_an_Admin_I_can_remove_a_user_entity_from_an_equivalency_52342()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC52342", generalcoursetitle + "TC52342");
            _test.Log(Status.Info, "Content Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            EquivalenciesPage.Resultgrid.click_ApplaytoManagelinkof(EquivalencyName);
            EquivalenciesManageGroupsEditPage.isExistingUseddisplay("No");
            EquivalenciesManageGroupsEditPage.Click_Changebutton();
            Assert.IsTrue(EquivalenciesManageGroupsEditPage.isAddUsermodalOpened());
            EquivalenciesManageGroupsEditPage.addUserModal.addUser("User", "user");
            Assert.IsTrue(Driver.comparePartialString("The users/groups were added for the equivalency", Driver.getSuccessMessage()));
            EquivalenciesManageGroupsEditPage.Selectuserentity();
            EquivalenciesManageGroupsEditPage.Click_Remove();
            Assert.IsTrue(EquivalenciesManageGroupsEditPage.RemoveUsersModal.Confirmmessage("Are you sure you want to remove the selected users? This cannot be undone."));
            EquivalenciesManageGroupsEditPage.RemoveUsersModal.Click_Remove();
            Assert.IsTrue(Driver.comparePartialString("The users/groups were removed from the equivalency", Driver.getSuccessMessage()));



        }

    }


}


