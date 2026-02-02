//using AventStack.ExtentReports;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VMS_Phase1PortalAT.FlowTest.Authentication;

//namespace VMS_Phase1PortalAT.FlowTest.Transactions.Sales
//{
//    [TestClass]
//    public class TransactionList
//    {
//        private IWebDriver driver;
//        private WebDriverWait wait;

//        public static string productName;
//        public static string reqQty;
//        public static IList<IWebElement> outofstockProducts;

//        //Report Generating
//        private static ExtentReports extent;
//        private static ExtentTest test;

//        [TestInitialize]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
//            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
//        }

//        //public MachineFunctions(IWebDriver driver)
//        //{
//        //    this.driver = driver;
//        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
//        //}

//        [TestMethod]
//        public void TransactionFlow()
//        {
//            extent = ExtentManager.GetInstance();
//            test = extent.CreateTest("Exporting the transaction");
//            try
//            {
//                //Login
//                var login = new Login(driver);
//                login.CompanyLoginSuccess();

//                //Fetching Machine List
//                IWebElement transactionsMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Transactions")));
//                transactionsMenu.Click();
//                Thread.Sleep(2000);

//                IWebElement salesList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Transactions0")));
//                salesList.Click();
//                Thread.Sleep(5000);

//                for (int i = 1; i <= 5; i++)
//                {
//                    // Open Export popup
//                    IWebElement exportButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[.//mat-icon[normalize-space()='cloud_download']]")));
//                    exportButton.Click();
//                    Thread.Sleep(2000);

//                    // Select radio option by index
//                    IWebElement optionRadio = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"(//div[@class='optionHolder2']//mat-radio-button)[{i}]")));
//                    optionRadio.Click();
//                    Thread.Sleep(2000);

//                    // Click checkbox (always 1st checkbox shown after selecting option)
//                    IWebElement checkbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(@class,'mat-checkbox-layout')])[1]")));
//                    checkbox.Click();
//                    Thread.Sleep(2000);

//                    // Click Download
//                    IWebElement downloadBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(), 'Download')]")));
//                    downloadBtn.Click();
//                    Thread.Sleep(2000);
//                }

//                //SELECTIVE COLUMN EXPORT
//                // Open Export popup
//                IWebElement exportButton1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[.//mat-icon[normalize-space()='cloud_download']]")));
//                exportButton1.Click();
//                Thread.Sleep(2000);

//                // Select Summary radio option 
//                IWebElement summaryOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"(//div[@class='optionHolder2']//mat-radio-button)[1]")));
//                summaryOption.Click();
//                Thread.Sleep(2000);

//                // Click selective checkboxes 
//                IWebElement machineIDcheckbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(@class,'mat-checkbox-layout')])[2]")));
//                machineIDcheckbox.Click();
//                Thread.Sleep(2000);
//                IWebElement trnxIdCheckbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(@class,'mat-checkbox-layout')])[3]")));
//                trnxIdCheckbox.Click();
//                Thread.Sleep(2000);
//                IWebElement statusCheckbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(@class,'mat-checkbox-layout')])[7]")));
//                statusCheckbox.Click();
//                Thread.Sleep(2000);
//                IWebElement paidTotalCheckbox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(@class,'mat-checkbox-layout')])[9]")));
//                paidTotalCheckbox.Click();
//                Thread.Sleep(2000);
//                IWebElement customerName = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(@class,'mat-checkbox-layout')])[12]")));
//                customerName.Click();
//                Thread.Sleep(2000);

//                // Click Download
//                IWebElement downloadButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(), 'Download')]")));
//                downloadButton.Click();
//                Thread.Sleep(2000);
//            }

//            catch (Exception ex)
//            {
//                test.Fail(ex);
//            }
//            extent.Flush();

//        }
//    }
//}
