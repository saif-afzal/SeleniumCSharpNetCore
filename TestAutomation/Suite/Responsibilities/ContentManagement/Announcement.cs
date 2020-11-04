using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class f_Announcement : TestBase
    {
        string browserstr = string.Empty;
        public f_Announcement(string browser)
            : base(browser)
        {
            browserstr = browser;
}
        
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
          //  driver.Navigate().GoToUrl("http://baseqa-14-3.meridianksi.net/Default.aspx");
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        }
        [Test]
        public void e113_Create_a_new_announcement()
        {
            
            string expectedresult = " The item was created.";
            Document documentpage = new Document(driver);
            driver.UserLogin("admin",browserstr);
            // driver.openadminconsolepage();
       
            documentpage.linkmyresponsibilitiesclick();
            documentpage.tabcontentmanagementclick() ;
            documentpage.buttoncoursecreationgoclick("Announcement");
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_announcement["Title"]+browserstr);
      //      driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_FormView1_CNTLCL_CONTACT_INFO']")).SendKeys(ExtractDataExcel.MasterDic_announcement["Title"]);
       //      driver.GetElement(By.XPath("//input[@id='MainContent_UC1_CNT_NUMBER']")).Clear();
          
              //  driver.GetElement(By.XPath("//input[@id='MainContent_UC1_CNT_NUMBER']")).SendKeys(globalnum + 1);

            driver.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
     
                driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Save']")).ClickWithSpace();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage)));

            driver.Checkin();
            //driver.GetElement(By.XPath("//a[@id='NavigationStrip1_lbUserView']")).ClickWithSpace();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.WaitForElement(By.Id("announcementsBtn"));
         
                IWebElement element = driver.FindElement(By.Id("announcementsBtn"));
             //   driver.GetElement(By.Id("announcementsBtn")).Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", element);
     
          //  driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucAnnouncements_rlvListing_ctrl0_lnkTitle']"));
        //  string text =  driver.gettextofelement(By.XPath("//a[@id='ctl00_MainContent_ucAnnouncements_rlvListing_ctrl0_lnkTitle']"));
            Assert.IsTrue(driver.checktextispresent(By.XPath("//h3[contains(.,'" + ExtractDataExcel.MasterDic_announcement["Title"] + browserstr + "')]")));
          
         //   StringAssert.AreEqualIgnoringCase(ExtractDataExcel.MasterDic_announcement["Title"], text);
           
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        
        }
        public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
        [Test]
        public void e114_Conduct_a_simple_and_advanced_search_for_a_document()
        {
            driver.UserLogin("admin",browserstr);
            // driver.openadminconsolepage();
            GeneralCourse generalcourse = new GeneralCourse(driver);
            //generalcourse.linkmyresponsibilitiesclick();
            //generalcourse.tabcontentmanagementclick();
            //generalcourse.buttoncoursecreationgoclick("Announcement");
            //generalcourse.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_announcement["Title"], ExtractDataExcel.MasterDic_genralcourse["Desc"], 9);
            //generalcourse.populateCourseFilesform(driver);
            //generalcourse.buttoncreateclick(driver);

            string expectedresult = "1 Items";
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            generalcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_announcement["Title"]+browserstr, "");


           Assert.IsTrue(generalcourse.buttoncontentsearchclick());
         //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
       //     driver.UserLogin("admin");
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            generalcourse.populatecontentsearchadvance1("Exact phrase", ExtractDataExcel.MasterDic_announcement["Title"]+browserstr, ExtractDataExcel.MasterDic_genralcourse["Desc"], 9,"Announcement");



           Assert.IsTrue(generalcourse.buttoncontentsearchclick());
     //       driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }
        [Test]
        public void e115_Manage_an_announcement()
        {
            Document documentpage = new Document(driver);
            GeneralCourse generalcourse = new GeneralCourse(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentpage.tabcontentmanagementclick();
            string expectedresult = " The changes were saved.";
            generalcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_announcement["Title"]+browserstr, "");
            generalcourse.buttoncontentsearchclick();
            driver.ScrollToCoordinated("500", "500");
            driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']")).ClickWithSpace();
            driver.Checkout();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']")).ClickWithSpace();

            driver.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE']")).Clear();
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE']")).SendKeysWithSpace("an update");
            driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
          
            driver.WaitForElement(ObjectRepository.sucessmessage);
            driver.Compareregexstring(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
 //StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
            driver.Checkin();
          //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void e116_Delete_an_announcement()
        {
            Document documentpage = new Document(driver);
            string expectedresult = " The selected items were deleted.";
            driver.WaitForElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']")).ClickWithSpace();
            driver.SwitchTo().Alert().Accept();
            //  driver.UserLogin("admin");
            // driver.openadminconsolepage();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            driver.Compareregexstring(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
            //StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
          
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
      
    
    }
}
