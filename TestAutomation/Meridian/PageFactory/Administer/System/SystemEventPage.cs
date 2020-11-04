using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class SystemEventPage
    {
        public static summarywinCommand summarywin
        {
            get { return new summarywinCommand(); }
        }

        public static EventTableCommand EventTable { get { return new EventTableCommand(); } }

        public static AllTriggersDrowdownCommand AllTriggersDrowdown { get { return new AllTriggersDrowdownCommand(); } }

        public static string Title
        {
            get
            {
                Thread.Sleep(5000);
                Driver.Instance.selectWindow("Summary");

                return Driver.Instance.Title;
            }
        }

        public static ActionDropdownCommand ActionDropdown { get { return new ActionDropdownCommand(); } }

        public static EmailResultTableCommand EmailResultTable { get { return new EmailResultTableCommand(); } }

        public static bool? isInstructionTextdisplay()
        {
            return Driver.existsElement(By.XPath("//p[contains(text(),'You may manage the status of your automatic system')]"));
        }

        public static bool? ispagehasPagination()
        {
            return Driver.existsElement(By.XPath("//ul[@class='pagination']"));
        }

        public static bool? isSearchTextboxisDisplay()
        {
            return Driver.existsElement(By.XPath("//input[@id='SearchFor']"));
        }

        public static void Search(string v)
        {
            if (v != "")
            {
                Driver.clickEleJs(By.XPath("//input[@id='SearchFor']"));
                Driver.GetElement(By.XPath("//input[@id='SearchFor']")).Clear();
                Driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeys(v);
                Thread.Sleep(5000);
                Driver.GetElement(By.XPath("//input[@id='filter-inactive-check']")).ClickWithSpace();
                Driver.clickEleJs(By.XPath("//button[@id='btnSearchEvents']/span"));
            }
            else
            {
                Driver.clickEleJs(By.XPath("//input[@id='SearchFor']"));
                Driver.GetElement(By.XPath("//input[@id='SearchFor']")).Clear();                
                Driver.clickEleJs(By.XPath("//input[@id='filter-inactive-check']"));
                Driver.clickEleJs(By.XPath("//button[@id='btnSearchEvents']/span"));
            }
        }

        public static void clickInactivecheckbox()
        {
            Driver.clickEleJs(By.XPath("//input[@id='filter-inactive-check']"));
            Thread.Sleep(5000);
        }

        public static bool? isResultGriddisplay()
        {
            return Driver.existsElement(By.XPath("//div[@class='fixed-table-container table-no-bordered']"));
        }
    }

    public class EmailResultTableCommand
    {
        public EmailResultTableCommand()
        {
        }

        public ActionsCommand Actions { get { return new ActionsCommand(); } }
    }

    public class ActionsCommand
    {
        public ActionsCommand()
        {
        }

        public void ClickEdit(string v)
        {
            if(v.ToLower().Equals("firstresult"))
            {
                Driver.clickEleJs(By.XPath("//button[@id='actions']/i"));
                Thread.Sleep(1000);
                Driver.clickEleJs(By.XPath("//body/ul/li/a"));
            }
        }
    }

    public class ActionDropdownCommand
    {
        public ActionDropdownCommand()
        {
        }

        public void ActionSecect(string v)
        {
            if(v== "Inactive")
            {
                Driver.clickEleJs(By.XPath("//div[@id='content']/div/div/div/div/div/div/button/span[2]/span"));
                Driver.clickEleJs(By.XPath("//div[@id='content']/div/div/div/div/div/div/div/ul/li[2]/a/span"));
            }
        }
    }

    public class summarywinCommand
    {
        public summarywinCommand()
        {
        }

        public bool? isemailTitledisplay(string firsteventName)
        {
            return Driver.GetElement(By.XPath("//div[@id='TabMenu_div0']/table[2]/tbody/tr[2]/td[2]")).Text.Contains(firsteventName);
        }
    }

    public class AllTriggersDrowdownCommand
    {
        public AllTriggersDrowdownCommand()
        {
        }

        public void select(string v)
        {
            Driver.clickEleJs(By.XPath("//div/div/div/button/span[2]"));
            Driver.select(By.Id("searchList"), v);
        }
    }

    public class EventTableCommand
    {
        public EventTableCommand()
        {
        }

        public TriggerCommand Trigger { get { return new TriggerCommand(); } }

        public ActionCommand Action { get { return new ActionCommand(); } }

        public bool? isCulumnPresent(string v1, string v2, string v3, string v4, string v5)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Email Title')]"));
            Driver.existsElement(By.XPath("//a[contains(text(),'Trigger')]"));
            Driver.existsElement(By.XPath("//a[contains(text(),'Status')]"));
            Driver.existsElement(By.XPath("//div[contains(text(),'Actions')]"));
            return Driver.existsElement(By.XPath("//div[contains(text(),'Info')]"));

        }

        public bool? isEmailOpenswith(string v)
        {
            Driver.existsElement(By.XPath("//table[@id='tableEvents']/tbody/tr/td[2]/a"));
            return Driver.GetElement(By.XPath("//table[@id='tableEvents']/tbody/tr/td[2]/a")).Text.Contains(v);
        }

        public string getfirsteventname()
        {
            return Driver.GetElement(By.XPath("//table[@id='tableEvents']/tbody/tr/td[2]/a")).Text;
        }

        public void ClickActiveLink(string v)
        {
            Driver.clickEleJs(By.XPath("//td[4]/div/a/span"));
        }

        public bool? StatusActionMenus(string v1, string v2, string v3)
        {
            Driver.GetElement(By.XPath("//body/ul/li/a")).Text.Equals(v1);
            Driver.GetElement(By.XPath("//body/ul/li[2]/a")).Text.Equals(v2);
            return Driver.GetElement(By.XPath("//body/ul/li[3]/a")).Text.Equals(v3);
        }

        public void SelectStatusAction(string v)
        {
            if(v=="Inactive")
            {
                Driver.clickEleJs(By.XPath("//body/ul/li[2]/a"));
            }
            if (v == "Active")
            {
                Driver.clickEleJs(By.XPath("//body/ul/li/a"));
            }
            if (v == "Set Active Dates")
            {
                Driver.clickEleJs(By.XPath("//body/ul/li[3]/a"));
                Thread.Sleep(4000);
                Driver.clickEleJs(By.XPath("//div[@id='set-active-dates']/div/div/div[3]/button"));
            }
            
        }

        public bool? isStatus(string v)
        {
            Driver.existsElement(By.XPath("//span[@class='single-status-value']"));
            return Driver.GetElement(By.XPath("//span[@class='single-status-value']")).Text.Equals(v);
        }

        public void ClickInfoIconFistrecord()
        {
            Driver.clickEleJs(By.XPath("//td[6]/a/span"));
        }     

        public bool? isNorecordfoundDisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='tableEvents']/tbody/tr/td"));
        }

        public int getTotalCount()
        {
            string number = Driver.GetElement(By.XPath("//span[@class='pagination-info']")).Text;
            return Driver.getLastIntegerFromString(number);
        }

        public void SelectFirstRecord()
        {
            Driver.clickEleJs(By.XPath("//tr[1]//td[1]//input[1]"));
        }

        public void closeSummaywindow()
        {
            Driver.focusParentWindow();
        }
    }

    public class ActionCommand
    {
        public CopyModalCommand CopyModal { get { return new CopyModalCommand(); } }

        public SenTestEmailModalCommand SenTestEmailModal { get { return new SenTestEmailModalCommand(); } }

        public ActionCommand()
        {
        }
        public void ClickCopy(string v)
        {
            Driver.clickEleJs(By.Id("actions"));
            Driver.clickEleJs(By.XPath("//body/ul/li[2]/a"));
        }

        public bool? isCopyModaldisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='email-copy-confirm']/div/div/div/h4"));
        }

        public void delete(string v)
        {
            Driver.clickEleJs(By.Id("actions"));
            Thread.Sleep(5000);
            Driver.Instance.FindElement(By.LinkText("Delete")).Click();
            Driver.Instance.FindElement(By.Id("btnDeleteEmail")).Click();
        }

        public void ClickEdit()
        {
            Driver.clickEleJs(By.Id("actions"));
            Driver.clickEleJs(By.XPath("//body/ul/li/a"));
        }

        public void ClickSendTestEmail()
        {
            Driver.clickEleJs(By.Id("actions"));
            Driver.clickEleJs(By.XPath("//body/ul/li[3]/a"));
        }

        public bool? isSendEmailModaldisplay()
        {
            throw new NotImplementedException();
        }

        public bool? isSendTestEmailModaldisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='email-test-confirm']/div/div/div/h4"));
        }
    }

    public class SenTestEmailModalCommand
    {
        public SenTestEmailModalCommand()
        {
        }

        public void ClickSendEmail()
        {
            Driver.clickEleJs(By.Id("btnSendTestEmail"));
        }

        public void FillEmail(string v)
        {
            Driver.GetElement(By.Id("email-test-recipients")).Clear();
            Driver.GetElement(By.Id("email-test-recipients")).SendKeysWithSpace(v);

        }

        public void ClickCancel()
        {
            Driver.clickEleJs(By.XPath("//div[4]/div/div/div[3]/button"));
        }
    }

    public class CopyModalCommand
    {
        public CopyModalCommand()
        {
        }

        public bool? isNamedisplay()
        {
            return Driver.existsElement(By.Id("copy-email-title"));
        }

        public void Copywithnewname(string v)
        {
            Driver.GetElement(By.Id("copy-email-title")).Clear();
            Driver.GetElement(By.Id("copy-email-title")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("btnCopyEmail"));
        }
    }

    public class TriggerCommand
    {
        public TriggerCommand()
        {
        }

        public void ClickShowmore()
        {
            Driver.clickEleJs(By.XPath("//table[@id='tableEvents']/tbody/tr/td[3]/a/span"));

        }

        public bool? istriggerdiscriptiondisplay()
        {
            return Driver.existsElement(By.XPath("//small"));
        }
    }
}