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
    class AuditingConsole : TestBase
    {
        string browserstr = string.Empty;
        public AuditingConsole(string browser)
            : base(browser)
        {
            browserstr = browser+"auditingconsole";
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
     

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
        [Test,Order(1)]
        public void AuditingConsoleUserSearch_16459()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Navigate to Auditing Console
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
          //  driver.FindElement(By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Tools')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Audit Records')]"));
            driver.selectWindow("Auditing Console");
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Auditing Console')]"))); //Verified the heading displays Auditing Console
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'General Search')]"))); //Verified the General Search link is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'User Search')]"))); //Verified the User Search link is displayed
            #endregion
            #region User Search 
            driver.FindElement(By.XPath("//a[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.UserSearch']")).ClickWithSpace(); //Clicked on User Search link
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'User Name')]"))); // Verified User Name is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Audit Actions')]"))); //Verified Audit Actions is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Start Date')]"))); //Verified Start Date is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'End Date')]"))); //Verified End Date is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'ONLY include e-signature records')]"))); //Verified "Only include e-signature records" statement is dispayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchButton']")).ClickWithSpace(); //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Date/Time')]"))); //Table with date/time is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Title')]"))); //Table with Title is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Type')]"))); // Table with Type is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Audit Action')]"))); //Table with Audit Action is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Audit Record Action')]"))); //Table with Audit Record Action is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Performed By')]"))); //Table with Performaed by is displayed
            driver.ClickEleJs(By.XPath("//img[contains(@id,'But_AuditResults_AL_TRANSACTION_ID_0_01_1||')]")); //Expanded the 1st row by clicking on '+'
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Value')]"))); //Table with Value is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'Audit Actions')]"))); //Facet 'Audit Action' is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'Content Types')]"))); //Facet 'Content Types is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'System Actions')]"))); //Facet 'System Actions' is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'E-signature')]"))); //Facet 'E-signature' is displayed
            driver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_FacetedSearchParameter||AUDITTYPE||Modify']")); //Selected Create on Facet
            driver.FindElement(By.XPath("//input[@value='Refine Results']")).ClickWithSpace(); //Clicked on Refine Search
       //  Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(@id,'TabMenu_ML_BASE_TAB_Search_Feedback_']")));
            string ParentWIndow = driver.CurrentWindowHandle;
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_PrintRecords']")).ClickWithSpace(); //Clicked on Print Records
            driver.selectWindow("");
            driver.SelectWindowClose();
            driver.SwitchTo().Window(ParentWIndow);
          //  driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ExportRecords']")).ClickWithSpace(); //Clicked on Export Records
            #endregion
            #region Navigate to KI
            driver.Navigate_to_TrainingHome();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.LogoutHoverLink);
            #endregion
            }
        [Test, Order(2)]
        public void AuditingConsoleGeneralSearch_18427()
        {
            #region login
            driver.FindElement(By.XPath("//input[@id='MainContent_UC5_btnLogin']")).ClickWithSpace();//logging in
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeysWithSpace("siteadmin");//using regadmin account
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeysWithSpace("password");
            driver.FindElement(By.XPath("//input[@type='submit']")).ClickWithSpace();
            #endregion
            #region Navigate to Auditing Console
            driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-system']"));
            //  driver.FindElement(By.XPath("//a[@href='#admin-console-system']"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Tools')]"));
            driver.ClickEleJs(By.XPath("//a[contains(.,'Audit Records')]"));
            driver.selectWindow("Auditing Console");
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Auditing Console')]"))); //Verified the heading displays Auditing Console
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'General Search')]"))); //Verified the General Search link is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//a[contains(.,'User Search')]"))); //Verified the User Search link is displayed
            #endregion
            #region General Search
          //  driver.FindElement(By.XPath("//span[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.GeneralSearch']")).ClickWithSpace(); //Clicked on General Search
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Text')]"))); //Verified Search Text is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Search Type')]")));  //Verified Search Type is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Audit Actions')]"))); //Verified Audit Actions is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'Start Date')]"))); //Verified Start Date is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//span[contains(.,'End Date')]"))); //Verified End Date is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//label[contains(.,'ONLY include e-signature records')]"))); //Verified "Only include e-signature records" statement is dispayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchButton']")).ClickWithSpace();  //Clicked on Search button
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Date/Time')]"))); //Table with date/time is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Title')]"))); //Table with Title is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Type')]"))); // Table with Type is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Audit Action')]"))); //Table with Audit Action is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Audit Record Action')]"))); //Table with Audit Record Action is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Performed By')]"))); //Table with Performaed by is displayed
            driver.FindElement(By.XPath("//img[contains(@id,'But_AuditResults_AL_TRACKING_ID_0_01_1||']")).ClickWithSpace(); //Expanded the 1st row by clicking on '+'
            Assert.IsTrue(driver.existsElement(By.XPath("//td[contains(.,'Value')]"))); //Table with Value is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'Audit Actions')]"))); //Facet 'Audit Action' is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'Content Types')]"))); //Facet 'Content Types is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'System Actions')]"))); //Facet 'System Actions' is displayed
            Assert.IsTrue(driver.existsElement(By.XPath("//center[contains(.,'E-signature')]"))); //Facet 'E-signature' is displayed
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_FacetedSearchParameter||AUDITTYPE||Create']")); //Selected Create on Facet
            driver.FindElement(By.XPath("//input[@value='Refine Results']")).ClickWithSpace(); //Clicked on Refine Search
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_PrintRecords']")).ClickWithSpace(); //Clicked on Print Records
            driver.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ExportRecords']")).ClickWithSpace(); //Clicked on Export Records
            #endregion
        }
        //[Test]
        //public void a_Conduct_a_general_search_in_the_auditing_console()
        //{


        //    TrainingHomeobj.isTrainingHome();

        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_system_click();
        //    TrainingHomeobj.lnk_Tools_click();


        //    AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
        //    AuditingConsolesobj.Click_GeneralSearch();
        //    Assert.IsTrue(AuditingConsolesobj.Check_Search());

        //}
        //[Test]
        //public void b_Apply_the_faceted_search_filters_to_the_general_search_results()
        //{


        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_system_click();
        //    TrainingHomeobj.lnk_Tools_click();

        //    AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
        //    AuditingConsolesobj.Click_GeneralSearch();
        //    AuditingConsolesobj.Click_facet();
        //    Assert.IsTrue(AuditingConsolesobj.Click_refineresult());

        //}
        //[Test]
        //public void c_Conduct_a_user_search_in_the_auditing_console()
        //{

        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_system_click();
        //    TrainingHomeobj.lnk_Tools_click();

        //    AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
        //    AuditingConsolesobj.Click_lnkusersearch();
        //    AuditingConsolesobj.Click_UserSearch();
        //    Assert.IsTrue(AuditingConsolesobj.Check_SearchUser());

        //}

        //[Test]
        //public void d_Apply_the_faceted_search_filters_to_the_user_search_results()
        //{

        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.lnk_SystemOptions_click();
        //    TrainingHomeobj.lnk_system_click();
        //    TrainingHomeobj.lnk_Tools_click();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
        //    AuditingConsolesobj.Click_lnkusersearch();
        //    AuditingConsolesobj.Click_UserSearch();
        //    AuditingConsolesobj.Click_facet();
        //    Assert.IsTrue(AuditingConsolesobj.Click_refineresult());

        //}

        ////[Test]
        ////public void e_Print_the_search_results()
        ////{

        ////    driver.UserLogin("admin1",browserstr);
        ////    TrainingHomeobj.isTrainingHome();
        ////    TrainingHomeobj.Click_AdminConsoleLink();
        ////    AdminstrationConsoleobj.Click_OpenItemLink("Auditing Console");

        ////     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        ////}
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
                //TrainingHomeobj.lnk_Tools_click();
                //TrainingHomeobj.lnk_system_click();
                //TrainingHomeobj.lnk_SystemOptions_click();
                
                
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
