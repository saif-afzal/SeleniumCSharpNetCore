using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
using System.Collections.ObjectModel;
namespace Selenium2.Meridian
{
    class My_Responsibilities
    {
        private readonly IWebDriver driverobj;

        public My_Responsibilities(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool SelectProfileforAssignTraining()
        {
            try
            {
                driverobj.WaitForElement(btn_GoProfile);
                //SelectElement selProfile = new SelectElement(driver.GetElement(Locator_RequiredTraining.RequiredTraining_SelectProfile_Dropdown));
                //selProfile.SelectByValue("ML.BASE.ACT.AssignTrainingWithoutDeadline");
                driverobj.FindSelectElementnew(ddl_SelectProfile, "Assign Training Without Deadline");
                driverobj.GetElement(btn_GoProfile).Click();

                driverobj.WaitForElement(btn_assign_Search);
                driverobj.GetElement(txt_user_for_assign_trainig_search).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(btn_assign_Search).Click();

                driverobj.WaitForElement(btn_AssignTraining);
               // driverobj.GetElement(chk_Title).Click();
                driverobj.ClickEleJs(chk_Title);
                driverobj.GetElement(btn_AssignTraining).Click();
            }
            catch(Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Select Profile for Assigning Training", driverobj);
                return false;
            }
            return true;
        }

        public string RequiredTrainingAssigned()
        {
            try
            {
                driverobj.WaitForElement(lnk_SuccessMsg);
                return driverobj.gettextofelement(lnk_SuccessMsg);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }
        }

        public bool SearchProfile()
        {
            try
            {

                driverobj.WaitForElement(btn_required_search);
                driverobj.GetElement(txt_user_for_required_trainig_search).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(btn_required_search).Click();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool VerifyTrainingdates()
        {
            try
            {


                driverobj.WaitForElement(By.XPath("//td[contains(.,'User, RegAdmin')]"));
                string currentdatetime = DateTime.Now.ToString("M/dd/yyyy");
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + currentdatetime + "')]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool SearchAssignUser()
        {
            try
            {


                driverobj.WaitForElement(By.XPath("//td[contains(.,'User, RegAdmin')]"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool AssignExtension()
        {
            try
            {


                driverobj.WaitForElement(cmb_extension_exemption_Revome);
                driverobj.FindSelectElementnew(cmb_extension_exemption_Revome, "Apply Extension");
                driverobj.GetElement(btn_Apply_Remove_ExtensionGo).ClickWithSpace();
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btn_Apply_Remove_ExtensionGo).ClickWithSpace();
                driverobj.selectWindow("Apply Extension");
                Thread.Sleep(4000);
                driverobj.WaitForElement(txt_extensionDays);
                driverobj.GetElement(txt_extensionDays).SendKeys("2");
                driverobj.GetElement(txt_extensionReason).SendKeys("Test");
                driverobj.GetElement(btn_applyextension).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'2')]"));


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool RemoveExtension()
        {
            try
            {


                driverobj.WaitForElement(cmb_extension_exemption_Revome);
                driverobj.FindSelectElementnew(cmb_extension_exemption_Revome, "Remove Extension");
                driverobj.GetElement(btn_Apply_Remove_ExtensionGo).ClickWithSpace();
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btn_Apply_Remove_ExtensionGo).ClickWithSpace();
                driverobj.selectWindow("Remove Extension");
                Thread.Sleep(4000);
                driverobj.WaitForElement(btn_removeextension);
                driverobj.GetElement(btn_removeextension).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);



            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool Click_People()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);
              //  driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Manage')]"), By.XPath(".//*[@id='manage_menu_group-dropdown']/li[2]/a"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.ClickEleJs(By.XPath("//a[@href='/admin/manageusers/usersimplesearch.aspx']"));//  driverobj.GetElement(ObjectRepository.myResponsibilities);




                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }
        public bool Click_Traning()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(tab_traning);
                driverobj.GetElement(tab_traning).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }

        public bool Click_ECommerce()
        {
            bool result = false;
            try
            {
                driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/Admin/ManagePricingSchedule.aspx']"));

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }
        public bool Click_Notifications()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(tab_notifications);
                driverobj.GetElement(tab_notifications).ClickAnchor();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;

        }
        public bool Click_ProfessionalDevelopment()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(tab_ProfDev);
                driverobj.GetElement(tab_ProfDev).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_tab(string label)
        {
            try
            {
                switch (label)
                {

                    case "Content Management":
                        {
                            driverobj.WaitForElement(tab_ContentManagement);
                            driverobj.GetElement(tab_ContentManagement).ClickWithSpace();
                            break;

                        }
                    case "Approval Requests":
                        {
                            driverobj.WaitForElement(tab_ApprovalRequests);
                            driverobj.GetElement(tab_ApprovalRequests).ClickWithSpace();
                            break;

                        }
                    case "Instructor Tools":
                        {
                            driverobj.WaitForElement(tab_InstructorTools);
                            driverobj.GetElement(tab_InstructorTools).ClickWithSpace();
                            break;


                        }
                    case "SF-182":
                        {
                            driverobj.WaitForElement(tab_SF_182);
                            driverobj.GetElement(tab_SF_182).ClickWithSpace();
                            break;

                        }
                    case "People":
                        {
                            driverobj.WaitForElement(tab_people);
                            driverobj.GetElement(tab_people).ClickWithSpace();
                            break;

                        }
                    case "Professional Development":
                        {
                            driverobj.WaitForElement(tab_ProfDev);
                            driverobj.GetElement(tab_ProfDev).ClickWithSpace();
                            break;

                        }
                    default:
                        {
                            driverobj.WaitForElement(tab_Home);
                            driverobj.GetElement(tab_Home).ClickWithSpace();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public bool Click_ManageEnrollmentForOnlineCourses()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_MngEnrlmntForOnlineCourses);
                driverobj.GetElement(lnk_MngEnrlmntForOnlineCourses).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_ManageEnrollmentForClassroomCourses()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_MngEnrlmntForClassroom);
                driverobj.GetElement(lnk_MngEnrlmntForClassroom).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Verify_ProfessionalDevelopment_NotPresent()
        {
            bool result = false;
            try
            {
                driverobj.ElementNotPresent(tab_ProfDev);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Verify_ProfessionalDevelopment_Present()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(tab_ProfDev);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_accessKeys()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_accessKeys);
                driverobj.GetElement(lnk_accessKeys).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        
        private By lnk_accessKeys = By.XPath("//a[text()='Access Keys']");
        private By lnk_MngEnrlmntForClassroom = By.XPath("//a[contains(text(),'Manage Enrollment for Classroom Courses')]");
        private By lnk_MngEnrlmntForOnlineCourses = By.XPath("//a[contains(text(),'Manage Enrollment for Online Courses')]");
        private By ddl_SelectProfile = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining");
        private By btn_GoProfile = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu");
        private By btn_assign_Search = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search");
        private By chk_Title = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_ML.BASE.USR.Administrator_P_");
        private By btn_AssignTraining = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining");
        private By lnk_SuccessMsg = By.Id("ReturnFeedback");
        private By txt_user_for_assign_trainig_search = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole");
        private By txt_user_for_required_trainig_search = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_SearchFor");
        private By btn_required_search = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.BTN.Search");
        private By cmb_extension_exemption_Revome = By.XPath("//img[contains(@id,'TabMenu_ML_BASE_TAB_RequiredTraining_ActionsMenu_2_ASSIGNED_PROFILE_2_0_')]");
        private By btn_Apply_Remove_ExtensionGo = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ASSIGNED_ENTITY_GoButton_2");
        private By txt_extensionDays = By.Id("EXTENSION_TIME");
        private By txt_extensionReason = By.Id("EXTENSION_REASON");
        private By btn_applyextension = By.Id("ML.BASE.GENERIC.ApplyExtension");
        private By btn_removeextension = By.Id("ML.BASE.GENERIC.RemoveExtension");
        private By tab_people = By.XPath("//a[contains(.,'People')]");
        private By tab_traning = By.XPath("//a[contains(.,'Training')]");
        private By tab_ecommerce = By.XPath("//a[contains(.,'Ecommerce')]");
        private By tab_notifications = By.XPath("//a[contains(.,'Notifications')]");
        private By tab_ProfDev = By.XPath("//a[contains(.,'Professional Development')]");
        private By tab_Myresponsibilites = By.Id("NavigationStrip1_lbMyResponsibilities");
        private By tab_ApprovalRequests = By.XPath("//a[contains(.,'Approval Requests')]");
        private By tab_InstructorTools = By.XPath("//a[contains(.,'Instructor Tools')]");
        private By tab_SF_182 = By.XPath("//a[contains(.,'SF-182')]");
        private By tab_Home = By.XPath("//a[text()='Home']");
        private By tab_ContentManagement = By.XPath("//span[contains(.,'Content Management')]");

        /// <summary>
        // Methods for Access Keys POF below this point
        /// </summary>

        public bool enroll_in_accessKey_course(String courseName)
        {
            bool result = false;
            By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='"+courseName+"']]]]/td[4]/div/button");
            By action_Enroll = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/ul/li/a[text()='Enroll']");
            try
            {
                driverobj.WaitForElement(btn_actionDropDown);
                driverobj.GetElement(btn_actionDropDown).ClickWithSpace();
                driverobj.WaitForElement(action_Enroll);
                driverobj.GetElement(action_Enroll).ClickWithSpace();
                driverobj.WaitForElement(sucessAlert);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool transfer_accessKeys_to_another_user(String courseName)
        {
            bool result = false;
            By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/button");
            By action_Transfer = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/ul/li/a[text()='Transfer']");
            try
            {
                driverobj.WaitForElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgManageAccess_ctl00__0']/td[4]/div/button"));
                driverobj.GetElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgManageAccess_ctl00__0']/td[4]/div/button")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgManageAccess_ctl00_ctl04_btnTransfer']"));
                driverobj.GetElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgManageAccess_ctl00_ctl04_btnTransfer']")).ClickWithSpace();
                driverobj.WaitForElement(noOfKeysToTransfer);
                driverobj.GetElement(noOfKeysToTransfer).SendKeysWithSpace("1");
                driverobj.WaitForElement(emailToTransferKeys);
                driverobj.GetElement(emailToTransferKeys).SendKeysWithSpace(courseName);               
                driverobj.GetElement(transferKeysTitle).ClickWithSpace();
                Thread.Sleep(10000);

                driverobj.GetElement(btn_transferKey).ClickWithSpace();
                driverobj.WaitForElement(sucessAlert);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool assign_accessKeys_to_another_user(String courseName)
        {
            bool result = false;
            //By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/button");
            By action_Assign = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/a[text()='Assign']");
            try
            {
                //driverobj.WaitForElement(btn_actionDropDown);
                //driverobj.GetElement(btn_actionDropDown).ClickWithSpace();
                driverobj.WaitForElement(action_Assign);
                driverobj.GetElement(action_Assign).ClickWithSpace();
                //driverobj.WaitForElement(noOfKeysToTransfer);
                //driverobj.GetElement(noOfKeysToTransfer).SendKeysWithSpace("1");
                driverobj.WaitForElement(emailToTransferKeys);
                driverobj.GetElement(emailToTransferKeys).SendKeysWithSpace("sjain@meridianks.com");
                driverobj.GetElement(transferKeysTitle).ClickWithSpace();
                Thread.Sleep(10000);

                driverobj.GetElement(btn_assignKey).ClickWithSpace();
                driverobj.WaitForElement(sucessAlert);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        internal void ValidateResponsibilityPageComplete_SharedSteps7623()
        {
            TrainingHomes traninghomes = new TrainingHomes(driverobj);
            traninghomes.MyResponsiblities_click();
            Thread.Sleep(2000);
            VerifyTranings_Responsibility();
            VerifyPeople_Responsibility();
            VerifyEcommerce_Responsibility();
            VerifyNotifications_Responsibility();
            VerifyAccessKeys_Responsibility();
        }
        internal void VerifyTranings_Responsibility()
        {
            Click_Traning();
            ValidationForManageContentSection();
            ValidationForQuickLinksSection();
            ValidationForLearnerInterestSection();
            VerifyMain_Portlet();
        }
        internal void ValidationForManageContentSection()
        {
            try
            {
                List<string> errors = new List<string>();
                IWebElement manageContentSection = driverobj.FindElement(By.XPath(".//*[@id='content']/div[2]/div[1]"));
               // string headerText = manageContentSection.GetAttribute("h2");
                List<IWebElement> allElements = manageContentSection.FindElements(By.ClassName("list-group-item")).ToList();
                if (!manageContentSection.Text.Contains("Manage Content"))
                { errors.Add("Manage Content- Header text is missing."); }
                if (!allElements[0].Text.Equals("Search & Create Content"))
                { errors.Add("Search & Create Content link is not coming in Manage Content section in Traning Tab."); }
                if (!allElements[1].Text.Equals("Manage Enrollment for Classroom Courses"))
                { errors.Add("Manage Enrollment for Classroom Courses link is not coming in Manage Content section in Traning Tab."); }
                if (!allElements[2].Text.Equals("Manage Enrollment for Online Courses"))
                { errors.Add("Manage Enrollment for Online Courses link is not coming in Manage Content section in Traning Tab."); }
                if (!allElements[3].Text.Equals("Import Skillsoft courses"))
                { errors.Add("Import Skillsoft courses link is not coming in Manage Content section in Traning Tab."); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void ValidationForQuickLinksSection()
        {
            try
            {
                List<string> errors = new List<string>();
                IWebElement manageContentSection = driverobj.FindElement(By.XPath(".//*[@id='content']/div[2]/div[2]"));
                //string headerText = manageContentSection.GetAttribute("h2");
                List<IWebElement> allElements = manageContentSection.FindElements(By.ClassName("list-group-item")).ToList();
                if (!manageContentSection.Text.Contains("Quick Links"))
                { errors.Add("Quick Links- Header text is missing."); }
                if (!allElements[0].Text.Equals("Approval Requests"))
                { errors.Add("Approval Requests link is not coming in Quick Links section in Traning Tab."); }
                if (!allElements[1].Text.Equals("Instructor Tools"))
                { errors.Add("Instructor Tools for Classroom Courses link is not coming in Quick Links section in Traning Tab."); }
                if (!allElements[2].Text.Equals("On-the-Job Training Tasks"))
                { errors.Add("On-the-Job Training Tasks link is not coming in Quick Links section in Traning Tab."); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void ValidationForLearnerInterestSection()
        {
            try
            {
                List<string> errors = new List<string>();
                IWebElement manageContentSection = driverobj.FindElement(By.XPath(".//*[@id='content']/div[2]/div[3]"));
                //string headerText = manageContentSection.GetAttribute("h2");
                List<IWebElement> allElements = manageContentSection.FindElements(By.ClassName("list-group-item")).ToList();
                if (!manageContentSection.Text.Contains("Learner Interest"))
                { errors.Add("Learner Interes- Header text is missing."); }
                if (!allElements[0].Text.Contains("Interest List for Training Catalog"))
                { errors.Add("Interest List for Training Catalog- link is not coming in Learner Interest section in Traning Tab."); }
                if (!allElements[1].Text.Contains("Interest List for Classroom Courses"))
                { errors.Add("Interest List for Classroom Courses -link is not coming in Learner Interest section in Traning Tab."); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void VerifyMain_Portlet()
        {
            try
            {
                List<string> errors = new List<string>();

                if (!driverobj.gettextofelement(By.XPath(".//*[@id='content']/div[1]/div[1]")).Contains("Content Created by Me"))
                { errors.Add("Content Created by Me-PORTLET is not coming on My Responsibility page"); }
                if (!driverobj.gettextofelement(By.XPath(".//*[@id='content']/div[1]/div[2]")).Contains("Most Recent Requests"))
                { errors.Add("Most Recent Requests-PORTLET is not coming on My Responsibility page"); }
                if (!driverobj.gettextofelement(By.XPath(".//*[@id='content']/div[1]/div[3]")).Contains("Instructor Tools"))
                { errors.Add("Instructor Tools-PORTLET is not coming on My Responsibility page"); }
                if (!driverobj.gettextofelement(By.XPath(".//*[@id='content']/div[1]/div[4]")).Contains("Needs Grading"))
                { errors.Add("Needs Grading-PORTLET is not coming on My Responsibility page"); }
                if (!driverobj.gettextofelement(By.XPath(".//*[@id='ctl00_ctl00_MainContent_ucEvaluationPanel']/div")).Contains("On-the-Job Training Tasks"))
                { errors.Add("On-the-Job Training Tasks -PORTLET is not coming on My Responsibility page"); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void VerifyPeople_Responsibility()
        {
            try
            {
                Click_People();

                if (!driverobj.gettextofelement(By.Id("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser")).Contains("Create an account for a new user"))
                { throw new Exception("Create an account for a new user- Button is not coming on Peaple tab page"); }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void VerifyEcommerce_Responsibility()
        {
            try
            {
                Click_ECommerce();
                Thread.Sleep(2000);
                List<string> errors = new List<string>();
                if (!driverobj.gettextofelement(By.Id("MainContent_UC1_btnAddNew")).Contains("Add New Pricing Schedule"))
                { errors.Add("Add New Pricing Schedule-button is not coming on Ecommerce tab"); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void VerifyNotifications_Responsibility()
        {
            try
            {

                Click_Notifications();
                Thread.Sleep(3000);
                List<string> errors = new List<string>();
                IWebElement LetterHeads_Section = driverobj.FindElement(By.XPath(".//*[@id='content']/div[2]/div"));
                //string headerText = LetterHeads_Section.GetAttribute("h2");
                List<IWebElement> allElements = LetterHeads_Section.FindElements(By.ClassName("list-group-item")).ToList();
                if (!LetterHeads_Section.Text.Contains("Letterheads"))
                { errors.Add("Learner Interes- Header text is missing."); }
                if (!allElements[0].Text.Contains("Create Letterhead"))
                { errors.Add("Create Letterhead- link is not coming in Learner letterhead section in notification Tab."); }
                if (!allElements[1].Text.Contains("Manage Letterheads"))
                { errors.Add("Manage Letterheads-link is not coming in Letterhead section in notification Tab."); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSendEmail_pnlSendEmailNotif")).Contains("Send Email"))
                { errors.Add("Send Email Header is not coming for notification Tab."); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void VerifyAccessKeys_Responsibility()
        {
            try
            {
                if (driverobj.existsElement(lnk_accessKeys))
                {
                    Click_accessKeys();
                    Thread.Sleep(2000);
                    if (!driverobj.gettextofelement(By.ClassName("portlet")).Contains("Access Keys"))
                    { throw new Exception("Manage Pricing Schedules Link is not coming on Access key Tab"); }
                }
            
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        public bool orders_viewDetails(String courseName)
        {
            bool result = false;
            By btn_viewDetails = By.XPath("//td[ul[li[a[text()='" + courseName + "']]]]/following-sibling::td[2]/a");
            try
            {
                driverobj.WaitForElement(btn_viewDetails);
                driverobj.GetElement(btn_viewDetails).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool verify_accessKeysOptions(String courseName)
        {
            bool result = false;
            By action_Assign = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/a[text()='Assign']");
            By action_Transfer = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/ul/li/a[text()='Transfer']");
            By action_Download = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/ul/li/a[text()='Download']");
            By action_Enroll = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/ul/li/a[text()='Enroll']");
            By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/button");

            try
            {
                driverobj.WaitForElement(action_Assign);
                driverobj.WaitForElement(btn_actionDropDown);
                driverobj.GetElement(btn_actionDropDown).ClickWithSpace();
                driverobj.WaitForElement(action_Transfer);
                driverobj.WaitForElement(action_Download);
                driverobj.WaitForElement(action_Enroll);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool download_accessKeys(String courseName)
        {
            bool result = false;
            By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/button");
            By action_Download = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/ul/li/a[text()='Download']");
            try
            {
                driverobj.WaitForElement(btn_actionDropDown);
                driverobj.GetElement(btn_actionDropDown).ClickWithSpace();
                driverobj.WaitForElement(action_Download);
                driverobj.GetElement(action_Download).ClickWithSpace();
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driverobj.WaitForElement(noOfKeysToDownload);
                driverobj.GetElement(noOfKeysToDownload).SendKeysWithSpace("2");
                //driverobj.WaitForElement(emailToTransferKeys);
                //driverobj.GetElement(emailToTransferKeys).SendKeysWithSpace("sjain@meridianks.com");
                driverobj.GetElement(downloadKeysTitle).ClickWithSpace();
                Thread.Sleep(10000);

                string BaseWindow = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btn_downloadKey).ClickWithSpace();
                ReadOnlyCollection<string> handles = driverobj.WindowHandles;
                foreach (string handle in handles)
                {
                    if (handle != BaseWindow)
                    {
                        driverobj.SwitchTo().Window(handle);
                        break;
                    }
                }
                driverobj.Close();

                
                driverobj.SwitchTo().Window(BaseWindow);
                //driverobj.SelectWindowClose2();
                Thread.Sleep(5000);
                driverobj.WaitForElement(sucessAlert);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool verify_transferedAccessKeys(String courseName)
        {
            bool result = false;
            //By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/button");
            By btn_viewDetails = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/a");
            try
            {
                driverobj.WaitForElement(btn_viewDetails);
                driverobj.GetElement(btn_viewDetails).ClickWithSpace();
              result=  driverobj.existsElement(lbl_transferredKey);
               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool verify_downloadedAccessKeys(String courseName)
        {
            bool result = false;
            //By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/button");
            By btn_viewDetails = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/a");
            try
            {
                driverobj.WaitForElement(btn_viewDetails);
                driverobj.GetElement(btn_viewDetails).ClickWithSpace();
             result=   driverobj.existsElement(lbl_downloadedKey);
           
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool withdrawAccessKey(String courseName)
        {
            bool result = false;
            //By btn_actionDropDown = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/div/button");
            By btn_viewDetails = By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/a");
            try
            {
                driverobj.WaitForElement(btn_viewDetails);
                driverobj.GetElement(btn_viewDetails).ClickWithSpace();
                driverobj.WaitForElement(btn_viewDetails_downloadedKeys);
                driverobj.GetElement(btn_viewDetails_downloadedKeys).ClickWithSpace();
                driverobj.WaitForElement(btn_withdraw_downloadedKey);
                driverobj.GetElement(btn_withdraw_downloadedKey).ClickWithSpace();
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driverobj.WaitForElement(btn_withdraw_modal);
                driverobj.GetElement(btn_withdraw_modal).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
             result=   driverobj.existsElement(sucessAlert);

               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        internal void ValidateSearch_ScormCourse_SharedSteps_7252()
        {
            try
            {
                List<string> errors = new List<string>();
                driverobj.GetElement(By.CssSelector("a[href*='MainContent_ucSearchTop_pnlAdvanced']")).Click();
                Thread.Sleep(1000);
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_Literal2")).Contains("Search for"))
                { errors.Add("Search for section is not coming after SCORM course search from responsibility "); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_lblCategories")).Contains("Category"))
                { errors.Add("Category section is not coming in Search criteria after SCORM course search from responsibility "); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_MLabel1")).Contains("Editing Status"))
                { errors.Add("Editing Status section is not coming in Search criteria after SCORM course search from responsibility"); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_MLabel2")).Contains("Activity"))
                { errors.Add("Activity section is not coming in Search criteria after SCORM course search from responsibility "); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_MLabel6")).Contains("Content Type"))
                { errors.Add("Content Type section is not coming in Search criteria after SCORM course search from responsibility"); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_lblLanguage")).Contains("Language"))
                { errors.Add("Language section is not coming in Search criteria after SCORM course search from responsibility "); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_lblConstraint")).Contains("Limit"))
                { errors.Add("Limit section is not coming in Search criteria after SCORM course search from responsibility"); }
                if (!driverobj.gettextofelement(By.Id("MainContent_ucSearchTop_lblRating")).Contains("Rating"))
                { errors.Add("Rating section is not coming after SCORM course search from responsibility "); }
                if (!driverobj.IsElementVisible(By.Id("CreatedBy")))
                { errors.Add("Create by me - Button is not coming on SCORM course search page."); }
                if (!driverobj.IsElementVisible(By.Id("ScheduledTo")))
                { errors.Add("Courses I'm teaching - Button is not coming on SCORM course search page."); }
               
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void ValidateSearch_CourseDetails_ScormCourse_SharedSteps_7252()
        {
            try
            {
                Thread.Sleep(2000);
                List<string> errors = new List<string>();
                string summarySection = driverobj.gettextofelement(By.XPath(".//*[@id='MainContent_pnlContent']/div[2]/div[1]/div[1]"));
                if (!summarySection.Contains("Summary"))
                { errors.Add("Summary section is not coming on SCORM course search detail from responsibility "); }
                if (!summarySection.Contains("Title"))
                { errors.Add("Title filed in summary section is not coming in Search criteria after SCORM course search from responsibility "); }
                if (!summarySection.Contains("Description"))
                { errors.Add("Editing Status section is not coming in Search criteria after SCORM course search from responsibility"); }
                //if (!summarySection.Contains("Preview URL"))
                //{ errors.Add("Activity section is not coming in Search criteria after SCORM course search from responsibility "); }
                if (!summarySection.Contains("Search Priority"))
                { errors.Add("Content Type section is not coming in Search criteria after SCORM course search from responsibility"); }

                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucCourseSettings_pnlCourseSettings")))
                { errors.Add("Course Setting section is not coming after SCORM course search on detail page from responsibility "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucSCORMFiles_pnlSCORMFiles")))
                { errors.Add("Course Files section is not coming after SCORM course search on detail page from responsibility "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucCourseInfo_pnlCourseInfo")))
                { errors.Add("Course Information section is not coming after SCORM course search on detail page from responsibility  "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucCost_pnlCost")))
                { errors.Add("Cost & Sales Tax section is not coming after SCORM course search on detail page from responsibility "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucAccessPeriod_pnlAccessPeriod")))
                { errors.Add("Access Period section is not coming after SCORM course search on detail page from responsibility "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucAccessCodes_pnlAccessCodes")))
                { errors.Add("Access Keys section is not coming after SCORM course search on detail page from responsibility  "); }

                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucPrerequistes_pnlPrerequisites")))
                { errors.Add("Prerequisites section is not coming after SCORM course search on detail page from responsibility  "); }

                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucAllignedComptency_pnlAllignedComptency")))
                { errors.Add("Comptency section is not coming after SCORM course search on detail page from responsibility  "); }

                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucCertificate_pnlCertificate")))
                { errors.Add("Certificate section is not coming after SCORM course search on detail page from responsibility  "); }

                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucContentSharing_pnlContentSharing")))
                { errors.Add("ContentSharing section is not coming after SCORM course search on detail page from responsibility  "); }

                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucActivity_pnlActivity")))
                { errors.Add("Manage Activity section is not coming after SCORM course search on detail page from responsibility  "); }

                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucWindow_pnlWindow")))
                { errors.Add("Window section is not coming after SCORM course search on detail page from responsibility  "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucVersion_pnlVersioning")))
                { errors.Add("Versioning section is not coming after SCORM course search on detail page from responsibility  "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_MainContent_ucMobile_pnlMobile")))
                { errors.Add("Mobile setting section is not coming after SCORM course search on detail page from responsibility  "); }
                Thread.Sleep(2000);
                if (!driverobj.IsElementVisible(By.Id("MainContent_header_FormView1_btnDelete")))
                { errors.Add("Delete button for course is not coming after SCORM course search on detail page from responsibility  "); }
                if (!driverobj.IsElementVisible(By.Id("MainContent_header_FormView1_btnStatus")))
                { errors.Add("Checkout button for course is not coming after SCORM course search on detail page from responsibility  "); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        private By lbl_assignedKey = By.XPath("//.[contains(text(),'You assigned a key to')]");
        private By lbl_transferredKey = By.XPath("//p[contains(.,'You transferred 1 key(s) to Saurabh Jain')]");
        private By lbl_downloadedKey = By.XPath("//p[contains(.,'You downloaded 2 key(s)')]");
        private By btn_viewDetails_downloadedKeys = By.XPath("//td[contains(.,'You downloaded 2 key(s)')]/following-sibling::td[2]/div/a[2]");
        private By btn_withdraw_downloadedKey = By.XPath("//div[contains(text(),'Product Key:')]/following-sibling::div[2]/a");
        private By btn_withdraw_modal = By.Id("MainContent_UC1_Save");
        private By sucessAlert = By.CssSelector("div[class*='alert-success']");
        private By noOfKeysToTransfer = By.Id("txtCount1");
        private By noOfKeysToDownload = By.Id("MainContent_UC1_txtGenerateAccessCode");
        private By emailToTransferKeys = By.Id("MainContent_UC1_txtEmail1");
        private By btn_transferKey = By.Id("MainContent_UC1_btnTransfer");
        private By btn_assignKey = By.Id("MainContent_UC1_btnAssign");
        private By btn_downloadKey = By.Id("MainContent_UC1_btnDownload");
        private By transferKeysTitle = By.XPath("//div[@id='divAssignTokens']/h1");
        private By downloadKeysTitle = By.XPath("//div[@class='col-xs-12']/h2");


        
    }



}
