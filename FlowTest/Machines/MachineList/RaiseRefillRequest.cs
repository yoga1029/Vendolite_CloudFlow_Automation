using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;



namespace VMS_Phase1PortalAT.FlowTest.Machines.MachineList
{
    //[TestClass]
    public class RaiseRefillRequest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public static string productName;
        public static string reqQty;
        public static IList<IWebElement> outofstockProducts;
        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;

        //[TestInitialize]
        //public void Setup()
        //{
        //    driver = new ChromeDriver();
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //}

        public RaiseRefillRequest(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        //[TestMethod]
        public void RaiseRefillRequestFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Raising Refill Request");
            try
            {
                ////Login
                //var login = new Login(driver);
                //login.CompanyLoginSuccess();

                //Fetching Machine List
                IWebElement machineMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
                machineMenu.Click();
                Thread.Sleep(1000);

                IWebElement machineList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
                machineList.Click();
                Thread.Sleep(2000);

                IWebElement machineFilter = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
                machineFilter.Click();
                machineFilter.Clear();
                machineFilter.SendKeys(MachineMapping.unmappedMachineForMapping /* "2VE0000223" */ + Keys.Enter);
                Thread.Sleep(3000);

                //CHANGING OPERTION STATUS to Down Planned
                // Action Button 
                IWebElement actionBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
                actionBtn.Click();
                Thread.Sleep(1000);

                //Fetching the details of the machine 
                IWebElement machineDetails = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
                machineDetails.Click();
                Thread.Sleep(3000);

                //Operation Status
                Console.WriteLine("Setting the Status of the Machine To Down Planned");
                IWebElement selectStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Operation Status')]/following::a[1]")));
                selectStatus.Click();
                Thread.Sleep(1000);

                IWebElement statusDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-select[@name='status']")));
                statusDropdown.Click();

                IWebElement downPlannedOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-option//span[contains(normalize-space(),'Down (Planned)')]")));
                downPlannedOption.Click();

                IWebElement saveStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
                saveStatus.Click();
                Thread.Sleep(2000);
                driver.Navigate().Back();
                Thread.Sleep(2000);

                IWebElement machineFilter1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
                machineFilter1.Click();
                machineFilter1.Clear();
                machineFilter1.SendKeys(MachineMapping.unmappedMachineForMapping /* "2VE0000223" */ + Keys.Enter);
                Thread.Sleep(3000);


                //Raising refill request
                IWebElement actionButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[10]")));
                actionButton.Click();
                Thread.Sleep(1000);

                IWebElement raiseRefillRequest = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Raise Refill Request')]")));
                raiseRefillRequest.Click();
                Thread.Sleep(3000);

                IWebElement saveRequest = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[.//span[text()=' Save ']]")));
                saveRequest.Click();
                Thread.Sleep(1000);
                driver.Navigate().Back();
                Thread.Sleep(3000);

                //Warehouse Assigning
                IWebElement warTransactionsButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions")));
                warTransactionsButton.Click();
                Thread.Sleep(3000);

                IWebElement refillRequestMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions2")));
                refillRequestMenu.Click();
                Thread.Sleep(3000);

                IWebElement actionButton1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
                actionButton1.Click();
                Thread.Sleep(1000);

                IWebElement assignWarehouseButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Assign Warehouse ')]")));
                assignWarehouseButton.Click();
                Thread.Sleep(1000);

                IWebElement warehouseDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("providorWarehouseId")));
                warehouseDropdown.Click();

                String chooseWarehouse = RaiseRefillRequestData.refillDatas["warehouseName"];
                IWebElement choosingWarehouse = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(), ' {chooseWarehouse} ')]")));
                choosingWarehouse.Click();

                IWebElement saveWarehouse = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
                saveWarehouse.Click();
                Thread.Sleep(3000);

                //Stock Selection
                IWebElement actionButton2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
                actionButton2.Click();
                Thread.Sleep(1000);
                IWebElement selectStock = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Select Stock ')]")));
                selectStock.Click();
                Thread.Sleep(2000);


                // Check Stock Availability and Collect Out-of-Stock Products
                List<(string ProductName, string ReqQty)> outOfStockList = new List<(string, string)>();

                //IList<IWebElement> outofstockProducts = driver.FindElements(By.XPath("//table/tbody/tr"));

                //foreach (var row in outofstockProducts)
                //{
                //    var outOfStockText = row.FindElements(By.XPath(".//span[contains(text(),'Out of Stock')]"));
                //    if (outOfStockText.Count > 0 && outOfStockText[0].Displayed)
                //    {
                //        string productName = row.FindElement(By.XPath(".//td[2]")).Text; // Product Name column
                //        string reqQty = row.FindElement(By.XPath(".//td[5]")).Text;      // Required Qty column

                //        // Store directly as a tuple (ProductName, ReqQty)
                //        outOfStockList.Add((productName, reqQty));

                //        Console.WriteLine($"[Out of Stock Found] Product: {productName}, Required Qty: {reqQty}");
                //    }
                //}

                // If there are out-of-stock products → go to Purchase module
                if (outOfStockList.Count == 0)
                {
                    driver.FindElement(By.XPath("//button//span[text()=' Save ']")).Click();
                    Thread.Sleep(4000);

                    //Stock Selection
                    IWebElement actionButton3 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
                    actionButton3.Click();
                    Thread.Sleep(1000);
                    IWebElement completeRefill = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Complete Refill ')]")));
                    completeRefill.Click();
                    Thread.Sleep(2000);

                    IWebElement checkAllButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[normalize-space()='Check All']")));
                    checkAllButton.Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                    Thread.Sleep(4000);

                    //Fetching Machine List
                    IWebElement machineMenu1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
                    machineMenu1.Click();
                    Thread.Sleep(1000);

                    IWebElement machineList1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
                    machineList1.Click();
                    Thread.Sleep(2000);

                    IWebElement machineFilter2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
                    machineFilter2.Click();
                    machineFilter2.Clear();
                    machineFilter2.SendKeys(MachineMapping.unmappedMachineForMapping + Keys.Enter);
                    Thread.Sleep(2000);

                    //CHANGING OPERTION STATUS to ONLINE
                    // Action Button 
                    IWebElement actionBtn1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
                    actionBtn1.Click();
                    Thread.Sleep(1000);

                    //Fetching the details of the machine 
                    IWebElement machineDetails1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
                    machineDetails1.Click();
                    Thread.Sleep(3000);

                    //Operation Status
                    Console.WriteLine("Setting the Status of the Machine to ONLINE");
                    IWebElement selectStatus1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Operation Status')]/following::a[1]")));
                    selectStatus1.Click();
                    Thread.Sleep(1000);

                    IWebElement statusDropdown1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-select[@name='status']")));
                    statusDropdown1.Click();

                    IWebElement onlineOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-option//span[contains(normalize-space(),'Online')]")));
                    onlineOption.Click();

                    IWebElement saveStatus1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
                    saveStatus1.Click();
                    Thread.Sleep(2000);


                }
                else
                {
                    driver.FindElement(By.XPath("//button//span[text()='Close']")).Click();
                    Thread.Sleep(2000);
                }

                Console.WriteLine("Refill Request Raised. Moving to Returning the Product...");
                ReturnRequest returnProduct = new ReturnRequest(driver);
                returnProduct.ReturnRequestFlow();
                test.Pass();
            }
            catch (Exception ex)
            {
                test.Fail(ex);
            }
            extent.Flush();

        }







        private void ClickActionButtonByMachineId(string machineId)
        {
            try
            {
                IWebElement row = wait.Until(ExpectedConditions.ElementExists(By.XPath("//table//tr[td[2][contains(normalize-space(),'" + machineId + "')]]")));
                IWebElement actionButton = row.FindElement(By.XPath(".//td[contains(@class,'mat-column-action')]//button"));
                actionButton.Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Machine Id not found: " + machineId);
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timed out waiting for machine row: " + machineId);
            }
        }

        private void ClickActionButtonByMachineId2(string machineId)
        {
            try
            {
                IWebElement row = wait.Until(ExpectedConditions.ElementExists(By.XPath("//table//tr[td[4][contains(normalize-space(),'" + machineId + "')]]")));
                IWebElement actionButton = row.FindElement(By.XPath(".//td[contains(@class,'mat-column-action')]//button"));
                actionButton.Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Machine Id not found: " + machineId);
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timed out waiting for machine row: " + machineId);
            }
        }
    }
}
