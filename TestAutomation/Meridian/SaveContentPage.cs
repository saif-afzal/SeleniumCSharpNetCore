using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class SavedContentPage
    {
        public SavedContentPage()
        {
            
        }
      


  
        public static ContentTitleCommand ContentTitle { get { return new ContentTitleCommand(); } }

        public static ContentlistCommand Contentlist { get { return new ContentlistCommand(); } }

        public static ContentCommand Content { get { return new ContentCommand(); } }

        public static void ClickSaveButton()
        {

            if (Meridian_Common.text12 != null || Meridian_Common.text23 != null||Meridian_Common.SearchResultTitle!=null)
            {
                if (Meridian_Common.text12 != null)
                {
                    Driver.clickEleJs(By.XPath(".//h4[contains(.,'" + Meridian_Common.text12 + "')]/following::button[1]"));

                }
                if (Meridian_Common.text23 != null)
                {
                    Driver.clickEleJs(By.XPath(".//h4[contains(.,'" + Meridian_Common.text23 + "')]/following::button[1]"));
                }
                if (Meridian_Common.SearchResultTitle != null)
                {
                    Driver.clickEleJs(By.XPath(".//h4[contains(.,'" + Meridian_Common.SearchResultTitle + "')]/following::button[1]"));
                }
            }
            else
            {

                Driver.clickEleJs(By.XPath(".//h4[contains(.,'"+Meridian_Common.RecentContentText+"')]/following::button[1]"));
            }



        }

        public static bool? isToolTipDisplayed(string v)
        {
            // throw new NotImplementedException();
            //return Driver.GetElement(By.XPath("//h4[contains(.,'testdocment_281218')]/following::span[@title='" + v + "'][1]")).GetAttribute("Title") == v;
            if (Meridian_Common.text12 != null || Meridian_Common.text23 != null||Meridian_Common.SearchResultTitle!=null)
            {
                if (Meridian_Common.text12 != null)
                {
                    return Driver.GetElement(By.XPath("//h4[contains(.,'"+ Meridian_Common.text12 + "')]/following::span[@title='" + v + "'][1]")).GetAttribute("Title") == v;

                }
                if (Meridian_Common.text23 != null)
                {
                    return Driver.GetElement(By.XPath("//h4[contains(.,'"+ Meridian_Common.text23 + "')]/following::span[@title='" + v + "'][1]")).GetAttribute("Title") == v;
                }
                if (Meridian_Common.SearchResultTitle != null)
                {
                    return Driver.GetElement(By.XPath("//h4[contains(.,'" + Meridian_Common.SearchResultTitle + "')]/following::span[@title='" + v + "'][1]")).GetAttribute("Title") == v;
                }
            }


            return Driver.GetElement(By.XPath("//h4[contains(.,'"+Meridian_Common.RecentContentText+"')]/following::span[@title='" + v + "'][1]")).GetAttribute("Title") == v;

        }

        public static bool? isSavedDataDisplayed(string v)
        {
            if (Meridian_Common.text12 != null|| Meridian_Common.text23 != null||Meridian_Common.SearchResultTitle!=null)
            {
                if (Meridian_Common.text12 != null) {
                    return Driver.existsElement(By.XPath(".//h4[contains(.,'" + Meridian_Common.text12 + "')]"));
                    
                }
                if (Meridian_Common.text23 != null)
                {
                    return Driver.existsElement(By.XPath(".//h4[contains(.,'" + Meridian_Common.text23 + "')]"));
                }
                if (Meridian_Common.SearchResultTitle != null)
                {
                    return Driver.existsElement(By.XPath(".//h4[contains(.,'" + Meridian_Common.SearchResultTitle + "')]"));
                }
            }
          
        
                return Driver.existsElement(By.XPath(".//h4[contains(.,'"+ Meridian_Common.RecentContentText +"')]"));
          
    }

        public static bool? isSaveButtonIconGreen()
        {
            Thread.Sleep(3000);
           
            return Driver.GetElement(By.XPath("//ul[@class='list-saved-content list-unstyled mb-0 pt-4']//li[1]//button[1]")).GetCssValue("background-color") == "rgba(121, 168, 121, 1)";
        }

        public static bool? isPanelResetOptionDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@id='saved-content']/div/a")).Displayed;
        }

        public static bool? isSavedDataListDisplayed()
        {
            string Records = string.Empty;
            Records = Driver.GetElement(By.XPath("//div[@id='saved-content']/div[3]/div/span[3]")).Text;

            int Rec = 0;
            int linktitle = 0;
            Rec = Driver.getIntegerFromString(Records);
            linktitle = Driver.Instance.countelements(By.XPath("//div[@id='saved-content']/div[2]/div/ul/li/a/div[2]/h4"));
            if (Rec >= 1 & linktitle >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public static bool? isSavedContentTitleDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@id='saved-content']/div[2]/div/ul/li/a/div[2]/h4")).Displayed;
        }

        public static bool? isDateSavedDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@id='saved-content']/div[2]/div/ul/li/a/div[4]/strong")).Displayed;

        }

        public static bool? isProgressStatusDisplayed()
        {
            return Driver.existsElement(By.XPath("//b"));
            //return Driver.GetElement(By.XPath("//div[@id='saved-content']/div[2]/div/ul/li[8]/a/div[2]/b")).Displayed;

        }

        public static void ContentStatusFilterBy(string v)
        {
            //Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));

            if (v == "Started")
            {
                Driver.GetElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));

                Driver.clickEleJs(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));
                Driver.clickEleJs(By.XPath("//*[@id='saved-content']/div[1]/div[1]/div/ul/li[2]/a/span[1]"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));
                // Thread.Sleep(3000);
                Driver.clickEleJs(By.XPath(("//*[@id='saved-content']/div[1]/div[1]/div/ul/li[1]/a/span[1]")));

                Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));

            }

            

            else if (v == "Not Started")
            {
               // Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));

                Driver.GetElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));

                Driver.clickEleJs(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));

                Driver.clickEleJs(By.XPath("//*[@id='saved-content']/div[1]/div[1]/div/ul/li[2]/a/span[2]"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));
                Driver.clickEleJs(By.XPath("//*[@id='saved-content']/div[1]/div[1]/div/ul/li[2]/a/span[1]"));
                Thread.Sleep(3000);

                Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));
            }
            
            else if (v == "Completed")
            {
                {
                    //Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));

                    Driver.GetElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));

                    Driver.clickEleJs(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));

                    Driver.clickEleJs(By.XPath("//*[@id='saved-content']/div[1]/div[1]/div/ul/li[1]/a/span[2]"));
                    Thread.Sleep(2000);
                    Driver.clickEleJs(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]/span[2]/span[1]"));
                    Driver.clickEleJs(By.XPath("//*[@id='saved-content']/div[1]/div[1]/div/ul/li[2]/a/span[2]"));
                    Thread.Sleep(3000);

                    Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));
                }
                Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));

            }
        }

        public static bool? isContentStatusFilterBy(string v)
        {
            string ProgressStatus = Driver.GetElement(By.XPath("//b")).Text;

            return ProgressStatus == v;

        }

        public static bool? isTitleDisplayedInAscendingOrderOfDate()
        {
            throw new NotImplementedException();
        }

        public static bool? isTitleDisplayedInDescendingOrderOfDate()
        {
            throw new NotImplementedException();
        }

        public static bool? isTitleDisplayedInAscendingOrderOfRating()
        {
            throw new NotImplementedException();
        }

        public static bool? isTitleDisplayedInDescendingOrderOfRating()
        {
            throw new NotImplementedException();
        }

        public static bool? isTitleDisplayedInAscendingOrderOfCost()
        {
            throw new NotImplementedException();
        }

        public static bool? isTitleDisplayedInDescendingOrderOfCost()
        {
            throw new NotImplementedException();
        }

        public static void ClickPanelResetOption()
        {
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/a"));
        }

        public static bool? isDefaultPanelContentDisplayed()
        {
            throw new NotImplementedException();
        }

        public static ContentTitleFilterByCommand ContentTitleFilterBy(string v)
        {
            ////return new ContentTitleFilterByCommand();
            //Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div[2]/button/span[2]"));
            //Driver.clickEleJs(By.XPath("//span[@class='text'][contains(text(),"+v+")]"));
            { return new ContentTitleFilterByCommand(v); }

        }

        public static bool? isSavedDataDisplayedinResult(string v)
        {
            return Driver.existsElement(By.XPath("//h4[text()='" + v + "']"));
        }

        public static void ContentStatusFilterByNotStarted()
        {
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/div/ul/li/a"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/button/span[2]"));
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/div/ul/li[2]/a/span[2]"));
        }

        public static void ContentStatusFilterByStarted()
        {
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/div/ul/li/a/span[2]"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/div/ul/li[3]/a/span[2]"));
        }

        public static void ContentStatusFilterByCompleted()
        {
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/div/ul/li[3]/a"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/button/span[2]/span"));
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div/div/ul/li/a/span[2]"));
        }

        public static bool? ContentType()
        {
            return Driver.existsElement(By.XPath("//div[@id='saved-content']/div[2]/div/ul/li/a/div[2]/h4/small"));
        }

        public static void ContentList()
        {
            Driver.existsElement(By.XPath("//div[@id='saved-content']/div[2]/div/ul/li/a/div/h4"));
        }
    }

    public class ContentlistCommand
    {
   
    }

    public class ContentTitleFilterByCommand
    {
        private string v;
        private string k;

        public ContentTitleFilterByCommand(string v)
        {
           // this.usernme = username;
            this.v = v;
        }

        public ContentTitleFilterByCommand Sorting(string k)
        {
            this.k = k;
            return this;
        }

        public bool? VerifySorting()
        {
            string title = "";
            string order = "";



            title = Driver.GetElement(By.XPath("//button[@id='saved-content-sort-order'][@title=" + k + "]/span")).Text;

            order = Driver.GetElement(By.XPath("//span[@class='text'][contains(text(),"+v+")]")).Text;

            if (title == k && order == v )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ContentTitleCommand
    {
        public void AToZAssesdingOrder()
        {
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div[2]/button/span[2]"));
            Driver.clickEleJs(By.XPath("//span[@class='text'][contains(text(),'Title')]"));
        }

        public bool? isFilteredIn(string v)
        {
            string DropDown = "";
            string order = "";



             order=Driver.GetElement(By.XPath("//button[@id='saved-content-sort-order'][@title="+v+"]/span")).Text;

            string title = Driver.GetElement(By.XPath("//span[@class='text'][contains(text(),'Title')]")).Text;

            if (DropDown == title && v==order)
            {
                return true;
            }
            else
            {
                return false;
                    }

            }

        public void ZToADescendingOrder()
        {
            Driver.clickEleJs(By.XPath("//div[@id='saved-content']/div/div[2]/button/span[2]"));
            Driver.clickEleJs(By.XPath("//span[@class='text'][contains(text(),'Title')]"));

        }

  

        public bool? ContentTypeDocument(string FormatDocument)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div/div[1]/ul/li[1]/strong")).Text.Equals(FormatDocument);

        }

        public bool? ContentTypeGenaralCourse(string FormatGeneralCourse)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatGeneralCourse);

        }

        public bool? ContentTypeAICC(string FormatAICCCourse)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatAICCCourse);

        }

        public bool? ContentTypeScormCourse(string FormatScormCourse)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatScormCourse);

        }

        public bool? ContentTypeSurvey(string FormatSurvey)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatSurvey);

        }

        public bool? ContentTypeCurriculum(string FormatCurriculum)
        {
            return Driver.GetElement(By.XPath("//div[@id='bannerDiv']/div/div/p")).Text.Equals(FormatCurriculum);

        }

        //public bool? ContentTypeCertification(string FormatCurriculum)
        //{
        //    return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatCurriculum);

        //}

        public bool? ContentTypeBundle(string FormatBundle)
        {
            return Driver.GetElement(By.XPath("//ul[@class='list-inline']//strong[contains(text(),'Bundle')]")).Text.Equals(FormatBundle);
        }

        public bool? ContentTypeSubscription(string FormatSubscription)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatSubscription);

        }

        public bool? ContentTypeOJT(string FormatOJT)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatOJT);

        }

        public bool? ContentTypeClassroom(string FormatClassroom)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(FormatClassroom);

        }

        public bool? ContentTypeCertification(string formatCertification)
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[1]/div/ul/li[1]/strong")).Text.Equals(formatCertification);

        }
    }
}