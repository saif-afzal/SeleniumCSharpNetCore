using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ApprovalPathPage
    {
        public static bool? isTitleDisplay()
        {
            return Driver.existsElement(By.Id("item-title-create"));

        }

       
        public static int istaskDisplay()
        {
            string taskCount = Driver.GetElement(By.XPath("//tr[@id='customId_0']/td")).Text;
            return Driver.getIntegerFromString(taskCount);
        }

        public static sf128titlecommand Title(string v)
        {
            return new sf128titlecommand(v);
        }
    }
   
        public class sf128titlecommand
    {
            private string v;
            public sf128titlecommand(string v)
            {
                this.v = v;
            }

        public void Create()
        {
            Driver.GetElement(By.Id("item-title-create")).Clear();
            Driver.GetElement(By.Id("item-title-create")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("btn-update-title"));
            Thread.Sleep(1000);
        }
    }
}