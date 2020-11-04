using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
//using Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet;
using System.Reflection;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class Details
    {
        private readonly IWebDriver driverobj;

        public Details(IWebDriver driver)
        {
            driverobj = driver;
        }
        // Complete Certification/Curriculum by clicking AccessItem to display surveys
        public bool CompleteContent()
        {
            try
            {
                if (!driverobj.existsElement(btn_AccessItemCertification))//(r_TC_Curriculum.isCurriculum)
                {
                    driverobj.WaitForElement(btn_Enroll);
                    driverobj.ClickEleJs(btn_Enroll);

                    driverobj.WaitForElement(btn_AccessItemCurriculum);
                    driverobj.ClickEleJs(btn_AccessItemCurriculum);
                }
                else
                {
                    driverobj.WaitForElement(btn_AccessItemCertification);
                    driverobj.ClickEleJs(btn_AccessItemCertification);
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        // Survey Displayed on Certification completion
        public bool SurveyDisplays()
        {
            try
            {
                driverobj.WaitForElement(lnk_SelectedSurvey);
                driverobj.GetElement(lnk_SelectedSurvey);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool EnrollClassroomCourse()
        {
            try
            {
                driverobj.WaitForElement(By.CssSelector("input[id*='_EnrollButton']"));
                driverobj.GetElement(By.CssSelector("input[id*='_EnrollButton']")).Click();
                driverobj.WaitForElement(lnk_SuccessMsg);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool Click_ExpandClassroomCourseSection(string sectiontitle)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(detailssectioninfo).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//span[contains(.,'" + sectiontitle + "')]"));

                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        #region test

        public bool Click_ManageTestLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
            //    driverobj.GetElement(lnk_manage).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }



        public bool Click_LockTestLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_locktest);
              //  driverobj.GetElement(lnk_locktest).ClickWithSpace();
                driverobj.ClickEleJs(lnk_locktest);


                if (!driverobj.existsElement(lbl_success_old))
                { result = false; }
                else result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return result;
        }

        public bool Click_PublishScrom_1_2_Link()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_scorm2004);
                driverobj.WaitForElement(lnk_scorm1_2);
             //   driverobj.GetElement(lnk_scorm1_2).ClickWithSpace();
                driverobj.ClickEleJs(lnk_scorm1_2);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_PublishedTestTitleLink(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + "test_" + browserstr + ExtractDataExcel.token_for_reg + "')]"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'" + "test_" +browserstr+ ExtractDataExcel.token_for_reg + "')]")).ClickWithSpace();
             //   driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + "test_" + browserstr + ExtractDataExcel.token_for_reg + "')]"));
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[2]/div[3]/table/tbody/tr[2]/td[2]/a"));
                
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_PublishedManageLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_manage);
                driverobj.GetElement(lnk_manage).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_CopyTest()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_copy);
              //  driverobj.GetElement(lnk_copy).ClickWithSpace();
                driverobj.ClickEleJs(lnk_copy);
                driverobj.findandacceptalert();
                Thread.Sleep(10000);
                driverobj.WaitForElement(lbl_success_old);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_AssignRequiredTrainingLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_requiredtraining);
             //   driverobj.GetElement(lnk_requiredtraining).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[2]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }
        //public bool Click_DeletePublishedTestLink()
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        string originalHandle = driverobj.CurrentWindowHandle;
        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
        //        driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();


        //        int i = 0;
        //        bool windowFound = false;
        //        while (i < 3 && windowFound == false)
        //        {
        //            windowFound = driverobj.SwitchWindow("Delete Content");
        //            i++;
        //        }
        //        if (windowFound)
        //        {

        //            driverobj.WaitForElement(btn_delete_content);
        //            driverobj.GetElement(btn_delete_content).ClickAnchor();
        //            Thread.Sleep(5000);
        //            driverobj.SwitchTo().Window(originalHandle);
        //            Thread.Sleep(5000);
        //            actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));
        //            //actualresult = true;
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

        //         driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //    }
        //    return actualresult;
        //}

        #endregion
        public bool Click_DeletePublishedTestLink()
        {
            bool actualresult = false;
            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[4]"));
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[4]"));
                driverobj.WaitForElement(btn_delete_content);
            //    driverobj.GetElement(btn_delete_content).ClickAnchor();
                driverobj.ClickEleJs(btn_delete_content);
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[1]"));
                //actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));
                actualresult = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }

        public bool Click_ELManageLink()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_manage);
             //   driverobj.GetElement(lnk_manage).ClickWithSpace();
                driverobj.ClickEleJs(lnk_manage);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_DeleteEL()
        {
            bool actualresult = false;
            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[2]"));
             //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("html/body/form/div[3]/div[4]/div[5]/div[3]/div[1]/a[2]"));
                driverobj.WaitForElement(btn_delete_content);
                driverobj.GetElement(btn_delete_content).ClickAnchor();
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));
                if (!actualresult)
                {
                    if (!driverobj.existsElement(By.XPath("//a[contains(.,'Delete Content')]")))
                    { actualresult = true; }
                }
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        public bool Click_EnrollGeneralCourse()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_enrollgencourse);
                driverobj.GetElement(btn_enrollgencourse).ClickWithSpace();
                driverobj.WaitForElement(btn_opengencourse);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_OpenGeneralCourse()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_opengencourse);
                driverobj.WaitForElement(btn_cancleenrollgencourse);
                driverobj.ClickEleJs(btn_opengencourse);
                Thread.Sleep(5000);
                driverobj.SelectWindowClose2("Google","Details");
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_MarkCompleteGeneralCourse()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_markcompletegencourse);
                driverobj.ClickEleJs(btn_markcompletegencourse);
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(btn_markcompletegencourseframe);
                driverobj.ClickEleJs(btn_markcompletegencourseframe);
                driverobj.SwitchtoDefaultContent();
                driverobj.WaitForElement(lbl_success);


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }


        public bool Click_ViewDetailGeneralCourseCompleted(string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_viewdetailcompleted);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.ClickEleJs(lnk_viewdetailcompleted);
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
           //     driverobj.selectWindow(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "AllMyTraining" + 1);
                driverobj.SwitchtoDefaultContent();
                driverobj.ClickEleJs(By.XPath(".//*[@id='PageBody']/body/div[2]/div[1]/div/a"));
                Thread.Sleep(4000);
                //driverobj.WaitForElement(lbl_mainheading);
                //if (!driverobj.GetElement(lbl_mainheading).Text.Contains(searchtext))
                //{
                result = true;
                // }


                Thread.Sleep(3000);
                //driverobj.Close();
                //Thread.Sleep(3000);
                //driverobj.SwitchTo().Window(originalHandle);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        internal bool? Click_ViewDetailGeneralCourseCompleted()
        {
            throw new NotImplementedException();
        }

        public bool Check_CreditBlock()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lbl_creditblock);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool IsColSpaceDetailPage()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.ClassName("portlet"));

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        internal bool? EnrollClassroomCourse(IWebDriver driver)
        {
            throw new NotImplementedException();
        }

        public bool Click_JoinColSpace()
        {
            bool result = false;

            try
            {
                if (driverobj.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")))
                {
                    driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")).ClickWithSpace();
                    Thread.Sleep(10000);
                    driverobj.SelectFrame(By.Id("CFFrame"));
                    driverobj.WaitForElement(By.XPath("//a[@class='btn btn_app']"));
                    driverobj.SwitchTo().DefaultContent();
                    result = true;

                }
                else
                {
                    driverobj.GetElement(By.Id("ctl00_ctl00_ctl00_ContentPlaceHolder1_MainBodyPlaceHolder1_SpaceDetail1_hypJoinSpace")).ClickWithSpace();
                    Thread.Sleep(10000);
                    driverobj.SelectFrame(By.Id("CFFrame"));
                    driverobj.WaitForElement(By.XPath("//a[@class='btn btn_app']"));
                    driverobj.SwitchTo().DefaultContent();
                //    result = true;
                    driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")).ClickWithSpace();
                    Thread.Sleep(10000);
                    driverobj.SelectFrame(By.Id("CFFrame"));
                    driverobj.WaitForElement(By.XPath("//a[@class='btn btn_app']"));
                    driverobj.SwitchTo().DefaultContent();
                    result = true;
               //     result = true;
                }
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_LeaveColSpace()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_leavecolspace);
                driverobj.GetElement(btn_leavecolspace).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public string Click_AccessColSpace()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_Accesscolspace);
                result = driverobj.GetElement(By.ClassName("portlet")).Text;
                driverobj.GetElement(btn_Accesscolspace).ClickWithSpace();


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_MarkCompleteColSpace()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock']")).ClickWithSpace();
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driverobj.WaitForElement(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.SwitchTo().DefaultContent();
                //driverobj.Navigate_to_TrainingHome();
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchCurrentCompletedAttempt']"));
                result = true;



            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }


        public bool Check_ContentHeading(string contenttitle)
        {
            bool result = false;

            try
            {
                if (driverobj.existsElement(By.XPath("//h1[contains(.,'" + contenttitle + "')]")))
                    result = true;
                else
                    result = false;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }
        string format = "M/d/yyyy";
        public bool Click_SubmitRequest()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_submitrequest);
                driverobj.GetElement(btn_submitrequest).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(txt_requestreason); ;
                driverobj.GetElement(txt_requestreason).SendKeysWithSpace("Test Reason");

                driverobj.GetElement(txt_requestreceivedate).SendKeysWithSpace(DateTime.Now.ToString(format));
              //  driverobj.GetElement(rb_tutionrembursment).ClickWithSpace();
                driverobj.ClickEleJs(rb_tutionrembursment);
                driverobj.GetElement(btn_submitrequestframe).ClickWithSpace();

                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//ExtractDataExcel.MasterDic_EL["Title"]+browserstr
                result = true;

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_OpenDocumet()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_opendocument);
                driverobj.GetElement(btn_opendocument).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.SelectWindowClose1();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_MarkCompleteDocument()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_markcompletedocument);
                driverobj.GetElement(btn_markcompletedocument).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(btn_markcompletedocumentframe);
                driverobj.GetElement(btn_markcompletedocumentframe).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }


        public bool Click_ViewDetailDocumentCompleted()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_viewdetailcompleted);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(lnk_viewdetailcompleted).ClickWithSpace();
                driverobj.selectWindow("Details");
                Thread.Sleep(4000);
                //driverobj.WaitForElement(lbl_mainheading);
                //if (!driverobj.GetElement(lbl_mainheading).Text.Contains(searchtext))
                //{
                result = true;
                // }


                Thread.Sleep(3000);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Check_AddToCart()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addtocart);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_AddToCart()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addtocart);
                driverobj.GetElement(btn_addtocart).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_AddToCart_Accesskey()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addtocart_accesskey);
                driverobj.GetElement(btn_addtocart_accesskey).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_AddToCart_Accesskey_Classroomcourse()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addtocart_accesskey_classroom);
                driverobj.GetElement(btn_addtocart_accesskey_classroom).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_AddToCart_Physical_Content()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addtocart_physicalcontent);
                driverobj.GetElement(btn_addtocart_physicalcontent).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }
        public bool Click_EnrollCurriculam()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_enroll_curriculam);
                driverobj.GetElement(btn_enroll_curriculam).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool Click_AccessCurriculam()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_access_curriculam);
                driverobj.GetElement(btn_access_curriculam).ClickWithSpace();
                Thread.Sleep(5000);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public string enrollscormcourse()
        {
            string result = string.Empty;

            try
            {
                driverobj.WaitForElement(btn_enroll_scrom);
                driverobj.GetElement(btn_enroll_scrom).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();.
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(btn_enrollscrommodal);
                driverobj.GetElement(btn_enrollscrommodal).ClickWithSpace();
                driverobj.WaitForElement(btn_openitem);
                result = driverobj.GetElement(btn_openitem).GetAttribute("value");

            }
            catch (Exception ex)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                Console.WriteLine(ex.Message);

            }
            return result;
        }




        public bool scheduleReport()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(MyReportschedulereport);
                driverobj.ClickEleJs(MyReportschedulereport);
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(MyReportselectreport);
                string format = "MM/dd/yyyy";
                IWebElement element = driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Report_strContentType_0"));

                IJavaScriptExecutor executor = (IJavaScriptExecutor)driverobj;

                executor.ExecuteScript("arguments[0].click();", element);
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Report_strContentType_0")).ClickChkBox();
                driverobj.GetElement(MyReportstartdatefixcheck).Click();
                driverobj.GetElement(MyReportselectstartdate).SendKeys(DateTime.Now.ToString(format));
                driverobj.GetElement(MyReportrunschedulereport).ClickWithSpace();
                driverobj.WaitForElement(MyReportreporttitle);
                driverobj.GetElement(MyReportreporttitle).Clear();
                string newreporttitle = "test_" + DateTime.Now.ToString();
                driverobj.GetElement(MyReportreporttitle).SendKeysWithSpace(newreporttitle);

                nameofschedule = driverobj.GetElement(MyReportreporttitle).GetAttribute("value");
                driverobj.GetElement(MyReportreportdiscription).Clear();
                driverobj.GetElement(MyReportreportdiscription).SendKeysWithSpace("this is a test");
                driverobj.GetElement(MyReportrecurranceenddate).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
                driverobj.GetElement(MyReportrecurrancestartdate).SendKeysWithSpace(DateTime.Now.ToString(format));

                driverobj.GetElement(MyReportrecurancetime).SendKeysWithSpace("03:30 PM");
                driverobj.GetElement(MyReportrecurrancetype).ClickWithSpace();
                driverobj.GetElement(MyReportrecurranceenddate).ClickWithSpace();

                driverobj.GetElement(MyReportrecurrancenext).ClickWithSpace();
                driverobj.WaitForElement(MyReportrecurrancenext);
                driverobj.GetElement(MyReportrecurrancenext).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//input[@id='ML.BASE.BTN.Next']"));
                driverobj.GetElement(By.XPath("//input[@id='ML.BASE.BTN.Next']")).ClickWithSpace();
                driverobj.WaitForElement(createbutton);
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.BUTTON.UserSearch"));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.DATAGRID.UserSearchResults_ctl03_ML.BASE.USR.Administrator_MKSI.LMS.Id.SystemEmail.Recipient.DeliveryType.To"));
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.DATAGRID.UserSearchResults_ctl03_ML.BASE.USR.Administrator_MKSI.LMS.Id.SystemEmail.Recipient.DeliveryType.To"));
                driverobj.WaitForElement(By.XPath("//tr[3]/td[2]/span/input"));
                driverobj.ClickEleJs((By.XPath("//tr[3]/td[2]/span/input")));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.BUTTON.ExternalRecipientAdd"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_EditBox_ExternalRecipient")).SendKeysWithSpace("testdemo@meridianks.com");
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_External_DeliveryType_0"));
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.BUTTON.ExternalRecipientAdd"));

                driverobj.GetElement(createbutton).ClickWithSpace();
                Thread.Sleep(4000);
                driverobj.WaitForElement(By.XPath("//td[contains(text(),'" + newreporttitle + "')]"));
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;

        }



        public string deleteschedule()
        {
            string actualresult = string.Empty;
            try
            {

                driverobj.WaitForElement(chk_currentreport);
              //  driverobj.GetElement(chk_currentreport).ClickWithSpace();
                driverobj.ClickEleJs(chk_currentreport);
                driverobj.WaitForElement(btn_firstrun);
                driverobj.WaitForElement(MyReportbtndeletetask);
                ReadOnlyCollection<IWebElement> deleteicons = driverobj.FindElements(MyReportbtndeletetask);
                deleteicons[deleteicons.Count - 1].ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult.Replace("item(s)", "item");
        }

        public string suspendschedule()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(chk_currentreport);
              //  driverobj.GetElement(chk_currentreport).ClickWithSpace();
                driverobj.ClickEleJs(chk_currentreport);
                driverobj.WaitForElement(btn_firstrun);
                driverobj.WaitForElement(MyReportbtnsuspendtask);
                ReadOnlyCollection<IWebElement> suspendicons = driverobj.FindElements(MyReportbtnsuspendtask);
                suspendicons[suspendicons.Count - 1].ClickWithSpace();
                Thread.Sleep(8000);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(sucessmessage);
                actualresult = driverobj.GetElement(sucessmessage).Text;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public string clickrunicon()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(chk_currentreport);
              //  driverobj.GetElement(chk_currentreport).ClickWithSpace();
                driverobj.ClickEleJs(chk_currentreport);
                driverobj.WaitForElement(btn_firstrun);
                driverobj.WaitForElement(MyReportschedulereport);
                Thread.Sleep(10000);
                ReadOnlyCollection<IWebElement> runicons = driverobj.FindElements(runreporticon);
                runicons[runicons.Count - 1].ClickAnchor();
                driverobj.findandacceptalert();
                new WebDriverWait(driverobj, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists(sucessmessage));
                Thread.Sleep(4000);
                actualresult = driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;

        }

        public bool verify_submitAssignmentButtonNotPresent(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_returnClassroomDetailsPage);
                driver.ElementNotPresent(btn_submitAssignmentDetailsPage);
                


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool verify_submitAssignmentButtonPresent(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_returnClassroomDetailsPage);
                driver.WaitForElement(btn_submitAssignmentDetailsPage);



                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public List<string> return_assignmentDetails(IWebDriver driver)
        {
            List<string> actualresult = new List<string>(4);

            try
            {
                driver.WaitForElement(lbl_assignmenttitle);
                actualresult.Add(driver.GetElement(lbl_assignmenttitle).Text);
                actualresult.Add(driver.GetElement(lbl_assignmentpoints).Text);
                actualresult.Add(driver.GetElement(lbl_assignmentduedate).Text);
                actualresult.Add(driver.GetElement(lbl_assignmentstatus).Text);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return actualresult;
        }

        public bool click_infoIconForAssignment(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(img_infoIconAssignment);
                driver.GetElement(img_infoIconAssignment).ClickWithSpace();
                Thread.Sleep(2000);
                //driver.SelectFrame();
                driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driver.WaitForElement(lbl_titleInfoWindow);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public List<string> return_assignmentDetailsInfoWindow(IWebDriver driver)
        {
            List<string> actualresult = new List<string>(6);

            try
            {
                driver.WaitForElement(By.XPath("//div[@class='col-xs-12']/ul/li[1]"));
                actualresult.Add(driver.GetElement(By.XPath("//div[@class='col-xs-12']/ul/li[1]")).Text);
                actualresult.Add(driver.GetElement(By.XPath("//div[@class='col-xs-12']/ul/li[2]")).Text);
                actualresult.Add(driver.GetElement(By.XPath("//div[@class='col-xs-12']/ul/li[3]")).Text);
                actualresult.Add(driver.GetElement(By.XPath("//div[@class='col-xs-12']/ul/li[4]")).Text);
                actualresult.Add(driver.GetElement(By.XPath("//div[@class='col-xs-12']/ul/li[5]")).Text);
                actualresult.Add(driver.GetElement(By.XPath("//div[@class='col-xs-12']/ul/li[6]")).Text);
                driver.SwitchTo().DefaultContent();
                driver.GetElement(btn_closeInfoWindow).ClickWithSpace();
                


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return actualresult;
        }

        public bool click_submitAssignmentDetailsPage(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_submitAssignmentDetailsPage);
                driver.GetElement(btn_submitAssignmentDetailsPage).ClickWithSpace();
                driver.WaitForElement(btn_submitAssignment);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_submitAssignmentWithoutResponse(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_submitAssignment);
                driver.GetElement(btn_submitAssignment).ClickWithSpace();
                driver.findandacceptalert();
                driver.WaitForElement(btn_submitAssignment);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_submitAssignmentWithResponse(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_submitAssignment);
                driver.GetElement(btn_submitAssignment).ClickWithSpace();
                driver.findandacceptalert();
                driver.WaitForElement(lnk_SuccessMsg);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool populateAssignmentForm(IWebDriver driver, String assignmentResponse, String Comments)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(txt_assignmentResponse);
                driver.GetElement(txt_assignmentResponse).SendKeysWithSpace(assignmentResponse);
                driver.GetElement(txt_comments).SendKeysWithSpace(Comments);
                


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_SaveResumeLaterAssignment(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_SaveResumeLaterAssignment);
                driver.GetElement(btn_SaveResumeLaterAssignment).ClickWithSpace();
                driver.WaitForElement(btn_submitAssignmentDetailsPage);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }
        public bool Click_Openblog()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_openblog);
                driverobj.GetElement(btn_openblog).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.SelectWindowClose1();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        
        }

        public bool edit_quantity(string quantity)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_quantity);
                ((IJavaScriptExecutor)driverobj).ExecuteScript("document.getElementById('MainContent_ucContentECommerce_FormView1_txtQuantity').setAttribute('value', '" +quantity+"')");
                
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }
        private By txt_quantity = By.Id("MainContent_ucContentECommerce_FormView1_txtQuantity");
        private By btn_SaveResumeLaterAssignment = By.Id("MainContent_UC4_btnSaveResume");
        private By txt_comments = By.Id("MainContent_UC4_FormView1_txtComments");
        private By txt_assignmentResponse = By.Id("txtAssignmentResponse");
        private By btn_submitAssignment = By.Id("MainContent_UC4_btnSubmitAssignment");
        private By btn_closeInfoWindow = By.XPath("//div[@class='k-window-actions']/a");
        private By lbl_dueDateInfoWindow = By.XPath("//div[@class='portlet v1 forms']/div[17]/span");
        private By lbl_allowOnlineSubmissionInfoWindow = By.XPath("//div[@class='portlet v1 forms']/div[14]/span");
        private By lbl_gradingScaleInfoWindow = By.XPath("//div[@class='portlet v1 forms']/div[11]/span");
        private By lbl_itemWeightInfoWindow = By.XPath("//div[@class='portlet v1 forms']/div[8]/span");
        private By lbl_descInfoWindow = By.XPath("//div[@class='portlet v1 forms']/div[6]/span");
        private By lbl_titleInfoWindow = By.XPath("//div[@class='portlet v1 forms']/div[3]/span");
        private By img_infoIconAssignment = By.Id("ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00_ctl04_imgInfo");
        private By lbl_assignmenttitle = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00__0']/td[1]");
        private By lbl_assignmentpoints = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00__0']/td[2]");
        private By lbl_assignmentduedate = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00__0']/td[3]");
        private By lbl_assignmentstatus = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00__0']/td[4]");
        private By btn_submitAssignmentDetailsPage = By.Id("ctl00_MainContent_ucClassroom_ucAssignments_RadGrid1_ctl00_ctl04_hlSubmit");

        private By btn_returnClassroomDetailsPage = By.Id("MainContent_ucClassroom_ucAssignments_btnReturn");

        private By runreporticon = By.XPath("//a[contains(@id, '_btnRunTask')]");
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");


        private By lnk_manage = By.XPath("//a[contains(.,'Manage')]");
        private By lnk_locktest = By.XPath("//a[contains(.,'Lock Test')]");
        private By lnk_scorm2004 = By.XPath("//a[contains(.,'Publish SCORM 2004')]");
        private By lnk_scorm1_2 = By.XPath("//a[contains(.,'Publish SCORM 1.2')]");
        private By lnk_copy = By.XPath("//a[contains(.,'Copy')]");
        private By lnk_requiredtraining = By.XPath("//a[contains(.,'Required Training')]");
        private By lnk_deletecontent = By.XPath("//a[contains(.,'Delete Content')]");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");
        private By lbl_success_old = By.Id("ReturnFeedback");
      
        private By btn_enrollgencourse = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
        private By btn_opengencourse = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        private By btn_cancleenrollgencourse = By.Id("MainContent_ucPrimaryActions_FormView1_CancelEnrollment");
        private By btn_markcompletegencourse = By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock");
        private By btn_markcompletegencourseframe = By.Id("MainContent_UC1_btnMarkComplete");
        private By lnk_viewdetailcompleted = By.XPath("//a[contains(.,'Item Details')]");
        private By lbl_creditblock = By.Id("MainContent_ucContentMetaData_FormView1_MLabel7");


        private By btn_opendocument = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        private By btn_markcompletedocument = By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock");
        private By btn_markcompletedocumentframe = By.Id("MainContent_UC1_btnMarkComplete");


        private By btn_joincolspace = By.Id("MainContent_ucPrimaryActions_FormView1_JoinCSBlockFlag");
        private By btn_leavecolspace = By.Id("MainContent_ucPrimaryActions_FormView1_LeaveCS");
        private By btn_Accesscolspace = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        private By lbl_contentTitle = By.XPath("//h2[@class='col-8 content-title']");


        private By btn_submitrequest = By.Id("MainContent_ucPrimaryActions_FormView1_SubmitRequestBlock");
        private By txt_requestreason = By.Id("MainContent_UC1_fvSubmitRequest_ELR_REASON");
        private By txt_requestreceivedate = By.Id("ctl00_MainContent_UC1_fvSubmitRequest_ELR_OBTAINED_DATE_dateInput");
        private By btn_submitrequestframe = By.Id("MainContent_UC1_SubmitRequest");
        private By rb_tutionrembursment = By.Id("MainContent_UC1_fvSubmitRequest_ELR_TUITION_REIMBURSEMENT_1");

        private By detailssectioninfo = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/img");



        private By btn_AccessItemCertification = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag");
        private By btn_Enroll = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCurriculumButtonFlag");
        private By btn_AccessItemCurriculum = By.Id("MainContent_ucPrimaryActions_FormView1_CurriculumLaunchAttempt");
        private By lnk_SelectedSurvey = By.Id("lnkDetails");
        private By lnk_SuccessMsg = By.XPath("//div[@class='alert alert-success']");
        private By btn_EnrollCC = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnEnroll");
        private By btn_addtocart = By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonFlag");
        private By btn_addtocart_accesskey = By.Id("MainContent_ucContentECommerce_FormView1_btnAddAccessKeyToCart");
        private By btn_addtocart_physicalcontent = By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonProductFlag");

        private By btn_enroll_curriculam = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCurriculumButtonFlag");
        private By btn_access_curriculam = By.Id("MainContent_ucPrimaryActions_FormView1_CurriculumLaunchAttempt");

        private By btn_enrollscrommodal = By.Id("MainContent_UC1_btnCourseEnroll");
        private By btn_launchcertificate = By.Id("MainContent_ucPrimaryActions_FormView1_CertificateBlock");
        private By btn_openitem = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        private By btn_enroll_scrom = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");


        public static By MyReportschedulereport = By.Id("MainContent_ucPrimaryActions_FormView1_ScheduleReport");
        public static By MyReportselectreport = By.Id("TabMenu_ML_BASE_TAB_Report_strContentType_0");
        public static By MyReportstartdatefixcheck = By.Id("TabMenu_ML_BASE_TAB_Report_strFixedDate");
        public static By MyReportselectstartdate = By.Id("TabMenu_ML_BASE_TAB_Report_strFixedStartDate||DATEPICKER_dateInput");

        public static By MyReportrunschedulereport = By.Id("TabMenu_ML_BASE_TAB_Report_RunReport");
        public static By MyReportreporttitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_TITLE");
        public static By MyReportreportdiscription = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_DESCRIPTION");
        public static By MyReportrecurrancestartdate = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_START_DATE||DATEPICKER_dateInput");
        public static By MyReportrecurancetime = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_START_DATE||TIMEPICKER_dateInput");//"TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_START_DATE||TIMEPICKER_dateInput_text";

        public static By MyReportrecurranceenddate = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_RECURRENCE_END_DATE||DATEPICKER_dateInput");
        public static By MyReportrecurrancetype = By.CssSelector("option[value=\"ML.BASE.DV.RecurrenceType.Type2WorkDays\"]");
        public static By MyReportrecurrancenext = By.Id("ML.BASE.BTN.Next");
        public static By MyReportscheduleuserlastname = By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_USR_FIRST_NAME");
        public static By MyReportscheduleusersearch = By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.BUTTON.UserSearch");
       
        public static By MyReportscheduleusersearchlist = By.XPath("//table[@id='TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.DATAGRID.UserSearchResults']/tbody/tr[2]/td/span/input");

        public static By MyReportbtndeletetask = By.XPath("//a[contains(@id, '_btnDeleteTask')]");

        public static By MyReportbtnsuspendtask = By.XPath("//a[contains(@id, '_btnSuspendTask')]");


        public static string nameofschedule = string.Empty;
        private By createbutton = By.Id("ML.BASE.BTN.Create");
        private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");
        private By chk_currentreport = By.Id("MainContent_ucScheduledReport_cbShowCurrentTasks");
        private By btn_firstrun = By.Id("ctl00_MainContent_ucScheduledReport_mgScheduledReports_ctl00_ctl04_btnRunTask");

        private By btn_openblog = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        private By btn_markcompleteblog = By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock");
        private By btn_markcompleteblogframe = By.Id("MainContent_UC1_btnMarkComplete");

        private By btn_addtocart_accesskey_classroom = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_addcart");
    } 
}
