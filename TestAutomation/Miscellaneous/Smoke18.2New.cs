using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Diagnostics;
using System.Linq;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{

    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class FullSmokeTest : TestBase
    {
        string browserstr = string.Empty;
        public FullSmokeTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
        }
        string CareerPathTitle = "CareerPathTitle" + Driver.generateRandom(1, 100);
        string CompetencyTitle = "CompetencyTitle" + Driver.generateRandom(1, 100);
        string JobTitle = "JobTitle" + Driver.generateRandom(1, 100);

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

        [Test, Category("Smoke"), Order(1)]
        public void LoginSmoke()
        {
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            Assert.IsTrue(HomePage.Title == "Home");//checks the Home page title
        }




        public bool sectioncreation = false;
        bool test2 = false;
        public bool chktest = false;





        [Test]
        public void s01_Create_New_Account()
        {

            AccountCreation CreateAccount = new AccountCreation(driver);
            ClassroomCourse classroom = new ClassroomCourse(driver);
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            CreateNewAccountobj.Click_SelectOrganization();
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            chktest = ManageUsersobj.Click_SearchUser();
            Assert.IsTrue(Driver.Instance.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"], ManageUsersobj.passwordcreationnewuser(),browserstr));
            CommonSection.Avatar.Logout();


        }




        [Test]
        public void s02_Create_A_Document()
        {

            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent("Document");
            Createobj.FillDocumentPage("smoke");
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            CommonSection.Avatar.Logout();

        }

        [Test]
        public void s03_Create_A_General_Course()
        {

            GeneralCourse generalcourse = new GeneralCourse(driver);
            Driver.Instance.UserLogin("admin1",browserstr);
            // driver.openadminconsolepage();

            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            generalcourse.buttoncoursecreationgoclick("General Course");
            generalcourse.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_genralcourse["Title"], ExtractDataExcel.MasterDic_genralcourse["Desc"], 9);
            generalcourse.populateCourseFilesform(driver);
            Assert.IsTrue(generalcourse.buttoncreateclick(driver));

            CommonSection.Avatar.Logout();


        }

        [Test]
        public void s04_Create_A_SCORM_Course()

        {
            Document documentpage = new Document(driver);
            driver.UserLogin("admin",browserstr);
            string expectedresult = "Edit Summary";
            string expectedresult1 = "The course was created.";
            //driver.openadminconsolepage();
            Scorm12 CreateScorm = new Scorm12(driver);
            CreateScorm.linkmyresponsibilitiesclick();
            documentpage.tabcontentmanagementclick();
            documentpage.buttoncoursecreationgoclick("SCORM");
            //CreateScorm.linkscromcourseclick();

            //CreateScorm.buttongoclick();
            //    CreateScorm.navigatescorm12file(driver);
            driver.navigateAICCfile("\\Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            StringAssert.AreEqualIgnoringCase(expectedresult, text);
            driver.WaitForElement(ObjectRepository.sucessmessage);
            StringAssert.AreEqualIgnoringCase(expectedresult1, driver.gettextofelement(ObjectRepository.sucessmessage));
            CreateScorm.populatesummaryform(driver);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
            //   driver.Checkin();

            //     CommonSection.Avatar.Logout();



        }

        [Test]
        public void s05_Assign_Required_Training_To_SCORM_Course()
        {
            Scorm12 AssignScorm = new Scorm12(driver);
            driver.openadminconsolepage();
            AssignScorm.linkrequiredtrainingconsoleclick(driver);
            AssignScorm.populatesearchscorm(driver);
            AssignScorm.buttonsearchclick();
            AssignScorm.buttonrequiredtraining();
            AssignScorm.buttongotrainingclick();
            AssignScorm.populateassignuserform();
            Assert.IsTrue(AssignScorm.buttonassigntrainingclick());
            CommonSection.Avatar.Logout();

        }

        [Test]
        public void s06_Create_A_Classroom_Course()
        {


            //   ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "The item was created.";
            driver.UserLogin("admin",browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            //    classroomcourse.linkclassroomcourseclick();
            classroomcourse.linkclassroomcourseclick1("Classroom Course");
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"], ExtractDataExcel.MasterDic_classrommcourse["Desc"], 9);
            StringAssert.AreEqualIgnoringCase(expectedresult, classroomcourse.buttonsaveclick());
            //    CommonSection.Avatar.Logout();

        }

        [Test]
        public void s07_Create_A_Section_For_Classroom_Course()
        {
            //    ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "The course section was created with the first event.";
            //    Assert.IsTrue(driver.UserLogin("admin"));
            //classroomcourse.linkmyresponsibilitiesclick(driver);
            //classroomcourse.linkclassroomcourseclick();
            //classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 9, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1();
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, classroomcourse.buttonsaveandexitclick());
            sectioncreation = true;
            //    CommonSection.Avatar.Logout();

        }

        [Test]
        public void s08_Batch_Enroll_A_User_Into_A_Classroom_Section()
        {
            //    ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "The selected users were enrolled in the section.";
            classroomcourse.buttonmanageenrollmentclick();
            classroomcourse.buttonenrollusersclick();
            classroomcourse.populatebatchenrollusersform(ExtractDataExcel.MasterDic_admin1["Firstname"], ExtractDataExcel.MasterDic_admin1["Lastname"]);
            classroomcourse.buttonbatchenrolluserssearchclick();
            classroomcourse.buttonuserselectcheckboxclick();
            string actulresult = classroomcourse.buttonbatchenrollusersclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actulresult);

            CommonSection.Avatar.Logout();
        }

        [Test]

        public void s09_Create_A_New_Curriculum()
        {
            // ContentSearch contentsearchObj = new ContentSearch();
            // string expectedresult = "The item was created.";
            //driver.UserLogin("admin");
            //classroomcourse.linkmyresponsibilitiesclick(driver);
            //objTraining.SearchContent_Click();
            //ContentSearchobj.NewContent("Curriculums");
            //Createobj.FillCurriculumPage("");
            //String successMsg = Contentobj.SuccessMsgDisplayed();
            //StringAssert.Contains("The item was created.", successMsg);

            //Contentobj.ContentSearch_Click();
            //ContentSearchobj.Simple_Search(Variables.curriculumTitle);

            ////Assertion for curriculum displayed on search
            //Assert.IsTrue(ContentSearchobj.ViewInList());
            //  CommonSection.Avatar.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent("Curriculums");//please check text in dropdown its value changes
            Createobj.FillCurriculumPage();
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_TrainingActivityCurriBlock1();
            AddContentobj.SearchAndAddCurriculamContent();//ExtractDataExcel.MasterDic_genralcourse["Title"] + "smoke"
            Assert.IsTrue(AddContentobj.Click_Return());

            Assert.IsTrue(Contentobj.Click_CheckIn());
            CommonSection.Avatar.Logout();

        }

        [Test]
        public void s10_Create_A_New_Product()
        {
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();

            Assert.IsTrue(ProductUtilobj.CreateProduct(1, "admin1"));

        }

        [Test]
        public void s11_Search_For_The_Created_Document_And_Access_The_Details_Page()
        {
            driver.UserLogin("user",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_document["Title"]);
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(ExtractDataExcel.MasterDic_document["Title"]));
        }

        [Test]
        public void s12_Launch_The_Document()
        {
            Assert.IsTrue(Detailsobj.Click_OpenDocumet());
        }

        [Test]
        public void s13_Mark_The_Document_Complete()
        {
            Assert.IsTrue(Detailsobj.Click_MarkCompleteDocument());
            //Assert.IsTrue(Detailsobj.Click_ViewDetailDocumentCompleted());
            CommonSection.Avatar.Logout();
        }

        [Test]
        public void s14_Search_General_Course_And_Access_The_Details_Page()
        {
            driver.UserLogin("user",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"]);
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(ExtractDataExcel.MasterDic_genralcourse["Title"]));

        }

        [Test]
        public void s15_Enroll_In_The_General_Course()
        {

            Assert.IsTrue(Detailsobj.Click_EnrollGeneralCourse());
        }
        [Test]
        public void s16_Launch_The_General_Course()
        {


            Assert.IsTrue(Detailsobj.Click_OpenGeneralCourse());
        }
        [Test]
        public void s17_Mark_The_General_Course_Complete()
        {


            Assert.IsTrue(Detailsobj.Click_MarkCompleteGeneralCourse());
            Assert.IsTrue(Detailsobj.Click_ViewDetailGeneralCourseCompleted());
            CommonSection.Avatar.Logout();
        }

        [Test]
        public void s18_Search_SCORM_Course_And_Access_The_Details_Page()
        {
            driver.UserLogin("user",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_MyOwnLearning();
            string expectedresult = "Search Results";
            string actualresult = driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_scrom["Title"], "Exact phrase");
            StringAssert.Contains(expectedresult, actualresult);
            Assert.IsTrue(Driver.Instance.clicktableresult(""));
        }

        [Test]
        public void s19_Enroll_In_The_SCORM_Course()
        {
            string expectedresult = "Open Item";
            string actualresult = Detailsobj.enrollscormcourse();
            StringAssert.Contains(expectedresult, actualresult);

        }

        [Test]
        public void s20_Launch_The_SCORM_Course()
        {

            string _expectedresult = "Resume";
            Scorm12 Scorm = new Scorm12(driver);
            StringAssert.AreEqualIgnoringCase(Scorm.buttonopenscormclick(driver), _expectedresult);
            CommonSection.Avatar.Logout();

        }

        [Test]
        public void s21_Search_Classroom_Course_And_Access_The_Details_Page()
        {
            driver.UserLogin("user",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_classrommcourse["Title"]);
            // TrainingHomeobj.Click_Search(Variables.classroomCourseTitle);
            SearchResultsobj.Content_Click();
            // Assert.IsTrue(Detailsobj.Check_ContentHeading(Variables.classroomCourseTitle));
            Assert.IsTrue(Detailsobj.Check_ContentHeading(ExtractDataExcel.MasterDic_classrommcourse["Title"]));
        }


        [Test]
        public void s22_EnrolClassroomCourse()
        {
            Assert.IsTrue(Detailsobj.EnrollClassroomCourse(driver));
            CommonSection.Avatar.Logout();
        }

        [Test]
        public void s23_Search_Curriculam_And_Access_The_Details_Page()
        {
            driver.UserLogin("user",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_Search(Variables.curriculumTitle);
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(Variables.curriculumTitle));
        }

        [Test]
        public void s24_Enroll_In_The_Curriculam()
        {

            Assert.IsTrue(Detailsobj.Click_EnrollCurriculam());
        }
        [Test]
        public void s25_Access_The_Curriculam()
        {
            Assert.IsTrue(Detailsobj.Click_AccessCurriculam());
            CommonSection.Avatar.Logout();
        }

        [Test]
        public void s26_TranscriptDocument()
        {
            driver.UserLogin("user",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_document["Title"]));
        }
        [Test]
        public void s27_TranscriptGeneralCourse()
        {
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"]));
        }
        [Test]
        public void s28_TranscriptScorm()
        {
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_scrom["Title"]));
        }
        [Test]
        public void s29_TranscriptClassroomCourse()
        {
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(Variables.classroomCourseTitle));
            CommonSection.Avatar.Logout();
        }

        [Test]
        public void s30_Search_for_the_product_created_above_in_Training_Catalog_and_access_the_details_page()
        {

            driver.UserLogin("user",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_product["Title"]);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.Check_ContentHeading(ExtractDataExcel.MasterDic_product["Title"]));
            Assert.IsTrue(Detailsobj.Check_AddToCart());
        }

        [Test]
        public void s31_Add_the_product_to_the_shopping_cart_and_complete_the_purchase()
        {


            Detailsobj.Click_AddToCart();
            ShoppingCartsobj.Click_ShoppingCartLink(ExtractDataExcel.MasterDic_product["Title"]);
            //   ShoppingCartsobj.SetBillingAddress();
            ShoppingCartsobj.Click_CheckOut();
            ShoppingCartsobj.Populate_ShippingAddress();
            ShoppingCartsobj.Click_CountinueToPayment();
            ShoppingCartsobj.Click_Next();
            ShoppingCartsobj.Click_TermsAndConditions();
            Assert.IsTrue(ShoppingCartsobj.Click_BuyNow());
            CommonSection.Avatar.Logout();

        }


        [Test, Category("Smoke"), Order(2)]
        public void Help()
        {
            CommonSection.ClickHelpIcon();
            Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
        }
        [Test, Category("Smoke"), Order(3)]
        public void Search()
        {

            CommonSection.CatalogSearchText("Test");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Test") >= 1);//chcks the records are not zero
            CommonSection.Manage.People();
            ManageUsersPage.SearchUser("");
            Assert.IsTrue(ManageUsersPage.DisplaysUserlist >= 1);//checks people search is working
        }
        [Test, Category("Smoke"), Order(4)]
        public void Administration()
        {
            CommonSection.Administer.People.Organizations();
            OrganizationsPage.ClickSearch();
            Assert.IsTrue(OrganizationsPage.DisplaySearchRecords > 1);//checks Organization search is working
            CommonSection.Manage.Careerstab();
            // CommonSection.Administer.People.JobTitles();not avaialable in 18.1
            CareersPage.JobTitleKI.SearchJobtitle("");
            Assert.IsTrue(CareersPage.JobTitleKI.DisplaySearchRecords >= 1);
            //   JobTitlesPage.SearchJobtitle("");not avaialable in 18.1
            //  Assert.IsTrue(JobTitlesPage.DisplaySearchRecords > 1);//checks Jobtitle search is working

            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            Assert.IsTrue(HomePage.Title == "Home");// just checks the title
        }
        [Test, Category("Smoke"), Order(5)]
        public void Reports()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("My");
            Assert.IsTrue(ReportsConsolePage.DisplayResult > 1);//checks results display more than 1
            ReportsConsolePage.ClickMyTrainingProgress();
            DetailsPage.ClickSelect();
            RunReportPage.ClickRunReport();
            // Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            MeridianGlobalReportingPage.ClickDetails();
            Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));//retrieves the text from details tab
            DetailsPage.ClickCloseWindowlink();
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));
            //   MyTrainingProgressPDFPage.ClickBrowsertabX();
            //   Assert.IsTrue(DetailsPage.Displays>1);
            MeridianGlobalReportingPage.CloseWindow();

            Assert.IsTrue(RunReportPage.Title == "Run Report");
            Assert.IsTrue(Driver.focusParentWindow());
            CommonSection.Avatar.Reports();
            ReportsPage.MyTrainingProgress.ClickRunReport();
            ReportsPage.ReportCriteriaModal.ClickRunReport();
            MeridianGlobalReportingPage.ClickDetails();
            Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));
            DetailsPage.ClickCloseWindowlink();
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));

            MeridianGlobalReportingPage.CloseWindow();
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Reports");

        }
        [Test, Category("Smoke"), Order(6)]
        public void Upload_Launch_Course()
        {
            CommonSection.CreateLink.SCORM();
            CreatePage.ClickBrowsebutton();
            //  //  CreatePage.UploadScormfile("\\fileserver\\maindrive\\product_team\\SCORM\\SCORM_1_2\\maritime_navigation_exam_only.zip");
            //  CreatePage.ClickCreatebutton();
            Assert.IsTrue(SummaryPage.Title == "Summary");
            StringAssert.AreEqualIgnoringCase("The course was created.", SummaryPage.GetSuccessMessage(), "Error message is different");
            SummaryPage.UpdateTitle("Maritime Navigation - Exam only for Migration Test");
            //   SummaryPage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", AdminContentDetailsPage.GetSuccessMessage(), "Error message is different");
            AdminContentDetailsPage.ClickCheckInbutton();
            CommonSection.CatalogSearchText("Migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Migration Test") >= 1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitle("Maritime Navigation - Exam only for Migration Test"));
            AdminContentDetailsPage.ClickOpenItembutton();
            Assert.IsTrue(CourseLaunchModalPage.Exist("Maritime Navigation - Exam only for Migration Test"));
            // CourseLaunchModalPage.ClickBrowserX();
            Assert.IsTrue(AdminContentDetailsPage.CheckResumeButton());

            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Migration Test") >= 1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            AdminContentDetailsPage.Summary.ClickViewButton();//need towrite the code
            Assert.IsTrue(SummaryPage.Title == "Maritime Navigation - Exam only for Migration Test");//need towrite the code
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitleOnClickingEditButton("Maritime Navigation - Exam only for Migration Test"));
            AdminContentDetailsPage.DeleteContent();

            //  StringAssert.StartsWith("Success", ContentDetailsPage.GetRemovalSuccessMessage(), "Error message is different");
            CommonSection.SearchCatalog("Maritime Navigation - Exam only for Migration Test");
            Assert.IsTrue((SearchResultsPage.ReturnFirstRecordTitle() != "Maritime Navigation - Exam only for Migration Test"));
        }

        //  [Test, Category("Smoke"), Order(8)]
        public void Navigate_to_Public_Catalog()
        {
            Driver.Instance.Navigate().GoToUrl("https://prodsupport-ki-17-3.meridianksi.net/public/trainingcatalog.aspx");
            //EnterURL("baseqa-17-3-m-c1.meridianksi.net/public/trainingcatalog.aspx");
            Assert.IsTrue(CatalogPage.Title == "Public Catalog");
            CatalogPage.SearchContent();
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("") > 1);
            SearchResultsPage.ClickCourseTitle("");
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitle(""));

        }

        //  [Test, Category("Smoke"), Order(7)]

        public void Social()
        {
            CommonSection.Learn.Spaces();
            Assert.IsTrue(SpacesPage.CheckTitle == "Collaboration Spaces");
            SpacesPage.TypePublicSpace.ClickSpaceTitle();
            SpacesPage.SpaceTitlePage.ClickJoinButton();
            StringAssert.AreEqualIgnoringCase("You Joined the Collaboration Space", SpacesPage.GetSuccessMessage(), "Error message is different");
            SpacesPage.SpaceTitlePage.SelectAccessSpace();
            Assert.IsTrue(CSLaunchPage.Exist());

        }

        [Test, Category("Smoke"), Order(9)]
        public void Other()
        {
            CommonSection.SearchCatalog("");
            //CommonSection.Learn.Home();
            HomePage.ClickAboutLink();
            Assert.IsTrue(HomePage.ClickModalX());
            Assert.IsTrue(HomePage.Title == "Search Results");


            CommonSection.Administer.System.SystemAdministration.SystemCertificate("Certificates");
            Assert.IsTrue(SystemCertificatePage.Title == "System Certificate");
            SystemCertificatePage.Preview("Default");
            Assert.IsTrue(CertificatePage.VerifyFileDownload("\\Certificate.pdf"));
            Assert.IsTrue(SystemCertificatePage.Title == "System Certificate");
            // CommonSection.Avatar.Logout();
            // Assert.IsTrue(LoginPage.Title=="Login");
            //foreach (Process Proc in (from p in Process.GetProcesses()
            //                          where p.ProcessName == "chromedriver" ||p.ProcessName=="chrome"  
            //                          select p))
            //{
            //    // "Kill" the process
            //    Proc.Kill();
            //}



        }

    }
}

   

