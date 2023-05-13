using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assignment2
{
    [TestClass]
    public class Assignment
    {
        /*
         
            1.	Multiple Test Categories

         */
        [TestMethod]
        [TestCategory("Functional Testing")]
        [TestCategory("Positive Testing")]

        public void TestMethod1()
        {

        }

        /*
         
            2.	Parameterized Data.
            3.	Data handle from [DataRow].

         */

        [TestMethod]
        [TestCategory("DataDrive")]
        [DataRow("ImadTester", "ImadTester", "welcome_menu", "Welcome to Adactin Group of Hotels", "log message")]

        public void TestMethod2_3(string username, string password, string locator, string message, string log_message)
        {
        
        }



        [TestMethod]
        [Parallelizable(ParallelScope.Method)]
        public void TestMethod4()
        {
            // Test code here
        }
    }

    [TestClass]
    [DoNotParallelize]
    public class NonParallelizableTests
    {
        [TestMethod]
        [TestCategory("NonParallelizable")]
        public void TestMethod1()
        {
            // Test code here
            var option = (new ChromeOptions());
            option.AddArgument("Headless");
            IWebDriver driver = new ChromeDriver(option);

        }
    }
}
