using OpenQA.Selenium;
using Selenium2.Meridian;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using TestAutomation.helper;
//using  Selenium2.Meridian.ClassroomCourse;



namespace Selenium2.Meridian.Suite
{
    public class ContentDetailsPage:ObjectInit
    {
        private IWebDriver objDriver;
        public ContentDetailsPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }

        public  bool isViewCoreCertificationButtonDisplayed()
        {
            return objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_ViewCoreCert"));
        }
        public  bool? isCertificationInfoPageDisplayed()
        {
            bool res = false;
            int cnt =objDriver.WindowHandles.Count;
            if (cnt > 1)
            {
               objDriver.selectWindow();
            }
            res = objDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Summary_FIELD:CERT_TITLE")).Text == "testcert_0709";
            return res;
        }
        //public  IWebDriver  { get; set; }
        public  AssignmentWorkCommand AssignmentWork { get { return new AssignmentWorkCommand(objDriver); } }

        public  CourseMaterialsCommand CourseMaterials { get { return new CourseMaterialsCommand(objDriver); } }

        public  RecertificationCriteriaPortletCommand RecertificationCriteriaPortlet
        {
            get { return new RecertificationCriteriaPortletCommand(objDriver); }
        }

        public  CertificationPortletCommand CertificationPortlet
        {
            get { return new CertificationPortletCommand(objDriver); }
        }

        public  ObjectivesCommand ObjectivesPorlet
        {
            get { return new ObjectivesCommand(objDriver); }
        }

        public  CompletionCriteraiPortletCommand CompletionCriteraiPortlet
        {
            get { return new CompletionCriteraiPortletCommand(objDriver); }
        }

        public  AccordianCommand Accordians { get { return new AccordianCommand(objDriver); } }

        public  DocumentCommand Document
        {
            get { return new DocumentCommand(objDriver); }
        }

        public  CurriculumBlockCommand CurriculumBlock { get { return new CurriculumBlockCommand(objDriver); } }

        public  AccessApprovalModalCommand AccessApprovalModal
        {
            get { return new AccessApprovalModalCommand(objDriver); }
        }

        public  SCROMCommand SCROM { get { return new SCROMCommand(objDriver); } }

        public  ScheduledCourseCommand ScheduledCourse { get { return new ScheduledCourseCommand(objDriver); } }

        public  MorelikethisCommand MorelikeThis
        {
            get { return new MorelikethisCommand(objDriver); }
        }


        public  ExpandedScheduledCourseCommand ExpandedScheduledCourse { get { return new ExpandedScheduledCourseCommand(objDriver); } }


        public SummaryCommand Summary
        {
            get { return new SummaryCommand(objDriver); }
        }


        public  PromotionalVideoCommand PromotionalVideo
        {
            get
            {
                return new PromotionalVideoCommand(objDriver);


            }
        }


        public  ExpressInterestCommand ExpressInterest { get { return new ExpressInterestCommand(objDriver); } }

        public  SurveyPortletCommand SurveyPortlet { get { return new SurveyPortletCommand(objDriver); } }

        public  bool? isHistorywindowopened()
        {
           objDriver.selectWindow("History");
           
            return objDriver.GetElement(By.XPath("//h1[contains(text(),'History')]")).Displayed;
        }

        public  void Click_editContentSharing()
        {
            objDriver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
        }

        //public  SurveysCommand Surveys { get { return new SurveysCommand(objDriver); } }

        //public  EquivalenciesCommand Equivalencies { get { return new EquivalenciesCommand(objDriver); } }


        public  CourseTabCommand CourseTab { get { return new CourseTabCommand(objDriver); } }


        public  CurriculumBlocksCommand CurriculumBlocks { get { return new CurriculumBlocksCommand(objDriver); } }

        public  void closeSurveywindow(string v)
        {
            Thread.Sleep(20000);
            objDriver.focusParentWindow();
        }

        public  OpenItemComand OpenItem { get { return new OpenItemComand(objDriver); } }

        //public  OpenNewAttemptCommand OpenNewAttempt { get { return new OpenNewAttemptCommand(objDriver); } }

        public  OnTheJobTrainingActivitiesCommand OnTheJobTrainingActivities { get { return new OnTheJobTrainingActivitiesCommand(objDriver); } }

        public  ContentItemsPortletCommand ContentItemsPortlet { get { return new ContentItemsPortletCommand(objDriver); } }

        public  void clickReturningUserLogin()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='login']"));
        }

        //public  ContentTitleCommand ContentTitle { get { return new ContentTitleCommand(objDriver); } }

        public  MoreLikeThisSectionCommand MoreLikeThisSection { get { return new MoreLikeThisSectionCommand(objDriver); } }

        public  MarkCompleteModalCommand MarkCompleteModal { get { return new MarkCompleteModalCommand(objDriver); } }

        public  CertificationContentCommand CertificationContent { get { return new CertificationContentCommand(objDriver); } }

        public  object CurriculumEnrollment { get; set; }
        public  InformationCommand Information { get { return new InformationCommand(objDriver); } }

        public  object DropdownToggle { get; set; }
        public  CategoriesAccordianCommand CategoriesAccordian { get { return new CategoriesAccordianCommand(objDriver); } }

       

        public  CreditTypeAccordianCommand CreditTypeAccordian { get { return new CreditTypeAccordianCommand(objDriver); } }

        public  CourseProviderAccodianCommand CourseProviderAccodian { get { return new CourseProviderAccodianCommand(objDriver); } }

        public  MorelikethisPortletCommand MorelikethisPortlet { get { return new MorelikethisPortletCommand(objDriver); } }

        public  CurriculumContentTabCommand CurriculumContentTab { get { return new CurriculumContentTabCommand(objDriver); } }

        public  HistoryTabCommand HistoryTab { get { return new HistoryTabCommand(objDriver); } }

        public  bool? isreviewTabdisdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Reviews')]"));
        }

        public  ViewAllAttemptsModalCommand ViewAllAttemptsModal { get { return new ViewAllAttemptsModalCommand(objDriver); } }

        public  CourseInformationPortletCommand CourseInformationPortlet { get { return new CourseInformationPortletCommand(objDriver); } }

        public  Contenttabcommand ContentTab { get { return new Contenttabcommand(objDriver); } }

        public  ContentBannerCommand ContentBanner { get { return new ContentBannerCommand(objDriver); } }

        public  bool? overviewTabdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Overview')]"));
        }

        public  GeneralCourse_ReviewsTabCommand GeneralCourse_ReviewsTab { get { return new GeneralCourse_ReviewsTabCommand(objDriver); } }

        public  OverviewTabCommnad OverviewTab { get { return new OverviewTabCommnad(objDriver); } }

        public  ClickAddtoCartPortletCommand ClickAddtoCartPortlet { get { return new ClickAddtoCartPortletCommand(objDriver); } }

        public  ScheduleTabContentPageCommand ScheduleTab { get { return new ScheduleTabContentPageCommand(objDriver); } }

        public  ReviewsTabCommand ReviewsTab { get { return new ReviewsTabCommand(objDriver); } }

        public  HistoryTabCommand Historytab { get { return new HistoryTabCommand(objDriver); } }

        public  Bundle_ReviewsTab_Command Bundle_ReviewsTab
        {
            get { return new Bundle_ReviewsTab_Command(objDriver); }
        }

        //public  PrerequisitesCommand Prerequisiteportlet { get { return new PrerequisitesCommand(objDriver); } }

        public  Historywin Historywin { get { return new Historywin(objDriver); } }

        public  void ClickOnAddtoCartButtonOfSection()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4'][contains(text(),'Add to Cart')]"));
        }

        public  void ClickEnrollButton()
        {
            objDriver.ClickEleJs(By.XPath("//*[@id='enroll-prompt']/a"));
        }

        public  void ClickEditContent()
        {
            if (objDriver.existsElement(By.Id("MainContent_ucEditContent_FormView1_btnEditContent")))
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucEditContent_FormView1_btnEditContent"));
            }
            else
            {
                objDriver.ClickEleJs(By.XPath("//*[@id='contentDiv']/a[2]"));

            }
        }

        public  bool? ContentDetailsPageOpened()
        {

            Thread.Sleep(5000);
            if (objDriver.Url.Contains("contentdetails.aspx"))
            {
                return true;
            }
            else
                return false;

        }

        public  bool? isContentTabdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@id='content-details-content-tab-link']"));
        }

        public  void ClickBrowserBackButton()
        {
            Thread.Sleep(5000);
           objDriver.Navigate().Back();
        }

        public  void Click_ReviewTab_GeneralCourse()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'Reviews')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Reviews')]"));
        }

        public  void EnrollinGeneralCourse_new()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Enroll')]"));
            Thread.Sleep(5000);
        }

        public  void Click_EditCourseInformation()
        {
            objDriver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseInfo_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseInfo_lnkEdit']"));
        }

     

        public  void Click_Survey(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
        }

        public  string certificationProgress()
        {
            objDriver.existsElement(By.XPath("//div[@id='MainContent_ucContentStatus_FormView1_pnlCurriculaumProgress']"));
            return objDriver.GetElement(By.XPath("//div[@id='MainContent_ucContentStatus_FormView1_pnlCurriculaumProgress']")).Text;
        }

        public  bool CheckAssignmentPanel()
        {
            return objDriver.existsElement(By.XPath("/html/body/form/div[7]/div/div[2]/div/div[2]/div[1]/div[3]/div/div[1]/div/div[1]/h3"));
        }

        public  bool? isScoreUpdated()
        {
            throw new NotImplementedException();
        }

        public  void ClickAccessItemButton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag"));
            //MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag
        }

        public  bool? isScheduleTabdisplay()
        {
            return objDriver.existsElement(By.LinkText("Schedule"));
        }

        public  bool? isProgressDisplayed(string v)
        {
            return objDriver.GetElement(By.Id("MainContent_ucContentStatus_FormView1_pnlCurriculaumProgress")).Text.StartsWith(v);

        }

        public  bool? isURLisSEOFriendly(string v)
        {
            return objDriver.Url.EndsWith(v);
        }

        public  void ClickAddCurriculumBlock()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_MLinkButton1']"));
        }

        public  void ClickFindQualifyingContentButton()
        {
            if (objDriver.existsElement(By.Id("MainContent_ucCertification_FormView1_lnRecertSearchCatalog")))
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucCertification_FormView1_lnRecertSearchCatalog"));
            }
            else
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_ucCertification_FormView1_lnkCertSearchCatalog']"));
            }
        }

        public  void EnrolGeneralCourse()
        {
            if (objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton")))
            { objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton")); }
            //else
            //{
            //    objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt"));
            //}
        }

        public  void LaunchGenralCourse()
        {
            if (objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")) || objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt")))
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt"));
                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("Google", Meridian_Common.parentwdw);
                objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock"));
            }
        }



        public  string getEnrollmentSuccessMessage()
        {
            objDriver.existsElement(By.XPath("//div[@class='alert alert-success']"));
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public  bool? isEditContent_New19_2display()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Edit Content')]"));

        }

        public  void OpenItemGeneral()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));

            Thread.Sleep(5000);

           objDriver.SelectWindowClose();
        }

        public  string getMarkCompleteSuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//p[contains(text(),'You must complete any associated surveys before yo')]")).Text;
        }

        //public  bool? isEditContent_New19_2display()
        //{
        //    return objDriver.existsElement(By.XPath("//a[contains(text(),'Edit Content')]"));
        //}

        public  void MarkComplete()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock']"));

            objDriver.waitforframe();
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnMarkComplete']"));


        }

        public  bool? IsRestartCurriculumDisplayed()
        {
            return objDriver.existsElement(By.XPath("//a[@id='newAttempt']"));
        }

        public  bool? isHistoryTabDisplay_GeneralCourse()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'History')]"));
        }

        public  string getre_MarkCompleteSuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public  void ClickRetakeCurriculum_DissmissAlert()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='newAttempt']"));
            objDriver.ClickEleJs(By.XPath("//div[@id='confirmNewAttempt']/div/div/div[3]/button"));
            //objDriver.findanddismissalert();
        }

        public  void ClickRetakeCurriculum_AcceptAlert()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='newAttempt']"));
            objDriver.ClickEleJs(By.XPath("//div[@id='confirmNewAttempt']/div/div/div[3]/button[2]"));
            //objDriver.findandacceptalert();
        }


        public  void ClickEnroll()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton']"));
            //MainContent_ucPrimaryActions_FormView1_EnrollButton
        }

        public  void MarkCompleteGeneralCourse()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock"));
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnMarkComplete"));
           objDriver.SwitchTo().DefaultContent();
        }

        public  bool? isGamificationPointPortletDisplay()
        {
            return objDriver.existsElement(By.XPath("//strong[contains(text(),'Completion Reward:')]"));
        }

        public  bool isStatus(string v)
        {
            return true;
            //throw new NotImplementedException();
        }

        public  bool isProgress(string v)
        {
            return objDriver.GetElement(By.Id("MainContent_ucContentStatus_FormView1_pnlCurriculaumProgress")).Text.Equals(v);
        }

        public  bool isTextDisplayed(string v)
        {
            return objDriver.existsElement(By.XPath("//*[contains(.,'" + v + "')]"));
        }

        public  void ClickReCertifybutton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_CertStartCertification"));

        }

        public  void ClickAddtoCart_GeneralCourse()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Add to Cart')]"));
        }

        public  bool? IsModalDisplayed()
        {
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return true;
        }

        public  bool? IsModalClosed()
        {
            throw new NotImplementedException();
        }

        public  bool? isbacktoPreviousPageLinkdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/p/small/a/span[2]"));
        }

        public  bool? isBradCrumbdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div/ol"));
        }

        public  bool? IsViewCertificateButtondisplay()
        {
            return objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CertificateBlock']"));
        }

        public  void CloseModal()
        {
            throw new NotImplementedException();
        }

        public  void ClickViewCoreCertificationButton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_ViewCoreCert"));
        }

        public  bool? MatchCatalogName(string v1, object tC33918, string v2)
        {
            throw new NotImplementedException();
        }

        public  void CompleteCurriculumnContent()
        {
            Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
            Thread.Sleep(10000);
           objDriver.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            Thread.Sleep(4000);
            objDriver.ClickEleJs(By.XPath("//div[@class='sm:w-64 pull-right']//span[@class='caret']"));
            objDriver.ClickEleJs(By.XPath("//ul[@class='dropdown-menu']//li//a[@href='#'][contains(text(),'Mark Complete')]"));
        }

        public  void closeTestModalwithoutComplete(string v)
        {
           objDriver.SelectWindowClose1("SCORM Debug Window");
           objDriver.SelectWindowClose1("SCORM Debug Window");
           objDriver.SwitchWindow("Meridian Global - Core Domain");
           objDriver.selectWindow("Meridian Global - Core Domain");
            Thread.Sleep(5000);
           objDriver.waitforframe(By.Id("tocFrame"));
            Thread.Sleep(5000);           
           objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
        }

        public  void CompleteTestwithFail(string v)
        {
           objDriver.SelectWindowClose1("SCORM Debug Window");
           objDriver.SelectWindowClose1("SCORM Debug Window");
           objDriver.SwitchWindow("Meridian Global - Core Domain");
           objDriver.selectWindow("Meridian Global - Core Domain");
            Thread.Sleep(5000);
           objDriver.waitforframe(By.Id("tocFrame"));
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//u[contains(.,'" + v + "')]"));
           objDriver.SwitchTo().DefaultContent();
           objDriver.waitforframe(By.Id("contentFrame"));
            objDriver.ClickEleJs(By.XPath("//input[@id='q1false']"));
            objDriver.ClickEleJs(By.Id("Submit"));
            objDriver.ClickEleJs(By.Id("Submit"));
           objDriver.SwitchTo().DefaultContent();
           objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
        }

        public  bool? MatchCatalogName(string v)
        {
            objDriver.existsElement(By.XPath("//div[@id='content']/div/h1"));
            if (objDriver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text.Equals(v))
            {
                return true;
            }
            else
                return false;
        }

        public  bool RequestAccessHistory_Curriculum()
        {
            bool result = false;
            try
            {
               objDriver.IsElementVisible(By.XPath("//a[contains(text(),'View Request History')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'View Request History')]"));
               objDriver.SwitchWindow("History");
               objDriver.IsElementVisible(By.XPath("//h1[contains(text(),'History')]"));
                Thread.Sleep(4000);
               objDriver.SelectWindowClose2("History", Meridian_Common.parentwdw);
                //Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                //Thread.Sleep(10000);
                //objDriver.SelectWindowClose2("History", Meridian_Common.parentwdw);
                //Thread.Sleep(4000);
                //objDriver.SwitchTo().ParentFrame();
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;

        }

        public  bool? VerifyQuestionInSurvey(string question, string v)
        {
            bool result = false;
            try
            {
               objDriver.selectWindow(v);
                result = objDriver.existsElement(By.XPath("//span[contains(text(),'" + question + "')]"));
               objDriver.SelectWindowClose();
               objDriver.SwitchTo().DefaultContent();
            }
            catch { }
            return result;



            
            
        }

        public  bool? isSaveShareandEditContentbuttndisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='contentDiv']"));
        }

        public  bool? VerifyInformationModal()
        {
            objDriver.waitforframe();
            return objDriver.existsElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));
        }

        public  void Click_InfoIcon()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='contentDetailsHeader']/div/h2/a/span"));
        }

        public  string getAssociatedMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[3]/div/div[2]/div/div/p")).Text;
        }

        public  bool CancelRequestAccess_Curriculum()
        {
            bool result = false;
            try
            {
               objDriver.IsElementVisible(By.XPath("//a[@class='btn btn-danger cancel-request']"));
                objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-danger cancel-request']"));
               objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
               objDriver.GetElement(By.XPath("//textarea[@name='ctl00$MainContent$UC1$fvAccessRequest$REQUEST_COMMENT']")).SendKeysWithSpace("Testing data");
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_RequestAccess']"));
                result =objDriver.IsElementVisible(By.CssSelector("div.alert.alert-dismissible.alert-fixed.alert-success"));
                // result =objDriver.IsElementVisible(By.XPath("//span[contains(text(),'Success Your request for access approval was cancelled.×')]"));
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public  bool? isRe_certifybuttondisplay()
        {
            return objDriver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CertStartCertification']")).GetAttribute("Value").Equals("Re-certify");
        }

        public  bool? isReCertificationContentportletdisplay()
        {
            return objDriver.existsElement(By.XPath("//h3[contains(text(),'Re-certification Content')]"));
        }

        public  void Click_Recertfybutton()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CertStartCertification']"));
        }

        public  void Click_ContentTab()
        {
           objDriver.IsElementVisible(By.XPath("//a[@href='#contentTab']"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#contentTab']"));
            Thread.Sleep(5000);
        }

        public  bool? IsViewCoreCertificateButtondisplay()
        {
            return objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_ViewCoreCert']"));
        }

        public  void Click_OverviewTab()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'Overview')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Overview')]"));
        }
        public  void Click_HistoryTab_Curriculum()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'History')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'History')]"));
        }

        public  bool ClickViewCertificate_Curriculum()
        {
            bool result = false;
            try
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='btn hover:text-white btn-primary']//span[@id='quick-play-text']"));
                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("Certificate", Meridian_Common.parentwdw);
                Thread.Sleep(4000);
                result =objDriver.IsElementVisible(By.XPath("//a[@class='btn hover:text-white btn-primary']//span[@id='quick-play-text']"));

            }
            catch (Exception e)
            {

            }
            return result;


        }

        public  bool? isrelatedContentMatch(string courseCategory)
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='slick-slide00']//a"));
            //objDriver.ClickEleJs(By.XPath("//div[@id='container-more-like-this']/div/div/div/div[4]/a"));
            //div[@id='container-more-like-this']/div/div/div/div[4]/a
            ClickEditContent();
            objDriver.existsElement(By.XPath("//span[@class='rtIn']"));

            String textofcat = objDriver.GetElement(By.XPath("//span[@class='rtIn']")).Text;
            if (courseCategory.Equals(textofcat))
            {
                return true;
            }
            return false;
        }

        public  bool MarkComplete_Curriculum()
        {
            bool result = false;
            try
            {
                if (objDriver.FindElement(By.XPath("//li[1]//div[1]//div[3]//div[1]//div[1]//button[1]")).Displayed)
                {
                    objDriver.ClickEleJs(By.XPath("//li[1]//div[1]//div[3]//div[1]//div[1]//button[1]"));
                }
                else
                {
                    objDriver.ClickEleJs(By.XPath("//a[@class='block color-default no-underline font-semibold']"));
                    objDriver.ClickEleJs(By.XPath("//li[1]//div[1]//div[3]//div[1]//div[1]//button[1]"));
                }

                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("Google", Meridian_Common.parentwdw);
                Thread.Sleep(4000);
                objDriver.ClickEleJs(By.XPath("//div[@class='sm:w-64 pull-right']//span[@class='caret']"));
                objDriver.ClickEleJs(By.XPath("//ul[@class='dropdown-menu']//li//a[@href='#'][contains(text(),'Mark Complete')]"));
                if (objDriver.IsElementVisible(By.XPath("//span[contains(text(),'View Certificate')]")))
                {
                    result = true;
                }
                else if (objDriver.IsElementVisible(By.XPath("//button[contains(text(),'Review')]")))
                {
                    result = true;
                }
            }
            catch (Exception e)
            {

            }
            return result;

        }

        public  bool? isCreditTyperelatedContentDisplay(int creditType)
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='slick-slide00']//a"));
            ClickEditContent();
            string credit = objDriver.GetElement(By.XPath("//li[contains(text(),'Default Credit Type:')]")).Text;
            if (objDriver.getIntegerFromString(credit).Equals(creditType))
            {
                return true;
            }
            else return false;
        }

        public  void ScheduleTab_click()
        {

            objDriver.existsElement(By.LinkText("Schedule"));
            objDriver.ClickEleJs(By.LinkText("Schedule"));

        }

        public  void Edit_AddAccessPeriod(string v)
        {
            objDriver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucAccessPeriod_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessPeriod_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_CNT_ENABLE_ACCESS_PERIOD_0']"));
            objDriver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_CNT_ACCESS_PERIOD']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_CNT_ACCESS_PERIOD']")).SendKeys(v);
            objDriver.select(By.XPath("//select[@name='ctl00$ctl00$MainContent$MainContent$UC1$CNT_ACCESS_PERIOD_TYPE']"), "Day(s)");
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));



        }

        public  bool? isSameCourseProviderrelatedContentDisplay(string courseProvider)
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='slick-slide00']//a"));
            Thread.Sleep(5000);
            ClickEditContent_New19_2();
            objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucCourseInfo_pnlCourseInfo']/ul/li[2]/strong"));
            return objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucCourseInfo_pnlCourseInfo']/ul/li[2]/strong")).Text.Contains(courseProvider);
        }

        public  bool? isCotentTabDisplay()
        {
            return objDriver.existsElement(By.XPath("//li[@class='active']//a[contains(text(),'Content')]"));
            //return objDriver.GetElement(By.XPath("//li[@class='active']//a[contains(text(),'Content')]")).GetAttribute("aria-expanded").Contains("true");
        }

        public  bool? isScheduleTabselected()
        {
            objDriver.existsElement(By.XPath("//li[@class='active']//a[contains(text(),'Schedule')]"));
            return objDriver.GetElement(By.XPath("//li[@class='active']//a[contains(text(),'Schedule')]")).GetAttribute("aria-expanded").Contains("true");
        }

        public  bool? verifyAccessPeriod(string accessPeriod)
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div/p")).Text.Equals(accessPeriod);
        }

        public  string AccessPeriod()
        {
            return objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucAccessPeriod_pnlAccessPeriod']/div/p")).Text;
        }

        public  bool? isOverViewTabSelected()
        {
            objDriver.existsElement(By.XPath("//li[@class='active']//a[contains(text(),'Overview')]"));
            return objDriver.GetElement(By.XPath("//li[@class='active']//a[contains(text(),'Overview')]")).GetAttribute("aria-expanded").Contains("true");
        }

        public  void Click_CheckOut()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public  string VerifySuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public  bool MarkComplete_Curriculum_Content()
        {
            bool result = false;
            try
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='block color-default no-underline font-semibold']"));
                objDriver.ClickEleJs(By.XPath("//li[1]//div[1]//div[3]//div[1]//div[1]//button[1]"));

                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("Google", Meridian_Common.parentwdw);
                Thread.Sleep(4000);
                objDriver.ClickEleJs(By.XPath("//div[@class='sm:w-64 pull-right']//span[@class='caret']"));
                objDriver.ClickEleJs(By.XPath("//ul[@class='dropdown-menu']//li//a[@href='#'][contains(text(),'Mark Complete')]"));
                objDriver.ClickEleJs(By.XPath("//a[@class='block color-default no-underline font-semibold']"));
                result =objDriver.IsElementVisible(By.XPath("//span[contains(text(),'Completed')]"));
            }
            catch (Exception e)
            {

            }
            return result;

        }

        public  bool? isOnlySaveandSharebuttndisplay()
        {
            return objDriver.existsElement(By.XPath("//button[@class='btn btn-default dropdown-toggle']"));
        }

        public  bool? verifyUpdatedAccessPeriod(string updatedAccessPeriod)
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div/p")).Text.Equals(updatedAccessPeriod);

        }

        public  bool? VerifyUpdatedAccessPeriod(string accessPeriod, string updatedAccessPeriod)
        {
            bool result = false;
            try
            {
                result = accessPeriod != updatedAccessPeriod;

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public  void Edit_DisableAccessPeriod()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessPeriod_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_CNT_ENABLE_ACCESS_PERIOD_1']"));
            objDriver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_CNT_ACCESS_PERIOD']")).Clear();
            objDriver.select(By.XPath("//select[@name='ctl00$ctl00$MainContent$MainContent$UC1$CNT_ACCESS_PERIOD_TYPE']"), "");
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));

        }

        public  bool? isContentTabSelected()
        {
            objDriver.existsElement(By.XPath("//a[@id='content-details-content-tab-link']"));
            return objDriver.GetElement(By.XPath("//a[@id='content-details-content-tab-link']")).GetAttribute("aria-expanded").Contains("true");
        }

        public  void click_Surveylink()
        {
            objDriver.existsElement(By.XPath("//a[@id='MainContent_hlSurvey']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_hlSurvey']"));
        }

        public  bool? VerifyViewAllAttenpts()
        {
            return objDriver.existsElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));
        }

        public  void ViewAllAttempts()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_ucContentStatus_FormView1_ViewAllAttempts']"));
        }

        public  void Click_ReviewTab_Curriculum()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Reviews')]"));
        }

        public  bool? isCertificateDisplayed()
        {
           objDriver.selectWindow("Certificate");
           objDriver.SwitchTo().Frame(1);
            return objDriver.GetElement(By.XPath("//section[@class='primary']")).Displayed;
        }

        public  void Edit_Prerequisites(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));
            if (objDriver.existsElement(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_LnkAdd']"));
            }
            else if (objDriver.existsElement(By.XPath("//a[@id='empty-prereq-add']")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='empty-prereq-add']"));
            }

            objDriver.existsElement(By.Id("searchFor"));
            objDriver.GetElement(By.Id("searchFor")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//a[@id='btn-content-search']/span"));
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//table[@id='table-prereq-add']/tbody/tr/td/input"));
            objDriver.ClickEleJs(By.Id("prereq-modal-add"));

        }

        public  bool RequestAccess_Curriculum()
        {
            bool result = false;
            try
            {
               objDriver.IsElementVisible(By.XPath("//a[contains(text(),'Request Access')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Request Access')]"));
               objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
               objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace("Testing Data");
                objDriver.ClickEleJs(By.Id("MainContent_UC1_RequestAccess"));
               objDriver.SwitchtoDefaultContent();
               objDriver.IsElementVisible(By.XPath("//a[@class='btn btn-danger cancel-request']"));
               objDriver.IsElementVisible(By.XPath("//a[contains(text(),'View Request History')]"));
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;

        }

        public  void CloseAICCModal()
        {
           objDriver.SelectWindowClose();
           objDriver.SwitchtoDefaultContent();
        }

        public  bool? isAICCCourseOpened()
        {
           objDriver.selectWindow("meridianows.skillwsa.com");

            return objDriver.Title.Equals("meridianows.skillwsa.com");
        }

        public  void click_PrerequisiteTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text()," + v + ")]"));
        }

        public  string VerifyPrerequisiteInformation()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div/p")).Text;
        }

        public  bool? VerifyCurriculum_ContentTab(string unordered, string ordered, string credit, string optional, string v)
        {
            bool result = false;
            try
            {
                //objDriver.IsElementVisible(By.XPath("//a[@href='#contentTab']"));
                //objDriver.ClickEleJs(By.XPath("//a[@href='#contentTab']"));
               objDriver.IsElementVisible(By.XPath("//a[text()='" + unordered + "']"));
               objDriver.IsElementVisible(By.XPath("//a[text()='" + ordered + "']"));
               objDriver.IsElementVisible(By.XPath("//a[text()='" + credit + "']"));
               objDriver.IsElementVisible(By.XPath("//a[text()='" + optional + "']"));
               objDriver.IsElementVisible(By.XPath("//div[@id='blockHeading1']//div[@class='col-xs-8 col-sm-3 text-left sm:mt-2'][contains(text(),'Complete 1 in any order')]"));
               objDriver.IsElementVisible(By.XPath("//div[contains(text(),'Complete all in order')]"));
               objDriver.IsElementVisible(By.XPath("//div[@id='blockHeading3']//div[@class='col-xs-8 col-sm-3 text-left sm:mt-2'][contains(text(),'Complete 2 in any order')]"));
               objDriver.IsElementVisible(By.XPath("//div[contains(text(),'Optional')]"));

                // Expand The Blocks
                objDriver.ClickEleJs(By.XPath("//a[text()='" + unordered + "']"));
                objDriver.ClickEleJs(By.XPath("//a[text()='" + ordered + "']"));
                objDriver.ClickEleJs(By.XPath("//a[text()='" + credit + "']"));
                objDriver.ClickEleJs(By.XPath("//a[text()='" + optional + "']"));
                //Verify Mouse Hover Message
                //result =objDriver.GetElement(By.XPath("//p[@id='enroll-message']")).Text.Contains("Enroll in the Curriculum to get started");
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public  bool? getCancelEnrolFeedbackMessage(string v)
        {
            return objDriver.getSuccessMessage().Contains(v);
        }

        public  void ClickCancelEnrollment_Scrom()
        {
            objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CancelEnrollment']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CancelEnrollment']"));
        }

        public  void ClickBreadCrumb(string v)
        {
            objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]"));
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v + "')]"));
           
        }

        public  void clickExit()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='content-playlist-pdf']//button[@class='btn btn-link exit-playlist'][contains(text(),'Exit')]"));
        }

        public  bool? isContentopenedinline()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content-playlist-pdf']"));
        }

        public  void ClickCancelEnrollment_Curriculum()
        {
            objDriver.ClickEleJs(By.LinkText("Cancel Enrollment"));
        }

        public  bool? verifyHistotytab()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'History')]"));
        }



        public  bool SocialSharingDropDown(string socialSite)
        {
            if (objDriver.existsElement(By.XPath("//button[contains(.,'Share')]")))
            {
                objDriver.ClickEleJs(By.XPath("//button[contains(.,'Share')]"));
                objDriver.existsElement(By.XPath("//a[contains(.," + socialSite + ")]"));
                return objDriver.existsElement(By.XPath("//button[contains(.,'Share')]"));
            }
            else return false;
        }

        public  bool? reviewsTab()
        {
            objDriver.ClickEleJs(By.XPath("//a[@aria-controls='reviewsTab']"));
            return objDriver.existsElement(By.XPath("//a[contains(.,'Write a review')]"));
        }

        public  void writeCurriculumReview(string s)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Write a review')]"));
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.XPath("//select[contains(@id,'RATING')]"));
            objDriver.ClickEleJs(By.XPath("//option[@value='4']"));
            objDriver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("Test Review");
            objDriver.GetElement(By.XPath("//textarea[contains(@id,'REVIEW')]")).SendKeysWithSpace(s);
            objDriver.ClickEleJs(By.XPath("//input[@value='Save']"));
        }

        public  bool? editclickbuttonexist()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Edit Content')]"));
        }

        public  bool? historyTab()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'History')]"));
            objDriver.existsElement(By.XPath("//li[@class='complete']"));
            objDriver.existsElement(By.XPath("//li[contains(.,'Started curriculum')]"));
            objDriver.existsElement(By.XPath("//li[contains(.,'Enrolled in curriculum')]"));
            return true;
        }



        public  void deleteCurriculumReview()
        {
            objDriver.ClickEleJs(By.XPath("//a[@aria-controls='reviewsTab']"));
            objDriver.ClickEleJs(By.XPath("//span[@class='fa fa-close']"));
            objDriver.getSuccessMessage();
            
        }

        public  void editCurriculumReview(string s)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Edit review')]"));
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.XPath("//select[contains(@id,'RATING')]"));
            objDriver.ClickEleJs(By.XPath("//option[@value='2']"));
            objDriver.GetElement(By.XPath("//input[contains(@id,'TITLE')]")).SendKeysWithSpace("Edit Review");
            objDriver.GetElement(By.XPath("//textarea[contains(@id,'REVIEW')]")).SendKeysWithSpace(s);
            objDriver.ClickEleJs(By.XPath("//input[@value='Save']"));
        }

        public  bool? IsCurriculumContentStatusDisplayed()
        {
            return objDriver.existsElement(By.XPath("//span[@class='text-muted']"));
        }

        public  bool? IsCurriculumContentDisplayed()
        {
            return objDriver.existsElement(By.XPath("//span[@class='content-title mr-2']"));
        }

        public  void ClickCurriculumContentBlock()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='blockHeading1']/div/div/h4/a"));
        }

        public  bool? IsCurriculumContentBlockDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='blockHeading1']/div/div/h4/a"));
        }

        public  void Click_Enroll()
        {
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-primary btn-lg']"));

        }

        public  bool? verifyReviewText(string reviewText)
        {
            return objDriver.existsElement(By.XPath("//p[contains(.,'" + reviewText + "')]"));
        }

        //public  void cancelEnroll_ifEnrolled()
        //{
        //    if (objDriver.existsElement(By.XPath("//a[contains(.,'Cancel Enrollment')]")))
        //    {
        //        objDriver.ClickEleJs(By.XPath("//a[@aria-controls='reviewsTab']"));
        //        Thread.Sleep(2000);
        //        //_test.Log(Status.Info, "Checking to see if existing Review by current user is listed");
        //        if (objDriver.existsElement(By.XPath("//span[@class='fa fa-close']")))
        //        {
        //        //    _test.Log(Status.Info, "Existing review found...Deleting");
        //            ContentDetailsPage.CurriculumEnrollment.deleteCurriculumReview();
        //        }
        //        ContentDetailsPage.CurriculumEnrollment.cancelCurriculumEnrollment();
        //    }
        //}

        public  bool? isCancleEnrolllinkdisplay()
        {
            return objDriver.existsElement(By.LinkText("Cancel Enrollment"));
        }

        public  bool? ViewDetail_Previously_CompletedContent()
        {
            bool result = false;
            try
            {
                objDriver.ClickEleJs(By.XPath("//span[@class='fa fa fa-angle-down text-muted margin-right-xs']"));
               objDriver.IsElementVisible(By.XPath("//div[@class='col-xs-12 mt-6']//button[2]"));
                objDriver.ClickEleJs(By.XPath("//div[@id='contentTab']//button[2]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'View Details')]"));
                result =objDriver.IsElementVisible(By.XPath("//input[@name='ctl00$MainContent$ucCurriculumDetails$FormView1$CurrLaunchAnotherNewAttempt']"));
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public  bool? Review_Previously_CompletedContent()
        {
            bool result = false;
            try
            {
                objDriver.ClickEleJs(By.XPath("//span[@class='fa fa fa-angle-down text-muted margin-right-xs']"));
               objDriver.IsElementVisible(By.XPath("//button[contains(text(),'Review')]"));
                objDriver.ClickEleJs(By.XPath("//button[contains(text(),'Review')]"));
                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("Google", Meridian_Common.parentwdw);
                Thread.Sleep(4000);
                objDriver.ClickEleJs(By.XPath("//span[@class='fa fa fa-angle-down text-muted margin-right-xs']"));
                result =objDriver.IsElementVisible(By.XPath("//div[contains(text(),'Complete 2 in any order')]"));
            }
            catch (Exception e)
            {

            }
            return result;

        }

        public  void Click_MarkComplete()
        {
            objDriver.ClickEleJs(By.Id("quick-play-text"));
        }

        public  bool VerifyCurriculumDetailPage(string v)
        {
            bool result = false;
            try
            {
                //Verify Pre-requisite Portlet
                objDriver.GetElement(By.XPath("//div[@id='prereq-alert']/p")).Text.Contains("Complete the prerequisites to access this item.");
                objDriver.GetElement(By.XPath("//a[@class='text-grey-darker']")).Text.Contains("Prerequisite");
               objDriver.IsElementVisible(By.XPath("//a[contains(text(),'Request Waiver')]"));
               objDriver.IsElementVisible(By.XPath("//li[@class='relative pl-4 mb-2']//span[@class='prerequisite-status'][contains(text(),'Not Started')]"));
                // Verify Cost Portlet
               objDriver.IsElementVisible(By.XPath("//div[contains(text(),'$2.00')]"));
                // Verify Equivalecies Portlet
                objDriver.GetElement(By.XPath("//a[@class='font-semibold text-grey-darker block']")).Text.Contains("Equivalencies");
               objDriver.IsElementVisible(By.XPath("//li[@class='relative mb-2 pl-4']//span[@class='prerequisite-status'][contains(text(),'Not Started')]"));
                // Verify all four Tabs and Save and Edit Content Buttons of curriculum
               objDriver.IsElementVisible(By.XPath("//a[contains(text(),'Overview')]"));
               objDriver.IsElementVisible(By.XPath("//a[@href='#contentTab']"));
               objDriver.IsElementVisible(By.XPath("//a[contains(text(),'History')]"));
               objDriver.IsElementVisible(By.XPath("//a[contains(text(),'Reviews')]"));
               objDriver.IsElementVisible(By.XPath("//a[@class='btn-content-details-save btn btn-default transition']"));
                //objDriver.IsElementVisible(By.XPath("//a[@class='btn btn-default mr-1']"));
                // Verify Curriculum Title on Banner
               objDriver.IsElementVisible(By.XPath("//h1[contains(text(),'" + v + "')]")); // Content Title
               objDriver.IsElementVisible(By.XPath("//p[contains(.,'Curriculum')]")); // Content Type
               objDriver.IsElementVisible(By.XPath("//div[@class='row sm:flex sm:items-center m-0']")); // Banner
               objDriver.IsElementVisible(By.XPath("//div[@class='col-xs-12 col-sm-6 col-md-9']/div[@class='mt-4 mb-8 embed-responsive embed-responsive-16by9']")); // Promotional Video Portlet
               objDriver.IsElementVisible(By.XPath("//div[@class='col-xs-12 col-sm-6 col-md-9']//div[@class='portlet shadow']")); // Description Portlet


                result = true;
            }
            catch (Exception e)
            {

            }
            return result;

        }

        public  void ClickShoppingCart()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='lnkShoppingCart']//span[@class='fa fa-shopping-cart fa-lg']"));
        }

        public  void OpenMarkComplete()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock']"));
            objDriver.waitforframe();
        }

        public  void OpenItemScorm()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));

        }

        public  void CloseMarkComplete()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnMarkComplete']"));
        }

        public  bool? IsContentCreated()
        {
            return objDriver.existsElement(By.XPath("//li/strong"));
        }

        public  bool? isCostNSalesTaxAccordiandisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucCost_pnlCost']/div/div/div/h3"));
        }

        public  string OrderReciptSuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public  void DeleteContent()
        {
            objDriver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnDelete']"));
            Thread.Sleep(2000);
           objDriver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }

        public  bool? isCertificateAccordiandisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucCertificate_pnlCertificate']/div/div/div/h3"));
        }

        public  bool? IsSubscriptionBlockDispalyed(string subscriptionContent)
        {
            return objDriver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSubscription_mgSubscription_ctl00_ctl04_lnkDetails']")).Text.Equals(subscriptionContent);
        }

        public  bool? IsTypeDisplayed()
        {
            return objDriver.existsElement(By.XPath("//table[@id='ctl00_MainContent_ucSubscription_mgSubscription_ctl00']/thead/tr/th[2]"));
        }

        public  bool? IsCurriculumContentDisplayed(string v)
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
        }

        public  bool? IsCostDisplayed()
        {
            return objDriver.existsElement(By.XPath("//table[@id='ctl00_MainContent_ucSubscription_mgSubscription_ctl00']/thead/tr/th[3]"));
        }

        public  bool? IsTitleDisplayed()
        {
            return objDriver.existsElement(By.XPath("//table[@id='ctl00_MainContent_ucSubscription_mgSubscription_ctl00']/thead/tr/th[1]"));
        }

        public  bool? isPrerequisitesAccordiandisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucPrerequistes_pnlPrerequisites']/div/div/div/h3"));
        }

        public  bool? isDefultLocaledisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_pnlContent']/div/div/div/div/p/strong"));
        }

        public  void AddLocale()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ctl00_btnAddLocale"));
            objDriver.existsElement(By.Id("MainContent_MainContent_UC1_chkLocale_0"));
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_chkLocale_0"));
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public  void ReturnToDefaultContent()
        {
           objDriver.SwitchtoDefaultContent();
        }

        public  bool? Localedropdownlistdisplay()
        {
            return objDriver.existsElement(By.Id("ddlLocalesAdded"));
        }

        public  void DeleteLocale()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ctl00_btnDeleteLocale"));

           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.existsElement(By.Id("MainContent_UC1_deleteLocale"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_deleteLocale"));
        }

        public  bool? isAccessApprovalAcordianDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucAccessApproval_pnlAccesApproval']/div/div/div/h3"));
        }

        public  string VerifyFeedbackMessage()
        {
            objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public  bool? isCategoriesAcordianDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucCategories_pnlCategories']/div/div/div/h3"));

        }

        public  bool? isImageAcordianDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucImage_pnlImage']/div/div/div/h3"));
        }

        public  void LaunchAICCCourse()
        {
            if (objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")) || objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt")))

            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt"));
                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("meridianows.skillwsa.com", Meridian_Common.parentwdw);
                //objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock"));
            }
        }

        public  bool? isEquivalenciesAccordiandisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/div/div/h3"));
        }

        public  string GetSuccessMessage()
        {
            Thread.Sleep(10000);
            string rettext = objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            return rettext.Trim();
        }

        public  bool? isManageActivityAcordianDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucActivity_pnlActivity']/div/div/div/h3"));
        }

        public  void ClickCheckInbutton()
        {
            if (objDriver.existsElement(By.XPath("//a[contains(.,'Check-in')]")))
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Check-in')]"));
        }

        public  bool? CheckCourseTitle(string v)
        {
            return objDriver.existsElement(By.XPath("//h1[contains(.,'" + v + "')]"));
        }

        public  bool? IsRateAccordianDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@class='col-md-4']//div[2]//div[1]"));
        }

        public  void ClickOpenItembutton()
        {
            if (objDriver.existsElement(By.XPath("//a[@class='btn btn-primary btn-lg']")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-primary btn-lg']"));
                if (objDriver.existsElement(By.TagName("iframe")))
                {
                   objDriver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
                }
                objDriver.ClickEleJs(By.XPath("//span[@id='quick-play-text']"));
                //objDriver.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
            }
            else
            {
                objDriver.ClickEleJs(By.XPath("//span[@id='quick-play-text']"));

            }
        }

        public  void LaunchSCORMCourse()
        {
            if (objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")) || objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt")))

            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt"));
                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("Meridian Global-Core Domain", Meridian_Common.parentwdw);
                //objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock"));
            }
        }

        public  bool? IsDeleteRatingDisplayed()
        {
            return objDriver.existsElement(By.XPath("//a[@id='MainContent_ucContentRating_FormView1_delRating']"));
        }

        public  void Rate(string v1, string v2, string v3)
        {
            objDriver.existsElement(By.XPath("(//a[contains(text(),'Rate')])[3]"));
            objDriver.ClickEleJs(By.XPath("(//a[contains(text(),'Rate')])[3]"));
            objDriver.waitforframe();
            objDriver.select(By.XPath("//select[@id='MainContent_UC1_fvRateContent_CNTRTG_RATING']"), v1);
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_fvRateContent_CNTRTG_REVIEW_TITLE']")).SendKeysWithSpace(v2);
            objDriver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_fvRateContent_CNTRTG_REVIEW']")).SendKeysWithSpace(v3);
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']"));
            //objDriver.SwitchTo().DefaultContent();


        }

        public  bool? CheckResumeButton()
        {
            return objDriver.existsElement(By.XPath("//input[@class='btn btn-primary']"));
        }

        public  bool? isContentDetailsPageEditable()
        {
            bool result = false;
            try
            {
                objDriver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div[2]/p")).Text.Equals("Under Revision");
                objDriver.GetElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit")).Text.Equals("Edit");
                objDriver.GetElement(By.Id("MainContent_header_FormView1_btnStatus")).Text.Equals("Check-in");
                return true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public  bool? CheckCourseTitleOnClickingEditButton(string v)
        {

            objDriver.ClickEleJs(By.Id("MainContent_ucEditContent_FormView1_btnEditContent"));
            return objDriver.existsElement(By.XPath("//h1[contains(.,'" + v + "')]"));
        }

        public  void Click_Check_in()
        {
            objDriver.ClickEleJs(By.Id("MainContent_header_FormView1_btnStatus"));
            Thread.Sleep(5000);
        }

        public  bool? isContentDetailsPageNonEditable()
        {
            bool result = false;
            try
            {
                objDriver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div[2]/p")).Text.Equals("Available");
                objDriver.GetElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit")).Text.Equals("View");
                objDriver.GetElement(By.Id("MainContent_header_FormView1_btnStatus")).Text.Equals("Check-out");
                return true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public  bool? isSurveyAccordiandisplayed()
        {
            return objDriver.existsElement(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']"));
        }

        public  void CompleteLunchedCourse()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CurrLaunchAnotherNewAttempt"));
            Thread.Sleep(3000);
            string wdwHandle =objDriver.CurrentWindowHandle;
            IList<string> wdwTitle =objDriver.WindowHandles;

            foreach (string dr in wdwTitle)
            {
               objDriver.SwitchTo().Window(dr);
                if (objDriver.Title == "Google")
                {
                   objDriver.Close();
                   objDriver.SwitchTo().Window(wdwHandle);

                }

            }
            objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock"));
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock"));
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnMarkComplete"));
            Thread.Sleep(2000);



        }

        public  bool? UserEnrolledtoContent()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div[2]"));
        }

        public  bool? getFeedbackMessage(string v)
        {
            return objDriver.GetElement(By.XPath("//*[@id='content']/div[2]/div")).Text.Contains(v);
        }

        public  void Click_CiewCertificate()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucAttemptDetail_FormView1_CertificateBlock"));
        }

        public  bool? VerifyCertificateisOpened()
        {
            return objDriver.focusParentWindow();
        }

        public  void ClickCurriculumContentEditButton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucTrainingActivity_lnkEdit"));
        }

        public  bool? isRequestAccessbuttonDisplay()
        {
            if (objDriver.existsElement(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4'][contains(text(),'Request Access')]")))
            {
                return true;
            }
            if (objDriver.existsElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[8]/div[2]/div[3]/div[2]/div[1]/div[1]/div[3]/a[1]")))
            {
                return true;
            }
            if (objDriver.existsElement(By.XPath("//a[@class='btn btn-primary btn-lg']")))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public  bool? isCancleRequestbuttonDisplay()
        {
            if (objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//a[@class='btn btn-danger mb-4'][contains(text(),'Cancel Request')]")))
            {
                return true;
            }
            if (objDriver.existsElement(By.XPath("//a[@class='btn btn-danger cancel-request']")))
            {
                return true;
            }
            else
                return false;
        }

        public  bool? isEnrollButtonDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4']"));
        }

        public  void LaunchDocument()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
        }

        public  void MarkCompleteDocument()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock"));
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnMarkComplete"));
        }

        public  void MarkCompleteCurriculum()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CurrMarkCompleteBlock"));
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnMarkComplete"));

        }

        public  void ClickViewDetails()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucContentStatus_FormView1_MLinkButton1"));
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));

        }

        public  bool? VerifyCurriculumName(string v)
        {
            bool actualresult = false;
           objDriver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
            actualresult =objDriver.GetElement(By.XPath("//li[@class= 'list-group-item'][2]/strong[1]")).Text.Equals(v);
            //objDriver.SwitchtoDefaultContent();
           objDriver.SwitchTo().DefaultContent();
            objDriver.ClickEleJs(By.XPath("//*[@id='PageBody']/body/div[2]/div[1]/div/a/span"));
            return actualresult;
        }

        public  void ComleteSurvey(string v)
        {
            if (v == "Somnath-Survey")
            {
               objDriver.SwitchWindow("Somnath-Survey");
                objDriver.select(By.Id("sq_100i"), "New Delhi");
               objDriver.GetElement(By.Id("sq_101i")).SendKeysWithSpace("Test");
                objDriver.ClickEleJs(By.XPath("//span[contains(text(),'5')]"));
                objDriver.ClickEleJs(By.XPath("//input[@value='Complete']"));
                objDriver.ClickEleJs(By.XPath("//a[@class = 'btn btn-default']"));
            }
            else
            {
               objDriver.SwitchWindow(v);
                objDriver.ClickEleJs(By.XPath("//input[@id='sq_100i_0']"));                
                objDriver.ClickEleJs(By.XPath("//input[@value='Complete']"));
                objDriver.ClickEleJs(By.XPath("//button[@type='button']"));
            }


        }

        public  void ClickViewCertificateButton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CurrCertificateBlock"));
        }

        public  bool? VerifySurveyCompleted()
        {
            return objDriver.existsElement(By.XPath("//li[@class='list-group-item']/ul[@class='list-inline']"));
        }

        public  void ClickAccessItemButton_Bundle()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_AccessBundleBlock"));
        }

        public  void OpenItemAICC()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));
        }

        public  bool? VerifyCourseNumber()
        {
            return objDriver.existsElement(By.XPath("//strong[contains(.,'@123')]"));
        }

        public  bool? VerifyCourseProvider()
        {
            return objDriver.existsElement(By.XPath("//strong[contains(.,'Meridian')]"));

        }

        public  bool? VerifyCourseDuration()
        {
            return objDriver.existsElement(By.XPath("//strong[contains(.,'2.5')]"));
        }

        public  void ClickAddtoCart()
        {
            if (objDriver.existsElement(By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonFlag")))
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucContentECommerce_FormView1_AddToCartButtonFlag"));
            }
            else
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucContentECommerce_FormView1_btnAddAccessKeyToCart"));

            }

        }

        public  void CompleteTest(string v)
        {
           objDriver.SelectWindowClose1("SCORM Debug Window");
           objDriver.SelectWindowClose1("SCORM Debug Window");
           objDriver.SwitchWindow("Meridian Global - Core Domain");
           objDriver.selectWindow("Meridian Global - Core Domain");
            Thread.Sleep(5000);
            //objDriver.waitforframe(By.Id("tocFrame"));
            //Thread.Sleep(5000);
            //objDriver.ClickEleJs(By.XPath("//u[contains(.,'" + v + "')]"));
            //Thread.Sleep(10000);
            //objDriver.SwitchTo().DefaultContent();
           objDriver.waitforframe(By.Id("contentFrame"));
            objDriver.ClickEleJs(By.XPath("//input[@id='q1true']"));
            objDriver.ClickEleJs(By.Id("Submit"));
            objDriver.ClickEleJs(By.Id("Submit"));
           objDriver.SwitchTo().DefaultContent();
           objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");


        }

        public  string ExaustedAttemptsMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div[1]/p")).Text;
        }

        public  void ClickViewAllAttempts()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_ucContentStatus_FormView1_ViewAllAttempts']"));
        }

        public  void ClickOpenNewAttempt()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt']"));
        }

        public  bool? IsOpenNewAttemptDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt']"));
        }

        public  bool? VerifyRetakeTest()
        {
            return objDriver.existsElement(By.XPath("//a[@id='quick-play']"));
        }



        public  bool? IsOpenCurrentAttemptDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchCurrentCompletedAttempt']"));
        }

        public  void CloseSCORMModal()
        {
           objDriver.selectWindow("Meridian Global - Core Domain");
           objDriver.SelectWindowClose();
           objDriver.SwitchtoDefaultContent();
        }

        public  bool? isOpenItembuttonDisplay()
        {
            return objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
        }

        public  bool? VerifyContinueButton()
        {
            return objDriver.existsElement(By.XPath("//span[@id='quick-play-text']"));
        }

        public  bool? VerifyEnrollButtonPresent()
        {
            return objDriver.existsElement(By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnEnroll"));
        }

        public  bool? VerifyCompletedStringExists()
        {
            return objDriver.existsElement(By.XPath("//td[contains(.,'Completed')]"));
        }

        public  void ClickEnrollinGeneralCourse()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton"));
        }

        public  bool? VerifyResumeButtonExists()
        {
            return objDriver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchCourseAttemptExisting"));
        }

        public  void LaunchTest()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
        }

        public  bool? isMorelikethisPortletdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='container-more-like-this']"));
        }

        public  bool? VerifybundlePromotionalVideo()
        {
           objDriver.SwitchTo().Frame(0);
            IWebElement element = objDriver.GetElement(By.XPath("//div[4]/button"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)objDriver;
            executor.ExecuteScript("arguments[0].style.border='3px dotted blue'", element);
           objDriver.SwitchTo().ActiveElement();
            return objDriver.existsElement(By.XPath("//div[4]/button"));
        }

        public  bool? isrelatedContentDisplay(string v)
        {
            return objDriver.existsElement(By.XPath(".//h4[contains(.,'" + v + "')]"));

        }


        public  void ClickSaveButton()
        {
            objDriver.existsElement(By.XPath("//a[@class='btn-content-details-save btn btn-default transition']"));
            objDriver.ClickEleJs(By.XPath("//a[@class='btn-content-details-save btn btn-default transition']"));
        }

        public  bool? isSaveButtonIconGreen()
        {
            Thread.Sleep(3000);
            // throw new NotImplementedException();
            return objDriver.GetElement(By.XPath("//a[@class='btn-content-details-save btn transition btn-success border-transparent']")).GetCssValue("background-color") == "rgba(63, 131, 63, 1)";

        }

        public  bool? VerifyCancelEnrollmentButton_Curriculum()
        {
            return objDriver.existsElement(By.XPath("//a[@class='text-white hover:text-white focus:text-white']"));
        }

        public  bool? isToolTipDisplayed(string v)
        {
            return objDriver.GetElement(By.XPath("//a[@id='MainContent_ucEditContent_FormView1_btnSaveContent']")).Text == v;


        }

        public  bool? isSearchResultContentDisplayed()
        {
            throw new NotImplementedException();
        }

        public  bool? isMoreLikeThisDisplayed()
        {
            return objDriver.existsElement(By.Id("container-more-like-this"));

        }

        public  bool isCancelButtonDisplayed_Scrom()
        {
            return objDriver.IsElementVisible(By.XPath("//input[@value='Cancel Enrollment']"));
        }


        public  void ClickExpressInterest()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucContentMetaData_FormView1_MLinkButton1"));

        }

        public  bool? isExpressInterestLinkDisplayed()
        {
            return objDriver.existsElement(By.Id("MainContent_ucContentMetaData_FormView1_MLinkButton1"));

        }

        public  bool? isExpressInterestFrameDisplayed()
        {
            return objDriver.GetElement(By.Id("KendoUIMGDialog_wnd_title")).Displayed;


        }

        public  bool? isDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div/h1"));

        }

        public  bool? isCancelInterestDisplayed()
        {
            return objDriver.GetElement(By.Id("MainContent_ucContentMetaData_FormView1_MLinkButton2")).Displayed;

        }

        public  void ClickCancelInterest()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucContentMetaData_FormView1_MLinkButton2"));
           objDriver.findandacceptalert();
        }

        public  bool? isEventScheduleDisplayed()
        {
            return objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl06_rgEvents_ctl00__0']/td/ul/li/div/div[2]")).Displayed;


        }

        public  bool? isEnrollmentStartDateDisplayed()
        {
            return objDriver.GetElement(By.XPath("//ul[@class='list-group']//li[2]//div[1]//div[1]")).Displayed;
        }

        public  bool? isEnrollmentEndDateDisplayed()
        {
            return objDriver.GetElement(By.XPath("//ul[@class='list-group']//li[2]//div[1]//div[2]")).Displayed;
        }

        public  void ClickBundleContent()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucBundle_mgBundleRequired_ctl00_ctl04_lnkDetails1']"));
        }

        public  bool? isClassroomTitleDisplayed()
        {
            return objDriver.GetElement(By.XPath("//h1[contains(@class,'page-title')]")).Displayed;


        }

        public  void ClickRequestAccess()
        {
            if (objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_RequestAccessButtonFlag']")))
            {

                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_RequestAccessButtonFlag']"));
                objDriver.waitforframe();
                objDriver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_fvAccessRequest_REQUEST_COMMENT']")).SendKeysWithSpace("Request Accepted");
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_RequestAccess']"));
               objDriver.SwitchtoDefaultContent();


            }
            else
            {
                objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessRequestStatusCancel']"));
                objDriver.waitforframe();
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_RequestAccess']"));
                objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_RequestAccessButtonFlag']"));
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_RequestAccessButtonFlag']"));

            }
            //objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_RequestAccessButtonFlag']"));
            //objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_RequestAccessButtonFlag']"));

        }





        public  bool? isCancelRequestButtonDisplayed()
        {
            throw new NotImplementedException();
        }

        public  bool? isRequestAccessButtonDisplayed()
        {
            throw new NotImplementedException();
        }

        public  bool? isContentPageDisplayed()
        {

            Meridian_Common.ContentPageCourse = objDriver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text;

            return objDriver.GetElement(By.XPath("//div[@id='content']/div/h1")).Displayed;
        }

        public  void ClickAccessItemButton_Certi()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag"));
        }

        public  bool? isCertificatePageDisplayed()
        {
           objDriver.selectWindow("Certificate");
           objDriver.SwitchTo().Frame(1);
            return objDriver.GetElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/section[1]/h1[1]")).Displayed;
        }

        public  void ClickEnroll_CerficationGeneralCourse()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CertEnrollButton"));
        }

        public  void ClickViewCertificate()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CertificateBlock']"));
        }
        public  void ClickCourse()
        {
            objDriver.ClickEleJs(By.XPath("//table[@id='table-gradeable-content']/tbody/tr/td/a"));
        }

        public  void AccessItemBundle()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessBundleBlock']"));
        }

        public  bool? MarkComplete_Curriculum_whenSurveyRequired()
        {

            try
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='block color-default no-underline font-semibold']"));
                objDriver.ClickEleJs(By.XPath("//li[1]//div[1]//div[3]//div[1]//div[1]//button[1]"));

                Meridian_Common.parentwdw =objDriver.CurrentWindowHandle;
                Thread.Sleep(10000);
               objDriver.SelectWindowClose2("Google", Meridian_Common.parentwdw);
                Thread.Sleep(4000);
                objDriver.ClickEleJs(By.XPath("//div[@class='sm:w-64 pull-right']//span[@class='caret']"));
                objDriver.ClickEleJs(By.XPath("//ul[@class='dropdown-menu']//li//a[@href='#'][contains(text(),'Mark Complete')]"));
                return objDriver.FindElement(By.XPath("//a[@id='quick-play']")).Displayed;
            }
            catch
            {
                return false;
            }


        }

        public  string getRequestAccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public  string getSuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public  void ClickSectionTab()
        {
            throw new NotImplementedException();
        }



        public  bool? isCancelEnrollmentButtonDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[contains(text(),'Cancel Enrollment')]")).Displayed;
        }

        public  void ClickCancelRequest()
        {
            throw new NotImplementedException();
        }

        public  bool? isMeridianGlobalCoreDomainWindowDisplayed()
        {
            throw new NotImplementedException();
        }



        public  bool? VerifyCancelEnrollmentMessage()
        {
            throw new NotImplementedException();
        }

        public  string getCancelRequestMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public  bool? isEnrollButtonDisplayed()
        {
            return objDriver.GetElement(By.XPath("//input[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnEnroll']")).Displayed;
        }

        public  void ManageSurveys()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnAssignSurveys']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));

        }

        public  bool? isStatusBarDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content-progress']//div[@class='progress-bar bg-scs']"));
        }

        public  bool? isSectionDisplayed()
        {
            objDriver.ClickEleJs(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td/a"));
            return objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl06_rgEvents_ctl00__0']/td/ul/li/div/div/strong")).Displayed;
        }

        public  void ClickEnrollButton_OJT()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollOJT"));
        }

        public  void EnterYourCodeToReceiveCredit()
        {
            //string code = "";
            //Meridian_Common.CompletionCode= code;
            objDriver.ClickEleJs(By.XPath("//div[@id='overviewTab']/div/div[2]/div/p/a"));
            objDriver.waitforframe();
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_txtCompletionCode']")).SendKeysWithSpace(Meridian_Common.CompletionCode);
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnComplete']"));
            //objDriver.SwitchtoDefaultContent();
        }

        public  string getSurveysMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-warning']//p")).Text;
        }

        public  void Click_EditEquivalencies()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucEquivalencies_lnkEdit']"));
        }

        public  bool? isSurveyDisplayed()
        {
            return objDriver.existsElement(By.XPath("//h3[contains(text(),'Surveys')]"));
        }

        public  bool? isEquivalenciesDisplayed()
        {
            if (objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/h3")).Displayed)
            {
                return true;
            }
            else if (objDriver.existsElement(By.XPath("//div[@id='overviewTab']/div/div[2]/div[2]/div")))
            {
                return true;
            }
            else return false;
        }

        public  string GetCodeRelatedMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-danger']")).Text;
        }









        public  void ClickCancelkWaitlistButton()
        {
            string cancelwaitlist = "";
            objDriver.ClickEleJs(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[4]/div[2]/a"));
            Meridian_Common.cancelwaitlist = objDriver.GetElement(By.XPath("//table[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00']/tbody/tr[2]/td/div/ul/li[3]/div/div[2]")).ToString();


        }

        public  void ClickAccessItemButton_Subscription()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_AccessSubscriptionFlag"));
        }

        public  bool? VerifyEnRollmentStatusUpdated()
        {
            if (Meridian_Common.cancelwaitlist == Meridian_Common.waitlist)
            {
                return false;
            }
            return true;
        }
        public  void ClickWaitlistButton()
        {
            string waitlist = "";
            objDriver.ClickEleJs(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[4]/div[2]/input"));
            Meridian_Common.waitlist = objDriver.GetElement(By.XPath("//table[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00']/tbody/tr[2]/td/div/ul/li[3]/div/div[2]")).ToString();
        }

        public  void ClickAccessItemButton_PBundle()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_AccessBundleBlock"));
            //MainContent_ucPrimaryActions_FormView1_AccessBundleBlock
        }

        public  string VerifyEnrollMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public  void ClickCancelEnrollment()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_CancelEnrollment']"));
            //objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            //objDriver.GetElement(By.Id("MainContent_UC1_tbUnenrollReason")).Clear();
            //objDriver.GetElement(By.Id("MainContent_UC1_tbUnenrollReason")).SendKeysWithSpace("For Test");
            //objDriver.ClickEleJs(By.Id("MainContent_UC1_btnCancelEnrollment"));
            //Thread.Sleep(2000);
            ////objDriver.selectWindow("Enrollment Cancellation Reason");
            //objDriver.selectWindow("ctl00$MainContent$UC1$tbUnenrollReason");

            //objDriver.GetElement(By.Name("ctl00$MainContent$UC1$tbUnenrollReason")).SendKeys("Cancel");
            //objDriver.ClickEleJs(By.XPath("//*[@id='MainContent_UC1_btnCancelEnrollment']"));
           objDriver.SwitchTo().DefaultContent();
        }

        public  void ClickEditCertificationContent()
        {
            objDriver.existsElement(By.Id("MainContent_MainContent_ucCertficateContents_lnkEdit"));
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucCertficateContents_lnkEdit"));
        }

        public  string VerifyEnrollCancelMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public  bool? isWaitlistButtonDisplayed()
        {
            return objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[4]/div[2]/input")).Displayed;
        }



        public  string VerifyWaitlistMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;

        }

        public  bool? isBundlesCostTypeDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul/li"));
        }

        public  void ClickOnContent()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucBundle_mgBundleOptional_ctl00_ctl04_lnkDetails']"));
        }

        public  string VerifyCancelWaitlistMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;

        }

        public  string VerifyPrerequisiteMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='prereq-alert']/p")).Text;
        }

        public  bool? isprerequisitetableDisplayed()
        {
            return objDriver.GetElement(By.XPath("//div[@id='prerequisite-block']")).Displayed;

        }

        public class ExpressInterestCommand
        {
        private IWebDriver objDriver;
        public ExpressInterestCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? isReasonDisplayed()
            {

               objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));

                return objDriver.GetElement(By.Id("MainContent_UC1_UI_REASON")).Displayed;
            }

            public bool? isFormatDisplayed()
            {
                return objDriver.GetElement(By.Id("MainContent_UC1_UI_SECTION_FORMAT")).Displayed;
            }

            public bool? isISeekTrainingAfterDisplayed()
            {
                return objDriver.GetElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_dateInput")).Displayed;
            }

            public bool? isISeekTrainingBeforeDisplayed()
            {
                return objDriver.GetElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput")).Displayed;
            }

            public bool? isIPreferToTrainDisplayed()
            {
                return objDriver.GetElement(By.Id("MainContent_UC1_UI_DATETIME_PREFERENCE")).Displayed;
            }

            public bool? isLocationDisplayed()
            {
                return objDriver.GetElement(By.Id("MainContent_UC1_UI_LOCATION")).Displayed;
            }

            public bool? isAdditionalInformationDisplayed()
            {
                return objDriver.GetElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO")).Displayed;
            }

            public bool? isCancelButtonDisplayed()
            {
                return objDriver.GetElement(By.Id("MainContent_UC1_btnCancel")).Displayed;
            }

            public bool? isSubmitButtonDisplayed()
            {
                return objDriver.GetElement(By.Id("MainContent_UC1_btnSubmit")).Displayed;
            }

            public void SubmitWith(string v1, string v2, string v3, string v4, string v5, string v6, string v7)
            {

                objDriver.select(By.Id("MainContent_UC1_UI_REASON"), v1);
                objDriver.ClickEleJs(By.Id("MainContent_UC1_UI_SECTION_FORMAT_1"));
                objDriver.GetElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_dateInput")).SendKeys(v3);
                objDriver.GetElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput")).SendKeys(v4);
                objDriver.select(By.Id("MainContent_UC1_UI_DATETIME_PREFERENCE"), v5);
                objDriver.GetElement(By.Id("MainContent_UC1_UI_LOCATION")).SendKeys(v6);
                objDriver.GetElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO")).SendKeysWithSpace(v7);
                objDriver.ClickEleJs(By.Id("MainContent_UC1_btnSubmit"));

               objDriver.SwitchTo().DefaultContent();

            }
        }

        public  void ClickEnrollforCertificationcontent()
        {
            objDriver.ClickEleJs(By.Id("MainContent_ucCurriculumDetails_FormView1_CertEnrollButton"));
        }

        //public  void OpenNewAttempt()
        //{
        //    objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt']"));

        //    Thread.Sleep(10000);

        //   objDriver.SelectWindowClose();
        //}

        public  bool? VerifyPromotionalVideo()
        {
           objDriver.SwitchTo().Frame(0);
            IWebElement element = objDriver.GetElement(By.XPath("//div[4]/button"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)objDriver;
            executor.ExecuteScript("arguments[0].style.border='3px dotted blue'", element);
           objDriver.SwitchTo().ActiveElement();
            return objDriver.existsElement(By.XPath("//div[4]/button"));

        }

        public class PromotionalVideoCommand
        {
            public bool? isFullScreenIcondisabled;

        private IWebDriver objDriver;
        public PromotionalVideoCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void Click_Edit()
            {
                objDriver.existsElement(By.XPath("//h3[contains(text(),'Promotional Video')]/following::a[1]"));
                objDriver.ClickEleJs(By.XPath("//h3[contains(text(),'Promotional Video')]/following::a[1]"));
            }

            public bool? isVedioPreviewDisplay()
            {
                if (objDriver.existsElement(By.XPath("//div[@class='col-md-4 panel-group']//div[5]//ul[1]//li[1]")))
                {
                    return true;
                }
                else if (objDriver.existsElement(By.XPath("//h3[contains(text(),'Promotional Video')]/following::div[2]")))
                {
                    return true;
                }
                else return false;

            }
            public void ClickPlayButton()
            {
               objDriver.SwitchTo().Frame(0);
                objDriver.GetElement(By.XPath("//div[4]/button")).Click();


            }

            public bool? VerifyPlaysInline()
            {

                Thread.Sleep(30000);
                return
    (objDriver.existsElement(By.CssSelector("button.ytp-fullscreen-button.ytp-button")) && (objDriver.existsElement(By.XPath("//div[contains(@class,'ytp-small-mode')]"))));
            }

            public void ClickFullScreenIconAndPlay()
            {
                objDriver.GetElement(By.CssSelector("button.ytp-fullscreen-button.ytp-button")).Click();
                Thread.Sleep(2000);
                objDriver.GetElement(By.CssSelector("button.ytp-play-button.ytp-button")).Click();
                Thread.Sleep(5000);
            }

            public  bool? isCertificatePageDisplayed()
            {
               objDriver.selectWindow("Certificate");
               objDriver.SwitchTo().Frame(1);
                return objDriver.GetElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/section[1]/h1[1]")).Displayed;
            }

            public  void ClickViewCertificate()
            {
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CertificateBlock']"));
            }

            public  bool? isContentPageDisplayed()
            {

                Meridian_Common.ContentPageCourse = objDriver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text;

                return objDriver.GetElement(By.XPath("//div[@id='content']/div/h1")).Displayed;
            }

            public bool? VerifyPlaysOnFullScreen()
            {
                objDriver.GetElement(By.XPath("//div[4]/button")).Click();
                return objDriver.existsElement(By.XPath("//div[contains(@class,'ytp-small-mode')]"));
            }

            public  void ClickCourse()
            {
                objDriver.ClickEleJs(By.XPath("//table[@id='table-gradeable-content']/tbody/tr/td/a"));
            }

            public void SubmitWith(string v1, string v2, string v3, string v4, string v5, string v6, string v7)
            {

                objDriver.select(By.Id("MainContent_UC1_UI_REASON"), v1);
                objDriver.ClickEleJs(By.Id("MainContent_UC1_UI_SECTION_FORMAT_1"));
                objDriver.GetElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_dateInput")).SendKeys(v3);
                objDriver.GetElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput")).SendKeys(v4);
                objDriver.select(By.Id("MainContent_UC1_UI_DATETIME_PREFERENCE"), v5);
                objDriver.GetElement(By.Id("MainContent_UC1_UI_LOCATION")).SendKeys(v6);
                objDriver.GetElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO")).SendKeysWithSpace(v7);
                objDriver.ClickEleJs(By.Id("MainContent_UC1_btnSubmit"));

               objDriver.SwitchTo().DefaultContent();

            }

            public void ClickMinimizeScreenIcon()
            {
                throw new NotImplementedException();
            }

            public bool? isFullScreenIconisdisabled()
            {
                throw new NotImplementedException();
            }

            public void ClickbundlePlayButton()
            {
                throw new NotImplementedException();
            }
        }

        public  void Click_OJT_Content()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucOJT_FormView1_rgRequired_ctl00_ctl04_lnkDetails']"));
        }

        public  void ClickCurriculumnEnroll()
        {
            objDriver.ClickEleJs(By.LinkText("Enroll"));

        }

        public  bool? isBundlesCostDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/strong"));
        }

        public  bool? isBundlesTitleDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/a"));

        }
        public  bool? isCertificationPeriodDisplayed()
        {
            return objDriver.existsElement(By.XPath("//ul[@class='list-group']//li[3]"));
        }

        public  bool? isCertificationCostTypeDisplayed()
        {
            return objDriver.existsElement(By.XPath("//ul[@class='list-group']//li[2]"));
        }

        public  bool? isCertificationTypeDisplayed()
        {
            return objDriver.existsElement(By.XPath("//ul[@class='list-group']//li[1]"));
        }

        public  string getInformativeMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-warning']//p")).Text;
        }
        public  bool? isObjectivesBlockDisplayed()
        {
            return objDriver.existsElement(By.XPath("//h3[contains(text(),'Objectives')]"));
        }

        public  bool? isAlternateOptionsBlockDisplayed()
        {
            return objDriver.existsElement(By.XPath("//h3[contains(text(),'Alternate Options')]"));
        }

        public  bool? isCertificationContentBlockDisplayed()
        {
            return objDriver.existsElement(By.XPath("//h3[contains(text(),'Certification Content')]"));
        }

        public  void EditAndAddCertificationContent()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCertficateContents_lnkEdit']"));
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkUserGroup']"));
            objDriver.GetElement(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_txtSearchFor']")).SendKeysWithSpace("General");
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_ucContentSearch_btnSearch']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_ucAddContentSearch_rgCertificationAddContent_ctl00_ctl04_chkCertAddContent']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucAddContentSearch_btnAddCert']"));

        }

        public  bool? isAccessItemButtonDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag']"));
        }

        public  void ClickCertificationClassroom()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'AddingWaitlistMembers_Bug')]"));
        }
        public  void ClickAccessItem()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag']"));
        }
        public  string getAccessDateMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-info']//p")).Text;
        }
        public  string getCertificationEnrolledMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div[2]/p")).Text;
        }
        public  string getCurriculumEnrollmentSuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }
        public  void isCurriculumBlockDisplayed()
        {
            objDriver.GetElement(By.XPath("//div[2]/div[1]/div[3]/div"));
        }
        public  bool? isCurriculumCostDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@class='col-md-4']//ul[4]//li[1]//strong[1]"));
        }

        public  void AccessItemCertification()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag']"));
        }

        public  void ClickCertificationContent()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucCertification_FormView1_mgCertification_ctl00_ctl04_lnkDetails']"));
        }

        public  bool? isCurriculumtitleDisplayed()
        {
            return objDriver.existsElement(By.XPath("/html[1]/body[1]/form[1]/div[7]/div[1]/div[2]/div[1]/div[2]/div[2]/ul/li[1]/a[1]"));
        }

        public  bool? isCurriculumDisplayed()
        {
            return objDriver.existsElement(By.XPath("//h3[contains(text(),'Curriculums')]"));
        }
        public  bool? isPrerequisiteTitleDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/a"));
        }
        public  void CurriculumAccessItem()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CurriculumLaunchAttempt']"));
        }
        public  void EditCurriculumsContent()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucTrainingActivity_lnkEdit']"));
        }


        public  void EnrollinCurriculum()
        {
            objDriver.existsElement(By.XPath("//a[@class='btn btn-primary btn-lg']"));
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-primary btn-lg']"));
            //objDriver.IsElementVisible(By.XPath("//span[@id='feedback']"));
        }

        public  bool? isSuggestedBundlesDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/h3"));
        }

        public class ExpandedScheduledCourseCommand
        {
        private IWebDriver objDriver;
        public ExpandedScheduledCourseCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? VerifyEventScheduleText(string v)
            {
                objDriver.existsElement(By.XPath("//h4[contains(text(),'Event Schedule')]"));
                bool result = false;
                try
                {
                    switch (v)
                    {
                        case "AllDay":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//td/ul/li/div/div[2]")).Text.Contains("All Day");

                            break;
                        case "OneEvent":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                            result =objDriver.IsElementVisible(By.XPath("//div[2]/strong"));

                            break;
                        case "Every Weekday":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            string text = objDriver.GetElement(By.XPath("//div[@class='col-xs-4 col-sm-4']")).Text.Replace(@"\r\n", " ");
                            result = text.Contains("Every Weekday");

                            break;
                        case "Daily":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//div[@class='col-xs-4 col-sm-4']")).Text.Contains("Daily");

                            break;
                        case "Weekly":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//div[@class='col-xs-4 col-sm-4']")).Text.Contains("Every");

                            break;
                        case "Every two weeks":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//div[@class='col-xs-4 col-sm-4']")).Text.Contains("Every two weeks on");

                            break;
                        case "Monthly":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//div[@class='col-xs-4 col-sm-4']")).Displayed;

                            break;
                        case "MonthlySpecificDay":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//div[@class='col-xs-4 col-sm-4']")).Text.Contains("Every month on the");

                            break;

                        case "Annually":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//div[@class='col-xs-4 col-sm-4']")).Text.Contains("Every year on");

                            break;
                        case "MultipleEvents":
                           objDriver.IsElementVisible(By.XPath("//div/strong"));
                           objDriver.IsElementVisible(By.XPath("//div[2]/strong"));
                            result = objDriver.GetElement(By.XPath("//body[@class='canvas']//tr//tr[@class='rgRow']//div[2]")).Displayed;

                            break;
                    }

                }
                catch
                { }
                return result;
            }
        }




        public class MorelikethisCommand
        {
        private IWebDriver objDriver;
        public MorelikethisCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        string text = string.Empty;
            public MorelikethisCommand()
            {
                text = objDriver.GetElement(By.XPath("//div[@id='container-more-like-this']/div/div/div/div[4]/a/h4")).Text;
                text = text.Substring(0, 14);
                Meridian_Common.text12 = text;
            }
            public void ClickSaveButton(string text)
            {
                //text = text.Substring(0, 14);
                objDriver.existsElement(By.XPath("//h4[contains(.,'" + text + "')]/following::button[1]"));
                objDriver.ClickEleJs(By.XPath("//h4[contains(.,'" + text + "')]/following::button[1]"));

            }

            public bool? isSaveButtonIconGreen(string text)
            {
                Thread.Sleep(3000);

                return objDriver.GetElement(By.XPath("//h4[contains(.,'" + text + "')]/following::button[1]")).GetCssValue("background-color") == "rgba(121, 168, 121, 1)";

            }

            public bool? isToolTipDisplayed(string v)
            {
                return objDriver.GetElement(By.XPath("//h4[contains(.,'" + text + "')]/following::span[@title='" + v + "'][1]")).GetAttribute("Title") == v;
            }
        }

        public class SCROMCommand
        {
        private IWebDriver objDriver;
        public SCROMCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ClickEnrollButton()
            {
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_EnrollButton'] "));
            }

            public bool? VerifyOpenItemButtonAvailable()
            {
                return objDriver.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")).Displayed;
            }

            public void ClickOpenItem()
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
            }

            public bool? VerifyCourseOpensInNewWindow()
            {
                return true;
            }

            public void CompleteSCROMCourse()
            {
               objDriver.SelectWindowClose1("SCORM Debug Window");
               objDriver.SelectWindowClose1("SCORM Debug Window");
               objDriver.SwitchWindow("Meridian Global - Core Domain");
                //objDriver.WaitForElement(By.XPath("//input[@value='Resume']"));
                // objDriver.ClickEleJs(By.XPath("//input[@value='Resume']"));
               objDriver.selectWindow("Meridian Global - Core Domain");
                Thread.Sleep(5000);
               objDriver.waitforframe(By.Id("tocFrame"));
                objDriver.ClickEleJs(By.Id("BUTTON3"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'References and Lesson Objective')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'References and Lesson Objective')]"));

               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));

               objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Lights & Shapes')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Lights & Shapes')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Exam')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Exam')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                //driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                //driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//li[4]/input"));
                objDriver.ClickEleJs(By.XPath("//li[4]/input"));
                objDriver.ClickEleJs(By.XPath("//dt[2]/ol/li[2]/input"));
                objDriver.ClickEleJs(By.XPath("//dt[3]/ol/li[3]/input"));
                objDriver.ClickEleJs(By.XPath("//dt[4]/ol/li[2]/input"));
                objDriver.ClickEleJs(By.XPath("//input[@name='Q5']"));

                objDriver.ClickEleJs(By.XPath("//input[@value=' SUBMIT ANSWERS ']"));
               objDriver.SwitchTo().DefaultContent();
                //objDriver.ClickEleJs(By.XPath("//img[@id ='Exit']"));
               objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
            }

            public bool? VerifyDateofCompletion(string today)
            {
                string[] tokens;
                string dateString = objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
                string[] todaysplit = today.Split('/');
                int month = Int32.Parse(todaysplit[0]);
                int date = Int32.Parse(todaysplit[1]);
                if ((month < 10) && (date < 10))
                {
                    var regex = new Regex(@"\b\d{1}\/\d{1}/\d{4}\b");
                    string datetobe = regex.Match(dateString).ToString();
                    tokens = datetobe.Split('/');
                    int monthactual = Int32.Parse(tokens[0]);
                    int dateactual = Int32.Parse(tokens[1]);
                    if (monthactual == month && dateactual == date)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((month < 10) && (date >= 10))
                {
                    var regex = new Regex(@"\b\d{1}\/\d{2}/\d{4}\b");
                    string datetobe = regex.Match(dateString).ToString();
                    tokens = datetobe.Split('/');
                    int monthactual = Int32.Parse(tokens[0]);
                    int dateactual = Int32.Parse(tokens[1]);
                    if (monthactual == month && dateactual == date)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if ((month >= 10) && (date < 10))
                {
                    var regex = new Regex(@"\b\d{2}\/\d{1}/\d{4}\b");
                    string datetobe = regex.Match(dateString).ToString();
                    tokens = datetobe.Split('/');
                    int monthactual = Int32.Parse(tokens[0]);
                    int dateactual = Int32.Parse(tokens[1]);
                    if (monthactual == month && dateactual == date)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((month >= 10) && (date >= 10))
                {
                    var regex = new Regex(@"\b\d{2}\/\d{2}/\d{4}\b");
                    string datetobe = regex.Match(dateString).ToString();
                    tokens = datetobe.Split('/');
                    int monthactual = Int32.Parse(tokens[0]);
                    int dateactual = Int32.Parse(tokens[1]);
                    if (monthactual == month && dateactual == date)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }



                //objDriver.getIntegerFromString(date);
                //return date.Equals(today);
            }

            public bool? VerifyViewCertificateButtonAvailable()
            {
                return objDriver.GetElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CertificateBlock']")).Displayed;
            }

            public void ClickViewCertificateButton()
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_CertificateBlock"));
            }

            public void AddSurveys()
            {
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC4_hlManage"));
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnAssignSurveys"));
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
                objDriver.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"));

            }

            public void AddCourseInfo()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucCourseInfo_lnkEdit"));
               objDriver.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_NUMBER")).SendKeysWithSpace("@123");
                objDriver.select(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_PROVIDER"), "Meridian");
               objDriver.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_DURATION")).SendKeysWithSpace("2.5");
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            }

            public void Fail_SCROMCourse()
            {
               objDriver.SelectWindowClose1("SCORM Debug Window");
               objDriver.SelectWindowClose1("SCORM Debug Window");
               objDriver.SwitchWindow("Meridian Global - Core Domain");
                //objDriver.WaitForElement(By.XPath("//input[@value='Resume']"));
                // objDriver.ClickEleJs(By.XPath("//input[@value='Resume']"));
               objDriver.selectWindow("Meridian Global - Core Domain");
                Thread.Sleep(5000);
               objDriver.waitforframe(By.Id("tocFrame"));
                objDriver.ClickEleJs(By.XPath(".//*[@id='SCORM12Menu_1']/span[3]/img"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'References and Lesson Objective')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'References and Lesson Objective')]"));

               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));

               objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Lights & Shapes')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Lights & Shapes')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("tocFrame"));
               objDriver.WaitForElement(By.XPath("//u[contains(.,'Exam')]"));
                objDriver.ClickEleJs(By.XPath("//u[contains(.,'Exam')]"));
               objDriver.SwitchTo().DefaultContent();
               objDriver.waitforframe(By.Id("contentFrame"));
                //driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
                //driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
                Thread.Sleep(5000);
               objDriver.WaitForElement(By.XPath("html/body/form[1]/dl/dt[1]/ol/li[1]/input"));
                objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[1]/ol/li[2]/input"));
                objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[2]/ol/li[4]/input"));
                objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[3]/ol/li[2]/input"));
                objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[4]/ol/li[1]/input"));
                objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[5]/ol/li[4]/input"));

                objDriver.ClickEleJs(By.XPath("//input[@value=' SUBMIT ANSWERS ']"));
               objDriver.SwitchTo().DefaultContent();
                //objDriver.ClickEleJs(By.XPath("//img[@id ='Exit']"));
               objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");

            }

            public void CloseSCROMCoursewithoutComplete()
            {
               objDriver.selectWindow("Meridian Global");
               objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
            }
        }

        public  void AccessItemOJT()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucCurriculumDetails_FormView1_OJTLaunchAttempt']"));

        }

        public  void AddaNewSection(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lbAddSection']"));
            objDriver.waitforframe();
            objDriver.GetElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']"));

        }

        public  void ClickEditContent_New19_2()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Edit Content')]"));
        }

        public  bool? isPrerequisiteCostDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/ul/li[2]/strong"));
        }

        public  bool? isPrerequisiteStatusDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/ul/li/strong"));
        }

        public  void ClickPrerequisiteTitle()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/a"));
        }

        public  bool? isOtherAvailableTraining()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div[2]/div/h3"));
        }

        public  bool? isAddToCartButtonDisplayed()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Add to Cart')]"));
        }

        public  string AddToCartSuccessMessage()
        {
            return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public class ScheduledCourseCommand
        {
        private IWebDriver objDriver;
        public ScheduledCourseCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? IsWaitlistbuttonDisplay()
            {
                return objDriver.existsElement(By.XPath("//a[@class='btn btn-default schedule-action mb-4']"));
            }

            public void ClickWaitlistButton()
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-default schedule-action mb-4']"));
            }

            public bool? IsCancelWaitlistbuttonDisplay()
            {
                return objDriver.existsElement(By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_lnkCancelWaitList"));
            }



            public void ClickCancelkWaitlistButton()
            {
                objDriver.ClickEleJs(By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_lnkCancelWaitList"));
            }

            public bool? VerifyMiddleColumnText(string v)
            {
                objDriver.existsElement(By.XPath("//h3[@class='panel-title panel-title-with-btn']"));
                bool result = false;
                try
                {
                    switch (v)
                    {
                        case "AllDay":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            result = objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("All Day");
                            // result = true;
                            break;

                        case "OneEvent":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            result = objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Displayed; ;
                            // result = true;
                            break;
                        case "Every Weekday":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            result = objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Displayed;
                            //result = true;
                            break;
                        case "Daily":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            result = objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("Daily");
                            // result = true;
                            break;
                        case "Weekly":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            result = objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("Every");
                            // result = true;
                            break;
                        case "Every two weeks":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("Every two weeks on");
                            result =objDriver.IsElementVisible(By.XPath("//td[3]/p"));
                            // result = true;
                            break;
                        case "Monthly":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("Day 29 of every month");
                            result =objDriver.IsElementVisible(By.XPath("//td[3]/p"));
                            //result = true;
                            break;
                        case "MonthlySpecificDay":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("Every month on the");
                            result =objDriver.IsElementVisible(By.XPath("//td[3]/p"));
                            //result = true;
                            break;
                        case "Annually":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("Every year on");
                            result =objDriver.IsElementVisible(By.XPath("//td[3]/p"));
                            // result = true;
                            break;
                        case "MultipleEvents":
                           objDriver.IsElementVisible(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/h4"));
                            objDriver.GetElement(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text.Contains("Times Vary");
                            result =objDriver.IsElementVisible(By.XPath("//td[3]/p"));
                            break;
                    }

                }
                catch
                { }
                return result;
            }

            public void ClickExpandRowicon()
            {
                objDriver.ClickEleJs(By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td/a"));
            }
        }

        public  void AccessItemSubscription()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_AccessSubscriptionFlag']"));

        }

        public class AccessApprovalModalCommand
        {
        private IWebDriver objDriver;
        public AccessApprovalModalCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void SubmitRequestAccess(string v)
            {
                if (objDriver.existsElement(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4'][contains(text(),'Request Access')]")))
                {
                    objDriver.ClickEleJs(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4'][contains(text(),'Request Access')]"));
                    //   objDriver.waitforframe(By.XPath("//body[@id='modalMaster']"));

                   objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    objDriver.existsElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT"));
                    //objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).Click();
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).Clear();
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace(v);
                    objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_RequestAccess']"));
                    Thread.Sleep(5000);
                   objDriver.Navigate().Refresh();

                    objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//a[@class='btn btn-danger mb-4'][contains(text(),'Cancel Request')]"));
                }
                if (objDriver.existsElement(By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnRequestAccess")))
                {
                    objDriver.ClickEleJs(By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnRequestAccess"));
                   objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    objDriver.existsElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT"));
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).Clear();
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace(v);
                    objDriver.ClickEleJs(By.Id("MainContent_UC1_RequestAccess"));
                    Thread.Sleep(5000);
                    objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
                }
                if (objDriver.existsElement(By.XPath("//a[@class='btn btn-primary btn-lg']")))
                {
                    objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-primary btn-lg']"));


                   objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    objDriver.existsElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT"));
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).Clear();
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace(v);
                    objDriver.ClickEleJs(By.Id("MainContent_UC1_RequestAccess"));
                    Thread.Sleep(5000);
                    objDriver.existsElement(By.XPath("//a[@class='btn btn-danger cancel-request']"));
                }


            }

            public void CancelRequestAccess(string v)
            {


                if (objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//a[@class='btn btn-danger mb-4'][contains(text(),'Cancel Request')]")))
                {
                    objDriver.ClickEleJs(By.XPath("//div[@id='scheduleTab']//a[@class='btn btn-danger mb-4'][contains(text(),'Cancel Request')]"));
                   objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    objDriver.existsElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT"));
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).Clear();
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace(v);
                    objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_RequestAccess']"));
                    Thread.Sleep(5000);
                    objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
                }
                if (objDriver.existsElement(By.LinkText("Cancel Request")))
                {
                    objDriver.ClickEleJs(By.LinkText("Cancel Request"));
                   objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    objDriver.existsElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT"));
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).Clear();
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace(v);
                    objDriver.ClickEleJs(By.Id("MainContent_UC1_RequestAccess"));
                    Thread.Sleep(5000);
                   objDriver.Navigate().Refresh();

                    objDriver.existsElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[8]/div[2]/div[3]/div[2]/div[1]/div[1]/div[3]/a[1]"));
                }

            }

            public bool? ContentTypeDocument(string formatDocument)
            {
                objDriver.waitforframe();
                return objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/ul/li[2]/strong")).Text.Equals(formatDocument);
            }

            public void RequestAccess()
            {
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_RequestAccess']"));
            }

            public void SubmitCancelRequestAccess(string v)
            {
                if (objDriver.existsElement(By.LinkText("Cancel Request")))
                {
                    objDriver.ClickEleJs(By.LinkText("Cancel Request"));


                   objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    objDriver.existsElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT"));
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).Clear();
                    objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace(v);
                    objDriver.ClickEleJs(By.Id("MainContent_UC1_RequestAccess"));
                    Thread.Sleep(5000);
                    
                }
                
            }
        }

        public class CurriculumBlockCommand
        {
        private IWebDriver objDriver;
        public CurriculumBlockCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void ClickEnrollButton()
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCurriculumButtonFlag"));
            }

            public void ClickAccessItemButton()
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_CurriculumLaunchAttempt"));
            }

            public void ClickContentTitleButton(String v)
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, 'javascript:void(0);')]"));
            }

            public void ClickCancelEnrolmentButton()
            {
                objDriver.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_CancelEnrollementReason"));
               objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                objDriver.GetElement(By.Id("MainContent_UC1_tbUnenrollReason")).SendKeys("test");
                objDriver.ClickEleJs(By.Id("MainContent_UC1_btnCancelEnrollment"));
            }
        }

        public class DocumentCommand
        {
        private IWebDriver objDriver;
        public DocumentCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }


        public string VerifyCurrentDate(string today)
            {
                //string format = string.Format("{0:MMMM yyyy}");
                string dateString = objDriver.GetElement(By.XPath("//div[@class='alert alert-info']")).Text;
                var regex = new Regex(@"\b\d{1}\/\d{1}/\d{4}\b");
                string date = regex.Match(dateString).ToString();
                // string systemmonth = string.Format("{0:MMMM yyyy}", DateTime.Now);
                //objDriver.getIntegerFromString(date);
                return date;
            }

            public string VerifyMarkedAsComplete()
            {
                return objDriver.GetElement(By.XPath("//div[@class='alert alert-info']")).Text;
            }

            public string VerifyCompletedThisItemString()
            {
                return objDriver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;

            }

            public bool? OpenCurrentAttempt()
            {
                return objDriver.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchCurrentCompletedAttempt")).Displayed;
            }

            public bool? OpenNewAttempt()
            {
                return objDriver.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt")).Displayed;
            }

            public bool? GetHeaderText(string v)
            {
                return objDriver.GetElement(By.XPath("//h1[contains(@class,'page-title')]")).Text.Equals(v);
            }
        }

        public class AccordianCommand
        {
        private IWebDriver objDriver;
        public AccordianCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public PromotionalVideoCommand PromotionalVideo { get { return new PromotionalVideoCommand(objDriver); } }

       
        public void ClickEdit_CostNSalesTax()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucCost_lnkEdit"));
            }

            public void ClickEdit_Certificate()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucCertificate_lnkEdit"));
            }

            public string VerifyText_Certificate(string v)
            {
                objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucCertificate_pnlCertificate']/div/p"));
                return objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucCertificate_pnlCertificate']/div/p")).Text;
            }

            public void ClickEdit_Prerequisites()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));
            }

            public bool? VerifyanyPrerequisitesPresent()
            {
                //objDriver.Navigate().Back();
                string prerequisitenumber = objDriver.GetElement(By.XPath("//p[contains(text(),'1 Assigned Prerequisites')]")).Text;
                if (objDriver.getIntegerFromString(prerequisitenumber) >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void ClickEdit_AccessApproval()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucAccessApproval_lnkEdit"));

            }

            public void ClickEdit_Categories()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucCategories_lnkEdit"));
            }

            public bool? VerifyCategoryAdded()
            {
                string prerequisitenumber = objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucCategories_pnlCategories']/div/p")).Text;
                if (objDriver.getIntegerFromString(prerequisitenumber) >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void ClickEdit_Image()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucImage_lnkEdit"));
            }

            public bool? VerifyImageOnSummarAcordian()
            {
                return objDriver.existsElement(By.Id("MainContent_MainContent_ucImage_assignedImage"));
            }

            public void ClickEdit_Equivalencies()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucEquivalencies_lnkEdit"));
            }

            public bool? VerifyanyEquivalenciesPresent()

            {
               objDriver.Navigate().Back();
                string prerequisitenumber = objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucEquivalencies_pnlEquivalencies']/div/p")).Text;
                if (objDriver.getIntegerFromString(prerequisitenumber) >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool? ManageActivityStatus(string v)
            {
                objDriver.existsElement(By.Id("MainContent_MainContent_ucActivity_lnkEdit"));
                return objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucActivity_pnlActivity']/div/p")).Text.Equals(v);
            }

            public void ClickEdit_ManageActivity()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucActivity_lnkEdit"));
            }

            public void ClickManage_Survey()
            {
               objDriver.Checkout();
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']"));
            }

            public bool? VerifySurveyPresnet(string v = "")

            {


                ///objDriver.Navigate().Back();
                return objDriver.existsElement(By.XPath("//span[contains(text(),'!@#%$^**((*)(*)&(*^&*^_NEw SEryr6')]"));
            }

            public void ClickEdit_CurriculumContent()
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucTrainingActivity_lnkEdit']"));
            }

            public bool? ClickEdit_ScormCourseFile()
            {
                bool result = false;

                try
                {
                    objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucSCORMFiles_lnkEdit"));
                   objDriver.WaitForElement(By.XPath("//input[@id='AsyncUpload1file0']"));
                   objDriver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
                    objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Next']"));
                   objDriver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));

                    result = true;
                }
                catch (Exception ex)
                {


                }


                return result;
            }

            public void ClickEdit_Summery()
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            }

            public bool? ClickEdit_ScormCourseSetting()
            {
               objDriver.Checkout();
                bool result = false;
                try
                {
                   objDriver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
                    objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
                   objDriver.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
                    objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_EnableUIElmtPageHeader']"));
                    objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                    result = true;
                }
                catch (Exception e)
                {

                }

                return result;

            }

            public bool? ClickEdit_ContentShring()
            {
                bool result = false;
                try
                {
                    objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucContentSharing_lnkEdit']"));
                   objDriver.IsElementVisible(By.XPath("//h1[contains(.,'Content Sharing')]"));
                   objDriver.IsElementVisible(By.XPath("//input[@value='Save']"));
                   objDriver.IsElementVisible(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToPublicCatalog']"));
                    result = true;
                }
                catch (Exception e)
                {

                }
                return result;
            }

            public bool? ShaareContent_ChildDomain()
            {
                bool result = false;
                try
                {
                    objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToAllDomains']"));
                    objDriver.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                   objDriver.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                    result = true;
                }
                catch (Exception e)
                {

                }
                return result;
            }

            public void ClickSurveyLink()
            {
                objDriver.ClickEleJs(By.LinkText("Somnath-Survey"));
            }

            public void ClickEdit_CourseInformation()
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseInfo_lnkEdit']"));
            }

            public bool? isPromotionalVideoPresent()
            {
                return objDriver.existsElement(By.XPath("//h3[contains(text(),'Promotional Video')]"));
            }

            public void ClickEdit_Summary()
            {
                objDriver.ClickEleJs(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
            }

            public void ClickEdit_AccessKey()
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessCodes_lnkEdit']"));
            }

            public string VerifySurveyPresent()
            {
                return objDriver.gettextofelement(By.XPath("//*[@id='MainContent_pnlContent']/div[2]/div[2]/div[2]/ul/li/span[1]"));
            }

            public void ClickEdit_Permissions()
            {
                objDriver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucPermissions_MHyperLink1']"));
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPermissions_MHyperLink1']"));
            }

            public void Edit_ScormCourseSetting()
            {
               objDriver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
                objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCourseSettings_MlinkEdit']"));
            }
        }



        public class CompletionCriteraiPortletCommand
        {
        private IWebDriver objDriver;
        public CompletionCriteraiPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool isTextDisplayed(string v)
            {
                return objDriver.existsElement(By.XPath("//h3[contains(.,'" + v + "')]"));
            }

            public bool? isMsgDisplayed(string v)
            {
                return objDriver.existsElement(By.XPath("//p[contains(.,'" + v + "')]"));
            }
        }

        public class ObjectivesCommand
        {
        private IWebDriver objDriver;
        public ObjectivesCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool isTextDisplayed(string v)
            {
                return objDriver.existsElement(By.XPath("//p[contains(.,'" + v + "')]"));
            }
        }

        public class CertificationPortletCommand
        {
        private IWebDriver objDriver;
        public CertificationPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool isTextDisplayed(string v)
            {
                return objDriver.existsElement(By.XPath("//h1[contains(.,'" + v + "')]"));
            }

            public bool? isBoldTextDisplayed(string v)
            {
                return objDriver.existsElement(By.XPath("//b[contains(.,'" + v + "')]"));
            }
        }

        public class RecertificationCriteriaPortletCommand
        {
        private IWebDriver objDriver;
        public RecertificationCriteriaPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void clickContentTitle(string v)
            {
                objDriver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
            }

            public bool? content(string v)
            {
                objDriver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
               return objDriver.GetElement(By.XPath("//a[contains(text(),'" + v + "')]")).Text.Equals(v);
            }

            public bool? isTextDisplayed(string v)
            {
                return objDriver.existsElement(By.XPath("//b[contains(.,'" + v + "')]"));
            }
        }

        public class CourseMaterialsCommand
        {
            public NoteModalCommand NoteModal { get { return new NoteModalCommand(objDriver); } }

            public ActionsCommand Actions
            {
                get { return new ActionsCommand(objDriver); }
            }

        private IWebDriver objDriver;
        public CourseMaterialsCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? IsFiledisplayed()
            {
                return objDriver.existsElement(By.XPath("//table[@id='table-completable-content']/tbody/tr/td"));
            }

            public void ClicktoOpenFile()
            {
                objDriver.ClickEleJs(By.LinkText("Open"));
            }

            public bool? FileOpened()
            {
               objDriver.selectWindow("https://prdct-mg-18-2.mksi-lms.net/cserver/section/notesb5256f655b0b44e382f2f9e3314d85a0/Test.txt");
               objDriver.SelectWindowClose();


                return true;
            }

            public bool? FileStatus(string v)
            {
                return objDriver.GetElement(By.LinkText("Open")).Text == v;
            }

            public bool? IsNoteDisplayed()
            {
                return objDriver.existsElement(By.XPath("//table[@id='table-completable-content']/tbody/tr/td"));
            }

            public void ClickToOpenNote()
            {
                objDriver.ClickEleJs(By.LinkText("Open"));
            }

            public bool? IsNoteModaldisplay()
            {
                return objDriver.existsElement(By.XPath("//div[@id='readNote']/div/div/div/h4"));
            }

            public bool? IsNoteModalIsClosed()
            {
                return objDriver.existsElement(By.XPath("//div[@id='readNote']/div/div/div/h4"));
            }

            public void ClicktoOpenDocument(string docName)
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + docName + "')]"));
            }

            public bool? VerifyTitle(string v)
            {
                return objDriver.GetElement(By.CssSelector("#table-completable-content > tbody > tr > td")).Text == v;

            }

            public bool? VerifyStatusIsOpened()
            {
                return objDriver.existsElement(By.XPath("//td[contains(text(),'Opened')]"));
            }

            public bool? VerifyActions(string v)
            {
                return objDriver.GetElement(By.XPath("//a[contains(text(),'Open')]")).Text == v;
            }

            public bool? isContentDisplayed()
            {
                return objDriver.GetElement(By.XPath("//table[@id='table-completable-content']/tbody/tr/td/a")).Displayed;
            }

            public void ClickContentButton()
            {
                objDriver.ClickEleJs(By.XPath("//table[@id='table-completable-content']/tbody/tr/td/a"));
            }

            public void ClickContent(string v)
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(text()," + v + ")]"));
            }
        }

        public class ActionsCommand
        {
        private IWebDriver objDriver;
        public ActionsCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ClickOpen()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Open')]"));
            }

            public void ClickEnrollButton()
            {
                throw new NotImplementedException();
            }



            public bool? isContentDisplayed()
            {
                return objDriver.GetElement(By.XPath("//table[@id='table-completable-content']/tbody/tr/td/a")).Displayed;
            }

            public void ClickContentButton()
            {
                objDriver.ClickEleJs(By.XPath("//table[@id='table-completable-content']/tbody/tr/td/a"));
            }
        }

        public class NoteModalCommand
        {
        private IWebDriver objDriver;
        public NoteModalCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ClickClose()
            {
                objDriver.ClickEleJs(By.XPath("//div[@id='readNote']/div/div/div[3]/button"));
            }
        }

        public class AssignmentWorkCommand
        {
        private IWebDriver objDriver;
        public AssignmentWorkCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? SubmitAssignment(string v1, string v2)
            {
                bool result = false;
                try
                {
                    objDriver.existsElement(By.XPath("//table[@id='table-gradeable-content']/tbody/tr/td[5]/a"));
                    objDriver.ClickEleJs(By.XPath("//table[@id='table-gradeable-content']/tbody/tr/td[5]/a"));
                    //objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    objDriver.GetElement(By.Id("txtAssignmentResponse")).Clear();
                    objDriver.GetElement(By.Id("txtAssignmentResponse")).SendKeysWithSpace(v1);
                    objDriver.GetElement(By.Id("MainContent_UC4_FormView1_txtComments")).Clear();
                    objDriver.GetElement(By.Id("MainContent_UC4_FormView1_txtComments")).SendKeysWithSpace(v2);
                    objDriver.ClickEleJs(By.Id("MainContent_UC4_btnSubmitAssignment"));
                   objDriver.findandacceptalert();

                }
                catch (Exception ex)
                {

                }
                return objDriver.getSuccessMessage() == "The item was submitted.";
            }
        }

        public  bool? isMarkCompleteButtonDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock']"));
        }

        public  void ClickOpenItem()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));
           objDriver.SelectWindowClose();

        }

        public  bool? VerifyVersion()
        {
            throw new NotImplementedException();
        }


    }

    public class SummaryCommand
    {
        private IWebDriver objDriver;
        public SummaryCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void ClickViewButton()
        {
            objDriver.ClickEleJs(By.Id("MainContent_header_FormView1_btnStatus"));
        }
    }

    public class Historywin
    {
    private IWebDriver objDriver;
    public Historywin(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? isfieldsdisplay(string testTitle, string v1, string v2)
        {
            objDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_AccessApprovalHistory_CNT_TITLE")).Text.Equals(testTitle);
            objDriver.existsElement(By.XPath("//tr[4]/td/span/label/span"));
            return objDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_AccessApprovalHistory_CurrentStatus")).Text.Equals("Pending");
        }
    }

    public class Bundle_ReviewsTab_Command
    {
    private IWebDriver objDriver;
    public Bundle_ReviewsTab_Command(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void isWriteaReviewButtondisplay()
        {
            throw new NotImplementedException();
        }

        public void WriteaReview(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }

    public class ReviewsTabCommand
    {
    private IWebDriver objDriver;
    public ReviewsTabCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? idEquvalenciesPortletDisplay()
        {
            if (objDriver.existsElement(By.XPath("//a[@class='font-semibold text-grey-darker block collapsed']")))
            {
                return true;
            }
            else if (objDriver.existsElement(By.XPath("//a[@class='font-semibold text-grey-darker block']")))
            {
                return true;
            }
            else
                return false;

        }
    }

    public class ScheduleTabContentPageCommand
    {
    private IWebDriver objDriver;
    public ScheduleTabContentPageCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public SectionPortletCommand SectionPortlet { get { return new SectionPortletCommand(objDriver); } }

        public void ClickMakeaschedusuggestionlink()
        {
            objDriver.ClickEleJs(By.Id("lnkInterest"));
        }

        public bool? isExpressInterestModalopened()
        {
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return objDriver.GetElement(By.Id("KendoUIMGDialog_wnd_title")).Text.Equals("Express Interest");
        }

        public bool? isMakeaschedusuggestionlinkdisplay()
        {
            return objDriver.existsElement(By.Id("lnkInterest"));
        }

        public bool? IsSectiondisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//h3[contains(text(),'Section1')]"));
        }

        public bool? isShotbyDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div/div[2]/div/div"));
        }

        public void Submitschedulesuggestion()
        {
            
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=1 | ]]
            objDriver.ClickEleJs(By.Id("MainContent_UC1_UI_REASON"));
            objDriver.select(By.Id("MainContent_UC1_UI_REASON"), "Need a different location");
           
           objDriver.FindElement(By.Id("MainContent_UC1_UI_SECTION_FORMAT_0")).Click();
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_popupButton")).Click();
           objDriver.FindElement(By.LinkText("7")).Click();
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_dateInput")).Clear();
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_dateInput")).SendKeys("");
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE")).Clear();
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE")).SendKeys("2019-10-07");
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput")).Click();
           objDriver.FindElement(By.LinkText("15")).Click();
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput")).Clear();
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput")).SendKeys("");
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE")).Clear();
           objDriver.FindElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE")).SendKeys("2019-10-15");
           objDriver.FindElement(By.Id("MainContent_UC1_UI_LOCATION")).Click();
           objDriver.FindElement(By.Id("MainContent_UC1_UI_LOCATION")).Clear();
           objDriver.FindElement(By.Id("MainContent_UC1_UI_LOCATION")).SendKeys("test");
           objDriver.FindElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO")).Click();
           objDriver.FindElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO")).Clear();
           objDriver.FindElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO")).SendKeys("test");
           objDriver.FindElement(By.Id("MainContent_UC1_btnSubmit")).Click();
        }

        public int TotlaSchedulesectionCount()
        {
            string sectionCount = objDriver.GetElement(By.XPath("//div[@id='scheduleTab']/div/div/h2")).Text;
            return objDriver.getIntegerFromString(sectionCount);
        }
    }

    public class SectionPortletCommand
    {
    private IWebDriver objDriver;
    public SectionPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickAddtoCartButton()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'Add to Cart')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Add to Cart')]"));
        }

        public void ClickCancelkWaitlistButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-danger mb-4']"));
        }

        public void ClickEnrollButton()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'Enroll')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Enroll')]"));
        }

        public void ClickRequestAccessbutton(string v)
        {
            objDriver.ClickEleJs(By.XPath("//h3[contains(text(),'" + v + "')]/following::a[contains(text(),'Request Access')]"));
        }

        public void ClickSectionlink()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='scheduleTab']//div[@class='panel-footer p-1']//a[1]"));
        }

        public bool? isAccessKeyfielddisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//input[@class='form-control access-key-input']"));
        }

        public bool? IsAddtoCartbuttonDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//a[contains(text(),'Add to Cart')]"));
        }

        public bool? isCancelEnrollmentlinkdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//a[@class='block text-danger'][contains(text(),'Cancel Enrollment')]"));
        }

        public bool? IsCancelRequestbuttondisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//strong[contains(text(),'" + v + "')]/following::a[contains(text(),'Cancel Request')]"));
        }

        public bool? IsCancelWaitlistbuttonDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn btn-danger mb-4']"));
        }

        public bool? IsEnrollbuttonDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//a[contains(text(),'Enroll')]"));
        }

        public bool? isEnrollmnetopeningInfoDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div[2]/div/div/div[3]/ul/li[2]"));
        }

        public bool? IsMoreeventdetailsDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']//div[@class='row m-0 mt-4']//div[1]//div[1]"));
        }

        public int isNumberofSeatAvailable()
        {
            string seataval = objDriver.GetElement(By.XPath("//div[@id='scheduleTab']/div[2]/div/div/div[3]/ul/li/span")).Text;
            return objDriver.getIntegerFromString(seataval);
        }

        public bool? IsRequestAccessbuttondisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//h3[contains(text(),'" + v + "')]/following::a[contains(text(),'Request Access')][2]"));
        }

        public bool? isScetioncodedisplay(string sectioncode)
        {
            return objDriver.GetElement(By.XPath("//div[@id='scheduleTab']/div[2]/div[2]/div/div/p")).Text.StartsWith("Section Code");
        }

        public bool? isSectionCostdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div[2]/div/div/div[3]/p"));
        }

        public bool? isSectionFullinfoDisplay()
        {
            return objDriver.existsElement(By.XPath("//*[contains(text(),'Section is full')]"));
        }

        public bool? isSectionnotesdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div[2]/div[2]/div/div[2]/div"));//note
        }

        public bool? isSectionrelatedinfodisplay(string v1, string v2, string v3, string v4, string v5)
        {
            objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div[2]/div[2]/div/div[2]/ul/li[2]"));//date
            objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div[2]/div[2]/div/div[2]/ul/li[3]"));//time
            objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div[2]/div[2]/div/div[2]/ul/li[4]")); //room
            objDriver.GetElement(By.XPath("//div[@id='scheduleTab']/div[2]/div[2]/div/div[2]/ul/li[4]/a")).Text.Contains("Map");
            return objDriver.existsElement(By.XPath("//div[@id='scheduleTab']/div[2]/div[2]/div/div[2]/ul/li[5]/ul/li"));//instructor
        }

        public bool? IsViewAllSectionlinkDisplay()
        {
            return objDriver.GetElement(By.XPath("//div[@id='scheduleTab']//div[@class='panel-footer p-1']//a[1]")).Displayed;
        }

        public bool? IsWaitlistbuttonDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn btn-default schedule-action mb-4']"));
        }

        public void RequestAccess_classroomsection()
        {
            try
            {
                
               objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
               objDriver.GetElement(By.Id("MainContent_UC1_fvAccessRequest_REQUEST_COMMENT")).SendKeysWithSpace("Testing Data");
                objDriver.ClickEleJs(By.Id("MainContent_UC1_RequestAccess"));
               objDriver.SwitchtoDefaultContent();
                //objDriver.IsElementVisible(By.XPath("//a[@class='btn btn-danger cancel-request']"));
                    
                
            }
            catch (Exception e)
            {

            }
        }
    }

    public class ClickAddtoCartPortletCommand
    {
    private IWebDriver objDriver;
    public ClickAddtoCartPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? isAddedtocardinfodisplay()
        {
            return objDriver.GetElement(By.XPath("//em[@class='text-muted']")).Text.StartsWith("Added to your cart on");
        }
    }

    public class OverviewTabCommnad
    {
    private IWebDriver objDriver;
    public OverviewTabCommnad(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public SurveyPortletCommand SurveyPortlet { get { return new SurveyPortletCommand(objDriver); } }

        public TrainingAssignmentPortletCommand TrainingAssignment { get { return new TrainingAssignmentPortletCommand(objDriver); } }

        public CostportletCommand Costportlet { get { return new CostportletCommand(objDriver); } }

        public CreditPortletCommand CreditPortlet { get { return new CreditPortletCommand(objDriver); } }

        public PrerequisiteportletCommand Prerequisiteportlet { get { return new PrerequisiteportletCommand(objDriver); } }

        public completioncodeModalcommand completioncodeModal { get { return new completioncodeModalcommand(objDriver); } }

        public NextavailableSectioncommand NextavailableSection { get { return new NextavailableSectioncommand(objDriver); } }

        public PartoftheseCollectionCommand PartoftheseCollection { get { return new PartoftheseCollectionCommand(objDriver); } }

        public RequestWaiverModalCommand RequestWaiverModal { get { return new RequestWaiverModalCommand(objDriver); } }

        public PrerequisitefortheseitemsCommand Prerequisitefortheseitems { get { return new PrerequisitefortheseitemsCommand(objDriver); } }

        public DescriptionPortletCommand DescriptionPortlet { get { return new DescriptionPortletCommand(objDriver); } }

        public AddtoCartportletCommand AddtoCartportlet { get { return new AddtoCartportletCommand(objDriver); } }

        public CertificationExpiriesCommand CertificationExpiries { get { return new CertificationExpiriesCommand(objDriver); } }

        public ReCertifyCommand ReCertify { get { return new ReCertifyCommand(objDriver); } }

        public bool? AccessKeyQuentitydisplay()
        {
            return objDriver.existsElement(By.XPath("//input[@id='hdnQuantity']"));
        }

        public void clicktoexpandPartoftheseCollectionPortlet()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(@href, '#partBlock')]"));
        }

        public void clickToexpandPrerequisitefortheseitems()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='overviewTab']/div/div/div[3]/div"));
        }

        public void click_AddtoCart()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Add to Cart')]"));
        }

        public bool? DescriptionPortletTest(string v)
        {
            objDriver.existsElement(By.XPath("//*[@id='overviewTab']/div/div[1]/div[1]/div"));
            return objDriver.GetElement(By.XPath("//*[@id='overviewTab']/div/div[1]/div[1]/div")).Text.Contains(v);
        }

        public bool? DescriptionPortletTitle(string v)
        {
            return objDriver.GetElement(By.XPath("//h2[contains(text(),'Description')]")).Text.Equals(v);
        }

        public void ExitInline()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='content-playlist-pdf']/div[2]/div/div/div/button"));
        }

        public bool? isAccessKeyfielddisplay()
        {
            return objDriver.existsElement(By.XPath("//input[@id='hdnQuantity']"));
        }

        public bool? isAddtoCartbuttondisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Add to Cart')]"));
        }

        public bool? isCertificationExpiriespaneldesplay()
        {
            return objDriver.existsElement(By.XPath("//div[@class='flex-1 text-center p-3']"));
        }

        public bool? isCertificationisgooddesplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(text(),'Certification good for')]"));
        }

        public bool? isComplistioncodelinkdisplay()
        {
            return objDriver.existsElement(By.LinkText("Enter your code to receive credit."));
        }

        public bool? iscontentOpenInline()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content-playlist-pdf']"));
        }

        public bool? isCourseProviderDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(text(),'Course Provider')]"));
        }

        public bool? isDescriptionDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='overviewTab']/div/div[2]/div"));
        }

        public bool? isDescriptiondisplayExpandedtillRight()
        {
            return objDriver.existsElement(By.ClassName("portlet shadow"));
        }

        public bool? isDurationDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(text(),'Duration')]"));
        }

        public bool? iseditContentDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Edit Content')]"));
        }

        public bool? isEquivalenciesDisplayed()
        {
            return objDriver.existsElement(By.XPath("//a[contains(@href, '#equivalenciesBlock')]"));
        }

        public bool? isMasteryScoredisplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(text(),'Mastery Score')]"));
        }

        public bool? isMaxAttempsdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(text(),'Maximum Attempts')]"));
        }

        public bool? isMorelikethisPortletDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='container-more-like-this']"));
        }

        public bool? isNextavailableSectiondisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='section-highlight']/div/div/div/div/h3"));
        }

        public bool? isNumberidQuestiondisplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(text(),'Questions')]"));
        }

        public bool? isPartoftheseCollectionDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(@href, '#partBlock')]"));
        }

        public bool isPrerequisitefortheseitems()
        {
            return objDriver.existsElement(By.XPath("//div[@id='overviewTab']/div/div/div[3]/div"));
        }

        public bool? isPrerequisitePortletDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='prerequisite-block']"));
        }

        public bool? isPromotionalVideodisplay()
        {
            return objDriver.existsElement(By.XPath("//body[@class='canvas']"));
        }

        public bool? isReCertiypaneldisplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(text(),'Re-certify')]"));
        }

        public bool? isRequestWaiverModalDisplay()
        {
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return objDriver.existsElement(By.Id("KendoUIMGDialog_wnd_title"));
        }

        public bool? isSaveButtonDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn-content-details-save btn btn-default transition']"));
        }

        public bool? isShareButtonDisplay()
        {
            return objDriver.existsElement(By.XPath("//button[@class='btn btn-default dropdown-toggle']"));
        }

        public bool? issurveyPortletisDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='surveysBlock']"));
        }

        public bool? isTrainingAssignmentportletDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='ta-due']//div[@class='panel-body']"));

        }

        public string NextavailableSectionTitle()
        {
            return objDriver.GetElement(By.XPath("//div[@id='section-highlight']/div/div/div/div/h3")).Text;
        }
    }

    public class ReCertifyCommand
    {
    private IWebDriver objDriver;
    public ReCertifyCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? Status(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@id='before-certified']/div[2]/span")).Text.Equals(v);
        }
    }

    public class CertificationExpiriesCommand
    {
    private IWebDriver objDriver;
    public CertificationExpiriesCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? Status(string v)
        {
            return objDriver.GetElement(By.XPath("//span[@class='block text-lg']")).Text.Equals(v);
        }
    }

    public class AddtoCartportletCommand
    {
    private IWebDriver objDriver;
    public AddtoCartportletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? isTestAddedtoCart()
        {
            return objDriver.GetElement(By.XPath("//em[@class='text-muted']")).Text.StartsWith("Added to your cart");
        }

        public bool? isViewOrderlinkdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'View Order')]"));
        }
    }

    public class DescriptionPortletCommand
    {
    private IWebDriver objDriver;
    public DescriptionPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickShowMoreLink()
        {
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-link btn-block btn-sm']"));
        }

        public bool? ShowlessLinkdisplay()
        {
            return objDriver.GetElement(By.XPath("//a[@class='btn btn-link btn-block btn-sm']")).Text.Equals("Show less");
        }

        public bool? ShowMoreLinkdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn btn-link btn-block btn-sm']"));
        }
    }

    public class PrerequisitefortheseitemsCommand
    {
    private IWebDriver objDriver;
    public PrerequisitefortheseitemsCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? isContentdisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'"+v+"')]"));
        }
    }

    public class RequestWaiverModalCommand
    {
    private IWebDriver objDriver;
    public RequestWaiverModalCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void Submitrequestwaiver()
        {
           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.XPath("//span/input"));//select first record
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }

    public class PartoftheseCollectionCommand
    {
    private IWebDriver objDriver;
    public PartoftheseCollectionCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void expandPartofthesecollection()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(@href, '#partBlock')]"));
        }

        public bool? isContentdisplay(string v)
        {
            Thread.Sleep(3000);
            return objDriver.GetElement(By.XPath("//a[contains(@href, '#partBlock')]/following::div[1]")).Text.StartsWith(v);
        }
    }

    public class NextavailableSectioncommand
    {
    private IWebDriver objDriver;
    public NextavailableSectioncommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? isEnrollbuttondisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4'][contains(text(),'Enroll')]"));
        }

        public bool? isSectionCodedisplay()
        {
            return objDriver.GetElement(By.XPath("//div[@id='section-highlight']/div/div/div/div/p")).Text.StartsWith("Section Code");
        }

        public bool? isSectionrelatedinfodisplay(string v1, string v2, string v3, string v4, string v5)
        {
            objDriver.existsElement(By.XPath("//div[@id='section-highlight']/div/div/div/div[2]/ul/li[2]"));//date
            objDriver.existsElement(By.XPath("//div[@id='section-highlight']/div/div/div/div[2]/ul/li[3]"));//time
            objDriver.existsElement(By.XPath("//div[@id='section-highlight']/div/div/div/div[2]/ul/li[4]"));//location
            objDriver.existsElement(By.XPath("//a[contains(text(),'(Map)')]"));//map
            return objDriver.existsElement(By.XPath("//div[@id='section-highlight']/div/div/div/div[2]/ul/li[5]/ul/li")); //instructer
        }

        public bool? isSectionTitledisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='section-highlight']/div/div/div/div/h3"));
        }
    }

    public class completioncodeModalcommand
    {
    private IWebDriver objDriver;
    public completioncodeModalcommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public string message()
        {
            return objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/div")).Text;
        }
    }

    public class PrerequisiteportletCommand
    {
    private IWebDriver objDriver;
    public PrerequisiteportletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickPrerequisiteContentTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//ul[@class='list-unstyled mt-2']//a[1]"));
        }

        public void ClickRequestWaiverlink()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='lnkWaiver']"));
        }

        public bool? iscomplted()
        {
            Thread.Sleep(5000);
            return objDriver.GetElement(By.XPath("//div[@id='prerequisite-block']/h2/span")).Text.Equals("Completed");

        }

        public bool isContentdisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//a[contains(.,'" + v + "')]"));
        }

        public bool? isHeadershowes(string v)
        {
            return objDriver.GetElement(By.XPath("//p[@class='mb-0']")).Text.Contains(v);
        }

        public bool isPortletheadershowes(string v)
        {
            objDriver.existsElement(By.XPath("//p[@class='mb-0']"));
            string requiredcount = objDriver.GetElement(By.XPath("//p[@class='mb-0']")).Text;
            int requiredcount1 = objDriver.getIntegerFromString(requiredcount);
            if (objDriver.GetElement(By.XPath("//p[@class='mb-0']")).Text.StartsWith(v) || requiredcount1 == 2)
            {
                return true;
            }
            else
                return false;
           
        }

        public bool? isPrerequisiteCostDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='prereqs-block']/ul/li/span/span[2]"));
        }

        public bool? isPrerequisiteStatusDisplayed()
        {
            return objDriver.existsElement(By.XPath("//span[@class='prerequisite-status']"));
        }

        public bool? isPrerequisiteTitleDisplayed()
        {
            return objDriver.existsElement(By.XPath("//ul[@class='list-unstyled mt-2']//a[1]"));
        }
    }

    public class CreditPortletCommand
    {
    private IWebDriver objDriver;
    public CreditPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public int isCreditScoreDisplay()
        {
            string Creditscore = objDriver.GetElement(By.XPath("//li[@class='mb-2']")).Text;
            return objDriver.getIntegerFromString(Creditscore);
        }
    }

    public class CostportletCommand
    {
    private IWebDriver objDriver;
    public CostportletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickViewOrderlink()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'View Order')]"));
        }

        public bool? isViewOrderlinkDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'View Order')]"));
        }
    }

    public class TrainingAssignmentPortletCommand
    {
    private IWebDriver objDriver;
    public TrainingAssignmentPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? isDuedatedisplay()
        {
            return objDriver.existsElement(By.XPath("//*[contains(text(),'Training Due Dates')]/following::strong[1]"));
        }
    }

    public class GeneralCourse_ReviewsTabCommand
    {
    private IWebDriver objDriver;
    public GeneralCourse_ReviewsTabCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void DeleteReview()
        {
            objDriver.ClickEleJs(By.XPath("//span[@class='fa fa-close']"));
            Thread.Sleep(5000);
        }

        public bool? isEditReviewlinkdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='small']"));
        }

        public bool? isPaginationdisplay()
        {
            return objDriver.existsElement(By.XPath("//ul[@class='pagination']"));
        }

        public bool? isReviewlistUpdated(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@id='content-reviews']/ul/li/h3")).Text.Equals(v);
        }

        public bool? isWriteaReviewButtondisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Write a review')]"));
        }

        public int reviewcount()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'Reviews')]"));
            string reviewcount = objDriver.GetElement(By.XPath("//a[contains(text(),'Reviews')]")).Text;
            return objDriver.getIntegerFromString(reviewcount);
        }

        public void WriteaReview(string title, string feedbackText)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Write a review')]"));
           objDriver.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
            Thread.Sleep(10000);
            //objDriver.ClickEleJs(By.Id("MainContent_UC1_fvRateContent_CNTRTG_RATING"));
            // objDriver.select(By.Id("MainContent_UC1_fvRateContent_CNTRTG_RATING"), "4 Stars");
            IWebElement Title = objDriver.GetElement(By.XPath("//input[contains(@id,'TITLE')]"));
            Title.ClickWithSpace();
            Title.SendKeysWithSpace(title);
            objDriver.GetElement(By.XPath("//textarea[contains(@id,'REVIEW')]")).SendKeysWithSpace(feedbackText);
            objDriver.ClickEleJs(By.XPath("//input[@value='Save']"));

        }
    }

    public class ContentBannerCommand
    {
        public ContextDrivenMessageCommand ContextDrivenMessage { get { return new ContextDrivenMessageCommand(objDriver); } }

    private IWebDriver objDriver;
    public ContentBannerCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }


    public bool? AccessPeriodtext(string v)
        {
            objDriver.existsElement(By.Id("access-message"));
            return objDriver.GetElement(By.Id("access-message")).Text.StartsWith(v);
        }

        public void ClickOpenItembutton()
        {
            objDriver.ClickEleJs(By.XPath("//span[@id='quick-play-text']"));
        }

        public void ClickRetakeLink()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='newAttempt']"));
        }

        public void clickReviewButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='reviewAttempt']"));
        }

        public void CLickScheduleButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'View Schedule')]"));
        }

        public void ClickTakeTest()
        {
            objDriver.ClickEleJs(By.XPath("//span[@id='quick-play-text']"));
        }

        public void clickViewCertificateButton()
        {
            objDriver.ClickEleJs(By.LinkText("View Certificate"));
        }

        public void ClickViewContentButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'View Content')]"));
        }

        public void ClickViewRequestHistory()
        {
            objDriver.ClickEleJs(By.XPath("//a[@class='block text-white hover:text-white focus:text-white font-semibold']"));
        }

        public void clickViewScheduleButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'View Schedule')]"));
        }

        public void Click_CancelEnrollmetlink()
        {
            objDriver.ClickEleJs(By.LinkText("Cancel Enrollment"));

           objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            if (objDriver.existsElement(By.Id("MainContent_UC1_tbUnenrollReason")))
            {
                objDriver.GetElement(By.Id("MainContent_UC1_tbUnenrollReason")).SendKeysWithSpace("test");
                objDriver.ClickEleJs(By.Id("MainContent_UC1_btnCancelEnrollment"));
            }
        }

        public void click_continuebutton()
        {
            if (objDriver.existsElement(By.XPath("//span[@id='quick-play-text']")))
            {
                objDriver.ClickEleJs(By.XPath("//span[@id='quick-play-text']"));
            }
            else if (objDriver.existsElement(By.XPath("//a[@id='reviewAttempt']")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='reviewAttempt']"));
            }
        }

        public void Click_Enrollbutton()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Enroll')]"));
        }

        public void Click_recertificationLink()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='newAttempt']"));
        }

        public void Click_ScheduleButton()
        {
            objDriver.existsElement(By.LinkText("View Schedule"));
            objDriver.ClickEleJs(By.LinkText("View Schedule"));
        }

        public void Click_Startbutton()
        {
            if(objDriver.existsElement(By.XPath("//a[@id='quick-play']")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@id='quick-play']"));
            }
            else if (objDriver.existsElement(By.XPath("//a[@class='btn btn-primary btn-lg']")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-primary btn-lg']"));
            }
            

        }

        public void Click_TakeSurveybutton()
        {
            if(objDriver.existsElement(By.XPath("//span[@id='quick-play-text']")))
            {
                objDriver.ClickEleJs(By.XPath("//span[@id='quick-play-text']"));
            }
            else if(objDriver.existsElement(By.XPath("//a[@id='reviewAttempt']"))) ////a[@id='reviewAttempt']
            {
                objDriver.GetElement(By.XPath("//a[@id='reviewAttempt']")).ClickWithSpace();
            }
        }

        public void CloseOpenedDocumentwindow()
        {
            Thread.Sleep(3000);
            string wdwHandle =objDriver.CurrentWindowHandle;
            IList<string> wdwTitle =objDriver.WindowHandles;

            foreach (string dr in wdwTitle)
            {
               objDriver.SwitchTo().Window(dr);
                if (objDriver.Title == "Google")
                {
                   objDriver.Close();
                   objDriver.SwitchTo().Window(wdwHandle);

                }

            }
        }

        public void CloseOpenedTestwindow()
        {
            //objDriver.SelectWindowClose1("SCORM Debug Window");
            //objDriver.SelectWindowClose1("SCORM Debug Window");
            //objDriver.SwitchWindow("Meridian Global - Core Domain");
            //objDriver.selectWindow("Meridian Global - Core Domain");
            //Thread.Sleep(5000);
           objDriver.waitforframe(By.Id("tocFrame"));
            Thread.Sleep(5000);
            //objDriver.ClickEleJs(By.XPath("//u[contains(.,'" + v + "')]"));
            //objDriver.SwitchTo().DefaultContent();
            //objDriver.waitforframe(By.Id("contentFrame"));
            //objDriver.ClickEleJs(By.XPath("//input[@id='q1true']"));
            //objDriver.ClickEleJs(By.Id("Submit"));
            //objDriver.ClickEleJs(By.Id("Submit"));
            //objDriver.SwitchTo().DefaultContent();
           objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
        }

        public string ContentProgress()
        {
            objDriver.existsElement(By.XPath("//div[@id='content-progress']"));
            return objDriver.GetElement(By.XPath("//div[@id='content-progress']")).Text;
        }

        public bool? isAccessperiodflag()
        {
            return objDriver.existsElement(By.XPath("//p[@id='access-message']"));
        }

        public bool? isAccessperiodflagMessage(string v)
        {
            return objDriver.GetElement(By.XPath("//p[@id='access-message']")).Text.StartsWith(v);
        }

        public bool? isAccessPeriodmessagedisplay()
        {
            return objDriver.existsElement(By.Id("access-message"));
        }

        public bool? isCancelEnrolllinkDisplay_GeneralCourse()
        {

            return objDriver.existsElement(By.LinkText("Cancel Enrollment"));
        }

        public bool? isCancelEnrollmentLinkDisplay()
        {
            return objDriver.existsElement(By.LinkText("Cancel Enrollment"));
        }

        public bool? isCancleRequestbuttonDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn btn-danger cancel-request']"));
        }

        public bool iscompleteitemmessage(string v)
        {
            objDriver.existsElement(By.XPath("//strong[@class='block text-lg font-normal mb-1']"));
            return objDriver.GetElement(By.XPath("//strong[@class='block text-lg font-normal mb-1']")).Text.StartsWith(v);
        }

        public string iscompleteitemmessage()
        {
            throw new NotImplementedException();
        }

        public bool? isContentImagedisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='details_banner']/div/div/div/div"));
        }

        public bool? isContentProgressbarDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content-progress']"));
        }

        public bool? isContentTitledisplay(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@id='details_banner']/div/div/div/div/h1")).Text.Equals(v);
        }

        public bool? isContentTypedisplay()
        {
            return objDriver.GetElement(By.XPath("//div[@id='details_banner']/div/div/div/div/p")).Displayed;
        }

        public bool? isContinueButtonDisplsplay()
        {
            if (objDriver.existsElement(By.XPath("//span[@id='quick-play-text']")))
            {
                return true;
            }
            else if (objDriver.existsElement(By.XPath("//a[@id='reviewAttempt']")))
            {
                return true;
            }
            else
                return false;
        }

        public bool? isOpenItembuttonDisplay()
        {
            if (objDriver.existsElement(By.XPath("//a[contains(text(),'Enroll')]")))
            {
                return true;
            }
            else if (objDriver.existsElement(By.XPath("//span[@id='quick-play-text']")))
            {
                return true;
            }
            else
                return false;
        }

        public bool? isInstructionalMessage(string v)
        {
            objDriver.existsElement(By.XPath("//p[@id='enroll-message']"));
            return objDriver.GetElement(By.XPath("//p[@id='enroll-message']")).Text.Equals(v);
        }

        public bool? isMarkCompleteLinkdisplay()
        {
            return objDriver.existsElement(By.Id("markCompleteBtn"));
        }

        public bool? isMessagedisplay(string v)
        {
            return objDriver.GetElement(By.XPath("//*[@id='prerequisite-block']/h2/span")).Text.Contains(v);

        }

        public bool? isOpenItembuttonDisplay_GeneralCourse()
        {
            return objDriver.existsElement(By.XPath("//span[@id='quick-play-text']"));
        }

        public bool? isPrereqisiteRequiredmessageDisplay(string v)
        {
            return objDriver.GetElement(By.XPath("//p[@id='prereq-prompt-continue']")).Text.Equals(v);
        }

        public bool? isRequestAccessbuttondisplay()
        {
            return objDriver.existsElement(By.LinkText("Request Access"));
        }

        public bool? isRetakeLinkDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@id='newAttempt']"));
        }

        public bool? isReTakeSurveylinkDisplsplay()
        {
            return objDriver.existsElement(By.XPath("//a[@id='newAttempt']"));
        }

        public bool? isReviewButtonDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@id='reviewAttempt']"));
        }

        public bool? isReviewLinkDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@id='reviewAttempt']"));
        }

        public bool? isStartbuttonDisplay()
        {
            if (objDriver.existsElement(By.XPath("//a[@class='btn btn-primary btn-lg']")))
            {
                return true;
            }
            else if (objDriver.existsElement(By.XPath("//span[@id='quick-play-text']")))
            {
                return true;
            }
            else return false;
            
        }

        public bool? isStart_recertificationLinkdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@id='newAttempt']"));
        }

        public bool? isTakeSurveyButtonDisplay()
        {
            if (objDriver.existsElement(By.XPath("//span[@id='quick-play-text']")))
            {
                return objDriver.GetElement(By.XPath("//span[@id='quick-play-text']")).Text.Equals("Take Survey");
            }
           else if(objDriver.existsElement(By.XPath("//a[@id='reviewAttempt']")))
            {
                return objDriver.GetElement(By.XPath("//a[@id='reviewAttempt']")).Text.Equals("Take Survey");
            }
            else { return false; }
        }

        public bool? isTakeTestButtonDisplay()
        {
            return objDriver.existsElement(By.XPath("//span[@id='quick-play-text']"));
        }

        public bool? isViewCertificationButtonDisplay()
        {
            return objDriver.existsElement(By.LinkText("View Certificate"));
        }

        public bool? isViewContentButtonDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'View Content')]"));
        }

        public bool? IsViewScheduleButtonDisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'View Schedule')]"));
        }

        public void MarkCompleteforDoc()
        {
            objDriver.existsElement(By.Id("markCompleteBtn"));
            objDriver.ClickEleJs(By.Id("markCompleteBtn"));
            //objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            // objDriver.ClickEleJs(By.Id("MainContent_UC1_btnMarkComplete"));
            Thread.Sleep(2000);
        }

        public bool? RequiredSurveymessage(string v)
        {
            Thread.Sleep(5000);
            return objDriver.GetElement(By.XPath("//p[@id='survey-prompt']")).Text.Contains(v);

        }

        public bool? verifymessage(string v)
        {
            
            string message=objDriver.GetElement(By.XPath("//p[@id='completed-message']")).Text;

            if (v.Equals(message)) {
                return true;
            }
            return false;
        }

        public bool? isEnrollButtondisplay()
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'Enroll')]"));
        }
    }

    public class ContextDrivenMessageCommand
    {
    private IWebDriver objDriver;
    public ContextDrivenMessageCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? AfterContentStart(string v)
        {
            Thread.Sleep(5000);
            return objDriver.GetElement(By.XPath("//strong[@class='block text-lg font-normal mb-2']")).Text.Equals(v);
        }

        public bool? BeforeStart(string v)
        {
            return objDriver.GetElement(By.XPath("//span[@class='block mb-2']")).Text.Equals(v);
        }

        public bool? InProgressContentTitle(string v)
        {
            return objDriver.GetElement(By.XPath("//span[@id='content-to-play']")).Text.Equals(v);
        }

        public bool? PendingforApproval(string v)
        {
            Thread.Sleep(5000);
            return objDriver.GetElement(By.XPath("//p[@id='pending-approval']")).Text.Equals(v);
        }

        public bool? Suspended(string v)
        {
            return objDriver.GetElement(By.XPath("//p[@id='suspended-prompt']")).Text.StartsWith(v);
        }
    }

    public class Contenttabcommand
    {
    private IWebDriver objDriver;
    public Contenttabcommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public Assignedworkcommand Assignedwork { get { return new Assignedworkcommand(objDriver); } }

        public Coursematerialcommand Coursematerial { get { return new Coursematerialcommand(objDriver); } }

        public RequiredContentCommand RequiredContent { get { return new RequiredContentCommand(objDriver); } }

        public CurriculumBlockCommand CurriculumBlock { get { return new CurriculumBlockCommand(objDriver); } }

        public CurriculumUnOrderedBlockCommand CurriculumUnOrderedBlock { get { return new CurriculumUnOrderedBlockCommand(objDriver); } }

        public CurriculumOrderedBlockCommand CurriculumOrderedBlock { get { return new CurriculumOrderedBlockCommand(objDriver); } }

        public CoreCertificationCommand CoreCertification { get { return new CoreCertificationCommand(objDriver); } }

        public AlternetOptionCommand AlternetOption { get { return new AlternetOptionCommand(objDriver); } }

        public RecertificationCriteriaCommand RecertificationCriteria { get { return new RecertificationCriteriaCommand(objDriver); } }

        public void clickFindQualifyingContent()
        {
            objDriver.existsElement(By.LinkText("Find Qualifying Content"));
            objDriver.ClickEleJs(By.LinkText("Find Qualifying Content"));
        }

        public void ExpandCurriculumBlock()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='blockHeading1']/div/div/h4/a/span"));
        }

        public bool? isAlternetOptionportletdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='contentTab']/div[2]/div/div/div"));
        }

        public bool? isAssignedworksectiondisplay()
        {
            return objDriver.GetElement(By.XPath("//a[contains(@href, '#block1')]")).Text.StartsWith("Assigned Work");
        }

        public bool? isContentDurationdisplay(string v1, string v2)
        {
           // return objDriver.existsElement(By.XPath("//span[contains(text(),'" + v1 + "')]/following::span[text()='(" + v2 + " hours)']"));
            return objDriver.existsElement(By.XPath("//span[@class='text-muted small font-normal']"));
            ////span[contains(text(),'SRGC-1211')]/following::span[text()='(10 hours)']
        }

        public bool? isCoursematerialsectiondisplay()
        {
            return objDriver.existsElement(By.LinkText("Course Materials"));

        }

        public bool? isFindQualifyingContentbuttondisplay()
        {
            return objDriver.existsElement(By.LinkText("Find Qualifying Content"));
        }

        public bool? isRecertificationCriteriaportletdisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='block color-default no-underline font-semibold']"));
        }
    }

    public class RecertificationCriteriaCommand
    {
    private IWebDriver objDriver;
    public RecertificationCriteriaCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? Actionbuttondisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn btn-default start-actions play-link']"));
        }

        public void ClickEnroll(string v)
        {
            objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[contains(.,'Enroll')][1]"));
            objDriver.GetElement(By.XPath("//span[contains(text(),'"+v+"')]/following::div[contains(.,'Enroll')][1]")).ClickWithSpace();
        }

        public bool? ContentTitledisplay(string v)
        {
            return objDriver.GetElement(By.XPath("//span[@class='content-title']")).Text.Contains(v);
        }

        public bool? isStartbuttondisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[contains(.,'Start')][2]"));
        }

        public bool? otherActionbuttondisplay(string v1, string v2="", string v3="")
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v1 + "')]/following::div[2]"));
            if (objDriver.GetElement(By.LinkText("Continue")).Text.Equals(v2) || objDriver.GetElement(By.LinkText("Mark Complete")).Text.Equals(v3))
            {
                return true;
            }
            else return false;
        }

        public void SelectMarkComplete(string v)
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='designatedItems']/ul/li/div/div[3]/div/div/button/span"));
            objDriver.ClickEleJs(By.XPath("//div[@id='designatedItems']/ul/li/div/div[3]/div/div/ul/li/a"));
            Thread.Sleep(3000);
        }

        public void StarContentandClose(string v)
        {
            objDriver.existsElement(By.XPath("//span[contains(text(),'"+v+"')]/following::div[contains(.,'Start')][2]"));
            objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[contains(.,'Start')][1]")).ClickWithSpace();
            Thread.Sleep(3000);
            string wdwHandle =objDriver.CurrentWindowHandle;
            IList<string> wdwTitle =objDriver.WindowHandles;

            foreach (string dr in wdwTitle)
            {
               objDriver.SwitchTo().Window(dr);
                if (objDriver.Title == "Google")
                {
                   objDriver.Close();
                   objDriver.SwitchTo().Window(wdwHandle);

                }

            }
        }
    }

    public class AlternetOptionCommand
    {
    private IWebDriver objDriver;
    public AlternetOptionCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? Actionbuttondisplay(string title)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + title + "')]/following::div[2]"));
        }

        public void ClickEnroll(string v)
        {
            objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]")).ClickWithSpace();
        }

        public bool? ContentTitledisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]"));
        }

        public bool? ContentTypedisplay(string title)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + title + "')]/following::span[1]"));
        }

        public bool? isCountdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[contains(@class,'block-count')]"));
        }

        public bool? isStartbuttondisplay(string v)
        {
            return objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]")).Text.Equals("Start");
        }

        public bool? otherActionbuttondisplay(string v1, string v2="", string v3="")
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v1 + "')]/following::div[2]"));
            if (objDriver.GetElement(By.LinkText("Continue")).Text.Equals(v1) || objDriver.GetElement(By.LinkText("Mark Complete")).Text.Equals(v2))
            {
                return true;
            }
            else return false;
        }

        public void SelectMarkComplete(string v)
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]"));
            objDriver.ClickEleJs(By.LinkText("Mark Complete"));
            Thread.Sleep(3000);
        }

        public void StarContentandClose(string v)
        {
            if (objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]")))
            {
                objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]")).ClickWithSpace();
            }
          
            Thread.Sleep(3000);
            string wdwHandle =objDriver.CurrentWindowHandle;
            IList<string> wdwTitle =objDriver.WindowHandles;

            foreach (string dr in wdwTitle)
            {
               objDriver.SwitchTo().Window(dr);
                if (objDriver.Title == "Google")
                {
                   objDriver.Close();
                   objDriver.SwitchTo().Window(wdwHandle);

                }

            }

        }
    }

    public class CoreCertificationCommand
    {
    private IWebDriver objDriver;
    public CoreCertificationCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? Actionbuttondisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn btn-default start-actions play-link']"));
        }

        public void ClickContentTitle(string v)
        {
            objDriver.existsElement(By.XPath("//span[@class='content-title']"));
            objDriver.ClickEleJs(By.XPath("//span[@class='content-title']"));
        }

        public void ClickEnroll(string v)
        {
            objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[contains(.,'Enroll')][1]")).ClickWithSpace();
        }

        public void ClickStart(string v)
        {
            objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[contains(.,'Start')][2]")).ClickWithSpace();
        }

        public bool? ContentImagedisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='designatedItems']/ul/li/div/div/a/div"));
        }

        public bool? contentnotcompletedmessagedisplay()
        {
            return objDriver.existsElement(By.XPath("//p[contains(text(),'There is no content completed yet.')]"));
        }

        public bool? ContentTitledisplay(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@id='designatedItems']/ul/li/div/div/a/span")).Text.Contains(v);
        }

        public bool? ContentTypedisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='designatedItems']/ul/li/div/div/span"));
        }

        public bool? isStartbuttondisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[contains(.,'Start')][2]"));
        }

        public bool? otherActionbuttondisplay(string v, string v1="", string v2="")
        {
            objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]")).ClickWithSpace();
            if (objDriver.GetElement(By.LinkText("Continue")).Text.Equals(v1) || objDriver.GetElement(By.LinkText("Mark Complete")).Text.Equals(v2))
            {
                return true;
            }
            else return false;
        }

        public bool? ReviewActionbuttondisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@class='btn btn-default play-link']"));
        }

        public void SelectMarkComplete(string v)
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]"));
            objDriver.ClickEleJs(By.LinkText("Mark Complete"));
            Thread.Sleep(3000);
        }

        public void StarContentandClose(string v)
        {
            objDriver.GetElement(By.XPath("//span[contains(text(),'" + v + "')]/following::div[2]")).ClickWithSpace();
            Thread.Sleep(3000);
            string wdwHandle =objDriver.CurrentWindowHandle;
            IList<string> wdwTitle =objDriver.WindowHandles;

            foreach (string dr in wdwTitle)
            {
               objDriver.SwitchTo().Window(dr);
                if (objDriver.Title == "Google")
                {
                   objDriver.Close();
                   objDriver.SwitchTo().Window(wdwHandle);

                }

            }
        }
    }

    public class CurriculumOrderedBlockCommand
    {
    private IWebDriver objDriver;
    public CurriculumOrderedBlockCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? BannerCompletionContentCount(string v)
        {
            objDriver.existsElement(By.XPath("//a[text()='Ordered']/following::div[1]"));
            return objDriver.GetElement(By.XPath("//a[text()='Ordered']/following::div[2]")).Text.EndsWith(v);
        }

        public bool? BannerCompletionText(string v)
        {
            objDriver.existsElement(By.XPath("//a[text()='Ordered']/following::div[1]"));
            return objDriver.GetElement(By.XPath("//a[text()='Ordered']/following::div[1]")).Text.Equals(v);
        }
    }

    public class CurriculumUnOrderedBlockCommand
    {
    private IWebDriver objDriver;
    public CurriculumUnOrderedBlockCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? BannerCompletionContentCount(string v)
        {
            objDriver.existsElement(By.XPath("//a[text()='UnOrdered']/following::div[1]"));
            return objDriver.GetElement(By.XPath("//a[text()='UnOrdered']/following::div[2]")).Text.EndsWith(v);
        }

        public bool? BannerCompletionText(string v)
        {
            objDriver.existsElement(By.XPath("//a[text()='UnOrdered']/following::div[1]"));
           return  objDriver.GetElement(By.XPath("//a[text()='UnOrdered']/following::div[1]")).Text.Equals(v);
        }
    }

    public class CurriculumBlockCommand
    {
    private IWebDriver objDriver;
    public CurriculumBlockCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickContenttitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(.,'" + v + "')]"));
        }

        public bool? iscontentdisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//span[contains(.,'" + v + "')]"));
        }
    }

    public class RequiredContentCommand
    {
    private IWebDriver objDriver;
    public RequiredContentCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickContentEnroll(string v)
        {
            //objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v + "')]/following::a[contains(text(),'Enroll')]"));
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-default start-actions play-link']"));
        }

        public void ClickContentStart(string v)
        {
           // objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::a[contains(text(),'Start')]"));
            //objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v + "')]/following::a[contains(text(),'Start')]"));
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-default start-actions play-link']"));
        }
        

        public bool? isContentStartdisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::a[contains(text(),'Start')]"));
           // objDriver.ClickEleJs(By.XPath("//span[contains(text(),'" + v + "')]/following::a[contains(text(),'Start')]"));
        }

        public void CompleteBundleContent()
        {
            Thread.Sleep(3000);
            string wdwHandle =objDriver.CurrentWindowHandle;
            IList<string> wdwTitle =objDriver.WindowHandles;

            foreach (string dr in wdwTitle)
            {
               objDriver.SwitchTo().Window(dr);
                if (objDriver.Title == "Google")
                {
                   objDriver.Close();
                   objDriver.SwitchTo().Window(wdwHandle);

                }

            }
            objDriver.existsElement(By.Id("markCompleteBtn"));
            objDriver.ClickEleJs(By.Id("markCompleteBtn"));
        }

        public bool? isAddtocarddisplayfor(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isContentReviewdisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::a[contains(text(),'Review')]"));
        }

        public bool? isContentRetakeisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'" + v + "')]/following::a[contains(text(),'Retake')]"));
        }
    }

    public class Coursematerialcommand
    {
    private IWebDriver objDriver;
    public Coursematerialcommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? coursetypeandaccessbuttondisplay()
        {
            objDriver.existsElement(By.XPath("//div[@id='block2']/ul/li/div/div/span"));//content type
            return objDriver.existsElement(By.XPath("//div[@id='block2']/ul/li/div/div[3]/div/div/a")); //start or retake or review
        }
    }

    public class Assignedworkcommand
    {
    private IWebDriver objDriver;
    public Assignedworkcommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? isduedateandgreaddisplay()
        {
            objDriver.existsElement(By.XPath("//div[@id='block1']/ul/li/div/div[2]/span")); //due date
            return objDriver.existsElement(By.XPath("//div[@id='block1']/ul/li/div/div[3]"));//greade
        }
    }

    public class CourseInformationPortletCommand
    {
    private IWebDriver objDriver;
    public CourseInformationPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }

    public bool? duration(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucCourseInfo_pnlCourseInfo']/ul/li[3]/strong")).Text.Equals(v);
        }
    }

    public class ViewAllAttemptsModalCommand
    {
    private IWebDriver objDriver;
    public ViewAllAttemptsModalCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? VerifyAttempts()
        {
            return objDriver.existsElement(By.XPath("//tr[2]"));
        }
    }

    public class HistoryTabCommand
    {
    private IWebDriver objDriver;
    public HistoryTabCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? isViewCertificateButtonDisplay()
        {
            if (objDriver.existsElement(By.XPath("//div[@id='historyTab']/div/ul/li/a")))
            {
                return objDriver.GetElement(By.XPath("//div[@id='historyTab']/div/ul/li/a")).Text.Contains("View Certificate");
            }
            else
                return false;
        }
        public bool? VerifyRestartedCurriculum()
        {
            objDriver.existsElement(By.XPath("//div[@id='historyTab']//li[1]"));
            return objDriver.GetElement(By.XPath("//li[@class='restart']")).Text.Contains("Restarted");
        }
        public bool? verifydate()
        {
            
            string text = objDriver.GetElement(By.XPath("//span[@class='timestamp']")).Text;
            string s2 = text.IndexOf("\r\n").ToString();
            string output = text.Substring(0, int.Parse(s2));
            //DateTime date = DateTime.Now;
            //string Systemtime = string.Format("{0:d}", date);
            string Systemtime = DateTime.Now.ToString("M'/'d'/'yyyy");

            return output.Equals(Systemtime);
            
        }

        public bool? VerifyEnrolledinSection(string v)
        {
            return objDriver.GetElement(By.LinkText(v)).Displayed;
        }

        public bool? VerifyEnrolledinSectionwithAccessKey()
        {
            return objDriver.existsElement(By.XPath("//div[@id='historyTab']/div/ul/li/span[2]"));
        }

        public bool? VerifyEnrollstatus()
        {

            return objDriver.existsElement(By.XPath("//li[contains(.,'Enrolled')]"));
        }

        public bool? Verifystatrtedstatus()
        {
            return objDriver.existsElement(By.XPath("//*[@class='complete']"));
        }

        public bool? verifyViewDetailslink()
        {
            return objDriver.existsElement(By.XPath("//a[contains(.,'View Details')]"));
        }

        public bool? isStatusDisplay(string v)
        {
            if (v == "Started")
            {
                objDriver.existsElement(By.XPath("//li[contains(.,'Started')]"));
                return objDriver.GetElement(By.XPath("//li[contains(.,'Started')]")).Text.Contains(v);
            }
            else if (v == "Completed")
            {
                objDriver.existsElement(By.XPath("//li[contains(.,'Completed')]"));
                return objDriver.GetElement(By.XPath("//li[contains(.,'Completed')]")).Text.Contains(v);
            }
            else
                return false;
        }

        public bool? isTestfailed()
        {
            return objDriver.existsElement(By.XPath("//li[@class='failed']"));
        }

        public bool? isTestScoredisplay()
        {
            return objDriver.existsElement(By.XPath("//strong[@class='mr-1']"));
        }

        public bool? isRestarteddisplay()
        {
            return objDriver.existsElement(By.XPath("//li[@class='restart']"));
        }
    }




    public class CurriculumContentTabCommand
    {
    private IWebDriver objDriver;
    public CurriculumContentTabCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickCurriculumContentBlock()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='blockHeading1']/div/div/h4/a"));
        }

        public void ClickStartGeneralCourse(string v)
        {
            objDriver.ClickEleJs(By.XPath("//span[text()='" + v + "']/following::button[1]"));
        }



        public bool? VerifyStartButtonDisplayed(string v)
        {
            return objDriver.GetElement(By.XPath("//span[text()='" + v + "']/following::button[1]")).Displayed;
        }

        public bool? VerifyStatus(string v1, string v2)
        {
            Thread.Sleep(8000);
            return objDriver.GetElement(By.XPath("//span[text()='" + v1 + "']/following::span[3]")).Text.Equals(v2);
        }

        public bool? VerifyRetakeTest()
        {
            return objDriver.existsElement(By.XPath("//button[contains(text(),'Retake')]"));
        }

        public void RetakeTest()
        {
            throw new NotImplementedException();
        }

        public bool? VerifyContinueButton()
        {
            return objDriver.existsElement(By.XPath("//li[@class='list-group-item py-3 active']//button[@class='btn btn-default'][contains(text(),'Continue')]"));
        }

        public void Click_ContinueButton()
        {
            objDriver.ClickEleJs(By.XPath("//button[contains(text(),'Continue')]"));
        }

        public void Click_CurriculumContent()
        {
            objDriver.ClickEleJs(By.XPath("//span[@class='content-title mr-2']"));

        }
    }

    public class MorelikethisPortletCommand
    {
    private IWebDriver objDriver;
    public MorelikethisPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickSaveButton(string v)
        {
            objDriver.ClickEleJs(By.XPath("//div[@class='card slick-slide slick-current slick-active']//button[@type='button']"));
        }

        public string ContentTitle()
        {
            return objDriver.GetElement(By.XPath("//h4[@data-bind='text: name']")).Text;
        }

        public bool? isToolTipDisplayed(string v)
        {
            IWebElement SaveIcon =objDriver.FindElement(By.XPath("//div[@class='card slick-slide slick-current slick-active']//button[@type='button']"));
            string SaveIconToolTip = SaveIcon.GetAttribute("title");
            if (SaveIconToolTip.Equals(v))
            {
                return true;
            }
            else return false;
        }
    }

    public class CourseProviderAccodianCommand
    {
    private IWebDriver objDriver;
    public CourseProviderAccodianCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public string CourseProvidername()
        {
            objDriver.existsElement(By.XPath("//div[@id='MainContent_MainContent_ucCourseInfo_pnlCourseInfo']/ul/li[2]/strong"));
            return objDriver.GetElement(By.XPath("//div[@id='MainContent_MainContent_ucCourseInfo_pnlCourseInfo']/ul/li[2]/strong")).Text;
        }
    }

    public class CreditTypeAccordianCommand
    {
    private IWebDriver objDriver;
    public CreditTypeAccordianCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickManage()
        {
            objDriver.existsElement(By.Id("MainContent_MainContent_UC5_hlManage"));
            objDriver.ClickEleJs(By.Id("MainContent_MainContent_UC5_hlManage"));
        }

        public int CreditTypeNumber()
        {
            string credit = objDriver.GetElement(By.XPath("//li[contains(text(),'Default Credit Type:')]")).Text;
            return objDriver.getIntegerFromString(credit);
        }
    }

    public class CategoriesAccordianCommand
    {
    private IWebDriver objDriver;
    public CategoriesAccordianCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public string Categoryname()
        {
            objDriver.existsElement(By.XPath("//span[@class='rtIn']"));
            return objDriver.GetElement(By.XPath("//span[@class='rtIn']")).Text;
        }
    }

    public class InformationCommand
    {
    private IWebDriver objDriver;
    public InformationCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void Click_CategoriesTab()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton11']"));
        }

        public void Click_PermissionsTab()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton35']"));

        }

        public void Click_StatusTab()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton26']"));

        }

        public void StatusTab_VerifyEditingHistory()
        {
            objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li/strong")).Text);
        }

        public void PermissionsTab_VerifyPermissions()
        {
            objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li/strong")).Text);
        }

        public bool? SummaryTab_verifyUniqueID()
        {
            return objDriver.existsElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li[1]/strong"));
        }

        public bool? SummaryTab_verifyContentType()
        {
            return objDriver.existsElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li[4]/strong"));
        }

        public bool? SummaryTab_verifyCreatedDate()
        {
            return objDriver.existsElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li[6]/strong"));
        }

        public bool? SummaryTab_verifyCreatedBy()
        {
            return objDriver.existsElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li[7]/strong"));
        }

        public bool? CategoriesTab_verifyInstruction()
        {
            return objDriver.existsElement(By.XPath("//div[@id='pnlContent']/div/p"));
        }

        public void CategoriesTab_verifyRecordsCount()
        {
            objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li")).Text);
        }

        public bool? StatusTab_verifyCheckoutDate()
        {
            return objDriver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC2_rgStatus_ctl00__0']/td"));
        }

        public bool? StatusTab_verifyCheckinDate()
        {
            return objDriver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC2_rgStatus_ctl00__0']/td[3]"));
        }

        public bool? StatusTab_verifyCheckinUser()
        {
            return objDriver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC2_rgStatus_ctl00__0']/td[4]"));
        }

        public bool? StatusTab_verifyCheckoutUser()
        {
            return objDriver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC2_rgStatus_ctl00__0']/td[2]"));
        }

        public void Click_DomainSharing()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_lnkContentDomain1']"));

        }

        public bool? DomainSharingTab_verifyDomainOwner()
        {
            return objDriver.existsElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li[2]/strong"));
        }

        public void Click_Prerequisites()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton43']"));
        }

        public void PrerequisitesTab_verifyPrerequisites()
        {
            objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li")).Text);

        }

        public void Click_Equivalencies()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton62']"));

        }

        public void Click_ContentAssociations()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UC1_MLinkButton73']"));
        }

        public void ContentAssociationsTab_verifyAssociatedContents()
        {
            objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//div[@id='pnlContent']/div/ul[2]/li")).Text);

        }
    }



    public class CertificationContentCommand
    {
    private IWebDriver objDriver;
    public CertificationContentCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickContent(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text()," + v + ")]"));
        }
    }

    public class MarkCompleteModalCommand
    {
    private IWebDriver objDriver;
    public MarkCompleteModalCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? ContentTypeDocument(string FormatDocument)
        {
            objDriver.waitforframe();
            return objDriver.GetElement(By.XPath("//li[contains(text(),'Type:')]//strong[contains(text(),'Document')]")).Text.Equals(FormatDocument);

        }

        public bool? ContentTypeGeneralCourse(string FormatGeneralCourse)
        {
            objDriver.waitforframe();
            return objDriver.GetElement(By.XPath("//li[contains(text(),'Type:')]//strong[contains(text(),'Online')]")).Text.Equals(FormatGeneralCourse);

        }

        public bool? ContentTypeAICCCourse(string FormatAICCCourse)
        {
            objDriver.waitforframe();
            return objDriver.GetElement(By.XPath("//div[@id='MainContent_UC1_pnlUpdateMarkComplete']/ul/li[3]/strong")).Text.Equals(FormatAICCCourse);

        }

        public bool? ContentTypeScormCourse(string FormatScormCourse)
        {
            objDriver.waitforframe();
            return objDriver.GetElement(By.XPath("//li[contains(text(),'Type:')]//strong[contains(text(),'Online')]")).Text.Equals(FormatScormCourse);

        }
    }

    public class MoreLikeThisSectionCommand
    {

    private IWebDriver objDriver;
    public MoreLikeThisSectionCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? ContentTypeDocument()
        {
            return objDriver.GetElement(By.XPath("//strong[contains(text(),'Document')]")).Displayed;
        }

        public bool? ContentTypeGeneralCourse()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Enabled;
        }

        public bool? ContentTypeAICC()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Enabled;
        }

        public bool? ContentTypeScormCourse()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Enabled;
        }

        public bool? ContentTypeSurveys()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Enabled;
        }

        public bool? ContentTypeCurriculum()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Displayed;
        }

        public bool? ContentTypeCertification()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Enabled;
        }

        public bool? ContentTypeBundle()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Displayed;
        }

        public bool? ContentTypeSubscription()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Enabled;
        }

        public bool? ContentTypeOJT()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Enabled;
        }

        public bool? ContentTypeClassroom()
        {
            return objDriver.GetElement(By.XPath("//div/a/p[1]")).Displayed;
        }
    }

    public class ContentItemsPortletCommand
    {
    private IWebDriver objDriver;
    public ContentItemsPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickItemTitle(string v)
        {
            if(objDriver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]")))
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
            }
            else
            {
                objDriver.ClickEleJs(By.Id("ctl00_MainContent_ucCertification_FormView1_mgCertification_ctl00_ctl04_lnkDetails"));
            }
          

        }
    }

    public class OnTheJobTrainingActivitiesCommand
    {
    private IWebDriver objDriver;
    public OnTheJobTrainingActivitiesCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void CompleteContent(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text()," + v + ")]"));
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucChecklistDetails_FormView1_SelectAndSubmitEvalRequest']"));
            objDriver.waitforframe();
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']"));
           objDriver.findandacceptalert();



        }
    }

    public class OpenItemComand
    {
    private IWebDriver objDriver;
    public OpenItemComand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void CompleteAICCCourse()
        {
            Thread.Sleep(3000);
        }

        public void CompleteGeneralCourse()
        {
           objDriver.SelectWindowClose();
        }



        public void CompleteContentDocument()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst']"));
            //objDriver.SwitchtoDefaultContent();
            //objDriver.SelectWindowClose();
            //objDriver.SwitchTo().DefaultContent();
            //Thread.Sleep(10000);
            //objDriver.SelectWindowClose1("Google - Google Chrome");
        }

        //public void CompleteSCROMCourse()
        //{
        //   objDriver.SelectWindowClose1("SCORM Debug Window");
        //   objDriver.SelectWindowClose1("SCORM Debug Window");
        //   objDriver.SwitchWindow("Meridian Global - Core Domain");
        //    //objDriver.WaitForElement(By.XPath("//input[@value='Resume']"));
        //    // objDriver.ClickEleJs(By.XPath("//input[@value='Resume']"));
        //   objDriver.selectWindow("Meridian Global - Core Domain");
        //    Thread.Sleep(5000);
        //   objDriver.waitforframe(By.Id("tocFrame"));
        //    objDriver.ClickEleJs(By.XPath(".//*[@id='SCORM12Menu_1']/span[3]/img"));
        //   objDriver.WaitForElement(By.XPath("//u[contains(.,'References and Lesson Objective')]"));
        //    objDriver.ClickEleJs(By.XPath("//u[contains(.,'References and Lesson Objective')]"));

        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("contentFrame"));
        //    Thread.Sleep(5000);
        //   objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
        //    objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("tocFrame"));

        //   objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
        //    objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in any Condition of Visibility')]"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("contentFrame"));
        //    Thread.Sleep(5000);
        //   objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
        //    objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("tocFrame"));
        //   objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
        //    objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Sight of One Another')]"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("contentFrame"));
        //    Thread.Sleep(5000);
        //   objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
        //    objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("tocFrame"));
        //   objDriver.WaitForElement(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
        //    objDriver.ClickEleJs(By.XPath("//u[contains(.,'Conduct of Vessels in Restricted Visibility')]"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("contentFrame"));
        //    Thread.Sleep(5000);
        //   objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
        //    objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("tocFrame"));
        //   objDriver.WaitForElement(By.XPath("//u[contains(.,'Lights & Shapes')]"));
        //    objDriver.ClickEleJs(By.XPath("//u[contains(.,'Lights & Shapes')]"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("contentFrame"));
        //    Thread.Sleep(5000);
        //   objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
        //    objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("tocFrame"));
        //   objDriver.WaitForElement(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
        //    objDriver.ClickEleJs(By.XPath("//u[contains(.,'Sound & Light Signals')]"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("contentFrame"));
        //    Thread.Sleep(5000);
        //   objDriver.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
        //    objDriver.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("tocFrame"));
        //   objDriver.WaitForElement(By.XPath("//u[contains(.,'Exam')]"));
        //    objDriver.ClickEleJs(By.XPath("//u[contains(.,'Exam')]"));
        //   objDriver.SwitchTo().DefaultContent();
        //   objDriver.waitforframe(By.Id("contentFrame"));
        //    //driverobj.WaitForElement(By.XPath("//input[@value=' Continue> ']"));
        //    //driverobj.ClickEleJs(By.XPath("//input[@value=' Continue> ']"));
        //    Thread.Sleep(5000);
        //   objDriver.WaitForElement(By.XPath("html/body/form[1]/dl/dt[1]/ol/li[1]/input"));
        //    objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[1]/ol/li[4]/input"));
        //    objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[2]/ol/li[2]/input"));
        //    objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[3]/ol/li[3]/input"));
        //    objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[4]/ol/li[2]/input"));
        //    objDriver.ClickEleJs(By.XPath("html/body/form[1]/dl/dt[5]/ol/li[1]/input"));

        //    objDriver.ClickEleJs(By.XPath("//input[@value=' SUBMIT ANSWERS ']"));
        //   objDriver.SwitchTo().DefaultContent();
        //    //objDriver.ClickEleJs(By.XPath("//img[@id ='Exit']"));
        //   objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");
        //}
    }

    public class CurriculumBlocksCommand
    {
    private IWebDriver objDriver;
    public CurriculumBlocksCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickContent()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(@href, 'javascript:void(0);')]"));
        }
    }

    public class CourseTabCommand
    {
    private IWebDriver objDriver;
    public CourseTabCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public void ClickEditPrerequisite()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPrerequistes_lnkEdit']"));
        }
    }

    public class SurveyPortletCommand
    {
    private IWebDriver objDriver;
    public SurveyPortletCommand(IWebDriver objDriver)
    {
        this.objDriver = objDriver;
    }
    public bool? IsSurveysareNotavailable
        {
            get
            {
                bool result = false;
                try
                {
                    if (objDriver.FindElement(By.XPath("//div[@id='surveysBlock']//ul[@class='list-unstyled']")).Enabled)
                    {
                        result = true;
                    }

                }
                catch { }
                return result;
            }
        }

        public bool? IsSurveysareNotavailableforCurriculum
        {
            get

            {
                bool result = false;
                try
                {
                    if (objDriver.FindElement(By.XPath("//div[@id='surveysBlock']//div[@class='panel-body']")).Enabled)
                    {
                        result = true;
                    }

                }
                catch { }
                return result;
            }
        }

        public void ClickonattachedSurvey(string v = "")
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Before Course Start')]"));

        }

        public void CompleteSurvey(string v = "")
        {
            Thread.Sleep(10000);
           objDriver.selectWindow(v);
            objDriver.select(By.XPath("//select[@id='sq_100i']"), "yes");
            //objDriver.ClickEleJs(By.XPath("//body//input[3])"));
            objDriver.ClickEleJs(By.XPath("//input[@class='btn btn-primary complete']"));
            objDriver.focusParentWindow();


        }

        public bool? isSurveyDisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div[4]/div/h3"));
        }

        public bool? IsSurveysAvailable(string surveytitle)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string surveyTitle = surveytitle.Split(stringSeparators, StringSplitOptions.None)[0];
            //return objDriver.GetElement(By.XPath("//h3[contains(text(),'Surveys')]/following::a[text()='" + surveytitle + "']")).Enabled;
            return objDriver.GetElement(By.XPath("//a[contains(text(),'" + surveyTitle + "')]")).Enabled;
        }

        public bool? IsSurveysAvailableforCurriculumn(string v)
        {
            return objDriver.GetElement(By.XPath("//a[@class='font-semibold text-grey-darker block']/following::a[text()='" + v + "']")).Enabled;
        }

        public bool? IsSurveysDisplay(string surveytitle_OnEnroll, string surveytitle_OnContentComplete)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string survey1title = surveytitle_OnEnroll.Split(stringSeparators, StringSplitOptions.None)[0];
            string survey2title = surveytitle_OnContentComplete.Split(stringSeparators, StringSplitOptions.None)[0];
            bool result = false;
            objDriver.existsElement(By.XPath("//div[@id='survey-block']//div[@class='panel-heading']"));
            try
            {
                //string onEnrollsurveytitle = objDriver.GetElement(By.XPath("//*[@id='content']/div[2]/div/div[2]/div[2]/div[3]/ul/li[1]")).Text;
                string onEnrollsurveytitle = objDriver.GetElement(By.XPath("//span[contains(text(),'" + survey1title + "')]")).Text;
                //string onCompletedsurveytitle =objDriver.GetElement(By.XPath("//*[@id='content']/div[2]/div/div[2]/div[2]/div[3]/ul/li[2]")).Text;
                string onCompletedsurveytitle = objDriver.GetElement(By.XPath("//span[contains(text(),'" + survey2title + "')]")).Text;
                if (onEnrollsurveytitle.Contains(survey1title) || onCompletedsurveytitle.Contains(survey2title))
                {
                    result = true;
                }
            }
            catch { }
            return result;
        }

        public bool? IsSurveysDisplayForCurriculumn(string surveytitle_OnEnroll, string surveytitle_OnContentComplete)
        {
            bool result = false;
            objDriver.existsElement(By.XPath("//div[@id='survey-block']/div/a"));
            try
            {
                string onEnrollsurveytitle = objDriver.GetElement(By.XPath("//div[@id='surveysBlock']/div/div/ul/li/span")).Text;
                string onCompletedsurveytitle = objDriver.GetElement(By.XPath("//div[@id='surveysBlock']/div/div/ul/li[2]/span")).Text;
                if (onEnrollsurveytitle.Contains(surveytitle_OnEnroll) || onCompletedsurveytitle.Contains(surveytitle_OnContentComplete))
                {
                    result = true;
                }
            }
            catch { }
            return result;
        }

        public void Click_SurveyReport()
        {
            throw new NotImplementedException();
        }

        public bool? isRequiredDisplayFor(string v)
        {
            return objDriver.GetElement(By.XPath("//a[contains(text(),'" + v + "')]/following::small")).Text.Equals("Required");
        }

        public bool? VerifyQuestion(string v, string question)
        {
           objDriver.selectWindow(v);

            return objDriver.GetElement(By.XPath("//span[contains(text(),'" + question + "')]")).Text.Contains(question);
        }//span[contains(text(),'How are you 1807340034 ?')]

        public void EnterRatingResponseAndCompleteSurvey(string v)
        {
            objDriver.ClickEleJs(By.XPath("//body//label[6]"));
            objDriver.ClickEleJs(By.XPath("//input[@value='Complete']"));
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-default']"));
            objDriver.focusParentWindow();
        }

        public void EnterMatrixResponseAndCompleteSurvey()
        {
            objDriver.ClickEleJs(By.XPath("//th[@class='text-center']//span[contains(text(),'matrix response 2')]/following::input"));
            objDriver.ClickEleJs(By.XPath("//input[@value='Complete']"));
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-default']"));
            objDriver.focusParentWindow();
        }
        public void EnterSliderResponseAndCompleteSurvey()
        {
            objDriver.ClickEleJs(By.XPath("//div[@class='slider-handle min-slider-handle round']"));
            objDriver.ClickEleJs(By.XPath("//input[@value='Complete']"));
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-default']"));
            objDriver.focusParentWindow();
        }
    }
}






