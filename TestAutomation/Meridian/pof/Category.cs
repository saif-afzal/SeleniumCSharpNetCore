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
using relativepath;

namespace Selenium2.Meridian
{
    class Category
    {
        private readonly IWebDriver driverobj;

        public Category(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_CreateGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_creategoto);
             //   driverobj.GetElement(btn_creategoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_creategoto);


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Category", driverobj);
            }

            return result;
        }
        public bool Click_Create(string type, string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_create);
                driverobj.GetElement(txt_title).Clear();
                driverobj.GetElement(txt_title).SendKeysWithSpace(Variables.category+browserstr);
                driverobj.GetElement(txt_desc).SendKeysWithSpace(Variables.category+browserstr);
           //     driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.ClickEleJs(btn_create);
               result = driverobj.existsElement(lbl_sucess);


               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_SearchCategories(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_search);
                driverobj.GetElement(txt_search).Clear();
                driverobj.GetElement(txt_search).SendKeysWithSpace(Variables.category+browserstr);
                //driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.ClickEleJs(btn_search);
                Thread.Sleep(3000);
               result = driverobj.existsElement(By.XPath("//td[contains(.,'" + Variables.category+browserstr + "')]"));


                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }


        public bool Click_ViewContent()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(cmb_viewcontent);
                driverobj.FindSelectElementnew(cmb_viewcontent, "View Content");
                driverobj.GetElement(btn_viewcontent).ClickWithSpace();
                Thread.Sleep(4000);
                driverobj.FindElement(By.XPath("//span[contains(.,'Records found: 1')]"));

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_Delete()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(chk_category);
              //  driverobj.GetElement(chk_category).ClickWithSpace();
                driverobj.ClickEleJs(chk_category);
                driverobj.GetElement(btn_delete).ClickWithSpace();
                driverobj.findandacceptalert();
               result = driverobj.existsElement(lbl_sucess);

                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By txt_title = By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE");
        private By txt_desc = By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_DESCRIPTION");
        private By btn_creategoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By lbl_sucess = By.XPath("//span[@id='ReturnFeedback']");
        private By txt_search = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By cmb_viewcontent = By.Id("TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_ActionsMenu");
        private By btn_viewcontent = By.Id("TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_GoButton");
        private By chk_category = By.Id("TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_DataGridItem_CTGY_CATEGORY_ID");
        private By btn_delete = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Delete");

    }
}
