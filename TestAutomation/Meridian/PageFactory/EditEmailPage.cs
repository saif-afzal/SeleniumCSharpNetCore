using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class EditEmailPage
    {
        public static SubjectCommand Subject { get { return new SubjectCommand(); } }

        public static EmailBodyRichTextCommand EmailBodyRichText { get { return new EmailBodyRichTextCommand(); } }

        public static PreviewEmailModalCommand PreviewEmailModal { get { return new PreviewEmailModalCommand(); } }

        public static void ClickSave()
        {
            Driver.clickEleJs(By.Id("ML.BASE.BTN.Save"));
            
        }

        public static void ClickReturn()
        {
            Driver.existsElement(By.Id("Return"));
            Driver.clickEleJs(By.Id("Return"));
        }

        public static string getSubjectText()
        {
            Driver.clickEleJs(By.Id("edit-email-subject"));
            return Driver.GetElement(By.Id("edit-email-subject")).Text;
        }

        public static bool? isSubjectisUpdatedwithfieldCodeattheend(string selectedfieldCode)
        {
            Thread.Sleep(5000);
            Driver.clickEleJs(By.Id("edit-email-subject"));
            return Driver.GetElement(By.Id("edit-email-subject")).Text.EndsWith(selectedfieldCode);
        }

        public static bool? isEmailBodyisUpdatedwithfieldCodeattheEnd(string v)
        {
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//div[@id='edit-system-events']/div/div[2]/div[2]/div[4]/div/div/div[3]/div/p"));
            return Driver.GetElement(By.XPath("//div[@id='edit-system-events']/div/div[2]/div[2]/div[4]/div/div/div[3]/div/p")).Text.Contains(v);
        }

        public static bool? isPreviewButtondisplay()
        {
            if(Driver.existsElement(By.XPath("//div[@id='edit-system-events']/div/div[3]/button[2]")))
            {
                return true;
            }
            if (Driver.existsElement(By.XPath("//button[contains(text(),'Preview')]")))
            {
                return true;
            }
            else return false;
        }

        public static void ClickPreviewbutton()
        {
            Driver.clickEleJs(By.XPath("//div[@id='edit-system-events']/div/div[3]/button[2]"));
        }

        public static bool? isPreviewEmailModalOpen()
        {
            Driver.existsElement(By.XPath("//div[@id='preview-email']/div/div/div/h4"));
            return Driver.GetElement(By.XPath("//div[@id='preview-email']/div/div/div/h4")).Text.Equals("Preview Email");
        }

        public static void BrowseandUploadfile(string v)
        {
            Driver.Instance.navigateAICCfile(v, By.XPath("//input[@id='uploadAttachmentFile']"));
        }

        public static bool? isValidationmessagedidisplay()
        {
            Driver.existsElement(By.XPath("//div[4]/ul/li"));
            return Driver.GetElement(By.XPath("//div[4]/ul/li")).Text.StartsWith("Invalid extension");
        }

        public static bool? isfileisuploaded()
        {
            return Driver.existsElement(By.XPath("//i[@class='fa fa-trash']"));
        }

        public static void DeleteduploaededFile()
        {
            Driver.clickEleJs(By.XPath("//i[@class='fa fa-trash']"));
        }

        public static void ClickSystemeventBreadcromb()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[4]/a"));
        }

        public static void clickBreadcrumb(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
        }

        public static string getEmailTitle()
        {
            return Driver.GetElement(By.Id("email-title-edit-link")).Text;
        }

        public static void UpdateEmailTitle(string v)
        {
            Driver.clickEleJs(By.Id("email-title-edit-link"));
            Driver.GetElement(By.Id("email-title-edit-link")).Clear();
            Driver.GetElement(By.Id("email-title-edit-link")).SendKeysWithSpace(v);
        }

        public static void UpdateSubject(string v)
        {
            Driver.clickEleJs(By.Id("edit-email-subject"));
            Driver.GetElement(By.Id("edit-email-subject")).Clear();
            Driver.GetElement(By.Id("edit-email-subject")).SendKeysWithSpace(v);
        }
    }

    public class PreviewEmailModalCommand
    {
        public PreviewEmailModalCommand()
        {
        }

        public bool? isEmailTiteldisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='preview-email']/div/div/div[2]/h3"));
        }

        public void ClickClose()
        {
            Driver.clickEleJs(By.XPath("//div[@id='preview-email']/div/div/div[4]/button"));
        }
    }

    public class EmailBodyRichTextCommand
    {
        public EmailBodyRichTextCommand()
        {
        }

        public SelectFieldCodeModalCommand SelectFieldCodeModal { get { return new SelectFieldCodeModalCommand(); } }

        public void ClickSelectFieldCode()
        {
            Driver.clickEleJs(By.XPath("//div[@id='edit-system-events']/div/div[2]/div[2]/div[4]/div/div[2]/a"));
        }

        public bool? isSelectFieldCodeModalOpen()
        {
            return Driver.existsElement(By.XPath("//div[@id='dialog-field-code-insert']/div/div/div/h4"));
        }
    }

    public class SubjectCommand
    {
        public SubjectCommand()
        {
        }

        public SelectFieldCodeModalCommand SelectFieldCodeModal { get { return new SelectFieldCodeModalCommand(); } }

        public void CLickSelectFieldCode()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Select Field Codes')]"));
        }

        public bool? isSelectFieldCodeModalOpen()
        {
            return Driver.existsElement(By.XPath("//div[@id='dialog-field-code-insert']/div/div/div/h4"));
        }
    }

    public class SelectFieldCodeModalCommand
    {
        public SelectFieldCodeModalCommand()
        {
        }

        public string getFirstfieldcodetext()
        {
            return Driver.GetElement(By.XPath("//table[@id='edit-email-field-code-insert']/tbody/tr/td[2]/span")).Text;
        }

        public void SelectandSaveSubjectFieldCode()
        {
            Driver.clickEleJs(By.XPath("//table[@id='edit-email-field-code-insert']/tbody/tr/td/input"));
            Driver.clickEleJs(By.Id("btn-add-email-field-code-insert"));
        }
    }
}