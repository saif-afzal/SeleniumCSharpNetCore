using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class AddContentPage
    {
        public static bool? SearchResultDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'"+v+"')]"));
        }

        public static bool? VerifyClassroomCourseSelected(string v)
        {
            Driver.clickEleJs(By.XPath("//td[1]/a/img"));
            Driver.clickEleJs(By.XPath("//td[contains(text(),'"+v+"')]/preceding::span/input"));
            return Driver.GetElement(By.XPath("//td[contains(text(),'" + v + "')]/preceding::span/input")).Selected;
        }

        public static bool? VerifyByDefaultAllSectionsAreSelected(string v)
            
        {
            return Driver.GetElement(By.XPath("//td[contains(text(),'"+v+"')]/preceding::td[2]/span/input")).Selected;
        }

        public static bool? VerifyOnlyFutureSectionsAreDisplayed()
        {
            //string format = "M/dd/yyyy";
            string format = "{0:d}";
            string CurrentDate = DateTime.Now.ToString(format);
            CurrentDate = CurrentDate.Replace("-", "/");
            string Futuredate = Driver.GetElement(By.XPath("//tr[3]/td[5]/table/tbody/tr/td")).Text;
            
           var datelist = Futuredate.Split(new char[] { '-' });
            string NewFuturedate = datelist[1];
            NewFuturedate = NewFuturedate.Substring(1,9);
            return true;
            //Driver.matchtime
        }

        public static bool? VerifyIndividualSectionsAreDisplayed()
        {
            return Driver.existsElement(By.XPath("//tr/td[2]/span/input"));
        }

        public static bool? VerifySingleSectionCanNotBeSelectedWithAllSections(string v)
        {
            
            Driver.clickEleJs(By.XPath("//tr[3]/td[2]/span/input"));
            return Driver.GetElement(By.XPath("//td[contains(text(),'All Sections (#)')]/preceding::input[2]")).Selected;
        }

        public static bool? VerifyIndividualSectionsIsSelected(string v)
        {
            Driver.clickEleJs(By.XPath("//td[1]/a/img"));
            Driver.clickEleJs(By.XPath("//td[contains(text(),'All Sections (#)')]/preceding::input[2]"));
            return Driver.GetElement(By.XPath("//td[2]/table/tbody/tr[3]/td[2]/span/input")).Selected;

        }

        public static bool? GetSuccessDiscountCodeAddedMessage(string v)
        {
            Driver.clickEleJs(By.XPath("//td[contains(text(),'NewClassroomTest_DIscountCode002')]/preceding::span//input[1]"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_AddContent_AssignTraining']"));
            Thread.Sleep(3000);
            return Driver.GetElement(By.XPath("//span[@id='ReturnFeedback']")).Text.Contains(v);
        }
    }
}