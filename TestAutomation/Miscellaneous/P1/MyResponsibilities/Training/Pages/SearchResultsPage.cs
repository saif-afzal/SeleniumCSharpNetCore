using OpenQA.Selenium;
using ParallelTesting_Solution2;
using Selenium2.Meridian.Suite;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
//using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Collections.Generic;
using System.Threading;
using TestAutomation.helper;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class SearchResultsPage:ObjectInit
    {
        private IWebDriver objDriver;
        public SearchResultsPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  SearchedRecordCommand SearchedRecord
        {
            get { return new SearchedRecordCommand(objDriver); }
        }

        public  ListofSearchResultsCommand ListofSearchResults
        {
            get { return new ListofSearchResultsCommand(objDriver); }
        }

        public  ContentTagsFacetCommand ContentTagsFacet { get { return new ContentTagsFacetCommand(); } }

        public  SelectedTagsAboveSearchResultsCommand SelectedTagsAboveSearchResults { get { return new SelectedTagsAboveSearchResultsCommand(); } }

        public  CreditTypesFacetCommand CreditTypesFacet { get { return new CreditTypesFacetCommand(); } }

        public  ContentTypeFacetCommand ContentTypeFacet
        {
            get { return new ContentTypeFacetCommand(objDriver); }
        }

        public  CalendarCommand Calendar
        {
            get { return new CalendarCommand(objDriver); }
        }

        public  AICCSeachListCommand AICCSeachList { get { return new AICCSeachListCommand(objDriver); } }

        public  int CheckSearchRecord(string title)
        {
            Thread.Sleep(5000);

           objDriver.existsElement(By.XPath("//em[contains(.,'"+title+"')]/preceding::strong"));
          return  objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//em[contains(.,'"+title+"')]/preceding::strong")).Text);
           
           
        }

        public  void ClickCourseTitle(string v)
        {
            if (v == "CRCTitle1910293729TC27023_NewEnroll")
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'CRCTitle1910293729TC27023_NewEnroll')]")); 
            }
            else if(v==null)
            {
                objDriver.ClickEleJs(By.XPath("//li/div/div/h3/a"));
            }
            else if (v == "")
            {
                Meridian_Common.SearchResultTitle = objDriver.gettextofelement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div[2]/div/div/div/h3/a"));
                Meridian_Common.SearchResultTitle = Meridian_Common.SearchResultTitle.Substring(0, 9);
                if (!objDriver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/h3/a")))
                {
                    objDriver.ClickEleJs(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div[2]/div/div/div/h3/a"));
                }
                else
                {
                    objDriver.ClickEleJs(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/h3/a"));
                }
            }
            else 
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
                //objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]"));
            }

        }
        public  string ReturnFirstRecordTitle()
        {
            objDriver.existsElement(By.XPath(".//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[1]/h3/a"));
          return  objDriver.GetElement(By.XPath(".//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[1]/h3/a")).Text;
        }
        public  string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }

        public  object Search(string v)
        {
            throw new NotImplementedException();
        }

        public  bool MatchRecord(string v)
        {
            throw new NotImplementedException();
        }

        public  string VerifyCourseTitleText(string v)
        {
            objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/h3/a"));
            return objDriver.GetElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/h3/a")).Text;
        }

        public  string VerifyTextCredits(string v)
        {
            return objDriver.GetElement(By.XPath("//*[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div[2]/div/ul/li[2]")).Text;

        }

        public  void NavigateLastSearchResultPage()
        {
            objDriver.ClickEleJs(By.XPath("//*[@id='MGSearchResults']/div[2]/div[2]/div[1]/div/div[2]/nav/ol/li[5]/a/span"));
        }

        public  bool? IsContentImageDisplay()
        {
            return objDriver.GetElement(By.XPath("//*[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div[1]")).GetAttribute("style").Contains(".jpg");
        }

        public  bool? VerifyFacetSelected(string v)
        {
            objDriver.existsElement(By.CssSelector("span.text-group-addon"));
           return objDriver.GetElement(By.CssSelector("span.text-group-addon")).Text == v;
        }

        public  void ClickFirstCourseTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/h3/a"));
        }

        public  bool? isSearchResultDisplayed(string v)
        {
            return objDriver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
        }

        public  bool? isSearchResultListDisplayed(string v)
        {
            string Records = string.Empty;
           Records= objDriver.GetElement(By.XPath("//strong[@data-bind='formatText: [total]']")).Text;

            int Rec = 0;
            int linktitle = 0;
            Rec = objDriver.getIntegerFromString(Records);
            linktitle = objDriver.countelements(By.CssSelector("h3.results-heading"));
            if (Rec>=1&linktitle>=1)
            {
                return true;
                            }
            else
            {
                return false;
            }
            
        }

        public  bool? isMakeAContentSuggestionDisplayed()
        {
            return objDriver.GetElement(By.Id("lnkInterest")).Displayed;
        }

        public  void ClickMakeAContentSuggestion()
        {
            objDriver.ClickEleJs(By.Id("lnkInterest"));
           // objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }

        public  bool? isExpressInterestWindowDisplayed()
        {
            return objDriver.existsElement(By.Id("KendoUIMGDialog_wnd_title"));
           
        }

        public  bool? isfeedbackDisplayed()
        {
            throw new NotImplementedException();
        }

        public  void ClickCalendarButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='hlClassroomCalendarView']//span[@class='fa fa-calendar']"));

        }

        public  bool? verifyPrintWindowOpensDisplayingProperFormat()
        {
            throw new NotImplementedException();
        }

        public  void ClickFirstTitle()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div/div[2]/div/div/div/h3/a"));

        }

        public  void Login()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='login']"));
        }
    }

    public class AICCSeachListCommand
    {
        private IWebDriver objDriver;
        public AICCSeachListCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? isContentTypeDefaultFormat()
        {
            return objDriver.GetElement(By.XPath("//div[@id='panel_DF_FORMAT_ID']/div/ul/li/label")).Text.Contains("File");
        }
    }

    public class CalendarCommand
    {
        private IWebDriver objDriver;
        public CalendarCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? isDisplayed()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Displayed;
        }

        public bool? isDisplayingCurrentMonth()
        {
            return objDriver.matchmonth(By.XPath("//h3[@id='calendar-title']"));

        }

   

   

        public bool? isTodayLinkDisplayed()
        {
            return objDriver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/button")).Displayed;
        }

        public bool? isYearLinkDisplayed()
        {
            return objDriver.GetElement(By.XPath("//button[contains(text(),'Year')]")).Displayed;
        }

        public bool? isMonthLinkDisplayed()
        {
            return objDriver.GetElement(By.XPath("//button[contains(text(),'Month')]")).Displayed;
        }

        public bool? isWeekLinkDisplayed()
        {
            return objDriver.GetElement(By.XPath("//button[contains(text(),'Week')]")).Displayed;
        }

        public bool? isDayLinkDisplayed()
        {
            return objDriver.GetElement(By.XPath("//button[contains(text(),'Day')]")).Displayed;
        }

        public bool? isPrintButtonDisplayed()
        {
            return objDriver.GetElement(By.XPath("//a[@id='MainContent_UC1_lnkPrint']/span")).Displayed;
        }

        public void ClickmonthArrow()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div/button[2]/i"));
            //objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div/button[2]/i"));
            //objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div/button[2]/i"));
            //objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div/button[1]/i"));
            //objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div/button[1]/i"));
            //objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/div/button[1]/i"));

        }

        public bool? isCalendarShowingnextMOnth()
        {
            throw new NotImplementedException();
        }

        public void ClickYearLink()
        {
            objDriver.ClickEleJs(By.XPath("//button[contains(text(),'Year')]"));
        }

        public void ClickTodayButton()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/button"));
        }

        public bool? VerifyITDisplayAllMonths()
        {
            throw new NotImplementedException();
        }

        public void ClickMonthLink()
        {
            throw new NotImplementedException();
        }

        public bool? VerifyITDisplayWholeMonth()
        {
            throw new NotImplementedException();
        }

        public void ClickWeekLink()
        {
            throw new NotImplementedException();
        }

        public bool? VerifyITDisplayAWeek()
        {
            throw new NotImplementedException();
        }

        public void ClickDayLink()
        {
            throw new NotImplementedException();
        }

        public bool? VerifyITDisplayAWholeDay()
        {
            throw new NotImplementedException();
        }

        public void ClickClassroomCourse()
        {
            throw new NotImplementedException();
        }

        public bool? isNewFrameDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isEventTitleDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isEventLocationDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isInstructorDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isStartDateDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isEndDateDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isStartTimeDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isEndTimeDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isCancelButtonDisplaying()
        {
            throw new NotImplementedException();
        }

        public bool? isMoreInformationDisplaying()
        {
            throw new NotImplementedException();
        }

        public void ClickMoreInformationButton()
        {
            throw new NotImplementedException();
        }

        public void ClickCancelButton()
        {
            throw new NotImplementedException();
        }

        public bool? isNewFrameCloses()
        {
            throw new NotImplementedException();
        }

        public void ClickPrintButton()
        {
            throw new NotImplementedException();
        }

        public bool? VerifyCalendaronlyDisplayedOpenSectionWithOpenSeats()
        {
            throw new NotImplementedException();
        }

        public bool VerifyCalendarDisplayClassroomCourse(string v)//need to automate further
        {
            bool res = false;
            int i = 1;
            int j = 1;
            IList<IWebElement> hrow= objDriver.FindElements(By.XPath("//div[@id='calendar']/div[2]/div"));
            foreach (var a in hrow)
            {
                j = 1;
                IList<IWebElement> hrver = objDriver.FindElements(By.XPath("//div[@id='calendar']/div[2]/div[3]/div"));
                foreach(var b in hrver)
                {
                   if(objDriver.existsElement(By.XPath("//div[@id='calendar']/div[2]/div['" + i + "']/div['" + j + "']/div/div/div/a")))
                    {

                        return objDriver.GetElement(By.XPath("//div[@id='calendar']/div[2]/div['" + i + "']/div['" + j + "']/div/div/div/a")).Text.Contains("test_section");
                    }
                   else
                    {
                        //break;
                    }
                    j = j + 1;
                    
                }
                i = i + 1;
            }
            IList <IWebElement> cal = objDriver.FindElements(By.XPath("//div[@class='cal-week-box']/div"));
          foreach(var ele in cal)
            {
                if(ele.GetAttribute("data-original-title").Contains(v))
                {
                    res= true;
                }
                else
                {
                    res= false;
                }
            }
            return res;
        }
    }

    public class ContentTypeFacetCommand
    {
        private IWebDriver objDriver;
        public ContentTypeFacetCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public bool? UnCheckedDisplayFormatFacetRemoved { get { return objDriver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li[3]/div/span")); } }

        public void ClickContentType(string v)
        {
            objDriver.ClickEleJs(By.Id("CTYPGRP_CONTENT_GROUP_ID_ML.BASE.COURSEWARE.ONLINE"));
        }

        public bool? Display()
        {
            return objDriver.existsElement(By.XPath("//a[text()='Content Type']"));
        }

        public void SelectCheckbox()
        {
            objDriver.ClickEleJs(By.XPath("//a[text()='Content Type']/following::input[1]"));  //select first check box
            Thread.Sleep(3000);
            objDriver.existsElement(By.XPath("//a[text()='Content Type']"));
            objDriver.ClickEleJs(By.XPath("//a[text()='Content Type']/following::input[2]"));
            Thread.Sleep(3000);
            objDriver.existsElement(By.XPath("//a[text()='Content Type']"));
            objDriver.ClickEleJs(By.XPath("//a[text()='Content Type']/following::input[3]"));
            Thread.Sleep(3000);
            objDriver.existsElement(By.XPath("//a[text()='Content Type']"));
        }

        public void UnCheckDisplayFormatFacetFacetCheckbox()
        {
            objDriver.ClickEleJs(By.XPath("//a[text()='Content Type']/following::input[3]"));
            Thread.Sleep(3000);
            objDriver.WaitForElement(By.XPath("//a[text()='Content Type']"));
        }

        public bool? AllTagCheckboxUnChecked()
        {
            throw new NotImplementedException();
        }
    }

    public class CreditTypesFacetCommand
    {
        private IWebDriver objDriver;
        public CreditTypesFacetCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? UnCheckedCreditTypeRemoved
        {
            get
            { return objDriver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li[3]/div/span")); }
        }
        
        public CreditTypesFacetCommand()
        {
        }

        public bool? Display()
        {
            return objDriver.GetElement(By.LinkText("Credit Type")).Displayed;
        }

        public void SelectCheckbox()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_CREDITS']/div/ul/li/input"));
            Thread.Sleep(3000);
            objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_CREDITS']/div/ul/li[2]/input"));
            Thread.Sleep(3000);
            objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_CREDITS']/div/ul/li[3]/input"));
            Thread.Sleep(3000);
            objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
        }

        public void UnCheckCreditTypesFacetCheckbox()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_CREDITS']/div/ul/li[3]/input"));
            Thread.Sleep(3000);
            objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
        }

        public bool? TagCheckboxChecked()
        {

            IWebElement checkbox = objDriver.GetElement(By.XPath("//div[@id='panel_CNT_CREDITS']/div/ul/li/input"));
            if (checkbox.Selected)
            {
                return true;
            }
            else
            { return false; }
        }

        public bool? CreditTypesCheckboxUnChecked()
        {
            IWebElement checkbox = objDriver.GetElement(By.XPath("//div[@id='panel_CNT_CREDITS']/div/ul/li[2]/input"));
            if (!checkbox.Selected)
            {
                return true;
            }
            else
            { return false; }
        }

        public bool? AllTagCheckboxUnChecked()
        {
            IWebElement checkbox = objDriver.GetElement(By.XPath("//div[@id='panel_CNT_CREDITS']/div/ul/li/input"));
            if (!checkbox.Selected)
            {
                return true;
            }
            else
            { return false; }
        }

        public void SelectCheckbox(string v)
        {
            throw new NotImplementedException();
        }

        public void SelectCheckboxFor(string v)
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li[2]/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_CREDITS']/div/a"));
            objDriver.ClickEleJs(By.XPath("//*[contains(text(),'"+v+"')]//preceding::input[1]"));
        }
    }

    public class SelectedTagsAboveSearchResultsCommand
    {
        private IWebDriver objDriver;
        public SelectedTagsAboveSearchResultsCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? TagRemoved { get { return objDriver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li[2]/div/span")); } }

        public bool? AllTagsRemoved { get { return objDriver.existsElement(By.XPath("//div[2]/div[2]/ul/li/div/span")); } }

        public SelectedTagsAboveSearchResultsCommand()
        {
        }

        public bool? Display()
        {
            return objDriver.GetElement(By.XPath("//div[2]/div[2]/ul/li/div/span")).Displayed;
        }

     
        public void SelectClearAll()
        {
            objDriver.ClickEleJs(By.LinkText("Clear All"));
        }

        

        public void RemoveTag()
        {
            objDriver.GetElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li[2]/div/a/span")).ClickWithSpace();
            Thread.Sleep(3000);
            //objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
        }
    }

    public class ContentTagsFacetCommand
    {
        private IWebDriver objDriver;
        public ContentTagsFacetCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? UnCheckedTagRemoved { get { return objDriver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li[3]/div/span")); } }

        public ContentTagsFacetCommand()
        {
        }

        public bool? Display()
        {
            return objDriver.GetElement(By.LinkText("Content Tags")).Displayed;
        }

        public void SelectCheckbox()
        {
            objDriver.ClickEleJs(By.XPath("//div[4]/div[2]/div/ul/li/input"));
            Thread.Sleep(3000);
            //objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_TAGS']/div/ul/li[1]/label"));
            Thread.Sleep(3000);
            //objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_TAGS']/div/ul/li[2]/label"));
            Thread.Sleep(3000);
            //objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
        }

        public void UnCheckTagCheckbox()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='panel_CNT_TAGS']/div/ul/li[2]/label"));
            Thread.Sleep(3000);
            //objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul[2]/li/div/div/h3/a"));
        }

      

        public bool? TagCheckboxChecked()
        {
            IWebElement checkbox = objDriver.GetElement(By.XPath("//div[@id='panel_CNT_TAGS']/div/ul[1]/li[1]/input"));
            if (checkbox.Selected)
            {
                return true;
            }
            else
            { return false; }
        }

        public bool? TagCheckboxUnChecked()
        {
            IWebElement checkbox = objDriver.GetElement(By.Id("CNT_TAGS_Tag_Reg0612405840"));
            if (!checkbox.Selected)
            {
                return true;
            }
            else
            { return false; }
        }

        public bool? AllTagCheckboxUnChecked()
        {
            IWebElement checkbox = objDriver.GetElement(By.XPath("//div[@id='panel_CNT_TAGS']/div/ul/li/input"));
            if (!checkbox.Selected)
            {
                return true;
            }
            else
            { return false; }
        }
    }

    public class ListofSearchResultsCommand
    {
        private IWebDriver objDriver;
        public ListofSearchResultsCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public void ExpandSections()
        {
            //objDriver.ClickEleJs(By.XPath("//*[@id='MGSearchResults']/div[2]/div[2]/ul/li[1]/div[1]/div[4]/button"));
            objDriver.existsElement(By.XPath("//div[2]/button"));
            objDriver.ClickEleJs(By.XPath("//div[2]/button"));
        }

        public bool? VerifyTextonEventPortlet(string v)
        {
            objDriver.existsElement(By.XPath("//a/div/div/h4"));
            bool result = false;

            try
            {
                switch(v)
                {
                    case "AllDay":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div/h4"));
                       objDriver.IsElementVisible(By.XPath("//div[2]/p/span"));
                        result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Equals("All Day");
                     
                        break;

                    case "OneEvent":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div/h4"));
                        result= objDriver.IsElementVisible(By.XPath("//div[2]/p/span"));
                        //result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                     
                        break;
                    case "Every Weekday":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                        result=objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Every Weekday");
                       // result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                     
                        break;
                    case "Daily":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                        result=objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Daily");
                        //result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                     
                        break;
                    case "Weekly":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                       result= objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Every");
                        //result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                      
                        break;
                    case "Every two weeks":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                        result=objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Every two weeks on");
                       // result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                       
                        break;
                    case "Monthly":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        result=objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                        //result=objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Day of every month");
                       // result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                      
                        break;
                    case "MonthlySpecificDay":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                       result= objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Every month on the first");
                        //result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                      
                        break;
                    case "Annually":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                        result=objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Every year on");
                       // result = objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                      
                        break;
                    case "MultipleEvents":
                        objDriver.existsElement(By.XPath("//h4[@class='results-heading']"));
                        objDriver.IsElementVisible(By.XPath("//a/div/div[2]/p/span"));
                        result = objDriver.GetElement(By.XPath("//a/div/div[2]/p")).Text.Contains("Times vary");
                        //objDriver.GetElement(By.XPath("//p/span[2]")).Text.Contains("PM AM EST");
                       
                        break;
                }

            }
            catch
            { }
            return result;
        }

        public bool? Display()
        {
            objDriver.WaitForElement(By.XPath("//div[@id='MGSearchResults']/div/div/h2/strong"));
            return objDriver.GetElement(By.XPath("//div[@id='MGSearchResults']/div/div/h2/strong")).Displayed;
        }

        public bool? isContentTypeDisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//ul[@class='list-unstyled results-list']//li[1]//div[1]//div[2]//div[1]//div[1]//div[1]//p[1]//span[1]"));
        }

        public bool? isContentTypeIconDisplay(string v)
        {
            return objDriver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/span"));
        }
    }

    public class SearchedRecordCommand
    {
        private IWebDriver objDriver;
        public SearchedRecordCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public SectionsButtonCommand SectionsButton
        {
            get { return new SectionsButtonCommand(objDriver); }
        }

        public bool? isDefaulticondisplay(string v)
        {
            bool result = false;
            switch (v)
            {
                case "General":
                    objDriver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div"));
                    string text = objDriver.GetElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/span")).GetCssValue("Content");
                    if(text== "normal")
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }
    }

    public class SectionsButtonCommand:ObjectInit
    {
        private IWebDriver objDriver;
        private CommonSection commonSectionPage2;
       

        public SectionsButtonCommand(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
            commonSectionPage2 = new CommonSection(objDriver);
            
        }
        public Boolean ClickSectionTitle()
        {
            string format = "M/d/yyyy";
            if (objDriver.existsElement(By.XPath("(//button[@type='button'])[9]")))
                {
                objDriver.ClickEleJs(By.XPath("(//button[@type='button'])[9]"));
                objDriver.ClickEleJs(By.LinkText("testsection"));
            }
            else
            {
                commonSectionPage2.Manage.Training();

                trainingPage1.SearchRecord("Classroomcourse1");
                searchResultsPage1.ClickCourseTitle("Classroomcourse1");
                ClassroomCourseDetailsPage.ClickSectionsTab();
                SectionsPage.AddNewSectionButton();
                CreateNewCourseSectionAndEventPage.CreateSection("testsection" + Meridian_Common.globalnum, DateTime.Now.ToString(format), DateTime.Now.AddDays(2).ToString(format), "12:00 AM", "11:45 PM");
                commonSectionPage2.Manage.Training();

                trainingPage1.SearchRecord("Classroomcourse1");
            }
            return true;
           // throw new NotImplementedException();
        }
    }
}