using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;
using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Selenium2.Meridian;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
//using MeridianFramework.Training;
using NUnit.Framework;

namespace Selenium2
{
    public class Selenium2TestBase
    {
        private FirefoxProfile _ffp;
        private IWebDriver _driver;
        private IWebDriver driver;
        public string seesionId = "";
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        public IWebDriver StartBrowser(string browser,string browsers="")
        {
            String Format = "{dd/M/yyyy}";
            string date = DateTime.Now.ToString(Format);
            string environment = System.Configuration.ConfigurationManager.AppSettings["MeridianTestEnvironment"];
            string smokeenvironment = System.Configuration.ConfigurationManager.AppSettings["SmokeTestEnvironment"];
            Meridian_Common.MeridianTestSite = environment;
            Meridian_Common.SmokeTestSite = smokeenvironment;
            if (System.Configuration.ConfigurationManager.AppSettings["IsSmokeTestEnvironment"] == "True")
            {
                Meridian_Common.issmoketest = true;
            }
            if (NUnit.Framework.TestContext.CurrentContext.Test.Name == "SmokeTest")
            {
                Common.WebBrowser = ConfigurationManager.AppSettings["Selenium2smokeBrowser"];
            }
            else
            {

              //  Common.WebBrowser = ConfigurationManager.AppSettings["Selenium2Browser"];
            }
            string IP = System.Configuration.ConfigurationManager.AppSettings["IP"];
            string Spoon_Cred = System.Configuration.ConfigurationManager.AppSettings["spooncred"];
            //if (Common.WebBrowser.Contains("remote"))
            //{
            //    ExecuteCommand("spoon login " + Spoon_Cred + "", 25000);
            //    ExecuteCommand("spoon run spoonbrew/selenium-grid", 55000);
            //}
            DesiredCapabilities capabilities = new DesiredCapabilities();


            switch (browser)//Common.WebBrowser
            {
                case "firefox":
                    _ffp = new FirefoxProfile();
                    _ffp.AcceptUntrustedCertificates = true;
                    _driver = new FirefoxDriver();
                    break;
                case "iexplore":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IgnoreZoomLevel = true;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                   
                    
                    _driver = new InternetExplorerDriver(options);
                    // _driver = new InternetExplorerDriver();
                    break;

                case "edge":
                    InternetExplorerOptions options2 = new InternetExplorerOptions();
                    options2.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    _driver = new InternetExplorerDriver(options2);
                    // _driver = new InternetExplorerDriver();
                    break;
                case "chrome":
                     
                //    _driver = new ChromeDriver();

                    ChromeOptions options1 = new ChromeOptions();
                    //RelativeDirectory rd = new RelativeDirectory();
                    options1.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
                    options1.AddArguments("disable-infobars");
                    //var downloadDirectory = rd.Up(1) + "downloads";
                    //Meridian_Common.MeridianFileDownload = downloadDirectory;
                    //options1.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    options1.AddUserProfilePreference("download.prompt_for_download", false);
                    options1.AddUserProfilePreference("disable-popup-blocking", "true");

                    options1.AddArguments("--start-maximized");
                  
                    
                    //   var service = ChromeDriverService.CreateDefaultService(@"D:\Driver\"); 
                    //service.LogPath = "chromedriver.log";
                    //service.EnableVerboseLogging = true;
                    //  _driver = new ChromeDriver(service,options1);
                    _driver = new ChromeDriver(options1);
                    //var entries = _driver.Manage().Logs.GetLog(LogType.Browser);
                    //foreach (var entry in entries)
                    //{
                    //   Console.WriteLine(entry.ToString());
                    //}

                    //  _driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(180);
                    //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(240);
                    break;
               
                case "ffbs":
                    capabilities.SetCapability("browser", "Chrome");
                    capabilities.SetCapability("browser_version", "64.0");
                    capabilities.SetCapability("os", "OS X");
                    capabilities.SetCapability("os_version", "El Capitan");
                  //  capabilities.SetCapability("browserstack.safari.enablePopups", "true");
                    //capabilities = DesiredCapabilities.Chrome();
                    //   capabilities.SetCapability("browser", "Chrome");
                    //capabilities.SetCapability("browser_version", "47.0");
                    capabilities.SetCapability("browserstack.idleTimeout", 300);

                    capabilities.SetCapability("browserstack.video", "true");
                    if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                    {
                        capabilities.SetCapability("browserstack.local", "true");
                    }
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.idleTimeout", 120);
                    capabilities.SetCapability("resolution", "1024x768");
                    capabilities.SetCapability("build", "_" + date + "(chrome_mac)");
                    capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    capabilities.SetCapability("name", "" + this.GetType().Name + "." + browser);
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                    capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");
                    _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                    break;
              
                case "chbs":


                    capabilities.SetCapability("browser", "Chrome");
                    capabilities.SetCapability("browser_version", "73.0");
                    capabilities.SetCapability("os", "Windows");
                    capabilities.SetCapability("os_version", "10");
                    capabilities.SetCapability("resolution", "1024x768");
                    capabilities.SetCapability("browserstack.user", "saifafzal2");
                    capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");

                   
                    if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                    {
                        capabilities.SetCapability("browserstack.local", "true");
                    }
                         capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.idleTimeout", 120);
                    capabilities.SetCapability("resolution", "1024x768");
                             capabilities.SetCapability("build", "_" + date + "(chrome)");
                    capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    capabilities.SetCapability("name", "" + this.GetType().Name + "." + browser);
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                    capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");
                    _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
                 
                    break;
                case "safari":
                    capabilities.SetCapability("browser", "Safari");
                    capabilities.SetCapability("browser_version", "9.1");
                    capabilities.SetCapability("os", "OS X");
                    capabilities.SetCapability("os_version", "El Capitan");
                    capabilities.SetCapability("browserstack.safari.enablePopups", "true");
                    //capabilities = DesiredCapabilities.Chrome();
                    //   capabilities.SetCapability("browser", "Chrome");
                    //capabilities.SetCapability("browser_version", "47.0");
                    capabilities.SetCapability("browserstack.idleTimeout", 300);
                
                    capabilities.SetCapability("browserstack.video", "true");
                    if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                    {
                        capabilities.SetCapability("browserstack.local", "true");
                    }
                         capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.idleTimeout", 120);
                    capabilities.SetCapability("resolution", "1024x768");
                             capabilities.SetCapability("build", "_" + date + "(safari)");
                    capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    capabilities.SetCapability("name", "" + this.GetType().Name + "." + browser);
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                    capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");
                    _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                    break;
                case "iebs":

                    capabilities.SetCapability("browser", "IE");
                    capabilities.SetCapability("browser_version", "11.0");
                    capabilities.SetCapability("os", "Windows");
                    capabilities.SetCapability("os_version", "7");
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.ie.enablePopups", "true");
                    capabilities.SetCapability("resolution", "1280x800");
                    capabilities.SetCapability("browserstack.video", "false");
                    if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                    {
                        capabilities.SetCapability("browserstack.local", "true");
                    }
                    capabilities.SetCapability("build", "_" + date + "(Internet Explorer 11)");
                    capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    capabilities.SetCapability("name", "" + this.GetType().Name + "." + browser);
                    capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                    capabilities.SetCapability("browserstack.key", ConfigurationManager.AppSettings["key"]);
                    _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                    break;
            
             
                case "edgech":
                 
                    capabilities.SetCapability("browser", "Edge");
                    capabilities.SetCapability("browser_version", "80.0");
                    capabilities.SetCapability("os", "Windows");
                    capabilities.SetCapability("os_version", "10");
                    capabilities.SetCapability("browserstack.idleTimeout", 300);
                    capabilities.SetCapability("browserstack.ie.unexpectedAlertBehaviour", "dismiss");

                    capabilities.SetCapability("browserstack.edge.enablePopups", "true");
                    capabilities.SetCapability(CapabilityType.UnexpectedAlertBehavior, false);
                    capabilities.SetCapability("build", "_" + date + "edge");
                    //   capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    capabilities.SetCapability("name", "" + this.GetType().Name + "." + "edge");
                    //   capabilities.SetCapability("browserstack.local","true");
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.user", "saifafzal2");
                    capabilities.SetCapability("browserstack.key", "xKyB3pqxin4cckGSvjvo");
                    _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                    _driver.Manage().Window.Maximize();
                    break;
                case "iexploreremote":
                    //capabilities = DesiredCapabilities.InternetExplorer();
                    //_driver = new RemoteWebDriver(new Uri("http://" + IP + ":8080/wd/hub"), capabilities);

                   // Use this class in leiu of DesiredCapabilities
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();

                    // Force Windows to launch IE through Create Process API and in "private" browsing mode
                   ieOptions.ForceCreateProcessApi = true;
                   ieOptions.BrowserCommandLineArguments = "-private";
                   // ieOptions.EnsureCleanSession = true;
                    ieOptions.AddAdditionalCapability("version", "10");
                    
                    // Convert ieOptions to an ICapabilities object and instantiate driver
                    _driver = new RemoteWebDriver(new Uri("http://" + IP + ":5555/wd/hub"), ieOptions.ToCapabilities(),new TimeSpan(0,15,0) );
                   
                    break;
                case "Mchbs":


                    capabilities.SetCapability("browserName", "android");
                    capabilities.SetCapability("device", "Samsung Galaxy S8");
                    capabilities.SetCapability("realMobile", "true");
                    capabilities.SetCapability("os_version", "7.0");
                    capabilities.SetCapability("browserstack.user", "somnathrout2");
                    capabilities.SetCapability("browserstack.key", "7JftVFSgTT91qBbSDexg");


                    if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                    {
                        capabilities.SetCapability("browserstack.local", "true");
                    }
                   // capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.idleTimeout", 120);
                   // capabilities.SetCapability("resolution", "1024x768");
                   // capabilities.SetCapability("build", "_" + date + "(chrome)");
                    capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    capabilities.SetCapability("name", "" + this.GetType().Name + "." + browser);
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                    capabilities.SetCapability("browserstack.key", "7JftVFSgTT91qBbSDexg");
                    _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                   // _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);

                    break;
                case "chromeheadless":

                    //    _driver = new ChromeDriver();

                    ChromeOptions options1h = new ChromeOptions();
                    //RelativeDirectory rd1 = new RelativeDirectory();
                    options1h.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
                    options1h.AddArguments("disable-infobars");
                    //var downloadDirectory1 = rd1.Up(1) + "downloads";
                    //Meridian_Common.MeridianFileDownload = downloadDirectory1;
                    //options1h.AddUserProfilePreference("download.default_directory", downloadDirectory1);
                    options1h.AddUserProfilePreference("download.prompt_for_download", false);
                    options1h.AddUserProfilePreference("disable-popup-blocking", "true");

                    options1h.AddArguments("--start-maximized");
                    //for heafless browser
                    options1h.AddArguments("--headless");
                  
                    _driver = new ChromeDriver(options1h);
                    var entries1 = _driver.Manage().Logs.GetLog(LogType.Browser);
                    foreach (var entry in entries1)
                    {
                        Console.WriteLine(entry.ToString());
                    }

                  
                    break;

                case "dockerchrome":


                    //DesiredCapabilities capabilities = new DesiredCapabilities();
                    capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
                    capabilities.SetCapability(CapabilityType.Platform, "LINUX");


                    //if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                    //{
                    //    capabilities.SetCapability("browserstack.local", "true");
                    //}
                    //capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    //capabilities.SetCapability("browserstack.idleTimeout", 120);
                    //capabilities.SetCapability("resolution", "1024x768");
                    //capabilities.SetCapability("build", "_" + date + "(chrome)");
                   // capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    //capabilities.SetCapability("name", "" + this.GetType().Name + "." + browser);
                    //capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                   // capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                   // capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");
                    string GridURL = "http://localhost:4444/wd/hub";
                    _driver = new RemoteWebDriver(new Uri(GridURL), capabilities);
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);

                    break;
                case "chbsedge":


                    capabilities.SetCapability("browser", "Edge");
                    capabilities.SetCapability("browser_version", "80.0");
                    capabilities.SetCapability("os", "Windows");
                    capabilities.SetCapability("os_version", "10");
                    capabilities.SetCapability("resolution", "1024x768");
                    capabilities.SetCapability("browserstack.user", "saifafzal2");
                    capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");


                    if (ConfigurationManager.AppSettings["localsitetesting"] == "True")
                    {
                        capabilities.SetCapability("browserstack.local", "true");
                    }
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.idleTimeout", 120);
                    capabilities.SetCapability("resolution", "1024x768");
                    capabilities.SetCapability("build", "_" + date + "(Edge)");
                    capabilities.SetCapability("project", "" + ConfigurationManager.AppSettings["project"]);
                    capabilities.SetCapability("name", "" + this.GetType().Name + "." + browser);
                    capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                    capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["username"]);
                    capabilities.SetCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs");
                    _driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);

                    break;

            }
         //   ExtractDataExcel.fillalldic();
           
                return _driver;
            

        }
     
        public static int ExecuteCommand(string commnd, int timeout)
        {
            try
            {
                var pp = new ProcessStartInfo("cmd.exe", "/C" + commnd)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WorkingDirectory = "C:\\",
                };
                var process = Process.Start(pp);
                process.WaitForExit(timeout);
                process.Close();
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //public void AppendBrowserDetail()
        //{
        //    string fileLocation = Application.StartupPath + "/TestResult.xml";

        //    if (File.Exists(fileLocation))
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(fileLocation);


        //        XmlNodeList lst = doc.SelectNodes("//environment");



        //        XmlNode node = lst[0];
        //        XmlAttribute att = doc.CreateAttribute("Browser");


        //        att.InnerText = Common.WebBrowser;
        //        node.Attributes.Append(att);
        //        doc.Save(fileLocation);
        //    }
        //}

        //public void TestFixtureSetUpforall()
        //{
        //    if (ObjectRepository.isrunning == false)
        //    {
        //        Common.closeie();
        //        //ExtractDataExcel.fillalldic();
        //        driver = StartBrowser();
        //        driver.Manage().Window.Maximize();
        //        // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
        //        driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);

        //    }

        //}


        //public void TestFixtureTearDownforall()
        //{
        //    ObjectRepository.isrunning = false;
        //    // driver.Close();
        //    //  driver.Quit();
        //}
    }
}