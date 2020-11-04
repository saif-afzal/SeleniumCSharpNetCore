using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    internal class AssignCompetencyModal
    {
        public static SelectCompetencyCommand SelectCompetency { get { return new SelectCompetencyCommand(); } }

        internal static void SearchCompetency(string competencyTitle)
        {
            Driver.GetElement(By.Id("SearchFor")).SendKeysWithSpace(competencyTitle);
            Driver.clickEleJs(By.Id("btn-search"));
            Driver.clickEleJs(By.XPath("//table[@id='find-competencies-table']/tbody/tr/td/input"));

        }
    }

    internal class SelectCompetencyCommand
    {
        public SelectCompetencyCommand()
        {
        }

        internal void clickAssign()
        {
            Driver.clickEleJs(By.XPath("//table[@id='find-competencies-table']/tbody/tr/td/input"));
            Driver.clickEleJs(By.Id("btn-assign-competencies"));
            Thread.Sleep(2000);

        }
    }
}