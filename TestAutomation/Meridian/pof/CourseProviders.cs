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
    class CourseProviders
    {
        private readonly IWebDriver driverobj;
        public CourseProviders(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateNewGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_createnewgoto);
              //  driverobj.GetElement(btn_createnewgoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createnewgoto);
                driverobj.WaitForElement(txt_createname);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Populate_CourseProvider(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createname);
                driverobj.GetElement(txt_createname).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Name"]+browserstr);
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Desc"]);
                driverobj.GetElement(txt_createkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Desc"]);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
              actualresult =  driverobj.existsElement(lbl_success);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_Search(string browserstr)
        {
            bool actualresult = false;
            try
            {
                Thread.Sleep(2000);
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Name"]+browserstr);
                driverobj.GetElement(btn_search).ClickWithSpace();
                Thread.Sleep(2000);
               actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_CourseProvider["Name"]+browserstr + "')]"));
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_AdvSearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_advsearch);
            //    driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                driverobj.WaitForElement(txt_searchtitle);
                driverobj.GetElement(txt_searchtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Name"]+browserstr);
                driverobj.GetElement(txt_searchdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Desc"]);
                driverobj.GetElement(txt_searchkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Desc"]);
                driverobj.GetElement(btn_search).ClickWithSpace();
              actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_CourseProvider["Name"]+browserstr + "')]"));

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Edit_CourseProvider()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createdesc);
                driverobj.GetElement(txt_createdesc).Clear();
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_CourseProvider["Desc"] + "Edit");
                driverobj.GetElement(btn_edit_save).ClickWithSpace();
              actualresult =  driverobj.existsElement(lbl_success);

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_ManageItem()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_manageitem);
                driverobj.ClickEleJs(btn_manageitem);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SelectCourseProvider()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_itemtodelete);
               // driverobj.GetElement(chk_itemtodelete).ClickWithSpace();
                driverobj.ClickEleJs(chk_itemtodelete);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_DeleteCourseProvider()
        {
            bool actualresult = false;
            try
            {
               
                driverobj.WaitForElement(btn_delete);
                driverobj.GetElement(btn_delete).ClickWithSpace();
                driverobj.findandacceptalert();
              actualresult =  driverobj.existsElement(lbl_success);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_InformationIcon(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(img_infoicon);
                string originalHandle = driverobj.CurrentWindowHandle;
              //  driverobj.GetElement(img_infoicon).ClickWithSpace();
                driverobj.ClickEleJs(img_infoicon);
                driverobj.selectWindow("Course Provider");
                Thread.Sleep(4000);
                driverobj.WaitForElement(lbl_mainheading);
                if (driverobj.GetElement(lbl_mainheading).Text.Contains(ExtractDataExcel.MasterDic_CourseProvider["Name"]+browserstr))
                {
                    result = true;
                }

                //  SurveyUtilDriver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + "')]"));
                Thread.Sleep(3000);
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
        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_createname = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRWPRV_PROVIDER_NAME");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRWPRV_DESCRIPTION");
        private By txt_createkeyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRWPRV_KEYWORDS");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_manageitem = By.Id("TabMenu_ML_BASE_TAB_Search_CourseProviderSearch_ctl02_GoButton");

        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_searchtitle = By.Id("TabMenu_ML_BASE_TAB_Search_CRWPRV_PROVIDER_NAME");
        private By txt_searchdesc = By.Id("TabMenu_ML_BASE_TAB_Search_CRWPRV_DESCRIPTION");
        private By txt_searchkeyword = By.Id("TabMenu_ML_BASE_TAB_Search_CRWPRV_KEYWORDS");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

        private By txt_previewurl = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL");
        private By btn_save = By.Id("ML.BASE.BTN.Save");

        private By chk_itemtodelete = By.Id("TabMenu_ML_BASE_TAB_Search_CourseProviderSearch_ctl02_DataGridItem_Delete");
        private By btn_delete = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Delete");
        private By img_infoicon = By.XPath("//img[@ src='/Skins/BaseTopMenu/Icons/en-US/ViewInfoIcon.png']");
       // private By img_infoicon = By.Id("TabMenu_ML_BASE_TAB_Search_CourseProviderSearch_ctl02_ML.BASE.DG.Info");
        private By lbl_mainheading = By.Id("MainHeading");
        private By btn_edit_save = By.Id("Save");
    }
}
