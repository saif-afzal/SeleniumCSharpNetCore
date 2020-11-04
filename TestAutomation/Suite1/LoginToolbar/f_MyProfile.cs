using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Selenium2.Meridian.Suite.LoginToolbar
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class f_MyProfileold : TestBase
    {
        string browserstr = string.Empty;
        public f_MyProfileold(string browser)
            : base(browser)
        {
            browserstr = browser+"myprof";
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }
     
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test]
        public  void a_Edit_Profile_information_for_the_UserInfo()
        {

            driver.UserLogin("userforregression", browserstr);
            string _expectedresult = "The changes were saved.";
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickProfileTab();
            string _actualresult = MyAccountobj.MyProfileEditUserInfo();
            StringAssert.Contains(_expectedresult, _actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public  void b_Edit_Profile_information_for_the_Qualifications()
        {

            driver.UserLogin("userforregression", browserstr);
            string _expectedresult = "The changes were saved.";
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickProfileTab();
            string _actualresult = MyAccountobj.MyProfileEditQualification();
            Assert.IsTrue(driver.Compareregexstring(_expectedresult, _actualresult));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }


        [Test]
        public  void c_Edit_Profile_information_for_the_Preferences()
        {
            driver.UserLogin("userforregression", browserstr);
            string _expectedresult = "The changes were saved.";
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickPreferencesTab();
            string _actualresult = MyAccountobj.MyProfileEditPreferences();
            Assert.IsTrue(driver.Compareregexstring(_expectedresult, _actualresult));
         
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]

        public  void d_Edit_Profile_information_for_the_Work_Information()
        {

            string _expectedresult = "The changes were saved.";
            //driver.UserLogin("admin1",browserstr);
            //MyAccountobj.cofigureforselectingmultipleuser();
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickProfileTab();
            string _actualresult = MyAccountobj.MyProfileEditWorkInformation();
            Assert.IsTrue(driver.Compareregexstring(_expectedresult, _actualresult));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        //[Test]

        //public static void e_Edit_Profile_information_for_the_Edit_User_Data()
        //{

        //    string _expectedresult = "The changes were saved.";
        //    driver.UserLogin("userforregression",browserstr);
        //    string _actualresult = MyProfileobj.MyProfileedituserdata();
        //    StringAssert.Contains(_expectedresult, _actualresult);
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //}

        [Test]

        public  void e_View_Profile_information_for_Roles_and_Permissions()
        {

            string _expectedresult = "The roles and permissions you have acquired are listed below.";
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickAccountTab();
            string _actualresult = MyAccountobj.MyProfileviewroleandpermission();
            StringAssert.Contains(_expectedresult, _actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }

        [Test]
        public  void f_Edit_Shipping_information()
        {
            driver.UserLogin("userforregression", browserstr);
            string _expectedresult = "automateinfo";
            TrainingHomeobj.Click_MyAccount();
            MyAccountobj.ClickEcommerceTab();
            string _actualresult = MyAccountobj.MyProfileeditshippingaddress();
            StringAssert.Contains(_expectedresult, _actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

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
