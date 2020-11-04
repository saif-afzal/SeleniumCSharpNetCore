using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.ObjectModel;
using System.Reflection;
using Selenium2;
using Selenium2.Meridian;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian
{
   public class TrainingHomes
    {
        private readonly IWebDriver driverobj;

        public TrainingHomes(IWebDriver driver)
        {
            driverobj = driver;
        }
        public static string BaseWindow;

        public bool MyResponsiblities_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.XPath(".//*[@id='utility-nav']/ul[1]/li[2]/a"));

                driverobj.HoverLinkClick(By.XPath(".//*[@id='utility-nav']/ul[1]/li[2]/a"), By.XPath("//a[@href='/admin/myresponsibilities/training.aspx']"));
                //  driverobj.GetElement(ObjectRepository.myResponsibilities);
                if (driverobj.existsElement(By.XPath("//a[contains(.,'Content Items')]")))
                {
                    return true;
                }
                else if (!driverobj.existsElement(ObjectRepository.searchHome))
                {
                    driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/admin/MyResponsibilities/Training.aspx']"));
                    driverobj.WaitForElement(ObjectRepository.searchHome);
                }
                else
                {
                    driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/admin/MyResponsibilities/Training.aspx']"));
                    driverobj.WaitForElement(ObjectRepository.searchHome);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }
        public bool TeamPage_MenuBar_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//a[@id='ManagerView']"));
                driverobj.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/MyTeam.aspx']"));
                //driverobj.GetElement(By.XPath("//a[@id='ManagerView']")).ClickWithSpace();
                if (!driverobj.existsElement(By.CssSelector("div[id*='_MainContent_UC1_rgTeam']")))
                {
                    driverobj.GetElement(lnk_TeamPage).Click();
                }
                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool AdminConsole_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(lnk_AdminConsole);
                driver.GetElement(lnk_AdminConsole).ClickAnchor();

                // switching to Administartion window
                BaseWindow = driver.CurrentWindowHandle;

                ReadOnlyCollection<string> handles = driver.WindowHandles;

                foreach (string handle in handles)
                {
                    if (handle != BaseWindow)
                    {
                        driver.SwitchTo().Window(handle).Title.Equals("Administration Console");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
                return false;
            }
            return true;
        }

        public bool QuitAdminConsole(IWebDriver driver)
        {
            try
            {
                driver.Close();
                driver.SwitchTo().Window(BaseWindow);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
                return false;
            }
            return true;
        }

        public bool QuitSystemOptionsConsole(IWebDriver driver)
        {
            try
            {
                driver.Close();
                Thread.Sleep(2000);
                driver.SwitchTo().Window("");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
                return false;
            }
            return true;
        }

        public bool Click_TrainingCatalogLink()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='txtGlobalSearch']"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }


        public bool isTrainingHome()
        {
            bool result = false;

            //try
            //{
            //    driverobj.SwitchtoDefaultContent();
            //    Thread.Sleep(2000);
            //   string text= driverobj.Title;
            //   if (driverobj.IsElementVisible(lnk_closesysoption))
            //    {
            //        //  StandardDelay();
            //        driverobj.GetElement(lnk_closesysoption).ClickWithSpace();
            //        //   StandardDelay();
            //    }
            //   else
            //   {
            //       if (!driverobj.GetElement(By.Id("lbUserView")).Displayed)
            //       {
            //        //   driverobj.Navigate().Refresh();
            //       }
            //   }
            //    // StandardDelay();
            //    driverobj.WaitForElement(lnk_MyOwnLearning);
            //    driverobj.WaitForElement(lnk_TrainingHome);

            //    result = true;
            //}
            //catch (Exception ex)
            //{

            //    ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            //    driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //}


            return result;
        }

        private void StandardDelay()
        {
          //  if (driverobj is OpenQA.Selenium.IE.InternetExplorerDriver) Thread.Sleep(6000);
            
            //InternetExplorerDriver obj = new 
        }

        public bool Click_AdminConsoleLink()
        {

            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_AdminConsole);
                driverobj.GetElement(lnk_AdminConsole).ClickAnchor();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_Search(string searchtext)
        {

            bool result = false;
            try
            {
                driverobj.WaitForElement(By.Id("MainContent_ucQuickSearch_txtIDPSearchFor"));
                driverobj.GetElement(By.Id("MainContent_ucQuickSearch_txtIDPSearchFor")).Clear();
                driverobj.GetElement(By.Id("MainContent_ucQuickSearch_txtIDPSearchFor")).SendKeysWithSpace(searchtext);
              //  driverobj.GetElement(By.Id("MainContent_ucQuickSearch_txtSearchFor")).SendKeysWithSpace(Keys.Escape);
                driverobj.ClickEleJs(By.Id("btnIDPSearch"));

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_CollabartionSpace()
        {
            bool result = false;
            try
            {
                if (driverobj.GetElement(lnk_CollabartionSpace).Text=="Collaboration Space")
                {
                    driverobj.GetElement(lnk_CollabartionSpace).ClickAnchor();
                    result = true;
                }
                else
                {
                    driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath("//a[@href='/CollaborationSpace.aspx']"));
                }
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Click_TranscriptLink()
        {
            try
            {
                if (driverobj.GetElement(By.XPath(".//*[@id='utility-nav']/ul[1]/li[3]/a")).Text=="Transcript")
                {
                    driverobj.ClickEleJs(By.XPath("//a[contains(@href,'/Transcript/AllMyTraining.aspx')]"));
                }
                else
                {
                    driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"),By.XPath("//a[@href='/transcript/allmytraining.aspx']"));
                }
                }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool Click_MyOwnLearning()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Home')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Home')]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }


        public string ShoppingCartClick()
        {
            string helptitle = string.Empty;
            try
            {
                driverobj.WaitForElement(By.Id("shoppingCartBadge"));
                driverobj.GetElement(By.Id("shoppingCartBadge")).ClickWithSpace();
                //driverobj.WaitForElement(By.XPath("//h1[text()=Shopping Cart]"));
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Help Link", driverobj);
            }

            return helptitle;
        }

        public string HelpLinkClick()
        {
            string helptitle = string.Empty;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
            //    driverobj.WaitForElement(HelpLink_id);
                driverobj.WaitForElement(By.Id("lnkHelp"));
             //   driverobj.GetElement(By.Id("lnkHelp")).ClickAnchor();
                driverobj.ClickEleJs(By.Id("lnkHelp"));
                Thread.Sleep(3000);
                driverobj.SwitchWindow("Help");
                helptitle = driverobj.Title;
                driverobj.SelectWindowClose2("Help", "Home");
                Thread.Sleep(3000);
               // driverobj.SwitchTo().Window(originalHandle);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Help Link", driverobj);
            }

            return helptitle;
        }

        public bool VerifyGlobalNavigation()
        {
            bool expectedresult = false;

            try
            {

                driverobj.WaitForElement(lnk_MyOwnLearning);

                //driverobj.GetElement(By.Id("NavigationStrip1_lbManagerView"));

                driverobj.WaitForElement(lnk_MyResponsiblities);

            //    driverobj.WaitForElement(lnk_AdminConsole);
                expectedresult = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to click on any tab among (My Own Learning, My Responsbilities, Adminstration Console)", driverobj);
            }
            return expectedresult;
        }

        public bool Click_MyAccount()
        {
            bool expectedresult = false;

            try
            {

                Thread.Sleep(3000);
                driverobj.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/UserProfile.aspx']"));
                Thread.Sleep(3000);
                expectedresult = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to click on any tab among (My Own Learning, My Responsbilities, Adminstration Console)", driverobj);
            }
            return expectedresult;
        }
        public bool Click_Requests()
        {
            bool expectedresult = false;

            try
            {

                Thread.Sleep(3000);
                driverobj.OpenToolbarItems(lnk_requests);
                Thread.Sleep(3000);
                expectedresult = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to click on any tab among (My Own Learning, My Responsbilities, Adminstration Console)", driverobj);
            }
            return expectedresult;
        }

        public bool lnk_MyClanederClick()
        {
            bool actualresult = false;
            try
            {
                Thread.Sleep(3000);
                driverobj.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/MyCalendar.aspx']"));
                Thread.Sleep(3000);
                actualresult=driverobj.existsElement(ClanederMonthView);
                return actualresult;
                

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return actualresult;
            }
        }

        public bool lnk_MyReportsClick()
        {
            try
            {
                Thread.Sleep(3000);
                driverobj.HoverLinkClick(By.XPath("//span[@data-bind='text: USR_FIRST_NAME.substring(0,1) + USR_LAST_NAME.substring(0, 1)']"), By.XPath("//a[@href='/MyReports.aspx']"));
                Thread.Sleep(3000);

                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }

        public bool lnk_MyMessageClick()
        {
            try
            {
                Thread.Sleep(3000);
                driverobj.OpenToolbarItems(lnk_mymessage);
                Thread.Sleep(3000);

                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }

        public static void Catalog()
        {
            Driver.clickEleJs(By.XPath("//a[@type='button']"));
            Thread.Sleep(4000);
        }

        public bool checkmsgicon()
        {
            bool actualresult = false;
            try
            {
                //driverobj.WaitForElement(msgicon);
                //driverobj.GetElement(msgicon).Click();
                actualresult=driverobj.existsElement(firstmsgchk);
              

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool openmsg()
        {
            bool actualresult = false;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                string msetitleinlist = driverobj.GetElement(firstmsgtitle).Text;
                driverobj.GetElement(firstmsgtitle).Click();
                Thread.Sleep(3000);
                driverobj.SwitchWindow("Message");
                driverobj.WaitForElement(By.XPath("//li[contains(.,'"+msetitleinlist+"')]"));
               // string msgtitle = driverobj.GetElement(msgdetail).Text;
                driverobj.Close();
                Thread.Sleep(3000);

                driverobj.SwitchTo().Window(originalHandle);
                //if (msetitleinlist == msgtitle)
                //{
                    actualresult = true;
                //}

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Check_AnnouncementPortlet()
        {
            try
            {
                driverobj.WaitForElement(lbl_AnnouncementPortlet);
                driverobj.WaitForElement(lnk_FirstAnnouncementItem);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool Click_Announcement()
        {
            try
            {
                driverobj.WaitForElement(lnk_FirstAnnouncementItem);
                driverobj.ClickEleJs(lnk_FirstAnnouncementItem);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public string Get_AnnouncementTitle()
        {
            try
            {

                driverobj.WaitForElement(lnk_FirstAnnouncementItem);
                return driverobj.GetElement(lnk_FirstAnnouncementItem).Text;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return "";
            }
        }
        public bool Click_MoreAnnouncement()
        {
            try
            {
                driverobj.WaitForElement(btn_MoreAnnouncement);
                driverobj.ClickEleJs(btn_MoreAnnouncement);
                driverobj.WaitForElement(pagetitle);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }


        public bool Click_BrowseItem()
        {
            try
            {
                //List<IWebElement> allCategory = driverobj.FindElements(By.CssSelector("a[id*='MainContent_ucSearchLanding_rlvSearchResults_']")).ToList();
                //allCategory[0].Click();
                //Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath(".//*[@id='ctl00_MainContent_ucQuickSearch_ucBrowseCategories_RadTreeView1']/ul/li[1]/div/span[2]"));
                driverobj.GetElement(By.XPath(".//*[@id='ctl00_MainContent_ucQuickSearch_ucBrowseCategories_RadTreeView1']/ul/li[1]/div/span[2]")).ClickWithSpace();
                driverobj.WaitForElement(showcontent);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

        }


        public bool Check_FAQPortlet()
        {
            try
            {
                driverobj.WaitForElement(lbl_FAQPortlet);
                driverobj.WaitForElement(lnk_FirstFAQItem);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool Click_FAQ()
        {
            try
            {
                driverobj.WaitForElement(lnk_FirstFAQItem);
                driverobj.GetElement(lnk_FirstFAQItem).ClickWithSpace();
                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public string Get_FAQTitle()
        {
            try
            {

                driverobj.WaitForElement(lnk_FirstFAQItem);
                return driverobj.GetElement(lnk_FirstFAQItem).Text;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return "";
            }
        }
        public bool Click_MoreFAQ()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_ucFAQsPortlets_lnkMore']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_ucFAQsPortlets_lnkMore']"));
                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool Click_ProfessionalDevelopment()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(tab_ProfessionalDevelopment);
                driverobj.GetElement(tab_ProfessionalDevelopment).ClickAnchor();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }

            return result;
        }

        public bool Verify_ProfessionalDevelopment_NotPresent()
        {
            bool result = false;
            try
            {
                driverobj.ElementNotPresent(tab_ProfessionalDevelopment);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public void LinkContentSearchtclick()
        {


            try
            {
                driverobj.WaitForElement(By.XPath(".//*[@id='btnSearch']/span"));
                driverobj.ClickEleJs(By.XPath(".//*[@id='btnSearch']/span"));
              
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                Console.WriteLine(ex.Message);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

        }
      
        public bool Verify_ProfessionalDevelopment_Present()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(tab_ProfessionalDevelopment);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool MyTeam_click()
        {
            bool result = false;
            try
            {


                driverobj.WaitForElement(lnk_MyTeam);
                driverobj.GetElement(lnk_MyTeam).ClickAnchor();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }


        public bool lnk_SystemOptions_click()
        {
            bool result = false;
            //try
            //{
            //    if (!driverobj.GetElement(By.Id("lbUserView")).Displayed)
            //    {
            //        //driverobj.Navigate().Refresh();
            //    }
            //    driverobj.WaitForElement(lnk_SystemOptions);
            //    driverobj.GetElement(lnk_SystemOptions).ClickWithSpace();
            //    Thread.Sleep(2000);
            //    result = true;
            //}
            //catch (Exception ex)
            //{
            //    try
            //    {
            //        if (driverobj.IsElementVisible(lnk_closesysoption))
            //        {
            //          //  driverobj.Navigate().Refresh();
            //            driverobj.WaitForElement(lnk_SystemOptions);
            //        }
            //        else
            //        {
            //            driverobj.Navigate().Refresh();
            //            driverobj.WaitForElement(lnk_SystemOptions);
            //            driverobj.GetElement(lnk_SystemOptions).ClickWithSpace();
            //        }
            //    }
            //    catch (Exception ex1)
            //    {
            //        ExceptionandLogging.ExceptionLogging(ex1, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            //    return false;
            //}
            //}
            return result;
        }
        public bool lnk_training_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_training);
                driverobj.GetElement(lnk_training).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_CurrentTraining_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_currenttraining);
                driverobj.GetElement(lnk_currenttraining).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_People_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_People);
                driverobj.GetElement(lnk_People).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_Ecommerce_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_Ecommerce);
                driverobj.ClickEleJs(lnk_Ecommerce);
                //driverobj.GetElement(lnk_Ecommerce).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_system_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_system);
                driverobj.GetElement(lnk_system).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_ContentManagement_click()
        {
            bool result = false;
            try
            {

                driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-contentManagement']"));
                //driverobj.ClickEleJs(lnk_ContentManagement);

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_TrainingManagement_click(By by,By by1 )
        {
            bool result = false;
            try
            {
                Thread.Sleep(3000);
                driverobj.HoverLinkClick(by, by1);

                Thread.Sleep(3000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_requiredTrainingManagement_click()
        {
            bool result = false;
            try
            {
                Thread.Sleep(3000);
                driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
                //driverobj.GetElement(lnk_requiredTrainingManagement).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_ContentConfiguration_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_ContentConfiguration);
                driverobj.GetElement(lnk_ContentConfiguration).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_facilities_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_facilities);
                driverobj.GetElement(lnk_facilities).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_peopleManagement_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_peopleManagement);
                driverobj.GetElement(lnk_peopleManagement).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_OrdersandRefunds_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_OrdersandRefunds);
                driverobj.GetElement(lnk_OrdersandRefunds).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_CurrencyandTaxes_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_CurrencyandTaxes);
                driverobj.GetElement(lnk_CurrencyandTaxes).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_PricingandCodes_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_PricingandCodes);
                driverobj.ClickEleJs(lnk_PricingandCodes);
                //driverobj.GetElement(lnk_PricingandCodes).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_PaymentGateways_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_PaymentGateways);
                driverobj.GetElement(lnk_PaymentGateways).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_EmailManagement_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_EmailManagement);
                driverobj.GetElement(lnk_EmailManagement).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_SharedContentObjects_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_SharedContentObjects);
                driverobj.GetElement(lnk_SharedContentObjects).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_DomainsandURLS_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_DomainsandURLS);
                driverobj.GetElement(lnk_DomainsandURLS).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_SocialNetworkSharing_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_SocialNetworkSharing);
                driverobj.GetElement(lnk_SocialNetworkSharing).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_BrandingandCustomization_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_BrandingandCustomization);
                driverobj.GetElement(lnk_BrandingandCustomization).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_Tools_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_Tools);
                driverobj.GetElement(lnk_Tools).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool lnk_reportsManagement_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_reportsManagement);
                driverobj.GetElement(lnk_reportsManagement).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool lnk_SystemAdministration_click()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_SystemAdministration);
                driverobj.GetElement(lnk_SystemAdministration).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_systemOptions()
        {
            bool result = false;
            try
            {
                int cnt = 0;
                driverobj.WaitForElement(lnk_systemOptions);
             //   driverobj.FindElement(By.Id("NavigationStrip1_ddlAdminMenu")).Click();
                driverobj.FindElement(By.XPath("//li[@id='ddlAdminMenu']/a/span")).ClickAnchor();
               // driverobj.FindElement(By.XPath());
                while (!driverobj.FindElement(By.Id("lbUserView")).Displayed)
              {
                  if (cnt < 3)
                  {
                      driverobj.Navigate().Refresh();
                      driverobj.FindElement(By.XPath("//li[@id='ddlAdminMenu']/a/span")).ClickAnchor();
                      cnt = cnt + 1;
                  }
                  else
                  {
                      break;
                  }
              }
                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool close_systemOptions()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_closeSystemOptions);
                driverobj.GetElement(lnk_closeSystemOptions).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool Click_Products()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//a[contains(.,'Products')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Products')]")).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_systemOptionsTab(String tabName)
        {
            bool result = false;
            By lnk_systemOptionTab = By.XPath("//li/a[text()='"+tabName+"']");
            try
            {

                driverobj.WaitForElement(lnk_systemOptionTab);
                driverobj.ClickEleJs(lnk_systemOptionTab);

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_systemOptionsAccordian(String accordianName)
        {
            bool result = false;
            By lnk_systemOptionAccordian = By.XPath("//h3[@class='panel-title']/a[text()='"+accordianName+"']");
            try
            {

                driverobj.WaitForElement(lnk_systemOptionAccordian);
                driverobj.ClickEleJs(lnk_systemOptionAccordian);

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_systemOptionsLink(String linkName)
        {
            bool result = false;
            By lnk_systemOptionLink = By.XPath("//a[text()='" + linkName + "']");
            try
            {

                driverobj.WaitForElement(lnk_systemOptionLink);
                driverobj.ClickEleJs(lnk_systemOptionLink);

                Thread.Sleep(10000);
                driverobj.selectWindow();
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_currenttraining()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_currenttraining);
                driverobj.GetElement(lnk_currenttraining).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool Click_TrainingHome()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(lnk_TrainingHome);
                if (driverobj.GetElement(By.XPath(".//*[@id='utility-nav']/ul[1]/li[1]/a")).Text=="Learn")
                {
                driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a"));
                }
                else
                {
                    driverobj.ClickEleJs(lnk_TrainingHome);
                }
                    driverobj.WaitForElement(lnk_TrainingHome);
              //  driverobj.GetElement(lnk_TrainingHome).ClickWithSpace();
              //  driverobj.ClickEleJs(lnk_TrainingHome);

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool Click_Training()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_TrainingHome);
                driverobj.GetElement(lnk_TrainingHome).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool Click_UserName()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgTeam_ctl00__0']/td[1]/a"));
                driverobj.ClickEleJs(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgTeam_ctl00__0']/td[1]/a"));

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }
        public bool Click_About()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_about);
                driverobj.GetElement(lnk_about).ClickWithSpace();
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driverobj.SwitchtoDefaultContent();

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool Click_privacyPolicy()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_privacyPolicy);
                driverobj.GetElement(lnk_privacyPolicy).ClickWithSpace();
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driverobj.SwitchTo().DefaultContent();

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool Click_termsConditions()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_termsConditions);
                driverobj.GetElement(lnk_termsConditions).ClickWithSpace();
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driverobj.SwitchTo().DefaultContent();

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public String verify_aboutText()
        {
            String aboutText;
            try
            {

                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                aboutText = driverobj.GetElement(txt_aboutText).Text;
                driverobj.SwitchtoDefaultContent();
                driverobj.GetElement(lnk_close).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                aboutText = "Error";
            }
            return aboutText;
        }

        public String verify_privacyPolicy()
        {
            String privacyPolicy;
            try
            {

                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                privacyPolicy = driverobj.GetElement(txt_privacyPolicy).Text;
                driverobj.SwitchTo().DefaultContent();
                driverobj.GetElement(lnk_close).ClickWithSpace();


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                privacyPolicy = "Error";
            }
            return privacyPolicy;
        }

        public String verify_termsConditions()
        {
            String termsConditions;
            try
            {

                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                termsConditions = driverobj.GetElement(txt_termsConditions).Text;
                driverobj.SwitchTo().DefaultContent();
                driverobj.GetElement(lnk_close).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                termsConditions = "Error";
            }
            return termsConditions;
        }

        public String verify_welcomeMessage()
        {
            String welcomeMessage;
            try
            {

                driverobj.WaitForElement(txt_welcomeMessage);
                welcomeMessage = driverobj.GetElement(txt_welcomeMessage).Text;
                


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                welcomeMessage = "Error";
            }
            return welcomeMessage;
        }
        public bool VerifyUserNameColumn_Team()
        {
            try
            {
                Click_UserName();
                if (!driverobj.IsElementVisible(By.XPath(".//*[@id='ctl00_MainContent_UC1_rgTeam_ctl00']/tbody/tr[2]/td/div/div/div[1]/h3")))
                { throw new Exception("	User Name link lick is not clickable when click first time on link.."); }
                //Click_UserName();
                //Thread.Sleep(2000);
                //if (!driverobj.IsElementVisible(dec_sorting))
                //{ throw new Exception("	User Name link lick is not clickable when try to validate decending sorting."); }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool Verify_UserJumpsToTranscript_FromAccountPage()
        {
            try
            {
                Transcripts Transcriptsobj = new Transcripts(driverobj);
                if (!driverobj.IsElementVisible(By.XPath("//a[@href='Transcript/AllMyTraining.aspx']")))
                { throw new Exception("Completed Content link section is not coming on my account page.."); }
                driverobj.ClickEleJs(By.XPath("//a[@href='Transcript/AllMyTraining.aspx']"));
                Thread.Sleep(3000);
                if (!Transcriptsobj.IsTranscriptPageLoaded())
                { throw new Exception("User is not redircting to transcript page after click on -Completed Traning link from my account page"); }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        private By lnk_close = By.XPath("//a[@class='k-window-action k-link']");
        private By lnk_about = By.Id("lnkAboutPage");
        private By lnk_privacyPolicy = By.Id("lnkPrivacyPolicy");
        private By lnk_termsConditions = By.Id("lnkTermsOfUse");
        private By txt_aboutText = By.XPath("//h3[text()='Additional information']/following-sibling::p[1]");
        private By txt_privacyPolicy = By.XPath("//div[@class='col-xs-12']/p[1]");
        private By txt_termsConditions = By.XPath("//div[@class='col-xs-12']/p[1]");
        private By txt_welcomeMessage = By.XPath("//h1[@class='logo']/following-sibling::h2[1]");
        //-------
        private By lnk_closeSystemOptions = By.XPath("//a[@class='close-offcanvas']");
        private By lnk_systemOptions = By.XPath("//li[@id='NavigationStrip1_ddlAdminMenu']//span");
        private By lnk_MyTeam = By.Id("NavigationStrip1_lbManagerView");
        private By lnk_MyResponsiblities = By.Id("lbMyResponsibilities");
        private By lnk_TeamPage = By.Id("NavigationStrip1_lbManagerView");
        private By lnk_MyOwnLearning = By.Id("lbUserView");
        private By lnk_TrainingHome = By.XPath("//a[text()='Home']");
        private By lnk_UserName = By.LinkText("User Name");
        private By lnk_AdminConsole = By.Id("NavigationStrip1_lnkAdminConsole");
        private By lnk_Products = By.Id("phAdminMenu_lnkMangProduct");
        private By txt_search = By.Id("MainContent_ucQuickSearch_txtSearch");
        private By btn_search = By.XPath("//div[@id='MainContent_ucQuickSearch_QuickSearch']//a[@id='btnSearch']");
        private By lnk_TrainingCatalog = By.XPath("//a[contains(@data-menuitem,'traningcatalog')]");
        private By lnk_CollabartionSpace = By.XPath("//a[contains(.,'Collaboration Spaces')]");
        private By lnk_Transcript = By.XPath("//a[contains(.,'Transcript')]");
        private By HelpLink_id = By.Id("NavigationStrip1_lnkHelp");

        private By ShoppingCart_id = By.Id("NavigationStrip1_shoppingCartBadge");
        
        private By lnk_mainhover = By.XPath("/html/body/form/div[6]/div/div/div/div[2]/div/div/ul/li/a/span");
        private By lnk_logout = By.XPath("//a[normalize-space()='Logout']");
        private By lnk_myaccount = By.XPath("//a[normalize-space()='Account']");
        private By lnk_requests = By.XPath("//a[normalize-space()='Requests']");
        private By lnk_myreports = By.XPath("//a[normalize-space()='Reports']");
        private By lnk_mymessage = By.XPath("//a[normalize-space()='Messages']");
        private By lnk_mycalender = By.XPath("//a[normalize-space()='Calendar']");
        private By ClanederMonthView = By.XPath("//button[@data-calendar-view='month']");

        private By msgicon = By.XPath("//img[@id='NavigationStrip1_qucMessages_imgQueueIcon']");
        private By firstmsgchk = By.XPath("//input[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect']");
        private By firstmsgtitle = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkSubject");
        private By msgdetail = By.Id("MainContent_UC1_fvMessage_lblSubject");

        private By lbl_AnnouncementPortlet = By.XPath("//h2[contains(.,'Recent Announcements')]");
        private By lnk_FirstAnnouncementItem = By.Id("ctl00_MainContent_ucAnnouncements_rlvListing_ctrl0_lnkTitle");
        private By btn_MoreAnnouncement = By.Id("MainContent_ucAnnouncements_lnkMore");

        private By subcategoryfirstitem = By.XPath("//.[@id='ctl00_MainContent_ucQuickSearch_ucBrowseCategories_RadTreeView1']/ul/li[1]/div/span[2]");
        private By showcontent = By.Id("MainContent_ucBrowseCategory_lbSelectAllContent");

        private By lbl_FAQPortlet = By.XPath("//h2[contains(.,'FAQs')]");
        private By lnk_FirstFAQItem = By.Id("ctl00_MainContent_ucFAQsPortlets_rlvListing_ctrl0_lnkTitle");
        private By btn_MoreFAQ = By.Id("MainContent_ucFAQsPortlets_lnkMore");
        private By tab_ProfessionalDevelopment = By.XPath("//a[contains(.,'Professional Development')]");
        private By lnk_ContentSearch = By.XPath("//a[@href='../ContentSearch.aspx']");
        //---------------------------Admin Console link -----------------------------------
        private By lnk_SystemOptions = By.XPath("//li[@id='ddlAdminMenu']/a/span");//By.XPath("//span[contains(.,'System Options')]");

        private By lnk_training = By.XPath("//a[@href='#training']");

        private By lnk_People = By.XPath("//a[contains(.,'People')]");

        private By lnk_Ecommerce = By.XPath("//a[contains(.,'Ecommerce')]");

        private By lnk_system = By.XPath("//a[@href='#system']");

        private By lnk_ContentManagement = By.XPath("//a[contains(.,'Content Management')]");

        private By lnk_TrainingManagement = By.XPath("//a[contains(.,'Training Management')]");

        private By lnk_requiredTrainingManagement = By.XPath("//a[@href='#requiredTrainingManagement']");

        private By lnk_ContentConfiguration = By.XPath("//a[contains(.,'Content Configuration')]");

        private By lnk_facilities = By.XPath("//a[@href='#facilities']");

        private By lnk_peopleManagement = By.XPath("//a[@href='#peopleManagement']");

        private By lnk_OrdersandRefunds = By.XPath("//a[contains(.,'Orders and Refunds')]");

        private By lnk_CurrencyandTaxes = By.XPath("//a[contains(.,'Currency and Taxes')]");

        private By lnk_PricingandCodes = By.XPath("//a[contains(.,'Pricing and Codes')]");

        private By lnk_PaymentGateways = By.XPath("//a[contains(.,'Payment Gateways')]");

        private By lnk_EmailManagement = By.XPath("//a[contains(.,'Email Management')]");

        private By lnk_SharedContentObjects = By.XPath("//a[contains(.,'Shared Content/Objects')]");

        private By lnk_DomainsandURLS = By.XPath("//a[contains(.,'Domains and URLS')]");

        private By lnk_SocialNetworkSharing = By.XPath("//a[contains(.,'Social Network Sharing')]");

        private By lnk_BrandingandCustomization = By.XPath("//a[contains(.,'Branding and Customization')]");

        private By lnk_Tools = By.XPath("//a[contains(.,'Tools')]");

        private By lnk_reportsManagement = By.XPath("//a[@href='#reportsManagement']");

        private By lnk_SystemAdministration = By.XPath("//a[contains(.,'System Administration')]");

        private By lnk_closesysoption = By.XPath("//div[@id='admin-console']/a/span");//("//span[@class='fa fa-times']");

        private By lnk_currenttraining = By.XPath("//a[contains(.,'Current Training')]");
        private By ass_sorting = By.ClassName("rgSortAsc");
        private By dec_sorting = By.ClassName("rgSortDesc");
        private By lnk_completeContent = By.Id("MainContent_UCProfile_lnkTranscript");
        private By pagetitle = By.XPath("//h1[contains(.,'Announcements')]");
        public string browserstr { get; set; }
    }
}
