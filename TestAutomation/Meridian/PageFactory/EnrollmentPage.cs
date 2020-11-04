using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class EnrollmentPage
    {
        public static EnrollmentTabCommand EnrollmentTab { get { return new EnrollmentTabCommand(); } }

        public static BatchEnrollmentModalCommand BatchEnrollmentModal { get { return new BatchEnrollmentModalCommand(); } }

        public static string VerifyTab()
        {
            return Driver.Instance.Title;

        }

        public static string GetDescriptionLink()
        {
            return Driver.GetElement(By.XPath("//div[@id='enrolled']/div/p/strong")).Text;
        }

        public static void ClickWaitlistUsersButton()
        {
            Driver.waitlistrefresh();
            //Driver.existsElement(By.XPath("///button[contains(text(),'Waitlist Users')]"));
            //Driver.clickEleJs(By.XPath("///button[contains(text(),'Waitlist Users')]"));
            //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Waitlisted')]"));
            Driver.existsElement(By.XPath("//div[@id='waitlisted']/div/button"));
            Driver.clickEleJs(By.XPath("//div[@id='waitlisted']/div/button"));
           
        }

        public static void SelectCheckBox()
        {
            Driver.clickEleJs(By.XPath("//table[@id='tableWaitlistUsers']/thead/tr/th[1]/div[1]/input"));
        }

        public static void ClickWaitlistButton()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btnWaitlistUsers']"));
            Thread.Sleep(5000);
        }

        public static void ClickEnrollButton()
        {
            Driver.clickEleJs(By.CssSelector("button.btn.btn-primary.btn-block.margin-top-xs"));
        }

        public static void ClickContentTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkContent']"));
        }

        public static void ClickViewAslearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static void ClickSectionDetailsTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Section Details')]"));
        }
    }

    public class BatchEnrollmentModalCommand
    {
        public void EnrollUser(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='enrolled']/div/button"));
            Driver.waitforframe();

            Driver.GetElement(By.Id("SEARCH_FOR")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btnSearchClientSide']//span[@class='fa fa-search']"));
            Driver.clickEleJs(By.XPath("//td[contains(.,'" + v + "')]/preceding::input[1]"));
            Driver.clickEleJs(By.XPath("//input[@id='btnEnrollUsers']"));
            //Driver.Instance.SwitchTo().DefaultContent();
        }
    }

    public class EnrollmentTabCommand
    {
        public EnrollmentTabCommand()
        {
        }

        public bool? WaitlistedSubTab { get
            {
                Thread.Sleep(2000);
                return Driver.GetElement(By.XPath("//li[@id='waitlist-link']/a")).Displayed; } }

        public void ClickWaitlistedSubTab()
        {
            Driver.existsElement(By.XPath("//a[@href='#waitlisted']"));
            Driver.clickEleJs(By.XPath("//a[@href='#waitlisted']"));
            //Driver.Instance.Navigate().Refresh();
        }

        public bool SelectYes()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//td[5]/a"));
                SelectElement oSelect = new SelectElement(Driver.Instance.FindElement(By.XPath("//select[@class='form-control input-sm']")));
                oSelect.SelectByValue("1");
                result = true;
            }
            catch(Exception e)
            {

            }

            return result;

        }

        internal void BatchEnrollmentUsers()
        {
            throw new NotImplementedException();
        }

        internal void ClickEnrolButton()
        {
            throw new NotImplementedException();
        }

        public bool? isuserEnrolled()
        {
            return Driver.existsElement(By.XPath("//table[@id='enrolled-grid']//tbody"));
        }

        public void ClickEnrolled()
        {
            Driver.clickEleJs(By.XPath("//a[@href='#enrolled']"));
        }

        public void AddWaitListed()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'2')]"));
            Driver.clickEleJs(By.XPath("//button[contains(text(),'Waitlist Users')]"));
            Driver.clickEleJs(By.XPath("//table[@id='tableWaitlistUsers']/tbody/tr[1]/td[1]/input[1]"));
            Driver.clickEleJs(By.XPath("//button[@id='btnWaitlistUsers']"));

        }

        public void ClickWaitlistUsers()
        {
            Driver.existsElement(By.XPath("//div[@class='empty']//button[@type='button'][contains(text(),'Waitlist Users')]"));
            Driver.clickEleJs(By.XPath("//div[@class='empty']//button[@type='button'][contains(text(),'Waitlist Users')]"));
        }

        public void ImportRoster()
        {
            Driver.clickEleJs(By.XPath("//div[@id='enrolled']/div/button[2]"));
        }
    }
}