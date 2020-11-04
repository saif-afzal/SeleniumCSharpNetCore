using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AllMyTrainingPrintPage
    {
      

        public static AllTrainingContentCommand AllTrainingContent { get { return new AllTrainingContentCommand(); } }

        public static void Close()
        {
            Driver.Instance.SelectWindowClose1("All Training");
        }

        public static void CloseAllTrainingPrintWindow()
        {
            //Driver.Instance.SelectWindowClose1("All Training");
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Close Window')]"));
            Driver.Instance.SwitchtoDefaultContent();
        }
    }

    public class AllTrainingContentCommand
    {
        public bool? ContentType()
        {
            Driver.Instance.selectWindow("All Training");
            return Driver.GetElement(By.XPath("//tr//td[2]")).Displayed;
            

        }
    }
}