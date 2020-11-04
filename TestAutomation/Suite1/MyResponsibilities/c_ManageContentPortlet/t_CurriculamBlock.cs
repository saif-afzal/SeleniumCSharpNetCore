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
   class t_CurriculamBlockold : TestBase
    {
        string browserstr = string.Empty;
        public t_CurriculamBlockold(string browser)
            : base(browser)
        {
            browserstr = browser;
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //Loginobj = new Login();
            InitializeBase(driver);
            Driver.Instance = driver;
            TrainingHomeobj = new TrainingHomes(driver);
            Trainingobj = new Training(driver);
            ContentSearchobj = new ContentSearch(driver);
            Createobj = new Create(driver);
            Contentobj = new Content(driver);
            TrainingActivitiesobj = new TrainingActivities(driver);
            AddContentobj = new AddContent(driver);
            driver.UserLogin("admin1", browserstr);
        }
        public static bool isCurriculum;
        public Training Trainingobj;
        public Login Loginobj;
        public TrainingHomes TrainingHomeobj;
        public ContentSearch ContentSearchobj;
        public Create Createobj;
        public Content Contentobj;
        public TrainingActivities TrainingActivitiesobj;
        public AddContent AddContentobj;
        
      
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
          
        }
        [Test]
        public void h_Add_Autosave_Feature_in_Curriculam_Block()
        {
            //TrainingHomeobj.MyResponsiblities_click();
            //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
            //Createobj.FillCurriculumPage("block", browserstr);

            ////String Assertion on new curriculum creation 
            //String successMsg = Contentobj.SuccessMsgDisplayed();
            //StringAssert.Contains("The item was created.", successMsg);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(Variables.curriculumTitle);// + browserstr + "block","Exact phrase");
       //     Contentobj.ContentSearch_Click();
         //   ContentSearchobj.Simple_Search( Variables.curriculumTitle + browserstr + "block");

            //Assertion for curriculum displayed on search
        //    Assert.IsTrue(ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "block"));
         //   ContentSearchobj.ClickInList();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandAddAnotherCurriculamBlock("1",browserstr);
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("2",browserstr);
            TrainingActivitiesobj.Click_Backbutton();
            Contentobj.Edit_TrainingActivities();
          Assert.IsTrue(  TrainingActivitiesobj.Check_AutoSave());
        }

        [Test]
        public void b_Learning_Activities_can_be_searched_for_adding_to_a_curriculam_block()
        {
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
            Createobj.FillCurriculumPage("block", browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
            Createobj.FillGeneralCoursePage("",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
         //   Trainingobj.SearchContent_Click();
           // Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr+"block");

            //Assertion for curriculum displayed on search
            Assert.IsTrue(ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "block"));
           ContentSearchobj.ClickInList();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("2", browserstr);
            Assert.IsTrue(AddContentobj.SearchAndAddCurriculamContent(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr));
       
        }

        [Test]
        public void c_Curriculum_Builder_can_see_credit_values_for_Learning_activities_that_have_been_added_to_the_Curriculum_Block()
        {
            TrainingHomeobj.MyResponsiblities_click();
           // Trainingobj.SearchContent_Click();
           
           // Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr + "block");
            Assert.IsTrue(ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "block"));
            ContentSearchobj.ClickInList();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveCreditCurriculamBlock(browserstr);
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_TrainingActivityCurriBlockCredit();
            AddContentobj.SearchAndAddCurriculamContent(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
            AddContentobj.Click_Return();
        }
     [Test]
        public void d_create_an_ordered_block_and_add_learning_activities()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
            Createobj.FillCurriculumPage("ordered",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            TrainingHomeobj.MyResponsiblities_click();
            //Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr + "ordered");

            //Assertion for curriculum displayed on search
            Assert.IsTrue(ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "ordered"));
            ContentSearchobj.ClickInList();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("ordered",browserstr);
            TrainingActivitiesobj.Click_Backbutton();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_TrainingActivityCurriBlock1();
            AddContentobj.SearchAndAddCurriculamContent(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
           Assert.IsTrue( AddContentobj.Click_Return());
        }

        [Test]
        public void e_Search_and_Add_Training_Activities()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
            Createobj.FillCurriculumPage("tactivity",browserstr);

            //String Assertion on new curriculum creation 
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            TrainingHomeobj.MyResponsiblities_click();
            //Contentobj.ContentSearch_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr + "tactivity");

            //Assertion for curriculum displayed on search
            Assert.IsTrue(ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "tactivity"));
            ContentSearchobj.ClickInList();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("tactivity",browserstr);
            TrainingActivitiesobj.Click_Backbutton();
            Contentobj.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_TrainingActivityCurriBlock1();
            AddContentobj.SearchAndAddCurriculamContent(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
            Assert.IsTrue(AddContentobj.Click_Return());
        }


        [Test]
        public void f_Curriculum_Builder_can_See_Information_Regarding_the_Curriculum_from_the_Info_Icon_Link()
        {
            TrainingHomeobj.MyResponsiblities_click();
            //Trainingobj.SearchContent_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr + "tactivity");

            //Assertion for curriculum displayed on search
            ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "tactivity");
            ContentSearchobj.ClickInList();
            Assert.IsTrue(Contentobj.Click_Curriculam_InfoIcon(browserstr),browserstr);
            Contentobj.Click_Close_Infoicon();
        }

        [Test]
        public void g_curriculum_builder_can_access_the_details_page_of_a_content_item_added_to_the_curriculum_block()
        {
            TrainingHomeobj.MyResponsiblities_click();
          //  Trainingobj.SearchContent_Click();
            ContentSearchobj.Simple_Search( Variables.curriculumTitle+browserstr + "tactivity");

            //Assertion for curriculum displayed on search
            ContentSearchobj.ViewInList(Variables.curriculumTitle + browserstr + "tactivity");
            ContentSearchobj.ClickInList();
            Contentobj.Edit_TrainingActivities();
         //   TrainingActivitiesobj.Click_TrainingActivityCurriBlock1();
            Assert.IsTrue(Contentobj.Click_TrainingActivityBC(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr));
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
