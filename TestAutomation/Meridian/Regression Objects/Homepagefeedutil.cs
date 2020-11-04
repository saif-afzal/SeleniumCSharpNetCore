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
    class Homepagefeedutil
    {

        private readonly IWebDriver driverobj;
        public Homepagefeedutil(IWebDriver driver)
        {
            driverobj = driver;
        }

        string stringtofind = "testfeed_" + ExtractDataExcel.token_for_reg;

        public bool CreateHomeFeeds(string h_title)
        {

            bool actualresults = false;
            try
            {
                //driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                //driverobj.selectWindow("Homepage Feeds");
                //driverobj.GetElement(ObjectRepository.adminhomepagefeeds).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsGoBtn).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsTitle).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsTitle).SendKeys(stringtofind + h_title);
                driverobj.GetElement(ObjectRepository.HomeFeedsDesc).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsDesc).SendKeys(stringtofind + h_title);
                driverobj.GetElement(ObjectRepository.HomeFeedsKeywords).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsKeywords).SendKeys(stringtofind + h_title);
                //driverobj.GetElement(homefeedcontactinfo).Clear();
                //driverobj.GetElement(homefeedcontactinfo).SendKeys(stringtofind);
                //driverobj.GetElement(homefeeduniqueid).Clear();
                //driverobj.GetElement(homefeeduniqueid).SendKeys("hf" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ObjectRepository.createbutton).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsHtmlInfo).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsHtmlInfo).SendKeys("<html>\n<body>\n<h1>'" + stringtofind + h_title + "'<h1>\n</body>\n</html>");
                driverobj.GetElement(ObjectRepository.HomeFeedsSaveBtn).Click();
                driverobj.WaitForElement(ObjectRepository.checkin);
                driverobj.GetElement(ObjectRepository.checkin).ClickWithSpace();

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                //driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                actualresults = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresults;

        }

        public bool SetDomainFeeds(string h_title)
        {

            bool actualresult = false;
            try
            {
                //driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                //driverobj.selectWindow(ObjectRepository.adminwindowtitle);

                //driverobj.GetElement(ObjectRepository.admindomainmanagment).ClickWithSpace();
                if (!driverobj.existsElement(ObjectRepository.HomeFeedsSetDomain))
                {
                    driverobj.GetElement(ObjectRepository.HomeFeedsSelectDomain).ClickWithSpace();
                    driverobj.SelectWindowClose2("Domains", "Domain Console");
                    if (driverobj.existsElement(ObjectRepository.HomeFeedsSelectDomain))
                    {
                        driverobj.GetElement(ObjectRepository.HomeFeedsSelectDomain).ClickWithSpace();
                    }
                    else
                    {
                        driverobj.SelectWindowClose2("Domains", "Domain Console");
                        driverobj.GetElement(ObjectRepository.HomeFeedsSelectDomain).ClickWithSpace();
                    }
                }
                driverobj.GetElement(ObjectRepository.HomeFeedsSetDomain).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.HomeFeedsSearchFor);
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchFor).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchFor).SendKeysWithSpace(stringtofind + h_title);
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchForBtn).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.HomeFeedsSelectFeed);
                driverobj.GetElement(ObjectRepository.HomeFeedsSelectFeed).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsSelectFeedBtn).Click();
                driverobj.findandacceptalert();
                actualresult = driverobj.existsElement(ObjectRepository.eltypesucessmsg);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresult;

        }

        public bool CheckHomeFeeds(string h_title)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(By.XPath("//*[contains(.,'" + stringtofind + h_title + "')]"));
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool hpage_feedAdvSearch(string h_title)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.adminhomepagefeeds).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickAnchor();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeys(stringtofind + h_title);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeys(stringtofind + h_title);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeys(stringtofind + h_title);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + stringtofind + h_title + "')]"));
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
           ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              
            }
            return actualresult;
        }
        public bool hpage_feedsimplesearch(string h_title)
        {
            bool actualresult = false;
            try
            {
                hpage_feedsearch(h_title);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
           ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }

        public void hpage_feedsearch(string h_title)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.adminhomepagefeeds).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys(stringtofind + h_title);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_SearchType"), "Exact phrase");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + stringtofind + h_title + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + stringtofind + h_title + "')]")).Click();

            }
            catch (Exception ex)
            {
           ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }


        public bool managehpage_feed(string h_title)
        {
            bool actualresult = false;
            try
            {
                hpage_feedsearch(h_title);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL")).SendKeys("www.google.com");
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
           ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }
        public bool deletehpage_feed(string certfor)
        {
            bool actualresult = false;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
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
           ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;

        }

        public bool Deletehpage_feedDetail(string h_title)
        {
            bool actualresult = false;
            try
            {
                hpage_feedsearch(h_title);

                bool result = deletehpage_feed(stringtofind + h_title);

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
           ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return actualresult;
        }
        private By btn_save = By.Id("ML.BASE.BTN.Save");

    }
}
