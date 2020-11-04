using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CategoryPage
    {
        public static void CreateNewcategory(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='loading-area']/h1/a"));
            Driver.clickEleJs(By.XPath("//div[@id='loading-area']/h1/a"));
            Driver.GetElement(By.XPath("//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[@id='loading-area']/h1/span/div/form/div/div/div[2]/button/i"));
            Thread.Sleep(5000);


        }

        public static void Click_CategoryBreadComblink()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[4]/a"));
        }
    }
}