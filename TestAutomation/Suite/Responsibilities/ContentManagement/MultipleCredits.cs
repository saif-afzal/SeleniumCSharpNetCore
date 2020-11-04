using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2.Meridian;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class u_MultipleCredits : TestBase
    {
        string browserstr = string.Empty;
        public u_MultipleCredits(string browser)
            : base(browser)
        {
            browserstr = browser;
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
        [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {
          
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
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
            SearchResultsobj =new  SearchResults(driver);
            Detailsobj = new Details(driver);
            TrainingActivitiesobj = new TrainingActivities(driver);
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
            driver.UserLogin("admin1",browserstr);
        }

        [Test]
        public void a_Adding_Multiple_Credits_for_General_Course()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent( "General Course");
            Createobj.FillGeneralCoursePage("credit",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search(ExtractDataExcel.MasterDic_genralcourse["Title"] +browserstr + "credit");
            ContentSearchobj.ViewInList();
            ContentSearchobj.ClickInList();
            Contentobj.Click_CheckOut();
            Contentobj.Click_ManageCredits();
            Creditsobj.Check_CreditsonStart();
            Creditsobj.Click_AddCredits();
            Creditsobj.Fill_MultipleCredits();
            Creditsobj.Click_SaveCredits();
            TrainingActivitiesobj.Click_Backbutton();
            Creditsobj.Click_SaveAllCredits();
            Creditsobj.Click_Return();
           Assert.IsTrue( Contentobj.Verify_MultipleCredits());
           Contentobj.Click_CheckIn();
        }

        [Test]
        public void b_Adding_Multiple_Credits_for_Classroom_Course()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent( "Classroom Course");
            Createobj.FillClassroomCoursePage("credit",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.classroomCourseTitle +browserstr + "credit");
            ContentSearchobj.ViewInList();
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
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent( "Curriculums");
            Createobj.FillCurriculumPage("credit",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr + "credit");
            ContentSearchobj.ViewInList();
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
            ContentSearchobj.ViewInList();
            ContentSearchobj.ClickInList();
            Contentobj.Verify_MultipleCredits();
            string multicreditoncontent = Contentobj.Collect_MultipleCredits().Replace("  "," ");
            Contentobj.ManageSectionTab();
            Contentobj.Click_Coursedetail();
            StringAssert.AreEqualIgnoringCase(multicreditoncontent, ScheduleAndManageSectionobj.VerifyMultipleCredits());
          
            Contentobj.Click_CheckOut();
        }

        public void b_Adding_Multiple_Credits_for_AICC()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent( "AICC");
            Createobj.FillAICCPage();
            Summaryobj.Fill_AICCTitle("credits",browserstr);
            Summaryobj.Click_SaveAICC();
            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);

            Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.aicccourseTitle+browserstr + "credits");
            ContentSearchobj.ViewInList();
            ContentSearchobj.ClickInList();

            Contentobj.Click_ManageCredits();
            Creditsobj.Check_CreditsonStart();
            Creditsobj.Click_AddCredits();
            Creditsobj.Fill_MultipleCredits();
            Creditsobj.Click_SaveCredits();
            Creditsobj.Click_SaveAllCredits();
            Creditsobj.Click_Return();
            Assert.IsTrue(Contentobj.Verify_MultipleCredits());
            Contentobj.Click_CheckOut();
        }

     //   [Test]
        public void e_Learner_can_view_multiple_credit_types_through_the_view_details_link_on_content_details_page()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "credit");
            SearchResultsobj.Content_Click();
            Detailsobj.Click_EnrollGeneralCourse();
            Detailsobj.Click_OpenGeneralCourse();
            Detailsobj.Click_MarkCompleteGeneralCourse();
           Assert.IsTrue( Detailsobj.Click_ViewDetailGeneralCourseCompleted(browserstr));
        }

        [Test]
        public void f_Learner_can_view_credits_associated_to_a_Learning_Group_on_Content_Details_page()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "credit");
            SearchResultsobj.Content_Click();

            Assert.IsTrue(Detailsobj.Check_CreditBlock());
        }
        [TearDown]
        public void TearDown()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            Console.WriteLine("TearDown");
            driver.Quit();
        }
    }
}

