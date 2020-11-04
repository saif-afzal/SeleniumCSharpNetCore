using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class CreateCompetencyPage:ObjectInit
    {
        private IWebDriver objDriver;
        public CreateCompetencyPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;  
        }
        public  void EditCompetencyName(string v)
        {
            objDriver.ClickEleJs(By.XPath(".//*[@id='competency-title-edit-link']/em"));
            objDriver.GetElement(By.XPath("//input[@id='competency-title-edit']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-update-title']"));
            Thread.Sleep(2000);
           // objDriver.WaitForElement(By.CssSelector("div.alert.alert-dismissible.alert-fixed.alert-success"));
        }

        public  void SaveCompetencyName()
        {
            objDriver.ClickEleJs(By.Id("btn-update-title"));
        }

        public  void FillTitleTextBox_NewCompetency(string v)
        {
            throw new NotImplementedException();
        }

        public  void ClickSubTab_CompetencyDetail()
        {
            throw new NotImplementedException();
        }

        public  void SetDescription(string v)
        {
            throw new NotImplementedException();
        }

        public  void SetKeywords(string v)
        {
            throw new NotImplementedException();
        }

        public  void FillTitleTextBox_NewJobTitle(string v)
        {
            throw new NotImplementedException();
        }
    }
}