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
    public class P1NavigationBrandingAndCustomizationTest : TestBase
    {
        string browserstr = string.Empty;
        public P1NavigationBrandingAndCustomizationTest(string browser)
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
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string documenttitle = "Doc" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        string bunbdleTitle="Bndl"+ Meridian_Common.globalnum;
        string AICCTitle="AICC"+ Meridian_Common.globalnum;
        string surveyTitle= "Survey" + Meridian_Common.globalnum;

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }


  
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
   
      
        [Test]
        public void a01_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_General_Course_35415()
        {

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Navigate to Create General Course");
            Assert.IsTrue(GeneralCoursePage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Online");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35415", generalcoursetitle + "TC35415");
            _test.Log(Status.Info, "A new Genaral Course Created");
           
            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC35415" + '"');
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35415");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a02_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_Classroom_Course_35416()
        {
          
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            Assert.IsTrue(ClassroomCourse.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Classroom");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35416");
            _test.Log(Status.Info, "A new Classroom Course Created");

            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC35416" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35416");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }

        [Test]
        public void a03_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_Document_35419()
        {
           
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            Assert.IsTrue(DocumentPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CommonSection.CreteNewDocuemnt(documenttitle + "TC35419");
            _test.Log(Status.Info, "A new Classroom Course Created");
          
            CommonSection.SearchCatalog('"' + documenttitle + "TC35419" + '"');
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC35419");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click Edit Content ");

            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a04_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_AICC_35417()
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
            CreateAICCPage.Title(AICCTitle + "35417");
            Assert.IsTrue(CreateAICCPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Veified Display format for AICC Course");

            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
          
            CommonSection.SearchCatalog('"' + AICCTitle + "35417" + '"');
            SearchResultsPage.ClickCourseTitle(AICCTitle + "35417");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue("Survey");
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click Edit Content ");

            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a05_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_SCROM_35418()
        {
         
            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(scormtitle + "TC35418");
            Assert.IsTrue(DocumentPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Online");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
          
            CommonSection.SearchCatalog('"' + scormtitle + "TC35418" + '"');
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35418");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click Edit Content ");

            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a06_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_Survey_35420()
        {
           
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Cretae Survey page");
            Assert.IsTrue(DocumentPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            SurveysPage.CreateNewSurvey(surveyTitle + "TC35420"); 

            _test.Log(Status.Info, "A new Survey Created");
         
            CommonSection.Manage.SurveysAndEvaluations();
            SurveysPage.SearchSurvey(surveyTitle + "TC35420");
            SurveysPage.SurveyResults.ClickSearchedSurveyTilte(surveyTitle + "TC35420");
            //CommonSection.SearchCatalog('"' + surveyTitle + "TC35420" + '"');
            // SearchResultsPage.ClickCourseTitle(surveyTitle + "TC35420");
            //  _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            //   ContentDetailsPage.ClickEditContent();
            //  _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a07_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_Bundle_35421()
        {
    
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "TC35421");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            Assert.IsTrue(CreatebundlePage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CreatebundlePage.ClickCreatebutton();

            _test.Log(Status.Info, "A new Bundle Created");
        
            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC35421" + '"');
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35421");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a08_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_Certification_35422()
        {
     
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC35422");
            _test.Log(Status.Info, "Fill title");
            Assert.IsTrue(CertificationPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
        
            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35422" + '"');
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35422");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdownForCert.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a09_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_Curriculums_35423()
        {
      
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "TC35423");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            Assert.IsTrue(CreateCurriculumnPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Curriculum");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
         
            CommonSection.SearchCatalog('"' + curriculamtitle + "TC35423" + '"');
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35423");

            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a10_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_OJT_35424()
        {
        
            CommonSection.CreateLink.OJT();
            _test.Log(Status.Info, "Naviagte to Cretae OJT page");
            Assert.IsTrue(CreateojtPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is On-the-Job Training");
            CreateojtPage.CreteNewOJT(OJTTitle + "TC35424");
            _test.Log(Status.Info, "A new OJT Created");
        
            CommonSection.SearchCatalog('"' + OJTTitle + "TC35424" + '"');
            SearchResultsPage.ClickCourseTitle(OJTTitle + "TC35424");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            //ContentDetailsPage.ClickEditContent();
            //_test.Log(Status.Info, "Click Edit Content ");

            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
        [Test]
        public void a11_I_want_to_set_a_display_format_for_a_content_item_that_is_different_from_its_content_type_Subscriptions_35425()
        {
       
            CommonSection.CreateLink.Subscription();
            _test.Log(Status.Info, "Naviagte to Cretae Subscription page");
            Assert.IsTrue(CreatesubscriptionPage.DisplayFormatDropdown.isDefaultvaluedisplay());
            _test.Log(Status.Pass, "Verify Default value of Display Format is Document");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC35425").SubscriptionType("Dynamic Date").Create();
            _test.Log(Status.Info, "Create a new Subscriptions");
         
            CommonSection.SearchCatalog('"' + SubscriptionsTitle + "TC35425" + '"');
            SearchResultsPage.ClickCourseTitle(SubscriptionsTitle + "TC35425");
            _test.Log(Status.Info, "Search Content from Catalog and Click on Content Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content button");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click on Summary accordian Edit button");
            string DisplayFormatText = EditSummaryPage.DisplayFormatDropdown.SelectedText();
            EditSummaryPage.DisplayFormatDropdown.SelectanotherValue();
            _test.Log(Status.Info, "Select a new value for Deisplay Format dropdown");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", ContentDetailsPage.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            ContentDetailsPage.Accordians.ClickEdit_Summary();
            _test.Log(Status.Info, "Click Edit Summary button");
            Assert.IsFalse(EditSummaryPage.DisplayFormatDropdown.VerfySelectedText(DisplayFormatText));
            _test.Log(Status.Pass, "Match Display format value");
        }
    
        [Test]
        public void a12_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Career_Development_35566()
        //Pre-Req: Development Plan with Competency is created
        {
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Verify Professional Development Page is displayed ");
            CareerDevelopmentPage.DevelopmentPlansSection.ClickCreatePlan();
            _test.Log(Status.Info, "Verify Development Plan Page is displayed ");
            DevelopmentPlanPage.ProfecionalFocus.ClickAddContent();
            AddDevelopmentActivityPage.ClickSearchbutton();
            Assert.IsTrue(AddDevelopmentActivityPage.Content.ContentTypeisDisplay("DisplayFormat"));
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Development Plan page");
            AddDevelopmentActivityPage.AddContent();
            Assert.IsTrue(DevelopmentPlanPage.ProfecionalFocus.ContentTypeisDisplay("DisplayFormat"));
            DevelopmentPlanPage.ProfessionalFocusSection.ClickContentListTrashIcon();
            _test.Log(Status.Pass, "Click on the Trash icon for the Content");

            //Assert.IsTrue(ConfirmationModal.ContentType = DisplayFormat);
            //_test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Confirmation modal");
            //DevelopmentPlanPage.ProfessionalFocusSection.ClickonCompetencyTitle();
            //_test.Log(Status.Info, "On the Development Plan Page, Professional Focus Section, click on the Competency Title");
            //Assert.IsTrue(CompetencyModal.MandatoryTab.ContentList.TypeColumn.ContentType = DisplayFormat);
            //_test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Mandatory Tab");
            //CompetencyModal.ClickSupplementalTab();
            //_test.Log(Status.Info, "On the Competency Modal, select the Supplemental tab");
            //Assert.IsTrue(CompetencyModal.SupplementalTab.ContentList.TypeColumn.ContentType = DisplayFormat);
            //_test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Supplemental Tab");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Click Career development from learn");

            CareerDevelopmentPage.ClickExploreCareersbutton();
            Assert.IsTrue(CareerNavigatorPage.isJobCarddisplay());
            _test.Log(Status.Info, "Verify Career Navigator Landing Page is displayed with Job Cards");
            CareerNavigatorPage.ClickSearchIcon();
            _test.Log(Status.Info, "Click search icon");

            CareerNavigatorPage.SearchwithJobTitleAs("PrimaryJob_Title_Demo_2006").ClickSearchIcon();
            CareerNavigatorPage.ClickJobtitleName();
            _test.Log(Status.Info, "On the Career Navigator page, Click on the Job Card");
            Assert.IsTrue(CareerNavigatorPage.JobDetailModel.VerifyCompetenciesInProgressTabCount());
            _test.Log(Status.Info, "Verify JobCard Modal with InProgress Tab is displayed");
            CareerNavigatorPage.JobDetailModel.ClickCompetenciesInProgressTab();
            _test.Log(Status.Info, "On the Job Card Modal, Click on the Competency Link and click on content");
            //CareerNavigatorPage.CompetencyDetailsModal.SupplementalTab.ClickSupplemental();
            //Assert.IsTrue(CareerNavigatorPage.CompetencyDetailsModal.isContentTypeDisplay("DisplayFormat"));
            //_test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Mandatory Tab");
            CareerNavigatorPage.CompetencyDetailsModal.ClickSupplementalTab();
            _test.Log(Status.Info, "On the Competency Modal, select the Supplemental tab");
            Assert.IsTrue(CareerNavigatorPage.CompetencyDetailsModal.SupplementalTab.isContentTypedisplay("DisplayFormat"));
            _test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content in Competency modal - Supplemental Tab");
        }

        [Test]
        public void a13_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Current_Training_35554()

        {
            CommonSection.Learn.CurrentTraining();
            Assert.IsTrue(CurrentTrainingPage.ContentList.isContentTypeDisplay("DisplayFormat"));
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Current Training Page");

        }

        [Test]
        public void a14_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Public_Catalog_35565()

        {
            CommonSection.Avatar.Logout();
            _test.Log(Status.Info, "Verify User is logged Out");
            //LoginPage.Login();
            _test.Log(Status.Info, "Click Login");

            LoginPage.ClickBrowsePublicCatalogLink();
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search result is display");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.isContentTypeDisplay("DisplayFormat"));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format in Public Catalog");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.isContentTypeIconDisplay("DisplayFormatIcon"));
            _test.Log(Status.Pass, "Verify Content Type Icon is replaced by Display Format Icon (if there is no picture) for all Content in Public Catalog");


        }
        [Test]
        public void a15_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Catalog_Search_Results_35564()

        {
            //CommonSection.Avatar.Logout();
            //_test.Log(Status.Info, "Verify User is logged Out");
            SearchResultsPage.Login();
            _test.Log(Status.Info, "Click Login");

            // CommonSection.ClickLogin_PublicCatalog();
            LoginPage.ClickBrowsePublicCatalogLink();
            SearchResultsPage.Login();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.SearchCatalog("dolly");
            _test.Log(Status.Info, "Search dolly from Catalog search ");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("dolly") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search result is display");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.isContentTypeDisplay("DisplayFormat"));
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Catalog Search Results page");

        }
        [Test]
        public void a16_Certification_Promotional_Videos_35352()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC35352");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
        }
        [Test]//Dollys Certification w/ Promo Video_12182018
        public void a17_Learner_Plays_Promotional_Videos_From_Certification_35368()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35352" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC35352" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35352"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
            
            //ManageClassroomCoursePage.DeleteContent(CertificatrTitle + "TC35352");
        }
        [Test]
        public void a18_Subscription_Promotional_Videos_35359()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreateLink.Subscription();
            _test.Log(Status.Info, "Click create>Subscriptions");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC35359").SubscriptionType("Dynamic Date").Create();
            _test.Log(Status.Info, "Create a new Subscriptions");

            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
        }
        [Test]//"Dolly's Subscription w/ Promo Video_12182018"
        public void a19_Learner_Plays_Promotional_Videos_From_Subscription_35377()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + SubscriptionsTitle + "TC35359" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + SubscriptionsTitle + "TC35359" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(SubscriptionsTitle + "TC35359"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
            //ManageClassroomCoursePage.DeleteContent(SubscriptionsTitle + "TC35359");
        }
        [Test]
        public void a20_AICC_Promotional_Videos_35349()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            #region Create AICC Course
            Document documentpage = new Document(driver);
            string expectedresult = "Summary";
            string expectedresult1 = "The course was created.";
            AICC aicccourse = new AICC(driver);
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult1, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]"))));
            aicccourse.populatesummaryform(driver, browserstr);
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            #endregion


            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
        }
       
        [Test]
        public void a22_Bundle_Promotional_Videos_35351()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)


             CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", bunbdleTitle + "TC35351", "Bundle Price");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
        }
        [Test]
        public void a23_Learner_Plays_Promotional_Videos_From_Bundle_35366()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            CommonSection.SearchCatalog(bunbdleTitle + "TC35351"); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + bunbdleTitle + "TC35351" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC35351"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifybundlePromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");

        }
        [Test]
        public void a24_SCORM_Promotional_Videos_35358()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreteNewScorm(scormtitle + "TC35358");
            _test.Log(Status.Info, "Create A new SCROM Course");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
            _test.Log(Status.Info, "Verify Promotional Video preview on content details page");
        }
        [Test]//"Dolly's Scorm 1.2 Course w/ Image and Promo Video_12182018"
        public void a25_Learner_Plays_Promotional_Videos_From_Scorm_Course_35376()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + scormtitle + "TC35358" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + scormtitle + "TC35358" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35358"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
            //ManageClassroomCoursePage.DeleteContent(scormtitle + "TC35358");
        }

        [Test]
        public void a26_OJT_Promotional_Videos_35357()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreateLink.OJT();
            CreateojtPage.CreteNewOJT(OJTTitle + "TC35357");
            //OJT onlinejobtraining = new OJT(driver);
            //string expectedresult = " The item was created.";
            //CommonSection.CreateLink.OJT();
            //onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);

            //string actres = onlinejobtraining.buttoncreateclick(driver);
            //Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            //_test.Log(Status.Info, "Create a new On Job Training");

            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
        }
        [Test]//"Dolly's On The Job Training w/ Promo Video_01102018"
        public void a27_Learner_Plays_Promotional_Videos_From_OJT_35373()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog(OJTTitle + "TC35357"); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + OJTTitle + "TC35357" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(OJTTitle + "TC35357"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");

        }
        [Test]
        public void a28_Document_Promotional_Videos_35355()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreteNewDocuemnt(documenttitle + "TC35355");
            _test.Log(Status.Info, "Create A new Document");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
            _test.Log(Status.Info, "Verify Promotional Video preview on content details page");
        }
        [Test]//"Dolly's Document w/ promo video_12182018"
        public void a29_Learner_Plays_Promotional_Videos_From_Document_35372()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + documenttitle + "TC35355" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + documenttitle + "TC35355" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC35355"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
           // ManageClassroomCoursePage.DeleteContent(documenttitle + "TC35355");
        }

        [Test]
        public void a36_Curriculum_Promotional_Videos_35354()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35354");
            _test.Log(Status.Info, "Create A new Curriculum");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
            _test.Log(Status.Info, "Verify Promotional Video preview on content details page");
        }
        [Test]//"Dolly's Curriculum w/ Promotional Video_12182018"
        public void a37_Learner_Plays_Promotional_Videos_From_Curriculums_35370()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + curriculamtitle + "TC35354" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + curriculamtitle + "TC35354" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35354"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifybundlePromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickbundlePlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
            //ManageClassroomCoursePage.DeleteContent(curriculamtitle + "TC35354");
        }

        [Test]

        public void a30_General_Course_Promotional_Videos_35356()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35356", generalcoursetitle + "TC35356");
            _test.Log(Status.Info, "A new Genaral Course Created");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
            _test.Log(Status.Info, "Verify Promotional Video preview on content details page");
            ContentDetailsPage.ClickCheckInbutton();
        }

        [Test]//"Dolly's General Course w/ promotional video_12172018"
        public void a31_Learner_Plays_Promotional_Videos_From_General_Course_35375()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC35356" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + generalcoursetitle + "TC35356" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35356"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifybundlePromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickbundlePlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
           // ManageClassroomCoursePage.DeleteContent(generalcoursetitle + "TC35356");

        }
        [Test]

        public void a32_Classroom_Course_Promotional_Videos_35353()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35353");
            _test.Log(Status.Info, "Create A new Classroom Course");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
            _test.Log(Status.Info, "Verify Promotional Video preview on content details page");
        }
        [Test]//Dolly's Classroom Course w/ promo. Video_12182018
        public void a33_Learner_Plays_Promotional_Videos_From_Classroom_Course_35369()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + classroomcoursetitle + "TC35353" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + classroomcoursetitle + "TC35353" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC35353"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifybundlePromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickbundlePlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
           // ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "TC35353");
        }
        [Test]
        public void a34_Current_Training_Filter_Content_Types_23573()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.Learn.CurrentTraining();
            _test.Log(Status.Info, "Navigate to Current Training Page");
            Assert.IsTrue(CurrentTrainingPage.AllStatusDropDown.isSelectedValue("All Status"));
            int resultpagecount = CurrentTrainingPage.Totalnumberofresultpages();
            CurrentTrainingPage.AllStatusDropDown.SelectValue("Started");
            CurrentTrainingPage.ClickFilterButton();
            Assert.IsTrue(CurrentTrainingPage.AllStatusDropDown.isSelectedValue("Started"));
            Assert.IsTrue(CurrentTrainingPage.Totalnumberofresultpages() <= resultpagecount);
            CurrentTrainingPage.ClickResetButton();
            Assert.IsTrue(CurrentTrainingPage.Totalnumberofresultpages() == resultpagecount);
        }

        
 
        [Test]
        public void a35_Filter_Catalog_Search_results_by_Content_Type_Display_Format_35457()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); 
            CommonSection.SearchCatalog("sr");
            _test.Log(Status.Info, "Search dolly from Catalog search ");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("sr") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search result is display");
            Assert.IsTrue(SearchResultsPage.ContentTypeFacet.Display()); //Verify Display Format Facet  is displayed in the left sidebar
            SearchResultsPage.ContentTypeFacet.SelectCheckbox(); //Select multiple checkboxes
            _test.Log(Status.Info, "Select Content Type Facet check box");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("sr") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero after select Credit tag Facets");
            Assert.IsTrue(SearchResultsPage.SelectedTagsAboveSearchResults.Display()); //Verify the DisplayFormatFacet appears above the search results and Checkbox is checked
            SearchResultsPage.ContentTypeFacet.UnCheckDisplayFormatFacetFacetCheckbox();  //remove 3rd one
            _test.Log(Status.Pass, "UnCheck on Content Tag check box 3rd one");
            Assert.IsFalse(SearchResultsPage.ContentTypeFacet.UnCheckedDisplayFormatFacetRemoved);
            SearchResultsPage.SelectedTagsAboveSearchResults.RemoveTag();
            _test.Log(Status.Pass, "Removed one Tag");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.TagRemoved);
            SearchResultsPage.SelectedTagsAboveSearchResults.SelectClearAll();
            _test.Log(Status.Pass, "Click Clear All to clean all tag searches");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.AllTagsRemoved);
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("sr") >= 1);
        }
 
    
    
    
    }

}


