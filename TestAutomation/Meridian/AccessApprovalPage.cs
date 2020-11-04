using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AccessApprovalPage
    {
        public static bool? verifyFields()
        {
            bool result = true;
            try
            {
                Driver.existsElement(By.XPath("//div[@id='MainContent_pnlContent']/div/div/fieldset/legend"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_lblSearchFor"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_rbApprovalRequired_0"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
                result = true;
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public static void AssignApproverPath()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_rbApprovalRequired_0']"));
            //Driver.clickEleJs(By.Id("//input[@id='MainContent_MainContent_UC1_FormView1_rbApprovalRequired_0']"));
            //Driver.GetElement(By.XPath("MainContent_MainContent_UC1_txtSearch")).Click();
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_txtSearch")).SendKeys("Access_Approval");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
            //Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect"));
            //Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

      
    }
}