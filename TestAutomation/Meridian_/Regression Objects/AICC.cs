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
using OpenQA.Selenium.Remote;

namespace Selenium2.Meridian
{
    class AICC
    {

        private readonly IWebDriver driverobj;
        public bool tocreatescrom = false;
        public bool toassignscrom = false;
        public bool toenrollscrom = false;
        public bool tolaunchscrom = false;
        public AICC(IWebDriver driver)
        {
            driverobj = driver;
        }

         //"should Create a SCORM 1.2 course and check it in"    
         //"should Assign the SCORM 1.2 as required training to the new end user" 

      string path = string.Empty;
      RelativeDirectory rd = new RelativeDirectory();
      

      public void linkmyresponsibilitiesclick()
      {
          try
          {
              driverobj.WaitForElement(ObjectRepository.myResponsibilities);
              driverobj.GetElement(ObjectRepository.myResponsibilities).ClickAnchor();
              driverobj.WaitForElement(ObjectRepository.searchHome);
              tocreatescrom = true;

          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
             
              tocreatescrom = false;


          }

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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
             
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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
              
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
              Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);tocreatescrom = false;
              toassignscrom = false;
          }
      }
      public void navigateaiccfile(IWebDriver iSelenium)
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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            
              tocreatescrom = false;
          }
      }
      public void buttoncreateclick(IWebDriver iSelenium)
      {
          if (tocreatescrom == false)
          {
              return ;
          }
          try
          {

             // driverobj.WaitForpagetoload(ObjectRepository.create_btn_new);
              driverobj.GetElement(ObjectRepository.nxt_btn_new).ClickWithSpace();
              //driverobj.WaitForpagetoload(ObjectRepository.Return_Feedback_id);
              tocreatescrom = true;

          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
             
              tocreatescrom = false;
          }
      }
      public void populatesummaryform(IWebDriver iSelenium, string browserstr)
      {
          
          try
          {
              driverobj.WaitForElement(ObjectRepository.scromtitle);
              driverobj.GetElement(ObjectRepository.scromtitle).Clear();
             // Thread.Sleep(3000);
              driverobj.GetElement(ObjectRepository.scromtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_aicc["Title"]+browserstr);
             
          

              //result = generalCourse.GetElement(By.XPath(Object.Return_Feedback), 90, true).Text.ToString();
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            
             
          }
      }
      public bool buttonsaveclick(IWebDriver iSelenium)
      {
          if (tocreatescrom == false)
          {
              return false;
          }
          try
          {
              //driverobj.ScrollToCoordinated("0", "250");
              driverobj.WaitForElement(ObjectRepository.create_btn_new);
              driverobj.GetElement(ObjectRepository.create_btn_new).ClickWithSpace();
              driverobj.WaitForElement(ObjectRepository.CheckinNew);
              driverobj.GetElement(ObjectRepository.CheckinNew).ClickWithSpace();
              Thread.Sleep(5000);
             // driverobj.WaitForElement(ObjectRepository.Return_Feedback_id);
             // Thread.Sleep(5000);
              return true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
             
              return false;

          }
          //throws information is saved
      }
      public void populatesearchscorm(IWebDriver iSelenium, string browserstr)
      {
          
          try
          {
              driverobj.WaitForElement(ObjectRepository.scromsearch_actingrole);
           //   driverobj.FindSelectElementnew(ObjectRepository.scromsearch_actingrole, "Other");
              driverobj.GetElement(ObjectRepository.scromsearch_ed).ClickWithSpace() ;
              Thread.Sleep(2000);
              driverobj.GetElement(ObjectRepository.scromsearch_ed).SendKeys(ExtractDataExcel.MasterDic_scrom["Title"]+browserstr);
              driverobj.FindSelectElementnew(ObjectRepository.scromsearch_type, "All words");
              toassignscrom = true;


          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);toassignscrom = false;
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
              Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);toassignscrom = false;
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
              Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);toassignscrom = false;
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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
              
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
             // driverobj.GetElement(ObjectRepository.scromAssignTrainingfirstname).SendKeys(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr);
              //driverobj.FindSelectElementnew(ObjectRepository.assignTrainingSearchType, "All words");
              driverobj.WaitForElement(ObjectRepository.assignTrainingSearchBtn);
              driverobj.GetElement(ObjectRepository.assignTrainingSearchBtn).ClickWithSpace();
              driverobj.WaitForElement(ObjectRepository.tableResultAssignTraining);
              toassignscrom = true;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
          
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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
             
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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
             
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
              Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
              
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
                      driverobj.GetElement(By.XPath("//body")).SendKeys(Keys.F5);
                      buttonopenscormclick(driverobj);
                      result = driverobj.GetElement(ObjectRepository.scromlunchcourseexisting).GetAttribute("value");
                      cnt = cnt + 1;
                      //refreshpage(aicc);
                  }
                  else
                  {
                      break;
                  }
              }
             
             // buttonopenscormclick(aicc);
              result = driverobj.GetElement(ObjectRepository.scromlunchcourseexisting).GetAttribute("value");
              // result = driverobj.Title;
           
          }
          catch (Exception ex)
          {
             
              Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
              
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
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            
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
              Console.WriteLine(ex.Message);ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
       
 
        public string result = "null";
        

      public void  uploadfile(string path)
      {
          try
          {
              IAllowsFileDetection allowsDetection = (IAllowsFileDetection)driverobj;
              if (allowsDetection != null)
              {
                  allowsDetection.FileDetector = new LocalFileDetector();

              }
              Thread.Sleep(6000);
              driverobj.GetElement(ObjectRepository.scrom12_fileupload).SendKeys(path);
              Thread.Sleep(10000);
              //driverobj.GetElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_UploadContent_TDElementUploadFile']/table/tbody/tr/td/input")).SendKeys(path);
          }
          catch (Exception ex)
          {
              System.Windows.Forms.SendKeys.SendWait("{ESC}");
              Thread.Sleep(6000);
              // path = string.Empty;
              uploadfile(path);
          }
      }
      internal void CreateAICCCource(string browserstr)
      {
          TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
          Document documentobj = new Document(driverobj);
          Scorm12 scornobj = new Scorm12(driverobj);
          Trainings Trainingsobj = new Trainings(driverobj);
          TrainingHomeobj.MyResponsiblities_click();
       //   documentobj.tabcontentmanagementclick();
          Trainingsobj.CreateContentButton_Click_New(Locator_Training.AICC_CourseClick);
          driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
          driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
          driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
          driverobj.navigateAICCfile("\\Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
          scornobj.buttoncreateclick(driverobj,false);
          populatesummaryform(driverobj, browserstr);
          scornobj.buttonsaveclick(driverobj);
      }
      public static class locator
      {
          public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
          public static By classroomuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");
          public static By classroomtrainingsourcetypecode = By.Id("MainContent_UC1_FormView1_EHRI_CRSW_TR_SRC_TYP_CO");
          public static By classroomtrainingpurposetype = By.Id("MainContent_UC1_FormView1_EREP_DET_TRG_PURPOSE_TYPE");
          public static By ClassroomCourseSummaryCreditValuetextbox = By.Id("MainContent_UC1_CRSW_CREDIT_VALUE");
          public static By ManageSectionsLink = By.Id("MainContent_hlScheduling");
          public static By AddNewsectionBtn = By.Id("MainContent_MainContent_ucTopBar_FormView1_btnAddNewSection");
          public static By SectionTitle = By.Id("MainContent_UC1_FormView1_CRSSECT_TITLE");
          public static By NxtBtn = By.Id("MainContent_UC1_btnNext");
          public static By StartDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput");
          public static By EndDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput");
          public static By AllDayEvnt = By.Id("MainContent_UC1_FormView1_EVT_ALLDAYEVENT");
          public static By MinimumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
          public static By MaximumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
          public static By SaveAndExit = By.Id("MainContent_UC1_btnSave");
          public static By ChangeEnrolDate = By.Id("MainContent_UC1_FormView1_lnkEnrollInfo");
          public static By EnroStartDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput");
          public static By EnrolEndDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput");
          public static By EnroStartDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_popupButton");
          public static By EnrolEndDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_popupButton");
          public static By EnrolStartTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput_text");
          public static By EnrolEndTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput_text");
          public static By ClassroomCalendarView = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
          public static By manageenrollmentenrolusersbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnEnrollUser");
          public static By manageenrollmentmanageenrollmentbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnManageEnrollment");
          public static By cancelenrolmentselectwaitlistcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl06_cbSelected");
          public static By cancelenrolmentselectenrolledcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbSelected");
          public static By cancelenrolmentorwaitlistreasontextbox = By.Id("MainContent_UC1_tbUnenrollReason");
          public static By cancelenrolmentorwaitlistcancelenrolmentorwaitlistbutton = By.Id("MainContent_UC1_btnCancelEnrollWaitlist");
          public static By waitlistuserswaitlistusersbutton = By.Id("MainContent_UC1_btnWaitlistUsers");
          public static By batchenrollmentlastnametxtbox = By.Id("MainContent_UC1_USR_LAST_NAME");
          public static By batchenrollmentfirstnametxtbox = By.Id("MainContent_UC1_USR_FIRST_NAME");
          public static By batchenrollmentsearchbutton = By.Id("MainContent_UC1_btnSearch");
          public static By batchenrollmentselectcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbEnrolluser");
          public static By batchenrollmenticon = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_btnInfo");
          public static By batchenrollmentcancelicon = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_MImageButton2");
          public static By waitlistselectcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbWaitlist");
          public static By batchenrollmenttablelastnamelabel = By.XPath("//td[contains(.,'Site')]");
          public static By batchenrollmentbatchenrollusersbutton = By.Id("MainContent_UC1_btnEnrollUsers");
          public static By manageenrollmentmanagewaitlistbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnManageWaitlist");
          public static By batchenrollmentfeedback = By.XPath("//div[@class='alert alert-success']");
          public static By schedulemanagesectionSearcfortxtbox = By.Id("filterNameCode");
          public static By schedulemanagesectionSectionstatusdrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSectionStatus");
          public static By schedulemanagesectionActivitydrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSearchActivity");
          public static By schedulemanagesectionStartdatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdStartDate_dateInput");
          public static By schedulemanagesectionEnddatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdEndDate_dateInput");
          public static By schedulemanagesectionFilterbutton = By.XPath(".//*[@id='MainContent_pnlMVCSection']/div[1]/div[2]/div/div[1]/div/span/button");
          public static By schedulemanagesectionResulttable = By.XPath("//tr[@id = 'ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0']/td/a");
          public static By schedulemanagesectionclassroomcalendarlink = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
          public static By editeventselectlocationbutton = By.Id("MainContent_UC1_FormView1_lnkSelectLoc");
          public static By selectlocationframesearchbutton = By.Id("MainContent_UC1_btnSearch");
          public static By selectlocationframesroomtyperadiobutton = By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect");
          public static By selectlocationframessaveandexitbutton = By.Id("MainContent_UC1_Save");
          public static By selectlocationssuccessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By LogoutHoverLink = By.XPath("//a[normalize-space()='Logout']");
          public static By classroomcalendarviewlink = By.XPath("//a[contains(@id,'lnkDetails')]");
          public static By ClassroomcourseSave = By.Id("MainContent_UC1_Save");
          public static By classroomCoursesLink = By.XPath("//span[contains(.,'Content Management')]");
          public static By classroomTitle = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");

          //public static By classroomDesc = By.XPath("//*[@id='ctl00_MainContent_UC1_FormView1_rdEditorDesc_contentIframe']");
          public static By classroomDesc = By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']");
          public static By classroomKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
          public static By classroomsectionMinimumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
          public static By classroomsectionMaximumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
          public static By contentaccessapprovaleditbutton = By.Id("MainContent_MainContent_ucAccessApproval_accAccesApproval_lnkEdit");
          public static By contentaccessapprovalsuccessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By contentdeletecontentbutton = By.Id("MainContent_header_FormView1_btnDelete");
          public static By contentmanagelink = By.Id("MainContent_MainContent_UC4_hlManage");
          public static By managestudentsmanagesurveylink = By.Id("MainContent_UC4_hlManage");
          public static By sectiondetailsmanagelink = By.Id("MainContent_MainContent_ucEvaluations_hlManage");
          public static By surveysassignsurveyslink = By.Id("MainContent_UC1_btnAssignSurveys");
          public static By surveyframesearchtxtbox = By.Id("MainContent_UC1_txtSearchFor");
          public static By surveyframesearchtxtfilter = By.Id("MainContent_UC1_ddlSearchType");
          public static By surveyframesearchbutton = By.Id("MainContent_UC1_btnSearch");
          public static By surveyframeselectchkbox = By.Id("ctl00_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect");
          public static By surveyframesavebutton = By.Id("MainContent_UC1_Save");
          public static By surveyremovebutton = By.Id("MainContent_UC1_btnRemove");
          public static By contentsearchSearchAdvlnk = By.Id("MainContent_ucSearchTop_FormView1_lblSeeMore");
          public static By contentsearchSearchfortxtbx = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
          public static By contentsearchSearchfilterdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
          public static By contentsearchSearchTitletxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_TITLE");
          public static By contentsearchSearchDescriptiontxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_DESCRIPTION");
          public static By contentsearchSearchKeywordstxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_KEYWORDS");
          public static By contentsearchSearchCategorytxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNTCTGY_CATEGORY_ID");
          public static By contentsearchSearchRatingfilterdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_strRatingType");
          public static By contentsearchSearchRatingdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_intRating");
          public static By contentsearchSearchEditingStatusdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchStatusType");
          public static By contentsearchSearchActivitydrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchActivity");
          public static By contentsearchSearchbutton = By.Id("btnSearchCourses");
          public static By contentsearchResultTable = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
          public static By contentsearchItemscountlbl = By.Id("MainContent_ucSearchResults_lblItemCount");
          public static By MyRespnsibilitySearch = By.Id("MainContent_ucAdminQuickSearch_txtSearch");
          public static By MyRespnsibilitySearchFilter = By.Id("ddlSearchType");
          public static By MyRespnsibilitySearchButton = By.Id("btnContentSearch");
          public static By ContentSearchResultTitle = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
          public static By contentsearchresultcount = By.XPath("/html/body/form/div[6]/div/div[6]/div/div[3]");
          public static By sectiondetailscopybutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkCopy");
          public static By copyframedatetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_DATE_dateInput");
          public static By copyframetimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_TIME_dateInput");
          public static By copyframecopybutton = By.Id("MainContent_UC1_Save");
          public static By sectiondetailssuccessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By courseinformationtrainingpurposetypecodedrpdwn = By.Id("MainContent_UC1_FormView1_EREP_DET_TRG_PURPOSE_TYPE");
          public static By courseinformationtrainingsourcetypecodedrpdwn = By.Id("MainContent_UC1_FormView1_EHRI_CRSW_TR_SRC_TYP_CO");
          public static By courseinformationuniqueidtextbox = By.Id("MainContent_UC1_CNT_NUMBER");
          public static By CourseSectionLink1 = By.Id("MainContent_MHyperLink2");
          public static By eventselecteventcheckbox = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_chkSelect");
          public static By eventremoveeventbutton = By.Id("MainContent_UC1_FormViewButton_btnGo");
          public static By deleteeventsuccessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By detailsenrolbutton = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnEnroll");
          public static By detailssectioninfo = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/img");
          public static By myresponsibilitiesmycontenttitlelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
          public static By myresponsibilitiesaddnew = By.Id("MainContent_ucLastModifiedContent_hlAddNew");
          public static By myresponsibilitiesinstructortoolsportletdrpdwn = By.Id("MainContent_ucInstructorToolsSummary_Instructor");
          public static By myresponsibilitiesinstructortoolsportletbutton = By.Id("MainContent_ucInstructorToolsSummary_btnSearch");
          public static By myresponsibilitiesinstructortoolsportlettableresult = By.Id("ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00_ctl04_lnkDetails");
          public static By myresponsibilitiesinstructortoolsportlettableresultcount = By.XPath("//div[3]/div[2]/table/tbody/tr");
          public static By detailseventschedulesectiontitle = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl06_rgEvents_ctl00_ctl04_MLabel2");
          public static By sectiondetailediteventlink = By.Id("MainContent_MainContent_ucSectionEvents_MAccordion1_lbEdit");
          public static By eventseditbutton = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_btnGo");
          public static By editeventstrttimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_START_TIME_dateInput");
          public static By editeventendtimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_TIME_dateInput");
          public static By editeventsaveandexitbutton = By.Id("MainContent_UC1_btnSave");
          public static By eventssuccessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By expensesprofessionalservices = By.Id("CRSSECT_PROF_SERVICE");
          public static By expensesfacilityservices = By.Id("MainContent_UC1_FormView1_CRSSECT_FACILITY_FEES");
          public static By expensestravelexpenses = By.Id("MainContent_UC1_FormView1_CRSSECT_TRAVEL_EXPENSES");
          public static By expensesequipmentrental = By.Id("MainContent_UC1_FormView1_CRSSECT_EQUIPMENT_RENTAL");
          public static By expensessavebutton = By.Id("MainContent_UC1_Save");
          public static By managestudentsinstructortoolslink = By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li[4]/a/span");
          public static By managestudentsmyteachingscheduletab = By.Id("MainContent_UC1_lbMyTeachingSchedule");
          public static By managestudentsmanagestudentstab = By.Id("MainContent_UC1_lbManageStudentsActive");
          public static By searchHome = By.Id("btnContentSearch");
          public static By myresponsibilitiesinstructorgobutton = By.Id("MainContent_ucInstructorToolsSummary_btnSearch");
          public static By goCreateClassroombtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
          public static By informationcitylabel = By.Id("MainContent_UC1_PopUpUserInfo_lblCityTxt");
          public static By manageenrolmentforonlinecoursebuttonenrollcourse = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnEnrollUser");
          public static By manageenrolmentforonlinecoursesearchbutton = By.Id("btnSearchCourses");
          public static By manageenrolmentforonlinecoursesearchtextbox = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
          public static By manageenrolmentforonlinecoursefilterdropdown = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
          public static By manageenrolmentforonlinecourseresulttablelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
          public static By myResponsibilities = By.Id("NavigationStrip1_lbMyResponsibilities");
          public static By manageenrolmentforonlinecoursemanageenrollment = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnManageEnrollment");

          // general course
          public static By create_btn_new = By.Id("MainContent_UC1_Save");
          public static By genCourseTitle_ED = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
          public static By generalcourseenroll_btn = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
          public static By generalcoursekeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
          public static By myresponsibilitiesmanageenrolmentonlinecourses = By.Id("MainContent_ucManageEnrollmentMenu_hlManageOnlineEnrollement");

          public static By myresponsibilitiesmostrecentrequestusernamelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkContentTitle");
          public static By myresponsibilitiesmostrecentrequestcontenttitlelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkSectionTitle");
          public static By myresponsibilitiestodaylink = By.XPath("//a[contains(.,'Last 30 Days')]");
          public static By myresponsibilitiesviewallcoursesbutton = By.Id("MainContent_ucLastModifiedContent_lbAllContent");
          public static By org_select_link = By.Id("MainContent_UC1_lnkSelectOrg");
          public static By org_search_text = By.Id("MainContent_UC1_txtSearch");
          public static By org_search_btn = By.Id("MainContent_UC1_btnSearch");
          public static By org_radio_btn = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
          public static By org_save_btn = By.Id("MainContent_UC1_Save");
          public static By org_create_btn = By.Id("MainContent_UC1_Create");
          public static By login_name = By.CssSelector("span.rmText.rmExpandDown");

          public static By createnewcoursesectionandeventradiobutton = By.Id("MainContent_UC1_FormView1_CRSSECT_WAITLIST_OPTION_0");
          public static By scheduleandmanagesectionsmanageenrollmentbutton = By.Id("MainContent_header_FormView1_lnkManageEnroll");
          public static By schedulemanagesectionsectiontitlelink = By.CssSelector("#ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0 > td > a");
          public static By sectiondetailsEdit = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkEdit");
          public static By contentclassroomtitlelabel = By.Id("MainContent_MainContent_ucSummary_FormView1_MLabel2");
          public static By sectiondetaildeletesectionbutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkDelete");
          public static By sectiondetailsdeletemessage = By.XPath("//div[@class='alert alert-success']");
          public static By sectiondetailexpenseseditlink = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lbEdit");
          public static By sectiondetailexpensestotal = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lblTotalValue");
          public static By sectionenrolsucessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By sectioninformationclosewindowlink = By.Id("ML.BASE.CMD.CloseWindow");
          public static By sectionsucessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By sucessmessage = By.XPath("//div[@class='alert alert-success']");
          public static By attendancebutton = By.Id("MainContent_UC1_btnAttendance");
      }
    }
}
