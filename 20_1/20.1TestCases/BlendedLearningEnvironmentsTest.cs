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
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_BlendedLearningEnvironmentsTest : TestBase
    {
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string BunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;         
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;       
        string ExtlearningTitle = "ExtLearning" + Meridian_Common.globalnum;
        bool TC60939;

        public P1_BlendedLearningEnvironmentsTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }



        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }


        [Test, Order(01)]
        public void tc_61247_Copy_Gradebook_Offset_availability_dates()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC61247");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            //ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button on Create Section Page");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            SectionDetailsPage.ClickContentTab();
            SectionDetailsPage.ContentTab.SelectAddAssignmentAddContentdropdown("Add Assignment");
            _test.Log(Status.Info, "Select Add Note from Add Content Dropdown");
            SectionDetailsPage.ContentTab.AddAssignmentAs("Graded Assignment");
            string Duedate=SectionDetailsPage.ContentTab.SetDuedate();
            Assert.IsTrue(ManageClassroomCoursePage.Click_Gradebook());
            _test.Log(Status.Pass, "Assertion Pass Gradebook is Visible from Section Detail Page");
            Assert.IsTrue(GradebookPage.GradebookTab.VerifyGradedContent());
            _test.Log(Status.Pass, "User able to grade test");

            SectionsPage.SelectCopySectionformActionDropdown();
            Assert.IsTrue(SectionsPage.CopySectionModal.VerifyCopySectionModalComponets());
            _test.Log(Status.Pass, "Verify Modal Title, Section Start date, Section title and timezone");
            SectionsPage.CopySectionModal.ChangeStartDate();
            SectionsPage.CopySectionModal.CopywithGradebooktoggle("Yes","Section1-Copy");
            _test.Log(Status.Info, "Copy new section with Include section content and gradebook toggle option as Yes");
            Assert.IsTrue(Driver.comparePartialString("The classroom section was copied.", SectionsPage.GetFeedbackMessage()));
            _test.Log(Status.Pass, "Verify Successful messasge");

            SectionsPage.ClickSectionTitle("Section1-Copy");
            ManageClassroomCoursePage.Click_Gradebook();
            Assert.IsTrue(GradebookPage.GradebookTab.VerifyGradedContent());
            _test.Log(Status.Pass, "Assertion Pass Gradebook are Available for new section");
            Assert.IsTrue(GradebookPage.GradebookTab.verifyDuedateisdisplay());
        }

    }
}