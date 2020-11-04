using System;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    internal class Section1
    {
        internal static test2obj test2
        {
get { return new test2obj(); }
        }
    }

    internal class test2obj
    {
        public test3obj test3
        {
            get { return new test3obj(); }
        }
    }

    public class test3obj
    {
        internal void test4()
        {
            throw new NotImplementedException();
        }
    }
}