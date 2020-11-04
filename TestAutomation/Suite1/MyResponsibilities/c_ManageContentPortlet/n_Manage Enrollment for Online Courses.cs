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
    [TestFixture("firefoxbrowserstack")]
    [TestFixture("Chromebrowserstack")]
    [TestFixture("IE11browserstack")]
    [Parallelizable(ParallelScope.Fixtures)]
    class n_manageenrollmentonlinecoursesold : TestBase
    {
        public n_manageenrollmentonlinecoursesold(string browser)
            : base(browser)
        {

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
          //  objLogin = new Login();
            objTrainingHome = new TrainingHomes(driver);
            objTraining = new Training(driver);
            objContentSearch = new ContentSearch(driver);
            objCreate = new Create(driver);
            objContent = new Content(driver);
            objAddContent = new AddContent(driver);
        }

        [SetUp]
        public void SetUp()
        {
         
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
       
        //    objLogin.Login_click(driver); 
        }

        [Test]
        //Creating a Subscription
        public void A_Batch_enroll_a_useroruser_group_into_an_online_course()
        {         
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "ML.BASE.SUBSCRIPTION");
            objCreate.FillSubscriptionPage();

            //String Assertion on new Subscription creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            objContent.ContentSearch_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle);

            //Assertion for bundle displayed on search
         //   Assert.IsTrue(objContentSearch.ViewInList());
        }

        [Test]
        public void B_Cancel_enrollment_for_a_user_in_an_online_course()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle);
            // Subscription displayed on simple search
         //   Assert.IsTrue(objContentSearch.ViewInList());

            objContentSearch.AdvanceSearch( Variables.subscriptionTitle, "ML.BASE.SUBSCRIPTION");
            // Subscription displayed on advance search
           // Assert.IsTrue(objContentSearch.ViewInList());
        }



        [TearDown]
        public void TearDown()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            Console.WriteLine("TearDown");
            driver.Quit();
        }
    }       
}
