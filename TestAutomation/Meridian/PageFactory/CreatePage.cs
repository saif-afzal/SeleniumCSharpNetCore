using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class CreatePage:ObjectInit
    {
        private IWebDriver objDriver;
        public CreatePage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  void ClickBrowsebutton()
        {
            Thread.Sleep(10000);
            objDriver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            Thread.Sleep(30000);
            objDriver.existsElement(By.XPath("//input[@name='RowRemove']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Next']"));
        }

        internal  void UploadScormfile(string v)
        {
            throw new NotImplementedException();
        }

        internal  void ClickCreatebutton()
        {
            throw new NotImplementedException();
        }
    }
}