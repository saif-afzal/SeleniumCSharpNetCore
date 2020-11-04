using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
using OpenQA.Selenium.Firefox;
namespace Selenium2.Meridian.Suite.P1.Learning.Transcript.Other
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Transcript_ScormP1 : TestBase
    {
        string browserstr = string.Empty;
        bool courseCreated = false;
        public Transcript_ScormP1(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);

            #region Create Scorm Course
            Document documentpage = new Document(driver);
            //string expectedresult = "Edit Summary";
            //string expectedresult1 = "The course was created.";
            Scorm12 CreateScorm = new Scorm12(driver);
            classroomcourse.linkmyresponsibilitiesclick(driver);
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Scorm_CourseClick);
            driver.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            CreateScorm.buttoncreateclick(driver, true);
            driver.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
         //   string text = driver.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
            //StringAssert.AreEqualIgnoringCase(expectedresult, text);
            driver.WaitForElement(ObjectRepository.sucessmessage);
            CreateScorm.populatesummaryform(driver, browserstr);
            CreateScorm.buttonsaveclick(driver);

            #endregion

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
                driver.UserLogin("admin", browserstr);
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
        }
        
        //[Test, Order(1)]
        public void Launch_Scorm_From_Transcript_26844()
        {
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            Assert.IsTrue(classroomcourse.enrollInToCourses("Scorm", browserstr, "", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));
            Assert.IsTrue(documentobj.launchDocument("Scorm", browserstr, "", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr));
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
            Thread.Sleep(5000);
            driver.selectWindow("Meridian Global - Core Domain");
            Thread.Sleep(5000);
            driver.SelectWindowClose2("Meridian Global - Core Domain", ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
            Thread.Sleep(5000);
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@value='Resume']")));
            
       
        }

        //[Test, Order(2)]
        public void Complete_Scorm_Course_WithSurveys_From_Transcript_26846()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            Assert.IsTrue(Scorm1_2obj.markComplete());

            
        }

        //[Test, Order(3)]
        public void View_scorm_Course_Certificate_From_Transcript_26848()
        {
            // need to work on mark complete scorm function
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")));
            driver.ClickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction']"));
            Thread.Sleep(5000);
            driver.selectWindow("Meridian Global 2010.1");
            Thread.Sleep(2000);
            driver.waitforframe(By.Id("CertificateWindow"));
            Thread.Sleep(2000);
            driver.WaitForElement(By.XPath("//span[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]"));
            driver.SelectWindowClose2("Meridian Global 2010.1");
            Thread.Sleep(3000);
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_scrom["Title"] + browserstr + "')]")));
          
           
        }
    }
}

