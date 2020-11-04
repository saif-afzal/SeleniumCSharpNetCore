using System;
using System.Collections.Generic;
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
    class Instructor
    {
        private readonly IWebDriver driverobj;
        public Instructor(IWebDriver driver)
        {
            driverobj = driver;
        }
        //select instructors
        public bool buttonselectinstructorclick()
        {

            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(600,600)", "");
                driverobj.WaitForElement(locator.editeventselectlocationbutton);
                driverobj.GetElement(locator.editeventselectinstructorbutton).ClickWithSpace();
             
                driverobj.WaitForElement(locator.selectinstructorframesearchbutton);
              

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool populateselectinstructorform(string firstname, string lastname)
        {

            try
            {
                driverobj.GetElement(locator.lname_text).SendKeys(lastname);
                driverobj.GetElement(locator.fname_text).SendKeys(firstname);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool buttonselectinstructorsearchclick()
        {

            try
            {
                driverobj.GetElement(locator.selectinstructorframesearchbutton).ClickWithSpace();
                driverobj.WaitForElement(locator.selectinstructorframecheckbox);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return true;
            }
            return false;
        }
        public bool buttonselectinstructorcheckboxclick()
        {

            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driverobj;
                jse.ExecuteScript("window.scrollBy(600,600)", "");
                driverobj.GetElement(locator.selectinstructorframecheckbox).ClickWithSpace();
                driverobj.WaitForElement(locator.selectinstructorframessaveandexitbutton);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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

                driverobj.GetElement(locator.selectinstructorframessaveandexitbutton).ClickWithSpace();
                
                driverobj.WaitForElement(locator.selectinstructorssuccessmessage);
                result = driverobj.GetElement(locator.selectinstructorssuccessmessage).Text;

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        public string buttonwaitlistclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(locator.createnewcoursesectionandeventradiobutton);
                driverobj.GetElement(locator.createnewcoursesectionandeventradiobutton).ClickWithSpace();
                result = "true";
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        public bool linkinstructortoolsclick()
        {
            try
            {
                driverobj.GetElement(ObjectRepository.instructortools).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void taballinstructorsclick(IWebDriver driver)
        {
            try
            {
                driverobj.GetElement(ObjectRepository.managestudentsallinstructorstab).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.managestudentsallinstructorssearchtextbox);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }
        public string linkinstructortoolportletclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesinstructortoolsportlettableresult);
                driverobj.GetElement(ObjectRepository.myresponsibilitiesinstructortoolsportlettableresult).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.managestudentslink);
                return "true";
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "false";
            }
        }
        public string buttonemailallclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.managestudentsrosteremailallbutton).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.sendemailmessagetextbox);
                return "true";
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string buttonemailinstructortoolsclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.managestudentsrosteremailallbutton).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(ObjectRepository.sendemailmessagetextbox);
                return "true";
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string populatemessageform(string subject, string message)
        {

            try
            {
                driverobj.GetElement(ObjectRepository.sendemailsubjecttextbox).SendKeys(subject);
                driverobj.GetElement(ObjectRepository.sendemailmessagetextbox).SendKeys(message);
                return "true";

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public bool linkmanageclick()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.manage);
                driverobj.GetElement(ObjectRepository.manage).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
                driverobj.GetElement(ObjectRepository.allinstructors).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool linkcoursemanagesurveyclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.managestudentsmanagesurveylink);
                driverobj.GetElement(ObjectRepository.managestudentsmanagesurveylink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.surveysassignsurveyslink);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
                driverobj.GetElement(ObjectRepository.managestudentsallinstructorssearchtextbox).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.GetElement(ObjectRepository.managestudentsallinstructorssearchtextbox).SendKeys(classroomtitle);
                Thread.Sleep(2000);
                driverobj.FindSelectElementnew(ObjectRepository.managestudentinstructortoolssearchfilterdrpdown, filter);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
                driverobj.GetElement(ObjectRepository.managestudentsinstructortoolsearchbutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.resulttabletext);
                return driverobj.GetElement(ObjectRepository.resulttabletext).Text;

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
                driverobj.GetElement(ObjectRepository.resulttabletext).ClickWithSpace();
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "no tabs found";
            }

        }
        public string linkrecordattaendancescoresclick()
        {

            try
            {
                // driverobj.GetElement(ObjectRepository.resulttabletext).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.recordattendanceandscores).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.resulttabletext1);
                return driverobj.GetElement(ObjectRepository.resulttabletext1).Text;

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return "";
            }

        }
        public bool populateatendancestatusscoresform(string statusfilter, string score)
        {
            try
            {
                driverobj.GetElement(ObjectRepository.attendancechkbox).ClickWithSpace(); ;
                driverobj.FindSelectElementnew(ObjectRepository.statusdrpdown, statusfilter);
                driverobj.GetElement(ObjectRepository.scoretextbox).SendKeys(score);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return false;
            }
            return true;
        }
        public string linkresulttableclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.resulttabletext).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.recordattendanceandscores);
                return driverobj.GetElement(ObjectRepository.resulttabletext1).Text;

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public string buttonsendmailclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.sendemailsendbutton).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().DefaultContent();
                Thread.Sleep(3000);
                return driverobj.GetElement(ObjectRepository.selectlocationssuccessmessage).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public void tabmanagestudentsclick(IWebDriver driver)
        {
            try
            {
                driverobj.GetElement(ObjectRepository.managestudentsmanagestudentstab).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.managestudentsallinstructorstab);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);Console.WriteLine(ex.Message);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "false";
            }
        }
        public string buttongoinstructortoolportletclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesinstructortoolsportletbutton);
                driverobj.GetElement(ObjectRepository.myresponsibilitiesinstructortoolsportletbutton).ClickWithSpace();
                return "true";
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "false";
            }
        }
        public string buttonallmysectionsclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myresponsibilitiesinstructortoolportletallmysectionbutton);
                driverobj.GetElement(ObjectRepository.myresponsibilitiesinstructortoolportletallmysectionbutton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.managestudentsallinstructorstab);
                return driverobj.GetElement(ObjectRepository.managestudentsallinstructorstab).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "false";
            }
        }
        public void linkinstructortoolsclick(IWebDriver driver)
        {
            try
            {
                driverobj.GetElement(ObjectRepository.managestudentsinstructortoolslink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.managestudentsmyteachingscheduletab);


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);Console.WriteLine(ex.Message);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

        }
        public string InstructorToolsPortlet(IWebDriver iSelenium)
        {
            string result = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
                driverobj.GetElement(ObjectRepository.searchHome);
                driverobj.GetElement(By.Id("ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00_ctl04_lnkDetails")).ClickWithSpace();
                result = driverobj.GetElement(By.CssSelector("h1")).Text;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);Assert.Fail(ex.Message);
            }
            return result;
        }
        public void buttonattendanceclick()
        {

            try
            {
                driverobj.GetElement(locator.attendancebutton).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                // return "";
            }

        }
        public string buttonstatusclick()
        {

            try
            {
                driverobj.GetElement(locator.statusfilterbutton).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);
                return driverobj.GetElement(locator.progressstatus).GetAttribute("value");

                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public string buttonscoreclick()
        {

            try
            {
                driverobj.GetElement(locator.scorebutton).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(5000);
                return driverobj.GetElement(locator.scoretext).GetAttribute("value");
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                driverobj.GetElement(locator.savebutton).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(10000);
                return driverobj.GetElement(locator.sucessmessage).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        public static class locator
        {
        
            public static By editeventselectinstructorbutton = By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectInst");
            public static By selectinstructorframesearchbutton = By.Id("MainContent_MainContent_UC1_btnSearch");
            public static By selectinstructorframecheckbox = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_SectionInstructorSearch_ctl00_ctl04_chkSelect");
            public static By selectinstructorframessaveandexitbutton = By.Id("MainContent_MainContent_UC1_Save");
            public static By selectinstructorssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By editeventselectlocationbutton = By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectLoc");
            public static By selectlocationframesearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By selectlocationframesroomtyperadiobutton = By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect");
            public static By selectlocationframessaveandexitbutton = By.Id("MainContent_UC1_Save");
            public static By selectlocationssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By createnewcoursesectionandeventradiobutton = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_WAITLIST_OPTION_0");
            public static By LogoutHoverLink = By.XPath("//a[normalize-space()='Logout']");
            public static By lname_text = By.Id("MainContent_UC1_USR_LAST_NAME");
            public static By fname_text = By.Id("MainContent_UC1_USR_FIRST_NAME");
            public static By savebutton = By.Id("MainContent_UC1_Save");
            public static By attendancebutton = By.Id("MainContent_UC1_btnAttendance");
            public static By statusfilterbutton = By.Id("MainContent_UC1_btnProgress");
            public static By progressstatus = By.Id("ctl00_MainContent_UC1_rgEnrolled_ctl00_ctl04_ddlProgress");
            public static By scorebutton = By.Id("MainContent_UC1_btnScore");
            public static By scoretext = By.Id("ctl00_MainContent_UC1_rgEnrolled_ctl00_ctl04_PRG_FINAL_SCORE");
            public static By sucessmessage = By.XPath("//div[@class='alert alert-success']");

        }
    }
}
            /// <summary>
            /// declaring the variables
            /// </summary>


