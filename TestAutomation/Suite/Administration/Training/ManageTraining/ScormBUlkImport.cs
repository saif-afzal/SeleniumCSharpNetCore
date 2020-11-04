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


namespace Selenium2.Meridian.Suite.Administration.Training
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ScormBUlkImport : TestBase
    {
        string browserstr = string.Empty;
        public ScormBUlkImport(string browser)
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
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Create_a_new_certificate()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Certificates");
            Certificatesobj.Click_CreateGoTo();
            Certificatesobj.Populate_CreateForm();
            Certificatesobj.uploadfile();
            Certificatesobj.Click_CreateCertificate();
            Assert.IsTrue(Certificatesobj.Click_SaveStartFile());

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_certificate()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Certificates");
            Assert.IsTrue(Certificatesobj.Click_SearchCertificates());
            Assert.IsTrue(Certificatesobj.Click_gotomanagebtn());
            driver.Navigate_to_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Certificates");
            Assert.IsTrue(Certificatesobj.Click_AdvSearchCertificate());

        }

        [Test]
        public void c_Manage_a_certificate()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Certificates");
            Certificatesobj.Click_SearchCertificates();
            Certificatesobj.Click_gotomanagebtn();
            Assert.IsTrue(Certificatesobj.Click_UpdateCertificate());

        }

        [Test]
        public void d_Upload_files_for_the_certificate()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Certificates");
            Certificatesobj.Click_SearchCertificates();
            Certificatesobj.Click_gotomanagebtn();
            Certificatesobj.Click_Checkout();
            Certificatesobj.Click_CertificateTab();
            Certificatesobj.Click_deleteuploaded();
            Certificatesobj.uploadfile();
            Certificatesobj.Click_UploadFilebtn();
            Assert.IsTrue(Certificatesobj.Click_SaveStartFile());

        }

        [Test]
        public void e_Preview_the_certificate()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Certificates");
            Certificatesobj.Click_SearchCertificates();
            Certificatesobj.Click_gotomanagebtn();
            Certificatesobj.Click_Checkout();
            Certificatesobj.Click_CertificateTab();
            Certificatesobj.Click_PreviewLink();

        }

        [Test]
        public void f_Delete_the_certificate()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Certificates");
            Certificatesobj.Click_SearchCertificates();
            //Certificatesobj.Click_Checkout();
            //Certificatesobj.Click_CertificateTab();
            Certificatesobj.Chk_Delete();
            Certificatesobj.Click_Delete();

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
               
                    driver.Navigate().Refresh();
                
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
