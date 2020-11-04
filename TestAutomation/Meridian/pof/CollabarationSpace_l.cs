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
    class CollabarationSpace_l
    {
        private readonly IWebDriver driverobj;
        public CollabarationSpace_l(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool IsCollabarationSpace()
        {
            bool actualresult = false;
            try
            {
               actualresult = driverobj.existsElement(lbl_CollabationSpace);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }


        public bool Click_ColSpaceItem()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_ColSpacefirstitem);
                driverobj.ClickEleJs(lnk_ColSpacefirstitem);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool IsColSpaceItemAccessed()
        {
            bool actualresult = false;
            try
            {
                driverobj.SelectFrame(By.Name("CFMain"));
                actualresult = driverobj.existsElement(By.XPath("//div[contains(@class,'axero-space-header-title-name')]"));
                driverobj.SwitchTo().DefaultContent();
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        private By lbl_CollabationSpace =By.XPath("//h2[contains(.,'Collaboration Spaces')]");
        private By lnk_ColSpacefirstitem = By.Id("ctl00_MainContent_UC1_rgCspace_ctl00_ctl04_lnkDetails");
        private By lbl_coltitle = By.ClassName("axero-space-header-title-name");
        
    }
}
