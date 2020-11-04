using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
// using TestAutomation.Data;
using System.Threading;
using Selenium2.Meridian;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    /// <summary>
    /// used as util class for announcement test class 
    /// </summary>
    class AnnouncementUtil
    {
        private readonly IWebDriver driverobj;
        public AnnouncementUtil(IWebDriver driver)
        {
            driverobj = driver;
        }
        /// <summary>
        /// click on MyResponsbilities Link
        /// </summary>
        public void linkmyresponsibilitiesclick()
        {
            try
            {
                driverobj.WaitForElement(myResponsibilities);
                driverobj.GetElement(myResponsibilities).ClickAnchor();
               
               


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on My Responsbilities Link",driverobj);
                



            }

        }
        /// <summary>
        /// Click on content management link
        /// </summary>
        public void linkannouncmentclick()
        {

            try
            {
                driverobj.WaitForElement(ContentManagmentlink);
                driverobj.GetElement(ContentManagmentlink).Click();
                driverobj.WaitForElement(goannouncementbtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                

            }

        }
        /// <summary>
        /// select Announcement from link and click Go button to create Announcement
        /// </summary>
        public void buttongoclick()
        {
            try
            {
                driverobj.FindSelectElementnew(announcementtype, "Announcement");
                driverobj.GetElement(goannouncementbtn).Click();
                driverobj.WaitForElement(announcementTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
              

            }

        }
        /// <summary>
        /// fill announcement detail in form
        /// </summary>
        /// <param name="i">current number of announcement</param>
        public void populatesummaryannouncement(int i, string browserstr)
        {

            try
            {
                driverobj.GetElement(announcementTitle).SendKeys(ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + i);
                //driverobj.GetElement(announcementContactInfo).SendKeys(ExtractDataExcel.MasterDic_announcement["Announcement"]);
                //driverobj.GetElement(announcementuniqueid).Clear();
                //driverobj.GetElement(announcementuniqueid).SendKeys(globalnum + i);
                if (!driverobj.existsElement(By.Id("MainContent_UC1_txtAnnouncement")))
                {
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.GetElement(By.CssSelector("body")).Click();
                    driverobj.GetElement(By.CssSelector("body")).SendKeys(ExtractDataExcel.MasterDic_announcement["Announcement"]);

                    driverobj.SwitchTo().DefaultContent();
                }
                else
                {
                    driverobj.GetElement(By.Id("MainContent_UC1_txtAnnouncement")).SendKeys(ExtractDataExcel.MasterDic_announcement["Announcement"]);
                }
                //driverobj.GetElement(By.Id("MainContent_UC1_txtAnnouncement")).SendKeys(ExtractDataExcel.MasterDic_announcement["Announcement"]);
                //Thread.Sleep(4000);
                //generalCourse.GetElement(ObjectRepository.generalcoursedescription).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                //driverobj.GetElement(announcementDesc).Click();
                //driverobj.GetElement(announcementDesc).SendKeys(ExtractDataExcel.MasterDic_announcement["Announcement"]);
                // driverobj.GetElement(ObjectRepository.generalcourseKeyword).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                

            }
        }
        /// <summary>
        /// click button to create announcement and checkin announcement
        /// </summary>
        public void buttoncreateclick()
        {

            try
            {

                driverobj.WaitForElement(announcementnext_btn);
                driverobj.GetElement(announcementnext_btn).Click();

                driverobj.WaitForElement(announcementCheckinNew);
                driverobj.GetElement(announcementCheckinNew).Click();
                driverobj.WaitForElement(myResponsibilities);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
               


            }

        }
        /// <summary>
        /// it calls all functions for creating announcement
        /// </summary>
        /// <param name="noofanno">total number of announcement to create</param>
        /// <returns></returns>
        public bool NewAnnouncement(int noofanno,string browserstr)
        {
            bool result = false;


            try
            {

                for (int i = 1; i <= noofanno; i++)
                {

                    linkmyresponsibilitiesclick();
                    linkannouncmentclick();
                    buttongoclick();
                    populatesummaryannouncement(i, browserstr);
                    buttoncreateclick();
                }
                result = true;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
              
                //Assert.Fail(ex.Message + "Unable to Create Announcements");
            }
            return result;
        }
        /// <summary>
        /// checks all created functions are shown on training home page
        /// </summary>
        /// <param name="noofanno">total number of announcement</param>
        /// <returns></returns>
        public bool ViewMultipleAnnouncement(int noofanno, string browserstr)
        {


            bool viewedanno = false;
            try
            {
                int j = 0;
                // ExtractDataExcel.announcementforregression();
                driverobj.GetElement(TrainingHome).Click();

                for (int i = noofanno; i > 0; i--)
                {
                   
                   driverobj.WaitForElement(By.XPath("//a[text()='"+ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + i+"']"));
                }

                viewedanno = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            return viewedanno;

        }
        /// <summary>
        /// click on More Announcement link on training home page to view all announment available
        /// </summary>
        /// <returns></returns>
        public bool MoreAnnouncement(string browserstr)
        {
            bool actualresult = false;
            try
            {
            //ExtractDataExcel.announcementforregression();
            driverobj.GetElement(TrainingHome).Click();
            driverobj.GetElement(moreannouncementlink).Click();
            Thread.Sleep(3000);
            driverobj.WaitForTitle("Announcements",new TimeSpan(0,0,15));

            driverobj.WaitForElement(By.Id("MainContent_UC1_txtSearch"));
            driverobj.GetElement(By.Id("MainContent_UC1_txtSearch")).SendKeys(ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + 1);
            driverobj.FindSelectElementnew(By.Id("MainContent_UC1_ddlSearchType"), "All words");
            driverobj.GetElement(By.Id("MainContent_UC1_btnSearch")).Click();
            driverobj.WaitForElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + 1 + "']"));
            actualresult = true;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                
            }

            return actualresult;
        }

        /// <summary>
        /// click on recent created announcement link to view its detail
        /// </summary>
        /// <returns></returns>
        public bool ShowAnnouncement(string browserstr)
        {
            bool result = false;
            try
            {
                driverobj.GetElement(TrainingHome).Click();
                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + 1 + "']")).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(By.XPath("//h2[contains(text(),'" + ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + 1 + "')]"));
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
               
            }
            return result;
        }

        /// <summary>
        /// click on recent created announcement link to view its detail and launch it
        /// </summary>
        /// <returns></returns>
        public string OpenAnnouncementItem(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {

                driverobj.GetElement(TrainingHome).Click();
                driverobj.GetElement(By.XPath("//a[text()='" + ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + 1 + "']")).Click();
                // Thread.Sleep(3000);
                driverobj.GetElement(announcementfirstlaunch).Click();
                Thread.Sleep(3000);
                driverobj.selectWindow(announcementwindow);
                actualresult = driverobj.Title;
                driverobj.GetElement(closebutton).Click();
                //  driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window("");
                // Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                
            }
            return actualresult;
        }
        #region delete announcement not required
        /// <summary>
        /// to delete announcements
        /// </summary>
        /// <param name="noofanno">total number of announcements</param>
        public void DeleteAnnouncement(int noofanno, string browserstr)
        {



            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.announcementlink).Click();
                for (int i = 1; i <= noofanno; i++)
                {
                    driverobj.WaitForElement(ObjectRepository.searchtext);
                    driverobj.GetElement(ObjectRepository.searchtext).Clear();
                    driverobj.GetElement(ObjectRepository.searchtext).SendKeys(ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + i);
                    driverobj.FindSelectElementnew(ObjectRepository.searchtype, ObjectRepository.filterdropdowntext);

                    driverobj.GetElement(ObjectRepository.searchbutton).Click();
                    driverobj.GetElement(By.LinkText(ExtractDataExcel.MasterDic_announcement["Title"]+browserstr + i)).Click();
                    driverobj.WaitForElement(ObjectRepository.deletecontent);
                    driverobj.GetElement(ObjectRepository.deletecontent).Click();
                    deletewindow();


                }
                /*annolable:*/
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            
                //Assert.Fail(ex.Message + "Unable to Delete Announcements");
            }

        }
        /// <summary>
        /// use to open delete window and click on delete button
        /// </summary>
        public void deletewindow()
        {
            try
            {
                driverobj.selectWindow("Delete Content");
                Thread.Sleep(3000);
                driverobj.GetElement(ObjectRepository.deletebutton).Click();
                Thread.Sleep(3000);

                driverobj.selectWindow("Announcements");
            }
            catch (Exception ex)
            {
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        #endregion

        private By myResponsibilities = By.Id("NavigationStrip1_lbMyResponsibilities");
        private By ContentManagmentlink =By.XPath("//a[contains(.,'Search & Create Content')]");
        private By announcement_Link = By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li[2]/a/span");
        private By goannouncementbtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
        private By announcementtype = By.Id("MainContent_ucSearchTop_ddlCreateNew");
        private By announcementTitle = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        private By announcementContactInfo = By.Id("MainContent_UC1_FormView1_CNTLCL_CONTACT_INFO");
        private By announcementDesc = By.XPath("//*[@id='ctl00_MainContent_UC1_rdEditor_contentIframe']");
        private By announcementnext_btn = By.Id("MainContent_UC1_Save");
        private By announcementCheckinNew = By.Id("MainContent_header_FormView1_btnStatus");
        private By TrainingHome = By.XPath("//a[contains(text(),'Training Home')]");
        private By announcementlink = By.LinkText("Announcements");
        private By announcementgobutton = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");

        private string announcementwindow = "Announcements";
        private By moreannouncementlink = By.Id("MainContent_ucAnnouncements_lnkMore");
        private By announcementfirstlink = By.Id("ctl00_MainContent_ucAnnouncements_rlvListing_ctrl0_lnkTitle");
        private By announcementfirstlaunch = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        public static string moreannouncementlinkscontrol = "ctl00_MainContent_ucAnnouncements_rlvListing_ctrl###_lnkTitle";
        private By moreannouncementlinks = By.Id(moreannouncementlinkscontrol);
        private By closebutton = By.Id("ML.BASE.CMD.CloseWindow");
        private By announcementuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");

        private string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
      

    }
}
