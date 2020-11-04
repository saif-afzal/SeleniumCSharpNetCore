using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class Uploadscromecourse
    {
        public static void uploadfile()
        {
            Driver.Instance.navigateAICCfile("Data\\MARITIME NAVIGATION.zip", By.Id("AsyncUpload1file0"));
            Thread.Sleep(20000);
            Driver.Instance.ScrollToCoordinated("1000", "1000");
            Driver.Instance.WaitForElement(ObjectRepository.nxt_btn_new);
            Driver.clickEleJs(ObjectRepository.nxt_btn_new);
        }
    }
}