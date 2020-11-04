using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class FilePage
    {
        public static bool? IsOpened()
        {
            return Driver.Instance.CurrentWindowHandle.Length > 1;
        }

        public static bool? ContainsText(string v)
        {
            bool res = false;
            Driver.SelectChildWindow();
            res= Driver.existsElement(By.CssSelector("body:nth-child(4) > pre:nth-child(1)"));
            Driver.focusParentWindow();
            return res;

        }
    }
}