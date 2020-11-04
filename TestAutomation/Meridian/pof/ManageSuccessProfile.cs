using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class ManageSuccessProfile
    {
        private readonly IWebDriver driverobj;

        public ManageSuccessProfile(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_SearchProfile(string title)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(title);
                driverobj.WaitForElement(cmb_searchtype);
                driverobj.WaitForElement(btn_clearfilter);
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'"+title+"')]"));

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Check_Items()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(chk_firstitem);
                driverobj.WaitForElement(btn_createnewsucessprofile);
                driverobj.WaitForElement(btn_delete);
                driverobj.WaitForElement(btn_edit);
                driverobj.WaitForElement(btn_info);

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
      

     

        public bool Click_Delete()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(chk_firstitem);

             //   driverobj.GetElement(chk_firstitem).Click();
                driverobj.ClickEleJs(chk_firstitem);
               
                driverobj.GetElement(btn_delete).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lblsucess);
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

      

        private By txt_searchfor = By.Id("MainContent_UC1_SearchFor");
        private By cmb_searchtype = By.Id("MainContent_UC1_SearchType");
        private By btn_search = By.Id("btnSearchIdp");
        private By btn_clearfilter = By.Id("lbtnClearFilter");
        private By chk_firstitem = By.Id("ctl00_MainContent_UC1_rgSuccessProfile_ctl00_ctl04_chkRemove");
        private By btn_delete = By.Id("MainContent_UC1_btnRemove");
        private By btn_edit = By.Id("ctl00_MainContent_UC1_rgSuccessProfile_ctl00_ctl04_btnEditProficiencyScale");
        private By btn_createnewsucessprofile = By.Id("MainContent_UC1_btnCreateLetterhead");
        private By btn_info = By.Id("ctl00_MainContent_UC1_rgSuccessProfile_ctl00_ctl04_MImageButton2");

        private By lblsucess = By.XPath("//div[@class='alert alert-success']");
       
     
    }
}
