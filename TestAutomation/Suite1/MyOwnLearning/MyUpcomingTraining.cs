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
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Selenium2.Meridian.Suite.MyOwnLearning
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [Parallelizable(ParallelScope.Fixtures)]
    class MyUpcomingTrainingold : TestBase
    {
        string browserstr = string.Empty;
        public MyUpcomingTrainingold(string browser)
            : base(browser)
        {
            browserstr = browser+"MUT";
            InitializeBase(driver);
            //      driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            TrainingHomeobj = new TrainingHomes(driver);
            Trainingobj = new Training(driver);
            ContentSearchobj = new ContentSearch(driver);
            Createobj = new Create(driver);
            Contentobj = new Content(driver);
            driver.UserLogin("admin1", browserstr);
        }
        
        static MyOwnLearningUtils MyOwnLearningobj;
        public TrainingHomes TrainingHomeobj;
        public Training Trainingobj;
        public ContentSearch ContentSearchobj;
        public Create Createobj;
        public Content Contentobj;

    
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
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
        public void a_Click_the_All_My_Upcoming_Training_button_from_the_My_Upcoming_Training_porlet_or_My_Upcoming_Training_from_the_menu()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
            Createobj.FillGeneralCoursePage("myupcoming" + 1, browserstr);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
            Createobj.FillGeneralCoursePage("myupcoming" + 2, browserstr);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            MyOwnLearningobj.EnrollGenCourse(2, "myupcoming", browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            MyOwnLearningobj.CompleteTraining(1, 1, "myupcoming", browserstr);
            driver.UserLogin("userforregression", browserstr);

            bool _actualresult = MyOwnLearningobj.CheckStatusofTraining("myupcoming", browserstr);
            Assert.IsTrue(_actualresult);
            ObjectRepository.upcomingtraingcreated = true;
        }

        [Test]
        public void b_Select_a_status_filter_from_the_drop_down()
        {
            bool _actualresult = MyOwnLearningobj.TrainingStatusFilter("myupcoming", browserstr);
            Assert.IsTrue(_actualresult);
        }
        [Test]
        public void c_Click_the_action_button_for_content()
        {
            bool _actualresult = MyOwnLearningobj.ClickActionButton();
            Assert.IsTrue(_actualresult);
        }

        [Test]
        public void d_Click_on_a_content_item()
        {
            bool _actualresult = MyOwnLearningobj.OpenDetailPage("myupcoming", browserstr);
            Assert.IsTrue(_actualresult);
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
