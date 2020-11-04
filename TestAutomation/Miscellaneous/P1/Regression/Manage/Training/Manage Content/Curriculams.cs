using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using OpenQA.Selenium.Firefox;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.P1.MyResponsibilities.Training
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CurriculamsP1 : TestBase
    {
        string browserstr = string.Empty;
        bool courseCreated = false;
        public CurriculamsP1(string browser)
            : base(browser)
        {
            browserstr = browser;
        }


       
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
           // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }
        [SetUp]
        public void starttest()
        {
            classroomcourse = new ClassroomCourse(driver);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin",browserstr);
            }
            Meridian_Common.islog = false;
        }
        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            } 
        }
        
        //[Test, Order(1)]
        public void A_Create_Curriculam_10822()
        {
            Assert.IsTrue(objCurriculum.createCurriculum(browserstr));
            
        }
     
        //[Test, Order(2)]
        public void B_Manage_Curriculam_10823()
        {
            Assert.IsTrue(objCurriculum.manageCurriculum("", browserstr));
        }

       //[Test, Order(3)]
        public void C_Curriculams_Categories_10826()
        {

            Assert.IsTrue(objCurriculum.curriculumCategory("", browserstr));

        }

        //[Test, Order(4)]
        public void D_Curriculams_Cost_10825()
        {
            Assert.IsTrue(objCurriculum.curriculumCost("", browserstr));
        }

        //[Test, Order(5)]
        public void E_Curriculams_Alternate_Cost_10824()
        {
            Assert.IsTrue(objCurriculum.curriculumAlternativeCost("", browserstr));
        }

        //[Test, Order(6)]
        public void F_Curriculam_Image_10827()
        {
            Assert.IsTrue(objCurriculum.curriculumImage("", browserstr));
        }

        //[Test, Order(7)]
        public void G_Curriculam_Equivalencies_10828()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test, Order(8)]
        public void H_SCurriculams_Prerequisites_10829()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test, Order(9)]
        public void Curriculams_Certificate_10830()
        {
            Assert.IsTrue(objCurriculum.curriculumCertificate("", browserstr));
        }
        //[Test, Order(10)]
        public void H_Curriculams__Approval_Path_10831()
        {
            Assert.IsTrue(objCurriculum.curriculumApprovalPath("", browserstr));
        }
        //[Test, Order(11)]
        public void H_Curriculams__Content_Sharing_10834()
        {
            Assert.IsTrue(objCurriculum.curriculumContentSharing("", browserstr));
        }
        //[Test, Order(12)]
        public void H_Curriculams__Permissions_10832()
        {
            Assert.Fail("Need to be automated");
        }
        //[Test, Order(13)]
        public void To_create_an_ordered_block_and_add_learning_activities_15648()
{
            Assert.Fail("Need to be automated");
        }
        //[Test, Order(14)]
        public void H_Curriculams__Activity_10833()
        {
            Assert.IsTrue(objCurriculum.curriculumActivity("", browserstr));
        }
     
        //[Test, Order(15)] //Cannot be automated
        public void To_Test_Authorized_user_can_create_a_curriculum_block_of_credit_type_and_can_choose_credit_type_15694()
        {
            Assert.Ignore("Can not be automate");
        }
        //[Test, Order(16)] //CaNNOT BE Automated
        public void To_Test_Authorized_user_can_create_a_optional_block_and_can_add_learning_activities_15647()
        {
            Assert.Ignore("Can not be automate");
        }
        //[Test, Order(17)] //CaNNOT BE Automated
        public void Search_and_Add_training_activities_15758()
        {
            Assert.Ignore("Can not be automate");
        }
        //[Test, Order(18)]//Done
        public void I_Curriculams__Checkin_Checkout_10840()
        {
            Document documentpage = new Document(driver);
            documentpage.linkmyresponsibilitiesclick();
            documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr);
            Assert.IsTrue(driver.Checkin());
            Thread.Sleep(3000);
            Assert.IsTrue(driver.Checkout());
        }
        //[Test, Order(19)]//done
        public void H_Curriculams__Surveys_10837()
        {
            Assert.IsTrue(objCurriculum.curriculumSurvey("", browserstr));
        }
        //[Test, Order(20)]//done
        public void H_Curriculams__Add_Training_Activities_10841()
        {
            Assert.IsTrue(objCurriculum.curriculumAddTrainingActivity("", browserstr));
        }
        //[Test, Order(21)]//done
        public void Z_Add_Calssroom_Section__10848()
        {
            Assert.IsTrue(objCurriculum.curriculumAddTrainingActivityClassroom("", browserstr));
        }
        //[Test, Order(22)]//done
        public void H_Curriculams__Add_Locale_10835()
        {
            driver.Quit();
            Driver.Initialize();
            LoginPage.GoTo();

            LoginPage.LoginClick();
            LoginPage.LoginAs("regadmin").WithPassword("password").Login();
            CommonSection.Manage.Training();
            TrainingPageki.SearchforContent(Variables.curriculumTitle + browserstr);
            SearchResultsPage.CheckSearchRecord(Variables.curriculumTitle + browserstr);
            ContentDetailsPage.ClickAddLocaleButton();
            string langSet = AddLocalePage.SetInfo();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.GetSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.AddLocalCheck("Arabic"));
        }
        //[Test, Order(23)]//done
        public void H_Curriculams__Delete_Locale_10836()
        {
            driver.Quit();
            Driver.Initialize();
            LoginPage.GoTo();

            LoginPage.LoginClick();
            LoginPage.LoginAs("regadmin").WithPassword("password").Login();
            CommonSection.Manage.Training();
            TrainingPageki.SearchforContent(Variables.curriculumTitle + browserstr);
            SearchResultsPage.CheckSearchRecord(Variables.curriculumTitle + browserstr);
            ContentDetailsPage.DeleteLocal();
            DeleteLocalePage.ClickDeleteLocalButton();

            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.GetSuccessMessage(), "Error message is different");

        }
    }
}
