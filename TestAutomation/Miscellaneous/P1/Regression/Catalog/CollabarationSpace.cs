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


namespace Selenium2.Meridian.Suite.P1.Learning.Training_Catalog
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CollabarationSpaceP1 : TestBase
    {
        string browserstr = string.Empty;
        public CollabarationSpaceP1(string browser)
            : base(browser)
        {
            browserstr = browser+"CS";
        }
      
        public TrainingHomes TrainingHomeobj;
        public CollabarationSpace_l CollabarationSpace_lobj;
        public Details Detailsobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

           // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            TrainingHomeobj = new TrainingHomes(driver);
            CollabarationSpace_lobj = new CollabarationSpace_l(driver);
            Detailsobj = new Details(driver);
            driver.UserLogin("admin1", browserstr);
        }
        [SetUp]
        public void starttest()
        {
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("userforregression", browserstr);
            }
            Meridian_Common.islog = false;
        }
        //[Test]
        public void a_Join_a_collaboration_space_9462()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Learn')]"), By.XPath("//a[contains(@href,'/CollaborationSpace.aspx')]"));
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
           Assert.IsTrue( Detailsobj.Click_JoinColSpace());
            
        }

        //[Test]
        public void b_Access_a_collaboration_space_9478()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Detailsobj.Click_AccessColSpace();
           Assert.IsTrue(CollabarationSpace_lobj.IsColSpaceItemAccessed());
        //    Assert.IsTrue(driverobj.existsElement(By.XPath("//div[contains(@class,'axero-space-header-title-name')]")));
        }

        //[Test]
        public void c_Mark_a_collaboration_space_Complete_26275()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Assert.IsTrue(Detailsobj.Click_MarkCompleteColSpace());
            
        }




        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
    }
}
