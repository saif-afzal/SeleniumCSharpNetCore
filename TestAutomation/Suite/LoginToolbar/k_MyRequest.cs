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
    public class k_MyRequest : TestBase
    {
        string browserstr = string.Empty;
        public k_MyRequest(string browser)
            : base(browser)
        {
            browserstr = browser;
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
       // [Test]
        public  void a_Click_the_All_Requests_link_from_the_portlet()
        {
            //driver.UserLogin("admin");
            //MyRequestobj.CreateApproval();
            //driver.UserLogin("admin");
            //MyRequestobj.CreateGeneralCourseforApproval(1);
            //driver.UserLogin("admin");
            //MyRequestobj.CreateGeneralCourseforApproval(2);
            //driver.UserLogin("userforregression",browserstr);
            //MyRequestobj.sendforapproval();
            //driver.UserLogin("admin");
            //MyRequestobj.Approveone();
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.Click_Requests();
            Assert.IsTrue(MyAccountobj.Click_AllMyRequest());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public  void b_Click_on_a_content_item()
        {

            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.Click_Requests();
           // Assert.IsTrue(MyAccountobj.Click_AllMyRequest());
            Assert.IsTrue(Detailsobj.Check_ContentHeading(MyRequestsobj.Click_FirstItem()));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            //// string _expectedresult = "Details";
            //Assert.IsTrue(MyRequestobj.showdetailpage(1));
            ////StringAssert.AreEqualIgnoringCase(_actualresult, _expectedresult);
            ////driver.UserLogin("admin");
            ////MyOwnLearningobj.DeleteGeneralCourse(2);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
            //  rs.OneTimeTearDown();
        }



    }
}
