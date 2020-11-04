using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class CreateCareerPathPage
    {
        private IWebDriver objDriver;
        public CreateCareerPathPage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public  LevelsandjobtitlesTabCommand LevelsandjobtitlesTab
        { get{return new LevelsandjobtitlesTabCommand(); }
        }

        public  ListofvareerPathCommand ListofCareerPath { get { return new ListofvareerPathCommand(objDriver); } }

        public  ConfirmBoxCommand ConfirmBox { get { return new ConfirmBoxCommand(objDriver); } }

        public  object LevelsandJobTitlesTab { get; internal set; }
        public  ChangeLevelModalCommand ChangeLevelModal { get { return new ChangeLevelModalCommand(objDriver); } }

        public  AddJobTitleCommand AddJobTitleModal()
        {
            return new AddJobTitleCommand(objDriver);
        }

        public  void EditCareerPathName(string v)
        {
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath(".//*[@id='careerpath-title-edit-link']/em"));
            objDriver.GetElement(By.XPath(".//*[@id='careerpath-title-edit']")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath(".//*[@id='btn-update-title']"));
            objDriver.existsElement(By.XPath("//a[contains(text(),'None')]"));


        }



        public  string GetSuccessMessage()
        {
            return objDriver.getSuccessMessage();
        }

        public  string CheckStatus(string v)
        {
            return objDriver.GetElement(By.XPath("//*[@id='liDateSet']/div/span")).Text;
        }

        public  void ClickCareerBreadcrumb()
        {
            // objDriver.getSuccessMessage();
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//*[@id='content']/div[1]/ol/li[2]/a"));
            Thread.Sleep(2000);

        }

        public  void ChangeStatus(string v)
        {
            objDriver.ClickEleJs(By.Id("itemStatus"));
            objDriver.ClickEleJs(By.Id("inactiveStatus"));
        }

        public  void SetActiveDates(string v1, string v2)
        {
            string format = "M/dd/yyyy";
            string startdate = DateTime.Now.AddDays(-5).ToString(format);
            startdate = startdate.Replace("-", "/");
            string enddate = DateTime.Now.AddDays(5).ToString(format);
            enddate = enddate.Replace("-", "/");
            objDriver.existsElement(By.XPath("//button[@id='itemStatus']/span"));
            objDriver.ClickEleJs(By.XPath("//button[@id='itemStatus']/span"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Set Active Dates')]"));
            //objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_START_DATE_popupButton"));
            //objDriver.ClickEleJs(By.XPath("//a[contains(text(),'4')]"));
            //objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_END_DATE_popupButton"));
            //objDriver.ClickEleJs(By.XPath("//a[contains(text(),'25')]"));
            objDriver.existsElement(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_START_DATE_dateInput"));
            objDriver.GetElement(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_START_DATE_dateInput")).Clear();
            objDriver.GetElement(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_START_DATE_dateInput")).SendKeysWithSpace(startdate);
            objDriver.GetElement(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_END_DATE_dateInput")).Clear();
            objDriver.GetElement(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_END_DATE_dateInput")).SendKeysWithSpace(enddate);
            IWebElement ele = objDriver.FindElement(By.Id("ctl00_MainContent_UC1_OBJ_ACTIVE_END_DATE_dateInput"));
            ele.SendKeys(Keys.Tab);
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btn_save_activitydate"));
            // throw new NotImplementedException();
        }

        public  bool VerifyDates(string v)
        {
            Thread.Sleep(5000);
            objDriver.WaitForElement(By.Id("dateSet"));
            return objDriver.existsElement(By.Id("dateSet"));
        }

        public  EditTagsCommand EditNoneLinkTabAs(string v)
        {
            return new EditTagsCommand(v);
        }

        public  string VerifyAddedTagName(string v)
        {
            objDriver.existsElement(By.LinkText(v));
            return objDriver.GetElement(By.LinkText(v)).Text;
        }
        public  bool VerifyAddedTagNameDisplay(string v)
        {
            return objDriver.existsElement(By.LinkText(v));
        }

        public  void ClickAddJobTitlebutton()
        {
            objDriver.ClickEleJs(By.Id("btn-add-jobtitle-in-outer"));
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }

        public  string SuccessfullMessage()
        {

            return objDriver.getSuccessMessage();

        }

        public  void ClickCreateLevelbutton()
        {
            objDriver.existsElement(By.XPath("//button[@id='btn-create-level-in']"));
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-create-level-in']"));
            Thread.Sleep(2000);  
        }

        public  string GetLevelText()
        {
            Thread.Sleep(5000);
            return objDriver.GetElement(By.Id("txt_level_D34E03EA004F411097A208285A01FDB3")).Text;
        }

        public  void ClickAddJobTitlebuttonafterLevelAdd()
        {
            Thread.Sleep(5000);
            objDriver.existsElement(By.Id("btn-add-jobtitle"));
            objDriver.ClickEleJs(By.Id("btn-add-jobtitle"));
            //objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));

        }

        public  void ClickCreateAnotherLevelbutton()
        {
            objDriver.existsElement(By.XPath("//button[@id='btn-create-level']"));
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//button[@id='btn-create-level']")).ClickWithSpace();
        }

        public  void ClickCreateLevelbuttonafterjobsadded()
        {
            Thread.Sleep(2000);
            objDriver.WaitForElement(By.XPath("//button[@id='btn-create-level-confirm']"));
            objDriver.GetElement(By.XPath("//button[@id='btn-create-level-confirm']")).ClickWithSpace();
            Thread.Sleep(2000);
        }

        public  string GetOnpageSuccessMessage()
        {
            if (objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div")))
            {
                return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
            }
            else
            {
                return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
            }
        }

        public  string VerifyCareerPathStatusText(string v)
        {
            if (objDriver.existsElement(By.XPath("//li[@id='liDateSet']/div/span")))
            {
                return objDriver.GetElement(By.XPath("//li[@id='liDateSet']/div/span")).Text;
            }
            else
            {
                Thread.Sleep(5000);
                return objDriver.GetElement(By.XPath("//li[@id='liDateSet']/div/span")).Text;
            }
        }
    }

    public class ChangeLevelModalCommand
    {
        private IWebDriver objDriver;
        public ChangeLevelModalCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? CancelButton { get { return objDriver.existsElement(By.XPath("//div[@id='change-level-modal']/div/div/div[3]/button")); } }

        public bool? IsClosed { get { return objDriver.existsElement(By.XPath("//div[@id='change-level-modal']/div/div/div/h4")); } }

        public MoveToLevelCommand MoveToLevel { get { return new MoveToLevelCommand(objDriver); } }

        public bool? SaveButton { get { return objDriver.existsElement(By.Id("btn-change-level")); } }

        public SelectLevelCommand SelectLevel { get { return new SelectLevelCommand(objDriver); } }

        internal void ClickSave()
        {
            objDriver.ClickEleJs(By.Id("btn-change-level"));
            Thread.Sleep(2000);
            objDriver.WaitForElement(By.XPath("//h3/a/span[2]"));
        }
    }

    public class SelectLevelCommand
    {
        private IWebDriver objDriver;
        public SelectLevelCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        internal void ClickCancel()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='change-level-modal']/div/div/div[3]/button"));
            Thread.Sleep(2000);
        }

        internal void select()
        {
            objDriver.GetElement(By.XPath("//div[9]/div/div/div[2]/div/div/button/span")).ClickWithSpace();
        }
    }

    public class MoveToLevelCommand
    {
        private IWebDriver objDriver;
        public MoveToLevelCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? LevelSelection { get { return objDriver.existsElement(By.XPath("//div[9]/div/div/div[2]/div/div/button/span")); } }
    }

    public class ConfirmBoxCommand
    {
        private IWebDriver objDriver;
        public ConfirmBoxCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void SelectConfirm()
        {
            objDriver.WaitForElement(By.XPath("//button[@id='btn-create-level-confirm']"));
            objDriver.GetElement(By.Id("btn-add-level-post-confirm")).ClickWithSpace();
            Thread.Sleep(10000);
        }

        public void SelectCancelConfirm()
        {
            objDriver.WaitForElement(By.XPath("//div[@id='add-level-confirm-modal']/div/div/div[3]/button"));
            objDriver.GetElement(By.XPath("//div[@id='add-level-confirm-modal']/div/div/div[3]/button")).ClickWithSpace();
            Thread.Sleep(2000);
        }
    }

    public class ListofvareerPathCommand
    {
        private IWebDriver objDriver;
        public ListofvareerPathCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? verifyjobtilecount(string v)
        {
            Thread.Sleep(3000);
            objDriver.existsElement(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td[4]"));
            
            if (objDriver.GetElement(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td[4]")).Text.Contains(v))
            { return true; }
            else
            { return false; }
        }
    }

    public class LevelsandjobtitlesTabCommand
    {
        private IWebDriver objDriver;
    public LevelsandjobtitlesTabCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
   
        public bool? CreateLevelButtondisplay { get { return objDriver.existsElement(By.XPath("//button[@id='btn-create-level-in']")); } }
        public bool? AddJobTitleButtondisplay { get { return objDriver.existsElement(By.XPath("//button[@id='btn-add-jobtitle-in-outer']")); }  }

        public bool? Level1display { get
            {
                objDriver.WaitForElement(By.XPath("//h3/a/span[2]"));
                return objDriver.existsElement(By.XPath("//h3/a/span[2]"));}
        }
        public bool? Message { get; internal set; }
        public bool? LevelOpenCondition { get; internal set; }
        public bool? Level2display { get { return objDriver.existsElement(By.XPath("//h3/a/span[2]")); } }
        public bool? AddJobTitleButtonafteraddlevel { get { return objDriver.existsElement(By.XPath("//button[@id='btn-add-jobtitle-in']/span")); } }

        public bool? JobTitlesAdded { get
            {
                Thread.Sleep(10000);
                return objDriver.existsElement(By.XPath("//table[@id='jobtitle-list-career-path']/tbody/tr/td/a"));
            }
        }

        public bool? JobTitlesAddedinLevel { get
            {
                objDriver.WaitForElement(By.XPath("//div[2]/table/tbody/tr/td/a"));
                return objDriver.existsElement(By.XPath("//div[2]/table/tbody/tr/td/a"));
            } }

        public PopuponLevelCommand PopUpOnLevel { get { return new PopuponLevelCommand(objDriver); } }

        public bool? PopUpClosed { get { return objDriver.existsElement(By.XPath("//*[@id='edit_title_popup_D365FCB9AC58468CA7A3FA3B62E63279']/div[2]")); } }
        
        
        public LevelCommand Level { get { return new LevelCommand(); } }

        public ExpandedLevelCommand ExpandedLevel { get { return new ExpandedLevelCommand(objDriver); } }

        public bool? Levels { get; internal set; }
        public bool? DestinationLevelExpanded { get
            {
                Thread.Sleep(15000);
                return objDriver.existsElement(By.XPath("//a[contains(text(),'Name')]"));
            }
        }
        public DestinationLevelCommand DestinationLevel { get { return new DestinationLevelCommand(objDriver); } }
        public OriginalLevelCommand OriginalLevel { get { return new OriginalLevelCommand(objDriver); } }

        public LevelsandjobtitlesTabCommand()
        {
        }

        public void ClickLevel()
        {
            Thread.Sleep(3000);
            //Actions clickExpand = new Actions(objDriver);
            //clickExpand.MoveToElement(objDriver.FindElement(By.XPath("//div[@id='divMainPanel_477D78B4527D4294AF2C560A3CC39B81']/div/div/div/h3/a/span"))).Click().Perform();
            objDriver.ClickEleJs(By.XPath("//h3/a/span[2]"));
            Thread.Sleep(2000);
        }

        public void ClickActionOptions()
        {
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//td[5]/div/a/span"));
        }

        public void ClickRemoveOption()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Remove')]"));
            Thread.Sleep(5000);

        }

        public string GetRemoveModalTitle()
        {
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return objDriver.GetElement(By.XPath("//div[@id='remove-jobtitle-modal']/div/div/div/h4")).Text;
        }

        public void RemoveJobTitleCancelClick()
        {
            objDriver.ClickEleJs(By.XPath("//div[7]/div/div/div[3]/button"));
        }

        public string GetRemoveModalText()
        {
            objDriver.WaitForElement(By.XPath("//div[@id='remove-jobtitle-modal']/div/div/div[2]"));
            Thread.Sleep(2000);
            return objDriver.GetElement(By.XPath("//div[@id='remove-jobtitle-modal']/div/div/div[2]")).Text;
        }

        public void RemoveJobTitleRemoveClick()
        {
            objDriver.ClickEleJs(By.Id("btn-remove-jobtitle"));
        }

        public bool? JobTitleReuslt(string v)
        {
            Thread.Sleep(10000);
            objDriver.existsElement(By.XPath("//button[@id='btn-create-level-in']"));
           
            if (objDriver.GetElement(By.XPath("//div[@id='panel-empty-outer']/p/strong")).Text == v)
            {
                return true;
            }
            else
                return false;
        }

        public bool? JobTitleReusltAfteraddLevel(string v)
        {
            if (objDriver.GetElement(By.XPath("//div[@id='level1']/div/div/p/strong/span")).Text == v)
            {
                return true;
            }
            else
                return false;
        }

        public void SelectAddJobTitleOption()
        {
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//div[4]/ul/li[3]/a/span"));
        }

        public void ClickRemoveOptiontoDeleteLevels()
        {
            objDriver.ClickEleJs(By.LinkText("Delete Level"));
            Thread.Sleep(2000);
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.GetElement(By.XPath("//button[@id='btn-remove-level']")).ClickWithSpace();
        }

        public void ClickActionOptionstoDeleteLevels()
        {
            Thread.Sleep(10000);
            objDriver.existsElement(By.XPath("//div[4]/ul/li[3]/a/span"));
            objDriver.ClickEleJs(By.XPath("//div[4]/ul/li[3]/a/span"));
            Thread.Sleep(2000);
        }

        public void ClickAddJobTitleafteraddLevel()
        {
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//button[@id='btn-add-jobtitle-in']/span")).ClickWithSpace();
        }

        public void ExpandLevel1()
        {
            Thread.Sleep(10000);
            objDriver.existsElement(By.XPath("//h3/a/span[2]"));
            objDriver.ClickEleJs(By.XPath("//h3/a/span[2]"));
            Thread.Sleep(3000);
        }

        public void ClickAddJobTitleafteraddLevel1()
        {
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//button[@id='btn-add-jobtitle']")).ClickWithSpace();
        }

        public void ClickActionOptionsonLevel()
        {
            objDriver.existsElement(By.XPath("//div[4]/ul/li[3]/a/span"));
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//div[4]/ul/li[3]/a/span")).ClickWithSpace();

        }

        public void SelectAddJobTitleOptiononLevel()
        {
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Add Job Title')]"));
        }

        public bool? TabNameDisplay()
        {
            Thread.Sleep(10000);
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Levels and Job Titles')]"));
        }

        public void ClickOnLevelPencilIcon()
        {
            objDriver.ClickEleJs(By.XPath("//h3/a[2]/span"));
        }

        public bool? NoNewNameSaved(string v)
        {
            string leveltext = objDriver.GetElement(By.XPath("//h3/a/span[2]")).Text;
            if (leveltext == v)
            {
                return true;
            }
            else
                return false;
        }

        public bool? NewNameSaved(string v)
        {
            if(objDriver.GetElement(By.XPath("//h3/a/span[2]")).Text==v)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClickCreateLevel()
        {
            objDriver.existsElement(By.Id("btn-create-level-in"));
            objDriver.ClickEleJs(By.Id("btn-create-level-in"));
            Thread.Sleep(5000);
        }

        public void ClickAddJobTitlebuttoninsideLevel()
        {
            objDriver.existsElement(By.XPath("//button[@id='btn-add-jobtitle-in']/span"));
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-add-jobtitle-in']/span"));
        }

        public void CreateAnotherLevel()
        {
            objDriver.existsElement(By.XPath("//button[@id='btn-create-level']"));
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-create-level']"));
        }

        public bool AddJobTitletoToPLevel()
        {
            bool result = false;
            try
            {


                Thread.Sleep(10000);
                objDriver.existsElement(By.XPath("//button[@id='btn-add-jobtitle-in']/span"));
                objDriver.ClickEleJs(By.XPath("//button[@id='btn-add-jobtitle-in']/span"));
                objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));

                objDriver.GetElement(By.Id("search-Jobtitles")).Clear();
                objDriver.GetElement(By.Id("search-Jobtitles")).SendKeysWithSpace("jobtitle");
                objDriver.ClickEleJs(By.XPath("//button[@id='btn-search-jobtitle']/span"));
                objDriver.existsElement(By.XPath("//table[@id='jobtitle-list']/tbody/tr/td/input"));
                objDriver.ClickEleJs(By.XPath("//table[@id='jobtitle-list']/tbody/tr/td/input"));
                objDriver.ClickEleJs(By.Id("btn-add-jobtitles"));
                Thread.Sleep(15000);
                objDriver.existsElement(By.LinkText("Name"));
                result = true;
            }
            catch
            { }
            return result;

        }
    }

    public class OriginalLevelCommand
    {
    private IWebDriver objDriver;
    public OriginalLevelCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? CheckNoJobTitle(int v)
        {
            string newtotalcount = objDriver.GetElement(By.XPath("//div[2]/div/div/div[2]/a")).Text;
            int newcount = objDriver.getIntegerFromString(newtotalcount);
            if (newcount < v)
            {
                return true;
            }
            else
                return false;
        }

        public bool? CheckJobTitleCount(int v)
        {
            string newtotalcount = objDriver.GetElement(By.XPath("//div[2]/a")).Text;
            int newcount = objDriver.getIntegerFromString(newtotalcount);
            if (newcount <= v)
            {
                return true;
            }
            else
                return false;
        }
    }
    }

public class DestinationLevelCommand
{
    private IWebDriver objDriver;
    public DestinationLevelCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? CheckJobTitle
    {
        get
        {
            Thread.Sleep(10000);
            return objDriver.existsElement(By.XPath("//div[2]/table/tbody/tr/td/a"));
        }
    }

    public bool? CheckJobTitleCount(int v)
    {
        objDriver.existsElement(By.XPath("//div[2]/div/div/div[2]/a"));
        string newtotalcount = objDriver.GetElement(By.XPath("//div[2]/div/div/div[2]/a")).Text;
        int newcount = objDriver.getIntegerFromString(newtotalcount);
        if (newcount >= v)
        {
            return true;
        }
        else
            return false;
    }
}


public class ExpandedLevelCommand
    {
    private IWebDriver objDriver;
    public ExpandedLevelCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public JobTitleCommand1 JobTitle { get { return new JobTitleCommand1(objDriver); } }
    }

public class JobTitleCommand1
{
    private IWebDriver objDriver;
    public JobTitleCommand1(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public ActionDropDownIconCommand ActionDropDownIcon { get { return new ActionDropDownIconCommand(objDriver); } }

    public void ClickActionDropDownIcon()
    {
        objDriver.ClickEleJs(By.XPath("//td[5]/div/a/span"));
    }

    public void MovetoOtherLevel()
    {
        objDriver.existsElement(By.XPath("//td[5]/div/a/span"));
        objDriver.ClickEleJs(By.XPath("//td[5]/div/a/span"));
        objDriver.existsElement(By.XPath("//html[@id='PageBody']/body/ul/li/a"));
        objDriver.ClickEleJs(By.XPath("//html[@id='PageBody']/body/ul/li/a"));
        objDriver.existsElement(By.Id("btn-change-level"));
        objDriver.ClickEleJs(By.Id("btn-change-level"));
        Thread.Sleep(5000);
    }
}

public class ActionDropDownIconCommand
{
    private IWebDriver objDriver;
    public ActionDropDownIconCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? NoChangeLevelOption { get { return objDriver.existsElement(By.XPath("//html[@id='PageBody']/body/ul/li/a")); } }

    public void SelectChangeLevelOption()
    {
        objDriver.ClickEleJs(By.XPath("//html[@id='PageBody']/body/ul/li/a"));
        Thread.Sleep(2000);
    }
}

public class LevelCommand
{
    private IWebDriver objDriver;
    public LevelCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? LowestLevelDownArrowDisabled { get { return objDriver.GetElement(By.XPath("//div[2]/div/div/div[4]/ul/li[2]/a/span")).Enabled; } }
    public bool? HighestLevelUpArrowDisabled { get { return objDriver.GetElement(By.XPath("//div[4]/ul/li/a/span")).Enabled; } }
    public bool? DownArrowDisabled { get { return objDriver.GetElement(By.XPath("//div[4]/ul/li[2]/a/span")).Enabled; } }
    public bool? UpArrowDisabled { get { return objDriver.GetElement(By.XPath("//div[4]/ul/li/a/span")).Enabled; } }

    public bool? Expanded { get { return objDriver.existsElement(By.XPath("//a[contains(text(),'Name')]")); } }

    public bool? ChangeLevelModal { get { return objDriver.existsElement(By.XPath("//div[@id='change-level-modal']/div/div/div/h4")); } }

    public LevelCommand()
    {
    }

    public void HoverDownArrow()
    {
        objDriver.existsElement((By.XPath("//div[4]/ul/li[2]/a/span")));
        WebDriverWait wait = new WebDriverWait(objDriver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[4]/ul/li[2]/a/span")));

        Actions action = new Actions(objDriver);
        action.MoveToElement(element).Perform();
    }

    public bool? DownArrowToolTip(string v)
    {
        IWebElement element = objDriver.FindElement(By.XPath("//div[4]/ul/li[2]/a/span"));
        string titleText = element.GetAttribute("aria-title");
        if (v == titleText)
        {
            return true;
        }
        else
            return false;
    }

    public void HoverUpArrow()
    {
        WebDriverWait wait = new WebDriverWait(objDriver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[2]/div/div/div[4]/ul/li/a/span")));

        Actions action = new Actions(objDriver);
        action.MoveToElement(element).Perform();
    }

    public bool? UpArrowToolTip(string v)
    {
        IWebElement element = objDriver.FindElement(By.XPath("//div[2]/div/div/div[4]/ul/li/a/span"));
        string titleText = element.GetAttribute("aria-title");
        if (v == titleText)
        {
            return true;
        }
        else
            return false;
    }

    public void ClickDownArrow()
    {
        IWebElement element = objDriver.FindElement(By.XPath("//div[4]/ul/li[2]/a/span"));
        element.ClickWithSpace();
        Thread.Sleep(3000);
        objDriver.WaitForElement(By.XPath("//div[4]/ul/li[2]/a/span"));
        objDriver.existsElement(By.XPath("//div[4]/ul/li[2]/a/span"));
    }

    public void ClickUpArrow()
    {
        IWebElement element = objDriver.FindElement(By.XPath("//div[2]/div/div/div[4]/ul/li/a/span"));
        element.ClickWithSpace();
        Thread.Sleep(3000);
        objDriver.WaitForElement(By.XPath("//div[2]/div/div/div[4]/ul/li/a/span"));
        objDriver.existsElement(By.XPath("//div[2]/div/div/div[4]/ul/li/a/span"));
    }

    public bool? MovedDown(string v)
    {
        Thread.Sleep(2000);
        objDriver.WaitForElement(By.XPath("//h3/a/span[2]"));
        string newtopleveltext = objDriver.GetElement(By.XPath("//h3/a/span[2]")).Text;
        if (!(v.ToLower() == newtopleveltext.ToLower()))
        {
            return true;
        }
        else
            return false;
    }

    public bool? MovedUp(string v)
    {
        Thread.Sleep(2000);
        objDriver.WaitForElement(By.XPath("//h3/a/span[2]"));
        string newtopleveltext = objDriver.GetElement(By.XPath("//h3/a/span[2]")).Text;
        if (!(v.ToLower() == newtopleveltext.ToLower()))
        {
            return true;
        }
        else
            return false;
    }

    public string levelText()
    {
        return objDriver.GetElement(By.XPath("//h3/a/span[2]")).Text;

    }

    public void ExpandLevelWithJobTitle()
    {
        objDriver.WaitForElement(By.XPath("//div[2]/div/div/div/h3/a/span[2]"));
        objDriver.ClickEleJs(By.XPath("//div[2]/div/div/div/h3/a/span[2]"));
    }

    public int jobcount()
    {
        string totalcount = objDriver.GetElement(By.XPath("//div[2]/div/div/div[2]/a")).Text;
        return objDriver.getIntegerFromString(totalcount);
    }

    public void ExpandLevelWithJobTitleforonlyOnelevel()
    {
        objDriver.GetElement(By.XPath("//h3/a/span[2]")).ClickWithSpace();
        Thread.Sleep(2000);
    }

    public string VisibleLevelText()
    {
        return objDriver.GetElement(By.XPath("//h3/a/span[2]")).Text;
    }

    public string JobtitleStatus()
    {
        return objDriver.GetElement(By.XPath("//div[2]/table/tbody/tr/td[2]")).Text;
    }

    public bool? CompetenciesCount()
    {
        string competenciesCounttext = objDriver.GetElement(By.XPath("//div[2]/table/tbody/tr/td[3]")).Text;
        int competenciesCount = objDriver.getIntegerFromString(competenciesCounttext);
        if (competenciesCount >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool? UsersCount()
    {
        string competenciesCounttext = objDriver.GetElement(By.XPath("//div[2]/table/tbody/tr/td[4]")).Text;
        int competenciesCount = objDriver.getIntegerFromString(competenciesCounttext);
        if (competenciesCount >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool? JobtitleinsideLevel1Display()
    {
        return objDriver.existsElement(By.XPath("//div[2]/table/tbody/tr/td/a"));
    }

    public string JobtitletextinsideLevel1(string jobtitletext)
    {
        objDriver.existsElement(By.XPath("//div[2]/table/tbody/tr/td/a"));
        return objDriver.GetElement(By.XPath("//div[2]/table/tbody/tr/td/a")).Text;
    }

    public int jobcountTopLevel()
    {
        string totalcount = objDriver.GetElement(By.XPath("//div[2]/a")).Text;
        return objDriver.getIntegerFromString(totalcount);
    }
}


public class PopuponLevelCommand
{
    private IWebDriver objDriver;
    public PopuponLevelCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? Display()
    {
        ////*[@id='edit_title_popup_9BC29AA1B0CB42C4A4B853F046C188A5']/div[2]
        //objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        return objDriver.existsElement(By.XPath("//div/form/div/div/div/input"));
    }

    public void HitKeyboardEscKey()
    {
        Actions action = new Actions(objDriver);
        action.SendKeys(Keys.Escape).Perform();
    }

    public void EnterNewName(string v)
    {
        objDriver.GetElement(By.XPath("//div/form/div/div/div/input")).Clear();
        objDriver.GetElement(By.XPath("//div/form/div/div/div/input")).SendKeysWithSpace(v);
    }

    public void ClickCancel()
    {
        objDriver.GetElement(By.XPath("//div[2]/div/button[2]")).ClickWithSpace();
    }

    public void ClickSave()
    {
        objDriver.ClickEleJs(By.XPath("//div[2]/div/button/span"));
        Thread.Sleep(2000);
    }
}

public class AddJobTitleCommand
{
    private IWebDriver objDriver;
    public AddJobTitleCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public string GetModalTitalText()
    {
        objDriver.existsElement(By.XPath("//div[@id='add-jobtitle-modal']/div/div/div/h4"));
        return objDriver.GetElement(By.XPath("//div[@id='add-jobtitle-modal']/div/div/div/h4")).Text;
    }

    public void ClickNeedtocreateanewjobtitle()
    {
        objDriver.ClickEleJs(By.LinkText("Need to create a new job title?"));
        objDriver.WaitForElement(By.Id("createNewTextbox"));
        Thread.Sleep(2000);
    }

    public void FillTextJobTitleNameTextbox(string v)
    {
        objDriver.GetElement(By.Id("createNewTextbox")).SendKeysWithSpace(v);
    }

    public void ClickCreateandAddButton()
    {
        Thread.Sleep(2000);
        objDriver.ClickEleJs(By.XPath("//button[@id='btn-create-add-jobtitle']"));
    }

    public bool? isLevelTextdisplay()
    {
        return objDriver.existsElement(By.XPath("//div[@id='divSelectLevelNewJobtitle']/div/button/span"));
    }
}

public class EditTagsCommand
    {
        private string v;
    private IWebDriver objDriver;
    public EditTagsCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public EditTagsCommand(string v)
        {
            this.v = v;
        }

    public void ClickSaveCheckmark()
    {
        objDriver.existsElement(By.XPath("//a[contains(text(),'None')]"));
        Thread.Sleep(2000);
        objDriver.ClickEleJs(By.XPath("//a[contains(text(),'None')]"));
        Thread.Sleep(2000);
        objDriver.GetElement(By.Id("s2id_autogen2")).ClickWithSpace();
        objDriver.GetElement(By.Id("s2id_autogen2")).SendKeys(v);
        objDriver.WaitForElement(By.Id("select2-drop"));
        objDriver.GetElement(By.XPath("//*[@id='select2-drop']/ul/li[1]")).ClickWithSpace();
        //objDriver.ClickEleJs(By.ClassName("select2-results-dept-0 select2-result select2-result-selectable select2-highlighted"));
        objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div/div/ul/li/span/div/form/div/div/div[2]/div/button/span"));
    }
    }
