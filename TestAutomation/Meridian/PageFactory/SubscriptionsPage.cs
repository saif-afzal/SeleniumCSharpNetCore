using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class SubscriptionsPage
    {
        public static DisplayFormatCommandcert DisplayFormatDropdown { get { return new DisplayFormatCommandcert(); } }

        public static CreateSubscriptiosCommand TitleAs(string Title)
        {
            return new CreateSubscriptiosCommand(Title);
        }

    }
    public class DisplayFormatCommandcert
    {
    }

    public class CreateSubscriptiosCommand
    {
        private string DynamicDate;
        private string title;
        public CreateSubscriptiosCommand(string title)
        {
            this.title = title;
        }

        public CreateSubscriptiosCommand SubscriptionType(string DynamicDate)
        {
            this.DynamicDate = DynamicDate;
            return this;


        }

        public void Create()
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeys(title);
            Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_fvSubscription_SUBS_TYPE"));
            Driver.select(By.Id("MainContent_UC1_FormView1_fvSubscription_SUBS_TYPE"), DynamicDate);
            
            Driver.GetElement(By.Id("MainContent_UC1_FormView1_fvSubscription_SUB_TIME_PERIOD")).SendKeys("15");
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
              
        }

        
    }
}