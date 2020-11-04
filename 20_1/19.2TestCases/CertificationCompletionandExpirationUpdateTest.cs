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
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1_CertificationCompletionandExpirationUpdateTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_CertificationCompletionandExpirationUpdateTest(string browser)
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
        string documenttitle = "Document" + Meridian_Common.globalnum;
        string scormtitle = "SCROM" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle= "TA" + Meridian_Common.globalnum;
        string CertificatrTitle="Certification"+ Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        bool TC10877;
        bool TC10877_1;

    
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
    
        [Test, Order(1)]
        public void a01_Learner_experience_certification_where_admit_set_certificate_be_automatically_granted_upon_content_completion_is_YES_defualt_57971()
        {

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC57971", "Test General Course");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57971");
            _test.Log(Status.Info, "Fill title");
            Assert.IsTrue(CertificationPage.isShouldthecertificatebeautomaticallygranteduponcontentcompletion_lavelDisplay()); //AC1
            Assert.IsTrue(CertificationPage.automaticallygrantedcertificationDefaultValue("Yes"));  //AC3
            Assert.IsTrue(CertificationPage.automaticallygrantedcertificationValuesare("Yes", "No, admin approval is required")); //AC2
            _test.Log(Status.Pass, "Verified is automatically granted certification lavel and default value is Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate(generalcoursetitle + "TC57971");
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC57971" + '"'); 
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC57971" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC57971"); 
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.ClickAccessItemButton_Certi();
            ContentDetailsPage.ContentItemsPortlet.ClickItemTitle(generalcoursetitle + "TC57971");
            ContentDetailsPage.ClickEnroll_CerficationGeneralCourse();
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent_Certification();
            CertificationDetailsPage.ClickBreadCrumb();
            Assert.IsTrue(ContentDetailsPage.certificationProgress() == "100% Completed");  //AC4
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay()); //AC5
            //ContentDetailsPage.Click_HistoryTab_Curriculum();
            //Assert.IsTrue(ContentDetailsPage.HistoryTab.isViewCertificateButtonDisplay());  //AC6
            CommonSection.Transcript();
            TranscriptPage.ClickCertificationsTab();
            TranscriptPage.CertificationTab.sortbyDate("as");
            Assert.IsTrue(TranscriptPage.CertificationTab.isCertificationStatus(CertificatrTitle + "TC57971")== "Certified"); //AC7
            
        }
        [Test, Order(2)]
        public void a02_Learner_experience_certification_where_admit_set_certificate_be_automatically_granted_upon_content_completion_is_No_57970()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC57970", "Test General Course");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57970");
            _test.Log(Status.Info, "Fill title");
            Assert.IsTrue(CertificationPage.isShouldthecertificatebeautomaticallygranteduponcontentcompletion_lavelDisplay()); //AC1
            Assert.IsTrue(CertificationPage.automaticallygrantedcertificationDefaultValue("Yes"));  //AC3
            CertificationPage.SelectautomaticallygrantedcertificationDefaultValue("No");


            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate(generalcoursetitle + "TC57970");
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC57970" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC57970" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC57970");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.ClickAccessItemButton_Certi();
            ContentDetailsPage.ContentItemsPortlet.ClickItemTitle(generalcoursetitle + "TC57970");
            ContentDetailsPage.ClickEnroll_CerficationGeneralCourse();
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent_Certification();
            CertificationDetailsPage.ClickBreadCrumb();
            Assert.IsTrue(ContentDetailsPage.certificationProgress() == "100% Completed");  //AC4
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay()); //AC5  //AC5
            //ContentDetailsPage.Click_HistoryTab_Curriculum();
            //Assert.IsFalse(ContentDetailsPage.HistoryTab.isViewCertificateButtonDisplay());  //AC6
            CommonSection.Transcript();
            TranscriptPage.ClickCertificationsTab();
            TranscriptPage.CertificationTab.sortbyDate("as");
            Assert.IsTrue(TranscriptPage.CertificationTab.isCertificationStatus(CertificatrTitle + "TC57970") == "Pending"); //AC7
        }
        [Test, Order(3)]
        public void P20_1_a03_As_an_Admin_I_want_to_set_when_a_learner_can_begin_recertification_and_whether_they_can_complete_after_expiration_58197()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57970");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.DoesthisCertificationexpire("Yes");
            Assert.IsTrue(CertificationPage.isthisarecurringcertificationLeveldisplay());
            CertificationPage.isthisarecurringcertification("Yes");
            Assert.IsTrue(CertificationPage.isWhenistherecertificationperiodLevelDisplay()); //AC1
            CertificationPage.Whenistherecertificationperiod.Setbeforeexpiration();
            Assert.IsTrue(CertificationPage.isCertificationperiodfieldsDisplay()); //AC2
            CertificationPage.Whenistherecertificationperiod.Brfore("15");
            CertificationPage.Whenistherecertificationperiod.SetEndsAs("Set period");
           CertificationPage.Whenistherecertificationperiod.After("15");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create"); 
            Assert.IsTrue(ContentDetailsPage.Summary.VerifyRecertificationIntervaldays("15 Days")); //AC3
            TC10877 = true;
        }
        [Test, Order(4)]
        public void a04_Recertification_Admin_chooses_when_recertification_starts_58098()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57970");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.DoesthisCertificationexpire("Yes");
            Assert.IsTrue(CertificationPage.isthisarecurringcertificationLeveldisplay());
            CertificationPage.isthisarecurringcertification("Yes");
            Assert.IsTrue(CertificationPage.isWhendoestheCertificationgointoeffectLevelDisplay()); //AC1
            Assert.IsTrue(CertificatePage.isUponrecertificationcontentcompletionDisplay()); //AC2
            Assert.IsTrue(CertificatePage.isWhenpreviousCertificationexpiresDisplay()); //AC3
            //Assert.IsTrue(CertificatePage.isUponrecertificationcontentcompletionSelected()); //AC4
            _test.Log(Status.Pass, "Is Upon recertification content completion Selected");
            TC10877_1 = true;
        }
        [Test, Order(5)]
        public void tc_10878_Create_Certification()
        {
            Assert.IsTrue(TC10877);
            Assert.IsTrue(TC10877_1);
        }
        //[Test]
        //public void tc_58099_Recertification_When_Certification_expires_is_chosen()
        //{
        //    //cann't automated
        //}
        [Test, Order(6)]
        public void tc_33850_Create_Certification_when_user_defines_re_certification_completion_criteria_as_specific_credit_type()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC33850");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.SelectDropDown.CompletionCriteriaAs("Total credit hours are achieved");
            _test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            CertificationPage.SelectDropDown.TotalHrsscrollAs("2.5");
            _test.Log(Status.Info, "Select Value 2.5 from scroll");
            CertificationPage.SelectDropDown.CreditTypeAs("Default Credit Type");
            _test.Log(Status.Info, "Select Value Default credit type");
            CertificationPage.Radiobutton.SelectCertificationexpireAs("Yes");
            //CertificationPage.selectduration("1").Selectinterval("Day(s)");
            _test.Log(Status.Info, "Select Value as yes for Does this certification expire? and select interval period");
            CertificationPage.Radiobutton.SelectAllowReCertificationAs("Yes");
            _test.Log(Status.Info, "Select Allow Re Certification As Yes");
            CertificationPage.SelectDropDown.ReCertificationCriteriaAs("Total credit hours are achieved");
            _test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            CertificationPage.SelectDropDown.ReCertificationTotalHrsscrollAs("3.5");
            _test.Log(Status.Info, "Select Value 3.5 from scroll");
            CertificationPage.SelectDropDown.ReCertificationCreditTypeAs("dv_credit_type");
            _test.Log(Status.Info, "Select Value DV_Credit_Type");
            CertificationPage.Radiobutton.IncludePastContentCompletionAs("Yes");
            _test.Log(Status.Info, "Select Value as yes for Allow re-certification ?");


            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "Certification created");
           
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (2.5 Default Credit Type)", CertificationPage.VerifyCompletionCriteriaText("Total credit hours are achieved (2.5 Default Credit Type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (2.5 Default Credit Type)");
           
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (3.5 dv_credit_type)", CertificationPage.VerifyReCertificationCompletionCriteriaText("Total credit hours are achieved (3.5 dv_credit_type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (3.5 Default Credit Type)");



        }
        [Test, Order(7)]
        public void tc_26335_Access_Re_certification()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC26335", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC26335_Recitify", "Test General Course");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC26335");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.Whenistsertificationperiod("Immediately").until("1").Days();

            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate(generalcoursetitle + "TC26335");
            CertificatePage.Click_backbutton();

            CertificatePage.addContenttoRecertification(generalcoursetitle + "TC26335_Recitify");
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC26335" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC26335" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC26335");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.ClickAccessItemButton_Certi();
            ContentDetailsPage.ContentItemsPortlet.ClickItemTitle(generalcoursetitle + "TC26335");
            ContentDetailsPage.ClickEnroll_CerficationGeneralCourse();
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent_Certification();
            CertificationDetailsPage.ClickBreadCrumb();
            Assert.IsTrue(ContentDetailsPage.certificationProgress() == "100% Completed");  //AC4
            _test.Log(Status.Pass, "Verify progress display after content completed");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());

            Assert.IsTrue(ContentDetailsPage.isRe_certifybuttondisplay());
            _test.Log(Status.Pass, "Verify recertify button display");
            ContentDetailsPage.Click_Recertfybutton();
            Assert.IsTrue(ContentDetailsPage.isReCertificationContentportletdisplay());
            Assert.IsTrue(ContentDetailsPage.RecertificationCriteriaPortlet.content(generalcoursetitle + "TC26335_Recitify"));
            _test.Log(Status.Pass, "Verify recertify content is display");
            ContentDetailsPage.RecertificationCriteriaPortlet.clickContentTitle(generalcoursetitle + "TC26335_Recitify");
            ContentDetailsPage.ClickEnroll_CerficationGeneralCourse();
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent_Certification();
            CertificationDetailsPage.ClickBreadCrumb();
            Assert.IsTrue(ContentDetailsPage.certificationProgress() == "100% Completed");
            _test.Log(Status.Pass, "Verify progress display after content completed");
            Assert.IsTrue(ContentDetailsPage.IsViewCertificateButtondisplay());
            //Assert.IsTrue(ContentDetailsPage.IsViewCoreCertificateButtondisplay());

        }
        [Test, Order(8)]
        public void tc_26327_Add_Certification_To_Cart()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC26327");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.Click_Check_in();
            //CommonSection.SearchCatalog('"' + CertificatrTitle + "TC26327" + '"'); // Search for Bundle that has Promotional Video
            //_test.Log(Status.Info, "Searched" + CertificatrTitle + "TC26327" + "from Catalog");
            //SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC26327"); // Click on Bundle Title
            //_test.Log(Status.Info, "Clicked searched course title");
            //ContentDetailsPage.Click_CheckOut();
            //ContentDetailsPage.ClickEditContent_New19_2();
            //AdminContentDetailsPage.AddCost();
            //ContentDetailsPage.Click_Check_in();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC26327" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC26327" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC26327"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());
            ContentDetailsPage.ClickAddtoCart_GeneralCourse();
            StringAssert.AreEqualIgnoringCase("Success\r\nThe item was added to the cart.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ClickAddtoCartPortlet.isAddedtocardinfodisplay());
            Assert.IsTrue(CommonSection.isCountincrease_ShopingCart());

        }
      
     
    }

}



