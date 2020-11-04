using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class DevelopmentPlanPage
    {
        public static ProfecionalFocusCommand ProfecionalFocus { get { return new ProfecionalFocusCommand(); } }

        public static ProfessionalFocusSectionCommand ProfessionalFocusSection { get { return new ProfessionalFocusSectionCommand(); } }
    }

    public class ProfessionalFocusSectionCommand
    {
        public ProfessionalFocusSectionCommand()
        {
        }

        public void ClickContentListTrashIcon()
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_UC1_rgProfFocus_ctl00_ctl04_rgCompetencyActivities_ctl00_lnkCompRemoveActivityOrGoal']/span"));
            Thread.Sleep(2000);
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

        }
    }

    public class ProfecionalFocusCommand
    {
        public ProfecionalFocusCommand()
        {
        }

        public void ClickAddContent()
        {
            Driver.clickEleJs(By.Id("ctl00_MainContent_UC1_rgProfFocus_ctl00_ctl04_lbAddDevelopmentActivity1"));

        }

        public bool? ContentTypeisDisplay(string v)
        {
            return Driver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC1_rgProfFocus_ctl00__0']/td[2]/div[3]/div/div/ul/li"));
        }
    }
}