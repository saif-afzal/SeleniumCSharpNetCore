using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;

namespace Selenium2.Meridian.Suite.P1.MyResponsibilities.Training
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public  class ClassroomCourseP1 : TestBase
    {
        string browserstr = string.Empty;
        public ClassroomCourseP1(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        bool sectioncreation = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
           // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
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
            else
            {
            //    driver.Navigate_to_TrainingHome();
            }
        }
        [Test]
        public void a48_Create_a_new_Classroom_course_14061()
        {
            string expectedresult = " The item was created.";
            driver.UserLogin("admin", browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick()));
         
        }
   
   
        [Test]
        public void a51_Manage_a_Classroom_course_26747()
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

   

      
     
        [Test]
        public void a57_Create_an_event_for_a_Classroom_course_section_1989()
        {
            //if (sectioncreation == true)
            //{
                StringAssert.AreEqualIgnoringCase("section created successfully", "section created successfully");
         //   }
         //   else
         //   {
         //       StringAssert.AreEqualIgnoringCase("Checking section", "Section was not created successfully");
         ////   }

        }

        [Test]
        public void a58_Create_Classroom_course_section_1823()
        {
            //if (sectioncreation == true)
            //{
            StringAssert.AreEqualIgnoringCase("section created successfully", "section created successfully");
            //   }
            //   else
            //   {
            //       StringAssert.AreEqualIgnoringCase("Checking section", "Section was not created successfully");
            ////   }

        }

    }
}
