using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class BrowseTrainingCatalog
    {
          private readonly IWebDriver driverobj;

          public BrowseTrainingCatalog(IWebDriver driver)
        {
            driverobj = driver;
        }
          public bool Populate_SearchText(string searchtext)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(By.XPath("//input[@id='txtGlobalSearch']"));
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).Clear();
                driverobj.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(searchtext);
              
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

          public bool Set_SearchType(String searchtype)
          {
              bool result = false;

              try
              {

                  driverobj.WaitForElement(cmb_searchtype);
                  driverobj.FindSelectElementnew(cmb_searchtype,searchtype);
                 
                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              }

              return result;
          }
          public bool Click_Search()
          {
              bool result = false;

              try
              {

                //  driverobj.WaitForElement(By.XPath("//a[@id='btnSearch']"));
                  driverobj.ClickEleJs(By.XPath("//button[contains(@onclick,'return SiteWideSearchRedirect();')]"));

                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
              }

              return result;
          }


          public bool Click_ShowContent()
          {
              bool actualresult = false;
              try
              {
                
                  driverobj.WaitForElement(showcontent);
                  driverobj.GetElement(showcontent).ClickWithSpace();
                 actualresult= driverobj.existsElement(subcategoryfirstcontent);
                 
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                 
              }
              return actualresult;
          }

          public bool clear_languagePreferences()
          {
              bool result = false;

              try
              {
                  driverobj.WaitForElement(lnk_seeMore);
                  driverobj.GetElement(lnk_seeMore).ClickWithSpace();
                  driverobj.WaitForElement(dd_languagePreference);
                  driverobj.GetElement(dd_languagePreference).ClickWithSpace();
                  Thread.Sleep(2000);
                  //IWebElement select = driver.GetElement(by);
                  IList<IWebElement> options = driverobj.FindElements(By.XPath("//li[@class='active']/a/label/input"));
                  foreach (IWebElement option in options)
                  {
                      option.ClickWithSpace();
                  }
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

              }

              return result;
          }

          public bool select_languagePreferences(String lang)
          {
              bool result = false;
              By chk_selectLang = By.XPath("//label[input[@type='checkbox']][contains(text(),'"+lang+"')]");

              try
              {
                  driverobj.WaitForElement(By.XPath("//a[contains(.,'Change')]"));
                  driverobj.GetElement(By.XPath("//a[contains(.,'Change')]")).ClickWithSpace();
             
                  driverobj.WaitForElement(By.XPath(".//*[@id='languageModal']/div[2]/div/div[2]/div/div/span/div/button"));
                  driverobj.GetElement(By.XPath(".//*[@id='languageModal']/div[2]/div/div[2]/div/div/span/div/button")).Click();
                  Thread.Sleep(2000);
                  driverobj.WaitForElement(chk_selectLang);
                  driverobj.GetElement(chk_selectLang).ClickWithSpace();
                  driverobj.GetElement(By.XPath(".//*[@id='languageModalHeader']")).ClickWithSpace();
                  driverobj.WaitForElement(By.XPath(".//*[@id='langaugeSave']"));
                  driverobj.GetElement(By.XPath(".//*[@id='langaugeSave']")).ClickWithSpace();
                  //IWebElement select = driver.GetElement(by);
                  
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

              }

              return result;
          }
          internal bool Verify_LearnerTestResults_test_Individual_Question_Turnedoff(string browserstr)
          {
              try
              {
                  TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                  SearchResults SearchResultsobj = new SearchResults(driverobj);
                  driverobj.Navigate_to_TrainingHome();
                  TrainingHomeobj.Click_TrainingCatalogLink();
                  Populate_SearchText("test_" + browserstr + ExtractDataExcel.token_for_reg);
                  Click_Search();
                  SearchResultsobj.Content_Click();
                  driverobj.WaitForElement(openTest);
                  driverobj.GetElement(openTest).Click();
                  Thread.Sleep(2000);
                  string originalHandle = driverobj.CurrentWindowHandle;
                  Thread.Sleep(2000);
                  driverobj.SwitchWindow("Meridian Global - Core Domain");
                  Thread.Sleep(5000);
                  driverobj.SwitchTo().Frame("scorm_course_menu");
                  driverobj.WaitForElement(test_InsideFramePopupClick);
                  driverobj.GetElement(test_InsideFramePopupClick).ClickWithSpace();
                  Thread.Sleep(10000);
                  driverobj.SwitchTo().DefaultContent();
                  Thread.Sleep(2000);
                  driverobj.SwitchTo().Frame("scorm_block_info");
                  driverobj.GetElement(falseAnswerRadio).Click();
                  driverobj.WaitForElement(submitButton);
                  driverobj.GetElement(submitButton).ClickWithSpace();
                  Thread.Sleep(8000);
                  string text = driverobj.gettextofelement(questionResultSection);
                  if (text.ToLower().Contains("incorrect"))
                  { throw new Exception("Results still showing for questions for test when Individual_Question_Turned off option is checked. "); }
                  driverobj.SelectWindowClose2("Meridian Global - Core Domain", "Details");
                 // driverobj.Close();

                 // driverobj.SwitchTo().Window(originalHandle);
                  return driverobj.existsElement(ObjectRepository.sucessmessage);
                  
              }
              catch (Exception ex)
              {
                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                  return false;
              }
          }
          private By submitButton = By.Id("Submit");
          private By test_InsideFramePopupClick = By.XPath(".//*[@id='SCORM12Menu_1']/span[2]/u");
          private By falseAnswerRadio = By.Id("q1false");
          private By questionResultSection = By.CssSelector("div[class*='QuestionBlock']");
          private By dd_languagePreference = By.XPath("//span[@class='multiselect-selected-text']");
          private By lnk_seeMore = By.XPath("//a[@data-showtext='See more search criteria']");
          private By txt_searchfor = By.Id("MainContent_ucSearchLanding_txtSearchFor");
          private By cmb_searchtype = By.Id("ddlSearchType");
        private By btn_search = By.Id("btnSearch");

        private By showcontent = By.Id("MainContent_ucBrowseCategory_lbSelectAllContent");
        private By subcategoryfirstcontent = By.Id("ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails");
        private By openTest = By.CssSelector("input[name*='LaunchAttemptFirst']");
    }
}
