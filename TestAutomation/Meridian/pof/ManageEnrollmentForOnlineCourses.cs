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
    class ManageEnrollmentForOnlineCourses
    {
        private readonly IWebDriver driverobj;

        public ManageEnrollmentForOnlineCourses(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool populateSearchForm(string courseTitle)
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(txt_SearchCourseTitle);
                driverobj.GetElement(txt_SearchCourseTitle).SendKeysWithSpace(courseTitle);
                driverobj.FindSelectElementnew(ddl_SearchType, "Exact phrase");
                driverobj.GetElement(btn_Search).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }

        public bool Click_ManageUsers()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_EnrollUsers);
                driverobj.GetElement(btn_EnrollUsers).ClickWithSpace();
                
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }

        public bool Click_ManageUsersClassroom()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_EnrollUsersClassroom);
                driverobj.GetElement(btn_EnrollUsersClassroom).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }

        public bool verify_customFieldVisible(String customFieldLabel)
        {
            By lbl_customField = By.XPath("//label[contains(text(),'" + customFieldLabel + "')]");
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_seeMoreSearchCriteria);
                driverobj.GetElement(lnk_seeMoreSearchCriteria).Click();
                driverobj.WaitForElement(lbl_customField);


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }

        public bool Click_courseTitle()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_courseTitle);
                driverobj.GetElement(lnk_courseTitle).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }

        private By lnk_courseTitle = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnLink");
        private By lnk_seeMoreSearchCriteria = By.Id("MainContent_UC1_BaseCustomFieldSearch_lblSeeMore");
        private By btn_EnrollUsers = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnEnrollUser");
        private By btn_EnrollUsersClassroom = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnEnrollUser");
        private By btn_Search = By.Id("btnSearchCourses");
        private By txt_SearchCourseTitle = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
        private By ddl_SearchType = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
        
    }
}
