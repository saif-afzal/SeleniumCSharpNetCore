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
    class ProfessionalDevelopments
    {
        private readonly IWebDriver driverobj;

        public ProfessionalDevelopments(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Check_allsections()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.WaitForElement(btn_searchidp);
                driverobj.WaitForElement(cmb_searchtype);
                driverobj.WaitForElement(cmb_contenttype);
                driverobj.WaitForElement(cmb_searchactivity);
                driverobj.WaitForElement(lnk_createnewcompetency);
                driverobj.WaitForElement(lnk_createnewsucessprofile);
                driverobj.WaitForElement(lnk_managecompetencies);
                driverobj.WaitForElement(lnk_managesucessprofile);
                driverobj.WaitForElement(lnk_createnewproficiencyscale);
                driverobj.WaitForElement(lnk_manageproficencyscale);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_CreateNewCompetency()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_createnewcompetency);
                driverobj.GetElement(lnk_createnewcompetency).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }


        public bool Click_CreateNewProficencyScale()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_createnewproficiencyscale);
                driverobj.GetElement(lnk_createnewproficiencyscale).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_ManageProficencyScale()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_manageproficencyscale);
                driverobj.GetElement(lnk_manageproficencyscale).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Click_search(string title, string contenttype)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(title);
                driverobj.FindSelectElementnew(cmb_contenttype, contenttype);
                driverobj.GetElement(btn_searchidp).ClickWithSpace();
               
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Edit()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_edit);
                driverobj.GetElement(btn_edit).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Edit_Map_Conent()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_editmapcontent);
                driverobj.GetElement(btn_editmapcontent).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_CreateNewSuccessProfile()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_createnewsucessprofile);
                driverobj.GetElement(lnk_createnewsucessprofile).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_ManageSuccessProfile()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_managesucessprofile);
                driverobj.GetElement(lnk_managesucessprofile).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        private By txt_searchfor = By.Id("MainContent_ucSearchTop_SearchFor");
        private By btn_searchidp = By.Id("btnSearchIdp");
        private By cmb_searchtype = By.Id("MainContent_ucSearchTop_SearchType");
        private By cmb_contenttype = By.Id("MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID");
        private By cmb_searchactivity = By.Id("MainContent_ucSearchTop_SearchActivity");
        private By lnk_createnewcompetency = By.XPath("//a[contains(.,'Create New Competency')]");
        private By lnk_createnewsucessprofile = By.XPath("//a[contains(.,'Create New Success Profile')]");
        private By lnk_managecompetencies = By.XPath("//a[contains(.,'Manage Competencies')]");
        private By lnk_managesucessprofile = By.XPath("//a[contains(.,'Manage Success Profiles')]");
        private By lnk_createnewproficiencyscale = By.XPath("//a[contains(.,'Create New Proficiency Scale')]");
        private By lnk_manageproficencyscale = By.XPath("//a[contains(.,'Manage Proficiency Scales')]");
        private By btn_edit = By.Id("MainContent_MainContent_ucSummary_lnkEdit");
        private By btn_editmapcontent = By.Id("MainContent_MainContent_ucCourseSettings_lnkEdit");
    
        //in gov there was id
        //private By lnk_createnewcompetency = By.Id("MainContent_ucCompetenciesProfiles_htCreateCompetency");
        //private By lnk_createnewsucessprofile = By.Id("MainContent_ucCompetenciesProfiles_hlCreateSuccessProfile");
        //private By lnk_managecompetencies = By.Id("MainContent_ucCompetenciesProfiles_hlManageCompetencies");
        //private By lnk_managesucessprofile = By.Id("MainContent_ucCompetenciesProfiles_hlManageSuccessProfiles");
        //private By lnk_createnewproficiencyscale = By.Id("MainContent_ucProficiencyScales_htCreateProficiencyScale");
        //private By lnk_manageproficencyscale = By.Id("MainContent_ucProficiencyScales_hlManageProficiencyScales");

    }
}
