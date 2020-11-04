using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    internal class CarrerDevelopmentPage
    {
        public static bool? CheckCompetencyTitle(string v)
        {
            return Driver.existsElement(By.XPath("//strong[contains(.,'" + v + "')]"));
        }

        public static void FilterCompetenciesFor(string v)
        {
            Driver.clickEleJs(By.XPath(".//*[@id='filter-career-development']/div[1]/p/div/button"));
            Driver.clickEleJs(By.XPath(".//*[@id='filter-career-development']/div[1]/p/div/div/ul/li[5]/a/span[2]"));

        }
    }
}