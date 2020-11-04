using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using TestAutomation.helper;

namespace Selenium2.Meridian.Suite
{
    public class ComplianceDashboardPage
    {
        public static bool ViewTranscript()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(WebElement_Locators.lable_ComplianceDashboard_ComplianceDashboardPage);
                Driver.Instance.IsElementVisible(WebElement_Locators.button_Go_Transcript_ComplianceDashboard);
                Driver.clickEleJs(WebElement_Locators.button_Go_Transcript_ComplianceDashboard);
                Driver.Instance.IsElementVisible(By.XPath("//div[13]//div[2]//div[2]"));
                Driver.clickEleJs(By.XPath("//div[13]//div[2]//div[2]"));
                Driver.Instance.Navigate().Back();
                Thread.Sleep(2000);
                Driver.Instance.IsElementVisible(WebElement_Locators.lable_ComplianceDashboard_ComplianceDashboardPage);
                result = true;
            }
            catch(Exception e)
            {

            }
            return result;
        }

        public static bool? SendEmail_ToUsers()
        {
            bool result = false;
            try
            {
                // At present send email feature is not working. This method will update more once it will start working.
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_selectAll_Checkbox);
                Driver.clickEleJs(WebElement_Locators.ComplianceDashboardPage_selectAll_Checkbox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_Email_Link);
                Driver.clickEleJs(WebElement_Locators.ComplianceDashboardPage_Email_Link);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_PopupTitle_Header);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_FromEmail_TextBox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Subject_TextBox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Message_RichTextBox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Cancel_Button);
                Driver.clickEleJs(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Cancel_Button);
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? SendEmail_ToUserManager()
        {
            bool result = false;
            try
            {
                // At present send email feature is not working. This method will update more once it will start working.
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_selectAll_Checkbox);
                Driver.clickEleJs(WebElement_Locators.ComplianceDashboardPage_selectAll_Checkbox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailManager_Link);
                Driver.clickEleJs(WebElement_Locators.ComplianceDashboardPage_EmailManager_Link);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_PopupTitle_Header);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_FromEmail_TextBox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Subject_TextBox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Message_RichTextBox);
                Driver.Instance.IsElementVisible(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Cancel_Button);
                Driver.clickEleJs(WebElement_Locators.ComplianceDashboardPage_EmailPopup_Cancel_Button);
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? ApplyOrganizationFilter()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.Id("btnOrgSearch"));
                Driver.clickEleJs(By.Id("btnOrgSearch"));
                Driver.Instance.GetElement(By.XPath("//div[@class='webix_el_box']/input")).SendKeysWithSpace("Sample");
                Thread.Sleep(4000);
                Driver.clickEleJs(By.XPath("//div[@class='webix_list_item'][contains(text(),'Sample Organization 1')]"));
                Driver.clickEleJs(By.XPath("//button[@type='button']"));
                Driver.Instance.IsElementVisible(By.XPath("//span[contains(text(),'1 organization(s)')]"));
                result = Driver.Instance.IsElementVisible(By.XPath("//div*[contains(text(),'Sample Organization 1')]"));
            }
            catch(Exception e)
            {

            }
            return result;
        }

        public static bool? SaveUniversalFilter()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.Id("SaveDefault"));
                Driver.clickEleJs(By.Id("SaveDefault"));
                result = Driver.Instance.IsElementVisible(By.Id("ClearDefaults"));
                
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? Verify_AppliedUniversalFilter()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//span[contains(text(),'1 organization(s)')]"));
                result = Driver.Instance.IsElementVisible(By.XPath("//div*[contains(text(),'Sample Organization 1')]"));

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? ApplyContentFilter(string v)
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.Id("btnContentSearch"));
                Driver.clickEleJs(By.Id("btnContentSearch"));
                Driver.Instance.GetElement(By.XPath("//div[@class='webix_inp_static']/input")).SendKeysWithSpace(v);
                Thread.Sleep(4000);
                Driver.clickEleJs(By.XPath("//div[@class='webix_list_item']/span[@role='checkbox']"));
                IWebElement webElement = Driver.Instance.FindElement(By.XPath("//div[@class='webix_list_item']/span[@role='checkbox']"));
                webElement.SendKeys(Keys.Tab);
                Thread.Sleep(4000);
                result = Driver.Instance.IsElementVisible(By.XPath("//span[contains(text(),'1 content item(s)')]"));
                
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? ResetOrganizationFilter()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.Id("//span[contains(text(),'1 organization(s)')]"));
                Driver.Instance.GetElement(By.XPath("//div[@class='webix_el_box']/input")).Clear();
                Thread.Sleep(4000);
                Driver.clickEleJs(By.XPath("//button[@type='button']"));
                result = Driver.Instance.IsElementVisible(By.XPath("//span[contains(text(),'All organizations')]"));
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? ApplyDomainFilter()
        {
            bool result = false;
            try
            {
                Driver.Instance.selectDropdownValue(By.XPath("//div[@class='webix_view webix_control webix_el_select']/div/select"), "Meridian Global - Core Domain");
                Thread.Sleep(4000);
                result = Driver.Instance.IsElementVisible(By.XPath("//option[contains(text(),'Meridian Global - Core Domain')]"));

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? ResetDomainFilter()
        {
            bool result = false;
            try
            {
                Driver.Instance.selectDropdownValue(By.XPath("//div[@class='webix_view webix_control webix_el_select']/div/select"), "All domains");
                Thread.Sleep(4000);
                result = Driver.Instance.IsElementVisible(By.XPath("//option[contains(text(),'All domains')]"));

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? Verify_Overdue_Users_by_Completion_Criteria_Chart()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//div[contains(text(),'Overdue Users by Completion Criteria')]"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='overdueByCompletable']//div[@class='webix_view panel_drag_view webix_layout_line']//div[@class='webix_view webix_chart']//div//img[@class='webix_map_img']"));
                Driver.clickEleJs(By.Id("dueSoonTabLink"));
                Thread.Sleep(5000);
                Driver.Instance.IsElementVisible(By.XPath("//div[contains(text(),'Users Due Soon by Completion Criteria')]"));
                result = Driver.Instance.IsElementVisible(By.XPath("//div[@id='dueSoonByCompletable']//div[@class='webix_view panel_drag_view webix_layout_line']//div[@class='webix_view webix_chart']//div//img[@class='webix_map_img']"));
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? Verify_DueSoon_Tab()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.Id("dueSoonTabLink"));
                Driver.clickEleJs(By.Id("dueSoonTabLink"));
                Thread.Sleep(5000);
                Driver.Instance.IsElementVisible(By.XPath("//div[@class='webix_el_box']/select"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='dueSoonByOrgs']//canvas[1]"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='dueSoonByManager']//canvas[1]"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='dueSoonByStatus']//canvas[2]"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='dueSoonByCompletable']//canvas[2]"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='dueSoonToolBar']//a[@class='btn btn-default'][contains(text(),'Export')]"));
                Driver.Instance.IsElementVisible(By.XPath("//input[@id='dueSoonSearchUsers']"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Name')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Status')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Due Date')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Content')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Organization')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Completion Criteria')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Manager')]"));
                result = true;

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? Change_TimeFrame_Setting()
        {
            bool result = false;
            try
            {
                Driver.Instance.selectDropdownValue(By.XPath("//div[@class='webix_el_box']/select"),"60 days");
                Thread.Sleep(4000);
                result = true;

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static void Click_DueSoonTab()
        {
            Driver.clickEleJs(By.Id("dueSoonTabLink"));
            Thread.Sleep(5000);
        }

        public static bool? ResetContentFilter()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.Id("//span[contains(text(),'1 content item(s)')]"));
                Driver.clickEleJs(By.Id("//span[@class='webix_multicombo_delete']"));
                Driver.clickEleJs(By.XPath("//button[@type='button']"));
                Thread.Sleep(4000);
                result = Driver.Instance.IsElementVisible(By.XPath("//span[contains(text(),'All content')]"));

            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? VerifySelectedContent(string v)
        {
            bool res = false;
            IWebElement item= Driver.Instance.FindElement(By.XPath("//*[contains(text(),'"+v+"')]"));
            IList <IWebElement> lst = Driver.Instance.FindElements(By.XPath("//div[2]/div[2]/div/div[4]/div[@class='webix_cell']"));
            foreach(IWebElement x in lst)
            {
                if(lst.Contains(item))
                {
                    res = true;

                }
                else
                {
                    res = false;
                    break;
                }
            }
            //lst.Contains(item);

            //return Driver.existsElement(By.XPath("//div[2]/div[2]/div/div[4]/div"));
            return res;
            
        }

        public static void Click_RemoveContentFromContentFilter()
        {
            Driver.clickEleJs(By.XPath("//span[@class='webix_multicombo_delete']"));
        }

        public static bool? VerifyRemovedContent()
        {
            return Driver.existsElement(By.XPath("//li[@class='webix_multicombo_value']"));
        }

        public static bool? VerifySelectAll()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='mdatatable1557127440182']//div[@class='webix_ss_header']//input"));
                Driver.clickEleJs(By.XPath("//div[@id='mdatatable1557127440182']//div[@class='webix_ss_header']//input"));
             
                result = Driver.Instance.GetElement(By.XPath("//div[contains(@class,'webix_first webix_select_mark')]//div[1]//input[1]")).Selected;

            }
            catch (Exception e)
            {

            }
            return result;

        }
    }
}