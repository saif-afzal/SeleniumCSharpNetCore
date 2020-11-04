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

namespace Selenium2.Meridian.Suite.MyOwnLearning.TrainingHome
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class MyCompletedTraining : TestBase
    {
        string browserstr = string.Empty;
        public MyCompletedTraining(string browser)
            : base(browser)
        {
            browserstr = browser + "MCT";
        }
       
        static MyOwnLearningUtils MyOwnLearningobj;
        static TrainingHomes TrainingHomeobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            TrainingHomeobj = new TrainingHomes(driver);
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
        public void a_Access_the_Training_Home_page_and_view_the_My_Completed_Training_portlet()
        {
            MyOwnLearningobj.CreateGeneralCourse(1, "th_completed", browserstr);
            driver.UserLogin("userforregression", browserstr);
            MyOwnLearningobj.EnrollGenCourse(1, "th_completed", browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            MyOwnLearningobj.editexpirationdate("th_completed", browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(MyOwnLearningobj.CompleteTraining(1, 1, "th_completed", browserstr));
            
        }

        [Test]
        public void b_Select_a_30_60_90_day_filter()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            bool _actualresult = MyOwnLearningobj.Check306090(1, "th_completed", browserstr);
            Assert.IsTrue(_actualresult);
        }

        [Test]
        public void c_Click_the_All_My_Training_button()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            bool _actualresult = MyOwnLearningobj.ClickAllMyCompletedTraining("Transcript", "th_completed", browserstr);
            Assert.IsTrue(_actualresult);
        }

        [Test]
        public void d_Click_the_Print_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            bool _actualresult = MyOwnLearningobj.ClickTranscriptPrint("All My Training", 1, "th_completed", browserstr);
            Assert.IsTrue(_actualresult);
        }
        [Test]
        public void e_Click_the_View_Certificate_button_for_content()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            bool _actualresult = MyOwnLearningobj.ViewCertificateDetail(browserstr);
            Assert.IsTrue(_actualresult);
        }

        [Test]
        public void f_Click_on_a_content_item()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            bool _actualresult = MyOwnLearningobj.ClickOnTranscriptItem("th_completed", browserstr);
            Assert.IsTrue(_actualresult);
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
