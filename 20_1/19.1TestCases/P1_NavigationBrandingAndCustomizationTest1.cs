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
  ////   [Parallelizable(ParallelScope.Fixtures)]
    public class P1NavigationBrandingAndCustomizationTest1 : TestBase
    {
        string browserstr = string.Empty;
        public P1NavigationBrandingAndCustomizationTest1(string browser)
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
        string TATitle = "TATitle" + Meridian_Common.globalnum;
        string ScormTitle = "SCT" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string bundleTitle = "Bundle" + Meridian_Common.globalnum;
        string CertificationTitle = "Certificate" + Meridian_Common.globalnum;
        string curriculumTitle = "Curriculum" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscription" + Meridian_Common.globalnum;
        string DocumentTitle = "Document" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;

        public string SectionStartDate;
        string FormatDocument;
        string FormatGeneralCourse;
        string FormatAICCCourse;
        string FormatScormCourse;
        string FormatSurvey;
        string FormatCurriculum;
        string FormatCertification;
        string FormatBundle;
        string FormatSubscription;
        string FormatOJT;
        string FormatClassroom;
        public string EditedHeading;
        public string version;
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }


     
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
     

        [Test, Order(1)]
        public void a01_I_want_to_see_a_list_of_Display_Format_for_my_Site_35435()

        {

            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            string defultdisplayformatforAICC = DisplayFormatPage.GetAICCdefultDisplayFormat();
            string PreviousDate = DisplayFormatPage.GetDisplayed();
            DisplayFormatPage.ClickAICCDisplayFormatDropdown();
            _test.Log(Status.Info, "Clicked AICC display format dropdown");
            Assert.IsTrue(DisplayFormatPage.VerifyDisplayformatList());
            _test.Log(Status.Pass, "Verify list of Display Formats are displayed");
            DisplayFormatPage.SelectotherdisplayformatforAICC("File");
            _test.Log(Status.Info, "Select another Display Format");

            Assert.IsTrue(DisplayFormatPage.GetAICCdefultDisplayFormat(defultdisplayformatforAICC));
            _test.Log(Status.Pass, "Verify selected display format is not equals to defult format");
            Assert.IsTrue(DisplayFormatPage.isDefultChnagesDatedisplay(PreviousDate));
            _test.Log(Status.Pass, "Verify Defult Change Date display");
            DisplayFormatPage.SelectDefaultdisplayformatforAICC(defultdisplayformatforAICC);
            _test.Log(Status.Info, "Reset Display format value to defult");

        }




        [Test, Order(2)]
        public void a02_As_Admin_Set_Default_Display_Formats_And_Apply_To_All_Existing_Content_Items_35662()
        {
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            string defultdisplayformatforAICC = DisplayFormatPage.GetAICCdefultDisplayFormat();
            DisplayFormatPage.ClickAICCDisplayFormatDropdown();
            _test.Log(Status.Info, "Clicked AICC display format dropdown");
            Assert.IsTrue(DisplayFormatPage.VerifyDisplayformatList());
            _test.Log(Status.Pass, "Verify list of Display Formats are displayed");
            DisplayFormatPage.SelectDefaultdisplayformatforAICC("File");
            Assert.IsTrue(DisplayFormatPage.GetAICCdefultDisplayFormat(defultdisplayformatforAICC));
            _test.Log(Status.Pass, "Verify selected display format is not equals to default format");
           // Assert.IsTrue(DisplayFormatPage.AICC.ApplyToAllButtonDisplay());
            _test.Log(Status.Pass, "Verify AICC display format now displays Apply To All Button if All content are not the same Type");
            DisplayFormatPage.AICC.ClickApplyToAllbutton();
            _test.Log(Status.Pass, "Click on Apply To All Button");
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            //Assert.IsFalse(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply to All Modal is Closed");
            //            Assert.IsTrue(Driver.comparePartialString("The changes were saved", Driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success Message is displayed on Display Format Page");
            //Assert.IsFalse(DisplayFormatPage.AICC.ApplyToAllButtonDisplay());
            _test.Log(Status.Pass, "Verify Apply to All button is not displayed");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training ");
            TrainingPage.ManageContentPortlet.SearchForContent("AICC");

            _test.Log(Status.Info, "Search Content with AICC and click on Search Button");
            Assert.IsTrue(SearchResultsPage.AICCSeachList.isContentTypeDefaultFormat());
            _test.Log(Status.Info, "Verify all AICC content in the list displays Content Type as File");
        }



        [Test, Order(3)]
        public void a03_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_All_Portlets_In_HomePage_35552()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from site admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner Account");

            CommonSection.Learn.Home();
            HomePage.CurrentTrainingPortlet.Content();
            Assert.IsTrue(HomePage.CurrentTrainingPortlet.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Current Training Portlet");
            HomePage.CompletedTrainingPortlet.Conent();
            Assert.IsTrue(HomePage.CompletedTrainingPortlet.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Completed Training Portlet");
            HomePage.BasedOnYourInterest.Content();
            _test.Log(Status.Pass, "Check on content of BasedOnYourInterest");

            Assert.IsTrue(HomePage.BasedOnYourInterest.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Based On Your Interest Portlet");
            HomePage.RecentlyAdded.Content();
            _test.Log(Status.Pass, "Check on content of Recently Added");
            Assert.IsTrue(HomePage.RecentlyAdded.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Recently Added Portlet");

            //HomePage.RecommendedForYou.Content();
            //Assert.IsTrue(HomePage.RecommendedForYou.ContentType());
            //_test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Recommended for You Portlet");

        }
        [Test, Order(4)]
        public void a04_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Saved_Content_35553()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from site admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner Account");

            CommonSection.Dropdowntoggle.SavedContent();
            SavedContentPage.ContentList();
            _test.Log(Status.Info, "Check for content on Saved Content Page");

            Assert.IsTrue(SavedContentPage.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Saved Content Page");

        }


        [Test, Order(30)]//toShivam
        public void a05_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Transcript_35561()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from site admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner Account");

            CommonSection.Learn.Transcript();

            TranscriptPage.AllTrainingTab.Content();

            Assert.IsTrue(TranscriptPage.AllTrainingTab.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in All My Training Page");
            TranscriptPage.AllTrainingTab.ClickPrintButton();
            Assert.IsTrue(AllMyTrainingPrintPage.AllTrainingContent.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in All My Training Print Page");
            AllMyTrainingPrintPage.CloseAllTrainingPrintWindow();
            TranscriptPage.MoreDropDown.WaivedPreRequisite();
            _test.Log(Status.Pass, "Click Wiaved prereqiusites from More Dropdown toggle");

            TranscriptPage.WaivedPrerequisites.Content();
            Assert.IsTrue(TranscriptPage.WaivedPrerequisites.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Waived Prerequisites Page");
            TranscriptPage.WaivedPrerequisites.ClickPrintButton();
            Assert.IsTrue(WaivedPrerequisitesPrintPage.WaivedPrerequisitesContent.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Waived Prerequisites Print Page");
            WaivedPrerequisitesPrintPage.closeWaivedPrerequisitesPrintWindow();

            TranscriptPage.MoreDropDown.TrainingAssignmentExemptions();
            TranscriptPage.TrainingAssignmentExemptions.CurrentExemptionsContent();
            Assert.IsTrue(TranscriptPage.TrainingAssignmentExemptions.CurrentExemptionsContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Page Current Exemption Section");
            TranscriptPage.TrainingAssignmentExemptions.ClickCurrentExemptionsPrintButton();
            Assert.IsTrue(CurrentExemptionsPrintPage.CurrentExemptionsContent.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Current Print Page");
            TranscriptPage.TrainingAssignmentExemptions.closeCurrentExemptionsPrintWindow();
            Assert.IsTrue(TranscriptPage.TrainingAssignmentExemptions.PastExemptionsContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Page Past Exemption Section");
            TranscriptPage.TrainingAssignmentExemptions.ClickPastExemptionsPrintButton();
            Assert.IsTrue(PastExemptionsPrintPage.PastExemptionsContent.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Required Training Exemption Past Print Page");
            TranscriptPage.TrainingAssignmentExemptions.closePastExemptionsPrintWindow();


            TranscriptPage.MoreDropDown.ExpiredIncompleteContent();
            TranscriptPage.ExpiredIncompleteContents.Content();
            Assert.IsTrue(TranscriptPage.ExpiredIncompleteContents.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Expired Learning Page");
            TranscriptPage.ExpiredIncompleteContents.ClickPrintButton();
            Assert.IsTrue(ExpiredLearningPrintPage.ExpiredLearningContent.ContentType());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Expired Learning Print Page");
            TranscriptPage.ExpiredIncompleteContents.closeExpiredLearningPrintWindow();

        }

        [Test, Order(6)]
        public void a06_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Checkout_ShoppingCart_35562()
        //Pre-req - Item is added to Cart
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            string FormatGeneralCourse = DisplayFormatPage.SelectFormatGenenralCourse();

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35562");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add Cost to the Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check in Button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "login with learner's Account");
            CommonSection.SearchCatalog(generalcoursetitle + "TC35562");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35562");

            ContentDetailsPage.ClickAddtoCart();
            _test.Log(Status.Info, "Click on Add to Cart");
            CommonSection.ClickShoppingCart();
            _test.Log(Status.Info, "Verify Shopping Cart Page is displayed");
            Assert.IsTrue(ShoppingCartPage.Content.ContentType(generalcoursetitle + "TC35562", FormatGeneralCourse));

            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Shopping Cart Page");
            ShoppingCartPage.Checkout();
            _test.Log(Status.Info, "Verify Checkout Page is displayed ");
            CheckoutPage.UseThisPaymentMethod();
            _test.Log(Status.Info, "On the Checkout page, click Use this payment method button");

            Assert.IsTrue(CheckoutPage.OrderSummarySection.ContentType(generalcoursetitle + "TC35562", FormatGeneralCourse));
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Checkout Page");
            CheckoutPage.AcceptTermsandCondition();
            _test.Log(Status.Info, "Click on CheckBox to Accept Terms and Condition");
            Assert.IsTrue(OrderReceiptPage.OrderReceiptSection.ContentType(generalcoursetitle + "TC35562", FormatGeneralCourse));
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Order Receipt Page");

        }


        [Test, Order(7)]
        public void a07_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Orders_35568()
        //Pre-req - Items are purchased
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            string FormatGeneralCourse = DisplayFormatPage.SelectFormatGenenralCourse();

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35568");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add Cost to the Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check in Button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "login with learner's Account");
            CommonSection.SearchCatalog(generalcoursetitle + "TC35568");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35568");
            ContentDetailsPage.ClickAddtoCart();
            _test.Log(Status.Info, "Click on Add to Cart");
            CommonSection.ClickShoppingCart();
            _test.Log(Status.Info, "Click on Shopping Cart");
            ShoppingCartPage.Checkout();
            _test.Log(Status.Info, "Click on CheckOut");

            CheckoutPage.UseThisPaymentMethod();
            _test.Log(Status.Info, "Click on Use This Method");

            CheckoutPage.AcceptTermsandCondition();
            _test.Log(Status.Info, "Click on CheckBox to Accept Terms and Condition");

            CheckoutPage.PlaceOrder();
            _test.Log(Status.Info, "Click on Place Order");



            CommonSection.Avatar.Orders();
            _test.Log(Status.Info, "Click Orders from Avatar");
            OrderPage.ClickOrderedItemViewDetails(generalcoursetitle + "TC35568");
            _test.Log(Status.Info, "Verify Orders History Page is displayed with existing Orders, Click View Details for one Order");
            Assert.IsTrue(OrderDetailsPage.ItemDetails.ContentType(generalcoursetitle + "TC35568", FormatGeneralCourse));
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Order Details page");

        }

        [Test, Order(8)]
        public void a08_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Requests_35569()
        //Pre-req - Access Request is made
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            string FormatGeneralCourse = DisplayFormatPage.SelectFormatGenenralCourse();

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35569");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Access Approval Edit Button");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign Approver Path");
            AdminContentDetailsPage.ClickCheckInbutton();
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "login with learner's Account");
            CommonSection.SearchCatalog(generalcoursetitle + "TC35569");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35569");
            _test.Log(Status.Info, "Click Request Access");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("I want to Access");

            CommonSection.Avatar.Requests();
            _test.Log(Status.Info, "Click Requests from Avatar");
            Assert.IsTrue(RequestsPage.Requests.ContentRequestType(generalcoursetitle + "TC35569", FormatGeneralCourse));
            _test.Log(Status.Pass, "Verify Content Type in the Type column is replaced by Display Format for all Content Request in My Request Page");

        }

        [Test, Order(9)]
        public void a09_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Manage_Access_Keys_35570()
        //Pre-req - Purchased Access Keys

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            string FormatGeneralCourse = DisplayFormatPage.SelectFormatGenenralCourse();

            CommonSection.Learn.Home();
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "AK", "Test General Course");
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            Assert.IsTrue(ClassroomCoursePage.enableAccessKeys());
            _test.Log(Status.Info, "Access Keys Accordian Has been verfiied for General Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click CheckIn Button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "login with learner's Account");
            CommonSection.SearchCatalog(generalcoursetitle + "AK");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "AK");
            ContentDetailsPage.ClickAddtoCart();
            _test.Log(Status.Info, "Click Add to Cart");
            CommonSection.ClickShoppingCart();
            _test.Log(Status.Info, "Click Shopping Cart");
            ShoppingCartPage.Checkout();
            _test.Log(Status.Info, "Click on CheckOut");
            CheckoutPage.UseThisPaymentMethod();
            _test.Log(Status.Info, "Click on Use This Method");
            CheckoutPage.AcceptTermsandCondition();
            _test.Log(Status.Info, "Click on CheckBox to Accept Terms and Condition");
            CheckoutPage.PlaceOrder();
            _test.Log(Status.Info, "Click on Place Order");

            CommonSection.Manage.AccessKeys();
            _test.Log(Status.Info, "Select Access Keys from manage");
            Assert.IsTrue(AccessKeysPage.Conent.ContentFormat());
            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Manage Access page");
            AccessKeysPage.ClickViewDetails(generalcoursetitle + "AK");
            _test.Log(Status.Pass, "Click on View Details Action button from Manage Access page");
            VerifyCartPage.Content.ContentType(FormatGeneralCourse);

            _test.Log(Status.Pass, "Verify Content Type is replaced by Display Format for all Content in Item History page");


        }

        [Test, Order(10)]
        public void P20_1_a10_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Document_35572()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatForDocument("Document");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForDocument();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatDocument = DisplayFormatPage.CoursesInDisplayFormat.Document("Document");//XPathAgainstCoursetobeSelected

            //--------------------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();

            CommonSection.SearchCatalog("Document");
            _test.Log(Status.Info, "Search a document from Catalog search");
            //Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Document") >= 1);
            //_test.Log(Status.Pass, "Verify result is not Zero");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle("");
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeDocument(FormatDocument));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Document");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeDocument());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Document");
            ContentDetailsPage.ClickRequestAccess();
            _test.Log(Status.Pass, "Click Open Item button, Launch the Course and complete the content");
            Assert.IsTrue(ContentDetailsPage.AccessApprovalModal.ContentTypeDocument(FormatDocument));
            _test.Log(Status.Pass, "Verify Selected format on Approval Access Modal");
            ContentDetailsPage.AccessApprovalModal.RequestAccess();
            _test.Log(Status.Pass, "Click Request Access button on Access Approval Modal");

        }

        [Test, Order(11)]
        public void a11_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_General_Course_35573()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, " logout From Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35573");
            _test.Log(Status.Info, "Create general course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click CheckIn Button");

            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatForGeneralCourse("online");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForGeneralCourse();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatGeneralCourse = DisplayFormatPage.CoursesInDisplayFormat.GeneralCourse();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();


            CommonSection.SearchCatalog(generalcoursetitle + "TC35573");
            _test.Log(Status.Info, "Search a General Course from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35573");

            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeGenaralCourse(FormatGeneralCourse));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for General Course");

            ContentDetailsPage.EnrolGeneralCourse();
            _test.Log(Status.Info, "Enroll to general Course");

            ContentDetailsPage.LaunchGenralCourse();
            _test.Log(Status.Info, "Launch general Course");


            Assert.IsTrue(ContentDetailsPage.isMarkCompleteButtonDisplayed());
            _test.Log(Status.Pass, "Verify Mark Complete button is displayed Content Details Page");
            ContentDetailsPage.OpenMarkComplete();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");
            Assert.IsTrue(ContentDetailsPage.MarkCompleteModal.ContentTypeGeneralCourse(FormatGeneralCourse));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for General Course in Mark Complete Modal");
            ContentDetailsPage.CloseMarkComplete();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");


        }

        [Test, Order(28)]
        public void a27_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_AICC_35574()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "logout From  Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");

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
            // UploadaiccPage.UploadfileandClickCreate();
            CreateAICCPage.CreateAICC(AICCTitle + "TC35574");
            _test.Log(Status.Info, "Create a new AICC Course");
            #endregion
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click CheckIn Button");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatForAICC("online");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForAICC();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatAICCCourse = DisplayFormatPage.CoursesInDisplayFormat.AICC();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();


            CommonSection.SearchCatalog(AICCTitle + "TC35574");
            _test.Log(Status.Info, "Search a AICC Course from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC35574");

            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeAICC(FormatAICCCourse));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course");

            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeAICC());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course");
            ContentDetailsPage.ClickEnroll();
            ContentDetailsPage.LaunchAICCCourse();
            _test.Log(Status.Info, "Launch general Course");

            #region  To Complete AICC Course
            CommonSection.Logout();
            _test.Log(Status.Info, "logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login to Siteadmin Account");
            CommonSection.Manage.People();
            _test.Log(Status.Info, "Click on People");
            PeoplePage.Search_User("ak_learner");
            _test.Log(Status.Info, "Search User");
            PeoplePage.viewTranscript();
            _test.Log(Status.Info, "View Transcript");
            TranscriptPage.AllTrainingTab.Filter("", "", -1, 0);
            _test.Log(Status.Info, "Filter Search");
            TranscriptPage.SelectStatusAndGo(AICCTitle + "TC35574", "Mark Complete");

            #endregion

            TranscriptPage.MarkComplete("Completed");
            Assert.IsTrue(TranscriptPage.MarkCompleteModal.ContentTypeAICCCourse(FormatAICCCourse));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course in Mark Complete Modal");
            TranscriptPage.CloseMarkComplete();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");


        }

        [Test, Order(29)]
        public void a28_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Scorm_35575()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.CreteNewScorm(scormtitle + "TC35575");
            _test.Log(Status.Info, "Create A new SCROM Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click CheckIn Button");

            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatScormCourse("online");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForScorm();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatScormCourse = DisplayFormatPage.CoursesInDisplayFormat.ScormCourse();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();


            CommonSection.SearchCatalog(scormtitle + "TC35575");
            _test.Log(Status.Info, "Search a Scorm Course from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35575");

            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeScormCourse(FormatScormCourse));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Scorm Course");

            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeScormCourse());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Scorm Course");
            ContentDetailsPage.ClickEnroll();
            ContentDetailsPage.LaunchSCORMCourse();
            _test.Log(Status.Info, "Launch general Course");

            #region  To Complete AICC Course
            CommonSection.Logout();
            _test.Log(Status.Info, "logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login to Siteadmin Account");
            CommonSection.Manage.People();
            _test.Log(Status.Info, "Click on People");
            PeoplePage.Search_User("ak_learner");
            _test.Log(Status.Info, "Search User");
            PeoplePage.viewTranscript();
            _test.Log(Status.Info, "View Transcript");
            TranscriptPage.AllTrainingTab.Filter("", "", -1, 0);
            _test.Log(Status.Info, "Filter Search");
            TranscriptPage.SelectStatusAndGo(scormtitle + "TC35575", "Mark Complete");

            #endregion

            TranscriptPage.MarkComplete("Completed");
            Assert.IsTrue(TranscriptPage.MarkCompleteModal.ContentTypeScormCourse(FormatScormCourse));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course in Mark Complete Modal");
            TranscriptPage.CloseMarkComplete();
            _test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");
            _test.Log(Status.Info, "Launch Scorm Course");
            //Assert.IsTrue(ContentDetailsPage.isMarkCompleteButtonDisplayed());
            //_test.Log(Status.Pass, "Verify Mark Complete button is displayed Content Details Page");
            //ContentDetailsPage.OpenMarkComplete();
            //_test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");
            //Assert.IsTrue(ContentDetailsPage.MarkCompleteModal.ContentTypeScormCourse(FormatScormCourse));
            //_test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for AICC Course in Mark Complete Modal");
            //ContentDetailsPage.CloseMarkComplete();
            //_test.Log(Status.Pass, "Click Mark Complete button on Content Details Page");




        }

        [Test, Order(12)]
        public void P20_1_a12_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Survey_35576()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatSurvey("Survey");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForSurvey();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatSurvey = DisplayFormatPage.CoursesInDisplayFormat.Survey();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();


            CommonSection.SearchCatalog("Survey");
            _test.Log(Status.Info, "Search a Survey from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle("");

            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeSurvey(FormatSurvey));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Surveys");
            //Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeSurveys());
            //_test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Surveys");

        }

        [Test, Order(13)]
        public void P20_1_a13_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Curriculum_35577()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatCurriculum("Curriculum");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForCurriculum();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatCurriculum = DisplayFormatPage.CoursesInDisplayFormat.Curriculum();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();



            CommonSection.SearchCatalog("Curriculum");
            _test.Log(Status.Info, "Search a Curriculum from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle("");
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeCurriculum(FormatCurriculum));

            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Curriculum");


        }

        [Test, Order(14)]
        public void a14_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Certification_35578()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatCertification("Certification");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForCertification();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatCertification = DisplayFormatPage.CoursesInDisplayFormat.Certification();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();




            CommonSection.SearchCatalog("Certification");
            _test.Log(Status.Info, "Search a Certification from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle("");

            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeCertification(FormatCertification));

            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Certification");

            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeCertification());
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Certification");

        }

        [Test, Order(15)]
        public void a15_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Bundle_35579()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", bundleTitle + "TC35579", "Bundle Price");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click CheckIn Button");

            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatBundle("Bundle");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForBundle();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatBundle = DisplayFormatPage.CoursesInDisplayFormat.Bundle();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();



            CommonSection.SearchCatalog(bundleTitle + "TC35579");
            _test.Log(Status.Info, "Search a Bundle from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle(bundleTitle + "TC35579");

            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeBundle(FormatBundle));

            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Bundle");


        }

        [Test, Order(16)]
        public void a16_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Subscription_35580()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatSubscription("Subscription");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForSubscription();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatSubscription = DisplayFormatPage.CoursesInDisplayFormat.Subscription();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();



            CommonSection.SearchCatalog("Subscription");
            _test.Log(Status.Info, "Search a Subscription from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle("");
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeSubscription(FormatSubscription));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Subscription");

            //Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeSubscription());
            //_test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Subscription");

        }

        [Test, Order(17)]
        public void a17_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_OJT_35581()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatOJT("On-the-Job Training");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForOJT();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatOJT = DisplayFormatPage.CoursesInDisplayFormat.OJT();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------------------------

            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();


            CommonSection.SearchCatalog("OJT");
            _test.Log(Status.Info, "Search a OJT from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle("");
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeOJT(FormatOJT));

            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for OJT");
            Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeOJT());

            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for OJT");


        }

        [Test, Order(18)]
        public void a18_I_Want_To_See_Display_Format_And_Corresponding_Icon_Instead_Of_Content_Types_for_Content_Details_Page_Classroom_Course_35582()

        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatClassroom("Classroom");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForClassroom();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatClassroom = DisplayFormatPage.CoursesInDisplayFormat.Classroom();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------------------------

            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            CommonSection.SearchCatalog("Classroom");
            _test.Log(Status.Info, "Search a Classroom from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle("");
            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeClassroom(FormatClassroom));
            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Classroom Course");
            //Assert.IsTrue(ContentDetailsPage.MoreLikeThisSection.ContentTypeClassroom());
            //_test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Classroom Course");

        }
        [Test, Order(19)]//Custom Block
        public void a19_As_an_Administrator_make_a_custom_content_block_available_from_Homepage_Customization_35825()
        {
            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "Click on Homepage Customization");
            HomePageCustomizationPage.Add_CustomBlock();
            _test.Log(Status.Info, "Add custom Block and Save");
            Assert.IsTrue(HomePage.isCustomBlockDisplayed());
            _test.Log(Status.Info, "Verify Custom content block is Displayed");

        }
        [Test, Order(20)]//Custom Block
        public void a20_Add_Custom_Content_Block_Panel_35706()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            CustomBlockPage.Panels.CreatePanel();
            _test.Log(Status.Info, "Verify User Domain is Displayed");
            Assert.IsTrue(CreatePanelPage.isCreatePanelDisplayed());
            _test.Log(Status.Pass, "Verify Create Panel is Displayed");
            Assert.IsTrue(CreatePanelPage.isLocalizationDisplayed());
            _test.Log(Status.Pass, "Verify Create Panel is Displayed");
            Assert.IsTrue(CreatePanelPage.isStatusDisplayed());
            _test.Log(Status.Pass, "Verify Status is diplayed as visible");
            CreatePanelPage.FillTitle("Afreen Custom Content" + " " + Meridian_Common.globalnum);
            _test.Log(Status.Info, "Fill the Title and Save");
            CreatePanelPage.Heading.FillHeading("Flower");
            _test.Log(Status.Info, "Fill the Heading and Save");
            // Assert.IsAssignableFrom
            CreatePanelPage.Caption.FillCaption("Beautiful");
            _test.Log(Status.Info, "Fill the Caption and Save");
            CreatePanelPage.ButtonLabel.FillButtonLabel("Click me!");
            _test.Log(Status.Info, "Fill the Button Label and Save");
            CreatePanelPage.Hyperlink.AddhHyperlink("www.google.com");
            _test.Log(Status.Info, "Add a hyperlink and Save");
            //CreatePanelPage.BackgroundImage.AddBackgroundImage();
            //_test.Log(Status.Info, "Add a hyperlink and Save");
            CreatePanelPage.BackgroundVideo.AddBackgroundVideo("//www.youtube.com/embed/WSXDE4x4aek");
            _test.Log(Status.Info, "Add a hyperlink and Save");
            CreatePanelPage.Save();
            _test.Log(Status.Info, "Click on Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", CustomBlockDetailsPage.GetSuccessmessage()));
            _test.Log(Status.Pass, "Verify Success message is Displayed");

        }
        [Test, Order(21)]//Custom Block
        public void a22_As_an_Administrator_reorder_a_custom_Content_Panel_35776()
        {
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            CustomBlockPage.Panels.DragandDrop_CustomBlocks();
            _test.Log(Status.Info, "Drag and Drop Custom Blocks");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", CustomBlockPage.Successmessage()));
            _test.Log(Status.Pass, "Verify success message is Displayed");
        }


        [Test, Order(22)]//Custom Block
        public void a23_As_an_Administrator_delete_a_custom_Content_Panel_35726()
        {

            //CommonSection.Logout();
            //_test.Log(Status.Info, "Create logout From Siteadmin Account");
            //LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            //_test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            CustomBlockPage.Panels.SelectFirstCustomBlock();
            _test.Log(Status.Info, "Select Custom Block");
            CustomBlockPage.Panels.Delete();
            _test.Log(Status.Info, "Click Delete Button");
            Assert.IsTrue(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box Appears");
            CustomBlockPage.AlertBoxCancel();
            _test.Log(Status.Pass, "Click Cancel Button in Alert Box");
            Assert.IsFalse(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box is Closed");
            CustomBlockPage.Panels.SelectFirstCustomBlock();
            _test.Log(Status.Info, "Select Custom Block");
            CustomBlockPage.Panels.Delete();
            _test.Log(Status.Info, "Click Delete Button");
            Assert.IsTrue(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box Appears");
            CustomBlockPage.AlertBoxDelete();
            _test.Log(Status.Info, "Click Delete Button in Alert Box");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", CustomBlockPage.Successmessage()));
            _test.Log(Status.Pass, "Verify success message is Displayed");
            

        }
       
        [Test, Order(23)]//Custom Block
        public void a21_As_an_Administrator_edit_a_custom_Content_Panel_35707()
        {
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            CustomBlockPage.Panels.SelectCustomBlockToEdit();
            _test.Log(Status.Info, "Select a Custom block to Edit");
            CustomBlockDetailsPage.Edit_Title();
            _test.Log(Status.Info, "Edit title of Custom block");

            CustomBlockDetailsPage.TemplateView2();

            _test.Log(Status.Info, "Click on template view 2");
            CustomBlockDetailsPage.TemplateView3();
            _test.Log(Status.Info, "Click on template view 3");
            CustomBlockDetailsPage.TemplateView4();
            _test.Log(Status.Info, "Click on template view 4");
            CustomBlockDetailsPage.TemplateView1();
            _test.Log(Status.Info, "Click on template view 1");
            CustomBlockDetailsPage.EditHeading("Enter Heading For Test");
            _test.Log(Status.Info, "Edit Heading in the details Tab");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyHeading());
            _test.Log(Status.Pass, "verify Heading");
            CustomBlockDetailsPage.EditCaption("Change Caption For Test");
            _test.Log(Status.Info, "Edit Caption in the details Tab");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyCaption());
            _test.Log(Status.Pass, "verify Caption");
            CustomBlockDetailsPage.Edit_ButtonLabel();
            _test.Log(Status.Info, "Edit Button label in the details Tab");
            Assert.IsTrue(CustomBlockDetailsPage.VerifyButtonLabel());
            _test.Log(Status.Pass, "verify Button Label");
            CustomBlockDetailsPage.Save();
            _test.Log(Status.Pass, "Click on save Button");
           
        }



       
        [Test, Order(24)]//Custom Block
        public void a24_As_a_Custom_Role_User_add_a_Custom_Content_Block_Panel_for_the_domain_in_which_they_have_the_role_35868()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Siteadmin account");
            LoginPage.LoginAs("ak_user").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Custom Role user");
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            Assert.IsTrue(CustomBlockPage.isUserDomainDisplayed());
            _test.Log(Status.Info, "Verify User Domain is Displayed");

            CustomBlockPage.Panels.CreatePanel();
            _test.Log(Status.Info, "Verify User Domain is Displayed");
            Assert.IsTrue(CreatePanelPage.isCreatePanelDisplayed());
            _test.Log(Status.Pass, "Verify Create Panel is Displayed");
            Assert.IsTrue(CreatePanelPage.isLocalizationDisplayed());
            _test.Log(Status.Pass, "Verify Create Panel is Displayed");
            Assert.IsTrue(CreatePanelPage.isStatusDisplayed());
            _test.Log(Status.Pass, "Verify Status is diplayed as visible");
            CreatePanelPage.FillTitle("Afreen Custom Content");
            _test.Log(Status.Info, "Fill the Title and Save");
            CreatePanelPage.Heading.FillHeading("Flower");
            _test.Log(Status.Info, "Fill the Heading and Save");
            // Assert.IsAssignableFrom
            CreatePanelPage.Caption.FillCaption("Beautiful");
            _test.Log(Status.Info, "Fill the Caption and Save");
            CreatePanelPage.ButtonLabel.FillButtonLabel("Click me!");
            _test.Log(Status.Info, "Fill the Button Label and Save");
            CreatePanelPage.Hyperlink.AddhHyperlink("www.google.com");
            _test.Log(Status.Info, "Add a hyperlink and Save");
            CreatePanelPage.BackgroundImage.AddBackgroundImage();
            _test.Log(Status.Info, "Add a hyperlink and Save");
            CreatePanelPage.BackgroundVideo.AddBackgroundVideo("//www.youtube.com/embed/WSXDE4x4aek");
            _test.Log(Status.Info, "Add a hyperlink and Save");
            CreatePanelPage.Save();
            _test.Log(Status.Info, "Click on Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", CustomBlockDetailsPage.GetSuccessmessage()));
            _test.Log(Status.Pass, "Verify Success message is Displayed");


        }

        [Test, Order(25)]//Custom Block
        public void a25_As_a_Custom_Role_User_edit_a_Custom_Content_Block_Panel_for_the_domain_in_which_they_have_the_role_35869()
        {
            #region Edit and Cancel Changes
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            Assert.IsTrue(CustomBlockPage.isUserDomainDisplayed());
            _test.Log(Status.Info, "Verify User Domain is Displayed");
            CustomBlockPage.Panels.SelectCustomBlockToEdit();
            _test.Log(Status.Info, "Select Custom Block to edit");
            CustomBlockDetailsPage.Edit_Title();
            _test.Log(Status.Info, "Edit Title");
            string EditedTitle = CustomBlockDetailsPage.Title();
            Assert.IsTrue(CustomBlockDetailsPage.VerifyTitleEdited(EditedTitle));
            _test.Log(Status.Info, "Verify heading is Edited");

            CustomBlockDetailsPage.Edit_Heading();
            _test.Log(Status.Info, "Edit heading");
            string EditedHeading = CustomBlockDetailsPage.Heading();
            Assert.IsTrue(CustomBlockDetailsPage.VerifyHeadingEdited(EditedHeading));
            _test.Log(Status.Info, "Verify heading is Edited");

            CustomBlockDetailsPage.Edit_Caption();
            _test.Log(Status.Info, "Edit Caption");
            string EditedCaption = CustomBlockDetailsPage.Caption();
            Assert.IsTrue(CustomBlockDetailsPage.VerifyCaptionEdited(EditedCaption));
            _test.Log(Status.Info, "Verify Caption is Edited");

            Assert.IsFalse(CustomBlockDetailsPage.isButtonVisible());
            _test.Log(Status.Info, "Verify button is not Displayed");
            CustomBlockDetailsPage.Edit_ButtonLabel();
            _test.Log(Status.Info, "Edit Button label");
            Assert.IsTrue(CustomBlockDetailsPage.isButtonVisible());
            _test.Log(Status.Info, "Verify button is Displayed");
            CustomBlockDetailsPage.Cancel();
            _test.Log(Status.Info, "Click cancel");
            Assert.IsTrue(CustomBlockPage.isCustomBlockPageDisplayed());
            _test.Log(Status.Info, "Verify Custom Block Page is Displayed");

            #endregion



            #region Edit and Save Changes


            CustomBlockPage.Panels.SelectCustomBlockToEdit();
            _test.Log(Status.Info, "Select Custom Block to edit");
            CustomBlockDetailsPage.Edit_Title();
            _test.Log(Status.Info, "Edit Title");
            EditedTitle = CustomBlockDetailsPage.Title();
            Assert.IsTrue(CustomBlockDetailsPage.VerifyTitleEdited(EditedTitle));
            _test.Log(Status.Info, "Verify heading is Edited");

            CustomBlockDetailsPage.Edit_Heading();
            _test.Log(Status.Info, "Edit heading");
            EditedHeading = CustomBlockDetailsPage.Heading();
            Assert.IsTrue(CustomBlockDetailsPage.VerifyHeadingEdited(EditedHeading));
            _test.Log(Status.Info, "Verify heading is Edited");

            CustomBlockDetailsPage.Edit_Caption();
            _test.Log(Status.Info, "Edit Caption");
            EditedCaption = CustomBlockDetailsPage.Caption();
            Assert.IsTrue(CustomBlockDetailsPage.VerifyCaptionEdited(EditedCaption));
            _test.Log(Status.Info, "Verify Caption is Edited");

            Assert.IsFalse(CustomBlockDetailsPage.isButtonVisible());
            _test.Log(Status.Info, "Verify button is not Displayed");
            CustomBlockDetailsPage.Edit_ButtonLabel();
            _test.Log(Status.Info, "Edit Button label");
            Assert.IsTrue(CustomBlockDetailsPage.isButtonVisible());
            _test.Log(Status.Info, "Verify button is Displayed");
            CustomBlockDetailsPage.Save();
            _test.Log(Status.Info, "Click Save");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", CustomBlockDetailsPage.GetSuccessmessage()));
            _test.Log(Status.Pass, "Verify Success message is Displayed");


            #endregion

        }




        [Test, Order(26)]//Custom Block
        public void a26_As_a_Custom_Role_User_delete_a_custom_Content_Panel_for_the_Domain_in_which_they_have_the_role_35870()
        {

            #region Select Single Content Block and Delete
            CommonSection.Administer.System.BrandingAndCustomization.CustomBlock();
            _test.Log(Status.Info, "Click on Custom Block");
            Assert.IsTrue(CustomBlockPage.isUserDomainDisplayed());
            _test.Log(Status.Info, "Verify User Domain is Displayed");
            CustomBlockPage.Panels.SelectCustomBlock("Dolly's Custom Panel 8");
            _test.Log(Status.Info, "Select Custom block");
            CustomBlockPage.Panels.Delete();
            _test.Log(Status.Info, "Click Delete Button");
            Assert.IsTrue(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box Appears");
            CustomBlockPage.AlertBoxCancel();
            _test.Log(Status.Pass, "Click Cancel Button in Alert Box");
            Assert.IsFalse(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box is Closed");
            CustomBlockPage.Panels.SelectCustomBlock("Dolly's Custom Panel 8");
            _test.Log(Status.Info, "Select Custom Block");
            CustomBlockPage.Panels.Delete();
            _test.Log(Status.Info, "Click Delete Button");
            Assert.IsTrue(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box Appears");
            CustomBlockPage.AlertBoxDelete();
            _test.Log(Status.Info, "Click Delete Button in Alert Box");
            Assert.IsTrue(Driver.comparePartialString("The selected items were deleted.", CustomBlockPage.Successmessage()));
            _test.Log(Status.Pass, "Verify success message is Displayed");
            Assert.IsFalse(CustomBlockPage.Panels.VerifyCustomBlockDeleted("Dolly's Custom Panel 8"));
            _test.Log(Status.Pass, "Verify Selected Custom Block is Deleted");
            #endregion

            #region Select All Content Block and Delete

            CustomBlockPage.Panels.SelectAllCustomBlock();
            _test.Log(Status.Info, "Select all Custom block");
            CustomBlockPage.Panels.Delete();
            _test.Log(Status.Info, "Click Delete Button");
            Assert.IsTrue(CustomBlockPage.VerifyAlertBox());
            _test.Log(Status.Pass, "Verify Delete Alert box Appears");
            CustomBlockPage.AlertBoxDelete();
            _test.Log(Status.Info, "Click Delete Button in Alert Box");
            Assert.IsTrue(Driver.comparePartialString("The selected items were deleted.", CustomBlockPage.Successmessage()));
            _test.Log(Status.Pass, "Verify success message is Displayed");

            #endregion

        }


       


        
    }
}
