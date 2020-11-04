using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Reflection;

namespace Selenium2.Meridian
{
    class Blogs
    {

        private readonly IWebDriver driverobj;
        public Blogs(IWebDriver driver)
        {
            driverobj = driver;
        }

        //public static string stringtofind = "testblog_" + ExtractDataExcel.token_for_reg;


        public bool Click_GoToButton()
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(blogsGoBtn);
                driverobj.GetElement(blogsGoBtn).ClickWithSpace();
                actualresults = driverobj.existsElement(blogsTitle);


            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }
        public bool Populate_blogs(string h_title,string browserstr)
        {

            bool actualresults = false;
            try
            {
                driverobj.WaitForElement(blogsTitle);
                driverobj.GetElement(blogsTitle).Clear();
                driverobj.GetElement(blogsTitle).SendKeysWithSpace("testblog_" + h_title + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(blogsDesc).Clear();
                driverobj.GetElement(blogsDesc).SendKeysWithSpace("testblog_" + h_title + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(blogsKeywords).Clear();
                driverobj.GetElement(blogsKeywords).SendKeysWithSpace("testblog_" + h_title + ExtractDataExcel.token_for_reg + browserstr);
               driverobj.GetElement(createbutton).ClickWithSpace();
         actualresults=       driverobj.existsElement(checkin);
               // driverobj.GetElement(checkin).ClickWithSpace();
                driverobj.ClickEleJs(checkin);
               
              

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
              
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickWithSpace();
               actualresult = driverobj.existsElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
             
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Populate_advancesearch(string h_title,string browserstr)

        {
              bool actualresult = false;
            try
            {
            driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeysWithSpace("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeysWithSpace("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeysWithSpace("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
            
            actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Search(string h_title,string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "testblog_" + h_title + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + "testblog_" + h_title + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                Thread.Sleep(2000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search(string h_title, string browserstr)
        {
            bool actualresult = false;
            try
            {
               
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeysWithSpace("testblog_" + h_title + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
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
              
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
               actualresult = driverobj.existsElement(By.XPath("//span[contains(.,'Check Out')]"));
               
                
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

                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
              //  driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//span[contains(.,'Check Out')]"));
                actualresult = driverobj.existsElement(By.XPath("//span[@class='WorkflowButtonCurrent']"));
                
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

              
                //driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditBlog_CNT_PREVIEW_URL"));
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditBlog_CNT_PREVIEW_URL")).SendKeysWithSpace("www.google.com");
                driverobj.ClickEleJs(btn_save);
             actualresult=   driverobj.existsElement(By.Id("ReturnFeedback"));
              //  driverobj.GetElement(By.Id("ML.BASE.WF.Checkin")).ClickWithSpace();
                driverobj.ClickEleJs(By.Id("ML.BASE.WF.Checkin"));
              
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool blogs_req_training()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[2]"));
             //   driverobj.GetElement(lnk_required_training).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[2]"));

                driverobj.WaitForElement(btn_required_training_go);
                driverobj.FindSelectElementnew(cmb_AssignTraining, "Assign Training Without Deadline");
                driverobj.ClickEleJs(btn_required_training_go);
                driverobj.WaitForElement(txt_AssignTraining_SearchRole);
                driverobj.GetElement(txt_AssignTraining_SearchRole).Clear();
                driverobj.GetElement(txt_AssignTraining_SearchRole).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.ClickEleJs(btn_AssignTraining_Search);
                try { driverobj.WaitForElement(chk_AssignTraining_adduser_fromlist); }
                catch (Exception) { }
                 //  driverobj.GetElement(chk_AssignTraining_adduser_fromlist).ClickWithSpace();
                driverobj.ClickEleJs(chk_AssignTraining_adduser_fromlist);
                driverobj.ClickEleJs(btn_AssignTraining);
                Thread.Sleep(3000);
             actualresult=driverobj.existsElement(lbl_return_feedback);
              
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }
        public bool Click_Delete()
        {
            bool actualresult = false;
            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[3]"));
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[3]"));
                driverobj.WaitForElement(btn_delete_content);
               // driverobj.GetElement(btn_delete_content).ClickAnchor();
                driverobj.ClickEleJs(btn_delete_content);
                driverobj.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
                List<IWebElement> ele = driverobj.FindElements(By.CssSelector("button[type=button]")).ToList();
                foreach (var item in ele)
                {
                    if (item.Text.ToLower().Contains("delete")) { item.ClickWithSpace(); Thread.Sleep(2000); break; }
                }
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        internal void CreateBlog_Regression(string browserstr)
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            AdminstrationConsole AdminstrationConsoleobj = new AdminstrationConsole(driverobj);
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Click_GoToButton();
            Populate_blogs("", browserstr);
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
        private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");

    }
}
