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
    class VirtualMeetings
    {
        private readonly IWebDriver driverobj;
        public VirtualMeetings(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_Button()
        {
            bool actualresult = false;
            
            if (driverobj.existsElement(By.XPath("//a[contains(.,'Add Connection')]")))
            {
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Add Connection')]"));


                actualresult = true;
            }
            
            else
            {
                By AddConnection_Button = By.XPath("//a[@class='right button primary']");
                try
                {
                    driverobj.WaitForElement(AddConnection_Button);
                    driverobj.ClickEleJs(AddConnection_Button);

                    actualresult = true;
                }

                catch (Exception ex)
                {
                    ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                }
                return actualresult;
            }

            return actualresult;
        }

        public bool Click_Button_Validate()
        {
            bool actualresult = false;
            
            try
            {
                driverobj.WaitForElement(btn_validate);

                driverobj.ClickEleJs(btn_validate);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }

        public bool Click_Button_Next()
        {
            bool actualresult = false;

            try
            {
                Thread.Sleep(4000);
                driverobj.WaitForElement(btn_next);
                driverobj.ClickEleJs(btn_next);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }

        public string Click_Button_Done()
        {
            string actualresult = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_done);

                driverobj.ClickEleJs(btn_done);

                actualresult = driverobj.gettextofelement(lbl_feedback);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }
        public bool Click_FrameLink(string linktext)
        {
            bool actualresult = false;
           
            By AdobeMeeting_Link = By.XPath("//a[text()='" + linktext + "']");
            By framedetect = By.CssSelector("div[id*='_create_connection']");
            try
            {
                //driverobj.FindElement(By.CssSelector("a[class='button primary']")).Click();
                Thread.Sleep(3000);
                //driverobj.WaitForElement(framedetect);
               // driverobj.WaitForElement(AdobeMeeting_Link);
                driverobj.ClickEleJs(AdobeMeeting_Link);
              

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }
        public bool PopulateAdobeMeetingsForm(string username, string password, string adobeurl)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_urlhost);
                driverobj.GetElement(txt_urlhost).SendKeysWithSpace(adobeurl);
                driverobj.GetElement(txt_username_Adobe).SendKeysWithSpace(username);
                driverobj.GetElement(txt_password_Adobe).SendKeysWithSpace(password);
               // driverobj.GetElement(chkbox_other).ClickWithSpace();
                driverobj.ClickEleJs(chkbox_other);
               // driverobj.GetElement(chkbox_voip).ClickWithSpace();
                driverobj.ClickEleJs(chkbox_voip);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }
        public bool PopulateGotomeetingMeetingsForm(string username, string password, string clientid)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_clientid);
                driverobj.GetElement(txt_clientid).SendKeysWithSpace(clientid);
                driverobj.GetElement(txt_username_Gtm).SendKeysWithSpace(username);
                driverobj.GetElement(txt_password_Gtm).SendKeysWithSpace(password);
                driverobj.ClickEleJs(chkbox_gtmaudio);
                driverobj.ClickEleJs(chkbox_gtmother);


                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }
        public bool PopulateGototrainingMeetingsForm(string username, string password, string clientid)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_clientid_GTT);
                driverobj.GetElement(txt_clientid_GTT).SendKeysWithSpace(clientid);
                driverobj.GetElement(txt_username_GTT).SendKeysWithSpace(username);
                driverobj.GetElement(txt_password_GTT).SendKeysWithSpace(password);


                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }
        public bool PopulateWebexMeetingsForm(string hosturl, string username, string password, string hostid, string partnerid)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_urlhost_Webex);
                driverobj.GetElement(txt_urlhost_Webex).SendKeysWithSpace(hosturl);
                driverobj.GetElement(txt_username_Webex).SendKeysWithSpace(username);
                driverobj.GetElement(txt_password_Webex).SendKeysWithSpace(password);
                driverobj.GetElement(txt_hostid_Webex).SendKeysWithSpace(hostid);
                driverobj.GetElement(txt_partnerid_Webex).SendKeysWithSpace(partnerid);
                driverobj.ClickEleJs(chkbox_webexaudio);
                driverobj.ClickEleJs(chkbox_webexother);
                driverobj.ClickEleJs(chkbox_webexnone);


                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }

        public bool PopulateConnectionName(string ConnectionName)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_connectionname);
                driverobj.GetElement(txt_connectionname).SendKeysWithSpace(ConnectionName);
              


                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
            }
            return actualresult;
        }
   

        private By txt_urlhost = By.XPath("//input[@id='adobe_hostUrl']");
        private By txt_urlhost_Webex = By.Id("webex_hostUrl");
        private By txt_hostid_Webex = By.Id("webex_hostid");
        private By txt_partnerid_Webex = By.Id("webex_partnerid");
        private By txt_clientid = By.Id("gtm_clientid");
        private By txt_clientid_GTT = By.Id("gtt_clientid");
        private By txt_username_Adobe = By.Id("adobe_username");
        private By txt_username_Gtm = By.Id("gtm_username");
        private By txt_username_GTT = By.Id("gtt_username");
        private By txt_username_Webex = By.Id("webex_username");
        private By AdobeMeeting_Link = By.XPath("//a[contains(.,'Adobe Connect')]");
        private By txt_password_Adobe = By.Id("adobe_password");
        private By txt_password_Gtm = By.Id("gtm_password");
        private By txt_password_GTT = By.Id("gtt_password");
        private By txt_password_Webex = By.Id("webex_password");

        private By btn_validate = By.Id("btnValidate");
        private By lbl_feedback = By.Id("connection-receipt");
        private By btn_next = By.Id("btnNext1");
        private By btn_done = By.Id("btnDone1");
        private By txt_connectionname = By.Id("connection_name");
        private By chkbox_other = By.XPath("//div[@id='AdobeContainer']/div/div[4]/div/ul/li/input");
        private By chkbox_voip = By.XPath("//div[@id='AdobeContainer']/div/div[4]/div/ul/li[2]/input");
        private By chkbox_webexaudio = By.XPath("//div[@id='WebExContainer']/div/div[6]/div/ul/li/input");
        private By chkbox_webexnone = By.XPath("//div[@id='WebExContainer']/div/div[6]/div/ul/li[2]/input");
        private By chkbox_webexother = By.XPath("//div[@id='WebExContainer']/div/div[6]/div/ul/li[3]/input");
        private By chkbox_gtmaudio = By.XPath("//div[@id='G2MContainer']/div/div[4]/div/ul/li/input");
        private By chkbox_gtmother = By.XPath("//div[@id='G2MContainer']/div/div[4]/div/ul/li[2]/input");
        

        
    }
}
