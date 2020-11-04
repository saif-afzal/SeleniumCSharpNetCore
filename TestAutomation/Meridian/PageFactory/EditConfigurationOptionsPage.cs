using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class EditConfigurationOptionsPage
    {
        public static bool? Tabdisplay { get { return Driver.Instance.Title == "Edit Configuration Options"; } }

        public static CareerDevelopmentCommand EnableCareerDevelopment { get { return new CareerDevelopmentCommand(); } }

        public static EditConfigurationTabCommand EditConfigurationTab { get { return new EditConfigurationTabCommand(); } }

        public static string GetSuccessMessage()
        {
            Driver.Instance.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
            return Driver.GetElement(By.XPath("//span[@id='ReturnFeedback']")).Text;
        }

        public static string GetOptionValue()
        {
            return Driver.Instance.FindElement(By.XPath("//label[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_NamingContainer:Enable_ProfessionalDevelopment']/span")).Text;
        }

        public static void ClickSave()
        {
            Driver.GetElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")).ClickWithSpace();
            Thread.Sleep(2000);
        }

        public static bool? isSeftRegistrationisOn()
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_SelfRegistration_0"));
            return Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_SelfRegistration_0")).Selected;
        }

        public static void SetSeftRegistration(string v)
        {
            if(v=="Off")
            {
                Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_SelfRegistration_1"));
            }
            if (v == "On")
            {
                Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_SelfRegistration_0"));
            }
        }

        public static bool? isPublicCatalogYes()
        {
            return Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_EnablePublicCatalogDomain_0")).Selected;
        }


        public static void SetPublicCatalog(string v)
        {
            if(v=="No")
            {
                Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_EnablePublicCatalogDomain_1"));
            }
            if (v == "Yes")
            {
                Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_EnablePublicCatalogDomain_0"));
            }
        }
    }

    public class EditConfigurationTabCommand
    {
        public SelectOrganizationWindowCommand SelectOrganizationWindow { get { return new SelectOrganizationWindowCommand(); } }

        public EditConfigurationTabCommand()
        {
        }

        public bool? isDefaultOrganization(string v)
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_DM_DEFAULT_ORGANIZATION"));
            return Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_DM_DEFAULT_ORGANIZATION")).GetProperty("value").Equals(v);
        }

        public bool? isSelectbuttonisdisplay()
        {
            return Driver.existsElement(By.LinkText("Select"));
        }

        public void ClickSelect()
        {
            Driver.clickEleJs(By.LinkText("Select"));
        }

        public bool? isSelectOrganizationWindowOpen()
        {
            Driver.SelectChildWindow();
            Driver.existsElement(By.XPath("//div[@id='WorkSpaceTitleContainer']/h1"));
            return Driver.GetElement(By.XPath("//div[@id='WorkSpaceTitleContainer']/h1")).Text.Equals("Select Organization");

        }

        public bool? isOrgResetLinkdisplay()
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'Reset')]"));
        }

        public void ClickOrgResetLink()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Reset')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Reset')]"));
        }

        public bool? isEnablecontentleveleditingforsystememailsDisplay()
        {
            return Driver.existsElement(By.XPath("//span[contains(text(),'Enable content-level editing for system emails')]"));
        }

        public bool? isContentleveleditingforsystememailsisOn()
        {
            if (Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_EnableContentLevelEditingForSystemEmails_0']")).Selected)
            {
                return true;
            }
            else 
            {
                Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_EnableContentLevelEditingForSystemEmails_1']")).ClickWithSpace();
                return true;
            }
        }

        public string Contentleveleditingforsystememailsisselected()
        {
            if (Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_EnableContentLevelEditingForSystemEmails_0")).Selected)
            {
                return "yes";
            }
            if (Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_EnableContentLevelEditingForSystemEmails_1")).Selected)
            {
                return "no";
            }
            else
                return "no";
        }

        public void SetContentleveleditingforsystememailsisOn(string contentlevelseting)
        {
            if (contentlevelseting=="yes")
            {
                Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_EnableContentLevelEditingForSystemEmails_1"));
            }
            else
            {
                Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_EnableContentLevelEditingForSystemEmails_0"));
            }
        }

        public void ClickSave()
        {
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
            Thread.Sleep(5000);
        }

        public void ClickReturn()
        {
            Driver.clickEleJs(By.Id("Return"));
        }
    }

    public class SelectOrganizationWindowCommand
    {
        public SelectOrganizationWindowCommand()
        {
        }

        public void SelectOrg(string v)
        {
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys(v);
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_Organization_1_DOMAIN_MEMBERSHIP_1_0_ML.BASE.ORG.Sample1")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_Select")).Click();
            Driver.focusParentWindow();
        }
    }

    public class CareerDevelopmentCommand
    {
        public CareerDevelopmentCommand()
        {
        }

        public void ClickNo()
        {
            Driver.clickEleJs(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_Enable_ProfessionalDevelopment']/tbody/tr/td[2]/input"));
        }

        public void ClickYes()
        {
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_Enable_ProfessionalDevelopment_0']"));
        }
    }
}