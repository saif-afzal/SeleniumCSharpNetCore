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
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class SultanTest : TestBase
    {
        string browserstr = string.Empty;
        public SultanTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

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
        [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }

        [Test]
        public void Curriculum_Share_Link_via_SocialMedia_35710()
        {
            //Lets turn on default sharing for Facebook Only and validate it displays as an option for Sharing 
            CommonSection.Administer.System.SocialSharing.SocialSharing();
            CommonSection.SearchCatalog("AutoCurriculum");
            _test.Log(Status.Info, "Search for AutoCurriculum");
            SearchResultsPage.ClickCourseTitle("AutoCurriculum");
            _test.Log(Status.Info, "Access Content Details Page");
            Assert.IsTrue(SocialSharingDropDown("Facebook"));
            _test.Log(Status.Info, "Social Sharing button displays");

        }
        [Test]
        public void Curriculum_User_views_Reviews_and_Ratings_35712()
        {
            CommonSection.SearchCatalog("Review Curriculum Course");
            _test.Log(Status.Info, "Search for Review Curriculum Course");
            SearchResultsPage.ClickCourseTitle("Review Curriculum Course");
            //Cancel Enrollment if user is already enrolled
            if (Driver.existsElement(By.XPath("//a[contains(.,'Cancel Enrollment')]")))
            {
                Driver.clickEleJs(By.XPath("//a[@aria-controls='reviewsTab']"));
                Thread.Sleep(2000);
                _test.Log(Status.Info, "Checking to see if existing Review by current user is listed");
                if (Driver.existsElement(By.XPath("//span[@class='fa fa-close']")))
                {
                    _test.Log(Status.Info, "Existing review found...Deleting");
                    ContentDetailsPage.CurriculumEnrollment.deleteCurriculumReview();
                }
                ContentDetailsPage.CurriculumEnrollment.cancelCurriculumEnrollment();
            }
            _test.Log(Status.Info, "enroll in course");
            ContentDetailsPage.CurriculumEnrollment.enrollCurriculum();
            _test.Log(Status.Info, "Check Reviews Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumEnrollment.reviewsTab());
            _test.Log(Status.Info, "Write Curriculum review");
            ContentDetailsPage.CurriculumEnrollment.writeCurriculumReview();
            Assert.IsTrue(ContentDetailsPage.CurriculumEnrollment.verifyReviewText("For A test Review this class was great"));
            _test.Log(Status.Info, "Edit Review");
            ContentDetailsPage.CurriculumEnrollment.editCurriculumReview();
            Assert.IsTrue(ContentDetailsPage.CurriculumEnrollment.verifyReviewText("Made A small change"));
            _test.Log(Status.Info, "Delete review");
            ContentDetailsPage.CurriculumEnrollment.deleteCurriculumReview();
            _test.Log(Status.Info, "Cancel Enrollment");
            ContentDetailsPage.CurriculumEnrollment.cancelCurriculumEnrollment();
        }
        [Test, Order(1)]
        public void Curriculum_Enroll_24948()
        {
            CommonSection.SearchCatalog("Review Curriculum Course");
            _test.Log(Status.Info, "Search for Review Curriculum Course");
            SearchResultsPage.ClickCourseTitle("Review Curriculum Course");
            _test.Log(Status.Info, "enroll in course");
            ContentDetailsPage.CurriculumEnrollment.enrollCurriculum();
            Assert.IsTrue(ContentDetailsPage.CurriculumEnrollment.verifyCurriculumAlertMessage());
        }

        [Test, Order(2)]
        public void Curriculum_Cancel_Enrollment_26340()
        {
            _test.Log(Status.Info, "Cancel Enrollment");
            ContentDetailsPage.CurriculumEnrollment.cancelCurriculumEnrollment();
            Assert.IsTrue(ContentDetailsPage.CurriculumEnrollment.verifyCurriculumAlertMessage());
        }

        [Test]
        public void Curriculum_View_History_Progress_35713()
        {
            //Tests the User has Alreday enrolled and compoleted
            //in the future story, create a curriculum and progress through the course
            CommonSection.SearchCatalog("Review Curriculum");
            _test.Log(Status.Info, "Search for Review Curriculum");
            SearchResultsPage.ClickCourseTitle("Review Curriculum");
            _test.Log(Status.Info, "Check History Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumEnrollment.historyTab());
        }






        ///Add to ContentDetailsPage.cs
        ///
        public static bool SocialSharingDropDown(string socialSite)
        {
                if (Driver.existsElement(By.XPath("//button[contains(.,'Share')]")))
                {
                    Driver.clickEleJs(By.XPath("//button[contains(.,'Share')]"));
                    Driver.existsElement(By.XPath("//a[contains(.," + socialSite + ")]"));
                    return Driver.existsElement(By.XPath("//button[contains(.,'Share')]"));
                }
                else return false;
            }

        public class CurriculumEnrollment
        {
            public static void cancelCurriculumEnrollment()
            {
                Driver.clickEleJs(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
            }

            public static void enrollCurriculum()
            {
                Driver.clickEleJs(By.XPath("//a[contains(.,'Enroll')]"));
            }
            public static bool reviewsTab()
            {
                Driver.clickEleJs(By.XPath("//a[@aria-controls='reviewsTab']"));
                return Driver.existsElement(By.XPath("//a[contains(.,'Write a review')]"));
            }
            public static bool historyTab()
            {
                Driver.clickEleJs(By.XPath("//a[contains(.,'History')]"));
                Driver.existsElement(By.XPath("//li[@class='complete']"));
                Driver.existsElement(By.XPath("//li[contains(.,'Started curriculum')]"));
                Driver.existsElement(By.XPath("//li[contains(.,'Enrolled in curriculum')]"));
                return true;
            }
            public static void writeCurriculumReview()
            {
                Driver.clickEleJs(By.XPath("//a[contains(.,'Write a review')]"));
                Driver.Instance.SelectCurrentFrame();
                Driver.clickEleJs(By.XPath("//select[contains(@id,'RATING')]"));
                Driver.clickEleJs(By.XPath("//option[@value='4']"));
                Driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("Test Review");
                Driver.GetElement(By.XPath("//textarea[contains(@id,'REVIEW')]")).SendKeysWithSpace("For A test Review this class was great");
                Driver.clickEleJs(By.XPath("//input[@value='Save']"));
            }
            public static bool verifyReviewText(string reviewText)
            {
                return Driver.existsElement(By.XPath("//p[contains(.,'" + reviewText + "')]"));
            }
            public static void editCurriculumReview()
            {
                Driver.clickEleJs(By.XPath("//a[contains(.,'Edit review')]"));
                Driver.Instance.SelectCurrentFrame();
                Driver.clickEleJs(By.XPath("//select[contains(@id,'RATING')]"));
                Driver.clickEleJs(By.XPath("//option[@value='2']"));
                Driver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("Edit Review");
                Driver.GetElement(By.XPath("//textarea[contains(@id,'REVIEW')]")).SendKeysWithSpace("Made A small change");
                Driver.clickEleJs(By.XPath("//input[@value='Save']"));
            }
            public static void deleteCurriculumReview()
            {
                Driver.clickEleJs(By.XPath("//a[@aria-controls='reviewsTab']"));
                Driver.clickEleJs(By.XPath("//span[@class='fa fa-close']"));
                Driver.Instance.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            }
            public static bool verifyCurriculumAlertMessage()
            {
                Thread.Sleep(1000);
                return Driver.existsElement(By.XPath("//div[@class='alert alert-success']"));

            }
        }


    }




    ///Add to commonSection.cs
    public class SocialNetworkSharingCommand
    {
            public void SocialSharing()
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            Driver.clickEleJs(By.XPath("//a[@href='#administer_system']"));
            Driver.clickEleJs(By.XPath(".//*[@id='administer_branding_customization_Header']/h3/a"));
            Driver.clickEleJs(By.XPath("//a[@href='#administer_social_networking']"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'Facebook')]"));
            Thread.Sleep(3000);
            Driver.clickEleJs(By.XPath("//label[contains(.,'True')]"));
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }


    }



}

//add to IWebdriver.cs/// But if you have another function to switch frames,  use it.****************
/**public static void SelectCurrentFrame(this IWebDriver driver)
{
    int j = 0;
    Exception finalex = null;
    IList<IWebElement> iframes = driver.FindElements(By.TagName("iframe"));
    int noofframes = iframes.Count - 1;
    if (iframes.Count == 1)
    {
        noofframes = 0;
    }
    try
    {
        Thread.Sleep(3000);
        driver.SwitchTo().Frame(noofframes);
        finalex = null;
    }
    catch (Exception ex)
    {
        finalex = ex;
        Console.WriteLine("Exception was raised on locating element: " + ex.Message);
        driver.SwitchTo().DefaultContent();

    }

    if (finalex is NoSuchFrameException)
    {
        throw new NoSuchFrameException(j.ToString());
    }
    if (finalex is NoSuchElementException)
    {
        throw new NoSuchElementException(j.ToString());
    }

}

    */