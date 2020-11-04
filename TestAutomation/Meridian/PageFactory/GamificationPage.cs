using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class GamificationPage
    {
        public static PointsTabCommand PointsTab { get { return new PointsTabCommand(); } }
    }

    public class PointsTabCommand
    {
        public PointsTabCommand()
        {
        }

        public AddContentGemModalCommand AddContentModal { get { return new AddContentGemModalCommand(); } }

        public void Click_AddContentbutton()
        {
            Driver.clickEleJs(By.LinkText("Points"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//div[@id='has-content']/div/div[2]/div/button"));
            Driver.GetElement(By.XPath("//div[@id='find-content-modal']/div/div/div/h4")).Text.Equals("Add Content");
        }
    }

    public class AddContentGemModalCommand
    {
        public AddContentGemModalCommand()
        {
        }

        public bool? SelectAllandAddContents()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//table[@id='find-content']/thead/tr/th/div/input"));
                Driver.clickEleJs(By.Id("btn-add"));
                Driver.getSuccessMessage().Equals("The selected items are added");
                result= true;
            }
            catch { }
            return result;
        }
    }
}