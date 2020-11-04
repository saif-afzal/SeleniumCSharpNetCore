using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CurrentTrainingPage
    {
        public static AllStatusDropDownCommand AllStatusDropDown { get { return new AllStatusDropDownCommand(); } }

        public static ContentListCommand ContentList { get { return new ContentListCommand(); } }

        public static allContenttypefilterCommand allContenttypefilter { get { return new allContenttypefilterCommand(); } }

        public static int Totalnumberofresultpages()
        {
            if (Driver.existsElement(By.XPath("//table[@id='ctl00_MainContent_UC3_RadGrid1_ctl00']/thead/tr/td/div/div/nav/ol/li[3]/div/strong")))
            {
                string pageNo = Driver.GetElement(By.XPath("//table[@id='ctl00_MainContent_UC3_RadGrid1_ctl00']/thead/tr/td/div/div/nav/ol/li[3]/div/strong")).Text;
                return Driver.getIntegerFromString(pageNo);
            }
            else
            {
                return 1;

            }
        }

        public static void ClickFilterButton()
        {
            Driver.clickEleJs(By.Id("MainContent_UC3_btnFilter"));
            Thread.Sleep(1000);
        }

        public static void ClickResetButton()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC3_btnReset']"));
        }
    }

    public class allContenttypefilterCommand
    {
        public allContenttypefilterCommand()
        {
        }

        public void selectEvaluation()
        {
            Driver.Instance.FindElement(By.XPath("//div[@id='MainContent_UC3_pnlFilter']/div/div[2]/span/div/button/b")).Click();
            Driver.Instance.FindElement(By.XPath("//div[@id='MainContent_UC3_pnlFilter']/div/div[2]/span/div/ul/li[8]/a/label")).Click();
            Thread.Sleep(5000);
            Driver.Instance.FindElement(By.Id("MainContent_UC3_btnFilter")).Click();
        }
    }

    public class AllStatusDropDownCommand
    {
        public AllStatusDropDownCommand()
        {
        }

        public bool? isSelectedValue(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='MainContent_UC3_pnlFilter']/div/div/span/div/button/span"));
            return Driver.GetElement(By.XPath("//div[@id='MainContent_UC3_pnlFilter']/div/div/span/div/button/span")).Text.Contains(v);
        }

        public void SelectValue(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='MainContent_UC3_pnlFilter']/div/div/span/div/button/b"));
            Driver.clickEleJs(By.XPath("//div[@id='MainContent_UC3_pnlFilter']/div/div/span/div/ul/li[3]/a/label"));
        }
    }

    public class ContentListCommand
    {
        public ContentListCommand()
        {
        }

        public bool? isContentTypeDisplay(string v)
        {
            return Driver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC3_RadGrid1_ctl00__0']/td/ul/li"));
        }
    }
}