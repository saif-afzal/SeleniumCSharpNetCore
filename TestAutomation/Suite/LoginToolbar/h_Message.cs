using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;

namespace Selenium2.Meridian.Suite.LoginToolbar
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class h_Message: TestBase
    {

        string browserstr = string.Empty;
        public h_Message(string browser)
            : base(browser)
        {
            browserstr = browser+"message";
}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);

       

        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test]
        public  void a_Click_the_Messages_icon()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
         //   TrainingHomeobj.lnk_TrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
            ApprovalPathobj.Click_CreateNewGoTo();
            ApprovalPathobj.Click_Create("admin", browserstr);
            Assert.IsTrue(ApprovalPathobj.Click_AddApproval());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            MessageUtilobj.CreateGeneralCourseforApproval(1, browserstr);
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickPreferencesTab();
            MessageUtilobj.setprofiletorecivemsg();
            MessageUtilobj.sendforapproval(browserstr);
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.lnk_MyMessageClick();
            Assert.IsTrue(TrainingHomeobj.checkmsgicon());
        }
        [Test]
        public  void b_Click_on_an_unopened_message()
        {
            //driver.UserLogin("testuser","userreg_0903352135","password");
            TrainingHomeobj.lnk_MyMessageClick();
            Assert.IsTrue(TrainingHomeobj.openmsg());
        }
        [Test]
        public  void d_Mark_a_message_as_read()
        {
            Assert.IsTrue(MyMessageobj.markmsgasread());
        }
        [Test]
        public  void c_Mark_a_message_as_unread()
        {
            Assert.IsTrue(MyMessageobj.markmsgasunread());
        }
        [Test]
        public  void e_Delete_a_message()
        {
            Assert.IsTrue(MyMessageobj.deletemsg());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
