using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using OpenQA.Selenium;

namespace Selenium2.Meridian.Suite
{
    internal class CurriculumsDetailsPage
    {
        public static EquivalenciesCommand Equivalencies
        {
            get { return new EquivalenciesCommand(); }
        }

        public static PrerequisitesCommand Prerequisites
        {
            get { return new PrerequisitesCommand(); }
        }

        public static PermissionsCommand Permissions
        {
            get { return new PermissionsCommand(); }
        }
        internal static void ClickAddEquivalencies()
        {
            throw new NotImplementedException();
        }

        internal static void Selectrecord(string v)
        {
            throw new NotImplementedException();
        }

        internal static string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }

        internal static void ClickBackbutton()
        {
            throw new NotImplementedException();
        }

        internal static bool? JSConfirmationMsg()
        {
            throw new NotImplementedException();
        }

        internal static void ClickRemovebutton()
        {
            throw new NotImplementedException();
        }

        internal static void ClickOpenItemButton()
        {
            Driver.clickEleJs(OpenQA.Selenium.By.Id("MainContent_ucCurriculumDetails_FormView1_CurrLaunchAttemptFirst"));
        }

        internal static void ClickEnrollButton()
        {
            Driver.clickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CurrEnrollButton"));
        }
    }
}