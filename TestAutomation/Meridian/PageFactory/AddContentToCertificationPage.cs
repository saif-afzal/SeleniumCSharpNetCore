using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class AddContentToCertificationPage
    {
        public static SearchTypeCommand SearchType { get { return new SearchTypeCommand(); } }

        public static ResultGridCertificationContentCommand ResultGrid { get { return new ResultGridCertificationContentCommand(); } }

        public static void ClickSeemoresearchcriteriaLink()
        {
            Driver.clickEleJs(By.XPath("//a[@class='adv-search-toggle']"));
        }

        public static void ClickSearchbutton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch"));
        }

        public static void clickAddButton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_btnAddCert"));
        }

        public static bool? getFeedbackMessage()
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text.StartsWith("The selected content items were added.");
        }

        public static void clickBackButton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_btnCancel"));
        }
    }

    public class ResultGridCertificationContentCommand
    {
        public ResultGridCertificationContentCommand()
        {
        }

        public bool? isContentTypeDisplay(string v)
        {
            return Driver.GetElement(By.XPath("//td[contains(text(),'Evaluation')]")).Text.Contains(v);
        }

        public void Selectfirstrecord()
        {
            Driver.existsElement(By.XPath("//td[2]/input"));
            Driver.clickEleJs(By.XPath("//td[2]/input"));
        }
    }

    public class SearchTypeCommand
    {
        public SearchTypeCommand()
        {
        }

        public TypedropdownCommand Type { get { return new TypedropdownCommand(); } }

        public void ClickType()
        {
            if (Driver.existsElement(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_ddlContentType")))
            {
                Driver.GetElement(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_ddlContentType")).ClickWithSpace();
            }
            if(Driver.existsElement(By.Id("MainContent_MainContent_UC1_ucContentSearch_ddlContentType")))
            {
                Driver.GetElement(By.Id("MainContent_MainContent_UC1_ucContentSearch_ddlContentType")).ClickWithSpace();
            }
        }
    }

    public class TypedropdownCommand
    {
        public bool? isEvaluationdisplay()
        {
            Thread.Sleep(2000);
            if (Driver.existsElement(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_ddlContentType")))
            {
                return Driver.checkDropDownItems(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_ddlContentType"), "Evaluation");
            }
            else if (Driver.existsElement(By.Id("MainContent_MainContent_UC1_ucContentSearch_ddlContentType")))
            {
                return Driver.checkDropDownItems(By.Id("MainContent_MainContent_UC1_ucContentSearch_ddlContentType"), "Evaluation");
            }
            else
                return false;

        }

        public void SelectType(string v)
        {
            if (Driver.existsElement(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_ddlContentType")))
            {
                Driver.select(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_ddlContentType"), v);
            }
            else if (Driver.existsElement(By.Id("MainContent_MainContent_UC1_ucContentSearch_ddlContentType")))
            {
                Driver.select(By.XPath("//select[@id='MainContent_MainContent_UC1_ucContentSearch_ddlContentType']"), v);
            }
            
        }
    }
}