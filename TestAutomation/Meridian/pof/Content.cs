using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using System.Threading;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
   public class Content
    {
        private readonly IWebDriver driverobj;

        public Content(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool MyResponsiblities_click()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);
                driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
                //  driverobj.GetElement(ObjectRepository.myResponsibilities);
                if (driverobj.existsElement(ObjectRepository.searchHome))
                {
                    return true;
                }
                else if (!driverobj.existsElement(ObjectRepository.searchHome))
                {
                    driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
                    driverobj.WaitForElement(ObjectRepository.searchHome);
                }
                else
                {
                    driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
                    driverobj.WaitForElement(ObjectRepository.searchHome);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }
        public bool CostAndSalesTaxEdit_Click()
        {
            try
            {
                driverobj.WaitForElement(Content_CostAndSalesTaxEdit_Button);
                // checkpoint on creating bundle/course
                driverobj.GetElement(Content_CostAndSalesTaxEdit_Button).ClickWithSpace();
                driverobj.WaitForElement(addCostToContent);
                driverobj.GetElement(addCostToContent).SendKeysWithSpace("1");
                driverobj.WaitForElement(costSaveForGeneralCourse_Button);
                driverobj.GetElement(costSaveForGeneralCourse_Button).ClickWithSpace();
                driverobj.WaitForElement(btn_ReturnToDetailPage);
                driverobj.GetElement(btn_ReturnToDetailPage).Click();
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public string SuccessMsgDisplayed() // For Certification/Bundle/Curriculum/Subscription/KSA
        {
            string text = string.Empty;
            try
            {
                driverobj.WaitForElement(Content_SuccessMsg_Link);
                text = driverobj.gettextofelement(Content_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }
            return text;
        }

        public bool ContentSearch_Click()
        {
            try
            {
                driverobj.WaitForElement(Content_ContentSearch_Link);
                driverobj.ClickEleJs(Content_ContentSearch_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        //Edit Certification/Bundle/Curriculum/Subscription
        public bool Edit_Click()
        {
            try
            {
                driverobj.WaitForElement(Content_Edit_Button);
                driverobj.GetElement(Content_Edit_Button).ClickWithSpace();

                driverobj.WaitForElement(Content_Summary_Frame);
                driverobj.SwitchTo().Frame(driverobj.FindElement(Content_Summary_Frame));

                driverobj.WaitForElement(Content_Save_Button);
                driverobj.GetElement(Content_Keywords_TextBox).SendKeys("NewKeyword");
                //  ContentDriver.FindElement(Content_CertficationCostType_OptionButton).ClickWithSpace();
                driverobj.GetElement(Content_Save_Button).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        //Delete certification/bundle/curriculum/Subscription
        public bool DeleteContent_Click()
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
                //   driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                result = "";

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool Manage_Click()
        {
            try
            {
                driverobj.WaitForElement(Content_Survey_Manage_Link);
                driverobj.ClickEleJs(Content_Survey_Manage_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool CheckIn()
        {
            try
            {
                driverobj.WaitForElement(Content_CheckIn_Button);
                driverobj.ClickEleJs(Content_CheckIn_Button);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public bool ManageSurveyInClassroom_Click()
        {
            try
            {
                driverobj.WaitForElement(Content_Survey_Manage_Link);
                driverobj.GetElement(Content_Survey_Manage_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool MyOwnLearning_Click()
        {
            try
            {
                driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        // Copy certification/bundle/curriculum/Subscription
        public bool Copy_Click()
        {
            try
            {
                driverobj.WaitForElement(Content_Copy_Button);
                driverobj.ClickEleJs(Content_Copy_Button);
                driverobj.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool Add_Objective()
        {
            try
            {
                driverobj.WaitForElement(Content_EditObjective_Button);
                driverobj.ClickEleJs(Content_EditObjective_Button);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool Add_CertificationContent()
        {
            try
            {
                driverobj.WaitForElement(Content_EditCertifContent_Button);
                driverobj.ClickEleJs(Content_EditCertifContent_Button);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool Add_ReCertification()
        {
            try
            {
                driverobj.WaitForElement(Content_EditReCertification_Button);
                driverobj.GetElement(Content_EditReCertification_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool Add_AlternateOption()
        {
            try
            {
                driverobj.WaitForElement(Content_EditAlternateOption_Button);
                driverobj.ClickEleJs(Content_EditAlternateOption_Button);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool EditBundle_Click()
        {
            try
            {
                driverobj.WaitForElement(Content_Edit_Button);
                driverobj.GetElement(Content_Edit_Button).ClickWithSpace();

                driverobj.WaitForElement(Content_Summary_Frame);
                driverobj.SwitchTo().Frame(driverobj.FindElement(Content_Summary_Frame));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;

        }

        // Curriculum
        public bool Edit_TrainingActivities()
        {
            try
            {
                driverobj.WaitForElement(Content_EditTrainingActivities_Button);
                driverobj.ClickEleJs(Content_EditTrainingActivities_Button);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        // Subscription
        public bool Edit_Content()
        {
            try
            {
                driverobj.WaitForElement(Content_EditContent_Button);
                driverobj.ClickEleJs(Content_EditContent_Button);

                driverobj.WaitForElement(Content_AddContent_Button);
                driverobj.ClickEleJs(Content_AddContent_Button);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        // Editing Competency/Goal Plan Template Structure to add KSA
        public bool EditStructure()
        {
            try
            {
                driverobj.ScrollToCoordinated("500", "500");
                driverobj.WaitForElement(Content_EditStructure_Button);
                driverobj.GetElement(Content_EditStructure_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }
        public bool Click_detail_firstitem()
        {
            try
            {
                driverobj.WaitForElement(detail_firstitem);
                driverobj.GetElement(detail_firstitem).ClickAnchor();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }
        //Create Classsroom Course Section & Event
        public bool ManageSectionTab()
        {
            try
            {
                driverobj.WaitForElement(Content_ScheduleAndManageSection_Tab);
                driverobj.GetElement(Content_ScheduleAndManageSection_Tab).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool Click_Coursedetail()
        {
            try
            {
                driverobj.WaitForElement(btn_Coursedetail);
                driverobj.GetElement(btn_Coursedetail).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public bool Click_CheckOut()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(btn_checkout);
                driverobj.ClickEleJs(btn_checkout);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_ManageCredits()
        {
            try
            {

                driverobj.WaitForElement(lnk_manage_credit);
                driverobj.ClickEleJs(lnk_manage_credit);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool Click_Close_Infoicon()
        {
            try
            {
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(By.XPath("//span[@class='k-icon k-i-close']"));
                driverobj.ClickEleJs(By.XPath("//span[@class='k-icon k-i-close']"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public bool Verify_MultipleCredits()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//strong[contains(.,'5')]"));
                actualresult = driverobj.existsElement(By.XPath("//strong[contains(.,'2')]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public string Collect_MultipleCredits()
        {
            string collection = string.Empty;
            try
            {
                string part1 = driverobj.GetElement(lbl_firstcredit).Text.Trim();
                string part2 = driverobj.GetElement(lbl_secondcredit).Text.Trim();
                collection = part1 + ", " + part2;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return collection;
        }


        public bool Click_Curriculam_InfoIcon(string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(btn_curriculamInfo);
                driverobj.ClickEleJs(btn_curriculamInfo);
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                driverobj.WaitForElement(tab_Categories);
                driverobj.WaitForElement(tab_Content_Associations);
                driverobj.WaitForElement(tab_Domain_Sharing);
                driverobj.WaitForElement(tab_Permissions);
                driverobj.WaitForElement(tab_Prerequisites);
                driverobj.WaitForElement(tab_Status);
                driverobj.WaitForElement(tab_Training_Activities);
                driverobj.ClickEleJs(tab_Training_Activities);
                driverobj.WaitForElement(By.XPath("//h4[contains(.,'" + Variables.curriculumblockTitle+browserstr + "tactivity" + "')]"));
                actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "')]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

       
        public bool Click_TrainingActivityBC(string TrainingActivity)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + TrainingActivity + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + TrainingActivity + "')]")).ClickWithSpace();
               actualresult = driverobj.existsElement(By.XPath("//h1[contains(.,'" + TrainingActivity + "')]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool selectcategory(string category)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(lnk_editcategory);
             //   driverobj.GetElement(lnk_editcategory).ClickAnchor();
                driverobj.ClickEleJs(lnk_editcategory);
                Thread.Sleep(4000);
                //IWebElement check = driverobj.GetElement(By.XPath("//span[contains(text(),'" + category + "')]/preceding-sibling::input[@class='rtChk']"));
                //check.ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//span[contains(text(),'" + category + "')]/preceding-sibling::input[@class='rtChk']"));
                //check.SendKeys(Keys.Space);
                driverobj.GetElement(By.Id("MainContent_MainContent_ucCategories_btnSave")).ClickWithSpace();
                //driverobj.SwitchTo().DefaultContent();
                actualresult = driverobj.existsElement(By.CssSelector("div[class*='alert-success']"));

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                
            }
            return actualresult;
        }
        public bool Click_EditCompetency()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_editcompetency);
                driverobj.GetElement(btn_editcompetency).ClickWithSpace();
                actualresult = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Click_CheckIn()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(btn_CheckinNew);
                driverobj.ClickEleJs(btn_CheckinNew);
                actualresult = driverobj.existsElement(btn_CheckinNew);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                
            }
            return actualresult;
        }
        public bool EnableAccessKeysAndEdit_Button()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(accessKeys_Edit_Button);
                driverobj.GetElement(accessKeys_Edit_Button).ClickWithSpace();
                driverobj.WaitForElement(enableAccessKeys_Radio_Button);
                driverobj.GetElement(enableAccessKeys_Radio_Button).Click();
                driverobj.WaitForElement(saveAccessKeysEnable_Button);
                driverobj.GetElement(saveAccessKeysEnable_Button).ClickWithSpace();
                actualresult = true;
                

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool EnableAccessKeysAndAddRedemption()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(accessKeys_Edit_Button);
                driverobj.GetElement(accessKeys_Edit_Button).ClickWithSpace();
                driverobj.WaitForElement(enableAccessKeys_Radio_Button);
                driverobj.GetElement(enableAccessKeys_Radio_Button).Click();
                driverobj.GetElement(redemptionPeriodTextBox).SendKeys("30");
                driverobj.GetElement(contentAccessTextBox).SendKeys("2");
                //driverobj.GetElement(enableEmail).Click();
                driverobj.WaitForElement(saveAccessKeysEnable_Button);
                driverobj.GetElement(saveAccessKeysEnable_Button).ClickWithSpace();
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool AddCostToGeneralCourse()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(Content_CostAndSalesTaxEdit_Button);
                // checkpoint on creating bundle/course
                driverobj.GetElement(Content_CostAndSalesTaxEdit_Button).ClickWithSpace();
                driverobj.WaitForElement(addCostToContent);
                driverobj.GetElement(addCostToContent).Clear();
                driverobj.GetElement(addCostToContent).SendKeysWithSpace("50");
                driverobj.GetElement(costSaveForGeneralCourse_Button).ClickWithSpace();
                driverobj.WaitForElement(btn_ReturnToDetailPage);
                driverobj.GetElement(btn_ReturnToDetailPage).ClickWithSpace();
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool addLocale(String locale)
        {
            By chk_locale = By.XPath("//span[label[text()='"+locale+"']]/input");
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_addLocale);
                driverobj.GetElement(btn_addLocale).ClickWithSpace();
                driverobj.WaitForElement(chk_locale);
                driverobj.GetElement(chk_locale).ClickWithSpace();
                driverobj.WaitForElement(btn_SaveLocale);
                driverobj.GetElement(btn_SaveLocale).ClickWithSpace();
                driverobj.WaitForElement(Content_SuccessMsg_Link);
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Edit_localeTitle(String locale)
        {
            try
            {
                driverobj.WaitForElement(Content_Edit_Button);
                driverobj.ClickEleJs(Content_Edit_Button);
                driverobj.WaitForElement(txt_contentTitle);
                driverobj.GetElement(txt_contentTitle).Clear();
                driverobj.GetElement(txt_contentTitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + locale);
                driverobj.WaitForElement(btn_SaveLocale);
                driverobj.ClickEleJs(btn_SaveLocale);
                driverobj.WaitForElement(Content_SuccessMsg_Link);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        //private By txt_contentTitle = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE");
        private By txt_contentTitle = By.Id("CNTLCL_TITLE");
        private By btn_SaveLocale = By.Id("MainContent_MainContent_UC1_Save");
        private By btn_addLocale = By.Id("MainContent_ctl00_btnAddLocale");
        private By redemptionPeriodTextBox = By.CssSelector("input[id*='_CNT_REDEMPTION_PERIOD']");
        private By contentAccessTextBox = By.CssSelector("input[id*='_CNT_ACCESS_CODE_PERIOD']");
        private By enableEmail = By.CssSelector("input[id*='_CNT_ENABLE_ACC_EMAIL_FOR_OWNER_0']']");
        private By Content_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        private By Content_CostAndSalesTaxEdit_Button = By.Id("MainContent_MainContent_ucCost_lnkEdit");
        private By Content_ContentSearch_Link = By.XPath("//a[contains(.,'Content Search')]");
        private By Content_Edit_Button = By.Id("MainContent_MainContent_ucSummary_lnkEdit");
        private By Content_Summary_Frame = By.ClassName("k-content-frame");
        private By Content_Keywords_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        private By Content_CertficationCostType_OptionButton = By.Id("MainContent_UC1_FormView1_fvCertificate_CERT_COST_TYPE_1");
        private By Content_Save_Button = By.Id("MainContent_UC1_Save");
        private By Content_DeleteContent_Button = By.Id("MainContent_header_FormView1_btnDelete");
        private By Content_Survey_Manage_Link = By.Id("MainContent_MainContent_UC4_hlManage");
        private By Content_CheckIn_Button = By.Id("MainContent_header_FormView1_btnStatus");
        private By Content_MyOwnLearning_Link = By.Id("lbUserView");
        private By Content_Copy_Button = By.Id("MainContent_header_FormView1_btnCopy");
        private By Content_EditObjective_Button = By.Id("MainContent_MainContent_ucObjectives_lnkEdit");
        private By Content_EditCertifContent_Button = By.Id("MainContent_MainContent_ucCertficateContents_lnkEdit");
        private By Content_EditReCertification_Button = By.Id("MainContent_MainContent_ucReCertification_accReCertification_lnkEdit");
        private By Content_EditAlternateOption_Button = By.Id("MainContent_MainContent_ucAlternateOptions_lnkEdit");
        private By Content_MyResponsiblities_Link = By.Id("lbMyResponsibilities");
        private By Content_EditTrainingActivities_Button = By.Id("MainContent_MainContent_ucTrainingActivity_lnkEdit");
        private By Content_EditContent_Button = By.Id("MainContent_MainContent_ucContent_MlinkEdit");
        private By Content_AddContent_Button = By.Id("MainContent_MainContent_UC1_mlinkAddContent");
        private By Content_EditStructure_Button = By.Id("MainContent_MainContent_ucStructure_accStructure_lbEdit");
        private By detail_firstitem = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
        private By Content_ScheduleAndManageSection_Tab = By.Id("MainContent_hlScheduling");
        private By btn_checkout = By.XPath("//input[@value='Checkout']");
        private By btn_CloseInfoiconwindow = By.XPath("//a[@class='k-window-action k-link k-state-hover']");
        private By lnk_manage_credit = By.Id("MainContent_MainContent_UC5_hlManage");
        private By accessKeys_Edit_Button = By.XPath("//a[contains(@id,'MainContent_MainContent_ucAccessCodes_lnkEdit')]");
        private By enableAccessKeys_Radio_Button = By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_ENABLE_ACCESS_CODE_0']");
        private By saveAccessKeysEnable_Button = By.XPath("//input[@value='Save']");
        private By addCostToContent = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost");
        private By costSaveForGeneralCourse_Button = By.XPath("//input[@value='Save']");
        private By btn_ReturnToDetailPage = By.XPath("//input[@value='Back']");

        private By lbl_firstcredit = By.XPath("//div[@class='col-md-4 panel-group']/div/ul/li[contains(.,'5')]");
        private By lbl_secondcredit = By.XPath("//div[@class='col-md-4 panel-group']/div/ul/li[2][contains(.,'2')]");

        private By btn_curriculamInfo = By.XPath("//span[contains(.,'More Information')]");
        private By tab_Training_Activities = By.XPath("//a[contains(.,'Training Activities')]");
        private By tab_Categories = By.XPath("//a[contains(.,'Categories')]");
        private By tab_Status = By.XPath("//a[contains(.,'Status')]");
        private By tab_Permissions = By.XPath("//a[contains(.,'Permissions')]");
        private By tab_Domain_Sharing = By.XPath("//a[contains(.,'Domain Sharing')]");
        private By tab_Prerequisites = By.XPath("//a[contains(.,'Prerequisites')]");
        private By tab_Content_Associations = By.XPath("//a[contains(.,'Content Associations')]");
        private By lbl_sucess = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_editcompetency = By.Id("MainContent_MainContent_ucAllignedComptency_lnkEdit");
        private By btn_CheckinNew = By.Id("MainContent_header_FormView1_btnStatus");
        
        private By lnk_editcategory = By.Id("MainContent_MainContent_ucCategories_lnkEdit");
        private By btn_Coursedetail = By.Id("MainContent_MainContent_ucTopBar_btnMoreDetails");
    }
}
