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
  class ManagePricingSchedule
    {
        private readonly IWebDriver driverobj;

        public ManagePricingSchedule(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_Add_New_Pricing_Schedule()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_addnewpricingschedule);
                driverobj.GetElement(lnk_addnewpricingschedule).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
            }

            return result;
        }

        public string Click_Create()
        {
            string result = string.Empty ;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleCreate);
                driverobj.GetElement(btn_PriceScheduleCreate).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = driverobj.GetElement(lbl_success).Text;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }

        string format = "M/d/yyyy";
        public bool Select_Valid_From()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(dtp_validfrom);
                driverobj.GetElement(dtp_validfrom).SendKeys(DateTime.Now.ToString(format));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
            }

            return result;
        }
        public bool PopulatePricingScheduleName(string PricingScheduleName)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_PricingScheduleName);
                driverobj.GetElement(txt_PricingScheduleName).SendKeysWithSpace(PricingScheduleName);



                actualresult = true;
            }
            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(Meridian_Common.CurrentTestName + "--" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                throw new ElementNotVisibleException("---Name of Class->" + this.GetType().Name + "---Name of Method->" + MethodBase.GetCurrentMethod().Name + "---Error Message->" + ex.Message);

            }
            return actualresult;
        }

        public bool PopulatePriceScheduleDescription()
        {
            bool actualresult = false;
            try
            {
                driverobj.SetDescription("Test Desc");



                actualresult = true;
            }
            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(Meridian_Common.CurrentTestName + "--" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                throw new ElementNotVisibleException("---Name of Class->" + this.GetType().Name + "---Name of Method->" + MethodBase.GetCurrentMethod().Name + "---Error Message->" + ex.Message);

            }
            return actualresult;
        }


        public bool PopulatePricingScheduleSearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_PricingScheduleSearch);
                driverobj.GetElement(txt_PricingScheduleSearch).SendKeysWithSpace(Variables.PriceScheduleNameObj+browserstr);



                actualresult = true;
            }
            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(Meridian_Common.CurrentTestName + "--" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                throw new ElementNotVisibleException("---Name of Class->" + this.GetType().Name + "---Name of Method->" + MethodBase.GetCurrentMethod().Name + "---Error Message->" + ex.Message);

            }
            return actualresult;
        }


        public string Click_Search()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleSearch);
                driverobj.ClickEleJs(btn_PriceScheduleSearch);
                driverobj.WaitForElement(btn_PriceScheduleManage);
              
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }
        public string Click_Manage()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleManage);
                driverobj.ClickEleJs(btn_PriceScheduleManage);
                
              
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }

        public string Click_Copy()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleCopy);
                driverobj.GetElement(btn_PriceScheduleCopy).ClickWithSpace();


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }
        public string Click_AddContent()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleAddContent);
                driverobj.GetElement(btn_PriceScheduleAddContent).ClickWithSpace();

                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }
        public string Click_Add_UserGroup()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleAddUserGroup);
                driverobj.ClickEleJs(btn_PriceScheduleAddUserGroup);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }
        public string Click_AddContent_Search()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleAddContentSearch);
                driverobj.GetElement(btn_PriceScheduleAddContentSearch).ClickWithSpace();

               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }
        public string Click_AddUserGroup_Search()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleAddUserGroupSearch);
                driverobj.GetElement(btn_PriceScheduleAddUserGroupSearch).ClickWithSpace();


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }
        public bool PriceSchedule_Select_Content()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chkbox_PriceScheduleContent);
              //  driverobj.GetElement(chkbox_PriceScheduleContent).ClickWithSpace();
                driverobj.ClickEleJs(chkbox_PriceScheduleContent);


                actualresult = true;
            }
            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(Meridian_Common.CurrentTestName + "--" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                throw new ElementNotVisibleException("---Name of Class->" + this.GetType().Name + "---Name of Method->" + MethodBase.GetCurrentMethod().Name + "---Error Message->" + ex.Message);

            }
            return actualresult;
        }

        public string Click_Add_Content()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleSave);
                driverobj.ClickEleJs(btn_PriceScheduleSave);
                driverobj.WaitForElement(lbl_success);
                result = driverobj.GetElement(lbl_success).Text;

                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }
        public string Click_AddUserGroup()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_PriceScheduleAdd);
                driverobj.GetElement(btn_PriceScheduleAdd).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = driverobj.GetElement(lbl_success).Text;


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link for Creating a User", driverobj);
                result = "";
            }

            return result;
        }

        public bool PopulateUserGroupCost()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_PricingScheduleGroupCost);
                driverobj.GetElement(txt_PricingScheduleGroupCost).SendKeysWithSpace("5");



                actualresult = true;
            }
            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(Meridian_Common.CurrentTestName + "--" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                throw new ElementNotVisibleException("---Name of Class->" + this.GetType().Name + "---Name of Method->" + MethodBase.GetCurrentMethod().Name + "---Error Message->" + ex.Message);

            }
            return actualresult;
        }

        private By lnk_addnewpricingschedule = By.Id("MainContent_UC1_btnAddNew");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");
        private By txt_PricingScheduleName = By.Id("MainContent_UC1_PS_TITLE");
        private By txt_PricingScheduleDescription = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By txt_PricingScheduleDescriptioneditor = By.Id("ctl00_MainContent_UC1_rdEditorDesc_contentIframe");
        private By dtp_validfrom = By.Id("ctl00_MainContent_UC1_PS_FROM_DATE_dateInput");
        private By btn_PriceScheduleCreate = By.Id("MainContent_UC1_Save");
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");
        private By txt_PricingScheduleSearch = By.Id("MainContent_UC1_txtSearchFor");
        private By btn_PriceScheduleSearch = By.Id("MainContent_UC1_btnSearch");
        private By btn_PriceScheduleManage = By.Id("ctl00_MainContent_UC1_rgPricingInfo_ctl00_ctl04_btnManage");
        private By btn_PriceScheduleCopy = By.Id("ctl00_MainContent_UC1_rgPricingInfo_ctl00_ctl04_btnCopy");
        private By btn_PriceScheduleAddContent = By.Id("MainContent_ucPricingScheduleContents_lnkAdd");
        private By btn_PriceScheduleAddUserGroup = By.Id("MainContent_ucPricingScheduleUserGroups_lnkUserGroup");
        private By btn_PriceScheduleAddContentSearch = By.Id("btnSearch");
        private By btn_PriceScheduleAddUserGroupSearch = By.Id("btnSearchCourses");
        private By chkbox_PriceScheduleContent = By.XPath("//input[@id='ctl00_MainContent_ucSearchResults_rgContentResult_ctl00_ctl04_chkSelect']");
        private By btn_PriceScheduleSave = By.Id("MainContent_ucSearchResults_btnSave");
        private By btn_PriceScheduleAdd = By.Id("MainContent_ucUserGroupSearchResult_btnAdd");
        private By txt_PricingScheduleGroupCost = By.Id("ctl00_MainContent_ucUserGroupSearchResult_rgSearchUserGroups_ctl00_ctl04_PSUG_COST");
        
    }
}
