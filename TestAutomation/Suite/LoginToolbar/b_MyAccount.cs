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
  public  class b_MyAccount : TestBase
    {
        string browserstr = string.Empty;
        string email = string.Empty;
      public b_MyAccount(string browser)
            : base(browser)
        {
            browserstr = browser+"MyAccount";
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
        public  void a_Create_Account()
        {
            driver.UserLogin("admin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            //ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            //ManageUsersobj.Click_SearchUser();
            //Assert.IsTrue(driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"], ManageUsersobj.passwordcreationnewuser()));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public  void b_Login_to_the_site()
        {
            driver.UserLogin("admin", browserstr);
            Assert.IsTrue(TrainingHomeobj.VerifyGlobalNavigation());
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public void c_Forgot_Login_ID()
        {
            email= ExtractDataExcel.MasterDic_userforreg["Email"];
            string extectedresult ="You will receive an email containing your login ID.";
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "forget", ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr + "forget", ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr + "forget","@tpg.com");
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr + "forget", ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr + "forget");
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "forget", ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Loginobj.Click_btnlogin();
            string actualresult = Loginobj.Click_lnkforgetlogin(browserstr, ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "forget" + "@tpg.com");
            Assert.IsTrue(driver.Compareregexstring(extectedresult, actualresult));
        }
        [Test]
        public void d_Forgot_Password()
        {
            string extectedresult = " The system assigned a temporary password to you. It was sent to the email address listed in your profile within the system. ";
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            Loginobj.Click_btnlogin();
            string actualresult = Loginobj.Click_lnkforgetpassword(browserstr);
        
            Assert.IsTrue(driver.Compareregexstring(extectedresult, actualresult));
        }
        [Test]
        public void e_Contact_Admin()
        {
           
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
           Assert.IsTrue(Loginobj.Click_ContactAdmin(browserstr));
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
