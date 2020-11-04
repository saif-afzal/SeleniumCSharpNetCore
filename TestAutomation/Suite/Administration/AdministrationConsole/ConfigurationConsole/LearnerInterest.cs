using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;
using System.Threading;


namespace TestAutomation.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class LearnerInterest : TestBase
    {
        string browserstr = string.Empty;
        public LearnerInterest(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            //  driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://prdct-mg-17-2.mksi-lms.net/");

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test, Order(1)]
        public void To_test_console_settings_of_Learner_Interest_Settings_15692()
        {

            Assert.Fail();

        }
        [Test, Order(2)]
        public void To_test_the_update_of_threshold_value_for_Classroom_courses_15693()
        {

            Assert.Fail();
        }
        [Test, Order(3)]
        public void TO_test_the_customization_of_Learner_interest_fields_from_Learner_Interset_Settings_page_15695()
        {


            Assert.Fail();
        }
        [Test, Order(4)]
        public void TO_test_the_Learner_Reasons_page_in_Administration_Console_page_15740()
        {
            Assert.Fail();
        }
        [Test, Order(5)]
        public void To_test_that_administrator_can_create_and_manage_the_list_of_reasons_why_someone_is_requesting_a_training_activity_15867()
        {
            Assert.Fail();
        }
        [Test, Order(6)]
        public void To_test_that_admin_can_override_default_threshold_with_a_classroom_specific_course_15868()
        {
            Assert.Fail();
        }
        [Test, Order(7)]
        public void Enable_learner_Interest_24904()
        {
            Assert.Fail();
        }
     


        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
    }
}
