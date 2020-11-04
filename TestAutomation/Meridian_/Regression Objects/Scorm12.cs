using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using relativepath;
using System.Reflection;

namespace Selenium2.Meridian
{
    class Scorm12
    {

        private readonly IWebDriver driverobj;
        public bool tocreatescrom = false;
        public bool toassignscrom = false;
        public bool toenrollscrom = false;
        public bool tolaunchscrom = false;
        public Scorm12(IWebDriver driver)
        {
            driverobj = driver;
        }

         //"should Create a SCORM 1.2 course and check it in"    
         //"should Assign the SCORM 1.2 as required training to the new end user" 

      string path = string.Empty;
      RelativeDirectory rd = new RelativeDirectory();
      //public void linkscormCourseclick(IWebDriver iSelenium)
      //{

      //    try
      //    {
      //        driverobj.WaitForElement(ObjectRepository.scrom12_link);
      //        driverobj.GetElement(ObjectRepository.scrom12_link).ClickWithSpace();
      //        driverobj.WaitForElement(ObjectRepository.go_btn);
      //        tocreatescrom = true;
      //        toassignscrom = true;
      //    }
      //    catch (Exception ex)
      //    {
      //        Console.WriteLine(ex.Message);
      //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
      //        tocreatescrom = false;
      //        toassignscrom = false;
      //    }
      //}
      //public void buttongoclick(IWebDriver iSelenium)
      //{
      //    if (tocreatescrom == false)
      //    {
      //        return;
      //    }
      //    try
      //    {
      //        driverobj.GetElement(ObjectRepository.go_btn).ClickWithSpace();
      //        driverobj.WaitForElement(ObjectRepository.scrom12_fileupload);
      //        tocreatescrom = true;
      //    }
      //    catch (Exception ex)
      //    {
      //        Console.WriteLine(ex.Message);
      //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
      //        tocreatescrom = false;
      //    }
      //}

      public void linkmyresponsibilitiesclick()
      {
          //try
          //{

          //    driverobj.WaitForElement(ObjectRepository.myResponsibilities);
          //    driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
          //    //  driverobj.GetElement(ObjectRepository.myResponsibilities);
          //    if (driverobj.existsElement(ObjectRepository.searchHome))
          //    {
          //        return;
          //    }
          //    else if (!driverobj.existsElement(ObjectRepository.searchHome))
          //    {
          //        driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
          //        driverobj.WaitForElement(ObjectRepository.searchHome);
          //    }
          //    else
          //    {
          //        driverobj.HoverLinkClick(ObjectRepository.myResponsibilities, By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
          //        driverobj.WaitForElement(ObjectRepository.searchHome);
          //    }

          //}
          //catch (Exception ex)
          //{
          //    Console.WriteLine(ex.Message);
          //    ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


          //    driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
          //}


      }
      public void linkscromcourseclick()
      {
          if (tocreatescrom == false)
          {
              return;
          }

          try
          {
              driverobj.WaitForElement(ObjectRepository.classroomCoursesLink);
              driverobj.GetElement(ObjectRepository.classroomCoursesLink).ClickWithSpace();
              driverobj.WaitForElement(ObjectRepository.goCreateClassroombtn);
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              tocreatescrom = false;
          }

      }
      public void buttongoclick()
      {
          if (tocreatescrom == false)
          {
              return;
          }
          try
          {
              driverobj.select(ObjectRepository.selectcoursetype, "SCORM");
              Thread.Sleep(2000);
              driverobj.GetElement(ObjectRepository.goCreateClassroombtn).ClickWithSpace();
              //driverobj.WaitForElement(ObjectRepository.classroomTitle);
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              tocreatescrom = false;
          }

      }
      public void linkrequiredtrainingconsoleclick(IWebDriver iSelenium)
      {

          try
          {
              driverobj.WaitForElement(ObjectRepository.requiredtraining_link);
              driverobj.GetElement(ObjectRepository.requiredtraining_link).ClickAnchor();
              //driverobj.WaitForElement(ObjectRepository.go_btn);
              tocreatescrom = true;
              toassignscrom = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              tocreatescrom = false;
              toassignscrom = false;
          }
      }
      public void navigatedriverobjfile(IWebDriver iSelenium)
      {
          if (tocreatescrom == false)
          {
              return;
          }
          try
          {
              path = rd.Up(2) + "\\Data\\MARITIME NAVIGATION.zip";
             // path = path.Replace("\\", "/");
              Thread.Sleep(7000);
             uploadfile(path);
              Thread.Sleep(11000);
              tocreatescrom = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              tocreatescrom = false;
          }
      }
      public void buttoncreateclick(IWebDriver iSelenium,bool methodSpecificToScorn)
      {
          //if (methodSpecificToScorn)
          //{
          //    if (tocreatescrom == false)
          //    { return; }
          //}
          try
          {
                Thread.Sleep(8000);
             // driverobj.WaitForpagetoload(ObjectRepository.create_btn_new);
              driverobj.ScrollToCoordinated("1000", "1000");
             //   driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Next']"));
                driverobj.WaitForElement(ObjectRepository.nxt_btn_new);
              driverobj.ClickEleJs(ObjectRepository.nxt_btn_new);
              //driverobj.WaitForpagetoload(ObjectRepository.Return_Feedback_id);
              tocreatescrom = true;

          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              tocreatescrom = false;
          }
      }
      public void populatesummaryform(IWebDriver iSelenium, string browserstr)
      {
          if (tocreatescrom == false)
          {
              return;
          }
          try
          {
              driverobj.WaitForElement(ObjectRepository.scromtitle);
              driverobj.GetElement(ObjectRepository.scromtitle).Clear();
              driverobj.GetElement(ObjectRepository.scromtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
              tocreatescrom = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              tocreatescrom = false;
          }
      }
      public bool buttonsaveclick(IWebDriver iSelenium)
      {
            bool result = false;

            try
          {
              
              driverobj.WaitForElement(ObjectRepository.create_btn_new);
              driverobj.ClickEleJs(ObjectRepository.create_btn_new);
              driverobj.WaitForElement(ObjectRepository.CheckinNew);
              driverobj.ClickEleJs(ObjectRepository.CheckinNew);

                // driverobj.WaitForElement(ObjectRepository.Return_Feedback_id);
                // Thread.Sleep(5000);
                result = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              return false;

          }
            return result;
      }
      public void populatesearchscorm(IWebDriver iSelenium, string browserstr)
      {
          
          try
          {
              driverobj.WaitForElement(ObjectRepository.scromsearch_actingrole);
           //   driverobj.FindSelectElementnew(ObjectRepository.scromsearch_actingrole, "Other");
              driverobj.GetElement(ObjectRepository.scromsearch_ed).ClickWithSpace() ;
              Thread.Sleep(2000);
              driverobj.GetElement(ObjectRepository.scromsearch_ed).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr);
              driverobj.FindSelectElementnew(ObjectRepository.scromsearch_type, "All words");
              toassignscrom = true;


          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              toassignscrom = false;
          }
      }
      public void buttonsearchclick()
      {
          if (toassignscrom == false)
          {
              return;
          }
          try
          {
              driverobj.GetElement(ObjectRepository.scromsearch_btn).ClickWithSpace();
              driverobj.WaitForElement(ObjectRepository.scromrequiredtrainingbutton);
              toassignscrom = true;

          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              toassignscrom = false;
          }
      }
      public void buttonrequiredtraining()
      {
          if (toassignscrom == false)
          {
              return;
          }
          try
          {
              driverobj.GetElement(ObjectRepository.scromrequiredtrainingbutton).ClickWithSpace();
          //    driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_USR_LAST_NAME"));
              toassignscrom = true;

          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              toassignscrom = false;
          }
      }
     
      public void buttongotrainingclick()
      {
          if (toassignscrom == false)
          {
              return;
          }
          try
          {
              driverobj.WaitForElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining']"));

              driverobj.select(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining']"), "Assign Training Without Deadline");
          
              driverobj.GetElement(ObjectRepository.goTrainingBtn).ClickWithSpace();
             // driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_USR_LAST_NAME"));
              toassignscrom = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              toassignscrom = false;
          }
      }
      public void populateassignuserform()
      {
          if (toassignscrom == false)
          {
              return;
          }
          try
          {
             // driverobj.GetElement(ObjectRepository.scromAssignTrainingfirstname).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr);
              //driverobj.FindSelectElementnew(ObjectRepository.assignTrainingSearchType, "All words");
              driverobj.WaitForElement(ObjectRepository.assignTrainingSearchBtn);
              driverobj.GetElement(ObjectRepository.assignTrainingSearchBtn).ClickWithSpace();
              driverobj.WaitForElement(ObjectRepository.tableResultAssignTraining);
              toassignscrom = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              toassignscrom = false;
          }

      }
      public bool buttonassigntrainingclick()
      {
          if (toassignscrom == false)
          {
              return false ;
          }
          try
          {
              driverobj.GetElement(ObjectRepository.tableResultAssignTraining).ClickWithSpace();
              driverobj.WaitForElement(ObjectRepository.assignTrainingLink);
              driverobj.GetElement(ObjectRepository.assignTrainingLink).ClickWithSpace();
              driverobj.WaitForElement(ObjectRepository.Return_Feedback_id);
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              return false;

          }
          return true;

      }
      public void buttonenrolclick(IWebDriver iSelenium)
      {
          try
          {
              driverobj.WaitForElement(ObjectRepository.scromenrollbtn);
              driverobj.GetElement(ObjectRepository.scromenrollbtn).ClickWithSpace();
              Thread.Sleep(5000);
              toenrollscrom = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              toenrollscrom = false;
          }
      }
      public string buttonframeenrolclick(IWebDriver iSelenium)
      {
          string actualstring = string.Empty;
          if (toenrollscrom == false)
          {
              return actualstring;
          }
          try
          {
              Thread.Sleep(5000);

             // driverobj.SwitchTo().Frame(1);
              //driverobj.SelectFrame();
              driverobj.waitforframe(ObjectRepository.switchToFrame_New);
              driverobj.WaitForElement(ObjectRepository.scromenrolcourse);
              Thread.Sleep(3000);
              driverobj.GetElement(ObjectRepository.scromenrolcourse).ClickWithSpace();
              Thread.Sleep(3000);
              driverobj.SwitchTo().DefaultContent();
              Thread.Sleep(3000);
              driverobj.WaitForElement(ObjectRepository.scromlaunchfirstattempt);
              actualstring = driverobj.GetElement(ObjectRepository.scromlaunchfirstattempt).GetAttribute("value");
              return actualstring;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              return actualstring ;

          }
         
      }
      public string  buttonopenscormclick(IWebDriver iSelenium)
      {
          try
          {
              driverobj.GetElement(ObjectRepository.scromlaunchfirstattempt).ClickWithSpace();

              Thread.Sleep(10000);
              driverobj.SelectWindowClose();
              Thread.Sleep(10000);
              tolaunchscrom = true;
              driverobj.WaitForElement(ObjectRepository.scromlunchcourseexisting);
              int cnt = 0;
              while(!driverobj.existsElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchCourseAttemptExisting")))
              {
                  if (cnt < 4)
                  {
                      return "Page is not getting refresh";
                  }
                  driverobj.GetElement(ObjectRepository.scromlaunchfirstattempt).ClickWithSpace();

                  Thread.Sleep(10000);
                  driverobj.SelectWindowClose();
                  Thread.Sleep(10000);
              }
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              tolaunchscrom = false;
          }
          return driverobj.GetElement(ObjectRepository.scromlunchcourseexisting).GetAttribute("value");
      }
      public bool refreshpage(IWebDriver iSelenium)
      {
          int cnt = 0;
          if (tolaunchscrom == false)
          {
              return false;
          }
          try
          {
              result = driverobj.GetElement(ObjectRepository.scromlunchcourseexisting).GetAttribute("value");
              while (result != "Resume")
              {
                  if (cnt < 5)
                  {
                      driverobj.GetElement(By.XPath("//body")).SendKeysWithSpace(Keys.F5);
                      buttonopenscormclick(driverobj);
                      result = driverobj.GetElement(ObjectRepository.scromlunchcourseexisting).GetAttribute("value");
                      cnt = cnt + 1;
                      //refreshpage(driverobj);
                  }
                  else
                  {
                      break;
                  }
              }
             
             // buttonopenscormclick(driverobj);
              result = driverobj.GetElement(ObjectRepository.scromlunchcourseexisting).GetAttribute("value");
              // result = driverobj.Title;
           
          }
          catch (Exception ex)
          {
             
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              return false;

          }
          return true;
      }
      public bool buttonmarkcompleteclick(IWebDriver iSelenium)
      {
          try
          {
              driverobj.GetElement(ObjectRepository.scrommarkcompleteblock).ClickWithSpace();
              Thread.Sleep(5000);
              //   result = generalCourse.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst")).GetAttribute("value");



              //result = document.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              return false;

          }
          return true;

      }
      public bool buttonmarkcompleteframeclick(IWebDriver iSelenium)
      {
          try
          {
              //driverobj.SwitchTo().Frame(1);
              //driverobj.SelectFrame();
              driverobj.waitforframe(ObjectRepository.switchToFrame_New);
              driverobj.WaitForElement(ObjectRepository.scrommarkcompletebutton);
              driverobj.GetElement(ObjectRepository.scrommarkcompletebutton).ClickWithSpace();
              Thread.Sleep(3000);
              driverobj.SwitchTo().DefaultContent();
              //result = document.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
              driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
              return false;

          }
          if (driverobj.GetElement(ObjectRepository.scromcertificateblock).GetAttribute("value") == "View Certificate")
          {
              return true;
          }
          else
          {
              return false;
          }

      }
      internal void CreateSCORMCourse(string browserstr)
      {
          Document documentpage = new Document(driverobj);
            Trainings trainingsobj = new Trainings(driverobj);
          linkmyresponsibilitiesclick();
            trainingsobj.CreateContentButton_Click_New(Locator_Training.Scorm_CourseClick);
        //  documentpage.buttoncoursecreationgoclick("SCORM");
          driverobj.navigateAICCfile("\\Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
          buttoncreateclick(driverobj, true);
          driverobj.WaitForElement(By.XPath("//h1[contains(.,'Edit Summary')]"));
          string text = driverobj.gettextofelement(By.XPath("//h1[contains(.,'Edit Summary')]"));
          driverobj.WaitForElement(ObjectRepository.sucessmessage);
          populatesummaryform(driverobj, browserstr);
          buttonsaveclick(driverobj);
      }
 
        public string result = "null";
        

      public void  uploadfile(string path)
      {
          try
          {
              Thread.Sleep(6000);
              driverobj.GetElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_PATH']")).SendKeysWithSpace(path);
              Thread.Sleep(10000);
              //driverobj.GetElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_UploadContent_TDElementUploadFile']/table/tbody/tr/td/input")).SendKeysWithSpace(path);
          }
          catch (Exception ex)
          {
              System.Windows.Forms.SendKeys.SendWait("{ESC}");
              Thread.Sleep(6000);
              // path = string.Empty;
              uploadfile(path);
          }
      }
      internal void Goto_CreateSCORMPage()
      {
          Document documentpage = new Document(driverobj);
          linkmyresponsibilitiesclick();
          documentpage.tabcontentmanagementclick();
          documentpage.buttoncoursecreationgoclick("SCORM");
      }
      internal void ValidateContentSearch_SCORMCreate_Complete_SharedSteps7276()
      {
          try
          {
              List<string> errors = new List<string>();
              if (!driverobj.gettextofelement(By.XPath(".//*[@id='MainContent_UC1_pnlSCORM']/div[2]/div")).Contains("File Name"))
              { errors.Add("File Name -field is not coming on Create Scrom Course Page"); }
              if (!driverobj.gettextofelement(By.XPath(".//*[@id='MainContent_UC1_pnlSCORM']/div[3]/div[1]")).Contains("Content Item Owner Domain"))
              { errors.Add("Content Item Owner Domain- field is not coming on Create Scrom Course Page."); }
              if (!driverobj.gettextofelement(By.XPath(".//*[@id='MainContent_UC1_pnlSCORM']/div[3]/div[2]")).Contains("Locale"))
              { errors.Add("Locale-field is not coming on Create Scrom Course Page."); }
              if (!driverobj.IsElementVisible(By.Id("MainContent_UC1_btnCancel")))
              { errors.Add("Back button is not coming on SCORM Course create page"); }
              if (!driverobj.IsElementVisible(By.Id("MainContent_UC1_Next")))
              { errors.Add("Create button is not coming on SCORM Course create page "); }
              if (errors.Count > 0)
              {
                  string allErrors = string.Join("", errors);
                  throw new Exception(allErrors);
              }
          }
          catch (Exception ex)
          {

              ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
          }
      }
      internal void ValidateContentSearch_SCORMEditSummary_Complete_SharedSteps7276()
      {
          try
          {
              List<string> errors = new List<string>();
              if (!driverobj.IsElementVisible(By.Id("MainContent_UC1_btnCancel")))
              { errors.Add("Cancel button is not coming on SCORM Course Edit Summary page"); }
              if (!driverobj.IsElementVisible(By.Id("MainContent_UC1_Save")))
              { errors.Add("Save button is not coming on SCORM Course Edit Summary Page "); }
              if (!driverobj.existsElement(ObjectRepository.sucessmessage))
              { errors.Add("After Create Scorm Course , Sucess message is not comming. "); }
              if (!driverobj.existsElement(By.Id("MainContent_UC1_FormView1_CNT_CRAWL")))
              { errors.Add("Enable full text indexing for this content item. checkbox is not coming on Edit Summary Page for Scorm"); }
              if (!driverobj.existsElement(By.Id("MainContent_UC1_FormView1_CNT_ACCESS_WITHOUT_LOGIN")))
              { errors.Add("Allow users to access this content without logging in.- checkbox is not coming on Edit Summary Page"); }
              if (errors.Count > 0)
              {
                  string allErrors = string.Join("", errors);
                  throw new Exception(allErrors);
              }
          }
          catch (Exception ex)
          {
              ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
          }
          
      }
      internal bool ValidatePreviewButton()
      {
          bool actres = false;
          try
          {
              if (driverobj.IsElementVisible(By.CssSelector("input[id*='_btnPreview']")))
              {
                  string originalHandle = driverobj.CurrentWindowHandle;
                  driverobj.GetElement(By.CssSelector("input[id*='_btnPreview']")).Click();
                  Thread.Sleep(3000);
                  driverobj.SelectWindowClose2("Meridian Global - Core Domain", "Content");

                  if (driverobj.IsElementVisible(ObjectRepository.sucessmessage))
                  {
                      throw new Exception("Sucess Messgae should not come on closing the Scorm couse window open from Preview button");
                  }

                  else
                  {
                      actres = true;
                  }

              }

              else
              {
                  throw new Exception("Preview Button is not displayed for SCORM course after create");
              }
          }
          catch (Exception ex)
          {
              ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
          }
          return actres;
      }
      internal void ManageScormCourse(string browserstr)
      {
          try
          {
              Scorm12 CreateScorm = new Scorm12(driverobj);
              Document documentpage = new Document(driverobj);
              documentpage.linkmyresponsibilitiesclick();
              documentpage.tabcontentmanagementclick();
              driverobj.GetElement(By.XPath("//input[@id='MainContent_ucSearchTop_SearchFor']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_scrom["Title"] + browserstr);
              driverobj.GetElement(By.XPath("//input[@id='btnSearchCourses']")).ClickWithSpace();
              driverobj.WaitForElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']"));
              driverobj.GetElement(By.XPath("//a[@id='ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails']")).ClickWithSpace();
              driverobj.Checkout();
              driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
              driverobj.GetElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']")).ClickWithSpace();
              driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE"));
              if (!driverobj.existsElement(By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")))
              {
                  driverobj.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeysWithSpace("updating scenario");
              }
              else
              {
                  driverobj.GetElement(By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
              }
              driverobj.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
              Thread.Sleep(2000);
          }
          catch (Exception ex)
          {
              ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
          }
      }
     
    }
}
