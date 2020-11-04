using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using MyExcel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Threading;

//using TestAutomation.Meridian.Regression_Objects;

/// <summary>
/// On clicking the content title it must open the details page.
/// Clicking on View All courses from Content Portlet to test whether all the courses created are displayed.
/// </summary>

[TestFixture]
        public class Donotcheckin
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
        Driver.Initialize();
        Driver.Instance.Navigate().GoToUrl("http://tfs01:8080/tfs/MeridianBaseProduct/Meridian_Global/_testManagement#planId=30979&suiteId=30980&_a=tests");
            }

            [TearDown]
            public void TeardownTest()
            {

      //  Driver.Instance.Close();
                
               
            }

    [Test]
    public void TheUntitledTestCaseTest()
    {
      
            string rootfolder = string.Empty;
            string foldertodll = TestContext.CurrentContext.TestDirectory;
            if (foldertodll.Contains(@"bin\x86\Debug"))
            {
                rootfolder = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory).Replace(@"bin\x86\Debug", string.Empty);
            }
            if (foldertodll.Contains(@"bin\x86\Release"))
            {
                rootfolder = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"bin\x86\Release", string.Empty);
            }
            if (foldertodll.Contains(@"bin\Debug"))
            {
                rootfolder = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory).Replace(@"bin\Debug", string.Empty);

                rootfolder = rootfolder + "\\";
            }
            if (foldertodll.Contains(@"bin\Release"))
            {
                rootfolder = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"bin\Release", string.Empty);
            }

            ReadExcel test = new ReadExcel();
            string excelpath = rootfolder + "guidata.xlsx";

            ReadExcel test1 = new ReadExcel();
            DataTable dturls = test.loadurlfromexcel(excelpath, "Environment");

            //Driver.Instance =  Driver.Instance;

            Thread.Sleep(10000);
            Driver.clickEleJs(By.XPath("//li[@id='mi_58']/span"));
            IList<IWebElement> val = Driver.Instance.FindElements(By.XPath("//*[contains(@id, 'tfs_tnli')]"));
            foreach (var suite in val)//counts the list in tfs folders
            {
                string value = suite.GetAttribute("title");//checks the title of folder
                if (!value.EndsWith("Count of tests: 0"))//varifies the count is > 0
                {
                    int cnt = Driver.getIntegerFromString(value);
                    if (cnt > 0)
                    {
                        suite.ClickWithSpace();



                        if (Driver.existsElement(By.XPath("//div[@id='29']/div/span")))//testcase is present there or not
                        {
                            foreach (DataRow rows1 in dturls.Rows)//loads the table for excel
                            {
                                for (int j = 0; j < cnt; j++)
                                {
                                    if (rows1.ItemArray.Contains(Driver.GetElement(By.XPath("//div[@id='row_77_0']/div[2]")).Text) && Driver.existsElement(By.XPath("//div[@id='29']/div/span")))//ensures that excel id matches with column id
                                    {

                                        //  Driver.clickEleJs(By.XPath("//li[@id='mi_124']/span"));
                                        break;
                                    }

                                }
                            }
                        }
                    }
                    //   Driver.clickEleJs(By.XPath("//li[@id='tfs_tnli" + i + "']/a/div"));
                    //if (Driver.existsElement(By.XPath("//div[@id='29']/div/span")))
                    //{
                    //    if (Driver.GetElement(By.XPath("//div[@id='row_77_0']/div[2]")).Text.Contains(id))
                    //    {
                    //        Driver.clickEleJs(By.XPath("//li[@id='mi_124']/span"));
                    //    }
                    //}
                }
            }
            //  Driver.Instance.Navigate().GoToUrl("http://tfs01:8080/tfs/MeridianBaseProduct/Meridian_Global/_testManagement#planId=30979&suiteId=30980&_a=tests");

        }

        

            
            private bool IsElementPresent(By by)
            {
                try
                {
                     Driver.Instance.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                     Driver.Instance.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert =  Driver.Instance.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
    

    /// <summary>
    /// Clicking on View All courses from Content Portlet to test whether all the courses created are displayed.
    /// </summary>








