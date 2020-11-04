using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class MappedContent
    {
        private readonly IWebDriver driverobj;

        public MappedContent(IWebDriver driver)
        {
            driverobj = driver;
        }

        // certification/curriculum on training catalog
        public bool Click_MapContent()
        {
            try
            {
                driverobj.WaitForElement(btn_mapcontent);
                driverobj.GetElement(btn_mapcontent).ClickWithSpace();
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                return false;
            }
            return true;
        }

        public bool Click_search()
        {
            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.WaitForElement(cmb_searchtype);
                driverobj.GetElement(btn_search).ClickWithSpace();
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                return false;
            }
            return true;
        }
        public bool Click_AddContent()
        {
            try
            {
                
                driverobj.WaitForElement(chk_firstitemtomap);
              //  driverobj.GetElement(chk_firstitemtomap).ClickWithSpace();
                driverobj.ClickEleJs(chk_firstitemtomap);
                driverobj.WaitForElement(btn_return);
                driverobj.WaitForElement(btn_add);
                driverobj.GetElement(btn_add).ClickWithSpace();
                driverobj.WaitForElement(lbl_sucess);
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                return false;
            }
            return true;
        }

        private By btn_mapcontent = By.Id("MainContent_MainContent_UC1_btnMapContent");
        private By txt_searchfor = By.Id("MainContent_MainContent_UC1_SearchFor");
        private By cmb_searchtype = By.Id("MainContent_MainContent_UC1_SearchType");
        private By btn_search = By.Id("btnSearchCourses");
        private By chk_firstitemtomap = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCompetency_ctl00_ctl04_chkAdd");
        private By btn_return = By.Id("MainContent_MainContent_UC1_btnReturn");
        private By btn_add = By.Id("MainContent_MainContent_UC1_btnAdd");
        private By lbl_sucess = By.XPath("//div[@class='alert alert-success']");


    }
}
