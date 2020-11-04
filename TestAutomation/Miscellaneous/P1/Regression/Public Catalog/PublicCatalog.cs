using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;

namespace Selenium2.Meridian.Suite.P1.Learning
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    //[TestFixture("edge", Category = "edge")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
  public  class PublicCatalogP1 : TestBase
    {
        string browserstr = string.Empty;
        public PublicCatalogP1(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        bool sectioncreation = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
           // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);

            Document documentpage = new Document(driver);
         //   string expectedresult = "Edit Summary";
         //   string expectedresult1 = "The course was created.";
            Scorm12 CreateScorm = new Scorm12(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Scorm_CourseClick);
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver, true);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
         //   StringAssert.AreEqualIgnoringCase(expectedresult, text);
            Assert.IsTrue(driver.existsElement(ObjectRepository.sucessmessage));
            CreateScorm.populatesummaryform(driver, browserstr);
            Assert.IsTrue(CreateScorm.buttonsaveclick(driver));
            driver.Checkout();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
            driver.WaitForElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']"));
            driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeysWithSpace("1");
            driver.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            driver.ClickEleJs(By.XPath("//input[@value='Back']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'Check-in')]"));
         //   driver.Checkout();

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [SetUp]
        public void starttest()
        {
            classroomcourse = new ClassroomCourse(driver);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin",browserstr);

            }
            Meridian_Common.islog = false;
        }
        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
            //    driver.Navigate_to_TrainingHome();
            }
        }
        //[Test,Order(1)]
        public void Add_Items_To_Public_Catalog_Cart_Checkout_23474()
        {
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
            driver.WaitForElement(By.XPath("//input[contains(@id,'MainContent_MainContent_UC2_ShareToPublicCatalog')]"));
            driver.ClickEleJs(By.XPath("//input[contains(@id,'MainContent_MainContent_UC2_ShareToPublicCatalog')]"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC2_Save']"));
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            driver.Checkin();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite + "public/trainingcatalog.aspx");
            #region Checkout with Existing User
            driver.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
            driver.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-default']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.WaitForElement(By.XPath("//input[@value='Add to Cart']"));
            driver.ClickEleJs(By.XPath("//input[@value='Add to Cart']"));
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            driver.ClickEleJs(By.XPath("//span[contains(.,'Shopping Cart')]"));
            driver.WaitForElement(By.XPath("//div[4]/div/div/input"));
            driver.ClickEleJs(By.XPath("//div[4]/div/div/input"));
            driver.SwitchWindow("Checkout");
            driver.WaitForElement(By.XPath("//a[@id='MainContent_UC1_Login']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_Login']"));
            driver.WaitForElement(By.XPath("//input[@name='username']"));
            driver.GetElement(By.XPath("//input[@name='username']")).SendKeysWithSpace("regadmin");
            driver.GetElement(By.XPath("//input[@name='password']")).SendKeysWithSpace("password");
            driver.ClickEleJs(By.XPath("//input[@type='submit']"));
            driver.WaitForElement(By.XPath("//input[@value='Checkout']"));
            driver.ClickEleJs(By.XPath("//input[@value='Checkout']"));
            driver.WaitForElement(By.XPath("//input[@value='Use this payment method']"));
            driver.ClickEleJs(By.XPath("//input[@value='Use this payment method']"));
            driver.WaitForElement(By.XPath("//input[@id='cbAgreeToTerms']"));
            driver.ClickEleJs(By.XPath("//input[@id='cbAgreeToTerms']"));
            driver.ClickEleJs(By.XPath("//input[@value='Place Order']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'"+ExtractDataExcel.MasterDic_scrom["Title"]+ browserstr +"')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//div[@class='alert alert-success']")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.WaitForElement(By.XPath("//input[@value='Open Item']"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.Navigate().GoToUrl("https://prdct-mg-17-3.mksi-lms.net/public/trainingcatalog.aspx");
            #endregion
            #region Checkout with New User
            driver.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
            driver.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-default']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.WaitForElement(By.XPath("//input[@value='Add to Cart']"));
            driver.ClickEleJs(By.XPath("//input[@value='Add to Cart']"));
            driver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            driver.ClickEleJs(By.XPath("//span[contains(.,'Shopping Cart')]"));
            driver.WaitForElement(By.XPath("//div[4]/div/div/input"));
            driver.ClickEleJs(By.XPath("//div[4]/div/div/input"));
            driver.SwitchWindow("Checkout");
            driver.WaitForElement(By.XPath("//a[@id='MainContent_UC1_Register']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_Register']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Id"] + browserstr);
            driver.GetElement(By.XPath("//input[contains(@id,'MainContent_UC1_USR_PASSWORD')]")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_ConfirmPassword']")).SendKeysWithSpace("password");
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr); ;
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Lastname"] + browserstr); ;
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Create']"));
            driver.WaitForElement(By.XPath("//input[@value='Checkout']"));
            driver.ClickEleJs(By.XPath("//input[@value='Checkout']"));
            driver.WaitForElement(By.XPath("//input[@value='Use this payment method']"));
            driver.ClickEleJs(By.XPath("//input[@value='Use this payment method']"));
            driver.WaitForElement(By.XPath("//input[@id='cbAgreeToTerms']"));
            driver.ClickEleJs(By.XPath("//input[@id='cbAgreeToTerms']"));
            driver.ClickEleJs(By.XPath("//input[@value='Place Order']"));
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")));
            Assert.IsTrue(driver.existsElement(By.XPath("//div[@class='alert alert-success']")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@value='Open Item']")));
            #endregion

        }

    }
}
