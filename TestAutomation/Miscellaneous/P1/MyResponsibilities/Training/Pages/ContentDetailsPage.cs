using System;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class AdminContentDetailsPage
    {
        public static CategoriesCommand Categories { get; set; }
        public static bool? CheckEditDescription { get; set; }
        public static bool? CheckEditPassword { get; set; }
        public static void DeleteVesion(string v)
        {
            Driver.select(By.XPath("//select[@id='ddlVersionsAdded']"), v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_ctl00_btnDeleteVersion']"));
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//input[@value='Delete Version']"));
            Driver.Instance.SwitchtoDefaultContent();



        }

        public static string VerifyDeleteVersionSuccessMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static void ManageVersion_Delete(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ctl00_lnkManageVersions']"));
            Driver.clickEleJs(By.XPath("(//a[contains(text()," + v + ")])[2]/following::a[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgVersions_ctl00_ctl04_btnDeleteVersion']"));
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_deleteVersion']"));
            Driver.Instance.SwitchtoDefaultContent();


        }
        public static CostAndSalesTaxCommand CostAndSalesTax { get; set; }
        public static CourseFileCommand CourseFiles
        {
            get { return new CourseFileCommand(); }
        }
        public static CourseSettingsCommand CourseSettings { get; set; }
        public static PrerequisitesCommand Prerequisites { get; set; }
        public static CertificateCommand Certificate { get; set; }
        public static PermissionsCommand Permissions { get; set; }
        public static SummaryCommand Summary
        {
            get { return new SummaryCommand(); }
        }
        public static bool? GetTextForAccessApproval { get; set; }

        public static EquivalenciesCommand Equivalencies
        {
            get { return new EquivalenciesCommand(); }
        }
        public static AccessApprovalCommand AccessApproval { get { return new AccessApprovalCommand(); } }
        public static ContentSharingCommand ContentSharing { get; set; }
        public static ImageCommand Image { get; set; }
        public static ManageActivityCommand ManageActivity
        {
            get { return new ManageActivityCommand(); }
        }
        public static WindowCommand Window { get; set; }
        public static MobileSettingCommand MobileSettings { get; set; }
        public static SurveysCommand Surveys { get; set; }
        public static CourseInformationCommand CourseInformation { get { return new CourseInformationCommand(); } }
        public static CreditsCommand Credits { get { return new CreditsCommand(); } }

        public static OpenNewAttemptCommand ClickOpenNewAttemptbutton { get { return new OpenNewAttemptCommand(); } }

        public static DropDownToggleCommand DropDownToggle { get { return new DropDownToggleCommand(); }  }

        public static bool? ClickPreview(string type)
        {
            Driver.Instance.FindElement(By.Id("MainContent_ctl00_btnPreview")).ClickWithSpace();
            string wdwHandle = Driver.Instance.CurrentWindowHandle;
            IList<string> wdwTitle = Driver.Instance.WindowHandles;
            switch (type)
            {
                case "Scorm":
                    {
                        foreach (string dr in wdwTitle)
                        {
                            Driver.Instance.SwitchTo().Window(dr);
                            if (Driver.Instance.Title == "Meridian Global - Core Domain")
                            {
                                Driver.Instance.Close();
                                Driver.Instance.SwitchTo().Window(wdwHandle);
                                return true;
                            }

                        }
                        break;
                        
                    }
                default:
                    {
                        foreach (string dr in wdwTitle)
                        {
                            Driver.Instance.SwitchTo().Window(dr);
                            if (Driver.Instance.Title == "Google")
                            {
                                Driver.Instance.Close();
                                Driver.Instance.SwitchTo().Window(wdwHandle);
                                return true;
                            }

                        }
                        break;
                    }
                    
            }
            return false;
        }

        public static string GetSuccessMessage()
        {

            string rettext = Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            return rettext;
        }

        public static void DeleteScormCourse()
        {
           Driver.Instance.FindElement(By.XPath("//button[contains(.,'Toggle Dropdown')]")).ClickWithSpace();
           Driver.Instance.FindElement(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']")).ClickWithSpace();
           Driver.Instance.SwitchTo().Alert().Accept();
        }

        public static void ClickDeleteLocaleButton()
        {
            throw new NotImplementedException();
        }

        public static void Click_EditPrerequisitePanel()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));
        }

        public static void ClickAddLocaleButton()
        {
            Driver.Instance.FindElement(By.XPath("//input[@id='MainContent_ctl00_btnAddLocale']")).ClickWithSpace();

           
        }

        public static bool? VerifyIsPublishedTextDisplayed(string v)
        {
            Thread.Sleep(5000);
            return Driver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div[2]/p")).Text.Equals(v);
        }

        public static bool CheckEditTitle(string p)
        {
            string res = Driver.GetElement(By.XPath(".//*[@id='MainContent_pnlContent']/div[2]/div/div[1]/ul/li[1]/strong")).Text;
            return res == p;
        }

        public static bool? isContentopened(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='contentDetailsHeader']/div/h2"));
            return Driver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div/h2")).Text.StartsWith(v);
        }

        public static void ManageSurveyWhenSurveyTitleAvailable(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']"));

            Driver.clickEleJs(By.XPath("//a[@id='btnAssignSurvey']"));

            Driver.GetElement(By.XPath("//input[@id='survey_assign_searchfor']")).SendKeysWithSpace(v);

            Driver.clickEleJs(By.XPath("//a[@id='btnSearchAvailableSurveys']/span"));
            Thread.Sleep(3000);
            Driver.clickEleJs(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr[1]/td/input"));

            Driver.clickEleJs(By.XPath("//button[@id='btnAddSurveys']"));
        }

        public static bool CheckEditKeyword(string p)
        {
            string res = Driver.GetElement(By.XPath(".//*[@id='MainContent_pnlContent']/div[2]/div/div[1]/ul/li[2]/strong")).Text;
            return res == p;
        }

        public static bool GetTextForContentSharing(string p)
        {
            return Driver.Instance.FindElement(By.XPath(".//*[@id='MainContent_MainContent_ucActivity_pnlActivity']/div/p")).Text == p;
        }
        public static bool AddLocalCheck(string p)
        {
         bool res=Driver.checkDropDownItems(By.XPath(".//*[@id='ddlLocalesAdded']"), "Arabic");

         IWebElement dropdown = Driver.Instance.FindElement(By.XPath(".//*[@id='ddlLocalesAdded']"));
            SelectElement selectedValue= new SelectElement(dropdown);
            String selValue = selectedValue.SelectedOption.Text;
            if (res && selValue.Contains(p))
            {

                //Verify the default locale is marked in the selection/viewing listbox.

                //Verify the new locale(s) are created for the content item.
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ManageSurveys()
        {


            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']"));

            Driver.clickEleJs(By.XPath("//a[@id='btnAssignSurvey']"));

            Driver.clickEleJs(By.XPath("//a[@id='btnSearchAvailableSurveys']/span"));

            Driver.clickEleJs(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr[1]/td/input"));

            Driver.clickEleJs(By.XPath("//button[@id='btnAddSurveys']"));
        }

        public static void DeleteLocal()
        {
            Driver.select(By.Id("ddlLocalesAdded"), "Arabic");
            Driver.Instance.FindElement(By.Id("MainContent_ctl00_btnGo")).ClickWithSpace();
            Driver.Instance.FindElement(By.Id("MainContent_ctl00_btnDeleteLocale")).ClickWithSpace();

        }

        public static bool VerifyEquivalenciesText()
        {
            if (Driver.Instance.FindElement(By.XPath(".//*[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div[1]/p")).Text == "1 Assigned Equivalencies")
            {
                Driver.Instance.FindElement(By.XPath("//li[contains(.,'1 Content Items')]"));
                Driver.Instance.FindElement(By.XPath("//li[contains(.,'1 Individual Users')]"));
                Driver.Instance.FindElement(By.XPath("//li[contains(.,'0 Groups')]"));
                return true;
            }
            return false;
        }

        public static void ClickCheckInbutton()
        {
            if (Driver.existsElement(By.XPath("//a[contains(.,'Check-in')]")))
            Driver.clickEleJs(By.XPath("//a[contains(.,'Check-in')]"));
        }

        public static string GetRemovalSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static bool? CheckCourseTitle(string v)
        {
           return Driver.existsElement(By.XPath("//h1[contains(.,'"+v+"')]"));
        }

        public static void ClickOpenItembutton()
        {
           if(Driver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton']"));
                if (Driver.existsElement(By.TagName("iframe")))
                {
                    Driver.Instance.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                }
                    Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnCourseEnroll']"));
                Driver.clickEleJs(By.XPath("//input[@class='btn btn-primary']"));
            }
           else
            {
                Driver.clickEleJs(By.XPath("//input[@class='btn btn-primary']"));

            }
        }

        public static void SelectLocalization(string v)
        {
            Driver.clickEleJs(By.XPath("//button[@data-id='selectLanguage']"));
            Driver.clickEleJs(By.XPath("//span[contains(.,'"+v+"')]"));
        }

        public static void EditLocalization(string v1, string v2, string v3, string v4,string v5)
        {
            Driver.existsElement(By.XPath("//button[@data-id='selectLanguage']"));
            Driver.clickEleJs(By.XPath("//button[@data-id='selectLanguage']"));
            //Driver.clickEleJs(By.XPath("//span[contains(.,'French (Canada)')]"));

            Driver.clickEleJs(By.XPath("//span[contains(.,'Add Localization')]"));
          //  Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
           
            Driver.clickEleJs(By.XPath(".//*[@id='add-title-link']"));
            Driver.GetElement(By.XPath("//input[@class='form-control input-sm']")).SendKeysWithSpace(v1);
            Driver.clickEleJs(By.XPath("//div[@id='titleToLocalize']/span/div/form/div/div/div[2]/div/button/span"));
            Driver.clickEleJs(By.XPath(".//*[@id='add-description-link']"));
            Driver.GetElement(By.XPath(".//*[@id='localizeModal']/div/div/div[2]/div[3]/div/span/div/form/div/div[1]/div[1]/textarea")).SendKeysWithSpace(v2);
            Driver.GetElement(By.XPath(".//*[@id='localizeModal']/div/div/div[2]/div[3]/div/span/div/form/div/div[1]/div[2]/div/button[1]")).ClickWithSpace();
            Driver.clickEleJs(By.XPath(".//*[@id='add-jobcode-link']"));
            Driver.GetElement(By.XPath(".//*[@id='localizeModal']/div/div/div[2]/div[4]/div/span/div/form/div/div[1]/div[1]/input")).SendKeysWithSpace(v3);
            Driver.GetElement(By.XPath(".//*[@id='localizeModal']/div/div/div[2]/div[4]/div/span/div/form/div/div[1]/div[2]/div/button[1]")).Click();
            Driver.clickEleJs(By.XPath(".//*[@id='add-keywords-link']"));
            Driver.GetElement(By.XPath(".//*[@id='localizeModal']/div/div/div[2]/div[5]/div/span/div/form/div/div[1]/div[1]/input")).SendKeysWithSpace(v4);
            Driver.GetElement(By.XPath(".//*[@id='localizeModal']/div/div/div[2]/div[5]/div/span/div/form/div/div[1]/div[2]/div/button[1]")).Click();
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-locale']"));
            Driver.clickEleJs(By.XPath("//button[@data-id='selectLanguage']"));
            Driver.clickEleJs(By.XPath("//span[contains(.,'"+v5+"')]"));

        }

        public static bool? ClickResume()
        {
            throw new NotImplementedException();
        }

        public static string JobTitle_Title()
        {
            
            if(Driver.existsElement(By.XPath("//div[@id='content']/div/h1")))
            {
                return Driver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text;
            }
            else
            {
                return Driver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text;
            }
        }

        public static bool? CompetenciesTabDisplay()
        {
            return Driver.existsElement(By.LinkText("Competencies"));
        }

        public static bool? CheckResumeButton()
        {
            return Driver.existsElement(By.XPath("//input[@class='btn btn-primary']"));
        }

        public static bool? JobDetailstabDisplay()
        {
            return Driver.existsElement(By.LinkText("Job Details"));
        }

        public static void DeleteContent()
        {
           Driver.clickEleJs(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/button"));
            Driver.clickEleJs(By.XPath(".//*[@id='MainContent_header_FormView1_btnDelete']"));
            Driver.Instance.findandacceptalert();
        }

        public static bool? CheckCourseTitleOnClickingEditButton(string v)
        {
            Driver.clickEleJs(By.Id("MainContent_ucEditContent_FormView1_btnEditContent"));
            return Driver.existsElement(By.XPath("//h1[contains(.,'" + v + "')]"));
        }

        public static void SelectAddLocalization(string v)
        {
            Driver.existsElement(By.XPath("//button[@data-id='selectLanguage']"));
            Driver.clickEleJs(By.XPath("//button[@data-id='selectLanguage']"));
            Driver.clickEleJs(By.XPath("//span[contains(.,'Add Localization')]"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.clickEleJs(By.XPath("//button[@data-id='addLanguage']"));
            Driver.clickEleJs(By.XPath("//span[contains(.,'"+v+"')]"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-locale']"));
        }

        public static object ClickLocalizedInDropdown_SelectFrench(object canada)
        {
            throw new NotImplementedException();
        }

        public static string Frame()
        {
            throw new NotImplementedException();
        }

        public static void ClickSectionsTab()
        {
            throw new NotImplementedException();
        }

        public static bool? ContentDetailsPageOpened()
        {
            Thread.Sleep(5000);
            if (Driver.Instance.Url.Contains("contentdetails.aspx"))
            {
                return true;
            }
            else
                return false;
        }

        public static void ClickBrowserBackButton()
        {
            Driver.Instance.Navigate().Back();
        }

        public static void AddCost()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeys("20");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'View as Learner')]"));
        }

      

        public static void AddPrequisites(string v)
        {
            
            Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));
            if (Driver.GetElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']")).Text.Equals("Checkout"))
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            }

            if (Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']")))
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']"));
                Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace(v);
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                Driver.clickEleJs(By.XPath("//input[@name='ctl00$ctl00$MainContent$MainContent$UC1$rgPrerequisites$ctl00$ctl04$chkSelect']"));
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']"));
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            }
            else if(Driver.existsElement(By.Id("empty-prereq-add")))
            {
                Driver.clickEleJs(By.Id("empty-prereq-add"));
                Driver.existsElement(By.Id("searchFor"));
                Driver.GetElement(By.Id("searchFor")).Clear();
                Driver.GetElement(By.Id("searchFor")).SendKeysWithSpace(v);
                Driver.Instance.FindElement(By.XPath("//a[@id='btn-content-search']/span")).Click();
                Thread.Sleep(5000);
                Driver.clickEleJs(By.XPath("//table[@id='table-prereq-add']/tbody/tr/td/input"));
                Driver.clickEleJs(By.Id("prereq-modal-add"));

            }


        }

        public static void EditBundle()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkAddContent']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucBundleSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBundleAddContent_ctl00_ctl04_rbDesignatedContent']"));
            Driver.clickEleJs(By.XPath("//input[@value='Add']"));


        }

        public static void CreateAndManageChecklists()
        {
            Driver.clickEleJs(By.XPath("//li[@id='MainContent_ChecklistLink']/a"));
        }

        public static void ClickBundleBreadcomb()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucContentInfo1_FormView1_backButton']"));
            
        }

        public static void ClickCourseBreadcrumbs()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
        }

        public static string Title(string v)
        {

            return Driver.GetElement(By.XPath("//h2[contains(text(),"+v+")]")).Text;
        }

     

        public static void EditVersioning_Enabled(string v)
        {
            string version = "";
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucVersion_lnkEdit']"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTVER_VERSION_NUMBER']")).SendKeysWithSpace(v);
            version = Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTVER_VERSION_NUMBER']")).Text.ToString();
            Driver.select(By.XPath("//select[@id='MainContent_MainContent_UC1_FormView1_CNTVER_LOCALE_ID']"), "English (US)");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//input[@value='Enable Versioning']"));
            Driver.Instance.SwitchtoDefaultContent();
        }

        public static bool? VerifyAddVersionButton()
        {
            return Driver.existsElement(By.XPath("//input[@id='MainContent_ctl01_btnAddVersion']"));
        }                          

        public static bool? VerifyVersion(string version)
        {
            string FilledVersion = Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div/div/div/div/p/strong")).Text;
            FilledVersion=FilledVersion.Substring(8).ToString();
            return Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div/div/div/div/p/strong")).Text.ToString().Substring(8).Equals(version);

        }

   

        public static void AddVersion()
        {
            string format = "M/dd/yyyy";
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_ctl01_btnAddVersion']"));                                     
            //Driver.clickEleJs(By.XPath("//input[@id='MainContent_ctl00_btnAddVersion']"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTVER_VERSION_NUMBER']")).SendKeysWithSpace("2");
            Driver.select(By.XPath("//select[@id='MainContent_MainContent_UC1_FormView1_CNTVER_LOCALE_ID']"), "English (US)");
            string IssuedDate = DateTime.Now.AddDays(1).ToString(format);
            IssuedDate = IssuedDate.Replace("-", "/");
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CNTVER_ISSUE_DATE_dateInput']")).Click();
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CNTVER_ISSUE_DATE_dateInput']")).SendKeys(IssuedDate);
            Driver.GetElement(By.XPath("//input[@name='ctl00$ctl00$MainContent$MainContent$UC1$FormView1$CNTVER_ISSUE_TIME$dateInput']")).Click();
            Driver.GetElement(By.XPath("//input[@name='ctl00$ctl00$MainContent$MainContent$UC1$FormView1$CNTVER_ISSUE_TIME$dateInput']")).SendKeys("12:00 AM");
            string EffectiveDate = DateTime.Now.AddDays(2).ToString(format);
            EffectiveDate = EffectiveDate.Replace("-", "/");
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CNTVER_EFFECTIVE_DATE_dateInput']")).Click();
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CNTVER_EFFECTIVE_DATE_dateInput']")).SendKeys(EffectiveDate);
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CNTVER_EFFECTIVE_TIME_dateInput']")).Click();
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CNTVER_EFFECTIVE_TIME_dateInput']")).SendKeys("12:00 AM");
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNTVER_GRACE_PERIOD']")).SendKeysWithSpace("12");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

        public static void EnableAccessKeys()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_ucAccessCodes_lnkEdit"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucAccessCodes_lnkEdit"));
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_CNT_ENABLE_ACCESS_CODE_0"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_CNT_ENABLE_ACCESS_CODE_0"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Thread.Sleep(5000);
            

        }

        public static string VerifyNewVersionSuccessMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static bool? VerifyAddedVersionsInDropDownlist()
        {
            return Driver.existsElement(By.XPath("//select[@id='ddlVersionsAdded']"));
        }                                        

        public static bool? VerifyDeleteVersionButton()
        {
            return Driver.existsElement(By.XPath("//input[@id='MainContent_ctl01_btnDeleteVersion']"));
            
        }

        public static bool? VerifyManageVersionButton()
        {
            return Driver.existsElement(By.XPath("//a[@id='MainContent_ctl01_lnkManageVersions']"));
            ;
        }

        public static void ClickEditandAddCurriculumContent(string v, string s)//for Unordered Curriculum Block
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucTrainingActivity_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//div[@id='MainContent_pnlContent']//div[@class='col-xs-12']"));
            Driver.waitforframe();
            Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_BLOCK_NAME']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Driver.Instance.SwitchtoDefaultContent();
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Add Training Activities')]"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(s);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//tr/following::input[@name='ctl00$ctl00$MainContent$MainContent$UC1$rgBlockActivityContent$ctl00$ctl04$chkSelect']"));

            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAddActivity']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));


            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));

        }

        public static void ClickEditandAddSubscriptionContent(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucContent_MlinkEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_mlinkAddContent']"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_ucAddContent_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContent_ucContentSearch_btnSearchSubscription']"));
            Driver.clickEleJs(By.XPath("//td[contains(text(),'"+v+"')]/preceding::input[1]"));

            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContent_btnAddContent']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContent_btnCancel']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));

        }

        public static string CreatedContent()
        {
            throw new NotImplementedException();
        }

        public static bool? VerifyCheckout()
        {
            return Driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static void AddContentToBundle(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucBundles_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'Add Content')]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_ucBundleSearch_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucBundleSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBundleAddContent_ctl00_ctl04_rbContentMakeDiscretionary']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAdd']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnReturn"));

        }

        public static void EditAndAddCertificationContent(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCertficateContents_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkUserGroup']"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_btnAddCert']"));
        }

        public static void Click_CreateAndManageChecklists()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_hlChecklist']"));
        }
    }

    public class DropDownToggleCommand
    {
        public void Publish()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Publish')]"));
            //Driver.clickEleJs(By.XPath("//div[@id='contentDetailsHeader']/div[2]/div/ul/li[2]/a"));
            //Driver.Instance.findandacceptalert();
            Driver.clickEleJs(By.XPath("//div[@class='bootbox modal fade bootbox-confirm in']//button[@class='btn btn-primary'][contains(text(),'OK')]"));
        }

        public void ViewAsLearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnViewCatalog']"));
            Thread.Sleep(10000);
           
        }
    }

    public class OpenNewAttemptCommand
    {
        public OpenNewAttemptCommand()
        {
        }

        public void CompleteContent()
        {
            if (Driver.existsElement(By.XPath("//a[contains(text(),'Enroll')]")))
                {
                Driver.clickEleJs(By.XPath("//a[contains(text(),'Enroll')]"));
                Driver.clickEleJs(By.Id("quick-play-text"));
                Thread.Sleep(5000);
            }

            
            else if (Driver.existsElement(By.Id("quick-play-text")))
            {
                Driver.clickEleJs(By.Id("quick-play-text"));
            }
            else if (Driver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchCurrentCompletedAttempt']")))
                                      
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchCurrentCompletedAttempt']"));
            }
          
            
            Thread.Sleep(3000);
            string wdwHandle = Driver.Instance.CurrentWindowHandle;
            IList<string> wdwTitle = Driver.Instance.WindowHandles;

            foreach (string dr in wdwTitle)
            {
                Driver.Instance.SwitchTo().Window(dr);
                if (Driver.Instance.Title == "Google")
                {
                    Driver.Instance.Close();
                    Driver.Instance.SwitchTo().Window(wdwHandle);
                    
                }

            }
            Driver.existsElement(By.Id("markCompleteBtn"));
            Driver.clickEleJs(By.Id("markCompleteBtn"));
            //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
           // Driver.clickEleJs(By.Id("MainContent_UC1_btnMarkComplete"));
            Thread.Sleep(2000);



        }

        public void NotCompleteContent()
        {

            if (Driver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt")))
            {
                Driver.clickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt"));
            }
            if (Driver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchCourseAttemptExisting")))
            {
                Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div[5]/input")).ClickWithSpace();
            }

            Thread.Sleep(5000);
            string wdwHandle = Driver.Instance.CurrentWindowHandle;
            IList<string> wdwTitle = Driver.Instance.WindowHandles;

            foreach (string dr in wdwTitle)
            {
                Driver.Instance.SwitchTo().Window(dr);
                if (Driver.Instance.Title == "Google")
                {
                    Driver.Instance.Close();
                    Driver.Instance.SwitchTo().Window(wdwHandle);

                }

            }
            
        }

        public void CompleteContent_Certification()
        {
           
            if (Driver.existsElement(By.Id("MainContent_ucCurriculumDetails_FormView1_CertLaunchAttemptFirst")))
            {
                Driver.clickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CertLaunchAttemptFirst"));
            }

            Thread.Sleep(3000);
            string wdwHandle = Driver.Instance.CurrentWindowHandle;
            IList<string> wdwTitle = Driver.Instance.WindowHandles;

            foreach (string dr in wdwTitle)
            {
                Driver.Instance.SwitchTo().Window(dr);
                if (Driver.Instance.Title == "Google")
                {
                    Driver.Instance.Close();
                    Driver.Instance.SwitchTo().Window(wdwHandle);

                }

            }
            Driver.existsElement(By.Id("MainContent_ucCurriculumDetails_FormView1_CertMarkCompleteBlock"));
            Driver.clickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CertMarkCompleteBlock"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.existsElement(By.Id("MainContent_UC1_btnMarkComplete"));
            Driver.GetElement(By.Id("MainContent_UC1_btnMarkComplete")).ClickWithSpace();
            Thread.Sleep(2000);

        }
    }

    public class CreditsCommand
    {
        public CreditsCommand()
        {
        }

        public string VerifyTitleText(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div[3]/div/h5"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div[3]/div/h5")).Text;
        }

        public string VerifyAvailableCreditTypeText(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div[3]/ul/li")).Text;
        }

        public string VerifyNoteligiblesText(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div[3]/div[2]/em")).Text;
        }
    }

    public class SummarySectionCommand
    {
        public SummarySectionCommand()
        {
        }
    }

    public class CourseInformationCommand
    {
        public void ClickEditButton()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseInfo_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseInfo_lnkEdit']"));
        }
    }

    public class SurveysCommand
    {
        public void ManageScorm()
        {
            throw new NotImplementedException();
        }

        public bool? isSurveyTitleDisplayed()
        {
            return Driver.GetElement(By.XPath("//a[@id='lnkDetails']")).Displayed;
        }

        public bool? isSurveyProgressStatusDisplayed()
        {
            return Driver.GetElement(By.XPath("//li[@class='list-group-item']//li")).Displayed;

        }
    }

    public class CertificateCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class MobileSettingCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class WindowCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class ManageActivityCommand
    {
        public void ClickEditButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucActivity_lnkEdit']"));
        }
    }

    public class ImageCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class PermissionsCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }

        public void ClickEdit()
        {
            throw new NotImplementedException();
        }
    }

    public class ContentSharingCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class AccessApprovalCommand
    {
        public void ClickEditButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
        }
    }

    public class EquivalenciesCommand
    {
        public bool? GetTextForCostAndSalestax { get; set; }

        public void ClickEditButton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucEquivalencies_lnkEdit"));
        }

        public void ClickEdit()
        {
            throw new NotImplementedException();
        }

        public bool? isTitleDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/a")).Displayed;
        }

        public bool? isProgressStatusDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@class='col-md-4']//ul[@class='list-inline']//li[1]")).Displayed;
        }

        public bool? isCostDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@class='col-md-4']//ul[@class='list-inline']//li[2]")).Displayed;
        }

        public bool? NoEquivalenciesadded(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/p"));
            return Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/p")).Text.EndsWith(v);
        }

        public int AssignedEquivalenciesCount()
        {
            Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/p"));
            string equivalenciestext = Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/p")).Text;
            return Driver.getIntegerFromString(equivalenciestext);
        }
    }

    public class PrerequisitesCommand
    {
        public bool? GetTextForCostAndSalestax { get; set; }

        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }

        public void ClickEdit()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucPrerequistes_lnkEdit"));
            //throw new NotImplementedException();
        }

        public bool? isPortletheadershowes_old(string v)
        {
            Driver.existsElement(By.XPath("//p[@class='mb-0']"));
            string requiredcount = Driver.GetElement(By.XPath("//p[@class='mb-0']")).Text;
            int requiredcount1 = Driver.getIntegerFromString(requiredcount);
            if (Driver.GetElement(By.XPath("//p[@class='mb-0']")).Text.StartsWith(v) || requiredcount1 == 2)
            {
                return true;
            }
            else
                return false;

        }
    
    }

    public class CostAndSalesTaxCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class CategoriesCommand
    {
        public bool? GetTextForCostAndSalestax { get; set; }
        public bool? GetTitleOfSelectedCategory { get; set; }

        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class CourseSettingsCommand
    {
        public void ClickEditButton()
        {
            throw new NotImplementedException();
        }
    }

    public class CourseFileCommand
    {
        public CourseFileCommand()
        {

        }

        public void ClickEditButton()
        {
            Driver.Instance.FindElement(By.Id("MainContent_MainContent_ucDocument_lnkEdit")).ClickWithSpace();
        }
    }

    public class SummaryCommand
    {
        public SummaryCommand()
        {

        }

        public void ClickEditButton()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
            Driver.Instance.FindElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit")).ClickWithSpace();
        }

        public void ClickViewButton()
        {
            Driver.clickEleJs(By.Id("MainContent_header_FormView1_btnStatus"));
        }

        public void ClickEdit()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
            Driver.GetElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit")).Click();
        }

        public bool? VerifyReportDate()
        {

            // return Driver.comparePartialString(Driver.,"");//need to compare
            //throw new NotImplementedException();

            return Driver.matchtime(By.XPath("//span[@id='Data.REPORT_DATE_Row1']"));

        }

        public bool? VerifyOrganization()
        {
            Driver.existsElement(By.XPath("//span[contains(text(),'Sample Organization 1')]"));
            string ActualOrganization = Driver.GetElement(By.XPath("//span[contains(text(),'Sample Organization 1')]")).Text;
         //   string text = Driver.GetElement(by).Text;
            return ActualOrganization == Meridian_Common.Runreportpage_Organization;
        }

        //public bool? VerifySubOrganization()
        //{
        //    throw new NotImplementedException();

        //}

        public bool? VerifySectionActivity()

        {
            Driver.existsElement(By.XPath("//span[@id='Data.SECTION_ACTIVITY_Row1']"));
            string ActualSectionActivity = Driver.GetElement(By.XPath("//span[@id='Data.SECTION_ACTIVITY_Row1']")).Text;
            //   string text = Driver.GetElement(by).Text;
            return ActualSectionActivity == Meridian_Common.Runreportpage_SectionActivity;
        }

        public bool? VerifyDateRange()
        {
            string DateRangeFrom= Driver.GetElement(By.XPath("//span[@id='Data.RANGE_DATE_FROM_Row1']")).Text;
            string DatetangePartition= Driver.GetElement(By.XPath("//span[@id=' - _Row1']")).Text;
            string DateRangeTo= Driver.GetElement(By.XPath("//span[@id='Data.RANGE_DATE_TO_Row1']")).Text;
            string ActualDateRange = DateRangeFrom +DatetangePartition +DateRangeTo;
            string Summary_DateRange= Meridian_Common.Runreportpage_DateFrom+"-"+Meridian_Common.Runreportpage_DateTo;
            return ActualDateRange == Summary_DateRange;
        }

        public bool? VerifyCapacity()
        {
            string CapacityOperator = Driver.GetElement(By.XPath("//span[@id='Data.CAPACITY_OPERATOR_Row1']")).Text;
            string CapacityValue= Driver.GetElement(By.XPath("//span[@id='Data.CAPACITY_VALUE_Row1']")).Text;
            string ActualCapacity = (CapacityOperator +" " + CapacityValue).ToLower();
            string Summary_Capacity = (Meridian_Common.Runreportpage_CapacityOperator + " " + Meridian_Common.Runreportpage_CapacityValue).ToLower();
            return ActualCapacity == Summary_Capacity;

        }

        public bool? VerifyEnrollment()
        {
            string EnrollmentOperator = Driver.GetElement(By.XPath("//span[@id='Data.ENROLLMENT_OPERATOR_Row1']")).Text;
            string EnrollmentValue = Driver.GetElement(By.XPath("//span[@id='Data.ENROLLMENT_VALUE_Row1']")).Text;
            string ActualEnrollment = (EnrollmentOperator + " " + EnrollmentValue).ToLower();
            string Summary_Enrollment = (Meridian_Common.Runreportpage_EnrollmentOperator + " " + Meridian_Common.Runreportpage_EnrollmentValue).ToLower();
            return ActualEnrollment == Summary_Enrollment;
        }

        public bool? VerifyReportLayout()
        {
            string ActualLayout = Driver.GetElement(By.XPath("//span[@id='Data.REPORT_LAYOUT_Row1']")).Text;
            //   string text = Driver.GetElement(by).Text;
            return ActualLayout.StartsWith(Meridian_Common.Runreportpage_Layout.Trim());
        }

        public bool? VerifyTimeZone()
        {
            string ActualTimeZone = Driver.GetElement(By.XPath("//span[@id='Data.TZLCL_NAME_Row1']")).Text;
            //   string text = Driver.GetElement(by).Text;
            return ActualTimeZone == Meridian_Common.UserTimeZone;

        }

        public bool VerifyRecertificationIntervaldays(string v)
        {
            return Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[9]/strong")).Text.Equals(v);
        }

        public bool? isAvailableinCatalog(string v)
        {
            Thread.Sleep(5000);
            return Driver.GetElement(By.XPath("//strong[contains(text(),'" + v + "')]")).Text.Equals(v);
        }

        public string tagName(string v)
        {
            Driver.existsElement(By.XPath("//strong[contains(.,'" + v + "')]"));

            return Driver.GetElement(By.XPath("//strong[contains(.,'" + v + "')]")).Text;

        }

        public bool? isAvailableinCatalog_certification(string v)
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'Available in Catalog:')]")).Text.Contains(v);
        }
    }
}