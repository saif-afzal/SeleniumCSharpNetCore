using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Selenium2.Meridian.Suite.Learning
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CurrentTrainingold : TestBase
    {
        string browserstr = string.Empty;
        string learner = string.Empty;
        
        public CurrentTrainingold(string browser)
            : base(browser)
        {
            browserstr = browser+"CTs";
            learner = ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "CT";
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //create general course and enroll course
            driver.UserLogin("admin1", browserstr);
            #region create blog
            Blogsobj.CreateBlog_Regression(browserstr);
            #endregion

            driver.Navigate_to_TrainingHome();
            #region create general course title is ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr +ct1
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
            //ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("ct" + 1, browserstr);
            Contentobj.Click_CheckIn();
            #endregion

            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "ct" + 1);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.selectProfile();
            requiredtrainingobj.Click_SelectProfileGoBtn();
            SelectProfileobj.Click_SearchProfile("testdynamic");
            SelectProfileobj.Click_SelectProfile();
            requiredtrainingobj.Click_SearchUserforAssignTraining();
            requiredtrainingobj.Click_SelectUserforTraining();
            requiredtrainingobj.Click_RequiredTrainingLink();
            requiredtrainingobj.Click_SearchUserforRequiredTraining();
            Assert.IsTrue(requiredtrainingobj.CheckRequiredTraining());
            driver.Navigate_to_TrainingHome();
            //driver.SelectWindowClose1();
            //TrainingHomeobj.close_systemOptions();
            #region create classroom course title is NewTestClassroomCourse" + Meridian_Common.globalnum+ct
            generalcourseobj.linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            //ContentSearchobj.NewContent("Classroom Course");
            Createobj.FillClassroomCoursePage("ct", browserstr);
            #endregion

            //Contentobj.ManageSectionTab();
            //ScheduleAndManageSectionobj.AddNewSection_Click();
            //CourseSectionobj.CreateNewSectionInPerson(driver, ExtractDataExcel.MasterDic_admin1["Lastname"], browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "ct" + 1);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.EnrollClassroomCourse();
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.isTrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
     

        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void A_RegressionTestTo_Validate_all_PossibleActions_ParticularAICC_Training_InCT()
        {
            #region Create AICC Cource
            driver.UserLogin("admin1", browserstr);
            aicccourse.CreateAICCCource(browserstr);
            #endregion
            #region Assign Course to the User
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_aicc["Title"] + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforAICCTraningType(browserstr, "AICC"));
            //System.Windows.Forms.MessageBox.Show("first test pass");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.Simple_Search("AICC_" + ExtractDataExcel.token_for_reg + browserstr);
            ContentSearchobj.Content_Click();
            driver.WaitForElement(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
            //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
            driver.ClickEleJs(By.XPath("//a[contains(.,'Delete Content')]"));
            driver.findandacceptalert();
            driver.WaitForElement(By.XPath("//button[@onclick='return SearchContentRedirect();']"));
        }
        [Test]
        public void B_RegressionTestTo_Validate_all_PossibleActions_ParticularGeneralCourse_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create General Cource
            generalcourseobj.CreateGeneralCource(browserstr, "Yes");
            #endregion
            #region Assign Course to the User
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(generalcourseobj.VelidateAllPossibleActionforGCTraningType(browserstr, "General Course"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.Simple_Search("GC" + ExtractDataExcel.token_for_reg + browserstr);
            ContentSearchobj.Content_Click();
            driver.WaitForElement(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
            //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
            driver.ClickEleJs(By.XPath("//a[contains(.,'Delete Content')]"));
            driver.findandacceptalert();
            driver.WaitForElement(By.XPath("//button[@onclick='return SearchContentRedirect();']"));
        }
        [Test]
        public void C_RegressionTestTo_Validate_all_PossibleActions_Particular_SCORM_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create SCORM Cource
            scormobj.CreateSCORMCourse(browserstr);
            #endregion
            #region Assign Course to the User
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforSCORM_ClassRoom_TraningType(browserstr, "SCORM"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.Simple_Search("SCROM12" + ExtractDataExcel.token_for_reg + browserstr);
            ContentSearchobj.Content_Click();
            driver.WaitForElement(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
            //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
            driver.ClickEleJs(By.XPath("//a[contains(.,'Delete Content')]"));
            driver.findandacceptalert();
            driver.WaitForElement(By.XPath("//button[@onclick='return SearchContentRedirect();']"));
        }
        [Test]
        public void D_RegressionTestTo_Validate_all_PossibleActions_Particular_ClassRoomCourse_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create Classs Room Cource
            classroomcourse.CreateClassRoomCourse(browserstr);
            classroomcourse.CreateSection_ClassRoomCourse(browserstr);
            #endregion
            #region Assign Course to the User
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_classrommcourse["Title"]  + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforSCORM_ClassRoom_TraningType(browserstr, "ClassRoom Course"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.Simple_Search("Classroom" + ExtractDataExcel.token_for_reg + browserstr);
            ContentSearchobj.Content_Click();
            driver.WaitForElement(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
            //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
            driver.ClickEleJs(By.XPath("//a[contains(.,'Delete Content')]"));
            driver.findandacceptalert();
            driver.WaitForElement(By.XPath("//button[@onclick='return SearchContentRedirect();']"));
        }
        [Test]
        public void E_RegressionTestTo_Validate_all_PossibleActions_Particular_Curriculum_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create Curriculum Cource
            Createobj.CreateCurriculumCourseType(browserstr);
            #endregion
            #region Assign Course to the User
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(Variables.curriculumTitle + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforCurriculumTraningType(browserstr, "Curriculum"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.Simple_Search("NewTestCurriculum" + ExtractDataExcel.token_for_reg + browserstr);
            ContentSearchobj.Content_Click();
            driver.WaitForElement(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
            driver.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
            //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
            driver.ClickEleJs(By.XPath("//a[contains(.,'Delete Content')]"));
            driver.findandacceptalert();
            driver.WaitForElement(By.XPath("//button[@onclick='return SearchContentRedirect();']"));
        }
        [Test]
        public void F_RegressionTestTo_Validate_all_PossibleActions_Particular_OJT_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create OJT Cource
            ojtcourse.CreateOJTCourse(browserstr);
            #endregion
            #region Assign Course to the User
         //   TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforOJTTraningType(browserstr, "OJT"));
        }
        [Test]
        public void G_RegressionTestTo_Validate_all_PossibleActions_Particular_Document_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create Document Cource
            documentobj.Create_DocumentForRegression(ExtractDataExcel.MasterDic_document["Title"] + browserstr,browserstr);
            #endregion
            #region Assign Course to the User
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforDocumentTraningType(browserstr, "Document"));
        }
        [Test]
        public void H_RegressionTestTo_Validate_all_PossibleActions_Particular_Blog_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create Blog
            Blogsobj.CreateBlog_Regression(browserstr);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            #region Catalog Search And Open the Blog
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            CurrentTrainingsobj.SwitchToNewWindow("Blog");
            Thread.Sleep(5000);
            driver.SelectWindowClose2("Blogs", "Details");
            #endregion
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforBlog(browserstr, "Blog"));
        }
        [Test]
        public void I_RegressionTestTo_Validate_all_PossibleActions_Particular_FAQ_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create FAQ
            Faqsobj.Create_FAQForRegression(browserstr);
            #endregion
            #region Assign Course to the User
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_FAQ["Question"] + browserstr + "adminfaq1");
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);

            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforFAQ(browserstr, "FAQ"));
        }
        [Test]
        public void J_RegressionTestTo_Validate_all_PossibleActions_Particular_SiteSurvey_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create Site Survey
            Surveysobj.CreateNewSurveyForRegression(browserstr);
            Surveysobj.Click_Structure_Go();
            Surveysobj.Populate_Structure(1, browserstr);
            Surveysobj.Click_Populate_Create_Question(browserstr);
            driver.GetElement(By.Id("Return")).Click();
            Surveysobj.Click_PublishSurvey();
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            #region Catalog Search And Open the Site Survey
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_Survey["Title"] + browserstr);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            CurrentTrainingsobj.SwitchToNewWindow("SiteSurvey");
            #endregion
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforSiteSurvey(browserstr, "SiteSurvey"));
        }
        [Test]
        public void K_RegressionTestTo_Validate_all_PossibleActions_Particular_CollaborationSpace_Training_InCT()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            #region Create Collabaration
            CollabarationSpacesobj.CreateCollaborationSpaceForRegression(browserstr);
            #endregion
            #region Assign Course to the User
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            driver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch(ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.AssignProfileAndSaveTheTraning(browserstr);
            Thread.Sleep(3000);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.True(CurrentTrainingsobj.ValidateAllPossibleActionforCollaborationSpace(browserstr, "CollaborationSpace"));
        }
        #region Titans_Team_1CTFilters
        [Test]
        public void L_User_RequiredTraning_Filter_current_trainingt_showinly_required_training()
        {
            Assert.IsTrue(CurrentTrainingsobj.VerifyRequiredTraningFilter_CurrentTraning(browserstr, "RequiredTraning"));
        }
        [Test]
        public void M_User_ExtendedTraning_Filter_current_trainingt_showinly_required_training()
        {
            Assert.IsTrue(CurrentTrainingsobj.VerifyRequiredTraningFilter_CurrentTraning(browserstr, "ExtendedTraning"));
        }
        [Test]
        public void N_User_DueSoonTraning_Filter_current_trainingt_showinly_required_training()
        {
            Assert.IsTrue(CurrentTrainingsobj.VerifyRequiredTraningFilter_CurrentTraning(browserstr, "DueSoonTraning"));
        }
        [Test]
        public void O_User_OverdueTraning_Filter_current_trainingt_showinly_required_training()
        {
            Assert.IsTrue(CurrentTrainingsobj.VerifyRequiredTraningFilter_CurrentTraning(browserstr, "OverDueTraning"));
        }
        #endregion
        #region Titans_Team_1Expiring
        [Test]
        public void P_User_sees_an_indicator_of_expiring_access_period_for_training_in_CT()
        {
            #region Create General Cource
            generalcourseobj.CreateGeneralCource(browserstr, "No");
            #endregion
            MyOwnLearningobj.editaccessperiod();
            Thread.Sleep(3000);
            generalcourseobj.ClickonCheckinButton();
            TrainingHomeobj.Click_MyOwnLearning();

            TrainingCatalogobj.SearchAndClickSearched_GeneralCourse(browserstr);
            Detailsobj.Click_EnrollGeneralCourse();

            TrainingHomeobj.click_currenttraining();
            driver.ClickEleJs(By.XPath("//button[@title='All Statuses']"));
            //CurrentTrainingsobj.VerifyRequiredTraningFilter_CurrentTraning(browserstr, "Enrolled");
            driver.ClickEleJs(By.XPath("//input[@value='ML.BASE.DV.Enrollment.Status.Enroll']"));
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC3_btnFilter']"));
            int cnt1 = driver.countelements(By.XPath("//span[@class='fa fa-flag text-danger']"));
            int cnt2 = driver.countelements(By.XPath(".//li[contains(.,'Access expires')]"));
            int cnt3 = driver.countelements(By.XPath(".//*[@id='ctl00_MainContent_UC3_RadGrid1_ctl00']/tbody/tr"));
            Assert.AreEqual(cnt1, cnt2);
            Assert.GreaterOrEqual(cnt3, cnt2);

        }
        [Test]
        public void Q_User_sees_an_indicator_of_expiring_access_Key_for_training_in_CT()
        {
            #region Create General Cource
            browserstr = browserstr + "AK";//AK- Access Key
            generalcourseobj.CreateGeneralCource(browserstr, "No");
            #endregion
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.EnableAccessKeysAndAddRedemption();
            Contentobj.Click_CheckIn();
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingCatalogobj.SearchAndClickSearched_GeneralCourse(browserstr);
            ShoppingCartsobj.AssignCourseUserAccessKey(browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("testuser", browserstr, "AutomationTestUser", "password");
            TrainingHomeobj.lnk_CurrentTraining_click();
            Assert.IsTrue(CurrentTrainingsobj.VerifyAccessKeyCourse_InCurrentTraning(browserstr));
        }
        #endregion
        #region Titans_Team_1HiddenTraining
        [Test]
        public void R_Hidden_training_appears_back_in_Current_Training_after_user_reopens_it()
        {
            //driver.UserLogin("admin1", browserstr);
            #region Create Blog
            Blogsobj.CreateBlog_Regression(browserstr);
            #endregion
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            #region Catalog Search And Open the Blog
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            CurrentTrainingsobj.SwitchToNewWindow("Blog");
            #endregion
            CurrentTrainingsobj.ValidateHide_Course_Transcript_forBlog(browserstr, "Blog");
        } 
        #endregion
        [Test]
        public void L_User_filters_their_current_training_to_only_show_content_of_a_particular_type_23573()
        {
            
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText("testblog_" + ExtractDataExcel.token_for_reg + browserstr);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            CurrentTrainingsobj.SwitchToNewWindow("Blog");
            TrainingHomeobj.lnk_CurrentTraining_click();
            CurrentTrainingsobj.iscurrenttraining();
            Assert.IsTrue(CurrentTrainingsobj.Click_blogType(browserstr));
            Assert.IsTrue(CurrentTrainingsobj.Click_onlineType(browserstr, true));
             Assert.IsTrue(CurrentTrainingsobj.Click_AllType(browserstr));
        }
        [Test]
        public void M_sorts_current_training_by_begins_started_date_23645()
        {
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.lnk_CurrentTraining_click();
            CurrentTrainingsobj.iscurrenttraining();
           Assert.IsTrue( CurrentTrainingsobj.Click_started_begin());
        }
        [Test]
        public void N_sorts_current_training_by_ends_due_date_23644()
        {
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.lnk_CurrentTraining_click();
            CurrentTrainingsobj.iscurrenttraining();
            Assert.IsTrue(CurrentTrainingsobj.Click_due_end());
        }
        [Test]
        public void O_user_views_training_start_or_begins_date_23662()
        {
            TrainingHomeobj.click_currenttraining();
            string currentdate = DateTime.Now.ToString("dd");
            CurrentTrainingsobj.Click_blogType(browserstr);
            string startdate = driver.gettextofelement(By.ClassName("date-box-day"));
            //String Assertion for start date of training 
            StringAssert.Contains(startdate, currentdate);
        }
        [Test]
        public void P_User_views_training_due_or_end_date_25563()
        {
            TrainingHomeobj.click_currenttraining();
            string clsEndDate = DateTime.Now.AddDays(2).ToString("dd");
            string enddate = driver.gettextofelement(By.ClassName("date-box-day"));
            Assert.IsTrue(driver.Compareregexstring(enddate, clsEndDate));
        }
        [Test]
        public void Q_User_can_hide_non_required_training_25498()
        {
            TrainingHomeobj.click_currenttraining();
            driver.GetElement(By.CssSelector("input[id*='_btnReset']")).ClickWithSpace();
            Thread.Sleep(3000);
            CurrentTrainingsobj.Click_blogType(browserstr);
            CurrentTrainingsobj.course_dropdown();
            
            CurrentTrainingsobj.hidebtn_click();
            Thread.Sleep(3000);
            driver.GetElement(By.CssSelector("button[data-bb-handler='confirm']")).Click();
            //driver.SwitchTo().Alert().Accept();
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("Your content has been hidden. It is still available on your transcript.", successMsg);
        }
    
        [Test]
        public void R_User_sees_an_indicator_of_an_extension_being_granted_for_training_in_25202()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_Extendedtraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string extension_being_grantedTraining = driver.gettextofelement(By.Id("ctl00_MainContent_UC3_RadGrid1_ctl00__0"));
            StringAssert.Contains("Extended", extension_being_grantedTraining);
        }
        [Test]
        public void S_User_views_Due_Soon_label_for_due_soon_training_23663()
        {
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_DueSoonTraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string DueSoonStatus = driver.gettextofelement(By.CssSelector("div[id*='_pnlDueDate']"));
            StringAssert.Contains("Due Soon", DueSoonStatus);
        }
        [Test]
        public void T_User_views_Recurring_Training_label_for_recurring_training_25564()
        {
            TrainingHomeobj.click_currenttraining();
            string recurringlabelforrequiredtraining = driver.gettextofelement(By.CssSelector("tr[id*='MainContent_UC3_RadGrid']"));
            StringAssert.Contains("Recurring", recurringlabelforrequiredtraining);
        }
      //  [Test]
        public void j_User_views_overdue_active_training_25206()
        {
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_OverdueTraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string OverDueStatusforActiveTraining = driver.gettextofelement(By.ClassName("date-box-status"));
            StringAssert.Contains("Overdue", OverDueStatusforActiveTraining);
        }
     //   [Test]
        public void k_User_views_Overdue_label_for_late_training_25565()
        {
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_OverdueTraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string OverDueforLateTraining = driver.gettextofelement(By.ClassName("date-box-status"));
            StringAssert.Contains(OverDueforLateTraining, "Overdue");
        }
      //  [Test]
        public void l_User_does_not_see_no_show_training_in_CT_once_that_training_date_passes_23984()
        {


        }

        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //  _extent.Flush();
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }
    }
}
