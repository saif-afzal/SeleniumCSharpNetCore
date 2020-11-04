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
    public class P3RegressionTests : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPath" + Meridian_Common.globalnum;


        public P3RegressionTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
        }
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string classroomcoursetitle = "ClassRoomCourseTitle" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;

        bool TC_34081 = false;
        bool TC_34082 = false;
        string user = "User" + Meridian_Common.globalnum;
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
        string bundlecourse = "GeneralCourse" + Meridian_Common.globalnum;
       
        bool TC_10574 = false;
        bool TC_10823 = false;
        bool TC_10879 = false;

       
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
     
        bool ArchivedScale = false;
        bool learner_view_required_credit = false;
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }


        [Test, Order(8)]
        public void A08_Admin_Merges_Users_that_Both_Have_Selected_Interests_33987()
        {
            Driver.CreateNewAccount_Specific(user + "_User1");
            LoginPage.LoginAs(user + "_User1").WithPassword("").Login();
            CommonSection.Avatar.Account();
            AccountPage.ClickProfiletab();
            string primaryuser1_tags = AccountPage.addInterest("_User1");
            Driver.CreateNewAccount_Specific(user + "_User2");
            LoginPage.LoginAs(user + "_User2").WithPassword("").Login();
            CommonSection.Avatar.Account();
            AccountPage.ClickProfiletab();
            string primaryuser2_tags = AccountPage.addInterest("_User2");
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.People.MergeUser();
            MergeUsersPage.mergeUsers(user + "_User1", user + "_User2");

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs(user + "_User1").WithPassword("").Login();
            CommonSection.Avatar.Account();
            AccountPage.ClickProfiletab();
            string expectedTag = Driver.Instance.GetElement(By.XPath("//a[@class='btn btn-add-remove btn-outline-primary']")).Text;
            StringAssert.AreEqualIgnoringCase(primaryuser1_tags, expectedTag);


        }
        [Test, Order(1)]
        public void A01_Test_Access_Keys_with_Bundle_34151()
        {
            #region Create General Course and Bundle With Cost and Access keys Enabled
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse, "Test General Course");
            GeneralCoursePage.setCost("5");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.Learn.Home();
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Creating a Paid Bundle Course with Access Keys");
            objCreate.FillBundlePage(browserstr);
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            BundlesPage.enableAccessKeys();
            _test.Log(Status.Info, "Access Keys Enabled");
            BundlesPage.addContentIntoBundle(generalcourse);
            _test.Log(Status.Info, "Adding Paid General Course into Bundle");
            DocumentPage.ClickButton_CheckIn();

            #endregion
            #region Purchase Access Keys for Bundle
            ShoppingCarts.purchaseAccessKeys("Bundle", Variables.bundleTitle + browserstr);
            ShoppingCarts.completePurchaseProcess();
            _test.Log(Status.Info, "Keys has been purchased from shopping cart");
            CommonSection.Manage.Training();
            CommonSection.Manage.AccessKeys();
            AccessKeysPage.searchForContent(Variables.bundleTitle + browserstr);
            AccessKeysPage.assignKeysToLearner("ershivam.iimt@ggmail.com");
            _test.Log(Status.Info, "Keys has been assigned to learner");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            #endregion
            LoginPage.LoginAs("ssuser1").WithPassword("password").Login();
            Assert.IsTrue(BundlesPage.searchforBundle(Variables.bundleTitle + browserstr, generalcourse));
            _test.Log(Status.Info, "General Course Displaying inside Bundle, Assertion Pass");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//input[@value='Enroll']")));
            TC_10574 = true;
            _test.Log(Status.Info, "Cost of General Course Override, Assertion Pass");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();

        }
        [Test, Order(11)]
        public void A11_Access_Key_Expire_When_User_Completed_the_Content_Bundle_34189()
        {
            #region Create General Course and Bundle With Cost and Access keys Enabled
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34189", "Test General Course");
            GeneralCoursePage.setCost("5");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.Learn.Home();
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Creating a Paid Bundle Course with Access Keys");
            objCreate.FillBundlePage(browserstr + "TC34189");
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            BundlesPage.enableAccessKeys();
            _test.Log(Status.Info, "Access Keys Enabled");
            BundlesPage.addContentIntoBundle(generalcourse + "TC34189");
            _test.Log(Status.Info, "Adding Paid General Course into Bundle");
            DocumentPage.ClickButton_CheckIn();

            #endregion
            #region Purchase Access Keys for Bundle
            ShoppingCarts.purchaseAccessKeys("Bundle", Variables.bundleTitle + browserstr + "TC34189");
            ShoppingCarts.completePurchaseProcess();
            _test.Log(Status.Info, "Keys has been purchased from shopping cart");
            CommonSection.Manage.Training();
            CommonSection.Manage.AccessKeys();
            AccessKeysPage.searchForContent(Variables.bundleTitle + browserstr + "TC34189");
            AccessKeysPage.assignKeysToLearner("ershivam.iimt@ggmail.com");
            _test.Log(Status.Info, "Keys has been assigned to learner");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            #endregion
            LoginPage.LoginAs("ssuser1").WithPassword("password").Login();
            Assert.IsTrue(BundlesPage.searchforBundle(Variables.bundleTitle + browserstr + "TC34189", generalcourse + "TC34189"));
            _test.Log(Status.Info, "General Course Displaying inside Bundle, Assertion Pass");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//input[@value='Enroll']")));
            _test.Log(Status.Info, "Cost of General Course Override, Assertion Pass");
            GeneralCoursePage.completeGeneralCourse();
            BundlesPage.simplysearchforBundle(Variables.bundleTitle + browserstr + "TC34189");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'You have already completed this item. You must use another access key to begin a new attempt.')]")));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();

        }
        [Test, Order(22), Description("Dependent on 17"), Category("AutomatedP1")]
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
            Assert.IsTrue(ContentDetailsPage.CertificationPortlet.isBoldTextDisplayed("2.5 Default Credit Type"));
            _test.Log(Status.Info, "Verify Credit type Value needed to complete this certificaiton");
            Assert.IsTrue(ContentDetailsPage.ObjectivesPorlet.isTextDisplayed("Below is a list of content you’ve previously completed that awards this credit type."));
            _test.Log(Status.Info, "Verify Text displayed for Credit type Value needed to complete this certificaiton");
        }

        [Test, Order(3)]
        public void A03_Test_Access_Keys_with_Certification_34152()
        {
            #region Create General Course and Certification With Cost and Access keys Enabled
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "Cert", "Test General Course");
            GeneralCoursePage.setCost("5");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.Learn.Home();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Creating a Paid Certification Course with Access Keys");
            objCreate.FillCertificationPage(browserstr);
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            BundlesPage.enableAccessKeys();
            _test.Log(Status.Info, "Access Keys Enabled");
            CertificatePage.addContentIntoCertificate(generalcourse + "Cert");
            _test.Log(Status.Info, "Adding Paid General Course into Curriculum");
            DocumentPage.ClickButton_CheckIn();

            #endregion
            #region Purchase Access Keys for Certification
            ShoppingCarts.purchaseAccessKeys("Certification", Variables.certTitle + browserstr);
            ShoppingCarts.completePurchaseProcess();
            _test.Log(Status.Info, "Keys has been purchased from shopping cart");
            CommonSection.Manage.Training();
            CommonSection.Manage.AccessKeys();
            AccessKeysPage.searchForContent(Variables.certTitle + browserstr);
            AccessKeysPage.assignKeysToLearner("ershivam.iimt@ggmail.com");
            _test.Log(Status.Info, "Keys has been assigned to learner");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            #endregion
            LoginPage.LoginAs("ssuser1").WithPassword("password").Login();
            Assert.IsTrue(CertificatePage.searchforCertification(Variables.certTitle + browserstr, generalcourse + "Cert"));
            _test.Log(Status.Info, "General Course Displaying inside Curriculuam, Assertion Pass");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//input[@value='Enroll']")));
            TC_10879 = true;
            _test.Log(Status.Info, "Cost of General Course Override, Assertion Pass");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            LoginPage.LoginAs("").WithPassword("").Login();

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
            HomePage.CertificationPortlet.ClickViewDetailsButtonofCertificationTitle("testcert_0709", "View Details");
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

        public void P20_1_Learner_Views_Content_And_Credit_Hours_Completed_For_Core_Certification_34011()
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

        [Test, Order(19), Category("P1"), Category("AutomatedP1")]
        public void A16_Batch_Enroll_and_MarkComplete_User_into_Online_Course_with_Cost_34154()
        {
            #region Create General Course with Cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34154", "Test General Course");
            GeneralCoursePage.setCost("5");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Goto Training Page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Click on Batch enroll online course link");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34154");
            _test.Log(Status.Info, "Search for online course");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//div[@aria-disabled='true']")));
            _test.Log(Status.Pass, "Batch Enroll and MarkComplete User into Online Course with Cost");
            //  CommonSection.Manage.TrainingPage.searchFor_UsersToEnroll("");
            //  CommonSection.Manage.TrainingPage.BatchEnroll_OnlineCourse(); // In Progress
            // xpath = //label[@id='lblMarkComplete']

        }

        [Test, Order(20), Category("P1"), Category("AutomatedP1")]
        public void A17_BatchEnroll_And_MarkComplete_User_into_NoCost_OnlineCourse_where_Toggle_SetTo_Yes_34149()
        {
            #region Create General Course without cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34149", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Goto Training Page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Click on Batch enroll online course link");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34149");
            _test.Log(Status.Info, "Search for online course");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//div[@aria-disabled='true']")));
            _test.Log(Status.Pass, "Mark Enrollee complete toggle is disabled");
            CommonSection.Manage.TrainingPage.searchFor_UsersToBatchEnroll("");
            _test.Log(Status.Info, "Search for user to batch enroll");
            CommonSection.Manage.TrainingPage.select_UsersToBatchEnroll();
            _test.Log(Status.Info, "Select users to batch enroll");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.switchToggle_toYes_MarkEnrolleesComplete());
            _test.Log(Status.Pass, "Toggle set to Yes");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.Click_BatchEnroll_Button_OnlineCourse_WhenToogle_Yes());
            _test.Log(Status.Pass, "BatchEnroll And MarkComplete User into NoCost Online Course where Toggle Set To Yes");

        }

        [Test, Order(21), Category("P1"), Category("AutomatedP1")]
        public void A18_BatchEnroll_And_MarkComplete_User_into_NoCost_OnlineCourse_where_Toggle_SetTo_No_34163()
        {
            #region Create General Course without cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34163", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Goto Training Page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Click on Batch enroll online course link");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34163");
            _test.Log(Status.Info, "Search for online course");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//label[contains(text(),'Mark Enrollees Complete')]")));
            _test.Log(Status.Pass, "Mark Enrollee complete lable is disabled");
            CommonSection.Manage.TrainingPage.searchFor_UsersToBatchEnroll("");
            _test.Log(Status.Info, "Search for user to batch enroll");
            CommonSection.Manage.TrainingPage.select_UsersToBatchEnroll();
            _test.Log(Status.Info, "Select users to batch enroll");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.Click_BatchEnroll_Button_OnlineCourse_WhenToogle_No());
            _test.Log(Status.Pass, "BatchEnroll And MarkComplete User into NoCost Online Course where Toggle Set To No");

        }

        [Test, Order(22), Category("P1"), Category("AutomatedP1")]
        public void A19_UserManager_BatchEnroll_and_MarkComplete_User_into_NoCost_Online_Course_34164()
        {
            #region Create Learner
            Driver.CreateNewAccount("Learner");
            _test.Log(Status.Info, "Created Learner" + Meridian_Common.NewUserId);
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Logged in with admin");
            #endregion

            #region Create General Course without cost
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "TC34164", "Test General Course");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "General course created");
            #endregion
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Training page");
            CommonSection.Manage.TrainingPage.click_BatchEnrollment_OnlineCourse();
            _test.Log(Status.Info, "Goto batch enrollment online course page");
            CommonSection.Manage.TrainingPage.searchFor_OnlineContent(generalcourse + "TC34164");
            _test.Log(Status.Info, "search for online content");
            CommonSection.Manage.TrainingPage.click_EnrollUserButton();
            _test.Log(Status.Info, "Click enroll user button");
            Assert.IsTrue(Driver.Instance.isPresent(By.XPath("//label[contains(text(),'Mark Enrollees Complete')]")));
            _test.Log(Status.Pass, "Mark Enrollees Complete Lable Displaying");
            CommonSection.Manage.TrainingPage.searchFor_UsersToBatchEnroll(Meridian_Common.NewUserId);
            _test.Log(Status.Info, "Search for user");
            CommonSection.Manage.TrainingPage.select_UsersToBatchEnroll();
            _test.Log(Status.Info, "Select user's to batch enroll");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.switchToggle_toYes_MarkEnrolleesComplete());
            _test.Log(Status.Pass, "Switch Toggle to Yes");
            Assert.IsTrue(CommonSection.Manage.TrainingPage.Click_BatchEnroll_Button_OnlineCourse_WhenToogle_Yes());
            _test.Log(Status.Pass, "Click Batch Enroll Button When Toggle is Set to Yes");
            CommonSection.Manage.People();
            _test.Log(Status.Info, "Goto People Page");
            PeoplePage.Search_User(Meridian_Common.NewUserId);
            _test.Log(Status.Info, "Search user");
            PeoplePage.viewTranscript();
            _test.Log(Status.Info, "Open User's Transcript");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//td[contains(.,'" + generalcourse + "TC34164" + "')]")));
            _test.Log(Status.Pass, "Correct Course displayin in user's transcript");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//td[contains(.,'Completed')]")));
            _test.Log(Status.Pass, "Status displayin as Completed in user's transcript");
        }

        [Test, Order(10), Category("AutomatedP1")]

        public void J_Admin_Expand_Collapse_Recommendation_Portlet_From_HomepageCustomization_33573()
        {
            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "Navigate to Homepage Customization");

            HomePageCustomizationPage.Click_Collapse_RecentlyAddedPortlet();
            _test.Log(Status.Info, "Collapse Recently Added Recommendation Portlet");

            HomePageCustomizationPage.Click_Collapse_RecommendationPortlet();
            _test.Log(Status.Info, "Collapse Recommendation Based on Your Interest Portlet");

            HomePageCustomizationPage.ClickButton_Save();
            _test.Log(Status.Info, "Homepage Customization Setting Save");

            Assert.IsFalse(RecommendationsPage.Verify_RecentlyAddedPortlet());
            _test.Log(Status.Info, "Assert Recently Added Portlet Not Visible : Pass");

            Assert.IsFalse(RecommendationsPage.Verify_ContentTagPortlet());
            _test.Log(Status.Info, "Assert Recommendation Based on Your Ineterst Portlet Not Visible : Pass");

            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "Navigate to Homepage Customization");

            HomePageCustomizationPage.Click_Expand_RecentlyAddedPortlet();
            _test.Log(Status.Info, "Expand Recently Added Recommendation Portlet");

            HomePageCustomizationPage.Click_Expand_RecommendationPortlet();
            _test.Log(Status.Info, "Expand Recommendation Based on Your Interest Portlet");

            HomePageCustomizationPage.ClickButton_Save();
            _test.Log(Status.Info, "Homepage Customization Setting Save");

            Assert.IsTrue(RecommendationsPage.Verify_RecentlyAddedPortlet());
            _test.Log(Status.Info, "Assert Recently Added Portlet Visible : Pass");

            Assert.IsTrue(RecommendationsPage.Verify_ContentTagPortlet());
            _test.Log(Status.Info, "Assert Recommendation Based on Your Ineterst Portlet Visible : Pass");

        }

        [Test, Order(11), Category("AutomatedP1")]

        public void K_Admin_Drag_And_Drop_Recommendation_Portlets_33574()
        {
            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "Navigate to Homepage Customization");

            HomePageCustomizationPage.DragandDrop_RecommendationPortlet();
            _test.Log(Status.Info, "Dragging Recommendation Portlet");

            HomePageCustomizationPage.ClickButton_Save();
            _test.Log(Status.Info, "Homepage Customization Setting Save");

            Assert.IsTrue(RecommendationsPage.Verify_ContentTagPortlet());
            _test.Log(Status.Info, "Assert Recommendation Based on Your Ineterst Portlet Not Visible : Pass");

            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "Navigate to Homepage Customization");

            HomePageCustomizationPage.DragandDrop_RecommendationPortlet_Revert();
            _test.Log(Status.Info, "Dragging Back the Portlet To Previous Position");

            HomePageCustomizationPage.ClickButton_Save();
            _test.Log(Status.Info, "Homepage Customization Setting Save");


        }
        [Test, Order(30), Category("AutomatedP1")]
        //Creating a Subscription
        public void Z04_CreateANewSubscription_10853()
        {
            CommonSection.CreateLink.Subscription();
            //   Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            objCreate.FillSubscriptionPage(browserstr);
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());

            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            //String Assertion on new Subscription creation 


            //objContent.ContentSearch_Click();
            //objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);

            //Assertion for bundle displayed on search
            //Assert.IsTrue(objContentSearch.ViewInList(Variables.subscriptionTitle + browserstr));
        }


        [Test, Order(31), Category("AutomatedP1")]
        public void Z05_ManageASubscription_10854()
        {

            CommonSection.CreateLink.Subscription();

            objCreate.FillSubscriptionPage("editcontent");
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(Variables.subscriptionTitle + "editcontent");

            SearchResultsPage.ClickCourseTitle(Variables.subscriptionTitle + "editcontent");
            SubscriptionPage.ClickEdit();
            //   Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            SummaryPage.ClickSavebutton();

            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");

        }
        [TearDown]
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
                driver.Navigate().Refresh();
            }
        }
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }




    }

    //public class AccessKeysPage
    //{
    //    public static ConentCommand Conent { get { return new ConentCommand(); } }

    //    public static void assignKeysToLearner(string v)
    //    {
    //        Driver.clickEleJs(By.XPath("//table[1]/tbody[1]/tr[1]/td[4]/div[1]/a[1]"));
    //        Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_txtEmail1']")).SendKeysWithSpace(v);
    //        IWebElement webElement = Driver.Instance.FindElement(By.XPath("//a[@id='MainContent_UC1_btnCancel']"));
    //        webElement.SendKeys(Keys.Tab);
    //        Thread.Sleep(1000);
    //        Driver.clickEleJs(By.XPath("//input[@value='Assign']"));
    //        Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
    //    }

    //    public static void searchForContent(string v)
    //    {
    //        Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_txtSearch']")).SendKeysWithSpace(v);
    //        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));
    //        Thread.Sleep(2000);
    //    }

    //    public static void ClickViewDetails(string v)
    //    {
    //        Driver.clickEleJs(By.XPath("//a[contains(text(),"+v+")]/following::a[1]"));
    //    }
    //}

    //public class ConentCommand
    //{
    //    public bool? ContentFormat()
    //    {
    //        return Driver.GetElement(By.XPath("//tr/td/p")).Displayed;
    //    }
    //}
}
