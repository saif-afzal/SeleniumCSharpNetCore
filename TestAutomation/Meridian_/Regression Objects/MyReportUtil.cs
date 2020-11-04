using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
// using TestAutomation.Data;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian;
using System.Collections.ObjectModel;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class MyReportUtil
    {

        private readonly IWebDriver driverobj;

        public MyReportUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool MyReportlinkclick()
        {
            bool actualresult=false;
            try
            {
                driverobj.OpenToolbarItems(ObjectRepository.MyReportsHoverLink);
                //driverobj.GetElement(By.Id(WebElementRepository.MyReportLink)).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(ObjectRepository.MyReportfirstreport);
                string reporttitle = "Details";// driverobj.GetElement(ObjectRepository.MyReportfirstreport).Text;
                driverobj.GetElement(ObjectRepository.MyReportfirstreport).Click();
                Thread.Sleep(3000);
                if (driverobj.Title == reporttitle)
                {
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return actualresult;
        }

        public bool scheduleReport()
        {
            bool actualresult = false;
            try
            {
            //driverobj.GetElement(By.Id(WebElementRepository.MyReportLink)).Click();
            driverobj.OpenToolbarItems(ObjectRepository.MyReportsHoverLink);
            driverobj.WaitForElement(ObjectRepository.MyReportfirstreport);
            driverobj.GetElement(ObjectRepository.MyReportfirstreport).Click();
            driverobj.WaitForElement(ObjectRepository.MyReportschedulereport);
            driverobj.GetElement(ObjectRepository.MyReportschedulereport).Click();
            Thread.Sleep(5000);
            //driverobj.SelectFrame();
            driverobj.waitforframe(ObjectRepository.switchToFrame_New);
            driverobj.WaitForElement(ObjectRepository.MyReportselectreport);
            string format = "M/d/yyyy";
            driverobj.GetElement(ObjectRepository.MyReportselectreport).Click();
            driverobj.GetElement(ObjectRepository.MyReportstartdatefixcheck).Click();
            driverobj.GetElement(ObjectRepository.MyReportselectstartdate).SendKeys(DateTime.Now.ToString(format));
            driverobj.GetElement(ObjectRepository.MyReportrunschedulereport).Click();
            driverobj.WaitForElement(ObjectRepository.MyReportreporttitle);
            driverobj.GetElement(ObjectRepository.MyReportreporttitle).Clear();
            string newreporttitle = "test_" + DateTime.Now.ToString();
            driverobj.GetElement(ObjectRepository.MyReportreporttitle).SendKeys(newreporttitle);
            
            ObjectRepository.nameofschedule = driverobj.GetElement(ObjectRepository.MyReportreporttitle).GetAttribute("value");
            driverobj.GetElement(ObjectRepository.MyReportreportdiscription).Clear();
            driverobj.GetElement(ObjectRepository.MyReportreportdiscription).SendKeys("this is a test");
            //driverobj.GetElement(ObjectRepository.MyReportrecurrancestartdate).Click();
            //driverobj.GetElement(By.LinkText("" + DateTime.Now.Day)).Click();
            driverobj.GetElement(ObjectRepository.MyReportrecurranceenddate).SendKeys(DateTime.Now.AddDays(2).ToString(format));
            driverobj.GetElement(ObjectRepository.MyReportrecurrancestartdate).SendKeys(DateTime.Now.ToString(format));

            driverobj.GetElement(ObjectRepository.MyReportrecurancetime).SendKeys("03:30 PM");
            //driverobj.GetElement(ObjectRepository.MyReportrecurranceenddate).Click();
            //driverobj.GetElement(By.LinkText("" + DateTime.Now.AddDays(2).Day)).Click();

            driverobj.GetElement(ObjectRepository.MyReportrecurrancetype).Click();
            driverobj.GetElement(ObjectRepository.MyReportrecurranceenddate).Click();

            driverobj.GetElement(ObjectRepository.MyReportrecurrancenext).Click();
            driverobj.WaitForElement(ObjectRepository.MyReportrecurrancenext);
            driverobj.GetElement(ObjectRepository.MyReportrecurrancenext).Click();
            driverobj.WaitForElement(By.XPath("//input[@id='ML.BASE.BTN.Next']"));
            driverobj.GetElement(By.XPath("//input[@id='ML.BASE.BTN.Next']")).Click();
           // driverobj.WaitForElement(ObjectRepository.MyReportscheduleuserlastname);
            //driverobj.GetElement(ObjectRepository.MyReportscheduleuserlastname).Clear();
            //driverobj.GetElement(ObjectRepository.MyReportscheduleuserlastname).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr.ToString());
            //driverobj.GetElement(ObjectRepository.MyReportscheduleusersearch).Click();
            //driverobj.GetElement(ObjectRepository.MyReportscheduleusersearchlist).Click();
            driverobj.GetElement(ObjectRepository.createbutton).Click();
            Thread.Sleep(4000);
            driverobj.WaitForElement(By.XPath("//td[contains(text(),'"+newreporttitle+"')]"));
            actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return actualresult;

        }

        public void scheduletaskauthorizeduser()
        {
            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
            Thread.Sleep(5000);
            driverobj.selectWindow(ObjectRepository.adminwindowtitle);

            driverobj.GetElement(ObjectRepository.adminconfigconsole).ClickAnchor();
            driverobj.WaitForElement(ObjectRepository.adminconfigurereport);
            driverobj.GetElement(ObjectRepository.adminconfigurereport).Click();
            driverobj.WaitForElement(ObjectRepository.adminscheduletaskauthorizeuserfalse);
            driverobj.GetElement(ObjectRepository.adminscheduletaskauthorizeuserfalse).Click();
            driverobj.WaitForElement(ObjectRepository.adminsavescheduletaskauthorizeuser);
            driverobj.GetElement(ObjectRepository.adminsavescheduletaskauthorizeuser).Click();
            driverobj.WaitForElement(ObjectRepository.returnbutton);
            driverobj.GetElement(ObjectRepository.returnbutton).Click();
            driverobj.Close();
            driverobj.SwitchTo().Window("");
            Thread.Sleep(4000);
            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public string deleteschedule()
        { 
            string actualresult=string.Empty;
            try
            {
           // driverobj.GetElement(By.Id(WebElementRepository.MyReportLink)).Click();
            driverobj.OpenToolbarItems(ObjectRepository.MyReportsHoverLink);
            driverobj.WaitForElement(ObjectRepository.MyReportfirstreport);
            driverobj.GetElement(ObjectRepository.MyReportfirstreport).Click();
            Thread.Sleep(5000);
            //ObjectRepository.MyReportbtndeletetask = ObjectRepository.MyReportbtndeletetask.Replace("#####", "'" + driverobj.findidbytext(ObjectRepository.nameofschedule) + "'");
            //Thread.Sleep(1000);
            //driverobj.GetElement(By.XPath(ObjectRepository.MyReportbtndeletetask)).Click();
            driverobj.WaitForElement(ObjectRepository.MyReportbtndeletetask);
            ReadOnlyCollection<IWebElement> deleteicons = driverobj.FindElements(ObjectRepository.MyReportbtndeletetask);
            //reportsobj.ScrollToCoordinated("0", "250");
            deleteicons[deleteicons.Count - 1].Click();
            Thread.Sleep(3000);
            driverobj.findandacceptalert();
            driverobj.WaitForElement(sucessmessage);
            actualresult = driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return actualresult.Replace("item(s)", "item");
        }

        public string suspendschedule()
        {
            string actualresult=string.Empty;
            try
            {
                // driverobj.GetElement(By.Id(WebElementRepository.MyReportLink)).Click();
                driverobj.OpenToolbarItems(ObjectRepository.MyReportsHoverLink);
                Thread.Sleep(5000);

                driverobj.GetElement(ObjectRepository.MyReportfirstreport).Click();
                Thread.Sleep(5000);
                //ObjectRepository.MyReportbtnsuspendtask = ObjectRepository.MyReportbtnsuspendtask.Replace("#####", "'" + driverobj.findidbytext(ObjectRepository.nameofschedule) + "'");
                //Thread.Sleep(1000);
                //driverobj.GetElement(By.XPath(ObjectRepository.MyReportbtnsuspendtask)).Click();
                driverobj.WaitForElement(ObjectRepository.MyReportbtnsuspendtask);
                ReadOnlyCollection<IWebElement> suspendicons = driverobj.FindElements(ObjectRepository.MyReportbtnsuspendtask);
                //reportsobj.ScrollToCoordinated("0", "250");
                suspendicons[suspendicons.Count - 1].Click();
                Thread.Sleep(8000);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;

        }

        public string clickrunicon()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.OpenToolbarItems(ObjectRepository.MyReportsHoverLink);
                driverobj.WaitForElement(ObjectRepository.MyReportfirstreport);
                driverobj.GetElement(ObjectRepository.MyReportfirstreport).Click();
                driverobj.WaitForElement(ObjectRepository.MyReportschedulereport);
                ReadOnlyCollection<IWebElement> runicons = driverobj.FindElements(runreporticon);
                //reportsobj.ScrollToCoordinated("0", "250");
                runicons[runicons.Count - 1].Click();
                //reportsobj.WaitForElement(ObjectRepository.MyReportrunitem);
                // reportsobj.GetElement(ObjectRepository.MyReportrunitem).Click();
                driverobj.findandacceptalert();
                new WebDriverWait(driverobj, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists(ObjectRepository.sucessmessage));
                Thread.Sleep(4000);
                actualresult = driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return actualresult;

        }

        private By runreporticon = By.XPath("//a[contains(@id, '_btnRunTask')]");
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");

    }
}
