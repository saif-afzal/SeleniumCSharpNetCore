using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class SelectProfile
    {
        private readonly IWebDriver driverobj;
        public SelectProfile(IWebDriver driver)
        {
            driverobj = driver;
        }
        


        public bool Click_SearchProfile(string profilename)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_searchprofile);
                driverobj.GetElement(txt_searchprofile).SendKeysWithSpace(profilename);
             //   driverobj.GetElement(btn_searchprofile).ClickWithSpace();
                driverobj.ClickEleJs(btn_searchprofile);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SelectProfile()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(rb_selectprofile);
               // driverobj.GetElement(rb_selectprofile).Click();
                driverobj.ClickEleJs(rb_selectprofile);
                driverobj.GetElement(btn_selectprofile).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }



      
        private By txt_searchprofile = By.Id("TabMenu_ML_BASE_TAB_SelectProfile_SearchFor");
        private By btn_searchprofile = By.Id("TabMenu_ML_BASE_TAB_SelectProfile_ML.BASE.BTN.Search");
        private By rb_selectprofile = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_SelectProfile_SelectTrainingProfile_1_TrainingProfileSearch_1_0_')]");
        private By btn_selectprofile = By.Id("TabMenu_ML_BASE_TAB_SelectProfile_Select");
    }
}
