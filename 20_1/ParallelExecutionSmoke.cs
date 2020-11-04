using System;
using System.Collections.Specialized;
using System.Configuration;

using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.Meridian.Suite;

namespace ParallelTestingSolution
{



    [TestFixture("parallel", "chrome")]
    //[TestFixture("parallel", "firefox")]
    [TestFixture("parallel", "safari")]
    //[TestFixture("parallel", "ie")]
    [TestFixture("parallel", "edge")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ParallelTestSmoke : SmokeTest_20_2_Parallel
    {
        public ParallelTestSmoke(string profile, string environment) : base(profile, environment) { }

    }
}