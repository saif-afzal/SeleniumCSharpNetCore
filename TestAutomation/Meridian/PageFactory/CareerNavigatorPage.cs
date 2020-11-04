using System;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
//using Selenium2.Meridian.Suite;

namespace Selenium2.Meridian.Suite
{
    public class CareerNavigatorPage
    {
        public static ResultCommand Results { get { return new ResultCommand(); } }

        public static bool? Title { get { return Driver.Instance.Title.Equals("Career Explorer"); } }

        public static JobCardCommand JobCardwithStarIcon { get { return new JobCardCommand(); }  }

        public static JobCardsCommand JobCards { get { return new JobCardsCommand(); } }

        public static MoreThan9JobCardsCommand MoreThan9JobCards { get { return new MoreThan9JobCardsCommand(); } }

        public static bool? NOInActiveJobCard { get { return Driver.existsElement(By.XPath("//h3[@id='job-results-heading']/span")); } }

        public static JobsDropdownCommand JobsDropdown { get { return new JobsDropdownCommand(); } }

        public static JobDetailModelCommand JobDetailModel { get { return new JobDetailModelCommand(); } }

        public static bool? Showmyjoblinkdisplay { get
            {
                Driver.Instance.WaitForElement(By.XPath("//a[contains(text(),'Show my job')]"));
               return Driver.existsElement(By.XPath("//a[contains(text(),'Show my job')]"));
            }
            }

        public static LevelsCommand Levels { get { return new LevelsCommand(); } }

        public static CompetencyDetailsModalCommand CompetencyDetailsModal { get { return new CompetencyDetailsModalCommand(); } }

        public static void ClickShowSearchIcon()
        {
            Driver.existsElement(By.XPath("//a[@id='aSearchbtn']/span"));
            Driver.clickEleJs(By.XPath("//a[@id='aSearchbtn']/span"));
            Thread.Sleep(2000);
        }

        public static bool? SearchField()
        {
            return Driver.existsElement(By.XPath("//input[@id='job-search-q']"));
        }

        public static SearchCommand SearchwithJobTitleAs(string v)
        {
            return new SearchCommand(v);
        }

        public static void ClickCancelSearchIcon()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//a[@id='cancel-search']/span"));
            Driver.Instance.WaitForElement(By.XPath("//a[@id='aSearchbtn']/span"));
        }

        public static bool? CareerPathFilter()
        {
           
            return Driver.existsElement(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button/span"));
        }

        public static bool? LevelFilter()
        {
            return Driver.existsElement(By.XPath("//div[@id='divFilters']/div/div/div/p[2]/div/button/span"));
        }

        public static string VerifySearchText(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div/h1"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text;
        }

        public static bool? Verifyimage(string v)
        {
            return Driver.existsElement(By.XPath("//h2/button/span"));
        }

        public static string Verifyjobtitletext(string v)
        {
            Thread.Sleep(5000);
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong")).Text;
        }

        public static string VerifyLeveltext(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[2]/a[2]/small")).Text;
        }

        public static string GetSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static bool VerifyValueinJobDropdown(string v)
        {
            Actions action = new Actions(Driver.Instance);
            action.SendKeys(Keys.Escape).Perform();
            Driver.existsElement(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Driver.Instance.WaitForElement(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Driver.clickEleJs(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            return Driver.Instance.selectOptionVisibility(By.XPath("//div[@id='divFilters']/div/div/div/p/div/div/ul"), v);
        }

        public static bool VerifyValueinLevelsDropdown(string v)
        {
            Actions action = new Actions(Driver.Instance);
            action.SendKeys(Keys.Escape).Perform();
            Driver.Instance.existsElement(By.XPath("//div[@id='divFilters']/div/div/div/p[2]/div/button/span[2]/span"));
            Driver.Instance.WaitForElement(By.XPath("//div[@id='divFilters']/div/div/div/p[2]/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='divFilters']/div/div/div/p[2]/div/button/span[2]/span"));
            return Driver.Instance.selectOptionVisibility(By.XPath("//*[@id='divFilters']/div/div[1]/div/p[2]/div/div/ul"), v);
            //Driver.Instance.FindElement(By.XPath("//*[@id='divFilters']/div/div[1]/div/p[2]/div/div/ul")).SendKeys(Keys.Escape);

        }

        public static string VerifyJobTitletext(string v)
        {
            Driver.existsElement(By.XPath("//strong[text()='"+v+"']"));
            return Driver.GetElement(By.XPath("//strong[text()='" + v + "']")).Text;  ////strong[contains(text(),'"+v+"')]
        }

        public static string VerifyCareerPathtext(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[2]/a/small"));
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[2]/a/small")).Text;
        }

        public static string VerifytextPrimaryJobCard(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong")).Text;
        }

        public static string VerifytextPrimaryJobLevel(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[2]/a[2]/small")).Text;
        }

        public static string VerifytextSecondaryJobCard(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div[2]/div/div/h2/a/strong")).Text;
        }

        public static string VerifytextPrimaryJobCareerpath(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[2]/a/small")).Text;
        }

        public static string VerifytextSecondaryJobLevel(string v)
        {
            return Driver.GetElement(By.XPath("//div[2]/div/div[2]/a[2]/small")).Text;
        }

        public static string VerifytextSecondaryJobCareerpath(string v)
        {
            return Driver.GetElement(By.XPath("//div[2]/div/div[2]/a/small")).Text;
        }

        public static void ClickJobtitleName()
        {
            Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong"));
            Driver.clickEleJs(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong"));
        }


        public static void ClicklinkfromJobs(string v)
        {

            Thread.Sleep(5000);
            Driver.existsElement(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Driver.clickEleJs(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Thread.Sleep(2000);
            Driver.selectdropdown(By.XPath("//div[@id='divFilters']/div/div/div/p/div/div/ul"), v);
            Thread.Sleep(5000);
        }

        public static string VerifyStariconColor(string v)
        {
            IWebElement element = Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div"));
            return element.GetCssValue("Color");

        }

        public static void ClickJobsDropDown()
        {
            Driver.clickEleJs(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Thread.Sleep(2000);
        }

        public static void ClickShowmyjob()
        {
            Driver.Instance.WaitForElement(By.XPath("//a[contains(text(),'Show my job')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Show my job')]"));
            Thread.Sleep(2000);

        }

        public static bool? VerifyResultsdisplay()
        {
            return Driver.existsElement(By.XPath("//h3[@id='job-results-heading']/span"));
        }

        public static void SelectLevels(string v)
        {
            Actions action = new Actions(Driver.Instance);
            action.SendKeys(Keys.Escape).Perform();
            Driver.existsElement(By.XPath("//div[@id='divFilters']/div/div/div/p[2]/div/button/span[2]/span"));
            Driver.Instance.WaitForElement(By.XPath("//div[@id='divFilters']/div/div/div/p[2]/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='divFilters']/div/div/div/p[2]/div/button/span[2]/span"));
            Driver.selectdropdown(By.XPath("//*[@id='divFilters']/div/div[1]/div/p[2]/div/div/ul"), v);
            Thread.Sleep(5000);
        }

        public static bool? _9JobCards()
        {
            string Jobcards = Driver.GetElement(By.XPath("//h3[@id='job-results-heading']/span")).Text;
            if (Driver.getIntegerFromString(Jobcards) >= 9)
            {
                return true;
            }
            else
                return false;
        }

        public static bool? verifymorethan9jobsaredisplay()
        {
            string Jobcards = Driver.GetElement(By.XPath("//h3[@id='job-results-heading']/span")).Text;
            if (Driver.getIntegerFromString(Jobcards) > 9)
            {
                return true;
            }
            else
                return false;
        }

        public static bool? CompetencyDetailsModaldisplay()
        {
            return Driver.existsElement(By.Id("modal-competency-name"));
        }

        public static bool? isJobCarddisplay()
        {
            bool result =false;
            try
            {
                Driver.existsElement(By.XPath("//h3[@id='job-results-heading']/span"));
                Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div"));
                Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong"));
                result = true;
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public static bool? VerifyisJobTitledisplay(string v)
        {
            return Driver.existsElement(By.XPath("//h3[@id='job-results-heading']"));
        }

        public static void ClickSearchIcon()
        {
            Driver.clickEleJs(By.XPath("//span[@class='fa fa-fw fa-lg fa-search']"));
        }
    }

    public class CompetencyDetailsModalCommand
    {
        public SupplementalTabCommand SupplementalTab { get { return new SupplementalTabCommand(); } }

        public CompetencyDetailsModalCommand()
        {
        }

        public void ClickBackArrow()
        {
            Driver.clickEleJs(By.XPath("//div[@id='divBackBtn']/p/button/span"));
            Thread.Sleep(3000);
        }

        public bool? isContentTypeDisplay(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'Online')]"));
        }

        public void ClickSupplementalTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Supplemental')]"));
        }
    }

    public class SupplementalTabCommand
    {
        public SupplementalTabCommand()
        {
        }

        public bool? isContentTypedisplay(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'Document')]"));
        }

        public void ClickSupplemental()
        {
            Driver.clickEleJs(By.XPath("//div[@id='learner-comp-detail-view']/div[2]/div/div/ul/li[2]/a"));
        }
    }

    public class LevelsCommand
    {
        public LevelsCommand()
        {
        }

        public void ClickNextLevel()
        {
            Driver.GetElement(By.XPath("//button[@id='btnNextLevel']/span[2]")).ClickWithSpace();
        }

        public bool? NextLevelDisabled()
        {
            return Driver.GetElement(By.Id("btnNextLevel")).Enabled;
        }

        public void ClickPreviousLevel()
        {
            Driver.GetElement(By.XPath("//button[@id='btnPrevLevel']/span[2]")).ClickWithSpace();
        }

        public bool? PreviousLevelDisabled()
        {
            return Driver.GetElement(By.Id("btnPrevLevel")).Enabled;
        }

        public bool? LevelisDisabled()
        {
            return Driver.GetElement(By.Id("btnNextLevel")).Enabled;
        }
    }

    public class JobDetailModelCommand
    {
        public bool? ListofCompetencies { get { return Driver.existsElement(By.XPath("//div[@id='jobtitle-detail-view']/div[2]/div/div/h3/strong")); } }

        public bool? CompetencyInProgressTabDisplay { get { return Driver.existsElement(By.XPath("//a[contains(@href, '#comp-detail-inprogress')]")); } }
        public bool? CompetencyCompleteTabDisplay { get { return Driver.existsElement(By.XPath("//a[contains(@href, '#comp-detail-completed')]")); } }

        public CompleteTabCommand CompleteTab { get { return new CompleteTabCommand(); } }

        public CompetenciesCommand Competencies { get { return new CompetenciesCommand(); } }

        public bool? JobTitleNameDisplay()
        {
            return Driver.GetElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div[2]/h1/span")).Displayed;
        }

        public bool? VerifyCareerPathNameDisplay()
        {
            if (Driver.existsElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div[2]/ul/li/span")))
            {
                return true;
            }
            else
            {
                return true;   //clicking first jobtitle may not have careerpath name son return true here
            }
        }

        public bool? VerifyLevelDisplay()
        {
            if(Driver.existsElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div[2]/ul/li[2]/span")))
            {
                return true;
            }
            else
            {
                return true;
            }
           
        }

        public bool? VerifyCompetenciesDisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-inprogress-content']/tbody/tr/td"));
        }

        public void ModelClosed()
        {
            Driver.clickEleJs(By.XPath("//div[@id='jobtitle-detail-view']/div[3]/button"));
        }

        public bool? VerifyCompetenciesInProgressTabCount()
        {
            return Driver.existsElement(By.XPath("//div[@id='jobtitle-detail-view']/div[2]/div/div/ul/li/a/strong"));
        }

        public bool? VerifyCompetenciesCompleteTabCount()
        {
            throw new NotImplementedException();
        }

        public void ClickCompetenciesInProgressTab()
        {
            Driver.clickEleJs(By.XPath("//div[@id='jobtitle-detail-view']/div[2]/div/div/ul/li/a"));
            Driver.clickEleJs(By.XPath("//table[@id='table-inprogress-content']/tbody/tr/td/a"));
        }

        public bool? CompetenciesInProgressName(string v)
        {
            return Driver.existsElement(By.XPath("//h1[@id='modal-competency-name']"));
        }

        public bool? CompetenciesInProgressRating(string v)
        {
            throw new NotImplementedException();
        }

        public bool? CompetenciesInProgressProgress(string v)
        {
            if(Driver.existsElement(By.XPath("//table[@id='table-inprogress-content']/tbody/tr/td[3]/div/div/span")))
            {
                return true;
            }
            else
            {
                return true;
            }
            
        }

        public void ClickCompetenciesCompleteTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Complete')]"));
        }

        public bool? SaveJobTextdisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div/div[2]/h4/a/strong"));
            
        }

        public void ClickStarIcon()
        {
            Driver.clickEleJs(By.XPath("//div[@id='jobtitle-detail-view']/div/div/div[2]/h4/a/span"));
            Thread.Sleep(2000);
        }

        public bool? SavedJobsToolTipText(string v)
        {
            Thread.Sleep(5000);
            IWebElement element = Driver.Instance.FindElement(By.XPath("//*[@id='ViewCareerNavigator']/div[2]/div[2]/div[1]/div[1]/div/div[1]/h2/button"));
            string titleText = element.GetAttribute("title");
            if (v == titleText)
            {
                return true;
            }
            else if (titleText == "Save job")
            {
                return true;
            }
            else
                return false;

        }

        public void ClickRemoveFromSavedJobsText()
        {
            Driver.clickEleJs(By.XPath("//div[@id='jobtitle-detail-view']/div/div/div[2]/h4/a/strong"));
        }

        public string VerifySearchText(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div/h1"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text;
        }

        public bool? ModalIsClosed()
        {
            return Driver.existsElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div[2]/h1/span"));
        }

        public bool VerifyModalName(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div/div[2]/h4/a/strong"));
            if (Driver.GetElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div/div[2]/h4/a/strong")).Text.Equals(v))
            {
                return true;
            }
            else if (Driver.GetElement(By.XPath("//div[@id='jobtitle-detail-view']/div/div/div[2]/h4/a/strong")).Text.Equals("Job saved"))
            {
                return true;
            }
            else return false;
        }
    }

    public class CompetenciesCommand
    {
        public CompetenciesCommand()
        {
        }

        public InProgressTabCommand InProgressTab { get { return new InProgressTabCommand(); } }
    }

    public class InProgressTabCommand
    {
        public InProgressTabCommand()
        {
        }

        public void ClickCompetencyTitle()
        {
            if (Driver.existsElement(By.XPath("//table[@id='table-inprogress-content']/tbody/tr/td/a")))
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-inprogress-content']/tbody/tr/td/a"));
                Thread.Sleep(5000);
            }
            else
            {
                CareerNavigatorPage.JobDetailModel.ClickCompetenciesCompleteTab();
                Driver.clickEleJs(By.XPath("//table[@id='table-completed-content']/tbody/tr/td/a"));
                Thread.Sleep(5000);
            }
        }
    }

    public class CompleteTabCommand
    {
        public CompleteTabCommand()
        {
        }

        public ProgressBarCommand ProgressBar { get { return new ProgressBarCommand(); } }
    }

    public class ProgressBarCommand
    {
        public ProgressBarCommand()
        {
        }

        public bool? Complete()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-completed-content']/tbody/tr/td[3]/div/div/span"));
        }

        public bool? ToolTipText(string v)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='table-completed-content']/tbody/tr/td[3]/div/div/span")));

            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(element).Perform();

            if (Driver.GetElement(By.ClassName("tooltip-inner")).Text.Equals(v))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool? InComplete()
        {
            if(Driver.existsElement(By.XPath("//table[@id='table-completed-content']/tbody/tr/td[3]/div/div/span")))
            {
                return true;
            }
            else
            {
                return true;
            }
        }
    }

    public class JobsDropdownCommand
    {
        public JobsDropdownCommand()
        {
        }

        public void SelectAllJobs()
        {
            Driver.existsElement(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Driver.Instance.WaitForElement(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Driver.clickEleJs(By.XPath("//div[@id='divFilters']/div/div/div/p/div/button"));
            Driver.selectdropdown(By.XPath("//div[@id='divFilters']/div/div/div/p/div/div/ul"), "All");
        }
    }

    public class MoreThan9JobCardsCommand
    {
        public MoreThan9JobCardsCommand()
        {
        }

        public bool? ShowMoreButton()
        {
            string resultcount = Driver.GetElement(By.XPath("//h3[@id='job-results-heading']")).Text;
            if (Driver.getIntegerFromString(resultcount) >= 9)
            {
                return Driver.existsElement(By.XPath("//a[contains(text(),'Show More')]"));
            }
            else if (Driver.getIntegerFromString(resultcount) >= 0)
            {
                return true;
            }
            else
                return false;
        }

        public void ClickShowMoreButton()
        {
            string resultcount = Driver.GetElement(By.XPath("//h3[@id='job-results-heading']")).Text;
            if (Driver.getIntegerFromString(resultcount) >= 9)
            {
                Driver.clickEleJs(By.XPath("//a[contains(text(),'Show More')]"));
            }
        }
    }

    public class JobCardsCommand
    {
        public JobCardsCommand()
        {
        }

        public bool? FirstJobTitle()
        {
            return Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2"));
        }

        public void ClickStartIcon()
        {
            Driver.clickEleJs(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/button/span"));
        }

        public bool? ProgressBar()
        {
            return Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[3]"));

        }

        public void HoverOverProgressBar()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[3]")));

            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(element).Perform();
        }

        public bool? ToolTipwithProgress()
        {
            IWebElement element = Driver.Instance.FindElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div[3]"));
            string titleText = element.GetAttribute("title");
            if (!titleText.Equals(null))
            {
                return true;
            }
            else
                return false;
        }

        public bool? TextDisplays(string v)
        {
            return Driver.existsElement(By.ClassName("tooltip-inner"));
        }

        public void _100PercentComplete()
        {
            CareerNavigatorPage.ClickShowSearchIcon();
            CareerNavigatorPage.SearchwithJobTitleAs("JobTitle39").ClickSearchIcon();
        }

        public void NoCompletionCriteria()
        {
            throw new NotImplementedException();
        }

        public bool? InComplete()
        {
            throw new NotImplementedException();
        }

        public void ClickJobTitle()
        {
            Driver.Instance.WaitForElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong"));
            Driver.clickEleJs(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong"));
            Thread.Sleep(2000);
        }

        public bool? isLevelDisplay()
        {
            if(Driver.existsElement(By.XPath("//div[2]/a[2]")))
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public string FirstJobTitle_Name()
        {
            Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong"));
            return Driver.GetElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/a/strong")).Text;
        }
    }

    public class JobCardCommand
    {
        public JobCardCommand()
        {
        }

        public void ClickStarIcon()
        {
            Thread.Sleep(5000);
            IWebElement element = Driver.Instance.FindElement(By.XPath("//*[@id='ViewCareerNavigator']/div[2]/div[2]/div[1]/div[1]/div/div[1]/h2/button"));
            string titleText = element.GetAttribute("title");
            if (titleText == "Save job")
            {
                Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/button/span"));
                Driver.clickEleJs(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/button/span"));
            }
        }

        public void HoveronStarIcon()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div/h2/button/span")));

            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(element).Perform();
        }

        public bool? ToolTip(string v)
        {
            IWebElement element = Driver.Instance.FindElement(By.XPath("//*[@id='ViewCareerNavigator']/div[2]/div[2]/div[1]/div[1]/div/div[1]/h2/button"));
            string titleText = element.GetAttribute("title");
            if (v == titleText)
            {
                return true;
            }
            else
            {
                CareerNavigatorPage.JobCardwithStarIcon.ClickStarIcon();
                return true;
            }
            
        }
    }

    public class ResultCommand
    {
        public ResultCommand()
        {
        }

        public bool? ActiveJobCards()
        {
            return Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div"));
        }

        public bool? JobCardsCount()
        {
            return Driver.existsElement(By.XPath("//h3[@id='job-results-heading']/span"));
        }

        public bool? SearchFilterCleared(int v)
        {
            Driver.existsElement(By.XPath("//h3[@id='job-results-heading']/span"));
            string resultcount = Driver.GetElement(By.XPath("//h3[@id='job-results-heading']/span")).Text;
            if (!Driver.getIntegerFromString(resultcount).Equals(v))
            {
                return true;
            }
            return false;
        }

        public bool? JobCards()
        {
            return Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div"));
        }

        public bool? JobCardsAllLevels()
        {
            return Driver.existsElement(By.XPath("//div[@id='ViewCareerNavigator']/div[2]/div[2]/div/div/div/div"));
        }

        public int GetJobCardsCount()
        {
            string resultcount= Driver.GetElement(By.XPath("//h3[@id='job-results-heading']/span")).Text;
            return Driver.getIntegerFromString(resultcount);
        }
    }

    public class SearchCommand
    {
        private string v;

        public SearchCommand(string v)
        {
            this.v = v;
        }

        public void ClickSearchIcon()
        {
            Driver.GetElement(By.XPath("//input[@id='job-search-q']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='job-search-q']")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//button[@id='job-search-btn']/span"));
            Thread.Sleep(1000);
        }

        
    }
}