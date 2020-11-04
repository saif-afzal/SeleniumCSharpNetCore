using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
//using Meridian.Utility;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class RequiredTrainingConsoles
    {
        private readonly IWebDriver driverobj;

        public RequiredTrainingConsoles(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_RequiredTrainingContentSearch(string searchtext)
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_Search);
                driverobj.select(By.Id("TabMenu_ML_BASE_TAB_Search_ManagerRole"), "Other");
                driverobj.GetElement(txt_Search).Clear();
                driverobj.GetElement(txt_Search).SendKeysWithSpace(searchtext);
                driverobj.FindSelectElementnew(ddl_SearchType, "Exact phrase");
                driverobj.GetElement(btn_Search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + searchtext + "')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_RequiredTrainingContentAdvSearch(string searchtext)
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_Search);
                driverobj.WaitForElement(lnk_advsearch);
              //  driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                driverobj.GetElement(txt_adv_search).SendKeysWithSpace(searchtext);
                driverobj.GetElement(txt_desc_search).SendKeysWithSpace(searchtext);
                driverobj.GetElement(txt_keyword_search).SendKeysWithSpace(searchtext);
                driverobj.FindSelectElementnew(ddl_SearchType, "Exact phrase");
                driverobj.GetElement(btn_Search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + searchtext + "')]"));

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_GoToRequiredTraining()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_Go_To);
            //    driverobj.GetElement(btn_Go_To).ClickWithSpace();
                driverobj.ClickEleJs(btn_Go_To);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }


        public bool Click_AssignRequiredTrainingContentSearch()
        {
            bool result = false;

            try
            {

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }

        public bool Click_AssignRequiredTraining()
        {
            bool result = false;

            try
            {

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }

        public bool Click_InformationIcon(string searchtext)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(img_infoicon);
                string originalHandle = driverobj.CurrentWindowHandle;
              //  driverobj.GetElement(img_infoicon).ClickWithSpace();
                driverobj.ClickEleJs(img_infoicon);
                driverobj.selectWindow("Blogs");
                Thread.Sleep(4000);
                driverobj.WaitForElement(lbl_mainheading);
                if (driverobj.GetElement(lbl_mainheading).Text.Contains(searchtext))
                {
                    result = true;
                }

                //  SurveyUtilDriver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + "')]"));
                Thread.Sleep(3000);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }
        private By txt_Search = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_Search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By btn_Go_To = By.Id("TabMenu_ML_BASE_TAB_Search_ReqTrainingContent_GoButton_1");
        private By ddl_SearchType = By.Id("TabMenu_ML_BASE_TAB_Search_SearchType");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_adv_search = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE");
        private By txt_desc_search = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION");
        private By txt_keyword_search = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS");
       // private By img_infoicon = By.XPath("//img[contains(@id,'_1_ReqTrainingContent_1_InfoIcon')]");
        private By img_infoicon = By.XPath("//img[@ src='/Skins/BaseTopMenu/Icons/en-US/ViewInfoIcon.png']");
        private By lbl_mainheading = By.Id("MainHeading");
    }




}
