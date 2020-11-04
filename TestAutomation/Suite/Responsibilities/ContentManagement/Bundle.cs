using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
 class p_TC_Bundle : TestBase
    {
        string browserstr = string.Empty;
     public p_TC_Bundle(string browser)
            : base(browser)
        {
            browserstr = browser;
     }
      
        public Training objTraining;
        public Login objLogin;
        public TrainingHomes objTrainingHome;
        public ContentSearch objContentSearch;
        public Create objCreate;
        public Content objContent;
        public AdministrationConsoles objAdminConsole;
        public RequiredTrainingConsoles objReqTrainingConsole;
        public RequiredTraining objReqTraining;
        
        
        [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
           // objLogin = new Login();
            objTrainingHome = new TrainingHomes(driver);
            objTraining = new Training(driver);
            objContentSearch = new ContentSearch(driver);
            objCreate = new Create(driver);
            objContent = new Content(driver);
            objAdminConsole = new AdministrationConsoles(driver);
            objReqTrainingConsole = new RequiredTrainingConsoles(driver);
            objReqTraining = new RequiredTraining(driver);
            driver.UserLogin("admin1", browserstr);

        }

        [SetUp]
        public void SetUp()
        {
      
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
            //  objLogin.Login_click(driver);
        }

        [Test]
        //Creating a Bundle
        public void A_CreateANewBundle()
        {
            /* objTrainingHome.AdminConsole_Click(driver);
             objAdminConsole.ConfigConsole_Click(driver);
             objConfigConsole.ContentSettings_Click(driver);
             objContentSettings.IsAccessPeriod(driver);
             objTrainingHome.QuitAdminConsole(driver);*/

            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.NewContent("Bundle");
            objCreate.FillBundlePage(browserstr);

            //String Assertion on new Bundle creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            objContent.ContentSearch_Click();
            objContentSearch.Simple_Search(Variables.bundleTitle+browserstr);

            //Assertion for bundle displayed on search
            Assert.IsTrue(objContentSearch.ViewInList());
        }

        [Test]
        public void B_SimpleAndAdvanceSearchForBundle()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.bundleTitle+browserstr);
            // Bundle displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList());

            objContentSearch.AdvanceSearch(Variables.bundleTitle+browserstr, "ML.BASE.BUNDLE");
            // Bundle displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList());
        }

 /*       [Test]
        public void C_ManageABundle()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click(driver);
            objContentSearch.Simple_Search( Variables.bundleTitle);
            objContentSearch.Content_Click();
            objContent.Edit_Click(driver);
            //String assertion on updating Bundle
            String successMsg = objContent.SuccessMsgDisplayed(driver);
            StringAssert.Contains("The changes were saved.", successMsg);
        }*/

        [Test]
        public void D_AssignRequiredTrainingToABundle()
        {
            
            //objTrainingHome.AdminConsole_Click(driver);
            //objAdminConsole.RequiredTraining_Click(driver);
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-requiredTrainingManagement']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Training Assignments')]"));
            driver.selectWindow("Required Training Console");
          //  TrainingHomeobj.click_systemOptionsTab("Training");changed this as the term training is same in parent page.
           
            objReqTrainingConsole.Click_RequiredTrainingContentSearch(Variables.bundleTitle+browserstr);
            objReqTrainingConsole.Click_GoToRequiredTraining();
           Assert.IsTrue( objReqTraining.Assigntraining());
           
         //   objTrainingHome.QuitAdminConsole(driver);
        }

        [Test]
        public void E_CopyABundle()
        {
            driver.Navigate_to_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.bundleTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.Copy_Click();

            //String assertion on Copy of the bundle
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was copied. Use the workflow steps to make changes to the new item.", successMsg);
        }

        [Test]
        public void F_DeleteABundle()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.bundleTitle+browserstr);
            objContentSearch.Content_Click();
            objContent.DeleteContent_Click();
            //String assertion on deletion of bundle
            String successMsg = objTraining.SuccessMsg_DeletingCertification();
            StringAssert.Contains("The selected items were deleted.", successMsg);
        }

        [TearDown]
        public void TearDown()
        {
           
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Console.WriteLine("TearDown");
            driver.Quit();
        }

       
    } 
}
