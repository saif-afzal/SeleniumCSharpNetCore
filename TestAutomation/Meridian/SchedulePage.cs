using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class SchedulePage
    {
        public  static ScheduleTabCommand ScheduleTab
        {
            get { return new ScheduleTabCommand(); }
        }

        public static bool? ScheduleTabisvisible()
        {
            Thread.Sleep(10000);
            return Driver.existsElement(By.LinkText("Schedule"));
        }

        public static void ClickScheduleTab()
        {
            Driver.clickEleJs(By.LinkText("Schedule"));
        }
    }

    public class ScheduleTabCommand
    {
        public bool? BacktoSectionsButton
        {
            get { return Driver.existsElement(By.Id("MainContent_MainContent_UC1_BackToSections")); }
        }
        public bool? CreateNewEventButton
        {
            get { return Driver.existsElement(By.XPath("//a[@id='MainContent_MainContent_UC1_CreateEvent']")); }
        }

        public EventTitlecolumnCommand EventTitlecolumn
        {
            get { return new EventTitlecolumnCommand(); }
        }

        public InstructorscolumnCommand Instructorscolumn
        {
            get { return new InstructorscolumnCommand(); }
        }

        public LocationcolumnCommand Locationcolumn {
            get { return new LocationcolumnCommand(); }
        }

        public NotescolumnCommand Notescolumn
        {
get { return new NotescolumnCommand(); }
        }

        public SchedulecolumnCommand Schedulecolumn
        {
            get { return new SchedulecolumnCommand(); }
        }

      

        public IEnumerable VerifyBacktoSectionsButton()
        {
            string[] sarray = new string[] { "a", "b", "c" };
            return sarray;
        }

        public void ClickCreateNewEvent()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_CreateEvent"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_CreateEvent"));
        }
    }

    public class NotescolumnCommand
    {
        public bool ReadNotesButton
        {
            get { return Driver.existsElement(By.LinkText("Read Notes")); }
        }

        public bool? IsNotesColumnDisplay()
        {
            return Driver.existsElement(By.XPath("//table[@id='events-schedule']/thead/tr/th[6]/div"));
        }
    }

    public class LocationcolumnCommand
    {
        public string Locations
        {
            get { return Driver.GetElement(By.XPath("//table[@id='events-schedule']/tbody/tr/td[4]")).Text; }
        }

        public bool? Locationscolumn()
        {
            return Driver.existsElement(By.XPath("//table[@id='events-schedule']/thead/tr/th[4]/div"));
        }
    }

    public class InstructorscolumnCommand
    {
        public string Instructors
        {
            get { return Driver.GetElement(By.XPath("//table[@id='events-schedule']/tbody/tr/td[3]")).Text; }
        }

        public bool? Instructorscolumn()
        {
            return Driver.existsElement(By.XPath("//table[@id='events-schedule']/thead/tr/th[3]/div"));
        }
    }

    public class SchedulecolumnCommand
    {
        public string EventStartEndDateTime
        {
          
            get { return Driver.GetElement(By.XPath("//table[@id='events-schedule']/tbody/tr/td[2]")).Text;  }
        }

        public bool? EventStartEndDatecolumn()
        {
            return Driver.existsElement(By.XPath("//table[@id='events-schedule']/thead/tr/th[2]/div"));
        }
    }

    public class EventTitlecolumnCommand
    {
        public string Value
        {
            
            get {
              return  Driver.GetElement(By.XPath("//table[@id='events-schedule']/tbody/tr/td/a")).Text;
               }
        }

        public void ClickEventTitle(string text)
        {
            Driver.clickEleJs(By.XPath("//table[@id='events-schedule']/tbody/tr/td/a"));
        }

        public bool? EventTitleText()
        {
            return Driver.existsElement(By.XPath("//table[@id='events-schedule']/tbody/tr/td/a"));
        }
    }
}