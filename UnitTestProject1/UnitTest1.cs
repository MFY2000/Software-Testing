using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private TestContext instance;

        public TestContext TestContext
        {
            get { return instance; }
            set { instance = value; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://adactinhotelapp.com/";
            driver.Close();
        }


        [TestMethod]
        public void TestMethod2()
        {
            /*var option = (new ChromeOptions());
                option.AddArgument("Headless");*/
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://adactinhotelapp.com/";

            driver.FindElement(By.Id("username")).SendKeys("ImadTester");
            driver.FindElement(By.Id("password")).SendKeys("ImadTester");
            driver.FindElement(By.Id("login")).Click();

            string actualResult = driver.FindElement(By.ClassName("welcome_menu")).Text;
            Assert.AreEqual("Welcome to Adactin Group of Hotels", actualResult);
            driver.Close();
        }

        [TestMethod]
        [TestCategory("DataDrive")]
        [TestCategory("DataDrive")]

        public void TestMethod3()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://adactinhotelapp.com/";

            driver.FindElement(By.Id("username")).SendKeys("s");
            driver.FindElement(By.Id("password")).SendKeys("s");
            driver.FindElement(By.Id("login")).Click();

            string actualResult = driver.FindElement(By.ClassName("auth_error")).Text;
            Assert.AreEqual("Invalid Login details or Your Password might have expired. Click here to reset your password", actualResult);
            driver.Close();
        }



        [TestMethod]
        [TestCategory("DataDrive")]
        [TestCategory("DataDrive")]
        [DataRow("ImadTester", "ImadTester", "welcome_menu", "Welcome to Adactin Group of Hotels", "log message")]
        [DataRow("ImadTester1", "ImadTester1", "auth_error", "Invalid Login details or Your Password might have expired. Click here to reset your password", "log Message Error")]
        public void TestMethod4(string username, string password, string locator, string message, string log_message)
        {
            var option = (new ChromeOptions());
            option.AddArgument("Headless");
            IWebDriver driver = new ChromeDriver(option);
            driver.Manage().Window.Maximize();
            driver.Url = "https://adactinhotelapp.com/";

            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login")).Click();

            string actualResult = driver.FindElement(By.ClassName(locator)).Text;
            Assert.AreEqual(message, actualResult, log_message);

            driver.Close();
        }

        [TestMethod]
        [TestCategory("DataDrive_withFIle")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "data1.xml", "Login", DataAccessMethod.Sequential)]
        public void TestMethod5()
        {
            var option = (new ChromeOptions());
            option.AddArgument("Headless");
            IWebDriver driver = new ChromeDriver(option);
            driver.Manage().Window.Maximize();
            driver.Url = TestContext.DataRow["url"].ToString();

            driver.FindElement(By.Id("username")).SendKeys(TestContext.DataRow["username"].ToString());
            driver.FindElement(By.Id("password")).SendKeys(TestContext.DataRow["password"].ToString());
            driver.FindElement(By.Id("login")).Click();

            string actualResult = driver.FindElement(By.ClassName(TestContext.DataRow["locator"].ToString())).Text;
            Assert.AreEqual(TestContext.DataRow["message"].ToString(), actualResult);

            driver.Close();
        }


        [TestMethod]
        [TestCategory("DataDrive_withFIleCSV")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "C:\\Users\\MFY\\source\\repos\\UnitTestProject1\\UnitTestProject1\\bin\\Debug\\data1.csv", "data1#csv", DataAccessMethod.Sequential)]
        public void TestMethod6()
        {
           /* var option = (new ChromeOptions());
            option.AddArgument("Headless");*/
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = TestContext.DataRow["url"].ToString();

            driver.FindElement(By.Id("username")).SendKeys(TestContext.DataRow["username"].ToString());
            driver.FindElement(By.Id("password")).SendKeys(TestContext.DataRow["password"].ToString());
            driver.FindElement(By.Id("login")).Click();

            string actualResult = driver.FindElement(By.ClassName(TestContext.DataRow["locator"].ToString())).Text;
            Assert.AreEqual(TestContext.DataRow["message"].ToString(), actualResult);

            driver.Close();
        }
    }



}
