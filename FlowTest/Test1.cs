//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace MyFirstSeleniumTest
//{
//    [TestClass]
//    public class GoogleSearchTest
//    {
//        IWebDriver driver;

//        [TestInitialize] // Runs before each test
//        public void StartBrowser()
//        {
//            driver = new ChromeDriver(); // Opens Chrome
//        }

//        //[TestMethod] // Your test case
//        //public void SearchInGoogle()
////        //{
////        //    driver.Navigate().GoToUrl("https://www.google.com/");
////        //    IWebElement searchBox =  driver.FindElement(By.Name("q")); // Type
////        //    searchBox.SendKeys("dharshini" + Keys.Enter);
////        //    Assert.IsTrue(driver.Title.Contains("Selenium C#")); // Verify
////        //}

////        //[TestCleanup] // Runs after each test
////        //public void CloseBrowser()
////        //{
////        //    driver.Quit(); // Close browser
////        //} 


////        [TestMethod]
////        public void SearchInGoogle()
////        {
////            // Step 1: Go to Google
////            driver.Navigate().GoToUrl("https://www.google.com");

////            // Step 2: Find the search box and type something
////            IWebElement searchBox = driver.FindElement(By.Name("q"));
////            searchBox.SendKeys("Selenium WebDriver C#");

////            // Step 3: Press Enter to search
////            searchBox.SendKeys(Keys.Enter);

////            // Step 4: Wait for results (simple wait)
////            System.Threading.Thread.Sleep(2000);

////            // Step 5: Check if results contain our search term
////            string pageSource = driver.PageSource;
////            Assert.IsTrue(pageSource.Contains("Selenium"), "Search results do not contain the expected text.");
////        }

////    }
////}

//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace SeliniumClassDemo
//{
//    [TestClass]
//    public class ClassNameLocatorSample
//    {
//        IWebDriver driver;

//        [TestInitialize]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//        }

//        [TestMethod]
//        public void SearchWikipidea()
//        {
//            driver.Navigate().GoToUrl("https://www.wikipedia.org/");


//            IWebElement searchBox = driver.FindElement(By.ClassName("search-input"));
//            searchBox.SendKeys("Selenium (software)");

//            // Find search button using class name
//            IWebElement searchButton = driver.FindElement(By.ClassName("pure-button"));
//            searchButton.Click();
//        }
//    }
//}



//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System.Collections.Generic;

//namespace SeleniumDemo
//{
//    [TestClass]
//    public class ClassNameLocatorExample
//    {
//        IWebDriver driver;

//        [TestInitialize]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//        }

//        [TestMethod]
//        public void ClickLaptopsCategory()
//        {
//            driver.Navigate().GoToUrl("https://www.google.com/");

//            // Find "Laptops" category by class name
//            IWebElement searchName = driver.FindElement(By.Name("q"));
//            searchName.SendKeys(("dharshini") + Keys.Enter);

//            // Wait a bit to see the action
//            System.Threading.Thread.Sleep(2000);
//        }

        //[TestCleanup]
        //public void TearDown()
        //{
        //    driver.Quit();
        //}
//    }
//}

