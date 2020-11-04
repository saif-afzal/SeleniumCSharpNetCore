using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class BundlesPage
    {
        public static DisplayFormatCommand DisplayFormatDropdown { get { return new DisplayFormatCommand(); } }

        public static AvailableinCatalogCommand AvailableinCatalog { get { return new AvailableinCatalogCommand(); } }

        public static void ClickEdit()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
        }

        public static void enableAccessKeys()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessCodes_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_ENABLE_ACCESS_CODE_0']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_REDEMPTION_PERIOD']")).SendKeysWithSpace("5");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_ACCESS_CODE_ONE_ATTEMPT']"));
            Driver.Instance.selectDropdownValue(By.XPath("//select[@id='MainContent_MainContent_UC1_FormView1_CNT_ACCESS_CODE_PERIOD_SAME_AS_REDEMPTION']"), "Same period as Access Key Redemption");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'Enabled')]"));
        }

        public static void addContentIntoBundle(string generalcourse)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucBundles_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'Add Content')]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_ucBundleSearch_txtSearchFor']")).SendKeysWithSpace(generalcourse);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucBundleSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBundleAddContent_ctl00_ctl04_rbContentMakeDiscretionary']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAdd']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnReturn"));

        }

        public static void checkIn()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static bool? searchforBundle(string bundlecourse, string generalcourse)
        {
            bool result = false;
            try
            {
                CommonSection.SearchCatalog(bundlecourse);
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'" + bundlecourse + "')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'" + bundlecourse + "')]"));
                result = Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'" + generalcourse + "')]"));
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessBundleBlock']"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'" + generalcourse + "')]"));



            }
            catch (Exception e)
            {

            }

            return result;

        }

        public static void simplysearchforBundle(string bundlecourse)
        {
            CommonSection.SearchCatalog(bundlecourse);
            Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'" + bundlecourse + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'" + bundlecourse + "')]"));

        }

        public static void EnterTitle(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='CNTLCL_TITLE']")).SendKeysWithSpace(v);
        }

        public static void BundleType(string v)
        {
            Driver.clickEleJs(By.XPath("//select[@id='MainContent_UC1_FormView1_BNDL_BUNDLE_TYPE']"));
            Driver.select(By.XPath("//select[@id='MainContent_UC1_FormView1_BNDL_BUNDLE_TYPE']"), v);
        }

        public static void BundleCostType()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_FormView1_BNDL_BUNDLE_COST_TYPE_0']"));
        }

        public static void ClickCreate()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
        }


    }
}