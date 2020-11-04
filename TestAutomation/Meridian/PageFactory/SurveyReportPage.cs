using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Linq;

namespace Selenium2.Meridian.Suite
{
    public class SurveyReportPage
    {
     

     

        public static bool? isDropDownDisplayed()
        {
            return Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']"));
        }

        

        public static bool? VerifyStartandEndDate(string sectionStartDate, string sectionEndDate)
        {
            string Date = Driver.GetElement(By.XPath("//div[@id='results-filter']/div/div/span[3]/div/button")).Text;
            if(sectionStartDate.Substring(1,9)==Date.Substring(12,20)  && sectionEndDate.Substring(1,9)==Date.Substring(23,31))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Click_Filter()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btnFilterReport']"));
        }

        public static bool? isReportGenerated()
        {
            return Driver.existsElement(By.XPath("//p[@class='lead margin-n']"));
        }

        public static void Goback()
        {
            Driver.Instance.Navigate().Back();
        }

        public static bool? isSurveyDisplayed(string surveyTitle)
        {
            string DisplayedSurvey = Driver.GetElement(By.XPath("//span[@data-bind='text: $root.surveyTitle']")).Text;
            if (DisplayedSurvey == surveyTitle)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool? isContentTitleDisplayed(string contentTitle)
        {
            string DisplayedTitle= Driver.GetElement(By.XPath("//span[@data-bind='text: $root.courseTitle']")).Text;
            if (DisplayedTitle == contentTitle)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool? VerifySurveyReportIsDisplayed(string v)
        {
            return Driver.GetElement(By.XPath("//span[contains(text(),'"+v+"')]")).Text.Equals(v);
        }

      

        public static bool? VerifyOverallAverageRatingIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//canvas[@class='img-responsive center-block']"));
        }

        public static bool? VerifyTabularRepresentationIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[2]/div[3]/div/div/div[2]/div"));
        }

        public static bool? VerifyChoisesAndPercentageResponseIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//td[1]")) && Driver.existsElement(By.XPath("//td[2]"));

        }

        public static bool? VerifyTotalOfResponsesIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//td[3]"));
        }

        public static bool? VerifyQuestionTextIsDisplayedinExportableReport()
        {
            return Driver.existsElement(By.XPath("//tr/td[7]/span"));
        }

        public static bool? VerifyResponseValueInExportableReoprtIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//table[@id='dtAnalysisGrid']/tbody/tr/td[9]"));
        }

        public static bool? VerifyMatrixQuestionTextAreDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='report-question-stats']/div/div/a/ul/li[2]/p")) && Driver.GetElement(By.XPath("//div[@class='survey-report-pages']//div//div[1]//a[1]//ul[1]//li[2]//small[1]")).Text.Contains("Matrix");
        }

        public static bool? VerifyRatingTypeQuestionTextIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='report-question-stats']/div/div/a/ul/li[2]/p")) && Driver.GetElement(By.XPath("//div[@class='survey-report-pages']//div//div[1]//a[1]//ul[1]//li[2]//small[1]")).Text.Contains("Rating");
        }

        public static bool? VerifyMatrixOverallAverageRatingIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//canvas[@class='img-responsive center-block']"));
        }

        public static bool? VerifyMatrixTabularRepresentationIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[2]/div[3]/div/div/div[2]/div"));
        }

        public static bool? VerifyMatrixChoisesAndPercentageResponseIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//td[1]")) && Driver.existsElement(By.XPath("//td[2]"));
        }

        public static bool? VerifyMatrixTotalOfResponsesIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//td[3]"));
        }

        public static bool? VerifyMatrixRowTextIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//td[8]/span"));
        }

        public static bool? VerifyParagraphQuestionTextIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='report-question-stats']/div/div/a/ul/li[2]/p")) && Driver.GetElement(By.XPath("//div[@class='survey-report-pages']//div//div[1]//a[1]//ul[1]//li[2]//small[1]")).Text.Contains("Paragraph");
        }

        public static int Verify5ResponsesAreDisplayed()
        {
            Driver.existsElement(By.XPath("//div/ul/li/p"));
            string totleCount = Driver.Instance.FindElements(By.XPath("//div/ul/li/p")).Count.ToString();
            return Driver.getIntegerFromString(totleCount);
        }

        public static bool? VerifyMultipleTypeRadioButtonQuestionTextIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='report-question-stats']/div[1]/div/a/ul/li[2]/p")) && Driver.GetElement(By.XPath("//div[@id='report-question-stats']/div[1]/div/a/ul/li[2]/small")).Text.Contains("Radio Button");
        }

        public static bool? VerifyMultipleTypeDropdownQuestionTextIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='report-question-stats']/div[2]/div/a/ul/li[2]/p")) && Driver.GetElement(By.XPath("//div[@id='report-question-stats']/div[2]/div/a/ul/li[2]/small")).Text.Contains("Dropdown");
        }

        public static bool? VerifyMultipleTypeCheckboxQuestionTextIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='report-question-stats']/div[3]/div/a/ul/li[2]/p")) && Driver.GetElement(By.XPath("//div[@id='report-question-stats']/div[3]/div/a/ul/li[2]/small")).Text.Contains("Checkbox");
        }

        public static bool? VerifyCommenUnderCommentButton()
        {
            Driver.clickEleJs(By.XPath("//a[contains(@href, '#question-comments-0')]"));
            return Driver.existsElement(By.XPath("//div[1]/div[2]/div/p/a"));
        }

        public static bool? VerifyCountIsDisplayedOnCommentButton()
        {
            //Driver.clickEleJs(By.XPath("//div[1]/div[2]/div/div[4]/ol/li/div/p"));
            Driver.existsElement(By.XPath("//div[1]/div[2]/div/p/a"));
            Driver.existsElement(By.XPath("//div[@id='question-comments-0']/ol/li/div/p/span"));
            string buttoncommentcount = Driver.GetElement(By.XPath("//div[1]/div[2]/div/p/a")).Text;
            int commentcountunderbutton= Driver.Instance.FindElements(By.XPath("//div[@id='question-comments-0']/ol/li/div/p/span")).Count;
            return Driver.getIntegerFromString(buttoncommentcount) == commentcountunderbutton; 
        }

        public static int VerifyMoreResponsesAreDisplayed()
        {
            Driver.clickEleJs(By.LinkText("More Details"));
            Driver.existsElement(By.XPath("//table[@id='tableSurveyResults']/tbody/tr/td[2]"));
            string totleCount = Driver.Instance.FindElements(By.XPath("//table[@id='tableSurveyResults']/tbody/tr/td[2]")).Count.ToString();
            return Driver.getIntegerFromString(totleCount);




        }

        public static void CloseExportableReport()
        {
            Driver.clickEleJs(By.Id("Close Window"));
            Driver.focusParentWindow();
            //Driver.Instance.SwitchtoDefaultContent();
        }
    }

      
    
}