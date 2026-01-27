using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Docker.DotNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Machines.MachineList;
using VMS_Phase1PortalAT.FlowTest.Machines.ProductMapping;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Warehouse_Transactions.Purchase
{
    //[TestClass]
    public class AddPurchase
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        /*[TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        } */

        public AddPurchase(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }
        public void AddPurchaseFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Purchasing Products");
            try
            {
                //var login = new Login(driver);
                //login.CompanyLoginSuccess();

                //locate Warehouse Module
                IWebElement warehouseTransactionsButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space(text())='W. Transactions']")));
                warehouseTransactionsButton.Click();
                Thread.Sleep(2000);

                //Go to Purchase module
                IWebElement purchaseMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions0")));
                purchaseMenu.Click();
                Thread.Sleep(2000);


                IWebElement AddWarehousePurchase = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Add Warehouse Purchase')]")));
                AddWarehousePurchase.Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Name("warehouse")).Click();
                string warehouseName = AddPurchaseData.Purchases[0, 0];
                string dynamicWarehouseXPath = $"//span[text()=' {warehouseName} ']";
                driver.FindElement(By.XPath(dynamicWarehouseXPath)).Click();

                for (int i = 0; i < AddPurchaseData.Purchases.GetLength(0); i++)
                {

                    ////Filter by product
                    //IWebElement productFilter = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
                    //productFilter.Click();
                    //Thread.Sleep(2000);

                    //IWebElement selectProductName = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(), ' Product Name ')]")));
                    //selectProductName.Click();
                    //Thread.Sleep(2000);


                    //string chooseProductName = AddPurchaseData.Purchases[i, 5];
                    //IWebElement enterProductName = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    //enterProductName.Click();
                    //enterProductName.Clear();
                    //enterProductName.SendKeys(chooseProductName + Keys.Enter);

                    //var rows = driver.FindElements(By.XPath("//table//tbody/tr"));
                    //if (rows.Count == 0)
                    //{
                    //Console.WriteLine($"Product not found. Adding Purchase of the product");
                    //IWebElement AddWarehousePurchase = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Add Warehouse Purchase')]")));
                    //AddWarehousePurchase.Click();
                    //Thread.Sleep(1000);

                    //driver.FindElement(By.Name("warehouse")).Click();
                    //string warehouseName = AddPurchaseData.Purchases[0, 0];
                    //string dynamicWarehouseXPath = $"//span[text()=' {warehouseName} ']";
                    //driver.FindElement(By.XPath(dynamicWarehouseXPath)).Click();



                    // Add Purchase Page

                    driver.FindElement(By.Name("vendor")).Click();
                    string vendorName = AddPurchaseData.Purchases[i, 1];
                    string dynamicVendorXPath = $"//span[text()=' {vendorName} ']";
                    driver.FindElement(By.XPath(dynamicVendorXPath)).Click();

                    driver.FindElement(By.Name("productId")).Click();
                    string productName = AddPurchaseData.Purchases[i, 2];
                    string dynamicProductXPath = $"//span[contains(text(), ' {productName} ')]";
                    driver.FindElement(By.XPath(dynamicProductXPath)).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("qty"))).SendKeys(AddPurchaseData.Purchases[i, 3]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("batchId"))).SendKeys(AddPurchaseData.Purchases[i, 4]);

                    // Expiry Date selection
                    IWebElement expiryCalendarIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("drange")));
                    expiryCalendarIcon.Click();
                    Thread.Sleep(1000);

                    IWebElement yearControl = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='owl-dt-calendar-control']")));
                    yearControl.Click();
                    Thread.Sleep(1000);

                    IWebElement yearToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 6]}']]")));
                    yearToSelect.Click();
                    Thread.Sleep(1000);

                    IWebElement monthToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 7]}']]")));
                    monthToSelect.Click();
                    Thread.Sleep(1000);

                    IWebElement dayToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 8]}']]")));
                    dayToSelect.Click();
                    Thread.Sleep(1000);

                    // Bill Date selection
                    IWebElement billDateCalendarIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("drange2")));
                    billDateCalendarIcon.Click();
                    Thread.Sleep(1000);


                    IWebElement yearControl1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='owl-dt-calendar-control']")));
                    yearControl1.Click();
                    Thread.Sleep(1000);

                    IWebElement yearToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 9]}']]")));
                    yearToSelect1.Click();
                    Thread.Sleep(1000);

                    IWebElement monthToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 10]}']]")));
                    monthToSelect1.Click();
                    Thread.Sleep(1000);

                    IWebElement dayToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 11]}']]")));
                    dayToSelect1.Click();
                    Thread.Sleep(3000);

                    IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Add ']")));
                    addButton.Click();
                    Thread.Sleep(2000);
                    //}


                }
                IWebElement saveButton1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
                saveButton1.Click();
                Thread.Sleep(2000);

                Console.WriteLine("Products Purchased. Moving to Raise Refill Request...");
                RaiseRefillRequest purchase = new RaiseRefillRequest(driver);
                purchase.RaiseRefillRequestFlow();
                test.Pass();
            }
            catch (Exception ex)
            {
                test.Fail(ex);
            }
            extent.Flush();
        }

    }
}

