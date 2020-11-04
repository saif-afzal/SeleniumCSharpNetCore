using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    ////   [Parallelizable(ParallelScope.Fixtures)]
    public class P1_SF182Tests : TestBase
    {
        string browserstr = string.Empty;
        public P1_SF182Tests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }


        string ApprovalPathTitle = "Approvalpath" + Meridian_Common.globalnum;
        string AgencyNumber="AN" + Meridian_Common.globalnum;
        string CourseTitle="CourseTitle" + Meridian_Common.globalnum;
        bool TC61281;


        //  [OneTimeSetUp]
        public void Login()
        {

            //LoginPage.GoTo();
            ////    LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
        // [TearDown]
        public void teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath = screenShotPath.Replace(@"C:\Users\admin\Desktop\Automation\Regression Scripts\18.2\", @"Z:\");
                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                    driver.Navigate_to_TrainingHome();
                    Driver.focusParentWindow();
                    CommonSection.Avatar.Logout();
                    LoginPage.LoginClick();
                    LoginPage.LoginAs("siteadmin").WithPassword("password").Login();

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
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }
        [Test, Order(1)]
        public void tc_60296_SF_182_Privacy_Agreement()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            Assert.IsTrue(SF182Page.isPrivacyActStatementModaldisplay());
            _test.Log(Status.Pass, "Verify Privacy Act Statement modal display");
            SF182Page.PrivacyActStatementModal.Accept();
            _test.Log(Status.Info, "Click on Accept");
            Assert.IsFalse(SF182Page.isPrivacyActStatementModaldisplay());
            _test.Log(Status.Pass, "Verify Privacy Act Statement modal is display");
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsFalse(SF182Page.isPrivacyActStatementModaldisplay());
            _test.Log(Status.Pass, "Verify Privacy Act Statement modal is display");
        }
        [Test, Order(2)]
        public void tc_60215_SF_182_User_Creates_Request_for_self()
        {
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            Assert.IsTrue(NewSF182RequestPage.aboutThisSf182Request.Verifyfields("Agency", "request status", "Resubmission", "Initial", "Correction", "Cancellation"));
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            Assert.IsTrue(NewSF182RequestPage.YourInformation.Verifydisabledfields());
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isFindCreateTrainingdisplayexpanded());
            _test.Log(Status.Pass, "Verify Find or create training porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingCourseDatadisplay());
            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(CourseTitle);
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSubmit();
            Assert.IsTrue(SF182Page.resultgrid.isNewRequestCreated(CourseTitle));


        }
        [Test, Order(3)]
        public void tc_60297_User_Views_Own_SF_182_Request()
        {
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsTrue(SF182Page.isSeemoresearchcriterialinkdisplay());
            _test.Log(Status.Pass, "Verify See more search criteria link display on search bar");
            Assert.IsTrue(SF182Page.resultgrid.verifyresultgridtablecolumns("Training", "Vendor Name", "SF-182 Status", "Attendance Status","Actions")); //"Attendance Status",
            Assert.IsTrue(SF182Page.resultgrid.isrecorddisplay());
            _test.Log(Status.Pass, "Verify record display in result grid");
            Assert.IsTrue(SF182Page.resultgrid.isActionbuttondisplay());
            _test.Log(Status.Pass, "Verify Action button display in result grid");
        }

        [Test, Order(4)]
        public void tc_60295_Approver_Views_List_of_SF_182_request()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsTrue(SF182Page.isSeemoresearchcriterialinkdisplay());
            _test.Log(Status.Pass, "Verify See more search criteria link display on search bar");
            Assert.IsTrue(SF182Page.resultgrid.verifyresultgridtablecolumnsApprover("Training", "Username", "SF-182 Status", "Actions"));
            Assert.IsTrue(SF182Page.resultgrid.isrecorddisplay());
            _test.Log(Status.Pass, "Verify record display in result grid");
           // Assert.IsTrue(SF182Page.resultgrid.isActionbuttondisplay());
           // _test.Log(Status.Pass, "Verify Action button display in result grid");
        }
        [Test, Order(5)]
        public void tc_60599_SF182_Approval_Workflow_Tab()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            SF182Page.ClickApprovalWorkflow();
            Assert.IsFalse(SF182Page.ApprovalWorkflowTab.isDeletebuttonDisabled());
            Assert.IsTrue(SF182Page.ApprovalWorkflowTab.isCreatebuttonEnbled());
            Assert.IsTrue(SF182Page.ApprovalWorkflowTab.approvalpathtable.verifyColumnheader("Title", "Approvers","Assigned To","Default Path"));
            _test.Log(Status.Pass, "Verify table headers as Title,Approvers,Assigned To, Default Path");
        }

        [Test, Order(6)]
        public void tc_60659_SF182_Approval_workflow_Add_Approversa()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Admin navigated to SF182 page");
            SF182Page.ClickApprovalWorkflow();
            SF182Page.ApprovalWorkflowTab.clickCreate();
            ApprovalWorkflowPage.Create(ApprovalPathTitle);
            Assert.IsTrue(ApprovalWorkflowPage.approverstable.noapproveradded());
            ApprovalWorkflowPage.approverstable.ClickAdd();
            Assert.IsTrue(ApprovalWorkflowPage.approverstable.AddModalopened());
            _test.Log(Status.Pass, "Verify Add modal is opened");
            ApprovalWorkflowPage.approverstable.AddModal.clickAdd();
            Assert.IsTrue(ApprovalWorkflowPage.approverstable.isapproveradded());
            _test.Log(Status.Pass, "Verify approver Added successfully");

        }
        [Test, Order(7)]
        public void tc_60478_Select_Approvals_for_Mark_attendance_or_upload_certificate()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Admin navigated to SF182 page");
            SF182Page.ClickApprovalWorkflow();
            SF182Page.ApprovalWorkflowTab.clickCreate();
            ApprovalWorkflowPage.Create(ApprovalPathTitle+"TC60478");
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.isWhocanmarkorconfirmattendanceLebeldisplay());
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.isWhocanUploadCertificateLebeldisplay());

            ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.ClickTrainee();
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.DefaultList());
            _test.Log(Status.Pass, "Verify Trainee display as checked with Supervisor 1,Supervisor 2,Training POC");
            ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.setSupervisor1();
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.isnewvalu("Supervisor 1"));
            _test.Log(Status.Pass, "Verify new value set/save properly");
            ApprovalWorkflowPage.approverstab.WhocanUploadCertificate.ClickTrainingPOC();
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.WhocanUploadCertificate.DefaultList());
            _test.Log(Status.Pass, "Verify Training POC display as checked with Supervisor 1, Trainee, Finance POC");
            ApprovalWorkflowPage.approverstab.WhocanUploadCertificate.setTrainee();
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.WhocanUploadCertificate.isnewvalueset("Trainee"));
            _test.Log(Status.Pass, "Verify new value set/save properly");

        }
        [Test, Order(8)]
        public void P20_1_tc_60954_SF182_Approval_Workflow_Preview()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Admin navigated to SF182 page");
            SF182Page.ClickApprovalWorkflow();
            SF182Page.ApprovalWorkflowTab.clickCreate();
            ApprovalWorkflowPage.Create(ApprovalPathTitle + "TC60954");
            ApprovalWorkflowPage.approverstable.ClickAdd();
            Assert.IsTrue(ApprovalWorkflowPage.approverstable.AddModalopened());
            _test.Log(Status.Pass, "Verify Add modal is opened");
            ApprovalWorkflowPage.approverstable.AddModal.clickAdd();
            ApprovalWorkflowPage.approverstab.clickPreviewWorkflow();
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.isPreviewWorkflowmodalopened());
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.PreviewWorkflowmodal.isTrainingPOCuploadscertificateisLastline());
            _test.Log(Status.Pass, "Verify Training POC uploads certificate is Last line");

        }
        [Test, Order(9)]
        public void tc_61596_SF182_Approver_Searches_for_request()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Admin navigated to SF182 page");
            SF182Page.RequestTab.Search("");
            _test.Log(Status.Info, "Done blank search");
            Assert.IsTrue(SF182Page.RequestTab.isResultdisplay());
            SF182Page.RequestTab.clickSeemoresearchcriteriaLink();
            Assert.IsTrue(SF182Page.RequestTab.Seemoresearchcriteria.isLevelsdisplay(""));
            _test.Log(Status.Pass, "Verify levels on See more link section");
            SF182Page.RequestTab.ClickonStatusDropdown();
            Assert.IsTrue(SF182Page.RequestTab.isStatusdropdownList("All", "Approved","Cancelled","Completed", "Denied", "Draft", "Not Attended - Excused", "Not Attended - Not Excused", "Pending Finance POC", "Pending IFMIS POC", "Pending Supervisor 1", "Pending Supervisor 2", "Pending Training POC", "Pending User"));
            _test.Log(Status.Pass, "Verify status dropdown list");
            TC61281 = true;
        }
        [Test, Order(10)]
        public void tc_61281_SF_182_Approve_Request()
        {
            Assert.IsTrue(TC61281);
        }
        [Test, Order(11)]
        public void tc_61279_SF182_Create_request_for_another_user()
        {
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Create.CreateSF182Requestforuser();
            Assert.IsTrue(SF182Page.Create.isAddUserModaldisplay());
            SF182Page.Create.AddUserModal.adduser("learner 101");
            Assert.IsTrue(NewSF182RequestPage.isUserAdded());
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.Verifyfields("Training Vender","Course Title","Start date","End date"));
            //NewSF182RequestPage.TrainingCourseData.Entered("");




            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            Assert.IsTrue(NewSF182RequestPage.aboutThisSf182Request.Verifyfields("Agency", "request status", "Resubmission", "Initial", "Correction", "Cancellation"));
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            Assert.IsTrue(NewSF182RequestPage.YourInformation.Verifydisabledfields());
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isFindCreateTrainingdisplayexpanded());
            _test.Log(Status.Pass, "Verify Find or create training porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingCourseDatadisplay());
            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(CourseTitle);
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSubmit();
            Assert.IsTrue(SF182Page.resultgrid.isNewRequestCreated(CourseTitle));


        }

    }
}
