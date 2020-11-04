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

namespace TestAutomation.Meridian.Regression_Objects
{
    class MessageUtil
    {
        private readonly IWebDriver driverobj;

        public MessageUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

       // public string CourseTitle = ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "_request";
        public string CreateApproval(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.Approver();
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.adminconsoleapproverlink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.approvercreategobtn);
                driverobj.GetElement(ObjectRepository.approvercreategobtn).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.approvertitle);
                driverobj.GetElement(ObjectRepository.approvertitle).Clear();
                driverobj.GetElement(ObjectRepository.approvertitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_approver["Title"]+browserstr);
                driverobj.GetElement(ObjectRepository.approverdesc).Clear();
                driverobj.GetElement(ObjectRepository.approverdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_approver["Desc"]);
                driverobj.GetElement(ObjectRepository.createbutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.approvertype);
                driverobj.GetElement(ObjectRepository.approvertype).ClickWithSpace();
                Thread.Sleep(3000);
                //driverobj.WaitForElement(ObjectRepository.approvertypesetbtn);
                driverobj.GetElement(ObjectRepository.approvertypesetbtn).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(ObjectRepository.returnbutton);
                driverobj.GetElement(ObjectRepository.returnbutton).ClickWithSpace();
                Thread.Sleep(3000);

                actualresult = driverobj.Title;
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                //actualresult = driverobj.Title;
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }
        public void linkmyresponsibilitiesclick()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);
                driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
                driverobj.WaitForElement(ObjectRepository.searchHome);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);



            }

        }
        public void linkgeneralcourseclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.classroomCoursesLink);
                driverobj.ClickEleJs(ObjectRepository.classroomCoursesLink);
                driverobj.WaitForElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }

        }
        public void buttongoclick()
        {

            try
            {
                driverobj.select(ObjectRepository.selectcoursetype, "General Course");
                driverobj.GetElement(ObjectRepository.goCreateClassroombtn).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.classroomTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }

        }
        public void populatesummarygeneralCourse(int i, string browserstr)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "_request" + i);
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(ObjectRepository.generalcoursekeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
        }
        public void populateCourseFilesform()
        {

            try
            {
                // generalCourse.GetElement(ObjectRepository.generalcourseboostindex).SendKeys("2");
                driverobj.GetElement(ObjectRepository.generalcourseurlradio).Click();
                driverobj.GetElement(ObjectRepository.generalcourseurl_txtfld).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Url"]);

                //    generalCourse.GetElement(By.Id("TabMenu_ML_BASE_TAB_UploadFiles_COURSE_SAVE_FILE")).Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
        }
        public bool buttoncreateclick()
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.create_btn_new);
                driverobj.GetElement(ObjectRepository.create_btn_new).ClickWithSpace();

                driverobj.WaitForElement(ObjectRepository.CheckinNew);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;

            }
            return true;//throws information is saved
        }



        public void buttonaccessapprovaleditclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.contentaccessapprovaleditbutton);
                //driverobj.SelectFrame();
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovalradiobutton);
                driverobj.GetElement(ObjectRepository.manageaccessapprovalradiobutton).ClickWithSpace();
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }

        }
        public void populatemanageaccessapprovalframe(string searchapproval, string filtertext)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovalsearchtxtbox).SendKeysWithSpace(searchapproval);
                driverobj.FindSelectElementnew(ObjectRepository.manageaccessapprovalfiltercombobox, filtertext);
                driverobj.GetElement(ObjectRepository.manageaccessapprovalradiobutton).ClickWithSpace();
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }

        }
        public void buttonaccessapprovalsearchclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovalsearchbutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovaltableresultradiobutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }

        }
        public void radioaccessapprovalresultclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovaltableresultradiobutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovaltsavebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }

        }
        public string buttonaccessapprovalsaveclick()
        {
            string result = string.Empty;

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovaltsavebutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.contentaccessapprovalsuccessmessage);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public void buttoncheckinclick()
        {

            try
            {


                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);


            }

        }
        public string CreateGeneralCourseforApproval(int i, string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                TrainingHomes tr = new TrainingHomes(driverobj);
                tr.MyResponsiblities_click();
            //    linkmyresponsibilitiesclick();
                linkgeneralcourseclick();
                buttongoclick();
                populatesummarygeneralCourse(i, browserstr);
                populateCourseFilesform();
                buttoncreateclick();
                buttonaccessapprovaleditclick();
                populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"]+browserstr, "Any words");
                buttonaccessapprovalsearchclick();
                radioaccessapprovalresultclick();
                buttonaccessapprovalsaveclick();

                buttoncheckinclick();
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public string sendforapproval(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.GeneralCourse();

                driverobj.WaitForElement(By.Id("txtGlobalSearch"));
                driverobj.ClickEleJs(By.Id("txtGlobalSearch"));
                driverobj.WaitForElement(By.Id("txtGlobalSearch"));
                driverobj.GetElement(By.Id("txtGlobalSearch")).Clear();
              //  driverobj.FindSelectElementnew(ObjectRepository.trainingcatalogtextsearchtype, ObjectRepository.filterdropdowntext);
                driverobj.GetElement(By.Id("txtGlobalSearch")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "_request" + 1);
                driverobj.GetElement(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "_request" + 1 + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "_request" + 1 + "')]"));
                driverobj.WaitForElement(ObjectRepository.approverrequestaccessbtnflag);
                driverobj.GetElement(ObjectRepository.approverrequestaccessbtnflag).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                
                driverobj.WaitForElement(ObjectRepository.approverrequestaccessbtn);
                driverobj.GetElement(ObjectRepository.approverrequestaccessbtn).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.sucessmessage);
                actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool setprofiletorecivemsg()
        {
            bool actualresult = false;
            try
            {


                driverobj.WaitForElement(By.XPath(".//*[@id='preferences-block']/div[2]/div[2]/div[2]/div/div/div[2]/div/div/div/span[3]"));
                driverobj.GetElement(By.XPath(".//*[@id='preferences-block']/div[2]/div[2]/div[2]/div/div/div[2]/div/div/div/span[3]")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath(".//*[@id='preferences-block']/div[2]/div[2]/div[2]/div/div/div[2]/div/div/div/span[1]"));
                string foundoption = driverobj.GetElement(By.XPath(".//*[@id='preferences-block']/div[2]/div[2]/div[2]/div/div/div[2]/div/div/div/span[1]")).Text;
              if(foundoption=="Yes")
              {

                  actualresult = true;
              }
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool clickonmsgicon()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(msgicon);
                driverobj.GetElement(msgicon).ClickWithSpace();
                driverobj.WaitForElement(firstmsgchk);
                actualresult = true;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool openmsg()
        {
            bool actualresult = false;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                string msetitleinlist = driverobj.GetElement(firstmsgtitle).Text;
                driverobj.GetElement(firstmsgtitle).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchWindow("Message");
                string msgtitle = driverobj.GetElement(msgdetail).Text;
                driverobj.Close();
                Thread.Sleep(3000);

                driverobj.SwitchTo().Window(originalHandle);
                if (msetitleinlist == msgtitle)
                {
                    actualresult = true;
                }

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool markmsgasread()
        {

            bool actualresult = false;
            try
            {
                // driverobj.GetElement(firstmsgchk).Click();
                //driverobj.GetElement(deletebtn).Click();
                //driverobj.findandacceptalert();
                //Thread.Sleep(4000);

                driverobj.GetElement(firstmsgchk).ClickWithSpace();
                driverobj.GetElement(markreadbtn).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.WaitForElement(titleread);
                actualresult = true;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;


        }
        public bool markmsgasunread()
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(firstmsgchk).ClickWithSpace();
                driverobj.GetElement(markunreadbtn).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.WaitForElement(titleunread);
                actualresult = true;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;

        }
        public bool deletemsg()
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(firstmsgchk).ClickWithSpace();
                driverobj.GetElement(deletebtn).ClickWithSpace();
                driverobj.findandacceptalert();
                Thread.Sleep(4000);
                driverobj.WaitForElement(divsuccesmsg);
                actualresult = true;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;

        }


        private By userprefcommunicationmessage = By.Id("MainContent_UC1_FormView1_USR_COMMUNICATION_MESSAGES");

        private By frmsucessmessage = By.XPath("//div[@class='alert alert-success']");
        private By edituserpref = By.Id("MainContent_UCProfile_ucPreferences_lnkEdit");
        private By LinkMyAccount = By.XPath("//a[normalize-space()='Account']");
        private By msgicon = By.XPath("//img[@id='NavigationStrip1_qucMessages_imgQueueIcon']");
        private By firstmsgchk = By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect']");
        private By firstmsgtitle = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkSubject");
        private By msgdetail = By.XPath("//div[@id='content']/div/ul/li[5]");
        private By deletebtn = By.Id("MainContent_UC1_FormView1_Delete");
        private By markreadbtn = By.Id("MainContent_UC1_FormView1_MarkRead");
        private By titleread = By.XPath("//a[@class='message-read']");
        private By markunreadbtn = By.Id("MainContent_UC1_FormView1_MarkUnRead");
        private By titleunread = By.XPath("//a[@class='message-unread']");
        private By divsuccesmsg = By.XPath("//div[@class='alert alert-success']");
        //private By txt_classroomDesc = By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']");
        //private By txteditor_Description = By.XPath("//*[@id='ctl00_MainContent_UC1_FormView1_rdEditorDesc_contentIframe']");
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
    }
}
