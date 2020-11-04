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
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1PlaylistTests : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string block = "Block_" + Meridian_Common.globalnum;
        bool TC26963 = false;
        bool TC27167 = false;
        
        public P1PlaylistTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string CertificatrTitle = "Certi" + Meridian_Common.globalnum;
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
      
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
    
     
        [Test, Order(1)]
        public void P20_1_A01_User_Can_See_Overview_Tab_of_CurriculumDetailPage_26367()
        {
            #region Create a Curriculum and Add Promotional Video

            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC26367");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            #endregion
            #region Add Cost
            GeneralCoursePage.setCost("2");
            #endregion
            #region Add Prerequisite
            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            _test.Log(Status.Info, "Click on Prerequisities Accordian Edit button");
            Assert.IsTrue(PrerequisitesPage.isSearchFiledsdisplay());
            _test.Log(Status.Pass, "Verify Search fields are display in Prerequisites page");

            PrerequisitesPage.ClickAddPrerequisites();
            _test.Log(Status.Info, "Click on ADD Prerequisities Button");
            Assert.IsTrue(AddPrerequisitesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddPrerequisitesPage.SearchFor("");
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");

            Assert.IsTrue(PrerequisitesPage.isPrerequisitesadded());
            _test.Log(Status.Pass, "Verify Prerequisites are added to Curriculumn");
            AddPrerequisitesPage.ClickBackButton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifyanyPrerequisitesPresent());
            _test.Log(Status.Info, "Verify any Prerequisities content display in Accordian");

            #endregion
            #region Add Equivalancies
            ContentDetailsPage.Accordians.ClickEdit_Equivalencies();
            _test.Log(Status.Info, "Click on Prerequisities Accordian Edit button");
            Assert.IsTrue(EquivalenciesPage.isSearchFiledsdisplay());
            _test.Log(Status.Pass, "Verify Search fields are display in Equivalencies page");
            EquivalenciesPage.ClickAddEquivalencies();
            _test.Log(Status.Info, "Click on ADD Equivalencies Button");
            Assert.IsTrue(AddEquivalenciesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddEquivalenciesPage.SearchFor("").ClickAddbutton();
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify Equivalencies are added to Curriculumn");
            #endregion
            GeneralCoursePage.ClickCheckIn();
            CommonSection.SearchCatalog(curriculamtitle + "_TC26367");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26367");
            _test.Log(Status.Info, "Click on search result from catalog");
            Assert.IsTrue(ContentDetailsPage.VerifyCurriculumDetailPage(curriculamtitle + "_TC26367"));
            _test.Log(Status.Info, "Assertion Pass as per Curriculum Detail Page New UI");
            TC26963 = true;
            TC27167 = true;
        }

        [Test, Order(2)]
        public void P20_1_A02_User_Request_Access_To_Curriculum_26343()
        {
            #region Set access approval
            ContentDetailsPage.ClickEditContent_New19_2();
            _test.Log(Status.Info, "Click edit content button");
            DocumentPage.ClickButton_CheckOut();
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            CurriculumContentPage.Remove_PreRequisites();
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(curriculamtitle + "_TC26367");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26367");
            _test.Log(Status.Info, "Click on search result from catalog");
            #endregion
            Assert.IsTrue(ContentDetailsPage.RequestAccess_Curriculum());
            Assert.IsTrue(ContentDetailsPage.RequestAccessHistory_Curriculum());
            Assert.IsTrue(ContentDetailsPage.CancelRequestAccess_Curriculum());
            
        }

        [Test, Order(3)]
        public void A03_User_View_Prerequisities_to_Curriculum_26963()
        {
            Assert.IsTrue(TC26963);

        }
        [Test, Order(4)]
        public void A04_User_View_Equivalent_Items_to_Curriculum_27167()
        {
            Assert.IsTrue(TC27167);

        }

        [Test, Order(5)]
        public void P20_1_A05_Learner_View_Content_Tab_of_Curriculum_35589()
        {
            #region Create a Curriculum and Add Content Into it
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC35589");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddMultiple_TypeBlocks(block);
            CurriculumContentPage.AddTrainingActivities_UnOrdered("");
            CurriculumContentPage.AddTrainingActivities_Ordered();
            CurriculumContentPage.AddTrainingActivities_Credit();
            CurriculumContentPage.AddTrainingActivities_Optional();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC35589");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC35589");
            _test.Log(Status.Info, "Click on search result from catalog");
            Assert.IsFalse(Driver.existsElement(By.XPath("//a[@href='#contentTab']")));
            _test.Log(Status.Info, "Assertion Pass as Content Tab Not displaying when content under revison");
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(curriculamtitle + "_TC35589");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC35589");
            _test.Log(Status.Info, "Click on search result from catalog");
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.VerifyCurriculum_ContentTab(block + "_UnOrdered", block + "_Ordered", block + "_Credit", block + "_Optional", curriculamtitle + "TCID1"));
        }

        [Test, Order(6)]
        public void P20_1_A06_Learner_See_Each_Block_Contents_of_Content_Tab_After_Enrollment_35590()
        {
            ContentDetailsPage.EnrollinCurriculum();
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.VerifyCurriculum_ContentTab(block + "_UnOrdered", block + "_Ordered", block + "_Credit", block + "_Optional", curriculamtitle + "TCID1"));

        }

        [Test, Order(7)]
        public void P20_1_A07_View_Curriculum_Certificate_26349()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26349");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC26349");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC26349");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC26349");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC26349");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26349");
            _test.Log(Status.Info, "Click on search result from catalog");
            ContentDetailsPage.EnrollinCurriculum();
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.MarkComplete_Curriculum());
            Assert.IsTrue(ContentDetailsPage.ClickViewCertificate_Curriculum());

        }

       [Test, Order(8)] 
        public void A08_Certifications_Containing_a_Curriculum_27206()
        {
            #region Crate a Certification
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC27206");
            _test.Log(Status.Info, "Fill title");
            //CertificationPage.SelectDropDown.CompletionCriteriaAs("Total credit hours are achieved");
            //_test.Log(Status.Info, "Select Value Total credit hours are achieved from completion criteria dropdown");
            //CertificationPage.SelectDropDown.TotalHrsscrollAs("2.5");
            //_test.Log(Status.Info, "Select Value 2.5 from scroll");
            //CertificationPage.SelectDropDown.CreditTypeAs("Default Credit Type");
            //_test.Log(Status.Info, "Select Value Default credit type");
            CertificationPage.Radiobutton.SelectCertificationexpireAs("No");
            _test.Log(Status.Info, "Select Value as no for Does this certification expire?");
            CertificationPage.Radiobutton.IncludePastContentCompletionAs("No");
            _test.Log(Status.Info, "Select Value as no for Include Past Content Completion");
            CertificationPage.ClickCreate();
            _test.Log(Status.Info, "Select Value as Certification price for Certification Cost Type and click create");
            #endregion
            DocumentPage.ClickButton_CheckOut();
            CertificatePage.addContentIntoCertificate(curriculamtitle + "_TC26349");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(curriculamtitle + "_TC26349");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26349");
            _test.Log(Status.Info, "Click on search result from catalog");
            //  Block Detail is Missing
        }

        [Test, Order(9)]
        public void A09_Learner_Review_Previously_Completed_Content_36030()
        {
            #region Create a 2 general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC36030_1");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC36030_2");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC36030");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC26349");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC36030_1");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC36030_2");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create Learner and Login with it
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC36030");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC36030");
            _test.Log(Status.Info, "Click on search result from catalog");
            ContentDetailsPage.EnrollinCurriculum();
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.MarkComplete_Curriculum_Content();
            Assert.IsTrue(ContentDetailsPage.Review_Previously_CompletedContent());

        }

        [Test, Order(10)]
        public void A10_Learner_ViewDetail_Of_Previously_Completed_Content_36031()
        {
            Assert.IsTrue(ContentDetailsPage.ViewDetail_Previously_CompletedContent());
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
        }
        [Test, Order(11)]
        public void P20_1_A11_Enroll_in_Curriculum_24948()
        {            
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26948");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC26948");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC26948");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Click on search result from catalog");
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue(ContentDetailsPage.isCancleEnrolllinkdisplay());
        }
        [Test, Order(12)]  //depend on TC26948
        public void P20_1_A12_Cancle_Enrollment_in_Curriculum_26340()
        {
            CommonSection.SearchCatalog(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Click on search result from catalog");
            Assert.IsTrue(ContentDetailsPage.isCancleEnrolllinkdisplay());
            ContentDetailsPage.ClickCancelEnrollment_Curriculum();
            Assert.IsTrue(ContentDetailsPage.getCancelEnrolFeedbackMessage("Your enrollment for the curriculum was cancelled"));

        }

        [Test, Order(13)]
        public void P20_1_A13_Curriculum_Share_Link_via_SocialMedia_35710()
        {
            CommonSection.Administer.System.SocialNetWorkingSharing.SocialSharing_Facebook();
            CommonSection.SearchCatalog(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Search for AutoCurriculum");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Access Content Details Page");
            Assert.IsTrue(ContentDetailsPage.SocialSharingDropDown("Facebook"));
            _test.Log(Status.Info, "Social Sharing button displays");

        }

        [Test, Order(14)]
        public void P20_1_A14_Curriculum_User_views_Reviews_and_Ratings_35712()
        {
            CommonSection.SearchCatalog(curriculamtitle + "_TC26948");
            _test.Log(Status.Info, "Search for Review Curriculum Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC26948");
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue(ContentDetailsPage.reviewsTab());
            _test.Log(Status.Info, "Write Curriculum review");
            ContentDetailsPage.writeCurriculumReview("For A test Review this class was great");
            Assert.IsTrue(ContentDetailsPage.verifyReviewText("For A test Review this class was great"));
            _test.Log(Status.Info, "Edit Review");
            ContentDetailsPage.editCurriculumReview("Made A small change");
            Assert.IsTrue(ContentDetailsPage.verifyReviewText("Made A small change"));
            _test.Log(Status.Info, "Delete review");
            ContentDetailsPage.deleteCurriculumReview();
                       
        }

        [Test, Order(15)]
        public void P20_1_A15_Curriculum_View_History_Progress_35713()
        {
            Assert.IsTrue(ContentDetailsPage.historyTab());
            _test.Log(Status.Info, "Check History Tab");
        }

        [Test, Order(16)]
        public void A16_Test_Access_Keys_with_Curriculum_34153()
        {
            #region Create General Course and Curriculum With Cost and Access keys Enabled
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "Curr", "Test General Course");
            GeneralCoursePage.setCost("5");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.Learn.Home();
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Creating a Paid Curriculum Course with Access Keys");
            objCreate.FillCurriculumPage("AK", browserstr);
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            BundlesPage.enableAccessKeys();
            _test.Log(Status.Info, "Access Keys Enabled");
            CurriculumsPage.CurriculumContent.addContentIntoCurriculam(generalcourse + "Curr");
            _test.Log(Status.Info, "Adding Paid General Course into Curriculum");
            DocumentPage.ClickButton_CheckIn();

            #endregion
            #region Purchase Access Keys for Curriculam
            ShoppingCarts.purchaseAccessKeys("Curriculam", Variables.curriculumTitle + browserstr + "AK");
            ShoppingCarts.completePurchaseProcess();
            _test.Log(Status.Info, "Keys has been purchased from shopping cart");
            CommonSection.Manage.Training();
            CommonSection.Manage.AccessKeys();
            AccessKeysPage.searchForContent(Variables.curriculumTitle + browserstr + "AK");
            AccessKeysPage.assignKeysToLearner("ershivam.iimt@ggmail.com");
            _test.Log(Status.Info, "Keys has been assigned to learner");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            #endregion
            LoginPage.LoginAs("ssuser1").WithPassword("password").Login();
            Assert.IsTrue(CurriculumsPage.searchforCurriculam(Variables.curriculumTitle + browserstr + "AK", generalcourse + "Curr"));
            _test.Log(Status.Info, "General Course Displaying inside Curriculuam, Assertion Pass");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//input[@value='Enroll']")));
           // TC_10823 = true;
            _test.Log(Status.Info, "Cost of General Course Override, Assertion Pass");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();

        }
    }

}
