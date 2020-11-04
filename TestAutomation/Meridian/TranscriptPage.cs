using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{
    public class TranscriptPage
    {
       

        public static AllMyTrainingPageCommand AllMyTrainingPage
        {
            get { return new AllMyTrainingPageCommand(); }
        }

        public static CertificationTabCommand CertificationTab
        {
            get { return new CertificationTabCommand(); }
        }

        public static bool? CertificateWindowisOpened
        {
            get { return Driver.WindowExist("Certificate - Google Chrome"); }
        }

        public static CurricumnPortletCommand CurricumnPortlet { get { return new CurricumnPortletCommand(); } }

        public static MoreInformationCommand MoreInformation { get { return new MoreInformationCommand(); } }

        public static NotesAccorianCommand NotesAccorian { get { return new NotesAccorianCommand(); } }

        public static AllTrainingTabCommand AllTrainingTab { get { return new AllTrainingTabCommand(); } }

       
        public static WaivedPrerequisitesCommand WaivedPrerequisites { get { return new WaivedPrerequisitesCommand(); } }

        public static TrainingAssignmentExemptionsCommand TrainingAssignmentExemptions { get { return new TrainingAssignmentExemptionsCommand(); } }

        public static ExpiredIncompleteContentsCommand ExpiredIncompleteContents { get { return new ExpiredIncompleteContentsCommand(); } }

        public static MarkCompleteModalCommand MarkCompleteModal { get { return new MarkCompleteModalCommand(); } }

        public static MoreDropDownCommand MoreDropDown { get { return new MoreDropDownCommand(); } }

        public static CurriculumTabCommand CurriculumTab { get { return new CurriculumTabCommand(); } }

        public static ExternalLearningCommand ExternalLearning { get { return new ExternalLearningCommand(); } }

        public static bool? CertificateWindowIsClosed(string v)
        {
            return Driver.Instance.Title == v; 
        }

        public static void ClickCertificationsTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(@href, '/Transcript/MyCertifications.aspx')]"));
        }

        public static void CloseCertificationWindow()
        {
            Driver.Instance.SelectWindowClose2("Meridian Global 2010.1", Meridian_Common.parentwdw);
        }

        public static void ClickCurriculumsTab()
        {
            Driver.existsElement(By.XPath("//a[contains(@href, '/Transcript/Curricula.aspx')]"));
            Driver.clickEleJs(By.XPath("//a[contains(@href, '/Transcript/Curricula.aspx')]"));
        }

        public static string pagetitle()
        {
            return Driver.Instance.Title;
        }

        public static bool? AllComponetsdisplay()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.LinkText("All Training"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(@href, '/Transcript/Curricula.aspx')]"));
                Driver.existsElement(By.LinkText("Training Assignments"));
                Driver.existsElement(By.Id("dropdown-label"));
                Driver.clickEleJs(By.Id("dropdown-label"));
                return Driver.GetElement(By.LinkText("Waived Prerequisites")).Displayed;
               // result = true;
            }
            catch { }
            return result;

        }

        public static void ClickRequiredCourse(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),"+v+")]"));
        }

     

        public static string VerifyStatus(string v)
        {
            return Driver.GetElement(By.XPath("//a[contains(text(),"+v+")]/following::td[text()='Completed']")).Text;
        }

        public static void SelectStatusAndGo(string v1,string v2)
        {
            Driver.select(By.XPath("//td[contains(text(),'"+v1+"')]/following::div[1]"),v2);
            Driver.clickEleJs(By.XPath("//td[contains(text(),'" + v1 + "')]/following::a[contains(text(),'Go')][1]"));
            Thread.Sleep(5000);
            Driver.waitforframe();
        }

        public static void MarkComplete(string v)
        {
            Driver.GetElement(By.XPath("//textarea[@name='ctl00$MainContent$UC1$Reason']")).SendKeysWithSpace(v);
        }

        public static void CloseMarkComplete()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Driver.Instance.SwitchtoDefaultContent();
        }

        public static void ClickExternalLearningTab()
        {
            Driver.existsElement(By.XPath("//a[contains(@href, '/Transcript/MyExternalLearnings.aspx')]"));
            Driver.clickEleJs(By.XPath("//a[contains(@href, '/Transcript/MyExternalLearnings.aspx')]"));
        }
    }

    public class ExternalLearningCommand
    {
        public ExternalLearningCommand()
        {
        }

        public bool isTitledisplay(string extlearningTitle)
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'" + extlearningTitle + "')]"));
        }

        public void SubmitExternalLearning(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC2_MLinkButton1']"));
            Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_btnAddNew']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnAddNew']"));
            Driver.waitforframe();
            string format = "M/dd/yyyy";
            string obtaineddate = DateTime.Now.ToString(format);
            obtaineddate = obtaineddate.Replace("-", "/");
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_TITLE")).Clear();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_TITLE")).SendKeys(v);
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_DESCRIPTION")).Click();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_DESCRIPTION")).Clear();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_EXT_DESCRIPTION")).SendKeys("Ext Dec");
            Driver.Instance.FindElement(By.Id("MainContent_UC1_ELR_REASON")).Click();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_ELR_REASON")).Clear();
            Driver.Instance.FindElement(By.Id("MainContent_UC1_ELR_REASON")).SendKeys("For Automation");
            Driver.Instance.FindElement(By.Id("modalMaster")).Clear();
            Driver.Instance.FindElement(By.Id("modalMaster")).SendKeysWithSpace(obtaineddate);
            Driver.Instance.FindElement(By.Id("MainContent_UC1_SubmitRequest")).Click();
        }
    }

    public class CurriculumTabCommand
    {
        public CurriculumTabCommand()
        {
        }

        public void ClickEnrollmentDate()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Enrollment Date')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Enrollment Date')]"));
            Thread.Sleep(5000);
            
        }

        public void ClickCurriculumtitle(string v)
        {
            Driver.clickEleJs(By.LinkText(v));
        }
    }

    public class MoreDropDownCommand
    {
        public void WaivedPreRequisite()
        {
            Driver.existsElement(By.XPath("//ul[@id='more-list-group']/li[6]/a"));

            Driver.clickEleJs(By.XPath("//ul[@id='more-list-group']/li[6]/a"));
        }

        public void TrainingAssignmentExemptions()
        {
            Driver.clickEleJs(By.XPath("//ul[@id='more-list-group']/li[7]/a"));
        }

        public void ExpiredIncompleteContent()
        {
            Driver.clickEleJs(By.XPath("//ul[@id='more-list-group']/li[8]/a"));

        }
    }

    public class ExpiredIncompleteContentsCommand
    {
        public void Content()
        {
            Driver.existsElement(By.XPath("//td"));
        }

        public bool? ContentType()
        {
            return Driver.GetElement(By.XPath("//tr//td[2]")).Displayed;
        }

        public void ClickPrintButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton2']"));
        }

        public void ClickSaveasPDFButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_SaveAsPDF']/span[2]"));

        }

        public void closeExpiredLearningPrintWindow()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Close Window')]"));
            Driver.Instance.SwitchtoDefaultContent();
        }
    }



    public class TrainingAssignmentExemptionsCommand
    {
        public void CurrentExemptionsContent()
        {
            Thread.Sleep(3000);
        }


       

        public void ClickCurrentExemptionsPrintButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton2']/span[2]"));
            Thread.Sleep(5000);
            Driver.Instance.selectWindow("Current Exemptions");

            //Driver.clickEleJs(By.XPath("//a[contains(text(),'Close Window')]"));
        }

       

        public bool? PastExemptionsContentType()
        {
            return Driver.GetElement(By.XPath("//td[2]")).Displayed;
        }

        public void ClickPastExemptionsPrintButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC2_MLinkButton1']"));

        }

       

        public bool? CurrentExemptionsContentType()
        {
            return Driver.GetElement(By.XPath("//td[1]")).Enabled;
        }

        public void closeCurrentExemptionsPrintWindow()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Close Window')]"));
            Driver.Instance.SwitchtoDefaultContent();
        }

        public void closePastExemptionsPrintWindow()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Close Window')]"));
            Driver.Instance.SwitchtoDefaultContent();
        }
    }

    public class RequiredTrainingExemptionsTabCommand
    {
        public void CurrentExemptionsContent()
        {
            Driver.existsElement(By.XPath("//td[1]"));
        }
    }

    public class WaivedPrerequisitesCommand
    {
        public void Content()
        {
            Driver.existsElement(By.XPath("//td[1]"));
        }

      

        public void ClickPrintButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton2']/span[2]"));

        }

        public void ClickSaveasPDFButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_SaveAsPDF']/span[2]"));
        }

        public bool? ContentType()
        {
            return Driver.GetElement(By.XPath("//td[1]")).Displayed;
        }
    }

  

    public class AllTrainingTabCommand
    {
        public void Content()
        {
            Driver.existsElement(By.XPath("//a[contains(@href, '../ContentDetails.aspx?')]"));
        }

        public bool? ContentType()
        {
            return Driver.GetElement(By.XPath("//div[4]/table/tbody/tr/td[2]")).Displayed;
        }

        public void ClickPrintButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton1']/span[2]"));
        }

        public void SaveasPDFButton()
        {
            //Driver.Instance.SelectWindowClose();
            //Driver.Instance.SwitchtoDefaultContent();
            Driver.Instance.SelectWindowClose1("All Training");
           // Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_SaveAsPDF']/span[2]"));

        }

        public void Filter(string v1, string v2, int v3, int v4)
        {
            string format = "M/dd/yyyy";

            Driver.select(By.XPath("//select[@id='MainContent_UC1_ddlType']"),"All Training");
            Driver.select(By.XPath("//select[@id='MainContent_UC1_ddlStatus']"), "Started");
            Driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_rdpFromDate_dateInput']")).SendKeysWithSpace(DateTime.Now.AddDays(v3).ToString(format));
            Driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_rdpToDate_dateInput']")).SendKeysWithSpace(DateTime.Now.AddDays(v4).ToString(format));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnFilter']"));

        }

        public void ClickContent(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]"));
        }

        public void Click_GO()
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnGo']"));

        }

        public void MarkComplete_Transcript()
        {
            Driver.waitforframe();
            Driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_Reason']")).SendKeysWithSpace("Completed");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Driver.Instance.SwitchtoDefaultContent();

        }

        public void FilterandClickTesttitle(string v)
        {

            Driver.existsElement(By.XPath("//select[@id='MainContent_UC1_ddlType']"));
            Driver.select(By.XPath("//select[@id='MainContent_UC1_ddlType']"), "Test");
                     
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnFilter']"));
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
            Driver.GetElement(By.XPath("//a[contains(text(),'" + v + "')]")).ClickWithSpace();

        }
    }

    public class NotesAccorianCommand
    {
        public NotesAccorianCommand()
        {
        }

        public bool? NotesDisplay()
        {
            return Driver.existsElement(By.XPath("//div[2]/div/div/table/tbody/tr/td"));
        }
    }

    public class MoreInformationCommand
    {
        public MoreInformationCommand()
        {
        }

        public void viewPDFFilesandNotes()
        {
            Driver.existsElement(By.XPath("//span[@id='dropdown-label']"));
            Driver.clickEleJs(By.XPath("//span[@id='dropdown-label']"));
           // Driver.existsElement(By.LinkText("View PDF Files and Notes"));
            Driver.clickEleJs(By.LinkText("View PDF Files and Notes"));
        }
    }

    public class CurricumnPortletCommand
    {
        public CurricumnPortletCommand()
        {
        }

        public bool? VerifyColumnTitles()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.LinkText("Title"));
                Driver.existsElement(By.LinkText("Enrollment Date"));
                Driver.existsElement(By.LinkText("Completion Date"));
                Driver.existsElement(By.LinkText("Status"));
                Driver.existsElement(By.XPath("//table[@id='ctl00_MainContent_UC1_RadGrid1_ctl00']/thead/tr/th[5]"));
                Driver.existsElement(By.XPath("//table[@id='ctl00_MainContent_UC1_RadGrid1_ctl00']/thead/tr/th[6]"));
                result = true;
            }
            catch { }
            return result;
        }

        public bool? Verifyrecorddisplay()
        {
            return Driver.existsElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
        }

        public void ClickCurriculumTitle()
        {
            Driver.existsElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
            Driver.clickEleJs(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
        }
    }

    public class CertificationTabCommand
    {
        public string isCertificationStatus(string v)
        {
            return Driver.GetElement(By.XPath("//a[contains(text(),'" + v + "')]/following::td[3]")).Text;
        }

        public bool isCertificationProgress(string v)
        {
            throw new NotImplementedException();
        }

        public bool? ClickViewCertificateButton()
        {
            bool res = false;
            res = Driver.existsElement(By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_btnAction"));
            Meridian_Common.parentwdw=Driver.Instance.CurrentWindowHandle;

            Driver.clickEleJs(By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_btnAction"));
            return res;

          
        }

        public bool? isProgress(string v)
        {
            throw new NotImplementedException();
        }

        public ForCommand For(string v)
        {
            return new ForCommand(v);
        }

        public void sortbyDate(string v)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Date Obtained')]"));
            if (v=="as")
            {
                Driver.clickEleJs(By.XPath("//a[contains(text(),'Date Obtained')]"));
                Thread.Sleep(5000);
                Driver.clickEleJs(By.XPath("//a[contains(text(),'Date Obtained')]"));
                Thread.Sleep(5000);
            }
            else
            {
                Driver.clickEleJs(By.XPath("//a[contains(text(),'Date Obtained')]"));
                Thread.Sleep(5000);
            }
        }

        public bool? isStatusdisplay(string v1, string v2)
        {
            Driver.existsElement(By.LinkText(v1));
            return Driver.GetElement(By.XPath("//td[contains(text(),'Revoked')]")).Text.Equals(v2);
        }
    }

    public class AllMyTrainingPageCommand
    {
        public void SearchRecord(string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }

        public bool? isTestDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isClassroomCourseDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public void ClickClassroomCourseLink(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isGeneralCOurseDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isScormCourse2004tDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public void ClickDocument(string docname)
        {
            Driver.clickEleJs(By.LinkText(docname));
        }

        public void ClickSaveasPDF()
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_SaveAsPDF"));
        }
    }
}