using System;
using System.Threading;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class ManageContentPage
    {
        public static Filtercommand filtersearch { get { return new Filtercommand(); } }

        public static ResultGridCommand ResultGrid { get { return new ResultGridCommand(); } }

        public static ExpandedSectiondetailsCommand ExpandedSectiondetails { get { return new ExpandedSectiondetailsCommand(); } }

        public static void SelectMultipleResult()
        {
            throw new NotImplementedException();
        }

        public static void ClickAddTagOption_Select_DV_Test1()
        {
            throw new NotImplementedException();
        }

        public static string VerifyTags(string v)
        {
            throw new NotImplementedException();
        }

        public static void RemoveTag()
        {
            throw new NotImplementedException();
        }

        public static void ClickContentTitle(string s)
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'"+s+"')]"));
            //Driver.clickEleJs(By.XPath("//a[contains(text(),'" + s + "')]"));
        }

        public static void allSearch()
        {
            Driver.clickEleJs(By.XPath("//a[@id='btnSearch']"));
            Thread.Sleep(5000);
        }

        public static string verifyElements()
        {
            Driver.Instance.IsElementVisible(By.XPath("//h1[contains(.,'Manage Content')]"));
            Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Title')]"));
            Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Status')]"));
            Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Cost')]"));
            Driver.Instance.IsElementVisible(By.XPath("//table[@id='table-manage-content']/thead/tr/th[6]/div"));
            Driver.Instance.IsElementVisible(By.XPath("//table[@id='table-manage-content']/thead/tr/th[7]/div"));
            Driver.Instance.IsElementVisible(By.XPath("//table[@id='table-manage-content']/thead/tr/th[8]/div"));
            Driver.Instance.IsElementVisible(By.XPath("//input[@name='btSelectAll']"));
            Driver.Instance.IsElementVisible(By.XPath("//input[@data-index='0']"));
            Driver.Instance.IsElementVisible(By.XPath("//a[@href='#panel_CNT_CREDITS']"));
            Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'›')]"));
            Driver.Instance.IsElementVisible(By.XPath("//button[contains(.,'10 ')]"));
            Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
            Thread.Sleep(2000);
            Driver.Instance.IsElementVisible(By.XPath("//button[@data-id='selectAddContentTags']"));
            Driver.Instance.IsElementVisible(By.XPath("//button[@data-id='selectRemoveContentTags']"));
            Driver.Instance.IsElementVisible(By.XPath("//table[@id='table-manage-content']/tbody/tr/td/a/i"));
            Driver.clickEleJs(By.XPath("//table[@id='table-manage-content']/tbody/tr/td/a/i"));
            Driver.Instance.IsElementVisible(By.XPath("//a[contains(text(),'Section1')]"));
            string title = Driver.Instance.Title;
            return title;

        }

        public static bool search_WithingManageContentPage(string v)
        {
            bool result = false;
            try
            {
                Driver.Instance.GetElement(By.XPath("//input[@id='txtSearchContent']")).SendKeysWithSpace('"'+v+'"');
                Driver.clickEleJs(By.XPath("//button[@data-bind='click: $root.searchClick']"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'" + v + "')]"));
                result = true;
            }catch(Exception e)
            {

            }
            return result;
            
        }

        public static void ClickFirstContentTitle()
        {
            Driver.clickEleJs(By.XPath("//table[@id='table-manage-content']/tbody/tr[1]/td[3]/a"));
        }

        public static void Clickflitersearch()
        {
            Driver.clickEleJs(By.XPath("//div[@class='col-xs-12 col-md-4 float-md-right']//button[@class='btn btn-default']"));
        }

        public class Filtercommand
        {
            public void Searchfortext(string v)
            {
                Driver.Instance.GetElement(By.XPath("//input[@id='txtSearchContent']")).Clear();

                Driver.clickEleJs(By.XPath("//input[@id='txtSearchContent']"));

                Driver.Instance.GetElement(By.XPath("//input[@id='txtSearchContent']")).SendKeys(v);
                Thread.Sleep(5000);

            }
        }
    }

    public class ExpandedSectiondetailsCommand
    {
        public ExpandedSectiondetailsCommand()
        {
        }

        public bool? VerifyEventScheduleText(string v)
        {
            return Driver.GetElement(By.XPath("//td/div/div[2]/div[2]/table/tbody/tr/td[2]")).Text.Contains(v);
        }
    }

    public class ResultGridCommand
    {
        public ResultGridCommand()
        {
        }

        public bool? isSeaarchedContentDisplay(string v)
        {
            return Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
        }

        public void ClickCourseExpander(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]/preceding::a[1]"));
        }
    }
}