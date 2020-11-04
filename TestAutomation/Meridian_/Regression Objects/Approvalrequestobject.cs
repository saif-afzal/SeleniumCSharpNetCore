using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

using relativepath;
using System.Collections.ObjectModel;
using System.Reflection;
namespace Selenium2.Meridian
{
    class Approvalrequestobject
    {
        private readonly IWebDriver driverobj;
        public Approvalrequestobject(IWebDriver driver)
        {
            driverobj = driver;
        }
        public void linkapprovalrequestclick()
        {

            try
            {
                driverobj.GetElement(By.XPath("//a[contains(.,'Approval Requests')]"));
                driverobj.WaitForElement(ObjectRepository.accessapprovalawaitingmyapprovaltab);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Approval Request Link", driverobj);
                

            }

        }
        public void linkmyownlearningclick()
        {

            try
            {
                driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a")); 
              //  driverobj.WaitForElement(ObjectRepository.traininghomesearchtext);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void buttonaccessapprovaleditclick()
        {

            try
            {
            //    driverobj.ScrollToCoordinated("500", "500");
                driverobj.ClickEleJs(ObjectRepository.contentaccessapprovaleditbutton);
                
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovalradiobutton);
                driverobj.ClickEleJs(ObjectRepository.manageaccessapprovalradiobutton);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void populatemanageaccessapprovalframe(string searchapproval,string filtertext)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovalsearchtxtbox);
                driverobj.ClickEleJs(ObjectRepository.manageaccessapprovalsearchtxtbox);
                driverobj.GetElement(ObjectRepository.manageaccessapprovalsearchtxtbox).SendKeysWithSpace(searchapproval);
                driverobj.FindSelectElementnew(ObjectRepository.manageaccessapprovalfiltercombobox,filtertext);
                driverobj.ClickEleJs(ObjectRepository.manageaccessapprovalradiobutton);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void buttonaccessapprovalsearchclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.manageaccessapprovalsearchbutton);
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovaltableresultradiobutton);
                
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void radioaccessapprovalresultclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.manageaccessapprovaltableresultradiobutton);
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovaltsavebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string buttonaccessapprovalsaveclick()
        {
            string result = string.Empty;

            try
            {
                driverobj.ClickEleJs(ObjectRepository.manageaccessapprovaltsavebutton);
                driverobj.WaitForElement(ObjectRepository.contentaccessapprovalsuccessmessage);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
          return  result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public void buttonrequestaccessapprovalclick()
        {
        

            try
            {
                driverobj.ClickEleJs(ObjectRepository.detailsRequestaccessbutton);
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}
         
        }
        public string buttonrequestaccessapprovalframeclick()
        {
            string result = string.Empty;

            try
            {
                driverobj.ClickEleJs(ObjectRepository.accessapprovalrequestaccessbutton);
                driverobj.WaitForElement(ObjectRepository.detailsaccessapprovalsuccessmessage);
                result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);return "";
            }

        }
        public void populatefindrequest(string coursetitle)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalfindarequesttxtbox).SendKeysWithSpace(coursetitle);
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequestsearchbutton);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string buttonaccessapprovalfiltersearch()
        {
            string result = string.Empty;

            try
            {
                driverobj.ClickEleJs(ObjectRepository.accessapprovalfindarequestsearchbutton);
                driverobj.WaitForElement(ObjectRepository.accessapprovaltableresultstitlelink);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.accessapprovaltableresultstitlelink).Text;
        }
        public void buttonraccessapprovaldenyclick()
        {


            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovaldenybutton).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.accessapprovaldenyframebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string buttonraccessapprovaldenyframeclick()
        {

            string result = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovaldenyframebutton).Click();
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequestsearchbutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public void buttonraccessapprovalrescindclick()
        {


            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalrescindbutton).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.accessapprovalrescindframebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
               

            }

        }
        public string buttonraccessapprovalrescindframeclick()
        {

            string result = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalrescindframebutton).Click();
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequestsearchbutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public void buttonrmostrecentrequestsaccessapprovalclick()
        {


            try
            {
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesmostrecentrequestsapprovebutton);
               // driverobj.SelectFrame();
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                driverobj.WaitForElement(ObjectRepository.accessapprovalapproveframebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string buttonmostrecentrequestaccessapprovalframeclick()
        {

            string result = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalapproveframebutton).Click();
              //  driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestsapprovebutton);
                driverobj.WaitForElement(ObjectRepository.contentaccessapprovalsuccessmessage);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public void buttonrmostrecentrequestdenyclick()
        {


            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestsdenybutton);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesmostrecentrequestsdenybutton);
               // driverobj.SelectFrame();
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                driverobj.WaitForElement(ObjectRepository.accessapprovaldenyframebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string buttonmostrecentrequestdenyframeclick()
        {

            string result = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovaldenyframebutton).Click();
               // driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestsdenybutton);
                driverobj.WaitForElement(ObjectRepository.contentaccessapprovalsuccessmessage);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public string buttonrmostrecentrequestsviewallrequestsclick()
        {
            string result = string.Empty;

            try
            {
                //driverobj.ScrollToCoordinated("500", "500");
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestsviewallrequestsbutton);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesmostrecentrequestsviewallrequestsbutton);
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequestsearchbutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
                result = driverobj.Title;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);return "";
            }
            return result;

        }
        public void buttonraccessapprovalclick()
        {


            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalapprovebutton).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.accessapprovalapproveframebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string buttonraccessapprovalframeclick()
        {

            string result = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalapproveframebutton).Click();
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequestsearchbutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public void tabraccesapprovalawaitingapprovalfromothersclick()
        {


            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalawaitingapprovalfromothertab).Click();
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequesttxtbox);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void tabraccesapprovalfinalizedapprovalclick()
        {


            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalfinalizedrequeststab).Click();
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequesttxtbox);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void tabraccesapprovalmanageapprovalclick()
        {


            try
            {
                driverobj.GetElement(ObjectRepository.accessapprovalmanagerequesttab).Click();
                driverobj.WaitForElement(ObjectRepository.accessapprovalfindarequesttxtbox);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public void imageviewrequestclick()
        {

            try
            {
                driverobj.ClickEleJs(By.XPath("//tr[@id='ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00__0']/td/a"));
                driverobj.ClickEleJs(By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl06_lnkHistory"));
                driverobj.WaitForElement(ObjectRepository.accessapprovalviewrequestlink);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);}

        }
        public string linkviewrequestclick()
        {
            string result = string.Empty;

            try
            {
               // driverobj.GetElement(ObjectRepository.accessapprovalviewrequestlink).Click();
                driverobj.selectWindow("History");
                driverobj.WaitForElement(ObjectRepository.historydeniedlabel);
                result = driverobj.GetElement(ObjectRepository.historydeniedlabel).Text;
               // driverobj.Close();
              //  driverobj.SelectWindowClose();
                return result;
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);return "";
            }

        }
    }
}
