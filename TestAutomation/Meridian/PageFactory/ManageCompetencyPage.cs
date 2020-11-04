using OpenQA.Selenium;
using Selenium2;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class ManageCompetencyPage
    {
        
        public static bool? CheckEditDescription { get; internal set; }
        public static bool? CheckEditKeyword { get; internal set; }
        public static CompetencyDetailsTabLink CompetencyDetailsTab
        { get { return new CompetencyDetailsTabLink(); } }

        public static AssignedGroupsTabCommand AssignedGroupsTab 
        {
            get { return new AssignedGroupsTabCommand(); }
        }

        public static bool? CheckGroupTitle(string v)
        {
            { return Driver.GetElement(By.XPath("//table[@id='assigned_entities']/tbody/tr/td[2]")).Text == v; }
        }
        public static LocalizedIndropdownCommand LocalizedIndropdown
        {
            get { return new LocalizedIndropdownCommand(); }
        }

        public static AssociatedContentTabCommand AssociatedContentTab {
            get { return new AssociatedContentTabCommand(); }
            
        }
        public static SelectMandatoryRecordsCommand SelectMandatoryRecords {
get { return new SelectMandatoryRecordsCommand(); }
        }
        public static SupplementalTabCommand SupplementalTab
        {
            get { return new SupplementalTabCommand(); }
        }

        public static MandatoryTabCommand MandatoryTab
        {
            get { return new MandatoryTabCommand(); }
        }
        public static SelectSupplementalRecordsCommand SelectSupplementalRecords
        {
            get { return new SelectSupplementalRecordsCommand(); }
        }

        public static StatusdropdownCommand Statusdropdown
        {
            get { return new StatusdropdownCommand(); }
        }

        public static SetActiveDatesModalCommand SetActiveDatesModal
        {
            get { return new SetActiveDatesModalCommand(); }
        }

        public static bool? CheckStatus_InActive_ActiveFromDate { get; internal set; }
        public static bool? CheckStatus_InActive_ActiveUntilDate { get; internal set; }
        public static bool? CheckStatus_Active_ActiveFromDate_UntilDate { get; internal set; }
        public static bool? AssignedGroupsTab_OptionalRatingfield_clickViewScale {
            get { return Driver.GetElement(By.XPath("//a[contains(text(),'(view scale)')]")).Displayed; }
        }
        public static bool? CheckStatus_Active { get; internal set; }
        public static FrameCommand Frame
        {
            get { return new FrameCommand(); }
        }

        public static AssignGroupFrameCommand AssignGroupFrame
        {
get { return new AssignGroupFrameCommand(); }
        }

        public static void ClickCompetencyDetailsTab()
        {
            Driver.clickEleJs(By.XPath("//a[@href='#details']"));
            Thread.Sleep(2000);
        }

        public static void ClickSavebutton()
        {
            throw new NotImplementedException();
        }

        public static string GetSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static string GetDescriptionLink()
        {
            string actres = string.Empty;
            actres = Driver.GetElement(By.XPath("//a[@id='edit-description-link']")).Text;
            return actres;
                }
        public static string GetKeywordLink()
        {
            Thread.Sleep(2000);
            return Driver.GetElement(By.XPath("//a[@id='edit-keywords-link']")).Text;
        }

        public static void ClickAssignGroupsTab()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.Id("btn-find-group"));
            Thread.Sleep(3000);
        }

        public static bool? CheckSubOrganizationIncluded()
        {
            throw new NotImplementedException();
        }

        public static void ClickLocalizedIndropdown()
        {
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//div[@id='content']/div[2]/div/div/div/ul/li/div/button/span[2]/span"));
        }

        public static void removePermission()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPermissions_MHyperLink1']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl06_chkView']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));

        }

        public static bool? AssociateContent_VerifyAddedRecord(string v)
        {
            Thread.Sleep(5000);
            return Driver.GetElement(By.Id("supplemental_tab")).Text == v;
        }

        public static void SelectRecordFrame_ClickAddbutton()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//table[@id='find-content-table']/tbody/tr/td/input"));
            Driver.clickEleJs(By.Id("btn-add-content"));
            Thread.Sleep(2000);
        }

        public static void AssociateContentClick()
        {
            throw new NotImplementedException();
        }

        public static void addPermission()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucPermissions_MHyperLink1']"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'Assign Permissions')]"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("Everyone");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl04_chkView']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }

        public static void ClickAssociatedContentTab()
        {
            throw new NotImplementedException();
        }

        public static void SupplementalTabclick()
        {
            throw new NotImplementedException();
        }

        public static void SearchTextFrame(string v)
        {
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.clickEleJs(By.Id("searchFor"));
            Driver.GetElement(By.Id("searchFor")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//a[@id='btn-search']/span"));
            Thread.Sleep(2000);



        }

        public static void AssociatedContentTab_click()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Associated Content')]"));
            Thread.Sleep(2000);
        }

        public static void SupplementalTab_Click()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Supplemental')]"));
            Thread.Sleep(2000);
        }

        public static void AssociateContent_Click()
        {
            Driver.clickEleJs(By.Id("btn-assign-supplimental-cnt"));
        }

        public static bool? NameColumn(string v)
        {
            Thread.Sleep(3000);
            Driver.existsElement(By.XPath(".//*[@id='assigned_entities']/tbody/tr/td[2]"));
            return Driver.GetElement(By.XPath(".//*[@id='assigned_entities']/tbody/tr/td[2]")).Text==v;
        }
        public static bool? NameColumn2ndRow(string v)
        {
            Thread.Sleep(3000);
            Driver.existsElement(By.XPath(".//table[@id='assigned_entities']/tbody/tr[2]/td[2]"));
            return Driver.GetElement(By.XPath(".//table[@id='assigned_entities']/tbody/tr[1]/td[2]")).Text == v;
        }
        public static bool AssignedGroupsTab_OptionalRatingfield_NoScaledropdown()
        {
           return Driver.existsElement(By.XPath("//div[@id='usergroups']/div/div/div/button/span"));
        }

        public static void ClickStatusdropdown()
        {
            throw new NotImplementedException();
        }

        public static void SelectActive()
        {
            throw new NotImplementedException();
        }

        public static void ClickAssignedGroupsTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Assigned Groups')]"));
        }

        public static void SetActiveDatesModal_NoStartDateCheckbox_Check()
        {
            throw new NotImplementedException();
        }

        public static void SetActiveDatesModal_NoEndDateCheckbox_Check()
        {
            throw new NotImplementedException();
        }

        public static void SetActiveDatesModal_NoEndDateCheckbox_Uncheck()
        {
            throw new NotImplementedException();
        }

        public static void SetActiveDatesModal_EnterEndDate(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? CheckStatus_Activ_ActiveUntil(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? CheckStatus_Active_ActiveFrom(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? AssignedGroupsTab_OptionalRatingfield_clickdropdown()
        {
            throw new NotImplementedException();
        }



        public static void ClickSubTabAssociateContent()
        {
            throw new NotImplementedException();
        }

        public static void ClickSubTabMandatoryContent()
        {
            throw new NotImplementedException();
        }

        public static void ClickButtonAssociateContent()
        {
            throw new NotImplementedException();
        }

        public static void SelectProficiencyScaleFromDropdown()
        {
            throw new NotImplementedException();
        }

        public static void ClickOnAssignedGroupSubTab()
        {
            throw new NotImplementedException();
        }

        public static void ClickButtonAssignedGroup()
        {
            throw new NotImplementedException();
        }

        public static void ChangeRequiredRatingsForJobTitle()
        {
            throw new NotImplementedException();
        }

        public static string CompetencySupplementalTabText()
        {
            Driver.existsElement(By.XPath("(//div[@id='panel-empty']/p/strong)[3]"));
            return Driver.GetElement(By.XPath("(//div[@id='panel-empty']/p/strong)[3]")).Text;
        }

        public static void SelectALLAssignedGroup()
        {
            Driver.clickEleJs(By.XPath("//input[@name='btSelectAll']"));
        }

        public static void ClickAssignGroupsTabWhenrecordexist()
        {
            Driver.existsElement(By.XPath("//div[@id='panel-group-some']/div/button[2]"));
            Driver.clickEleJs(By.XPath("//div[@id='panel-group-some']/div/button[2]"));
            Thread.Sleep(2000);
        }

        public static bool CompetencyTitleText(string v)
        {
            IWebElement elm = Driver.GetElement(By.XPath("//div[@id='content']/div/h1"));
            if(elm.Text==v)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class AssignGroupFrameCommand
    {
        public void SelectJobTitleFilter()
        {
            throw new NotImplementedException();
        }

        public void SearchGroups(string v)
        {
            Driver.GetElement(By.Id("SearchFor-entities")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
        }

        public void SelectUserGroupFilter()
        {
            //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.clickEleJs(By.XPath(".//*[@id='filter-group']/div/div[1]/div/div/div/button"));
            //Driver.clickEleJs(By.Id("//div[@id='filter-group']/div/div/div/div/div/button/span"));
            //Driver.clickEleJs(By.XPath("//a[contains(text(),'User Groups')])[3]"));
            //Driver.select(By.XPath(".//*[@id='filter-group']/div/div[1]/div/div/div/button"), v);
            Driver.clickEleJs(By.XPath(".//*[@id='RoleType']/li[4]/a"));
        }
    }

    public class FrameCommand
    {
        public void SelectFirstContent()
        {
            throw new NotImplementedException();
        }

        public void ClickButtonAdd()
        {
            throw new NotImplementedException();
        }

        public void ClickButtonDelete()
        {
            throw new NotImplementedException();
        }

        public void EnterScaleTitle(string v)
        {
            throw new NotImplementedException();
        }

        public void EnterRatingCriteriaLable1(string v)
        {
            throw new NotImplementedException();
        }

        public void ClickButtonCreate()
        {
            throw new NotImplementedException();
        }

        public void EnterCompetencyToAdd(string v)
        {
            throw new NotImplementedException();
        }

        public void ClickButtonSearch()
        {
            throw new NotImplementedException();
        }

        public void SelectCompetencyCheckbox()
        {
            throw new NotImplementedException();
        }

        public void ClickButtonAssign()
        {
            throw new NotImplementedException();
        }

        public void SearchForJobTitle(string v)
        {
            throw new NotImplementedException();
        }

        public void SelectJobTitleCheckbox(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class SetActiveDatesModalCommand
    {
        public void NoStartDateCheckbox_UnCheck()
        {
            throw new NotImplementedException();
        }

        public void NoEndDateCheckbox_Check()
        {
            throw new NotImplementedException();
        }

        public void EnterStartDate(object futureDate)
        {
            throw new NotImplementedException();
        }

        public void ClickSave()
        {
            throw new NotImplementedException();
        }

        public void NoStartDateCheckbox_Check()
        {
            throw new NotImplementedException();
        }

        public void NoEndDateCheckbox_UnCheck()
        {
            throw new NotImplementedException();
        }

        public void EnterEndDate(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class StatusdropdownCommand
    {
        public void SelectActive()
        {
           
            throw new NotImplementedException();
        }

        public void SelectSetActiveDates()
        {
            throw new NotImplementedException();
        }
    }

    public class SelectSupplementalRecordsCommand
    {
        public void ClickMakeMandatory()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Make Mandatory')]"));

        }
    }

    public class MandatoryTabCommand
    {
        public bool? CheckRecord { get; internal set; }
    }

    public class SupplementalTabCommand
    {
        public bool? CheckRecord { get; internal set; }
    }

    public class SelectMandatoryRecordsCommand
    {
        public void ClickMakeSupplemental()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.LinkText("Make Supplemental"));
            
        }
    }

    public class AssociatedContentTabCommand
    {
        public bool? CheckMandatoryTabCount {
            get { return Driver.GetElement(By.LinkText("Make Supplemental")).Displayed; }
                }
        public bool? CheckSupplementalTabCount {
            get { return Driver.GetElement(By.LinkText("Make Mandatory")).Displayed; }
        }

        public void ClickMandatoryTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Mandatory')]"));
            Thread.Sleep(2000);
        }

        public void ClickSupplementalTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Supplemental')]"));
            Thread.Sleep(2000);
        }
    }

    public class LocalizedIndropdownCommand
    {
        public LocalizedIndropdownCommand()
        {
        }

        public string CheckLanguage(string v)
        {
            String var2 = null;
            IWebElement select = Driver.Instance.FindElement(By.XPath("//select[@id='selectLanguage']"));
            IList<IWebElement> options = select.FindElements(By.TagName("option"));
            foreach (IWebElement element in options)
            {
                var2 = element.Text;
                if(var2.Contains(v))
                {
                    return var2;
                }
            }
            //return options.ToString();
            return var2;
        }

        public void ClickAddLocalization()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div[2]/div/div/div/ul/li/div/button/span[2]/span"));
            Driver.select(By.XPath("//select[@id='selectLanguage']"), "Add Localization");
        }

        public void SelectLanguage(String v)
        {
            //Driver.clickEleJs(By.XPath("//button[@data-id='selectLanguage']"));
            //Driver.clickEleJs(By.XPath("//span[contains(.,'Add Localization')]"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.clickEleJs(By.XPath("//button[@data-id='addLanguage']"));
            Driver.clickEleJs(By.XPath("//span[contains(.,'" + v + "')]"));
        }
    }

    public class AssignedGroupsTabCommand
    {
        public bool? OptionalRatingfield_clickdropdown { get; internal set; }

        public AssignedGroupsTabCommand()
        {
        }

        public void ClickAssignGroupbutton()
        {
            Driver.clickEleJs(By.XPath(".//*[@id='btn-find-group']"));

        }
        public void ClickAssignGroupButtonRHS()
        {
            Driver.Instance.waitforframe(By.XPath("//*[@id='panel - group - some']/div[1]/button[2]"));
            Driver.clickEleJs(By.XPath("//*[@id='panel - group - some']/div[1]/button[2]"));
            Thread.Sleep(2000);
        }

        public void ClickSearchRecords(string v)
        {
            Driver.clickEleJs(By.Id("btSelectItem_7D4946A74EDA42C6A16D217FCE0D89FF"));
        }

        public void ClickRemovebutton()
        {
            Driver.clickEleJs(By.XPath("//input[@name='btSelectAll']"));
            //Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
            //if (Driver.existsElement(By.XPath("//input[@data-index='1']")))
            //{
            //    Driver.clickEleJs(By.XPath("//input[@data-index='1']"));
            //}
            //if (Driver.existsElement(By.XPath("//input[@data-index='2']")))
            //{
            //    Driver.clickEleJs(By.XPath("//input[@data-index='2']"));
            //}

            Driver.clickEleJs(By.XPath("//button[@id='btn-remove']"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-entities']"));

        }

        public void ClickSearchbutton()
        {
            throw new NotImplementedException();
        }

        public void ClickRemoveAllbutton()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove']"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-entities']"));
        }

        public void OptionalRatingfield_dropdown_SelectProficiencyScale(string v)
        {
            Driver.Instance.select(By.Id("selectScale"), "test");
        }

        public bool? RequiredRatingColumn_CheckRecord(string v)
        {
            Thread.Sleep(5000);
            return Driver.GetElement(By.XPath("//*[@id='assigned_entities']/tbody/tr/td[5]/a")).Text == v;
        }

        public void OptionalRatingfield_clickViewScale()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'(view scale)')]"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));

        }

        public void ClickRemoveinRemoveConfirmationModal()
        {
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-entities']"));
        }

        public void ClickAssignGroupButtonOuter()
        {
            Driver.Instance.existsElement(By.XPath("//div[@id='panel-group-some']/div/button[2]"));
            Driver.clickEleJs(By.XPath("//div[@id='panel-group-some']/div/button[2]"));
            Thread.Sleep(2000);
        }
    }
}

public class CompetencyDetailsTabLink
    {


    public void AddDescription(string v)
    {
        Thread.Sleep(3000);
        Driver.clickEleJs(By.XPath("//a[@id='edit-description-link']"));
        Driver.GetElement(By.XPath("//textarea[@class='form-control input-large']")).Clear();
        Driver.GetElement(By.XPath("//textarea[@class='form-control input-large']")).SendKeysWithSpace(v);
        Thread.Sleep(2000);
        Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        Thread.Sleep(2000);
        Driver.Instance.WaitForElement(By.CssSelector("div.alert.alert-dismissible.alert-fixed.alert-success"));



    }

    public void AddKeywords(string v)
    {
        Thread.Sleep(2000);
        Driver.clickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
        Driver.GetElement(By.XPath("//input[@class='form-control input-sm']")).Clear();
        Driver.GetElement(By.XPath("//input[@class='form-control input-sm']")).SendKeysWithSpace(v);
        Thread.Sleep(2000);
        Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        Thread.Sleep(2000);
        Driver.Instance.WaitForElement(By.CssSelector("div.alert.alert-dismissible.alert-fixed.alert-success"));
    }
    
}