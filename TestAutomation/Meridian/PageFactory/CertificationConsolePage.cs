using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CertificationConsolePage
    {
        public static ResulttableCommand Resulttable { get { return new ResulttableCommand(); } }

        public static void Search(string v)
        {
            Driver.existsElement(By.XPath("//input[@id='DashboardSearchFor']"));
            Driver.GetElement(By.XPath("//input[@id='DashboardSearchFor']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='DashboardSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btnSearchCertifications']/span"));


        }

        public static void ClickSearchedContentTitle(string v)
        {
            Driver.existsElement(By.LinkText(v));
            Driver.clickEleJs(By.LinkText(v));
        }

        public static void SearchUser(string v)
        {
            Driver.Instance.FindElement(By.Id("UserSearchFor")).Click();
            Driver.Instance.FindElement(By.Id("UserSearchFor")).Clear();
            Driver.Instance.FindElement(By.Id("UserSearchFor")).SendKeys(v);
            Driver.Instance.FindElement(By.XPath("//button[@id='btnSearchUsers']/span")).Click();
            
        }

        public static void clickcloseicon()
        {
            Driver.clickEleJs(By.XPath("//div[2]/div/button"));
            Driver.existsElement(By.XPath("//table[@id='certifyMoreUsers']/tbody/tr/td[2]/small"));
            Driver.clickEleJs(By.XPath("//td[3]/a/span"));
            Driver.Instance.SelectFrame(By.XPath("//span[@class='k-window-title']"));
            Driver.existsElement(By.XPath("//strong[contains(text(),'testabc@meridianksi.com')]"));
            Driver.Instance.SwitchTo().Frame(1);
            Driver.clickEleJs(By.LinkText("Close"));
        }

        public static string CertifiedUserCount()
        {
            Driver.existsElement(By.XPath("//td[3]"));
            return Driver.GetElement(By.XPath("//td[3]")).Text;
        }

        public static void ClickCertificationBreadcromp()
        {
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Certifications')]"));
        }
    }

    public class ResulttableCommand
    {
        public CertifiyUserModalCommand CertifiyUserModal { get { return new CertifiyUserModalCommand(); } }

        public ResulttableCommand()
        {
        }

        public bool? isUserdisplay(string v)
        {
            Driver.existsElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[2]"));
            return Driver.GetElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[2]")).Text.Contains(v);
        }

        public bool? CurrentStatus(string v)
        {
            return Driver.GetElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[3]")).Text.Equals(v);
        }

        public bool? ProgressStatus(string v)
        {
            if(Driver.GetElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[4]")).Text.Equals(v))
            {
                return true;
            }
            if (Driver.GetElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[4]")).Text.StartsWith(v))
            {
                return true;
            }
            else
                return false;
        }

        public bool? ActionMenuItems(string v1="", string v2="",string v3="",string v4="",string v5="")
        {
            int count = 0;
            string[] values = { v1, v2, v3, v4, v5 };
            //int result = values.Count(s => s != null);
            int result=(from s in values where !string.IsNullOrEmpty(s) select s).Count();

            Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
            IWebElement allOptions = Driver.Instance.FindElement(By.XPath("//body[@class='canvas']/ul[1]"));
            IList<IWebElement> elements = allOptions.FindElements(By.XPath("//body[@class='canvas']/ul[1]/li"));
            int i = 0;
            bool res = false;
            foreach(IWebElement option in elements)
            {
                if (option.Text.Length != 0)
                {
                    if (option.Text.Equals(values[i]))
                    {
                        i = i + 1;
                    }
                }
                if(result==i)
                {
                    res = true;
                    break;
                }
                
                    
            }
            return res;
            // Driver.Instance.select
            // Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
            // Driver.GetElement(By.LinkText("Certify")).Text.Equals(v1);
            // return Driver.GetElement(By.LinkText("Suspend")).Text.Equals(v2);
        }

        public bool SelectActionItem(string v)
        {
            if (v == "Revoke")
            {
                Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
                Driver.clickEleJs(By.LinkText(v));
                Driver.existsElement(By.Id("revoke-reason"));
                Driver.GetElement(By.Id("revoke-reason")).SendKeysWithSpace("For Automation");
                Driver.clickEleJs(By.Id("btn-revoke-user"));
                return Driver.GetElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[3]")).Text.Equals(v);
            }
            if (v == "Suspend")
            {
                Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
                Driver.clickEleJs(By.LinkText(v));
                Driver.existsElement(By.Id("suspend-reason"));
                Driver.GetElement(By.Id("suspend-reason")).SendKeysWithSpace("For Automation");
                Driver.clickEleJs(By.Id("btn-suspend-user"));
                return Driver.GetElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[3]")).Text.Equals(v);
            }
            if (v == "Certify")
            {
                Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
                Driver.clickEleJs(By.LinkText(v));
                Driver.existsElement(By.Id("certify-reason"));
                Driver.GetElement(By.Id("certify-reason")).SendKeysWithSpace("For Automation");
                Driver.clickEleJs(By.Id("btn-add-cert"));
                return Driver.GetElement(By.XPath("//table[@id='tableUsers']/tbody/tr/td[3]")).Text.Equals(v);
            }
            else return false;

        }

        public bool? isRevokedstatusdisplayActionMenu()
        {
            return Driver.existsElement(By.LinkText("Revoked"));
        }

        public bool? isCertifiyUserModalOpen()
        {
            return Driver.existsElement(By.XPath("//div[@id='certify-more']/div/div/div/h4"));
        }

        public void selectstatus(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/div/ul/li/div/div/div/div/button/span[2]/span"));
            Driver.select(By.XPath("//div[@id='content']/div/div/ul/li/div/div/div/div/button/span[2]/span"), v);
            Thread.Sleep(5000);
        }

        public void Selectuser(string v)
        {
            Driver.clickEleJs(By.XPath("//table[@id='tableUsers']/tbody/tr/td/input"));
        }

        public void SelectCertifyfrombulkaction()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/div/div/div/div/div/div/button/span[2]/span"));
            Driver.select(By.XPath("//div[@id='content']/div/div/div/div/div/div/div/div/ul/li[2]/a/span"), "Action:");
        }

        public void ClickCertifyAction()
        {
            Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
            Driver.clickEleJs(By.LinkText("Certify"));
        }
    }

    public class CertifiyUserModalCommand
    {
        public CertifiyUserModalCommand()
        {
        }

        public ObtaineddateCalenderCommand ObtaineddateCalender { get { return new ObtaineddateCalenderCommand(); } }

        public void CancelwithReason(string v)
        {
            Driver.Instance.FindElement(By.Id("certify-reason")).Click();
            Driver.Instance.FindElement(By.Id("certify-reason")).Clear();
            Driver.Instance.FindElement(By.Id("certify-reason")).SendKeys("test");
            Driver.Instance.FindElement(By.Id("btn-cancel")).Click();
        }

        public void CertifywithReason(string v)
        {
            Driver.Instance.FindElement(By.Id("certify-reason")).Click();
            Driver.Instance.FindElement(By.Id("certify-reason")).Clear();
            Driver.Instance.FindElement(By.Id("certify-reason")).SendKeys("test");
            Driver.Instance.FindElement(By.Id("btn-add-cert")).Click();
        }

        public bool? Obtaineddate(string v)
        {
            string format = "M/dd/yyyy";
            string currentdate = DateTime.Now.ToString(format).Replace("-","/");
            //startdate = startdate.Replace("-", "/");
            IWebElement ObtainedDate = Driver.GetElement(By.XPath("//input[@id='cert-obtained-date']"));
            return ObtainedDate.Text.Equals(currentdate);
        }

        public bool? Expirationdate(string v)
        {
            string format = "M/dd/yyyy";
            string currentdate = DateTime.Now.AddDays(1).ToString(format).Replace("-", "/");
            //startdate = startdate.Replace("-", "/");
            IWebElement ObtainedDate = Driver.GetElement(By.XPath("//input[@id='cert-expiration-date']"));
            return ObtainedDate.Text.Equals(currentdate);
        }

        public bool? isRecertificationPerioddisplay()
        {
            return Driver.GetElement(By.XPath("//div[@id='recert-period-div']/h4")).Text.Equals("Recertification Period");
        }

        public bool? isRecertificationbegindisplay(string v1,int day, string v2)
        {
            string format = "M/dd/yyyy";
            string currentdate = DateTime.Now.AddDays(-day).ToString(format).Replace("-", "/");
            //startdate = startdate.Replace("-", "/");
            IWebElement beginsDate = Driver.GetElement(By.Id("cert-add-period-begins"));
            IWebElement message= Driver.GetElement(By.Id("cert-add-period-begins-desc"));
            if (beginsDate.Text.Equals(currentdate) && message.Text.Equals(v2))
            {
                return true;
            }
            else return false;
        }

        public bool? isRecertificationPeriodenddisplay(string v)
        {
            return Driver.GetElement(By.Id("cert-add-period-ends-desc")).Text.Equals(v);
        }

        public bool? isRecertificationenddatedisplay(string v1, int day)
        {
            string format = "M/dd/yyyy";
            string currentdate = DateTime.Now.AddDays(day).ToString(format).Replace("-", "/");
            //startdate = startdate.Replace("-", "/");
            IWebElement EndDate = Driver.GetElement(By.Id("cert-add-period-ends"));
            return EndDate.Text.Equals(currentdate);
        }
    }

    public class ObtaineddateCalenderCommand
    {
        public ObtaineddateCalenderCommand()
        {
        }

        public bool? isbackdatesaredisabled()
        {
            Driver.GetElement(By.XPath("//input[@id='cert-obtained-date']")).ClickWithSpace();
            return Driver.GetElement(By.XPath("//div[@id='pane-add-cert-exp']/div[2]/div/div/div/div/div/div/ul/li/div/div/table/tbody/tr[4]/td[3]")).Enabled;
        }
    }
}