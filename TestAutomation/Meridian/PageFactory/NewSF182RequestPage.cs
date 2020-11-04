using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class NewSF182RequestPage
    {
        public static aboutThisSf182RequestCommand aboutThisSf182Request
        {
            get { return new aboutThisSf182RequestCommand(); }
        }

        public static YourInformationCommand YourInformation { get { return new YourInformationCommand(); } }

        public static FindorCreateTrainingCommand FindorCreateTraining { get { return new FindorCreateTrainingCommand(); } }

        public static TrainingCourseDataCommand TrainingCourseData { get { return new TrainingCourseDataCommand(); } }

        public static bool? isAboutThisSF_182RequestPortletdisplayexpanded()
        {
            Driver.existsElement(By.LinkText("About This SF-182 Request"));
            return Driver.GetElement(By.Id("sectionPre")).GetAttribute("aria-expanded").Contains("true");
        }

        public static bool? isYourinformationdisplayexpanded()
        {
            Driver.existsElement(By.Id("sectionA"));
            return Driver.GetElement(By.Id("sectionA")).GetAttribute("aria-expanded").Contains("true");
        }

        public static bool? isFindCreateTrainingdisplayexpanded()
        {
            return Driver.GetElement(By.Id("sectionTraining")).GetAttribute("aria-expanded").Contains("true");
        }

        public static void ClickSubmit()
        {
            Driver.clickEleJs(By.XPath("//button[@id='submit-form']"));
        }

        public static bool? isUserAdded()
        {
            return Driver.existsElement(By.XPath("//span[@class='text-group-addon']"));
        }

        public static bool? isTrainingCourseDatadisplayexpanded()
        {
            Driver.existsElement(By.LinkText("Training Course Data"));
            return Driver.GetElement(By.Id("sectionB")).GetAttribute("aria-expanded").Contains("true");
        }

        public static void ClickSaveasDraft()
        {
            Driver.existsElement(By.XPath("//div[@id='sf182Form']/div/div[6]/div[2]/button"));
            Driver.clickEleJs(By.XPath("//div[@id='sf182Form']/div/div[6]/div[2]/button"));
        }
    }

    public class TrainingCourseDataCommand
    {
        public TrainingVendorCommand TrainingVendor { get { return new TrainingVendorCommand(); } }

        public TrainingCourseDataCommand()
        {
        }

        public bool? Verifyfields(string v, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }

        public bool? isTrainingVendordropdowndisplay()
        {
            Driver.existsElement(By.XPath("//div[@id='sectionB']/div/div/div/div/label"));
            return Driver.GetElement(By.XPath("//div[@id='sectionB']/div/div/div/div/label")).Text.Equals("Training Vendor");
        }
    }

    public class TrainingVendorCommand
    {
        public TrainingVendorCommand()
        {
        }

        public void SelectVenderName()
        {
            Driver.clickEleJs(By.XPath("//div[@id='sectionB']/div/div/div/div/div/div/div/button/span[2]/span"));
            Driver.select(By.XPath("//div[@id='sectionB']/div/div/div/div/div/div/div/select"), "AS Vendor1");
        }
    }

    public class FindorCreateTrainingCommand
    {
        public CostandBillingInformationCommand CostandBillingInformation { get { return new CostandBillingInformationCommand(); } }

        public FindorCreateTrainingCommand()
        {
        }

        public bool? isTrainingCourseDatadisplay()
        {
            return Driver.GetElement(By.Id("sectionTraining")).GetAttribute("aria-expanded").Contains("true");
        }

        public void entermandetorydata(string course)
        {
            Driver.GetElement(By.XPath("//input[@id='CourseTitle']")).SendKeys(course);
           // string format = "yyyy/mm/dd";
           // string startdate = DateTime.Now.AddDays(-2).ToString(format);
           // string enddate = DateTime.Now.AddDays(2).ToString(format);
           //// startdate = startdate.Replace("-", "/");
           //// enddate = enddate.Replace("-", "/");
           // IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@id='TrainingStartDate']"));

           // Driver.existsElement(By.Id("//input[@id='TrainingStartDate']"));
           // webElement.Clear();
           // webElement.SendKeysWithSpace(startdate);
           // Driver.GetElement(By.XPath("//input[@id='TrainingEndDate']")).Clear();
           // Driver.GetElement(By.XPath("//input[@id='TrainingEndDate']")).SendKeysWithSpace(enddate);
           // Driver.GetElement(By.XPath("//input[@id='TrainingEndDate']")).SendKeys(Keys.Tab);

            Thread.Sleep(3000);
            // Driver.clickEleJs(By.XPath("//div[@id='enrollmentBlock']/div[2]/div/div[3]/div/div/span[3]"));
            Driver.clickEleJs(By.XPath("//div[@id='sectionB']/div/div[4]/div[2]/div/div/div/span/i"));
            Driver.clickEleJs(By.XPath("//div[@id='sectionB']/div/div[4]/div[2]/div/div/div/div/ul/li/div/div/table/tbody/tr[3]/td[3]"));
            Driver.clickEleJs(By.XPath("//div[@id='sectionB']/div/div[4]/div[3]/div/div/div/span/i"));
            Driver.clickEleJs(By.XPath("//div[@id='sectionB']/div/div[4]/div[3]/div/div/div/div/ul/li/div/div/table/tbody/tr[3]/td[6]"));
        }

        public void ClickNext()
        {
            Driver.clickEleJs(By.XPath("//div[@id='sectionB']//button[@class='btn btn-primary'][contains(text(),'Next')]"));
        }

        public bool? isCostandBillingInformationdisplayExpanded()
        {
            Driver.existsElement(By.Id("sectionC"));
            return Driver.GetElement(By.Id("sectionC")).GetAttribute("aria-expanded").Contains("true");
        }

        public bool? isTrainingDetaisdisplayexpanded()
        {
            Driver.existsElement(By.Id("sectionD"));
            return Driver.GetElement(By.Id("sectionD")).GetAttribute("aria-expanded").Contains("true");
        }
    }

    public class CostandBillingInformationCommand
    {
        public CostandBillingInformationCommand()
        {
        }

        public void enterCosts()
        {
            Driver.GetElement(By.XPath("//input[@id='TuitionCost']")).SendKeys("5");
            Driver.GetElement(By.XPath("//input[@id='BookMaterialCost']")).SendKeys("5");
            Driver.GetElement(By.XPath("//input[@id='TravelCost']")).SendKeys("5");
            Driver.GetElement(By.XPath("//input[@id='PerDiemCost']")).SendKeys("5");
            Driver.GetElement(By.XPath("//input[@id='NonGovtContributionCost']")).SendKeys("100");
        }

        public void clickNext()
        {
            Driver.clickEleJs(By.XPath("//div[@id='sectionC']//button[@class='btn btn-primary'][contains(text(),'Next')]"));
        }

        public bool? isTotalcostisdisabled()
        {
            if (!Driver.GetElement(By.XPath("//input[@id='TotalCostDirect']")).Enabled)
            {
                return true;
            }
            else return false;
        }
    }

    public class YourInformationCommand
    {
        public YourInformationCommand()
        {
        }

        public bool? Verifydisabledfields()
        {
            try
            {
                List<string> errors = new List<string>();

                if (!Driver.GetElement(By.XPath("//input[@type='text']")).Displayed)
                { errors.Add("Applicant Name is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='ssn']")).Displayed)
                { errors.Add("Applicant Name is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='DateOfBirth']")).Displayed)
                { errors.Add("DOB is disabled"); }
                if (!Driver.GetElement(By.XPath("//textarea[@id='WorkEmail']")).Displayed)
                { errors.Add("Work Email is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='PositionTitle']")).Displayed)
                { errors.Add("Position Title is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='AppointmentType']")).Displayed)
                { errors.Add("Appointment Type is disabled"); }
                if (!Driver.GetElement(By.XPath("//select[@class='aspNetDisabled form-control forms-large']")).Displayed)
                { errors.Add("Education Level is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='PayPlan']")).Displayed)
                { errors.Add("pay plan is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='Series']")).Displayed)
                { errors.Add("Series is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='Grade']")).Displayed)
                { errors.Add("Grade is disabled"); }
                if (!Driver.GetElement(By.XPath("//input[@id='Step']")).Displayed)
                { errors.Add("Step is disabled"); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);

                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", Driver.Instance);
            }
            return true;
        }

        public void ClickNext()
        {
            Driver.clickEleJs(By.XPath("//div[@id='sectionA']//button[@class='btn btn-primary'][contains(text(),'Next')]"));
        }
    }

    public class aboutThisSf182RequestCommand
    {
        public aboutThisSf182RequestCommand()
        {
        }

        public bool? Verifyfields(string v1, string v2, string v3, string v4, string v5, string v6)
        {
            
            try
            {
                List<string> errors = new List<string>();

                if (!Driver.existsElement(By.XPath("//input[@type='text']")))
                { errors.Add("Agency Code text bot is not available"); }
                if (!Driver.GetElement(By.XPath("//label[contains(text(),'Resubmission')]")).Text.Contains(v3))
                { errors.Add("Resubmission is not coming on page"); }
                if (!Driver.GetElement(By.XPath("//label[contains(text(),'Initial')]")).Text.Contains(v4))
                { errors.Add("Initial is not coming on page"); }
                if (!Driver.GetElement(By.XPath("//label[contains(text(),'Correction')]")).Text.Contains(v5))
                { errors.Add("Correction is not coming on page"); }
                if (!Driver.GetElement(By.XPath("//label[contains(text(),'Cancellation')]")).Text.Contains(v6))
                { errors.Add("Cancellation is not coming on page"); }
                if (errors.Count > 0)
                {
                    string allErrors = string.Join("", errors);
                    throw new Exception(allErrors);
                    
                }
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", Driver.Instance);
            }
            return true;
        }

        public bool? EnterAgencyNumberiseditble()
        {
            return Driver.GetElement(By.XPath("//input[@id='agencyOffice']")).Enabled;
        }

        public void EnterAgencyNumber(string agencyNumber)
        {
            Driver.GetElement(By.XPath("//input[@type='text']")).SendKeysWithSpace(agencyNumber);
        }

        public void ClickNext()
        {
            Driver.clickEleJs(By.XPath("//div[@id='sectionPre']/div/div[2]/button"));
        }
    }
}