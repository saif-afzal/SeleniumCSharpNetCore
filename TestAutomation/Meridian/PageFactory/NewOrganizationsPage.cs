using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class NewOrganizationsPage
    {
        public static OrganizationCreateCommand OrganizationTitleAs(string v)
        {
            return new OrganizationCreateCommand(v);

        }

        public static bool? SuccessmessgeDisplay()
        {
            return Driver.GetElement(By.Id("ReturnFeedback")).Displayed;
        }
    }

    public class OrganizationCreateCommand
    {
        private string description;
        private string v;

        public OrganizationCreateCommand(string v)
        {
            this.v = v;
        }

        public OrganizationCreateCommand DescriptionAs(string Description)
        {
            this.description = Description;
            return this;
        }

        public void Create()
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_TITLE"));
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_TITLE")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_TITLE")).SendKeysWithSpace(v);
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_DESCRIPTION")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_DESCRIPTION")).SendKeysWithSpace(description);
            Driver.GetElement(By.Id("ML.BASE.BTN.Create")).ClickWithSpace();
            Thread.Sleep(3000);

        }
    }
}