using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium2.Meridian;
using System.Threading;
using NUnit.Framework;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class MyRequestUtil
    {

        private readonly IWebDriver driverobj;
        public MyRequestUtil(IWebDriver driver)
        {
            driverobj = driver;
        }
        //public string CourseTitle = ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "_request";
        public string CreateApproval(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.Approver();
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.adminconsoleapproverlink).Click();
                driverobj.WaitForElement(ObjectRepository.approvercreategobtn);
                driverobj.GetElement(ObjectRepository.approvercreategobtn).Click();
                driverobj.WaitForElement(ObjectRepository.approvertitle);
                driverobj.GetElement(ObjectRepository.approvertitle).Clear();
                driverobj.GetElement(ObjectRepository.approvertitle).SendKeys(ExtractDataExcel.MasterDic_approver["Title"]+browserstr);
                driverobj.GetElement(ObjectRepository.approverdesc).Clear();
                driverobj.GetElement(ObjectRepository.approverdesc).SendKeys(ExtractDataExcel.MasterDic_approver["Desc"]);
                driverobj.GetElement(ObjectRepository.createbutton).Click();
                driverobj.WaitForElement(ObjectRepository.approvertype);
                driverobj.GetElement(ObjectRepository.approvertype).Click();
                Thread.Sleep(3000);
                //driverobj.WaitForElement(ObjectRepository.approvertypesetbtn);
                driverobj.GetElement(ObjectRepository.approvertypesetbtn).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(ObjectRepository.returnbutton);
                driverobj.GetElement(ObjectRepository.returnbutton).Click();
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);


            }

        }
        public void linkgeneralcourseclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.content_management_Link);
                driverobj.GetElement(ObjectRepository.content_management_Link).Click();
                driverobj.WaitForElement(ObjectRepository.goCreategeneralcoursebtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }

        }
        public void buttongoclick()
        {
            try
            {
                driverobj.FindSelectElementnew(ObjectRepository.selectcoursetype, "General Course");
                driverobj.GetElement(ObjectRepository.goCreategeneralcoursebtn).Click();
                driverobj.WaitForElement(ObjectRepository.generalcourseTitle);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }

        }
        public void populatesummarygeneralCourse(int i,string browserstr)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.generalcourseTitle).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "_request" + i);
                if (!driverobj.existsElement(ObjectRepository.classroomDesc))
                {
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.GetElement(By.CssSelector("body")).Click();
                    driverobj.GetElement(By.CssSelector("body")).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);

                    driverobj.SwitchTo().DefaultContent();
                }
                else
                {
                    driverobj.GetElement(ObjectRepository.classroomDesc).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                }
                driverobj.GetElement(ObjectRepository.generalcourseKeyword).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }
        public void populateCourseFilesform()
        {

            try
            {
                // generalCourse.GetElement(ObjectRepository.generalcourseboostindex).SendKeys("2");
                driverobj.GetElement(ObjectRepository.generalcourseurlradio).Click();
                driverobj.GetElement(ObjectRepository.generalcourseurl_txtfld).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Url"]);


            }
            catch (Exception ex)
            {
                
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }
        public void buttoncreateclick()
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.generalcoursenext_btn);
                driverobj.GetElement(ObjectRepository.generalcoursenext_btn).Click();

                driverobj.WaitForElement(ObjectRepository.CheckinNew);


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }



        public void buttonaccessapprovaleditclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.contentaccessapprovaleditbutton).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovalradiobutton);
                driverobj.GetElement(ObjectRepository.manageaccessapprovalradiobutton).Click();
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void populatemanageaccessapprovalframe(string searchapproval, string filtertext)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovalsearchtxtbox).SendKeys(searchapproval);
                driverobj.FindSelectElementnew(ObjectRepository.manageaccessapprovalfiltercombobox, filtertext);
                driverobj.GetElement(ObjectRepository.manageaccessapprovalradiobutton).Click();
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttonaccessapprovalsearchclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovalsearchbutton).Click();
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovaltableresultradiobutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void radioaccessapprovalresultclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovaltableresultradiobutton).Click();
                driverobj.WaitForElement(ObjectRepository.manageaccessapprovaltsavebutton);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public string buttonaccessapprovalsaveclick()
        {
            string result = string.Empty;

            try
            {
                driverobj.GetElement(ObjectRepository.manageaccessapprovaltsavebutton).Click();
                driverobj.WaitForElement(ObjectRepository.contentaccessapprovalsuccessmessage);

                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                result = "";
            }
            return result = driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
        }
        public void buttoncheckinclick()
        {

            try
            {


                driverobj.GetElement(ObjectRepository.CheckinNew).Click();
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);


            }

        }
        public string CreateGeneralCourseforApproval(int i, string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                linkmyresponsibilitiesclick();
                linkgeneralcourseclick();
                buttongoclick();
                populatesummarygeneralCourse(i,browserstr);
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public string sendforapproval(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                //ExtractDataExcel.GeneralCourse();
                for (int i = 1; i <= 2; i++)
                {

                    driverobj.GetElement(ObjectRepository.trainingcatalog).Click();
                    driverobj.WaitForElement(ObjectRepository.trainingcatalogtextsearchfor);
                    driverobj.GetElement(ObjectRepository.trainingcatalogtextsearchfor).Clear();
                    driverobj.FindSelectElementnew(ObjectRepository.trainingcatalogtextsearchtype, ObjectRepository.filterdropdowntext);
                    driverobj.GetElement(ObjectRepository.trainingcatalogtextsearchfor).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + i);
                    driverobj.GetElement(ObjectRepository.trainingcatalogsearch).Click();
                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + i + "')]"));
                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + i + "')]")).ClickAnchor();
                    driverobj.WaitForElement(ObjectRepository.approverrequestaccessbtnflag);
                    driverobj.GetElement(ObjectRepository.approverrequestaccessbtnflag).Click();
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.WaitForElement(ObjectRepository.approverrequestaccessbtn);
                    driverobj.GetElement(ObjectRepository.approverrequestaccessbtn).Click();
                    driverobj.WaitForElement(ObjectRepository.sucessmessage);
                    actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;

                }
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public string Approveone()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
                driverobj.WaitForElement(ObjectRepository.MyResponsbilityApproverrequestlink);
                driverobj.GetElement(ObjectRepository.MyResponsbilityApproverrequestlink).Click();
                driverobj.WaitForElement(ObjectRepository.MyResponsbilityFirstApprovebtn);
                driverobj.GetElement(ObjectRepository.MyResponsbilityFirstApprovebtn).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.MyResponsbilityApprovebtn);
                driverobj.GetElement(ObjectRepository.MyResponsbilityApprovebtn).Click();
                driverobj.SwitchTo().Window("");

                actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool ViewallRequest(int noofcourse, string browserstr)
        {
            bool actualresult = false;
            try
            {
                //ExtractDataExcel.GeneralCourse();

                bool allrequestpersent = false;
                Thread.Sleep(2000);
                driverobj.OpenToolbarItems(ObjectRepository.MyAccountHoverLink);
                driverobj.WaitForElement(ObjectRepository.MyRequestPendingapprovercount);
                string noofpending = driverobj.GetElement(ObjectRepository.MyRequestPendingapprovercount).Text;
                noofpending = Regex.Replace(noofpending, "[^0-9]", "");
                driverobj.GetElement(ObjectRepository.MyRequestAllRequestLink).Click();

                for (int i = 1; i <= noofcourse; i++)
                {

                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + i + "')]"));


                }
                allrequestpersent = true;
                if (allrequestpersent == true && noofpending == "1")
                {
                    actualresult = true;
                }
                else
                {
                    actualresult = false;
                }
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;




        }

        public bool ViewallRequest()
        {
            bool actualresult = false;
            try
            {
                //ExtractDataExcel.GeneralCourse();


                Thread.Sleep(2000);
                driverobj.OpenToolbarItems(ObjectRepository.MyAccountHoverLink);
                driverobj.WaitForElement(ObjectRepository.MyRequestPendingapprovercount);
                string noofpending = driverobj.GetElement(ObjectRepository.MyRequestPendingapprovercount).Text;
                noofpending = Regex.Replace(noofpending, "[^0-9]", "");
                driverobj.GetElement(ObjectRepository.MyRequestAllRequestLink).Click();

                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));

                if (noofpending != string.Empty)
                {
                    actualresult = true;
                }
               
               // driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;




        }
        public bool showdetailpage(int noofcourse)
        {
            // ExtractDataExcel.GeneralCourse();
            bool actualresult = false;
            try
            {
                Thread.Sleep(2000);
                driverobj.OpenToolbarItems(ObjectRepository.MyAccountHoverLink);
                driverobj.WaitForElement(MyRequestAllRequestLink);

                driverobj.GetElement(MyRequestAllRequestLink).Click();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
               string elementtitle= driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails")).Text;
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails")).Click();
                //driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + noofcourse + "')]"));
                //driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + noofcourse + "')]")).Click();
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 60));
                driverobj.GetElement(By.XPath("//h2[contains(.,'"+elementtitle+"')]"));
                actualresult = true;
                //driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;

        }

        private By MyRequestPendingapprovercount = By.Id("MainContent_ucAddlLinksMyRequests_MLabel1");
        private By MyRequestAllRequestLink = By.Id("MainContent_ucAddlLinksMyRequests_lnkMyRequests");
    }
}
