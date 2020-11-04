using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class SF182RequestDetailsPage
    {
        public static sfContentBannerCommand ContentBanner { get { return new sfContentBannerCommand(); } }

        public static aboutThisSf182RequestCommand aboutThisSf182Request { get { return new aboutThisSf182RequestCommand(); } }

        public static RequstDetailsTabCommand RequstDetailsTab { get { return new RequstDetailsTabCommand(); } }

        public static bool? isSubmitbuttondisplay()
        {
            return Driver.existsElement(By.XPath("//a[@id='submit-form']"));
        }

        public static bool? isSavebuttondisplay()
        {
            throw new NotImplementedException();
        }

        public static void clickRequstDetailsTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='requestDetailsLink']"));
        }

        public static void ClickSubmitbutton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='submit-form']"));
        }
    }

    public class RequstDetailsTabCommand
    {
        public RequstDetailsTabCommand()
        {
        }

        public aboutThisSf182RequestCommand aboutThisSf182Request { get { return new aboutThisSf182RequestCommand(); } }

        public TrainingDetailsCommand TrainingDetails { get { return new TrainingDetailsCommand(); } }

        public bool? isSavebuttondisplay()
        {
            return Driver.existsElement(By.LinkText("Save"));
        }
    }

    public class TrainingDetailsCommand
    {
        public TrainingDetailsCommand()
        {
           
        }

        public bool isTrainingDutyFieldisEnabled()
        {
            Driver.existsElement(By.XPath("//input[@id='TrainingDutyHours']"));
            return Driver.GetElement(By.XPath("//input[@id='TrainingDutyHours']")).Enabled;
        }
    }

    public class sfContentBannerCommand
    {
        public sfContentBannerCommand()
        {
        }

        public bool? Title(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='sf182Details']/div/div[2]/div/div/div/h1"));
            return Driver.GetElement(By.XPath("//div[@id='sf182Details']/div/div[2]/div/div/div/h1")).Text.Equals(v);
        }
    }
}