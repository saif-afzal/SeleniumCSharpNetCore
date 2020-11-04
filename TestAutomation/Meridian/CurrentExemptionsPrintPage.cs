using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CurrentExemptionsPrintPage
    {
        public static CurrentExemptionsContentCommand CurrentExemptionsContent { get { return new CurrentExemptionsContentCommand(); } }
    }

    public class CurrentExemptionsContentCommand
    {
        public bool? ContentType()
        {
            Driver.Instance.selectWindow("Current Exemptions");
            return Driver.GetElement(By.XPath("//td[1]")).Displayed;
            //Driver.clickEleJs(By.XPath("//a[contains(text(),'Close Window')]"));
        }
    }
}