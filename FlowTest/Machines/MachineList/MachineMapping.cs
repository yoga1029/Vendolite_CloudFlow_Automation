
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Machines.ProductMapping;
using VMS_Phase1PortalAT.FlowTest.Product.Brand;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using WindowsInput;
using WindowsInput.Native;



namespace VMS_Phase1PortalAT.FlowTest.Machines.MachineList
{
    public class MachineMapping
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public static string unmappedMachineForMapping;
        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public MachineMapping(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void ClientMappingWithMachineFlow()
        {

            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Mapping Machine with Client");
            try
            {
                Thread.Sleep(4000);
                IWebElement machineMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
                machineMenu.Click();
                Thread.Sleep(1000);

                //Fetching Machine List
                IWebElement machineList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
                machineList.Click();
                Thread.Sleep(6000);

                // Get all rows 
                var machineRows = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("table tbody tr"))).ToList();
                Console.WriteLine("Total Machines Found: " + machineRows.Count);

                //store unmapped machines
                List<IWebElement> unmappedMachines = new List<IWebElement>();

                foreach (var row in machineRows)
                {
                    var cells = row.FindElements(By.TagName("td"));
                    string clientName = cells[2].Text.Trim();
                    if (string.Equals(clientName, "N/A", StringComparison.OrdinalIgnoreCase))
                    {
                        unmappedMachines.Add(row);
                    }
                }
                Console.WriteLine("Unmapped Machines Count: " + unmappedMachines.Count);
                if (unmappedMachines.Count > 0)
                {
                    var firstUnmappedRow = unmappedMachines.First();
                    string firstUnmappedMachineId = firstUnmappedRow.FindElements(By.TagName("td"))[0].Text;
                    Console.WriteLine("First Unmapped Machine Id: " + firstUnmappedMachineId);

                    // Store for further mapping
                    unmappedMachineForMapping = firstUnmappedMachineId;
                }
                else
                {
                    Console.WriteLine("No unmapped machines found.");
                }
                // Navigate to Purchase Order menu
                IWebElement purchaseOrderButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Purchase Order')]")));
                purchaseOrderButton.Click();
                Thread.Sleep(2000);
                // Navigate to Current Purchase Order submenu
                IWebElement currentPurchaseOrderMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Current Purchase Order')]")));
                currentPurchaseOrderMenu.Click();
                Thread.Sleep(2000);

                // Navigate to Add Client Purchase Order page
                IWebElement addClientPurchaseOrderButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                addClientPurchaseOrderButton.Click();

                // Bill Date
                IWebElement billDate = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("drange2")));
                billDate.Click();
                Thread.Sleep(1000);

                IWebElement yearControl = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='owl-dt-calendar-control']")));
                yearControl.Click();
                Thread.Sleep(1000);

                IWebElement yearToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[.//span[text()='2025']]")));
                yearToSelect.Click();
                Thread.Sleep(1000);

                IWebElement monthToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[.//span[text()='Sept']]")));
                monthToSelect.Click();
                Thread.Sleep(1000);

                IWebElement dayToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[.//span[text()='3']]")));
                dayToSelect.Click();
                Thread.Sleep(1000);

                IWebElement client = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("client")));
                client.Click();
                Thread.Sleep(1000);

                string clientName1 = AddClientPurchaseOrderData.addClientPurchaseOderSuccess["clientName"];
                string dynamicXPath = $"//span[text()=' {clientName1} ']";
                driver.FindElement(By.XPath(dynamicXPath)).Click();

                //IWebElement chooseClientName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = ' YogeswariiS ']")));
                //chooseClientName.Click(); Thread.Sleep(1000);

                // Click the upload button (which opens the Windows dialog)

                IWebElement uploadBtn = driver.FindElement(By.XPath("//mat-icon[text()='cloud_upload']"));
                uploadBtn.Click();
                Thread.Sleep(2000);

                // Simulate typing file path + Enter
                var sim = new InputSimulator();
                sim.Keyboard.TextEntry(@"C:\Users\Yogeswari-PC\Downloads\PO-PDF.pdf");
                sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                Thread.Sleep(2000);

                // Expiry Date
                IWebElement billDateCalendarIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("drange")));
                billDateCalendarIcon.Click();
                Thread.Sleep(1000);

                IWebElement yearControl1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='owl-dt-calendar-control']")));
                yearControl1.Click();
                Thread.Sleep(1000);

                IWebElement yearToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[.//span[text()='2035']]")));
                yearToSelect1.Click();
                Thread.Sleep(1000);

                IWebElement monthToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[.//span[text()='Sept']]")));
                monthToSelect1.Click();
                Thread.Sleep(1000);

                IWebElement dayToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[.//span[text()='2']]")));
                dayToSelect1.Click();
                Thread.Sleep(3000);

                //IWebElement selectMachine = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'machineId']")));
                //selectMachine.Click();
                //Thread.Sleep(2000);

                //IWebElement selectMachineInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("machineId")));
                //selectMachineInput.SendKeys(unmappedMachineForMapping[0] + Keys.Enter);
                //selectMachineInput.Click();
                //Thread.Sleep(5000);


                IWebElement selectMachineInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("machineId")));
                selectMachineInput.Click();
                Thread.Sleep(1000);

                // Get all dropdown machine options
                var machineOptions = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("mat-option span")));

                // Compare stored unmapped machine with each dropdown option
                bool found = false;
                for (int i = 0; i < machineOptions.Count; i++)
                {
                    string optionTexts = machineOptions[i].Text.Trim();
                    if (optionTexts.Equals(unmappedMachineForMapping, StringComparison.OrdinalIgnoreCase))
                    {
                        machineOptions[i].Click();
                        Console.WriteLine("Mapped machine is: " + optionTexts);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Stored unmapped machine not found in dropdown!");
                }


                IWebElement addBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mat-icon-button.mat-primary")));
                addBtn.Click();
                Thread.Sleep(2000);

                //// Click add button
                //IWebElement addBtn = driver.FindElement(By.CssSelector("button.mat-icon-button.mat-primary"));
                //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //    js.ExecuteScript("arguments[0].click();", addBtn);

                IWebElement save = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[.//span[normalize-space(text())='Save']]")));
                save.Click();
                Thread.Sleep(3000);

                AddBrand brand = new AddBrand(driver);
                brand.AddBrandFlow();
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