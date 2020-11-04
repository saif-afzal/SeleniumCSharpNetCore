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
using System.Collections.ObjectModel;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class Productutil
    {
        private readonly IWebDriver driverobj;
        private TrainingHomes TrainingHomeobj;
        private AdminstrationConsole AdminstrationConsoleobj;
        public Productutil(IWebDriver driver)
        {
            driverobj = driver;
            TrainingHomeobj = new TrainingHomes(driver);
            AdminstrationConsoleobj = new AdminstrationConsole(driver);
        }

        public bool CreateProduct(int noofcourse, string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                TrainingHomeobj.isTrainingHome();
              //  TrainingHomeobj.lnk_SystemOptions_click();
              
              TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
                AdminstrationConsoleobj.Click_OpenItemLink("Products");
                for (int i = 1; i <= noofcourse; i++)
                {
                    driverobj.WaitForElement(btn_go);
                    driverobj.GetElement(btn_go).ClickWithSpace();
                    driverobj.WaitForElement(txt_create_title);
                    driverobj.GetElement(txt_create_title).Clear();
                    driverobj.GetElement(txt_create_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Title"] + browserstr + i + type);
                    driverobj.GetElement(txt_create_desc).Clear();
                    driverobj.GetElement(txt_create_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Desc"] + i + type);
                    driverobj.GetElement(txt_create_keyword).Clear();
                    driverobj.GetElement(txt_create_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Desc"] + i + type);
                    //driverobj.isPresentAndClick(By.Id(WebElementRepository.generalcoursenxtbtn));
                    driverobj.GetElement(txt_create_shipping).Clear();
                    driverobj.GetElement(txt_create_shipping).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["shipping"]);
                    driverobj.GetElement(txt_create_handling).Clear();
                    driverobj.GetElement(txt_create_handling).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["handling"]);
                    driverobj.GetElement(txt_create_add_stock).Clear();
                    driverobj.GetElement(txt_create_add_stock).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["stock"]);

                    driverobj.GetElement(btn_create).ClickWithSpace();
                    driverobj.WaitForElement(lbl_return_feedback);
                    driverobj.GetElement(btn_edit_cost).ClickWithSpace();
                    driverobj.WaitForElement(txt_edit_cost);
                    driverobj.GetElement(txt_edit_cost).Clear();
                    driverobj.GetElement(txt_edit_cost).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["cost"]);
                    driverobj.ClickEleJs(btn_save_default_cost);
                    Thread.Sleep(4000);
                    driverobj.WaitForElement(By.XPath("//span[contains(.,'Check In')]"));
                    driverobj.ClickEleJs(By.XPath("//span[contains(.,'Check In')]"));
                    driverobj.WaitForElement(btn_return);
                    driverobj.ClickEleJs(btn_return);

                }
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                actualresult = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool CreateSingleProduct(string title, string description, string keyword, string shipping, string handling, string stock)
        {
            bool actualresult = false;
            try
            {
                TrainingHomeobj.isTrainingHome();
                TrainingHomeobj.lnk_SystemOptions_click();
                TrainingHomeobj.lnk_ContentManagement_click();
                AdminstrationConsoleobj.Click_OpenItemLink("Products");

                driverobj.WaitForElement(btn_go);
                driverobj.GetElement(btn_go).ClickWithSpace();
                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeysWithSpace(title);
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeysWithSpace(description);
                driverobj.GetElement(txt_create_keyword).Clear();
                driverobj.GetElement(txt_create_keyword).SendKeysWithSpace(keyword);
                driverobj.GetElement(txt_create_shipping).Clear();
                driverobj.GetElement(txt_create_shipping).SendKeysWithSpace(shipping);
                driverobj.GetElement(txt_create_handling).Clear();
                driverobj.GetElement(txt_create_handling).SendKeysWithSpace(handling);
                driverobj.GetElement(txt_create_add_stock).Clear();
                driverobj.GetElement(txt_create_add_stock).SendKeysWithSpace(stock);

                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.GetElement(btn_edit_cost).ClickWithSpace();
                driverobj.WaitForElement(txt_edit_cost);
                driverobj.GetElement(txt_edit_cost).Clear();
                driverobj.GetElement(txt_edit_cost).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["cost"]);
                driverobj.GetElement(btn_save_default_cost).ClickWithSpace();
                Thread.Sleep(4000);
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check In')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Check In')]")).ClickWithSpace();
                driverobj.WaitForElement(btn_return);
                driverobj.GetElement(btn_return).ClickWithSpace();

                driverobj.Close();
                SwitchToLastWindow();
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }


        private void SwitchToLastWindow()
        {
            Thread.Sleep(1000);
            driverobj.SwitchTo().Window(driverobj.WindowHandles.Last());
            Thread.Sleep(1000);
        }

        public bool ProductAdvSearch(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_product).ClickAnchor();

                driverobj.GetElement(lnk_advance_search).Click();
                driverobj.WaitForElement(txt_search_title);
                driverobj.GetElement(txt_search_title).Clear();
                driverobj.GetElement(txt_search_title).SendKeys(ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + type);
                driverobj.GetElement(txt_search_desc).Clear();
                driverobj.GetElement(txt_search_desc).SendKeys(ExtractDataExcel.MasterDic_product["Desc"] + 1 + type);
                driverobj.GetElement(txt_search_keyword).Clear();
                driverobj.GetElement(txt_search_keyword).SendKeys(ExtractDataExcel.MasterDic_product["Desc"] + 1 + type);
                driverobj.GetElement(btn_search).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + type + "')]"));

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public void Productsearch(string type, string browserstr)
        {

            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_product).Click();
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeys(ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + type);
                driverobj.GetElement(btn_search).Click();

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + type + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + type + "')]")).Click();
                // driverobj.GetElement(By.XPath("//a[contains(.,'" + stringtofind + "')]")).Click();

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

        }

        public bool Productsimplesearch(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                Productsearch(type, browserstr);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }


        public bool manageProduct(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                Productsearch(type, browserstr);
                driverobj.WaitForElement(lnk_Manage);
                driverobj.GetElement(lnk_Manage).Click();
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).Click();
                driverobj.WaitForElement(txt_create_desc);
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeys(ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + type);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                Thread.Sleep(3000);
                driverobj.GetElement(By.XPath("//span[contains(.,'Check In')]")).Click();

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool addstock(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                Productsearch(type, browserstr);
                driverobj.WaitForElement(lnk_Manage);
                driverobj.GetElement(lnk_Manage).Click();
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).Click();
                driverobj.WaitForElement(txt_create_add_stock);
                driverobj.GetElement(txt_create_add_stock).Clear();
                driverobj.GetElement(txt_create_add_stock).SendKeys("2");
                int noofstock = 0;
                if (driverobj.GetElement(lbl_available_stock).Text != "0")
                {
                    noofstock = Convert.ToInt32(driverobj.GetElement(lbl_available_stock).Text);
                }
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                if (noofstock + 2 == Convert.ToInt32(driverobj.GetElement(lbl_available_stock).Text))
                {
                    actualresult = true;
                }
                driverobj.GetElement(By.XPath("//span[contains(.,'Check In')]")).Click();

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool deleteProduct()
        {
            bool actualresult = false;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.SwitchWindow("Delete Content");

                driverobj.WaitForElement(By.Id("0"));
                driverobj.GetElement(By.Id("0")).Click();
                Thread.Sleep(5000);
                driverobj.SwitchTo().Window(originalHandle);
                Thread.Sleep(5000);

                driverobj.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
                actualresult = true;


            }

            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;


        }
        public bool DeleteProduct(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                Productsearch(type, browserstr);

                bool result = deleteProduct();

                if (result == true)
                {
                    driverobj.Close();
                    driverobj.SwitchTo().Window("");
                    Thread.Sleep(3000);
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        //product

        private By adminconsoleopenlink = By.Id("NavigationStrip1_lnkAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By btn_go = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By lnk_product = By.XPath("//a[contains(text(),'Products')]");
        private By txt_create_title = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_TITLE");
        private By txt_create_desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_DESCRIPTION");
        private By txt_create_keyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_KEYWORDS");
        private By txt_create_shipping = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_SHIPPING");
        private By txt_create_handling = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_HANDLING");
        private By txt_create_add_stock = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_ADD_STOCK");
        private By lbl_available_stock = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_AVL_STOCK");
        private By btn_edit_cost = By.Id("ML.BASE.WF.EditCost");
        private By txt_edit_cost = By.Id("TabMenu_ML_BASE_TAB_EditCost_CCT_COST");
        private By btn_save_default_cost = By.Id("TabMenu_ML_BASE_TAB_EditCost_SaveDefaultCost");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        private By btn_return = By.Id("Return");
        private By btn_save = By.Id("ML.BASE.BTN.Save");

        private By lnk_advance_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_search_title = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE");
        private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION");
        private By txt_search_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_Manage = By.XPath("//a[contains(.,'Manage')]");
        private By chk_delete = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_Search_DeleteProductType_1_PRODUCT_TYPE_1_0_')]");
        private By btn_delete_content = By.Id("TabMenu_ML_BASE_TAB_Search_Delete");

    }
}
