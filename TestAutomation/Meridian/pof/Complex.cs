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
    class Complex
    {
        private readonly IWebDriver driverobj;

        public Complex(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_CreateGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_creategoto);
              //  driverobj.GetElement(btn_creategoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_creategoto);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Classroom Complex", driverobj);
            }

            return result;
        }

        public bool Click_Create(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_name);
                driverobj.GetElement(txt_name).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr);
                driverobj.GetElement(txt_desc).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr);
                driverobj.GetElement(txt_keyword).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr);
                driverobj.GetElement(btn_create).ClickWithSpace();
              result =  driverobj.existsElement(lbl_sucess);

                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_Search(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_search);
                driverobj.GetElement(txt_search).Clear();
                driverobj.GetElement(txt_search).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr);
                driverobj.GetElement(btn_search).ClickWithSpace();
               result = driverobj.existsElement(By.XPath("//td[contains(.,'" + Variables.classrommcomplexTitle+browserstr + "')]"));
                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        public bool Click_AdvSearchlink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_advsearch);
           //     driverobj.GetElement(lnk_advsearch).ClickWithSpace();
                driverobj.ClickEleJs(lnk_advsearch);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        public bool Click_AdvSearch(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_search_name);
                driverobj.GetElement(txt_search_name).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr);
                driverobj.GetElement(txt_search_desc).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr);
                driverobj.GetElement(txt_search_keyword).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr);
                driverobj.GetElement(btn_search).ClickWithSpace();
              result =  driverobj.existsElement(By.XPath("//td[contains(.,'" + Variables.classrommcomplexTitle+browserstr + "')]"));
                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj); driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Click_ManageGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_managegoto);
                driverobj.ClickEleJs(btn_managegoto);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        public bool Click_Save(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_desc);
                driverobj.GetElement(txt_desc).Clear();
                driverobj.GetElement(txt_desc).SendKeysWithSpace(Variables.classrommcomplexTitle+browserstr + "edit");
             //   driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.ClickEleJs(btn_save);
               result = driverobj.existsElement(lbl_sucess);

                
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
                driverobj.WaitForElement(chk_complex);
                //driverobj.GetElement(chk_complex).ClickWithSpace();
                driverobj.ClickEleJs(chk_complex);
                driverobj.WaitForElement(btn_delete);
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
        private By btn_creategoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_name = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CMPLX_NAME");
        private By txt_desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CMPLX_DESCRIPTION");
        private By txt_keyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CMPLX_KEYWORDS");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_sucess = By.XPath("//span[@id='ReturnFeedback']");
        private By txt_search = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_search_name = By.Id("TabMenu_ML_BASE_TAB_Search_CMPLX_NAME");
        private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_CMPLX_DESCRIPTION");
        private By txt_search_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_CMPLX_KEYWORDS");
        private By btn_managegoto = By.Id("TabMenu_ML_BASE_TAB_Search_ComplexSearch_ctl02_GoButton");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By chk_complex = By.Id("TabMenu_ML_BASE_TAB_Search_ComplexSearch_ctl02_DataGridItem_CMPLX_COMPLEX_ID");
        private By btn_delete = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Delete");



    }
}
