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
    class OJT
    {
        private readonly IWebDriver driverobj;
        public bool tocreatedriverobj = false;
        public bool togenralcoursecomplete = false;
        public OJT(IWebDriver driver)
        {
            driverobj = driver;
        }
        public string result = string.Empty;

        

        public void linkmyresponsibilitiesclick()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);
                driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
                driverobj.WaitForElement(ObjectRepository.searchHome);
                tocreatedriverobj = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;


            }

        }
        //content search
        public bool populatecontentsearchsimple(string statusfilter, string texttosearch, string i)
        {
            try
            {
                driverobj.WaitForElement(locator.contentsearchSearchfortxtbx);
                Thread.Sleep(3000);
                driverobj.GetElement(locator.contentsearchSearchfortxtbx).SendKeys(texttosearch + i);
                Thread.Sleep(3000);
                driverobj.FindSelectElementnew(locator.contentsearchSearchfilterdrpdwn, statusfilter);
                //driverobj.GetElement(locator.scoretextbox).SendKeys(texttosearch);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public int countallrequestelements()
        {
            int cnt = 0;
            try
            {
             //   driverobj.WaitForElement(By.ClassName("icon"));
                cnt = driverobj.countelements(By.ClassName("icon"));
                return cnt;

                // driverobj.GetElement(locator.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                return cnt;


            }
        }
        public bool buttoncontentsearchclick()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.Id("MainContent_ucAdminSearch_txtSearchFor"));
                driverobj.ClickEleJs(By.XPath(".//*[@id='btnSearch']"));
                driverobj.WaitForElement(By.XPath(".//*[@id='MGSearchResults']/div[1]/div/h2/strong[1]"));
                actualresult = true;
                
                //Thread.Sleep(5000);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                actualresult = false;
            }
            return actualresult;
        }
        public bool populatecontentsearchadvance(string statusfilter, string texttosearch1, string Desctext, int i)
        {
            try
            {
                driverobj.WaitForElement(locator.contentsearchSearchfortxtbx);
                driverobj.GetElement(locator.contentsearchSearchfortxtbx).SendKeysWithSpace(texttosearch1);
                driverobj.ClickEleJs(locator.contentsearchSearchAdvlnk);
                // driverobj.WaitForElement(locator.contentsearchSearchDescriptiontxtbx);
                //   driverobj.GetElement(locator.contentsearchSearchDescriptiontxtbx).SendKeys(Desctext);
                driverobj.WaitForElement(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"));
                driverobj.select(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"), "On-the-Job Training");
                //driverobj.FindSelectElementnew(locator.contentsearchSearchfilterdrpdwn, statusfilter);
                //driverobj.GetElement(locator.scoretextbox).SendKeys(texttosearch);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void tabcreateandmanagechecklistclick()
        {
            try
            {
               // driverobj.Checkout();
               driverobj.WaitForElement(By.XPath("//a[@id='MainContent_hlChecklist']"));
              driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_hlChecklist']"));
                //driverobj.WaitForElement(locator.ManageSectionsLink);
                //driverobj.GetElement(locator.ManageSectionsLink).Click();
                driverobj.WaitForElement(locator.AddNewsectionBtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

        }
        public void buttonaddnewsectionclick()
        {
         
            try
            {
                driverobj.WaitForElement(locator.AddNewsectionBtn);
                driverobj.ClickEleJs(locator.AddNewsectionBtn);
                driverobj.WaitForElement(locator.SectionTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

        }
        public void buttonsearchgoclick(string Title, string filtertext)
        {

            try
            {
                //driverobj.WaitForElement(locator.MyRespnsibilitySearch);
                //driverobj.GetElement(locator.MyRespnsibilitySearch).Click();
                //Thread.Sleep(2000);
                driverobj.WaitForElement(locator.MyRespnsibilitySearch);
                driverobj.ClickEleJs(locator.MyRespnsibilitySearch);
                driverobj.GetElement(locator.MyRespnsibilitySearch).SendKeys(Title);
                Thread.Sleep(2000);
             //   driverobj.select(locator.MyRespnsibilitySearchFilter, filtertext);
                driverobj.ClickEleJs(locator.MyRespnsibilitySearchButton);
                driverobj.WaitForElement(locator.ContentSearchResultTitle);
                driverobj.ClickEleJs(locator.ContentSearchResultTitle);
                //    driverobj.WaitForElement(locator.ManageSectionsLink);
                    //driverobj.Checkout();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

        }
        //input[@id='MainContent_UC1_btnDelete']
            public void buttonuseecictingchecklist()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(@id,'MLinkButton1')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(@id,'MLinkButton1')]"));
            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);

            }
        }
        public void populatechecklistadd()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_UC1_SearchFor']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_SearchFor']"));
                driverobj.select(By.XPath("//select[@id='MainContent_UC1_SearchType']"), "Exact phrase");
            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);

            }

        }
        public void buttonsearchchecklist()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='btnSearchChecklists']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='btnSearchChecklists']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_rgChecklistSearch_ctl00_ctl04_chkSelect']"));
                driverobj.GetElement(By.XPath("//a[@id='MainContent_UC1_btnAdd']")).Click();
            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);

            }
        }
    
    public void linkchecklistclick()
    {
        try
        {
            driverobj.WaitForElement(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_MHyperLink3']"));
            driverobj.ClickEleJs(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_MHyperLink3']"));
        }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            Console.WriteLine(ex.Message);
           
        }
    }
       
     
       
        public string buttondeletechecklistclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnDelete"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnDelete"));


                Thread.Sleep(3000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                driverobj.WaitForElement(locator.sucessmessage);
                result = driverobj.GetElement(locator.sucessmessage).Text;
                driverobj.Checkin();

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        public string buttondeletesectionclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_header_btnDelete']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_header_btnDelete']"));


                Thread.Sleep(3000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                result = driverobj.GetElement(locator.sectiondetailssuccessmessage).Text;

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        public bool buttoncourseeditclick()
        {

            try
            {
               
                driverobj.WaitForElement(locator.sectiondetailsEdit);
                driverobj.ClickEleJs(locator.sectiondetailsEdit);
              //  driverobj.SelectFrame();
                driverobj.WaitForElement(locator.driverobjupdateKeyword);
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string populateeditclassroomsummaryform(string keyword)
        {

            try
            {

                driverobj.WaitForElement(locator.driverobjupdateKeyword);
                driverobj.ClickEleJs(locator.driverobjupdateKeyword);
                driverobj.GetElement(locator.driverobjupdateKeyword).Clear();
                driverobj.GetElement(locator.driverobjupdateKeyword).SendKeysWithSpace(keyword);
                //  driverobj.GetElement(locator.driverobjSummaryCreditValuetextbox).Clear();
                //  driverobj.GetElement(locator.driverobjSummaryCreditValuetextbox).SendKeys("3");
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);
                return "true";
            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string buttonsaveeditojtsaveclick()
        {

            try
            {
                driverobj.WaitForElement(locator.driverobjupdateSave);
                driverobj.ClickEleJs(locator.driverobjupdateSave);
                driverobj.WaitForElement(locator.contentaccessapprovalsuccessmessage);
                string text = driverobj.GetElement(locator.contentaccessapprovalsuccessmessage).Text;
                driverobj.SwitchTo().DefaultContent();
                driverobj.Checkin();
                return text;
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                driverobj.ClickEleJs(locator.driverobjsLink);
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
            //if (tocreatedriverobj == false)
            //{
            //    return;
            //}
            try
            {
                //driverobj.WaitForElement(ObjectRepository.selectcoursetype);
                //driverobj.select(ObjectRepository.selectcoursetype, "On-the-Job Training");
                //driverobj.ClickEleJs(ObjectRepository.goCreateClassroombtn);
                //driverobj.WaitForElement(ObjectRepository.classroomTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }

        }
        public void populatesummaryojt(IWebDriver iSelenium, string title, string desc, int i)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.genCourseTitle_ED);
                driverobj.ClickEleJs(ObjectRepository.genCourseTitle_ED);
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).SendKeys(title);
             //   driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(ObjectRepository.generalcoursekeyword).SendKeys(desc);
                tocreatedriverobj = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }
        }
        public void populatechecklist(IWebDriver iSelenium, string title, string desc, int i)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.genCourseTitle_updateED);
                driverobj.ClickEleJs(ObjectRepository.genCourseTitle_updateED);
                driverobj.GetElement(ObjectRepository.genCourseTitle_updateED).SendKeysWithSpace(title);
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(ObjectRepository.generalcoursechecklistkeyword).SendKeysWithSpace(desc);
              
            
       
            }
            catch (Exception ex)
            {
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
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populateCourseFilesform(IWebDriver iSelenium)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.generalcourseboostindex);

                driverobj.GetElement(ObjectRepository.generalcourseboostindex).SendKeys("2");
                driverobj.ClickEleJs(locator.driverobjurlradio);
                //    driverobj.GetElement(ObjectRepository.driverobjurl_txtfld).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Url"]);
                driverobj.GetElement(locator.createdriverobjurl).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Url"]);

                //    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_UploadFiles_COURSE_SAVE_FILE")).Click();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                tocreatedriverobj = false;
            }
        }
        public string buttoncreateclick(IWebDriver iSelenium)
        {
            string result = string.Empty;
            try
            {

                driverobj.WaitForElement(ObjectRepository.create_btn_new);
                driverobj.ClickEleJs(ObjectRepository.create_btn_new);

                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                result = driverobj.gettextofelement(locator.sucessmessage);
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                //driverobj.WaitForElement(ObjectRepository.myResponsibilities);
                // Thread.Sleep(3000);
                //driverobj.WaitForElement(ObjectRepository.Return_Feedback);

                //result = driverobj.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return "";

            }
            return result;//throws information is saved
        }
        public string buttonchecklistcreateclick(IWebDriver iSelenium)
        {
            string result = string.Empty;
            try
            {

                driverobj.WaitForElement(ObjectRepository.create_btn_newchklist);
                driverobj.ClickEleJs(ObjectRepository.create_btn_newchklist);
                driverobj.WaitForElement(locator.sucessmessage);
                result = driverobj.gettextofelement(locator.sucessmessage);
              //  driverobj.WaitForElement(By.XPath("//a[contains(.,'Create & Manage Checklists')]"));commented as the form had changed in 18.1
             //   driverobj.ClickEleJs(By.XPath("//a[contains(.,'Create & Manage Checklists')]"));
                
                driverobj.Checkin();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return "";

            }
            return result;//throws information is saved
        }
        public string buttonenrolclick(IWebDriver iSelenium)
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.generalcourseenroll_btn);
                driverobj.ClickEleJs(ObjectRepository.generalcourseenroll_btn);
                Thread.Sleep(5000);
                actualresult = driverobj.GetElement(ObjectRepository.generalcourselaunchattept).GetAttribute("value");
                // result = driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_LaunchAttemptFirst")).GetAttribute("value");
                return actualresult;


                //result = driverobj.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
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
                driverobj.ClickEleJs(ObjectRepository.generalcourselaunchattept);
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
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
                driverobj.ClickEleJs(ObjectRepository.generalcourseMarkCompleteBlock);
                Thread.Sleep(5000);
                togenralcoursecomplete = true;
                //   result = driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_LaunchAttemptFirst")).GetAttribute("value");



                //result = driverobj.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
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
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.generalcourseMarkCompleteButton);
                driverobj.ClickEleJs(ObjectRepository.generalcourseMarkCompleteButton);
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                actualresult = driverobj.GetElement(ObjectRepository.generalcoursecertificateblock).GetAttribute("value");
                return actualresult;
                //result = driverobj.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
            }
            catch (Exception ex)
            {
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
                driverobj.ClickEleJs(locator.myresponsibilitiescontentmanagementgobutton);
                driverobj.WaitForElement(ObjectRepository.classroomTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populateCourseFilesframe(IWebDriver iSelenium)
        {

            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseFiles_accCourseFiles_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseFiles_accCourseFiles_lnkEdit']"));
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeys("www.yahoo.com");

            }
            catch (Exception ex)
            {
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

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkassignsurveyclick()
        {

            try
            {
                driverobj.ClickEleJs(locator.surveysassignsurveyslink);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(locator.surveyframesearchtxtbox);
            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                driverobj.ClickEleJs(locator.surveyframesearchbutton);
                driverobj.WaitForElement(locator.surveyframeselectchkbox);
            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool selectcheckbox()
        {

            try
            {
                driverobj.ClickEleJs(locator.surveyframeselectchkbox);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                driverobj.ClickEleJs(locator.surveyframesavebutton);
                //    driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(locator.surveyremovebutton);
                result = driverobj.GetElement(locator.surveyremovebutton).Text;
                //Thread.Sleep(5000);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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

                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_MbtnSave']"));
                driverobj.WaitForElement(locator.sucessmessage);
                result = driverobj.GetElement(locator.sucessmessage).Text;
                driverobj.SwitchTo().DefaultContent();
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }catch (Exception ex)
            {
ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        internal void CreateOJT_NewUser(string browserstr)
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driverobj);
            classroomcourse.linkmyresponsibilitiesclick(driverobj);
            classroomcourse.linkclassroomcourseclick();
            buttongoclick();
            populatesummaryojt(driverobj, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr + "CT_SortTest", ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            buttoncreateclick(driverobj);
        }
        internal void Search_EnrollOJT_NewUser(string browserstr)
        {
            try
            {
                driverobj.GetElement(ObjectRepository.traininghomesearchtext).SendKeysWithSpace(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr + "CT_SortTest");
                driverobj.GetElement(ObjectRepository.traininghomeSearchButton).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_ojt["Title"] + browserstr + "CT_SortTest" + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_ojt["Title"] + browserstr + "CT_SortTest" + "')]")).Click();
                driverobj.WaitForElement(locator.OJTEnrollButton);
                driverobj.GetElement(locator.OJTEnrollButton).Click();
                driverobj.WaitForElement(locator.sucessmessage);
                driverobj.GetElement(locator.OJTOpenEnrolledCourse).Click();
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-info']"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
 
        }
        internal void CreateOJTCourse(string browserstr)
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driverobj);
            Trainings trainingsobj = new Trainings(driverobj);
            classroomcourse.linkmyresponsibilitiesclick(driverobj);
            trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);
            populatesummaryojt(driverobj, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            buttoncreateclick(driverobj);
        }
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        public static class locator
        {
            public static By driverobjupdateSave = By.Id("MainContent_MainContent_UC1_Save");
            public static By driverobjSave = By.Id("MainContent_UC1_Save");
            public static By driverobjupdateKeyword = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By driverobjKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By myresponsibilitiescontentmanagementselectcoursedropdown = By.Id("MainContent_ucSearchTop_ddlCreateNew");
            public static By myresponsibilitiescontentmanagementtab = By.XPath("//span[contains(.,'Content Management')]");
            public static By myresponsibilitiescontentmanagementgobutton = By.Id("MainContent_ucSearchTop_btnCreateNew");
            public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
            public static By driverobjuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");
            public static By driverobjtrainingpurposetype = By.Id("MainContent_UC1_EREP_DET_TRG_PURPOSE_TYPE");
            public static By driverobjtrainingsourcetypecode = By.Id("MainContent_UC1_EHRI_CRSW_TR_SRC_TYP_CO");
            public static By createdriverobjurl = By.Id("MainContent_UC1_DOCUMENT_URL");
            public static By driverobjurlradio = By.Id("MainContent_UC1_EXTERNALFILE_URL");
            public static By driverobjSummaryCreditValuetextbox = By.Id("MainContent_UC1_CRSW_CREDIT_VALUE");
            public static By ManageSectionsLink = By.Id("MainContent_hlChecklist");
            public static By AddNewsectionBtn = By.Id("MainContent_MainContent_ucTopBar_lnkCreateChecklist");
            public static By SectionTitle = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE");
            public static By NxtBtn = By.Id("MainContent_UC1_btnNext");
            public static By StartDate = By.Id("ctl00_MainContent_UC1_CRSSECT_SECTION_START_DATE_dateInput");
            public static By EndDate = By.Id("ctl00_MainContent_UC1_CRSSECT_SECTION_END_DATE_dateInput");
            public static By AllDayEvnt = By.Id("MainContent_UC1_EVT_ALLDAYEVENT");
            public static By MinimumCapacity = By.Id("MainContent_UC1_CRSSECT_MIN_CAPACITY");
            public static By MaximumCapacity = By.Id("MainContent_UC1_CRSSECT_MAX_CAPACITY");
            public static By SaveAndExit = By.Id("MainContent_UC1_btnSave");
            public static By ChangeEnrolDate = By.Id("MainContent_UC1_lnkEnrollInfo");
            public static By EnroStartDate = By.Id("ctl00_MainContent_UC1_CRSSECT_ENROLL_START_DATE_dateInput");
            public static By EnrolEndDate = By.Id("ctl00_MainContent_UC1_CRSSECT_ENROLL_END_DATE_dateInput");
            public static By EnroStartDate_ = By.Id("ctl00_MainContent_UC1_CRSSECT_ENROLL_START_DATE_popupButton");
            public static By EnrolEndDate_ = By.Id("ctl00_MainContent_UC1_CRSSECT_ENROLL_END_DATE_popupButton");
            public static By EnrolStartTime = By.Id("ctl00_MainContent_UC1_CRSSECT_ENROLL_START_TIME_dateInput_text");
            public static By EnrolEndTime = By.Id("ctl00_MainContent_UC1_CRSSECT_ENROLL_END_TIME_dateInput_text");
            public static By ClassroomCalendarView = By.Id("hlClassroomCalendarView");
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
            public static By batchenrollmentfeedback = By.CssSelector("div.forms-msg-success");
            public static By schedulemanagesectionSearcfortxtbox = By.Id("filterNameCode");
            public static By schedulemanagesectionSectionstatusdrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSectionStatus");
            public static By schedulemanagesectionActivitydrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSearchActivity");
            public static By schedulemanagesectionStartdatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdStartDate_dateInput");
            public static By schedulemanagesectionEnddatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdEndDate_dateInput");
            public static By schedulemanagesectionFilterbutton = By.XPath(".//*[@id='MainContent_pnlMVCSection']/div[1]/div[2]/div/div[1]/div/span/button");
            public static By schedulemanagesectionResulttable = By.XPath("//tr[@id = 'ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0']/td/a");
            public static By schedulemanagesectionclassroomcalendarlink = By.Id("hlClassroomCalendarView");
            public static By editeventselectlocationbutton = By.Id("MainContent_UC1_lnkSelectLoc");
            public static By selectlocationframesearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By selectlocationframesroomtyperadiobutton = By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect");
            public static By selectlocationframessaveandexitbutton = By.Id("MainContent_UC1_Save");
            public static By selectlocationssuccessmessage = By.CssSelector("div.forms-msg-success");
            public static By LogoutHoverLink = By.XPath("//a[normalize-space()='Logout']");
            public static By classroomcalendarviewlink = By.XPath("//a[contains(@id,'lnkDetails')]");

            public static By driverobjsLink = By.XPath("//span[contains(.,'Content Management')]");
            public static By classroomTitle = By.Id("MainContent_UC1_CNTLCL_TITLE");

            public static By classroomDesc = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
            public static By classroomKeyword = By.Id("MainContent_UC1_CNTLCL_KEYWORDS");
            public static By classroomsectionMinimumCapacity = By.Id("MainContent_UC1_CRSSECT_MIN_CAPACITY");
            public static By classroomsectionMaximumCapacity = By.Id("MainContent_UC1_CRSSECT_MAX_CAPACITY");
            public static By contentaccessapprovaleditbutton = By.Id("MainContent_MainContent_ucAccessApproval_accAccesApproval_lnkEdit");
            public static By contentaccessapprovalsuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By contentdeletecontentbutton = By.Id("MainContent_header_btnDelete");
            public static By contentmanagelink = By.Id("MainContent_MainContent_UC4_hlManage");
            public static By managestudentsmanagesurveylink = By.Id("MainContent_UC4_hlManage");
            public static By sectiondetailsmanagelink = By.Id("MainContent_MainContent_ucEvaluations_hlManage");
            public static By surveysassignsurveyslink = By.Id("MainContent_UC1_btnAssignSurveys");
            public static By surveyframesearchtxtbox = By.Id("MainContent_UC1_txtSearchFor");
            public static By surveyframesearchtxtfilter = By.Id("MainContent_UC1_ddlSearchType");
            public static By surveyframesearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By surveyframeselectchkbox = By.Id("ctl00_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect");
            public static By surveyframesavebutton = By.Id("MainContent_UC1_Save");
            public static By surveyremovebutton = By.Id("MainContent_UC1_btnRemove");
            public static By contentsearchSearchAdvlnk = By.XPath("//a[@aria-controls='MainContent_ucSearchTop_pnlAdvanced']");
            public static By contentsearchSearchfortxtbx = By.Id("MainContent_ucSearchTop_SearchFor");
            public static By contentsearchSearchfilterdrpdwn = By.Id("MainContent_ucSearchTop_SearchType");
            public static By contentsearchSearchTitletxtbx = By.Id("MainContent_ucSearchTop_CNT_TITLE");
            public static By contentsearchSearchDescriptiontxtbx = By.Id("MainContent_ucSearchTop_CNT_DESCRIPTION");
            public static By contentsearchSearchKeywordstxtbx = By.Id("MainContent_ucSearchTop_CNT_KEYWORDS");
            public static By contentsearchSearchCategorytxtbx = By.Id("MainContent_ucSearchTop_CNTCTGY_CATEGORY_ID");
            public static By contentsearchSearchRatingfilterdrpdwn = By.Id("MainContent_ucSearchTop_strRatingType");
            public static By contentsearchSearchRatingdrpdwn = By.Id("MainContent_ucSearchTop_intRating");
            public static By contentsearchSearchEditingStatusdrpdwn = By.Id("MainContent_ucSearchTop_SearchStatusType");
            public static By contentsearchSearchActivitydrpdwn = By.Id("MainContent_ucSearchTop_SearchActivity");
            public static By contentsearchSearchbutton = By.Id("btnSearchCourses");
            public static By contentsearchResultTable = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By contentsearchItemscountlbl = By.Id("MainContent_ucSearchResults_lblItemCount");
            public static By MyRespnsibilitySearch = By.Id("MainContent_ucSearchTop_SearchFor");
            public static By MyRespnsibilitySearchFilter = By.Id("MainContent_ucSearchTop_SearchType");
            public static By MyRespnsibilitySearchButton = By.Id("btnSearchCourses");
            public static By ContentSearchResultTitle = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By contentsearchresultcount = By.XPath("/html/body/form/div[6]/div/div[6]/div/div[3]");
            public static By sectiondetailscopybutton = By.Id("MainContent_MainContent_ucSummary_lnkCopy");
            public static By copyframedatetxtbox = By.Id("ctl00_MainContent_UC1_CRSSECT_NEWSTART_DATE_dateInput");
            public static By copyframetimetxtbox = By.Id("ctl00_MainContent_UC1_CRSSECT_NEWSTART_TIME_dateInput");
            public static By copyframecopybutton = By.Id("MainContent_UC1_Save");
            public static By sectiondetailssuccessmessage = By.CssSelector("div.forms-msg-success");
            public static By courseinformationtrainingpurposetypecodedrpdwn = By.Id("MainContent_UC1_EREP_DET_TRG_PURPOSE_TYPE");
            public static By courseinformationtrainingsourcetypecodedrpdwn = By.Id("MainContent_UC1_EHRI_CRSW_TR_SRC_TYP_CO");
            public static By courseinformationuniqueidtextbox = By.Id("MainContent_UC1_CNT_NUMBER");
            public static By CourseSectionLink1 = By.Id("MainContent_hldriverobjware");
            public static By eventselecteventcheckbox = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_chkSelect");
            public static By eventremoveeventbutton = By.Id("MainContent_UC1_FormViewButton_btnGo");
            public static By deleteeventsuccessmessage = By.CssSelector("div.forms-msg-success");
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
            public static By editeventstrttimetxtbox = By.Id("ctl00_MainContent_UC1_EVT_START_TIME_dateInput");
            public static By editeventendtimetxtbox = By.Id("ctl00_MainContent_UC1_EVT_END_TIME_dateInput");
            public static By editeventsaveandexitbutton = By.Id("MainContent_UC1_btnSave");
            public static By eventssuccessmessage = By.CssSelector("div.forms-msg-success");
            public static By expensesprofessionalservices = By.Id("CRSSECT_PROF_SERVICE");
            public static By expensesfacilityservices = By.Id("MainContent_UC1_CRSSECT_FACILITY_FEES");
            public static By expensestravelexpenses = By.Id("MainContent_UC1_CRSSECT_TRAVEL_EXPENSES");
            public static By expensesequipmentrental = By.Id("MainContent_UC1_CRSSECT_EQUIPMENT_RENTAL");
            public static By expensessavebutton = By.Id("MainContent_UC1_Save");
            public static By managestudentsinstructortoolslink = By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li[4]/a/span");
            public static By managestudentsmyteachingscheduletab = By.Id("MainContent_UC1_lbMyTeachingSchedule");
            public static By managestudentsmanagestudentstab = By.Id("MainContent_UC1_lbManageStudentsActive");
            public static By searchHome = By.Id("btnContentSearch");
            public static By goCreateClassroombtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
            public static By informationcitylabel = By.Id("MainContent_UC1_PopUpUserInfo_lblCityTxt");
            public static By manageenrolmentforonlinecoursebuttonenrollcourse = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnEnrollUser");
            public static By manageenrolmentforonlinecoursesearchbutton = By.Id("btnSearchCourses");
            public static By manageenrolmentforonlinecoursesearchtextbox = By.Id("MainContent_ucSearchTop_SearchFor");
            public static By manageenrolmentforonlinecoursefilterdropdown = By.Id("MainContent_ucSearchTop_SearchType");
            public static By manageenrolmentforonlinecourseresulttablelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By myResponsibilities = By.Id("NavigationStrip1_lbMyResponsibilities");
            public static By manageenrolmentforonlinecoursemanageenrollment = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnManageEnrollment");

            // general course
            public static By create_btn_new = By.Id("MainContent_UC1_Save");
            public static By genCourseTitle_ED = By.Id("MainContent_UC1_CNTLCL_TITLE");
            public static By driverobjenroll_btn = By.Id("MainContent_ucPrimaryActions_EnrollButton");
            public static By driverobjkeyword = By.Id("MainContent_UC1_CNTLCL_KEYWORDS");
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

            public static By createnewcoursesectionandeventradiobutton = By.Id("MainContent_UC1_CRSSECT_WAITLIST_OPTION_0");
            public static By scheduleandmanagesectionsmanageenrollmentbutton = By.Id("MainContent_header_lnkManageEnroll");
            public static By schedulemanagesectionsectiontitlelink = By.CssSelector("#ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0 > td > a");
            public static By sectiondetailsEdit = By.Id("MainContent_MainContent_ucSummary_lnkEdit");
            public static By contentclassroomtitlelabel = By.Id("MainContent_MainContent_ucSummary_MLabel2");
            public static By sectiondetaildeletesectionbutton = By.Id("MainContent_MainContent_ucSummary_lnkDelete");
            public static By sectiondetailsdeletemessage = By.CssSelector("div.forms-msg-success");
            public static By sectiondetailexpenseseditlink = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lbEdit");
            public static By sectiondetailexpensestotal = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lblTotalValue");
            public static By sectionenrolsucessmessage = By.CssSelector("div.forms-msg-success");
            public static By sectioninformationclosewindowlink = By.Id("ML.BASE.CMD.CloseWindow");
            public static By sectionsucessmessage = By.CssSelector("div.forms-msg-success");
            public static By sucessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By attendancebutton = By.Id("MainContent_UC1_btnAttendance");
            public static By HoverMainLink = By.XPath("/html/body/form/div[6]/div/div/div/div[2]/div/div/ul/li/a/span");
            public static By OJTEnrollButton = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollOJT");
            public static By OJTOpenEnrolledCourse = By.Id("MainContent_ucPrimaryActions_FormView1_OJTLaunchAttempt");
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
        //        driverobj.GetElement(By.Id(Object.genCourseTitle_ED), 90, true).SendKeys(ExtractDataExcel.driverobj("courseTitle"));
        //        driverobj.GetElement(By.Id(Object.description), 90, true).SendKeys(ExtractDataExcel.driverobj("desc"));
        //        driverobj.GetElement(By.Id(Object.keyword), 90, true).SendKeys(ExtractDataExcel.driverobj("desc"));
        //        driverobj.GetElement(By.Id(Object.nxt_btn), 90, true).Click();
        //       // Thread.Sleep(10000);
        //        driverobj.GetElement(By.Id(Object.rd_btn), 90, true);
        //        driverobj.GetElement(By.Id(Object.rd_btn), 90, true).Click();
        //        driverobj.GetElement(By.Id(Object.url_txtfld), 90, true).SendKeys(ExtractDataExcel.driverobj("url"));
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
        //        driverobj.GetElement(ObjectRepository.CourseName_Ed, 90, true).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr);//ExtractDataExcel.driverobj("name"));
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
        //        driverobj.GetElement(ObjectRepository.driverobjenrollbutton, 90, true);
        //        driverobj.GetElement(ObjectRepository.driverobjenrollbutton, 90, true).Click();
        //        Thread.Sleep(5000);
        //        result = driverobj.GetElement(ObjectRepository.driverobjlaunchfirstattempt).GetAttribute("value");
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

        //        driverobj.GetElement(ObjectRepository.driverobjlaunchfirstattempt,90,true).Click();
        //        Thread.Sleep(3000);
        //        driverobj.SelectWindowClose();
        //        Thread.Sleep(5000);
        //       // driverobj.GetElement(By.XPath("//body")).SendKeys(Keys.F5);
        //        Thread.Sleep(5000);
        //        result1 = driverobj.GetElement(ObjectRepository.driverobjMarkCompleteBlock).GetAttribute("value");
        //       int cnt = 0;
        //       while (result1 != "Mark Complete")
        //       {
        //           if (cnt < 5)
        //           {
        //               driverobj.GetElement(By.XPath("//body"),120,true).SendKeys(Keys.F5);
        //               driverobj.GetElement(ObjectRepository.driverobjlaunchfirstattempt,90,true).Click();

        //               driverobj.SelectWindowClose();

        //               result1 = driverobj.GetElement(ObjectRepository.driverobjMarkCompleteBlock).GetAttribute("value");
        //               cnt++;
        //           }
        //       }
        //       result = driverobj.GetElement(ObjectRepository.driverobjMarkCompleteBlock).GetAttribute("value");
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
        //        driverobj.GetElement(ObjectRepository.driverobjMarkCompleteBlock,90,true).Click();
        //        Thread.Sleep(3000);
        //        driverobj.SwitchTo().Frame(1);
        //        driverobj.GetElement(ObjectRepository.driverobjMarkCompleteButton, 90, true).Click();
        //        Thread.Sleep(3000);
        //        driverobj.SwitchTo().DefaultContent();
        //        if (driverobj.GetElement(ObjectRepository.driverobjcertificateblock).GetAttribute("value") == "View Certificate")
        //        {
        //            result = driverobj.GetElement(ObjectRepository.driverobjlaunchanotherattempt).GetAttribute("value");
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
        //        driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeys(coursename);
        //        driverobj.FindSelectElementnew(ObjectRepository.driverobjsearchdropdown, "Contains");

        //        driverobj.GetElement(ObjectRepository.driverobjsearchbutton, 90, true).Click();


        //        Thread.Sleep(5000);
        //        driverobj.GetElement(By.XPath("//a[contains(text(),'" + coursename + "')]"), 90, true).Click();



        //        Thread.Sleep(7000);
        //        driverobj.GetElement(ObjectRepository.driverobjenroll_btn, 90, true).Click();
        //        Thread.Sleep(7000);
        //        driverobj.GetElement(ObjectRepository.driverobjunenroll, 90, true);
        //        driverobj.GetElement(ObjectRepository.driverobjlaunchfirstattempt, 90, true).Click();
        //        Thread.Sleep(7000);

        //        driverobj.selectWindow("Google");
        //        Thread.Sleep(5000);
        //        driverobj.Close();
        //        Thread.Sleep(8000);

        //        string title = driverobj.Title;



        //        driverobj.GetElement(ObjectRepository.driverobjcertificateblock, 90, true).Click();
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