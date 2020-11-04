using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class SurveycosolePage
    {
        public static SurveysTabCommand SurveysTab { get { return new SurveysTabCommand(); } }

        public static CreateCommand Create { get { return new CreateCommand(); } }

        public static ItemTabCommand ItemTab { get { return new ItemTabCommand(); } }

        public static LearnerEvaluationTabCommand LearnerEvaluationTab { get { return new LearnerEvaluationTabCommand(); } }

        public static bool? SurveysTabisLearningEvaluationssarePresent()
        {
            return Driver.existsElement(By.XPath("//li[@id='evalsTab']//a[contains(text(),'Learner Evaluations')]"));
        }

        public static void clickLearnerEvaluations()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Learner Evaluations')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Learner Evaluations')]"));
        }
    }

    public class LearnerEvaluationTabCommand
    {
        public CompletedTabCommand CompletedTab { get { return new CompletedTabCommand(); } }

        public LearnerEvaluationTabCommand()
        {
        }

        public bool? isCompltedTabdisplay()
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'Completed')]"));
        }

        public void ClickCompletedTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Completed')]"));
        }
    }

    public class CompletedTabCommand
    {
        public CompletedTabCommand()
        {
        }

        public bool? isCompletedEvalustiondisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-completed-evaluation']/tbody/tr/td"));
        }

        public bool? ColumnHeaders(string v1, string v2, string v3, string v4)
        {
            Driver.existsElement(By.XPath("//table[@id='table-completed-evaluation']/thead/tr/th/a"));
            Driver.existsElement(By.XPath("//table[@id='table-completed-evaluation']/thead/tr/th[2]/a"));
            Driver.existsElement(By.XPath("//table[@id='table-completed-evaluation']/thead/tr/th[3]/a"));
            return Driver.GetElement(By.XPath("//table[@id='table-completed-evaluation']/thead/tr/th[4]")).Text.EndsWith(v4);
        }
    }

    public class ItemTabCommand
    {
        public ItemTabCommand()
        {
        }

        public ResultTableCommand ResultTable { get { return new ResultTableCommand(); } }

        public void search(string v1, string v2)
        {
            if(v1=="Evaluation")
            {
                Driver.clickEleJs(By.XPath("//button[@id='search-filter']/span"));
                Driver.clickEleJs(By.LinkText("Evaluations"));
                Driver.GetElement(By.Id("SurveySearchFor")).Clear();
                Driver.GetElement(By.Id("SurveySearchFor")).SendKeysWithSpace(v2);
                Driver.clickEleJs(By.XPath("//button[@id='btnSearchSurveys']/span"));


            }
           
        }
    }

    public class ResultTableCommand
    {
        public ResultTableCommand()
        {
        }

        public void clickEvalustionTitle(string v)
        {
            Driver.existsElement(By.LinkText(v));
            Driver.clickEleJs(By.LinkText(v));
        }
    }

    public class CreateCommand
    {
        public CreateCommand()
        {
        }

        public void Evaluation()
        {
            Driver.existsElement(By.XPath("//div[@id='list-toolbar']/div/div/div[2]/button/span[3]"));
            Driver.clickEleJs(By.XPath("//div[@id='list-toolbar']/div/div/div[2]/button/span[3]"));
            Driver.clickEleJs(By.XPath("//div/div/div/div[2]/ul/li[2]/a"));
        }
    }

    public class SurveysTabCommand
    {
        public SurveysTabCommand()
        {
            

        }

        public void ClickCreateNewSurvey()
        {
            Driver.clickEleJs(By.XPath("//span[@class='visible-lg-inline visible-md-inline']"));
            Driver.clickEleJs(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(text(),'Survey')]"));
        }
    }
}