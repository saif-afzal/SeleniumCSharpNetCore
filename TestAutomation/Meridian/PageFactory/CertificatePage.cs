using OpenQA.Selenium;
using Selenium2.Meridian;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class CertificatePage:ObjectInit
    {
        private IWebDriver objDriver;
        public CertificatePage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }

        public  bool? VerifyFileDownload(string v)
        {
            if (objDriver.WindowHandles.Count > 1)
            {
                objDriver.selectWindow(Meridian_Common.childwdw1);
                objDriver.SwitchTo().Frame(0);
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Close Window')]"));
                objDriver.focusParentWindow();
            }
            else
            {
                return objDriver.verifyFile(v);
            }
            return true;
        }

        public  void Edit_Click(IWebDriver driver)
        {
            throw new NotImplementedException();
        }

        public  bool? isrequiredattributesdisplay()
        {
            bool result = false;
            try
            {
                objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlSave']/fieldset/legend"));
                objDriver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_btnPreview"));
                objDriver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_btnChangeCertificate"));
                result = true;
            }
            catch
            { }
            return result;
        }

        public  void click_ChageCertificate()
        {
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_btnChangeCertificate"));
        }

        public  bool? isCurrentCertificatedisplay()
        {
            return objDriver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_btnRemove"));
        }

        public  bool? CertificatePreviewModalDisplay()
        {
            throw new NotImplementedException();
        }

        public  void Click_Preview()
        {
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_btnPreview"));
        }

        public  void Click_back()
        {
            objDriver.focusParentWindow();
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }

        public  void addContentIntoCertificate(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCertficateContents_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkUserGroup']"));
            objDriver.GetElement(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//input[@value='Search']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_btnAddCert']"));
            objDriver.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }

        public  bool? searchforCertification(string coursetitle, string generalcoursetitle)
        {
            bool result = false;
            try
            {
                commonSection1.SearchCatalog(coursetitle);
                objDriver.IsElementVisible(By.XPath("//a[contains(.,'" + coursetitle + "')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + coursetitle + "')]"));
                objDriver.IsElementVisible(By.XPath("//a[contains(.,'" + generalcoursetitle + "')]"));
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + generalcoursetitle + "')]"));


                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public  bool? isPrintLinkDisplayed()
        {
           
            objDriver.SwitchWindow("CloseWindow");
            objDriver.SwitchTo().Frame(0);
            return objDriver.GetElement(By.XPath("//*[@id='BaseForm']/table/tbody/tr/td/a[1]")).Displayed;
            
        }

        public  void ClickCloseWindow()
        {
            objDriver.ClickEleJs(By.XPath("/html[1]/body[1]/form[1]/table[1]/tbody[1]/tr[1]/td[1]/a[2]"));
            objDriver.focusParentWindow();
        }

        public  bool? VerifyCertificateCourseTitle()
        {
            string CertificateCourseTitle = "";
            Meridian_Common.CertificateCourseTitle = objDriver.GetElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/section[1]/h3[1]/span[1]")).Text;
            if(Meridian_Common.CertificateCourseTitle==Meridian_Common.ContentPageCourse)
            {
                return true;
            }
            return false;



        }

        public  bool? VerifyCertificateDate()
        {
            string CertificateDate = objDriver.GetElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/section[1]/h3[1]/span[2]/span[1]")).Text;

          
            if (CertificateDate == Meridian_Common.CourseComplitionDate)
            {
                return true;
            }
            return false;



        }

        public  bool? VerifyCandidateName()
        {
             string CandidateNameOnCertificate = objDriver.GetElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/section[1]/h2[1]/span[1]")).Text;

            //Meridian_Common.CandidateName = objDriver.GetElement(By.XPath("/html[1]/body[1]/form[1]/div[7]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/h2[1]")).Text;

            if (CandidateNameOnCertificate == Meridian_Common.CandidateName)
            {
                return true;
            }
            return false;
           objDriver.SwitchTo().DefaultContent();
        }

        public  void Click_backbutton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_btnCancel"));
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }

        public  bool? isWhenpreviousCertificationexpiresDisplay()
        {
            return objDriver.existsElement(By.XPath("//button[contains(text(),'When previous certification expires')]"));
        }

        public  bool? isUponrecertificationcontentcompletionDisplay()
        {
            return objDriver.existsElement(By.XPath("//button[contains(text(),'Upon recertification content completion')]"));
        }

        public  bool? isUponrecertificationcontentcompletionSelected()
        {
            throw new NotImplementedException();
        }

        public  void Doesthiscertificationexpire(string v)
        {
            objDriver.ClickEleJs(By.XPath("//label[contains(text(),'Does this certification expire?')]"));
        }

        public  void addContenttoRecertification(string v)
        {
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucReCertification_lnkEdit"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkAddContent']"));
            objDriver.GetElement(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch"));
            objDriver.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent"));
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_btnAddReCert"));
            objDriver.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }

        public  void addContentIntoCertificateAlternetOption(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAlternateOptions_lnkEdit']"));
            objDriver.existsElement(By.Id("MainContent_MainContent_UC1_lnkUserGroup"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkUserGroup']"));
            objDriver.GetElement(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch"));
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath("//td[2]/input"));
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucAddContentSearch_btnAddAltOption"));
            objDriver.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }

        public  void addClassroomsectionIntoCertificate(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCertficateContents_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkUserGroup']"));
            objDriver.GetElement(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//input[@value='Search']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent']"));
            objDriver.ClickEleJs(By.XPath("//td/input"));
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath("//td[2]/table/tbody/tr/td/input"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_btnAddCert']"));
            objDriver.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }
    }

}

