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


namespace Selenium2.Meridian.Suite.MyOwnLearning
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CollabarationSpace : TestBase
    {
        string browserstr = string.Empty;
        public CollabarationSpace(string browser)
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

            driver.Manage().Window.Maximize();
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
        [Test]
        public void a_Join_a_collaboration_space()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
           Assert.IsTrue( Detailsobj.Click_JoinColSpace());
            
        }


        [Test]
        public  void b_Click_on_a_collaboration_space_link()
        {

            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
          Assert.IsTrue(  Detailsobj.IsColSpaceDetailPage());
        }

      //  [Test] Need to add manager so that we can leave the collaboration space
        public  void d_Leave_a_collaboration_space()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Assert.IsTrue(Detailsobj.Click_LeaveColSpace());
        }

        [Test]
        public  void c_Access_a_collaboration_space()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_CollabartionSpace();
            CollabarationSpace_lobj.IsCollabarationSpace();
            CollabarationSpace_lobj.Click_ColSpaceItem();
            Detailsobj.Click_AccessColSpace();
            StringAssert.AreEqualIgnoringCase("Info",CollabarationSpace_lobj.IsColSpaceItemAccessed());
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
