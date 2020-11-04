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
    class m_manageenrollmentclassroomcourseold : TestBase
    {
        public m_manageenrollmentclassroomcourseold(string browser)
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
        
         //   objLogin.Login_click(driver); 
        }

        [Test]
        //Creating a Subscription
        public void Batch_enroll_a_user_and_user_group_into_a_classroom_course_section()
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
            //Assert.IsTrue(objContentSearch.ViewInList());
        }

        [Test]
        public void Batch_waitlist_a_user_into_a_classroom_course_section()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle);
            // Subscription displayed on simple search
          //  Assert.IsTrue(objContentSearch.ViewInList());

            objContentSearch.AdvanceSearch( Variables.subscriptionTitle, "ML.BASE.SUBSCRIPTION");
            // Subscription displayed on advance search
        //    Assert.IsTrue(objContentSearch.ViewInList());
        }

        [Test]
        public void Cancel_enrollment_for_a_user_in_a_classroom_course_section()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle);
            objContentSearch.Content_Click();
            objContent.Edit_Click();
            //String assertion on updating Subscription
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The changes were saved.", successMsg);
        }

        [Test]
        public void Cancel_waitlist_for_a_user_in_a_classroom_course_section()
        {
            // PreRequisite - Create Classroom Course
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.NewContent( "ML.BASE.COURSEWARE.CLASSROOM");
            objCreate.FillClassroomCoursePage("");

            objContent.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search( Variables.subscriptionTitle);
            objContentSearch.Content_Click();
            objContent.Edit_Content();
            objAddContent.SearchAndAddContent();
            //String assertion on adding training activities
            String successMsg = objAddContent.SuccessMsg();
            StringAssert.Contains("The selected items were added. Note: If inactive items were added, users will not be able to access them.", successMsg);
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
