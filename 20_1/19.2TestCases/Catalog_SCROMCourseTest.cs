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
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P1_Catalog_SCROMCourseTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_SCROMCourseTest(string browser)
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
        bool TC26372;
        bool? _TC_57924;
        bool TC57810;
        bool TC57930, TC57930_1, TC57930_2, TC57930_3;

   
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
      

        //Start writing your test here

        [Test, Order(1)]
        public void P20_1_a01_Add_SCROM_Course_to_Cart_26227()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26227");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");

            Assert.IsTrue(ContentDetailsPage.isCostNSalesTaxAccordiandisplayed());
            _test.Log(Status.Pass, "Verify Cost and Sales Tax Accordian Display");

            ContentDetailsPage.Accordians.ClickEdit_CostNSalesTax();
            _test.Log(Status.Info, "Click on Cost & SalesTax Accordian Edit button");
            Assert.IsTrue(CostPage.VerifyDifferentPortlets());
            _test.Log(Status.Pass, "Verify the Manage Sales Tax, Default Cost, Alternate Costs, Pricing Schedules sections are displayed");

            CostPage.DefaultCostAs("15").Save();
            _test.Log(Status.Info, "Enter Defailt Cost and Click Save");
            Assert.IsTrue(CostPage.Successmessage("The default cost was saved."));
            _test.Log(Status.Pass, "Verfy Default cost is saved");
            ContentDetailsPage.Click_Check_in();
            CommonSection.Logout();

            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + scormtitle + "TC26227" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + scormtitle + "TC26227" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26227"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());  //57254 AC6
            ContentDetailsPage.ClickAddtoCart_GeneralCourse();
            //StringAssert.AreEqualIgnoringCase("Success\r\nThe item was added to the cart.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ClickAddtoCartPortlet.isAddedtocardinfodisplay());
            Assert.IsTrue(CommonSection.isCountincrease_ShopingCart());
            CommonSection.ClickShoppingCart();
            
            ShoppingCartPage.CompletePurchaseProcess();
            OrderPage.Click_PurchasedContentTitle();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Costportlet.isViewOrderlinkDisplay());
            ContentDetailsPage.OverviewTab.Costportlet.ClickViewOrderlink();
            Assert.IsTrue(OrderDetailsPage.VerifyPurchasedContent(scormtitle + "TC26227"));
            TC26372 = true;
            TC57930 = true;
        }
        [Test, Order(2)] //depend on 26227
        public void P20_1_a02_View_SCORM_Course_Purchase_Details_26372()
        {
            Assert.IsTrue(TC26372);
        }
        [Test, Order(3)]
        public void P20_1_a03_SCROM_Course_Reviews_Tab_and_ratings_57645()
        {
            CommonSection.Avatar.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Create a scrum course
            CommonSection.CreteNewScorm(scormtitle + "TC57645");
            _test.Log(Status.Info, "Creating New Scorm");
           // DocumentPage.ClickButton_CheckIn();
            #endregion

            CommonSection.Avatar.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("password").Login();
            CommonSection.SearchCatalog(scormtitle + "TC57645");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57645");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay()); //AC1
            ContentDetailsPage.EnrollinGeneralCourse_new();
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay()); //AC1
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title")); //AC2 and AC5
        }

        [Test, Order(4)] // create a scrom, add description, course information, credit and gamification points
        public void P20_1_a04_As_a_Learner_view_SCROM_Course_details_Description_Course_Information_Credit_Point_and_Completion_reqards_57620()
        {
            CommonSection.SearchCatalog("SCROM_TC57645");
            SearchResultsPage.ClickCourseTitle("SCROM_TC57645");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());   //AC1
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isCourseProviderDisplay()); //AC3
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDurationDisplay());  //AC2
            Assert.IsTrue(ContentDetailsPage.OverviewTab.CreditPortlet.isCreditScoreDisplay()>=0); //AC7
           // Assert.IsTrue(ContentDetailsPage.OverviewTab.CreditPortlet.isRewardPointDisplay()) //AC8
        }

        [Test, Order(5)]

        public void P20_1_a05_SCORM_History_tab_View_Certificate_button_57918()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.CreteNewScorm(scormtitle + "TC57918");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");
           // ContentDetailsPage.Click_Check_in();
            //_test.Log(Status.Pass, "Verify New Scorm Course is check in  ");
            CommonSection.SearchCatalog(scormtitle + "TC57918");
            _test.Log(Status.Pass, "Search the scrom course  ");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57918");
            Assert.False(ContentDetailsPage.verifyHistotytab());
            _test.Log(Status.Pass, " scrom course not having history tab");
            ContentDetailsPage.Click_Enroll();
            _test.Log(Status.Pass, " clicking enroll ");
            Assert.IsTrue(ContentDetailsPage.VerifyCancelEnrollmentButton_Curriculum());
            // verify the test case for 57924
            Assert.IsTrue(ContentDetailsPage.verifyHistotytab());
            _test.Log(Status.Pass, " verify the history tab");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click at History ");
            //Assert.IsTrue(ContentDetailsPage.Historytab.verifydate());
           // _test.Log(Status.Pass, "validate the date ");
            Assert.IsTrue(ContentDetailsPage.Historytab.VerifyEnrollstatus());

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            _test.Log(Status.Pass, "click at start button ");
            Driver.Instance.selectWindow("Meridian Global - Core Domain");

            Driver.Instance.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
            Driver.Instance.SwitchTo().DefaultContent();




            // Driver.Instance.selectWindow("Meridian Global");
            //Driver.focusParentWindow();

           
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "click at History tab again ");
            Thread.Sleep(5000);
            Assert.IsTrue(ContentDetailsPage.Historytab.verifydate());
            _test.Log(Status.Pass, "Verify the Date and status as statrted ");
            Assert.IsTrue(ContentDetailsPage.Historytab.Verifystatrtedstatus());

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            _test.Log(Status.Pass, "Verify to Display at contiunue button ");
            ContentDetailsPage.ContentBanner.click_continuebutton();
            _test.Log(Status.Pass, "Verify to click at contiunue button");
            Driver.Instance.selectWindow("Meridian Global");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Pass, "Complete the Scrom page");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "click at History tab again ");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isViewCertificateButtonDisplay());

            _TC_57924 = true;
            TC57810 = true;
                                                                 }
        [Test, Order(6)]

        public void P20_1_a06_SCORM_Banner_Actions_Enroll_57924()
        {

            Assert.IsTrue(_TC_57924);
            _test.Log(Status.Pass, "Verify the View Detail Link ");

        }
        [Test, Order(7)]
        public void P20_1_a07_Scorm_Learner_Views_History_Tab_after_Enrolling_57810()
        {
            Assert.IsTrue(TC57810);
        }
       [Test, Order(8)]

        public void P20_1_a08_SCORM_Learner_views_Details_in_History_from_multiple_attempts_57919()
        {

            CommonSection.SearchCatalog(scormtitle + "TC57918");
            _test.Log(Status.Pass, "Search the scrom course  ");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC262557");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click at History ");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.verifyViewDetailslink());
            _test.Log(Status.Pass, "Verify the View Detail Link ");

        }
        [Test, Order(9), Description("Need to write the vaidation for local picker")]

        public void P20_1_a09_SCORM_Banner_Actions_Navigation_57921()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC57921");
            _test.Log(Status.Info, "Creating New Scorm");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            StringAssert.AreEqualIgnoringCase("The file was uploaded.", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(scormtitle + "TC57921");
            _test.Log(Status.Pass, "Search the scrom course  ");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57921");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.isbacktoPreviousPageLinkdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(scormtitle + "TC57921"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
        }
        [Test, Order(10)]

        public void P20_1_a10_SCORM_Banner_Actions_Edit_Save_Share_57922()
        {
            CommonSection.SearchCatalog(scormtitle + "TC57921");
            _test.Log(Status.Pass, "Search the scrom course  ");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57921");
            //ContentDetailsPage.Click_HistoryTab_Curriculum();
            //_test.Log(Status.Pass, "Click at History ");
            ContentDetailsPage.ClickSaveButton();
            _test.Log(Status.Pass, "Click at saved button ");
            Assert.IsTrue(ContentDetailsPage.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Click at Green saved button ");
            Assert.IsTrue(ContentDetailsPage.SocialSharingDropDown("Facebook"));
            _test.Log(Status.Pass, "verify the facebook ");
            Assert.IsTrue(ContentDetailsPage.editclickbuttonexist());

            _test.Log(Status.Pass, "verify the edit contentdetailpage ");

        }
        [Test, Order(11)]

        public void P20_1_a11_SCORM_Banner_Actions_Request_Access_57923()
        {

            CommonSection.CreteNewScorm(scormtitle + "TC57923");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isAccessApprovalAcordianDisplay());
            _test.Log(Status.Pass, "Verify Access Approval Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
           // Driver.Instance.Checkout();
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click check in button");
           // CommonSection.Logout();
          //  LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.SearchCatalog('"' + scormtitle + "TC57923" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57923");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            TC57930_1 = true;
        }
        [Test, Order(12)]
        public void a12_View_Prerequisities_to_SCORM_Course_26955()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26955");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Scorm Course is Created");
            AdminContentDetailsPage.AddPrequisites("General");
            ContentDetailsPage.Click_Check_in();

            CommonSection.SearchCatalog('"' + scormtitle + "TC26955" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26955");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay()); //AC1
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isMessagedisplay("Completed"));
            TC57930_2 = true;
        }
        //[Test]
        //public void a13_SCORM_Banner_Pass_Fail_For_Never_New_57925()
        //{
        //   //Marking this test cases as Can't automated as it involve some content config setting
        //}
        [Test, Order(13)]
        public void P20_1_a13_SCORM_Banner_Actions_Survey_57926()
        {
            #region Survey with Required Status Yes
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewScorm(scormtitle + "TC57926");
            _test.Log(Status.Info, "A new SCROM Course Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");

            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");

            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            #endregion
           
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(scormtitle + "TC57926");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57926");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.Click_Enroll();
            _test.Log(Status.Info, "Click on Enroll Button");
            //Assert.IsTrue(Driver.comparePartialString("You are now enrolled.", ContentDetailsPage.getEnrollmentSuccessMessage()));
           // _test.Log(Status.Info, "Verify Succcess Message");
            ContentDetailsPage.OpenItemScorm();
            _test.Log(Status.Info, "Click on open item ");
            Driver.Instance.selectWindow("Meridian Global");
            ContentDetailsPage.SCROM.CompleteSCROMCourse();
            _test.Log(Status.Pass, "Complete the Scrom page");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.RequiredSurveymessage("Complete 1 survey(s) to receive your certificate."));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeSurveyButtonDisplay());
            ContentDetailsPage.ContentBanner.Click_TakeSurveybutton();
                        
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");
            Assert.True(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            
            TC57930_3 = true;
        }
        //[Test]
        //public void a15_SCORM_Banner_Pass_Fail_For_Always_New_57927()
        //{
        //    //Marking this test cases as Can't automated as it involve some content config
        //}
        //[Test]
        //public void a16_SCORM_Banner_Pass_Fail_For_Ask_User_57928()
        //{
        //    //Marking this test cases as Can't automated as it involve some content config

        //}
        //[Test]
        //public void a17_SCORM_Banner_Pass_Fail_for_One_Time_Content_Usage_57929()
        //{
        //    //Marking this test cases as Can't automated as it involve some content config
        //}
        [Test, Order(14)]
        public void P20_1_a18_SCORM_Banner_Notifications_57930()
        {
            Assert.IsTrue(TC57930);
            Assert.IsTrue(TC57930_1);
            Assert.IsTrue(TC57930_2);
            Assert.IsTrue(TC57930_3);
        }
        [Test, Order(15)]
        public void P20_1_a19_SCORM_What_Other_Content_can_learner_take_57664()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewScorm(scormtitle + "TC57664");
            _test.Log(Status.Info, "Create A new SCROM Course");
           // ContentDetailsPage.Click_Check_in();
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC57664");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");

            CurriculumContentPage.AddCurriculumBlock.AddBlockAs_OrderedType("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");

            CurriculumContentPage.AddTrainingActivities_UnOrdered(scormtitle + "TC57664");
            _test.Log(Status.Info, "Add training Activities");
            
            AdminContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + scormtitle + "TC57664" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + scormtitle + "TC57664" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57664"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay());
            ContentDetailsPage.OverviewTab.PartoftheseCollection.expandPartofthesecollection();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.PartoftheseCollection.isContentdisplay(curriculamtitle + "TC57664"));
            

        }
       
       
        [Test, Order(16)]//"Dolly's Scorm 1.2 Course w/ Image and Promo Video_12182018"
        public void a20_Learner_Plays_Promotional_Videos_From_Scorm_Course_35376()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreteNewScorm(scormtitle + "TC35358");
            _test.Log(Status.Info, "Create A new SCROM Course");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
          
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            DocumentPage.ClickButton_CheckIn();
           
           
            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + scormtitle + "TC35358" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + scormtitle + "TC35358" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC35358"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            //Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            //_test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            //ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            //_test.Log(Status.Info, "Clicked Play button of Promotional video");
            //Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            //_test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            //Assert.IsTrue(ContentDetailsPage.PromotionalVideo.isFullScreenIconisdisabled()); //Click on Full Screen Icon
            
        }
        [Test, Order(17)]
        public void P20_1_a24_View_SCORM_Course_Details_26366()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreteNewScorm(scormtitle + "TC26366");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");
            CommonSection.SearchCatalog('"' + scormtitle + "TC26366" + '"');
            _test.Log(Status.Info, "Search created document from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26366");
            _test.Log(Status.Info, "Click searched document title");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(scormtitle + "TC26366"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
          

        }
       
        [Test, Order(18)]
        public void P20_1_a22_Equivalent_Items_to_a_SCORM_Course_27162()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC27162");
            _test.Log(Status.Info, "A new SCROM Course Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
          
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
           // string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
           
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(scormtitle + "TC27162");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC27162");
            Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());
        }
        [Test, Order(19)]
        public void P20_1_a23_SCORM_Overview_Tab_Verify_Overview_contents_for_SCORM_course_57606()
        {
            CommonSection.CreteNewScorm(scormtitle+"TC57606");
            _test.Log(Status.Info, "A new SCROM Course Created");
            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            PrerequisitesPage.ClickAddPrerequisites();
            _test.Log(Status.Info, "Click on ADD Prerequisities Button");
            Assert.IsTrue(AddPrerequisitesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddPrerequisitesPage.SearchFor("");
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");

            Assert.IsTrue(PrerequisitesPage.isPrerequisitesadded());
            _test.Log(Status.Pass, "Verify Prerequisites are added to Curriculumn");
            AddPrerequisitesPage.ClickBackButton();
            DocumentPage.ClickButton_CheckIn();
            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "_TC57606");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(scormtitle + "TC57606");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("learner 101");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("days");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickDueDateTab();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            _test.Log(Status.Pass, "Verify Copletion count saved properly");
            CreateTrainingAssignmentPage.clickAssignButton();
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();

            CommonSection.SearchCatalog(scormtitle + "TC57606");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC57606");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
        }
    }
}



