using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Machines.MachineList;
using VMS_Phase1PortalAT.FlowTest.Machines.ProductMapping;
using VMS_Phase1PortalAT.FlowTest.Product.Brand;
using VMS_Phase1PortalAT.FlowTest.Product.Categories;
using VMS_Phase1PortalAT.FlowTest.Product.ProductList;
using VMS_Phase1PortalAT.FlowTest.Product.Subcategories;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using VMS_Phase1PortalAT.FlowTest.Warehouse.Vendor;
using VMS_Phase1PortalAT.FlowTest.Warehouse.WarehouseList;
using WindowsInput;
using WindowsInput.Native;

namespace VMS_Phase1PortalAT.FlowTest.TestFlows   //same namespace
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


        [TestMethod]
        [Priority(5)]
        public void Step5_AddBrand()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Brand Flow");

            try
            {
                new AddBrand(driver).AddBrandFlow();
                test.Pass("Brand completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [TestMethod]
        [Priority(6)]
        public void Step6_AddCategory()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Category Flow");

            try
            {
                new AddCategory(driver).AddCategoryFlow();
                test.Pass("Category completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }



        [TestMethod]
        [Priority(7)]
        public void Step7_AddSubCategory()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add SubCategory Flow");

            try
            {
                new AddSubCategory(driver).AddSubCategoryFlow();
                test.Pass("SubCategory completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }


        [TestMethod]
        [Priority(8)]
        public void Step8_AddProduct()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Product Flow");

            try
            {
                new AddProduct(driver).AddProductFlow();
                test.Pass("Product completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [TestMethod]
        [Priority(9)]
        public void Step9_AddWarehouse()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Warehouse Flow");

            try
            {
                new AddWarehouse(driver).AddWarehouseFlow();
                test.Pass("Warehouse completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [TestMethod]
        [Priority(10)]
        public void Step10_AddVendor()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Vendor Flow");

            try
            {
                new AddVendor(driver).AddVendorFlow();
                test.Pass("Vendor completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }


        [TestMethod]
        [Priority(11)]
        public void Step11_ProductMapping()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Product Mapping Flow");

            try
            {
                new Productmapping(driver).ProductMappingFlow();
                test.Pass("Product Mapping completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }

        [TestMethod]
        [Priority(12)]
        public void Step12_AddPurchase()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Add Purchase Flow");

            try
            {
                new AddPurchase(driver).AddPurchaseFlow();
                test.Pass("Purchase completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }



        [TestMethod]
        [Priority(13)]
        public void Step13_RaiseRefillRequest()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Raise Refill Request Flow");

            try
            {
                new RaiseRefillRequest(driver).RaiseRefillRequestFlow();
                test.Pass("Refill Request completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }


        [TestMethod]
        [Priority(14)]
        public void Step14_ReturnRequest()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Return Request Flow");

            try
            {
                new ReturnRequest(driver).ReturnRequestFlow();
                test.Pass("Return Request completed");
            }
            catch (Exception ex)
            {
                test.Fail(ex);
                previousStepFailed = true;
                throw;
            }
        }


        [TestMethod]
        [Priority(15)]
        public void Step15_MachineScrapping()
        {
            if (previousStepFailed)
                Assert.Inconclusive("Previous step failed");

            test = extent.CreateTest("Machine Scrapping Flow");

            try
            {
                new MachineScrapping(driver).MachineScrappingFlow();
                test.Pass("Machine scrapping completed");
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

    // ================= BRANCH CLASS =================

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

    // ================= CLIENT CLASS =================

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



    // ================= Machine Mapping CLASS =================

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

            IWebElement yearControl = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='owl-dt-calendar-control']")));
            yearControl.Click();
            Thread.Sleep(1000);

            IWebElement yearToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{machinePOData.machineMapping[0, 0]}']]")));
            yearToSelect.Click();
            Thread.Sleep(1000);

            IWebElement monthToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{machinePOData.machineMapping[0, 1]}']]")));
            monthToSelect.Click();
            Thread.Sleep(1000);

            IWebElement dayToSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{machinePOData.machineMapping[0, 2]}']]")));
            dayToSelect.Click();
            Thread.Sleep(1000);


            //driver.FindElement(By.XPath("//td[.//span[text()='2025']]")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//td[.//span[text()='Sept']]")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//td[.//span[text()='3']]")).Click();
            //Thread.Sleep(1000);

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

            IWebElement yearControl1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='owl-dt-calendar-control']")));
            yearControl1.Click();
            Thread.Sleep(1000);

            IWebElement yearToSelect2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{machinePOData.machineMapping[0, 3]}']]")));
            yearToSelect2.Click();
            Thread.Sleep(1000);

            IWebElement monthToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{machinePOData.machineMapping[0, 4]}']]")));
            monthToSelect1.Click();
            Thread.Sleep(1000);

            IWebElement dayToSelect1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[.//span[text()='{machinePOData.machineMapping[0, 5]}']]")));
            dayToSelect1.Click();
            Thread.Sleep(1000);


            //driver.FindElement(By.XPath("//td[.//span[text()='2035']]")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//td[.//span[text()='Sept']]")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//td[.//span[text()='2']]")).Click();
            //Thread.Sleep(3000);

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





    public class AddBrand
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddBrand(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddBrandFlow()
        {
            // wait for overlay to disappear first
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
                By.XPath("//div[contains(@class,'overlay')]")
            ));

            // Locate Product Module
            By productModuleBy = By.XPath("//div[contains(text(),'Products')]");
            wait.Until(d => d.FindElement(productModuleBy).Displayed);
            IWebElement productModule = driver.FindElement(productModuleBy);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", productModule);

            productModule.Click();

            // Locate Brand sub-module
            By brandListBy = By.XPath("//div[contains(text(),' Brand ')]");
            wait.Until(d => d.FindElement(brandListBy).Displayed);
            driver.FindElement(brandListBy).Click();

            Thread.Sleep(7000);

            for (int i = 0; i < AddBrandData.Brands.GetLength(0); i++)
            {
                string searchName = AddBrandData.Brands[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                IWebElement searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(3000);

                var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

                if (rows.Count == 0)
                {
                    Console.WriteLine($"Brand '{searchName}' not found. Adding brand");

                    By addBrandBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                    wait.Until(d => d.FindElement(addBrandBtnBy).Displayed);
                    driver.FindElement(addBrandBtnBy).Click();

                    Thread.Sleep(2000);

                    IWebElement brandName =
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
                    brandName.SendKeys(AddBrandData.Brands[i, 1]);

                    driver.FindElement(By.Name("branch")).Click();
                    string branchName = AddBrandData.Brands[i, 2];
                    string dynamicXPath = $"//span[text()=' {branchName} ']";
                    driver.FindElement(By.XPath(dynamicXPath)).Click();

                    // Upload Brand Image
                    IWebElement imageUploadBtn =
                        wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                    imageUploadBtn.SendKeys(AddBrandData.Brands[i, 3]);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                          .Click();

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"Brand '{searchName}' already exists.");
                }
            }
        }
    }




    public class AddCategory
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddCategory(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddCategoryFlow()
        {
            Thread.Sleep(1000);

            // Locate Product Module
            By productModuleBy = By.XPath("//div[contains(text(),'Products')]");
            wait.Until(d => d.FindElement(productModuleBy).Displayed);
            driver.FindElement(productModuleBy).Click();

            // Locate Category sub-module
            By categorySubModuleBy = By.XPath("//div[contains(text(),' Categories ')]");
            wait.Until(d => d.FindElement(categorySubModuleBy).Displayed);
            driver.FindElement(categorySubModuleBy).Click();

            Thread.Sleep(7000);

            for (int i = 0; i < AddCategoryData.Categories.GetLength(0); i++)
            {
                string searchName = AddCategoryData.Categories[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                IWebElement searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(4000);

                var rows = driver.FindElements(By.XPath("//table//tbody/tr"));
                Thread.Sleep(1000);

                if (rows.Count == 0)
                {
                    Console.WriteLine($"Category '{searchName}' not found. Adding category");

                    By addCategoryBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                    wait.Until(d => d.FindElement(addCategoryBtnBy).Displayed);
                    driver.FindElement(addCategoryBtnBy).Click();

                    Thread.Sleep(2000);

                    IWebElement categoryName =
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
                    categoryName.SendKeys(AddCategoryData.Categories[i, 1]);

                    driver.FindElement(By.Name("branch")).Click();
                    string branchName = AddCategoryData.Categories[i, 2];
                    string dynamicBranchXPath = $"//span[text()=' {branchName} ']";
                    driver.FindElement(By.XPath(dynamicBranchXPath)).Click();

                    driver.FindElement(By.Name("brand")).Click();
                    string brandName = AddCategoryData.Categories[i, 3];
                    string dynamicBrandXPath = $"//span[text()=' {brandName} ']";
                    driver.FindElement(By.XPath(dynamicBrandXPath)).Click();

                    // Upload Category Image
                    IWebElement imageUploadBtn =
                        wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                    imageUploadBtn.SendKeys(AddCategoryData.Categories[i, 4]);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                          .Click();

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"Category '{searchName}' already exists.");
                }
            }
        }
    }




    public class AddSubCategory
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddSubCategory(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddSubCategoryFlow()
        {
            Thread.Sleep(1000);

            // Locate Product Module
            By productModuleBy = By.XPath("//div[contains(text(),'Products')]");
            wait.Until(d => d.FindElement(productModuleBy).Displayed);
            driver.FindElement(productModuleBy).Click();

            // Locate SubCategory sub-module
            By subCategoryBy = By.XPath("//div[contains(text(),' Sub Categories ')]");
            wait.Until(d => d.FindElement(subCategoryBy).Displayed);
            driver.FindElement(subCategoryBy).Click();

            Thread.Sleep(5000);

            for (int i = 0; i < AddSubCategoryData.SubCategory.GetLength(0); i++)
            {
                string searchName = AddSubCategoryData.SubCategory[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                IWebElement searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(7000);

                var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

                if (rows.Count == 0)
                {
                    Console.WriteLine($"Subcategory '{searchName}' not found. Adding Subcategory");

                    By addSubCategoryBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                    wait.Until(d => d.FindElement(addSubCategoryBtnBy).Displayed);
                    driver.FindElement(addSubCategoryBtnBy).Click();

                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")))
                        .SendKeys(AddSubCategoryData.SubCategory[i, 1]);

                    driver.FindElement(By.Name("branch")).Click();
                    string branchName = AddSubCategoryData.SubCategory[i, 2];
                    string dynamicBranchXPath = $"//span[text()=' {branchName} ']";
                    driver.FindElement(By.XPath(dynamicBranchXPath)).Click();

                    driver.FindElement(By.Name("brand")).Click();
                    string brandName = AddSubCategoryData.SubCategory[i, 3];
                    string dynamicBrandXPath = $"//span[text()=' {brandName} ']";
                    driver.FindElement(By.XPath(dynamicBrandXPath)).Click();

                    driver.FindElement(By.Name("category")).Click();
                    string categoryName = AddSubCategoryData.SubCategory[i, 4];
                    string dynamicCategoryXPath = $"//span[text()=' {categoryName} ']";
                    driver.FindElement(By.XPath(dynamicCategoryXPath)).Click();

                    // Upload SubCategory Image
                    IWebElement imageUploadBtn =
                        wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                    imageUploadBtn.SendKeys(AddSubCategoryData.SubCategory[i, 5]);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                          .Click();

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"Subcategory '{searchName}' already exists.");
                }
            }
        }
    }


    public class AddProduct
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddProduct(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddProductFlow()
        {
            Thread.Sleep(1000);

            // Locate Product Module
            By productModuleBy = By.XPath("//div[contains(text(),'Products')]");
            wait.Until(d => d.FindElement(productModuleBy).Displayed);
            driver.FindElement(productModuleBy).Click();

            // Locate ProductList sub-module
            By productListBy = By.XPath("//div[contains(text(),' Product List ')]");
            wait.Until(d => d.FindElement(productListBy).Displayed);
            driver.FindElement(productListBy).Click();

            Thread.Sleep(5000);

            for (int i = 0; i < AddProductData.Products.GetLength(0); i++)
            {
                IWebElement branchFilter =
                    wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath("//input[@name = 'branch']")));
                branchFilter.Click();
                Thread.Sleep(2000);

                IWebElement selectBranch =
                    wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath("//span[contains (text(), ' Pudukkottai Branch ')]")));
                selectBranch.Click();
                Thread.Sleep(2000);

                string searchName = AddProductData.Products[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                IWebElement searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(3000);

                var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

                if (rows.Count == 0)
                {
                    Console.WriteLine($"Product '{searchName}' not found. Adding Product");

                    By addProductBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                    wait.Until(d => d.FindElement(addProductBtnBy).Displayed);
                    driver.FindElement(addProductBtnBy).Click();

                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")))
                        .SendKeys(AddProductData.Products[i, 1]);

                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.ElementIsVisible(
                        By.XPath("(//input[@placeholder = 'Branch'])[2]"))).Click();
                    string branchName = AddProductData.Products[i, 2];
                    driver.FindElement(By.XPath($"//span[text()=' {branchName} ']")).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("brand"))).Click();
                    string brandName = AddProductData.Products[i, 3];
                    driver.FindElement(By.XPath($"//span[text()=' {brandName} ']")).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("category"))).Click();
                    string categoryName = AddProductData.Products[i, 4];
                    driver.FindElement(By.XPath($"//span[text()=' {categoryName} ']")).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("subcategory"))).Click();
                    string subcategoryName = AddProductData.Products[i, 5];
                    driver.FindElement(By.XPath($"//span[text()=' {subcategoryName} ']")).Click();

                    IWebElement productId =
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("customProductId")));
                    productId.SendKeys(AddProductData.Products[i, 6]);
                    Thread.Sleep(2000);

                    IWebElement hsnCode =
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("hsnCode")));
                    hsnCode.SendKeys(AddProductData.Products[i, 7]);
                    Thread.Sleep(2000);

                    bool sp = true;
                    if (AddProductData.Products[i, 10] == "1")
                    {
                        IWebElement addGstCheckbox =
                            wait.Until(ExpectedConditions.ElementExists(
                                By.XPath("//input[@name='addGST']")));
                        ((IJavaScriptExecutor)driver)
                            .ExecuteScript("arguments[0].click();", addGstCheckbox);

                        Thread.Sleep(1000);
                        sp = false;

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("mrp")))
                            .SendKeys(AddProductData.Products[i, 11]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("cgst")))
                            .SendKeys(AddProductData.Products[i, 12]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("sgst")))
                            .SendKeys(AddProductData.Products[i, 13]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("utgst")))
                            .SendKeys(AddProductData.Products[i, 14]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("cess")))
                            .SendKeys(AddProductData.Products[i, 15]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("sCost")))
                            .SendKeys(AddProductData.Products[i, 16]);
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("utCost")))
                            .SendKeys(AddProductData.Products[i, 17]);
                    }

                    if (sp)
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("cost")))
                            .SendKeys(AddProductData.Products[i, 8]);
                    }

                    IWebElement imageUploadBtn =
                        wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                    imageUploadBtn.SendKeys(AddProductData.Products[i, 9]);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                          .Click();
                    Thread.Sleep(3000);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Cancel')]"))
                          .Click();
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"Product '{searchName}' already exists.");
                }
            }
        }
    }

    public class AddWarehouse
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddWarehouse(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddWarehouseFlow()
        {
            // Locate Warehouse Module
            By warehouseModuleBy = By.Id("menuItem-Warehouse");
            wait.Until(d => d.FindElement(warehouseModuleBy).Displayed);
            driver.FindElement(warehouseModuleBy).Click();

            // Fetch Warehouse List sub-menu
            By warehouseListBy = By.Id("menuItem-Warehouse0");
            wait.Until(d => d.FindElement(warehouseListBy).Displayed);
            driver.FindElement(warehouseListBy).Click();

            Thread.Sleep(2000);

            for (int i = 0; i < AddWarehouseData.Warehouses.GetLength(0); i++)
            {
                By searchTypeBtnBy = By.XPath("(//mat-select[@role = 'listbox'])[2]");
                wait.Until(d => d.FindElement(searchTypeBtnBy).Displayed);
                driver.FindElement(searchTypeBtnBy).Click();
                Thread.Sleep(2000);

                By selectNameBy = By.XPath("//span[contains (text(), ' Name ')]");
                wait.Until(d => d.FindElement(selectNameBy).Displayed);
                driver.FindElement(selectNameBy).Click();
                Thread.Sleep(2000);

                string searchName = AddWarehouseData.Warehouses[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                IWebElement searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(2000);

                var rowData = driver.FindElements(By.XPath("//table//tbody/tr"));

                if (rowData.Count == 0)
                {
                    Console.WriteLine($"Warehouse '{searchName}' not found. Adding Warehouse");

                    By addWarehouseBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                    wait.Until(d => d.FindElement(addWarehouseBtnBy).Displayed);
                    driver.FindElement(addWarehouseBtnBy).Click();

                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")))
                        .SendKeys(AddWarehouseData.Warehouses[i, 1]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("lat")))
                        .SendKeys(AddWarehouseData.Warehouses[i, 2]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("lon")))
                        .SendKeys(AddWarehouseData.Warehouses[i, 3]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("city")))
                        .SendKeys(AddWarehouseData.Warehouses[i, 4]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("state")))
                        .SendKeys(AddWarehouseData.Warehouses[i, 5]);

                    driver.FindElement(By.Name("branch")).Click();
                    string branchName = AddWarehouseData.Warehouses[i, 6];
                    string dynamicXPath = $"//span[text()=' {branchName} ']";
                    driver.FindElement(By.XPath(dynamicXPath)).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("phoneNo")))
                        .SendKeys(AddWarehouseData.Warehouses[i, 7]);

                    Thread.Sleep(1000);

                    // Upload / publish file
                    wait.Until(ExpectedConditions.ElementIsVisible(
                        By.XPath("//span [contains(text(),'publish' )]"))).Click();

                    Thread.Sleep(1000);
                    var sim = new InputSimulator();
                    sim.Keyboard.TextEntry(AddWarehouseData.Warehouses[i, 8]);
                    sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                    Thread.Sleep(1000);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                          .Click();

                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine($"Warehouse '{searchName}' already exists.");
                }
            }
        }
    }

    public class AddVendor
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddVendor(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddVendorFlow()
        {
            // Locate Warehouse Module
            By warehouseModuleBy = By.Id("menuItem-Warehouse");
            wait.Until(d => d.FindElement(warehouseModuleBy).Displayed);
            driver.FindElement(warehouseModuleBy).Click();

            // Fetch Vendor List sub-menu
            By vendorListBy = By.Id("menuItem-Warehouse1");
            wait.Until(d => d.FindElement(vendorListBy).Displayed);
            driver.FindElement(vendorListBy).Click();

            Thread.Sleep(2000);

            for (int i = 0; i < AddWarehouseData.Vendors.GetLength(0); i++)
            {
                By searchTypeBtnBy = By.XPath("(//mat-select[@role = 'listbox'])[2]");
                wait.Until(d => d.FindElement(searchTypeBtnBy).Displayed);
                driver.FindElement(searchTypeBtnBy).Click();
                Thread.Sleep(2000);

                By selectNameBy = By.XPath("//span[contains (text(), ' Name ')]");
                wait.Until(d => d.FindElement(selectNameBy).Displayed);
                driver.FindElement(selectNameBy).Click();
                Thread.Sleep(2000);

                string searchName = AddWarehouseData.Vendors[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                IWebElement searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(2000);

                var rowData = driver.FindElements(By.XPath("//table//tbody/tr"));

                if (rowData.Count == 0)
                {
                    Console.WriteLine($"Vendor '{searchName}' not found. Adding Vendor");

                    By addVendorBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                    wait.Until(d => d.FindElement(addVendorBtnBy).Displayed);
                    driver.FindElement(addVendorBtnBy).Click();

                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")))
                        .SendKeys(AddWarehouseData.Vendors[i, 1]);

                    driver.FindElement(By.Name("branch")).Click();
                    string branchName = AddWarehouseData.Vendors[i, 2];
                    string dynamicXPath = $"//span[text()=' {branchName} ']";
                    driver.FindElement(By.XPath(dynamicXPath)).Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("email")))
                        .SendKeys(AddWarehouseData.Vendors[i, 3]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("mobile")))
                        .SendKeys(AddWarehouseData.Vendors[i, 4]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactPersonName")))
                        .SendKeys(AddWarehouseData.Vendors[i, 5]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactPersonEmail")))
                        .SendKeys(AddWarehouseData.Vendors[i, 6]);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactPersonMobile")))
                        .SendKeys(AddWarehouseData.Vendors[i, 7]);

                    Thread.Sleep(1000);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                          .Click();

                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine($"Vendor '{searchName}' already exists.");
                }
            }
        }
    }



    public class Productmapping
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Productmapping(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void ProductMappingFlow()
        {
            // Fetching Machine menu
            By machineMenuBy = By.Id("menuItem-Machines");
            wait.Until(d => d.FindElement(machineMenuBy).Displayed);
            driver.FindElement(machineMenuBy).Click();

            // Fetching Machine List
            By machineListBy = By.Id("menuItem-Machines0");
            wait.Until(d => d.FindElement(machineListBy).Displayed);
            driver.FindElement(machineListBy).Click();
            Thread.Sleep(1000);

            string machineId = MachineMapping.unmappedMachineForMapping;
            Console.WriteLine("Selecting machine: " + machineId);

            By searchBoxBy = By.Name("searchText");
            wait.Until(d => d.FindElement(searchBoxBy).Displayed);
            IWebElement searchText = driver.FindElement(searchBoxBy);
            searchText.Clear();
            searchText.SendKeys(machineId + Keys.Enter);
            Thread.Sleep(3000);

            // Action Button
            IWebElement actionButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
            actionButton.Click();
            Thread.Sleep(1000);

            // Machine details
            IWebElement machineDetails = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
            machineDetails.Click();
            Thread.Sleep(3000);

            // Edit Slot
            IWebElement editSlot = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[@mattooltip='Edit Slot']")));
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

            //IWebElement saveSlots = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), ' Save ')]")));
            //saveSlots.Click();
            //Thread.Sleep(3000);

            //IWebElement editInfo = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@mattooltip='Edit Info']")));
            //editInfo.Click();
            //Thread.Sleep(2000);

            IWebElement saveSlots = wait.Until(ExpectedConditions.ElementToBeClickable(
    By.XPath("//span[contains(text(), ' Save ')]")));
            saveSlots.Click();

            //// wait for slot save dialog/overlay to disappear
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(
            //    By.XPath("//mat-dialog-container | //div[contains(@class,'cdk-overlay-backdrop')]")
            //));

            //// ===== PASTE DEBUG CODE HERE =====
            //Console.WriteLine("DEBUG: URL = " + driver.Url);

            //var editInfoCount = driver.FindElements(By.XPath("//button[@mattooltip='Edit Info']")).Count;
            //Console.WriteLine("DEBUG: Edit Info button count = " + editInfoCount);

            //var pageText = driver.PageSource.Contains("Edit Info");
            //Console.WriteLine("DEBUG: PageSource contains 'Edit Info' = " + pageText);
            //// ===== END DEBUG CODE =====

            //// now try to locate Edit Info
            //By editInfoBtn = By.XPath("//button[@mattooltip='Edit Info']");

            //IWebElement editInfo = wait.Until(driver =>
            //{
            //    try
            //    {
            //        var el = driver.FindElement(editInfoBtn);
            //        return el.Displayed ? el : null;
            //    }
            //    catch (NoSuchElementException)
            //    {
            //        return null;
            //    }
            //});

            //((IJavaScriptExecutor)driver)
            //    .ExecuteScript("arguments[0].click();", editInfo);




            // wait until overlay/backdrop is fully gone
            wait.Until(driver =>
                driver.FindElements(By.CssSelector("mat-dialog-container, .cdk-overlay-backdrop")).Count == 0
            );

            // locator
            By editInfoBtn = By.XPath("//button[@mattooltip='Edit Info']");

            // wait until button is present AND enabled (not disabled)
            IWebElement editInfo = wait.Until(driver =>
            {
                try
                {
                    var el = driver.FindElement(editInfoBtn);

                    // check enabled via attribute (Angular sometimes keeps disabled attr)
                    bool isDisabled = el.GetAttribute("disabled") != null;

                    return (!isDisabled && el.Displayed) ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

            Console.WriteLine("EditInfo disabled attr = " + editInfo.GetAttribute("disabled"));
            // scroll into view
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView({block:'center'});", editInfo);

            // wait a bit for Angular animation
            Thread.Sleep(500);

            // force JS click
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", editInfo);





            IWebElement clientLocation = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("clientLocation")));
            clientLocation.Clear();
            clientLocation.SendKeys(machineInfoData.machineDetails[0, 0]);

            IWebElement routeIdentifier = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("routeIdentifier")));
            routeIdentifier.Clear();
            routeIdentifier.SendKeys(machineInfoData.machineDetails[0, 1]);

            IWebElement saveButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Save')]")));
            saveButton.Click();
            Thread.Sleep(2000);

            Console.WriteLine("Product Mapping in to slots...");
            Actions a = new Actions(driver);

            for (int i = 0; i < ProductMappingData.products.GetLength(0); i++)
            {
                IWebElement product = wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath($"(//mat-card)[{ProductMappingData.products[i, 0]}]")));

                a.MoveToElement(product).Pause(TimeSpan.FromSeconds(2)).Perform();

                IWebElement editSlot2 = wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath($"(//mat-card)[{ProductMappingData.products[i, 0]}]//button//mat-icon")));
                editSlot2.Click();
                Thread.Sleep(2000);

                IList<IWebElement> toggleButtons = driver.FindElements(By.XPath("//section[@class='full_width']//input"));
                foreach (IWebElement toggleButton in toggleButtons)
                {
                    if (!toggleButton.Selected)
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", toggleButton);
                        Thread.Sleep(1000);
                    }
                }

                IWebElement selectProduct = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("product")));
                selectProduct.Click();

                IWebElement choosingProduct = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath($"//div[@role='listbox']//div[contains(text(), ' {ProductMappingData.products[i, 1]} ')]")));
                choosingProduct.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("purchaseLimitPerUser")))
                    .SendKeys(ProductMappingData.products[i, 2]);

                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("purchaseLimitPerTransaction")))
                    .SendKeys(ProductMappingData.products[i, 3]);

                IWebElement reset = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("purchaseLimitResetPerUser")));
                reset.Click();
                driver.FindElement(By.XPath($"//span[contains(text(), ' {ProductMappingData.products[i, 4]} ')]")).Click();

                IWebElement stockLimitInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("stockLimit")));
                stockLimitInput.Click();
                driver.FindElement(By.XPath($"//span[contains(text(), ' {ProductMappingData.products[i, 5]} ')]")).Click();

                IWebElement save = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), ' Save ')]")));
                save.Click();
            }
        }
    }


    public class AddPurchase
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddPurchase(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddPurchaseFlow()
        {
            // Locate Warehouse Transactions Module
            By warehouseTransactionsBy = By.XPath("//div[normalize-space(text())='W. Transactions']");
            wait.Until(d => d.FindElement(warehouseTransactionsBy).Displayed);
            driver.FindElement(warehouseTransactionsBy).Click();
            Thread.Sleep(2000);

            // Go to Purchase module
            By purchaseMenuBy = By.Id("menuItem-W. Transactions0");
            wait.Until(d => d.FindElement(purchaseMenuBy).Displayed);
            driver.FindElement(purchaseMenuBy).Click();
            Thread.Sleep(2000);

            IWebElement addWarehousePurchase =
                wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button[contains (@mattooltip, 'Add Warehouse Purchase')]")));
            addWarehousePurchase.Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Name("warehouse")).Click();
            string warehouseName = AddPurchaseData.Purchases[0, 0];
            driver.FindElement(By.XPath($"//span[text()=' {warehouseName} ']")).Click();

            for (int i = 0; i < AddPurchaseData.Purchases.GetLength(0); i++)
            {
                driver.FindElement(By.Name("vendor")).Click();
                string vendorName = AddPurchaseData.Purchases[i, 1];
                driver.FindElement(By.XPath($"//span[text()=' {vendorName} ']")).Click();

                driver.FindElement(By.Name("productId")).Click();
                string productName = AddPurchaseData.Purchases[i, 2];
                driver.FindElement(By.XPath($"//span[contains(text(), ' {productName} ')]")).Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("qty")))
                    .SendKeys(AddPurchaseData.Purchases[i, 3]);

                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("batchId")))
                    .SendKeys(AddPurchaseData.Purchases[i, 4]);

                // Expiry Date
                IWebElement expiryCalendarIcon =
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("drange")));
                expiryCalendarIcon.Click();
                Thread.Sleep(1000);

                IWebElement yearControl =
                    wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath("//div[@class='owl-dt-calendar-control']")));
                yearControl.Click();

                driver.FindElement(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 6]}']]")).Click();
                driver.FindElement(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 7]}']]")).Click();
                driver.FindElement(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 8]}']]")).Click();

                // Bill Date
                IWebElement billDateCalendarIcon =
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("drange2")));
                billDateCalendarIcon.Click();
                Thread.Sleep(1000);

                IWebElement yearControl1 =
                    wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath("//div[@class='owl-dt-calendar-control']")));
                yearControl1.Click();

                driver.FindElement(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 9]}']]")).Click();
                driver.FindElement(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 10]}']]")).Click();
                driver.FindElement(By.XPath($"//td[.//span[text()='{AddPurchaseData.Purchases[i, 11]}']]")).Click();

                IWebElement addButton =
                    wait.Until(ExpectedConditions.ElementToBeClickable(
                        By.XPath("//button//span[text()= ' Add ']")));
                addButton.Click();
                Thread.Sleep(2000);
            }

            IWebElement saveButton1 =
                wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button//span[text()= ' Save ']")));
            saveButton1.Click();
            Thread.Sleep(2000);
        }
    }



    public class RaiseRefillRequest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public RaiseRefillRequest(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void RaiseRefillRequestFlow()
        {
            // Fetching Machine List
            By machineMenuBy = By.Id("menuItem-Machines");
            wait.Until(d => d.FindElement(machineMenuBy).Displayed);
            driver.FindElement(machineMenuBy).Click();
            Thread.Sleep(1000);

            By machineListBy = By.Id("menuItem-Machines0");
            wait.Until(d => d.FindElement(machineListBy).Displayed);
            driver.FindElement(machineListBy).Click();
            Thread.Sleep(2000);

            IWebElement machineFilter = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
            machineFilter.Clear();
            machineFilter.SendKeys(MachineMapping.unmappedMachineForMapping + Keys.Enter);
            Thread.Sleep(3000);

            // Action Button
            IWebElement actionBtn = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
            actionBtn.Click();
            Thread.Sleep(1000);

            IWebElement machineDetails = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
            machineDetails.Click();
            Thread.Sleep(3000);

            // Set Operation Status = Down Planned
            IWebElement selectStatus = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Operation Status')]/following::a[1]")));
            selectStatus.Click();
            Thread.Sleep(1000);

            IWebElement statusDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("status")));
            statusDropdown.Click();

            IWebElement downPlannedOption = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//mat-option//span[contains(normalize-space(),'Down (Planned)')]")));
            downPlannedOption.Click();

            IWebElement saveStatus = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
            saveStatus.Click();
            Thread.Sleep(2000);

            driver.Navigate().Back();
            Thread.Sleep(2000);

            // Filter again
            IWebElement machineFilter1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
            machineFilter1.Clear();
            machineFilter1.SendKeys(MachineMapping.unmappedMachineForMapping + Keys.Enter);
            Thread.Sleep(3000);

            // Raise refill request
            IWebElement actionButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[10]")));
            actionButton.Click();
            Thread.Sleep(1000);

            IWebElement raiseRefillRequest = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Raise Refill Request')]")));
            raiseRefillRequest.Click();
            Thread.Sleep(3000);

            IWebElement saveRequest = wait.Until(
                ExpectedConditions.ElementIsVisible(By.XPath("//button[.//span[text()=' Save ']]")));
            saveRequest.Click();
            Thread.Sleep(1000);

            driver.Navigate().Back();
            Thread.Sleep(3000);

            // Warehouse Assigning
            IWebElement warTransactionsButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions")));
            warTransactionsButton.Click();
            Thread.Sleep(3000);

            IWebElement refillRequestMenu = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions2")));
            refillRequestMenu.Click();
            Thread.Sleep(3000);

            IWebElement actionButton1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
            actionButton1.Click();
            Thread.Sleep(1000);

            IWebElement assignWarehouseButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Assign Warehouse ')]")));
            assignWarehouseButton.Click();
            Thread.Sleep(1000);

            IWebElement warehouseDropdown = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("providorWarehouseId")));
            warehouseDropdown.Click();

            string chooseWarehouse = RaiseRefillRequestData.refillDatas["warehouseName"];
            driver.FindElement(By.XPath($"//span[contains(text(), ' {chooseWarehouse} ')]")).Click();

            IWebElement saveWarehouse = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
            saveWarehouse.Click();
            Thread.Sleep(3000);

            // Stock Selection
            IWebElement actionButton2 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
            actionButton2.Click();
            Thread.Sleep(1000);

            IWebElement selectStock = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Select Stock ')]")));
            selectStock.Click();
            Thread.Sleep(2000);

            // Save stock selection
            driver.FindElement(By.XPath("//button//span[text()=' Save ']")).Click();
            Thread.Sleep(4000);

            // Complete Refill
            IWebElement actionButton3 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
            actionButton3.Click();
            Thread.Sleep(1000);

            IWebElement completeRefill = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Complete Refill ')]")));
            completeRefill.Click();
            Thread.Sleep(2000);

            IWebElement checkAllButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[normalize-space()='Check All']")));
            checkAllButton.Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
            Thread.Sleep(4000);

            // Set Machine Status = ONLINE
            IWebElement machineMenu1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
            machineMenu1.Click();
            Thread.Sleep(1000);

            IWebElement machineList1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
            machineList1.Click();
            Thread.Sleep(2000);

            IWebElement machineFilter2 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
            machineFilter2.Clear();
            machineFilter2.SendKeys(MachineMapping.unmappedMachineForMapping + Keys.Enter);
            Thread.Sleep(2000);

            IWebElement actionBtn1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
            actionBtn1.Click();
            Thread.Sleep(1000);

            IWebElement machineDetails1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
            machineDetails1.Click();
            Thread.Sleep(3000);

            IWebElement selectStatus1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Operation Status')]/following::a[1]")));
            selectStatus1.Click();
            Thread.Sleep(1000);

            IWebElement statusDropdown1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("status")));
            statusDropdown1.Click();

            IWebElement onlineOption = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//mat-option//span[contains(normalize-space(),'Online')]")));
            onlineOption.Click();

            IWebElement saveStatus1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
            saveStatus1.Click();
            Thread.Sleep(2000);
        }
    }



    public class ReturnRequest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ReturnRequest(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void ReturnRequestFlow()
        {
            Thread.Sleep(2000);

            // Machines → Requests → Return
            By machineMenuBy = By.Id("menuItem-Machines");
            wait.Until(d => d.FindElement(machineMenuBy).Displayed);
            driver.FindElement(machineMenuBy).Click();

            By requestsBy = By.Id("menuItem-Machines2");
            wait.Until(d => d.FindElement(requestsBy).Displayed);
            driver.FindElement(requestsBy).Click();

            IWebElement returnTab = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//div[@role='tab']//div[text()='Return']")));
            returnTab.Click();
            Thread.Sleep(2000);

            IWebElement addReturnRequest = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button[contains (@mattooltip, 'Add Return request')]")));
            addReturnRequest.Click();
            Thread.Sleep(2000);

            string machineId = MachineMapping.unmappedMachineForMapping;
            Console.WriteLine("Selected machine for return: " + machineId);

            IWebElement machineDropdown = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("machineIds")));
            machineDropdown.Click();
            Thread.Sleep(2000);

            var machineOptions = wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("mat-option span")));

            foreach (var option in machineOptions)
            {
                if (option.Text.Trim().Equals(machineId, StringComparison.OrdinalIgnoreCase))
                {
                    option.Click();
                    break;
                }
            }

            IWebElement checkAllButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[normalize-space()='Check All']")));
            checkAllButton.Click();

            driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
            Thread.Sleep(3000);

            // W. Transactions → Return Requests
            IWebElement warTransactionsButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions")));
            warTransactionsButton.Click();
            Thread.Sleep(3000);

            IWebElement returnRequestMenu = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-W. Transactions3")));
            returnRequestMenu.Click();
            Thread.Sleep(3000);

            IWebElement searchTypeButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
            searchTypeButton.Click();
            Thread.Sleep(2000);

            IWebElement selectMachineId = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(normalize-space(),'Machine Id')]")));
            selectMachineId.Click();
            Thread.Sleep(2000);

            IWebElement searchRequest = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
            searchRequest.Clear();
            searchRequest.SendKeys(machineId + Keys.Enter);
            Thread.Sleep(2000);

            IWebElement actionButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[11]")));
            actionButton.Click();
            Thread.Sleep(1000);

            IWebElement assignWarehouseButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Assign Warehouse ')]")));
            assignWarehouseButton.Click();
            Thread.Sleep(2000);

            IWebElement warehouseDropdown = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("providorWarehouseId")));
            warehouseDropdown.Click();
            Thread.Sleep(2000);

            string chooseWarehouse = ReturnRequestData.refillDatas["warehouseName"];
            driver.FindElement(By.XPath($"//span[contains(text(), ' {chooseWarehouse} ')]")).Click();

            IWebElement saveWarehouse = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Save ']")));
            saveWarehouse.Click();
            Thread.Sleep(3000);

            IWebElement actionButton1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[11]")));
            actionButton1.Click();
            Thread.Sleep(2000);

            IWebElement pickupStock = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Pick Up Stock ')]")));
            pickupStock.Click();
            Thread.Sleep(3000);

            IWebElement confirmPickup = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()= ' Pick Up ']")));
            confirmPickup.Click();
            Thread.Sleep(3000);

            IWebElement actionButton2 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[11]")));
            actionButton2.Click();
            Thread.Sleep(2000);

            IWebElement completeReturn = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Complete Return ')]")));
            completeReturn.Click();
            Thread.Sleep(2000);

            IWebElement checkAllButton1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[normalize-space()='Check All']")));
            checkAllButton1.Click();
            driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
            Thread.Sleep(4000);

            // Update Location
            IWebElement machineMenu1 = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines")));
            machineMenu1.Click();

            IWebElement machineList = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Machines0")));
            machineList.Click();

            IWebElement searchText = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
            searchText.Clear();
            searchText.SendKeys(machineId + Keys.Enter);
            Thread.Sleep(3000);

            IWebElement actionBtn = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector(".mat-focus-indicator.mat-menu-trigger.mat-icon-button.mat-button-base")));
            actionBtn.Click();

            IWebElement machineDetails = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.ClassName("mat-menu-item")));
            machineDetails.Click();
            Thread.Sleep(3000);

            IWebElement selectLocation = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='cityText']")));
            selectLocation.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("City")))
                .SendKeys(LocationData.location[0, 0]);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("State")))
                .SendKeys(LocationData.location[0, 1]);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("pluscode")))
                .SendKeys(LocationData.location[0, 2]);

            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//button//span[contains(text(),' Validate Plus Code ')]"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//span[contains(text(), ' Save ')]"))).Click();
        }
    }


    public class MachineScrapping
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MachineScrapping(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void MachineScrappingFlow()
        {
            Thread.Sleep(2000);

            // Navigate to Current Purchase Order
            IWebElement currentPurchaseOrderMenu = wait.Until(
                ExpectedConditions.ElementExists(By.XPath("//div[contains(text(),'Current Purchase Order')]")));
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView({block:'center'});", currentPurchaseOrderMenu);
            Thread.Sleep(300);
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", currentPurchaseOrderMenu);
            Thread.Sleep(2000);

            // Search Machine to Scrap
            IWebElement searchTypeButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
            searchTypeButton.Click();
            Thread.Sleep(2000);

            IWebElement selectMachineId = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(normalize-space(),'Machine Id')]")));
            selectMachineId.Click();
            Thread.Sleep(2000);

            string machineId = MachineMapping.unmappedMachineForMapping;
            Console.WriteLine("Selecting machine for scrap: " + machineId);

            IWebElement searchMachine = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
            searchMachine.Clear();
            searchMachine.SendKeys(machineId + Keys.Enter);
            Thread.Sleep(2000);

            IWebElement actionButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
            actionButton.Click();
            Thread.Sleep(1000);

            IWebElement scrapButton = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Move to scrap ')]")));
            scrapButton.Click();
            Thread.Sleep(2000);

            IWebElement confirmScrapping = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(),' Confirm ')]")));
            confirmScrapping.Click();
            Thread.Sleep(2000);

            Console.WriteLine("Machine scrapped successfully: " + machineId);
        }
    }

}
