using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class MyTrainingProgressPage
    {
        public static string verifylabel(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='WorkSpaceContainer']/h2")).Text;
            //  throw new NotImplementedException();
        }
        public static void ClickSelectButton()
        {
            Driver.GetElement(By.XPath("//input[@value='Select']")).ClickWithSpace();
        }
       
    }
}