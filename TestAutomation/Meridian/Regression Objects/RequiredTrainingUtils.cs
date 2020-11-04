using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
// using TestAutomation.Data;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Text.RegularExpressions;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class RequiredTrainingUtils
    {
        private readonly IWebDriver driverobj;

        public RequiredTrainingUtils(IWebDriver driver)
        {
            driverobj = driver;
        }

 

        public bool clickonquicklink()
        {
            try
            {

                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkRT"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkRT")).Click();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rgRequiredTraining_ctl00_ctl04_lnkDetails"));
                return true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Required Training QuickLink", driverobj);
                return false;
            }
        }

        public bool clickontitle()
        {
            bool actualresult = false;
            try
            {

                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkRT"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkRT")).Click();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rgRequiredTraining_ctl00_ctl04_lnkDetails"));
                string elementtitle = driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rgRequiredTraining_ctl00_ctl04_lnkDetails")).Text;
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rgRequiredTraining_ctl00_ctl04_lnkDetails")).Click();
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//elementtitle
                actualresult = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool printreqtraining()
        {
            bool actualresult = false;
            try
            {

                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkRT"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkRT")).Click();
                driverobj.WaitForElement(btnprintreqtraining);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btnprintreqtraining).Click();
                Thread.Sleep(3000);
                driverobj.SwitchWindow("Required Training");
                driverobj.WaitForElement(printwindowreqtrainingtext);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);

                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
            return actualresult;

        }

        public bool savepdfreqtraining()
        {

            try
            {
                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkRT"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkRT")).Click();
                driverobj.WaitForElement(btnsaveaspdfreqtraining);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btnsaveaspdfreqtraining).Click();
                Thread.Sleep(3000);
                driverobj.selectWindow("RequiredTrainingPrint.aspx");
                Thread.Sleep(8000);

                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);


                return true;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }

        }

        private By lnktranscript = By.XPath("//div[@id='ctl00_SiteNavigationBar2_rdNavigationMenu']/ul/li[3]/a/span");
        private By TrainingHome = By.XPath("//a[contains(text(),'Training Home')]");
        private By reqtrainingcompleted = By.XPath("/html/body/form/div[6]/div/div[7]/div[2]/div[3]");
        private By reqtrainingstarted = By.XPath("/html/body/form/div[6]/div/div[7]/div[2]/div[4]");
  
        private string TranscriptPageTitle = "Transcript";

        private By btnprintreqtraining = By.Id("MainContent_UC1_MLinkButton1");
        private By printwindowreqtrainingtext = By.Id("ctl00_MainContent_UC1_rgRequiredTraining_ctl00_ctl04_lnkDetails");
        private By btnsaveaspdfreqtraining = By.Id("MainContent_UC1_SaveAsPDF");

    }
}
