using OpenQA.Selenium;
using Selenium2.Meridian;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class DetailsPage:ObjectInit
    {
        private IWebDriver objDriver;
        public DetailsPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }


        public  int Displays { get; internal set; }
        public  string CheckDetailsTabText 
            {
                get
            {
                string res = string.Empty;
                objDriver.selectWindow("Run Report");
                //objDriver.SwitchTo().Window(Meridian_Common.childwdw2);
                res = objDriver.GetElement(By.XPath("//*[@id='WorkSpaceTitleContainer']/h1")).Text;
                //   objDriver.ClickEleJs(By.Id("ML.BASE.CMD.CloseWindow"));
                // objDriver.selectWindow("Meridian Global Reporting");
                return res;
            }
        }

        public  void ClickSelect()
        {
            Thread.Sleep(10000);
            objDriver.FindElement(By.XPath("//input[@value='Select']")).Click();
        }

        public  void ClickDetails()
        {
            throw new NotImplementedException();
        }

        public  void ClickExporttoPDF()
        {
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.Id("Export to PDF"));
            Thread.Sleep(3000);

        }
        public  string verifylabel(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@id='WorkSpaceContainer']/h2")).Text;
            //  throw new NotImplementedException();
        }
        public  void ClickCloseWindowlink()
        {
             objDriver.SelectWindowClose2("Run Report","Meridian Global Reporting");
        }
    }
}