
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V126.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Machines.MachineList;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Company.Client
{
    public class AddClient
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;
        public AddClient(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddClientFlow()
        {

            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Entering in to Client");
            try
            {
                // Locate Company Module
                IWebElement companyModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Company")));
                companyModule.Click();

                // Fetching Client sub-menu
                IWebElement clientButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Company1")));
                clientButton.Click();
                Thread.Sleep(2000);

                for (int i = 0; i < AddClientData.Clients.GetLength(0); i++)
                {
                    string searchName = AddClientData.Clients[i, 0];
                    IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    searchText.Clear();
                    searchText.SendKeys(searchName + Keys.Enter);
                    Thread.Sleep(2000);
                    var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

                    // Check if client exists
                    if (rows.Count == 0)
                    {
                        Console.WriteLine($"Client '{searchName}' not found. Adding Client");

                        // Navigate to add client page
                        IWebElement addClientButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                        addClientButton.Click();
                        Thread.Sleep(2000);

                        // Fill the input fields using 2D array
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name"))).SendKeys(AddClientData.Clients[i, 1]);

                        driver.FindElement(By.Name("branch")).Click();
                        string branchName = AddClientData.Clients[i, 2];
                        string dynamicXPath = $"//span[text()=' {branchName} ']";
                        driver.FindElement(By.XPath(dynamicXPath)).Click();
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactno"))).SendKeys(AddClientData.Clients[i, 3]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("email"))).SendKeys(AddClientData.Clients[i, 4]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("address"))).SendKeys(AddClientData.Clients[i, 5]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("gstNo"))).SendKeys(AddClientData.Clients[i, 6]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyName"))).SendKeys(AddClientData.Clients[i, 7]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyContactNo"))).SendKeys(AddClientData.Clients[i, 8]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyEmail"))).SendKeys(AddClientData.Clients[i, 9]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyAddress"))).SendKeys(AddClientData.Clients[i, 10]);
                        Thread.Sleep(2000);

                        // Save client
                        driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                        Thread.Sleep(2000);
                    }
                }

                MachineMapping machineMapping = new MachineMapping(driver);
                machineMapping.ClientMappingWithMachineFlow();
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
//// Associated Machines
//IWebElement actionButton1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Click here')]")));
//actionButton1.Click();
//Thread.Sleep(1000);

//IWebElement assosiatedMachines = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (text(), 'Associated Machines')]")));
//assosiatedMachines.Click();
//Thread.Sleep(2000);
//driver.Navigate().Back();

//// Associated PO
//IWebElement actionButton2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Click here')]")));
//actionButton2.Click();
//Thread.Sleep(1000);

//IWebElement assosiatedPO = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (text(), ' Associated PO')]")));
//assosiatedPO.Click();
//Thread.Sleep(5000);
//driver.Navigate().Back();

//// Edit Client Details
//IWebElement actionButton3 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Click here')]")));
//actionButton3.Click();
//Thread.Sleep(2000);

//IWebElement editButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (text(), 'Edit')]")));
//editButton.Click();
//Thread.Sleep(2000);

//driver.FindElement(By.Name("name")).SendKeys("swari");
//Thread.Sleep(1000);

//driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
//Thread.Sleep(2000);

//// Delete Client
//IWebElement actionButton4 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Click here')]")));
//actionButton4.Click();
//Thread.Sleep(2000);

//IWebElement deleteButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (text(), 'Delete')]")));
//deleteButton.Click();
//Thread.Sleep(2000);

//IWebElement confirmDelete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(), 'Confirm')]")));
//confirmDelete.Click();
//Thread.Sleep(2000);
