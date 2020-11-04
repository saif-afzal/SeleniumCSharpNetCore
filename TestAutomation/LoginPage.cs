using System;
using OpenQA.Selenium;
//using TestAutomation.P1.MyResponsibilities.Training;
using System.Threading;
using TestAutomation.helper;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class LoginPage
    {
        public  string Title { get; internal set; }
        public  string username = "siteadmin";
        public  string password = "password";
        private IWebDriver objDriver;

        public LoginPage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public  void GoTo(string env = "")
        {
            if (env == "")
            {
                objDriver.Navigate().GoToUrl("https://prdct-mg-20-2.mksi-lms.net/");
            }
            else
            {
                objDriver.Navigate().GoToUrl(env);
            }
        }

        public  void LoginClick()
        {
            //commented because of bug
          //  Meridian_Common.parentwdw = objDriver.CurrentWindowHandle;
            if (objDriver.existsElement(By.Id("MainContent_UC5_btnLogin")))
            {
                objDriver.ClickEleJs(By.Id("MainContent_UC5_btnLogin"));
            }
            objDriver.IsElementDisplayed_Generic(By.Id("username"));

            objDriver.GetElement(By.Id("username")).Clear();
        }

        public  LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username,objDriver);
        }

        public  void CreateAccountClick()
        {
            throw new NotImplementedException();
        }

        public  void ClickSignup()
        {
            Driver.clickEleJs(By.LinkText("Sign up!"));
        }

        public  void ClickBrowsePublicCatalogLink()
        {
            Driver.clickEleJs(By.XPath("//a[@class='ng-binding']"));
        }

        public  void Login()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));
        }

        public  bool? isSignupLisnkdisplay()
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'Sign up!')]"));
        }

        public  bool? isBrowsePublicCatalog()
        {
            return Driver.existsElement(By.XPath("//a[@class='ng-binding']"));
        }
    }

    public class LoginCommand
    {
        private string password;
        private string username;
        private IWebDriver objDriver;

        public LoginCommand(string username,IWebDriver objDriver)
        {
            this.username = username;
            this.objDriver = objDriver;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            if (username != "")
            {
                objDriver.GetElement(By.Id("username")).SendKeysWithSpace(username);
            }
            else
            {
                Thread.Sleep(4000);
                objDriver.IsElementDisplayed_Generic(By.Id("username"));
                Driver.GetElement(By.Id("username")).SendKeysWithSpace(username);
            }
            Meridian_Common.parentwdw = objDriver.CurrentWindowHandle;
            if (password != "")
            {
                objDriver.GetElement(By.Id("password")).SendKeysWithSpace(password);
            }
            else
            {
              
               
                objDriver.GetElement(By.Id("password")).SendKeysWithSpace(password);
            }
            //Driver.GetElement(By.Id("password")).SendKeysWithSpace(LoginPage.password);
         //   objDriver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5000);
            objDriver.GetElement(By.XPath("//input[@value='Log In']")).ClickWithSpace();
            Thread.Sleep(3000);
            if (objDriver.checkElementExists(By.XPath("//div[@class='alert alert-danger ng-binding ng-scope']"),10))
            {
                //Driver.CreateNewAccount();
            }
        }

        //public WithFileCommand WithFile(string p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}