using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1_Curriculum_NavigatetoDetailPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Curriculum_NavigatetoDetailPagesTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle = "TA" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        

        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test, Order(01)]
        public void tc_61678_As_a_learner_Accessing_Nested_Curriculum()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC61678");
            _test.Log(Status.Info, "Create a new General Course");           
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC61678_Pretochild");
            _test.Log(Status.Info, "Create a new General Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC61678_PretoParent");
            _test.Log(Status.Info, "Create a new General Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC61678");
            _test.Log(Status.Info, "Create Curriculum");
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "TC61678_Pretochild" + '"');
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "TC61678");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC61678_Parent");
            _test.Log(Status.Info, "Create Curriculum");
            AdminContentDetailsPage.AddPrequisites('"' + GeneralCourseTitle + "TC61678_Pretochild" + '"');
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(curriculamtitle + "TC61678");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");

            CommonSection.SearchCatalog('"' + curriculamtitle + "TC61678" + '"');
            _test.Log(Status.Pass, "Search the General Course Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC61678");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Verify Enroll button is not display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify prerequisite required message display on banner");

            CommonSection.SearchCatalog('"' + curriculamtitle + "TC61678_Parent" + '"');
            _test.Log(Status.Pass, "Search the General Course Course");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC61678_Parent");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Verify Enroll button is not display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify prerequisite required message display on banner");
            ContentDetailsPage.OverviewTab.Prerequisiteportlet.ClickPrerequisiteContentTitle(GeneralCourseTitle + "TC61678_Pretochild");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "TC61678_Pretochild"));
            ContentDetailsPage.ContentBanner.Click_Enrollbutton();
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            ContentDetailsPage.ClickBreadCrumb(curriculamtitle + "TC61678_Parent");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC61678_Parent"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            ContentDetailsPage.ContentBanner.Click_Enrollbutton();
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC61678"));
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isEnrollButtondisplay());
            _test.Log(Status.Pass, "Verify Enroll button is not display");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify prerequisite required message display on banner");
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());

        }
       

    }
}



