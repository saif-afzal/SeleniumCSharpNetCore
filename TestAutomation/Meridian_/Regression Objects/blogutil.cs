using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class blogutil
    {

        private readonly IWebDriver driverobj;
        public blogutil(IWebDriver driver)
        {
            driverobj = driver;
        }

        //public static string stringtofind = "testblog_" + ExtractDataExcel.token_for_reg;

        public bool Createblogs(string h_title, string browserstr)
        {

            bool actualresults = false;
            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.WaitForElement(adminblogs);
                driverobj.GetElement(adminblogs).Click();
                driverobj.WaitForElement(blogsGoBtn);
                driverobj.GetElement(blogsGoBtn).Click();
                driverobj.WaitForElement(blogsTitle);
                driverobj.GetElement(blogsTitle).Clear();
                driverobj.GetElement(blogsTitle).SendKeys("testblog_" + ExtractDataExcel.token_for_reg+browserstr);
                driverobj.GetElement(blogsDesc).Clear();
                driverobj.GetElement(blogsDesc).SendKeys("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(blogsKeywords).Clear();
                driverobj.GetElement(blogsKeywords).SendKeys("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(createbutton).Click();
                driverobj.WaitForElement(checkin);
                driverobj.GetElement(checkin).Click();

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);

                actualresults = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

               
            }
            return actualresults;

        }





        public bool blogsAdvSearch(string h_title,string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(adminblogs).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickAnchor();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeys("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeys("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeys("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "testblog_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }
        public void blogssearch(string h_title,string browserstr)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(adminblogs).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "testblog_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + "testblog_" + ExtractDataExcel.token_for_reg + browserstr + "')]")).Click();

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }

        public bool blogssimplesearch(string h_title,string browserstr)
        {
            bool actualresult = false;
            try
            {
                blogssearch(h_title,browserstr);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }


        public bool manageblogs(string h_title, string browserstr)
        {
            bool actualresult = false;
            try
            {
                blogssearch(h_title,browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditBlog_CNT_PREVIEW_URL"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditBlog_CNT_PREVIEW_URL")).SendKeys("www.google.com");
                driverobj.GetElement(btn_save).Click();
                driverobj.WaitForElement(By.Id("ReturnFeedback"));
                driverobj.GetElement(By.Id("ML.BASE.WF.Checkin")).Click();
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }

        public bool blogs_req_training(string h_title, string browserstr)
        {
            bool actualresult = false;
            try
            {
                blogssearch(h_title,browserstr);
                driverobj.WaitForElement(lnk_required_training);
                driverobj.GetElement(lnk_required_training).ClickAnchor();

                driverobj.WaitForElement(btn_required_training_go);
                driverobj.FindSelectElementnew(cmb_AssignTraining, "Assign Training Without Deadline");
                driverobj.GetElement(btn_required_training_go).Click();
                driverobj.WaitForElement(txt_AssignTraining_SearchRole);
                driverobj.GetElement(txt_AssignTraining_SearchRole).Clear();
                driverobj.GetElement(txt_AssignTraining_SearchRole).SendKeys(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(btn_AssignTraining_Search).Click();

                driverobj.GetElement(chk_AssignTraining_adduser_fromlist).Click();
                driverobj.GetElement(btn_AssignTraining).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }
        public bool deleteblogs(string certfor)
        {
            bool actualresult = false;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                //driverobj.findandacceptalert();
                driverobj.SwitchWindow("Delete Content");

                driverobj.WaitForElement(By.Id("0"));
                driverobj.GetElement(By.Id("0")).Click();
                Thread.Sleep(5000);
                driverobj.SwitchTo().Window(originalHandle);
                Thread.Sleep(5000);
                driverobj.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
                actualresult = true;


            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;

        }

        public bool Deleteblogs(string h_title, string browserstr)
        {
            bool actualresult = false;
            try
            {
                blogssearch(h_title, browserstr);

                bool result = deleteblogs("testblog_" + ExtractDataExcel.token_for_reg + browserstr);

                if (result == true)
                {
                    driverobj.Close();
                    driverobj.SwitchTo().Window("");
                    Thread.Sleep(3000);
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }

        private By adminblogs = By.LinkText("Blogs");
        private By blogsGoBtn = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By blogsTitle = By.Id("TabMenu_ML_BASE_TAB_EditBlog_BLG_BLOG_TITLE");
        private By blogsDesc = By.Id("TabMenu_ML_BASE_TAB_EditBlog_BLG_BLOG_DESCRIPTION");
        private By blogsKeywords = By.Id("TabMenu_ML_BASE_TAB_EditBlog_BLG_BLOG_KEYWORDS");
        private By createbutton = By.Id("ML.BASE.BTN.Create");
        private By checkin = By.XPath("//span[contains(.,'Check In')]");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        //reg training
        private By lnk_required_training = By.XPath("//a[contains(.,'Required Training')]");
        private By btn_required_training_go = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu");
        private By cmb_AssignTraining = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining");
        private By txt_AssignTraining_SearchRole = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole");
        private By btn_AssignTraining_Search = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search");
        private By chk_AssignTraining_adduser_fromlist = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]");
        private By btn_AssignTraining = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining");

    }
}
