using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class Transcripts
    {
        private readonly IWebDriver driverobj;
        public Transcripts(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Check_TranscriptDefaults()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_AllMyTraining);
                driverobj.WaitForElement(cmb_allmytrainingtype);
                driverobj.WaitForElement(cmb_allmytrainingstatus);
                driverobj.WaitForElement(txt_allmytrainingFromDate);
                driverobj.WaitForElement(txt_allmytrainingFromDate);
                driverobj.WaitForElement(btn_allmytrainingfilter);
                driverobj.WaitForElement(lnk_allmytrainingfirstitem);
                driverobj.WaitForElement(btn_saveaspdf);
                driverobj.WaitForElement(btn_print);
                actualresult = true;
            }
            catch (Exception e)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }

        public bool Click_AllMyTrainingLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_AllMyTraining);
                driverobj.ClickEleJs(lnk_AllMyTraining);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_RequiredTrainingLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_RequiredTrainig);
                driverobj.ClickEleJs(lnk_RequiredTrainig);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_ExternalLearningLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_ExternalLearning);
                driverobj.GetElement(lnk_ExternalLearning).ClickWithSpace();

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_CertificationLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkCert"));
                driverobj.ClickEleJs(By.Id("MainContent_ucQLinks_lnkCert"));

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_CurriculamLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_Curriculam);
                driverobj.ClickEleJs(lnk_Curriculam);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_CurriculamFilter()
        {
            bool result = false;

            try
            {
                SelectElement oSelect = new SelectElement(driverobj.FindElement(By.XPath("//select[@id='MainContent_UC1_ddlType']")));
                SelectElement oSelect1 = new SelectElement(driverobj.FindElement(By.XPath("//select[@id='MainContent_UC1_ddlStatus']")));
                oSelect.SelectByText("Curriculums");
                oSelect1.SelectByText("Completed");
                driverobj.WaitForElement(lnk_Curriculam);
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnFilter']"));
                driverobj.WaitForElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction']"));
                driverobj.SelectWindowClose2();

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_Document_Filter()
        {
            bool result = false;

            try
            {
                SelectElement oSelect = new SelectElement(driverobj.FindElement(By.XPath("//select[@id='MainContent_UC1_ddlType']")));
                SelectElement oSelect1 = new SelectElement(driverobj.FindElement(By.XPath("//select[@id='MainContent_UC1_ddlStatus']")));
                oSelect.SelectByText("Curriculums");
                oSelect1.SelectByText("Completed");
                driverobj.WaitForElement(lnk_Curriculam);
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnFilter']"));
                driverobj.WaitForElement(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction']"));
                driverobj.SelectWindowClose2();

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Check_AllMyTrainingFilters()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(cmb_allmytrainingtype);
                driverobj.WaitForElement(cmb_allmytrainingstatus);
                driverobj.WaitForElement(txt_allmytrainingFromDate);
                driverobj.WaitForElement(txt_allmytrainingFromDate);
                driverobj.WaitForElement(btn_allmytrainingfilter);
                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }


        public bool SelectType(string type)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(cmb_allmytrainingtype);
                driverobj.select(cmb_allmytrainingtype, type);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }
        public bool SelectStatus(string status)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(cmb_allmytrainingstatus);
                driverobj.select(cmb_allmytrainingstatus, status);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_BtnFilter()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_allmytrainingfilter);
                driverobj.ClickEleJs(btn_allmytrainingfilter);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Check_DesiredResult(string searchedrecord)
        {
            bool result = false;
            
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + searchedrecord + "')]"));

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public bool Click_DesiredResult(string searchedrecord)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + searchedrecord + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + searchedrecord + "')]"));
                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }


        public bool Click_PrintBtn(string PageTitle,string course = "",string browserstr="",string type="")
        {
            bool actualresult = false;

            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(btn_print);
                driverobj.ClickEleJs(btn_print);
                Thread.Sleep(6000);
              //  driverobj.Close();
                Thread.Sleep(2000);
                driverobj.selectWindow("All Training");
                for (int i = 1; i <= 2; i++)
                {
                    actualresult = driverobj.existsElement(By.XPath("//td[contains(text(),'" + course+ "')]"));
                    break;
                }
                driverobj.SelectWindowClose2(PageTitle, "Transcript");
              //  driverobj.SwitchWindow(PageTitle);
                //driverobj.Close();
                //Thread.Sleep(3000);
                //driverobj.SwitchTo().Window(originalHandle);
               // actualresult = true;

            }

            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool Click_PDFBtn(string PageTitle)
        {
            bool actualresult = false;

            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(btn_saveaspdf);
                driverobj.ClickEleJs(btn_saveaspdf);
                Thread.Sleep(10000);
            //    driverobj.SelectWindowClose2("CurriculaPrint.aspx", "Transcript");
                driverobj.SelectWindowClose2();
              //  driverobj.SwitchWindow(PageTitle);
                //driverobj.Close();
                Thread.Sleep(3000);
                //driverobj.SwitchTo().Window(originalHandle);
                actualresult = true;

            }

            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool Click_ELSubmitRequest()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_elsubmitrequest);
                driverobj.GetElement(btn_elsubmitrequest).ClickWithSpace();
                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }


            return result;
        }

        public string Click_ELFirstItem()
        {
            try
            {
                driverobj.WaitForElement(lnk_elfirstitem);
                string itemfound = driverobj.GetElement(lnk_elfirstitem).Text;
                driverobj.GetElement(lnk_elfirstitem).ClickWithSpace();
                return itemfound;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                return "";
            }
        }


        public bool Check_CertificationsFirstItem()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_certificationsfirstitem);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }
            return result;
        }

        public string Click_CertificationsFirstItem()
        {

            try
            {
                driverobj.WaitForElement(lnk_certificationsfirstitem);
                string itemfound = driverobj.GetElement(lnk_certificationsfirstitem).Text;
                driverobj.GetElement(lnk_certificationsfirstitem).ClickWithSpace();
                return itemfound;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                return "";
            }

        }


        public bool Check_CurriculamFirstItem()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_curriculamfirstitem);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }
            return result;
        }

        public string Click_CurriculamFirstItem()
        {

            try
            {
                driverobj.WaitForElement(lnk_curriculamfirstitem);
                string itemfound = driverobj.GetElement(lnk_curriculamfirstitem).Text;
                driverobj.GetElement(lnk_curriculamfirstitem).ClickWithSpace();
                return itemfound;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                return "";
            }

        }

        public bool Check_RequiredTrainingFirstItem()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_requiredtrainingfirstitem);

                result = true;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);

            }
            return result;
        }

        public string Click_RequiredTrainingFirstItem()
        {

            try
            {
                driverobj.WaitForElement(lnk_requiredtrainingfirstitem);
                string itemfound = driverobj.GetElement(lnk_requiredtrainingfirstitem).Text;
                driverobj.GetElement(lnk_requiredtrainingfirstitem).ClickWithSpace();
                return itemfound;
            }
            catch (Exception e)
            {

                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
                return "";
            }

        }
        public bool IsTranscriptPageLoaded()
        {
            try
            {
                if (!(driverobj.IsElementVisible(transcript_QuickLinksSection) && driverobj.IsElementVisible(allTraningsPannel)))
                { return false; }
                if (!driverobj.Url.ToLower().Contains("transcript"))
                { return false; }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private By lnk_AllMyTraining = By.Id("MainContent_ucQLinks_lnkAllTraining");
        private By lnk_Curriculam = By.Id("MainContent_ucQLinks_lnkCurriculum");//a[@id='MainContent_ucQLinks_lnkCurriculum']
        private By lnk_ExternalLearning = By.Id("MainContent_ucQLinks_lnkEL");
        private By lnk_RequiredTrainig = By.Id("MainContent_ucQLinks_lnkRT");
        private By lnk_Certifications = By.Id("MainContent_ucQLinks_lnkCert");

        private By cmb_allmytrainingtype = By.Id("MainContent_UC1_ddlType");
        private By cmb_allmytrainingstatus = By.Id("MainContent_UC1_ddlStatus");
        private By txt_allmytrainingFromDate = By.Id("ctl00_MainContent_UC1_rdpFromDate_dateInput");
        private By txt_allmytrainingToDate = By.Id("ctl00_MainContent_UC1_rdpToDate_dateInput");
        private By btn_allmytrainingfilter = By.Id("MainContent_UC1_btnFilter");
        private By lnk_allmytrainingfirstitem = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");

        private By lnk_firstitem = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");
        private By btn_print = By.XPath("//a[contains(.,'Print')]"); //By.Id("MainContent_UC1_MLinkButton1");// not using id bcoz differs on ff and ie


        private By btn_saveaspdf = By.XPath("//a[contains(.,'Save as PDF')]");//By.Id("MainContent_UC1_SaveAsPDF");// not using id bcoz differs on ff and ie


        private By btn_elsubmitrequest = By.Id("MainContent_UC2_MLinkButton1");

        private By lnk_elfirstitem = By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_lnkDetails");

        private By lnk_certificationsfirstitem = By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_lnkDetails");

        private By lnk_curriculamfirstitem = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");

        private By lnk_requiredtrainingfirstitem = By.Id("ctl00_MainContent_UC1_rgRequiredTraining_ctl00_ctl04_lnkDetails");
        private By transcript_QuickLinksSection = By.Id("QuickLinks");
        private By allTraningsPannel = By.CssSelector("div[id*='_MainContent_UC1Panel']");
    }
}
