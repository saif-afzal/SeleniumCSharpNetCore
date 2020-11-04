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

namespace TestAutomation.Meridian.Regression_Objects
{
    class Faqs
    {
        private readonly IWebDriver driverobj;

        public Faqs(IWebDriver driver)
        {
            driverobj = driver;
        }


        public bool Click_GoToButton()
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(btn_go);
                driverobj.GetElement(btn_go).ClickWithSpace();
                driverobj.WaitForElement(txt_create_question);
                actualresults = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }
        public bool Populate_faq(string faqfor, int total, string browserstr)
        {

            bool actualresults = false;
            try
            {
                for (int i = 1; i <= total; i++)
                {

                    driverobj.WaitForElement(txt_create_question);
                    driverobj.GetElement(txt_create_question).Clear();
                    driverobj.GetElement(txt_create_question).SendKeysWithSpace(ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + i);
                    driverobj.GetElement(btn_create).ClickWithSpace();
                    driverobj.WaitForElement(lbl_return_feedback);
                    driverobj.GetElement(txt_create_Answer).Clear();
                    driverobj.GetElement(txt_create_Answer).SendKeysWithSpace(ExtractDataExcel.MasterDic_FAQ["Answer"]);
                    driverobj.GetElement(txt_create_Source).Clear();
                    driverobj.GetElement(txt_create_Source).SendKeysWithSpace(ExtractDataExcel.MasterDic_FAQ["Source"]);
                    driverobj.GetElement(btn_AddAnswer).ClickWithSpace();
                    Thread.Sleep(3000);
                    driverobj.WaitForElement(tab_CheckIn);
                 //   driverobj.GetElement(tab_CheckIn).ClickWithSpace();
                    driverobj.ClickEleJs(tab_CheckIn);
                    driverobj.WaitForElement(lbl_Return);
                    actualresults = true;
                }

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }

        public bool Click_lnkadvancesearch()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(lnk_advance_search);
              //  driverobj.GetElement(lnk_advance_search).ClickWithSpace();
                driverobj.ClickEleJs(lnk_advance_search);
                driverobj.WaitForElement(txt_search_question);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Populate_advancesearch(string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_search_question);
                driverobj.GetElement(txt_search_question).Clear();
                driverobj.GetElement(txt_search_question).SendKeysWithSpace(ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + " " + faqfor + 1);
                driverobj.GetElement(txt_search_answer).Clear();
                driverobj.GetElement(txt_search_answer).SendKeysWithSpace(ExtractDataExcel.MasterDic_FAQ["Answer"]);
                driverobj.GetElement(txt_search_source).Clear();
                driverobj.GetElement(txt_search_source).SendKeysWithSpace(ExtractDataExcel.MasterDic_FAQ["Source"]);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Search(string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_admin_search);
                driverobj.ClickEleJs(btn_admin_search);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1 + "')]"));
               // driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1 + "')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"] + browserstr + faqfor + 1 + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search(string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }


        public bool Click_Manage()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(lnk_manage);
              //  driverobj.(lnk_manage).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
            //    driverobj.WaitForElement(txt_preview_url);
              
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_CheckOut()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(tab_checkOut);
               // driverobj.GetElement(tab_checkOut).ClickWithSpace();
                driverobj.ClickEleJs(tab_checkOut);
            //    driverobj.WaitForElement(txt_preview_url);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }
        public bool Click_save()
        {
            bool actualresult = false;
            try
            {
                //driverobj.WaitForElement(txt_preview_url);
                //driverobj.GetElement(txt_preview_url).SendKeysWithSpace("www.google.com");
                driverobj.ClickEleJs(btn_save);
                driverobj.WaitForElement(lbl_return_feedback);
           //     driverobj.GetElement(tab_CheckIn).ClickWithSpace();
                driverobj.ClickEleJs(tab_CheckIn);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Delete()
        {
            bool actualresult = false;
            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                //IWebElement element = driverobj.FindElement(By.XPath("//button[contains(.,'Delete Content')]"));
                //IJavaScriptExecutor executor = (IJavaScriptExecutor)driverobj;
                //executor.ExecuteScript("arguments[0].click();", element);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
               // driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).Click();
                driverobj.ClickEleJs((By.XPath("//a[contains(.,'Delete Content')]")));
                driverobj.WaitForElement(btn_delete_content);
              //  driverobj.GetElement(btn_delete_content).ClickAnchor();
                driverobj.ClickEleJs(btn_delete_content);
                //List<IWebElement> ele = driverobj.FindElements(By.CssSelector("a[href*=DeleteContentItem]")).ToList();
                //foreach (var item in ele)
                //{
                //    if (item.Text.ToLower().Contains("delete")) { item.ClickWithSpace(); Thread.Sleep(2000); break; }
                //}
                //Thread.Sleep(2000);
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        internal void Create_FAQForRegression(string browserstr)
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            AdminstrationConsole AdminstrationConsoleobj = new AdminstrationConsole(driverobj);
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("FAQs");
            Click_GoToButton();
            Populate_faq("adminfaq", 1, browserstr);

        }
        private By adminconsoleopenlink = By.Id("NavigationStrip1_lnkAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By lnk_faq = By.LinkText("FAQs");
        private By myOwnlearning = By.Id("NavigationStrip1_lbUserView");
        private By btn_go = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_create_question = By.Id("TabMenu_ML_BASE_TAB_EditQuestion_FAQQ_QUESTION");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        private By txt_create_Answer = By.Id("TabMenu_ML_BASE_TAB_EditAnswers_FAQA_ANSWER");
        private By txt_create_Source = By.Id("TabMenu_ML_BASE_TAB_EditAnswers_FAQA_SOURCE");
        private By btn_AddAnswer = By.Id("TabMenu_ML_BASE_TAB_EditAnswers_ML.BASE.BTN.AddAnswer");
        private By tab_CheckIn = By.XPath("//a[@id='ML.BASE.WF.Checkin']/span");
        private By lbl_Return = By.Id("Return");
        private By lnk_more = By.Id("MainContent_ucFAQsPortlets_lnkMore");
        private By lnk_firstitem = By.Id("ctl00_MainContent_UC1_rlvSearchResults_ctrl0_lnkQuestionDetails");
        private By txt_search = By.Id("MainContent_UC1_txtSearch");
        private By btn_search = By.Id("MainContent_UC1_btnSearch");

        //admin
        private By lnk_advance_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_search_question = By.Id("TabMenu_ML_BASE_TAB_Search_FAQQ_QUESTION");
        private By txt_search_answer = By.Id("TabMenu_ML_BASE_TAB_Search_FAQA_ANSWER");
        private By txt_search_source = By.Id("TabMenu_ML_BASE_TAB_Search_FAQA_SOURCE");
        private By btn_admin_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_manage = By.XPath("//a[contains(.,'Manage')]");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By tab_checkOut = By.XPath("//span[contains(.,'Check Out')]");
        private By txt_preview_url = By.Id("TabMenu_ML_BASE_TAB_EditQuestion_CNT_PREVIEW_URL");
        private By lnk_delete_content = By.XPath("//a[contains(.,'Delete Content')]");
         private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");

    }
}
