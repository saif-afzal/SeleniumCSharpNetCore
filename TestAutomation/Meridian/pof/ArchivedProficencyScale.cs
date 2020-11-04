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
    class ArchivedProficencyScale
    {
        private readonly IWebDriver driverobj;

        public ArchivedProficencyScale(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Check_Items()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_firstitem);
                driverobj.WaitForElement(tbl_rating);
                driverobj.WaitForElement(btn_copy);
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
       
        string titletext = string.Empty;
        public bool Click_title()
        {
            bool actualresult = false;

            try
            {

                driverobj.WaitForElement(lnk_firstitem);
                titletext = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(lnk_firstitem).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.XPath("//h3[contains(.,'Rating scale for " + titletext + "')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(btn_contentclose);
                driverobj.GetElement(btn_contentclose).ClickWithSpace();
                actualresult = driverobj.existsElement(btn_info);
                
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return actualresult;
        }

        public bool Click_infoicon()
        {
            bool actualresult = false;

            try
            {

                driverobj.WaitForElement(btn_info);
                titletext = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(btn_info).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'" + titletext + "')]"));
                driverobj.WaitForElement(btn_infoclose);
                driverobj.GetElement(btn_infoclose).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
               actualresult = driverobj.existsElement(btn_copy);
                
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return actualresult;
        }
        public bool Click_Copy()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_copy);
                titletext = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(btn_copy).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'Copy of " + titletext + "')]"));
                if(driverobj.GetElement(txt_copyscaletitle).Text=="Copy of "+titletext)
                {
                    result = true;
                }
                driverobj.WaitForElement(btn_copyscalecancle);
                driverobj.WaitForElement(btn_copyscalesave);
                driverobj.GetElement(btn_copyscalesave).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                //driverobj.WaitForElement(btn_contentclose);
                //driverobj.GetElement(btn_contentclose).ClickWithSpace();
               result = driverobj.existsElement(lblsucess);
               
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
      
        private By lnk_firstitem = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_lblTitle");
        private By tbl_rating = By.XPath("//td[a[@id='ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_lblTitle']]/following-sibling::td[1]");

        private By btn_copy = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_btnCopyProficiencyScale");

        private By btn_info = By.XPath("//a[@id='ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_btnInfoProficiencyScale']");
       
        private By btn_contentclose = By.XPath("//span[@class='k-icon k-i-close']");
        private By btn_infoclose = By.Id("MainContent_UC1_MButton1");
        private By txt_copyscaletitle =By.Id("MainContent_UC1_PS_TITLE");
        private By btn_copyscalecancle = By.Id("MainContent_UC1_btnReturn");
        private By lblsucess = By.XPath("//div[@class='alert alert-success']");
     
        private By btn_copyscalesave = By.Id("MainContent_UC1_btnCopy");

    }
}
