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
    class ManageProficencyScale
    {
        private readonly IWebDriver driverobj;

        public ManageProficencyScale(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_SearchScale(string title)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(title);
                driverobj.WaitForElement(cmb_searchtype);
                driverobj.WaitForElement(btn_clearfilter);
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(lnk_firstitem);

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool Check_Items()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_firstitem);
                driverobj.WaitForElement(tbl_items);
                driverobj.WaitForElement(lbl_range);
                driverobj.WaitForElement(rb_default);
                driverobj.WaitForElement(btn_edit);
                driverobj.WaitForElement(btn_copy);
                driverobj.WaitForElement(btn_arvhive);
                driverobj.WaitForElement(btn_info);

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool sort_title()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_sorttitle);
                driverobj.GetElement(lnk_sorttitle).ClickWithSpace();
                IList<IWebElement> alltitle = driverobj.FindElements(lnk_itemtitles);
                String[] allText = new String[alltitle.Count];
                int i = 0;
                foreach (IWebElement element in alltitle)
                {
                    allText[i++] = element.Text;
                }
              result=  driverobj.isSorted(allText);
                
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        string titletext = string.Empty;
        public bool Click_title()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_firstitem);
                titletext = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(lnk_firstitem).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.XPath("//h3[contains(.,'Rating scale for "+titletext+"')]"));
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(btn_contentclose);
                driverobj.GetElement(btn_contentclose).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_infoicon()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_info);
                titletext = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(btn_info).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'"+titletext+"')]"));
                driverobj.WaitForElement(btn_infoclose);
                driverobj.GetElement(btn_infoclose).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_ArchiveItem()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_arvhive);
                driverobj.GetElement(btn_arvhive).ClickWithSpace();
                driverobj.WaitForElement(lblsucess);
               
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_ViewArchive()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_viewarchived);
                driverobj.GetElement(btn_viewarchived).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Edit()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_edit);
                titletext = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(btn_edit).ClickWithSpace();
              
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_save(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + ExtractDataExcel.MasterDic_ProficencyScale["Title"]+browserstr + "')]"));
                driverobj.WaitForElement(txt_edittitle);
                driverobj.GetElement(txt_edittitle).Clear();
                driverobj.GetElement(txt_edittitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_ProficencyScale["Title"]+browserstr);
                driverobj.GetElement(btn_save).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Copy(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_copy);
                titletext = driverobj.GetElement(lnk_firstitem).Text;
                driverobj.GetElement(btn_copy).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'Copy of " + ExtractDataExcel.MasterDic_ProficencyScale["Title"]+browserstr + "')]"));
                
                driverobj.WaitForElement(btn_copyscalecancle);
                driverobj.WaitForElement(btn_copyscalesave);
                driverobj.GetElement(btn_copyscalesave).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                //driverobj.WaitForElement(btn_contentclose);
                //driverobj.GetElement(btn_contentclose).ClickWithSpace();
                driverobj.WaitForElement(lblsucess);
                result = true;
                //driverobj.WaitForElement(By.XPath("//a[contains(.,'Copy of " + ExtractDataExcel.MasterDic_ProficencyScale["Title"]+browserstr+"')]"));
            }
            catch (Exception ex)
            {
               ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        private By txt_searchfor = By.Id("MainContent_UC1_SearchFor");
        private By cmb_searchtype = By.Id("MainContent_UC1_SearchType");
        private By btn_search = By.Id("btnSearchIdp");
        private By btn_clearfilter = By.Id("lbtnClearFilter");
        private By lnk_firstitem = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_lblTitle");
        private By tbl_items = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00");
        private By lbl_range = By.XPath("//td[a[@id='ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_lblTitle']]/following-sibling::td[1]");
        private By rb_default = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_rbDefault");
        private By btn_edit = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_btnEditProficiencyScale");
        private By btn_copy = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_btnCopyProficiencyScale");
        private By btn_arvhive = By.Id("ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_btnArchiveProficiencyScale");
        private By btn_info = By.XPath("//a[@id='ctl00_MainContent_UC1_rgProficiencyScale_ctl00_ctl04_btnInfoProficiencyScale']/span");
        private By lnk_sorttitle = By.XPath("//a[text()='Title']");
        private By lnk_itemtitles = By.XPath("//a[contains(@id,'lblTitle')]");
        private By lnk_titles = By.XPath("//a[contains(@id,'_lblTitle')]");
        private By lblsucess = By.XPath("//div[@class='alert alert-success']");
        private By btn_viewarchived = By.Id("MainContent_UC1_htviewArchive");
        private By btn_contentclose = By.XPath("//span[text()='Close']");
        private By btn_infoclose = By.Id("MainContent_UC1_MButton1");
        private By txt_edittitle = By.Id("MainContent_UC1_PS_TITLE");
        private By btn_save = By.Id("MainContent_UC1_btnEdit");

        private By txt_copyscaletitle = By.Id("MainContent_UC1_PS_TITLE");
        private By btn_copyscalecancle = By.Id("MainContent_UC1_btnReturn");
     
        private By btn_copyscalesave = By.Id("MainContent_UC1_btnCopy");

        

    }
}
