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
    class DomainManagement : TestBase
    {
        string browserstr = string.Empty;
        public DomainManagement(string browser)
            : base(browser)
        {
            browserstr = browser+"domman";
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
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
           
        }

        #region Titans_Team3
              [Test]
         public void A_RegressionTestTo_Validate_HTML_editing_and_500_characters_in_about_system_message_25090()
         {
             String longAboutText = "This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About";
             driver.Navigate_to_TrainingHome();
             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
             urlobj.Edit_aboutText(longAboutText);

             //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
             //driver.UserLogin("userforregression", browserstr);
             driver.Navigate_to_TrainingHome();
             TrainingHomeobj.Click_About();
             Assert.AreEqual(TrainingHomeobj.verify_aboutText(), longAboutText);

             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
        Assert.IsTrue(urlobj.Edit_aboutText("Test"));
         }
         [Test]
         public void B_RegressionTestTo_Validate_HTML_editing_and_500_characters_in_privacy_policy_25091()
         {
             String longPrivacyPolicy = "This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About";
             //driver.UserLogin("admin1", browserstr);
             driver.Navigate_to_TrainingHome();
             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
             urlobj.Edit_privacyPolicy(longPrivacyPolicy);

             //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
             //driver.UserLogin("userforregression", browserstr);
             driver.Navigate_to_TrainingHome();
             TrainingHomeobj.Click_privacyPolicy();
             Assert.AreEqual(TrainingHomeobj.verify_privacyPolicy(), longPrivacyPolicy);

             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
             urlobj.Edit_privacyPolicy("Test");

         }
         [Test]
         public void C_RegressionTestTo_Validate_HTML_editing_and_500_characters_in_terms_conditions_25087_25088()
         {
             String longTermsConditions = "This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About";
             //driver.UserLogin("admin1", browserstr);
             driver.Navigate_to_TrainingHome();
             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
             urlobj.Edit_termsConditions(longTermsConditions);

             //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
             //driver.UserLogin("userforregression", browserstr);
             driver.Navigate_to_TrainingHome();
             TrainingHomeobj.Click_termsConditions();
             Assert.AreEqual(TrainingHomeobj.verify_termsConditions(), longTermsConditions);

             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
            Assert.IsTrue(urlobj.Edit_termsConditions("Test"));
         }
         [Test]
         public void D_RegressionTestTo_Validate_HTML_editing_and_500_characters_in_welcome_message_11345()
         {
             String longWelcomeMessage = "This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About Text more than 500 characters This is a very long About";
             //driver.UserLogin("admin1", browserstr);
             driver.Navigate_to_TrainingHome();
             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
             urlobj.Edit_welcomeMessage(longWelcomeMessage);

             driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
             Assert.AreEqual(TrainingHomeobj.verify_welcomeMessage(), longWelcomeMessage);

             driver.UserLogin("admin1", browserstr);
             TrainingHomeobj.lnk_SystemOptions_click();
             TrainingHomeobj.lnk_system_click();
             TrainingHomeobj.lnk_DomainsandURLS_click();
             TrainingHomeobj.click_systemOptionsLink("URLs");
             urlobj.select_url();
             urlobj.Click_landingFooterText_tab();
           Assert.IsTrue(urlobj.Edit_welcomeMessage("Test"));
         }

        #endregion
       // [Test]
        public void a_Create_a_new_domain()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("URLs");
            urlobj.Click_AddUrl();
            urlobj.Click_nextnewUrl(browserstr);
            Assert.IsTrue(urlobj.Click_savenewUrl());
          
          driver.Navigate_to_TrainingHome();
          AdminstrationConsoleobj.Click_OpenItemLink("Domains");
          DomainConsoleobj.Click_CreateGoTo();
          DomainConsoleobj.Click_ParentDomain();
          DomainConsoleobj.Click_next();
        Assert.IsTrue(  DomainConsoleobj.Populate_domain(browserstr,"delete"));


        }

      //  [Test]
        public void m_Delete_a_domain()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr,"delete");
            DomainConsoleobj.Click_Membership();
            DomainConsoleobj.Click_search();
            DomainConsoleobj.Click_remove();
            DomainConsoleobj.Click_summary();
          Assert.IsTrue(  DomainConsoleobj.Click_DeleteDomain());
          
        }

      //  [Test]
        public void b_Select_an_existing_domain_from_the_tree_to_manage_the_domain()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_CreateGoTo();
        //    DomainConsoleobj.Click_selectDomain(browserstr, "delete");
            DomainConsoleobj.Click_ParentDomain();
            DomainConsoleobj.Click_next();
            Assert.IsTrue(DomainConsoleobj.Populate_domain(browserstr, ""));
            driver.Navigate_to_TrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            Assert.IsTrue(DomainConsoleobj.Click_selectDomain(browserstr, ""));

        }

     //   [Test]
        public void c_Edit_the_skins_for_a_domain()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_BrandingandCustomization_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Skins");
            skinobj.Click_creategoto();
           Assert.IsTrue( skinobj.Click_Createnewskin(browserstr));
           Assert.IsTrue(skinobj.Click_btnShare(browserstr));
           driver.Navigate_to_TrainingHome();
           TrainingHomeobj.lnk_DomainsandURLS_click();
           AdminstrationConsoleobj.Click_OpenItemLink("Domains");
          DomainConsoleobj.Click_selectDomain(browserstr, "");
          Assert.IsTrue(DomainConsoleobj.Click_Skin(browserstr));
             
        }

       // [Test]
        public void d_Rename_a_menu_item()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr, "");
            Assert.IsTrue(DomainConsoleobj.Click_Menu(browserstr));
        }

     //   [Test]
        public void e_Edit_the_domain_configuration_options()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr, "");
            Assert.IsTrue(DomainConsoleobj.Click_Option());
        }
    //    [Test]
        public void f_Select_a_domain_level_certificate()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr, "");
            DomainConsoleobj.Click_Certificatetab();
            DomainConsoleobj.Click_SearchCertificate();
           Assert.IsTrue( DomainConsoleobj.Click_SelectCertificate());

        }
    //    [Test]
        public void g_Select_a_homepage_feed_for_the_domain()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr, "");
            DomainConsoleobj.Click_homepagefeedtab();
            DomainConsoleobj.Click_Searchhomepagefeed();
            Assert.IsTrue(DomainConsoleobj.Click_Selecthomepagefeed());
        }

    //    [Test]
        public void h_Add_entities_to_the_domain_membership()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr, "");
            DomainConsoleobj.Click_Membership();
            DomainConsoleobj.Click_AddMembergoto();
            DomainConsoleobj.Click_searchmembertoadd();
           Assert.IsTrue( DomainConsoleobj.Click_AddMember());
        }

    //    [Test]
        public void i_Remove_entities_from_the_domain_membership()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr, "");
            DomainConsoleobj.Click_Membership();
            DomainConsoleobj.Click_search();
           Assert.IsTrue( DomainConsoleobj.Click_remove());
        }
   //     [Test]
        public void j_Edit_the_activity_for_a_domain()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            DomainConsoleobj.Click_selectDomain(browserstr, "");
            DomainConsoleobj.Click_activitytab();
            Assert.IsTrue(DomainConsoleobj.Click_Selectactivity()) ;
        }
   //     [Test]
        public void k_Edit_the_Privacy_Policy_Terms_of_Use()
        {
          
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("URLs");
       
            Assert.IsTrue(urlobj.Update_Privacy(browserstr));

        }
   //     [Test]
        public void l_Edit_the_Terms_and_Conditions()
        {
            
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("URLs");
            
            Assert.IsTrue(urlobj.Update_term(browserstr));
        }
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
                TrainingHomeobj.lnk_ContentManagement_click();
                if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                {
                    driver.Navigate().Refresh();
                }

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