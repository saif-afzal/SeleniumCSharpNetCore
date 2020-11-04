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

namespace Selenium2.Meridian.P1
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class JobTitleP1 : TestBase
    {
        string browserstr = string.Empty;
        public JobTitleP1(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
           // driver.Manage().Window.Maximize();
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
        //[Test]
        public void a_Create_a_new_job_title_22211()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Job Titles");
            JobTitlesobj.Click_CreateNewGoTo();
            Assert.IsTrue(ManageJobTitleobj.Populate_JobTitle(browserstr));

        }

        //[Test]
        public void b_Manage_a_job_title_22212()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Job Titles");
            JobTitlesobj.Click_Search(browserstr);
            JobTitlesobj.Click_ManageItem();
            Assert.IsTrue(ManageJobTitleobj.Click_Save());

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
                //TrainingHomeobj.lnk_peopleManagement_click();
                //TrainingHomeobj.lnk_People_click();
                //TrainingHomeobj.lnk_SystemOptions_click();
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }

    }
}
