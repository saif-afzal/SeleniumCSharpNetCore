using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ClassroomCourseEnrollmentPage
    {
        public static void ClickSelect()
        {
            Driver.clickEleJs(By.XPath("//input[@value='Select']"));

        }
    }
}