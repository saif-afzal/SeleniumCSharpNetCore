using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
namespace Selenium2.Meridian.Suite.P1.Learning.Transcript.Other
{
    //[TestFixture("ffbs", Category = "firefox")]
    //[TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Transcript_DocumentP1 : TestBase
    {
        string browserstr = string.Empty;
        bool courseDocCreated = false;
        public Transcript_DocumentP1(string browser)
            : base(browser)
        {
            browserstr = browser+"docs";
        }      
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           // driver.Manage().Window.Maximize();
            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
            documentobj.linkmyresponsibilitiesclick();
            Trainingsobj.CreateContentButton_Click_New(Locator_Training.Document_CourseClick);
            documentobj.populatesummarygeneralCourse(driver, ExtractDataExcel.MasterDic_document["Title"] + browserstr, ExtractDataExcel.MasterDic_document["Desc"]);
            documentobj.populateCourseFilesform(driver, true);
            driver.ScrollToCoordinated("500", "500");
            documentobj.buttoncreateclick(driver);
        
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
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
        
        
        //[Test]
        public void Launch_Document_from_Transcript_26868()
        {
            
            documentobj.launchDocument("Document", browserstr, ExtractDataExcel.MasterDic_document["Title"] + browserstr, "");
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'"+ ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]")));
            driver.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
            driver.WaitForElement(By.XPath("//input[@value='Open Item']"));
            driver.ClickEleJs(By.XPath("//input[@value='Open Item']"));
            Thread.Sleep(5000);
            driver.SelectWindowClose2("Google", "" + ExtractDataExcel.MasterDic_document["Title"] + browserstr);
            Thread.Sleep(5000);
            Assert.IsTrue(driver.existsElement(By.XPath("//input[@value='Mark Complete']")));
         
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
