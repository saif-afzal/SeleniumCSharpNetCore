using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class AccessKeys
    {
        private readonly IWebDriver driverobj;
        public AccessKeys(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool enable_Accesskeys_Classroomsection_byadmin()
        {
            bool actualresult = false;
            try
            {
                IWebElement rb_enableaccesskeys = driverobj.FindElement(By.Id("TabMenu_ML_BASE_WF_ContentSettings_AccessCodes_PurchaseinBulk_0"));
                IWebElement chk_classroomcourse = driverobj.FindElement(By.Id("TabMenu_ML_BASE_WF_ContentSettings_CTYP_SUPPORTS_ACCESSCODE_FLAG_3"));
                IWebElement rb_enableaccesskeys1 = driverobj.FindElement(By.Id("TabMenu_ML_BASE_WF_ContentSettings_EnableAccessPeriods_1"));
                if(rb_enableaccesskeys.Selected)
                {

                    if(chk_classroomcourse.Selected)
                    {
                        driverobj.GetElement(btn_SaveConfigSetting).Click();
                        driverobj.WaitForElement(sucessAlert);
                        //driverobj.Close();
                        
                    }

                    else
                    {
                        chk_classroomcourse.Click();
                        driverobj.GetElement(btn_SaveConfigSetting).Click();
                        driverobj.WaitForElement(sucessAlert);
                        //driverobj.Close();
                       
                    }
                }

                else
                
                {
                    rb_enableaccesskeys.ClickAnchor();

                    if (chk_classroomcourse.Selected)
                    {
                        driverobj.GetElement(btn_SaveConfigSetting).Click();
                        driverobj.WaitForElement(sucessAlert);
                        driverobj.Close();
                        
                    }

                    else
                    {
                        chk_classroomcourse.Click();
                        driverobj.GetElement(btn_SaveConfigSetting).Click();
                        driverobj.WaitForElement(By.Id("ReturnFeedback"));
                        driverobj.SelectWindowClose2("Content Settings", "Home");
                        
                    }
                }

                actualresult = true;
            }
            catch(Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Click_Managea_AccessKeys()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_ManageAccessKeys);
                driverobj.GetElement(btn_ManageAccessKeys).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Enter_Users_Email_Address()
        {
            bool actualresult = false;
            try
            {

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Click_Assign_Button()
        {
            bool actualresult = false;
            try
            {

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Click_Download_Keys(string browserstr)
        {
            bool actualresult = false;
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("tr[id*='_rgManageAccess']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr))
                    {
                        string originalHandle = driverobj.CurrentWindowHandle;
                        item.FindElement(btn_Dropdown).Click();
                        driverobj.WaitForElement(By.XPath("//a[contains(.,'Download')]"));
                        List<IWebElement> ele = item.FindElement(By.CssSelector("div[class*='open']")).FindElements(By.TagName("li")).ToList();
                        ele[1].Click();
                        Thread.Sleep(5000);
                        driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                        driverobj.WaitForElement(keytextBox);
                        driverobj.GetElement(keytextBox).Clear();
                        driverobj.GetElement(keytextBox).SendKeys("1");
                        driverobj.GetElement(By.CssSelector("div[id='pnlContent']")).ClickWithSpace();//Click on lable to just verification of email..
                        Thread.Sleep(1000);
                        driverobj.GetElement(downloadButton_AccessKey).ClickWithSpace();
                        Thread.Sleep(10000);
                        driverobj.WaitForTitle("Meridian Global Reporting",new TimeSpan(0,0,60));
                        driverobj.SelectWindowClose2("Meridian Global Reporting","Access Keys");
                        Thread.Sleep(5000);
                        if (!driverobj.existsElement(sucessAlert))
                        { return false; }
                        actualresult = true;
                        break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Click_Enroll_Order_Detail_Page(string browserstr)
        {
            bool actualresult = false;
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("tr[id*='_rgManageAccess']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr))
                    {
                        string originalHandle = driverobj.CurrentWindowHandle;
                        item.FindElement(btn_Dropdown).Click();
                        driverobj.WaitForElement(By.XPath("//a[contains(.,'Enroll')]"));
                        List<IWebElement> ele = item.FindElement(By.CssSelector("div[class*='open']")).FindElements(By.TagName("li")).ToList();
                        ele[3].Click();
                        Thread.Sleep(5000);
                        if (!driverobj.existsElement(sucessAlert))
                        { return false; }
                        actualresult = true;
                        break;
                    }
                }
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Click_Enroll_Order_Detail_Page_Classroomcourse(string browserstr)
        {
            bool actualresult = false;
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("tr[id*='_rgManageAccess']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr))
                    {
                        string originalHandle = driverobj.CurrentWindowHandle;
                        item.FindElement(btn_Dropdown).Click();
                        driverobj.WaitForElement(By.XPath("//a[contains(.,'Enroll')]"));
                        List<IWebElement> ele = item.FindElement(By.CssSelector("div[class*='open']")).FindElements(By.TagName("li")).ToList();
                        ele[3].Click();
                        Thread.Sleep(5000);
                        if (!driverobj.existsElement(sucessAlert))
                        { return false; }
                        actualresult = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Click_Transfer_AccessKeys(string browserstr)
        {
            bool actualresult = false;
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("tr[id*='_rgManageAccess']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr))
                    {
                        string originalHandle = driverobj.CurrentWindowHandle;
                        item.FindElement(btn_Dropdown).Click();
                        driverobj.WaitForElement(By.XPath("//a[contains(.,'Transfer')]"));
                        List<IWebElement> ele = item.FindElement(By.CssSelector("div[class*='open']")).FindElements(By.TagName("li")).ToList();
                        ele[0].Click();
                        Thread.Sleep(5000);
                        driverobj.WaitForElement(emailtextBox_Transfer);
                        driverobj.GetElement(emailtextBox_Transfer).Clear();
                        driverobj.GetElement(emailtextBox_Transfer).SendKeys("automationmeridian@gmail.com");
                        driverobj.WaitForElement(keys_totrasnfer);
                        driverobj.GetElement(keys_totrasnfer).Clear();
                        driverobj.GetElement(keys_totrasnfer).SendKeys("1");
                        driverobj.GetElement(By.CssSelector("div[class='well remaining-key']")).ClickWithSpace();//Click on lable to just verification of email..
                        Thread.Sleep(1000);
                        driverobj.GetElement(TransferButton_AccessKey).Click();
                        driverobj.WaitForElement(sucessAlert);

                        if (!driverobj.existsElement(sucessAlert))
                        { return false; }
                        actualresult = true;
                        break;
                    }
                }
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Check_History_For_TranferedKeys(string browserstr)
        {
            bool actualresult = false;
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("tr[id*='_rgManageAccess']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr))
                    {
                        
                        string originalHandle = driverobj.CurrentWindowHandle;
                        driverobj.WaitForElement(By.CssSelector("a[id*='_btnViewDetails']"));
                        string courseName = ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr;
                        driverobj.FindElement(By.XPath("//tr[td[strong[a[text()='" + courseName + "']]]]/td[4]/a")).Click();
                       actualresult= driverobj.existsElement(By.XPath("//p[contains(.,'You transferred 1 key(s) to Automation TestUser')]"));
                         
                    }
                }
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }

        public bool Click_Refund(string browserstr)
        {
            bool actualresult = false;
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("div[id*='_rgOrderHistory']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr))
                    {

                        string originalHandle = driverobj.CurrentWindowHandle;
                        driverobj.WaitForElement(By.CssSelector("a[id*='_lnkPurchaseDetails']"));
                        string courseName = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr;
                        driverobj.GetElement(By.CssSelector("a[id*='_lnkPurchaseDetails']")).Click();
                        driverobj.FindElement(btn_Dropdown).Click();
                        driverobj.WaitForElement(By.XPath("//a[contains(.,'Refund')]"));
                        driverobj.GetElement(By.XPath("//a[contains(.,'Refund')]")).Click();
                        driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                     //   driverobj.GetElement(By.Id("chkRefundTransfers")).Click();
                        driverobj.WaitForElement(By.Id("MainContent_UC1_txtCount1"));
                        driverobj.GetElement(By.Id("MainContent_UC1_txtCount1")).SendKeys("1");
                        driverobj.GetElement(By.CssSelector("div[class ='well remaining-key']")).Click();
                        driverobj.GetElement(By.Id("MainContent_UC1_btnRefund")).Click();
               actualresult=driverobj.existsElement(sucessAlert);

                        
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }

            return actualresult;
        }




      

        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By btn_Dropdown = By.CssSelector("button[data-toggle*='dropdown']");
        private By btn_Download_Keys = By.CssSelector("a[id*='_rgManageAccess']");
        private By downloadButton_AccessKey = By.Id("MainContent_UC1_btnDownload");
        private By sucessAlert = By.CssSelector("div[class*='alert-success']");
        private By keytextBox = By.Id("MainContent_UC1_txtGenerateAccessCode");
        private By keys_totrasnfer = By.Id("txtCount1");
        private By TransferButton_AccessKey = By.Id("MainContent_UC1_btnTransfer");
        private By emailtextBox_Transfer = By.Id("MainContent_UC1_txtEmail1");
        private By btn_ManageAccessKeys = By.CssSelector("a[id*='_btnViewDetails']");
        private By btn_SaveConfigSetting = By.Id("ML.BASE.BTN.Save");


        
    }
}
