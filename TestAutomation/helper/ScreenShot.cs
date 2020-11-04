using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium2.Meridian
{

   public class ScreenShot
    {

        private readonly IWebDriver driverobj;
      public static Random rng = new Random();
        public ScreenShot(IWebDriver driver)
        {
            driverobj = driver;
        }
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");

            string otherpath1 = string.Empty;
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string otherpath = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots/" + Todaysdate;
            otherpath1 = new Uri(otherpath).LocalPath;
            //  pth.Substring(0, pth.LastIndexOf("bin"))
            if (!Directory.Exists(otherpath))
            {

                // otherpath1 = new Uri(otherpath).LocalPath;
                Directory.CreateDirectory(otherpath1);


            }

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();




            string finalpth = otherpath1 + "\\" + screenShotName + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".png";
            string localpath = new Uri(finalpth).LocalPath;


            screenshot.SaveAsFile(localpath, OpenQA.Selenium.ScreenshotImageFormat.Png);

            return localpath;
            ////screenshot.SaveAsFile(localpath, OpenQA.Selenium.ScreenshotImageFormat.Png);
            //screenshot.SaveAsFile(localpath, OpenQA.Selenium.ScreenshotImageFormat.Bmp);
            //ImageToBase64(screenshot);
            //return localpath;
        }


        private static string ImageToBase64(Image image)
        {
            try
            {
                var imageStream = new MemoryStream();
                image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Bmp);
                imageStream.Position = 0;
                var imageBytes = imageStream.ToArray();
                var ImageBase64 = Convert.ToBase64String(imageBytes);
                return ImageBase64;
            }
            catch (Exception ex)
            {
                return "Error converting image to base64!";
            }
        }
    }
}
