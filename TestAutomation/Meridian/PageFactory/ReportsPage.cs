using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class ReportsPage:ObjectInit
    {
        private IWebDriver objDriver;
        public ReportsPage(IWebDriver objDriver) : base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  MyTrainingProgressCommand MyTrainingProgress
        {
            get { return new MyTrainingProgressCommand(objDriver); }
        }

        public  ReportCriteriaModalCommand ReportCriteriaModal
        {
            get { return new ReportCriteriaModalCommand(objDriver); }
        }

        public  TrainingAssignemntDashboardCommand TrainingAssignemntDashboard { get { return new TrainingAssignemntDashboardCommand(objDriver); } }

        public  void ComplianceDashboard()
        {
            
           objDriver.IsElementVisible(WebElement_Locators.lable_ComplianceDashbord_ReportsPage);
            objDriver.ClickEleJs(WebElement_Locators.button_Open_ComplianceDashboard);
        }
    }

    public class TrainingAssignemntDashboardCommand
    {
        private IWebDriver objDriver;
        public TrainingAssignemntDashboardCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void Open()
        {
            objDriver.existsElement(By.XPath("//td[contains(text(),'Training Assignment Dashboard')]/following::td[contains(.,'Open')]"));
            objDriver.ClickEleJs(By.XPath("//td[contains(text(),'Training Assignment Dashboard')]/following::td[contains(.,'Open')]"));
        }
    }

    public class ReportCriteriaModalCommand
    {
        private IWebDriver objDriver;
        public ReportCriteriaModalCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ClickRunReport()
        {
            try
            {
                Thread.Sleep(5000);
               objDriver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_RunReport']"));
            }
            catch(Exception ex)
            {

            }
        }
    }

    public class MyTrainingProgressCommand
    {
        private IWebDriver objDriver;
        public MyTrainingProgressCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ClickRunReport()
        {
            if (!objDriver.existsElement(By.XPath("//a[contains(.,'My Training Progress')]")))
            {
                objDriver.ClickEleJs(By.XPath(".//*[@id='ctl00_MainContent_MyReports_rgReports_ctl00']/thead/tr[1]/td/div/div[2]/nav/ol/li[4]/a"));
                objDriver.existsElement(By.XPath("//a[contains(.,'My Training Progress')]/parent::td/parent::tr//a[contains(.,'Run Report')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'My Training Progress')]/parent::td/parent::tr//a[contains(.,'Run Report')]"));
            }
            else
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'My Training Progress')]/parent::td/parent::tr//a[contains(.,'Run Report')]"));
            }
            }
    }
}