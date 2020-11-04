using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CareerDevelopmentPage
    {
        public static AddJobsmodelwindowCommand AddJobsmodelwindow { get { return new AddJobsmodelwindowCommand(); } }

        public static SavedJobsPortletCommand SavedJobsPortlet { get { return new SavedJobsPortletCommand(); } }

        public static CompetencyModalCommand CompetencyModal { get { return new CompetencyModalCommand(); } }

        public static CompetencyCommand Competency { get { return new CompetencyCommand(); } }

        public static DevelopmentPlansSectionCommand DevelopmentPlansSection { get { return new DevelopmentPlansSectionCommand(); } }

        public static void ClickExploreCareersbutton()
        {
            Driver.existsElement(By.LinkText("Explore Careers"));
            Driver.clickEleJs(By.LinkText("Explore Careers"));
            Thread.Sleep(2000);
        }

        public static string GetSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static bool? CareerDevelopment()
        {
            return Driver.existsElement(By.XPath("//div[@id='content']/div/h1"));
        }

        public static void ClickCompetenciesWithCompletedRatings()
        {
            Driver.Instance.WaitForElement(By.XPath("//div/div/div[2]/p/strong"));
            Driver.clickEleJs(By.XPath("//div/div/div[2]/p/strong"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }

        public static void ClickCompetenciesWithNonRequireContent()
        {
            Driver.Instance.WaitForElement(By.XPath("//div/div/div[2]/p/strong"));
            Driver.clickEleJs(By.XPath("//a[3]/div/div/div/div[2]/p/strong"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }

        public static void ClickCompetenciesWithNoRatings()
        {
            Driver.existsElement(By.XPath("//a[4]/div/div/div/div[2]/p/strong"));
            Driver.clickEleJs(By.XPath("//a[2]/div/div/div/div[2]/p/strong"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }

        public static void ClicktoCompetenciesWithCompletedRatings(string v)
        {
            Driver.existsElement(By.XPath("//strong[text()='"+v+"']"));
            Driver.clickEleJs(By.XPath("//strong[text()='" + v + "']"));
        }
    }

    public class DevelopmentPlansSectionCommand
    {
        public DevelopmentPlansSectionCommand()
        {
        }

        public void ClickCreatePlan()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Create Plan')]"));
        }
    }

    public class CompetencyCommand
    {
        public CompetencyCommand()
        {
        }

        public bool? StatusIsComplete()
        {
            return Driver.existsElement(By.XPath("//div[3]/div/div/span"));
        }
        public bool? StatusIsCompleteForCompetencywithoutrating()
        {
            return Driver.existsElement(By.XPath("//a[2]/div/div[3]/div/div"));
        }

        public bool? InComplete()
        {
            Thread.Sleep(3000);
            return Driver.existsElement(By.XPath("//div[3]/div/div/span"));
        }
    }

    public class CompetencyModalCommand
    {
        public CompetencyModalCommand()
        {
        }

        public MandatoryTabCommand MandatoryTab { get { return new MandatoryTabCommand(); } }

        public bool? Display()
        {
            Thread.Sleep(5000);
            return Driver.existsElement(By.Id("modal-competency-name"));
        }
    }

    public class MandatoryTabCommand
    {
        public MandatoryTabCommand()
        {
        }

        public void ClickMandatoryContent()
        {
            try
            {
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("//table[@id='table-required-content']/tbody/tr/td/a"));
            }
            catch
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-required-content']/tbody/tr/td/a"));
            }
        }

        public void NoMandatoryContent()
        {
            try
            {
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("//div[@id='learner-comp-detail-view']/div[2]/div/div/ul[2]/li[2]/a"));
                Driver.clickEleJs(By.XPath("//table[@id='table-optional-content']/tbody/tr/td/a"));
            }
            catch
            {
                Driver.clickEleJs(By.XPath("//a[3]/div/div/div/div[2]/p/strong"));
                Driver.clickEleJs(By.XPath("//table[@id='table-optional-content']/tbody/tr/td/a"));
            }
        }
    }

    public class AddJobsmodelwindowCommand
    {
        public bool? IsClosed { get { return Driver.existsElement(By.XPath("//div[@id='find-jobtitles-modal']/div/div/div/h4")); } }

        public AddJobsmodelwindowCommand()
        {
        }

        public string VerifyJobmodelTitleText(string v)
        {
            //Driver.Instance.waitforframe(By.XPath(""));
            return Driver.GetElement(By.XPath("//div[@id='find-jobtitles-modal']/div/div/div/h4")).Text;
        }

        public void SearchTextwith(string v)
        {
            Driver.GetElement(By.Id("SearchFor")).Clear();
            Driver.GetElement(By.Id("SearchFor")).SendKeysWithSpace(v);
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//button[@id='btn-search']/span"));
            Driver.Instance.WaitForElement(By.XPath("//table[@id='find-jobtitles-table']/tbody/tr/td[2]"));
        }

        public void SelectrecordandAdd(string v)
        {
            Thread.Sleep(3000);
            Driver.clickEleJs(By.XPath("//table[@id='find-jobtitles-table']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-add']"));
            

        }

        public bool? NameColumn(string v, string v1, string v2, string v3)
        {
            bool result = false;
            try
            {
                Driver.GetElement(By.XPath("//th[2]/a")).Text.Equals(v);
                Driver.GetElement(By.XPath("//th[3]/a")).Text.Equals(v1);
                Driver.GetElement(By.XPath("//th[4]/a")).Text.Equals(v2);
                Driver.GetElement(By.XPath("//th[5]/a")).Text.Equals(v3);
                result = true;
            }
            catch
            {
                result= false;
            }
            return result;
            

        }

        public bool? PathColumn(string v)
        {
            if (Driver.GetElement(By.XPath("//th[3]/a")).Text == v)
            {
                return true;
            }
            else
                return false;
        }

        public bool? LevelColumn(string v)
        {
            if (Driver.GetElement(By.XPath("//th[4]/a")).Text == v)
            {
                return true;
            }
            else
                return false;
        }

        public bool? CompetenciesColumn(string v)
        {
            if (Driver.GetElement(By.XPath("//th[5]/a")).Text == v)
            {
                return true;
            }
            else
                return false;
        }

        public string Jobtitletext()
        {
            Driver.existsElement(By.XPath("//table[@id='find-jobtitles-table']/tbody/tr/td[2]"));
            return Driver.GetElement(By.XPath("//table[@id='find-jobtitles-table']/tbody/tr/td[2]")).Text;
        }
    }

    public class SavedJobsPortletCommand
    {
        public SavedJobsPortletCommand()
        {
        }

        public bool? JobCardAdded(string v)
        { 
                Thread.Sleep(5000);
            return Driver.existsElement(By.XPath("//strong[contains(text(),'"+v+"')]"));
               // return Driver.existsElement(By.XPath("//div[@id='MainContent_UC4_pnlMySavedJobs']/ul/li/div/div[2]/h4/strong"));
        }

        public JobsSavedCommand JobsSaved { get { return new JobsSavedCommand(); } }

        public bool JobCardRemoved(string v)
        {
            Thread.Sleep(5000);
            if(Driver.existsElement(By.XPath("//strong[contains(text(),'" + v + "')]")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClickAddbuttonfrosmSavedJobs()
        {
            Driver.Instance.WaitForElement(By.XPath("//button[@id='btn-add-saved-jobs']"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-saved-jobs']"));
            Thread.Sleep(2000);
        }

        public string VerifyaddedjobtitleText(string v)
        {
            Thread.Sleep(3000);
            Driver.Instance.WaitForElement(By.XPath("//div[@id='MainContent_UC4_pnlMySavedJobs']/ul/li/div/div[2]/h4/strong"));
            return Driver.GetElement(By.XPath("//div[@id='MainContent_UC4_pnlMySavedJobs']/ul/li/div/div[2]/h4/strong")).Text;
        }

        public void DeleteSaveJobCards()
        {
            Thread.Sleep(2000);
            if (Driver.existsElement(By.XPath("//div[@id='MainContent_UC4_pnlMySavedJobs']/ul/li/div/div[2]/h4/strong")))
            {
                Driver.clickEleJs(By.XPath("//div[3]/div/ul/li/a/span"));
                Driver.clickEleJs(By.XPath("//div[@id='confirm-remove-list']/div/div/div[3]/button[2]"));
                Thread.Sleep(5000);
            }
           
        }
    }

    public class JobsSavedCommand
    {
        public JobsSavedCommand()
        {
        }

        public bool? NamePathLevelCompetencies()
        {
            IWebElement JobtitleName = Driver.GetElement(By.XPath("//h4/strong"));
            IWebElement PathLevelCompetencies = Driver.GetElement(By.XPath("//div[@id='MainContent_UC4_pnlMySavedJobs']/ul/li/div/div[2]/small"));
            if (JobtitleName.Displayed || PathLevelCompetencies.Displayed)
            {
                return true;
            }
            else
                return false;
        }
    }
}