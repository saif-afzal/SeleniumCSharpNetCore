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
    class HomePageFeed
    {

        private readonly IWebDriver driverobj;
        public HomePageFeed(IWebDriver driver)
        {
            driverobj = driver;
        }

        //string stringtofind = "testfeed_" + ExtractDataExcel.token_for_reg;


        public bool Click_GoToButton()
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(ObjectRepository.HomeFeedsGoBtn);
                driverobj.ClickEleJs(ObjectRepository.HomeFeedsGoBtn);
                driverobj.WaitForElement(ObjectRepository.HomeFeedsTitle);
                actualresults = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }
        public bool Populate_HomeFeeds(string h_title,string browserstr)
        {

            bool actualresults = false;
            try
            {
               
                    driverobj.GetElement(ObjectRepository.HomeFeedsTitle).Clear();
                    driverobj.GetElement(ObjectRepository.HomeFeedsTitle).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg+browserstr);
                    driverobj.GetElement(ObjectRepository.HomeFeedsDesc).Clear();
                    driverobj.GetElement(ObjectRepository.HomeFeedsDesc).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg + browserstr);
                    driverobj.GetElement(ObjectRepository.HomeFeedsKeywords).Clear();
                    driverobj.GetElement(ObjectRepository.HomeFeedsKeywords).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg + browserstr);
                    driverobj.ClickEleJs(ObjectRepository.createbutton);
                    driverobj.WaitForElement(ObjectRepository.HomeFeedsHtmlInfo);
                    driverobj.GetElement(ObjectRepository.HomeFeedsHtmlInfo).Clear();
                    driverobj.GetElement(ObjectRepository.HomeFeedsHtmlInfo).SendKeysWithSpace("<html>\n<body>\n<h1>'" + "testfeed_" + ExtractDataExcel.token_for_reg  + h_title+browserstr + "'<h1>\n</body>\n</html>");
                    driverobj.ClickEleJs(ObjectRepository.HomeFeedsSaveBtn);
                    driverobj.WaitForElement(ObjectRepository.checkin);
                   // driverobj.GetElement(ObjectRepository.checkin).ClickWithSpace();
                    driverobj.ClickEleJs(ObjectRepository.checkin);
                    actualresults = true;
              
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }

        public bool Click_SetDomainFeeds(string h_title,string browserstr)
        {

            bool actualresult = false;
            try
            {
                if (driverobj.existsElement(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1']/span[2]")))
                {
                    driverobj.ClickEleJs(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1']/span[2]"));
                    driverobj.SelectWindowClose2("Domains", "Domain Console");
                    driverobj.ClickEleJs(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1']/span[2]"));
                }
                else
                {

                    //driverobj.GetElement(ObjectRepository.admindomainmanagment).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1_1']/span[2]"));

                    //   driverobj.GetElement(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1_1']/span[2]")).ClickWithSpace();
                    driverobj.ClickEleJs(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1_1']/span[2]"));


                }
              //  driverobj.SelectWindowClose1("Domains");
              //  driverobj.WaitForElement(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1_1']/span[2]"));
              ////  driverobj.GetElement(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1_1']/span[2]")).ClickWithSpace();
              //  driverobj.ClickEleJs(By.XPath(".//*[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1_1']/span[2]"));
                driverobj.WaitForElement(ObjectRepository.HomeFeedsSetDomain);
              //  driverobj.GetElement(ObjectRepository.HomeFeedsSetDomain).ClickWithSpace();
                driverobj.ClickEleJs(ObjectRepository.HomeFeedsSetDomain);
                driverobj.WaitForElement(ObjectRepository.HomeFeedsSearchFor);
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchFor).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchFor).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg+browserstr);
                driverobj.ClickEleJs(ObjectRepository.HomeFeedsSearchForBtn);

             //   driverobj.GetElement(ObjectRepository.HomeFeedsSelectFeed).ClickWithSpace();
                driverobj.ClickEleJs(ObjectRepository.HomeFeedsSelectFeed);
                driverobj.ClickEleJs(ObjectRepository.HomeFeedsSelectFeedBtn);
                driverobj.findandacceptalert();
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;

        }

        public bool CheckHomeFeeds(string h_title)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(By.XPath("//*[contains(.,'" + "testfeed_" + ExtractDataExcel.token_for_reg + "')]"));
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }

        public bool Click_lnkadvancesearch()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
            //    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickAnchor();
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Populate_advancesearch(string h_title, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "testfeed_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Search(string h_title, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            //    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).ClickWithSpace();
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "testfeed_" + ExtractDataExcel.token_for_reg +  browserstr + "')]"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'" + "testfeed_" + ExtractDataExcel.token_for_reg +  browserstr + "')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + "testfeed_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search(string h_title,string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeysWithSpace("testfeed_" + ExtractDataExcel.token_for_reg +  browserstr);
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
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
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

                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
              //  driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//span[contains(.,'Check Out')]"));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL"));
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
                //driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL"));
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL")).SendKeysWithSpace("www.google.com");
                driverobj.ClickEleJs(btn_save);
                driverobj.WaitForElement(By.Id("ReturnFeedback"));
              //  driverobj.GetElement(By.Id("ML.BASE.WF.Checkin")).ClickWithSpace();
                driverobj.ClickEleJs(By.Id("ML.BASE.WF.Checkin"));
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
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Delete Content')]"));
                driverobj.WaitForElement(btn_delete_content);
              //  driverobj.GetElement(btn_delete_content).ClickAnchor();
                driverobj.ClickEleJs(btn_delete_content);
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
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");

    }
}
