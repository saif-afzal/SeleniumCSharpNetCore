using System;
using System.Collections.Specialized;
using System.Configuration;

using NUnit.Framework;
using OpenQA.Selenium;
namespace ParallelTestingSolution
{



    [TestFixture("parallel", "chrome")]
    [TestFixture("parallel", "firefox")]
    [TestFixture("parallel", "safari")]
    [TestFixture("parallel", "ie")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ParallelTest : SingleTest
    {
        public ParallelTest(string profile, string environment) : base(profile, environment) { }
    }
}