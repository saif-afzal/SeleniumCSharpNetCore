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
   class c_MyTasks : TestBase
    {

         public c_MyTasks(string browser)
            : base(browser)
        {

        }
       
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

       [OneTimeSetUp]
        //Initiating Driver
        public void LoadDriver()
        {
           
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin");
            objLogin = new Login();
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

        [SetUp]
        public void SetUp()
        {
      
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);

//driver.UserLogin("admin");
        }
        [TearDown]
        public void TearDown()
        {
          //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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



        [Test]
        public void f25_From_Pending_Evaluations_schedule_an_evaluation_for_a_user()
        {
            string format = "MM/dd/yyyy";
       
            // string expectedresult = ExtractDataExcel.MasterDic_classrommcourse["Title"];
            string expectedresult = "The evaluation was scheduled for this checklist.";
            //driver.UserLogin("admin");
            //classroomcourse.deleteclassroomcourse(driver);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
          
            classroomcourse.linkmyresponsibilitiesclick(driver);
            tasks.tabcontentmanagementclick();
            tasks.populateselectcoursecreation("On-the-Job Training");
            tasks.buttongoclick();
            tasks.populatesummaryojt(driver,ExtractDataExcel.MasterDic_ojt["Title"], ExtractDataExcel.MasterDic_ojt["Desc"], 0);
            tasks.buttoncreatenewclick();
            tasks.buttoncreateandmanagechecklistclick();
            tasks.useandexistingchecklistclick();
            tasks.populatechecklistsearch("newchklist", "Exact phrase");
            tasks.buttonchecklistsearchclick();
            tasks.selectandclickaddclick();
            tasks.buttonCheckinclick();
            tasks.tabmyownlearningclick();
            driver.searchcourseintraininghomepage(ExtractDataExcel.MasterDic_ojt["Title"], "Exact phrase");
            driver.clicktableresult();
            tasks.buttonenrolojtclick();
            tasks.buttonlaunchojtclick();
            tasks.linktestchecklistclick();
            tasks.populateframeevaluators();
            tasks.buttonsaveframeclick();

            classroomcourse.linkmyresponsibilitiesclick(driver);
           string actualresult=  tasks.testcode();
            
            classroomcourse.linkmyresponsibilitiesclick(driver);
            string test = driver.gettextofelement(By.Id("MainContent_ucEvaluation_lbScheduled"));
            driver.WaitForElement(By.Id("MainContent_ucEvaluation_lbScheduled"));
            Assert.GreaterOrEqual(driver.getintegerfromstring(test), 1);
            //driver.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkSubject"));

        //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            StringAssert.Contains(expectedresult, actualresult);


        }

        [Test]
        public void f26_From_Scheduled_Evaluations_reschedule_an_evaluation()
        {
            string format = "MM/dd/yyyy";
            classroomcourse.linkmyresponsibilitiesclick(driver);
       //     driver.ScrollToCoordinated("2000", "2000");
            driver.WaitForElement(By.Id("MainContent_ucEvaluation_lbScheduled"));
            driver.GetElement(By.Id("MainContent_ucEvaluation_lbScheduled")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucEvaluation_rgEvaluations_ctl00_ctl04_btnChange']"));
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucEvaluation_rgEvaluations_ctl00_ctl04_btnChange']")).ClickWithSpace();
           // driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucEvaluation_rgEvaluations_ctl00_ctl04_btnChange']")).ClickWithSpace();
            driver.SelectFrame();
            driver.WaitForElement(By.XPath("//input[@id='MainContent_UC1_rblSelect_0']"));
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_rblSelect_0']")).ClickWithSpace();
            driver.GetElement(By.XPath("//input[@id='MainContent_UC1_btnSave']")).ClickWithSpace();
          //  driver.SelectFrame(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_START_DATE_dateInput"));

            driver.WaitForElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_START_DATE_dateInput"));
            driver.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_START_DATE_dateInput")).Clear();
            driver.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_END_DATE_dateInput")).Clear();
            driver.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_START_DATE_dateInput")).SendKeysWithSpace(DateTime.Now.ToString(format));
            driver.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_END_DATE_dateInput")).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));

        
            driver.GetElement(By.Id("MainContent_UC1_btnSave")).ClickWithSpace();
            driver.SwitchTo().DefaultContent();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            string actualreslt = driver.gettextofelement(ObjectRepository.sucessmessage);
            string expectedresult = "The evaluation was scheduled for this checklist.";
            StringAssert.Contains(expectedresult, actualreslt);
          //  driver.UserLogin("admin");
   
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void f27_From_Scheduled_Evaluations_start_an_evaluation_for_a_user_and_complete_the_evaluation()
        {
            classroomcourse.linkmyresponsibilitiesclick(driver);
       
            string expectedresult = "You marked the evaluation as successful.";
            //driver.WaitForElement(By.XPath("//a[@id='MainContent_ucEvaluation_lbScheduled']"));
            //driver.GetElement(By.XPath("//a[@id='MainContent_ucEvaluation_lbScheduled']")).ClickAnchor();
            driver.WaitForElement(By.Id("ctl00_MainContent_ucEvaluation_rgEvaluations_ctl00_ctl04_btnStartEvaluation"));
            driver.GetElement(By.Id("ctl00_MainContent_ucEvaluation_rgEvaluations_ctl00_ctl04_btnStartEvaluation")).ClickWithSpace();
            driver.WaitForElement(By.Id("MainContent_UC1_btnSuccessful"));
            driver.GetElement(By.Id("MainContent_UC1_btnSuccessful")).ClickWithSpace();

            driver.findandacceptalert();
            driver.WaitForElement(ObjectRepository.sucessmessage);
            string actualreslt = driver.gettextofelement(ObjectRepository.sucessmessage);
            StringAssert.Contains(expectedresult, actualreslt);

        }

        [Test]
        public void f28_From_Completed_Evaluations_view_all_the_attempts_for_an_evaluation()
        {
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);

            classroomcourse.linkmyresponsibilitiesclick(driver);
      
            driver.WaitForElement(By.XPath("//a[@id='MainContent_ucEvaluation_lblCompleted']"));
            driver.GetElement(By.XPath("//a[@id='MainContent_ucEvaluation_lblCompleted']")).ClickWithSpace();
            driver.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucEvaluation_rgEvaluations_ctl00_ctl04_btnViewAttempts']"));
            driver.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucEvaluation_rgEvaluations_ctl00_ctl04_btnViewAttempts']")).ClickWithSpace();
           // driver.selectWindow("View All Attempts");
            driver.WaitForElement(By.XPath("//td[contains(.,'Successful')]"));
           string actualresult=driver.gettextofelement(By.XPath("//td[contains(.,'Successful')]"));
           string expectedresult = "Successful";
           StringAssert.Contains(expectedresult, actualresult);

        }
            

        
        [Test]
        public void f29_Click_View_All_My_Tasks()
        {
            int expectedresult = 1;
            classroomcourse.linkmyresponsibilitiesclick(driver);
            driver.ScrollToCoordinated("2500", "2500");
            driver.WaitForElement(By.Id("MainContent_ucEvaluation_lbAllTasks"));
            driver.GetElement(By.Id("MainContent_ucEvaluation_lbAllTasks")).ClickWithSpace();
            driver.WaitForElement(By.Id("MainContent_UC1_lblCompleted"));
            driver.GetElement(By.Id("MainContent_UC1_lblCompleted")).ClickAnchor();

         
            //driver.WaitForElement(By.XPath("//a[@id='MainContent_UC1_MLinkButton3']"));
            //driver.GetElement(By.XPath("//a[@id='MainContent_UC1_MLinkButton3']")).ClickWithSpace();
            driver.WaitForElement(By.Id("ctl00_MainContent_UC1_rgEvaluations_ctl00_ctl05_btnViewAttempts"));
            int cnt = driver.countelements(By.XPath("//span[contains(.,'Info')]"));

       //     MyTasks tasks = new MyTasks(driver);
            
            Assert.GreaterOrEqual(cnt, expectedresult);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }


    }
  
  
}





