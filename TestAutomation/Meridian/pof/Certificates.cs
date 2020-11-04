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
using OpenQA.Selenium.Remote;

namespace Selenium2.Meridian
{
    class Certificates
    {
     private readonly IWebDriver driverobj;

     public Certificates(IWebDriver driver)
        {
            driverobj = driver;
        }
         public bool Click_CreateGoTo()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_CreateGoTo);
                // driverobj.GetElement(btn_CreateGoTo).ClickWithSpace();
                 driverobj.ClickEleJs(btn_CreateGoTo);
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Certificates", driverobj);
             }

             return result;
         }

         public bool Populate_CreateForm()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_create_title);
                 driverobj.GetElement(txt_create_title).Clear();
                 driverobj.GetElement(txt_create_title).SendKeysWithSpace("Certificate_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_create_desc).Clear();
                 driverobj.GetElement(txt_create_desc).SendKeysWithSpace("Certificate_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_create_keyword).Clear();
                 driverobj.GetElement(txt_create_keyword).SendKeysWithSpace("Certificate_desc_" + ExtractDataExcel.token_for_reg);
               //  driverobj.GetElement(chk_format).ClickWithSpace();
                 driverobj.ClickEleJs(chk_format);
                 driverobj.GetElement(btn_next).ClickWithSpace();
               
                 result = true;
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

             }

             return result;
         }

        
         public bool Click_CreateCertificate()
         {
              bool result = false;

             try
             {
             driverobj.WaitForElement(btn_create);
             driverobj.GetElement(btn_create).ClickWithSpace();
               result =  driverobj.existsElement(lbl_success);
             
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_SaveStartFile()
         {
              bool result = false;

             try
             {
             driverobj.WaitForElement(chk_startfile);
            // driverobj.GetElement(chk_startfile).ClickWithSpace();
             driverobj.ClickEleJs(chk_startfile);
                  driverobj.GetElement(btn_savestartfile).ClickWithSpace();
                 driverobj.WaitForElement(lbl_success);
                 Click_Checkin();
             result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_SearchCertificates()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(txt_search_for);
                 driverobj.GetElement(txt_search_for).Clear();
                 driverobj.GetElement(txt_search_for).SendKeysWithSpace("Certificate_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(btn_search).ClickWithSpace();
                 result = driverobj.existsElement(btn_gotomanagebtn);

             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
             }

             return result;
         }
         public bool Click_gotomanagebtn()
         {
             bool result = false;

             try
             {
                 
                 driverobj.WaitForElement(btn_gotomanagebtn);
                 driverobj.ClickEleJs(btn_gotomanagebtn);

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }
         public bool Click_AdvSearchCertificate()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_advsearch);
              //   driverobj.GetElement(lnk_advsearch).ClickAnchor();
                 driverobj.ClickEleJs(lnk_advsearch);
                 driverobj.WaitForElement(txt_search_title);
                 driverobj.GetElement(txt_search_title).Clear();
                 driverobj.GetElement(txt_search_title).SendKeysWithSpace("Certificate_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_search_desc).Clear();
                 driverobj.GetElement(txt_search_desc).SendKeysWithSpace("Certificate_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(txt_search_keyword).Clear();
                 driverobj.GetElement(txt_search_keyword).SendKeysWithSpace("Certificate_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(btn_search).ClickWithSpace();

                 driverobj.WaitForElement(btn_gotomanagebtn);
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_UpdateCertificate()
         {
             bool result = false;

             try
             {
                 Click_Checkout();
                 driverobj.WaitForElement(txt_create_desc);
                 driverobj.GetElement(txt_create_desc).Clear();
                 driverobj.GetElement(txt_create_desc).SendKeysWithSpace("Certificate_desc_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(btn_save).ClickWithSpace();
                 driverobj.WaitForElement(lbl_success);
                 Click_Checkin();
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }
         
         public bool uploadfile()
         {
             bool result = false;
             RelativeDirectory rd = new RelativeDirectory();
             try
             {
                 IAllowsFileDetection allowsDetection = (IAllowsFileDetection)driverobj;
                 if (allowsDetection != null)
                 {
                     allowsDetection.FileDetector = new LocalFileDetector();

                 }
                 Thread.Sleep(3000);
                 //string path = rd.Up(2) + "\\Data\\CertificateWithGraphics.zip";
                 string path = rd.Up(2) + @"Data\CertificateWithGraphics.zip";
                 Thread.Sleep(4000);
                 driverobj.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditCertificate_UploadFile']")).SendKeys(path);
                 Thread.Sleep(4000);
                 result = true;
                
             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }

         public bool Click_CertificateTab()
         {
             bool result = false;

             try
             {
                 
                 driverobj.WaitForElement(tab_Certificate);

               //  driverobj.GetElement(tab_Certificate).ClickWithSpace();
                 driverobj.ClickEleJs(tab_Certificate);
                 
                 result = true;

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }

         public bool Click_UploadFilebtn()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_UploadFile);
                 driverobj.GetElement(btn_UploadFile).ClickWithSpace();
                result = driverobj.existsElement(lbl_success);
                

                 

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }

         public bool Click_deleteuploaded()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_deleteuploadedfile);
                 driverobj.GetElement(lnk_deleteuploadedfile).ClickWithSpace();
                 driverobj.findandacceptalert();
                result = driverobj.existsElement(lbl_success);

                 

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }
         public bool Click_PreviewLink()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_preview);
                 driverobj.GetElement(lnk_preview).ClickWithSpace();
                 driverobj.selectWindow("Certificates");
                 Click_Checkin();
                 result = true;

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }
         public bool Click_Checkout()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(tab_Checkout);
               //  driverobj.GetElement(tab_Checkout).ClickWithSpace();
                 driverobj.ClickEleJs(tab_Checkout);
                result = driverobj.existsElement(tab_checkin);

                 

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }

         public bool Click_Checkin()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(tab_checkin);
              //   driverobj.GetElement(tab_checkin).ClickWithSpace();
                 driverobj.ClickEleJs(tab_checkin);
                result = driverobj.existsElement(tab_Checkout);

                 

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }

         public bool Chk_Delete()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(chk_delete);
             //    driverobj.GetElement(chk_delete).ClickWithSpace();
                driverobj.ClickEleJs(chk_delete);
                 result = true;

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }

         public bool Click_Delete()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(btn_delete);
             //    driverobj.GetElement(btn_delete).ClickWithSpace();
                driverobj.ClickEleJs(btn_delete);
                 result = true;

             }
             catch (Exception ex)
             {
                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }
             return result;
         }

         private By btn_CreateGoTo = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
         private By txt_create_title = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_TITLE");
         private By txt_create_desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_DESCRIPTION");
         private By txt_create_keyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_KEYWORDS");
         private By chk_format = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_DISPLAY_TYPE_1");
         private By btn_next = By.Id("ML.BASE.BTN.Next");
         private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By chk_startfile=By.XPath("//input[@value='\\Meridian Global Reporting.htm']");
        private By btn_savestartfile=By.Id("TabMenu_ML_BASE_HEAD_EditCertificate_COURSE_START_FILE");
        private By tab_checkin=By.XPath("//span[contains(.,'Check In')]");
         private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");

         private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
         private By txt_search_title = By.Id("TabMenu_ML_BASE_TAB_Search_CERT_TITLE");
         private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_CERT_DESCRIPTION");
         private By txt_search_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_CERT_KEYWORDS");
         private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By btn_gotomanagebtn=By.Id("TabMenu_ML_BASE_TAB_Search_CertificateSearch_ctl02_GoButton");

         private By txt_search_for = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
         private By tab_Certificate = By.XPath("//span[text()='Certificate']");
         private By tab_Checkout = By.XPath("//span[contains(.,'Check Out')]");
         private By btn_UploadFile = By.Id("TabMenu_ML_BASE_HEAD_EditCertificate_ML.BASE.FORM.EXTERNALFILE_URL");
         private By lnk_deleteuploadedfile = By.XPath("//a[@id='TabMenu_ML_BASE_HEAD_EditCertificate_DELETE_DIRECTORY_CONTENT']");
         private By lnk_preview =By.Id("TabMenu_ML_BASE_HEAD_EditCertificate_PREVIEW_CERTIFICATE");
         private By chk_delete = By.Id("TabMenu_ML_BASE_TAB_Search_CertificateSearch_ctl02_DataGridItem_CERT_CERTIFICATE_ID");
         private By btn_delete = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Delete");

         private By btn_save = By.Id("ML.BASE.BTN.Save");
    }
}
