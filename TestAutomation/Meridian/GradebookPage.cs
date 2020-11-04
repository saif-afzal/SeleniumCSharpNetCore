using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class GradebookPage
    {
        public static GradebookTabCommand GradebookTab
        {
            get { return new GradebookTabCommand(); }
        }

        public static bool? isGeneralCourseDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public static bool? isScoreDisplayed()
        {
            throw new NotImplementedException();
        }

        public static void clickContentTab()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkContent"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkContent"));
        }

        public static bool? GradebookTabDisplay()
        {
            return Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkGradebook"));

        }
    }

    public class GradebookTabCommand
    {
        public GradesSubTabCommand GradesSubTab { get { return new GradesSubTabCommand(); } }

        public UserListGridCommand UserListGrid { get { return new UserListGridCommand(); } }

        public void ClickViewLearner()
        {
            throw new NotImplementedException();
        }

        public bool? isScore(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isGeneralCourseDisplayed(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isScoreDisplayed()
        {
            throw new NotImplementedException();
        }

        public bool? isTestDisplayed()
        {
            throw new NotImplementedException();
        }

        public void ClickContentTab()
        {
            throw new NotImplementedException();
        }

        public bool? isGeneralCoursetDisplayed()
        {
            throw new NotImplementedException();
        }

        public bool? isScormCourse2004tDisplayed()
        {
            throw new NotImplementedException();
        }

        public bool? isScormCourse12Displayed(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isScoreUpdatedAsActualScoreXWeightOfGradebookColumn()
        {
            throw new NotImplementedException();
        }

        public bool? GradeTest()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-gradebook']/tbody/tr/td[5]/a"));
                //Driver.existsElement(By.XPath("//table[@id='table-gradebook']/tbody/tr/td[5]/a"));
               // Driver.clickEleJs(By.XPath("//table[@id='table-gradebook']/tbody/tr/td[5]/a"));
                Driver.clickEleJs(By.XPath("//select[@id='grading-scale']"));
                Driver.GetElement(By.XPath("//select[@id='grading-scale']")).SendKeysWithSpace("p");

                //Driver.selectdropdown(By.XPath("//select[@id='grading-scale']"), "Pass");
                //table[@id='table-gradebook']/tbody/tr/td[5]/span/div/form/div/div/div/select
                result = Driver.existsElement(By.XPath("//button[contains(text(),'Submit')]"));
                 Driver.clickEleJs(By.XPath("//button[contains(text(),'Submit')]"));
                
            }
            catch
            { }
            return result;
        }

        public bool? BulkGrades()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-gradebook']/thead/tr/th/div/input"));
                Driver.clickEleJs(By.XPath("//div[3]/div/button/span"));
                Driver.clickEleJs(By.LinkText("Completed"));
                result = Driver.existsElement(By.XPath("//html[@id='PageBody']/body/div/div/div/div[3]/button[2]"));
                Driver.clickEleJs(By.XPath("//html[@id='PageBody']/body/div/div/div/div[3]/button[2]"));
               
            }
            catch
            { }
            return result;
        }

        public bool? VerifyGradedContent()
        {
            
                Driver.clickEleJs(By.XPath("//table[@id='table-gradebook']/thead/tr/th/div/input"));
                return Driver.Instance.IsElementVisible(By.XPath("//table[@id='table-gradebook']/thead/tr/th[5]/div/span"));
             
           
        }

        public bool? VerifyGradedContentisNotDisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='table-gradebook']/thead/tr/th[5]/div/span"));
        }

        public bool? isGradesSubTabDisplay()
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'Grades')]"));
        }

        public void SelectLearner(string v)
        {
            Driver.clickEleJs(By.XPath("//td[contains(text(),"+v+")]/preceding::input[1]"));
        }

        public void ProgressStatus(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='gradebookToolbar']/div/div/div[3]/div[1]/button"));
            Driver.select(By.XPath("//div[@id='gradebookToolbar']/div/div/div[3]/div[1]/button"), v);
            Driver.Instance.findandacceptalert();
        }

        public void AttendenceStatus(string v)
        {
            Driver.clickEleJs(By.XPath("//button[contains(text(),'Attended')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Yes')]"));
            //Driver.select(By.XPath("//div[@id='gradebookToolbar']/div/div/div[3]/div[2]/button"), v);
            //Driver.Instance.findandacceptalert();
        }

        public bool? verifyDuedateisdisplay()
        {
            return Driver.existsElement(By.XPath("//body[@class='canvas']"));
        }

        public void CompleteSection()
        {
            Driver.Instance.FindElement(By.XPath("//table[@id='table-gradebook']/tbody/tr/td/input")).Click();
            Driver.Instance.FindElement(By.XPath("//div[@id='gradebookToolbar']/div/div/div[3]/div/button/span")).Click();
            Driver.Instance.FindElement(By.LinkText("Completed")).Click();
            Driver.Instance.FindElement(By.XPath("//html[@id='PageBody']/body/div/div/div/div[3]/button[2]")).Click();
        }

        public bool? isPaginationdisplay()
        {
            return Driver.existsElement(By.XPath("//button[@id='page_forward_events']//span"));
        }
    }

    public class UserListGridCommand
    {
        public UserListGridCommand()
        {
        }

        public bool Verify_ColumnHeader()
        {
            bool result = false;

            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Name')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Progress')]"));
                Driver.Instance.IsElementVisible(By.XPath("//strong[contains(text(),'Attendance')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Score')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Name')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Progress')]"));               
                Driver.clickEleJs(By.XPath("//a[contains(.,'Score')]"));
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public bool Verify_AttendanceSubTab(string v1, string v2)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'All Attended')]"));
            return Driver.existsElement(By.XPath("//a[contains(text(),'All Absent')]"));
        }

        public void ClickAllAttended()
        {
            Driver.clickEleJs(By.LinkText("All Attended"));
        }

        public void ClickAllAbsent()
        {
            Driver.clickEleJs(By.LinkText("All Absent"));
        }

        public bool? Verify_ColumnHeaderforRecevent()
        {
            bool result = false;

            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Name')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Progress')]"));
                Driver.Instance.IsElementVisible(By.XPath("//strong[contains(text(),'Attendance')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Score')]"));
                Driver.Instance.IsElementVisible(By.XPath("//th[1]//div[1]//strong[1]")); //event name
                Driver.clickEleJs(By.XPath("//a[contains(.,'Name')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Progress')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Score')]"));
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }

    public class GradesSubTabCommand
    {
        public GradesSubTabCommand()
        {
        }

        public GradeSubmissionsCommand GradeSubmissions { get { return new GradeSubmissionsCommand(); } }

        public void ClickGrades()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Grades')]"));
        }

        public bool? isGradesOnlyButtonDisplay()
        {
            return Driver.existsElement(By.XPath("//label[@class='btn btn-default']"));
        }

        public bool? isGradeSubmissionsButtonDisplay()
        {
            return Driver.existsElement(By.XPath("//label[@class='btn btn-default active']"));
        }
    }

    public class GradeSubmissionsCommand
    {
        public GradeSubmissionsCommand()
        {
        }

        public bool? isusertabledisplay()
        {
            return Driver.existsElement(By.XPath("//div[@class='fixed-table-container']"));
        }

        public bool? UserTablecolumnHeaders(string v1, string v2, string v3, string v4)
        {
            Driver.GetElement(By.XPath("//a[@class='th-inner sortable both']")).Text.Equals(v1);
            Driver.GetElement(By.XPath("//div[contains(text(),'Score')]")).Text.Equals(v2);
            Driver.GetElement(By.XPath("//div[contains(text(),'Attendance')]")).Text.Equals(v3);
            return Driver.GetElement(By.XPath("//span[contains(text(),'Graded Assignment')]")).Text.StartsWith(v4);

        }
    }
}