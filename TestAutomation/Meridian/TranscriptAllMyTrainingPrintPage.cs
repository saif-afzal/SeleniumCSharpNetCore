using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite
{
    internal class TranscriptAllMyTrainingPrintPage
    {
        public static string Title
        {
            get
            {
                string res = string.Empty;
                Driver.Instance.selectWindow("Untitled - Google Chrome");
                res = Driver.Instance.Url;
                Driver.Instance.SelectWindowClose2("", "Meridian Global Reporting");
                return res;
            }
        }
    }
}