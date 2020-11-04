using System;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using OpenQA.Selenium;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class HelpPage
    {
        private IWebDriver objDriver;
        public HelpPage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        
        public  bool Title
        {
            get { return objDriver.WindowHandles.Contains("Help"); }
        }

        public  bool? CheckTitle()
        {
           objDriver.SelectChildWindow();
            objDriver.ClickEleJs(By.XPath("//img[@class='homebutton hover']"));
            objDriver.Navigate_to_TrainingHome();
            return true;
        }
    }
}