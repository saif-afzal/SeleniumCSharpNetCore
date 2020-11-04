using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

using System.Reflection;

namespace Selenium2.Meridian
{
    public class Create
    {
         private readonly IWebDriver driverobj;

         public Create(IWebDriver driver)
        {
            driverobj = driver;
        }
        // string[] excelArr;

        /*      public bool FillCertificationPageByExcel()
              {
                  try
                  {
                      Excel.Application xlApp;
                      Excel.Workbook xlWorkBook;
                      Excel.Worksheet xlWorkSheet;
                      Excel.Range xlrange;

                      int xlRowCnt = 0;
                      int xlColCnt = 0;

                      xlApp = new Excel.Application();
                      //Open Excel file
                      xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\richa.gupta\Desktop\Certification.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                      xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                      //This gives the used cells in the sheet

                      xlrange = xlWorkSheet.UsedRange;
                      excelArr = new string[3];

                      for (xlRowCnt = 1; xlRowCnt <= xlrange.Rows.Count; xlRowCnt++)
                      {
                          for (xlColCnt = 1; xlColCnt <= xlrange.Columns.Count; xlColCnt++)
                          {
                              excelArr[xlColCnt - 1] = (string)(xlrange.Cells[xlRowCnt, xlColCnt] as Excel.Range).Value2;
                          }
                      }
                      certTitle = excelArr[0] + DateTime.Now.ToString("ddMMyyyyhhmmss");
                      driverobj.WaitForElementPresent(Create_Create_Button);
                      driverobj.FindElement(Create_Title_TextBox).SendKeys(excelArr[0], true);   
                      driverobj.SwitchTo().Frame(driverobj.FindElement(Create_Description_TextBox));               
                      IWebElement a = driverobj.FindElement(By.CssSelector("body"));                
                      ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].innerHTML = '"+ excelArr[1] + "'", a);
                      driverobj.SwitchTo().DefaultContent();
                      driverobj.FindElement(Create_Keywords_TextBox).SendKeys(excelArr[2], true);
                  }
                  catch (Exception ex)
                  {
                  }            
                  return true;
              }*/

        //Filling certification form
         public bool FillCertificationPage(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btn_Create);
                Thread.Sleep(2000);
                driverobj.GetElement(txt_Title).Clear();
                driverobj.GetElement(txt_Title).SendKeysWithSpace(Variables.certTitle+browserstr);
                //if (driverobj.existsElement(txteditor_Description))
                //{
                //    driverobj.SwitchTo().Frame(driverobj.FindElement(txteditor_Description));
                //    IWebElement a = driverobj.FindElement(By.CssSelector("body"));
                //    ((IJavaScriptExecutor)driverobj).ExecuteScript("arguments[0].innerHTML = 'TestDesc'", a);
                //    driverobj.SwitchTo().DefaultContent();
                //}
                //else
                //{
                //    driverobj.GetElement(txt_Description).SendKeys("TestDesc");
                //}
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(txt_Keywords).SendKeysWithSpace("TestKeywords");
                //driverobj.ClickEleJs(By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_COST_TYPE_0"));//Certification price
                //driverobj.ClickEleJs(By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_PRD_FLAG_1"));//Certification Period No
              //  SelectElement selector = new SelectElement(driverobj.FindElement(cmb_CertificationType));
             //   selector.SelectByValue("ML.BASE.CERTTYPE.Linear");
               // driverobj.GetElement(rb_CertificationCostType).ClickWithSpace();
             //   driverobj.ClickEleJs(rb_CertificationCostType);
              //  driverobj.GetElement(rb_CertificationPeriod).ClickWithSpace();
              //  driverobj.ClickEleJs(rb_CertificationPeriod);
               // driverobj.GetElement(txt_CertificationPeriod).SendKeysWithSpace("2");
              //  SelectElement selCertificationType = new SelectElement(driverobj.FindElement(cmb_CertificationPeriod));
              //  selCertificationType.SelectByValue("ML.BASE.CERT.Day");
               // driverobj.GetElement(rb_ReCertificationOption).ClickWithSpace();
              //  driverobj.ClickEleJs(rb_ReCertificationOption);
              //  driverobj.GetElement(txt_ReCertificationInterval).SendKeysWithSpace("1");
              //  driverobj.WaitForElement(chk_period);
             //   driverobj.GetElement(chk_period).ClickWithSpace();
              //  driverobj.ClickEleJs(chk_period);
             //   SelectElement selReCertificationType = new SelectElement(driverobj.FindElement(cmb_ReCertificationInterval));
             //   selReCertificationType.SelectByValue("ML.BASE.CERT.Day");
               // driverobj.GetElement(rb_IncludePastContentCompletion).ClickWithSpace();
              //  driverobj.ClickEleJs(rb_IncludePastContentCompletion);
                driverobj.ClickEleJs(btn_Create);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        internal void FillDocumentPage(string v)
        {
            throw new NotImplementedException();
        }

        //Filling bundle form
        public bool FillBundlePage(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btn_Create);
                Thread.Sleep(3000);
                driverobj.GetElement(txt_Title).Clear();
                driverobj.GetElement(txt_Title).SendKeysWithSpace(Variables.bundleTitle+browserstr);
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(txt_Keywords).SendKeysWithSpace("Test Keyword");
                SelectElement selector = new SelectElement(driverobj.FindElement(cmb_BundleType));
                selector.SelectByValue("ML.BASE.BUNDLETYPE.PROGRESS");
               // driverobj.GetElement(rb_BundleCostType).ClickWithSpace();
                driverobj.ClickEleJs(rb_BundleCostType);
                driverobj.GetElement(btn_Create).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        //Filling curriculum form
         public bool FillCurriculumPage(string type, string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btn_Create);
                Thread.Sleep(2000);
                driverobj.GetElement(txt_Title).Clear();
                driverobj.GetElement(txt_Title).SendKeysWithSpace(Variables.curriculumTitle+browserstr+type);
         //       driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(txt_Keywords).SendKeysWithSpace("TestKeywords");
              //  driverobj.GetElement(chk_colspace).ClickWithSpace();
               // driverobj.GetElement(rb_CollaborationSpaceOption).ClickWithSpace();
                driverobj.ClickEleJs(rb_CollaborationSpaceOption);
                driverobj.GetElement(btn_Create).ClickWithSpace();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool FillScormPage()
        {
            try
            {
                driverobj.WaitForElement(btn_next);
                driverobj.navigateAICCfile("\\Data\\MARITIME NAVIGATION.zip", By.Id("MainContent_UC1_DOCUMENT_PATH"));
                driverobj.GetElement(btn_next).ClickWithSpace();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        //Filling generalcourse form
        public bool FillGeneralCoursePage(string type, string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btn_Create);
                Thread.Sleep(2000);
                driverobj.GetElement(txt_Title).Clear();
                driverobj.GetElement(txt_Title).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type);
            //    driverobj.SetDescription(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(txt_Keywords).SendKeysWithSpace("TestKeywords");
               // driverobj.GetElement(rb_selecturl).ClickWithSpace();
                driverobj.ClickEleJs(rb_selecturl);
                driverobj.GetElement(txt_url).SendKeys("www.google.com");
                driverobj.GetElement(btn_Create).ClickWithSpace();
              
                Thread.Sleep(5000);
               // ObjectRepository.CourseTitle = ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        //Filling document form
        public bool FillDocumentPage(string type, string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btn_Create);
                Thread.Sleep(2000);
                driverobj.GetElement(txt_Title).Clear();
                driverobj.GetElement(txt_Title).SendKeys(ExtractDataExcel.MasterDic_document["Title"]+browserstr + type);
                if (driverobj.existsElement(txteditor_Description))
                {
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.GetElement(By.CssSelector("body")).ClickWithSpace();
                    driverobj.GetElement(By.CssSelector("body")).SendKeysWithSpace(ExtractDataExcel.MasterDic_document["Desc"]);
                    driverobj.SwitchTo().DefaultContent();
                }
                else
                {
                    driverobj.GetElement(txt_Description).SendKeys(ExtractDataExcel.MasterDic_document["Desc"]);
                }
                driverobj.GetElement(txt_Keywords).SendKeys(ExtractDataExcel.MasterDic_document["Desc"]);
              //  driverobj.GetElement(rb_selecturl).Click();
                driverobj.ClickEleJs(rb_selecturl);
                driverobj.GetElement(txt_url).SendKeys("www.google.com");
                driverobj.GetElement(btn_Create).ClickWithSpace();
               
                Thread.Sleep(3000);
               // ObjectRepository.CourseTitle = ExtractDataExcel.MasterDic_document["Title"]+browserstr + type;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        //Filling AICC form


        public void performclick()
        {
            Actions builder = new Actions(driverobj);
            IWebElement link = driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rau_ausilverlight06"));
            builder = builder.KeyDown(Keys.Control).Click(link).KeyUp(Keys.Control);
            IAction multiple = builder.Build();
            multiple.Perform();
        
        }
        public bool FillAICCPage()
        {
            try
            {
                driverobj.WaitForElement(btn_next);
                driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
                driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
                driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
                driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
                driverobj.GetElement(btn_next).ClickWithSpace();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        internal void FillCurriculumPage()
        {
            throw new NotImplementedException();
        }

        //Filling Classroom Course form
        public bool FillClassroomCoursePage(string type, string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btn_Create);
                Thread.Sleep(2000);
                driverobj.GetElement(txt_Title).Clear();
                driverobj.GetElement(txt_Title).SendKeysWithSpace(Variables.classroomCourseTitle+browserstr+type);
                //if (driverobj.existsElement(txteditor_Description))
                //{
                //    driverobj.SwitchTo().Frame(driverobj.FindElement(txteditor_Description));
                //    IWebElement a = driverobj.FindElement(By.CssSelector("body"));
                //    ((IJavaScriptExecutor)driverobj).ExecuteScript("arguments[0].innerHTML = 'TestDesc'", a);
                //    driverobj.SwitchTo().DefaultContent();
                //}
                //else
                //{
                //    driverobj.GetElement(txt_Description).SendKeys("TestDesc");
                //}
           //     driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(txt_Keywords).SendKeys("TestKeywords");
                driverobj.GetElement(btn_Create).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        //Filling Subscription form
        public bool FillSubscriptionPage(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btn_Create);
                Thread.Sleep(2000);
                driverobj.GetElement(txt_Title).Clear();
                driverobj.GetElement(txt_Title).SendKeysWithSpace(Variables.subscriptionTitle+browserstr);
                //if (driverobj.existsElement(txteditor_Description))
                //{
                //    driverobj.SwitchTo().Frame(driverobj.FindElement(txteditor_Description));
                //    IWebElement a = driverobj.FindElement(By.CssSelector("body"));
                //    ((IJavaScriptExecutor)driverobj).ExecuteScript("arguments[0].innerHTML = 'TestDesc'", a);
                //    driverobj.SwitchTo().DefaultContent();
                //}
                //else
                //{
                //    driverobj.GetElement(txt_Description).SendKeys("TestDesc");
                //}
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(txt_Keywords).SendKeysWithSpace("TestKeywords");

                SelectElement selector = new SelectElement(driverobj.FindElement(cmb_SubscriptionType));
                selector.SelectByValue("ML.BASE.SUB.DynamicDate");
                driverobj.GetElement(txt_ExpirationDate).SendKeysWithSpace("1");
                driverobj.GetElement(btn_Create).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        internal void CreateCurriculumCourseType(string browserstr)
        {
            TrainingHomes objTrainingHome = new TrainingHomes(driverobj);
            ContentSearch objContentSearch = new ContentSearch(driverobj);
            Training objTraining = new Training(driverobj);
            Trainings traininsobj = new Trainings(driverobj);
            objTrainingHome.MyResponsiblities_click();
            traininsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
            FillCurriculumPage("", browserstr);
            driverobj.WaitForElement(ObjectRepository.CheckinNew);
            driverobj.ClickEleJs(ObjectRepository.CheckinNew);
            Thread.Sleep(3000);
        }
       private By txt_classroomDesc = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By txt_Title = By.Id("CNTLCL_TITLE");
        //private By txt_Title = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
       private By txteditor_Description = By.Id("MainContent_UC1_FormView1_MCustomValidatorDesc");
       private By txt_Description = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");

       private By txt_Keywords = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
       private By cmb_CertificationType = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_CERTTYPE");
       private By rb_CertificationCostType = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_COST_TYPE_0");
       private By rb_CertificationPeriod = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_PRD_FLAG_0");
       private By rb_IncludePastContentCompletion = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_INCL_PAST_COMPLETION_1");
       private By btn_Create= By.Id("MainContent_UC1_Save");
       private By txt_CertificationPeriod = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_PERIOD");
       private By cmb_CertificationPeriod = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_PERIOD_TYPE");
       private By rb_ReCertificationOption = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_RECERT_FLAG_0");
       private By txt_ReCertificationInterval = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_RECERT_TIME_INTERVAL");
       private By cmb_ReCertificationInterval = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_RECERT_TIME_INTVL_TYPE");
       private By cmb_BundleType = By.Id("MainContent_UC1_FormView1_BNDL_BUNDLE_TYPE");
       private By rb_BundleCostType = By.Id("MainContent_UC1_FormView1_BNDL_BUNDLE_COST_TYPE_0");
       private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
       private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
       private By rb_CollaborationSpaceOption = By.Id("MainContent_UC1_FormView1_fvCurriculum_CRLM_CSPACE_AVLBLE_1");
       private By cmb_SubscriptionType = By.Id("MainContent_UC1_FormView1_fvSubscription_SUBS_TYPE");
       private By txt_ExpirationDate = By.Id("MainContent_UC1_FormView1_fvSubscription_SUB_TIME_PERIOD");
       private By rb_selecturl = By.Id("MainContent_UC1_EXTERNALFILE_URL");
       private By txt_url = By.Id("MainContent_UC1_DOCUMENT_URL");
       private By btn_next = By.Id("MainContent_UC1_Next");
       private By btn_CheckinNew = By.Id("MainContent_header_FormView1_btnStatus");
       private By chk_period = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_PRD_FLAG_1");
       private By chk_colspace = By.Id("MainContent_UC1_FormView1_fvCurriculum_CRLM_CSPACE_AVLBLE_1");


       internal void FillClassroomCoursePage(string p)
       {
           throw new NotImplementedException();
       }

       internal void FillSubscriptionPage()
       {
           throw new NotImplementedException();
       }
    } 
    }

