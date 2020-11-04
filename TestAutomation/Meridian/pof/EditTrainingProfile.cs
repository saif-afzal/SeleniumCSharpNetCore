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

namespace Selenium2.Meridian
{
    class EditTrainingProfile
    {
          private readonly IWebDriver driverobj;

          public EditTrainingProfile(IWebDriver driver)
        {
            driverobj = driver;
        }

          public bool Click_CreateTrainingProfileDynamic(string browserstr,string createProfile)
          {
              bool result = false;

              try
              {
                  driverobj.WaitForElement(txt_title);
                  driverobj.GetElement(txt_title).Clear();
                  driverobj.GetElement(txt_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Title"]+browserstr+"Dynamic");
                  driverobj.GetElement(txt_desc).Clear();
                  driverobj.GetElement(txt_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Desc"]);
                  driverobj.GetElement(txt_keyword).Clear();
                  driverobj.GetElement(txt_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Desc"]);
                  if (createProfile.ToLower().Equals("yes"))
                  {
                      driverobj.FindSelectElementnew(cmb_trainingperiodtype, "Assignment Date");
                      //  driverobj.GetElement(rb_initialduedate).Click();
                  driverobj.ClickEleJs(rb_initialduedate);
                //  driverobj.GetElement(rb_reccurancedaysyes).Click();
                  driverobj.ClickEleJs(rb_reccurancedaysyes);
                      driverobj.GetElement(txt_recurracedays).Clear();
                      driverobj.GetElement(txt_recurracedays).SendKeysWithSpace("1");
                      driverobj.FindSelectElementnew(cmb_reccurancedays, "Day(s)");
                      driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RECUR_VISIBLE_RDO_OFF")).Click();
                      driverobj.ClickEleJs(btn_createtrainingprofile);
                      driverobj.WaitForElement(lbl_success);
                  }
                  result = true;
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              }
              return result;
          }

          public bool Click_CreateTrainingProfileFixed(string browserstr)
          {
              bool result = false;

              try
              {
                  driverobj.WaitForElement(txt_title);
                  driverobj.GetElement(txt_title).Clear();
                  driverobj.GetElement(txt_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Title"]+browserstr);
                  driverobj.GetElement(txt_desc).Clear();
                  driverobj.GetElement(txt_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Desc"]);
                  driverobj.GetElement(txt_keyword).Clear();
                  driverobj.GetElement(txt_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Desc"]);
                  driverobj.FindSelectElementnew(cmb_trainingperiodtype, "Assignment Date");
                //  driverobj.GetElement(rb_fixeddate).Click();
                  driverobj.ClickEleJs(rb_fixeddate);
                  driverobj.GetElement(txt_fixeddate).Clear();
                  driverobj.GetElement(txt_fixeddate).SendKeysWithSpace(DateTime.Now.ToString(format));
                //  driverobj.GetElement(rb_reccurancedaysno).Click();
                  driverobj.ClickEleJs(rb_reccurancedaysno);
                  driverobj.GetElement(btn_createtrainingprofile).ClickWithSpace();
                  driverobj.WaitForElement(lbl_success);
                  //driverobj.Close();
                  //driverobj.SwitchTo().Window("");
                  //Thread.Sleep(4000);
                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              }


              return result;
          }


          public bool Click_UpdateTrainingProfileFixed()
          {
              bool result = false;

              try
              {
                  driverobj.WaitForElement(txt_title);
                  driverobj.GetElement(txt_desc).Clear();
                  driverobj.GetElement(txt_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Desc"]+"Updated");
                  driverobj.GetElement(btn_save).ClickWithSpace();
                  driverobj.WaitForElement(lbl_success);
                  result = true;
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              }
              return result;
          }

          public bool Click_SharingTab()
          {
              bool result = false;

              try
              {
                  driverobj.WaitForElement(lnk_sharingTab);
                  driverobj.GetElement(lnk_sharingTab).ClickWithSpace();
                  driverobj.WaitForElement(btn_save);
                  
                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
              }


              return result;
          }

          public bool shareTrainingProfileToChildDomain()
          {
              bool result = false;

              try
              {
                  driverobj.WaitForElement(rb_contentShared);
                //  driverobj.GetElement(rb_contentShared).ClickWithSpace();
                  driverobj.ClickEleJs(rb_contentShared);
                  driverobj.WaitForElement(chk_shareToChildDomain);
                //  driverobj.GetElement(chk_shareToChildDomain).ClickWithSpace();
                  driverobj.ClickEleJs(chk_shareToChildDomain);
                  driverobj.GetElement(btn_save).ClickWithSpace();
                  Thread.Sleep(4000);
                  driverobj.GetElement(btn_Return).ClickWithSpace();

                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
              }


              return result;
          }
          internal void ValidatePreviewEmailLink()
          {
              if (driverobj.IsElementVisible(By.LinkText("Preview Email")))
              {
                  string originalHandle = driverobj.CurrentWindowHandle;
                  driverobj.ClickEleJs(By.LinkText("Preview Email"));
                  Thread.Sleep(2000);
                  driverobj.SwitchWindow("Training Reminder Email");
                  bool closeButton = driverobj.IsElementVisible(By.Id("ML.BASE.CMD.CloseWindow"));
                  bool printButton = driverobj.IsElementVisible(By.Id("ML.BASE.CMD.Print"));
                  if (!(closeButton && printButton)) { throw new Exception("Either Close Window button or Print button is not present on Preview Email page "); }
                  driverobj.Close();
                  Thread.Sleep(2000);
                  driverobj.SwitchTo().Window(originalHandle);
              }
              else
                  throw new Exception("Preview Email- Link is not coming on Edit Traning Profile page which creating new traning profile.");
          }
          internal bool VerifyTraningProfilePastCompletionOptions(string RecurrenceTrue,string optionToCheck)
          {
              try
              {
                  driverobj.FindSelectElementnew(cmb_trainingperiodtype, "Last Completion Date");
                  driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_ON"));
                  driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DD_TIME")).Clear();
                  driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DD_TIME")).SendKeysWithSpace("1");
                  driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DD_PERIOD"), "Day(s)");

                 
                  if (RecurrenceTrue.ToLower().Equals("no"))
                  {
                      driverobj.GetElement(rb_reccurancedaysno).Click();
                      VerifyPastCompletionOptions_WhenRecurrence_None(); 
                  }
                  else
                  {
                      driverobj.GetElement(rb_reccurancedaysyes).Click();
                      driverobj.GetElement(txt_recurracedays).Clear();
                      driverobj.GetElement(txt_recurracedays).SendKeysWithSpace("1");
                      driverobj.FindSelectElementnew(cmb_reccurancedays, "Day(s)");
                      VerifyPastCompletionOptions_WhenRecurrence_TrueWithSomeValues();
                  }
                  driverobj.GetElement(pastCompletionOption).Click();
                  if (optionToCheck.Equals("Include all completions"))
                  { driverobj.GetElement(IncludeAllCompletions).Click(); }
                  else
                  {
                      driverobj.GetElement(WithinDueDateInterval).Click();  
                  }

                  driverobj.GetElement(RecurringTrainingVisibilityInterval).Click();
                  driverobj.ClickEleJs(btn_createtrainingprofile);
                  //driverobj.SwitchTo().Alert().Accept();
                  if (!driverobj.existsElement(lbl_success)) { throw new Exception("Traning Profile is not creating.."); }
                  return true;
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                  return false;
              }
          }
          internal void VerifyPastCompletionOptions_WhenRecurrence_None()
          {
              try
              {
                  string text = driverobj.gettextofelement(allCompletions);
                  if (!(driverobj.IsElementVisible(allCompletions) && driverobj.gettextofelement(allCompletions).Contains("Include all completions")))
                  { throw new Exception("Include all completions -field is not coming in Past Completion Options section when no recurrence is selected"); }
                  if (!(driverobj.IsElementVisible(Completions_DateInterval) && driverobj.gettextofelement(Completions_DateInterval).Contains("Include completions within Initial Due Date Interval")))
                  { throw new Exception("Include completions within Initial Due Date Interval -field is not coming in Past Completion Options section when no recurrence is selected"); }
                  if (!(driverobj.IsElementVisible(Completions_AfterSpec_Date) && driverobj.gettextofelement(Completions_AfterSpec_Date).Contains("Include completions after a specified date")))
                  { throw new Exception("Include completions after a specified date -field is not coming in Past Completion Options section when no recurrence is selected"); }
                
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
          internal void VerifyPastCompletionOptions_WhenRecurrence_TrueWithSomeValues()
          {
              try
              {
                  if (!(driverobj.IsElementVisible(allCompletions) && driverobj.gettextofelement(allCompletions).Contains("Include all completions")))
                  { throw new Exception("Include all completions -field is not coming in Past Completion Options section when recurrence is selected"); }
                  if (!(driverobj.IsElementVisible(Completions_DateInterval) && driverobj.gettextofelement(Completions_DateInterval).Contains("Include completions within Initial Due Date Interval")))
                  { throw new Exception("Include completions within Initial Due Date Interval -field is not coming in Past Completion Options section when recurrence is selected"); }
                  if (!(driverobj.IsElementVisible(Completions_AfterSpec_Date) && driverobj.gettextofelement(Completions_AfterSpec_Date).Contains("Include completions after a specified date")))
                  { throw new Exception("Include completions after a specified date -field is not coming in Past Completion Options section when recurrence is selected"); }
                  if (!(driverobj.IsElementVisible(Completions_RecurrenceInterval) && driverobj.gettextofelement(Completions_RecurrenceInterval).Contains("Include completions within Recurrence Interval")))
                  { throw new Exception("Include completions within Recurrence Interval -field is not coming in Past Completion Options section when recurrence is selected"); }
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
          internal bool VerifyMigratedExistingTraningProfile_Manage()
          {
              try
              {
                  bool initialDueDate_Yes = driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_ON")).Selected;
                  bool Recurrence_Yes = driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RTP_RADIO_ON")).Selected;
                  bool IncludeCompletions_RecurrenceInterval = driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_PCO_WITHIN_DUE_DATE_INTERVAL")).Selected;
                  bool RecurringTrainingVisibilityInterval = driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RECUR_VISIBLE_RDO_OFF")).Selected;
                  if (!(initialDueDate_Yes && Recurrence_Yes && IncludeCompletions_RecurrenceInterval && RecurringTrainingVisibilityInterval))
                  { return false; }
                  string TrainingPeriodType = driverobj.FindElement(By.CssSelector("option[value='LastCompletionDate']")).Text;
                  if (!TrainingPeriodType.Equals("Last Completion Date")) { return false; }
                  return true;
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                  return false;
              }
          }
          string format = "M/d/yyyy";
          private By btn_Return = By.Id("Return");
          private By chk_shareToChildDomain = By.Id("TabMenu_ML_BASE_TAB_DomainContentSharing_ContentShared_3_ContentSharing_1_2_151A8B477D2446E39AA3B729D8963165_P_");
          private By rb_contentShared = By.Id("TabMenu_ML_BASE_TAB_DomainContentSharing_CONTENT_SHARED");
          private By lnk_sharingTab = By.XPath("//a[span[text()='Sharing']]");
          private By txt_title = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_TITLE");
          private By txt_desc = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_DESCRIPTION");
          private By txt_keyword = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_KEYWORDS");
          private By cmb_trainingperiodtype = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_DEADLINE");
          private By rb_initialduedate = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_OFF");
          private By rb_reccurancedaysyes = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RTP_RADIO_ON");
          private By txt_recurracedays = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RTP_RECUR_TIME");
          private By cmb_reccurancedays = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RTP_RECUR_PERIOD");
          private By btn_createtrainingprofile = By.Id("ML.BASE.BTN.Create");
          private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
          private By rb_fixeddate = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_OFF");
          private By txt_fixeddate = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_FIXED||DATEPICKER_dateInput");
          private By rb_reccurancedaysno = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RTP_RADIO_OFF");
          private By btn_save = By.Id("ML.BASE.BTN.Save");
          private By allCompletions = By.CssSelector("td[id*='_TDElementRTP_PCO_INCLUDE_ALL_COMPLETIONS']");
          private By Completions_DateInterval = By.CssSelector("td[id*='_TDElementRTP_PCO_WITHIN_DUE_DATE_INTERVAL']");
          private By Completions_AfterSpec_Date = By.CssSelector("td[id*='_TDElementRTP_PCO_INCLUDE_AFTER_SPECIFIC_DATE']");
          private By Completions_RecurrenceInterval = By.CssSelector("td[id*='_TDElementRTP_PCO_WITHIN_RECURRENCE_INTERVAL']");
          private By IncludeAllCompletions = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_PCO_INCLUDE_ALL_COMPLETIONS");
          private By WithinDueDateInterval = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_PCO_WITHIN_DUE_DATE_INTERVAL");
          private By pastCompletionOption = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_PAST_COMPLETION_OPTIONS_FLAG");
          private By RecurringTrainingVisibilityInterval = By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RECUR_VISIBLE_RDO_OFF");

    }
}
