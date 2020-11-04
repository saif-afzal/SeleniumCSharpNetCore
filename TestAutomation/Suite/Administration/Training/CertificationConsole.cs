using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;


namespace Selenium2.Meridian.Suite.Administration.Training
{
    [TestFixture]
    class CertificationConsole : Selenium2TestBase
    {

        public static IWebDriver driverobj;
        static CertificationUtils CertificationUtilobj;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Common.closeie();
            //ExtractDataExcel.fillalldic();
           // driverobj = StartBrowser();
            driverobj.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driverobj.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            CertificationUtilobj = new CertificationUtils(driverobj);
        }

             [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driverobj.Quit();
        }
    }
}
