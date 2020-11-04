using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class MyTrainingProgressPDFPage:ObjectInit
    {
        private IWebDriver objDriver;
        public MyTrainingProgressPDFPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  int Displays { get; internal set; }
        public  string Title
        {
            get
            {
                string res = string.Empty;
               objDriver.selectWindow("My_Training_Progress.pdf");
                res =objDriver.Url;
               objDriver.SelectWindowClose2("", "Meridian Global Reporting");
                return res;
            }
        }
        internal  void ClickBrowsertabX()
        {
            throw new NotImplementedException();
        }
    }
}