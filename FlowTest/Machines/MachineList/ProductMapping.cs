
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net;
using System.Xml.Linq;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Machines.MachineList;
using VMS_Phase1PortalAT.FlowTest.Utilities;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using VMS_Phase1PortalAT.FlowTest.Warehouse_Transactions.Purchase;


namespace VMS_Phase1PortalAT.FlowTest.Machines.ProductMapping
{
    //[TestClass]
    public class Productmapping
    {
        private IWebDriver driver;
        private WebDriverWait wait;
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
        public Productmapping(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        //[TestMethod]
        public void ProductMappingFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Mapping Products into Machine Slots");
            try
            {
                //    var login = new Login(driver);
                //    login.CompanyLoginSuccess();

                //Fetching Machine menu
                IWebElement machineMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
                machineMenu.Click();

                // Fetching Machine List
                IWebElement machineList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
                machineList.Click();
                Thread.Sleep(1000);

                string machineId = /*"2VE0000218" */ MachineMapping.unmappedMachineForMapping;
                Console.WriteLine("Selecting machine: " + machineId);

                IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                searchText.Clear();
                searchText.SendKeys(machineId + Keys.Enter);
                Thread.Sleep(3000);

                // Action Button 
                IWebElement actionButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
                actionButton.Click();
                Thread.Sleep(1000);

                //Fetching the details of the machine 
                IWebElement machineDetails = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
                machineDetails.Click();
                Thread.Sleep(3000);

                //Edit Planogram
                Thread.Sleep(3000);
                IWebElement editSlot = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@mattooltip='Edit Slot']")));
                editSlot.Click();
                Thread.Sleep(1000);

                IWebElement slotRowCount = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("slotRowCount")));
                slotRowCount.Clear();
                slotRowCount.SendKeys(PlanogramData.slotCounts[0, 0]);

                IWebElement slotColumnCount = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("slotColumnCount")));
                slotColumnCount.Clear();
                slotColumnCount.SendKeys(PlanogramData.slotCounts[0, 1]);

                IWebElement endingRowCount = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@name='slotColumnCount'])[2]")));
                endingRowCount.Clear();
                endingRowCount.SendKeys(PlanogramData.slotCounts[0, 0]);

                IWebElement endingColumnCount = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@type='number'])[6]")));
                endingColumnCount.Clear();
                endingColumnCount.SendKeys(PlanogramData.slotCounts[0, 1]);
                Thread.Sleep(1000);
                IWebElement saveSlots = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), ' Save ')]")));
                saveSlots.Click();
                Thread.Sleep(6000);
                Console.WriteLine("Product Matrix Changed again");

                //Edit machine info
                // wait for any overlay/loader to disappear
                wait.Until(driver =>
                {
                    var overlays = driver.FindElements(By.XPath("//div[contains(@class,'overlay')]"));
                    return overlays.Count == 0 || overlays.All(o => !o.Displayed);
                });

                // locate the EDIT INFO icon's parent button and click it
                IWebElement editInfo = wait.Until(
                    ExpectedConditions.ElementToBeClickable(
                        By.XPath("//mat-icon[normalize-space()='edit']/parent::button")
                    )
                );

                // scroll into view
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", editInfo);

                // click once
                editInfo.Click();

                // wait until Edit Info form is visible (proves click worked)
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("clientLocation")));



                IWebElement clientLocation = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("clientLocation")));
                clientLocation.Clear();
                clientLocation.SendKeys(machineInfoData.machineDetails[0, 0]);
                Thread.Sleep(2000);

                IWebElement routeIdentifier = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("routeIdentifier")));
                routeIdentifier.Clear();
                routeIdentifier.SendKeys(machineInfoData.machineDetails[0, 1]);
                Thread.Sleep(2000);

                // Direct Refill checkbox
                IWebElement directRefillCheckbox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='directRefill']")));

                if (directRefillCheckbox.Selected)
                {
                    Console.WriteLine("Direct Refill is checked. Unchecking now..");
                    IWebElement directRefillLabel = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Direct Refill Option')]")));
                    directRefillLabel.Click();
                    Thread.Sleep(1000); // allow Auto Refill to enable
                }
                else
                {
                    Console.WriteLine("Direct Refill is already unchecked. Moving to check the status of Auto Refill...");
                }

                // Auto Refill checkbox
                IWebElement autoRefillCheckbox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name ='disabledAutoRefill']")));

                if (autoRefillCheckbox.Selected)
                {
                    Console.WriteLine("Disable Auto Refill is checked. Unchecking now..");
                    IWebElement autoRefillLabel = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Disable Auto Refill')]")));
                    autoRefillLabel.Click();
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Disable Auto Refill is already unchecked. Saving..");
                }
                Thread.Sleep(2000);

                //Save
                IWebElement saveButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Save')]")));
                saveButton.Click();
                Thread.Sleep(2000);


                //// Edit Single Slot 
                Console.WriteLine("Product Mapping in to slots...");
                Thread.Sleep(3000);
                Actions a = new Actions(driver);

                //Product Assigning Matrix 
                for (int i = 0; i < ProductMappingData.products.GetLength(0); i++)
                {
                    Thread.Sleep(2000);
                    IWebElement product = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"(//mat-card)[{ProductMappingData.products[i, 0]}]")));

                    a.MoveToElement(product).Pause(TimeSpan.FromSeconds(3)).Perform();

                    //// String dynamicXPath1 = $"(//mat-card)[{slotIndex}]//button//mat-icon";
                    //IWebElement editSlot2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"(//mat-card)[{ProductMappingData.products[i, 0]}]//button//mat-icon")));
                    //editSlot2.Click();
                    //Thread.Sleep(2000);

                    // wait for overlay/loader to disappear
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                        By.XPath("//div[contains(@class,'overlay')]")
                    ));

                    // locate the EDIT BUTTON (not icon)
                    IWebElement editSlot2 = wait.Until(
                        ExpectedConditions.ElementToBeClickable(
                            By.XPath($"(//mat-card)[{ProductMappingData.products[i, 0]}]//button[.//mat-icon]")
                        )
                    );

                    // scroll into view
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", editSlot2);

                    // click safely
                    editSlot2.Click();

                    // Locate the toggle button input
                    IList<IWebElement> toggleButtons = driver.FindElements(By.XPath("//section[@class='full_width']//input"));

                    foreach (IWebElement toggleButton in toggleButtons)
                    {
                        // Check current state of toggle button
                        bool isToggleEnabled = toggleButton.Selected;
                        if (!isToggleEnabled)
                        {
                            Console.WriteLine("Toggle is OFF. Enabling now...");
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            js.ExecuteScript("arguments[0].click();", toggleButton);
                            Thread.Sleep(1000);
                            Console.WriteLine("Toggled Enabled.");
                        }
                    }

                    IWebElement selectProduct = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("product")));
                    selectProduct.Click();

                    //String name = ProductMappingData.products[i, 1];
                    IWebElement choosingProduct = wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath($"//div[@role='listbox']//div[contains(text(), ' {ProductMappingData.products[i, 1]} ')]")));
                    choosingProduct.Click();

                    IWebElement purchaseLimitPerUser = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("purchaseLimitPerUser")));
                    purchaseLimitPerUser.Clear();
                    purchaseLimitPerUser.SendKeys(ProductMappingData.products[i, 2]);

                    IWebElement purchaseLimitPerTransaction = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("purchaseLimitPerTransaction")));
                    purchaseLimitPerTransaction.Clear();
                    purchaseLimitPerTransaction.SendKeys(ProductMappingData.products[i, 3]);


                    IWebElement purchaseLimitResetPerUser = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("purchaseLimitResetPerUser")));
                    purchaseLimitResetPerUser.Click();
                    IWebElement resetTime = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[contains(text(), ' {ProductMappingData.products[i, 4]} ')]")));
                    resetTime.Click();

                    IWebElement stockLimitInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("stockLimit")));
                    stockLimitInput.Click();
                    //String stockLimit = ProductMappingData.products[i, 5];
                    //String stockLimitXPath = $"//span[contains(text(), ' {ProductMappingData.products[i, 5]} ')]";
                    IWebElement chooseStockLimit = wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath($"//span[contains(text(), ' {ProductMappingData.products[i, 5]} ')]")));
                    chooseStockLimit.Click();

                    IWebElement save = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), ' Save ')]")));
                    save.Click();
                }

                //Modify Planogram after Product Mapping
                IWebElement editSlot1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@mattooltip='Edit Slot']")));
                editSlot.Click();
                Thread.Sleep(1000);

                IWebElement slotRowCount1 = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("slotRowCount")));
                slotRowCount1.Clear();
                slotRowCount1.SendKeys(PlanogramData.slotCounts[0, 2]);


                IWebElement slotColumnCount1 = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("slotColumnCount")));
                slotColumnCount1.Clear();
                slotColumnCount1.SendKeys(PlanogramData.slotCounts[0, 3]);

                IWebElement endingRowCount1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@name='slotColumnCount'])[2]")));
                endingRowCount1.Clear();
                endingRowCount1.SendKeys(PlanogramData.slotCounts[0, 2]);


                IWebElement endingColumnCount1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@type='number'])[6]")));
                endingColumnCount1.Clear();
                endingColumnCount1.SendKeys(PlanogramData.slotCounts[0, 3]);
                Thread.Sleep(2000);
                IWebElement saveSlots1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), ' Save ')]")));
                saveSlots1.Click();
                Console.WriteLine("Product Matrix Changed again");
                Thread.Sleep(2000);

                Console.WriteLine("Product Mapping Done. Moving to Product Purchase ");
                AddPurchase purchase = new AddPurchase(driver);
                purchase.AddPurchaseFlow();
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



