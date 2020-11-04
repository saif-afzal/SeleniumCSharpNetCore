using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class ProfessionalDevelopments_learner
    {
        private readonly IWebDriver driverobj;

        public ProfessionalDevelopments_learner(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_AddSucessProfile()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addsucessprofile);
                driverobj.GetElement(btn_addsucessprofile).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                Thread.Sleep(5000);
                driverobj.WaitForElement(txt_searchforsp);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_SearchSucessProfile(string orgtoadd)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_searchforsp);
                driverobj.GetElement(txt_searchforsp).SendKeysWithSpace(orgtoadd);
                driverobj.GetElement(btn_searchforsp).ClickWithSpace();
                driverobj.WaitForElement(btn_addspaction);
               
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_AddSPAction()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addspaction);
                driverobj.GetElement(btn_addspaction).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                //driverobj.WaitForElement(By.XPath("//h3[contains(.,'"+Variables.SuccessProfileTitle+browserstr+"smoke"+"')]"));
                //driverobj.WaitForElement(By.XPath("//td[contains(.,'" + Variables.PerformanceCompetencyTitle+browserstr + "smoke" + "')]"));

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_CreateDevPlan()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_createdevplan);
                driverobj.GetElement(btn_createdevplan).ClickWithSpace();
              
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Check_SucessProfile(string sucessprofiletitle,string performancecompetency)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(con_sucessprofile);
                driverobj.WaitForElement(btn_addsucessprofile);
                driverobj.FindElement(By.XPath("//h2[contains(.,'"+sucessprofiletitle+"')]"));
                driverobj.FindElement(By.XPath("//td[contains(.,'" + performancecompetency + "')]"));

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_FirstDevPlan(String DevPlanTitle)
        {
            bool result = false;
            By lnk_devPlan = By.XPath("//a[contains(text(),'" + DevPlanTitle + "')]");
            By pagination = By.XPath("//ol[@class='pager']/li[3]/div/strong");
            

            try
            {
                driverobj.WaitForElement(btn_viewAllPlans);
                driverobj.GetElement(btn_viewAllPlans).ClickWithSpace();

                if (driverobj.existsElement(pagination))
                {

                String totalPages = driverobj.GetElement(pagination).Text.ToString();
                totalPages = totalPages.Replace("of ", "");
                int intPages = int.Parse(totalPages);
                for (int i = 1; i <= intPages; i++)
                {
                    if (driverobj.existsElement(lnk_devPlan))
                        break;
                    else
                        driverobj.GetElement(By.XPath("//span[em[contains(text(),'Next')]]")).ClickWithSpace();
                }
                }


                driverobj.WaitForElement(lnk_devPlan);
                driverobj.GetElement(lnk_devPlan).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_DevPlan(string title)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//span[contains(.,'"+title+"')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'" + title + "')]")).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        private By btn_addsucessprofile = By.Id("MainContent_UC1_btnAddSuccessProfile");
        private By txt_searchforsp = By.Id("MainContent_UC1_SearchFor");
        private By btn_searchforsp = By.Id("btnSearchIdp");
        private By btn_addspaction = By.Id("ctl00_MainContent_UC1_rgSearch_ctl00_ctl04_btnAdd");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");
        private By btn_createdevplan = By.Id("MainContent_UC2_btnCreateNewPlan");
        private By con_sucessprofile = By.XPath("//div[contains(@id,'MainContent_UC1_ucSuccessProfileGrid')]");//con stand for div as it is shown as container
        private By lnk_firstdevplan = By.Id("ctl00_MainContent_UC1_rgAllPlans_ctl00_ctl20_lblTitle");
        private By btn_viewAllPlans = By.Id("MainContent_UC2_lnkViewAllPlans");
    }
}
