using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class Createnewproficencyscale
    {
        private readonly IWebDriver driverobj;

        public Createnewproficencyscale(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_Create(string Title, string type)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).SendKeysWithSpace(Title+type);
                driverobj.GetElement(txt_label1).SendKeysWithSpace(ExtractDataExcel.MasterDic_ProficencyScale["Label"]);
                driverobj.GetElement(txt_db1).SendKeysWithSpace(ExtractDataExcel.MasterDic_ProficencyScale["DB"]);
                driverobj.GetElement(txt_label2).SendKeysWithSpace(ExtractDataExcel.MasterDic_ProficencyScale["Label"]);
                driverobj.GetElement(txt_db2).SendKeysWithSpace(ExtractDataExcel.MasterDic_ProficencyScale["DB"]);
                driverobj.GetElement(txt_label3).SendKeysWithSpace(ExtractDataExcel.MasterDic_ProficencyScale["Label"]);
                driverobj.GetElement(txt_db3).SendKeysWithSpace(ExtractDataExcel.MasterDic_ProficencyScale["DB"]);
                driverobj.WaitForElement(lnk_addanother);
                driverobj.WaitForElement(lnk_remove);
                driverobj.WaitForElement(chk_default);
                driverobj.WaitForElement(btn_cancel);
                driverobj.GetElement(btn_create).ClickWithSpace();
               result = driverobj.existsElement(lblsucess);
                
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }


        private By txt_title = By.Id("MainContent_UC1_PS_TITLE");

        private By txt_label1 = By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_0");
        private By txt_db1 = By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_0");

        private By txt_label2 = By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_1");
        private By txt_db2 = By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_1");

        private By txt_label3 = By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_2");
        private By txt_db3 = By.Id("MainContent_UC1_rlvRating_PSI_LABEL_TITLE_2");

        private By lnk_addanother = By.XPath("//a[contains(.,'Add Another')]");
        private By lnk_remove = By.XPath("//a[contains(.,'Remove')]");
        private By chk_default = By.Id("MainContent_UC1_PS_DEFAULT");
        private By btn_create = By.Id("MainContent_UC1_btnCreate");
        private By btn_cancel = By.Id("MainContent_UC1_btnReturn");
        private By lblsucess = By.XPath("//div[@class='alert alert-success']");



    }
}
