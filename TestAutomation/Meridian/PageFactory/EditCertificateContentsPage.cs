using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class EditCertificateContentsPage
    {
        public static addedContentCommand addedContent { get { return new addedContentCommand(); } }

        public static void AddContent(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'Add Content')]"));
            Driver.Instance.GetElement(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch"));
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent"));
            Driver.clickEleJs(By.XPath("//input[@value='Add']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_btnCancel']"));
        }

        public static void ClickBack()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
        }

        public static void ClickAddContent()
        {
            Driver.existsElement(By.XPath("//a[contains(.,'Add Content')]"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'Add Content')]"));
        }
    }

    public class addedContentCommand
    {
        public addedContentCommand()
        {
        }

        public bool? isEvaluationAdded()
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'Evaluation')]"));
        }
    }
}