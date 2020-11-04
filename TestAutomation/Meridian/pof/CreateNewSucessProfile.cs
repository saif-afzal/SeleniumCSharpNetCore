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
    class CreateNewSucessProfile
    {
        private readonly IWebDriver driverobj;

        public CreateNewSucessProfile(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_Create(string Title, string type, string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace(Title + type);
                
                driverobj.SetDescription(Variables.SuccessProfileTitle+browserstr + type);
                
                driverobj.WaitForElement(cmb_contentowner);
                driverobj.WaitForElement(rb_activity);
                driverobj.WaitForElement(btn_cancel);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lnk_addcompetency);
               result = driverobj.existsElement(lnk_addorganization);
               
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

     


        private By txt_title = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        private By txt_desc = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By cmb_contentowner = By.Id("MainContent_UC1_DL_DOMAIN_ID");
        private By rb_activity = By.Id("MainContent_UC1_rdoActive");
        private By btn_create = By.Id("MainContent_UC1_Save");
        private By btn_cancel = By.Id("MainContent_UC1_btnReturn");
        private By lnk_addcompetency = By.Id("MainContent_UC1_hlAddCompetency");
        private By lnk_addorganization = By.Id("MainContent_UC1_hlAddJob");
        private By lblsucess = By.XPath("//div[@class='alert alert-success']");



    }
}
