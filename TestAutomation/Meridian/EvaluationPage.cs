using System;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite
{
    public class EvaluationPage
    {
        public static TypeCommand Type { get { return new TypeCommand(); } }

        public static EvaluatormustmarkaspassfailCommand Evaluatormustmarkaspassfail { get { return new EvaluatormustmarkaspassfailCommand(); } }

        public static AvailableinCatalogCurriculumCommand AvailableinCatalog { get { return new AvailableinCatalogCurriculumCommand(); } }

        public static void CreateNewEvaluation(string p)
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(p);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }

        public static CreateEvaluationCommand Title(string v)
        {
            return new CreateEvaluationCommand(v);
        }

        public static bool? EvaluationTileis(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div/h2")).Text.StartsWith(v);
        }

        public static void ClickCanbeaddedtocontainersortrainingassignments()
        {
            Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_SRVY_INDEPENDENT_CONTENT']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_SRVY_INDEPENDENT_CONTENT']"));
        }
    }

    public class CreateEvaluationCommand
    {
        private string v;
        private string title;
        private string key;

        public CreateEvaluationCommand(string v)
        {
            this.v = v;
        }

        public CreateEvaluationCommand Keywors(string key)
        {
            this.key = key;
            return this;
        }

        public void Create()
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            Driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_FormView1_CNTLCL_KEYWORDS']")).SendKeys(key);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }

    public class EvaluatormustmarkaspassfailCommand
    {
        public EvaluatormustmarkaspassfailCommand()
        {
        }

        public bool? Defectvalue(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='option-survey-type-evaluation-switch']/div/div/div/div/span[3]")).Text.Equals(v);
        }
    }

    public class TypeCommand
    {
        public TypeCommand()
        {
        }

        public bool? isEvaluationSelected()
        {
            return Driver.GetElement(By.XPath("//label[contains(.,'Evaluation')]")).GetAttribute("checked").Equals("checked");
        }
    }
}