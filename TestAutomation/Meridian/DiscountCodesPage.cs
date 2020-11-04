using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class DiscountCodesPage
    {
        public static void SearchCodeAndEditContent(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_DISCOUNT_CODE_GoButton_1']"));
            Driver.clickEleJs(By.XPath("//a[@id='ML.BASE.HEAD.EditContent']/span"));
        }

        public static void RemoveDiscountCode()
        {
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditContent_ML.BASE.BTN.Search']"));
            Driver.clickEleJs(By.XPath("//span/input"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditContent_RemoveAssignment']"));
            Driver.Instance.findandacceptalert();
            Driver.clickEleJs(By.XPath("//ol[@class='breadcrumb']//a[contains(text(),'Discount Codes')]"));


        }
    }
}