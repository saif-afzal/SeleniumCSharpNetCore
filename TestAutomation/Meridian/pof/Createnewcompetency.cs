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
    class Createnewcompetency
    {
        private readonly IWebDriver driverobj;

        public Createnewcompetency(IWebDriver driver)
        {
            driverobj = driver;
        }
       
        public bool Click_Create(string title,string type, string typeofcompetency)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace(title+type);
                driverobj.FindSelectElementnew(cmb_type, typeofcompetency);
                Thread.Sleep(10000);
                driverobj.SetDescription(title);

                if (typeofcompetency == "Performance Competency")
                {
                    driverobj.WaitForElement(rb_proficencyscale);
                   // driverobj.GetElement(rb_proficencyscale).Click();
                    driverobj.ClickEleJs(rb_proficencyscale);
                }
                driverobj.WaitForElement(btn_cancel);
                driverobj.GetElement(btn_create).ClickWithSpace();
               result = driverobj.existsElement(lblsucess);
                
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Save(string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_title);

                driverobj.GetElement(txt_keyword).SendKeysWithSpace(Variables.SkillGroupTitle+browserstr + " Edited");
              
                driverobj.WaitForElement(btn_cancel_EditPage);
                driverobj.GetElement(btn_create).ClickWithSpace();
              result = driverobj.existsElement(lblsucess);

                
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        private By txt_title = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        private By cmb_type = By.Id("MainContent_UC1_FormView1_DL_Type");
        private By txt_desc = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By txt_keyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        private By rb_proficencyscale = By.Id("ctl00_MainContent_UC1_ProfeciencyScale_rgProficiencyScale_ctl00_ctl08_rdoSelect");
        private By btn_create = By.Id("MainContent_UC1_Save");
        private By btn_cancel = By.Id("MainContent_UC1_btnCancel");
        private By btn_cancel_EditPage = By.Id("MainContent_UC1_btnReturn");
        private By lblsucess = By.XPath("//div[@class='alert alert-success']");
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");



    }
}
