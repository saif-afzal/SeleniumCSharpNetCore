using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class JobTitlesPage
    {
        public static int DisplaySearchRecords
        {
            get
            {
                Thread.Sleep(5000);
                Driver.Instance.WaitForElement(By.XPath("//span[@class='PRE']"));
                string text = Driver.GetElement(By.XPath("//span[@class='PRE']")).Text;
                int retvalue = Driver.getIntegerFromString(text);
                Driver.Instance.Navigate_to_TrainingHome();
                return retvalue;
            }
        }

        public static FrameCommand Frame { get; internal set; }
        public static CompetenciesTabCommand CompetenciesTab
        {
            get { return new CompetenciesTabCommand(); }
        }

        //code commented for 17.3
        public static void SearchJobtitle(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='searchForJobtitle']"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-jobtitle-search']"));
            //  Driver.Instance.selectWindow("JobTitles");
            //Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));
            //Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));

        }

        public static bool? CheckRecords(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? JobCode(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? DescriptionValue(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? KeywordsValue(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? LocalizedinValue(string v)
        {
            throw new NotImplementedException();
        }

        public static void ClickButtonAssignCompetency()
        {
            throw new NotImplementedException();
        }

        public static bool? CheckJobTitle(string v)
        {
            return (Driver.GetElement(By.XPath(".//*[@id='job-title-edit-link']/em")).Text == v);
        }

        public static bool? CheckJobCode(string v)
        {
            return (Driver.GetElement(By.XPath(".//*[@id='edit-jobcode-link']")).Text == v);
        }

        public static bool? CheckDescriptionValue(string v)
        {
            return (Driver.GetElement(By.XPath(".//*[@id='edit-description-link']")).Text == v);
        }

        public static bool? CheckKeywordsValue(string v)
        {
            return (Driver.GetElement(By.XPath("//a[@id='edit-keywords-link']")).Text == v);
        }

        public static void EditJobtitlename(string v)
        {
            throw new NotImplementedException();
        }

        public static string VerifyText(By by1, object by2, string v)
        {
            throw new NotImplementedException();
        }

        public static string VerifyText(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public static void ClickCareerBreadcrumb()
        {
            throw new NotImplementedException();
        }

        public static void ClickCareerPath()
        {
            throw new NotImplementedException();
        }

        public static void ClickLevel2Expandlink()
        {
            throw new NotImplementedException();
        }

        public static string isJobtitle(string v)
        {
            throw new NotImplementedException();
        }
    }
}