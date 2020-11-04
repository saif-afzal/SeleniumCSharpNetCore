using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CreateNewEvent
    {
        public static ScheduleTabCommand ScheduleTab { get { return new ScheduleTabCommand(); } }
    }

    public class ScheduleTabCommand
    {
        public ScheduleTabCommand()
        {
        }

        public void CreateNewEvent(string v)
        {
            string format = "M/dd/yyyy";
            string startdate = DateTime.Now.AddDays(2).ToString(format);
            startdate = startdate.Replace("-", "/");
            
            string enddate = DateTime.Now.AddDays(5).ToString(format);
            enddate = enddate.Replace("-", "/");

            Driver.existsElement(By.Id("eventTitle_0"));
            Driver.GetElement(By.Id("eventTitle_0")).Clear();
            Driver.GetElement(By.Id("eventTitle_0")).SendKeysWithSpace("Section 2");

            // Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
            //Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
            IWebElement StartsRecur = Driver.Instance.FindElement(By.XPath("//input[@id='startDate']"));
            StartsRecur.Clear();
            StartsRecur.SendKeysWithSpace(startdate);

            IWebElement EndsRecur = Driver.Instance.FindElement(By.XPath("//input[@id='endDate']"));
            EndsRecur.Clear();
            EndsRecur.SendKeysWithSpace(enddate);
            Driver.clickEleJs(By.XPath("//div[@id='event0']/div/div/div[4]/div/div/button/span"));
            
            Driver.clickEleJs(By.XPath("//span[contains(.,'Daily')]"));
            //  Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Daily");


            Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("11/25/19");

            //IWebElement webElement3 = Driver.Instance.FindElement(By.XPath("//input[@id='endDateRecur']"));
            //webElement3.SendKeys(Keys.Tab);
            Actions action = new Actions(Driver.Instance);
            action.SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
            Driver.clickEleJs(By.Id("btnSave"));
            Thread.Sleep(2000);
           // Driver.clickEleJs(By.Id("btnSave"));
        }
    }
}