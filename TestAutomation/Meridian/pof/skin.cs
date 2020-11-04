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
using OpenQA.Selenium.Remote;
namespace Selenium2.Meridian
{
    class skin
    {
        private readonly IWebDriver driverobj;

        public skin(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_creategoto()
        {
            bool result = false;

            try
            {
                
                driverobj.WaitForElement(btn_creategoto);
                driverobj.GetElement(btn_creategoto).ClickWithSpace();
                driverobj.WaitForElement(txt_title);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_Createnewskin(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace("testskin" + ExtractDataExcel.token_for_reg + browserstr);
                uploadfile();
                driverobj.GetElement(btn_save).ClickWithSpace();
              result= driverobj.existsElement(lbl_success);

               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool uploadfile()
        {
            bool result = false;
            RelativeDirectory rd = new RelativeDirectory();
            try
            {
                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)driverobj;
                if (allowsDetection != null)
                {
                    allowsDetection.FileDetector = new LocalFileDetector();

                }
                Thread.Sleep(3000);
                string path = rd.Up(2) + "\\Data\\Skin.zip";
                Thread.Sleep(4000);
                driverobj.GetElement(btn_upload).SendKeys(path);
                Thread.Sleep(4000);
                result = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return result;
        }
          public bool Click_tabShare()
        {
            bool result = false;

            try
            {
                
                driverobj.WaitForElement(lnk_sharing);
                driverobj.GetElement(lnk_sharing).ClickAnchor();
                driverobj.WaitForElement(rb_sharing);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
          public bool Click_btnShare(string browserstr)
        {
            bool result = false;

            try
            {
                
                driverobj.WaitForElement(rb_sharing);
                driverobj.GetElement(rb_sharing).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(text(),'" + "testdomain" + ExtractDataExcel.token_for_reg + browserstr + "')]/following-sibling::td[6]/span/input"));
                driverobj.GetElement(By.XPath("//td[contains(text(),'" + "testdomain" + ExtractDataExcel.token_for_reg + browserstr + "')]/following-sibling::td[6]/span/input")).ClickChkBox();
              result= driverobj.existsElement(lbl_success);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        private By btn_creategoto = By.Id("TabMenu_ML_BASE_WF_Skins_GoPageActionsMenu");
        private By txt_title = By.Id("TabMenu_ML_BASE_UploadSkins_CSL_SKIN_TITLE");
        private By btn_upload = By.XPath("//input[@id='TabMenu_ML_BASE_UploadSkins_CSS_FILE']");
       
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By lbl_success =By.XPath("//span[@id='ReturnFeedback']");
        private By lnk_sharing =By.XPath("//span[contains(.,'Sharing')]");
        private By rb_sharing = By.XPath("//input[@id='TabMenu_ML_BASE_TAB_DomainContentSharing_CONTENT_SHARED']");

        


    }
}
