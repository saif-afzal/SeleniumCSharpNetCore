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
    class FaqUtils
    {
        private readonly IWebDriver driverobj;

        public FaqUtils(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool createfaq(string faqfor, int total, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_faq).Click();
                for (int i = 1; i <= total; i++)
                {
                    driverobj.WaitForElement(btn_go);
                    driverobj.GetElement(btn_go).Click();
                    driverobj.WaitForElement(txt_create_question);
                    driverobj.GetElement(txt_create_question).Clear();
                    driverobj.GetElement(txt_create_question).SendKeys(ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + i);
                    driverobj.GetElement(btn_create).Click();
                    driverobj.WaitForElement(lbl_return_feedback);
                    driverobj.GetElement(txt_create_Answer).Clear();
                    driverobj.GetElement(txt_create_Answer).SendKeys(ExtractDataExcel.MasterDic_FAQ["Answer"]);
                    driverobj.GetElement(txt_create_Source).Clear();
                    driverobj.GetElement(txt_create_Source).SendKeys(ExtractDataExcel.MasterDic_FAQ["Source"]);
                    driverobj.GetElement(btn_AddAnswer).Click();
                    driverobj.WaitForElement(tab_CheckIn);
                    driverobj.GetElement(tab_CheckIn).Click();
                    driverobj.GetElement(lbl_Return).Click();
                }
                Thread.Sleep(3000);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;

        }

        public bool viewfaq(int total, string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myOwnlearning);
                driverobj.GetElement(ObjectRepository.myOwnlearning).Click();
                for (int i = 1; i <= total; i++)
                {
                    driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + i + "']"));

                }


                actualresult = true;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool clickonfaqlink(string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(myOwnlearning);


                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1 + "']")).ClickWithSpace();
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 15));
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1 + "')]"));

                actualresult = true;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool viewmorefaq()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(lnk_more);
                driverobj.GetElement(lnk_more).ClickWithSpace();

                driverobj.WaitForElement(lnk_firstitem);
                driverobj.WaitForElement(txt_search);
                driverobj.WaitForElement(btn_search);

                actualresult = true;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }


        public bool FaqAdvSearch(string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_faq).Click();

                driverobj.GetElement(lnk_advance_search).Click();
                driverobj.WaitForElement(txt_search_question);
                driverobj.GetElement(txt_search_question).Clear();
                driverobj.GetElement(txt_search_question).SendKeys(ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + " " + faqfor + 1);
                driverobj.GetElement(txt_search_answer).Clear();
                driverobj.GetElement(txt_search_answer).SendKeys(ExtractDataExcel.MasterDic_FAQ["Answer"]);
                driverobj.GetElement(txt_search_source).Clear();
                driverobj.GetElement(txt_search_source).SendKeys(ExtractDataExcel.MasterDic_FAQ["Source"]);
                driverobj.GetElement(btn_admin_search).Click();

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1 + "')]"));
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public void faqsearch(string faqfor, string browserstr)
        {

            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_faq).Click();
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeys(ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1);
                driverobj.GetElement(btn_admin_search).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1 + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr + faqfor + 1 + "')]")).Click();

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public bool faqsimplesearch(string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                faqsearch(faqfor, browserstr);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }


        public bool managefaq(string faqfor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                faqsearch(faqfor, browserstr);
                driverobj.WaitForElement(lnk_manage);
                driverobj.GetElement(lnk_manage).Click();
                driverobj.WaitForElement(tab_checkOut);
                driverobj.GetElement(tab_checkOut).ClickWithSpace();
                driverobj.WaitForElement(txt_preview_url);
                driverobj.GetElement(txt_preview_url).SendKeys("www.google.com");
                driverobj.GetElement(btn_save).Click();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.GetElement(tab_CheckIn).Click();
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool Click_Delete()
        {
            bool actualresult = false;
            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.WaitForElement(btn_delete_content);
                driverobj.GetElement(btn_delete_content).ClickAnchor();
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
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
