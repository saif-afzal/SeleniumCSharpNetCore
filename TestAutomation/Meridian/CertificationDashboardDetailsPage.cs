using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CertificationDashboardDetailsPage
    {
        public static CertifyUsersModalCommand CertifyUsersModal { get { return new CertifyUsersModalCommand(); } }

        public static void Click_CertifyUsers()
        {
            Driver.clickEleJs(By.XPath("//div[@id='btn-item-primary']/button"));
        }

        public static bool? VerifyCertifyUsersModalIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='certify-more']/div/div/div/h4"));
        }

        public static void SearchCertificationDetails(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='UserSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btnSearchUsers']"));
        }

        public static bool? VerifyStatus(string v)
        {
            return Driver.GetElement(By.XPath("//tr//td[3]")).Text.Contains(v);
        }
    }

    public class CertifyUsersModalCommand
    {
        public void SearchUsers(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btn-search']//span[@class='fa fa-search']"));


        }

        public bool? VerifyNameAndEmailIdIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='certify-more']//tr//td[2]"));
        }

        public bool? VerifyUserInformationFromInfoIcon()
        {
            
            Driver.clickEleJs(By.XPath("//td[3]/a/span"));
            Driver.waitforframe();
            Driver.existsElement(By.XPath("//span[@id='KendoUIMGDialog_wnd_title']"));
            return Driver.existsElement(By.XPath("//div[@id='acct-contact']/ul/li[3]/strong"));

        }

        public void CloseInformationModal()
        {
            //Driver.Instance.SwitchtoDefaultContent();
            Driver.clickEleJs(By.XPath("//div[5]/div/div/a"));
            //Driver.focusParentWindow();
        }

        public void SelectMultipleUsers()
        {
            Driver.clickEleJs(By.XPath("//input[@id='btSelectAll_certifyMoreUsers']"));
            //Driver.clickEleJs(By.XPath("//button[@id='btn-add-cert-exp']"));


        }

        public bool? VerifyObtainedDateIsTodaysdate()
        {
            string format = "M/dd/yyyy";
            string ObtainedDate = DateTime.Now.ToString(format);
            ObtainedDate = ObtainedDate.Replace("-", "/");
            string DisplayedObtainedDate = Driver.GetElement(By.XPath("//input[@id='cert-obtained-date']")).Text.ToString();

            return DisplayedObtainedDate == ObtainedDate;
        }

        public bool? VerifyOnClickOfPreviousButtonPagelandsOnPreviousPage()
        {
           
            return Driver.existsElement(By.XPath("//td[contains(text(),./*)]"));
        }

        public void ClickNextButton()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-cert-exp']"));
        }

        public void ClickPreviousButton()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-cert-usr']"));
        }

      

        public bool? VerifyObtainedDateCanBeSelectedPast(int v)
        {
            string format = "MM/dd/yyyy";
            string ObtainedDate = DateTime.Now.AddDays(0).ToString(format);
            string NewObtainedDate = DateTime.Now.AddDays(-v).ToString(format);
            NewObtainedDate = NewObtainedDate.Replace("-", "/");


            Driver.GetElement(By.XPath("//input[@id='cert-obtained-date']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='cert-obtained-date']")).ClickWithSpace();
            Driver.Instance.GetElement(By.XPath("//input[@id='cert-obtained-date']")).SendKeysWithSpace(NewObtainedDate);

            return NewObtainedDate != ObtainedDate;

            //return Driver.GetElement(By.XPath("//input[@id='cert-obtained-date']")).Text.ToString().Equals(NewObtainedDate);
        }

        public bool? VerifyReasonTextboxIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//textarea[@id='certify-reason']"));
        }

        public bool? VerifyCertifyButtonIsEnabled()
        {
            return Driver.GetElement(By.XPath("//button[@id='btn-add-cert']")).Enabled;
        }

        public void EnterReason()
        {
            Driver.GetElement(By.XPath("//textarea[@id='certify-reason']")).SendKeysWithSpace("Text");
        }

        public void ClickCertifyButton()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-cert']"));
        }

        public bool? VerifyExpirationDateCanbeOverridden(int v)
        {
            string format = "MM/dd/yyyy";
            string ExpirationDate= DateTime.Now.AddDays(0).ToString(format);
            string NewExpirationDate = DateTime.Now.AddDays(v).ToString(format);
            NewExpirationDate = NewExpirationDate.Replace("-", "/");


            Driver.GetElement(By.XPath("//input[@id='cert-expiration-date']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='cert-expiration-date']")).ClickWithSpace();
            Driver.Instance.GetElement(By.XPath("//input[@id='cert-expiration-date']")).SendKeysWithSpace(NewExpirationDate);

            return NewExpirationDate != ExpirationDate;
            //return Driver.GetElement(By.XPath("//input[@id='cert-expiration-date']")).Text.ToString().Equals(NewExpirationDate);
        }

      

        public bool? VerifyCertificationPeriodLearnerMayStart()
        {
            return Driver.existsElement(By.XPath("//span[@id='cert-add-period-begins']"));
        }

        public bool? VerifyCertificationPeriodLearnerMustCompleteBy(string v="")
        {
            if (Driver.GetElement(By.XPath("//small[@id='cert-add-period-ends-desc']")).Text.Equals(v))
            {
                return true;
            }
            else if (Driver.existsElement(By.XPath("//span[@id='cert-add-period-ends']")))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}