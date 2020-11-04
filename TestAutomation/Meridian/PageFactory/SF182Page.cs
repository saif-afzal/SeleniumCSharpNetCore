using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class SF182Page
    {
        public static string Title {
            get
            {
                Thread.Sleep(20000);

                //                Driver.Instance.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
                return Driver.Instance.Title;
            }
        }

        public static PrivacyActStatementCommand PrivacyActStatementModal { get { return new PrivacyActStatementCommand(); } }

        public static resultgridcommand resultgrid { get { return new resultgridcommand(); } }

        public static ApprovalWorkflowTabCommand ApprovalWorkflowTab { get { return new ApprovalWorkflowTabCommand(); } }

        public static RequestTabCommand RequestTab { get { return new RequestTabCommand(); } }

        public static CreateCommandsf182 Create { get { return new CreateCommandsf182(); } }

        public static VendorsTabCommand VendorsTab { get { return new VendorsTabCommand(); } }

        public static moreSearchcriteriaCommand moreSearchcriteria { get { return new moreSearchcriteriaCommand(); } }

        public static ReasonforDenialTabCommand ReasonforDenialTab { get { return new ReasonforDenialTabCommand(); } }

        public static void Click_SF_182TrainingRequestlink()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucLearnerLinks_hlSF182Console']"));
        }

        public static bool? isPrivacyActStatementModaldisplay()
        {
            //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.existsElement(By.XPath("//div[@id='policy-modal']/div/div/div/h2"));
            return Driver.GetElement(By.XPath("//div[@id='policy-modal']/div/div/div/h2")).Text.Equals("Privacy Act Statement");
        }

        public static void ClickCreate()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Create')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Create')]"));
        }

        public static bool? isSeemoresearchcriterialinkdisplay()
        {
            if (Driver.existsElement(By.XPath("//div[@class='col-md-12 text-center md:text-left']//a[1]")))
            {
                return true;
            }
            else if (Driver.existsElement(By.XPath("//div[@class='row mb-4']//a[1]")))
            {
                return true;
            }
            else return false;
        }

        public static void ClickApprovalWorkflow()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Approval Workflows')]"));
        }

        public static void CLickReasonforDenialTab()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Reason for Denial')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Reason for Denial')]"));
        }

        public static void CLickVendorsTab()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Vendors')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Vendors')]"));
        }

        public static void Search(string v)
        {
            Driver.existsElement(By.Id("SearchRequests"));
            Driver.GetElement(By.Id("SearchRequests")).Clear();
            Driver.GetElement(By.Id("SearchRequests")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//div[@id='requestsList']/div/div/div/span[2]/button"));
        }

        public static void ClickSeemoreSearchcriteria()
        {
            Driver.clickEleJs(By.LinkText("See more search criteria"));
        }

        public static void ClickSearchIcon()
        {
            Driver.clickEleJs(By.XPath("//div[@id='requestsList']/div/div/div/span[2]/button/span"));
        }
    }

    public class ReasonforDenialTabCommand
    {
        public ReasonforDenialTabCommand()
        {
        }

        public ResultListCommand ResultList { get { return new ResultListCommand(); } }

        public void CreateNew(string denialTitle)
        {
            Driver.clickEleJs(By.XPath("//div[@id='reasonsToolbar']/div/div/div[2]/button"));
            Driver.existsElement(By.Id("reasonTitle"));
            Driver.Instance.FindElement(By.Id("reasonTitle")).Click();
            Driver.Instance.FindElement(By.Id("reasonTitle")).Clear();
            Driver.Instance.FindElement(By.Id("reasonTitle")).SendKeys("test1");
            Driver.clickEleJs(By.XPath("//div[@id='createReason']/div/div/div[3]/button[2]"));
        }

        public void search(string denialTitle)
        {
            Driver.GetElement(By.Id("searchFor")).Clear();
            Driver.GetElement(By.Id("searchFor")).SendKeys(denialTitle);
            Driver.clickEleJs(By.XPath("//div[@id='reasonsToolbar']/div/div/div/div/span/button/span"));
        }
    }

    public class ResultListCommand
    {
        public ResultListCommand()
        {
        }

        public void UpdateTitle(string actual, string updatetitle)
        {
            Driver.existsElement(By.LinkText(actual));
            Driver.clickEleJs(By.LinkText(actual));
            Driver.clickEleJs(By.XPath("//table[@id='table-denial-reason']/tbody/tr/td/span/div/form/div/div/div/input"));
            Driver.GetElement(By.XPath("//table[@id='table-denial-reason']/tbody/tr/td/span/div/form/div/div/div/input")).Clear();
            Driver.GetElement(By.XPath("//table[@id='table-denial-reason']/tbody/tr/td/span/div/form/div/div/div/input")).SendKeysWithSpace(updatetitle);
            Driver.clickEleJs(By.XPath("//table[@id='table-denial-reason']/tbody/tr/td/span/div/form/div/div/div[2]/button/span"));

        }

        public bool? isTitleUpdated(string v)
        {
            return Driver.existsElement(By.LinkText(v));
            
        }

        public void ChnageStatus(string v1, string v2)
        {
            if(v2== "Inactive")
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-denial-reason']/tbody/tr/td[2]/a"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.LinkText("Inactive"));
            }
            if (v2 == "Active")
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-denial-reason']/tbody/tr/td[2]/a"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.LinkText("Active"));
            }
        }
    }

    public class moreSearchcriteriaCommand
    {
        public VenderNamedropdownCommand VenderNamedropdown { get { return new VenderNamedropdownCommand(); } }

        public moreSearchcriteriaCommand()
        {
        }

        public TraineeEmailAddressCommand TraineeEmailAddress(string v)
        {
            return new TraineeEmailAddressCommand(v);
        }

        public bool? isVenderNamedropdowndisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'Vendor Name')]"));
        }
    }

    public class VenderNamedropdownCommand
    {
        public VenderNamedropdownCommand()
        {
        }

        public void SelectVender()
        {
            Driver.clickEleJs(By.XPath("//div[@id='requestsAdvancedSearch']/div/div/div[3]/div/div/ul/li[2]/a/span"));
            Driver.select(By.XPath("//div[@id='requestsAdvancedSearch']/div/div/div[3]/div/select"), "AS Vendor1");
        }
    }

    public class TraineeEmailAddressCommand
    {
        private string v;

        public TraineeEmailAddressCommand(string v)
        {
            this.v = v;
        }

        public void Search()
        {
            Driver.existsElement(By.XPath("//input[@id='learnerEmail']"));
            Driver.GetElement(By.XPath("//input[@id='learnerEmail']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='learnerEmail']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[@id='requestsList']/div/div/div/span[2]/button/span"));
        }
    }

    public class VendorsTabCommand
    {
        public VendorModaldCommand VendorModald { get { return new VendorModaldCommand(); } }

        public vendersList vendersList { get { return new vendersList(); } }

        public VendorsTabCommand()
        {
        }

        public bool? isExistingVendorsdisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='vendorsTab']//tr[1]//td[1]"));

        }

        public string titleofFistVendername()
        {
            return Driver.GetElement(By.XPath("//div[@id='vendorsTab']//tr[1]//td[1]")).Text;
        }

        public void ClickFistVendorTitle()
        {
            Driver.clickEleJs(By.XPath("//table[@id='table-vendors']/tbody/tr/td/a"));
        }

        public bool? VendorModaldisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='createVendor']/div/div/div/h4"));
        }

        public bool? isVendernameisUpdated(string venderName)
        {
            string VName=Driver.GetElement(By.XPath("//table[@id='table-vendors']/tbody/tr/td/a")).Text;
            if(VName!= venderName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class vendersList
    {
        public vendersList()
        {
        }

        public void ChangestatusofFirstrecord(string v)
        {
            if(v=="Inactive")
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-vendors']/tbody/tr/td[3]/a"));
                Driver.clickEleJs(By.XPath("//body/ul/li[2]/a"));
            }
            if (v == "Active")
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-vendors']/tbody/tr/td[3]/a"));
                Driver.clickEleJs(By.XPath("//body/ul/li/a"));
            }
        }
    }

    public class VendorModaldCommand
    {
        public VendorModaldCommand()
        {
        }

        public void UpdateVenderTitle(string v)
        {
            Driver.GetElement(By.Id("vendorTitle")).Clear();
            Driver.GetElement(By.Id("vendorTitle")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[@id='createVendor']/div/div/div[3]/button[2]"));
        }
    }

    public class CreateCommandsf182
    {
        public CreateCommandsf182()
        {
        }

        public AddUserModalCommand AddUserModal { get { return new AddUserModalCommand(); } }

        public void CreateSF182Requestforuser()
        {
            Driver.existsElement(By.XPath("//div[@id='requestsToolbar']/div/div/div[2]/div/button"));
            Driver.clickEleJs(By.XPath("//div[@id='requestsToolbar']/div/div/div[2]/div/button"));
            Driver.clickEleJs(By.Id("Create SF-182 Request for User"));
        }

        public bool? isAddUserModaldisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='findUsers']/div/div/div/h4"));
        }
    }

    public class AddUserModalCommand
    {
        public AddUserModalCommand()
        {
        }

        public void adduser(string v)
        {
            Driver.GetElement(By.Id("SearchFor")).Clear();
            Driver.GetElement(By.Id("SearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btn-search']/span"));
            Driver.clickEleJs(By.XPath("//td/input"));
            Driver.clickEleJs(By.XPath("//button[2]"));
        }
    }

    public class RequestTabCommand
    {
        public SeemoresearchcriteriaCommand Seemoresearchcriteria { get { return new SeemoresearchcriteriaCommand(); } }

        public RequestTabCommand()
        {
        }

        public void Search(string v)
        {
            if (v == "")
            {
                Driver.clickEleJs(By.XPath("//div/div/span[2]/button"));
            }
        }

        public bool? isResultdisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-requests']//tbody"));
        }

        public void clickSeemoresearchcriteriaLink()
        {
            Driver.clickEleJs(By.XPath("//div[@class='col-md-12 text-center md:text-left']//a[1]"));
        }

        public void ClickonStatusDropdown()
        {
            Driver.clickEleJs(By.XPath("//select[@id='Status']"));
        }

       

        public bool? isStatusdropdownList(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9, string v10, string v11, string v12, string v13, string v14)
        {
            int count = 0;
            string[] values = { v1, v2, v3, v4, v5,v6,v7,v8,v9,v10,v11,v12,v13,v14 };
            //int result = values.Count(s => s != null);
            int result = (from s in values where !string.IsNullOrEmpty(s) select s).Count();
            
            IWebElement allOptions = Driver.Instance.FindElement(By.XPath("//div[@id='requestsList']/div/div[2]/select"));
            IList<IWebElement> elements = allOptions.FindElements(By.TagName("option"));
            int i = 0;
            bool res = false;
            foreach (IWebElement option in elements)
            {
                if (option.Text.Length != 0)
                {
                    if (option.Text.Equals(values[i]))
                    {
                        i = i + 1;
                    }
                }
                if (result == i)
                {
                    res = true;
                    break;
                }


            }
            return res;
        }
    }

    public class SeemoresearchcriteriaCommand
    {
        public SeemoresearchcriteriaCommand()
        {
        }

        public bool? isLevelsdisplay(string v)
        {
            Driver.existsElement(By.XPath("//label[contains(text(),'Training between')]"));
            Driver.existsElement(By.XPath("//label[contains(text(),'PO #')]"));
            Driver.existsElement(By.XPath("//label[contains(text(),'Unique Identifying Number')]"));
            Driver.existsElement(By.XPath("//label[contains(text(),'Organizations')]"));
            Driver.existsElement(By.XPath("//label[contains(text(),'Vendor Name')]"));
            return Driver.existsElement(By.XPath("//label[contains(text(),'Activity')]"));
        }
    }

    public class ApprovalWorkflowTabCommand
    {
        public ApprovalWorkflowTabCommand()
        {
        }

        public approvalpathtableCommand approvalpathtable { get { return new approvalpathtableCommand(); } }

        public bool? isCreatebuttonEnbled()
        {
            return Driver.GetElement(By.XPath("//a[@class='btn btn-primary'][contains(text(),'Create')]")).Enabled;
        }

        public bool? isDeletebuttonDisabled()
        {
            return Driver.GetElement(By.XPath("//button[@id='delete-path']")).Enabled;
        }

        public void clickCreate()
        {
            Driver.existsElement(By.XPath("//a[@class='btn btn-primary'][contains(text(),'Create')]"));
            Driver.clickEleJs(By.XPath("//a[@class='btn btn-primary'][contains(text(),'Create')]"));
        }
    }

    public class approvalpathtableCommand
    {
        public approvalpathtableCommand()
        {
        }

        public bool? verifyColumnheader(string v1, string v2, string v3, string v4)
        {
            try
            {
                List<string> errors = new List<string>();

                if (!Driver.GetElement(By.XPath("//a[contains(text(),'Title')]")).Text.Contains(v1))
                { errors.Add("Title is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//a[contains(text(),'Approvers')]")).Text.Contains(v2))
                { errors.Add("Approvers is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//div[contains(text(),'Assigned To')]")).Text.Contains(v3))
                { errors.Add("Assigned To is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//div[contains(text(),'Default Path')]")).Text.Contains(v4))
                { errors.Add("Default Path is not coming on table header"); }
                
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);

                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", Driver.Instance);
            }
            return true;
        }
    }

    public class resultgridcommand
    {
        public InformationmodalCommand Informationmodal { get { return new InformationmodalCommand(); } }

        public resultgridcommand()
        {

        }
        public bool? verifyresultgridtablecolumns(string v1, string v2, string v3, string v4="", string v5="")
        {
            try
            {
                List<string> errors = new List<string>();

                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th/a")).Text.Contains(v1))
                { errors.Add("Training is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th[2]/a")).Text.Contains(v2))
                { errors.Add("Vendor Name is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th[3]")).Text.Contains(v3))
                { errors.Add("Status is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th[4]/a")).Text.Contains(v5))
                { errors.Add("Attendance Status is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th[5]/div")).Text.Contains(v5))
                { errors.Add("Actions is not coming on table header"); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);

                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", Driver.Instance);
            }
            return true;
        }

        public void ClickTakeAction(string v)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]/following::a[contains(text(),'Take Action')][1]"));
        }

        public void TakeAction(string v)
        {
            if (v == "Approve")
            {
                Driver.existsElement(By.XPath("//div[@id='takeActionBody']/div/div/h4"));
                Driver.clickEleJs(By.Id("approve-button"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("//div[3]/div/button"));
                Driver.clickEleJs(By.XPath("//div[3]/div[2]/button[2]"));
            }

        }

        public bool? isrecorddisplay()
        {
            if (Driver.existsElement(By.XPath("//div[@id='requestsTab']//td[1]")))
            {
                return true;
            }
            else if (Driver.existsElement(By.XPath("//*[@id='table - requests']/tbody/tr")))
            {
                return true;
            }
            else if (Driver.existsElement(By.Id("table-requests")))
            {
                return true;
            }
            else return false;
        }

        public void ClickUserNameTitle()
        {
            Driver.clickEleJs(By.XPath("//table[@id='table-requests']/tbody/tr/td[2]/a"));

        }

        public bool? isActionbuttondisplay()
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'View History')]"));
        }

        public bool? verifyresultgridtablecolumnsApprover(string v1, string v2, string v3, string v4)
        {
            try
            {
                List<string> errors = new List<string>();

                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th/a")).Text.Contains(v1))
                { errors.Add("Training is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th[2]/a")).Text.Contains(v2))
                { errors.Add("Vendor Name is not coming on table header"); }
                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th[3]/a")).Text.Contains(v3))
                { errors.Add("Status is not coming on table header"); }
                
                if (!Driver.GetElement(By.XPath("//table[@id='table-requests']/thead/tr/th[4]/div")).Text.Contains(v4))
                { errors.Add("Actions is not coming on table header"); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);

                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", Driver.Instance);
            }
            return true;
        }

        public bool? isNewRequestCreated(string courseTitle)
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'" + courseTitle + "')]"));
        }

        public bool? isSearchrecorddisplay(string v)
        {
            return Driver.existsElement(By.LinkText(v));
        }

        public void clicksf182requestTitle(string v)
        {
            Driver.clickEleJs(By.LinkText(v));
        }

        public void TakeActionbytrainingPOC(string v)
        {
            if (v == "Approve")
            {
                Driver.existsElement(By.XPath("//div[@id='takeActionBody']/div/div/h4"));
                Driver.clickEleJs(By.Id("approve-button"));
                Thread.Sleep(2000);
                Driver.existsElement(By.XPath("//div[@id='approverContainer']/div/label/strong"));
                Driver.Instance.FindElement(By.XPath("//div[@id='approverContainer']/div/div/button")).Click();
                Driver.Instance.FindElement(By.LinkText("sr ifmispoc")).Click();
                Driver.select(By.Id("ifmisPOC"), "sr ifmispoc");
                Driver.Instance.FindElement(By.XPath("//div[@id='approverContainer']/div[2]/button[2]")).Click();
                Driver.Instance.FindElement(By.Id("TrainingDutyHours")).Click();
                Driver.Instance.FindElement(By.Id("TrainingDutyHours")).Clear();
                Driver.Instance.FindElement(By.Id("TrainingDutyHours")).SendKeys("12");
                Driver.Instance.FindElement(By.Id("TrainingNonDutyHours")).Click();
                Driver.Instance.FindElement(By.Id("TrainingNonDutyHours")).Clear();
                Driver.Instance.FindElement(By.Id("TrainingNonDutyHours")).SendKeys("12");
                Driver.Instance.FindElement(By.Id("TrainingPurposeType")).Click();
                Driver.select(By.Id("TrainingPurposeType"), "Program/Mission Change");
                Driver.Instance.FindElement(By.Id("TrainingPurposeType")).Click();
                Driver.Instance.FindElement(By.Id("TrainingTypeCode")).Click();
                Driver.select(By.Id("TrainingTypeCode"), "Training Program Area");
                Driver.Instance.FindElement(By.Id("TrainingTypeCode")).Click();
                Driver.Instance.FindElement(By.Id("TrainingDeliveryTypeCode")).Click();
                Driver.select(By.Id("TrainingDeliveryTypeCode"), "Traditional Classroom (no technology)");
                Driver.Instance.FindElement(By.Id("TrainingDeliveryTypeCode")).Click();
                Driver.Instance.FindElement(By.Id("TrainingDesignationTypeCode")).Click();
                Driver.select(By.Id("TrainingDesignationTypeCode"), "Undergraduate Credit");
                Driver.Instance.FindElement(By.Id("TrainingDesignationTypeCode")).Click();
                Driver.Instance.FindElement(By.Id("TrainingCredit")).Click();
                Driver.Instance.FindElement(By.Id("TrainingCredit")).Clear();
                Driver.Instance.FindElement(By.Id("TrainingCredit")).SendKeys("12");
                Driver.Instance.FindElement(By.Id("TrainingCreditTypeCode")).Click();
                Driver.select(By.Id("TrainingCreditTypeCode"), "Semester Hours");
                Driver.Instance.FindElement(By.Id("TrainingCreditTypeCode")).Click();
                Driver.Instance.FindElement(By.Id("TrainingAccreditationIndicator01")).Click();
                Driver.Instance.FindElement(By.Id("ContinutedServiceAgreementIndicator01")).Click();
                Driver.Instance.FindElement(By.Id("ContinutedServiceAgreementIndicator02")).Click();
                Driver.Instance.FindElement(By.Id("TrainingSourceTypeCode")).Click();
                Driver.select(By.Id("TrainingSourceTypeCode"), "Government Internal");
                Driver.Instance.FindElement(By.Id("TrainingSourceTypeCode")).Click();
                Driver.Instance.FindElement(By.XPath("//div[@id='edit-training']/div/div[3]/button[2]")).Click();
            }
            if (v == "Mark Attendance")
            {
                Driver.existsElement(By.XPath("//div[@id='markAttendanceBody']/div/div[2]/div/button[2]"));
                Driver.clickEleJs(By.XPath("//div[@id='markAttendanceBody']/div/div[2]/div/button[2]"));
            }
        }
    }

    public class InformationmodalCommand
    {
        public InformationmodalCommand()
        {
        }

        public string emailid()
        {
            Driver.Instance.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
            Driver.existsElement(By.Id("KendoUIMGDialog_wnd_title"));
            string email= Driver.GetElement(By.XPath("//div[@id='acct-contact']/ul/li[3]/strong")).Text;
            Driver.clickEleJs(By.LinkText("Close"));
            return email;
        }
   
    }

    public class PrivacyActStatementCommand
    {
        public PrivacyActStatementCommand()
        {
        }

        public void Accept()
        {
            
            //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.existsElement(By.XPath("//div[@id='policy-modal']/div/div/div[3]/button"));
            Driver.clickEleJs(By.XPath("//div[@id='policy-modal']/div/div/div[3]/button"));

        }
    }
}