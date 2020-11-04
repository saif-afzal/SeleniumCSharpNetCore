using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class TrainingAssignmentsPage
    {
        public static AssigneesLinksCommand AssigneesLinks { get { return new AssigneesLinksCommand(); } }

        public static AssignmentsLinksCommand AssignmentsLinks { get { return new AssignmentsLinksCommand(); } }

        public static ContentsCommand Contents { get { return new ContentsCommand(); } }

        public static SearchDropdownCommand SearchDropdown { get { return new SearchDropdownCommand(); } }

        public static StatusFilterCommand StatusFilter { get { return new StatusFilterCommand(); } }

        public static ListofContentCommand ListofContent { get { return new ListofContentCommand(); } }

        public static bool? VerifyisListofAssignmentsdisplay()
        {
            return Driver.existsElement(By.XPath("//tr[@data-index='0']//td[2]"));
        }

        public static bool? isListofContentdisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='training-assignment-content']/tbody/tr/td"));
        }

        public static void SearchbyContent(string v)
        {
            Driver.GetElement(By.XPath("//input[@placeholder='Search by content']")).Clear();
            Driver.GetElement(By.XPath("//input[@placeholder='Search by content']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//a[@id='btn-search']"));

        }

        public static int Totalnumberofresultdisplay()
        {
            string total = Driver.GetElement(By.XPath("//div[@id='pane-search-content']/div/div[2]/div[4]/div/span")).Text;
            return Driver.getIntegerFromString(total);
        }

        public static void SearchTrainingAssignment(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='search-text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//a[@id='btn-search']"));
        }

       

        public static bool? VerifyDueDate_None(string v)
        {
            return Driver.GetElement(By.XPath("//table[@id='training-assignment']/tbody/tr/td[3]")).Text.Equals("None");

        }

        public static bool? VerifyDueDate(string firstDueDate)
        {
            return Driver.GetElement(By.XPath("//table[@id='training-assignment']/tbody/tr/td[3]")).Text.Equals(firstDueDate);
        }
    }

    public class ListofContentCommand
    {
        public bool? VerifyAssigneesColumnisNotSortable { get { return Driver.Instance.FindElement(By.XPath("//div[contains(text(),'Assignees')]")).GetCssValue("class").Contains("sortable both"); } }

       

        public ListofContentCommand()
        {
        }

        public bool? VerifyColumns(string v1, string v2, string v3, string v4, string v5, string v6)
        {
            bool result = false;
            try
            {
                Driver.GetElement(By.XPath("//table[@id='training-assignment-content']/thead/tr/th[1]/a")).Text.Equals(v1);
                Driver.GetElement(By.XPath("//table[@id='training-assignment-content']/thead/tr/th[2]/a")).Text.Equals(v2);
                Driver.GetElement(By.XPath("//table[@id='training-assignment-content']/thead/tr/th[3]/a")).Text.Equals(v3);
                Driver.GetElement(By.XPath("//table[@id='training-assignment-content']/thead/tr/th[4]/div[1]")).Text.Equals(v4);
                Driver.GetElement(By.XPath("//table[@id='training-assignment-content']/thead/tr/th[5]/div[1]")).Text.Equals(v5);
                Driver.GetElement(By.XPath("//table[@id='training-assignment-content']/thead/tr/th[6]/div[1]")).Text.Equals(v6);
                result = true;



            }
            catch { }
            return result;
        }

        public bool? VerifyAssignmentColumnisNotSortable()
        {
            return Driver.Instance.FindElement(By.XPath("//div[contains(text(),'Assignments')]")).GetCssValue("class").Contains("sortable both");
        }

        public bool? VerifyResultisdisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='training-assignment-content']/tbody/tr/td"));
        }

        public int VerifyResultsByStatusInActive()
        {
            string total = Driver.GetElement(By.XPath("//div[@id='pane-search-content']/div/div[2]/div[4]/div/span")).Text;
            return Driver.getIntegerFromString(total);
        }

        public void ClickonStatusHeader()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Status')]"));
        }

        public bool? isStatusdisplay(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'Pending')]"));
        }
    }

    public class StatusFilterCommand
    {
        public StatusFilterCommand()
        {
        }

        public bool? VerifyIsActiveSelecte { get { return Driver.GetElement(By.XPath("//div[@id='has-assignment']/div/div[2]/div/div[2]/button/span")).Text.Contains("Active"); } }

        public void SelectInActive()
        {
            Driver.clickEleJs(By.XPath("//div[@id='has-assignment']/div/div[2]/div/div[2]/button"));
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Inactive')]"));
            Driver.clickEleJs(By.XPath("//span[@class='text'][contains(text(),'Active')]"));
            Driver.clickEleJs(By.XPath("//body[@class='canvas']/form[@id='Form1']/div[@id='MainContainer']/div[@id='content']/div[@class='col-xs-12']/div[@class='portlet']/div[@id='has-assignment']/div[1]"));
        }

        public bool? VerifyIsPendingisSelected()
        {
            Driver.clickEleJs(By.XPath("//div[@id='has-assignment']/div/div[2]/div/div/button/span[2]/span"));
            return Driver.GetElement(By.XPath("//span[contains(text(),'Pending')]/following::span[1]")).Displayed;
        }
    }

    public class AssigneesLinksCommand
    {
        public AssigneesLinksCommand()
        {
        }

        public AssigneesModalCommand AssigneesModal { get { return new AssigneesModalCommand(); } }
    }

    public class AssignmentsLinksCommand
    {
        public AssignmentsLinksCommand()
        {
        }

        public AssigmnentsModalCommand AssigmnentsModal { get { return new AssigmnentsModalCommand(); } }

        public AssigneesModalCommand AssigneesModal { get { return new AssigneesModalCommand(); } }

       
    }

    public class AssigneesModalCommand
    {
        public AssigneesModalCommand()
        {
        }

        public bool? VerifyAssigneesList()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//div[@id='modal-content-assignees']/div/div/div/h3"));
                Driver.GetElement(By.XPath("//div[@id='modal-content-assignees']/div/div/div/h3")).Text.Equals("Assignees");
                Driver.GetElement(By.XPath("//div[@id='modal-content-assignees']/div/div/div[2]/h3")).Text.Equals("This content item is assigned to the following users:");
                Driver.GetElement(By.XPath("//table[@id='assignee-grid']/thead/tr/th/a")).Text.Equals("Name");
                Driver.GetElement(By.XPath("//table[@id='assignee-grid']/thead/tr/th[2]/a")).Text.Equals("Type");
                Driver.GetElement(By.XPath("//table[@id='assignee-grid']/thead/tr/th[3]/a")).Text.Equals("Status");
                Driver.GetElement(By.XPath("//table[@id='assignee-grid']/thead/tr/th[4]/a")).Text.Equals("Assignments");
                Driver.existsElement(By.XPath("//table[@id='assignee-grid']/tbody/tr/td"));

                result = true;

            }
            catch { }
            return result;
        }

        public string AssigmentTitleText(string v)
        {
            return Driver.GetElement(By.XPath("//table[@id='assignee-grid']/tbody/tr/td[4]/a")).Text;
        }

        public void Click_Assignmentlink()
        {
            Driver.clickEleJs(By.XPath("//table[@id='assignee-grid']/tbody/tr/td[4]/a"));
        }
    }

    public class AssigmnentsModalCommand
    {
        public AssigmnentsModalCommand()
        {
        }

        public bool? VerifyAssignmentsList()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[contains(@href, '#modal-content-assignments')]"));
                Driver.GetElement(By.XPath("//div[@id='modal-content-assignments']/div/div/div/h3")).Text.Equals("Assignments");
                Driver.GetElement(By.XPath("//div[@id='modal-content-assignments']/div/div/div[2]/h3")).Text.Equals("The following assignments include this content item:");
                Driver.GetElement(By.XPath("//table[@id='assignment-grid']/thead/tr/th/a")).Text.Equals("Name");
                Driver.GetElement(By.XPath("//table[@id='assignment-grid']/thead/tr/th[2]/a")).Text.Equals("Status");
                Driver.existsElement(By.XPath("//table[@id='assignment-grid']/tbody/tr/td/a"));
                Driver.existsElement(By.XPath("//div[@id='modal-content-assignments']/div/div/div[3]/button"));

                result = true;

            }
            catch { }
            return result;
        }

        public void Click_AssigmentTitle()
        {
            Driver.clickEleJs(By.XPath("//table[@id='assignment-grid']/tbody/tr[1]/td/a"));
        }

        public string AssigmentTitleText(string v)
        {
            return Driver.GetElement(By.XPath("//table[@id='assignment-grid']/tbody/tr/td/a")).Text;
        }
    }

    public class ContentsCommand
    {
        public ContentsCommand()
        {
        }

        public bool? isAssignmentsLinkPresent()
        {
            return Driver.existsElement(By.XPath("//a[contains(@href, '#modal-content-assignments')]"));
        }

        public bool? isAssigneesLinkPresent()
        {
            return Driver.existsElement(By.XPath("//table[@id='training-assignment-content']/tbody/tr/td[5]/a"));
        }

        public void Click_AssigneesLink()
        {
            Driver.clickEleJs(By.XPath("//table[@id='training-assignment-content']/tbody/tr/td[5]/a"));
        }
    }

    public class SearchDropdownCommand
    {
        public SearchDropdownCommand()
        {
        }

        public void Select(string v)
        {
            Driver.existsElement(By.XPath("//button[@id='search-filter']/span"));
            Driver.clickEleJs(By.XPath("//button[@id='search-filter']/span"));
            Driver.clickEleJs(By.XPath("//a[contains(@href, '#pane-search-content')]"));

        }
    }
}