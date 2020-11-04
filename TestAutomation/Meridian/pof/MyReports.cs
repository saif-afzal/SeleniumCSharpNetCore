using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
// using TestAutomation.Data;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Selenium2.Meridian
{
    class MyReports
    {

        private readonly IWebDriver driverobj;

        public MyReports(IWebDriver driver)
        {
            driverobj = driver;
        }


        public bool MyReportlinkcheck()
        {
            bool actualresult = false;
            try
          {
                driverobj.WaitForElement(MyReportfirstreport);
                string reporttitle = "Details";
                driverobj.ClickEleJs(MyReportfirstreport);
                Thread.Sleep(10000);
                //driverobj.WaitForTitle(reporttitle, new TimeSpan(0, 0, 10));
                if (driverobj.Title == reporttitle)
                {
                    actualresult = true;
                }
                driverobj.WaitForElement(chk_currentreport);
                //driverobj.GetElement(chk_currentreport).ClickWithSpace();
                actualresult = driverobj.existsElement(By.XPath(".//*[@id='ctl00_MainContent_ucScheduledReport_mgScheduledReports_ctl00__0']/td[1]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;
        }

        public string Click_btncreteriarun()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(btn_selectcreteria);
               
                driverobj.ClickEleJs(btn_selectcreteria);
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(chk_contenttype);
                driverobj.ClickEleJs(chk_contenttype);
                driverobj.WaitForElement(btn_runreport);
                driverobj.GetElement(btn_runreport).ClickWithSpace();
                driverobj.selectWindow();
                Thread.Sleep(10000);
                actualresult = driverobj.Title;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;
        }

        public bool Click_btnarchive()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_archive);
                driverobj.GetElement(btn_archive).ClickWithSpace();
                driverobj.FindSelectElementnew(cmb_reportstype, "My Content Access");
                driverobj.WaitForElement(lbl_archivepage);
                //driverobj.GetElement(chk_currentreport).ClickWithSpace();
                actualresult = driverobj.existsElement(lbl_itemtype);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;
        }

        public bool click_archivelink()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_archive);
                driverobj.GetElement(btn_archive).ClickWithSpace();
                driverobj.FindSelectElementnew(cmb_reportstype, "My Content Access");
                driverobj.WaitForElement(lbl_archivepage);
               driverobj.WaitForElement(lbl_itemtype);
               driverobj.WaitForElement(lnk_firstarchiveitem);
              string reporttitle= driverobj.GetElement(lnk_firstarchiveitem).Text;
              driverobj.GetElement(lnk_firstarchiveitem).ClickAnchor();
              Thread.Sleep(5000);
              driverobj.selectWindow();
              Thread.Sleep(3000);
              if (reporttitle == driverobj.Title)
              {
                  actualresult = true;
              }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;
        }
        //public bool MyReportlinkclick()
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        driverobj.WaitForElement(MyReportfirstreport);
        //        string reporttitle = "Details";
        //        driverobj.GetElement(MyReportfirstreport).ClickWithSpace();
        //        Thread.Sleep(10000);
        //        //driverobj.WaitForTitle(reporttitle, new TimeSpan(0, 0, 10));
        //        if (driverobj.Title == reporttitle)
        //        {
        //            actualresult = true;
        //        }
        //        driverobj.WaitForElement(chk_currentreport);
        //        driverobj.GetElement(chk_currentreport).ClickWithSpace();
        //      actualresult= driverobj.existsElement(btn_firstrun);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
        //    }

        //    return actualresult;
        //}

        private By MyReportfirstreport = By.Id("ctl00_MainContent_MyReports_rgReports_ctl00_ctl04_lnkDetails");
        private By chk_currentreport = By.Id("MainContent_ucScheduledReport_cbShowCurrentTasks");
        private By btn_firstrun = By.Id("ctl00_MainContent_ucScheduledReport_mgScheduledReports_ctl00_ctl04_btnRunTask");
        private By btn_selectcreteria = By.Id("ctl00_MainContent_MyReports_rgReports_ctl00_ctl04_lnkCriteria");
        private By chk_contenttype = By.Id("MainContent_UC1_strContentType_0");
        private By btn_runreport = By.Id("MainContent_UC1_RunReport");
        private By btn_archive = By.Id("MainContent_MyReports_lnkArchived");
        private By cmb_reportstype = By.Id("MainContent_UC1_ddlArchivedReports");
        private By lbl_archivepage = By.XPath("//h1[contains(.,'Archived Scheduled Reports')]");
        private By lbl_itemtype = By.XPath("//td[contains(.,'My Content Access')]");
        private By lnk_firstarchiveitem = By.Id("ctl00_MainContent_UC1_rgArchives_ctl00_ctl04_lnkArchive");
    }
}
