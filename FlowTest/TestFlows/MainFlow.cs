using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Machines.MachineList;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.TestFlows   // ✅ SAME NAMESPACE
{
    [TestClass]
    [DoNotParallelize]
    public class TestFlow
    {
        public static IWebDriver driver;
        public static bool previousStepFailed = false;

        private static ExtentReports extent;
        private static ExtentTest test;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
            extent = ExtentManager.GetInstance();
        }

        [TestMethod]
        [Priority(1)]
        public void Step1_Login()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Login Flow");

            try
            {
                new Login(driver).CompanyLoginSuccess();
                test.Pass("Login successful");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [TestMethod]
        [Priority(2)]
        public void Step2_AddBranch()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Branch Flow");

            try
            {
                new AddBranch(driver).AddBranchFlow();
                test.Pass("Branch completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [TestMethod]
        [Priority(3)]
        public void Step3_AddClient()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Client Flow");

            try
            {
                new AddClient(driver).AddClientFlow();
                test.Pass("Client completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [TestMethod]
        [Priority(4)]
        public void Step4_MachineMapping()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Machine Mapping Flow");

            try
            {
                new MachineMapping(driver).ClientMappingWithMachineFlow();
                test.Pass("Machine mapping completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            extent.Flush();
            driver.Quit();
        }
    }

    // ================= BRANCH CLASS (SAME FILE, SAME NAMESPACE) =================

    public class AddBranch
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddBranch(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddBranchFlow()
        {
            Thread.Sleep(2000);

            By companyModuleBy = By.Id("menuItem-Company");
            wait.Until(d => d.FindElement(companyModuleBy).Displayed);
            driver.FindElement(companyModuleBy).Click();

            By branchListBy = By.XPath("//div[contains(text(),'Branch List')]");
            wait.Until(d => d.FindElement(branchListBy).Displayed);
            driver.FindElement(branchListBy).Click();

            Thread.Sleep(2000);

            string searchName = AddBranchData.addBranchSuccess["searchName"];

            By searchBoxBy = By.Name("searchText");
            wait.Until(d => d.FindElement(searchBoxBy).Displayed);
            IWebElement searchText = driver.FindElement(searchBoxBy);
            searchText.Clear();
            searchText.SendKeys(searchName + Keys.Enter);

            Thread.Sleep(3000);

            var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

            if (rows.Count == 0)
            {
                By addBranchBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                wait.Until(d => d.FindElement(addBranchBtnBy).Displayed);
                driver.FindElement(addBranchBtnBy).Click();

                Thread.Sleep(2000);

                driver.FindElement(By.Name("name")).SendKeys(AddBranchData.addBranchSuccess["name"]);
                driver.FindElement(By.Name("location")).SendKeys(AddBranchData.addBranchSuccess["location"]);
                driver.FindElement(By.Name("code")).SendKeys(AddBranchData.addBranchSuccess["code"]);
                driver.FindElement(By.Name("email")).SendKeys(AddBranchData.addBranchSuccess["email"]);
                driver.FindElement(By.Name("contactDetails")).SendKeys(AddBranchData.addBranchSuccess["contactDetails"]);
                driver.FindElement(By.Name("gstNo")).SendKeys(AddBranchData.addBranchSuccess["gstNo"]);
                driver.FindElement(By.Name("address")).SendKeys(AddBranchData.addBranchSuccess["address"]);
                driver.FindElement(By.Name("companyName")).SendKeys(AddBranchData.addBranchSuccess["companyName"]);
                driver.FindElement(By.Name("companyContactNo")).SendKeys(AddBranchData.addBranchSuccess["companyContactNo"]);
                driver.FindElement(By.Name("companyEmail")).SendKeys(AddBranchData.addBranchSuccess["companyEmail"]);
                driver.FindElement(By.Name("companyAddress")).SendKeys(AddBranchData.addBranchSuccess["companyAddress"]);

                Thread.Sleep(3000);

                IWebElement branchLogo = wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                branchLogo.SendKeys(AddBranchData.addBranchSuccess["fileUpload"]);

                driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                Thread.Sleep(4000);
            }
        }
    }

    // ================= CLIENT CLASS (SAME FILE, SAME NAMESPACE) =================

    public class AddClient
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddClient(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddClientFlow()
        {
            By companyModuleBy = By.Id("menuItem-Company");
            wait.Until(d => d.FindElement(companyModuleBy).Displayed);
            driver.FindElement(companyModuleBy).Click();

            By clientMenuBy = By.Id("menuItem-Company1");
            wait.Until(d => d.FindElement(clientMenuBy).Displayed);
            driver.FindElement(clientMenuBy).Click();

            Thread.Sleep(2000);

            for (int i = 0; i < AddClientData.Clients.GetLength(0); i++)
            {
                string searchName = AddClientData.Clients[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                IWebElement searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(2000);

                var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

                if (rows.Count == 0)
                {
                    By addClientBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                    wait.Until(d => d.FindElement(addClientBtnBy).Displayed);
                    driver.FindElement(addClientBtnBy).Click();

                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")))
                        .SendKeys(AddClientData.Clients[i, 1]);

                    driver.FindElement(By.Name("branch")).Click();
                    string branchName = AddClientData.Clients[i, 2];
                    string dynamicXPath = $"//span[text()=' {branchName} ']";
                    driver.FindElement(By.XPath(dynamicXPath)).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactno")))
                        .SendKeys(AddClientData.Clients[i, 3]);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("email")))
                        .SendKeys(AddClientData.Clients[i, 4]);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("address")))
                        .SendKeys(AddClientData.Clients[i, 5]);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("gstNo")))
                        .SendKeys(AddClientData.Clients[i, 6]);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyName")))
                        .SendKeys(AddClientData.Clients[i, 7]);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyContactNo")))
                        .SendKeys(AddClientData.Clients[i, 8]);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyEmail")))
                        .SendKeys(AddClientData.Clients[i, 9]);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyAddress")))
                        .SendKeys(AddClientData.Clients[i, 10]);

                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                    Thread.Sleep(2000);
                }
            }
        }
    }



    // ================= Machine Mapping CLASS (SAME FILE, SAME NAMESPACE) =================

    public class MachineMapping
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public static string unmappedMachineForMapping;

        public MachineMapping(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void ClientMappingWithMachineFlow()
        {
            // wait for overlay to disappear
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                By.XPath("//div[contains(@class,'overlay')]")
            ));

            IWebElement machineMenu = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines"))
            );

            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].scrollIntoView(true);", machineMenu);

            machineMenu.Click();
            Thread.Sleep(1000);

            IWebElement machineList = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
            machineList.Click();
            Thread.Sleep(6000);

            var machineRows = wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(
                    By.CssSelector("table tbody tr")));

            List<IWebElement> unmappedMachines = new List<IWebElement>();

            foreach (var row in machineRows)
            {
                var cells = row.FindElements(By.TagName("td"));
                string clientName = cells[2].Text.Trim();
                if (clientName.Equals("N/A", StringComparison.OrdinalIgnoreCase))
                {
                    unmappedMachines.Add(row);
                }
            }

            if (unmappedMachines.Count > 0)
            {
                var firstUnmappedRow = unmappedMachines.First();
                unmappedMachineForMapping =
                    firstUnmappedRow.FindElements(By.TagName("td"))[0].Text;
            }
            else
            {
                Console.WriteLine("No unmapped machines found.");
                return;
            }

            IWebElement purchaseOrderButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//div[contains(text(),'Purchase Order')]")));
            purchaseOrderButton.Click();
            Thread.Sleep(2000);

            IWebElement currentPurchaseOrderMenu = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//div[contains(text(),'Current Purchase Order')]")));
            currentPurchaseOrderMenu.Click();
            Thread.Sleep(2000);

            IWebElement addClientPurchaseOrderButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button[contains(@class,'add_fab')]")));
            addClientPurchaseOrderButton.Click();

            IWebElement billDate = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("drange2")));
            billDate.Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//td[.//span[text()='2025']]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//td[.//span[text()='Sept']]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//td[.//span[text()='3']]")).Click();
            Thread.Sleep(1000);

            IWebElement client = wait.Until(
                ExpectedConditions.ElementIsVisible(By.Name("client")));
            client.Click();

            string clientName1 =
                AddClientPurchaseOrderData.addClientPurchaseOderSuccess["clientName"];
            string dynamicXPath = $"//span[text()=' {clientName1} ']";
            driver.FindElement(By.XPath(dynamicXPath)).Click();

            IWebElement fileInput = driver.FindElement(
                By.XPath("//input[@type='file']"));

            string projectRoot = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectRoot, "TestData", "PO-PDF.pdf");
            fileInput.SendKeys(filePath);

            IWebElement billDateCalendarIcon = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("drange")));
            billDateCalendarIcon.Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//td[.//span[text()='2035']]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//td[.//span[text()='Sept']]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//td[.//span[text()='2']]")).Click();
            Thread.Sleep(3000);

            IWebElement selectMachineInput = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("machineId")));
            selectMachineInput.Click();
            Thread.Sleep(2000);

            var machineOptions = wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(
                    By.CssSelector("mat-option span")));

            foreach (var option in machineOptions)
            {
                if (option.Text.Trim()
                    .Equals(unmappedMachineForMapping,
                            StringComparison.OrdinalIgnoreCase))
                {
                    option.Click();
                    break;
                }
            }

            IWebElement addBtn = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector("button.mat-icon-button.mat-primary")));
            addBtn.Click();
            Thread.Sleep(2000);

            IWebElement save = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button[.//span[normalize-space(text())='Save']]")));
            save.Click();
            Thread.Sleep(4000);
        }
    }

}
