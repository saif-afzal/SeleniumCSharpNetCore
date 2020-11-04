using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;

namespace Selenium2.Meridian.Suite.P1.Learning.Transcript.Other
{
    //[TestFixture("ffbs", Category = "firefox")]
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    //[TestFixture("edge", Category = "edge")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
  public  class Transxript_ClassroomSectionP1 : TestBase
    {
        string browserstr = string.Empty;
        public Transxript_ClassroomSectionP1(string browser)
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
            
            //Classroom and Section Creation
            string expectedresult = " The item was created.";
            driver.UserLogin("admin", browserstr);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            driver.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick());

            classroomcourse.linkSectionsClick();
            classroomcourse.addNewSectionClick();
            classroomcourse.populatesectionform1(browserstr);
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            sectioncreation = true;

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
        //[Test,Order(1)]
        public void Classroom_Section_Cancel_Enrollment_26717()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            classroomcourse.enrollInClassroomCourse(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr + "')]"));
            Assert.IsTrue(classroomcourse.cancelenrollInClassroomCourse());
            
        }
           

    }
}
