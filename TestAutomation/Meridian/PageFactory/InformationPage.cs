using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System.Linq;

namespace Selenium2.Meridian.Suite
{
    public class InformationPage
    {
        public static ViewUsersTabCommand ViewUsersTab
        {
            get { return new ViewUsersTabCommand(); }
        }

        public static void ClickViewUsersTab()
        {
            Driver.clickEleJs(By.XPath("//nobr[contains(.,'View Users')]"));
        }

        public static bool? JobTitleName(string v)
        {
            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.Last());
            return Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Summary_FIELD:JBTTLLCL_TITLE")).Text== v;
            

        }


    }

    public class ViewUsersTabCommand
    {
        public int CountRecords
        {
            get
            {
                return Driver.getIntegerFromString(Driver.GetElement(By.XPath("//span[@class='PRE']")).Text);

            }
        }
    }
}

