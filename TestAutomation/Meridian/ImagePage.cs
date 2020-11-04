using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ImagePage
    {
        public static void UploadnewImageFile()
        {
            Driver.Instance.navigateAICCfile("Data\\test_image.jpg", By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_AsyncUpload1file0"));
            Thread.Sleep(3000);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Thread.Sleep(3000);
        }

        public static bool? verifyrequiredatributesdisplay()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.XPath("//div[@id='MainContent_pnlContent']/div/div/div[2]/label"));
                Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_AsyncUpload1file0"));
                result = Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save"));
             
            }
            catch
            { }
            return result;
        }
    }
}