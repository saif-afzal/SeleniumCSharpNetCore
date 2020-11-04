using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Text.RegularExpressions;
//using MeridianFramework.Training;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Collections.ObjectModel;
//using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
//using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static SuggestedCertificationsCommand SuggestedCertifications
        {
            get { return new SuggestedCertificationsCommand(); }
        }

        public static IWebDriver Initialize(string browser = "")
        {
            if (browser == "")
            {
                //RelativeDirectory rd = new RelativeDirectory();
                ChromeOptions options1 = new ChromeOptions();
                //var downloadDirectory = rd.Up(1) + "downloads";
                //Meridian_Common.MeridianFileDownload = downloadDirectory;
                //options1.AddUserProfilePreference("download.default_directory", downloadDirectory);
                options1.AddUserProfilePreference("download.prompt_for_download", false);
                options1.AddUserProfilePreference("disable-popup-blocking", "true");
                options1.AddArguments("disable-infobars");
                options1.AddArguments("--start-maximized");
                Instance = new ChromeDriver(options1);


                    //Instance.Manage().Timeouts().ImplicitlyWait = TimeSpan.FromSeconds(240);

            }
            else
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                String Format = "{dd/M/yyyy}";
                string date = DateTime.Now.ToString(Format);
              
                capabilities.SetCapability("browser", "Chrome");
                //capabilities.SetCapability("browser_version", "63.0");
                capabilities.SetCapability("browserstack.debug", "true");
                if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                {
                    capabilities.SetCapability("browserstack.local", "true");
                }
                capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                capabilities.SetCapability("browserstack.idleTimeout", 120);
                capabilities.SetCapability("resolution", "1024x768");
                capabilities.SetCapability("build", date + "(chrome)");
                capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                capabilities.SetCapability("name", "" + browser + "." + "chbs");
                capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");
                Instance = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                Instance.Manage().Window.Maximize();
                Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                ////string sessionId = ((RemoteWebDriver)Instance).Capabilities.GetCapability("webdriver.remote.sessionid").ToString();
                ////string buildId= ((RemoteWebDriver)Instance).Capabilities.GetCapability("browserstack.video").ToString();
            }
            return Instance;
        }

        internal static void waitlistrefresh()
        {
            throw new NotImplementedException();
        }

        internal static bool? WindowExist(string v)
        {
            bool res = false;
            ReadOnlyCollection<string> handles = Instance.WindowHandles;
            if (handles.Count > 1)
            {
                int i = handles.Count;
                foreach (string handle in handles)
                {
                    Instance.SwitchTo().Window(handle);
                    if (Instance.Title == v)
                    {
                        res = true;
                        break;
                    }

                }
            }
            return res;
        }
        public static void waitforframe()
        {
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
        }
        public static bool focusParentWindow()
        {
            ReadOnlyCollection<string> handles = Instance.WindowHandles;
            if (handles.Count > 1)
            {
                int i = handles.Count;
                foreach (string handle in handles)
                {

                    if (handle != Meridian_Common.parentwdw)
                    {


                        Instance.SwitchTo().Window(handle);
                        Instance.Close();

                    }
                    //else
                    //{
                    //    Instance.SwitchTo().Window(Meridian_Common.parentwdw);
                    //    break;
                    //}
                }
            }

            Instance.SwitchTo().Window(Meridian_Common.parentwdw);


            return true;
        }
        //public static bool CreateNewAccount(string addedtext = "")
        //{
        //    Meridian_Common.NewUserId = "newuser_" + addedtext + Meridian_Common.globalnum;
        //    Meridian_Common.Emailid = "test" + Meridian_Common.globalnum + "@tpg.com";
        //    CommonSection.Logout();
        //    LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
        //    CommonSection.Manage.People();
        //    PeoplePage.ClickCreateAccount();
        //    if (Driver.GetElement(By.XPath("//input[@id='USR_EMAIL_ADDRESS']")).Enabled)
        //    {
        //        CreateAccountPage.CreateAccount(Meridian_Common.NewUserId, Meridian_Common.NewUserId, "LastName", Meridian_Common.Emailid);
        //    }
        //    else
        //    {
        //        CreateAccountPage.CreateAccount(Meridian_Common.NewUserId, Meridian_Common.NewUserId, "LastName");
        //    }
        //    bool res = getSuccessMessage().Contains("The account was created and the user profile was updated.");
        //    if (res)
        //    {
        //        PeoplePage.Search_User(Meridian_Common.NewUserId);
        //        string passwd = PeoplePage.Generate_Password();
        //        CommonSection.Logout();
        //        LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword(passwd).Login();
        //        EditPasswordPage.editpassword(passwd, "password", "password");
        //        res = getSuccessMessage().Contains("Your password was changed. Remember to use your new password the next time you log in.");
        //        CommonSection.Logout();
        //    }
        //    return res;
        //}

        //public static bool CreateNewAccount_Specific(string addedtext)
        //{
        //    //  Meridian_Common.NewUserId = "newuser_" + addedtext + Meridian_Common.globalnum;

        //    CommonSection.Logout();
        //    LoginPage.LoginAs("siteadmin").WithPassword("password").Login(); ;
        //    CommonSection.Manage.People();
        //    PeoplePage.ClickCreateAccount();
        //    CreateAccountPage.CreateAccount(addedtext, addedtext, "LastName");

        //    bool res = getSuccessMessage().Contains("The account was created and the user profile was updated.");
        //    if (res)
        //    {
        //        PeoplePage.Search_User(addedtext);
        //        string passwd = PeoplePage.Generate_Password();
        //        CommonSection.Logout();
        //        LoginPage.LoginAs(addedtext).WithPassword(passwd).Login();
        //        EditPasswordPage.editpassword(passwd, "password", "password");
        //        res = getSuccessMessage().Contains("Your password was changed. Remember to use your new password the next time you log in.");
        //        CommonSection.Logout();
        //    }
        //    return res;
        //}
        public static string GetText(By by)
        {
            try
            {
              return  GetElement(by).Text;
            }
            catch(Exception ex)
            {
                return GetElement(By.XPath("//div[@id='MGSearchResults']/div[2]/div[2]/ul/li/div/div/h3/a")).Text;
            }
        }
        //public static IWebElement GetElement(By by)Used new version of Getelement which was changed in 19.1 HF
        //{
        //    Instance.WaitForElement(by);
        //    String execScript = "return document.documentElement.scrollHeight>document.documentElement.clientHeight;";
        //    if (ConfigurationManager.AppSettings["Selenium2Browsersa"] != null)//checking safari browser
        //    {
        //        IJavaScriptExecutor scrollBarPresent = (IJavaScriptExecutor)Driver.Instance;
        //        Boolean test = (Boolean)(scrollBarPresent.ExecuteScript(execScript));
        //        if (test == true)
        //        {
        //            IWebElement element = Driver.Instance.FindElement(by);
        //            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //            Thread.Sleep(500);
        //        }
        //        else if (test == false)
        //        {//commented the below code as it was not working with firefox in Browserstack
        //         //IWebElement element = driver.FindElement(by);
        //         //Actions action = new Actions(driver);
        //         //action.MoveToElement(element).Perform();
        //         //Console.WriteLine("Scroll bar not present");
        //        }


        //        for (int i = 1; i <= 1; i++)
        //        {
        //            try
        //            {
        //                return Driver.Instance.FindElement(by);
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Exception was raised on locating element: " + ex.Message);

        //            }

        //        }
        //        throw new ElementNotVisibleException(by.ToString());


        //    }
        //    return Driver.Instance.FindElement(by);
        //}
       
    
       
       
       
        public static bool verifyFile(string filename)
        {
            Thread.Sleep(20000);

            if (File.Exists(Meridian_Common.MeridianFileDownload + filename))
            {
                File.Delete(Meridian_Common.MeridianFileDownload + filename);
                var wdw = Instance.CurrentWindowHandle;
                Instance.SwitchTo().Window(wdw);
                return true;
            }
            else
            {
                return false;

            }
        }
        public static void ClickAndWaitForPageToLoad(By elementLocator, int timeout = 40)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                var element = Driver.Instance.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
      
        public static void select(By by, string text,string tagname="")
        {
            try
            {
                IWebElement select = Instance.FindElement(by);
                IList<IWebElement> options;
                if (tagname=="")
                {
                    options = select.FindElements(By.TagName("option"));

                }
                else
                {
                     options = select.FindElements(By.TagName(tagname));

                }
                foreach (IWebElement option in options)
                {
                    if (option.Text.Contains(text))
                        option.Click();
                    //break;
                }
            }
            catch (NoSuchElementException)
            {
                by = null;


            }
        }
        public static void selectdropdown(By by, string text)
        {
            try
            {
                IWebElement select = Instance.FindElement(by);
                IList<IWebElement> options = select.FindElements(By.TagName("li"));
                foreach (IWebElement option in options)
                {
                    if (option.Text.Contains(text))
                    {
                        option.Click();
                        break;
                    }

                }
            }
            catch (NoSuchElementException)
            {
                by = null;


            }
        }
        //public static void navigateAICCfile(string testpath, By by)
        //{
        //    RelativeDirectory rd = new RelativeDirectory();
        //    string path = string.Empty;
        //    try
        //    {


        //        path = rd.Up(2) + testpath;
        //        // path = path.Replace("\\", "/");
        //        Thread.Sleep(1000);
        //        uploadFile(path, by);
        //        //  Thread.Sleep(11000);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        //   driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        //    }
        //}

        public static void uploadFile(string path, By by)
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

        public static int getIntegerFromString(string extractText)
        {

            try
            {
                Thread.Sleep(1000);
                string resultString = Regex.Match(extractText, @"\d+").Value;
                int number = Int32.Parse(resultString);
                return number;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public static int getLastIntegerFromString(string extractText)
        {
            
            try
            {
                int y = 0;
                Thread.Sleep(1000);
                string[] resultString = Regex.Split(extractText, @"\D+");
                foreach (string value in resultString)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        int number = int.Parse(value);
                        y = number;
                        //Console.WriteLine("Number: {0}", i);
                    }
                    
                }
                return y;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public static void hoverLink(string firsttab, string childtab)
        {

            IWebElement a = Driver.GetElement(By.XPath("//a[contains(.,'" + firsttab + "')]"));
            IWebElement b = Driver.GetElement(By.XPath("//a[@href='/admin/professionaldevelopment/professionaldevelopment.aspx']"));
            String mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}";
            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript(mouseOverScript, a);
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript(mouseOverScript, b);
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript("arguments[0].click();", b);



            //    catch (Exception e)
            //    {
            //        // TODO: handle exception
            //    }
            //}
            //else
            //{
            //IWebElement link = GetElement(hoverlink);
            //IWebElement linkli = GetElement(linkclick);
            //Actions action = new Actions(Driver.Instance);
            //Cursor.Position = new Point(0, 0);
            //action.MoveToElement(link).Build().Perform();
            //Thread.Sleep(2000);
            //linkli.Click();
        }
        //}
        public static bool comparePartialString(string text, string actual)
        {
            string act1 = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", "");
            string act2 = System.Text.RegularExpressions.Regex.Replace(actual, @"\s+", "");
            bool res = act2.Contains(act1);
            return res;
        }

        public static bool? checkTitle(string Title)
        {
            return (Driver.Instance.Title.ToString() == Title);
        }
        public static int generateRandom(int min, int max)
        {
            var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
            return new Random(seed).Next(min, max);
        }
        public static bool checkDropDownItems(By by, string item)
        {
            {
                IWebElement select = Driver.GetElement(by);
                IList<IWebElement> options = select.FindElements(By.TagName("option"));
                foreach (IWebElement option in options)
                {
                    if (option.Text.Contains(item))
                        return true;
                }
            }
            return false;
        }
        public static string getSuccessMessage()
        {
            string rettext = string.Empty;
            try
            {
                ////Thread.Sleep(5000);
                //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
                //if (wait.Until(ExpectedConditions.StalenessOf(Driver.Instance.FindElement(By.XPath(".//*[@class='alert alert-dismissible alert-fixed alert-success']")))))
                //     // IWebElement element1 = Driver.Instance.FindElement(By.XPath("html/body/div[4]/div/div[1]/div"));
                //    Driver.Instance.WaitForElement(By.XPath(".//*[@class='alert alert-dismissible alert-fixed alert-success']"));
                //rettext = Driver.GetElement(By.XPath(".//*[@class='alert alert-dismissible alert-fixed alert-success']")).Text;
                // Driver.Instance.WaitForElement(By.CssSelector("div.alert.alert-dismissible.alert-fixed.alert-success"));
                ////rettext = Driver.GetElement(By.XPath("html/body/div[4]/div/div[1]/div")).Text;
                rettext = Driver.Instance.FindElement(By.CssSelector("div.alert.alert-dismissible.alert-fixed.alert-success")).Text;
                // return rettext;

            }
            catch (Exception Ex)
            {
                rettext = Driver.GetElement(By.CssSelector("div.alert.alert-success")).Text;
            }
            return rettext;
        }
        private static string str = string.Empty;
        public static bool VerifySearchResultisMatchedwith(By commonpath, string res1, string res2)
        {
            var a = "aaaaa";
            string res = string.Empty;
            var arr = new List<string>();
            arr.Add(res1);
            arr.Add(res2);
            bool result = false;
            IList<IWebElement> lst = Driver.Instance.FindElements(commonpath);
            int i = 0;
            foreach (var ele in lst)
            {
                if (ele.Text.Contains(arr[i]))
                    result = true;
                //select tags
                i = i + 1;
            }
            return result;
        }
     



        public static bool checkContentTagsOnDetailsPage()
        {
            return str == Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[3]/strong")).Text;
        }

        public static bool matchtime(By by)
        {
            DateTime date = DateTime.Now;

            string Systemtime = string.Format("{0:dddd}, {0:MMMM d, yyyy}", date);
            
            string text = Driver.GetElement(by).Text;

            
            return Systemtime==text;
        }
        public static bool matchmonth(By by)
        {
            DateTime month = DateTime.Now;

            string systemmonth = string.Format("{0:MMMM yyyy}", DateTime.Now);

            string text = Driver.GetElement(by).Text;

            return systemmonth == text;

        }

        
         
      

        public static bool SelectChildWindow()
        {
            ReadOnlyCollection<string> handles = Instance.WindowHandles;
            if (handles.Count > 1)
            {
                int i = handles.Count;
                foreach (string handle in handles)
                {

                    if (handle != Meridian_Common.parentwdw)
                    {


                        Instance.SwitchTo().Window(handle);
                        break;

                    }
                    //else
                    //{
                    //    Instance.SwitchTo().Window(Meridian_Common.parentwdw);
                    //    break;
                    //}
                }
            }

           


            return true;
        }

        public static bool? isSuggestedCertificationDisplayed()
        {
            return Driver.existsElement(By.XPath("//*[@id='content']/div[2]/div/div[2]/div[2]/h3[1]"));
        }

        public class SuggestedCertificationsCommand
        {
            public bool? isCertificationTitleDisplayed()
            {
                return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/a")).Displayed;
            }

            public bool? isCertificationCostDisplayed()
            {
                return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div/div[2]/div[2]/ul[2]/li/strong")).Displayed;

            }
        }

        public static bool comparePartialString(string v1, bool? v2)
        {
            throw new NotImplementedException();
        }

       



        //////////////////////////////////////////////////////////////////////////////////////////
        ///

      
       

      

      

      
    
       


       
        
        public static IWebElement GetElement(By by)
        {
            try
            {
                Instance.WaitForElement(by);
                String execScript = "return document.documentElement.scrollHeight>document.documentElement.clientHeight;";
                if (ConfigurationManager.AppSettings["Selenium2Browsersa"] != null)//checking safari browser
                {
                    IJavaScriptExecutor scrollBarPresent = (IJavaScriptExecutor)Driver.Instance;
                    Boolean test = (Boolean)(scrollBarPresent.ExecuteScript(execScript));
                    if (test == true)
                    {
                        IWebElement element = Driver.Instance.FindElement(by);
                        ((IJavaScriptExecutor)Driver.Instance).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                        Thread.Sleep(500);
                    }
                    else if (test == false)
                    {//commented the below code as it was not working with firefox in Browserstack
                     //IWebElement element = driver.FindElement(by);
                     //Actions action = new Actions(driver);
                     //action.MoveToElement(element).Perform();
                     //Console.WriteLine("Scroll bar not present");
                    }


                    for (int i = 1; i <= 2; i++)
                    {
                        try
                        {
                            return Driver.Instance.FindElement(by);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception was raised on locating element: " + ex.Message);

                        }

                    }
                    throw new ElementNotVisibleException(by.ToString());


                }
            }
            catch (Exception ex)
            {
                throw new ElementNotVisibleException(by.ToString());
            }
            return Driver.Instance.FindElement(by);
        }
        public static Boolean waitUnitElementIsDisplayed(By by, int seconds)
        {
            if (checkElementExists(by, seconds))
            {
                for (int i = 0; i < seconds; i++)
                {
                    if (Instance.FindElement(by).Displayed)
                        return true;
                    else
                        Thread.Sleep(1000);
                }

            }
            else
            {
                return false;
            }


            return false;
        }
        public static bool checkElementExists(By by, int seconds)
        {
            bool result = false;
            try
            {
                Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Instance.FindElement(by);
                result = true;
            }
            catch (NoSuchElementException ex)
            {
                result = false;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        public static bool? verifyToolTipText(By elementtohover, string v)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(elementtohover));

            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(element).Perform();

            if (Driver.GetElement(elementtohover).Text.Equals(v))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool existsElement(By by)
        {
            try
            {
                Thread.Sleep(5000);
                if (Driver.Instance.FindElement(by).Displayed)
                {
                    return true;
                }
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
        public static bool existsElementwithElementText(By by, string text)
        {
            try
            {
                Thread.Sleep(5000);
                IWebElement element = Driver.Instance.FindElement(by);
                if (element.Displayed || element.Text == text)
                {
                    return true;
                }
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
       
      
        public static void clickEleJs(By by)
        {

            try
            {
                waitUnitElementIsDisplayed(by, 40);
                //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
                //wait.Until(ExpectedConditions.ElementIsVisible(by));
                IWebElement element = Instance.GetElement(by);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Instance;
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                executor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception ex)
            {
                throw new ElementNotVisibleException(by.ToString());
            }


        }
       
       
        public static bool checkTagsonContentCreationPage(bool checkcontenttags)
        {
            #region verifies that list selected is represented in textbox
            Thread.Sleep(5000);

            Driver.GetElement(By.XPath("//div[@id='container-tags']/div/div/button/span[2]/span")).ClickWithSpace();//clicks tags button
            var arr = new List<string>();
            IList<IWebElement> lst = Driver.Instance.FindElements(By.XPath("//div[@id='container-tags']/div/div/div/ul/li"));
            int i = 0;
            foreach (var ele in lst)
            {
                ele.ClickWithSpace();//select tags
                arr.Add(ele.Text);
                i = i + 1;
                if (i == 3)
                {
                    Driver.GetElement(By.XPath("//div[@id='container-tags']/div/div/button/span[2]/span")).ClickWithSpace();
                    break;
                }
            }
            str = string.Join(",", arr);
            var stractual = Driver.GetElement(By.XPath("//div[@id='container-tags']/div/div/button/span")).Text;
            stractual = Regex.Replace(stractual, @"\s+", "");
            if (checkcontenttags == true)
            {
                return stractual == str;
            }
            else
            {
                return false;
            }

            #endregion
            #region verifies the tag at content details page
            //     str== Driver.GetElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[3]/strong")).Text;
            #endregion
        }



     

      





     

        

      


    }

}
