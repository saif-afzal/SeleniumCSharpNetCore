using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet;
using Selenium2.Meridian;
using System.Reflection;
//using Meridian.Testcases;


namespace Selenium2.Meridian
{
    class AddContent
    {
    private readonly IWebDriver driverobj;

    public AddContent(IWebDriver driver)
        {
            driverobj = driver;
        }
    public bool AddingBundle(string browserstr)
        {
            
            try
            {
                driverobj.WaitForElement(txt_Search);
                driverobj.GetElement(txt_Search).Clear();
                driverobj.GetElement(txt_Search).SendKeysWithSpace(Variables.bundleTitle+browserstr);
                driverobj.select(cmb_Type, "Exact phrase");
                driverobj.GetElement(btn_Search).ClickWithSpace();
                driverobj.WaitForElement(chk_BundleName);
               // driverobj.GetElement(chk_BundleName).ClickWithSpace();
                driverobj.ClickEleJs(chk_BundleName);
                //if (1==1)//(q_TC_Certification.addingOptions == 1)
                //{
                //    driverobj.ClickEleJs(btn_AddReCertification);
                //}
        
               
                    if(driverobj.existsElement(btn_AddCertification))
                    {
                        driverobj.ClickEleJs(btn_AddCertification);
                    }
                else if(driverobj.existsElement(btn_AddReCertification))
                    {
                        driverobj.ClickEleJs(btn_AddReCertification);
                    }
                    else if(driverobj.existsElement(btn_AddAlternateOption))
                    {
                        driverobj.ClickEleJs(btn_AddAlternateOption);
                    }
             
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        // Search Training Activities to add to the Curriculum
        public bool SearchAndAddActivity(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(txt_SearchActivity);
                driverobj.GetElement(txt_SearchActivity).Clear();
                driverobj.GetElement(txt_SearchActivity).SendKeysWithSpace(Variables.classroomCourseTitle+browserstr);
                driverobj.select(cmb_TypeActivity, "Exact phrase");
                driverobj.GetElement(btn_SearchActivity).ClickWithSpace();

                driverobj.WaitForElement(btn_Add);
              //  driverobj.GetElement(chk_Prescribed).ClickWithSpace();
                driverobj.ClickEleJs(chk_Prescribed);
                driverobj.GetElement(btn_Add).ClickWithSpace();   
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool SearchAndAddActivityGC(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(txt_SearchActivity);
                driverobj.GetElement(txt_SearchActivity).Clear();
                driverobj.GetElement(txt_SearchActivity).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
                driverobj.select(cmb_TypeActivity, "Exact phrase");
                driverobj.GetElement(btn_SearchActivity).ClickWithSpace();

                driverobj.WaitForElement(btn_Add);
                //  driverobj.GetElement(chk_Prescribed).ClickWithSpace();
                driverobj.ClickEleJs(chk_Prescribed);
                driverobj.GetElement(btn_Add).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool SearchAndAddActivityClassroom(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(txt_SearchActivity);
                driverobj.GetElement(txt_SearchActivity).Clear();
                driverobj.GetElement(txt_SearchActivity).SendKeysWithSpace(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr);
                driverobj.select(cmb_TypeActivity, "Exact phrase");
                driverobj.GetElement(btn_SearchActivity).ClickWithSpace();

                driverobj.WaitForElement(btn_Add);
                //  driverobj.GetElement(chk_Prescribed).ClickWithSpace();
                driverobj.ClickEleJs(chk_Prescribed);
                driverobj.GetElement(btn_Add).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }


        // Search and Add Content(Classroom Course) to the Subscription
        public bool SearchAndAddContent(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_SearchContent);
                driverobj.GetElement(txt_SearchContentsubscription).Clear();
                driverobj.GetElement(txt_SearchContentsubscription).SendKeysWithSpace(Variables.classroomCourseTitle+browserstr);//Variables.classroomCourseTitle+browserstr);
                driverobj.select(cmb_TypeContentsubscription, "Exact phrase");
                driverobj.GetElement(btn_SearchContent).ClickWithSpace();

                driverobj.WaitForElement(btn_AddContentsubscription);
               // driverobj.GetElement(chk_ContentNamesubscription).ClickWithSpace();
                driverobj.ClickEleJs(chk_ContentNamesubscription);
                driverobj.GetElement(btn_AddContentsubscription).ClickWithSpace();
                driverobj.WaitForElement(lbl_SuccessMsg);
              actualresult =  driverobj.existsElement(lbl_notfound);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                
            }
            return actualresult;
        }


        public bool SearchAndAddCurriculamContent(string content)
        {
            bool actualresult = false;
            try
            {
                if (driverobj.existsElement(By.XPath("//a[contains(.,'Add Training Activities')]")))
                    {
                    driverobj.ClickEleJs(By.XPath("//a[contains(.,'Add Training Activities')]"));
                }
                driverobj.WaitForElement(btn_SearchContent1);
                driverobj.GetElement(txt_SearchContent).Clear();
                driverobj.GetElement(txt_SearchContent).SendKeysWithSpace(content);//Variables.classroomCourseTitle+browserstr);
                driverobj.select(cmb_TypeContent, "Exact phrase");
                driverobj.ClickEleJs(btn_SearchContent1);

                driverobj.WaitForElement(btn_AddContent);
              //  driverobj.GetElement(chk_ContentName).ClickWithSpace();
                driverobj.ClickEleJs(chk_ContentName);
                driverobj.ClickEleJs(btn_AddContent);
               driverobj.WaitForElement(lbl_SuccessMsg);
               actualresult = driverobj.existsElement(lbl_notfound);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                
            }
            return actualresult;
        }

        // Successfully added bundle/training activity to curriculum
        public string SuccessMsg()
        {
            try
            {
                driverobj.WaitForElement(lbl_SuccessMsg);
                return driverobj.gettextofelement(lbl_SuccessMsg);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }

        }

        public bool Click_Return()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_return);
                driverobj.GetElement(btn_return).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
               
            }
            return result;
        }

        private By txt_Search = By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor");
        private By btn_Search = By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch");
        private By chk_BundleName = By.Id("ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent");

        private By btn_AddCertification = By.Id("MainContent_MainContent_ucAddContentSearch_btnAddCert");
        private By btn_AddReCertification = By.Id("MainContent_ucAddContentSearch_btnAddReCert");
        private By btn_AddAlternateOption = By.Id("MainContent_MainContent_ucAddContentSearch_btnAddAltOption");
        private By cmb_Type = By.Id("MainContent_MainContent_ucAddContentSearch_ucContentSearch_ddlSearchType");
        private By lbl_SuccessMsg = By.XPath("//div[@class='alert alert-success']");

        private By txt_SearchActivity = By.Id("MainContent_MainContent_UC1_ucContentSearch_txtSearchFor");
        private By cmb_TypeActivity = By.Id("MainContent_MainContent_UC1_ucContentSearch_ddlSearchType");
        private By btn_SearchActivity = By.Id("MainContent_MainContent_UC1_ucContentSearch_btnSearch");
        private By rb_Prescribed = By.Id("ctl00_MainContent_UC1_rgCurriculumnAddActivity_ctl00_ctl04_rbPrescribedContent");
        private By btn_Add = By.Id("MainContent_MainContent_UC1_btnAddActivity");

        private By txt_SearchContentsubscription = By.Id("MainContent_MainContent_ucAddContent_ucContentSearch_txtSearchFor");
        private By txt_SearchContent = By.Id("MainContent_MainContent_UC1_ucContentSearch_txtSearchFor");
        private By cmb_TypeContent = By.Id("MainContent_MainContent_UC1_ucContentSearch_ddlSearchType");
        private By cmb_TypeContentsubscription = By.Id("MainContent_MainContent_ucAddContent_ucContentSearch_ddlSearchType");
        private By btn_SearchContent = By.Id("MainContent_MainContent_ucAddContent_ucContentSearch_btnSearchSubscription");
        private By btn_SearchContent1 = By.Id("MainContent_MainContent_UC1_ucContentSearch_btnSearch");
        private By chk_ContentName = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect");
        private By chk_ContentNamesubscription = By.Id("ctl00_ctl00_MainContent_MainContent_ucAddContent_rgSubscriptionAddContent_ctl00_ctl04_chkSubscriptionAddContent");
        private By btn_AddContent = By.Id("MainContent_MainContent_UC1_btnAddActivity");
        private By btn_AddContentsubscription = By.Id("MainContent_MainContent_ucAddContent_btnAddContent");
        private By lbl_notfound = By.XPath("//span[contains(.,'No records found.')]");
        private By btn_return = By.Id("MainContent_MainContent_UC1_btnCancel");
        private By chk_Prescribed = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect");


        internal void SearchAndAddContent()
        {
            throw new NotImplementedException();
        }

        internal void SearchAndAddCurriculamContent()
        {
            throw new NotImplementedException();
        }
    }
}
