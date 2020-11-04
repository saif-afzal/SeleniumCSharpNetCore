using System;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
//using  Selenium2.Meridian.P1.MyResponsibilities.Training.AdministerCommand;
using System.Threading;
using Selenium2.Meridian.Suite;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using static Selenium2.Meridian.P1.MyResponsibilities.Training.AdministerCommand;
using ParallelTesting_Solution2;
using TestAutomation.helper;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class CommonSection:ObjectInit
    {
        private IWebDriver objDriver;
        public CommonSection(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  CreateLinkCommand CreateLink
        {
            get { return new CreateLinkCommand(objDriver); }
        }

        public class CreateLinkCommand
        {
            private IWebDriver objDriver;
            public CreateLinkCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }

            public void SCORM()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/admin/uploadscormcourse.aspx']"));
                //throw new NotImplementedException();
            }

            public void Document()
            {


                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Document')]"));
                //throw new NotImplementedException();
            }

            public void ClickCurriculumns()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Curriculums')]"));
            }

            public void ClassroomCourse()
            {
               
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Classroom Course')]"));

            }

            public void GeneralCourse()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'General Course')]"));
            }

            public void Curriculam()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Curriculums')]"));
            }

            public void Certifications()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.LinkText("Certification"));
            }

            public void OJT()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'On-the-Job Training')]"));
            }

            public void AICC()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.LinkText("AICC"));
               
            }

            public void Bundle()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Bundle')]"));
            }

            public void Subscription()
            {
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Subscription')]"));
            }

            public void Survey()
            {
                objDriver.ClickEleJs(By.XPath("//button[@class='btn btn-primary dropdown-toggle navbar-btn']"));
                //objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '/admin/createsurvey.aspx')]"));
            }

            public void Evaluation()
            {
                //objDriver.GetElement(By.XPath("")).Click();
                objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(@href,'/admin/createevaluation.aspx')]"));
                Thread.Sleep(2000);

            }

            //public void GeneralCourse()
            //{
            //    objDriver.ClickEleJs(By.XPath("//button[@data-toggle='dropdown']"));
            //    // objDriver.FindElement(By.XPath("//a[contains(.,'Document')]"));
            //    objDriver.ClickEleJs(By.XPath("//a[contains(.,'General Course')]"));
            //}
        }

        public  void CreateEvaluationWithPassFail(string v)
        {
           CreateLink.Evaluation();
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            objDriver.ClickEleJs(By.XPath("//span[@class='bootstrap-switch-handle-off bootstrap-switch-default']"));
            //objDriver.ClickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            //objDriver.FindElement(By.Id("MainContent_UC1_DOCUMENT_URL")).SendKeys("www.google.com");
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
            Thread.Sleep(10000);
        }

        public  void CreateEvaluationWithoutPassFail(string v)
        {
           CreateLink.Evaluation();
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            //objDriver.ClickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            //objDriver.FindElement(By.Id("MainContent_UC1_DOCUMENT_URL")).SendKeys("www.google.com");
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
            Thread.Sleep(10000);
        }

        public  LearnerCommand Learner
        {
            get { return new LearnerCommand(objDriver); }
        }

       
        public  ManageCommand Manage
        {
            get { return new ManageCommand(objDriver); }
        }

        public  LearnCommand Learn
        {
            get { return new LearnCommand(objDriver); }
        }

        public  UserdropdownCommand Userdropdown
        {
            get { return new UserdropdownCommand(objDriver); }
        }

        public  void ClickToggleNevigationIcon()
        {
            objDriver.ClickEleJs(By.XPath("//button[@id='responsive-navmenu']"));
        }

        public  AdministerCommand Administer
        {
            get { return new AdministerCommand(objDriver); }
        }



        public  AvatarCommand Avatar
        {
            get { return new AvatarCommand(objDriver); }
        }

        public  HomeCommand Home
        {
            get { return new HomeCommand(objDriver); }
        }

        public  DropdowntoggleCommand Dropdowntoggle
        {
            get
            {
                return new DropdowntoggleCommand(objDriver);
            }
        }

        public  void ClickSearchIcon()
        {
            objDriver.ClickEleJs(By.XPath("//div[@class='navbar-header']//a[@title='Search']"));
        }

        public  void MobileCatalogSearchText(string v)
        {
            objDriver.GetElement(By.XPath("//input[@id='txtSearch']")).Clear();
            objDriver.GetElement(By.XPath("//input[@id='txtSearch']")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//a[@id='btnMobileSiteSearch']"));
        }

        public  ToggledResponsiveMenusCommand ToggledResponsiveMenus { get { return new ToggledResponsiveMenusCommand(objDriver); } }

        public  void Logout()
        {
            objDriver.focusParentWindow();
            Meridian_Common.isadminlogin = false;
            Thread.Sleep(3000);
            if (objDriver.Title != "Login") {
                objDriver.ClickEleJs(By.XPath("//a[@id='ph_avatar']//span[@class='caret']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Logout')]"));
                Thread.Sleep(2000);
                if (objDriver.existsElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")))
                    {
                     objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));
                }
                
                //objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));
                //    objDriver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        
        }

        public  void ClickHelpIcon()
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(.,'Help')]"));
           // objDriver.selectWindow("Help");
        }

        public  void CatalogSearchText(string v)
        {
            objDriver.existsElement(By.Id("txtGlobalSearch"));
            objDriver.GetElement(By.Id("txtGlobalSearch")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//button[contains(@onclick,'return SiteWideSearchRedirect();')]"));
        }

        public  void SearchCatalog(string v)
        {
            objDriver.existsElement(By.Id("txtGlobalSearch"));
            objDriver.GetElement(By.Id("txtGlobalSearch")).Clear();
            objDriver.GetElement(By.Id("txtGlobalSearch")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//button[contains(@onclick,'return SiteWideSearchRedirect();')]"));

        }

        public  bool? NoCareerDevelopmentMenu()
        {
            return objDriver.existsElement(By.XPath("//a[contains(@href, '/professionaldevelopment/professionaldevelopment.aspx')]"));
        }

        public  bool? CareerDevelopmentMenu()
        {
            Thread.Sleep(3000);
            return objDriver.existsElement(By.XPath("//a[contains(@href, '/professionaldevelopment/professionaldevelopment.aspx')]"));
        }

        public  void Transcript()
        {
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.LinkText("Transcript"));
        }

        public  void ClickHome()
        {
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath("//div[@id='utility-nav']/ul/li/a"));
        }

        public  void ClickTranscript()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='utility-nav']/ul/li[3]/a"));
        }

        public  void ClickCurrentTraining()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(@href, '/upcomingtraining.aspx')]"));
        }

        public  void CreteNewCurriculumn(string v)
        {
            CreateLink.Curriculam();
            objDriver.existsElement(By.Id("CNTLCL_TITLE"));
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            objDriver.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeys("Test");
            objDriver.ClickEleJs(By.Id("MainContent_UC1_FormView1_fvCurriculum_CRLM_CSPACE_AVLBLE_1"));
            objDriver.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
        }

        public  void CreteNewDocuemnt(string v)
        {
            CreateLink.Document();
            objDriver.existsElement(By.Id("CNTLCL_TITLE"));
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            objDriver.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeys("Test");
            objDriver.ClickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            objDriver.GetElement(By.Id("MainContent_UC1_DOCUMENT_URL")).SendKeys("www.google.com");
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
        }

        public  void CLickCreateAccount()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='lnkNewAccount']"));
        }

        public  bool? isCreateAccountmenudisplay()
        {
            return objDriver.existsElement(By.XPath("//a[@id='lnkNewAccount']"));
        }

        public  void SelectParentWindow()
        {
            objDriver.focusParentWindow();
        }

        public  void CreteNewScorm(string v)
        {
           CreateLink.SCORM();
            objDriver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            Thread.Sleep(20000);
            objDriver.ScrollToCoordinated("1000", "1000");
            //objDriver.WaitForElement(ObjectRepository.nxt_btn_new);
            //objDriver.ClickEleJs(ObjectRepository.nxt_btn_new);
            objDriver.WaitForElement(By.Id("CNTLCL_TITLE"));
            objDriver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
            objDriver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
            objDriver.Checkin();



        }

        public  void CreateGeneralCourse(string v)
        {
            CreateLink.GeneralCourse();
            objDriver.existsElement(By.Id("CNTLCL_TITLE"));
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            objDriver.ClickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            objDriver.FindElement(By.Id("MainContent_UC1_DOCUMENT_URL")).SendKeys("www.google.com");
            objDriver.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
        }

        public  void ClickShoppingCart()
        {
            objDriver.existsElement(By.XPath("//span[contains(.,'Shopping Cart')]"));
            objDriver.ClickEleJs(By.XPath("//span[contains(.,'Shopping Cart')]"));
        }

        public  void ClickCatalog()
        {
            objDriver.ClickEleJs(By.LinkText("Catalog"));
        }

        public  void ClickLogin_PublicCatalog()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Returning User? Log In')]"));
        }

        public  void CreateNewOJT(string v)
        {
            CreateLink.OJT();
            objDriver.existsElement(By.Id("CNTLCL_TITLE"));
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
        }

        public  bool? isCountincrease_ShopingCart()
        {
            return objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//a[@id='lnkShoppingCart']/span[2]")).Text) >= 1;
        }

        //public  void Completepurchage(string v)
        //{
        //    if (v.StartsWith("CRC"))
        //    {
        //        CommonSection.ClickShoppingCart();
        //        ShoppingCartPage.ClickCheckout_public();
        //        CheckoutPage.UseThisPaymentMethod();
        //        CheckoutPage.AcceptTermsandCondition();
        //        CheckoutPage.PlaceOrder();
        //        Assert.IsTrue(objDriver.comparePartialString("Thank you for your order! Your order has been successfully processed. You will receive an email confirmation shortly.", OrderReceiptPage.SuccessMessage()));
        //        OrderReceiptPage.ViewOrder();
        //        Assert.IsTrue(OrderPage.isPurchasedCotentDisplayed());
        //        OrderPage.Click_Purchased_Content(v + " - " + "Section1");
        //    }
        //    else if (v.StartsWith("bundle"))
        //    {
        //        CommonSection.ClickShoppingCart();
        //        ShoppingCartPage.ClickCheckout_public();
        //        CheckoutPage.UseThisPaymentMethod();
        //        CheckoutPage.AcceptTermsandCondition();
        //        CheckoutPage.PlaceOrder();
        //        Assert.IsTrue(objDriver.comparePartialString("Thank you for your order! Your order has been successfully processed. You will receive an email confirmation shortly.", OrderReceiptPage.SuccessMessage()));
        //        OrderReceiptPage.ViewOrder();
        //        Assert.IsTrue(OrderPage.isPurchasedCotentDisplayed());
        //        OrderPage.Click_Purchased_Content(v);
        //    }
        //    else 
        //    {
        //        CommonSection.ClickShoppingCart();
        //        ShoppingCartPage.ClickCheckout_public();
        //        CheckoutPage.UseThisPaymentMethod();
        //        CheckoutPage.AcceptTermsandCondition();
        //        CheckoutPage.PlaceOrder();
        //        Assert.IsTrue(objDriver.comparePartialString("Thank you for your order! Your order has been successfully processed. You will receive an email confirmation shortly.", OrderReceiptPage.SuccessMessage()));
        //        OrderReceiptPage.ViewOrder();
        //        Assert.IsTrue(OrderPage.isPurchasedCotentDisplayed());
        //        OrderPage.Click_Purchased_Content(v);
        //    }

        //}

        public  bool? cleanshoppingcart()
        {
            ClickShoppingCart();
            Thread.Sleep(5000);
            if (objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//a[@id='lnkShoppingCart']/span[2]")).Text) >= 1)
            {
                do
                {
                    objDriver.ClickEleJs(By.XPath("//input[@value='Remove']"));
                    Thread.Sleep(2000);
                    objDriver.SwitchTo().Alert().Accept();
                    Thread.Sleep(2000);
                }
                while (objDriver.existsElement(By.XPath("//input[@value='Remove']")));
            }
            return true;
        }

        public  void CreteNewDocuemntwithfile(string v)
        {
            CreateLink.Document();
            objDriver.existsElement(By.Id("CNTLCL_TITLE"));
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            objDriver.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeys("Test");
            //objDriver.ClickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            objDriver.navigateAICCfile("Data\\Doc with pdf.pdf", By.Id("AsyncUpload1file0"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
        }

        public  void CreteNewDocuemntwithFile(string v)
        {
            CreateLink.Document();
            objDriver.existsElement(By.Id("CNTLCL_TITLE"));
            objDriver.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            objDriver.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeys("Test");
            objDriver.navigateAICCfile("Data\\Doc with pdf.pdf", By.Id("AsyncUpload1file0"));
            Thread.Sleep(20000);
            //objDriver.GetElement(By.Id("MainContent_UC1_DOCUMENT_URL")).SendKeys("www.google.com");
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }

    public class ToggledResponsiveMenusCommand
    {
        private IWebDriver objDriver;
        public ToggledResponsiveMenusCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }


        public void ClickHelp()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='lnkHelp']"));
        }
    }

    public class DropdowntoggleCommand
    {
        private IWebDriver objDriver;
        public DropdowntoggleCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void SavedContent()
        {
            //throw new NotImplementedException();
            objDriver.existsElement(By.XPath("//a[contains(text(),'Saved Content')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Saved Content')]"));

        }

        public void SF182()
        {
            WebDriverWait wait = new WebDriverWait(objDriver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='utility-nav']/ul/li[4]/a/span")));

            Actions action = new Actions(objDriver);
            action.MoveToElement(element).Perform();
            objDriver.existsElement(By.LinkText("SF-182"));
            objDriver.ClickEleJs(By.LinkText("SF-182"));
            Thread.Sleep(2000);
        }

        public void Transcript()
        {
            objDriver.ClickEleJs(By.XPath("//ul[@id='learn_menu_group-dropdown']//a[contains(text(),'Transcript')]"));
        }

       
    }

    public class HomeCommand
    {
        private IWebDriver objDriver;
        public HomeCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

    }

    public class AvatarCommand
    {
        private IWebDriver objDriver;
        public AvatarCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void Reports()
        {
            objDriver.ClickEleJs(By.XPath(".//*[@id='ph_avatar']/span"));
            objDriver.ClickEleJs(By.XPath("//a[@href='/myreports.aspx']"));

        }

        public void Logout()
        {
            if (objDriver.existsElement(By.XPath("//img[@id='imgAvatar']")))
            {
                objDriver.ClickEleJs(By.XPath("//img[@id='imgAvatar']"));

               // objDriver.ClickEleJs(By.XPath(".//*[@id='user-dropdown']/li[8]/a"));
            }
            else if(objDriver.existsElement(By.XPath("//div[@id='divDefaultAvatar']/span")))
            {
                objDriver.ClickEleJs(By.XPath("//div[@id='divDefaultAvatar']/span"));

                //objDriver.ClickEleJs(By.XPath(".//*[@id='user-dropdown']/li[8]/a"));
            }
            objDriver.ClickEleJs(By.XPath(".//*[@id='user-dropdown']/li[8]/a"));
            Meridian_Common.isadminlogin = false;
            Thread.Sleep(5000);
            if (objDriver.Title != "Login")
            {
               // objDriver.ClickEleJs(By.XPath("//a[@id='ph_avatar']//span[@class='caret']"));
                //objDriver.ClickEleJs(By.XPath("//a[contains(.,'Logout')]"));
                Thread.Sleep(5000);
                objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));
                //    objDriver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                Thread.Sleep(5000);
            }
        }

        public void Account()
        {
            objDriver.ClickEleJs(By.XPath(".//*[@id='ph_avatar']/span"));
            objDriver.ClickEleJs(By.XPath("//ul[@id='user-dropdown']/li/a"));
        }

        public void Requests()
        {
            objDriver.ClickEleJs(By.XPath(".//*[@id='ph_avatar']/span"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Requests')]"));
        }

        public void Orders()
        {
            objDriver.ClickEleJs(By.XPath("//ul[@id='user-dropdown']/li[5]/a"));
        }

        public void Calendar()
        {
            objDriver.ClickEleJs(By.XPath("//ul[@id='user-dropdown']/li[3]/a"));
            Thread.Sleep(5000);
        }
    }

    public class AdministerCommand
    {
        private IWebDriver objDriver;
        public AdministerCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
       
        public PeopleComand People
        {
            get { return new PeopleComand(objDriver); }
        }

        public TrainingManagementComand TrainingManagement
        {
            get { return new TrainingManagementComand(objDriver); }
        }

        public SystemCommand System
        {
            get { return new SystemCommand(objDriver); }
        }

        public class TrainingCommand
        {
            private IWebDriver objDriver;
            public TrainingCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }

            public ContentConfigurationCommand ContentConfiguration { get { return new ContentConfigurationCommand(objDriver); } }

            public void InstructorTool()
            {
                objDriver.ClickEleJs(By.XPath("//a[@href='../Instructors/MyTeachingSchedule.aspx']"));
            }

            public void click_BatchEnrollment_OnlineCourse()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage Enrollment for Online Courses')]"));
            }

            public void searchFor_OnlineContent(string v)
            {
                objDriver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace(v);
                objDriver.ClickEleJs(By.XPath("//input[@value='Search']"));

            }

            public void click_EnrollUserButton()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Enroll Users')]"));
                Thread.Sleep(3000);
            }

            public void searchFor_UsersToBatchEnroll(string v)
            {
                objDriver.GetElement(By.XPath("//input[@id='SEARCH_FOR']")).Clear();
                objDriver.GetElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace(v);
                objDriver.ClickEleJs(By.XPath("//button[@id='btnSearchClientSide']"));
            }

            public void select_UsersToBatchEnroll()
            {
                objDriver.ClickEleJs(By.XPath("//input[@data-index='0']"));
                if (objDriver.IsElementVisible(By.XPath("//input[@data-index='1']")))
                {
                    objDriver.ClickEleJs(By.XPath("//input[@data-index='1']"));
                }
                
            }

            public bool switchToggle_toYes_MarkEnrolleesComplete()
            {
                bool result = false;
                try
                {
                    objDriver.isPresent(By.XPath("//div[@aria-disabled='false']"));
                    objDriver.GetElement(By.XPath("//span[@class='bootstrap-switch-label']")).ClickWithSpace();
                    objDriver.isPresent(By.XPath("//label[@id='lblMarkComplete']/div/div/span"));
                    result = true;
                }
                catch (Exception e)
                {

                }
                return result;

            }

            public bool Click_BatchEnroll_Button_OnlineCourse_WhenToogle_Yes()
            {
                bool result = false;
                try
                {
                    //Verify all elements as per test case.
                    objDriver.IsElementVisible(By.XPath("//h4[contains(.,'Mark Enrollees Complete')]"));
                    objDriver.ClickEleJs(By.XPath("//input[@id='btnEnrollUsers']"));
                    objDriver.IsElementVisible(By.XPath("//label[contains(.,'*Reason for Action')]"));
                    objDriver.IsElementVisible(By.XPath("//textarea[@id='MainContent_UC1_txtReason']"));
                    objDriver.IsElementVisible(By.XPath("//strong[contains(.,'This action is permanent and cannot be undone.')]"));
                    objDriver.IsElementVisible(By.XPath("//input[@id='btnEnrollAndMarkComplete']"));
                    objDriver.IsElementVisible(By.XPath("//button[contains(.,'Cancel')]"));

                    objDriver.ClickEleJs(By.XPath("//input[@id='btnEnrollAndMarkComplete']"));
                    objDriver.IsElementVisible(By.XPath("//span[contains(.,'This field is required.')]"));
                    objDriver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_txtReason']")).SendKeysWithSpace("Testing Batch Enrollment OnLine Course");
                    objDriver.ClickEleJs(By.XPath("//input[@id='btnEnrollAndMarkComplete']"));
                    if (objDriver.IsElementVisible(By.XPath("//td[contains(.,'2')]")))
                    {
                        result = true;
                    } else if (objDriver.IsElementVisible(By.XPath("//td[contains(.,'1')]")))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    
                    
                }
                catch (Exception e)
                {

                }
                return result;


            }

            public bool? Click_BatchEnroll_Button_OnlineCourse_WhenToogle_No()
            {
                bool result = false;
                try
                {
                    //Verify all elements as per test case.

                    objDriver.ClickEleJs(By.XPath("//input[@id='btnEnrollUsers']"));
                    objDriver.IsElementVisible(By.XPath("//td[contains(.,'2')]"));
                    result = true;
                }
                catch (Exception e)
                {

                }
                return result;
            }
        
    }

        public ContentManagementCommand ContentManagement { get { return new ContentManagementCommand(objDriver); } }

        public TrainingCommand Training { get { return new TrainingCommand(objDriver); } }

        public ECommerceCommand ECommerce
        {
            get { return new ECommerceCommand(objDriver); }
        }

        public class TrainingManagementComand
        {
            private IWebDriver objDriver;
            public TrainingManagementComand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }

            public void ClickExternalLearningRequests()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#administer_training_management']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Content Categories')]"));
            }

            public void ContentCategories()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#administer_training_management']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Content Categories')]"));
            }

            public void ContentTag()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#administer_training_management']"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/admin/managetags']"));
            }

            public void ContentTags()
            {
                throw new NotImplementedException();
            }

            public void Certifications()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#administer_training_management']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Certifications')]"));
            }
        }

        public class PeopleComand
        {
            private IWebDriver objDriver;
            public PeopleComand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;

            }

            public void Organizations()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#administer_personnel']"));
                objDriver.ClickEleJs(By.XPath(".//*[@id='administer_people_management']/div/ul/li[6]/a"));

            }
            //changed for 18.1, reached in KI
            public void JobTitles()
            {
                //objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                //objDriver.ClickEleJs(By.XPath("//a[@href='/admin/professionaldevelopment/professionaldevelopment.aspx']"));
                //objDriver.ClickEleJs(By.XPath("//a[@aria-controls='jobtitles']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#admin-console-personnel']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Job Titles')]"));
                Thread.Sleep(5000);
            }

            public void Roles()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '#administer_personnel')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Roles')]"));
                Thread.Sleep(5000);
            }

            public void Instructor()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#administer_personnel']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Instructors')]"));
                Thread.Sleep(2000);
            }

            public void MergeUser()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='#administer_personnel']"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Merge Users')]"));
                Thread.Sleep(2000);
            }

            public void Organizations_Mobile()
            {
                objDriver.ClickEleJs(By.XPath("//ul[@id='mobileMenuAccordion']/li[3]/a"));
                objDriver.ClickEleJs(By.XPath("//ul[@id='mobile-admin-console']/li[2]/a"));
                objDriver.ClickEleJs(By.XPath("//div[@id='mobile_administer_people_management']/div/ul/li[6]/a"));
                Thread.Sleep(5000);
            }
        }

        public class UserdropdownCommand
        {
            private IWebDriver objDriver;
            public UserdropdownCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }

            public void ClickLogout()
            {

                objDriver.ClickEleJs(By.XPath(".//*[@id='ph_avatar']/span"));
                objDriver.ClickEleJs(By.XPath(".//*[@id='user-dropdown']/li[8]/a"));
            }
        }

        public class LearnCommand
        {
            private IWebDriver objDriver;
            public LearnCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }


            public void CareerDevelopment()
            {
                objDriver.ClickEleJs(By.XPath("//div[@id='utility-nav']/ul/li[4]/a/span"));  ////div[@id='utility-nav']/ul/li[4]/a/span
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '/professionaldevelopment/professionaldevelopment.aspx')]"));
                ////a[contains(@href, '/professionaldevelopment/professionaldevelopment.aspx')]
            }

            public void ProfessionalDevelopment()
            {
                throw new NotImplementedException();
            }

            public void Spaces()
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='dropdown-toggle active']"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/collaborationspace.aspx']"));
              //  throw new NotImplementedException();
            }

            public void Home()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Learn')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/learnerpage.aspx']"));

            }

            public void Click()
            {
                objDriver.ClickEleJs(By.XPath("//div[@id='utility-nav']/ul/li[4]/a"));
            }

            public void ClickHome()
            {
                //objDriver.ClickEleJs(By.XPath("//div[@id='utility-nav']/ul/li/a"));
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '/learnerpage.aspx')]"));
                //throw new NotImplementedException();
            }

            public void CurrentTraining()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Learn')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Current Training')]"));
            }

            public void Transcript()
            {
                objDriver.ClickEleJs(By.XPath("//ul[@id='learn_menu_group-dropdown']/li[3]/a"));
            }

            public void SavedContent()
            {
                objDriver.existsElement(By.XPath("//a[contains(text(),'Saved Content')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Saved Content')]"));
            }

            public void SF182()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Learn')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'SF-182')]"));
                Thread.Sleep(2000);
            }
        }

        public class ManageCommand
        {
            private IWebDriver objDriver;
          
            public ManageCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }

            public TrainingCommand TrainingPage
            {
                get { return new TrainingCommand(objDriver); }
            }
            public  CareersCommand Careers
            {
                get { return new CareersCommand(objDriver); }
            }

         
            public void Training()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/admin/myresponsibilities/training.aspx']"));

            }



            public void ProfessionalDevelopment()
            {
                objDriver.hoverLink("Manage", "//a[@href='/admin/professionaldevelopment/professionaldevelopment.aspx']");

            }

            public void People()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/admin/manageusers/usersimplesearch.aspx']"));
            }

            public void Careerstab()
            {
                objDriver.existsElement(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/admin/professionaldevelopment/professionaldevelopment.aspx']"));
                objDriver.ClickEleJs(By.XPath("//a[@aria-controls='careerpaths']"));

            }
            public void CareerMenu()
            {
                Thread.Sleep(3000);
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[@href='/admin/professionaldevelopment/professionaldevelopment.aspx']"));
            }



            public void DevelopmentPlanApprovals()
            {
                throw new NotImplementedException();
            }

            public void Recommendations()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Recommendations')]"));
                objDriver.WaitForElement(By.XPath("//div[2]/div/div/span"));
                
            }

            public void AccessKeys()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Access Keys')]"));
                Thread.Sleep(2000);
            }

            public bool? IsSurveysDisplay()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                return objDriver.existsElement(By.XPath("//a[contains(text(),'Surveys')]"));
                
            }

            public void Gamification()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Gamification')]"));
                Thread.Sleep(2000);
            }

            public void People_Mobile()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '#manageMenu')]"));
                objDriver.ClickEleJs(By.XPath("//div[@id='manageMenu']/ul/li[2]/a"));
                Thread.Sleep(2000);
            }

            public void Catalog_Mobile()
            {
                objDriver.GetElement(By.XPath("//ul[@id='mobileMenuAccordion']/li[5]/a")).Text.Equals("Catalog");
                objDriver.ClickEleJs(By.XPath("//ul[@id='mobileMenuAccordion']/li[5]/a"));
            }

            public void Careers_Mobile()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '#manageMenu')]"));
                objDriver.ClickEleJs(By.XPath("//ul[@class='nav']//a[contains(text(),'Careers')]"));
                Thread.Sleep(2000);
            }

            public void SurveysAndEvaluations()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Surveys and Evaluations')]"));
                Thread.Sleep(2000);
            }
        

            public void ApprovalRequests()
            {
                objDriver.ClickEleJs(By.XPath("//ul[@id='manage_menu_group-dropdown']/li[8]/a"));
           
            }

            public void SF182()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '/base/sf182/manage')]"));
                Thread.Sleep(2000);
            }

            public void Certification()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Certifications')]"));
                Thread.Sleep(2000);
            }

            public void Teams()
            {
                objDriver.ClickEleJs(By.XPath("//ul[@id='manage_menu_group-dropdown']//a[contains(text(),'Team')]"));
            }

            public void Certifications()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(@href, '/certificationsconsole')]"));
            }
        }

        public class LearnerCommand
        {
            private IWebDriver objDriver;
            public LearnerCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }


            public void Transcript()
            {
                objDriver.FindElement(By.XPath("//a[contains(.,'Learn')]")).ClickWithSpace();
                objDriver.FindElement(By.XPath("//a[contains(.,'Transcript')]")).ClickWithSpace();

            }

            public void CurrentTraining()
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Current Training')]"));
                objDriver.WaitForPageLoad(By.LinkText("Find More Training"));
            }
        }
    }

    public class ECommerceCommand
    {
        private IWebDriver objDriver;
        public ECommerceCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public PricingAndCodesCommand PricingAndCodes { get { return new PricingAndCodesCommand(objDriver); } }
    }

    public class PricingAndCodesCommand
    {
        private IWebDriver objDriver;
        public PricingAndCodesCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }


        public void DiscountCodes()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(@href, '#administer_ecommerce')]"));
            objDriver.ClickEleJs(By.XPath("//div[@id='administer_pricing_codes_Header']/h3/a"));
            objDriver.ClickEleJs(By.LinkText("Discount Codes"));
        }
    }

    public class ContentConfigurationCommand
    {
        private IWebDriver objDriver;
        public ContentConfigurationCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void ContentSettings()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//div[@id='administer_content_configuration_Header']//a[contains(text(),'Content Configuration')]"));

            objDriver.ClickEleJs(By.XPath("//div[@id='administer_content_configuration']//a[contains(text(),'Content Settings')]"));
        }

        public void DisplayFormats()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//div[@id='administer_content_configuration_Header']//a[contains(text(),'Content Configuration')]"));

            objDriver.ClickEleJs(By.XPath("//div[@id='administer_content_configuration']//a[contains(text(),'Display Format')]"));
        }
    }

    public class ContentManagementCommand
    {
        private IWebDriver objDriver;
        public ContentManagementCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }


        public void CreditType()
        {
            objDriver.Navigate().Refresh();
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//li[@id='mega-li']/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='administer_content_management_Header']/h3/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='administer_content_management']/div/ul/li[6]/a"));
        }

        public void CreateTest(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Content Management')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Tests')]"));
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_TITLE']")).SendKeysWithSpace(v);
            objDriver.GetElement(By.XPath(" //textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_DESCRIPTION']")).SendKeysWithSpace("test");
            objDriver.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_KEYWORDS']")).SendKeys("test");
            objDriver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_GoPageActionsMenu']"));
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_TITLE']")).SendKeysWithSpace("test");
            objDriver.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_DESCRIPTION']")).SendKeysWithSpace("test");
            objDriver.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_KEYWORDS']")).SendKeysWithSpace("test");
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_NUM_QUESTIONS']")).SendKeysWithSpace("1");
            objDriver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='Return']"));
            objDriver.select(By.XPath("//select[starts-with(@id,'TabMenu_ML_BASE_TAB_EditStructure_ActionsMenu_1_TestQuestionGroups')]"), "New True/False");
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));
            objDriver.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']")).SendKeysWithSpace("Are you Human?");
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TYPE_TRUEFALSE_VALUE_0']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='Return']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='Return']"));
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'"+v+"')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Lock Test')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Publish SCORM 1.2')]"));
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MASTERY_SCORE']")).SendKeysWithSpace("100");
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_QSTNS_PER_PAGE']")).SendKeysWithSpace("1");
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MAX_ATTEMPTS']")).SendKeysWithSpace("2");

            objDriver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            objDriver.ClickEleJs(By.XPath("//div[@id='TabMenuMLBASETABEditLocationContentLocation_1']//input[@type='checkbox']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
            objDriver.ClickEleJs(By.XPath(" //span[contains(text(),'Check In')]"));




        }

        public void AddInstructorToTest()
        {
            objDriver.ClickEleJs(By.XPath("//span[contains(.,'Check Out')]"));
            objDriver.ClickEleJs(By.XPath("//span[contains(.,'Select Instructors')]"));
           // objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_SelectInstructors_ML.BASE.BTN.Search"));
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_SelectInstructors_GoPageActionsMenu"));
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnSearch"));
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_AddUsers_InstructorsDataGrid_ctl02_DataGridItem_USR_LAST_NAME"));
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnAdd"));
            objDriver.ClickEleJs(By.Id("Return"));
            objDriver.ClickEleJs(By.XPath("//span[contains(.,'Check In')]"));


        }
        public void CompleteTest(string v)
        {
            objDriver.SelectWindowClose1("SCORM Debug Window");
            objDriver.SelectWindowClose1("SCORM Debug Window");
            objDriver.SwitchWindow("Meridian Global - Core Domain");
            objDriver.selectWindow("Meridian Global - Core Domain");
            Thread.Sleep(5000);
            objDriver.waitforframe(By.Id("tocFrame"));
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//u[contains(.,'" + v + "')]"));
            objDriver.SwitchTo().DefaultContent();
            objDriver.waitforframe(By.Id("contentFrame"));
            objDriver.ClickEleJs(By.XPath("//input[@id='q1true']"));
            objDriver.ClickEleJs(By.Id("Submit"));
            objDriver.ClickEleJs(By.Id("Submit"));
            objDriver.SwitchTo().DefaultContent();
            objDriver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + "anybrowser");





        }

        public bool? SearchTest(string v)
        {

            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Content Management')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Tests')]"));
            objDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'"+v+"')]"));
            objDriver.ClickEleJs(By.XPath("//div[@class='KVContentWorkflow']//a[contains(text(),'Manage')]"));
            return objDriver.existsElement(By.XPath("//tr[@class='DataGridRows']//td[contains(.,'Administrator, Site')]"));

        }

        public void Tests()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Content Management')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Tests')]"));
        }
    }

    public class CareersCommand
    {
        private IWebDriver objDriver;
        public CareersCommand(IWebDriver objDriver)
        {
            this.objDriver =  objDriver;
        }
        public void Careerstab()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='/admin/professionaldevelopment/professionaldevelopment.aspx']"));
            objDriver.ClickEleJs(By.XPath("//a[@aria-controls='careerpaths']"));
        }

        public void JobTitletab()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Manage')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='/admin/professionaldevelopment/professionaldevelopment.aspx']"));
            objDriver.ClickEleJs(By.Id("jobtitlestab"));
        }
    }


    

    public class TrainingManagementComand
    {
        private IWebDriver objDriver;
        public TrainingManagementComand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

    }

    public class SystemCommand
    {
        private IWebDriver objDriver;
        public SystemCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public SocialNetWorkingSharingCommand SocialNetWorkingSharing
        {
            get { return new SocialNetWorkingSharingCommand(objDriver); }
        }

        public BrandingAndCustomizationCommand BrandingAndCustomization
        {
            get { return new BrandingAndCustomizationCommand(objDriver); }
        }

        public ReportingCommand Reporting
        {
            get { return new ReportingCommand(objDriver); }
        }

        public SystemAdministrationCommand SystemAdministration
        {
            get { return new SystemAdministrationCommand(objDriver); }
        }
        public DomainsandURLSCommand DomainsandURLS
        {
            get { return new DomainsandURLSCommand(objDriver); }
        }

        public EmailManagementCommand EmailManagement
        {
            get { return new EmailManagementCommand(objDriver); }
        }
    }

    public class EmailManagementCommand
    {
        private IWebDriver objDriver;
        public EmailManagementCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void SystemEmailOptions()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.LinkText("Email Management"));
            objDriver.ClickEleJs(By.LinkText("System Email Options"));
        }

        public void SystemEvents()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.LinkText("Email Management"));
            objDriver.ClickEleJs(By.LinkText("System Events"));
        }
    }

    public class DomainsandURLSCommand
    {
        private IWebDriver objDriver;
        public DomainsandURLSCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void Domains()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='administer_domains_url_management_Header']/h3/a"));
            objDriver.ClickEleJs(By.LinkText("Domains"));
        }
    }

    public class SystemAdministrationCommand
    {
        private IWebDriver objDriver;
        public SystemAdministrationCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        private string v;

        public void SystemCertificate(string wdwname)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system_administration']"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'System Certificate')]"));
            objDriver.selectWindow(wdwname);
        }
    }

    public class ReportingCommand
    {

        private IWebDriver objDriver;
        public ReportingCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void ReportConsole()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_report_management']"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Reports Console')]"));
        }
    }

    public class BrandingAndCustomizationCommand
    {
        private IWebDriver objDriver;
        public BrandingAndCustomizationCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void HomepageCustomization()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='administer_branding_customization_Header']/h3/a"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Homepage Customization')]"));
            Thread.Sleep(5000);
        }

        public void CustomBlock()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(@href, '/admin/customblockmanage.aspx')]"));
        }

        public void FieldManagement()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='administer_branding_customization_Header']/h3/a"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Field Management')]"));
            Thread.Sleep(5000);
        }

        public void Themes()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='administer_branding_customization_Header']/h3/a"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Themes')]"));
            Thread.Sleep(5000);
        }
    }

    public class SocialNetWorkingSharingCommand
    {
        private IWebDriver objDriver;
        public SocialNetWorkingSharingCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void SocialSharing_Facebook()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Administer')]"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_system']"));
            objDriver.ClickEleJs(By.XPath(".//*[@id='administer_branding_customization_Header']/h3/a"));
            objDriver.ClickEleJs(By.XPath("//a[@href='#administer_social_networking']"));
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'Facebook')]"));
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath("//label[contains(.,'True')]"));
            objDriver.ClickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }

        
    }
}