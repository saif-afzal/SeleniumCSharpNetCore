using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CustomBlockDetailsPage
    {
        public static string GetSuccessmessage()
        {
            return Driver.getSuccessMessage();
        }

        public static void Edit_Heading()
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-heading']"));
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div/div/div[2]/span/div/form/div/div/div/input")).Clear();
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div/div/div[2]/span/div/form/div/div/div/input")).SendKeysWithSpace("Edited Heading");
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));


        }

        public static string Heading()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-heading']")).Text;
        }

        public static void Edit_Caption()
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-caption']"));
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[2]/div/div[2]/span/div/form/div/div/div/input")).Clear();
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[2]/div/div[2]/span/div/form/div/div/div/input")).SendKeysWithSpace("Edited Caption");
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));

        }

        public static string Caption()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-caption']")).Text;

        }

        public static void Edit_ButtonLabel()
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-btn']"));
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[3]/div/div[2]/span/div/form/div/div/div/input")).Clear();
            Driver.GetElement(By.XPath("//div[@id='custom-details']/div[4]/div[3]/div/div[2]/span/div/form/div/div/div/input")).SendKeysWithSpace("Edited Button Label");
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));

        }

        public static void Edit_Title()
        {
            Driver.clickEleJs(By.XPath("//h1[@id='custom-title-heading']/a"));
            Driver.GetElement(By.XPath("//h1[@id='custom-title-heading']/span/div/form/div/div/div/input")).Clear();
            Driver.GetElement(By.XPath("//h1[@id='custom-title-heading']/span/div/form/div/div/div/input")).SendKeysWithSpace("Edited Title");
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        }

        public static bool? isButtonVisible()
        {
            return Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/p")).Displayed;
        }



        public static bool? VerifyHeadingEdited(string editedHeading)
        {
            return Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/div/h1")).Text.Equals(editedHeading);

        }



        public static string Title()
        {
            return Driver.GetElement(By.XPath("//h1[@id='custom-title-heading']/a")).Text;
        }

        public static bool? VerifyCaptionEdited(string editedCaption)
        {
            return Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/div/p")).Text.Equals(editedCaption);

        }

        public static bool? VerifyTitleEdited(string editedTitle)
        {
            return Driver.GetElement(By.XPath("//h1[@id='custom-title-heading']/a")).Text.Equals(editedTitle);

        }

        public static void Cancel()
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-action-cancel']"));
            Thread.Sleep(5000);
        }

        public static void Save()
        {
            Driver.clickEleJs(By.XPath("//button[@id='custom-action-save']"));
        }

        public static void TemplateView2()
        {
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[3]/div/div/div[3]/ul/li[2]/label/b"));
        }

        public static void TemplateView3()
        {
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[3]/div/div/div[3]/ul/li[3]/label/b/b[2]"));
        }

        public static void TemplateView4()
        {
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[3]/div/div/div[3]/ul/li[4]/label/b"));
        }

        public static void TemplateView1()
        {
            Driver.clickEleJs(By.XPath("//b[@class='template-fg flex-1']"));

        }

        public static void EditHeading(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-heading']"));
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[4]/div/div/div[2]/span/div/form/div/div/div[2]/button/i"));

        }

        public static bool? VerifyHeading()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-heading']")).Text.Equals(Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/div/h1")).Text);
        }

        public static void EditCaption(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-caption']"));
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));

        }

        public static bool? VerifyCaption()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-caption']")).Text.Equals(Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/div/p")).Text);

        }

        public static bool? VerifyButtonLabel()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-btn']")).Text.Equals(Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/p")).Text);

        }

        public static void ClickBreadcrumb()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[4]/a"));
        }
    }

}