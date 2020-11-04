using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Threading;
using TestAutomation.helper;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class AccountPage:ObjectInit
    {
        private IWebDriver objDriver;
        public AccountPage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  EditInterestsModalCommand EditInterestsModal
        {
            get { return new EditInterestsModalCommand(objDriver); }
        }

        public  InterestsCommand Interests
        {
            get { return new InterestsCommand(objDriver); }
        }

        public  InterestsPortletCommand InterestsPortlet
        {
            get { return new InterestsPortletCommand(objDriver); }
        }

        public  InterestsSectionCommand InterestsSection { get { return new InterestsSectionCommand(objDriver); } }

        public  ProfileTabCommand ProfileTab
        {
            get { return new ProfileTabCommand(objDriver); }
        }

        public  WorkInformationFrameCommand WorkInformationFrame
        {
            get { return new WorkInformationFrameCommand(objDriver); }
        }

        public  void ClickProfiletab()
        {
            objDriver.ClickEleJs(By.XPath("//a[@href='#acct-profile']"));
        }

        public  void ClickProfileTab()
        {
            objDriver.WaitForElement(By.LinkText("Profile"));
            objDriver.ClickEleJs(By.LinkText("Profile"));
            Thread.Sleep(2000);
        }

        public  void ClickEditInterest()
        {
            objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-primary mg-select-tag']"));

        }

        public  void Close_InterestWindow()
        {
            objDriver.ClickEleJs(By.XPath("//button[contains(.,'Done')]"));
        }

        public  void ClickPreferencesTab()
        {
            objDriver.ClickEleJs(By.XPath("//a[@href='#acct-preferences']"));
        }

        public  void Click_EditPreferencesButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[@id='MainContent_UCProfile_ucPreferences_FormView1_lnkEdit']"));
            objDriver.SelectFrame(By.XPath("//span[@class='k-window-title']"));
        }

        public  void Change_Timezone()
        {
            objDriver.selectDropdownValue(By.XPath("//select[@id='MainContent_UC1_FormView1_USR_TIME_ZONE_ID']"), "(UTC-06:00) Central Time (US & Canada)");
        }

        public  void Click_SavePreferencesButton()
        {
            objDriver.ClickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            objDriver.SwitchtoDefaultContent();
            objDriver.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }

        public  string addInterest(string user)
        {
            string userID = null;
            switch(user)
            {
                case "_User1":
                    {
                        objDriver.ClickEleJs(By.XPath("//a[contains(.,'Edit Interests')]"));
                        Thread.Sleep(3000);
                        userID = objDriver.GetElement(By.XPath("/html[1]/body[1]/form[1]/div[7]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/a[1]")).Text;
                        objDriver.ClickEleJs(By.XPath("/html[1]/body[1]/form[1]/div[7]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/a[1]"));
                        objDriver.ClickEleJs(By.XPath("//button[contains(.,'Done')]"));
                        Thread.Sleep(2000);
                        break;
                    }
                case "_User2":
                    {
                        objDriver.ClickEleJs(By.XPath("//a[contains(.,'Edit Interests')]"));
                        Thread.Sleep(3000);
                        userID = objDriver.GetElement(By.XPath("/html[1]/body[1]/form[1]/div[7]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/a[1]")).Text;
                        objDriver.ClickEleJs(By.XPath("/html[1]/body[1]/form[1]/div[7]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/a[1]"));
                        objDriver.ClickEleJs(By.XPath("//button[contains(.,'Done')]"));
                        Thread.Sleep(2000);
                        break;
                    }
  
            }

            return userID;

        }

        public  void Click_EditWorkInformation()
        {
            objDriver.ClickEleJs(By.Id("MainContent_UCProfile_ucWorkInfo_lnkEdit"));
        }
    }

    public class WorkInformationFrameCommand
    {
        private IWebDriver objDriver;
        public WorkInformationFrameCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void AddJobTitle(string v)
        {
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.ClickEleJs(By.XPath("//div[@id='MainContent_UC1_FormView1_pnlAddJobTitle']/div/a"));
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.GetElement(By.Id("MainContent_UC1_txtSearch")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("MainContent_UC1_btnSearch"));
            objDriver.ClickEleJs(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_chkSelect"));
            objDriver.ClickEleJs(By.Id("MainContent_UC1_FormView1_Save"));
            objDriver.findandacceptalert();
            objDriver.SwitchTo().DefaultContent();
            objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            objDriver.getSuccessMessage();
            objDriver.ClickEleJs(By.Id("MainContent_UC1_Save"));
            objDriver.SwitchTo().DefaultContent();
            objDriver.getSuccessMessage();

        }
    }

    public class InterestsSectionCommand
    {
        private IWebDriver objDriver;
        public InterestsSectionCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public bool? EditLink { get { return objDriver.GetElement(By.XPath("//div[@id='currentUserContentTags']/h2")).Displayed; } }

        public bool? InterestsAdded { get { return objDriver.GetElement(By.XPath("//ul[@id='profileInterests']/li/a")).Displayed; } }

        public void ClickEditLink()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Edit Interests')]"));
        }
    }

    public class InterestsCommand
    {
        private IWebDriver objDriver;
        public InterestsCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? EditLink { get; internal set; }

        public void ClickEditLink()
        {
            if (objDriver.IsElementVisible(By.XPath("//a[@id='btnManageLearnerTags']")))
            {
                //objDriver.ClickEleJs(By.XPath("//a[@id='btnManageLearnerTags']"));
                //Thread.Sleep(1000);
            }
            else
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'Edit Interests')]"));
                Thread.Sleep(3000);
                objDriver.GetElement(By.Id("interestSearch")).SendKeysWithSpace("testtag");
                //objDriver.ClickEleJs(By.XPath("btn btn-default"));
                objDriver.ClickEleJs(By.XPath("//a[@data-id='268']"));
                objDriver.ClickEleJs(By.XPath("//button[contains(.,'Done')]"));
                Thread.Sleep(2000);
                //objDriver.ClickEleJs(By.XPath("//a[@id='btnManageLearnerTags']"));
            }
        }

        public bool? InterestsAdded()
        {
            throw new NotImplementedException();
        }

        public bool? InterestsRemovedfromModal()
        {
            throw new NotImplementedException();
        }

        public bool? InterestsRemovedfromAccountsPage()
        {
            throw new NotImplementedException();
        }
    }

    public class ProfileTabCommand
    {
        private IWebDriver objDriver;
        public ProfileTabCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? isInterestsSectionDisplayed;

        public bool? InterestsSection { get
            {
                Thread.Sleep(5000);
                return objDriver.GetElement(By.XPath("//div[@id='currentUserContentTags']/h2")).Displayed;
            }
        }
        public bool? NoInterestsSection { get; internal set; }

        public void RemoveTags()
        {
            
            while (objDriver.IsElementVisible(By.XPath("//a[@class='btn btn-add-remove btn-outline-primary']/span")))
            {
                objDriver.ClickEleJs(By.XPath("//a[@class='btn btn-add-remove btn-outline-primary']/span"));
            }
        }

        public void TimeZone()
        {           
            //Meridian_Common.UserTimeZone= objDriver.GetElement(By.XPath("//strong[contains(text(),'(UTC-05:00) Eastern Time (US & Canada)')]")).Text;
            Meridian_Common.UserTimeZone = objDriver.GetElement(By.XPath("//div[@id='preferences-block']/div/ul/li[4]/strong")).Text;


        }
    }

    public class EditInterestsModalCommand
    {
        private IWebDriver objDriver;
        public EditInterestsModalCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? MultipleInterests { get
            {
                objDriver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                return objDriver.GetElement(By.Id("learner-tags-modal")).Displayed;
            }
        }

        public string SelectInterestTagname { get {
                Thread.Sleep(2000);
                return objDriver.GetElement(By.XPath("//ul[@id='profileInterests']/li/a")).Text; } }

        public void SelectInterest()
        {
            throw new NotImplementedException();
        }

        public void SelectInterest(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public void SelectInterests()
        {
            throw new NotImplementedException();
        }

        public bool? MultipleSelectedInterests()
        {
            throw new NotImplementedException();
        }

        public void DeSelectInterests()
        {
            throw new NotImplementedException();
        }

        public void SelectInterestTag()
        {
            objDriver.GetElement(By.XPath("//div[@id='add-interest']/div/a")).ClickWithSpace();
            Thread.Sleep(2000);
           
        }

        public void ClickDone()
        {
            objDriver.ClickEleJs(By.XPath("//div[@id='ko-container-add-interest']/div[2]/button"));
            Thread.Sleep(2000);
        }
    }

    public class InterestsPortletCommand
    {
        private IWebDriver objDriver;
        public InterestsPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public bool? ContentTagDeleted { get; internal set; }
        public bool? EditInterests { get; internal set; }

        public void ClickEditLink()
        {
            throw new NotImplementedException();
        }

        public bool? InterestsAdded()
        {
            throw new NotImplementedException();
        }

        public bool? InterestsAdded(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}