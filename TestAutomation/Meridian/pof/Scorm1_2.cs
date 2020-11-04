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
    class Scorm1_2
    {
          private readonly IWebDriver driverobj;

          public Scorm1_2(IWebDriver driver)
        {
            driverobj = driver;
        }

          public bool Click_CourseSettingForScorm()
          {
              bool result = false;

              try
              {
                  driverobj.WaitForElement(tab_checkout);
                 // driverobj.GetElement(tab_checkout).ClickWithSpace();
                  driverobj.ClickEleJs(tab_checkout);
                  Thread.Sleep(4000);
               //   driverobj.GetElement(tab_coursesetting).ClickWithSpace();
                  driverobj.ClickEleJs(tab_coursesetting);

                  driverobj.WaitForElement(chk_uiheader);
                //  driverobj.GetElement(chk_uiheader).Click();
                  driverobj.ClickEleJs(chk_uiheader);

                  driverobj.GetElement(btn_save).ClickWithSpace();


                  driverobj.WaitForElement(lbl_success);
                  driverobj.WaitForElement(tab_checkin);
              //    driverobj.GetElement(tab_checkin).ClickWithSpace();
                  driverobj.ClickEleJs(tab_checkin);
                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              }


              return result;
          }

        public bool markComplete()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@value='Resume']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Resume']"));
                driverobj.selectWindow("Meridian Global - Core Domain");
                Thread.Sleep(5000);
                driverobj.waitforframe(By.Id("tocFrame"));
                driverobj.ClickEleJs(By.XPath(".//*[@id='SCORM12Menu_1']/span[3]/img"));
                driverobj.WaitForElement(By.XPath("//u[contains(.,'References and Lesson Objective')]"));
                driverobj.ClickEleJs(By.XPath("//u[contains(.,'References and Lesson Objective')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("contentFrame"));
                driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("tocFrame"));
               
                driverobj.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
                driverobj.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("contentFrame"));
                driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("tocFrame"));
                driverobj.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
                driverobj.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("contentFrame"));
                driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("tocFrame"));
                driverobj.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
                driverobj.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("contentFrame"));
                driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("tocFrame"));
                driverobj.WaitForElement(By.XPath("//u[contains(.,'Lights & Shapes')]"));
                driverobj.ClickEleJs(By.XPath("//u[contains(.,'Lights & Shapes')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("contentFrame"));
                driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("tocFrame"));
                driverobj.WaitForElement(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
                driverobj.ClickEleJs(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("contentFrame"));
                driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("tocFrame"));
                driverobj.WaitForElement(By.XPath("//u[contains(.,'Exam')]"));
                driverobj.ClickEleJs(By.XPath("//u[contains(.,'Exam')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.waitforframe(By.Id("contentFrame"));
                //driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                //driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));

                driverobj.WaitForElement(By.XPath("html/body/form[1]/dl/dt[1]/ol/li[1]/input"));
                driverobj.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[1]/ol/li[1]/input"));
                driverobj.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[3]/ol/li[1]/input"));
                driverobj.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[4]/ol/li[1]/input"));
                driverobj.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[5]/ol/li[1]/input"));

                driverobj.ClickEleJs(By.XPath("//input[@value=' SUBMIT ANSWERS ']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
                result= driverobj.existsElement(By.XPath("//input[@value='Open Current Attempt']"));

               
            }
            catch(Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool viewScormCertificate()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@value='View Certificate']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='View Certificate']"));
                driverobj.selectWindow("Meridian Global 2010.1");
                driverobj.waitforframe(By.Id("CertificateWindow"));
                //     driverobj.SelectWindowClose2("Meridian Global 2010.1");
                driverobj.WaitForElement(By.XPath("//span[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser" + "')]"));
                driverobj.SelectWindowClose2("Meridian Global 2010.1");
                driverobj.WaitForElement(By.XPath("//input[@value='Open Current Attempt']"));
                actualresult = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool manageScormCourseFile()
        {
            bool result = false;

            try
            {
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSCORMFiles_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//input[@id='AsyncUpload1file0']"));
                driverobj.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Next']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool setCategory()
        {
            bool result = false;

            try
            {
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCategories_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'Categories')]"));
                driverobj.ClickEleJs(By.XPath("//div[@id='ctl00_ctl00_MainContent_MainContent_ucCategories_tvCategories']/ul/li/ul/li/div/input"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucCategories_btnSave']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool setCost()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'Cost')]"));
                driverobj.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).Clear();
                driverobj.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeysWithSpace("1");
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Check-in')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool setAlternateCost()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h3[contains(.,'Alternate Costs')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Add more users/groups')]"));
                driverobj.WaitForElement(By.XPath("//input[@value='Search']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Search']"));
                driverobj.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_NEW_CCT_COST']")).SendKeysWithSpace("2");
                driverobj.ClickEleJs(By.XPath("//input[@value='Add']"));
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']"));
                driverobj.WaitForElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_chkSelect']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Save']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Check-in')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool setCertificate(string browserstr)
        {
            bool result = false;

            try
            {
                //Set Certificate
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCertificate_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//p[contains(.,'The default certificate is currently assigned.')]"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCertificate_lnkEdit']"));

                driverobj.WaitForElement(By.XPath("//strong[contains(.,'Base Default Certificate(Associated with Site)')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Change Certificate')]"));
                driverobj.WaitForElement(By.XPath("//input[@value='Search']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Search']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.findandacceptalert();
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Back']"));

                //Preview Certificate
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Preview')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Preview')]"));

               // By ViewCertificate = By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "th_completed" + 1 + "')]/../../td[5]");
               // bool isfound = false;
               // try
               // {
               //     //driverobj.highlightElement(ViewCertificate);
               //     //driverobj.highlightElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "th_completed" + 1 + "')]/../../td[5]"));
               ////     driverobj.GetElement(ViewCertificate).ClickWithSpace();
               //     Thread.Sleep(4000);
               //     driverobj.SwitchTo().Window(driverobj.WindowHandles.Last());
               //     Thread.Sleep(3000);
               //     //driverobj.SelectFrame();
               //     //driverobj.waitforframe(ObjectRepository.switchToFrame_New);
               //     driverobj.FindElement(By.XPath("//h1"));
               //     Thread.Sleep(2000);
               //     string username = ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr.ToString() + " " + ExtractDataExcel.MasterDic_userforreg["Lastname"] + browserstr.ToString();
               //     if (driverobj.existsElement(By.Id("UserFullName")))
               //     {
               //         isfound = true;
               //     }
               //     driverobj.SelectWindowClose2("Meridian Global 2010.1", "Home");

               // }

               // catch (Exception ex)
               // {
               //     driverobj.SelectWindowClose2("Meridian Global 2010.1", "Home");
               //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
               // }

                driverobj.SwitchWindow("Meridian Global 2010.1");
                Thread.Sleep(5000);
                
             //   driverobj.WaitForElement(By.XPath("//p[contains(.,'This is to certify that')]"));
                driverobj.SelectWindowClose2("Meridian Global 2010.1");

                //Remove Certificate
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Remove')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Remove')]"));
                driverobj.findandacceptalert();
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.WaitForElement(By.XPath("//strong[contains(.,'Base Default Certificate(Associated with Site)')]"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Back']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Check-in')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool verifyApprovalPath(string browserstr, string scorm)
        {
            bool result = false;

            try
            {
                #region Request Access By Learner

                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(scorm);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + scorm + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + scorm + "')]"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + scorm + "')]"));
                driverobj.WaitForElement(By.XPath("//input[@value='Request Access']"));
                result = true;
                #endregion
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool checkInfoIcon(string browserstr, string scorm)
        {
            bool result = false;

            try
            {
                #region Request Access By Learner

                driverobj.WaitForElement(By.XPath("//span[@class='fa fa-info-circle text-info']"));
                driverobj.ClickEleJs(By.XPath("//span[@class='fa fa-info-circle text-info']"));
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                driverobj.IsElementVisible(By.XPath("//strong[contains(.,'Active')]"));
                driverobj.IsElementVisible(By.XPath("//strong[contains(.,'$0.00')]"));
                driverobj.IsElementVisible(By.XPath("//strong[contains(.,'SCORM 1.2')]"));
                driverobj.IsElementVisible(By.XPath("//a[contains(.,'Categories')]"));
                driverobj.IsElementVisible(By.XPath("//a[contains(.,'Status')]"));
                driverobj.IsElementVisible(By.XPath("//a[@id='MainContent_UC1_lnkPermissions']"));
                driverobj.IsElementVisible(By.XPath("//a[contains(.,'Domain Sharing')]"));
                driverobj.IsElementVisible(By.XPath("//a[contains(.,'Prerequisites')]"));
                driverobj.IsElementVisible(By.XPath("//a[contains(.,'Equivalencies')]"));
                driverobj.IsElementVisible(By.XPath("//a[contains(.,'Content Associations')]"));
                driverobj.SelectWindowClose2();
                result = true;
                #endregion
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }



        public bool verifyActivityInactive(string browserstr, string scorm)
        {
            bool result = false;

            try
            {
                #region Check Activity of Content after disable.

                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(scorm);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));

                if (!driverobj.IsElementVisible(By.XPath("//a[contains(.,'" + scorm + "')]")))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                
                #endregion
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool verifyActivityactive(string browserstr, string scorm)
        {
            bool result = false;

            try
            {
                #region Check Activity of Content after disable.

                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(scorm);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                if (!driverobj.IsElementVisible(By.XPath("//a[contains(.,'" + scorm + "')]")))
                {
                    result = false;
                }
                else
                {
                    result = true;
                }

                #endregion
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool verifyApprovalPathAfterRemoval(string browserstr, string scorm)
        {
            bool result = false;

            try
            {
                #region Request Access By Learner
                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(scorm);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + scorm + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + scorm + "')]"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + scorm + "')]"));
                if (!driverobj.existsElement(By.XPath("//input[@value='Request Access']"))) {
                    result = true;
                };
                
                #endregion
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }


        private By tab_checkout = By.XPath("//span[contains(.,'Check Out')]");
          private By tab_coursesetting = By.XPath("//span[contains(.,'Course Settings')]");
        private By chk_uiheader=By.Id("TabMenu_ML_BASE_EditScormSettings_SCORM12.EnableUIElmtPageHeader");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By tab_checkin = By.XPath("//span[contains(.,'Check In')]");

    }
}
