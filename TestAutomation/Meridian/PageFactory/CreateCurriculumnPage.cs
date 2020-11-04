using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CreateCurriculumnPage
    {
        public static DisplayFormatDropdownCommand DisplayFormatDropdown { get { return new DisplayFormatDropdownCommand(); } }

        public static AvailableinCatalogCurriculumCommand AvailableinCatalog { get { return new AvailableinCatalogCurriculumCommand(); } }

        public static void fillTtile(string v)
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.Instance.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            Driver.Instance.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeys("Test");
        }

        public static void SelectCollaborationSpaceOption(string v)
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_fvCurriculum_CRLM_CSPACE_AVLBLE_1"));
        }

        public static void ClickCreatebutton()
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }

    public class AvailableinCatalogCurriculumCommand
    {
        public AvailableinCatalogCurriculumCommand()
        {

        }

        public bool? isAvailableinCatalogOptionisDisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'Available in Catalog')]"));
        }

        public bool? isChecked()
        {
            if (Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")).Selected;
            }
            else if (Driver.existsElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']")).Selected;
            }
            else if (Driver.existsElement(By.XPath("//input[@id='CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='CNT_SEARCHABLE']")).Selected;
            }
            else
                return false;
        }

        public void ClicktoUncheck()
        {
            if (Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE"));
            }
            else if (Driver.existsElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']"));
            }
            else if (Driver.existsElement(By.XPath("//input[@id='CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='CNT_SEARCHABLE']"));
            }
        }
    }
}