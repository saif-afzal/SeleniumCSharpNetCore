using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ContentCategoriesPage
    {
        public static CategoryHierarchyTabCommand CategoryHierarchyTab { get { return new CategoryHierarchyTabCommand(); } }

        public static ContenttabCommand Contenttab { get { return new ContenttabCommand(); } }

        public static SearchTabCommand SearchTab { get { return new SearchTabCommand(); }  }

        public static void Click_CategoryHierarchyTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='hierarchy-tab']"));
        }
    }

    public class ContenttabCommand
    {
        public ContenttabCommand()
        {
        }

        public bool? VerifyContent()
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.Id("content-tab"));
                Driver.existsElement(By.Id("search-content")); //search input box
                Driver.GetElement(By.XPath("//table[@id='categories-content']/thead/tr/th/a")).Text.Equals("Title");
                Driver.GetElement(By.XPath("//table[@id='categories-content']/thead/tr/th[2]/a")).Text.Equals("Type");
                result = true;
            }
            catch { }
            return result;
        }
    }

    public class CategoryHierarchyTabCommand
    {
        public CategoryHierarchyTabCommand()
        {
        }

        public bool? isNewCategoryDisplay(string v)
        {
            return Driver.existsElement(By.XPath("//a[@id='hierarchy-tab']/following::a[contains(text(),'" + v + "')]"));

            //string Text = Driver.GetElement(By.XPath("//a[@id='hierarchy-tab']/following::a[contains(text(),'" + v + "'')]")).Text;
            //if(Text==v)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }

    public class SearchTabCommand
    {
        public SearchTabCommand()
        {
        }

        public void Click_CreateButton()
        {
            Driver.existsElement(By.Id("search-tab"));
            Driver.clickEleJs(By.Id("search-tab"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Create')]"));
        }

        public void SearchCategory(string v)
        {
            Driver.existsElement(By.Id("search-categories"));
            Driver.GetElement(By.Id("search-categories")).Clear();
            Driver.GetElement(By.Id("search-categories")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//div[2]/div/span/button/span"));
        }

        public bool? DeleteCategory(string v)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]/preceding::input[1]"));
                Driver.clickEleJs(By.XPath("//div[@id='utilityToolbar']/div/div/div/button/span"));
                Driver.clickEleJs(By.Id("btn-remove-content"));
                result= true;

            }
            catch { }
            return result;
        }

        public void Click_SearchedCategoryTitle(string v)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
        }
    }
}