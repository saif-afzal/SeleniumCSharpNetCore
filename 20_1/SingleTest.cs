using System;
using System.Collections.Specialized;
using System.Configuration;

using NUnit.Framework;
using OpenQA.Selenium;

namespace ParallelTestingSolution
{
    [TestFixture("single", "chrome")]
   // [Ignore("build configuration is parallel",Until ="2020-04-12")]
    public class SingleTest : BrowserStackNUnitTest
    {
        public SingleTest(string profile, string environment) : base(profile, environment) { }

        [Test]
        public void SearchGoogle()
        {
           
            driver.Navigate().GoToUrl("https://www.google.com/ncr");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("BrowserStack");
            query.Submit();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("BrowserStack - Google Search", driver.Title);
        }
    }
}
