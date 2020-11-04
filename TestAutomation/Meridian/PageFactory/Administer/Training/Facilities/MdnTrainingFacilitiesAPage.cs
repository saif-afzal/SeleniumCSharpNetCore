using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;

namespace TestAutomation.PageFactoryTests
{
    class MdnTrainingFaciltiesAPage
    {
        static string Url = "https://prdct-mg-17-2.mksi-lms.net/Default.aspx";
        string Title = string.Empty;
        [FindsBy(How = How.Id, Using = "MainContent_UC5_btnLogin")]
        [CacheLookup]
        private IWebElement LoginButton;
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement Username;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement SignInButton;
        #region Username Initials tab
        [FindsBy(How = How.Id, Using = ".//*[@id='divDefaultAvatar']/span")]
        private IWebElement NameInitialsTab;
        #region Other Options
        [FindsBy(How = How.Id, Using = ".//*[@id='user-dropdown']/li[1]/a")]
        private IWebElement AccountLink;
        [FindsBy(How = How.Id, Using = ".//*[@id='lnkMyMessages']")]
        private IWebElement MessagesLink;
        [FindsBy(How = How.XPath, Using = ".//*[@id='user-dropdown']/li[3]/a")]
        private IWebElement OrdersLink;
        [FindsBy(How = How.Id, Using = ".//*[@id='user-dropdown']/li[4]/a")]
        private IWebElement ReportLink;
        [FindsBy(How = How.Id, Using = "..//*[@id='user-dropdown']/li[5]/a")]
        private IWebElement CalendarLink;
        [FindsBy(How = How.Id, Using = ".//*[@id='user-dropdown']/li[6]/a")]
        private IWebElement RequestsLink;
        [FindsBy(How = How.XPath, Using = ".//*[@id='user-dropdown']/li[8]/a")]
        private IWebElement LogoutLink;
        #endregion
        #endregion

        private IWebDriver driverobj;
        public MdnTrainingFaciltiesAPage(IWebDriver driver)
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
        #region Clicking Login
        public void ClickLogin()
        {
            LoginButton.Click();
        }
        #endregion
       
    }
    //public class BmiCalcPage
    //{
    //    static string Url = "http://cookbook.seleniumacademy.com/bmicalculator.html";
    //    private static string Title = "BMI Calculator";
    //    [FindsBy(How = How.Id, Using = "heightCMS")]
    //    [CacheLookup]
    //    private IWebElement HeightField;

    //    [FindsBy(How = How.Id, Using = "weightKg")]

    //    private IWebElement WeightField;
    //    [FindsBy(How = How.Id, Using = "Calculat")]

    //    private IWebElement CalculateButton;
    //    [FindsBy(How = How.Id, Using = "bmi")]

    //    private IWebElement BmiField;
    //    [FindsBy(How = How.Id, Using = "bmi_category")]

    //    private IWebElement BmiCategoryField;

    //    private IWebDriver driverobj;
    //    public BmiCalcPage(IWebDriver driver)
    //    {
    //        driverobj = driver;
    //        PageFactory.InitElements(driverobj, this);
    //    }
    //    public void Load()
    //    {
    //        driverobj.Navigate().GoToUrl(Url);

    //    }
    //    public void Close()
    //    {
    //        driverobj.Close();

    //    }
    //    public bool isLoaded
    //    {
    //        get { return driverobj.Title.Equals(Title); }

    //    }
    //    public void CalculateBmi(String height, String weight)
    //    {
    //        HeightField.SendKeys(height);
    //        WeightField.SendKeys(weight);
    //        CalculateButton.Click();
    //    }
    //    public String Bmi
    //    {
    //        get { return BmiField.GetAttribute("value"); }
    //    }
    //    public String BmiCategory
    //    {
    //        get { return BmiCategoryField.GetAttribute("value"); }
    //    }
    //}
}
