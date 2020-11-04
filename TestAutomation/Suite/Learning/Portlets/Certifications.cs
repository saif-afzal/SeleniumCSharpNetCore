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
using System.Configuration;


namespace Selenium2.Meridian.Suite.CommonTest
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Certifications : TestBase
    {
        string browserstr = string.Empty;
        string generalCoursePaidCourseTitle = string.Empty;
        public Certifications(string browser)
            : base(browser)
        {
            browserstr = browser+"SC";
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("userforregression", browserstr);
            //driver.UserLogin("admin1", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.MyResponsiblities_click();
            //MyResponsibilitiesobj.Click_People();
            //ManageUsersobj.Click_CreateNewUserLink();
            //CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            //CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            //CreateNewAccountobj.Click_CreateAccount();
            //ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr);
            //ManageUsersobj.Click_SearchUser();
            //driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
            // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         //   driver.UserLogin("custom", browserstr, "change_" + ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "tochange", ExtractDataExcel.MasterDic_newuser["Password"]);
            driver.UserLogin("admin1", browserstr);
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
       
        public string A_Create_General_Paid_Course()
        {
                GeneralCourse generalcourse = new GeneralCourse(driver);
                //driver.UserLogin("admin", browserstr);
                generalcourse.linkmyresponsibilitiesclick();
                generalcourse.tabcontentmanagementclick();
                ContentSearchobj.NewContent("General Course");
                Createobj.FillGeneralCoursePage("courseTitle", browserstr);
                generalCoursePaidCourseTitle = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle";
                Contentobj.CostAndSalesTaxEdit_Click();
                //driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeysWithSpace("50.00");
                //driver.FindElement(By.XPath("//input[@value='Save']")).ClickWithSpace();
                //driver.FindElement(By.XPath("//input[@value='Back']")).ClickWithSpace();
                Contentobj.EnableAccessKeysAndEdit_Button();
                Contentobj.Click_CheckIn();

                return generalCoursePaidCourseTitle;
        }
        [Test]
        public void B_View_ShoppingCart_Order_History_25514()
        {
            StringAssert.AreEqualIgnoringCase(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle",A_Create_General_Paid_Course());
        }
        [Test]
        public void C_User_Views_Total_Item_Count_24761_24762()
        {
            string title = generalCoursePaidCourseTitle;
            string expectedresult = "The quantity was updated. NOTE: Costs may have been refreshed in the shopping cart.";
            string expectedresult1 = "Some or all of the values entered for the quantity were invalid. All products have been restored to the original values.";
            string expectedresult2 = (title + " was removed from your cart.");
            string actualresult = string.Empty;
            string actualresult1 = string.Empty;
            string actualresult2 = string.Empty;
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(title);
            //BrowseTrainingCatalogobj.Set_SearchType("Exact phrase");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            driver.WaitForElement(By.XPath("//input[@class='btn btn-primary']"));
            driver.FindElement(By.XPath("//input[@class='btn btn-primary']")).Click();
            Thread.Sleep(3000);
            TrainingHomeobj.ShoppingCartClick();
            Assert.IsTrue(driver.WaitForElement(By.XPath("//a[contains(.,'"+ title +"')]")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@size='1']")));
            actualresult = ShoppingCartsobj.Click_Update_Content_Amount("99", title);
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            //Verify content and cart Amount updates to reflect total. 
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            Thread.Sleep(1000);
            Assert.IsTrue(driver.WaitForElement(By.XPath("//input[@value='99']")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//p[contains(.,'$99.00')]")));
            Assert.IsTrue(driver.WaitForElement(By.XPath("//div[contains(@class,'alert alert-success')]")));
            //Verify Error message when Qty = -
            //actualresult1 = ShoppingCartsobj.Click_Update_Content_Amount("-9", title);
            //StringAssert.AreEqualIgnoringCase(expectedresult1, actualresult1);
            //Verify Item is removed from cart when Qty = 0 
            actualresult2 = ShoppingCartsobj.Click_Update_Content_Amount("0", title);
            StringAssert.AreEqualIgnoringCase(expectedresult2, actualresult2);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }
        [Test]
        public void D_Use_ShippingAddress_for_BillingAddress_25491()
        {
            string title = generalCoursePaidCourseTitle;
            string expectedresult = "The quantity was updated. NOTE: Costs may have been refreshed in the shopping cart.";
            string expectedresult1 = "Some or all of the values entered for the quantity were invalid. All products have been restored to the original values.";
            string expectedresult2 = (title + " was removed from your cart.");
            string actualresult = string.Empty;
            string actualresult1 = string.Empty;
            string actualresult2 = string.Empty;
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle");
            //BrowseTrainingCatalogobj.Set_SearchType("Exact phrase");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            driver.WaitForElement(By.XPath("//input[@class='btn btn-primary']"));
            driver.FindElement(By.XPath("//input[@class='btn btn-primary']")).Click();
            Thread.Sleep(3000);
            TrainingHomeobj.Click_MyAccount();
            TrainingHomeobj.lnk_Ecommerce_click();
            // Get the current window handle so you can switch back later.
            string currentHandle = driver.CurrentWindowHandle;
            IWebElement element = driver.FindElement(By.XPath("//a[contains(.,'Edit Shipping Information')]"));
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            //driver.SwitchTo().Window(); 
            ClickAndSwitchWindow(element, driver);
            driver.waitforframe(By.ClassName("k-content-frame"));
            driver.GetElement(By.XPath("//input[@id='SI_SHIP_TO_NAME']")).SendKeysWithSpace("Test Account");
            driver.GetElement(By.XPath("//input[@id='SI_SHIP_TO_STREET']")).SendKeysWithSpace("2003 Edmund Halley Drive");
            driver.GetElement(By.XPath("//input[@id='SI_SHIP_TO_CITY']")).SendKeysWithSpace("Reston");
            driver.GetElement(By.XPath("//select[@id='SI_SHIP_TO_COUNTRY_ID']")).ClickWithSpace();
            driver.GetElement(By.XPath("//option[@value='US']")).ClickWithSpace();
            driver.GetElement(By.XPath("//select[@id='SI_SHIP_TO_STATE_ID']")).ClickWithSpace();
            driver.GetElement(By.XPath("//option[contains(.,'Virginia')]")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@id='SI_SHIP_TO_ZIP']")).SendKeysWithSpace("24141");
            driver.GetElement(By.XPath("//input[@id='SI_SHIP_TO_PHONE']")).SendKeysWithSpace("6097126297");
            driver.GetElement(By.XPath("//input[@value='Save']")).ClickWithSpace();
            driver.SwitchtoDefaultContent();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void E_User_purchase_repurchase_physical_digital_content_25546()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click(); 
            TrainingHomeobj.LinkContentSearchtclick(); 
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle1", browserstr);
            string title = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle1";
            Contentobj.CostAndSalesTaxEdit_Click();
//            Contentobj.AddCostToGeneralCourse();
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.Click_CheckIn();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.lnk_ContentManagement_click();
            //TrainingHomeobj.Click_Products();
            AdminstrationConsoleobj.Click_OpenItemLink("Products");
            //SwitchToLastWindow();
            Productsobj.Click_CreateNewGoTo();
            Productsobj.Populate_Product("WithCost", browserstr);
            string producttitle = ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + "WithCost";
            Productsobj.btncreateclick();
            Productsobj.updatecost();
            Productsobj.checkinproduct();
            driver.Navigate_to_TrainingHome();
            //driver.Close();
            //SwitchToLastWindow();
            TrainingHomeobj.close_systemOptions();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(title);
            //BrowseTrainingCatalogobj.Set_SearchType("Exact phrase");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            detailspage.Click_AddToCart_Accesskey();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(producttitle);
            //BrowseTrainingCatalogobj.Set_SearchType("Exact phrase");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            detailspage.Click_AddToCart_Physical_Content();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
//            CheckOutobj.ShippingAddress();
//            ShoppingCartsobj.Click_ShipToThisAddress();
//            CheckOutobj.Click_CreditCard();
//            CheckOutobj.CreditCartInformation();
//            CheckOutobj.Click_UseThisPaymentMethod();
//            CheckOutobj.SameAsBillingAddress();
 //          Assert.IsTrue( CheckOutobj.PlaceOrder()); 
           
        }
        [Test]
        public void F_c_User_View_Order_History_US1913()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle2", browserstr);
            string title = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle2";
            Contentobj.CostAndSalesTaxEdit_Click();
         //   Contentobj.AddCostToGeneralCourse();
            Contentobj.Click_CheckIn();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(title);
            //BrowseTrainingCatalogobj.Set_SearchType("Exact phrase");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            detailspage.Click_AddToCart();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.FillBillingAddress();
            CheckOutobj.Click_UseThisPaymentMethod();
         
            CheckOutobj.PlaceOrder();
            ShoppingCartsobj.Click_ViewOrder();
            Assert.IsTrue(driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + "')]")));
            Assert.IsTrue(driver.WaitForElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgOrderHistory_ctl00__0']/td[1]")));
            Assert.IsTrue(driver.WaitForElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgOrderHistory_ctl00__0']/td[2]")));
            Assert.IsTrue(driver.WaitForElement(By.Id("MainContent_UC1_lnkRedeemAccessKeys")));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                
        }
        [Test]
        public void G_d_User_add_shippingaddress_firsttime()
        {
            driver.UserLogin("userforregression", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.MyResponsiblities_click();
            //MyResponsibilitiesobj.Click_People();
            //ManageUsersobj.Click_CreateNewUserLink();
            //CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            //CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            //CreateNewAccountobj.Click_CreateAccount();
            //ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr, ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr);
            //ManageUsersobj.Click_SearchUser();
            //driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, ManageUsersobj.passwordcreationnewuser(), browserstr);
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            string producttitle = ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + "WithCost";
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(producttitle);
            //BrowseTrainingCatalogobj.Set_SearchType("Exact phrase");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            detailspage.Click_AddToCart_Physical_Content();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            Assert.IsTrue(CheckOutobj.ShippingAddress());
            Assert.IsTrue(ShoppingCartsobj.Click_ShipToThisAddress());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         }
        [Test] 
        public void H_e_Check_Saletax_Calculation_In_Shoppingcart_US2010()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle3", browserstr);
            string title = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle3";
            Contentobj.CostAndSalesTaxEdit_Click();
            //Contentobj.AddCostToGeneralCourse();
            Contentobj.Click_CheckIn();
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(title);
          //  BrowseTrainingCatalogobj.Set_SearchType("Exact phrase");
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            detailspage.Click_AddToCart();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_CurrencyandTaxes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Sales Tax Options");
            ShoppingCartsobj.Enable_Avalara_Saletax();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            // write function for saltetax calculation.
            CheckOutobj.FillBillingAddress();
            CheckOutobj.Click_UseThisPaymentMethod();
            
            string actres = driver.gettextofelement(By.XPath("//p[@class='total']"));
            int actres1 = driver.getintegerfromstring(actres.ToString());
            Assert.GreaterOrEqual(actres1,1);
            //Assert.AreEqual(78, actres1);
            //TrainingHomeobj.MyResponsiblities_click();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void I_Purchase_Content_Validate_In_Current_Training()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle4", browserstr);
            string title = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle4";
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.AddCostToGeneralCourse();
            Contentobj.Click_CheckIn();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
           // driver.UserLogin("testuser", browserstr, ExtractDataExcel.MasterDic_newuser["Id"] + browserstr, "password");
            
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(title);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            detailspage.Click_AddToCart();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.FillBillingAddress();
            CheckOutobj.Click_UseThisPaymentMethod();
           
            CheckOutobj.PlaceOrder();
            ShoppingCartsobj.Click_ViewOrder();
            TrainingHomeobj.Click_TrainingHome();
            Assert.IsTrue(driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + "')]")));
               driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }

        [Test]
        public void J_User_Steps_Through_Shipping_Address_Payment_Method_And_Order_Summary_All_In_One_Page_25259()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle", browserstr);
            string title = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle";
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.Click_CheckIn();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.lnk_ContentManagement_click();
            TrainingHomeobj.Click_Products();
            SwitchToLastWindow();
            Productsobj.Click_CreateNewGoTo();
            Productsobj.Populate_Product("WithCost", browserstr);
            string producttitle = ExtractDataExcel.MasterDic_product["Title"] + browserstr + 1 + "WithCost";
            Productsobj.btncreateclick();
            Productsobj.updatecost();
            Productsobj.checkinproduct();
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.close_systemOptions();
            //TrainingHomeobj.Click_Training();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(title);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.Click_AddToCart_Accesskey();
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(producttitle);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            detailspage.Click_AddToCart_Physical_Content();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.ShippingAddress();
            ShoppingCartsobj.Click_ShipToThisAddress();
            CheckOutobj.Click_UseThisPaymentMethod();
           // CheckOutobj.FillBillingAddress();
            Assert.IsTrue(CheckOutobj.PlaceOrder());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // logout 
        }

        [Test]
        public void K_User_Changes_Payment_Method_During_CheckOut_Process_25554()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle5", browserstr);
            string titlea = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr +"courseTitle5";
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.Click_CheckIn();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(titlea);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.Click_AddToCart_Accesskey();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            string currentHandle = driver.CurrentWindowHandle;
            IWebElement element = driver.FindElement(By.XPath("//a[contains(@id,'MainContent_UC1_lnkPaymentEdit')]"));
            PopupWindowFinder finder = new PopupWindowFinder(driver);
            ClickAndSwitchWindow(element, driver);
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            // driver.SelectFrame(By.XPath("//input[@id='MainContent_UC1_PMTPAYFLOWPROCREDITCARD']"));

            driver.FindElement(By.XPath("//input[@id='MainContent_UC1_PMTPAYFLOWPROCREDITCARD']")).Click();
            driver.select(By.Id("PI_CREDIT_CARD_TYPE"), "Visa");
            CheckOutobj.CreditCartInformation();
            CheckOutobj.CreditCardInfoSave();
            CheckOutobj.FillBillingAddress();
            driver.SwitchTo().DefaultContent();
            //  SwitchToLastWindow();
            Assert.IsTrue(CheckOutobj.PlaceOrder());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void L_User_Views_Purchase_Receipt_After_Completing_Checkout_24772()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle6", browserstr);
            string titleb = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "courseTitle6";
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.Click_CheckIn();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(titleb);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.Click_AddToCart_Accesskey();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            CheckOutobj.FillBillingAddress();
            CheckOutobj.PlaceOrder();
            Assert.IsTrue(ShoppingCartsobj.Click_ViewOrder());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void M_User_Purchases_Multiple_Copies_Of_A_Piece_Of_Content_25517()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            TrainingHomeobj.LinkContentSearchtclick();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("courseTitle7", browserstr);
            string titlec = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr +  "courseTitle7";
            Contentobj.CostAndSalesTaxEdit_Click();
            Contentobj.EnableAccessKeysAndEdit_Button();
            Contentobj.Click_CheckIn();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            BrowseTrainingCatalogobj.Populate_SearchText(titlec);
            BrowseTrainingCatalogobj.Click_Search();
            SearchResultsobj.Content_Click();
            Detailsobj.Click_AddToCart_Accesskey();
            Detailsobj.Click_AddToCart_Accesskey();
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            CheckOutobj.FillBillingAddress();
            Assert.IsTrue(CheckOutobj.PlaceOrder());
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
                //TrainingHomeobj.lnk_TrainingManagement_click();
                //TrainingHomeobj.lnk_SystemOptions_click();

          }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
//            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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

        public static string ClickAndSwitchWindow(IWebElement elementToBeClicked,IWebDriver driver, int timer = 2000)
        {
            System.Collections.Generic.List<string> previousHandles = new
            System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> currentHandles = new
            System.Collections.Generic.List<string>();
            previousHandles.AddRange(driver.WindowHandles);
            elementToBeClicked.Click();

            Thread.Sleep(timer);
            for (int i = 0; i < 20; i++)
            {
                currentHandles.Clear();
                currentHandles.AddRange(driver.WindowHandles);
                foreach (string s in previousHandles)
                {
                    currentHandles.RemoveAll(p => p == s);
                }
                if (currentHandles.Count == 1)
                {
                    driver.SwitchTo().Window(currentHandles[0]);
                    Thread.Sleep(100);
                    return currentHandles[0];
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
            return null;
        }

        private void SwitchToLastWindow()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(1000);
        }

    }

}
