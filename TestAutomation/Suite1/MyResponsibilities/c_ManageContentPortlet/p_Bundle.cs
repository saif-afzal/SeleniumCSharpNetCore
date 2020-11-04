using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
 class p_TC_Bundleold : TestBase
    {
        string browserstr = string.Empty;
     public p_TC_Bundleold(string browser)
            : base(browser)
        {
            browserstr = browser;
            // driver.Manage().Window.Maximize();
            InitializeBase(driver);
            Driver.Instance = driver;
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
      
        public Training objTraining;
        public Login objLogin;
        public TrainingHomes objTrainingHome;
        public ContentSearch objContentSearch;
        public Create objCreate;
        public Content objContent;
        public AdministrationConsoles objAdminConsole;
        public RequiredTrainingConsoles objReqTrainingConsole;
        public RequiredTraining objReqTraining;
        
        
    

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
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


            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Bundle_CourseClick);
            objCreate.FillBundlePage(browserstr);

            //String Assertion on new Bundle creation 
            String successMsg = objContent.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            //objContent.ContentSearch_Click();
            objTrainingHome.MyResponsiblities_click();
            objContentSearch.Simple_Search(Variables.bundleTitle+browserstr);

            //Assertion for bundle displayed on search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.bundleTitle + browserstr));
        }

       // [Test]
        public void B_SimpleAndAdvanceSearchForBundle()
        {
            objTrainingHome.MyResponsiblities_click();
            objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.bundleTitle+browserstr);
            // Bundle displayed on simple search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.bundleTitle + browserstr));

            objContentSearch.AdvanceSearch(Variables.bundleTitle+browserstr, "ML.BASE.BUNDLE");
            // Bundle displayed on advance search
            Assert.IsTrue(objContentSearch.ViewInList(Variables.bundleTitle + browserstr));
        }

        /*       [Test]
               public void C_ManageABundle()
               {
                   objTrainingHome.MyResponsiblities_click();
                   objTraining.SearchContent_Click(driver);
                   objContentSearch.Simple_Search( Variables.bundleTitle);
                   objContentSearch.Content_Click();
                   objContent.Edit_Click(driver);
                   String assertion on updating Bundle
                   String successMsg = objContent.SuccessMsgDisplayed(driver);
                   StringAssert.Contains("The changes were saved.", successMsg);
               }*/

        //  [Test]
        public void D_AssignRequiredTrainingToABundle()
        {
            
            //objTrainingHome.AdminConsole_Click(driver);
            //objAdminConsole.RequiredTraining_Click(driver);
            driver.HoverLinkClick(By.XPath(".//*[@id='mega-li']/a"), By.XPath("//a[@href='#admin-console-requiredTrainingManagement']"));
            driver.ClickEleJs(By.XPath(".//*[@id='admin-console-requiredTrainingManagement']/div/ul/li[1]/a"));
            driver.SwitchWindow("Required Training Console");
            objReqTrainingConsole.Click_RequiredTrainingContentSearch(Variables.bundleTitle+browserstr);
            objReqTrainingConsole.Click_GoToRequiredTraining();
           Assert.IsTrue( objReqTraining.Assigntraining());
           
         //   objTrainingHome.QuitAdminConsole(driver);
        }

        [Test]
        public void E_CopyABundle()
        {
          //  driver.Navigate_to_TrainingHome();
          //  TrainingHomeobj.isTrainingHome();
            objTrainingHome.MyResponsiblities_click();
       //     objTraining.SearchContent_Click();
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
            Document documentpage = new Document(driver);
            objTrainingHome.MyResponsiblities_click();
          //  objTraining.SearchContent_Click();
            objContentSearch.Simple_Search(Variables.bundleTitle+browserstr);
            objContentSearch.Content_Click();
            string actualresult = documentpage.buttondeletesectionclick();
            Assert.IsTrue(driver.comparePartialString("Success", driver.getSuccessMessage()));
        }

        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //  _extent.Flush();
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }


    } 
}
