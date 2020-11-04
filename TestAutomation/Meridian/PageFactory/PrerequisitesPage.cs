using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class PrerequisitesPage
    {
       

        public static AppliedtoCommand Appliedto { get { return new AppliedtoCommand(); } }

        public static AddPrerequisitesModalCommand AddPrerequisitesModal { get { return new AddPrerequisitesModalCommand(); } }

        public static prerequisitesmustbecompleteddropdownCommand prerequisitesmustbecompleteddropdown { get { return new prerequisitesmustbecompleteddropdownCommand(); } }

        public static PrerequisiteresultTableCommand PrerequisiteresultTable { get { return new PrerequisiteresultTableCommand(); } }

        public static string GetSuccessMessage()
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public static void ClickAddPrerequisites()
        {
            if (Driver.GetElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']")).Text.Equals("Checkout"))
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            }
            if (Driver.existsElement(By.XPath("//a[@id='empty-prereq-add']")))
            {
                Driver.clickEleJs(By.XPath("//a[@id='empty-prereq-add']"));
            }
            else if(Driver.existsElement(By.XPath("//span[contains(text(),'Add Prerequisites')]")))
            {
                Driver.clickEleJs(By.XPath("//span[contains(text(),'Add Prerequisites')]"));
            }
               
        }

        public static void Selectrecord(string v)
        {
            throw new NotImplementedException();
        }

        public static void ClickBackbutton()
        {
            Driver.Instance.Navigate().Back();
        }

        public static void ClickRemovebutton()
        {
            throw new NotImplementedException();
        }

        public static bool? JSConfirmationMsg()
        {
            throw new NotImplementedException();
        }

        public static string GetPrerequisiteAssignedToContentItems()
        {
            throw new NotImplementedException();
        }

        public static string GetPrerequisiteAssignedToUserGroups()
        {
            throw new NotImplementedException();
        }

        public static bool? isSearchFiledsdisplay()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_lblSearchFor"));
                Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlSearch']/div[2]/div[2]/label"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save"));
                result = true;
            }
            catch { }
            return result; 
        }

        public static bool? isPrerequisitesadded()
        {

            return Driver.existsElement(By.XPath("//span[@class='fa fa-info-circle fa-lg']"));
            //return Driver.existsElement(By.XPath("//td[3]"));
        }

        public static void removeAddedPrerequisites()
        {
            Driver.existsElement(By.XPath("//td[1]/input"));
            //Driver.existsElement(By.XPath("//input[@id='content_AC8827E29FD74B9C8EFFA7201950BC72']"));
            //Driver.clickEleJs(By.XPath("//input[@id='content_AC8827E29FD74B9C8EFFA7201950BC72']"));
            Driver.clickEleJs(By.XPath("//td[1]/input"));
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Remove')]"));
           
            //Driver.Instance.SwitchTo().Alert().Accept();
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-prerequisites']"));

            Thread.Sleep(5000);

        }

        public static void ClickSave()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

        public static void ClickViewAsLearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static void Click_BreadCrumb(string v="")
        {
            if(Driver.existsElement(By.XPath("//div[@id='content']/div/ol/li[3]/a")))
            {
                Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
            }
            if(Driver.existsElement(By.XPath("//a[contains(text(),'"+v+"')]")))
            {
                Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
            }
        }

        public static string VerifyPrerequisiteMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static bool? IsPageDisplayed()
        {
            return Driver.existsElement(By.XPath("//h1[contains(@class,'page-title')]"));
        }

        public static string VerifyMessage()
        {
            return Driver.GetElement(By.XPath("//div[@id='no-prerequisites']/div/p/strong")).Text;
        }

        public static bool? VerifyAddPrerequisitesButtonIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//a[@id='empty-prereq-add']"));
        }

        public static void Click_AddPrerequisitesButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='empty-prereq-add']"));
        }

        public static bool? VerifyAddPrerequisitesModalIsDisplayed()
        {
            
            return Driver.existsElement(By.XPath("//div[@id='prereq-add']/div/div/div/h4"));
        }

        public static bool? VerifyContentIsDisplayedInAddPrerequisitesModal()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-prereq-add']/tbody/tr/td[2]"));
        }

        public static void SelectandAddPrerequisitesToAssign()
        {
            Driver.clickEleJs(By.XPath("//input[@id='btSelectAll_table-prereq-add']"));
            Driver.clickEleJs(By.XPath("//button[@id='prereq-modal-add']"));
        }

        public static int VerifyPrerequisitesAdded()
        {
            Driver.existsElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[2]"));
            string totleCount = Driver.Instance.FindElements(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[2]")).Count.ToString();
            return Driver.getIntegerFromString(totleCount);
        }

        public static bool? VerifyPrerequisitesDateAddedOn()
        {
            return Driver.existsElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[6]"));
        }

        public static string PrerequisitesCountInTable()
        {
            string con = Driver.GetElement(By.XPath("//div[@id='has-prerequisites']//span[@class='pagination-info']")).Text;
            string[] conlist = con.Split(' ');
            return conlist[5];

        }

        public static bool? VerifyAssignedPrerequisiteCount(string prereqcount)
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
            string con = Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/p")).Text;
            string[] conlist = con.Split(' ');
            if (conlist[0] == prereqcount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool? VerifyPrerequisitesValidPeriod()
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'Valid Period')]"));
        }

        public static bool? VerifyPrerequisitesTargetScoreIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'Target Score')]"));
        }

        public static void SelectAssignedPrerequsites()
        {
            Driver.clickEleJs(By.XPath("//table[@id='content-prerequisites']/tbody/tr[1]/td/input"));
        }

        public static bool? VerifyDeleteButtonisEnabled()
        {
            return Driver.GetElement(By.XPath("//span[contains(text(),'Remove')]")).Enabled;
        }

        public static void ClickDeleteButton()
        {
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Remove')]"));
            
        }

        public static bool? VerifyAlertBoxisDisplayed()
        {
            return Driver.existsElement(By.XPath("//h4[contains(text(),'Remove Prerequisite')]"));
        }

        public static void ClickOKofAlertBox()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-prerequisites']"));
        }

        public static bool? VerifyAssignedPrerequisitesareDeleted(int assignedPrequisiteCount)
        {
            Thread.Sleep(5000);
            string NewCount = Driver.Instance.FindElements(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[2]")).Count.ToString();
            return Driver.getIntegerFromString(NewCount) != assignedPrequisiteCount;
        }

        public static void ClickValidPeriodHotLink()
        {
            Driver.clickEleJs(By.XPath("//tr[1]//td[3]//a[1]"));
        }

        public static bool? VerifySaveDateTextBoxIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[3]/span/div/form/div/div"));
        }

        public static void EnterDateAndSaveTheDate(string v)
        {
            Thread.Sleep(2000);

            Driver.clickEleJs(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[3]/span/div/form/div/div/div/input"));
            Driver.GetElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[3]/span/div/form/div/div/div/input")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[3]/span/div/form/div/div/div[2]/button[1]"));
        }

        public static bool? VerifyEnteredDateIsSaved(string v)
        {
            Thread.Sleep(17000);
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
            return Driver.GetElement(By.XPath("//a[contains(text(),'"+v+"')]")).Text.StartsWith(v);
        }




        public static void ClickTargetScoreHotLink()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Not set')]"));
        }


        public static bool? VerifySaveTargetScoreTextBoxIsDisplayed()
        {
            //return Driver.existsElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr[3]/td[4]/span/div/form/div/div"));
            return Driver.existsElement(By.XPath("//input[@placeholder='Score (Number)']"));
        }

        public static void EnterTargetScoreAndSaveTheTargetScore(string v)
        {
            Driver.GetElement(By.XPath("//input[@placeholder='Score (Number)']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-primary btn-sm xeditable-submit']"));
            //Driver.GetElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr[3]/td[4]/span/div/form/div/div/div/input")).SendKeysWithSpace(v);
            // Driver.clickEleJs(By.XPath("//table[@id='content-prerequisites']/tbody/tr[3]/td[4]/span/div/form/div/div/div[2]/button[1]"));
            Thread.Sleep(20000);
        }

        public static bool? VerifyEnteredTargetScoreIsSaved(string v)
        {
            Driver.existsElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr[1]/td[4]/a"));
            return Driver.GetElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr[1]/td[4]/a")).Text.StartsWith(v);
        }

        public static bool? prerequisitesmustbecompleteddropdowndisplay()
        {
            return Driver.existsElement(By.XPath("//span[@class='filter-option pull-left'][contains(text(),'ALL')]"));
        }

        public static int prerequisitesmustbecompleteddropdownlist()
        {
            Driver.clickEleJs(By.XPath("//div[@id='has-prerequisites']/div/div/button/span[2]"));
            IWebElement select = Driver.Instance.FindElement(By.XPath("//div[@id='has-prerequisites']/div/div/select"));
            //IList <IWebElement> options = select.FindElements(By.TagName("li"));
            int count = select.Text.Split().Length;
            string retValue = select.Text.Split()[count - 1];
            return int.Parse(retValue);

        }

        public static int totlaPrerequisitesCountInTable()
        {
            string con = Driver.GetElement(By.XPath("//div[@id='has-prerequisites']//span[@class='pagination-info']")).Text;
            return Driver.getLastIntegerFromString(con);
        }

        public static string prerequisitesmustbecompleteddropdownlisttext()
        {
            Driver.clickEleJs(By.XPath("//div[@id='has-prerequisites']/div/div/button/span[2]"));
            return Driver.Instance.FindElement(By.XPath("//div[@id='has-prerequisites']/div/div/select")).Text;
        }
    }

    public class PrerequisiteresultTableCommand
    {
        public PrerequisiteresultTableCommand()
        {
        }

        public ValidPeriodCommand ValidPeriod { get { return new ValidPeriodCommand(); } }
    }

    public class ValidPeriodCommand
    {
        public ValidPeriodCommand()
        {
        }

        public bool? isAlwayslinkdisplay()
        {
            Thread.Sleep(15000);
            return Driver.existsElement(By.LinkText("Always"));
        }

        public bool? isCustomlinkdisplay()
        {
            Thread.Sleep(15000);
            return Driver.existsElement(By.LinkText("Custom"));
        }

        public void SetCustomdays(string v)
        {
            Driver.existsElement(By.LinkText("Always"));
            Driver.Instance.FindElement(By.LinkText("Always")).Click();
            //Driver.clickEleJs(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[3]/span/div/form/div/div/div/select"));
            Driver.select(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[3]/span/div/form/div/div/div/select"), "Custom");
            //Driver.clickEleJs(By.XPath("//td[3]/div/div/a"));
            Thread.Sleep(3000);
            Driver.clickEleJs(By.LinkText("#"));
            Driver.Instance.FindElement(By.XPath("//div/form/div/div/div/input")).Clear();
            Driver.Instance.FindElement(By.XPath("//div/form/div/div/div/input")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//span[@class='fa fa-check']"));
            Thread.Sleep(25000);
        }
    }

    public class prerequisitesmustbecompleteddropdownCommand
    {
        public prerequisitesmustbecompleteddropdownCommand()
        {
        }

        public void Selectlist(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='has-prerequisites']/div/div/button/span[2]"));
            Thread.Sleep(5000);
            Driver.select(By.XPath("//div[@id='has-prerequisites']/div/div/select"),v);
        }

        public bool? isListselectd(string v)
        {
            Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']"));
            return Driver.GetElement(By.XPath("//span[@class='filter-option pull-left']")).Text.Equals(v);
        }
    }

    public class AddPrerequisitesModalCommand
    {
        public AddPrerequisitesModalCommand()
        {
        }

        public void addprerequisite()
        {
            Driver.existsElement(By.Id("btSelectItem_undefined"));
            Driver.Instance.FindElement(By.Id("btSelectItem_undefined")).Click();
            Driver.Instance.FindElement(By.Id("prereq-modal-add")).Click();
        }

        public void clickNextPage()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'›')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'›')]"));

        }
    }

    public class AppliedtoCommand
    {
        public AppliedtoCommand()
        {
        }

        public void ClickManage()
        {
            Driver.existsElement(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[5]/small/a"));
            Driver.clickEleJs(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td[5]/small/a"));
        }
    }
}