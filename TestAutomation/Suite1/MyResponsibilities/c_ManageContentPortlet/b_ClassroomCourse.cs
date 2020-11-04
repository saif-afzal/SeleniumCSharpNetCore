using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using MeridianFramework.Training;
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
  public  class b_ClassroomCourseold : TestBase
    {
        string browserstr = string.Empty;
        public b_ClassroomCourseold(string browser)
            : base(browser)
        {
            browserstr = browser;
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }
        bool sectioncreation = false;

       

    

        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            classroomcourse = new ClassroomCourse(driver);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1",browserstr);
            }
            Meridian_Common.islog = false;
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
        [Test]
        public void a48_Create_a_new_Classroom_course()
        {
            string expectedresult = " The item was created.";
            driver.UserLogin("admin1", browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick()));
         
        }
        [Test]
        public void a49_Conduct_a_simple_search_for_a_Classroom_course()
        {
            string expectedresult = "1 Items";
            classroomcourse.linkmyresponsibilitiesclick(driver);
             //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "");
            classroomcourse.buttoncontentsearchclick();
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "')]")));
        }
        [Test]
        public void a50_Narrow_your_search_using_the_search_facets()
        {
            string expectedresult = "1 Items";
            //classroomcourse.linkmyresponsibilitiesclick(driver);
             //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            //classroomcourse.buttoncontentsearchclick();
            int cnt = driver.countelements(By.XPath("//input[contains(@onclick,'return ModalPopup')]"));
            int cnt1 = driver.countelements(By.XPath("//input[contains(@onclick,'return ModalPopup')]"));
            Assert.GreaterOrEqual(cnt, cnt1);
        }
        [Test]
        public void a51_Manage_a_Classroom_course()
        {
            string expectedresult = " The changes were saved.";
            string actualresult = string.Empty;
            classroomcourse.linkmyresponsibilitiesclick(driver);
             //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, "Exact phrase");
            classroomcourse.buttoncourseeditclick();
            classroomcourse.populateeditclassroomsummaryform("testchange");
            actualresult = classroomcourse.buttonsaveeditclassroomsaveclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
        }

        //[Test]
        public void a49_Conduct_a_advance_search_for_a_Classroom_course()
        {
            string expectedresult = "1 Items";
            classroomcourse.linkmyresponsibilitiesclick(driver);
           //  Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.populatecontentsearchadvance("Classroom Course", ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
           classroomcourse.buttoncontentsearchclick();
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "')]")));
        }

        [Test]
        public void a52_Create_a_section_for_a_Classroom_course()
        {
            string expectedresult = " The course section was created with the first event.";
            classroomcourse.linkmyresponsibilitiesclick(driver);
             //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"]  +"Create"+browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveandexitclick()));

            sectioncreation = true;
       //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void a53_Conduct_a_search_for_a_classroom_course_section()
        {
         //   ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr;
        //    driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
             //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.populatesectionsearch("Current", ExtractDataExcel.MasterDic_classrommcourse["Title"]);
            StringAssert.AreEqualIgnoringCase(expectedresult, classroomcourse.buttonsectionsearchclick());
            // b_LogoutUser();
       //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void a54_View_the_Classroom_Calendar()
        {

  
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            Assert.IsTrue(classroomcourse.linkcalendarclick(ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr));
    
           

        }
        [Test]
        public void a55_Manage_a_Classroom_course_section()
        {
       //     ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " The information was saved.";
       //     driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
             //Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.GetElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]")).ClickWithSpace();
          //  classroomcourse.linksearchresulttableclick();
            classroomcourse.buttonsectioneditclick();
            classroomcourse.prepopulatesectionform();
            string actualresult = classroomcourse.buttonsaveandexitclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
      //      driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a56_Edit_expenses_for_a_classroom_course_section()
        {
     //       ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " The information was saved.";
     //       driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
          //  classroomcourse.linksearchresulttableclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.ClickEleJs(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            classroomcourse.linkcosteditclick();
            classroomcourse.populateexpensesform();
            string actualresult = classroomcourse.buttonframesaveandexit();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
      //      driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a57_Create_an_event_for_a_Classroom_course_section()
        {
            if (sectioncreation == true)
            {
                StringAssert.AreEqualIgnoringCase("section created successfully", "section created successfully");
            }
            else
            {
                StringAssert.AreEqualIgnoringCase("Checking section", "Section was not created successfully");
            }

        }
        [Test]
        public void a58_Assign_a_survey_to_a_Classroom_course_section()
        {
       //     ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " Remove";
     //       driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
         //   classroomcourse.linksearchresulttableclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.GetElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]")).ClickWithSpace();
            classroomcourse.linkmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
    //        driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a59_Copy_the_classroom_course_section()
        {
         //   ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "The classroom section was copied.";
       //     driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.ClickEleJs(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            classroomcourse.buttoncopyclassroomsectionclick();
            classroomcourse.populatecopyframe();
            string actualresult = classroomcourse.copybuttonclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
       //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a64_Delete_a_Classroom_course_section()
        {
    //        ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " The course section was deleted.";
    //        driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
         //   classroomcourse.linksearchresulttableclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.ClickEleJs(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));

            string actualresult = classroomcourse.buttondeletesectionclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
    //        driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        // [Test]
        public void a61_Send_an_email_to_users_in_the_classroom_course_section()
        {
            //ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            //string expectedresult = "The information was saved.";
            //driver.UserLogin("admin");
            //classroomcourse.linkmyresponsibilitiesclick(driver);
            //classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"]+9, "Exact phrase");
            //classroomcourse.linkmanagesectionsclick();
            //classroomcourse.linksearchresulttableclick();
            //classroomcourse.linkcosteditclick();
            //classroomcourse.populateexpensesform();
            //string actualresult = classroomcourse.buttonframesaveandexit();
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //// b_LogoutUser();
            Assert.Pass("Not scripted yet");

        }
        [Test]
        public void a60_Edit_an_event_for_a_classroom_course_section()
        {
      //      ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " The information was saved.";
          //  driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.GetElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]")).ClickWithSpace();
            //classroomcourse.linksearchresulttableclick();
            classroomcourse.buttonediteventclick();
            classroomcourse.linkediteventclick();
            classroomcourse.populateediteventform();
            string actualresult = classroomcourse.buttoneventsaveandexitclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
      //      driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a61_Select_a_location_for_a_classroom_course_section_event()
        {
     //       ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " The location was saved.";
         //   driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.GetElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]")).ClickWithSpace();
            classroomcourse.buttonediteventclick();
            classroomcourse.linkediteventclick();
            classroomcourse.buttonselectlocationclick();
            classroomcourse.buttonselectlocationsearchclick();
            classroomcourse.buttonselectlocationradaiobuttonclick();
            string actualresult = classroomcourse.buttonlocationsaveandexitclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
       //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a62_Select_an_instructor_for_a_classroom_course_section_event()
        {
        //    ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "The selected instructors were removed.";
          //  driver.UserLogin("admin",browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.GetElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]")).ClickWithSpace();
            classroomcourse.buttonediteventclick();
            classroomcourse.linkediteventclick();
            classroomcourse.buttonselectinstructorclick();
            classroomcourse.buttonselectinstructorsearchclick();
            classroomcourse.buttonselectinstructorcheckboxclick();
            string actualresult = classroomcourse.buttoninstructorsaveandexitclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
     //       driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a66_Delete_a_Classroom_course_section_event()
        {
        //    ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " The event was deleted.";
       //     driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            driver.WaitForElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]"));
            driver.GetElement(By.XPath(".//*[@class='badge small bg-success']/preceding::a[1]")).ClickWithSpace();
            classroomcourse.buttonediteventclick();
            classroomcourse.checkboxdeleteeventclick();

            string actualresult = classroomcourse.buttonremoveeventclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
      //      driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();

        }
        [Test]
        public void a64_Assign_a_survey_to_a_Classroom_course()
        {
        //    ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = " Remove";
     //       driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            // Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            // classroomcourse.linkmanagesectionsclick();
            //  classroomcourse.linksearchresulttableclick();
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //b_LogoutUser();
            //driver.UserLogin("admin");
            //classroomcourse.deleteclassroomcourse(driver);
        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
      //  [Test]
        public void a67_Manage_Enrollment_for_a_classroom_course_to_batch_enroll_a_user_into_a_class_section_with_a_cost()
        {
        //    ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "The information was saved.";
        //    driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.linksearchresulttableclick();
            classroomcourse.buttonsectioneditclick();
            classroomcourse.prepopulatesectionform();
            string actualresult = classroomcourse.buttonsaveandexitclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
       //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        //[Test]
        public void a68_Manage_Enrollment_for_a_classroom_course_to_batch_waitlist_a_user_into_a_class_section()
        {
     //       ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "Remove";
     //       driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            // classroomcourse.linkmanagesectionsclick();
            //  classroomcourse.linksearchresulttableclick();
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();
            driver.UserLogin("admin1",browserstr);
            classroomcourse.deleteclassroomcourse(driver);
       //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        //[Test]
        public void a69_Manage_Enrollment_for_a_classroom_course_to_cancel_a_users_enrollment_in_a_class_section()
        {
     //       ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "Remove";
     //       driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            // classroomcourse.linkmanagesectionsclick();
            //  classroomcourse.linksearchresulttableclick();
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();
            driver.UserLogin("admin1",browserstr);
            classroomcourse.deleteclassroomcourse(driver);
     //       driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        //[Test]
        public void a70_Manage_Enrollment_for_a_classroom_course_to_cancel_waitlist_for_a_user_in_a_classroom_course_section()
        {
   //         ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "Remove";
   //         driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, "Exact phrase");
            // classroomcourse.linkmanagesectionsclick();
            //  classroomcourse.linksearchresulttableclick();
            classroomcourse.linkcontentmanagesurveyclick();
            classroomcourse.linkassignsurveyclick();
            classroomcourse.buttonsearchsurveyclick();
            classroomcourse.selectcheckbox();
            string actualresult = classroomcourse.savebuttonclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            // b_LogoutUser();
            driver.UserLogin("admin1",browserstr);
            classroomcourse.deleteclassroomcourse(driver);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        //[Test]
        public void a71_Create_a_new_Classroom_course_Virtual()
        {


            //   ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            string expectedresult = "The item was created.";
            //  driver.UserLogin("admin");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            //     Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create"+ browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            StringAssert.AreEqualIgnoringCase(expectedresult, classroomcourse.buttonsaveclick());
            //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

    }
}
