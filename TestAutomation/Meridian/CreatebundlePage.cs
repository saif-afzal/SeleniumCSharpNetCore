using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CreatebundlePage
    {
        public static bundleCostTypeCommand bundleCostType { get { return new bundleCostTypeCommand(); } }

        public static bundleTypedropdownCommand bundleTypedropdown { get { return new bundleTypedropdownCommand(); } }

        public static DisplayFormatDropdownCommand DisplayFormatDropdown { get { return new DisplayFormatDropdownCommand(); } }

        public static void CreateBundle(string bundleType="", string bundleTilte="", string bundleCost="")
        {
            CreatebundlePage.FillTitle(bundleTilte);
            CreatebundlePage.bundleTypedropdown.selecttype(bundleType);
            CreatebundlePage.bundleCostType.selectradiobutton(bundleCost);
            CreatebundlePage.ClickCreatebutton();
        }

        public static void ClickCreatebutton()
        {
            Driver.clickEleJs(By.XPath("//input[@value='Create']"));
        }

        public static void FillTitle(string bundleTilte)
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeys(bundleTilte);
        }
    }

    public class bundleCostTypeCommand
    {
        public bundleCostTypeCommand()
        {
        }

        public void selectradiobutton(string bundleCost)
        {
            if (bundleCost == "Bundle Price")
            {
                Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_BNDL_BUNDLE_COST_TYPE_0"));
            }
            else if (bundleCost == "Element Price")
            {
                Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_BNDL_BUNDLE_COST_TYPE_1"));
            }
        }
    }

    public class bundleTypedropdownCommand
    {
        public bundleTypedropdownCommand()
        {
        }

        public void selecttype(string bundleType)
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_BNDL_BUNDLE_TYPE"));
            Driver.select(By.Id("MainContent_UC1_FormView1_BNDL_BUNDLE_TYPE"), bundleType);
        }
    }
}