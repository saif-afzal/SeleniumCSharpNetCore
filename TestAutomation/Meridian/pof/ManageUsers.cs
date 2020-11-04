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
    class ManageUsers
    {
        private readonly IWebDriver driverobj;

        public ManageUsers(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_CreateNewUserLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_createnewuser);
                driverobj.GetElement(lnk_createnewuser).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
            }

            return result;
        }

        public bool populateaccountsearchform(string firstname,string lastname)
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.Id("SEARCH_FOR"));
                driverobj.GetElement(By.Id("SEARCH_FOR")).SendKeysWithSpace(firstname);
             //   driverobj.GetElement(By.Id("USR_LAST_NAME")).SendKeysWithSpace(lastname);
              
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }


        public bool Click_SearchUser()
        {
            By btn_searchuser = By.Id("btnSearchClientSide");
            bool result = false;
            try
            {
               
                driverobj.WaitForElement(btn_searchuser);
                driverobj.ClickEleJs(btn_searchuser);
                Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath("//a[contains(@class,'btn btn-default go')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }

        public string passwordcreationnewuser()
        {
            By cmb_action = By.XPath("//select[@id='ddlUsrAction_0']");
            //    By btn_gotoaction = By.XPath(".//*[@id='btnGo']");
            By btn_gotoaction = By.XPath("//a[@class='btn btn-default go']");
            try
            {
                driverobj.WaitForElement(cmb_action);
                driverobj.select(cmb_action, "Login Assistance");
                driverobj.WaitForElement(btn_gotoaction);
                driverobj.GetElement(btn_gotoaction).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));               
                driverobj.GetElement(btn_savepassword).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchtoDefaultContent();
                driverobj.WaitForElement(lbl_success);
                string msgstring = driverobj.GetElement(lbl_success).Text;
                var elements = msgstring.Split(' ');
                string passwd = string.Empty;
                if (Meridian_Common.MeridianTestbrowser == "iebs"||Meridian_Common.MeridianTestbrowser ==null)
                {
                    string text = string.Empty;
                    text = driverobj.GetBrwser();
                    if (text == "chrome"||text=="IE")//used IE as safari need to change
                    {
                        passwd = elements[5];

                    }
                    else
                    {
                        passwd = elements[6];
                    }
                }

                else
                {
                     passwd = elements[5];
                }
                passwd = passwd.Replace(".", "");
                Thread.Sleep(2000);
                driverobj.ClickEleJs(By.XPath("//a[@id='ph_avatar']"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Logout')]"));
                return passwd;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }

        }

        public bool verify_customFieldVisible(String customFieldLabel)
        {
            By lbl_customField = By.XPath("//label[contains(text(),'"+ customFieldLabel +"')]");
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_seeMoreSearchCriteria);
                driverobj.GetElement(lnk_seeMoreSearchCriteria).Click();
                driverobj.WaitForElement(lbl_customField);
                

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }



        private By lnk_seeMoreSearchCriteria = By.Id("MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_lblSeeMore");
        private By lnk_createnewuser = By.Id("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser");
        private By txt_searchfirstname = By.Id("MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_FIRST_NAME");
        private By txt_searchlastname = By.Id("MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_USR_LAST_NAME");
        private By btn_searchuser = By.Id("MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_btnSearch");
        private By lbl_firstuser = By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_lblUsrLastName");
        private By cmb_action = By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction");
        private By btn_gotoaction = By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_btnGo");
        private By btn_savepassword = By.Id("MainContent_UC1_Save");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");

    }
}
