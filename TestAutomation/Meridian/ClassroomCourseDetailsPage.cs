using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;


namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class ClassroomCourseDetailsPage
    {
        private IWebDriver objDriver;
        public ClassroomCourseDetailsPage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public static void ClickSectionsTab()
        {
            Driver.clickEleJs(By.Id("MainContent_hlNewSection"));
           // throw new NotImplementedException();
        }

        public static void addToCart()
        {
            Driver.clickEleJs(By.XPath("//input[@value='Add to Cart']"));
            Thread.Sleep(3000);
            Driver.clickEleJs(By.Id("lnkShoppingCart"));
            Driver.clickEleJs(By.XPath("//input[@value='Checkout']"));
            Driver.clickEleJs(By.XPath("//input[@value='Use this payment method']"));
            Driver.clickEleJs(By.XPath("//input[@type='checkbox']"));
            Driver.clickEleJs(By.XPath("//input[@value='Place Order']"));

        }

        public static bool? verifyEnrollment()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//p[contains(.,'Enrolled')]"));
                result = Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Cancel Enrollment')]"));
               

            }catch(Exception e)
            {

            }

            return result;
        }

        public static void CLickManageCredit()
        {
            Driver.Instance.WaitForElement(By.Id("MainContent_MainContent_UC5_hlManage"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC5_hlManage"));
            Thread.Sleep(2000);
        }
    }
}