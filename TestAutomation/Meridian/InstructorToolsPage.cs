using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class InstructorToolsPage
    {
        public static TeachingScheduleTabCommand TeachingScheduleTab { get { return new TeachingScheduleTabCommand(); } }

        public static ManageStudentsTabCommand ManageStudentsTab { get { return new ManageStudentsTabCommand(); } }
    }

    public class ManageStudentsTabCommand
    {
        public void SearchSection(string v1, string v2)
        {
            Driver.GetElement(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_txtSearchFor']")).SendKeysWithSpace(v1);
            //Driver.clickEleJs(By.XPath("//div[@id='MainContent_ucInstructorToolsResults_ucITSearch_pnlMain']/div/div[2]"));

            //Driver.Instance.FindElement(By.XPath("//select[@id='MainContent_ucInstructorToolsResults_ucITSearch_PendingAction']")).Click();
            //Driver.Instance.FindElement(By.XPath("//select[@id='MainContent_ucInstructorToolsResults_ucITSearch_PendingAction']")).Click();
            Driver.Instance.select(By.XPath("//select[@id='MainContent_ucInstructorToolsResults_ucITSearch_PendingAction']"),v2);
           // Driver.Instance.select(By.XPath("//div[@id='MainContent_ucInstructorToolsResults_ucITSearch_pnlMain']/div/div[2]"), v2);


           // Driver.Instance.select(By.Id("MainContent_ucInstructorToolsResults_ucITSearch_pnlMain"),v2);

            Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_btnSearch']"));
        }

      

        public bool? isCourseDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//h3[contains(text(),'"+v+"')]"));
        }

        public void ExpandCourse(string v)
        {
            Driver.clickEleJs(By.XPath("//h3[contains(text(),'"+v+"')]/following::tr[@id='ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00__0']//a[@title='Expand Row']"));
        }

        public bool? VerifyCourseInformation()
        {
            return Driver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl06_rgEvents_ctl00__0']/td[3]"));
        }

        public void ExpandEvent()
        {
            Driver.clickEleJs(By.XPath("//table[@id='ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00']/tbody/tr[2]/td/div/h4/following::a[@title='Expand Row']"));
        }

        public bool? VerifyAdditionalInformation()
        {
            return Driver.existsElement(By.XPath("//div[@id='ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl06_rgEvents_ctl00_ctl06_ctl00_FormView1_pnlAdditionalInfo']/h5"));
        }
    }

    public class TeachingScheduleTabCommand
    {
        public TeachingScheduleTabCommand()
        {
        }

        public EnrollmentCommand Enrollment { get { return new EnrollmentCommand(); } }

        public bool? ListOfSectionSchedules { get { return Driver.existsElement(By.XPath("//td/a")); } }
        public bool? SectionScheduleExpanded { get { return Driver.existsElement(By.Id("ctl00_MainContent_ucTeachingSchedule_rgMyTeachingSchedule_ctl00_ctl06_hlMangStudents")); } }

        public void ClickExpandIcon(string v)
        {
            Driver.existsElement(By.XPath("//td/a"));
            Driver.GetElement(By.XPath(".//li[contains(.,'" + v + "')]/preceding::a[1][@title='Expand Row']"));
            Driver.clickEleJs(By.XPath(".//li[contains(.,'"+v+"')]/preceding::a[1][@title='Expand Row']"));
        }
    }

    public class EnrollmentCommand
    {
        public EnrollmentCommand()
        {
        }

        public void ClickManageGradebook(string v)
        {
            Driver.clickEleJs(By.XPath(".//li[contains(.,'"+v+"')]/following::a[contains(.,'Manage Gradebook')]"));
        }

        public void OptionfromManageGradebook(string v)
        {
            Driver.existsElement(By.LinkText("Toggle Dropdown"));
            Driver.clickEleJs(By.LinkText("Toggle Dropdown"));
            Driver.existsElement(By.LinkText("Manage Content"));
            Driver.clickEleJs(By.LinkText("Manage Content"));
        }
    }
}