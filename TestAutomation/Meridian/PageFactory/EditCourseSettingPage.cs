using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class EditCourseSettingPage
    {
        public static bool? isPlayerModedisplay()
        {
            return Driver.existsElement(By.Id("lblSCORM12_InLinePlayer"));
        }

        public static bool? PlayerModeddropdownlist(string v1, string v2, string v3)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.Id("SCORM12_InLinePlayer"));
                Driver.checkDropDownItems(By.Id("SCORM12_InLinePlayer"), v1);
                Driver.clickEleJs(By.Id("SCORM12_InLinePlayer"));
                Driver.checkDropDownItems(By.Id("SCORM12_InLinePlayer"), v2);
                Driver.clickEleJs(By.Id("SCORM12_InLinePlayer"));
                Driver.checkDropDownItems(By.Id("SCORM12_InLinePlayer"), v3);
                result= true;
            }
            catch
            {

            }
            return result;
        }

        public static void ClickSave()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSave"));
        }
    }
}