using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CurriculumContentPage
    {
        public static AddCurriculumBlockCommand AddCurriculumBlock { get { return new AddCurriculumBlockCommand(); } }

        public static addedCurriculumContentCommand addedContent { get { return new addedCurriculumContentCommand(); } }

        public static void ClickAddCurriculumBlock()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_MLinkButton1"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_MLinkButton1"));
           // Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            

        }
        public static bool? VerifyOrderedTypeIsAvailable()
        {
            return Driver.existsElement(By.XPath("//strong[contains(.,'Ordered')]"));
        }

        public static void CurriculumContentFrame_SelectType(string v)
        {
            throw new NotImplementedException();
        }

        public static void CurriculumContentFrame_Title_Text(string v)
        {
            throw new NotImplementedException();
        }

        public static void CurriculumContentFrame_ClickSave()
        {
            throw new NotImplementedException();
        }

        public static bool GetSuccessMessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text.Equals(v);
        }

        public static void ClickAddTrainingActivities(string v="")
        {
            Driver.existsElement(By.LinkText("Add Training Activities"));
            Driver.clickEleJs(By.LinkText("Add Training Activities"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl13_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAddActivity']"));


        }

        public static void Selectrecord(string v)
        {
            throw new NotImplementedException();
        }

        public static void ClickRemovebutton()
        {
            throw new NotImplementedException();
        }

        public static void ClickBackbutton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));

        }

        public static void RemoveTrainingActivities()
        {
            Driver.existsElement(By.XPath("//td[2]/input"));
            Driver.clickEleJs(By.XPath("//td[2]/input"));
            Driver.clickEleJs(By.LinkText("Remove"));
            Thread.Sleep(2000);
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

        }

        public static bool? isCreditCompenetsDisplay()
        {
            bool result = false;
            try
            {
                if(Driver.GetElement(By.XPath("//div[2]/div/div/label")).Text.Equals("Required Credit Type")||Driver.GetElement(By.XPath("//div[2]/label")).Text.Equals("Required Credits"))
                {
                    result = true;
                }
            }
            catch
            { }
            return result;
        }

        public static void ClickEditContent()
        {
            Driver.clickEleJs(By.XPath("//a[@class='btn btn-default mr-1']"));
        }

        public static void AddTrainingActivities_UnOrdered(string s)
        {
            Driver.existsElement(By.XPath("//div[1]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/a[contains(text(),'Add Training Activities')]"));
            Driver.clickEleJs(By.XPath("//div[1]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/a[contains(text(),'Add Training Activities')]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(s);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect']"));
            if (Driver.Instance.IsElementVisible(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAddActivity']"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));

            } }

        public static void ClickAddTrainingActivitiesbutton()
        {
            Driver.existsElement(By.LinkText("Add Training Activities"));
            Driver.clickEleJs(By.LinkText("Add Training Activities"));
        }

        public static void AddTrainingActivities_Ordered(string v="")
        {
            Driver.clickEleJs(By.XPath("//strong[contains(text(),'Ordered')]/following::a[contains(.,'Add Training Activities')]"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl07_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAddActivity']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
        }

        public static void AddTrainingActivities_Credit()
        {
            Driver.clickEleJs(By.XPath("//div[3]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/a[contains(text(),'Add Training Activities')]"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl07_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAddActivity']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
        }

        public static void AddTrainingActivities_Optional()
        {
            Driver.clickEleJs(By.XPath("//div[4]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/a[contains(text(),'Add Training Activities')]"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl07_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAddActivity']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
        }

        public static void Remove_PreRequisites()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//table[@id='content-prerequisites']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Remove')]"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-prerequisites']"));
            //Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']"));
        }
    }

    public class addedCurriculumContentCommand
    {
        public addedCurriculumContentCommand()
        {
        }

        public bool? isEvaluationAdded()
        {
            return Driver.existsElement(By.XPath("//td[4]/a"));
        }
    }
}

public class AddCurriculumBlockCommand
{
    public AddCurriculumBlockCommand()
    {
    }

    public void AddBlockAs(string v)
    {

        Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        Thread.Sleep(10000);
        IWebElement BlockName = Driver.GetElement(By.Id("MainContent_UC1_BLOCK_NAME"));
        BlockName.ClickWithSpace();
        BlockName.Clear();
        BlockName.SendKeysWithSpace(v);
        //Driver.GetElement(By.Id("MainContent_UC1_BLOCK_NAME")).Clear();
        //Driver.GetElement(By.Id("MainContent_UC1_BLOCK_NAME")).SendKeysWithSpace(v);
        Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        Driver.Instance.SwitchtoDefaultContent();
    }

    public void AddCreditBlockAs(string v)
    {
        Driver.existsElement(By.XPath("//span[@id='MainContent_UC1_BLOCK_TYPE']/label[3]"));
        Driver.clickEleJs(By.XPath("//span[@id='MainContent_UC1_BLOCK_TYPE']/label[3]"));
        IWebElement box_Search = Driver.GetElement(By.Id("MainContent_UC1_BLOCK_NAME"));
        box_Search.Clear();
        box_Search.SendKeys(v);
        IWebElement ordered = Driver.GetElement(By.Id("MainContent_UC1_BLOCK_TYPE_1"));
        ordered.Click();
        Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
    }

    public void AddMultiple_TypeBlocks(string block)
    {
        Driver.Instance.GetElement(By.XPath("//input[@name='ctl00$MainContent$UC1$BLOCK_NAME']")).SendKeysWithSpace(block + "_UnOrdered");
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_AddAnotherBlock']"));
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_BLOCK_TYPE_1']"));
        Driver.Instance.GetElement(By.XPath("//input[@name='ctl00$MainContent$UC1$BLOCK_NAME']")).SendKeysWithSpace(block + "_Ordered");
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_AddAnotherBlock']"));
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_BLOCK_TYPE_2']"));
        Driver.Instance.GetElement(By.XPath("//input[@name='ctl00$MainContent$UC1$BLOCK_NAME']")).SendKeysWithSpace(block + "_Credit");
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_AddAnotherBlock']"));
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_BLOCK_TYPE_3']"));
        Driver.Instance.GetElement(By.XPath("//input[@name='ctl00$MainContent$UC1$BLOCK_NAME']")).SendKeysWithSpace(block + "_Optional");
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
    }

    public void AddBlockAs_OrderedType(string v)
    {
        Driver.waitforframe();
        Thread.Sleep(10000);
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_BLOCK_TYPE_1']"));
        Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_BLOCK_NAME']")).Clear();
        Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_BLOCK_NAME']")).SendKeysWithSpace(v);
        Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));

    }
}
