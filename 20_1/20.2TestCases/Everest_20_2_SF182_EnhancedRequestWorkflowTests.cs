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
    public class NF_Everest_20_2_SF182_EnhancedRequestWorkflowTests : TestBase
    {
        string browserstr = string.Empty;
        public NF_Everest_20_2_SF182_EnhancedRequestWorkflowTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }


        string ApprovalPathTitle = "Approvalpath" + Meridian_Common.globalnum;
        string AgencyNumber="AN" + Meridian_Common.globalnum;
        string SF182CourseTitle = "SF182CourseTitle" + Meridian_Common.globalnum;
        bool TC61281;
        string DenialTitle= "Denial" + Meridian_Common.globalnum;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
        
        
        [Test, Order(1)]
        public void tc_63269_SF182_Workflow_path_cannot_be_saved_with_Empty_fields_for_Marking_Attendance()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            Assert.IsTrue(SF182Page.isPrivacyActStatementModaldisplay());
            _test.Log(Status.Pass, "Verify Privacy Act Statement modal display");
            SF182Page.PrivacyActStatementModal.Accept();
            _test.Log(Status.Info, "Click on Accept");
            SF182Page.ClickApprovalWorkflow();
            Assert.IsFalse(SF182Page.ApprovalWorkflowTab.isDeletebuttonDisabled());
            Assert.IsTrue(SF182Page.ApprovalWorkflowTab.isCreatebuttonEnbled());
            _test.Log(Status.Pass, "verify Create button is Enabled");
            SF182Page.ApprovalWorkflowTab.clickCreate();
            ApprovalWorkflowPage.Create(ApprovalPathTitle);
            Assert.IsTrue(ApprovalWorkflowPage.approverstable.noapproveradded());
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.isWhocanmarkorconfirmattendanceLebeldisplay());
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.isWhocanUploadCertificateLebeldisplay());

            ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.ClickTrainee();
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.DefaultList());
            _test.Log(Status.Pass, "Verify Trainee display as checked with Supervisor 1,Supervisor 2,Training POC");
            ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.UnSelectTrainee();
            _test.Log(Status.Info, "Click Trainee to un checked ");
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.isSaveOptionisDisabled());
            _test.Log(Status.Info, "Verify use can't save it");
        }
        [Test, Order(2)]
        public void tc_60215_SF_182_User_Creates_Request_for_self()
        {
            //Contiue to 63269
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.isWhocanUploadCertificateLebeldisplay());
            ApprovalWorkflowPage.approverstab.WhocanUploadCertificate.ClickTrainingPOC();
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.WhocanUploadCertificate.DefaultList());
            _test.Log(Status.Pass, "Verify Training POC display as checked with Supervisor 1, Trainee, Finance POC");
            ApprovalWorkflowPage.approverstab.WhocanUploadCertificate.UnselectTraininPOC();
            _test.Log(Status.Info, "Click TraineePOC to unchecked ");
            Assert.IsTrue(ApprovalWorkflowPage.approverstab.Whocanmarkorconfirmattendance.isSaveOptionisDisabled());
            _test.Log(Status.Info, "Verify use can't save it");
        } 
        [Test, Order(3)]
        public void tc_63497_Admin_Edit_Vendors_for_SF182()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.CLickVendorsTab();
            _test.Log(Status.Info, "Click Vendors Tab");
            Assert.IsTrue(SF182Page.VendorsTab.isExistingVendorsdisplay());
            _test.Log(Status.Pass, "Verify is existing vendors are display in list");
            string VenderName = SF182Page.VendorsTab.titleofFistVendername();
            SF182Page.VendorsTab.ClickFistVendorTitle();
            Assert.IsTrue(SF182Page.VendorsTab.VendorModaldisplay());
            _test.Log(Status.Pass, "Verify is existing vendors are display in list");
            SF182Page.VendorsTab.VendorModald.UpdateVenderTitle(VenderName+"1");
            _test.Log(Status.Pass, "Verify is existing vendors are display in list");
            Assert.IsTrue(SF182Page.VendorsTab.isVendernameisUpdated(VenderName));
            _test.Log(Status.Pass, "Verify vender name is updated");
        }
        [Test, Order(4)]
        public void tc_63498_Admin_Change_the_status_of_Vendors_SF_182()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.CLickVendorsTab();
            _test.Log(Status.Info, "Click Vendors Tab");
            Assert.IsTrue(SF182Page.VendorsTab.isExistingVendorsdisplay());
            _test.Log(Status.Pass, "Verify is existing vendors are display in list");
            string VenderName = SF182Page.VendorsTab.titleofFistVendername();
            SF182Page.VendorsTab.vendersList.ChangestatusofFirstrecord("Inactive");
            Assert.IsTrue(Driver.comparePartialString("Success The changes were saved.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            SF182Page.VendorsTab.vendersList.ChangestatusofFirstrecord("Active");
            Assert.IsTrue(Driver.comparePartialString("Success The changes were saved.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
        }
        [Test, Order(5)]
        public void tc_63617_As_admin_search_for_Sf_182_request_by_requester_email_address()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.ClickSeemoreSearchcriteria();
            SF182Page.moreSearchcriteria.TraineeEmailAddress("sf182user@test.com").Search();
            Assert.IsTrue(SF182Page.RequestTab.isResultdisplay());
            SF182Page.resultgrid.ClickUserNameTitle();
            Assert.IsTrue(SF182Page.resultgrid.Informationmodal.emailid() == "sf182user@test.com");
            _test.Log(Status.Pass, "Verify search email display into user information modal");
        }
        [Test, Order(6)]
        public void tc_63519_Admin_can_find_searchable_dropdown_list_in_SF_182_request_form_for_Training_Vendor_At_Search_criteria_and_New_Requests()
        {
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.isTrainingVendordropdowndisplay());
            _test.Log(Status.Pass, "Verify Training Vendor list dropdown display");
            NewSF182RequestPage.TrainingCourseData.TrainingVendor.SelectVenderName();

            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickSeemoreSearchcriteria();
            Assert.IsTrue(SF182Page.moreSearchcriteria.isVenderNamedropdowndisplay());
            SF182Page.moreSearchcriteria.VenderNamedropdown.SelectVender();
            SF182Page.ClickSearchIcon();
        }
        [Test, Order(7)]
        public void tc_63815_As_a_learner_Enter_Edit_Request_detail()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("sf182user1").WithPassword("").Login();
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            Assert.IsTrue(SF182Page.isPrivacyActStatementModaldisplay());
            _test.Log(Status.Pass, "Verify Privacy Act Statement modal display");
            SF182Page.PrivacyActStatementModal.Accept();
            _test.Log(Status.Info, "Click on Accept");           
            //request for draft
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");

            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(SF182CourseTitle+ "TC63815");
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSaveasDraft();

            CommonSection.Dropdowntoggle.SF182();
            SF182Page.Search(SF182CourseTitle + "TC63815");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63815"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63815");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63815"));
            Assert.IsTrue(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user can submit this form");
            Assert.IsTrue(SF182RequestDetailsPage.aboutThisSf182Request.EnterAgencyNumberiseditble());
            SF182RequestDetailsPage.ClickSubmitbutton();
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle+ "TC63815");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63815"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63815");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle+ "TC63815"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsFalse(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());

        }
        [Test, Order(8)]
        public void tc_63517_Learner_can_find_searchable_dropdown_list_in_SF_182_request_form_for_Training_Vendor_New_Request_and_Search_Criteria()
        {
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");           
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.isTrainingVendordropdowndisplay());
            _test.Log(Status.Pass, "Verify Training Vendor list dropdown display");
            NewSF182RequestPage.TrainingCourseData.TrainingVendor.SelectVenderName();

            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickSeemoreSearchcriteria();
            Assert.IsTrue(SF182Page.moreSearchcriteria.isVenderNamedropdowndisplay());
            SF182Page.moreSearchcriteria.VenderNamedropdown.SelectVender();
            SF182Page.ClickSearchIcon();
            //Assert.IsTrue(SF182Page.resultgrid.verifyresults());


        }
        [Test, Order(9)]
        public void tc_63817_As_a_supervisor_1_Enter_Edit_Request_detail()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("supervisor1").WithPassword("").Login();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");

            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(SF182CourseTitle + "TC63817");
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSaveasDraft();
            CommonSection.Learn.SF182();
            SF182Page.Search(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63817"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63817"));
            Assert.IsTrue(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user can submit this form");
            Assert.IsTrue(SF182RequestDetailsPage.aboutThisSf182Request.EnterAgencyNumberiseditble());
            SF182RequestDetailsPage.ClickSubmitbutton();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63817"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63817"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());

            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));            
            SF182Page.Search(SF182CourseTitle + "TC63815");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63815"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63815");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63815"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsFalse(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.TrainingDetails.isTrainingDutyFieldisEnabled());
            _test.Log(Status.Pass, "Verify only training details can edit by superviser 1");

            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manager >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63815");
            SF182Page.resultgrid.ClickTakeAction(SF182CourseTitle + "TC63815");
            SF182Page.resultgrid.TakeAction("Approve");
        }
        [Test, Order(10)]
        public void tc_63618_As_supervisor_1_search_for_Sf_182_request_by_requester_email_address()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.ClickSeemoreSearchcriteria();
            SF182Page.moreSearchcriteria.TraineeEmailAddress("sf182user@test.com").Search();
            Assert.IsTrue(SF182Page.RequestTab.isResultdisplay());
            SF182Page.resultgrid.ClickUserNameTitle();
            Assert.IsTrue(SF182Page.resultgrid.Informationmodal.emailid() == "sf182user@test.com");
            _test.Log(Status.Pass, "Verify search email display into user information modal");
        }
        [Test, Order(11)]
        public void tc_63521_Supervisor_1_can_find_searchable_dropdown_list_in_SF_182_request_form_for_Training_Vendor_At_Search_criteria_and_New_Requests()
        {
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.isTrainingVendordropdowndisplay());
            _test.Log(Status.Pass, "Verify Training Vendor list dropdown display");
            NewSF182RequestPage.TrainingCourseData.TrainingVendor.SelectVenderName();

            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickSeemoreSearchcriteria();
            Assert.IsTrue(SF182Page.moreSearchcriteria.isVenderNamedropdowndisplay());
            SF182Page.moreSearchcriteria.VenderNamedropdown.SelectVender();
            SF182Page.ClickSearchIcon();
        }
        [Test, Order(12)]
        public void tc_63818_As_a_supervisor_2_Enter_Edit_Request_detail()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("supervisor2").WithPassword("").Login();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");

            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(SF182CourseTitle + "TC63818");
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSaveasDraft();
            CommonSection.Learn.SF182();
            SF182Page.Search(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63818"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63818"));
            Assert.IsTrue(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user can submit this form");
            Assert.IsTrue(SF182RequestDetailsPage.aboutThisSf182Request.EnterAgencyNumberiseditble());
            SF182RequestDetailsPage.ClickSubmitbutton();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63818");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63818"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63818");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63818"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());

            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manager >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63817"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63817");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63817"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsFalse(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.TrainingDetails.isTrainingDutyFieldisEnabled());
            _test.Log(Status.Pass, "Verify only training details can edit by superviser 1");

            //CommonSection.Manage.SF182();
            //_test.Log(Status.Info, "Navigate to Manager >> SF182");
            //Assert.IsTrue(Driver.checkTitle("SF-182"));
            //SF182Page.Search(SF182CourseTitle + "TC63815");
            //SF182Page.resultgrid.ClickTakeAction(SF182CourseTitle + "TC63815");
            //SF182Page.resultgrid.TakeAction("Approve");
        }
        [Test, Order(13)]
        public void tc_63619_As_supervisor_2_search_for_Sf_182_request_by_requester_email_address()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.ClickSeemoreSearchcriteria();
            SF182Page.moreSearchcriteria.TraineeEmailAddress("sf182user@test.com").Search();
            Assert.IsTrue(SF182Page.RequestTab.isResultdisplay());
            SF182Page.resultgrid.ClickUserNameTitle();
            Assert.IsTrue(SF182Page.resultgrid.Informationmodal.emailid() == "sf182user@test.com");
            _test.Log(Status.Pass, "Verify search email display into user information modal");
        }
        [Test, Order(14)]
        public void tc_63522_Supervisor_2_can_find_searchable_dropdown_list_in_SF_182_request_form_for_Training_Vendor_At_Search_criteria_and_New_Requests()
        {
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.isTrainingVendordropdowndisplay());
            _test.Log(Status.Pass, "Verify Training Vendor list dropdown display");
            NewSF182RequestPage.TrainingCourseData.TrainingVendor.SelectVenderName();

            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickSeemoreSearchcriteria();
            Assert.IsTrue(SF182Page.moreSearchcriteria.isVenderNamedropdowndisplay());
            SF182Page.moreSearchcriteria.VenderNamedropdown.SelectVender();
            SF182Page.ClickSearchIcon();
        }
        [Test, Order(15)]
        public void tc_63820_As_a_Training_POC_Enter_Edit_Request_detail()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("trainingpoc").WithPassword("").Login();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to Learn >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");

            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(SF182CourseTitle + "TC63820");
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSaveasDraft();
            CommonSection.Learn.SF182();
            SF182Page.Search(SF182CourseTitle + "TC63820");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63820"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63820");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63820"));
            Assert.IsTrue(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user can submit this form");
            Assert.IsTrue(SF182RequestDetailsPage.aboutThisSf182Request.EnterAgencyNumberiseditble());
            SF182RequestDetailsPage.ClickSubmitbutton();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63820");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63820"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63820");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63820"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());
            
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manager >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63818");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63818"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63818");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63818"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsFalse(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.TrainingDetails.isTrainingDutyFieldisEnabled());
            _test.Log(Status.Pass, "Verify only training details can edit by superviser 1");

            //CommonSection.Manage.SF182();
            //_test.Log(Status.Info, "Navigate to Manager >> SF182");
            //Assert.IsTrue(Driver.checkTitle("SF-182"));
            //SF182Page.Search(SF182CourseTitle + "TC63815");
            //SF182Page.resultgrid.ClickTakeAction(SF182CourseTitle + "TC63815");
            //SF182Page.resultgrid.TakeActionbytrainingPOC("Approve");
            //_test.Log(Status.Info, "Approve the resuest with training details");
            //SF182Page.resultgrid.ClickTakeAction(SF182CourseTitle + "TC63815");
            //SF182Page.resultgrid.TakeActionbytrainingPOC("Mark Attendance");
            //_test.Log(Status.Info, "Mark attendance");

        }
        [Test, Order(16)]
        public void tc_63620_As_training_POC_search_for_Sf_182_request_by_requester_email_address()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.ClickSeemoreSearchcriteria();
            SF182Page.moreSearchcriteria.TraineeEmailAddress("sf182user@test.com").Search();
            Assert.IsTrue(SF182Page.RequestTab.isResultdisplay());
            SF182Page.resultgrid.ClickUserNameTitle();
            Assert.IsTrue(SF182Page.resultgrid.Informationmodal.emailid() == "sf182user@test.com");
            _test.Log(Status.Pass, "Verify search email display into user information modal");
        }
        [Test, Order(6)]
        public void tc_63639_Training_POC_can_find_searchable_dropdown_list_in_SF_182_request_form_for_Training_Vendor_At_Search_criteria_and_New_Requests()
        {
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.isTrainingVendordropdowndisplay());
            _test.Log(Status.Pass, "Verify Training Vendor list dropdown display");
            NewSF182RequestPage.TrainingCourseData.TrainingVendor.SelectVenderName();

            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickSeemoreSearchcriteria();
            Assert.IsTrue(SF182Page.moreSearchcriteria.isVenderNamedropdowndisplay());
            SF182Page.moreSearchcriteria.VenderNamedropdown.SelectVender();
            SF182Page.ClickSearchIcon();
        }

        [Test, Order(17)]
        public void tc_63819_As_a_IFMIS_POC_Enter_Edit_Request_detail()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("srifmispoc").WithPassword("").Login();
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");

            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(SF182CourseTitle + "TC63819");
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSaveasDraft();
            CommonSection.Learn.SF182();
            SF182Page.Search(SF182CourseTitle + "TC63819");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63819"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63819");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63819"));
            Assert.IsTrue(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user can submit this form");
            Assert.IsTrue(SF182RequestDetailsPage.aboutThisSf182Request.EnterAgencyNumberiseditble());
            SF182RequestDetailsPage.ClickSubmitbutton();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63819");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "T63819"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63819");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63819"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());
        }
        [Test, Order(18)]
        public void tc_63622_As_IFMIS_POC_search_for_Sf_182_request_by_requester_email_address()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.ClickSeemoreSearchcriteria();
            SF182Page.moreSearchcriteria.TraineeEmailAddress("sf182user@test.com").Search();
            Assert.IsTrue(SF182Page.RequestTab.isResultdisplay());
            SF182Page.resultgrid.ClickUserNameTitle();
            Assert.IsTrue(SF182Page.resultgrid.Informationmodal.emailid() == "sf182user@test.com");
            _test.Log(Status.Pass, "Verify search email display into user information modal");
        }
        [Test, Order(6)]
        public void tc_63520_IFMIS_POC_can_find_searchable_dropdown_list_in_SF_182_request_form_for_Training_Vendor_At_Search_criteria_and_New_Requests()
        {
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.isTrainingVendordropdowndisplay());
            _test.Log(Status.Pass, "Verify Training Vendor list dropdown display");
            NewSF182RequestPage.TrainingCourseData.TrainingVendor.SelectVenderName();

            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickSeemoreSearchcriteria();
            Assert.IsTrue(SF182Page.moreSearchcriteria.isVenderNamedropdowndisplay());
            SF182Page.moreSearchcriteria.VenderNamedropdown.SelectVender();
            SF182Page.ClickSearchIcon();
        }
        [Test, Order(19)]
        public void tc_63821_As_a_Finance_POC_Enter_Edit_Request_detail()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("srfinancepoc").WithPassword("").Login();
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");

            NewSF182RequestPage.FindorCreateTraining.entermandetorydata(SF182CourseTitle + "TC63821");
            _test.Log(Status.Info, "Enter Course title, start and end date");
            NewSF182RequestPage.FindorCreateTraining.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isCostandBillingInformationdisplayExpanded());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.enterCosts();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.isTotalcostisdisabled());
            NewSF182RequestPage.FindorCreateTraining.CostandBillingInformation.clickNext();
            Assert.IsTrue(NewSF182RequestPage.FindorCreateTraining.isTrainingDetaisdisplayexpanded());
            NewSF182RequestPage.ClickSaveasDraft();
            CommonSection.Learn.SF182();
            SF182Page.Search(SF182CourseTitle + "TC63820");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "TC63821"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63821");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63821"));
            Assert.IsTrue(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user can submit this form");
            Assert.IsTrue(SF182RequestDetailsPage.aboutThisSf182Request.EnterAgencyNumberiseditble());
            SF182RequestDetailsPage.ClickSubmitbutton();
            CommonSection.Learn.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.Search(SF182CourseTitle + "TC63821");
            Assert.IsTrue(SF182Page.resultgrid.isSearchrecorddisplay(SF182CourseTitle + "T63821"));
            SF182Page.resultgrid.clicksf182requestTitle(SF182CourseTitle + "TC63821");
            Assert.IsTrue(SF182RequestDetailsPage.ContentBanner.Title(SF182CourseTitle + "TC63821"));
            Assert.IsFalse(SF182RequestDetailsPage.isSubmitbuttondisplay());
            _test.Log(Status.Pass, "Verify user cann't see submit this form");
            SF182RequestDetailsPage.clickRequstDetailsTab();
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.isSavebuttondisplay());
            Assert.IsTrue(SF182RequestDetailsPage.RequstDetailsTab.aboutThisSf182Request.EnterAgencyNumberiseditble());
        }
        [Test, Order(20)]
        public void tc_63621_As_Finance_POC_search_for_Sf_182_request_by_requester_email_address()
        {
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            SF182Page.ClickSeemoreSearchcriteria();
            SF182Page.moreSearchcriteria.TraineeEmailAddress("sf182user@test.com").Search();
            Assert.IsTrue(SF182Page.RequestTab.isResultdisplay());
            SF182Page.resultgrid.ClickUserNameTitle();
            Assert.IsTrue(SF182Page.resultgrid.Informationmodal.emailid() == "sf182user@test.com");
            _test.Log(Status.Pass, "Verify search email display into user information modal");
        }
        [Test, Order(6)]
        public void tc_63640_Finance_POC_can_find_searchable_dropdown_list_in_SF_182_request_form_for_Training_Vendor_At_Search_criteria_and_New_Requests()
        {
            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickCreate();
            Assert.IsTrue(NewSF182RequestPage.isAboutThisSF_182RequestPortletdisplayexpanded());
            NewSF182RequestPage.aboutThisSf182Request.EnterAgencyNumber(AgencyNumber);
            NewSF182RequestPage.aboutThisSf182Request.ClickNext();
            Assert.IsTrue(NewSF182RequestPage.isYourinformationdisplayexpanded());
            _test.Log(Status.Pass, "Verify Your information porlet expnded after done next from Agency");
            NewSF182RequestPage.YourInformation.ClickNext();
            _test.Log(Status.Info, "Click Next on Your information portlety");
            Assert.IsTrue(NewSF182RequestPage.isTrainingCourseDatadisplayexpanded());
            _test.Log(Status.Pass, "Verify training course data porlet expnded after done next from Your Information");
            Assert.IsTrue(NewSF182RequestPage.TrainingCourseData.isTrainingVendordropdowndisplay());
            _test.Log(Status.Pass, "Verify Training Vendor list dropdown display");
            NewSF182RequestPage.TrainingCourseData.TrainingVendor.SelectVenderName();

            CommonSection.Dropdowntoggle.SF182();
            _test.Log(Status.Info, "Navigate to dropdown >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.ClickSeemoreSearchcriteria();
            Assert.IsTrue(SF182Page.moreSearchcriteria.isVenderNamedropdowndisplay());
            SF182Page.moreSearchcriteria.VenderNamedropdown.SelectVender();
            SF182Page.ClickSearchIcon();
        }
        [Test, Order(21)]
        public void tc_63282_As_Admin_manage_list_of_SF182_Reason_of_Denial()

        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.Manage.SF182();
            _test.Log(Status.Info, "Navigate to Manage >> SF182");
            Assert.IsTrue(Driver.checkTitle("SF-182"));
            SF182Page.CLickReasonforDenialTab();
            SF182Page.ReasonforDenialTab.CreateNew(DenialTitle);
            SF182Page.ReasonforDenialTab.search(DenialTitle);
            _test.Log(Status.Info, "Search Denial Resone title");
            SF182Page.ReasonforDenialTab.ResultList.UpdateTitle(DenialTitle,DenialTitle + "update");
            Assert.IsTrue(SF182Page.ReasonforDenialTab.ResultList.isTitleUpdated(DenialTitle + "update"));
            _test.Log(Status.Pass, "Is Denial title updated");
            SF182Page.ReasonforDenialTab.ResultList.ChnageStatus(DenialTitle + "update","Inactive");
            Assert.IsTrue(Driver.comparePartialString("Success The changes were saved.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            SF182Page.ReasonforDenialTab.ResultList.ChnageStatus(DenialTitle + "update", "Active");
            Assert.IsTrue(Driver.comparePartialString("Success The changes were saved.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");

        }
    }
}
