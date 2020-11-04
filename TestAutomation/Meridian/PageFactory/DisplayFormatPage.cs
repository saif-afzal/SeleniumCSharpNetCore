using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class DisplayFormatPage
    {
        public static AICCCommand AICC { get { return new AICCCommand(); } }

        public static ApplyToAllModalCommand ApplyToAllModal { get { return new ApplyToAllModalCommand(); } }

       

        public static CoursesInDisplayFormatCommand CoursesInDisplayFormat { get { return new CoursesInDisplayFormatCommand(); } }

        public static bool? isContentwithdisplayformatdisplay()
        {
            return Driver.GetElement(By.XPath("//div[@id='loadingArea']/ul/li[3]/div/button")).Displayed;
        }

        public static string GetAICCdefultDisplayFormat()
             {
            if(Driver.existsElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button/span")))
            {
                Driver.clickEleJs(By.XPath("//div[@class='dropdown-menu open']//span[@class='text'][contains(text(),'Online')]"));
                return Driver.GetElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button/span")).Text.Trim();
            }
            else
            {
                Driver.clickEleJs(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button"));
                return Driver.GetElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button")).Text.Trim();
            }
            
        }

        public static void ClickAICCDisplayFormatDropdown()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button"));
        }

        public static bool? VerifyDisplayformatList()
        {
            return Driver.existsElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button"));
        }

        public static void SelectotherdisplayformatforAICC(string v)
        {
            //Driver.Instance.select(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button"), v);
            //Driver.clickEleJs(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button"));
            Driver.clickEleJs(By.XPath("//*[@id='loadingArea']/ul[1]/li[3]/div/div/ul/li[7]/a/span[1]"));
         

        }

        public static bool? GetAICCdefultDisplayFormat(string defultdisplayformatforAICC)
        {
            string NewFormat = Driver.GetElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button")).Text.Trim();
            if(NewFormat !=defultdisplayformatforAICC)
            {
                return true;
            }
            else
            {
                //Driver.clickEleJs(By.XPath("//*[@id='loadingArea']/ul[1]/li[3]/div/div/ul/li[7]/a/span[1]"));
                return false;
            }
        }

        public static string GetDisplayed()
        {
            return Driver.GetElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[5]/small/span")).Text;
        }



        public static bool? isDefultChnagesDatedisplay(string previousDate)
        {
            string NewDate = Driver.GetElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[5]/small/span")).Text;
            //if (NewDate != previousDate)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return Driver.existsElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[5]/small/span"));

        }

        public static bool? isApplyToAllModaldisplay()
        {
            Driver.waitforframe();
            return Driver.existsElement(By.XPath("//div[@class='modal-header']"));
        }

        public static void SelectDefaultdisplayformatforAICC(string defultdisplayformatforAICC)
        {
            //Driver.Instance.select(By.XPath("//div[@id='loadingArea']/ul[1]/li[3]/div/button"), defultdisplayformatforAICC);
            //span[@class='filter-option pull-left'][contains(text(),'File')]
           //Driver.clickEleJs(By.XPath("//div[@class='dropdown-menu open']//span[@class='text'][contains(text(),'File')]"));
            Driver.clickEleJs(By.XPath("//div[@class='dropdown-menu open']//span[@class='text'][contains(text(),'"+ defultdisplayformatforAICC + "')]"));


        }

        public static string SelectFormatGenenralCourse()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'General Course: URL')]/following::span[contains(text(),'Online')][1]")).Text;

        }
    }

    public class CoursesInDisplayFormatCommand
    {


        public string Document(string v)//li[contains(text(),'General Course: URL')]/following::span[contains(text(),'Online')][1]
        {
            //return Driver.GetElement(By.XPath("//li[contains(text(),'"+v+"')]/following::div[1]")).Text;
            return Driver.GetElement(By.XPath("//li[contains(text(),'Document')]/following::span[contains(text(),'Document')][1]")).Text;
        }

        public void SelectDisplayFormatForDocument(string v)
        {
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Document')]"));
            //Driver.Instance.select(By.XPath("//li[contains(text(),'Document')]/following::div[1]"), v);
        }

        public void ApplyToAllForDocument()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']/ul[6]/li[4]/button"));
        }

        public void SelectDisplayFormatForGeneralCourse(string v)
        {
            Driver.select(By.XPath("//li[contains(text(),'General Course: URL')]/following::div[1]"), v);
        }

        public string GeneralCourse()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'General Course: URL')]/following::span[contains(text(),'Online')][1]")).Text;
        }

        public void SelectDisplayFormatForAICC(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'AICC')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'File')]"));
        }

        public string AICC()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'AICC')]/following::span[contains(text(),'File')][1]")).Text;
        }

        public void SelectDisplayFormatScormCourse(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'SCORM 1.2')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//div[@class='btn-group bootstrap-select mb-1 md:mb-0 open dropup']//li[@class='selected']//a[@tabindex='0']"));


        }

        public string ScormCourse()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'SCORM 1.2')]/following::span[contains(text(),'Online')][1]")).Text;
        }

        public void SelectDisplayFormatSurvey(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'Survey')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Survey')]"));

        }

        public string Survey()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'Survey')]/following::span[contains(text(),'Survey')][1]")).Text;
        }

        public void SelectDisplayFormatCurriculum(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'Curriculum')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Curriculum')]"));

        }

        public string Curriculum()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'Curriculum')]/following::span[contains(text(),'Curriculum')][1]")).Text;

        }

        public void SelectDisplayFormatCertification(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'Certification')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Certification')]"));

        }

        public string Certification()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'Certification')]/following::span[contains(text(),'Certification')][1]")).Text;

        }

        public void SelectDisplayFormatBundle(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'Bundle')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Bundle')]"));

        }

        public string Bundle()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'Bundle')]/following::span[contains(text(),'Bundle')][1]")).Text;

        }

        public void SelectDisplayFormatSubscription(string v)
        {
           // Driver.select(By.XPath("//li[contains(text(),'Subscription')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Subscription')]"));

        }

        public string Subscription()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'Subscription')]/following::span[contains(text(),'Subscription')][1]")).Text;
        }

        public void SelectDisplayFormatOJT(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'On-the-Job Training')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'On-the-Job Training')]"));

        }

        public string OJT()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'On-the-Job Training')]/following::span[contains(text(),'On-the-Job Training')][1]")).Text;

        }

        public void SelectDisplayFormatClassroom(string v)
        {
            //Driver.select(By.XPath("//li[contains(text(),'Classroom')]/following::div[1]"), v);
            Driver.clickEleJs(By.XPath("//li[@class='selected']//span[@class='text'][contains(text(),'Classroom')]"));

        }

        public string Classroom()
        {
            return Driver.GetElement(By.XPath("//li[contains(text(),'Classroom')]/following::span[contains(text(),'Classroom')][1]")).Text;

        }

        public void ApplyToAllForClassroom()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[4]//li[4]//button[1]"));
        }

        public void ApplyToAllForOJT()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[10]//li[4]//button[1]"));
        }

        public void ApplyToAllForSubscription()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[13]//li[4]//button[1]"));
        }

        public void ApplyToAllForBundle()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[2]//li[4]//button[1]"));
        }

        public void ApplyToAllForCertification()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[3]//li[4]//button[1]"));
        }

        public void ApplyToAllForCurriculum()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[5]//li[4]//button[1]"));
        }

        public void ApplyToAllForSurvey()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[14]//li[4]//button[1]"));
        }

        public void ApplyToAllForScorm()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[11]//li[4]//button[1]"));
        }

        public void ApplyToAllForAICC()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']/ul[1]/li[4]/button[1]"));
        }

        public void ApplyToAllForGeneralCourse()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']//ul[8]//li[4]//button[1]"));
        }
    }
    
    public class ApplyToAllModalCommand
    {
        public bool? WarningMessage()
        {
            return Driver.existsElement(By.XPath("//div[@id='assign-mapping']/div/div/div[3]"));
        }

        public int ContentItemsCount()
        {
            string count=Driver.GetElement(By.XPath("//div[@id='assign-mapping']/div/div/div[3]")).Text;
            return Driver.getIntegerFromString(count); 
        }

        public void ClickApply()
        {
            Driver.clickEleJs(By.XPath("//div[@id='assign-mapping']/div/div/div[4]/button[2]"));
        }
    }

    public class AICCCommand
    {


        public bool? ApplyToAllButtonDisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='loadingArea']/ul[1]/li[4]/button"));
        }

        public void ClickApplyToAllbutton()
        {
            Driver.clickEleJs(By.XPath("//div[@id='loadingArea']/ul[1]/li[4]/button"));
        }
    }
}