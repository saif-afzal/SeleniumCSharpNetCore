using System;
using System.Threading;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    internal class EditPasswordPage
    {
        internal static void editpassword(string passwd, string v1, string v2)
        {
            Driver.GetElement(ObjectRepository.currentpassword).SendKeys(passwd);
            Driver.GetElement(ObjectRepository.editpassword).SendKeys(v1);
            Driver.GetElement(ObjectRepository.repeatpassword).SendKeys(v2);
            Driver.clickEleJs(ObjectRepository.saveeditpassword);
            Thread.Sleep(2000);
           
        }
    }
}