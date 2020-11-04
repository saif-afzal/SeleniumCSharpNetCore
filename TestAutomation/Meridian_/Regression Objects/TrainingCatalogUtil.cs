using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Text.RegularExpressions;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class TrainingCatalogUtil
    {

        private readonly IWebDriver driverobj;
        private TrainingHomes TrainingHomeobj;
        private AdminstrationConsole AdminstrationConsoleobj;

        public TrainingCatalogUtil(IWebDriver driver)
        {
            driverobj = driver;
            TrainingHomeobj = new TrainingHomes(driverobj);
            AdminstrationConsoleobj = new AdminstrationConsole(driverobj);
        }
        public void createcategories()
        {
            try
            {
                TrainingHomeobj.isTrainingHome();
                TrainingHomeobj.lnk_SystemOptions_click();
                TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                AdminstrationConsoleobj.Click_OpenItemLink("Content Categories");
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE")).SendKeysWithSpace("cat" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_DESCRIPTION")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_DESCRIPTION")).SendKeysWithSpace("cat" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(By.Id("ML.BASE.BTN.Create")).ClickWithSpace();
                driverobj.WaitForElement(categorysucessmsg);

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                TrainingHomeobj.isTrainingHome();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }


        }
        public void Create_Classroom_Course_and_Section(string browserstr)
        {
            try
            {

                ClassroomCourse classroomcourse = new ClassroomCourse(driverobj);
                //string expectedresult = "The item was created.";
                // TrainigCatalogUtilDriver.UserLogin("admin");
                classroomcourse.linkmyresponsibilitiesclick(driverobj);
                classroomcourse.linkclassroomcourseclick();
                classroomcourse.buttongoclick();
                classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
                classroomcourse.buttonsaveclick();
                classroomcourse.selectcategory();


                //TrainigCatalogUtildriver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

                //string expectedresult1 = "The course section was created with the first event.";
                // Assert.IsTrue(TrainigCatalogUtilDriver.UserLogin("admin"));
                classroomcourse.linkmyresponsibilitiesclick(driverobj);
                classroomcourse.linkclassroomcourseclick();
                classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC", "Exact phrase");
                classroomcourse.linkmanagesectionsclick();
                classroomcourse.buttonaddnewsectionclick();
                classroomcourse.populatesectionform1(browserstr);
                classroomcourse.populatesectionform12();
                classroomcourse.populateframeform();
                classroomcourse.buttonsaveframeclick();
                classroomcourse.buttonsaveandexitclick();
                // TrainigCatalogUtildriver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

        }
        string format = "M/d/yyyy";
        public void searchcourse(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                driverobj.WaitForElement(txttrainingcatalogsearch);
                driverobj.GetElement(txttrainingcatalogsearch).SendKeysWithSpace(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC");
                //driverobj.FindSelectElementnew(cmbtrainingcatalogsearch, "All words");

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
        }
        public void searchcourse_DocumentType(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                driverobj.WaitForElement(txttrainingcatalogsearch);
                driverobj.GetElement(txttrainingcatalogsearch).SendKeysWithSpace(ExtractDataExcel.MasterDic_document["Title"] + browserstr);
                //driverobj.FindSelectElementnew(cmbtrainingcatalogsearch, "All words");
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
        }
        public void searchcourseblank()
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                driverobj.WaitForElement(txttrainingcatalogsearch);
                //driverobj.GetElement(txttrainingcatalogsearch).SendKeys(ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr + "TC");
                //driverobj.FindSelectElementnew(cmbtrainingcatalogsearch, "All words");

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
        }

        public void Advancesearchcourse(string browserstr)
        {
            try
            {
                searchcourse(browserstr);
                Thread.Sleep(2000);
                driverobj.GetElement(AdvanceSearchLink).ClickWithSpace();
                driverobj.WaitForElement(Cmbeditingstatus);
                driverobj.FindSelectElementnew(Cmbeditingstatus, "Available");
                driverobj.FindSelectElementnew(Cmbactivity, "Active");

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }


        }
        public bool CheckSearchedItem(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(btntrainingcatalogsearch);
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC" + "']"));
                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC" + "']")).ClickWithSpace();

                driverobj.WaitForElement(By.XPath("//h4[contains(text(),'" + Regex.Replace(DateTime.Now.AddDays(2).ToString(format), "-", "/") + "')]"));
                driverobj.WaitForElement(By.XPath("//h4[contains(text(),'" + Regex.Replace(DateTime.Now.ToString(format), "-", "/") + "')]"));
                return driverobj.existsElement(By.XPath("//li[contains(.,'1 seats left')]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }


        }
        public bool CheckSearchedItem_Document(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "']"));
                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "']")).ClickWithSpace();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }


        }
        public bool selectfromcategory()
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                driverobj.WaitForElement(rootcategory);
                driverobj.GetElement(rootcategory).ClickWithSpace();
                //driverobj.WaitForElement(subcategoryfirstitem);
                //driverobj.GetElement(subcategoryfirstitem).Click();
                driverobj.WaitForElement(showcontent);
                driverobj.GetElement(showcontent).ClickWithSpace();
                driverobj.WaitForElement(subcategoryfirstcontent);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }

        public bool selectfromcategory_home()
        {
            try
            {
                //driverobj.GetElement(myResponsbility).Click();
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                //driverobj.WaitForElement(rootcategory_home);
                //driverobj.GetElement(rootcategory_home).Click();
                driverobj.WaitForElement(subcategoryfirstitem);
                driverobj.GetElement(subcategoryfirstitem).ClickWithSpace();
                driverobj.WaitForElement(showcontent);
                driverobj.GetElement(showcontent).ClickWithSpace();
                driverobj.WaitForElement(subcategoryfirstcontent);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }


        public bool selectfromsubcategory(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                //driverobj.WaitForElement(rootcategory);
                //driverobj.GetElement(rootcategory).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + "cat" + ExtractDataExcel.token_for_reg + "')]"));
                //if(driverobj.GetElement(By.Id("ctl00_MainContent_ucBrowseCategory_rlvPath_ctrl0_lbCategory")).Text.Contains("ROOT")==false)
                //{
                //    return false;
                //}

                driverobj.GetElement(By.XPath("//a[contains(text(),'" + "cat" + ExtractDataExcel.token_for_reg + "')]")).ClickAnchor();

                driverobj.WaitForElement(showcontent);
                driverobj.GetElement(showcontent).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC" + "']"));
                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC" + "']")).ClickWithSpace();
                driverobj.WaitForElement(By.CssSelector("tr[id^='ctl00_MainContent_ucClassroom_rgSections_']"));
                driverobj.WaitForElement(By.XPath("//h4[contains(text(),'" + Regex.Replace(DateTime.Now.AddDays(2).ToString(format), "-", "/") + "')]"));
                driverobj.WaitForElement(By.XPath("//h4[contains(text(),'" + Regex.Replace(DateTime.Now.ToString(format), "-", "/") + "')]"));
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }

        public bool viewallcontentfromcategory(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                //driverobj.WaitForElement(rootcategory);
                //driverobj.GetElement(rootcategory).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + "cat" + ExtractDataExcel.token_for_reg + "')]"));

                driverobj.GetElement(By.XPath("//a[contains(text(),'" + "cat" + ExtractDataExcel.token_for_reg + "')]")).ClickAnchor();

                driverobj.WaitForElement(showcontent);
                driverobj.GetElement(showcontent).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC" + "']"));
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }

        public bool searchforcourseincategory(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                //driverobj.WaitForElement(rootcategory);
                //driverobj.GetElement(rootcategory).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + "cat" + ExtractDataExcel.token_for_reg + "')]"));
                //if (driverobj.GetElement(By.Id("ctl00_MainContent_ucBrowseCategory_rlvPath_ctrl0_lbCategory")).Text.Contains("ROOT") == false)
                //{
                //    return false;
                //}

                driverobj.GetElement(By.XPath("//a[contains(text(),'" + "cat" + ExtractDataExcel.token_for_reg + "')]")).ClickAnchor();
                if (driverobj.GetElement(By.Id("ctl00_MainContent_ucBrowseCategory_rlvPath_ctrl0_lbCategory")).Text.Contains("cat" + ExtractDataExcel.token_for_reg) == false)
                {
                    return false;
                }
                driverobj.WaitForElement(showcontent);
                driverobj.GetElement(showcontent).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC" + "']"));
                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC" + "']")).ClickWithSpace();
                driverobj.WaitForElement(By.CssSelector("tr[id^='ctl00_MainContent_ucClassroom_rgSections_']"));    
                driverobj.WaitForElement(By.XPath("//h4[contains(text(),'" + Regex.Replace(DateTime.Now.AddDays(2).ToString(format), "-", "/") + "')]"));
                driverobj.WaitForElement(By.XPath("//h4[contains(text(),'" + Regex.Replace(DateTime.Now.ToString(format), "-", "/") + "')]"));
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }

        public bool CalenderSwitchToMonth(string browserstr)
        {
            try
            {
                searchcourse(browserstr);
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
                driverobj.WaitForElement(BtnClassroomCalenderView);
                driverobj.GetElement(BtnClassroomCalenderView).ClickWithSpace();
                driverobj.WaitForElement(ClanederMonthView);
                string CurrentCalender = DateTime.Now.ToString("MMM") + ", " + DateTime.Now.ToString("yyyy");
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'" + CurrentCalender + "')]"));

                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool Print(string browserstr)
        {
            bool actualresult = false;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                searchcourse(browserstr);
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_UC3_lbPrint']"));
                driverobj.GetElement(By.XPath("//a[@id='MainContent_UC3_lbPrint']")).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.selectWindow("Search Results");
                Thread.Sleep(6000);
                driverobj.WaitForElement(By.Id("ctl00_MainContent_ucSearch_rlvSearchResults_ctrl0_lnkDetails"));
                string linktext = driverobj.GetElement(By.Id("ctl00_MainContent_ucSearch_rlvSearchResults_ctrl0_lnkDetails")).Text;
                if (linktext == ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "TC")
                {
                    actualresult = true;
                }

                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }


        public bool facetsearch()
        {
            try
            {
                driverobj.WaitForElement(myOwnlearning);
                driverobj.GetElement(myOwnlearning).ClickWithSpace();
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                // driverobj.WaitForElement(rootcategory);
                driverobj.GetElement(By.Id("MainContent_ucSearchLanding_txtSearchFor")).Clear();
                driverobj.GetElement(By.Id("MainContent_ucSearchLanding_txtSearchFor")).SendKeysWithSpace("test");
                driverobj.GetElement(By.Id("btnSearch")).ClickAnchor();
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3"));
                string output = driverobj.GetElement(By.XPath("//div[@id='FacetCTGYLCL_CATEGORY_ID']/ul/li[1]/a[contains(text(),'None')]")).Text.Split(new char[] { '(', ')' })[1] + " Items";
                driverobj.GetElement(By.XPath("//div[@id='FacetCTGYLCL_CATEGORY_ID']/ul/li[1]/a[contains(text(),'None')]")).ClickWithSpace();
                // string extractedtext=driverobj.GetElement(By.XPath("//div[@id='FacetCTGYLCL_CATEGORY_ID']/a[contains(text(),'None')]")).Text;
                Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3"));
                if (!driverobj.GetElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3")).Text.Equals(output))
                {
                    return false;
                }
                output = driverobj.GetElement(By.XPath(".//*[@id='FacetCTYPLCL_DISPLAY_NAME']/ul/li[2]/label[contains(text(),'Classroom')]")).Text.Split(new char[] { '(', ')' })[1] + " Items";
                driverobj.GetElement(By.Id("cbContent TypeClassroom")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3"));
                Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3"));
                if (!driverobj.GetElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3")).Text.Equals(output))
                {
                    return false;
                }
                output = driverobj.GetElement(By.XPath("//div[@id='FacetCRWPRV_PROVIDER_ID']/ul/li/label[contains(text(),'None')]")).Text.Split(new char[] { '(', ')' })[1] + " Items";
                driverobj.GetElement(By.Id("cbCourse ProviderNone")).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3"));
                if (!driverobj.GetElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3")).Text.Equals(output))
                {
                    return false;
                }
                output = driverobj.GetElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3")).Text;

                driverobj.GetElement(By.Id("MainContent_ucSearchWithin_txtSearch")).Clear();
                driverobj.GetElement(By.Id("MainContent_ucSearchWithin_txtSearch")).SendKeysWithSpace("test");
                driverobj.GetElement(By.Id("btnFilterSearch")).ClickWithSpace();
                Thread.Sleep(1000);
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3"));
                if (!driverobj.GetElement(By.XPath(".//*[@id='MGSearchResults']/div[3]/div[1]/h3")).Text.Equals(output))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }


        public bool checkcourses()
        {
            bool actualresult = false;
            string[] courselist = { "cbContent TypeClassroom",/* "cbContent TypeOnline",*/ "cbContent TypeCertification", "cbContent TypeCurriculum", "cbContent TypeTest", "cbContent TypeBundle" };
            try
            {
                string linktext = string.Empty;
                searchcourseblank();
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
                foreach (string currlink in courselist)
                {

                    driverobj.GetElement(By.XPath("//input[@id='" + currlink + "']")).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                    linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                    driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                    driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).ClickWithSpace();
                    driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).ClickWithSpace();
                }
                #region commented
                ////---------------------------------------scrom

                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeOnline']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------certification
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeCertification']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------curriculam
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeCurriculum']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------test
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeTest']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------bundle
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeBundle']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();
                #endregion
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool checkcontent()
        {
            bool actualresult = false;
            string[] contentlist = {/* "cbContent TypeAnnouncement", "cbContent TypeFAQ",*/ "cbContent TypeDocument", "cbContent TypeSurvey", "cbContent TypeCollaboration Space", "cbContent TypeBlog" };
            try
            {
                string linktext = string.Empty;
                searchcourseblank();
                driverobj.WaitForElement(btntrainingcatalogsearch);
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
                foreach (string listitem in contentlist)
                {
                    driverobj.WaitForElement(By.XPath("//input[@id='" + listitem + "']"));
                    driverobj.GetElement(By.XPath("//input[@id='" + listitem + "']")).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                    linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                    driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                    driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).ClickWithSpace();
                    driverobj.WaitForElement(By.XPath("//a[contains(.,'Clear Filter')]"));
                    driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).ClickWithSpace();
                }
                #region comment
                ////---------------------------------------faq

                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeFAQ']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------document
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeDocument']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------site survey
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeSurvey']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------coleberation spaces
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeCollaboration Space']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();

                ////---------------------------------------blog
                //driverobj.GetElement(By.XPath("//input[@id='cbContent TypeBlog']")).Click();
                //driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']"));
                //linktext = driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Text;
                //driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails']")).Click();
                //driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + linktext + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(.,'Search Results')]")).Click();
                //driverobj.GetElement(By.XPath("//a[contains(.,'Clear Filter')]")).Click();
                //#endregion
                //actualresult = true;
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool LaunchAllpicableContent_CourseFromSearchResilts(string browserstr)
        {
            try
            {
                searchcourse_DocumentType(browserstr);
                CheckSearchedItem_Document(browserstr);
                AccessSelectedtem();
                Thread.Sleep(2000);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void AccessSelectedtem()
        {
            try
            {
                driverobj.WaitForElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
                driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")).ClickWithSpace();
                Thread.Sleep(3000);
                if (!(driverobj.WindowHandles.Count() > 1)) { throw new Exception("Open Iten button is not clickable"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SwitchCurrencyCourse_Contentitem_cost(string browserstr)
        {
            try
            {
                searchcourseblank();
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(btntrainingcatalogsearch);
                driverobj.GetElement(btntrainingcatalogsearch).ClickWithSpace();
                Thread.Sleep(1000);
                driverobj.GetElement(paidCheckBox).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.WaitForElement(subcategoryfirstcontent);
                driverobj.GetElement(subcategoryfirstcontent).ClickWithSpace();
                driverobj.WaitForElement(By.LinkText("Change Currency"));
                driverobj.GetElement(By.LinkText("Change Currency")).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.waitforframe(switchFrame);
                driverobj.FindSelectElementnew(changeCurrencyDropDown, "Indian Rupee");
                driverobj.GetElement(changeCurrencyFrameSave).ClickWithSpace();
                if (!driverobj.existsElement(changeCurrencySuccess))
                { return false; }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal void SearchAndClickSearched_GeneralCourse(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(trainingcatalog);
                driverobj.GetElement(trainingcatalog).ClickWithSpace();
                driverobj.WaitForElement(txttrainingcatalogsearch);
                driverobj.GetElement(By.Id("MainContent_ucSearchLanding_txtIDPSearchFor")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
                driverobj.GetElement(By.XPath("//span[contains(.,'Search')]")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "']"));
                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "']")).ClickWithSpace();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal bool VerifyActionforPerticulerGeneralCourse_AccessPeriod(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(enrollButton);
                IsCorrectButtonDisplayed_GC_Catalog("Enroll", enrollButton, browserstr, "General Course");
                ValidateAccessPeriodValidation();
                driverobj.GetElement(enrollButton).Click();
                driverobj.WaitForElement(sucessMessage);
                driverobj.WaitForElement(openItemmentButton);
                IsCorrectButtonDisplayed_GC_Catalog("Open Item", openItemmentButton, browserstr, "General Course");
                driverobj.WaitForElement(cancellEnrollmentButton);
                IsCorrectButtonDisplayed_GC_Catalog("Cancel Enrollment", cancellEnrollmentButton, browserstr, "General Course");
                driverobj.GetElement(cancellEnrollmentButton).Click();
                driverobj.WaitForElement(enrollButton);
                driverobj.WaitForElement(sucessMessage);
                driverobj.GetElement(enrollButton).Click();
                Thread.Sleep(2000);
                driverobj.GetElement(openItemmentButton).Click();
                driverobj.SelectWindowClose2("Google", "Details");
                //string originalHandle = driverobj.CurrentWindowHandle;
                //Thread.Sleep(2000);
                //driverobj.SwitchWindow("Google");
                //driverobj.Close();
                //Thread.Sleep(3000);
                //driverobj.SwitchTo().Window(originalHandle);
                driverobj.WaitForElement(resumeButton);
                IsCorrectButtonDisplayed_GC_Catalog("Resume", resumeButton, browserstr, "General Course");
                driverobj.WaitForElement(markCompleteButton);
                IsCorrectButtonDisplayed_GC_Catalog("Mark Complete", markCompleteButton, browserstr, "General Course");
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal void IsCorrectButtonDisplayed_GC_Catalog(string ButtonText, By locator, string browserstr, string courseType)
        {
            try
            {

                string buttonText = string.Empty;
                buttonText = driverobj.FindElement(locator).GetAttribute("value");
                if (!buttonText.Equals(ButtonText)) { throw new Exception("Default Button Text is not proper in current traning section for " + courseType + " course. Text should be -" + ButtonText); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void ValidateAccessPeriodValidation()
        {
            string validationText = "Access ends 1 day(s) after enrollment";
            try
            {
                if (driverobj.existsElement(accessPeriodMessage))
                {
                    string errorText = driverobj.gettextofelement(accessPeriodMessage);
                    if (!(errorText.Contains(validationText))) { throw new Exception("Alert/Validation message text is not corrent.. It should be " + validationText); }
                }
                else
                    throw new Exception("Access Period Alert/Validation message is not coming..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool Verification_SearchWthDifferentLanguages()
        {
            try
            {
                
                //Note- Print , calender view functionality tested in Traning Caralog test cases 
              //  Click_AdvanceSearch();
                driverobj.GetElement(LanguageDropDown).Click();
                List<IWebElement> allCheckbox_Language = driverobj.FindElements(By.CssSelector("label[class='checkbox']")).ToList();
                foreach (var item in allCheckbox_Language)
                {
                    if (!item.Text.Equals("English (US)"))
                    {
                        item.Click();
                        Thread.Sleep(1000);
                    }
                }
                driverobj.GetElement(btntrainingcatalogsearch).Click();
                Thread.Sleep(3000);
                VerifyLanguage_Facet();
                bool expressInterest = driverobj.IsElementVisible(expressInterestButton);
                bool classroomCalanderView = driverobj.IsElementVisible(calanderView);
                bool printButton = driverobj.IsElementVisible(print_Button);
                if (!(expressInterest && classroomCalanderView && printButton))
                { throw new Exception("After search>>Buttons on the top like Express Interest,Print,Classroom Calaender View are not coming."); }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal void VerifyLanguage_Facet()
        {
            List<IWebElement> allLanguage_SearchPage = driverobj.FindElements(LanguageFilterSection).ToList();
            if (allLanguage_SearchPage.Count == 0)
            { throw new Exception("Language filter section is not coming after search"); }
            allLanguage_SearchPage[0].Click();
            Thread.Sleep(4000);
            if (!driverobj.IsElementVisible(results_SearchPage))
            { throw new Exception("After apply language filter>> results are not coming.. "); }
        }
        internal  void Click_AdvanceSearch()
        {
            try
            {
                driverobj.GetElement(advance_SearchCriteria).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        private By expressInterestButton = By.Id("MainContent_UC3_lnkInterest");
        private By calanderView = By.Id("MainContent_UC3_hlClassroomCalendarView");
        private By print_Button = By.Id("MainContent_UC3_lbPrint");
        private By LanguageDropDown = By.CssSelector("button[title*='English']");
        private By LanguageFilterSection = By.CssSelector("input[id*='cbLanguages']");
        private By advance_SearchCriteria = By.CssSelector("a[href='#MainContent_ucSearchLanding_pnlAdvanced']");
        private By results_SearchPage = By.CssSelector("ul[class*='search-details']");
        private By sucessMessage = By.XPath("//div[@class='alert alert-success']");
        private By openItemmentButton = By.CssSelector("input[id*='_LaunchAttemptFirst']");
        private By cancellEnrollmentButton = By.CssSelector("input[id*='_CancelEnrollment']");
        private By resumeButton = By.CssSelector("input[id*='_LaunchCourseAttemptExisting']");
        private By markCompleteButton = By.CssSelector("input[id*='_MarkCompleteBlock']");
        private By enrollButton = By.CssSelector("input[id*='_EnrollButton']");
        private By accessPeriodMessage = By.CssSelector("div[class*='alert-danger']");
        private By myOwnlearning = By.Id("NavigationStrip1_lbUserView");
        private By myResponsbility = By.Id("NavigationStrip1_lbMyResponsibilities");
        private By trainingcatalog = By.XPath("//a[contains(text(),'Catalog')]");
        private By txttrainingcatalogsearch = By.Id("MainContent_ucSearchLanding_txtSearchFor");
        private By cmbtrainingcatalogsearch = By.Id("ddlSearchType");
        private By btntrainingcatalogsearch = By.Id("btnSearch");
        private By SeatLeft = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_ltNumOfSeatsLeft");
        private By AdvanceSearchLink = By.Id("MainContent_ucSearchLanding_pnlAdvanced");
        private By Cmbeditingstatus = By.Id("MainContent_ucSearchLanding_SearchStatusType");
        private By Cmbactivity = By.Id("MainContent_ucSearchLanding_SearchActivity");
        private By rootcategory = By.Id("ctl00_MainContent_ucSearchLanding_rlvSearchResults_ctrl0_lbCategory"); //By.XPath("//a[contains(text(),'ROOT')]");
        private By rootcategory_home = By.Id("MainContent_ucQuickSearch_ucBrowseCategories_rpCategories_lnkCategory_0");
        private By subcategoryfirstitem = By.XPath("[@id='ctl00_MainContent_ucQuickSearch_ucBrowseCategories_RadTreeView1']/ul/li[1]/div/span[2]");
        private By showcontent = By.Id("MainContent_ucBrowseCategory_lbSelectAllContent");
        private By subcategoryfirstcontent = By.Id("ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails");
        private By adminconsoleopenlink = By.Id("NavigationStrip1_lnkAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By categorysucessmsg = By.Id("ReturnFeedback");
        private By ClanederMonthView = By.XPath("//em[@class='rsHeaderMonth']");
        private By BtnClassroomCalenderView = By.Id("MainContent_UC3_hlClassroomCalendarView");
        private By enrollButtonTraningCatalog = By.CssSelector("input[id*='_btnEnroll']");
        private By paidCheckBox = By.Id("cbCostFacetPaid");
        private By switchFrame = By.CssSelector("iframe[class='k-content-frame']");
        private By changeCurrencyDropDown = By.Id("MainContent_UC1_USR_CURRENCY_ID");
        private By changeCurrencyFrameSave = By.Id("MainContent_UC1_Save");
        private By changeCurrencySuccess = By.XPath("//div[@class='alert alert-success']");
    }
}







