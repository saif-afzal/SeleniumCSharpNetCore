using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class SectionDetailsPage
    {
        public static ContentTabCommand ContentTab { get { return new ContentTabCommand(); } }

        public static SectionDetailsTabCommand SectionDetailsTab { get { return new SectionDetailsTabCommand(); } }

        public static ScheduleTabCommand ScheduleTab { get { return new ScheduleTabCommand(); } }

        public static SurveysPortletCommand SurveysPortlet { get { return new SurveysPortletCommand(); } }

        public static GradebookTabCommand GradebookTab { get { return new GradebookTabCommand(); } }

        public static NotificationTabCommand NotificationTab { get { return new NotificationTabCommand(); } }

        public static ScheduleandContentTabCommand ScheduleandContentTab { get { return new ScheduleandContentTabCommand(); } }

        //public static CostsCommand Costs { get { return new CostsCommand(); } }

        public static void ClickScehduleTab()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkSchedule"));
        }

        public static void ClickContentTab()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkContent"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkContent"));
        }

        public static bool? SectionContentPageopened()
        {
            return Driver.existsElement(By.XPath("//div[@id='no-content']/div/div/a"));
        }

        public static string GetSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static void ClickGradebookTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkGradebook']"));

        }

        public static void clickEnrollmentTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkManageEnrollment']"));
        }

        public static bool? Add_Notes()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[@data-target='#addTranscriptNote']"));
                Driver.Instance.GetElement(By.XPath("//textarea[@id='note_description']")).SendKeysWithSpace("Test Notes");
                Driver.clickEleJs(By.XPath("//button[@id='btnAddTranscriptNote']"));
                Thread.Sleep(2000);
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'1 note(s)')]"));
                result = true;
            }catch(Exception e)
            {

            }
            return result;
        }

        public static bool? isGradebookAndAttendanceTabDisplay()
        {
            return Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkGradebook"));
        }

        public static bool? Delete_Notes()
        {
            {
                bool result = false;
                try
                {
                    Driver.clickEleJs(By.XPath("//a[contains(.,'1 note(s)')]"));
                    Driver.clickEleJs(By.XPath("//table[@id='notes']/tbody/tr/td/input"));
                    Driver.clickEleJs(By.XPath("//button[@id='btnDeleteNote']"));
                    Thread.Sleep(2000);
                    result = true;
                }
                catch (Exception e)
                {

                }
                return result;
            }

        }

        public static void Click_GradesOnlyButton()
        {
            Driver.clickEleJs(By.XPath("//label[contains(.,'Grades Only')]"));

        }

        public static bool enterGradeForUser_PASS_OR_FAIL()
        {
            bool result = false;
            try
            {
                Thread.Sleep(10000);
                Driver.clickEleJs(By.XPath("//table[1]/tbody[1]/tr[1]/td[5]/a[1]"));
                Driver.Instance.selectDropdownValue(By.XPath("//select[@class='form-control input-sm']"), "Pass");
                result= Driver.existsElement(By.XPath("//a[@data-value='ML.BASE.Pass']"));
                
            }catch(Exception e)
            {

            }
            return result;
            
        }

        public static void ManageSurveys()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucEvaluations_hlManage']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAssignSurveys']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));

        }

        public static void ClickScheduleandContentTab()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkSectionTimeline"));
        }

        public static bool? isScheduleandContentTabDisplay()
        {
            return Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkSectionTimeline"));
        }

        public static void ClickNotificationTab()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkNotification"));
        }

        public static bool? isNotificationTabDisplay()
        {
            return Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkNotification"));
        }

        public static void ClickEditCost()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lbEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lbEdit']"));
        }

        public static void ClickViewAsLearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static void clickSectionDetailsTab()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkSectionDetails"));
        }
    }

    public class ScheduleandContentTabCommand
    {        

        public ScheduleandContentTabCommand()
        {
        }

        public CommitmentCommand Commitment { get { return new CommitmentCommand(); } }

        public bool? CommitmentDisplay()
        {
            return Driver.existsElement(By.XPath("//strong[contains(text(),'Commitment')]"));
        }

        public int EventCount()
        {
            Driver.existsElement(By.XPath("//span[@id='event-cnt']"));
            return Driver.getIntegerFromString(Driver.GetElement(By.XPath("//span[@id='event-cnt']")).Text);
        }

        public bool? isGradedItemsDisplay()
        {
            return Driver.existsElement(By.XPath("//strong[contains(text(),'Graded Items')]"));
        }

        public bool? isPossiblePointdisplay()
        {
            return Driver.existsElement(By.XPath("//strong[contains(text(),'Possible Points')]"));
        }
    }

    public class CommitmentCommand
    {
        public CommitmentCommand()
        {
        }

        public bool? StartandEndDateDisplay()
        {
            return Driver.existsElement(By.Id("section-time"));
        }
    }

    public class NotificationTabCommand
    {
        public NotificationTabCommand()
        {
        }

        public EmailTableCommand EmailTable { get { return new EmailTableCommand(); } }

        public ActionCommandNotification Action { get { return new ActionCommandNotification(); } }

        public bool? isEmailTabledisplay()
        {
           return Driver.existsElement(By.XPath("//table[@id='table-notification']"));
        }
    }

    public class ActionCommandNotification
    {
        public ActionCommandNotification()
        {
        }

        public void ClickEdit(string v)
        {
            Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//html[@id='PageBody']/body/ul/li/a"));
        }
    }

    public class EmailTableCommand
    {
        public EmailTableCommand()
        {
        }

        public ActionsCommand Actions { get { return new ActionsCommand(); } }

        public bool? Columnheader(string v1, string v2, string v3, string v4, string v5)
        {
            Driver.GetElement(By.XPath("//a[contains(text(),'Email Title')]")).Text.Equals(v1);
            Driver.GetElement(By.XPath("//a[contains(text(),'Trigger')]")).Text.Equals(v2);
            Driver.GetElement(By.XPath("//div[contains(text(),'On')]")).Text.Equals(v3);
            Driver.GetElement(By.XPath("//div[contains(text(),'Actions')]")).Text.Equals(v4);
            return Driver.GetElement(By.XPath("//div[contains(text(),'Info')]")).Text.Equals(v5);
        }

        public bool? inactiveEmailDisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-notification']/tbody/tr/td/a"));
        }

        public void TurnoffFirstEmail()
        {
            Driver.GetElement(By.XPath("//table[@id='table-notification']/tbody/tr/td[3]/div/div/span[2]")).ClickWithSpace();
        }
    }

    public class ActionsCommand
    {
        public ActionsCommand()
        {
        }

        public void SendTestEmail()
        {
            Driver.clickEleJs(By.Id("actions"));
            Driver.clickEleJs(By.XPath("//html[@id='PageBody']/body/ul/li[3]/a"));
        }

        public bool? isSendTestEmailModaldisplay()
        {
            Driver.existsElement(By.XPath("//div[@id='email-test-confirm']/div/div/div/h4"));
            return Driver.GetElement(By.XPath("//div[@id='email-test-confirm']/div/div/div/h4")).Text.Equals("Send Test Email");
        }

        public void CancelSendTestEmail()
        {
            Driver.existsElement(By.XPath("//div[@id='email-test-confirm']/div/div/div[3]/button"));
            Driver.clickEleJs(By.XPath("//div[@id='email-test-confirm']/div/div/div[3]/button"));
        }

        public void SendTestEmailtoUser()
        {
            Driver.existsElement(By.Id("email-test-recipients"));
            Driver.GetElement(By.Id("email-test-recipients")).Clear();
            Driver.GetElement(By.Id("email-test-recipients")).SendKeys("test@test.com");
            Driver.clickEleJs(By.Id("btnSendTestEmail"));
        }
    }

    public class SurveysPortletCommand
    {
        public void Click_Report()
        {
            Driver.clickEleJs(By.XPath("//span[@class='fa fa-fw fa-bar-chart fa-lg']"));
        }
    }

    public class SectionDetailsTabCommand
    {
        public SectionDetailsTabCommand()
        {
        }
        public void CopyTheCompletionCode()
        {
            string CompletionCode = "";
            Meridian_Common.CompletionCode = Driver.GetElement(By.XPath("//div[@id='details']/ul/li[3]/dl/dd")).ToString();
        }
        public SurvetAccordian SurvetAccordian { get { return new SurvetAccordian(); } }

        public SectionPermissionsCommand Permissions { get { return new SectionPermissionsCommand(); } }

        public bool? isSurveyAccordianDisplay()
        {
            return Driver.existsElement(By.XPath("//h4[@class='panel-title panel-title-with-btn']"));
        }

        public void Click_ManageSurveysButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucEvaluations_hlManage']"));
        }

        public void ClickEditPermissions()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_ucPermissions_MHyperLink1"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucPermissions_MHyperLink1"));
        }
    }

    public class SectionPermissionsCommand
    {
        public SectionPermissionsCommand()
        {
        }

        public bool? isInheritcoursepermissionsisChecked()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_chkUseCrsPerm"));
            return Driver.GetElement(By.Id("MainContent_MainContent_UC1_chkUseCrsPerm")).Selected;
        }

        public bool? isAssignPermissionsButtonDisplay()
        {
            return Driver.existsElement(By.Id("MainContent_MainContent_UC1_lnkCostAdd"));
        }

        public void AssignPermissions(string v)
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_txtSearchFor"));
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_txtSearchFor")).Clear();
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_txtSearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
            Driver.clickEleJs(By.XPath("//td[3]/input"));
            Driver.clickEleJs(By.XPath("//td[5]/input"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public void ClickSave()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public void ClickAssignPermissions()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_lnkCostAdd"));
        }

        public void UnCheckInheritcoursepermissions()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_chkUseCrsPerm"));
        }
    }

    public class SurvetAccordian
    {
        public SurvetAccordian()
        {
        }

        public bool? isCourseLevelSurveysdisplay()
        {
            return Driver.existsElement(By.XPath("//strong[@class='badge bg-wrn-lighter text-wrn-darker ml-1']"));
        }
    }

    public class CostsCommand
    {
        public CostsCommand()
        {
        }

        public void DefaultCost(int v)
        {
          // Driver.getIntegerFromString.(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeys(v);
        }

     
    }

    public class ContentTabCommand
    {
        public ContentTabCommand()
        {
        }

        public AddNoteModalCommand AddNoteModal { get { return new AddNoteModalCommand(); } }

        public bool? AddNoteModalIsClosed { get {
                Thread.Sleep(3000);
                return Driver.GetElement(By.XPath("//div[@id='addNote']/div/div/div/h4")).Displayed; } }

        public bool? ListFiles { get { return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[3]")); } }

        public bool? ListNoteAdded { get { return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a")); } }

        public bool? NoteModalOpened { get
            {
                Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                return Driver.existsElement(By.XPath("//div[@id='addNote']/div/div/div/h4"));
            }
            }

       // public bool? UpLoadFileModalIsClosed { get { return Driver.existsElement(By.XPath("//div[@id='uploadFile']/div/div/div/h4")); } }

       // public bool? ListFileAdded { get { return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[3]")); } }

        public bool? ListNotes { get { return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr[2]/td[3]")); } }
       
        public AvailableToLearnersColumnCommand AvailableToLearnersColumn { get { return new AvailableToLearnersColumnCommand(); } }

        public bool? ListAssignemnt { get { return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[3]")); } }

        public bool? ListFirstNotes { get { return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a")); } }

        public void AddContentdropdownSelect(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@class='btn-group']//a[@class='btn btn-primary dropdown-toggle']"));
            Driver.clickEleJs(By.XPath("//div[@class='btn-group open']//ul[@class='dropdown-menu']//li//a[@href='#'][contains(text(),'Create Note')]"));
        }

        public bool? AddNoteModaldisplay()
        {
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return Driver.existsElement(By.XPath("//div[@id='addNote']//div[@class='modal-header']"));
        }

        public void ClickNoteName()
        {
            Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a"));
        }

        public void CloseAddNoteModal()
        {
            Driver.clickEleJs(By.XPath("//div[3]/div/div/div/button/span"));
        }

        public bool? NotesTitleXCharactersOfActualNote()
        {
            throw new NotImplementedException();
        }

        public void SelectUploadFilesFromAdddContentdropdown(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='no-content']/div/div/a[2]"));
            Driver.clickEleJs(By.XPath("//div[@id='no-content']/div/div/ul/li[3]/a"));
            //Driver.clickEleJs(By.Id("action_DropDownBtn"));
            //Driver.clickEleJs(By.XPath("//div[@id='utilityToolbar']/div/div[2]/div/ul/li[3]/a"));

        }

        public bool? UploadFilesModaldisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='uploadFile']/div/div/div/h4"));
        }

        public void CloseUploadFileModal()
        {
            Driver.clickEleJs(By.XPath("//div[@id='uploadFile']/div/div/div/button/span"));
        }

        public void UploadFile()
        {
            Driver.Instance.navigateAICCfile("Data\\Fileupload.txt", By.Id("uploadContentFile"));
            Driver.clickEleJs(By.XPath("//div[@id='uploadFile']/div/div/div[3]/button[2]"));
            Thread.Sleep(3000);
        }

        public void FileClickName()
        {
            Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[2]/a"));
        }

        public void SelectAddNotesFromAddContentdropdown()
        {
            Driver.existsElement(By.Id("action_DropDownBtn"));
            Driver.clickEleJs(By.Id("action_DropDownBtn"));
            Driver.clickEleJs(By.XPath("//div[@id='utilityToolbar']/div/div[3]/div/ul/li[2]/a"));
        }

        public void AddAssignmentAs(string v)
        {
            Thread.Sleep(10000);
            //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            //Driver.existsElement(By.XPath("//div[@id='edit-assignment-modal']/div/h4"));
            Driver.GetElement(By.Id("title")).Clear();
            Driver.GetElement(By.Id("title")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//div[@id='edit-assignment-modal']/div[3]/button[2]"));
            Driver.existsElement(By.XPath("//div[@id='edit-assignment-modal']/div[2]/div[2]/button[2]"));
            Driver.clickEleJs(By.XPath("//div[@id='edit-assignment-modal']/div[2]/div[2]/button[2]"));
            Thread.Sleep(10000);
        }

        public void SelectAddAssignmentAddContentdropdown(string v)
        {
            
            Driver.clickEleJs(By.XPath("//div[@id='no-content']/div/div/a[2]"));
            Driver.clickEleJs(By.XPath("//div[@id='no-content']/div/div/ul/li/a"));
        }

        public void AddContent(string name)
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkContent"));
            Driver.clickEleJs(By.XPath("//div[@class='btn-group']/a[contains(.,'Add Content')]"));
            Driver.existsElement(By.Id("SearchFor"));
            Driver.Instance.GetElement(By.Id("SearchFor")).SendKeysWithSpace(name);
            Driver.clickEleJs(By.Id("btn-search-content"));
            //if (Driver.existsElement(By.XPath(".//*[contains(.,'" + name + "')]/preceding::td/input")))
            //{
            //    Driver.clickEleJs(By.XPath(".//*[contains(.,'" + name + "')]/preceding::td/input"));
            //}
            //else
            //{
                Driver.clickEleJs(By.XPath("//table[@id='find-content']/tbody/tr/td/input"));
            //}
            Driver.clickEleJs(By.Id("btn-add"));
            Driver.clickEleJs(By.XPath("//a[@class='xeditable xeditable-click']"));
            Driver.Instance.selectDropdownValue(By.XPath("//select[@class='form-control input-sm']"), "Yes, when learner enrolls");
            //Driver.select(By.XPath("//select[@class='form-control input-sm']"), "Yes, when learner enrolls");



        }

        public void DeleteContent()
        {
            Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//div[@id='utilityToolbar']/div/div/button"));
            Driver.clickEleJs(By.Id("//button[@id='btn-remove-content']"));
        }

        public void AddGrade()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Not set')]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='weight']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='weight']")).SendKeysWithSpace("5");
            string format = "M/dd/yyyy";
            string startdate = DateTime.Now.AddDays(2).ToString(format);
            startdate = startdate.Replace("-", "/");
            Driver.Instance.GetElement(By.XPath("//input[@id='fromDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='fromDate']")).SendKeysWithSpace(startdate);
            Thread.Sleep(3000);
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Points')]"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath(" //button[contains(text(),'Save')]"));
            Thread.Sleep(3000);

        }

        public bool? UpLoadFileModalIsClosed()
        {
            return Driver.existsElement(By.XPath("//div[@id='uploadFile']/div/div/div/h4"));
        }

        public bool? ListFileAdded()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[3]"));
        }

        public string AddSingleContent(string v)
        {
            string contenttitle = null;
            Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkContent"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkContent"));
            Driver.clickEleJs(By.XPath("//div[@class='btn-group']/a[contains(.,'Add Content')]"));
            Driver.existsElement(By.Id("SearchFor"));
            Driver.Instance.GetElement(By.Id("SearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("btn-search-content"));
            
            Driver.clickEleJs(By.XPath("//table[@id='find-content']/tbody/tr/td/input"));
            contenttitle = Driver.GetElement(By.XPath("//table[@id='find-content']/tbody/tr/td[2]")).Text;
            Driver.clickEleJs(By.Id("btn-add"));
            return contenttitle;
        }

        public string SetDuedate()
        {
            Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[5]/a"));
            Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[5]/a"));
            string format = "M/dd/yyyy";
            string duedate = DateTime.Now.AddDays(2).ToString(format);
            duedate = duedate.Replace("-", "/");
            Driver.clickEleJs(By.XPath("//div[@id='datetimepickerDueDate']/input"));
            Driver.GetElement(By.XPath("//div[@id='datetimepickerDueDate']/input")).SendKeysWithSpace(duedate);
            Driver.clickEleJs(By.XPath("//div[2]/div/div/div[3]/button[2]"));
            return duedate;

        }
    }

    public class AvailableToLearnersColumnCommand
    {
        public AvailableToLearnersColumnCommand()
        {
        }

        public void ClickFileCell(string v="")
        {
            if (v.ToLower().Equals(null))
            {
                Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a"));
                Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a"));
                Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div/div/select"));
                Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div/div/select")).ClickWithSpace();
            }
            else
            {
                Driver.existsElement(By.XPath("//table[@id='table-material']//td[contains(text(),'"+v+"')]/following::td[2]"));
                Driver.clickEleJs(By.XPath("//table[@id='table-material']//td[contains(text(),'" + v + "')]/following::td[2]"));
                Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div/div/select"));
                Driver.GetElement(By.XPath("//select[@class='form-control input-sm']")).ClickWithSpace();
            }
        }

        public bool? CellDropDownOption(string v)
        {
            try
            {
                IWebElement select = Driver.Instance.FindElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div[1]/div/select"));
                //IList<IWebElement> options = select.FindElements(By.TagName("options"));
                string optionstext = select.Text.Replace("\r\n","=");
                string[] optionstext1 = optionstext.Split('=');
                for(int i=0;i<optionstext1.Length;i++)
                {
                    if(optionstext1[i]==v)
                    {
                        return true;
                       
                    }
                   
                }

                
            }
            catch (NoSuchElementException)
            {
                return false;


            }
            return true;
        }

        public void SelectOption(string v, string x="")
        {
            if (v == "Yes, when learner enrolls"||x.Equals(null))
            {
                if (Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div/div/select")))
                {
                    Driver.Instance.select(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div[1]/div/select"), v);
                }
                else
                {
                    Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a"));
                    Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div/div/select")).ClickWithSpace();
                    Driver.Instance.select(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div[1]/div/select"), v);
                }

            }
            else
            {
                if (Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div/div/select")))
                {
                    Driver.Instance.select(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div[1]/div/select"), v);
                }
                else
                {
                    Driver.clickEleJs(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a"));
                    Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div/div/select")).ClickWithSpace();
                    Driver.Instance.select(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/span/div/form/div/div[1]/div/select"), v);
                }
            }
            Thread.Sleep(2000);//insserted this delay as msg appears after 2 sec
        }

        public bool? CellDisplay(string v)
        {
            Driver.existsElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a"));
            return Driver.GetElement(By.XPath("//table[@id='table-material']/tbody/tr/td[4]/a")).Text == v;
        }
    }

    public class AddNoteModalCommand
    {
        public AddNoteModalCommand()
        {
        }

        public void AddNoteswith(string v)
        {
            Driver.GetElement(By.Id("note_description")).Clear();
            Driver.GetElement(By.Id("note_description")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[@id='addNote']/div/div/div[3]/button[2]"));
            Thread.Sleep(3000);
        }
    }
}