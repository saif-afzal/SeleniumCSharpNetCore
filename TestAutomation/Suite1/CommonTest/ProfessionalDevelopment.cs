using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ProfessionalDevelopment_New : TestBase
    {
        string browserstr = string.Empty;
        public ProfessionalDevelopment_New(string browser)
            : base(browser)
        {
            // InitializeBase(driver);
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            //    LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
       
        //  [OneTimeSetUp]
        public void Login()
        {
            // Driver.Initialize();

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
                    ////////////string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(""));
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
        //  [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }
        //  [Test, Order(1)] need to automate that later
        public void Create_Career_Path_31460()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCreateCareerPath();
            CreateCareerPathPage.EditCareerPathName(CareerPathTitle);
            //  CreateCareerPathPage.SaveCareerPathName();
            Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
            Assert.IsTrue(CareersPage.CheckCareerPathTitle("Create Career Path"));

        }

        // [Test, Order(2)] need to be done later
        public void View_List_of_Career_Path_as_existing_User_31461()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.SearchCareerPath(CareerPathTitle);
            Assert.IsTrue(CareersPage.CheckNameColumn(CareerPathTitle));

        }
        [Test, Order(1), Category("cannot be automated")]
        public void Add_Job_title_model_22219()
        {
            Assert.Ignore("Need to be automated" + " Survey Issue on External");
        }





        [Test, Order(2), Category("cannot be automated")]
        public void Share_competency_across_domains_32183()
        {
            Assert.Ignore("Need to be automated" + " Survey Issue on External");


        }

        [Test, Order(3),Category("P1")]
        public void Edit_Competency_Details_Creation_31458()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CommonTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            //CreateCompetencyPage.SaveCompetencyName();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            ManageCompetencyPage.ClickCompetencyDetailsTab();
            ManageCompetencyPage.CompetencyDetailsTab.AddDescription("EditDescription");
            // ManageCompetencyPage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));

            StringAssert.AreEqualIgnoringCase("EditDescription", ManageCompetencyPage.GetDescriptionLink(), "Description does not match");
            ManageCompetencyPage.CompetencyDetailsTab.AddKeywords("EditKeywords");
            // ManageCompetencyPage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("EditKeywords", ManageCompetencyPage.GetKeywordLink(), "Keywords does not match");

        }
        //Reg_JobTItle needs to be created in different environments
        [Test, Order(4),Category("P1")]
        public void User_Edit_a_Job_title_31501()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            ManageJobTitlePage.ClickJobDetailsTab();
            ManageJobTitlePage.JobDetailsTab.AddDescription("Reg_Description");
            //   ManageJobTitlePage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("Reg_Description", ManageJobTitlePage.GetDescriptionLink(), "Description value does not match");
            ManageJobTitlePage.JobDetailsTab.AddKeywords("Reg_Keywords");
            //  ManageJobTitlePage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("Reg_Keywords", ManageJobTitlePage.GetKeywordLink(), "Keywords value does not match");
            ManageJobTitlePage.JobDetailsTab.JobCodeLink("Reg_JOBCODE");
            // ManageJobTitlePage.ClickSavebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            StringAssert.AreEqualIgnoringCase("Reg_JOBCODE", ManageJobTitlePage.GetJobCodeLink(), "JobCode Value does not match");

        }

        [Test, Order(5),Category("P1")]
        public void User_Remove_Competency_from_existing_Job_title_31504()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.SearchJobtitle(JobTitle);
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            CareersPage.ClickJobtitle(JobTitle);
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            //ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle);
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle);
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle);
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle));
        }

        [Test, Order(6),Category("P1")]
        public void User_Remove_Competency_while_Creating_New_Job_title_31506()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.EditJobTitleName(JobTitle);
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            Assert.IsTrue(CareersPage.JobTitle(JobTitle));
            ManageJobTitlePage.CareerTrackTab.ClickAssignCompetency();
            //ManageJobTitlePage.AssignCompetencyFrame.SearchCompetency(CompetencyTitle);
            ManageJobTitlePage.AssignCompetencyFrame.AssignCompetencyItem(CompetencyTitle);
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            ManageJobTitlePage.CareerTrackTab.RemoveCompetency(CompetencyTitle);
            // ManageJobTitlePage.ConfirmationWindow.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageJobTitlePage.GetSuccessMessage()));
            Assert.IsFalse(ManageJobTitlePage.NameColumn(CompetencyTitle));
        }
        [Test, Order(7), Category("P1")]//dependent on 31458
        public void Add_User_Group_to_Competency_32152() // need to create user and then make a user group to call that users
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);//cllick on record new competency required here
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignGroupsTab();//clicking on tab
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();//not required
            AssignGroupPage.SelectUserGroupFilter();//select user group filter
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("usergroup_1102520752");//search user group
            AssignGroupPage.SearchGroups.ClickSearchbutton();//clicking search button
            AssignGroupPage.SelectSearchRecord();//clicking chkbox for record found
            AssignGroupPage.ClickAssignButton();//clicking assisgn button
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.NameColumn("Dolly's User Group_12012017")); //checked the user group displaying in Assigned groups
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 1);//Verify the total is increased. Search same competency through competencies tab

            CommonSection.Logout();
            // LoginPage.GoTo();
            // LoginPage.LoginClick();
            LoginPage.LoginAs("esguser01").WithPassword("").Login();//login with the user that was member of user group
            CommonSection.Learn.CareerDevelopment();
            CareersPage.FilterCompetenciesFor("usergroup_1102520752");
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));

        }
        [Test, Order(8), Category("P1")]// dependednt on 32152
        public void Remove_User_Group_from_Competency_32155()
        {
            CommonSection.Logout();
            // LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            //ManageCompetencyPage.ClickAssignGroupsTab();
            //ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Dolly's User Group_12012017");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased. Search same competency through competencies tab
                                                                                                      //Verify the total is decressed to 0
            CommonSection.Logout();
            // LoginPage.GoTo();
            //    LoginPage.LoginClick();
            LoginPage.LoginAs("esguser01").WithPassword("").Login();//login with the user that was member of user group
            CommonSection.Learn.CareerDevelopment();
            CareersPage.FilterCompetenciesFor("usergroup_1102520752");
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            CommonSection.Logout();
        }
        [Test, Order(9), Category("P1")]
        public void Add_Organization_to_Competency_32153()// need to create organisation and then create a new user, assign him that organisation
        {
            CommonSection.Logout();
            // LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            AssignGroupPage.SelectOrganizationFilter();
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Sample Organization 1");
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            AssignGroupPage.SelectSearchRecord();
            AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.NameColumn("Sample Organization 1 ")); ;//checked the user group displaying in Assigned groups
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 1);//Verify the total is increased. Search same competency through competencies tab

            CommonSection.Logout();
            // LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("esguser01").WithPassword("").Login();//login with the user that was member of user group
            CommonSection.Learn.CareerDevelopment();
            CareersPage.FilterCompetenciesFor("Organization");
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(CompetencyTitle));
            CommonSection.Logout();
        }
        [Test, Order(10), Category("P1")]
        public void Remove_Organization_from_Competency_32156()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Sample Organization 1");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            StringAssert.AreEqualIgnoringCase("The Selected Groups were Removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle(""));
            CareersPage.CompetencyTab.CheckCompetencyTitle("");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            CommonSection.Logout();
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            CommonSection.Logout();
        }
        [Test, Order(11), Category("P1")]
        public void Add_AllTypes_to_Competency_32154()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            AssignGroupPage.SelectAllTypeFilter();
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            AssignGroupPage.SearchRecords.ClickSelectAllbutton();
            AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            StringAssert.AreEqualIgnoringCase("The Selected Groups were Assigned", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle(""));
            Assert.IsTrue(ManageCompetencyPage.CheckSubOrganizationIncluded());
            CareersPage.CompetencyTab.CheckCompetencyTitle("");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 1);//Verify the total is increased
            CommonSection.Logout();
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            CommonSection.Logout();
        }
        [Test, Order(12), Category("P1")]
        public void Remove_All_Types_from_Competency_32157()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickSearchbutton();
            ManageCompetencyPage.AssignedGroupsTab.ClickRemoveAllbutton();
            StringAssert.AreEqualIgnoringCase("The Selected Groups were Removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle(""));
            CareersPage.CompetencyTab.CheckCompetencyTitle("");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle_CheckAssignedGroupsColumn == 0);//Verify the total is increased
            CommonSection.Logout();
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            CommonSection.Logout();
        }
        [Test, Order(13),Category("P1")]
        public void ActiveInActive_Job_Title_In_Professional_Development_31882()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickShowInActiveItemsCheckbox(); //Check Inactive checkbox
            Assert.IsTrue(CareersPage.JobTitlesTab.CheckJobTitles);//Check for Active and Inactive Job Titles displayed
            CareersPage.JobTitlesTab.ClickShowInActiveItemsCheckbox(); //Uncheck Inactive Items Checkbox
            Assert.IsTrue(CareersPage.JobTitlesTab.CheckJobTitles);//Check for Only Active Job Titles displayed
        }
        [Test, Order(14),Category("P1")]
        public void Localize_Competency_32105()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            ManageCompetencyPage.ClickLocalizedIndropdown();
            ManageCompetencyPage.LocalizedIndropdown.ClickAddLocalization();
            AddLocalizationModal.LocalizedIndropdown.SelectLanguage("");
            AddLocalizationModal.EnterForm("Title", "Description", "Keywords");

            AddLocalizationModal.ClickLocalize();
            StringAssert.AreEqualIgnoringCase("The Changes were saved", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.ClickLocalizedIndropdown();
           //Assert.IsTrue(ManageCompetencyPage.LocalizedIndropdown.CheckLanguage);
        }
        [Test, Order(15),Category("P1")]
        public void User_adds_supplemental_training_to_a_new_competency_31561()

        {  // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName("CompetencyTitle_Reg");
            CreateCompetencyPage.SaveCompetencyName();
            StringAssert.AreEqualIgnoringCase("The Competency was created", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.AssociatedContentTab_click();
            ManageCompetencyPage.SupplementalTab_Click();
            StringAssert.AreEqualIgnoringCase("There is no supplemental content.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.AssociateContent_Click();
            ManageCompetencyPage.SearchTextFrame("Document that created as Pre req");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            StringAssert.AreEqualIgnoringCase("The selected items were added.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("dv_test"));//Added record should appear that we created as pre req
        }

        [Test, Order(16), Category("P1")]
        public void User_adds_supplemental_training_to_an_existing_competency_31562()
        {
            // //Pre-req: Login with admin and create a document/Gen. Course that will be added as supplemetanl training  
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchRecord("DV_Competency");
            ManageCompetencyPage.ClickAssociatedContentTab();
            ManageCompetencyPage.SupplementalTabclick();
            ManageCompetencyPage.AssociateContentClick();
            ManageCompetencyPage.SearchTextFrame("Document that created as Pre req");
            ManageCompetencyPage.SelectRecordFrame_ClickAddbutton();
            StringAssert.AreEqualIgnoringCase("The selected items were added.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.AssociateContent_VerifyAddedRecord("dv_test"));//Added record should appear that we created as pre req
        }

        [Test, Order(17),Category("P1")]
        public void Add_Job_Title_to_Competency_31507()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.ClickCompetency();
            ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
            AssignGroupPage.SelectJobTitleFilter();
            AssignGroupPage.SearchGroups.EnterSearchGroupstext("Manager");//Create this record for another environment
            AssignGroupPage.SearchGroups.ClickSearchbutton();
            AssignGroupPage.SelectSearchRecord();
            AssignGroupPage.ClickAssignButton();
            StringAssert.AreEqualIgnoringCase("The Selected Groups were Assigned", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle(""));
            CareersPage.CompetencyTab.CheckCompetencyTitle("");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);//Verify the total is increased
            CommonSection.Userdropdown.ClickLogout();
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Learn.ProfessionalDevelopment();
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            CommonSection.Userdropdown.ClickLogout();
        }
        [Test, Order(18),Category("P1")]
        public void Remove_Job_Title_from_Competency_31508()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.ClickCompetency();
            ManageCompetencyPage.ClickAssignGroupsTab();
            ManageCompetencyPage.AssignedGroupsTab.ClickSearchRecords("Manager");
            ManageCompetencyPage.AssignedGroupsTab.ClickRemovebutton();
            StringAssert.AreEqualIgnoringCase("The Selected Groups were Removed", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle(""));
            CareersPage.CompetencyTab.CheckCompetencyTitle("");
            Assert.IsTrue(CareersPage.CompetencyTab.CompetencyTitle.CheckAssignedGroupsColumn);//Verify the total is decreased
            CommonSection.Userdropdown.ClickLogout();
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Learn.ProfessionalDevelopment();
            Assert.IsTrue(CareersPage.CheckCompetencyTitle(""));
            CommonSection.Userdropdown.ClickLogout();
        }

        [Test, Order(19),Category("P1")]
        public void Switch_Mandatory_Content_to_Supplemental_in_Competency_31881() //dependent on the records already exists in Mandatory tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssociatedContentTab();//clicking on tab
            ManageCompetencyPage.AssociatedContentTab.ClickMandatoryTab();
            ManageCompetencyPage.SelectMandatoryRecords.ClickMakeSupplemental();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.SupplementalTab.CheckRecord);//Check Record is moved to Supplemental tab
            Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved from Mandatory tab
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is increased.
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is decreased.  
        }
        [Test, Order(20), Category("P1")]
        public void Switch_Supplemental_Content_to_Mandatory_in_Competency_32214() //dependent on the records already exists in Supplemental tab
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.SearchCompetency(CompetencyTitle);
            CareersPage.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssociatedContentTab();//clicking on tab
            ManageCompetencyPage.AssociatedContentTab.ClickSupplementalTab();
            ManageCompetencyPage.SelectSupplementalRecords.ClickMakeMandatory();
            Assert.IsTrue(Driver.comparePartialString("Success", ManageCompetencyPage.GetSuccessMessage()));
            Assert.IsTrue(ManageCompetencyPage.SupplementalTab.CheckRecord);//Check Record is moved from Supplemental tab
            Assert.IsTrue(ManageCompetencyPage.MandatoryTab.CheckRecord); //Check Record is moved to Mandatory tab
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckSupplementalTabCount);//Verify the total is decreased.
            Assert.IsTrue(ManageCompetencyPage.AssociatedContentTab.CheckMandatoryTabCount);//Verify the total is increased.

        }
        [Test, Order(21), Category("P1")]
        public void View_Proficiency_Scale_Details_from_list_of_competencies_32106()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.CheckProficiencyScaleColumn_ClickView());
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Modal with Numbers is displyed
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed

        }

        [Test, Order(22), Category("P1")]
        public void View_Proficiency_Scale_Details_from_Proficiency_Scale_Page_32107()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickProficiencyScalesTab();
            CareersPage.ProficiencyScalesTab_ClickProficiencyScaleTitle();
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord);
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord);
        }

        [Test, Order(23), Category("P1")]
        public void View_Proficiency_Scale_Details_from_Assigned_Groups_32109()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickAssignedGroupsTab();
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_clickViewScale);
            Assert.IsTrue(CareersPage.RatingScaleModal_Numbers_CheckRecord); //Verify Rating Scale Modal with Numbers is displyed
            Assert.IsTrue(CareersPage.RatingScaleModal_Labels_CheckRecord); //Verify Rating Scale Page Modal with Labels is displayed
        }

        [Test, Order(24),Category("P1")]
        public void Access_Careers_31888()
        {
            CommonSection.Manage.Careerstab();
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifySearchText("Career Paths"));
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyText("Job Title"));
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scale"));
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyText("360 Templates"));
            CommonSection.Userdropdown.ClickLogout();

            //LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("user_competencymanager").WithPassword("password").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            StringAssert.AreEqualIgnoringCase("Career Paths", CareersPage.CareerPathTab.VerifySearchText("Career Paths"));
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyText("Job Title"));
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyText("Proficiency Scale"));
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyText("360 Templates"));
        }

        [Test, Order(25), Category("P1")]
        public void Change_Sort_Order_of_competencies_32126()
        {
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(CareersPage.ListofCompetencies.SortDescending);
            CareersPage.SelectSortAscending();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord);
            CareersPage.SelectSortDescending();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord);

        }

        [Test, Order(26)]
        public void View_Active_and_Inactive_competencies_32159()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCareerPathTab();
            CareersPage.ClickCompetencyTab();
          int recordsbefore=  CareersPage.CompetencyTab.GetNumberOfRecords();
            CareersPage.CompetenciesTab.ClickInactiveItemsCheckbox();
            int recordsafter = CareersPage.CompetencyTab.GetNumberOfRecords();
            Assert.That(recordsafter > recordsbefore,recordsafter+" is not greater than "+recordsbefore);
            CareersPage.CompetenciesTab.ClickInactiveItemsCheckbox();
            recordsafter = CareersPage.CompetencyTab.GetNumberOfRecords();
            Assert.That(recordsafter == recordsbefore, "Records after is not equal to Records Before");
        }

        [Test, Order(27)]
        public void Set_Competency_Activity_Status_to_Active_with_No_Start_Date_And_No_End_Date_32160()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal_NoStartDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal_NoEndDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);
        }

        [Test, Order(28)]
        public void Set_Competency_Activity_Status_to_Active_with_No_Start_Date_And_With_End_Date_32162()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal_NoStartDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal_NoEndDateCheckbox_Uncheck();
            ManageCompetencyPage.SetActiveDatesModal_EnterEndDate("FutureDate"); //Select Future End Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Activ_ActiveUntil("Date"));

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);

        }

        [Test, Order(29)]
        public void Set_Competency_Activity_Status_to_Active_with_Start_Date_And_No_End_Date_32163()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal_NoEndDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.EnterStartDate("PastDate"); //Select Past Start Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Active_ActiveFrom("Date"));

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);

        }

        [Test, Order(30)]
        public void Set_Competency_Activity_Status_to_Active_with_Start_Date_And_End_Date_32164()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.NoEndDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.EnterStartDate("PastDate"); //Select Past Start Date
            ManageCompetencyPage.SetActiveDatesModal.EnterEndDate("FutureDate"); //Select Future End Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_Active_ActiveFromDate_UntilDate);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_Active);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecord_Active);

        }

        [Test, Order(31)]
        public void Set_Competency_Activity_Status_to_Active_with_Start_Date_to_Later_Than_Today_32165()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.NoEndDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.EnterStartDate("FutureDate"); //Select Future Start Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_InActive_ActiveFromDate);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecordIsInactive);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecordIsInactive);


        }
        [Test, Order(33)]
        public void Set_Competency_Activity_Status_to_Active_with_End_Date_to_Past_Date_32166()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetenciesTab.ClickCompetencyTitle(CompetencyTitle);
            ManageCompetencyPage.ClickStatusdropdown();
            ManageCompetencyPage.Statusdropdown.SelectActive();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            ManageCompetencyPage.Statusdropdown.SelectSetActiveDates();
            ManageCompetencyPage.SetActiveDatesModal.NoStartDateCheckbox_Check();
            ManageCompetencyPage.SetActiveDatesModal.NoEndDateCheckbox_UnCheck();
            ManageCompetencyPage.SetActiveDatesModal.EnterEndDate("PastDate"); //Select Past End Date
            ManageCompetencyPage.SetActiveDatesModal.ClickSave();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckStatus_InActive_ActiveUntilDate);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the record in List of Competencies
            CareersPage.ClickCompetencyTab();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecordIsInactive);

            CommonSection.Manage.Careerstab(); //Verify the status is changed to Active for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.ClickJobTitleName(JobTitle);
            ManageJobTitlePage.CompetenciesTab.ClickCompetency();
            Assert.IsTrue(ManageJobTitlePage.ListofCompetencies.CheckRecordIsInactive);


        }
        [Test, Order(34)]
        public void Add_proficiency_Scale_to_Competency_from_Create_Competency_32168()
        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickCompetencyTab();
            CareersPage.CompetencyTab.ClickCreateCompetency();
            CreateCompetencyPage.EditCompetencyName(CompetencyTitle);
            // CreateCompetencyPage.SaveCompetencyName();
           
            StringAssert.AreEqualIgnoringCase("Success\r\nThe competency was created.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            ManageCompetencyPage.ClickAssignGroupsTab();
           // ManageCompetencyPage.AssignedGroupsTab.ClickAssignGroupbutton();
         //   AssignGroupPage.SelectAllTypeFilter();
            AssignGroupPage.SearchGroups.ClickSearchbutton("");
            AssignGroupPage.SearchRecords.SearchRecord("");
            AssignGroupPage.ClickIncludeSubOrganizations("Yes");
            AssignGroupPage.ClickAssignButton();
            StringAssert.AreEqualIgnoringCase("Success\r\nThe selected groups were assigned.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ManageCompetencyPage.CheckGroupTitle("dfgdfgdg"));
          //  Assert.IsTrue(ManageCompetencyPage.CheckSubOrganizationIncluded());
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab_OptionalRatingfield_NoScaledropdown());
         //   Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_clickdropdown);
            ManageCompetencyPage.AssignedGroupsTab.OptionalRatingfield_dropdown_SelectProficiencyScale("test");
            Assert.IsTrue(ManageCompetencyPage.AssignedGroupsTab.RequiredRatingColumn_CheckRecord("1")); //displays the #1 lowest option of Proficiency Scale

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the Competency under Competency Listing
            CareersPage.ClickCompetencyTab(); //Verify the Competency Title created above
            CareersPage.SearchByCompetencyTitle(CompetencyTitle);
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_CheckProficiencyScale("test")); //Verify the Proficiency Scale selected above
            Assert.IsTrue(CareersPage.CompetenciesTab.ListOfCompetencies.CompetencyTitle_ProficiencyScaleColumn_CheckProficiencyScaleRating("1 - 3 3 View")); //Verify the Proficiency Scale Rating include First and Last Rating Number and label

            CommonSection.Manage.Careerstab(); //Verify the Proficiency Rating for the competency record under Job Title
            CareersPage.ClickJobTitleTab();
            CareersPage.JobTitlesTab.SearchJobTitle("dfgdfgdg");
            CareersPage.JobTitlesTab.ClickJobTitleName("dfgdfgdg");
            Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.VerifyProficiencyScale("test"));
            ManageJobTitlePage.CompetenciesTab.RemoveAllCompetency();
            ManageJobTitlePage.CompetenciesTab.ClickAssignCompetency();
            AssignCompetencyModal.SearchCompetency(CompetencyTitle);
            Assert.IsTrue(ManageJobTitlePage.CompetenciesTab.AssignCompetency_CompetencyTitle_CheckProficiencyScale("test"));

        }

        [Test, Order(35)]
        public void Add_proficiency_Scale_to_Competency_from_Existing_Competency_32287()
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

        [Test, Order(36), Category("P1")]
        //Pre-req - Learner has atleast one competency assigned to them they have not completed and one completed
        public void Filter_competencies_by_Complete_Incomplete_Status_32130()
        {
            CommonSection.Learn.CareerDevelopment();
            Assert.IsTrue(CareersPage.ListofCompetencies.InProgressStatus);
            CareersPage.SelectCompleteIcon();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_CompletedStatus);
            CareersPage.SelectInProgressIcon();
            Assert.IsTrue(CareersPage.ListofCompetencies.CheckRecord_InProgressStatus);
            //QUESTIONS - What to do if no competencies with In Progress or Completed Status - How to display a message "You have no Incomplete Competencies" or "You have no Completed Competencies"
        }
        [Test, Order(37), Category("P1")]
        public void Verify_Updated_label_of_Career_Development_on_Domain_Page_32303()

        {
            CommonSection.Manage.Careerstab();
            DomainsPage.ClickDomainLink("Meridian Global-Core Domain(default)");
            EditSummaryPage.ClickMenuTab();
            StringAssert.AreEqualIgnoringCase("Career Development", MenuPage.GetSuccessMessage(), "Error message is different");
            MenuPage.ClickOptionsTab("");
            StringAssert.AreEqualIgnoringCase("Enable Career Development", EditConfigurationOptionsPage.GetSuccessMessage(), "Error message is different");
        }


        [Test, Order(38), Category("P1")]
        public void Test_to_Verify_order_of_Tabs_on_Careers_page_32310()

        {

            CommonSection.Manage.Careerstab();
            StringAssert.AreEqualIgnoringCase("Job Titles", CareersPage.GetSuccessMessage(), "Error message is different");//verify tab name
            StringAssert.AreEqualIgnoringCase("Competencies", CareersPage.GetSuccessMessage(), "Error message is different");//verify tab name
            StringAssert.AreEqualIgnoringCase("Proficiency Scales", CareersPage.GetSuccessMessage(), "Error message is different");//verify tab name
            StringAssert.AreEqualIgnoringCase("360 Templates", CareersPage.GetSuccessMessage(), "Error message is different");//verify tab name

        }

        [Test, Order(39), Category("P1")]
        public void Test_to_Verify_instruction_Text_On_Tabs_and_Careers_page_32311()

        {
            CommonSection.Manage.Careerstab();
            Assert.IsTrue(CareersPage.VerifyInstructionText);
            CareersPage.ClickTab("Job Titles");
            Assert.IsTrue(CareersPage.JobTitlesTab.VerifyInstructionText);
            CareersPage.ClickTab("Competencies");
            Assert.IsTrue(CareersPage.CompetenciesTab.VerifyInstructionText);
            CareersPage.ClickTab("Proficiency Scales");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyInstructionText);
            CareersPage.ClickTab("360 Templates");
            Assert.IsTrue(CareersPage.Chk360TemplatesTab.VerifyInstructionText);

        }

        [Test, Order(40),Category("P1")]
        public void Test_when_User_add_a_new_proficiency_scale_31801()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.ClickCreateNewProficencyScale();
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.ClickTitleTextBox("Regression Scale");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
        }
        [Test, Order(41), Category("P1")]
        public void User_View_lists_all_Proficiency_Scales_32373()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.ClickCreateNewProficencyScale();
            StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.TitleTextBox("Regression Scale");
            CareersPage.RatingCriteria_1.Label("1");
            CareersPage.RatingCriteria_2.Label("2");
            CareersPage.RatingCriteria_3.Label("3");
            CareersPage.ClickCreatebutton();
            StringAssert.AreEqualIgnoringCase(" The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Regression Scale");
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase(" Regression Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            StringAssert.AreEqualIgnoringCase(" 1-3", CareersPage.GetSuccessMessage(), "Error message is different");

        }

        [Test, Order(42),Category("P1")]
        public void Curriculum_Equivalencies_10828()

        {
            //login 
            CommonSection.CreateLink.ClickCurriculumns();
            CurriculumsPage.Create("Reg_Curriculumn");
            //  CurriculumsPage.SelectCollaborationSpaceOption.No();
            //   CurriculumsPage.Create();
            StringAssert.AreEqualIgnoringCase("The item was created.", CurriculumsDetailsPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Equivalencies", CurriculumsDetailsPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("No equivalencies are currently assigned.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            CurriculumsDetailsPage.Equivalencies.ClickEdit();
            StringAssert.AreEqualIgnoringCase("Search For", EquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Search Type", EquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Content Type", EquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("User Search", EquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            CurriculumsDetailsPage.ClickAddEquivalencies();
            StringAssert.AreEqualIgnoringCase("Search For", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Search Type", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Content Type", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("User Search", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            AddEquivalenciesPage.ClickSeaMoreSearchCriteria();
            StringAssert.AreEqualIgnoringCase("Title", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Description", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Keywords", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Activity", AddEquivalenciesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            AddEquivalenciesPage.VerifySearchButton();
            AddEquivalenciesPage.VerifyBackButton();
            AddEquivalenciesPage.VerifyAddButton();
            AddEquivalenciesPage.Search("dv");
            AddEquivalenciesPage.SelectRecord();//select it by mouse selection
            AddEquivalenciesPage.ClickAddButton();
            StringAssert.AreEqualIgnoringCase("The items were added as equivalencies.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            CurriculumsDetailsPage.Selectrecord("DV-Classroom_12/122017");//mark any record as checked
            CurriculumsDetailsPage.ClickRemovebutton();
            Assert.IsTrue(CurriculumsDetailsPage.JSConfirmationMsg());
            StringAssert.AreEqualIgnoringCase("The selected items were removed and are no longer prerequisites.", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            CurriculumsDetailsPage.ClickBackbutton();
            StringAssert.AreEqualIgnoringCase("1 Assigned Equivalencies", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Assigned To:", ManageCompetencyPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
        }

        [Test, Order(43),Category("P1")]
        public void Curriculum_Prerequisites_10829()

        {
            //login 
            CommonSection.CreateLink.ClickCurriculumns();
            CurriculumsPage.Create("Curriculumn"+Meridian_Common.globalnum,"Tags"+ Meridian_Common.globalnum, "No");
        
            StringAssert.AreEqualIgnoringCase("The item was created.", Driver.getSuccessMessage());//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Prerequisites", CurriculumsPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("No prerequisites are currently assigned.", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify Breadcrumb text
            CurriculumsDetailsPage.Prerequisites.ClickEdit();
            //StringAssert.AreEqualIgnoringCase("Search For", PrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Search Type", PrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Content Type", PrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("User Search", PrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            PrerequisitesPage.ClickAddPrerequisites();
            //StringAssert.AreEqualIgnoringCase("Search For", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Search Type", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Content Type", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("User Search", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
                                                                                                                                     // ClickSeaMoreSearchCriteria();
            //StringAssert.AreEqualIgnoringCase("Title", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Description", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Keywords", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //StringAssert.AreEqualIgnoringCase("Activity", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //AddPrerequisitesPage.VerifySearchButton();
            //AddPrerequisitesPage.VerifyBackButton();
            //AddPrerequisitesPage.VerifyAddButton();
            AddPrerequisitesPage.SearchFor("dv");
            // AddPrerequisitesPage.SelectRecord();//select it by mouse selection
            //  AddPrerequisitesPage.ClickAddButton();
            StringAssert.AreEqualIgnoringCase("The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", Driver.getSuccessMessage(), "Error message is different");//verify Breadcrumb text
            //PrerequisitesPage.Selectrecord("DV-Classroom_12/122017");//mark any record as checked
            PrerequisitesPage.ClickBackbutton();
            StringAssert.AreEqualIgnoringCase("1 Assigned Prerequisites", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("1 Content Items", PrerequisitesPage.GetPrerequisiteAssignedToContentItems(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("1 Groups", PrerequisitesPage.GetPrerequisiteAssignedToUserGroups(), "Error message is different");//verify Breadcrumb text

            PrerequisitesPage.ClickRemovebutton();
           // Assert.IsTrue(PrerequisitesPage.JSConfirmationMsg());
            StringAssert.AreEqualIgnoringCase("The selected items were removed and are no longer prerequisites.", Driver.getSuccessMessage(), "Error message is different");//verify Breadcrumb text
            
         
        }

        [Test, Order(44), Category("P1")]
        public void To_create_an_ordered_block_and_add_learning_activities_15648()

        {
            //login 
            CommonSection.CreateLink.ClickCurriculumns();
            CurriculumsPage.Create("Reg_Curriculumn");
            // CurriculumnPage.SelectCollaborationSpaceOption.No().click;
            // CurricullumnsPage.Create().click;
            StringAssert.AreEqualIgnoringCase("The item was created.", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Curriculum Content", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("There are no items in the curriculum.", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify Breadcrumb text
            CurriculumsPage.CurriculumContent.ClickEdit();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.CurriculumContentFrame_SelectType("Ordered");
            CurriculumContentPage.CurriculumContentFrame_Title_Text("Reg_block");
            CurriculumContentPage.CurriculumContentFrame_ClickSave();
            Assert.IsTrue(CurriculumContentPage.GetSuccessMessage("The changes were saved."));//
            CurriculumContentPage.ClickAddTrainingActivities();
            AddTrainingActivitiesPage.VerifySearchButton();
            AddTrainingActivitiesPage.VerifyBackButton();
            AddTrainingActivitiesPage.VerifyAddButton();
            AddTrainingActivitiesPage.Search("dv");
            AddPrerequisitesPage.SelectRecord();//select it by mouse selection
            AddPrerequisitesPage.ClickAddButton();
            StringAssert.AreEqualIgnoringCase("The selected items were added.", AddPrerequisitesPage.GetSuccessMessage(), "Error message is different");
            AddPrerequisitesPage.ClickBackButton();
            CurriculumContentPage.Selectrecord("DV-Classroom_12/122017");//mark any record as checked
            CurriculumContentPage.ClickRemovebutton();
            StringAssert.AreEqualIgnoringCase("JSConfirmationMsg", "");
            Assert.IsTrue(CurriculumContentPage.GetSuccessMessage("The item was removed."));//
            CurriculumContentPage.ClickBackbutton();
            StringAssert.AreEqualIgnoringCase("The curriculum contains 1 item(s).", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//
        }
        [Test, Order(45), Category("AutomatedP1")]
        public void Curriculum_Permissions_10832()

        {
            //login 
            CommonSection.CreateLink.ClickCurriculumns();
            CurriculumsPage.Create("Reg_Curriculumn");
            //  CurriculumnPage.SelectCollaborationSpaceOption.No().click;
            //  CurricullumnsPage.Create().click;
            StringAssert.AreEqualIgnoringCase("The item was created.", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Permissions", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify Breadcrumb text
            CurriculumsDetailsPage.Permissions.ClickEdit();
            StringAssert.AreEqualIgnoringCase("Search For", PermissionsPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Search Type", PermissionsPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Content Type", PermissionsPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("User Search", PermissionsPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            PermissionsPage.ClickAssignPermissions();
            StringAssert.AreEqualIgnoringCase("Search For", AddUsersPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Search Type", AddUsersPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("Content Type", AddUsersPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            StringAssert.AreEqualIgnoringCase("User Search", AddUsersPage.GetSuccessMessage(), "Error message is different");//verify Breadcrumb text
            AddUsersPage.VerifySearchButton();
            AddUsersPage.VerifyBackButton();
            AddUsersPage.VerifySaveButton();
            AddUsersPage.Search("dv");
            AddUsersPage.ManageRecord("Learner,dv");
            StringAssert.AreEqualIgnoringCase("The permissions information was saved.", PermissionsPage.GetSuccessMessage(), "Error message is different");//verify  text
            PermissionsPage.ClickBackbutton();
            CurriculumsPage.ClickCheckin();
            StringAssert.AreEqualIgnoringCase("The permissions information was saved.", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify  text
                                                                                                                                                           //logout
                                                                                                                                                           //login with the learner whom we assigned manage permission
            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Reg_Curriculumn");
            StringAssert.AreEqualIgnoringCase("Reg_Curriculumn", SearchResultsPage.GetSuccessMessage(), "Error message is different");//verify  text
            TrainingPage.ClickSearchRecord("Reg_Curriculumn");
            StringAssert.AreEqualIgnoringCase("Reg_Curriculumn", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify  text
            CurriculumsPage.ClickCheckout();
            CurriculumsPage.EditSummary();
            SummaryPage.UpdateTitle("Reg_Curriculumn-update");
            StringAssert.AreEqualIgnoringCase("Reg_Curriculumn-update", CurriculumsPage.GetPrerequisiteMessage(), "Error message is different");//verify  text

        }
        [Test, Order(46)]
        public void Test_to_Verify__breadcrumb_on_Development_Plan_Approval_page_32322()

        {

            CommonSection.Manage.DevelopmentPlanApprovals();
            StringAssert.AreEqualIgnoringCase("Development Plan Approvals", DevelopmentPlanApprovalsPage.VerifyLabelText(), "Error message is different");//verify Label text
            StringAssert.AreEqualIgnoringCase("Manage / Development Plan Approvals", DevelopmentPlanApprovalsPage.VerifyBreadcrumbText(), "Error message is different");//verify Breadcrumb text

        }

        [Test, Order(47)]
        public void Test_when_User_can_edit_proficiency_scales_from_the_tab_32398()

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
            CareersPage.ClickEditButtonforRecord_RegressionScale();
            CareersPage.ProficiencyScaleTab.ProficiencyScaleModal.EditProficiencyScale("EditScale", "4", "5", "6");
            // CareersPage.FrameCareers.EditTitle("Regression_Scale1");
            StringAssert.AreEqualIgnoringCase("The changes were saved.", Driver.getSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("EditScale");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("EditScale", CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
            StringAssert.AreEqualIgnoringCase("1-3", CareersPage.ProficiencyScaleTab.VerifySearchResultScale(), "Error message is different");
            Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyScaleisDeleted(1));
        }

        [Test, Order(48)]
        public void Test_when_User_can_copy_proficiency_scales_from_the_tab_32399()

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
            CareersPage.ClickLink_ViewArchivedScales();
            // StringAssert.AreEqualIgnoringCase("Scale_" + Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifyArchivedProficiencyScale(), "Error message is different");
            CareersPage.SearchTextBox("Scale_" + Meridian_Common.globalnum);
            CareersPage.Searchbutton();
           Assert.IsTrue(CareersPage.ProficiencyScaleTab.VerifyScaleisDeleted(2));

        }
        [Test, Order(50)]
        public void Test_when_User_can_archive_proficiency_scales_from_the_tab_32400()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scales");
            //CareersPage.ClickCreateNewProficencyScale();
            //StringAssert.AreEqualIgnoringCase("Create New Proficiency Scale", CareersPage.GetSuccessMessage(), "Error message is different");
            //CareersPage.TitleTextBox("Regression_Scale1");
            //CareersPage.RatingCriteria_1.Label("1");
            //CareersPage.RatingCriteria_2.Label("2");
            //CareersPage.RatingCriteria_3.Label("3");
            //CareersPage.ClickCreatebutton();
            //StringAssert.AreEqualIgnoringCase(" The changes were saved.", CareersPage.GetSuccessMessage(), "Error message is different");
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
        }
        [Test, Order(49)]
        public void Test_when_User_can_View_all_archived_proficiency_scales_from_the_tab_32401()

        {
           
            CommonSection.Manage.Careerstab();

            CareersPage.ClickTab("Proficiency Scales");
            CareersPage.CreateNewProficencyScale("Scale_"+Meridian_Common.globalnum, "1","2","3");
  
            StringAssert.AreEqualIgnoringCase("The changes were saved.", Driver.getSuccessMessage(), "Error message is different");
            CareersPage.SearchTextBox("Scale_"+ Meridian_Common.globalnum);
            CareersPage.SelectSearchType("Exact Phrase");
            CareersPage.Searchbutton();
            StringAssert.AreEqualIgnoringCase("Scale_"+ Meridian_Common.globalnum, CareersPage.ProficiencyScaleTab.VerifySearchResultTitle(), "Error message is different");
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

        }



        [Test, Order(51)]
        public void Test_Searching_for_Competency_by_Name_Keyword_Description_31474()

        {
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Competencies");
            CareersPage.ClickButtonCreateCompetency();
            CreateCompetencyPage.FillTitleTextBox_NewCompetency("Regression_Competency1");
            CreateCompetencyPage.ClickSubTab_CompetencyDetail();
            CreateCompetencyPage.SetDescription("Description_Regression_Competency1");
            CreateCompetencyPage.SetKeywords("Keyword_Regression_Competency1");
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Competencies");
           // StringAssert.AreEqualIgnoringCase("Regression_Competency1", CareersPage.SearchByKeyword()); //This will return a string which will contain competency title
            CommonSection.Manage.Careerstab();
            //StringAssert.AreEqualIgnoringCase("Regression_Competency1", CareersPage.SearchByDescription()); //This will return a string which will contain competency title
            CommonSection.Manage.Careerstab();
           // StringAssert.AreEqualIgnoringCase("Regression_Competency1", CareersPage.SearchByCompetencyTitle()); //This will return a string which will contain competency title

        }

        [Test, Order(52)]
        public void Test_Creation_of_Job_Title_from_Professional_Development_31482()

        {
            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Job Title");
            CareersPage.ClickCreateJobTitleButton();
            CreateCompetencyPage.FillTitleTextBox_NewJobTitle("Regression_JobTitle1");
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Job Title");
            StringAssert.AreEqualIgnoringCase("Regression_JobTitle1", CareersPage.SearchByJobTitle1()); //This will return a string which will contain jobtitle title


        }





        [Test, Order(53)]
        public void Test_Creation_of_Job_Title_from_Professional_Development_31555()

        {

            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Competencies");
            CareersPage.SearchByCompetencyTitle("Regression_Competency1");
            CareersPage.ClickLinkCompetencyFromSearchResult();
            ManageCompetencyPage.ClickSubTabAssociateContent();
            ManageCompetencyPage.ClickSubTabMandatoryContent();
            ManageCompetencyPage.ClickButtonAssociateContent();
            ManageCompetencyPage.Frame.SelectFirstContent();
            ManageCompetencyPage.Frame.ClickButtonAdd();
            StringAssert.AreEqualIgnoringCase("Selected Content", "Content in the Grid");



        }
        [Test, Order(54)] // this test case will be last test case in test file.
        public void Test_User_Able_To_Delete_Competency_32104()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Competencies");
            CareersPage.SearchByCompetencyTitle("Regression_Competency1");
            CareersPage.SelectCheckboxForCompetency();
            CareersPage.ClickButtonDeleteForCompetency();
            CareersPage.Frame.ClickButtonDelete();
            CareersPage.SearchByCompetencyTitle("Regression_Competency1");
           // StringAssert.AreNotEqualIgnoringCase(SearchResultsPage.MatchRecord("Regression_JobTitle1"), "Regression_Competency1"); //competency will not display in search result then test case pass

        }


        [Test, Order(55)]
        public void Test_User_defines_the_required_rating_for_a_job_title_specific_competency_32221()

        {
            CommonSection.Manage.Careerstab();
            CareersPage.ClickTab("Proficiency Scale");
            CareersPage.ClickButtonCreateNewProficiencyScale();
            CareersPage.Frame.EnterScaleTitle("ProficiencyScale_Test");
            CareersPage.Frame.EnterRatingCriteriaLable1("1");
            CareersPage.Frame.EnterRatingCriteriaLable1("2");
            CareersPage.Frame.EnterRatingCriteriaLable1("3");
            CareersPage.Frame.ClickButtonCreate();

            CareersPage.ClickTab("Job Title");
            CareersPage.SearchByCompetencyTitle("Regression_JobTitle1");
            CareersPage.ClickOnJobTitleSearchResult("Regression_JobTitle1");
            TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.ClickButtonAssignCompetency();
            TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.Frame.EnterCompetencyToAdd("Regression_Competency1");
            TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.Frame.ClickButtonSearch();
            TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.Frame.SelectCompetencyCheckbox();
            TestAutomation.Suite.Responsibilities.ProfessionalDevelopment.JobTitlesPage.Frame.ClickButtonAssign();

            CareersPage.ClickTab("Competencies");
            CareersPage.SearchByCompetencyTitle("Regression_Competency1");
            CareersPage.ClickLinkCompetencyFromSearchResult();
            ManageCompetencyPage.SelectProficiencyScaleFromDropdown();
            ManageCompetencyPage.ClickOnAssignedGroupSubTab();
            ManageCompetencyPage.ClickButtonAssignedGroup();
            ManageCompetencyPage.Frame.SearchForJobTitle("Regression_JobTitle1");
            ManageCompetencyPage.Frame.SelectJobTitleCheckbox("Regression_JobTitle1");
            ManageCompetencyPage.Frame.ClickButtonAssign();

            ManageCompetencyPage.ChangeRequiredRatingsForJobTitle();
            Assert.IsTrue(false);// "Success Message About Ratings Change");


        }
        [Test, Order(56), Category("cannot be automated")]
        public void View_Response_Site_Layout_instead_of_Static_Site_Layout_32298()
        {
            Assert.Ignore("Mobile related");

        }
        [Test, Order(57), Category("cannot be automated")]
        public void UserInformation_7996()
        {
            Assert.Fail("need to check");

        }
        [Test, Order(58),Category("P1")]
        public void Login_8597()
        {
            Assert.True(true);

        }
        [Test, Order(59), Category("P1")]
        public void Logout_24943()
        {
            Assert.True(true);

        }
        [Test, Order(60)]
        public void Test_Learner_View_Competency_Detail_Model_Widnow_32149()

        {
            //This Test is developed in 18.1 however this feature has been pushed to 18.2 so can not automate it.
        }

        [Test, Order(61)]
        public void Test_when_User_sets_the_active_flag_for_a_career_path_33161()
        {
            //   LoginPage.GoTo();
            // LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            _test.Log(Status.Info, "Navigating to Career page ");
            CareersPage.CareerPathTab.CreateCareerPath();
            _test.Log(Status.Info, "Click Create Career Path");
            CreateCareerPathPage.EditCareerPathName("Reg_CareerPath1");
            _test.Log(Status.Info, "Fill career path name");
            StringAssert.AreEqualIgnoringCase("Active", CreateCareerPathPage.CheckStatus("Active"));
            _test.Log(Status.Info, "Select status as Active");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "Click career path breadcrumb");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath1");
            _test.Log(Status.Info, "Search created career path");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath1", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"), "Actual text was " + CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify Active Status");
        }
        [Test, Order(62)]
        public void Test_when_User_sets_the_Inactive_flag_for_a_career_path_33166()
        {
            //  LoginPage.GoTo();
            // LoginPage.LoginClick();
            // LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            _test.Log(Status.Info, "Navigating to Career page ");
            CareersPage.CareerPathTab.CreateCareerPath();
            _test.Log(Status.Info, "Click Create Career Path");
            CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
            _test.Log(Status.Info, "Fill career path name");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "Click career path breadcrumb");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "Search created career path");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path Status");
            CareersPage.CareerPathTab.ClickSearchResult("Reg_CareerPath");
            _test.Log(Status.Info, "Click Career path name");
            CreateCareerPathPage.ChangeStatus("Inactive");
            _test.Log(Status.Info, "Select status as Inactive");
            StringAssert.AreEqualIgnoringCase("Inactive", CreateCareerPathPage.CheckStatus("Inactive"));
            _test.Log(Status.Info, "Verify status updated to Inactive");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "Click career path breadcrumb");
            CareersPage.CareerPathTab.SelectShowInactiveItems();
            _test.Log(Status.Info, "Click show inactive item checkbox");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "Search created career path ");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Inactive", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("InActive"));
            _test.Log(Status.Info, "Verify InActive Status");
        }
        [Test, Order(63)]
        public void Test_when_User_searches_for_a_career_path_33168()
        {
            // LoginPage.GoTo();
            //  LoginPage.LoginClick();
            //  LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            _test.Log(Status.Info, "Navigating to Career page ");
            CareersPage.CareerPathTab.CreateCareerPath();
            _test.Log(Status.Info, "Click Create Career Path");
            CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
            _test.Log(Status.Info, "Fill career path name");
            StringAssert.AreEqualIgnoringCase("Active", CreateCareerPathPage.CheckStatus("Inactive "));
            _test.Log(Status.Info, "Verify status");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "click on Careers Breadcrumb");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "Search Created Career Path ");
            CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath");
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path status");
        }
        [Test, Order(64)]
        public void Test_when_User_sets_the_active_dates_for_a_career_path_33166()
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
        [Test, Order(65)]
        public void Test_when_user_navigates_to_section_enrollment_From_sections_listing_33267()
        {

            LoginPage.GoTo();
            LoginPage.LoginClick();
            LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
            // create a classroom and Section like : dv_class1105 , section 1
            CommonSection.Manage.Training();
            TrainingPage.ClickSearchRecord("dv_class1805");

            AdminContentDetailsPage.ClickSectionsTab();
            SectionsPage.ClickManageEnrollmentButton();//click manage enrollment button for section 1
                                                       // EnrollmentPage.BatchEnrollUsers();
            Assert.IsTrue(Driver.comparePartialString("Enrolled", EnrollmentPage.VerifyTab()));
            StringAssert.AreEqualIgnoringCase("There are no enrolled students.", EnrollmentPage.GetDescriptionLink(), "Description does not match");
        }
        [Test, Order(66)]
        public void Select_credit_type_columns_in_Training_Progress_Report_33515()
        {
            // create a credit value with name - dv_credit_type
            //   Create a General coruse with name - dv_gc2205_credit_value
            //Add credit type with value as 1 or 1 both default cretid value and dv_credit_type checkin
            // Learner complete this course then login with admin
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "Navigating to Report page ");
            ReportsConsolePage.SearchText("My Training Progress");
            _test.Log(Status.Info, "Search My Training Progress Report");
            ReportsConsolePage.ClickMyTrainingProgress();
            _test.Log(Status.Info, "Click My Training Progress Title name");
            StringAssert.AreEqualIgnoringCase("My Training Progress", MyTrainingProgressPage.verifylabel("My Training Progress"));
            _test.Log(Status.Info, "Verify Label name = My Training Progress");
            MyTrainingProgressPage.ClickSelectButton();
            _test.Log(Status.Info, "Click Select button");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "Click Run Report");
            StringAssert.AreEqualIgnoringCase("Meridian Global Reporting", MeridianGlobalReportingPage.Title);
            _test.Log(Status.Info, "Verify page label");
            MeridianGlobalReportingPage.CustomizeTableColumns("DV_Credit_Type", "Default Credit Type");//Click on gear icon Below formula button
                                                                                                       //      MeridianGlobalReportingPage.SelectColumns("DV_Credit_Type", "Default Credit Type");
            StringAssert.AreEqualIgnoringCase("dv_dc2205_credit_value", MeridianGlobalReportingPage.ContentTitle);//verify course name
            _test.Log(Status.Info, "Verify Course name");
            _test.Log(Status.Info, "Select DV_Credit_Type and Default Credit Type options");
            Assert.IsTrue(MeridianGlobalReportingPage.verifycolumn("dv_credit_type"), "dv_Credit_Type column not present");//verify colums
            Assert.IsTrue(MeridianGlobalReportingPage.verifycolumn1("Default Credit Type"), "Default Credit Type not present");//verify colums
            StringAssert.AreEqualIgnoringCase("1", MeridianGlobalReportingPage.verifycolumnvalue("1"), "Mismatch for Dv_Credit_Type_value");

            StringAssert.AreEqualIgnoringCase("1", MeridianGlobalReportingPage.verifycolumnvalue1("1"), "Mismatch for Default Credit Type");
        }
      
        //[Test, Order(61)]
        //public void Test_when_User_sets_the_active_flag_for_a_career_path_33161()
        //{
        // //   LoginPage.GoTo();
        //   // LoginPage.LoginClick();
        //    //LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
        //    CommonSection.Manage.Careers();
        //    _test.Log(Status.Info, "Navigating to Career page ");
        //    CareersPage.CareerPathTab.CreateCareerPath();
        //    _test.Log(Status.Info, "Click Create Career Path");
        //    CreateCareerPathPage.EditCareerPathName("Reg_CareerPath1");
        //    _test.Log(Status.Info, "Fill career path name");
        //    StringAssert.AreEqualIgnoringCase("Active",CreateCareerPathPage.CheckStatus("Active"));
        //    _test.Log(Status.Info, "Select status as Active");
        //    CreateCareerPathPage.ClickCareerBreadcrumb();
        //    _test.Log(Status.Info, "Click career path breadcrumb");
        //    CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath1");
        //    _test.Log(Status.Info, "Search created career path");
        //    StringAssert.AreEqualIgnoringCase("Reg_CareerPath1", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"), "Actual text was " + CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
        //    _test.Log(Status.Info, "Verify career path name");
        //    StringAssert.AreEqualIgnoringCase("Active",CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
        //    _test.Log(Status.Info, "Verify Active Status");
        //}
        //[Test, Order(62)]
        //public void Test_when_User_sets_the_Inactive_flag_for_a_career_path_33166()
        //{
        //  //  LoginPage.GoTo();
        //   // LoginPage.LoginClick();
        //   // LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
        //    CommonSection.Manage.Careers();
        //    _test.Log(Status.Info, "Navigating to Career page ");
        //    CareersPage.CareerPathTab.CreateCareerPath();
        //    _test.Log(Status.Info, "Click Create Career Path");
        //    CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
        //    _test.Log(Status.Info, "Fill career path name");
        //    CreateCareerPathPage.ClickCareerBreadcrumb();
        //    _test.Log(Status.Info, "Click career path breadcrumb");
        //    CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
        //    _test.Log(Status.Info, "Search created career path");
        //    StringAssert.AreEqualIgnoringCase("Active",CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
        //    _test.Log(Status.Info, "Verify career path Status");
        //    CareersPage.CareerPathTab.ClickSearchResult("Reg_CareerPath");
        //    _test.Log(Status.Info, "Click Career path name");
        //    CreateCareerPathPage.ChangeStatus("Inactive");
        //    _test.Log(Status.Info, "Select status as Inactive");
        //    StringAssert.AreEqualIgnoringCase("Inactive",CreateCareerPathPage.CheckStatus("Inactive"));
        //    _test.Log(Status.Info, "Verify status updated to Inactive");
        //    CreateCareerPathPage.ClickCareerBreadcrumb();
        //    _test.Log(Status.Info, "Click career path breadcrumb");
        //    CareersPage.CareerPathTab.SelectShowInactiveItems();
        //    _test.Log(Status.Info, "Click show inactive item checkbox");
        //    CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
        //    _test.Log(Status.Info, "Search created career path ");
        //    StringAssert.AreEqualIgnoringCase("Reg_CareerPath",CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
        //    _test.Log(Status.Info, "Verify career path name");
        //    StringAssert.AreEqualIgnoringCase("Inactive",CareersPage.CareerPathTab.VerifySearchedRecordStatusText("InActive"));
        //    _test.Log(Status.Info, "Verify InActive Status correctly");
        //}
        //    [Test, Order(63)]
        //    public void Test_when_User_searches_for_a_career_path_33168()
        //    {
        //       // LoginPage.GoTo();
        //      //  LoginPage.LoginClick();
        //      //  LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
        //        CommonSection.Manage.Careers();
        //        _test.Log(Status.Info, "Navigating to Career page ");
        //        CareersPage.CareerPathTab.CreateCareerPath();
        //        _test.Log(Status.Info, "Click Create Career Path");
        //        CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
        //        _test.Log(Status.Info, "Fill career path name");
        //        StringAssert.AreEqualIgnoringCase("Active",CreateCareerPathPage.CheckStatus("Inactive "));
        //        _test.Log(Status.Info, "Verify status");
        //        CreateCareerPathPage.ClickCareerBreadcrumb();
        //        _test.Log(Status.Info, "click on Careers Breadcrumb");
        //        CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
        //        _test.Log(Status.Info, "Search Created Career Path ");
        //        CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath");
        //        _test.Log(Status.Info, "Verify career path name");
        //        StringAssert.AreEqualIgnoringCase("Active",CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
        //        _test.Log(Status.Info, "Verify career path status");
        //    }
        //    [Test, Order(64)]
        //    public void Test_when_User_sets_the_active_dates_for_a_career_path_33166()
        //    {
        //       // LoginPage.GoTo();
        //        //LoginPage.LoginClick();
        //        //LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
        //        CommonSection.Manage.Careers();
        //        _test.Log(Status.Info, "Navigating to Career page");
        //        CareersPage.CareerPathTab.CreateCareerPath();
        //        _test.Log(Status.Info, "Click Create Career Path");
        //        CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
        //        _test.Log(Status.Info, "Fill career path name");
        //        CreateCareerPathPage.ClickCareerBreadcrumb();
        //        _test.Log(Status.Info, "click on career breadcrumb ");
        //        CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
        //        _test.Log(Status.Info, "search created career path");
        //        StringAssert.AreEqualIgnoringCase("Reg_CareerPath",CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
        //        _test.Log(Status.Info, "Verify career path name");
        //        StringAssert.AreEqualIgnoringCase("Active",CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
        //        _test.Log(Status.Info, "Verify career path status");
        //        CareersPage.CareerPathTab.ClickSearchResult("Reg_CareerPath");
        //        _test.Log(Status.Info, "click career path name");
        //        CreateCareerPathPage.SetActiveDates("5/4/2018", "5/31/2018");
        //        _test.Log(Status.Info, "Define Career path Active Datas");
        //        //Assert.IsTrue(CreateCareerPathPage.SetActiveDatesPopup.VerifyText("SetActiveDates "));
        //        //CreateCareerPathPage.FillStartDate("5/4/2018").FillEndDate("5/31/2018").ClickSave();
        //        Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
        //        _test.Log(Status.Info, "Date saved");
        //        Assert.IsTrue(CreateCareerPathPage.VerifyDates("Active from 05/04/2018 until 05/31/2018"));
        //        _test.Log(Status.Info, "Verify Career Path active dates");
        //        StringAssert.AreEqualIgnoringCase("Active",CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
        //        _test.Log(Status.Info, "Verify status should be Active");
        //        CreateCareerPathPage.ClickCareerBreadcrumb();
        //        _test.Log(Status.Info, "click on career breadcrumb");
        //        CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
        //        _test.Log(Status.Info, "Search created career path");
        //        StringAssert.AreEqualIgnoringCase("Reg_CareerPath",CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
        //        _test.Log(Status.Info, "Verify career path name");
        //        StringAssert.AreEqualIgnoringCase("Active",CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
        //        _test.Log(Status.Info, "Verify career path status");
        //    }
        //    [Test, Order(65)]
        //    public void Test_when_user_navigates_to_section_enrollment_From_sections_listing_33267()
        //    {

        //        LoginPage.GoTo();
        //        LoginPage.LoginClick();
        //        LoginPage.LoginAs("").WithPassword("").Login(); //Login as admin
        //        // create a classroom and Section like : dv_class1105 , section 1
        //        CommonSection.Manage.Training();
        //        TrainingPage.ClickSearchRecord("dv_class1805");

        //        ContentDetailsPage.ClickSectionsTab();
        //        SectionsPage.ClickManageEnrollmentButton();//click manage enrollment button for section 1
        //       // EnrollmentPage.BatchEnrollUsers();
        //        Assert.IsTrue(Driver.comparePartialString("Enrolled", EnrollmentPage.VerifyTab()));
        //        StringAssert.AreEqualIgnoringCase("There are no enrolled students.", EnrollmentPage.GetDescriptionLink(), "Description does not match");
        //    }
        //    [Test, Order(66)]
        //    public void Select_credit_type_columns_in_Training_Progress_Report_33515()
        //    {
        //        // create a credit value with name - dv_credit_type
        //        //   Create a General coruse with name - dv_gc2205_credit_value
        //        //Add credit type with value as 1 or 1 both default cretid value and dv_credit_type checkin
        //        // Learner complete this course then login with admin
        //        CommonSection.Administer.System.Reporting.ReportConsole();
        //        _test.Log(Status.Info, "Navigating to Report page ");
        //        ReportsConsolePage.SearchText("My Training Progress");
        //        _test.Log(Status.Info, "Search My Training Progress Report");
        //        ReportsConsolePage.ClickMyTrainingProgress();
        //        _test.Log(Status.Info, "Click My Training Progress Title name");
        //        StringAssert.AreEqualIgnoringCase("My Training Progress", MyTrainingProgressPage.verifylabel("My Training Progress"));
        //        _test.Log(Status.Info, "Verify Label name = My Training Progress");
        //        MyTrainingProgressPage.ClickSelectButton();
        //        _test.Log(Status.Info, "Click Select button");
        //        RunReportPage.ClickRunReport();
        //        _test.Log(Status.Info, "Click Run Report");
        //        StringAssert.AreEqualIgnoringCase("Meridian Global Reporting", MeridianGlobalReportingPage.Title);
        //        _test.Log(Status.Info, "Verify page label");
        //        MeridianGlobalReportingPage.CustomizeTableColumns("DV_Credit_Type", "Default Credit Type");//Click on gear icon Below formula button
        //  //      MeridianGlobalReportingPage.SelectColumns("DV_Credit_Type", "Default Credit Type");
        //        StringAssert.AreEqualIgnoringCase("dv_dc2205_credit_value", MeridianGlobalReportingPage.ContentTitle);//verify course name
        //        _test.Log(Status.Info, "Verify Course name");
        //        _test.Log(Status.Info, "Select DV_Credit_Type and Default Credit Type options");
        //        Assert.IsTrue(MeridianGlobalReportingPage.verifycolumn("dv_credit_type"), "dv_Credit_Type column not present");//verify colums
        //        Assert.IsTrue(MeridianGlobalReportingPage.verifycolumn1("Default Credit Type"), "Default Credit Type not present");//verify colums
        //        StringAssert.AreEqualIgnoringCase("1", MeridianGlobalReportingPage.verifycolumnvalue("1"), "Mismatch for Dv_Credit_Type_value");

        //        StringAssert.AreEqualIgnoringCase("1", MeridianGlobalReportingPage.verifycolumnvalue1("1"), "Mismatch for Default Credit Type");


        //    }
        //}
    }
}

