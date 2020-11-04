using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium2.Meridian
{
    public class ExceptionandLogging
    {

        public static void ExceptionLogging(Exception ex, string CurrentTestName, string currentClassName, String CurrentMethodName, string errorfromfunction, IWebDriver driver)
        {
            
          return;
          //  driver.CaptureScreenshotandLog(CurrentTestName + "--" + currentClassName + "-" + CurrentMethodName, ex.Message, ex.StackTrace);
            string MessageToPrint = string.Empty;
            if (string.IsNullOrEmpty(errorfromfunction))
            {
                MessageToPrint = "Name of Class: " + currentClassName + "Name of Method: " + CurrentMethodName + "Error Message: " + ex.Message;
            }
            else
            {
                MessageToPrint = "Name of Class: " + currentClassName + "Name of Method: " + CurrentMethodName + "Error Message: " + errorfromfunction;
            }


            if (ex is ElementNotVisibleException)
            {

                throw new ElementNotVisibleException(MessageToPrint);

            }

            if (ex is InvalidCookieDomainException)
            {

                throw new InvalidCookieDomainException(MessageToPrint);

            }
            if (ex is InvalidElementStateException)
            {

                throw new InvalidElementStateException(MessageToPrint);

            }
            if (ex is InvalidSelectorException)
            {

                throw new InvalidSelectorException(MessageToPrint);

            }
            if (ex is NoAlertPresentException)
            {

                throw new NoAlertPresentException(MessageToPrint);

            }

            if (ex is NoSuchElementException)
            {

                throw new NoSuchElementException(MessageToPrint);

            }

            if (ex is NoSuchFrameException)
            {

                throw new NoSuchFrameException(MessageToPrint);

            }
            if (ex is NoSuchWindowException)
            {

                throw new NoSuchWindowException(MessageToPrint);

            }
            if (ex is StaleElementReferenceException)
            {

                throw new StaleElementReferenceException(MessageToPrint);

            }
            if (ex is TimeoutException)
            {

                throw new TimeoutException(MessageToPrint);

            }

            if (ex is UnableToSetCookieException)
            {

                throw new UnableToSetCookieException(MessageToPrint);

            }
            if (ex is WebDriverException)
            {

                throw new TimeoutException(MessageToPrint);

            }
            if (ex is WebDriverTimeoutException)
            {

                throw new WebDriverTimeoutException(MessageToPrint);

            }
            throw new Exception(MessageToPrint);

        }
    }
}
