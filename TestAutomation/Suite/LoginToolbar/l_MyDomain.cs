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
   // [TestFixture("firefoxbrowserstack")]
    //[TestFixture("Chromebrowserstack")]
    //[TestFixture("IE11browserstack")]
   // [Parallelizable(ParallelScope.Fixtures)]
    class l_MyDomain : Selenium2TestBase
    {
        public static IWebDriver driverobj;
        static Domainutil Domainutilobj;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Common.closeie();
            //ExtractDataExcel.fillalldic();
            driverobj = StartBrowser();
            driverobj.Manage().Window.Maximize();
            driverobj.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            Domainutilobj = new Domainutil(driverobj);
          
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        }
      //  [Test]
        public static void a_Change_to_another_domain()
        {
            driverobj.UserLogin("admin1");
            Assert.IsTrue(Domainutilobj.Changetoanotherdomain());
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driverobj.Quit();
        }


    }
}
