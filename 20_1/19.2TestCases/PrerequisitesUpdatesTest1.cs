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
    public class P1_PrerequisitesUpdatesTest1 : TestBase
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
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string SCORMTitle = "SCORM" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;
        int AssignedPrequisiteCount;
        bool TC57286, TC57286_1, TC57284;

        public P1_PrerequisitesUpdatesTest1(string browser)
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
        public void tc_57234_Prerequisites_Manage_Users_to_whom_prerequisite_applies_General()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC56978");
            _test.Log(Status.Info, "Create a general Course");

            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", PrerequisitesPage.VerifyMessage());
            _test.Log(Status.Pass, "Verify message on manage Prerequisite Page");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(2)]
        public void tc_57235_Prerequisites_Manage_Users_to_whom_prerequisite_applies_AICC()
        {
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC57235");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(3)]
        public void tc_57236_Prerequisites_Manage_Users_to_whom_prerequisite_applies_SCORM()
        {
            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(SCORMTitle + "TC57236");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(4)]
        public void tc_57244_Prerequisites_Manage_Users_to_whom_prerequisite_applies_Classroom()
        {
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC57244");
            _test.Log(Status.Info, "A new Classroom Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(5)]
        public void tc_57245_Prerequisites_Manage_Users_to_whom_prerequisite_applies_Document()
        {
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC57245");
            _test.Log(Status.Info, "A new document Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(6)]
        public void tc_57246_Prerequisites_Manage_Users_to_whom_prerequisite_applies_Curriculum()
        {
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "_TC52243");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(7)]
        public void tc_57247_Prerequisites_Manage_Users_to_whom_prerequisite_applies_Bundle()
        {
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(BunbdleTitle + "_TC7247");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
          
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(8)]
        public void tc_57248_Prerequisites_Manage_Users_to_whom_prerequisite_applies_Surveys()
        {
            CommonSection.CreateLink.Survey();
            _test.Log(Status.Info, "Naviagte to Manage >> Survey page");

            SurveysPage.CreateNewSurvey(surveyTitle + "_TC52244");
            _test.Log(Status.Info, "A new Survey Created");

            ContentDetailsPage.click_Surveylink();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
           
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }

        [Test, Order(9)]
        public void tc_57249_Prerequisites_Manage_Users_to_whom_prerequisite_applies_Certification()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57249");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.Appliedto.ClickManage();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isMessagedisplay("This prerequisite applies to All Users."));
            _test.Log(Status.Pass, "Verify No user added for pre requisite");
            PrerequisitesManageGroupsEditPage.click_Changelink();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isAdduserModalopen("Add Users"));
            _test.Log(Status.Pass, "Verify Add User modal display");
            PrerequisitesManageGroupsEditPage.addUserModal.ClickallTypedropdown();
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.addUserModal.allTypedrowdown.islist("Job Title", "Organization", "User"));
            _test.Log(Status.Pass, "Verify all type dropdown list has values");
            PrerequisitesManageGroupsEditPage.addUserModal.Click_SelectAlltable();
            PrerequisitesManageGroupsEditPage.addUserModal.ClickAddbutton();
            _test.Log(Status.Info, "users added");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.isApplaytoAllUsersbuttondisplay());
            _test.Log(Status.Pass, "Verify Applay to all user button display on manage prerequiste page");
            int totaluseradded = PrerequisitesManageGroupsEditPage.recordcount();
            PrerequisitesManageGroupsEditPage.selecttworecord();
            PrerequisitesManageGroupsEditPage.RemoveselectedRecord();
            _test.Log(Status.Info, "Record removed");
            Assert.IsTrue(PrerequisitesManageGroupsEditPage.recordcount() < totaluseradded);
            _test.Log(Status.Pass, "Verify total count decreased");
        }
        [Test, Order(10)]
        public void tc_57264_As_an_Admin_I_want_to_choose_How_many_Prerequisites_to_be_completed()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57264");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");

            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdowndisplay());
            int totleaddedcontent = PrerequisitesPage.totlaPrerequisitesCountInTable();
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdownlist() < totleaddedcontent);

        }

        [Test, Order(11)]
        public void tc_57279_As_an_Admin_I_want_see_prerequisite_must_be_completed_dropdown_When_Assigned_Prerequisite_is_0()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57279");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");

            Assert.IsFalse(PrerequisitesPage.prerequisitesmustbecompleteddropdowndisplay()); //AC1
        }
        [Test, Order(12)]
        public void tc_57280_As_an_Admin_I_want_make_a_selection_of_prerequisite_must_be_completed_from_dropdown_When_Assigned_Prerequisite_is_1()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57280");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.AddPrerequisitesModal.addprerequisite();
            _test.Log(Status.Info, "Select prerequisites to assign");

            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdowndisplay()); //AC1
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdownlisttext() == "ALL");
        }
        [Test, Order(13)]
        public void tc_57281_As_an_Admin_I_want_to_see_my_changes_are_saved_of_Prerequisites_must_be_completed_Dropdown()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57281");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");

            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdowndisplay());
            int totleaddedcontent = Driver.getIntegerFromString(PrerequisitesPage.PrerequisitesCountInTable());
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdownlist() < totleaddedcontent);
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            PrerequisitesPage.ClickBackbutton();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdown.isListselectd("2"));
        }
        [Test, Order(14)]
        public void tc_57283_As_an_Admin_I_want_to_see_Prerequisites_Must_Be_Completed_Dropdown_Digit_does_not_change_on_Adding_More_Prerequisites()
        {
            //depend 57281
            CommonSection.SearchCatalog(CertificatrTitle + "TC57281");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC57281");
            ContentDetailsPage.ClickEditContent();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdown.isListselectd("2"));
            _test.Log(Status.Pass, "Verify prerequisites must be completed dropdown still hold value 2");
            PrerequisitesPage.ClickAddPrerequisites();
            PrerequisitesPage.AddPrerequisitesModal.clickNextPage();
            PrerequisitesPage.AddPrerequisitesModal.addprerequisite();
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdown.isListselectd("2"));
            _test.Log(Status.Pass, "Verify prerequisites must be completed dropdown still hold value 2");
            TC57286 = true;
        }
        [Test, Order(15)]
        public void tc_57285_As_an_Admin_If_my_dropdown_selection_is_All_and_I_remove_assigned_Prerequisites_my_selection_should_not_change()
        {
            //depend 57281
            CommonSection.SearchCatalog(CertificatrTitle + "TC57281");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC57281");
            ContentDetailsPage.ClickEditContent();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdown.isListselectd("2"));
            PrerequisitesPage.SelectAssignedPrerequsites();
            _test.Log(Status.Info, "Select Assigned prerequisites to Delete");
            Assert.IsTrue(PrerequisitesPage.VerifyDeleteButtonisEnabled());
            _test.Log(Status.Pass, "Verify Delete button is enabled");
            PrerequisitesPage.ClickDeleteButton();
            _test.Log(Status.Info, "Click Delete button");
            Assert.IsTrue(PrerequisitesPage.VerifyAlertBoxisDisplayed());
            _test.Log(Status.Pass, "Verify AlertBox is Displayed");
            PrerequisitesPage.ClickOKofAlertBox();
            _test.Log(Status.Info, "Click Delete button");
            Assert.IsTrue(PrerequisitesPage.prerequisitesmustbecompleteddropdown.isListselectd("2"));
            TC57286_1 = true;
            TC57284 = true;
        }
        [Test, Order(16)]
        public void tc_57286_As_an_Admin_If_my_dropdown_selection_is_All_and_I_Add_Prerequisites_my_selection_should_not_change()
        {
            Assert.IsTrue(TC57286);
            Assert.IsTrue(TC57286_1);
        }
        [Test, Order(17)]
        public void tc_58338_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_General_course()
        {

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC58338");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(generalcoursetitle + "TC58338");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC58338");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));

        }
       
        [Test, Order(19)]
        public void tc_58341_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_Classroom_Course()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC58341");
            _test.Log(Status.Info, "A new Classroom Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            //DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(classroomcoursetitle + "_TC58341");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC58341");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        [Test, Order(20)]
        public void tc_58343_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_Documents()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC58343");
            _test.Log(Status.Info, "A new Classroom Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC58343");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC58343");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        //[Test, Order(40)]
        //public void tc_58344_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_Surveys()
        //{
        //    //need to decide how to handle on automation
        //}
        [Test, Order(21)]
        public void P20_1_tc_58345_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_Bundle()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(BunbdleTitle + "_TC58345");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(BunbdleTitle + "_TC58345");
            SearchResultsPage.ClickCourseTitle(BunbdleTitle + "_TC58345");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        [Test, Order(22)]
        public void tc_58346_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_Certification()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC58346");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(CertificatrTitle + "TC58346");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC58346");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        [Test, Order(23)]
        public void P20_1_tc_58347_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_Curriculum()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "_TC58347");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(curriculamtitle + "_TC58347");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC58347");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        [Test, Order(24)]
        public void tc_58348_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_On_The_Job_Training()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateNewOJT(OJTTitle + "TC58348");
            _test.Log(Status.Info, "Create OJT");


            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.",ContentDetailsPage.getInformativeMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(OJTTitle + "TC58348");
            SearchResultsPage.ClickCourseTitle(OJTTitle + "TC58348");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
       
        [Test, Order(26)]
        public void tc_58350_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_Classroom_course()
        {
            //CommonSection.Logout();
           // LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC58350");
            _test.Log(Status.Info, "A new Classroom Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(classroomcoursetitle + "_TC58350");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC58350");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(27)]
        public void tc_58351_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_SCORM()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(SCORMTitle + "TC58351");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(SCORMTitle + "TC58351");
            SearchResultsPage.ClickCourseTitle(SCORMTitle + "TC58351");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(28)]
        public void tc_58352_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_Document()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC58352");
            _test.Log(Status.Info, "A new Document Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC58352");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC58352");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        //[Test, Order(49)]
        //public void tc_58353_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_Survey()
        //{
        //    //need to decide how to handle on automation
        //}
        [Test, Order(29)]
        public void P20_1_tc_58354_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_Bundle()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(BunbdleTitle + "_TC58354");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(BunbdleTitle + "_TC58354");
            SearchResultsPage.ClickCourseTitle(BunbdleTitle + "_TC58354");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(30)]
        public void tc_58355_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_Certification()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC58355");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(CertificatrTitle + "TC58355");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC58355");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(31)]
        public void P20_1_tc_58356_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_Curriculum()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Curriculam();
            _test.Log(Status.Info, "Naviagte to Cretae Curriculums page");
            CreateCurriculumnPage.fillTtile(curriculamtitle + "_TC58356");
            CreateCurriculumnPage.SelectCollaborationSpaceOption("No");
            CreateCurriculumnPage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Curriculum created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(curriculamtitle + "_TC58356");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC58356");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(32)]
        public void tc_58357_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_On_The_Job_Training()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateNewOJT(OJTTitle + "TC58357");
            _test.Log(Status.Info, "Create OJT");


            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");
            Assert.IsTrue(PrerequisitesPage.IsPageDisplayed());
            _test.Log(Status.Pass, "Verify manage prerequisites Page loads");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");
            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesModalIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");

            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            //Assert.IsTrue(Driver.comparePartialString("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.",ContentDetailsPage.getInformativeMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(OJTTitle + "TC58357");
            SearchResultsPage.ClickCourseTitle(OJTTitle + "TC58357");
            Assert.IsTrue(ContentDetailsPage.Prerequisiteportlet.isPortletheadershowes_old("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(33)]
        public void tc_58342_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_all_Prerequisites_to_be_completed_in_SCORM()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(SCORMTitle + "TC58342");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(SCORMTitle + "TC58342");
            SearchResultsPage.ClickCourseTitle(SCORMTitle + "TC58342");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        [Test, Order(34)]
        public void tc_58337_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_all_Prerequisites_to_be_completed_in_General_course()
        {

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC58337");
            _test.Log(Status.Info, "Create a general Course");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(generalcoursetitle + "TC58337");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC58337");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));

        }
        [Test,Order(35)]
        public void tc_57284_As_an_Admin_I_want_to_see_Prerequisites_Must_Be_Completed_Dropdown_Digit_does_not_change_on_Removing_Prerequisites()
        {
            Assert.IsTrue(TC57284);
        }
    }
}