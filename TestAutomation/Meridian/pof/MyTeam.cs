using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
namespace Selenium2.Meridian
{
    class MyTeam
    {
        private readonly IWebDriver driverobj;

        public MyTeam(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Verify_ProfessionalDevelopment_NotPresent()
        {
            bool result = false;
            try
            {
                driverobj.ElementNotPresent(tab_ProfessionalDevelopment);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Verify_ProfessionalDevelopment_Present()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(tab_ProfessionalDevelopment);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Verify_pageElementsForUser(String username)
        {
            bool result = false;
            By userEntry = By.XPath("//td[contains(text(),'" + username + "')]");
            By expandIcon = By.XPath("//td[contains(text(),'" + username + "')]/preceding-sibling::td[1]/img");
            By lbl_email = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Email Address')]");
            By lbl_phone = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Work Phone')]");
            By lbl_location = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Location')]");
            By lbl_roles = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Roles')]");
            By lbl_loginID = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Login ID')]");
            By lbl_userID = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'User ID')]");
            By lbl_Organizations = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Organizations')]");
            By lbl_Managers = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Managers')]");
            By lbl_JobTitles = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Job Titles')]");
            By lbl_PendingRequests = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[strong[contains(text(),'Pending Requests')]]");
            By lbl_AssignedTraining = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[strong[contains(text(),'Assigned Training')]]");
            By lbl_LastLogin = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[contains(text(),'Last Login')]");
            By lnk_EmailUser = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[a[contains(text(),'Email User')]]");
            By lnk_ViewTranscript = By.XPath("//tr[td[contains(text(),'" + username + "')]]/following-sibling::tr[1]//li[a[contains(text(),'View Transcript')]]");
            try
            {
                driverobj.WaitForElement(userEntry);
                driverobj.WaitForElement(expandIcon);
                driverobj.GetElement(expandIcon).ClickWithSpace();
                driverobj.WaitForElement(lbl_email);
                driverobj.WaitForElement(lbl_phone);
                driverobj.WaitForElement(lbl_location);
                driverobj.WaitForElement(lbl_roles);
                driverobj.WaitForElement(lbl_loginID);
                driverobj.WaitForElement(lbl_userID);
                driverobj.WaitForElement(lbl_Organizations);
                driverobj.WaitForElement(lbl_Managers);
                driverobj.WaitForElement(lbl_JobTitles);
                driverobj.WaitForElement(lbl_PendingRequests);
                driverobj.WaitForElement(lbl_AssignedTraining);
                driverobj.WaitForElement(lbl_LastLogin);
                driverobj.WaitForElement(lnk_EmailUser);
                driverobj.WaitForElement(lnk_ViewTranscript);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }


        private By tab_ProfessionalDevelopment = By.XPath("//span[contains(.,'Professional Development')]");



    }



}
