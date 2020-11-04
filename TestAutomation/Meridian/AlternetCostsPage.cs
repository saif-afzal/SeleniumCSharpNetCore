using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AlternetCostsPage
    {
        public static bool? IsSearchfieldsDisplayed()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_lblSearchFor"));
                Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlSearch']/div/div[2]/label"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_lblType"));
                Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlSearch']/div/div[4]/label"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_Add"));
                result = Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnCancel"));
               

            }
            catch(Exception ex)
            { }
            return result;
        }

        public static void AddUsertoAlternetCost()
        {
            
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
            Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST"));
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST")).SendKeys("20");
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Add"));
        }
    }
}