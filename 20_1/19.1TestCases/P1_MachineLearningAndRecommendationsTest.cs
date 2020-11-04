using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
  //   [Parallelizable(ParallelScope.Fixtures)]
    public class P1MachineLearningAndRecommendationsTest : TestBase
    {
        string browserstr = string.Empty;
        public P1MachineLearningAndRecommendationsTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            InitializeBase(driver);
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

      
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
     
     
        [Test]
        public void a01_Admin_Option_to_enable_disable_the_people_like_me_recommendations_area_on_the_catalog_and_learner_home_pages_34799()
        {
            //Login with admin user
            Assert.IsTrue(HomePage.isRecommendedforYouPortletdisplay());
            _test.Log(Status.Pass, "Verify Recommended for You Portlet is displaying in Learner HomePage");
            CommonSection.ClickCatalog();
            _test.Log(Status.Info, "Navigate to Catalog Page");
            Assert.IsTrue(CatalogPage.isRecommendedforYouPortletdisplay());
            _test.Log(Status.Pass, "Verify Recommended for You Portlet is displaying in Catalog Page");
            CommonSection.Manage.Recommendations();
            _test.Log(Status.Info, "Navigate to Recommendation Page from Manage");
            RecommendationsPage.SimilarUsersContentProgress.Disabled();
            _test.Log(Status.Info, "Disabled Similar Users' Content Progress");
            //Assert.IsTrue(Driver.comparePartialString("Success", Driver.Instance.getSuccessMessage())); //The changes ware saved
            CommonSection.Learn.Home();
            _test.Log(Status.Info, "Navigate to back to Learner Homepage");
            Assert.IsFalse(HomePage.isRecommendedforYouPortletdisplay());
            _test.Log(Status.Pass, "Verify Recommended for You Portlet should not displaying in Learner HomePage");
            CommonSection.ClickCatalog();
            _test.Log(Status.Info, "Navigate to Catalog Page");
            Assert.IsFalse(CatalogPage.isRecommendedforYouPortletdisplay());
            _test.Log(Status.Pass, "Verify Recommended for You Portlet should not displaying in Catalog Page");
            CommonSection.Manage.Recommendations();
            RecommendationsPage.SimilarUsersContentProgress.Enabled();

        }
        
        [Test]
        public void a02_Test_to_see_related_similar_content_based_on_Tags_when_viewing_a_Content_Item_34827()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34827", generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Content Created");
            String expectedtagname = GeneralCoursePage.CreateTags(tagname);
            _test.Log(Status.Info, "Tag Created");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34827_1", generalcoursetitle + "TC34827_1");
            _test.Log(Status.Info, "Content Created");
            String expectedtagname1 = GeneralCoursePage.CreateTags(tagname);
            _test.Log(Status.Info, "Tag Created");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC34827" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            Assert.IsTrue(ContentDetailsPage.isrelatedContentDisplay(generalcoursetitle + "TC34827_1"));
            _test.Log(Status.Pass, "Verify similar content displaying in More like this Portlet");
        }
        [Test]
        public void a03_Admin_Enable_Disable_Similar_Content_34766()
        {
            //Login with admin user
            CommonSection.Manage.Recommendations();
            _test.Log(Status.Info, "Navigate to Recommendation Page from Manage");
            Assert.IsTrue(RecommendationsPage.Morelikethis.isEnabled());
            _test.Log(Status.Pass, "Verify More like this toggele is Enable state");
            CommonSection.SearchCatalog(generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            CommonSection.Manage.Recommendations();
            _test.Log(Status.Info, "Navigate to Recommendation Page from Manage");
            RecommendationsPage.Morelikethis.Disabled();
            _test.Log(Status.Info, "Disabled More like this toggele option");
            CommonSection.SearchCatalog(generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsFalse(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is not displaying in content details Page");

            CommonSection.Manage.Recommendations();
            RecommendationsPage.Morelikethis.Enabled();

        }
        [Test]
        public void a04_Test_to_see_related_similar_content_based_on_Keywords_when_viewing_a_Content_Item_34835()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34835", generalcoursetitle + "TC34835");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34835_1", generalcoursetitle + "TC34835");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC34835" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34835");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            Assert.IsTrue(ContentDetailsPage.isrelatedContentDisplay(generalcoursetitle + "TC34835_1"));
            _test.Log(Status.Pass, "Verify similar content displaying in More like this Portlet");
        }
       // [Test]not able to automate because of description field
        public void a05_Test_to_see_related_similar_content_based_on_Description_when_viewing_a_Content_Item_34837()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34837", generalcoursetitle + "TC34837");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddDescription(generalcoursedec + "TC34837");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34837_1", generalcoursetitle + "TC34837_1");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddDescription(generalcoursedec + "TC34837");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC34837" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34837");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            Assert.IsTrue(ContentDetailsPage.isrelatedContentDisplay(generalcoursetitle + "TC34837_1"));
            _test.Log(Status.Pass, "Verify similar content displaying in More like this Portlet");

        }
        [Test]
        public void a06_Test_to_see_related_similar_content_based_on_Categories_when_viewing_a_Content_Item_34836()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34836", generalcoursetitle + "TC34836");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddCategories("TC34836");
            string CourseCategory = ContentDetailsPage.CategoriesAccordian.Categoryname();
            GeneralCoursePage.ClickCheckIn();

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34836_1", generalcoursetitle + "TC34836_1");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddCategories("TC34836");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC34836" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34836");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            Assert.IsTrue(ContentDetailsPage.isrelatedContentMatch(CourseCategory));
        }
        [Test]
        public void a07_Test_to_see_related_similar_content_based_on_Credit_Types_when_viewing_a_Content_Item_34838()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34838", generalcoursetitle + "TC34838");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddCreditType("5");
            int creditType = ContentDetailsPage.CreditTypeAccordian.CreditTypeNumber();
            GeneralCoursePage.ClickCheckIn();

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34838_1", generalcoursetitle + "TC34838_1");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddCreditType("5");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC34838" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34838");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            Assert.IsTrue(ContentDetailsPage.isCreditTyperelatedContentDisplay(creditType));
        }
        [Test]
        public void a08_Test_to_see_related_similar_content_based_on_Course_Provider_when_viewing_a_Content_Item_34839()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34839", generalcoursetitle + "TC34839");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddCourseProvider("Meridian");
            string CourseProvider = ContentDetailsPage.CourseProviderAccodian.CourseProvidername();
            GeneralCoursePage.ClickCheckIn();

            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC34839_1", generalcoursetitle + "TC34839_1");
            _test.Log(Status.Info, "Content Created");
            GeneralCoursePage.AddCourseProvider("Meridian");
            GeneralCoursePage.ClickCheckIn();

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC34839" + '"');
            _test.Log(Status.Info, "Search a content from catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34839");
            _test.Log(Status.Info, "Click on searched content tilte");
            Assert.IsTrue(ContentDetailsPage.isMorelikethisPortletdisplay());
            _test.Log(Status.Pass, "Verify More like this Portlet is displaying in content details Page");
            Assert.IsTrue(ContentDetailsPage.isSameCourseProviderrelatedContentDisplay(CourseProvider));
        }
        [Test]

        public void b1_Save_Items_From_Recently_Added_34738()
        //Prerequisite - Recently added in recommendation must be Enabled

        {
           
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            Assert.IsTrue(HomePage.RecentlyAdded.isSaveButtonDisplyed());
            _test.Log(Status.Pass, "Verify Save Button is Displayed");
            HomePage.RecentlyAdded.ClickSaveButton();
            _test.Log(Status.Info, "Click Save Button in Recently Added Portlet");

            Assert.IsTrue(HomePage.RecentlyAdded.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Verify Save Button icon is Green");
            Assert.IsTrue(HomePage.RecentlyAdded.isTooltipDisplyed("Saved"));
            _test.Log(Status.Pass, "Verify Tooltip Display Saved and the content get Saved");
            HomePage.RecentlyAdded.ClickSaveButton();
            _test.Log(Status.Info, "Click Save Button in Recently Added Portlet");
            Assert.IsFalse(HomePage.RecentlyAdded.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Verify Save Button icon is Plane");
            Assert.IsTrue(HomePage.RecentlyAdded.isTooltipDisplyed("Save"));
            _test.Log(Status.Pass, "Verify Tooltip Display Save and the content get UnSaved");
            HomePage.RecentlyAdded.ClickSaveButton();
            _test.Log(Status.Info, "Click Save Button in Recently Added Portlet");
            CommonSection.Dropdowntoggle.SavedContent();
            _test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");
            Assert.IsTrue(SavedContentPage.isSavedDataDisplayed(""));
            _test.Log(Status.Pass, "Saved content get Displayed");
            SavedContentPage.ClickSaveButton();
            _test.Log(Status.Info, "Click Save Button in Saved content Page");
            Assert.IsTrue(SavedContentPage.isToolTipDisplayed("Save"));
            _test.Log(Status.Pass, "Verify Tooltip Display Save and the content get UnSaved");
            CommonSection.Dropdowntoggle.SavedContent();
            _test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");
            Assert.IsFalse(SavedContentPage.isSavedDataDisplayed(""));
            _test.Log(Status.Pass, "Saved content is not Displayed");


        }


        [Test]
        public void b2_Save_Items_From_More_Like_This_Similar_Content_34774()
        //Prerequisite - Recently added in recommendation must be Enabled

        {
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout of the Site Admin Account");
            //LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            //_test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.SearchCatalog(generalcoursetitle + "TC34835");
            //CommonSection.SearchCatalog(generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Click Catalog Search Button");

            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34835");// generalcoursetitle + "TC34827");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.isMoreLikeThisDisplayed());
            _test.Log(Status.Pass, "Verify More Like This Portlet is Displayed");
            ContentDetailsPage.MorelikethisPortlet.ClickSaveButton(generalcoursetitle + "TC34835");
            _test.Log(Status.Info, "Click Save Button in More Like This");
            //Assert.IsTrue(ContentDetailsPage.MorelikeThis.isSaveButtonIconGreen("GC_Reg0101491949TC34827"));
            //_test.Log(Status.Pass, "Verify Save Button icon is Green");
           // Assert.IsTrue(ContentDetailsPage.MorelikethisPortlet.isToolTipDisplayed("Saved"));
           // _test.Log(Status.Pass, "Verify Tooltip Display Saved and the content get Saved");
            string ContentSaved = ContentDetailsPage.MorelikethisPortlet.ContentTitle();
            //ContentDetailsPage.MorelikeThis.ClickSaveButton();
            //_test.Log(Status.Info, "Click Save Button in More Like This");
            //Assert.IsFalse(ContentDetailsPage.MorelikeThis.isSaveButtonIconGreen());
            //_test.Log(Status.Pass, "Verify Save Button icon is Plane");
            //Assert.IsTrue(ContentDetailsPage.MorelikeThis.isToolTipDisplayed("Save"));
            //_test.Log(Status.Pass, "Verify Tooltip Display Save and the content get UnSaved");
            //ContentDetailsPage.MorelikeThis.ClickSaveButton();
            //_test.Log(Status.Info, "Click Save Button in More Like This");
            CommonSection.Dropdowntoggle.SavedContent();
            _test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");
            Assert.IsTrue(SavedContentPage.isSavedDataDisplayedinResult(ContentSaved));
            _test.Log(Status.Pass, "Verify content is Displayed");
            //SavedContentPage.ClickSaveButton();
            //_test.Log(Status.Info, "Click Save Button in Saved content Page");
            //CommonSection.Dropdowntoggle.SavedContent();
            //_test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");
            //Assert.IsFalse(SavedContentPage.isSavedDataDisplayed(""));
            //_test.Log(Status.Pass, "Saved content is not Displayed");


        }

        [Test]

        public void b3_Save_Item_Form_Content_Details_34775()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC34835");
            CommonSection.SearchCatalog(generalcoursetitle + "TC34835");
            _test.Log(Status.Info, "Click Catalog Search Button");
            //  CommonSection.SearchCatalog("");
            // _test.Log(Status.Info, "Click Catalog Search Button");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC34835");
            _test.Log(Status.Info, "Click on Course Title");
            ContentDetailsPage.ClickSaveButton();
            _test.Log(Status.Info, "Click on Save Button of Content Detail Page");
            Assert.IsTrue(ContentDetailsPage.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Verify Save Button icon is Green");
            Assert.IsTrue(ContentDetailsPage.isToolTipDisplayed("Saved"));
            _test.Log(Status.Pass, "Verify Tooltip Display Saved");
            //ContentDetailsPage.ClickSaveButton();
            //_test.Log(Status.Info, "Click on Save Button of Content Detail Page");
            //Assert.IsFalse(ContentDetailsPage.isSaveButtonIconGreen());
            //_test.Log(Status.Pass, "Verify Save Button icon is Plane");
            //Assert.IsTrue(ContentDetailsPage.isToolTipDisplayed("Save"));
            //_test.Log(Status.Pass, "Verify Tooltip Display Save and the content get UnSaved");
            //ContentDetailsPage.ClickSaveButton();
            //_test.Log(Status.Info, "Click on Save Button of Content Detail Page");
            CommonSection.Dropdowntoggle.SavedContent();
            _test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");
            Assert.IsTrue(SavedContentPage.isSavedDataDisplayedinResult(generalcoursetitle + "TC34835"));
            _test.Log(Status.Pass, "Verify content is Displayed");
            //Assert.IsTrue(SavedContentPage.isSavedDataDisplayed(""));
            //_test.Log(Status.Pass, "Verify content is Displayed");
            //SavedContentPage.ClickSaveButton();
            //_test.Log(Status.Info, "Click Save Button in Saved content Page");
            //Assert.IsFalse(SavedContentPage.isSaveButtonIconGreen());
            //_test.Log(Status.Pass, "Verify Save Button icon is Plane");
            //Assert.IsTrue(SavedContentPage.isToolTipDisplayed("Save"));
            //_test.Log(Status.Pass, "Verify Tooltip Display Save and the content get UnSaved");
            //CommonSection.Dropdowntoggle.SavedContent();
            //_test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");
            //Assert.IsFalse(SavedContentPage.isSavedDataDisplayed(""));
            //_test.Log(Status.Pass, "Saved content is not Displayed");

        }
        

        [Test]
        public void b4_Save_Item_Based_on_Interest_34740()
        //Prerequisite - Based on Interest in Recommendation must be Enabled
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with Learner's Account");
            //CommonSection.ClickHome();
            //_test.Log(Status.Info, "Click Home From Common Section");

            Assert.IsTrue(HomePage.BasedOnYourInterest.isDisplayed());
            _test.Log(Status.Pass, "Verify Based On Your Interest Portlet is Displayed ");

            Assert.IsTrue(HomePage.BasedOnYourInterest.isSaveButtonDispalyed());
            _test.Log(Status.Pass, "Verify in Based On Your Interest Portlet Save Button is Displayed ");

            if(HomePage.BasedOnYourInterest.isSaveButtonIconGreen()==true)
            {
                Assert.IsTrue(HomePage.BasedOnYourInterest.isToolTipDisplayed("Saved"));
                _test.Log(Status.Pass, "Verify Tooltip Display Saved");

                HomePage.BasedOnYourInterest.ClickSaveButton();
                _test.Log(Status.Info, "Click on Content Save Button");

                Assert.IsFalse(HomePage.BasedOnYourInterest.isSaveButtonIconGreen());
                _test.Log(Status.Pass, "Verify Save Button icon is Plane");

                Assert.IsTrue(HomePage.BasedOnYourInterest.isToolTipDisplayed("Save"));
                _test.Log(Status.Pass, "Verify Tooltip Display Save and the content get UnSaved");
                HomePage.BasedOnYourInterest.ClickSaveButton();
                _test.Log(Status.Info, "Click on Content Save Button");
            }
            else
            {
                HomePage.BasedOnYourInterest.ClickSaveButton();
                _test.Log(Status.Info, "Click on Content Save Button");
                Assert.IsTrue(HomePage.BasedOnYourInterest.isSaveButtonIconGreen());
                _test.Log(Status.Pass, "Verify Save Button icon is Green ");
                Assert.IsTrue(HomePage.BasedOnYourInterest.isToolTipDisplayed("Saved"));
                _test.Log(Status.Pass, "Verify Tooltip Display Saved");
            }
             
           

            CommonSection.Learn.SavedContent();
            _test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");

            Assert.IsTrue(SavedContentPage.isSavedDataDisplayed(""));
            _test.Log(Status.Pass, "Verify content is Displayed");

            SavedContentPage.ClickSaveButton();
            _test.Log(Status.Info, "Click Save Button in Saved content Page");

            Assert.IsFalse(SavedContentPage.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Verify Save Button icon is Plane");

            Assert.IsTrue(SavedContentPage.isToolTipDisplayed("Save"));
            _test.Log(Status.Pass, "Verify Tooltip Display Save and the content get UnSaved");

            CommonSection.Learn.SavedContent();
            _test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");

            Assert.IsFalse(SavedContentPage.isSavedDataDisplayed(""));
            _test.Log(Status.Pass, "Saved content is not Displayed");

        }
        [Test]
        public void b5_Access_Saved_Content_34769()
        {
            //this is a test
            //CommonSection.Logout();
            //_test.Log(Status.Info, "Logout of the Site Admin Account");
            //LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            //_test.Log(Status.Info, "Login with Learner's Account");
            CommonSection.Learn.SavedContent();
            _test.Log(Status.Info, "Open Saved Content Form Dropdown Toggle");
            Assert.IsFalse(SavedContentPage.isPanelResetOptionDisplayed());
            _test.Log(Status.Pass, "Verify Panel Reset option is Not Displayed ");
            Assert.IsTrue(SavedContentPage.isSavedDataListDisplayed());
            _test.Log(Status.Pass, "Verify Saved Content List is Displayed ");
            Assert.IsTrue(SavedContentPage.isSavedContentTitleDisplayed());
            _test.Log(Status.Pass, "Verify content title is Displayed ");
            Assert.IsTrue(SavedContentPage.isProgressStatusDisplayed());
            _test.Log(Status.Pass, "Verify progerss Status is Displayed ");
            Assert.IsTrue(SavedContentPage.isDateSavedDisplayed());
            _test.Log(Status.Pass, "Verify Date Saved is Displayed ");
            SavedContentPage.ContentStatusFilterByStarted();
            //SavedContentPage.ContentStatusFilterBy("Started");
            _test.Log(Status.Info, "Content is Filtered by Status Started");
            Assert.IsTrue(SavedContentPage.isContentStatusFilterBy("Started"));
            _test.Log(Status.Pass, "Verify Content list is filtered with Status Started  ");
            SavedContentPage.ContentStatusFilterByNotStarted();
            //SavedContentPage.ContentStatusFilterBy("Not Started");
            _test.Log(Status.Info, "Content is Filtered by Status Not Started ");
            Assert.IsTrue(SavedContentPage.isSavedDataListDisplayed());
            _test.Log(Status.Pass, "Verify Content list is filtered with Status Not Started");
            SavedContentPage.ContentStatusFilterByCompleted();
            //SavedContentPage.ContentStatusFilterBy("Completed");
            _test.Log(Status.Info, "Content is Filtered by Status Completed");
            Assert.IsTrue(SavedContentPage.isContentStatusFilterBy("Completed"));
            _test.Log(Status.Pass, "Verify Content list is filtered with Status Completed ");
            SavedContentPage.ContentTitle.AToZAssesdingOrder();
            _test.Log(Status.Info, "Content is Filtered by Alphabets in Ascending");
            //Assert.IsTrue(SavedContentPage.ContentTitle.isFilteredIn("Ascending Order"));
            //_test.Log(Status.Pass, "Verify Content list is filtered in Ascending order of Alphabets ");
            SavedContentPage.ContentTitle.ZToADescendingOrder();
            _test.Log(Status.Info, "Content is Filtered by Alphabets in Descending");
            //Assert.IsTrue(SavedContentPage.ContentTitle.isFilteredIn("Descending Order"));
            //_test.Log(Status.Pass, "Verify Content list is filtered in Descending order of Alphabets ");

            //SavedContentPage.ContentTitleFilterBy("Date Saved").Sorting("Ascending").VerifySorting();
            //_test.Log(Status.Info, "Content is Filtered by Date Saved in Ascending order");
            //SavedContentPage.ContentTitleFilterBy("Date Saved").Sorting("Descending").VerifySorting();
            //_test.Log(Status.Info, "Content is Filtered by Date Saved in Descending order");
            //SavedContentPage.ContentTitleFilterBy("Rating").Sorting("Ascending").VerifySorting();
            //_test.Log(Status.Info, "Content is Filtered by Rating in Ascending order");
            //SavedContentPage.ContentTitleFilterBy("Rating").Sorting("Descending").VerifySorting();
            //_test.Log(Status.Info, "Content is Filtered by Rating in Descending order");
            //SavedContentPage.ContentTitleFilterBy("Cost").Sorting("Ascending").VerifySorting();
            //_test.Log(Status.Info, "Content is Filtered by Cost in Ascending order");
            //SavedContentPage.ContentTitleFilterBy("Cost").Sorting("Descending").VerifySorting();
            //_test.Log(Status.Info, "Content is Filtered by Cost in Descending order");
            //Assert.IsTrue(SavedContentPage.isPanelResetOptionDisplayed());
            //_test.Log(Status.Pass, "Verify Panel rest option is Displayed ");
            //SavedContentPage.ClickPanelResetOption();
            //_test.Log(Status.Info, "Click on Panel Reset Option");
            //Assert.IsFalse(SavedContentPage.isPanelResetOptionDisplayed());
            //_test.Log(Status.Pass, "Verify Panel Reset option is Not Displayed ");

        }




    }


}


