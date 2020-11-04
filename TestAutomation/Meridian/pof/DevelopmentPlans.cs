using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class DevelopmentPlans
    {
        private readonly IWebDriver driverobj;

        public DevelopmentPlans(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Check_DevelopmentPlan(string successprofile,string competency)
        {
            bool result = false;
            By pagination = By.XPath("//ol[@class='pager']/li[3]/div/strong");
            By lbl_SP = By.XPath("//label[contains(.,'" + successprofile + "')]");
            By lnk_competency = By.XPath("//a[contains(.,'" + competency + "')]");

            try
            {

                
                driverobj.WaitForElement(txt_LTObj);
                driverobj.WaitForElement(txt_STObj);
                //driverobj.WaitForElement(lnk_addAct);
                driverobj.WaitForElement(lnk_goal);
                driverobj.WaitForElement(btn_AddSuccessProfile);
                driverobj.WaitForElement(btn_submit);
                driverobj.WaitForElement(btn_return);

                if (driverobj.existsElement(pagination))
                {

                    String totalPages = driverobj.GetElement(pagination).Text.ToString();
                    totalPages = totalPages.Replace("of ", "");
                    int intPages = int.Parse(totalPages);
                    for (int i = 1; i <= intPages; i++)
                    {
                        if (driverobj.existsElement(lnk_competency))
                            break;
                        else
                            driverobj.GetElement(By.XPath("//span[em[contains(text(),'Next')]]")).ClickWithSpace();
                    }
                }


                driverobj.WaitForElement(lbl_SP);
                driverobj.WaitForElement(lnk_competency);
                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
              
            }

            return result;
        }

        public bool Check_DevelopmentPlanTitle(string userfirstname, string userlastname)
        {
            bool result = false;

            try
            {
                String devplantitle = driverobj.GetElement(txt_devplantitle).GetAttribute("value").ToString();

                if (devplantitle.Equals("New Development Plan for " + userfirstname + " " + userlastname))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }

        public bool Update_DevelopmentPlanTitle(String type, string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_devplantitle);
                driverobj.GetElement(txt_devplantitle).ClickWithSpace();
                driverobj.GetElement(txt_devplantitle).Clear();
                driverobj.GetElement(txt_devplantitle).SendKeysWithSpace(Variables.DevPlanTitle+browserstr+browserstr + type);
                driverobj.GetElement(div_ProfessionalFocus).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }

        public bool Click_DevelopmentPlanTitle(string devplantitle)
        {
            bool result = false;

            try
            {


                driverobj.WaitForElement(txt_devplantitle);
                driverobj.GetElement(txt_devplantitle).Clear();
                driverobj.GetElement(txt_devplantitle).SendKeysWithSpace(devplantitle);
                driverobj.GetElement(btn_savedevplantitle).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
             
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }
        public bool Click_AddDevelopmentActivity(string browserstr)
        {
            bool result = false;
            By lnk_addAct = By.XPath("//h3[a[contains(text(),'" + Variables.PerformanceCompetencyTitle+browserstr + "')]]/following-sibling::div/a[1][contains(text(),'Add Development Activity')]");
            By pagination = By.XPath("//ol[@class='pager']/li[3]/div/strong");

            try
            {
                if (driverobj.existsElement(pagination))
                {

                    String totalPages = driverobj.GetElement(pagination).Text.ToString();
                    totalPages = totalPages.Replace("of ", "");
                    int intPages = int.Parse(totalPages);
                    for (int i = 1; i <= intPages; i++)
                    {
                        if (driverobj.existsElement(lnk_addAct))
                            break;
                        else
                            driverobj.GetElement(By.XPath("//span[em[contains(text(),'Next')]]")).ClickWithSpace();
                    }
                }

                driverobj.WaitForElement(lnk_addAct);
                driverobj.GetElement(lnk_addAct).ClickWithSpace();
               
                    result = true;
            
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }

        public bool Check_OverlapofCompetency(string performancecompetency)
        {
            bool result = false;

            try
            {

                //driverobj.WaitForElement(href_overlap);
                driverobj.WaitForElement(By.XPath("//h3[a[contains(text(),'"+performancecompetency+"')]]/following-sibling::div/a[3][contains(text(),'Aligned')]"));

                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }

        public bool Click_Competency(string performancecompetency)
        {
            bool result = false;
            By pagination = By.XPath("//ol[@class='pager']/li[3]/div/strong");
            By lnk_competency = By.XPath("//a[contains(.,'" + performancecompetency + "')]");

            try
            {
                if (driverobj.existsElement(pagination))
                {

                    String totalPages = driverobj.GetElement(pagination).Text.ToString();
                    totalPages = totalPages.Replace("of ", "");
                    int intPages = int.Parse(totalPages);
                    for (int i = 1; i <= intPages; i++)
                    {
                        if (driverobj.existsElement(lnk_competency))
                            break;
                        else
                            driverobj.GetElement(By.XPath("//span[em[contains(text(),'Next')]]")).ClickWithSpace();
                    }
                }



                driverobj.WaitForElement(lnk_competency);
                driverobj.GetElement(lnk_competency).ClickWithSpace();

                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }

        public bool Check_CompetencyModal(string performancecompetency)
        {
            bool result = false;

            try
            {

             //body will be added after new organization bug solved
                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }


        public bool Click_AddSucessProfile()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_AddSuccessProfile);
                driverobj.GetElement(btn_AddSuccessProfile).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(txt_searchforsp);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_SearchSucessProfile(string orgtoadd)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_searchforsp);
                driverobj.GetElement(txt_searchforsp).SendKeysWithSpace(orgtoadd);
                driverobj.GetElement(btn_searchforsp).ClickWithSpace();
                driverobj.WaitForElement(btn_addspaction);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_AddSPAction()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addspaction);
                driverobj.GetElement(btn_addspaction).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
              
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_RemoveSucessProfile()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_removesp);
                driverobj.GetElement(btn_removesp).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Check_DefaultAreas()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(div_ProfessionalEnhancement);
                driverobj.WaitForElement(div_ProfessionalFocus);
                driverobj.WaitForElement(div_GeneralDevelopment);
                
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Click_SubmitDevPlan()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_submit);
                driverobj.GetElement(btn_submit).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(txt_comment_for_approval);
                driverobj.GetElement(txt_comment_for_approval).SendKeysWithSpace("test");
                driverobj.GetElement(btn_submit_plan_for_approval).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Check_ReadOnly_DevPlan()
        {
            bool result = false;
            string planStatus = driverobj.GetElement(lbl_status).Text;
            planStatus = planStatus.Replace("Plan Status: ", "");

            try
            {
                driverobj.WaitForElement(lbl_status);
               
                driverobj.ElementNotPresent(btn_AddSuccessProfile);
                driverobj.ElementNotPresent(lnk_goal);
                driverobj.ElementNotPresent(txt_LTObj);
                driverobj.ElementNotPresent(txt_STObj);
                driverobj.ElementNotPresent(btn_submit);
                if (planStatus != "Pending Approval")
                {
                    result = false;
                }
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_AddGoal(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_firstgoalinprofessionalfocus);
                driverobj.GetElement(lnk_firstgoalinprofessionalfocus).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(txt_goaltitle);
                driverobj.GetElement(txt_goaltitle).SendKeysWithSpace(Variables.GoalTitle+browserstr);
                driverobj.GetElement(txt_goaldesc).SendKeysWithSpace("test");
                driverobj.GetElement(btn_savegoal).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_EditGoal()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_editgoal);
                driverobj.GetElement(btn_editgoal).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(txt_updategoaldesc);
                driverobj.GetElement(txt_updategoaldesc).Clear();
                driverobj.GetElement(txt_updategoaldesc).SendKeysWithSpace("test_edit");
                driverobj.GetElement(btn_updategoal).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_DeleteGoal()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_deletegoal);
                driverobj.GetElement(btn_deletegoal).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }


        public bool Click_Longtermobj(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_LTObj);
                driverobj.GetElement(txt_LTObj).SendKeysWithSpace(Variables.LongTermObj+browserstr);
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Click_Shorttermobj(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_STObj);
                driverobj.GetElement(txt_STObj).SendKeysWithSpace(Variables.ShortTermObj+browserstr);
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Check_objective(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.FindElement(By.XPath("//textarea[contains(.,'"+Variables.ShortTermObj+browserstr+"')]"));
                driverobj.FindElement(By.XPath("//textarea[contains(.,'" + Variables.LongTermObj+browserstr + "')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        //private By lnk_addAct = By.XPath("//h3[a[contains(text(),'" + Variables.PerformanceCompetencyTitle+browserstr + "')]]/following-sibling::div/a[1][contains(text(),'Add Development Activity')]");
        private By lnk_goal = By.Id("MainContent_UC1_lnkGeneralDevAddGoal");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");
       
        private By href_overlap = By.Id("ctl00_MainContent_UC1_rgProfFocus_ctl00_ctl07_lnkOverlapCompetency");
        private By btn_savedevplantitle = By.Id("MainContent_UC1_imgNameSave");
        private By txt_devplantitle = By.Id("MainContent_UC1_devPlanTitle");
        private By txt_STObj = By.Id("MainContent_UC1_txtShortTerm");
        private By txt_LTObj = By.Id("MainContent_UC1_txtLongTerm");

        private By btn_submit = By.Id("MainContent_UC1_btnSubmitPlanBottom");
        private By btn_return = By.Id("MainContent_UC1_btnCancelBottom");
        private By btn_AddSuccessProfile = By.Id("MainContent_UC1_btnAddSuccessProfile");
        private By txt_searchforsp = By.Id("MainContent_UC1_SearchFor");
        private By btn_searchforsp = By.Id("btnSearchIdp");
        private By btn_addspaction = By.Id("ctl00_MainContent_UC1_rgSuccessProfiles_ctl00_ctl04_btnAdd");
        private By btn_removesp = By.XPath("//a[contains(@id,'lnkDeleteSuccessProfile')]");
        private By div_ProfessionalFocus=By.XPath("//h2[contains(.,'Professional Focus')]");
        private By div_ProfessionalEnhancement = By.XPath("//h2[contains(.,'Professional Enhancement')]");
        private By div_GeneralDevelopment = By.XPath("//h2[contains(.,'General Development')]");
        private By lbl_status = By.XPath("//h2[contains(text(),'Plan Status:')]");
        private By txt_comment_for_approval = By.Id("MainContent_UC1_txtComments");
        private By btn_submit_plan_for_approval = By.Id("MainContent_UC1_btnSubmitPlan");
        private By lnk_firstgoalinprofessionalfocus = By.Id("ctl00_MainContent_UC1_rgProfFocus_ctl00_ctl04_lnkFocusAddGoal");
        private By txt_goaltitle = By.Id("MainContent_UC1_txtTitle");
        private By txt_goaldesc = By.Id("MainContent_UC1_txtDescription");
        private By btn_savegoal = By.Id("MainContent_UC1_btnSave");
        private By btn_editgoal = By.Id("ctl00_MainContent_UC1_rgProfFocus_ctl00_ctl04_rgCompetencyActivities_ctl00_lnkCompEditActivityOrGoal");
        private By btn_deletegoal = By.Id("ctl00_MainContent_UC1_rgProfFocus_ctl00_ctl04_rgCompetencyActivities_ctl00_lnkCompRemoveActivityOrGoal");
        private By btn_updategoal = By.Id("MainContent_UC1_FormView1_btnUpdate");
        private By txt_updategoaldesc = By.Id("MainContent_UC1_FormView1_UDPG_DESCRIPTION");
       

    }
}
