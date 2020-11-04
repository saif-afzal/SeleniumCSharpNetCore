using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class GeneralCoursePage
    {
        public static DisplayFormatCommand DisplayFormatDropdown { get { return new DisplayFormatCommand(); } }

        public static AvailableinCatalogCommand AvailableinCatalog { get { return new AvailableinCatalogCommand(); } }

        public static bool? VerifyTagsdropdown()
        {
            throw new NotImplementedException();
        }

        public static void SelectTags()
        {
            throw new NotImplementedException();
        }

        public static void CreateGeneralCourse(string v1, string v2)
        {
          
            Driver.GetElement(ObjectRepository.genCourseTitle_ED).SendKeysWithSpace(v1);
            //   driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
            Driver.GetElement(ObjectRepository.generalcoursekeyword).SendKeysWithSpace(v2);
            //Driver.select(By.XPath("//div[@id='content']/div[2]/div/div[9]/div/div/select"), "Internal");
            Driver.Instance.WaitForElement(ObjectRepository.generalcourseboostindex);

            Driver.GetElement(ObjectRepository.generalcourseboostindex).SendKeysWithSpace("2");
            // driverobj.GetElement(locator.driverobjurlradio).Click();
            Driver.clickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            //    driverobj.GetElement(ObjectRepository.generalcourseurl_txtfld).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Url"]);
            Driver.GetElement(By.Id("MainContent_UC1_DOCUMENT_URL")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Url"]);
            if (Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div/div[9]/div/div/select")))
            {
                Driver.select(By.XPath("//div[@id='content']/div[2]/div/div[9]/div/div/select"), "Internal");
            }
            Driver.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();
        }

        
        public static string CreateTags(string tagname)
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
            Driver.clickEleJs(By.Id("ContentTags"));
            Driver.GetElement(By.XPath("//input[@autocapitalize='off']")).SendKeysWithSpace(tagname);
            IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@autocapitalize='off']"));
            webElement.SendKeys(Keys.Tab);
            Driver.clickEleJs(By.XPath("//div[@id='container-tags']/div/span/div/form/div/div/div[2]/button/i"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'"+tagname+"')]")).Text;
            return s;
        }

        public static void setCost(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lnkEdit']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//input[@value='Back']"));
        }

        public static void RemoveTag(string tagname)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'"+tagname+"')]"));
            Driver.clickEleJs(By.XPath("//span[@aria-label='Remove']"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Thread.Sleep(2000);
        }

        public static void ClickSaveButton()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public static String SearchTag(string tagname)
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.Id("ContentTags"));
            Thread.Sleep(2000);
            Driver.GetElement(By.XPath("//input[@autocapitalize='off']")).SendKeysWithSpace(tagname);
            Thread.Sleep(1000);
            IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@autocapitalize='off']"));
            webElement.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//div[@id='container-tags']/div/span/div/form/div/div/div[2]/button/i"));
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Thread.Sleep(2000);
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            return s;
        }

        public static void SearchTagForNewContent(string tagname)
        {
            Driver.clickEleJs(By.Id("ContentTags"));
            Thread.Sleep(2000);
            Driver.GetElement(By.XPath("//input[@autocapitalize='off']")).SendKeysWithSpace(tagname);
            Thread.Sleep(1000);
            IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@autocapitalize='off']"));
            webElement.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//div[@id='container-tags']/div/span/div/form/div/div/div[2]/button/i"));
            Thread.Sleep(1000);
            //Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            //Thread.Sleep(2000);
            //string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            //return s;
        }

        public static void completeGeneralCourse()
        {
            Driver.clickEleJs(By.XPath("//a[@class='btn btn-primary btn-lg']"));
            Driver.clickEleJs(By.XPath("//a[@id='quick-play']"));
            Driver.focusParentWindow();
            Driver.Instance.IsElementVisible(By.XPath("//a[@id='markCompleteBtn']"));
            //Driver.clickEleJs(By.XPath("//input[@value='Mark Complete']"));
            //Driver.Instance.SelectFrame(By.XPath("//span[@class='k-window-title']"));
             Driver.clickEleJs(By.XPath("//a[@id='markCompleteBtn']"));
            //Driver.Instance.IsElementVisible(By.XPath("//a[@class='btn hover:text-white btn-primary']"));
            Driver.Instance.IsElementVisible(By.XPath("//a[@class='btn hover:text-white btn-primary']"));//Changes 

        }

        public static void ClickCheckIn()
        {
            Driver.clickEleJs(By.LinkText("Check-in"));
        }

        public static void AddDescription(string v)
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
            Driver.existsElement(By.XPath("//label[contains(text(),'Description')]"));
            Driver.GetElement(By.XPath("//div[@class='fr-element fr-view']//p")).Click();
            IReadOnlyCollection<IWebElement> elems = Driver.Instance.FindElements(By.XPath("//div[@class='fr-element fr-view']//p")).Where(e => e.Displayed).ToList();
            elems.ElementAt(0).Click();
            IWebElement element = Driver.Instance.GetElement(By.XPath("//*[@id='Editor']/div[3]/div/p"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.Instance;
            //executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            //executor.ExecuteScript("arguments[0].click();", element);
            String js = "arguments[0].setAttribute('p','" + v + "')";
            executor.ExecuteScript(js, element);
            Driver.waitforframe();
            elems.ElementAt(0).SendKeys("a");

            //Driver.GetElement(By.XPath("//div[@id='Editor']/div[3]/div")).Clear();
            //Driver.GetElement(By.XPath("//div[@id='Editor']/div[3]/div")).SendKeysWithSpace(v);

            // Driver.GetElement(By.XPath("//div[@class='fr-element fr-view']//p")).Clear();
            //Driver.GetElement(By.XPath("//div[@class='fr-element fr-view']//p")).SendKeys(v);

            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            
        }

        public static void AddCategories(string v)
        {
            Driver.existsElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
            ContentDetailsPage.Accordians.ClickEdit_Categories();
            Driver.existsElement(By.XPath("//span[contains(text(),'ROOT')]/following::input[1]"));
            Driver.clickEleJs(By.XPath("//span[contains(text(),'ROOT')]/following::input[1]"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_ucCategories_btnSave']"));
            Thread.Sleep(5000);
            //Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

        public static void AddCourseProvider(string v)
        {
            Driver.existsElement(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
            ContentDetailsPage.Accordians.ClickEdit_CourseInformation();
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_PROVIDER"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_PROVIDER"));
            Driver.select(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlSave']/div/div[2]/div/select"), "Meridian");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
           
        }

        public static void AddCreditType(string v)
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC5_hlManage"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC5_hlManage"));
            Thread.Sleep(2000);
            Driver.GetElement(By.XPath("//td[3]/input")).Clear();
            Driver.GetElement(By.XPath("//td[3]/input")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_MButton1"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
            
        }
    }

    public class AvailableinCatalogCommand
    {
        public AvailableinCatalogCommand()
        {
        }

        public void ClicktoUncheck()
        {
            if (Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE"));
            }
            else if (Driver.existsElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']"));
            }
            else if (Driver.existsElement(By.XPath("//input[@id='CNT_SEARCHABLE']")))
            {
                Driver.clickEleJs(By.XPath("//input[@id='CNT_SEARCHABLE']"));
            }

        }

        public bool? isAvailableinCatalogOptionisDisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'Available in Catalog')]"));
        }

        public bool? isChecked()
        {
            if (Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNT_SEARCHABLE']")).Selected;
            }
            else if (Driver.existsElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_SEARCHABLE']")).Selected;
            }
            else if(Driver.existsElement(By.XPath("//input[@id='CNT_SEARCHABLE']")))
            {
                return Driver.GetElement(By.XPath("//input[@id='CNT_SEARCHABLE']")).Selected;
            }
            else
                return false;
        }
    }

    public class DisplayFormatCommand
    {
        public DisplayFormatCommand()
        {
        }

        public bool? Defaultvalue(string v)
        {
            
            if (Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']")))
            {
                return Driver.GetElement(By.XPath("//span[@class='filter-option pull-left']")).Text.Contains(v);
            }
            else if (Driver.existsElement(By.XPath("//div[@id='INTERNALDOC_PATH_DETAILS']//span[@class='filter-option pull-left']")))
            {
                return Driver.GetElement(By.XPath("//div[@id='INTERNALDOC_PATH_DETAILS']//span[@class='filter-option pull-left']")).Text.Contains(v);
            }
            else return false;
        }

        public bool? isDefaultvaluedisplay()
        {
            if (Driver.existsElement(By.XPath("//span[@class='filter-option pull-left']")))
            {
                return true;
            }
            else if (Driver.existsElement(By.XPath("//div[@id='INTERNALDOC_PATH_DETAILS']//span[@class='filter-option pull-left']")))
            {
                return true;
            }
            else return false;
        }
    }
}