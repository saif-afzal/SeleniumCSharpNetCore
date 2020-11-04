using System;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System.Threading;
using Selenium2.Meridian;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class MeridianGlobalReportingPage:ObjectInit
    {
        private IWebDriver objDriver;
        public MeridianGlobalReportingPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  int Displays
        {
            get
            {
                int cnt = 0;
             //  objDriver.selectWindow("Meridian Global Reporting");
               objDriver.WaitForElement(By.Id("Data.TOTAL_RECORDS_Row1"));
                cnt= objDriver.getIntegerFromString(objDriver.GetElement(By.Id("Data.TOTAL_RECORDS_Row1")).Text);
               //objDriver.SelectWindowClose2("Meridian Global Reporting", "Run Report");
                return cnt;
            }
        }

        public  string Title
        {
            get
            {
                Thread.Sleep(5000);
               objDriver.selectWindow("Meridian Global Reporting");

                return objDriver.Title;
            }
        }

        public  string ContentTitle
        {
            get { return objDriver.GetElement(By.XPath("//span[@id='colCourseName_Row1']")).Text; }
        }

        //public  SummaryCommand Summary { get { return new SummaryCommand(objDriver); } }

        public  TableCommand Table { get { return new TableCommand(objDriver); } }

        public  PrintWindowCommand PrintWindow { get { return new PrintWindowCommand(objDriver); } }

        public  CustomizeTableCommand CustomizeTable { get { return new CustomizeTableCommand(objDriver); } }

        public  void ClickDetails()
        {
            try
            {

                Thread.Sleep(10000);
               objDriver.selectWindow("Meridian Global Reporting");
                objDriver.ClickEleJs(By.Id("GoButton_Row1"));
            }
            catch
            {
                objDriver.focusParentWindow();
                objDriver.ClickEleJs(By.XPath("//input[@value='Run Report']"));
                Thread.Sleep(10000);
               objDriver.selectWindow("Meridian Global Reporting");
                objDriver.ClickEleJs(By.Id("GoButton_Row1"));
            }
        }

        public  void CloseWindow()
        {
            objDriver.focusParentWindow();
           //objDriver.SelectWindowClose2("Meridian Global Reporting", Meridian_Common.parentwdw);
        }

        public  void CustomizeTableColumns()
        {
            throw new NotImplementedException();
        }

        public  object SelectColumns(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public  bool? verifycolumn(string v)
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu22_Row1']/span")).Text==v;
        }

        public  string verifycolumnvalue(string v)
        {
            return objDriver.GetElement(By.XPath("//span[@id='coldv_credit_type_Row1']")).Text;
        }

        public  void CustomizeTableColumns(string v1, string v2)
        {
            objDriver.ClickEleJs(By.Id("imgTableEdit"));
            objDriver.ClickEleJs(By.Id("iclLayout_rdList12"));
            objDriver.ClickEleJs(By.Id("iclLayout_rdList14"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
           // throw new NotImplementedException();
        }

        public  bool? verifycolumn1(string v)
        {
            return objDriver.GetElement(By.XPath("//td[3]/ul/li[5]/label/span")).Text == v;
        }

        public  string verifycolumnvalue1(string v)
        {
            return objDriver.GetElement(By.XPath("//span[@id='colDefaultCreditType_Row1']")).Text;
        }

        public  bool? isDisplayed()
        {
           objDriver.selectWindow("Meridian Global Reporting");
            return objDriver.existsElement(By.XPath("//h1[@id='Session.rdReportName']"));

        }

        public  bool? VerifyManagerProficiencyRatingReportlevelColumns()
        {
            objDriver.existsElement(By.Id("ExtraColumnHeaderLabel_Row1"));
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu13_Row1']/span")).Text.Equals("Competency");
            objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Maximum Possible Rating");           
            return objDriver.GetElement(By.XPath("//th[9]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Target Rating");
        }

        public  bool? verifyLoginidAddedtoreportTable()
        {
            if (objDriver.existsElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Login ID')]")))
            {
                return objDriver.GetElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Login ID')]")).Text.Equals("Login ID");
            }
            
            else
            {
                return false;
            }

        }

        public  void ClickTabileEditicon()
        {
            objDriver.ClickEleJs(By.Id("imgTableEdit"));
        }

        public  bool? isPrintDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Print']")).Displayed;

        }

        public  bool? isSaveNewDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Save New']")).Displayed;

        }

        public  bool? VerifyDomainReportTrainingAssignmenPeriodbyUsertlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Name");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Status");
            return objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Type");
        }

        public  bool? VerifyOrganizationReportTrainingAssignmenstbyContentItemlevelColumns()
        {
            objDriver.existsElement(By.Id("ExtraColumnHeaderLabel_Row1"));
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Training Period Status");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Equivalent Content Completed");
            return objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completion Status");
        }

        public  bool? VerifyDomainReportTrainingAssignmenstlevelColumns()
        {
            objDriver.existsElement(By.Id("ExtraColumnHeaderLabel_Row1"));
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Training Period Status");
            return objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completion Status");
        }

        public  bool? isViewLayoutDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='View Layouts']")).Displayed;
        }

        public  bool? isRefreshDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Refresh']")).Displayed;
        }

        public  bool? isCloseWindowDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Close Window']")).Displayed;
        }

        public  bool? isExportToExcelDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Export to Excel']")).Displayed;
        }

        public  bool? isExportToPDFDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Export to PDF']")).Displayed;
        }

        public  bool? VerifyDomainReportTrainingAssignmenbyContentItemlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Name");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Status");
            return objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Type");
        }

        public  bool? isExportToXMLDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Export to XML']")).Displayed;
        }

        public  bool? isExportToCSVDisplayed()
        {
            return objDriver.GetElement(By.XPath("//span[@id='Export to CSV']")).Displayed;
        }

        public  void Print()
        {
            objDriver.ClickEleJs(By.XPath("//span[@id='Print']"));
        }

        public  bool? VerifyPrintWindowOpens()
        {
            return objDriver.existsElement(By.XPath(""));
        }

        public  bool? VerifyOrganizationReportTrainingAssignmenstbyUserlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content Type");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Name");
            return objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Status");
        }

        public  void ClosePrintWindow()
        {
            throw new NotImplementedException();
        }

        public  void ExportToExcel()
        {
            objDriver.ClickEleJs(By.XPath("//span[@id='Print']"));

        }

        public  void CloseExcelSheet()
        {
            throw new NotImplementedException();
        }

        public  void ExportToPDF()
        {
            objDriver.ClickEleJs(By.XPath("//span[@id='Export to PDF']"));
        }

        public  void ClosePDFTab()
        {
            throw new NotImplementedException();
        }

        public  void ExportToCSV()
        {
            objDriver.ClickEleJs(By.XPath("//span[@id='Export to CSV']"));
        }

        public  void CloseCSVSheet()
        {
            throw new NotImplementedException();
        }

        public  void ExportToXML()
        {
            objDriver.ClickEleJs(By.XPath("//span[@id='Export to XML']"));
        }

        public  void CloseXMLSheet()
        {
            throw new NotImplementedException();
        }

        public  bool? VerifyPDFTabOpens()
        {
            throw new NotImplementedException();
        }

        public  bool? VerifyCSVSheetOpens()
        {
            throw new NotImplementedException();
        }

        public  bool? VerifyXMLSheetOpens()
        {
            throw new NotImplementedException();
        }

        public  bool? VerifyExcelSheetOpens()
        {
            throw new NotImplementedException();
        }

        public  bool? VerifyPageComponents(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9)
        {
            bool result = false;
            try
            {
                Thread.Sleep(10000);
               objDriver.selectWindow("Meridian Global Reporting");
                objDriver.GetElement(By.XPath("//h1[@class='ReportTitle']")).Text.Equals("All Questions, All Surveys.");
                objDriver.existsElement(By.XPath("//span[@id='Save New']"));
                objDriver.existsElement(By.XPath("//span[@id='Print']"));
                objDriver.existsElement(By.XPath("//span[@id='Export to Excel']"));
                objDriver.existsElement(By.XPath("//span[@id='Export to PDF']"));
                objDriver.existsElement(By.XPath("//span[@id='Export to XML']"));
                objDriver.existsElement(By.XPath("//span[@id='Export to CSV']"));
                objDriver.existsElement(By.XPath("//span[@id='Close Window']"));
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;

        }

        public  bool? VerifySurveyReportlevelColumns()
        {
            bool result = false;
            try
            {
                objDriver.existsElement(By.XPath("//span[contains(text(),'Survey ID')]"));
                objDriver.existsElement(By.XPath("//span[contains(text(),'Survey Title')]"));
                objDriver.existsElement(By.XPath("//span[contains(text(),'Survey Section')]"));
                objDriver.existsElement(By.XPath("//span[contains(text(),'Question ID')]"));
                objDriver.existsElement(By.XPath("//span[contains(text(),'Content ID')]"));
                objDriver.existsElement(By.XPath("//span[contains(text(),'Content Title')]"));
                objDriver.existsElement(By.XPath("//span[contains(text(),'User ID')]"));
                objDriver.existsElement(By.XPath("//span[contains(text(),'Language')]"));
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public  bool? VerifyManagersReportContentAccessColumns()
        {
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu7_Row1']/span"));
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu10_Row1']/span")).Text.Equals("Content Type");
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu13_Row1']/span")).Text.Equals("Start Date");
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu17_Row1']/span")).Text.Equals("Complete Date");

        }

        public  bool? VerifyContentUsageReportlevelColumns()
        {

            objDriver.existsElement(By.XPath("//a[@class='rdThemePopupMenu']//span[contains(text(),'Content Title')]"));
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu4_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']"));
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu7_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']"));
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu10_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']"));
             return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu13_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
  

        }

        public  bool? VerifyManagersReportTrainingAssignmentslevelColumns()
        {
            objDriver.existsElement(By.Id("ExtraColumnHeaderLabel_Row1"));
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content Type");
            return objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completion Status");
        }

        public  bool? VerifyContentUsageReportsDisplay()
        {
            return objDriver.existsElement(By.XPath("//span[@id='colContentTitle_Row1']"));
        }

        public  int VerifyCompletdColumnValue()
        {
            
            objDriver.existsElement(By.XPath("//td[@id='colTotalCompleted_Row1']/span"));
            string totleCount = objDriver.GetElement(By.XPath("//td[@id='colTotalCompleted_Row1']/span")).Text;
            return objDriver.getIntegerFromString(totleCount);
        }

        public  bool? VerifyContentUsageReportsinGroup()
        {
            objDriver.existsElement(By.Id("lblGroupReplace_Row1"));
            return objDriver.GetElement(By.Id("colContentTitle_Row10")).Displayed;
        }

        public  bool? VerifyOrgReportTrainingAssignmenPeriodbyContentItemlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content Type");
            return objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completion Status");
        }

        public  bool? VerifyManagersReportTrainingAssignmentlevelColumns()
        {
            objDriver.existsElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span"));
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Current Assignment");
            return objDriver.GetElement(By.XPath("//th[10]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Exemption Reason");
        }

        public  bool? verifyerrormessage(string v)
        {
            objDriver.existsElement(By.Id("lblGroupError-DuplicateGroupColumn"));
            return objDriver.GetElement(By.Id("lblGroupError-DuplicateGroupColumn")).Text.Equals(v);
        }

        public  void ClickUserProgress()
        {
            objDriver.ClickEleJs(By.Id("GoButton_Row1"));
        }

        public  bool? VerifyJobTitleinheader(string v)
        {
            return objDriver.GetElement(By.XPath("//span[@id='Data.JOB_TITLE_Row1']")).Text.Equals(v);
        }

        public  bool? VerifyReportContaindColumns()
        {
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu1_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']"));
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu16_Row1']//span[@id='ExtraColumnHeaderLabel_Row1'] "));
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu13_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']"));
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu7_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public  int VerifyRequiredContentCompletionColumnValue()
        {
            string value = objDriver.GetElement(By.XPath("//span[@id='colRequiredContentCompletion_Row1']")).Text;
            return objDriver.getIntegerFromString(value);
        }

        public  bool? VerifyTrainingProgressDetailsbyContainerlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Content Type");
            return objDriver.GetElement(By.XPath("//th[10]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Score");
        }

        public  bool? VerifyJobTitleinheaderisdisplay()
        {
            
                return objDriver.GetElement(By.XPath("//span[@id='Data.JOB_TITLE_Row1']")).Displayed;
            
        }

        public  bool? VerifyCompetencyinheaderisdisplay()
        {
            return objDriver.GetElement(By.XPath("//strong[@id='Competency:_Row1']")).Displayed;
        }

        public  bool? VerifyOrganizationReportTrainingAssignmentlevelColumns()
        {
            objDriver.existsElement(By.Id("ExtraColumnHeaderLabel_Row1"));
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content Type");
            return objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completion Status");
        }

        public  bool? VerifySurveyExportableReportIsDisplayed(string v)
        {
            return objDriver.selectWindow("Meridian Global reporting");
        }

        public  bool? VerifyManagersReportTrainingAssignmentsExemptionslevelColumns()
        {
            objDriver.existsElement(By.Id("ExtraColumnHeaderLabel_Row1"));
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Current Assignment");
            return objDriver.GetElement(By.XPath("//th[7]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Exemption Type");
        }

        public  bool? VerifySurveyIsDisplayed()
        {
            return objDriver.existsElement(By.XPath("//td/div/table/tbody/tr/td[3]/span"));

            //public  bool? VerifySelectedContent()
            //{
            //    bool res = false;
            //    IWebElement item =objDriver.FindElement(By.XPath("//*[contains(text(),'GC2611434343anybrowserCTs')]"));
            //    IList<IWebElement> lst =objDriver.FindElements(By.XPath("//div[2]/div[2]/div/div[4]/div[@class='webix_cell']"));
            //    foreach (IWebElement x in lst)
            //    {
            //        if (lst.Contains(item))
            //        {
            //            res = true;

            //        }
            //        else
            //        {
            //            res = false;
            //            break;
            //        }
            //    }
            //    //lst.Contains(item);

            //    //return objDriver.existsElement(By.XPath("//div[2]/div[2]/div/div[4]/div"));
            //    return res;

            }

        public  bool? VerifySF_182ReportlevelColumns()
        {
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu4_Row1']/span")).Text.Equals("SF-182 Status");
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu7_Row1']/span")).Text.Equals("Training Title");
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu18_Row1']/span")).Text.Equals("Supervisor 1");
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu21_Row1']/span")).Text.Equals("Section E Authorizing Official Name");
        }

        public  bool? VerifyOrganizationReportTrainingProgresslevelColumns()
        {
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("First Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//th[7]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Complete Date");
            return objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Progress Status");
        }

        public  bool? verifyStatusDateAddedtoreportTable()
        {
            objDriver.existsElement(By.XPath("//a[@id='agColumnHeaderPopupMenu44_Row1']/span"));
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu44_Row1']/span")).Text.Equals("Status Date");
        }

        public  bool? VerifyExternalLearningOrglevelColumns()
        {
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu7_Row1']/span")).Text.Equals("External Learning Title");
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu10_Row1']/span")).Text.Equals("External Learning Type");
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu13_Row1']/span")).Text.Equals("Status");
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu29_Row1']/span")).Text.Equals("Expiration Date");
        }

        public  bool? VerifyRecentUserAccessColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Registration Date");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Logins");
            return objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Last Access Date");
        }

        public  bool? VerifyTrainingProgressbyUserlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Complete Date");
            return objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Progress Status");
        }

        public  bool? verifyTotalCostAddedtoreportTable()
        {
            if (objDriver.existsElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Total Cost')]")))
            {
                return objDriver.GetElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Total Cost')]")).Text.Equals("Total Cost");
            }

            else
            {
                return false;
            }

        }

        public  bool? isUserNamelabledisplay()
        {
            return objDriver.GetElement(By.Id("User Name:_Row1")).Text.StartsWith("User Name");
        }

        public  bool? VerifyRepeatUserAccessColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Registration Date");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Logins");
            return objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Last Access Date");
        }

        public  bool? VerifyOrgReportContentAccessColumns()
        {
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu4_Row1']/span")).Text.Equals("First Name");
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu7_Row1']/span")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu10_Row1']/span")).Text.Equals("Content Type");
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu25_Row1']/span")).Text.Equals("Total Launches");
        }

        public  bool? VerifyTestItemAnalysisResponseSummaryLableColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Question ID");
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Test Question");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Question Type");
            return objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Response");
        }

        public  bool? VerifyOrgName(string v)
        {
            return objDriver.GetElement(By.Id("Data.ORG_LIST_Row1")).Text.StartsWith(v);
        }

        public  bool? isContentTtitlelabledisplay()
        {
            return objDriver.GetElement(By.Id("Title:_Row1")).Text.StartsWith("Title:");
        }

        public  bool? VerifyTrainingProgressbyContentlevelColumns()
        {
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("First Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Enroll Date");
            objDriver.GetElement(By.XPath("//th[7]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Progress Status");
            return objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Score");
        }

        public  bool? VerifySummaryReport_TrainingProgressbyOrganizationlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Enrollments");
            objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completions");
            return objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Average Score");
        }

        public  bool? verifyCourseProviderAddedtoreportTable()
        {            
            if (objDriver.existsElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Course Provider')]")))
            {
                return objDriver.GetElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Course Provider')]")).Text.Equals("Course Provider");
            }

            else
            {
                return false;
            }

        }

        public  bool? VerifySummaryReport_UserProgressbyOrganizationlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Classroom Enrollments");
            objDriver.GetElement(By.XPath("//th[7]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Online Starts");
            return objDriver.GetElement(By.XPath("//th[16]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Average Score");
        }

        public  bool? VerifyDomainReportTrainingProgresslevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Content Title");
            objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Progress Status");
            return objDriver.GetElement(By.XPath("//th[9]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Score");
        }

        public  bool? VerifyDomainReportTrainingAssignmentslevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Last Name");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[6]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Training Period Status");
            return objDriver.GetElement(By.XPath("//th[8]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completion Status");
        }

        public  bool? VerifyUserNameisdisplayinReportheader()
        {
            return objDriver.existsElement(By.Id("User Name:_Row1"));
        }

        public  bool? VerifyOrgReportTrainingAssignmentsPeriodbyUserlevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content Type");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Name");
            return objDriver.GetElement(By.XPath("//th[5]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assignment Status");
        }

        public  bool? verifyContentActivityAddedtoreportTable()
        {
            return objDriver.GetElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Content Activity')]")).Text.Equals("Content Activity");
        }

        public  bool? VerifyTestItemAnalysisResponseDetailsLableColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Question ID");
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Test Question");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Question Type");
            return objDriver.GetElement(By.XPath("//th[7]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Response");
        }

        public  bool? VerifyOrgReportTrainingAssignmenPeriodbyUserevelColumns()
        {
            objDriver.GetElement(By.Id("ExtraColumnHeaderLabel_Row1")).Text.Equals("Assigned Content");
            objDriver.GetElement(By.XPath("//th[3]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Assigned Content Type");
            objDriver.GetElement(By.XPath("//th[4]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Training Period Status");
            return objDriver.GetElement(By.XPath("//th[7]/table/tbody/tr/td[2]/span/a/span")).Text.Equals("Completion Status");
        }

        public  bool? verifyCategoriesAddedtoreportTable()
        {
            return objDriver.GetElement(By.XPath("//*[@id='ExtraColumnHeader_Row1']/following::span[contains(text(),'Categories')]")).Text.Equals("Categories");
        }
    }

    public class CustomizeTableCommand
    {
        private IWebDriver objDriver;
        public CustomizeTableCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void SelectLoginId()
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'Login ID')]/preceding::input[1]"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
        }

        public void SelectStatusDate()
        {
            objDriver.existsElement(By.XPath("//table[@id='iclLayout_container']/tbody/tr/td[2]/ul/li[7]/label/span"));
            objDriver.ClickEleJs(By.Id("iclLayout_rdList15"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
            Thread.Sleep(5000);
        }

        public void SelectTotalCost()
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'Total Cost')]/preceding::input[1]"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
        }

        public void Unselectanyfield()
        {
            objDriver.ClickEleJs(By.Id("iclLayout_rdList8"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
        }

        public void SelectCourseProvider()
        {
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'Course Provider')]/preceding::input[1]"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
        }

        public void SelectContentActivity()
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'Content Activity')]/preceding::input[1]"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
        }

        public void SelectCategories()
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'Categories')]/preceding::input[1]"));
            objDriver.ClickEleJs(By.Id("lblLayoutOk"));
        }
    }
}

    public class PrintWindowCommand
    {
    private IWebDriver objDriver;
    public PrintWindowCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? isContentDisplayed()
        {
            throw new NotImplementedException();
        }
    }

    public class TableCommand
    {
    private IWebDriver objDriver;
    public TableCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? isSectionTitleDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu1_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isCourseTitleDidplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu4_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isInstrustorDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu7_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isLocationDisplaying()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu10_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isStartDateDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu13_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isEndDateDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu17_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isCapacityDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu21_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isEnrolledDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu24_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isAttendDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu27_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isAverageScoreDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='agColumnHeaderPopupMenu30_Row1']//span[@id='ExtraColumnHeaderLabel_Row1']")).Displayed;
        }

        public bool? isReportDropDownDisplayed()
        {
            return objDriver.GetElement(By.XPath("//select[@id='ReportMenu_Row1']")).Displayed;
        }

        public bool? isGoButtonDisplayed()
        {
            return objDriver.GetElement(By.XPath("//input[@id='GoButton_Row1']")).Displayed;
        }

        public void ClickSettingImg()
        {
            objDriver.ClickEleJs(By.Id("imgTableEdit"));
        }

        public void ClickGroup()
        {
            objDriver.ClickEleJs(By.Id("lblHeadingGroup"));
        }

        public void SelectGroupingColumn(string v)
        {
            objDriver.ClickEleJs(By.Id("rdAgGroupColumn"));
            objDriver.select(By.XPath("//td[@id='colGroupColumnCell2']/span"), v);
        }

        public void ClickAdd()
        {
            objDriver.ClickEleJs(By.Id("lblGroupOk"));
            Thread.Sleep(1000);
        }
    }
