using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;


namespace Selenium2.Meridian.Suite
{
    public class EquivalenciesManageGroupsEditPage
    {
        public static addUserModalCommand addUserModal { get { return new addUserModalCommand(); } }

        public static RemoveUsersModalCommand RemoveUsersModal { get { return new RemoveUsersModalCommand(); } }

        public static bool isExistingUseddisplay(string v)
        {
            if (v == "No")
            {
                Driver.existsElement(By.XPath("//div[@id='no-users']/div/p/strong"));
                return Driver.GetElement(By.XPath("//div[@id='no-users']/div/p/strong")).Text.Equals("This equivalency applies to All Users.");
            }
            else
                return false;
        }

        public static void Click_Changebutton()
        {
            Driver.clickEleJs(By.Id("empty-equiv-user-add"));
        }

        public static bool? isAddUsermodalOpened()
        {
            Driver.existsElement(By.XPath("//div[@id='equiv-user-add']/div/div/div/h4"));
            return Driver.GetElement(By.XPath("//div[@id='equiv-user-add']/div/div/div/h4")).Text.Equals("Add Users");
        }

        public static void click_Equivalencies_breadcrumb()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Equivalencies')]"));
        }

        public static void Selectuserentity()
        {
            Driver.clickEleJs(By.XPath("//input[@id='btSelectItem_undefined']"));
        }

        public static void Click_Remove()
        {
            Driver.clickEleJs(By.XPath("//button[@id='equiv-user-toolbar-remove']/span[2]"));
        }
    }

    public class RemoveUsersModalCommand
    {
        public RemoveUsersModalCommand()
        {

        }

        public bool? Confirmmessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='equiv-user-remove']/div/div/div[2]/p"));
            return Driver.GetElement(By.XPath("//div[@id='equiv-user-remove']/div/div/div[2]/p")).Text.Equals(v);
        }

        public void Click_Remove()
        {
            Driver.clickEleJs(By.Id("equiv-user-modal-remove"));

           

        }
    }

    public class addUserModalCommand
    {
        

        public addUserModalCommand()
        {
        }

        public allTypedrowdownCommand allTypedrowdown { get { return new allTypedrowdownCommand(); } }

        public void addUser(string v1, string v2)
        {
            if(v1.ToLower().Trim().Equals("job title"))
            {
                Driver.clickEleJs(By.XPath("//div[@id='filter-group']/ul/li/div/div/button"));
                Driver.clickEleJs(By.LinkText("Job Title"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-search']/span"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("//table[@id='table-equiv-user-add']/tbody/tr/td/input"));
                Driver.clickEleJs(By.Id("equiv-user-modal-add"));
            }
            if (v1.ToLower().Trim().Equals("organization"))
            {
                Driver.clickEleJs(By.XPath("//div[@id='filter-group']/ul/li/div/div/button"));
                Driver.clickEleJs(By.LinkText("Organization"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-search']/span"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("//table[@id='table-equiv-user-add']/tbody/tr/td/input"));
                Driver.clickEleJs(By.Id("equiv-user-modal-add"));
            }
            if (v1.ToLower().Trim().Equals("user"))
            {
                Driver.clickEleJs(By.XPath("//div[@id='filter-group']/ul/li/div/div/button"));
                Driver.clickEleJs(By.LinkText("User"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-search']/span"));
                Thread.Sleep(2000);
                Driver.clickEleJs(By.XPath("//table[@id='table-equiv-user-add']/tbody/tr/td/input"));
                Driver.clickEleJs(By.Id("equiv-user-modal-add"));
            }
        }

        public void ClickallTypedropdown()
        {
            Driver.clickEleJs(By.XPath("//div[@id='filter-group']/ul/li/div/div/button/span"));
        }

        public void Click_SelectAlltable()
        {
            Driver.clickEleJs(By.Id("btSelectAll_table-prereq-user-add"));
        }

        public void ClickAddbutton()
        {
            Driver.clickEleJs(By.Id("prereq-user-modal-add"));
            
        }
    }

    public class allTypedrowdownCommand
    {
        public allTypedrowdownCommand()
        {
        }

        public bool? islist(string v1, string v2, string v3)
        {
            Driver.GetElement(By.LinkText("Job Title")).Text.Equals(v1);
            Driver.GetElement(By.LinkText("Organization")).Text.Equals(v2);
            return Driver.GetElement(By.LinkText("User")).Text.Equals(v3);
        }
    }
}