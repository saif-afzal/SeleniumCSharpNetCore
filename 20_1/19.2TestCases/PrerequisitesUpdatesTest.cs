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
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_PrerequisitesUpdatesTest2 : TestBase
    {
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string BunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string SCORMTitle = "SCORM" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;
        int AssignedPrequisiteCount;

        public P1_PrerequisitesUpdatesTest2(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }



        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        


        [Test, Order(01)]
        public void PR01_As_an_admin_In_General_Course_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56941()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC56941");
            _test.Log(Status.Info, "Create a general Course");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

        }
        [Test, Order(2)]
        public void PR02_As_an_admin_In_AICC_I_want_to_see_Add_Prquisite_Modal_loads_with_available_Content_Displayed_56942()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC56942");
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }
        [Test, Order(03)]
        public void PR03_As_an_admin_In_Classroom_course_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56943()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC56943");
            _test.Log(Status.Pass, "New Classroom Course Created");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }

        [Test, Order(04)]
        public void PR04_As_an_admin_In_SCORM_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56944()
        {
            CommonSection.CreteNewScorm(SCORMTitle + "TC56944");
            _test.Log(Status.Info, "Create a Scorm Course");
            ContentDetailsPage.Click_CheckOut();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }
        [Test, Order(05)]
        public void PR05_As_an_admin_In_Document_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56967()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC56967");
            _test.Log(Status.Info, "Create a Document Course");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }

        [Test, Order(06)]
        public void PR06_As_an_admin_In_Bundle_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56968()
        {
            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", BunbdleTitle + "TC56968", "Bundle Price");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }

        [Test, Order(07)]
        public void PR07_As_an_admin_In_Certification_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56969()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC56969");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }

        [Test, Order(08)]
        public void PR08_As_an_admin_In_Curriculum_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56970()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC56970");
            _test.Log(Status.Info, "Create Curriculum");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }

        [Test, Order(09)]
        public void PR09_As_an_admin_In_On_The_Job_Training_I_want_to_see_Add_Prerequisite_Modal_loads_with_available_Content_Displayed_56971()
        {
            CommonSection.CreateNewOJT(OJTTitle + "TC56971");
            _test.Log(Status.Info, "Create Curriculum");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
        }

        [Test, Order(10)]
        public void PR10_As_an_admin_I_want_to_Assign_Prerequisites_in_General_Course_and_want_to_see_its_Count_on_Admin_content_details_Page_56978()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC56978");
            _test.Log(Status.Info, "Create a general Course");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify assigned Prerequisites matches the count");
        }
        [Test, Order(11)]
        public void PR11_As_an_admin_I_want_to_Assign_Prerequisites_in_Curriculum_and_want_to_see_its_Count_on_Admin_content_details_Page_56977()
        {
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "_TC56977");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify assigned Prerequisites matches the count");
        }
        [Test, Order(12)]
        public void PR12_As_an_admin_I_want_to_Assign_Prerequisites_in_AICC_and_want_to_see_its_Count_on_Admin_content_details_Page_56979()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC56979");
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify Assigned Prerequisites is equal to Panel count");
        }

        [Test, Order(13)]
        public void PR13_As_an_admin_I_want_to_Assign_Prerequisites_in_Classroom_course_and_want_to_see_its_Count_on_Admin_content_details_Page_56980()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC56980");
            _test.Log(Status.Pass, "New Classroom Course Created");


            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify Assigned Prerequisites is equal to Panel count");
        }

        [Test, Order(14)]
        public void PR14_As_an_admin_I_want_to_Assign_Prerequisites_in_SCORM_and_want_to_see_its_Count_on_Admin_content_details_Page_56981()
        {
            CommonSection.CreteNewScorm(SCORMTitle + "TC56981");
            _test.Log(Status.Info, "Create a Scorm Course");

            ContentDetailsPage.Click_CheckOut();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify Assigned Prerequisites is equal to Panel count");

        }

        [Test, Order(15)]
        public void PR15_As_an_admin_I_want_to_Assign_Prerequisites_in_Document_and_want_to_see_its_Count_on_Admin_content_details_Page_56982()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC56982");
            _test.Log(Status.Info, "Create a Document Course");


            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify Assigned Prerequisites is equal to Panel count");

        }

        [Test, Order(16)]
        public void PR16_As_an_admin_I_want_to_Assign_Prerequisites_in_Bundle_and_want_to_see_its_Count_on_Admin_content_details_Page_56983()
        {
            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", BunbdleTitle + "TC56983", "Bundle Price");


            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify Assigned Prerequisites is equal to Panel count");

        }

        [Test, Order(17)]
        public void PR17_As_an_admin_I_want_to_Assign_Prerequisites_in_On_The_Job_Training_and_want_to_see_its_Count_on_Admin_content_details_Page_56984()
        {
            CommonSection.CreateNewOJT(OJTTitle + "TC56984");
            _test.Log(Status.Info, "Create OJT");


            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.",ContentDetailsPage.getInformativeMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            string prereqcount = PrerequisitesPage.PrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisiteCount(prereqcount));
            _test.Log(Status.Pass, "Verify Assigned Prerequisites is equal to Panel count");


        }
        [Test, Order(18)]
        public void PR18_As_an_admin_I_want_to_see_Assigned_Prerequisites_Valid_period_Target_Score_and_Date_added_on_manage_Prerequisite_Page_57102()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC57102");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.",ContentDetailsPage.getInformativeMessage()));
            StringAssert.AreEqualIgnoringCase("Success\r\nThe selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesValidPeriod());
            _test.Log(Status.Pass, "Verify Prerequisites valid Period is displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesTargetScoreIsDisplayed());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
        }

        [Test, Order(19)]
        public void PR19_As_an_admin_I_want_to_Delete_Assigned_Prerequisites_on_manage_Prerequisite_Page_57104()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC57104");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.",ContentDetailsPage.getInformativeMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            int AssignedPrequisiteCount = PrerequisitesPage.VerifyPrerequisitesAdded();
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesValidPeriod());
            _test.Log(Status.Pass, "Verify Prerequisites valid Period is displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesTargetScoreIsDisplayed());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            //Assert.IsFalse(PrerequisitesPage.VerifyDeleteButtonisEnabled());
            //_test.Log(Status.Pass, "Verify Delete button is enabled");
            PrerequisitesPage.SelectAssignedPrerequsites();
            _test.Log(Status.Info, "Select Assigned prerequisites to Delete");
            Assert.IsTrue(PrerequisitesPage.VerifyDeleteButtonisEnabled());
            _test.Log(Status.Pass, "Verify Delete button is enabled");
            PrerequisitesPage.ClickDeleteButton();
            _test.Log(Status.Info, "Click Delete button");
            Assert.IsTrue(PrerequisitesPage.VerifyAlertBoxisDisplayed());
            _test.Log(Status.Pass, "Verify AlertBox is Displayed");
            PrerequisitesPage.ClickOKofAlertBox();
            _test.Log(Status.Info, "Click Delete button");
//            StringAssert.AreEqualIgnoringCase("Success\r\n The selected items were removed and are no longer prerequisites.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyAssignedPrerequisitesareDeleted(AssignedPrequisiteCount));


        }
        [Test, Order(20)]
        public void PR20_As_an_admin_I_want_to_add_Target_score_and_Valid_Period_to_the_Assigned_Prerequisites_on_manage_Prerequisite_Page_57105()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC57105");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
          
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.",ContentDetailsPage.getInformativeMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesDateAddedOn());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            PrerequisitesPage.ClickValidPeriodHotLink();
            _test.Log(Status.Info, "Click Valid period Hot link against content");
            Assert.IsTrue(PrerequisitesPage.VerifySaveDateTextBoxIsDisplayed());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            //_test.Log(Status.Info, "enter the date and Save the Date");
            Assert.IsTrue(PrerequisitesPage.VerifyEnteredDateIsSaved("15"));
            _test.Log(Status.Pass, "Verify Entered date is saved");
            PrerequisitesPage.ClickTargetScoreHotLink();
            _test.Log(Status.Info, "Click Valid period Hot link against content");
            Assert.IsTrue(PrerequisitesPage.VerifySaveTargetScoreTextBoxIsDisplayed());
            _test.Log(Status.Pass, "Verify date on which the Prerequisites Added on are displayed");
            PrerequisitesPage.EnterTargetScoreAndSaveTheTargetScore("20");
            _test.Log(Status.Info, "enter the date and Save the Date");
            Assert.IsTrue(PrerequisitesPage.VerifyEnteredTargetScoreIsSaved("20"));
            _test.Log(Status.Pass, "Verify Entered date is saved");

        }
        [Test, Order(21)]
        public void tc_58832_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_AICC_Course()
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
            CreateAICCPage.Title(AICCTitle + "TC58832");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
           // PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
           // _test.Log(Status.Info, "Set Valid Period value as 0");
           // Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
          //  _test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }
        [Test, Order(22)]
        public void tc_58839_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_General_Course()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC58839");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }
        [Test, Order(23)]
        public void P20_1_tc_58840_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_SCROM_Course()
        {
            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(SCORMTitle + "TC58840");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }
        [Test, Order(24)]
        public void tc_58841_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_Classroom_Course()
        {
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC58841");
            _test.Log(Status.Info, "A new Classroom Course Created");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }
        [Test, Order(25)]
        public void tc_58842_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_documnet()
        {
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC58842");
            _test.Log(Status.Info, "A new Document Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");

        }
        [Test, Order(26)]
        public void tc_58843_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_Certification()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC58843");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }
        [Test, Order(27)]
        public void tc_58844_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_Curriculums()
        {
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "_TC58844");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }
        [Test, Order(28)]
        public void tc_58845_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_Bundle()
        {
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(BunbdleTitle + "_TC58845");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }
        [Test, Order(29)]
        public void tc_58846_As_an_admin_I_want_to_update_Valid_Period_interaction_for_prerequisites_in_Survey()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Manage >> Survey page");

            SurveysPage.CreateNewSurvey(surveyTitle + "_TC58846");
            _test.Log(Status.Info, "A new Survey Created");

            ContentDetailsPage.click_Surveylink();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            _test.Log(Status.Pass, "Verify Always link display for Valid Period culumn");
            //PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("0");
            //_test.Log(Status.Info, "Set Valid Period value as 0");
            //Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isAlwayslinkdisplay());
            //_test.Log(Status.Pass, "Verify 0 should not saved and Always link display for Valid Period culumn again");
            PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.SetCustomdays("15");
            _test.Log(Status.Info, "Set Valid Period value as 15");
            Assert.IsTrue(PrerequisitesPage.PrerequisiteresultTable.ValidPeriod.isCustomlinkdisplay());
            _test.Log(Status.Pass, "Verify values saved and custom link display for Valid Period culumn again");
        }


    }
}