using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Reflection;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using System.Drawing;

namespace TestAutomation.Meridian.Regression_Objects
{
    class MyOwnLearningUtils
    {

        private readonly IWebDriver driverobj;
        public MyOwnLearningUtils(IWebDriver driver)
        {
            driverobj = driver;
        }

        public void linkmyresponsibilitiesclick()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);
                driverobj.HoverLinkClick(By.XPath("//a[@id='ManagerView']"), By.XPath("//a[@href='/Admin/MyResponsibilities/Training.aspx']"));
                driverobj.WaitForElement(ObjectRepository.searchHome);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click My Responsbilities Link", driverobj);

            }

        }
        public void linkgeneralcourseclick()
        {

            try
            {
                driverobj.WaitForElement(Locator_Training.Training_CreateButtonClick);
                driverobj.GetElement(Locator_Training.Training_CreateButtonClick).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'General Course')]"));
                driverobj.FindElement(By.XPath("//a[contains(.,'General Course')]")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }

        }
        public void buttongoclick()
        {

            try
            {
                //driverobj.select(ObjectRepository.selectcoursetype, "General Course");
                //driverobj.GetElement(ObjectRepository.goCreateClassroombtn).Click();
                //driverobj.WaitForElement(ObjectRepository.classroomTitle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }

        }
        public void populatesummarygeneralCourse(int i, string type, string browserstr)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.genCourseTitle_ED);
                driverobj.ClickEleJs(ObjectRepository.genCourseTitle_ED);
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + i);
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                driverobj.GetElement(ObjectRepository.generalcoursekeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
              

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }
        public void populateCourseFilesform()
        {

            try
            {
                // generalCourse.GetElement(ObjectRepository.generalcourseboostindex).SendKeys("2");
                driverobj.GetElement(ObjectRepository.generalcourseurlradio).Click();
                driverobj.GetElement(ObjectRepository.generalcourseurl_txtfld).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Url"]);

                //    generalCourse.GetElement(By.Id("TabMenu_ML_BASE_TAB_UploadFiles_COURSE_SAVE_FILE")).Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }
        public bool buttoncreateclick()
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.create_btn_new);
                driverobj.GetElement(ObjectRepository.create_btn_new).Click();

                driverobj.WaitForElement(ObjectRepository.CheckinNew);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;

            }
            return true;//throws information is saved
        }

        public bool editaccessperiod()
        {

            try
            {

                driverobj.WaitForElement(By.Id("MainContent_MainContent_ucAccessPeriod_lnkEdit"));
                driverobj.ClickEleJs(By.Id("MainContent_MainContent_ucAccessPeriod_lnkEdit"));

                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_CNT_ENABLE_ACCESS_PERIOD_0"));
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_CNT_ENABLE_ACCESS_PERIOD_0")).Click();
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_CNT_ACCESS_PERIOD")).SendKeysWithSpace("1");
                driverobj.FindSelectElementnew(By.Id("MainContent_MainContent_UC1_CNT_ACCESS_PERIOD_TYPE"), "Day(s)");
                Thread.Sleep(2000);
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_Save")).ClickWithSpace();
               
                driverobj.WaitForElement(sucessmessage);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;

            }
            return true;//throws information is saved
        }


        public bool buttoncheckinclick()
        {

            try
            {

                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                driverobj.ClickEleJs(ObjectRepository.CheckinNew);
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;

            }
            return true;//throws information is saved
        }

        public string CreateGeneralCourse(int noofcourse, string usefor, string browserstr)
        {
            string actualresult = string.Empty;
            //ObjectRepository.CourseTitle = ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "_" + usefor;
            try
            {


                for (int i = 1; i <= noofcourse; i++)
                {

                    linkmyresponsibilitiesclick();
                    linkgeneralcourseclick();
                    buttongoclick();
                    populatesummarygeneralCourse(i, usefor, browserstr);
                    populateCourseFilesform();
                    buttoncreateclick();
                    editaccessperiod();
                    buttoncheckinclick();
                }

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool SearchGeneralCourse(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                //ExtractDataExcel.GeneralCourse();
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();
                driverobj.WaitForElement(ObjectRepository.CourseName_Ed);
                driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1);//ExtractDataExcel.generalcourse("name"));
                driverobj.FindSelectElementnew(ObjectRepository.CourseName_Typ, ObjectRepository.filterdropdowntext);
                driverobj.GetElement(ObjectRepository.CourseSearch_Btn).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]")).SendKeys(OpenQA.Selenium.Keys.Enter);
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));
                driverobj.WaitForElement(ObjectRepository.generalcourseenrollbutton);
                actualresult = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool SiteSearch(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                //ExtractDataExcel.GeneralCourse();
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();

                driverobj.WaitForElement(By.Id("txtGlobalSearch"));
                driverobj.GetElement(By.Id("txtGlobalSearch")).ClickWithSpace();
                
                /*Actions action = new Actions(driverobj);
                Cursor.Position = new Point(0, 0);
                action.MoveToElement(link).Build().Perform();
                Thread.Sleep(2000);*/
                driverobj.WaitForElement(By.Id("txtGlobalSearch"));
                // driverobj.GetElement(By.Id("SiteNavigationBar2_SiteWide_txtSearch")).Click();
                driverobj.GetElement(By.Id("txtGlobalSearch")).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1);
                driverobj.WaitForElement(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']"));
                driverobj.GetElement(By.XPath("//button[@onclick='return SiteWideSearchRedirect();']")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.ClickEleJs(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));
           actualresult=     driverobj.existsElement(ObjectRepository.generalcourseenrollbutton);
                
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }
        public string DeleteGeneralCourse(int noofcourse)
        {
            string actualresult = string.Empty;
            //try
            //{
            //    //ExtractDataExcel.GeneralCourse();
            //    driverobj.GetElement(ObjectRepository.adminconsoleopenlink).Click();
            //    driverobj.selectWindow(ObjectRepository.adminwindowtitle);
            //    driverobj.GetElementOnPage(ObjectRepository.gereralcourse_link);
            //    driverobj.GetElement(ObjectRepository.gereralcourse_link).Click();

            //    for (int i = 1; i <= noofcourse; i++)
            //    {
            //        driverobj.WaitForElement(ObjectRepository.searchtext);
            //        driverobj.GetElement(ObjectRepository.searchtext).Clear();
            //        driverobj.GetElement(ObjectRepository.searchtext).SendKeys(ObjectRepository.CourseTitle+i);

            //        driverobj.FindSelectElementnew(ObjectRepository.searchtype, ObjectRepository.filterdropdowntext);

            //        // driverobj.WaitForElement(ObjectRepository.searchbutton);
            //        driverobj.GetElement(ObjectRepository.searchbutton).Click();
            //        driverobj.WaitForElement(By.LinkText(ObjectRepository.CourseTitle + i));
            //        driverobj.GetElement(By.LinkText(ObjectRepository.CourseTitle + i)).Click();
            //        driverobj.WaitForElement(ObjectRepository.generalcoursedeletecontentlink);
            //        driverobj.GetElement(ObjectRepository.generalcoursedeletecontentlink).Click();
            //        Thread.Sleep(5000);
            //       driverobj.SwitchTo().Window("Delete Content");
            //       //driverobj.selectWindow(ObjectRepository.generalcoursedeletewindow);
            //       // WebElementRepository.wherestuck++;
            //        Thread.Sleep(5000);
            //        driverobj.GetElement(ObjectRepository.generalcoursedeletecontentbutton).Click();
            //       //WebElementRepository.wherestuck++;
            //        driverobj.selectWindow("General Course");
            //    }

            //    //driverobj.Close();
            //    driverobj.SwitchTo().Window("");
            //    Thread.Sleep(3000);
            //    driverobj.SelectWindowClose();
            //    driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //}
            //catch (Exception ex)
            //{
            //    // int ii=  WebElementRepository.wherestuck;
            //    driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //    //Assert.Fail(ex.Message);
            //}
            return actualresult;
        }

        public string EnrollGenCourse(int noofcourse, string type, string browserstr)
        {

            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(ObjectRepository.TrainingHome).ClickWithSpace();

                for (int i = 1; i <= noofcourse; i++)
                {

                    driverobj.WaitForElement(ObjectRepository.CourseName_Ed);
                    Thread.Sleep(2000);
                    driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + i);//ExtractDataExcel.generalcourse("name"));
                    Thread.Sleep(2000);
                //    driverobj.FindSelectElementnew(ObjectRepository.CourseName_Typ, ObjectRepository.filterdropdownexact);
                    driverobj.FindElement(ObjectRepository.CourseName_Ed).SendKeys(OpenQA.Selenium.Keys.Escape);
                    driverobj.ClickEleJs(By.Id("//a[@id='btnSearch']"));
                    try { driverobj.ClickEleJs(ObjectRepository.CourseSearch_Btn); } catch (Exception) { } 
                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                    driverobj.ClickEleJs(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                    driverobj.WaitForElement(ObjectRepository.generalcourseenrollbutton);
                    driverobj.GetElement(ObjectRepository.generalcourseenrollbutton).ClickWithSpace();
                    //Thread.Sleep(3000);
                    //driverobj.GetElement(ObjectRepository.generalcourselaunchattept).Click();GC2804182318ffbsct1 ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type
                    //Thread.Sleep(5000);
                    //driverobj.selectWindow(ObjectRepository.testurlsite );
                    //driverobj.Close();
                    //driverobj.SwitchTo().Window("");
                 //   driverobj.GetElement(ObjectRepository.TrainingHome).Click();


                }
              //  driverobj.WaitForElement(ObjectRepository.TrainingHome);
                actualresult = driverobj.Title;
                Thread.Sleep(4000);
              
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;


        }

        public bool CheckStatusofTraining(string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 2 + "')]"));
                driverobj.WaitForElement(ObjectRepository.TrainingRequiredLegend);
                driverobj.WaitForElement(ObjectRepository.TrainingOverDueLegend);
                driverobj.WaitForElement(ObjectRepository.TrainingDueSoonLegend);
                driverobj.WaitForElement(ObjectRepository.TrainingRecurringLegend);
                isfound = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public bool TrainingStatusFilter(string type, string browserstr)
        {

            bool isfound = false;
            try
            {

                driverobj.GetElement(ObjectRepository.TrainingHome).Click();
                driverobj.WaitForElement(ObjectRepository.AllMyUpComingTrainingFilter);
                driverobj.FindSelectElementnew(ObjectRepository.AllMyUpComingTrainingFilter, "Enrolled");
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 2 + "')]"));
                driverobj.FindSelectElementnew(ObjectRepository.AllMyUpComingTrainingFilter, "Started");
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.FindSelectElementnew(ObjectRepository.AllMyUpComingTrainingFilter, "All");
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 2 + "')]"));
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                isfound = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        string stringtofind = "testfeed_" + DateTime.Now.ToString();

        public void CreateHomeFeeds()
        {


            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).SendKeys(OpenQA.Selenium.Keys.Enter);
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.adminhomepagefeeds).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsGoBtn).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsTitle).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsTitle).SendKeys(stringtofind);
                driverobj.GetElement(ObjectRepository.HomeFeedsDesc).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsDesc).SendKeys(stringtofind);
                driverobj.GetElement(ObjectRepository.HomeFeedsKeywords).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsKeywords).SendKeys(stringtofind);
                //driverobj.GetElement(homefeedcontactinfo).Clear();
                //driverobj.GetElement(homefeedcontactinfo).SendKeys(stringtofind);
                //driverobj.GetElement(homefeeduniqueid).Clear();
                //driverobj.GetElement(homefeeduniqueid).SendKeys("hf" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(ObjectRepository.createbutton).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsHtmlInfo).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsHtmlInfo).SendKeys("<html>\n<body>\n<h1>'" + stringtofind + "'<h1>\n</body>\n</html>");
                driverobj.GetElement(ObjectRepository.HomeFeedsSaveBtn).Click();
                driverobj.WaitForElement(ObjectRepository.checkin);
                driverobj.GetElement(ObjectRepository.checkin).Click();
                driverobj.GetElement(ObjectRepository.MoveToAdminHomePage).SendKeys(OpenQA.Selenium.Keys.Enter);
                driverobj.GetElement(ObjectRepository.admindomainmanagment).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsSelectDomain).Click();
                driverobj.WaitForElement(ObjectRepository.HomeFeedsSetDomain);
                driverobj.GetElement(ObjectRepository.HomeFeedsSetDomain).Click();
                driverobj.WaitForElement(ObjectRepository.HomeFeedsSearchFor);
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchFor).Clear();
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchFor).SendKeys(stringtofind);
                driverobj.GetElement(ObjectRepository.HomeFeedsSearchForBtn).Click();

                driverobj.GetElement(ObjectRepository.HomeFeedsSelectFeed).Click();
                driverobj.GetElement(ObjectRepository.HomeFeedsSelectFeedBtn).Click();
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }

        }

        public bool CheckHomeFeeds()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(By.XPath("//*[contains(.,'" + stringtofind + "')]"));
                return true;
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool ClickAllMyTraining(string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();
                driverobj.WaitForElement(ObjectRepository.AllMyUpComingTrainingButton);
                driverobj.GetElement(ObjectRepository.AllMyUpComingTrainingButton).Click();
               isfound= driverobj.existsElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public bool ClickActionButton()
        {

            bool isfound = false;
            try
            {
                // ExtractDataExcel.GeneralCourse();
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.ClickEleJs(ObjectRepository.TrainingHome);
                driverobj.WaitForElement(ObjectRepository.AllMyUpComingTrainingButton);
                driverobj.ClickEleJs(ObjectRepository.AllMyUpComingTrainingButton);
                driverobj.WaitForElement(ObjectRepository.AllMyUpComingTrainingActionBtn);
                driverobj.ClickEleJs(ObjectRepository.AllMyUpComingTrainingActionBtn);
                //Thread.Sleep(4000);
                driverobj.SelectWindowClose();
                //driverobj.selectWindow(ObjectRepository.testurlsite );
                //driverobj.Close();
                //driverobj.SwitchTo().Window("");
                //Thread.Sleep(4000);

                isfound = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }
        public bool th_ClickActionButton()
        {

            bool isfound = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(ObjectRepository.TrainingHome).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(By.CssSelector("a[id='DefaultComboBtn']"));
                driverobj.GetElement(By.CssSelector("a[id='DefaultComboBtn']")).ClickWithSpace();
              
                driverobj.SelectWindowClose();
              
                isfound = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }
        public bool OpenDetailPage(string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(ObjectRepository.TrainingHome).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.AllMyUpComingTrainingButton);
                driverobj.GetElement(ObjectRepository.AllMyUpComingTrainingButton).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1 + "')]")).ClickAnchor();
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1 + "')]"));
                isfound = true;

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }
        public bool th_OpenDetailPage(string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(ObjectRepository.TrainingHome).ClickWithSpace();
               
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1 + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1 + "')]")).ClickAnchor();
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1 + "')]"));
                isfound = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }
        public bool CompleteTraining(int startfrom, int noofcourse, string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                //driverobj.GetElement(ObjectRepository.TrainingHome).Click();

                for (int i = startfrom; i <= noofcourse; i++)
                {
                    Thread.Sleep(4000);
                    driverobj.WaitForElement(ObjectRepository.CourseName_Ed);
                    driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i);//ExtractDataExcel.generalcourse("name"));
                    //driverobj.FindSelectElementnew(ObjectRepository.CourseName_Typ, ObjectRepository.filterdropdowntext);
                    driverobj.ClickEleJs(By.XPath(".//*[@id='btnSearch']"));

                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                    driverobj.ClickEleJs(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                    driverobj.WaitForElement(ObjectRepository.generalcourselaunchattept);
                    driverobj.GetElement(ObjectRepository.generalcourselaunchattept).ClickWithSpace();
                    Thread.Sleep(5000);
                    driverobj.SelectWindowClose2("Google","Details");
                    driverobj.WaitForElement(ObjectRepository.generalcourseMarkCompleteBlock);
                    driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteBlock).ClickWithSpace();
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.GetElement(ObjectRepository.generalcourseMarkCompleteButton).ClickWithSpace();
                    Thread.Sleep(3000);
                    driverobj.SwitchtoDefaultContent();
                   // actualresult = driverobj.GetElement(ObjectRepository.generalcoursecertificateblock).GetAttribute("value");
                    driverobj.ClickEleJs(ObjectRepository.TrainingHome);
               
                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]")).ClickWithSpace();
                actualresult=    driverobj.existsElement(By.Id("MainContent_ucContentStatus_FormView1_MLinkButton2"));
               
                  

                }
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool OpenTraining(int startfrom, int noofcourse, string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();

                for (int i = startfrom; i <= noofcourse; i++)
                {
                    Thread.Sleep(4000);
                    driverobj.WaitForElement(ObjectRepository.CourseName_Ed);
                    driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeysWithSpace(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + i);//ExtractDataExcel.generalcourse("name"));
                    driverobj.FindSelectElementnew(ObjectRepository.CourseName_Typ, ObjectRepository.filterdropdowntext);
                    driverobj.GetElement(ObjectRepository.CourseSearch_Btn).ClickWithSpace();

                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + i + "')]"));
                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + i + "')]")).ClickWithSpace();
                    driverobj.WaitForElement(ObjectRepository.generalcourselaunchattept);
                    driverobj.GetElement(ObjectRepository.generalcourselaunchattept).ClickWithSpace();
                    driverobj.SelectWindowClose();
                   actualresult= driverobj.existsElement(ObjectRepository.generalcourseMarkCompleteBlock);

                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public string StartTraining(int noofcourse, string type, string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();

                for (int i = 1; i <= noofcourse; i++)
                {
                    Thread.Sleep(4000);
                    driverobj.WaitForElement(ObjectRepository.CourseName_Ed);
                    driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i);//ExtractDataExcel.generalcourse("name"));
                    driverobj.FindSelectElementnew(ObjectRepository.CourseName_Typ, ObjectRepository.filterdropdowntext);
                    driverobj.GetElement(ObjectRepository.CourseSearch_Btn).Click();

                    driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]")).SendKeys(OpenQA.Selenium.Keys.Enter);
                    driverobj.WaitForElement(ObjectRepository.generalcourselaunchattept);
                    driverobj.GetElement(ObjectRepository.generalcourselaunchattept).Click();
                    driverobj.SelectWindowClose();
                    driverobj.GetElement(ObjectRepository.TrainingHome).Click();

                }
            }
            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool CheckCompletedCourse(int noofcourse, string type, string browserstr)
        {

            bool isfound = false;
            try
            {


                for (int i = 1; i <= noofcourse; i++)
                {
                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));

                }

                driverobj.GetElement(ObjectRepository.completed30days);
                driverobj.GetElement(ObjectRepository.completed60days);
                driverobj.GetElement(ObjectRepository.completed90days);
                driverobj.GetElement(ObjectRepository.AllMyCompletedTrainingActionBtn1);
                driverobj.GetElement(ObjectRepository.AllMyCompletedTrainingActionBtn2);


                isfound = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public bool Check306090(int noofcourse, string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                driverobj.GetElement(ObjectRepository.TrainingHome).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucCompletedTraining_lbl30Days"));
                driverobj.GetElement(By.Id("MainContent_ucCompletedTraining_lbl30Days")).ClickWithSpace();
                IList<IWebElement> tab = driverobj.FindElements(By.XPath("//*[@id='MainContent_ucCompletedTraining_pnlFilter']/a"));
               
                foreach (IWebElement tabtext in tab)
                {
                   
                    tabtext.Click();
            isfound=driverobj.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
            driverobj.Navigate().Refresh();
            IList<IWebElement> tab1 = driverobj.FindElements(By.XPath("//*[@id='MainContent_ucCompletedTraining_pnlFilter']/a")); 
foreach(IWebElement tabtext2 in tab1)
{
    tab1[1].ClickWithSpace();
    isfound = driverobj.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1 + "')]"));
     driverobj.Navigate().Refresh();
            IList<IWebElement> tab2 = driverobj.FindElements(By.XPath("//*[@id='MainContent_ucCompletedTraining_pnlFilter']/a"));
            foreach (IWebElement tabtext3 in tab2)
            {
                tab2[2].ClickWithSpace();
                isfound = driverobj.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + type + 1 + "')]"));
                break;
            }
            break;
}
break;

                }
               

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public bool ClickAllMyCompletedTraining(string pagetitle, string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.AllMyCompletedTrainingButton);
                driverobj.GetElement(ObjectRepository.AllMyCompletedTrainingButton).ClickWithSpace();
                driverobj.WaitForTitle("Transcript", new TimeSpan(0, 0, 30));//pagetitle
              isfound=  driverobj.existsElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + "1" + "')]"));
              
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public bool ViewCertificateDetail(string browserstr)
        {
            By ViewCertificate = By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "th_completed" + 1 + "')]/../../td[5]");
            bool isfound = false;
            try
            {
                //driverobj.highlightElement(ViewCertificate);
                //driverobj.highlightElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + "th_completed" + 1 + "')]/../../td[5]"));
                driverobj.GetElement(ViewCertificate).ClickWithSpace();
                Thread.Sleep(4000);
                driverobj.SwitchTo().Window(driverobj.WindowHandles.Last());
                Thread.Sleep(3000);
                //driverobj.SelectFrame();
                //driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.Id("UserFullName"));
                Thread.Sleep(2000);
                string username = ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr.ToString() + " " + ExtractDataExcel.MasterDic_userforreg["Lastname"]+browserstr.ToString();
                if (driverobj.existsElement(By.Id("UserFullName")))
                {
                    isfound = true;
                }
                driverobj.SelectWindowClose2("Meridian Global 2010.1", "Home");

            }

            catch (Exception ex)
            {
                driverobj.SelectWindowClose2("Meridian Global 2010.1", "Home");
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            
            return isfound;

        }

        public bool ClickTranscriptPrint(string pagetitle, int noofcourse, string type, string browserstr)
        {

            bool isfound = false;
            try
            {

                driverobj.WaitForElement(ObjectRepository.AllMyCompletedTrainingButton);
                driverobj.GetElement(ObjectRepository.AllMyCompletedTrainingButton).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.TanscriptPrintBtn);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(ObjectRepository.TanscriptPrintBtn).ClickWithSpace();
                Thread.Sleep(4000);
                driverobj.SwitchWindow("All Training");
                Thread.Sleep(6000);

                for (int i = 1; i <= noofcourse; i++)
                {
                 isfound=   driverobj.existsElement(By.XPath("//td[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                }

                driverobj.SelectWindowClose2("All Training", "Transcript");
              

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public bool ClickOnTranscriptItem(string type, string browserstr)
        {

            bool isfound = false;
            try
            {

                //driverobj.GetElement(ObjectRepository.TrainingHome).Click();
                driverobj.WaitForElement(ObjectRepository.AllMyCompletedTrainingButton);
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + "1" + "')]")).ClickWithSpace();
                //driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//ObjectRepository.CourseTitle + 1
               isfound= driverobj.existsElement(By.XPath("//h1[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + "1" + "')]"));


            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public bool setautosearch()
        {
            bool isfound = false;
            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).SendKeys(OpenQA.Selenium.Keys.Enter);
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(ObjectRepository.adminconfigconsole).SendKeys(OpenQA.Selenium.Keys.Enter);
                driverobj.GetElement(ObjectRepository.adminconfigconsolesearch).SendKeys(OpenQA.Selenium.Keys.Enter);
                driverobj.GetElement(ObjectRepository.adminconsolesetautosearch).Click();
                driverobj.GetElement(ObjectRepository.save_btn);
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return isfound;
        }

        public bool showautocomplete(string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                driverobj.WaitForElement(ObjectRepository.CourseName_Ed);
                driverobj.GetElement(ObjectRepository.CourseName_Ed).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type);
                driverobj.GetElement(ObjectRepository.searchautocomplete);

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

            return isfound;
        }

        public bool CheckUpComingTraining(string type, string browserstr)
        {

            bool isfound = false;
            try
            {
                // ExtractDataExcel.GeneralCourse();
                driverobj.GetElement(ObjectRepository.UpComingTraining).Click();
                driverobj.GetElement(ObjectRepository.UpComingTrainingFilter);
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]")).SendKeys(OpenQA.Selenium.Keys.Enter);
                driverobj.WaitForElement(ObjectRepository.generalcourselaunchattept);
                driverobj.GetElement(ObjectRepository.generalcourselaunchattept).Click();

                driverobj.SelectWindowClose();

                driverobj.GetElement(ObjectRepository.UpComingTraining).Click();
                driverobj.GetElement(ObjectRepository.UpComingTrainingRequiredLegend);
                driverobj.GetElement(ObjectRepository.UpComingTrainingOverDueLegend);
                driverobj.GetElement(ObjectRepository.UpComingTrainingDueSoonLegend);
                driverobj.GetElement(ObjectRepository.UpComingTrainingRecurringLegend);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                isfound = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }

        public void CreateProfile()
        {
            try
            {
                driverobj.FindElement(By.LinkText("Training Profiles")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_TITLE")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_TITLE")).SendKeys("pf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_DESCRIPTION")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_DESCRIPTION")).SendKeys("pf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_KEYWORDS")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_KEYWORDS")).SendKeys("pf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_OFF")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_FIXED||DATEPICKER_popupButton")).Click();
                driverobj.FindElement(By.LinkText("6")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_FIXED||DATEPICKER_dateInput")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_FIXED||DATEPICKER_dateInput")).SendKeys("");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_FIXED||DATEPICKER")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_ITP_DATE_FIXED||DATEPICKER")).SendKeys("2013-08-06");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTP_RTP_RADIO_OFF")).Click();
                driverobj.FindElement(By.Id("ML.BASE.BTN.Create")).Click();
                driverobj.FindElement(By.Id("ML.BASE.BTN.Save")).Click();
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

        }

        public void CreateCurruculam()
        {
            try
            {
                driverobj.FindElement(By.LinkText("Curriculums")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_TITLE")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_TITLE")).SendKeys("cf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_DESCRIPTION")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_DESCRIPTION")).SendKeys("cf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_KEYWORDS")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_KEYWORDS")).SendKeys("cf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_CODE")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_CODE")).SendKeys("cf_001");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_CSPACE_AVLBLE_1")).Click();
                driverobj.FindElement(By.Id("ML.BASE.BTN.Create")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingActivities_GoPageActionsMenu")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys("gc_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_ContentReq_1_ACTIVITIES_1_0_1D1682C74FCE4839885CF7F5F59F0348")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Add")).Click();
                driverobj.FindElement(By.XPath("//a[@id='ML.BASE.WF.Checkin']/span")).Click();
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

        }

        public void AssignCurruculam()
        {
            try
            {
                driverobj.FindElement(By.LinkText("Curriculums")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys("cf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_Search_ID1_CONTENT1_1_0_F77CFC292E5443149335977F6B44595A")).Click();
                driverobj.FindElement(By.LinkText("Required Training")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu")).Click();
                driverobj.FindElement(By.LinkText("Required Training")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_SelectProfile_SearchFor")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_SelectProfile_SearchFor")).SendKeys("pf_01");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_SelectProfile_ML.BASE.BTN.Search")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_SelectProfile_SelectTrainingProfile_1_TrainingProfileSearch_1_0_423A091C877F4457A66FDF45F5399F8D")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_SelectProfile_Select")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).Clear();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).SendKeys("user regression");
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_3_ENTITY_LIST_1_2_6C1379271E9D4B0CBC161D75AADD33BC_P_")).Click();
                driverobj.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining")).Click();
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

        }

        public void AllMyTraining()
        {
            try
            {
                driverobj.WaitForElement(ObjectRepository.TranscriptHome);
                driverobj.GetElement(ObjectRepository.TranscriptHome).Click();
                driverobj.WaitForElement(ObjectRepository.allmytraininglink);
                driverobj.GetElement(ObjectRepository.allmytraininglink).Click();
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

        }

        public void ClickAllMyTrainingLink(int noofcourse, string type, string browserstr)
        {


            try
            {
                AllMyTraining();

                for (int i = 1; i <= noofcourse; i++)
                {
                    driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                }
                driverobj.WaitForElement(ObjectRepository.allmytrainingstatusfilter);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

        }

        public bool SelectAllMyTrainingFilter(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                AllMyTraining();
                driverobj.WaitForElement(ObjectRepository.allmytrainingstatusfilter);
                driverobj.FindSelectElementnew(ObjectRepository.allmytrainingstatusfilter, "Started");
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                driverobj.FindSelectElementnew(ObjectRepository.allmytrainingstatusfilter, "Enrolled");
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 2 + "')]"));
                driverobj.FindSelectElementnew(ObjectRepository.allmytrainingstatusfilter, "All");
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 2 + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));
                actualresult = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool ClickAllMyTrainingPrintBtn(int i, string type, string browserstr)
        {
            bool actualresult = false;

            try
            {
                AllMyTraining();
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                driverobj.GetElement(ObjectRepository.allmytrainingprintbtn).SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(3000);
                driverobj.SwitchWindow(ObjectRepository.allmytrainingprintpagetitle);
                driverobj.WaitForElement(ObjectRepository.allmytrainingprintpagelink);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);
                actualresult = true;

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool ClickAllMyTrainingPDFBtn(int i, string type, string browserstr)
        {
            bool actualresult = false;

            try
            {
                AllMyTraining();
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                driverobj.GetElement(ObjectRepository.allmytrainingsaveaspdfbtn).SendKeys(OpenQA.Selenium.Keys.Enter);
                Thread.Sleep(3000);
                driverobj.SwitchWindow(ObjectRepository.allmytrainingpdfpagetitle);
                driverobj.Close();
                Thread.Sleep(6000);
                driverobj.SwitchWindow(originalHandle);
                Thread.Sleep(8000);
                actualresult = true;

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool ClickAllMyTrainingItem(int i, string type, string browserstr)
        {
            bool actualresult = false;

            try
            {
                AllMyTraining();

                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + i + "')]")).SendKeys(OpenQA.Selenium.Keys.Enter);
                Thread.Sleep(2000);
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//ObjectRepository.CourseTitle + i
                actualresult = true;
            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }
            return actualresult;
        }

        public bool GetTranscriptItem(string type, string browserstr)
        {

            bool isfound = false;
            try
            {

                driverobj.WaitForElement(ObjectRepository.TranscriptHome);
                driverobj.GetElement(ObjectRepository.TranscriptHome).Click();
                driverobj.WaitForElement(ObjectRepository.allmytraininglink);
                driverobj.GetElement(ObjectRepository.allmytraininglink).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + 1 + "')]"));

                isfound = true;

            }

            catch (Exception ex)
            {
         ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                //Assert.Fail(ex.Message);
            }

            return isfound;

        }


        public void editexpirationdate(string type, string browserstr)
        {
            My_Responsibilities resp = new My_Responsibilities(driverobj);
            resp.Click_People();
            driverobj.WaitForElement(By.XPath("//input[@id='SEARCH_FOR']"));
            driverobj.GetElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr);
            //driverobj.GetElement(By.Id("MainContent_ucUserSimpleSearch_BaseCustomFieldSearch_btnSearch")).ClickWithSpace();
         //   driverobj.WaitForElement(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction"));
        //    driverobj.FindSelectElementnew(By.Id("ctl00_MainContent_ucSearchResults_rgSearchUser_ctl00_ctl04_ddlUsrAction"), "View Transcript");
            driverobj.GetElement(By.XPath("//button[@id='btnSearchClientSide']")).ClickWithSpace();
            driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_ddlUsrAction"));
            //IWebElement expireele = driverobj.GetElement(By.XPath("//.[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"]+browserstr + type + "')]"));
            driverobj.select(By.XPath("//select[@id='ddlUsrAction_0']"), "View Transcript");
            driverobj.GetElement(By.XPath("//*[@id='tableSearchUser']/tbody/tr/td[7]/div/div/span/a")).ClickWithSpace();
            driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnGo")).ClickWithSpace();
            Thread.Sleep(3000);
            //driverobj.SelectFrame();
            driverobj.waitforframe(ObjectRepository.switchToFrame_New);
            Thread.Sleep(3000);
            driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rdNewExpiry_dateInput"));
            driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rdNewExpiry_dateInput")).SendKeysWithSpace(DateTime.Now.AddDays(-2).ToString("M/d/yyyy"));
            driverobj.GetElement(By.Id("MainContent_UC1_Save")).ClickWithSpace();

            driverobj.WaitForElement(sucessmessage);



        }

        public bool click_systemOptions()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(lnk_systemOptions);
                driverobj.GetElement(lnk_systemOptions).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_systemTab()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//a[text()='System']"));
                driverobj.GetElement(By.XPath("//a[text()='System']")).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_brandingAndCustomization()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//a[text()='Branding and Customization']"));
                driverobj.GetElement(By.XPath("//a[text()='Branding and Customization']")).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        public bool click_homepageFeeds()
        {
            bool result = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//a[text()='Homepage Feeds']"));
                driverobj.GetElement(By.XPath("//a[text()='Homepage Feeds']")).ClickWithSpace();

                Thread.Sleep(2000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return result;
        }

        private By lnk_systemOptions = By.XPath("//li[@id='NavigationStrip1_ddlAdminMenu']//span");

        private By gentrainingpurposetype = By.Id("MainContent_UC1_FormView1_EREP_DET_TRG_PURPOSE_TYPE");
        private By genuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");
        private By gentrainingsourcetypecode = By.Id("MainContent_UC1_FormView1_EHRI_CRSW_TR_SRC_TYP_CO");

        //homepagefeed
        private By homefeeduniqueid = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_NUMBER");
        private By homefeedcontactinfo = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_CONTACT_INFO");
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");
        private By txt_classroomDesc = By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']");
        private By txteditor_Description = By.XPath("//*[@id='ctl00_MainContent_UC1_FormView1_rdEditorDesc_contentIframe']");
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");

    }
}
