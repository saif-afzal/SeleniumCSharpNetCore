using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class MenuPage
    {
        public static string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }

        public static void ClickOptionsTab(string v)
        {
            throw new NotImplementedException();
        }

        public static string GetCurrentValueForCareerPath()
        {
            return Driver.Instance.FindElement(By.XPath("//table[@id='EditCustomValue']/tbody/tr[7]/td")).Text;
            
        }
    }
}