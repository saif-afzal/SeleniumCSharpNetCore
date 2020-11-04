using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class CatalogPage
    {
        public static string Title
        {
            get { return Driver.Instance.Title; }
        }

        public static void SearchContent()
        {
            throw new NotImplementedException();
        }

        public static void ClickonSearchedCatalog(string classroomcoursetitle)
        {
            Driver.clickEleJs(By.LinkText(classroomcoursetitle));
            Thread.Sleep(2000);
        }

        public static void ClickEditContent()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucEditContent_FormView1_btnEditContent']"));
            Thread.Sleep(2000);
        }

        public static bool GetCurrentEnrolledTraining(string classroomcoursetitle)
        {
            Thread.Sleep(2000);
            return (Driver.GetElement(By.XPath("///div[@id='section-highlight']//div[@class='panel-heading text-center font-semibold']")).Text== "Enrolled" || Driver.GetElement(By.XPath("//h1[@class='mt-4 sm:mt-0 m-0 mb-2 text-2xl']")).Text==classroomcoursetitle);
        }

        public static void EnrollinClassroomCourse()
        {
            Driver.existsElement(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4']"));
            Driver.clickEleJs(By.XPath("//div[@id='section-highlight']//a[@class='btn btn-primary schedule-action mb-4']"));
            Thread.Sleep(2000);
        }

        public static void CancelEnrollment()
        {
            Driver.clickEleJs(By.LinkText("Cancel Enrollment"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.GetElement(By.Id("MainContent_UC1_tbUnenrollReason")).Clear();
            Driver.GetElement(By.Id("MainContent_UC1_tbUnenrollReason")).SendKeysWithSpace("For Test");
            Driver.clickEleJs(By.Id("MainContent_UC1_btnCancelEnrollment"));
            Thread.Sleep(2000);
        }
        public static void CancelEnrollment_WithoutReason()
        {
            Driver.clickEleJs(By.LinkText("Cancel Enrollment"));


            Thread.Sleep(2000);
        }

        public static bool GetMessages()
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Displayed;
        }

        public static void Click_Enrollbutton()
        {
            if (Driver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_CurriculumLaunchNewAttempt")))
            {
                Driver.clickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_CurriculumLaunchNewAttempt"));
            }
            if(Driver.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCurriculumButtonFlag")))
            {
                Driver.clickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCurriculumButtonFlag"));
            }
            if (Driver.existsElement(By.XPath("//input[@value='Enroll']")))
            {
                Driver.clickEleJs(By.XPath("//input[@value='Enroll']"));
            }
            if(Driver.existsElement(By.XPath("//*[@id='enroll-prompt']/a")))
                {
                Driver.clickEleJs(By.XPath("//*[@id='enroll-prompt']/a"));
            }
        }

        public static void Click_CancelEnrollButton()
        {
            if (Driver.Instance.IsElementVisible(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CancelEnrollementReason']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucPrimaryActions_FormView1_CancelEnrollementReason']"));
              //  Driver.Instance.SwitchTo().Window("Enrollment Cancellation Reason");
              //  Driver.Instance.selectWindow("Enrollment Cancellation Reason");
                Driver.Instance.SelectFrame(By.XPath("//iframe[@class='k-content-frame']"));
               
                Driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_tbUnenrollReason']")).SendKeysWithSpace("Testing");
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnCancelEnrollment']"));
                Driver.Instance.SwitchtoDefaultContent();
            }
            
        }

        public static void SearchContent_InCatalogPage(string v)
        {
            Driver.Instance.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
            Thread.Sleep(2000);
        }

        public static bool? isRecommendedforYouPortletdisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='container-collabrative-recomendation']"));
        }

        public static void SearchContent_OnMobile(string v)
        {
            Driver.existsElement(By.XPath("//input[@id='MainContent_ucSearchLanding_txtIDPSearchFor']"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_ucSearchLanding_txtIDPSearchFor']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='MainContent_ucSearchLanding_txtIDPSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//a[@id='btnIDPSearch']"));
            Thread.Sleep(2000);
        }
    }
}