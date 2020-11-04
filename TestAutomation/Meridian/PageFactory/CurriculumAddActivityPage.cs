using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CurriculumAddActivityPage
    {
        public static SearchTypeCommand SearchType { get { return new SearchTypeCommand(); } }

        public static ResultGridCurriculumContentCommand ResultGrid { get { return new ResultGridCurriculumContentCommand(); } }

        public static void ClickSeemoresearchcriteriaLink()
        {
            Driver.clickEleJs(By.XPath("//a[@class='adv-search-toggle']"));
        }

        public static void ClickSearchbutton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_ucContentSearch_btnSearch"));
        }

        public static void clickAddButton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnAddActivity"));
        }

        public static bool? getFeedbackMessage()
        {
            Thread.Sleep(5000);
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text.StartsWith("The selected items were added.");
        }

        public static void clickBackButton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }
    }

    public class ResultGridCurriculumContentCommand
    {
        public ResultGridCurriculumContentCommand()
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
}