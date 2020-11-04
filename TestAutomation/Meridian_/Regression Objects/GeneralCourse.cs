using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace Selenium2.Meridian
{
    /*Objective: General Course class
     * 1.Create a General course- Admin
     * 2.Search a General course - User
     * 3.Enroll in genrel course -User
     * 4.Mrak course complete - User
     * 5.Veiw certificate for the course -User
     * 
     */
    class GeneralCourse
    {
        private readonly IWebDriver driverobj;
        public bool tocreatedriverobj = false;
        public bool togenralcoursecomplete = false;
        Trainings Trainingsobj;
        public GeneralCourse(IWebDriver driver)
        {
            Trainingsobj = new Trainings(driver);
            driverobj = driver;
        }
        public string result = string.Empty;

        //public void linkdriverobjclick(IWebDriver iSelenium)
        //{
        //    try
        //    {
        //        driverobj.WaitForElement(ObjectRepository.gereralcourse_link);
        //        driverobj.GetElement(ObjectRepository.gereralcourse_link).Click();
        //        driverobj.WaitForElement(ObjectRepository.go_btn);
        //        tocreatedriverobj = true;
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        tocreatedriverobj = false;

        //    }

        //}
        //public void buttongoclick(IWebDriver iSelenium)
        //{
        //    if (tocreatedriverobj == false)
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.go_btn).Click();
        //        driverobj.WaitForElement(ObjectRepository.genCourseTitle_ED);
        //        tocreatedriverobj = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        tocreatedriverobj = false;
        //    }
        //}
        public void populatesummarygeneralcourse(IWebDriver iSelenium, string title, string desc, int i)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.genCourseTitle_ED);
                driverobj.ClickEleJs(ObjectRepository.genCourseTitle_ED);
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).SendKeysWithSpace(title);
             //   driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(ObjectRepository.generalcoursekeyword).SendKeysWithSpace(desc);
                driverobj.select(By.XPath("//div[@id='content']/div[2]/div/div[9]/div/div/select"), "Internal");
                //driverobj.GetElement(By.XPath("//textarea[contains(@id,'INFO')]")).SendKeysWithSpace("1234567890");
                //driverobj.FindSelectElementnew(locator.driverobjtrainingpurposetype, "New Work Assignment");
                //driverobj.FindSelectElementnew(locator.driverobjtrainingsourcetypecode, "Government Internal");
                //driverobj.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTEHRI_TUITION_FEE_COST']")).SendKeysWithSpace("100");
                //driverobj.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTEHRI_NON_GOVT_COST']")).SendKeysWithSpace("100");
                //driverobj.GetElement(By.XPath("//input[@id='MainContent_UC1_CRSW_DURATION']")).SendKeysWithSpace("10");
                //driverobj.GetElement(By.XPath("//input[@id='MainContent_UC1_CRSW_CREDIT_VALUE']")).SendKeysWithSpace("5");
                //driverobj.select(By.XPath("//select[@id='MainContent_UC1_CRSW_CREDIT_TYPE']"), "Continuing Education Units");

                //driverobj.GetElement(locator.driverobjuniqueid).Clear();
                //driverobj.GetElement(locator.driverobjuniqueid).SendKeysWithSpace(locator.globalnum + i);

                //driverobj.GetElement(ObjectRepository.nxt_btn).Click();
                // Thread.Sleep(10000);
                // driverobj.WaitForElement(ObjectRepository.generalcourserd_btn);
                if (driverobj.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[9]/div/div/select")))
                {
                    driverobj.select(By.XPath("//div[@id='content']/div[2]/div/div[9]/div/div/select"), "Internal");
                }
                tocreatedriverobj = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }
        }
        public void linkmyresponsibilitiesclick()
        {
            try
            {

                driverobj.WaitForElement(By.XPath(".//*[@id='utility-nav']/ul[1]/li[2]/a"));

                driverobj.HoverLinkClick(By.XPath(".//*[@id='utility-nav']/ul[1]/li[2]/a"), By.XPath("//a[@href='/admin/myresponsibilities/training.aspx']"));
                //  driverobj.GetElement(ObjectRepository.myResponsibilities);
                if (driverobj.existsElement(By.XPath("//a[contains(.,'Content Items')]")))
                {
                    return;
                }
                else if (!driverobj.existsElement(ObjectRepository.searchHome))
                {
                    driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/admin/MyResponsibilities/Training.aspx']"));
                    driverobj.WaitForElement(ObjectRepository.searchHome);
                }
                else
                {
                    driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/admin/MyResponsibilities/Training.aspx']"));
                    driverobj.WaitForElement(ObjectRepository.searchHome);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }


        }
        //content search
        public bool populatecontentsearchsimple(string statusfilter, string texttosearch, string i)
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(texttosearch+i);
                // Thread.Sleep(2000);
                //     driverobj.FindSelectElementnew(ObjectRepository.MyRespnsibilitySearchFilter, filtertext);
                driverobj.ClickEleJs(By.XPath("//a[@id='btnSearch']"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttoncontentsearchclick()
        {

            try
            {
                driverobj.ClickEleJs(locator.contentsearchSearchbutton);
                driverobj.WaitForElement(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails"));

                return true;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                return false;
            }

        }
        public bool populatecontentsearchadvance1(string statusfilter, string texttosearch1, string Desctext, int i, string filtercourse)
        {
            try
            {
                driverobj.GetElement(locator.contentsearchSearchfortxtbx).SendKeysWithSpace(texttosearch1);
                driverobj.GetElement(locator.contentsearchSearchAdvlnk).Click();
                // driverobj.WaitForElement(locator.contentsearchSearchDescriptiontxtbx);
                //   driverobj.GetElement(locator.contentsearchSearchDescriptiontxtbx).SendKeysWithSpace(Desctext);
                driverobj.WaitForElement(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"));
                driverobj.select(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"), filtercourse);
                //driverobj.FindSelectElementnew(locator.contentsearchSearchfilterdrpdwn, statusfilter);
                //driverobj.GetElement(locator.scoretextbox).SendKeysWithSpace(texttosearch);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populatecontentsearchadvance(string statusfilter, string texttosearch1, string Desctext, int i)
        {
            try
            {
                driverobj.GetElement(locator.contentsearchSearchfortxtbx).SendKeysWithSpace(texttosearch1);
                driverobj.GetElement(locator.contentsearchSearchAdvlnk).ClickWithSpace();
                // driverobj.WaitForElement(locator.contentsearchSearchDescriptiontxtbx);
                //   driverobj.GetElement(locator.contentsearchSearchDescriptiontxtbx).SendKeysWithSpace(Desctext);
                driverobj.WaitForElement(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"));
                driverobj.select(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"), "General Course");
                //driverobj.FindSelectElementnew(locator.contentsearchSearchfilterdrpdwn, statusfilter);
                //driverobj.GetElement(locator.scoretextbox).SendKeysWithSpace(texttosearch);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void buttonsearchgoclick(string Title, string filtertext)
        {

            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(Title);
                // Thread.Sleep(2000);
                //     driverobj.FindSelectElementnew(ObjectRepository.MyRespnsibilitySearchFilter, filtertext);
                driverobj.ClickEleJs(By.XPath("//a[@id='btnSearch']"));
             



            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

        }
        public string buttondeletesectionclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_header_FormView1_btnDelete']")).Click();


                Thread.Sleep(3000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                result = driverobj.GetElement(locator.sectiondetailssuccessmessage).Text;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        public bool buttoncourseeditclick()
        {

            try
            {
                driverobj.ClickEleJs(locator.sectiondetailsEdit);
                // driverobj.SelectFrame();
                driverobj.WaitForElement(locator.driverobjKeywordupdate);
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string populateeditclassroomsummaryform(string keyword)
        {

            try
            {

                driverobj.WaitForElement(locator.driverobjKeywordupdate);
                driverobj.GetElement(locator.driverobjKeywordupdate).Clear();
                driverobj.GetElement(locator.driverobjKeywordupdate).SendKeysWithSpace(keyword);
                //  driverobj.GetElement(locator.driverobjSummaryCreditValuetextbox).Clear();
                //  driverobj.GetElement(locator.driverobjSummaryCreditValuetextbox).SendKeysWithSpace("3");
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);
                return "true";
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string buttonsaveeditclassroomsaveclick()
        {

            try
            {
                driverobj.GetElement(locator.driverobjUpdateSave).ClickWithSpace();
                driverobj.WaitForElement(locator.contentaccessapprovalsuccessmessage);
                string text = driverobj.GetElement(locator.contentaccessapprovalsuccessmessage).Text;
                driverobj.SwitchtoDefaultContent();
                // driverobj.SwitchTo().DefaultContent();
                driverobj.Checkin();
                return text;
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public void linkdriverobjclick()
        {
            if (tocreatedriverobj == false)
            {
                return;
            }

            try
            {
                driverobj.WaitForElement(locator.driverobjsLink);
                driverobj.GetElement(locator.driverobjsLink).Click();
                driverobj.WaitForElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }

        }
        public void buttongoclick()
        {
            if (tocreatedriverobj == false)
            {
                return;
            }
            try
            {
                driverobj.select(ObjectRepository.selectcoursetype, "General Course");
                driverobj.GetElement(ObjectRepository.goCreateClassroombtn).Click();
                driverobj.WaitForElement(ObjectRepository.classroomTitle);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }

        }



        public void tabcontentmanagementclick()
        {


            try
            {
                driverobj.WaitForElement(locator.myresponsibilitiescontentmanagementtab);
                driverobj.ClickEleJs(locator.myresponsibilitiescontentmanagementtab);
                driverobj.WaitForElement(locator.myresponsibilitiescontentmanagementgobutton);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populateCourseFilesform(IWebDriver iSelenium)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.generalcourseboostindex);

                driverobj.GetElement(ObjectRepository.generalcourseboostindex).SendKeysWithSpace("2");
               // driverobj.GetElement(locator.driverobjurlradio).Click();
                driverobj.ClickEleJs(locator.driverobjurlradio);
                //    driverobj.GetElement(ObjectRepository.generalcourseurl_txtfld).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Url"]);
                driverobj.GetElement(locator.createdriverobjurl).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Url"]);

                //    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_UploadFiles_COURSE_SAVE_FILE")).Click();


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }
        }
        public bool buttoncreateclick(IWebDriver iSelenium)
        {
            if (tocreatedriverobj == false)
            {
                return false;
            }
            try
            {

                driverobj.WaitForElement(ObjectRepository.create_btn_new);
                driverobj.GetElement(ObjectRepository.create_btn_new).Click();

                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
              //  driverobj.WaitForElement(ObjectRepository.myResponsibilities);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return false;

            }
            return true;//throws information is saved
        }
        internal bool ClickonCheckinButton()
        {
            try
            {

                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                driverobj.GetElement(ObjectRepository.CheckinNew).Click();
           //     driverobj.WaitForElement(ObjectRepository.myResponsibilities);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        internal bool buttoncreateclick_WithoutCheckin(IWebDriver iSelenium)
        {
            if (tocreatedriverobj == false)
            {
                return false;
            }
            try
            {
                driverobj.WaitForElement(ObjectRepository.create_btn_new);
                driverobj.GetElement(ObjectRepository.create_btn_new).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return false;

            }
            return true;//throws information is saved
        }
        public string buttonenrolclick(IWebDriver iSelenium)
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.generalcourseenroll_btn);
                driverobj.GetElement(ObjectRepository.generalcourseenroll_btn).Click();
                Thread.Sleep(5000);
                actualresult = driverobj.GetElement(ObjectRepository.generalcourselaunchattept).GetAttribute("value");
                // result = driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")).GetAttribute("value");
                return actualresult;


                //result = driverobj.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return actualresult;

            }

        }
        public bool buttonopenitemclick(IWebDriver iSelenium)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.generalcourselaunchattept);
                driverobj.GetElement(ObjectRepository.generalcourselaunchattept).Click();
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return false;

            }
            return true;
        }
        public void buttonmarkcompleteclick(IWebDriver iSelenium)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.generalcourseMarkCompleteBlock);
                driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteBlock).Click();
                Thread.Sleep(5000);
                togenralcoursecomplete = true;
                //   result = driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")).GetAttribute("value");



                //result = driverobj.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                togenralcoursecomplete = false;
            }

        }
        public string buttonmarkcompleteframeclick(IWebDriver iSelenium)
        {
            string actualresult = string.Empty;
            if (togenralcoursecomplete == false)
            {
                return actualresult;
            }
            try
            {
                // driverobj.SwitchTo().Frame(1);
                driverobj.waitforframe(ObjectRepository.switchToFrame_New); 
                //driverobj.SelectFrame();
                driverobj.WaitForElement(ObjectRepository.generalcourseMarkCompleteButton);
                driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteButton).Click();
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                actualresult = driverobj.GetElement(ObjectRepository.generalcoursecertificateblock).GetAttribute("value");
                return actualresult;
                //result = driverobj.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return actualresult;

            }


        }
        public void buttoncoursecreationgoclick(string text)
        {

            try
            {
                // driverobj.FindElement(By.XPath("//select[@id='MainContent_ucSearchTop_ddlCreateNew']")).;
                driverobj.select(locator.myresponsibilitiescontentmanagementselectcoursedropdown, text);
                //    driverobj.FindSelectElementnew(locator.myresponsibilitiescontentmanagementselectcoursedropdown, text);
                driverobj.GetElement(locator.myresponsibilitiescontentmanagementgobutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.classroomTitle);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populateCourseFilesframe(IWebDriver iSelenium)
        {

            try
            {
                driverobj.ScrollToCoordinated("500", "500");
                driverobj.WaitForElement(By.Id("MainContent_MainContent_ucCourseFiles_lnkEdit"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucCourseFiles_lnkEdit"));

                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_EXTERNALFILE_URL"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_EXTERNALFILE_URL"));
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_DOCUMENT_URL")).SendKeysWithSpace("www.yahoo.com");

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }
        }
        public bool linkcontentmanagesurveyclick()
        {

            try
            {
                driverobj.WaitForElement(locator.contentmanagelink);
                driverobj.ClickEleJs(locator.contentmanagelink);
                driverobj.WaitForElement(locator.surveysassignsurveyslink);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkassignsurveyclick()
        {

            try
            {
                driverobj.WaitForElement(locator.surveysassignsurveyslink);
                driverobj.GetElement(locator.surveysassignsurveyslink).ClickWithSpace();

                //   driverobj.WaitForElement(locator.surveyframesearchtxtbox);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttonsearchsurveyclick()
        {

            try
            {
                // driverobj.SelectFrame(locator.surveyframesearchbutton);
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_btnSearch")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool selectcheckbox()
        {

            try
            {
                driverobj.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string savebuttonclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_Save")).ClickWithSpace();
                //    driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(locator.surveyremovebutton);
                result = driverobj.GetElement(locator.surveyremovebutton).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        public string buttoncoursefileseditclick()
        {
            string result = string.Empty;

            try
            {

                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_MbtnSave")).ClickWithSpace();
                driverobj.WaitForElement(locator.sucessmessage);
                result = driverobj.GetElement(locator.sucessmessage).Text;
                driverobj.SwitchtoDefaultContent();
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        internal void CreateGeneralCource(string browserstr, string courseCheckinRequired)
        {
            Trainings Trainingsobj = new Trainings(driverobj);
            linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
          //  buttoncoursecreationgoclick("General Course");
            populatesummarygeneralcourse(driverobj, ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, ExtractDataExcel.MasterDic_genralcourse["Desc"], 9);
            populateCourseFilesform(driverobj);
            if (courseCheckinRequired.Equals("Yes"))
                Assert.IsTrue(buttoncreateclick(driverobj));
            else
                Assert.IsTrue(buttoncreateclick_WithoutCheckin(driverobj));
        }
        public bool VelidateAllPossibleActionforGCTraningType(string browserstr, string courseType)
        {
            try
            {
                CurrentTrainings curentTrn = new CurrentTrainings(driverobj);
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                ValidateEnrollActionGeneral_Course(browserstr,courseType);
                ValidateCancellEnrollActionGeneral_Course(browserstr,courseType);
                ValidateOpenEnrollActionGeneral_Course(browserstr,courseType);
                ValidateResumeActionGeneral_Course(browserstr,courseType);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal void SearchTraningAndOpneItem(string browserstr)
        {
            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
            driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]")).ClickWithSpace();
            Thread.Sleep(2000);
            driverobj.WaitForElement(By.CssSelector("input[id*='_EnrollButton']"));
        }
        internal void ValidateEnrollActionGeneral_Course(string browserstr, string courseType)
        {
            try
            {
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Enroll", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Enroll"),browserstr,courseType);
                driverobj.WaitForElement(By.CssSelector("span[class='multiselect-selected-text']"));
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", By.CssSelector("a[id*='DefaultComboBtn']"), browserstr, courseType);
        
                //-------------------
                //driverobj.GetElement(enrollButton).ClickWithSpace();
                //Thread.Sleep(2000);
                //driverobj.WaitForElement(openItemButton);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void ValidateCancellEnrollActionGeneral_Course(string browserstr, string courseType)
        {
            try
            {
                driverobj.ClickOn_TraningType(By.XPath("By.XPath(.//*[@id='ctl00_MainContent_UC3_RadGrid1_ctl00__0']/td[4]/div/a[2]))"), browserstr, courseType);
                driverobj.ClickEleJs(By.LinkText("Cancel Enrollment"));
                Thread.Sleep(3000);
                driverobj.WaitForElement(sucessMessage);
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Enroll", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
                //-------------
                //driverobj.WaitForElement(cancellEnrollButton);
                //driverobj.GetElement(cancellEnrollButton).ClickWithSpace();
                //Thread.Sleep(2000);
                //if (!(driverobj.WaitForElement(enrollButton) && driverobj.WaitForElement(sucessMessage)))
                //{ throw new Exception("After Cancell Enroll request >> either page is not redirecting to Enroll home page or enrollement cancell sucessful message is not coming"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void ValidateOpenEnrollActionGeneral_Course(string browserstr,string courseType)
        {
            try
            {
                driverobj.ClickOn_TraningType(By.LinkText("Enroll"),browserstr,courseType);
                Thread.Sleep(2000);
                driverobj.WaitForElement(sucessMessage);
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", By.CssSelector("a[id*='DefaultComboBtn']"), browserstr,courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Open Item"),browserstr,courseType);
                driverobj.SelectWindowClose2("Google","Current Training");
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Resume", By.CssSelector("a[id*='DefaultBtn']"), browserstr,courseType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void ValidateResumeActionGeneral_Course(string browserstr,string courseType)
        {
            try
            {
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                //string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Resume", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Resume"), browserstr, courseType);
                driverobj.SelectWindowClose2("Google", "Current Training");
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Resume", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal bool ValidatePreviewButton_generalCourse()
        {
            bool actualres = false;
            try
            {
                if (driverobj.IsElementVisible(By.CssSelector("input[id*='_btnPreview']")))
                {
                    string originalHandle = driverobj.CurrentWindowHandle;
                    driverobj.ClickEleJs(By.CssSelector("input[id*='_btnPreview']"));
                    Thread.Sleep(3000);
                    driverobj.SelectWindowClose2("Google", "Content");
                    if (driverobj.IsElementVisible(ObjectRepository.sucessmessage))
                    {
                        throw new Exception("Sucess Messgae should not come on closing the Document course window open from Preview button");
                    }
                    else
                    {
                        actualres = true;
                    }
                }
                else
                {
                    throw new Exception("Preview Button is not displayed for SCORM course after create");
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualres;
        }
        internal void ManageGeneralCourseCourse(string browserstr)
        {
            try
            {
                linkmyresponsibilitiesclick();
                //tabcontentmanagementclick();
                buttonsearchgoclick(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, "Exact phrase");
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
                driverobj.Checkout();
                buttoncourseeditclick();
                populateeditclassroomsummaryform("testchange");
                buttonsaveeditclassroomsaveclick();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }

        public bool createGeneralCourse(string browserstr)
        {
            bool result = false;
            try
            {
                Document documentobj = new Document(driverobj);
                Trainings Trainingsobj = new Trainings(driverobj);
                documentobj.linkmyresponsibilitiesclick();
                Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
                documentobj.populatesummarygeneralCourse(driverobj, ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                documentobj.populateCourseFilesform(driverobj, true);
                driverobj.ScrollToCoordinated("500", "500");
                documentobj.buttoncreateclick(driverobj);

                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool manageGeneralCourse(string browserstr)
        {
            bool result = false;
            try
            {
                Document documentobj = new Document(driverobj);
                Trainings Trainingsobj = new Trainings(driverobj);
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'Summary')]"));
                driverobj.GetElement(By.XPath("//textarea[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS']")).SendKeysWithSpace(" Edited ");
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));

                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        private By btn_allcontenttype = By.XPath(".//*[@id='MainContent_UC3_pnlHeader']/div[1]/span[2]/div/button");
        private By multiSelectClick = By.CssSelector("button[class*='multiselect']");
        private By enrollButton = By.CssSelector("a[id='DefaultBtn']");
        private By openItemButton = By.CssSelector("a[id='DefaultComboBtn']");
        private By cancellEnrollButton = By.CssSelector("a[id='btnCancelEnroll']");
        private By sucessMessage = By.XPath("//div[@class='alert alert-success']");
        private By alertForAccess = By.XPath("//div[@class='alert alert-info']");
        private By resumeButton = By.CssSelector("a[id='DefaultBtn']");
        public static class locator
        {
            public static By driverobjUpdateSave = By.Id("MainContent_MainContent_UC1_Save");
            public static By driverobjSave = By.Id("MainContent_UC1_Save");
            public static By driverobjKeywordupdate = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By driverobjKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By myresponsibilitiescontentmanagementselectcoursedropdown = By.Id("MainContent_ucSearchTop_ddlCreateNew");
            public static By myresponsibilitiescontentmanagementtab = By.XPath("//a[@href='../ContentSearch.aspx']");
            public static By myresponsibilitiescontentmanagementgobutton = By.Id("MainContent_ucSearchTop_btnCreateNew");
            public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
            public static By driverobjuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");
            public static By driverobjtrainingpurposetype = By.Id("MainContent_UC1_FormView1_EREP_DET_TRG_PURPOSE_TYPE");
            public static By driverobjtrainingsourcetypecode = By.Id("MainContent_UC1_FormView1_EHRI_CRSW_TR_SRC_TYP_CO");
            public static By createdriverobjurl = By.Id("MainContent_UC1_DOCUMENT_URL");
            public static By driverobjurlradio = By.Id("MainContent_UC1_EXTERNALFILE_URL");
            public static By driverobjSummaryCreditValuetextbox = By.Id("MainContent_UC1_CRSW_CREDIT_VALUE");
            public static By ManageSectionsLink = By.Id("MainContent_hlScheduling");
            public static By AddNewsectionBtn = By.Id("MainContent_MainContent_ucTopBar_FormView1_btnAddNewSection");
            public static By SectionTitle = By.Id("MainContent_UC1_FormView1_CRSSECT_TITLE");
            public static By NxtBtn = By.Id("MainContent_UC1_btnNext");
            public static By StartDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput");
            public static By EndDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput");
            public static By AllDayEvnt = By.Id("MainContent_UC1_FormView1_EVT_ALLDAYEVENT");
            public static By MinimumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
            public static By MaximumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
            public static By SaveAndExit = By.Id("MainContent_UC1_btnSave");
            public static By ChangeEnrolDate = By.Id("MainContent_UC1_FormView1_lnkEnrollInfo");
            public static By EnroStartDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput");
            public static By EnrolEndDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput");
            public static By EnroStartDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_popupButton");
            public static By EnrolEndDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_popupButton");
            public static By EnrolStartTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput_text");
            public static By EnrolEndTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput_text");
            public static By ClassroomCalendarView = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
            public static By manageenrollmentenrolusersbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnEnrollUser");
            public static By manageenrollmentmanageenrollmentbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnManageEnrollment");
            public static By cancelenrolmentselectwaitlistcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl06_cbSelected");
            public static By cancelenrolmentselectenrolledcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbSelected");
            public static By cancelenrolmentorwaitlistreasontextbox = By.Id("MainContent_UC1_tbUnenrollReason");
            public static By cancelenrolmentorwaitlistcancelenrolmentorwaitlistbutton = By.Id("MainContent_UC1_btnCancelEnrollWaitlist");
            public static By waitlistuserswaitlistusersbutton = By.Id("MainContent_UC1_btnWaitlistUsers");
            public static By batchenrollmentlastnametxtbox = By.Id("MainContent_UC1_USR_LAST_NAME");
            public static By batchenrollmentfirstnametxtbox = By.Id("MainContent_UC1_USR_FIRST_NAME");
            public static By batchenrollmentsearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By batchenrollmentselectcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbEnrolluser");
            public static By batchenrollmenticon = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_btnInfo");
            public static By batchenrollmentcancelicon = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_MImageButton2");
            public static By waitlistselectcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbWaitlist");
            public static By batchenrollmenttablelastnamelabel = By.XPath("//td[contains(.,'Site')]");
            public static By batchenrollmentbatchenrollusersbutton = By.Id("MainContent_UC1_btnEnrollUsers");
            public static By manageenrollmentmanagewaitlistbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnManageWaitlist");
            public static By batchenrollmentfeedback = By.XPath("//div[@class='alert alert-success']");
            public static By schedulemanagesectionSearcfortxtbox = By.Id("filterNameCode");
            public static By schedulemanagesectionSectionstatusdrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSectionStatus");
            public static By schedulemanagesectionActivitydrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSearchActivity");
            public static By schedulemanagesectionStartdatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdStartDate_dateInput");
            public static By schedulemanagesectionEnddatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdEndDate_dateInput");
            public static By schedulemanagesectionFilterbutton = By.XPath(".//*[@id='MainContent_pnlMVCSection']/div[1]/div[2]/div/div[1]/div/span/button");
            public static By schedulemanagesectionResulttable = By.XPath("//tr[@id = 'ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0']/td/a");
            public static By schedulemanagesectionclassroomcalendarlink = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
            public static By editeventselectlocationbutton = By.Id("MainContent_UC1_FormView1_lnkSelectLoc");
            public static By selectlocationframesearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By selectlocationframesroomtyperadiobutton = By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect");
            public static By selectlocationframessaveandexitbutton = By.Id("MainContent_UC1_Save");
            public static By selectlocationssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By LogoutHoverLink = By.XPath("//a[normalize-space()='Logout']");
            public static By classroomcalendarviewlink = By.XPath("//a[contains(@id,'lnkDetails')]");

            public static By driverobjsLink = By.XPath("//span[contains(.,'Content Management')]");
            public static By classroomTitle = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");

            public static By classroomDesc = By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']");
            public static By classroomKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By classroomsectionMinimumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
            public static By classroomsectionMaximumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
            public static By contentaccessapprovaleditbutton = By.Id("MainContent_MainContent_ucAccessApproval_accAccesApproval_lnkEdit");
            public static By contentaccessapprovalsuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By contentdeletecontentbutton = By.Id("MainContent_header_FormView1_btnDelete");
            public static By contentmanagelink = By.Id("MainContent_MainContent_UC4_hlManage");
            public static By managestudentsmanagesurveylink = By.Id("MainContent_UC4_hlManage");
            public static By sectiondetailsmanagelink = By.Id("MainContent_MainContent_ucEvaluations_hlManage");
            public static By surveysassignsurveyslink = By.Id("MainContent_MainContent_UC1_btnAssignSurveys");
            public static By surveyframesearchtxtbox = By.Id("MainContent_UC1_txtSearchFor");
            public static By surveyframesearchtxtfilter = By.Id("MainContent_UC1_ddlSearchType");
            public static By surveyframesearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By surveyframeselectchkbox = By.Id("ctl00_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect");
            public static By surveyframesavebutton = By.Id("MainContent_UC1_Save");
            public static By surveyremovebutton = By.Id("MainContent_MainContent_UC1_btnRemove");
            public static By contentsearchSearchAdvlnk = By.XPath("//a[contains(.,'See more search criteria')]");
            public static By contentsearchSearchfortxtbx = By.Id("MainContent_ucSearchTop_SearchFor");
            public static By contentsearchSearchfilterdrpdwn = By.Id("MainContent_ucSearchTop_SearchType");
            public static By contentsearchSearchTitletxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_TITLE");
            public static By contentsearchSearchDescriptiontxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_DESCRIPTION");
            public static By contentsearchSearchKeywordstxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_KEYWORDS");
            public static By contentsearchSearchCategorytxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNTCTGY_CATEGORY_ID");
            public static By contentsearchSearchRatingfilterdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_strRatingType");
            public static By contentsearchSearchRatingdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_intRating");
            public static By contentsearchSearchEditingStatusdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchStatusType");
            public static By contentsearchSearchActivitydrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchActivity");
            public static By contentsearchSearchbutton = By.Id("btnSearchCourses");
            public static By contentsearchResultTable = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By contentsearchItemscountlbl = By.Id("MainContent_ucSearchResults_lblItemCount");
            public static By MyRespnsibilitySearch = By.Id("MainContent_ucAdminQuickSearch_txtSearch");
            public static By MyRespnsibilitySearchFilter = By.Id("ddlSearchType");
            public static By MyRespnsibilitySearchButton = By.Id("btnContentSearch");
            public static By ContentSearchResultTitle = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By contentsearchresultcount = By.XPath("/html/body/form/div[6]/div/div[6]/div/div[3]");
            public static By sectiondetailscopybutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkCopy");
            public static By copyframedatetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_DATE_dateInput");
            public static By copyframetimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_TIME_dateInput");
            public static By copyframecopybutton = By.Id("MainContent_UC1_Save");
            public static By sectiondetailssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By courseinformationtrainingpurposetypecodedrpdwn = By.Id("MainContent_UC1_FormView1_EREP_DET_TRG_PURPOSE_TYPE");
            public static By courseinformationtrainingsourcetypecodedrpdwn = By.Id("MainContent_UC1_FormView1_EHRI_CRSW_TR_SRC_TYP_CO");
            public static By courseinformationuniqueidtextbox = By.Id("MainContent_UC1_CNT_NUMBER");
            public static By CourseSectionLink1 = By.Id("MainContent_hldriverobjware");
            public static By eventselecteventcheckbox = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_chkSelect");
            public static By eventremoveeventbutton = By.Id("MainContent_UC1_FormViewButton_btnGo");
            public static By deleteeventsuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By detailsenrolbutton = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnEnroll");
            public static By detailssectioninfo = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/img");
            public static By myresponsibilitiesmycontenttitlelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By myresponsibilitiesaddnew = By.Id("MainContent_ucLastModifiedContent_hlAddNew");
            public static By myresponsibilitiesinstructortoolsportletdrpdwn = By.Id("MainContent_ucInstructorToolsSummary_Instructor");
            public static By myresponsibilitiesinstructortoolsportletbutton = By.Id("MainContent_ucInstructorToolsSummary_btnSearch");
            public static By myresponsibilitiesinstructortoolsportlettableresult = By.Id("ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00_ctl04_lnkDetails");
            public static By myresponsibilitiesinstructortoolsportlettableresultcount = By.XPath("//div[3]/div[2]/table/tbody/tr");
            public static By detailseventschedulesectiontitle = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl06_rgEvents_ctl00_ctl04_MLabel2");
            public static By sectiondetailediteventlink = By.Id("MainContent_MainContent_ucSectionEvents_MAccordion1_lbEdit");
            public static By eventseditbutton = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_btnGo");
            public static By editeventstrttimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_START_TIME_dateInput");
            public static By editeventendtimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_TIME_dateInput");
            public static By editeventsaveandexitbutton = By.Id("MainContent_UC1_btnSave");
            public static By eventssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By expensesprofessionalservices = By.Id("CRSSECT_PROF_SERVICE");
            public static By expensesfacilityservices = By.Id("MainContent_UC1_FormView1_CRSSECT_FACILITY_FEES");
            public static By expensestravelexpenses = By.Id("MainContent_UC1_FormView1_CRSSECT_TRAVEL_EXPENSES");
            public static By expensesequipmentrental = By.Id("MainContent_UC1_FormView1_CRSSECT_EQUIPMENT_RENTAL");
            public static By expensessavebutton = By.Id("MainContent_UC1_Save");
            public static By managestudentsinstructortoolslink = By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li[4]/a/span");
            public static By managestudentsmyteachingscheduletab = By.Id("MainContent_UC1_lbMyTeachingSchedule");
            public static By managestudentsmanagestudentstab = By.Id("MainContent_UC1_lbManageStudentsActive");
            public static By searchHome = By.Id("btnContentSearch");
            public static By goCreateClassroombtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
            public static By informationcitylabel = By.Id("MainContent_UC1_PopUpUserInfo_lblCityTxt");
            public static By manageenrolmentforonlinecoursebuttonenrollcourse = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnEnrollUser");
            public static By manageenrolmentforonlinecoursesearchbutton = By.Id("btnSearchCourses");
            public static By manageenrolmentforonlinecoursesearchtextbox = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
            public static By manageenrolmentforonlinecoursefilterdropdown = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
            public static By manageenrolmentforonlinecourseresulttablelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By myResponsibilities = By.Id("NavigationStrip1_lbMyResponsibilities");
            public static By manageenrolmentforonlinecoursemanageenrollment = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnManageEnrollment");

            // general course
            public static By create_btn_new = By.Id("MainContent_UC1_Save");
            public static By genCourseTitle_ED = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
            public static By driverobjenroll_btn = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
            public static By driverobjkeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By myresponsibilitiesmanageenrolmentonlinecourses = By.Id("MainContent_ucManageEnrollmentMenu_hlManageOnlineEnrollement");

            public static By myresponsibilitiesmostrecentrequestusernamelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkContentTitle");
            public static By myresponsibilitiesmostrecentrequestcontenttitlelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkSectionTitle");
            public static By myresponsibilitiestodaylink = By.Id("MainContent_ucBrowseByDate_CreatedBy");
            public static By myresponsibilitiesviewallcoursesbutton = By.Id("MainContent_ucLastModifiedContent_lbAllContent");
            public static By org_select_link = By.Id("MainContent_UC1_lnkSelectOrg");
            public static By org_search_text = By.Id("MainContent_UC1_txtSearch");
            public static By org_search_btn = By.Id("MainContent_UC1_btnSearch");
            public static By org_radio_btn = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
            public static By org_save_btn = By.Id("MainContent_UC1_Save");
            public static By org_create_btn = By.Id("MainContent_UC1_Create");
            public static By login_name = By.CssSelector("span.rmText.rmExpandDown");

            public static By createnewcoursesectionandeventradiobutton = By.Id("MainContent_UC1_FormView1_CRSSECT_WAITLIST_OPTION_0");
            public static By scheduleandmanagesectionsmanageenrollmentbutton = By.Id("MainContent_header_FormView1_lnkManageEnroll");
            public static By schedulemanagesectionsectiontitlelink = By.CssSelector("#ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0 > td > a");
            public static By sectiondetailsEdit = By.Id("MainContent_MainContent_ucSummary_lnkEdit");
            public static By contentclassroomtitlelabel = By.Id("MainContent_MainContent_ucSummary_FormView1_MLabel2");
            public static By sectiondetaildeletesectionbutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkDelete");
            public static By sectiondetailsdeletemessage = By.XPath("//div[@class='alert alert-success']");
            public static By sectiondetailexpenseseditlink = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lbEdit");
            public static By sectiondetailexpensestotal = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lblTotalValue");
            public static By sectionenrolsucessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By sectioninformationclosewindowlink = By.Id("ML.BASE.CMD.CloseWindow");
            public static By sectionsucessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By sucessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By attendancebutton = By.Id("MainContent_UC1_btnAttendance");
            public static By HoverMainLink = By.XPath("/html/body/form/div[6]/div/div/div/div[2]/div/div/ul/li/a/span");
          
        }
        //public string Createdriverobj(IWebDriver iSelenium)
        //{
        //  //  string result = string.Empty;
        //    try
        //    {    
        //        driverobj.GetElementOnPage(By.XPath(Object.gereralcourse_link));
        //        driverobj.GetElement(By.XPath(Object.gereralcourse_link), 90, true).Click();
        //        driverobj.GetElement(By.Id(Object.go_btn), 90, true);
        //        driverobj.GetElement(By.Id(Object.go_btn),90,true).Click();
        //        //Thread.Sleep(10000);
        //        //driverobj.GetElement(By.Id(Object.genCourseTitle_ED));
        //        driverobj.GetElement(By.Id(Object.genCourseTitle_ED), 90, true).SendKeysWithSpace(ExtractDataExcel.driverobj("courseTitle"));
        //        driverobj.GetElement(By.Id(Object.description), 90, true).SendKeysWithSpace(ExtractDataExcel.driverobj("desc"));
        //        driverobj.GetElement(By.Id(Object.keyword), 90, true).SendKeysWithSpace(ExtractDataExcel.driverobj("desc"));
        //        driverobj.GetElement(By.Id(Object.nxt_btn), 90, true).Click();
        //       // Thread.Sleep(10000);
        //        driverobj.GetElement(By.Id(Object.rd_btn), 90, true);
        //        driverobj.GetElement(By.Id(Object.rd_btn), 90, true).Click();
        //        driverobj.GetElement(By.Id(Object.url_txtfld), 90, true).SendKeysWithSpace(ExtractDataExcel.driverobj("url"));
        //        driverobj.GetElement(By.Id(Object.Create_BTN), 90, true).Click();
        //       // Thread.Sleep(3000);
        //        result = driverobj.GetElement(By.XPath(Object.Return_Feedback)).Text.ToString();
        //        driverobj.Checkin();
        //        driverobj.GetElement(By.Id(Object.Return),90,true).Click();
        //        Thread.Sleep(5000);
        //        driverobj.GetElement(By.XPath("/html/body/form/div[3]/div[3]/div/table/tbody/tr/td/a[2]"), 90, true).Click();
        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.TakeScreenShot();
        //        Assert.Fail(ex.Message);
        //    }
        //    return result;
        //    }

        //public string Searchdriverobj(IWebDriver iSelenium)
        //{
        //  //  string result = string.Empty;
        //    try
        //    {

        //        driverobj.GetElement(ObjectRepository.TrainingHome, 90, true).Click();
        //        driverobj.GetElement(ObjectRepository.CourseName_Ed, 90, true);
        //        driverobj.GetElement(ObjectRepository.CourseName_Ed, 90, true).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr);//ExtractDataExcel.driverobj("name"));
        //        driverobj.FindSelectElementnew(ObjectRepository.CourseName_Typ, "Contains");
        //        driverobj.GetElement(ObjectRepository.CourseSearch_Btn, 90, true).Click();
        //        Thread.Sleep(5000);
        //        driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "')]"), 90, true);
        //        driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "')]"), 90, true).Click();
        //        result = driverobj.GetElement(By.TagName("Title")).Text;
        //    }

        //    catch (Exception ex)
        //    {
        //        driverobj.TakeScreenShot();
        //        Assert.Fail(ex.Message);
        //    }
        //    return result;
        //}
        //public string Opendriverobj(IWebDriver iSelenium)
        //{
        //  //  string result = string.Empty;

        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.generalcourseenrollbutton, 90, true);
        //        driverobj.GetElement(ObjectRepository.generalcourseenrollbutton, 90, true).Click();
        //        Thread.Sleep(5000);
        //        result = driverobj.GetElement(ObjectRepository.generalcourselaunchfirstattempt).GetAttribute("value");
        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.TakeScreenShot();
        //        Assert.Fail(ex.Message);
        //    }
        //    return result;//throws information is saved
        //}
        //public string Launchdriverobj(IWebDriver iSelenium)
        //{

        //    string result1 = string.Empty;
        //    try
        //    {

        //        driverobj.GetElement(ObjectRepository.generalcourselaunchfirstattempt,90,true).Click();
        //        Thread.Sleep(3000);
        //        driverobj.SelectWindowClose();
        //        Thread.Sleep(5000);
        //       // driverobj.GetElement(By.XPath("//body")).SendKeysWithSpace(Keys.F5);
        //        Thread.Sleep(5000);
        //        result1 = driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteBlock).GetAttribute("value");
        //       int cnt = 0;
        //       while (result1 != "Mark Complete")
        //       {
        //           if (cnt < 5)
        //           {
        //               driverobj.GetElement(By.XPath("//body"),120,true).SendKeysWithSpace(Keys.F5);
        //               driverobj.GetElement(ObjectRepository.generalcourselaunchfirstattempt,90,true).Click();

        //               driverobj.SelectWindowClose();

        //               result1 = driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteBlock).GetAttribute("value");
        //               cnt++;
        //           }
        //       }
        //       result = driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteBlock).GetAttribute("value");
        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.TakeScreenShot();
        //        Assert.Fail(ex.Message);
        //    }
        //    return result;//throws information is saved
        //}
        //public string driverobjComplete(IWebDriver iSelenium)
        //{
        //  //  string result = string.Empty;
        //    string result1 = string.Empty;
        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteBlock,90,true).Click();
        //        Thread.Sleep(3000);
        //        driverobj.SwitchTo().Frame(1);
        //        driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteButton, 90, true).Click();
        //        Thread.Sleep(3000);
        //        driverobj.SwitchTo().DefaultContent();
        //        if (driverobj.GetElement(ObjectRepository.generalcoursecertificateblock).GetAttribute("value") == "View Certificate")
        //        {
        //            result = driverobj.GetElement(ObjectRepository.generalcourselaunchanotherattempt).GetAttribute("value");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.TakeScreenShot();
        //        Assert.Fail(ex.Message);
        //    }
        //    return result;//throws information is saved
        //}



        //public void UserSearchCourse(IWebDriver iSelenium, string coursename)
        //{

        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeysWithSpace(coursename);
        //        driverobj.FindSelectElementnew(ObjectRepository.generalcoursesearchdropdown, "Contains");

        //        driverobj.GetElement(ObjectRepository.generalcoursesearchbutton, 90, true).Click();


        //        Thread.Sleep(5000);
        //        driverobj.GetElement(By.XPath("//a[contains(text(),'" + coursename + "')]"), 90, true).Click();



        //        Thread.Sleep(7000);
        //        driverobj.GetElement(ObjectRepository.generalcourseenroll_btn, 90, true).Click();
        //        Thread.Sleep(7000);
        //        driverobj.GetElement(ObjectRepository.generalcourseunenroll, 90, true);
        //        driverobj.GetElement(ObjectRepository.generalcourselaunchfirstattempt, 90, true).Click();
        //        Thread.Sleep(7000);

        //        driverobj.selectWindow("Google");
        //        Thread.Sleep(5000);
        //        driverobj.Close();
        //        Thread.Sleep(8000);

        //        string title = driverobj.Title;



        //        driverobj.GetElement(ObjectRepository.generalcoursecertificateblock, 90, true).Click();
        //            Thread.Sleep(8000);


        //        driverobj.selectWindow("Message");
        //        Thread.Sleep(3000);
        //        driverobj.Close();

        //        if (title != "Message")
        //        {
        //            string title1 = driverobj.Title;
        //           // MessageBox.Show("" + title1 + "");

        //            driverobj.selectWindow(title1);
        //            Thread.Sleep(3000);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.TakeScreenShot();

        //        Assert.Fail(ex.Message);
        //    }
        //}








    }
}



//:check_in=>[:text,"Check In"],
//      :check_out =>[:text,"Check Out"],
//      :search_course=>[:id,"TabMenu_ML_BASE_TAB_Search_SearchFor"],
//      :search_type =>[:id,"TabMenu_ML_BASE_TAB_Search_SearchType"], 
//      :search_btn =>[:id,"TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"],