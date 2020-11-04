using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class SurveyPage
    {
        public static DisplayFormatCommand DisplayFormatDropdown { get { return new DisplayFormatCommand(); } }

        public static ItemsTabCommand ItemsTab { get { return new ItemsTabCommand(); } }

       

        public static void CreteNewSurvey(string p)
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeys(p);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }

        public static void AddImage()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_hlSurvey']"));
            Driver.existsElement(By.Id("MainContent_MainContent_ucImage_lnkEdit"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucImage_lnkEdit"));
            ImagePage.UploadnewImageFile();
        }

        public static void Click_Publish()
        {
            Driver.clickEleJs(By.XPath("//div[@id='contentDetailsHeader']/div[2]/div/button/span"));
            Driver.clickEleJs(By.LinkText("Publish"));
            Driver.clickEleJs(By.XPath("//html[@id='PageBody']/body/div/div/div/div[2]/button[2]"));
        }

        public static void ClickViewasLearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

       
    }


    public class ItemsTabCommand
    {
        public void ViewVisualReportFromActionsMenu(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]//following::a[contains(text(),'View Report')]"));
        }

        public void ViewExportableReportFromActionsMenu(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]//following::a[@id='logiReportLnk']"));
        }
    }
}