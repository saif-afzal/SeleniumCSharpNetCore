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
    public class a_SearchandcreateContentold : TestBase
    {
        public a_SearchandcreateContentold(string browser)
            : base(browser)
        {

}
        private ClassroomCourse classroomcourse;
        [OneTimeSetUp]
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
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
      //  [Test]
        public void g31_Click_Search_and_Create_Content_link()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            int expectedresult = 0;
            driver.UserLogin("admin", ""); ;
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.populatesearchcontent(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 0, "Any words");
            int actualresult = classroomcourse.buttoncontentsearchgoclick();
            Assert.GreaterOrEqual(actualresult, expectedresult);
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





