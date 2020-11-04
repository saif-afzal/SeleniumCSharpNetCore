using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite
{
    public class AllQuestionsAllSurveyPDFPage
    {
        public static string Title
        {
            get
            {
                string res = string.Empty;
                Driver.Instance.selectWindow("All_Questions_All_Surveys.pdf");
                res = Driver.Instance.Url;
                Driver.Instance.SelectWindowClose2("", "Meridian Global Reporting");
                return res;
            }
        }

        public static string TitleofReport
        {
            get
            {
                string res = string.Empty;
                Driver.Instance.selectWindow("Fit_job.pdf");
                res = Driver.Instance.Url;
                Driver.Instance.SelectWindowClose2("", "Meridian Global Reporting");
                return res;
            }
        }
                
               
    }
}