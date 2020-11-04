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
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class SultanTest : TestBase
    {
        string browserstr = string.Empty;
        public SultanTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string documenttitle = "Document" + Meridian_Common.globalnum;
        string scormtitle = "SCROM" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle = "TA" + Meridian_Common.globalnum;
        string CertificatrTitle = "Certification" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";

        /*[OneTimeSetUp]
                public void OneTimeSetUp()
                {
                    InitializeBase(driver);
                    //driver.Manage().Window.Maximize();
                    //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
                    //Driver.Instance.UserLogin("userforregression", browserstr);
                    //LoginPage.LoginAs("newuser_2610012701").WithPassword("password").Login();
                    //driver.UserLogin("admin1", browserstr);

                }
          */
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
        // [TearDown]
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

        //Start writing your test here

        [Test, Order(1)]

        public void a01_Bundle_Banner_Course_Info_and_Navigation_57025()
        {
            // Validate Content Bundle Banner
            CommonSection.SearchCatalog("Content Bundle");
            driver.FindElement(By.XPath("//a[contains(@href,'/ContentDetails.aspx?id=0319E365C6E54AEF9F220EBEBF6B1943')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//h1[contains(.,'Content Bundle')]"))); // Content Title
            _test.Log(Status.Info, "Content Bundle Header Found");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='row sm:flex sm:items-center m-0']"))); // Banner
            _test.Log(Status.Info, "Banner is Visible");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='mt-2 sm:mt-0 sm:max-w-xs w-full h-48 md:h-64 flex bg-cover bg-no-repeat bg-center rounded shadow banner-image']"))); // Image
            _test.Log(Status.Info, "Image is visible");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'Bundle')]"))); //Content Type
            _test.Log(Status.Info, "Content Type is visible");


            // Validate Progress Bundle
            CommonSection.SearchCatalog("Progress Bundle No Cost");
            driver.FindElement(By.XPath("//a[contains(.,'Progress Bundle No Cost')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//h1[contains(.,'Progress Bundle No Cost')]"))); // Content Title
            _test.Log(Status.Info, "Progress Bundle Header Found");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='row sm:flex sm:items-center m-0']"))); // Banner
            _test.Log(Status.Info, "Banner visible Found");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='mt-2 sm:mt-0 sm:max-w-xs w-full h-48 md:h-64 flex bg-cover bg-no-repeat bg-center rounded shadow banner-image']"))); // Image
            _test.Log(Status.Info, "Image Found");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'Bundle')]"))); //Content Type
            _test.Log(Status.Info, "Content Type is visible");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Start')]"))); //Start Button visible
            _test.Log(Status.Info, "Start Button is visible");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'Click Start to Continue')]")));
            _test.Log(Status.Info, "Continue button is visible");
            // Verify Progress Bar displays when Content is started
            driver.FindElement(By.XPath("//a[contains(@class,'btn btn-primary btn-lg')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Cancel Access')]")));
            Assert.IsTrue(Driver.Instance.IsElementVisible((By.XPath("//div[contains(@class,'progress bg-grey-light relative mt-4 mb-2 sm:max-w-sm')]"))));
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[@onclick='ViewContent()']"))); // View Content button 
            _test.Log(Status.Info, "Status Bar Check complete");
            // Cancel Bundle access
            driver.FindElement(By.XPath("//a[contains(.,'Cancel Access')]")).Click();
        }

        [Test, Order(2)]
        public void a02_Bundle_Banner_Actions_57026()
        {
            CommonSection.SearchCatalog("Content Bundle");
            driver.FindElement(By.XPath("//a[contains(@href,'/ContentDetails.aspx?id=0319E365C6E54AEF9F220EBEBF6B1943')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,' Save')]"))); // Save button verification
            Assert.IsTrue(Driver.Instance.IsElementVisible((By.XPath("//button[contains(.,'Share')]"))));  //Social network button
            _test.Log(Status.Info, "Save Button and Social Button verification passed");
            // Verify learner can navigate to content details page
            ScrollIntoView();
            driver.FindElement(By.XPath("//a[contains(.,' Edit Content')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//ol[contains(.,'ManageTrainingContent Bundle')]")));
            _test.Log(Status.Info, "User was able to navigate to content details page");
            // Log in with user with no admin rights
            CommonSection.Avatar.Logout();
            LoginPage.LoginAs("sulearner1").WithPassword("password").Login();
            CommonSection.SearchCatalog("Content Bundle");
            driver.FindElement(By.XPath("//a[contains(@href,'/ContentDetails.aspx?id=0319E365C6E54AEF9F220EBEBF6B1943')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[@data-bind='click: updateSavedContent']"))); // Save button verification
            Assert.IsTrue(Driver.Instance.IsElementVisible((By.XPath("//button[contains(.,'Share')]"))));  //Social network button
            Assert.AreEqual(false, Driver.Instance.IsElementVisible(By.XPath("//a[@onclick='ViewContent()']"))); // Verify content is not Visisble
            ScrollIntoView();
            driver.FindElement(By.XPath("//a[@data-bind='click: updateSavedContent']")).Click();  //Click the save button
            ScrollIntoView();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[@class='btn-content-details-save btn transition btn-success border-transparent']"))); //Verify success button for saved content
            ScrollIntoView();
            driver.FindElement(By.XPath("//a[@data-bind='click: updateSavedContent']")).Click();  //Click the save button to undo save
        }

        [Test, Order(3)]
        public void a03_Bundle_AccessRequest_57027_57028()
        {
            CommonSection.Avatar.Logout();
            LoginPage.LoginClick();
            LoginPage.LoginAs("sulearner1").WithPassword("password").Login();
            CommonSection.SearchCatalog("Bundle request Access");
            driver.FindElement(By.XPath("//a[contains(.,'Bundle Request Access')]")).Click();
            ContentDetailsPage.RequestAccess_Curriculum(); // Used this.  May need to create a universal function or copy into bundle
            ContentDetailsPage.RequestAccessHistory_Curriculum(); //TAsk 57028
            ContentDetailsPage.CancelRequestAccess_Curriculum();
        }

        [Test, Order(4)]
        public void a04_View_HistoryTab_57029()
        {
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog("Progress Bundle 1 content");
            driver.FindElement(By.XPath("//a[contains(.,'Progress Bundle 1 content')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@class,'btn btn-primary btn-lg')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Start')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'Document2202161916editcontent')]"))); //Verify content dipslays
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'Document2110093209editcontent')]"))); //Verify content displays
            Driver.Instance.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            driver.FindElement(By.XPath("//*[@id='designatedItems']/ul/li[2]/div/div[3]/div/a")).Click();
            Driver.Instance.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            driver.FindElement(By.XPath("//a[contains(.,'Continue')]")).Click();
            Driver.Instance.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            driver.FindElement(By.XPath("//a[contains(@id,'markCompleteBtn')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@id,'markCompleteBtn')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'History')]")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//li[contains(.,' Started')]"))); //Verify history
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//li[contains(.,' Enrolled')]"))); //Verify history
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'View Certificate')]"))); //Verify history
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[contains(@aria-valuemax,'100')]")));                                                                                                       //div[contains(@aria-valuemax,'100')]                                                                                                        
        }
        [Test, Order(5)]
        public void a05_continue_inProgressContent_57032()
        {
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog("Progress Bundle 1 content");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[contains(.,'Progress Bundle 1 content')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Start')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Start')]")).Click();
            Driver.Instance.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            driver.FindElement(By.XPath("//a[contains(.,'Continue')]")).Click();
            Driver.Instance.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            driver.FindElement(By.XPath("//a[contains(@id,'markCompleteBtn')]")).Click();
            _test.Log(Status.Info, "COntinue In Progress automation successful");
        }

        [Test, Order(5)]
        public void a06_Overview_Bundle_57009()
        {
            CommonSection.SearchCatalog("Content Bundle with Survey ");
            driver.FindElement(By.XPath("//a[contains(.,'Content Bundle with Survey')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//h2[contains(.,'Description')]")));
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[@href='#surveysBlock']"))); // verify Surveys display
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[@href='#equivalenciesBlock']"))); //verify equivelancies display
            //57037 Complete survey and view certificate
        }

        [Test, Order(6)]
        public void a07_Bundle_start_Survey_view_certificate_57037()
        {
            //57037 Complete survey and view certificate
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog("Progress Bundle with Survey ");
            driver.FindElement(By.XPath("//a[@href='/ContentDetails.aspx?id=1C47B75576A640D385CFCCCCFEB03CF1']")).Click();
            driver.FindElement(By.XPath("//a[contains(@class,'btn btn-primary btn-lg')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Start')]")).Click();
            Driver.Instance.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            driver.FindElement(By.XPath("//*[@id='designatedItems']/ul/li[2]/div/div[3]/div/a")).Click();
            Driver.Instance.SelectWindowClose2("Google", Meridian_Common.parentwdw);
            driver.FindElement(By.XPath("//a[contains(@id,'markCompleteBtn')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@id,'markCompleteBtn')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'Almost there! Complete 1 survey(s) to receive your certificate.')]"))); //verify text for Survey
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'Take Survey')]"))); //verify text for Survey
            // Complete Survey
            driver.FindElement(By.XPath("//span[contains(.,'Take Survey')]")).Click();
            Driver.Instance.SwitchWindow("NewSurvey");
            Driver.select(By.Id("sq_100i"), "Yes");
            Driver.clickEleJs(By.XPath("//input[@value='Complete']"));
            Thread.Sleep(1000);
            // Driver.clickEleJs(By.XPath("/html/body/div[2]/div/div/form/div[2]/div[1]/div[2]/div[2]/button"));

            Driver.Instance.SelectWindowClose2("NewSurvey", Meridian_Common.parentwdw);
            //Click On the History tab and verify Certificate is avialable
            driver.FindElement(By.XPath("//a[contains(.,'History')]")).Click();
            driver.WaitForElement(By.XPath("//span[contains(.,'View Certificate')]"));
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'View Certificate')]")));
        }

        [Test, Order(7)]
        public void a08_Bundle_Edit_Content_notAvialable_for_Learner_57313()
        {
            //Seperated this.  All other details in the US are already automated
            //Using Bundle That will always be checked out
            //Log in with a non admin
            CommonSection.Avatar.Logout();
            LoginPage.LoginClick();
            LoginPage.LoginAs("sulearner1").WithPassword("password").Login();
            CommonSection.SearchCatalog("Checked Out For Edit Progress Bundle With Survey");
            driver.FindElement(By.XPath("//a[contains(.,'Checked Out For Edit  Progress Bundle With Survey')]")).Click();
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-warning mb-0']")));


        }

        [Test, Order(8)]
        public void a09_Continue_InProgress_Bundle_57032()
        {

            //Log in with a non admin
            CommonSection.Avatar.Logout();
            LoginPage.LoginClick();
            LoginPage.LoginAs("sulearner2").WithPassword("password").Login();
            CommonSection.SearchCatalog("Progress Bundle With Survey");
            driver.FindElement(By.XPath("//a[contains(.,'Progress Bundle With Survey')]")).Click();
            Thread.Sleep(2000);
            driver.existsElement(By.XPath("//a[contains(.,'Required Content')]"));
            //           Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Required Content Required')]"))); // validate learner lands on Contents tab
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'Continue')]")));
            driver.FindElement(By.XPath("//span[contains(.,'Continue')]")).Click();

        }




        [Test, Order(9)]
        public void a10_Bundle_Access_Period_57033()
        {
            CommonSection.Avatar.Logout();
            _test.Log(Status.Info, "Logout Successful");
            LoginPage.LoginClick();
            LoginPage.LoginAs("sulearner1").WithPassword("password").Login();
            _test.Log(Status.Info, "Login As sulearner1 successful");
            CommonSection.SearchCatalog("Bundle request Access");
            _test.Log(Status.Info, "Search for Content bundle with access period successful");
            driver.FindElement(By.XPath("//a[@href='/ContentDetails.aspx?id=9D886253FAE64A90B2758937A808E047']")).Click();
            _test.Log(Status.Info, "Bundle Click in search results");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'Access ends 3 week(s) after enrollment')]")));
            _test.Log(Status.Info, "Access period description found");
        }

        [Test, Order(10)]
        public void a11_Bundle_Start_content_57313()
        {
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog("Progress Bundle with Survey ");
            driver.FindElement(By.XPath("//a[@href='/ContentDetails.aspx?id=1C47B75576A640D385CFCCCCFEB03CF1']")).Click();
            _test.Log(Status.Info, "Bundle Content Successfully clicked");
            driver.FindElement(By.XPath("//a[contains(@class,'btn btn-primary btn-lg')]")).Click();
            _test.Log(Status.Info, "Content Started");
            driver.FindElement(By.XPath("//a[contains(.,'Start')]")).Click();
            _test.Log(Status.Info, "Learner Started content and closed out modal.");

        }


        [Test, Order(11)]
        public void a12_Bundle_Learner_Views_Reviews_Tab_57571()
        {
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog("c");
            driver.FindElement(By.XPath("//a[@href='/ContentDetails.aspx?id=9D8D1EAF90414DE88B490AE95BDB6663']")).Click();
            driver.FindElement(By.XPath("//a[contains(@class,'btn btn-primary btn-lg')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Enroll')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Start')]")).Click();
            _test.Log(Status.Info, "Learner Started content and closed out modal.");
            driver.FindElement(By.XPath("//a[@aria-controls='reviewsTab']")).Click();
            _test.Log(Status.Info, "Click On Reviews Tab.");
            ContentDetailsPage.Bundle_ReviewsTab.isWriteaReviewButtondisplay();
            _test.Log(Status.Info, "Verify ' Write Review' button is visible");
            ContentDetailsPage.Bundle_ReviewsTab.WriteaReview("This Course ws needed", "This was the best Course taken to Date");
            _test.Log(Status.Info, "Review Succussful");
        }


        [Test, Order(12)]
        public void a13_Bundle_Equivalencies_27165()
        {
            CommonSection.SearchCatalog("bundle with equivalencies ");
            _test.Log(Status.Info, "Bundle Course Found in Catalog");
            driver.FindElement(By.XPath("//a[@href='/ContentDetails.aspx?id=2E6C44161BE248819AD7834EE8F512C0']")).Click();
            _test.Log(Status.Info, "Bundle Content Successfully clicked");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[@href='#equivalenciesBlock']"))); //verify equivelancies display
            driver.FindElement(By.XPath("//a[contains(@href,'#equivalenciesBlock')]")).Click();
            _test.Log(Status.Info, "Successful click of the Equivalencies block");
            driver.FindElement(By.XPath("//h4[contains(.,' Bundle With Equivalencies  is satisfied by')]"));
            _test.Log(Status.Info, "First Equivalencies Found and validated");
            driver.FindElement(By.XPath("//h4[contains(.,' Bundle With Equivalencies  satisfies')]"));
            _test.Log(Status.Info, "Second Equivalencies Found and validated");
        }
        [Test, Order(13)]
        public void a14_Bundle_User_access_Prerequisite_57756()
        {
            CommonSection.CatalogSearchText("//a[@href='/ContentDetails.aspx?id=E7C54702288F48698B92F40F1B3C12D0']");
            _test.Log(Status.Info, "Search for content through Catalog search");
            driver.FindElement(By.XPath("//a[@href='/ContentDetails.aspx?id=E7C54702288F48698B92F40F1B3C12D0']")).Click();
            _test.Log(Status.Info, "Click the content Title");
            Assert.IsTrue(ContentDetailsPage.isprerequisitetableDisplayed());
            _test.Log(Status.Pass, "Verify is the prerquisite table Dispayed");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[contains(@href,'#prereqs-block')]")));
            _test.Log(Status.Pass, "Verify is the prerquisite title Dispayed");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'   $5.00')]")));
            _test.Log(Status.Pass, "Verify is the prerquisite Cost Dispayed");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//span[contains(.,'Not Started')]")));
            _test.Log(Status.Pass, "Verify is the prerquisite Status Dispayed");
            driver.FindElement(By.XPath("//a[@href='/contentdetails.aspx?id=09B33C2474CB48AA9F3C5689ACB3FD95']")).Click();
            _test.Log(Status.Info, "Click the prerequisite Title");
        }


        public void ScrollIntoView()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,-250)", "");
            Thread.Sleep(10000);
        }
    }
}





