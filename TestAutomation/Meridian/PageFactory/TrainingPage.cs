using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class TrainingPage:ObjectInit
    {
        private IWebDriver objDriver;
        public TrainingPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  ManageContentPortletCommand ManageContentPortlet
        {
            get { return new ManageContentPortletCommand(objDriver); }
        }

        public  TeachingScheduleCommand TeachingSchedule { get { return new TeachingScheduleCommand(objDriver); } }

        public  TrainingAssignmentsCommand TrainingAssignments { get { return new TrainingAssignmentsCommand(objDriver); } }

        public  InstructorToolsCommand InstructorTools { get { return new InstructorToolsCommand(objDriver); } }

        public  QuickLinksCommand QuickLinks { get { return new QuickLinksCommand(objDriver); } }

        public  void ClickSearchRecord(string v)
        {
            objDriver.GetElement(By.Id("MainContent_ucAdminSearch_txtSearchFor")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("btnSearch"));
            objDriver.ClickEleJs(By.LinkText(v));

          //  throw new NotImplementedException();
        }
        public  void SearchRecord(string v)
        {
            objDriver.WaitForElement(By.Id("MainContent_ucAdminSearch_txtSearchFor"));
            objDriver.GetElement(By.Id("MainContent_ucAdminSearch_txtSearchFor")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("btnSearch"));

          //  throw new NotImplementedException();
        }

        public  ManageContentCommand ManageContentSearchText(string v)
        {
            return new ManageContentCommand(v);
        }

        public  bool removeTag_ManageContentSearchPage(string tagname)
        {
            bool result = false;
            try
            {
                if (objDriver.IsElementVisible(By.XPath("//a[contains(.,'"+tagname+"')]")))
                {
                    objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + tagname + "')]"));
                    objDriver.ClickEleJs(By.XPath("//span[@aria-label='Remove']"));
                    objDriver.ClickEleJs(By.XPath("//button[@type='submit']"));
                    Thread.Sleep(3000);
                    objDriver.IsElementVisible(By.XPath("//a[contains(text(),'Add Tags')]"));
                    result = true;
                }
                else if(objDriver.IsElementVisible(By.XPath("//a[contains(text(),'Add Tags')]")))
                {
                    result = true;
                }
              
            }catch(Exception e)
            {

            }
            return result;
            
        }

        public  bool addTag_ManageContentSearchPage(string tagname)
        {
            bool result = false;
            try
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Add Tags')]"));
                objDriver.GetElement(By.XPath("//input[@autocorrect='off']")).SendKeysWithSpace(tagname);
                IWebElement webElement = objDriver.FindElement(By.XPath("//input[@autocapitalize='off']"));
                webElement.SendKeys(Keys.Tab);
                Thread.Sleep(1000);
                objDriver.ClickEleJs(By.XPath("//button[@type='submit']"));
                Thread.Sleep(3000);
                objDriver.IsElementVisible(By.XPath("//a[contains(.,'" + tagname + "')]"));
                result = true;
            }catch(Exception e)
            {

            }

            return result;
            
        }

        public  bool? isInstructorToolDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div[2]/h2"));
        }

        public  bool? isTeachingScheduleDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@id='content']/div[2]/div[2]/h2"));

        }
    }

    public class QuickLinksCommand
    {
        private IWebDriver objDriver;
        public QuickLinksCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ClickInstructorTools()
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'Instructor Tools')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Instructor Tools')]"));
        }
    }

    public class InstructorToolsCommand
    {
        private IWebDriver objDriver;
        public InstructorToolsCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ViewAllSections()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_ucInstructorToolsSummary_lnkAllMySections']"));
        }
    }

    public class TrainingAssignmentsCommand
    {
        private IWebDriver objDriver;
        public TrainingAssignmentsCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void Click_CreateTrainingAssignment()
        {
            objDriver.ClickEleJs(By.LinkText("Create Training Assignment"));
        }

        public void Click_ManageTrainingAssignments()
        {
            objDriver.ClickEleJs(By.LinkText("Manage Training Assignments"));
        }
    }

    public class TeachingScheduleCommand
    {
        private IWebDriver objDriver;
        public TeachingScheduleCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void ClickViewTeachingSchedule()
        {
            objDriver.existsElement(By.Id("MainContent_ucInstructorToolsSummary_Summary_lbAllMyTeaching"));
            objDriver.ClickEleJs(By.Id("MainContent_ucInstructorToolsSummary_Summary_lbAllMyTeaching"));

        }

        public bool? VerifyAllDayDisplayed()
        {
            return objDriver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_ucInstructorToolsSummary_Summary_rgMyTeachingSchedule_ctl00__3']/td"));
        }

        public bool? VerifyCourseDateAndRecurrenceStatus()
        {
            return objDriver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_ucInstructorToolsSummary_Summary_rgMyTeachingSchedule_ctl00__3']/td[2]/ul/li[4]"));
        }

        public bool? VerifyAllDayDisplayed(string v)
        {
            return objDriver.existsElement(By.XPath("//li[contains(.,"+v+")]/preceding::td[1]"));

        }
    }

    public class ManageContentCommand
    {
        private IWebDriver objDriver;
        public ManageContentCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        private string v;

        public ManageContentCommand(string v)
        {
            this.v = v;
        }

        public void Click()
        {
            objDriver.existsElement(By.LinkText(v));
            objDriver.ClickEleJs(By.LinkText(v));
            Thread.Sleep(2000);
        }
    }

    public class ManageContentPortletCommand
    {
        private IWebDriver objDriver;
        public ManageContentPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void SearchForContent(string v)
        {
            objDriver.GetElement(By.XPath("//input[@id='MainContent_ucAdminSearch_txtSearchFor']")).SendKeysWithSpace(v);
            Thread.Sleep(3000);
            objDriver.ClickEleJs(By.XPath(".//*[@id='btnSearch']/span"));
            Thread.Sleep(5000);
        }
    }
}