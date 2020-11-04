using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Selenium2.Meridian
{
    class MyPurchases
    {

        private readonly IWebDriver driverobj;
        public static string purchaseitem = string.Empty;
        public MyPurchases(IWebDriver driver)
        {
            driverobj = driver;
        }

        public string View_PurchaseHistoryDetail()
        {
            bool result = false;
             string txtitem=string.Empty;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rgOrderHistory_ctl00_ctl04_lnkPurchaseDetails"));
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rgOrderHistory_ctl00_ctl04_lnkPurchaseDetails")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rgOrderDetials_ctl00_ctl04_lnkDetails"));
              txtitem = driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rgOrderDetials_ctl00_ctl04_lnkDetails")).Text;
               // driverobj.GetElement(lnk_purchasefirstitem).Click();
               // Thread.Sleep(3000);
               // driverobj.SwitchWindow("Purchase Details");
               //result= driverobj.WaitForElement(By.XPath("//h1[contains(.,'"+txtitem+"')]"));
               
               // driverobj.Close();
               // Thread.Sleep(3000);
               // driverobj.SwitchTo().Window(originalHandle);
         
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return txtitem;
        }


        private By lnk_purchasefirstitem = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");
        private By lbl_purchaseitemtitle = By.Id("TabMenu_ML_BASE_TAB_PurchaseDetails_FIELD:CNT_TITLE");
    }
}
