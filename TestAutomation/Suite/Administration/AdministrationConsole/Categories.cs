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

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Categories : TestBase
    {
        string browserstr = string.Empty;
        public Categories(string browser)
            : base(browser)
        {
            browserstr = browser;
        } 
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
            
        }
        [SetUp]
        public void starttest()
        {

            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin1",browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void Create_Category_21003()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")); //Clicked on Log In
            #endregion
            #region navigate to  Categories
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Content Categories')]"));
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verify the page contains Categories heading
            #endregion
            #region Create Categories
            driver.FindElement(By.XPath("//option[contains(.,'Create New')]"));
            driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.DataGridSimpleSearch']")); //Selected Create New
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']")); //Clicked on Go button
            driver.FindElement(By.XPath("//span[contains(.,'New Category')]")); //Verified New Categories page is displayed
            driver.FindElement(By.XPath("//input[contains(@value,'Create')]")); //Verified 'Create' button is displayed
            driver.FindElement(By.XPath("//input[contains(@value,'Cancel')]")); //Verified 'Cancel' button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE']")); //Entered Title "Dolly's Category_04232017"
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_DESCRIPTION']")); //Entered Description ""Dolly's Category_04232017"
            driver.FindElement(By.XPath("//select[@currentvalue='ROOT']")); //Parent Category as Root
            driver.FindElement(By.XPath("//nobr[contains(.,'Preview')]")); //Clicked the Preview Tab, Preview of the data entered is displayed
            driver.FindElement(By.XPath("//nobr[contains(.,'Edit Category')]")); //Clicked the Edit Category tab again and verified the data still intact
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Create']")); //Clicked the Create button
            driver.FindElement(By.XPath("//span[contains(.,'The new category was created.')]")); //Verified the Success feedback is displayed
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.CategoryManagement']")); //Click on Category Management page
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_DataGridItem_CTGY_CATEGORY_ID']")); //Verified the Category created is displayed in Data Grid (I cannot capture the Category) 
            driver.FindElement(By.XPath("//nobr[contains(.,'Category Hierarchy')]")); //Select Category Hierarchy tab
            driver.FindElement(By.XPath("//span[@class='   ']")); //Verified the Category is included in Hierarchy
            #endregion
            #region Return to Categories page
            driver.FindElement(By.XPath("//input[@id='Return']")); //Return from Edit Categories page
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verified Categories page is displayed
            #endregion

        }
        [Test]
        public void Edit_Category_21004()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")); //Clicked on Log In
            #endregion
            #region navigate to  Categories
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Content Categories')]"));
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verify the page contains Categories heading
            #endregion
            #region Search Category
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")); //Search for the Category "Dolly's"
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")); //Clicked on Search
            #endregion
            #region Edit category
            driver.FindElement(By.XPath("//select[@contenttype='CATEGORIES']")); //Selected Edit Action dropdown
            driver.FindElement(By.XPath("//option[contains(.,'Edit')]")); //Selected Edit from Action drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_GoButton']")); //Clicked on Go
            driver.FindElement(By.XPath("//span[@title='Edit Category']")); //Verified Edit Category page is displayed
            driver.FindElement(By.XPath("//nobr[contains(.,'Edit Category')]")); //Verified the Edit Category tab is displayed with data
            driver.FindElement(By.XPath("//nobr[contains(.,'Preview')]")); //Verified the Preview tab is displayed
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")); //Verified Save button is displayed
            driver.FindElement(By.XPath("//input[@id='Return']")); //Verified Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE']")); //Edited the Title field "Dolly's Category_04232017_a"
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_DESCRIPTION']")); //Edited the Description field "Dolly's Category_04232017_a"
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")); //Clicked on Save
            driver.FindElement(By.XPath("//span[contains(.,'The summary information changes were saved.')]")); //Verified the Success feedback is displayed
            driver.FindElement(By.XPath("//nobr[contains(.,'Preview')]")); //Verified the Preview tab displays the changed information
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.CategoryManagement']")); //Clicked on Categories breadcrumb
            driver.FindElement(By.XPath("//span[contains(@id,'FeedbackCategoryListingDataGrid')]")); //Verified the Search feedback contains the Category created
            driver.FindElement(By.XPath("//nobr[contains(.,'Category Hierarchy')]"));
            #endregion
            #region Return to Categories page
            driver.FindElement(By.XPath("//input[@id='Return']")); //Return from Edit Categories page
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verified Categories page is displayed
            #endregion
        }
        [Test]
        public void Delete_Category_21005()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")); //Clicked on Log In
            #endregion
            #region navigate to  Categories
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Content Categories')]"));
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verify the page contains Categories heading
            #endregion
            #region Search Category
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")); //Search for the Category "Dolly's"
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")); //Clicked on Search
            #endregion
            #region Delete Category
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_DataGridItem_CTGY_CATEGORY_ID']")); //Clicked on the Checkbox to delete "Dolly's Category_1"
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Delete']")); //Clicked on Delete
            driver.FindElement(By.XPath("//span[contains(.,'The category was deleted.')]")); //Verified the Category delete success message is received
            #endregion
        }
        [Test]
        public void View_Category_Content_21006()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")); //Clicked on Log In
            #region navigate to  Categories
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Content Categories')]"));
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verify the page contains Categories heading
            #endregion
            #endregion
            #region navigate to  Categories
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Content Categories')]"));
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verify the page contains Categories heading
            #endregion
            #region Search Category
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")); //Search for the Category "Dolly's"
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")); //Clicked on Search
            #endregion
            #region View Category Content
            driver.FindElement(By.XPath("//select[@contenttype='CATEGORIES']")); //Selected Edit Action dropdown
            driver.FindElement(By.XPath("//option[@value='ML.BASE.ACT.ViewContent']")); //Selected View Content option from dropdown
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_GoButton']")); //Clicked on Go button
            driver.FindElement(By.XPath("//nobr[contains(.,'Category Content')]")); //Verified Category Content page is displayed
            driver.FindElement(By.XPath("//span[@title='Category Content']")); //Verified the Title is displayed as Category Content
            driver.FindElement(By.XPath("//span[@id='TabMenu_ML_BASE_TAB_CategoryContent_FeedbackCategoryContentListingDataGrid']"));//Verified the Records found is displayed on the page
            driver.FindElement(By.XPath("//span[contains(.,'Title')]")); //Verified the datagrid heading Title is displayed
            driver.FindElement(By.XPath("//span[contains(.,'Type')]")); //Verified the datagrid heading Type is displayed
            driver.FindElement(By.XPath("//span[contains(.,'Activity')]")); //Verified the datagrid heading Activity is displayed  - Testcase states about Info Icon, I don't see
            #endregion
            #region Return to Categories page
            driver.FindElement(By.XPath("//input[@id='Return']")); //Return from Edit Categories page
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verified Categories page is displayed
            #endregion
            }
      //  [Test]cannot be automated
        public void Category_Sharing_25265()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']"));//created siteadmin account
            driver.FindElement(By.XPath("//input[@id='username']")); // Entered siteadmin
            driver.FindElement(By.XPath("//input[@id='password']")); //Entered password
            driver.FindElement(By.XPath("//input[@type='submit']")); //Clicked on Log In
            #endregion
            #region navigate to  Categories
            driver.FindElement(By.XPath("//a[contains(.,'Administer')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Training Management')]"));
            driver.FindElement(By.XPath("//a[contains(.,'Content Categories')]"));
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verify the page contains Categories heading
            #endregion
            #region Search Category
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")); //Search for the Category "Dolly's"
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']")); //Clicked on Search
            #endregion
            #region Edit category
            driver.FindElement(By.XPath("//select[@contenttype='CATEGORIES']")); //Selected Edit Action dropdown
            driver.FindElement(By.XPath("//option[contains(.,'Edit')]")); //Selected Edit from Action drop down
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_CategoryListingDataGrid_ctl02_GoButton']")); //Clicked on Go
            driver.FindElement(By.XPath("//span[@title='Edit Category']")); //Verified Edit Category page is displayed
            driver.FindElement(By.XPath("//nobr[contains(.,'Edit Category')]")); //Verified the Edit Category tab is displayed with data
            driver.FindElement(By.XPath("//nobr[contains(.,'Preview')]")); //Verified the Preview tab is displayed
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")); //Verified Save button is displayed
            driver.FindElement(By.XPath("//input[@id='Return']")); //Verified Return button is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE']")); //Edited the Title field "Dolly's Category_04232017_a"
            driver.FindElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_DESCRIPTION']")); //Edited the Description field "Dolly's Category_04232017_a"
            driver.FindElement(By.XPath("//input[@id='ML.BASE.BTN.Save']")); //Clicked on Save
            driver.FindElement(By.XPath("//span[contains(.,'The summary information changes were saved.')]")); //Verified the Success feedback is displayed
            driver.FindElement(By.XPath("//nobr[contains(.,'Preview')]")); //Verified the Preview tab displays the changed information
            driver.FindElement(By.XPath("//a[@pageid='ML.BASE.HEAD.CategoryManagement']")); //Clicked on Categories breadcrumb
            driver.FindElement(By.XPath("//span[contains(@id,'FeedbackCategoryListingDataGrid')]")); //Verified the Search feedback contains the Category created
            driver.FindElement(By.XPath("//nobr[contains(.,'Category Hierarchy')]"));
            #endregion
            #region Category Sharing 
            driver.FindElement(By.XPath("//span[contains(.,'Sharing')]")); //Clicked on Sharing tab
            driver.FindElement(By.XPath("//span[@title='Content Sharing']")); //Content Sharing page is dispayed - Cannot further test as there is no Domains for Sharing
            #endregion  
            #region Return to Categories page
            driver.FindElement(By.XPath("//input[@id='Return']")); //Return from Edit Categories page
            driver.FindElement(By.XPath("//span[contains(.,'Categories')]")); //Verified Categories page is displayed
            #endregion

        }

        //[Test]
        //public void a_Create_a_new_category()
        //{

        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_TrainingManagement_click();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Content Categories");
        //    Categoryobj.Click_CreateGoTo();
        //    Assert.IsTrue(Categoryobj.Click_Create("",browserstr));

        //}
        //[Test]
        //public void b_Conduct_a_search_for_a_category()
        //{


        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_TrainingManagement_click();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Content Categories");
        //    Assert.IsTrue(Categoryobj.Click_SearchCategories(browserstr));

        //}
        //[Test]
        //public void c_View_content_that_is_associated_to_a_category()
        //{

        //    TrainingHomeobj.MyResponsiblities_click();
        //    Trainingsobj.SearchContent_Click();
        //    ContentSearchobj.NewContent("General Course");
        //    Createobj.FillGeneralCoursePage("cat", browserstr);

        //    ////String Assertion on new curriculum creation 
        //    String successMsg = Contentobj.SuccessMsgDisplayed();
        //    StringAssert.Contains("The item was created.", successMsg);

        //    Contentobj.selectcategory(Variables.category+browserstr);
        //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //  driver.UserLogin("admin1",browserstr);
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_TrainingManagement_click();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Content Categories");
        //    Categoryobj.Click_SearchCategories(browserstr);
        //    Assert.IsTrue(Categoryobj.Click_ViewContent());

        //}
        //[Test]
        //public void d_Delete_a_category()
        //{

        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_TrainingManagement_click();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Content Categories");
        //    Categoryobj.Click_SearchCategories(browserstr);
        //    Assert.IsTrue(Categoryobj.Click_Delete());

        //}
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
                TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                driver.checkdisplay(By.Id("lbUserView"));
             
                
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
