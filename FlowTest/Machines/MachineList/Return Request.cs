using AventStack.ExtentReports;
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

namespace VMS_Phase1PortalAT.FlowTest.Machines.MachineList
{
    //[TestClass]
    public class ReturnRequest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private static ExtentReports extent;
        private static ExtentTest test;

        public ReturnRequest(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        //[TestInitialize]
        //public void Setup()
        //{
        //    driver = new ChromeDriver();
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //}

        //[TestMethod]
        public void ReturnRequestFlow()
        {

            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Returning the Products to warehouse");
            try
            {
                ////Login
                //var login = new Login(driver);
                //login.CompanyLoginSuccess();
                Thread.Sleep(2000);
                //Fetching Machine List
                IWebElement machineMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
                machineMenu.Click();
                Thread.Sleep(1000);
                IWebElement requests = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines2")));
                requests.Click();
                Thread.Sleep(2000);
                IWebElement ReturnTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@role='tab']//div[text()='Return']")));
                ReturnTab.Click();
                Thread.Sleep(2000);

                IWebElement AddReturnRequest = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Add Return request')]")));
                AddReturnRequest.Click();
                Thread.Sleep(2000);

                //Fill the input fields
                string machineId = /*"2VE0000224"*/ MachineMapping.unmappedMachineForMapping;
                Console.WriteLine("Selected machine for returning products: " + machineId);

                // 1. Click the dropdown
                IWebElement machineDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("machineIds")));
                machineDropdown.Click();
                Thread.Sleep(2000);

                // 2. Wait for list to appear
                var machineOptions = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("mat-option span")));

                // 3. Loop through dropdown and click exact match
                bool found = false;
                foreach (var option in machineOptions)
                {
                    string optionText = option.Text.Trim();
                    //Console.WriteLine("Found option: " + optionText);

                    if (optionText.Equals(machineId, StringComparison.OrdinalIgnoreCase))
                    {
                        option.Click();
                        Console.WriteLine("Machine selected: " + optionText);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Machine ID NOT FOUND in dropdown! → " + machineId);
                }
                Thread.Sleep(1000);
                IWebElement checkAllButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[normalize-space()='Check All']")));
                checkAllButton.Click();
                driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                Thread.Sleep(3000);

                //Warehouse Assigning to Return the products
                IWebElement warTransactionsButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions")));
                warTransactionsButton.Click();
                Thread.Sleep(3000);

                IWebElement returnRequestMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions3")));
                returnRequestMenu.Click();
                Thread.Sleep(3000);

                IWebElement searchTypeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
                searchTypeButton.Click();
                Thread.Sleep(2000);
                IWebElement selectMachineId = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(normalize-space(),'Machine Id')]")));
                selectMachineId.Click();
                Thread.Sleep(2000);
                IWebElement searchRequest = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
                searchRequest.Clear();
                searchRequest.SendKeys(/*MachineMapping.unmappedMachineForMapping */ machineId + Keys.Enter);
                Thread.Sleep(2000);

                IWebElement actionButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[11]")));
                actionButton.Click();
                Thread.Sleep(1000);

                IWebElement assignWarehouseButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Assign Warehouse ')]")));
                assignWarehouseButton.Click();
                Thread.Sleep(2000);

                IWebElement warehouseDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("providorWarehouseId")));
                warehouseDropdown.Click();
                Thread.Sleep(2000);

                String chooseWarehouse = ReturnRequestData.refillDatas["warehouseName"];
                IWebElement choosingWarehouse = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(), ' {chooseWarehouse} ')]")));
                choosingWarehouse.Click();

                IWebElement saveWarehouse = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
                saveWarehouse.Click();
                Thread.Sleep(3000);

                IWebElement actionButton1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[11]")));
                actionButton1.Click();
                Thread.Sleep(2000);

                IWebElement pickupStock = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Pick Up Stock ')]")));
                pickupStock.Click();
                Thread.Sleep(3000);

                IWebElement confirmPickup = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Pick Up ']")));
                confirmPickup.Click();
                Thread.Sleep(3000);

                IWebElement actionButton2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[11]")));
                actionButton2.Click();
                Thread.Sleep(2000);

                IWebElement completeReturn = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Complete Return ')]")));
                completeReturn.Click();
                Thread.Sleep(2000);

                IWebElement checkAllButton1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[normalize-space()='Check All']")));
                checkAllButton1.Click();
                driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                Thread.Sleep(4000);


                //SETTING LOCATION AND PARAMETERS 
                //Fetching Machine menu
                IWebElement machineMenu1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
                machineMenu1.Click();

                // Fetching Machine List
                IWebElement machineList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
                machineList.Click();
                Thread.Sleep(1000);

                //string machineId = /*"2VE0000218" */ MachineMapping.unmappedMachineForMapping;
                //Console.WriteLine("Selecting machine: " + machineId);

                IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                searchText.Clear();
                searchText.SendKeys(machineId + Keys.Enter);
                Thread.Sleep(3000);

                // Action Button 
                IWebElement actionBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
                actionBtn.Click();
                Thread.Sleep(1000);

                //Fetching the details of the machine 
                IWebElement machineDetails = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
                machineDetails.Click();
                Thread.Sleep(3000);

                //Set Location for Machine
                Console.WriteLine("Setting the Location of the Machine");
                IWebElement selectLocation = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='cityText']")));
                selectLocation.Click();

                IWebElement city = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("City")));
                city.Clear();
                city.SendKeys(LocationData.location[0, 0]);
                IWebElement state = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("State")));
                state.Clear();
                state.SendKeys(LocationData.location[0, 1]);
                IWebElement plusCode = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("pluscode")));
                plusCode.Clear();
                plusCode.SendKeys(LocationData.location[0, 2]);
                IWebElement validatePlusCode = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(),' Validate Plus Code ')]")));
                validatePlusCode.Click();
                Thread.Sleep(1000);
                IWebElement saveLocation = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), ' Save ')]")));
                saveLocation.Click();
                Console.WriteLine("Machine's Location Updated");
                Thread.Sleep(4000);


                //SET PARAMETERS
                //Read expected parameters from ParametersData file
                IWebElement parameters = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(),' Parameters ')]")));
                parameters.Click();
                Thread.Sleep(1000);
                List<string> expectedParams = new List<string>()
                {
                    ParametersData.parameters[0, 0],
                    ParametersData.parameters[0, 1],
                    ParametersData.parameters[0, 2]
                };

                // Scan existing parameters on Machine Parameters popup
                var existingParamElements = driver.FindElements(By.XPath("//div[@class='itemName']/div"));
                List<string> presentParams = existingParamElements.Select(e => e.Text.Trim()).ToList();

                Console.WriteLine("Present Parameters:");
                presentParams.ForEach(Console.WriteLine);

                // Build missing parameter list
                List<string> missingParams = expectedParams.Where(p => !presentParams.Contains(p)).ToList();

                Console.WriteLine("Missing Parameters:");
                missingParams.ForEach(Console.WriteLine);

                //If Missing Parameters Exixts
                if (missingParams.Count != 0)
                {
                    // Click "Add Parameters" button 
                    IWebElement addParameterBtn = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//div[contains(@class,'parameterDisplay') and contains(.,'Add Parameters')]")));
                    addParameterBtn.Click();
                    Thread.Sleep(2000);

                    // Add missing parameters ONE BY ONE
                    foreach (string param in missingParams)
                    {
                        Console.WriteLine($"Adding missing parameter: {param}");

                        // Open dropdown
                        IWebElement dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("machineParameterToAdd")));
                        dropdown.Click();
                        Thread.Sleep(400);

                        // Select the parameter from dropdown
                        IWebElement paramOption = wait.Until(ExpectedConditions.ElementToBeClickable(
                                By.XPath($"//div[contains(@class,'cdk-overlay-pane')]//span[normalize-space()='{param}']")));
                        paramOption.Click();
                        Thread.Sleep(400);

                        // Click Add +
                        IWebElement addButtonInside = wait.Until(ExpectedConditions.ElementToBeClickable(
                                By.XPath("//button//span[contains(text(),'Add')]")));
                        addButtonInside.Click();
                        Thread.Sleep(700);
                    }

                    IWebElement enableButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(),'Enable')]")));
                    enableButton.Click();
                    Thread.Sleep(1000);

                    IWebElement closePopup = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-icon[text()='clear']")));
                    closePopup.Click();
                    Thread.Sleep(1000);
                    Console.WriteLine("All missing parameters added & enabled successfully");
                }
                else
                {
                    Console.WriteLine("All parameters already exist. Nothing to add.");
                    IWebElement closeNow = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-icon[text()='clear']")));
                    closeNow.Click();
                    Thread.Sleep(800);

                }
                Thread.Sleep(3000);

                Console.WriteLine("Parameter and Location are Updated. Moving to Add Functions of the Machine...");
                //MachineFunctions machineFunction = new MachineFunctions(driver);
                //machineFunction.MachineFunctionsFlow();


                Console.WriteLine("Products are Returned. Moving to Scrapping the Machine...");
                MachineScrapping scrapProduct = new MachineScrapping(driver);
                scrapProduct.MachineScrappingFlow();
                test.Pass();
            }
            catch (Exception e)
            {
                test.Fail(e);
            }

            extent.Flush();
        }

    }
}
