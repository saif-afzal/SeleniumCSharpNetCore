using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class EditSummaryPage
    {
        public static MenuCommands Menus
        {
             get { return new MenuCommands(); }
            
        }

        public static bool? SelectOptionsTab
        {
            get
            {
                Driver.Instance.WaitForElement(By.XPath("//div[@id='TabMenu_div0']/table/tbody/tr/td"));
                return Driver.GetElement(By.XPath("//div[@id='TabMenu_div0']/table/tbody/tr/td")).Displayed;
            }
        }

        public static SummaryTabCommand SummaryTab { get { return new SummaryTabCommand(); } }

        public static DisplayFormatCommand DisplayFormatDropdown { get { return new DisplayFormatCommand(); } }

        public static DisplayFormatDropdownForCertCommand DisplayFormatDropdownForCert { get { return new DisplayFormatDropdownForCertCommand(); } }

        public static OptionsTabCommand OptionsTab { get { return new OptionsTabCommand(); } }

        public static void ClickMenuTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='ML.BASE.WF.Menu']/span"));
            Thread.Sleep(2000);
        }

        public static void ClickOptionsTab()
        {
            Driver.clickEleJs(By.XPath("//div[3]/div/ul/li[5]/a/span"));
            Thread.Sleep(2000);
        }

        public static void ClickSavebutton()
        {
            if (Driver.existsElement(By.Id("MainContent_UC1_Save")))
            {
                Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
            }
            else if (Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save")))
            {
                Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            }
            else if (Driver.existsElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")))
            {
                Driver.GetElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")).ClickWithSpace();
            }
        }

        public static void addDescription(string v)
        {
            Driver.existsElement(By.XPath("//div[@class='fr-element fr-view']//p"));
         
            IWebElement descriptiontextbox = Driver.GetElement(By.XPath("//div[@class='fr-element fr-view']//p"));
            descriptiontextbox.Click();
            descriptiontextbox.Clear();
            descriptiontextbox.SendKeysWithSpace(v);
            descriptiontextbox.SendKeys(Keys.Tab);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

        //public static void Click_Savebutton()
        //{
        //    Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        //}
    }

    public class OptionsTabCommand
    {
        public OptionsTabCommand()
        {
        }

        public void AutomaticCurriculumnEnrolment(string v)
        {
            Driver.existsElement(By.XPath("//nobr[contains(text(),'Edit Configuration Options')]"));
            if(v=="On")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_AutoCurriculumEnrollment_0']"));
            }
            if(v=="Off")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_AutoCurriculumEnrollment_1']"));
            }
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }

        public bool? isAutoApproveDevelopmentPlan(string v)
        {
            Driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_AutoApproveDevelopmentPlan_1']"));
            if (v=="No")
            {
                return Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_AutoApproveDevelopmentPlan_1']")).Selected;
            }
            if (v == "Yes")
            {
                return Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_AutoApproveDevelopmentPlan_0']")).Selected;
            }
            else
                return false;
        }

        public void Save()
        {
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }

        public void SetAutoApproveDevelopmentPlan(string v)
        {
            if (v == "No")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_AutoApproveDevelopmentPlan_1']"));
            }
            if (v == "Yes")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditConfigOptions_AutoApproveDevelopmentPlan_0']"));
            }
        }
    }

    public class DisplayFormatDropdownForCertCommand
    {
        public DisplayFormatDropdownForCertCommand()
        {
        }

        public string SelectedText()
        {
            Driver.existsElement(By.XPath("//label[contains(text(),'Display Format')]/following::button"));
            return Driver.GetElement(By.XPath("//label[contains(text(),'Display Format')]/following::button")).Text;
        }
    }

    public class DisplayFormatCommand
    {
        public string SelectedText()
        {
            string s = string.Empty;
            Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']"));
            IList<IWebElement> options1= Driver.Instance.FindElements(By.XPath("//span[@class='filter-option pull-left']"));
            foreach (IWebElement option in options1)
            {
                s = option.Text;
                if(s!="")
                {
                    break;
                }
            }
            return s;
            //IList <IWebElement> options = Driver.Instance.FindElements(By.XPath("//body[@class='canvas']//div[@id='content']//div[@class='row']//div[@class='row']//li"));
            ////IList<IWebElement> options = select.FindElements(By.TagName("li"));
            ////return Driver.GetElement(By.XPath("//button[@class='btn dropdown-toggle btn-default']")).GetAttribute("Title");
            //IWebElement combobox = Driver.GetElement(By.XPath("//span[@class='filter-option pull-left']"));
            //SelectElement selectedValue = new SelectElement(combobox);
            //string selectedtext = selectedValue.SelectedOption.Text;
            //foreach (IWebElement option in options)
            //{
            //   string s= option.Text;
            //}
            //return "";
        }

        public void SelectanotherValue(string value="")
        {

            Driver.clickEleJs(By.XPath("//span[@class='filter-option pull-left']"));
            Driver.select(By.XPath("//select[@id='display_format']"), value);
        }

        public bool? VerfySelectedText(string displayFarmatText)
        {
            string s = string.Empty;
            Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']"));
            IList<IWebElement> options1 = Driver.Instance.FindElements(By.XPath("//span[@class='filter-option pull-left']"));
            foreach (IWebElement option in options1)
            {
                s = option.Text;
                if (s != "")
                {
                    break;
                }
            }
            return s.Contains(displayFarmatText);
            //Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']"));
            //string DisplayForamattextNew = Driver.GetElement(By.XPath("//span[@class='filter-option pull-left']")).Text;
            //if (!displayFarmatText.Contains(DisplayForamattextNew))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }

    public class SummaryTabCommand
    {
        public SummaryTabCommand()
        {
        }

        public PaymentTypesSectionCommand PaymentTypesSection { get { return new PaymentTypesSectionCommand(); } }
    }

    public class PaymentTypesSectionCommand
    {
        public PaymentTypesSectionCommand()
        {
        }

        public bool isNYDOHChecked()
        {
            
            bool result = false;
            try
            {
                Driver.Instance.FindElement(By.XPath(".//label[contains(.,'NYDOH')]/preceding::input[1]")).GetAttribute("checked");
                result = true;
            }
            catch { }
            return result;
        }
    }

    public class MenuCommands
    {
        public void ClickMenuTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='ML.BASE.WF.Menu']/span"));
            Thread.Sleep(2000);
        }

        public void ClickOptionsTab()
        {
            Driver.clickEleJs(By.Id("ML.BASE.WF.EditOptions"));
            Thread.Sleep(2000);
        }
    }
}