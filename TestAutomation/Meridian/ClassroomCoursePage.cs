using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class ClassroomCoursePage
    {
        public static AvailableinCatalogClassCommand AvailableinCatalog { get { return new AvailableinCatalogClassCommand(); } }

        public static void CreateClassroomCourse(string v)
        {
            CommonSection.CreateLink.ClassroomCourse();
            Thread.Sleep(5000);
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
            Thread.Sleep(5000);
          //  throw new NotImplementedException();
        }

        public static void Create(string v)
        {
            throw new NotImplementedException();
        }

        public static string GetSuccessMessage()
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }
                
        public static string GetUpdatedSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static bool? GetNewCreatedSectionLink(string v)
        {
            Thread.Sleep(30000);
            return Driver.existsElement(By.LinkText(v));
        }

        public static void EnterDescription(string v)
        {
            throw new NotImplementedException();
        }

        public static object EnterKeywords(string v)
        {
            throw new NotImplementedException();
        }

        public static void DeleteClassroomCourse(string v)
        {
            CommonSection.CatalogSearchText('"' + v + '"');
            SearchResultsPage.CheckSearchRecord(v);
            SearchResultsPage.ClickCourseTitle(v);
            CatalogPage.ClickEditContent();
            ClassroomCourse classroomcourse = new ClassroomCourse(Driver.Instance);
            classroomcourse.deletecontent();

        }

        public static bool enableAccessKeys()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessCodes_lnkEdit']"));
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_ENABLE_ACCESS_CODE_0']"));
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                result = Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'Enabled')]"));
                
            }catch(Exception e)
            {

            }
            return result;
            
        }

        public static string verifyTimeZone_ClassroomDetailPage()
        {
            string s = Driver.GetElement(By.XPath("//*[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[3]/p")).Text;
            return s;
        }

        public static string verifyTimeZone_CatalogPage()
        {
            // Driver.clickEleJs(By.XPath("//button[@data-toggle='collapse']"));
            string s = Driver.Instance.GetElement(By.XPath("//span[@data-bind='formatText: [startTime, endTime, timeZone]']")).Text;
            return s;
            
        }

        public static string verifyTimeZone_EventDetail()
        {
            Driver.clickEleJs(By.XPath("//a[@class='fa']"));
            string s = Driver.Instance.GetElement(By.XPath("//*[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl06_rgEvents_ctl00__0']/td/ul/li/div/div[2]")).Text;
            return s;
        }

        public static string click_DetailButton(string s)
        {
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-default collapsed']"));
            string s2 = Driver.Instance.GetElement(By.XPath("//a[contains(.,'"+s+"')]")).Text;
            return s2;
        }

        public static void CreateBundle(string v)
        {
            CommonSection.CreateLink.ClassroomCourse();
            Thread.Sleep(5000);
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }

    public class AvailableinCatalogClassCommand
    {
        public AvailableinCatalogClassCommand()
        {
        }

        public void ClicktoUncheck()
        {
            if (Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_CNT_SEARCHABLE"));
            }
            else if (Driver.existsElement(By.XPath("//input[@id='CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='CNT_SEARCHABLE']"));
            }
        }

        public bool? isChecked()
        {
            if (Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")).Selected;
            }
            else if (Driver.existsElement(By.XPath("//input[@id='CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='CNT_SEARCHABLE']")).Selected;
            }
            else return true;
        }

        public bool? isAvailableinCatalogOptionisDisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'Available in Catalog')]"));
        }
    }
}