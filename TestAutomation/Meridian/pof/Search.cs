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
    class Search
    {
        private readonly IWebDriver driverobj;

        public Search(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_SearchCompetency(string type)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_search_competency);
                driverobj.GetElement(txt_search_competency).SendKeysWithSpace(type);
                driverobj.WaitForElement(cmb_competency_type);
                driverobj.WaitForElement(cmb_competency_searchtype);
                driverobj.WaitForElement(btn_return);
                driverobj.GetElement(btn_search).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Searchorganization(string type)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_search);
                driverobj.GetElement(txt_search).SendKeysWithSpace(type);
                driverobj.WaitForElement(cmb_organization_type);
                driverobj.WaitForElement(cmb_organization_searchtype);
                driverobj.FindSelectElementnew(cmb_organization_searchtype, "Exact phrase");
                driverobj.WaitForElement(btn_cancle);
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'"+type+"')]"));

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_addorganization()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(chk_addorganization);
              //  driverobj.GetElement(chk_addorganization).ClickWithSpace();
                driverobj.ClickEleJs(chk_addorganization);
                driverobj.WaitForElement(btn_addorganization);
                driverobj.GetElement(btn_addorganization).ClickWithSpace();
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

        public bool Click_addcompetency()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(chk_addcompetency);
              //  driverobj.GetElement(chk_addcompetency).ClickWithSpace();
                driverobj.ClickEleJs(chk_addcompetency);
                driverobj.WaitForElement(btn_addcompetency);
                driverobj.GetElement(btn_addcompetency).ClickWithSpace();
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
        private By txt_search = By.Id("MainContent_UC1_txtSearchFor");
        private By txt_search_competency = By.Id("MainContent_UC1_SearchFor");
        
        private By btn_search = By.Id("btnSearch");
        private By btn_return = By.Id("MainContent_UC1_btnReturn");

        private By btn_cancle = By.Id("MainContent_UC1_Cancel");

        private By cmb_competency_searchtype = By.Id("MainContent_UC1_SearchType");
        private By cmb_competency_type = By.Id("MainContent_UC1_strType");

        private By cmb_organization_searchtype = By.Id("MainContent_UC1_ddlSearchType");
        private By cmb_organization_type = By.Id("MainContent_UC1_ddlEntityType");

        private By chk_addorganization = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_chkSelect");
        private By btn_addorganization = By.Id("MainContent_UC1_btnAdd");

        private By chk_addcompetency = By.Id("ctl00_MainContent_UC1_rgCompetency_ctl00_ctl04_chkAdd");
        private By btn_addcompetency = By.Id("MainContent_UC1_btnAdd");

        private By lblsucess = By.XPath("//div[@class='alert alert-success']");
        


    }
}
