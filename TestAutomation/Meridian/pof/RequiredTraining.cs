using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class RequiredTraining
    {
        private readonly IWebDriver driverobj;
        public RequiredTraining(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Assigntraining()
        {
            try
            {
                driverobj.WaitForElement(RequiredTraining_GoProfile_Button);
             //   driverobj.GetElement(RequiredTraining_GoProfile_Button).ClickWithSpace();
                //SelectElement selProfile = new SelectElement(driver.GetElement(Locator_RequiredTraining.RequiredTraining_SelectProfile_Dropdown));
                //selProfile.SelectByValue("ML.BASE.ACT.AssignTrainingWithoutDeadline");
                driverobj.WaitForElement(RequiredTraining_SelectProfile_Dropdown);
                driverobj.select(RequiredTraining_SelectProfile_Dropdown, "Assign Training Without Deadline");
             //   driverobj.GetElement(RequiredTraining_GoProfile_Button).ClickWithSpace();
                driverobj.ClickEleJs(RequiredTraining_GoProfile_Button);

                driverobj.WaitForElement(RequiredTraining_Search_Button);
                driverobj.ClickEleJs(RequiredTraining_Search_Button);

                driverobj.WaitForElement(RequiredTraining_AssignTraining_Button);
                driverobj.WaitForElement(RequiredTraining_Title_Checkbox);
                //driverobj.GetElement(RequiredTraining_Title_Checkbox).ClickWithSpace();
                driverobj.ClickEleJs(RequiredTraining_Title_Checkbox);
                driverobj.GetElement(RequiredTraining_AssignTraining_Button).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool AssigntrainingCourse(string course,string user)
        {
            try
            {
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ManagerRole"));
                driverobj.select(By.Id("TabMenu_ML_BASE_TAB_Search_ManagerRole"), "Other");
                driverobj.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));
                driverobj.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeysWithSpace(course);
                driverobj.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")).ClickWithSpace();

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ReqTrainingContent_GoButton_1"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ReqTrainingContent_GoButton_1")).ClickWithSpace();
                //SelectElement selProfile = new SelectElement(driver.GetElement(Locator_RequiredTraining.RequiredTraining_SelectProfile_Dropdown));
                //selProfile.SelectByValue("ML.BASE.ACT.AssignTrainingWithoutDeadline");
                driverobj.select(RequiredTraining_SelectProfile_Dropdown, "Assign Training Without Deadline");
                driverobj.GetElement(RequiredTraining_GoProfile_Button).ClickWithSpace();

                driverobj.WaitForElement(RequiredTraining_Search_Button);
               // driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).SendKeysWithSpace(user);
                driverobj.GetElement(RequiredTraining_Search_Button).ClickWithSpace();

                driverobj.WaitForElement(RequiredTraining_AssignTraining_Button);
                driverobj.WaitForElement(RequiredTraining_Title_Checkbox);
                driverobj.ClickEleJs(RequiredTraining_Title_Checkbox);
                driverobj.GetElement(RequiredTraining_AssignTraining_Button).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool selectProfile()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(RequiredTraining_SelectProfile_Dropdown);
                
                driverobj.select(RequiredTraining_SelectProfile_Dropdown, "Select Profile");
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SelectProfileGoBtn()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(RequiredTraining_GoProfile_Button);
            //    driverobj.GetElement(RequiredTraining_GoProfile_Button).ClickWithSpace();
                driverobj.ClickEleJs(RequiredTraining_GoProfile_Button);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_SearchUserforAssignTraining()
        {
            bool actualresult = false;
            try
            {
                
                driverobj.WaitForElement(txt_searchuser_assigntraining);
                driverobj.GetElement(txt_searchuser_assigntraining).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Firstname"]);
             //   driverobj.GetElement(btn_searchuser_assigntraining).ClickWithSpace();
                driverobj.ClickEleJs(btn_searchuser_assigntraining);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SearchUserforAssignTraining_ForGC(string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_searchuser_assigntraining);
                driverobj.GetElement(txt_searchuser_assigntraining).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr);
                driverobj.GetElement(btn_searchuser_assigntraining).Click();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Click_SelectUserforTraining()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div/table/tbody/tr[2]/td/div[1]/table[3]/tbody/tr[3]/td[2]/span/input"));
              //  driverobj.GetElement(chk_selectuser).Click();

// driverobj.ClickEleJs(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_4_ENTITY_LIST_1_3_ML.CodeManager_P_']"));
                if (driverobj.existsElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div/table/tbody/tr[2]/td/div[1]/table[3]/tbody/tr[3]/td[2]/span/input")))
              {
                //  driverobj.GetElement(By.XPath(".//*[contains(.,'user, regadmin')]/../td/span")).ClickAnchor();
                    driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div/table/tbody/tr[2]/td/div[1]/table[3]/tbody/tr[3]/td[2]/span/input"));
              }
                else
                {
                  //  driverobj.GetElement(chk_selectuser).ClickWithSpace();
                    driverobj.ClickEleJs(chk_selectuser);
                }
             //   driverobj.GetElement(btn_assignuser).ClickWithSpace();
                driverobj.ClickEleJs(btn_assignuser);
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_RequiredTrainingLink()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_requiredtraining);
                
                driverobj.ClickEleJs(lnk_requiredtraining);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool CheckRequiredTraining()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//td[contains(.,' " + ExtractDataExcel.MasterDic_admin1["Firstname"]  + "" + "')]"));
                
                //driverobj.WaitForElement(By.XPath("//td[contains(.,'" + DateTime.Now.ToString("MM/dd/yyyy") + "')]"));

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_SearchUserforRequiredTraining()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_searchuser_requiredtraining);
                driverobj.GetElement(txt_searchuser_requiredtraining).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Firstname"]);
             //   driverobj.GetElement(btn_searchuser_requiredtraining).ClickWithSpace();
                driverobj.ClickEleJs(btn_searchuser_requiredtraining);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_ApplyExtensionGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(cmb_extension_exemtion);
                driverobj.FindSelectElementnew(cmb_extension_exemtion, "Apply Extension");
                
                string originalHandle = driverobj.CurrentWindowHandle;
             //   driverobj.GetElement(btn_extension_exemtion).ClickWithSpace();
                driverobj.ClickEleJs(btn_extension_exemtion);
                driverobj.selectWindow("Apply Extension");
                Thread.Sleep(4000);
                driverobj.WaitForElement(txt_extension_day);
                driverobj.GetElement(txt_extension_day).Clear();
                driverobj.GetElement(txt_extension_day).SendKeysWithSpace("2");
                driverobj.GetElement(txt_extension_reason).SendKeysWithSpace("Test");
     //           driverobj.GetElement(btn_apply_extension).ClickWithSpace();
                driverobj.ClickEleJs(btn_apply_extension);
                Thread.Sleep(5000);

                driverobj.SwitchTo().Window(originalHandle);
                driverobj.WaitForElement(lbl_success);
                if (driverobj.GetElement(lbl_extension_days).Text == "2")
                {
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_RemoveExtensionGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(cmb_extension_exemtion);
                driverobj.FindSelectElementnew(cmb_extension_exemtion, "Remove Extension");

                string originalHandle = driverobj.CurrentWindowHandle;
             //   driverobj.GetElement(btn_extension_exemtion).ClickWithSpace();
                driverobj.ClickEleJs(btn_extension_exemtion);
                driverobj.selectWindow("Remove Extension");
                Thread.Sleep(4000);
                driverobj.WaitForElement(btn_remove_extension);

            //    driverobj.GetElement(btn_remove_extension).ClickWithSpace();
                driverobj.ClickEleJs(btn_remove_extension);
                Thread.Sleep(5000);

                driverobj.SwitchTo().Window(originalHandle);
                driverobj.WaitForElement(lbl_success);
                if (driverobj.GetElement(lbl_extension_days).Text == "0")
                {
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SearchUserforAssignTraining(string firstname)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_searchuser_assigntraining);
                driverobj.GetElement(txt_searchuser_assigntraining).SendKeysWithSpace(firstname);
                driverobj.GetElement(btn_searchuser_assigntraining).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool selectAssignTrainingWithoutDeadline()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(RequiredTraining_SelectProfile_Dropdown);

                driverobj.select(RequiredTraining_SelectProfile_Dropdown, "Assign Training Without Deadline");
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        internal void AssignProfileAndSaveTheTraning(string browserstr)
        {
            SelectProfile SelectProfileobj = new SelectProfile(driverobj);
            selectProfile();
            Click_SelectProfileGoBtn();
            SelectProfileobj.Click_SearchProfile("testdynamic");
            SelectProfileobj.Click_SelectProfile();
            Click_SearchUserforAssignTraining_ForGC(browserstr); 
            Click_SelectUserforTraining();
            Click_RequiredTrainingLink();
            //Click_SearchUserforRequiredTraining();
        }
        private By txt_searchuser_assigntraining = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole");
        private By btn_searchuser_assigntraining = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search");
        private By chk_selectuser = By.XPath("//input[@title='user, regadmin']");
        private By btn_assignuser = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining");
        private By lnk_requiredtraining =By.XPath("//a[@title='Required Training']");
        private By txt_searchuser_requiredtraining = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_SearchFor");
        private By btn_searchuser_requiredtraining = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.BTN.Search");

        private By txt_extension_day = By.Id("EXTENSION_TIME");
        private By txt_extension_reason = By.Id("EXTENSION_REASON");
        private By btn_apply_extension = By.Id("ML.BASE.GENERIC.ApplyExtension");

        private By btn_remove_extension = By.Id("ML.BASE.GENERIC.RemoveExtension");

        private By lbl_extension_days = By.XPath("//tr[contains(@id,'TabMenu_ML_BASE_TAB_RequiredTraining_ASSIGNED_ENTITY_RTA_ASSIGNMENT_ID_0_02_2||')]/td[8]");
        private By cmb_extension_exemtion = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_RequiredTraining_ActionsMenu_2_ASSIGNED_PROFILE_2_0_')]");
        private By btn_extension_exemtion = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ASSIGNED_ENTITY_GoButton_2");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By RequiredTraining_SelectProfile_Dropdown = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining");
        private By RequiredTraining_GoProfile_Button = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu");
        private By RequiredTraining_Search_Button = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search");
        private By RequiredTraining_Title_Checkbox = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]");
        private By RequiredTraining_AssignTraining_Button = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining");
       
    }
}
