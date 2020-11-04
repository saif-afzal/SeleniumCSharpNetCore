using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace TestAutomation.Suite1.Administration.AdministrationConsole
{
    public class ManageClassroomCoursePage
    {
        string format = "M/dd/yyyy";
        public static void Clicktab(string v)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]")); //a[contains(text(),'Sections')]
            Thread.Sleep(3000);
        }
        public static CreateSctionCommand CreateSection
        {
            get { return new CreateSctionCommand(); }
        }
        public static SctionTabCommand Sectiontab
        {
            get { return new SctionTabCommand(); }
        }
        public static EnrollmenttabCommand Enrollmenttab
        {
            get { return new EnrollmenttabCommand(); }
        }

        public static BatchEnrollUserModalCommand BatchEnrollUserModal
        { get { return new BatchEnrollUserModalCommand(); } }

        public static SectionsdropdownCommand Sectionsdropdown { get { return new SectionsdropdownCommand(); } }

        public static SelectInstructorModalCommand SelectInstructorModal { get { return new SelectInstructorModalCommand(); } }

        public static SelectLocationModalCommand SelectLocationModal { get { return new SelectLocationModalCommand(); } }

        public static SectionsPageCommand SectionsPage { get { return new SectionsPageCommand(); } }

        public static InstructorCalendarModalCommand InstructorCalendarModal { get { return new InstructorCalendarModalCommand(); } }

        public static bool? Enrollment()
        {
            return Driver.existsElement(By.XPath("(//button[@type='button'])[6]"));
        }
        public static string GetUpdatedSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static void ClickonSection()
        {
            Driver.existsElement(By.LinkText("Section 1"));
            Driver.clickEleJs(By.LinkText("Section 1"));
            Thread.Sleep(2000);

        }

        public static void SelectAddDayEventCheckbox()
        {
            Driver.clickEleJs(By.XPath("//div[@id='event0']/div/div/div/div/div/span[3]"));
        }

        public static void SelectWaitListasYes()
        {
            Driver.clickEleJs(By.XPath("//div[@id='enrollmentBlock']/div[2]/div/div[3]/div/div/span[3]"));
        }

        public static void ClickSectionBreadcrumb()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[4]/a"));
        }

        public static void SelectTimeZone()
        {
            Driver.Instance.selectDropdownValue(By.XPath("//select[@id='edit-time-zone']"), "(UTC-05:00) Eastern Time (US & Canada)");
        }

        public static void SelectAllDayEvent()
        {
            Driver.clickEleJs(By.XPath("//label[contains(text(),'All Day')]/following::span[contains(text(),'No')][1]"));
        }

        public static void EnterMaximum(string v)
        {
            Driver.Instance.GetElement(By.XPath("//input[@id='maxCapacity']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='maxCapacity']")).SendKeysWithSpace(v);
        }

        public static void SelectUseWaitlist(string v)
        {
            Driver.clickEleJs(By.XPath("//div[3]/div[2]/div[1]/div[3]/div/div/span[3]"));
        }

        public static void ClickSectionTitle(string s)
        {
            Driver.existsElement(By.XPath("//a[contains(.,'" + s + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'" + s + "')]"));
        }

        public static void ClickEnrollButton()
        {
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-primary btn-block margin-top-xs']"));
            Driver.Instance.waitforframe((By.CssSelector("iframe[class='k-content-frame']")));

        }

        public static void ClickEnrollmentTab()
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'Enrollment')]"));
        }

        public static void SelectCheckBox()
        {
            Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr/td/input"));
        }

        public static void ClickEnroll()
        {
            Driver.clickEleJs(By.XPath("//input[@value='Enroll']"));
        }

        public static bool? ScheduleTab()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkSchedule']"));
                result = Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Read Notes')]"));
               
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public static void ClickReadNotesButton()
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'Read Notes')]"));
            Driver.Instance.SwitchWindow("Notes");
        }

        public static void ClickCloseReadNotePopup()
        {
            Driver.clickEleJs(By.XPath("//button[contains(.,'Close')]"));
        }

        public static bool EnterNotes(string v)
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[@class='addNotes']"));
                Driver.clickEleJs(By.XPath("//a[@class='addNotes']"));
                result = Driver.Instance.IsElementVisible(By.XPath("//a[@class='removeNotes']"));
                Driver.Instance.GetElement(By.XPath("//textarea[@cols='20']")).SendKeysWithSpace(v);
               
            }
            catch (Exception e)

            {

            }


            return result;
        }

        public static void SetEnrollmentCancellationDate()
        {
            string s = DateTime.UtcNow.ToLocalTime().ToString();
            Driver.clickEleJs(By.XPath("//a[@id='addEnrollmentCancellation']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='enrollCancellEndDateTime']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='enrollCancellEndDateTime']")).SendKeysWithSpace(s);
        }

        public static bool SearchForEnrolledUser(string v)
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.XPath("//input[@id='enrollmentSearch']"));
                Thread.Sleep(5000);
                Driver.GetElement(By.XPath("//input[@id='enrollmentSearch']")).SendKeysWithSpace(v);
                Driver.clickEleJs(By.XPath("//button[@id='btnSearchEnrollmentTabs']"));
                result = Driver.Instance.IsElementVisible(By.XPath("//tr[@data-index='0']/td[2]"));
              
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static void SelectMultipleUsers()
        {
            Thread.Sleep(10000);
            Driver.existsElement(By.XPath("//table[@id='tableEnrollUsers']/thead/tr/th[1]/div[1]/input"));
            Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/thead/tr/th[1]/div[1]/input"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//input[@id='btnEnrollUsers']"));
        }

        public static void SectionDetailTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkSectionDetails']"));
        }

        public static void setCostForSection()

        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucCost_lbEdit']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lbEdit']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeysWithSpace("20");
            //Driver.clickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));

        }

        public static void SearchForContent(string classroomcoursetitle)
        {
            Driver.Instance.GetElement(By.XPath("//input[@id='txtGlobalSearch']")).SendKeysWithSpace(classroomcoursetitle);
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-default']"));
            Driver.Instance.WaitForElement(By.XPath("//a[contains(.,'" + classroomcoursetitle + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'" + classroomcoursetitle + "')]"));
            Driver.Instance.WaitForElement(By.XPath("//h1[contains(.,'" + classroomcoursetitle + "')]"));
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
            string s = Driver.GetElement(By.XPath("//strong[contains(.,'" + tagname + "')]")).Text;
            return s;
        }

        public static bool ClickButton_EditSection()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_FormView1_lnkEdit']"));
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_FormView1_lnkEdit']"));
                Thread.Sleep(5000);
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_TITLE"));
                Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput"));
                //string checkboxstatus = Driver.Instance.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_DNMIC_DATE")).GetAttribute("checked");
                string stastdateststatus = Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput")).GetAttribute("disabled");
               // Assert.AreEqual("true", checkboxstatus);
                Assert.AreEqual("true", stastdateststatus);
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool Click_Gradebook()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkGradebook']"));
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkGradebook']"));
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public static void DeleteContent(string v)
        {
            Driver.Instance.SwitchTo().DefaultContent();
            CommonSection.SearchCatalog('"' + v + '"');
            CatalogPage.ClickonSearchedCatalog(v);
            CatalogPage.ClickEditContent();
            Driver.clickEleJs(By.XPath("//div[@id='contentDetailsHeader']/div[2]/div/button"));
            Driver.clickEleJs(By.Id("MainContent_header_FormView1_btnDelete"));
            Thread.Sleep(2000);
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
           // driverobj.WaitForElement(locator.batchenrollmentfeedback);
        }

        public static bool Verify_GradebookGrid()
        {
            bool result = false;

            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Name')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Progress')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Attended')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Score')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Name')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Progress')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Attended')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Score')]"));
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool setAvailable_for_Purchase()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//legend[contains(.,'*Available for Purchase')]"));
                Driver.Instance.IsElementVisible(By.XPath("//label[contains(.,'Same as enrollment period')]"));
                Driver.Instance.IsElementVisible(By.XPath("//label[contains(.,'Custom Date Range')]"));
                Driver.clickEleJs(By.XPath("//label[contains(.,'Custom Date Range')]"));
                Thread.Sleep(1000);
                Driver.Instance.IsElementVisible(By.XPath("//label[@for='startDate2']"));
                Driver.Instance.IsElementVisible(By.XPath("//label[@for='endDate2']"));
                Driver.clickEleJs(By.XPath("//label[contains(.,'Same as enrollment period')]"));
                result = true;
            }catch(Exception e)
            {

            }
            return result;
        }

        public static void setRecurence(string v)
        {
            switch (v)
            {
                case "Weekly":
                    Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//span[contains(.,'Weekly')]"));
                  //  Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Weekly");
                    Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));
                    Driver.Instance.IsElementVisible(By.XPath("//label[contains(.,'*Repeat on')]"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("10/30/20");

                    IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@id='weekDay_0']"));
                    webElement.SendKeys(Keys.Tab);

                    Driver.clickEleJs(By.XPath("//input[@id='weekDay_0']"));
                    break;

                case "Every Weekday":
                    Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//span[contains(.,'Every Weekday')]"));
                    //  Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Every Weekday");

                    Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("10/30/20");

                    IWebElement webElement2 = Driver.Instance.FindElement(By.XPath("//input[@id='endDateRecur']"));
                    webElement2.SendKeys(Keys.Tab);

                    break;

                case "Daily":
                    Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//span[contains(.,'Daily')]"));
                    //  Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Daily");
                    Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("10/30/20");

                    IWebElement webElement3 = Driver.Instance.FindElement(By.XPath("//input[@id='endDateRecur']"));
                    webElement3.SendKeys(Keys.Tab);

                    break;

                case "Every two weeks":
                    Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//span[contains(.,'Every two weeks')]"));
                    // Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Every two weeks");
                    Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));

                    Driver.Instance.IsElementVisible(By.XPath("//label[contains(.,'*Repeat on')]"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("10/30/20");

                    IWebElement webElement4 = Driver.Instance.FindElement(By.XPath("//input[@id='weekDay_0']"));
                    webElement4.SendKeys(Keys.Tab);

                    Driver.clickEleJs(By.XPath("//input[@id='weekDay_0']"));
                    break;

                case "Monthly":
                    Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//span[contains(.,'Monthly')]"));
                    //   Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Monthly");
                    Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));
                    Driver.Instance.IsElementVisible(By.XPath("//select[@id='monthPattern_0']"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("10/30/20");

                    IWebElement webElement5 = Driver.Instance.FindElement(By.XPath("//input[@id='endDateRecur']"));
                    webElement5.SendKeys(Keys.Tab);


                    break;
                case "MonthlySDR":
                    Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//span[contains(.,'Monthly')]"));
                    //   Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Monthly");
                    Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));
                    Driver.Instance.IsElementVisible(By.XPath("//select[@id='monthPattern_0']"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("10/30/20");

                    IWebElement webElement5a = Driver.Instance.FindElement(By.XPath("//input[@id='endDateRecur']"));
                    webElement5a.SendKeys(Keys.Tab);
                    Driver.GetElement(By.Id("monthPattern_0")).ClickWithSpace();  ////*[@id="monthPattern_0"]
                    Driver.select(By.XPath("//div[@id='divMonthlyOption_0']/div/select"), "First");
                    webElement5a.SendKeys(Keys.Tab);
                    break;

                case "Annually":
                    Driver.Instance.IsElementVisible(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//button[@class='btn dropdown-toggle btn-default']"));
                    Driver.clickEleJs(By.XPath("//span[contains(.,'Annually')]"));
                    //  Driver.Instance.selectDropdownValue(By.XPath("//button[@class='btn dropdown-toggle btn-default']"), "Annually");
                    Driver.Instance.IsElementVisible(By.XPath("//input[@id='endDateRecur']"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='endDateRecur']")).SendKeysWithSpace("10/30/22");

                    IWebElement webElement6 = Driver.Instance.FindElement(By.XPath("//input[@id='endDateRecur']"));
                    webElement6.SendKeys(Keys.Tab);

                    break;
                   
            }
        }

        public static void ClickSelectLocationButton()
        {
            Driver.clickEleJs(By.Id("location_0"));
        }

        public static bool? SelectLocationModaldisplay()
        {
           // Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return Driver.existsElement(By.XPath("//div[@id='setLocation']/div/div/div/h4"));
        }

        public static void EnterStartDateAndTime(string v)
        {
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys(v);
        }

        public static void EnterEndDateAndTime(string v)
        {
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).SendKeys(v);
        }

        public static void ClickSelectInstructorButton()
        {
            Driver.clickEleJs(By.XPath("//div[3]/button"));


        }

        public static bool? SelectInstructorModaldisplay()
        {
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return Driver.existsElement(By.XPath("//div[@id='setInstructor']/div/div/div/h4"));
        }

        public static bool? LocationAdded()
        {
            return Driver.existsElement(By.Id("removeLocation_0"));
        }

        public static void SelectLocation()
        {
            Driver.clickEleJs(By.XPath("//button[@id='location_0']"));
            Driver.clickEleJs(By.XPath("//button[@id='locationsearch"));
            Driver.clickEleJs(By.XPath("//td/input"));
            Driver.clickEleJs(By.XPath("//button[@id='btnSet']"));
            
        }

        public static void SelectInstructor()
        {
            Driver.clickEleJs(By.XPath("//button[@id='instructor_0']"));
            Driver.clickEleJs(By.XPath("//button[@id='instructorsearch']"));
            Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
            Driver.clickEleJs(By.XPath("//button[@id='btnSetInstructor']"));
            Driver.Instance.IsElementVisible(By.XPath("//li[@class='clearfix margin-bottom-sm']"));
        }

        public static void Select_Specific_Instructor(string s)
        {
            Driver.clickEleJs(By.XPath("//button[@id='instructor_0']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_instructorName']")).SendKeysWithSpace(s);
            Driver.clickEleJs(By.XPath("//button[@id='instructorsearch']"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
            Driver.clickEleJs(By.XPath("//button[@id='btnSetInstructor']"));
            Thread.Sleep(5000);
            Driver.existsElement(By.XPath("//li[@class='clearfix margin-bottom-sm']"));
        }

        public static void Enable_AccessKeys()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucAccessCodes_lnkEdit']"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_FormView1_CNT_ENABLE_ACCESS_CODE_0']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Thread.Sleep(2000);
        }

        public static void SetAccessKeys_Custom()
        {
            Driver.clickEleJs(By.XPath("//fieldset/div/label[2]"));

        }

        public static void Set_Cost()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucCost_lbEdit']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeysWithSpace("5");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
            Thread.Sleep(2000);
        }

        public static void Set_LearnerAttendance_toYES()
        {
            Driver.clickEleJs(By.XPath("//a[@data-name='attendance']"));
            Driver.Instance.GetElement(By.XPath("//div[@class='xeditable-input']/select")).Click();
            Driver.Instance.GetElement(By.XPath("//option[@value='T']")).Click();
          //  Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Yes')]"));

        }

        public static void Set_LearnerAttendance_toNo()
        {
            Driver.clickEleJs(By.XPath("//a[@data-name='attendance']"));
            Driver.Instance.GetElement(By.XPath("//div[@class='xeditable-input']/select")).Click();
            Driver.Instance.GetElement(By.XPath("//option[@value='F']")).Click();
            Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'No')]"));

        }

        public static bool Set_Progress_To_NoShow()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//table/tbody/tr/td[3]/a"));
                Driver.Instance.GetElement(By.XPath("//select[@class='form-control input-sm']")).Click();
                Driver.Instance.GetElement(By.XPath("//option[contains(.,'No Show')]")).Click();
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'No Show')]"));
                Thread.Sleep(2000);
                //    Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-dismissible alert-fixed alert-success']"));
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;

        }

        public static bool Set_Progress_To_Completed()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//table/tbody/tr/td[3]/a"));
                Driver.Instance.GetElement(By.XPath("//select[@class='form-control input-sm']")).Click();
                Driver.Instance.GetElement(By.XPath("//option[contains(.,'Completed')]")).Click();
                Driver.clickEleJs(By.XPath("//button[contains(.,'OK')]"));
                Driver.Instance.IsElementVisible(By.XPath("//td[contains(.,'Completed')]"));
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;

        }

        public static void ClickViewasLearner()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static bool? ExportToExcel()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Export to Excel')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Export to Excel')]"));
                Driver.Instance.SwitchWindow("Meridian Global Reporting");

                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public static bool? PringtSighInSheet(String s)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[@id='action_DropDownBtn']"));
                Driver.clickEleJs(By.XPath("//a[@data-bind='click: PrintSignIn']"));
                Driver.Instance.SwitchWindow("Home Page - Mozilla Firefox");
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Print')]"));
                Driver.clickEleJs(By.XPath("//a[contains(.,'Close Window')]"));


                //Driver.Instance.IsElementVisible(By.XPath("//strong[contains(.,'"+s+"')]"));
                //Driver.Instance.Close();
                //Driver.Instance.SwitchtoDefaultContent();
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? Set_Score()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Update')]"));
                Driver.clickEleJs(By.XPath("//a[contains(text(),'Update')]"));
                Driver.Instance.GetElement(By.XPath("//input[@type='text']")).Clear();
                Driver.Instance.GetElement(By.XPath("//input[@type='text']")).SendKeysWithSpace("99.99");
                Driver.clickEleJs(By.XPath("//button[@type='submit']"));
                Thread.Sleep(2000);
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'99.99')]"));
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public static bool? Filter_User()
        {
            bool result = false;
            try
            {
                Driver.Instance.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace("xyzxyzxyz");
                Driver.clickEleJs(By.XPath("//div[@id='gradebookToolbar']/div/div/div/div/span/button/span"));
                Driver.Instance.GetElement(By.XPath("//input[@id='searchFor']")).Clear();
                Driver.Instance.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace("");
                Driver.clickEleJs(By.XPath("//div[@id='gradebookToolbar']/div/div/div/div/span/button/span"));
                Driver.Instance.IsElementVisible(By.XPath("//td[contains(text(),'Completed')]"));
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public static bool Create_Assignment(String s)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//div[2]/div/div/a[2]"));
                Driver.clickEleJs(By.XPath("//div[2]/div/div/div/div[1]/div/div[2]/div/div/ul/li[1]/a"));
                Driver.Instance.GetElement(By.XPath("//input[@id='title']")).SendKeysWithSpace(s);
                Driver.clickEleJs(By.XPath("//button[contains(.,'Next')]"));
                Driver.clickEleJs(By.XPath("//button[@data-bind='click: save, enable: valid']"));
                Thread.Sleep(3000);
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'" + s + "')]"));
                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? InstructorAdded()
        {
            return Driver.existsElement(By.Id("valueInstructors_0"));
        }

        public static void removeinstructors()
        {
            if (Driver.existsElement(By.XPath("//ul[@id='valueInstructors_0']/li[2]/a")))
            {
                Driver.GetElement(By.XPath("//ul[@id='valueInstructors_0']/li[2]/a")).ClickWithSpace();
            }
            if (Driver.existsElement(By.XPath("//ul[@id='valueInstructors_0']/li/a")))
            {
                Driver.clickEleJs(By.XPath("//ul[@id='valueInstructors_0']/li/a"));
            }
            //if (Driver.existsElement(By.XPath("//div[2]/div[3]/ul/li[2]/a")))
            //{
            //    Driver.clickEleJs(By.XPath("//div[2]/div[3]/ul/li[2]/a"));
            //}
        }

        public static bool? Remove_Content()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//table[@id='table-material']/thead/tr/th/div/input"));
                Driver.clickEleJs(By.XPath("//span[@class='fa fa-trash']"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-remove-content']"));
                Driver.Instance.IsElementVisible(By.XPath("//p[@class='text-center']/strong[contains(text(),'No content has been added')]"));
                result = true;
            }catch(Exception e)
            {

            }
            return result;
        }

        public static bool? Verify_SectionDetilPage()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_FormView1_lnkEdit']"));
                Driver.Instance.IsElementVisible(By.XPath("//input[@disabled='disabled']"));
                //Driver.Instance.IsElementVisible(By.XPath(""));
                result = true;
            }catch(Exception e)
            {

            }
            return result;
            
        }

        public static bool? Remove_Event(string s)
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'"+s+"')]"));
                Driver.clickEleJs(By.XPath("//input[contains(@id,'btSelectAll')]"));
                Driver.clickEleJs(By.XPath("//span[@class='fa fa-trash']"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-delete-ok']"));
                Driver.Instance.IsElementVisible(By.XPath("//td[contains(text(),'No matching records found')]"));

                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? Add_Content()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//div[@class='btn-group']//a[@class='btn btn-primary'][contains(text(),'Add Content')]"));
                Driver.clickEleJs(By.XPath("//div[@class='btn-group']//a[@class='btn btn-primary'][contains(text(),'Add Content')]"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-search-content']//span[@class='fa fa-search']"));
                Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-add']"));
                Driver.Instance.IsElementVisible(By.XPath("//input[@data-index='0']"));

                result = true;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public static bool? Grade_Individual_Assignment()
        {
            bool result = false;
            try
            {
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='gradebookToolbar']/div/div/div[2]/div/label"));
                Driver.Instance.IsElementVisible(By.XPath("//div[@id='gradebookToolbar']/div/div/div[2]/div/label[2]"));
                Driver.clickEleJs(By.XPath("//div[@id='gradebookToolbar']/div/div/div[2]/div/label[2]"));
                Driver.clickEleJs(By.XPath("//table[@id='table-gradebook']/tbody/tr/td[5]/a"));
                Driver.Instance.selectDropdownValue(By.XPath("//select[@class='form-control input-sm']"), "Pass");
             //   Driver.Instance.GetElement(By.XPath("//select[@class='form-control input-sm']")).Click();
           //     Driver.clickEleJs(By.XPath("//option[@value='ML.BASE.Pass']"));
                Driver.Instance.IsElementVisible(By.XPath("//td/a[contains(text(),'Pass')]"));

                result = true;
            }catch(Exception e)
            {

            }
            return result;
        }

        public static void SetEnrollmentStartDate(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='enrollmentStartDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='enrollmentStartDate']")).SendKeys(v);

        }

        public static void SwitchtoLearner()
        {
            Driver.clickEleJs(By.Id("MainContent_header_FormView1_btnStatus"));
        }

        public static void ClickSectionTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_hlNewSection']"));
        }

        public static void Click_ContentTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_SectionHeaderTabs_lnkContent']"));
        }

        public static string add_AnotherEvent(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='addEventBtn']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='eventTitle_1']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='eventTitle_1']")).SendKeysWithSpace(v+"_2ndEvent");
            IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@id='eventTitle_1']"));
            webElement.SendKeys(Keys.Tab);
            return v + "_2ndEvent";
        }

        public static void BackatTheSectionsPage()
        {
            Driver.clickEleJs(By.Id("MainContent_ucContentInfo1_FormView1_backButton"));
        }
    }

    public class InstructorCalendarModalCommand
    {
        public bool? VerifyPersonalDaysDisplayed(DateTime today, string createdEvent)
        {
            return Driver.existsElement(By.XPath("//div[@class='cal-month-day cal-day-inmonth cal-day-today']//a[@data-original-title='"+ createdEvent + "']"));
        }
    }
}

public class SectionsPageCommand
{
    public SectionsPageCommand()
    {
    }

    public bool? ListofSections { get { return Driver.existsElement(By.XPath("//li/div/div/div/div/h3/a")); } }
}

public class SelectLocationModalCommand
{
    public SelectLocationModalCommand()
    {
    }

    public LocationCalenderModalModal LocationCalenderModal { get { return new LocationCalenderModalModal(); } }
    public object SearchLocation { get; internal set; }

    public void Addlocation()
    {
        Driver.clickEleJs(By.XPath("//table[@id='locations']/tbody/tr/td/input"));
        Driver.clickEleJs(By.Id("btnSet"));
    }

    public void ClickLocationRadioButton()
    {
        Driver.clickEleJs(By.XPath("//table[@id='locations']/tbody/tr/td/input"));
    }

    public void ClickSet()
    {
        Driver.clickEleJs(By.Id("btnSet"));
    }

    public void ClickViewSchedule()
    {
        Driver.clickEleJs(By.Id("location_0"));
        //Thread.Sleep(2000);
    }

    public void CloseModal()
    {
        Driver.clickEleJs(By.XPath("//div[@id='setLocation']/div/div/div/button/span"));
    }
}

public class LocationCalenderModalModal
{
    public LocationCalenderModalModal()
    {
    }

    public void CloseModal()
    {
        Driver.clickEleJs(By.XPath("//div[@id='showCalendar']/div/div/div/button/span"));

    }

    public bool? ModalisDisplay()
    {
        if (Driver.existsElement(By.Id("location_0")))
        {
            Driver.clickEleJs(By.Id("location_0"));
        }
        //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        return Driver.existsElement(By.XPath("//div[@id='setLocation']/div/div/div/h4"));
    }
}

public class SelectInstructorModalCommand
{
    public SelectInstructorModalCommand()
    {
    }

 //   public bool? ViewScheduleButton { get { return Driver.existsElement(By.XPath("//a[contains(text(),'View Schedule')]")); } }

    public void SearchInstructor(string v)
    {
        if (!v.Equals(null))
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_instructorName"));
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_instructorName")).Clear();
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_instructorName")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("instructorsearch"));

        }
        else
        {
            Driver.clickEleJs(By.Id("instructorsearch"));
        }
    }

    public void ClickViewScheduleButton()
    {
        Driver.clickEleJs(By.XPath("//table[@id='instructors']/tbody/tr/td[5]/a"));
    }

    public bool? InstructorCalendarModaldisplay()
    {
        Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        return Driver.existsElement(By.XPath("//span[@id='calendarModalTitle']"));
    }

    public void CloseInstructorCalendarModal()
    {
        Driver.clickEleJs(By.XPath("//div[@id='showCalendar']/div/div/div/button/span"));
    }

    public void CloseInstructorModal()
    {
        Driver.clickEleJs(By.XPath("//div[@id='setInstructor']/div/div/div/button/span"));
    }

    public void SelectandClickSet()
    {
        Driver.existsElement(By.XPath("//table[@id='instructors']/tbody/tr/td/input"));
        Driver.clickEleJs(By.XPath("//table[@id='instructors']/tbody/tr/td/input"));
        Driver.clickEleJs(By.Id("btnSetInstructor"));

    }

    public bool? ViewScheduleButton()
    {
        return Driver.existsElement(By.XPath("//table[@id='instructors']/tbody/tr[1]/td[5]/a[1]"));
    }

    public bool? InstructorAvailability(string v)
    {
        return Driver.GetElement(By.XPath("//table[@id='instructors']/tbody/tr/td[4]/span")).Text.Contains(v);
    }
}

public class SectionsdropdownCommand
{
    public SectionsdropdownCommand()
    {
    }

    public bool? ManageWaitlistdisplay()
    {
        Driver.clickEleJs(By.XPath("//div[2]/div/div/button/span"));
        return Driver.GetElement(By.LinkText("Manage Enrollment")).Displayed;
    }

    public bool? WaitlistUsersdisplay()
    {
        return Driver.GetElement(By.LinkText("Manage Waitlist")).Displayed;
    }

    public void SelectManageoption(string v)
    {
        Driver.existsElement(By.XPath("//div[2]/div/div/button"));
        Driver.clickEleJs(By.XPath("//div[2]/div/div/button"));
        //Thread.Sleep(2000);
        Driver.selectdropdown(By.XPath("//*[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li/div[1]/div[2]/div/div/ul"), v);
    }

    public void OpenDropdown()
    {
       // Driver.Instance.WaitForElement(By.XPath("//div[2]/div/div/button"));
        Driver.clickEleJs(By.XPath("//div[2]/div/div/button"));
        Thread.Sleep(2000);
    }

    public bool? ManageWaitlist(String v)
    {
        return Driver.Instance.selectOptionVisibility(By.XPath("//div[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li/div/div[2]/div/div/ul"), v);
    }

    public void CopySection()
    {
        Driver.clickEleJs(By.LinkText("Copy Section"));
    }
}

public class BatchEnrollUserModalCommand
{
    public BatchEnrollUserModalCommand()
    {
    }

    public void EnrollUser(string v)
    {
        Driver.existsElement(By.Id("SEARCH_FOR"));
        //Driver.GetElement(By.Id("SEARCH_FOR")).Clear();
        Driver.GetElement(By.Id("SEARCH_FOR")).SendKeysWithSpace(v);
        Driver.clickEleJs(By.XPath("//button[@id='btnSearchClientSide']/span"));
        //   Driver.existsElement(By.Id("enroll_user_ML.BASE.USR.User"));
        Thread.Sleep(5000);
        Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr/td/input"));
        Driver.clickEleJs(By.Id("btnEnrollUsers"));
        //Thread.Sleep(5000);
    }

    public void SearchUserandEnrollbatch(string v)
    {
        Driver.GetElement(By.Id("SEARCH_FOR")).Clear();
        Driver.GetElement(By.Id("SEARCH_FOR")).SendKeysWithSpace(v);
        Driver.clickEleJs(By.XPath("//button[@id='btnSearchClientSide']/span"));
        Driver.existsElement(By.Id("enroll_user_ML.BASE.USR.User"));
        Thread.Sleep(5000);
        Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr/td/input"));
        //Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr[2]/td/input"));
        //Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr[3]/td/input"));
        Driver.clickEleJs(By.Id("btnEnrollUsers"));
    }

    public void EnrollUser_MultipleUsers(string v)
    {
        Driver.GetElement(By.Id("SEARCH_FOR")).Clear();
        Driver.GetElement(By.Id("SEARCH_FOR")).SendKeysWithSpace(v);
        Driver.clickEleJs(By.XPath("//button[@id='btnSearchClientSide']/span"));
        Driver.existsElement(By.Id("enroll_user_ML.BASE.USR.User"));
        Thread.Sleep(5000);
        Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr/td/input"));
        Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr[2]/td/input"));
        Driver.clickEleJs(By.XPath("//table[@id='tableEnrollUsers']/tbody/tr[3]/td/input"));
        Driver.clickEleJs(By.Id("btnEnrollUsers"));
    }
}

public class EnrollmenttabCommand
{
    public EnrollmenttabCommand()
    {
    }

    public void ClickEnroll()
    {
        Driver.clickEleJs(By.XPath("(//button[@type='button'])[6]"));
    }

    public void SearchEnrolledUser(string v)
    {
        Driver.GetElement(By.Id("enrollmentSearch")).SendKeysWithSpace(v);
        Driver.clickEleJs(By.Id("btnSearchEnrollmentTabs"));
        Thread.Sleep(2000);
    }

    public string AttendanceRequiredStatusForEnrolledUser()
    {
        Thread.Sleep(3000);
        return Driver.GetElement(By.XPath("//table[@id='enrolled-grid']/tbody/tr/td[4]/a")).Text;
    }

    public void UpdateAttendanceRequiredfromNotoYes()
    {
        Driver.clickEleJs(By.XPath("//a[@class='xeditable xeditable-click']"));//afreen
        //Driver.clickEleJs(By.XPath("//table[@id='enrolled-grid']/tbody/tr/td[4]/a"));
        Thread.Sleep(1000);
        Driver.GetElement(By.XPath("//select[@class='form-control input-sm']")).SendKeysWithSpace("Y");//afreen


        //Driver.GetElement(By.XPath("//table[@id='enrolled-grid']/tbody/tr/td[4]/span/div/form/div/div/div/select")).SendKeysWithSpace("Y");
        //Driver.select(By.XPath("//table[@id='enrolled-grid']/tbody/tr/td[4]/span/div/form/div/div/div/select"), "Yes");
        Thread.Sleep(2000);
    }

    public void ClickWaitlistUsers()
    {
        Driver.existsElement(By.XPath("//div[@id='waitlisted']//button[@type='button'][contains(text(),'Waitlist Users')]"));
        //Driver.Instance.WaitForElement(By.XPath("//div[2]/div[2]/div/button"));
        Driver.clickEleJs(By.XPath("//div[@id='waitlisted']//button[@type='button'][contains(text(),'Waitlist Users')]"));
        //Thread.Sleep(2000);
    }

    public bool? WaitListUserModelDisplay()
    {
        return Driver.existsElement(By.XPath("//form[@id='ctl00']/div[3]/h3"));
    }

    public void EnrollwaitlistUser(string v)
    {
        Driver.GetElement(By.Id("SEARCH_FOR")).Clear();
        Driver.GetElement(By.Id("SEARCH_FOR")).SendKeysWithSpace(v);
        Thread.Sleep(5000);
        Driver.existsElement(By.XPath("//button[@id='btnSearchClientSide']/span"));
        Driver.clickEleJs(By.XPath("//button[@id='btnSearchClientSide']/span"));
        //Driver.existsElement(By.Id("enroll_user_ML.BASE.USR.User"));
        //Thread.Sleep(5000);
        Driver.clickEleJs(By.XPath("//table[@id='tableWaitlistUsers']/tbody/tr/td/input"));
        Driver.clickEleJs(By.Id("btnWaitlistUsers"));
    }

    public bool? WaitListUserCount()
    {
        String waitlistusercount = Driver.GetElement(By.XPath("//li[@id='waitlist-link']/a/span")).Text;
        int waitlistcount = Driver.getIntegerFromString(waitlistusercount);
        if (waitlistcount >= 1)
        {
            return true;
        }
        else
            return false;
    }

    public void ReservedSeatsbutton()
    {
        Driver.existsElement(By.XPath("//div[@id='panel-empty']/button"));
        Driver.clickEleJs(By.XPath("//div[@id='panel-empty']/button"));
    }

    public bool? ReserveSeatsModelDisplay()
    {
        Thread.Sleep(3000);
        return Driver.existsElement(By.XPath("//div[@id='reserve-seats']/div/h3"));
    }

    public void EnrolGrouptoReserveSeats(string v)
    {
        if (!(v == null))
        {
            Driver.GetElement(By.Id("ugSearch")).Clear();
            Driver.GetElement(By.Id("ugSearch")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[2]/div/div/div/span/button"));
            // Driver.existsElement(By.Id("enroll_user_ML.BASE.USR.User"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//table[@id='user-group-grid']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//div[@id='reserve-seats']/div[3]/button[2]"));
            Thread.Sleep(5000);
        }
        else
        {
            Driver.clickEleJs(By.XPath("//div[2]/div/div/div/span/button"));
            Driver.existsElement(By.XPath("//table[@id='user-group-grid']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//table[@id='user-group-grid']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//div[@id='reserve-seats']/div[3]/button[2]"));
            Thread.Sleep(5000);
        }
    }

    public bool? Groupdisplayintoreservetab()
    {
        return Driver.GetElement(By.XPath("//table[@id='required-grid']/tbody/tr/td[2]")).Displayed;
    }

    public void SelectAddedUserGroup()
    {
        Driver.GetElement(By.XPath("//table[@id='required-grid']/thead/tr/th/div/input")).ClickWithSpace();

    }

    public void ClickRemove()
    {
        Driver.clickEleJs(By.XPath("//button[@id='btn-remove-selected']"));
    }

    public string EnrolledUserName()
    {
        Driver.existsElement(By.XPath("//table[@id='enrolled-grid']/tbody/tr/td[2]"));
        return Driver.GetElement(By.XPath("//table[@id='enrolled-grid']/tbody/tr/td[2]")).Text;

    }
}

    public class SctionTabCommand
    {
    public SectionDetailsCommand SectionDetails { get { return new SectionDetailsCommand(); } }

    public SctionTabCommand()
        {
        }

        public void ClickManageEnrollment()
        {
            Driver.existsElement(By.LinkText("Manage Enrollment"));
            Driver.clickEleJs(By.LinkText("Manage Enrollment"));
        }

        public void ClickonCompleteCheckBox()
        {
            Driver.Instance.WaitForElement(By.XPath("//div[@id='panel_END_DATE']/div/ul/li/label"));
            Driver.clickEleJs(By.XPath("//div[@id='panel_END_DATE']/div/ul/li/label"));
            Thread.Sleep(2000);
        }

    public void ClickDetails(string v)
    {
        Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]/following::button[2]"));
        Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]/following::button[2]"));
    }

    public bool? VerifySection2Expanded()
    {
        return Driver.existsElement(By.XPath("//li[2]/div[2]/div/div/div"));
    }

  

    public bool? VerifySection2EnrollmentAndSectionDates(string SectionStartDate)
    {
        string EnrollmentDate = Driver.GetElement(By.XPath("//li[2]/div[2]/div/div/div/ul/li[2]/dl/dd")).Text.Substring(1, 9);
        if (EnrollmentDate == SectionStartDate)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    public bool? VerifySection2EnrollmentAndSectionDatesDifferent(string SectionStartDate)
    {
        string EnrollmentDate = Driver.GetElement(By.XPath("//li[2]/div[2]/div/div/div/ul/li[2]/dl/dd")).Text.Substring(1, 9);
        if (EnrollmentDate != SectionStartDate)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    public bool? VerifyEventScheduleTextforSection(string v)
    {
        return Driver.GetElement(By.XPath("//div[@id='MainContent_pnlMVCSection']/div[2]/div[2]/ul[2]/li/div/div/div/div/ul/li[2]")).Text.Contains(v);
    }

    public void ClickaddaNewSection()
    {
        Driver.existsElement(By.XPath("//a[@id='add-section']"));
        Driver.clickEleJs(By.XPath("//a[@id='add-section']"));
    }
}

public class SectionDetailsCommand
{
    public SectionDetailsCommand()
    {
    }

    public string EnrollmentStartDate()
    {
        return Driver.GetElement(By.XPath("//dd[@data-bind='text: $parent.formatEnrollmentPeriod($data)']")).Text.Substring(2, 9);
    }
}

public class CreateSctionCommand
    {
        private string v;

        public CreateSctionCommand()
        {

        }

        public void TitleAs(string v)
        {
            Driver.existsElement(By.Id("section-title"));
            Driver.GetElement(By.Id("section-title")).Clear();
            Driver.GetElement(By.Id("section-title")).SendKeysWithSpace(v);
           // Thread.Sleep(2000);


        }
       

    public object SectionEndTime(string v)
    {
        return this.v = v;
    }

    


        public void SectionMinCapacity(string v)
        {
            throw new NotImplementedException();
        }

        public void SectionMaxCapacity(string v)
        {
            //Driver.GetElement(By.Id("maxCapacity")).Clear();
            Driver.GetElement(By.Id("maxCapacity")).Clear();
            Driver.GetElement(By.Id("maxCapacity")).SendKeysWithSpace(v);
           // Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//h3[contains(.,'Enrollment')]"));
            Driver.Instance.IsElementVisible(By.XPath("//a[@class='addNotes']"));
            //Driver.clickEleJs(By.XPath("//a[@class='addNotes']"));
            //Driver.clickEleJs(By.XPath("//div[@id='enrollmentBlock']/div[2]"));

            //int numVal = Int32.Parse(v);
            //for(int i=0;i<numVal;i++)
            //{
            //    Driver.GetElement(By.Id("maxCapacity")).ClickWithSpace();
            //    Driver.GetElement(By.Id("maxCapacity")).SendKeysWithSpace(i.ToString());
            //    i++;
            //}

        }

        public void Create()
        {
           // Thread.Sleep(3000);
            Driver.existsElement(By.XPath("//button[@id='btnCreate']"));
            Driver.clickEleJs(By.XPath("//button[@id='btnCreate']"));
            Thread.Sleep(5000);


        }

        public void ClickAddaNewSection()
        {
            Driver.existsElement(By.LinkText("Add a New Section"));
            Driver.clickEleJs(By.LinkText("Add a New Section"));
            //Thread.Sleep(2000);

        }

        public void UseWaitlistasYes()
        {
        Driver.clickEleJs(By.XPath("//div[3]/div/div/span[3]"));
        }
    public void AddInstructorToSection()
    {
        Driver.clickEleJs(By.XPath("//button[contains(.,'Select Instructor')]"));
        Driver.clickEleJs(By.Id("btSelectItem_ML.BASE.USR.Administrator"));
        Driver.clickEleJs(By.Id("btnSetInstructor"));
    }
        public void SetEnrollmentStartsDate(int i)
        {
            string format = "M/dd/yyyy";
            string startdate = DateTime.Now.AddDays(-i).ToString(format);
            startdate = startdate.Replace("-", "/");
        IWebElement webElement = Driver.Instance.FindElement(By.Id("enrollmentStartDate"));
       
        Driver.existsElement(By.Id("enrollmentStartDate"));
        webElement.Clear();
        webElement.SendKeysWithSpace(startdate);
        webElement.SendKeys(Keys.Tab);
      //  Driver.Instance.GetElement(By.Id("enrollmentStartDate")).Clear();
      //      Driver.Instance.GetElement(By.Id("enrollmentStartDate")).SendKeysWithSpace(startdate);
            Thread.Sleep(3000);
            Driver.clickEleJs(By.XPath("//div[@id='enrollmentBlock']/div[2]/div/div[3]/div/div/span[3]"));
            //Driver.clickEleJs(By.Id("minCapacity"));

        }

    public void SectionStartTime(string v)
    {
        Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
        Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys("01/19/2019 5:30 PM");
    }

    public void SectionStartDate(int v)
    {
        string format = "M/dd/yyyy";
        string startdate = DateTime.Now.AddDays(-v).ToString(format);
        startdate = startdate.Replace("-", "/");
        Driver.Instance.GetElement(By.Id("startDate")).Clear();
        Driver.Instance.GetElement(By.Id("startDate")).SendKeysWithSpace(startdate);
        Thread.Sleep(3000);
        Driver.clickEleJs(By.XPath("//div[@id='enrollmentBlock']/div[2]/div/div[3]/div/div/span[3]"));
    }

    public void SectionEndDate(int v)
    {
        string format = "M/dd/yyyy";
        string startdate = DateTime.Now.AddDays(-v).ToString(format);
        startdate = startdate.Replace("-", "/");
       
        Driver.Instance.GetElement(By.Id("endDate")).Clear();
        Driver.Instance.GetElement(By.Id("endDate")).SendKeysWithSpace(startdate);
        Thread.Sleep(3000);
        Driver.clickEleJs(By.XPath("//div[@id='enrollmentBlock']/div[2]/div/div[3]/div/div/span[3]"));
    }

    public void SetEnrollmentEndDate(int v)
    {
        string format = "M/dd/yyyy";
        string startdate = DateTime.Now.AddDays(v).ToString(format);
        startdate = startdate.Replace("-", "/");
        Driver.Instance.GetElement(By.Id("enrollEndDate")).Clear();
        Driver.Instance.GetElement(By.Id("enrollEndDate")).SendKeysWithSpace(startdate);
        Thread.Sleep(3000);
        Driver.clickEleJs(By.XPath("//div[@id='enrollmentBlock']/div[2]/div/div[3]/div/div/span[3]"));
    }

    public void SectionCode(string sectionCode)
    {
        Driver.GetElement(By.XPath("//input[@id='section-code']")).SendKeysWithSpace(sectionCode);
    }
}
   

