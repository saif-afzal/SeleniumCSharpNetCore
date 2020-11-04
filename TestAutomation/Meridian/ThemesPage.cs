using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ThemesPage
    {
        public static SearchbarCommand Searchbar { get { return new SearchbarCommand(); } }

        public static bool? isSearchBarisdisplay()
        {
            throw new NotImplementedException();
        }

        public static bool? isNorecordsfounddisplay()
        {
            Driver.existsElement(By.XPath("//div[@id='has-themes']/div[3]/p/strong"));
            return Driver.GetElement(By.XPath("//div[@id='has-themes']/div[3]/p/strong")).Text.Equals("No records found.");
        }

        public static bool? isSearchresultFound(string v)
        {
            return Driver.existsElement(By.XPath("//strong[contains(text(),'" + v + "')]"));
        }
    }

    public class SearchbarCommand
    {
        public SearchbarCommand()
        {
        }

        public void Search(string v)
        {
            Driver.GetElement(By.Id("theme-search")).Clear();
            Driver.GetElement(By.Id("theme-search")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//button[@id='theme-search-go']/span"));
            Thread.Sleep(5000);

        }
    }
}