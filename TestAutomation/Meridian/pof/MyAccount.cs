using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.ObjectModel;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace Selenium2.Meridian
{
    class MyAccount
    {
        private readonly IWebDriver driverobj;

        public MyAccount(IWebDriver driver)
        {
            driverobj = driver;
        }
        public string ChangeUserId(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(EditLoginIdBtn);
                driverobj.GetElement(EditLoginIdBtn).ClickAnchor();
               
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(OldUserId);
                driverobj.GetElement(OldUserId).Clear();
                driverobj.GetElement(OldUserId).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "tochange");
                driverobj.GetElement(NewUserId).Clear();
                driverobj.GetElement(NewUserId).SendKeysWithSpace("change_" + ExtractDataExcel.MasterDic_newuser["Id"]+browserstr + "tochange");
                driverobj.GetElement(SaveChangedUserIdBtn).ClickWithSpace();
                driverobj.SwitchtoDefaultContent();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;
        }

        public string ChangePassword()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(EditPasswordBtn);
                driverobj.GetElement(EditPasswordBtn).ClickWithSpace();
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                driverobj.WaitForElement(OldPassword);
                driverobj.GetElement(OldPassword).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"].ToString());
                driverobj.GetElement(NewPassword).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"].ToString() + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ConfirmNewPassword).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Password"].ToString() + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(SaveChangedPasswordBtn).ClickWithSpace();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;
        }

        public string ChangeSecurityQuestion()
        {

            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(EditsecurityquestionBtn);
                driverobj.GetElement(EditsecurityquestionBtn).ClickWithSpace();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(securityquestion);
                driverobj.getcomboitemselected(securityquestion, 1);
                driverobj.GetElement(securityanswer).Clear();
                driverobj.GetElement(securityanswer).SendKeysWithSpace("test1");
                driverobj.GetElement(SavesecurityquestiondBtn).ClickWithSpace();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return actualresult;
        }

        public string MyProfileEditUserInfo()
        {
            string actualresult = string.Empty;
            try
            {
                //driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(BtnUserInfoEdit);
                driverobj.GetElement(BtnUserInfoEdit).ClickAnchor();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(txtuseremail);
                driverobj.GetElement(txtuseremail).SendKeysWithSpace("testsf");
                driverobj.GetElement(txtuserworkphone).SendKeysWithSpace("12345678");
                driverobj.GetElement(txtuserworkphoneext).SendKeysWithSpace("123");
                driverobj.GetElement(txtuserhomephone).SendKeysWithSpace("12345678");
                driverobj.GetElement(txtusermobile).SendKeysWithSpace("12345678");
                driverobj.GetElement(txtuserstreet).SendKeysWithSpace("test address");
                driverobj.GetElement(txtusercity).SendKeysWithSpace("test city");
                driverobj.getcomboitemselected(cmbuserstate, 1);
                driverobj.GetElement(txtuserpostal).SendKeysWithSpace("123456");
                driverobj.GetElement(saveaccountsectiondetail).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(frmsucessmessage);
                actualresult = driverobj.GetElement(frmsucessmessage).Text;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public string MyProfileEditQualification()
        {
            string actualresult = string.Empty;
            try
            {
                //driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(BtnQualificationEdit);
                driverobj.ClickEleJs(BtnQualificationEdit);
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.getcomboitemselected(cmbeducationlevel, 1);
                driverobj.GetElement(userqualificationeducationdescription).Clear();
                driverobj.GetElement(userqualificationeducationdescription).SendKeysWithSpace("computer science");
                driverobj.GetElement(userqualificationexpertise).Clear();
                driverobj.GetElement(userqualificationexpertise).SendKeysWithSpace("selenium");
                driverobj.GetElement(userqualificationjoddescription).Clear();
                driverobj.GetElement(userqualificationjoddescription).SendKeysWithSpace("5 years");
                driverobj.GetElement(saveaccountsectiondetail).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public string MyProfileEditPreferences()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(edituserpref);
                driverobj.ClickEleJs(edituserpref);
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(userpreflocalregion);
                driverobj.FindSelectElementnew(userpreflocalregion, "English (United States)");
                driverobj.FindSelectElementnew(userpreftimezone, "(GMT-05:00) Eastern Time (US and Canada)");
                driverobj.getcomboitemselected(userprefpagesize, 1);
                driverobj.GetElement(ObjectRepository.userprefsave).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchtoDefaultContent();
                driverobj.WaitForElement(frmsucessmessage);
                actualresult = driverobj.GetElement(frmsucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public string MyProfileEditWorkInformation()
        {
            string actualresult = string.Empty;
            try
            {


                //driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(BtnWorkInfoEdit);
                driverobj.GetElement(BtnWorkInfoEdit).ClickWithSpace();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(LinkManagerSectionOpen);
                driverobj.GetElement(LinkManagerSectionOpen).ClickWithSpace();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(BtnSearchManager);
                driverobj.GetElement(BtnSearchManager).ClickWithSpace();
                Thread.Sleep(3000);
                //IList<IWebElement> managerstoselect = driverobj.FindElements(ChkManagerlist);
                //managerstoselect[0].ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td/input"));
                IWebElement element = driverobj.FindElement(By.XPath("//td/input"));

                IJavaScriptExecutor executor = (IJavaScriptExecutor)driverobj;

                executor.ExecuteScript("arguments[0].click();", element);
              //  driverobj.GetElement(By.XPath("//td/input")).ClickChkBox();
                driverobj.GetElement(BtnSaveMnager).ClickWithSpace();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                //driverobj.SwitchTo().DefaultContent();
                //Thread.Sleep(5000);
                //driverobj.SelectFrame();

                //driverobj.GetElement(LinkproxySectionOpen).ClickWithSpace();
                //Thread.Sleep(7000);
                //driverobj.SelectFrame();
                //driverobj.GetElement(BtnSearchproxy).ClickWithSpace();
                //Thread.Sleep(7000);
                //driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect"));
                //driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect")).ClickWithSpace();
                ////IList<IWebElement> proxystoselect = driverobj.FindElements(Chkproxylist);
                ////proxystoselect[0].Click();
                //driverobj.GetElement(BtnSaveproxy).ClickWithSpace();
                //Thread.Sleep(5000);
                //driverobj.SwitchTo().DefaultContent();
                //Thread.Sleep(5000);
                //driverobj.SelectFrame();


                driverobj.WaitForElement(txtcompanyname);
                driverobj.GetElement(txtcompanyname).SendKeysWithSpace("test company");
                driverobj.GetElement(txtcompanystreet).SendKeysWithSpace("test address");
                driverobj.GetElement(txtcompanycity).SendKeysWithSpace("test city");
                driverobj.getcomboitemselected(cmbcompanystate, 1);
                driverobj.GetElement(txtcompanypostal).SendKeysWithSpace("123456");
                //driverobj.getcomboitemselected(cmbappid);
                //driverobj.GetElement(txtpayplancode).SendKeysWithSpace("AA");
                //driverobj.GetElement(txtusrseries).SendKeysWithSpace("1234");
                driverobj.ClickEleJs(saveaccountsectiondetail);
                Thread.Sleep(3000);
                driverobj.SwitchtoDefaultContent();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool SelectManager(String ManagerName)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(BtnWorkInfoEdit);
                driverobj.GetElement(BtnWorkInfoEdit).ClickWithSpace();
                Thread.Sleep(3000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(LinkManagerSectionOpen).ClickWithSpace();
                Thread.Sleep(7000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(txt_SearchManager).SendKeysWithSpace(ManagerName);
                driverobj.GetElement(BtnSearchManager).ClickWithSpace();
                Thread.Sleep(7000);
                IList<IWebElement> managerstoselect = driverobj.FindElements(ChkManagerlist);
                managerstoselect[0].ClickWithSpace();
                driverobj.GetElement(BtnSaveMnager).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(saveaccountsectiondetail).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(sucessmessage);

                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public string MyProfileedituserdata()
        {
            string actualresult = string.Empty;
            try
            {
                string format = "MM/dd/yyyy";
                driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(BtnEHRIEdit);
                driverobj.GetElement(BtnEHRIEdit).ClickWithSpace();
                Thread.Sleep(3000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(txtssnno).Clear();
                driverobj.GetElement(txtssnno).SendKeysWithSpace("123-45-6789");
                Thread.Sleep(2000);
                driverobj.GetElement(txtdob).Clear();
                driverobj.GetElement(txtdob).SendKeysWithSpace(DateTime.Now.ToString(format));
                driverobj.GetElement(saveaccountsectiondetail).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;

        }

        public string MyProfileeditshippingaddress()
        {
            string actualresult = string.Empty;
            try
            {

                string format = "MM/dd/yyyy";
                //driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(btn_editshipping);
                driverobj.ClickEleJs(btn_editshipping);
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(By.XPath("//input[@id='SI_SHIP_TO_STREET']"));
                driverobj.WaitForElement(By.XPath("//input[@id='SI_SHIP_TO_NAME']"));
                    driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_NAME']")).Clear();
                    driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_NAME']")).SendKeysWithSpace("automateinfo");
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_STREET']")).Clear();
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_STREET']")).SendKeysWithSpace("485 Wildwood North Circle, Homewood");
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_CITY']")).Clear();
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_CITY']")).SendKeysWithSpace("Birmingham");

                  driverobj.FindSelectElementnew(By.XPath("//select[@id='SI_SHIP_TO_COUNTRY_ID']"), "UNITED STATES");
                  driverobj.FindSelectElementnew(By.XPath("//select[@id='SI_SHIP_TO_STATE_ID']"), "Alabama");
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_ZIP']")).Clear();
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_ZIP']")).SendKeysWithSpace("35209");
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_PHONE']")).Clear();
                driverobj.GetElement(By.XPath("//input[@id='SI_SHIP_TO_PHONE']")).SendKeysWithSpace("123456789");
                Thread.Sleep(2000);

                driverobj.ClickEleJs(By.Id("MainContent_UC1_btnSave"));
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.XPath("//*[@id='MainContent_UCProfile_pnlShippingInfo']/ul/li[1]/strong"));
                actualresult = driverobj.GetElement(By.XPath("//*[@id='MainContent_UCProfile_pnlShippingInfo']/ul/li[1]/strong")).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;

        }
        public string MyProfileviewroleandpermission()
        {
            string actualresult = string.Empty;
            try
            {

                //driverobj.OpenToolbarItems(LinkMyAccount);
                driverobj.WaitForElement(ViewPermissionbtn); 
                string totalpermissionstring = driverobj.GetElement(permissioncount).Text;
                int totalpermission =Convert.ToInt32( Regex.Replace(totalpermissionstring, "[^0-9]", ""));
                driverobj.GetElement(ViewPermissionbtn).ClickWithSpace();
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(ViewPermissionlbl);
                actualresult = driverobj.GetElement(ViewPermissionlbl).Text;
                int cnt = 0;
                if(totalpermission>10)
                {
                    cnt = 10;

                }
                else
                {
                    cnt = totalpermission;
                }
                for (int i = 0; i < cnt; i++)
                {
                    driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00__" + i));
                }

                driverobj.GetElement(Cloasepermission).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(ViewPermissionbtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;

        }

        public void cofigureforselectingmultipleuser()
        {
            try
            {
                driverobj.ClickEleJs(ObjectRepository.adminconsoleopenlink);
                Thread.Sleep(5000);
                driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(adminconfigconsole);
                driverobj.ClickEleJs(adminconfigconsole);
                driverobj.WaitForElement(adminconsole_config_users);
                driverobj.GetElement(adminconsole_config_users).ClickWithSpace();
                driverobj.WaitForElement(edituserworkinfo_config_enablemultiplejobtitle);
                driverobj.GetElement(edituserworkinfo_config_enablemultiplejobtitle).ClickWithSpace();
                driverobj.GetElement(edituserworkinfo_config_enablemultipleorg).ClickWithSpace();
                driverobj.GetElement(edituserworkinfo_config_enablemultiplemanagers).ClickWithSpace();
                driverobj.GetElement(adminsavescheduletaskauthorizeuser).ClickWithSpace();
                driverobj.WaitForElement(returnbutton);
                driverobj.GetElement(returnbutton).ClickWithSpace();
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

        }

        public void addjobtitle(int setlimit)
        {
            try
            {
                driverobj.GetElement(ObjectRepository.edituserworkinfo_addjobtitle).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(ObjectRepository.edituserworkinfo_search).ClickWithSpace();
                Thread.Sleep(5000);
                IList<IWebElement> jobtitlestoselect = driverobj.FindElements(ObjectRepository.edituserworkinfo_checkoptions);
                for (int i = 0; i <= jobtitlestoselect.Count - 1; i++)
                {
                    if (i >= setlimit)
                    {
                        break;
                    }

                    jobtitlestoselect[i].ClickWithSpace();
                }

                driverobj.GetElement(ObjectRepository.editworkinfo_FormView1_Save).ClickWithSpace();
                driverobj.findandacceptalert();
                Thread.Sleep(4000);
                driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(4000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }

         public bool Click_AllMyRequest()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_AllRequest);
                driverobj.WaitForElement(lbl_paindingapprovalcount);
                string noofpending = driverobj.GetElement(lbl_paindingapprovalcount).Text;
                noofpending = Regex.Replace(noofpending, "[^0-9]", "");
                driverobj.GetElement(lnk_AllRequest).ClickWithSpace();
                driverobj.WaitForElement(lnk_requestfirstitem);
                if (noofpending != string.Empty)
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
         public string Click_GoToMeetingAndSelectConnector(string linktext)
         {
             string actualresult = string.Empty;
             try
             {
                 driverobj.WaitForElement(lnk_GoToMeeting);

                 driverobj.GetElement(lnk_GoToMeeting).ClickWithSpace();
                 //driverobj.SelectFrame();
                 driverobj.waitforframe(ObjectRepository.switchToFrame_New);   
                 driverobj.WaitForElement(By.XPath("//a[contains(.,'" + linktext + "')]"));
                 driverobj.GetElement(By.XPath("//a[contains(.,'" + linktext + "')]")).ClickWithSpace();
                 driverobj.WaitForElement(txt_SelfRegisterUsername);
                 driverobj.GetElement(txt_SelfRegisterUsername).SendKeysWithSpace(ExtractDataExcel.MasterDic_GoToMeeting["Name"]);
                 driverobj.GetElement(txt_SelfRegisterPassword).SendKeysWithSpace(ExtractDataExcel.MasterDic_GoToMeeting["Password"]);
                 driverobj.GetElement(btn_SelfRegisterValidate).ClickWithSpace();
                 driverobj.WaitForElement(btn_SelfRegisterDone);
                 driverobj.GetElement(btn_SelfRegisterDone).ClickWithSpace();
                 Thread.Sleep(2000);
                 driverobj.SwitchTo().DefaultContent();
                 Thread.Sleep(2000);
                 driverobj.WaitForElement(txt_SelfRegisterFeedbackMsg);
                 actualresult = driverobj.GetElement(txt_SelfRegisterFeedbackMsg).Text.ToString();


             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }
             return actualresult;
         }
         public string Click_AdobeConnectAndSelectConnector(string linktext)
         {
             string actualresult = string.Empty;
             try
             {
                 driverobj.WaitForElement(lnk_AdobeConnect);

                 driverobj.GetElement(lnk_AdobeConnect).ClickWithSpace();
                 //driverobj.SelectFrame();
                 driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                 driverobj.WaitForElement(By.XPath("//a[contains(.,'" + linktext + "')]"));
                 driverobj.GetElement(By.XPath("//a[contains(.,'" + linktext + "')]")).ClickWithSpace();
                 driverobj.WaitForElement(txt_SelfRegisterUsername);
                 driverobj.GetElement(txt_SelfRegisterUsername).SendKeysWithSpace(ExtractDataExcel.MasterDic_Adobe["Name"]);
                 driverobj.GetElement(txt_SelfRegisterPassword).SendKeysWithSpace(ExtractDataExcel.MasterDic_Adobe["Password"]);
                 driverobj.GetElement(btn_SelfRegisterValidate).ClickWithSpace();
                 driverobj.WaitForElement(btn_SelfRegisterDone);
                 driverobj.GetElement(btn_SelfRegisterDone).ClickWithSpace();
                 Thread.Sleep(2000);
                 driverobj.SwitchTo().DefaultContent();
                 Thread.Sleep(2000);
                 driverobj.WaitForElement(txt_SelfRegisterFeedbackMsg);
                 actualresult = driverobj.GetElement(txt_SelfRegisterFeedbackMsg).Text.ToString();


             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }
             return actualresult;
         }
         public string Click_GoToTrainingAndSelectConnector(string linktext)
         {
             string actualresult = string.Empty;
             try
             {
                 driverobj.WaitForElement(lnk_GoToTraining);

                 driverobj.GetElement(lnk_GoToTraining).ClickWithSpace();
                 //driverobj.SelectFrame();
                 driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                 driverobj.WaitForElement(By.XPath("//a[contains(.,'" + linktext + "')]"));
                 driverobj.GetElement(By.XPath("//a[contains(.,'" + linktext + "')]")).ClickWithSpace();
                 driverobj.WaitForElement(txt_SelfRegisterUsername);
                 driverobj.GetElement(txt_SelfRegisterUsername).SendKeysWithSpace(ExtractDataExcel.MasterDic_GoToTraining["Name"]);
                 driverobj.GetElement(txt_SelfRegisterPassword).SendKeysWithSpace(ExtractDataExcel.MasterDic_GoToTraining["Password"]);
                 driverobj.GetElement(btn_SelfRegisterValidate).ClickWithSpace();
                 driverobj.WaitForElement(btn_SelfRegisterDone);
                 driverobj.GetElement(btn_SelfRegisterDone).ClickWithSpace();
                 Thread.Sleep(2000);
                 driverobj.SwitchTo().DefaultContent();
                 Thread.Sleep(2000);
                 driverobj.WaitForElement(txt_SelfRegisterFeedbackMsg);
                 actualresult = driverobj.GetElement(txt_SelfRegisterFeedbackMsg).Text.ToString();


             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }
             return actualresult;
         }
         public bool ClickPurchaseHistory(string browserstr)
         {
             try
             {
                 driverobj.WaitForElement(lnk_MyPurchase);
                 driverobj.ClickEleJs(lnk_MyPurchase);
              return   driverobj.existsElement(By.Id("MainContent_UC1_lnkRedeemAccessKeys"));
               
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


                 return false;
             }

         }


          public bool ClickAccountTab()
         {
             try
             {
                 driverobj.WaitForElement(tab_account);
                 driverobj.ClickEleJs(tab_account);
                 driverobj.WaitForElement(ViewPermissionbtn);
                 return true;
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


                 return false;
             }

         }

          public bool ClickProfileTab()
          {
              try
              {
                  driverobj.WaitForElement(tab_profile);
                  driverobj.ClickEleJs(tab_profile);
                  driverobj.WaitForElement(BtnUserInfoEdit);
                  return true;
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


                  return false;
              }

          }

          public bool ClickPreferencesTab()
          {
              try
              {
                  driverobj.WaitForElement(tab_preferences);
                  driverobj.ClickEleJs(tab_preferences);
                  driverobj.WaitForElement(edituserpref);
                  return true;
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


                  return false;
              }

          }

          public bool ClickEcommerceTab()
          {
              try
              {
                  driverobj.WaitForElement(tab_ecommerce);
                  driverobj.GetElement(tab_ecommerce).ClickWithSpace();
                  driverobj.WaitForElement(btn_editshipping);
                  return true;
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                  return false;
              }

          }

          public bool EditPreferences_ForLanguage()
          {
              string actualresult = string.Empty;
              try
              {
                  driverobj.WaitForElement(edituserpref);
                  driverobj.GetElement(edituserpref).ClickWithSpace();
                  driverobj.waitforframe(By.ClassName("k-content-frame"));
                  driverobj.WaitForElement(userpreflocalregion);
                  driverobj.GetElement(By.ClassName("multiselect-selected-text")).Click();
                  List<IWebElement> allLanguages = driverobj.FindElements(By.ClassName("checkbox")).ToList();
                  allLanguages[0].Click();
                  driverobj.GetElement(ObjectRepository.userprefsave).ClickWithSpace();
                  Thread.Sleep(4000);
                  driverobj.SwitchTo().DefaultContent();
                  if (!driverobj.existsElement(frmsucessmessage)) { return false; }
                  return true;
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                  return false;
              }
          }

         private By txt_SearchManager = By.Id("MainContent_UC1_txtSearch");
        private By EditLoginIdBtn = By.Id("lnkLoginEdit");
        private By OldUserId = By.Id("MainContent_UC1_OldLoginId");
        private By NewUserId = By.Id("MainContent_UC1_USR_LOGIN_ID");
        private By SaveChangedUserIdBtn = By.Id("MainContent_UC1_Save");

        private By EditPasswordBtn = By.Id("lnkPasswordEdit");
        private By OldPassword = By.Id("MainContent_UC1_CurrentPassword");
        private By NewPassword = By.Id("MainContent_UC1_USR_PASSWORD");
        private By ConfirmNewPassword = By.Id("MainContent_UC1_ConfirmPassword");
        private By SaveChangedPasswordBtn = By.Id("MainContent_UC1_Save");


        private By pagehavingtitle = By.TagName("Title");

        private By EditsecurityquestionBtn = By.Id("lnkSecurityQuestionsEdit");
        private By securityquestion = By.Id("ctl00_MainContent_UC1_rlvQuestions_ctrl0_MQuestion");
        private By securityanswer = By.Id("ctl00_MainContent_UC1_rlvQuestions_ctrl0_MAnswer");
        private By SavesecurityquestiondBtn = By.Id("MainContent_UC1_Save");


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
        private By LinkManagerSectionOpen = By.XPath("//a[text()='Select Manager']");
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
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");
        private By frmsucessmessage = By.XPath("//div[@class='alert alert-success']");
        private By edituserpref = By.Id("MainContent_UCProfile_ucPreferences_FormView1_lnkEdit");
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

        private By ViewPermissionbtn = By.Id("MainContent_UCProfile_lnkViewRoles");
        private By ViewPermissionlbl = By.Id("MainContent_UC1_Literal1");
        private By Cloasepermission = By.Id("MainContent_UC1_Cancel");

        private By adminconsoleopenlink = By.Id("NavigationStrip1_lbAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By adminconfigconsole = By.XPath("//a[contains(text(),'Configuration Console (Home)')]");
        private By adminconsole_config_users = By.LinkText("Users");
        private By returnbutton = By.Id("Return");
        private By permissioncount = By.XPath("/html/body/form/div[7]/div/div/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/span[1]");

       
        private By lnk_AllRequest = By.Id("MainContent_ucAddlLinksMyRequests_lnkMyRequests");
        private By lbl_paindingapprovalcount = By.XPath("//div[@id='content']/div[2]/div/ul[1]/li[1]");
        private By lnk_requestfirstitem = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");

        private By lnk_MyPurchase = By.Id("MainContent_UCProfile_ucMyPurchases_lnkMyPurchases");
        private By lnk_GoToMeeting = By.Id("MainContent_ucAddLinksMyIntegrations_lnkEditVirtualEvent");
        private By lnk_AdobeConnect = By.Id("MainContent_ucAddLinksMyIntegrations_lnkADBEditVirtualEvent");
        private By lnk_GoToTraining = By.Id("MainContent_ucAddLinksMyIntegrations_lnkGTTEditVirtualEvent");
        private By txt_SelfRegisterUsername = By.Id("username");
        private By txt_SelfRegisterPassword = By.Id("password");
        private By btn_SelfRegisterValidate = By.Id("MainContent_UC1_btnValidate");
        private By btn_SelfRegisterDone = By.Id("MainContent_UC1_btnDone1");
        private By txt_SelfRegisterFeedbackMsg = By.Id("host-receipt");

        private By tab_account =By.XPath("//div[@id='content']/div/div/ul/li[1]/a");//-account
        private By tab_profile =By.XPath("//div[@id='content']/div/div/ul/li[2]/a");//-profile
        private By tab_preferences =By.XPath("//div[@id='content']/div/div/ul/li[3]/a");//-preferences
        private By tab_ecommerce =By.XPath("//div[@id='content']/div/div/ul/li[4]/a");//-Ecommerce
        
        
        private By btn_editshipping =By.Id("MainContent_UCProfile_ucShippingInfo_lnkEdit");//shippinginfo
       
       

    }
}
