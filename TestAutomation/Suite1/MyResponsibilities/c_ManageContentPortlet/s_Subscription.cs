using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class s_TC_Subscriptionold : TestBase
    {
        string browserstr = string.Empty;
        public s_TC_Subscriptionold(string browser)
            : base(browser)
        {
            browserstr = browser;
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            // objLogin = new Login();
            InitializeBase(driver);
            Driver.Instance = driver;
            objTrainingHome = new TrainingHomes(driver);
            objTraining = new Training(driver);
            objContentSearch = new ContentSearch(driver);
            objCreate = new Create(driver);
            objContent = new Content(driver);
            objAddContent = new AddContent(driver);
            driver.UserLogin("admin1", browserstr);
        }
        public Training objTraining;
        public Login objLogin;
        public TrainingHomes objTrainingHome;
        public ContentSearch objContentSearch;
        public Create objCreate;
        public Content objContent;
        public AddContent objAddContent;

    

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);

        }

        [Test]
        //Creating a Subscription
        public void A_CreateANewSubscription()
        {         
            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Subscription_CourseClick);
            objCreate.FillSubscriptionPage(browserstr);

            //String Assertion on new Subscription creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            //objContent.ContentSearch_Click();
            //objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);

            //Assertion for bundle displayed on search
            //Assert.IsTrue(objContentSearch.ViewInList(Variables.subscriptionTitle + browserstr));
        }

      //  [Test]
        public void B_SimpleAndAdvanceSearchForSubscription()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);
            // Subscription displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.subscriptionTitle + browserstr));

            objContentSearch.AdvanceSearch( Variables.subscriptionTitle+browserstr, "ML.BASE.SUBSCRIPTION");
            // Subscription displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.subscriptionTitle + browserstr));
        }

    /*    [Test]
        public void C_ManageASubscription()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle);
            objContentSearch.Content_Click();
            objContent.Edit_Click(driver);
            //String assertion on updating Subscription
            String successMsg = objContent.SuccessMsgDisplayed(driver);
            StringAssert.Contains("The changes were saved.", successMsg);
        }
        */
        [Test]
        public void D_AddContentToTheSubscription()
        {
            // PreRequisite - Create Classroom Course
            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            objCreate.FillClassroomCoursePage("", browserstr);

            objTrainingHome.MyResponsiblities_click();
            //  objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.Edit_Content();
            objAddContent.SearchAndAddContent(browserstr);
            //String assertion on adding training activities
            String successMsg = objAddContent.SuccessMsg();
            StringAssert.Contains("The selected items were added. Note: If inactive items were added, users will not be able to access them.", successMsg);
        }

        [Test]
        public void E_CopyASubscription()
        {
            objTrainingHome.MyResponsiblities_click();
       //     objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.Copy_Click();

            //String assertion on Copy of the Subscription
            String successMsg = objContent.SuccessMsgDisplayed();          
            StringAssert.Contains("The item was copied.", successMsg);
        }

        [Test]
        public void F_DeleteASubscription()
        {
            Document documentpage = new Document(driver);
            objTrainingHome.MyResponsiblities_click();
        //    objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);
            objContentSearch.Content_Click();
            string actualresult = documentpage.buttondeletesectionclick();
            Assert.IsTrue(driver.comparePartialString("Success", driver.getSuccessMessage()));
        }

        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

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
    }       
}
