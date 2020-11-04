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
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1CertificationbyCreditTypeHoursTests : TestBase
    {
        string browserstr = string.Empty;
        public P1CertificationbyCreditTypeHoursTests(string browser)
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
        [Test, Order(1)]
        public void While_searching_for_Classroom_course_Learner_views_credit_type_and_credit_type_value_33875()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a classroom course i.e. DV_Class_CV_0507, and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            #region  Pre-Requisite
            CreditTypesPage.inactivepreviouscredittype();
            CommonSection.Administer.ContentManagement.CreditType();
            CreditTypesPage.ClickCreatenew();
            NewCreditTypePage.TitleAs(CreditTypeTitle).DescriptionAs("Test for Automation").Create();
            NewCreditTypePage.AssignedUsers("Add Users").SearchText("site").SelectAdminuser("siteadmin").Add();
            CommonSection.CreateLink.ClassroomCourse();
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "credittype");
            ClassroomCourseDetailsPage.CLickManageCredit();
            NewCreditTypePage.ClickAddCredit();
            NewCreditTypePage.AddCreditValuetoCreditType();

            CommonSection.CreateLink.Curriculam();
            CurriculumsPage.TitleAs(curriculamtitle + "CreditType").Create();
            ClassroomCourseDetailsPage.CLickManageCredit();
            NewCreditTypePage.ClickAddCredit();
            NewCreditTypePage.AddCreditValuetoCreditType();

            CommonSection.CreateLink.GeneralCourse();
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "credittype", "Automation Test");
            ClassroomCourseDetailsPage.CLickManageCredit();
            NewCreditTypePage.ClickAddCredit();
            NewCreditTypePage.AddCreditValuetoCreditType();



            // CommonSection.Logout();

            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.SearchCatalog('"'+classroomcoursetitle + "credittype"+'"');
            _test.Log(Status.Info, "Search Classroom course DV_Class_CV_0507 from catalog search");
            StringAssert.AreEqualIgnoringCase(classroomcoursetitle + "credittype", SearchResultsPage.VerifyCourseTitleText(classroomcoursetitle + "credittype"));
            _test.Log(Status.Info, "Verify Classroom course name");
            StringAssert.AreEqualIgnoringCase(CreditTypeTitle + " (5)", SearchResultsPage.VerifyTextCredits(CreditTypeTitle + " (5)"));
            _test.Log(Status.Info, "Verify Credit type value and Credit Type");

        }

        [Test, Order(2)]
        public void Learner_views_credit_type_help_text_from_Classroom_Course_Details_33805()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a classroom course i.e. DV_Class_CV_0507, and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner
           
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "credittype" + '"');
            _test.Log(Status.Info, "Search and open Classroom course DV_Class_CV_0507 from catalog search");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "credittype");
            // CatalogSearch.SearchCourse("DV_Class_CV_0507").clicktitle(); 
            _test.Log(Status.Info, "Click on Classroom course DV_Class_CV_0507 title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Info, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Info, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Info, "Verify Credit type text info that user is not eligible for ");
        }
        
        [Test, Order(3)]
        public void Learner_views_credit_type_help_text_from_Curriculum_Details_33810()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a Curriculum course i.e. DV_Curri_CV_0507, and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner

            CommonSection.SearchCatalog('"'+curriculamtitle + "CreditType"+'"');
            _test.Log(Status.Info, "Search and open course DV_Curri_CV_0507 from catalog search");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "CreditType");
            _test.Log(Status.Info, "Click on course DV_Curri_CV_0507 title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Info, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Info, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Info, "Verify Credit type text info that user is not eligible for ");
        }

        [Test, Order(4)]
        public void While_searching_for_Curriculum_Learner_views_credit_type_and_credit_type_value_33876()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a Curriculum course i.e. DV_Curri_CV_0507,and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.SearchCatalog('"'+curriculamtitle + "CreditType"+'"');
            _test.Log(Status.Info, "Search Classroom course DV_Curri_CV_0507 from catalog search");
            StringAssert.AreEqualIgnoringCase(curriculamtitle + "CreditType", SearchResultsPage.VerifyCourseTitleText(curriculamtitle + "CreditType"));
            _test.Log(Status.Info, "Verify Curriculum name");
            StringAssert.AreEqualIgnoringCase(CreditTypeTitle + " (5)", SearchResultsPage.VerifyTextCredits(CreditTypeTitle + " (5)"));
            _test.Log(Status.Info, "Verify Credit type value and Credit Type");
        }


        [Test, Order(5), Category("AutomatedP1")]
        public void Learner_views_credit_type_help_text_from_AICC_Course_Details_33807()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a AICC course i.e. DV_AICC_CV_0507 , and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner
            CommonSection.SearchCatalog('"' + "AICC-TEST_Somnath" + '"');
            _test.Log(Status.Info, "Search and open AICC course Somnath-AICC  from catalog search");
            SearchResultsPage.ClickCourseTitle("AICC-TEST_Somnath");
            _test.Log(Status.Info, "Click on course Somnath-AICC title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Info, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Info, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Info, "Verify Credit type text info that user is not eligible for ");
        }
        [Test, Order(6), Category("AutomatedP1")]
        public void While_searching_for_AICC_course_Learner_views_credit_type_and_credit_type_value_33877()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a AICC course i.e. DV_AICC_CV_0507 , and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.SearchCatalog('"' + "AICC-TEST_Somnath" + '"');
            _test.Log(Status.Info, "Search Classroom course Somnath-AICC from catalog search");
            StringAssert.AreEqualIgnoringCase("AICC-TEST_Somnath", SearchResultsPage.VerifyCourseTitleText("AICC-TEST_Somnath"));
            _test.Log(Status.Info, "Verify course name");
            StringAssert.AreEqualIgnoringCase("dv_credit_type (5)", SearchResultsPage.VerifyTextCredits("dv_credit_type (5)"));
            _test.Log(Status.Info, "Verify Credit type value and Credit Type");

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

        [Test, Order(9)]
        public void Learner_views_credit_type_help_text_from_Scorm_Course_Details_33809()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a sorm course i.e. DV_Scorm_CV_0507 , and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner
            CommonSection.SearchCatalog('"' + "SCORM-TEST-Somnath1" + '"');
            _test.Log(Status.Info, "Search and open Scorm course SCORM-TEST-Somnath1  from catalog search");
            SearchResultsPage.ClickCourseTitle("SCORM-TEST-Somnath1");
            _test.Log(Status.Info, "Click on course SCORM-TEST-Somnath1 title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Pass, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Pass, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Pass, "Verify Credit type text info that user is not eligible for ");
        }



        [Test, Order(10)]
        public void While_searching_for_Scorm_course_Learner_views_credit_type_and_credit_type_value_33879()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a sorm course i.e. DV_Scorm_CV_0507 , and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.SearchCatalog('"' + "SCORM-TEST-Somnath1" + '"');
            _test.Log(Status.Info, "Search Scorm course SCORM-TEST-Somnath1 from catalog search");
            StringAssert.AreEqualIgnoringCase("SCORM-TEST-Somnath1", SearchResultsPage.VerifyCourseTitleText("SCORM-TEST-Somnath1"));
            _test.Log(Status.Pass, "Verify Classroom course name");
            StringAssert.AreEqualIgnoringCase("dv_credit_type (5)", SearchResultsPage.VerifyTextCredits("dv_credit_type (5)"));
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

        [Test, Order(16), Category("AutomatedP1")]
        public void Create_Certification_user_defines_recertification_completion_as_Credit_type_33850()
        {
            //login with a admin 
            // Create a Certification from create>Certification
            driver.UserLogin("admin1", browserstr);
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle+"TC33850");
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

            //CertificationPage.Radiobutton.IncludePastContentCompletionAs("No");
            //_test.Log(Status.Info, "Select Value as no for Include Past Content Completion");
           // CertificationPage.Radiobutton.CertificationCostTypeAs("Certification price");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "Select Value as Certification price for Certification Cost Type and click create");
            //StringAssert.AreEqualIgnoringCase("The item was created.", CertificationPage.VerifySuccessMessageText("The item was created."));
            //_test.Log(Status.Pass, "The item was created.");
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (2.5 Default Credit Type)", CertificationPage.VerifyCompletionCriteriaText("Total credit hours are achieved (2.5 Default Credit Type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (2.5 Default Credit Type)");
            //StringAssert.ArenotEqualIgnoringCase("Certification Content", Reg_Cert_CV_1107Page.VerifyText(""));
            // _test.Log(Status.Info, "Verify  Certification Content panel is not visible");
            StringAssert.AreEqualIgnoringCase("Total credit hours are achieved (3.5 dv_credit_type)", CertificationPage.VerifyReCertificationCompletionCriteriaText("Total credit hours are achieved (3.5 dv_credit_type)"));
            _test.Log(Status.Pass, "Verify Completion Criteria: Total credit hours are achieved (3.5 Default Credit Type)");
            
            //StringAssert.ArenotEqualIgnoringCase("Re-Certification Content", Reg_Cert_CV_1107Page.VerifyText(""));
            //_test.Log(Status.Info, "Verify  Re-Certification Content panel is not visible");
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
        [Test, Order(17), Category("AutomatedP1")]

        public void Learner_Views_Their_Certification_Progress_33943()
        //Certification created with completion criteria as Total Credit hours achieved
        {
            CommonSection.Logout();
            Driver.CreateNewAccount();
           
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login(); //Login as regular user (Learner)
            CommonSection.SearchCatalog("testcert_0709");
            //  CatalogSearch.EnterSearchText"Certification".ClickSearch(); //Search for the certification with completion criteria is based on Total Credit Hours
            //  Assert.IsTrue(SearchResultsPage.ListofSearchResults); //Verify the certification is displayed
            SearchResultsPage.ClickCourseTitle("testcert_0709");
            //SearchResultsPage.CheckSearchRecord("Certification");
            ContentDetailsPage.ClickAccessItemButton();
            Assert.IsTrue(ContentDetailsPage.isProgressDisplayed("0%"));
            CommonSection.Learn.ClickHome();
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsStatus("In Progress"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsProgressStatus("0%"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsRequiredCount(3));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsEarnedCount(0));

            // Assert.IsTrue(HomePage.CertificationPortlet.Status("InProgress").Progress("0%"));
            CommonSection.ClickCurrentTraining();
            //Assert.IsTrue(HomePage.CurrentTrainingPortlet.For("Automation Certification").IsStatus("InProgress"));
            Assert.IsTrue(HomePage.CurrentTrainingPortlet.For("testcert_0709").IsProgress("0%"));
            // Assert.IsTrue(HomePage.CurrentTrainingPortlet.Status("InProgress").Progress("0%"));
            //testgen1
            CommonSection.ClickHome();
            HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709","View Details");
            // Assert.IsTrue(CertificationDetailPage);
            ContentDetailsPage.ClickFindQualifyingContentButton();
//            // Assert.IsTrue(SearchResultsPage.CheckSearchRecord.CreditTypeHours); //Verify the Search Results display with all the course records with CreditTypes and Hours
            SearchResultsPage.ClickCourseTitle("testgen1"); //From Search Results page click on the Title of the Course which qualifies for the Credit Type Hours 
            ContentDetailsPage.EnrolGeneralCourse();
            ContentDetailsPage.LaunchGenralCourse();
            ContentDetailsPage.MarkCompleteGeneralCourse();// Enroll, Launch, and Completed the course
            CommonSection.ClickHome();
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsStatus("In Progress"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsProgressStatus("33%"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsRequiredCount(3));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsEarnedCount(1));

            //testgen2
            HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709", "View Details");
            // Assert.IsTrue(CertificationDetailPage);
            ContentDetailsPage.ClickFindQualifyingContentButton();
            //            // Assert.IsTrue(SearchResultsPage.CheckSearchRecord.CreditTypeHours); //Verify the Search Results display with all the course records with CreditTypes and Hours
            SearchResultsPage.ClickCourseTitle("testgen2"); //From Search Results page click on the Title of the Course which qualifies for the Credit Type Hours 
            ContentDetailsPage.EnrolGeneralCourse();
            ContentDetailsPage.LaunchGenralCourse();
            ContentDetailsPage.MarkCompleteGeneralCourse();// Enroll, Launch, and Completed the course
            CommonSection.ClickHome();
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsStatus("In Progress"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsProgressStatus("67%"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsRequiredCount(3));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsEarnedCount(2));

            //testgen3
            HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709", "View Details");
            // Assert.IsTrue(CertificationDetailPage);
            ContentDetailsPage.ClickFindQualifyingContentButton();
            //            // Assert.IsTrue(SearchResultsPage.CheckSearchRecord.CreditTypeHours); //Verify the Search Results display with all the course records with CreditTypes and Hours
            SearchResultsPage.ClickCourseTitle("testgen3"); //From Search Results page click on the Title of the Course which qualifies for the Credit Type Hours 
            ContentDetailsPage.EnrolGeneralCourse();
            ContentDetailsPage.LaunchGenralCourse();
            ContentDetailsPage.MarkCompleteGeneralCourse();// Enroll, Launch, and Completed the course
            CommonSection.ClickHome();
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsStatus("Certified"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsProgressStatus("100%"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsRequiredCount(3));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsEarnedCount(3));


            //  Assert.IsTrue(HomePage.CertificationPortlet.Status("Certified").Progress("100% Completed"));
            HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709", "View Details");
            //Assert.IsTrue(ContentDetailsPage.isStatus("Certified"));
            Assert.IsTrue(ContentDetailsPage.isProgress("100% Completed"));
            // Assert.IsTrue(CertificationDetailPage.Status("Certified").Progress("100% Completed"));
            CommonSection.ClickTranscript();
            TranscriptPage.ClickCertificationsTab();
            Assert.IsTrue(TranscriptPage.CertificationTab.For("testcert_0709").isCertificationStatus("Certified"));
            Assert.IsTrue(TranscriptPage.CertificationTab.For("testcert_0709").isCertificationProgress("100% Completed"));

            // Assert.IsTrue(TranscriptPage.CertificationsTab.Certification.Status("Certified").Progress("100% Completed"));
            learner_view_required_credit = true;
        }
        [Test, Order(18), Category("AutomatedP1")]

        public void Learner_Views_Certificate_For_Certification_Completed_By_Fulfilling_Required_Amount_Of_Credit_Type_Hours_33944()
        //Certification created with completion criteria as Total Credit hours is achieved. User has already completed the certification
        {
            //   LoginPage.LoginAs("reguser").WithPassword("").Login(); //Login as regular user (Learner)
            // CommonSection.Home.CertificationPortlet();
            //Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsStatus("Certified"));

            //Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsProgressStatus("100%"));
            //HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709", "View Details");
            ////Assert.IsTrue(ContentDetailsPage.isStatus("Certified"));
            //Assert.IsTrue(ContentDetailsPage.isProgress("100% Completed"));
            CommonSection.ClickTranscript();
            TranscriptPage.ClickCertificationsTab();
            //Assert.IsTrue(TranscriptPage.CertificationTab.isCertificationStatus("Certified"));
            //Assert.IsTrue(TranscriptPage.CertificationTab.isProgress("100% Completed"));
            TranscriptPage.CertificationTab.ClickViewCertificateButton();
            Driver.Instance.SwitchWindow("Certificate");
            string s = Driver.Instance.Title;
            StringAssert.AreEqualIgnoringCase("Certificate", s);
            TranscriptPage.CloseCertificationWindow();
            Driver.Instance.SwitchtoDefaultContent();
            Assert.IsTrue(TranscriptPage.CertificateWindowIsClosed("Transcript"));

        }
        [Test, Order(19), Category("AutomatedP1")]

        public void Learner_Views_Certificate_For_ReCertification_Completed_By_Fulfilling_Required_Amount_Of_Credit_Type_Hours_33956()
        //Certification and Re-Certification created with completion criteria as Total Credit hours is achieved. User has already completed the certification and Re-Certification
        {
            //     LoginPage.LoginAs("reguser").WithPassword("").Login(); //Login as regular user (Learner)
            // CommonSection.Home.CertificationPortlet();
            CommonSection.Learn.ClickHome();
            HomePage.CertificationPortlet.For("testcert_0709").ClickViewDetailsButton();
            Assert.IsTrue(ContentDetailsPage.RecertificationCriteriaPortlet.isTextDisplayed("3 sa_credittype"));
            ContentDetailsPage.ClickReCertifybutton();
            Assert.IsTrue(ContentDetailsPage.isProgressDisplayed("0"));
            CommonSection.ClickHome();
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsProgressStatus("0%"));
            Assert.IsTrue(HomePage.CurrentTrainingPortlet.For("testcert_0709").IsProgress("0%"));
            Assert.IsTrue(HomePage.CertificationContentPortlet.For("testcert_0709").IsProgressCount("1"));
            HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709", "View Details");
            // Assert.IsTrue(CertificationDetailPage);
            ContentDetailsPage.ClickFindQualifyingContentButton();
            //            // Assert.IsTrue(SearchResultsPage.CheckSearchRecord.CreditTypeHours); //Verify the Search Results display with all the course records with CreditTypes and Hours
            SearchResultsPage.ClickCourseTitle("testgen1"); //From Search Results page click on the Title of the Course which qualifies for the Credit Type Hours 
            ContentDetailsPage.EnrolGeneralCourse();
            ContentDetailsPage.LaunchGenralCourse();
            ContentDetailsPage.MarkCompleteGeneralCourse();// Enroll, Launch, and Completed the course
            CommonSection.ClickHome();
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsStatus("Certified"));
            Assert.IsTrue(HomePage.CertificationPortlet.For("testcert_0709").IsProgressStatus("100%"));

            CommonSection.ClickTranscript();
            TranscriptPage.ClickCertificationsTab();
            Assert.IsTrue(TranscriptPage.CertificationTab.For("testcert_0709").isCertificationStatus("Certified"));
            Assert.IsTrue(TranscriptPage.CertificationTab.For("testcert_0709").isCertificationProgress("100% Completed"));
          //  CommonSection.Logout();
        }


        [Test, Order(20), Category("AutomatedP1")]

        public void User_Views_Credit_Hours_Required_And_Completed_For_Any_Credit_Type_Certifications_Through_Certification_Portlet_33983()

        // Prerequisite- Certification portlet has been enabled from Admin > System > Branding and Customization > Homepage Customization 
        // User is enrolled in a credit type certiifcation

        {
            Assert.IsTrue(learner_view_required_credit);
           // CommonSection.Logout();
        }
        [Test, Order(21), Category("AutomatedP1")]

        public void Learner_Views_Content_And_Credit_Hours_Completed_For_Core_Certification_34011()
        //Create a certification with completion criteria as Total credit hours achieved for both certification and Re-certification. Complete certification so that learner can Re-Certify it

        {
            //  driver.UserLogin("userforregression", browserstr); //Login as regular user (Learner)
            CommonSection.ClickHome();
            HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709", "View Details");
            // HomePage.CertificationPortlet.ExpandCertificationTitle();// Expand the certification that has completed certification
            //Assert.IsTrue(HomePage.CertificationPortlet.isCertificationReCertifyButtonDisplayed); // Verify the Re-Certify button is displayed
            //HomePage.CertificationPortlet.ClickReCertifyButton(); // Click Re-Certify button
            Assert.IsTrue(ContentDetailsPage.isViewCoreCertificationButtonDisplayed()); //Verify the Content Details page with View Core Certification Button is displayed
            ContentDetailsPage.ClickViewCoreCertificationButton();//Click on the View Core Certification button
            Assert.IsTrue(ContentDetailsPage.isCertificationInfoPageDisplayed()); //Verify Certification Info Page is displayed
            CertificationInfoPage.SelectCompletionCriteriaTab();//Select Completion Criteria Tab on Certification Info page
            //Assert.IsTrue(CertificationInfoPage.CompletionCriteriaTab.isTextWithNumberOfCreditsAndCreditTypesDisplayed("3 sa_credittype")); //Verify text with Number of Credits and Credit Types required to earn Certification are displayed
            CertificationInfoPage.SelectReCertificationCriteriaTab();//Select Completion Criteria Tab on Certification Info page
           // Assert.IsTrue(CertificationInfoPage.ReCertificationCriteriaTab.isTextWithNumberOfCreditsAndCreditTypesDisplayed("1 sa_credittype")); //Verify text with Number of Credits and Credit Types required to earn Re-certification are displayed
            //CommonSection.SelectParentWindow();

        }


        [Test, Order(22),Description("Dependent on 17")]
        public void learner_views_credit_hours_required_for_Certification_and_any_completed_content_toward_those_hours_33921()
        {
            Driver.focusParentWindow();
            CommonSection.Logout();
            //login with a admin 
            //Pre-Req- Create a Certification with completion criteria as Credit Hrs.(with 3 Default Credit Type) Achieved.
            //login with learner
            LoginPage.LoginAs("saiflearner").WithPassword("").Login(); //Login as regular user (Learner)
            CommonSection.SearchCatalog(CertificatrTitle + "TC33850");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC33850");
               
            _test.Log(Status.Info, "Search Certification DV_Re_Cert_0803 from catalog search and open it");
           Assert.IsTrue(ContentDetailsPage.CertificationPortlet.isTextDisplayed(CertificatrTitle + "TC33850"));
            _test.Log(Status.Info, "Verify Certification course name");
            ContentDetailsPage.ClickAccessItemButton();
            _test.Log(Status.Info, "Click  Access Item button");
            Assert.IsTrue(ContentDetailsPage.CompletionCriteraiPortlet.isTextDisplayed("Completion Criteria"));
            _test.Log(Status.Info, "Verify Completion Criteria section for this certificaiton");
            Assert.IsTrue( ContentDetailsPage.CertificationPortlet.isBoldTextDisplayed("2.5 Default Credit Type"));
            _test.Log(Status.Info, "Verify Credit type Value needed to complete this certificaiton");
             Assert.IsTrue(ContentDetailsPage.ObjectivesPorlet.isTextDisplayed("Below is a list of content you’ve previously completed that awards this credit type."));
            _test.Log(Status.Info, "Verify Text displayed for Credit type Value needed to complete this certificaiton");
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
