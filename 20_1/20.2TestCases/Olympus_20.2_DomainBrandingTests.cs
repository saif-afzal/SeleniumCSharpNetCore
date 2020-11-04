using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]

    [TestFixture("anybrowser", Category = "local")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class NF_Olympus_20_2_DomainBrandingTests : TestBase
    {
        string browserstr = string.Empty;
        bool TC35342;
        public NF_Olympus_20_2_DomainBrandingTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }


        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test, Order(1)]
        public void tc_63902_As_a_Admin_search_for_the_theme_in_the_Landing_page()
        {
            CommonSection.Administer.System.BrandingAndCustomization.Themes();
            _test.Log(Status.Info, "Navigate to System Branding and Customization >> Themes page");
            Assert.IsTrue(Driver.checkTitle("Themes"));
            _test.Log(Status.Pass, "Verify Page title is Themes");
            Assert.IsTrue(ThemesPage.isSearchBarisdisplay());
            _test.Log(Status.Pass, "Verify Searchbar is display");
            ThemesPage.Searchbar.Search("asdasdsasa");
            _test.Log(Status.Info, "Search any not match text");
            Assert.IsTrue(ThemesPage.isNorecordsfounddisplay());
            _test.Log(Status.Info, "Verify no result found");
            ThemesPage.Searchbar.Search("Default");
            _test.Log(Status.Info, "Search any match text");
            Assert.IsTrue(ThemesPage.isSearchresultFound("Default"));
            _test.Log(Status.Info, "Verify result is found found");
        }
    }
        
}



