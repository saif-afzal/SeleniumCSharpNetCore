using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
 
namespace Selenium2
{
    public static class Common
    {
        private static TimeSpan _defaultTimeSpan = new TimeSpan(0, 0, 360);
        private static string Token;
 
        public static string WebBrowser { get; set; }
        public static TimeSpan DriverTimeout
        {
            get { return _defaultTimeSpan; }
            set { _defaultTimeSpan = value; }
        }
        public static string token
        {
            get{return Token;}
            set { Token=string.Format("{0:ddhhssmmss}", DateTime.Now);}
            
        }
        public static void closeie()
        {
            string[] processtokill = { "IEDriverServer.exe *32", "iexplore" };
            foreach (string currprocess in processtokill)
            {
            foreach (Process p in System.Diagnostics.Process.GetProcessesByName("iexplore"))
            {
                try
                {
                    p.Kill();
                    p.WaitForExit(); // possibly with a timeout
                }
                catch (Win32Exception winException)
                {
                    // process was terminating or can't be terminated - deal with it
                }
                catch (InvalidOperationException invalidException)
                {
                    // process has already exited - might be able to let this one go
                }
            }
            }

        }
        }
     
    }
