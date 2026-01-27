using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
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
using VMS_Phase1PortalAT.FlowTest.Machines.ProductMapping;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using VMS_Phase1PortalAT.FlowTest.Warehouse_Transactions.Purchase;

namespace VMS_Phase1PortalAT.FlowTest.Warehouse.Vendor
{
    public class AddVendor
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private object searchName;

        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public AddVendor(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddVendorFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding Vendor");
            try
            {

                //Locate Warehouse Module
                IWebElement warehouseModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Warehouse")));
                warehouseModule.Click();

                // Fetching Vendor List sub-menu
                IWebElement vendorList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Warehouse1")));
                vendorList.Click();
                Thread.Sleep(2000);

                for (int i = 0; i < AddWarehouseData.Vendors.GetLength(0); i++)
                {
                    IWebElement searchTypeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
                    searchTypeButton.Click();
                    Thread.Sleep(2000);

                    IWebElement selectName = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(), ' Name ')]")));
                    selectName.Click();
                    Thread.Sleep(2000);

                    string searchName = AddWarehouseData.Vendors[i, 0];
                    IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    searchText.Clear();
                    searchText.SendKeys(searchName + Keys.Enter);
                    Thread.Sleep(2000);

                    var rowData = driver.FindElements(By.XPath("//table//tbody/tr"));    //fetching table data
                    if (rowData.Count == 0)
                    {
                        Console.WriteLine($"Warehouse '{searchName}' not found. Adding Warehouse");

                        // Navigate to add warehouse page
                        IWebElement addVendorButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                        addVendorButton.Click();
                        Thread.Sleep(2000);

                        // Fill the input fields using 2D array
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name"))).SendKeys(AddWarehouseData.Vendors[i, 1]);

                        driver.FindElement(By.Name("branch")).Click();
                        string branchName = AddWarehouseData.Vendors[i, 2];
                        string dynamicXPath = $"//span[text()=' {branchName} ']";
                        driver.FindElement(By.XPath(dynamicXPath)).Click();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("email"))).SendKeys(AddWarehouseData.Vendors[i, 3]);


                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("mobile"))).SendKeys(AddWarehouseData.Vendors[i, 4]);

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactPersonName"))).SendKeys(AddWarehouseData.Vendors[i, 5]);

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactPersonEmail"))).SendKeys(AddWarehouseData.Vendors[i, 6]);


                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactPersonMobile"))).SendKeys(AddWarehouseData.Vendors[i, 7]);
                        Thread.Sleep(1000);

                        driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                        Thread.Sleep(2000);

                    }
                }

                Console.WriteLine("Moving to Product Mapping ");
                Productmapping purchase = new Productmapping(driver);
                purchase.ProductMappingFlow();
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

