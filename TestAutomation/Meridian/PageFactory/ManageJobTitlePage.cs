using OpenQA.Selenium;
using Selenium2.Meridian;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class ManageJobTitlePage
    {
        public static JobDetailsTabCommand JobDetailsTab
        { get { return new JobDetailsTabCommand(); } }
        public static CareerTrackCommand CareerTrackTab
        { get { return new CareerTrackCommand(); } }

        public static AssignCompetencyFrameCommand AssignCompetencyFrame
        { get { return new AssignCompetencyFrameCommand(); } }

        public static CompetenciesTabCommand CompetenciesTab
        {
            get { return new CompetenciesTabCommand(); }
        }

        public static ListofCompetenciesCommand ListofCompetencies
        {
            get { return new ListofCompetenciesCommand(); }
        }

        public static void ClickJobDetailsTab()
        {
            Driver.existsElement(By.XPath("//a[@href='#jobdetails']"));
            Driver.clickEleJs(By.XPath("//a[@href='#jobdetails']"));
        }

        public static void ClickSavebutton()
        {
            Driver.clickEleJs(By.XPath(""));
            Driver.GetElement(By.XPath(""));
        }

        public static string GetSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }

        public static string GetDescriptionLink()
        {
            Driver.Instance.WaitForElement(By.XPath("//a[@id='edit-description-link']"));
            string actres = string.Empty;
            actres = Driver.GetElement(By.XPath("//a[@id='edit-description-link']")).Text;
            return actres;
        }

        public static bool NameColumn(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(.,'"+v+"')]"));
        }

        public static string GetKeywordLink()
        {
            return Driver.GetElement(By.XPath("//a[@id='edit-keywords-link']")).Text;
        }

        public static string GetJobCodeLink()
        {
            return Driver.GetElement(By.XPath("//a[@id='edit-jobcode-link']")).Text;
        }

        internal static void ClickViewUSersTab()
        {
            throw new NotImplementedException();
        }


        public static string VerifyCareerpathText(string v)
        {
            if (Driver.existsElement(By.XPath("//a[@id='aCareerPath']/strong/span")))
            {
                return Driver.GetElement(By.XPath("//a[@id='aCareerPath']/strong/span")).Text;
            }
            else return Driver.GetElement(By.XPath("//a[@id='aCareerPath']/strong/span")).Text;
        }

        public static string VerifyLevelText(string v)
        {
            if(!Driver.existsElement(By.Id("spLevelName")))
            {
                Driver.clickEleJs(By.Id("spCareerPath"));
                Driver.clickEleJs(By.XPath("//button[@id='btn-save-path-level']/span"));
                Thread.Sleep(5000);
                return Driver.GetElement(By.Id("spLevelName")).Text;
            }
            return Driver.GetElement(By.Id("spLevelName")).Text;
        }

        public static string getJobTitletext()
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div/h1")).Text;
        }

        public static void ClickCareerBreadcrumb()
        {
            Driver.existsElement(By.XPath("//*[@id='content']/div[1]/ol/li[2]/a"));
            Driver.clickEleJs(By.XPath("//*[@id='content']/div[1]/ol/li[2]/a"));
            Thread.Sleep(2000);
        }
    }

    public class AssignCompetencyFrameCommand
    {
        public AssignCompetencyFrameCommand()
        {
        }

        public void SearchCompetency(string v)
        {
           
                //  .//*[@id='find-competencies-modal']
                //  Driver.Instance.waitforframe(By.XPath(".//*[@id='find-competencies-modal']"));
                Driver.existsElement(By.XPath("//input[@id='SearchFor']"));
                Driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace(v);
                Driver.clickEleJs(By.XPath("//i[@class='fa fa-search']"));
                Driver.Instance.WaitForElement(By.XPath("//td[contains(.,'" + v + "')]"));
                //  Driver.GetElement(By.XPath("//input[@id='SearchFor']"))
           
        }

        public void AssignCompetencyItem(string v)
        {
            string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
            if (!(v == null))
            {
                Driver.existsElement(By.XPath("//input[@id='SearchFor']"));
                Driver.GetElement(By.XPath("//input[@id='SearchFor']")).SendKeysWithSpace(v);
                Driver.clickEleJs(By.XPath("//i[@class='fa fa-search']"));
                Driver.Instance.WaitForElement(By.XPath("//td[contains(.,'" + v + "')]"));
                Driver.existsElement(By.XPath("//input[@name='btSelectItem']"));
                Driver.clickEleJs(By.XPath("//input[@name='btSelectItem']"));
                Thread.Sleep(3000);
                Driver.clickEleJs(By.XPath("//button[@id='btn-assign-competencies']"));
                Thread.Sleep(5000);
            }
            else
            {
                if(Driver.existsElement(By.XPath(".//tr[contains(.,'No matching records found')]")))
                {
                    Driver.clickEleJs(By.XPath("//a[contains(text(),'Need to add a new competency?')]"));
                    Driver.GetElement(By.Id("createNewCompetency")).Clear();
                    Driver.GetElement(By.Id("createNewCompetency")).SendKeysWithSpace(CompetencyTitle+"TC33566");
                    Driver.clickEleJs(By.XPath("btn-createAndaddCompetency"));
                    
                }
                else
                {
                    Driver.existsElement(By.XPath("//input[@name='btSelectItem']"));
                    Driver.clickEleJs(By.XPath("//input[@name='btSelectItem']"));
                    Thread.Sleep(3000);
                    Driver.clickEleJs(By.XPath("//button[@id='btn-assign-competencies']"));
                    Thread.Sleep(5000);
                }

            }
            //Driver.existsElement(By.XPath("//input[@name='btSelectItem']"));
            //Driver.clickEleJs(By.XPath("//input[@name='btSelectItem']"));
            //Thread.Sleep(3000);
            //Driver.clickEleJs(By.XPath("//button[@id='btn-assign-competencies']"));
            //Thread.Sleep(5000);
        }
    }

    public class CareerTrackCommand
    {
        public CareerTrackCommand()
        {
        }

        public void ClickAssignCompetency()
        {
            if(!Driver.existsElement(By.XPath("//button[@id='btn-add-competency']")))
            {
                Driver.clickEleJs(By.XPath("//button[@id='btn-add-competency2']"));
            }
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-competency']"));
        }

        public void RemoveCompetency(string v)
        {
            Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
            Driver.clickEleJs(By.XPath("//button[@id='btn-remove-competencies']"));
            Driver.clickEleJs(By.Id("remove-competencies"));
        }
    }

    public class JobDetailsTabCommand
    {
        public JobDetailsTabCommand()
        {
        }

        public void AddDescription(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='edit-description-link']"));
            Thread.Sleep(1000);
            Driver.GetElement(By.XPath("//textarea[@class='form-control input-large']")).Clear();
            Driver.GetElement(By.XPath("//textarea[@class='form-control input-large']")).SendKeysWithSpace(v);
            Driver.GetElement(By.XPath("//form/div/div/div[2]/div/button/span")).ClickWithSpace();
        }

        public void AddKeywords(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='edit-keywords-link']"));
            Driver.GetElement(By.XPath("//input[@class='form-control input-sm']")).Clear();
            Driver.GetElement(By.XPath("//input[@class='form-control input-sm']")).SendKeysWithSpace(v);
            Driver.GetElement(By.XPath("//form/div/div/div[2]/div/button/span")).ClickWithSpace();
        }

        public void JobCodeLink(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='edit-jobcode-link']"));
            Driver.GetElement(By.XPath("//input[@class='form-control input-sm']")).Clear();
            Driver.GetElement(By.XPath("//input[@class='form-control input-sm']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
        }
    }
}