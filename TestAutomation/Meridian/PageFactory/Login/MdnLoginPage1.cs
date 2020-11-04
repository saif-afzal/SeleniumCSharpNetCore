using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;

namespace TestAutomation.PageFactoryTests
{
    class MdnLoginPage1
    {
        static string Url = "https://prdct-mg-17-2.mksi-lms.net/Default.aspx";
        private static string Title = "Login";
       
        [FindsBy(How = How.Id, Using = "username")]
        [CacheLookup]
        private IWebElement Username;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement SignInButton;
        private IWebDriver driverobj;
        public MdnLoginPage1(IWebDriver driver)
        {
            driverobj = driver;
            // driver = new ChromeDriver();
            PageFactory.InitElements(driverobj, this);
        }
        public void Load()
        {
            driverobj.Navigate().GoToUrl(Url);
        }
        public void Close()
        {
            driverobj.Close();
        }
        public bool isLoaded
        {
            get { return driverobj.Title.Equals(Title); }
        }
       
        #region Userlogin
        public void UserLogin(string type,string browser,string username="",string password="")
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            SignInButton.Click();
        }
        #endregion
    }
    public class BmiCalcPage
    {
        static string Url = "http://cookbook.seleniumacademy.com/bmicalculator.html";
        private static string Title = "BMI Calculator";
        [FindsBy(How = How.Id, Using = "heightCMS")]
        [CacheLookup]
        private IWebElement HeightField;

        [FindsBy(How = How.Id, Using = "weightKg")]

        private IWebElement WeightField;
        [FindsBy(How = How.Id, Using = "Calculat")]

        private IWebElement CalculateButton;
        [FindsBy(How = How.Id, Using = "bmi")]

        private IWebElement BmiField;
        [FindsBy(How = How.Id, Using = "bmi_category")]

        private IWebElement BmiCategoryField;

        private IWebDriver driverobj;
        public BmiCalcPage(IWebDriver driver)
        {
            driverobj = driver;
            PageFactory.InitElements(driverobj, this);
        }
        public void Load()
        {
            driverobj.Navigate().GoToUrl(Url);

        }
        public void Close()
        {
            driverobj.Close();

        }
        public bool isLoaded
        {
            get { return driverobj.Title.Equals(Title); }

        }
        public void CalculateBmi(String height, String weight)
        {
            HeightField.SendKeys(height);
            WeightField.SendKeys(weight);
            CalculateButton.Click();
        }
        public String Bmi
        {
            get { return BmiField.GetAttribute("value"); }
        }
        public String BmiCategory
        {
            get { return BmiCategoryField.GetAttribute("value"); }
        }
    }
}
