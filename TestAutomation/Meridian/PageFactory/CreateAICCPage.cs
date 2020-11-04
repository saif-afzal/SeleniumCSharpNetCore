using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CreateAICCPage
    {
        public static DisplayFormatDropdownCommand DisplayFormatDropdown { get { return new DisplayFormatDropdownCommand(); } }

        public static AvailableinCatalogCommand AvailableinCatalog { get { return new AvailableinCatalogCommand(); } }

        public static void Title(string v)
        {
            Thread.Sleep(5000);
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
        }

        public static void CreateAICC(string v)
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }

    public class DisplayFormatDropdownCommand
    {
        public DisplayFormatDropdownCommand()
        {
        }

        public bool? Defaultvalue(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='INTERNALDOC_PATH_DETAILS']//span[@class='filter-option pull-left']"));
            return Driver.GetElement(By.XPath("//div[@id='INTERNALDOC_PATH_DETAILS']//span[@class='filter-option pull-left']")).Text.Equals(v);
        }

        public bool? isDefaultvaluedisplay()
        {
            if (Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']")))
            {
                return true;
            }
            else if (Driver.existsElement(By.XPath("//div[@id='INTERNALDOC_PATH_DETAILS']//span[@class='filter-option pull-left']")))
            {
                return true;
            }
            else if (Driver.existsElement(By.XPath("//label[contains(text(),'Display Format')]/following::button")))
            {
                return true;
            }
            else return false;
        }
    }
}