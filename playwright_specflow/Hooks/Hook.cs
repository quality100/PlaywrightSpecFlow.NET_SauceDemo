using System;
using Allure.Commons;
using NUnit.Framework;
using TechTalk.SpecFlow;

//[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace PlaywrightSpecFlow.NET_SauceDemo.Hooks
{
    [Binding]
    public class Hooks
    {
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        [BeforeTestRun]
        public static void BeforeTestRun() 
        {
            allure.CleanupResultDirectory();
        }
    }
}