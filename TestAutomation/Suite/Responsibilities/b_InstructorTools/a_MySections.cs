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


namespace Selenium2.Meridian.Suite.MyResponsibilities.b_InstructorTools
{

    [TestFixture("firefoxbrowserstack")]
    [TestFixture("Chromebrowserstack")]
    [TestFixture("IE11browserstack")]
    [Parallelizable(ParallelScope.Fixtures)]

    class a_MySections : TestBase
    {
        public a_MySections(string browser)
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




        [Test]
        public void d14_Select_an_Instructor_filter_Me_All_Instructors_PartI()
        {
            driver.UserLogin("admin");

            // string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
            int expectedresult = 1;

            classroomcourse.linkmyresponsibilitiesclick(driver);
            instructors.drpdownfilterinstructortoolsportletselect("All Instructors");
            instructors.buttongoinstructortoolportletclick();
            int actualresult = driver.countelements(ObjectRepository.myresponsibilitiesinstructortoolsportlettableresultcount);
            Assert.GreaterOrEqual(actualresult, expectedresult);



        }
        [Test]
        public void d14_Select_an_Instructor_filter_Me_All_Instructors_PartII()
        {

            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Instructor instructor = new Instructor(driver);
            string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
            // driver.UserLogin("admin");
            // classroomcourse.deleteclassroomcourse(driver);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink);
            //driver.UserLogin("admin");
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

            classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkclassroomcourseclick();
            classroomcourse.buttongoclick();
            classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"], ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
            classroomcourse.buttonsaveclick();

            //driver.UserLogin("admin");
            //classroomcourse.linkmyresponsibilitiesclick(driver);
            //classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 0, "Exact phrase");
            classroomcourse.linkmanagesectionsclick();
            classroomcourse.buttonaddnewsectionclick();
            classroomcourse.populatesectionform1();
            classroomcourse.populatesectionform12();
            classroomcourse.populateframeform();
            classroomcourse.buttonsaveframeclick();
            instructor.buttonselectinstructorclick();
            classroomcourse.populateselectinstructorform(ExtractDataExcel.MasterDic_admin["Firstname"], ExtractDataExcel.MasterDic_admin["Lastname"]);
            instructor.buttonselectinstructorsearchclick();
            instructor.buttonselectinstructorcheckboxclick();
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
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_classrommcourse["Title"], "Exact phrase");
            driver.clicktableresult();
            approvalrequest.buttonrequestaccessapprovalclick();
            approvalrequest.buttonrequestaccessapprovalframeclick();


            // classroomcourse.linkmyresponsibilitiesclick(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            driver.select(By.XPath("//select[@id='MainContent_ucInstructorToolsSummary_Instructor']"), "Me");
            //  driver.GetElement(By.XPath("//span[contains(.,'Instructor Tools')]")).ClickWithSpace();
            //    
            //  string actualresult1 = driver.gettextofelement(By.Id("ctl00_MainContent_ucTeachingSchedule_rgMyTeachingSchedule_ctl00_ctl04_MLiteral34"));
            driver.ScrollToCoordinated("1500", "1500");

            IList<IWebElement> options = driver.FindElements(By.XPath("//table[@id='ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00']/tbody/tr"));
            int cnt = options.Count;
            int i = -1;
            foreach (IWebElement option in options)
            {
                
                
                    string[] alltext = option.Text.Split();
                    foreach(string res in alltext)
                    {
                      if(res.Contains(expectedresult))
                      {
                          Assert.Pass("Strings matched");  
                          //break;
                      }

                    }
                   
                
                i = i + 1;
                if (i == cnt)
                {
                    driver.GetElement(By.XPath("//a[@id='MainContent_ucInstructorToolsSummary_lnkAllMySections']")).ClickWithSpace();
                    driver.WaitForElement(By.XPath("//a[@id='MainContent_ucInstructorToolsResults_ucLinks_lblMy']"));
                    IList<IWebElement> options1 = driver.FindElements(By.XPath("//table[@id='ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00']/tbody/tr"));

                    foreach (IWebElement option1 in options1)
                    {
                        string[] alltext1 = option1.Text.Split();
                        foreach (string res in alltext1)
                        {
                            if (res.Contains(expectedresult))
                            {
                                Assert.Pass("Strings matched");
                                //break;
                            }

                        }
                   

                    }

                    Assert.Fail("strings did not matched");

                }




            }
        }

        [Test]
        public void d15_Click_on_a_classroom_course_title_from_the_Instructor_Tools_portlet()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Instructor instructor = new Instructor(driver);
            string expectedresult = "Manage Students";


            classroomcourse.linkmyresponsibilitiesclick(driver);
            instructor.drpdownfilterinstructortoolsportletselect("All Instructors");
            instructor.buttongoinstructortoolportletclick();
            instructor.linkinstructortoolportletclick();
            string actualresult = driver.Title;
            StringAssert.Contains(expectedresult, actualresult);


        }
        [Test]
        public void d16_Click_All_My_Sections()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            Instructor instructor = new Instructor(driver);
            string expectedresult = "Manage Students";

            documentobj.linkmyresponsibilitiesclick();
            string actualresult = instructor.buttonallmysectionsclick();
            Assert.AreEqual(expectedresult, actualresult);
            documentobj.linkmyresponsibilitiesclick();
            documentobj.tabcontentmanagementclick();
            documentobj.buttonsearchgoclick(ExtractDataExcel.MasterDic_document["Title"], "Exact phrase");
            classroomcourse.deletecontent();

        }










    }
    
 
  
}





