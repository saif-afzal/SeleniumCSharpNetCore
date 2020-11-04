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
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P4RegressionTests : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPath" + Meridian_Common.globalnum;


        public P4RegressionTests(string browser)
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
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
        string bundlecourse = "GeneralCourse" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        bool TC_10574 = false;
        bool TC_10823 = false;
        bool TC_10879 = false;
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }


        [Test, Order(7)]
        public void b7_Express_Interest_14261()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.SearchCatalog("");
            _test.Log(Status.Info, "Click Catalog Search Button");
            Assert.IsTrue(SearchResultsPage.isSearchResultListDisplayed(""));
            _test.Log(Status.Pass, "Verify Search list is Displayed");
            Assert.IsTrue(SearchResultsPage.isMakeAContentSuggestionDisplayed());
            _test.Log(Status.Pass, "Verify Make a content Suggestion is Displayed");
            SearchResultsPage.ClickMakeAContentSuggestion();
            _test.Log(Status.Info, "Click MAke A Content Suggestion Link");
            Assert.IsTrue(SearchResultsPage.isExpressInterestWindowDisplayed());
            _test.Log(Status.Pass, "Verify Express Interest Window is Displayed");
            Assert.IsTrue(ExpressInterest.isTopicOfInterestDisplayed());
            _test.Log(Status.Pass, "Verify Topic Of Interest is Displayed");
            Assert.IsTrue(ExpressInterest.isContentTypeDisplayed());
            _test.Log(Status.Pass, "Verify Content Type is Displayed");
            Assert.IsTrue(ExpressInterest.isReasonDisplayed());
            _test.Log(Status.Pass, "Verify Reason is Displayed");
            Assert.IsTrue(ExpressInterest.isISeekTrainingAfterDisplayed());
            _test.Log(Status.Pass, "Verify I Seek Training After is Displayed");
            Assert.IsTrue(ExpressInterest.isISeekTrainingBeforeDisplayed());
            _test.Log(Status.Pass, "Verify I Seek Training Before is Displayed");
            Assert.IsTrue(ExpressInterest.isIPreferToTrainDisplayed());
            _test.Log(Status.Pass, "Verify I Prefer To Train is Displayed");
            Assert.IsTrue(ExpressInterest.isLocationDisplayed());
            _test.Log(Status.Pass, "Verify Location is Displayed");
            Assert.IsTrue(ExpressInterest.isAdditionalInformationDisplayed());
            _test.Log(Status.Pass, "Verify Additional Information is Displayed");
            Assert.IsTrue(ExpressInterest.isCancelButtonDisplayed());
            _test.Log(Status.Pass, "Verify Cancel Button is Displayed");
            Assert.IsTrue(ExpressInterest.isSubmitButtonDisplayed());
            _test.Log(Status.Pass, "Verify Submit Button is Displayed");
            ExpressInterest.SubmitWith("Topic Of Interest", "Document", "Interested in a different topic", "1/8/2019",
                "2/22/2019", "Mornings", "India", "Training is good for EVERYBODY");
            _test.Log(Status.Info, "Fill Express interest Form and Submit It");
            Assert.IsTrue(Driver.comparePartialString("The item was submitted", Driver.getSuccessMessage()));//The item was submitted
            _test.Log(Status.Pass, "Verify Feedback is Displayed");
            Assert.IsTrue(SearchResultsPage.isSearchResultListDisplayed(""));
            _test.Log(Status.Pass, "Verify Search list is Displayed");
        }

        [Test, Order(8)]
        public void b8_Remove_interest_In_Classroom_Course_Interest_14262()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.SearchCatalog("");
            _test.Log(Status.Info, "Click Catalog Search Button");
            Assert.IsTrue(SearchResultsPage.isSearchResultListDisplayed(""));
            _test.Log(Status.Pass, "Verify Search list is Displayed");
            SearchResultsPage.ClickCourseTitle("");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "Verify Content Details Page is Displayed");
            Assert.IsTrue(ContentDetailsPage.isExpressInterestLinkDisplayed());
            _test.Log(Status.Pass, "verify Express Interest Link is Displayed");
            ContentDetailsPage.ClickExpressInterest();
            _test.Log(Status.Info, "Click Express Interest Link");
            Assert.IsTrue(ContentDetailsPage.isExpressInterestFrameDisplayed());
            _test.Log(Status.Info, "Verify Express Interest Frame is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isReasonDisplayed());
            _test.Log(Status.Pass, "Verify Reason is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isFormatDisplayed());
            _test.Log(Status.Pass, "Verify Format is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isISeekTrainingAfterDisplayed());
            _test.Log(Status.Pass, "Verify I Seek Training After is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isISeekTrainingBeforeDisplayed());
            _test.Log(Status.Pass, "Verify I Seek Training Before is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isIPreferToTrainDisplayed());
            _test.Log(Status.Pass, "Verify I Prefer To Train is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isLocationDisplayed());
            _test.Log(Status.Pass, "Verify Location is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isAdditionalInformationDisplayed());
            _test.Log(Status.Pass, "Verify Additional Information is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isCancelButtonDisplayed());
            _test.Log(Status.Pass, "Verify Cancel Button is Displayed");
            Assert.IsTrue(ContentDetailsPage.ExpressInterest.isSubmitButtonDisplayed());
            _test.Log(Status.Pass, "Verify Submit Button is Displayed");
            ContentDetailsPage.ExpressInterest.SubmitWith("Need a different location", "No Preference", "1/8/2019",
                "2/22/2019", "Mornings", "India", "Training is good for EVERYBODY");
            _test.Log(Status.Info, "Fill the Express Interest Form and submit It.");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "Verify Content Details Page is Displayed");
            Assert.IsTrue(Driver.comparePartialString("The item was submitted.", ContentDetailsPage.getSuccessMessage()));//The item was submitted
            _test.Log(Status.Pass, "Verify Feedback is Displayed");
            Assert.IsFalse(ContentDetailsPage.isExpressInterestLinkDisplayed());
            _test.Log(Status.Pass, "Verify Express Interest Link  NOT is Displayed");
            Assert.IsTrue(ContentDetailsPage.isCancelInterestDisplayed());
            _test.Log(Status.Pass, "Verify Cancel Interest Link is Displayed");
            ContentDetailsPage.ClickCancelInterest();//handle Popup
            _test.Log(Status.Info, "Click Cancel Interest Link to Cancel the Request");
            Assert.IsTrue(ContentDetailsPage.isExpressInterestLinkDisplayed());
            _test.Log(Status.Pass, "Verify Express Interest Link is Displayed");

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
