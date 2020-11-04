using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;


namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class InstructorsPage
    {
        public static void RemoveInstructor()
        {
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSelectedInstructor_ctrl0_lnkDelete"));
            Driver.Instance.findandacceptalert();
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
            // throw new NotImplementedException();
        }

        public static void AddInstructor(string s)
        {
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME']")).SendKeysWithSpace(s);
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_AddUsers_btnAdd']"));
        }

        public static bool Click_GradebookConsole()
        {
            bool result = false;
            try
            {
                result = Driver.Instance.IsElementVisible(By.Id("ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl06_lnkSectionFilesNotes"));
                Driver.clickEleJs(By.Id("ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl06_lnkSectionFilesNotes"));
             

            }
            catch (Exception e)
            {

            }

            return result;
        }

        public static void Search_ForSection(string classroom_title)
        {
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucGBConsole_txtSearchFor']")).SendKeysWithSpace(classroom_title);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucGBConsole_btnSearch']"));
        }

        public static bool? Click_GradebookButton()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[@id='ctl00_MainContent_ucGBConsole_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl04_lnkEditGB']"));
                Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucGBConsole_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl04_lnkEditGB']"));
                result = Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkGradebook']"));

             
            } catch(Exception e)
            {

            }

            return result;
        }

        public static void Click_ManageStudent()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucTabs_lbManageStudents']"));
        }

        public static void Search_ForSection_InManageStudentPage(string classroomcoursetitle)
        {
            if(Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_ucInstructorToolsResults_ucLinks_lblAll']")))
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucInstructorToolsResults_ucLinks_lblAll']"));
                Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_txtSearchFor']")).SendKeysWithSpace(classroomcoursetitle);
                Driver.Instance.selectDropdownValue(By.XPath("//select[@id='MainContent_ucInstructorToolsResults_ucITSearch_PendingAction']"), "All");
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_btnSearch']"));
                //Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Section1')]"));
            }
            else if(Driver.existsElement(By.Id("MainContent_ucInstructorToolsResults_ucITSearch_PendingAction")))
            {
                Driver.Instance.select(By.Id("MainContent_ucInstructorToolsResults_ucITSearch_PendingAction"), "All");
                Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_txtSearchFor']")).SendKeysWithSpace(classroomcoursetitle);
                //Driver.Instance.selectDropdownValue(By.XPath("//select[@id='MainContent_ucInstructorToolsResults_ucITSearch_PendingAction']"), "All");
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_btnSearch']"));
                //Driver.existsElement(By.XPath("//a[contains(.,'Section1')]"));
            }
            else
            {
                Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_txtSearchFor']")).SendKeysWithSpace(classroomcoursetitle);
                Driver.Instance.selectDropdownValue(By.XPath("//select[@id='MainContent_ucInstructorToolsResults_ucITSearch_PendingAction']"), "All");
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_btnSearch']"));
              
            }
           

        }

        public static bool? Click_SectionTitle_FrommanageStudentPage(string v)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[contains(.,'"+v+"')]"));
                return Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkGradebook']"));
                
            }catch(Exception e)
            {
                return false;
            }

            //return result;
        }

        public static bool Expand_SectionDetail()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[@class='fa']"));
                Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucTeachingSchedule_rgMyTeachingSchedule_ctl00_ctl06_hlMangStudents']"));
                result = Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkGradebook']"));
               
            } catch(Exception e)
            {

            }
            return result;
        }

        public static bool Search_ForSection_ManageStudent(string classroomcoursetitle)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[@href='InstructorToolsAll.aspx']"));
                Driver.Instance.GetElement(By.XPath("//input[contains(@id,'txtSearchFor')]")).SendKeysWithSpace(classroomcoursetitle);
           
                Driver.Instance.selectDropdownValue(By.XPath("//select[@name='ctl00$MainContent$ucInstructorToolsResults$ucITSearch$PendingAction']"), "All");
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucInstructorToolsResults_ucITSearch_btnSearch']"));
                Driver.clickEleJs(By.XPath("//a[@class='fa']"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Manage Content')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkContent']"));
                Driver.Instance.IsElementVisible(By.XPath("//strong[contains(.,'No content has been added.')]"));
                result = Driver.Instance.IsElementVisible(By.XPath("//div/div[2]/div/div/div/div[1]/div/div[2]/div/div/a[1]"));
              
            } catch(Exception e)
            {

            }

            return result;
            
        }

        public static void Click_TeachingScheduleTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucTabs_lbMyTeachingScheduleActive']"));
        }

        public static void Click_Expand_SectionDetail()
        {
            Driver.clickEleJs(By.XPath("//a[@class='fa']"));
        }

        public static bool? Click_ManageGradeBookButton()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Manage Gradebook')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Manage Gradebook')]"));
                result = Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkGradebook']"));
              
            }catch(Exception e)
            {

            }
            return result;
        }
    }
}