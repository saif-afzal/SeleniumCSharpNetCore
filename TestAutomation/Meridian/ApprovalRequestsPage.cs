using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ApprovalRequestsPage
    {
        public static PendingMyApprovalCommand PendingMyApproval { get { return new PendingMyApprovalCommand(); } }
    }

    public class PendingMyApprovalCommand
    {
        public void Approve(string v1,string v2 )
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v1 + "')]/following::a[@id='ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_btnMyApprove']"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v1+"')]/following::a[@id='ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_btnMyApprove']"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            // Driver.GetElement(By.Id("MainContent_UC1_REQUEST_COMMENT")).SendKeysWithSpace(v2);
            Driver.existsElement(By.Id("MainContent_UC1_SubmitRequest"));
            Driver.clickEleJs(By.Id("MainContent_UC1_SubmitRequest"));
            // Driver.Instance.SwitchtoDefaultContent(); //MainContent_UC1_SubmitRequest

        }
    }
}