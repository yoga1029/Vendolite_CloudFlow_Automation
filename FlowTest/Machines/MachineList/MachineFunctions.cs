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
    [TestClass]
    public class MachineFunctions
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public static string productName;
        public static string reqQty;
        public static IList<IWebElement> outofstockProducts;

        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        //public MachineFunctions(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //}

        [TestMethod]
        public void MachineFunctionsFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding Functions to the Machine");
            try
            {
                //Login
                var login = new Login(driver);
                login.CompanyLoginSuccess();

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
                machineFilter.SendKeys(/* MachineMapping.unmappedMachineForMapping */ "STE0000031" + Keys.Enter);
                Thread.Sleep(3000);

                IWebElement actionButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
                actionButton.Click();
                Thread.Sleep(2000);

                //Fetching the details of the machine 
                IWebElement machineDetails = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
                machineDetails.Click();
                Thread.Sleep(3000);



                //SET FUNCTIONS
                //Read expected functions 
                IWebElement functions = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(),' Functions ')]")));
                functions.Click();
                Thread.Sleep(1000);
                List<string> expectedFunctions = new List<string>()
                {
                    FunctionsData.functions[0, 0],
                    FunctionsData.functions[0, 1],
                    FunctionsData.functions[0, 2],
                    FunctionsData.functions[0, 3]
                };

                // Scan existing functions on Machine functions popup
                var existingFunctionElements = driver.FindElements(By.XPath("//div[@class='itemName']/strong"));
                List<string> presentFunctions = existingFunctionElements.Select(e => e.Text.Trim()).ToList();

                Console.WriteLine("Present Functions:");
                presentFunctions.ForEach(Console.WriteLine);

                // Build missing Functions list
                List<string> missingFunctions = expectedFunctions.Where(p => !presentFunctions.Contains(p)).ToList();

                Console.WriteLine("Missing Functions:");
                missingFunctions.ForEach(Console.WriteLine);

                //If Missing Parameters Exixts
                if (missingFunctions.Count != 0)
                {
                    // Click "Add Functions" button 
                    IWebElement addFunctionBtn = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button[.//span[contains(normalize-space(),'Add Function')]]")));
                    addFunctionBtn.Click();
                    Thread.Sleep(2000);

                    // Add missing functions ONE BY ONE
                    foreach (string func in missingFunctions)
                    {
                        Console.WriteLine($"Adding missing function: {func}");

                        // Open dropdown
                        IWebElement dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("machineFunctionToAdd")));
                        dropdown.Click();
                        Thread.Sleep(400);

                        // Select the function from dropdown
                        IWebElement Option = wait.Until(ExpectedConditions.ElementToBeClickable(
                                By.XPath($"//div[contains(@class,'cdk-overlay-pane')]//span[normalize-space()='{func}']")));
                        Option.Click();
                        Thread.Sleep(400);

                        // Click Add +
                        IWebElement addButtonInside = wait.Until(ExpectedConditions.ElementToBeClickable(
                                By.XPath("(//button[.//span[contains(normalize-space(),'Add')] and .//mat-icon[normalize-space()='add']])[2]")));
                        addButtonInside.Click();
                        Thread.Sleep(700);
                    }

                    IWebElement enableButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(),'Enable')]")));
                    enableButton.Click();
                    Thread.Sleep(1000);

                    //IWebElement closePopup = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-icon[text()='clear']")));
                    //closePopup.Click();
                    //Thread.Sleep(1000);
                    Console.WriteLine("All missing functions added & enabled successfully");
                }
                else
                {
                    Console.WriteLine("All functions already exist. Nothing to add.");
                    //IWebElement closeNow = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//mat-icon[text()='clear']")));
                    //closeNow.Click();
                    //Thread.Sleep(800);

                }
                Thread.Sleep(3000);


                // LOOP through all 4 play buttons one by one
                for (int i = 4; i >= 1; i--)
                {
                    Console.WriteLine($"Executing Function #{i}");

                    // Click the i‑th play button
                    IWebElement playBtn = wait.Until(
                        ExpectedConditions.ElementToBeClickable(By.XPath($"(//button[.//mat-icon[normalize-space()='play_arrow']])[{i}]")));
                    playBtn.Click();
                    Thread.Sleep(800);

                    // Toggle all parameters ON (if present)
                    IList<IWebElement> toggleButtons = driver.FindElements(By.XPath("//section[contains(@class,'full_width')]//input"));

                    foreach (IWebElement toggleButton in toggleButtons)
                    {
                        bool isToggleEnabled = toggleButton.Selected;
                        if (!isToggleEnabled)
                        {
                            Console.WriteLine("Toggle OFF → Turning ON...");
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            js.ExecuteScript("arguments[0].click();", toggleButton);
                            Thread.Sleep(500);
                        }
                    }

                    // ---- CHECK FOR CHECKBOX ----
                    var checkboxes = driver.FindElements(By.XPath("//label[contains(@class,'mat-checkbox-layout')]//input[@type='checkbox']"));

                    if (checkboxes.Count > 0)
                    {
                        Console.WriteLine("Checkbox found. Enabling it...");

                        IWebElement checkbox = checkboxes[0];

                        bool isChecked = checkbox.Selected;

                        if (!isChecked)
                        {
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            js.ExecuteScript("arguments[0].click();", checkbox);
                            Thread.Sleep(500);
                            Console.WriteLine("Checkbox enabled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No checkbox found. Skipping checkbox step.");
                    }


                    // Click Execute
                    try
                    {
                        IWebElement execute = wait.Until(
                            ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(), 'Execute')]")));
                        execute.Click();
                        Console.WriteLine("Execute clicked.");
                        Thread.Sleep(2000);
                    }
                    catch
                    {
                        Console.WriteLine("No Execute button (maybe auto‑executed). Skipping...");
                    }

                    Thread.Sleep(800);

                    //// Close popup (clear icon)
                    //try
                    //{
                    //    IWebElement closePopup = wait.Until(
                    //        ExpectedConditions.ElementToBeClickable(By.XPath("//mat-icon[text()='clear']")));
                    //    closePopup.Click();
                    //    Thread.Sleep(700);
                    //    Console.WriteLine("Popup closed.");
                    //}
                    //catch
                    //{
                    //    Console.WriteLine("Popup was not shown or already closed.");
                    //}
                }


            }
            catch (Exception ex)
            {
                test.Fail(ex);
            }
            extent.Flush();

        }
    }
}
