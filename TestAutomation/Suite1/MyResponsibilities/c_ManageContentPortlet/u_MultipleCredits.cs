using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class u_MultipleCreditsold : TestBase
    {
        string browserstr = string.Empty;
        public u_MultipleCreditsold(string browser)
            : base(browser)
        {
            browserstr = browser;
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            InitializeBase(driver);
            Driver.Instance = driver;
            // Loginobj = new Login();
            TrainingHomeobj = new TrainingHomes(driver);
            Trainingobj = new Training(driver);
            ContentSearchobj = new ContentSearch(driver);
            Createobj = new Create(driver);
            Contentobj = new Content(driver);
            Creditsobj = new Credits(driver);
            AddContentobj = new AddContent(driver);
            Summaryobj = new Summary(driver);
            ScheduleAndManageSectionobj = new ScheduleAndManageSection(driver);
            SearchResultsobj = new SearchResults(driver);
            Detailsobj = new Details(driver);
            TrainingActivitiesobj = new TrainingActivities(driver);
            driver.UserLogin("admin1", browserstr);
        }
        public static bool isCurriculum;
        public Training Trainingobj;
        public Login Loginobj;
        public TrainingHomes TrainingHomeobj;
        public ContentSearch ContentSearchobj;
        public Create Createobj;
        public Content Contentobj;
        public Credits Creditsobj;
        public AddContent AddContentobj;
        public Summary Summaryobj;
        public ScheduleAndManageSection ScheduleAndManageSectionobj;
        public SearchResults SearchResultsobj;
        public Details Detailsobj;
        public TrainingActivities TrainingActivitiesobj;
     
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
          
        }

        [Test]
        public void a_Adding_Multiple_Credits_for_General_Course()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
            Createobj.FillGeneralCoursePage("credit",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            TrainingHomeobj.MyResponsiblities_click();
          //  Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search(ExtractDataExcel.MasterDic_genralcourse["Title"] +browserstr + "credit");
            ContentSearchobj.ViewInList(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "credit");
            ContentSearchobj.ClickInList();
            driver.Checkout();
            Contentobj.Click_ManageCredits();
            Creditsobj.Check_CreditsonStart();
            Creditsobj.Click_AddCredits();
            Creditsobj.Fill_MultipleCredits();
            Creditsobj.Click_SaveCredits();
            TrainingActivitiesobj.Click_Backbutton();
            Creditsobj.Click_SaveAllCredits();
            Creditsobj.Click_Return();
           Assert.IsTrue( Contentobj.Verify_MultipleCredits());
           driver.Checkin();
        }

        [Test]
        public void b_Adding_Multiple_Credits_for_Classroom_Course()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            Createobj.FillClassroomCoursePage("credit",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            TrainingHomeobj.MyResponsiblities_click();
            //Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.classroomCourseTitle +browserstr + "credit");
            ContentSearchobj.ViewInList(Variables.classroomCourseTitle + browserstr + "credit");
            ContentSearchobj.ClickInList();
           
            Contentobj.Click_ManageCredits();
            Creditsobj.Check_CreditsonStart();
            Creditsobj.Click_AddCredits();
            Creditsobj.Fill_MultipleCredits();
            Creditsobj.Click_SaveCredits();
            TrainingActivitiesobj.Click_Backbutton();
            Creditsobj.Click_SaveAllCredits();
            Creditsobj.Click_Return();
            Assert.IsTrue(Contentobj.Verify_MultipleCredits());
            //Contentobj.Click_CheckOut();
        }

        [Test]
        public void c_Adding_Multiple_Credits_for_Curriculam()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
            Createobj.FillCurriculumPage("credit",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            TrainingHomeobj.MyResponsiblities_click();
           // Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr + "credit");
            ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "credit");
            ContentSearchobj.ClickInList();
            
            Contentobj.Click_ManageCredits();
            Creditsobj.Check_CreditsonStart();
            Creditsobj.Click_AddCredits();
            Creditsobj.Fill_MultipleCredits();
            Creditsobj.Click_SaveCredits();
            TrainingActivitiesobj.Click_Backbutton();
            Creditsobj.Click_SaveAllCredits();
            Creditsobj.Click_Return();
            Assert.IsTrue(Contentobj.Verify_MultipleCredits());
           // Contentobj.Click_CheckOut();
        }

      //  [Test]
        public void d_Adding_Multiple_Credits_for_Classroom_Course_Section()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
           
            ContentSearchobj.Simple_Search( Variables.classroomCourseTitle+browserstr + "credit");
            ContentSearchobj.ViewInList(Variables.classroomCourseTitle + browserstr + "credit");
            ContentSearchobj.ClickInList();
            Contentobj.Verify_MultipleCredits();
            string multicreditoncontent = Contentobj.Collect_MultipleCredits().Replace("  "," ");
            Contentobj.ManageSectionTab();
            Contentobj.Click_Coursedetail();
            StringAssert.AreEqualIgnoringCase(multicreditoncontent, ScheduleAndManageSectionobj.VerifyMultipleCredits());
          
            Contentobj.Click_CheckOut();
        }
        [Test]
        public void d_Adding_Multiple_Credits_for_AICC()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.AICC_CourseClick);
            Createobj.FillAICCPage();
            Summaryobj.Fill_AICCTitle("credits",browserstr);
            Summaryobj.Click_SaveAICC();
            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The changes were saved.", successMsg);

            TrainingHomeobj.MyResponsiblities_click();
            ContentSearchobj.Simple_Search( Variables.aicccourseTitle+browserstr + "credits");
            ContentSearchobj.ViewInList(Variables.aicccourseTitle + browserstr + "credits");
            ContentSearchobj.ClickInList();

            Contentobj.Click_ManageCredits();
            Creditsobj.Check_CreditsonStart();
            Creditsobj.Click_AddCredits();
            Creditsobj.Fill_MultipleCredits();
            Creditsobj.Click_SaveCredits();
            TrainingActivitiesobj.Click_Backbutton();
            Creditsobj.Click_SaveAllCredits();
            Creditsobj.Click_Return();
            Assert.IsTrue(Contentobj.Verify_MultipleCredits());
         //   Contentobj.Click_CheckOut();
        }

        [Test]
        public void e_Learner_can_view_multiple_credit_types_through_the_view_details_link_on_content_details_page()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "credit");
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Contentobj.Verify_MultipleCredits());
        
        }

        [Test]
        public void f_Learner_can_view_credits_associated_to_a_Learning_Group_on_Content_Details_page()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.Click_Search(Variables.aicccourseTitle + browserstr + "credits");
            SearchResultsobj.Content_Click();
            //TrainingHomeobj.isTrainingHome();
            //    TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "credit");
            Assert.IsTrue(Contentobj.Verify_MultipleCredits());
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

