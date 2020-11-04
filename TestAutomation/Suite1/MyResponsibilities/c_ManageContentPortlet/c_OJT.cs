﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   class c_OnlineJobTrainingold : TestBase
    {
        string browserstr = string.Empty;
        public c_OnlineJobTrainingold(string browser)
            : base(browser)
        {
            browserstr = browser+"ojt1";  
        
            // driver.Manage().Window.Maximize();
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //Thread.Sleep(5000);
            //objLogin = new Login(driver);
            classroomcourse = new ClassroomCourse(driver);
            objTrainingHome = new TrainingHomes(driver);
            objTraining = new Training(driver);
            objContentSearch = new ContentSearch(driver);
            objCreate = new Create(driver);
            objContent = new Content(driver);
            objAdminConsole = new AdministrationConsoles(driver);
            objReqTrainingConsole = new RequiredTrainingConsoles(driver);
            objReqTraining = new RequiredTraining(driver);
            approvalrequest = new Approvalrequestobject(driver);
            tasks = new MyTasks(driver); ;
        }
        public bool sectioncreation = false;
        //   private string user;
      
        public Training objTraining;
        public Login objLogin;
        public TrainingHomes objTrainingHome;
        public ContentSearch objContentSearch;
        public Create objCreate;
        public Content objContent;
        public AdministrationConsoles objAdminConsole;
        public RequiredTrainingConsoles objReqTrainingConsole;
        public RequiredTraining objReqTraining;
        public ClassroomCourse classroomcourse;
        public Approvalrequestobject approvalrequest;
        public MyTasks tasks;

      

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

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
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
        [Test]
        public void b72_Create_a_new_OJT_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The item was created.";
            driver.UserLogin("admin", browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);
            onlinejobtraining.buttongoclick();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            string actres = onlinejobtraining.buttoncreateclick(driver);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actres);
        }

        [Test]
        public void b73_Conduct_a_simple_search_for_a_OJT()
        {
        //    driver.UserLogin("admin", browserstr);
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = "1 Items";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                   Assert.IsTrue(onlinejobtraining.buttoncontentsearchclick());
        }
        //[Test]
        public void b73_Conduct_an_advance_search_for_a_OJT()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = "1 Items";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            onlinejobtraining.populatecontentsearchadvance("Exact phrase", ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            Assert.IsTrue(onlinejobtraining.buttoncontentsearchclick());
        }
        public void b74_Narrow_your_search_using_the_search_facets()
        {
            OJT onlinejobtraining = new OJT(driver);
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "1 Items";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            onlinejobtraining.buttoncontentsearchclick();
            int cnt = onlinejobtraining.countallrequestelements();
            driver.GetElement(By.XPath("//a[@id='MainContent_ucSearchTop_CreatedBy']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='cbContent TypeOn-the-Job Training']"));
            driver.GetElement(By.XPath("//input[@id='cbContent TypeOn-the-Job Training']")).ClickWithSpace();
            int cnt1 = onlinejobtraining.countallrequestelements();
            Assert.GreaterOrEqual(cnt, cnt1);
        }
        [Test]
        public void b75_Manage_an_OJT_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The changes were saved.";
            string actualresult = string.Empty;
            classroomcourse.linkmyresponsibilitiesclick(driver);
                 //  Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, "Exact phrase");
            driver.Checkout();
            onlinejobtraining.buttoncourseeditclick();
            onlinejobtraining.populateeditclassroomsummaryform("testchange");
            actualresult = onlinejobtraining.buttonsaveeditojtsaveclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
        }
        [Test]
        public void b76_Create_a_checklist_for_an_OJT_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The item was created.";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                //   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, "Exact phrase");
            driver.Checkout();
            onlinejobtraining.tabcreateandmanagechecklistclick();
            onlinejobtraining.buttonaddnewsectionclick();
            onlinejobtraining.populatechecklist(driver, ExtractDataExcel.MasterDic_ojt["Title"]+browserstr+ Meridian_Common.globalnum, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            string actres =onlinejobtraining.buttonchecklistcreateclick(driver);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actres);
        }
        [Test]
        public void b77_Delete_a_checklist_from_an_OJT_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The checklist was deleted.";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                //   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"]+browserstr, "Exact phrase");
            driver.Checkout();
            onlinejobtraining.tabcreateandmanagechecklistclick();
            onlinejobtraining.linkchecklistclick();
            string actualresult = onlinejobtraining.buttondeletechecklistclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
        }
        [Test]
        public void b78_Create_a_section_for_a_checklist_for_an_OJT_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The item was created.";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);
            onlinejobtraining.buttongoclick();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + 3 + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 3);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, onlinejobtraining.buttoncreateclick(driver)));
            //StringAssert.AreEqualIgnoringCase(expectedresult, onlinejobtraining.buttoncreateclick(driver));
            classroomcourse.linkmyresponsibilitiesclick(driver);
               //    Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"] + 3 + browserstr, "Exact phrase");
            driver.Checkout();
            onlinejobtraining.tabcreateandmanagechecklistclick();
            onlinejobtraining.buttonaddnewsectionclick();
            onlinejobtraining.populatechecklist(driver, ExtractDataExcel.MasterDic_ojt["Title"]+browserstr + Meridian_Common.globalnum, ExtractDataExcel.MasterDic_ojt["Desc"], 5);
            string actres=onlinejobtraining.buttonchecklistcreateclick(driver);
            driver.Checkout();
            driver.ClickEleJs(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_MHyperLink3']"));
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_lbAddSection"));
            driver.ClickEleJs(By.Id("MainContent_MainContent_UC1_lbAddSection"));
           // driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']")).SendKeys("testchecklist");
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']"));
            driver.SwitchTo().DefaultContent();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            driver.gettextofelement(ObjectRepository.sucessmessage);
            Assert.IsTrue(driver.Compareregexstring(expectedresult,actres));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actres);
        }
        [Test]
        public void b79_Delete_a_section_from_a_checklist()
        {
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The checklist was deleted.";
            driver.GetElement(By.Id("MainContent_MainContent_UC1_btnDelete")).ClickWithSpace();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            Thread.Sleep(5000);
            string actualresult = driver.gettextofelement(ObjectRepository.sucessmessage);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
        }
        [Test]
        public void b81_Create_a_question_for_a_checklist_for_an_OJT_item()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);

            OJT onlinejobtraining = new OJT(driver);

            string expectedresult = " The changes were saved.";
         //   Assert.IsTrue(driver.UserLogin("admin"));
            classroomcourse.linkmyresponsibilitiesclick(driver);
            //       Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"] + 3 + browserstr, "Exact phrase");
         driver.Checkout();
            onlinejobtraining.tabcreateandmanagechecklistclick();
            onlinejobtraining.buttonaddnewsectionclick();
            onlinejobtraining.populatechecklist(driver, ExtractDataExcel.MasterDic_ojt["Title"]+browserstr + Meridian_Common.globalnum, ExtractDataExcel.MasterDic_ojt["Desc"], 6);
            onlinejobtraining.buttonchecklistcreateclick(driver);

            ////added code
            driver.Checkout();

            driver.ClickEleJs(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_MHyperLink3']"));
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_UC1_lbAddSection']"));
            driver.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lbAddSection']"));
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']")).SendKeys("testchecklist");
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']"));
            driver.SwitchTo().DefaultContent();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            driver.gettextofelement(ObjectRepository.sucessmessage);
            driver.ClickEleJs(By.XPath("//a[contains(.,'Create New Question')]"));
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//select[@id='MainContent_UC1_fvQuestion_CQ_CHECKLIST_QUESTION_TYPE_ID']"));
            driver.WaitForElement(By.XPath("//select[@id='MainContent_UC1_fvQuestion_CQ_CHECKLIST_QUESTION_TYPE_ID']"));
            driver.select(By.XPath("//select[@id='MainContent_UC1_fvQuestion_CQ_CHECKLIST_QUESTION_TYPE_ID']"),"Checkbox");
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_fvQuestion_btnGo']"));
            driver.WaitForElement(By.XPath("//textarea[@id='MainContent_UC1_fvQuestion_CQL_QUESTION_TITLE']"));
            driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_fvQuestion_CQL_QUESTION_TITLE']")).SendKeys("this is a test");
            driver.GetElement(By.XPath("//textarea[@name='ctl00$MainContent$UC1$fvQuestion$txtAnswerChoices']")).SendKeys("this is a test");
            driver.ClickEleJs(By.Id("MainContent_UC1_btnSave"));
            driver.SwitchTo().DefaultContent();
            driver.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSections_ctrl0_rlvQuestions_ctrl0_lbEditQuestion"));
            Assert.IsTrue(driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSections_ctrl0_rlvQuestions_ctrl0_lbEditQuestion")).Enabled);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage)));
            //StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        }
        [Test]
        public void b82_Delete_a_question_from_a_checklist()
        {
            string expectedresult = " The questions were deleted.";
            driver.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSections_ctrl0_lbAddSection"));
            driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSections_ctrl0_lbAddSection")).ClickWithSpace();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.Id("MainContent_UC1_lbDeleteQuestion"));
            driver.GetElement(By.Id("ctl00_MainContent_UC1_rgQuestion_ctl00_ctl04_chkSelect")).ClickWithSpace();
            driver.GetElement(By.Id("MainContent_UC1_lbDeleteQuestion")).ClickWithSpace();
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().DefaultContent();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            Thread.Sleep(5000);
            string res = driver.gettextofelement(ObjectRepository.sucessmessage);
            driver.Compareregexstring(expectedresult, res);
            //StringAssert.AreEqualIgnoringCase(expectedresult, res);
        }
        [Test]
        public void b84_Publish_a_checklist_for_an_OJT_item()
        {
            OJT onlinejobtraining = new OJT(driver);
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " The checklist was published.";
            classroomcourse.linkmyresponsibilitiesclick(driver);
              //     Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"]+browserstr, "Exact phrase");
            driver.Checkout();
            onlinejobtraining.tabcreateandmanagechecklistclick();
            onlinejobtraining.buttonaddnewsectionclick();
            onlinejobtraining.populatechecklist(driver, ExtractDataExcel.MasterDic_ojt["Title"]+browserstr + Meridian_Common.globalnum, ExtractDataExcel.MasterDic_ojt["Desc"], 4);
            onlinejobtraining.buttonchecklistcreateclick(driver);
            driver.Checkout();
          //  driver.WaitForElement(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_MHyperLink3']"));
           // driver.ClickEleJs(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_MHyperLink3']")) ;
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_lbAddSection"));
            driver.ClickEleJs(By.Id("MainContent_MainContent_UC1_lbAddSection")) ;
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']")).SendKeys("testchecklist");
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']")) ;
            driver.SwitchTo().DefaultContent();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            driver.gettextofelement(ObjectRepository.sucessmessage);
            driver.ClickEleJs(By.XPath("//a[contains(.,'Create New Question')]")) ;
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            driver.WaitForElement(By.XPath("//select[@id='MainContent_UC1_fvQuestion_CQ_CHECKLIST_QUESTION_TYPE_ID']"));
            driver.select(By.XPath("//select[@id='MainContent_UC1_fvQuestion_CQ_CHECKLIST_QUESTION_TYPE_ID']"), "Checkbox");
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_fvQuestion_btnGo']")) ;
            driver.WaitForElement(By.XPath("//textarea[@id='MainContent_UC1_fvQuestion_CQL_QUESTION_TITLE']"));
            driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_fvQuestion_CQL_QUESTION_TITLE']")).SendKeys("this is a test");
            driver.GetElement(By.XPath("//textarea[@name='ctl00$MainContent$UC1$fvQuestion$txtAnswerChoices']")).SendKeys("this is a test");
            driver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']")) ;
            driver.SwitchTo().DefaultContent();
            bool res = driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSections_ctrl0_rlvQuestions_ctrl0_ctl02_0"));
            if (driver.existsElement(By.Id("ctl00_MainContent_UC1_rlvSections_ctrl1_lbAddSection")))
            {
                
                //driver.SelectFrame();
                driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driver.WaitForElement(By.Id("MainContent_UC1_lbDeleteSection"));
                driver.ClickEleJs(By.Id("MainContent_UC1_lbDeleteSection")) ;
                Thread.Sleep(3000);
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(3000);
            }
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_btnPublish"));
            driver.GetElement(By.Id("MainContent_MainContent_UC1_btnPublish")).ClickWithSpace();
            driver.SwitchTo().Alert().Accept();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            Thread.Sleep(5000);
            Assert.IsTrue(res);
            driver.Compareregexstring(expectedresult,driver.gettextofelement(ObjectRepository.sucessmessage));
            //StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        }
        [Test]
        public void b85_Conduct_a_search_for_an_existing_checklist_and_add_it_to_the_OJT()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The items were added.";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            onlinejobtraining.buttongoclick();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + 2 + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 2);
            onlinejobtraining.buttoncreateclick(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
             //      Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"] + 2 + browserstr, "Exact phrase");
            onlinejobtraining.tabcreateandmanagechecklistclick();
            driver.Checkout();
            driver.ClickEleJs(By.Id("MainContent_MainContent_ucTopBar_MLinkButton1"));
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_SearchFor"));
            //driver.GetElement(By.Id("MainContent_MainContent_UC1_SearchFor")).SendKeys(" ");
            driver.ClickEleJs(By.Id("btnSearchChecklists"));
            driver.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgChecklistSearch_ctl00_ctl04_chkSelect"));
            driver.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgChecklistSearch_ctl00_ctl04_chkSelect"));
            driver.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnAdd"));
            driver.WaitForElement(ObjectRepository.sucessmessage);
            driver.Compareregexstring(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
       //     StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        }
        [Test]
        public void b86_Move_a_checklist_from_the_Do_in_Order_or_Do_in_any_order_sections_of_the_OJT()
        {
            driver.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_chkSelect"));
            driver.ClickEleJs(By.Id("MainContent_MainContent_ucTopBar_btnMoveToAnyOrder"));
            driver.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklistsAnyOrder_ctl00_ctl04_chkSelect1"));
            Assert.IsTrue(driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklistsAnyOrder_ctl00_ctl04_chkSelect1")));
        }
        [Test]
        public void b87_Remove_a_checklist_from_an_OJT_item()
        {
            string expectedresult = " The checklists were removed.";
            try
            {
                driver.ScrollToCoordinated("500", "500");
                driver.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklistsAnyOrder_ctl00_ctl04_btnDeleteCheckList2"));
                driver.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklistsAnyOrder_ctl00_ctl04_btnDeleteCheckList2"));
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
                driver.WaitForElement(ObjectRepository.sucessmessage);
                string tex = driver.gettextofelement(ObjectRepository.sucessmessage);
                driver.Compareregexstring(expectedresult, tex);
                //StringAssert.AreEqualIgnoringCase(expectedresult, tex);
            }
            catch (ElementNotVisibleException) { driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink); }
        }
        [Test]
        public void b88_Manage_evaluators_for_an_OJT_item_and_add_an_evaluator()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The changes were saved.";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            onlinejobtraining.buttongoclick();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + 7 + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 7);
            onlinejobtraining.buttoncreateclick(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
              //     Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"] + 7 + browserstr, "Exact phrase");
            onlinejobtraining.tabcreateandmanagechecklistclick();
            driver.Checkout();
            driver.WaitForElement(By.Id("MainContent_MainContent_ucTopBar_MLinkButton1"));
            driver.ClickEleJs(By.Id("MainContent_MainContent_ucTopBar_MLinkButton1"));
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_SearchFor"));
            driver.GetElement(By.Id("MainContent_MainContent_UC1_SearchFor")).SendKeys(" ");
            driver.ClickEleJs(By.Id("btnSearchChecklists"));
            driver.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgChecklistSearch_ctl00_ctl04_chkSelect"));
            driver.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgChecklistSearch_ctl00_ctl04_chkSelect"));
            driver.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnAdd"));
            driver.WaitForElement(ObjectRepository.sucessmessage);
         driver.gettextofelement(ObjectRepository.sucessmessage);
            driver.ClickEleJs(By.XPath("//a[contains(.,'Manage Evaluators')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Add Evaluators')]"));
            driver.WaitForElement(By.Id("MainContent_MainContent_UC1_txtSearchFor"));
            driver.GetElement(By.Id("MainContent_MainContent_UC1_txtSearchFor")).SendKeysWithSpace("site");
            driver.ClickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
            driver.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl04_chkSelect"));
            driver.ClickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl04_chkSelect"));
            driver.GetElement(By.Id("MainContent_MainContent_UC1_Add")).ClickWithSpace();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            Assert.IsTrue(driver.existsElement(By.Id("MainContent_MainContent_UC1_btnRemove")));
           driver.Compareregexstring(expectedresult,driver.gettextofelement(ObjectRepository.sucessmessage));
            //StringAssert.AreEqualIgnoringCase(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
        }
        [Test]
        public void b88_Manage_evaluators_for_an_OJT_item_and_remove_an_evaluator()
        {
            string expectedresult = " The entity(ies) was removed.";
            driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEvaluators_ctl00_ctl04_chkSelect']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_MainContent_UC1_btnRemove']")).ClickWithSpace();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            driver.WaitForElement(ObjectRepository.sucessmessage);
            string tex = driver.gettextofelement(ObjectRepository.sucessmessage);
            driver.Compareregexstring(expectedresult, tex);
            //StringAssert.AreEqualIgnoringCase(expectedresult,tex);
        }
        [Test]
        public void b89_Assign_a_survey_to_an_OJT_item()
        {
            OJT onlinejobtraining = new OJT(driver);
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " Remove";
            classroomcourse.linkmyresponsibilitiesclick(driver);
                //   Trainingsobj.CreateContentButton_Click_New(Locator_Training.OJT_GeneralCourseClick);;
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_ojt["Title"]+browserstr, "Exact phrase");
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            driver.Compareregexstring(expectedresult, driver.gettextofelement(ObjectRepository.sucessmessage));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
        }
    }
}
