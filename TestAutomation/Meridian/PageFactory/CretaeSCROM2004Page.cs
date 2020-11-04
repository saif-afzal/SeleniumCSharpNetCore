using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CretaeSCROM2004Page
    {
        public static void Tile(string p)
        {
            Driver.Instance.WaitForElement(By.Id("CNTLCL_TITLE"));
            Driver.Instance.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            Driver.Instance.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(p);
        }

        public static void clickSaveButton()
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }
}