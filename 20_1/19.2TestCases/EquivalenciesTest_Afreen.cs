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
using TestAutomation;
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
    public class P1_EquivalenciesTest_Afreen1 : TestBase
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
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;

        public P1_EquivalenciesTest_Afreen1(string browser)
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
   


       
        [Test,Order(01)]
        public void a01_As_an_admin_manage_equivalencies_for_content_General_Course_52292()
        // Pre-req: General Course created with equivaliencies
        {
            #region  Pre-req: General Course created with equivaliencies
            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC52292");
            _test.Log(Status.Info, "Create a general Course");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");

            #endregion


            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(generalcoursetitle + "TC52292");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(generalcoursetitle + "TC52292"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(generalcoursetitle + "TC52292");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();
            
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by "  + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();
        }


        [Test, Order(02)]
        public void a02_As_an_admin_manage_equivalencies_for_content_SCORM_52293()
        //Pre-req: Scorm Course created with equivaliencies
        {
            #region  Pre-req: Scorm created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies " + "Scorm");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            CommonSection.CreteNewScorm(SCORMTitle + "TC52293");
            _test.Log(Status.Info, "Create a Scorm Course");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies " + "Scorm");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies " + "Scorm"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(SCORMTitle + "TC52293");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(SCORMTitle + "TC52293"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(SCORMTitle + "TC52293");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies " + "Scorm"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();

            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();

        }
        [Test, Order(03)]
        public void a03_As_an_admin_manage_equivalencies_for_content_Document_52291()
        // Pre-req: Document created with equivaliencies
        {
            #region  Pre-req: Document created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies " + "Document");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC52291");
            _test.Log(Status.Info, "Create a Document Course");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies " + "Document");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies " + "Document"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(DocumentTitle + "TC52291");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(DocumentTitle + "TC52291"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(DocumentTitle + "TC52291");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies " + "Document"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();

            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();

        }
        [Test, Order(04)]
        public void a04_As_an_admin_manage_equivalencies_for_content_Classroom_52289()
        // Pre-req: Classroom Course created with equivaliencies
        {
            #region  Pre-req: Classroom created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies " + "Classroom");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC52289");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies " + "Classroom");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies " + "Classroom"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(classroomcoursetitle + "TC52289");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(classroomcoursetitle + "TC52289"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(classroomcoursetitle + "TC52289");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies " + "Classroom"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();

            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();



        }
        [Test, Order(05)]
        public void a05_As_an_admin_manage_equivalencies_for_content_AICC_52287()
        // Pre-req: AICC Course created with equivaliencies
        {

            #region  Pre-req:AICC created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies " + "AICC");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC52287");
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies " + "AICC");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies " + "AICC"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(AICCTitle + "TC52287");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(AICCTitle + "TC52287"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(AICCTitle + "TC52287");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies " + "AICC"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();

            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();



        }
        [Test, Order(06)]
        public void a06_As_an_admin_manage_equivalencies_for_content_Curriculum_52290()
        // Pre-req: Curriculum created with equivaliencies
        {
            #region  Pre-req: Curriculum created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies " + "Curriculum");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC52290");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies " + "Curriculum");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies " + "Curriculum"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(curriculamtitle + "TC52290");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(curriculamtitle + "TC52290"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(curriculamtitle + "TC52290");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies " + "Curriculum"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();

            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();

        }
        [Test, Order(07)]
        public void a07_As_an_admin_manage_equivalencies_for_content_Bundles_52288()
        // Pre-req: Bundles created with equivaliencies
        {
            #region  Pre-req: Bundles created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies " + "Bundles");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", BunbdleTitle + "TC52288", "Bundle Price");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies " + "Bundles");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies " + "Bundles"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(BunbdleTitle + "TC52288");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(BunbdleTitle + "TC52288"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(BunbdleTitle + "TC52288");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies " + "Bundles"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();

            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();

        }
        [Test, Order(08)]
        public void a08_As_an_admin_manage_equivalencies_for_content_Survey_52305()
        // Pre-req: Surveys created with equivaliencies
        {

            #region  Pre-req: Survey created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "For_Equivalencies " + "Survey");
            _test.Log(Status.Info, "Create a general Course");
            string Equivalency = EquivalenciesPage.Equivalency();
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Checkin Button");

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC52305");
            _test.Log(Status.Info, "A new Survey Created");
            CreateSurveypage.Click_SurveyTab();
            _test.Log(Status.Info, "Click survey tab");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddEquivalencies(generalcoursetitle + "For_Equivalencies " + "Survey");
            _test.Log(Status.Info, "Add Equivalency to the Course");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isEquivalenciesadded(generalcoursetitle + "For_Equivalencies " + "Survey"));
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(surveyTitle + "TC52305");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(surveyTitle + "TC52305"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(surveyTitle + "TC52305");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyEquivalencyContentdisplayed(generalcoursetitle + "For_Equivalencies " + "Survey"));
            _test.Log(Status.Pass, "Verify is any existing equivalencies content display");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDateAddedDisplayed());
            _test.Log(Status.Pass, "Verify the Date the equivalency was added is displayed in Date Added column");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship by default");

            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("↔ 2-way"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("→ 1-way only");
            _test.Log(Status.Info, "Select ->1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify ->1-WayOnly relationship is now displayed");
            string Content = EquivalenciesPage.Content();

            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " is satisfied by " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for ->1-WayOnly relationship is now displayed under the relationship");


            EquivalenciesPage.Resultgrid.Click_Relationship();
            _test.Log(Status.Info, "Click 2-Way dropdown from relationship column for a content");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDropdownDisplayed("→ 1-way only"));
            _test.Log(Status.Pass, "Verify clicking on 2-way relationship, expanded to dropdown");
            EquivalenciesPage.Resultgrid.Select("← 1-way only");
            _test.Log(Status.Info, "Select <-1-way Only dropdown option from relationship column for a content and click on Save");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyRelationship("1-way only"));
            _test.Log(Status.Pass, "Verify <-1-WayOnly relationship is now displayed");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.VerifyDescriptionText(Content + " satisfies " + Equivalency)); //Description as "Satisfies XXXXXX" -> (Course name)
            _test.Log(Status.Pass, "Verify Description text for <-1-WayOnly relationship is now displayed under the relationship");
            //ContentDetailsPage.DeleteContent();

        }
        [Test, Order(09)]
        public void a09_As_an_admin_remove_equivalencies_from_a_content_General_Course_52323()
        // Pre-req: General Course created with equivaliencies content added
        {
            #region  Pre-req: Survey created with equivaliencies

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC52323");
            _test.Log(Status.Info, "Create a general Course");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(generalcoursetitle + "TC52323");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(generalcoursetitle + "TC52323"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(generalcoursetitle + "TC52323");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            ContentDetailsPage.DeleteContent();


        }
        [Test, Order(10)]
        public void a10_As_an_admin_remove_equivalencies_from_a_content_SCORM_52325()
        // Pre-req: Scorm Course created with equivaliencies
        {
            #region  Pre-req: SCORM created with equivaliencies

            CommonSection.CreteNewScorm(SCORMTitle + "TC52325");
            _test.Log(Status.Info, "Create a Scorm Course");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(SCORMTitle + "TC52325");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(SCORMTitle + "TC52325"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(SCORMTitle + "TC52325");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            ContentDetailsPage.DeleteContent();

        }
        [Test, Order(11)]
        public void a11_As_an_admin_remove_equivalencies_from_a_content_Document_52322()
        // Pre-req: Document created with equivaliencies
        {

            #region  Pre-req: Document created with equivaliencies

            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC52322");
            _test.Log(Status.Info, "Create a Document Course");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(DocumentTitle + "TC52322");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(DocumentTitle + "TC52322"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(DocumentTitle + "TC52322");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            ContentDetailsPage.DeleteContent();

        }
        [Test, Order(12)]
        public void a12_As_an_admin_remove_equivalencies_from_a_content_Classroom_52320()
        // Pre-req: Classroom Course created with equivaliencies
        {
            #region  Pre-req: Classroom created with equivaliencies

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC52320");
            _test.Log(Status.Pass, "New Classroom Course Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(classroomcoursetitle + "TC52320");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(classroomcoursetitle + "TC52320"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(classroomcoursetitle + "TC52320");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            ContentDetailsPage.DeleteContent();

        }
        [Test, Order(13)]
        public void a13_As_an_admin_remove_equivalencies_from_a_content_AICC_52318()
        // Pre-req: AICC Course created with equivaliencies
        {
            #region  Pre-req: AICC created with equivaliencies
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC52318");
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion


            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(AICCTitle + "TC52318");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(AICCTitle + "TC52318"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(AICCTitle + "TC52318");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            ContentDetailsPage.DeleteContent();
     

        }
        [Test, Order(14)]
        public void a14_As_an_admin_remove_equivalencies_from_a_content_Curriculum_52321()
        // Pre-req: Curriculum created with equivaliencies
        {

            #region  Pre-req: Curriculum created with equivaliencies

            CommonSection.CreteNewCurriculumn(curriculamtitle + "52321");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion


            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(curriculamtitle + "52321");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(curriculamtitle + "52321"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(curriculamtitle + "52321");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            ContentDetailsPage.DeleteContent();


        }
        [Test, Order(15)]
        public void a15_As_an_admin_remove_equivalencies_from_a_content_Bundle_52319()
        // Pre-req: Bundles created with equivaliencies
        {
            #region  Pre-req: Bundle created with equivaliencies

            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", BunbdleTitle + "52319", "Bundle Price");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(BunbdleTitle + "52319");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(BunbdleTitle + "52319"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(BunbdleTitle + "52319");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            ContentDetailsPage.DeleteContent();



        }
        [Test, Order(16)]
        public void a16_As_an_admin_remove_equivalencies_from_a_content_Survey_52327()
        // Pre-req: Surveys created with equivaliencies
        {

            #region  Pre-req: Survey created with equivaliencies

            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            SurveysPage.CreateNewSurvey(surveyTitle + "52327");
            _test.Log(Status.Info, "A new Survey Created");
            CreateSurveypage.Click_SurveyTab();
            _test.Log(Status.Info, "Click survey tab");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            EquivalenciesPage.AddEquvalenciesModal.AddAllContentAsEquivalencies();
            _test.Log(Status.Info, "Select all content and Add as equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");

            #endregion

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click Training under Manage");
            TrainingPage.ManageContentPortlet.SearchForContent(surveyTitle + "52327");
            _test.Log(Status.Info, "Search for Content from Manage content Portlet");
            Assert.IsTrue(ManageContentPage.ResultGrid.isSeaarchedContentDisplay(surveyTitle + "52327"));
            _test.Log(Status.Info, "Verify searched Content is Displayed");
            ManageContentPage.ClickContentTitle(surveyTitle + "52327");
            _test.Log(Status.Info, "Click Searched Course Title");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit Equivalencies");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            Assert.IsFalse(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Disabled");
            EquivalenciesPage.Resultgrid.SelectFirstContent();
            _test.Log(Status.Info, "Select first Content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");

            EquivalenciesPage.Resultgrid.SelectAllEquivalenciesContent();
            _test.Log(Status.Info, "Select All Equivalencies content from table");
            Assert.IsTrue(EquivalenciesPage.RemoveButtonEnabled());
            _test.Log(Status.Info, "verify Remove Button is Enabled");
            EquivalenciesPage.RemoveEquivalencies();
            _test.Log(Status.Info, "Click remove Button and Click OK In alert box to remove Equivalencies");
            Assert.IsTrue(Driver.comparePartialString("The items were removed. They are not equivalencies.", EquivalenciesPage.RemoveSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message is displayed");
            Assert.IsFalse(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "verify Equivalencies are Added");
            ContentDetailsPage.DeleteContent();



        }

   

    }
}