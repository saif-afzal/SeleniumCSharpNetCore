using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium2.Meridian;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Utility;
using System.Reflection;
using relativepath;

namespace Selenium2.Meridian
{
    class Organization
    {
        private readonly IWebDriver driverobj;

        public Organization(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_CreateGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_creategoto);
             //   driverobj.GetElement(btn_creategoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_creategoto);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Organization", driverobj);
            }

            return result;
        }

        public bool Click_Create(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace(Variables.organizationTitle+browserstr);
                driverobj.GetElement(txt_desc).SendKeysWithSpace(Variables.organizationTitle+browserstr);
               // driverobj.GetElement(txt_orgcode).SendKeysWithSpace(Variables.organizationTitle+browserstr);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_sucess);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_Search(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_search);
                driverobj.GetElement(txt_search).Clear();
                driverobj.GetElement(txt_search).SendKeysWithSpace(Variables.organizationTitle+browserstr);
               
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + Variables.organizationTitle+browserstr + "')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        public bool Click_Create(string type, string parent, string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace(Variables.organizationTitle+browserstr + type);
                driverobj.GetElement(txt_desc).SendKeysWithSpace(Variables.organizationTitle+browserstr);
                //driverobj.GetElement(txt_orgcode).SendKeysWithSpace(Variables.organizationTitle+browserstr);
                if(parent!=string.Empty)
                {
                    driverobj.FindSelectElementnew(cmb_parent, parent);
                }
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_sucess);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Click_ManageGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_managegoto);
                driverobj.GetElement(btn_managegoto).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        private By btn_creategoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_title = By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_TITLE");
        private By txt_desc = By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_DESCRIPTION");
        private By txt_orgcode = By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_ORGANIZATION_CODE");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By txt_search = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By btn_managegoto = By.Id("TabMenu_ML_BASE_TAB_Search_OrganizationListingDataGrid_ctl02_GoButton");
        private By lbl_sucess = By.XPath("//span[@id='ReturnFeedback']");
        private By cmb_parent = By.Id("TabMenu_ML_BASE_TAB_EditOrganization_ORG_PARENT_ID");
       



    }
}
