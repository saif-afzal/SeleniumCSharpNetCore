using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class PastExemptionsPrintPage
    {
        public static PastExemptionsContentCommand PastExemptionsContent { get { return new PastExemptionsContentCommand(); } }
    }

    public class PastExemptionsContentCommand
    {
        public bool? ContentType()
        {
            Driver.Instance.selectWindow("Past Exemptions");
            return Driver.GetElement(By.XPath("//td2")).Displayed;
        }
    }
}