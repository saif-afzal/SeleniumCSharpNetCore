using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;
using Selenium2;

namespace Selenium2.Meridian.Suite.MyResponsibilities.e_InstructorTools
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class d_NeedsGrading : TestBase
    {
        string browserstr = string.Empty;
        public d_NeedsGrading(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        //Initiating Driver
        public void OneTimeSetUp()
        {
           

            Common.closeie();
            ExtractDataExcel.fillalldic();
       //     driver = StartBrowser();

            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);

           // InitializeBase(driver);
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);


            // PreRequisite - Create a new instructor
          //  driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            manageuserobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_instructor["Id"]+browserstr, ExtractDataExcel.MasterDic_instructor["Firstname"]+browserstr, ExtractDataExcel.MasterDic_instructor["Lastname"]+browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            manageuserobj.populateaccountsearchform(ExtractDataExcel.MasterDic_instructor["Firstname"]+browserstr, ExtractDataExcel.MasterDic_instructor["Lastname"]+browserstr);
            manageuserobj.Click_SearchUser();
            driver.tempUserLogin("instructor", ExtractDataExcel.MasterDic_instructor["Id"]+browserstr, manageuserobj.passwordcreationnewuser(), browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
         //   TrainingHomeobj.AdminConsole_Click(driver);
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
           
            AdminstrationConsoleobj.Click_OpenItemLink("Instructors");

            //AdminstrationConsoleobj.Click_OpenItemLink("Instructors");
            Instructorsobj.CreateInstructor_Click(driver, browserstr);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);
        }

        [SetUp]
        public void SetUp()
        {

            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);


        }

        [Test]
        public void a_Assign_instructor_to_test_for_grading_essay_questions_18512()
        {
            driver.UserLogin("admin1", browserstr);

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_CreateGoTo();
            Testsobj.Populate_CreateForm("", browserstr);
            Testsobj.Click_CreateNewGroupGoTo();
            Testsobj.Populate_CreateQuestionGroupForm();
            Testsobj.Click_Return();
            Testsobj.Click_NewQuestionGoTo("New Essay");
            Testsobj.Populate_NewQuestionForm();
            Testsobj.Click_Return();
            Testsobj.Click_testsLinkBreadCrumb();
            Testsobj.Click_SearchTestNew("test_"+ browserstr + ExtractDataExcel.token_for_reg);
            Testsobj.Click_LockTest();
            Testsobj.Click_publishScorm12();
            Testsobj.Populate_PublishScormForm();
            Testsobj.Click_SelectInstructorsTab();
            Testsobj.Click_GoToAddInsturctor();
            Testsobj.Populate_AddUserForm(browserstr);
            Assert.IsTrue(Testsobj.AddSelectedUser());
            Testsobj.Click_Return();
            Testsobj.Click_CheckinTab();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


            
        }

        [Test]
        public void b_instructor_to_see_all_of_the_test_submissions_that_needs_to_grade()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.Click_TrainingCatalogLink();
            TrainingHomeobj.Click_Search("test_" + browserstr + ExtractDataExcel.token_for_reg);
            SearchResultsobj.MyResponsbilities_Content_Click_Catalog();
            Testsobj.Click_Test_OpenItem(browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("instructor", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.linkinstructortoolsclick();
            Assert.IsTrue(Testsobj.Click_NeedGradingTab());

                   



        }



    }
}
