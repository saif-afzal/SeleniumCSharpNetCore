using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System.Threading;
using System;
using Selenium2.Meridian.Suite;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using ParallelTesting_Solution2;
using TestAutomation.helper;

namespace Selenium2.Meridian.Suite
{
    public class CareersPage:ObjectInit
    {
        private IWebDriver objDriver;
        public CareersPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  bool? _360EvaluationTabDisplay;

        public  bool? CheckNameColumn(string matchrecord)
        {
            return objDriver.GetElement(By.XPath("//a[@class=' firepath-matching-node']")).Text == matchrecord;
        }
        public  CommonTabCommand CommonTab
        {
            get { return new CommonTabCommand(objDriver); }
        }

        public  CompetencyTabCommand CompetencyTab
        {
            get { return new CompetencyTabCommand(objDriver); }
        }


        public  JobTitlesTabCommand JobTitlesTab
        {
            get { return new JobTitlesTabCommand(objDriver); }
        }

        public  ListofCompetenciesCommand ListofCompetencies
        {
            get { return new ListofCompetenciesCommand(objDriver); }
        }

        public  void ClickCreateCareerPath()
        {
            objDriver.existsElement(By.XPath("//a[contains(.,'Create Career Path')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Create Career Path')]"));
        }
        public  void SearchCareerPath(string record)
        {
            objDriver.GetElement(By.XPath(".//*[@id='searchCareerPaths']")).SendKeysWithSpace(record);
            objDriver.ClickEleJs(By.XPath(".//*[@id='btn-search-paths']"));
        }


        public  void ClickCompetencyTab()
        {
            objDriver.ClickEleJs(By.XPath("//a[@aria-controls='competencies']"));
            int i = 0;
           while(!objDriver.existsElement(By.XPath("//a[contains(@href, 'Competency.aspx')]")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@aria-controls='competencies']"));
                i = i + 1;
                if(i==10000)
                {
                    break;
                }
            }
            Thread.Sleep(10000);
        }

        public  bool? CheckCareerPathTitle(string Title)
        {
            return objDriver.checkTitle(Title);
        }

        public  void ClickJobTitleTab()
        {
            objDriver.existsElement(By.XPath(".//*[@id='jobtitlestab']"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='jobtitlestab']"));
            // objDriver.GetElement(By.XPath(""));
            Thread.Sleep(3000);
        }

        public  void SearchJobtitle(string v)
        {
            objDriver.GetElement(By.XPath(".//*[@id='searchForJobtitle']")).Clear();
            objDriver.GetElement(By.XPath(".//*[@id='searchForJobtitle']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath(".//*[@id='btn-jobtitle-search']"));
            Thread.Sleep(1000);
            //objDriver.WaitForElement(By.XPath("//a[contains(.,'" + v + "')]"));
        }

        public  bool? JobTitle(string v)
        {

            //  objDriver.ClickEleJs(By.XPath(""));
            return objDriver.existsElement(By.XPath("//a[contains(.,'" + v + "')]"));

        }

        public  void ClickJobtitle(string v)
        {
            objDriver.WaitForElement(By.XPath("//a[contains(.,'" + v + "')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]"));
            //  objDriver.GetElement(By.XPath(""));

        }

        public  void EditJobTitleName(string jobTitle)
        {
            objDriver.existsElement(By.XPath("//a[@id='createJobTitleBtn']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='createJobTitleBtn']"));
            objDriver.GetElement(By.XPath(".//*[@id='job-title-edit-link']/em")).ClickWithSpace();
            Thread.Sleep(3000);
            objDriver.GetElement(By.XPath(".//*[@id='job-title-edit']")).SendKeysWithSpace(jobTitle);
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath(".//*[@id='btn-update-title']"));
            Thread.Sleep(5000);

        }

        public  void ClickCompetencyTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]"));
        }

        public  void SelectSortDescending()
        {
            throw new NotImplementedException();
        }

        public  void SelectSortAscending()
        {
            throw new NotImplementedException();
        }

        public  void SelectCompleteIcon()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='filter-career-development']/div[2]/div/label[2]/span[2]"));
            Thread.Sleep(2000);
        }

        public  void SelectInProgressIcon()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='filter-career-development']/div[2]/div/label/span[2]"));
        }

        public  CareerPathTabCommand CareerPathTab
        {
            get { return new CareerPathTabCommand(objDriver); }
        }
        public  Template360TabCommand Chk360TemplatesTab
        {
            get { return new Template360TabCommand(objDriver); }
        }

        public  JobTitleCommand JobTitleKI
        {
            get { return new JobTitleCommand(objDriver); }
        }

      
        public  ProficiencyScaleTabCommand ProficiencyScaleTab
        {
            get { return new ProficiencyScaleTabCommand(objDriver); }
        }
        public  RatingCriteria_1_command RatingCriteria_1
        {
            get { return new RatingCriteria_1_command(objDriver); }
        }
        public  RatingCriteria_2_command RatingCriteria_2
        {
            get { return new RatingCriteria_2_command(objDriver); }
        }
        public  RatingCriteria_3_command RatingCriteria_3
        {
            get { return new RatingCriteria_3_command(objDriver); }
        }

        public  FrameCareersCommand FrameCareers
        {
            get { return new FrameCareersCommand(objDriver); }
        }

        public  CompetenciesTabCommand CompetenciesTab
        {
            get { return new CompetenciesTabCommand(objDriver); }
        }

    

     

    

        public  bool? RatingScaleModal_Labels_CheckRecord {
            get { return objDriver.GetElement(By.XPath("//div[@id='viewScale']/div/div/div[2]/ol/li/h4/span")).Text == "1"; }
        }
        public  bool? RatingScaleModal_Numbers_CheckRecord {
            get { return objDriver.existsElement(By.XPath("//div[@id='viewScale']/div/div/div[2]/ol/li/h4/span"));  }
        }
     
        public  bool? VerifyInstructionText
        {
            
            get { return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/p")).Text == "Define job responsibilities and create competencies to set training and proficiency targets."; }
        }

        public  bool? RatingScaleModal_NumbersandLabels_CheckRecord
        {
            get { return objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/ol/li/h4")).Displayed; }
        }

        public  ProficiencyScaleModalCommand CreateNewProficiencyScaleModel
        {
            get { return new ProficiencyScaleModalCommand(objDriver); }
            }

        public  bool? JobTitleTab { get { return objDriver.GetElement(By.XPath("//a[contains(text(),'Job Titles')]")).Displayed; } }

        public  bool? CareerPathTabDisplay { get { return objDriver.GetElement(By.XPath("//a[contains(text(),'Career Paths')]")).Displayed; } }
        public  bool? CompetenciesTabDisplay { get { return objDriver.GetElement(By.XPath("//a[contains(text(),'Competencies')]")).Displayed; } }
        public  bool? ProficiencyScaleTabDisplay { get { return objDriver.GetElement(By.XPath("//a[contains(text(),'Proficiency Scales')]")).Displayed; } }
        public  bool? NoCareerPathTab { get { return objDriver.existsElement(By.XPath("//a[contains(text(),'Career Paths')]")); } }

        public  bool? NoCompetenciesTab { get { return objDriver.existsElement(By.XPath("//a[contains(text(),'Competencies')]")); } }

        public  void ClickJobTitleTab_Mobile()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'Job Titles')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Job Titles')]"));
        }

        public  bool? NoProficiencyScaleTab { get { return objDriver.existsElement(By.XPath("//a[contains(text(),'Proficiency Scales')]")); } }

        public  bool? No360EvaluationTab { get { return objDriver.existsElement(By.XPath("//a[contains(text(),'360 Templates')]")); } }

        public  bool? EvaluationTabDisplay { get { return objDriver.GetElement(By.XPath("//a[contains(text(),'360 Templates')]")).Displayed; } }

        public  string GetSuccessMessage()
        {
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return objDriver.GetElement(By.XPath("//div[@id='MainContent_UC1_pnlCreateProfScale']/h2")).Text; //div[@id='MainContent_UC1_pnlCreateProfScale']/h2
        }

        public  void ClickTitleTextBox(string v)
        {
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).SendKeys(v);
            Thread.Sleep(2000);
        }

        public  void ClickCreateNewProficencyScale()
        {
            
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Create New Proficiency Scale')]"));
            Thread.Sleep(2000);
        }

        public  void ClickTab(string v)
        {
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]"));
            Thread.Sleep(5000);
        }

        public  void ClickCreatebutton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnCreate"));
        }

        public  void TitleTextBox(string v)
        {
            Thread.Sleep(2000);
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).SendKeysWithSpace(v);
        }

        public  void SearchTextBox(string v)
        {
            objDriver.GetElement(By.Id("MainContent_UC3_ctl40_SearchFor")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC3_ctl40_SearchFor")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
        }

        public  void SelectSearchType(string v)
        {
            objDriver.ClickEleJs(By.Id("MainContent_UC3_ctl40_SearchType"));
            objDriver.GetElement(By.Id("MainContent_UC3_ctl40_SearchType")).SendKeysWithSpace("Exact Phrase");
            //objDriver.select(By.XPath("//select[@id='MainContent_UC3_ctl40_SearchType']"),v);
        }

        public  void Searchbutton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_UC3_ctl40_btnSearchIdp"));
        }

        public  void CreateJobTitle(string v)
        {
            commonSection1.Manage.ProfessionalDevelopment();
            ClickJobTitleTab();
            EditJobTitleName(v);

        }

        public  void ClickSearchbutton()
        {
            throw new NotImplementedException();
        }

        public  void ClickEditButtonforRecord_RegressionScale()
        {
            objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_btnEditProficiencyScale"));
        }

        public  void ClickCopyButtonforRecord_Regression_Scale1()
        {
            objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_btnCopyProficiencyScale"));

        }

        public  void ClickArchiveButtonforRecord_RegressionScale1()
        {
            throw new NotImplementedException();
        }

       

    

    

        public  void ClickButtonCreateNewProficencyScale()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='has-scale']/div[2]/div[2]/a"));
          
        }

        public  void FillTitleTextBox(string v)
        {
            throw new NotImplementedException();
        }

        public  void ClickArchiveButtonforRecord_Regression_Scale1()
        {
            objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_btnArchiveProficiencyScale"));
        }

        public  void SearchTextBoxFill(string v)
        {
            throw new NotImplementedException();
        }

        public  void SearchTextBoxFill__SearchTypeSelection_ExactPhrase_ClickSearchbutton(string v)
        {
            throw new NotImplementedException();
        }

        public  void ClickLink_ViewArchivedScales()
        {
            objDriver.ClickEleJs(By.Id("MainContent_UC3_ctl40_htviewArchive"));
        }

        public  void DeleteJobTitle(String Jobtitle)
        {
            commonSection1.Manage.ProfessionalDevelopment();
            ClickJobTitleTab();
            SearchJobtitle(Jobtitle);
            objDriver.existsElement(By.XPath("//table[@id='table-jobtitles']/tbody/tr/td/input"));
            objDriver.ClickEleJs(By.XPath("//table[@id='table-jobtitles']/tbody/tr/td/input"));
            objDriver.ClickEleJs(By.Id("remove-jobtitle"));
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.Id("btn-remove-jobtitles"));


        }

        public  string NoMatchingJobTitleFound(string v)
        {
            objDriver.existsElement(By.XPath("//table[@id='table-jobtitles']/tbody/tr/td"));
            return objDriver.GetElement(By.XPath("//table[@id='table-jobtitles']/tbody/tr/td")).Text;
        }

        public  void FilterCompetenciesFor(string v)
        {
            objDriver.ClickEleJs(By.XPath(".//*[@id='filter-career-development']/div[1]/p/div/button"));
            objDriver.ClickEleJs(By.XPath("//span[contains(.,'"+ v +"')]"));

        }
        public  void ClickinfoIcon(string v)
        {
            objDriver.ClickEleJs(By.XPath("//span[@class='fa fa-info-circle fa-lg']"));
        }

      

      

        public  bool? CheckProficiencyScaleColumn_ClickView()
        {
            return objDriver.GetElement(By.XPath("//a[contains(text(),'View')]")).Text == "View";
        }

        public  void ClickProficiencyScalesTab()
        {
            
        }

        public  void ProficiencyScalesTab_ClickProficiencyScaleTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_lblTitle']"));
            Thread.Sleep(2000);
            //objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/h3"));
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/h3"));
        }



        public  void ClickButtonCreateCompetency()
        {
            throw new NotImplementedException();
        }

        public  void ClickCreateJobTitleButton()
        {
            objDriver.existsElement(By.XPath("//a[@id='createJobTitleBtn']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='createJobTitleBtn']"));
            objDriver.existsElement(By.XPath(".//*[@id='job-title-edit-link']/em"));
        }

        public  object SearchByJobTitle()
        {
            throw new NotImplementedException();
        }

        public  string SearchByJobTitle1()
        {
            throw new NotImplementedException();
        }

        public  string SearchByKeyword(string v,string v1)
        {
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//input[@id='searchFor']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-search']/i"));
            Thread.Sleep(2000);
            return objDriver.GetElement(By.LinkText(v1)).Text;
        }

        public  string SearchByDescription(string v, string v1)
        {
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//input[@id='searchFor']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-search']/i"));
            Thread.Sleep(2000);
            return objDriver.GetElement(By.LinkText(v1)).Text;
        }

        public  string SearchByCompetencyTitle(string v)
        {
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//input[@id='searchFor']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-search']/i"));
            Thread.Sleep(2000);
            return objDriver.GetElement(By.LinkText(v)).Text;
        }

        public  bool? ViewJobTitleButton()
        {
            throw new NotImplementedException();
        }

        //public  void SearchByCompetencyTitle(string v)
        //{
        //    throw new NotImplementedException();
        //}

        public  void ClickLinkCompetencyFromSearchResult()
        {
            throw new NotImplementedException();
        }

        public  void ClickJobtitlelink(string v)
        {
            throw new NotImplementedException();
        }

        public  bool? CheckCompetencyTitle(string competencyTitle)
        {
           
            objDriver.GetElement(By.ClassName("list-group-item")).Click();
            return objDriver.GetElement(By.XPath("//a[@id='DF99CA78FB5D4B50A0A0B1F31AB09B6C']/div/div/div/div[2]/p/strong")).Text == competencyTitle;
        }

   

        public  void ClickLocalizedInDropdown_SelectAddLocalization()
        {
            throw new NotImplementedException();
        }

        public  void ClickLocalizeButton()
        {
            throw new NotImplementedException();
        }

        public  void ClickAddKeywordslink_Edit(string v)
        {
            throw new NotImplementedException();
        }

        public  void Frame_ClickLocalizedin_select(string v)
        {
            throw new NotImplementedException();
        }

        public  void ClickLocalizedInDropdown_SelectEnglish(string v)
        {
            throw new NotImplementedException();
        }

        public  void ClickReg_Jobtittlelink_Edit(string v)
        {
            throw new NotImplementedException();
        }

        public  void ClickAddDescriptionLink_Edit(string v)
        {
            throw new NotImplementedException();
        }

        public  void ClickJobCodeLink_Edit(string v)
        {
            throw new NotImplementedException();
        }

        public  void clickCompetenciesColumn()
        {
            throw new NotImplementedException();
        }

        public  bool? sortingcompetencycolumn_verifysortingdescorder()
        {
            throw new NotImplementedException();
        }

        public  bool? sortingcompetencycolumn_verifydescendingorder()
        {
            throw new NotImplementedException();
        }

        public  bool? sortingcompetencycolumn_verifysortingascecorder()
        {
            Thread.Sleep(1000);
            string text1 = objDriver.GetElement(By.XPath(".//*[@id='jobtitle-competencies']/tbody/tr[1]/td[2]")).Text;
            string text2 = objDriver.GetElement(By.XPath(".//*[@id='jobtitle-competencies']/tbody/tr[2]/td[2]")).Text;
            objDriver.ClickEleJs(By.XPath(".//*[@id='jobtitle-competencies']/thead/tr/th[2]/a"));
            Thread.Sleep(2000);
            string text3 = objDriver.GetElement(By.XPath(".//*[@id='jobtitle-competencies']/tbody/tr[1]/td[2]")).Text;
            string text4 = objDriver.GetElement(By.XPath(".//*[@id='jobtitle-competencies']/tbody/tr[2]/td[2]")).Text;
            if ((text1 == text4) && (text2 == text3))
            {
                return true;
            }
            return false;
        }

        public  void SelectCheckboxForCompetency()
        {
            throw new NotImplementedException();
        }

        public  void ClickButtonDeleteForCompetency()
        {
            throw new NotImplementedException();
        }

        public  void ClickButtonCreateNewProficiencyScale()
        {
            throw new NotImplementedException();
        }

        public  void ClickOnJobTitleSearchResult(string v)
        {
            throw new NotImplementedException();
        }

        public  string GetProficiencyTitle()
        {
            return objDriver.FindElement(By.XPath("//a[@id='ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_lblTitle']")).Text;
        }

        public  string VerifySuccessMessage()
        {
            Thread.Sleep(5000);
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public  string GetProficiencyCreatedSuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public  string VerifyJobTitle(string v)
        {
            Thread.Sleep(10000);
            objDriver.existsElement(By.LinkText(v));
            return objDriver.GetElement(By.LinkText(v)).Text;
        }

        public  string VerifySearchinstructionText(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/p")).Text;
        }

        public  void ClickAnyrecordfromCareerPathListing()
        {
            objDriver.ClickEleJs(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td[2]/div/strong/a"));
            Thread.Sleep(2000);
        }

        public  void clickCareerPathTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]"));
        }

        public  void SearchJobtitlewithShowInactiveItems(string v)
        {
            objDriver.GetElement(By.XPath(".//*[@id='searchForJobtitle']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("showActiveJobTitles"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='btn-jobtitle-search']"));
            Thread.Sleep(1000);
        }

        public  bool? ProficeancyItemCount()
        {
            return objDriver.existsElement(By.XPath("//td/div/div/h3"));
        }

        public  bool? ProficeancyViewPopupClosed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='viewScale']/div/div/div[2]/ol/li/h4/span"));
        }

        public  void DeleteCareerPath(string v)
        {
            commonSection1.Manage.Careerstab();
            CareerPathTab.SearchCareerPath(v);
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//input[@name='btSelectAll']"));
            objDriver.WaitForElement(By.Id("remove-careerpath"));
            objDriver.ClickEleJs(By.Id("remove-careerpath"));
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.Id("btn-remove-careerpath"));

        }

        public  void CreateCompetency(string v)
        {
            commonSection1.Manage.ProfessionalDevelopment();
            ClickCompetencyTab();
            CommonTab.ClickCreateCompetency();
            createCompetencyPage1.EditCompetencyName(v);

        }

        public  void DeleteCompetency(string v)
        {
            commonSection1.Manage.ProfessionalDevelopment();
            ClickCompetencyTab();
            SearchByCompetencyTitle(v);
            objDriver.existsElement(By.XPath("//table[@id='list-competencies']/tbody/tr/td/input"));
            objDriver.ClickEleJs(By.XPath("//table[@id='list-competencies']/tbody/tr/td/input"));
            objDriver.ClickEleJs(By.Id("remove-competency"));
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.Id("btn-remove-competency"));
        }

        public  void CreateCareerPath(string v)
        {
            commonSection1.Manage.Careerstab();
            ClickCreateCareerPath();
            createCareerPathPage1.EditCareerPathName(v);
        }

        public  void ClickCareerPathTab()
        {
            objDriver.existsElement(By.XPath("//a[@id='careerpathtab']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='careerpathtab']"));
        }

        public  void CreateNewProficencyScale(string v1, string v2, string v3, string v4)
        {
            objDriver.ClickEleJs(By.LinkText("Create New Proficiency Scale"));
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).SendKeysWithSpace(v1);
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_0")).SendKeysWithSpace(v2);
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_1")).SendKeysWithSpace(v3);
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_2")).SendKeysWithSpace(v4);
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnCreate"));


        }

        public  bool? VerifyIsAddedJobTitleDisplay()
        {
            Thread.Sleep(10000);
            return objDriver.existsElement(By.XPath("//div[2]/table/tbody/tr/td/a"));
        }
    }

   
    public class CareerPathTabCommand
    {


        private IWebDriver objDriver;
        public CareerPathTabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public string VerifySearchText(string v)
        {
            Thread.Sleep(3000);
            objDriver.IsElementDisplayed_Generic(By.XPath("//a[contains(text(),'" + v + "')]"));  //a[contains(text(),'Career Paths')]
            objDriver.WaitForElement(By.XPath("//a[contains(text(),'" + v + "')]"));
            return objDriver.GetElement(By.XPath("//a[contains(text(),'" + v + "')]")).Text;
            // return objDriver.GetElement(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td[2]/div/strong/a")).Text;
        }

        public void CreateCareerPath()
        {
            if (objDriver.existsElement(By.XPath("//div[@id='careerpath-panel-empty']/a")))
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, 'CareerPath.aspx')]"));
            }
            else
            {
                objDriver.ClickEleJs(By.XPath("//*[@id='has-careerpaths']/div[2]/div[2]/a"));
            }
        }

        public void SearchCareerPath(string v)
        {
          
            objDriver.existsElement(By.Id("searchCareerPaths"));
            objDriver.GetElement(By.Id("searchCareerPaths")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//*[@id='btn-search-paths']/span"));
        }

        public string VerifySearchedRecordStatusText(string v)
        {
            Thread.Sleep(3000);
           // objDriver.WaitForElement(By.XPath("//a[contains(text(),'" + v + "')]"));
           return objDriver.GetElement(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td[2]/div/span")).Text;
        }

        public void ClickSearchResult(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'"+v+"')]"));
            objDriver.existsElement(By.LinkText("Levels and Job Titles"));
        }

        public void SelectShowInactiveItems()
        {
            objDriver.ClickEleJs(By.Id("showActivePaths"));
        }

        public bool? DeleteCareerPath(string v)
        {
            objDriver.existsElement(By.XPath("//td/input"));
            objDriver.ClickEleJs(By.XPath("//td/input"));
            objDriver.ClickEleJs(By.Id("remove-careerpath"));
            objDriver.WaitForElement(By.Id("btn-remove-careerpath"));
            objDriver.ClickEleJs(By.Id("btn-remove-careerpath"));
         return   objDriver.existsElement(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td"));
        }

        public string VerifySearchTextForTags(string v)
        {
            return objDriver.GetElement(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td[2]/div/span")).Text;
        }

        public bool? VerifyJobtitleSearchText(string v)
        {
            return objDriver.IsElementDisplayed_Generic(By.XPath("//a[contains(text(),'" + v + "')]"));
        }

        public string VerifyTabName(string v)
        {
            objDriver.existsElement(By.Id("careerpathtab"));
            return objDriver.GetElement(By.Id("careerpathtab")).Text;
        }
    }

    public class Template360TabCommand
    {
        private IWebDriver objDriver;
        public Template360TabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public bool? VerifyInstructionText
        {
            get { return objDriver.GetElement(By.XPath("//div[@id='has-evaluations']/div/p")).Text == "Use 360 templates as the basis for a user’s 360 evaluation."; }
        }

        public bool? VerifyText(string v)
        {
            return objDriver.GetElement(By.XPath("//a[contains(text(),'360 Templates')]")).Text == v;
        }
    }

    public class ProficiencyScaleTabCommand
    {
        private IWebDriver objDriver;
        public ProficiencyScaleTabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public bool? VerifyInstructionText
        {
            get { return objDriver.GetElement(By.XPath("//div[@id='has-scale']/p")).Text == "Proficiency scales are used to measure a person’s mastery of a competency. Scales currently assigned to a competency cannot be edited or deleted."; }
        }

        public ProficiencyScaleModalCommand ProficiencyScaleModal
        {
            get { return new ProficiencyScaleModalCommand(objDriver); }
        }
        public bool? VerifyText(string v)
        {
            return objDriver.GetElement(By.XPath("//a[contains(text(),'Proficiency Scales')]")).Text == v;
        }

        public void ProficiencyScaleViewModal_CloseClick()
        {
            //objDriver.ClickEleJs(By.XPath("//html[@id='PageBody']/body/div[2]/div/div/a"));
            //// objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            //Actions action = new Actions(objDriver.Instance);
            //action.SendKeys(OpenQA.Selenium.Keys.F1);
            // objDriver.ClickEleJs(By.LinkText("Close"));
            objDriver.Navigate().Refresh();
        }

        public string VerifySearchResultTitle()
        {
            return objDriver.GetElement(By.Id("ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_lblTitle")).Text;
        }

        public string VerifySearchResultScale()
        {
            return objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00__0']/td[3]")).Text;
        }

        public string VerifyNoRecordsFoundisDsiplayed()
        {
            return objDriver.GetElement(By.XPath("//table[@id='ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00']/tbody/tr/td/span")).Text;
        }

        public string VerifyArchivedProficiencyScale()
        {
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return objDriver.GetElement(By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_lblTitle")).Text;
        }

        public void VerifyArchivedScaleisDeleted()
        {
            objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl02_ctl01_chkRemoveHeader"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnRemove"));
            objDriver.findandacceptalert();
            objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl02_ctl01_chkRemoveHeader"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnRemove"));
            objDriver.findandacceptalert();
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnCancel"));
            objDriver.SwitchTo().DefaultContent();

        }

        public bool VerifySearchResultsisMatchedWith(string v1, string v2)
        {
            //return objDriver.VerifySearchResultisMatchedwith(By.XPath("//table[@id='ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00']//tbody/tr"), v1, v2);
            return true;
        }

        public bool VerifyScaleisDeleted(int numberofrecords)
        {
            if (numberofrecords >= 1)
            {
                objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_chkRemove"));
            }
            else
            {
                objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl04_chkRemove"));
                objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC3_ctl40_rgProficiencyScale_ctl00_ctl06_chkRemove"));
            }
                objDriver.ClickEleJs(By.Id("MainContent_UC3_ctl40_btnRemove"));
            objDriver.findandacceptalert();
            return true;
            //return GetProficiencyCreatedSuccessMessage() == "The item was removed.";

        }
    }

    public class ProficiencyScaleModalCommand
    {
        private IWebDriver objDriver;
        public ProficiencyScaleModalCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void CreateNew(string v)
        {
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Thread.Sleep(2000);
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).SendKeysWithSpace(v);
        }
        public void EditProficiencyScale(string v1, string v2, string v3, string v4)
        {
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC1_PS_TITLE")).SendKeysWithSpace(v1);
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_0")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_0")).SendKeysWithSpace(v2);
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_1")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_1")).SendKeysWithSpace(v3);
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_2")).Clear();
            objDriver.GetElement(By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_2")).SendKeysWithSpace(v4);
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnEdit"));
            objDriver.SwitchTo().DefaultContent();
        }
    }

    public class CompetenciesTabCommand
    {
        private IWebDriver objDriver;
        public CompetenciesTabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public ListofCompetenciesCommand ListOfCompetencies
        {
            get { return new ListofCompetenciesCommand(objDriver); }
        }
        public bool AssignCompetency_CompetencyTitle_CheckProficiencyScale(string v)
        {
            return objDriver.GetElement(By.XPath("//div[2]/table/tbody/tr/td[5]")).Text == v;
        }
        public bool? VerifyInstructionText
        {
            get { return objDriver.GetElement(By.XPath("//div[@id='competencies']/p")).Text == "Use competencies to define skills, associate training, and set proficiency targets for a job title, organization, or user group."; }
        }

        public void ClickCompetencyTitle(string v)
        {
            objDriver.ClickEleJs(By.LinkText(v));
        }

        public void ClickInactiveItemsCheckbox()
        {
            objDriver.ClickEleJs(By.Id("showActiveCompetencies"));
        }

        public void ShowInactiveItems_CheckboxIsUncheck()
        {
            throw new NotImplementedException();
        }

        public void ClickAssignCompetency()
        {
            Thread.Sleep(5000);
            if(objDriver.existsElement(By.Id("btn-add-competency2")))
            {
                objDriver.ClickEleJs(By.Id("btn-add-competency2"));
            }
            objDriver.WaitForElement(By.Id("btn-add-competency"));
            objDriver.ClickEleJs(By.Id("btn-add-competency"));
        }

        public void ClickCompetency()
        {
            throw new NotImplementedException();
        }

        public bool? VerifyText(string v)
        {
            return objDriver.GetElement(By.XPath("//a[contains(text(),'Competencies')]")).Text == "Competencies";
        }

        public void ClickCareerPath(string v)
        {
            objDriver.existsElement(By.Id("spCareerPath"));
            objDriver.ClickEleJs(By.Id("spCareerPath"));
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath("//span[@id='pnlPath']/div[2]/div/div/div/div/button/span"));

        }

        public void SearchandSelect(string v)
        {
            objDriver.GetElement(By.XPath("//span[@id='pnlPath']/div[2]/div/div/div/div/div/div/input")).Clear();
            objDriver.GetElement(By.XPath("//span[@id='pnlPath']/div[2]/div/div/div/div/div/div/input")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
            //objDriver.selectdropdown(By.XPath("//span[@id='pnlPath']/div[2]/div/div/div/div/select"), v);
            //objDriver.GetElement(By.XPath("//span[@id='pnlPath']/div[2]/div/div/div/div/div/ul/li[122]/a")).ClickWithSpace();
            objDriver.ClickEleJs(By.CssSelector("li.active > a > span.text"));
        }

        public void clickyescheckmark()
        {
            objDriver.ClickEleJs(By.Id("btn-save-path-level"));
            Thread.Sleep(5000);
        }

        public void RemoveAllCompetency()
        {
            objDriver.ClickEleJs(By.XPath("//*[@id='jobtitle-competencies']/thead/tr/th[1]/div[1]/input"));
            objDriver.ClickEleJs(By.Id("btn-remove-competencies"));
            objDriver.ClickEleJs(By.Id("remove-competencies"));
        }

        public bool? VerifyProficiencyScale(string v)
        {
            return objDriver.GetElement(By.XPath("//*[@id='jobtitle-competencies']/tbody/tr[1]/td[6]")).Text == v;
        }

        public void CreateCarrerPathWithLevels(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }

    

    public class FrameCareersCommand
    {
        private IWebDriver objDriver;
        public FrameCareersCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void EditTitle(string v)
        {
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnCopy"));
            objDriver.SwitchtoDefaultContent();
        }
    }

    public class RatingCriteria_3_command
    {
        private IWebDriver objDriver;
        public RatingCriteria_3_command(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void Label(string v)
        {
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_rlvRating_PSI_LABEL_TITLE_2']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_rlvRating_PSI_LABEL_TITLE_2']")).SendKeysWithSpace(v);
            Thread.Sleep(1000);
        }
    }

    public class RatingCriteria_2_command
    {
        private IWebDriver objDriver;
        public RatingCriteria_2_command(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void Label(string v)
        {
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_rlvRating_PSI_LABEL_TITLE_1']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_rlvRating_PSI_LABEL_TITLE_1']")).SendKeysWithSpace(v);
            Thread.Sleep(1000);
        }
    }

    public class RatingCriteria_1_command
    {
        private IWebDriver objDriver;
        public RatingCriteria_1_command(IWebDriver objDriver)
        { 
        
            this.objDriver = objDriver;
        }
        public void Label(string v)
        {
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_rlvRating_PSI_LABEL_TITLE_0']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_rlvRating_PSI_LABEL_TITLE_0']")).SendKeysWithSpace(v);
            Thread.Sleep(1000);

        }
    }

    public class JobTitleCommand
    {
        private IWebDriver objDriver;
        public JobTitleCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public int DisplaySearchRecords
        {
            get
            {
                Thread.Sleep(5000);
                objDriver.WaitForElement(By.XPath(".//*[@id='table-jobtitles']/thead/tr/th[1]/div[1]/input"));
               
                int retvalue = objDriver.FindElements(By.XPath("//span[@class='fa fa-info-circle fa-lg']")).Count;
               
                return retvalue;
            }
        }

        public void SearchJobtitle(string v)
        {
            Thread.Sleep(5000);
            objDriver.GetElement(By.Id("searchForJobtitle")).SendKeysWithSpace(v);
               objDriver.ClickEleJs(By.XPath("//button[@id='btn-jobtitle-search']"));
        }

      
    }
  

    public class ListofCompetenciesCommand
    {
        private IWebDriver objDriver;
        public ListofCompetenciesCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool CompetencyTitle_CheckProficiencyScale(string proficiencyscale)
        {
            return objDriver.GetElement(By.XPath("//table[@id='list-competencies']/tbody/tr/td[5]")).Text.Contains(proficiencyscale);
        }

        public bool CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating(string v)
        {
            return objDriver.GetElement(By.XPath("//table[@id='list-competencies']/tbody/tr/td[5]")).Text.EndsWith(v);
        }

        public bool? CheckRecord { get; internal set; }
        public bool? CheckRecordIsActive { get; internal set; }
        public bool CheckRecordIsInactive
        {
          get { return true; }
        }
        public bool? CheckRecord_Active { get; internal set; }
        public bool? CheckRecord_CompletedStatus
        {
            //need to write code for positive case.
            get { return objDriver.GetElement(By.XPath("//span[@id='emptyCompleted']")).Text == "You have no completed competencies."; }
        }
        public bool? CheckRecord_InProgressStatus {
            get {return objDriver.GetElement(By.XPath("//a[@id='DF99CA78FB5D4B50A0A0B1F31AB09B6C']/div/div/div/div[2]/p/strong")).Displayed; }
                
        }
        public bool? InProgressStatus
        {
            get { return objDriver.GetElement(By.XPath("//div[@id='filter-career-development']/div[2]/div/label[2]/span[2]")).Displayed; }
        }
        public bool? SortDescending { get; internal set; }
    }

    public class JobTitlesTabCommand
    {
        private object get;
        private string count1;
        private string count2;

        private IWebDriver objDriver;
        public JobTitlesTabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public bool? CheckJobTitles { get; internal set; }
        public bool? VerifyInstructionText
        {
            get { return objDriver.GetElement(By.XPath("//div[@id='jobtitles']/p")).Text == "Job titles define a position and its responsibilities. Assign competencies to set training and proficiency targets."; }
        }

        public bool? StatusInActive { get { return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div/div/ul/li[3]/div/span")).Displayed; } }

      

        public void ClickShowInActiveItemsCheckbox()
        {
            objDriver.ClickEleJs(By.Id("showActiveJobTitles"));
            Thread.Sleep(2000);
        }

        public void ClickJobTitleName(string jobTitle)
        {
            objDriver.ClickEleJs(By.LinkText(jobTitle));
        }

        public string GetMessage()
        {
            return objDriver.GetElement(By.XPath(".//*[@id='jobtitles']/p")).Text;
        }

        public bool? VerifyText(string v)
        {
            return objDriver.GetElement(By.XPath("//a[contains(text(),'Job Titles')]")).Text == v;
        }

        public bool GetTotalJobTitles()
        {
            Thread.Sleep(2000);
            var TotalCount = objDriver.FindElement(By.XPath("//div[@id='has-jobtitles']/div[3]/div[2]/div[4]/div/span")).Text;
            String [] count=TotalCount.Split(' ');
           string count1 = count[5];
            ClickShowInActiveItemsCheckbox();
            Thread.Sleep(2000);
            var TotalCount1 = objDriver.FindElement(By.XPath("//div[@id='has-jobtitles']/div[3]/div[2]/div[4]/div/span")).Text;
            String[] count2 = TotalCount.Split(' ');
            if(!(count1.Equals(count2)))
            {
                return true;
            }
            return false;
            //return count1;    
        }

        public void SelectStatusInactive()
        {
            objDriver.existsElement(By.XPath("//button[@id='itemStatus']"));
            objDriver.ClickEleJs(By.XPath("//button[@id='itemStatus']"));
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//a[@id='inactiveStatus']"));
            Thread.Sleep(5000);
        }

        public void ClickCreateJobTitle()
        {
            objDriver.ClickEleJs(By.Id("createJobTitleBtn"));
        }

        public void ClickAssignCompetency()
        {
            objDriver.ClickEleJs(By.Id("btn-add-competency"));
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }

        public void SelectStatusActive()
        {
            objDriver.ClickEleJs(By.XPath("//button[@id='itemStatus']"));
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Active')]"));
            Thread.Sleep(5000);

        }

        public void DeleteJobTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//table[@id='table-jobtitles']/tbody/tr/td/input"));
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.Id("remove-jobtitle"));
            objDriver.WaitForElement(By.Id("btn-remove-jobtitles"));
            objDriver.ClickEleJs(By.Id("btn-remove-jobtitles"));
           // return objDriver.existsElement(By.XPath("//table[@id='list-careerpaths']/tbody/tr/td"));
        }

        public void SearchJobTitle(string v)
        {
            objDriver.GetElement(By.Id("searchForJobtitle")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//button[@id='btn-jobtitle-search']/i"));
        }

        public bool? Nomatchingrecordsfound()
        {
            objDriver.existsElement(By.XPath("//table[@id='table-jobtitles']/tbody/tr/td"));
            return objDriver.GetElement(By.XPath("//table[@id='table-jobtitles']/tbody/tr/td")).Displayed;


        }
    }

    public class CompetencyTabCommand
    {
        private IWebDriver objDriver;
        public CompetencyTabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public CompetencyTabCommand CompetencyTitle
        {
            get { return new CompetencyTabCommand(objDriver); }
        }
        public int CompetencyTitle_CheckAssignedGroupsColumn
        { get
            {string number= objDriver.GetElement(By.XPath(".//*[@id='list-competencies']/tbody/tr/td[4]")).Text;
                return objDriver.getIntegerFromString(number); }
        }

      

        public void SearchCompetency(string v)
        {
            objDriver.ClickEleJs(By.XPath(".//*[@id='searchFor']"));
            objDriver.GetElement(By.XPath(".//*[@id='searchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath(".//*[@id='btn-search']"));
            Thread.Sleep(2000);

        }

        public bool CheckCompetencyTitle(string v)
        {
            return objDriver.existsElement(By.XPath("//em[contains(.,'" + v + "')]"));
        }

        public void SearchRecord(string v)
        {
            throw new NotImplementedException();
        }

        public void ClickCreateCompetency()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Create Competency')]"));
        }

        public void ClickCompetency()
        {
            throw new NotImplementedException();
        }

        public void ProficiencyScaleColumn_ClickView()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'View')]"));
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }

        public void ProficiencyScaleViewModal_CloseClick()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='viewScale']/div/div/div/button/span"));
        }

        public void ClickCompetencyTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//em[contains(.,'" + v + "')]"));
        }

        public int GetNumberOfRecords()
        {
            Thread.Sleep(5000);
          var str=  objDriver.GetElement(By.XPath("//div[@id='has-competencies']/div[3]/div[2]/div[4]/div/span")).Text;
            str = str.Replace("Showing 1 to 10 of ", "");
            return objDriver.getIntegerFromString(str);
          
        }
    }

    public class CompetencyTitleCommand
    {
        private IWebDriver objDriver;
        public CompetencyTitleCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? CheckAssignedGroupsColumn {
            get { return objDriver.GetElement(By.XPath("//table[@id='assigned_entities']/tbody/tr/td[2]")).Displayed; }
        }
    }

    public class CommonTabCommand
    {
        private IWebDriver objDriver;
        public CommonTabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }



        public void ClickCreateCompetency()
        {
            objDriver.existsElement(By.XPath(".//*[@id='has-competencies']/div[2]/div[2]/a"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='has-competencies']/div[2]/div[2]/a"));
        }

        public void ClickCompetency()
        {
            throw new NotImplementedException();
        }
    }
}