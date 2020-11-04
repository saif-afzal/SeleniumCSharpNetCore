using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CertificationDetailsPage
    {
        public static void Enroll()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucCurriculumDetails_FormView1_CertEnrollButton']"));
        }

        public static void OpenItem()
        {
            Driver.clickEleJs(By.XPath("//input[contains(text(),'Open Item')]"));

        }

        public static void MarkComplete()
        {
            Driver.Instance.SelectWindowClose();
            Driver.clickEleJs(By.XPath("//div[@id='content']/div[2]/div/div[2]/div/div[3]/input[2]"));
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnMarkComplete']"));
        }

        public static void ViewCertificate()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucCurriculumDetails_FormView1_CertCertificateBlock']"));

        }

        public static void ClickBreadCrumb()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_ucContentInfo1_FormView1_backButton']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucContentInfo1_FormView1_backButton']"));
        }
    }
}