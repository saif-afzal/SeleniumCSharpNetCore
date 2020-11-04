using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class Products
    {
        private readonly IWebDriver driverobj;
        public Products(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateNewGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_createnewgoto);
                Thread.Sleep(1000);
                driverobj.GetElement(btn_createnewgoto).ClickWithSpace();
                Thread.Sleep(1000);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Populate_Product(string typeofproduct, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(producttitle);
                driverobj.GetElement(producttitle).Clear();
                driverobj.GetElement(producttitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Title"]+browserstr + 1 + typeofproduct);
                driverobj.GetElement(productdescription).Clear();
                driverobj.GetElement(productdescription).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Desc"] + 1 + typeofproduct);
                driverobj.GetElement(productkeyword).Clear();
                driverobj.GetElement(productkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Desc"] + 1 + typeofproduct);
                driverobj.GetElement(productshipping).Clear();
                driverobj.GetElement(productshipping).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["shipping"]);
                driverobj.GetElement(producthandling).Clear();
                driverobj.GetElement(producthandling).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["handling"]);
                driverobj.GetElement(productaddstock).Clear();
                driverobj.GetElement(productaddstock).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["stock"]);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool btncreateclick()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_create);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(Return_Feedback);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool updatecost()
        {
            bool actualresult = false;
            try
            {
                //string actualresult = string.Empty;
                //actualresult = driverobj.GetElement(Return_Feedback).Text.ToString();
              //  driverobj.GetElement(producteditcostbutton).ClickWithSpace();
                driverobj.ClickEleJs(producteditcostbutton);
                driverobj.WaitForElement(producteditcosttxt);
                driverobj.GetElement(producteditcosttxt).Clear();
                driverobj.GetElement(producteditcosttxt).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["cost"]);
                driverobj.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditCost_SaveDefaultCost']"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool checkinproduct()
        {
            bool actualresult = false;
            try
            {
                Thread.Sleep(4000);
                driverobj.WaitForElement(btn_checkin);
              // driverobj.GetElement(btn_checkin).Click();
               driverobj.ClickEleJs(btn_checkin);
             //   driverobj.GetElement(Return).ClickWithSpace();
                //commented due to bug of new window
                //driverobj.Close();
                //driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool clickreturn()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(Return);
                driverobj.GetElement(Return).ClickWithSpace();
                //commented due to bug of new window
                //driverobj.Close();
                //driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Click_lnkadvancesearch()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(lnk_advance_search);
             //   driverobj.GetElement(lnk_advance_search).ClickWithSpace();
                driverobj.ClickEleJs(lnk_advance_search);
                driverobj.WaitForElement(txt_search_title);
              
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Populate_advancesearch(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_search_title);
                driverobj.GetElement(txt_search_title).Clear();
                driverobj.GetElement(txt_search_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Title"]+browserstr + 1 + type);
                driverobj.GetElement(txt_search_desc).Clear();
                driverobj.GetElement(txt_search_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Desc"] + 1 + type);
                driverobj.GetElement(txt_search_keyword).Clear();
                driverobj.GetElement(txt_search_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Desc"] + 1 + type);
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_product["Title"]+browserstr + 1 + type + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Search(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.ClickEleJs(btn_search);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_product["Title"]+browserstr + 1 + type + "')]"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_product["Title"]+browserstr + 1 + type + "')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + type + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Title"]+browserstr + 1 + type);
                driverobj.WaitForElement(btn_search);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }


        public bool Click_Manage()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
              //  driverobj.GetElement(lnk_Manage).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
              
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_CheckOut()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
              //  driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//span[contains(.,'Check Out')]"));
                driverobj.WaitForElement(productdescription);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }
        public bool Click_save(string type,string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(productdescription);
                driverobj.GetElement(productdescription).Clear();
                driverobj.GetElement(productdescription).SendKeysWithSpace(ExtractDataExcel.MasterDic_product["Title"]+browserstr + 1 + type);
                driverobj.ClickEleJs(btn_save);
                driverobj.WaitForElement(lbl_return_feedback);
                Thread.Sleep(3000);
               // driverobj.GetElement(By.XPath("//span[contains(.,'Check In')]")).Click();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_addstock(string type)
        {
            bool actualresult = false;
            try
            {
               
                driverobj.WaitForElement(productaddstock);
                driverobj.GetElement(productaddstock).Clear();
                driverobj.GetElement(productaddstock).SendKeysWithSpace("2");
                int noofstock = 0;
                if (driverobj.GetElement(lbl_available_stock).Text != "0")
                {
                    noofstock = Convert.ToInt32(driverobj.GetElement(lbl_available_stock).Text);
                }
                driverobj.ClickEleJs(btn_save);
                driverobj.WaitForElement(lbl_return_feedback);
                if (noofstock + 2 == Convert.ToInt32(driverobj.GetElement(lbl_available_stock).Text))
                {
                    actualresult = true;
                }
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check In')]"));
               //driverobj.GetElement(By.XPath("//span[contains(.,'Check In')]")).Click();

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Click_Delete()
        {
            bool actualresult = false;
            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[2]"));
             //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[2]"));
                driverobj.WaitForElement(btn_delete_content);
             //   driverobj.GetElement(btn_delete_content).ClickAnchor();
                driverobj.ClickEleJs(btn_delete_content);
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }



        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By product_link = By.XPath("//a[contains(text(),'Products')]");
        private By producttitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_TITLE");
        private By productdescription = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_DESCRIPTION");
        private By productkeyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_KEYWORDS");
        private By productshipping = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_SHIPPING");
        private By producthandling = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_HANDLING");
        private By productaddstock = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_ADD_STOCK");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By producteditcostbutton = By.Id("ML.BASE.WF.EditCost");
        private By producteditcosttxt = By.Id("TabMenu_ML_BASE_TAB_EditCost_CCT_COST");
        private By productsavedefaultcost = By.Id("//input[@id='TabMenu_ML_BASE_TAB_EditCost_SaveDefaultCost']");
        private By lbl_available_stock = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_PRD_AVL_STOCK");
        private By Return_Feedback = By.XPath("//*[@id='ReturnFeedback']");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By Return = By.Id("Return");
        private By btn_checkin = By.Id("ML.BASE.WF.Checkin");
        private By lnk_advance_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_search_title = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE");
        private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION");
        private By txt_search_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_Manage = By.XPath("//a[contains(.,'Manage')]");
        private By chk_delete = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_Search_DeleteProductType_1_PRODUCT_TYPE_1_0_')]");
        private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");

    }
}
