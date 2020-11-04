using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;


namespace Selenium2.Meridian.Suite.P1.Learning.Transcript.Tab
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CurriculumsTranscriptP1 : TestBase
    {

        string browserstr = string.Empty;
        public CurriculumsTranscriptP1(string browser)
            : base(browser)
        {
            browserstr = browser;
}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
            #region Loading Drivers
            TrainingHomes objTrainingHome = new TrainingHomes(driver);
            Create objCreate = new Create(driver);
            Content objContent = new Content(driver);
            TrainingActivities objTrainingActivities = new TrainingActivities(driver);
            AddContent objAddContent = new AddContent(driver);
    
            #endregion
            #region Create Curriculum with content
            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
            objCreate.FillGeneralCoursePage("", browserstr);
            driver.WaitForElement(ObjectRepository.CheckinNew);
            driver.ClickEleJs(ObjectRepository.CheckinNew);

            objTrainingHome.MyResponsiblities_click();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);

            objCreate.FillCurriculumPage("", browserstr);
            objContent.Edit_TrainingActivities();
            TrainingActivitiesobj.Click_AddCurriculamBlock();
            TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("", browserstr);
            objTrainingActivities.AddTrainingActivities_Click();
            objAddContent.SearchAndAddActivityGC(browserstr);
            //String assertion on adding training activities
            String successMsg1 = objAddContent.SuccessMsg();

            String successMsg = objContent.SuccessMsgDisplayed();
            //    StringAssert.Contains("The item was created.", successMsg);
            driver.WaitForElement(ObjectRepository.CheckinNew);
            driver.ClickEleJs(ObjectRepository.CheckinNew);
            #endregion
        }
        [SetUp]
        public void starttest()
        {
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test, Order(1)]
        public  void A_View_Transcript_Curriculum_26150()
        {
            ContentSearch objContentSearch = new ContentSearch(driver);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //driver.UserLogin("userforregression", browserstr);
            objContentSearch.enrollInCurriculum(Variables.curriculumTitle + browserstr, browserstr);
            objContentSearch.accessCurriculum(browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();

            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]")));
            Assert.IsTrue(Transcriptsobj.Click_PrintBtn("Curriculums"));
            Assert.IsTrue(Transcriptsobj.Click_PDFBtn("CurriculaPrint.aspx"));

            
        }

        [Test, Order(2)]
        public void Launch_Curriculum_26855()
        {
            ContentSearch objContentSearch = new ContentSearch(driver);
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]"));
            //Assert.IsTrue(objContentSearch.accessCurriculum(browserstr));
            Assert.IsTrue(objContentSearch.launchCurriculum(browserstr));
            //Assert.Fail("Need to be automated");

        }

        [Test, Order(3)]
        public  void B_Curriculum_View_Certificate_26853()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_CurriculamLink();
         //   Transcriptsobj.Click_CurriculamFilter();
            driver.WaitForElement(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]"));
            driver.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction']"));
            Thread.Sleep(5000);
            driver.selectWindow("Meridian Global 2010.1");
            Thread.Sleep(2000);
            driver.waitforframe(By.Id("CertificateWindow"));
            Thread.Sleep(2000);
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'" + Variables.curriculumTitle + browserstr + "')]")));
            driver.SelectWindowClose2("Meridian Global 2010.1");
            Thread.Sleep(2000);
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + Variables.curriculumTitle + browserstr + "')]")));



        }
        [Test, Order(4)]
        public void Take_Surveys_26852()
        {
            Assert.Ignore("Need to be automated" + " Survey Issue on External");
        }

       
        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
    }
}
