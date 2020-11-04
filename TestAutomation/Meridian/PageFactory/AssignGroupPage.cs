using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class AssignGroupPage
    {
        public static SearchGroupsCommand SearchGroups
        {
            
                get{ return new SearchGroupsCommand(); }
        }

        public static SearchRecordsCommand SearchRecords
        {
            get { return new SearchRecordsCommand(); }
        }
        public static void SelectUserGroupFilter()
        {

            Driver.clickEleJs(By.XPath(".//*[@id='filter-group']/div/div[1]/div/div/div/button"));
            Driver.clickEleJs(By.XPath(".//*[@id='RoleType']/li[4]/a"));
            Thread.Sleep(3000);
            Driver.clickEleJs(By.Id("btn-search-entities"));
            //Driver.hoverLink(".//*[@id='filter-group']/div/div[1]/div/div/div/button", ".//*[@id='RoleType']/li[4]/a");
        }

        public static void SelectSearchRecord()
        {
            Thread.Sleep(2000);
            //Driver.clickEleJs(By.XPath("//input[@data-index='0']")); ////input[@id='btSelectItem_ML.BASE.ORG.Sample1']
            Driver.clickEleJs(By.XPath("//table[@id='find-entities-table']/thead/tr/th/div/input"));
          
        }

        public static void ClickAssignButton()
        {
            Driver.clickEleJs(By.XPath(".//*[@id='btn-add-entities']"));
        }

        public static void SelectOrganizationFilter()
        {
            Driver.clickEleJs(By.XPath(".//*[@id='filter-group']/div/div[1]/div/div/div/button"));
            Driver.clickEleJs(By.XPath(".//*[@id='RoleType']/li[3]/a"));
            Thread.Sleep(2000);

        }
        public static void SelecJobtitleFilter()
        {
            Driver.clickEleJs(By.XPath(".//*[@id='filter-group']/div/div[1]/div/div/div/button"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Job Title')]"));
            Thread.Sleep(2000);

        }

        public static void ClickIncludeSubOrganizations(string v)
        {
           if(v=="Yes")
            {
                Driver.clickEleJs(By.XPath("//span[@class='bootstrap-switch-handle-off bootstrap-switch-default']"));
            }
           else
            {

            }
        }

        public static void SelectAllTypeFilter()
        {
            throw new NotImplementedException();
        }

        public static void SelectJobTitleFilter()
        {
            Driver.clickEleJs(By.XPath(".//*[@id='filter-group']/div/div[1]/div/div/div/button"));
            Driver.clickEleJs(By.XPath(".//*[@id='RoleType']/li[2]/a"));
            Thread.Sleep(2000);
        }

        public static void ClickSelectAllinPage1()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//table[@id='find-entities-table']/thead/tr/th/div/input"));
        }

        public static void SelectFirstRecord()
        {
            Driver.clickEleJs(By.XPath("//table[@id='find-entities-table']/tbody/tr/td/input"));
        }

        
    }

    public class SearchRecordsCommand
    {
        public SearchRecordsCommand()
        {
        }

        public void ClickSelectAllbutton()
        {
            throw new NotImplementedException();
        }

        public void SearchRecord(string title="")
        {
          
            Driver.clickEleJs(By.XPath("//table[@id='find-entities-table']/tbody/tr/td/input"));
        }

        public void SelectFirstRecord()
        {
            Driver.existsElement(By.XPath("//table[@id='find-entities-table']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//table[@id='find-entities-table']/tbody/tr/td/input"));
        }
    }

    public class SearchGroupsCommand
    {
        public SearchGroupsCommand()
        {
        }

        public void EnterSearchGroupstext(string v)
        {
            if (!(v == null))
            {
                Thread.Sleep(2000);
                Driver.GetElement(By.XPath("//input[@id='SearchFor-entities']")).SendKeysWithSpace(v);
                Driver.clickEleJs(By.XPath(".//*[@id='btn-search-entities']"));
                Thread.Sleep(2000);
            }
            else
            {
                Thread.Sleep(2000);
               // Driver.GetElement(By.XPath("//input[@id='SearchFor-entities']")).SendKeysWithSpace(v);
                Driver.clickEleJs(By.XPath(".//*[@id='btn-search-entities']"));
                Thread.Sleep(2000);
            }
        }

        public void ClickSearchbutton(string title="")
        {
            Driver.GetElement(By.Id("SearchFor-entities")).SendKeysWithSpace(title);
            Driver.clickEleJs(By.XPath("//a[@id='btn-search-entities']/i"));
            Thread.Sleep(2000);
        }
    }

 

      

    }