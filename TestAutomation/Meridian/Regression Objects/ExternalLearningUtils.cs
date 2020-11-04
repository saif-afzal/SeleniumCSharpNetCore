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
    class ExternalLearningUtils
    {
        private readonly IWebDriver driverobj;
        public ExternalLearningUtils(IWebDriver driver)
        {
            driverobj = driver;
        }


        public void ClickTranscriptELLink()
        {


            try
            {
                driverobj.WaitForElement(ObjectRepository.TranscriptHome);
                driverobj.GetElement(ObjectRepository.TranscriptHome).Click();
                driverobj.WaitForElement(ObjectRepository.TranscriptELLink);
                driverobj.GetElement(ObjectRepository.TranscriptELLink).Click();


            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on External Learning Link on Transcript Page", driverobj);
                //Assert.Fail(ex.Message);
            }

        }
        public string CreateELType(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                // ExtractDataExcel.Product();
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.WaitForElement(ObjectRepository.eltype_link);
                driverobj.GetElement(ObjectRepository.eltype_link).ClickAnchor();

                driverobj.WaitForElement(ObjectRepository.eltypegobutton);
                driverobj.GetElement(ObjectRepository.eltypegobutton).Click();
                driverobj.WaitForElement(ObjectRepository.eltypetitle);
                //Thread.Sleep(2000);
                driverobj.GetElement(ObjectRepository.eltypetitle).SendKeys(ExtractDataExcel.MasterDic_ELType["Title"]+browserstr);
                driverobj.GetElement(ObjectRepository.eltypedesc).SendKeys(ExtractDataExcel.MasterDic_ELType["Desc"]);

                driverobj.GetElement(ObjectRepository.eltypecreate).Click();
                driverobj.WaitForElement(ObjectRepository.eltypesave);
                driverobj.GetElement(ObjectRepository.eltypesave).Click();
                driverobj.WaitForElement(ObjectRepository.eltypesucessmsg);
                actualresult = driverobj.GetElement(ObjectRepository.eltypesucessmsg).Text;
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                //driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool CreateEL(string browserstr)
        {
            bool actualresult = false;
            try
            {
                // ExtractDataExcel.Product();
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElementOnPage(ObjectRepository.el_link);
                driverobj.GetElement(ObjectRepository.el_link).Click();

                driverobj.WaitForElement(ObjectRepository.elgobutton);
                driverobj.GetElement(ObjectRepository.elgobutton).Click();
                driverobj.WaitForElement(ObjectRepository.eltitle);
                //Thread.Sleep(2000);
                driverobj.GetElement(ObjectRepository.eltitle).SendKeys(ExtractDataExcel.MasterDic_EL["Title"]+browserstr);
                driverobj.GetElement(ObjectRepository.eldescription).SendKeys(ExtractDataExcel.MasterDic_EL["Desc"]);
                driverobj.GetElement(ObjectRepository.elkeyword).SendKeys(ExtractDataExcel.MasterDic_EL["Desc"]);
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_CONTACT_INFO")).SendKeys(ExtractDataExcel.MasterDic_EL["Desc"]);
                driverobj.FindSelectElementnew(ObjectRepository.eltypeselect, ExtractDataExcel.MasterDic_ELType["Title"]+browserstr);
                // driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_NUMBER")).SendKeys("el" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ObjectRepository.elcreate).Click();
                driverobj.WaitForElement(ObjectRepository.checkin);
                driverobj.GetElement(ObjectRepository.checkin).Click();
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                //driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool SearchEL(string browserstr)
        {
            bool actualresult = false;
            try
            {
                //ExtractDataExcel.GeneralCourse();
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();
                driverobj.WaitForElement(ObjectRepository.CourseName_Ed);
                driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeys(ExtractDataExcel.MasterDic_EL["Title"]+browserstr);//ExtractDataExcel.generalcourse("name"));
                driverobj.FindSelectElementnew(ObjectRepository.CourseName_Typ, ObjectRepository.filterdropdowntext);
                driverobj.GetElement(ObjectRepository.CourseSearch_Btn).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_EL["Title"]+browserstr + "')]"));

                actualresult = true;
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool requestelEL(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"]+browserstr + "')]")).ClickAnchor();
                driverobj.WaitForElement(ObjectRepository.elsubmitrequestbutton);
                driverobj.GetElement(ObjectRepository.elsubmitrequestbutton).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.elrequestreason); ;
                driverobj.GetElement(ObjectRepository.elrequestreason).SendKeys("Test Reason");

                driverobj.GetElement(ObjectRepository.elrequestdateobtained).SendKeys(DateTime.Now.ToString(format));
                driverobj.GetElement(By.Id("MainContent_UC1_fvSubmitRequest_ELR_TUITION_REIMBURSEMENT_1")).Click();
                driverobj.GetElement(ObjectRepository.elrequestsubmitrequestbtn).Click();

                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//ExtractDataExcel.MasterDic_EL["Title"]+browserstr
                actualresult = true;
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }


        string format = "MM/dd/yyyy";
        public bool ApproveEL(string browserstr)
        {
            bool actualresult = false;
            try
            {
                // ExtractDataExcel.Product();
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElementOnPage(ObjectRepository.elconsole_link);
                driverobj.GetElement(ObjectRepository.elconsole_link).ClickAnchor();

                driverobj.WaitForElement(ObjectRepository.eluserfirstname);
                driverobj.GetElement(ObjectRepository.eluserfirstname).SendKeys(ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr.ToString());
                driverobj.GetElement(ObjectRepository.elusersearch).Click();
                driverobj.WaitForElement(ObjectRepository.elgoforaction);
                driverobj.GetElement(ObjectRepository.elgoforaction).Click();
                driverobj.WaitForElement(ObjectRepository.elapprovecheck);
                driverobj.GetElement(ObjectRepository.elapprovecheck).Click();

                driverobj.WaitForElement(ObjectRepository.elexpirydate);
                string expirydate = DateTime.Now.AddDays(1).ToString(format);
                Thread.Sleep(2000);
                driverobj.GetElement(ObjectRepository.elexpirydate).Clear();
                driverobj.GetElement(ObjectRepository.elexpirydate).SendKeys(expirydate);
                driverobj.GetElement(ObjectRepository.elapprovereason).SendKeys("Test Reason");
                driverobj.GetElement(ObjectRepository.eltakeaction).Click();
                driverobj.WaitForElement(ObjectRepository.elconsolesucessmsg);




                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool CheckELItems(string browserstr)
        {
            bool actualresult = false;
            string format = "M/dd/yyyy";
            try
            {
                ClickTranscriptELLink();

                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"]+browserstr + "')]"));
                driverobj.WaitForElement(By.XPath("//td[contains(text(),'" + ExtractDataExcel.MasterDic_ELType["Title"]+browserstr + "')]"));
                //driverobj.WaitForElement(By.XPath("//td[contains(text(),'" + DateTime.Now.ToString(format) + "')]"));
                //driverobj.WaitForElement(By.XPath("//td[contains(text(),'" + DateTime.Now.AddDays(1).ToString(format) + "')]"));
                //driverobj.WaitForElement(By.XPath("//td[contains(text(),'Approved')]"));
                //driverobj.WaitForElement(By.XPath("//td[contains(text(),'Test Reason')]"));
                actualresult = true;
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public string ClickSubmitRequestBtn()
        {
            string actualresult = string.Empty;

            try
            {
                ClickTranscriptELLink();

                driverobj.WaitForElement(ObjectRepository.elsubmitrequestbtn);
                driverobj.GetElement(ObjectRepository.elsubmitrequestbtn).Click();
                driverobj.WaitForElement(ObjectRepository.elsearchforbtn);
                actualresult = driverobj.Title.Trim();
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool ClickELItem(string browserstr)
        {
            bool actualresult = false;

            try
            {
                ClickTranscriptELLink();

                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"]+browserstr + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"]+browserstr + "')]")).ClickAnchor();
                Thread.Sleep(2000);
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//ExtractDataExcel.MasterDic_EL["Title"]+browserstr
                actualresult = true;
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool ClickELPrintBtn(string browserstr)
        {
            bool actualresult = false;

            try
            {
                ClickTranscriptELLink();
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"]+browserstr + "')]"));
                driverobj.GetElement(ObjectRepository.elprintbtn).ClickAnchor();

                Thread.Sleep(3000);
                driverobj.selectWindow(ObjectRepository.elprintpagetitle);
                Thread.Sleep(6000);
                driverobj.WaitForElement(ObjectRepository.elprintpagelink);
                //driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);
                actualresult = true;

            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool ClickELPDFBtn(string browserstr)
        {
            bool actualresult = false;

            try
            {
                ClickTranscriptELLink();
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"]+browserstr + "')]"));
                driverobj.GetElement(ObjectRepository.elsaveaspdfbtn).ClickAnchor();
                Thread.Sleep(3000);
                driverobj.SwitchWindow(ObjectRepository.elpdfpagetitle);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.selectWindow(originalHandle);
                Thread.Sleep(8000);
                actualresult = true;

            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }


    }
}

