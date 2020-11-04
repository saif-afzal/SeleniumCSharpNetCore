using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium2.Meridian;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Utility;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class Purchaseutil
    {
          private readonly IWebDriver driverobj;
          
          public Purchaseutil(IWebDriver driver)
        {
            driverobj = driver;
        }
          public void AddAccountCodes(string browserstr)
          {
              try
              {
                  driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                  driverobj.selectWindow(ObjectRepository.adminwindowtitle);
              driverobj.WaitForElement(By.LinkText("Account Codes"));
              driverobj.GetElement(By.LinkText("Account Codes")).Click();
              driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys("AC062314"/*"Account Code for Everyone"*/);
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
              driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ACCT_CODE_GoButton_1"));
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ACCT_CODE_GoButton_1")).Click();
              driverobj.WaitForElement(By.XPath("//a[@id='ML.BASE.WF.EditUserPermissions']/span"));
              driverobj.GetElement(By.XPath("//a[@id='ML.BASE.WF.EditUserPermissions']/span")).Click();
              driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditPermissions_GoPageActionsMenu"));
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditPermissions_GoPageActionsMenu")).Click();
              driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_SearchRole"));
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_SearchRole")).Clear();
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_SearchRole")).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr);
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_ML.BASE.BTN.Search")).Click();
              driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_ContentExistingUsers_ctl02_ML.BASE.PERM.VIEW"));
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_ContentExistingUsers_ctl02_ML.BASE.PERM.VIEW")).Click();
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_ContentExistingUsers_ctl02_ML.BASE.PERM.MANAGE")).Click();
              driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignUsers_btnAdd")).Click();
              driverobj.WaitForElement(returnfeedback);
              driverobj.Close();
              driverobj.SwitchTo().Window("");
              Thread.Sleep(4000);
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);



              }

          }

          public void AccountCodeCheckout()
          {
              try
              {
  //                driverobj.WaitForElement(By.Id("MainContent_UC1_btnCheckout"));
  //                driverobj.GetElement(By.Id("MainContent_UC1_btnCheckout")).Click();
  //             if(driverobj.WaitForElement(By.Id("MainContent_UC1_paymentmethod")))
  //             {
  //driverobj.GetElement(By.Id("MainContent_UC1_paymentmethod")).ClickAnchor();
  //             }
                
  //            driverobj.WaitForElement(By.Id("MainContent_UC1_fvPaymentInfo_PMTACCOUNTCODE_0"));
  //            driverobj.GetElement(By.Id("MainContent_UC1_fvPaymentInfo_PMTACCOUNTCODE_0")).Click();
  //            driverobj.GetElement(By.Id("MainContent_UC1_Checkout")).Click();

              driverobj.WaitForElement(By.Id("cbAgreeToTerms"));
              driverobj.GetElement(By.Id("cbAgreeToTerms")).Click();
              driverobj.GetElement(By.Id("MainContent_UC1_btnPlaceOrder")).Click();
              driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
               }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);



              }
          }
          string purchaseitem = string.Empty;
          public bool ClickPurchaseHistory()
          {
              try{
              driverobj.OpenToolbarItems(LinkMyAccount);
              driverobj.WaitForElement(By.Id("MainContent_ucAddlLinksMyPurchases_lnkMyPurchases"));
              driverobj.GetElement(By.Id("MainContent_ucAddlLinksMyPurchases_lnkMyPurchases")).Click() ;
              driverobj.WaitForElement(By.XPath("//a[contains(.,'" +purchaseitem+"1" + "')]"));
              return true;
               }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);


                  return false;
              }
          
          }

          public bool View_PurchaseHistoryDetail()
          {
              bool result = false;
              try
              {
              
              
              string originalHandle = driverobj.CurrentWindowHandle;
              driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkPurchaseDetails")).Click() ;
              Thread.Sleep(3000);
              driverobj.SwitchWindow("Purchase Details");
             string purchaseitemtoshow= driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_PurchaseDetails_FIELD:CNT_TITLE")).Text;
              driverobj.Close();
              Thread.Sleep(3000);
              driverobj.SwitchTo().Window(originalHandle);
              if (purchaseitem+"1" == purchaseitemtoshow)
              {
                  result = true;
              }
               }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              }
              return result;
          }
          private By returnfeedback = By.XPath("//span[@id='ReturnFeedback']");
          private By LinkMyAccount = By.XPath("//a[normalize-space()='Account']");

    }
}
