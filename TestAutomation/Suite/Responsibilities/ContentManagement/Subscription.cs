using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class s_TC_Subscription : TestBase
    {
        string browserstr = string.Empty;
        public s_TC_Subscription(string browser)
            : base(browser)
        {
            browserstr = browser;
}
        public Training objTraining;
        public Login objLogin;
        public TrainingHomes objTrainingHome;
        public ContentSearch objContentSearch;
        public Create objCreate;
        public Content objContent;
        public AddContent objAddContent;

        [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {

            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
           // objLogin = new Login();
            objTrainingHome = new TrainingHomes(driver);
            objTraining = new Training(driver);
            objContentSearch = new ContentSearch(driver);
            objCreate = new Create(driver);
            objContent = new Content(driver);
            objAddContent = new AddContent(driver);
            driver.UserLogin("admin1", browserstr);
        }

        [SetUp]
        public void SetUp()
        {
        
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
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "Subscriptions");
            objCreate.FillSubscriptionPage(browserstr);

            //String Assertion on new Subscription creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            objContent.ContentSearch_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);

            //Assertion for bundle displayed on search
            Assert.IsTrue(objContentSearch.ViewInList());
        }

        [Test]
        public void B_SimpleAndAdvanceSearchForSubscription()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);
            // Subscription displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList());

            objContentSearch.AdvanceSearch( Variables.subscriptionTitle+browserstr, "ML.BASE.SUBSCRIPTION");
            // Subscription displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList());
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
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "Classroom Course");
            objCreate.FillClassroomCoursePage("", browserstr);

            objContent.MyResponsiblities_click();
            objTraining.SearchContent_Click();
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
            objTraining.SearchContent_Click();
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
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.DeleteContent_Click();
            //String assertion on deletion of Subscription
            String successMsg = objTraining.SuccessMsg_DeletingCertification();
            StringAssert.Contains("The selected items were deleted.", successMsg);
        }

        [TearDown]
        public void TearDown()
        {
           
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Console.WriteLine("TearDown");
            driver.Quit();
        }
    }       
}
