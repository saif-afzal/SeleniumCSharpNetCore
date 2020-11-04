using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CreatePanelPage
    {
        public static HeadingCommand Heading { get { return new HeadingCommand(); } }

        public static CaptionCommand Caption { get { return new CaptionCommand(); } }

        public static ButtonLabelCommand ButtonLabel { get { return new ButtonLabelCommand(); } }
        public static Hyperlink Hyperlink { get { return new Hyperlink(); } }

        public static BackgroundImageCommand BackgroundImage { get { return new BackgroundImageCommand(); } }
        public static BackgroundVideoCommand BackgroundVideo { get { return new BackgroundVideoCommand(); } }

        public static bool? isCreatePanelDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='content']/div/h1"));
        }

        public static bool? isLocalizationDisplayed()
        {
            return Driver.existsElement(By.XPath("//span[@class='filter-option pull-left'][contains(text(),'English (US)')]"));
        }

        public static bool? isStatusDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@id='loading-area']/div/div/ul/li[2]/div/div/span")).Text == "Visible";
        }

        public static void FillTitle(string v)
        {
            Driver.clickEleJs(By.XPath("//h1[@id='custom-title-heading']/a"));
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        }

        public static void Save()
        {
            Driver.clickEleJs(By.XPath("//button[@id='custom-action-save']"));
        }
    }

    public class BackgroundVideoCommand
    {
        public void AddBackgroundVideo(string v)
        {
            //Driver.clickEleJs(By.XPath("//h1[@id='custom-title-heading']/a"));
            Driver.GetElement(By.XPath("//input[@id='custom-setting-video']")).SendKeysWithSpace(v);
            Thread.Sleep(10000);
            Driver.existsElement(By.XPath("//span[@title='Update video']"));
            Driver.clickEleJs(By.XPath("//span[@title='Update video']"));
            Thread.Sleep(5000);
        }
    }

    public class BackgroundImageCommand
    {       
        public void AddBackgroundImage()
        {

            Driver.clickEleJs(By.XPath("//input[@id='custom-setting-img']"));
            //Driver.Instance.navigateAICCfile("Data\\Flower1.JPEG", By.XPath("//input[@id='custom-setting-img-value']"));
           
            Driver.clickEleJs(By.XPath("//input[@id='custom-setting-img']"));

            Driver.clickEleJs(By.XPath("//a[@title='Upload selected files']"));

        }
    }

    public class Hyperlink
    {
        public void AddhHyperlink(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-link']"));
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[5]/div/div/div[2]/span/div/form/div/div/div/input")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        }
    }

    public class ButtonLabelCommand
    {
        public void FillButtonLabel(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-btn']"));
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[3]/div/div[2]/span/div/form/div/div/div/input")).Clear();

            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[3]/div/div[2]/span/div/form/div/div/div/input")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        }
    }

    public class CaptionCommand
    {
        public void FillCaption(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-caption']"));
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[2]/div/div[2]/span/div/form/div/div/div/input")).Clear();

            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[2]/div/div[2]/span/div/form/div/div/div/input")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        }
    }

    public class HeadingCommand
    {
        public void FillHeading(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-heading']"));
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div/div/div[2]/span/div/form/div/div/div/input")).Clear();

            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div/div/div[2]/span/div/form/div/div/div/input")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//i[@class='fa fa-check']"));
        }
    }
}