using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace Selenium2.Meridian.Suite
{
    public class CreateTrainingAssignmentPage
    {
        public static AssignessTabCommand AssignessTab { get { return new AssignessTabCommand(); } }

        public static ContentTabCommand1 ContentTab { get { return new ContentTabCommand1(); } }

        public static DueDateTabCommand DueDateTab { get { return new DueDateTabCommand(); } }

        public static EffectiveDateTabCommand EffectiveDateTab { get { return new EffectiveDateTabCommand(); } }

        public static bool? isTrainingAssigmentPageOpened(string assignmentTitleText)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div/h1"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text.Equals(assignmentTitleText);
        }

        public static void Create(string v)
        {
            Driver.existsElement(WebElement_Locators.CreateTrainingAssignmentPage_TitleBox);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_TitleBox);
            Driver.GetElement(WebElement_Locators.CreateTrainingAssignmentPage_TitleInputTextBox).Clear();
            Driver.GetElement(WebElement_Locators.CreateTrainingAssignmentPage_TitleInputTextBox).SendKeysWithSpace(v);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_SaveTitleBtn);


        }

        public static void ClickEffectiveDatesTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Effective Dates')]"));
        }

        public static bool? isEffectiveDateandExpiresDateDisplayonTop(string effectiveDate, string expiresDate)
        {
            Driver.existsElement(By.XPath("//span[@id='rt-effective-date-info']"));
            Driver.GetElement(By.XPath("//span[@id='rt-effective-date-info']")).Text.Contains(effectiveDate);
            return Driver.GetElement(By.XPath("//span[@id='rt-expiration-date-info']")).Text.Contains(expiresDate);
        }

        public static void clickAssignButton()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btn-assign']"));
            Thread.Sleep(5000);
            Driver.existsElement(By.Id("btn-assign-ok"));
            Driver.clickEleJs(By.Id("btn-assign-ok"));
            Thread.Sleep(10000);
        }

        public static bool? isAssignmentStatus(string v)
        {
            Driver.existsElement(By.XPath("//span[@id='mode-label']"));
            return Driver.GetElement(By.XPath("//span[@id='mode-label']")).Text.Equals(v);
        }

        public static void ClickDueDateTab()
        {
            Thread.Sleep(10000);
            Driver.existsElement(By.LinkText("Due Date"));
            Driver.clickEleJs(By.LinkText("Due Date"));
        }
    }

    public class EffectiveDateTabCommand
    {
        public EffectiveDateTabCommand()
        {
        }

        public string SetEffectiveDate(int v)
        {
            string format = "M/dd/yyyy";
            string startdate = DateTime.Now.AddDays(v).ToString(format);
            startdate = startdate.Replace("-", "/");
            IWebElement effectiveDate = Driver.GetElement(By.XPath("//input[@id='schedule-effective-on-date']"));
            effectiveDate.Clear();
            effectiveDate.SendKeysWithSpace(startdate);
            effectiveDate.SendKeys(Keys.Tab);
            Driver.clickEleJs(By.XPath("//input[@id='schedule-effective-on-date']"));
            Driver.clickEleJs(By.XPath("//div[@id='effectiveDateDiv']//span[@class='input-group-addon']"));
            return startdate;
        }

        public string SetExpiresDate(int v)
        {
            string format = "M/dd/yyyy";
            string enddate = DateTime.Now.AddDays(v).ToString(format);
            enddate = enddate.Replace("-", "/");
            IWebElement ExpiresDate = Driver.GetElement(By.XPath("//input[@id='schedule-expires-on-date']"));
            ExpiresDate.Clear();
            ExpiresDate.SendKeysWithSpace(enddate);
            ExpiresDate.SendKeys(Keys.Tab);
            Driver.clickEleJs(By.XPath("//input[@id='schedule-expires-on-date']"));
            Driver.clickEleJs(By.XPath("//div[@id='expDateDiv']//span[@class='input-group-addon']"));
            return enddate;
        }
    }

    public class DueDateTabCommand
    {
        public DueDateTabCommand()
        {
        }

        public AssignmentDueDateModalCommand AssignmentDueDateModal { get { return new AssignmentDueDateModalCommand(); } }

        public void ClickChage()
        {
            Driver.existsElement(By.LinkText("Due Date"));
            Driver.clickEleJs(By.LinkText("Due Date"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.Id("rt-date-edit"));
            Thread.Sleep(5000);
        }

        public bool? VerifyPreviousComplistion(string previousCompletions)
        {
            Driver.existsElement(By.Id("pastcompletionsetting"));
            try
            {
                
                if(previousCompletions.Equals("Yes, all previous completions"))
                {
                  return Driver.GetElement(By.Id("pastcompletionsetting")).Text.Contains("Satisfy the assignment");
                }
                if (previousCompletions.Equals("Yes, if completed since"))
                {
                    return Driver.GetElement(By.Id("pastcompletionsetting")).Text.Contains("Satisfy the assignment if completed since");
                }
                if (previousCompletions.Equals("Yes, if completed within the last"))
                {
                    return Driver.GetElement(By.Id("pastcompletionsetting")).Text.Contains("Satisfy the assignment if completed within the past");
                } //Yes, if completed since [MM/DD].
                if (previousCompletions.Equals("Yes, if completed since [MM/DD]."))
                {
                    return Driver.GetElement(By.Id("pastcompletionsetting")).Text.Contains("Satisfy the assignment if completed since");
                }

            }
            catch{ }
            return false;
        }

        public string First_DueDate()
        {
            return Driver.GetElement(By.XPath("//p[@id='due']")).Text;
        }
    }

    public class AssignmentDueDateModalCommand
    {
        public AssignmentDueDateModalCommand()
        {
        }

        public string SetPreviousCompletionsYesandRecurringNo(string v)
        {
            string PreviusCompletions = null;
            try
            {
                if (v == "Yes")
                {
                    Driver.existsElement(By.XPath("//div[@id='due-date-status']/div/div/div/span[2]"));
                    Driver.clickEleJs(By.XPath("//div[@id='due-date-status']/div/div/div/span[3]"));
                    Driver.clickEleJs(By.Id("Due_Date_Times_Once"));
                    Driver.existsElement(By.Id("Due_Date_When_Within_Amount"));
                    Driver.GetElement(By.Id("Due_Date_When_Within_Amount")).SendKeysWithSpace("15");
                    Driver.clickEleJs(By.Id("Allow_All_Prev_completions"));
                    PreviusCompletions = Driver.GetElement(By.Id("Allow_All_Prev_completions_Label")).Text;
                    Driver.clickEleJs(By.Id("rt-date-save"));

                }
                if (v == "date")
                {
                    int i = 4;
                    string format = "M/dd/yyyy";
                    string enddate = DateTime.Now.AddDays(i).ToString(format);
                    enddate = enddate.Replace("-", "/");
                    Driver.existsElement(By.XPath("//div[@id='due-date-status']/div/div/div/span[2]"));
                    Driver.clickEleJs(By.XPath("//div[@id='due-date-status']/div/div/div/span[3]"));
                    Driver.clickEleJs(By.Id("Due_Date_Times_Once"));
                    Driver.existsElement(By.Id("Due_Date_When_Within_Amount"));
                    Driver.GetElement(By.Id("Due_Date_When_Within_Amount")).SendKeysWithSpace("15");
                    // Driver.clickEleJs(By.Id("Allow_Prev_Completions_Since"));
                    Driver.GetElement(By.XPath("//input[@id='Prev_completions_Since_Date']")).Clear();
                    Driver.GetElement(By.XPath("//input[@id='Prev_completions_Since_Date']")).SendKeysWithSpace("10/10/2018");
                    PreviusCompletions = Driver.GetElement(By.XPath("//div[@id='allow-prev-completions-since']/div/label")).Text;
                    Driver.clickEleJs(By.Id("rt-date-save"));

                }
                if (v == "days")
                {
                    Driver.existsElement(By.XPath("//div[@id='due-date-status']/div/div/div/span[2]"));
                    Driver.clickEleJs(By.XPath("//div[@id='due-date-status']/div/div/div/span[3]"));
                    Driver.clickEleJs(By.Id("Due_Date_Times_Once"));
                    Driver.existsElement(By.Id("Due_Date_When_Within_Amount"));
                    Driver.GetElement(By.Id("Due_Date_When_Within_Amount")).SendKeysWithSpace("15");
                   // Driver.clickEleJs(By.Id("Allow_Prev_Completions_From"));
                    Driver.GetElement(By.Id("Prev_Completions_Within_Amount")).SendKeys("30");
                    PreviusCompletions = Driver.GetElement(By.XPath("//div[@id='allow-prev-completions-from']/div/label")).Text;
                    Driver.clickEleJs(By.Id("rt-date-save"));

                }
                if (v == "days_DDMM")
                {
                    Driver.existsElement(By.XPath("//div[@id='due-date-status']/div/div/div/span[2]"));
                    Driver.clickEleJs(By.XPath("//div[@id='due-date-status']/div/div/div/span[3]"));
                    Driver.clickEleJs(By.Id("Due_Date_Times_Once"));
                    Driver.existsElement(By.Id("Due_Date_When_Within_Amount"));
                    Driver.GetElement(By.Id("Due_Date_When_Within_Amount")).SendKeysWithSpace("15");
                    // Driver.clickEleJs(By.Id("Allow_Prev_Completions_From"));
                    Thread.Sleep(2000);
                    Driver.clickEleJs(By.XPath("//input[@id='Prev_completions_By_Date']"));
                    Driver.GetElement(By.XPath("//input[@id='Prev_completions_By_Date']")).Clear();
                    Driver.GetElement(By.XPath("//input[@id='Prev_completions_By_Date']")).SendKeysWithSpace("01/01");
                    Driver.GetElement(By.XPath("//input[@id='Prev_completions_By_Date']")).SendKeysWithSpace("01/01");
                    PreviusCompletions = Driver.GetElement(By.XPath("//label[contains(text(),'Yes, if completed since [MM/DD].')]")).Text;
                    Driver.clickEleJs(By.Id("rt-date-save"));

                }

            } catch
            { }
            return PreviusCompletions;
        }

        public bool? isAssignDueDateDisplay()
        {
            Driver.existsElement(By.XPath("//div[@id='due-date-modal']/div/div/div/h4"));
            Driver.existsElement(By.XPath("//div[@id='due-date-status']/label"));
            return Driver.existsElement(By.Id("rt-date-save"));
        }

        public void ClickCancel()
        {
            Driver.clickEleJs(By.XPath("//div[@id='due-date-modal']/div/div/div[3]/button"));
        }

        public void SetDueDateNonRecurring(string v)
        {

            if (v == "Within days")
            {
                Driver.existsElement(By.XPath("//div[@id='due-date-status']/div/div/div/span[2]"));
                Driver.clickEleJs(By.XPath("//div[@id='due-date-status']/div/div/div/span[3]"));
                Driver.clickEleJs(By.Id("Due_Date_Times_Once"));
                Driver.existsElement(By.Id("Due_Date_When_Within_Amount"));
                Driver.GetElement(By.Id("Due_Date_When_Within_Amount")).SendKeys("30");
                Driver.clickEleJs(By.Id("rt-date-save"));

            }
        }

        public void SetDueDateRecurring(string v)
        {
            if (v == "Within days")
            {
                Driver.existsElement(By.XPath("//div[@id='due-date-status']/div/div/div/span[2]"));
                Driver.clickEleJs(By.XPath("//div[@id='due-date-status']/div/div/div/span[3]"));
                Driver.clickEleJs(By.Id("Due_Date_Times_More"));
                Driver.existsElement(By.Id("Due_Date_Recur_Every_Number"));
                Driver.GetElement(By.Id("Due_Date_Recur_Every_Number")).SendKeys("30");
                Driver.GetElement(By.Id("Due_Date_Occur_Within_Time")).SendKeys("100");
                Driver.clickEleJs(By.Id("rt-date-save"));

            }
        }
    }


    public class AssignessTabCommand
    {
        public AssignessTabCommand()
        {
        }

        public AddAssignessModalCommand AddAssignessModal { get { return new AddAssignessModalCommand(); } }

        public void ClickAddAssignees()
        {
            Driver.existsElement(By.LinkText("Assignees"));
            Driver.clickEleJs(By.LinkText("Assignees"));
            Driver.existsElement(By.Id("btn-find-assignees"));
            Driver.clickEleJs(By.Id("btn-find-assignees"));
        }
    }

    public class AddAssignessModalCommand
    {
        public AddAssignessModalCommand()
        {
        }

        public bool? VerifyInactiveSearch()
        {
            bool result = false;
            try
            {
                Thread.Sleep(2000);
                Assert.IsTrue(Driver.GetElement(By.XPath("//div[@id='find-assignees-modal']/div/div/div/h3")).Text.Equals("Add Assignees"));
                Thread.Sleep(2000);
                var Resultcount = Driver.GetElement(By.XPath("//div[@id='find-assignees-modal']/div/div/div[4]/div[2]/div[2]/div[4]/div/span")).Text;
                //Thread.Sleep(2000);
                String[] count = Resultcount.Split(' ');
                //Thread.Sleep(2000);
                string Resultcount_active = count[5];
                //Thread.Sleep(5000);
                Driver.clickEleJs(By.Id("showInActiveAssignee"));
                Thread.Sleep(2000);
                Driver.existsElement(By.XPath("//div[@id='find-assignees-modal']/div/div/div[4]/div[2]/div[2]/div[4]/div/span"));
                Thread.Sleep(2000);
               
                var Resultcount1 = Driver.GetElement(By.XPath("//div[@id='find-assignees-modal']/div/div/div[4]/div[2]/div[2]/div[4]/div/span")).Text;
                Thread.Sleep(2000);
                String[] count1 = Resultcount1.Split(' ');
                //Thread.Sleep(2000);
                string Resultcount_Inactive = count1[5];
                //Thread.Sleep(5000);
                Driver.clickEleJs(By.XPath("//table[@id='find-assignees-table']/tbody/tr/td/input"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.Id("btn-add-assignees"));
                Driver.clickEleJs(By.XPath("//a[@href='#panel-assignees']"));

                Thread.Sleep(2000);
                //if (!(Resultcount_active.Equals(Resultcount_Inactive)))          //original Code working on External 19.1
                //{
                //    result = true;
                //}

                if (!(Resultcount_active.Equals(Resultcount_Inactive)))              //Due to Change in application i.e. productSite 19.1            
                {
                    result = true;
                }

            }
            catch
            { }
            return result;
        
        }

        public void Search(string v)
        {
            Driver.GetElement(By.Id("SearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("btn-search"));
        }

        public void AddAssigne(string v)
        {
            Driver.existsElement(WebElement_Locators.CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_SearchContentTextBox);
            Driver.GetElement(By.Id("MainContent_UC3_ddlSearchType")).ClickWithSpace();
            Driver.select(By.XPath("//div[@id='filter-group']/div/select"), "Exact phrase");
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//input[@id='SearchFor']"));
            Driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_Searchbtn);
            Thread.Sleep(3000);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_FirstSearchedresultListcheckBox);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_AddBtn);
        }
    }

    public class ContentTabCommand1
    {
        public AddContentModalCommand AddContentModal { get { return new AddContentModalCommand(); } }

        public void ClickAddContent()
        {
            Driver.existsElement(By.XPath("//li[@id='content-tab']/a"));
            Driver.clickEleJs(By.XPath("//li[@id='content-tab']/a"));
            Driver.clickEleJs(By.Id("btn-find-content"));

        }
    }

    public class AddContentModalCommand
    {
        public AddContentModalCommand()
        {
        }

        public bool? VerifyInactiveSearch()
        {
            bool result = false;
            try
            {
                Thread.Sleep(2000);
                Assert.IsTrue(Driver.GetElement(By.XPath("//div[@id='find-content-modal']/div/div/div/h3")).Text.Equals("Add Content"));
                Thread.Sleep(2000);
                var Resultcount = Driver.GetElement(By.XPath("//div[@id='find-content-modal']/div/div/div[2]/div[2]/div[2]/div[4]/div/span")).Text;
                //Thread.Sleep(5000);
                String[] count = Resultcount.Split(' ');
                //Thread.Sleep(5000);
                string Resultcount_active = count[5];
                //Thread.Sleep(5000);
                Driver.clickEleJs(By.Id("showInActiveContent"));
                Thread.Sleep(2000);
                Driver.existsElement(By.XPath("//div[@id='find-content-modal']/div/div/div[2]/div[2]/div[2]/div[4]/div/span"));
                Thread.Sleep(2000);
                var Resultcount1 = Driver.GetElement(By.XPath("//div[@id='find-content-modal']/div/div/div[2]/div[2]/div[2]/div[4]/div/span")).Text;
                Thread.Sleep(2000);
                String[] count1 = Resultcount1.Split(' ');
                //Thread.Sleep(5000);
                string Resultcount_Inactive = count1[5];
                //Thread.Sleep(5000);
                Driver.clickEleJs(By.XPath("//table[@id='find-content-table']/tbody/tr/td/input"));
                //Thread.Sleep(5000);
                Driver.clickEleJs(By.Id("btn-add"));
                Thread.Sleep(20000);
                 if (!(Resultcount_active.Equals(Resultcount_Inactive)))
                {
                    result= true;
                }
             

            }
            catch
            { }
            return result;
        }

        public void AddContent(string v="")
        {
            Driver.existsElement(WebElement_Locators.CreateTrainingAssignmentPage_ContentTab_AddContentModal_SearchContentTextBox);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_ContentTab_AddContentModal_SearchContentTextBox);

            Driver.GetElement(WebElement_Locators.CreateTrainingAssignmentPage_ContentTab_AddContentModal_SearchContentTextBox).SendKeysWithSpace(v);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_ContentTab_AddContentModal_Searchbtn);
            Thread.Sleep(3000);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_ContentTab_AddContentModal_FirstSearchedresultListcheckBox);
            Driver.clickEleJs(WebElement_Locators.CreateTrainingAssignmentPage_ContentTab_AddContentModal_AddBtn);
        }
    }
}