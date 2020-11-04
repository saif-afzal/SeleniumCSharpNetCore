using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomation.helper;

namespace TestAutomation.Miscellaneous
{
    public class SummaryPage:ObjectInit
    {
        private IWebDriver objDriver;
        public SummaryPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  string Title
        {
            get
            {
                Thread.Sleep(20000);
                string res = objDriver.Title;
                //objDriver.ClickEleJs(By.Id("MainContent_ucEditContent_FormView1_btnEditContent"));
                return res;
            }
        }

        //public  SelectDropDownCommand SelectDropDown { get { return new SelectDropDownCommand(); } }

        public  SelectDropDownonSummaryCommand SelectDropDownonSummary { get { return new SelectDropDownonSummaryCommand(objDriver); } }

        public  DisplayformatCommand DisplayFormatDropdown { get { return new DisplayformatCommand(objDriver); } }

        public  void ClickSavebutton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public  string GetSuccessMessage()
        {
            string rettext = objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            return rettext.Trim();
        }

        public  void UpdateTitle(string v)
        {
            objDriver.existsElement(By.Id("CNTLCL_TITLE"));
            objDriver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            objDriver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath(".//*[@id='MainContent_UC1_Save']"));
        }

        public  bool? VerifyCompletionCriterianoteditable(string v)
        {
            Thread.Sleep(3000);
            objDriver.WaitForElement(By.XPath("//div[7]/div/div/div/label"));
            return objDriver.GetElement(By.XPath("//*[@id='CERT_COMPLETION_CRITERIA']")).Enabled;
            // return true;
        }

        public  bool? VerifyTotalHoursnoteditable(string v)
        {
            IWebElement dd = objDriver.GetElement(By.XPath("//div[2]/div/input"));
            return dd.Enabled;
        }

        public  bool? VerifyfCreditTypenoteditable(string v)
        {
            IWebElement dd = objDriver.GetElement(By.XPath("//div[3]/div/div/select"));

            return dd.Enabled;
        }

        public  void clicksave()
        {
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Thread.Sleep(2000);
        }

        public  void ClickonCertificationsBreadcromb()
        {
            Thread.Sleep(2000);
            objDriver.WaitForElement(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
            Thread.Sleep(3000);

        }

        public  bool? AddnewTag(string v)
        {
            bool result = false;
            try
            {
                Thread.Sleep(5000);
                objDriver.ClickEleJs(By.Id("ContentTags"));
                //objDriver.ClickEleJs(By.XPath("//input[@id='s2id_autogen4']"));
                objDriver.GetElement(By.XPath("//input[@autocapitalize='off']")).SendKeysWithSpace(v);
                Thread.Sleep(1000);
                IWebElement webElement = objDriver.FindElement(By.XPath("//input[@autocapitalize='off']"));
                webElement.SendKeys(OpenQA.Selenium.Keys.Tab);
                Thread.Sleep(1000);
                objDriver.ClickEleJs(By.XPath("//div[@id='container-tags']/div/span/div/form/div/div/div[2]/button/i"));
                Thread.Sleep(1000);
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public  bool? checkContentTagsOnDetailsPage()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[3]/strong"));
        }
    }
    public class DisplayformatCommand
    {
        private IWebDriver objDriver;
        public DisplayformatCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? Defaultvalue(string v)
        {

            objDriver.existsElement(By.XPath("//span[@class='filter-option pull-left']"));
            return objDriver.GetElement(By.XPath("//span[@class='filter-option pull-left']")).Text.Contains(v);
        }
    }

    public class SelectDropDownonSummaryCommand
    {
        private IWebDriver objDriver;
        public SelectDropDownonSummaryCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ReCertificationCriteriaAs(string v)
        {
            Thread.Sleep(5000);
            objDriver.WaitForElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div/div/div/div/button/span[2]/span"));
            objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div/div/div/div/button/span[2]/span")).ClickWithSpace();
            Thread.Sleep(3000);
            objDriver.selectDropdownValue(By.XPath("//*[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[1]/div/div/div/div/ul"), v);
            Thread.Sleep(5000);
        }

        public void TotalHrsscrollAs(string v)
        {
            objDriver.existsElement(By.XPath("//fieldset[2]/div/div[2]/div/input"));
            objDriver.GetElement(By.XPath("//fieldset[2]/div/div[2]/div/input")).Clear();
            objDriver.GetElement(By.XPath("//fieldset[2]/div/div[2]/div/input")).SendKeys(v);
            Thread.Sleep(2000);
        }

        public void CreditTypeAs(string v)
        {
            objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/button/span/small"));
            objDriver.WaitForElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/button/span/small"));
            objDriver.ClickEleJs(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/button/span/small"));
            objDriver.selectDropdownValue(By.XPath("//*[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/div/ul"), v);
            Thread.Sleep(5000);

        }
    }
}
