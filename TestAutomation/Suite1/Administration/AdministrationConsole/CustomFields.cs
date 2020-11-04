//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Selenium2;
//using OpenQA.Selenium;
//using NUnit.Framework;
//using Selenium2.Meridian;
//using System.Threading;
//using TestAutomation.Meridian.Regression_Objects;

//namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
//{ `
//    class CustomFields : TestBase
//    {

//        [OneTimeSetUp]
//        public void OneTimeSetUp()
//        {
//            Common.closeie();
//            driver = StartBrowser();
//            InitializeBase(driver);
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
         
//        }
//        [SetUp]
//        public void starttest()
//        {
//            Meridian_Common.islog = false;
//            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
//            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
//            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
//        }
//        [Test]
//        public void a_Create_a_custom_field_and_make_it_in_use()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_EditUserInfo();
//            CustomFieldobj.Click_NewCustomFieldGoTo();
//            Assert.IsTrue(CreateNewCustomFieldobj.Populate_NewCustomField());
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            //AdminstrationConsoleobj.Click_SelectItemLink("Custom Fields");
//            CustomFieldobj.Click_Test();
//            CustomFieldobj.Click_NewCustomFieldGoTo();
//            Assert.IsTrue(  CreateNewCustomFieldobj.Populate_NewCustomField());
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

//            //verify field in test
//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
//            Testsobj.Click_CreateGoTo();
//           Assert.IsTrue( Testsobj.Verify_CustomField());
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//        }
//        [Test]
//        public void b_Edit_a_default_field()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_Test();
//            CustomFieldobj.Click_DefaultAction();
//          Assert.IsTrue(  EditFieldobj.Click_EditDefaultField());
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//        }
//        [Test]
//        public void c_Edit_a_custom_field()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_Test();
//            CustomFieldobj.Click_CustomAction();
//            Assert.IsTrue(EditFieldobj.Click_EditCustomField());
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//        }

//        [Test]
//        public void d_Reorder_custom_field()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_Test();
           
//            Assert.IsTrue(CustomFieldobj.Click_ReorderField());
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//        }

//        [Test]
//        public void e_Remove_a_custom_field_or_remove_visibility_for_a_custom_field()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_Test();
//            CustomFieldobj.Click_DeleteField();
//            EditFieldobj.Click_UnCheckVisibility();
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

//            //verify field in test
//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
//            Testsobj.Click_CreateGoTo();
//            Assert.IsTrue(Testsobj.Verify_CustomFieldNotAvailable());
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//        }

//        //[Test]
//        //public void f_perform_user_search_using_any_searchable_field_for_Manage_enrollment_online_19380()
//        //{

//        //    driver.UserLogin("admin1");
//        //    TrainingHomeobj.isTrainingHome();
//        //    TrainingHomeobj.Click_AdminConsoleLink();
//        //    AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//        //    CustomFieldobj.Click_EditUserInfo();
//        //    CustomFieldobj.Click_NewCustomFieldGoTo();
//        //    Assert.IsTrue(CreateNewCustomFieldobj.Populate_NewCustomField());
//        //    //driver.SelectWindowClose1();
//        //    driver.selectWindow(" 	Training Home ");

//        //    generalcourseobj.linkmyresponsibilitiesclick();
//        //    generalcourseobj.tabcontentmanagementclick();
//        //    generalcourseobj.buttoncoursecreationgoclick("General Course");
//        //    generalcourseobj.populatesummarygeneralcourse(driver, ExtractDataExcel.MasterDic_genralcourse["Title"], ExtractDataExcel.MasterDic_genralcourse["Desc"], 9);
//        //    generalcourseobj.populateCourseFilesform(driver);
//        //    Assert.IsTrue(generalcourseobj.buttoncreateclick(driver));

//        //    TrainingHomeobj.MyResponsiblities_click();
//        //    MyResponsibilitiesobj.Click_ManageEnrollmentForOnlineCourses();
//        //    ManageEnrollmentForOnlineCoursesobj.populateSearchForm(ExtractDataExcel.MasterDic_genralcourse["Title"]);
//        //    ManageEnrollmentForOnlineCoursesobj.Click_ManageUsers();


//        //    Assert.IsTrue(ManageEnrollmentForOnlineCoursesobj.verify_customFieldVisible("custom_" + ExtractDataExcel.token_for_reg));

//        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            
//        //}

//        //[Test]
//        //public void g_perform_user_search_using_any_searchable_field_for_Manage_enrollment_classroom_19379()
//        //{

//        //    driver.UserLogin("admin1");
//        //    TrainingHomeobj.isTrainingHome();
//        //    TrainingHomeobj.Click_AdminConsoleLink();
//        //    Thread.Sleep(3000);
//        //    AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//        //    CustomFieldobj.Click_EditUserInfo();
//        //    CustomFieldobj.Click_NewCustomFieldGoTo();
//        //    Assert.IsTrue(CreateNewCustomFieldobj.Populate_NewCustomField());
//        //    //driver.SelectWindowClose1();
//        //    driver.selectWindow(" 	Training Home ");

//        //    TrainingHomeobj.MyResponsiblities_click();
//        //    Trainingobj.SearchContent_Click();
//        //    ContentSearchobj.NewContent("Classroom Course");
//        //    Createobj.FillClassroomCoursePage("");
//        //    Contentobj.ManageSectionTab();
//        //    ScheduleAndManageSectionobj.AddNewSection_Click();

//        //    CourseSectionobj.CreateNewSectionInPerson(driver, "");

//        //    TrainingHomeobj.MyResponsiblities_click();
//        //    MyResponsibilitiesobj.Click_ManageEnrollmentForClassroomCourses();
//        //    ManageEnrollmentForOnlineCoursesobj.populateSearchForm(Variables.classroomCourseTitle);
//        //    ManageEnrollmentForOnlineCoursesobj.Click_courseTitle();
//        //    ManageEnrollmentForOnlineCoursesobj.Click_ManageUsersClassroom();


//        //    Assert.IsTrue(ManageEnrollmentForOnlineCoursesobj.verify_customFieldVisible("custom_" + ExtractDataExcel.token_for_reg));

//        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

//        //}

//        [Test]
//        public void h_perform_user_search_using_any_searchable_field_for_People_homepage_19360()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            Thread.Sleep(3000);
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_EditUserInfo();
//            CustomFieldobj.Click_NewCustomFieldGoTo();
//            Assert.IsTrue(CreateNewCustomFieldobj.Populate_NewCustomField());
//            //driver.SelectWindowClose1();
//            driver.selectWindow(" 	Training Home ");


//            TrainingHomeobj.MyResponsiblities_click();
//            MyResponsibilitiesobj.Click_People();
            


//            Assert.IsTrue(manageuserobj.verify_customFieldVisible("custom_" + ExtractDataExcel.token_for_reg));

//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

//        }

//        [Test]
//        public void i_custom_fields_not_visible_in_domains_not_shared_19351()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            Thread.Sleep(3000);
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_Documents();
//            CustomFieldobj.Click_NewCustomFieldGoTo();
//            CreateNewCustomFieldobj.Populate_NewCustomField();
//            driver.selectWindow(" 	Training Home ");

//            driver.Navigate().GoToUrl("http://baseqa-14-5.dm1.meridianksi.net");
//            driver.UserLogin("child1admin");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            Thread.Sleep(3000);
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_Documents();
//            Assert.IsTrue(CustomFieldobj.verify_customFieldNotPresent());

//            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);

//        }

//        [Test]
//        public void j_Domain_admins_can_add_custom_fields_for_use_with_user_profile_19345()
//        {

//            driver.UserLogin("admin1");
//            TrainingHomeobj.isTrainingHome();
//            TrainingHomeobj.Click_AdminConsoleLink();
//            Thread.Sleep(3000);
//            AdminstrationConsoleobj.Click_OpenItemLink("Custom Fields");
//            CustomFieldobj.Click_Documents();
//            CustomFieldobj.Click_NewCustomFieldGoTo();
//            CreateNewCustomFieldobj.Populate_NewCustomField();
//            Assert.IsTrue(CustomFieldobj.verify_customFieldPresent());

//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//        }


//        [TearDown]
//        public void stoptest()
//        {

//            if (Meridian_Common.islog == true)
//            {
//                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//            }
//        }
//        [OneTimeTearDown]
//        public void OneTimeTearDown()
//        {

//            driver.Quit();
//        }

//    }
//}
