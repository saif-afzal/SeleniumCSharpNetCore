using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CertificationPage
    {
        #region element ids
        public static By CertificationAutoGrantdropdown = By.Id("MainContent_UC1_FormView1_fvCertificate_ddlCERT_AUTO_GRANT_ON_COMPLETION");
        #endregion

        public static RadiobuttonCommand Radiobutton { get { return new RadiobuttonCommand(); } }

        public static SummaryCommand Summary { get { return new SummaryCommand(); } }

        public static SelectDropDownCommand SelectDropDown { get { return new SelectDropDownCommand(); } }

        public static DisplayFormatDropdownCommand DisplayFormatDropdown { get { return new DisplayFormatDropdownCommand(); } }

        public static WhenistherecertificationperiodCommand Whenistherecertificationperiod { get { return new WhenistherecertificationperiodCommand(); } }

        public static AvailableinCatalogCommand AvailableinCatalog { get { return new AvailableinCatalogCommand(); } }

        public static void FillTitle(string v)
        {
            Thread.Sleep(5000);
            Driver.Instance.WaitForElement(By.Id("CNTLCL_TITLE"));
            if (Driver.existsElement(By.Id("CNTLCL_TITLE")))
            {
                Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
                Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            }
            else
            {
                CommonSection.CreateLink.Certifications();
                Driver.Instance.WaitForElement(By.Id("CNTLCL_TITLE"));
                Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
                Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            }
        }

        public static void SelectCertificationexpireRadiobutton(string v)
        {
            throw new NotImplementedException();
        }

        public static void ClickCreate()
        {
            Driver.existsElement(By.Id("MainContent_UC1_Save"));
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
            Thread.Sleep(3000);
            Driver.Instance.Checkin();
        }

        public static string VerifySuccessMessageText(string v)
        {
            Driver.Instance.WaitForElement(By.XPath("//div[@id='content']/div[2]/div"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public static string VerifyCompletionCriteriaText(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[5]/strong"));
            return Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[5]/strong")).Text;
        }

        public static string VerifyReCertificationCompletionCriteriaText(string v)
        {
            try
            {
                Driver.existsElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[10]/strong"));
                return Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[10]/strong")).Text;
            }
            catch
            {
                return Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[10]/strong")).Text;
            }
        }

        public static void ClickSearchedCertification_Dashboard(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]"));
        }

      

        public static void SearchCertification_Dashboard(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='DashboardSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btnSearchCertifications']"));
        }

        public static void CreateCertification()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));

        }

        
     public static void AddContentInCertification(string ClassroomCourse)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCertficateContents_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Add Content')]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(ClassroomCourse);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_btnAddCert']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));

        }

        public static void CheckIn()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static void ClickCreateCertification()
        {
            Driver.existsElement(By.Id("MainContent_UC1_Save"));
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
            Thread.Sleep(3000);
        }

        public static bool? isShouldthecertificatebeautomaticallygranteduponcontentcompletion_lavelDisplay()
        {
            return Driver.Instance.FindElement(By.XPath("//label[contains(text(),'Should the certificate be automatically granted up')]")).Displayed;
        }

        public static bool? automaticallygrantedcertificationDefaultValue(string v)
        {
            //string dropdownvalue = Driver.GetElement(By.Id("MainContent_UC1_FormView1_fvCertificate_ddlCERT_AUTO_GRANT_ON_COMPLETION")).Text;
            string dropdownvalue=Driver.GetElement(CertificationAutoGrantdropdown).Text;

            return dropdownvalue.Trim().StartsWith(v);
        }

        public static bool? automaticallygrantedcertificationValuesare(string v1, string v2)
        {
            bool res = false;
            string[] dropdownlist = null;
            string dropdownvalue = Driver.GetElement(By.Id("MainContent_UC1_FormView1_fvCertificate_ddlCERT_AUTO_GRANT_ON_COMPLETION")).Text.Trim();
            string[] stringSeparators = new string[] { "\r\n" };
            string[] autogrant = dropdownvalue.Split(stringSeparators, StringSplitOptions.None);
            if (Array.Exists(autogrant, element => element == v1) && Array.Exists(autogrant, element => element == v2))
            {
                res=true;
            }
            return res;
           //return Driver.GetElement(By.Id("MainContent_UC1_FormView1_fvCertificate_ddlCERT_AUTO_GRANT_ON_COMPLETION")).Text.Equals(v1+v2);
        }

        public static void SelectautomaticallygrantedcertificationDefaultValue(string v)
        {
            Driver.clickEleJs(By.XPath("//div[6]/div/div/div/div/ul/li[2]/a/span"));
            Thread.Sleep(2000);
            Driver.select(By.XPath("//div[6]/div/div/div/select"), "No, admin approval is required");
        }

        public static void DoesthisCertificationexpire(string v)
        {
            Driver.clickEleJs(By.XPath("//label[contains(text(),'Does this certification expire?')]"));
        }

        public static bool? isthisarecurringcertificationLeveldisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'Is this a recurring certification?')]"));
        }

        public static void isthisarecurringcertification(string v)
        {
            Driver.clickEleJs(By.XPath("//label[contains(text(),'Is this a recurring certification?')]"));
        }

        public static bool? isWhenistherecertificationperiodLevelDisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'When is the recertification period?')]"));
        }

        public static bool? isCertificationperiodfieldsDisplay()
        {
            return Driver.existsElement(By.XPath("//input[@id='CERT_RECERT_TIME_INTERVAL']"));
        }

        public static bool? isWhendoestheCertificationgointoeffectLevelDisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'When does the recertification go into effect?')]"));
        }

        public static WhenistsertificationperiodCommand Whenistsertificationperiod(string v)
        {
            return new WhenistsertificationperiodCommand(v);
        }

        public static void selectCompletionCriteria(string v)
        {
            if(v.ToLower()=="liner")
            {
                Driver.clickEleJs(By.XPath("//div[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div/div/div/div/button"));
                Driver.select(By.Id("CERT_COMPLETION_CRITERIA"), "Content is completed in SPECIFIC order");
                ////div[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div/div/div/div/div/ul/li[2]/a/span/small
            }
            if (v.ToLower() == "total credit hours are achieved")
            {
                Driver.clickEleJs(By.XPath("//div[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div/div/div/div/button"));
                Driver.select(By.Id("CERT_COMPLETION_CRITERIA"), "Total credit hours are achieved");
                ////div[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div/div/div/div/div/ul/li[2]/a/span/small
            }
        }

        public static void SearchCertification_Dashboard_DetailsPage(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='UserSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btnSearchUsers']"));
        }

        public static void Click_OptionFromActionMenu(string v)
        {
            Driver.clickEleJs(By.XPath("//tr[1]//td[6]//span[1]//button[1]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Recertify')]"));
        }
    }

    public class WhenistsertificationperiodCommand
    {
        private string v;
        private string days;

        public WhenistsertificationperiodCommand(string v)
        {
            this.v = v;
        }

        public WhenistsertificationperiodCommand until(string days)
        {
            this.days = days;
            return this;
        }

        public void Days()
        {
            Driver.existsElement(By.XPath("//div[@id='immediateOptions']/div/div/div/div/ul/li[2]/a/span"));
            Driver.clickEleJs(By.XPath("//div[@id='immediateOptions']/div/div/div/div/ul/li[2]/a/span"));
            Thread.Sleep(5000);
            //Driver.select(By.Id("immediateOptionsMode"), "With limit after expiration");
            //Thread.Sleep(3000);
            Driver.GetElement(By.Id("immediateRecertExtensionInterval")).Clear();
            Driver.GetElement(By.Id("immediateRecertExtensionInterval")).SendKeysWithSpace(days);
        }
    }

    public class WhenistherecertificationperiodCommand
    {
        public WhenistherecertificationperiodCommand()
        {

        }

        public void Setbeforeexpiration()
        {
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-default period-options']"));
        }

        public void Brfore(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='CERT_RECERT_TIME_INTERVAL']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='CERT_RECERT_TIME_INTERVAL']")).SendKeysWithSpace(v);
        }

        public void After(string v)
        {
            Driver.existsElement(By.Id("delayRecertExtensionInterval"));
            Driver.GetElement(By.Id("delayRecertExtensionInterval")).Clear();
            Driver.GetElement(By.Id("delayRecertExtensionInterval")).SendKeysWithSpace(v);
        }

        public void SetEndsAs(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='periodOptions']/div/div[2]/div/button/span"));
            Driver.clickEleJs(By.XPath("//div[@id='periodOptions']/div/div[2]/div/button/span"));
            Driver.select(By.Id("periodOptionsMode"), v);
            Thread.Sleep(2000);
        }

        public void Start(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='CERT_RECERT_TIME_INTERVAL']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='CERT_RECERT_TIME_INTERVAL']")).SendKeys(v);
        }

        public void ReCertificationWindowWithLimitAfterExpiration(string v)
        {
            Driver.select(By.Id("immediateOptionsMode"),"With limit after expiration");
            Driver.GetElement(By.XPath("//input[@id='immediateRecertExtensionInterval']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='immediateRecertExtensionInterval']")).SendKeysWithSpace(v);

           
        }
    }

    public class SelectDropDownCommand
    {
        public SelectDropDownCommand()
        {
        }

        public void CompletionCriteriaAs(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div/div/div/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div/div/div/div/button/span[2]/span"));
            Driver.select(By.XPath("//div[7]/div/div/div/div/select"), v);
            Thread.Sleep(2000);
        }

        public void TotalHrsscrollAs(string v)
        {
            Driver.existsElement(By.XPath("//input[@id='CERT_COMPLETION_CRITERIA_CREDIT']"));
            Driver.GetElement(By.XPath("//input[@id='CERT_COMPLETION_CRITERIA_CREDIT']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='CERT_COMPLETION_CRITERIA_CREDIT']")).SendKeys(v);
            Thread.Sleep(2000);
        }

        public void CreditTypeAs(string v)
        {
            Driver.Instance.WaitForElement(By.XPath("//div[@class='col-md-9 md:pl-4 form-group completion-criteria collapse in']//button[@class='dropdown-toggle btn btn-default form-control-select-sub']"));
            Driver.clickEleJs(By.XPath("//div[@class='col-md-9 md:pl-4 form-group completion-criteria collapse in']//button[@class='dropdown-toggle btn btn-default form-control-select-sub']"));
            Driver.select(By.XPath("//*[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[1]/div/div/div[2]/div[2]/div/div"), v,"a");
            Thread.Sleep(2000);
        }

        public void ReCertificationCriteriaAs(string v)
        {
            Driver.existsElement(By.XPath("//div[@class='btn-group bootstrap-select']//button[@class='btn dropdown-toggle btn-default']"));
            Driver.clickEleJs(By.XPath("//label[contains(text(),'How do learners recertify?')]/following::button[1]"));
            Driver.select(By.XPath("//div[@class='btn-group bootstrap-select open']//div[@class='dropdown-menu open']"), v,"a");
        }

        public void ReCertificationTotalHrsscrollAs(string v)
        {
            Driver.GetElement(By.Id("CERT_RECERT_COMPLETION_CRITERIA_CREDIT")).Clear();
            Driver.GetElement(By.Id("CERT_RECERT_COMPLETION_CRITERIA_CREDIT")).SendKeys(v);
            Thread.Sleep(2000);
        }

        public void ReCertificationCreditTypeAs(string v)
        {
            Driver.GetElement(By.XPath("//div[@class='col-md-9 md:pl-4 form-group recert-complete-credit collapse in']//button[@class='dropdown-toggle btn btn-default form-control-select-sub']")).ClickWithSpace();
            Thread.Sleep(2000);
            Driver.select(By.XPath("//div[@class='btn-group bootstrap-select form-control open']//div[@class='dropdown-menu open']"), v,"a");
        }
    }
   

    public class RadiobuttonCommand
    {
        public RadiobuttonCommand()
        {
        }

        public void SelectCertificationexpireAs(string v)
        {
            IWebElement element = Driver.Instance.FindElement(By.XPath("//label[contains(text(),'Does this certification expire?')]/following::span[3]"));
            if (v.ToLower().Equals("yes"))
            {
                Actions action = new Actions(Driver.Instance);
                action.MoveToElement(element).Perform();
                Driver.clickEleJs(By.XPath("//label[contains(text(),'oes this certification expire?')]"));
               // Driver.Instance.WaitForElement(By.Id("CERT_PERIOD"));
            }
            else 
            {
                Driver.GetElement(By.XPath("//div[@class='bootstrap-switch bootstrap-switch-wrapper bootstrap-switch-off bootstrap-switch-small bootstrap-switch-id-certificationExpire bootstrap-switch-animate']//span[@class='bootstrap-switch-handle-off bootstrap-switch-default'][contains(text(),'No')]")).ClickWithSpace();
                Thread.Sleep(2000);
            }
        }

        public void IncludePastContentCompletionAs(string v)
        {
            if (v.ToLower().Equals("yes"))
            {
                Driver.clickEleJs(By.XPath("//label[contains(text(),'Do past completions count toward this certificatio')]"));
            }
            else
            {
                Driver.GetElement(By.XPath("//div[@class='bootstrap-switch bootstrap-switch-wrapper bootstrap-switch-off bootstrap-switch-small bootstrap-switch-id-pastCompletion bootstrap-switch-animate']//span[@class='bootstrap-switch-handle-off bootstrap-switch-default'][contains(text(),'No')]")).ClickWithSpace();
                Thread.Sleep(3000);
            }
        }

        public void CertificationCostTypeAs(string v)
        {
            Driver.existsElement(By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_COST_TYPE_0"));
            Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_COST_TYPE_0"));

        }

        public void SelectAllowReCertificationAs(string v)
        {
            //Driver.Instance.WaitForElement(By.XPath("//div[2]/fieldset/div/div/div/div/label"));
            Driver.clickEleJs(By.XPath("//label[contains(text(),'Is this a recurring certification?')]"));
           // Driver.Instance.WaitForElement(By.XPath("//div[@id='MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div/div/div/label"));

        }
    }


}