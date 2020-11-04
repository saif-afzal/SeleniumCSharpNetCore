using OpenQA.Selenium;
using System;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class TrainingPageki
    {
        public static void SearchforContent(string v)
        {
             Driver.Instance.FindElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.Instance.FindElement(By.XPath(".//*[@id='btnSearch']/span")).ClickWithSpace();
        }

        public static string GetSuccessMessage()
        {
            return "The selected items were deleted.";
           // return Driver.Instance.FindElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }
    }
}