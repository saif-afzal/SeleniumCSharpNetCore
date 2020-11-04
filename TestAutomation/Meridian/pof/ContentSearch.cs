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
    class ContentSearch
    {

        private readonly IWebDriver driverobj;

        public ContentSearch(IWebDriver driver)
        {
            driverobj = driver;
        }
        // Select Certification/Bundle/Curriculum/Classroom from dropdown to create new one
        public bool NewContent(string selectorString)
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_Go_Button);
                driverobj.select(ContentSearch_AddNew_Dropdown, selectorString);

                driverobj.GetElement(ContentSearch_Go_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool Simple_SearchCertification(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_Search_Button);
                driverobj.GetElement(ContentSearch_SearchFor_TextBox).SendKeys(Variables.certTitle+browserstr);
                driverobj.select(ContentSearch_SearchType_Dropdown, "Exact phrase");
                driverobj.GetElement(ContentSearch_Search_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool Adv_SearchCertification(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_Search_Button);
                driverobj.GetElement(ContentSearch_SearchFor_TextBox).Clear();
                driverobj.GetElement(ContentSearch_SearchFor_TextBox).SendKeys(Variables.certTitle+browserstr);
                driverobj.select(ContentSearch_SearchType_Dropdown, "Exact phrase");
                driverobj.GetElement(ContentSearch_SeeMoreSearchCriteria_Link).Click();
                SelectElement activitySel = new SelectElement(driverobj.GetElement(ContentSearch_Activity_Dropdown));
                activitySel.SelectByValue("T");
                SelectElement contentSel = new SelectElement(driverobj.GetElement(ContentSearch_ContentType_Dropdown));
                contentSel.SelectByValue("ML.BASE.CERTIFICATION");
                driverobj.GetElement(ContentSearch_Search_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        // Selected certification/bundle click
        public bool Content_Click()
        {
            try
            {
                driverobj.ScrollToCoordinated("500", "500");
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[1]/h3/a[1]"));
                driverobj.ClickEleJs(By.XPath(".//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[1]/h3/a[1]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool Simple_Search(string searchString) // Certification and Bundle Search
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(searchString);
             //   SelectElement selType = new SelectElement(driverobj.GetElement(ContentSearch_SearchType_Dropdown));
          //      selType.SelectByValue("ML.BASE.DV.SearchExactPhrase");
                driverobj.ClickEleJs(By.Id("btnSearch"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool AdvanceSearch(string searchString, string type)
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_Search_Button);
                driverobj.GetElement(ContentSearch_SearchFor_TextBox).Clear();
                driverobj.GetElement(ContentSearch_SearchFor_TextBox).SendKeysWithSpace(searchString);
            //    SelectElement selector = new SelectElement(driverobj.GetElement(ContentSearch_SearchType_Dropdown));
              //  selector.SelectByValue("ML.BASE.DV.SearchExactPhrase");
                driverobj.ClickEleJs(ContentSearch_SeeMoreSearchCriteria_Link);
                SelectElement activitySel = new SelectElement(driverobj.GetElement(ContentSearch_Activity_Dropdown));
                activitySel.SelectByValue("T");
                SelectElement contentSel = new SelectElement(driverobj.GetElement(ContentSearch_ContentType_Dropdown));
                contentSel.SelectByValue(type);
                driverobj.ClickEleJs(ContentSearch_Search_Button);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool ViewInList(string title="")
        {
            bool actualresult = false;
            try
            {
               actualresult = driverobj.existsElement(ContentSearch_Name_Link);

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                
            }
            return actualresult;
        }

        public bool enrollInCurriculum(string curriculum, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("userforregression", browserstr);

                #region Enrollment in to curriculum By Learner
                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(curriculum);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + curriculum + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + curriculum + "')]"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + curriculum + "')]"));
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
                
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                actualresult = true;
                #endregion

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool cancelEnrollment()
        {
            bool actualresult = false;
            try
            {
                #region Cancel Enrollment from curriculum By Learner
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CancelEnrollment']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CancelEnrollment']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                actualresult = true;
                #endregion

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool accessCurriculum(string browserstr)
        {
            bool actualresult = false;
            try
            {
            //   driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
            //   driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                #region Access curriculum By Learner
                driverobj.WaitForElement(By.XPath("//input[@value='Access Item']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Access Item']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
                actualresult = true;
                #endregion

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool launchCurriculum(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
                driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
                #region Access curriculum By Learner
                driverobj.ClickEleJs(By.XPath("//input[@value='Enroll']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Open Item']"));
                Thread.Sleep(5000);
                driverobj.SelectWindowClose2("Google");
                Thread.Sleep(5000);
                driverobj.WaitForElement(By.XPath("//input[@value='Mark Complete']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Mark Complete']"));
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(3000);
                driverobj.ClickEleJs(By.XPath("//input[@value='Mark Complete']"));
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.XPath("//input[@value='Open Current Attempt']"));
            //    driverobj.ClickEleJs(By.XPath("//a[@title(.,'" + Variables.curriculumTitle + browserstr + "…')]"));
                driverobj.ClickEleJs(By.XPath("//a[@title='"+ Variables.curriculumTitle + browserstr + "']"));
                actualresult = true;
                #endregion

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool viewCurriculumCertificate(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@value='View Certificate']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='View Certificate']"));
                driverobj.selectWindow("Meridian Global 2010.1");
                driverobj.waitforframe(By.Id("CertificateWindow"));
           //     driverobj.SelectWindowClose2("Meridian Global 2010.1");
                driverobj.WaitForElement(By.XPath("//span[contains(.,'" + Variables.curriculumTitle + browserstr + "')]"));
                driverobj.SelectWindowClose2("Meridian Global 2010.1");
                driverobj.WaitForElement(By.XPath("//div[contains(@id,'pnlCurriculaumProgress')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool viewDetailsOfCourses(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                switch (type)
                {
                    case "Curriculum":

                        {
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + Variables.curriculumTitle + browserstr + "')]"));
                            driverobj.WaitForElement(By.XPath("//strong[contains(.,'Curriculum')]"));
                            driverobj.WaitForElement(By.XPath("//div[@id='MainContent_ucContentStatus_FormView1_pnlCurriculaumProgress']"));
                            driverobj.WaitForElement(By.XPath("//h4[contains(.,'" + Variables.curriculumblockTitle + browserstr + "')]"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
                            driverobj.WaitForElement(By.XPath("//h3[contains(.,'Curriculum Blocks')]"));
                        //    driverobj.WaitForElement(By.XPath("//a[contains(.,'Edit Content')]"));
                            
                            break;
                        }

                    case "ClassroomCourse":

                        {
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "')]"));
                            driverobj.WaitForElement(By.XPath("//h4[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "')]"));
                         //   driverobj.GetElement(By.XPath("//a[@title='Expand Row']")).ClickWithSpace();
                            driverobj.WaitForElement(By.XPath("//strong[contains(.,'In-Person')]"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Edit Content')]"));
                            driverobj.WaitForElement(By.XPath("//input[@class='btn btn-primary']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Enter your code to receive credit.')]"));
                    //        driverobj.WaitForElement(By.XPath("//p[contains(.,'Open for enrollment 5 seats left')]"));

                            break;
                        }

                    case "Scorm":
                        {
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'View Details')]"));
                            driverobj.selectWindow("Details");
                            driverobj.WaitForElement(By.XPath("//span[contains(.,'"+ ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr + " ')]"));
                            driverobj.WaitForElement(By.XPath("//span[contains(.,'" + ExtractDataExcel.MasterDic_userforreg["Lastname"] + browserstr + " ')]"));
                            driverobj.WaitForElement(By.XPath("//span[contains(.,'"+ ExtractDataExcel.MasterDic_scrom["Title"] + browserstr +" ')]"));
                            driverobj.WaitForElement(By.XPath("//span[contains(.,'SCORM 1.2 ')]"));
                            driverobj.WaitForElement(By.XPath("//span[contains(.,'Started ')]"));
                            driverobj.WaitForElement(By.XPath("//span[contains(.,'credit ')]"));
                            driverobj.SelectWindowClose2("Details");
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'"+ ExtractDataExcel.MasterDic_scrom["Title"] + browserstr +"')]"));
                            break;
                        }
                }

                actualresult = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return actualresult;
        }

        public bool viewCurriculumDetail(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'"+ Variables.curriculumTitle + browserstr + "')]"));
                driverobj.WaitForElement(By.XPath("//strong[contains(.,'Curriculum')]"));
                driverobj.WaitForElement(By.XPath("//div[@id='MainContent_ucContentStatus_FormView1_pnlCurriculaumProgress']"));
                driverobj.WaitForElement(By.XPath("//h4[contains(.,'"+ Variables.curriculumblockTitle + browserstr +"')]"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
                driverobj.WaitForElement(By.XPath("//h3[contains(.,'Curriculum Blocks')]"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Edit Content')]"));

                actualresult = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }


        public bool ClickInList()
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_Name_Link);
                driverobj.ClickEleJs(ContentSearch_Name_Link);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool SearchCertification(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_Search_Button);
                driverobj.GetElement(ContentSearch_SearchFor_TextBox).SendKeys(Variables.certTitle+browserstr);
                driverobj.GetElement(ContentSearch_Search_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        //certification in search list
        public bool ViewCertification()
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_CerticationName_Link);
                driverobj.GetElement(ContentSearch_CerticationName_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool Certification_Click()
        {
            try
            {
                driverobj.WaitForElement(ContentSearch_CerticationName_Link);
                driverobj.GetElement(ContentSearch_CerticationName_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool Click_AddDevelopmentActivity()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_adddevlopmentactivity);
               // driverobj.GetElement(chk_adddevlopmentactivity).ClickWithSpace();
                driverobj.ClickEleJs(chk_adddevlopmentactivity);
                driverobj.WaitForElement(btn_adddevelopmentactivity);
                driverobj.GetElement(btn_adddevelopmentactivity).ClickWithSpace();
               actualresult = driverobj.existsElement(lbl_success);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                
            }
            return actualresult;
        }
      
        private By ContentSearch_AddNew_Dropdown = By.Id("MainContent_ucSearchTop_ddlCreateNew");
        private By ContentSearch_Go_Button = By.Id("MainContent_ucSearchTop_btnCreateNew");
        private By ContentSearch_SearchFor_TextBox = By.Id("MainContent_ucSearchTop_SearchFor");
        private By ContentSearch_Search_Button = By.Id("btnSearchCourses");
        private By ContentSearch_CerticationName_Link = By.XPath("//a[contains(.,'NewTestCertification')]");
        private By ContentSearch_SiteAdministrator_Link = By.XPath("//span[contains(.,'Site Administrator')]");
        private By ContentSearch_Logout_Link = By.XPath("//span[contains(.,'Logout')]");
        private By ContentSearch_SeeMoreSearchCriteria_Link = By.XPath("//a[@class='adv-search-toggle']");
        private By ContentSearch_Activity_Dropdown = By.Id("MainContent_ucSearchTop_SearchActivity");
        private By ContentSearch_ContentType_Dropdown = By.Id("MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID");
        private By ContentSearch_SearchType_Dropdown = By.Id("MainContent_ucSearchTop_SearchType");
        private By ContentSearch_Name_Link = By.XPath("//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[1]/h3/a[1]");
        private By chk_adddevlopmentactivity = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_chkAdd");
        private By btn_adddevelopmentactivity = By.Id("MainContent_ucSearchResults_btnAdd");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");

    }  
}
