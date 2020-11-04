using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class EditPermissionsPage
    {
        public static CareerMenuCommand CareerMenu { get { return new CareerMenuCommand(); } }

        public static SetPermissionCommand PermissionforCareerPaths { get
            { return new SetPermissionCommand(); } }

        public static string VerifySearchText(string v)
        {
            Driver.existsElement(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60__1:0_5:0_4']/td[2]"));
            return Driver.GetElement(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60__1:0_5:0_4']/td[2]")).Text;

        }

        public static string VerifySearchText1(string v)
        {
            return Driver.GetElement(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60_ctl18_Detail50__1:0_5:0_4:0_0']/td[2]")).Text;
        }

        public static void SetPermissionforonlyAdmin()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_lnkCostAdd"));
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl06_chkView"));
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl06_chkLaunch"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnCancel"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }

        public static void clickAssignPermission()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_lnkCostAdd"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_lnkCostAdd"));
        }

        public static void AssignPermissionTo(string v)
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_txtSearchFor"));
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_txtSearchFor")).Clear();
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_txtSearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_ddlSearchType"));
            Driver.select(By.Id("MainContent_MainContent_UC1_ddlSearchType"), "All words");
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
            Driver.existsElement(By.XPath("//td[3]/input"));
            Driver.clickEleJs(By.XPath("//td[3]/input"));
            Driver.clickEleJs(By.XPath("//td[5]/input"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }
    }

    public class CareerMenuCommand
    {
        public CareerMenuCommand()
        {
        }

        public bool? CareerPathOption { get { return Driver.GetElement(By.XPath("//td[2]/table/tbody/tr[12]/td[2]/table/tbody/tr[9]/td[2]")).Displayed; } }
        public bool? CompetenciesOption { get { return Driver.GetElement(By.XPath("//td[2]/table/tbody/tr[12]/td[2]/table/tbody/tr/td[2]")).Displayed; } }
        public bool? EvaluationOption { get { return Driver.GetElement(By.XPath("//td[2]/table/tbody/tr[12]/td[2]/table/tbody/tr[5]/td[2]")).Displayed; } }
        public bool? JobTitleOption { get { return Driver.GetElement(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60__1:0_5:0_0']/td[2]")).Displayed; } }

        public bool? JobTitleOptionwithCareerDevelopmentYes { get { return Driver.GetElement(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60__1:0_5:0_3']/td[2]")).Displayed; } }

       
        public bool? ProficiencyScaleOption { get { return Driver.GetElement(By.XPath("//td[2]/table/tbody/tr[12]/td[2]/table/tbody/tr[3]/td[2]")).Displayed; } }

        internal bool? NoCareerPathOption(string v)
        {
            return Driver.existsElementwithElementText(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60__1:0_5:0_4']/td[2]"),v);

        }

        internal bool? NoCompetenciesOption(string v)
        {
            return Driver.existsElementwithElementText(By.XPath("//td[2]/table/tbody/tr[12]/td[2]/table/tbody/tr/td[2]"), v);
        }

        internal bool? NoProficiencyScaleOption(string v)
        {
            return Driver.existsElementwithElementText(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60__1:0_5:0_1']/td[2]"), v);
        }

        internal bool? No360EvaluationOption(string v)
        {
            return Driver.existsElementwithElementText(By.XPath("//tr[@id='ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60__1:0_5:0_4']/td[2]"), v);
        }
    }

    public class SetPermissionCommand
    {
        public SetPermissionCommand()
        {
        }

        internal void SelectAllow()
        {
            Driver.clickEleJs(By.Id("ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60_ctl16_rbAllow"));
            Thread.Sleep(2000);
        }

        internal void SelectDeny()
        {
            Driver.clickEleJs(By.Id("ctl03_RadGrid1_ctl00_ctl09_Detail20_ctl21_Detail60_ctl18_Detail50_ctl04_rbDeny"));
            Thread.Sleep(2000);
        }

        internal void ClickSave()
        {
            Driver.clickEleJs(By.Id("ctl03_btnSave"));
            Thread.Sleep(2000);
        }
    }
}