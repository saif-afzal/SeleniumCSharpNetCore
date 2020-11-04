using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class VersionsPage
    {
        public static string VerifyVersionEnableMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static string VerifyVersionAlertMessage()
        {
            return Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_UC1_VersionLocked']")).Text;

        }

        //public static string VersionNo()
        //{
        //    return Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTVER_VERSION_NUMBER']")).Text;

        //}

        public static void CheckIn()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }





        public static void Click_Back()
        {
            Driver.clickEleJs(By.XPath(" //input[@id='MainContent_MainContent_UC1_btnCancel']"));

           
        }
    }
}