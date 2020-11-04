using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;


namespace _19_1
{
   public class Eventwrapper:EventFiringWebDriver
    {
        public Eventwrapper(IWebDriver driver):base(driver)
        {
            IWebDriver Driver = driver;
        }
       
    }
}
