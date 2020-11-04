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
    class Tests
    {
        
         private readonly IWebDriver driverobj;

         public Tests(IWebDriver driver)
        {
            driverobj = driver;
        }
         public bool Click_CreateGoTo()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_CreateGoTo);
              //   driverobj.GetElement(btn_CreateGoTo).ClickWithSpace();
                 driverobj.ClickEleJs(btn_CreateGoTo);
                 driverobj.WaitForElement(txt_create_title);
             }
             catch (Exception ex)
             {
                
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Populate_CreateForm(string typeoftest, string browserstr)
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_create_title);
                 driverobj.GetElement(txt_create_title).Clear();
                 driverobj.GetElement(txt_create_title).SendKeysWithSpace("test_"+browserstr+ ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_create_desc).Clear();
                 driverobj.GetElement(txt_create_desc).SendKeysWithSpace("test_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_create_keyword).Clear();
                 driverobj.GetElement(txt_create_keyword).SendKeysWithSpace("test_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(btn_create).ClickWithSpace();

                 driverobj.WaitForElement(lbl_success);
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

             }

             return result;
         }

         public bool Click_SearchTest(string browserstr)
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_search_for);
                 driverobj.GetElement(txt_search_for).Clear();
                 driverobj.GetElement(txt_search_for).SendKeysWithSpace("test_" + browserstr + ExtractDataExcel.token_for_reg);
                 driverobj.WaitForElement(cmb_searchtype);
                 driverobj.FindSelectElementnew(cmb_searchtype, "Starts with");
                 driverobj.GetElement(btn_search).ClickWithSpace();
                 driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "test_" + browserstr + ExtractDataExcel.token_for_reg + "')]"));
              //   driverobj.GetElement(By.XPath("//a[contains(.,'" + "test_" + browserstr + ExtractDataExcel.token_for_reg + "')]")).ClickWithSpace();
                 driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + "test_" + browserstr + ExtractDataExcel.token_for_reg + "')]"));
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }
             
             return result;
         }

         public bool Click_SearchTestNew(String testname)
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_search_for);
                 driverobj.GetElement(txt_search_for).Clear();
                 driverobj.GetElement(txt_search_for).SendKeysWithSpace(testname);
                 driverobj.WaitForElement(cmb_searchtype);
                 driverobj.FindSelectElementnew(cmb_searchtype, "Exact phrase");
                 driverobj.GetElement(btn_search).ClickWithSpace();
                 driverobj.WaitForElement(By.XPath("//a[contains(.,'" + testname + "')]"));
                 driverobj.GetElement(By.XPath("//a[contains(.,'" + testname + "')]")).ClickWithSpace();
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }

         public bool Click_AdvSearchTest(string browserstr)
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_advsearch);
            //     driverobj.GetElement(lnk_advsearch).ClickAnchor();
                 driverobj.ClickEleJs(lnk_advsearch);
                 driverobj.WaitForElement(txt_search_title);
                 driverobj.GetElement(txt_search_title).Clear();
                 driverobj.GetElement(txt_search_title).SendKeysWithSpace("test_" + browserstr + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_search_desc).Clear();
                 driverobj.GetElement(txt_search_desc).SendKeysWithSpace("test_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_search_keyword).Clear();
                 driverobj.GetElement(txt_search_keyword).SendKeysWithSpace("test_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(btn_search).ClickWithSpace();
                 driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "test_" + browserstr + ExtractDataExcel.token_for_reg + "')]"));
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }
        

         public bool Click_CreateNewGroupGoTo()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_editstructuregoto);
               //  driverobj.GetElement(btn_editstructuregoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_editstructuregoto);
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Populate_CreateQuestionGroupForm()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_QuestionGroup_title);
                 driverobj.GetElement(txt_QuestionGroup_title).Clear();
                 driverobj.GetElement(txt_QuestionGroup_title).SendKeysWithSpace("quesGroupTitle_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_QuestionGroup_Desc).Clear();
                 driverobj.GetElement(txt_QuestionGroup_Desc).SendKeysWithSpace("quesGroupDesc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_QuestionGroup_Keyword).Clear();
                 driverobj.GetElement(txt_QuestionGroup_Keyword).SendKeysWithSpace("quesGroupKeyword_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_QuestionGroup_NoOfQues).Clear();
                 driverobj.GetElement(txt_QuestionGroup_NoOfQues).SendKeysWithSpace("1");
                 driverobj.GetElement(btn_create).ClickWithSpace();

                 driverobj.WaitForElement(lbl_success);
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

             }

             return result;
         }
       

         public bool Update_test()
         {
             bool result = false;

             try
             {
                 //driverobj.WaitForElement(txt_previewurl);
                 //driverobj.GetElement(txt_previewurl).SendKeysWithSpace("www.google.com");
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

         public bool Click_StructureTab()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(tab_structure);
               //  driverobj.GetElement(tab_structure).ClickWithSpace();
                 driverobj.ClickEleJs(tab_structure);
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

             }

             return result;
         }
        
         public bool Click_NewQuestionGoTo(String quesType)
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_question_goto);
                 driverobj.FindSelectElementnew(ddl_questiontype, quesType);
             //    driverobj.GetElement(btn_question_goto).ClickWithSpace();
                driverobj.ClickEleJs(btn_question_goto);
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

             }

             return result;
         }
        

         public bool Click_PreviewTest()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_preview);
                 string originalHandle = driverobj.CurrentWindowHandle;
              //   driverobj.GetElement(btn_preview).ClickWithSpace();
                 driverobj.ClickEleJs(btn_preview);
                 driverobj.selectWindow("Preview Test");
                 Thread.Sleep(8000);
                 driverobj.Close();
                 Thread.Sleep(3000);
                 driverobj.SwitchTo().Window(originalHandle);
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_DeleteQuestion()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_editstructuregoto);
               //  driverobj.GetElement(chk_question).ClickWithSpace();
                 driverobj.ClickEleJs(chk_question);
                 driverobj.GetElement(btn_deletestructurequestion).ClickWithSpace();
                 driverobj.findandacceptalert();
                 driverobj.WaitForElement(lbl_success);
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }
         public bool Click_DeleteGroup()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_editstructuregoto);
               //  driverobj.GetElement(chk_structure).ClickWithSpace();
                 driverobj.ClickEleJs(chk_structure);
                 driverobj.GetElement(btn_deletestructurequestion).ClickWithSpace();
                 driverobj.findandacceptalert();
                 driverobj.WaitForElement(lbl_success);
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }


             return result;
         }

         public bool Verify_CustomField()
         {
             bool result = false;

             try
             {
                 
            // By customfield=By.XPath("//span[contains(text(),'" + "custom_" + ExtractDataExcel.token_for_reg + "')]/following-sibling::input[@class='FormFieldDisplay']");
                 By customfield = By.XPath("//span[contains(text(),'" + "custom_" + ExtractDataExcel.token_for_reg + "')]/ancestor::tr[1]/td[2]/input");
                // By customfield = By.XPath("//span[contains(text(),'custom_1005553255')]/ancestor::tr[1]/td[2]/input");
                 
                 Thread.Sleep(3000);
                 if (driverobj.existsElement(customfield))
                 {
                     result = true;
                 }
                 else
                 {

                     result = false;
                 }
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

             }

             return result;
         }

         public bool Verify_CustomFieldNotAvailable()
         {
             bool result = false;

             try
             {
                 By customfield = By.XPath("//span[contains(text(),'" + "custom_" + ExtractDataExcel.token_for_reg + "')]/ancestor::tr[1]/td[2]/input");
                 Thread.Sleep(3000);
                 if (driverobj.existsElement(customfield))
                 {
                     result = false;
                 }
                 else
                 {

                     result = true;
                 }
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

             }

             return result;
         }

         public bool Click_testsLinkBreadCrumb()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_testsBreadCrumb);
                 driverobj.ClickEleJs(lnk_testsBreadCrumb);
                 driverobj.WaitForElement(txt_search_for);
                 
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Click_Return()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_Return);
                 driverobj.GetElement(btn_Return).ClickWithSpace();
                 driverobj.WaitForElement(btn_question_goto);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Populate_NewQuestionForm()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_questionText);
                 driverobj.GetElement(txt_questionText).Clear();
                 driverobj.GetElement(txt_questionText).SendKeysWithSpace("New Essay Type Question?");
                 
                 driverobj.GetElement(btn_create).ClickWithSpace();

                 driverobj.WaitForElement(lbl_success);
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

             }

             return result;
         }

         public bool Click_LockTest()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_LockTest);
                 driverobj.GetElement(lnk_LockTest).ClickWithSpace();
                 driverobj.WaitForElement(lbl_success);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Click_publishScorm12()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_publishScorm12);
                 driverobj.GetElement(lnk_publishScorm12).ClickWithSpace();
                 driverobj.WaitForElement(btn_create);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Populate_PublishScormForm()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_Keyword_PublishScorm);
                 driverobj.GetElement(txt_Keyword_PublishScorm).Clear();
                 driverobj.GetElement(txt_Keyword_PublishScorm).SendKeysWithSpace("Test Keyword");
                 driverobj.GetElement(txt_MasteryScore_PublishScorm).SendKeysWithSpace("100");
               //  driverobj.GetElement(chk_ShowAllQues).ClickWithSpace();
                 driverobj.ClickEleJs(chk_ShowAllQues);

                 driverobj.GetElement(btn_create).ClickWithSpace();

                 driverobj.WaitForElement(lbl_success);
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

             }

             return result;
         }

         public bool Click_SelectInstructorsTab()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_SelectInstructorsTab);
                 driverobj.GetElement(lnk_SelectInstructorsTab).ClickWithSpace();
                 driverobj.WaitForElement(btn_GoAddInstructor);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Click_GoToAddInsturctor()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_GoAddInstructor);
                 driverobj.GetElement(btn_GoAddInstructor).ClickWithSpace();
                 driverobj.WaitForElement(btn_SearchUsers);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Populate_AddUserForm(string browserstr)
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_LastName_AddUsers);
                 driverobj.GetElement(txt_LastName_AddUsers).Clear();
                 driverobj.GetElement(txt_LastName_AddUsers).SendKeysWithSpace(ExtractDataExcel.MasterDic_instructor["Lastname"]+browserstr);
                 driverobj.GetElement(txt_FirstName_AddUsers).Clear();
                 driverobj.GetElement(txt_FirstName_AddUsers).SendKeysWithSpace(ExtractDataExcel.MasterDic_instructor["Firstname"]+browserstr);

                 driverobj.GetElement(btn_SearchUsers).ClickWithSpace();
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

             }

             return result;
         }

         public bool AddSelectedUser()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_AddSelectedUser);
                // driverobj.GetElement(chk_User_AddUser).ClickWithSpace();
                 driverobj.ClickEleJs(chk_User_AddUser);
                 driverobj.GetElement(btn_AddSelectedUser).ClickWithSpace();
                 driverobj.WaitForElement(lbl_success);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Click_CheckinTab()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_CheckinTab);
                 driverobj.GetElement(lnk_CheckinTab).ClickWithSpace();
                 driverobj.WaitForElement(lnk_CheckOutTab);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Click_Test_OpenItem(String browserstr)
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_OpenItem);
                 driverobj.GetElement(btn_OpenItem).ClickWithSpace();
                 Thread.Sleep(8000);
                // driverobj.SwitchTo().Window("Meridian Global - Core Domain");
                 driverobj.SwitchWindow("Meridian Global - Core Domain");
                
                 driverobj.SwitchTo().Frame("scorm_course_menu");
                // Thread.Sleep(4000);
                 driverobj.WaitForElement(By.XPath(".//*[@id='SCORM12Menu_1']/span[2]/u"));
                 driverobj.GetElement(By.XPath(".//*[@id='SCORM12Menu_1']/span[2]/u")).ClickWithSpace();
                 Thread.Sleep(10000);
                 driverobj.SwitchTo().DefaultContent();
                 driverobj.SwitchTo().Frame("scorm_block_info");
                 driverobj.GetElement(By.Id("q1b1")).SendKeysWithSpace("test");
                 //driverobj.SelectFrame(By.XPath(".//*[@id='SCORM12Menu_1']/span[2]/u"));
                 //driverobj.WaitForElement(By.XPath("//span[text()='" + "test_" +browserstr+ ExtractDataExcel.token_for_reg + "']"));
                 //driverobj.GetElement(By.XPath("//u[text()='" + "test_" + browserstr + ExtractDataExcel.token_for_reg + "']")).ClickAnchor();
                 //driverobj.WaitForElement(By.Id("q1b1"));
                 driverobj.WaitForElement(By.Id("Submit"));
                 driverobj.GetElement(By.Id("Submit")).ClickWithSpace();
                 Thread.Sleep(8000);
               //  driverobj.SwitchTo().DefaultContent();
                // driverobj.SwitchTo().Frame("scorm_block_info");
              //   driverobj.selectWindow("scorm_block_info");
              //   driverobj.SwitchWindow("Meridian Global - Core Domain");
              //   string title = driverobj.Title;
               //  driverobj.SwitchTo().Frame("scorm_block_info");
                 driverobj.WaitForElement(By.XPath(".//*[@id='Submit']"));
                 driverobj.GetElement(By.XPath(".//*[@id='Submit']")).ClickWithSpace();
                 Thread.Sleep(5000);
                 driverobj.Close();
              //   driverobj.SwitchTo().DefaultContent();

                // driverobj.SelectFrame(By.XPath(".//*[@id='SCORM12Menu_1']/span[2]/u"));

               //  driverobj.WaitForElement(lnk_CheckOutTab);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         public bool Click_NeedGradingTab()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(tab_NeedGradingtab);
                 driverobj.GetElement(tab_NeedGradingtab).ClickWithSpace();
                 driverobj.WaitForElement(btn_grade);
             //    driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_instructor["Lastname"]+", "+ExtractDataExcel.MasterDic_instructor["Firstname"]+"')]"));
                 

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }


             return result;
         }

         private By lnk_CheckOutTab = By.Id("ML.BASE.WF.Checkout");
         private By lnk_CheckinTab = By.Id("ML.BASE.WF.Checkin");
         private By btn_AddSelectedUser = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnAdd");
         private By chk_User_AddUser = By.Id("TabMenu_ML_BASE_TAB_AddUsers_InstructorsDataGrid_ctl02_DataGridItem_USR_LAST_NAME");
         private By txt_FirstName_AddUsers = By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME");
         private By txt_LastName_AddUsers = By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_LAST_NAME");
         private By btn_SearchUsers = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnSearch");
         private By btn_GoAddInstructor = By.Id("TabMenu_ML_BASE_SelectInstructors_GoPageActionsMenu");
         private By lnk_SelectInstructorsTab = By.Id("ML.BASE.WF.SelectInstructors");
         private By chk_ShowAllQues = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SHOW_ALL_QUESTIONS");
         private By txt_MasteryScore_PublishScorm = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MASTERY_SCORE");
         private By txt_Keyword_PublishScorm = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_KEYWORDS");
         private By lnk_publishScorm12 = By.XPath("//a[text()='Publish SCORM 1.2']");
         private By lnk_LockTest = By.XPath("//a[text()='Lock Test']");
         private By txt_questionText = By.Id("TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE");
         private By ddl_questiontype = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_TAB_EditStructure_ActionsMenu_1_TestQuestionGroups_1_0_')]");
         private By btn_Return = By.Id("Return");
         private By lnk_testsBreadCrumb = By.XPath("//a[text()='Tests']");
         private By txt_QuestionGroup_NoOfQues = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_NUM_QUESTIONS");
         private By txt_QuestionGroup_Keyword = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_KEYWORDS");
         private By txt_QuestionGroup_Desc = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_DESCRIPTION");
         private By txt_QuestionGroup_title = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_TITLE");
         private By btn_CreateGoTo = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
         private By txt_create_title = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_TST_TITLE");
         private By txt_create_desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_TST_DESCRIPTION");
         private By txt_create_keyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_TST_KEYWORDS");
         private By txt_create_contact = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_CONTACT_INFO");
         private By btn_create = By.Id("ML.BASE.BTN.Create");
         private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");

         private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
         private By txt_search_title = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE");
         private By cmb_searchtype = By.Id("TabMenu_ML_BASE_TAB_Search_SearchType");
         private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION");
         private By txt_search_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS");
         private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

         private By txt_search_for = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");

         private By btn_editstructuregoto = By.Id("TabMenu_ML_BASE_TAB_EditStructure_GoPageActionsMenu");
         private By txt_previewurl = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL");
         private By btn_save = By.Id("ML.BASE.BTN.Save");
         private By tab_structure = By.XPath("//span[contains(.,'Structure')]");
         private By btn_question_goto = By.Id("TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1");
         private By btn_preview = By.Id("TabMenu_ML_BASE_TAB_EditStructure_Preview");
         private By chk_question = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_TAB_EditStructure_DeleteQuestion_2_TestQuestionGroups_2_0_')]");
         private By btn_deletestructurequestion = By.Id("TabMenu_ML_BASE_TAB_EditStructure_ML.BASE.BTN.Delete");
         private By chk_structure = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_TAB_EditStructure_DeleteGroup_3_TestQuestionGroups_1_1_')]");
         private By btn_OpenItem = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
         private By tab_NeedGradingtab = By.Id("MainContent_ucTabs_lbENGrading");

         private By btn_grade = By.Id("ctl00_MainContent_ucNeedsGrading_rgNeedGrading_ctl00_ctl05_rgUsers_ctl00_ctl04_lnkGrade");
         private By submitgrade_userdetail = By.XPath("//td[contains(.,'Administrator, Site')]");
         

    }
}
