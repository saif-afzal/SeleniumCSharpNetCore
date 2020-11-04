using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.ObjectModel;
using System.Reflection;
using OpenQA.Selenium.Support.UI;

namespace Selenium2.Meridian
{
    class MyMessages
    {
        private readonly IWebDriver driverobj;

        public MyMessages(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool markmsgasread()
        {

            bool actualresult = false;
            try
            {
                // driverobj.GetElement(firstmsgchk).Click();
                //driverobj.GetElement(deletebtn).Click();
                //driverobj.findandacceptalert();
                //Thread.Sleep(4000);
                driverobj.WaitForElement(firstmsgchk);
              //  driverobj.GetElement(firstmsgchk).ClickWithSpace();
                driverobj.ClickEleJs(firstmsgchk);
                driverobj.GetElement(markreadbtn).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.WaitForElement(messagelist);
                if (driverobj.GetElement(messagelist).GetAttribute("className") == "message-read")
                {
                    actualresult = true;
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;


        }
        public bool markmsgasunread()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(firstmsgchk);
              //  driverobj.GetElement(firstmsgchk).ClickWithSpace();
                driverobj.ClickEleJs(firstmsgchk);
                driverobj.GetElement(markunreadbtn).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.WaitForElement(messagelist);
                if (driverobj.GetElement(messagelist).GetAttribute("className") == "message-unread")
                {
                    actualresult = true;
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }
        public bool deletemsg()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(firstmsgchk);
               // driverobj.GetElement(firstmsgchk).ClickWithSpace();
                driverobj.ClickEleJs(firstmsgchk);
                driverobj.GetElement(deletebtn).ClickWithSpace();
                driverobj.findandacceptalert();
                Thread.Sleep(4000);
                driverobj.WaitForElement(divsuccesmsg);
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        private By firstmsgchk = By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect']");
        private By firstmsgtitle = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkSubject");
        private By msgdetail = By.Id("MainContent_UC1_fvMessage_lblSubject");
        private By deletebtn = By.Id("MainContent_UC1_FormView1_Delete");
        private By markreadbtn = By.Id("MainContent_UC1_FormView1_MarkRead");
        private By titleread = By.XPath("//a[@class='message-read']");
        private By markunreadbtn = By.Id("MainContent_UC1_FormView1_MarkUnRead");
        private By titleunread = By.XPath("//a[@class='message-unread']");
        private By messagelist = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00__0");
        private By divsuccesmsg = By.XPath("//div[@class='alert alert-success']");
    }
}
