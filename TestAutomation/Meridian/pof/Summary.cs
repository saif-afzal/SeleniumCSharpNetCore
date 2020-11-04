using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class Summary
    {

        private readonly IWebDriver driverobj;

        public Summary(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Fill_AICCTitle(string type, string browserstr)
        {
            try
            {
                driverobj.WaitForElement(lbl_successmsg);
                driverobj.WaitForElement(txt_aicc_title);
                driverobj.GetElement(txt_aicc_title).Clear();
                driverobj.GetElement(txt_aicc_title).SendKeys(Variables.aicccourseTitle+browserstr+ type);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool Click_SaveAICC()
        {
            try
            {
                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
                Thread.Sleep(4000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public void FillScormPage(string browserstr)
        {

            try
            {
                driverobj.WaitForElement(scromtitle);
                driverobj.GetElement(scromtitle).Clear();
                Thread.Sleep(3000);
                driverobj.GetElement(scromtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr);
               
                driverobj.WaitForElement(create_btn_new);
                driverobj.GetElement(create_btn_new).ClickWithSpace();
                driverobj.WaitForElement(CheckinNew);


                //result = generalCourse.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
        }
        private By lbl_successmsg = By.XPath("//div[@class='alert alert-success']");
        private By txt_aicc_title = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        private By btn_save = By.Id("MainContent_UC1_Save");
        private By scromtitle = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        private  By create_btn_new = By.Id("MainContent_UC1_Save");
        private By CheckinNew = By.Id("MainContent_header_FormView1_btnStatus");
    }
}
