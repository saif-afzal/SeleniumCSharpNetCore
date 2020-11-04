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
    public class P1_Notifications_EventManagementTest : TestBase
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
        string SenderName = Meridian_Common.globalnum;
        bool TC61375;
        bool TC61358;
        bool TC61362;

        public P1_Notifications_EventManagementTest(string browser)
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
        public void tc_61249_As_an_admin_I_want_to_view_list_of_system_events()
        {
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            Assert.IsTrue(SystemEventPage.isInstructionTextdisplay());
            _test.Log(Status.Pass, "Verify page opened with instructional text");
            Assert.IsTrue(SystemEventPage.EventTable.isCulumnPresent("Email Title","Trigger","Status","Action","Info"));
            _test.Log(Status.Pass, "Verify Table harareds are Email Title,Trigger,Status,Action,Info");
            Assert.IsTrue(SystemEventPage.ispagehasPagination());
            _test.Log(Status.Pass, "Verify page has pagination");
            SystemEventPage.EventTable.Trigger.ClickShowmore();
            _test.Log(Status.Info, "Click Showmoew link of trigger");
            Assert.IsTrue(SystemEventPage.EventTable.Trigger.istriggerdiscriptiondisplay());
            _test.Log(Status.Pass, "Verify is Trigger discription display");
        }
        [Test, Order(02)]
        public void tc_61250_As_a_Domain_Administrator_I_want_to_view_list_of_system_events()
        {
            //CommonSection.Administer.System.EmailManagement.SystemEvents();
            //_test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            Assert.IsTrue(SystemEventPage.isInstructionTextdisplay());
            _test.Log(Status.Pass, "Verify page opened with instructional text");
            SystemEventPage.AllTriggersDrowdown.select("360 Evaluations");
            Assert.IsTrue(SystemEventPage.EventTable.isEmailOpenswith("360 Evaluations"));
            _test.Log(Status.Pass, "Verify email associated with select options are open");
        }
        [Test, Order(03)]
        public void tc_61285_Search_Email_20_1()
        {
            CommonSection.Manage.Training();
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            Assert.IsTrue(SystemEventPage.isSearchTextboxisDisplay());
            _test.Log(Status.Pass, "Verify Search option is display");
            SystemEventPage.Search("Access");
            Assert.IsTrue(SystemEventPage.EventTable.isEmailOpenswith("Access"));
            _test.Log(Status.Pass, "Verify email associated with search are open");
        }
        [Test, Order(04)]
        public void tc_61251_As_an_admin_I_want_to_change_Activity_or_set_Active_dates_for_an_individual_email()
        {
            //CommonSection.Administer.System.EmailManagement.SystemEvents();
            //_test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            SystemEventPage.Search("");
            string firsteventName = SystemEventPage.EventTable.getfirsteventname();
            SystemEventPage.EventTable.ClickActiveLink("FirstEvent");
            Assert.IsTrue(SystemEventPage.EventTable.StatusActionMenus("Active", "Inactive", "Set Active Dates"));
            SystemEventPage.EventTable.SelectStatusAction("Inactive");
            Assert.IsTrue(SystemEventPage.EventTable.getfirsteventname() != firsteventName);
            _test.Log(Status.Info, "Verify first event is changed as first one is Inactive ");
            SystemEventPage.Search(firsteventName);
            SystemEventPage.EventTable.ClickActiveLink("FirstEvent");
            SystemEventPage.EventTable.SelectStatusAction("Set Active Dates");
        }
        [Test, Order(5)]
        public void tc_61360_As_a_domain_admin_I_want_to_make_a_copy_of_System_email_20_1()
        {
            //CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            SystemEventPage.Search("");
            string firsteventName = SystemEventPage.EventTable.getfirsteventname();
            SystemEventPage.EventTable.Action.ClickCopy("firstrecird");
            Assert.IsTrue(SystemEventPage.EventTable.Action.isCopyModaldisplay());
            Assert.IsTrue(SystemEventPage.EventTable.Action.CopyModal.isNamedisplay());
            SystemEventPage.EventTable.Action.CopyModal.Copywithnewname("Copy of_" + firsteventName);
           
            //StringAssert.AreEqualIgnoringCase("The email was copied and is displayed in the list below.\r\nx", Driver.getSuccessMessage(), "Error message is different");
            SystemEventPage.Search("Copy of_" + firsteventName);
            Assert.IsTrue(SystemEventPage.EventTable.getfirsteventname() == "Copy of_" + firsteventName);
            Assert.IsTrue(SystemEventPage.EventTable.isStatus("Inactive"));
            SystemEventPage.EventTable.Action.delete("Copy of_" + firsteventName);
            Assert.IsTrue(SystemEventPage.EventTable.isNorecordfoundDisplay());
            _test.Log(Status.Info, "Verify record is deleted");
            TC61375 = true;
            TC61358 = true;
        }
        [Test, Order(6)]
        public void tc_61375_Admin_deletes_a_custom_email_20_1()
        {
            Assert.IsTrue(TC61375);
        }
        [Test, Order(7)]
        public void tc_61358_As_an_admin_I_want_to_make_a_copy_of_System_email_20_1()
        {
            Assert.IsTrue(TC61358);
        }
       
        [Test,Order(7)]
        public void tc_61366_Filter_to_show_only_Active_emails_by_default_and_and_then_include_Inactive_20_1()
        {
            //CommonSection.Administer.System.EmailManagement.SystemEvents();            
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            SystemEventPage.Search("");
            int TotalEventCount = SystemEventPage.EventTable.getTotalCount();
            SystemEventPage.clickInactivecheckbox();
            Assert.IsTrue(SystemEventPage.EventTable.getTotalCount() > TotalEventCount);
        }
        [Test, Order(8)]
        public void tc_61361_As_an_admin_I_want_to_edit_status_of_multiple_emails_20_1()
        {
            CommonSection.Manage.Training();
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            string firsteventName = SystemEventPage.EventTable.getfirsteventname();
            SystemEventPage.EventTable.SelectFirstRecord();
            SystemEventPage.ActionDropdown.ActionSecect("Inactive");
            SystemEventPage.Search(firsteventName);
            Assert.IsTrue(SystemEventPage.EventTable.isStatus("Inactive"));
            TC61362 = true;

        }
        [Test, Order(9)]
        public void tc_61362_As_a_domain_admin_I_want_to_edit_status_of_multiple_emails_20_1()
        {
            Assert.IsTrue(TC61362);
        }
        [Test, Order(10)]
        public void tc_61291_Edit_an_Existing_Email_20_1()
        {
            CommonSection.Manage.Training();
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            SystemEventPage.EventTable.Action.ClickEdit();
            Assert.IsTrue(Driver.Instance.Title.Equals("Edit Email"));
            EditEmailPage.ClickSave();
            EditEmailPage.ClickReturn();
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));

        }
        [Test, Order(11)]
        public void tc_61347_Admin_sends_a_test_email_20_1()
        {
            CommonSection.Manage.Training();
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            SystemEventPage.EventTable.Action.ClickSendTestEmail();
            Assert.IsTrue(SystemEventPage.EventTable.Action.isSendTestEmailModaldisplay());
            SystemEventPage.EventTable.Action.SenTestEmailModal.FillEmail("srout@meridianks.net");
            SystemEventPage.EventTable.Action.SenTestEmailModal.ClickCancel();
            SystemEventPage.EventTable.Action.ClickSendTestEmail();
            Assert.IsTrue(SystemEventPage.EventTable.Action.isSendTestEmailModaldisplay());
            SystemEventPage.EventTable.Action.SenTestEmailModal.FillEmail("srout@meridianks.net");
            SystemEventPage.EventTable.Action.SenTestEmailModal.ClickSendEmail();
            StringAssert.AreEqualIgnoringCase("Success\r\nThe test email was sent.\r\n×", Driver.getSuccessMessage());


        }
        [Test, Order(12)]
        public void tc_61346_Admin_views_more_information_about_an_email_20_1()
        {
            CommonSection.Manage.Training();
            CommonSection.Administer.System.EmailManagement.SystemEvents();
            _test.Log(Status.Info, "Goto Administer > System >EmailManagement>System Events Page");
            Assert.IsTrue(Driver.Instance.Title.Equals("System Events"));
            string firsteventName = SystemEventPage.EventTable.getfirsteventname();
            SystemEventPage.EventTable.ClickInfoIconFistrecord();
            Assert.IsTrue(SystemEventPage.Title == "Summary");
            Assert.IsTrue(SystemEventPage.summarywin.isemailTitledisplay(firsteventName));
            SystemEventPage.EventTable.closeSummaywindow();


        }
        [Test, Order(13)]
        public void tc_62346_Change_Sender_Email_Address_and_Sender_Email_Name()
        {
            CommonSection.Administer.System.EmailManagement.SystemEmailOptions();
            Assert.IsTrue(SystemEmailOptionsPage.isSenderNamedisplay());
            _test.Log(Status.Pass, "Verify Sender Name is display");
            SystemEmailOptionsPage.EnterSenderName(SenderName);
            SystemEmailOptionsPage.ClickSave();
            Assert.IsTrue(SystemEmailOptionsPage.getSenderName() == SenderName);

        }

    }
}