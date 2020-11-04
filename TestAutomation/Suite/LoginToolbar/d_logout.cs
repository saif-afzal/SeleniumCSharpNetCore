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
   public class d_logout : TestBase
    {
        string browserstr = string.Empty;
        public d_logout(string browser)
            : base(browser)
        {
            browserstr = browser+"logout";
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

        public  void a_Click_the_Logout_link()
        {
             string _expectedresult = "Login";
             driver.UserLogin("admin", browserstr);
            string _actualresultadmin = UsersUtilobj.LogoutUser();
            StringAssert.AreEqualIgnoringCase(_actualresultadmin, _expectedresult);

            driver.UserLogin("userforregression", browserstr);
            string _actualresult = UsersUtilobj.LogoutUser();
            StringAssert.AreEqualIgnoringCase(_actualresult, _expectedresult);

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
