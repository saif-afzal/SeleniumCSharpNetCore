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
    class AuditingConsoles
    {
        private readonly IWebDriver driverobj;

        public AuditingConsoles(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_GeneralSearch()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_general_search);
                driverobj.WaitForElement(btn_search);
                driverobj.GetElement(btn_search).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Search Record For Auditing Console in Simple Search", driverobj);
            }

            return result;
        }

        public bool Check_Search()
        {
            bool result = false;

            try
            {
                result = driverobj.existsElement(lbl_firstitem);


             
               //commented due to bug regarding expand button
                //driverobj.WaitForElement(btn_firstitem);
               //driverobj.GetElement(btn_firstitem).ClickWithSpace();
               //result = driverobj.existsElement(lbl_firstexpandeditem);
                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        int facetvalue = 0;
        public bool Click_facet()
        {
            bool result = false;
            By chk_create = By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_AuditProperty_0']");
            try
            {
                driverobj.WaitForElement(chk_create);
                driverobj.WaitForElement(By.XPath("//label[contains(.,'Create')]"));
               // driverobj.GetElement(chk_create).Click();
                driverobj.ClickEleJs(chk_create);
                driverobj.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchButton']"));
                facetvalue =Convert.ToInt32( Regex.Match(driverobj.GetElement(lbl_create).Text, @"\(([^)]*)\)").Groups[1].Value);
                if(facetvalue>=10)
                {
                    
                    result = true;
                }
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_refineresult()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_refinesearch);
            //    driverobj.GetElement(btn_refinesearch).ClickWithSpace();
                driverobj.ClickEleJs(btn_refinesearch);
                driverobj.WaitForElement(lbl_recordfound);
                if (driverobj.GetElement(lbl_recordfound).Text.Contains("Records found: " + facetvalue + ""))
                {

                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_lnkusersearch()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_usersearch);
            //    driverobj.GetElement(lnk_usersearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_usersearch);
               
                    result = true;
               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_UserSearch()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_usersearch);
                driverobj.GetElement(txt_usersearch).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Firstname"]);
                driverobj.WaitForElement(btn_search);
                driverobj.GetElement(btn_search).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

         public bool Check_SearchUser()
        {
            bool result = false;

            try
            {
                result = driverobj.existsElement(lbl_firstitemuser);
                //expand button issue
                //driverobj.WaitForElement(btn_firstitemuser);
                //driverobj.GetElement(btn_firstitemuser).ClickWithSpace();
                //driverobj.WaitForElement(lbl_firstexpandeditemuser);
                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        private By txt_general_search = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_SearchButton");
        private By lbl_firstitem = By.XPath("//tr[contains(@id,'TabMenu_ML_BASE_TAB_Search_AuditResults_AL_TRACKING_ID_0_01_1')]");
        private By btn_firstitem =By.XPath("//img[contains(@id,'But_AuditResults_AL_TRACKING_ID_0_01_1')]");
        private By lbl_firstexpandeditem = By.XPath("//table[contains(@id,'TabMenu_ML_BASE_TAB_Search_AuditResultsDetails_1_')]");
        private By lbl_recordfound = By.XPath("//span[contains(@id,'TabMenu_ML_BASE_TAB_Search_Feedback_')]");
        private By chk_create = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_FacetedSearchParameter||AUDITTYPE||Create')]");
        private By lbl_create = By.XPath("//label[contains(@for,'TabMenu_ML_BASE_TAB_Search_FacetedSearchParameter||AUDITTYPE||Create')]");
        private By btn_refinesearch = By.Id("TabMenu_ML_BASE_TAB_Search_RefineSearchAuditTrail");
        private By lnk_usersearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.UserSearch");
        private By txt_usersearch = By.Id("TabMenu_ML_BASE_TAB_Search_USER_NAME");
        private By lbl_firstitemuser = By.XPath("//tr[contains(@id,'TabMenu_ML_BASE_TAB_Search_AuditResults_AL_TRANSACTION_ID_0_01_1')]");
        private By btn_firstitemuser =By.XPath("//img[contains(@id,'But_AuditResults_AL_TRANSACTION_ID_0_01_1')]");
        private By lbl_firstexpandeditemuser = By.XPath("//table[contains(@id,'TabMenu_ML_BASE_TAB_Search_AuditResultsDetails_1_')]");
       
        

    }
}
