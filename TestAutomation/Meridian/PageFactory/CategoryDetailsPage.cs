using MeridianFramework.Training;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CategoryDetailsPage
    {
        public static bool? SetLocalized(string v)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//div[@id='loading-area']/ul/li/div/button"));
                Driver.select(By.XPath("//div[@id='loading-area']/ul/li/div/select"), v);
                //Driver.clickEleJs(By.XPath("//span[contains(.,'" + v + "')]"));
                result = true;

            }
            catch { }
            return result;
        }

        public static string GetCategoryTitle()
        {
            return Driver.GetElement(By.XPath("//div[@id='loading-area']/h1/a")).Text;
        }

        public static void EditCategory(string title, string Des)
        {
            Driver.existsElement(By.XPath("//div[@id='loading-area']/h1/a"));
            Driver.clickEleJs(By.XPath("//div[@id='loading-area']/h1/a"));
            Driver.GetElement(By.XPath("//input[@type='text']")).Clear();
            Driver.GetElement(By.XPath("//input[@type='text']")).SendKeysWithSpace(title);
            Driver.clickEleJs(By.XPath("//div[@id='loading-area']/h1/span/div/form/div/div/div[2]/button/span"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//div[@id='summary']/div/div/div[2]/div/a"));
            Driver.GetElement(By.XPath("//div[@id='summary']/div/div/div[2]/div/span/div/form/div/div/div/textarea")).Clear();
            Driver.GetElement(By.XPath("//div[@id='summary']/div/div/div[2]/div/span/div/form/div/div/div/textarea")).SendKeysWithSpace(Des);
            Driver.clickEleJs(By.XPath("//div[@id='summary']/div/div/div[2]/div/span/div/form/div/div/div[2]/button/span"));
            Thread.Sleep(5000);
        }

        public static bool? isCategoryTitleupdated(string v1, string v2)
        {
            return Driver.GetElement(By.XPath("//div[@id='loading-area']/h1/a")).Text.Equals(v2);
        }

        public static void UploadImage(string filepath)
        {
            Driver.Instance.navigateAICCfile("Data\\image.jpg", By.XPath("//input[@id='uploadFile']"));
            Thread.Sleep(3000);
           // Driver.Instance.uploadFile(filepath, By.XPath("//input[@id='uploadFile']"));
           // Thread.Sleep(5000);
            Driver.clickEleJs(By.LinkText("Upload"));
        }
    }
}