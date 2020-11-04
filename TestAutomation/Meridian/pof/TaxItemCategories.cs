using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
using System.Collections.ObjectModel;
using System.Configuration;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class TaxItemCategories
    {
        private readonly IWebDriver driverobj;
        public TaxItemCategories(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_AddNewTaxRate()
        {
            bool actualresult = false;
            try
            {
               // driverobj.waitforframe(By.Id("KIFrame"));
              //  driverobj.SelectFrame();
                driverobj.WaitForElement(btn_addnewtaxitem);
             //   driverobj.GetElement(btn_addnewtaxitem).ClickWithSpace();
                driverobj.ClickEleJs(btn_addnewtaxitem);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Populate_NewTaxItem()
        {
            bool actualresult = false;
            try
            {
                
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                // driverobj.SelectFrame();
                Thread.Sleep(10);
                driverobj.WaitForElement(btn_AddTaxItenCatagery);
                driverobj.ClickEleJs(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace("test_taxcategory_" + ExtractDataExcel.token_for_reg);
                driverobj.getcomboitemselected(cmb_TaxTable,1);
                driverobj.ClickEleJs(btn_AddTaxItenCatagery);
                driverobj.SwitchTo().DefaultContent();

              //  driverobj.waitforframe(By.Id("KIFrame"));
                actualresult = driverobj.existsElement(btn_addnewtaxitem);
            //    driverobj.SwitchTo().DefaultContent();
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
    


        public bool Click_ManageTaxItem()
        {
            bool actualresult = false;
            Thread.Sleep(6000);
            int taxtablecount = 0;

            try
            {
             //   driverobj.waitforframe(By.Id("KIFrame"));
             //   driverobj.SelectFrame();
                ReadOnlyCollection<IWebElement> managebtns = driverobj.FindElements(alltaxtable);// -1;
                if (driverobj.FindElements(alltaxtable).Count == 1)
                {
                    taxtablecount = 0;
                }
                // ShoppingCartUtilDriver.SelectFrame();
                //ShoppingCartUtilDriver.WaitForElement(By.Id("ctl00_MainContent_UC1_rgTaxTables_ctl00_ctl20_btnManageTaxRateTable"));
                driverobj.WaitForElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[1]/input"));
                driverobj.ClickEleJs(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[1]/input"));
                //managebtns[managebtns.Count - 1].Click();
                //driverobj.GetElement(By.XPath("//a[@href='EditSalesTaxRates.aspx?tid=" + taxtablecount + "']")).Click();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
               // driverobj.SelectFrame();
                driverobj.WaitForElement(txt_desc);
                driverobj.GetElement(txt_desc).SendKeysWithSpace("test");
                driverobj.getcomboitemselected(cmb_TaxTable, 1);
                driverobj.ClickEleJs(btn_save);
                Thread.Sleep(4000);
             
               //     driverobj.SwitchTo().DefaultContent();
              
              //  driverobj.waitforframe(By.Id("KIFrame"));
               // driverobj.SelectFrame();
                driverobj.WaitForElement(btn_addnewtaxitem);
                driverobj.SwitchTo().DefaultContent();
                actualresult = true;
            }
                catch(WebDriverTimeoutException)
            {
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(btn_addnewtaxitem);
                driverobj.SwitchTo().DefaultContent();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }


        public bool Click_DeleteTaxItem()
        {
            bool actualresult = false;
            Thread.Sleep(6000);
            int taxtablecount = 0;
            try
            {
         ////       driverobj.waitforframe(By.Id("KIFrame"));
         //   //    driverobj.SelectFrame(); 
         //       ReadOnlyCollection<IWebElement> managebtns = driverobj.FindElements(alltaxtable);// -1;
         //       if (driverobj.FindElements(alltaxtable).Count == 1)
         //       {
         //           taxtablecount = 0;
         //       }
         //       driverobj.WaitForElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[1]/input"));
         //       driverobj.GetElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[1]/input")).ClickWithSpace();
         //       driverobj.waitforframe(By.ClassName("k-content-frame"));
         //      // driverobj.SelectFrame();
         //       driverobj.WaitForElement(txt_desc);
         //       driverobj.getcomboitemselected(cmb_TaxTable, 0);
         //       driverobj.ClickEleJs(btn_save);
         //       Thread.Sleep(4000);
         // //      driverobj.SwitchTo().DefaultContent();
             
         //  //     driverobj.waitforframe(By.Id("KIFrame"));
         //     //  driverobj.SelectFrame();
         //       driverobj.WaitForElement(btn_addnewtaxitem);




                driverobj.WaitForElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[2]/input"));
                driverobj.ClickEleJs(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[2]/input"));
                driverobj.findandacceptalert();
                driverobj.WaitForElement(By.XPath("//*[contains(@class,'alert alert-success')]"));
                driverobj.SwitchTo().DefaultContent();
                
                actualresult = true;

            }
            catch (WebDriverTimeoutException)
            {
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(btn_addnewtaxitem);




                driverobj.WaitForElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[2]/input"));
                driverobj.GetElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[2]/input")).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
                driverobj.SwitchTo().DefaultContent();

                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        private By btn_addnewtaxitem = By.Id("MainContent_UC1_btnAddFirstTaxItemCategory");
        private By txt_title = By.Id("MainContent_UC1_tbTaxItemCategoryTitle");
        private By cmb_TaxTable = By.Id("MainContent_UC1_ddlTaxTables");
        private By btn_AddTaxItenCatagery = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        private By txt_desc = By.Id("MainContent_UC1_tbDescription");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_save = By.Id("MainContent_UC1_btnAssignTaxTable");
        private By alltaxtable = By.XPath("//a[contains(@id, '_btnAssignTaxTable')]");// By.XPath("//tr['ctl00_MainContent_UC1_rgTaxTables_ctl00']/tbody/tr");
        private string ManageTaxTableBtn = "ctl00_MainContent_UC1_rgTaxItemCategory_ctl00__";
        private By ManageTaxRateState = By.Id("MainContent_UC1_ADD_STATE_DLL");
        private By taxratetxt = By.Id("MainContent_UC1_tbDefaultTaxRate");
        private By checkshippingtax = By.Id("MainContent_UC1_cbTaxShipping");
        private By shippingtaxratetxt = By.Id("MainContent_UC1_tbShippingTaxRate");
        private By addshippinforstatebtn = By.Id("MainContent_UC1_btnAddStateAndCounties");
    }
}
