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
    public class NF_CourseNotifications_CustomizedMessagesTest : TestBase
    {
        string browserstr = string.Empty;
        bool TC35342;
        bool TC63434;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        bool TC63391;
        bool TC63433;
        bool TC63268;
        string classroomcoursetitle = "CRT" + Meridian_Common.globalnum;
        string Contentlevelseting;
        bool TC63231;
        bool TC63647;
        bool TC63879;
        bool TC63929;
        bool TC63930;
        public NF_CourseNotifications_CustomizedMessagesTest(string browser)
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

        [Test, Order(1)]
        public void tc_63322_As_Domain_Admin_I_want_to_review_notification_for_Classroom_sections()
        {
            #region Create a classroom course and add multiple section having cost without cost
            //CommonSection.CreateLink.ClassroomCourse();
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63322");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            #endregion

            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.inactiveEmailDisplay());
            _test.Log(Status.Pass, "Verify inactive Email are not visible here");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Columnheader("Email Title", "Trigger", "On/Off", "Action", "Info"));
            _test.Log(Status.Pass, "Verify Email Table column headers");
            TC63268 = true;
        }
        [Test, Order(2)]
        public void tc_63268_As_an_admin_I_want_to_review_notification_for_Classroom_sections()
        {
            Assert.IsTrue(TC63268);
        }
        [Test, Order(3)]
        public void tc_63393_As_a_Domain_Admin_I_want_to_send_test_email()
        {
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.CancelSendTestEmail();
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmailtoUser();
            Assert.IsTrue(Driver.comparePartialString("The test email was sent.", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched");
            TC63391 = true;
        }
        [Test, Order(4)]
        public void tc_63391_As_an_Admin_I_want_to_send_test_email()
        {
            Assert.IsTrue(TC63391);
        }
        [Test, Order(5)]
        public void tc_63363_As_an_Instructor_I_want_to_review_notification_for_Classroom_sections_where_it_is_not_available_to_me_by_default()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("Somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as classroom instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage >> Training ");
            TrainingPage.QuickLinks.ClickInstructorTools();
            _test.Log(Status.Info, "Click Instructor tools link from Quick link portlet ");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "_TC63322");
            _test.Log(Status.Info, "Expand the classroom course ");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "_TC63322");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(GradebookPage.GradebookTabDisplay());
            Assert.IsFalse(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is not display");

        }
        
        [Test, Order(6)]
        public void tc_63389_Admin_provides_permission_to_Instructor_and_Instructor_review_notification_for_Classroom_sections()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.clickSectionDetailsTab();
            SectionDetailsPage.SectionDetailsTab.ClickEditPermissions();
            Assert.IsTrue(SectionDetailsPage.SectionDetailsTab.Permissions.isInheritcoursepermissionsisChecked());
            _test.Log(Status.Pass, "Verify In the section permission edit page In herit course permissions is checked");
            SectionDetailsPage.SectionDetailsTab.Permissions.UnCheckInheritcoursepermissions();
            Assert.IsTrue(SectionDetailsPage.SectionDetailsTab.Permissions.isAssignPermissionsButtonDisplay());
            SectionDetailsPage.SectionDetailsTab.Permissions.ClickAssignPermissions();
            SectionDetailsPage.SectionDetailsTab.Permissions.AssignPermissions("Somnath1");
            Assert.IsTrue(SectionDetailsPage.SectionDetailsTab.Permissions.isInheritcoursepermissionsisChecked());
            _test.Log(Status.Pass, "Verify In the section permission edit page In herit course permissions is checked");
            SectionDetailsPage.SectionDetailsTab.Permissions.UnCheckInheritcoursepermissions();
            SectionDetailsPage.SectionDetailsTab.Permissions.ClickSave();

            CommonSection.Logout();
            LoginPage.LoginAs("Somnath1_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as classroom instructor");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to manage >> Training ");
            TrainingPage.QuickLinks.ClickInstructorTools();
            _test.Log(Status.Info, "Click Instructor tools link from Quick link portlet ");
            InstructorToolsPage.TeachingScheduleTab.ClickExpandIcon(classroomcoursetitle + "_TC63322");
            _test.Log(Status.Info, "Expand the classroom course ");
            InstructorToolsPage.TeachingScheduleTab.Enrollment.ClickManageGradebook(classroomcoursetitle + "_TC63322");
            _test.Log(Status.Info, "Click Manage Gradebook link on Instructor tool page");
            Assert.IsTrue(GradebookPage.GradebookTabDisplay());
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display Now");
            SectionDetailsPage.ClickNotificationTab();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.CancelSendTestEmail();
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmailtoUser();
            Assert.IsTrue(Driver.comparePartialString("The test email was sent.", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            TC63434 = true;

        }
        [Test, Order(7)]
        public void tc_63434_As_an_Instructor_I_want_to_turn_an_email_notification_On_Off_when_admin_provided_me_permission()
        {
            Assert.IsTrue(TC63434);
        }
        [Test, Order(8)]
        public void tc_63394_As_an_Instructor_I_want_to_send_test_email()
        {
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.CancelSendTestEmail();
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmailtoUser();
            Assert.IsTrue(Driver.comparePartialString("The test email was sent.", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched");
        }

        [Test, Order(9)]
        public void tc_63321_As_course_manager_I_want_to_review_notification_for_Classroom_sections()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.clickAssignPermission();
            _test.Log(Status.Info, "Click Assign Permission");
            EditPermissionsPage.AssignPermissionTo("somnath course manager");

            CommonSection.Logout();
            LoginPage.LoginAs("srcoursemanager").WithPassword("password").Login();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ManageClassroomCoursePage.Clicktab("Sections");
            //create new section
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");            
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            //ManageClassroomCoursePage.ClickSectionTitle("Section1");
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.inactiveEmailDisplay());
            _test.Log(Status.Pass, "Verify inactive Email are not visible here");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Columnheader("Email Title", "Trigger", "On/Off", "Action", "Info"));
            _test.Log(Status.Pass, "Verify Email Table column headers");
        }
        [Test, Order(10)]
        public void tc_63392_As_a_Course_Manager_I_want_to_send_test_email()
        {
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.CancelSendTestEmail();
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmail();
            Assert.IsTrue(SectionDetailsPage.NotificationTab.EmailTable.Actions.isSendTestEmailModaldisplay());
            _test.Log(Status.Pass, "Verify Send Test Email modal display");
            SectionDetailsPage.NotificationTab.EmailTable.Actions.SendTestEmailtoUser();
            Assert.IsTrue(Driver.comparePartialString("The test email was sent.", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
        }
        [Test, Order(11)]
        public void tc_63430_As_a_Course_Manager_I_want_to_turn_an_email_notification_On_Off()
        {
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.EmailTable.TurnoffFirstEmail();
            Assert.IsTrue(Driver.comparePartialString("Success The changes were saved.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
        }
        [Test, Order(12)]
        public void tc_63431_As_an_admin_I_want_to_turn_an_email_notification_On_Off()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "As an Admin navigate to System >> Domains");
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            _test.Log(Status.Info, "Navigate to option tab");
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isEnablecontentleveleditingforsystememailsDisplay());
            _test.Log(Status.Pass, "Verify Enable content-level editing for system emails option is Display");
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isContentleveleditingforsystememailsisOn());

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63431");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("Somnath1");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            

            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.EmailTable.TurnoffFirstEmail();
            Assert.IsTrue(Driver.comparePartialString("Success The changes were saved.×", driver.getSuccessMessage()));
            _test.Log(Status.Pass, "Successful message matched ");
            TC63433 = true;

        }
        [Test, Order(13)]
        public void tc_63433_As_a_domain_admin_I_want_to_turn_an_email_notification_On_Off()
        {
            Assert.IsTrue(TC63433);
        }
        [Test, Order(14)]
        public void tc_63230_As_an_admin_I_want_to_enable_content_level_editing_for_system_emails_Domain_Setting()
        {
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "As an Admin navigate to System >> Domains");
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            _test.Log(Status.Info, "Navigate to option tab");
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isEnablecontentleveleditingforsystememailsDisplay());
            _test.Log(Status.Pass, "Verify Enable content-level editing for system emails option is Display");
            Contentlevelseting = EditConfigurationOptionsPage.EditConfigurationTab.Contentleveleditingforsystememailsisselected();
            EditConfigurationOptionsPage.EditConfigurationTab.SetContentleveleditingforsystememailsisOn(Contentlevelseting);
            _test.Log(Status.Info, "Set Contnt level emaol editing option to oposite of variable : Contentlevelseting");
            EditConfigurationOptionsPage.EditConfigurationTab.ClickSave();
            Contentlevelseting = EditConfigurationOptionsPage.EditConfigurationTab.Contentleveleditingforsystememailsisselected();
            EditConfigurationOptionsPage.EditConfigurationTab.ClickReturn();
            _test.Log(Status.Info, "Click return");
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            _test.Log(Status.Info, "Navigate to option tab");
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isEnablecontentleveleditingforsystememailsDisplay());
            _test.Log(Status.Pass, "Verify Enable content-level editing for system emails option is Display");
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.Contentleveleditingforsystememailsisselected()==Contentlevelseting);
            _test.Log(Status.Pass, "Verify Enable content-level editing for system emails option setting is no which doesn't mathch with prior one");
            EditConfigurationOptionsPage.EditConfigurationTab.SetContentleveleditingforsystememailsisOn(Contentlevelseting);
            _test.Log(Status.Info, "Set Contnt level emaol editing option to oposite of variable : Contentlevelseting");
            EditConfigurationOptionsPage.EditConfigurationTab.ClickSave();
            TC63231 = true;
        }
        [Test, Order(15)]
        public void tc_63231_As_a_Domain_Admin_I_want_to_enable_content_level_editing_for_system_emails_Domain_Setting()
        {
            Assert.IsTrue(TC63231);
        }
        [Test, Order(16)]
        public void tc_63878_As_a_Siteadmin_I_want_to_add_field_codes_to_email_subject_and_message_when_the_cursor_is_not_placed_in_the_existing_textbox()
        {
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "As an Admin navigate to System >> Email Management >> System Event");
            Assert.IsTrue(SystemEventPage.isResultGriddisplay());
            _test.Log(Status.Pass, "Verify Email table is display");
            SystemEventPage.EmailResultTable.Actions.ClickEdit("FirstResult");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            string Actualsubject = EditEmailPage.getSubjectText();
            EditEmailPage.Subject.CLickSelectFieldCode();
            Assert.IsTrue(EditEmailPage.Subject.isSelectFieldCodeModalOpen());
            _test.Log(Status.Pass, "Verify Select Field Code modal opened");
            string SelectedfieldCode = EditEmailPage.Subject.SelectFieldCodeModal.getFirstfieldcodetext();
            EditEmailPage.Subject.SelectFieldCodeModal.SelectandSaveSubjectFieldCode();
            Assert.IsFalse(EditEmailPage.Subject.isSelectFieldCodeModalOpen());
            Assert.IsTrue(EditEmailPage.isSubjectisUpdatedwithfieldCodeattheend(SelectedfieldCode));
            EditEmailPage.EmailBodyRichText.ClickSelectFieldCode();
            Assert.IsTrue(EditEmailPage.EmailBodyRichText.isSelectFieldCodeModalOpen());
            _test.Log(Status.Pass, "Verify Select Field Code modal opened");
            string SelectedfieldCodeEmailbody = EditEmailPage.EmailBodyRichText.SelectFieldCodeModal.getFirstfieldcodetext();
            EditEmailPage.EmailBodyRichText.SelectFieldCodeModal.SelectandSaveSubjectFieldCode();
            Assert.IsFalse(EditEmailPage.EmailBodyRichText.isSelectFieldCodeModalOpen());
            Assert.IsTrue(EditEmailPage.isEmailBodyisUpdatedwithfieldCodeattheEnd(SelectedfieldCodeEmailbody));
            EditEmailPage.ClickSave();
            EditEmailPage.ClickSystemeventBreadcromb();
            SystemEventPage.EmailResultTable.Actions.ClickEdit("FirstResult");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.isSubjectisUpdatedwithfieldCodeattheend(SelectedfieldCode));
            Assert.IsTrue(EditEmailPage.isEmailBodyisUpdatedwithfieldCodeattheEnd(SelectedfieldCodeEmailbody));
            TC63879 = true;
        }
        [Test, Order(17)]
        public void tc_63879_As_a_Domainadmin_I_want_to_add_field_codes_to_email_subject_and_message_when_the_cursor_is_not_placed_in_the_existing_textbox()
        {
            Assert.IsTrue(TC63879);
        }
        [Test, Order(18)]
        public void tc_63916_As_an_Admin_preview_an_Email_from_Edit_workflow_20_2()
        {
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "As an Admin navigate to System >> Email Management >> System Event");
            Assert.IsTrue(SystemEventPage.isResultGriddisplay());
            _test.Log(Status.Pass, "Verify Email table is display");
            SystemEventPage.EmailResultTable.Actions.ClickEdit("FirstResult");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.isPreviewButtondisplay());
            EditEmailPage.ClickPreviewbutton();
            Assert.IsTrue(EditEmailPage.isPreviewEmailModalOpen());
            Assert.IsTrue(EditEmailPage.PreviewEmailModal.isEmailTiteldisplay());
            EditEmailPage.PreviewEmailModal.ClickClose();
            Assert.IsTrue(EditEmailPage.isPreviewButtondisplay());
            _test.Log(Status.Pass, "Verify Preview Email Modal is Closed");
        }
        [Test, Order(19)]
        public void tc_63918_As_an_Admin_attach_files_to_an_email_from_Edit_workflow_20_2()
        {
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "As an Admin navigate to System >> Email Management >> System Event");
            Assert.IsTrue(SystemEventPage.isResultGriddisplay());
            _test.Log(Status.Pass, "Verify Email table is display");
            SystemEventPage.EmailResultTable.Actions.ClickEdit("FirstResult");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            EditEmailPage.BrowseandUploadfile("Data\\mv_mvet_a03_it_enus.au");
            _test.Log(Status.Info, "Upload an invalid extension file");
            Assert.IsTrue(EditEmailPage.isValidationmessagedidisplay());
            _test.Log(Status.Pass, "Verify Invalid extension file validation message display");
            EditEmailPage.BrowseandUploadfile("Data\\test_image.jpg");
            _test.Log(Status.Info, "Upload a valide extension file");
            Assert.IsTrue(EditEmailPage.isfileisuploaded());
            _test.Log(Status.Pass, "Verify file is uploaded");
            EditEmailPage.DeleteduploaededFile();
            EditEmailPage.ClickSave();

        }
        [Test, Order(20)]
        public void tc_63927_As_an_admin_I_want_to_preview_an_email_for_Classroom_sections()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63927");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");           
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.Action.ClickEdit("FirstRecord");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.isPreviewButtondisplay());
            EditEmailPage.ClickPreviewbutton();
            Assert.IsTrue(EditEmailPage.isPreviewEmailModalOpen());
            Assert.IsTrue(EditEmailPage.PreviewEmailModal.isEmailTiteldisplay());
            EditEmailPage.PreviewEmailModal.ClickClose();
            Assert.IsFalse(EditEmailPage.isPreviewButtondisplay());
            _test.Log(Status.Pass, "Verify Preview Email Modal is Closed");

            EditEmailPage.clickBreadcrumb(classroomcoursetitle + "_TC63927");
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.clickAssignPermission();
            _test.Log(Status.Info, "Click Assign Permission");
            EditPermissionsPage.AssignPermissionTo("somnath course manager");
            TC63929 = true;
        }
        [Test, Order(21)]
        public void tc_63929_As_a_Domain_admin_I_want_to_preview_an_email_for_Classroom_sections()
        {
            Assert.IsTrue(TC63929);
        }
       [Test, Order(22)]
        public void tc_63928_As_a_Course_manager_I_want_to_preview_an_email_for_Classroom_sections()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("srcoursemanager").WithPassword("password").Login();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.Action.ClickEdit("FirstRecord");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.isPreviewButtondisplay());
            EditEmailPage.ClickPreviewbutton();
            Assert.IsTrue(EditEmailPage.isPreviewEmailModalOpen());
            Assert.IsTrue(EditEmailPage.PreviewEmailModal.isEmailTiteldisplay());
            EditEmailPage.PreviewEmailModal.ClickClose();
            Assert.IsFalse(EditEmailPage.isPreviewButtondisplay());
            _test.Log(Status.Pass, "Verify Preview Email Modal is Closed");
        }
        [Test, Order(23)]
        public void tc_63932_As_a_siteadmin_I_want_to_edit_an_email_notification()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.System.DomainsandURLS.Domains();
            _test.Log(Status.Info, "As an Admin navigate to System >> Domains");
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            _test.Log(Status.Info, "Navigate to option tab");
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isEnablecontentleveleditingforsystememailsDisplay());
            _test.Log(Status.Pass, "Verify Enable content-level editing for system emails option is Display");
            Assert.IsTrue(EditConfigurationOptionsPage.EditConfigurationTab.isContentleveleditingforsystememailsisOn());

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC63932");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");

            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.Action.ClickEdit("FirstRecord");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.isPreviewButtondisplay());
            string actualEmailTitle = EditEmailPage.getEmailTitle();
            EditEmailPage.UpdateEmailTitle(actualEmailTitle + "test");
            string Actualsubject = EditEmailPage.getSubjectText();
            EditEmailPage.UpdateSubject(Actualsubject + "test");
            EditEmailPage.ClickSave();
            _test.Log(Status.Info, "Click Save");
            EditEmailPage.clickBreadcrumb("Notifications");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.Action.ClickEdit("FirstRecord");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.getEmailTitle().Equals(actualEmailTitle + "test"));
            Assert.IsTrue(EditEmailPage.getSubjectText().Equals(Actualsubject + "test"));
            _test.Log(Status.Pass, "Verify Changes are retained");
            TC63930 = true;
        }
        [Test, Order(24)]
        public void tc_63930_As_a_domain_admin_I_want_to_edit_an_email_notification()
        {
            Assert.IsTrue(TC63930);
        }
        [Test, Order(25)]
        public void tc_63931_As_a_Course_manager_I_want_to_edit_an_email_notification()
        {
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_Permissions();
            EditPermissionsPage.clickAssignPermission();
            _test.Log(Status.Info, "Click Assign Permission");
            EditPermissionsPage.AssignPermissionTo("somnath course manager");

            CommonSection.Logout();
            LoginPage.LoginAs("srcoursemanager").WithPassword("password").Login();
            CommonSection.SearchCatalog('"' + classroomcoursetitle + "_TC63322" + '"');
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC63322");
            ContentDetailsPage.ClickEditContent_New19_2();
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            Assert.IsTrue(SectionDetailsPage.isNotificationTabDisplay());
            _test.Log(Status.Pass, "Verify Notification tab is display");
            SectionDetailsPage.ClickNotificationTab();
            _test.Log(Status.Info, "Click Notification tab");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.Action.ClickEdit("FirstRecord");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.isPreviewButtondisplay());
            SectionDetailsPage.NotificationTab.Action.ClickEdit("FirstRecord");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.isPreviewButtondisplay());
            string actualEmailTitle = EditEmailPage.getEmailTitle();
            EditEmailPage.UpdateEmailTitle(actualEmailTitle + "test");
            string Actualsubject = EditEmailPage.getSubjectText();
            EditEmailPage.UpdateSubject(Actualsubject + "test");
            EditEmailPage.ClickSave();
            _test.Log(Status.Info, "Click Save");
            EditEmailPage.clickBreadcrumb("Notifications");
            Assert.IsTrue(SectionDetailsPage.NotificationTab.isEmailTabledisplay());
            _test.Log(Status.Pass, "Verify Email table display in Notification tab");
            SectionDetailsPage.NotificationTab.Action.ClickEdit("FirstRecord");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.getEmailTitle().Equals(actualEmailTitle + "test"));
            Assert.IsTrue(EditEmailPage.getSubjectText().Equals(Actualsubject + "test"));
            _test.Log(Status.Pass, "Verify Changes are retained");
        }

        [Test, Order(16)]
        public void tc_63648_As_a_Siteadmin_I_want_to_save_an_email_from_the_Edit_workflow_20_2()
        {
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "As an Admin navigate to System >> Email Management >> System Event");
            SystemEventPage.EmailResultTable.Actions.ClickEdit("FirstResult");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            string actulTitle = EditEmailPage.getEmailTitle();            
            EditEmailPage.UpdateEmailTitle(actulTitle + "test");
            string Actualsubject = EditEmailPage.getSubjectText();
            EditEmailPage.UpdateSubject(Actualsubject + "test");            
            EditEmailPage.ClickSave();
            _test.Log(Status.Info, "Click Save");

            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "As an Admin navigate to System >> Email Management >> System Event");
            SystemEventPage.EmailResultTable.Actions.ClickEdit("FirstResult");
            Assert.IsTrue(Driver.checkTitle("Edit Email"));
            _test.Log(Status.Pass, "Verify Edit Email page display");
            Assert.IsTrue(EditEmailPage.getEmailTitle().Equals(actulTitle + "test"));
            Assert.IsTrue(EditEmailPage.getSubjectText().Equals(Actualsubject + "test"));
            _test.Log(Status.Pass, "Verify Changes are retained");
            TC63647 = true;
        }
        [Test, Order(17)]
        public void tc_63647_As_a_Domain_Admin_I_want_to_save_an_email_from_the_Edit_workflow_20_2()
        {
            Assert.IsTrue(TC63647);
        }

    }
}



