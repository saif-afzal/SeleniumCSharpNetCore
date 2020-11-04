using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class WaivedPrerequisitesPrintPage
    {
        public static WaivedPrerequisitesContentCommand WaivedPrerequisitesContent { get { return new WaivedPrerequisitesContentCommand(); } }

        public static void closeWaivedPrerequisitesPrintWindow()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Close Window')]"));
            Driver.Instance.SwitchtoDefaultContent();
        }
    }

    public class WaivedPrerequisitesContentCommand
    {
        public bool? ContentType()
        {
            Driver.Instance.SelectWindowClose1("All Training");
           // Driver.clickEleJs(By.XPath(""));
           return Driver.GetElement(By.XPath("//td[1]")).Displayed;
        }
    }
}