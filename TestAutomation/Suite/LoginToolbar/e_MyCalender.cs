using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;
namespace Selenium2.Meridian.Suite.LoginToolbar
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class e_MyCalender : TestBase 
    {
        string browserstr = string.Empty;
        public e_MyCalender(string browser)
            : base(browser)
        {
            browserstr = browser+"clndr";
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);

        }

        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test]
        public  void a_Click_on_My_Calendar()
        {

            driver.UserLogin("admin1", browserstr);//userforregression
            Assert.IsTrue(TrainingHomeobj.lnk_MyClanederClick());
           
        }

        [Test]
        public  void b_Add_an_event_to_the_calendar()
        {
            string expectedresult = "The event was created.";
            TrainingHomeobj.lnk_MyClanederClick();
            string _actualresult = MyCalendersobj.AddEventToCalender();
            StringAssert.Contains(expectedresult, _actualresult);
        }


        [Test]
        public  void c_Edit_an_event()
        {
            string expectedresult = "The event was updated.";
            TrainingHomeobj.lnk_MyClanederClick();
            string _actualresult = MyCalendersobj.EditEventFromCalender();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, _actualresult));
          
        }

        [Test]
        public  void d_Delete_an_event()
        {
            string expectedresult = "The event was deleted.";
            TrainingHomeobj.lnk_MyClanederClick();
            string _actualresult = MyCalendersobj.DeleteEventFromCalender();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, _actualresult));

        }

        [Test]
        public  void e_View_Calendar_Day_view()
        {

            TrainingHomeobj.lnk_MyClanederClick();
           Assert.IsTrue(MyCalendersobj.CalenderSwitchToWeek());
           

        }

        [Test]
        public  void f_View_Calendar_Month_view()
        {

            TrainingHomeobj.lnk_MyClanederClick();
            Assert.IsTrue(MyCalendersobj.CalenderSwitchToMonth());
            
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

       // [Test]
        public  void g_Print_the_calendar()
        {

            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyClanederClick();
            Assert.IsTrue(MyCalendersobj.PrintCalender());
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
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }



    }
}
