using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class EquivalenciesPage
    {
        public static AddEquvalenciesModalCommand AddEquvalenciesModal { get { return new AddEquvalenciesModalCommand(); } }

        public static ResultgridCommand Resultgrid { get { return new ResultgridCommand(); } }

        public static string GetSuccessMessage()
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public static bool? isSearchFiledsdisplay()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_lblSearchFor"));
                Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlSearch']/div[2]/div[2]/label"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save"));
                result = true;
            }
            catch { }
            return result;
        }

        public static void ClickAddEquivalencies()
        {
            Driver.clickEleJs(By.XPath("//a[@id='empty-equiv-add']"));
        }

        public static bool? isEquivalenciesadded()
        {
            return Driver.existsElement(By.XPath("//table[@id='content-equivalency']//td/input"));
        }

        public static void removeAddedEquivalencies()
        {

            Driver.existsElement(By.XPath("//td[1]/input"));
            Driver.clickEleJs(By.XPath("//td[1]/input"));
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Remove')]"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-equivalency']"));
            //Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }

        public static void ClickViewAsLearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static bool? isExestingEquvalencyContentdisplay(string v)
        {
            Driver.existsElement(By.XPath("//strong[contains(text(),'NoAssignedEquivalencies')]"));
            if (v == "No")
            {
                return Driver.GetElement(By.XPath("//strong[contains(text(),'NoAssignedEquivalencies')]")).Text.Equals("NoAssignedEquivalencies");
            }
            else if (v == "Yes")
            {
                return true;
            }
            else return false;
        }

        public static void ClickAddEquivalencyButton()
        {
            if (Driver.GetElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']")).Text.Equals("Checkout"))
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            }
            Driver.existsElement(By.XPath("//a[@id='empty-equiv-add']"));
            Driver.clickEleJs(By.XPath("//a[@id='empty-equiv-add']"));
        }

        public static bool? isAddEquvalenciesModalDisplay()
        {
            return Driver.existsElement(By.XPath("//h4[contains(text(),'Add Equivalencies')]"));
        }

        public static string Content()
        {
           string con= Driver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div/h2")).Text;
            string[] conlist = Regex.Split(con,"\r\n");
            return conlist[0];
        }

        public static bool? RemoveButtonEnabled()
        {
            return Driver.GetElement(By.XPath("//button[@id='equiv-toolbar-remove']")).Enabled;
        }

        public static void RemoveEquivalencies()
        {
            
            Driver.clickEleJs(By.XPath("//button[@id='equiv-toolbar-remove']"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-equivalency']"));
            Thread.Sleep(2000);
        }

        public static string RemoveSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static void ClickBreadcrumb_ContentTitle(string contenttitle)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+contenttitle+"')]"));
        }

        public static string Equivalency()
        {
            string con = Driver.GetElement(By.XPath("//div[@id='contentDetailsHeader']/div/h2")).Text;
            string[] conlist = Regex.Split(con, "\r\n");
            return conlist[0];
        }
    }

    public class ResultgridCommand
    {
        public ResultgridCommand()
        {
        }

        public bool? isRelationship(string v)
        {
            return Driver.GetElement(By.LinkText("2-way")).Text.Equals(v);
        }

        public bool? VerifyEquivalencyContentdisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'" + v + "')]")); 
        }

        public bool? VerifyDateAddedDisplayed()
        {
            return Driver.existsElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td[5]"));
        }

        public bool? VerifyRelationship(string v)
        {
            Thread.Sleep(5000);
            return Driver.GetElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td[4]/div/div/a")).Text.Equals(v);
        }

        public void Click_Relationship()
        {
            Driver.clickEleJs(By.XPath("//table[@id='content-equivalency']/tbody/tr/td/div/div/a"));
        }                               

        public bool? VerifyDropdownDisplayed(string v)
        {
            string con = Driver.GetElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td/div/div/span/div/form/div/div/div/select")).Text;
            string[] conlist = Regex.Split(con, "\r\n");
            return conlist[0].Contains(v)|| conlist[1].Contains(v) || conlist[2].Contains(v);
            //return Driver.GetElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td[3]/div/div/span/div/form/div/div/div/select")).Text.Contains(v);
        }

        public void Select(string v)
        {
            Driver.select(By.XPath("//table[@id='content-equivalency']/tbody/tr/td/div/div/span/div/form/div/div/div/select"),v);
            Driver.clickEleJs(By.XPath("//table[@id='content-equivalency']/tbody/tr/td/div/div/span/div/form/div/div/div[2]/button[1]/span"));
        }

   

        public void Click_1WayRelationship()
        {
            throw new NotImplementedException();
        }

        public bool? isEquivalenciesadded(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'"+v+"')]"));
        }

        public void SelectFirstContent()
        {
            Driver.clickEleJs(By.XPath("//table[@id='content-equivalency']/tbody/tr[1]/td/input"));
        }

        public void SelectAllEquivalenciesContent()
        {
            Driver.clickEleJs(By.XPath("//table[@id='content-equivalency']/thead/tr/th/div/input"));
        }

        public void click_ApplaytoManagelinkof(string equivalencyName)
        {
            Driver.clickEleJs(By.XPath("//td[contains(text(),'" + equivalencyName + "')]/following::a[contains(text(),'Manage')]"));
            //Driver.clickEleJs(By.XPath("//table[@id='content-equivalency']/tbody/tr/td[4]/small/a"));
        }

        public bool? verifyquivalenciesApplayedto(string v, string equivalencyName)
        {
            if (v.Equals("Job Titles"))
            {
                Thread.Sleep(5000);
                string ManageUserText = Driver.GetElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td[5]/span")).Text;
                ManageUserText.Contains(v);
                if (Driver.getIntegerFromString(ManageUserText) == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (v.Equals("Organization"))
            {
                string ManageUserText = Driver.GetElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td[5]/span")).Text;
                ManageUserText.Contains(v);
                if (Driver.getIntegerFromString(ManageUserText) == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (v.Equals("User"))
            {
                string ManageUserText = Driver.GetElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td[5]/span")).Text;
                ManageUserText.Contains(v);
                if (Driver.getIntegerFromString(ManageUserText) == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool? VerifyDescriptionText(string v)
        {
            return Driver.GetElement(By.XPath("//table[@id='content-equivalency']/tbody/tr/td/div/div/small")).Text.Equals(v);
        }
    }

    public class AddEquvalenciesModalCommand
    {
        public AddEquvalenciesModalCommand()
        {
        }

        public bool? VerifymodalComponets(string v1, string v2, string v3, string v4, string v5)
        {
            Driver.existsElement(By.XPath("//input[@id='searchFor']"));
            Driver.existsElement(By.XPath("//table[@id='table-equiv-add']/tbody/tr/td[2]"));
            Driver.existsElement(By.Id("showInActiveContent"));
            return Driver.existsElement(By.XPath("//div[@id='equiv-add']/div/div/div[5]/button"));
        }

        public void ClickSearch()
        {
            Driver.existsElement(By.XPath("//a[@id='btn-content-search']/span"));
            Driver.clickEleJs(By.XPath("//a[@id='btn-content-search']/span"));
            Thread.Sleep(5000);
        }

        public string FistrecordTitle()
        {
            return Driver.GetElement(By.XPath("//table[@id='table-equiv-add']/tbody/tr/td[2]")).Text;
        }

        public void SelectandAddFirstrecord()
        {
            Driver.clickEleJs(By.XPath("//a[@id='btn-content-search']/span"));
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//table[@id='table-equiv-add']/tbody/tr/td/input"));
            Driver.clickEleJs(By.Id("equiv-modal-add"));
            Thread.Sleep(5000);
        }

        public void AddEquivalencies(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//a[@id='btn-content-search']/span"));
            Driver.clickEleJs(By.XPath("//td[contains(text(),'"+v+"')]/preceding::input[1]"));
            Driver.clickEleJs(By.XPath("//button[@id='equiv-modal-add']"));
        }

        public void AddAllContentAsEquivalencies()
        {
            Driver.clickEleJs(By.XPath("//input[@id='btSelectAll_table-equiv-add']"));
            Driver.clickEleJs(By.XPath("//button[@id='equiv-modal-add']"));

        }
    }
}