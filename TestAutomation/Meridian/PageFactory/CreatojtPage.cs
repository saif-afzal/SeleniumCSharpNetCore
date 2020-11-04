using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CreateojtPage
    {
        public static DisplayFormatDropdownCommand DisplayFormatDropdown { get { return new DisplayFormatDropdownCommand(); } }

        public static void CreteNewOJT(string v)
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }
}