using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
using System.Collections.ObjectModel;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class ManageTaxRates
    {
        private readonly IWebDriver driverobj;
        public ManageTaxRates(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_AddNewTaxRate()
        {
            bool actualresult = false;
            try
            {
               // Thread.Sleep(6000);
                driverobj.waitforframe(By.Id("KIFrame"));
          //     driverobj.SelectFrame();
                driverobj.WaitForElement(btn_addnewtaxrate);
            //    driverobj.GetElement(btn_addnewtaxrate).ClickWithSpace();
                driverobj.ClickEleJs(btn_addnewtaxrate);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Populate_NewTaxRate()
        {
            bool actualresult = false;
            try
            {
                driverobj.waitforframe(By.ClassName("k-content-frame"));
             //   driverobj.SelectFrame();
                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace("test_taxcategory_" + ExtractDataExcel.token_for_reg);
                driverobj.getcomboitemselected(cmb_TaxTable,1);
                driverobj.WaitForElement(btn_AddTaxItenCatagery);
                driverobj.ClickEleJs(btn_AddTaxItenCatagery);
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("KIFrame"));
             //   driverobj.SelectFrame();
                actualresult = driverobj.existsElement(btn_addnewtaxrate);
                driverobj.SwitchTo().DefaultContent();
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_ManageTaxRate()
        {
            bool actualresult = false;
            Thread.Sleep(6000);
            int taxtablecount = 0;
            try
            {
              
                driverobj.waitforframe(By.Id("KIFrame"));
                if (driverobj.existsElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgTaxTables_ctl00']/tfoot/tr/td/div/div[2]/nav/ol/li[4]/a")))
                {
                    driverobj.ClickEleJs(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgTaxTables_ctl00']/tfoot/tr/td/div/div[2]/nav/ol/li[4]/a"));
                }
                //driverobj.SelectFrame();
                ReadOnlyCollection<IWebElement> managebtns = driverobj.FindElements(alltaxtable);// -1;
                if (driverobj.FindElements(alltaxtable).Count == 1)
                {
                    taxtablecount = 0;
                }
               
                // ShoppingCartUtilDriver.SelectFrame();
                //ShoppingCartUtilDriver.WaitForElement(By.Id("ctl00_MainContent_UC1_rgTaxTables_ctl00_ctl20_btnManageTaxRateTable"));
                driverobj.WaitForElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[1]/a"));
                driverobj.ClickEleJs(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[1]/a"));
                //managebtns[managebtns.Count - 1].Click();
                //driverobj.GetElement(By.XPath("//a[@href='EditSalesTaxRates.aspx?tid=" + taxtablecount + "']")).Click();
               // driverobj.SwitchTo().Frame(0);
                driverobj.WaitForElement(ManageTaxRateState);
                driverobj.getcomboitemselected(ManageTaxRateState,1);
                Thread.Sleep(3000);
                driverobj.WaitForElement(taxratetxt);
                driverobj.GetElement(taxratetxt).SendKeysWithSpace("5");
                driverobj.ClickEleJs(checkshippingtax);
                driverobj.GetElement(shippingtaxratetxt).SendKeysWithSpace("0");
                driverobj.ClickEleJs(addshippinforstatebtn);
                Thread.Sleep(4000);
                driverobj.SwitchTo().DefaultContent();
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }


        public bool Click_EditTaxRate()
        {
            bool actualresult = false;
            Thread.Sleep(6000);
            int taxtablecount = 0;
           
            try
            {
                
                driverobj.waitforframe(By.Id("KIFrame"));
                if (driverobj.existsElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgTaxTables_ctl00']/thead/tr[1]/td/div/div[2]/nav/ol/li[4]/a/span")))
                {
                    driverobj.ClickEleJs(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgTaxTables_ctl00']/thead/tr[1]/td/div/div[2]/nav/ol/li[4]/a/span"));
                }//driverobj.SelectFrame();
                ReadOnlyCollection<IWebElement> managebtns = driverobj.FindElements(alltaxtable);// -1;
                if (driverobj.FindElements(alltaxtable).Count == 1)
                {
                    taxtablecount = 0;
                }
                // ShoppingCartUtilDriver.SelectFrame();
                //ShoppingCartUtilDriver.WaitForElement(By.Id("ctl00_MainContent_UC1_rgTaxTables_ctl00_ctl20_btnManageTaxRateTable"));
                driverobj.WaitForElement(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[2]/input"));
                driverobj.ClickEleJs(By.XPath("//tr[@id = '" + ManageTaxTableBtn + taxtablecount.ToString() + "']/td[3]/ul/li[2]/input"));
                //managebtns[managebtns.Count - 1].Click();
                //driverobj.GetElement(By.XPath("//a[@href='EditSalesTaxRates.aspx?tid=" + taxtablecount + "']")).Click();
            //    driverobj.SelectFrame();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(txt_desc);
                driverobj.GetElement(txt_desc).SendKeysWithSpace("test");
                driverobj.ClickEleJs(btn_save);
                driverobj.waitforframe(By.Id("KIFrame"));
              //  driverobj.SwitchTo().DefaultContent();
          //      driverobj.SelectFrame();
                driverobj.WaitForElement(btn_addnewtaxrate);
                driverobj.SwitchTo().DefaultContent();
                actualresult = true;
            }
            catch (WebDriverTimeoutException)
            {
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(btn_addnewtaxrate);
                driverobj.SwitchTo().DefaultContent();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        private By btn_addnewtaxrate = By.Id("MainContent_UC1_btnAddNewTaxTable");
        private By txt_title = By.Id("MainContent_UC1_tbTaxTableTitle");
        private By cmb_TaxTable = By.Id("MainContent_UC1_ddlTaxItemCategories");
        private By btn_AddTaxItenCatagery = By.Id("MainContent_UC1_btnAddNewTaxTable");
        private By txt_desc = By.Id("MainContent_UC1_tbDescription");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_save = By.Id("MainContent_UC1_btnSave");
        private By alltaxtable = By.XPath("//a[contains(@id, '_btnManageTaxRateTable')]");// By.XPath("//tr['ctl00_MainContent_UC1_rgTaxTables_ctl00']/tbody/tr");
        private string ManageTaxTableBtn = "ctl00_MainContent_UC1_rgTaxTables_ctl00__";
        private By ManageTaxRateState = By.Id("MainContent_UC1_ADD_STATE_DLL");
        private By taxratetxt = By.Id("MainContent_UC1_tbDefaultTaxRate");
        private By checkshippingtax = By.Id("MainContent_UC1_cbTaxShipping");
        private By shippingtaxratetxt = By.Id("MainContent_UC1_tbShippingTaxRate");
        private By addshippinforstatebtn = By.Id("MainContent_UC1_btnAddStateAndCounties");
    }
}
