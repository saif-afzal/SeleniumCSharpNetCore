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
   public class c_Login : TestBase
    {
        string browserstr = string.Empty;
       public c_Login(string browser)
            : base(browser)
        {
            browserstr = browser+"login";
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

        public  void a_Change_Login_ID()
        {
            driver.UserLogin("admin", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "tochange", ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr + "tochange", ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr + "tochange", ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr+"tochange", ExtractDataExcel.MasterDic_newuser["Lastname"] +browserstr+ "tochange");
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] +browserstr+ "tochange", ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            string _expectedresult = " Your login ID was updated. Use your new login ID the next time you log in.";
            TrainingHomeobj.Click_MyAccount();
            string _actualresult = MyAccountobj.ChangeUserId(browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("custom",browserstr, "change_" + ExtractDataExcel.MasterDic_newuser["Id"] +browserstr+ "tochange", ExtractDataExcel.MasterDic_newuser["Password"]);
            Assert.IsTrue(driver.Compareregexstring(_actualresult, _expectedresult));
     

        }

        [Test]
        public  void b_Change_Password()
        {
            TrainingHomeobj.Click_MyAccount();
            string _expectedresult = " Your password was changed. Remember to use your new password the next time you log in.";
            string _actualresult = MyAccountobj.ChangePassword();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("custom",browserstr, "change_" + ExtractDataExcel.MasterDic_newuser["Id"] +browserstr+ "tochange", ExtractDataExcel.MasterDic_newuser["Password"] + ExtractDataExcel.token_for_reg);
            Assert.IsTrue(driver.Compareregexstring(_actualresult, _expectedresult));
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

       [Test]
        public  void c_Change_Security_Questions()
        {
           
            string _expectedresult = " The changes were saved.";
            TrainingHomeobj.Click_MyAccount();
            string _actualresult = MyAccountobj.ChangeSecurityQuestion();
            Assert.IsTrue(driver.Compareregexstring(_actualresult, _expectedresult));
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
