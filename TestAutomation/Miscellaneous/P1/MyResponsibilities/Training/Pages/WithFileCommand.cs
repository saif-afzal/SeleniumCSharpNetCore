using MeridianFramework.Training;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.P1.MyResponsibilities.Training
{
    public class WithFileCommand
    {
        private string url = string.Empty;
        private string title = string.Empty;
        private string keyword = string.Empty;
        private string description = string.Empty;
        public WithFileCommand(string arg_url)
        {
            this.url = arg_url;
        }
        public void CreateDocument()
        {
            IWebElement test = Driver.Instance.FindElement(By.XPath("//*[@id='Editor']/div[3]/div/p"));

            Driver.Instance.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE")).SendKeys("testDoc");

            Driver.Instance.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeys(keyword);
            Driver.Instance.FindElement(By.Id("MainContent_UC1_FormView1_CNT_BOOST")).SendKeys("2");
            //Driver.ClickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            navigateAICCfile("MeridianFramework\\Data\\Fileupload.txt", By.XPath("//input[@id='AsyncUpload1file0']"));
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
        public void navigateAICCfile(string testpath, By by)
        {
            RelativeDirectory rd = new RelativeDirectory();
            string path = string.Empty;
            try
            {


                path = rd.Up(2) + testpath;
                // path = path.Replace("\\", "/");
                Thread.Sleep(1000);
                uploadfile(path, by);
                //  Thread.Sleep(11000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
        }

        public static void uploadfile(string path, By by)
        {
            try
            {
                //Thread.Sleep(6000);

                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)Driver.Instance;
                if (allowsDetection != null)
                {
                    allowsDetection.FileDetector = new LocalFileDetector();

                }
                Driver.Instance.FindElement(by).SendKeys(path);

                Thread.Sleep(2000);
                //scorm12.GetElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_UploadContent_TDElementUploadFile']/table/tbody/tr/td/input")).SendKeys(path);
            }
            catch (Exception ex)
            {
                //  System.Windows.Forms.SendKeys.SendWait("{ESC}");
                Thread.Sleep(6000);
                // path = string.Empty;
                // uploadfile(driver, path, by);
            }
        }
    }
}
