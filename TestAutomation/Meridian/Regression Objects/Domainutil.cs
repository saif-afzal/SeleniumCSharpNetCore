using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using Selenium2.Meridian;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class Domainutil
    {
        private readonly IWebDriver driverobj;

        public Domainutil(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Changetoanotherdomain()
        {
            bool actualresult = false;
            try
            {
                driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(By.Id("MainContent_ucAddlLinksMyDomains_ddlDomains"));
                driverobj.FindSelectElementnew(By.Id("MainContent_ucAddlLinksMyDomains_ddlDomains"), "SQL Child Domain 1");
                driverobj.findandacceptalert();
                Thread.Sleep(7000);
                driverobj.WaitForElement(ObjectRepository.login_name);
                driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(By.Id("MainContent_ucAddlLinksMyDomains_ddlDomains"));
                driverobj.FindSelectElementnew(By.Id("MainContent_ucAddlLinksMyDomains_ddlDomains"), "SQL Child Domain 1");
                driverobj.WaitForElement(By.Id("MainContent_ucAddlLinksMyDomains_ddlDomains"));
                driverobj.FindSelectElementnew(By.Id("MainContent_ucAddlLinksMyDomains_ddlDomains"), "Meridian Global - Core Domain");
                Thread.Sleep(7000);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(ObjectRepository.login_name);

                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        private By LinkMyAccount = By.XPath("//a[normalize-space()='Account']");
    }
}
