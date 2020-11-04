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
    class JobTitles
    {
        private readonly IWebDriver driverobj;
        public JobTitles(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateNewGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_createnewgoto);
             //   driverobj.GetElement(btn_createnewgoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createnewgoto);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }


        public bool Click_Search(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_JobTitle["Name"]+browserstr);
                driverobj.ClickEleJs(btn_search);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_JobTitle["Name"]+browserstr + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool Click_AdvSearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_advsearch);
             //   driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                driverobj.WaitForElement(txt_searchtitle);
                driverobj.GetElement(txt_searchtitle).Clear();
                driverobj.GetElement(txt_searchtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_JobTitle["Name"]+browserstr);
                driverobj.GetElement(txt_searchdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_JobTitle["Desc"]);

                driverobj.ClickEleJs(btn_search);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_JobTitle["Name"]+browserstr + "')]"));

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

       
        public bool Click_ManageItem()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_manageitem);
                driverobj.ClickEleJs(btn_manageitem);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }



        public bool Click_SelectJobTitleToDelete()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_delete);
              //  driverobj.GetElement(chk_delete).Click();
                driverobj.ClickEleJs(chk_delete);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool Click_DeleteJobTitle()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_delete);
                driverobj.ClickEleJs(btn_delete);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");

        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_manageitem = By.Id("TabMenu_ML_BASE_TAB_Search_JOBTITLE_GoButton_1");

        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_searchtitle = By.Id("TabMenu_ML_BASE_TAB_Search_JBTTLLCL_TITLE");
        private By txt_searchdesc = By.Id("TabMenu_ML_BASE_TAB_Search_JBTTLLCL_DESCRIPTION");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By chk_delete = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_DeleteJobTitle_1_JOBTITLE_1_0_')]");
        private By btn_delete = By.Id("TabMenu_ML_BASE_TAB_Search_Delete");
    }
}
