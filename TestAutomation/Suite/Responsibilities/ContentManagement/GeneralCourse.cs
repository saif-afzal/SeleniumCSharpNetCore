using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;
namespace Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class e_GeneralCourse : TestBase
    {
        string browserstr = string.Empty;
        bool courseGCCreated = false;

        public e_GeneralCourse(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            InitializeBase(driver);
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            //   driver.Navigate().GoToUrl("http://baseqa-14-3.meridianksi.net/Default.aspx");
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
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
        #region Titans_Team_UploadedGeneralCourse
        [Test]
        public void A_As_a_content_administrator_able_to_preview_my_uploaded_GeneralCOurse_CreateCourse_7251()
        {
            #region Create General Course Cource
            generalcourseobj.CreateGeneralCource(browserstr, "Yes");
            courseGCCreated = true;
            #endregion
      Assert.IsTrue(generalcourseobj.ValidatePreviewButton_generalCourse());
        }
        [Test]
        public void B_As_a_content_administrator_able_to_preview_my_uploaded_GeneralCOurse_SearchCourse_7253()
        {
            if (!courseGCCreated) { documentobj.Create_DocumentForRegression(browserstr); courseGCCreated = true; }
            generalcourseobj.linkmyresponsibilitiesclick();
            generalcourseobj.tabcontentmanagementclick();
            generalcourseobj.linkmyresponsibilitiesclick();
            generalcourseobj.tabcontentmanagementclick();
            generalcourseobj.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, "");
            generalcourseobj.buttoncontentsearchclick();
            driver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]"));
            driver.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "')]")).Click();
            Assert.IsTrue(generalcourseobj.ValidatePreviewButton_generalCourse());
        }
        [Test]
        public void C_As_a_content_administrator_able_to_preview_my_uploaded_GeneralCOurse_ManageCourse_7278()
        {
            generalcourseobj.ManageGeneralCourseCourse(browserstr);
          Assert.IsTrue(generalcourseobj.ValidatePreviewButton_generalCourse());
        }

        #endregion
        [Test]
        public void e100_Create_a_new_General_course()
        {
            GeneralCourse generalcourse = new GeneralCourse(driver);
         //   driver.UserLogin("admin", browserstr);
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.CreateGeneralCource(browserstr,"Yes");
        }

        [Test]
        public void e101nduct_a_simple_and_advanced_search_for_a_General_course()
        {

            //   driver.UserLogin("admin");
            // driver.openadminconsolepage();
            GeneralCourse generalcourse = new GeneralCourse(driver);
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            //generalcourse.buttoncoursecreationgoclick("General Course");
            //generalcourse.populatesummarygeneralcourse(driver, ExtractDataExcel.MasterDic_genralcourse["Title"], ExtractDataExcel.MasterDic_genralcourse["Desc"],9 );
            //generalcourse.populateCourseFilesform(driver);
            //generalcourse.buttoncreateclick(driver);

            string expectedresult = "1 Items";
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            generalcourse.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, "");


            Assert.IsTrue(generalcourse.buttoncontentsearchclick());
            //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


            //     driver.UserLogin("admin");
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            generalcourse.populatecontentsearchadvance("Exact phrase", ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, ExtractDataExcel.MasterDic_genralcourse["Desc"], 9);


            Assert.IsTrue(generalcourse.buttoncontentsearchclick());
            //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void e102_Manage_a_General_course()
        {
            GeneralCourse generalcourse = new GeneralCourse(driver);

            string expectedresult = " The changes were saved.";
            string actualresult = string.Empty;

            //    driver.UserLogin("admin");
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            //  documentpage.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_document["Title"], "9");


            //documentpage.buttoncontentsearchclick();
            generalcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, "Exact phrase");
            driver.Checkout();
            generalcourse.buttoncourseeditclick();
            generalcourse.populateeditclassroomsummaryform("testchange");
            actualresult = generalcourse.buttonsaveeditclassroomsaveclick();
            //    driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
         
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));

        }

        [Test]
        public void e103_Edit_the_Course_Files_for_a_General_course()
        {
            GeneralCourse generalcourse = new GeneralCourse(driver);

            string expectedresult = " The URL for the course was updated.";
            string actualresult = string.Empty;

            //     driver.UserLogin("admin");
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            //documentpage.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_document["Title"], "9");


            //documentpage.buttoncontentsearchclick();
            generalcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, "Exact phrase");
            driver.Checkout();
            //    generalcourse.buttoncourseeditclick();
            //   generalcourse.populateeditclassroomsummaryform("testchange");
            generalcourse.populateCourseFilesframe(driver);
            actualresult = generalcourse.buttoncoursefileseditclick();
            driver.Checkin();
            //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));

        }

        [Test]
        public void e104_Assign_a_survey_to_a_General_course()
        {
            GeneralCourse generalcourse = new GeneralCourse(driver);
            string expectedresult = " Remove";
            //    driver.UserLogin("admin");
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            generalcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, "Exact phrase");
            // classroomcourse.linkmanagesectionsclick();
            //  classroomcourse.linksearchresulttableclick();
            driver.Checkout();
            generalcourse.linkcontentmanagesurveyclick();
            generalcourse.linkassignsurveyclick();
            generalcourse.buttonsearchsurveyclick();
            generalcourse.selectcheckbox();
            string actualresult = generalcourse.savebuttonclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            //      driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public void e105_Delete_a_general_course()
        {
            GeneralCourse generalcourse = new GeneralCourse(driver);
            Document documentpage = new Document(driver);
            //       driver.UserLogin("admin");
            generalcourse.linkmyresponsibilitiesclick();
            generalcourse.tabcontentmanagementclick();
            //documentpage.tabcontentmanagementclick();
            //documentpage.populatecontentsearchsimple("Exact phrase", ExtractDataExcel.MasterDic_document["Title"], "9");


            //documentpage.buttoncontentsearchclick();
            generalcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr, "Exact phrase");

            string expectedresult = " The selected items were deleted.";
            //    driver.UserLogin("admin");
            //     classroomcourse.linkmyresponsibilitiesclick(driver);
            //     classroomcourse.buttonsearchgoclick(ExtractDataExcel.MasterDic_classrommcourse["Title"] + 9, "Exact phrase");
            //  classroomcourse.linkmanagesectionsclick();
            //  classroomcourse.linksearchresulttableclick();

            string actualresult = documentpage.buttondeletesectionclick();
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actualresult));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driver.UserLogin("admin", browserstr);
            }
        }
    }
}
