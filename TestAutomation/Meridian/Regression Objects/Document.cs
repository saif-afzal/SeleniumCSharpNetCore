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
using relativepath;
using System.Reflection;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

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
    public class Document
    {
        private readonly IWebDriver driverobj;
        string path = string.Empty;
        RelativeDirectory rd = new RelativeDirectory();
        public bool tocreatedriverobj = false;
        public bool togenralcoursecomplete = false;
        public Document(IWebDriver driver)
        {
            driverobj = driver;
        }
        public string result = string.Empty;



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
        public void populatesummarydocument(IWebDriver iSelenium, string title, string desc, int i)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.genCourseTitle_ED);
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).SendKeysWithSpace(title);
                //Thread.Sleep(4000);
                //generalCourse.GetElement(ObjectRepository.generalcoursedescription).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                if (!driverobj.existsElement(locator.classroomDesc))
                {
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.GetElement(By.CssSelector("body")).ClickWithSpace();

                    driverobj.GetElement(By.CssSelector("body")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);

                    driverobj.SwitchTo().DefaultContent();
                }
                else
                {
                    driverobj.GetElement(locator.classroomDesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                }


                driverobj.GetElement(ObjectRepository.generalcoursekeyword).SendKeysWithSpace(desc);
                driverobj.GetElement(By.XPath("//textarea[contains(@id,'INFO')]")).SendKeysWithSpace("1234567890");
                driverobj.GetElement(locator.generalcourseuniqueid).Clear();
                driverobj.GetElement(locator.generalcourseuniqueid).SendKeysWithSpace(locator.globalnum + i);


            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
        }

        public void tabcontentmanagementclick()
        {


            try
            {
                //driverobj.WaitForElement(Locator_Training.Training_CreateButtonClick);
                //driverobj.GetElement(Locator_Training.Training_CreateButtonClick).Click();
                //driverobj.WaitForElement(courselink);
                //driverobj.FindElement(courselink).Click();
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }

        public void searchForContentFromAdminSide(string type, string browserstr, string scorm = "")
        {


            try
            {
                switch (type)
                {
                    case "scorm":
                        {
                            driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(scorm);
                            driverobj.ClickEleJs(By.XPath("//a[@id='btnSearch']/span"));
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SearchContentRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + scorm + "')]"));
                            break;
                        }
                    

                
            }
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }

        public bool requestAccessForContent(string type, string browserstr, string document= "", string classroom = "", string scorm = "")
        {
            bool actualresult = false;
            try
            {
                switch (type)
                {
                    case "Document":

                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("userforregression", browserstr);

                            #region Request Access By Learner
                            driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                            driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(document);
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + document + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + document + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + document + "')]"));
                            driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));

                            driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            Thread.Sleep(5000);
                            driverobj.GetElement(By.XPath("//input[@class='btn btn-primary pull-right']")).ClickWithSpace();
                            driverobj.SwitchTo().DefaultContent();
                            driverobj.WaitForElement(By.XPath("//div[contains(@class,'alert alert-success')]"));
                            
                            #endregion

                            break;
                        }

                    case "ClassroomCourse":

                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("userforregression", browserstr);

                            #region Request Access By Learner
                            driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                            driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(classroom);
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + classroom + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + classroom + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + classroom + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
                            //driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            //Thread.Sleep(5000);
                            //driverobj.GetElement(By.XPath("//textarea[@id='MainContent_UC1_tbUnenrollReason']")).SendKeysWithSpace("Testing Purpose");
                            //driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                            //driverobj.SwitchTo().DefaultContent();
                            driverobj.ClickEleJs(By.XPath("//input[@value='Request Access']"));

                            driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            Thread.Sleep(5000);
                            driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                            driverobj.SwitchTo().DefaultContent();
                            driverobj.WaitForElement(By.XPath("//div[contains(@class,'alert alert-success')]"));
                            #endregion
                            break;
                        }

                    case "scorm":
                        {
                            #region Request Access By Learner
                            driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                            driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(scorm);
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + scorm + "')]"));
                                                        
                            driverobj.ClickEleJs(By.XPath("//input[@value='Request Access']"));
                            Thread.Sleep(5000);
                            driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            Thread.Sleep(5000);
                            driverobj.ClickEleJs(By.XPath("//input[@value='Request Access']"));
                            Thread.Sleep(5000);
                            driverobj.SwitchTo().DefaultContent();
                            driverobj.WaitForElement(By.XPath("//div[contains(@class,'alert alert-success')]"));
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

        public bool cancelRequestAccessForContent(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                switch (type)
                {
                    case "Document":

                        {
                            #region Cancel Request Access By Learner
                            driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                            driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            Thread.Sleep(5000);
                            driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                            driverobj.SwitchTo().DefaultContent();
                            driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                            #endregion
                           
                            break;
                        }

                    case "ClassroomCourse":

                        {
                            #region Cancel Request Access By Learner
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Cancel Request')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Cancel Request')]"));
                            driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            Thread.Sleep(5000);
                            driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                            driverobj.SwitchTo().DefaultContent();
                            driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                            #endregion
                            break;
                        }

                    case "scorm":
                        {
                            #region Cancel Request Access By Learner
                            driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                            Thread.Sleep(5000);
                            driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            Thread.Sleep(5000);
                            driverobj.ClickEleJs(By.XPath("//input[@value='Cancel Request']"));
                            Thread.Sleep(5000);
                            driverobj.SwitchTo().DefaultContent();
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

        public bool requestAccess(string document, string browserstr )
        {
         bool result = false;

            try
            {
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("userforregression", browserstr);
               
                #region Request Access By Learner
                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(document);
                driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                driverobj.WaitForElement(By.XPath("//a[contains(.,'"+ document +"')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + document + "')]"));
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'"+document+"')]"));
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
                
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.XPath("//div[contains(@class,'alert alert-success')]"));
                result = true;
                #endregion

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

            return result;
        }

        public bool cancelRequestAccess(string document, string browserstr)
        {
            bool result = false;

            try
            {
                #region Cancel Request Access By Learner
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
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

        public bool removeAccessApproval(string type, string browserstr, string document="",  string scorm="")
        {
            bool result = false;
           
            try
            {
                switch (type)
                {
                    case "Document":
                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("admin1", browserstr);
                            linkmyresponsibilitiesclick();
                            driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(document);
                            driverobj.ClickEleJs(By.XPath("//a[@id='btnSearch']/span"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + document + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + document + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + document + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Checkout')]"));
                            driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.ClickEleJs(By.XPath("//input[@value='N']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                            driverobj.findandacceptalert();
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Check-in')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Checkout')]"));
                            
                            break;
                        }

                    case "Scorm":
                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("admin1", browserstr);
                            linkmyresponsibilitiesclick();
                            driverobj.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(scorm);
                            driverobj.ClickEleJs(By.XPath("//a[@id='btnSearch']/span"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + scorm + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Checkout')]"));
                            driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                            driverobj.ClickEleJs(By.XPath("//input[@value='N']"));
                            driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                            driverobj.findandacceptalert();
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Check-in')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'Checkout')]"));
                           
                            break;
                        }
                }
                
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

            return result;
        }


        public bool launchDocument(string type, string browserstr, string document="", string scorm="")
        {
            bool result = false;

            try
            {
                switch (type)
                {
                    case "Document":
                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("userforregression", browserstr);

                            #region Launch Document
                            driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                            driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(document);
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + document + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + document + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + document + "')]"));
                            driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
                            Thread.Sleep(5000);
                            driverobj.SelectWindowClose2("Google", "" + document);
                            Thread.Sleep(5000);
                        result=driverobj.existsElement(By.XPath("//input[@value='Mark Complete']"));

                            #endregion
                            
                            break;
                        }

                    case "Scorm":
                        {
                            driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                            driverobj.UserLogin("userforregression", browserstr);

                            #region Launch Document
                            driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                            driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(scorm);
                            driverobj.ClickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                            driverobj.WaitForElement(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + scorm + "')]"));
                            driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + scorm + "')]"));

                            //driverobj.ClickEleJs(By.XPath("//input[@value='Enroll']"));
                            //driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                            //Thread.Sleep(5000);
                            //driverobj.GetElement(By.XPath("//input[@class='btn btn-primary pull-right']")).ClickWithSpace();
                            //driverobj.SwitchTo().DefaultContent();
                            //driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));

                            driverobj.ClickEleJs(By.XPath("//input[@value='Open Item']"));
                            Thread.Sleep(5000);
                            //Launch Scorm
                            driverobj.selectWindow("Meridian Global - Core Domain");
                            Thread.Sleep(5000);
                            driverobj.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
                            //    driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                            Thread.Sleep(3000);
                            driverobj.WaitForElement(By.XPath("//input[@value='Resume']"));

                            #endregion
                            result = true;
                            break;
                        }
                }
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

            return result;
           
        }

        public bool markCompleteDocument(string document, string browserstr)
        {
            bool result = false;

            try
            {
                #region mark Complete Document
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock']"));
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Thread.Sleep(5000);
                driverobj.GetElement(By.XPath("//input[@class='btn btn-primary pull-right']")).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchCurrentCompletedAttempt']"));

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

        public string buttondeletesectionclick()
        {
            string result = string.Empty;
            try
            {
                driverobj.ClickEleJs(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/button"));
             
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
                //driverobj.HoverLinkClick(By.XPath(".//*[@id='contentDetailsHeader']/div[2]/div/button"), By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
            
                Thread.Sleep(3000);
                driverobj.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                //driverobj.WaitForElement(locator.sectiondetailssuccessmessage);
                //result = driverobj.GetElement(locator.sectiondetailssuccessmessage).Text;

            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "";
            }
            return result;
        }
        public void buttoncoursecreationgoclick(string text)
        {

            try
            {
                driverobj.select(locator.myresponsibilitiescontentmanagementselectcoursedropdown, text);
                driverobj.GetElement(locator.myresponsibilitiescontentmanagementgobutton).ClickWithSpace();
              //  driverobj.WaitForElement(By.Id("MainContent_UC1_Next"));
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
        public bool buttoncourseeditclick()
        {

            try
            {
                driverobj.ClickEleJs(locator.sectiondetailsEdit);


                driverobj.WaitForElement(locator.driverobjKeywordupdate);
           
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
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
                driverobj.ScrollToCoordinated("500", "500");
                driverobj.WaitForElement(locator.driverobjKeywordupdate);
             //   driverobj.GetElement(driverobjKeywordupdate).ClickWithSpace();
                driverobj.GetElement(locator.driverobjKeywordupdate).SendKeysWithSpace(keyword);
                //  driverobj.GetElement(locator.driverobjSummaryCreditValuetextbox).Clear();
                //  driverobj.GetElement(locator.driverobjSummaryCreditValuetextbox).SendKeysWithSpace("3");
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);
                return "true";
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public string buttonsaveeditclassroomsaveclick()
        {

            try
            {
                driverobj.ScrollToCoordinated("500", "500");
                driverobj.GetElement(locator.driverobjUpdateSave).ClickWithSpace();
                driverobj.WaitForElement(locator.contentaccessapprovalsuccessmessage);
                string text = driverobj.GetElement(locator.contentaccessapprovalsuccessmessage).Text;
                driverobj.SwitchtoDefaultContent();
                driverobj.Checkin();
                return text;
                //driverobj.GetElement(locator.schedulemanagesectionResulttable).Text;
                //Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return "false";
            }

        }
        public void buttonsearchgoclick(string Title, string filtertext)
        {

            try
            {
                driverobj.WaitForElement(locator.contentsearchSearchfortxtbx);
                driverobj.ClickEleJs(locator.contentsearchSearchfortxtbx);
                Thread.Sleep(2000);
                driverobj.GetElement(locator.contentsearchSearchfortxtbx).SendKeysWithSpace(Title);
                Thread.Sleep(2000);
       //         driverobj.select(locator.contentsearchSearchfilterdrpdwn, filtertext);
                driverobj.ClickEleJs(locator.contentsearchSearchbutton);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + Title + "')]"));
               // driverobj.ScrollToCoordinated("500", "500");
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + Title + "')]"));
                //    driverobj.WaitForElement(locator.ManageSectionsLink);
                //    driverobj.Checkout();

            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

        }

        public void editApprovalEnable()
        {

            try
            {
                //   driverobj.WaitForElement();
                //   driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                //   driverobj.WaitForElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
                //  driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_rbApprovalRequired_0']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                driverobj.WaitForElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

        }

        public bool editActivityMarkInactive()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucActivity_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucActivity_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'Manage Activity')]"));
                driverobj.ClickEleJs(By.XPath("//input[@value='F']"));
                driverobj.WaitForElement(By.XPath("//input[@value='Save']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Save']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

            return result;
        }

        public bool editActivityMarkActive()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucActivity_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucActivity_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'Manage Activity')]"));
                driverobj.ClickEleJs(By.XPath("//input[@value='T']"));
                driverobj.WaitForElement(By.XPath("//input[@value='Save']"));
                driverobj.ClickEleJs(By.XPath("//input[@value='Save']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }
            return result;
        }



        public bool editApprovalDiable()
        {
            bool result = false;
            try
            {
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessApproval_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));

                driverobj.ClickEleJs(By.XPath("//input[@value='N']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                driverobj.findandacceptalert();
                            
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);

                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);

            }

            return result;
        }

        public void populatesummarygeneralCourse(IWebDriver iSelenium, string title, string desc)
        {

            try
            {
                
                driverobj.WaitForElement(ObjectRepository.genCourseTitle_ED);
                driverobj.ClickEleJs(ObjectRepository.genCourseTitle_ED);
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).SendKeysWithSpace(title);
             //   driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(ObjectRepository.generalcoursekeyword).SendKeysWithSpace(desc);


            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
        }
        public bool populatecontentsearchadvance(string statusfilter, string texttosearch1, string Desctext, int i)
        {
            try
            {
                driverobj.GetElement(locator.contentsearchSearchfortxtbx).SendKeysWithSpace(texttosearch1);
                driverobj.GetElement(locator.contentsearchSearchAdvlnk).Click();
                // generalCourse.WaitForElement(locator.contentsearchSearchDescriptiontxtbx);
                //   generalCourse.GetElement(locator.contentsearchSearchDescriptiontxtbx).SendKeysWithSpace(Desctext);
                driverobj.WaitForElement(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"));
                driverobj.select(By.XPath("//select[@id='MainContent_ucSearchTop_CNT_CONTENT_TYPE_ID']"), "driverobj");
                //driverobj.select(locator.contentsearchSearchfilterdrpdwn, statusfilter);
                //generalCourse.GetElement(locator.scoretextbox).SendKeysWithSpace(texttosearch);

            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                driverobj.LogoutUser(locator.LogoutHoverLink, locator.HoverMainLink);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void populateCourseFilesform(IWebDriver iSelenium, bool url)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.generalcourseboostindex);
                driverobj.GetElement(ObjectRepository.generalcourseboostindex).SendKeysWithSpace("2");
                if (url == true)
                {
                  //  driverobj.GetElement(locator.createdriverobjtypeurlradiobutton).ClickWithSpace();
                    driverobj.ClickEleJs(locator.createdriverobjtypeurlradiobutton);
                    driverobj.GetElement(ObjectRepository.generalcourseurl_txtfld).SendKeysWithSpace(ExtractDataExcel.MasterDic_document["Url"]);
                  //  driverobj.GetElement(locator.createdriverobjtypeurltxtbox).SendKeysWithSpace(ExtractDataExcel.MasterDic_document["Url"]);
                }
                else
                {
                    driverobj.navigateAICCfile("\\Data\\Fileupload.txt", By.XPath("//input[@id='AsyncUpload1file0']"));
                }




            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
        }
        public bool buttoncreateclick(IWebDriver iSelenium)
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.create_btn_new);
                driverobj.GetElement(ObjectRepository.create_btn_new).ClickWithSpace();

            //    driverobj.WaitForElement(ObjectRepository.CheckinNew);
            //    driverobj.ClickEleJs(ObjectRepository.CheckinNew);
           //     driverobj.WaitForElement(ObjectRepository.myResponsibilities);
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                return false;

            }
            return true;//throws information is saved
        }





        public void uploadfile(string path)
        {
            try
            {
                Thread.Sleep(6000);
                driverobj.GetElement(locator.driverobj_fileupload).Click();
                Thread.Sleep(2000);
                driverobj.GetElement(By.XPath("//input[@class='ruFileInput']")).SendKeysWithSpace(path);
                driverobj.WaitForElement(By.XPath("//input[@class='ruButton ruRemove']"));
                // driverobj.GetElement(locator.driverobj_fileupload).SendKeysWithSpace(path);
                //scorm12.GetElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_UploadContent_TDElementUploadFile']/table/tbody/tr/td/input")).SendKeysWithSpace(path);
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                System.Windows.Forms.SendKeys.SendWait("{ESC}");
                Thread.Sleep(6000);
                // path = string.Empty;
                // uploadfile(path);
            }
        }
        public void navigatedriverobjfile()
        {

            try
            {
                path = rd.Up(2) + "\\Data\\Fileupload.txt";
                // path = path.Replace("\\", "/");
                Thread.Sleep(7000);
                uploadfile(path);
                Thread.Sleep(11000);

            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
        }
        public void CreateDocuemntCourse(string browserstr)
        {
            linkmyresponsibilitiesclick();
            //tabcontentmanagementclick();
            //buttoncoursecreationgoclick("Document");
            CommonSection.CreateLink.Document();
            populatesummarygeneralCourse(driverobj, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
            populateCourseFilesform(driverobj, true);
            driverobj.ScrollToCoordinated("500", "500");
            driverobj.GetElement(By.CssSelector("input[id='MainContent_UC1_Save']")).ClickWithSpace();
            Thread.Sleep(2000);
            driverobj.ClickEleJs(By.Id("MainContent_header_FormView1_btnStatus"));
            Thread.Sleep(2000);
        }
        internal void Create_DocumentForRegression(string title,string browserstr)
        {
            Trainings trainingsobj = new Trainings(driverobj);
            linkmyresponsibilitiesclick();
            trainingsobj.CreateContentButton_Click_New(Locator_Training.Document_CourseClick);
            populatesummarygeneralCourse(driverobj, title, ExtractDataExcel.MasterDic_document["Desc"]);
            populateCourseFilesform(driverobj, true);
            //driverobj.ScrollToCoordinated("500", "500");
            buttoncreateclick(driverobj);
 
        }
        internal bool ValidatePreviewButton_Document(string title)
        {
            bool actualres = false;
            try
            {
                if (driverobj.IsElementVisible(By.CssSelector("input[id*='_btnPreview']")))
                {
                    string originalHandle = driverobj.CurrentWindowHandle;
                    driverobj.ClickEleJs(By.CssSelector("input[id*='_btnPreview']"));
                    Thread.Sleep(3000);
                    driverobj.SelectWindowClose2("Google", title);
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
        internal void ManageDocumentCourse(string browserstr)
        {
            try
            {
                string actualresult = string.Empty;
                linkmyresponsibilitiesclick();
              //  tabcontentmanagementclick();
                buttonsearchgoclick(ExtractDataExcel.MasterDic_document["Title"] + browserstr, "Exact phrase");
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

        public bool createDocument(string browserstr)
        {
            bool result = false;
            try
            {
                Document documentobj = new Document(driverobj);
                Trainings Trainingsobj = new Trainings(driverobj);
                documentobj.linkmyresponsibilitiesclick();
                Trainingsobj.CreateContentButton_Click_New(Locator_Training.Document_CourseClick);
                documentobj.populatesummarygeneralCourse(driverobj, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
                documentobj.populateCourseFilesform(driverobj, true);
                driverobj.ScrollToCoordinated("500", "500");
                documentobj.buttoncreateclick(driverobj);

                result = true;
            }

            catch(Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool shareDocument(string browserstr)
        {
            bool result = false;
            try
            {
                Document documentobj = new Document(driverobj);
                Trainings Trainingsobj = new Trainings(driverobj);
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'Manage Content Sharing')]"));
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToAllDomains']"));
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

        //public bool createDocument(string browserstr)
        //{
        //    bool result = false;
        //    try
        //    {
        //        Document documentobj = new Document(driverobj);
        //        Trainings Trainingsobj = new Trainings(driverobj);
        //        documentobj.linkmyresponsibilitiesclick();
        //        Trainingsobj.CreateContentButton_Click_New(Locator_Training.Document_CourseClick);
        //        documentobj.populatesummarygeneralCourse(driverobj, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
        //        documentobj.populateCourseFilesform(driverobj, true);
        //        driverobj.ScrollToCoordinated("500", "500");
        //        documentobj.buttoncreateclick(driverobj);

        //        result = true;
        //    }

        //    catch(Exception ex)
        //    {
        //        ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
        //        Console.WriteLine(ex.Message);
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //    }

        //    return result;
        //}

        //public bool shareDocument(string browserstr)
        //{
        //    bool result = false;
        //    try
        //    {
        //        Document documentobj = new Document(driverobj);
        //        Trainings Trainingsobj = new Trainings(driverobj);
        //        driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
        //        driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
        //        driverobj.WaitForElement(By.XPath("//h2[contains(.,'Manage Content Sharing')]"));
        //        driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToAllDomains']"));
        //        driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
        //        driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
        //        result = true;
        //    }

        //    catch (Exception ex)
        //    {
        //        ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
        //        Console.WriteLine(ex.Message);
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //    }

        //    return result;
        //}

        public bool sètImage(string browserstr)
        {
            bool result = false;
            try
            {
                Document documentobj = new Document(driverobj);
                Trainings Trainingsobj = new Trainings(driverobj);
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucImage_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucImage_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'Image')]"));
                driverobj.navigateAICCfile("Data\\image.jpg", By.XPath("//input[@class='ruFileInput']"));
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                driverobj.WaitForElement(By.XPath("//img[@class='img-thumbnail']"));
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

        public bool manageDocument(string browserstr)
        {
            bool result = false;
            try
            {
                Document documentobj = new Document(driverobj);
                Trainings Trainingsobj = new Trainings(driverobj);
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'Summary')]"));
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
        public static class locator
        {
            
            public static By driverobjKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By driverobjKeywordupdate = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
            public static By generalcourseuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");
            public static By myresponsibilitiescontentmanagementselectcoursedropdown = By.Id("MainContent_ucSearchTop_ddlCreateNew");
            public static By myresponsibilitiescontentmanagementtab = By.XPath("//a[@href='../ContentSearch.aspx']");
            public static By myresponsibilitiescontentmanagementgobutton = By.Id("MainContent_ucSearchTop_btnCreateNew");
            public static By driverobjSummaryCreditValuetextbox = By.Id("MainContent_UC1_CRSW_CREDIT_VALUE");
            public static By createdriverobjtypeurlradiobutton = By.Id("MainContent_UC1_EXTERNALFILE_URL");
            public static By createdriverobjtypeurltxtbox = By.Id("MainContent_UC1_driverobj_URL");
            public static By driverobj_fileupload = By.Id("AsyncUpload1ListContainer");
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
            public static By driverobjSave = By.Id("MainContent_UC1_Save");
             public static By driverobjUpdateSave = By.Id("MainContent_MainContent_UC1_Save");
          
            public static By driverobjsLink = By.XPath("//span[contains(.,'Content Management')]");
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
            public static By contentsearchSearchAdvlnk = By.XPath("//a[contains(.,'See more search criteria')]");
            public static By contentsearchSearchfortxtbx = By.Id("MainContent_ucAdminSearch_txtSearchFor");
            public static By contentsearchSearchfilterdrpdwn = By.Id("MainContent_ucSearchTop_SearchType");
            public static By contentsearchSearchTitletxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_TITLE");
            public static By contentsearchSearchDescriptiontxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_DESCRIPTION");
            public static By contentsearchSearchKeywordstxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_KEYWORDS");
            public static By contentsearchSearchCategorytxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNTCTGY_CATEGORY_ID");
            public static By contentsearchSearchRatingfilterdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_strRatingType");
            public static By contentsearchSearchRatingdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_intRating");
            public static By contentsearchSearchEditingStatusdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchStatusType");
            public static By contentsearchSearchActivitydrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchActivity");
            public static By contentsearchSearchbutton = By.Id("btnSearch");
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



    }
}


//:check_in=>[:text,"Check In"],
//      :check_out =>[:text,"Check Out"],
//      :search_course=>[:id,"TabMenu_ML_BASE_TAB_Search_SearchFor"],
//      :search_type =>[:id,"TabMenu_ML_BASE_TAB_Search_SearchType"], 
//      :search_btn =>[:id,"TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"],