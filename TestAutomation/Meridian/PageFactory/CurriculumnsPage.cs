using System;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CurriculumsPage
    {
        public static bool? VerifyCancelButton()
        {
            return Driver.Instance.FindElement(By.Id("MainContent_ucPrimaryActions_FormView1_CancelEnrollementReason")).Displayed;
        }

        public static bool? VerifyEnrollButton()
        {
            return Driver.Instance.FindElement(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCurriculumButtonFlag")).Displayed;
        }
        public static CurriculumContentCommand CurriculumContent
        {
            get { return new CurriculumContentCommand(); }
        }

        public static DisplayFormatCommand DisplayFormatDropdown { get { return new DisplayFormatCommand(); }}

        public static void Create(object reg_Curriculumn)
        {
            throw new NotImplementedException();
        }

        public static string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }

        public static void ClickCheckin()
        {
            throw new NotImplementedException();
        }

        public static void ClickCheckout()
        {
            throw new NotImplementedException();
        }

        public static void EditSummary()
        {
            throw new NotImplementedException();
        }

        public static void Edit_Click(IWebDriver driver)
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
        }

        public static void ClickSave()
        {

        }

        public static curriculumCreatCommand TitleAs(string title)
        {
            return new curriculumCreatCommand(title);
        }

        public static void Create(object title, object tags, object isCollaborationOptionAvailable)
        {
            throw new NotImplementedException();
        }

        public static string GetPrerequisiteMessage()
        {
            throw new NotImplementedException();
        }

        public static bool? searchforCurriculam(string coursetitle, string generalcoursetitle)
        {
            bool result = false;
            try
            {
                CommonSection.SearchCatalog(coursetitle);
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'" + coursetitle + "')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'" + coursetitle + "')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'" + generalcoursetitle + "')]"));
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CurriculumLaunchAttempt']"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'" + generalcoursetitle + "')]"));


                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static void FillTitle(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='CNTLCL_TITLE']")).SendKeysWithSpace(v);
        }

        public static void SelectCollaborationSpaceOption(string v)
        {
            if(v=="Yes")
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_FormView1_fvCurriculum_CRLM_CSPACE_AVLBLE_0']"));
            }
            else
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_FormView1_fvCurriculum_CRLM_CSPACE_AVLBLE_1']"));

            }
        }

        public static void CreateCurriculum()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));

        }
    }



}
public class curriculumCreatCommand
    {
        private string title;

        public curriculumCreatCommand(string title)
        {
            this.title = title;
        }

    public void Create()
        {
            Driver.Instance.WaitForElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(title);
            Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_fvCurriculum_CRLM_CSPACE_AVLBLE_0"));
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
            Thread.Sleep(2000);
        }
    }

    public class CurriculumContentCommand
    {
    public void ClickEdit()
        {
            throw new NotImplementedException();
        }

    public void addContentIntoCurriculam(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucTrainingActivity_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_MLinkButton1']"));
            Driver.Instance.SelectFrame(By.XPath("//span[@class='k-window-title']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_BLOCK_NAME']")).SendKeysWithSpace("Block1");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Driver.Instance.SwitchtoDefaultContent();
            Driver.clickEleJs(By.XPath("//a[contains(.,'Add Training Activities')]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAddActivity']"));
        }
    }
