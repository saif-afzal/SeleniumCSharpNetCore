using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class PrerequisitesManageGroupsEditPage
    {
        public static addUserModalCommand addUserModal { get { return new addUserModalCommand(); }  }

        public static bool? isMessagedisplay(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='no-users']/div/p/strong"));
            return Driver.GetElement(By.XPath("//div[@id='no-users']/div/p/strong")).Text.Equals(v);

        }

        public static void click_Changelink()
        {
            Driver.existsElement(By.LinkText("Change"));
            Driver.clickEleJs(By.LinkText("Change"));
        }

        public static bool? isAdduserModalopen(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='prereq-user-add']/div/div/div/h4"));
            return Driver.GetElement(By.XPath("//div[@id='prereq-user-add']/div/div/div/h4")).Text.Equals(v);
        }

        public static bool isApplaytoAllUsersbuttondisplay()
        {
            return Driver.existsElement(By.Id("all-users-button"));
        }

        public static int recordcount()
        {
            Driver.existsElement(By.XPath("//div[@id='has-users']/div[2]/div[2]/div[4]/div/span"));
            string count = Driver.GetElement(By.XPath("//div[@id='has-users']/div[2]/div[2]/div[4]/div/span")).Text;
            return Driver.getLastIntegerFromString(count);
        }

        public static void selecttworecord()
        {
            Driver.clickEleJs(By.Id("btSelectItem_undefined"));
            Driver.clickEleJs(By.XPath("//table[@id='table-prereq-user']/tbody/tr[2]/td/input"));
        }

        public static void RemoveselectedRecord()
        {
            Driver.clickEleJs(By.XPath("//button[@id='prereq-user-toolbar-remove']/span[2]"));
            Driver.clickEleJs(By.Id("prereq-user-modal-remove"));
            
        }
    }
}