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
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_TrainingAssignmentsReportingDashboardsTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_TrainingAssignmentsReportingDashboardsTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string AICCCourseTitle = "AICC" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle= "TA" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        
        [Test, Order(1)]
        public void tc_60249_As_a_Admin_I_want_to_see_Summary_data_about_all_of_my_employees()
        {
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "Admin navigated to Avatar >> Reports");
            ReportsPage.TrainingAssignemntDashboard.Open();


        }
        [Test, Order(2)]
        public void tc_59940_As_a_Supervisor_User_Manager_I_want_to_see_my_direct_reports_in_Team()
         {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from current account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "login as User Manager");
            CommonSection.Manage.Teams();
            _test.Log(Status.Info, "Click on Teams from manage");
            Assert.IsTrue(TeamPage.IsPeopleCountDisplayed());
            _test.Log(Status.Pass, "Verify Employee count is displayed");
            Assert.IsTrue(TeamPage.VerifyAvatarIsDisplayed());
            _test.Log(Status.Pass, "Verify Employee count is displayed");
            Assert.IsTrue(TeamPage.VerifyEmployeeInitialsAreDisplayed());
            _test.Log(Status.Pass, "Verify Employee count is displayed");
            Assert.IsTrue(TeamPage.VerifyEmployeeNamesAreDisplayed());
            _test.Log(Status.Pass, "Verify Employee count is displayed");

        }
        [Test, Order(3)]
        public void tc_61732_As_an_Admin_I_want_to_visualize_assignments_and_completions_by_due_date()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from current account");
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "login as User Manager");
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "Click on Avatar and Reports");
            ReportsPage.TrainingAssignemntDashboard.Open();
            _test.Log(Status.Info, "Open Training Assignement dashboard");
            Assert.IsTrue(TrainingAssignemntDashboardPage.ischartdisplay());
            _test.Log(Status.Pass, "Verify chart is display");
            Assert.IsTrue(TrainingAssignemntDashboardPage.isfiltersaredisplay());
            _test.Log(Status.Pass, "Verify more filters are displaying");
            Assert.IsTrue(TrainingAssignemntDashboardPage.isresultsDisplayed());
            _test.Log(Status.Pass, "Verify results are displaying");

        }

    }
}



