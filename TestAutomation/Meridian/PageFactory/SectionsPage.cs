using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class SectionsPage
    {
        private IWebDriver objDriver;
        public SectionsPage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public static ListofSectionsCommand ListofSections { get { return new ListofSectionsCommand(); } }

        public static CopySectionModalCommand CopySectionModal { get { return new CopySectionModalCommand(); } }

        public static void ClickManageEnrollmentButton()
        {
            //Driver.ClickAndWaitForPageToLoad(By.LinkText("Manage Enrollment"));
            Driver.existsElement(By.XPath("//a[contains(text(),'Manage Enrollment')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Manage Enrollment')]"));//a[contains(text(),'Manage Enrollment')]
                                                                            //Driver.clickEleJs(By.LinkText("Manage Enrollment"));
                                                                            // Driver.wa
        }

        public static void ClickScheduleTab()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkSchedule"));
           // throw new NotImplementedException();
        }

        public static void UpdateSectionDetails(string v1, string v2, string v3)
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectLoc"));

           // throw new NotImplementedException();
        }

        public static void ClickLocation()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectLoc"));
           // throw new NotImplementedException();
        }

        public static void ClickInstructor()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectInst"));
         
         //   throw new NotImplementedException();
        }

        public static void DeleteEventNotes()
        {
            throw new NotImplementedException();
        }

        public static void ClickSaveButton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSave"));
        }

        public static void UpdateSectionDetails()
        {
            throw new NotImplementedException();
        }

        public static void AddEventNotes(string sampletext)
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_lnkComments"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Thread.Sleep(5000);
            Driver.GetElement(By.Id("MainContent_UC1_FormView1_EVT_PRE_ENRL_COMMENT")).SendKeysWithSpace(sampletext);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }

        public static void AddNewSectionButton()
        {
            Driver.clickEleJs(By.XPath("//div[@id='MainContent_pnlMVCSection']/div/a"));
           // throw new NotImplementedException();
        }



        public static void ClickSectionTitle(string v)
        {
            Driver.clickEleJs(By.LinkText(v));
        }

        public static void ClickCompletedSecton()
        {
            Thread.Sleep(2000);
            Driver.GetElement(By.XPath("//div[@id='panel_END_DATE']/div/ul/li/label")).ClickWithSpace();
        }

        public static bool? SectionDetailsPageOpened()
        {
            return Driver.existsElement(By.Id("MainContent_MainContent_SectionHeaderTabs_lnkSectionDetails"));
        }

        public static void SelectViewAsLearner()
        {
            Driver.clickEleJs(By.Id("MainContent_header_FormView1_btnStatus"));
        }

        public static void SelectCopySectionformActionDropdown()
        {
            if (Driver.Instance.Title.Equals("Gradebook"))
            {
                Driver.clickEleJs(By.LinkText("Sections"));
            }
            Driver.existsElement(By.XPath("//div[2]/div/div/button"));
            Driver.clickEleJs(By.XPath("//div[2]/div/div/button"));
            Thread.Sleep(2000);
            Driver.selectdropdown(By.XPath("//*[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li/div[1]/div[2]/div/div/ul"), "Copy Section");
        }

        public static void ClickonSectionTitle(string v)
        {
            if (v == "2nd Section")
            {
                Driver.clickEleJs(By.XPath("//div[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li[2]/div/div/div/div/h3/a"));
            }
            if(v== "3rd Section")
            {
                Driver.clickEleJs(By.XPath("//div[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li[3]/div/div/div/div/h3/a"));
            }
        }

        public static string GetFeedbackMessage()
        {
            Thread.Sleep(5000);
            Driver.existsElement(By.XPath("//*[@id='content']/div[2]/div"));
            return Driver.GetElement(By.XPath("//*[@id='content']/div[2]/div")).Text;
        }

        public static void CourseTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_lcClassroomCourseware']"));
        }

        public static void ClickSearchSection()
        {
            Driver.GetElement(By.XPath("//div[@id='MainContent_pnlMVCSection']/div[2]/div/div/span/button/span"));
        }

        public static string SectionStartDate()
        {
           return  Driver.GetElement(By.XPath("//div[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li/div/div/div/div/ul/li")).Text.Substring(1, 9);

        }

        public static string CopiedSectionStartDate()
        {
            return Driver.GetElement(By.XPath("//*[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li[2]/div[1]/div[1]/div/div[1]/ul/li[1]")).Text.Substring(1,9);
        }

        public static void Click_CourseTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_lcClassroomCourseware']"));
        }
    }

    public class CopySectionModalCommand
    {
        public CopySectionModalCommand()
        {
        }

        public bool? VerifyCopySectionModalComponets()
        {
           
                Driver.existsElement(By.XPath("//div[@id='copysection']/div/h3"));
                Driver.Instance.IsElementVisible(By.XPath("//label[@for='sectiontitle']"));
            Driver.Instance.IsElementVisible(By.XPath("//label[@for='sect-copy-enrollment']"));
                Driver.Instance.IsElementVisible(By.XPath("//p[contains(text(),'Summary and location information are automatically')]"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='SecDateDiv']/label"));
                return Driver.Instance.IsElementVisible(By.XPath("//label[@for='sect-copy-opt']/following::span[contains(text(),'No')]"));
              
        }

        public void CopywithGradebooktoggle(string v,string sectiontitle="")
        {
            if (v == "Yes")
            {
                if(sectiontitle!=null)
                {
                    Driver.GetElement(By.XPath("//input[@id='sectiontitle']")).Clear();
                    Driver.GetElement(By.XPath("//input[@id='sectiontitle']")).SendKeys(sectiontitle);
                }
                //Driver.clickEleJs(By.XPath("//div[@id='copysection']/div[3]/div/div/span[3]"));
                Driver.clickEleJs(By.XPath("//label[@for='sect-copy-opt']/following::span[contains(text(),'No')]"));
                Driver.GetElement(By.Id("sectiontitle")).Clear();
                Driver.GetElement(By.Id("sectiontitle")).SendKeysWithSpace("Section1-Copy");
                Driver.clickEleJs(By.Id("btnCopy"));

            }
            else if (v == "No")
            {
                Driver.GetElement(By.Id("sectiontitle")).Clear();
                Driver.GetElement(By.Id("sectiontitle")).SendKeysWithSpace("Section1-Copy-WithNo");
                Driver.clickEleJs(By.Id("btnCopy"));
            }
        }

        public bool? VerifyModalEnrollmentDate(string SectionStartDate)
        {
            //Driver.waitforframe();
            string EnrollmentDate = Driver.GetElement(By.XPath("//small[@class='text-sm']")).Text.Substring(2, 9);
            if (EnrollmentDate == SectionStartDate)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public void EditSectionTitle(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='sectiontitle']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='sectiontitle']")).SendKeysWithSpace(v);
        }

        public bool? EnrollmentStartsToggle(string v)

        {
            string EnrollmentStartStatus = Driver.GetElement(By.XPath("//div[@id='SecEnrollDateDiv']/div/div/div/div/span[3]")).Text;
            if (EnrollmentStartStatus == v)
            {
                return true;
            }
            else
            {
                Driver.clickEleJs(By.XPath("//span[@class='bootstrap-switch-handle-off bootstrap-switch-default']"));
                return true;
            }

        }

        public void ClickCopy()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btnCopy']"));
        }

        public void ChangeEnrollmentStartsDate(int v)
        {
            string format = "M/dd/yyyy";
            string startdate = DateTime.Now.AddDays(-v).ToString(format);
            startdate = startdate.Replace("-", "/");
            Driver.Instance.GetElement(By.XPath("//input[@id='sectionEnrollStartDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='sectionEnrollStartDate']")).SendKeysWithSpace(startdate);
        }

        public void ChangeStartDate()
        {
            string format = "M/dd/yyyy";
            string startdate = DateTime.Now.AddDays(2).ToString(format);
            startdate = startdate.Replace("-", "/");
            Driver.Instance.GetElement(By.XPath("//input[@id='sectionStartDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='sectionStartDate']")).SendKeysWithSpace(startdate);
        }
    }

    public class ListofSectionsCommand
    {
        public ListofSectionsCommand()
        {
        }

        public void ClickSectionTitle()
        {
            Driver.clickEleJs(By.XPath("//li/div/div/div/div/h3/a"));
        }
    }
}