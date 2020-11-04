using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
using System;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class ExternalLearningSearch
    {
        private readonly IWebDriver driverobj;
        public ExternalLearningSearch(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_SearchEl(string searchtext)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(searchtext);
                driverobj.GetElement(btn_searchfor).ClickWithSpace();
                driverobj.WaitForElement(lnk_firstitem);
                driverobj.WaitForElement(lnk_seconditem);

                actualresult = true;
            }
            catch (Exception e)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }

        public string Click_Elfirstitem()
        {

            try
            {

                driverobj.WaitForElement(lnk_firstitem);
                string itemfound = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(lnk_firstitem).ClickWithSpace();

                return itemfound;
            }
            catch (Exception e)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return "";
            }

        }

        public string Click_Elseconditem()
        {

            try
            {

                driverobj.WaitForElement(lnk_seconditem);
                string itemfound = driverobj.GetElement(lnk_seconditem).Text;
                driverobj.GetElement(lnk_seconditem).ClickWithSpace();
                return itemfound;
            }
            catch (Exception e)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return "";
            }

        }

        private By txt_searchfor = By.Id("MainContent_UC1_txtSearchFor");
        private By btn_searchfor = By.Id("MainContent_UC1_btnSearch");
        private By lnk_firstitem = By.Id("ctl00_MainContent_UC1_rlvSearchResults_ctrl0_lnkDetails");
        private By lnk_seconditem = By.Id("ctl00_MainContent_UC1_rlvSearchResults_ctrl1_lnkDetails");

    }
}
