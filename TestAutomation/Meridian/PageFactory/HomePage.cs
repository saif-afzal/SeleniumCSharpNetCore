using System;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using OpenQA.Selenium;
using System.Threading;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using Selenium2.Meridian;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class HomePage:ObjectInit
    {
        private IWebDriver objDriver;
        public HomePage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  Catalogommand Catalog
        {
            get { return new Catalogommand(objDriver); }
        }
        public  RecommendationCommand RecommendationPortlet
        {
            get { return new RecommendationCommand(objDriver); }
        }

        public  object Create { get; internal set; }
        

        public  string Title
        {
            get
            {
                Thread.Sleep(20000);

                //                objDriver..Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
                return objDriver.Title;
            }
        }

        public  CertificationPortletCommand CertificationPortlet
        {
            get { return new CertificationPortletCommand(objDriver); }
        }

        public  CurrentTrainingPortletCommand CurrentTrainingPortlet
        {
            get { return new CurrentTrainingPortletCommand(objDriver); }
        }

        public  CertificationContentPortletCommand CertificationContentPortlet
        {
            get { return new CertificationContentPortletCommand(objDriver); }
        }

        public  RecentlyAddedCommand RecentlyAdded
        {
            get { return new RecentlyAddedCommand(); }
        }

        public  BasedOnYourInterestCommand BasedOnYourInterest {
            get { return new BasedOnYourInterestCommand(objDriver); } }

        public  CompletedTrainingPortletCommand CompletedTrainingPortlet { get { return new CompletedTrainingPortletCommand(objDriver); } }


        public  RecommendedForYou RecommendedForYou { get { return new RecommendedForYou(objDriver); } }

        public  void ClickAboutLink()
        {
            Thread.Sleep(5000);
            objDriver.ClickEleJs(By.XPath("//a[@id='lnkAboutPage']"));
        }

        public  bool? ClickMoalX()
        {
            objDriver.GetElement(By.XPath("//a[contains(.,'Close')]")).ClickWithSpace();
            //objDriver..waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
            // objDriver..waitforframe(By.Id("KendoUIMGDialog_wnd_title"));
            objDriver.ClickEleJs(By.XPath("//a[@class='k-window-action k-link k-state-hover']"));
            //objDriver..SwitchTo().DefaultContent();
            // objDriver..SwitchTo().Frame(0).Close();
            return true;
        }



        public class Catalogommand
        {
            private IWebDriver objDriver;
            public Catalogommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }
            public bool RecentlyAdded_RecommendationPortlet()
            {
                bool result = false;
                try
                {
                    result = objDriver.IsElementVisible(By.XPath("//div/div[@id='container-recently-added']"));
                  //  result = true
                }
                catch (Exception e)
                {

                }

                return result;
            }

            public bool VerifyAndClickButton_ShowMore()
            {
                bool result = false;
                try
                {
                    if (objDriver.IsElementVisible(By.Id("btnRecentlyAddedShowMore")))
                    {
                        objDriver.ClickEleJs(By.Id("btnRecentlyAddedShowMore"));
                        Thread.Sleep(2000);
                        result = objDriver.IsElementVisible(By.XPath("//div/div[@id='container-recently-added']/div/div[2]"));
                     
                    }

                    else
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {

                }

                return result;
            }

            public bool? BasedOnYourInterest_RecommendationPortlet()
            {
                bool result = false;
                try
                {
                    result = objDriver.IsElementVisible(By.Id("container-recommend-by-interest"));
                }
                catch(Exception e)
                {

                }

                return result;
            }
        }

        public  bool? selectInterest(string tagname, string coursename)
        {
            bool result = false;
            try
            {
                if (objDriver.IsElementVisible(By.XPath("//a[contains(text(),'Edit Interests')]")))
                {
                    objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Edit Interests')]"));
                    objDriver.GetElement(By.XPath("//input[@id='interestSearch']")).SendKeysWithSpace(tagname);
                    objDriver.ClickEleJs(By.XPath("//div[@id='addTags']/div/span/button/span"));
                    objDriver.ClickEleJs(By.XPath("//a[contains(.,'"+tagname+"')]"));
                    objDriver.ClickEleJs(By.XPath("//button[contains(.,'Done')]"));
                    objDriver.IsElementVisible(By.XPath("//h4[contains(text(),'"+coursename+"')]"));
                    result = true;
                }
                else
                {
                    commonSection1.Avatar.Account();
                    accountPage1.ClickProfiletab();
                    accountPage1.ProfileTab.RemoveTags();
                    commonSection1.Learn.Home();
                    objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Edit Interests')]"));
                    objDriver.GetElement(By.XPath("//input[@id='interestSearch']")).SendKeysWithSpace(tagname);
                    objDriver.ClickEleJs(By.XPath("//div[@id='addTags']/div/span/button/span"));
                    objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + tagname + "')]"));
                    objDriver.ClickEleJs(By.XPath("//button[contains(.,'Done')]"));
                    objDriver.IsElementVisible(By.XPath("//h4[contains(text(),'" + coursename + "')]"));
                    result = true;
                }
               
            }catch(Exception e)
            {

            }
            return result;
        }

        public  bool? IsNavigationbarLogodisplay()
        {
            return objDriver.existsElement(By.XPath("//span[@class='navbar-logo']"));
        }

        public class RecommendationCommand
        {
            private IWebDriver objDriver;
            public RecommendationCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
            }
            public bool Access_Content(String s)
            {
                bool result = false;
                try
                {
                    Thread.Sleep(5000);
               result= objDriver.IsElementVisible(By.XPath("//h4[contains(text(),'" + s + "')]"));
                    objDriver.ClickEleJs(By.XPath("//h4[contains(text(),'" + s + "')]"));
              result=   objDriver.IsElementVisible(By.XPath("//h1[contains(.,'" + s + "')]"));
                    
                }
                catch(Exception e)
                {

                }
                return result;
            }

            public bool? Verify_Content_InRandom(string s)
            {
                bool result = false;
                try
                {
                    Thread.Sleep(5000);
                  result=  objDriver.existsElement(By.XPath("//h4[contains(text(),'" + s + "')]"));
                  
                }
                catch(Exception e)
                {

                }
                return result;
            }
        }

        public  bool VerifyMessage(string v)
        {
            throw new NotImplementedException();
        }

        public  void clickGetStarted()
        {
            objDriver.existsElement(By.XPath("//*[@id='content']/div/div/a"));
            objDriver.ClickEleJs(By.XPath("//*[@id='content']/div/div/a"));
        }

        public  bool? isRecommendedforYouPortletdisplay()
        {
            return objDriver.existsElement(By.XPath("//div[@id='container-collabrative-recomendation']"));
        }

        public  bool? ClickModalX()
        {
            objDriver.GetElement(By.XPath("//a[contains(.,'Close')]")).ClickWithSpace();
            //objDriver..waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
            // objDriver..waitforframe(By.Id("KendoUIMGDialog_wnd_title"));
            //objDriver.ClickEleJs(By.XPath("//a[@class='k-window-action k-link k-state-hover']"));
            //objDriver..SwitchTo().DefaultContent();
            // objDriver..SwitchTo().Frame(0).Close();
            return true;
        }

        public  bool? isCustomBlockDisplayed()
        {
            return objDriver.existsElement(By.XPath("//div[@class='bg-contrast flex text-white slick-slide slick-current slick-active']//div[@class='overlay absolute pin transition opacity-75 w-full']"));
        }
    }

    public class RecommendedForYou
    {
        private IWebDriver objDriver;
        public RecommendedForYou(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void Content()
        {
            //objDriver.existsElement(By.XPath("//div[@id='container-collabrative-recomendation']/div/div/div/div/a/h4"));
            objDriver.existsElement(By.XPath("//div[@id='container-collabrative-recomendation']/div/div/div/div[4]/a/h4"));
        }

        public bool? ContentType()
        {
            return objDriver.GetElement(By.XPath("//div[6]/div/div/div/div/a/p[1]")).Enabled;
        }
    }

    public class CompletedTrainingPortletCommand
    {
        private IWebDriver objDriver;
        public CompletedTrainingPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public void Conent()
        {
            objDriver.existsElement(By.XPath("//div[2]/table/tbody/tr/td/a"));
        }

        public bool? ContentType()
        {
            return objDriver.GetElement(By.XPath("//div[2]/table/tbody/tr/td[2]")).Displayed;
        }

        public void Click_CourseTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),"+v+")]"));
        }
    }

    public class BasedOnYourInterestCommand
    {
        private IWebDriver objDriver;
        string text = string.Empty;
        public BasedOnYourInterestCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
            text = objDriver.GetElement(By.XPath("//div[3]/div/div[1]/a/h4")).Text;
            text = text.Substring(0, 14);
            Meridian_Common.text23 = text;
        }
      
       

        public bool? isDisplayed()
        {
          return objDriver.GetElement(By.XPath("//div[@id='container-recommend-by-interest']")).Displayed;
            
        }

        public bool? isSaveButtonDispalyed()
        {
            return objDriver.GetElement(By.XPath("//div[@class='recommended-by-tags-carousel slick-carousel']//div[1]//button[1]")).Enabled;
        }

        public bool? isSaveButtonIconGreen()
        {
            Thread.Sleep(3000);

            return objDriver.GetElement(By.XPath("//div[@class='recommended-by-tags-carousel slick-carousel']//div[1]//button[1]")).GetCssValue("background-color") == "rgba(121, 168, 121, 1)";
        }

        public void ClickSaveButton()
        {
            objDriver.existsElement(By.XPath("//div[@class='recommended-by-tags-carousel slick-carousel']//div[1]//button[1]"));
            objDriver.ClickEleJs(By.XPath("//div[@class='recommended-by-tags-carousel slick-carousel']//div[1]//button[1]"));
        }

        public bool? isToolTipDisplayed(string v)
        {
            return objDriver.GetElement(By.XPath("//div[@class='recommended-by-tags-carousel slick-carousel']//div[1]//button[1]/span[@title='" + v + "'][1]")).GetAttribute("Title") == v;

        }

        public void Content()
        {
            Thread.Sleep(5000);
            objDriver.existsElement(By.XPath("//div[@class='card list']//h4"));

        }

        public bool? ContentType()
        {
           return  objDriver.existsElement(By.XPath("//div[@class='card list']//h4/following::p[@class='text-muted']"));

        }
    }

    public class RecentlyAddedCommand
    {

        private IWebDriver objDriver;
        public RecentlyAddedCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }

        public RecentlyAddedCommand()
        {
           
       
            PageFactory.InitElements(objDriver, this);
        }
        //[FindsBy(How = How.XPath, Using = ("//h4[contains(.,'"+ Meridian_Common.RecentContentText + "')]/following::button[1]"))]
        //public IWebElement CornerSaveButton { get; set; }

        [FindsBy(How=How.XPath, Using =("//div[5]/button/span"))]
        public IWebElement Icon { get; set; }

        //[FindsBy(How =How.XPath, Using =("//h4[contains(.,'"+ Meridian_Common.RecentContentText + "')]/following::button[1]"))]
        //public IWebElement GreenBtn { get; set; }


        public bool? isSaveButtonDisplyed()
        {
            //var elem = objDriver..FindElement(By.XPath("//div[@class='recently-added-carousel slick-carousel slick-initialized slick-slider slick-dotted']//div[@class='card slick-slide slick-current slick-active']//button[@type='button']"));
            //Actions action = new Actions(objDriver.);
            //action.MoveToElement(elem).Perform();

            //elem.Click();
            //Meridian_Common.RecentContentText = objDriver.GetElement(By.XPath("//div[@id='container-recently-added']/div/div/div/div[5]/a/h4")).Text;
           // return objDriver.GetElement(By.XPath("//h4[contains(.,'" + Meridian_Common.RecentContentText + "')]/following::button[1]")).Enabled;

            Meridian_Common.RecentContentText = objDriver.GetElement(By.XPath("//div[@id='container-recently-added']/div/div/div/div[5]/a/h4")).Text;
            return objDriver.GetElement(By.XPath("//h4[contains(.,'"+ Meridian_Common.RecentContentText + "')]/following::button[1]")).Enabled;
          
        }

        public void ClickSaveButton()
        {
            Thread.Sleep(3000);
            Meridian_Common.RecentContentText = objDriver.GetElement(By.XPath("//div[@id='container-recently-added']/div/div/div/div[5]/a/h4")).Text;
            objDriver.existsElement(By.XPath("//h4[contains(.,'"+ Meridian_Common.RecentContentText + "')]/following::button[1]"));
            objDriver.ClickEleJs(By.XPath("//h4[contains(.,'"+ Meridian_Common.RecentContentText + "')]/following::button[1]"));
        }

        public bool? isSaveButtonIconGreen()
        {
            Thread.Sleep(3000);
            // throw new NotImplementedException();
            return objDriver.GetElement(By.XPath("//h4[contains(.,'"+ Meridian_Common.RecentContentText + "')]/following::button[1]")).GetCssValue("background-color") == "rgba(121, 168, 121, 1)";
           // return GreenBtn.GetCssValue("#79a879");
        }

        public bool? isTooltipDisplyed(string v)
        {
            //  throw new NotImplementedException();
           return objDriver.GetElement(By.XPath("//h4[contains(.,'"+ Meridian_Common.RecentContentText + "')]/following::span[@title='"+v+"'][1]")).GetAttribute("Title")==v;
            //return  objDriver.verifyToolTipText(By.XPath("//div[@class='card slick-slide slick-current slick-active']//span[@title='" + v + "']"),v);
        }

        public void Content()
        {
            objDriver.existsElement(By.XPath("//div[@id='container-recently-added']/div/div/div/div[4]/a[1]/h4"));
        }

        public bool? ContentType()
        {
            return objDriver.GetElement(By.XPath("//div[@id='container-recently-added']/div/div/div/div/a/h4/following::p[1]")).Enabled;
        }
    }

    public class CertificationContentPortletCommand
    {
        private IWebDriver objDriver;
        public CertificationContentPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public ForCertificationContentPortletCommand For(string v)
        {
            return new ForCertificationContentPortletCommand(v);
        }
    }

    public class ForCertificationContentPortletCommand
    {
        private IWebDriver objDriver;
        private string v;
        public ForCertificationContentPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
            
        }

        public ForCertificationContentPortletCommand(string v)
        {
            this.v = v;
        }

        public bool? IsStatus(string v)
        {
            throw new NotImplementedException();
        }

        public bool? IsProgress(string v)
        {
            throw new NotImplementedException();
        }

        public bool? IsProgressCount(string v)
        {
            return objDriver.GetElement(By.XPath("//*[@id='MainContent_ucCertSummary_pnlStarted']/strong")).Text==v;
        }
    }

    public class CurrentTrainingPortletCommand
    {
        private IWebDriver objDriver;
        public CurrentTrainingPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? isStatus(string v)
        {
            throw new NotImplementedException();
        }

        public bool? isProgress(string v)
        {
            throw new NotImplementedException();
        }

        public ForCommand For(string v)
        {
            return new ForCommand(v);
        }

     

        public bool? ContentType()
        {
            return objDriver.GetElement(By.XPath("//tr/td[1]/h3/a/following::li[1]")).Displayed;
        }

        public void Content()
        {
            objDriver.existsElement(By.XPath("//tr/td[1]/h3/a"));
        }
    }

    public class CertificationPortletCommand
    {
        private IWebDriver objDriver;
        public CertificationPortletCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public bool? isCreditTypeDisplayed;
        public bool? isCertificationRequiredCreditHoursDisplayed;
        public bool? isCertificationEarnedCreditHoursDisplayed;
        public bool? isCertificationCreditTypeDisplayed;
        public bool? isCertificationReCertifyButtonDisplayed;

        public void ExpandCertificationTitle()
        {
            throw new NotImplementedException();
        }

        public bool? isStatus(string searchtext,string v)
        {
            Thread.Sleep(5000);
            return objDriver.GetElement(By.XPath("//h2[contains(text(),'Certifications')]/following::a[contains(.,'" + searchtext + "')]/following::li[1]")).Text == v;
            //throw new NotImplementedException();
           // return true;
        }

        public void ClickViewDetailsButtonofCertificationTitle(string v="",string linktext2="")
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'"+v+"')]/span"));
            Thread.Sleep(3000);
            if (objDriver.GetElement(By.XPath("//a[contains(.,'" + v + "')]/following::a[1][contains(.,'" + linktext2 + "')]")).Displayed)
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]/following::a[1][contains(.,'" + linktext2 + "')]"));
            }
            else
            {
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]/span"));
                objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]/following::a[1][contains(.,'" + linktext2 + "')]"));

            }
        }

        public bool isProgress(string v)
        {
            throw new NotImplementedException();
        }

        public void ClickReCertifyButton()
        {
            throw new NotImplementedException();
        }

        public ForCommand For(string v)
        {
            return new ForCommand(v);
           // throw new NotImplementedException();
        }

        public void ExpandCertificationTitle(string v)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'"+v+"')]"));
        }

        public void Content()
        {
            throw new NotImplementedException();
        }

        public bool? ContentType()
        {
            throw new NotImplementedException();
        }
    }

    public class ForCommand
    {
        private IWebDriver objDriver;
        private string v;
        public ForCommand(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
          
        }
        public ForCommand(string v)
        {
            this.v = v;

        }



        public bool? IsStatus(string z)
        {
          return  objDriver.existsElement(By.XPath("//a[contains(.,'" + v + "')]/following::li[1][contains(.,'"+z+"')]"));
        }

        public bool? IsProgress(string l)
        {
            return objDriver.GetElement(By.XPath("//a[(text()='"+v+"')]/following::div[1]/div/span[1]")).Text == l;
        }

        public bool? isCertificationStatus(string res)
        {
           return objDriver.GetElement(By.XPath("//a[contains(.,'"+v+"')]//following::td[3]")).Text == res;
        }

        public bool? isCertificationProgress(string res)
        {
            return objDriver.GetElement(By.XPath("//a[contains(.,'" + v + "')]//following::td[4]/div/div")).Text == res;
        }

        public bool IsCertificationProgress(string res)
        {
            return objDriver.GetElement(By.XPath("//a[contains(.,'" + v + "')]//following::td[4]/div/div")).Text == res;

        }

        public void IsCertificationStatus(string v)
        {
            throw new NotImplementedException();
        }

        public void IsCertified()
        {
            objDriver.GetElement(By.XPath("//a[contains(.,'test_0309')]/following::li[1])")).Text.Contains("Certified");
            //throw new NotImplementedException();
        }

        public bool IsProgressStatus(string z)
        {
           return objDriver.existsElement(By.XPath("//a[contains(.,'" + v + "')]/following::p[1][contains(.,'" + z + "')]"));
        }

        public void ClickRecertifyButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]"));
            objDriver.GetElement(By.XPath("//a[contains(.,'" + v + "')]/following::a[contains(.,'Re-certify')]]")).ClickWithSpace();
        }

        public void ClickViewDetailsButton()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]"));
            Thread.Sleep(2000);
            objDriver.GetElement(By.XPath("//a[contains(.,'" + v + "')]/following::a[contains(.,'View Details')]")).ClickWithSpace();
        }

        public bool? IsEarnedCount(int z)
        {
           return objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//a[contains(.,'" + v + "')]/span/following::li[contains(.,'Earned')]")).Text) == z;

        }

        public bool? IsRequiredCount(int z)
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'" + v + "')]/span"));
            Thread.Sleep(2000);
          return  objDriver.getIntegerFromString(objDriver.GetElement(By.XPath("//a[contains(.,'"+v+"')]/span/following::li[contains(.,'Required')]")).Text)==z;
          //  throw new NotImplementedException();
        }
        
        

    }
    
}