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

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]

    [Parallelizable(ParallelScope.Fixtures)]
    class Aboutthesystem : TestBase
    {
        string browserstr = string.Empty;
        public Aboutthesystem(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
      
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1",browserstr);

        }
        [SetUp]
        public void starttest()
        {

            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
          

            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1",browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Create_a_new_approval_path()
        {

       
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
            ApprovalPathobj.Click_CreateNewGoTo();
            ApprovalPathobj.Click_Create("admin", browserstr);
            Assert.IsTrue(ApprovalPathobj.Click_AddApproval());

        }
        [Test]
        public void b_Conduct_a_search_for_an_approval_path()
        {


            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
            Assert.IsTrue(ApprovalPathobj.Click_Search("admin", browserstr));

        }
        [Test]
        public void c_Edit_approves_and_stages_for_an_approval_path()
        {


            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
            ApprovalPathobj.Click_Search("admin", browserstr);
            ApprovalPathobj.Click_ManageGoTo();
            ApprovalPathobj.Click_Approvertab();
            Assert.IsTrue(ApprovalPathobj.Click_AddApproval());

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
                driver.Navigate_to_TrainingHome();
                TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                {
                    driver.Navigate().Refresh();
                }
                
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
             driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.Quit();
        }

    }
}
