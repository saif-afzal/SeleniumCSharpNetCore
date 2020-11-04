using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using Selenium2.Meridian;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class MyProfileUtil
    {

        private readonly IWebDriver driverobj;

        public MyProfileUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

      
        public void findanddelete()
        {
            try
            {

                driverobj.GetElement(ObjectRepository.edituserworkinfo).Click();
                Thread.Sleep(4000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                //Thread.Sleep(7000);
                IList<IWebElement> orgstodelete = driverobj.FindElements(ObjectRepository.MyProfileMgrsToDelete);
                for (int i = 0; i <= orgstodelete.Count - 2; i++)
                {

                    driverobj.WaitForElement(ObjectRepository.MyProfileMgrsIconToDelete);
                    driverobj.GetElement(ObjectRepository.MyProfileMgrsIconToDelete).Click();



                }

                IList<IWebElement> jobtitlestodelete = driverobj.FindElements(ObjectRepository.MyProfileJobTitleToDelete);
                for (int i = 0; i <= jobtitlestodelete.Count - 2; i++)
                {

                    driverobj.WaitForElement(ObjectRepository.MyProfileJobTitleIconToDelete);
                    driverobj.GetElement(ObjectRepository.MyProfileJobTitleIconToDelete).Click();


                }

                IList<IWebElement> managerstodelete = driverobj.FindElements(ObjectRepository.MyProfileOrgsToDelete);
                for (int i = 0; i <= managerstodelete.Count - 1; i++)
                {

                    driverobj.WaitForElement(ObjectRepository.MyProfileOrgsIconToDelete);
                    driverobj.GetElement(ObjectRepository.MyProfileOrgsIconToDelete).Click();

                }
                driverobj.GetElement(ObjectRepository.edituserworkinfo_saveorok).Click();
                Thread.Sleep(4000);
                driverobj.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }


        }

     

        public void loginwithchangeid(string password)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.login_id);
                driverobj.GetElement(ObjectRepository.login_id).SendKeys("change_" + ObjectRepository.newuserloginid);
                driverobj.GetElement(ObjectRepository.login_password).SendKeys(password);
                driverobj.GetElement(ObjectRepository.signin_button).Click();
                driverobj.WaitForElement(ObjectRepository.login_name);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public string ChangeUserId()
        {
            string actualresult = string.Empty;
            try
            {
                Thread.Sleep(3000);
                driverobj.HoverLinkClick(ObjectRepository.MyAccountHoverLink, ObjectRepository.MyAccountHoverLink);//need to check this line
                Thread.Sleep(3000);


                driverobj.GetElement(ObjectRepository.EditLoginIdBtn).Click();
                Thread.Sleep(2000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(ObjectRepository.OldUserId).Clear();
                driverobj.GetElement(ObjectRepository.OldUserId).SendKeys(ObjectRepository.newuserloginid);
                driverobj.GetElement(ObjectRepository.NewUserId).Clear();
                driverobj.GetElement(ObjectRepository.NewUserId).SendKeys("change_" + ObjectRepository.newuserloginid);
                driverobj.GetElement(ObjectRepository.SaveChangedUserIdBtn).Click();

                driverobj.WaitForElement(ObjectRepository.sucessmessage);
                actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                loginwithchangeid(ExtractDataExcel.MasterDic_newuser["Password"].ToString());

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return actualresult;
        }

        public string ChangePassword()
        {
            string actualresult = string.Empty;
            try
            {

                driverobj.HoverLinkClick(ObjectRepository.MyAccountHoverLink, ObjectRepository.MyAccountHoverLink);//need to check this line
               
                driverobj.GetElement(ObjectRepository.EditPasswordBtn).Click();
                Thread.Sleep(2000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(ObjectRepository.OldPassword).SendKeys(ExtractDataExcel.MasterDic_newuser["Password"].ToString());
                driverobj.GetElement(ObjectRepository.NewPassword).SendKeys(ExtractDataExcel.MasterDic_newuser["Password"].ToString()+ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ObjectRepository.ConfirmNewPassword).SendKeys(ExtractDataExcel.MasterDic_newuser["Password"].ToString() + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ObjectRepository.SaveChangedPasswordBtn).Click();
                driverobj.WaitForElement(ObjectRepository.sucessmessage);
                actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                loginwithchangeid(ExtractDataExcel.MasterDic_newuser["Password"].ToString() + ExtractDataExcel.token_for_reg);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return actualresult;
        }

        public string ChangeSecurityQuestion()
        {

            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.NewUser();
                Thread.Sleep(3000);
                driverobj.HoverLinkClick(ObjectRepository.MyAccountHoverLink, ObjectRepository.MyAccountHoverLink);//need to check this line
                //driverobj.WaitForElement(ObjectRepository.EditsecurityquestionBtn);
                driverobj.GetElement(ObjectRepository.EditsecurityquestionBtn).Click();
                Thread.Sleep(2000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                //driverobj.FindSelectElementnew(By.Id("ctl00_MainContent_UC1_rlvQuestions_ctrl0_MQuestion"), "What is the name of your favorite childhood friend?");
                //driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rlvQuestions_ctrl0_MAnswer")).Clear();
                //driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rlvQuestions_ctrl0_MAnswer")).SendKeys("Friend1");
                IWebElement securityquestion = driverobj.GetElement(ObjectRepository.securityquestion);
                SelectElement selector = new SelectElement(securityquestion);
                selector.SelectByIndex(1);
                //driverobj.GetElement(By.XPath("id('"+ObjectRepository.securityquestion+"')/option[3]")).Click();
                driverobj.GetElement(ObjectRepository.securityanswer).Clear();
                driverobj.GetElement(ObjectRepository.securityanswer).SendKeys("test1");

                driverobj.GetElement(ObjectRepository.SavesecurityquestiondBtn).Click();
                driverobj.WaitForElement(ObjectRepository.sucessmessage);
                actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }


            return actualresult;
        }


        //objects for account updation
        private By LinkMyAccount = By.XPath("//a[normalize-space()='Account']");
        private By BtnUserInfoEdit = By.Id("MainContent_UCProfile_ucUserInfo_lnkEdit");
        private By txtuseremail = By.Id("MainContent_UC1_FormView1_USR_EMAIL_ADDRESS");
        private By txtuserworkphone = By.Id("MainContent_UC1_FormView1_USR_WORK_PHONE");
        private By txtuserworkphoneext = By.Id("MainContent_UC1_FormView1_USR_WORK_PHONE_EXT");
        private By txtuserhomephone = By.Id("MainContent_UC1_FormView1_USR_HOME_PHONE");
        private By txtusermobile = By.Id("MainContent_UC1_FormView1_USR_MOBILE_PHONE");
        private By txtuserstreet = By.Id("MainContent_UC1_FormView1_USR_STREET_ADDRESS");
        private By txtusercity = By.Id("MainContent_UC1_FormView1_USR_CITY");
        private By cmbuserstate = By.Id("MainContent_UC1_FormView1_USR_STATE_ID");
        private By txtuserpostal = By.Id("MainContent_UC1_FormView1_USR_POSTAL_CODE");
        private By saveaccountsectiondetail = By.Id("MainContent_UC1_Save");
        private By BtnWorkInfoEdit = By.Id("MainContent_UCProfile_ucWorkInfo_lnkEdit");
        private By LinkManagerSectionOpen = By.Id("MainContent_UC1_FormView1_HyperLink1");
        private By BtnSearchManager = By.Id("MainContent_UC1_btnSearch");
        private By ChkManagerlist = By.XPath("//input[contains(@id, '_chkSelect')]");
        private By BtnSaveMnager = By.Id("MainContent_UC1_FormView1_Save");


        private By LinkproxySectionOpen = By.Id("MainContent_UC1_FormView1_MHyperLink1");
        private By BtnSearchproxy = By.Id("MainContent_UC1_btnSearch");
        private By Chkproxylist = By.XPath("//input[contains(@id, '_chkSelect')]");
        private By BtnSaveproxy = By.Id("MainContent_UC1_FormView1_Save");
        private By txtcompanyname = By.Id("MainContent_UC1_FormView1_USR_COMPANY");
        private By txtcompanystreet = By.Id("MainContent_UC1_FormView1_USR_WORK_STREET_ADDRESS");
        private By txtcompanycity = By.Id("MainContent_UC1_FormView1_USR_WORK_CITY");
        private By cmbcompanystate = By.Id("MainContent_UC1_FormView1_USR_WORK_STATE_ID");
        private By txtcompanypostal = By.Id("MainContent_UC1_FormView1_USR_WORK_POSTAL_CODE");
        private By btnchangeshippingadd = By.Id("MainContent_UC1_MButton1");
        private By cmbappid = By.Id("MainContent_UC1_FormView1_USR_APPTMT_TYPE_ID");
        private By txtpayplancode = By.Id("MainContent_UC1_FormView1_USR_PAY_PLAN_CODE");
        private By txtusrseries = By.Id("MainContent_UC1_FormView1_USR_SERIES");
        private By BtnQualificationEdit = By.Id("MainContent_UCProfile_ucQualification_lnkEdit");
        private By cmbeducationlevel = By.Id("MainContent_UC1_FormView1_USR_EDUCATION_LEVEL_ID");
        private By userqualificationeducationdescription = By.Id("MainContent_UC1_FormView1_USR_EDUCATION_DESCRIPTION");
        private By userqualificationexpertise = By.Id("MainContent_UC1_FormView1_USR_EXPERTISE");
        private By userqualificationjoddescription = By.Id("MainContent_UC1_FormView1_USR_JOB_DESCRIPTION");
        private By BtnEHRIEdit = By.Id("MainContent_UCProfile_ucEHRI_lnkEdit");
        private By txtssnno = By.Id("MainContent_UC1_FormView1_EHRI_EMPL_NUMBER");
        private By txtdob = By.Id("ctl00_MainContent_UC1_FormView1_EHRI_DATE_OF_BIRTH_dateInput");
        private By sucessmessage = By.CssSelector("div.forms-msg-success");
        private By frmsucessmessage = By.ClassName("forms-msg-success");
        private By edituserpref = By.Id("MainContent_UCProfile_ucPreferences_lnkEdit");
        // private By edituserpref = By.Id("(MainContent_UCProfile_ucPreferences_lnkEdit");
        // public static By userprefshowlanguage = By.Id("MainContent_UC1_FormView1_USR_508C_OPTION");
        private By userprefshowcontactinfo = By.Id("MainContent_UC1_FormView1_USR_SHOW_CONTACT_INFO");
        private By userpreshowprofessionalinfo = By.Id("MainContent_UC1_FormView1_USR_SHOW_PROFESSIONAL_INFO");
        private By userprefcommunicationemail = By.Id("MainContent_UC1_FormView1_USR_COMMUNICATION_EMAIL");
        private By userprefcommunicationmessage = By.Id("MainContent_UC1_FormView1_USR_COMMUNICATION_MESSAGES");
        
        private By userpreflocallanguage = By.Id("MainContent_UC1_FormView1_USR_REGION_LOCALE_ID");
        private By userpreflocalregion = By.Id("MainContent_UC1_FormView1_USR_REGION_LOCALE_ID");
        private By userpreftimezone = By.Id("MainContent_UC1_FormView1_USR_TIME_ZONE_ID");
        private By userpreftheme = By.Id("MainContent_UC1_FormView1_STYLESHEET");
        private By userprefpagesize = By.Id("MainContent_UC1_FormView1_PAGE_SIZE");
        private By userprefsave = By.Id("MainContent_UC1_Save");

        private By edituserworkinfo_config_enablemultiplejobtitle = By.Id("TabMenu_ML_BASE_HEAD_Users_ENABLE_USERMULTIPLEJOBTITLES_1");
        private By edituserworkinfo_config_enablemultipleorg = By.Id("TabMenu_ML_BASE_HEAD_Users_ENABLE_USERMULTIPLEORGANIZATIONS_1");
        private By edituserworkinfo_config_enablemultiplemanagers = By.Id("TabMenu_ML_BASE_HEAD_Users_ENABLE_USERMULTIPLEMANAGERS_1");
        private By adminsavescheduletaskauthorizeuser = By.Id("ML.BASE.BTN.Save");

        private By ViewPermissionbtn = By.Id("MainContent_UCProfile_ucRoleInformation_lnkView");
        private By ViewPermissionlbl = By.Id("MainContent_UC1_Literal1");
        private By Cloasepermission = By.Id("MainContent_UC1_Cancel");

        private By adminconsoleopenlink = By.Id("NavigationStrip1_lbAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By adminconfigconsole = By.XPath("//a[contains(text(),'Configuration Console (Home)')]");
        private By adminconsole_config_users = By.LinkText("Users");
        private By returnbutton = By.Id("Return");
        private By permissioncount = By.XPath("//div[@id='MainContent_UCProfile_ucRoleInformation_FormView1_pnlCustomFields']/div[7]/span");

    }

}

