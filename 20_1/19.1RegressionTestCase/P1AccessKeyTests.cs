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
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1AccessKeyTests : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPath" + Meridian_Common.globalnum;
        bool TC_10574 = false;


        public P1AccessKeyTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

       // [OneTimeSetUp]
        public void OneTimeSetUp()
        {
          
        }
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
        string bundlecourse = "GeneralCourse" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
      //  bool TC_10574 = false;
        bool TC_10823 = false;
        bool TC_10879 = false;
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

       

        [Test, Order(1), Category("AutomatedP1")]
        public void A05_Test_AccessKeys_Accordian_For_Bundle_35814()
        {
            #region Create General Course and Bundle With Cost and Access keys Enabled
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse, "Test General Course");
            GeneralCoursePage.setCost("5");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "Paid general course created");
            CommonSection.Learn.Home();
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Creating a Paid Bundle Course with Access Keys");
            objCreate.FillBundlePage(browserstr);
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            Assert.IsTrue(ClassroomCoursePage.enableAccessKeys());
            _test.Log(Status.Info, "Access Keys Accordian Has been verfiied for Bundle Course");
            #endregion
           
           
        }

      

        [Test, Order(2), Category("AutomatedP1")]
        public void A10_Test_AccessKeys_Accordian_For_AICC_35819()
        {
            #region Create AICC Course
            Document documentpage = new Document(driver);
            string expectedresult = "Summary";
            string expectedresult1 = "The course was created.";
            AICC aicccourse = new AICC(driver);
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            driver.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
            Assert.IsTrue(driver.Compareregexstring(expectedresult1, driver.gettextofelement(By.XPath("//*[contains(@class,'alert alert-success')]"))));
            aicccourse.populatesummaryform(driver, browserstr);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
            #endregion
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            DocumentPage.ClickButton_CheckOut();
            Assert.IsTrue(ClassroomCoursePage.enableAccessKeys());
            _test.Log(Status.Info, "Access Keys Accordian Has been verfiied for AICC Course");

        }
        


        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }




    }

    //public class AccessKeysPage
    //{
    //    public static ConentCommand Conent { get { return new ConentCommand(); } }

    //    public static void assignKeysToLearner(string v)
    //    {
    //        Driver.clickEleJs(By.XPath("//table[1]/tbody[1]/tr[1]/td[4]/div[1]/a[1]"));
    //        Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_txtEmail1']")).SendKeysWithSpace(v);
    //        IWebElement webElement = Driver.Instance.FindElement(By.XPath("//a[@id='MainContent_UC1_btnCancel']"));
    //        webElement.SendKeys(Keys.Tab);
    //        Thread.Sleep(1000);
    //        Driver.clickEleJs(By.XPath("//input[@value='Assign']"));
    //        Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
    //    }

    //    public static void searchForContent(string v)
    //    {
    //        Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_txtSearch']")).SendKeysWithSpace(v);
    //        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));
    //        Thread.Sleep(2000);
    //    }

    //    public static void ClickViewDetails(string v)
    //    {
    //        Driver.clickEleJs(By.XPath("//a[contains(text(),"+v+")]/following::a[1]"));
    //    }
    //}

    //public class ConentCommand
    //{
    //    public bool? ContentFormat()
    //    {
    //        return Driver.GetElement(By.XPath("//tr/td/p")).Displayed;
    //    }
    //}
}
