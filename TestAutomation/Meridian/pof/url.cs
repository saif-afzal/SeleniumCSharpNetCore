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
    class url
    {
        private readonly IWebDriver driverobj;

        public url(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_AddUrl()
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(btn_addurl);
                driverobj.GetElement(btn_addurl).ClickAnchor();
                driverobj.WaitForElement(txt_url);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_nextnewUrl(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_url);
                driverobj.GetElement(txt_url).SendKeysWithSpace("http://testurl"+ExtractDataExcel.token_for_reg+browserstr);
                driverobj.GetElement(btn_next).ClickWithSpace();
                driverobj.WaitForElement(txt_welcometext);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_savenewUrl()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(cmb_announcementcount);
                driverobj.GetElement(cmb_announcementcount).SendKeysWithSpace("1");
                driverobj.WaitForElement(txt_welcometext);
                driverobj.GetElement(txt_welcometext).SendKeysWithSpace("test_welcometext");
               // $("[id^=lp-about]").prev('div').find('p').last().text("dfhuisfiusdfged");
           //     driverobj.GetElement(txt_abouttext).Click();
                driverobj.ClickEleJs(txt_abouttext);
                driverobj.GetElement(txt_abouttext).SendKeysWithSpace("About Us Tes");
              
               ((IJavaScriptExecutor)driverobj).ExecuteScript("$('[id^=lp-about]').prev('div').find('p').last().text('test privacy policy');");
            //   driverobj.GetElement(txt_abouttext).Click();
                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
              result= driverobj.existsElement(lbl_success);
              driverobj.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Update_Privacy(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "http://testurl" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + "http://testurl" + ExtractDataExcel.token_for_reg + browserstr + "')]")).ClickAnchor();
                driverobj.WaitForElement(tab_landingfooter);
                driverobj.GetElement(tab_landingfooter).ClickWithSpace();
                driverobj.WaitForElement(txt_privacy);
                driverobj.GetElement(txt_privacy).Click();
                //((IJavaScriptExecutor)driverobj).ExecuteScript(" $('[for^='lp-privacy-en-US']').prev('div').find('p').last().text('test privacy policy');");
                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
                result = driverobj.existsElement(lbl_success);
                driverobj.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Update_term(string browserstr)
        {
            bool result = false;

            try
            {
               driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "http://testurl" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + "http://testurl" + ExtractDataExcel.token_for_reg + browserstr + "')]")).ClickAnchor();
                driverobj.WaitForElement(tab_landingfooter);
                driverobj.GetElement(tab_landingfooter).ClickWithSpace();
                driverobj.WaitForElement(txt_terms);
                driverobj.GetElement(txt_terms).Click();
                ((IJavaScriptExecutor)driverobj).ExecuteScript(" $('[id^=lp-terms]').prev('div').find('p').last().text('test term and condition');");
                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
                result = driverobj.existsElement(lbl_success);
                driverobj.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_landingFooterText_tab()
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                Thread.Sleep(1000);
                driverobj.WaitForElement(tab_landingfooter);
                driverobj.GetElement(tab_landingfooter).ClickAnchor();
                driverobj.WaitForElement(txt_welcometxt);
                driverobj.SwitchtoDefaultContent();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Edit_aboutText(String aboutText)
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(lnk_EnglishUS);
                driverobj.GetElement(lnk_EnglishUS).ClickWithSpace();
                //driverobj.WaitForElement(txt_welcometxt);
                driverobj.SetDescription1(aboutText_htmleditor, aboutText_htmlcontrol, aboutText);
                driverobj.GetElement(btn_save).ClickWithSpace();
             result=   driverobj.existsElement(lbl_success);
                driverobj.SwitchtoDefaultContent();
               
                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Edit_privacyPolicy(String privacyPolicy)
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                Thread.Sleep(1000);
                driverobj.WaitForElement(lnk_EnglishUS);
                driverobj.GetElement(lnk_EnglishUS).ClickWithSpace();
                //driverobj.WaitForElement(txt_welcometxt);
                driverobj.SetDescription1(privacyPolicy_htmleditor, privacyPolicy_htmlcontrol, privacyPolicy);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.SwitchtoDefaultContent();
                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Edit_termsConditions(String termsConditions)
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(lnk_EnglishUS);
                driverobj.GetElement(lnk_EnglishUS).ClickWithSpace();
                //driverobj.WaitForElement(txt_welcometxt);
                driverobj.SetDescription1(termsConditions_htmleditor, termsConditions_htmlcontrol, termsConditions);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.SwitchtoDefaultContent();
                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Edit_welcomeMessage(String welcomeMessage)
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(lnk_EnglishUS);
                driverobj.GetElement(lnk_EnglishUS).ClickWithSpace();
                driverobj.WaitForElement(txt_welcomeMessage);
                driverobj.GetElement(txt_welcomeMessage).Clear();
                driverobj.GetElement(txt_welcomeMessage).SendKeysWithSpace(welcomeMessage);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.SwitchtoDefaultContent();
                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool select_url()
        {
            bool result = false;

            try
            {
                driverobj.waitforframe(By.Id("KIFrame"));
                driverobj.WaitForElement(lnk_url);
                driverobj.GetElement(lnk_url).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        private By lnk_url = By.XPath("//td[text()='Meridian Global - Core Domain']/preceding-sibling::td[1]/a");
        private By btn_addurl = By.XPath("//a[@class='btn btn-primary']");
        private By txt_url = By.Id("url");
        private By btn_next = By.Id("btnNext");
        private By cmb_announcementcount =By.Id("announcements-count");
        private By txt_welcometext = By.Id("lp-text-en-US");
        private By txt_abouttext = By.XPath(".//*[@id='en-US']/div[2]/div/div[2]/div/p");
        private By btn_save = By.Id("btnSaveAll");
        private By lbl_success = By.Id("saved-alert");
        private By txt_privacy = By.XPath(".//*[@id='en-US']/div[3]/div/div[2]/div/p");
        private By txt_terms = By.XPath(".//*[@id='en-US']/div[4]/div/div[2]/div/p");
        private By tab_landingfooter =By.XPath("//a[contains(.,'Landing and Footer Text')]");
        private By txt_welcometxt = By.Id("lp-text-es-ES");
        private By aboutText_htmleditor = By.XPath("//label[contains(text(),'About Text')]/following-sibling::div[1]/div[2]/div/p");
        private By aboutText_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By privacyPolicy_htmleditor = By.XPath("//label[contains(text(),'Privacy Policy Text')]/following-sibling::div[1]/div[2]/div/p");
        private By privacyPolicy_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By termsConditions_htmleditor = By.XPath("//label[contains(text(),'Terms of Use Text')]/following-sibling::div[1]/div[2]/div/p");
        private By termsConditions_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By txt_welcomeMessage = By.Id("lp-text-en-US");
        
        
        private By lnk_EnglishUS = By.XPath("//a[@aria-controls='en-US']");
       
        


    }
}
