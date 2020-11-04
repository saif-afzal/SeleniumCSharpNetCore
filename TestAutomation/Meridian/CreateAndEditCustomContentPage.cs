using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CreateAndEditCustomContentPage
    {
        public static DetailsTabCommand DetailsTab { get { return new DetailsTabCommand(); } }

        public static void EditCustomContentTitle(string v)
        {
            Driver.clickEleJs(By.XPath("//h1[@id='custom-title-heading']/a"));
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//h1[@id='custom-title-heading']/span/div/form/div/div/div[2]/button/i"));
        }
    }

    public class DetailsTabCommand
    {
        public void TemplateView2()
        {
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[3]/div/div/div[3]/ul/li[2]/label/b"));
        }

        public void TemplateView3()
        {
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[3]/div/div/div[3]/ul/li[3]/label/b/b[2]"));
        }

       
        public void TemplateView1()
        {
            Driver.clickEleJs(By.XPath("//b[@class='template-fg flex-1']"));

        }
        public void TemplateView4()
        {
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[3]/div/div/div[3]/ul/li[4]/label/b"));

        }


        public void EditHeading(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-heading']"));
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[@id='custom-details']/div[4]/div/div/div[2]/span/div/form/div/div/div[2]/button/i"));

        }

        public bool? VerifyHeading()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-heading']")).Text.Equals(Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/div/h1")).Text);

        }

        public void EditCaption(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-caption']"));
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));

        }

        public bool? VerifyCaption()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-caption']")).Text.Equals(Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/div/p")).Text);
        }

        public void EditButtonLabel(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-setting-btn']"));
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//div[@class='xeditable-input']//input[@type='text']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        }

        public bool? VerifyButtonLabel()
        {
            return Driver.GetElement(By.XPath("//a[@id='custom-setting-btn']")).Text.Equals(Driver.GetElement(By.XPath("//div[@id='preview-full']/div/div/div/p")).Text);

        }

        public void Cancel()
        {
            Driver.clickEleJs(By.XPath("//a[@id='custom-action-cancel']"));
        }

        public void Save()
        {
            Driver.clickEleJs(By.XPath("//button[@id='custom-action-save']"));
        }
    }
}