using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;

//using TestAutomation.Meridian.Regression_Objects;


namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    
    [TestFixture("firefoxbrowserstack")]
    [TestFixture("Chromebrowserstack")]
    [TestFixture("IE11browserstack")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class o_ImportSkillsoftCoursesold : TestBase
    {
        public o_ImportSkillsoftCoursesold(string browser)
            : base(browser)
        {

}
        private ClassroomCourse classroomcourse;
        private string record = string.Empty;
      //  [OneTimeSetUp]//plese open it is for failed one
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //if (delsiteadminclassroom == "false")
            //{
            //    //    delclass();
            //}

            //RemoveDummyAdminAccount();

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

       // [Test]
        public void j43_Search_for_a_skillsoft_course()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            record = string.Empty;
            string expectedresult = "The selected Skillsoft courses were imported.";
            driver.UserLogin("admin", ""); ;
            classroomcourse.linkmyresponsibilitiesclick(driver);
            driver.WaitForElement(By.XPath("//a[@id='MainContent_ucSkillSoftMenu_ImportSkillSoftCourses']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_ucSkillSoftMenu_ImportSkillSoftCourses']")).ClickWithSpace();
          
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='ctl00_MainContent_UC1_rgSkillSoftCourses_ctl00_ctl04_chkSelect']"));
            driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_rgSkillSoftCourses_ctl00_ctl04_chkSelect']")).ClickWithSpace();

            record=driver.gettextofelement(By.XPath("//span[@id='ctl00_MainContent_UC1_rgSkillSoftCourses_ctl00_ctl06_lblTitle']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnDownload']")).ClickWithSpace();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            string actualreslt = driver.gettextofelement(ObjectRepository.sucessmessage);
            StringAssert.Contains(expectedresult, actualreslt);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public void j44_Select_Already_Downloaded_facet_options_to_narrow_the_results()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);

            int expcnt = 1;
            driver.UserLogin("admin", ""); ;
            classroomcourse.linkmyresponsibilitiesclick(driver);
            driver.GetElement(By.XPath("//a[@id='MainContent_ucSkillSoftMenu_ImportSkillSoftCourses']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_txtPhrase']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_txtPhrase']")).SendKeys(record);
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[contains(@id,'chkSelect')]"));
         int actcnt = driver.countelements(By.XPath("//input[contains(@id,'chkSelect')]"));
         Assert.GreaterOrEqual(actcnt,expcnt);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void j45_Click_Recently_Updated()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);

            driver.UserLogin("admin", ""); ;
            classroomcourse.linkmyresponsibilitiesclick(driver);
            driver.WaitForElement(By.XPath("//a[@id='MainContent_ucSkillSoftMenu_ImportSkillSoftCourses']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_ucSkillSoftMenu_ImportSkillSoftCourses']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnSearch']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//label[@for='cbCourses downloaded']"));
            int cnt = driver.getintegerfromstring(driver.GetElement(By.XPath("//label[@for='cbCourses downloaded']")).Text);
            driver.GetElement(By.XPath("//input[@id='cbCourses downloaded']")).ClickWithSpace();
            int actcnt = driver.countelements(By.XPath("//input[contains(@id,'chkSelect')]"));
          
            Assert.LessOrEqual(cnt,actcnt);
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





