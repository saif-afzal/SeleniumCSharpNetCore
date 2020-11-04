using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class SF182ConsolePage
    {
        public static string Title
        {
            get
            {
                Thread.Sleep(20000);

                //                Driver.Instance.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
                return Driver.Instance.Title;
            }
        }

        public static ApprovalPathstabCommand ApprovalPathstab { get { return new ApprovalPathstabCommand(); } }

        public static bool? isHelpTextdisplay()
        {
            return Driver.existsElement(By.Id("MainContent_ucBulk_lblMultiSelect"));
        }

        public static bool? istabsdisplay(string v1, string v2, string v3)
        {
            Driver.GetElement(By.XPath("//ul[@id='sf182-manage-list']/li/a")).Text.Equals(v1);
            Driver.GetElement(By.LinkText("Bulk Actions")).Text.Equals(v2);
           return Driver.GetElement(By.XPath("Approval Paths")).Text.Equals(v3);

        }

        public static bool? isBradeCrumbtext(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div/ol")).Text.EndsWith(v);
        }

        public static void Click_ApprovalPathLink()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Approval Workflows')]"));
        }

        public static int TotalCount()
        {
            string paginationinfo = Driver.GetElement(By.XPath("//span[@class='pagination-info']")).Text;
            return Driver.getIntegerFromString(paginationinfo);
        }

        public static selectsfapprovalpathcommand Select(string v)
        {
            return new selectsfapprovalpathcommand(v);
        }

        public static void Click_Sf128BreadcrombLink()
        {
            Driver.clickEleJs(By.XPath("//ol[@class='breadcrumb']//a[contains(text(),'SF-182')]"));
        }
    }

    public class selectsfapprovalpathcommand
    {
        private string v;

        public selectsfapprovalpathcommand(string v)
        {
            this.v = v;
        }

        public void Delete()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]/preceding::td[1]"));
            Driver.clickEleJs(By.XPath("//button[@id='delete-path']"));
            Thread.Sleep(1000);
            Driver.clickEleJs(By.Id("btn-remove-content"));
        }
    }

    public class ApprovalPathstabCommand
    {
        public ApprovalPathstabCommand()
        {
        }

        public bool? VerifyComponets(string v1, string v2)
        {
            Driver.existsElement(By.LinkText("Title"));
            Driver.GetElement(By.XPath("//table[@id='table-approvals']/thead/tr/th[3]/div")).Text.Equals("Total Steps");
            Driver.GetElement(By.XPath("//table[@id='table-approvals']/thead/tr/th[4]/div")).Text.Equals("Assigned To");
            Driver.GetElement(By.XPath("//table[@id='table-approvals']/thead/tr/th[5]/div")).Text.Equals("Default Path");
            return Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Create')]"));
        }

        public void Click_Create()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Create')]"));
        }
    }
}