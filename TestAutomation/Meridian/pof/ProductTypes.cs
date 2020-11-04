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
    class ProductTypes
    {
        private readonly IWebDriver driverobj;

        public ProductTypes(IWebDriver driver)
        {
            driverobj = driver;
        }
        string stringtofind = "test_product_type_" + ExtractDataExcel.token_for_reg;

        public bool Click_GoToButton()
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(btn_go);
                driverobj.GetElement(btn_go).ClickWithSpace();
                driverobj.WaitForElement(txt_create_title);
                actualresults = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }
        public bool Populate_ProductType()
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeysWithSpace(stringtofind);
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeysWithSpace(stringtofind + "_desc");
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.GetElement(btn_return).ClickWithSpace();
                actualresults = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }

        public bool Click_lnkadvancesearch()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_advance_search);
            //    driverobj.GetElement(lnk_advance_search).ClickWithSpace();
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

        public bool Populate_advancesearch()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_search_title);
                driverobj.GetElement(txt_search_title).Clear();
                driverobj.GetElement(txt_search_title).SendKeysWithSpace(stringtofind);
                driverobj.GetElement(txt_search_desc).Clear();
                driverobj.GetElement(txt_search_desc).SendKeysWithSpace(stringtofind + "_desc");
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Search(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_search);
                driverobj.GetElement(btn_search).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + stringtofind + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(stringtofind);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
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
                driverobj.WaitForElement(btn_manage_go);
              //  driverobj.GetElement(btn_manage_go).ClickWithSpace();
                driverobj.ClickEleJs(btn_manage_go);
                driverobj.WaitForElement(txt_create_desc);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_save()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_create_desc);
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeysWithSpace(stringtofind + "_managedesc");
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                actualresult = true;
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
                driverobj.WaitForElement(btn_delete_content);
              //  driverobj.GetElement(chk_delete).ClickWithSpace();
                driverobj.ClickEleJs(chk_delete);
                driverobj.GetElement(btn_delete_content).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_return_feedback);
                actualresult = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

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
