using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CurriculumDetailsPage
    {
        public static void CLickbreadcrumb()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucContentInfo1_FormView1_backButton']"));
        }
    }
}