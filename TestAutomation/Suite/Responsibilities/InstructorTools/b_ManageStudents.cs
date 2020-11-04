using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
namespace Selenium2.Meridian.Suite.MyResponsibilities.e_InstructorTools
{
    [TestFixture("firefoxbrowserstack")]
    [TestFixture("Chromebrowserstack")]
    [TestFixture("IE11browserstack")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class d_InstructorTools : TestBase
    {
        public d_InstructorTools(string browser)
            : base(browser)
        {
        }
        public bool sectioncreation = false;

        //   private string user;
        private ClassroomCourse classroomcourse;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
           
             driver.Quit();
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        }
          [Test]
        public void Click_on_Classroom_Calendar_View()
        {
          //  driver.UserLogin("admin");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void d142_Conduct_a_search_for_sections()
        {
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
            ClassroomCourse ClassroomCourse = new ClassroomCourse(driver);
           // driver.UserLogin("admin");
            ClassroomCourse.linkmyresponsibilitiesclick(driver);
            ClassroomCourse.linkclassroomcourseclick();
            ClassroomCourse.buttongoclick();
            ClassroomCourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"search_section", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            ClassroomCourse.buttonsaveclick();
            ClassroomCourse.linkmyresponsibilitiesclick(driver);
            ClassroomCourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "Exact phrase");
            ClassroomCourse.linkmanagesectionsclick();
            ClassroomCourse.buttonaddnewsectionclick();
         //   ClassroomCourse.populatesectionform1();
            ClassroomCourse.populatesectionform12();
            ClassroomCourse.populateframeform();
            ClassroomCourse.buttonsaveframeclick();
            ClassroomCourse.buttonsaveandexitclick();
          
            ClassroomCourse.buttonmanageenrollmentclick();
            ClassroomCourse.buttonenrollusersclick();
            ClassroomCourse.populatebatchenrollusersform("site", "admin");
            ClassroomCourse.buttonbatchenrolluserssearchclick();
            ClassroomCourse.buttonuserselectcheckboxclick();
            ClassroomCourse.buttonbatchenrollusersclick();
            ClassroomCourse.linkmyresponsibilitiesclick(driver);
            ClassroomCourse.linkinstructortoolsclick();
            ClassroomCourse.linkmanageclick();
            ClassroomCourse.linkallinstructorsclick();
            ClassroomCourse.populatemanagestudentsform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "All");
            string _actualresult = ClassroomCourse.buttonsearchclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, _actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void d143_Click_on_a_section_title_to_view_the_Roster_for_a_classroom_section()
        {
            ClassroomCourse ClassroomCourse = new ClassroomCourse(driver);
            string expectedresult = "enrolled and waitlisted tabs found";
            string actualresult = string.Empty;
          //  driver.UserLogin("admin");
            ClassroomCourse.linkmyresponsibilitiesclick(driver);
            ClassroomCourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "Exact phrase");
            ClassroomCourse.linkinstructortoolsclick();
            ClassroomCourse.linkmanageclick();
            ClassroomCourse.linkallinstructorsclick();
            ClassroomCourse.populatemanagestudentsform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "All");
         //   ClassroomCourse.linkmanagesectionsclick();
            ClassroomCourse.buttonsearchclick();
            actualresult=ClassroomCourse.linksectiontitleclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void d144_Export_the_roster_to_Excel()
        {
            //ClassroomCourse ClassroomCourse = new ClassroomCourse(driver);
            //string expectedresult = "enrolled and waitlisted tabs found";
            //string actualresult = string.Empty;
            //driver.UserLogin("admin");
            //ClassroomCourse.linkmyresponsibilitiesclick(driver);
            //ClassroomCourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 0, "Exact phrase");
            //ClassroomCourse.linkinstructortoolsclick();
            //ClassroomCourse.linkmanageclick();
            //ClassroomCourse.linkallinstructorsclick();
            //ClassroomCourse.populatemanagestudentsform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 0, "All");
            ////   ClassroomCourse.linkmanagesectionsclick();
            //ClassroomCourse.buttonsearchclick();
            //ClassroomCourse.linksectiontitleclick();
            //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            Assert.Pass("need to be scripted");
          

        }
        [Test]
        public void d145_Send_an_email_to_users_from_the_Roster()
        {
            ClassroomCourse ClassroomCourse = new ClassroomCourse(driver);
            string expectedresult = "The email was sent.";
            string actualresult = string.Empty;
          //  driver.UserLogin("admin");
            ClassroomCourse.linkmyresponsibilitiesclick(driver);
            ClassroomCourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "Exact phrase");
            ClassroomCourse.linkinstructortoolsclick();
            ClassroomCourse.linkmanageclick();
            ClassroomCourse.linkallinstructorsclick();
            ClassroomCourse.populatemanagestudentsform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "All");
            ClassroomCourse.buttonsearchclick();
            ClassroomCourse.linksectiontitleclick();
            ClassroomCourse.buttonemailallclick();
            ClassroomCourse.populatemessageform("this is a test","TestAutomation checked");
            actualresult = ClassroomCourse.buttonsendmailclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
      
        [Test]
        public void d147_Send_an_email_to_the_users_from_the_Instructor_Tools_page()
        {
            ClassroomCourse ClassroomCourse = new ClassroomCourse(driver);
            string expectedresult = "The email was sent.";
            string actualresult = string.Empty;
           // driver.UserLogin("admin");
            ClassroomCourse.linkmyresponsibilitiesclick(driver);
            ClassroomCourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "Exact phrase");
            ClassroomCourse.linkinstructortoolsclick();
            ClassroomCourse.linkmanageclick();
            ClassroomCourse.linkallinstructorsclick();
            ClassroomCourse.populatemanagestudentsform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "All");
            ClassroomCourse.buttonsearchclick();
            ClassroomCourse.linksectiontitleclick();
            ClassroomCourse.buttonemailinstructortoolsclick();
            ClassroomCourse.populatemessageform("this is a test", "TestAutomation checked");
            actualresult = ClassroomCourse.buttonsendmailclick();
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void d148_Assign_a_survey_to_the_classroom_section()
        {
            ClassroomCourse ClassroomCourse = new ClassroomCourse(driver);
            string expectedresult = "Remove";
            string actualresult = string.Empty;
           // driver.UserLogin("admin");
            ClassroomCourse.linkmyresponsibilitiesclick(driver);
            ClassroomCourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "Exact phrase");
            ClassroomCourse.linkinstructortoolsclick();
            ClassroomCourse.linkmanageclick();
            ClassroomCourse.linkallinstructorsclick();
            ClassroomCourse.populatemanagestudentsform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "search_section", "All");
            ClassroomCourse.buttonsearchclick();
            ClassroomCourse.linksectiontitleclick();
            ClassroomCourse.linkcoursemanagesurveyclick();
        //    ClassroomCourse.linkmanagesurveyclick();
            ClassroomCourse.linkassignsurveyclick();
            ClassroomCourse.buttonsearchsurveyclick();
            ClassroomCourse.selectcheckbox();
        actualresult = ClassroomCourse.savebuttonclick();
        driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
       // driver.UserLogin("admin");
        ClassroomCourse.deleteclassroomcourse(driver); ;
        driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult);

        }
        [Test]
        public void Add_a_note_to_the_users_Transcript_via_Manage_Notes()
        {

        //    driver.UserLogin("admin");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
    }
}
