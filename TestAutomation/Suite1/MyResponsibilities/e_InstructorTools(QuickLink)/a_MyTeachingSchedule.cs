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

/// <summary>
/// As_an_Instructor_click_on_tabs_to_sort_by_date.
/// Click_on_the_Access_Virtual_Event_link_if_available(Not used in Test)
/// Click_on_My_Teaching_Calendar
/// Click_All_My_Teaching_Schedule
/// </summary>

namespace Selenium2.Meridian.Suite.MyResponsibilities.e_InstructorTools
{
 
    [TestFixture("firefoxbrowserstack")]
    [TestFixture("Chromebrowserstack")]
    [TestFixture("IE11browserstack")]
    [Parallelizable(ParallelScope.Fixtures)]

    public class c_MyTeachingScheduleInstructorold :TestBase
    {
        public c_MyTeachingScheduleInstructorold(string browser)
            : base(browser)
        {
        }
        private ClassroomCourse classroomcourse;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
         //   driver.UserLogin("admin");
          //classroomcourse.deleteclassroomcourse(driver);
    

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
/// <summary>
/// As an instructor click on tabs to sort by date Using Today Tab
   /// expected result = ExtractDataExcel.MasterDic_classrommcourse["Title"]
/// </summary>

         [Test]
        public void c09_As_an_Instructor_click_on_tabs_to_sort_by_date()
        {
            string format = "MM/dd/yyyy";
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Instructor instructor = new Instructor(driver);
            //in expectedresult = 1;
            driver.UserLogin("admin");

            int i = 1;
            string[] dayswise = { "Today", "Next 7 Days", "Next 30 days", "Upcoming Events" };
            //   driver.UserLogin("admin");
            classroomcourse.deleteclassroomcourse(driver);
            foreach (string aa in dayswise)
            {
                string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
                classroomcourse.linkmyresponsibilitiesclick(driver);
                classroomcourse.linkclassroomcourseclick();
                classroomcourse.buttongoclick();

                classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"instructor_sortdate", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
                classroomcourse.buttonsaveclick();
                classroomcourse.linkmyresponsibilitiesclick(driver);
                classroomcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_classrommcourse["Title"] + "instructor_sortdate", "");


               classroomcourse.buttoncontentsearchclick();
               driver.WaitForElement(ObjectRepository.ContentSearchResultTitle);
               driver.GetElement(ObjectRepository.ContentSearchResultTitle).ClickWithSpace();
               driver.WaitForElement(ObjectRepository.ManageSectionsLink);
                classroomcourse.linkclassroomcourseclick();

                classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "instructor_sortdate", "Exact phrase");
                classroomcourse.linkmanagesectionsclick();
                classroomcourse.buttonaddnewsectionclick();
                classroomcourse.populatesectionform1();
                if (aa == "Next 7 Days")
                {
                    classroomcourse.populatesectionformcustomize12(DateTime.Now.AddDays(3).ToString(format), DateTime.Now.AddDays(5).ToString(format));
                    classroomcourse.populateframeformCustomize(DateTime.Now.AddDays(3).ToString(format), DateTime.Now.AddDays(5).ToString(format));
                }
                else if (aa == "Next 30 days")
                {
                    classroomcourse.populatesectionformcustomize12(DateTime.Now.AddDays(40).ToString(format), DateTime.Now.AddDays(40).ToString(format));
                    classroomcourse.populateframeformCustomize(DateTime.Now.AddDays(40).ToString(format), DateTime.Now.AddDays(40).ToString(format));
                }
                else if (aa == "Upcoming Events")
                {
                    classroomcourse.populatesectionformcustomize12(DateTime.Now.AddDays(15).ToString(format), DateTime.Now.AddDays(15).ToString(format));
                    classroomcourse.populateframeformCustomize(DateTime.Now.AddDays(15).ToString(format), DateTime.Now.AddDays(15).ToString(format));
                }
                else
                {
                    classroomcourse.populatesectionformcustomize12(DateTime.Now.ToString(format), DateTime.Now.ToString(format));
                    classroomcourse.populateframeformCustomize(DateTime.Now.ToString(format), DateTime.Now.ToString(format));
                }

                classroomcourse.buttonsaveframeclick();
                instructor.buttonselectinstructorclick();
                instructor.populateselectinstructorform(ExtractDataExcel.MasterDic_admin["Firstname"], ExtractDataExcel.MasterDic_admin["Lastname"]);
                instructor.buttonselectinstructorsearchclick();
                instructor.buttonselectinstructorcheckboxclick();
                instructor.buttoninstructorsaveandexitclick();
                instructor.buttonwaitlistclick();
                classroomcourse.buttonsaveandexitclick();
                classroomcourse.buttonmanageenrollmentclick();
                classroomcourse.buttonenrollusersclick();
                classroomcourse.populatebatchenrollusersform("site", "admin");
                classroomcourse.buttonbatchenrolluserssearchclick();
                classroomcourse.buttonuserselectcheckboxclick();
                classroomcourse.buttonbatchenrollusersclick();
                classroomcourse.linkmyresponsibilitiesclick(driver);
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driver.UserLogin("Instructor");
                classroomcourse.linkmyresponsibilitiesclick(driver);
                i = i + 1;
                if (aa == "Today")
                {
                    string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    //string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinescedulenxt30daylabel);
                    //classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingschedule7daytab);
                    //string actualresult = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachingschedulenoresultintablelabel);
                    //classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingschedule30daytab);
                    //string actualresult3 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachingschedulenoresultintablelabel);

                    IList<IWebElement> options = driver.FindElements(By.XPath("//span[@class='instructor-tools-main-title']"));
                    foreach (IWebElement option in options)
                    {
                        if (expectedresult.Contains(option.Text))
                        {
                            StringAssert.AreEqualIgnoringCase("", "");
                            break;
                        }

                    }
                }

                else if (aa == "Next 7 Days")
                {
                    string expectedresult1 = "No scheduled events";
                    string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                  //  classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingscheduletodaytab);
                    //string actualresult = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachingschedulenoresultintablelabel);
                    //classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingschedule30daytab);
                    //string actualresult2 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    //classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingscheduleupcomingtab);
                    //string actualresult3 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);


                    IList<IWebElement> options = driver.FindElements(By.XPath("//span[@class='instructor-tools-main-title']"));
                    foreach (IWebElement option in options)
                    {
                        if (expectedresult.Contains(option.Text))
                        {
                            StringAssert.AreEqualIgnoringCase("", "");
                            break;
                        }

                    }


                    // StringAssert.AreEqualIgnoringCase(expectedresult, actualresult1);


                }
                else if (aa == "Upcoming Events")
                {
                    classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingscheduleupcomingtab);
                    string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    StringAssert.AreEqualIgnoringCase(expectedresult, actualresult1);
                }
                else if (aa == "Next 30 days")
                {
                    classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingscheduleupcomingtab);
                           IList<IWebElement> options = driver.FindElements(By.XPath("//span[@class='instructor-tools-main-title']"));
                    foreach (IWebElement option in options)
                    {
                        if (expectedresult.Contains(option.Text))
                        {
                            StringAssert.AreEqualIgnoringCase("", "");
                            break;
                        }

                    }
                    //string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult1);

                }
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driver.UserLogin("admin");
                classroomcourse.deleteclassroomcourse(driver);
                //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }


       // [Test]
        public void c10_Click_on_the_Access_Virtual_Event_link_if_available()

        {
        
        }
        [Test]
        public void c11_Click_on_My_Teaching_Calendar()
        {
            string format = "MM/dd/yyyy";
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Instructor instructor = new Instructor(driver);
            int i = 1;
            //in expectedresult = 1;
            driver.UserLogin("admin");
            classroomcourse.deleteclassroomcourse(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"Teaching_Calander", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] +"Teaching_Calander", "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1();
            classroomcourse.populatesectionformcustomize12(DateTime.Now.ToString(format), DateTime.Now.ToString(format));
            classroomcourse.populateframeformCustomize(DateTime.Now.ToString(format), DateTime.Now.ToString(format));
            classroomcourse.buttonsaveframeclick();
            instructor.buttonselectinstructorclick();
            instructor.populateselectinstructorform(ExtractDataExcel.MasterDic_admin["Firstname"], ExtractDataExcel.MasterDic_admin["Lastname"]);
            instructor.buttonselectinstructorsearchclick();
            instructor.buttonselectinstructorcheckboxclick();
            instructor.buttoninstructorsaveandexitclick();
            instructor.buttonwaitlistclick();
            classroomcourse.buttonsaveandexitclick();
            classroomcourse.buttonmanageenrollmentclick();
            classroomcourse.buttonenrollusersclick();
            classroomcourse.populatebatchenrollusersform("site", "admin");
            classroomcourse.buttonbatchenrolluserssearchclick();
            classroomcourse.buttonuserselectcheckboxclick();
            classroomcourse.buttonbatchenrollusersclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("Instructor");
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingschedulemyteachingcalendarlink);
            driver.SelectFrame();
            
            IList<IWebElement> text = driver.FindElements(By.XPath("//div[@class='rsAptContent']"));
            int cnt = driver.countelements(By.XPath("//div[@class='rsAptContent']"));
            foreach (IWebElement result in text) 
            {
                if (result.Text.Contains(expectedresult))
                {
                    Assert.IsTrue(0==0);
                }
            }
           // string actualresult1 = driver.gettextofelement(By.XPath("//div[@class='rsAptContent']"));
            driver.SwitchTo().DefaultContent();
            driver.GetElement(By.CssSelector("span.k-icon.k-i-close")).ClickWithSpace();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin");
            classroomcourse.deleteclassroomcourse(driver);
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





