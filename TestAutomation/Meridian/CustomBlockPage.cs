using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CustomBlockPage
    {
        public static Panels Panels { get { return new Panels(); } }

        public static bool? VerifyAlertBox()
        {
            //Driver.waitforframe();
            return Driver.existsElement(By.XPath("//h4[@class='modal-title']"));
        }

        public static void AlertBoxCancel()
        {
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//div[@id='remove-block-modal']/div/div/div[3]/button[1]"));
            Driver.Instance.SwitchtoDefaultContent();
        }

        public static void AlertBoxDelete()
        {
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//div[@id='remove-block-modal']/div/div/div[3]/button[2]"));
            Driver.Instance.SwitchtoDefaultContent();
        }

        public static string Successmessage()
        {
            return Driver.getSuccessMessage();
        }

        public static bool? isUserDomainDisplayed()
        {
            string UserDomain = Driver.GetElement(By.XPath("//span[@class='filter-option pull-left']")).Text;
            return UserDomain.Contains("Core Domain");

        }

        public static bool? isCustomBlockPageDisplayed()
        {
            return Driver.existsElement(By.XPath("//h1[contains(text(),'Custom Block')]"));
        }
    }

    public class Panels
    {
        public void SelectCustomBlock(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]/preceding::input[1]"));
        }

        public void Delete()
        {
            Driver.clickEleJs(By.XPath("//button[@id='custom-panels-delete']"));
        }

        public bool? VerifyCustomBlockDeleted(string v)
        {
            return Driver.existsElement(By.XPath("//a[contains(text()," + v + ")]/preceding::input[1]"));
        }

        public void DragandDrop_CustomBlocks()
        {
            Thread.Sleep(5000);
           Actions ac = new Actions(Driver.Instance);
            ac.DragAndDrop(Driver.Instance.FindElement(By.XPath("//tr[@id='customId_0']")), Driver.Instance.FindElement(By.XPath("//tr[@id='customId_2']")));
            ac.Build().Perform();
        }

        public void SelectCustomBlockToEdit()
        {
            Driver.clickEleJs(By.XPath("//tr[@id='customId_0']/td[3]/a"));
        }

        public void CreatePanel()
        {
            Driver.clickEleJs(By.XPath("//div[@class='col-xs-6 text-right']//a[@class='btn btn-primary'][contains(text(),'Create Panel')]"));
        }

        public void SelectAllCustomBlock()
        {
            Driver.clickEleJs(By.XPath("//tr[4]/td[3]"));
        }

        public void SelectFirstCustomBlock()
        {
            Driver.clickEleJs(By.XPath("//tr[@id='customId_0']/td/input"));
        }
    }
}