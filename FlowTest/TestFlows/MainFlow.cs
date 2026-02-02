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
using VMS_Phase1PortalAT.FlowTest.Product.Brand;
using VMS_Phase1PortalAT.FlowTest.Product.Categories;
using VMS_Phase1PortalAT.FlowTest.Product.ProductList;
using VMS_Phase1PortalAT.FlowTest.Product.Subcategories;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

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

}
