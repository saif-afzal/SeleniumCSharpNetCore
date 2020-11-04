using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ImportRosterPage
    {
      
        public static void DownloadTemplate()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("test-type");
            options.AddArguments("disable-popup-blocking");
            options.AddArgument("disable-extensions");
            options.AddUserProfilePreference("plugins.plugins_disabled", new[] {
                "Adobe Flash Player",
                "Chrome PDF Viewer"
            });

            object Downloads = null;
            //object TempDownloadFolder = null;
            options.AddUserProfilePreference("download.default_directory", "Downloads");

            

            
            Driver.clickEleJs(By.XPath("//div[@id='Roster']/ul/li[2]/a"));
        }
    }
}