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
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1RegressionTests4 : TestBase
    {
        string browserstr = string.Empty;
        public P1RegressionTests4(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        bool res1 = false;

        string LevelName = "Level" + Meridian_Common.globalnum;
        string OrganizationTitle = "Organization" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        bool ArchivedScale = false;
        string documenttitle = "Doc" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string testtitle = "Test" + Meridian_Common.globalnum;
        string title = "Google";
        static string today = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
        string markAsComplete = $"This item was marked as complete on "+today+".";
        string completed = "The item was marked complete.";
        string curriculamblocktitle = "curriculam1";
        public bool chktest = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

        }
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
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
                    if (driver.Title == "Object reference not set to an instance of an object.")
                    {
                        driver.Navigate_to_TrainingHome();
                        Driver.focusParentWindow();
                        CommonSection.Avatar.Logout();
                        LoginPage.LoginClick();
                        LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
                    }
                    //if (!Meridian_Common.isadminlogin)
                    //{
                    //    CommonSection.Logout();
                    //    LoginPage.LoginAs("").WithPassword("").Login();
                    //}


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

         [Test, Order(1), Category("P1")]
        public void a01_Test_when_User_add_a_new_proficiency_scale_31801()

        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickTab("Proficiency Scales");
            _test.Log(Status.Info, "Open Proficiency Scales tab");
            CareersPage.ClickCreateNewProficencyScale();
            _test.Log(Status.Info, "Click Create new Preficiency");
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message");
            CareersPage.ClickTitleTextBox("Regression Scale");
            _test.Log(Status.Info, "Click On Scale Title");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            _test.Log(Status.Info, "Enter Label text");
            CareersPage.ClickCreatebutton();
            _test.Log(Status.Info, "Click Create button");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.VerifySuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message");
            Assert.IsTrue(CareersPage.ProficeancyItemCount());
            _test.Log(Status.Pass, "Verify Item Count");
        }

        [Test, Order(2), Category("P1")]
        public void a02_User_adds_supplemental_training_to_a_new_competency_31561()

        {  // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training 
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Create General Course Page ");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC31561", "Automation Test");
            _test.Log(Status.Info, "Fill Course title and Description and Click on Create");

            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle + "TC31561");
            _test.Log(Status.Info, "Competency Title filled");
            //CreateCompetencyPage.SaveCompetencyName();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));

            // CareersPage.CompetencyTab.ClickCreateCompetency();
            //CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            //CreateCompetencyPage.SaveCompetencyName();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //StringAssert.AreEqualIgnoringCase("The Competency was created", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.AssociatedContentTab_click();
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.SupplementalTab_Click();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            Assert.AreEqual("There is no supplemental content.", ManageCompetencyPage.CompetencySupplementalTabText(), "Error message is different");
            _test.Log(Status.Pass, "Verify supplemental tab doesnot contain any Content");
            ManageCompetencyPage.AssociateContent_Click();
            _test.Log(Status.Info, "Click on Associated Content Button present inside frame");
            ManageCompetencyPage.SearchTextFrame(generalcoursetitle + "TC31561");
            _test.Log(Status.Info, "Search" + generalcoursetitle + "TC31561");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            _test.Log(Status.Info, "Select course and Click Add");
            //Assert.AreEqual("The selected items were added.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("1"));//Added record should appear that we created as pre req
            _test.Log(Status.Pass, "Verify Content added to supplemental tab");
        }
        [Test, Order(3), Category("P1")]  //depend on 31458
        public void a03_User_adds_supplemental_training_to_an_existing_competency_31562()
        {
            // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC31561");
            _test.Log(Status.Info, "Search Conpetency");
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle + "TC31561");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            ManageCompetencyPage.AssociatedContentTab_click();
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.SupplementalTab_Click();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            ManageCompetencyPage.AssociateContent_Click();
            _test.Log(Status.Info, "Click on Associated Content Button present inside frame");
            ManageCompetencyPage.SearchTextFrame(generalcoursetitle + "TC31561");
            _test.Log(Status.Info, "Search" + generalcoursetitle + "TC31561");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            _test.Log(Status.Info, "Select course and Click Add");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("1"));//Added record should appear that we created as pre req
            _test.Log(Status.Pass, "Verify Content added to supplemental tab");
            // Assert.AreEqual("Success", ManageCompetencyPage.GetSuccessMessage());
            //Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("dv_test"));//Added record should appear that we created as pre req
        }
        [Test, Order(4), Category("P1")]
        public void a04_Switch_Supplemental_Content_to_Mandatory_in_Competency_32214() //dependent on the records already exists in Supplemental tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Search CompetencyTitle1803432643");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            ManageCompetencyPage.AssociatedContentTab_click();//clicking on tab
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.AssociatedContentTab.ClickSupplementalTab();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            // ManageCompetencyPage.AssociateContent_Click();
            // ManageCompetencyPage.SearchTextFrame("Document that created as Pre req");
            // ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            // Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount); //Verify record display
            _test.Log(Status.Pass, "Verify Content is Present");
            ManageCompetencyPage.SelectSupplementalRecords.ClickMakeMandatory();
            _test.Log(Status.Info, "Mark as Mandatory from one of the record");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            //Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount); //verify record moved from supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.SupplementalTab.CheckRecord);//Check Record is moved from Supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved to Mandatory tab
            //Assert.Null(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is decreased.
            ManageCompetencyPage.AssociatedContentTab.ClickMandatoryTab();
            _test.Log(Status.Info, "Click on Mandatory Tab");
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is increased.
            _test.Log(Status.Pass, "Verify Content is Present");

        }
        [Test, Order(5), Category("P1")]
        public void a05_Switch_Mandatory_Content_to_Supplemental_in_Competency_31881() //dependent on the records already exists in Mandatory tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Search CompetencyTitle1803432643");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle1803432643");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            ManageCompetencyPage.AssociatedContentTab_click();//clicking on tab
            _test.Log(Status.Info, "Clicking on Associated Content Tab");
            ManageCompetencyPage.AssociatedContentTab.ClickMandatoryTab();
            _test.Log(Status.Info, "Click on Mandatory Tab");
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);
            _test.Log(Status.Pass, "Verify Content is Present");
            ManageCompetencyPage.SelectMandatoryRecords.ClickMakeSupplemental();
            _test.Log(Status.Info, "Mark as Supplemental from one of the record");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful message");
            //Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);
            ManageCompetencyPage.AssociatedContentTab.ClickSupplementalTab();
            _test.Log(Status.Info, "Click on Supplemental Tab");
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);
            _test.Log(Status.Pass, "Verify Content is Present");
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Check Record is moved to Supplemental tab
            //Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved from Mandatory tab
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is increased.
            // Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is decreased.  
        }
        [Test, Order(6), Category("P1")]
        public void a06_View_Proficiency_Scale_Details_from_list_of_competencies_32106()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle0705274827");
            _test.Log(Status.Info, "Search CompetencyTitle0705274827");
            Assert.IsTrue(CareersPage.CheckProficiencyScaleColumn_ClickView());
            _test.Log(Status.Pass, "Verify Profeciency Column is display with View link");
            CareersPage.CompetencyTab.ProficiencyScaleColumn_ClickView();
            _test.Log(Status.Info, "Click on View link");
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Modal with Labels is displayed
            _test.Log(Status.Pass, "Verify Profeciency Labels are display on Popup");
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed
            _test.Log(Status.Pass, "Verify Profeciency Labels Numbers are display on Popup");
            CareersPage.CompetencyTab.ProficiencyScaleViewModal_CloseClick();
            _test.Log(Status.Info, "Close the Popup");
            Assert.IsTrue(CareersPage.ProficeancyViewPopupClosed());
            _test.Log(Status.Pass, "Verify Popup is closed");


        }

        [Test, Order(7), Category("P1")]
        public void a07_View_Proficiency_Scale_Details_from_Proficiency_Scale_Page_32107()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickTab("Proficiency Scales");
            _test.Log(Status.Info, "Open Proficiency Scales Tab");
            // CareersPage.ClickProficiencyScalesTab();
            CareersPage.ProficiencyScalesTab_ClickProficiencyScaleTitle();
            _test.Log(Status.Info, "Click on Proficiency Scale title");
            Assert.IsTrue(CareersPage.RatingScaleModal_NumbersandLabels_CheckRecord);
            _test.Log(Status.Pass, "Verify Detail Proficiency display");
            // Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord);
            CareersPage.ProficiencyScaleTab.ProficiencyScaleViewModal_CloseClick();
            _test.Log(Status.Info, "Click the popup");
        }

        [Test, Order(8), Category("P1")]
        public void a08_View_Proficiency_Scale_Details_from_Assigned_Groups_32109()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency("CompetencyTitle0705274827");
            _test.Log(Status.Info, "Search CompetencyTitle0705274827");
            CareersPage.CompetenciesTab.ClickCompetencyTitle("CompetencyTitle0705274827");
            _test.Log(Status.Info, "Click on Searched Compentency Title");
            //CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignedGroupsTab();
            _test.Log(Status.Info, "Clicking on Assign Group Tab");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickViewScale);
            _test.Log(Status.Pass, "Verify Optional Rating drodown is Present");
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_clickViewScale();
            _test.Log(Status.Info, "Clicking Optional Rating view Scale link");
            //Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickViewScale);
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Modal with Numbers is displyed
            _test.Log(Status.Pass, "Verify Scale Numbers are display");
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed
            _test.Log(Status.Pass, "Verify Scale Lables are display");
            CareersPage.CompetencyTab.ProficiencyScaleViewModal_CloseClick();
            _test.Log(Status.Info, "Close Popup");
        }
        [Test, Order(9), Category("P1")]
        public void a09_Test_Searching_for_Competency_by_Name_Keyword_Description_31474()

        {
            CareersPage.CreateCompetency(CompetencyTitle+"TC31474");
           _test.Log(Status.Pass, "Create new Competency successfully created");
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            _test.Log(Status.Info, "Clicked on Competency Details tab");
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("Description_Regression_Competency1");
            // ManageCompetencyPage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "AddDescription added to Competency successfully created");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("Keyword_Regression_Competency1");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "AddKeywords added to Competency successfully created");
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Reopen Carres page");
            //CareersPage.CommonTab.ClickCreateCompetency();
            StringAssert.AreEqualIgnoringCase(CompetencyTitle+ "TC31474", CareersPage.SearchByKeyword("Keyword_Regression_Competency1", CompetencyTitle+ "TC31474")); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies with Keyword");
            StringAssert.AreEqualIgnoringCase(CompetencyTitle + "TC31474", CareersPage.SearchByDescription("Description_Regression_Competency1", CompetencyTitle + "TC31474")); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies by Description");
            StringAssert.AreEqualIgnoringCase(CompetencyTitle + "TC31474", CareersPage.SearchByCompetencyTitle(CompetencyTitle + "TC31474")); //This will return a string which will contain competency title
            _test.Log(Status.Pass, "Verified searched result after searching competencies by CompetencyTitle");
            CareersPage.DeleteCompetency(CompetencyTitle + "TC31474");
        }

        [Test, Order(10), Category("P1")]
        public void a10_Test_Creation_of_Job_Title_from_Professional_Development_31482()

        {
            Assert.True(true);
            //similar to test case id 22211.
        }
        [Test, Order(11), Category("P1")]
        //Pre-req - Learner has atleast one competency assigned to them they have not completed and one completed
        public void a11_Filter_competencies_by_Complete_Incomplete_Status_32130()
        {
            CommonSection.Logout();

            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner");
            CommonSection.Learn.CareerDevelopment();
            _test.Log(Status.Info, "Open Career Development Page");
            Assert.IsTrue(CareersPage.ListofCompetencies.InProgressStatus);
            _test.Log(Status.Pass, "Progress bar display for competency");
            CareersPage.SelectCompleteIcon();
            _test.Log(Status.Info, "Select Complete Icon");
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_CompletedStatus);
            _test.Log(Status.Pass, "verify records");
            CareersPage.SelectInProgressIcon();
            _test.Log(Status.Info, "Select In Progress Icon");
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_InProgressStatus);
            _test.Log(Status.Pass, "Verify records");

            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }

        [Test, Order(12), Category("P1")]
        public void a12_Add_AllTypes_to_Competency_32154()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CareersPage.CreateJobTitle(JobTitle + "TC32154");
            _test.Log(Status.Info, "Login with Admin suer");
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.ClickCreateCompetency(); //cllick on record new competency required here
            _test.Log(Status.Info, "Click on Create Competency Button");
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Competency Title filled");
            //CreateCompetencyPage.SaveCompetencyName();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageCompetencyPage.ClickAssignGroupsTab();//clicking on tab
            _test.Log(Status.Info, "Clicking on Assign Group Tab");
            //ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();//not required
            #region Adding JobTitle to Competency
            AssignGroupPage.SelectJobTitleFilter();            //select user group filter
            _test.Log(Status.Pass, "Select Job Title from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext(JobTitle + "TC32154");//search Job title
            _test.Log(Status.Info, "Enter Job Title name into search text Box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            //Assert.IsTrue(ManageCompetencyPage.NameColumn("usergroup_1102520752")); //checked the user group displaying in Assigned groups
            #endregion
            #region Adding Organization to Competency
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();//clicking on tab
            _test.Log(Status.Info, "Clicking on Assign Group button outside Frame");
            AssignGroupPage.SelectOrganizationFilter();
            _test.Log(Status.Pass, "Select Organization from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            _test.Log(Status.Info, "Enter Organization name into search text box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            //Assert.IsTrue(ManageCompetencyPage.NameColumn("Sample Organization 1 "));
            #endregion
            #region Adding userGroup to competency
            ManageCompetencyPage.ClickAssignGroupsTabWhenrecordexist();
            _test.Log(Status.Info, "Clicking on Assign Group button outside Frame");
            AssignGroupPage.SelectUserGroupFilter();//select user group filter
            _test.Log(Status.Pass, "Select User Group from DropDown In Assign Group Modal");
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("usergroup_1102520752");//search user group
            _test.Log(Status.Info, "Enter User Group name into search text box");
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            _test.Log(Status.Info, "Click Search Icon In Assign Group Modal");
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            _test.Log(Status.Info, "Select Search result In Assign Group Modal");
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            _test.Log(Status.Info, "Click Assign Button in Assign Group Modal");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            // Assert.IsTrue(ManageCompetencyPage.NameColumn("usergroup_1102520752"));
            #endregion
            //#region Adding all types using Select ALL
            //ManageCompetencyPage.ClickAssignGroupsTab();
            //AssignGroupPage.ClickSelectAllinPage1();
            //AssignGroupPage.ClickAssignButton();
            //Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            //#endregion
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Search Competency" + CompetencyTitle + "TC32154");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 3);//Verify the total is increased. Search same competency through competencies tab
            _test.Log(Status.Pass, "Verify competency count");

            //CommonSection.Logout();
            //// LoginPage.GoTo();
            //// LoginPage.LoginClick();
            //LoginPage.LoginAs("testuser123").WithPassword("").Login();//login with the user that was member of user group
            //CommonSection.Learn.CareerDevelopment();
            //CareersPage.FilterCompetenciesFor("usergroup_1102520752");

            //// Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [Test, Order(13), Category("P1")]
        public void a13_Remove_All_Types_from_Competency_32157()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Search " + CompetencyTitle + "TC32154");
            CareersPage.ClickCompetencyTitle(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Click on Conoetency Title");
            ManageCompetencyPage.SelectALLAssignedGroup();
            _test.Log(Status.Info, "Click On Select All Check Box");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemoveAllbutton(); //Success  The selected items were removed.
            _test.Log(Status.Info, "Click on Remove All button");
            //StringAssert.AreEqualIgnoringCase("The selected items were removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify successful message");
            //Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle);
            //CareersPage.CompetencyTab.CheckCompetencyTitle(CompetencyTitle);
            CommonSection.Manage.ProfessionalDevelopment();
            _test.Log(Status.Info, "Open Career Menu");
            CareersPage.ClickCompetencyTab();
            _test.Log(Status.Info, "Open Competency tab");
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle + "TC32154");
            _test.Log(Status.Info, "Search " + CompetencyTitle + "TC32154");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            _test.Log(Status.Pass, "Verify Assign Group Count");

        }
        [Test, Order(14), Category("AutomatedP1")]
        public void a14_Self_Enroll_in_Classroom_Course_14432()
        {
            #region create new course, add section to it and enroll
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify successful message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add new Section Button");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Filled Title as Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Filled Max Capacity to 11");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "New Classroom Course CreatedVerify Section1 link is present on screen");
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            // _test.Log(Status.Pass, "Create New Course Section and Event");
            CommonSection.Logout();
            #endregion
            #region Login with a Learner, search classroom course and enroll
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            _test.Log(Status.Info, "Open Current trainging Page");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');
            _test.Log(Status.Info, "Search course name as" + classroomcoursetitle);
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);
            _test.Log(Status.Info, "Click on Course title");
            CatalogPage.EnrollinClassroomCourse();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            #endregion


        }
        [Test, Order(15), Category("AutomatedP1")]
        public void a15_Self_Cancel_Enrollment_in_Classroom_Course_14435()
        {
            #region Login with learner and Cancel Enrollment for an Enrolled Classroom Course
            //LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            //_test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            _test.Log(Status.Info, "Open Current trainging Page");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');// ('"' + classroomcoursetitle + '"');
            _test.Log(Status.Info, "Search course name as" + classroomcoursetitle);
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle); //("ClassRoomCourseTitle2011472447");// 
            _test.Log(Status.Info, "Click on Course title");
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));// (classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            //CurrentTrainings.ClickAction();
            CatalogPage.CancelEnrollment();
            _test.Log(Status.Info, "Click on Cancel Enrollment");
            Assert.IsTrue(CatalogPage.GetMessages());
            _test.Log(Status.Pass, "Verify successful message is display");
            #endregion

        }

        [Test, Order(16)]
        public void a16_Add_proficiency_Scale_to_Competency_from_Create_Competency_32168()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CareersPage.CreateCompetency(CompetencyTitle+"TC32168");
            _test.Log(Status.Info, "Create a new competency");
            StringAssert.AreEqualIgnoringCase("Success\r\nThe competency was created.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message is display");
            ManageCompetencyPage.ClickAssignGroupsTab();
            AssignGroupPage.SelectUserGroupFilter();
            //AssignGroupPage.SearchGroups.ClickSearchbutton("");
            AssignGroupPage.SearchRecords.SelectFirstRecord();
            AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            _test.Log(Status.Info, "Click Assign Button");
            StringAssert.AreEqualIgnoringCase("Success\r\nThe selected groups were assigned.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            _test.Log(Status.Pass, "Verify successful message is display");
            //Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle("dfgdfgdg"));
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_NoScaledropdown());
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.RequiredRatingColumn_CheckRecord("1")); //displays the #1 lowest option of Proficiency Scale

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the Competency under Competency Listing
            CareersPage.ClickCompetencyTab(); //Verify the Competency Title created above
            CareersPage.SearchByCompetencyTitle(CompetencyTitle + "TC32168");
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_CheckProficiencyScale("test")); //Verify the Proficiency Scale selected above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating("1 - 3 3 View")); //Verify the Proficiency Scale Rating include First and Last Rating Number and label

            //CareersPage.CreateJobTitle(JobTitle + "TC32168"); //Verify the Proficiency Rating for the competency record under Job Title
           
            //Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.VerifyProficiencyScale("test"));
            //ManageJobTitlePage.CompetenciesTab.RemoveAllCompetency();
            //ManageJobTitlePage.CompetenciesTab.ClickAssignCompetency();
            //AssignCompetencyModal.SearchCompetency(CompetencyTitle + "TC32168");
            //Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.AssignCompetency_CompetencyTitle_CheckProficiencyScale("test"));

        }
        [Test, Order(17), Description("Dependent on 44")]
        public void a17_Add_proficiency_Scale_to_Competency_from_Existing_Competency_32287()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.SearchByCompetencyTitle(CompetencyTitle);
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_NoScaledropdown());
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            AssignGroupPage.SelectUserGroupFilter();
            AssignGroupPage.SelectFirstRecord();
            AssignGroupPage.ClickAssignButton();
            // Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickdropdown());
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            //      ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.RequiredRatingColumn_CheckRecord("1")); //displays the #1 lowest option of Proficiency Scale

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the Competency under Competency Listing
            CareersPage.ClickCompetencyTab(); //Verify the Competency Title created above
            CareersPage.SearchByCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_CheckProficiencyScale("test")); //Verify the Proficiency Scale selected above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating("3 View")); //Verify the Proficiency Scale Rating include First and Last Rating Number and label

            //CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the competency record under Job Title
            //CareersPage.ClickJobTitleTab();
            //CareersPage.JobTitlesTab.SearchJobTitle("dfgdfgdg");
            //CareersPage.JobTitlesTab.ClickJobTitleName("dfgdfgdg");
            //ManageJobTitlePage.CompetenciesTab.ClickAssignCompetency();
            //Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.AssignCompetency_CompetencyTitle_CheckProficiencyScale(""));

        }
        [Test, Order(18)]
        public void a18_View_Active_and_Inactive_competencies_32159()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCareerPathTab();
            CareersPage.ClickCompetencyTab();
            int recordsbefore = CareersPage.CompetencyTab.GetNumberOfRecords();
            CareersPage.CompetenciesTab.ClickInactiveItemsCheckbox();
            int recordsafter = CareersPage.CompetencyTab.GetNumberOfRecords();
            Assert.That(recordsafter > recordsbefore, recordsafter + " is not greater than " + recordsbefore);
            CareersPage.CompetenciesTab.ClickInactiveItemsCheckbox();
            recordsafter = CareersPage.CompetencyTab.GetNumberOfRecords();
            Assert.That(recordsafter == recordsbefore, "Records after is not equal to Records Before");
        }
        [Test, Order(19)]
        public void a19_Test_when_User_can_View_all_archived_proficiency_scales_from_the_tab_32401()

        {

            CommonSection.Manage.Careerstab();

            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.CreateNewProficencyScale("Scale_" + Meridian_Common.globalnum, "1", "2", "3");

            StringAssert.AreEqualIgnoringCase("The changes were saved.", Driver.getSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            CareersPage.ClickArchiveButtonforRecord_Regression_Scale1();
            StringAssert.AreEqualIgnoringCase("The item was archived.", Driver.getSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("No records found.", CareersPage.ProficiencyScaleTab.VerifyNoRecordsFoundisDsiplayed(), "Error message is different");
            CareersPage.ClickLink_ViewArchivedScales();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifyArchivedProficiencyScale(), "Error message is different");
            CareersPage.ProficiencyScaleTab.VerifyArchivedScaleisDeleted();
            ArchivedScale = true;
        }
        [Test, Order(20), Description("Dependent on 47")]
        public void a20_Test_when_User_can_archive_proficiency_scales_from_the_tab_32400()

        {
            Assert.IsTrue(ArchivedScale);
        }
        [Test, Order(21)]
        public void a21_Test_when_User_can_copy_proficiency_scales_from_the_tab_32399()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.CreateNewProficencyScale("Scale_" + Meridian_Common.globalnum, "1", "2", "3");

            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            CareersPage.ClickCopyButtonforRecord_Regression_Scale1();
            CareersPage.FrameCareers.EditTitle("Regression_Scale2");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Copy of Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");

            CareersPage.SearchTextBox("Copy of Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Copy of Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.Searchbutton();
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifySearchResultsisMatchedWith("Copy of Scale_" + Meridian_Common.globalnum, "Scale_" + Meridian_Common.globalnum));
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.Searchbutton();
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyScaleisDeleted(2));
        }
        [Test, Order(22)]
        public void a22_Test_when_User_can_edit_proficiency_scales_from_the_tab_32398()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.CreateNewProficencyScale("Scale_" + Meridian_Common.globalnum, "1", "2", "3");

            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            CareersPage.ClickEditButtonforRecord_RegressionScale();
            CareersPage.ProficiencyScaleTab.ProficiencyScaleModal.EditProficiencyScale("EditScale", "4", "5", "6");
            // CareersPage.FrameCareers.EditTitle("Regression_Scale1");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetProficiencyCreatedSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("EditScale");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("EditScale", CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyScaleisDeleted(1));
        }

        [Test, Order(23), Category("AutomatedP1")]
        public void a23_View_list_of_Competencies_from_Career_Development_page_33761()
        {
            Assert.True(true);   // this test cases is similar as 33755
        }

        [Test, Order(24)]
        public void a24_Delete_Job_Title_22213()
        {
            CareersPage.CreateJobTitle(JobTitle + "Delete");
            _test.Log(Status.Info, "A new job Title Created");
            CareersPage.DeleteJobTitle(JobTitle + "Delete");
            _test.Log(Status.Info, "Created job title searched and deleted");
            Assert.IsTrue(CareersPage.JobTitlesTab.Nomatchingrecordsfound());
            _test.Log(Status.Pass, "Verify job title is deleted");

        }
        [Test, Order(1), Category("AutomatedP1")]
        public void z27_Create_New_Account_Self_Registration_8585()
        {
            AccountCreation CreateAccount = new AccountCreation(driver);
            CommonSection.Logout();
            LoginPage.ClickSignup();
            _test.Log(Status.Info, "Click Sign up link on Login Page");

            CreateNewAccountobj.PopulateCreateNewUserLinkOuter(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            _test.Log(Status.Info, "Click Create button after fill all mandetory fields");
            HomePage.clickGetStarted();
            _test.Log(Status.Info, "Click On lets get Started button");
            Assert.IsTrue(HomePage.Title == "Home");
            _test.Log(Status.Pass, "User Successfully Logged in");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");

        }
        [Test, Order(2), Category("AutomatedP1")]
        public void z28_My_Training_Progress_Report_24843()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            ReportsConsolePage.SearchText("My");
            _test.Log(Status.Info, "Searched My");
            Assert.IsTrue(ReportsConsolePage.DisplayResult > 1);//checks results display more than 1
            ReportsConsolePage.ClickMyTrainingProgress();
            _test.Log(Status.Info, "Clicked My Training Progress");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            // Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "Clicked go button having details selected and opens details page");
            Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));//retrieves the text from details tab
            DetailsPage.ClickCloseWindowlink();
            _test.Log(Status.Info, "Details page closes");
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            Assert.IsTrue(RunReportPage.Title == "Run Report");
            Assert.IsTrue(Driver.focusParentWindow());
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "open reports from KI");
            ReportsPage.MyTrainingProgress.ClickRunReport();
            _test.Log(Status.Info, "opens run report page from KI");
            ReportsPage.ReportCriteriaModal.ClickRunReport();
            _test.Log(Status.Info, "click run report from KI");
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "click the go button having details option displayed");
            string restext = DetailsPage.CheckDetailsTabText;
            StringAssert.EndsWith("Details", restext);
            DetailsPage.ClickCloseWindowlink();
            _test.Log(Status.Info, "closed the details page ");
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));
            Driver.focusParentWindow();
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            //StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Reports");
        }
        [Test, Order(3), Category("AutomatedP1")]
        public void z29_Request_Access_to_SCORM_Course_26230()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26230");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isAccessApprovalAcordianDisplay());
            _test.Log(Status.Pass, "Verify Access Approval Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click check in button");

            CommonSection.SearchCatalog('"' + scormtitle + "TC26230" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26230");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
        }
        [Test, Order(4), Category("AutomatedP1")]
        public void z30_Cancle_Request_Access_to_SCORM_Course_26233()
        {
            CommonSection.SearchCatalog('"' + scormtitle + "TC26230" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26230");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.AccessApprovalModal.CancelRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
        }
        [Test, Order(5), Category("AutomatedP1")]
        public void z31_Request_Access_to_Document_26206()
        {
            CommonSection.CreteNewDocuemnt(documenttitle + "TC26206");
            _test.Log(Status.Info, "Creating New Document");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

            Assert.IsTrue(ContentDetailsPage.isAccessApprovalAcordianDisplay());
            _test.Log(Status.Pass, "Verify Access Approval Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click check in button");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog('"' + documenttitle + "TC26206" + '"');
            _test.Log(Status.Info, "Search created document from Catalog");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC26206");
            _test.Log(Status.Info, "Click searched document title");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
        }
        [Test, Order(6), Category("AutomatedP1")]
        public void z32_Cancel_Request_Access_to_Document_26207()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from Admin");
            LoginPage.LoginAs("saiflearner").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog('"' + documenttitle + "TC26206" + '"');
            _test.Log(Status.Info, "Search created document from Catalog");
            SearchResultsPage.ClickCourseTitle(documenttitle + "TC26206");
            _test.Log(Status.Info, "Click searched document title");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.AccessApprovalModal.CancelRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
        }
        [Test, Order(7), Category("AutomatedP1")]
        public void z33_View_Transcript_20487()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            StringAssert.AreEqualIgnoringCase("Transcript", TranscriptPage.pagetitle());
            _test.Log(Status.Pass, "Verify page title is Transcript");
            Assert.IsTrue(TranscriptPage.AllComponetsdisplay());
            _test.Log(Status.Pass, "Verify all componets of Transcript page is display");
            //TranscriptPage.AllMyTrainingPage.ClickSaveasPDF();
            //_test.Log(Status.Info, "Click on Save as PDF button");
            //Driver.Instance.SwitchWindow("Untitled - Google Chrome");
            //Assert.IsTrue(TranscriptAllMyTrainingPrintPage.Title.EndsWith("AllMyTrainingPrint.aspx"));
            //TranscriptAllMyTrainingPrintPage
            Driver.focusParentWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");


        }
        [Test, Order(75), Category("AutomatedP1")]
        public void Admin_bulk_adds_tags_on_manage_content_page_34043()
        {
            //login with a admin 
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Manage Content Search page");
            TrainingPage.SearchRecord("");
            _test.Log(Status.Info, "Click Search page");
            ManageContentPage.SelectMultipleResult();
            ManageContentPage.ClickAddTagOption_Select_DV_Test1();
            _test.Log(Status.Info, "Select Multiple records and click add tag and select DV_Test1 Tag");
            StringAssert.AreEqualIgnoringCase("DV_Test1", ManageContentPage.VerifyTags("DV_Test1"));
            _test.Log(Status.Info, "Verify that Tag DV_Test1 is applied to all selected items under Tags column");

        }
        [Test, Order(29)]
        public void R_User_sees_an_indicator_of_an_extension_being_granted_for_training_in_25202()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_Extendedtraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string extension_being_grantedTraining = driver.gettextofelement(By.Id("ctl00_MainContent_UC3_RadGrid1_ctl00__0"));
            StringAssert.Contains("Extended", extension_being_grantedTraining);
        }
        [Test, Order(27)]
        public void S_User_views_Due_Soon_label_for_due_soon_training_23663()
        {
            TrainingHomeobj.click_currenttraining();
            CurrentTrainingsobj.select_DueSoonTraining();
            CurrentTrainingsobj.clikonFilterbutton();
            string DueSoonStatus = driver.gettextofelement(By.CssSelector("div[id*='_pnlDueDate']"));
            StringAssert.Contains("Due Soon", DueSoonStatus);
        }
        [Test]
        public void Q_User_can_hide_non_required_training_25498()
        {
            TrainingHomeobj.click_currenttraining();
            driver.GetElement(By.CssSelector("input[id*='_btnReset']")).ClickWithSpace();
            Thread.Sleep(3000);
            CurrentTrainingsobj.Click_blogType(browserstr);
            CurrentTrainingsobj.course_dropdown();

            CurrentTrainingsobj.hidebtn_click();
            Thread.Sleep(3000);
            driver.GetElement(By.CssSelector("button[data-bb-handler='confirm']")).Click();
            //driver.SwitchTo().Alert().Accept();
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("Your content has been hidden. It is still available on your transcript.", successMsg);
        }
        [Test, Order(76)]
        public void Admin_bulk_removes_tags_on_manage_content_page_34044()
        {
            //login with a admin 
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Manage Content Search page");
            TrainingPage.SearchRecord("");
            _test.Log(Status.Info, "Click Search page");
            ManageContentPage.SelectMultipleResult();
            ManageContentPage.RemoveTag();
            _test.Log(Status.Info, "Select Multiple records and click Remove tag and select DV_Test1 Tag");
            StringAssert.AreNotEqualIgnoringCase("DV_Test1", ManageContentPage.VerifyTags("DV_Test1"));
            _test.Log(Status.Info, "Verify that Tag DV_Test1 is removed from all selected items under Tags column");

        }
        [Test, Order(29)]
        public void Create_JobTitle_22211()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.EditJobTitleName(JobTitle);
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            res1 = true;
            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }
        [Test, Category("AutomatedP1")]
        public void Create_Career_Path_31460()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCreateCareerPath();
            CreateCareerPathPage.EditCareerPathName(CareerPathTitle);
            //  CreateCareerPathPage.SaveCareerPathName();
            Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
            Assert.IsTrue(CareersPage.CheckCareerPathTitle("Create Career Path"));

        }
        [Test, Category("AutomatedP1")]
        public void View_List_of_Career_Path_as_existing_User_31461()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.SearchCareerPath(CareerPathTitle);
            Assert.IsTrue(CareersPage.CheckNameColumn(CareerPathTitle));

        }
    
       
        [Test, Order(14), Category("AutomatedP1")]
        public void Test_when_User_sets_the_active_dates_for_a_career_path_33167()
        {
            // LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            _test.Log(Status.Info, "Navigating to Career page");
            CareersPage.CareerPathTab.CreateCareerPath();
            _test.Log(Status.Info, "Click Create Career Path");
            CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
            _test.Log(Status.Info, "Fill career path name");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "click on career breadcrumb ");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "search created career path");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path status");
            CareersPage.CareerPathTab.ClickSearchResult("Reg_CareerPath");
            _test.Log(Status.Info, "click career path name");
            CreateCareerPathPage.SetActiveDates("5/4/2018", "5/31/2018");
            _test.Log(Status.Info, "Define Career path Active Datas");
            //Assert.IsTrue(CreateCareerPathPage.SetActiveDatesPopup.VerifyText("SetActiveDates "));
            //CreateCareerPathPage.FillStartDate("5/4/2018").FillEndDate("5/31/2018").ClickSave();
            Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
            _test.Log(Status.Info, "Date saved");
            Assert.IsTrue(CreateCareerPathPage.VerifyDates("Active from 05/04/2018 until 05/31/2018"));
            _test.Log(Status.Info, "Verify Career Path active dates");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify status should be Active");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "click on career breadcrumb");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "Search created career path");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path status");
        }
}

}
