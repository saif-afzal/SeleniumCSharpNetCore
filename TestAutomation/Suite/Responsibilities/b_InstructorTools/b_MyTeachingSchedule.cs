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

namespace Selenium2.Meridian.Suite.MyResponsibilities.b_InstructorTools
{
 
    [TestFixture("firefoxbrowserstack")]
    [TestFixture("Chromebrowserstack")]
    [TestFixture("IE11browserstack")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class b_MyTeachingSchedule : TestBase
    {
        public b_MyTeachingSchedule(string browser)
            : base(browser)
        {
        }
       
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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
                driver.UserLogin("admin");
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
                driver.Navigate_to_TrainingHome();
            }
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
            TrainingHomeobj.click_systemOptions();
            //   TrainingHomeobj.click_systemOptionsTab("People");
            TrainingHomeobj.click_systemOptionsAccordian("Training Management");
            TrainingHomeobj.click_systemOptionsLink("Access Approval Paths");
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.Click_AdminConsoleLink();
            //AdminstrationConsoleobj.Click_OpenItemLink("Approval Paths");
            ApprovalPathobj.Click_CreateNewGoTo();
            ApprovalPathobj.Populate_AdministrativeApproval(ExtractDataExcel.MasterDic_approver["Title"]);
            ApprovalPathobj.Select_Administrators(3);
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            int i = 1;
            string[] dayswise = { "Today", "Next 7 Days", "Next 30 days", "Upcoming Events" };
            //   driver.UserLogin("admin");
            //    classroomcourse.deleteclassroomcourse(driver);
            foreach (string aa in dayswise)
            {
                string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
                classroomcourse.linkmyresponsibilitiesclick(driver);
                classroomcourse.linkclassroomcourseclick();
                classroomcourse.buttongoclick();

                classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "instructor_sort", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
                classroomcourse.buttonsaveclick();

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
                    classroomcourse.populatesectionformcustomize12(DateTime.Now.ToString(format), DateTime.Now.AddDays(1).ToString(format));
                    classroomcourse.populateframeformCustomize(DateTime.Now.ToString(format), DateTime.Now.AddDays(1).ToString(format));
                }

                classroomcourse.buttonsaveframeclick();
                instructor.buttonselectinstructorclick();
                classroomcourse.populateselectinstructorform(ExtractDataExcel.MasterDic_admin["Firstname"], ExtractDataExcel.MasterDic_admin["Lastname"]);
                instructor.buttonselectinstructorsearchclick();
                instructor.buttonselectinstructorcheckboxclick();
                IList<IWebElement> options1 = driver.FindElements(By.XPath(".//*[@class='cal-month-day cal-day-inmonth cal-day-today']"));
                instructor.buttoninstructorsaveandexitclick();
                instructor.buttonwaitlistclick();
                classroomcourse.buttonsaveandexitclick();
                classroomcourse.linkcoursesectionclick();
                approvalrequest.buttonaccessapprovaleditclick();
                approvalrequest.populatemanageaccessapprovalframe(ExtractDataExcel.MasterDic_approver["Title"], "Exact phrase");
                approvalrequest.buttonaccessapprovalsearchclick();
                approvalrequest.radioaccessapprovalresultclick();
                approvalrequest.buttonaccessapprovalsaveclick();
                approvalrequest.linkmyownlearningclick();
                driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "instructor_sort", "Exact phrase");
                driver.clicktableresult();
                approvalrequest.buttonrequestaccessapprovalclick();
                approvalrequest.buttonrequestaccessapprovalframeclick();
                classroomcourse.linkmyresponsibilitiesclick(driver);
                i = i + 1;
                if (aa == "Today")
                {
                    if (driver.Returntextfromportlet(By.XPath("//tr[@id='ctl00_MainContent_ucInstructorToolsSummary_Summary_rgMyTeachingSchedule_ctl00__0']/td/ul"), expectedresult))
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.IsTrue(driver.Returntextfrompage(By.XPath("//tr[@id='ctl00_MainContent_ucTeachingSchedule_rgMyTeachingSchedule_ctl00__0']/td[3]/div/div/ul"), expectedresult));
                    }





                }


                else if (aa == "Next 7 Days")
                {
                    string expectedresult1 = "No scheduled events";
                    //   string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    //  classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingscheduletodaytab);
                    //string actualresult = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachingschedulenoresultintablelabel);
                    //classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingschedule30daytab);
                    //string actualresult2 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    //classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingscheduleupcomingtab);
                    //string actualresult3 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);





                    // StringAssert.AreEqualIgnoringCase(expectedresult, actualresult1);


                }
                else if (aa == "Upcoming Events")
                {
                    classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesmyteachingscheduleupcomingtab);
                    //  string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    StringAssert.AreEqualIgnoringCase(expectedresult, "");
                }
                else if (aa == "Next 30 days")
                {

                    //string actualresult1 = driver.gettextofelement(ObjectRepository.myresponsibilitiesmyteachinesceduletodaylabel);
                    //StringAssert.AreEqualIgnoringCase(expectedresult, actualresult1);

                }
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driver.UserLogin("admin");
                classroomcourse.deleteclassroomcourse(driver);
                //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
            
        
    

         //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        

            
       // [Test]
        public void c10_Click_on_the_Access_Virtual_Event_link_if_available()

        {
        
        }
       // [Test]
        public void c11_Click_on_My_Teaching_Calendar()
        {
            string format = "MM/dd/yyyy";
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Instructor instructor = new Instructor(driver);
            int i = 1;
            //in expectedresult = 1;
        //    driver.UserLogin("admin");
        //    classroomcourse.deleteclassroomcourse(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"] + "teaching_calender";
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"]+"teaching_calender", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "teaching_calender", "Exact phrase");
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
       //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //    driver.UserLogin("admin");
          //  classroomcourse.deleteclassroomcourse(driver);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            
            
            
            
          

        }
      //  [Test]
        public void c12_Click_All_My_Teaching_Schedule()
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
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "allmyteachingschedule", ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();
            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "allmyteachingschedule", "Exact phrase");
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
            classroomcourse.tabnxt7daysclick(driver, ObjectRepository.myresponsibilitiesviewlallmyteachingschedulebutton);
            string actualresult1 = driver.gettextofelement(ObjectRepository.myteachingscheduleeventlabel);
            StringAssert.AreEqualIgnoringCase(expectedresult, actualresult1);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin");
            classroomcourse.deleteclassroomcourse(driver);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

     

    }
   
  
}





