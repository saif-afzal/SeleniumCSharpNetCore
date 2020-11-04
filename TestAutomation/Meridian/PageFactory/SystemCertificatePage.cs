using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class SystemCertificatePage:ObjectInit
    {
        private IWebDriver objDriver;
        public SystemCertificatePage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  BaseDefaultCertificateCommand BaseDefaultCertificate
        {
            get { return new BaseDefaultCertificateCommand(); }
        }

        public  object BaseDefaultCertificateSearch { get; internal set; }

        public  string Title
        {
            get {
              
                return objDriver.Title;
            }
        }

        public  void Preview(string v)
        {
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_BTN_SelectCertificate_SearchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_BTN_SelectCertificate_ML.BASE.BTN.Search']"));
            Thread.Sleep(20000);
            objDriver.FindElement(By.XPath(".//*[@id='TabMenu_ML_BASE_BTN_SelectCertificate_CertificateSearch_ctl02_GoButton']")).Click();

        }
    }

    public class BaseDefaultCertificateCommand
    {
        public BaseDefaultCertificateCommand()
        {
        }

        public PreviewDropdownCommand PreviewDropdown
        {
            get { return new PreviewDropdownCommand(); }
        }
    }

    public class PreviewDropdownCommand
    {
        public PreviewDropdownCommand()
        {
        }

        internal void ClickGo()
        {
            throw new NotImplementedException();
        }
    }
}