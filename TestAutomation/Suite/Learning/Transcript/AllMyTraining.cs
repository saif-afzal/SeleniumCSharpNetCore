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

namespace Selenium2.Meridian.Suite.MyOwnLearning.Transcript
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class AllMyTraining : TestBase
    {
        string browserstr = string.Empty;
        public AllMyTraining(string browser)
            : base(browser)
        {
            browserstr = browser+"MT";
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);

        }
        [SetUp]
        public void starttest()
        {
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);

            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Click_the_All_My_Training_quicklink()
        {


            driver.UserLogin("admin1",browserstr);
            for (int i = 1; i <= 2; i++)
            {
                TrainingHomeobj.MyResponsiblities_click();
                Trainingobj.SearchContent_Click();
                ContentSearchobj.NewContent("General Course");
                Createobj.FillGeneralCoursePage("AllMyTraining" + i, browserstr);

                //String Assertion on new curriculum creation 
                String successMsg = Contentobj.SuccessMsgDisplayed();
                StringAssert.Contains("The item was created.", successMsg);
                Assert.IsTrue(Contentobj.Click_CheckIn());
            }
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"] +browserstr+ "AllMyTraining" + 1);
            SearchResultsobj.Content_Click();
            Assert.IsTrue(Detailsobj.Click_EnrollGeneralCourse());

            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_Search(ExtractDataExcel.MasterDic_genralcourse["Title"] +browserstr+ "AllMyTraining" + 2);
            SearchResultsobj.Content_Click();
            Detailsobj.Click_EnrollGeneralCourse();
            Detailsobj.Click_OpenGeneralCourse();
           Assert.IsTrue( Detailsobj.Click_MarkCompleteGeneralCourse());

           string dri = driver.Title;
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Assert.IsTrue(Transcriptsobj.Check_AllMyTrainingFilters());
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1));
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 2));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink,ObjectRepository.HoverMainLink);
        }

        [Test]
        public void b_Apply_search_filters_to_the_All_My_Training_view_of_the_Transcript()
        {

            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Transcriptsobj.SelectType("All My Training");
            Transcriptsobj.SelectStatus("Enrolled");
            Transcriptsobj.Click_BtnFilter();
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1));
            Transcriptsobj.SelectType("All Training");
            Transcriptsobj.SelectStatus("Completed");
            Transcriptsobj.Click_BtnFilter();
            Assert.IsTrue(Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 2));
            Transcriptsobj.SelectStatus("All");
            Transcriptsobj.Click_BtnFilter();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }



        [Test]
        public void C_Click_on_a_content_item()
        {
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"]+ browserstr+"AllMyTraining" + 1);
            Transcriptsobj.Click_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1);
            Assert.IsTrue(Detailsobj.Check_ContentHeading(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void d_Complete_a_content_item_that_is_started()
        {

            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Transcriptsobj.Check_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1);
            Transcriptsobj.Click_DesiredResult(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1);
            Detailsobj.Check_ContentHeading(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1);
            Detailsobj.Click_OpenGeneralCourse();
            Detailsobj.Click_MarkCompleteGeneralCourse();
            Assert.IsTrue(Detailsobj.Click_ViewDetailGeneralCourseCompleted(browserstr));
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void e_Click_the_Print_link()
        {
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Assert.IsTrue(Transcriptsobj.Click_PrintBtn("All Training", ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "AllMyTraining" + 1,browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void f_Click_the_Save_as_PDF_link()
        {
            driver.UserLogin("userforregression",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_TranscriptLink();
            Transcriptsobj.Click_AllMyTrainingLink();
            Assert.IsTrue(Transcriptsobj.Click_PDFBtn("AllMyTrainingPrint.aspx"));
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
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }
    }
}
