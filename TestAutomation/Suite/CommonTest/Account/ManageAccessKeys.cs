using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;
using OpenQA.Selenium.Support.UI;
using System.Reflection;


namespace Selenium2.Meridian.Suite.CommonTest.Account
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ManageAccessKeys : TestBase
    {
        string browserstr = string.Empty;
        public ManageAccessKeys(string browser)
            : base(browser)
        {
            browserstr = browser + "ATAK";
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
            #region Create New User ExtractDataExcel.MasterDic_newuser["Id"] + browserstr (user),ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr(email)
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr);
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            #endregion
            # region    Create Classroom Course ExtractDataExcel.MasterDic_classrommcourse["Title"] +browserstr
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            classroomcourse.CreateClassRoomCourse(browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            # endregion
            #region Create General Course ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
           
            generalcourseobj.CreateGeneralCource(browserstr, "No");
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            #endregion
        
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.Click_CheckIn();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("testuser", browserstr, ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, "password");
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingCatalogobj.SearchAndClickSearched_GeneralCourse(browserstr);
            ShoppingCartsobj.PurchaseAccessKeysandOpenViewOrder_NewUser(browserstr);

        }

        [SetUp]
        public void starttest()
        {
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);

            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }


        [Test]
        public void A_User_navigates_to_their_Order_History_via_the_profile_dropdown_TC25812()
        {
            driver.Navigate_to_TrainingHome();
            driver.OrderClick(ObjectRepository.OrdersHoverLink, ObjectRepository.HoverMainLink);
            Assert.IsTrue(driver.WaitForElement(ObjectRepository.manageaccesskeys));
        }

        [Test]
        public void B_From_order_details_user_assigns_access_key_to_another_user_TC25942()
        {
             driver.OrderClick(ObjectRepository.OrdersHoverLink, ObjectRepository.HoverMainLink);
            ShoppingCartsobj.Click_ManageAccessKeys();
            ShoppingCartsobj.AssignCourse_AccessKeys(browserstr);
            ShoppingCartsobj.EnterUser_ToEnterAccessKey();
            Assert.IsTrue(driver.WaitForElement(By.CssSelector("div[class*='alert-success']")));

        }

        [Test]
        public void C_From_order_details_user_downloads_access_keys_TC25943()
        {
            Assert.IsTrue(accesskeys.Click_Download_Keys(browserstr));
        }

        [Test]
        public void D_From_order_details_user_enrolls_in_purchased_content_TC25928()
        {
            Assert.IsTrue(accesskeys.Click_Enroll_Order_Detail_Page(browserstr));
        }

        [Test]
        public void E_From_order_details_user_views_history_of_a_transferred_access_key_TC25789()
        {
            accesskeys.Click_Transfer_AccessKeys(browserstr);
            Assert.IsTrue(accesskeys.Check_History_For_TranferedKeys(browserstr));

        }
        [Test]
        public void F_User_refunds_an_access_key_through_Order_Details_TC25940()
        {
            driver.Navigate_to_TrainingHome();
            driver.OrderClick(ObjectRepository.OrdersHoverLink, ObjectRepository.HoverMainLink);
            Assert.IsTrue(accesskeys.Click_Refund(browserstr));

        }



        [Test]
        public void G_User_enables_access_keys_for_a_particular_classroom_course_TC25881()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
         
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr, "Exact phrase");
          
            Contentobj.CostAndSalesTaxEdit_Click();
            Assert.IsTrue(Contentobj.EnableAccessKeysAndEdit_Button());
        }

        [Test]
        public void H_User_defines_access_key_settings_for_a_particular_classroom_course_section_TC25927()
        {
          
            Assert.IsTrue(classroomcourse.CreateClassRoom_CourseSection_EnableAccessKeys(browserstr));
         //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void I_User_buys_multiple_copies_of_a_classroom_section_TC25921()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            string title = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr;
            driver.UserLogin("testuser", browserstr, ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, "password");
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(title);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            ShoppingCartsobj.PurchaseAccessKeysandOpenViewOrder_NewUser_Classroomcourse(browserstr);
            Assert.IsTrue(driver.WaitForElement(ObjectRepository.manageaccesskeys));
        }

        [Test]
        public void J_User_enrolls_himself_in_a_classroom_section_using_an_access_key_TC25923()
        {
            ShoppingCartsobj.Click_ManageAccessKeys();
            Assert.IsTrue(accesskeys.Click_Enroll_Order_Detail_Page_Classroomcourse(browserstr));
        }

        [Test]
        public void K_User_assigns_classroom_section_access_keys_to_users_TC25915()
        {
            ShoppingCartsobj.AssignCourse_AccessKeys_Classroomcourse(browserstr);
            ShoppingCartsobj.EnterUser_ToEnterAccessKey();
            Assert.IsTrue(driver.WaitForElement(By.CssSelector("div[class*='alert-success']")));
        }

        [Test]
        public void L_User_views_PendingRedemption_status_for_a_key_that_has_been_assigned_redeemed_but_not_processed_TC26142()
        {
            accesskeys.Click_Managea_AccessKeys();
            Assert.IsTrue(driver.WaitForElement(By.XPath("//td[contains(.,'Pending Redemption')]")));
        }

        [Test]
        public void M_Admin_enables_access_keys_for_classroom_courses_TC25878()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_training_click();
            TrainingHomeobj.lnk_ContentConfiguration_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Content Settings");
            Assert.IsTrue(accesskeys.enable_Accesskeys_Classroomsection_byadmin());
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.lnk_ContentManagement_click();
            driver.Navigate().Refresh();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Assert.IsTrue(driver.WaitForElement(ObjectRepository.main_login_button));

        }
        [Test]
        public void N_From_Order_Details_User_Prints_Order_25787()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle", browserstr);
            string titled = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr+ "courseTitle";
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.Click_CheckIn();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("testuser", browserstr, ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, "password");
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(titled);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.Click_AddToCart_Accesskey();
            Detailsobj.Click_AddToCart_Accesskey();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            CheckOutobj.FillBillingAddress();
            CheckOutobj.PlaceOrder();
            ShoppingCartsobj.Click_ViewOrder();
            CheckOutobj.ViewDetails();
            Assert.IsTrue(CheckOutobj.Print());
        }

        [Test]
        public void O_From_item_history_user_enrolls_in_purchased_content_25928_25811()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("", browserstr);
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.Click_CheckIn();

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.edit_quantity("10");
            Detailsobj.Click_AddToCart_Accesskey();

            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            ShoppingCartsobj.select_invoice();
            ShoppingCartsobj.placeOrder_invoice();

            // TFS 25811 (Start)
            ShoppingCartsobj.Click_ViewOrder();
            MyResponsibilitiesobj.orders_viewDetails(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
            Assert.IsTrue(MyResponsibilitiesobj.verify_accessKeysOptions(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
            // TFS 25811 (End)

            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_accessKeys();
            Assert.IsTrue(MyResponsibilitiesobj.enroll_in_accessKey_course(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
        }

        [Test]
        public void P_From_item_history_user_transfers_keys_to_another_user_25929()
        {
            //driver.UserLogin("userforregression", browserstr);
            //driver.UserLogin("admin1", browserstr);

            driver.Navigate_to_TrainingHome();
            //    TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_accessKeys();

            Assert.IsTrue(MyResponsibilitiesobj.transfer_accessKeys_to_another_user(ExtractDataExcel.MasterDic_userforreg["Id"] + browserstr + "@tpg.com"));
            //Assert.IsTrue(MyResponsibilitiesobj.transfer_accessKeys_to_another_user("GC0503250925anybrowser"));
        }

        [Test]
        public void Q_From_item_history_user_assigns_key_to_another_user_25926()
        {
            //driver.UserLogin("userforregression", browserstr);
            //driver.UserLogin("admin1", browserstr);

            driver.Navigate_to_TrainingHome();
            //   TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_accessKeys();

            //Assert.IsTrue(MyResponsibilitiesobj.assign_accessKeys_to_another_user("GC0503250925anybrowser"));
            Assert.IsTrue(MyResponsibilitiesobj.assign_accessKeys_to_another_user(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
        }

        [Test]
        public void R_From_item_history_user_downloads_access_keys_25849()
        {
            //driver.UserLogin("userforregression", browserstr);
            //driver.UserLogin("admin1", browserstr);

            driver.Navigate_to_TrainingHome();
            //  TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_accessKeys();

            //Assert.IsTrue(MyResponsibilitiesobj.download_accessKeys("aaa_gencourse"));
            Assert.IsTrue(MyResponsibilitiesobj.download_accessKeys(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
        }

        [Test]
        public void S_User_views_new_design_treatment_for_Transferred_access_keys_in_Item_History_25811()
        {
            //driver.UserLogin("userforregression", browserstr);
            //driver.UserLogin("admin1", browserstr);

            driver.Navigate_to_TrainingHome();
            //   TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_accessKeys();

            //Assert.IsTrue(MyResponsibilitiesobj.verify_transferedAccessKeys("GC0901290029anybrowser"));
            Assert.IsTrue(MyResponsibilitiesobj.verify_transferedAccessKeys(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
        }

        [Test]
        public void T_User_views_status_of_Downloaded_access_keys_in_Item_History_25849()
        {
            //driver.UserLogin("userforregression", browserstr);
            //driver.UserLogin("admin1", browserstr);

            driver.Navigate_to_TrainingHome();
            //   TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_accessKeys();

            //Assert.IsTrue(MyResponsibilitiesobj.verify_downloadedAccessKeys("GC0901290029anybrowser"));
            Assert.IsTrue(MyResponsibilitiesobj.verify_downloadedAccessKeys(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
        }

        [Test]
        public void U_User_withdraws_a_specific_key_from_user_25830_25789()
        {
            //driver.UserLogin("userforregression", browserstr);
            //driver.UserLogin("admin1", browserstr);

            driver.Navigate_to_TrainingHome();
            //    TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_accessKeys();

            Assert.IsTrue(MyResponsibilitiesobj.withdrawAccessKey(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
            //Assert.IsTrue(MyResponsibilitiesobj.verify_downloadedAccessKeys(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));
        }







        [TearDown]
        public void stoptest()
        {

            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
              //  TrainingHomeobj.lnk_ContentManagement_click();
                if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                {
                    driver.Navigate().Refresh();
                }

            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.Quit();
        }
        public void Search()
        {
            SelectElement contentSearch = new SelectElement(driver.GetElement(By.XPath("//select[@id='ddlSearchType']")));
            contentSearch.SelectByText("Exact phrase");
            driver.GetElement(By.XPath("//input[@id='btnSearch']")).ClickWithSpace();
            Thread.Sleep(1000);
            driver.GetElement(By.XPath("//a[contains(@id,'lnkDetails')]")).ClickWithSpace();
            Thread.Sleep(1000);
            driver.GetElement(By.XPath("//input[@type='submit']")).ClickWithSpace();


        }
        private void SwitchToLastWindow()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(1000);
        }

    }

}
