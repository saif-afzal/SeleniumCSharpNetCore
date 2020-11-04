using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CategoriesPage
    {
        public static bool? verifyCategoriesTree()
        {
            return Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucCategories_pnlResults']/div/div"));
        }

        public static void Selectandaddcategories()
        {
            Driver.clickEleJs(By.XPath("//input[@type='checkbox']"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucCategories_btnSave"));
        }
    }
}