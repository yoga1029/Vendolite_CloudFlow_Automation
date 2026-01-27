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
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using VMS_Phase1PortalAT.FlowTest.Warehouse.Vendor;
using WindowsInput;
using WindowsInput.Native;

namespace VMS_Phase1PortalAT.FlowTest.Warehouse.WarehouseList
{

    public class AddWarehouse
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private object searchName;

        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public AddWarehouse(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddWarehouseFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding Warehouse");
            try
            {


                //Locate Warehouse Module
                IWebElement warehouseModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Warehouse")));
                warehouseModule.Click();

                // Fetching Warehouse List sub-menu
                IWebElement warehouseList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Warehouse0")));
                warehouseList.Click();
                Thread.Sleep(2000);

                for (int i = 0; i < AddWarehouseData.Warehouses.GetLength(0); i++)
                {

                    IWebElement searchTypeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
                    searchTypeButton.Click();
                    Thread.Sleep(2000);

                    IWebElement selectName = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(), ' Name ')]")));
                    selectName.Click();
                    Thread.Sleep(2000);


                    string searchName = AddWarehouseData.Warehouses[i, 0];
                    IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    searchText.Clear();
                    searchText.SendKeys(searchName + Keys.Enter);
                    Thread.Sleep(2000);

                    var rowData = driver.FindElements(By.XPath("//table//tbody/tr"));    //fetching table data
                    if (rowData.Count == 0)
                    {
                        Console.WriteLine($"Warehouse '{searchName}' not found. Adding Warehouse");

                        // Navigate to add warehouse page
                        IWebElement addWarehouseButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                        addWarehouseButton.Click();
                        Thread.Sleep(2000);

                        // Fill the input fields using 2D array
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name"))).SendKeys(AddWarehouseData.Warehouses[i, 1]);

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("lat"))).SendKeys(AddWarehouseData.Warehouses[i, 2]);

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("lon"))).SendKeys(AddWarehouseData.Warehouses[i, 3]);


                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("city"))).SendKeys(AddWarehouseData.Warehouses[i, 4]);

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("state"))).SendKeys(AddWarehouseData.Warehouses[i, 5]);

                        driver.FindElement(By.Name("branch")).Click();
                        string branchName = AddWarehouseData.Warehouses[i, 6];
                        string dynamicXPath = $"//span[text()=' {branchName} ']";
                        driver.FindElement(By.XPath(dynamicXPath)).Click();


                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("phoneNo"))).SendKeys(AddWarehouseData.Warehouses[i, 7]);
                        Thread.Sleep(1000);


                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span [contains(text(),'publish' )]"))).Click();
                        Thread.Sleep(1000);
                        var sim = new InputSimulator();
                        sim.Keyboard.TextEntry(AddWarehouseData.Warehouses[i, 8]);
                        sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                        Thread.Sleep(1000);


                        driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                        Thread.Sleep(2000);


                    }
                }
                Console.WriteLine($" '{searchName}' Found. Moving to AddVendor");
                AddVendor vendorList = new AddVendor(driver);
                vendorList.AddVendorFlow();
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
