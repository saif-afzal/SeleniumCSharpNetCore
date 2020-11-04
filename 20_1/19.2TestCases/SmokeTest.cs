using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using ParallelTesting_Solution2;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
//using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Threading;
using TestAutomation.helper;
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;


//using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
     [Parallelizable(ParallelScope.Fixtures)]
    public class SmokeTest_20_2 : Hooks
    {
        string browserstr = string.Empty;
        
        public SmokeTest_20_2(string browser)
             : base()
        {
            browserstr = browser;
            IWebDriver driver = Driver;
            InitializeBase(driver);
           
         
            
        }
        //string CareerPathTitle = "CareerPathTitle" + Driver.generateRandom(1, 100);
        //string CompetencyTitle = "CompetencyTitle" + Driver.generateRandom(1, 100);
        //string JobTitle = "JobTitle" + Driver.generateRandom(1, 100);
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        

        //private TestContext testContextInstance;

        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}
        //  [OneTimeSetUp]
        public void Login()
        {

            //LoginPage.GoTo();
            ////    LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
      
    

       [Test, Category("Smoke"), Order(1)]
        public void LoginSmoke_8597()
        {
           
            loginPage1.GoTo();
            _test.Log(Status.Pass, "Site opens successfully");
            loginPage1.LoginClick();
            _test.Log(Status.Pass, "Login CLick passes");
            loginPage1.LoginAs("siteadmin").WithPassword("password").Login();
            _test.Log(Status.Pass, "login as siteadmin successful");
            Assert.IsTrue(Driver.Title == "Home");//checks the Home page title
        }
        [Test, Category("Smoke"), Order(2)]
        public void Help_238()
        {

         

            commonSection.ClickHelpIcon();
            _test.Log(Status.Pass, "help icon opens successfully");
            Assert.IsTrue(helpPage1.CheckTitle());//checks the Help page with one click in it

             }
        [Test, Category("Smoke"), Order(3)]
        public void Search_6833()
        {

        

            commonSection.CatalogSearchText("Test");
            _test.Log(Status.Info, "Test searched successfully from Catalog search");
            Assert.IsTrue(searchResultsPage1.CheckSearchRecord("Test") >= 1);//chcks the records are not zero
            _test.Log(Status.Pass, "search record is greater than 1"); //CommonSection.Manage.People();
            commonSection.Manage.People();
            _test.Log(Status.Info, "open people page from common section ");

            manageUsersPage1.SearchUser("");
            _test.Log(Status.Info, "blank search takes place from manage users page");
            Assert.IsTrue(manageUsersPage1.DisplaysUserlist >= 1);//checks people search is working
            _test.Log(Status.Pass, "search record is greater than 1");

        }
        [Test, Category("Smoke"), Order(4)]
        public void Administration_Organization_Search_56127()
        {
            commonSection.Administer.People.Organizations();
            _test.Log(Status.Info, "Organization page opens");
            organizationsPage1.ClickSearch();
            _test.Log(Status.Info, "Done Blank search");
            Assert.IsTrue(organizationsPage1.DisplaySearchRecords > 1);//checks Organization search is working
        }


        [Test, Category("Smoke"), Order(5)]
        public void Careers_Manage_JobTitle_22212() // used this test cases for job title search
        {

            commonSection.Manage.Careers.JobTitletab();
            _test.Log(Status.Info, "Opened Careers page");
            // CommonSection.Administer.People.JobTitles();not avaialable in 18.1
            careersPage1.JobTitleKI.SearchJobtitle("");
            _test.Log(Status.Info, "did blank search in job tiltle");
            Assert.IsTrue(careersPage1.JobTitleKI.DisplaySearchRecords >= 1);
            //   JobTitlesPage.SearchJobtitle("");not avaialable in 18.1
            //  Assert.IsTrue(JobTitlesPage.DisplaySearchRecords > 1);//checks Jobtitle search is working
        }
        [Test, Category("Smoke"), Order(6)]
        public void Administration_HomePage_Customization_23935()
        {
            commonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "opened home customization page");
            Assert.IsTrue(homePage1.Title == "Home");// just checks the title
        }
        [Test, Category("Smoke"), Order(7)]
        public void Reports_24843()
        {
            commonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            reportConsolePage1.SearchText("My");
            _test.Log(Status.Info, "Searched My");
            Assert.IsTrue(reportConsolePage1.DisplayResult > 1);//checks results display more than 1
            reportConsolePage1.ClickMyTrainingProgress();
            _test.Log(Status.Info, "Clicked My Training Progress");
            detailsPage1.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            runReportPage1.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            // Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            meridianGlobalReportingPage1.ClickDetails();
            _test.Log(Status.Info, "Clicked go button having details selected and opens details page");
            Assert.IsTrue(detailsPage1.CheckDetailsTabText.EndsWith("Details"));//retrieves the text from details tab
            detailsPage1.ClickCloseWindowlink();
            _test.Log(Status.Info, "Details page closes");
            Assert.IsTrue(meridianGlobalReportingPage1.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(meridianGlobalReportingPage1.Displays > 1);
            detailsPage1.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(myTrainingProgressPDFPage1.Title.EndsWith("My_Training_Progress.pdf"));
            //   MyTrainingProgressPDFPage.ClickBrowsertabX();
            //   Assert.IsTrue(DetailsPage.Displays>1);
            meridianGlobalReportingPage1.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            Assert.IsTrue(runReportPage1.Title == "Run Report");
            Assert.IsTrue(Driver.focusParentWindow());
            commonSection.Avatar.Reports();
            _test.Log(Status.Info, "open reports from KI");
            reportsPage1.MyTrainingProgress.ClickRunReport();
            _test.Log(Status.Info, "opens run report page from KI");
            reportsPage1.ReportCriteriaModal.ClickRunReport();
            _test.Log(Status.Info, "click run report from KI");
            meridianGlobalReportingPage1.ClickDetails();
            _test.Log(Status.Info, "click the go button having details option displayed");
            string restext = detailsPage1.CheckDetailsTabText;
            StringAssert.EndsWith("Details", restext);
            detailsPage1.ClickCloseWindowlink();
            _test.Log(Status.Info, "closed the details page ");
            Assert.IsTrue(meridianGlobalReportingPage1.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(meridianGlobalReportingPage1.Displays > 1);
            detailsPage1.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(myTrainingProgressPDFPage1.Title.EndsWith("My_Training_Progress.pdf"));

            meridianGlobalReportingPage1.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(runReportPage1.Title, "Reports");

        }
        [Test, Category("Smoke"), Order(8)]
        public void Create_SCROM_Course_7251()
        {
            commonSection.CreateLink.SCORM();
            _test.Log(Status.Info, "open scorm page");
            createPage1.ClickBrowsebutton();
            _test.Log(Status.Info, "browse the content and click create button");
            //  //  CreatePage.UploadScormfile("\\fileserver\\maindrive\\product_team\\SCORM\\SCORM_1_2\\maritime_navigation_exam_only.zip");
            //  CreatePage.ClickCreatebutton();
            Assert.IsTrue(summaryPage1.Title == "Summary", "Expected = Summary, but actual was " + summaryPage1.Title);
            StringAssert.AreEqualIgnoringCase("The course was created.", summaryPage1.GetSuccessMessage(), "Error message is different");
            summaryPage1.UpdateTitle("Maritime Navigation - Exam only for Migration Test");
            //   SummaryPage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", contentDetailsPage1.GetSuccessMessage(), "Error message is different");
            contentDetailsPage1.ClickCheckInbutton();
            _test.Log(Status.Info, "Checkin scorm course");
        }
        [Test, Category("Smoke"), Order(9)]
        public void Search_SCROM_Course_26248()
        {
            commonSection.CatalogSearchText("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "search migration");
            Assert.IsTrue(searchResultsPage1.CheckSearchRecord("Maritime Navigation - Exam only for Migration Test") >= 1);
            searchResultsPage1.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "opens searched content link");
            Assert.IsTrue(contentDetailsPage1.CheckCourseTitle("Maritime Navigation - Exam only for Migration Test"));
            contentDetailsPage1.ClickOpenItembutton();
            _test.Log(Status.Info, "Enrols and open the scorm course");
            Assert.IsTrue(courseLaunchModalPage1.Exist("Maritime Navigation - Exam only for Migration Test"));
            // CourseLaunchModalPage.ClickBrowserX();
            Assert.IsTrue(contentDetailsPage1.ContentBanner.isContinueButtonDisplsplay());
        }
        [Test, Category("Smoke"), Order(10)]
        public void Delete_SCROM_Course_7438()
        {
            commonSection.Manage.Training();
            _test.Log(Status.Info, "open training page");
            trainingPage1.ManageContentPortlet.SearchForContent("Migration");
            _test.Log(Status.Info, "search for content migration");
            Assert.IsTrue(searchResultsPage1.CheckSearchRecord("Migration") >= 1);
            searchResultsPage1.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "click the searjced title link");
            contentDetailsPage1.Summary.ClickViewButton();//need towrite the code
            _test.Log(Status.Info, "CLick view button");
            Assert.IsTrue(summaryPage1.Title == "Maritime Navigation - Exam only for Migration Test");//need towrite the code
                                                                                                     //Assert.IsTrue(ContentDetailsPage.CheckCourseTitleOnClickingEditButton("Maritime Navigation - Exam only for Migration Test"));
            contentDetailsPage1.DeleteContent();
            _test.Log(Status.Info, "deleting the content");
            //  StringAssert.StartsWith("Success", ContentDetailsPage.GetRemovalSuccessMessage(), "Error message is different");
            commonSection.Manage.Training();
            _test.Log(Status.Info, "open training page");
            trainingPage1.ManageContentPortlet.SearchForContent("Migration");
            _test.Log(Status.Info, "search for content migration");
            Assert.IsTrue(searchResultsPage1.CheckSearchRecord("Migration") == 0);
        }

        //  //    //[Test, Category("Smoke"), Order(8)]
        //  //    public void Navigate_to_Public_Catalog()
        //  //    {
        //  //        Driver.Instance.Navigate().GoToUrl("https://prodsupport-ki-17-3.meridianksi.net/public/trainingcatalog.aspx");
        //  //        //EnterURL("baseqa-17-3-m-c1.meridianksi.net/public/trainingcatalog.aspx");
        //  //        Assert.IsTrue(CatalogPage.Title == "Public Catalog");
        //  //        CatalogPage.SearchContent();
        //  //        Assert.IsTrue(SearchResultsPage.CheckSearchRecord("") > 1);
        //  //        SearchResultsPage.ClickCourseTitle("");
        //  //        Assert.IsTrue(ContentDetailsPage.CheckCourseTitle(""));

        //  //    }

        //  //    //[Test, Category("Smoke"), Order(7)]

        //  //    public void Social()
        //  //    {
        //  //        CommonSection.Learn.Spaces();
        //  //        Assert.IsTrue(SpacesPage.CheckTitle == "Collaboration Spaces");
        //  //        SpacesPage.TypePublicSpace.ClickSpaceTitle();
        //  //        SpacesPage.SpaceTitlePage.ClickJoinButton();
        //  //        StringAssert.AreEqualIgnoringCase("You Joined the Collaboration Space", SpacesPage.GetSuccessMessage(), "Error message is different");
        //  //        SpacesPage.SpaceTitlePage.SelectAccessSpace();
        //  //        Assert.IsTrue(CSLaunchPage.Exist());

        //  //    }

        [Test, Category("Smoke"), Order(11)]
        public void About_the_System_Link_7662()
        {
            commonSection.SearchCatalog("");
            _test.Log(Status.Info, "do blank catalog search");
            //CommonSection.Learn.Home();
            homePage1.ClickAboutLink();
            _test.Log(Status.Info, "CLick about link");
            Assert.IsTrue(homePage1.ClickModalX());
            Assert.IsTrue(homePage1.Title == "Search Results");

        }
        [Test, Category("Smoke"), Order(12)]
        public void View_System_Certificate_35597()
        {
            commonSection.Administer.System.SystemAdministration.SystemCertificate("Certificates");
            _test.Log(Status.Info, "opens certificate page");
            Assert.IsTrue(systemCertificatePage1.Title == "System Certificate");
            systemCertificatePage1.Preview("Default");
            _test.Log(Status.Info, "CLick default button");
            Assert.IsTrue(certificatePage1.VerifyFileDownload("\\Certificate.pdf"));
            Assert.IsTrue(systemCertificatePage1.Title == "System Certificate");

        }
        //  [Test, Category("Smoke"), Order(13)]
        //  public void tc_23724_Complete_Purchase_with_Cybersource()  //share step 13754
        //  {
        //      CommonSection.Logout();
        //      LoginPage.GoTo("https://baseqa-20-2-m-c1.meridianksi.net/");
        //      _test.Log(Status.Pass, "Site opens successfully");
        //      LoginPage.LoginClick();
        //      _test.Log(Status.Pass, "Login CLick passes");
        //      LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
        //      _test.Log(Status.Pass, "login as siteadmin successful");
        //      Assert.IsTrue(HomePage.Title == "Home");
        //      Assert.IsTrue(CommonSection.cleanshoppingcart());
        //      _test.Log(Status.Info, "Clean shopping cart if any added before");
        //      CommonSection.CreateGeneralCourse(generalcoursetitle + "_TC23724");
        //      _test.Log(Status.Info, "New general course created");
        //      AdminContentDetailsPage.AddCost();
        //      ContentDetailsPage.ClickEditContent_New19_2();
        //      DocumentPage.ClickButton_CheckIn();

        //      CommonSection.SearchCatalog(generalcoursetitle + "_TC23724");
        //      SearchResultsPage.ClickCourseTitle(generalcoursetitle + "_TC23724");
        //      Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());
        //      ContentDetailsPage.ClickAddtoCart_GeneralCourse();
        //      Assert.IsTrue(ContentDetailsPage.ClickAddtoCartPortlet.isAddedtocardinfodisplay());
        //      Assert.IsTrue(CommonSection.isCountincrease_ShopingCart());
        //      CommonSection.ClickShoppingCart();
        //      _test.Log(Status.Info, "Click on Shopping cart icon");
        //      ShoppingCartPage.Checkout();
        //      CheckoutPage.selectPaymentmethod("Cybersource Secure Acceptance");
        //      CheckoutPage.UseThisPaymentMethod();
        //      CheckoutPage.AcceptTermsandCondition();
        //      CheckoutPage.PlaceOrder();
        //      Assert.IsTrue(Driver.checkTitle("Payment Methods"));
        //      PaymentMethodspage.Cybersoursepayment.Card.SelectCard("AMEX");
        //      Assert.IsTrue(CheckoutPage.Cybersoursepayment.PaymentDetails.isAmexisSelected());
        //      CheckoutPage.Cybersoursepayment.PaymentDetails.EnterCarddetails();
        //      CheckoutPage.Cybersoursepayment.PaymentDetails.clickPay();

        //      Assert.IsTrue(OrderReceiptPage.paymentsccessmessage("Thank you for your order! Your order has been successfully processed. You will receive an email confirmation shortly."));
        //      Assert.IsTrue(OrderReceiptPage.isOrdernumberdisplay());
        //      OrderReceiptPage.ViewOrder();
        //      _test.Log(Status.Pass, "Click View Order");
        //      OrderPage.ClickOrderedItemViewDetails(generalcoursetitle + "_TC23724");
        //      _test.Log(Status.Pass, "Click View Details for Purchased Content");
        //      Assert.IsTrue(OrderDetailsPage.VerifyPurchasedContent(generalcoursetitle + "_TC23724"));
        //      _test.Log(Status.Pass, "verify Puschased Content");
        //      OrderDetailsPage.ItemDetails.ClickContentTitle();
        //      Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(generalcoursetitle + "_TC23724"));
        //      Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
        //      _test.Log(Status.Pass, "verify start button display after content Puschased");
        //      Assert.IsTrue(ContentDetailsPage.OverviewTab.AddtoCartportlet.isViewOrderlinkdisplay());
        //      _test.Log(Status.Pass, "verify View Order link display in Add to Cart portlet");
        //  }

    }
}
