using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ApprovalWorkflowPage
    {
        public static approverstablecommand approverstable { get { return new approverstablecommand(); } }

        public static approverstabcommand approverstab { get { return new approverstabcommand(); } }

        public static void Create(string approvalPathTitle)
        {
            Driver.existsElement(By.Id("item-title-create"));
            Driver.GetElement(By.Id("item-title-create")).Clear();
            Driver.GetElement(By.Id("item-title-create")).SendKeysWithSpace(approvalPathTitle);
            Driver.clickEleJs(By.Id("btn-update-title"));
        }
    }

    public class approverstabcommand
    {
        public approverstabcommand()
        {
        }

        public Whocanmarkorconfirmattendancecommand Whocanmarkorconfirmattendance { get { return new Whocanmarkorconfirmattendancecommand(); } }

        public WhocanUploadCertificateCommand WhocanUploadCertificate { get { return new WhocanUploadCertificateCommand(); } }

        public PreviewWorkflowmodalCommand PreviewWorkflowmodal { get { return new PreviewWorkflowmodalCommand(); } }

        public bool? isWhocanmarkorconfirmattendanceLebeldisplay()
        {
            return Driver.existsElement(By.XPath("//label[@id='markAttendanceRolesLabel']"));
        }

        public bool? isWhocanUploadCertificateLebeldisplay()
        {
            return Driver.existsElement(By.XPath("//label[@id='uploadCertificateRolesLabel']"));
        }

        public void clickPreviewWorkflow()
        {
            Driver.existsElement(By.Id("previewButton"));
            Driver.clickEleJs(By.Id("previewButton"));
        }

        public bool? isPreviewWorkflowmodalopened()
        {
            Driver.existsElement(By.XPath("//div[@id='previewWorkflow']/div/div/div/h4"));
            return Driver.GetElement(By.XPath("//div[@id='previewWorkflow']/div/div/div/h4")).Text.Equals("Preview Workflow");
        }
    }

    public class PreviewWorkflowmodalCommand
    {
        public PreviewWorkflowmodalCommand()
        {
        }

        public bool? isTrainingPOCuploadscertificateisLastline()
        {
            return Driver.GetElement(By.XPath("//div[@id='preview-body']/ul/li[last()]")).Text.Contains("Training POC uploads certificate");
        }
    }

    public class WhocanUploadCertificateCommand
    {
        public WhocanUploadCertificateCommand()
        {
        }

        public bool? DefaultList()
        {
            Driver.existsElement(By.XPath("//input[@value='ML.BASE.ROLE.Trainee']"));
            Driver.existsElement(By.XPath("//input[@value='ML.BASE.ROLE.Supervisor1']"));
            Driver.existsElement(By.XPath("//input[@value='ML.BASE.ROLE.FINANCEPOCAP']"));
            return Driver.GetElement(By.XPath("//input[@value='ML.BASE.ROLE.TRAININGPOC']")).Selected;
        }

        public void ClickTrainingPOC()
        {
            Driver.clickEleJs(By.XPath("//a[@id='uploadCertificateRoles']"));
        }

        public void setTrainee()
        {
            Driver.clickEleJs(By.XPath("//input[@value='ML.BASE.ROLE.TRAININGPOC']"));
            Driver.clickEleJs(By.XPath("//input[@value='ML.BASE.ROLE.Trainee']"));
            Driver.clickEleJs(By.XPath("//span[@class='fa fa-check']"));
        }

        public bool? isnewvalueset(string v)
        {
            return Driver.GetElement(By.XPath("//a[@id='uploadCertificateRoles']")).Text.Equals(v);
        }

        public void UnselectTraininPOC()
        {
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Training POC')]/preceding::input[1]"));
        }
    }

    public class Whocanmarkorconfirmattendancecommand
    {
        public Whocanmarkorconfirmattendancecommand()
        {
        }

        public void ClickTrainee()
        {
            Driver.clickEleJs(By.XPath("//a[@id='markAttendanceRoles']"));
        }

        public bool? DefaultList()
        {
            Driver.existsElement(By.XPath("//input[@value='ML.BASE.ROLE.Supervisor1']"));
            Driver.existsElement(By.XPath("//input[@value='ML.BASE.ROLE.Supervisor2']"));
            Driver.existsElement(By.XPath("//input[@value='ML.BASE.ROLE.TRAININGPOC']"));
            return Driver.GetElement(By.XPath("//input[@value='ML.BASE.ROLE.Trainee']")).Selected;

        }

        public void setSupervisor1()
        {
            Driver.clickEleJs(By.XPath("//input[@value='ML.BASE.ROLE.Trainee']"));
            Driver.clickEleJs(By.XPath("//input[@value='ML.BASE.ROLE.Supervisor1']"));
            Driver.clickEleJs(By.XPath("//span[@class='fa fa-check']"));
        }

        public bool? isnewvalu(string v)
        {
            return Driver.GetElement(By.XPath("//a[@id='markAttendanceRoles']")).Text.Equals(v);
        }

        public bool isSaveOptionisDisabled()
        {
            return Driver.GetElement(By.XPath("//button[@class='btn btn-primary xeditable-submit']")).Displayed;
        }

        public void UnSelectTrainee()
        {
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Trainee')]/preceding::input[1]"));
        }
    }

    public class approverstablecommand
    {
        public AddModalCommand AddModal { get { return new AddModalCommand(); } }

        public approverstablecommand()
        {
        }

        public bool? noapproveradded()
        {
            Driver.existsElement(By.XPath("//div[@id='no-approvers']/p/strong"));
            return Driver.GetElement(By.XPath("//div[@id='no-approvers']/p/strong")).Text.Equals("There are no approvers.");
        }

        public void ClickAdd()
        {
            Driver.clickEleJs(By.XPath("//div[@id='no-approvers']/button"));
        }

        public bool? AddModalopened()
        {
            return Driver.existsElement(By.XPath("//div[@id='addTask']/div/div/div/h4"));
        }

        public bool? isapproveradded()
        {
            return Driver.existsElement(By.XPath("//tr[@id='customId_0']/td"));
        }
    }

    public class AddModalCommand
    {
        public AddModalCommand()
        {
            
        }

        public void clickAdd()
        {
            Driver.existsElement(By.XPath("//div[3]/div/div/div[3]/button[2]"));
            Driver.clickEleJs(By.XPath("//div[3]/div/div/div[3]/button[2]"));
        }
    }
}