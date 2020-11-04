using NUnit.Framework;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class MeridianMobileApplication : TestBase
    {
        public MeridianMobileApplication(string browser)
            : base(browser)
        {
           // InitializeBase(driver);
            //Driver.Instance = driver;
            //LoginPage.GoTo();
            ////    LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
             [SetUp]
        public void starttest()
        {



        }
        [TearDown]
        public void teardown()
        {
            //  Driver.Instance.Quit();
        }
        [Test,Category("P1")]
        public void View_Response_Site_Layout_instead_of_Static_Site_Layout_32298()
        {
            Assert.Ignore("Mobile related");

        }
    }
}

