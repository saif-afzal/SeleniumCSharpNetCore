using OpenQA.Selenium;
using Selenium2.Meridian;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class RunReportPage:ObjectInit
    {
        private IWebDriver objDriver;
        public RunReportPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  string Title
        {
            get {
                string res = string.Empty;
                res = objDriver.Title;
                //objDriver.Navigate_to_TrainingHome();
                return res;
            }
        }

        public  ProgessStatusDropdownCommand ProgessStatusDropdown { get { return new ProgessStatusDropdownCommand(objDriver); } }

        public  OrganizationCommand Organization { get { return new OrganizationCommand(objDriver); } }

        public  void ClickRunReport()
        {
            Thread.Sleep(10000);
            // Meridian_Common.parentwdw = objDriver..CurrentWindowHandle;
            objDriver.ClickEleJs(By.XPath("//input[@value='Run Report']"));
        }

        public  bool? isOrganizationDisplayed()
        {
            return objDriver.existsElement(By.XPath("//label[@id='TabMenu_ML_BASE_TAB_Report_NamingContainer:strOrganization']//span[contains(text(),'Organization')]"));
        }

        public  bool? isSectionActivityDisplayed()
        {
            return objDriver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strSectionActivity']"));
            
        }

        public  bool? isStartDateDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_strDateFrom||DATEPICKER_dateInput']"));
            
        }

        public  bool? isEndDateDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_strDateTo||DATEPICKER_dateInput']"));
        }

        public  bool? isCapacityDisplayed()
        {
            return objDriver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strCapacityOperator']"));
        }

        public  bool? isCapacityTextboxDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_intCapacityValue']"));
        }

        public  bool? isEnrollmentDisplayed()
        {
            return objDriver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strEnrollmentOperator']"));
        }

        public  bool? isEnrollmentTextboxDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_intEnrollmentValue']")); 
        }

        public  bool? isRecordPerPageDisplayed()
        {
            return objDriver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strPageRowCount']"));
        }

        public  bool? isLayoutDisplayed()
        {
            return objDriver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_AgReportLayout']"));
        }

        public  bool? isRunReportButtonDisplayed()
        {
            return objDriver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_RunReport']"));
        }

        public  void RunReportWith(string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9, string v10)
        {
            objDriver.existsElement(By.XPath("//span[contains(text(),'Sample Organization 1')]/preceding::input[@type='checkbox'][1]"));
            objDriver.ClickEleJs(By.XPath("//span[contains(text(),'Sample Organization 1')]/preceding::input[@type='checkbox'][1]"));
            Meridian_Common.Runreportpage_Organization = objDriver.GetElement(By.XPath("//span[contains(text(),'Sample Organization 1')]")).Text;



            objDriver.select(By.XPath("//select[@name='TabMenu$ML_BASE_TAB_Report$strSectionActivity']"), v2);
            //Meridian_Common.Runreportpage_SectionActivity ="";
            Meridian_Common.Runreportpage_SectionActivity = v2;


            




            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_strDateFrom||DATEPICKER_dateInput']")).SendKeys(v3);
            // Meridian_Common.Runreportpage_DateFrom = objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_strDateFrom||DATEPICKER_dateInput']")).Text;
            Meridian_Common.Runreportpage_DateFrom = v3;
             objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_strDateTo||DATEPICKER_dateInput']")).SendKeys(v4);
            //Meridian_Common.Runreportpage_DateTo = objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_strDateTo||DATEPICKER_dateInput']")).Text;
            Meridian_Common.Runreportpage_DateTo = v4;
            objDriver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strCapacityOperator']"), v5);
            //Meridian_Common.Runreportpage_CapacityOperator = objDriver.GetElement(By.XPath("//select[@name='TabMenu$ML_BASE_TAB_Report$strCapacityOperator']")).Text;
            Meridian_Common.Runreportpage_CapacityOperator = v5;
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_intCapacityValue']")).SendKeys(v6);
            //Meridian_Common.Runreportpage_CapacityValue = objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_intCapacityValue']")).Text;
            Meridian_Common.Runreportpage_CapacityValue = v6;
            objDriver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strEnrollmentOperator']"), v7);
            //Meridian_Common.Runreportpage_EnrollmentOperator = objDriver.GetElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strEnrollmentOperator']")).Text;
            Meridian_Common.Runreportpage_EnrollmentOperator = v7;
            //objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_intEnrollmentValue']").SendKeys(v8);
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_intEnrollmentValue']")).SendKeys(v8);
           // Meridian_Common.Runreportpage_EnrollmentValue = objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_intEnrollmentValue']")).Text;
            Meridian_Common.Runreportpage_EnrollmentValue = v8;

            objDriver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strPageRowCount']"), v9);
            objDriver.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_AgReportLayout']"), v10);
            Meridian_Common.Runreportpage_Layout = objDriver.GetElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_Report_TDElementAgReportLayout']/select")).Text;

            


            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Report_RunReport']"));


        }

        public  bool? isDomainReport_TrainingAssignmentPeriodbyUserLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Domain Report - Training Assignment Periods by Use')]"));
        }

        public  bool? isOrganizationReport_TrainingAssignmentsbyContentItemLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Training Assignments by Cont')]"));
        }

        public  bool? isComplestionStatusDisplay()
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'Completion Status')]"));
        }

        public  bool? isDomainReport_TrainingAssignmentsbyContentItemLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Domain Report - Training Assignments by Content It')]"));
        }

        public  bool? isDomainReport_TrainingAssignmentsLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Domain Report - Training Assignments')]"));
        }

        public  bool? isOrganizationReport_TrainingAssignmentsbyUserLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Training Assignments by User')]"));
        }

        public  bool? isManagersReport_ProficiencyRatingsisDisplay()
        {
            objDriver.existsElement(By.XPath("//div[@id='WorkSpaceContainer']/h2"));
            return objDriver.GetElement(By.XPath("//div[@id='WorkSpaceContainer']/h2")).Text.Equals("Manager's Report - Proficiency Ratings");
        }

        public  bool? isRemoveOrganizationDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@onclick='ClearReportOrg()']")).Displayed;
        }

        public  bool? isCotentActivityDisplay()
        {
            return objDriver.GetElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Report_strContentActivity']")).Displayed;
        }

        public  bool? isIncludeSubOrganizationDisplayed()
        {
            return objDriver.existsElement(By.XPath("//label[@for='TabMenu_ML_BASE_TAB_Report_strIncludeSubOrgs']"));
        }

        public  bool? isSearchtextdisplay()
        {
            return objDriver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));
        }

        public  SearchwithCommand Searchwith(string v)
        {
            return new SearchwithCommand(v);
        }

        public  void SelectresultandClickSelect()
        {
            if (objDriver.existsElement(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_CandidateJobTitleDataGrid']/tbody/tr[2]/td/span/input")))
            {
                objDriver.ClickEleJs(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_CandidateJobTitleDataGrid']/tbody/tr[2]/td/span/input"));
                objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_btnAdd"));
            }
            if (objDriver.existsElement(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_ContentListingDataGrid']/tbody/tr[2]/td/span/input")))
            {
                objDriver.ClickEleJs(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_ContentListingDataGrid']/tbody/tr[2]/td/span/input"));
                objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_btnAdd"));
            }
        }

        public  void CLickSearchButton()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
        }

        public  bool? isCompentencysearchfielddisplay()
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'Competency')]"));
        }

        public  bool? isManagersReportContentAccessdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='WorkSpaceContainer']/h2"));
        }

        public  bool? isSF_182Requestsdisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'SF-182 Requests')]"));

        }

        public  bool? isSF_182Sratusdisplay()
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'SF-182 Status:')]"));
        }

        public  void selectSF182Sratus(string v)
        {
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Report_SF182REQUEST_STATUS_14"));
        }

        public  bool? isOrganizationReport_ExternalLearningLableDisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - External Learning')]"));
        }

        public  bool? isExternalLearneringTypedisplay()
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'External Learning Type')]"));
        }

        public  bool? isDomainReport_ExternalLearningLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Domain Report - External Learning')]"));
        }

        public  bool? isRecentUserAccessLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Recent User Access')]"));
        }

        public  bool? isRepeatUserAccessLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Repeat User Access')]"));
        }

        public  bool? isManagersReport_ExternalLearningLabeldisplay()
        {
            objDriver.existsElement(By.XPath("//div[@id='WorkSpaceContainer']/h2"));
            return objDriver.GetElement(By.XPath("//div[@id='WorkSpaceContainer']/h2")).Text.Equals("Manager's Report - External Learning");
        }

        public  bool? isOrgReportContentAccessdisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Content Access')]"));
        }

        public  bool? isTestItemAnalysisResponseSummarydisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Test Item Analysis Response Summary')]"));
        }

        public  void SelectFirstresultandClickSelect()
        {
            objDriver.existsElement(By.XPath("//tr[2]/td/span/input"));
            objDriver.ClickEleJs(By.XPath("//tr[2]/td/span/input"));
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_btnAdd"));
        }

        public  bool? isManagersReport_TrainingAssignmentLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Manager's Report - Training Assignment Exemptions')]"));
        }

        public  bool? isExemptionTypeTypedisplay()
        {
            return objDriver.existsElement(By.XPath("//span[contains(text(),'Exemption Type')]"));
        }

        public  bool? isOrganizationReport_TrainingAssignmentsLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Training Assignments')]"));
        }

        public  bool? isOrganizationReport_TrainingProgressLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Training Progress')]"));
        }

        public  bool? isTrainingProgressbyUserLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Training Progress by User')]"));
        }

        public  bool? isManagersReport_TrainingAssignmentsLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='WorkSpaceContainer']/h2"));
        }

        public  bool? isTrainingProgressbyContentLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Training Progress by Content')]"));
        }

        public  bool? isSummaryReport_TrainingProgressbyOrganizationLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Summary Report - Training Progress by Organization')]"));
        }

        public  bool? isSummaryReport_UserProgressbyOrganizationLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Summary Report - User Progress by Organization')]"));
        }

        public  bool? isDomainReport_TrainingProgressLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Domain Report - Training Progress')]"));
        }

        public  bool? isDomainReport_TrainingAssignmentLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Domain Report - Training Assignments')]"));
        }

        public  bool? isOrganizationReport_TrainingAssignmensPeriodbyUsertLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Training Assignments by User')]"));
        }

        public  bool? isOrganizationReport_TrainingAssignmentPeriodbyContentItemLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Training Assignment Periods')]"));
        }

        public  bool? isTestItemAnalysisResponseDetailsdisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Test Item Analysis Response Details')]"));
        }

        public  bool? isTrainingProgressDetailsbyContainerLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Training Progress Details by Container')]"));
        }

        public  bool? isLastNameSearchtextdisplay()
        {
            return objDriver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_USR_LAST_NAME']"));
        }

        public  void SelectFirstUserfromresultandClickSelect()
        {
            objDriver.existsElement(By.XPath("//table[4]/tbody/tr[2]/td/span/input"));
            objDriver.ClickEleJs(By.XPath("//table[4]/tbody/tr[2]/td/span/input"));
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_btnAdd"));
        }

        public  bool? isManagersReport_TrainingAssignmentsExemptionsLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='WorkSpaceContainer']/h2"));
        }

        public  bool? isOrganizationReport_TrainingAssignmentPeriodbyUserLabeldisplay()
        {
            return objDriver.existsElement(By.XPath("//h2[contains(text(),'Organization Report - Training Assignment Periods')]"));
        }
    }

    public class OrganizationCommand
    {
        private IWebDriver objDriver;
        public OrganizationCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public bool? isSelectble(string v)
        {
            return objDriver.GetElement(By.XPath("//input[@class='webix_tree_checkbox']")).Displayed;
        }

        public bool? isdisplay(string v)
        {
            return objDriver.GetElement(By.XPath("//div[contains(text(),'Sample Organization 1')]")).Text.Equals(v);
        }
    }

    public class SearchwithCommand
    {
        private string v;
        private IWebDriver objDriver;
        public SearchwithCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public SearchwithCommand(string v)
        {
            this.v = v;
        }

        public void CLickSearchButton()
        {
            objDriver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeys(v);
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
        }
    }

    public class ProgessStatusDropdownCommand
    {
        private IWebDriver objDriver;
        public ProgessStatusDropdownCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void SelectProgressStatus(string v)
        {
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Report_strProgressStatus"));
            Thread.Sleep(1000);
            objDriver.select(By.Id("TabMenu_ML_BASE_TAB_Report_strProgressStatus"), v);
        }
    }
}