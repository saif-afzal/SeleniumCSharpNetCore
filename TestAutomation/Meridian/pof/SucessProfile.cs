using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class SucessProfile
    {
        private readonly IWebDriver driverobj;

        public SucessProfile(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_Save(string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_title);
                //if (!driverobj.existsElement(txt_desc))
                //{
                //    driverobj.SelectFrame();
                //    driverobj.GetElement(By.CssSelector("body")).ClickWithSpace();
                //    driverobj.GetElement(By.CssSelector("body")).SendKeysWithSpace(Variables.SuccessProfileTitle+browserstr + "updated");
                //    driverobj.SwitchTo().DefaultContent();
                //}
                //else
                //{
                //    driverobj.GetElement(txt_desc).SendKeysWithSpace(Variables.SuccessProfileTitle+browserstr + "updated");
                //}
                
                if (driverobj.existsElement(txt_keyword))
                {
                    driverobj.GetElement(txt_keyword).SendKeysWithSpace(Variables.SuccessProfileTitle+browserstr + "updated");
                }
                else
                {
                    driverobj.SetDescription(Variables.SuccessProfileTitle+browserstr + "updated");
                }
                driverobj.WaitForElement(rb_activity);
                driverobj.WaitForElement(btn_cancel);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lblsucess);
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_AddCompetency()
        {
            bool result = false;

            try
            {

             
                driverobj.WaitForElement(lnk_addcompetency);
                driverobj.GetElement(lnk_addcompetency).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_AddOrganization()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_addjob);
                driverobj.GetElement(lnk_addjob).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Click_SaveTarget(string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_desc).Clear();
                driverobj.GetElement(txt_desc).SendKeysWithSpace(Variables.SuccessProfileTitle+browserstr + "updated");
                driverobj.WaitForElement(rb_activity);
                driverobj.WaitForElement(btn_cancel);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lblsucess);
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Back()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_cancel);
               
                driverobj.GetElement(btn_cancel).ClickWithSpace();
                driverobj.WaitForElement(btn_cancel);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Cancel()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_cancel);

                driverobj.GetElement(btn_cancel).ClickWithSpace();
                
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_EditSP()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_EditSP);

                driverobj.GetElement(btn_EditSP).ClickWithSpace();

                driverobj.WaitForElement(txt_title);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Edit_Save(string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_title_edit);
                

                
                    driverobj.GetElement(txt_keyword).SendKeysWithSpace(Variables.SuccessProfileTitle+browserstr + "updated");
                
                
                driverobj.WaitForElement(btn_cancel_edit);
                driverobj.GetElement(btn_save_edit).ClickWithSpace();
                driverobj.WaitForElement(lblsucess);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        private By btn_EditSP = By.Id("MainContent_MainContent_ucSummary_lnkEdit");
        private By txt_title = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        private By txt_title_edit = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE");
        private By txt_desc = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By txt_keyword = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        private By cmb_contentowner = By.Id("MainContent_UC1_DL_DOMAIN_ID");
        private By rb_activity = By.Id("MainContent_UC1_rdoActive");
        private By btn_save = By.Id("MainContent_UC1_Save");
        private By btn_save_edit = By.Id("MainContent_MainContent_UC1_Save");
        private By btn_cancel = By.Id("MainContent_UC1_btnReturn");
        private By btn_cancel_edit = By.Id("MainContent_MainContent_UC1_btnCancel");
        private By lnk_addcompetency = By.Id("MainContent_UC1_hlAddCompetency");
        private By lnk_addjob = By.Id("MainContent_UC1_hlAddJob");
        private By lblsucess = By.XPath("//div[@class='alert alert-success']");
        private By cmb_targetdata = By.Id("ctl00_MainContent_UC1_Success_Profile_ctl00_ctl04_ddlTarget_");
        private By chk_critical = By.Id("ctl00_MainContent_UC1_Success_Profile_ctl00_ctl04_chkCritical_");

 

    }
}
