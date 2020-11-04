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

namespace Selenium2.Meridian.Suite.MyOwnLearning
{
    [TestFixture("ffbs")]
    [TestFixture("chbs")]
    [TestFixture("iebs")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ReserveSeats : TestBase
    {
        string browserstr = string.Empty;
        public ReserveSeats(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        public TrainingHomes TrainingHomeobj;
        public BrowseTrainingCatalog BrowseTrainingCatalogobj;
        static TrainingCatalogUtil TrainingCatalogobj;
        public SearchResults SearchResultsobj;
        static MyOwnLearningUtils MyOwnLearningobj;
        static Document documentobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            TrainingCatalogobj = new TrainingCatalogUtil(driver);
            documentobj = new Document(driver);
            TrainingHomeobj = new TrainingHomes(driver);
            BrowseTrainingCatalogobj = new BrowseTrainingCatalog(driver);
            SearchResultsobj = new SearchResults(driver);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            driver.UserLogin("admin1", browserstr);
            documentobj.CreateDocuemntCourse(browserstr);
        }

        [SetUp]
        public void SetUp()
        {

            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);

            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        #region Titans_Team3
        [Test]
        public void E_Learner_should_see_all_content_results_that_align_with_language_preferences_9212()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("", browserstr);
            Contentobj.addLocale("Italian");
            Contentobj.Edit_localeTitle(browserstr + "Italian");
            Contentobj.addLocale("Spanish (Spain)");
            Contentobj.Edit_localeTitle(browserstr + "Spanish");
            Contentobj.addLocale("Russian");
            Contentobj.Edit_localeTitle(browserstr + "Russian");
            Contentobj.Click_CheckIn();

            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_MyOwnLearning();
            TrainingHomeobj.Click_TrainingCatalogLink();
            //   BrowseTrainingCatalogobj.clear_languagePreferences();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
            //  BrowseTrainingCatalogobj.select_languagePreferences("English (US)");
            BrowseTrainingCatalogobj.Click_Search();
            Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));

            TrainingHomeobj.Click_TrainingCatalogLink();
            //  BrowseTrainingCatalogobj.clear_languagePreferences();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Italian");
            //BrowseTrainingCatalogobj.select_languagePreferences("Italian");
            BrowseTrainingCatalogobj.Click_Search();
            BrowseTrainingCatalogobj.select_languagePreferences("Italian");
            Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Italian"));

            TrainingHomeobj.Click_TrainingCatalogLink();
            //  BrowseTrainingCatalogobj.clear_languagePreferences();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Spanish");

            BrowseTrainingCatalogobj.Click_Search();
            BrowseTrainingCatalogobj.select_languagePreferences("Spanish (Spain)");
            Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Spanish"));

            TrainingHomeobj.Click_TrainingCatalogLink();
            //  BrowseTrainingCatalogobj.clear_languagePreferences();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Russian");

            BrowseTrainingCatalogobj.Click_Search();
            BrowseTrainingCatalogobj.select_languagePreferences("Russian");
            Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Russian"));

            TrainingHomeobj.Click_TrainingCatalogLink();
            //  BrowseTrainingCatalogobj.clear_languagePreferences();
            BrowseTrainingCatalogobj.Populate_SearchText(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr);
            //BrowseTrainingCatalogobj.select_languagePreferences("Russian");
            BrowseTrainingCatalogobj.Click_Search();
            //Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Russian"));
            //Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Spanish"));
            //Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "Italian"));
            Assert.IsTrue(SearchResultsobj.verify_searchObject(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr));

        }
     
        #endregion
        [Test]
        public void a_Conduct_a_simple_and_advanced_search_for_a_course_conten()
        {
            string actualresult = "1 seats left";
            TrainingCatalogobj.createcategories();
            TrainingCatalogobj.Create_Classroom_Course_and_Section(browserstr);
            //MyOwnLearningobj.CreateGeneralCourse(1, "site_search");
            TrainingCatalogobj.searchcourse(browserstr);
            Assert.IsTrue(TrainingCatalogobj.CheckSearchedItem(browserstr));
            TrainingCatalogobj.Advancesearchcourse(browserstr);
            Assert.IsTrue(TrainingCatalogobj.CheckSearchedItem(browserstr));
        }

        [Test]
        public void b_Select_a_category_from_the_category_list()
        {
            Assert.IsTrue(TrainingCatalogobj.selectfromcategory());
        }

        [Test]
        public void c_Select_a_sub_category_from_the_category_list()
        {
            Assert.IsTrue(TrainingCatalogobj.selectfromsubcategory(browserstr));
        }

        [Test]
        public void d_Click_See_all_content_in_this_category_if_browsing_a_sub_category()
        {

            Assert.IsTrue(TrainingCatalogobj.viewallcontentfromcategory(browserstr));
        }
        [Test]
        public void e_Conduct_a_simple_search_for_a_course_content_within_the_category_if_browsing_a_sub_category()
        {
            Assert.IsTrue(TrainingCatalogobj.searchforcourseincategory(browserstr));
        }

        [Test]
        public void f_Apply_faceted_search_keyword_category_type_cost_rating_course_provider_filters_to_the_search_results()
        {

            Assert.IsTrue(TrainingCatalogobj.facetsearch());
        }

        public void g_Click_See_More_for_each_faceted_category()
        {

        }
        [Test]
        public void h_Click_the_Classroom_Calendar_View_link()
        {

            Assert.IsTrue(TrainingCatalogobj.CalenderSwitchToMonth(browserstr));
        }
        [Test]
        public void i_Click_the_Print_link()
        {
            Assert.IsTrue(TrainingCatalogobj.Print(browserstr));
        }

        [Test]
        public void j_Launch_applicable_content_courses_from_the_search_results()
        {
            Assert.IsTrue(TrainingCatalogobj.LaunchAllpicableContent_CourseFromSearchResilts(browserstr));
        }
        [Test]
        public void k_Click_on_a_course_link_Classroom_SCORM_1_2_SCORM_2004_AICC_General_Curriculum_Certification_Test_Bundle_Subscriptions()
        {
            Assert.IsTrue(TrainingCatalogobj.checkcourses());
        }
        [Test]
        public void l_Click_on_a_content_link_Announcement_FAQ_Documents_Site_Surveys_Product_Collaboration_Spaces_Blog_Homepage_Feed()
        {
            Assert.IsTrue(TrainingCatalogobj.checkcontent());
        }
        public void m_Click_Express_Interest_Link()
        {

        }
        [Test]
        public void n_Switch_currency_CourseAndContent_item_Cost()
        {
            Assert.IsTrue(TrainingCatalogobj.SwitchCurrencyCourse_Contentitem_cost(browserstr));
        }
        [TearDown]
        public void TearDown()
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
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.Quit();
        }

        #region changesforpofrevertedforxg
        //        using System;
        //using System.Collections.Generic;
        //using System.Linq;
        //using System.Text;
        //using Selenium2;
        //using OpenQA.Selenium;
        //using NUnit.Framework;
        //using Selenium2.Meridian;
        //using System.Threading;
        //using TestAutomation.Meridian.Regression_Objects;

        //namespace Selenium2.Meridian.Suite.MyOwnLearning
        //{
        //    [TestFixture("ffbs")]
        //[TestFixture("chbs")]
        //[TestFixture("iebs")]
        //[Parallelizable(ParallelScope.Fixtures)]
        //     class TrainingCatalog : Selenium2TestBase
        //    {

        //        public static IWebDriver driver;
        //        public TrainingHomes traininghomeobj;
        //        public AdministrationConsoles administraionconsoleobj;
        //        public Categories Categoriesobj;
        //        public ContentSearch ContentSearchobj;
        //        public Create Createobj;
        //        public Content Contentobj;
        //        public BrowseTrainingCatalog BrowseTrainingCatalogobj;
        //        static TrainingCatalogUtil TrainingCatalogobj;
        //        public SearchResults SearchResultsobj;
        //        public Training Trainingobj;

        //        [OneTimeSetUp]
        //        public void OneTimeSetUp()
        //        {
        //            Common.closeie();
        //            driver = StartBrowser();
        //            driver.Manage().Window.Maximize();
        //            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        //            TrainingCatalogobj = new TrainingCatalogUtil(driver);
        //            Categoriesobj = new Categories(driver);
        //            Trainingobj = new Training(driver);
        //            ContentSearchobj = new ContentSearch(driver);
        //            Createobj = new Create(driver);
        //            Contentobj = new Content(driver);



        //            traininghomeobj = new TrainingHomes(driver);
        //            administraionconsoleobj = new AdministrationConsoles(driver);
        //            BrowseTrainingCatalogobj = new BrowseTrainingCatalog(driver);
        //            SearchResultsobj = new SearchResults(driver);

        //        }
        //        [SetUp]
        //        public void starttest()
        //        {
        //            Meridian_Common.islog = false;
        //int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
        //int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
        //Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        //        }

        //        //[Test]
        //        //public void a_Open_Training_Catalog_Item()
        //        //{
        //        //    driver.UserLogin("admin1",browserstr);
        //        //    Assert.IsTrue(TrainingHomeobj.isTrainingHome(), "Unable to Find Training Home Page");
        //        //    Assert.IsTrue(TrainingHomeobj.Click_TrainingCatalogLink(), "Unable to Click on Training Catalog Link");
        //        //    Assert.IsTrue(BrowseTrainingCatalogobj.Populate_SearchText(Variables.classroomCourseTitle), "Unable to Enter Search Text");
        //        //    Assert.IsTrue(BrowseTrainingCatalogobj.Set_SearchType(), "Unable to set Filter Type");
        //        //    Assert.IsTrue(BrowseTrainingCatalogobj.Click_Search(), "Unable to Search Training Catalog Record");
        //        //    Assert.IsTrue(SearchResultsobj.Content_Click(), "Unable to Find and Click on Search Result");

        //        //}

        //        [Test]
        //        public  void a_Conduct_a_simple_and_advanced_search_for_a_course_conten()
        //        {
        //            string actualresult = "1 seats left";
        //            driver.UserLogin("admin1",browserstr);
        //            traininghomeobj.isTrainingHome();
        //            traininghomeobj.Click_AdminConsoleLink();
        //            administraionconsoleobj.Click_OpenItemLink("Categories");
        //            Categoriesobj.Click_CreateGoTo();
        //            Categoriesobj.Populate_CreateForm();
        //            Categoriesobj.Click_CreateCategory();

        //            traininghomeobj.MyResponsiblities_click();
        //            Trainingobj.SearchContent_Click();
        //            ContentSearchobj.NewContent("ML.BASE.COURSEWARE.CLASSROOM");
        //            Createobj.FillClassroomCoursePage("");

        //            //Content.MyResponsiblities_click();
        //            //Training.SearchContent_Click();
        //            //ContentSearch.Simple_Search( Variables.subscriptionTitle);
        //            //ContentSearch.Content_Click();
        //            //Content.Edit_Content();
        //            //AddContent.SearchAndAddContent();
        //            ////String assertion on adding training activities
        //          //  String successMsg = objAddContent.SuccessMsg();
        //            String successMsg = string.Empty;
        //            StringAssert.Contains("The selected items were added. Note: If inactive items were added, users will not be able to access them.", successMsg);




        //            driver.UserLogin("admin1",browserstr);
        //           TrainingCatalogobj.createcategories();
        //            TrainingCatalogobj.Create_Classroom_Course_and_Section();
        //            TrainingCatalogobj.searchcourse();
        //            StringAssert.Contains(TrainingCatalogobj.CheckSearchedItem(), actualresult);
        //            TrainingCatalogobj.Advancesearchcourse();
        //            StringAssert.Contains(TrainingCatalogobj.CheckSearchedItem(), actualresult);
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        }

        //        [Test]
        //        public static void b_Select_a_category_from_the_category_list()
        //        {
        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.selectfromcategory());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //        }

        //        [Test]
        //        public static void c_Select_a_sub_category_from_the_category_list()
        //        {
        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.selectfromsubcategory());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //        }

        //        [Test]
        //        public static void d_Click_See_all_content_in_this_category_if_browsing_a_sub_category()
        //        {

        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.viewallcontentfromcategory());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        }
        //        [Test]
        //        public static void e_Conduct_a_simple_search_for_a_course_content_within_the_category_if_browsing_a_sub_category()
        //        {
        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.searchforcourseincategory());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        }

        //        [Test]
        //        public static void f_Apply_faceted_search_keyword_category_type_cost_rating_course_provider_filters_to_the_search_results()
        //        {

        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.facetsearch());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //        }

        //        public static void g_Click_See_More_for_each_faceted_category()
        //        {
        //            driver.UserLogin("admin1",browserstr);

        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //        }

        //        [Test]
        //        public static void h_Click_the_Classroom_Calendar_View_link()
        //        {

        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.CalenderSwitchToMonth());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //        }
        //        [Test]
        //        public static void i_Click_the_Print_link()
        //        {

        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.Print());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        }

        //        [Test]
        //        public static void j_Launch_applicable_content_courses_from_the_search_results()
        //        {
        //            driver.UserLogin("admin1",browserstr);

        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //        }

        //        [Test]
        //        public static void k_Click_on_a_course_link_Classroom_SCORM_1_2_SCORM_2004_AICC_General_Curriculum_Certification_Test_Bundle_Subscriptions()
        //        {
        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.checkcourses());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //        }
        //        [Test]
        //        public static void l_Click_on_a_content_link_Announcement_FAQ_Documents_Site_Surveys_Product_Collaboration_Spaces_Blog_Homepage_Feed()
        //        {
        //            driver.UserLogin("admin1",browserstr);
        //            Assert.IsTrue(TrainingCatalogobj.checkcontent());
        //            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        }

        //        [OneTimeTearDown]
        //        public void OneTimeTearDown()
        //        {

        //            driver.Quit();
        //        }

        //    }
        //}

        #endregion

    }
}
