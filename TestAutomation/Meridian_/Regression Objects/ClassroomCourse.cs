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
using relativepath;
using System.Collections.ObjectModel;
using System.Reflection;
namespace Selenium2.Meridian
{
    class ClassroomCourse
    {


        private readonly IWebDriver driverobj;

        public ClassroomCourse(IWebDriver driver)
        {
            driverobj = driver;
        }
        public List<string> NavigateMyResponsibilitiesTab(IWebDriver iSelenium)
        {

            List<string> result = new List<string>(4);

            try
            {
                //   driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
                driverobj.WaitForElement(ObjectRepository.searchHome);
                //     driverobj.GetElement(ObjectRepository.searchHome);
                IList<IWebElement> test = driverobj.FindElements(By.TagName("h2"));
                result.Add(test[0].Text);
                result.Add(test[1].Text);
                // result.Add(driverobj.GetElement(By.XPath("/html/body/form/div[6]/div/div[5]/div[2]/div/h2")).Text);
                result.Add(test[2].Text);
                result.Add(test[3].Text);
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Assert.Fail(ex.Message);
            }
            return result;
        }
        public void linkmyresponsibilities1click1(IWebDriver driver)
        {
            try
            {
                driverobj.WaitForElement(By.Id("lbMyResponsibilities"));
                driverobj.GetElement(By.Id("lbMyResponsibilities")).ClickAnchor();
                //     driverobj.WaitForElement(locator.myresponsibilitiesinstructorgobutton);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
            }

        }
        public void linkclassroomcourseclick1(string selection)
        {
            //if (tocreateclassroomcourse == false)
            //{
            //    return;
            //}

            try
            {

                driverobj.WaitForElement(ObjectRepository.classroomCoursesLink);
                driverobj.ClickEleJs(ObjectRepository.classroomCoursesLink);
                //  driverobj.GetElement(ObjectRepository.classroomCoursesLink).ClickWithSpaceWithSpace();
                driverobj.WaitForElement(ObjectRepository.goCreateClassroombtn);
                driverobj.select(By.Id("MainContent_ucSearchTop_ddlCreateNew"), selection);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void linkmyresponsibilitiesclick(IWebDriver driver)
        {
            try
            {

                driverobj.WaitForElement(By.XPath(".//*[@id='utility-nav']/ul[1]/li[2]/a"));
               
                driver.HoverLinkClick(By.XPath(".//*[@id='utility-nav']/ul[1]/li[2]/a"), By.XPath("//a[@href='/admin/myresponsibilities/training.aspx']"));
                //  driverobj.GetElement(ObjectRepository.myResponsibilities);
                if (driverobj.existsElement(By.XPath("//a[contains(.,'Content Items')]")))
                {
                    return;
                }
                else if (!driverobj.existsElement(ObjectRepository.searchHome))
                {
                    driver.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/admin/myresponsibilities/training.aspx']"));
                    driverobj.WaitForElement(ObjectRepository.searchHome);
                }
                else
                {
                    driver.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/admin/myresponsibilities/training.aspx']"));
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

        public void linkinstructortoolsclick(IWebDriver driver)
        {
            try
            {
                driverobj.ClickEleJs(ObjectRepository.managestudentsinstructortoolslink);
                driverobj.WaitForElement(ObjectRepository.managestudentsmyteachingscheduletab);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

        }
        public void tabmanagestudentsclick(IWebDriver driver)
        {
            try
            {
                driverobj.ClickEleJs(ObjectRepository.managestudentsmanagestudentstab);
                driverobj.WaitForElement(ObjectRepository.managestudentsallinstructorstab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }
        public string narrowsearchfacets(IWebDriver iSelenium)
        {
            try
            {



                driverobj.WaitForElement(By.Id("MainContent_ucSearchResults_lblItemCount"));
                if (driverobj.GetElement(By.Id("MainContent_ucSearchResults_lblItemCount")).Text == "0 Items")
                {
                    return "no records found";

                }
                else
                {
                    driverobj.WaitForElement(locator.myresponsibilitiesmycontenttitlelink);
                    if (driverobj.existsElement(By.Id("cbContent TypeClassroom")))
                    {
                        driverobj.ScrollToCoordinated("500", "500");
                        driverobj.WaitForElement(By.Id("cbContent TypeClassroom"));
                        driverobj.ClickEleJs(By.Id("cbContent TypeClassroom"));
                        Thread.Sleep(3000);
                    }
                    if (driverobj.existsElement(By.Id("cbContent TypeOnline")))
                    {
                        driverobj.ScrollToCoordinated("500", "500");
                        driverobj.ClickEleJs(By.XPath("//input[@id='cbContent TypeOnline']"));
                        Thread.Sleep(3000);
                    }
                    if (driverobj.existsElement(By.Id("cbContent TypeDocument")))
                    {
                        driverobj.ScrollToCoordinated("500", "500");
                        driverobj.ClickEleJs(By.XPath("//input[@id='cbContent TypeDocument']"));
                        Thread.Sleep(3000);
                    }

                    if (driverobj.existsElement(By.Id("cbContent TypeAnnouncement")))
                    {
                        driverobj.ScrollToCoordinated("500", "500");
                        driverobj.ClickEleJs(By.XPath("//input[@id='cbContent TypeAnnouncement']"));
                        Thread.Sleep(3000);
                    }
                    return driverobj.GetElement(By.Id("MainContent_ucSearchResults_lblItemCount")).Text;



                }




            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return "";
            }
        }
        public void taballinstructorsclick(IWebDriver driver)
        {
            try
            {
                driverobj.ClickEleJs(ObjectRepository.managestudentsallinstructorstab);
                driverobj.WaitForElement(ObjectRepository.managestudentsallinstructorssearchtextbox);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }
        public void tabnxt7daysclick(IWebDriver driver, By by)
        {
            try
            {
                driverobj.ClickEleJs(by);
                driverobj.WaitForElement(by);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }
        public void linkclassroomcourseclick()
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void buttonaddnewclassroomcourseclick()
        {


            try
            {
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesaddnew);
                driverobj.WaitForElement(ObjectRepository.classroomTitle);
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void linkcoursesectionclick()
        {


            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MHyperLink2"));
                driverobj.WaitForElement(By.Id("MainContent_lcClassroomCourseware"));
                // driverobj.GetElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void buttongoclick()
        {

            try
            {
                //driverobj.select(ObjectRepository.selectcoursetype, "Classroom Course");
                //driverobj.ClickEleJs(ObjectRepository.goCreateClassroombtn);
                //driverobj.WaitForElement(ObjectRepository.classroomTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populateClassroomform1(string title, string description, int i)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.classroomTitle);
                driverobj.ClickEleJs(ObjectRepository.classroomTitle);
                driverobj.GetElement(ObjectRepository.classroomTitle).SendKeysWithSpace(title + i);


                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);

                //Thread.Sleep(4000);
                //classroomcourse.GetElement(ObjectRepository.classroomDesc);
                //classroomcourse.GetElement(ObjectRepository.classroomDesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_classrommcourse["Desc"]);


                driverobj.GetElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeysWithSpace(description);
                driverobj.GetElement(ObjectRepository.courseinformationsearchprioritytextbox).SendKeysWithSpace("1");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);


            }

        }
        public void populateClassroomform(string title, string description)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.classroomTitle);
                driverobj.ClickEleJs(ObjectRepository.classroomTitle);
                driverobj.GetElement(ObjectRepository.classroomTitle).SendKeys(title);
                //  driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeysWithSpace(description);
                driverobj.GetElement(ObjectRepository.courseinformationsearchprioritytextbox).SendKeysWithSpace("1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public string buttonsaveclick()
        {

            string actualresult = string.Empty;
            try
            {
                //driverobj.ScrollToCoordinated("0", "250");
                driverobj.ClickEleJs(ObjectRepository.create_btn_new);
                driverobj.WaitForElement(ObjectRepository.sucessmessage);
                actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        public void SetPrerequisite()
        {
            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucPrerequistes_accPrerequisites_MHyperLink1"));
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_LnkAdd"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_LnkAdd"));
                Thread.Sleep(3000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(3000);
                driverobj.WaitForElement(By.Id("MainContent_UC1_btnSearch"));
                driverobj.ClickEleJs(By.Id("MainContent_UC1_btnSearch"));
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect"));
                driverobj.ClickEleJs(By.Id("ctl00_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect"));
                // waived_course = driverobj.GetElement(By.XPath("//tr[@id='ctl00_MainContent_UC1_rgPrerequisites_ctl00__0']/td[2]")).Text;
                driverobj.ClickEleJs(By.Id("MainContent_UC1_Add"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        //public string buttonsaveclick()
        //{
        //    if (tocreateclassroomcourse == false)
        //    {
        //        return "";
        //    }
        //    string actualresult = string.Empty;
        //    try
        //    {
        //        IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
        //        jse.ExecuteScript("window.scrollBy(500,500)", "");
        //        driverobj.GetElement(ObjectRepository.org_save_btn);
        //        driverobj.WaitForElement(ObjectRepository.sucessmessage);
        //        actualresult = driverobj.GetElement(ObjectRepository.sucessmessage).Text;

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //    }
        //    return actualresult;
        //}
        public void buttonsearchgoclick(string Title, string filtertext="")
        {

            try
            {
                //driverobj.WaitForElement(ObjectRepository.MyRespnsibilitySearch);
                //driverobj.GetElement(ObjectRepository.MyRespnsibilitySearch);
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(Title);
                // Thread.Sleep(2000);
                //     driverobj.FindSelectElementnew(ObjectRepository.MyRespnsibilitySearchFilter, filtertext);
                driverobj.ClickEleJs(By.XPath("//a[@id='btnSearch']"));

                driverobj.WaitForElement(By.XPath("//*[contains(.,'" + Title + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + Title + "')]"));
                driverobj.WaitForElement(By.Id("MainContent_header_FormView1_btnDelete"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populatesearchcontent(string Title, string filtertext)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.MyRespnsibilitySearch).SendKeysWithSpace(Title);
                driverobj.FindSelectElementnew(ObjectRepository.MyRespnsibilitySearchFilter, filtertext);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public int buttoncontentsearchgoclick()
        {

            try
            {

                driverobj.ClickEleJs(ObjectRepository.MyRespnsibilitySearchButton);
                driverobj.WaitForElement(ObjectRepository.ContentSearchResultTitle);
                return driverobj.countelements(ObjectRepository.contentsearchresultcount);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return 0;

            }

        }
        public int linktodayclick()
        {

            try
            {

                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiestodaylink);
                if (driverobj.existsElement(ObjectRepository.ContentSearchResultTitle))
                {
                    driverobj.WaitForElement(ObjectRepository.ContentSearchResultTitle);
                }
                int cnt = driverobj.countelements(ObjectRepository.contentsearchresultcount);
                return cnt;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return 0;

            }

        }
        public void buttonsearchresulttableclick()
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.ContentSearchResultTitle);
                driverobj.ClickEleJs(ObjectRepository.ContentSearchResultTitle);
                driverobj.WaitForElement(ObjectRepository.ManageSectionsLink);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void linkmanagesectionsclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.ManageSectionsLink);
                driverobj.WaitForElement(ObjectRepository.AddNewsectionBtn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }

        }
        public void buttonaddnewsectionclick()
        {
            try
            {
                driverobj.ClickEleJs(ObjectRepository.AddNewsectionBtn);
                driverobj.WaitForElement(ObjectRepository.SectionTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populatesectionform1(string browserstr)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.SectionTitle);
                driverobj.ClickEleJs(ObjectRepository.SectionTitle);
                Thread.Sleep(3000);
                driverobj.GetElement(ObjectRepository.SectionTitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr);
                Thread.Sleep(3000);
                driverobj.ClickEleJs(ObjectRepository.NxtBtn);
                Thread.Sleep(3000);
                //while (!driverobj.existsElement(By.Id("MainContent_UC1_FormView1_REQ_CRSSECT_TITLE")))
                //{
                //    driverobj.GetElement(ObjectRepository.SectionTitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr);
                //    Thread.Sleep(3000);
                //    driverobj.GetElement(ObjectRepository.NxtBtn);
                //    Thread.Sleep(3000);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populatesectionform12()
        {

            try
            {
                string format = "M/dd/yyyy";
                driverobj.WaitForElement(ObjectRepository.StartDate);
                string startdate = DateTime.Now.ToString(format);
                startdate = startdate.Replace("-", "/");
                string enddate = DateTime.Now.AddDays(2).ToString(format);
                enddate = enddate.Replace("-", "/");
                driverobj.ClickEleJs(ObjectRepository.EndDate);
                driverobj.GetElement(ObjectRepository.EndDate).SendKeysWithSpace(enddate);
                driverobj.ClickEleJs(ObjectRepository.StartDate);
                driverobj.GetElement(ObjectRepository.StartDate).SendKeysWithSpace(startdate);
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMaximumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMaximumCapacity).SendKeysWithSpace("1");
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMinimumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMinimumCapacity).SendKeysWithSpace("0");

                driverobj.WaitForElement(ObjectRepository.AllDayEvnt);

                driverobj.ClickEleJs(ObjectRepository.ChangeEnrolDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populatesectionform12_AdvanceDate()
        {

            try
            {
                string format = "MM/dd/yy";
                driverobj.WaitForElement(ObjectRepository.StartDate);
                driverobj.GetElement(ObjectRepository.EndDate).Click();
                driverobj.GetElement(ObjectRepository.EndDate).SendKeysWithSpace(DateTime.Now.AddDays(4).ToString(format));
                driverobj.GetElement(ObjectRepository.StartDate).Click();
                driverobj.GetElement(ObjectRepository.StartDate).SendKeysWithSpace(DateTime.Now.AddDays(1).ToString(format));
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMaximumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMaximumCapacity).SendKeysWithSpace("5");
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMinimumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMinimumCapacity).SendKeysWithSpace("0");

                driverobj.WaitForElement(ObjectRepository.AllDayEvnt);

                driverobj.ClickEleJs(ObjectRepository.ChangeEnrolDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }

        public void populatesectionformcustomizeCapacity(string Max, string Min)
        {

            try
            {
                string format = "MM/dd/yy";
                driverobj.WaitForElement(ObjectRepository.StartDate);
                driverobj.ClickEleJs(ObjectRepository.EndDate);
                driverobj.GetElement(ObjectRepository.EndDate).SendKeysWithSpace(DateTime.Now.AddDays(4).ToString(format));
                driverobj.ClickEleJs(ObjectRepository.StartDate);
                driverobj.GetElement(ObjectRepository.StartDate).SendKeysWithSpace(DateTime.Now.AddDays(1).ToString(format));
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMaximumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMaximumCapacity).SendKeysWithSpace(Max);
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMinimumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMinimumCapacity).SendKeysWithSpace(Min);

                driverobj.WaitForElement(ObjectRepository.AllDayEvnt);

                driverobj.ClickEleJs(ObjectRepository.ChangeEnrolDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }

        public void populatesectionformcustomize12(string startdate, string enddate)
        {

            try
            {
                string format = "MM/dd/yy";
                driverobj.WaitForElement(ObjectRepository.StartDate);
                driverobj.ClickEleJs(ObjectRepository.EndDate);
                driverobj.GetElement(ObjectRepository.EndDate).SendKeysWithSpace(enddate);
                driverobj.ClickEleJs(ObjectRepository.StartDate);
                driverobj.GetElement(ObjectRepository.StartDate).SendKeysWithSpace(startdate);
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMaximumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMaximumCapacity).SendKeysWithSpace("1");
                driverobj.ClickEleJs(ObjectRepository.classroomsectionMinimumCapacity);
                driverobj.GetElement(ObjectRepository.classroomsectionMinimumCapacity).SendKeysWithSpace("0");

                driverobj.WaitForElement(ObjectRepository.AllDayEvnt);
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.ClickEleJs(ObjectRepository.ChangeEnrolDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populateframeform()
        {

            try
            {
                string format = "M/dd/yyyy";
                //Thread.Sleep(5000);
                //driverobj.SwitchTo().Frame(driverobj.GetElement(By.XPath("/html/body/div[2]/div[2]/iframe")));
                //Thread.Sleep(5000);
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                //  driverobj.SelectFrame();
                string endenroldate = DateTime.Now.AddDays(2).ToString(format);
                endenroldate = endenroldate.Replace("-", "/");
                string startenroldate = DateTime.Now.ToString(format);
                startenroldate = startenroldate.Replace("-", "/");
                driverobj.WaitForElement(ObjectRepository.EnroStartDate);
                driverobj.WaitForElement(ObjectRepository.EnroStartDate);
                // driverobj.GetElement(ObjectRepository.EnrolEndDate).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
                driverobj.GetElement(ObjectRepository.EnrolEndDate).Click();
                driverobj.GetElement(ObjectRepository.EnrolEndDate).SendKeysWithSpace(endenroldate);
                //driverobj.GetElement(By.XPath("//a[contains(text(),'1')]"));
                driverobj.WaitForElement(ObjectRepository.EnroStartDate);
                driverobj.GetElement(ObjectRepository.EnroStartDate).Click();
                driverobj.GetElement(ObjectRepository.EnroStartDate).SendKeysWithSpace(startenroldate);
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput']"));
                driverobj.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput']")).SendKeysWithSpace("12:00 AM");
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput']"));
                driverobj.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput']")).SendKeysWithSpace("12:00 AM");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public void populateframeformCustomize(string startdate, string enddate)
        {

            try
            {
                string format = "MM/dd/yy";
                //Thread.Sleep(5000);
                //driverobj.SwitchTo().Frame(driverobj.GetElement(By.XPath("/html/body/div[2]/div[2]/iframe")));
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.EnroStartDate);
                driverobj.WaitForElement(ObjectRepository.EnroStartDate);
                // driverobj.GetElement(ObjectRepository.EnrolEndDate).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
                driverobj.ClickEleJs(ObjectRepository.EnrolEndDate);
                driverobj.GetElement(ObjectRepository.EnrolEndDate).SendKeysWithSpace(enddate);
                //driverobj.GetElement(By.XPath("//a[contains(text(),'1')]"));
                driverobj.WaitForElement(ObjectRepository.EnroStartDate);
                driverobj.ClickEleJs(ObjectRepository.EnroStartDate);
                driverobj.GetElement(ObjectRepository.EnroStartDate).SendKeysWithSpace(startdate);
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }

        public void editAccessApproval(string browserstr, string type)
        {

            try
            {
                switch (type)
                {
                    case "classroom":
                        {
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Edit Content')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Edit Content')]"));

                            driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                            driverobj.WaitForElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_rbApprovalRequired_0']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                            driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                            //    driverobj.WaitForElement(ObjectRepository.CheckinNew);
                            //    driverobj.ClickEleJs(ObjectRepository.CheckinNew);

                            break;
                        }
                    case "scorm":
                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("admin1", browserstr);
                            driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                            driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));

                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Edit Content')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Edit Content')]"));

                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Checkout')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Checkout')]"));

                            driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                            driverobj.WaitForElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_rbApprovalRequired_0']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                            driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Check-in')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("userforregression", browserstr);
                            break;
                        }
                }




            }


            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

        }
        public void buttonsaveframeclick()
        {

            try
            {
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
                Thread.Sleep(3000);
                driverobj.WaitForElement(By.XPath("//input[@value='ML.BASE.WAITLIST.Automatic']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='ML.BASE.WAITLIST.Automatic']"));
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSave']"));
                //driverobj.WaitForElementNotPresent(By.Id("MainContent_UC1_Save"));
                //Thread.Sleep(5000);
                //while (driverobj.existsElement("MainContent_UC1_Save"))
                //{
                //    Thread.Sleep(3000);
                //    driverobj.GetElement(By.Id("MainContent_UC1_Save"));
                //    Thread.Sleep(3000);
                //}
                //driverobj.GetElement(By.Id(Object.save_btn));
                //Thread.Sleep(5000);
                //driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(5000);
                driverobj.SwitchtoDefaultContent();
          //      driverobj.WaitForElement(ObjectRepository.SaveAndExit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }

        public void enableaccesskeypurchasetimeframe()
        {

            try
            {
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_rbPurchasingPeriod_0"));
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_rbPurchasingPeriod_1"));
                driverobj.WaitForElement(ObjectRepository.SaveAndExit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }

        public string buttonsaveandexitclick()
        {

            string actualresult = string.Empty;
            try
            {
                //  driverobj.SwitchTo().DefaultContent();
                driverobj.ClickEleJs(ObjectRepository.SaveAndExit);
                driverobj.WaitForElement(ObjectRepository.sectionsucessmessage);
                actualresult = driverobj.GetElement(ObjectRepository.sectionsucessmessage).Text;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        public string imagesectioninfoclick()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.ClickEleJs(ObjectRepository.detailssectioninfo);
                actualresult = driverobj.GetElement(ObjectRepository.detailseventschedulesectiontitle).Text;
                return actualresult;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return actualresult;
            }
        }
        public string buttonenrolclick()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.ClickEleJs(ObjectRepository.detailsenrolbutton);
                actualresult = driverobj.GetElement(ObjectRepository.sectionenrolsucessmessage).Text;
                return actualresult;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

                Console.WriteLine(ex.Message);
                return actualresult;

            }
        }
        public bool linkinstructortoolsclick()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.instructortools);
                driverobj.ClickEleJs(ObjectRepository.instructortools);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkmanageclick()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.manage);
                driverobj.ClickEleJs(ObjectRepository.manage);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkallinstructorsclick()
        {
            try
            {
                driverobj.GetElement(ObjectRepository.allinstructors);
                driverobj.ClickEleJs(ObjectRepository.allinstructors);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populatemanagestudentsform(string classroomtitle, string filter)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.managestudentsallinstructorssearchtextbox);
                driverobj.ClickEleJs(ObjectRepository.managestudentsallinstructorssearchtextbox);
                driverobj.GetElement(ObjectRepository.managestudentsallinstructorssearchtextbox).SendKeysWithSpace(classroomtitle);
                driverobj.FindSelectElementnew(ObjectRepository.managestudentinstructortoolssearchfilterdrpdown, filter);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string buttonsearchclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.managestudentsinstructortoolsearchbutton);
                driverobj.ClickEleJs(ObjectRepository.managestudentsinstructortoolsearchbutton);
                driverobj.WaitForElement(ObjectRepository.resulttabletext);
                return driverobj.GetElement(ObjectRepository.resulttabletext).Text;

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public string linksectiontitleclick()
        {
            string text = string.Empty;

            try
            {
                driverobj.WaitForElement(ObjectRepository.resulttabletext);
                driverobj.ClickEleJs(ObjectRepository.resulttabletext);
                driverobj.WaitForElement(ObjectRepository.managestudentsrosterenrolledtab);
                if ((driverobj.GetElement(ObjectRepository.managestudentsrosterenrolledtab).Text == "Enrolled (1)") && (driverobj.GetElement(ObjectRepository.managestudentsrosterwaitlistedtab).Text == "Waitlisted (0)"))
                {
                    text = "enrolled and waitlisted tabs found";
                }
                return text;

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "no tabs found";
            }

        }
        public string linkrecordattaendancescoresclick()
        {

            try
            {
                // driverobj.GetElement(ObjectRepository.resulttabletext);
                driverobj.ClickEleJs(ObjectRepository.recordattendanceandscores);
                driverobj.WaitForElement(ObjectRepository.resulttabletext1);
                return driverobj.GetElement(ObjectRepository.resulttabletext1).Text;

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return "";
            }

        }
        public bool populateatendancestatusscoresform(string statusfilter, string score)
        {
            try
            {
                driverobj.ClickEleJs(ObjectRepository.attendancechkbox); ;
                driverobj.FindSelectElementnew(ObjectRepository.statusdrpdown, statusfilter);
                driverobj.GetElement(ObjectRepository.scoretextbox).SendKeysWithSpace(score);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return false;
            }
            return true;
        }
        public string linkresulttableclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.resulttabletext);
                driverobj.WaitForElement(ObjectRepository.recordattendanceandscores);
                return driverobj.GetElement(ObjectRepository.resulttabletext1).Text;

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        //public bool populateatendancestatusscoresform(string statusfilter, string score)
        //{
        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.attendancechkbox);
        //        driverobj.FindSelectElementnew(ObjectRepository.statusdrpdown, statusfilter);
        //        driverobj.GetElement(ObjectRepository.scoretextbox).SendKeysWithSpace(score);

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}
        public void buttonattendanceclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.attendancebutton);
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                // return "";
            }

        }
        public string buttonstatusclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.statusfilterbutton);
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);
                return driverobj.GetElement(ObjectRepository.progressstatus).GetAttribute("value");

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public string buttonscoreclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.scorebutton);
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);
                return driverobj.GetElement(ObjectRepository.scoretext).GetAttribute("value");
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public string buttonsave1click()
        {

            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.ClickEleJs(ObjectRepository.savebutton);
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(10000);
                return driverobj.GetElement(ObjectRepository.sucessmessage).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public string buttondeletecontentclick()
        {
            try
            {
                driverobj.ClickEleJs(ObjectRepository.contentdeletecontentbutton);
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);
                return driverobj.GetElement(ObjectRepository.sucessmessage).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }

    

        public bool enrollInToCourses(string type, string browserstr, string classroom = "", string scorm = "", string curriculum = "")
        {
            bool actualresult = false;
            try
            {
                switch (type)
                {
                    case "Curriculum":

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
                            
                            #endregion

                            break;
                        }

                    case "ClassroomCourse":

                        {
                            #region Cancel Request Access By Learner
                            driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                            driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            Thread.Sleep(5000);
                            driverobj.GetElement(By.XPath("//input[@class='btn btn-primary pull-right']")).ClickWithSpace();
                            driverobj.SwitchTo().DefaultContent();
                            driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                            #endregion
                            break;
                        }

                    case "Scorm":
                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("userforregression", browserstr);

                            #region Enrollment in to scorm By Learner
                            driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                            driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(scorm);
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + scorm + "')]"));
                            driverobj.ClickEleJs(By.XPath("//input[@value='Enroll']"));
                            Thread.Sleep(5000);
                            if (driverobj.IsElementVisible(By.CssSelector("iframe[class='k-content-frame']")))
                            {
                                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                                Thread.Sleep(5000);
                                driverobj.ClickEleJs(By.XPath("//input[@value='Enroll']"));
                                Thread.Sleep(5000);
                                driverobj.SwitchTo().DefaultContent();

                            }
                            

                            driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));

                            #endregion
                            break;
                        }
                }

                actualresult = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return actualresult;
        }

        public bool enrollInClassroomCourse(string classroom)
        {
            bool actualresult = false;
            try
            {
                #region Enrollment in to classroom By Learner
                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(classroom);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + classroom + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + classroom + "')]"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + classroom + "')]"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Enroll']"));
                Thread.Sleep(5000);
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                actualresult = true;
                #endregion

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                //return "";
            }

            return actualresult;
        }

        public bool requestWaitlist(string classroom, string browserstr)
        {
            Document documentobj = new Document(driverobj);
            bool result = false;

            try
            {
                driverobj.ClickEleJs(By.XPath("//input[@value='Enroll']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("admin1", browserstr);
                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(classroom);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + classroom + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + classroom + "')]"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + classroom + "')]"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Waitlist']"));

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

        public bool cancelRequestWaitlist()
        {
            bool result = false;

            try
            {
                #region Cancel Request Waitlist By Learner
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Cancel Waitlist')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Waitlist')]"));
                driverobj.WaitForElement(By.XPath("//input[@value='Waitlist']"));
                #endregion
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

        //public bool cancelEnrollmentCourses(string type)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        switch (type)
        //        {
        //            case "Scorm":
        //                {
        //                    #region Cancel Enrollment from Scorm By Learner
        //                    driverobj.WaitForElement(By.XPath("//input[@value='Cancel Enrollment']"));
        //                    driverobj.ClickEleJs(By.XPath("//input[@value='Cancel Enrollment']"));
        //                    driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
        //                    actualresult = true;
        //                    #endregion
        //                    break;
        //                }

        //            case "Classroom":
        //                {
        //                    #region Cancel Enrollment from classroom By Learner
        //                    driverobj.WaitForElement(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
        //                    driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
        //                    driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
        //                    actualresult = true;
        //                    #endregion
        //                    break;
        //                }

        //            case "Curriculum":
        //                {
        //                    #region Cancel Enrollment from Curriculum By Learner
        //                    driverobj.WaitForElement(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
        //                    driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
        //                    driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
        //                    actualresult = true;
        //                    #endregion
        //                    break;
        //                }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return false;
        //}

        public bool cancelEnrollmentCourses(string type)
        {
            bool actualresult = false;
            try
            {
                switch (type)
                {
                    case "Scorm":
                        {
                            #region Cancel Enrollment from Scorm By Learner
                            driverobj.WaitForElement(By.XPath("//input[@value='Cancel Enrollment']"));
                            driverobj.ClickEleJs(By.XPath("//input[@value='Cancel Enrollment']"));
                            driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
                            actualresult = true;
                            #endregion
                            break;
                        }

                    case "Classroom":
                        {
                            #region Cancel Enrollment from classroom By Learner
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
                            driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
                            actualresult = true;
                            #endregion
                            break;
                        }

                    case "Curriculum":
                        {
                            #region Cancel Enrollment from Curriculum By Learner
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
                            driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
                            actualresult = true;
                            #endregion
                            break;
                        }
                }

                actualresult = true;
               
            }
            
            catch
            {

            }

            return actualresult;
        }

        public bool cancelenrollInClassroomCourse()
        {
            bool actualresult = false;
            try
            {
                #region Cancel Enrollment from classroom By Learner
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
                Thread.Sleep(4000);
                if (driverobj.IsElementVisible(By.TagName("iframe")))
                {
                    driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    Thread.Sleep(5000);
                    driverobj.GetElement(By.XPath("//textarea[@id='MainContent_UC1_tbUnenrollReason']")).SendKeysWithSpace("Testing Purpose");
                    driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                    Thread.Sleep(3000);
                    driverobj.SwitchTo().DefaultContent();
                }
                

                driverobj.WaitForElement(By.XPath("//input[@value='Enroll']"));
                actualresult = true;
                #endregion

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        //content search
        public bool populatecontentsearchsimple(string statusfilter, string texttosearch, string i)
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']"));
                Thread.Sleep(3000);
                driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(texttosearch + i);
                Thread.Sleep(3000);
            //    driverobj.FindSelectElementnew(ObjectRepository.contentsearchSearchfilterdrpdwn, statusfilter);
                //driverobj.GetElement(ObjectRepository.scoretextbox).SendKeysWithSpace(texttosearch);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttoncontentsearchclick()
        {

            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='btnSearch']"));
                 driverobj.ClickEleJs(By.XPath("//a[@id='btnSearch']"));
               // return driverobj.WaitForElement(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails"));
              
                return true;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                return false;
            }

        }
        public bool populatecontentsearchadvance(string statusfilter, string texttosearch1, string Desctext)
        {
            try
            {
                driverobj.GetElement(By.Id("MainContent_ucAdminSearch_txtSearchFor")).SendKeysWithSpace(texttosearch1);
              //  driverobj.ClickEleJs(By.Id("btnSearch"));
                //driverobj.WaitForElement(ObjectRepository.contentsearchSearchDescriptiontxtbx);
                //driverobj.GetElement(ObjectRepository.contentsearchSearchDescriptiontxtbx).SendKeysWithSpace(Desctext);
                //driverobj.select(By.Id("MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID"), statusfilter);
               // driverobj.FindSelectElementnew(ObjectRepository.contentsearchSearchfilterdrpdwn, statusfilter);
                //driverobj.GetElement(ObjectRepository.scoretextbox).SendKeysWithSpace(texttosearch);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        //section search
        public bool populatesectionsearch(string statusfilter, string texttosearch)
        {
            try
            {
              //  driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucTopBar_btnFilters"));
                driverobj.WaitForElement(ObjectRepository.schedulemanagesectionSearcfortxtbox);
                driverobj.GetElement(ObjectRepository.schedulemanagesectionSearcfortxtbox).SendKeysWithSpace(texttosearch);
               // driverobj.FindSelectElementnew(ObjectRepository.schedulemanagesectionSectionstatusdrpdwn, statusfilter);
                //driverobj.GetElement(ObjectRepository.scoretextbox).SendKeysWithSpace(texttosearch);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string buttonsectionsearchclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.schedulemanagesectionFilterbutton);
                    driverobj.WaitForElement(By.XPath("//tr[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0']/td[1]/a"));
              //  int cnt=driverobj.FindElements(By.XPath("//a[contains(.,'ClassC3012001700anybrowser')]")).Count;
                string text1 = driverobj.FindElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]")).Text;
              //  string text= driverobj.FindElement(By.XPath("/html/body/form/div[7]/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div[2]/ul[2]/li/div[1]/div[1]/div/div[1]/h3/a")).Text;
                //Thread.Sleep(5000);
                return text1;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }

        //calendar click
        public bool linkcalendarclick(string title)
        {
            bool res = false;
            try
            {
                driverobj.ClickEleJs(By.XPath(".//*[@id='hlClassroomCalendarView']/span"));
              //  driverobj.WaitForElement(ObjectRepository.schedulemanagesectionResulttable);
                driverobj.WaitForElement(By.CssSelector("a.cal-event-week.event-item"));
              //  driverobj.WaitForElement(By.Id("hlClassroomCalendarView"));
                driverobj.ClickEleJs(By.CssSelector("a.cal-event-week.event-item"));
                driverobj.WaitForElement(By.XPath("//*[contains(.,'12am "+title+"')]"));
                IList<IWebElement> options1 = driverobj.FindElements(By.XPath("//div[@class='cal-month-day cal-day-inmonth']"));
                
                foreach (IWebElement option1 in options1)
                {
                    string textme = option1.Text;
                  //  if(textme.EndsWith("\n "))
                //    {
                         res = driverobj.existsElement(By.XPath(".//*[@data-original-title='"+title+"']"));
                        break;
               //     }
                }
                driverobj.waitforframe(By.CssSelector("iframe[src*='SectionCalendar']"));
                driverobj.ClickEleJs(By.Id("MainContent_UC1_Cancel"));
                driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(2000);
               
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
               
            }

            return res;
        }

        //email send option
        public string buttonemailallclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.managestudentsrosteremailallbutton)  ;
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.sendemailmessagetextbox);
                return "true";
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string buttonemailinstructortoolsclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.managestudentsrosteremailallbutton)  ;
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.sendemailmessagetextbox);
                return "true";
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string populatemessageform(string subject, string message)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.sendemailsubjecttextbox).SendKeysWithSpace(subject);
                driverobj.GetElement(ObjectRepository.sendemailmessagetextbox).SendKeysWithSpace(message);
                return "true";

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string buttonsendmailclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.sendemailsendbutton)  ;
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(3000);
                return driverobj.GetElement(ObjectRepository.selectlocationssuccessmessage).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }


        //manage sections

        public string linksearchresulttableclick()
        {
            string text = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.schedulemanagesectionsectiontitlelink);
                driverobj.GetElement(ObjectRepository.schedulemanagesectionsectiontitlelink)  ;
                driverobj.WaitForElement(ObjectRepository.sectiondetailsEdit);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return text;

        }
        public bool buttonsectioneditclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.sectiondetailsEdit)  ;
                driverobj.WaitForElement(ObjectRepository.classroomsectionMinimumCapacity);
                //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttoncourseeditclick()
        {

            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucSummary_lnkEdit"))  ;
              
                driverobj.WaitForElement(ObjectRepository.classroomKeyword);
          
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string populateeditclassroomsummaryform(string keyword)
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.classroomKeyword);
                driverobj.GetElement(ObjectRepository.classroomKeyword).Clear();
                driverobj.GetElement(ObjectRepository.classroomKeyword).SendKeysWithSpace(keyword);
                //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);
                return "true";
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string buttonsaveeditclassroomsaveclick()
        {

            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"))  ;
                driverobj.WaitForElement(ObjectRepository.contentaccessapprovalsuccessmessage);
             
                return driverobj.GetElement(ObjectRepository.contentaccessapprovalsuccessmessage).Text;
                //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public bool prepopulatesectionform()
        {
            try
            {
                driverobj.GetElement(ObjectRepository.classroomsectionMinimumCapacity).SendKeysWithSpace("20");
                driverobj.GetElement(ObjectRepository.classroomsectionMaximumCapacity).SendKeysWithSpace("20");
                //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        ////edit manage approval
        //public bool linkcosteditclick()
        //{

        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.sectiondetailexpenseseditlink);
        //        driverobj.SelectFrame(ObjectRepository.expensesprofessionalservices);
        //        driverobj.WaitForElement(ObjectRepository.expensesprofessionalservices);
        //        //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
        //        //Thread.Sleep(5000);

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}
        //public bool populateexpensesform()
        //{
        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.expensesprofessionalservices).Clear();
        //        driverobj.GetElement(ObjectRepository.expensesprofessionalservices).SendKeysWithSpace("20");
        //        driverobj.GetElement(ObjectRepository.expensesfacilityservices).Clear();
        //        driverobj.GetElement(ObjectRepository.expensesfacilityservices).SendKeysWithSpace("20");
        //        //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
        //        //Thread.Sleep(5000);

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}
        //public string buttonframesaveandexit()
        //{
        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.expensessavebutton);
        //        driverobj.WaitForElement(ObjectRepository.sectiondetailexpensestotal);

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        Console.WriteLine(ex.Message);
        //        return "";
        //    }
        //    return driverobj.GetElement(ObjectRepository.sectionsucessmessage).Text;
        //}

        //edit cost
        public bool linkcosteditclick()
        {

            try
            {
                //IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                //jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucSectionExpenses_lbEdit"))  ;
              
                driverobj.WaitForElement(ObjectRepository.expensesprofessionalservices);
                //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populateexpensesform()
        {
            try
            {
                driverobj.GetElement(ObjectRepository.expensesprofessionalservices).Clear();
                driverobj.GetElement(ObjectRepository.expensesprofessionalservices).SendKeysWithSpace("20");
                driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_FACILITY_FEES")).Clear();
                driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_FACILITY_FEES")).SendKeysWithSpace("20");
                //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string buttonframesaveandexit()
        {
            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"))  ;
                driverobj.WaitForElement(By.XPath("//strong[contains(.,'$40.00')]"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            if (driverobj.existsElement(By.XPath("//strong[contains(.,'$40.00')]")))
            {
                return driverobj.GetElement(ObjectRepository.sectionsucessmessage).Text;
            }
            else
            {
                return "Cost did not return correct text";
            }
        }

        //edit cost for batch enroll
        //public bool linkcosteditclick()
        //{

        //    try
        //    {
        //        IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
        //        jse.ExecuteScript("window.scrollBy(500,500)", "");
        //        driverobj.GetElement(ObjectRepository.sectiondetailexpenseseditlink);
        //        driverobj.SelectFrame(ObjectRepository.expensesprofessionalservices);
        //        driverobj.WaitForElement(ObjectRepository.expensesprofessionalservices);
        //        //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
        //        //Thread.Sleep(5000);

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}
        //public bool populateexpensesform()
        //{
        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.expensesprofessionalservices).Clear();
        //        driverobj.GetElement(ObjectRepository.expensesprofessionalservices).SendKeysWithSpace("20");
        //        driverobj.GetElement(ObjectRepository.expensesfacilityservices).Clear();
        //        driverobj.GetElement(ObjectRepository.expensesfacilityservices).SendKeysWithSpace("20");
        //        //driverobj.GetElement(ObjectRepository.schedulemanagesectionResulttable).Text;
        //        //Thread.Sleep(5000);

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}
        //public string buttonframesaveandexit()
        //{
        //    try
        //    {
        //        driverobj.GetElement(ObjectRepository.expensessavebutton);
        //        driverobj.WaitForElement(ObjectRepository.sectiondetailexpensestotal);

        //    }
        //    catch (Exception ex)
        //    {
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        Console.WriteLine(ex.Message);
        //        return "";
        //    }
        //    return driverobj.GetElement(ObjectRepository.sectionsucessmessage).Text;
        //}

        //assign surveys
        public bool linkcoursemanagesurveyclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.managestudentsmanagesurveylink);
                driverobj.GetElement(ObjectRepository.managestudentsmanagesurveylink)  ;
                driverobj.WaitForElement(ObjectRepository.surveysassignsurveyslink);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkmanagesurveyclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.sectiondetailsmanagelink);
                driverobj.ClickEleJs(ObjectRepository.sectiondetailsmanagelink)  ;
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnAssignSurveys"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkcontentmanagesurveyclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.contentmanagelink);
                driverobj.ClickEleJs(ObjectRepository.contentmanagelink)  ;
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnAssignSurveys"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkassignsurveyclick()
        {

            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnAssignSurveys"))  ;
               // driverobj.SelectFrame();
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_txtSearchFor"));
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttonsearchsurveyclick()
        {

            try
            {
                // driverobj.SelectFrame(ObjectRepository.surveyframesearchbutton);
                if (driverobj.Checkout())
                {
                    driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
                    driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"))  ;
                    driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
            
                }
                else
                {
                    driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
                    driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
                    driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
                }
            }
            catch (Exception ex)
            {
          //   ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            //    driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              //  Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool selectcheckbox()
        {

            try
            {
                driverobj.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"))  ;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_Save"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"))  ;//ObjectRepository.surveyframesavebutton);
                //    driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnRemove"));//ObjectRepository.surveyremovebutton);
                result = driverobj.GetElement(By.Id("MainContent_MainContent_UC1_btnRemove")).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }


        //copy section
        public bool buttoncopyclassroomsectionclick()
        {

            try
            {
                driverobj.WaitForElement(By.Id("MainContent_MainContent_ucSummary_FormView1_lnkCopy"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucSummary_FormView1_lnkCopy"))  ;
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.copyframedatetxtbox);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populatecopyframe()
        {

            try
            {
                string format = "MM/d/yyyy";
                driverobj.GetElement(ObjectRepository.copyframetimetxtbox).SendKeysWithSpace("12.00 AM");
                driverobj.GetElement(ObjectRepository.copyframedatetxtbox).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
                driverobj.ClickEleJs(By.XPath("//div[@class='col-xs-12']"));
                
}
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string copybuttonclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.copyframecopybutton);
               
                Thread.Sleep(3000);
                driverobj.ClickEleJs(ObjectRepository.copyframecopybutton)  ;
                for (int i = 0; i < 2; i++)
                {
                    if (driverobj.existsElement(By.XPath("//span[contains(.,' This field is required.')]")))
                    {
                        Thread.Sleep(3000);
                        driverobj.GetElement(By.XPath("//span[contains(.,' This field is required.')]")).Click();
                        Thread.Sleep(3000);
                        driverobj.ClickEleJs(ObjectRepository.copyframecopybutton);
                    }
                    else
                    {
                        break;
                    }
                }
                // driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(5000);
                driverobj.SwitchtoDefaultContent();
                driverobj.WaitForElement(ObjectRepository.sectiondetailssuccessmessage);
                result = driverobj.GetElement(ObjectRepository.sectiondetailssuccessmessage).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        //delete section
        public string buttondeletesectionclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.sectiondetaildeletesectionbutton);
                driverobj.ClickEleJs(ObjectRepository.sectiondetaildeletesectionbutton)  ;
                Thread.Sleep(3000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                driverobj.WaitForElement(ObjectRepository.sectiondetailssuccessmessage);
                result = driverobj.GetElement(ObjectRepository.sectiondetailssuccessmessage).Text;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        //edit event
        public bool buttonediteventclick()
        {

            try
            {
                driverobj.WaitForElement(By.Id("MainContent_MainContent_ucSectionEvents_lbEdit"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucSectionEvents_lbEdit"))  ;
                driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEvents_ctl00_ctl04_btnGo"));


            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkediteventclick()
        {

            try
            {
                //IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                //jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEvents_ctl00_ctl04_btnGo"))  ;
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_EVT_ALLDAYEVENT"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populateediteventform()
        {

            try
            {
                string format = "MM/dd/yy";
                // driverobj.GetElement(ObjectRepository.editeventstrttimetxtbox).Clear();
                driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_EVT_START_TIME_dateInput")).Clear();
                driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_EVT_START_TIME_dateInput")).SendKeysWithSpace("1.00 AM");
                // driverobj.GetElement(ObjectRepository.editeventendtimetxtbox).Clear();
                  driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_EVT_END_TIME_dateInput")).Clear();
                driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_EVT_END_TIME_dateInput")).SendKeysWithSpace("12.00 AM");
                //  driverobj.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_DATE_dateInput")).Clear();
                // driverobj.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_DATE_dateInput")).SendKeysWithSpace(DateTime.Now.AddDays(3).ToString(format));
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string buttoneventsaveandexitclick()
        {
            string result = string.Empty;
            try
            {


                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnSave"))  ;
                driverobj.WaitForElement(ObjectRepository.eventssuccessmessage);
                result = driverobj.GetElement(ObjectRepository.eventssuccessmessage).Text;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        //select location
        public bool buttonselectlocationclick()
        {

            try
            {

                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectLoc"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectLoc"))  ;
              //  driverobj.SelectFrame();
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnSearch"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool buttonselectlocationsearchclick()
        {

            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"))  ;
                driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool buttonselectlocationradaiobuttonclick()
        {

            try
            {

                driverobj.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect"))  ;
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_Save"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public string buttonlocationsaveandexitclick()
        {
            string result = string.Empty;
            try
            {

                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"))  ;
               // driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(ObjectRepository.selectlocationssuccessmessage);
                result = driverobj.GetElement(ObjectRepository.selectlocationssuccessmessage).Text;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        //select instructors
        public bool buttonselectinstructorclick()
        {

            try
            {

                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectInst"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectInst"))  ;

                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
             

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool populateselectinstructorform(string firstname, string lastname)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.lname_text).SendKeysWithSpace(lastname);
                driverobj.GetElement(ObjectRepository.fname_text).SendKeysWithSpace(firstname);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool buttonselectinstructorsearchclick()
        {

            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"))  ;
                driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_SectionInstructorSearch_ctl00_ctl04_chkSelect"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool buttonselectinstructorcheckboxclick()
        {

            try
            {

                driverobj.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_SectionInstructorSearch_ctl00_ctl04_chkSelect"));
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_Save"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public string buttoninstructorsaveandexitclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"));

                driverobj.WaitForElement(ObjectRepository.selectinstructorssuccessmessage);
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectInst"))  ;
                driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSelectedInstructor_ctrl0_lnkDelete"));
                driverobj.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSelectedInstructor_ctrl0_lnkDelete"));
                driverobj.findandacceptalert();
                if (!driverobj.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSelectedInstructor_ctrl0_lnkDelete")))
                {
                    return "The selected instructors were removed.";
                }
                else
                {
                    return "There is some error in locating the instructor";
                }
            
             

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
        
        }
        public string buttonwaitlistclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.createnewcoursesectionandeventradiobutton);
                driverobj.ClickEleJs(ObjectRepository.createnewcoursesectionandeventradiobutton);
                result = "true";
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        //manage enrollment for 14.1
        public bool buttonmanageenrollmentclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.scheduleandmanagesectionsmanageenrollmentbutton);
                driverobj.ClickEleJs(ObjectRepository.scheduleandmanagesectionsmanageenrollmentbutton);
                driverobj.WaitForElement(ObjectRepository.manageenrollmentenrolusersbutton);
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttonenrollusersclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.manageenrollmentenrolusersbutton);
                driverobj.ClickEleJs(ObjectRepository.manageenrollmentenrolusersbutton);
                driverobj.WaitForElement(ObjectRepository.batchenrollmentbatchenrollusersbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttonmanagewaitlistclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.manageenrollmentmanagewaitlistbutton);
                driverobj.ClickEleJs(ObjectRepository.manageenrollmentmanagewaitlistbutton);
                driverobj.WaitForElement(ObjectRepository.waitlistuserswaitlistusersbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttonmanageenrolclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.manageenrollmentmanageenrollmentbutton);
                driverobj.ClickEleJs(ObjectRepository.manageenrollmentmanageenrollmentbutton);
                driverobj.WaitForElement(ObjectRepository.cancelenrolmentorwaitlistcancelenrolmentorwaitlistbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool usercancelenrolselectcheckboxclick()
        {

            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.ClickEleJs(ObjectRepository.cancelenrolmentselectenrolledcheckbox);
                driverobj.WaitForElement(ObjectRepository.cancelenrolmentorwaitlistreasontextbox);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool usercancelwaitlistselectcheckboxclick()
        {

            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.ClickEleJs(ObjectRepository.cancelenrolmentselectenrolledcheckbox);
                driverobj.WaitForElement(ObjectRepository.cancelenrolmentorwaitlistreasontextbox);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populatecancelenrolmentorwaitlistreasontextbox(string reason)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.cancelenrolmentorwaitlistreasontextbox);
                driverobj.ClickEleJs(ObjectRepository.cancelenrolmentorwaitlistreasontextbox);
                driverobj.GetElement(ObjectRepository.cancelenrolmentorwaitlistreasontextbox).SendKeysWithSpace(reason);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populatebatchenrollusersform(string firstname, string lastname)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.batchenrollmentlastnametxtbox);
                driverobj.GetElement(ObjectRepository.batchenrollmentlastnametxtbox).SendKeysWithSpace(lastname);
                driverobj.ClickEleJs(ObjectRepository.batchenrollmentfirstnametxtbox);
                Thread.Sleep(2000);
                driverobj.GetElement(ObjectRepository.batchenrollmentfirstnametxtbox).SendKeysWithSpace(firstname);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttonbatchenrolluserssearchclick()
        {

            try
            {
                driverobj.ClickEleJs(ObjectRepository.batchenrollmentsearchbutton);
                driverobj.WaitForElement(ObjectRepository.batchenrollmenttablelastnamelabel);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool buttonuserselectcheckboxclick()
        {

            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.ClickEleJs(ObjectRepository.batchenrollmentselectcheckbox);
                driverobj.WaitForElement(ObjectRepository.batchenrollmentbatchenrollusersbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttonuserselectwaitlistcheckboxclick()
        {

            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(500,500)", "");
                driverobj.WaitForElement(ObjectRepository.waitlistselectcheckbox);
                driverobj.ClickEleJs(ObjectRepository.waitlistselectcheckbox);
                driverobj.WaitForElement(ObjectRepository.waitlistuserswaitlistusersbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string buttonbatchenrollusersclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.batchenrollmentbatchenrollusersbutton);
                driverobj.ClickEleJs(ObjectRepository.batchenrollmentbatchenrollusersbutton);
                driverobj.WaitForElement(ObjectRepository.batchenrollmentfeedback);
                result = driverobj.GetElement(ObjectRepository.batchenrollmentfeedback).Text;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "Users were not enrolled due to " + ex.Message;
            }
            return result;
        }
        public string buttonwaitlistusersclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.waitlistuserswaitlistusersbutton);
                driverobj.ClickEleJs(ObjectRepository.waitlistuserswaitlistusersbutton);
                driverobj.WaitForElement(ObjectRepository.batchenrollmentfeedback);
                result = driverobj.GetElement(ObjectRepository.batchenrollmentfeedback).Text;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "Users were not enrolled due to " + ex.Message;
            }
            return result;
        }
        public string buttoncancelenrolmentorwaitlistclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.cancelenrolmentorwaitlistcancelenrolmentorwaitlistbutton);
                driverobj.ClickEleJs(ObjectRepository.cancelenrolmentorwaitlistcancelenrolmentorwaitlistbutton);
                Thread.Sleep(3000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                driverobj.WaitForElement(ObjectRepository.batchenrollmentfeedback);
                result = driverobj.GetElement(ObjectRepository.batchenrollmentfeedback).Text;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "Users were not enrolled due to " + ex.Message;
            }
            return result;
        }
        //delete event
        public bool checkboxdeleteeventclick()
        {

            try
            {
                driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEvents_ctl00_ctl04_chkSelect"));
                driverobj.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEvents_ctl00_ctl04_chkSelect"));

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string buttonremoveeventclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_UC1_FormViewButton_btnGo"));
                driverobj.SwitchTo().Alert().Accept();
                driverobj.WaitForElement(ObjectRepository.deleteeventsuccessmessage);
                result = driverobj.GetElement(ObjectRepository.deleteeventsuccessmessage).Text;

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        //Select an Instructor filter (Me, All Instructors)
        public string drpdownfilterinstructortoolsportletselect(string text)
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesinstructortoolsportletdrpdwn);
                driverobj.FindSelectElementnew(ObjectRepository.myresponsibilitiesinstructortoolsportletdrpdwn, text);
                return "true";
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "false";
            }
        }
        public string buttongoinstructortoolportletclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesinstructortoolsportletbutton);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesinstructortoolsportletbutton);
                return "true";
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "false";
            }
        }
        public string linkinstructortoolportletclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesinstructortoolsportlettableresult);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesinstructortoolsportlettableresult);
                driverobj.WaitForElement(ObjectRepository.managestudentslink);
                return "true";
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "false";
            }
        }
        public string buttonallmysectionsclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesinstructortoolportletallmysectionbutton);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesinstructortoolportletallmysectionbutton);
                driverobj.WaitForElement(ObjectRepository.managestudentsallinstructorstab);
                return driverobj.GetElement(ObjectRepository.managestudentsallinstructorstab).Text;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "false";
            }
        }
        public string buttonviewallcoursesclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_ucLastModifiedContent_lbAllContent']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_ucLastModifiedContent_lbAllContent']"));
                driverobj.WaitForElement(ObjectRepository.contentsearchItemscountlbl);
                return driverobj.GetElement(ObjectRepository.contentsearchItemscountlbl).Text;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "false";
            }
        }
        public List<string> RecordsFromTable(IWebDriver iSelenium)
        {
            List<string> result = new List<string>();

            try
            {

                //driverobj.GetElement(ObjectRepository.myResponsibilities);
                //driverobj.GetElement(By.Id("MainContent_ucLastModifiedContent_MLinkButton1"));
                //driverobj.GetElement(By.Id("MainContent_ucLastModifiedContent_MLinkButton1"));
                driverobj.WaitForElement(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails"));
                result.Add(driverobj.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails")).Text);
                result.Add(driverobj.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl1_lnkDetails")).Text);
                result.Add(driverobj.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl2_lnkDetails")).Text);
                result.Add(driverobj.GetElement(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl3_lnkDetails")).Text);
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.TakeScreenShot();
                Assert.Fail(ex.Message);
            }
            return result;
        }
        public void selectcategory()
        {
            try
            {
                driverobj.WaitForElement(By.Id("MainContent_MainContent_ucCategories_lnkEdit"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucCategories_lnkEdit"))  ;
                Thread.Sleep(3000);
                driverobj.WaitForElement(By.XPath("//span[contains(.,'" + "cat" + ExtractDataExcel.token_for_reg + "')]"));

                driverobj.ClickEleJs(By.XPath("//span[contains(text(),'" + "cat" + ExtractDataExcel.token_for_reg + "')]/preceding-sibling::input[@class='rtChk']"));
                
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucCategories_btnSave"));
               // driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(locator.sucessmessage);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }
        }
        public string ClassroomCourseTitleHomePage(IWebDriver iSelenium, string browserstr)
        {
            string result = string.Empty;

            try
            {
                driverobj.GetElement(ObjectRepository.myResponsibilities);
                driverobj.ClickEleJs(By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li/a/span"))  ;
                string text = ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr;
                driverobj.ClickEleJs(By.Id("ctl00_MainContent_ucLastModifiedContent_RadGrid1_ctl00_ctl04_lnkDetails"));
                driverobj.GetElement(By.Id("MainContent_header_FormView1_btnDelete"));
                result = driverobj.GetElement(By.CssSelector("h1")).Text;
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Assert.Fail(ex.Message);
            }
            return result;
        }
        public string InstructorToolsPortlet(IWebDriver iSelenium)
        {
            string result = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
                driverobj.GetElement(ObjectRepository.searchHome);
                driverobj.ClickEleJs(By.Id("ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00_ctl04_lnkDetails"));
                result = driverobj.GetElement(By.CssSelector("h1")).Text;
            }

            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Assert.Fail(ex.Message);
            }
            return result;
        }
        public string linkcontenttitleclick(string v)
        {
            string result = string.Empty;
            try
            {
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesmycontenttitlelink);
                Thread.Sleep(3000);

                driverobj.WaitForElement(By.XPath("//span[@class='fa fa-info-circle text-info']"));
                result = driverobj.Title;
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        //delete classroom course
        public string deleteclassroomcourse(IWebDriver iSelenium)
        {
            try
            {


                while (true)
                {
                    linkmyresponsibilitiesclick(driverobj);
                    linkclassroomcourseclick();
                    driverobj.WaitForElement(By.Id("CreatedBy"));
                    driverobj.ClickEleJs(By.Id("CreatedBy"))  ;
                    // linktodayclick();
                    //  driverobj.WaitForElement(By.Id("MainContent_ucSearchResults_lblItemCount"));
                    //14.3c MainContent_ucSearchResults_lblItemCount
                    driverobj.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div/h3"));
                    if (driverobj.GetElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div/h3")).Text == "0 Items")
                    {
                        return "test complete";
                        break;
                    }
                    else
                    {
                        driverobj.WaitForElement(locator.myresponsibilitiesmycontenttitlelink);
                        if (driverobj.existsElement(By.Id("cbContent TypeClassroom")))
                        {
                            driverobj.ScrollToCoordinated("500", "500");
                            driverobj.WaitForElement(By.Id("cbContent TypeClassroom"));
                            driverobj.ClickEleJs(By.Id("cbContent TypeClassroom"));
                            Thread.Sleep(3000);
                        }
                        //if (driverobj.existsElement("cbContent TypeOnline"))
                        //{
                        //    driverobj.ScrollToCoordinated("500", "500");
                        //    driverobj.GetElement(By.XPath("//input[@id='cbContent TypeOnline']"));
                        //    Thread.Sleep(3000);
                        //}
                        //if (driverobj.existsElement(By.Id("cbContent TypeDocument")))
                        //{
                        //    driverobj.ScrollToCoordinated("500", "500");
                        //    driverobj.GetElement(By.XPath("//input[@id='cbContent TypeDocument']"));
                        //    // Thread.Sleep(3000);
                        //}

                        //if (driverobj.existsElement(By.Id("cbContent TypeAnnouncement")))
                        //{
                        //    driverobj.ScrollToCoordinated("500", "500");
                        //    driverobj.GetElement(By.XPath("//input[@id='cbContent TypeAnnouncement']"));
                        //    //  Thread.Sleep(3000);
                        //}

                        {



                            driverobj.WaitForElement(locator.myresponsibilitiesmycontenttitlelink);

                        }
                        int i = 0;
                        driverobj.ScrollToCoordinated("500", "500");
                        driverobj.ClickEleJs(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl" + i + "_lnkDetails"));
                        Thread.Sleep(3000);
                        //if (driverobj.Title.Contains("Object reference not set to an instance of an object"))
                        //{
                        //    driverobj.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
                        //    driverobj.UserLogin("admin");

                        //    i = i + 1;
                        //    linkmyresponsibilitiesclick(classroomcourse);
                        //    Thread.Sleep(3000);
                        //    linktodayclick();

                        //    driverobj.WaitForElement(By.Id("MainContent_ucSearchResults_lblItemCount"));
                        //    if (driverobj.GetElement(By.Id("MainContent_ucSearchResults_lblItemCount")).Text == "0 Items")
                        //    {
                        //        return "test complete";

                        //    }
                        //    // return "true";
                        //}
                        //else
                        //{
                        driverobj.WaitForElement(locator.contentdeletecontentbutton);
                        driverobj.ClickEleJs(locator.contentdeletecontentbutton);
                        Thread.Sleep(2000);
                        driverobj.SwitchTo().Alert().Accept();
                        Thread.Sleep(2000);
                        driverobj.WaitForElement(locator.batchenrollmentfeedback);
                        //  }
                    }



                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return "";
            }
            return "true";
        }
        public void deletecontent()
        {
            try
            {
                driverobj.WaitForElement(locator.contentdeletecontentbutton);
                driverobj.ClickEleJs(locator.contentdeletecontentbutton);
                Thread.Sleep(2000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(2000);
                driverobj.WaitForElement(locator.batchenrollmentfeedback);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
              
            }
        }
        //most recent requests
        public string linkmostrecentrequestsusernamelinkclick()
        {
            string result = string.Empty;
            try
            {
          
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestusernamelink);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesmostrecentrequestusernamelink)  ;
                driverobj.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
              //  driverobj.SelectFrame();
                driverobj.WaitForElement(ObjectRepository.informationcitylabel);
                result = driverobj.GetElement(ObjectRepository.informationcitylabel).Text;
                
                driverobj.SwitchTo().DefaultContent();

                Thread.Sleep(2000);
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Close')]"));
               // driverobj.WaitForElement(By.XPath("//*[@id='PageBody']/body/div[3]/div[1]/div/a"));
             //   driverobj.GetElement(By.XPath("//*[@id='PageBody']/body/div[3]/div[1]/div/a"));//By.CssSelector("span.k-icon.k-i-close") made changes for chrome
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestusernamelink);
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        public string linkmostrecentrequestscontenttitlelinkclick(string v)
        {
            string result = string.Empty;
            try
            {
          
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestcontenttitlelink);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesmostrecentrequestcontenttitlelink);
                Thread.Sleep(5000);
                //if (driverobj.Title == "My Responsibilities")
                //{
                //    driverobj.SelectFrame(By.Id("lblCreatedUserLabel"));
                //    driverobj.WaitForElement(By.Id("lblCreatedUserLabel"));
                //    result = driverobj.GetElement(By.Id("lblCreatedUserLabel")).Text;
                //    driverobj.SwitchTo().DefaultContent();
                //    driverobj.GetElement(By.XPath("//div[2]/div/div/a/span"));

                //    driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestusernamelink);
                //}
                //else
                //{
                driverobj.selectWindow("Section Information");
                Thread.Sleep(5000);
                driverobj.WaitForElement(ObjectRepository.sectioninformationclosewindowlink);
                result = driverobj.GetElement(ObjectRepository.sectioninformationclosewindowlink).Text;
                driverobj.SelectWindowClose2("Section Information", "Training");
                //driverobj.GetElement(ObjectRepository.sectioninformationclosewindowlink);
                // driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(5000);
               // driverobj.SwitchTo().Window("");
              //  driverobj.SwitchtoDefaultContent();
                //Thread.Sleep(3000);
                //driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmostrecentrequestusernamelink);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }

        //online course
        public bool linkonlinecourseclick()
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesmanageenrolmentonlinecourses);
                driverobj.ClickEleJs(ObjectRepository.myresponsibilitiesmanageenrolmentonlinecourses);
                driverobj.WaitForElement(ObjectRepository.manageenrolmentforonlinecoursesearchbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool populateonlinecoursesearch(string statusfilter, string texttosearch)
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.manageenrolmentforonlinecoursesearchtextbox);
                driverobj.ClickEleJs(ObjectRepository.manageenrolmentforonlinecoursesearchtextbox);
                Thread.Sleep(2000);
                driverobj.GetElement(ObjectRepository.manageenrolmentforonlinecoursesearchtextbox).SendKeysWithSpace(texttosearch);

                driverobj.FindSelectElementnew(ObjectRepository.manageenrolmentforonlinecoursefilterdropdown, statusfilter);
                //driverobj.GetElement(ObjectRepository.scoretextbox).SendKeysWithSpace(texttosearch);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public string buttononlinecoursesearch()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.manageenrolmentforonlinecoursesearchbutton);
                driverobj.ClickEleJs(ObjectRepository.manageenrolmentforonlinecoursesearchbutton);
                driverobj.WaitForElement(ObjectRepository.manageenrolmentforonlinecoursebuttonenrollcourse);
                return "";
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "false";
            }
        }
        public bool buttononlineenrollusersclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.manageenrolmentforonlinecoursebuttonenrollcourse);
                driverobj.ClickEleJs(ObjectRepository.manageenrolmentforonlinecoursebuttonenrollcourse);
                driverobj.WaitForElement(ObjectRepository.batchenrollmentbatchenrollusersbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool buttononlineusermanageenrolclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.manageenrolmentforonlinecoursemanageenrollment);
                driverobj.ClickEleJs(ObjectRepository.manageenrolmentforonlinecoursemanageenrollment);
                driverobj.WaitForElement(ObjectRepository.cancelenrolmentorwaitlistcancelenrolmentorwaitlistbutton);

            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        internal void CreateClassRoom_CourseSection(string browserstr)
        {
            try
            {
                linkmyresponsibilitiesclick(driverobj);
                linkclassroomcourseclick1("Classroom Course");
                buttongoclick();
                populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "CT_SortTest", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
                buttonsaveclick();
                linkmanagesectionsclick();
                buttonaddnewsectionclick();
                populatesectionform1(browserstr);
                populatesectionform12_AdvanceDate();
                populateframeform();
                buttonsaveframeclick();
                buttonsaveandexitclick();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }

        internal bool CreateClassRoom_CourseSection_EnableAccessKeys(string browserstr)
        {
            bool acturalresult = false;

            try
            {
                //linkmyresponsibilitiesclick(driverobj);
                //linkclassroomcourseclick1("Classroom Course");
                //buttongoclick();
                //populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "CT_SortTest", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
                //buttonsaveclick();
                linkmanagesectionsclick();
                buttonaddnewsectionclick();
                populatesectionform1(browserstr);
                populatesectionform12_AdvanceDate();
                populateframeform();
                buttonsaveframeclick();
                enableaccesskeypurchasetimeframe();
                buttonsaveandexitclick();
                acturalresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return acturalresult;
        }

        internal void Search_EnrollClassRoomCourse_NewUser(string browserstr)
        {
            try
            {
                driverobj.GetElement(ObjectRepository.traininghomesearchtext).SendKeysWithSpace(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "CT_SortTest");
                driverobj.GetElement(ObjectRepository.traininghomeSearchButton).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "CT_SortTest" + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "CT_SortTest" + "')]")).Click();
                driverobj.WaitForElement(locator.detailsenrolbutton);
                driverobj.GetElement(locator.detailsenrolbutton).Click();
                driverobj.WaitForElement(locator.batchenrollmentfeedback);
                driverobj.GetElement(By.XPath("//a[@data-menuitem='traininghome']")).Click();
            }
            catch (Exception ex)
            { 
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void CreateClassRoomCourse(string browserstr)
        {
            Trainings trainingsobj = new Trainings(driverobj);
            linkmyresponsibilitiesclick(driverobj);
            trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            //linkclassroomcourseclick1("Classroom Course");
            //buttongoclick();
            populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] +browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            buttonsaveclick();
        }
        internal void CreateSection_ClassRoomCourse(string browserstr)
        {
            //linkmyresponsibilitiesclick(driverobj);
            //linkclassroomcourseclick();
            //buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, "Exact phrase");
            linkmanagesectionsclick();
            buttonaddnewsectionclick();
            populatesectionform1(browserstr);
            populatesectionform12();
            populateframeform();
            buttonsaveframeclick();
            buttonsaveandexitclick();
        }
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.XPath("//div[@class='fr-element fr-view']");
        public static class locator
        {
            public static By ClassroomCourseSummaryCreditValuetextbox = By.Id("MainContent_UC1_CRSW_CREDIT_VALUE");
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
            public static By ClassroomcourseSave = By.Id("MainContent_UC1_Save");
            public static By classroomCoursesLink = By.XPath("//span[contains(.,'Content Management')]");
            public static By classroomTitle = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");

            public static By classroomDesc = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
            public static By classroomKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By classroomsectionMinimumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
            public static By classroomsectionMaximumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
            public static By contentaccessapprovaleditbutton = By.Id("MainContent_MainContent_ucAccessApproval_accAccesApproval_lnkEdit");
            public static By contentaccessapprovalsuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By contentdeletecontentbutton = By.Id("MainContent_header_FormView1_btnDelete");
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
            public static By contentsearchSearchAdvlnk = By.Id("MainContent_ucSearchTop_FormView1_lblSeeMore");
            public static By contentsearchSearchfortxtbx = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
            public static By contentsearchSearchfilterdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
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
            public static By CourseSectionLink1 = By.Id("MainContent_MHyperLink2");
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
            public static By myresponsibilitiesinstructorgobutton = By.Id("MainContent_ucInstructorToolsSummary_btnSearch");
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
            public static By generalcourseenroll_btn = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
            public static By generalcoursekeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
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
            public static By sectiondetailsEdit = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkEdit");
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

        internal void populatesectionform1()
        {
            throw new NotImplementedException();
        }

        internal void linkSectionsClick()
        {
            driverobj.GetElement(By.XPath("//a[@id='MainContent_hlNewSection']"));
            driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_hlNewSection']"));
            driverobj.WaitForElement(By.XPath("//a[contains(.,'Add a New Section')]"));
            //throw new NotImplementedException();
        }

        internal void addNewSectionClick()
        {
            driverobj.GetElement(By.XPath("//a[contains(.,'Add a New Section')]"));
            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Add a New Section')]"));
            driverobj.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnNext']"));
            //throw new NotImplementedException();
        }
    }
}

