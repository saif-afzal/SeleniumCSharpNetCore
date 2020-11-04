using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class AddJobTitleModal
    {
        public static ListofJobTitlesCommand ListofJobTitles { get { return new ListofJobTitlesCommand(); } }

        public static bool? NoAddToLevelSelection { get { return Driver.GetElement(By.XPath("//div[@id='divSelectLevel']/div/button/span")).Displayed; } }

        public static bool? ResultsFound()
        {
            return Driver.existsElement(By.XPath("//table[@id='jobtitle-list']/tbody/tr/td[2]"));
        }

        public static bool? NoMatchingResultsFound()
        {
            return Driver.existsElement(By.XPath("//table[@id='jobtitle-list']/tbody/tr/td"));
        }
    }

    public class ListofJobTitlesCommand
    {
        public bool? StatusColumn { get { return Driver.GetElement(By.XPath("//a[contains(text(),'Status')]")).Displayed; } }

        public ListofJobTitlesCommand()
        {
        }

        public void Search(string v)
        {
            Driver.GetElement(By.Id("search-Jobtitles")).Clear();
            Driver.GetElement(By.Id("search-Jobtitles")).SendKeys(v);
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//button[@id='btn-search-jobtitle']/span"));
            Thread.Sleep(4000);

        }

        public void AddmultipleJobtitles()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//div[2]/div[2]/table/tbody/tr/td/input"));
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//tr[2]/td/input"));
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//tr[3]/td/input"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.Id("btn-add-jobtitles"));
            Driver.existsElement(By.XPath("//table[@id='jobtitle-list-career-path']/tbody/tr/td/a"));
        }

        public void AddSingleJobtitles()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//div[2]/div[2]/table/tbody/tr/td/input"));
            Driver.clickEleJs(By.Id("btn-add-jobtitles"));
            Thread.Sleep(2000);
        }
    }
}