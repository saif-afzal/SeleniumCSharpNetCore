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
    class ProductTypeUtil
    {
        private readonly IWebDriver driverobj;

        public ProductTypeUtil(IWebDriver driver)
        {
            driverobj = driver;
        }
        string stringtofind = "test_product_type_" + ExtractDataExcel.token_for_reg;
        public bool createproducttype()
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_Product_Types).Click();
                    driverobj.WaitForElement(btn_go);
                    driverobj.GetElement(btn_go).Click();
                    driverobj.WaitForElement(txt_create_title);
                    driverobj.GetElement(txt_create_title).Clear();
                    driverobj.GetElement(txt_create_title).SendKeys(stringtofind);
                    driverobj.GetElement(txt_create_desc).Clear();
                    driverobj.GetElement(txt_create_desc).SendKeys(stringtofind+"_desc");
                    driverobj.GetElement(btn_create).Click();
                    driverobj.WaitForElement(lbl_return_feedback);
                    driverobj.GetElement(btn_save).Click();
                    driverobj.WaitForElement(lbl_return_feedback);
                    driverobj.GetElement(btn_return).Click();
              
                Thread.Sleep(3000);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;

        }

        public bool ProductTypeAdvSearch()
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_Product_Types).Click();

                driverobj.GetElement(lnk_advance_search).Click();
                driverobj.WaitForElement(txt_search_title);
                driverobj.GetElement(txt_search_title).Clear();
                driverobj.GetElement(txt_search_title).SendKeys(stringtofind);
                driverobj.GetElement(txt_search_desc).Clear();
                driverobj.GetElement(txt_search_desc).SendKeys(stringtofind+"_desc");
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                driverobj.GetElement(btn_search).Click();

                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + stringtofind + "')]"));
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public void ProductTypesearch()
        {

            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_Product_Types).Click();
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeys(stringtofind);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                driverobj.GetElement(btn_search).Click();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + stringtofind + "')]"));
               // driverobj.GetElement(By.XPath("//a[contains(.,'" + stringtofind + "')]")).Click();

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

        }

        public bool ProductTypesimplesearch()
        {
            bool actualresult = false;
            try
            {
                ProductTypesearch();
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }


        public bool manageProductType()
        {
            bool actualresult = false;
            try
            {
                ProductTypesearch();
                driverobj.WaitForElement(btn_manage_go);
                driverobj.GetElement(btn_manage_go).Click();
                driverobj.WaitForElement(txt_create_desc);
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeys(stringtofind+"_managedesc");
                driverobj.GetElement(btn_save).Click();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool deleteProductType()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_delete_content);
                driverobj.GetElement(chk_delete).Click();
                driverobj.GetElement(btn_delete_content).Click();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_return_feedback);
                actualresult = true;


            }

            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
            return actualresult;

        }

        public bool DeleteProductType()
        {
            bool actualresult = false;
            try
            {
                ProductTypesearch();

                bool result = deleteProductType();

                if (result == true)
                {
                    driverobj.Close();
                    driverobj.SwitchTo().Window("");
                    Thread.Sleep(3000);
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        private By adminconsoleopenlink = By.Id("NavigationStrip1_lnkAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By lnk_Product_Types = By.LinkText("Product Types");
        private By btn_go = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_create_title = By.Id("TabMenu_ML_BASE_HEAD_EditProductType_PTL_TYPE_TITLE");
        private By txt_create_desc = By.Id("TabMenu_ML_BASE_HEAD_EditProductType_PTL_TYPE_DESCRIPTION");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        private By btn_return = By.Id("Return");
        private By lnk_advance_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_search_title = By.Id("TabMenu_ML_BASE_TAB_Search_PTL_TYPE_TITLE");
        private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_PTL_TYPE_DESCRIPTION");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_manage_go = By.Id("TabMenu_ML_BASE_TAB_Search_PRODUCT_TYPE_GoButton_1");
        private By chk_delete = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_Search_DeleteProductType_1_PRODUCT_TYPE_1_0_')]");
        private By btn_delete_content = By.Id("TabMenu_ML_BASE_TAB_Search_Delete");

    }
}
