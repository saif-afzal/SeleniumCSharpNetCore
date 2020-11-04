using System;
using System.Threading;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite
{
    public class MergeUsersPage
    {
        public static void mergeUsers(string PrimaryUser, string SecondaryUser)
        {
            Driver.Instance.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_MergeUsers_USR_LOGIN_ID']")).SendKeysWithSpace(PrimaryUser);
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_MergeUsers_ML.BASE.BTN.Search']"));
            Driver.clickEleJs(By.XPath("//tbody[1]/tr[2]/td[1]/div[1]/table[3]/tbody[1]/tr[3]/td[2]/span[1]/input[1]"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_MergeUsers_ML.BASE.BTN.SelectPrimaryAccount']"));

            Driver.Instance.FindElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_SelectSecondaryAccount_USR_LOGIN_ID']")).SendKeysWithSpace(SecondaryUser);
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_SelectSecondaryAccount_ML.BASE.BTN.Search']"));
            Driver.clickEleJs(By.XPath("//input[@type='radio']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_SelectSecondaryAccount_ML.BASE.BTN.SelectSecondaryAccount']"));
            Driver.Instance.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_ReviewAccountMerge_MERGE_USER_REASON']")).SendKeysWithSpace("Testing");
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_ReviewAccountMerge_SubmitMergeUser']"));
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            Driver.Instance.IsElementVisible(By.XPath("//span[@id='ReturnFeedback']"));

        }
    }
}