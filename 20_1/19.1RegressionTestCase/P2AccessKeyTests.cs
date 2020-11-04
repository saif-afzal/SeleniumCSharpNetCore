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
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P2AccessKeyTests : TestBase
    {
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;


        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPath" + Meridian_Common.globalnum;


        public P2AccessKeyTests(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
        }
        string generalcourse = "GeneralCourse" + Meridian_Common.globalnum;
        string bundlecourse = "GeneralCourse" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        bool TC_10574 = false;
        bool TC_10823 = false;
        bool TC_10879 = false;
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

      

        //[Test, Order(2)]
        //public void A02_Test_Access_Keys_with_Curriculum_34153()
        //{
        //    #region Create General Course and Curriculum With Cost and Access keys Enabled
        //    CommonSection.CreateLink.GeneralCourse();
        //    _test.Log(Status.Info, "Creating a Paid General Course");
        //    GeneralCoursePage.CreateGeneralCourse(generalcourse + "Curr", "Test General Course");
        //    GeneralCoursePage.setCost("5");
        //    DocumentPage.ClickButton_CheckIn();
        //    _test.Log(Status.Info, "Paid general course created");
        //    CommonSection.Learn.Home();
        //    CommonSection.CreateLink.Curriculam();
        //    _test.Log(Status.Info, "Creating a Paid Curriculum Course with Access Keys");
        //    objCreate.FillCurriculumPage("AK", browserstr);
        //    GeneralCoursePage.setCost("5");
        //    _test.Log(Status.Info, "Cost Has Been Set");
        //    BundlesPage.enableAccessKeys();
        //    _test.Log(Status.Info, "Access Keys Enabled");
        //    CurriculumsPage.CurriculumContent.addContentIntoCurriculam(generalcourse + "Curr");
        //    _test.Log(Status.Info, "Adding Paid General Course into Curriculum");
        //    DocumentPage.ClickButton_CheckIn();

        //    #endregion
        //    #region Purchase Access Keys for Curriculam
        //    ShoppingCarts.purchaseAccessKeys("Curriculam", Variables.curriculumTitle + browserstr + "AK");
        //    ShoppingCarts.completePurchaseProcess();
        //    _test.Log(Status.Info, "Keys has been purchased from shopping cart");
        //    CommonSection.Manage.Training();
        //    CommonSection.Manage.AccessKeys();
        //    AccessKeysPage.searchForContent(Variables.curriculumTitle + browserstr + "AK");
        //    AccessKeysPage.assignKeysToLearner("ershivam.iimt@ggmail.com");
        //    _test.Log(Status.Info, "Keys has been assigned to learner");
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //    #endregion
        //    LoginPage.LoginAs("ssuser1").WithPassword("password").Login();
        //    Assert.IsTrue(CurriculumsPage.searchforCurriculam(Variables.curriculumTitle + browserstr + "AK", generalcourse + "Curr"));
        //    _test.Log(Status.Info, "General Course Displaying inside Curriculuam, Assertion Pass");
        //    Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//input[@value='Enroll']")));
        //    TC_10823 = true;
        //    _test.Log(Status.Info, "Cost of General Course Override, Assertion Pass");
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //    LoginPage.LoginAs("").WithPassword("").Login();

        //}

    

        [Test, Order(4), Category("AutomatedP1")]
        public void A04_Test_AccessKeys_Accordian_For_ClassroomCourse_35813()
        {
            #region Create Classroom Course with Cost and Access Keys
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            _test.Log(Status.Info, "Filled all required information and submit the classroom creation page");
            classroomcourse.buttonsaveclick();
            _test.Log(Status.Pass, "Verify Classroom Course saved");
            Assert.IsTrue(Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_MainContent_ucAccessCodes_lnkEdit']")));
            _test.Log(Status.Pass, "Access Keys According displaying for classroom course");
            Assert.IsTrue(ClassroomCoursePage.enableAccessKeys());
            _test.Log(Status.Info, "Access Keys Enabled for classroom course");
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            #endregion

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Pass, "Enter Section Title and Capacity");
            ManageClassroomCoursePage.SelectWaitListasYes();
            Assert.IsTrue(ManageClassroomCoursePage.setAvailable_for_Purchase());
            _test.Log(Status.Pass, "Availability for purchase detail for access keys has been set");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Pass, "New Section Created");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Classroom Course Section Created With Access Keys Enabled");

        }

        [Test, Order(5), Category("AutomatedP11")]

        public void A05_ManageACurriculum_10823()

        {
            CommonSection.CreateLink.Curriculam();
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            objCreate.FillCurriculumPage("", "editcontent");         
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(Variables.curriculumTitle + "editcontent");
            SearchResultsPage.ClickCourseTitle(Variables.curriculumTitle + "editcontent");
            CurriculumsPage.Edit_Click(driver);
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            SummaryPage.ClickSavebutton();
            //   Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            TC_10823 = true;

        }



        [Test, Order(6), Category("AutomatedP1")]
        public void A06_Test_AccessKeys_Accordian_For_Curriculam_35815()
        {
   
            Assert.IsTrue(TC_10823); // This test case has been already covered in Test Case 34153
            _test.Log(Status.Pass, "Access Keys Accordian Has been verfiied for curriculam");

        }
        [Test, Order(7), Category("AutomatedP1")]
        //Editing existing certification
        public void A07_ManageACertification_10879()
        {
            CommonSection.CreateLink.Certifications();
            // objCreate.FillCertificationPageByExcel(driver);
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            objCreate.FillCertificationPage("editcontent");
            CommonSection.Manage.Training();
            TrainingPage.SearchRecord(Variables.certTitle + "editcontent");
            SearchResultsPage.ClickCourseTitle(Variables.certTitle + "editcontent");
            CurriculumsPage.Edit_Click(driver);
            //  Assert.IsTrue(Driver.checkTagsonContentCreationPage(true));
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            SummaryPage.ClickSavebutton();
            //  Assert.IsTrue(Driver.checkContentTagsOnDetailsPage());
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            StringAssert.AreEqualIgnoringCase(tagname, s);
            _test.Log(Status.Info, "Assertion Pass as Searching for Tag Successfully Done");
            TC_10879 = true;


        }

        [Test, Order(8), Category("AutomatedP1")]
        public void A08_Test_AccessKeys_Accordian_For_Certification_35816()
        {
            Assert.IsTrue(TC_10879); // This test case has been already covered in Test Case 34152
            _test.Log(Status.Pass, "Access Keys Accordian Has been verfiied for certification");

        }

        [Test, Order(9), Category("AutomatedP1")]
        public void A09_Test_AccessKeys_Accordian_For_GeneralCourse_35817()
        {
            CommonSection.Learn.Home();
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Creating a Paid General Course");
            GeneralCoursePage.CreateGeneralCourse(generalcourse + "AK", "Test General Course");
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            Assert.IsTrue(ClassroomCoursePage.enableAccessKeys());
            _test.Log(Status.Info, "Access Keys Accordian Has been verfiied for General Course");

        }

        [Test, Order(10), Category("AutomatedP1")]
        public void A10_Test_AccessKeys_Accordian_For_Scorm_35818()
        {
            CommonSection.Learn.Home();
            CommonSection.CreteNewScorm(scormtitle + "AK");
            _test.Log(Status.Info, "New Scorm Course Created");
            GeneralCoursePage.setCost("5");
            _test.Log(Status.Info, "Cost Has Been Set");
            Assert.IsTrue(ClassroomCoursePage.enableAccessKeys());
            _test.Log(Status.Info, "Access Keys Accordian Has been verfiied for Scorm Course");


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
                driver.Navigate().Refresh();
            }
        }
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }




    }

    public class AccessKeysPage
    {
        public static ConentCommand Conent { get { return new ConentCommand(); } }

        public static void assignKeysToLearner(string v)
        {
            Driver.clickEleJs(By.XPath("//table[1]/tbody[1]/tr[1]/td[4]/div[1]/a[1]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_txtEmail1']")).SendKeysWithSpace(v);
            IWebElement webElement = Driver.Instance.FindElement(By.XPath("//a[@id='MainContent_UC1_btnCancel']"));
            webElement.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//input[@value='Assign']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }

        public static void searchForContent(string v)
        {
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_txtSearch']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));
            Thread.Sleep(2000);
        }

        public static void ClickViewDetails(string v)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]/following::a[1]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]/following::a[1]"));
        }

        public static EnableAccessKeyCommand EnableAccessKey(string v)
        {
            return new EnableAccessKeyCommand(v);
        }

        internal static void Enroll()
        {
            Driver.clickEleJs(By.XPath("//tr[@id='ctl00_MainContent_UC1_rgManageAccess_ctl00__0']/td[4]/div/button/span"));
            Driver.clickEleJs(By.Id("ctl00_MainContent_UC1_rgManageAccess_ctl00_ctl04_btnEnroll"));
        }
    }

    public class EnableAccessKeyCommand
    {
        private string v;

        public EnableAccessKeyCommand(string v)
        {
            this.v = v;
        }

        internal void Save()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_CNT_ENABLE_ACCESS_CODE_0"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }
    }

    public class ConentCommand
    {
        public bool? ContentFormat()
        {
            return Driver.GetElement(By.XPath("//tr/td/p")).Displayed;
        }
    }
}
