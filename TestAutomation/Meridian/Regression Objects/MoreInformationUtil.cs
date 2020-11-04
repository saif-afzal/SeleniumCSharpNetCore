using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
// using TestAutomation.Data;
using System.Threading;
using Selenium2.Meridian;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class MoreInformationUtil
    {
        private readonly IWebDriver driverobj;
        public MoreInformationUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

        public void Create_Classroom_Course(string browserstr)
        {
            try
            {

                ClassroomCourse classroomcourse = new ClassroomCourse(driverobj);
                //string expectedresult = "The item was created.";
                // TrainigCatalogUtilDriver.UserLogin("admin");
                classroomcourse.linkmyresponsibilitiesclick(driverobj);
                classroomcourse.linkclassroomcourseclick();
                classroomcourse.buttongoclick();
                classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr + "WP0", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
                classroomcourse.buttonsaveclick();
                classroomcourse.SetPrerequisite();
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }

        }
        public void searchCourse(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(txttraininghomesearch);
                driverobj.GetElement(txttraininghomesearch).Clear();
                driverobj.GetElement(txttraininghomesearch).SendKeysWithSpace(ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr + "WP0");
                driverobj.FindSelectElementnew(cmbtraininghomesearch, "All words");
                driverobj.GetElement(btntraninghomesearch).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "WP0" + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "WP0" + "')]")).ClickAnchor();

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }
        public void RequestforWiever(string browserstr)
        {
            try
            {
                searchCourse(browserstr);
                driverobj.WaitForElement(btnrequestwiever);
                driverobj.GetElement(btnrequestwiever).ClickWithSpace();
                Thread.Sleep(3000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(3000);
                driverobj.WaitForElement(chkrequestwiever);
                driverobj.GetElement(chkrequestwiever).ClickWithSpace();
                driverobj.GetElement(btnsaverequestwiever).ClickWithSpace();
                driverobj.WaitForElement(sucessmessage);
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }
        public void AproveWaiver(string browserstr)
        {
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickWithSpace();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(linkwieverconsole).Click();
                driverobj.WaitForElement(txtcourseforwiever);
                driverobj.GetElement(txtcourseforwiever).Clear();
                driverobj.GetElement(txtcourseforwiever).SendKeys(ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr + "WP0");
                driverobj.GetElement(btncoursesearchforwiever).Click();
                driverobj.WaitForElement(btngoforwiever);
                driverobj.GetElement(btngoforwiever).Click();
                driverobj.WaitForElement(txtsearchuserforwiever);
                driverobj.GetElement(txtsearchuserforwiever).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr);
                driverobj.GetElement(btnsearchuserforwiever).Click();
                //driverobj.WaitForElement(By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_ENTITY_ID_1_ENTITY_LIST_1_0_']"));
                //driverobj.GetElement(By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_ENTITY_ID_1_ENTITY_LIST_1_0_']")).Click();
                driverobj.WaitForElement(chkuserforwiever);
                driverobj.GetElement(chkuserforwiever).Click();
                driverobj.GetElement(chkassignwiever).Click();
                driverobj.WaitForElement(returnfeedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }

        public bool checkwiever(string browserstr)
        {
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckwiever);
                driverobj.ClickEleJs(lnkcheckwiever);
                Thread.Sleep(3000);
                //driverobj.SelectFrame();
                //driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.CssSelector("div[id*='_rgWaivedPrereqs']"));
                //driverobj.WaitForElement(By.XPath("//td[contains(text(),'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "WP0" + "')]"));
                // driverobj.WaitForElement(By.XPath("//td[contains(text(),'7173 KS Module 2: PMBOK® Guide Contents and Foundational Concepts')]"));
                //driverobj.WaitForElement(lblwievertype);
                // driverobj.WaitForElement(By.XPath("//td[contains(text(),'SCORM 1.2')]"));
                //string originalHandle = driverobj.CurrentWindowHandle;
                //driverobj.SwitchTo().Window(originalHandle);
                //driverobj.GetElement(btncloseframe).Click();    
                //driverobj.WaitForElement(lnkcheckwiever);
                return true;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool printwiever(string browserstr)
        {
            bool actualresult = false;
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckwiever);
                driverobj.ClickEleJs(lnkcheckwiever);
                Thread.Sleep(3000);
                driverobj.WaitForElement(btnprintwiever);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.ClickEleJs(btnprintwiever);
                Thread.Sleep(3000);
                if (driverobj.SwitchWindow("Waived Prerequisites"))
                {
                    driverobj.GetElement(printwindowwievedtext);
                    driverobj.Close();
                    Thread.Sleep(3000);
                    driverobj.SwitchTo().Window(originalHandle);
                    actualresult = true;
                }
                else return false;
                return actualresult;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }

        public bool savepdfwiever(string browserstr)
        {
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckwiever);
                driverobj.ClickEleJs(lnkcheckwiever);
                Thread.Sleep(3000);
                driverobj.WaitForElement(btnsaveaspdfwiever);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.ClickEleJs(btnsaveaspdfwiever);
                Thread.Sleep(3000);
                if (driverobj.selectWindow("WaivedPrerequisitesPrint.aspx"))
                {
                    driverobj.Close();
                    Thread.Sleep(2000);
                    driverobj.SwitchTo().Window(originalHandle);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool checkexpired()
        {
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckexpired);
                driverobj.ClickEleJs(lnkcheckexpired);
                driverobj.WaitForElement(By.CssSelector("div[id*='ctl00_MainContent_UC1_rgExpiredLearning']"));
                return true;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool printexpired()
        {
            try
            {
                string firstitemtext = string.Empty;
                string printtext = string.Empty;
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckexpired);
                driverobj.ClickEleJs(lnkcheckexpired);
                Thread.Sleep(3000);
                driverobj.WaitForElement(By.Id("MainContent_UC1_MLinkButton2"));
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(By.CssSelector("span[class*='fa-print']")).Click();
                Thread.Sleep(3000);
                if (driverobj.selectWindow("ExpiredLearningPrint.aspx"))
                {
                    string printNewWindowPS = driverobj.PageSource;
                    driverobj.Close();
                    Thread.Sleep(3000);
                    driverobj.SwitchTo().Window(originalHandle);
                    if (printNewWindowPS.Contains("Expired Incomplete Content"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }

        public bool savepdfexpired()
        {
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckexpired);
                driverobj.ClickEleJs(lnkcheckexpired);
                Thread.Sleep(3000);
                //Thread.Sleep(3000);
                driverobj.WaitForElement(btnsaveaspdfexpired);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btnsaveaspdfexpired).ClickWithSpace();
                Thread.Sleep(3000);
                if (driverobj.selectWindow("ExpiredLearningPrint.aspx"))
                {
                    Thread.Sleep(2000);
                    driverobj.Close();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public void click_moreinfo()
        {
            try
            {
                driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath("//a[@href='/Transcript/AllMyTraining.aspx']"));
                driverobj.WaitForElement(btn_moreinfo);
                driverobj.ClickEleJs(btn_moreinfo);
                driverobj.WaitForElement(btn_moreinfo);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                
            }
        }



        public bool checkexemptions()
        {
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Training Assignment Exemptions')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Training Assignment Exemptions')]"));
                Thread.Sleep(3000);
                driverobj.WaitForElement(currentexemptionitems);
                driverobj.WaitForElement(pastexemptionitems);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }

        public bool printexemptions()
        {
            bool actualresult = false;

            try
            {
                string currprinttext = string.Empty;
                string pastfirstitemtext = string.Empty;
                string pastprinttext = string.Empty;
                click_moreinfo();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Training Assignment Exemptions')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Training Assignment Exemptions')]"));
                Thread.Sleep(3000);
                driverobj.WaitForElement(currentexemptionitems);
                driverobj.WaitForElement(btnprintcurrentexemption);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.ClickEleJs(btnprintcurrentexemption);
                Thread.Sleep(3000);

                if (driverobj.selectWindow("Current Exemptions"))
                {
                    string newWindowPopupPS = driverobj.PageSource;
                    driverobj.Close();
                    Thread.Sleep(1000);
                    driverobj.SwitchTo().Window(originalHandle);
                    if (newWindowPopupPS.Contains("Current Exemptions"))
                    {
                        actualresult = true;
                    }
                }
                else return false;
                Thread.Sleep(3000);
                driverobj.WaitForElement(pastexemptionitems);
                driverobj.WaitForElement(btnprintpastexemption);
                originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btnprintpastexemption).ClickWithSpace();
                Thread.Sleep(3000);
                if (driverobj.SwitchWindow("Past Exemptions"))
                {
                    string pastprintNewWindowPS = driverobj.PageSource;
                    driverobj.Close();
                    Thread.Sleep(3000);
                    driverobj.SwitchTo().Window(originalHandle);
                    //driverobj.GetElement(btncloseframe).ClickWithSpace();
                    if (pastprintNewWindowPS.Contains("Past Exemptions"))
                    {
                        actualresult = true;
                    }
                }
                else return false;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                actualresult = false;
            }
            return actualresult;
        }

        public bool savepdfexemptions()
        {
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Training Assignment Exemptions')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Training Assignment Exemptions')]"));
                Thread.Sleep(3000);
                driverobj.WaitForElement(currentexemptionitems);
                driverobj.WaitForElement(btnsaveaspdfcurrentexemption);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_UC2_SaveAsPDF']"));
                Thread.Sleep(3000);
                driverobj.selectWindow("RequiredTrainingExemptionsCurrentPrint.aspx");  
                driverobj.Close();
                Thread.Sleep(1000);
                driverobj.SwitchTo().Window(originalHandle);
                Thread.Sleep(3000);
                driverobj.WaitForElement(pastexemptionitems);
                driverobj.WaitForElement(btnsaveaspdfpastexemption);
                originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btnsaveaspdfpastexemption).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.selectWindow("RequiredTrainingExemptionsPastPrint.aspx");
                driverobj.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool checkpdffilesandnotes()
        {
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckpdfandfiles);
                driverobj.ClickEleJs(lnkcheckpdfandfiles);
                Thread.Sleep(3000);
                driverobj.WaitForElement(pdflink);
                driverobj.WaitForElement(seemorelink);
                return true;
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool clickseemore()
        {
            bool actualresult = false;
            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckpdfandfiles);
                driverobj.GetElement(lnkcheckpdfandfiles).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(seemorelink);
                driverobj.GetElement(seemorelink).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(seemoretextbox);
                driverobj.GetElement(seemorecanclebtn).ClickWithSpace();

                actualresult = true;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                actualresult = false;
            }

            return actualresult;

        }

        public bool viewpdf()
        {

            try
            {
                click_moreinfo();
                driverobj.WaitForElement(lnkcheckpdfandfiles);
                driverobj.ClickEleJs(lnkcheckpdfandfiles);
                if (driverobj.existsElement(firstPdfFile))
                {
                    driverobj.WaitForElement(pdflink);
                    string originalHandle = driverobj.CurrentWindowHandle;
                    driverobj.GetElement(pdflink).ClickWithSpace();
                    Thread.Sleep(3000);
                    driverobj.selectWindow(pdfpagetitle);
                    driverobj.Close();
                    Thread.Sleep(3000);
                    driverobj.SwitchTo().Window(originalHandle);
                }
                return true;
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }

        }



        private By adminconsoleopenlink = By.Id("NavigationStrip1_lbAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By txttraininghomesearch = By.Id("MainContent_ucQuickSearch_txtSearch");
        private By cmbtraininghomesearch = By.Id("ddlSearchType");
        private By btntraninghomesearch = By.Id("btnSearch");
       // private By courselink = By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr + "WP0" + "')]");
        private By btnrequestwiever = By.Id("btnManagePrequisites");
        private By chkrequestwiever = By.Id("ctl00_MainContent_UC1_rgPrequisite_ctl00_ctl04_chkSelect");
        private By btnsaverequestwiever = By.Id("MainContent_UC1_Save");
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");
        private By linkwieverconsole = By.LinkText("Waiver Console");
        private By txtcourseforwiever = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btncoursesearchforwiever = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By btngoforwiever = By.Id("TabMenu_ML_BASE_TAB_Search_CONTENT_GoButton_1");
        private By txtsearchuserforwiever = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btnsearchuserforwiever = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By chkuserforwiever = By.XPath("//input[@type='checkbox']");
        private By chkassignwiever = By.Id("TabMenu_ML_BASE_TAB_Search_AssignEntities");
        private By returnfeedback = By.XPath("//span[@id='ReturnFeedback']");
        private By lnktranscript = By.XPath("//a[contains(.,'Transcript')]");//By.XPath("//div[@id='ctl00_SiteNavigationBar2_rdNavigationMenu']/ul/li[3]/a/span");
        private By lnkcheckwiever =By.XPath("//a[contains(.,'Waived Prerequisites')]");
       // private By lblweivercourse = By.XPath("//td[contains(text(),'" + ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr + "WP0" + "')]");
        private By lblwievertype = By.XPath("//td[contains(text(),'Classroom')]");
        private By btncloseframe = By.CssSelector("span.k-icon.k-i-close");
        private By btnprintwiever = By.Id("MainContent_UC1_MLinkButton2");
        private By printwindowwievedtext = By.CssSelector("div[class='portlet']");
        private By btnsaveaspdfwiever = By.Id("MainContent_UC1_SaveAsPDF");

        private By lnkcheckexpired =By.XPath("//a[contains(.,'Expired Incomplete Content')]");
        private By expiredfirstitem = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00__0");
        private By btnprintexpired = By.Id("MainContent_UC1_MLinkButton1");
        private By expiredfirstitemtext = By.XPath("//tr[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[1]");
        private By printwindowexpiredtext = By.XPath("//tr[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[1]");
        private By btnsaveaspdfexpired = By.Id("MainContent_UC1_SaveAsPDF");

        private By lnkcheckexemptions = By.XPath("//a[contains(.,'Required Training Exemptions')]");


        private By currentexemptionitems = By.CssSelector("div[id*='_MainContent_UC1_rgRTCurrentExempts']");
        private By btnprintcurrentexemption = By.Id("MainContent_UC1_MLinkButton1");
        private By currentexemptionfirstitemtext = By.XPath("//tr[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[1]");
        private By printwindowcurrentexemptiontext = By.XPath("//tr[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[1]");
        private By btnsaveaspdfcurrentexemption = By.Id("MainContent_UC1_SaveAsPDF");

        private By pastexemptionitems = By.CssSelector("div[id*='_MainContent_UC2_rgRTPastExempts']");
        private By btnprintpastexemption = By.Id("MainContent_UC2_MLinkButton1");
        private By pastexemptionfirstitemtext = By.XPath("//tr[@id='ctl00_MainContent_UC2_RadGrid1_ctl00__0']/td[1]");
        private By printwindowpastexemptiontext = By.XPath("//tr[@id='ctl00_MainContent_UC2_RadGrid1_ctl00__0']/td[1]");
        private By btnsaveaspdfpastexemption = By.Id("MainContent_UC2_SaveAsPDF");


        private By lnkcheckpdfandfiles = By.XPath("//a[contains(.,'View PDF Files and Notes')]");


        private By pdflink = By.CssSelector("div[id*='_MainContent_UC1_gdPDFFiles']");
        private By seemorelink = By.CssSelector("div[id*='_MainContent_UC2_grdNotes']");
        private By seemoretextbox = By.Id("MainContent_UC1_lblNote");
        private By seemorecanclebtn = By.Id("MainContent_UC1_btnCancel");
        private string pdfpagetitle = "ViewTranscriptAttachment.aspx";
        private By btn_moreinfo = By.Id("MainContent_ucQLinks_moreInfoBtn");
        private By firstPdfFile = By.CssSelector("tr[id*='_MainContent_UC1_gdPDFFiles_ctl00__0']");
    }
}
