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
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P2CertificationbyCreditTypeHoursTests : TestBase
    {
        string browserstr = string.Empty;
        public P2CertificationbyCreditTypeHoursTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
          
        }
       
        
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        bool ArchivedScale = false;
        bool learner_view_required_credit = false;
      

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

        }
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
      // [TearDown]
        public void teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath = screenShotPath.Replace(@"C:\Users\admin\Desktop\Automation\Regression Scripts\18.2\", @"Z:\");
                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    if (driver.Title == "Object reference not set to an instance of an object.")
                    {
                        driver.Navigate_to_TrainingHome();
                        Driver.focusParentWindow();
                        CommonSection.Avatar.Logout();
                        LoginPage.LoginClick();
                        LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
                    }
                    //if (!Meridian_Common.isadminlogin)
                    //{
                    //    CommonSection.Logout();
                    //    LoginPage.LoginAs("").WithPassword("").Login();
                    //}


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
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }
      
       


        
        [Test, Order(7), Category("AutomatedP1")]
        public void Learner_views_credit_type_help_text_from_General_Course_Details_33808()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a General course i.e. DV_GC_CV_0507 , and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner
            CommonSection.SearchCatalog('"'+generalcoursetitle + "credittype"+'"');
            _test.Log(Status.Info, "Search and open General course DV_GC_CV_0507  from catalog search");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "credittype");
            _test.Log(Status.Info, "Click on course DV_GC_CV_0507 title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Pass, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Pass, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Pass, "Verify Credit type text info that user is not eligible for ");
        }
        [Test, Order(8), Category("AutomatedP1")]
        public void While_searching_for_General_course_Learner_views_credit_type_and_credit_type_value_33878()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a General course i.e. DV_GC_CV_0507 ,and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.SearchCatalog('"'+generalcoursetitle + "credittype"+'"');
            _test.Log(Status.Info, "Search Classroom course DV_GC_CV_0507 from catalog search");
            StringAssert.AreEqualIgnoringCase(generalcoursetitle + "credittype", SearchResultsPage.VerifyCourseTitleText(generalcoursetitle + "credittype"));
            _test.Log(Status.Pass, "Verify course name");
            StringAssert.AreEqualIgnoringCase(CreditTypeTitle + " (5)", SearchResultsPage.VerifyTextCredits(CreditTypeTitle + " (5)"));
            _test.Log(Status.Pass, "Verify Credit type value and Credit Type");
        }


        [Test, Order(11), Category("AutomatedP1")]
        public void Catalog_Search_By_Using_Credit_Types_Facets_33885()

        //login with a admin 
        // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
        //Now create a sorm course i.e. DV_Scorm_CV_0507 , and add credit type, DV_Credit_Type and give value =3 in this, do this for multiple content items
        //login with learner

        //Pre-Req - Admin has created Credit Types and Admin has associated content with tags

        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login(); //Login as regular user (Learner)
            CommonSection.SearchCatalog("DV_GC_CV_0507");
            _test.Log(Status.Info, "Search DV_GC_CV_0507 from Catalog search ");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("DV_GC_CV_0507") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search result is display");
            Assert.IsTrue(SearchResultsPage.CreditTypesFacet.Display()); //Verify Credit Types Facet  is displayed in the left sidebar
            SearchResultsPage.CreditTypesFacet.SelectCheckbox(); //Select multiple checkboxes
            _test.Log(Status.Info, "Select Credit Type Facet check box");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("DV_GC_CV_0507") >= 1);
            _test.Log(Status.Pass, "Verify result is not Zero after select Credit tag Facets");
            //Assert.IsTrue.SearchResultsPage.ListofSearchResults.ContentAssociatedtoCreditTypes(); //Verify the page refreshed with the Content Associated with Selected Credit Types displayed
            Assert.IsTrue(SearchResultsPage.SelectedTagsAboveSearchResults.Display()); //Verify the Credit Types appears above the search results and Checkbox is checked
            Assert.IsTrue(SearchResultsPage.CreditTypesFacet.TagCheckboxChecked());
            SearchResultsPage.CreditTypesFacet.UnCheckCreditTypesFacetCheckbox();  //remove 3rd one
            _test.Log(Status.Pass, "UnCheck on Content Tag check box");
            Assert.IsFalse(SearchResultsPage.CreditTypesFacet.UnCheckedCreditTypeRemoved);
            //Assert.IsTrue.SearchResultsPage.ListofSearchResults.ContentRemovedAssociatedtoCreditTypesFacet();
            SearchResultsPage.SelectedTagsAboveSearchResults.RemoveTag();
            _test.Log(Status.Pass, "Removed one Tag");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.TagRemoved);
            Assert.IsTrue(SearchResultsPage.CreditTypesFacet.CreditTypesCheckboxUnChecked());
            // Assert.IsTrue.SearchResultsPage.ListofSearchResults.ContentRemovedAssociatedtoCreditTypes();
            SearchResultsPage.SelectedTagsAboveSearchResults.SelectClearAll();
            _test.Log(Status.Pass, "Click Clear All to clean all tag searches");
            Assert.IsFalse(SearchResultsPage.SelectedTagsAboveSearchResults.AllTagsRemoved);
            Assert.IsTrue(SearchResultsPage.CreditTypesFacet.AllTagCheckboxUnChecked());
            // Assert.IsTrue(SearchResultsPage.ListofSearchResults.AllContentDisplayed());
        }

       // [Test, Order(12)]
        //public void Inactive_CreditType()
        //{
        //    CommonSection.Logout();
        //    LoginPage.LoginAs("").WithPassword("").Login();
        //    CommonSection.Administer.ContentManagement.CreditType();
        //    CreditTypesPage.ClickMagangeGo();
        //    EditCreditTypePage.ClickActivity();
        //    EditCreditTypePage.ActivityTab.SelectInactive();
        //    EditCreditTypePage.ActivityTab.ClickSave();

        //}

        [Test, Order(13), Category("AutomatedP1")]
        public void Create_Certification_using_redesigned_certification_settings_33863()
        {
            //login with a admin 
            //   Create a Certification from create>Certification
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle);
            _test.Log(Status.Info, "Fill title");
            CertificationPage.SelectDropDown.CompletionCriteriaAs("Total credit hours are achieved");
            _test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            CertificationPage.SelectDropDown.TotalHrsscrollAs("2.5");
            _test.Log(Status.Info, "Select Value 2.5 from scroll");
            CertificationPage.SelectDropDown.CreditTypeAs("Default Credit Type");
            _test.Log(Status.Info, "Select Value Default credit type");
            CertificationPage.Radiobutton.SelectCertificationexpireAs("No");
            _test.Log(Status.Info, "Select Value as no for Does this certification expire?");
            CertificationPage.Radiobutton.IncludePastContentCompletionAs("No");
            _test.Log(Status.Info, "Select Value as no for Include Past Content Completion");
            //CertificationPage.Radiobutton.CertificationCostTypeAs("Certification Price");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "Select Value as Certification price for Certification Cost Type and click create");
            //StringAssert.AreEqualIgnoringCase("The item was created.", CertificationPage.VerifySuccessMessageText("The item was created."));
            _test.Log(Status.Pass, "The item was created.");
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (2.5 Default Credit Type)", CertificationPage.VerifyCompletionCriteriaText("Total credit hours are achieved (2.5 Default Credit Type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (2.5 Default Credit Type)");
            //  StringAssert.ArenotEqualIgnoringCase("Certification Content", Reg_Cert_CV_1107Page.VerifyText(""));
            // _test.Log(Status.Info, "Verify  Certification Content panel is not visible");

        }

        [Test, Order(14), Category("AutomatedP1")]
        public void Create_Certification_when_Completion_Criteria_Set_as_Credit_type_33822()
        {
            //login with a admin 
            // Create a Certification from create>Certification
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle+"TC33822");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.SelectDropDown.CompletionCriteriaAs("Total credit hours are achieved");
            _test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            CertificationPage.SelectDropDown.TotalHrsscrollAs("2.5");
            _test.Log(Status.Info, "Select Value 2.5 from scroll");
            CertificationPage.SelectDropDown.CreditTypeAs("Default Credit Type");
            _test.Log(Status.Info, "Select Value Default credit type");
            CertificationPage.Radiobutton.SelectCertificationexpireAs("No");
            _test.Log(Status.Info, "Select Value as no for Does this certification expire?");
            CertificationPage.Radiobutton.IncludePastContentCompletionAs("No");
            _test.Log(Status.Info, "Select Value as no for Include Past Content Completion");
            //CertificationPage.Radiobutton.CertificationCostTypeAs("Certification price");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "Select Value as Certification price for Certification Cost Type and click create");
           // StringAssert.AreEqualIgnoringCase("The item was created.", CertificationPage.VerifySuccessMessageText("The item was created."));
            _test.Log(Status.Pass, "The item was created.");
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (2.5 Default Credit Type)", CertificationPage.VerifyCompletionCriteriaText("Total credit hours are achieved (2.5 Default Credit Type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (2.5 Default Credit Type)");
            //StringAssert.ArenotEqualIgnoringCase("Certification Content", Reg_Cert_CV_1107Page.VerifyText(""));
            // _test.Log(Status.Info, "Verify  Certification Content panel is not visible");
            CertificationPage.Summary.ClickEdit();
            _test.Log(Status.Info, "Click Edit Button");
            Assert.IsFalse(SummaryPage.VerifyCompletionCriterianoteditable("Completion Criteria"));
            _test.Log(Status.Pass, "Verify  Completion Criteria cannot be modified");
            Assert.IsFalse(SummaryPage.VerifyTotalHoursnoteditable("Total Hours "));
            _test.Log(Status.Pass, "Verify  Total Hours  cannot be modified");
            Assert.IsFalse(SummaryPage.VerifyfCreditTypenoteditable("Credit Type"));
            _test.Log(Status.Pass, "Verify  Credit Type cannot be modified");
        }

        

        [Test, Order(15), Category("AutomatedP1")]
        public void Edit_Certification_user_edits_recertification_completion_as_Credit_type_33851()
        {
            //login with a admin 
            // Create a Certification from create>Certification
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create >> certification");
            CertificationPage.FillTitle(CertificatrTitle+"TC33851");
            _test.Log(Status.Info, "Fill title as" + CertificatrTitle+"TC33851");
            CertificationPage.SelectDropDown.CompletionCriteriaAs("Total credit hours are achieved");
            _test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            CertificationPage.SelectDropDown.TotalHrsscrollAs("2.5");
            _test.Log(Status.Info, "Select Value 2.5 from scroll");
            CertificationPage.SelectDropDown.CreditTypeAs("Default Credit Type");
            _test.Log(Status.Info, "Select Value Default credit type");
            CertificationPage.Radiobutton.SelectCertificationexpireAs("Yes");
            _test.Log(Status.Info, "Select Value as yes for Does this certification expire? and select interval period");
            CertificationPage.Radiobutton.SelectAllowReCertificationAs("Yes");
            _test.Log(Status.Info, "Select Value as yes for Allow re-certification ?");
            CertificationPage.SelectDropDown.ReCertificationCriteriaAs("Total credit hours are achieved");
            _test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            CertificationPage.SelectDropDown.ReCertificationTotalHrsscrollAs("3.5");
            _test.Log(Status.Info, "Select Value 3.5 from scroll");
            CertificationPage.SelectDropDown.ReCertificationCreditTypeAs("dv_credit_type");
            _test.Log(Status.Info, "Select Value DV_Credit_Type");
            CertificationPage.Radiobutton.IncludePastContentCompletionAs("No");
            _test.Log(Status.Info, "Select Value as no for Include Past Content Completion");
            //CertificationPage.Radiobutton.CertificationCostTypeAs("Certification price");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "Select Value as Certification price for Certification Cost Type and click create");
           // StringAssert.AreEqualIgnoringCase("The item was created.", CertificationPage.VerifySuccessMessageText("The item was created."));
            _test.Log(Status.Info, "The item was created.");
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (2.5 Default Credit Type)", CertificationPage.VerifyCompletionCriteriaText("Total credit hours are achieved (2.5 Default Credit Type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (2.5 Default Credit Type)");
            //StringAssert.ArenotEqualIgnoringCase("Certification Content", Reg_Cert_CV_1107Page.VerifyText(""));
            //_test.Log(Status.Info, "Verify  Certification Content panel is not visible");
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (3.5 dv_credit_type)", CertificationPage.VerifyReCertificationCompletionCriteriaText("Total credit hours are achieved (3.5 dv_credit_type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (3.5 DV_Credit_Type)");
            // StringAssert.ArenotEqualIgnoringCase("Re-Certification Content", Reg_Cert_CV_1107Page.VerifyText(""));
            // _test.Log(Status.Info, "Verify  Re-Certification Content panel is not visible");
            CertificationPage.Summary.ClickEdit();
            _test.Log(Status.Info, "Click Edit Button");
            Assert.IsFalse(SummaryPage.VerifyCompletionCriterianoteditable("Completion Criteria"));
            _test.Log(Status.Pass, "Verify  Completion Criteria cannot be modified");
            Assert.IsFalse(SummaryPage.VerifyTotalHoursnoteditable("Total Hours "));
            _test.Log(Status.Pass, "Verify  Total Hours  cannot be modified");
            Assert.IsFalse(SummaryPage.VerifyfCreditTypenoteditable("Credit Type"));
            _test.Log(Status.Info, "Verify  Credit Type cannot be modified");
            // SummaryPage.SelectDropDown.ReCertificationCriteriaAs("Total credit hours are achieved");
            SummaryPage.SelectDropDownonSummary.ReCertificationCriteriaAs("Total credit hours are achieved");
            _test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            // SummaryPage.SelectDropDown.TotalHrsscrollAs("3.0");
            SummaryPage.SelectDropDownonSummary.TotalHrsscrollAs("3.0");
            _test.Log(Status.Info, "Select Value 3 from scroll for recertification");
            // SummaryPage.SelectDropDown.CreditTypeAs("Default Credit Type");
            SummaryPage.SelectDropDownonSummary.CreditTypeAs("Default Credit Type");
            SummaryPage.clicksave();
            _test.Log(Status.Info, "Select Value Default Credit Type and click save");
            // SummaryPage.ClickonCertificationsBreadcromb();
            //StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (3 Default Credit Type)", CertificationPage.VerifyReCertificationCompletionCriteriaText("Total credit hours are achieved (3.0 Default Credit Type)"));
            //_test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (3 Default Credit Type)");
            CommonSection.Logout();
        }
      
 

       
        [Test, Order(23), Category("AutomatedP1")]
        public void learner_jump_to_list_of_content_that_is_pertinent_toward_meeting_their_required_credit_hours_33938()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, assing this credit type to some content like gen. course or aicc course 
            //Now create a Certification course i.e. DV_Cert_CV_0507 , and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.Logout();
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();
            CommonSection.SearchCatalog("saiflearner");
            SearchResultsPage.ClickCourseTitle("DV_Cert_CV_0507");
            _test.Log(Status.Info, "Search Certification DV_Cert_CV_0507 from catalog search and open it");
            Assert.IsTrue(ContentDetailsPage.isTextDisplayed("DV_Cert_CV_0507"));
            _test.Log(Status.Info, "Verify Certification course name");
            ContentDetailsPage.ClickFindQualifyingContentButton();
            _test.Log(Status.Info, "Click  Find Qualifying Content button");
            Assert.IsTrue(SearchResultsPage.VerifyFacetSelected("DV_Credit_Type"));
            _test.Log(Status.Info, "Verify Credit type filter is applied and DV_Credit_type is selected as facet");
        }

        [Test, Order(24), Description("Dependent on 17"), Category("AutomatedP1")]
        public void learner_views_credit_hours_required_for_Re_Certification_and_any_completed_content_toward_those_hours_33968()
        {
            CommonSection.Logout();
            LoginPage.LoginAs(ExtractDataExcel.MasterDic_userforreg["Id"] + "people").WithPassword("").Login();
            //driver.UserLogin("userforregression", browserstr);
            //      CommonSection.Learn.ClickHome();
            HomePage.CertificationPortlet.For("testcert_0709").ClickViewDetailsButton();
            ContentDetailsPage.ClickAccessItemButton();
            ContentDetailsPage.ClickReCertifybutton();
            _test.Log(Status.Info, "Click  Re-Certify button");
            Assert.IsTrue(ContentDetailsPage.isTextDisplayed("Re-certification Criteria"));
            _test.Log(Status.Info, "Verify Re-certification Criteria section for this certificaiton");
            Assert.IsTrue(ContentDetailsPage.isTextDisplayed("1 sa_credittype"));
            _test.Log(Status.Info, "Verify Credit type Value needed to complete this certificaiton");
            Assert.IsTrue(ContentDetailsPage.isTextDisplayed("You must earn 3 sa_credittype credits to complete re-certification. Below is a list of content you’ve previously completed that awards this credit type"));
            _test.Log(Status.Info, "Verify Text displayed for Credit type Value needed to complete this certificaiton");

            //login with a admin 
            //Pre-Req- Create a Certification with completion criteria as Credit Hrs.(with 3 Default Credit Type) Achieved.
            //Pre-Req- Set it as Expired and set expired completion time interval as 0, with completion criteria as Credit Hrs.(with 4 DV_Credit_Type) Achieved.
            //login with learner, access item and certify it by completing the content for credit type
            CommonSection.CatalogSearchText("testcert_0609");
            SearchResultsPage.ClickCourseTitle("testcert_0609");
            _test.Log(Status.Info, "Search Certification testcert_0609 from catalog search and open it");
            Assert.IsTrue(ContentDetailsPage.CertificationPortlet.isTextDisplayed("testcert_0609"));
            _test.Log(Status.Info, "Verify Certification course name");
            ContentDetailsPage.ClickAccessItemButton();
            _test.Log(Status.Info, "Click  Access Item button");
            // StringAssert.AreEqualIgnoringCase("3 Default Credit Type", ContentDetailsPage.CompletionCriteraiPortlet.isTextDisplayed("3 Default Credit Type"));
            _test.Log(Status.Info, "Verify Credit type Value needed to complete this certificaiton");
            Assert.IsTrue(ContentDetailsPage.CompletionCriteraiPortlet.isMsgDisplayed("You must earn 3 sa_credittype Type credits to complete this certification. Below is a list of content you’ve previously completed that awards this credit type."));
            _test.Log(Status.Info, "Verify Text displayed for Credit type Value needed to complete this certificaiton");
            //Click find qualified content and open and complete content which meeting required credit type so that certificaiton will complete
            ContentDetailsPage.ClickReCertifybutton();
            _test.Log(Status.Info, "Click  Re-Certify button");
            Assert.IsTrue(ContentDetailsPage.isTextDisplayed("Re-certification Criteria"));
            _test.Log(Status.Info, "Verify Re-certification Criteria section for this certificaiton");
            Assert.IsTrue(ContentDetailsPage.isTextDisplayed("4 DV_Credit_Type"));
            _test.Log(Status.Info, "Verify Credit type Value needed to complete this certificaiton");
            Assert.IsTrue(ContentDetailsPage.isTextDisplayed("You must earn 4 DV_Credit_Type credits to complete re-certification. Below is a list of content you’ve previously completed that awards this credit type"));
            _test.Log(Status.Info, "Verify Text displayed for Credit type Value needed to complete this certificaiton");



        }




    }

}
