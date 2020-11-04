using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class ProfessionalDevelopmentPage
    {

        public static bool? CheckNameColumn(string matchrecord)
        {
            return Driver.GetElement(By.XPath("//a[@class=' firepath-matching-node']")).Text == matchrecord;
        }
        public static CommonTabCommand CommonTab
        {
          get { return new CommonTabCommand(); }
        }

        public static CompetencyTabCommand CompetencyTab
        {
            get { return new CompetencyTabCommand(); }
        }

        public static bool? CheckCompetencyTitle { get; internal set; }
        public static JobTitlesTabCommand JobTitlesTab
        {
            get { return new JobTitlesTabCommand(); }
        }

        public static DevelopmentPlanCommand DevelopmentPlan { get { return new DevelopmentPlanCommand(); } }

        public static PendingDevPlan PendingDevPlan { get { return new PendingDevPlan(); } }

        public static ProfecionalFocusCommand ProfecionalFocus { get { return new ProfecionalFocusCommand(); } }

        public static void ClickCreateCareerPath()
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'Create Career Path')]"));
        }
        public static void SearchCareerPath(string record)
        {
            Driver.GetElement(By.XPath(".//*[@id='searchCareerPaths']")).SendKeysWithSpace(record);
            Driver.clickEleJs(By.XPath(".//*[@id='btn-search-paths']"));
        }
    

        public static void ClickCompetencyTab()
        {
            Driver.clickEleJs(By.XPath("//a[@aria-controls='competencies']"));

        }

        internal static bool? CheckCareerPathTitle(string Title)
        {
            return Driver.checkTitle(Title);
        }

        public static void ClickJobTitleTab()
        {
            Driver.clickEleJs(By.XPath(".//*[@id='jobtitlestab']"));
           // Driver.GetElement(By.XPath(""));
        }

        public static void SearchJobtitle(string v)
        {
            
            Driver.GetElement(By.XPath(".//*[@id='searchForJobtitle']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath(".//*[@id='btn-jobtitle-search']"));
        }

        public static bool? JobTittle(string v)
        {
            
          //  Driver.clickEleJs(By.XPath(""));
           return Driver.existsElement(By.XPath("//a[contains(.,'"+v+"')]"));
            
        }

        public static void ClickJobtittle(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'"+v+"')]"));
          //  Driver.GetElement(By.XPath(""));
            
        }

        public static void EditJobTitleName(string jobTitle)
        {
            Driver.clickEleJs(By.XPath("//a[@href='JobTitle.aspx']"));
            Driver.clickEleJs(By.XPath(".//*[@id='job-title-edit-link']/em"));
            Driver.GetElement(By.XPath(".//*[@id='job-title-edit']")).SendKeysWithSpace(jobTitle);
            Driver.clickEleJs(By.XPath(".//*[@id='btn-update-title']"));

        }

        internal static void ClickJobTitlesTab()
        {
            throw new NotImplementedException();
        }

        public static void ClickCompetencyTitle(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'"+v+"')]"));
        }

        public static bool? isDevelopmentPlanportletdisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='MainContent_UC2_pnlMyDevelopmentPlan']"));
        }

        public static bool? isdevplanOpened(string v)
        {
            Driver.existsElement(By.XPath("//h2[@class='h1 my-0 text-center font-bold']"));
            return Driver.GetElement(By.XPath("//h2[@class='h1 my-0 text-center font-bold']")).Text.Equals(v);
        }
    }

    public class ProfecionalFocusCommand
    {
        public ProfecionalFocusCommand()
        {
        }

        public ClickAddContentCommand AddContent { get { return new ClickAddContentCommand(); } }

        public bool? isExternallearnersubmitted()
        {
            return Driver.existsElement(By.XPath("//div[@class='panel panel-default']//tr[2]//td[1]"));
        }

        public bool? isRemoveExternalLearningicondisplay()
        {
            return Driver.existsElement(By.XPath("//span[@class='fa fa-fw fa-trash']"));
        }

        public void RemoveExternalLearning()
        {
            Driver.clickEleJs(By.XPath("//div[3]/a[2]/span"));
            Thread.Sleep(2000);
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

        }
    }

    public class PendingDevPlan
    {
        public PendingDevPlan()
        {
        }

        public GeneralDevelopmentCommand GeneralDevelopment { get { return new GeneralDevelopmentCommand(); } }
    }

    public class GeneralDevelopmentCommand
    {
        public ClickAddContentCommand ClickAddContent { get { return new ClickAddContentCommand(); } }

        public GeneralDevelopmentCommand()
        {
        }

        public string getContettitle()
        {
            return Driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC1_rgGeneralDevelopment_ctl00_ctl04_lbTitle1']")).Text;
        }

        public void ClickContentTitle(string v="")
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_UC1_rgGeneralDevelopment_ctl00_ctl04_lbTitle1']"));
        }

        public void ClickAddContentDropdown()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div[3]/div/div/div/div/button/span"));
        }

        public bool? isExternallearnersubmitted()
        {
            return Driver.existsElement(By.XPath("//div[@class='content-entry ml-16 mb-1 p-2 bg-b-05 sm:flex']"));
        }

        public bool? isviewdescriptionLinkdisplay()
        {
            return Driver.existsElement(By.LinkText("View Description"));
        }

        public void ClickviewdescriptionLink()
        {
            Driver.clickEleJs(By.LinkText("View Description"));
        }

        public bool? isDiscriptionmodaldisplay()
        {
            return Driver.existsElement(By.Id("viewDescriptionTitle"));
        }

        public void CloseDiscriptionmodal()
        {
            Driver.clickEleJs(By.XPath("//div[3]/div/div/div[3]/button"));
        }
    }

    public class ClickAddContentCommand
    {
        public ClickAddContentCommand()
        {
        }

        public bool? isExternalLearneingoptiondisplay()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_lnkGeneralDevAddExternal"));
        }

        public void clickExternallearning()
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_lnkGeneralDevAddExternal"));
        }

        public void SubmitExtrernalLearning(string title)
        {
            Driver.waitforframe();
            string format = "M/dd/yyyy";
            string obtaineddate = DateTime.Now.ToString(format);
            obtaineddate = obtaineddate.Replace("-", "/");
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_TITLE")).Clear();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_TITLE")).SendKeys(title);
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_DESCRIPTION")).Click();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_DESCRIPTION")).Clear();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_DESCRIPTION")).SendKeys("Ext Dec");
            Driver.Instance.FindElement(By.Id("MainContent_UC1_ELR_REASON")).Click();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_ELR_REASON")).Clear();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_ELR_REASON")).SendKeys("For Automation");
            Driver.Instance.FindElement(By.Id("modalMaster")).Clear();
            Driver.Instance.FindElement(By.Id("modalMaster")).SendKeysWithSpace(obtaineddate);
            Driver.Instance.FindElement(By.Id("MainContent_UC1_SubmitRequest")).Click();
        }
    }

    public class DevelopmentPlanCommand
    {
        public DevelopmentPlanCommand()
        {
        }

        public void ClickCreatePlan()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC2_btnCreateNewPlan']"));
        }

        public bool isdeveplandisplay(string v)
        {
            return Driver.GetElement(By.XPath("//strong[contains(text(),'New Development Plan for Somnath learner 101')]")).Text.Equals(v);
        }

        public void ClickexistingDevplan()
        {
            Driver.clickEleJs(By.XPath("//strong[contains(text(),'New Development Plan for Somnath learner 101')]"));
        }
    }

    public class JobTitlesTabCommand
    {
        public JobTitlesTabCommand()
        {
        }

        public bool? CheckJobTitles { get; internal set; }

        internal void ClickShowInActiveItemsCheckbox()
        {
            throw new NotImplementedException();
        }
    }

    public class CompetencyTabCommand
    {
        public CompentencyTitleCommand CompetencyTitle {
            get { return new CompentencyTitleCommand(); }
        }
        public string CompetencyTitle_CheckAssignedGroupsColumn
        { get { return Driver.GetElement(By.XPath(".//*[@id='list-competencies']/tbody/tr/td[4]")).Text; } }

        public CompetencyTabCommand()
        {
        }

        public void SearchCompetency(string v)
        {
            Driver.clickEleJs(By.XPath(".//*[@id='searchFor']"));
            Driver.GetElement(By.XPath(".//*[@id='searchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath(".//*[@id='btn-search']"));
           
        }

        public bool CheckCompetencyTitle(string v)
        {
            return Driver.existsElement(By.XPath("//em[contains(.,'" + v + "')]"));
        }

        internal void SearchRecord(string v)
        {
            throw new NotImplementedException();
        }

        internal void ClickCreateCompetency()
        {
            throw new NotImplementedException();
        }

        internal void ClickCompetency()
        {
            throw new NotImplementedException();
        }
    }

    public class CompentencyTitleCommand
    {
        public bool? CheckAssignedGroupsColumn { get; internal set; }
    }

    public class CommonTabCommand
    {
    
      
         

        public void ClickCreateCompetency()
        {
            Driver.clickEleJs(By.XPath(".//*[@id='has-competencies']/div[1]/div[3]/div/a"));
        }

        internal void ClickCompetency()
        {
            throw new NotImplementedException();
        }
    }
}