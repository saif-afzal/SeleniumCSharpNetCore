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
    class CustomField
    {
         private readonly IWebDriver driverobj;

         public CustomField(IWebDriver driver)
        {
            driverobj = driver;
        }

         public bool Click_EditUserInfo()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_edituserinfo);
                 driverobj.GetElement(lnk_edituserinfo).ClickWithSpace();
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on the Link to add Custom Fields to User Info", driverobj);
             }

             return result;
         }

         public bool Click_Documents()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_documents);
                 driverobj.GetElement(lnk_documents).ClickWithSpace();
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on the Link to add Custom Fields to User Info", driverobj);
             }

             return result;
         }

         public bool Click_Test()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_test);
                 driverobj.GetElement(lnk_test).ClickWithSpace();
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_NewCustomFieldGoTo()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_CreateNewCustumFieldGoTo);
                 driverobj.GetElement(btn_CreateNewCustumFieldGoTo).ClickWithSpace();
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_DefaultAction()
         {
             bool result = false;

             try
             {
               
                 driverobj.WaitForElement(btn_defaultaction);
               
                 driverobj.GetElement(btn_defaultaction).ClickWithSpace();
                result= true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_CustomAction()
         {
             bool result = false;

             try
             {
                
                 driverobj.WaitForElement(btn_customaction);
                 driverobj.GetElement(btn_customaction).ClickWithSpace();
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_ReorderField()
         {
             bool result = false;

             try
             {

                 driverobj.WaitForElement(cmb_firstcustom);
                 driverobj.WaitForElement(cmb_secondcustom);
                 //td[select[@id='" +firstcustomid + "']]/following-sibling::td[1]
                 By customfirsttitlefield = By.XPath("//td[select[@id='" + firstcustomid + "']]/following-sibling::td[1]");
                 By customsecondtitlefield = By.XPath("//td[select[@id='" + secondcustomid + "']]/following-sibling::td[1]");
                 string firsttilte = driverobj.GetElement(customfirsttitlefield).Text;
                 string secondtilte = driverobj.GetElement(customsecondtitlefield).Text;
                 driverobj.FindSelectElementnew(cmb_firstcustom, "2");
                 driverobj.FindSelectElementnew(cmb_secondcustom, "1");
                 driverobj.GetElement(btn_save).ClickWithSpace();
                 driverobj.WaitForElement(lbl_success);
                 By customfirsttitlefieldchange = By.XPath("//td[select[@id='" + firstcustomid + "']]/following-sibling::td[1]");
                 By customsecondtitlefieldchange = By.XPath("//td[select[@id='" + secondcustomid + "']]/following-sibling::td[1]");
                 string firsttiltechange = driverobj.GetElement(customfirsttitlefield).Text;
                 string secondtiltechange = driverobj.GetElement(customsecondtitlefield).Text;
                 if ((firsttilte == secondtiltechange) && (secondtilte == firsttiltechange))
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

         public bool Click_DeleteField()
         {
             bool result = false;

             try
             {

                 By itemtodelete = By.XPath("//td[text()='" + "custom_" + ExtractDataExcel.token_for_reg + "']/following-sibling::td[8]/table/tbody/tr[1]/td/input");
                 driverobj.WaitForElement(itemtodelete);
                 driverobj.GetElement(itemtodelete).ClickWithSpace();

                     result = true;
                
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_EditField()
         {
             bool result = false;

             try
             {

                 By itemtoedit = By.XPath("//td[text()='" + "custom_" + ExtractDataExcel.token_for_reg + "']/following-sibling::td[6]//input");
                 driverobj.WaitForElement(itemtoedit);
                 driverobj.GetElement(itemtoedit).ClickWithSpace();

                 result = true;

             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }

         public bool Click_sharingTab()
         {
             bool result = false;

             try
             {


                 driverobj.WaitForElement(btn_sharingTab);
                 driverobj.GetElement(btn_sharingTab).ClickWithSpace();

                 result = true;

             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }

         public bool selectSharingCheckboxAndSave()
         {
             bool result = false;

             try
             {


                 driverobj.WaitForElement(chk_sharingPushRequired);
             //    driverobj.GetElement(chk_sharingPushRequired).ClickWithSpace();
                 driverobj.ClickEleJs(chk_sharingPushRequired);
              //   driverobj.GetElement(chk_sharingIsVisible).ClickWithSpace();
                 driverobj.ClickEleJs(chk_sharingIsVisible);
                // driverobj.GetElement(chk_sharingEditableField).ClickWithSpace();
                 driverobj.ClickEleJs(chk_sharingEditableField);
                // driverobj.GetElement(chk_sharingSearchable).ClickWithSpace();
                 driverobj.ClickEleJs(chk_sharingSearchable);
                 driverobj.GetElement(btn_save).ClickWithSpace();

                 result = true;

             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }

         public bool verify_customFieldNotPresent()
         {
             bool result = false;
             By customField = By.XPath("//td[text()='" + "custom_" + ExtractDataExcel.token_for_reg + "']");

             try
             {
                 driverobj.ElementNotPresent(customField);

                 result = true;

             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }

         public bool verify_customFieldPresent()
         {
             bool result = false;
             By customField = By.XPath("//td[text()='" + "custom_" + ExtractDataExcel.token_for_reg + "']");

             try
             {
                 driverobj.WaitForElement(customField);

                 result = true;

             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }

         private By chk_sharingSearchable = By.Id("TabMenu_ML_BASE_TAB_DomainContentSharing_ContentSearchable_3_ContentSharing_1_2_151A8B477D2446E39AA3B729D8963165_P_");
         private By chk_sharingEditableField = By.Id("TabMenu_ML_BASE_TAB_DomainContentSharing_ContentEditable_3_ContentSharing_1_2_151A8B477D2446E39AA3B729D8963165_P_");
         private By chk_sharingIsVisible = By.Id("TabMenu_ML_BASE_TAB_DomainContentSharing_ContentVisible_3_ContentSharing_1_2_151A8B477D2446E39AA3B729D8963165_P_");
         private By chk_sharingPushRequired = By.Id("TabMenu_ML_BASE_TAB_DomainContentSharing_ContentPushedRequired_3_ContentSharing_1_2_151A8B477D2446E39AA3B729D8963165_P_");
         private By btn_sharingTab = By.Id("ML.BASE.WF.DomainContentSharing");
         private By lnk_documents = By.XPath("//a[contains(.,'Documents')]");
         private By lnk_edituserinfo = By.XPath("//a[contains(.,'Edit User Information')]");
         private By lnk_test = By.XPath("//a[contains(.,'Tests')]");
         private By btn_CreateNewCustumFieldGoTo = By.Id("TabMenu_ML_BASE_HEAD_ManageFields_GoPageActionsMenu");
         private By btn_defaultaction = By.Id("TabMenu_ML_BASE_HEAD_ManageFields_BaseFormElements_ctl04_EDITBASEFIELD");
         private By btn_customaction = By.Id("TabMenu_ML_BASE_HEAD_ManageFields_CustomFormElements_ctl02_EDITCUSTOMFIELD");
        static string firstcustomid = "TabMenu_ML_BASE_HEAD_ManageFields_CustomFormElements_ctl02_ReOrderMenu";
        static string secondcustomid = "TabMenu_ML_BASE_HEAD_ManageFields_CustomFormElements_ctl03_ReOrderMenu";
         private By cmb_firstcustom = By.Id(firstcustomid);
         private By cmb_secondcustom = By.Id(secondcustomid);
         private By btn_save = By.Id("ML.BASE.BTN.Save");
         private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");

      
    }
}
