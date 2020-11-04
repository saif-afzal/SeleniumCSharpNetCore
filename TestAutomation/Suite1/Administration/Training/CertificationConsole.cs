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
    class CertificationConsoleold : Selenium2TestBase
    {

        public static IWebDriver driverobj;
        static CertificationUtils CertificationUtilobj;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Common.closeie();
            //ExtractDataExcel.fillalldic();
            driverobj = StartBrowser();
            driverobj.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driverobj.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            CertificationUtilobj = new CertificationUtils(driverobj);
        }

        [Test]
        public static void a_Search_for_certifications()
        {

            driverobj.UserLogin("admin1");
            Assert.IsTrue(CertificationUtilobj.Search_Certification_Console());
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public static void b_Conduct_a_Search_for_users_who_have_progress_against_a_certification()
        {
            driverobj.UserLogin("userforregression");
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driverobj.UserLogin("admin1");
            Assert.IsTrue(CertificationUtilobj.Search_User());
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }


        [Test]
        public static void c_Grant_a_certifications_to_a_user()
        {
            driverobj.UserLogin("admin1",);
            Assert.IsTrue(CertificationUtilobj.Grant_Certification());
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public static void d_Revoke_a_certification_for_a_user()
        {

            driverobj.UserLogin("admin1");
            Assert.IsTrue(CertificationUtilobj.Revoke_Certification());
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }




        [Test]
        public static void e_Suspend_a_certification_for_a_user()
        {
            driverobj.UserLogin("admin1");
            Assert.IsTrue(CertificationUtilobj.Suspend_Certification());
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driverobj.Quit();
        }
    }
}
